using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

public class DbTemplates
{
	public DbTemplates()
	{
	}

	public virtual DataTable estimate_itemid_select(int CompanyID, long EstimateID, long EstimateItemID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_itemid_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItem_ID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable PCR_Template_GetAllDetails_By_EstimateItemID(long CurrentEstimateItemID, string CurrentEstimateType, long ParentItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Template_GetAllDetails_By_EstimateItemID");
		database.AddInParameter(storedProcCommand, "@CurrentEstimateItemID", DbType.Int64, CurrentEstimateItemID);
		database.AddInParameter(storedProcCommand, "@CurrentEstimateType", DbType.String, CurrentEstimateType);
		database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.String, ParentItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable PCR_Template_subitems_select(long ParentItemID, string PageType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Template_subitems_select");
		database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Select_EmailTemplateName(int UserID, int CompanyID, string TemplateType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_DefaultEmailBody_select");
		database.AddInParameter(storedProcCommand, "@userId", DbType.Int32, UserID);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_default_template_field_properties_select(int CompanyID, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_template_field_properties_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_ContactInfo(int CompanyID, int ContactID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_ContactInfo");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_field_category_selectall(int CompanyID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_template_field_category_selectall");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_field_properties_select(int CompanyID, long TemplateID, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_field_properties_select");
		storedProcCommand.CommandTimeout = 200;
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_fields_oncategory_select(int CompanyID, int CategoryID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_template_fields_oncategory_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_FieldValue_select(int CompanyID, int EstimateID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_Allfields_value_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_FieldValue_select(int CompanyID, long ID, string ModuleName, string templateId = "")
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_General_Values_Select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, ModuleName);
		database.AddInParameter(storedProcCommand, "@templateId", DbType.String, templateId);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}
	public virtual DataSet settings_template_CustomeFieldValue_select(int companyID, long estimateID, string ModuleType)
	{
		DataSet dataSet = new DataSet();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetCustomFields");

		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, estimateID);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
		database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataSet.Load(dataReader,LoadOption.OverwriteChanges,new string[] { "DepartmentFields", "ContactFields" });
		}
		return dataSet;
	}

	public virtual DataTable settings_template_FieldValue_select_Invoice(int CompanyID, long InvoiceID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_template_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_font_select(int CompanyID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Fonts_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataSet settings_template_GetTemplateData(int CompanyID, long TemplateID, long EstimateID, string PageType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_GetTemplateData_New");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		return database.ExecuteDataSet(storedProcCommand);
	}

	public virtual DataSet settings_template_GetTemplateData_New_tbl(int CompanyID, long TemplateID, long EstimateID, string PageType, string EstimateItemID, long JobID, long InvoiceID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_GetTemplateData_New_tbl");
        storedProcCommand.CommandTimeout = Int32.MaxValue;
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@JobId", DbType.Int64, JobID);
		database.AddInParameter(storedProcCommand, "@InvoiceId", DbType.Int64, InvoiceID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.String, EstimateItemID);
		return database.ExecuteDataSet(storedProcCommand);
	}

	public virtual DataTable settings_template_pdf_select(int CompanyID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_pdf_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_pdf_select_ByID(int CompanyID, long PDFID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_pdf_select_ByID");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int64, PDFID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_template_pdf_select_readyonly(int CompanyID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_pdf_select_readyonly");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public DataTable settings_titlecode_fortemplate_select_for_printbrocker(int CompanyID, long ModuleID, string ModuleName, int SupplierID, int SupplierContactID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_titlecode_fortemplate_select_for_printbrocker]");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		database.AddInParameter(storedProcCommand, "@SupplierContactID", DbType.Int64, SupplierContactID);
		database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, SupplierID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public DataTable settings_titlecode_fortemplate_select_for_printbrocker_New(int CompanyID, long ModuleID, string ModuleName, int SupplierID, int SupplierContactID, long EstimateItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_titlecode_fortemplate_select_for_printbrocker_New");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, SupplierID);
		database.AddInParameter(storedProcCommand, "@SupplierContactID", DbType.Int64, SupplierContactID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable settings_zeroth_template_select(int CompanyID, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_zeroth_template_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual int Template_Group_Add(int TemplateID, string GroupName, bool IsAuto)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_Group_Add");
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
		database.AddInParameter(storedProcCommand, "@IsAuto", DbType.String, IsAuto);
		database.ExecuteScalar(storedProcCommand);
		return 0;
	}

	public virtual void Template_Group_Delete(int GroupID, int TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_Group_Delete");
		database.AddInParameter(storedProcCommand, "@GroupID", DbType.String, GroupID);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual DataSet Template_Group_View(int TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_Group_View");
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		return database.ExecuteDataSet(storedProcCommand);
	}

	public virtual int Template_HGroup_Add(int TemplateID, string GroupName, bool IsDeleteAllIfMainIsBlank)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_HGroup_Add");
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
		database.AddInParameter(storedProcCommand, "@IsDeleteAllIfMainIsBlank", DbType.Boolean, IsDeleteAllIfMainIsBlank);
		database.ExecuteScalar(storedProcCommand);
		return 0;
	}

	public virtual void Template_HGroup_Delete(int GroupID, int TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_HGroup_Delete");
		database.AddInParameter(storedProcCommand, "@GroupID", DbType.String, GroupID);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual DataSet Template_HGroup_View(int TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_HGroup_View");
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
		return database.ExecuteDataSet(storedProcCommand);
	}

	public virtual DataTable templates_company_additional_address_select(int CompanyID, int AddressID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_company_additional_address_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, AddressID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_company_address_select(int CompanyID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_company_address_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_GetDelivryItemTotalExTax_select(int CompanyID, string itemid)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_GetDelivryItemTotalExTax_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@itemids", DbType.String, itemid);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

    public virtual DataTable templates_company_client_address_select(int CompanyID, int ClientID)
    {
        DataTable dataTable = new DataTable();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_company_client_address_select");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
        database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public virtual DataTable templates_company_contact_address_select(int CompanyID, int ContactID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_company_contact_address_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_delivery_notes_Allfields_value_select(int CompanyID, int DeliveryID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_notes_Allfields_value_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int32, DeliveryID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual int templates_items_count_select(int CompanyID, long ID, string PageType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_items_count_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		return (int)database.ExecuteScalar(storedProcCommand);
	}

	public virtual long templates_orderitemID_select(long OrderID, long EstimateItemID, long ModuleID, string ModuleName)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_orderitemID_select");
		database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
		database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
		object obj = database.ExecuteScalar(storedProcCommand);
		return (obj == null ? (long)0 : long.Parse(obj.ToString()));
	}

	public virtual DataTable templates_purchase_Allfields_value_select(int CompanyID, int PurchaseID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_purchase_Allfields_value_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int32, PurchaseID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_quantity_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_quantity_details_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_quantity_details_select_new(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_quantity_details_select_reEng");
        storedProcCommand.CommandTimeout = Int32.MaxValue;
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable templates_quantity_details_select_LocationGrouping(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_quantity_details_select_LocationGrouping");
		storedProcCommand.CommandTimeout = Int32.MaxValue;
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public DataTable templates_total_price_details_select(int CompanyID, long EstimateID, string PageType, string SelectedItems, long TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_total_price_details_select_reEng");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		database.AddInParameter(storedProcCommand, "@EstimateItemNewID", DbType.String, SelectedItems);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public DataTable templates_total_price_details_select_AllItem(int CompanyID, long EstimateID, string PageType, string SelectedItems, long TemplateID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_total_price_details_select_reEng_AllItems");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
		database.AddInParameter(storedProcCommand, "@EstimateItemNewID", DbType.String, SelectedItems);
		database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public DataTable templates_warehouse_details_select(int CompanyID, long EstimateItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templates_warehouse_details_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

    public DataTable get_latest_customer_email(long jobID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_latest_customer_email");
        database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, jobID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }
}