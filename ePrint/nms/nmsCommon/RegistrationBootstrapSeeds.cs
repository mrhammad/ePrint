using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>Built-in CRM registration template. No runtime read from company 0 or 2144.</summary>
	internal static class RegistrationBootstrapSeeds
	{
		public static void Apply(int companyId, SqlConnection connection)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			Execute(companyId, connection, LookupAndNavigationSql);
			Execute(companyId, connection, ClientCustomizeSql);
			Execute(companyId, connection, ContactCustomizeSql);
			Execute(companyId, connection, CustomizeSubsectionSql);
		}

		private static void Execute(int companyId, SqlConnection connection, string sql)
		{
			string resolvedSql = sql.Replace("{COUNTRY_LIST}", CountryOptionValues.List.Replace("'", "''"));
			using (SqlCommand command = new SqlCommand(resolvedSql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.ExecuteNonQuery();
			}
		}

		private const string LookupAndNavigationSql = @"		IF NOT EXISTS (SELECT 1 FROM tb_backendemailmessages WHERE companyID = @companyId)
		BEGIN
			DECLARE @welcomeMsg nvarchar(max) = N'<p>Welcome to Print Management Software,<br /><br />Thank you for registering.</p>';
			INSERT INTO tb_backendemailmessages (companyID, sectionname, languagename, message, registrationEmail, subject) VALUES
				(@companyId, N'Registration', N'English', @welcomeMsg, N'', N'Print Management Software Notification Mail'),
				(@companyId, N'Add User', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Add New Company', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Web To Ticket', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Convert Lead', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Add Task', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Edit Task', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Invalid Login attempts', N'English', @welcomeMsg, N'', N'Thank you for opting for eCRM247 solution');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_installmentperiod WHERE companyid = @companyId)
		BEGIN
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Daily','Spanish');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Monthly','Spanish');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Quarterly','Spanish');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Weekly','Spanish');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Yearly','Spanish');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Daily','English');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Monthly','English');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Quarterly','English');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Weekly','English');
		INSERT INTO tb_installmentperiod (companyid,installmentPeriod,languagename) VALUES (@companyId,'Yearly','English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_scheduleType WHERE companyid = @companyId)
		BEGIN
		INSERT INTO tb_scheduleType (companyid,scheduleType,languagename) VALUES (@companyId,'Divide Amount into multiple installments','Spanish');
		INSERT INTO tb_scheduleType (companyid,scheduleType,languagename) VALUES (@companyId,'Repeat Amount for each installment','Spanish');
		INSERT INTO tb_scheduleType (companyid,scheduleType,languagename) VALUES (@companyId,'Divide Amount into multiple installments','English');
		INSERT INTO tb_scheduleType (companyid,scheduleType,languagename) VALUES (@companyId,'Repeat Amount for each installment','English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_ownershiptype WHERE companyid = @companyId)
		BEGIN
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Public','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Private','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Subsidiary','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Others','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Hotel Clubs','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Non Profit Making Organisation','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'School Institution','Spanish');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Hotel Clubs','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Non Profit Making Organisation','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Others','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Private','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Public','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'School Institution','English');
		INSERT INTO tb_ownershiptype (companyid,ownershiptype,languagename) VALUES (@companyId,'Subsidiary','English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_partnerRole WHERE companyID = @companyId)
		BEGIN
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Advertiser',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Agency',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Broker',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Consultant',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Dealer',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Developer',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Distributer',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Institution',@companyId,'English');
		INSERT INTO tb_partnerRole (RoleName,companyID,languagename) VALUES ('Lender',@companyId,'English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_clienttype WHERE companyid = @companyId)
		BEGIN
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Client','Spanish');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Competitor','Spanish');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Other','Spanish');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Prospect','Spanish');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Supplier','Spanish');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Client','English');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Competitor','English');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'ljkljkl','English');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Other','English');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Prospect','English');
		INSERT INTO tb_clienttype (companyid,clienttypename,languagename) VALUES (@companyId,'Supplier','English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_role WHERE companyID = @companyId)
		BEGIN
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Business User',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Decision Maker',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Econoimic Buyer',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Economoc Decision',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Evaluator',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Executive Sponsor',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Influencer',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Other',@companyId,'English');
		INSERT INTO tb_role (roleName,companyID,languagename) VALUES ('Sponser',@companyId,'English');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_lowernavigator WHERE companyid = @companyId)
		BEGIN
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Lead', 2, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Client', 3, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Contact', 4, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Opportunity', 5, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Campaign', 7, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Product', 8, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Contract', 9, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Ticket', 11, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Solution', 12, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'Recycle Bin', 13, @companyId, N'', 1);
		END
		IF NOT EXISTS (SELECT 1 FROM tb_uppernavigator WHERE companyid = @companyId)
		BEGIN
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'HOME', 0, @companyId, N'#2259D7', 1, N'', N'Home', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'CLIENTS', 1, @companyId, N'#2259D7', 1, N'', N'CRM', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'ESTIMATES', 2, @companyId, N'#2259D7', 1, N'', N'Estimates', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'JOBS', 3, @companyId, N'#2259D7', 1, N'', N'Jobs', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'PURCHASES', 4, @companyId, N'#2259D7', 1, N'', N'Purchases', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'DELIVERYNOTE', 5, @companyId, N'#2259D7', 1, N'', N'Delivery Note', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'INVOICES', 6, @companyId, N'#2259D7', 1, N'', N'Invoices', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'WAREHOUSE', 7, @companyId, N'#2259D7', 1, N'', N'Warehouse', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'DOCUMENTS', 8, @companyId, N'#2259D7', 1, N'', N'Documents', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'REPORTS', 9, @companyId, N'#2259D7', 1, N'', N'Reports', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'CAMPAIGN', 10, @companyId, N'#2259D7', 1, N'', N'Campaign', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'SETTINGS', 11, @companyId, N'#2259D7', 1, N'', N'Settings', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'PRODUCTCATALOGUE', 12, @companyId, N'#8484FF', 1, N'', N'Products', N'#FFFFFF');
		END";

		private const string ClientCustomizeSql = @"
		IF NOT EXISTS (SELECT 1 FROM tb_clientcustomize WHERE companyId = @companyId)
		BEGIN
		DECLARE @countryList nvarchar(max) = N'{COUNTRY_LIST}';
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'clientname','Client Name','Company Name                                                                                        ','clientname','text','nvarchar',1,1,1,0,0,'','',300,'d         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'AccountStatus','Account Status','Account Status                                                                                      ','AccountStatus','text','text',1,0,0,0,6,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Clientalias','Client Alias','Company Alias                                                                                       ','Clientalias','text','nvarchar',1,1,1,0,14,'','',200,'d         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Type','Type','Type                                                                                                ','Type','text','text',1,0,0,0,20,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Account','Account No ','Account No                                                                                          ','Account','text','text',1,0,0,0,28,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Address1','Address1','Address Line 1                                                                                      ','Address1','text','text',1,0,0,0,36,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Address3','Address3','Address Line 3                                                                                      ','Address3','text','text',1,0,0,0,44,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'State/Country','State/Country','Address Line 2                                                                                      ','State/Country','text','text',1,0,0,0,52,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'PostalCode','PostalCode','Business Address Line 4                                                                             ','PostalCode','text','text',1,0,0,0,60,'','',20,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Country','Country','Country                                                                                             ','Country','select','select',1,0,0,0,68,'',@countryList,0,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Telephone','Telephone','Telephone                                                                                           ','Telephone','text','text',1,0,0,0,76,'','',20,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'fax','Fax','Fax                                                                                                 ','fax','text','nvarchar',1,0,0,0,84,'','',25,'d         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Email','Email','Email                                                                                               ','Email','email','email',1,0,0,0,92,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'DefaultInvoiceaddress','Default Invoice address','Default Invoice Address                                                                             ','DefaultInvoiceaddress','checkbox','checkbox',1,0,0,0,100,'','',0,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'DefaultDeliveryaddress','Default Delivery address','Default Delivery Address                                                                            ','DefaultDeliveryaddress','checkbox','checkbox',1,0,0,0,108,'','',0,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'website','Website','URL                                                                                                 ','website','text','nvarchar',1,0,0,0,116,'','',200,'d         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'CreditLimit','Credit Limit ','Credit Limit                                                                                        ','CreditLimit','text','text',1,0,0,0,124,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'CreditRef','Credit Ref','Credit Ref                                                                                          ','CreditRef','text','text',1,0,0,0,132,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'A/COpened','A/C Opened','A/C Opened                                                                                          ','A/COpened','text','text',1,0,0,0,140,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'TaxRegNo','Tax Reg No','Tax Reg No                                                                                          ','TaxRegNo','text','text',1,0,0,0,148,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Terms','Terms ','Terms                                                                                               ','Terms','text','text',1,0,0,0,156,'','',50,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'CompanyNumber','Company Number','Company Number                                                                                      ','CompanyNumber','text','text',1,0,0,0,164,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'ProfitMargin','Profit Margin','Profit Margin                                                                                       ','ProfitMargin','select','select',1,0,0,0,172,'','0%,10%,20%,30%,50%,60%,70%,80%',0,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'A/COpened','A/C Opened','A/C Opened                                                                                          ','A/COpened','text','text',1,0,0,0,180,'','',50,'e         ',0,' ',1);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BankCode','Bank Code ','Bank Code                                                                                           ','BankCode','text','text',1,0,0,0,180,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BankAccount','Bank Account','Bank Account                                                                                        ','BankAccount','text','text',1,0,0,0,188,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'AccountName','Account Name','Account Name                                                                                        ','AccountName','text','text',1,0,0,0,196,'','',250,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'SalesPerson','Sales Person ','Sales Person                                                                                        ','SalesPerson','text','text',1,0,0,0,204,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'TaxNumber','Tax Number','Tax Number                                                                                          ','TaxNumber','text','text',1,0,0,0,212,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Balance','Balance','Balance                                                                                             ','Balance','text','text',1,0,0,0,220,'','',100,'e         ',0,' ',0);
		INSERT INTO tb_clientcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'description','Description','Description                                                                                         ','description','textarea','ntext',1,0,0,0,228,'','',2500,'d         ',0,' ',0);
		END";

		private const string ContactCustomizeSql = @"
		IF NOT EXISTS (SELECT 1 FROM tb_contactcustomize WHERE companyId = @companyId)
		BEGIN
		DECLARE @countryList nvarchar(max) = N'{COUNTRY_LIST}';
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'contactalias','Contact Alias','Contact Alias                                                                                       ','contactalias','text','nvarchar',1,0,1,0,0,'','',200,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'title','Title','Title                                                                                               ','title','text','nvarchar',1,0,0,0,8,'','',200,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'firstName','First Name','First Name                                                                                          ','firstName','text','nvarchar',1,0,1,0,16,'','',200,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'createDate','Create Date','Created On                                                                                          ','createDate','None','datetime',0,1,0,0,22,'','',1,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'modifiedDate','Modified Date','Modified On                                                                                         ','modifiedDate','None','datetime',0,1,0,0,23,'','',1,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'lastViewDate','Last View Date','Last Viewed On                                                                                      ','lastViewDate','None','datetime',0,1,0,0,24,'','',1,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'lastName','Last Name','Last Name                                                                                           ','lastName','text','nvarchar',1,1,1,0,24,'','',200,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'createUserID','Created By','Created By                                                                                          ','createUserID','None','int',0,1,0,0,25,'','',4,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'modifyUserID','Modified By','Modified By                                                                                         ','modifyUserID','None','int',0,1,0,0,26,'','',4,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'CompanyName','Company Name','Company Name                                                                                        ','CompanyName','text','text',1,0,0,0,30,'','',200,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'MiddleName','Middle Name','Middle Name                                                                                         ','MiddleName','text','text',0,0,0,0,38,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Email','Email','Email                                                                                               ','Email','email','email',1,0,1,0,46,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessAddress','Business Address','Business Address Line 1                                                                             ','BusinessAddress','text','text',1,0,0,0,54,'','',250,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessCity','Business City','Business Address Line 2                                                                             ','BusinessCity','text','text',1,0,0,0,62,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessState','Business State','Business Address Line 3                                                                             ','BusinessState','text','text',1,0,0,0,70,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessPostCode','Business Post Code','Business Address Line 4                                                                             ','BusinessPostCode','text','text',1,0,0,0,78,'','',20,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessCountry','Business Country','Business Country                                                                                    ','BusinessCountry','select','select',1,0,0,0,86,'',@countryList,50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessPhone','Business Phone','Business Phone                                                                                      ','BusinessPhone','text','text',1,0,0,0,94,'','',20,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessFax','Business Fax','Business Fax                                                                                        ','BusinessFax','text','text',1,0,0,0,102,'','',250,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'BusinessURL','Business URL','Business URL                                                                                        ','BusinessURL','text','text',1,0,0,0,110,'','',100,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomeAddress','Home Address','Home Address Line 1                                                                                 ','HomeAddress','text','text',1,0,0,0,118,'','',250,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomeCity','Home City','Home Address Line 2                                                                                 ','HomeCity','text','text',1,0,0,0,126,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomeState','Home State','Home Address Line 3                                                                                 ','HomeState','text','text',1,0,0,0,134,'','',50,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomePostCode','Home Post Code','Home Address Line 4                                                                                 ','HomePostCode','text','text',1,0,0,0,142,'','',20,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomeCountry','Home Country','Home Country                                                                                        ','HomeCountry','select','select',1,0,0,0,150,'',@countryList,20,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'HomePhone','Home Phone','Home Phone                                                                                          ','HomePhone','text','text',1,0,0,0,158,'','',20,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Mobile','Mobile','Mobile                                                                                              ','Mobile','text','text',1,0,0,0,166,'','',20,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Department','Department','Department                                                                                          ','Department','text','text',1,0,0,0,174,'','',50,'d         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'JobTitle','Job Title','Job Title                                                                                           ','JobTitle','text','text',1,0,0,0,182,'','',100,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'Notes','Notes','Notes                                                                                               ','Notes','text','text',0,0,0,0,190,'','',250,'e         ',0,'          ',0);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'DefaultInvoiceaddress','Default Invoice address ','Default Invoice address                                                                             ','DefaultInvoiceaddress','checkbox','checkbox',1,0,0,0,198,'','',0,'e         ',0,'          ',1);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'DefaultDeliveryaddress','Default Delivery address','Default Delivery address                                                                            ','DefaultDeliveryaddress','checkbox','checkbox',1,0,0,0,206,'','',0,'e         ',0,'          ',1);
		INSERT INTO tb_contactcustomize (companyId,databaseFieldName,labelName,screenName,inputBoxID,inputType,dataType,isDisplayed,isDefault,isRequired,isReadOnly,orderNumber,databaseName,optionvalue,maxLength,fieldType,decimalPlace,optionType,isDelete) VALUES (@companyId,'DefaultContact','Default Contact ','Default Contact                                                                                     ','DefaultContact','checkbox','checkbox',1,0,0,0,214,'','',0,'e         ',0,'          ',1);
		END";

		private const string CustomizeSubsectionSql = @"
		IF NOT EXISTS (SELECT 1 FROM tb_customizesubsection WHERE companyid = @companyId)
		BEGIN
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Open Activities',0,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Open Activities',0,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Marketing',0,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Notes',0,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Asset','Notes',0,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Asset','Open Activities',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Open Activities',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Product','Standard Price',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Price','Product',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Active History',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Active History',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Lead','Notes',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Notes',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Notes',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Notes',1,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Open Activities',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Open Activities',2,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Open Activities',2,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Notes',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Notes',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Solution','Notes',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Product','Price Books',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Active History',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Asset','Active History',2,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Asset','Ticket',3,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Home','Task',3,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Solution','Attachments',3,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','HTML Email',3,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Attachment',3,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Active History',3,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Active History',3,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Active History',3,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Contact Role',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Opportunity',4,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Contacts',4,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Lead','Active History',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Ticket History',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Opportunity',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Solution','Ticket',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Solution','Solution History',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Home','Opportunity',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Campaign','Attachment',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Asset','Attachment',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Approval Request',4,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Contract History',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Home','Lead',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('TICKET','Solution',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Attachment',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Attachment',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Attachment',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Opportunity',5,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contact','Ticket',5,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Competitors',5,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('opportunity','Stage History',6,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Ticket',6,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Contract','Attachment',6,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','Partners',7,'#DDDDDD',@companyId,0);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Lead','Attachment',7,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Home','Graph',8,'',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('CLIENT','HTML Email',8,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Lead','Open Activities',10,'#DDDDDD',@companyId,1);
		INSERT INTO tb_customizesubsection (sectionname,subsectionname,ordernumber,navigationcolor,companyid,isdisplay) VALUES ('Lead','HTML Email',13,'#DDDDDD',@companyId,1);
		END";
	}
}

