using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Services;


namespace ePrint.usercontrol.warehouse
{
    public partial class inventory_add : System.Web.UI.UserControl
    {
        protected HiddenField hdn_supplierid_frompopup = new HiddenField();

        public languageClass objlang = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string type = string.Empty;

        public string item = string.Empty;

        public string pagename = string.Empty;

        public string id = string.Empty;

        public string PropertyValue = string.Empty;

        public string PropertyConcat = string.Empty;

        public string Properties = string.Empty;

        public string PropertyName = string.Empty;

        public string pg = string.Empty;

        public string SubcatValue = string.Empty;

        public string SubcatConcat = string.Empty;

        public string inkid = string.Empty;

        public string Inventory_Name = string.Empty;

        public int Inventory_ID;

        public string CatValue = string.Empty;

        public string SubCatValue = string.Empty;

        public long InventoryID;

        public int SubCategoryID;

        private long InvCode;

        private Global gloobj = new Global();

        private InventoryBasePage obj = new InventoryBasePage();

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        public commonClass comm = new commonClass();

        private commonClass objJava = new commonClass();

        public string paperType = string.Empty;

        public string InkType = string.Empty;

        public string ProductType = string.Empty;

        public decimal DefaultValue;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string TabSelection = string.Empty;

        public string PaperMeasure = string.Empty;

        public static string ItemName;

        public int ddlSelectSupID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string LargeFormat = "";

        public int MaterialNo;

        public string LargeFormatCalculation = "";

        public string PaperTypeNew = string.Empty;

        public string IsColororwhiteink = string.Empty;

        public languageClass objLangClass = new languageClass();

        public string IsLargeMaterial = string.Empty;

        private string Export_Display = string.Empty;

        public string ServerName_Inventory = string.Empty;

        public string PaprMeasure = string.Empty;

        private int y;

        private BasePage objpage = new BasePage();

        public int DecimalPaperSize;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static inventory_add()
        {
            inventory_add.ItemName = string.Empty;
        }

        public inventory_add()
        {
        }

        protected void btnArchive_OnClick(object sender, EventArgs e)
        {
            this.InventoryID = Convert.ToInt64(base.Request.QueryString["id"].ToString());
            this.obj.warehouse_inventory_archive(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()));
            this.objBase.Message_Display(this.objlang.GetLanguageConversion("Inventory_Item_Archived_Successfully"), "msg-fail", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id= ", this.InventoryID));
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (base.Request.QueryString["type"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"));
            }
            else if (base.Request.QueryString["type"].ToString().ToLower() != "invselector")
            {
                if (base.Request.Url.ToString().ToLower().Contains("common/inventory_finishedgoods_add.aspx"))
                {
                    base.Response.Write("<script language='javascript' type='text/javascript'>window.close();</script>");
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("common/inkselector.aspx"))
                {
                    if (base.Request.Params["Esttype"] == "F" || base.Request.Params["Esttype"] == "D")
                    {
                        HttpResponse response = base.Response;
                        string[] item = new string[] { this.strSitepath, "common/inkselector.aspx?cnt=", base.Request.Params["cnt"], "&id=", base.Request.Params["id"], "&type=", base.Request.Params["type"], "&EstItemID=", base.Request.Params["EstItemID"], "&side=", base.Request.Params["side"], "&ddlval=", base.Request.Params["ddlval"], "&Esttype=", base.Request.Params["Esttype"], "&Section=", base.Request.Params["Section"], "&sidenumber=", base.Request.Params["sidenumber"], "&InkType=", base.Request.Params["InkType"] };
                        response.Redirect(string.Concat(item));
                        return;
                    }
                    if (base.Request.Params["Esttype"] == "N" || base.Request.Params["Esttype"] == "K")
                    {
                        HttpResponse httpResponse = base.Response;
                        string[] strArrays = new string[] { this.strSitepath, "common/inkselector.aspx?cnt=", base.Request.Params["cnt"], "&id=", base.Request.Params["id"], "&type=", base.Request.Params["type"], "&EstItemID=", base.Request.Params["EstItemID"], "&side=", base.Request.Params["side"], "&ddlval=", base.Request.Params["ddlval"], "&EstimateLithoNCRItemID=", base.Request.Params["EstimateLithoNCRItemID"], "&EstimateLithobookletItemID=", base.Request.Params["EstimateLithobookletItemID"], "&Esttype=", base.Request.Params["Esttype"], "&Section=", base.Request.Params["Section"], "&sidenumber=", base.Request.Params["sidenumber"], "&InkType=", base.Request.Params["InkType"] };
                        httpResponse.Redirect(string.Concat(strArrays));
                        return;
                    }
                }
                else if (base.Request.QueryString["type"].ToString().ToLower() == "edit")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"));
                    return;
                }
            }
            else
            {
                if (base.Request.Params["item"].ToString().ToLower() == "paper")
                {
                    if (base.Request.QueryString["IsLargeMaterial"] == null)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=invselector&pg=", base.Session["PageName"].ToString(), "&item=paper"));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    string[] str = new string[] { this.strSitepath, "common/common_popup.aspx?type=invselector&pg=", base.Session["PageName"].ToString(), "&item=paper&IsLargeMaterial=", base.Request.QueryString["IsLargeMaterial"].ToString() };
                    response1.Redirect(string.Concat(str));
                    return;
                }
                if (base.Request.Params["item"].ToString().ToLower() == "ink")
                {
                    HttpResponse httpResponse1 = base.Response;
                    string[] str1 = new string[] { this.strSitepath, "common/common_popup.aspx?type=invselector&pg=", base.Session["PageName"].ToString(), "&item=ink&InkType=", base.Request.Params["InkType"].ToString(), "&id=", base.Request.Params["id"].ToString() };
                    httpResponse1.Redirect(string.Concat(str1));
                    return;
                }
                if (base.Request.Params["item"].ToString().ToLower() == "plates")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=invselector&pg=", base.Session["PageName"].ToString(), "&item=plates"));
                    return;
                }
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            this.obj.warehouse_inventory_delete(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()));
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory&suc=del"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.SaveClick("save");
        }

        protected void btnStay_OnClick(object sender, EventArgs e)
        {
            this.SaveClick("stay");
        }

        protected void grdInventoryHistory_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (this.y == 0)
            {
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivExport");
                if (this.Export_Display == "0" || this.Export_Display == "2")
                {
                    htmlControl.Visible = false;
                }
                else
                {
                    htmlControl.Visible = true;
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnActionType");
                Label red = (Label)e.Item.FindControl("lblDescription");
                Label removeDecimalPlacesIfZero = (Label)e.Item.FindControl("lblQuantity");
                Label label = (Label)e.Item.FindControl("lblInstockQty");
                Label removeDecimalPlacesIfZero1 = (Label)e.Item.FindControl("lblFinalQuantity");
                if (hiddenField.Value.ToLower() != "a" && hiddenField.Value.ToLower() != "o" && hiddenField.Value.ToLower() != "r")
                {
                    if (hiddenField.Value.ToLower() != "h")
                    {
                        red.ForeColor = Color.Red;
                        if (red.Text.Contains("style='color:Blue'"))
                        {
                            red.Text = red.Text.Replace("style='color:Blue'", "style='color:Red'");
                        }
                    }
                    else
                    {
                        red.Attributes.Add("style", "color: #0000ff");
                        if (red.Text.Contains("style='color:Blue'"))
                        {
                            red.Text = red.Text.Replace("style='color:Blue'", "style='color:#0000ff'");
                        }
                    }
                }
                else if (!red.Text.ToLower().Contains("stock utilized:"))
                {
                    red.Attributes.Add("style", "color: #006400");
                    if (red.Text.Contains("style='color:Blue'"))
                    {
                        red.Text = red.Text.Replace("style='color:Blue'", "style='color:#006400'");
                    }
                }
                else
                {
                    red.ForeColor = Color.Red;
                    if (red.Text.Contains("style='color:Blue'"))
                    {
                        red.Text = red.Text.Replace("style='color:Blue'", "style='color:Red'");
                    }
                }
                if (removeDecimalPlacesIfZero.Text == "-")
                {
                    removeDecimalPlacesIfZero.Text = "0";
                }
                removeDecimalPlacesIfZero.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero.Text), 2, "", false, false, true);
                removeDecimalPlacesIfZero.Text = this.comm.ToRemoveDecimalPlacesIfZero(removeDecimalPlacesIfZero.Text);
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                label.Text = this.comm.ToRemoveDecimalPlacesIfZero(label.Text);
                removeDecimalPlacesIfZero1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(removeDecimalPlacesIfZero1.Text), 2, "", false, false, true);
                removeDecimalPlacesIfZero1.Text = this.comm.ToRemoveDecimalPlacesIfZero(removeDecimalPlacesIfZero1.Text);
                if (removeDecimalPlacesIfZero.Text == "0")
                {
                    removeDecimalPlacesIfZero.Text = "-";
                }
                red.Text = red.Text.Replace("µ", "");
            }
            inventory_add usercontrolWarehouseInventoryAdd = this;
            usercontrolWarehouseInventoryAdd.y = usercontrolWarehouseInventoryAdd.y + 1;
        }

        protected void grdInventoryHistoryBind()
        {
            this.grdInventoryHistory.Rebind();
        }

        protected void grdInventoryHistoryPageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.grdInventoryHistory.CurrentPageIndex = e.NewPageIndex;
            this.grdInventoryHistoryBind();
        }

        protected void grdInventoryHistoryPageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.grdInventoryHistoryBind();
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (base.Request.Params["type"] == null)
            {
                HttpSessionState session = base.Session;
                if (string.IsNullOrEmpty(this.txtMarkup.Text))
                    this.txtMarkup.Text = "-1";
                object[] text = new object[] { this.txtInvName.Text, ",", this.txtdescription.Text, ",", this.ddlInvCategory.SelectedValue, ",", this.txtInvLocation.Text, ",", this.txtInStock.Text, ",", this.txtReorderLevel.Text, ",", this.txtReorderQty.Text, ",", this.txtCost.Text, ",", this.txtPackedIn.Text, ",", this.txtPackedPrice.Text, ",", this.ddlPaperType.SelectedValue, ",", this.ddlPaperSize.SelectedValue, ",", this.txtBasisWeight.Text, ",", this.ddlCoated.SelectedValue, ",", this.txtColour.Text, ",", this.txtCost.Text, ",", this.txtWebWidth.Text, ",", this.txtWebLength.Text, ",", this.txtPer.Text, ",", this.txtPaperHeight.Text, ",", this.txtPaperWidth.Text, ",", this.chkCustom.Checked, ",", this.txtYield.Text, ",", this.txtMarkup.Text };
                session["Values"] = string.Concat(text);
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                return;
            }
        }

        protected void lnkCopyInventory_OnClick(object sender, EventArgs e)
        {
            this.InventoryID = Convert.ToInt64(base.Request.Params["id"].ToString());
            int num = 0;
            if (this.txtCopyStockQuantity.Text == "" || this.txtCopyStockQuantity.Text == null)
            {
                this.txtCopyStockQuantity.Text = "0";
            }
            num = Convert.ToInt32(this.txtCopyStockQuantity.Text);
            long num1 = this.obj.Copy_Inventory(this.CompanyID, this.InventoryID, num);
            string empty = string.Empty;
            string str = string.Empty;
            if (this.InventoryManagement == "IM")
            {
                foreach (DataRow row in this.obj.warehouse_inventory_select(this.CompanyID, this.InventoryID).Rows)
                {
                    empty = row["InventoryName"].ToString();
                    row["FriendlyName"].ToString();
                }
                this.comm.Insert_Activity_History_For_Inventory(num1, string.Concat("Copied Inventory from ", empty), this.UserID, Convert.ToInt32(Convert.ToDecimal(num)), "o", Convert.ToInt32(Convert.ToDecimal(num)));
                this.grdInventoryHistoryBind();
            }
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id=", num1, "&suc=cop" };
            response.Redirect(string.Concat(objArray));
        }

        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(base.Request.Params["id"].ToString()));
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("Date");
            dataTable1.Columns.Add("Description");
            dataTable1.Columns.Add("User");
            dataTable1.Columns.Add("Adjusted Qty");
            dataTable1.Columns.Add("InStock Qty");
            dataTable1.Columns.Add("Available Qty");
            foreach (DataRow row in dataTable.Rows)
            {
                string empty = string.Empty;
                try
                {
                    string[] strArrays = row["Description"].ToString().Split(new char[] { '<' });
                    string[] strArrays1 = strArrays[1].ToString().Split(new char[] { '>' });
                    empty = string.Concat(strArrays[0], strArrays1[1]);
                }
                catch
                {
                    empty = row["Description"].ToString();
                }
                object[] item = new object[] { row["CreatedDate"], empty, row["UserName"], row["quantity"], row["instockQty"], row["FinalQuantity"] };
                dataTable1.Rows.Add(item);
            }
            WebExport webExport = new WebExport();
            webExport.WebExportDetails(dataTable1, WebExport.ExportFormat.Excel, string.Concat(inventory_add.ItemName, "-History.xls"), ",");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.LargeFormat == null)
            {
                this.LargeFormat = "";
            }
            else
            {
                this.LargeFormat = ConnectionClass.LargeFormat;
            }
            if (ConnectionClass.LargeFormatCalculation != null)
            {
                this.LargeFormatCalculation = ConnectionClass.LargeFormatCalculation;
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/inventory_finishedgoods_add.aspx"))
            {
                this.btnCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_cancelprocess');window.close(); return false;");
            }
            this.Export_Display = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "exportorimport", this.Page.Request.Url.ToString());
            this.grdInventoryHistory.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Date");
            this.grdInventoryHistory.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Description");
            this.grdInventoryHistory.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("User");
            this.grdInventoryHistory.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Adjusted_Qty");
            this.grdInventoryHistory.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Instock_Qty");
            this.grdInventoryHistory.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Available_Qty");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.DivImageButton8.Visible = true;
                this.Divdiv_btnstay.Visible = true;
                this.Divdiv_btnsave.Visible = true;
                this.Divdiv_btndelete.Visible = true;
                this.Divdiv_btnsavenew.Visible = true;
                this.Divdiv_btnstaynew.Visible = true;
            }
            else
            {
                this.DivImageButton8.Visible = false;
                this.Divdiv_btnstay.Visible = false;
                this.Divdiv_btnsave.Visible = false;
                this.Divdiv_btndelete.Visible = false;
                this.Divdiv_btnsavenew.Visible = false;
                this.Divdiv_btnstaynew.Visible = false;
            }
            string str = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.Divdiv_btndelete.Visible = true;
            }
            else
            {
                this.Divdiv_btndelete.Visible = false;
            }
            string str1 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "others", this.Page.Request.Url.ToString());
            if (str1 == "0" || str1 == "2")
            {
                this.divQtyToAdjusted.Attributes.Add("style", "display:none");
                this.divQtyAdjustment.Attributes.Add("style", "display:none");
                this.divReasonadjustment.Attributes.Add("style", "display:none");
            }
            else
            {
                this.divQtyToAdjusted.Attributes.Add("style", "display:block");
                this.divQtyAdjustment.Attributes.Add("style", "display:block");
                this.divReasonadjustment.Attributes.Add("style", "display:block");
            }
            if (base.Request.Params["IsLargeMaterial"] != null && base.Request.Params["IsLargeMaterial"].ToString() != "")
            {
                this.IsLargeMaterial = base.Request.Params["IsLargeMaterial"].ToString();
            }
            this.Label1.Text = this.objLangClass.GetLanguageConversion("Width");
            this.Label2.Text = this.objLangClass.GetLanguageConversion("Length");
            this.Label9.Text = this.objLangClass.GetLanguageConversion("Email_Address_For_Alerts_To_be_Sent_To");
            this.Label11.Text = this.objLangClass.GetLanguageConversion("Alert_The_Users");
            this.Label43.Text = this.objLangClass.GetLanguageConversion("Location");
            this.Label44.Text = this.objLangClass.GetLanguageConversion("Status");
            this.Label4.Text = this.objLangClass.GetLanguageConversion("Supplier");
            this.lblAccountCode.Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
            this.Label58.Text = this.objLangClass.GetLanguageConversion("Paper_Type");
            this.lblInkType.Text = this.objLangClass.GetLanguageConversion("Ink_Costing_Type");
            this.Label7.Text = string.Concat(this.objLangClass.GetLanguageConversion("Minimum_Cost"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label49.Text = string.Concat(this.objLangClass.GetLanguageConversion("Cost"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label50.Text = this.objLangClass.GetLanguageConversion("Packed_In");
            this.Label51.Text = string.Concat(this.objLangClass.GetLanguageConversion("Pack_Price"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label52.Text = string.Concat(this.objlang.GetValueOnLang("Process Charge"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label53.Text = string.Concat(this.objlang.GetValueOnLang("Selling Price"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label60.Text = this.objlang.GetValueOnLang("Max. No. of Impressions");
            this.Label54.Text = this.objLangClass.GetLanguageConversion("Size_Ordered");
            this.Label5.Text = this.objLangClass.GetLanguageConversion("Basis_Weight");
            this.Label57.Text = this.objLangClass.GetLanguageConversion("Coated");
            this.Label56.Text = this.objlang.GetValueOnLang("Ink Absorption");
            this.lblColour.Text = this.objLangClass.GetLanguageConversion("Colour");
            this.Label62.Text = this.objlang.GetValueOnLang("Washup Counter");
            this.Label6.Text = string.Concat(this.objlang.GetValueOnLang("Set up Cost"), " ", this.objJava.GetCurrencyinRequiredFormate("", true));
            this.Label63.Text = this.objLangClass.GetLanguageConversion("Yield");
            this.Label45.Text = this.objLangClass.GetLanguageConversion("Opening_Stock");
            this.Label8.Text = this.objLangClass.GetLanguageConversion("Allocated_Qty");
            this.Label46.Text = this.objLangClass.GetLanguageConversion("ReOrder_Alert_Level");
            this.Label47.Text = this.objLangClass.GetLanguageConversion("ReOrder_Quantity");
            this.lblQtyToBeAdjusted.Text = this.objLangClass.GetLanguageConversion("Qty_To_Be_Adjusted");
            this.lblCopyStockQuantity.Text = this.objLangClass.GetLanguageConversion("Enter_The_True_Stock_Quantity");
            this.txtReasonadjustment.Text = this.objLangClass.GetLanguageConversion("Stock_Replenished");
            this.chkReorderLevelEveryTime.Text = this.objLangClass.GetLanguageConversion("Each_Time_The_Stock_Falls_Below_The_ReOrder_Level");
            this.chkReorderLevelDaily.Text = this.objLangClass.GetLanguageConversion("Once_Per_Day_Until_The_Stock_Is_Replenished");
            this.rdoNone.Text = this.objLangClass.GetLanguageConversion("Dont_Alert_Users");
            this.btnOk.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnSave_new.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnNext.Text = this.objLangClass.GetLanguageConversion("Next");
            this.btnSave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.btnArchive.Text = this.objLangClass.GetLanguageConversion("Archive_This_Item");
            this.BtnPrevious.Text = this.objLangClass.GetLanguageConversion("Previous");
            this.btnCancel_new.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.lbl_UserFriendlyName.Text = this.objLangClass.GetLanguageConversion("Friendly_Name");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnStay.Text = this.objLangClass.GetLanguageConversion("Save_Stay");
            this.lblAvailableQty.Text = this.objLangClass.GetLanguageConversion("Available_Qty");
            this.lblReasonadjustment.Text = this.objLangClass.GetLanguageConversion("Reason_For_Adjustment");
            this.lblReasonadjustment.Text = this.objLangClass.GetLanguageConversion("Stock_Replenished");
            this.btnStay_new.Text = this.objLangClass.GetLanguageConversion("Save_Stay");
            this.ddlInkType.Items[0].Text = this.objLangClass.GetLanguageConversion("Yield");
            this.ddlInkType.Items[1].Text = this.objLangClass.GetLanguageConversion("Matrix");
            this.ddlPaperType.Items[0].Text = this.objLangClass.GetLanguageConversion("Sheet");
            this.ddlPaperType.Items[1].Text = this.objLangClass.GetLanguageConversion("Roll");
            this.ddlCoated.Items[0].Text = this.objLangClass.GetLanguageConversion("None");
            this.ddlCoated.Items[1].Text = this.objLangClass.GetLanguageConversion("Gloss");
            this.ddlCoated.Items[2].Text = this.objLangClass.GetLanguageConversion("Matt");
            this.ServerName_Inventory = ConnectionClass.ServerName;
            //if (this.ServerName_Inventory.ToLower() != "gci")
            //{
            //    this.lblPackedIn.Text = "Sq.CM/KG";
            //}
            //else
            //{
            //    this.lblPackedIn.Text = "Sq.In/Lbs";
            //    ListItem listItem = new ListItem("Lbs", "Lbs");
            //    this.ddlPackedIn.Items.Insert(this.ddlPackedIn.Items.Count - 1, listItem);
            //    this.ddlPackedIn.Items.RemoveAt(0);
            //}
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["id"] != null)
            {
                this.inkid = base.Request.Params["id"].ToString();
            }
            this.pagename = base.Session["PageName"].ToString();
            this.txtInvName.Focus();
            this.divQtyToAdjusted.Attributes.Add("style", "display:none");
            this.PaperMeasure = this.objSet.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblCostpermtr.Text = this.objlang.GetLanguageConversion("Cost_per_Linear");
            this.lblCostperSQmtr.Text = this.objlang.GetLanguageConversion("Cost_Per_Sqaure_Meter");
            this.lblCaliperType.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMaterial");

            foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hid_3DecimalPaperSize.Value = dataRow["Decimal3ForPaperSizes"] != DBNull.Value
                                   ? dataRow["Decimal3ForPaperSizes"].ToString() : "False";
                if(this.hid_3DecimalPaperSize.Value.ToLower() == "true")
                {
                    this.DecimalPaperSize = 3;
                }
                else
                {
                    this.DecimalPaperSize = 0;
                }
            }
            if (this.PaperMeasure != "In.")
            {
                this.lblLengthType.Text = this.objlang.GetLanguageConversion("meters");
                this.lblpreLnFtMtr.Text = this.objlang.GetLanguageConversion("per_mtr");
                this.lblpreSqFtMtr.Text = this.objlang.GetLanguageConversion("per_sq_mtr");
            }
            else
            {
                this.lblWidthType.Text = this.objlang.GetLanguageConversion("ft");
                this.lblLengthType.Text = this.objlang.GetLanguageConversion("ft");
                this.lblpreLnFtMtr.Text = this.objlang.GetLanguageConversion("per_ft");
                this.lblpreSqFtMtr.Text = this.objlang.GetLanguageConversion("per_sq_ft");
            }
            if (this.InventoryManagement != "IM")
            {
                this.TabSelection = "False";
                this.btnSave.Visible = true;
                this.divbtnNext.Visible = false;
            }
            else
            {
                this.TabSelection = "True";
                if (!base.IsPostBack)
                {
                    this.txtemail.Text = this.objBase.SpecialDecode(InventoryBasePage.GetUserEmail(this.CompanyID, this.UserID));
                }
                this.divbtnNext.Visible = true;
            }
            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString() != "")
            {
                this.item = base.Request.Params["item"].ToString();
            }
            if (base.Request.Params["MaterialNo"] != null && base.Request.Params["MaterialNo"].ToString() != "")
            {
                this.MaterialNo = Convert.ToInt32(base.Request.Params["MaterialNo"].ToString());
            }
            if (base.Request.Params["id"] != null && base.Request.Params["id"].ToString() != "")
            {
                this.id = base.Request.Params["id"].ToString();
            }
            if (this.IsLargeMaterial.ToString() == "1")
            {
                this.chk_LargeFormatMaterial.Checked = true;
            }
            if (base.Request.Params["paperType"] != null)
            {
                this.paperType = base.Request.Params["paperType"].ToString();
            }
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["InkType"] != null)
            {
                this.InkType = base.Request.Params["InkType"].ToString();
            }
            if (!base.Request.Url.ToString().ToLower().Contains("maspro"))
            {
                this.Label40.Text = this.objLangClass.GetLanguageConversion("Inventory_Code");
                this.Label39.Text = this.objLangClass.GetLanguageConversion("Inventory_Name");
                this.Label5.Text = this.objLangClass.GetLanguageConversion("Basis_Weight");
                this.Label41.Text = this.objLangClass.GetLanguageConversion("Inventory_Category");
            }
            else
            {
                this.Label40.Text = this.objlang.GetValueOnLang("Part Code");
                this.Label39.Text = this.objlang.GetValueOnLang("Part Name");
                this.Label5.Text = this.objlang.GetValueOnLang("Weight");
                this.Label41.Text = this.objlang.GetValueOnLang("Part Category");
            }
            this.txtSheetsTo1.Attributes.Add("style", "text-align:right");
            this.txtInkChargableCost1.Attributes.Add("style", "text-align:right");
            this.txtInkCostPer1.Attributes.Add("style", "text-align:right");
            this.txtSheetsTo2.Attributes.Add("style", "text-align:right");
            this.txtInkChargableCost2.Attributes.Add("style", "text-align:right");
            this.txtInkCostPer2.Attributes.Add("style", "text-align:right");
            this.txtSheetsTo3.Attributes.Add("style", "text-align:right");
            this.txtInkChargableCost3.Attributes.Add("style", "text-align:right");
            this.txtInkCostPer3.Attributes.Add("style", "text-align:right");
            this.txtSheetsTo4.Attributes.Add("style", "text-align:right");
            this.txtInkChargableCost4.Attributes.Add("style", "text-align:right");
            this.txtInkCostPer4.Attributes.Add("style", "text-align:right");
            this.txtInkChargableCost5.Attributes.Add("style", "text-align:right");
            this.txtInkCostPer5.Attributes.Add("style", "text-align:right");
            this.txtminimum.Attributes.Add("style", "text-align:right");
            this.txtCost.Attributes.Add("style", "text-align:right");
            this.txtPer.Attributes.Add("style", "text-align:right");
            this.txtPackedIn.Attributes.Add("style", "text-align:right");
            this.txtPackedPrice.Attributes.Add("style", "text-align:right");
            this.txtMarkup.Attributes.Add("style", "text-align:right");
            this.txtYield.Attributes.Add("style", "text-align:right");
            this.txtInStock.Attributes.Add("style", "text-align:right");
            this.txtReorderLevel.Attributes.Add("style", "text-align:right");
            this.txtReorderQty.Attributes.Add("style", "text-align:right");
            this.txtBasisWeight.Attributes.Add("style", "text-align:right");
            this.txtWebLength.Attributes.Add("style", "text-align:right");
            this.txtWebWidth.Attributes.Add("style", "text-align:right");
            this.txtPaperHeight.Attributes.Add("style", "text-align:right");
            this.txtPaperWidth.Attributes.Add("style", "text-align:right");
            this.txtRollStockQty.Attributes.Add("style", "text-align:right");
            this.txtAllocatedQty.Attributes.Add("style", "text-align:right");
            this.txtAvailableQty.Attributes.Add("style", "text-align:right");
            this.txtCopyStockQuantity.Attributes.Add("style", "text-align:right");
            this.txtminimum.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtminimum.Text), 0, "", false, false, true);
            this.txtCost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtCost.Text), 0, "", false, false, true);
            this.txtPackedPrice.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtPackedPrice.Text), 0, "", false, false, true);
            if (string.IsNullOrEmpty(this.txtMarkup.Text))
                this.txtMarkup.Text = "-1";
            this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMarkup.Text), 0, "", false, false, true);
            this.txtInkChargableCost1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInkChargableCost1.Text), 0, "", false, false, true);
            this.txtInkChargableCost2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInkChargableCost2.Text), 0, "", false, false, true);
            this.txtInkChargableCost3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInkChargableCost3.Text), 0, "", false, false, true);
            this.txtInkChargableCost4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInkChargableCost4.Text), 0, "", false, false, true);
            this.txtInkChargableCost5.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInkChargableCost5.Text), 0, "", false, false, true);
            this.lblCostPerReel.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.lblCostPerReel.Text), 0, "", false, false, true);
            this.txtWebLength.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtWebLength.Text), 0, "", false, false, true);
            this.txtWebWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtWebWidth.Text), 0, "", false, false, true);
            if (!base.IsPostBack && base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString() == "cop")
            {
                this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Copied_Successfully"), "msg-success", this.plhMessage);
            }
            if (!base.IsPostBack)
            {
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = true;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
                for (int i = 1; i <= 5; i++)
                {
                    TextBox textBox = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", i));
                    TextBox textBox1 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", i));
                    TextBox textBox2 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", i));
                    TextBox textBox3 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                    AttributeCollection attributes = textBox.Attributes;
                    object[] objArray = new object[] { "AllowNumber(this,this.value);ToInteger(this,this.value);checkNextCharge(this.value,", i, ");CallonBlur(this.value,'spn_InkValue_", i, "');" };
                    attributes.Add("onkeyup", string.Concat(objArray));
                    textBox1.Attributes.Add("onkeyup", string.Concat("AllowNumber(this,this.value);CallonBlur(this.value,'spn_InkValue_", i, "');"));
                    textBox2.Attributes.Add("onkeyup", string.Concat("AllowNumber(this,this.value);ToInteger(this,this.value);CallonBlur(this.value,'spn_InkValue_", i, "');"));
                    textBox3.Attributes.Add("onkeyup", "AllowNumber(this,this.value);CallonBlur(this.value,'Spn_Setupcostreq');IsDecimalValue(this.value,'Spn_Setupcost');");
                    textBox3.Attributes.Add("style", "text-align:right");
                    textBox3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox3.Text), 0, "", false, false, true);
                }
                this.obj.Bind_Stock_Category(this.ddlInvCategory, this.CompanyID, "--- Select ---");
                bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
                if (ConnectionClass.Is_Non_Printing_System)
                {
                    for (int j = 0; j < this.ddlInvCategory.Items.Count; j++)
                    {
                        if (this.ddlInvCategory.Items[j].Text.ToLower() == "ink" || this.ddlInvCategory.Items[j].Text.ToLower() == "inks" || this.ddlInvCategory.Items[j].Text.ToLower() == "plates" || this.ddlInvCategory.Items[j].Text.ToLower() == "plate" || this.ddlInvCategory.Items[j].Text.ToLower() == "paper")
                        {
                            this.ddlInvCategory.Items.Remove(this.ddlInvCategory.Items[j]);
                            j--;
                        }
                    }
                }
                int num = 1;
                if (num < this.ddlInvCategory.Items.Count)
                {
                    this.ddlInvCategory.Items[num].Attributes.Add("class", " ");
                }

                //Ticket 80178
                DataTable dataTable = SettingsBasePage.settings_system_markup_select(this.CompanyID);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Inks"].ToString()), 2, "", false, false, true);
                }
            }
            if (!base.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat(" javascript:ShowCategoryWise(", this.ddlInvCategory.ClientID, ");"), true);
            }
            this.objComp.company_supplier_select(this.CompanyID, this.ddlSupplier);
            this.ddlSupplier.Items[0].Text = string.Concat("--- ", this.objlang.GetLanguageConversion("Select"), " ---");
            if (base.Request.QueryString["suplrid"] != null)
            {
                DropDownList dropDownList = this.ddlSupplier;
                long num1 = Convert.ToInt64(base.Request.QueryString["suplrid"]);
                dropDownList.SelectedValue = num1.ToString();
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/inkselector.aspx"))
            {
                this.btnDelete.Visible = false;
            }
            this.lblBasisweightType.Text = this.objPage.GetRegionalSettings(this.CompanyID, "Weight");
            this.lblBasisweightType.Text = this.lblBasisweightType.Text.ToUpper();
            this.lblColour.Text = this.objPage.GetRegionalSettings(this.CompanyID, "Colour");
            //this.lblWidthType.Text = this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.hid_PaperWidthType.Value = this.lblWidthType.Text;
            this.PaprMeasure = this.lblBasisweightType.Text;
            this.InvCode = this.obj.warehouse_code_select(this.CompanyID, "i");
            foreach (DataRow row in this.obj.settings_inventoryproperties_name_select(this.CompanyID).Rows)
            {
                this.PropertyValue = row["Properties"].ToString();
                this.SubcatValue = row["Subcategories"].ToString();
                this.PropertyConcat = string.Concat(this.PropertyValue, "µ");
                this.hid_Properties.Value = string.Concat(this.hid_Properties.Value, this.PropertyConcat);
                this.hid_SubCategoryName.Value = string.Concat(this.hid_SubCategoryName.Value, this.SubcatValue);
            }
            if (!base.IsPostBack)
            {
                this.hid_ddlPrintSheetSize.Value = EstimateBasePage.Paper_Size_Select(this.CompanyID);
                string[] strArrays = this.hid_ddlPrintSheetSize.Value.Split(new char[] { 'µ' });
                if (!string.IsNullOrEmpty(this.hid_ddlPrintSheetSize.Value.Trim()))
                {
                    for (int k = 0; k < (int)strArrays.Length; k++)
                    {
                        string[] strArrays1 = strArrays[k].Split(new char[] { '±' });
                        ListItem listItem1 = new ListItem()
                        {
                            Text = this.objBase.SpecialDecode(strArrays1[1]),
                            Value = strArrays1[0]
                        };
                        this.ddlPaperSize.Items.Insert(k, listItem1);
                        this.ddlPaperSize.Items[k].Attributes.Add("class", "");
                    }
                }
                this.ddlPaperSize.Items.Insert(0, string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---"));
                this.ddlPaperSize.Items[0].Text = string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---");
                this.ddlPaperSize.Items[0].Value = "0";
                this.txtInvCode.Text = string.Concat("INV", this.InvCode.ToString().Substring(1, this.InvCode.ToString().Length - 1));
                if (base.Request.QueryString["type"] == null)
                {
                    this.divArchivelnk.Visible = false;
                    this.ddlPaperType.Enabled = true;
                    this.ddlInkType.Enabled = true;
                    this.divHistoryforedit.Visible = false;
                    this.btnStay_new.Visible = false;
                    this.btnStay.Visible = false;
                }
                else
                {
                    this.type = base.Request.QueryString["type"].ToString().ToLower();
                    if (this.type == "edit")
                    {
                        this.InventoryID = Convert.ToInt64(base.Request.QueryString["id"].ToString());
                        this.btnStay.Visible = true;
                        this.btnStay_new.Visible = true;
                        if (base.Request.Params["sta"] != null && base.Request.Params["sta"].ToString().ToLower() == "y")
                        {
                            BaseClass baseClass1 = new BaseClass();
                            baseClass1.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Saved_Successfully"), "msg-success", this.plhMessage);
                        }
                        if (this.InventoryManagement != "IM")
                        {
                            this.divQtyToAdjusted.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            this.Label45.Text = this.objLangClass.GetLanguageConversion("In_Stock_Qty");
                            this.divAvailableQty.Attributes.Add("style", "display:block");
                            string str2 = this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "others", this.Page.Request.Url.ToString());
                            if (str2 == "0" || str2 == "2")
                            {
                                this.divQtyToAdjusted.Attributes.Add("style", "display:none");
                                this.divQtyAdjustment.Attributes.Add("style", "display:none");
                                this.divReasonadjustment.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                this.divQtyToAdjusted.Attributes.Add("style", "display:block");
                                this.divQtyAdjustment.Attributes.Add("style", "display:block");
                                this.divReasonadjustment.Attributes.Add("style", "display:block");
                            }
                        }
                        this.divAllocatedQty.Attributes.Add("style", "display:block");
                        this.txtAllocatedQty.Enabled = false;
                        this.txtAvailableQty.Enabled = false;
                        this.txtInStock.Enabled = false;
                        this.divHistoryforedit.Visible = true;
                        try
                        {
                            if (this.InventoryID != (long)0)
                            {
                                DropDownList dropDownList1 = this.ddlAccountCode;
                                int num2 = InventoryBasePage.Inventory_AccountingCode_Select((long)this.CompanyID, this.InventoryID);
                                dropDownList1.SelectedValue = num2.ToString();
                            }
                        }
                        catch
                        {
                        }
                        this.btnDelete.Visible = true;
                        foreach (DataRow dataRow in this.obj.warehouse_inventory_select(this.CompanyID, this.InventoryID).Rows)
                        {
                            this.txtInvName.Text = this.objBase.SpecialDecode(dataRow["InventoryName"].ToString());
                            this.txt_UserFriendlyName.Text = this.objBase.SpecialDecode(dataRow["FriendlyName"].ToString());
                            this.txtInvCode.Text = this.objBase.SpecialDecode(dataRow["InventoryCode"].ToString());
                            inventory_add.ItemName = dataRow["InventoryName"].ToString();
                            this.ddlInvCategory.SelectedValue = dataRow["InventoryCategoryID"].ToString();
                            if (string.Compare(this.ddlInvCategory.SelectedItem.Text, "Inks", true) == 0)
                            {
                                this.ddlPaperSize.SelectedIndex = 1;
                            }
                            this.txtdescription.Text = this.objBase.SpecialDecode(dataRow["Description"].ToString());
                            this.txtInvLocation.Text = this.objBase.SpecialDecode(dataRow["Location"].ToString());
                            if (dataRow["IsArchived"].ToString() == "True")
                            {
                                this.divArchivelnk.Visible = true;
                                this.btnArchive.Visible = false;
                            }
                            else if (dataRow["IsArchived"].ToString() == "False")
                            {
                                this.divArchivelnk.Visible = false;
                                this.btnArchive.Visible = true;
                            }
                            if (base.Request.QueryString["suplrid"] == null)
                            {
                                this.ddlSupplier.SelectedValue = dataRow["SupplierID"].ToString();
                            }
                            else
                            {
                                DropDownList dropDownList2 = this.ddlSupplier;
                                long num3 = Convert.ToInt64(base.Request.QueryString["suplrid"]);
                                dropDownList2.SelectedValue = num3.ToString();
                            }
                            if (this.ddlInvCategory.SelectedItem.Text == "Inks" || this.ddlInvCategory.SelectedItem.Text == "inks" || this.ddlInvCategory.SelectedItem.Text == "Ink" || this.ddlInvCategory.SelectedItem.Text == "ink")
                            {
                                this.txtInStock.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["InStock"].ToString()), 2, "", false, false, true);
                                this.txtInStock.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.txtInStock.Text);
                            }
                            else
                            {
                                this.txtInStock.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["InStock"].ToString()), 2, "", false, false, true);
                                this.txtInStock.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.txtInStock.Text);
                            }
                            if (this.ddlInvCategory.SelectedItem.Text == "Inks" || this.ddlInvCategory.SelectedItem.Text == "inks" || this.ddlInvCategory.SelectedItem.Text == "Ink" || this.ddlInvCategory.SelectedItem.Text == "ink")
                            {
                                this.txtReorderLevel.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ReorderLevel"].ToString()), 0, "", false, false, true);
                            }
                            else
                            {
                                this.txtReorderLevel.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ReorderLevel"].ToString()), 0, "", true, false, true);
                            }
                            this.txtReorderQty.Text = dataRow["ReOrderQuantity"].ToString();
                            this.txtAllocatedQty.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["AllocatedQty"].ToString()), 0, "", false, false, true);
                            this.txtAllocatedQty.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.txtAllocatedQty.Text);
                            this.txtAvailableQty.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtInStock.Text) - Convert.ToDecimal(this.txtAllocatedQty.Text), 0, "", false, false, true);
                            this.hdnAvailableQty.Value = this.txtAvailableQty.Text;
                            this.txtAvailableQty.Text = this.comm.ToRemoveDecimalPlacesIfZero(this.txtAvailableQty.Text);
                            if (dataRow["alertType"].ToString().ToLower() == "e")
                            {
                                this.chkReorderLevelEveryTime.Checked = true;
                                this.chkReorderLevelDaily.Checked = false;
                                this.rdoNone.Checked = false;
                            }
                            else if (dataRow["alertType"].ToString().ToLower() != "o")
                            {
                                this.chkReorderLevelDaily.Checked = false;
                                this.chkReorderLevelEveryTime.Checked = false;
                                this.rdoNone.Checked = true;
                            }
                            else
                            {
                                this.chkReorderLevelDaily.Checked = true;
                                this.chkReorderLevelEveryTime.Checked = false;
                                this.rdoNone.Checked = false;
                            }
                            this.txtemail.Text = this.objBase.SpecialDecode(dataRow["alertEmailID"].ToString());
                            if (this.txtemail.Text == " ")
                            {
                                this.txtemail.Text = this.objBase.SpecialDecode(InventoryBasePage.GetUserEmail(this.CompanyID, this.UserID));
                            }
                            if (dataRow["IsLargeFormatMaterial"].ToString().ToLower() != "true")
                            {
                                continue;
                            }
                            this.chk_LargeFormatMaterial.Checked = true;
                        }
                        string _caliper = string.Empty;
                        foreach (DataRow row1 in this.obj.warehouse_inventoryproperties_select(this.CompanyID, this.InventoryID).Rows)
                        {
                            this.txtCost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Cost"].ToString()), 0, "", false, false, false);
                            if (this.ddlInvCategory.SelectedItem.Text == "Inks" || this.ddlInvCategory.SelectedItem.Text == "inks" || this.ddlInvCategory.SelectedItem.Text == "Ink" || this.ddlInvCategory.SelectedItem.Text == "ink")
                            {
                                this.txtPackedIn.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PackedIn"].ToString()), 0, "", false, false, false);
                                this.txtPer.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PerQuantity"].ToString()), 0, "", false, false, false);
                            }
                            else
                            {
                                this.txtPackedIn.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PackedIn"].ToString()), 0, "", true, false, false);
                                this.txtPer.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PerQuantity"].ToString()), 0, "", true, false, false);
                            }
                            this.txtPackedPrice.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PackedPrice"].ToString()), 0, "", false, false, false);

                            if (ddlInvCategory.SelectedItem.Text.Equals("Inks"))
                                this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["InkMarkup"].ToString()), 0, "", false, false, false);
                            else if (ddlInvCategory.SelectedItem.Text.Equals("Paper"))
                                this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PaperMarkup"].ToString()), 0, "", false, false, false);
                            else 
                                this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["InventoryItemMarkup"].ToString()), 0, "", false, false, false);

                            this.txtProcessCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ProcessCharge"].ToString()), 0, "", false, false, false);
                            this.txtSellingPrice.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["SellingPrice"].ToString()), 0, "", false, false, false);
                            this.lblCostPerReel.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["CostPerReel"].ToString()), 0, "", false, false, false);
                            this.ddlPaperSize.SelectedValue = row1["PaperSizeID"].ToString();
                            this.txtPaperHeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Height"].ToString()), this.DecimalPaperSize, "", false, false, false);
                            this.txtPaperWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Width"].ToString()), this.DecimalPaperSize, "", false, false, false);
                            //this.lblWidthType.Text = row1["WidthType"].ToString();
                            this.txtWebWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Width"].ToString()), 0, "", false, false, false);
                            this.txtWebLength.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Length"].ToString()), 0, "", false, false, false);
                            this.txtBasisWeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BasisWeight"].ToString()), 0, "", false, false, false);
                            if(string.IsNullOrEmpty(row1["Caliper"].ToString()))
                            {
                                _caliper = "0.0000";
                            }
                            else
                            {
                                _caliper = row1["Caliper"].ToString();
                            }
                            this.txtCaliper.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(_caliper), 4, "", false, false, false);
                            this.ddlCoated.SelectedValue = row1["Coated"].ToString();
                            this.txtColour.Text = this.objBase.SpecialDecode(row1["Colour"].ToString());
                            this.ddlPaperType.SelectedValue = row1["PaperType"].ToString();
                            if (this.ddlPaperType.SelectedValue.ToLower() == "web printing")
                            {
                                string regionalSpelling = this.objPage.GetRegionalSettings(this.CompanyID, "Metre");
                                this.divRollStockQty.Attributes.Add("style", "display:block; width:30%;");
                                this.divRollStockQtyContainer.Attributes.Add("style", "display:block; width:150px;");
                                string baseText3 = this.Label3.Text;
                                this.Label3.Text = baseText3.Replace("Meters", regionalSpelling);
                                string baseText45 = this.objLangClass.GetLanguageConversion("Instock_Qty_Roll");
                                this.Label45.Text = baseText45.Replace("Meters", regionalSpelling);
                                //this.Label45.Text = this.objLangClass.GetLanguageConversion("Instock_Qty_Roll");
                                string baseTextAQ = this.objLangClass.GetLanguageConversion("Available_Meters");
                                this.lblAvailableQty.Text = baseTextAQ.Replace("Meters", regionalSpelling);
                                //this.lblAvailableQty.Text = this.objLangClass.GetLanguageConversion("Available_Meters");
                                string baseText8 = this.objLangClass.GetLanguageConversion("Allocated_Meters");
                                this.Label8.Text = baseText8.Replace("Meters", regionalSpelling);
                                //this.Label8.Text = this.objLangClass.GetLanguageConversion("Allocated_Meters");
                                string baseText46 = this.objLangClass.GetLanguageConversion("ReOrder_Alert_Level_Meters");
                                this.Label46.Text = baseText46.Replace("Meters", regionalSpelling);
                                //this.Label46.Text = this.objLangClass.GetLanguageConversion("ReOrder_Alert_Level_Meters");
                                string baseText47 = this.objLangClass.GetLanguageConversion("Meters_ReOrder_Quantity");
                                this.Label47.Text = baseText47.Replace("Meters", regionalSpelling);
                                //this.Label47.Text = this.objLangClass.GetLanguageConversion("ReOrder_Quantity_Meters");
                                this.txtRollStockQty.Text = this.txtWebLength.Text;
                                string baseTextAdj = this.objLangClass.GetLanguageConversion("Qty_To_Be_Adjusted_Meters");
                                this.lblQtyToBeAdjusted.Text = baseTextAdj.Replace("Meters", regionalSpelling);
                                //this.lblQtyToBeAdjusted.Text = this.objLangClass.GetLanguageConversion("Qty_To_Be_Adjusted_Meters");
                            }
                            this.txtInkAbsorption.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["InkAbsorption"].ToString()), 0, "", false, false, false);
                            this.txtWashup.Text = row1["WashupCounter"].ToString();
                            this.txtYield.Text = row1["Yield"].ToString();
                            this.ddlPackedIn.SelectedValue = row1["PackedInType"].ToString();
                            this.lblPackedIn.Text = row1["YieldType"].ToString();
                            this.hdnPackedIn.Value = row1["YieldType"].ToString();
                            this.ddlInkType.SelectedValue = row1["InkType"].ToString();
                            this.txtminimum.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["InkMinimumCost"].ToString()), 0, "", false, false, false);
                            for (int l = 0; l < this.ddlPackedIn.Items.Count; l++)
                            {
                                if (this.ddlPackedIn.Items[l].Value == row1["YieldType"].ToString())
                                {
                                    this.ddlPackedIn.SelectedIndex = l;
                                }
                            }
                            this.hid_packprice.Value = row1["PackedPrice"].ToString();
                            this.hid_sellingprice.Value = row1["SellingPrice"].ToString();
                            this.hid_costperreel.Value = row1["CostPerReel"].ToString();
                            this.hid_costperMtr.Value = row1["CostPerLinear"].ToString();
                            this.hid_perqty.Value = row1["PerQuantity"].ToString();
                        }
                        DataTable dataTable = new DataTable();
                        dataTable = InventoryBasePage.warehouse_inventoryinkMatrix_select(this.CompanyID, this.InventoryID);
                        int num4 = 1;
                        foreach (DataRow dataRow1 in dataTable.Rows)
                        {
                            HtmlGenericControl htmlGenericControl = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", num4));
                            TextBox str3 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", num4));
                            TextBox str4 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", num4));
                            TextBox textBox4 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", num4));
                            TextBox str5 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", num4));
                            TextBox textBox5 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                            HiddenField hiddenField = (HiddenField)this.DIV_TAKE_MATRIX.FindControl(string.Concat("hid_InkmatrixSheetsfromID_", num4));
                            hiddenField.Value = dataRow1["InkMatrixId"].ToString();
                            if (num4 != 5)
                            {
                                htmlGenericControl.InnerText = dataRow1["InventorySheetsFrom"].ToString();
                            }
                            else
                            {
                                htmlGenericControl.InnerText = string.Concat("+", dataRow1["InventorySheetsFrom"].ToString());
                            }
                            str3.Text = dataRow1["InventorySheetsFrom"].ToString();
                            str4.Text = dataRow1["InventorySheetsTo"].ToString();
                            textBox4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["ChargableCost"].ToString()), 0, "", false, false, false);
                            str5.Text = dataRow1["ChargableSheets"].ToString();
                            textBox5.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["SetUpCost"].ToString()), 0, "", false, false, false);
                            num4++;
                        }
                        if (Convert.ToInt32(this.ddlPaperSize.SelectedValue.ToString()) == 0)
                        {
                            this.chkCustom.Checked = true;
                            this.pnlChkCustomShow.Visible = true;
                        }
                        this.ddlPaperType.Enabled = false;
                        this.ddlInkType.Enabled = false;
                        this.ddlInvCategory.Enabled = false;
                        this.CatValue = this.ddlInvCategory.SelectedValue;
                        this.SubCatValue = this.SubCategoryID.ToString();
                        this.pnlLoadSubCat.Visible = true;
                    }
                }
            }
            if (base.Session["Values"] != null)
            {
                string str6 = base.Session["Values"].ToString();
                string[] strArrays2 = str6.Split(new char[] { ',' });
                this.txtInvName.Text = strArrays2[0].ToString();
                this.txtdescription.Text = strArrays2[1].ToString();
                this.objBase.SetDDLValue(this.ddlInvCategory, strArrays2[2]);
                ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm111111111111111", ";ShowCategoryWise1();", true);
                this.txtInvLocation.Text = strArrays2[3].ToString();
                this.txtInStock.Text = strArrays2[4].ToString();
                this.txtReorderLevel.Text = strArrays2[5].ToString();
                this.txtReorderQty.Text = strArrays2[6].ToString();
                this.txtCost.Text = strArrays2[7].ToString();
                this.txtPackedIn.Text = strArrays2[8].ToString();
                ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm11", "CalculatePackPrice(); CalSellingPrice(); ValidateCostPer();", true);
                this.objBase.SetDDLValue(this.ddlPaperType, strArrays2[10]);
                ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm11111111111", "ShowddlPaperType();", true);
                this.objBase.SetDDLValue(this.ddlPaperSize, strArrays2[11]);
                ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm11", "CallonChange(this.value,'spn_papersize');LoadToSheetCustom(this.value);", true);
                this.txtBasisWeight.Text = strArrays2[12].ToString();
                this.objBase.SetDDLValue(this.ddlCoated, strArrays2[13]);
                this.txtColour.Text = strArrays2[14].ToString();
                this.txtCost.Text = strArrays2[15].ToString();
                this.txtWebWidth.Text = strArrays2[16].ToString();
                this.txtWebLength.Text = strArrays2[17].ToString();
                this.txtPer.Text = strArrays2[18].ToString();
                this.txtPaperHeight.Text = strArrays2[19].ToString();
                this.txtPaperWidth.Text = strArrays2[20].ToString();
                this.chkCustom.Checked = Convert.ToBoolean(strArrays2[21].ToString());
                this.txtYield.Text = strArrays2[22].ToString();
                this.txtMarkup.Text = strArrays2[23].ToString();
                base.Session["Values"] = null;
            }
            this.txtInvName.Focus();
            if (base.Request.Url == null)
            {
                this.ImageButtonPlus.Visible = false;
                this.ImageButton8.Visible = true;
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("common"))
            {
                this.ImageButtonPlus.Visible = false;
                this.ImageButton8.Visible = true;
            }
            else
            {
                this.ImageButton8.Visible = false;
                this.ImageButtonPlus.Visible = true;
            }
            if (base.Request.QueryString["type"] != null)
            {
                if (base.Request.QueryString["type"].ToString().ToLower() == "invselector")
                {
                    if (base.Request.Params["item"].ToString().ToLower() == "paper" || base.Request.Params["item"].ToString().ToLower() == "ink" || base.Request.Params["item"].ToString().ToLower() == "plates")
                    {
                        this.colourPanel.Style.Add("display", "none");
                        this.Content.Attributes.Remove("class");
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("common/inventory_finishedgoods_add.aspx"))
                {
                    this.colourPanel.Style.Add("display", "none");
                    this.Content.Attributes.Remove("class");
                }
                else if (base.Request.Url.ToString().ToLower().Contains("common/inkselector.aspx"))
                {
                    this.colourPanel.Style.Add("display", "none");
                    this.Content.Attributes.Remove("class");
                }
                if (base.Request.QueryString["type"] == null)
                {
                    this.Content.Style.Add("margin-left", "-70px");
                }
            }
            if (base.Request.Params["inkcolor"] != null)
            {
                this.IsColororwhiteink = base.Request.Params["inkcolor"].ToString();
            }
        }

        protected void RadGrid1_SortCommand(object source, GridSortCommandEventArgs e)
        {
            GridSortExpression gridSortExpression = new GridSortExpression();
            switch (e.OldSortOrder)
            {
                case GridSortOrder.None:
                    {
                        gridSortExpression.FieldName = e.SortExpression;
                        gridSortExpression.SortOrder = GridSortOrder.Descending;
                        break;
                    }
                case GridSortOrder.Ascending:
                    {
                        gridSortExpression.FieldName = e.SortExpression;
                        gridSortExpression.SortOrder = (this.grdInventoryHistory.MasterTableView.AllowNaturalSort ? GridSortOrder.None : GridSortOrder.Descending);
                        e.Item.OwnerTableView.SortExpressions.AddSortExpression(gridSortExpression);
                        break;
                    }
                case GridSortOrder.Descending:
                    {
                        gridSortExpression.FieldName = e.SortExpression;
                        gridSortExpression.SortOrder = GridSortOrder.Ascending;
                        e.Item.OwnerTableView.SortExpressions.AddSortExpression(gridSortExpression);
                        break;
                    }
            }
            e.Canceled = true;
            this.grdInventoryHistory.Rebind();
        }

        protected void SaveClick(string ClickType)
        {
            string[] item;
            string empty = string.Empty;
            decimal num = new decimal(0);
            if (this.IsLargeMaterial.ToString() != "1" && base.Request.QueryString["PaperType"] != null)
            {
                if (base.Request.QueryString["PaperType"].ToLower() == "roll")
                {
                    this.ddlPaperType.SelectedValue = "web printing";
                }
                if (base.Request.QueryString["PaperType"].ToLower() == "sheet")
                {
                    this.ddlPaperType.SelectedValue = "sheet";
                }
            }
            if (this.txtReorderLevel.Text == "")
            {
                this.txtReorderLevel.Text = "0";
            }
            if (this.txtReorderQty.Text == "")
            {
                this.txtReorderQty.Text = "0";
            }
            if (this.hid_packprice.Value == "NaN" || this.hid_packprice.Value == "Infinity")
            {
                this.hid_packprice.Value = "0";
            }
            if (this.hid_sellingprice.Value == "NaN" || this.hid_sellingprice.Value == "Infinity")
            {
                this.hid_sellingprice.Value = "0";
            }
            if (this.txtPaperHeight.Text == "" || this.txtPaperHeight.Text == null)
            {
                this.txtPaperHeight.Text = "0";
            }
            if (this.txtPaperWidth.Text == "" || this.txtPaperWidth.Text == null)
            {
                this.txtPaperWidth.Text = "0";
            }
            num = (this.ddlPaperType.SelectedValue.ToLower() != "web printing" ? Convert.ToDecimal(this.txtPaperWidth.Text) : Convert.ToDecimal(this.txtWebWidth.Text));
            if (this.hdn_supplierID.Value != "")
            {
                this.ddlSelectSupID = Convert.ToInt32(this.hdn_supplierID.Value);
            }
            else if (base.Request.QueryString["suplrid"] != null)
            {
                this.ddlSelectSupID = Convert.ToInt32(base.Request.QueryString["suplrid"]);
            }
            else if (this.hdn_supplierid_frompopup.Value != "")
            {
                this.ddlSelectSupID = Convert.ToInt32(this.hdn_supplierid_frompopup.Value);
            }
            else if (base.Request.QueryString["id"] != null)
            {
                DataTable dataTable = this.obj.warehouse_inventory_select(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()));
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ddlSelectSupID = Convert.ToInt32(row["SupplierID"]);
                }
            }
            if (base.Request.Params["MaterialNo"] != null && base.Request.Params["MaterialNo"].ToString() != "")
            {
                this.MaterialNo = Convert.ToInt32(base.Request.Params["MaterialNo"].ToString());
            }
            if (base.Request.QueryString["type"] == null || base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_add.aspx?type=add&suplrid"))
            {
                int num1 = this.obj.warehouse_inventory_insert(this.CompanyID, this.objBase.SpecialEncode(this.txtInvName.Text), this.objBase.SpecialEncode(this.txt_UserFriendlyName.Text), this.objBase.SpecialEncode(this.txtInvCode.Text), Convert.ToInt32(this.ddlInvCategory.SelectedValue), this.objBase.SpecialEncode(this.txtdescription.Text), this.objBase.SpecialEncode(this.txtInvLocation.Text), this.ddlSelectSupID, Convert.ToDecimal(this.txtInStock.Text), Convert.ToDecimal(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), Convert.ToInt32(this.txtAllocatedQty.Text), this.chk_LargeFormatMaterial.Checked);
                if (num1 != -1)
                {
                    if (this.InventoryManagement == "IM")
                    {
                        this.comm.Insert_Activity_History_For_Inventory((long)num1, "Stock Opening Value", this.UserID, Convert.ToInt32(this.txtInStock.Text), "o", Convert.ToInt32(Convert.ToDecimal(this.txtInStock.Text)));
                        if (this.chkReorderLevelDaily.Checked || this.chkReorderLevelEveryTime.Checked)
                        {
                            if (!this.chkReorderLevelDaily.Checked)
                            {
                                InventoryBasePage.Inventory_InventoryAlerts_On_Insert_Update((long)num1, "e", this.objBase.SpecialEncode(this.txtemail.Text), " ");
                            }
                            else
                            {
                                InventoryBasePage.Inventory_InventoryAlerts_On_Insert_Update((long)num1, "o", this.objBase.SpecialEncode(this.txtemail.Text), " ");
                            }
                        }
                    }
                    if (this.AccountingCode == "d")
                    {
                        InventoryBasePage.Inventory_AccountingCode_Insert((long)this.CompanyID, (long)num1, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (string.Concat("INV", this.InvCode.ToString().Substring(1, this.InvCode.ToString().Length - 1)) == this.txtInvCode.Text.Trim())
                    {
                        this.obj.warehouse_code_update(this.CompanyID, "i", this.InvCode);
                    }
                    if (this.chkCustom.Checked)
                    {
                        this.ddlPaperSize.SelectedValue = "0";
                    }
                    //Ticket 80178 
                    if (string.IsNullOrEmpty(this.txtMarkup.Text))
                        this.txtMarkup.Text = "-1";
                    this.obj.warehouse_inventoryproperties_insert(this.CompanyID, num1, Convert.ToDecimal(this.txtCost.Text), Convert.ToDecimal(this.txtPer.Text), Convert.ToDecimal(this.txtPackedIn.Text), Convert.ToDecimal(this.hid_packprice.Value), Convert.ToDecimal(this.txtProcessCharge.Text), Convert.ToDecimal(this.hid_sellingprice.Value), Convert.ToDecimal(this.hid_costperreel.Value), Convert.ToInt32(this.ddlPaperSize.SelectedValue), Convert.ToDecimal(this.txtPaperHeight.Text), Convert.ToDecimal(num), this.hid_PaperWidthType.Value, Convert.ToDecimal(this.txtWebLength.Text), this.lblLengthType.Text, Convert.ToDecimal(this.txtBasisWeight.Text), this.ddlCoated.SelectedValue, this.objBase.SpecialEncode(this.txtColour.Text), this.ddlPaperType.SelectedValue, Convert.ToDecimal(this.txtInkAbsorption.Text), Convert.ToInt32(this.txtWashup.Text), Convert.ToDecimal(this.txtYield.Text), this.hdnPackedIn.Value, this.ddlPackedIn.SelectedValue, this.ddlInkType.SelectedValue, Convert.ToDecimal(this.txtminimum.Text), Convert.ToDecimal(this.hid_costperMtr.Value), Convert.ToDecimal(txtMarkup.Text), Convert.ToDecimal(this.txtCaliper.Text));
                    if (this.ddlInkType.SelectedValue == "M")
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            HtmlGenericControl htmlGenericControl = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", i));
                            TextBox textBox = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", i));
                            TextBox textBox1 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", i));
                            TextBox textBox2 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", i));
                            TextBox textBox3 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", i));
                            TextBox textBox4 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                            this.obj.warehouse_inventoryinkMatrix_insert(this.CompanyID, (long)num1, Convert.ToInt64(textBox.Text), Convert.ToInt64(textBox1.Text), Convert.ToDecimal(textBox2.Text), Convert.ToInt64(textBox3.Text), Convert.ToDecimal(textBox4.Text));
                        }
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory&suc=ins"));
                    return;
                }
                this.objBase.Message_Display(this.objlang.GetLanguageConversion("Inventory_Item_Name_Code_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                if (base.Request.QueryString["type"].ToString().ToLower() == "edit" && base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_add.aspx"))
                {
                    DataTable dataTable1 = this.obj.warehouse_inventory_select(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()));
                    if (dataTable1.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            this.txtInStock.Text = dataRow["InStock"].ToString();
                        }
                    }
                    if (this.InventoryManagement == "IM")
                    {
                        if (this.txtQtyToAdjusted.Text == "")
                        {
                            this.txtQtyToAdjusted.Text = "0";
                        }
                        if (this.txtAllocatedQty.Text == "")
                        {
                            this.txtAllocatedQty.Text = "0";
                        }
                        decimal num2 = new decimal(0);
                        if (this.ddlMinusPlus.SelectedItem.Value.ToLower() == "plus")
                        {
                            num2 = Convert.ToDecimal(this.txtInStock.Text) + Convert.ToDecimal(this.txtQtyToAdjusted.Text);
                            empty = "r";
                        }
                        if (this.ddlMinusPlus.SelectedItem.Value.ToLower() == "minus")
                        {
                            num2 = Convert.ToDecimal(this.txtInStock.Text) - Convert.ToDecimal(this.txtQtyToAdjusted.Text);
                            empty = "d";
                        }
                        this.txtInStock.Text = num2.ToString();
                    }
                    if (this.obj.warehouse_inventory_update(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()), this.objBase.SpecialEncode(this.txtInvName.Text), this.objBase.SpecialEncode(this.txt_UserFriendlyName.Text), this.objBase.SpecialEncode(this.txtInvCode.Text), Convert.ToInt32(this.ddlInvCategory.SelectedValue), this.objBase.SpecialEncode(this.txtdescription.Text), this.objBase.SpecialEncode(this.txtInvLocation.Text), this.ddlSelectSupID, Convert.ToDecimal(this.txtInStock.Text), Convert.ToDecimal(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), Convert.ToDecimal(this.txtAllocatedQty.Text), this.chk_LargeFormatMaterial.Checked) == -1)
                    {
                        this.objBase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Name_code_Already_Exists"), "msg-fail", this.plhMessage);
                        return;
                    }
                    if (this.InventoryManagement == "IM")
                    {
                        if (empty != null && this.txtQtyToAdjusted.Text != "0")
                        {
                            this.comm.Insert_Activity_History_For_Inventory(Convert.ToInt64(base.Request.QueryString["id"].ToString()), string.Concat(this.txtReasonadjustment.Text, "µ"), this.UserID, Convert.ToInt32(this.txtQtyToAdjusted.Text), empty, Convert.ToInt32(Convert.ToDecimal(this.txtInStock.Text)));
                        }
                        if (this.chkReorderLevelDaily.Checked)
                        {
                            InventoryBasePage.Inventory_InventoryAlerts_On_Insert_Update(Convert.ToInt64(base.Request.QueryString["id"].ToString()), "o", this.objBase.SpecialEncode(this.txtemail.Text), this.txtReasonadjustment.Text);
                        }
                        else if (!this.chkReorderLevelEveryTime.Checked)
                        {
                            InventoryBasePage.Inventory_InventoryAlerts_On_Insert_Update(Convert.ToInt64(base.Request.QueryString["id"].ToString()), "n", this.objBase.SpecialEncode(this.txtemail.Text), this.txtReasonadjustment.Text);
                        }
                        else
                        {
                            InventoryBasePage.Inventory_InventoryAlerts_On_Insert_Update(Convert.ToInt64(base.Request.QueryString["id"].ToString()), "e", this.objBase.SpecialEncode(this.txtemail.Text), this.txtReasonadjustment.Text);
                        }
                    }
                    if (this.AccountingCode == "d")
                    {
                        InventoryBasePage.Inventory_AccountingCode_Insert((long)this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()), int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (this.chkCustom.Checked)
                    {
                        this.ddlPaperSize.SelectedValue = "0";
                    }
                    long num3 = (long)0;
                    if (base.Request.QueryString["id"] != null)
                    {
                        num3 = Convert.ToInt64(base.Request.QueryString["id"].ToString());
                    }
                    decimal num4 = new decimal(0);
                    decimal.TryParse(this.txtCost.Text, out num4);
                    decimal num5 = new decimal(0);
                    decimal.TryParse(this.txtPer.Text, out num5);
                    decimal num6 = new decimal(0);
                    decimal.TryParse(this.txtPackedIn.Text, out num6);
                    decimal num7 = new decimal(0);
                    decimal.TryParse(this.hid_packprice.Value, out num7);
                    decimal num8 = new decimal(0);
                    decimal.TryParse(this.txtProcessCharge.Text, out num8);
                    decimal num9 = new decimal(0);
                    decimal.TryParse(this.hid_sellingprice.Value, out num9);
                    decimal num10 = new decimal(0);
                    decimal.TryParse(this.hid_costperreel.Value, out num10);
                    decimal num11 = new decimal(0);
                    decimal.TryParse(this.hid_costperMtr.Value, out num11);
                    decimal num12 = new decimal(0);
                    decimal.TryParse(this.txtWebLength.Text, out num12);
                    decimal num13 = new decimal(0);
                    decimal.TryParse(this.txtBasisWeight.Text, out num13);
                    decimal num14 = new decimal(0);
                    decimal.TryParse(this.txtInkAbsorption.Text, out num14);
                    decimal num15 = new decimal(0);
                    decimal.TryParse(this.txtYield.Text, out num15);
                    decimal num16 = new decimal(0);
                    decimal.TryParse(this.txtminimum.Text, out num16);
                    //Ticket 80178 
                    decimal num20 = new decimal(0);
                    if (string.IsNullOrEmpty(this.txtMarkup.Text))
                        this.txtMarkup.Text = "-1";
                    decimal.TryParse(this.txtMarkup.Text, out num20);

                    decimal num21 = new decimal(0);
                    decimal.TryParse(this.txtCaliper.Text, out num21);
                    this.obj.warehouse_inventoryproperties_update(this.CompanyID, num3, num4, num5, num6, num7, num8, num9, num10, Convert.ToInt32(this.ddlPaperSize.SelectedValue), decimal.Parse(this.txtPaperHeight.Text), num, this.hid_PaperWidthType.Value, num12, Convert.ToString(this.lblLengthType.Text), num13, Convert.ToString(this.ddlCoated.SelectedValue), Convert.ToString(this.objBase.SpecialEncode(this.txtColour.Text)), Convert.ToString(this.ddlPaperType.SelectedValue), num14, Convert.ToInt32(this.txtWashup.Text), num15, Convert.ToString(this.hdnPackedIn.Value), Convert.ToString(this.ddlPackedIn.SelectedValue), Convert.ToString(this.ddlInkType.SelectedValue), num16, num11, num20, num21);
                    if (this.ddlInkType.SelectedValue == "M")
                    {
                        for (int j = 1; j <= 5; j++)
                        {
                            HtmlGenericControl htmlGenericControl1 = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", j));
                            TextBox textBox5 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", j));
                            TextBox textBox6 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", j));
                            TextBox textBox7 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", j));
                            TextBox textBox8 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", j));
                            TextBox textBox9 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                            HiddenField hiddenField = (HiddenField)this.DIV_TAKE_MATRIX.FindControl(string.Concat("hid_InkmatrixSheetsfromID_", j));
                            long num17 = Convert.ToInt64(base.Request.Params["id"].ToString());
                            this.obj.warehouse_inventoryinkMatrix_Update(this.CompanyID, num17, Convert.ToInt64(hiddenField.Value), Convert.ToInt64(textBox5.Text), Convert.ToInt64(textBox6.Text), Convert.ToDecimal(textBox7.Text), Convert.ToInt64(textBox8.Text), Convert.ToDecimal(textBox9.Text));
                        }
                    }
                    if (ClickType.ToLower() != "stay")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory&suc=upd"));
                        return;
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id=", base.Request.Params["id"], "&sta=y"));
                    return;
                }
                if (base.Request.QueryString["type"].ToString().ToLower() == "invselector")
                {
                    if (base.Request.Params["item"].ToString().ToLower() == "ink")
                    {
                        if (base.Request.Params["InkType"].ToString().ToLower() != "m")
                        {
                            this.ddlInkType.SelectedValue = "Y";
                        }
                        else
                        {
                            this.ddlInkType.SelectedValue = "M";
                        }
                    }
                    int num18 = this.obj.warehouse_inventory_insert(this.CompanyID, this.objBase.SpecialEncode(this.txtInvName.Text), this.objBase.SpecialEncode(this.txt_UserFriendlyName.Text), this.objBase.SpecialEncode(this.txtInvCode.Text), Convert.ToInt32(this.hdn_InvCatID.Value), this.objBase.SpecialEncode(this.txtdescription.Text), this.objBase.SpecialEncode(this.txtInvLocation.Text), this.ddlSelectSupID, Convert.ToDecimal(this.txtInStock.Text), Convert.ToDecimal(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), Convert.ToInt32(this.txtAllocatedQty.Text), this.chk_LargeFormatMaterial.Checked);
                    this.Inventory_Name = this.objBase.ReplaceSingleQuote(this.txtInvName.Text);
                    this.Inventory_ID = num18;
                    if (num18 == -1)
                    {
                        this.objBase.Message_Display(this.objlang.GetLanguageConversion("Inventory_Item_Name_Code_Already_Exists"), "msg-fail", this.plhMessage);
                        return;
                    }
                    if (this.AccountingCode == "d")
                    {
                        InventoryBasePage.Inventory_AccountingCode_Insert((long)this.CompanyID, (long)num18, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (this.InventoryManagement == "IM")
                    {
                        this.comm.Insert_Activity_History_For_Inventory((long)num18, "Stock Opening Value", this.UserID, Convert.ToInt32(this.txtInStock.Text), "o", Convert.ToInt32(Convert.ToDecimal(this.txtInStock.Text)));
                    }
                    this.obj.warehouse_code_update(this.CompanyID, "i", this.InvCode);
                    if (this.chkCustom.Checked)
                    {
                        this.ddlPaperSize.SelectedValue = "0";
                    }
                    //Ticket 80178 
                    if (string.IsNullOrEmpty(this.txtMarkup.Text))
                        this.txtMarkup.Text = "-1";
                    this.obj.warehouse_inventoryproperties_insert(this.CompanyID, num18, Convert.ToDecimal(this.txtCost.Text), Convert.ToDecimal(this.txtPer.Text), Convert.ToDecimal(this.txtPackedIn.Text), Convert.ToDecimal(this.hid_packprice.Value), Convert.ToDecimal(this.txtProcessCharge.Text), Convert.ToDecimal(this.hid_sellingprice.Value), Convert.ToDecimal(this.hid_costperreel.Value), Convert.ToInt32(this.ddlPaperSize.SelectedValue), Convert.ToDecimal(this.txtPaperHeight.Text), Convert.ToDecimal(num), this.hid_PaperWidthType.Value, Convert.ToDecimal(this.txtWebLength.Text), this.lblLengthType.Text, Convert.ToDecimal(this.txtBasisWeight.Text), this.ddlCoated.SelectedValue, this.objBase.SpecialEncode(this.txtColour.Text), this.ddlPaperType.SelectedValue, Convert.ToDecimal(this.txtInkAbsorption.Text), Convert.ToInt32(this.txtWashup.Text), Convert.ToDecimal(this.txtYield.Text), this.hdnPackedIn.Value, this.ddlPackedIn.SelectedValue, this.ddlInkType.SelectedValue, Convert.ToDecimal(this.txtminimum.Text), Convert.ToDecimal(this.hid_costperMtr.Value), Convert.ToDecimal(txtMarkup.Text), Convert.ToDecimal(this.txtCaliper.Text));
                    if ((base.Request.Params["item"].ToString().ToLower() == "ink" || base.Request.Params["item"].ToString().ToLower() == "inks") && this.ddlInkType.SelectedValue == "M")
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int k = 1; k <= 5; k++)
                        {
                            HtmlGenericControl htmlGenericControl2 = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", k));
                            TextBox textBox10 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", k));
                            TextBox textBox11 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", k));
                            TextBox textBox12 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", k));
                            TextBox textBox13 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", k));
                            TextBox textBox14 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                            if (base.Request.QueryString["type"] != null && base.Request.QueryString["type"].ToString().ToLower() != "edit")
                            {
                                this.obj.warehouse_inventoryinkMatrix_insert(this.CompanyID, (long)num18, Convert.ToInt64(textBox10.Text), Convert.ToInt64(textBox11.Text), Convert.ToDecimal(textBox12.Text), Convert.ToInt64(textBox13.Text), Convert.ToDecimal(textBox14.Text));
                            }
                        }
                    }
                    if (base.Request.Params["item"].ToString().ToLower() == "paper")
                    {
                        this.PaperTypeNew = this.ddlPaperType.SelectedValue;
                        this.pnl_SendPaperID_Name.Visible = true;
                        return;
                    }
                    if (base.Request.Params["item"].ToString().ToLower() == "ink")
                    {
                        this.pnl_InventoryName.Visible = true;
                        return;
                    }
                    if (base.Request.Params["item"].ToString().ToLower() == "plates")
                    {
                        this.pnl_CloseParent.Visible = true;
                        return;
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("common/inkselector.aspx"))
                {
                    int num19 = this.obj.warehouse_inventory_insert(this.CompanyID, this.objBase.SpecialEncode(this.txtInvName.Text), this.objBase.SpecialEncode(this.txt_UserFriendlyName.Text), this.objBase.SpecialEncode(this.txtInvCode.Text), Convert.ToInt32(this.hdn_InvCatID.Value), this.objBase.SpecialEncode(this.txtdescription.Text), this.objBase.SpecialEncode(this.txtInvLocation.Text), this.ddlSelectSupID, Convert.ToDecimal(this.txtInStock.Text), Convert.ToDecimal(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), Convert.ToInt32(this.txtAllocatedQty.Text), this.chk_LargeFormatMaterial.Checked);
                    if (num19 != -1)
                    {
                        if (this.InventoryManagement == "IM")
                        {
                            this.comm.Insert_Activity_History_For_Inventory((long)num19, "Stock Opening Value", this.UserID, Convert.ToInt32(this.txtInStock.Text), "o", Convert.ToInt32(Convert.ToDecimal(this.txtInStock.Text)));
                        }
                        this.obj.warehouse_code_update(this.CompanyID, "i", this.InvCode);
                        if (this.chkCustom.Checked)
                        {
                            this.ddlPaperSize.SelectedValue = "0";
                        }
                        //Ticket 80178 
                        if (string.IsNullOrEmpty(this.txtMarkup.Text))
                            this.txtMarkup.Text = "-1";
                        this.obj.warehouse_inventoryproperties_insert(this.CompanyID, num19, Convert.ToDecimal(this.txtCost.Text), Convert.ToDecimal(this.txtPer.Text), Convert.ToDecimal(this.txtPackedIn.Text), Convert.ToDecimal(this.hid_packprice.Value), Convert.ToDecimal(this.txtProcessCharge.Text), Convert.ToDecimal(this.hid_sellingprice.Value), Convert.ToDecimal(this.hid_costperreel.Value), Convert.ToInt32(this.ddlPaperSize.SelectedValue), Convert.ToDecimal(this.txtPaperHeight.Text), Convert.ToDecimal(num), this.hid_PaperWidthType.Value, Convert.ToDecimal(this.txtWebLength.Text), this.lblLengthType.Text, Convert.ToDecimal(this.txtBasisWeight.Text), this.ddlCoated.SelectedValue, this.objBase.SpecialEncode(this.txtColour.Text), this.ddlPaperType.SelectedValue, Convert.ToDecimal(this.txtInkAbsorption.Text), Convert.ToInt32(this.txtWashup.Text), Convert.ToDecimal(this.txtYield.Text), this.hdnPackedIn.Value, this.ddlPackedIn.SelectedValue, this.InkType, Convert.ToDecimal(this.txtminimum.Text), Convert.ToDecimal(this.hid_costperMtr.Value), Convert.ToDecimal(txtMarkup.Text), Convert.ToDecimal(this.txtCaliper.Text));
                        if (this.InkType == "M")
                        {
                            for (int l = 1; l <= 5; l++)
                            {
                                HtmlGenericControl htmlGenericControl3 = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", l));
                                TextBox textBox15 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", l));
                                TextBox textBox16 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", l));
                                TextBox textBox17 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", l));
                                TextBox textBox18 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", l));
                                TextBox textBox19 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                                this.obj.warehouse_inventoryinkMatrix_insert(this.CompanyID, (long)num19, Convert.ToInt64(textBox15.Text), Convert.ToInt64(textBox16.Text), Convert.ToDecimal(textBox17.Text), Convert.ToInt64(textBox18.Text), Convert.ToDecimal(textBox19.Text));
                            }
                        }
                        if (base.Request.Params["Esttype"] == "F" || base.Request.Params["Esttype"] == "D")
                        {
                            HttpResponse response = base.Response;
                            item = new string[] { this.strSitepath, "common/inkselector.aspx?cnt=", base.Request.Params["cnt"], "&id=", base.Request.Params["id"], "&type=", base.Request.Params["type"], "&EstItemID=", base.Request.Params["EstItemID"], "&side=", base.Request.Params["side"], "&ddlval=", base.Request.Params["ddlval"], "&Esttype=", base.Request.Params["Esttype"], "&Section=", base.Request.Params["Section"], "&sidenumber=", base.Request.Params["sidenumber"], "&InkType=", base.Request.Params["InkType"], "&suc=yes" };
                            response.Redirect(string.Concat(item));
                            return;
                        }
                        if (base.Request.Params["Esttype"] == "N" || base.Request.Params["Esttype"] == "K")
                        {
                            HttpResponse httpResponse = base.Response;
                            item = new string[] { this.strSitepath, "common/inkselector.aspx?cnt=", base.Request.Params["cnt"], "&id=", base.Request.Params["id"], "&type=", base.Request.Params["type"], "&EstItemID=", base.Request.Params["EstItemID"], "&side=", base.Request.Params["side"], "&ddlval=", base.Request.Params["ddlval"], "&EstimateLithoNCRItemID=", base.Request.Params["EstimateLithoNCRItemID"], "&EstimateLithobookletItemID=", base.Request.Params["EstimateLithobookletItemID"], "&Esttype=", base.Request.Params["Esttype"], "&Section=", base.Request.Params["Section"], "&sidenumber=", base.Request.Params["sidenumber"], "&InkType=", base.Request.Params["InkType"], "&suc=yes" };
                            httpResponse.Redirect(string.Concat(item));
                            return;
                        }
                    }
                }
                else if (base.Request.Url.ToString().ToLower().Contains("common/inventory_finishedgoods_add.aspx"))
                {
                    int num20 = this.obj.warehouse_inventory_insert(this.CompanyID, this.objBase.SpecialEncode(this.txtInvName.Text), this.objBase.SpecialEncode(this.txt_UserFriendlyName.Text), this.objBase.SpecialEncode(this.txtInvCode.Text), Convert.ToInt32(this.ddlInvCategory.SelectedValue), this.objBase.SpecialEncode(this.txtdescription.Text), this.objBase.SpecialEncode(this.txtInvLocation.Text), this.ddlSelectSupID, Convert.ToDecimal(this.txtInStock.Text), Convert.ToDecimal(this.txtReorderLevel.Text), Convert.ToInt32(this.txtReorderQty.Text), Convert.ToInt32(this.txtAllocatedQty.Text), this.chk_LargeFormatMaterial.Checked);
                    if (num20 != -1)
                    {
                        if (this.InventoryManagement == "IM")
                        {
                            this.comm.Insert_Activity_History_For_Inventory((long)num20, "Stock Opening Value", this.UserID, Convert.ToInt32(this.txtInStock.Text), "o", Convert.ToInt32(Convert.ToDecimal(this.txtInStock.Text)));
                        }
                        this.obj.warehouse_code_update(this.CompanyID, "i", this.InvCode);
                        if (this.chkCustom.Checked)
                        {
                            this.ddlPaperSize.SelectedValue = "0";
                        }
                        //Ticket 80178 
                        if (string.IsNullOrEmpty(this.txtMarkup.Text))
                            this.txtMarkup.Text = "-1";
                        this.obj.warehouse_inventoryproperties_insert(this.CompanyID, num20, Convert.ToDecimal(this.txtCost.Text), Convert.ToDecimal(this.txtPer.Text), Convert.ToDecimal(this.txtPackedIn.Text), Convert.ToDecimal(this.hid_packprice.Value), Convert.ToDecimal(this.txtProcessCharge.Text), Convert.ToDecimal(this.hid_sellingprice.Value), Convert.ToDecimal(this.hid_costperreel.Value), Convert.ToInt32(this.ddlPaperSize.SelectedValue), Convert.ToDecimal(this.txtPaperHeight.Text), Convert.ToDecimal(num), this.hid_PaperWidthType.Value, Convert.ToDecimal(this.txtWebLength.Text), this.lblLengthType.Text, Convert.ToDecimal(this.txtBasisWeight.Text), this.ddlCoated.SelectedValue, this.objBase.SpecialEncode(this.txtColour.Text), this.ddlPaperType.SelectedValue, Convert.ToDecimal(this.txtInkAbsorption.Text), Convert.ToInt32(this.txtWashup.Text), Convert.ToDecimal(this.txtYield.Text), this.hdnPackedIn.Value, this.ddlPackedIn.SelectedValue, this.ddlInkType.SelectedValue, Convert.ToDecimal(this.txtminimum.Text), Convert.ToDecimal(this.hid_costperMtr.Value), Convert.ToDecimal(txtMarkup.Text), Convert.ToDecimal(this.txtCaliper.Text));
                        if (this.ddlInkType.SelectedValue == "M")
                        {
                            for (int m = 1; m <= 5; m++)
                            {
                                HtmlGenericControl htmlGenericControl4 = (HtmlGenericControl)this.DIV_TAKE_MATRIX.FindControl(string.Concat("spnSheetsFrom", m));
                                TextBox textBox20 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsFrom", m));
                                TextBox textBox21 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtSheetsTo", m));
                                TextBox textBox22 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkChargableCost", m));
                                TextBox textBox23 = (TextBox)this.DIV_TAKE_MATRIX.FindControl(string.Concat("txtInkCostPer", m));
                                TextBox textBox24 = (TextBox)this.DIV_TAKE_MATRIX.FindControl("txtSetupCost");
                                this.obj.warehouse_inventoryinkMatrix_insert(this.CompanyID, (long)num20, Convert.ToInt64(textBox20.Text), Convert.ToInt64(textBox21.Text), Convert.ToDecimal(textBox22.Text), Convert.ToInt64(textBox23.Text), Convert.ToDecimal(textBox24.Text));
                            }
                        }
                    }
                    if (base.Request.Params["mode"] != null && base.Request.Params["page"] != null)
                    {
                        this.ProductType = "inventory";
                        this.pnlWinClose.Visible = true;
                        return;
                    }
                }
            }
        }

        protected void UnArchive_onclicklnk(object sender, EventArgs e)
        {
            this.InventoryID = Convert.ToInt64(base.Request.QueryString["id"].ToString());
            this.obj.warehouse_inventory_unarchive(this.CompanyID, Convert.ToInt64(base.Request.QueryString["id"].ToString()));
            this.objBase.Message_Display(this.objlang.GetLanguageConversion("Inventory Item Un-Archived Successfully"), "msg-fail", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/inventory_add.aspx?type=edit&id= ", this.InventoryID));
        }

      
    }
}