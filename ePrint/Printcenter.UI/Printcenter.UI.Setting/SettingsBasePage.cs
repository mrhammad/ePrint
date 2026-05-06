using ePrint.settings;
using ePrint.StoreSettings;
using nmsCommon;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.DataAccessLayer.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.Setting
{
    public class SettingsBasePage : BasePage
    {
        public static BaseClass objBase;

        static SettingsBasePage()
        {
            SettingsBasePage.objBase = new BaseClass();
        }

        public SettingsBasePage()
        {
        }

        public static DataTable ActivityCallReport_SelectColoumn()
        {
            return Settings.ActivityCallReport_SelectColoumn();
        }

        public static DataTable ActivityTaskEventReport_SelectColoumn()
        {
            return Settings.ActivityTaskEventReport_SelectColoumn();
        }

        public static DataTable AllowCSvEnable(long PriceCatalogueID, long CompanyID)
        {
            return Settings.AllowCSvEnable(PriceCatalogueID, CompanyID);
        }

        public static DataTable ArchiveStatus_Edit(long CompanyID)
        {
            return Settings.ArchiveStatus_Edit(CompanyID);
        }

        public static void ArchiveStatus_Update(long CompanyID, long ArchiveStatusId, string Module, string Event, long StatusID, int IsArchive)
        {
            Settings.ArchiveStatus_Update(CompanyID, ArchiveStatusId, Module, Event, StatusID, IsArchive);
        }

        public static DataTable AutoDeliveryAlert_EditSelectStatus(int CompanyID, int StatusID)
        {
            return Settings.AutoDeliveryAlert_EditSelectStatus(CompanyID, StatusID);
        }

        public static DataTable AutoDeliveryAlert_select(int CompanyID)
        {
            return Settings.AutoDeliveryAlert_select(CompanyID);
        }

        public static DataTable AutoDeliveryAlert_SelectStatus(int CompanyID)
        {
            return Settings.AutoDeliveryAlert_SelectStatus(CompanyID);
        }

        public static void autojobalert_delete(int CompanyID, int EmailID)
        {
            Settings.autojobalert_delete(CompanyID, EmailID);
        }

        public static DataTable AutojobAlert_EditSelectStatus(int CompanyID, int StatusID)
        {
            return Settings.AutojobAlert_EditSelectStatus(CompanyID, StatusID);
        }
        public static DataTable Auto_Module_Alert_EditSelectStatus(int CompanyID, int StatusID,string PageName)
        {
            return Settings.Auto_Module_Alert_EditSelectStatus(CompanyID, StatusID, PageName);
        }
        public static DataTable AutojobAlert_select(int CompanyID)
        {
            return Settings.AutojobAlert_select(CompanyID);
        }
        public static DataTable AutoAlertEmailByTemplate_select(int CompanyID,string TemplateType)
        {
            return Settings.AutoAlertEmailByTemplate_select(CompanyID,TemplateType);
        }
        public static DataTable AutojobAlert_SelectStatus(int CompanyID)
        {
            return Settings.AutojobAlert_SelectStatus(CompanyID);
        }
        public static DataTable SelectModuleStatus(int CompanyID,string PageName)
        {
            return Settings.SelectModuleStatus(CompanyID,PageName);
        }
        public void Bind_Account_Status(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = SettingsBasePage.settings_accountstatus_select(sqlParameter1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = SettingsBasePage.objBase.SpecialDecode(row["StatusTitle"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "StatusTitle";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_AccountingCodes(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = SettingsBasePage.Setting_accountingCode_SelectAll(sqlParameter1);
            ddl.DataSource = dataTable;
            ddl.DataTextField = "Code";
            ddl.DataValueField = "AccountCodeID";
            ddl.DataBind();
            ddl.Items.Insert(0, "");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
            int num = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["IsDefault"].ToString().ToLower() != "true")
                {
                    num++;
                }
                else
                {
                    ddl.Items[num].Selected = true;
                    break;
                }
            }
        }

        public static void Bind_AccountingCodes_New(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = SettingsBasePage.Setting_accountingCode_SelectAll(sqlParameter1);

            dataTable.Columns.Add("CodeAndDescription", typeof(string), "Code + ' ' + Description");

            ddl.DataSource = dataTable;
            ddl.DataTextField = "CodeAndDescription";
            ddl.DataValueField = "AccountCodeID";
            ddl.DataBind();
            ddl.Items.Insert(0, "");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
            int num = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (ddl.ID == "ddl_AccountingCode")
                {
                    if (row["IsDefault"].ToString().ToLower() != "true")
                    {
                        num++;
                    }
                    else
                    {
                        ddl.Items[num].Selected = true;
                        break;
                    }
                }
                else if (ddl.ID == "ddl_PurchaseAccountingCode")
                {
                    if (row["IsDefaultPurchase"].ToString().ToLower() != "true")
                    {
                        num++;
                    }
                    else
                    {
                        ddl.Items[num].Selected = true;
                        break;
                    }
                }
            }
        }

        public void Bind_CompanyType(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = SettingsBasePage.settings_CompanyType_select(sqlParameter1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["companytype"] = baseClass.SpecialDecode(row["companytype"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "companytype";
            ddl.DataValueField = "id";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_EmailTemplates(DropDownList ddl, int sqlParameter1, string defaultValue, string sectionname)
        {
            ddl.DataSource = SettingsBasePage.template_email_phrasebook_select(sqlParameter1, "Email Body", sectionname, "all");
            ddl.DataTextField = "EmailTemplateName";
            ddl.DataValueField = "PhraseBookID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_Language(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.settings_languages_select(sqlParameter1);
            ddl.DataTextField = "Languages";
            ddl.DataValueField = "LanguageID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_Markup(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = SettingsBasePage.settings_markup_selectall(sqlParameter1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["MarkupName"] = baseClass.SpecialDecode(row["MarkupName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "MarkupName";
            ddl.DataValueField = "MarkupID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_OtherCostCategory(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = SettingsBasePage.settings_othercostcategory_selectall(sqlParameter1);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["OtherCostCategoryName"] = baseClass.SpecialDecode(row["OtherCostCategoryName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "OtherCostCategoryName";
            ddl.DataValueField = "OtherCostCategoryID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_PaperSize(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = SettingsBasePage.settings_papersize_selectall(sqlParameter1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["PaperSizeName"] = baseClass.SpecialDecode(row["PaperSizeName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "PaperSizeName";
            ddl.DataValueField = "PaperSizeID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_PaymentMode(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.settings_PaymentValue_select((long)sqlParameter1);
            ddl.DataTextField = "PaymentModeValue";
            ddl.DataValueField = "PaymentModeID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_PaymentTermName(DropDownList ddl_Payment, int sqlParameter1, string defaultValue)
        {
            ddl_Payment.DataSource = SettingsBasePage.PaymentTerm_Details_Select((long)sqlParameter1);
            ddl_Payment.DataTextField = "Name";
            ddl_Payment.DataValueField = "PaymenttermID";
            ddl_Payment.DataBind();
            ddl_Payment.Items.Insert(0, " ");
            ddl_Payment.Items[0].Text = defaultValue;
            ddl_Payment.Items[0].Value = "0";
        }

        public static void Bind_PressNames(DropDownList ddl, int sqlParameter1)
        {
            ddl.DataSource = SettingsBasePage.settings_PressName_select(sqlParameter1);
            ddl.DataTextField = "DigitalPressName";
            ddl.DataValueField = "pressid";
            ddl.DataBind();
            ddl.Items.Insert(0, "--- Select ---");
            ddl.Items[0].Value = "0";
        }

        public void Bind_ReferencedBy(DropDownList ddl, string Name, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.ClientReferencedByName_Select(Name, sqlParameter1);
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ReferencedID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_ScreenName(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.ReturnScreenName_Select(sqlParameter1);
            ddl.DataTextField = "ScreenName";
            ddl.DataValueField = "DatabaseFieldName";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_Status(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.settings_estimatestatus_select(sqlParameter1);
            ddl.DataTextField = "StatusTitle";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();
            if (defaultValue != "no")
            {
                ddl.Items.Insert(0, " ");
                ddl.Items[0].Text = defaultValue;
                ddl.Items[0].Value = "0";
            }
        }

        public void Bind_Status_for_all_modules(DropDownList ddl, int sqlParameter1, string defaultValue, string cond)
        {
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select_new(sqlParameter1, cond);
            ddl.DataSource = dataTable;
            ddl.DataTextField = "StatusTitle";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();
            if (defaultValue != "no")
            {
                ddl.Items.Insert(0, " ");
                ddl.Items[0].Text = defaultValue;
                ddl.Items[0].Value = "0";
            }
            foreach (DataRow row in dataTable.Rows)
            {
                ddl.SelectedIndex = Convert.ToInt32(row["StatusID"]);
            }
        }

        public void Bind_Status_Listbox(ListBox lstbox, int sqlParameter1, string defaultValue, string cond)
        {
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(sqlParameter1, cond);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = SettingsBasePage.objBase.SpecialDecode(row["StatusTitle"].ToString());
            }
            lstbox.DataSource = dataTable;
            lstbox.DataTextField = "StatusTitle";
            lstbox.DataValueField = "StatusID";
            lstbox.DataBind();
            if (defaultValue != "no")
            {
                lstbox.Items.Insert(0, " ");
                lstbox.Items[0].Text = defaultValue;
                lstbox.Items[0].Value = "0";
            }
        }

        public void Bind_Status_new(DropDownList ddl, int sqlParameter1, string defaultValue, string cond)
        {
            ddl.DataSource = SettingsBasePage.settings_estimatestatus_moduletype_select(sqlParameter1, cond);
            ddl.DataTextField = "StatusTitle";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();
            if (defaultValue != "no")
            {
                ddl.Items.Insert(0, " ");
                ddl.Items[0].Text = defaultValue;
                ddl.Items[0].Value = "0";
            }
        }

        public void Bind_Subject(DropDownList ddl, int sqlParameter, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = SettingsBasePage.settings_subject_select(sqlParameter);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("sampleSubject"))
                    {
                        continue;
                    }
                    row["sampleSubject"] = baseClass.SpecialDecode(row["sampleSubject"].ToString());
                }
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "sampleSubject";
            ddl.DataValueField = "sampleSubjectId";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Bind_TaxRate(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = SettingsBasePage.settings_taxrate_select(sqlParameter1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["TaxName"] = SettingsBasePage.objBase.SpecialDecode(row["TaxName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "TaxName";
            ddl.DataValueField = "TaxID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_TemplateField(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            ddl.DataSource = SettingsBasePage.settings_template_field_category_selectall(sqlParameter1);
            ddl.DataTextField = "CategoryName";
            ddl.DataValueField = "CategoryID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public void Bind_User(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = SettingsBasePage.settings_user_select(sqlParameter1);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("Name"))
                    {
                        continue;
                    }
                    row.Table.Columns["Name"].ReadOnly = false;
                    row["Name"] = SettingsBasePage.objBase.SpecialDecode(row["Name"].ToString());
                }
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "UserID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "-1";
        }

        public static DataSet Bindddl_othercostSelectedCategory(int CompanyID)
        {
            return Settings.Bindddl_othercostSelectedCategory(CompanyID);
        }

        public static DataSet Bindddl_SelectedCategory(int CompanyID)
        {
            return Settings.Bindddl_SelectedCategory(CompanyID);
        }

        public static void CallPurpose_delete(long Id)
        {
            Settings.CallPurpose_delete(Id);
        }

        public static int CallPurpose_insert(int CompanyID, string statusTitle, bool IsDefault, int UserID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = CompanyID,
                StatusTitle = statusTitle,
                IsDefaultStatus = IsDefault,
                UserID = UserID
            };
            return Settings.CallPurpose_insert(settingsItem);
        }

        public static DataTable CallPurpose_select(long CompanyID)
        {
            return Settings.CallPurpose_select(CompanyID);
        }

        public static void CallPurpose_status_update(long CompanyID, long StatusID)
        {
            Settings.CallPurpose_status_update(CompanyID, StatusID);
        }

        public static void CallPurpose_update(SettingsItem items)
        {
            Settings.CallPurpose_update(items);
        }

        public static void CartImage_Insert_Update(long AccountID, string CartImage, string OriginalCartImageName)
        {
            Settings.CartImage_Insert_Update(AccountID, CartImage, OriginalCartImageName);
        }

        public string Category_Customer_Select(long companyid, long CustID)
        {
            return Settings.Category_Customer_Select(companyid, CustID);
        }

        public static DataTable Check_IsApprovalFeaturesOn(int CompanyID)
        {
            return Settings.Check_IsApprovalFeaturesOn(CompanyID);
        }

        public static void CheckInksWhileRerun(int CompanyID, long EstimateItemID, long EstimateLithoNCRItemId, long EstimateLithoBookletItemId, string sidenumber)
        {
            Settings.CheckInksWhileRerun(CompanyID, EstimateItemID, EstimateLithoNCRItemId, EstimateLithoBookletItemId, sidenumber);
        }

        public static bool CheckIsCampaignEnabled(long AccountID, long CompanyID)
        {
            return Settings.CheckIsCampaignEnabled(AccountID, CompanyID);
        }

        public static DataTable ClientReferencedByName_Select(string Name, int CompanyID)
        {
            return Settings.ClientReferencedByName_Select(Name, CompanyID);
        }

        public static void common_add_usertype_and_accessrights_new_Default(long CompanyID, long UserID, string usertype, string sectionname, int isview, int isadd, int isedit, int isdelete, int isdisplay, int isassignmentrights, string Others, string PrintorEmail, string ExportorImport, string IsRevert, string description)
        {
            Settings.common_add_usertype_and_accessrights_new_Default(CompanyID, UserID, usertype, sectionname, isview, isadd, isedit, isdelete, isdisplay, isassignmentrights, Others, PrintorEmail, ExportorImport, IsRevert, description);
        }

        public static void common_update_accessrights_New(long CompanyID, long usertypeid, string sectionname, int isview, int isadd, int isedit, int isdelete, int isdisplay, int isassignmentrights, string Others, string PrintorEmail, string ExportorImport, string IsRevert, string description)
        {
            Settings.common_update_accessrights_New(CompanyID, usertypeid, sectionname, isview, isadd, isedit, isdelete, isdisplay, isassignmentrights, Others, PrintorEmail, ExportorImport, IsRevert, description);
        }

        public static DataTable CRM_Customers_SelectForDashboard(long CompanyID, string widgetType)
        {
            return Settings.CRM_Customers_SelectForDashboard(CompanyID, widgetType);
        }

        public static DataSet CRM_Select_IsAdvance_Crm(int CompanyID, string HostName)
        {
            return Settings.CRM_Select_IsAdvance_Crm(CompanyID, HostName);
        }

        public static DataSet CRM_Select_Isstore_ForOrder(int CompanyID, string SystemName)
        {
            return Settings.CRM_Select_Isstore_ForOrder(CompanyID, SystemName);
        }

        public static DataTable CustomizeClient_Report(int CompanyID)
        {
            return Settings.CustomizeClient_Report(CompanyID);
        }

        public static DataTable CustomizeJob_Report(int CompanyID, string FromDate, string ToDate)
        {
            return Settings.CustomizeJob_Report(CompanyID, FromDate, ToDate);
        }

        public static DataTable CustomizeProduct_Report(int CompanyID, long ClientID)
        {
            return Settings.CustomizeProduct_Report(CompanyID, ClientID);
        }

        public static DataTable CustomStyles_Details(long AccountID)
        {
            return Settings.CustomStyles_Details(AccountID);
        }

        public static void CustomStyles_Insert_Update(string ClassName, long AccountID, string Color, string FontFamily, string FontSize, string BackgroundColor, string Height, string Border, string FontWeight, string BackgroundImage, string TextDecoration, string TextTranform)
        {
            Settings.CustomStyles_Insert_Update(ClassName, AccountID, Color, FontFamily, FontSize, BackgroundColor, Height, Border, FontWeight, BackgroundImage, TextDecoration, TextTranform);
        }

        public static DataTable DefaultSettings_ProductType_Select(long CompanyID, string Type)
        {
            return Settings.DefaultSettings_ProductType_Select(CompanyID, Type);
        }

        public static string DeleteImageCategory(long CategoryID, long UserID)
        {
            return Settings.DeleteImageCategory(CategoryID, UserID);
        }

        public static void DeleteMultipleImageCategory(long CompanyID, long UserID, string CategoryID)
        {
            Settings.DeleteMultipleImageCategory(CompanyID, UserID, CategoryID);
        }

        public static string DeleteMultipleImageCategory_Check(long CompanyID, long UserID, string CategoryIDs, string ImgIDs)
        {
            return Settings.DeleteMultipleImageCategory_Check(CompanyID, UserID, CategoryIDs, ImgIDs);
        }

        public static void DeleteMultipleImages(long CompanyID, long UserID, string ImgID)
        {
            Settings.DeleteMultipleImages(CompanyID, UserID, ImgID);
        }

        public static string DeleteRootImage(long ImageID, long UserID)
        {
            return Settings.DeleteRootImage(ImageID, UserID);
        }

        public static void DeleteSingleInUseCategory(string CategoryID, long UserID)
        {
            Settings.DeleteSingleInUseCategory(CategoryID, UserID);
        }

        public static void DeleteSingleInUseImage(string ImgID, long UserID)
        {
            Settings.DeleteSingleInUseImage(ImgID, UserID);
        }

        public static void DigitalPress_AccountingCode_Insert(long CompanyID, long DigitalPressID, int AccountCodeID)
        {
            Settings.DigitalPress_AccountingCode_Insert(CompanyID, DigitalPressID, AccountCodeID);
        }

        public static int DigitalPress_AccountingCode_Select(long CompanyID, long DigitalPressID)
        {
            return Settings.DigitalPress_AccountingCode_Select(CompanyID, DigitalPressID);
        }

        public static void DigitalPress_New_Copy(long DigitalPressID)
        {
            Settings.DigitalPress_New_Copy(DigitalPressID);
        }

        public static void Guillotine_New_Copy(long GuillotineID)
        {
            Settings.Guillotine_New_Copy(GuillotineID);
        }

        public static void LargeFormate_New_Copy(long PressID)
        {
            Settings.LargeFormate_New_Copy(PressID);
        }

        public static void lithopress_New_Copy(long LithoPressID)
        {
            Settings.lithopress_New_Copy(LithoPressID);
        }

        public static int DigitalPressMatrixCounter_Select(long CompanyID)
        {
            return Settings.DigitalPressMatrixCounter_Select(CompanyID);
        }

        public void DisableApprovalSystem(long AccountID)
        {
            (new Settings()).DisableApprovalSystem(AccountID);
        }

        public static void editabletemplate_colorstyle_delete(long ColorID)
        {
            Settings.editabletemplate_colorstyle_delete(ColorID);
        }

        public static void editabletemplate_colorstyle_insert(long TemplateID, long UserID, long CompanyID, string ColorStyle, string code_c, string code_m, string code_y, string code_k, decimal code_r, decimal code_g, decimal code_b, decimal code_a, decimal Tint, int IsSpotColor, string SpotColor)
        {
            Settings.editabletemplate_colorstyle_insert(TemplateID, UserID, CompanyID, ColorStyle, code_c, code_m, code_y, code_k, code_r, code_g, code_b, code_a, Tint, IsSpotColor, SpotColor);
        }

        public static DataTable editabletemplate_colorstyle_select(long CompanyID)
        {
            return Settings.editabletemplate_colorstyle_select(CompanyID);
        }

        public static void editabletemplate_colorstyle_update(long ColorID, long TemplateID, long UserID, long CompanyID, string ColorStyle, string code_c, string code_m, string code_y, string code_k, decimal code_r, decimal code_g, decimal code_b, decimal code_a, decimal Tint, int IsSpotColor, string SpotColor)
        {
            Settings.editabletemplate_colorstyle_update(ColorID, TemplateID, UserID, CompanyID, ColorStyle, code_c, code_m, code_y, code_k, code_r, code_g, code_b, code_a, Tint, IsSpotColor, SpotColor);
        }

        public static DataTable editabletemplate_fontfamily_select(long CompanyID)
        {
            return Settings.editabletemplate_fontfamily_select(CompanyID);
        }

        public static void editabletemplate_fontstyle_delete(long FontID)
        {
            Settings.editabletemplate_fontstyle_delete(FontID);
        }

        public static void editabletemplate_fontstyle_insert(long TemplateID, long UserID, long CompanyID, string FontStyle, decimal FontSize, string ManualTracking, string TextAlign, decimal Indent, string Capitalize, string DataType, string Format, string FontFamily)
        {
            Settings.editabletemplate_fontstyle_insert(TemplateID, UserID, CompanyID, FontStyle, FontSize, ManualTracking, TextAlign, Indent, Capitalize, DataType, Format, FontFamily);
        }

        public static void editabletemplate_fontstyle_update(long CompanyID, decimal FontSize, string ManualTracking, string TextAlign, decimal Indent, string Capitalize, string DataType, string Format, string FontFamily, string FontStyle, long FontID)
        {
            Settings.editabletemplate_fontstyle_update(CompanyID, FontSize, ManualTracking, TextAlign, Indent, Capitalize, DataType, Format, FontFamily, FontStyle, FontID);
        }

        public static DataTable editabletemplate_fontstyles_select(long CompanyID)
        {
            return Settings.editabletemplate_fontstyles_select(CompanyID);
        }

        public static string eprint_numbering(int CompanyID, string ModuleName, bool IsHandy)
        {
            return Settings.eprint_numbering(CompanyID, ModuleName, IsHandy);
        }

        public static DataSet Estimate_Outwork_Supplier_Select(long CompanyID, long EstimateID)
        {
            return Settings.Estimate_Outwork_Supplier_Select(CompanyID, EstimateID);
        }

        public static DataSet Estimate_Outwork_Supplier_Select_per_Item(long EstimateItemID)
        {
            return Settings.Estimate_Outwork_Supplier_Select_per_Item(EstimateItemID);
        }

        public static DataTable EstoreReport_Customer_View(int CompanyID, long ReportID, string ReportName, string ModuleName)
        {
            return Settings.EstoreReport_Customer_View(CompanyID, ReportID, ReportName, ModuleName);
        }

        public static string Fetch_SelectedAccountID(long UserID)
        {
            return Settings.Fetch_SelectedAccountID(UserID);
        }

        public static string Fetch_SelectedAccountName(long AccountID)
        {
            return Settings.Fetch_SelectedAccountName(AccountID);
        }

        public static bool Fetch_SupplierQuote(int CompanyID)
        {
            return Settings.Fetch_SupplierQuote(CompanyID);
        }

        public static void Font_Delete(long CompanyID, long FontID)
        {
            Settings.Font_Delete(CompanyID, FontID);
        }

        public static void Font_Insert_Update(long CompanyID, string FontName, long UserId, string FontFilePath, bool ReadyFile, string Extension, string ActualFontFamilyName)
        {
            Settings.Font_Insert_Update(CompanyID, FontName, UserId, FontFilePath, ReadyFile, Extension, ActualFontFamilyName);
        }

        public static DataTable Font_Select(long CompanyID)
        {
            return Settings.Font_Select(CompanyID);
        }

        public static int get_default_Status_ID(int companyID, string type, int estimateid)
        {
            return Settings.get_default_Status_ID(companyID, type, estimateid);
        }

        public static DataTable Get_Estimate_DefaulSetting(int CompanyID)
        {
            return Settings.Get_Estimate_DefaulSetting(CompanyID);
        }

        public static int get_jobStatus_ID(int companyID, string statusTitle)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusTitle = statusTitle
            };
            return Settings.get_jobStatus_ID(settingsItem);
        }

        public static DataTable get_jobStatus_Title(int companyID, int statusID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID
            };
            return Settings.get_jobStatus_Title(settingsItem);
        }

        public static DataTable GetCategories(long CompanyID, long UserID)
        {
            return Settings.GetCategories(CompanyID, UserID);
        }

        public static DataTable GetCategoryNames(long CompanyID, long UserID)
        {
            return Settings.GetCategoryNames(CompanyID, UserID);
        }

        public static bool GetEditableTemplate_Value(long PricecatalogueID)
        {
            return Settings.GetEditableTemplate_Value(PricecatalogueID);
        }

        public static DataTable getEmailForSetting(int AccountId)
        {
            return Settings.getEmailForSetting(AccountId);
        }

        public static DataTable GetFirstandLastPagedetails(int PDFID)
        {
            return Settings.GetFirstandLastPagedetails(PDFID);
        }

        public static DataSet GetImageGalleryCategories(long CompanyID, long CategoryID)
        {
            return Settings.GetImageGalleryCategories(CompanyID, CategoryID);
        }

        public static DataTable GetImageNames(long PriceCatalogueID)
        {
            return Settings.GetImageNames(PriceCatalogueID);
        }

        public static DataTable GetImagePath(long CompanyID, long CategoryID)
        {
            return Settings.GetImagePath(CompanyID, CategoryID);
        }

        public static DataTable getIsStock_Value(long PricecatalogueID)
        {
            return Settings.getIsStock_Value(PricecatalogueID);
        }

        public static DataTable getOldPDFName(int PriceCatalogueID, int NewPriceCatalogueID, string _newpdfnameforcopied)
        {
            return Settings.getOldPDFName(PriceCatalogueID, NewPriceCatalogueID, _newpdfnameforcopied);
        }

        public static DataTable GetProduct_SelectClient(int CompanyID)
        {
            return Settings.GetProduct_SelectClient(CompanyID);
        }
        public static DataTable GetProduct_SelectClient(int CompanyID, int clientTypeId)
        {
            return Settings.GetProduct_SelectClient(CompanyID, clientTypeId);
        }

        public static DataTable GetProduct_SelectDepartment(int CompanyID, string ClientID)
        {
            return Settings.GetProduct_SelectDepartment(CompanyID, ClientID);
        }

        public static DataTable GetProductCanned_Customer(int CompanyID)
        {
            return Settings.GetProductCanned_Customer(CompanyID);
        }

        public static DataTable GetSearchItems(long CompanyID, long CategoryID, long UserID, string SearchText)
        {
            return Settings.GetSearchItems(CompanyID, CategoryID, UserID, SearchText);
        }

        public static DataSet GetStockUsage_InPacks(int CompanyID, string ClientId, string WhereCondition)
        {
            return Settings.GetStockUsage_InPacks(CompanyID, ClientId, WhereCondition);
        }

        public static DataSet GetStockUsage_InPacks_cost(int CompanyID, string ClientId, string WhereCondition)
        {
            return Settings.GetStockUsage_InPacks_cost(CompanyID, ClientId, WhereCondition);
        }
        public static DataSet GetItemsRequiringReorder(int CompanyID, long ClientId)//,, string WhereCondition)
        {
            return Settings.GetItemsRequiringReorder(CompanyID, ClientId);//, WhereCondition);
        }
        public static DataSet GetAllEstimateItemsByCustomers(string query, long CompanyID, long ClientId)//,, string WhereCondition)
        {
            return Settings.GetAllEstimateItemsByCustomers(query, CompanyID, ClientId);//, WhereCondition);
        }
        public static DataSet GetItemsWithReorderAlertsSet(int CompanyID, long ClientId)//, string WhereCondition)
        {
            return Settings.GetItemsWithReorderAlertsSet(CompanyID, ClientId);//, WhereCondition);
        }
        public static DataTable GetCustomerYearlyComparisonData(int CompanyID, string WhereCondition)
        {
            return Settings.GetCustomerYearlyComparisonData(CompanyID, WhereCondition);
        }
        public string Group_webothercostName_Select(long companyid, long ID)
        {
            return Settings.Group_webothercostName_Select(companyid, ID);
        }

        public static void Guillotine_AccountingCode_Insert(long CompanyID, long GuillotineID, int AccountCodeID)
        {
            Settings.Guillotine_AccountingCode_Insert(CompanyID, GuillotineID, AccountCodeID);
        }

        public static int Guillotine_AccountingCode_Select(long CompanyID, long GuillotineID)
        {
            return Settings.Guillotine_AccountingCode_Select(CompanyID, GuillotineID);
        }

        public static void Guillotine_Bind(DropDownList ddl, int CompanyID, string defaultValue)
        {
            DataTable dataTable = Settings.Settings_Guillotine_Select_All(CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["GuillotineName"] = SettingsBasePage.objBase.SpecialDecode(row["GuillotineName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "GuillotineName";
            ddl.DataValueField = "GuillotineID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void Guillotine_Bind_For_Large(DropDownList ddl, int CompanyID, string defaultValue)
        {
            DataTable dataTable = Settings.guillotine_for_large_format_select(CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["GuillotineName"] = SettingsBasePage.objBase.SpecialDecode(row["GuillotineName"].ToString());
            }
            ddl.DataSource = dataTable;
            ddl.DataTextField = "GuillotineName";
            ddl.DataValueField = "GuillotineID";
            ddl.DataBind();
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static DataTable guillotine_for_large_format_select(int CompanyID)
        {
            return Settings.guillotine_for_large_format_select(CompanyID);
        }

        public long Insert_BlankPDFDetails(int CreadtedBy, int CompanyID, string PDFName, string ImageName, string Title, long PriceCatalogueID, double Pageheight, double Pagewidth, double zoomx, double zoomy, double zoompercentage, bool isOverPrintFileRequired, double CropMarkWidth, double CropMarkHeight, bool isAllowPDFPreviews, bool isPDFPreviewMandatory, bool isAllowWaterMark, string WaterMarkText, int NoOfPages)
        {
            Settings setting = new Settings();
            return setting.Insert_BlankPDFDetails(CreadtedBy, CompanyID, PDFName, ImageName, Title, Convert.ToInt64(PriceCatalogueID), Pageheight, Pagewidth, zoomx, zoomy, zoompercentage, isOverPrintFileRequired, 0, 0, isAllowPDFPreviews, isPDFPreviewMandatory, isAllowWaterMark, WaterMarkText, NoOfPages);
        }

        public long Insert_In_EtTemplate(int CreadtedBy, int CompanyID, string PdfName, string Title, long PriceCatalogueID, bool IsOverPrintFileRequired, double CropMarkWidth, double CropNarkHeight, bool IsAllowPDFPreview, bool IsPdfPreviewMandotrory, bool IsAllowWaterMark, string WaterMarkText, long NoOfPages, bool ChkAllowCSV, string Type, string TitleHighResPDFName, string HighResPdfName)
        {
            Settings setting = new Settings();
            return setting.Insert_In_EtTemplate(CreadtedBy, CompanyID, PdfName, Title, PriceCatalogueID, IsOverPrintFileRequired, CropMarkWidth, CropNarkHeight, IsAllowPDFPreview, IsPdfPreviewMandotrory, IsAllowWaterMark, WaterMarkText, NoOfPages, ChkAllowCSV, Type, TitleHighResPDFName, HighResPdfName);
        }

        public static long InsertCategory(long CompanyID, string CategoryName, string Description, long parentId, string CategoryImage, long UserID, string UserType)
        {
            return Settings.InsertCategory(CompanyID, CategoryName, Description, parentId, CategoryImage, UserID, UserType);
        }

        public static long InsertImageGallery(long CompanyID, long CategoryID, long UserID, string UserType, string OriginalFileName, string filename, long FileSize, string Description, string MetaTag, bool IsPDF, long TemplateID)
        {
            return Settings.InsertImageGallery(CompanyID, CategoryID, UserID, UserType, OriginalFileName, filename, FileSize, Description, MetaTag, IsPDF, TemplateID);
        }

        public static string IsCategoryDeleted(long CatID)
        {
            return Settings.IsCategoryDeleted(CatID);
        }

        public static DataSet IsConverted_IsCorped(long PriceCatalogueID, int DbID)
        {
            return Settings.IsConverted_IsCorped(PriceCatalogueID, DbID);
        }

        public static string IsGalleryCategoryAssigned(long CategoryID, long UserID)
        {
            return Settings.IsGalleryCategoryAssigned(CategoryID, UserID);
        }

        public static string IsGalleryImageAssigned(long ImageID, long UserID)
        {
            return Settings.IsGalleryImageAssigned(ImageID, UserID);
        }

        public static string IsImageDeleted(long ImgID)
        {
            return Settings.IsImageDeleted(ImgID);
        }

        public static DataSet JobReport_CustomizeCustomer(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate, string WhereCondition)
        {
            return Settings.JobReport_CustomizeCustomer(CompanyID, ClientID, FromDate, ToDate, WhereCondition);
        }

        // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
        public static DataSet JobReport_CustomizeCustomer2(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate, string WhereCondition)
        {
            return Settings.JobReport_CustomizeCustomer2(CompanyID, ClientID, FromDate, ToDate, WhereCondition);
        }

        public static void LargeFormatPress_AccountingCode_Insert(long CompanyID, long PressID, int AccountCodeID)
        {
            Settings.LargeFormatPress_AccountingCode_Insert(CompanyID, PressID, AccountCodeID);
        }

        public static int LargeFormatPress_AccountingCode_Select(long CompanyID, long PressID)
        {
            return Settings.LargeFormatPress_AccountingCode_Select(CompanyID, PressID);
        }

        public static void Litho_press_AccountingCode_Insert(long CompanyID, long LithoPressID, int AccountCodeID)
        {
            Settings.Litho_press_AccountingCode_Insert(CompanyID, LithoPressID, AccountCodeID);
        }

        public static int LithoPress_AccountingCode_Select(long CompanyID, long LithoPressID)
        {
            return Settings.LithoPress_AccountingCode_Select(CompanyID, LithoPressID);
        }

        public static void ManageCampign_Insert_Update(long CompanyID, long UserID, long AccountID, long ManageID, string EventTitle, string Venue, string EventCode, DateTime StartDate, DateTime EndDate, string UseType, bool IsArchive, string OrderNumber, long DeliveryAddressID, DateTime DeliveryDate)
        {
            Settings.ManageCampign_Insert_Update(CompanyID, UserID, AccountID, ManageID, EventTitle, Venue, EventCode, StartDate, EndDate, UseType, IsArchive, OrderNumber, DeliveryAddressID, DeliveryDate);
        }

        public long MasterTemplate_Insert(long DbID, int CreadtedBy, int CompanyID, string Title, string PdfName, long PriceCatalogueID, bool IsOverPrintFileRequired, double CropMarkWidth, double CropNarkHeight, bool IsAllowPDFPreview, bool IsPdfPreviewMandotrory, bool IsAllowWaterMark, string WaterMarkText, long NoOfPages, string Type, string TitleHighResPDFName, string HighResPdfName)
        {
            Settings setting = new Settings();
            return setting.MasterTemplate_Insert(DbID, CreadtedBy, CompanyID, Title, PdfName, PriceCatalogueID, IsOverPrintFileRequired, CropMarkWidth, CropNarkHeight, IsAllowPDFPreview, IsPdfPreviewMandotrory, IsAllowWaterMark, WaterMarkText, NoOfPages, Type, TitleHighResPDFName, HighResPdfName);
        }

        public long MasterTemplate_InsertBlankPDFDetails(long DbID, int CreadtedBy, int CompanyID, string PDFName, string ImageName, string Title, long PriceCatalogueID, double Pageheight, double Pagewidth, double zoomx, double zoomy, double zoompercentage, bool isOverPrintFileRequired, double CropMarkWidth, double CropMarkHeight, bool isAllowPDFPreviews, bool isPDFPreviewMandatory, bool isAllowWaterMark, string WaterMarkText, int NoOfPages)
        {
            Settings setting = new Settings();
            return setting.MasterTemplate_InsertBlankPDFDetails(DbID, CreadtedBy, CompanyID, PDFName, ImageName, Title, Convert.ToInt64(PriceCatalogueID), Pageheight, Pagewidth, zoomx, zoomy, zoompercentage, isOverPrintFileRequired, 0, 0, isAllowPDFPreviews, isPDFPreviewMandatory, isAllowWaterMark, WaterMarkText, NoOfPages);
        }

        public static DataTable notenc_password_select()
        {
            return Settings.notenc_password_select();
        }

        public static DataTable OrderDetailsReport(long CompanyID, string ClientId, DateTime FromDate, DateTime Todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            return Settings.OrderDetailsReport(CompanyID, ClientId, FromDate, Todate, ISStockItem, IsStockReplenish, AllowUnApprovedOrder);
        }

        public static void OtherCost_AccountingCode_Insert(long CompanyID, long OtherCostID, int AccountCodeID)
        {
            Settings.OtherCost_AccountingCode_Insert(CompanyID, OtherCostID, AccountCodeID);
        }

        public static int OtherCost_AccountingCode_Select(long CompanyID, long OtherCostID)
        {
            return Settings.OtherCost_AccountingCode_Select(CompanyID, OtherCostID);
        }

        public static void othercost_category_order_number_update(int CompanyID, long OthercostCategoryID, int OrderNumber)
        {
            Settings.othercost_category_order_number_update(CompanyID, OthercostCategoryID, OrderNumber);
        }

        public static void othercost_oncategory_Insert(long CompanyID, long OtherCostID, string EstimateType, long OrderNo, bool isMandatory)
        {
            Settings.othercost_oncategory_Insert(CompanyID, OtherCostID, EstimateType, OrderNo, isMandatory);
        }

        public static DataTable othercost_oncategory_select(int CompanyID, long OtherCostCategoryID)
        {
            return Settings.othercost_oncategory_select(CompanyID, OtherCostCategoryID);
        }

        public static void othercost_oncategory_Update(long CompanyID, long ID, int SortWeight)
        {
            Settings.othercost_oncategory_Update(CompanyID, ID, SortWeight);
        }

        public static void othercost_sequence_Delete(long CompanyID, string EstimateType)
        {
            Settings.othercost_sequence_Delete(CompanyID, EstimateType);
        }

        public static DataTable othercost_sequence_select(long CompanyID, string EstimateType)
        {
            return Settings.othercost_sequence_select(CompanyID, EstimateType);
        }

        public static void PaymentTerm_Details_Delete(int PaymentTermID)
        {
            Settings.PaymentTerm_Details_Delete(PaymentTermID);
        }

        public static DataTable PaymentTerm_Details_Select(long CompanyID)
        {
            return Settings.PaymentTerm_Details_Select(CompanyID);
        }

        public static void PaymentTerms_Detail_Insert(long CompanyID, string PaymentName, string PaymentDays, bool IsDefault, int PaymentTermID)
        {
            Settings.PaymentTerms_Detail_Insert(CompanyID, PaymentName, PaymentDays, IsDefault, PaymentTermID);
        }

        public static DataTable PhraseBook_Colour_Size_Material_Select(long CompanyID)
        {
            return Settings.PhraseBook_Colour_Size_Material_Select(CompanyID);
        }

        public static string PODeliveryAddress_BasedonSettings_Select(int CompanyID, string EstimateType)
        {
            return Settings.PODeliveryAddress_BasedonSettings_Select(CompanyID, EstimateType);
        }

        public static DataTable PreFlight_Options_Select(string Type, int TypeId)
        {
            return Settings.PreFlight_Options_Select(Type, TypeId);
        }

        public static void PreFlightProfile_Insert(string ProfileName)
        {
            Settings.PreFlightProfile_Insert(ProfileName);
        }

        public static int price_catalogue_copy(int CompanyID, int UserID, int PriceCatalogueID)
        {
            return Settings.price_catalogue_copy(CompanyID, UserID, PriceCatalogueID);
        }

        public static void Price_Catalogue_Order_Number_Update(int CompanyID, long PriceCatalogueID, int OrderNumber)
        {
            Settings.Price_Catalogue_Order_Number_Update(CompanyID, PriceCatalogueID, OrderNumber);
        }

        public static void Price_For_Whole_Pack_Insert(int CompanyID, bool DefaultPriceForWholePack, string DefaultEstimateType, int Roundoff, string DefaultOutworkMarkpupType, bool DefaulPORaise, bool DefaulDelivaryRaise, bool UpdateItemDescription, string WorkingDaysFrom, string WorkingDaysTo, string RoundoffSubtotal, bool IsRoundLock, int DefaultPaperSize, bool DigitalSingle, bool DigitalBooklet, bool DigitalPad, bool OffsetSingle, bool OffsetBooklet, bool OffsetPad, bool OffsetNCR, bool LargeFormatLinear, bool LargeFormatsquaremeter, bool IsCombineItemfor_SameSupplier, bool Highlightsellingprice, char ProductSelectType, bool AllowPrintReadyFile, bool AllowUnApprovedOrder, bool AllowSorting, bool CopyOutworkDescFieldsToSupplier, bool AllowSortingPopup, bool chkSumCondensedView, bool chkUnitPrice,int PaymentMethod, bool DontTickDescbox,int DefaultCostingType,bool chkisaddheadings,bool chk3DecimalPlaces, bool chkEnblePriority,bool MandatoryReplenishments)
        {
            Settings.Price_For_Whole_Pack_Insert(CompanyID, DefaultPriceForWholePack, DefaultEstimateType, Roundoff, DefaultOutworkMarkpupType, DefaulPORaise, DefaulDelivaryRaise, UpdateItemDescription, WorkingDaysFrom, WorkingDaysTo, RoundoffSubtotal, IsRoundLock, DefaultPaperSize, DigitalSingle, DigitalBooklet, DigitalPad, OffsetSingle, OffsetBooklet, OffsetPad, OffsetNCR, LargeFormatLinear, LargeFormatsquaremeter, IsCombineItemfor_SameSupplier, Highlightsellingprice, ProductSelectType, AllowPrintReadyFile, AllowUnApprovedOrder, AllowSorting, CopyOutworkDescFieldsToSupplier, AllowSortingPopup, chkSumCondensedView,chkUnitPrice,PaymentMethod, DontTickDescbox , DefaultCostingType, chkisaddheadings,chk3DecimalPlaces, chkEnblePriority, MandatoryReplenishments);
        }

        public static void PC_settings_default_Dates_insert(int CompanyID, int ValidFor, string DefaultEstimatedArtwork, string DefaultEstimatedProof, string DefaultEstimatedApproval, string DefaultEstimatedProduction, string DefaultEstimatedCompletion, string DefaultEstimatedDelivery, bool IsDefaultArtwork, bool IsDefaultProof, bool IsDefaultApproval, bool IsDefaultProduction, bool IsDefaultCompletion, bool IsDefaultDelivery, bool IsDefaultCustomDate1, bool IsDefaultCustomDate2, bool IsDefaultCustomDate3, bool IsDefaultCustomDate4, bool IsDefaultCustomDate5, string DefaultCustomDate1, string DefaultCustomDate2, string DefaultCustomDate3, string DefaultCustomDate4, string DefaultCustomDate5, string DefaultCustomDateTitle1, string DefaultCustomDateTitle2, string DefaultCustomDateTitle3, string DefaultCustomDateTitle4, string DefaultCustomDateTitle5)
        {
          
            Settings.PC_settings_default_Dates_insert(CompanyID, ValidFor, DefaultEstimatedArtwork, DefaultEstimatedProof, DefaultEstimatedApproval, DefaultEstimatedProduction, DefaultEstimatedCompletion, DefaultEstimatedDelivery, IsDefaultArtwork, IsDefaultProof, IsDefaultApproval, IsDefaultProduction, IsDefaultCompletion, IsDefaultDelivery, IsDefaultCustomDate1, IsDefaultCustomDate2, IsDefaultCustomDate3, IsDefaultCustomDate4, IsDefaultCustomDate5, DefaultCustomDate1, DefaultCustomDate2, DefaultCustomDate3, DefaultCustomDate4, DefaultCustomDate5, DefaultCustomDateTitle1, DefaultCustomDateTitle2, DefaultCustomDateTitle3, DefaultCustomDateTitle4, DefaultCustomDateTitle5);
        }

        public static DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            return Settings.Price_For_Whole_Pack_Select(CompanyID);
        }

        public static string PC_select_ProductEditingOption_Status(int CompanyID)
        {
            return Settings.PC_select_ProductEditingOption_Status(CompanyID);
        }

        public static DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            return Settings.PC_select_DeliveryCost_Settings(CompanyID, AccountID);
        }

        public static DataTable PC_select_MIS_DeliveryCost_Settings(int CompanyID)
        {
            return Settings.PC_select_MIS_DeliveryCost_Settings(CompanyID);
        }

        public static void PC_Update_ProductEditingOption_Status(long ID, string Status)
        {
            Settings.PC_Update_ProductEditingOption_Status(ID, Status);
        }

        public static void PC_Update_DeliveryCost_Settings(int CompanyID, int AccountID, bool IsEnableDC, bool IsEnableShipEngine, bool Allowpickup)
        {
            Settings.PC_Update_DeliveryCost_Settings(CompanyID, AccountID, IsEnableDC, IsEnableShipEngine, Allowpickup);
        }

        public static void PC_Update_MIS_DeliveryCost_Settings(int CompanyID, bool IsEnableDC, bool IsEnableShipEngine, bool Allowpickup)
        {
            Settings.PC_Update_MIS_DeliveryCost_Settings(CompanyID, IsEnableDC, IsEnableShipEngine, Allowpickup);
        }

        public static DataTable Pricecatalog_Import(long CompanyID, string IsFromWebStore, string EstimateType, string MatrixType)
        {
            return Settings.Pricecatalog_Import(CompanyID, IsFromWebStore, EstimateType, MatrixType);
        }

        public static void PriceCatalogue_AccountingCode_Insert(long CompanyID, long PriceCatalogueID, int AccountCodeID)
        {
            Settings.PriceCatalogue_AccountingCode_Insert(CompanyID, PriceCatalogueID, AccountCodeID);
        }

        public static int PriceCatalogue_AccountingCode_Select(long CompanyID, long PriceCatalogueID)
        {
            return Settings.PriceCatalogue_AccountingCode_Select(CompanyID, PriceCatalogueID);
        }

        public void PriceCatalogue_Allocation_Insert(int id, int CustomerID, int AccountID, string AllocationType)
        {
            Settings.PriceCatalogue_Allocation_Insert(id, CustomerID, AccountID, AllocationType);
        }

        public void PriceCatalogue_Allocation_Remove(int id, string AllocationType, int CustomerID, string From)
        {
            Settings.PriceCatalogue_Allocation_Remove(id, AllocationType, CustomerID, From);
        }

        public DataTable PriceCatalogue_Allocation_Select(int companyid, string allocationType, long ID, string From)
        {
            return Settings.PriceCatalogue_Allocation_Select(companyid, allocationType, ID, From);
        }

        public static void PriceCatalogue_Category_Delete(int CompanyID, int PriceCatalogueCategoryID)
        {
            Settings.PriceCatalogue_Category_Delete(CompanyID, PriceCatalogueCategoryID);
        }

        public static int PriceCatalogue_Category_Insert(int CompanyID, string PriceCatalogueCategoryName)
        {
            return Settings.PriceCatalogue_Category_Insert(CompanyID, PriceCatalogueCategoryName);
        }

        public static void PriceCatalogue_Category_Select(int CompanyID, DropDownList ddl)
        {
            ddl.DataSource = Settings.PriceCatalogue_Category_Select(CompanyID);
            ddl.DataTextField = "PriceCatalogueCategoryName";
            ddl.DataValueField = "PriceCatalogueCategoryID";
            ddl.DataBind();
        }

        public static int PriceCatalogue_CategoryID_Import(int CompanyID, string PriceCatalogueCategoryName)
        {
            return Settings.PriceCatalogue_CategoryID_Import(CompanyID, PriceCatalogueCategoryName);
        }

        public static DataTable PriceCatalogue_Customer_View(int CompanyID, long PriceCatalogueID)
        {
            return Settings.PriceCatalogue_Customer_View(CompanyID, PriceCatalogueID);
        }
        public static DataTable DeliveryNote_Number_View(int CompanyID, long EstimateID)
        {
            return Settings.DeliveryNote_Number_View(CompanyID, EstimateID);
        }

        public static DataTable Purchase_Number_View(int CompanyID, long EstimateID)
        {
            return Settings.Purchase_Number_View(CompanyID, EstimateID);
        }

        public static int PriceCatalogue_DeleteCatalogueID_Exsists(int CompanyID, int CategoryID, string Itemcode)
        {
            return Settings.PriceCatalogue_DeleteCatalogueID_Exsists(CompanyID, CategoryID, Itemcode);
        }

        public static int PriceCatalogue_PriceCatalogueID_Exsists(int CompanyID, int CategoryID, string Itemcode, string ItemTitle)
        {
            return Settings.PriceCatalogue_PriceCatalogueID_Exsists(CompanyID, CategoryID, Itemcode, ItemTitle);
        }

        public DataTable PriceCatalogue_webothercost_Select(int companyID, long ID)
        {
            return Settings.PriceCatalogue_webothercost_Select(companyID, ID);
        }

        public static long PriceCatalogueFeatures_Insert(SettingsItem item)
        {
            return Settings.PriceCatalogueFeatures_Insert(item);
        }

        public static DataSet PriceCatalogueFeatures_select(int CompanyID, int PriceCatalogueFeautredID, int maximumRows, int startRowIndex)
        {
            return Settings.PriceCatalogueFeatures_select(CompanyID, PriceCatalogueFeautredID, maximumRows, startRowIndex);
        }

        public static int Product_AddEditAccess_Check(int CompanyId, int UserId)
        {
            return Settings.Product_AddEditAccess_Check(CompanyId, UserId);
        }

        public DataTable Product_Customer_Select(long companyid, long ID, string AllocationType, string From)
        {
            return Settings.Product_Customer_Select(companyid, ID, AllocationType, From);
        }

        public static string Product_ItemTitle_Select(long PriceCatalogueID)
        {
            return Settings.Product_ItemTitle_Select(PriceCatalogueID);
        }

        public static void productcatalogue_StockReminderEmail_delete(int EmailID)
        {
            Settings.productcatalogue_StockReminderEmail_delete(EmailID);
        }

        public static DataTable productcatalogue_StockReminderEmail_select(int CompanyID)
        {
            return Settings.productcatalogue_StockReminderEmail_select(CompanyID);
        }

        public static DataTable productcatalogue_StockReminderEmail_selectedrow(int EmailID)
        {
            return Settings.productcatalogue_StockReminderEmail_selectedrow(EmailID);
        }

        public static void productcatalogue_StockReminderEmailBody_insert(int CompanyID, int UserID, string TemplateName, string EmailBody, int IsDefault, string Subject)
        {
            Settings.productcatalogue_StockReminderEmailBody_insert(CompanyID, UserID, TemplateName, EmailBody, IsDefault, Subject);
        }

        public static void productcatalogue_StockReminderEmailBody_update(int EmailID, string TemplateName, string EmailBody, int IsDefault, string Subject)
        {
            Settings.productcatalogue_StockReminderEmailBody_update(EmailID, TemplateName, EmailBody, IsDefault, Subject);
        }

        public static void productcatalogue_warehouselocation_delete(int LocationID)
        {
            Settings.productcatalogue_warehouselocation_delete(LocationID);
        }

        public static void productcatalogue_warehouselocation_insert(int companyid, string LocationName, string Address, string City, string Suburb, string PostCode, string Country, string Telephone, int IsDefault)
        {
            Settings.productcatalogue_warehouselocation_insert(companyid, LocationName, Address, City, Suburb, PostCode, Country, Telephone, IsDefault);
        }

        public static DataTable productcatalogue_warehouselocation_select(int companyid)
        {
            return Settings.productcatalogue_warehouselocation_select(companyid);
        }

        public static void productcatalogue_warehouselocation_update(int companyid, int LocationID, string LocationName, string Address, string City, string Suburb, string PostCode, string Country, string Telephone, int IsDefault)
        {
            Settings.productcatalogue_warehouselocation_update(companyid, LocationID, LocationName, Address, City, Suburb, PostCode, Country, Telephone, IsDefault);
        }

        public static DataTable productcatalogue_warehousestock_select(int CompanyID)
        {
            return Settings.productcatalogue_warehousestock_select(CompanyID);
        }

        public static void productcatalogue_warehousestock_update(int CompanyID, string FieldName, string ScreenName, int IsDisplay)
        {
            Settings.productcatalogue_warehousestock_update(CompanyID, FieldName, ScreenName, IsDisplay);
        }

        public static DataTable ProductReport_CustomizeCustomer(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate)
        {
            return Settings.ProductReport_CustomizeCustomer(CompanyID, ClientID, FromDate, ToDate);
        }

        // added code for new report "Stock Release and Adjustment Report 2" by shehzad
        public static DataTable ProductReport_CustomizeCustomer2(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate)
        {
            return Settings.ProductReport_CustomizeCustomer2(CompanyID, ClientID, FromDate, ToDate);
        }
        public static DataTable ProductstockUsageReport(long CompanyID, string ClientId, string DepartmentId, string MonthCatagory)
        {
            return Settings.ProductstockUsageReport(CompanyID, ClientId, DepartmentId, MonthCatagory);
        }
        public static DataTable ProductstockUsageHistoryReport(long CompanyID, string ClientId, string DepartmentId, string MonthCatagory)
        {
            return Settings.ProductstockUsageHistoryReport(CompanyID, ClientId, DepartmentId, MonthCatagory);
        }

        public static void ProductVisibility_Item(string type, string IDs)
        {
            Settings.ProductVisibility_Item(type, IDs);
        }

        public static void Purchase_AccountingCode_Insert(long CompanyID, long PurchaseID, int AccountCodeID)
        {
            Settings.Purchase_AccountingCode_Insert(CompanyID, PurchaseID, AccountCodeID);
        }

        public static int Purchase_AccountingCode_Select(long CompanyID, long PurchaseID)
        {
            return Settings.Purchase_AccountingCode_Select(CompanyID, PurchaseID);
        }

        public static DataSet Report_ActivitytaskEvent_select(int companyID, int PageSize, int PageNumber, long UserID, string Columns, string GroupBy, string CompanyType, string ReportName, string Description, string SaveType, long ReportID, string PageName)
        {
            return Settings.Report_ActivitytaskEvent_select(companyID, PageSize, PageNumber, UserID, Columns, GroupBy, CompanyType, ReportName, Description, SaveType, ReportID, PageName);
        }

        public static DataSet report_pricecatalogue_select(int companyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string Columns, string Qtyoption, string IsPriceChecked, string SearchText, string Catagory, string Customer, string PublicAccount, string IsSpecific, string ISDateChecked, string SaveType, string DateType, string CompanyName, string ReportName, string Description, string PageName, long UserID, long ReportID, string FromDate, string ToDate, string createdDate, string CategoryID, int ClientID, int IsNonEditable, int IsStock, int IsEditable, int IsOpeningStock, int IsLocation, int IsQtyAdded, int IsQtySold, int IsQtyAdjustedIncreament, int IsQtyAdjustedDecrement, int IsDetailedAdditionalOptionStock)
        {
            return Settings.report_pricecatalogue_select(companyID, PageSize, PageNumber, SortBy, SortDirection, Columns, Qtyoption, IsPriceChecked, SearchText, Catagory, Customer, PublicAccount, IsSpecific, ISDateChecked, SaveType, DateType, CompanyName, ReportName, Description, PageName, UserID, ReportID, FromDate, ToDate, createdDate, CategoryID, ClientID, IsNonEditable, IsStock, IsEditable, IsOpeningStock, IsLocation, IsQtyAdded, IsQtySold, IsQtyAdjustedIncreament, IsQtyAdjustedDecrement, IsDetailedAdditionalOptionStock);
        }

        public static DataTable ReturnScreenName_Select(int companyID)
        {
            return Settings.ReturnScreenName_Select(companyID);
        }

        public static void Roles_AccessDetails_Insert(long RoleID, string SectionName, int AddEdit, int Read, int Tab_Delete, int Show, string Others, string PrintorEmail, string ExportorImport, string Revert, long CompanyID, string IsTaskEventCall, string IsForecast,string IsRemove)
        {
            Settings.Roles_AccessDetails_Insert(RoleID, SectionName, AddEdit, Read, Tab_Delete, Show, Others, PrintorEmail, ExportorImport, Revert, CompanyID, IsTaskEventCall, IsForecast,IsRemove);
        }

        public static void Roles_AccessDetails_Update(long RoleID, string SectionName, int AddEdit, int Read, int Tab_Delete, int archive, int Show, string Others, string PrintorEmail, string ExportorImport, string Revert, long CompanyID, string IsTaskEventCall, string IsForecast,string IsRemove)
        {
            Settings.Roles_AccessDetails_Update(RoleID, SectionName, AddEdit, Read, Tab_Delete, archive, Show, Others, PrintorEmail, ExportorImport, Revert, CompanyID, IsTaskEventCall, IsForecast,IsRemove);
        }

        public static void Roles_ReportDetails_Insert(long RoleID, int ShowReport, int ExportReport, long CompanyID, string ReportItems, int ReportOrderNumber)
        {
            Settings.Roles_ReportDetails_Insert(RoleID, ShowReport, ExportReport, CompanyID, ReportItems, ReportOrderNumber);
        }

        public static void Roles_ReportDetails_Update(long RoleID, int ShowReport, int ExportReport, long CompanyID, string ReportItems, int ReportOrderNumber)
        {
            Settings.Roles_ReportDetails_Update(RoleID, ShowReport, ExportReport, CompanyID, ReportItems, ReportOrderNumber);
        }

        public static long Roles_StaticCheckBox_Insert(string RoleName, int CompanyId, string Description, bool showCostExMarkup, bool showMarkup, bool showCostIncMarkup, bool showProfitMargin, bool showProfitInCurrency, bool showSubTotal, bool showTax, bool showSellingPrice, bool showGrossProfitMargin, bool showGrossProfit, bool showSupplierName, bool showPrice, bool showCalculated, bool showSubItems, string unSuccessfulLoginAttemptCount, string changePWDAfterSelectedDays, string restrictSystemIPforUnauthorizedEmailAccess, bool isDelete, bool isSpecialPrivilege, string ShowRecords, string EditRecords, string TypeList, string IPType, string IPList)
        {
            return Settings.Roles_StaticCheckBox_Insert(RoleName, CompanyId, Description, showCostExMarkup, showMarkup, showCostIncMarkup, showProfitMargin, showProfitInCurrency, showSubTotal, showTax, showSellingPrice, showGrossProfitMargin, showGrossProfit, showSupplierName, showPrice, showCalculated, showSubItems, unSuccessfulLoginAttemptCount, changePWDAfterSelectedDays, restrictSystemIPforUnauthorizedEmailAccess, isDelete, isSpecialPrivilege, ShowRecords, EditRecords, TypeList, IPType, IPList);
        }

        public static void Roles_StaticCheckBox_Update(long RoleID, int CompanyId, string Description, bool showCostExMarkup, bool showMarkup, bool showCostIncMarkup, bool showProfitMargin, bool showProfitInCurrency, bool showSubTotal, bool showTax, bool showSellingPrice, bool showGrossProfitMargin, bool showGrossProfit, bool showSupplierName, bool showPrice, bool showCalculated, bool showSubItems, string unSuccessfulLoginAttemptCount, string changePWDAfterSelectedDays, string restrictSystemIPforUnauthorizedEmailAccess, bool isSpecialPrivilege, string ShowRecords, string EditRecords, string TypeList, string IPType, string IPList,Boolean Locking, Boolean IgnoreLock, bool showAdditional)
        {
            Settings.Roles_StaticCheckBox_Update(RoleID, CompanyId, Description, showCostExMarkup, showMarkup, showCostIncMarkup, showProfitMargin, showProfitInCurrency, showSubTotal, showTax, showSellingPrice, showGrossProfitMargin, showGrossProfit, showSupplierName, showPrice, showCalculated, showSubItems, unSuccessfulLoginAttemptCount, changePWDAfterSelectedDays, restrictSystemIPforUnauthorizedEmailAccess, isSpecialPrivilege, ShowRecords, EditRecords, TypeList, IPType, IPList, Locking, IgnoreLock, showAdditional);
        }

        //public static DataSet SelectUserTypeSettings(long CompanyId, long userId)
        //{
        //    return Settings.SelectUserTypeSettings(CompanyId, userId);
        //}

        public static int Save_Estore_EmailSetting(int EmailSettingID, int AccountID, int CompanyID, string AdminTo, string AdminCc, string AdminBcc, string CustomerFrom, string CustomerCc, string CustomerBcc)
        {
            return Settings.Save_Estore_EmailSetting(EmailSettingID, AccountID, CompanyID, AdminTo, AdminCc, AdminBcc, CustomerFrom, CustomerCc, CustomerBcc);
        }

        public static void SaveCampaign(long AccountID, long CompanyID, int IsCampaign)
        {
            Settings.SaveCampaign(AccountID, CompanyID, IsCampaign);
        }

        public static DataTable Select_Address_CheckBoxStatus(int CompanyID, int AccountID)
        {
            return Settings.Select_Address_CheckBoxStatus(CompanyID, AccountID);
        }

        public static DataTable select_Alert_Notification_EmailBody(long CompanyID)
        {
            return Settings.select_Alert_Notification_EmailBody(CompanyID);
        }

        public static DataTable Select_EmailSignature(int CompanyID)
        {
            return Settings.Select_EmailSignature(CompanyID);
        }

        public static DataTable Select_JobCardSettings(long CompanyID)
        {
            return Settings.Select_JobCardSettings(CompanyID);
        }

        public static DataTable Select_ProductStockManagement(int CompanyID)
        {
            return Settings.Select_ProductStockManagement(CompanyID);
        }

        public static DataTable select_SystemIp_Address(long UserTypeID)
        {
            return Settings.select_SystemIp_Address(UserTypeID);
        }

        public static DataTable select_UpdatedStatus(int CompanyID, string cond, long estimateID)
        {
            return Settings.select_UpdatedStatus((long)CompanyID, cond, estimateID);
        }

        public static long SelectDBID(long CompanyID, string SystemName)
        {
            return Settings.SelectDBID(CompanyID, SystemName);
        }

        public static string SelectForecolor_GetActiveTabForeColor(int CompanyID, string HeaderName)
        {
            return Settings.SelectForecolor_GetActiveTabForeColor(CompanyID, HeaderName);
        }

        public static DataTable SelectInUseCampaign(long AccountID, long ManageID)
        {
            return Settings.SelectInUseCampaign(AccountID, ManageID);
        }

        public static string SelectIsConverted(long PriceCatalogueID, long DbID)
        {
            return Settings.SelectIsConverted(PriceCatalogueID, DbID);
        }

        public static string SelectIsConverted_Croped(long PriceCatalogueID, int DbID)
        {
            return Settings.SelectIsConverted_Croped(PriceCatalogueID, DbID);
        }

        public static DataTable SelectMangeCampign(long CompanyID, long UserID, long AccountID)
        {
            return Settings.SelectMangeCampign(CompanyID, UserID, AccountID);
        }

        public static void Set_Horizontal_Group_TOP(int CompanyID, long TemplateID)
        {
            Settings.Set_Horizontal_Group_TOP(CompanyID, TemplateID);
        }

        public static DataSet Set_TemplateID(long PriceCatalogueID)
        {
            return Settings.Set_TemplateID(PriceCatalogueID);
        }

        public static void SetDefault_PaymentTerm(long CompanyID, int PaymentTermID)
        {
            Settings.SetDefault_PaymentTerm(CompanyID, PaymentTermID);
        }

        public static void SetDefault_RefferceBy(long CompanyID, int ReferencedID)
        {
            Settings.SetDefault_RefferceBy(CompanyID, ReferencedID);
        }

        public static void Setting_accountingCode_Delete(int CompanyID, int AccountCodeID)
        {
            Settings.Setting_accountingCode_Delete(CompanyID, AccountCodeID);
        }

        public static int Setting_accountingCode_Insert(int CompanyID, string Code, string Description, bool IsDefault, bool IsDefaultPurchase, int AccountCodeID, bool IsRevenueCode, bool IsPurchaseCode)
        {
            return Settings.Setting_accountingCode_Insert(CompanyID, Code, Description, IsDefault, IsDefaultPurchase, AccountCodeID, IsRevenueCode, IsPurchaseCode);
        }

        public static DataTable Setting_accountingCode_SelectAll(int CompanyID)
        {
            return Settings.Setting_accountingCode_SelectAll(CompanyID);
        }

        public static DataTable Setting_accountingCode_SelectAllPurchaseCode(int CompanyID)
        {
            return Settings.Setting_accountingCode_SelectAllPurchaseCode(CompanyID);
        }

        public static DataTable Setting_accountingCode_SelectAllRevenueCode(int CompanyID)
        {
            return Settings.Setting_accountingCode_SelectAllRevenueCode(CompanyID);
        }

        public static void Setting_eStoreReports_InsertUpdate(bool IsEnabled, string UserType, int accountId, int CompanyId)
        {
            Settings.Setting_eStoreReports_InsertUpdate(IsEnabled, UserType, accountId, CompanyId);
        }

        public static DataTable Setting_eStoreReports_Select(int accountId, int CompanyId)
        {
            return Settings.Setting_eStoreReports_Select(accountId, CompanyId);
        }

        public static void Setting_Insert_PublicLogoutSettings(long AccountID, long CompanyID, long UserID, string ReDirectURL, bool IsCustomLogout, bool IsForceUSer)
        {
            Settings.Setting_Insert_PublicLogoutSettings(AccountID, CompanyID, UserID, ReDirectURL, IsCustomLogout, IsForceUSer);
        }

        public static void Setting_Insert_PublicttrackingSettings(long AccountID, long CompanyID, long UserID, string ReDirectURL, bool IsEnableTracking)
        {
            Settings.Setting_Insert_PublicttrackingSettings(AccountID, CompanyID, UserID, ReDirectURL, IsEnableTracking);
        }

        public static void Setting_Insert_SpendLimitSettings(long AccountID, long CompanyID, long UserID, bool IsSpendLimit, bool IsPerUser, bool IsPerDept)
        {
            Settings.Setting_Insert_SpendLimitSettings(AccountID, CompanyID, UserID, IsSpendLimit, IsPerUser, IsPerDept);
        }

        public static void Setting_Insert_StoreCreditsettings(long AccountID, long CompanyID, long UserID, bool IsStoreCreditsEnabled, bool IsDeleted)
        {
            Settings.Setting_Insert_StoreCreditsettings(AccountID, CompanyID, UserID, IsStoreCreditsEnabled, IsDeleted);
        }

        public static void Setting_Insert_ZipToTaxsettings(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted, string ZipUsername, string ZipPassword)
        {
            Settings.Setting_Insert_ZipToTaxsettings(AccountID, CompanyID, UserID, IsZip2taxEnabled, IsDeleted, ZipUsername, ZipPassword);
        }
        public static void Setting_InsertUpdateProofTermsAndConditions(long CompanyID, long ClientID, bool IsTermAndConditions, string TermsAndConditions)
        {
            Settings.Setting_InsertUpdateProofTermsAndConditions(CompanyID, ClientID, IsTermAndConditions, TermsAndConditions);
        }

        public static void Setting_InsertUpdateShipEngineErrorMsg(long CompanyID, long ClientID, bool IsTermAndConditions, string ErrorMsg)
        {
            Settings.Setting_InsertUpdateShipEngineErrorMsg(CompanyID, ClientID, IsTermAndConditions, ErrorMsg);
        }
        public static void Setting_AllInsertUpdateProofTermsAndConditions(List<ProofTermsAndConditionsData> clientList)
        {
            Settings.Setting_AllInsertUpdateProofTermsAndConditions(clientList);
        }

        public static void Setting_AllInsertUpdateShipEngineErrorData(List<ShipEngineErrorData> clientList)
        {
            Settings.Setting_AllInsertUpdateShipEngineErrorData(clientList);
        }
        public static void Setting_InsertUpdate_ProofTermsAndCondition(long CompanyID, long ClientID, bool IsTermAndConditions)
        {
            Settings.Setting_InsertUpdate_ProofTermsAndCondition(CompanyID, ClientID, IsTermAndConditions);
        }

        public static void Setting_Insert_ZipToTaxsettings_only(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted)
        {
            Settings.Setting_Insert_ZipToTaxsettings_only(AccountID, CompanyID, UserID, IsZip2taxEnabled, IsDeleted);
        }

        public static void Setting_Insert_Crm_ZipToTaxsettings(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted)
        {
            Settings.Setting_Insert_Crm_ZipToTaxsettings(AccountID, CompanyID, UserID, IsZip2taxEnabled, IsDeleted);
        }

        public static void Setting_JobCardSettings_Insert(int CompanyID, string SectionName, string Description, bool IsChecked, string EstimateType, string ItemType)
        {
            Settings.Setting_JobCardSettings_Insert(CompanyID, SectionName, Description, IsChecked, EstimateType, ItemType);
        }

        public static DataTable Setting_JobCardSettings_SelectAll(int CompanyID, string Estimatetype, string ItemtType)
        {
            return Settings.Setting_JobCardSettings_SelectAll(CompanyID, Estimatetype, ItemtType);
        }

        public static DataTable Setting_jobcardtags_Select(string estimatetype)
        {
            return Settings.Setting_jobcardtags_Select(estimatetype);
        }

        public static DataTable Setting_PublicLogoutSettings_Select(long AccountID, long CompanyID)
        {
            return Settings.Setting_PublicLogoutSettings_Select(AccountID, CompanyID);
        }

        public static void Setting_ReferencedBy_InsertUpdate(int ReferencedID, int CompanyID, string Name, string CommissionValue, bool InUse, bool IsDefault)
        {
            Settings.Setting_ReferencedBy_InsertUpdate(ReferencedID, CompanyID, Name, CommissionValue, InUse, IsDefault);
        }

        public static DataTable Setting_SpendLimit_Select(long AccountID, long CompanyID)
        {
            return Settings.Setting_SpendLimit_Select(AccountID, CompanyID);
        }

        public static DataTable Setting_StoreCredit_Select(long AccountID, long CompanyID)
        {
            return Settings.Setting_StoreCredit_Select(AccountID, CompanyID);
        }
        public static DataTable Setting_ProofTermsAndCondition_Select(long ClientID, long CompanyID)
        {
            return Settings.Setting_ProofTermsAndCondition_Select(ClientID, CompanyID);
        }

        public static DataTable Setting_ShipEngineError_Select(long ClientID, long CompanyID)
        {
            return Settings.Setting_ShipEngineError_Select(ClientID, CompanyID);
        }
        public static DataTable Setting_GetProofTermsSelectedCustomer(long CompanyID)
        {
            return Settings.Setting_GetProofTermsSelectedCustomer(CompanyID);
        }

        public static DataTable Setting_GetShipEngineErrorSelectedCustomer(long CompanyID)
        {
            return Settings.Setting_GetShipEngineErrorSelectedCustomer(CompanyID);
        }
        public static DataTable Setting_ZiptoTax_Select(long AccountID, long CompanyID)
        {
            return Settings.Setting_ZiptoTax_Select(AccountID, CompanyID);
        }


        public static void Setting_UpdateHidePrice(long AccountID, bool IsHidePrice)
        {
            Settings.Setting_UpdateHidePrice(AccountID, IsHidePrice);
        }

        public static DataTable setting_user_edit(int companyID, int userid, TextBox txtname, TextBox txtemail, TextBox txtpassword, TextBox txtconfirmpassword, DropDownList ddlrole, TextBox txtdesription, CheckBox chkdisable, TextBox txtPhone, TextBox txtMobile, TextBox txtFax)
        {
            return Settings.setting_user_edit(companyID, userid, txtname, txtemail, txtpassword, txtconfirmpassword, ddlrole, txtdesription, chkdisable, txtPhone, txtMobile, txtFax);
        }

        public static DataTable setting_user_profile(int companyID, int userid)
        {
            return Settings.setting_user_profile(companyID, userid);
        }

        public static void settings_accountstatus_delete(int companyID, int statusID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID
            };
            Settings.settings_accountstatus_delete(settingsItem);
        }

        public static int settings_accountstatus_insert(int companyID, string statusTitle, bool IsDefault)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusTitle = statusTitle,
                IsDefaultStatus = IsDefault
            };
            return Settings.settings_accountstatus_insert(settingsItem);
        }

        public static DataTable settings_accountstatus_select(int CompanyID)
        {
            return Settings.settings_accountstatus_select(CompanyID);
        }

        public static void settings_accountstatus_setDefalut(int companyID, int StatusID)
        {
            Settings.settings_accountstatus_setDefalut(companyID, StatusID);
        }

        public static DataTable settings_AccountStatus_SetDefault(int CompanyID)
        {
            return Settings.settings_AccountStatus_SetDefault(CompanyID);
        }

        public static int settings_accountstatus_update(int companyID, int statusID, string statusTitle, bool IsDefault)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID,
                StatusTitle = statusTitle,
                IsDefaultStatus = IsDefault
            };
            return Settings.settings_accountstatus_update(settingsItem);
        }

        public static int settings_check_userid_exist(int CompanyID, int UserID)
        {
            return Settings.settings_check_userid_exist(CompanyID, UserID);
        }

        public static long Settings_ClickChargeLookup_Insert(int CompanyID, decimal BlackChargeableSheets, decimal ColorChargeableSheets, decimal ChargeableSheets, long ClickChargeLookupID)
        {
            return Settings.Settings_ClickChargeLookup_Insert(CompanyID, BlackChargeableSheets, ColorChargeableSheets, ChargeableSheets, ClickChargeLookupID);
        }

        public static DataTable Settings_ClickChargeLookup_Select_By_ID(int CompanyID, long ClickChargeLookupID)
        {
            return Settings.Settings_ClickChargeLookup_Select_By_ID(CompanyID, ClickChargeLookupID);
        }

        public static void Settings_ClickChargeZoneLookup_Insert(int CompanyID, long DigitalPressID, int ZoneFrom, int ZoneTo, int ChargeableSheets, decimal Cost, decimal ChargeableRate, string ZoneType)
        {
            Settings.Settings_ClickChargeZoneLookup_Insert(CompanyID, DigitalPressID, ZoneFrom, ZoneTo, ChargeableSheets, Cost, ChargeableRate, ZoneType);
        }
        public static void Settings_LargeFormatChargeZone_Insert(string ZoneType)
        {
            Settings.Settings_LargeFormatChargeZone_Insert(ZoneType);
        }
        

        public static DataTable Settings_ClickChargeZoneLookup_Select_By_ID(int CompanyID, long DigitalPressID)
        {
            return Settings.Settings_ClickChargeZoneLookup_Select_By_ID(CompanyID, DigitalPressID);
        }
        public static DataTable Settings_LargeFormatChargeZone_Select_By_IDlong(long DigitalPressID)
        {
            return Settings.Settings_LargeFormatChargeZone_Select_By_IDlong(DigitalPressID);
        }

        public static string settings_companyweight_select(int CompanyID)
        {
            return Settings.settings_companyweight_select(CompanyID);
        }

        public static DataTable settings_companyprofile_select(int CompanyID)
        {
            return Settings.settings_companyprofile_select(CompanyID);
        }
        public static DataTable shipengine_sent_settings_select(int CompanyID)
        {
            return Settings.shipengine_sent_settings_select(CompanyID);
        }
        public static void UpdateJobDeliveryDate(long jobId, DateTime deliveryDate)
        {
             Settings.UpdateJobDeliveryDate(jobId, deliveryDate);
        }

        public static void settings_companyprofile_update(int CompanyID, string CompanyName, string AddressLine1, string AddressLine2, string AddressLine3, string PostalCode, string Country, string Telephone, string Fax, string URL, string CompanyNumber, string TaxNumber, int CountryID, string MarketingEmail, DateTime fiscalfromtxt, DateTime fiscaltotxt, string CurrencyCountryID)
        {
            Settings.settings_companyprofile_update(CompanyID, CompanyName, AddressLine1, AddressLine2, AddressLine3, PostalCode, Country, Telephone, Fax, URL, CompanyNumber, TaxNumber, CountryID, MarketingEmail, fiscalfromtxt, fiscaltotxt, CurrencyCountryID);
        }

        public static void shipengine_sent_settings_update(int CompanyID, string AddressLine1, string AddressLine2, string City, string State, string PostalCode, string Country, string MaxWeight, int CountryID, string Weight)
        {
            Settings.shipengine_sent_settings_update(CompanyID, AddressLine1, AddressLine2, City, State, PostalCode, Country, MaxWeight, CountryID, Weight);
        }

        public static DataTable settings_CompanyType_ddlselect(int Id)
        {
            return Settings.settings_CompanyType_ddlselect(Id);
        }

        public static void settings_CompanyType_deleterow(int id, int CompanyID)
        {
            Settings.settings_CompanyType_deleterow(id, CompanyID);
        }

        public static DataTable settings_CompanyType_select(int CompanyID)
        {
            return Settings.settings_CompanyType_select(CompanyID);
        }

        public static DataTable settings_CompanyType_select_ForClient(int CompanyID, string Companytype)
        {
            return Settings.settings_CompanyType_select_ForClient(CompanyID, Companytype);
        }

        public static void settings_copmanyType_insert(int id, int CompanyID, string CompanyType, int UserID, string UsedIn, DateTime datetime)
        {
            Settings.settings_copmanyType_insert(id, CompanyID, CompanyType, UserID, UsedIn, datetime);
        }

        public static void Settings_CopyWidget_delete(int CopyMasterID, int CompanyID)
        {
            Settings.Settings_CopyWidget_delete(CopyMasterID, CompanyID);
        }

        public static void settings_costformulabased_delete(int CompanyID, long OtherCostID)
        {
            Settings.settings_costformulabased_delete(CompanyID, OtherCostID);
        }

        public static long settings_costformulabased_insert(int CompanyID, long CostFormulaBasedID, long OtherCostID, string FormulaType, string Formula, string FormulaTag)
        {
            return Settings.settings_costformulabased_insert(CompanyID, CostFormulaBasedID, OtherCostID, FormulaType, Formula, FormulaTag);
        }

        public static DataTable settings_costformulabased_select(int CompanyID, long CostFormulaBasedID)
        {
            return Settings.settings_costformulabased_select(CompanyID, CostFormulaBasedID);
        }

        public static DataTable settings_costformulatag_selectall(int CompanyID)
        {
            return Settings.settings_costformulatag_selectall(CompanyID);
        }

        public static long settings_costquantitybased_insert(int CompanyID, long OtherCostID, long CostQuantityBasedID, decimal HourlyRate, decimal MakeReadyTime, decimal TimePerUnit, decimal DefaultUnitCost, string DefaultQtyType, decimal FixedQty, string VariableQty, bool IsMatrix)
        {
            return Settings.settings_costquantitybased_insert(CompanyID, OtherCostID, CostQuantityBasedID, HourlyRate, MakeReadyTime, TimePerUnit, DefaultUnitCost, DefaultQtyType, FixedQty, VariableQty, IsMatrix);
        }

        public static DataTable settings_costquantitybased_select(int CompanyID, long CostQuantityBasedID)
        {
            return Settings.settings_costquantitybased_select(CompanyID, CostQuantityBasedID);
        }

        public static long settings_costtimebased_insert(int CompanyID, long OtherCostID, long CostTimeBasedID, decimal HourlyRate, decimal MakeReadyTime, decimal HourlyRunSpeed, string DefaultHourType, decimal FixedHours, string VariableHours, string timebasetype)
        {
            return Settings.settings_costtimebased_insert(CompanyID, OtherCostID, CostTimeBasedID, HourlyRate, MakeReadyTime, HourlyRunSpeed, DefaultHourType, FixedHours, VariableHours, timebasetype);
        }

        public static DataTable settings_costtimebased_select(int CompanyID, long CostTimeBasedID)
        {
            return Settings.settings_costtimebased_select(CompanyID, CostTimeBasedID);
        }

        public static DataTable settings_costtimebased_selectall(int CompanyID)
        {
            return Settings.settings_costtimebased_selectall(CompanyID);
        }

        public static DataTable Settings_dashbaord_AllStatus(int CompanyID, string Module)
        {
            return Settings.Settings_dashbaord_AllStatus(CompanyID, Module);
        }

        public static DataTable settings_default_phrasebook_forestimate_select(int CompanyID, string phraseType)
        {
            return Settings.settings_default_phrasebook_forestimate_select(CompanyID, phraseType);
        }

        public static DataSet settings_default_phrasebook_of_outwork_header_foooter(int CompanyID, string PhraseType)
        {
            return Settings.settings_default_phrasebook_of_outwork_header_foooter(CompanyID, PhraseType);
        }

        public static DataTable settings_default_phrasebook_select(int CompanyID, string phraseType)
        {
            return Settings.settings_default_phrasebook_select(CompanyID, phraseType);
        }

        public static DataSet settings_default_phrasebook_select_header_footer(int CompanyID, string PhraseType)
        {
            return Settings.settings_default_phrasebook_select_header_footer(CompanyID, PhraseType);
        }

        public static DataTable settings_default_template_group_select(int CompanyID, long TemplateID)
        {
            return Settings.settings_default_template_group_select(CompanyID, TemplateID);
        }

        public static int settings_default_template_select(int CompanyID, string ModuleName)
        {
            return Settings.settings_default_template_select(CompanyID, ModuleName);
        }

        public static void settings_default_template_update(int CompanyID, int TemplateID, string ModuleName)
        {
            Settings.settings_default_template_update(CompanyID, TemplateID, ModuleName);
        }

        public static DataSet settings_digital_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Settings.settings_digital_press_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static void settings_digital_press_SetDefault(int CompanyID, int DigitalPressID)
        {
            Settings.settings_digital_press_SetDefault(CompanyID, DigitalPressID);
        }

        public static void settings_digitalpress_delete(int companyID, long DigitalPressID)
        {
            Settings.settings_digitalpress_delete(companyID, DigitalPressID);
        }

        public static long Settings_DigitalPress_Insert(int CompanyID, string DigitalPressName, string Description, decimal MaxImgHeight, decimal MaxImgWidth, decimal MaxSheetWeight, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, decimal SpoilageSheets, decimal RunningSpoilage, long PaperID, int PrintSheetID, int JobSizeID, long GuillotineID, decimal SetupCharge, decimal MinCharge, decimal MarkUp, string MethodName, long MethodID, bool IsBlackFlatternClick, bool IsBlackSumClick, bool IsColorFlatternClick, bool IsColorSumClick, long DigitalPressID, bool IsDefaultPress, bool CalculationType, int UnitOfMeasure)
        {
            return Settings.Settings_DigitalPress_Insert(CompanyID, DigitalPressName, Description, MaxImgHeight, MaxImgWidth, MaxSheetWeight, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, SpoilageSheets, RunningSpoilage, PaperID, PrintSheetID, JobSizeID, GuillotineID, SetupCharge, MinCharge, MarkUp, MethodName, MethodID, IsBlackFlatternClick, IsBlackSumClick, IsColorFlatternClick, IsColorSumClick, DigitalPressID, IsDefaultPress, CalculationType, UnitOfMeasure);
        }

        public static DataTable Settings_DigitalPress_Select_All(int CompanyID)
        {
            return Settings.Settings_DigitalPress_Select_All(CompanyID);
        }

        public static DataTable Settings_DigitalPress_Select_By_ID(int CompanyID, long DigitalPressID)
        {
            return Settings.Settings_DigitalPress_Select_By_ID(CompanyID, DigitalPressID);
        }

        public static int settings_EmailBody_Copy(int CompanyID, int EmailID)
        {
            return Settings.settings_EmailBody_Copy(CompanyID, EmailID);
        }

        public static void settings_EmailSetting_Email_Eprint(int CompanyID, int EmailSettingID, string EmailSettingType, string Bcc, string Cc, int UserID, bool IsSuplierRFQ_AttachAll, bool IsPurchase_AttachAll, bool IsCheckedCC, bool IsCheckedBCC, bool SupplierAttachLink, bool PurchaseAttachLink, bool AttachDeliveryNote, bool AttacheStoreFile)
        {
            Settings.settings_EmailSetting_Email_Eprint(CompanyID, EmailSettingID, EmailSettingType, Bcc, Cc, UserID, IsSuplierRFQ_AttachAll, IsPurchase_AttachAll, IsCheckedCC, IsCheckedBCC, SupplierAttachLink, PurchaseAttachLink, AttachDeliveryNote, AttacheStoreFile);
        }

        public static void settings_emailsetting_insert(int CompanyID, int EmailSettingID, string EmailSettingType, string Bcc, string Cc, int UserID, bool Checked_OtherCC, bool Checked_OtherBCC)
        {
            Settings.settings_emailsetting_insert(CompanyID, EmailSettingID, EmailSettingType, Bcc, Cc, UserID, Checked_OtherCC, Checked_OtherBCC);
        }

        public static DataTable settings_emailsetting_select(int CompanyID, int UserID)
        {
            return Settings.settings_emailsetting_select(CompanyID, UserID);
        }

        public static void settings_estimatestatus_delete(int companyID, int statusID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID
            };
            Settings.settings_estimatestatus_delete(settingsItem);
        }

        public static void settings_DeliveryCost_delete(int companyID, int DeliveryCostID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                DeliveryCostID = DeliveryCostID
            };
            Settings.settings_DeliveryCost_delete(settingsItem);
        }

        public static void settings_MIS_DeliveryCost_delete(int companyID, int DeliveryCostID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                DeliveryCostID = DeliveryCostID
            };
            Settings.settings_MIS_DeliveryCost_delete(settingsItem);
        }

        public static int settings_estimatestatus_delete_check_all_module(int companyID, int statusID, string statusTitle)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID,
                StatusTitle = statusTitle
            };
            return Settings.settings_estimatestatus_delete_check_all_module(settingsItem);
        }

        public static int settings_estimatestatus_insert(int companyID, string statusTitle, int isdefault)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusTitle = statusTitle,
                isdefault = isdefault
            };
            return Settings.settings_estimatestatus_insert(settingsItem);
        }

        public static int settings_estimatestatus_insert_new(int CompanyID, string StatusTitle, int estimate, int job, int invoice, int purchase, int delivery, int orders, int estimateDefault, int jobDefault, int invoiceDefault, int purchaseDefault, int deliveryDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability, string code)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_estimatestatus_insert_new(CompanyID, StatusTitle, estimate, job, invoice, purchase, delivery, orders, estimateDefault, jobDefault, invoiceDefault, purchaseDefault, deliveryDefault, ordersDefault, isdefault, UserFriendlyName, Probability,code);
        }

        public static int settings_DeliveryCost_insert_new(int CompanyID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_DeliveryCost_insert_new(CompanyID, DeliveryCostTitle, Type, Formula, FromShipEngine, FromOtherStore, AccountID);
        }

        public static int settings_MIS_DeliveryCost_insert_new(int CompanyID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_MIS_DeliveryCost_insert_new(CompanyID, DeliveryCostTitle, Type, Formula, FromShipEngine, FromOtherStore, AccountID);
        }

        public static int settings_estimatestatus_insert_new_proof(int CompanyID, string StatusTitle, int estimate, int job, int invoice, int purchase, int delivery,int proof, int orders, int estimateDefault, int jobDefault, int invoiceDefault, int purchaseDefault, int deliveryDefault,int proofDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability, string code)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_estimatestatus_insert_new_proof(CompanyID, StatusTitle, estimate, job, invoice, purchase, delivery,proof, orders, estimateDefault, jobDefault, invoiceDefault, purchaseDefault, deliveryDefault,proofDefault, ordersDefault, isdefault, UserFriendlyName, Probability, code);
        }

        public static DataTable settings_estimatestatus_moduletype_select(int CompanyID, string cond)
        {
            return Settings.settings_estimatestatus_moduletype_select(CompanyID, cond);
        }

        public static DataTable settings_estimatestatus_moduletype_select_new(int CompanyID, string cond)
        {
            return Settings.settings_estimatestatus_moduletype_select_new(CompanyID, cond);
        }

        public static void settings_estimatestatus_order_number_update(int CompanyID, int StatusID, int OrderNumber)
        {
            Settings.settings_estimatestatus_order_number_update(CompanyID, StatusID, OrderNumber);
        }

        public static DataTable settings_estimatestatus_select(int CompanyID)
        {
            return Settings.settings_estimatestatus_select(CompanyID);
        }

        public static DataTable settings_estimatestatus_select_new(int CompanyID, string type)
        {
            return Settings.settings_estimatestatus_select_new(CompanyID, type);
        }

        public static string settings_estimatestatus_sortalpha_select(int CompanyID)
        {
            return Settings.settings_estimatestatus_sortalpha_select(CompanyID);
        }

        public static void settings_estimatestatus_sortalpha_update(int CompanyID, int StatusID, string cond)
        {
            Settings.settings_estimatestatus_sortalpha_update(CompanyID, StatusID, cond);
        }

        public static int settings_estimatestatus_update(int companyID, int statusID, string statusTitle)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                StatusID = statusID,
                StatusTitle = statusTitle
            };
            return Settings.settings_estimatestatus_update(settingsItem);
        }

        public static int settings_estimatestatus_update_new(int CompanyID, int StatusID, string StatusTitle, int Estimate, int Job, int Invoice, int Purchase, int Delivery, int orders, int EstimateDefault, int JobDefault, int InvoiceDefault, int PurchaseDefault, int DeliveryDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability,string code)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_estimatestatus_update_new(CompanyID, StatusID, StatusTitle, Estimate, Job, Invoice, Purchase, Delivery, orders, EstimateDefault, JobDefault, InvoiceDefault, PurchaseDefault, DeliveryDefault, ordersDefault, isdefault, UserFriendlyName, Probability,code);
        }

        public static int settings_DeliveryCost_update_new(int CompanyID, int DeliveryCostID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_DeliveryCost_update_new(CompanyID, DeliveryCostID, DeliveryCostTitle, Type, Formula, FromShipEngine, FromOtherStore, AccountID);
        }

        public static int settings_MIS_DeliveryCost_update_new(int CompanyID, int DeliveryCostID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_MIS_DeliveryCost_update_new(CompanyID, DeliveryCostID, DeliveryCostTitle, Type, Formula, FromShipEngine, FromOtherStore, AccountID);
        }

        public static int settings_estimatestatus_update_new_proof(int CompanyID, int StatusID, string StatusTitle, int Estimate, int Job, int Invoice, int Purchase, int Delivery,int Proof, int orders, int EstimateDefault, int JobDefault, int InvoiceDefault, int PurchaseDefault, int DeliveryDefault,int ProofDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability, string code)
        {
            SettingsItem settingsItem = new SettingsItem();
            return Settings.settings_estimatestatus_update_new_proof(CompanyID, StatusID, StatusTitle, Estimate, Job, Invoice, Purchase, Delivery,Proof, orders, EstimateDefault, JobDefault, InvoiceDefault, PurchaseDefault, DeliveryDefault,ProofDefault, ordersDefault, isdefault, UserFriendlyName, Probability, code);
        }

        public static DataTable settings_eStore_Orders(int CompanyID)
        {
            return Settings.settings_eStore_Orders(CompanyID);
        }

        public static DataTable settings_Delivery_Costs(int CompanyID, int AccountID)
        {
            return Settings.settings_Delivery_Costs(CompanyID, AccountID);
        }

        public static DataTable OtherStore_Delivery_Costs(int CompanyID, int AccountID)
        {
            return Settings.OtherStore_Delivery_Costs(CompanyID, AccountID);
        }

        public static DataTable settings_MIS_Delivery_Costs(int CompanyID)
        {
            return Settings.settings_MIS_Delivery_Costs(CompanyID);
        }

        public static DataTable settings_MIS_Delivery_Cost_Selector(int CompanyID)
        {
            return Settings.settings_MIS_Delivery_Cost_Selector(CompanyID);
        }

        public static string Settings_fromemail_get(int CompanyID)
        {
            return Settings.Settings_fromemail_get(CompanyID);
        }

        public static void Settings_fromemail_save(int CompanyID, string FromEmail)
        {
            Settings.Settings_fromemail_save(CompanyID, FromEmail);
        }

        public static string settings_getDateondateformat(int CompanyID, string Date, string DateType)
        {
            return Settings.settings_getDateondateformat(CompanyID, Date, DateType);
        }

        public static void Settings_Guillotine_Delete(int CompanyID, long GuillotineID)
        {
            Settings.Settings_Guillotine_Delete(CompanyID, GuillotineID);
        }

        public static int Settings_Guillotine_Insert(int CompanyID, string GuillotineName, string Description, decimal MinSheetHeight, decimal MinSheetWidth, decimal MaxSheetHeight, decimal MaxSheetWidth, decimal MaxSheetWeight, decimal SetUpCharge, decimal CostPerCut, decimal MinCharge, decimal MarkUp, decimal PaperWeight1, decimal MaxSheets1, decimal PaperWeight2, decimal MaxSheets2, decimal PaperWeight3, decimal MaxSheets3, long GuillotineID, bool DefaultFirstTrim, bool DefaultSecondTrim, bool IsLarge, int JobCut,string Guillotinetype,string calculationType)
        {
            return Settings.Settings_Guillotine_Insert(CompanyID, GuillotineName, Description, MinSheetHeight, MinSheetWidth, MaxSheetHeight, MaxSheetWidth, MaxSheetWeight, SetUpCharge, CostPerCut, MinCharge, MarkUp, PaperWeight1, MaxSheets1, PaperWeight2, MaxSheets2, PaperWeight3, MaxSheets3, GuillotineID, DefaultFirstTrim, DefaultSecondTrim, IsLarge, JobCut, Guillotinetype,calculationType);
        }

        public static DataSet settings_guillotine_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string IsForLarge)
        {
            return Settings.settings_guillotine_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, IsForLarge);
        }

        public static DataTable Settings_Guillotine_PageText_New(int CompanyID, string IsLarge)
        {
            return Settings.Settings_Guillotine_PageText_New(CompanyID, IsLarge);
        }

        public static DataTable Settings_Guillotine_Select_All(int CompanyID)
        {
            return Settings.Settings_Guillotine_Select_All(CompanyID);
        }

        public static DataTable Settings_Guillotine_Select_By_ID(int CompanyID, long GuillotineID)
        {
            return Settings.Settings_Guillotine_Select_By_ID(CompanyID, GuillotineID);
        }

        public static void Settings_Insert_Alert_Setting(long CompanyID, long UserID, bool isShowTaskAlertonScreen, int ShowTaskAlertOnScreenTime, bool isShowCallAlertOnScreen, int ShowCallAlertOnScreenTime, bool isSendTaskAlert, int SendTaskAlertTime, bool isSendCallAlert, int SendCallAlertTime, int CreatedBy)
        {
            Settings.Settings_Insert_Alert_Setting(CompanyID, UserID, isShowTaskAlertonScreen, ShowTaskAlertOnScreenTime, isShowCallAlertOnScreen, ShowCallAlertOnScreenTime, isSendTaskAlert, SendTaskAlertTime, isSendCallAlert, SendCallAlertTime, CreatedBy);
        }

        public static void Settings_Insert_Alert_Settings(long CompanyID, long UserID, string TasksAlert, int TasksAlertMinute, string TasksAlertFor, string EventAlert, int EventAlertMinute, string EventAlertFor, string CallAlert, int CallAlertMinute, string CallAlertFor, int CreatedBy)
        {
            Settings.Settings_Insert_Alert_Settings(CompanyID, UserID, TasksAlert, TasksAlertMinute, TasksAlertFor, EventAlert, EventAlertMinute, EventAlertFor, CallAlert, CallAlertMinute, CallAlertFor, CreatedBy);
        }

        public static void Settings_Insert_CopyWidgets(int MasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int CreatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus)
        {
            Settings.Settings_Insert_CopyWidgets(MasterID, CompanyID, UserID, WidgetType, DefaultDate, ShowPrint, TitleName, WidgetName, DisplayType, GraphType, CreatedBy, ModuleName, NoOfRecords, Customizecolumns, Customerid, isSpread, TaskStatus, CompanyType, DisplayRecordSalesOf, QuarterType, FromDate, Todate, EstimateType, ShowFullScreen, ShowAllOptions, Status, ShowArchivedStatus);
        }
        public static void Settings_Insert_CopyWidgetsNew(int MasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int CreatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus,bool IsLastYearData,bool IsDailyTarget,bool IsMonthlyTarget)
        {
            Settings.Settings_Insert_CopyWidgetsNew(MasterID, CompanyID, UserID, WidgetType, DefaultDate, ShowPrint, TitleName, WidgetName, DisplayType, GraphType, CreatedBy, ModuleName, NoOfRecords, Customizecolumns, Customerid, isSpread, TaskStatus, CompanyType, DisplayRecordSalesOf, QuarterType, FromDate, Todate, EstimateType, ShowFullScreen, ShowAllOptions, Status, ShowArchivedStatus,IsLastYearData,IsDailyTarget,IsMonthlyTarget);
        }
        public static void Settings_Insert_CopyWidgets(long CopyMasterID, long CompanyID, string UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, long CreatedBy, string IsCalendarYear, string FromDate, string ToDate)
        {
            Settings.Settings_Insert_CopyWidgets(CopyMasterID, CompanyID, UserID, DateType, IncludeArchiverecords, IsDisplayWidget, Color, Title, CreatedBy, IsCalendarYear, FromDate, ToDate);
        }
        public static void Settings_Insert_CopyWidgets(long CopyMasterID, long CompanyID, int UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, long CreatedBy, string IsCalendarYear, string FromDate, string ToDate,DailyTarget dailyTarget,MonthlyTarget monthlyTarget)
        {
            Settings.Settings_Insert_CopyWidgets(CopyMasterID, CompanyID, UserID, DateType, IncludeArchiverecords, IsDisplayWidget, Color, Title, CreatedBy, IsCalendarYear, FromDate, ToDate,dailyTarget,monthlyTarget);
        }

        public static int Settings_inventoryStockReduction_insert_update(long CompanyID, string StockReduces, int JobStatusChange, string CancelledJob, int StatusMsg)
        {
            return Settings.Settings_inventoryStockReduction_insert_update(CompanyID, StockReduces, JobStatusChange, CancelledJob, StatusMsg);
        }

        public static DataTable Settings_inventoryStockReduction_Select(long CompanyID)
        {
            return Settings.Settings_inventoryStockReduction_Select(CompanyID);
        }

        public static long settings_itemdescription_insert(int CompanyID, long ItemDescriptionID, string EstimateType, string DatabaseFieldName, string ScreenName, bool IsChecked,int DisplayOrder)
        {
            return Settings.settings_itemdescription_insert(CompanyID, ItemDescriptionID, EstimateType, DatabaseFieldName, ScreenName, IsChecked, DisplayOrder);
        }

        public static string settings_itemdescription_select(int CompanyID, string EstimateType)
        {
            return Settings.settings_itemdescription_select(CompanyID, EstimateType);
        }

        public static string settings_itemdescription_selectall(int CompanyID)
        {
            return Settings.settings_itemdescription_selectall(CompanyID);
        }

        public static DataTable settings_itemdescriptionNew_select(int companyid, string EstType)
        {
            return Settings.settings_itemdescriptionNew_select(companyid, EstType);
        }
        public static DataTable settings_items_delivery_note_select(int CompanyID, long DeliveryID)
        {
            return Settings.settings_items_delivery_note_select(CompanyID, DeliveryID);
        }

        public static void settings_itemtitle_delete(int companyID, int itemTitleID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                ItemTitleID = itemTitleID
            };
            Settings.settings_itemtitle_delete(settingsItem);
        }

        public static int settings_itemtitle_insert(int companyID, string itemTitle)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                ItemTitle = itemTitle
            };
            return Settings.settings_itemtitle_insert(settingsItem);
        }

        public static DataTable settings_itemtitle_select(int CompanyID)
        {
            return Settings.settings_itemtitle_select(CompanyID);
        }

        public static int settings_itemtitle_update(int companyID, int itemTitleID, string itemTitle)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                ItemTitleID = itemTitleID,
                ItemTitle = itemTitle
            };
            return Settings.settings_itemtitle_update(settingsItem);
        }

        public static void settings_jobcardsettings_itemdescription_update(int CompanyID, string Data)
        {
            Settings.settings_jobcardsettings_itemdescription_update(CompanyID, Data);
        }

        public static DataTable settings_languages_select(int companyID)
        {
            return Settings.settings_languages_select(companyID);
        }

        public static DataSet settings_largeformat_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Settings.settings_largeformat_press_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static void settings_largeformat_press_SetDefault(int CompanyID, int PressID)
        {
            Settings.settings_largeformat_press_SetDefault(CompanyID, PressID);
        }

        public static void Settings_LargeFormate_Delete(int CompanyID, long LargeFormatPressID)
        {
            Settings.Settings_LargeFormate_Delete(CompanyID, LargeFormatPressID);
        }

        public static long Settings_LargeFormate_Insert(int CompanyID, string PressName, string Description, decimal MinWebWidth, decimal MaxWebWidth, decimal MaxSheetWidth, string GripSideOrientation, decimal GripDepth, decimal GutterDepth, string PaperType, decimal SetUpSpoilage, string SpoilageInTerms, decimal RunningSpoilage, int PaperSizeID, int SheetSizeID, int JobSizeID, int GuillotineID, bool IsPerfecting, decimal SetupCharge, decimal MinRunningCharge, decimal Markup, decimal PrintPerHourLow, decimal PrintPerHourMedium, decimal PrintPerHourHigh, decimal PerHourCharge, decimal CoverageSide1, decimal CoverageSide2, bool IsDefaultPress, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, string InkType, int UnitOfMeasure, long Material2, long Material3, long Material4, long Material5, decimal WhiteInkCoverageSide1, decimal WhiteInkCoverageSide2, bool isFullSheet, string CalculationType, decimal SetUpSpoilage_Sqm)
        {
            return Settings.Settings_LargeFormate_Insert(CompanyID, PressName, Description, MinWebWidth, MaxWebWidth, MaxSheetWidth, GripSideOrientation, GripDepth, GutterDepth, PaperType, SetUpSpoilage, SpoilageInTerms, RunningSpoilage, PaperSizeID, SheetSizeID, JobSizeID, GuillotineID, IsPerfecting, SetupCharge, MinRunningCharge, Markup, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, PerHourCharge, CoverageSide1, CoverageSide2, IsDefaultPress, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, InkType, UnitOfMeasure, Material2, Material3, Material4, Material5, WhiteInkCoverageSide1, WhiteInkCoverageSide2, isFullSheet, CalculationType,SetUpSpoilage_Sqm);
        }

        public static void Settings_LargeFormate_Insert_ink_insert(int CompanyID, long LargeFormatPressID, int InkID, bool IswhiteInk)
        {
            Settings.Settings_LargeFormate_Insert_ink_insert(CompanyID, LargeFormatPressID, InkID, IswhiteInk);
        }

        public static IDataReader Settings_LargeFormate_Insert_ink_update(int CompanyID, long LargeFormatPressID, bool IswhiteInk)
        {
            return Settings.Settings_LargeFormate_Insert_ink_update(CompanyID, LargeFormatPressID, IswhiteInk);
        }

        public static IDataReader Settings_LargeFormate_Select(int CompanyID, long LargeFormatPressID)
        {
            return Settings.Settings_LargeFormate_Select(CompanyID, LargeFormatPressID);
        }

        public static int Settings_LargeFormate_Update(int CompanyID, long LargeFormatPressID, string PressName, string Description, decimal MinWebWidth, decimal MaxWebWidth, decimal MaxSheetWidth, string GripSideOrientation, decimal GripDepth, decimal GutterDepth, string PaperType, decimal SetUpSpoilage, decimal RunningSpoilage, int PaperSizeID, int SheetSizeID, int JobSizeID, int GuillotineID, bool IsPerfecting, decimal SetupCharge, decimal MinRunningCharge, decimal Markup, decimal PrintPerHourLow, decimal PrintPerHourMedium, decimal PrintPerHourHigh, decimal PerHourCharge, decimal CoverageSide1, decimal CoverageSide2, bool IsDefaultPress, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, string InkType, int UnitOfMeasure, long Material2, long Material3, long Material4, long Material5, decimal WhiteInkCoverageSide1, decimal WhiteInkCoverageSide2, bool isFullSheet, decimal SetUpSpoilage_Sqm)
        {
            return Settings.Settings_LargeFormate_Update(CompanyID, LargeFormatPressID, PressName, Description, MinWebWidth, MaxWebWidth, MaxSheetWidth, GripSideOrientation, GripDepth, GutterDepth, PaperType, SetUpSpoilage, RunningSpoilage, PaperSizeID, SheetSizeID, JobSizeID, GuillotineID, IsPerfecting, SetupCharge, MinRunningCharge, Markup, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, PerHourCharge, CoverageSide1, CoverageSide2, IsDefaultPress, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, InkType, UnitOfMeasure, Material2, Material3, Material4, Material5, WhiteInkCoverageSide1, WhiteInkCoverageSide2, isFullSheet,SetUpSpoilage_Sqm);
        }

        public static void Settings_LargeFormate_update_ink_Delete(int CompanyID, long LargeFormatPressID, int InkID)
        {
            Settings.Settings_LargeFormate_update_ink_Delete(CompanyID, LargeFormatPressID, InkID);
        }

        public static void Settings_LargeFormate_update_ink_update(int CompanyID, long LargeFormatPressID, int InkID, bool IswhiteInk)
        {
            Settings.Settings_LargeFormate_update_ink_update(CompanyID, LargeFormatPressID, InkID, IswhiteInk);
        }

        public static void Settings_Litho_Insert_ink_insert(int CompanyID, long LithoPressID, int InkID)
        {
            Settings.Settings_Litho_Insert_ink_insert(CompanyID, LithoPressID, InkID);
        }

        public static void settings_Litho_press_matrix_insert(int CompanyID, long pressID, decimal GSM, decimal sheet, decimal sheetsperhour)
        {
            Settings.settings_Litho_press_matrix_insert(CompanyID, pressID, GSM, sheet, sheetsperhour);
        }

        public static void settings_Litho_press_matrix_update(int CompanyID, long pressID)
        {
            Settings.settings_Litho_press_matrix_update(CompanyID, pressID);
        }

        public static DataSet settings_litho_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Settings.settings_litho_press_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static void settings_litho_press_SetDefault(int CompanyID, int LithoPressID)
        {
            Settings.settings_litho_press_SetDefault(CompanyID, LithoPressID);
        }

        public static void settings_lithopress_delete(int companyID, long LithoPressID)
        {
            Settings.settings_lithopress_delete(companyID, LithoPressID);
        }

        public static long Settings_LithoPress_Insert(int CompanyID, string LithoPressName, string Description, decimal MaxImgHeight, decimal MaxImgWidth, decimal MaxSheetWeight, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, decimal SpoilageSheets, decimal RunningSpoilage, long PaperID, int PrintSheetID, int JobSizeID, long GuillotineID, decimal SetupCharge, decimal MinCharge, decimal MarkUp, long PlateID, decimal MakeReadyPerPlate, bool MakeReadyPerPlateCheck, decimal WashupChargePerColour, bool WashupChargePerColourCheck, string MethodName, decimal HourlyChargeRate, string ColourUnits, string DefaultColour, decimal DefaultInkCoverageSide, string InkType, bool IsDefaultPress, long LithoPressID, int UnitOfMeasure, decimal SetupChargeWork_n_Turn, decimal SetupChargeWork_n_Tumble, decimal MakeReadyWork_n_Turn, decimal MakeReadyWork_n_Tumble, bool isPerfect)
        {
            return Settings.Settings_LithoPress_Insert(CompanyID, LithoPressName, Description, MaxImgHeight, MaxImgWidth, MaxSheetWeight, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, SpoilageSheets, RunningSpoilage, PaperID, PrintSheetID, JobSizeID, GuillotineID, SetupCharge, MinCharge, MarkUp, PlateID, MakeReadyPerPlate, MakeReadyPerPlateCheck, WashupChargePerColour, WashupChargePerColourCheck, MethodName, HourlyChargeRate, ColourUnits, DefaultColour, DefaultInkCoverageSide, InkType, IsDefaultPress, LithoPressID, UnitOfMeasure, SetupChargeWork_n_Turn, SetupChargeWork_n_Tumble, MakeReadyWork_n_Turn, MakeReadyWork_n_Tumble, isPerfect);
        }

        public static DataTable Settings_LithoPress_Select_By_ID(int CompanyID, long LithoPressID)
        {
            return Settings.Settings_LithoPress_Select_By_ID(CompanyID, LithoPressID);
        }

        public static IDataReader settings_lithopress_select_ink(int CompanyID, long LithoPressID)
        {
            return Settings.settings_lithopress_select_ink(CompanyID, LithoPressID);
        }

        public static IDataReader settings_lithopress_select_ink_rownum(int CompanyID, long LithoPressID, int rownum)
        {
            return Settings.settings_lithopress_select_ink_rownum(CompanyID, LithoPressID, rownum);
        }

        public static void Settings_lithopress_update_ink_Delete(int CompanyID, long LithoPressID, int InkID)
        {
            Settings.Settings_lithopress_update_ink_Delete(CompanyID, LithoPressID, InkID);
        }

        public static DataTable Settings_LithoPressMatrix_Select_By_ID(int CompanyID, long LithoPressID)
        {
            return Settings.Settings_LithoPressMatrix_Select_By_ID(CompanyID, LithoPressID);
        }

        public static void settings_managecampaign_delete(long ManageID)
        {
            Settings.settings_managecampaign_delete(new SettingsItem()
            {
                ManageID = ManageID
            });
        }

        public static void settings_markup_delete(int companyID, int markupID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                MarkupID = markupID
            };
            Settings.settings_markup_delete(settingsItem);
        }

        public static DataTable settings_markup_for_printbroker_select(int CompanyID)
        {
            return Settings.settings_markup_for_printbroker_select(CompanyID);
        }

        public static int settings_markup_insert(int companyID, string markupName, decimal markupRate)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                MarkupName = markupName,
                MarkupRate = markupRate
            };
            return Settings.settings_markup_insert(settingsItem);
        }

        public static DataTable settings_markup_rate_selectall(int CompanyID)
        {
            return Settings.settings_markup_rate_selectall(CompanyID);
        }

        public static DataTable settings_markup_select(int CompanyID, int MarkupID)
        {
            return Settings.settings_markup_select(CompanyID, MarkupID);
        }

        public static DataTable settings_markup_selectall(int CompanyID)
        {
            return Settings.settings_markup_selectall(CompanyID);
        }

        public static int settings_markup_update(int companyID, int markupID, string markupName, decimal markupRate)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                MarkupID = markupID,
                MarkupName = markupName,
                MarkupRate = markupRate
            };
            return Settings.settings_markup_update(settingsItem);
        }

        public static DataSet Settings_MasterWidget_Select_ByMasterID(int MasterID)
        {
            return Settings.Settings_MasterWidget_Select_ByMasterID(MasterID);
        }

        public static void Settings_MiniCopyWidget_delete(int CopyMasterID, int CompanyID)
        {
            Settings.Settings_MiniCopyWidget_delete(CopyMasterID, CompanyID);
        }

        public static DataSet Settings_MiniMasterWidget_Select_ByMasterID(int MasterID)
        {
            return Settings.Settings_MiniMasterWidget_Select_ByMasterID(MasterID);
        }

        public static void settings_number_insert(int CompanyID, int Estimate, int Jobs, int Invoices, int Purchases, int Delivery, char Type, int Order, string NumberingType, string IpAddress, string NumberingChangeHistory, int Account)
        {
            Settings.settings_number_insert(CompanyID, Estimate, Jobs, Invoices, Purchases, Delivery, Type, Order, NumberingType, IpAddress, NumberingChangeHistory, Account);
        }

        public static IDataReader settings_number_select(int CompanyID)
        {
            return Settings.settings_number_select(CompanyID);
        }

        public static DataTable settings_number_select1(int companyID)
        {
            return Settings.settings_number_select1(companyID);
        }

        public static DataTable settings_OrderingProcess_select(int CompanyID, int AccountID)
        {
            return Settings.settings_OrderingProcess_select(CompanyID, AccountID);
        }

        public static string settings_otherCost_category_sortalpha_select(int CompanyID)
        {
            return Settings.settings_otherCost_category_sortalpha_select(CompanyID);
        }

        public static void settings_otherCost_category_sortalpha_update(int CompanyID, int FieldID, string cond)
        {
            Settings.settings_otherCost_category_sortalpha_update(CompanyID, FieldID, cond);
        }

        public static int settings_othercost_categoryduplicacy_check(int CompanyID, string OtherCostCategoryName, long OtherCostCategoryID)
        {
            return Settings.settings_othercost_categoryduplicacy_check(CompanyID, OtherCostCategoryName, OtherCostCategoryID);
        }

        public static long settings_OtherCost_Copy(int CompanyID, long OtherCostID)
        {
            return Settings.settings_OtherCost_Copy(CompanyID, OtherCostID);
        }

        public static void settings_othercost_delete(int CompanyID, long OtherCostID)
        {
            Settings.settings_othercost_delete(CompanyID, OtherCostID);
        }

        public static DataSet settings_othercost_formulatag_select(int CompanyID)
        {
            return Settings.settings_othercost_formulatag_select(CompanyID);
        }

        public static long settings_othercost_insert(long OtherCostID, int CompanyID, string OtherCostName, string Description, long OtherCostCategoryID, string CalculationType, long CostTimeBasedID, int SupplierID, decimal PerHourCost, decimal Profit, decimal Minimum, string Formula)
        {
            return Settings.settings_othercost_insert(OtherCostID, CompanyID, OtherCostName, Description, OtherCostCategoryID, CalculationType, CostTimeBasedID, SupplierID, PerHourCost, Profit, Minimum, Formula);
        }

        public static int settings_othercost_matrix_insert(long OtherCostID, string CalculationType, string Column1, string Column2, string Column3, string Column4, string Column5, string Column6, string Column7, string Column8, string Column9, string Column10, string Prompt)
        {
            return Settings.settings_othercost_matrix_insert(OtherCostID, CalculationType, Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Prompt);
        }

        public static DataTable settings_othercost_matrix_select(int CompanyID, long OtherCostID)
        {
            return Settings.settings_othercost_matrix_select(CompanyID, OtherCostID);
        }

        public static void settings_othercost_matrix_update(int MatrixHeadingID, string CalculationType, string Column1, string Column2, string Column3, string Column4, string Column5, string Column6, string Column7, string Column8, string Column9, string Column10, string Prompt)
        {
            Settings.settings_othercost_matrix_update(MatrixHeadingID, CalculationType, Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Prompt);
        }

        public static void settings_othercost_matrix_value_insert(int MatrixID, int From, int To, decimal Col1Value, decimal Col2Value, decimal Col3Value, decimal Col4Value, decimal Col5Value, decimal Col6Value, decimal Col7Value, decimal Col8Value, decimal Col9Value, decimal Col10Value)
        {
            Settings.settings_othercost_matrix_value_insert(MatrixID, From, To, Col1Value, Col2Value, Col3Value, Col4Value, Col5Value, Col6Value, Col7Value, Col8Value, Col9Value, Col10Value);
        }

        public static DataTable settings_othercost_matrix_value_select(int CompanyID, int MatrixHeadingID)
        {
            return Settings.settings_othercost_matrix_value_select(CompanyID, MatrixHeadingID);
        }

        public static void settings_othercost_matrix_value_update(int MatrixValueID, int From, int To, decimal Col1Value, decimal Col2Value, decimal Col3Value, decimal Col4Value, decimal Col5Value, decimal Col6Value, decimal Col7Value, decimal Col8Value, decimal Col9Value, decimal Col10Value)
        {
            Settings.settings_othercost_matrix_value_update(MatrixValueID, From, To, Col1Value, Col2Value, Col3Value, Col4Value, Col5Value, Col6Value, Col7Value, Col8Value, Col9Value, Col10Value);
        }

        public static DataSet settings_othercost_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int OthercostCategoryid)
        {
            return Settings.settings_othercost_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, OthercostCategoryid);
        }

        public static DataTable settings_othercost_select(int CompanyID, long OtherCostID)
        {
            return Settings.settings_othercost_select(CompanyID, OtherCostID);
        }

        public static DataTable settings_othercost_selectall(int CompanyID)
        {
            return Settings.settings_othercost_selectall(CompanyID);
        }

        public static DataSet settings_othercost_View(int CompanyID, int OtherCostCategoryID)
        {
            return Settings.settings_othercost_View(CompanyID, OtherCostCategoryID);
        }

        public static void settings_othercostcategory_delete(int CompanyID, long otherCostCategoryID)
        {
            Settings.settings_othercostcategory_delete(CompanyID, otherCostCategoryID);
        }

        public static int settings_othercostcategory_insert(int companyID, long otherCostCategoryID, string otherCostCategoryName, int preStatus, string JobcardCategory)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                OtherCostCategoryID = otherCostCategoryID,
                OtherCostCategoryName = otherCostCategoryName,
                StatusID = preStatus,
                JobcardCategory = JobcardCategory
            };
            return Settings.settings_othercostcategory_insert(settingsItem);
        }

        public static DataTable settings_othercostcategory_select(int companyID, long otherCostCategoryID)
        {
            return Settings.settings_othercostcategory_select(companyID, otherCostCategoryID);
        }

        public static DataTable settings_othercostcategory_selectall(int companyID)
        {
            return Settings.settings_othercostcategory_selectall(companyID);
        }

        public static DataTable settings_othercostcategory_selectall_new(int companyID)
        {
            return Settings.settings_othercostcategory_selectall_new(companyID);
        }

        public static int settings_othercostduplicacy_check(int CompanyID, string OtherCostName, long OtherCostID)
        {
            return Settings.settings_othercostduplicacy_check(CompanyID, OtherCostName, OtherCostID);
        }

        public static void settings_OtherSettings_insert_update(int CompanyID, string JobName, string DatabaseFieldName)
        {
            Settings.settings_OtherSettings_insert_update(CompanyID, JobName, DatabaseFieldName);
        }

        public static DataTable settings_othersettings_select(int CompanyID)
        {
            return Settings.settings_othersettings_select(CompanyID);
        }

        public static void settings_papersize_delete(int companyID, int PaperSizeID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PaperSizeID = PaperSizeID
            };
            Settings.settings_papersize_delete(settingsItem);
        }

        public static int settings_papersize_insert(int companyID, string PaperSizeName, decimal Height, decimal Width)
        {
            BaseClass baseClass = new BaseClass();
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PaperSizeName = baseClass.SpecialEncode(PaperSizeName),
                Height = Height,
                Width = Width
            };
            return Settings.settings_papersize_insert(settingsItem);
        }

        public static void settings_papersize_ordernumber_update(int CompanyID, int PaperSizeID, int OrderNumber)
        {
            Settings.settings_papersize_ordernumber_update(CompanyID, PaperSizeID, OrderNumber);
        }

        public static DataTable settings_papersize_select(int companyID, int paperSizeID)
        {
            return Settings.settings_papersize_select(companyID, paperSizeID);
        }

        public static DataTable settings_papersize_selectall(int companyID)
        {
            return Settings.settings_papersize_selectall(companyID);
        }

        public static int settings_papersize_update(int companyID, int PaperSizeID, string PaperSizeName, decimal Height, decimal Width)
        {
            BaseClass baseClass = new BaseClass();
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PaperSizeID = PaperSizeID,
                PaperSizeName = baseClass.SpecialEncode(PaperSizeName),
                Height = Height,
                Width = Width
            };
            return Settings.settings_papersize_update(settingsItem);
        }

        public static void settings_PaperSize_update(int CompanyID, int OrderNumber, int PapaersizeID)
        {
            Settings.settings_PaperSize_update(CompanyID, OrderNumber, PapaersizeID);
        }

        public static string settings_papersizename_select(int CompanyID, int PaperSizeID)
        {
            return Settings.settings_papersizename_select(CompanyID, PaperSizeID);
        }

        public static DataTable settings_PaymentTerms_SetDefault(int CompanyID)
        {
            return Settings.settings_PaymentTerms_SetDefault(CompanyID);
        }

        public static DataTable settings_PaymentValue_select(long CompanyID)
        {
            return Settings.settings_PaymentValue_select(CompanyID);
        }

        public static void settings_phrasebook_delete(int companyID, int phraseBookID, string phraseType)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PhraseBookID = phraseBookID,
                PhraseType = phraseType
            };
            Settings.settings_phrasebook_delete(settingsItem);
        }

        public static DataTable settings_phrasebook_footersignature_select(int CompanyID)
        {
            return Settings.settings_phrasebook_footersignature_select(CompanyID);
        }

        public static void settings_phrasebook_insert(int companyID, string phraseType, string phraseText, bool isDefaultPhrase, string emailTemplateName, string emailTemplateType)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                IsDefaultPhrase = isDefaultPhrase,
                EmailTemplateName = emailTemplateName,
                EmailTemplateType = emailTemplateType
            };
            Settings.settings_phrasebook_insert(settingsItem);
        }

        public static void settings_phrasebook_insert_drpdn(int companyID, string phraseType, string phraseText, bool isDefaultPhrase, string Title, string Type, string emailTemplateName, string emailTemplateType, string LineSeparator, string LabelSeparator)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                IsDefaultPhrase = isDefaultPhrase,
                Type = Type,
                Title = Title,
                EmailTemplateName = emailTemplateName,
                EmailTemplateType = emailTemplateType
            };
            Settings.settings_phrasebook_insert_drpdn(settingsItem, LineSeparator, LabelSeparator);
        }

        public static DataTable settings_phrasebook_select(int CompanyID, string phraseType)
        {
            return Settings.settings_phrasebook_select(CompanyID, phraseType);
        }

        public static void settings_phrasebook_update(int companyID, int phraseBookID, string phraseType, string phraseText, bool isDefaultPhrase, string emailTemplateName, string emailTemplateType)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PhraseBookID = phraseBookID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                IsDefaultPhrase = isDefaultPhrase,
                EmailTemplateName = emailTemplateName,
                EmailTemplateType = emailTemplateType
            };
            Settings.settings_phrasebook_update(settingsItem);
        }

        public static void settings_phrasebook_update_drpdn(int companyID, int phraseBookID, string phraseType, string phraseText, bool isDefaultPhrase, string Title, string Type, string emailTemplateName, string emailTemplateType, string LineSeparator, string LabelSeparator)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                PhraseBookID = phraseBookID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                Type = Type,
                Title = Title,
                IsDefaultPhrase = isDefaultPhrase,
                EmailTemplateName = emailTemplateName,
                EmailTemplateType = emailTemplateType
            };
            Settings.settings_phrasebook_update_drpdn(settingsItem, LineSeparator, LabelSeparator);
        }

        public static int settings_plantpressduplicacy_check(int CompanyID, string PlantPressType, string PlantPressName, long PlantpressID)
        {
            return Settings.settings_plantpressduplicacy_check(CompanyID, PlantPressType, PlantPressName, PlantpressID);
        }

        public static void settings_PO_DeliveryAdrress_insertupdate(SettingsItem item)
        {
            Settings.settings_PO_DeliveryAdrress_insertupdate(item);
        }

        public static DataTable settings_PODeliveryAddress_select(int CompanyID)
        {
            return Settings.settings_PODeliveryAddress_select(CompanyID);
        }

        public static void Settings_PreFlightOptions_InsertUpdate(int ProfileId, string Type, int TypeId, bool IsEnabled)
        {
            Settings.Settings_PreFlightOptions_InsertUpdate(ProfileId, Type, TypeId, IsEnabled);
        }

        public static void settings_preFlightProfile_delete(long preflightID)
        {
            Settings.settings_preFlightProfile_delete(preflightID);
        }

        public static DataTable settings_PressName_select(int CompanyID)
        {
            return Settings.settings_PressName_select(CompanyID);
        }

        public static int settings_price_catalogue_chkexsisting(int CompanyID, int PriceCatalogueid, string itemcode)
        {
            return Settings.settings_price_catalogue_chkexsisting(CompanyID, PriceCatalogueid, itemcode);
        }

        public static void settings_price_catalogue_customer_insert(int CompanyID, string SqlData)
        {
            Settings.settings_price_catalogue_customer_insert(CompanyID, SqlData);
        }

        public static int settings_price_catalogue_insert(int CompanyID, int PriceCatalogueID, string itemcode, string CategoryName, string CatalogueName, string Description, int PriceCatalogueCategoryID, string ItemTitle, string Artwork, string Color, string Size, string Material, string Delivery, string Finishing, string Notes, string Terms, string MatrixType, string CustomerType, string Proofs, string Packing, int UnitOfMeasure)
        {
            return Settings.settings_price_catalogue_insert(CompanyID, PriceCatalogueID, itemcode, CategoryName, CatalogueName, Description, PriceCatalogueCategoryID, ItemTitle, Artwork, Color, Size, Material, Delivery, Finishing, Notes, Terms, MatrixType, CustomerType, Proofs, Packing, UnitOfMeasure);
        }

        public static DataSet settings_price_catalogue_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int PriceCatalogueCategoryid)
        {
            return Settings.settings_price_catalogue_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, PriceCatalogueCategoryid);
        }

        public static void settings_price_catalogue_properties_delete(int PriceCatalogueID)
        {
            Settings.settings_price_catalogue_properties_delete(PriceCatalogueID);
        }

        public static void settings_price_catalogue_properties_deleteAll(int CompanyID, int PriceCatalogueID)
        {
            Settings.settings_price_catalogue_properties_deleteAll(CompanyID, PriceCatalogueID);
        }

        public static int settings_price_catalogue_properties_insert(int CompanyID, int PriceCatalogueID, int FromQuantity, int ToQuantity, decimal Price, decimal Markup, decimal SellingPrice)
        {
            return Settings.settings_price_catalogue_properties_insert(CompanyID, PriceCatalogueID, FromQuantity, ToQuantity, Price, Markup, SellingPrice);
        }

        public static DataTable settings_price_catalogue_select(int CompanyID)
        {
            return Settings.settings_price_catalogue_select(CompanyID);
        }

        public static DataSet settings_price_catalogue_selectByID(int CompanyID, int PriceCatalogueID)
        {
            return Settings.settings_price_catalogue_selectByID(CompanyID, PriceCatalogueID);
        }

        public static void Settings_ReferedBy_Isdelete_Update(int ReferencedID, int CompanyID)
        {
            Settings.Settings_ReferedBy_Isdelete_Update(ReferencedID, CompanyID);
        }

        public static DataTable settings_RefferceBy_SetDefault(int CompanyID)
        {
            return Settings.settings_RefferceBy_SetDefault(CompanyID);
        }

        public static int settings_regionalsettings_insert(SettingsItem item)
        {
            return Settings.settings_regionalsettings_insert(item);
        }

        public static DataTable settings_regionalsettings_select(int CompanyID)
        {
            return Settings.settings_regionalsettings_select(CompanyID);
        }

        public static string settings_regionalsettings_select_by_type(int CompanyID, string RegionalType)
        {
            return Settings.settings_regionalsettings_select_by_type(CompanyID, RegionalType);
        }

        public static void settings_RegionalSettings_update(int CompanyID, int LanguageID, string DateFormate, string Colour, string Organization, string State, string Centre, string ZipCode, string Metre, string Weight, string GeneralWeight, string PaperMeasure, string PageTitle, string CompanyTitle, int TimeZoneID, DateTime fiscalfromtxt, DateTime fiscaltotxt, int IsDisplayCostCentre, string PaperMaterial)
        {
            Settings.settings_RegionalSettings_update(CompanyID, LanguageID, DateFormate, Colour, Organization, State, Centre, ZipCode, Metre, Weight, GeneralWeight, PaperMeasure, PageTitle, CompanyTitle, TimeZoneID, fiscalfromtxt, fiscaltotxt, IsDisplayCostCentre,PaperMaterial);
        }

        public static void settings_role_select(int companyid, int roleid, TextBox txtdescription, Label lblheader)
        {
            Settings.settings_role_select(companyid, roleid, txtdescription, lblheader);
        }

        public static DataSet Settings_Select_Alert_Email_Body(int AlertID)
        {
            return Settings.Settings_Select_Alert_Email_Body(AlertID);
        }

        public static DataSet settings_Select_Alert_Setting(long CompanyID, long UserID)
        {
            return Settings.settings_Select_Alert_Setting(CompanyID, UserID);
        }

        public static DataSet settings_Select_Alert_Settings(long CompanyID, long UserID)
        {
            return Settings.settings_Select_Alert_Settings(CompanyID, UserID);
        }

        public static DataSet Settings_Select_Copywidget_ByUserID(int UserID)
        {
            return Settings.Settings_Select_Copywidget_ByUserID(UserID);
        }

        public static DataSet Settings_Select_CopyWidgets(int CopyMasterID)
        {
            return Settings.Settings_Select_CopyWidgets(CopyMasterID);
        }

        public static DataSet Settings_Select_MasterWidgets()
        {
            return Settings.Settings_Select_MasterWidgets();
        }

        public static DataSet Settings_Select_MasterWidgetsForUSer()
        {
            return Settings.Settings_Select_MasterWidgetsForUSer();
        }

        public static DataSet Settings_Select_MiniCopywidget(int UserID)
        {
            return Settings.Settings_Select_MiniCopywidget(UserID);
        }

        public static DataSet Settings_Select_MiniMasterWidgets()
        {
            return Settings.Settings_Select_MiniMasterWidgets();
        }

        public static long Settings_SpeedWeightLookup_Insert_Update(int CompanyID, decimal HourlyCharge, decimal BlackGSM1, decimal BlackPagesPerMinute1, decimal BlackGSM2, decimal BlackPagesPerMinute2, decimal BlackGSM3, decimal BlackPagesPerMinute3, decimal ColorGSM1, decimal ColorPagesPerMinute1, decimal ColorGSM2, decimal ColorPagesPerMinute2, decimal ColorGSM3, decimal ColorPagesPerMinute3, long SpeedWeightLookup)
        {
            return Settings.Settings_SpeedWeightLookup_Insert_Update(CompanyID, HourlyCharge, BlackGSM1, BlackPagesPerMinute1, BlackGSM2, BlackPagesPerMinute2, BlackGSM3, BlackPagesPerMinute3, ColorGSM1, ColorPagesPerMinute1, ColorGSM2, ColorPagesPerMinute2, ColorGSM3, ColorPagesPerMinute3, SpeedWeightLookup);
        }

        public static DataTable Settings_SpeedWeightLookup_Select_By_ID(int CompanyID, long SpeedWeightLookupID)
        {
            return Settings.Settings_SpeedWeightLookup_Select_By_ID(CompanyID, SpeedWeightLookupID);
        }

        public static void settings_subject_delete(int CompanyID, string Subject)
        {
            Settings.settings_subject_delete(CompanyID, Subject);
        }

        public static void settings_subject_insert(int CompanyID, string Subject)
        {
            Settings.settings_subject_insert(CompanyID, Subject);
        }

        public static DataTable settings_subject_select(int CompanyID)
        {
            return Settings.settings_subject_select(CompanyID);
        }

        public static int Settings_SupplierEmailBody_Insert(long CompanyID, string TemplateType, string TemplateName, string Subject, string Body, long EmailtoAdminID, bool Isdefault)
        {
            return Settings.Settings_SupplierEmailBody_Insert(CompanyID, TemplateType, TemplateName, Subject, Body, EmailtoAdminID, Isdefault);
        }

        public static string settings_system_markup_by_type(int CompanyID, string Type)
        {
            return Settings.settings_system_markup_by_type(CompanyID, Type);
        }

        public static void settings_system_markup_delete(int companyID, int systemMarkupID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                SystemMarkupID = systemMarkupID
            };
            Settings.settings_system_markup_delete(settingsItem);
        }

        public static int settings_system_markup_insert(int companyID, decimal paper, decimal printBroker, decimal inks, decimal inventoryItems, decimal otherCosts, decimal deliverycost, int markupID, int taxID, bool roundUpTotals)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                Paper = paper,
                PrintBroker = printBroker,
                Inks = inks,
                InventoryItems = inventoryItems,
                OtherCosts = otherCosts,
                DeliveryCost = deliverycost,
                MarkupID = markupID,
                TaxID = taxID,
                RoundUpTotals = roundUpTotals
            };
            return Settings.settings_system_markup_insert(settingsItem);
        }

        public static DataTable settings_system_markup_select(int CompanyID)
        {
            return Settings.settings_system_markup_select(CompanyID);
        }

        public static int settings_system_markup_update(int companyID, int systemMarkupID, decimal paper, decimal printBroker, decimal inks, decimal inventoryItems, decimal otherCosts, decimal DeliveryCost, int markupID, int taxID, bool roundUpTotals)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                SystemMarkupID = systemMarkupID,
                Paper = paper,
                PrintBroker = printBroker,
                Inks = inks,
                InventoryItems = inventoryItems,
                OtherCosts = otherCosts,
                DeliveryCost = DeliveryCost,
                MarkupID = markupID,
                TaxID = taxID,
                RoundUpTotals = roundUpTotals
            };
            return Settings.settings_system_markup_update(settingsItem);
        }

        public static void settings_taborder_update(int CompanyID, int OrderNumber, int HeaderID)
        {
            Settings.settings_taborder_update(CompanyID, OrderNumber, HeaderID);
        }

        public static void Settings_TaskSubject_delete(long SubjectId)
        {
            Settings.Settings_TaskSubject_delete(SubjectId);
        }

        public static void Settings_TaskSubject_Insert(string Subject, long CompanyID, bool IsDefault)
        {
            Settings.Settings_TaskSubject_Insert(Subject, CompanyID, IsDefault);
        }

        public static DataTable Settings_TaskSubject_Select(long CompanyID)
        {
            return Settings.Settings_TaskSubject_Select(CompanyID);
        }

        public static void Settings_TaskSubject_status_update(long SubjectId, long CompanyID)
        {
            Settings.Settings_TaskSubject_status_update(SubjectId, CompanyID);
        }

        public static void Settings_TaskSubject_Update(long SubjectID, long CompanyID, string Subject, bool IsDefault)
        {
            Settings.Settings_TaskSubject_Update(SubjectID, CompanyID, Subject, IsDefault);
        }

        public static void settings_taxrate_delete(int companyID, int taxID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                TaxID = taxID
            };
            Settings.settings_taxrate_delete(settingsItem);
        }

        public static void settings_taxrate_delete_new(int TaxID, int CompanyID)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                TaxID = TaxID,
                CompanyID = CompanyID
            };
            Settings.settings_taxrate_delete_new(settingsItem);
        }

        public static int settings_taxrate_insert(int companyID, string taxName, decimal taxRate)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                TaxName = taxName,
                TaxRate = taxRate
            };
            return Settings.settings_taxrate_insert(settingsItem);
        }

        public static int settings_taxrate_insert_new(int companyID, string taxName, decimal taxRate, string Alias)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                TaxName = SettingsBasePage.objBase.SpecialEncode(taxName),
                TaxRate = taxRate,
                Alias = Alias
            };
            return Settings.settings_taxrate_insert(settingsItem);
        }

        public static DataTable settings_taxrate_select(int CompanyID)
        {
            return Settings.settings_taxrate_select(CompanyID);
        }

        public static DataTable settings_taxrate_selectbyID(int CompanyID, int TaxID)
        {
            return Settings.settings_taxrate_selectbyID(CompanyID, TaxID);
        }

        public static int settings_taxrate_update(int companyID, int taxID, string taxName, decimal taxRate)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = companyID,
                TaxID = taxID,
                TaxName = taxName,
                TaxRate = taxRate
            };
            return Settings.settings_taxrate_update(settingsItem);
        }

        public static int settings_taxrate_update_new(int companyID, int taxID, string taxName, decimal taxRate, string Alias)
        {
            if (Alias == null)
            {
                SettingsItem settingsItem = new SettingsItem()
                {
                    CompanyID = companyID,
                    TaxID = taxID,
                    TaxName = SettingsBasePage.objBase.SpecialEncode(taxName),
                    TaxRate = taxRate,
                    Alias = ""
                };
                return Settings.settings_taxrate_update(settingsItem);

            }
            else
            {
                SettingsItem settingsItem = new SettingsItem()
                {
                    CompanyID = companyID,
                    TaxID = taxID,
                    TaxName = SettingsBasePage.objBase.SpecialEncode(taxName),
                    TaxRate = taxRate,
                    Alias = Alias
                };
                return Settings.settings_taxrate_update(settingsItem);
            }
        }

        public static IDataReader settings_template(int CompanyID, string page)
        {
            return Settings.settings_template(CompanyID, page);
        }

        public static IDataReader settings_template_CustomerValue_select(int CompanyID, int CustomerID)
        {
            return Settings.settings_template_CustomerValue_select(CompanyID, CustomerID);
        }

        public static void settings_template_Delete(int CompanyID, int TemplateID)
        {
            Settings.settings_template_Delete(CompanyID, TemplateID);
        }

        public static void settings_template_emailed_insert(string TemplateName, string TemplateKey, long CompanyID)
        {
            Settings.settings_template_emailed_insert(TemplateName, TemplateKey, CompanyID);
        }

        public static string settings_template_emailed_select(string TemplateKey)
        {
            return Settings.settings_template_emailed_select(TemplateKey);
        }

        public static string settings_template_emailed_select_CompanyID(string TemplateKey)
        {
            return Settings.settings_template_emailed_select_CompanyID(TemplateKey);
        }

        public static string settings_template_emailed_select_GUID(string TemplateKey)
        {
            return Settings.settings_template_emailed_select_GUID(TemplateKey);
        }

        public static void settings_template_emailed_update(string TemplateGUIDName, string TemplateKey)
        {
            Settings.settings_template_emailed_update(TemplateGUIDName, TemplateKey);
        }

        public static DataTable settings_template_field_category_selectall(int CompanyID)
        {
            return Settings.settings_template_field_category_selectall(CompanyID);
        }

        public static IDataReader settings_template_FieldText_select(int CompanyID, string PageType)
        {
            return Settings.settings_template_FieldText_select(CompanyID, PageType);
        }

        public static IDataReader settings_template_FieldValue_select(int CompanyID, int EstimateID)
        {
            return Settings.settings_template_FieldValue_select(CompanyID, EstimateID);
        }

        public static DataSet Settings_Template_Group_Select(int ID)
        {
            return Settings.Settings_Template_Group_Select(ID);
        }

        public static DataSet Settings_Template_HGroup_Select(int ID)
        {
            return Settings.Settings_Template_HGroup_Select(ID);
        }

        public static IDataReader settings_template_notes_values_select(int CompanyID, int DeliveryID)
        {
            return Settings.settings_template_notes_values_select(CompanyID, DeliveryID);
        }

        public static void settings_template_pdf_delete(int CompanyID, long PDFID)
        {
            Settings.settings_template_pdf_delete(CompanyID, PDFID);
        }

        public static IDataReader settings_template_purchase_values_select(int CompanyID, int PurchaseID)
        {
            return Settings.settings_template_purchase_values_select(CompanyID, PurchaseID);
        }

        public static IDataReader settings_template_quantity_select(int CompanyID, int QuantityID)
        {
            return Settings.settings_template_quantity_select(CompanyID, QuantityID);
        }

        public static IDataReader settings_template_select_byID(int CompanyID, int TemplateID)
        {
            return Settings.settings_template_select_byID(CompanyID, TemplateID);
        }

        public static void settings_template_update(int CompanyID, int TemplateID, string Name, string Description, string Contents, string ControlList, string ModuleName, bool IsDefault, long PDFID, decimal FooterSpace, decimal HeaderSpace, char ItemSplitStatus, bool isKeepWithPrevious, bool issplitsubitem, bool isLocationBasedSorting
            , bool isGroupingBasedOnStock , int UserID)
        {
            Settings.settings_template_update(CompanyID, TemplateID, Name, Description, Contents, ControlList, ModuleName, IsDefault, PDFID, FooterSpace, HeaderSpace, ItemSplitStatus, isKeepWithPrevious, issplitsubitem, isLocationBasedSorting, isGroupingBasedOnStock, UserID);
        }

        public static void settings_templatecategory_delete(int CompanyID, long CategoryID)
        {
            Settings.settings_templatecategory_delete(CompanyID, CategoryID);
        }

        public static int settings_templatecategory_insert(int CompanyID, string fieldName)
        {
            return Settings.settings_templatecategory_insert(CompanyID, fieldName);
        }

        public static DataTable settings_templatecategory_select(int CompanyID, string fieldName, int fieldValue)
        {
            return Settings.settings_templatecategory_select(CompanyID, fieldName, fieldValue);
        }

        public static void settings_templatefield_Isdelete_update(int FieldID)
        {
            Settings.settings_templatefield_Isdelete_update(FieldID);
        }

        public static void settings_templatefield_order_number_update(int CompanyID, int FieldID, int OrderNumber, string FieldName, string FieldValue, string FieldText)
        {
            Settings.settings_templatefield_order_number_update(CompanyID, FieldID, OrderNumber, FieldName, FieldValue, FieldText);
        }

        public static void settings_templatefield_properties_delete(int CompanyID, long TemplateID)
        {
            Settings.settings_templatefield_properties_delete(CompanyID, TemplateID);
        }

        public static void settings_templatefield_properties_insert(int CompanyID, long TemplateID, string objID, string objType, string objName, string type, string objValue, string imgsrc, string title, string align, string position, decimal top, decimal left, decimal width, decimal height, string zindex, string padding, string display, string overflow, string fontfamily, string fontsize, string fontweight, string fontstyle, string fontcolor, string textdecoration, string textalign, string border, string backgroundcolor, string visibility, string maxlength, string offsetwidth, string offsetheight, string offsettop, string offsetleft, string pixelwidth, string pixelheight, string pixeltop, string objlock, string canmove, string canchangefontcolor, string canchangefontsize, string canchangefont, string objclass, string onmouseoverclass, string objTag, string GroupID, string HGroupID, string AssociatedLabel, bool IsHGroupMain, string objrepeat)
        {
            Settings.settings_templatefield_properties_insert(CompanyID, TemplateID, objID, objType, objName, type, objValue, imgsrc, title, align, position, top, left, width, height, zindex, padding, display, overflow, fontfamily, fontsize, fontweight, fontstyle, fontcolor, textdecoration, textalign, border, backgroundcolor, visibility, maxlength, offsetwidth, offsetheight, offsettop, offsetleft, pixelwidth, pixelheight, pixeltop, objlock, canmove, canchangefontcolor, canchangefontsize, canchangefont, objclass, onmouseoverclass, objTag, GroupID, HGroupID, AssociatedLabel, IsHGroupMain, objrepeat);
        }

        public static DataTable settings_templatefield_properties_select(int CompanyID, long TemplateID)
        {
            return Settings.settings_templatefield_properties_select(CompanyID, TemplateID);
        }

        public static DataTable settings_templatefield_select(int companyID)
        {
            return Settings.settings_templatefield_select(companyID);
        }

        public static void settings_templatefieldadd_Delete(int CompanyID, int fieldID)
        {
            Settings.settings_templatefieldadd_Delete(CompanyID, fieldID);
        }

        public static DataTable settings_templates_associatelabel_select(int TemplateID)
        {
            return Settings.settings_templates_associatelabel_select(TemplateID);
        }

        public static int settings_templates_checkDuplicate(int CompanyID, string TemplateName, string ModuleName)
        {
            return Settings.settings_templates_checkDuplicate(CompanyID, TemplateName, ModuleName);
        }

        public static void settings_templates_groups_copy(long CompanyID, long OldTemplateID, long NewTemplateID)
        {
            Settings.settings_templates_groups_copy(CompanyID, OldTemplateID, NewTemplateID);
        }

        public static void settings_templates_Hgroups_copy(long CompanyID, long OldTemplateID, long NewTemplateID)
        {
            Settings.settings_templates_Hgroups_copy(CompanyID, OldTemplateID, NewTemplateID);
        }

        public static long settings_templates_insert(int CompanyID, string Name, string Description, string Contents, string ControlList, string ModuleName, bool IsDefault, long PDFID, decimal FooterSpace, decimal HeaderSpace, char ItemSplitStatus, bool isKeepWithPrevious, bool isSplitSubitem, bool isLocationBasedSorting
            , bool isGroupingBasedOnStock)
        {
            return Settings.settings_templates_insert(CompanyID, Name, Description, Contents, ControlList, ModuleName, IsDefault, PDFID, FooterSpace, HeaderSpace, ItemSplitStatus, isKeepWithPrevious, isSplitSubitem, isLocationBasedSorting, isGroupingBasedOnStock);
        }

        public static DataTable settings_templates_properties_select(int COmpanyID, long TemplateID)
        {
            return Settings.settings_templates_properties_select(COmpanyID, TemplateID);
        }

        public static void settings_templates_properties_update(int CompanyID, long TemplatePropertiesID, string align, decimal top, decimal left, decimal width, decimal height, string fontfamily, string fontsize, string GroupID, string HGroupID, string AssociatedLabel, bool IsHGroupMain, bool IsLock)
        {
            Settings.settings_templates_properties_update(CompanyID, TemplatePropertiesID, align, top, left, width, height, fontfamily, fontsize, GroupID, HGroupID, AssociatedLabel, IsHGroupMain, IsLock);
        }

        public static DataTable settings_templates_select(int COmpanyID, string ModuleName)
        {
            return Settings.settings_templates_select(COmpanyID, ModuleName);
        }

        public static DataTable settings_templatesfields_select(int CompanyID, int CategoryID)
        {
            return Settings.settings_templatesfields_select(CompanyID, CategoryID);
        }

        public static int settings_templatespdf_insert(int CompanyID, long PDFID, string PDFTitle, string PDFName, string PDFKey, string ReportFileName)
        {
            return Settings.settings_templatespdf_insert(CompanyID, PDFID, PDFTitle, PDFName, PDFKey, ReportFileName);
        }

        public static void settings_templatespdf_pages_insert(int ID, int FirstPageNumber, int LastPageNumber)
        {
            Settings.settings_templatespdf_pages_insert(ID, FirstPageNumber, LastPageNumber);
        }

        public static DataTable settings_titlecode_fortemplate_select(int CompanyID, long ModuleID, string ModuleName)
        {
            return Settings.settings_titlecode_fortemplate_select(CompanyID, ModuleID, ModuleName);
        }
        public static DataTable settings_get_internal_email_template_values(int CompanyID, long ModuleID,string Module)
        {
            return Settings.settings_get_internal_email_template_values(CompanyID, ModuleID,Module);
        }
        public static DataTable settings_titlecode_fortemplate_select(int CompanyID, long ModuleID, string ModuleName, string Items)
        {
            return Settings.settings_titlecode_fortemplate_select(CompanyID, ModuleID, ModuleName, Items);
        }

        public static DataTable settings_proof_template_select(int CompanyID, long ModuleID, string Items)
        {
            return Settings.settings_proof_template_select(CompanyID, ModuleID, Items);
        }

        public static DataTable settings_titlecode_fortemplate_select_Item(int CompanyID, long EstimateItemID)
        {
            return Settings.settings_titlecode_fortemplate_select_Item(CompanyID, EstimateItemID);
        }

        public static DataTable settings_titlecode_fortemplate_select_Item_delivery(int CompanyID, long Deliveryid)
        {
            return Settings.settings_titlecode_fortemplate_select_Item_delivery(CompanyID, Deliveryid);
        }

        public static void Settings_Update_Alert_Notification_settings(int AlertID, long CompanyID, long UserID, string TemplateName, string Subject, string Body)
        {
            Settings.Settings_Update_Alert_Notification_settings(AlertID, CompanyID, UserID, TemplateName, Subject, Body);
        }

        public static void Settings_Update_Alert_Setting(long CompanyID, long UserID, bool isShowTaskAlertonScreen, int ShowTaskAlertOnScreenTime, bool isShowCallAlertOnScreen, int ShowCallAlertOnScreenTime, bool isSendTaskAlert, int SendTaskAlertTime, bool isSendCallAlert, int SendCallAlertTime, int CreatedBy)
        {
            Settings.Settings_Update_Alert_Setting(CompanyID, UserID, isShowTaskAlertonScreen, ShowTaskAlertOnScreenTime, isShowCallAlertOnScreen, ShowCallAlertOnScreenTime, isSendTaskAlert, SendTaskAlertTime, isSendCallAlert, SendCallAlertTime, CreatedBy);
        }

        public static void Settings_Update_Alert_Settings(long CompanyID, long UserID, string TasksAlert, int TasksAlertMinute, string TasksAlertFor, string EventAlert, int EventAlertMinute, string EventAlertFor, string CallAlert, int CallAlertMinute, string CallAlertFor, int CreatedBy)
        {
            Settings.Settings_Update_Alert_Settings(CompanyID, UserID, TasksAlert, TasksAlertMinute, TasksAlertFor, EventAlert, EventAlertMinute, EventAlertFor, CallAlert, CallAlertMinute, CallAlertFor, CreatedBy);
        }

        public static void Settings_Update_CopyWidgets(long ID, long CopyMasterID, long CompanyID, string UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, string IsCalendarYear, string FromDate, string ToDate,DailyTarget dailyTarget, MonthlyTarget monthlyTarget)
        {
            Settings.Settings_Update_CopyWidgets(ID, CopyMasterID, CompanyID, UserID, DateType, IncludeArchiverecords, IsDisplayWidget, Color, Title, IsCalendarYear, FromDate, ToDate,dailyTarget,monthlyTarget);
        }

        public static void Settings_Update_CopyWidgets(int CopyMasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int LastUpdatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus,string IsCalendarYear,string DateType,bool IsLastYearData= false,bool IsDailyTarget= false,bool IsMonthlyTarget= false)
        {
            Settings.Settings_Update_CopyWidgets(CopyMasterID, CompanyID, UserID, WidgetType, DefaultDate, ShowPrint, TitleName, WidgetName, DisplayType, GraphType, LastUpdatedBy, ModuleName, NoOfRecords, Customizecolumns, Customerid, isSpread, TaskStatus, CompanyType, DisplayRecordSalesOf, QuarterType, FromDate, Todate, EstimateType, ShowFullScreen, ShowAllOptions, Status, ShowArchivedStatus,IsCalendarYear,DateType,IsLastYearData,IsDailyTarget,IsMonthlyTarget);
        }
        public static bool settings_user_access_rights_check(int CompanyID, int UserID, string Module, string Type)
        {
            return Settings.settings_user_access_rights_check(CompanyID, UserID, Module, Type);
        }

        public static DataTable Settings_user_check_isadmin(int CompanyID, int UserID)
        {
            return Settings.Settings_user_check_isadmin(CompanyID, UserID);
        }
        public static DataTable GetTrackingOPtions(int Id)
        {
            return Settings.GetTrackingOPtions(Id);
        }

        public static DataTable SaveUpdateTrackingOPtions(Int32 Id, string TrackingOption, string Description)
        {
            return Settings.SaveUpdateTrackingOPtions(Id, TrackingOption, Description);
        }

        public static void DeleteTrackingOPtions(int Id)
        {
            Settings.DeleteTrackingOPtions(Id);
        }

        public static void settings_user_delete(int companyid, int userid)
        {
            Settings.settings_user_delete(companyid, userid);
        }

        public static int settings_user_insert(int companyID, string email, string name, string password, int usertype, string description, bool disable, string createddate, string phone, string Mobile, string Fax, string defaultlanding, bool IsActivateUserForSalesTargets, string UserImage, string JobTitle, Int32 LocationId)
        {
            return Settings.settings_user_insert(companyID, email, name, password, usertype, description, disable, createddate, phone, Mobile, Fax, defaultlanding, IsActivateUserForSalesTargets, UserImage, JobTitle, LocationId);
        }

        public static void settings_user_password_update(int companyID, int userid, string password)
        {
            Settings.settings_user_password_update(companyID, userid, password);
        }

        public static void settings_user_profile_update(int companyID, int userid, string name, string description, string phone, string Mobile, string Fax, string defaultlanding, string UserImage, string JobTitle)
        {
            Settings.settings_user_profile_update(companyID, userid, name, description, phone, Mobile, Fax, defaultlanding, UserImage, JobTitle);
        }

        public static DataTable settings_user_select(int CompanyID)
        {
            return Settings.settings_user_select(CompanyID);
        }

        public static DataTable settings_user_select_forddl(int CompanyID)
        {
            return Settings.settings_user_select_forddl(CompanyID);
        }

        public static void settings_user_update(int companyID, int userid, string email, string name, string password, int usertype, string description, bool disable, string phone, string Mobile, string Fax, string defaultlanding, bool IsActivateUserForSalesTargets, string UserImage, string JobTitle, Int32 TrackingOptionId)
        {
            Settings.settings_user_update(companyID, userid, email, name, password, usertype, description, disable, phone, Mobile, Fax, defaultlanding, IsActivateUserForSalesTargets, UserImage, JobTitle, TrackingOptionId);
        }

        public static string Settings_UserImage_Select(long UserID)
        {
            return Settings.Settings_UserImage_Select(UserID);
        }

        public static int settings_usermailduplicacy_check(int CompanyID, string PlantPressType, string PlantPressName, long PlantpressID)
        {
            return Settings.settings_usermailduplicacy_check(CompanyID, PlantPressType, PlantPressName, PlantpressID);
        }

        public static DataTable settings_userrole_select(int CompanyID, DropDownList ddlrole)
        {
            return Settings.settings_userrole_select(CompanyID, ddlrole);
        }

        public static void settings_userTab_display_update(string TabName, int IsDisplay)
        {
            Settings.settings_userTab_display_update(TabName, IsDisplay);
        }

        public static void settings_webstoreothercost_order_number_update(int CompanyID, int WebOtherCostID, int OrderNumber)
        {
            Settings.settings_webstoreothercost_order_number_update(CompanyID, WebOtherCostID, OrderNumber);
        }

        public DataTable SubAdditional_Option_Select(int companyID, long ID)
        {
            return Settings.SubAdditional_Option_Select(companyID, ID);
        }

        public static void system_autoDeliveryalert_email(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC, int EmailID)
        {
            Settings.system_autoDeliveryalert_email(CompanyID, UserID, StatusID, Subject, Body, FooterID, IsEnabled, CC, BCC, EmailID);
        }

        public static DataTable system_autojobalert(int CompanyID, int EmailID)
        {
            return Settings.system_autojobalert(CompanyID, EmailID);
        }

        public static void system_autojobalert_email(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC, int EmailID)
        {
            Settings.system_autojobalert_email(CompanyID, UserID, StatusID, Subject, Body, FooterID, IsEnabled, CC, BCC, EmailID);
        }
        public static void system_auto_internal_alert(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC,string EmailTo,string EmailType, int EmailID)
        {
            Settings.system_auto_internal_alert(CompanyID, UserID, StatusID, Subject, Body, FooterID, IsEnabled, CC, BCC,EmailTo,EmailType, EmailID);
        }
        public static string system_default_settings(int CompanyID)
        {
            return Settings.system_default_settings(CompanyID);
        }

        public static DataTable template_email_phrasebook_select(int CompanyID, string PhraseType, string EmailTemplateType, string SelectType)
        {
            return Settings.template_email_phrasebook_select(CompanyID, PhraseType, EmailTemplateType, SelectType);
        }

        public static int Template_Group_Update(int ID, string GroupName, bool IsAuto)
        {
            return Settings.Template_Group_Update(ID, GroupName, IsAuto);
        }

        public static int Template_HGroup_Update(int ID, string GroupName, bool isDeleteAllIfMainisBlank)
        {
            return Settings.Template_HGroup_Update(ID, GroupName, isDeleteAllIfMainisBlank);
        }

        public static void Unauth_Access_EmailBody_delete(long EmailID)
        {
            Settings.Unauth_Access_EmailBody_delete(EmailID);
        }

        public static DataTable Unauth_Access_EmailBody_Details(long CompanyID)
        {
            return Settings.Unauth_Access_EmailBody_Details(CompanyID);
        }

        public static void Unauth_Access_EmailBody_insert(int CompanyID, int UserID, string TemplateName, string Subject, string Body, int FooterID, bool IsDefault, long EmailID)
        {
            Settings.Unauth_Access_EmailBody_insert(CompanyID, UserID, TemplateName, Subject, Body, FooterID, IsDefault, EmailID);
        }

        public static DataTable Unauth_Access_EmailBody_Select(int CompanyID)
        {
            return Settings.Unauth_Access_EmailBody_Select(CompanyID);
        }

        public static DataTable Unauth_Access_EmailBody_selectedrow(long EmailID)
        {
            return Settings.Unauth_Access_EmailBody_selectedrow(EmailID);
        }

        public static void Update_settings_TemNameLastCounter(int CompanyID, long ModuleID, string ModuleName)
        {
            Settings.Update_settings_TemNameLastCounter(CompanyID, ModuleID, ModuleName);
        }

        public static void UpdateCategory(long CompanyID, long CategoryID, string CategoryName, string Description, long parentId, string CategoryImage, long UserID, string UserType)
        {
            Settings.UpdateCategory(CompanyID, CategoryID, CategoryName, Description, parentId, CategoryImage, UserID, UserType);
        }

        public static void UpdateImageDetails(long ImageID, long CompanyID, long CategoryID, long UserID, string OriginalFileName, string newfilename, string Description, string MetaTag)
        {
            Settings.UpdateImageDetails(ImageID, CompanyID, CategoryID, UserID, OriginalFileName, newfilename, Description, MetaTag);
        }

        public static void UpdateImageGallery(long ImageID, long CompanyID, string OriginalFileName, string Description, string MetaTag)
        {
            Settings.UpdateImageGallery(ImageID, CompanyID, OriginalFileName, Description, MetaTag);
        }

        public static void UpdateImageName(int New_PriceCatalogueID, string ControlID, string _newimgname)
        {
            Settings.UpdateImageName(New_PriceCatalogueID, ControlID, _newimgname);
        }

        public static void UpdateSelectedAccountID(long UserID, long AccountID)
        {
            Settings.UpdateSelectedAccountID(UserID, AccountID);
        }

        public static DataTable User_IsValid_Select(string Email, string Password)
        {
            return Settings.User_IsValid_Select(Email, Password);
        }

        public static int user_profile_userTypeId_Select(int CompanyID, int UserID)
        {
            return Settings.user_profile_userTypeId_Select(CompanyID, UserID);
        }

        public static string view_Default_select(string PageName, int CompanyID)
        {
            return Settings.view_Default_select(PageName, CompanyID);
        }

        public static void ScanningStockHistory_InsertOrUpdate(long Id, long CompanyID, string JobOrPoCode, Int32 Qty, string ItemCode, Int32 PriceCatalogueStockId, Int32 EstimateItemId, Int32 PurchaseItemId, Boolean Status, String ErrorMessage, Int32 UserId, string FileName, DateTime Date)
        {
             Settings.ScanningStockHistory_InsertOrUpdate(Id, CompanyID, JobOrPoCode, Qty, ItemCode, PriceCatalogueStockId, EstimateItemId, PurchaseItemId, Status, ErrorMessage, UserId, FileName, Date);
        }

        public static DataTable ScanningStockHistory_Select(int CompanyID)
        {
            return Settings.ScanningStockHistory_Select(CompanyID);
        }

        public static void Settings_Save_Targets(long CompanyID, int UserID, string DataType, DailyTarget dailyTarget, MonthlyTarget monthlyTarget)
        {
            Settings.Settings_Save_Targets(CompanyID, UserID, DataType, dailyTarget, monthlyTarget);
        }
        public static DataTable Settings_Targets_Select(long CompanyID, int UserID,string DataType)
        {
            return Settings.Settings_Targets_Select(CompanyID, UserID,DataType);
        }
        public static DataTable Select_Proof_Settings(int CompanyID, int UserID)
        {
            return Settings.Select_Proof_Settings(CompanyID, UserID);
        }

        public static void InsertProofSettingIfNotExist(int CompanyID, int UserID)
        {
            Settings.InsertProofSettingIfNotExist(CompanyID, UserID);
        }
        public static void Save_Proof_Settings(int CompanyID, int UserID, bool IsDisplayModuleNumber, bool IsItemPanelState, bool IsProofDescriptionStatus, bool IsItemTitle, bool IsDescription, bool IsArtwork, bool IsSize, bool IsColour, bool IsMaterial, bool IsDelivery, bool IsFinishing, bool IsProofs, bool IsPacking, bool IsNotes, bool IsInstructions, bool isCustomDescription1, bool isCustomDescription2, bool isCustomDescription3, bool isCustomDescription4, bool isCustomDescription5, bool isCustomDescription6, bool isCustomDescription7, bool isCustomDescription8, bool isCustomDescription9, bool isCustomDescription10, bool isCustomDescription11, bool isCustomDescription12, bool isCustomDescription13, bool isCustomDescription14, bool isCustomDescription15, bool isCustomDescription16, bool isCustomDescription17, bool isCustomDescription18, bool isCustomDescription19, bool isCustomDescription20, bool isCustomDescription21, bool isCustomDescription22, bool isCustomDescription23, bool isCustomDescription24, bool isCustomDescription25,bool chkDownloadFileBeforeApprove,bool chkMultiApproval,bool chkChangeProofDescription, bool chkProofCustomerComment)
        {
            Settings.Save_Proof_Settings(CompanyID, UserID, IsDisplayModuleNumber, IsItemPanelState, IsProofDescriptionStatus, IsItemTitle, IsDescription, IsArtwork, IsSize, IsColour, IsMaterial, IsDelivery, IsFinishing, IsProofs, IsPacking, IsNotes, IsInstructions, isCustomDescription1, isCustomDescription2, isCustomDescription3, isCustomDescription4, isCustomDescription5, isCustomDescription6, isCustomDescription7, isCustomDescription8, isCustomDescription9, isCustomDescription10, isCustomDescription11, isCustomDescription12, isCustomDescription13, isCustomDescription14, isCustomDescription15, isCustomDescription16, isCustomDescription17, isCustomDescription18, isCustomDescription19, isCustomDescription20, isCustomDescription21, isCustomDescription22, isCustomDescription23, isCustomDescription24, isCustomDescription25, chkDownloadFileBeforeApprove,chkMultiApproval,chkChangeProofDescription, chkProofCustomerComment);
        }
        public static DataTable Select_JobDefault_Settings(int CompanyID)
        {
            return Settings.Select_JobDefault_Settings(CompanyID);
        }
        public static void InsertUpdate_JobDefault_Settings(int CompanyID, bool IsDefaultJobArtwork, bool IsDefaultJobProof, bool IsDefaultJobApproval, bool IsDefaultJobProduction,bool Display100JobsOnJobPage)
        {
            Settings.InsertUpdate_JobDefault_Settings(CompanyID,IsDefaultJobArtwork,IsDefaultJobProof,IsDefaultJobApproval,IsDefaultJobProduction, Display100JobsOnJobPage);
        }
        public static void UpdateStripeDetails(int CompanyID,string HostName,string StripeKey,string StripeImage)
        {
            Settings.UpdateStripeDetails(CompanyID, HostName,StripeKey,StripeImage);
        }
        public static void UpdateStripeSuccessDetails(int CompanyID, string HostName, string url, string msg, string img,string logourl)
        {
            Settings.UpdateStripeSuccessDetails(CompanyID, HostName, url, msg,img, logourl);
        }
        public static DataTable GetStripeDetails(int CompanyID, string HostName)
        {
            return Settings.GetStripeDetails(CompanyID, HostName);
        }
        public static DataTable GetStripeSuccessDetails(int CompanyID, string HostName)
        {
            return Settings.GetStripeSuccessDetails(CompanyID, HostName);
        }
        public static void add_small_format_formula_tag(int CompanyID)
        {
            Settings.add_small_format_formula_tag(CompanyID);
        }
        public static DataTable PC_SecondApproval_Email(int CompanyID, int ProofID, string Type)
        {
            return Settings.PC_SecondApproval_Email(CompanyID, ProofID, Type);
        }
        public static DataTable PC_GetProofEmailDetails(int ProofID,int CompanyID)
        {
            return Settings.PC_GetProofEmailDetails(ProofID,CompanyID);
        }
        public static void add_warehouse_caliper_formula_tag(int CompanyID)
        {
            Settings.add_warehouse_caliper_formula_tag(CompanyID);
        }

        public static DataTable Select_DaysSince_Settings(int companyID)
        {
            return Settings.Select_DaysSince_Settings(companyID);
        }

        public static void InsertUpdate_DaysSince_Settings(int companyID, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11, string text12, string text13, string text14, string text15, string text16, int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int v10, int v11, int v12, int v13, int v14, int v15, int v16)
        {
            Settings.InsertUpdate_DaysSince_Settings(companyID, text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12, text13, text14, text15, text16 , v1,  v2,  v3,  v4,  v5,  v6,  v7,  v8,  v9,  v10,  v11,  v12,  v13,  v14,  v15,  v16);

        }
        public static int SaveFtpSettings(string ftpAddress, string username, string encryptedPassword, int CompanyID, int ftpPort,string rootFolder,string fileTransferProtocol)
        {
            return Settings.SaveFtpSettings(ftpAddress, username, encryptedPassword, CompanyID,ftpPort,rootFolder, fileTransferProtocol);
        }
        public static void SaveSelectedFolders(int ftpSettingsId, List<string> selectedFolders)
        {
            Settings.SaveSelectedFolders(ftpSettingsId, selectedFolders);
        }
        public static void SaveSelectedFolder(int ftpSettingsId, string folderName)
        {
            Settings.SaveSelectedFolder(ftpSettingsId, folderName);
        }
        public static void DeleteSelectedFolder(int ftpSettingsId, string folderName)
        {
            Settings.DeleteSelectedFolder(ftpSettingsId, folderName);
        }
        public static List<string> GetSavedFtpFoldersByFtpId(int ftpSettingsId)
        {
            return Settings.GetSavedFtpFoldersByFtpId(ftpSettingsId);
        }
        public static Dictionary<int, string> GetSavedFtpFolders(int CompanyID)
        {
            return Settings.GetSavedFtpFolders(CompanyID);
        }
        public static FtpSettingsModel GetFtpSettings(int CompanyID)
        {
            return Settings.GetFtpSettings(CompanyID);
        }

        public static void SaveFtpRouteSetting(int companyId, string sectionName, string actionName, int statusValue, bool isSelected)
        {
            Settings.SaveFtpRouteSetting(companyId, sectionName, actionName, statusValue, isSelected);
        }
        public static List<FtpRouteSetting> LoadFtpRouteSettings(int CompanyID)
        {
            return Settings.LoadFtpRouteSettings(CompanyID);
        }
        public static void InsertUpdateFTPPrefix(int CompanyID,int PrefixMode)
        {
            Settings.InsertUpdateFTPPrefix(CompanyID, PrefixMode);
        }
        public static FtpPrefixSettingsModel GetFtpPrefixSettings(int CompanyID)
        {
            return Settings.GetFtpPrefixSettings(CompanyID);
        }
        public static DataTable GetFTPEmailTags(int CompanyID, long PriceCatalogueID,long EstimateItemID)
        {
            return Settings.GetFTPEmailTags(CompanyID, PriceCatalogueID,EstimateItemID);
        }
        public static DataTable GetFTPEmailTemplate(int CompanyID, string TemplateType)
        {
            return Settings.GetFTPEmailTemplate(CompanyID, TemplateType);
        }
        public static DataTable GetFtpLogSettings(int CompanyID)
        {
            return Settings.GetFtpLogSettings(CompanyID);
        }
        public static void SaveFtpLogs(int CompanyID,long ProductCatalogueID,long EstimateItemID , DateTime TimeStamp, string Status,string TargetDestination, string FileName, string FTPError)
        {
            Settings.SaveFtpLogs(CompanyID,ProductCatalogueID,EstimateItemID, TimeStamp, Status, TargetDestination, FileName,FTPError);
        }
    }
}
