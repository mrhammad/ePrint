import { chromium } from 'playwright';

const base = 'http://localhost:1111';
const email = 'test2174@globotech.test';
const password = '12345678';
const newUserEmail = `guiuser_${Date.now()}@globotech.test`;

const browser = await chromium.launch({ headless: true });
const page = await browser.newPage();
const errors = [];

page.on('pageerror', (err) => errors.push(`pageerror: ${err.message}`));
page.on('console', (msg) => {
  if (msg.type() === 'error') errors.push(`console: ${msg.text()}`);
});

try {
  console.log('1. Login...');
  await page.goto(`${base}/Login/Login.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  const title = await page.title();
  if (/Server Error|Could not load/i.test(title)) {
    throw new Error(`Login page failed: ${title}`);
  }
  await page.fill('#email', email);
  await page.fill('#password', password);
  await page.click('#btnlogin', { noWaitAfter: true, timeout: 10000 });
  for (let i = 0; i < 90; i++) {
    const url = page.url();
    if (!/login\.aspx/i.test(url)) break;
    await page.waitForTimeout(1000);
  }
  console.log('   URL after login:', page.url());

  if (page.url().toLowerCase().includes('login.aspx')) {
    const errText = await page.locator('.errorMsg, #lblerror, .validation-msg').allTextContents();
    throw new Error(`Login failed. Messages: ${errText.join(' | ') || '(none)'}`);
  }

  console.log('2. User Manager...');
  await page.goto(`${base}/Settings/user_manager.aspx`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  console.log('   user_manager URL:', page.url());
  const umTitle = await page.title();
  const umHtml = await page.content();
  if (/resource cannot be found|404/i.test(umHtml) && !/User Manager/i.test(umTitle)) {
    throw new Error(`user_manager 404 at ${page.url()}`);
  }
  if (/Server Error|NullReference|Exception Details/i.test(umHtml)) {
    const match = umHtml.match(/<h2>\s*<i>([^<]+)<\/i>/i) || umHtml.match(/<title>([^<]+)<\/title>/i);
    await page.screenshot({ path: 'user_manager_error.png', fullPage: true }).catch(() => {});
    throw new Error(`user_manager failed: ${match ? match[1] : umTitle}`);
  }
  console.log('   User Manager loaded:', umTitle);

  console.log('3. Add New User...');
  await page.goto(`${base}/Settings/user_add.aspx?type=add`, { waitUntil: 'domcontentloaded', timeout: 60000 });
  const addContent = await page.content();
  if (/Server Error|NullReference|Exception Details/i.test(addContent)) {
    throw new Error('user_add page server error');
  }

  const nameSel = 'input[id$="txtname"]';
  const emailSel = 'input[id$="txtemail"]';
  const passSel = 'input[id$="txtpassword"]';
  const confirmSel = 'input[id$="txtconfirmpassword"]';

  await page.waitForSelector(nameSel, { timeout: 15000 });
  await page.fill(nameSel, 'GUI Test User');
  await page.fill(emailSel, newUserEmail);
  await page.fill(passSel, 'TestPass99!');
  await page.fill(confirmSel, 'TestPass99!');

  const roleSelect = page.locator('select[id$="ddlrole"]');
  if ((await roleSelect.count()) > 0) {
    const options = await roleSelect.locator('option').allTextContents();
    console.log('   Roles:', options.join(', '));
    if (options.length > 1) await roleSelect.selectOption({ index: 1 });
  }

  const landingSelect = page.locator('select[id$="ddlDefaultLanding"]');
  if ((await landingSelect.count()) > 0 && (await landingSelect.locator('option').count()) > 0) {
    await landingSelect.selectOption({ index: 0 });
  }

  console.log('4. Save...');
  const saveBtn = page.locator('input[id$="btnSave"], button[id$="btnSave"], a[id$="btnSave"]').first();
  if ((await saveBtn.count()) === 0) {
    await page.locator('[id$="btnSave"]').first().click({ force: true });
  } else {
    await saveBtn.click({ force: true });
  }
  await page.waitForLoadState('networkidle', { timeout: 60000 }).catch(() => {});

  console.log('   URL after save:', page.url());
  const afterSave = await page.content();
  if (/Server Error|NullReference|Exception Details/i.test(afterSave)) {
    throw new Error('Error after save');
  }
  if (afterSave.includes('EmailAddress_Duplicate') || afterSave.includes('already exist')) {
    throw new Error('Duplicate email message shown');
  }

  if (page.url().includes('user_manager')) {
    console.log('SUCCESS: redirected to user_manager');
  } else {
    console.log('WARN: expected user_manager redirect');
  }

  if (errors.length) {
    console.log('Client errors:', errors.join('\n'));
  }
  console.log('New user email:', newUserEmail);
} catch (e) {
  console.error('FAILED:', e.message);
  process.exitCode = 1;
} finally {
  await browser.close();
}
