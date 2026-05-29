import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'hammad@globotech.tech';
const password = '12345678';

const itemPages = {
  S: (estId, itemId) => `${base}/Estimates/estimate_single_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=S`,
  L: (estId, itemId) => `${base}/Estimates/estimate_large_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=L`,
  F: (estId, itemId) => `${base}/Estimates/estimate_large_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=F`,
  C: (estId, itemId) => `${base}/Estimates/estimate_pricecatalog.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=C&maintype=edit`,
  U: (estId, itemId) => `${base}/Estimates/estimate_Othercost.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=U`,
  W: (estId, itemId) => `${base}/Estimates/estimate_warehouse.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=W`,
  Q: (estId, itemId) => `${base}/Estimates/estimate_quickquote.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=Q`,
};

const samples = [
  { estId: '28900', num: 'EST-0000001', title: 'Test', items: [{ id: '103425', type: 'W' }, { id: '103426', type: 'W' }] },
  { estId: '28901', num: 'EST-0000002', title: '123', items: [{ id: '103427', type: 'S' }] },
  { estId: '28902', num: 'EST-0000003', title: 'test', items: [{ id: '103428', type: 'C' }, { id: '103429', type: 'C' }] },
  { estId: '28903', num: 'EST-0000004', title: 'test', items: [{ id: '103430', type: 'C' }, { id: '103431', type: 'C' }] },
  { estId: '28904', num: 'EST-0000005', title: 'Price Per Unit Test', items: [{ id: '103432', type: 'C' }, { id: '103433', type: 'Q' }, { id: '103434', type: 'Q' }, { id: '103435', type: 'U' }] },
  { estId: '28905', num: 'EST-0000006', title: 'Price Per Unit Test 3', items: [{ id: '103436', type: 'L' }, { id: '103437', type: 'U' }] },
  { estId: '28906', num: 'EST-0000007', title: '1', items: [{ id: '103438', type: 'Q' }] },
  { estId: '28907', num: 'EST-0000008', title: '123', items: [{ id: '103439', type: 'U' }] },
];

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const failures = [];
const jsErrors = [];

page.on('pageerror', (err) => jsErrors.push(err.message));

function checkHtml(label, html, url) {
  if (/unauthorized_access/i.test(url)) return `${label}: unauthorized`;
  if (/Server Error|Exception Details|Parser Error/i.test(html)) {
    const m = html.match(/<title>([^<]+)<\/title>/i) || html.match(/Message:<\/b>\s*([^<]+)/i);
    return `${label}: server error - ${m ? m[1].trim() : 'unknown'}`;
  }
  if (/NullReferenceException/i.test(html)) return `${label}: NullReferenceException`;
  return null;
}

try {
  await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  await page.fill('#email', email);
  await page.fill('#password', password);
  await page.click('#btnlogin', { noWaitAfter: true });
  for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) {
    await page.waitForTimeout(1000);
  }
  if (/login\.aspx/i.test(page.url())) {
    throw new Error('Login failed - still on login page');
  }
  console.log('Logged in:', page.url());

  await page.goto(`${base}/Estimates/estimate_view.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  let err = checkHtml('estimate_view', await page.content(), page.url());
  if (err) throw new Error(err);

  for (const sample of samples) {
    const summaryUrl = `${base}/Estimates/estimate_summary_reeng.aspx?estid=${sample.estId}&type=edit`;
    await page.goto(summaryUrl, { waitUntil: 'domcontentloaded', timeout: 90000 });
    err = checkHtml(`${sample.num} summary`, await page.content(), page.url());
    if (err) {
      failures.push(err);
      continue;
    }
    console.log(`OK ${sample.num} summary (${sample.title})`);

    for (const item of sample.items) {
      const itemUrl = itemPages[item.type](sample.estId, item.id);
      await page.goto(itemUrl, { waitUntil: 'domcontentloaded', timeout: 90000 });
      await page.waitForTimeout(1500);
      err = checkHtml(`${sample.num} item ${item.type} (${item.id})`, await page.content(), page.url());
      if (err) failures.push(err);
      else console.log(`  OK item ${item.type} id=${item.id}`);
    }
  }

  const recentJs = [...new Set(jsErrors)].slice(-10);
  if (recentJs.length) {
    console.log('JS errors (may be benign):');
    recentJs.forEach((e) => console.log('  ', e.slice(0, 200)));
  }

  if (failures.length) {
    console.error('\nFAILURES:');
    failures.forEach((f) => console.error(' -', f));
    process.exitCode = 1;
  } else {
    console.log('\nAll 8 registration sample estimates opened successfully (summary + all items).');
  }
} catch (e) {
  console.error('FAILED:', e.message);
  process.exitCode = 1;
} finally {
  await browser.close();
}
