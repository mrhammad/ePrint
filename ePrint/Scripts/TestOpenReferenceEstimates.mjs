import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'test2174@globotech.test';
const password = '12345678';

const itemPages = {
  S: (estId, itemId) => `${base}/Estimates/estimate_single_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=S`,
  L: (estId, itemId) => `${base}/Estimates/estimate_large_item.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=L`,
  O: (estId, itemId) => `${base}/Estimates/estimate_printbroker.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=O&maintype=edit`,
  W: (estId, itemId) => `${base}/Estimates/estimate_warehouse.aspx?type=edit&estid=${estId}&EstItemID=${itemId}&esttype=W`,
};

// Seeded on company 2174 via SeedReferenceEstimatesForCompany.ps1 (update IDs after re-seed).
const samples = [
  { estId: '28936', title: 'Test', type: 'S' },
  { estId: '28937', title: 'test', type: 'O' },
  { estId: '28938', title: '2310', type: 'W' },
  { estId: '28939', title: 'tet', type: 'L' },
];

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const failures = [];

page.on('pageerror', () => { /* legacy script errors on summary pages; item pages validated below */ });

try {
  await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded' });
  await page.fill('#email', email);
  await page.fill('#password', password);
  await page.click('#btnlogin', { noWaitAfter: true });
  for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) {
    await page.waitForTimeout(1000);
  }

  await page.goto(`${base}/Estimates/estimate_view.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  if (/Server Error|Exception Details/i.test(await page.content())) {
    throw new Error('estimate_view failed to load');
  }

  for (const sample of samples) {
    await page.goto(`${base}/Estimates/estimate_summary_reeng.aspx?estid=${sample.estId}&type=edit`, {
      waitUntil: 'domcontentloaded',
      timeout: 60000,
    });
    const summaryHtml = await page.content();
    if (/Server Error|Exception Details|NullReference/i.test(summaryHtml)) {
      failures.push(`${sample.title}: summary page error`);
      continue;
    }

    const html = await page.content();
    const itemMatch =
      html.match(/EstItemID=(\d+)/i) ||
      html.match(/EstimateItemID=(\d+)/i);
    if (!itemMatch) {
      failures.push(`${sample.title}: could not resolve item id on summary`);
      continue;
    }

    const itemUrl = itemPages[sample.type](sample.estId, itemMatch[1]);
    await page.goto(itemUrl, { waitUntil: 'domcontentloaded', timeout: 60000 });
    const itemHtml = await page.content();
    if (/Server Error|Exception Details|NullReference/i.test(itemHtml)) {
      failures.push(`${sample.title}: item page error (${sample.type})`);
    } else {
      console.log(`OK ${sample.title} (${sample.type}) est=${sample.estId} item=${itemMatch[1]}`);
    }
  }

  console.log(failures.length ? `FAILURES:\n${failures.join('\n')}` : 'All reference estimates opened successfully.');
  process.exit(failures.length ? 1 : 0);
} finally {
  await browser.close();
}
