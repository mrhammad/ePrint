import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'info@globotech.tech';
const password = '12345';

const itemPages = {
  S: (estId, itemId) => `${base}/Estimates/estimate_single_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=S`,
  L: (estId, itemId) => `${base}/Estimates/estimate_large_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=L`,
  C: (estId, itemId) => `${base}/Estimates/estimate_pricecatalog.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=C&maintype=edit`,
  U: (estId, itemId) => `${base}/Estimates/estimate_Othercost.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=U`,
  W: (estId, itemId) => `${base}/Estimates/estimate_warehouse.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=W`,
  Q: (estId, itemId) => `${base}/Estimates/estimate_quickquote.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=Q`,
};

const samples = [
  { estId: '28892', num: 'EST-0000001', title: 'Test', items: [{ id: '103410', type: 'W' }, { id: '103411', type: 'W' }] },
  { estId: '28893', num: 'EST-0000002', title: '123', items: [{ id: '103412', type: 'S' }] },
  { estId: '28894', num: 'EST-0000003', title: 'test', items: [{ id: '103413', type: 'C' }, { id: '103414', type: 'C' }] },
  { estId: '28895', num: 'EST-0000004', title: 'test', items: [{ id: '103415', type: 'C' }, { id: '103416', type: 'C' }] },
  { estId: '28896', num: 'EST-0000005', title: 'Price Per Unit Test', items: [{ id: '103417', type: 'C' }, { id: '103418', type: 'Q' }, { id: '103419', type: 'Q' }, { id: '103420', type: 'U' }] },
  { estId: '28897', num: 'EST-0000006', title: 'Price Per Unit Test 3', items: [{ id: '103421', type: 'L' }, { id: '103422', type: 'U' }] },
  { estId: '28898', num: 'EST-0000007', title: '1', items: [{ id: '103423', type: 'Q' }] },
  { estId: '28899', num: 'EST-0000008', title: '123', items: [{ id: '103424', type: 'U' }] },
];

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const failures = [];

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
  for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) await page.waitForTimeout(1000);
  if (/login\.aspx/i.test(page.url())) throw new Error('Login failed');

  await page.goto(`${base}/Estimates/estimate_view.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  const viewHtml = await page.content();
  let err = checkHtml('estimate_view', viewHtml, page.url());
  if (err) failures.push(err);
  else if (/No records to display/i.test(viewHtml)) failures.push('estimate_view: grid shows no records (wrong view filter?)');
  else console.log('estimate_view: grid has data');

  for (const sample of samples) {
    const summaryUrl = `${base}/Estimates/estimate_summary_reeng.aspx?estid=${sample.estId}&type=edit`;
    await page.goto(summaryUrl, { waitUntil: 'domcontentloaded', timeout: 90000 });
    err = checkHtml(`${sample.num} summary`, await page.content(), page.url());
    if (err) failures.push(err);
    else console.log(`OK ${sample.num} summary`);

    for (const item of sample.items) {
      await page.goto(itemPages[item.type](sample.estId, item.id), { waitUntil: 'domcontentloaded', timeout: 90000 });
      await page.waitForTimeout(1500);
      err = checkHtml(`${sample.num} item ${item.type}`, await page.content(), page.url());
      if (err) failures.push(err);
      else console.log(`  OK item ${item.type}`);
    }
  }

  if (failures.length) {
    console.error('\nFAILURES:');
    failures.forEach((f) => console.error(' -', f));
    process.exitCode = 1;
  } else console.log('\nAll samples OK for info@globotech.tech');
} catch (e) {
  console.error('FAILED:', e.message);
  process.exitCode = 1;
} finally {
  await browser.close();
}
