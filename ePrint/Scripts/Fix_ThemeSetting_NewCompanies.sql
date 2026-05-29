-- New registrations were missing tb_ThemeSetting, so crm_selecttheme returned no rows
-- and the app built broken image URLs (404 on radimg1.gif, lockclosed.png, etc.).
INSERT INTO tb_ThemeSetting (ImageFolder, theme, CompanyID, CreatedDate)
SELECT N'images', N'Theme1', c.companyID, GETDATE()
FROM tb_company c
WHERE ISNULL(c.isDelete, 0) = 0
  AND NOT EXISTS (SELECT 1 FROM tb_ThemeSetting t WHERE t.CompanyID = c.companyID);

SELECT CompanyID, ImageFolder, theme FROM tb_ThemeSetting
WHERE CompanyID IN (SELECT companyID FROM tb_company WHERE ISNULL(isDelete, 0) = 0)
ORDER BY CompanyID DESC;
