import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'test2174@globotech.test';
const password = '12345678';

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const jsErrors = [];

page.on('pageerror', (err) => jsErrors.push(err.message));

await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded' });
await page.fill('#email', email);
await page.fill('#password', password);
await page.click('#btnlogin', { noWaitAfter: true });
for (let i = 0; i < 60 && /login\.aspx/i.test(page.url()); i++) {
  await page.waitForTimeout(1000);
}

await page.goto(`${base}/Settings/templates.aspx?page=Estimate`, { waitUntil: 'domcontentloaded', timeout: 60000 });
const listHtml = await page.content();
if (/Server Error|Exception Details/i.test(listHtml)) {
  console.error('templates list failed to load');
  process.exit(1);
}

const editLink = page.locator('a[href*="templates_add.aspx"]').first();
if ((await editLink.count()) === 0) {
  console.error('No edit link on templates list');
  process.exit(1);
}

const href = await editLink.getAttribute('href');
await page.goto(href.startsWith('http') ? href : `${base}/Settings/${href.replace(/^\//, '')}`, {
  waitUntil: 'domcontentloaded',
  timeout: 60000,
});

const editorHtml = await page.content();
const hasGeneral = /js\/item\/general\.js/i.test(editorHtml);
const hasRgb = /js\/rgbcolor\.js/i.test(editorHtml);

console.log('general.js referenced:', hasGeneral);
console.log('rgbcolor.js referenced:', hasRgb);
console.log('trim12 defined:', await page.evaluate(() => typeof trim12 === 'function'));
console.log('SpecialDecode defined:', await page.evaluate(() => typeof SpecialDecode === 'function'));

const addFieldBtn = page.locator('input[value*="Add Field"], input[onclick*="AddField"]').first();
if ((await addFieldBtn.count()) > 0) {
  await addFieldBtn.click({ timeout: 5000 }).catch(() => {});
  await page.waitForTimeout(500);
}

const relevant = jsErrors.filter((e) => /trim12|SpecialDecode/i.test(e));
if (relevant.length) {
  console.error('JS errors:', relevant);
  process.exit(1);
}

console.log('No trim12/SpecialDecode errors. Total page errors:', jsErrors.length);
await browser.close();
process.exit(hasGeneral && (await page.evaluate(() => typeof trim12 === 'function')) ? 0 : 1);
