import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'hammad@globotech.tech';
const password = '12345678';

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();

try {
  await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  await page.fill('#email', email);
  await page.fill('#password', password);
  await page.click('#btnlogin', { noWaitAfter: true });
  for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) await page.waitForTimeout(1000);
  if (/login\.aspx/i.test(page.url())) throw new Error('Login failed');

  await page.goto(`${base}/Estimates/estimate_view.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  await page.waitForTimeout(3000);
  const html = await page.content();
  const hasNoRecords = /No records to display/i.test(html);
  const hasEst = /EST-\d+/i.test(html);
  console.log('estimate_view: noRecords=', hasNoRecords, 'hasEST=', hasEst);
  if (hasNoRecords && !hasEst) process.exitCode = 1;
} catch (e) {
  console.error('FAILED:', e.message);
  process.exitCode = 1;
} finally {
  await browser.close();
}
