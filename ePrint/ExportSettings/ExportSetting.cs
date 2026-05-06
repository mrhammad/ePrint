using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ExportSettings
{
	public class ExportSetting
	{
		public ExportSetting()
		{
		}

		public void BindPaymentMethod(DropDownList ddl, int companyID)
		{
			DbExportSetting dbExportSetting = new DbExportSetting();
			DataTable item = dbExportSetting.PC_PaymentExportSetting_PaymentMethod_Bind(companyID).Tables[0];
			ddl.DataSource = item;
			ddl.DataTextField = "Accounting Type";
			ddl.DataValueField = "Accounting Method ID";
			ddl.DataBind();
			ddl.Items.Insert(0, "");
			ddl.Items[0].Text = "---Select---";
			ddl.Items[0].Value = "0";
		}

		public void BindPaymentModule(DropDownList ddl2)
		{
			DbExportSetting dbExportSetting = new DbExportSetting();
			ddl2.DataSource = dbExportSetting.PC_PaymentExportSetting_PaymentModule_Bind().Tables[0];
			ddl2.DataTextField = "Type";
			ddl2.DataValueField = "Accounting Type ID";
			ddl2.DataBind();
			ddl2.Items.Insert(0, "");
			ddl2.Items[0].Text = "---Select---";
			ddl2.Items[0].Value = "0";
		}

		public void contact_xeroerror_update(int CompanyID, long ContactID, bool XeroErrorCode, string XeroErrorDesc)
		{
			(new DbExportSetting()).contact_xeroerror_update(CompanyID, ContactID, XeroErrorCode, XeroErrorDesc);
		}

		public void invoice_xeroerror_update(int CompanyID, long EstimateID, bool XeroErrorCode, string XeroErrorDesc)
		{
			(new DbExportSetting()).invoice_xeroerror_update(CompanyID, EstimateID, XeroErrorCode, XeroErrorDesc);
		}

		public void purchase_xeroerror_update(int CompanyID, long PurchaseID, bool XeroErrorCode, string XeroErrorDesc)
		{
			(new DbExportSetting()).purchase_xeroerror_update(CompanyID, PurchaseID, XeroErrorCode, XeroErrorDesc);
		}

		public void Setting_Export_ResetOldData(int CompanyID, string ExportViewName)
		{
			(new DbExportSetting()).Setting_Export_ResetOldData(CompanyID, ExportViewName);
		}

		public DataTable setting_getpaymentmoduleforexport(int paymentmethodid, string modulename)
		{
			return (new DbExportSetting()).setting_getpaymentmoduleforexport(paymentmethodid, modulename);
		}

		public DataTable settings_Accounting_export_contact(int CompanyID, int IsExported, string CompanyType)
		{
			return (new DbExportSetting()).settings_Accounting_export_contact(CompanyID, IsExported, CompanyType);
		}

		public DataTable settings_Accounting_export_Contact_Type_Xero(int CompanyID, int IsExported)
		{
			return (new DbExportSetting()).settings_Accounting_export_Contact_Type_Xero(CompanyID, IsExported);
		}

		public DataTable settings_Accounting_export_invoice(int CompanyID, string ExportSettingType, int IsExported)
		{
			return (new DbExportSetting()).settings_Accounting_export_invoice(CompanyID, ExportSettingType, IsExported);
		}

		public DataTable settings_Accounting_export_Purchase(int CompanyID, string ExportSettingType, int IsExported)
		{
			return (new DbExportSetting()).settings_Accounting_export_Purchase(CompanyID, ExportSettingType, IsExported);
		}

		public DataTable settings_Accounting_export_Purchase_Type_Xero(int CompanyID, string ExportSettingType, int IsExported)
		{
			return (new DbExportSetting()).settings_Accounting_export_Purchase_Type_Xero(CompanyID, ExportSettingType, IsExported);
		}

		public int settings_exportsetting_check(int CompanyID, int ExportType)
		{
			return (new DbExportSetting()).settings_exportsetting_check(CompanyID, ExportType);
		}

		public DataTable settings_PaymentExportSetting_PaymentMethod_FieldValue_select(int ddlvalue)
		{
			return (new DbExportSetting()).settings_PaymentExportSetting_PaymentMethod_FieldValue_select(ddlvalue);
		}
	}
}