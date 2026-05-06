using nmsCommon;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Template
{
	public Template()
	{
	}

	public void Bind_TemplateFieldCategory(DropDownList ddl, int sqlParameter1, string defaultValue)
	{
		ddl.DataSource = this.settings_template_field_category_selectall(sqlParameter1);
		ddl.DataTextField = "CategoryName";
		ddl.DataValueField = "CategoryID";
		ddl.DataBind();
		ddl.Items.Insert(0, " ");
		ddl.Items[0].Text = defaultValue;
		ddl.Items[0].Value = "0";
	}

	public void Bind_TemplateFonts(DropDownList ddl, int sqlParameter1, string defaultValue)
	{
		ddl.DataSource = this.settings_template_font_select(sqlParameter1);
		ddl.DataTextField = "Name";
		ddl.DataValueField = "Value";
		ddl.DataBind();
		for (int i = 0; i < ddl.Items.Count; i++)
		{
			ddl.Items[i].Attributes.Add("style", string.Concat("font-family: ", ddl.Items[i].Text, "; font-size: 14px;"));
		}
	}

	public void Bind_TemplatePDF(DropDownList ddl, int sqlParameter1, string defaultValue)
	{
		ddl.DataSource = this.settings_template_pdf_select_readyonly(sqlParameter1);
		ddl.DataTextField = "PDFTitle";
		ddl.DataValueField = "PDFID";
		ddl.DataBind();
		ddl.Items.Insert(0, " ");
		ddl.Items[0].Text = defaultValue;
		ddl.Items[0].Value = "0";
	}

	public DataTable estimate_itemid_select(int CompanyID, long EstimateID, long EstimateItemID)
	{
		return (new DbTemplates()).estimate_itemid_select(CompanyID, EstimateID, EstimateItemID);
	}

	public DataTable PCR_Template_GetAllDetails_By_EstimateItemID(long CurrentEstimateItemID, string CurrentEstimateType, long ParentItemID)
	{
		return (new DbTemplates()).PCR_Template_GetAllDetails_By_EstimateItemID(CurrentEstimateItemID, CurrentEstimateType, ParentItemID);
	}

	public DataTable PCR_Template_subitems_select(long ParentItemID, string PageType)
	{
		return (new DbTemplates()).PCR_Template_subitems_select(ParentItemID, PageType);
	}

	public string ReplaceAllTags_Outlook(DataTable dt, string TemplateKey, string ModuleName, string EmailBody, string supcnt)
	{
		commonClass _commonClass = new commonClass();
		BaseClass baseClass = new BaseClass();
		string[] strArrays = null;
		string[] strArrays1 = null;
		StringBuilder stringBuilder = new StringBuilder();
		string emailBody = EmailBody;
		int num = Convert.ToInt32(HttpContext.Current.Session["companyID"]);
		int num1 = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		string str = string.Concat(HttpContext.Current.Session["firstName"].ToString(), " ", HttpContext.Current.Session["lastName"].ToString());
		if (ModuleName.ToLower() != "printbroker")
		{
			string str1 = string.Concat(baseClass.strSitepath, "pdf.aspx?key=", TemplateKey);
			if (dt.Rows.Count > 0)
			{
				DataRow item = dt.Rows[0];
				if (emailBody.Contains("[$AttachmentsPath$]"))
				{
					if (item["FileName"].ToString() != "")
					{
						strArrays = item["FileName"].ToString().Split(new char[] { ',' });
					}
					if (item["OriginalFileName"].ToString() != "")
					{
						strArrays1 = item["OriginalFileName"].ToString().Split(new char[] { ',' });
					}
					if (strArrays != null && strArrays1 != null)
					{
						for (int i = 0; i < (int)strArrays.Length; i++)
						{
							if (stringBuilder.Length != 0)
							{
								string[] strArrays2 = new string[] { "<a href=", global.sitePath(), "DocManager.ashx?doctype=attachments&filename=", strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
								stringBuilder.Append(string.Concat(strArrays2));
							}
							else
							{
								string[] strArrays3 = new string[] { "<br /><a href=", global.sitePath(), "DocManager.ashx?doctype=attachments&filename=", strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
								stringBuilder.Append(string.Concat(strArrays3));
							}
						}
					}
					emailBody = (stringBuilder.Length != 0 ? emailBody.Replace("[$AttachmentsPath$]", stringBuilder.ToString()) : emailBody.Replace("[$AttachmentsPath$]", ""));
				}
				string[] strArrays4 = new string[] { "<a href='", str1, "'>", str1, "</a>&nbsp;" };
				emailBody = emailBody.Replace("[$PDFPath$]", string.Concat(strArrays4));
				emailBody = emailBody.Replace("[$EmailFooter$]", str);
				if (ModuleName.Trim().ToLower() == "estimate")
				{
					emailBody = emailBody.Replace("[$EstimateTitle$]", item["EstimateTitle"].ToString());
					emailBody = emailBody.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
					emailBody = emailBody.Replace("[$CustomerName$]", item["CustomerName"].ToString());
					emailBody = emailBody.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item["EstimateDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedArtwork"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedDelivery"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$ValidFor$]", item["ValidFor"].ToString());
					emailBody = emailBody.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
					emailBody = emailBody.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
					emailBody = emailBody.Replace("[$EstimateHeader$]", item["EstimateHeader"].ToString());
					emailBody = emailBody.Replace("[$EstimateFooter$]", item["EstimateFooter"].ToString());
					emailBody = emailBody.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["EstimateValue"].ToString()), 0, "", false, false, true));
				}
				else if (ModuleName.Trim().ToLower() == "job" || ModuleName.Trim().ToLower() == "jobcard")
				{
					emailBody = emailBody.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
					emailBody = emailBody.Replace("[$JobNumber$]", item["JobNumber"].ToString());
					emailBody = emailBody.Replace("[$JobTitle$]", item["JobTitle"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
					emailBody = emailBody.Replace("[$CustomerName$]", item["CustomerName"].ToString());
					emailBody = emailBody.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["JobDelivery"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
					emailBody = emailBody.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
					emailBody = emailBody.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
					emailBody = emailBody.Replace("[$JobHeader$]", item["JobHeader"].ToString());
					emailBody = emailBody.Replace("[$JobFooter$]", item["JobFooter"].ToString());
					emailBody = emailBody.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
				}
				else if (ModuleName.Trim().ToLower() == "invoice")
				{
					emailBody = emailBody.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
					emailBody = emailBody.Replace("[$JobNumber$]", item["JobNumber"].ToString());
					emailBody = emailBody.Replace("[$InvoiceNumber$]", item["InvoiceNumber"].ToString());
					emailBody = emailBody.Replace("[$InvoiceTitle$]", item["InvoiceTitle"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
					emailBody = emailBody.Replace("[$CustomerName$]", item["CustomerName"].ToString());
					emailBody = emailBody.Replace("[$InvoiceDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$InvoiceOrderNumber$]", item["InvoiceOrderNumber"].ToString());
					emailBody = emailBody.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
					emailBody = emailBody.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
					emailBody = emailBody.Replace("[$InvoiceHeader$]", item["InvoiceHeader"].ToString());
					emailBody = emailBody.Replace("[$InvoiceFooter$]", item["InvoiceFooter"].ToString());
					emailBody = emailBody.Replace("[$InvoiceValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["InvoiceValue"].ToString()), 0, "", false, false, true));
					emailBody = emailBody.Replace("[$InvoiceDueDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDueDate"].ToString(), num, 0, false));
				}
				else if (ModuleName.Trim().ToLower() == "purchase")
				{
					emailBody = emailBody.Replace("[$PONumber$]", item["PONumber"].ToString());
					emailBody = emailBody.Replace("[$RefNo$]", item["ReferenceNo"].ToString());
					emailBody = emailBody.Replace("[$SupplierName$]", item["SupplierName"].ToString());
					emailBody = emailBody.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
					emailBody = emailBody.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
					emailBody = emailBody.Replace("[$SupplierContactEmail$]", item["SupplierContactEmail"].ToString());
					emailBody = emailBody.Replace("[$PurchaseHeader$]", item["PurchaseHeader"].ToString());
					emailBody = emailBody.Replace("[$PurchaseFooter$]", item["PurchaseFooter"].ToString());
					emailBody = emailBody.Replace("[$RequiredDate$]", _commonClass.Eprint_return_Date_Before_View(item["RequiredDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$RaisedBy$]", item["RaisedBy"].ToString());
					emailBody = emailBody.Replace("[$PriceIncTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["PriceIncTax"].ToString()), 0, "", false, false, true));
					emailBody = emailBody.Replace("[$PriceExTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["PriceExTax"].ToString()), 0, "", false, false, true));
					emailBody = emailBody.Replace("[$Quantity$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["Quantity"].ToString()), 0, "", true, false, true));
					emailBody = emailBody.Replace("[$POComments$]", item["POComments"].ToString());
					emailBody = emailBody.Replace("[$SupplierQuoteNumber$]", item["SupplierQuoteNumber"].ToString());
					emailBody = emailBody.Replace("[$JobOrderTitle$]", item["JobOrderTitle"].ToString());
				}
				else if (ModuleName.Trim().ToLower() == "note")
				{
					emailBody = emailBody.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
					emailBody = emailBody.Replace("[$CustomerName$]", item["CustomerName"].ToString());
					emailBody = emailBody.Replace("[$DeliveryHeader$]", item["DeliveryHeader"].ToString());
					emailBody = emailBody.Replace("[$DeliveryFooter$]", item["DeliveryFooter"].ToString());
					emailBody = emailBody.Replace("[$DeliveryNumber$]", item["DeliveryNumber"].ToString());
					emailBody = emailBody.Replace("[$RefNo$]", item["RefNo"].ToString());
					emailBody = emailBody.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
					emailBody = emailBody.Replace("[$CarrierName$]", item["CarrierName"].ToString());
					emailBody = emailBody.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$ShippedTo$]", item["ShippedTo"].ToString());
				}
				else if (ModuleName.Trim().ToLower() == "webstoreorder")
				{
					emailBody = emailBody.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
					emailBody = emailBody.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
					emailBody = emailBody.Replace("[$CustomerName$]", item["CustomerName"].ToString());
					emailBody = emailBody.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
					emailBody = emailBody.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$OrderDate$]", _commonClass.Eprint_return_Date_Before_View(item["OrderedDate"].ToString(), num, 0, false));
					emailBody = emailBody.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
					emailBody = emailBody.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
					emailBody = emailBody.Replace("[$OrderValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(item["OrderValue"]), 0, "", false, false, true));
				}
			}
		}
		else
		{
			DataRow dataRow = dt.Rows[0];
			if (emailBody.Contains("[$AttachmentsPath$]"))
			{
				if (dataRow["FileName"].ToString() != "")
				{
					strArrays = dataRow["FileName"].ToString().Split(new char[] { ',' });
				}
				if (dataRow["OriginalFileName"].ToString() != "")
				{
					strArrays1 = dataRow["OriginalFileName"].ToString().Split(new char[] { ',' });
				}
				if (strArrays != null && strArrays1 != null)
				{
					for (int j = 0; j < (int)strArrays.Length; j++)
					{
						if (stringBuilder.Length != 0)
						{
							string[] strArrays5 = new string[] { "<a href=", global.sitePath(), "DocManager.ashx?doctype=attachments&filename=", strArrays[j], " target='_blank'>", strArrays1[j], "</a><br />" };
							stringBuilder.Append(string.Concat(strArrays5));
						}
						else
						{
							string[] strArrays6 = new string[] { "<br /><a href=", global.sitePath(), "DocManager.ashx?doctype=attachments&filename=", strArrays[j], " target='_blank'>", strArrays1[j], "</a><br />" };
							stringBuilder.Append(string.Concat(strArrays6));
						}
					}
				}
				emailBody = (stringBuilder.Length != 0 ? emailBody.Replace("[$AttachmentsPath$]", stringBuilder.ToString()) : emailBody.Replace("[$AttachmentsPath$]", ""));
			}
			string[] strArrays7 = new string[] { baseClass.strSitepath, "pdf.aspx?key=", supcnt, "_", TemplateKey };
			string str2 = string.Concat(strArrays7);
			string[] strArrays8 = new string[] { "<a href=", str2, ">", str2, "</a>&nbsp;" };
			emailBody = emailBody.Replace("[$PDFPath$]", string.Concat(strArrays8));
			emailBody = emailBody.Replace("[$EmailFooter$]", str);
			emailBody = emailBody.Replace("[$EstimateTitle$]", dataRow["EstimateTitle"].ToString());
			emailBody = emailBody.Replace("[$EstimateNumber$]", dataRow["EstimateNumber"].ToString());
			emailBody = emailBody.Replace("[$SupplierContactFirstName$]", dataRow["SupplierContactFirstName"].ToString());
			emailBody = emailBody.Replace("[$SupplierContactLastName$]", dataRow["SupplierContactLastName"].ToString());
			emailBody = emailBody.Replace("[$SupplierContactFullName$]", dataRow["SupplierContactFullName"].ToString());
			emailBody = emailBody.Replace("[$SupplierContactEmail$]", dataRow["SupplierContactEmail"].ToString());
			emailBody = emailBody.Replace("[$SupplierName$]", dataRow["SupplierName"].ToString());
			emailBody = emailBody.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(dataRow["EstimateDate"].ToString(), num, 0, false));
			emailBody = emailBody.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(dataRow["EstimatedArtwork"].ToString(), num, 0, false));
			emailBody = emailBody.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(dataRow["EstimatedDelivery"].ToString(), num, 0, false));
			emailBody = emailBody.Replace("[$ValidFor$]", dataRow["ValidFor"].ToString());
			emailBody = emailBody.Replace("[$SalesPerson$]", dataRow["SalesPerson"].ToString());
			emailBody = emailBody.Replace("[$SalesPersonEmail$]", dataRow["SalesPersonEmail"].ToString());
			emailBody = emailBody.Replace("[$EstimateHeader$]", dataRow["EstimateHeader"].ToString());
			emailBody = emailBody.Replace("[$EstimateFooter$]", dataRow["EstimateFooter"].ToString());
			emailBody = emailBody.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(dataRow["EstimateValue"]), 0, "", false, false, true));
		}
		return emailBody;
	}

	public DataTable Select_EmailTemplateName(int UserID, int CompanyID, string TemplateType)
	{
		return (new DbTemplates()).Select_EmailTemplateName(UserID, CompanyID, TemplateType);
	}

	public DataTable settings_default_template_field_properties_select(int CompanyID, string PageType)
	{
		return (new DbTemplates()).settings_default_template_field_properties_select(CompanyID, PageType);
	}

	public DataTable settings_template_ContactInfo(int CompanyID, int ContactID)
	{
		return (new DbTemplates()).settings_template_ContactInfo(CompanyID, ContactID);
	}

	public DataTable settings_template_field_category_selectall(int CompanyID)
	{
		return (new DbTemplates()).settings_template_field_category_selectall(CompanyID);
	}

	public DataTable settings_template_field_properties_select(int CompanyID, long TemplateID, string PageType)
	{
		return (new DbTemplates()).settings_template_field_properties_select(CompanyID, TemplateID, PageType);
	}

	public DataTable settings_template_fields_oncategory_select(int CompanyID, int CategoryID)
	{
		return (new DbTemplates()).settings_template_fields_oncategory_select(CompanyID, CategoryID);
	}

	public DataTable settings_template_FieldValue_select(int CompanyID, int EstimateID)
	{
		return (new DbTemplates()).settings_template_FieldValue_select(CompanyID, EstimateID);
	}

	public DataTable settings_template_FieldValue_select(int CompanyID, long ID, string ModuleName, string templateId = "")
	{
		return (new DbTemplates()).settings_template_FieldValue_select(CompanyID, ID, ModuleName, templateId);
	}
	public DataSet settings_template_CustomeFieldValue_select(int CompanyID, long EstimateID,string ModuleType)
	{
		return (new DbTemplates()).settings_template_CustomeFieldValue_select(CompanyID, EstimateID,ModuleType);
	}

	public DataTable settings_template_FieldValue_select_Invoice(int CompanyID, long InvoiceID)
	{
		return (new DbTemplates()).settings_template_FieldValue_select_Invoice(CompanyID, InvoiceID);
	}

	public DataTable settings_template_font_select(int CompanyID)
	{
		return (new DbTemplates()).settings_template_font_select(CompanyID);
	}

	public DataSet settings_template_GetTemplateData(int CompanyID, long TemplateID, long EstimateID, string PageType)
	{
		return (new DbTemplates()).settings_template_GetTemplateData(CompanyID, TemplateID, EstimateID, PageType);
	}

	public DataSet settings_template_GetTemplateData_New_tbl(int CompanyID, long TemplateID, long EstimateID, string PageType, string EstimateItemID, long JobID, long InvoiceID)
	{
		DbTemplates dbTemplate = new DbTemplates();
		return dbTemplate.settings_template_GetTemplateData_New_tbl(CompanyID, TemplateID, EstimateID, PageType, EstimateItemID, JobID, InvoiceID);
	}

	public DataTable settings_template_pdf_select(int CompanyID)
	{
		return (new DbTemplates()).settings_template_pdf_select(CompanyID);
	}

	public DataTable settings_template_pdf_select_ByID(int CompanyID, long PDFID)
	{
		return (new DbTemplates()).settings_template_pdf_select_ByID(CompanyID, PDFID);
	}

	public DataTable settings_template_pdf_select_readyonly(int CompanyID)
	{
		return (new DbTemplates()).settings_template_pdf_select_readyonly(CompanyID);
	}

	public DataTable settings_titlecode_fortemplate_select_for_printbrocker(int CompanyID, long ModuleID, string ModuleName, int SupplierID, int SupplierContactID)
	{
		return (new DbTemplates()).settings_titlecode_fortemplate_select_for_printbrocker(CompanyID, ModuleID, ModuleName, SupplierID, SupplierContactID);
	}

	public DataTable settings_titlecode_fortemplate_select_for_printbrocker_New(int CompanyID, long ModuleID, string ModuleName, int SupplierID, int SupplierContactID, long EstimateItemID)
	{
		DbTemplates dbTemplate = new DbTemplates();
		return dbTemplate.settings_titlecode_fortemplate_select_for_printbrocker_New(CompanyID, ModuleID, ModuleName, SupplierID, SupplierContactID, EstimateItemID);
	}

	public DataTable settings_zeroth_template_select(int CompanyID, string PageType)
	{
		return (new DbTemplates()).settings_zeroth_template_select(CompanyID, PageType);
	}

	public int Template_Group_Add(int TemplateID, string GroupName, bool IsAuto)
	{
		return (new DbTemplates()).Template_Group_Add(TemplateID, GroupName, IsAuto);
	}

	public void Template_Group_Delete(int GroupID, int TemplateID)
	{
		(new DbTemplates()).Template_Group_Delete(GroupID, TemplateID);
	}

	public DataSet Template_Group_View(int TemplateID)
	{
		return (new DbTemplates()).Template_Group_View(TemplateID);
	}

	public int Template_HGroup_Add(int TemplateID, string GroupName, bool IsDeleteAllIfMainIsBlank)
	{
		return (new DbTemplates()).Template_HGroup_Add(TemplateID, GroupName, IsDeleteAllIfMainIsBlank);
	}

	public void Template_HGroup_Delete(int GroupID, int TemplateID)
	{
		(new DbTemplates()).Template_HGroup_Delete(GroupID, TemplateID);
	}

	public DataSet Template_HGroup_View(int TemplateID)
	{
		return (new DbTemplates()).Template_HGroup_View(TemplateID);
	}

	public DataTable templates_company_additional_address_select(int CompanyID, int AddressID)
	{
		return (new DbTemplates()).templates_company_additional_address_select(CompanyID, AddressID);
	}

	public DataTable templates_company_address_select(int CompanyID)
	{
		return (new DbTemplates()).templates_company_address_select(CompanyID);
	}

	public DataTable templates_company_client_address_select(int CompanyID, int ClientID)
	{
		return (new DbTemplates()).templates_company_client_address_select(CompanyID, ClientID);
	}
    public DataTable templates_GetDelivryItemTotalExTax_select(int CompanyID, string itemid)
    {
        return (new DbTemplates()).templates_GetDelivryItemTotalExTax_select(CompanyID, itemid);
    }

    public DataTable templates_company_contact_address_select(int CompanyID, int ContactID)
	{
		return (new DbTemplates()).templates_company_contact_address_select(CompanyID, ContactID);
	}

	public DataTable templates_delivery_notes_Allfields_value_select(int CompanyID, int DeliveryID)
	{
		return (new DbTemplates()).templates_delivery_notes_Allfields_value_select(CompanyID, DeliveryID);
	}

	public int templates_items_count_select(int CompanyID, long ID, string PageType)
	{
		return (new DbTemplates()).templates_items_count_select(CompanyID, ID, PageType);
	}

	public long templates_orderitemID_select(long OrderID, long EstimateItemID, long ModuleID, string ModuleName)
	{
		return (new DbTemplates()).templates_orderitemID_select(OrderID, EstimateItemID, ModuleID, ModuleName);
	}

	public DataTable templates_purchase_Allfields_value_select(int CompanyID, int PurchaseID)
	{
		return (new DbTemplates()).templates_purchase_Allfields_value_select(CompanyID, PurchaseID);
	}

	public DataTable templates_quantity_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		return (new DbTemplates()).templates_quantity_details_select(CompanyID, EstimateID, EstimateItemID, EstimateType, PageType);
	}

	public DataTable templates_quantity_details_select_new(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		return (new DbTemplates()).templates_quantity_details_select_new(CompanyID, EstimateID, EstimateItemID, EstimateType, PageType);
	}

	public DataTable templates_quantity_details_select_LocationGrouping(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
	{
		return (new DbTemplates()).templates_quantity_details_select_LocationGrouping(CompanyID, EstimateID, EstimateItemID, EstimateType, PageType);
	}

	public DataTable templates_total_price_details_select(int CompanyID, long EstimateID, string PageType, string SelectedItems, long TemplateID)
	{
		return (new DbTemplates()).templates_total_price_details_select(CompanyID, EstimateID, PageType, SelectedItems, TemplateID);
	}

	public DataTable templates_total_price_details_select_AllItem(int CompanyID, long EstimateID, string PageType, string SelectedItems, long TemplateID)
	{
		return (new DbTemplates()).templates_total_price_details_select_AllItem(CompanyID, EstimateID, PageType, SelectedItems, TemplateID);
	}

	public DataTable templates_warehouse_details_select(int CompanyID, long EstimateItemID)
	{
		return (new DbTemplates()).templates_warehouse_details_select(CompanyID, EstimateItemID);
	}

    public DataTable get_latest_customer_email(long jobID)
    {
        return (new DbTemplates()).get_latest_customer_email(jobID);
    }
}