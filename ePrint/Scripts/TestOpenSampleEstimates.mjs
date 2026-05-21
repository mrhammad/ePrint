import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'test2174@globotech.test';
const password = '12345678';

const itemPages = {
  S: (estId, itemId) => `${base}/Estimates/estimate_single_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=S`,
  L: (estId, itemId) => `${base}/Estimates/estimate_litho_single_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=L`,
  F: (estId, itemId) => `${base}/Estimates/estimate_large_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=F`,
  O: (estId, itemId) => `${base}/Estimates/estimate_printbroker.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=O&maintype=edit`,
  U: (estId, itemId) => `${base}/Estimates/estimate_Othercost.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=U`,
  W: (estId, itemId) => `${base}/Estimates/estimate_warehouse.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=W`,
  Q: (estId, itemId) => `${base}/Estimates/estimate_quickquote.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=Q`,
};

const demos = [
  { num: 'DEMO-001', type: 'S' },
  { num: 'DEMO-002', type: 'L' },
  { num: 'DEMO-003', type: 'F' },
  { num: 'DEMO-004', type: 'O' },
  { num: 'DEMO-005', type: 'U' },
  { num: 'DEMO-006', type: 'W' },
  { num: 'DEMO-007', type: 'Q' },
];

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const failures = [];

page.on('pageerror', (err) => failures.push(`JS: ${err.message}`));

try {
  await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded' });
  await page.fill('#email', email);
  await page.fill('#password', password);
  await page.click('#btnlogin', { noWaitAfter: true });
  for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) await page.waitForTimeout(1000);

  await page.goto(`${base}/Estimates/estimate_view.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  const listHtml = await page.content();
  if (/Server Error|Exception Details/i.test(listHtml)) {
    throw new Error('estimate_view failed to load');
  }

  for (const demo of demos) {
    const link = page.locator(`a:has-text("${demo.num}")`).first();
    if ((await link.count()) === 0) {
      failures.push(`${demo.num}: not found on estimate list`);
      continue;
    }
    await link.click({ noWaitAfter: true });
    await page.waitForTimeout(2500);
    const summaryUrl = page.url();

    const itemLink = page.locator('a[href*="EstItemID"], a[href*="EstimateItemID"]').first();
    let estId = '';
    let itemId = '';
    const href = (await itemLink.count()) > 0 ? await itemLink.getAttribute('href') : '';
    if (href) {
      const estMatch = href.match(/estid=(\d+)/i);
      const itemMatch = href.match(/EstItemID=(\d+)/i) || href.match(/EstimateItemID=(\d+)/i);
      estId = estMatch ? estMatch[1] : '';
      itemId = itemMatch ? itemMatch[1] : '';
    }

    if (!estId || !itemId) {
      const m = summaryUrl.match(/estid=(\d+)/i);
      if (m) estId = m[1];
    }

    if (!estId || !itemId) {
      failures.push(`${demo.num}: could not resolve estimate/item ids (url=${summaryUrl})`);
      continue;
    }

    const itemUrl = itemPages[demo.type](estId, itemId);
    await page.goto(itemUrl, { waitUntil: 'domcontentloaded', timeout: 60000 });
    const html = await page.content();
    if (/Server Error|Exception Details|NullReference/i.test(html)) {
      const title = await page.title();
      failures.push(`${demo.num} (${demo.type}): server error on item page - ${title}`);
    } else if (/unauthorized_access/i.test(page.url())) {
      failures.push(`${demo.num} (${demo.type}): unauthorized`);
    } else {
      console.log(`OK ${demo.num} ${demo.type} est=${estId} item=${itemId}`);
    }
  }

  if (failures.length) {
    console.error('Failures:');
    failures.forEach((f) => console.error(' -', f));
    process.exitCode = 1;
  } else {
    console.log('All sample estimate item types opened successfully.');
  }
} catch (e) {
  console.error('FAILED:', e.message);
  process.exitCode = 1;
} finally {
  await browser.close();
}
