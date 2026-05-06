using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Prefligt;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;
using Ghostscript.NET.Processor;

namespace ePrint.ProductCatalogue
{
    public partial class ProductCatalogue_item : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private commonClass objJava = new commonClass();

        private Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        public languageClass objLanguage = new languageClass();

        public string strImagepath = global.imagePath();

        public string TemplatesitePath = global.TemplatesitePath();

        public string strSitePath = global.sitePath();

        public string EditableTemplate = ConnectionClass.EditableTemplate;

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int count;

        public int PageSize = 10000;

        public int PageIndex = 1;

        public int totalrec;

        public int sortcount;

        public int ProductCatalogueID;

        public int totalPublicNo;

        public int totalPublicNo_Selected;

        public bool UnitOfMeasureKey;

        public static string WebStore;

        public static string IsDecoration = ConnectionClass.IsDecoration;

        public string PageType = "g";

        public string lstValue = "no";

        public string action = "add";

        public string colorformat = string.Empty;

        public string pg = string.Empty;

        public string item = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string PaperMeasure = string.Empty;

        public string RedirectTo = string.Empty;

        private string MatrixType = string.Empty;

        public string CustomerType = string.Empty;

        public static int TempProductID;

        public static Hashtable htAdditionalGroup;

        public static string CompanyName;

        public static int pricecatalogid;

        public static int ManageStockPermission;

        public static string ChkIsEditable;

        public string Editable = "false";

        public long EstID;

        public long EstItemID;

        public string EstType = string.Empty;

        public string pgFrom = string.Empty;

        public string ServerName = string.Empty;

        public string SecDocumentSitePath = string.Empty;

        public string Measurementvalue = string.Empty;

        public string Measurementvalue2 = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long ModuleId;

        public string WebStorePathB2C = ConnectionClass.B2CURL;

        private BaseClass objBaseClass = new BaseClass();

        public long productCatalogID;

        public Preflight_documents objPreFlight = new Preflight_documents();

        public bool IsStockExist;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<ProductCatalogue_item.CouponCodes> AvaliableCouponCodes
        {
            get
            {
                IList<ProductCatalogue_item.CouponCodes> couponCodes;
                try
                {
                    object item = this.Session["AvaliableCouponCodes"];
                    if (item == null)
                    {
                        item = this.GetAvaliableCouponCodes();
                        if (item == null)
                        {
                            item = new List<ProductCatalogue_item.CouponCodes>();
                        }
                        else
                        {
                            this.Session["AvaliableCouponCodes"] = item;
                        }
                    }
                    couponCodes = (IList<ProductCatalogue_item.CouponCodes>)item;
                }
                catch
                {
                    this.Session["AvaliableCouponCodes"] = null;
                    return new List<ProductCatalogue_item.CouponCodes>();
                }
                return couponCodes;
            }
            set
            {
                this.Session["AvaliableCouponCodes"] = value;
            }
        }

        protected IList<ProductCatalogue_item.OrderNew> PendingOrders
        {
            get
            {
                IList<ProductCatalogue_item.OrderNew> orderNews;
                try
                {
                    object item = this.Session["WebOtherCostPendingOrders"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<ProductCatalogue_item.OrderNew>();
                        }
                        else
                        {
                            this.Session["WebOtherCostPendingOrders"] = item;
                        }
                    }
                    orderNews = (IList<ProductCatalogue_item.OrderNew>)item;
                }
                catch
                {
                    this.Session["WebOtherCostPendingOrders"] = null;
                    return new List<ProductCatalogue_item.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["WebOtherCostPendingOrders"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        protected IList<ProductCatalogue_item.CouponCodes> SelectedCouponCodes
        {
            get
            {
                IList<ProductCatalogue_item.CouponCodes> couponCodes;
                try
                {
                    object item = this.Session["SelectedCouponCodes"];
                    if (item == null)
                    {
                        item = this.GetSelectedCouponCodes();
                        if (item == null)
                        {
                            item = new List<ProductCatalogue_item.CouponCodes>();
                        }
                        else
                        {
                            this.Session["SelectedCouponCodes"] = item;
                        }
                    }
                    couponCodes = (IList<ProductCatalogue_item.CouponCodes>)item;
                }
                catch
                {
                    this.Session["SelectedCouponCodes"] = null;
                    return new List<ProductCatalogue_item.CouponCodes>();
                }
                return couponCodes;
            }
            set
            {
                this.Session["SelectedCouponCodes"] = value;
            }
        }
        

        protected IList<ProductCatalogue_item.OrderNew> ShippedOrders
        {
            get
            {
                int productId = Convert.ToInt32(Request.Params["id"]); // pulled from ?id=123 in URL
                string sessionKey = $"WebOtherCostShippedOrders_{productId}";

                try
                {
                    object item = this.Session[sessionKey];
                    if (item == null)
                    {
                        item = this.GetShippingOrders(productId);
                        if (item == null)
                            item = new List<ProductCatalogue_item.OrderNew>();

                        this.Session[sessionKey] = item;
                    }

                    return (IList<ProductCatalogue_item.OrderNew>)item;
                }
                catch
                {
                    this.Session[sessionKey] = null;
                    return new List<ProductCatalogue_item.OrderNew>();
                }
            }
            set
            {
                int productId = Convert.ToInt32(Request.Params["id"]);
                string sessionKey = $"WebOtherCostShippedOrders_{productId}";
                this.Session[sessionKey] = value;
            }
        }



        static ProductCatalogue_item()
        {
            ProductCatalogue_item.WebStore = string.Empty;
            ProductCatalogue_item.TempProductID = 0;
            ProductCatalogue_item.htAdditionalGroup = new Hashtable();
            ProductCatalogue_item.CompanyName = string.Empty;
            ProductCatalogue_item.pricecatalogid = 0;
            ProductCatalogue_item.ManageStockPermission = 0;
            ProductCatalogue_item.ChkIsEditable = "false";
        }

        public ProductCatalogue_item()
        {
        }

        public void Activity_history_for_Productcataloge()
        {
            DataTable dataTable = new DataTable();
            notesclass _notesclass = new notesclass();
            Notes note = new Notes();
            commonClass _commonClass = new commonClass();
            if (this.pgFrom.ToLower() == "job")
            {
                dataTable = EstimatesBasePage.Select_Item_Number_Title_basedonModule(this.CompanyID, this.EstItemID, this.pgFrom.ToLower());
                _notesclass.Item_number = dataTable.Rows[0]["JobItemNumber"].ToString();
                _notesclass.Item_title = this.objBaseClass.SpecialDecode(dataTable.Rows[0]["ItemTitle"].ToString());
                _notesclass.ModuleName = "Job";
                if (this.action != "edit")
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobitemProcreated);
                }
                else
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.JobitemProUpdated);
                }
            }
            else if (this.pgFrom.ToLower() != "invoice")
            {
                dataTable = EstimatesBasePage.Select_Item_Number_Title_basedonModule(this.CompanyID, this.EstItemID, this.pgFrom.ToLower());
                _notesclass.Item_number = dataTable.Rows[0]["EstimateItemNumber"].ToString();
                _notesclass.Item_title = this.objBaseClass.SpecialDecode(dataTable.Rows[0]["ItemTitle"].ToString());
                _notesclass.ModuleID = this.EstID;
                _notesclass.ModuleName = "Estimate";
                if (this.action != "edit")
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.EstitemProcreated);
                }
                else
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.EstitemProUpdated);
                }
            }
            else
            {
                dataTable = EstimatesBasePage.Select_Item_Number_Title_basedonModule(this.CompanyID, this.EstItemID, this.pgFrom.ToLower());
                _notesclass.Item_number = dataTable.Rows[0]["InvoiceItemNumber"].ToString();
                _notesclass.Item_title = this.objBaseClass.SpecialDecode(dataTable.Rows[0]["ItemTitle"].ToString());
                _notesclass.ModuleID = this.InvoiceID;
                _notesclass.ModuleName = "Invoice";
                if (this.action != "edit")
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.InvitemProcreated);
                }
                else
                {
                    _notesclass.NotesType = Convert.ToString(Notes.NotesType.InvitemProUpdated);
                }
            }
            _notesclass.Product_code = base.SpecialEncode(this.txtitemcode.Text);
            _notesclass.Product_title = base.SpecialEncode(this.txtCatalogueName.Text);
            _notesclass.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            _notesclass.CompanyID = this.CompanyID;
            _notesclass.UserID = this.UserID;
            _notesclass.ItemID = this.EstItemID;
            note.NotesAdd(_notesclass);
        }

        protected void BindGroup(string BindType)
        {
            if (this.action != "add")
            {
                ProductCatalogue_item.TempProductID = this.ProductCatalogueID;
            }
            else if (ProductCatalogue_item.TempProductID != 0)
            {
                ProductCatalogue_item.TempProductID = Convert.ToInt32(ProductCatalogue_item.TempProductID);
            }
            string empty = string.Empty;
            DataTable dataTable = WebstoreBasePage.AdditionalGroup_select((long)ProductCatalogue_item.TempProductID);
            this.ddlGroup.DataSource = dataTable;
            this.ddlGroup.DataTextField = "GroupName";
            this.ddlGroup.DataValueField = "AdditionalGroupID";
            this.ddlGroup.DataBind();
            int count = this.ddlGroup.Items.Count - 1;
            this.ddlGroup.Items.Insert(count + 1, "-----------------");
            this.ddlGroup.Items[count + 1].Text = "-----------------";
            this.ddlGroup.Items[count + 1].Value = "-1";
            this.ddlGroup.Items.Insert(count + 2, "Create New");
            this.ddlGroup.Items[count + 2].Text = "Create New";
            this.ddlGroup.Items[count + 2].Value = "-2";
            if (dataTable.Rows.Count != 0)
            {
                this.div_grpEdit.Style.Add("display", "block");
                this.div_grpAdd.Style.Add("display", "none");
                this.ddlGroup.SelectedIndex = 0;
                return;
            }
            this.div_grpEdit.Style.Add("display", "none");
            this.div_grpAdd.Style.Add("display", "block");
            this.ddlGroup.SelectedIndex = count + 2;
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (this.pgFrom.ToLower() == "estimate")
            {
                HttpResponse response = base.Response;
                object[] estID = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                response.Redirect(string.Concat(estID));
                return;
            }
            if (this.pgFrom.ToLower() == "job")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.pgFrom.ToLower() != "invoice")
            {
                if (this.RedirectTo == "crm")
                {
                    this.RedirectTOCRM();
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/pricecatalogue.aspx", this.jID, this.InvID));
                return;
            }
            HttpResponse response1 = base.Response;
            object[] estID1 = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
            response1.Redirect(string.Concat(estID1));
        }

        protected void btnCategorySave_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.btnCategorySave.Text, "save", true) != 0)
            {
                string.Compare(this.btnCategorySave.Text, "update", true);
            }
            else
            {
                int num = SettingsBasePage.PriceCatalogue_Category_Insert(this.CompanyID, base.ReplaceSingleQuote(this.txtPriceCatalogueCategoryName.Text));
                if (num <= 0)
                {
                    for (int i = 0; i < this.ddlPriceCatalogueCategory.Items.Count; i++)
                    {
                        if (this.ddlPriceCatalogueCategory.Items[i].Text == base.ReplaceSingleQuote(this.txtPriceCatalogueCategoryName.Text))
                        {
                            this.ddlPriceCatalogueCategory.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    SettingsBasePage.PriceCatalogue_Category_Select(this.CompanyID, this.ddlPriceCatalogueCategory);
                    this.ddlPriceCatalogueCategory.Items.Insert(0, " ");
                    this.ddlPriceCatalogueCategory.Items[0].Text = "--- Select Category ---";
                    this.ddlPriceCatalogueCategory.Items[0].Value = "0";
                    this.ddlPriceCatalogueCategory.SelectedValue = num.ToString();
                }
            }
            this.txtPriceCatalogueCategoryName.Text = "";
        }

        protected void btnCouponCodeMove_Click(object sender, EventArgs e)
        {
            IList<ProductCatalogue_item.CouponCodes> avaliableCouponCodes = this.AvaliableCouponCodes;
            IList<ProductCatalogue_item.CouponCodes> selectedCouponCodes = this.SelectedCouponCodes;
            if (base.Request.Cookies["CouponCodeMove"] != null)
            {
                string[] strArrays = base.Request.Cookies["CouponCodeMove"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogue_item.CouponCodes couponCode = ProductCatalogue_item.GetCouponCode(avaliableCouponCodes, Convert.ToInt64(strArrays[i].ToString()));
                        if (couponCode != null)
                        {
                            selectedCouponCodes.Add(couponCode);
                            avaliableCouponCodes.Remove(couponCode);
                        }
                    }
                }
            }
            this.SelectedCouponCodes = selectedCouponCodes;
            this.AvaliableCouponCodes = avaliableCouponCodes;
            this.GridAvaialbleCoupncodes.Rebind();
            this.GridSelectedCouponCodes.Rebind();
        }

        protected void btnCouponCodeRemove_Click(object sender, EventArgs e)
        {
            IList<ProductCatalogue_item.CouponCodes> avaliableCouponCodes = this.AvaliableCouponCodes;
            IList<ProductCatalogue_item.CouponCodes> selectedCouponCodes = this.SelectedCouponCodes;
            if (base.Request.Cookies["CouponCodeReMove"] != null)
            {
                string[] strArrays = base.Request.Cookies["CouponCodeReMove"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogue_item.CouponCodes couponCode = ProductCatalogue_item.GetCouponCode(selectedCouponCodes, Convert.ToInt64(strArrays[i].ToString()));
                        if (couponCode != null)
                        {
                            avaliableCouponCodes.Add(couponCode);
                            selectedCouponCodes.Remove(couponCode);
                        }
                    }
                }
            }
            this.SelectedCouponCodes = selectedCouponCodes;
            this.AvaliableCouponCodes = avaliableCouponCodes;
            this.GridSelectedCouponCodes.Rebind();
            this.GridAvaialbleCoupncodes.Rebind();
        }

        protected void BtnMove_Onclick(object sender, EventArgs e)
        {
            IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
            IList<ProductCatalogue_item.OrderNew> pendingOrders = this.PendingOrders;
            if (base.Request.Cookies["OtherCostMoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["OtherCostMoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogue_item.OrderNew order = ProductCatalogue_item.GetOrder(pendingOrders, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            shippedOrders.Add(order);
                            this.PendingOrders.Remove(order);
                        }
                    }
                }
            }
            this.ShippedOrders = shippedOrders;
            this.PendingOrders = pendingOrders;
            this.GridWebOtherCostShippedOrders.Rebind();
            this.GridWebOtherCostPendingOrders.Rebind();
        }

        protected void BtnReMove_Onclick(object sender, EventArgs e)
        {
            IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
            IList<ProductCatalogue_item.OrderNew> pendingOrders = this.PendingOrders;
            if (base.Request.Cookies["OtherCostRemoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["OtherCostRemoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogue_item.OrderNew order = ProductCatalogue_item.GetOrder(shippedOrders, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            this.PendingOrders.Add(order);
                            shippedOrders.Remove(order);
                        }
                        foreach (ProductCatalogue_item.OrderNew pendingOrder in pendingOrders)
                        {
                            if (pendingOrder.WebOtherCostID != Convert.ToInt64(strArrays[i].ToString()))
                            {
                                continue;
                            }
                            pendingOrder.AdditionalGroupID = (long)0;
                            pendingOrder.GroupName = "";
                        }
                    }
                }
            }
            this.ShippedOrders = shippedOrders;
            this.PendingOrders = pendingOrders;
            this.GridWebOtherCostShippedOrders.Rebind();
            this.GridWebOtherCostPendingOrders.Rebind();
        }

        protected void btnRemoveGroup_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Cookies["AdditionalGroupIDs"] != null)
            {
                IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
                string[] strArrays = base.Request.Cookies["AdditionalGroupIDs"].Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i] != "")
                    {
                        long num = Convert.ToInt64(strArrays[i]);
                        if (ProductCatalogue_item.htAdditionalGroup.ContainsKey(num))
                        {
                            ProductCatalogue_item.htAdditionalGroup[num] = 0;
                        }
                    }
                    foreach (ProductCatalogue_item.OrderNew shippedOrder in shippedOrders)
                    {
                        if (shippedOrder.WebOtherCostID != Convert.ToInt64(strArrays[i]))
                        {
                            continue;
                        }
                        shippedOrder.AdditionalGroupID = (long)0;
                        shippedOrder.GroupName = "";
                    }
                }
                this.ShippedOrders = shippedOrders;
                this.GridWebOtherCostShippedOrders.Rebind();
                base.Message_Display(string.Concat(this.objLanguage.GetLanguageConversion("Group_Removed_Successfully"), "!"), "msg-success", this.plhMessage);
            }
        }

        protected void btnSaveGroup_OnClick(object sender, EventArgs e)
        {
            this.SaveGroup();
        }

        protected string ConvertToImage(string PDFPath, string ImagePath, string filename)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (!filename.Contains("t_"))
            {
                str = (!filename.Contains("m_") ? "imconvert.exe -density 300 -depth 8 -quality 85 \"[PDF][0]\" \"[Image]\"" : "imconvert.exe   \"[PDF][0]\" -resize 300x300 \"[Image]\"");
            }
            else
            {
                str = "imconvert.exe   \"[PDF][0]\" -resize 200x150 \"[Image]\"";
            }
            str = str.Replace("[PDF]", PDFPath).Replace("[Image]", ImagePath);
            ProductCatalogue_item.ExecuteCommand(str);
            empty = (File.Exists(PDFPath) ? string.Concat(filename, ".png") : string.Concat(filename, ".png"));
            return empty;
        }

        protected void DeleteGroup_OnClick(object sender, EventArgs e)
        {
            long num = (long)0;
            if (this.action != "add")
            {
                ProductCatalogue_item.TempProductID = this.ProductCatalogueID;
            }
            else if (ProductCatalogue_item.TempProductID != 0)
            {
                ProductCatalogue_item.TempProductID = Convert.ToInt32(ProductCatalogue_item.TempProductID);
            }
            else
            {
                ProductCatalogue_item.TempProductID = base.GensNegValue(6);
            }
            num = Convert.ToInt64(this.ddlGroup.SelectedValue);
            WebstoreBasePage.AdditionalGroup_delete(num, (long)ProductCatalogue_item.TempProductID);
            IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
            foreach (ProductCatalogue_item.OrderNew shippedOrder in shippedOrders)
            {
                if (shippedOrder.AdditionalGroupID != num)
                {
                    continue;
                }
                shippedOrder.AdditionalGroupID = (long)0;
                shippedOrder.GroupName = "";
                long webOtherCostID = shippedOrder.WebOtherCostID;
                if (!ProductCatalogue_item.htAdditionalGroup.ContainsKey(webOtherCostID))
                {
                    continue;
                }
                ProductCatalogue_item.htAdditionalGroup[webOtherCostID] = 0;
            }
            this.BindGroup("add");
            this.ShippedOrders = shippedOrders;
            this.GridWebOtherCostShippedOrders.Rebind();
        }

        public static string ExecuteCommand(string command)
        {
            string end;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", string.Concat("/c ", command))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process process = new Process()
                {
                    StartInfo = processStartInfo
                };
                process.Start();
                process.WaitForExit();
                end = process.StandardOutput.ReadToEnd();
            }
            catch
            {
                return null;
            }
            return end;
        }

        public void FinalSave(string FromPage, string SaveType)
        {
            DateTime now;
            object[] secureDocPath;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            string value = this.hdn_Customers.Value;
            string str = this.hdn_Customers.Value;
            char[] chrArray = new char[] { ',' };
            string[] strArrays = str.Split(chrArray);
            string str1 = "X";
            int num3 = 0;
            if (this.rdSelectedAll.Checked)
            {
                this.CustomerType = "A";
            }
            else if (this.rdSelectedCustomer.Checked || this.lstownership.SelectedValue != "1")
            {
                this.CustomerType = "S";
            }
            else if (this.rdCustomerNone.Checked)
            {
                this.CustomerType = "N";
            }
            num2 = (!this.chk_ShowSides.Checked ? 0 : 1);
            int num4 = 0;
            if (this.ddldrawstockfrom.SelectedIndex == 1)
            {
                str1 = "S";
            }
            else if (this.ddldrawstockfrom.SelectedIndex == 2)
            {
                str1 = "O";
            }
            else if (this.ddldrawstockfrom.SelectedIndex == 3)
            {
                str1 = "A";
            }
            else if (this.ddldrawstockfrom.SelectedIndex == 4)
            {
                str1 = "M";
            }
            else if (this.ddldrawstockfrom.SelectedIndex == 5)
            {
                str1 = "P";
            }
            if (this.action == "edit")
            {
                try
                {
                    num1 = Convert.ToInt32(base.Request.Params["id"].ToString());
                }
                catch (Exception exception)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/pricecatalogue.aspx"));
                }
                foreach (DataRow row in WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, num1).Rows)
                {
                    this.MatrixType = row["MatrixType"].ToString();
                }
            }
            else if (this.ddlMatrixType.SelectedValue == "pricebands")
            {
                this.MatrixType = "P";
            }
            else if (this.ddlMatrixType.SelectedValue != "signagematrix")
            {
                this.MatrixType = "S";
            }
            else
            {
                this.MatrixType = "G";
            }
            this.txtItemTitle.Text = this.txtCatalogueName.Text;
            string str2 = "";
            this.txtCatalogueName.Text = this.txtCatalogueName.Text.Replace("\r\n", str2).Replace("\n", str2).Replace("\r", str2);
            num4 = SettingsBasePage.settings_price_catalogue_chkexsisting(this.CompanyID, num1, base.SpecialEncode(this.txtitemcode.Text));
            if (this.ddlDefaultPreFlightProfile.SelectedIndex != 0)
            {
                num3 = Convert.ToInt32(this.ddlDefaultPreFlightProfile.SelectedItem.Value);
            }
            string empty = string.Empty;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num38 = 0;
            int num39 = 0;
            bool num40 = false;
            int isWatermark = 0;
            if (this.chkProductVisible.Checked)
            {
                num5 = 1;
            }
            if (this.ChkPrintReadyFile.Checked)
            {
                num6 = 1;
            }
            if (this.ChkShortDescription.Checked)
            {
                num7 = 1;
            }
            if (this.ChkItemDescription.Checked)
            {
                num8 = 1;
            }
            if (this.ChkPriceStart.Checked)
            {
                num9 = 1;
            }
            if (this.ChkPriceList.Checked)
            {
                num10 = 1;
            }
            if (this.ChkEditableProduct.Checked)
            {
                num11 = 1;
            }
            if (this.chkstockitem.Checked)
            {
                num12 = 1;
            }
            if (this.chkbackorders.Checked)
            {
                num13 = 1;
            }
            if (this.Chkshowstock.Checked)
            {
                num14 = 1;
            }
            if (this.chkShowSoldPack.Checked)
            {
                num15 = 1;
            }
            if (this.ChkUnitPrice.Checked)
            {
                num38 = 1;
            }
            if (this.ChkPackPrice.Checked)
            {
                num39 = 1;
            }
            if(this.chkJobName.Checked)
            {
                num40 = true;
            }
            if (this.chkpricesubtotaltax.Checked)
            {
                num16 = 1;
            }
            if (this.chkAllowWaterMarksPrintReady.Checked)
            {
                isWatermark = 1;
            }
            HttpCookie item = base.Request.Cookies["cke_uploadimageName"];
            if (item != null)
            {
                empty = item["uploadImgname"];
                now = DateTime.Now;
                item.Expires = now.AddDays(-1);
                base.Response.Cookies.Add(item);
            }
            if (this.action == "edit")
            {
                if (!(this.hdnsupplierid_onpopup.Value != "") || !(this.ddlSupplier.SelectedValue == "0") && this.ddlSupplier.SelectedValue != null)
                {
                    this.hdnsupplierid_onpopup.Value = this.ddlSupplier.SelectedValue;
                }
                else
                {
                    this.SetDDLValue(this.ddlSupplier, this.hdnsupplierid_onpopup.Value);
                }
                if (num4 != -1)
                {
                    if (this.TextBoxHeight.Text == "")
                    {
                        this.TextBoxHeight.Text = "0.00";
                    }
                    if (this.TextBoxWidth.Text == "")
                    {
                        this.TextBoxWidth.Text = "0.00";
                    }
                    if (this.TextBoxWeight.Text == "")
                    {
                        this.TextBoxWeight.Text = "0.00";
                    }
                    if (this.TextBoxLength.Text == "")
                    {
                        this.TextBoxLength.Text = "0.00";
                    }
                    if (this.TextBoxCBM.Text == "")
                    {
                        this.TextBoxCBM.Text = "0.00";
                    }
                    if (this.TextBoxPerQuantity.Text == "")
                    {
                        this.TextBoxPerQuantity.Text = "0.00";
                    }
                    if (this.TextBoxVolumetricWeight.Text == "")
                    {
                        this.TextBoxVolumetricWeight.Text = "0.00";
                    }

                    var Mandatory1 = ddlDecoration1_Mandatory.Text == "Yes" ? true : false;
                    var Mandatory2 = ddlDecoration2_Mandatory.Text == "Yes" ? true : false;
                    var Mandatory3 = ddlDecoration3_Mandatory.Text == "Yes" ? true : false;
                    var Mandatory4 = ddlDecoration4_Mandatory.Text == "Yes" ? true : false;
                    var Mandatory5 = ddlDecoration5_Mandatory.Text == "Yes" ? true : false;
                    var Mandatory6 = ddlDecoration6_Mandatory.Text == "Yes" ? true : false;

                    long ftpFolderId = string.IsNullOrEmpty(ddlFtpFolders.SelectedValue) ? 0 : Convert.ToInt64(ddlFtpFolders.SelectedValue);
                    string prefix = txtPrefix?.Text?.Trim() ?? string.Empty;


                    string ftpFileType = string.Empty;

                    if (rdoEditable.Checked)
                    {
                        ftpFileType = "Editable";
                    }
                    else if (rdoFTPFile.Checked)
                    {
                        ftpFileType = "FTPFile";
                    }
                    else
                    {
                        ftpFileType = "PrintReady";
                    }
                    Object[] _secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady" };
                    
                    string savePath = string.Concat(_secureDocPath);
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }

                    string ftpFileName = "";

                    if (fileUploader.HasFile)
                    {
                        ftpFileName = Path.GetFileName(fileUploader.FileName);
                        string fullPath = Path.Combine(savePath, ftpFileName);
                        fileUploader.SaveAs(fullPath);
                    }
                    foreach (DataRow row2 in WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, num1).Rows)
                    {
                        if(string.IsNullOrEmpty(ftpFileName) && (!string.IsNullOrEmpty(row2["FTPFile"].ToString())))
                        {
                            ftpFileName = row2["FTPFile"].ToString();
                        }
                    }
                    num = WebstoreBasePage.Settings_Product_Catalogue_InsertUpdate(this.CompanyID, num1, base.SpecialEncode(this.txtitemcode.Text), base.SpecialEncode(this.txtCategoryName.Text), base.SpecialEncode(this.txtCatalogueName.Text).TrimEnd(new char[0]), base.SpecialEncode(this.txtDescription.Text), this.UserID, Convert.ToInt32(this.ddlPriceCatalogueCategory.SelectedValue), base.SpecialEncode(this.txtItemTitle.Text), base.SpecialEncode(this.txtArtwork.Text), base.SpecialEncode(this.txtColour.Text), base.SpecialEncode(this.txtSize.Text), base.SpecialEncode(this.txtMaterial.Text), base.SpecialEncode(this.txtDelivery.Text), base.SpecialEncode(this.txtFinishing.Text), base.SpecialEncode(this.txtNotes.Text), base.SpecialEncode(this.txtInstructions.Text), this.MatrixType, base.SpecialEncode(this.txtProofs.Text), base.SpecialEncode(this.txtPacking.Text), empty, this.hid_ArtworkFileValue.Value, num5, this.txtShortdescriprion.Text, this.RadEdit_txtItemdescriprion.Content, Convert.ToInt32(this.txtUnitOfMeasure.Text), Convert.ToInt32(this.ddlArtCount.SelectedValue), this.CustomerType, num2, num6, num7, num8, num9, num10, this.ChkMandatoryArtworkFile.Checked, Convert.ToInt32(this.hdnsupplierid_onpopup.Value), base.SpecialEncode(this.txtCustom1.Text), base.SpecialEncode(this.txtCustom2.Text), base.SpecialEncode(this.txtCustom3.Text), base.SpecialEncode(this.txtCustom4.Text), base.SpecialEncode(this.txtCustom5.Text), base.SpecialEncode(this.txtCustom6.Text), base.SpecialEncode(this.txtCustom7.Text), base.SpecialEncode(this.txtCustom8.Text), base.SpecialEncode(this.txtCustom9.Text), base.SpecialEncode(this.txtCustom10.Text), base.SpecialEncode(this.txtCustom11.Text), base.SpecialEncode(this.txtCustom12.Text), base.SpecialEncode(this.txtCustom13.Text), base.SpecialEncode(this.txtCustom14.Text), base.SpecialEncode(this.txtCustom15.Text), base.SpecialEncode(this.txtCustom16.Text), base.SpecialEncode(this.txtCustom17.Text), base.SpecialEncode(this.txtCustom18.Text), base.SpecialEncode(this.txtCustom19.Text), base.SpecialEncode(this.txtCustom20.Text), base.SpecialEncode(this.txtCustom21.Text), base.SpecialEncode(this.txtCustom22.Text), base.SpecialEncode(this.txtCustom23.Text), base.SpecialEncode(this.txtCustom24.Text), base.SpecialEncode(this.txtCustom25.Text), num11, num12, num13, num14, Convert.ToInt32(this.lstownership.SelectedItem.Value), this.EstItemID, this.EstType, base.SpecialEncode(this.txtcustomercode.Text), Convert.ToInt32(this.txt_SoldinPack.Text), num15, this.chkAllowGroupRun.Checked, this.chkCustomerCode.Checked, this.chkItemCode.Checked, num16, num38, num39, num40, this.chkQuickItemAdd.Checked, this.chkAddToCartStay.Checked, this.chk_EnableCumulative_Priceing.Checked, this.chkSubAdditionOption.Checked, str1, Convert.ToInt32(this.ddl_SaleTaxRate.SelectedValue), Convert.ToInt32(this.ddlPressName.SelectedValue), num3, txtdecoration1_title.Text, txtdecoration2_title.Text, txtdecoration3_title.Text, txtdecoration4_title.Text, txtdecoration5_title.Text, txtdecoration6_title.Text, Decoration1_Name.Text, Decoration2_Name.Text, Decoration3_Name.Text, Decoration4_Name.Text, Decoration5_Name.Text, Decoration6_Name.Text, Decoration1_Description.Text, Decoration2_Description.Text, Decoration3_Description.Text, Decoration4_Description.Text, Decoration5_Description.Text, Decoration6_Description.Text, BaseClass.CheckDoubleNull(Decoration1_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration2_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration3_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration4_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration5_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration6_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration1_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration2_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration3_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration4_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration5_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration6_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration1_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration2_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration3_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration4_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration5_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration6_Minimumcost.Text), Mandatory1, Mandatory2, Mandatory3, Mandatory4, Mandatory5, Mandatory6,ftpFolderId, prefix,ftpFileName,ftpFileType, Convert.ToInt32(this.ddl_AccountingCode.SelectedValue), isWatermark, base.SpecialEncode(txtWaterMarkPrintReady.Text), Convert.ToDouble(this.TextBoxHeight.Text), Convert.ToDouble(this.TextBoxWidth.Text), Convert.ToDouble(this.TextBoxLength.Text), Convert.ToDouble(this.TextBoxWeight.Text), Convert.ToDouble(this.TextBoxCBM.Text), this.chkCRMOverride.Checked, Convert.ToInt32(this.ddl_PurchaseAccountingCode.SelectedValue), Convert.ToDouble(this.TextBoxPerQuantity.Text), Convert.ToDouble(this.TextBoxVolumetricWeight.Text));
                    if (num > 0 && this.EstItemID > (long)0 && base.Request.Params["pgFrom"] != null)
                    {
                        this.Activity_history_for_Productcataloge();
                    }
                    if (this.CustomerType == "S" || this.CustomerType == "A")
                    {
                        if (this.lstownership.SelectedValue != "1")
                        {
                            WebstoreBasePage.PriceCatalogueCustomer_Delete((long)num1);
                        }
                        for (int i = 0; i < (int)strArrays.Length - 1; i++)
                        {
                            WebstoreBasePage.PriceCatalogueCustomer_Insert((long)num1, Convert.ToInt64(strArrays[i].ToString()), (long)0, this.CustomerType);
                        }
                    }
                    else
                    {
                        WebstoreBasePage.PriceCatalogueCustomer_Delete((long)num1);
                    }
                    if (this.lstownership.SelectedValue == "1")
                    {
                        WebstoreBasePage.PriceCatalogueCustomer_Public_Delete((long)num1);
                        for (int j = 0; j < this.lstStatus.CheckedItems.Count; j++)
                        {
                            long num17 = Convert.ToInt64(this.lstStatus.CheckedItems[j].Value);
                            WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(num1), (long)0, num17, "");
                        }
                    }
                }
                else
                {
                    num = -1;
                    base.Message_Display(this.objlang.GetLanguageConversion("This_Itemcode_Already_Exists"), "msg-fail", this.plhMessage);
                }
            }
            else if (num4 != -1)
            {
                if (this.TextBoxHeight.Text == "")
                {
                    this.TextBoxHeight.Text = "0.00";
                }
                if (this.TextBoxWidth.Text == "")
                {
                    this.TextBoxWidth.Text = "0.00";
                }
                if (this.TextBoxWeight.Text == "")
                {
                    this.TextBoxWeight.Text = "0.00";
                }
                if (this.TextBoxLength.Text == "")
                {
                    this.TextBoxLength.Text = "0.00";
                }
                if (this.TextBoxCBM.Text == "")
                {
                    this.TextBoxCBM.Text = "0.00";
                }
                if (this.TextBoxPerQuantity.Text == "")
                {
                    this.TextBoxPerQuantity.Text = "0.00";
                }
                if (this.TextBoxVolumetricWeight.Text == "")
                {
                    this.TextBoxVolumetricWeight.Text = "0.00";
                }

                if (!(this.hdnsupplierid_onpopup.Value != "") || !(this.ddlSupplier.SelectedValue == "0") && this.ddlSupplier.SelectedValue != null)
                {
                    this.hdnsupplierid_onpopup.Value = this.ddlSupplier.SelectedValue;
                }
                else
                {
                    this.SetDDLValue(this.ddlSupplier, this.hdnsupplierid_onpopup.Value);
                }
                var Mandatory1 = ddlDecoration1_Mandatory.Text == "Yes" ? true : false;
                var Mandatory2 = ddlDecoration2_Mandatory.Text == "Yes" ? true : false;
                var Mandatory3 = ddlDecoration3_Mandatory.Text == "Yes" ? true : false;
                var Mandatory4 = ddlDecoration4_Mandatory.Text == "Yes" ? true : false;
                var Mandatory5 = ddlDecoration5_Mandatory.Text == "Yes" ? true : false;
                var Mandatory6 = ddlDecoration6_Mandatory.Text == "Yes" ? true : false;
                long ftpFolderId = string.IsNullOrEmpty(ddlFtpFolders.SelectedValue) ? 0 : Convert.ToInt64(ddlFtpFolders.SelectedValue);
                string prefix = txtPrefix?.Text?.Trim() ?? string.Empty;

                string ftpFileType = string.Empty;

                if (rdoEditable.Checked)
                {
                    ftpFileType = "Editable";
                }
                else if (rdoFTPFile.Checked)
                {
                    ftpFileType = "FTPFile";
                }
                else
                {
                    ftpFileType = "PrintReady";
                }
                Object[] _secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady" };

                string savePath = string.Concat(_secureDocPath);
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                string ftpFileName = "";

                if (fileUploader.HasFile)
                {
                    ftpFileName = Path.GetFileName(fileUploader.FileName);
                    string fullPath = Path.Combine(savePath, ftpFileName);
                    fileUploader.SaveAs(fullPath);
                }
                num = WebstoreBasePage.Settings_Product_Catalogue_InsertUpdate(this.CompanyID, num1, base.SpecialEncode(this.txtitemcode.Text), base.SpecialEncode(this.txtCategoryName.Text), base.SpecialEncode(this.txtCatalogueName.Text).TrimEnd(new char[0]), base.SpecialEncode(this.txtDescription.Text), this.UserID, Convert.ToInt32(this.ddlPriceCatalogueCategory.SelectedValue), base.SpecialEncode(this.txtItemTitle.Text), base.SpecialEncode(this.txtArtwork.Text), base.SpecialEncode(this.txtColour.Text), base.SpecialEncode(this.txtSize.Text), base.SpecialEncode(this.txtMaterial.Text), base.SpecialEncode(this.txtDelivery.Text), base.SpecialEncode(this.txtFinishing.Text), base.SpecialEncode(this.txtNotes.Text), base.SpecialEncode(this.txtInstructions.Text), this.MatrixType, base.SpecialEncode(this.txtProofs.Text), base.SpecialEncode(this.txtPacking.Text), empty, this.hid_ArtworkFileValue.Value, num5, this.txtShortdescriprion.Text, this.RadEdit_txtItemdescriprion.Content, Convert.ToInt32(this.txtUnitOfMeasure.Text), Convert.ToInt32(this.ddlArtCount.SelectedValue), this.CustomerType, num2, num6, num7, num8, num9, num10, this.ChkMandatoryArtworkFile.Checked, Convert.ToInt32(this.hdnsupplierid_onpopup.Value), base.SpecialEncode(this.txtCustom1.Text), base.SpecialEncode(this.txtCustom2.Text), base.SpecialEncode(this.txtCustom3.Text), base.SpecialEncode(this.txtCustom4.Text), base.SpecialEncode(this.txtCustom5.Text), base.SpecialEncode(this.txtCustom6.Text), base.SpecialEncode(this.txtCustom7.Text), base.SpecialEncode(this.txtCustom8.Text), base.SpecialEncode(this.txtCustom9.Text), base.SpecialEncode(this.txtCustom10.Text), base.SpecialEncode(this.txtCustom11.Text), base.SpecialEncode(this.txtCustom12.Text), base.SpecialEncode(this.txtCustom13.Text), base.SpecialEncode(this.txtCustom14.Text), base.SpecialEncode(this.txtCustom15.Text), base.SpecialEncode(this.txtCustom16.Text), base.SpecialEncode(this.txtCustom17.Text), base.SpecialEncode(this.txtCustom18.Text), base.SpecialEncode(this.txtCustom19.Text), base.SpecialEncode(this.txtCustom20.Text), base.SpecialEncode(this.txtCustom21.Text), base.SpecialEncode(this.txtCustom22.Text), base.SpecialEncode(this.txtCustom23.Text), base.SpecialEncode(this.txtCustom24.Text), base.SpecialEncode(this.txtCustom25.Text), num11, num12, num13, num14, Convert.ToInt32(this.lstownership.SelectedItem.Value), this.EstItemID, this.EstType, base.SpecialEncode(this.txtcustomercode.Text), Convert.ToInt32(this.txt_SoldinPack.Text), num15, this.chkAllowGroupRun.Checked, this.chkCustomerCode.Checked, this.chkItemCode.Checked, num16, num38, num39, num40, this.chkQuickItemAdd.Checked, this.chkAddToCartStay.Checked, this.chk_EnableCumulative_Priceing.Checked, this.chkSubAdditionOption.Checked, str1, Convert.ToInt32(this.ddl_SaleTaxRate.SelectedValue), Convert.ToInt32(this.ddlPressName.SelectedValue), num3, txtdecoration1_title.Text, txtdecoration2_title.Text, txtdecoration3_title.Text, txtdecoration4_title.Text, txtdecoration5_title.Text, txtdecoration6_title.Text, Decoration1_Name.Text, Decoration2_Name.Text, Decoration3_Name.Text, Decoration4_Name.Text, Decoration5_Name.Text, Decoration6_Name.Text, Decoration1_Description.Text, Decoration2_Description.Text, Decoration3_Description.Text, Decoration4_Description.Text, Decoration5_Description.Text, Decoration6_Description.Text, BaseClass.CheckDoubleNull(Decoration1_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration2_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration3_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration4_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration5_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration6_SetupCost.Text), BaseClass.CheckDoubleNull(Decoration1_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration2_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration3_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration4_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration5_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration6_PerItemCost.Text), BaseClass.CheckDoubleNull(Decoration1_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration2_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration3_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration4_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration5_Minimumcost.Text), BaseClass.CheckDoubleNull(Decoration6_Minimumcost.Text), Mandatory1, Mandatory2, Mandatory3, Mandatory4, Mandatory5, Mandatory6,ftpFolderId,prefix,ftpFileName,ftpFileType, Convert.ToInt32(this.ddl_AccountingCode.SelectedValue), isWatermark, base.SpecialEncode(txtWaterMarkPrintReady.Text), Convert.ToDouble(this.TextBoxHeight.Text), Convert.ToDouble(this.TextBoxWidth.Text), Convert.ToDouble(this.TextBoxLength.Text), Convert.ToDouble(this.TextBoxWeight.Text), Convert.ToDouble(this.TextBoxCBM.Text), this.chkCRMOverride.Checked, Convert.ToInt32(this.ddl_PurchaseAccountingCode.SelectedValue), Convert.ToDouble(this.TextBoxPerQuantity.Text), Convert.ToDouble(this.TextBoxVolumetricWeight.Text));
                if (num > 0 && this.EstItemID > (long)0 && base.Request.Params["pgFrom"] != null)
                {
                    this.Activity_history_for_Productcataloge();
                }
                if (this.CustomerType == "S" || this.CustomerType == "A")
                {
                    if (this.lstownership.SelectedValue != "1")
                    {
                        WebstoreBasePage.PriceCatalogueCustomer_Delete((long)num1);
                    }
                    for (int k = 0; k < (int)strArrays.Length - 1; k++)
                    {
                        WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(num), Convert.ToInt64(strArrays[k].ToString()), (long)0, this.CustomerType);
                    }
                }
                if (this.lstownership.SelectedValue == "1" && this.lstStatus.SelectedIndex != 0)
                {
                    for (int l = 0; l < this.lstStatus.Items.Count; l++)
                    {
                        if (this.lstStatus.Items[l].Checked)
                        {
                            int num18 = Convert.ToInt32(this.lstStatus.Items[l].Value);
                            WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(num), (long)0, Convert.ToInt64(num18), "");
                        }
                    }
                }
            }
            else
            {
                num = -1;
                base.Message_Display(this.objlang.GetLanguageConversion("This_Itemcode_Already_Exists"), "msg-fail", this.plhMessage);
                if (base.Request.Params["ToConvert"] != null && base.Request.Params["ToConvert"].ToLower() == "yes")
                {
                    this.action = "Create";
                }
            }
            if (num != -1)
            {
                this.ProductCatalogueID = num;
                if (empty != "" && this.action == "add")
                {
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//" };
                    string str3 = string.Concat(secureDocPath);
                    string str4 = string.Concat(str3, empty);
                    string str5 = string.Concat(str3, "m_", empty);
                    string str6 = string.Concat(str3, "t_", empty);
                    secureDocPath = new object[] { str3, num, "_", empty };
                    string str7 = string.Concat(secureDocPath);
                    secureDocPath = new object[] { str3, "m_", num, "_", empty };
                    string str8 = string.Concat(secureDocPath);
                    secureDocPath = new object[] { str3, "t_", num, "_", empty };
                    string str9 = string.Concat(secureDocPath);
                    File.Copy(str4, str7);
                    File.Copy(str5, str8);
                    File.Copy(str6, str9);
                    File.Delete(str4);
                    File.Delete(str5);
                    File.Delete(str6);
                    secureDocPath = new object[] { "t_", num, "_", empty };
                    empty = string.Concat(secureDocPath);
                }
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady//" };
                empty2 = string.Concat(secureDocPath);
                if (this.upPrintReadyFile.HasFile)
                {
                    this.ProductCatalogueID = num;
                    string empty3 = string.Empty;
                    string correctedFile = string.Empty;
                    empty3 = this.objJava.ReplaceSplSymbol(this.upPrintReadyFile.FileName);
                    correctedFile = string.Concat(num, "_", empty3.Replace(" ", "_"));
                    secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady" };
                    if (!Directory.Exists(string.Concat(secureDocPath)))
                    {
                        secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady" };
                        Directory.CreateDirectory(string.Concat(secureDocPath));
                    }
                    FileUpload fileUpload = this.upPrintReadyFile;
                    secureDocPath = new object[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//PrintReady//", correctedFile };
                    fileUpload.SaveAs(string.Concat(secureDocPath));
                    chrArray = new char[] { '.' };
                    string[] strArrays1 = correctedFile.Split(chrArray);
                    string lower = strArrays1[(int)strArrays1.Length - 1].ToLower();
                    string reportFile = string.Empty;
                    if (this.chkPreflightFiles != null && this.chkPreflightFiles.Checked && lower == "pdf")
                    {
                        PreflightParameters preflightParameter = this.objPreFlight.Preflight_file(correctedFile, this.ddlPreflightFiles.SelectedItem.Text, "", this.CompanyID.ToString(), empty2);
                        if (preflightParameter.IsPreflighted)
                        {
                            correctedFile = preflightParameter.CorrectedFile;
                            reportFile = preflightParameter.ReportFile;
                        }
                    }
                    WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), correctedFile, "pdf", this.chkForceUser.Checked, reportFile);
                    empty1 = correctedFile;
                }
                else if (this.lblPrintReadyFile.Text != "")
                {
                    WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), this.hid_PrintReadyFile.Value, "pdf", this.chkForceUser.Checked, this.hid_ReportFile.Value);
                    empty1 = this.hid_PrintReadyFile.Value;
                }
                if (this.action == "edit" && empty != "")
                {
                    empty = string.Concat("t_", empty);
                }
                else if (this.action != "add" && this.action != "edit")
                {
                    empty = "";
                }
                if (this.hid_ProductImage.Value != "")
                {
                    empty = this.hid_ProductImage.Value;
                }
                if (this.lblProductImage.Text != "" || this.ancUploadimage.InnerHtml != "")
                {
                    if (this.hid_ProductImage.Value != "")
                    {
                        empty = this.hid_ProductImage.Value;
                    }
                    if (!this.chksetPrAsProductimg.Checked || !(empty1 != ""))
                    {
                        WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), empty, "image", this.chkForceUser.Checked, "");
                    }
                    else
                    {
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//PrintReady//", empty1 };
                        string str10 = string.Concat(secureDocPath);
                        empty1 = empty1.Replace(".pdf", "");
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//t_", empty1, ".png" };
                        string str11 = string.Concat(secureDocPath);
                        string image = this.ConvertToImage(str10, str11, string.Concat("t_", empty1));
                        WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), image, "image", this.chkForceUser.Checked, "");
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//m_", empty1, ".png" };
                        string str12 = string.Concat(secureDocPath);
                        this.ConvertToImage(str10, str12, string.Concat("m_", empty1));
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//", empty1, ".png" };
                        string str13 = string.Concat(secureDocPath);
                        this.ConvertToImage(str10, str13, empty1);
                    }
                }
                if (!this.chksetPrAsProductimg.Checked || !(empty1 != ""))
                {
                    WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), empty, "image", this.chkForceUser.Checked, "");
                }
                else
                {
                    empty1 = empty1.Replace(".pdf", "");
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//PrintReady//", empty1 };
                    string str14 = string.Concat(secureDocPath);
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//", empty1, ".png" };
                    string str20 = string.Concat(secureDocPath);
                    ExecuteCommandGhostLibrary(string.Concat(str14, ".pdf"), string.Concat(secureDocPath));
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//t_", empty1, ".png" };
                    string str15 = string.Concat(secureDocPath);
                    ExecuteCommandGhostLibraryForThumbnail(string.Concat(str14, ".pdf"), string.Concat(secureDocPath));
                    string image1 = this.ConvertToImage(str14, str15, string.Concat("t_", empty1));
                    WebstoreBasePage.settings_Product_CatalogueImage_Update((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID), image1, "image", this.chkForceUser.Checked, "");
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//m_", empty1, ".png" };
                    string str16 = string.Concat(secureDocPath);
                    ExecuteCommandGhostLibrary(string.Concat(str14, ".pdf"), string.Concat(secureDocPath));
                    string image2 = this.ConvertToImage(str14, str16, string.Concat("m_", empty1));
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//", empty1, ".png" };
                    string str17 = string.Concat(secureDocPath);
                    this.ConvertToImage(str14, str17, empty1);
                }
                if (num1 == 0)
                {
                    string value1 = this.hidQtyPrice.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays2 = value1.Split(chrArray);
                    for (int m = 0; m < (int)strArrays2.Length - 1; m++)
                    {
                        if (strArrays2[m] != "")
                        {
                            decimal num19 = 0;
                            decimal num20 = 0;
                            decimal num21 = new decimal(0);
                            decimal num22 = new decimal(0);
                            decimal num23 = new decimal(0);
                            decimal num24 = new decimal(0);
                            decimal num25 = new decimal(0);
                            decimal num26 = new decimal(0);
                            decimal num27 = new decimal(0);
                            bool hideOnEStore = false;
                            string str18 = strArrays2[m];
                            chrArray = new char[] { '±' };
                            string[] strArrays3 = str18.Split(chrArray);
                            for (int n = 0; n < (int)strArrays3.Length; n++)
                            {
                                string str19 = strArrays3[n];
                                chrArray = new char[] { '»' };
                                string[] strArrays4 = str19.Split(chrArray);
                                if (string.Compare(strArrays4[0], "FromQty", true) == 0)
                                {
                                    num19 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "ToQty", true) == 0)
                                {
                                    num20 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Cost", true) == 0)
                                {
                                    num21 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Markup", true) == 0)
                                {
                                    num22 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "SellingPrice", true) == 0)
                                {
                                    num23 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Weight", true) == 0)
                                {
                                    num24 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Width", true) == 0)
                                {
                                    num25 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Height", true) == 0)
                                {
                                    num26 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "Length", true) == 0)
                                {
                                    num27 = Convert.ToDecimal(strArrays4[1]);
                                }
                                else if (string.Compare(strArrays4[0], "HideOnEStore", true) == 0)
                                {
                                    hideOnEStore = strArrays4[1] == "1" ? true : false;
                                }

                            }
                            WebstoreBasePage.settings_Product_CatalogueQty_insert(this.CompanyID, num, num19, num20, num21, num22, num23, num24, num25, num26, num27, hideOnEStore);
                        }
                    }
                    this.GridWebOtherCostShippedOrders.AllowPaging = false;
                    this.GridWebOtherCostShippedOrders.Rebind();
                    for (int o = 0; o < this.GridWebOtherCostShippedOrders.Items.Count; o++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)this.GridWebOtherCostShippedOrders.Items[o].FindControl("Id_2");
                        long num28 = (long)0;
                        num28 = (!ProductCatalogue_item.htAdditionalGroup.ContainsKey(Convert.ToInt64(htmlInputCheckBox.Value)) ? (long)0 : Convert.ToInt64(ProductCatalogue_item.htAdditionalGroup[Convert.ToInt64(htmlInputCheckBox.Value)]));
                        WebstoreBasePage.settings_Product_CatalogueAdditional_insert(this.CompanyID, (long)this.ProductCatalogueID, Convert.ToInt64(htmlInputCheckBox.Value), num28);
                        WebstoreBasePage.AdditionalGroup_ProductID_Update(Convert.ToInt64(ProductCatalogue_item.TempProductID), (long)this.ProductCatalogueID);
                    }
                    this.GridSelectedCouponCodes.AllowPaging = false;
                    this.GridSelectedCouponCodes.Rebind();
                    for (int p = 0; p < this.GridSelectedCouponCodes.Items.Count; p++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)this.GridSelectedCouponCodes.Items[p].FindControl("chkSCC_2");
                        WebstoreBasePage.Product_CatalogueCouponCode_insert(this.CompanyID, (long)this.ProductCatalogueID, Convert.ToInt64(htmlInputCheckBox1.Value));
                    }
                }
                else
                {
                    WebstoreBasePage.Settings_Product_CatalogueQty_delete(num1);
                    string value2 = this.hidQtyPrice.Value;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays5 = value2.Split(chrArray);
                    for (int q = 0; q < (int)strArrays5.Length - 1; q++)
                    {
                        if (strArrays5[q] != "")
                        {
                            decimal num29 = 0;
                            decimal num30 = 0;
                            decimal num31 = new decimal(0);
                            decimal num32 = new decimal(0);
                            decimal num33 = new decimal(0);
                            decimal num34 = new decimal(0);
                            decimal num35 = new decimal(0);
                            decimal num36 = new decimal(0);
                            decimal num37 = new decimal(0);
                            string str20 = strArrays5[q];
                            bool hideOnEStore = false;
                            chrArray = new char[] { '±' };
                            string[] strArrays6 = str20.Split(chrArray);
                            for (int r = 0; r < (int)strArrays6.Length; r++)
                            {
                                string str21 = strArrays6[r];
                                chrArray = new char[] { '»' };
                                string[] strArrays7 = str21.Split(chrArray);
                                if (string.Compare(strArrays7[0], "FromQty", true) == 0)
                                {
                                    num29 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "ToQty", true) == 0)
                                {
                                    num30 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Cost", true) == 0)
                                {
                                    num31 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Markup", true) == 0)
                                {
                                    num32 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "SellingPrice", true) == 0)
                                {
                                    num33 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Weight", true) == 0)
                                {
                                    num34 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Width", true) == 0)
                                {
                                    num35 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Height", true) == 0)
                                {
                                    num36 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "Length", true) == 0)
                                {
                                    num37 = Convert.ToDecimal(strArrays7[1]);
                                }
                                else if (string.Compare(strArrays7[0], "HideOnEStore", true) == 0)
                                {
                                    hideOnEStore = strArrays7[1] == "1" ? true : false;
                                }
                            }
                            WebstoreBasePage.settings_Product_CatalogueQty_insert(this.CompanyID, num1, num29, num30, num31, num32, num33, num34, num35, num36, num37, hideOnEStore);
                        }
                    }
                    //WebstoreBasePage.settings_Product_CatalogueAdditional_Delete((long)this.CompanyID, (long)num1);
                    this.SaveAdditionalRecords(num1);
                    WebstoreBasePage.ProductCatalogue_CouponCode_Delete((long)this.CompanyID, (long)num1);
                    this.GridSelectedCouponCodes.AllowPaging = false;
                    this.GridSelectedCouponCodes.Rebind();
                    for (int s = 0; s < this.GridSelectedCouponCodes.Items.Count; s++)
                    {
                        HtmlInputCheckBox htmlInputCheckBox2 = (HtmlInputCheckBox)this.GridSelectedCouponCodes.Items[s].FindControl("chkSCC_2");
                        WebstoreBasePage.Product_CatalogueCouponCode_insert(this.CompanyID, (long)num1, Convert.ToInt64(htmlInputCheckBox2.Value));
                    }
                }
            }
            if (num == -1)
            {
                this.txtCatalogueName.Focus();
                this.txtCatalogueName.Attributes.Add("onfocus", "select()");
            }
            else
            {
                if (Convert.ToBoolean(this.hdn_AddZeroOpeningStock.Value) && SaveType != "managestock" && WebstoreBasePage.pricecataloguestock_actiontype_check((long)num1, "self") == "Opening")
                {
                    commonClass _commonClass = this.objJava;
                    string str22 = Convert.ToString(this.Session["DateFormat"]);
                    commonClass _commonClass1 = this.objJava;
                    now = DateTime.Now;
                    string str23 = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str22, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                    WebstoreBasePage.DefaultProductStock_Self_Insert((long)num, (long)this.UserID, (long)this.CompanyID, Convert.ToDateTime(str23));
                }
                if (this.AccountingCode == "d")
                {
                    SettingsBasePage.PriceCatalogue_AccountingCode_Insert((long)this.CompanyID, (long)num, int.Parse(this.ddlAccountCode.SelectedValue));
                }
                if (FromPage == "FinalSave")
                {
                    if (this.RedirectTo == "crm")
                    {
                        this.RedirectTOCRM();
                        return;
                    }
                    if (num1 != 0)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                        return;
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=in", this.jID, this.InvID));
                    return;
                }
                if (FromPage == "Price")
                {
                    if (SaveType == "saveandstay")
                    {
                        HttpResponse response = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=p&from=", this.RedirectTo, this.jID, this.InvID };
                        response.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (SaveType == "save")
                    {
                        if (this.RedirectTo == "crm")
                        {
                            this.RedirectTOCRM();
                            return;
                        }
                        if (num1 != 0)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse httpResponse = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse response1 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response1.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() != "invoice")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=in", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse httpResponse1 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (SaveType.ToLower() == "managestock")
                    {
                        Type type = base.GetType();
                        secureDocPath = new object[] { "javascript:addstockonsave(", num, ",'", str1.ToLower(), "');" };
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, type, "", string.Concat(secureDocPath), true);
                        SaveType = "";
                        return;
                    }
                }
                else if (FromPage == "Artwork")
                {
                    if (SaveType == "saveandstay")
                    {
                        HttpResponse response2 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ac", this.jID, this.InvID };
                        response2.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (SaveType == "save")
                    {
                        if (this.RedirectTo == "crm")
                        {
                            this.RedirectTOCRM();
                            return;
                        }
                        if (num1 != 0)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse httpResponse2 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse2.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse response3 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response3.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() != "invoice")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=in", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse httpResponse3 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        httpResponse3.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                }
                else if (FromPage == "Additional")
                {
                    if (SaveType == "saveandstay")
                    {
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse response4 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response4.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "invoice")
                        {
                            HttpResponse response5 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                            response5.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.RedirectTo != "crm")
                        {
                            HttpResponse httpResponse5 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ao", this.jID, this.InvID };
                            httpResponse5.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        HttpResponse response6 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ao&from=", this.RedirectTo, this.jID, this.InvID };
                        response6.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                }
                else if (FromPage == "editproduct")
                {
                    if (SaveType == "saveandstay")
                    {
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse httpResponse6 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse6.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse response7 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response7.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "invoice")
                        {
                            HttpResponse httpResponse7 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                            httpResponse7.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        HttpResponse response8 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ep&from=", this.RedirectTo, this.jID, this.InvID };
                        response8.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (SaveType == "save")
                    {
                        if (this.RedirectTo == "crm")
                        {
                            this.RedirectTOCRM();
                            return;
                        }
                        if (num1 != 0)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse httpResponse8 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse8.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse response9 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response9.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() != "invoice")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=in", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse httpResponse9 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        httpResponse9.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                }
                else if (FromPage.ToLower() == "general")
                {
                    if (SaveType == "saveandstay")
                    {
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse response10 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response10.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse httpResponse10 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse10.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "invoice")
                        {
                            HttpResponse response11 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                            response11.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        HttpResponse httpResponse11 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=g&from=", this.RedirectTo, this.jID, this.InvID };
                        httpResponse11.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (SaveType == "save")
                    {
                        if (this.RedirectTo == "crm")
                        {
                            this.RedirectTOCRM();
                            return;
                        }
                        if (num1 != 0)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "estimate")
                        {
                            HttpResponse response12 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            response12.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() == "job")
                        {
                            HttpResponse httpResponse12 = base.Response;
                            secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                            httpResponse12.Redirect(string.Concat(secureDocPath));
                            return;
                        }
                        if (this.pgFrom.ToLower() != "invoice")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=in", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse response13 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        response13.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                }
                else if (FromPage == "CouponCode" && SaveType == "saveandstay")
                {
                    if (this.pgFrom.ToLower() == "estimate")
                    {
                        HttpResponse httpResponse13 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                        httpResponse13.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.pgFrom.ToLower() == "job")
                    {
                        HttpResponse response14 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                        response14.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.pgFrom.ToLower() == "invoice")
                    {
                        HttpResponse httpResponse14 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        httpResponse14.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.RedirectTo != "crm")
                    {
                        HttpResponse response15 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=cc", this.jID, this.InvID };
                        response15.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    HttpResponse httpResponse15 = base.Response;
                    secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=cc&from=", this.RedirectTo, this.jID, this.InvID };
                    httpResponse15.Redirect(string.Concat(secureDocPath));
                    return;
                }
                else if (FromPage == "FTP" && SaveType == "saveandstay")
                {
                    if (this.pgFrom.ToLower() == "estimate")
                    {
                        HttpResponse httpResponse13 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                        httpResponse13.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.pgFrom.ToLower() == "job")
                    {
                        HttpResponse response14 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstID, this.jID, this.InvID };
                        response14.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.pgFrom.ToLower() == "invoice")
                    {
                        HttpResponse httpResponse14 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstID, this.jID, this.InvID };
                        httpResponse14.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    if (this.RedirectTo != "crm")
                    {
                        HttpResponse response15 = base.Response;
                        secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ft", this.jID, this.InvID };
                        response15.Redirect(string.Concat(secureDocPath));
                        return;
                    }
                    HttpResponse httpResponse15 = base.Response;
                    secureDocPath = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&clientID=", this.ClientID, "&page=ft&from=", this.RedirectTo, this.jID, this.InvID };
                    httpResponse15.Redirect(string.Concat(secureDocPath));
                    return;
                }
                else if (FromPage == "FTP" && SaveType == "save")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx?display=up", this.jID, this.InvID));
                    return;

                }

            }
        }

        [WebMethod]
        public static RadGrid GetAllAditionalItems()
        {
            RadGrid radGrid = new RadGrid()
            {
                AllowPaging = false
            };
            radGrid.Rebind();
            return radGrid;
        }

        protected IList<ProductCatalogue_item.CouponCodes> GetAvaliableCouponCodes()
        {
            IList<ProductCatalogue_item.CouponCodes> couponCodes = new List<ProductCatalogue_item.CouponCodes>();
            DataSet dataSet = WebstoreBasePage.Available_couponCode_PageText(this.CompanyID, this.PageSize, 1, "", "asc", "");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        long num = Convert.ToInt64(row["CouponCodeID"].ToString());
                        string str = row["CouponCode"].ToString();
                        string str1 = row["UserFriendlyName"].ToString();
                        couponCodes.Add(new ProductCatalogue_item.CouponCodes(num, str, str1));
                    }
                    this.Session["AvaliableCouponCodes"] = dataSet.Tables[0];
                }
                catch
                {
                    couponCodes.Clear();
                }
            }
            return couponCodes;
        }

        private static ProductCatalogue_item.CouponCodes GetCouponCode(IEnumerable<ProductCatalogue_item.CouponCodes> AvailableCoupons, long CouponCodeID)
        {
            ProductCatalogue_item.CouponCodes couponCode;
            using (IEnumerator<ProductCatalogue_item.CouponCodes> enumerator = AvailableCoupons.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ProductCatalogue_item.CouponCodes current = enumerator.Current;
                    if (current.CouponCodeID != CouponCodeID)
                    {
                        continue;
                    }
                    couponCode = current;
                    return couponCode;
                }
                return null;
            }
            return couponCode;
        }

        private static ProductCatalogue_item.OrderNew GetOrder(IEnumerable<ProductCatalogue_item.OrderNew> ordersToSearchIn, long WebOtherCostID)
        {
            ProductCatalogue_item.OrderNew orderNew;
            using (IEnumerator<ProductCatalogue_item.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ProductCatalogue_item.OrderNew current = enumerator.Current;
                    if (current.WebOtherCostID != WebOtherCostID)
                    {
                        continue;
                    }
                    orderNew = current;
                    return orderNew;
                }
                return null;
            }
            return orderNew;
        }

        protected IList<ProductCatalogue_item.OrderNew> GetOrders()
        {
            IList<ProductCatalogue_item.OrderNew> orderNews = new List<ProductCatalogue_item.OrderNew>();
            DataSet dataSet = WebstoreBasePage.SettingsWebStore_OtherCost_PageText(this.CompanyID, this.PageSize, 1, "OrderNumber", "asc", "", "p", false);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        long num = Convert.ToInt64(row["WebOtherCostID"].ToString());
                        string str = row["OtherCostCategoryName"].ToString();
                        string str1 = row["WebOtherCostName"].ToString();
                        string str2 = row["UserFriendlyName"].ToString();
                        string str3 = row["Description"].ToString();
                        long num1 = Convert.ToInt64(row["AdditionalGroupID"].ToString());
                        string str4 = row["GroupName"].ToString();
                        orderNews.Add(new ProductCatalogue_item.OrderNew(num, str, str1, str2, str3, num1, str4));
                    }
                    this.Session["OtherCostPendingOrders"] = dataSet.Tables[0];
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        [WebMethod]
        public static int GetPricecatalogue(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            int num = Convert.ToInt32(strArrays[0]);
            string str = baseClass.ReplaceSingleQuote(strArrays[1]);
            int num1 = Convert.ToInt32(strArrays[2]);
            return SettingsBasePage.settings_price_catalogue_chkexsisting(num, num1, str);
        }

        protected IList<ProductCatalogue_item.CouponCodes> GetSelectedCouponCodes()
        {
            IList<ProductCatalogue_item.CouponCodes> couponCodes = new List<ProductCatalogue_item.CouponCodes>();
            DataTable dataTable = WebstoreBasePage.Product_CatalogueCouponCode_Select((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID));
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["CouponCodeID"].ToString());
                        string str = row["CouponCode"].ToString();
                        string str1 = row["UserFriendlyName"].ToString();
                        couponCodes.Add(new ProductCatalogue_item.CouponCodes(num, str, str1));
                    }
                    this.Session["SelectedCouponCodes"] = dataTable;
                }
                catch
                {
                    couponCodes.Clear();
                }
            }
            return couponCodes;
        }

        /* protected IList<ProductCatalogue_item.OrderNew> GetShippingOrders()
         {
             IList<ProductCatalogue_item.OrderNew> orderNews = new List<ProductCatalogue_item.OrderNew>();
             DataTable dataTable = WebstoreBasePage.settings_Product_CatalogueAdditional_Select((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID));
             if (dataTable.Rows.Count > 0)
             {
                 try
                 {
                     foreach (DataRow row in dataTable.Rows)
                     {
                         long num = Convert.ToInt64(row["WebOtherCostID"].ToString());
                         string str = row["OtherCostCategoryName"].ToString();
                         string str1 = row["WebOtherCostName"].ToString();
                         string str2 = row["UserFriendlyName"].ToString();
                         string str3 = row["Description"].ToString();
                         long num1 = Convert.ToInt64(row["AdditionalGroupID"].ToString());
                         string str4 = row["GroupName"].ToString();
                         orderNews.Add(new ProductCatalogue_item.OrderNew(num, str, str1, str2, str3, num1, str4));
                     }
                     this.Session["OtherCostPendingOrders"] = dataTable;
                 }
                 catch
                 {
                     orderNews.Clear();
                 }
             }
             return orderNews;
         }*/

        protected IList<ProductCatalogue_item.OrderNew> GetShippingOrders(int productId)
        {
            IList<ProductCatalogue_item.OrderNew> orderNews = new List<ProductCatalogue_item.OrderNew>();

            DataTable dataTable = WebstoreBasePage.settings_Product_CatalogueAdditional_Select(
                (long)this.CompanyID, Convert.ToInt64(productId)
            );

            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long costId = Convert.ToInt64(row["WebOtherCostID"]);
                        string category = row["OtherCostCategoryName"].ToString();
                        string name = row["WebOtherCostName"].ToString();
                        string friendly = row["UserFriendlyName"].ToString();
                        string desc = row["Description"].ToString();
                        long groupId = Convert.ToInt64(row["AdditionalGroupID"]);
                        string groupName = row["GroupName"].ToString();

                        orderNews.Add(new ProductCatalogue_item.OrderNew(costId, category, name, friendly, desc, groupId, groupName));
                    }
                }
                catch
                {
                    orderNews.Clear();
                }
            }

            return orderNews;
        }


        protected void grdPendingOrders_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridWebOtherCostPendingOrders.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridWebOtherCostPendingOrders.ClientID)
            {
                if (e.DestDataItem == null && this.ShippedOrders.Count == 0 || e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridWebOtherCostShippedOrders.ClientID)
                {
                    IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
                    IList<ProductCatalogue_item.OrderNew> pendingOrders = this.PendingOrders;
                    int num = -1;
                    if (e.DestDataItem != null)
                    {
                        ProductCatalogue_item.OrderNew order = ProductCatalogue_item.GetOrder(shippedOrders, (long)e.DestDataItem.GetDataKeyValue("WebOtherCostID"));
                        num = (order != null ? shippedOrders.IndexOf(order) : -1);
                    }
                    foreach (GridDataItem draggedItem in e.DraggedItems)
                    {
                        ProductCatalogue_item.OrderNew orderNew = ProductCatalogue_item.GetOrder(pendingOrders, (long)draggedItem.GetDataKeyValue("WebOtherCostID"));
                        if (orderNew == null)
                        {
                            continue;
                        }
                        if (num <= -1)
                        {
                            shippedOrders.Add(orderNew);
                        }
                        else
                        {
                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                num++;
                            }
                            shippedOrders.Insert(num, orderNew);
                        }
                        pendingOrders.Remove(orderNew);
                    }
                    this.ShippedOrders = shippedOrders;
                    this.PendingOrders = pendingOrders;
                    this.GridWebOtherCostPendingOrders.Rebind();
                    this.GridWebOtherCostShippedOrders.Rebind();
                    return;
                }
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridWebOtherCostPendingOrders.ClientID)
                {
                    IList<ProductCatalogue_item.OrderNew> orderNews = this.PendingOrders;
                    ProductCatalogue_item.OrderNew order1 = ProductCatalogue_item.GetOrder(orderNews, (long)e.DestDataItem.GetDataKeyValue("WebOtherCostID"));
                    int num1 = orderNews.IndexOf(order1);
                    if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                    {
                        num1--;
                    }
                    if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                    {
                        num1++;
                    }
                    List<ProductCatalogue_item.OrderNew> orderNews1 = new List<ProductCatalogue_item.OrderNew>();
                    foreach (GridDataItem gridDataItem in e.DraggedItems)
                    {
                        ProductCatalogue_item.OrderNew orderNew1 = ProductCatalogue_item.GetOrder(orderNews, (long)gridDataItem.GetDataKeyValue("WebOtherCostID"));
                        if (orderNew1 == null)
                        {
                            continue;
                        }
                        orderNews1.Add(orderNew1);
                    }
                    foreach (ProductCatalogue_item.OrderNew orderNew2 in orderNews1)
                    {
                        orderNews.Remove(orderNew2);
                        orderNews.Insert(num1, orderNew2);
                    }
                    this.PendingOrders = orderNews;
                    this.GridWebOtherCostPendingOrders.Rebind();
                    int pageSize = num1 - this.GridWebOtherCostPendingOrders.PageSize * this.GridWebOtherCostPendingOrders.CurrentPageIndex;
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
            }
        }

        protected void grdShippedOrders_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridWebOtherCostShippedOrders.DataSource = this.ShippedOrders;
        }

        protected void grdShippedOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridWebOtherCostShippedOrders.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridWebOtherCostShippedOrders.ClientID)
            {
                IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
                ProductCatalogue_item.OrderNew order = ProductCatalogue_item.GetOrder(shippedOrders, (long)e.DestDataItem.GetDataKeyValue("WebOtherCostID"));
                int num = shippedOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<ProductCatalogue_item.OrderNew> orderNews = new List<ProductCatalogue_item.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    ProductCatalogue_item.OrderNew orderNew = ProductCatalogue_item.GetOrder(shippedOrders, (long)draggedItem.GetDataKeyValue("WebOtherCostID"));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (ProductCatalogue_item.OrderNew orderNew1 in orderNews)
                {
                    shippedOrders.Remove(orderNew1);
                    shippedOrders.Insert(num, orderNew1);
                }
                this.ShippedOrders = shippedOrders;
                this.GridWebOtherCostShippedOrders.Rebind();
                int pageSize = num - this.GridWebOtherCostShippedOrders.PageSize * this.GridWebOtherCostShippedOrders.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void GridAvaialbleCoupncodes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridAvaialbleCoupncodes.DataSource = this.AvaliableCouponCodes;
        }

        protected void GridAvaialbleCoupncodes_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridAvaialbleCoupncodes.ClientID)
            {
                if (e.DestDataItem == null && this.AvaliableCouponCodes.Count == 0 || e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridSelectedCouponCodes.ClientID)
                {
                    IList<ProductCatalogue_item.CouponCodes> selectedCouponCodes = this.SelectedCouponCodes;
                    IList<ProductCatalogue_item.CouponCodes> avaliableCouponCodes = this.AvaliableCouponCodes;
                    int num = -1;
                    if (e.DestDataItem != null)
                    {
                        ProductCatalogue_item.CouponCodes couponCode = ProductCatalogue_item.GetCouponCode(selectedCouponCodes, (long)e.DestDataItem.GetDataKeyValue("CouponCodeID"));
                        num = (couponCode != null ? selectedCouponCodes.IndexOf(couponCode) : -1);
                    }
                    foreach (GridDataItem draggedItem in e.DraggedItems)
                    {
                        ProductCatalogue_item.CouponCodes couponCode1 = ProductCatalogue_item.GetCouponCode(avaliableCouponCodes, (long)draggedItem.GetDataKeyValue("CouponCodeID"));
                        if (couponCode1 == null)
                        {
                            continue;
                        }
                        if (num <= -1)
                        {
                            selectedCouponCodes.Add(couponCode1);
                        }
                        else
                        {
                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                num++;
                            }
                            selectedCouponCodes.Insert(num, couponCode1);
                        }
                        avaliableCouponCodes.Remove(couponCode1);
                    }
                    this.SelectedCouponCodes = selectedCouponCodes;
                    this.AvaliableCouponCodes = avaliableCouponCodes;
                    this.GridAvaialbleCoupncodes.Rebind();
                    this.GridSelectedCouponCodes.Rebind();
                    return;
                }
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridAvaialbleCoupncodes.ClientID)
                {
                    IList<ProductCatalogue_item.CouponCodes> couponCodes = this.AvaliableCouponCodes;
                    ProductCatalogue_item.CouponCodes couponCode2 = ProductCatalogue_item.GetCouponCode(couponCodes, (long)e.DestDataItem.GetDataKeyValue("CouponCodeID"));
                    int num1 = couponCodes.IndexOf(couponCode2);
                    if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                    {
                        num1--;
                    }
                    if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                    {
                        num1++;
                    }
                    List<ProductCatalogue_item.CouponCodes> couponCodes1 = new List<ProductCatalogue_item.CouponCodes>();
                    foreach (GridDataItem gridDataItem in e.DraggedItems)
                    {
                        ProductCatalogue_item.CouponCodes couponCode3 = ProductCatalogue_item.GetCouponCode(couponCodes, (long)gridDataItem.GetDataKeyValue("CouponCodeID"));
                        if (couponCode3 == null)
                        {
                            continue;
                        }
                        couponCodes1.Add(couponCode3);
                    }
                    foreach (ProductCatalogue_item.CouponCodes couponCode4 in couponCodes1)
                    {
                        couponCodes.Remove(couponCode4);
                        couponCodes.Insert(num1, couponCode4);
                    }
                    this.AvaliableCouponCodes = couponCodes;
                    this.GridAvaialbleCoupncodes.Rebind();
                    int pageSize = num1 - this.GridAvaialbleCoupncodes.PageSize * this.GridAvaialbleCoupncodes.CurrentPageIndex;
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
            }
        }

        protected void GridSelectedCouponCodes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridSelectedCouponCodes.DataSource = this.SelectedCouponCodes;
        }

        protected void GridSelectedCouponCodes_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridSelectedCouponCodes.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridSelectedCouponCodes.ClientID)
            {
                IList<ProductCatalogue_item.CouponCodes> selectedCouponCodes = this.SelectedCouponCodes;
                ProductCatalogue_item.CouponCodes couponCode = ProductCatalogue_item.GetCouponCode(selectedCouponCodes, (long)e.DestDataItem.GetDataKeyValue("CouponCodeID"));
                int num = selectedCouponCodes.IndexOf(couponCode);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<ProductCatalogue_item.CouponCodes> couponCodes = new List<ProductCatalogue_item.CouponCodes>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    ProductCatalogue_item.CouponCodes couponCode1 = ProductCatalogue_item.GetCouponCode(selectedCouponCodes, (long)draggedItem.GetDataKeyValue("CouponCodeID"));
                    if (couponCode1 == null)
                    {
                        continue;
                    }
                    couponCodes.Add(couponCode1);
                }
                foreach (ProductCatalogue_item.CouponCodes couponCode2 in couponCodes)
                {
                    selectedCouponCodes.Remove(couponCode2);
                    selectedCouponCodes.Insert(num, couponCode2);
                }
                this.SelectedCouponCodes = selectedCouponCodes;
                this.GridSelectedCouponCodes.Rebind();
                int pageSize = num - this.GridSelectedCouponCodes.PageSize * this.GridSelectedCouponCodes.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (base.Request.Params["action"] == null)
            {
                HttpResponse response = base.Response;
                object[] clientID = new object[] { this.strSitepath, "client/client_add.aspx?type=Supplier&post=settings&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
                response.Redirect(string.Concat(clientID));
            }
            else if (base.Request.Params["action"].ToString().ToLower() == "edit")
            {
                HttpResponse httpResponse = base.Response;
                object[] lower = new object[] { this.strSitepath, "client/client_add.aspx?type=Supplier&post=settings&mode=", base.Request.Params["action"].ToString().ToLower(), "&id=", base.Request.Params["id"].ToString(), "&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(lower));
                return;
            }
        }

        protected void imgbtnaddcategory_Click(object sender, ImageClickEventArgs e)
        {
            if (base.Request.Params["action"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?type=product&post=settings&mode=add", this.jID, this.InvID));
            }
            else if (base.Request.Params["action"].ToString().ToLower() == "edit")
            {
                HttpResponse response = base.Response;
                object[] lower = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?type=product&post=settings&postmode=", base.Request.Params["action"].ToString().ToLower(), "&id=", base.Request.QueryString["id"].ToString(), "&clientID=", this.ClientID, "&from=", this.RedirectTo, "&mode=add", this.jID, this.InvID };
                response.Redirect(string.Concat(lower));
                return;
            }
        }

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            int num = SettingsBasePage.price_catalogue_copy(this.CompanyID, Convert.ToInt32(this.Session["UserID"]), Convert.ToInt32(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] invID = new object[] { this.strSitepath, "ProductCatalogue/pricecatalogue.aspx?action=edit&id=", num, "&copy=yes", this.jID, this.InvID };
            response.Redirect(string.Concat(invID));
        }

        protected void lnk_CouponCode_Save_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("FinalSave", "save");
        }

        protected void lnk_CouponCode_SaveMangeStock_Click(object sender, EventArgs e)
        {
            this.FinalSave("Price", "managestock");
        }

        protected void lnk_CouponCode_SaveStay_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("CouponCode", "saveandstay");
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        SettingsBasePage.settings_price_catalogue_properties_deleteAll(this.CompanyID, Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Product_Catalogue_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkgensave_Onclick(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("General", "save");
        }

        protected void lnkgensavestay_Onclick(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("General", "saveandstay");
        }

        protected void lnkgrdPriceText_OnCommand(object sender, CommandEventArgs e)
        {
            HttpResponse response = base.Response;
            string[] str = new string[] { this.strSitepath, "ProductCatalogue/pricecatalogue.aspx?action=edit&id=", e.CommandArgument.ToString(), this.jID, this.InvID };
            response.Redirect(string.Concat(str));
        }

        protected void OnClick_btnAdditionalSaveandStay(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("Additional", "saveandstay");
        }

        protected void OnClick_btnArtworkSave(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("Artwork", "save");
        }

        protected void OnClick_btnArtworkSaveandStay(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("Artwork", "saveandstay");
        }

        protected void OnClick_btnprice_managestock(object sender, EventArgs e)
        {
            this.FinalSave("Price", "managestock");
        }

        protected void OnClick_btnPriceSave(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("Price", "save");
        }

        protected void OnClick_btnPriceSaveandStay(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("Price", "saveandstay");
        }

        protected void OnClick_btnSave(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.FinalSave("FinalSave", "save");
        }

        protected void OnClick_lnkCategoryDelete(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.hid_CategoryID.Value);
            if (num != 0)
            {
                SettingsBasePage.PriceCatalogue_Category_Delete(this.CompanyID, num);
                SettingsBasePage.PriceCatalogue_Category_Select(this.CompanyID, this.ddlPriceCatalogueCategory);
                this.ddlPriceCatalogueCategory.Items.Insert(0, " ");
                this.ddlPriceCatalogueCategory.Items[0].Text = "--- Select Category ---";
                this.ddlPriceCatalogueCategory.Items[0].Value = "0";
                this.ddlPriceCatalogueCategory.SelectedIndex = 0;
            }
        }

        protected void OnClick_lnkSaveGroupandFinal(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }
            this.SaveGroup();
            this.FinalSave("Additional", "saveandstay");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridWebOtherCostPendingOrders.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
            GridFilterMenu gridFilterMenu = this.GridAvaialbleCoupncodes.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (gridFilterMenu.Items[j].Text == "Custom")
                {
                    gridFilterMenu.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "between")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (ConnectionClass.IsCBM != null)
            {
                if (ConnectionClass.IsCBM.ToString().ToLower() != "true")
                {
                    this.divCBMActive.Visible = false;
                }
                else
                {
                    this.divCBMActive.Visible = true;

                }
            }

            if (ConnectionClass.isMatrixCalculation != null)
            {
                if (ConnectionClass.isMatrixCalculation.ToString().ToLower() != "true")
                {
                    this.hdn_isMatrixCalculation.Value = "false";
                }
                else
                {
                    this.hdn_isMatrixCalculation.Value = "true";

                }
            }

            string[] clientID;
            object[] str;
            global.pageName = "productcatalogue";
            (new BaseClass()).ReturnRoles_Privileges_Tabs("productcatalogue", "isview", "");
            this.SecDocumentSitePath = this.SecureSitePath;
            this.ucEditableProduct.btnSave_ClickEventHandler += new Editproductsave(this.ucEditableProduct_btnSave_ClickEventHandler);
            ProductCatalogue_item.ChkIsEditable = "false";
            if (base.Request.Params["EstID"] != null)
            {
                this.EstID = Convert.ToInt64(base.Request.Params["EstID"].ToString());
            }
            if (base.Request.Params["EstItemID"] != null)
            {
                this.EstItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
            }
            if (base.Request.Params["EstType"] != null)
            {
                this.EstType = base.Request.Params["EstType"].ToString();
            }
            if (base.Request.Params["pgFrom"] != null)
            {
                this.pgFrom = base.Request.Params["pgFrom"].ToString();
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (this.EditableTemplate.ToLower() != "on")
            {
                this.ChkEditableProduct.Enabled = false;
                this.div_ManageStockMsg.Style.Add("display", "block");
            }
            else
            {
                this.ChkEditableProduct.Enabled = true;
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string _str = SettingsBasePage.Fetch_SelectedAccountID(Convert.ToInt32(this.Session["UserID"].ToString()));
            int AccountID = 0;
            if (_str != "")
            {
                string[] _strArrays = _str.Split(new char[] { '~' });
                AccountID = Convert.ToInt32(_strArrays[0]);
            }
            DataTable _dt = WebstoreBasePage.OrderMangerOptions_Select(Convert.ToInt32(this.CompanyID), Convert.ToInt32(AccountID));
            foreach (DataRow row in _dt.Rows)
            {
                if (!Convert.ToBoolean(row["CartJobNameShow"]))
                {
                    //this.divlblJobName.InnerText = row["CartJobScreenName"].ToString();
                    this.divlblJobName.InnerText = "Display Job Name in product screen";
                    this.divlblJobName.Visible = false;
                    this.divchkJobName.Visible = false;
                }
                else
                {
                    //this.divlblJobName.InnerText = row["CartJobScreenName"].ToString();
                    this.divlblJobName.InnerText = "Display Job Name in product screen";
                    this.divlblJobName.Visible = true;
                    this.divchkJobName.Visible = true;
                    //if (!Convert.ToBoolean(row["CartJobNameIsMandatory"]))
                    //{
                    //    this.chkJobNameRequired.Checked = false;
                    //    this.chkJobNameRequired.Enabled = true;
                    //}
                    //else
                    //{
                    //    this.chkJobNameRequired.Checked = true;
                    //    this.chkJobNameRequired.Enabled = true;
                    //}
                }
            }
            if (!base.IsPostBack)
            {
                SettingsBasePage.Bind_TaxRate(this.ddl_SaleTaxRate, this.CompanyID, string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---"));
                SettingsBasePage.Bind_AccountingCodes_New(this.ddl_AccountingCode, this.CompanyID, string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---"));
                SettingsBasePage.Bind_AccountingCodes_New(this.ddl_PurchaseAccountingCode, this.CompanyID, string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---"));
                string str1 = "0";
                foreach (DataRow row in SettingsBasePage.settings_system_markup_select(this.CompanyID).Rows)
                {
                    str1 = row["taxid"].ToString();
                }

                DataTable dataTable205 = SettingsBasePage.settings_companyprofile_select(Convert.ToInt16(base.Session["Companyid"]));
                string countryName205 = Convert.ToString(dataTable205.Rows[0]["Country"]);

                //if (countryName205 == "United States")
                //{
                //    this.ddl_SaleTaxRate.SelectedIndex = this.ddl_SaleTaxRate.Items.IndexOf(this.ddl_SaleTaxRate.Items.FindByValue("0"));
                //}
                //else
                //{
                //    this.ddl_SaleTaxRate.SelectedIndex = this.ddl_SaleTaxRate.Items.IndexOf(this.ddl_SaleTaxRate.Items.FindByValue(str1));
                //}
                this.ddl_SaleTaxRate.SelectedIndex = this.ddl_SaleTaxRate.Items.IndexOf(this.ddl_SaleTaxRate.Items.FindByValue("0"));

                if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsPreflightEnable"]))
                {
                    this.divDefaultPreflightProfile.Style.Add("display", "block");
                }
                DataTable dataTable = SettingsBasePage.PreFlight_Options_Select("MIS", this.CompanyID);
                string str2 = "0";
                if (dataTable.Rows.Count != 0)
                {
                    DataTable dataTable1 = CompanyBasePage.PreflightProfile_Select();
                    this.ddlPreflightFiles.DataSource = dataTable1;
                    this.ddlPreflightFiles.DataTextField = "ProfileName";
                    this.ddlPreflightFiles.DataValueField = "Id";
                    this.ddlPreflightFiles.DataBind();
                    this.ddlPreflightFiles.Items.Insert(0, new ListItem("--- Select Profile ---", "0"));
                    this.ddlDefaultPreFlightProfile.DataSource = dataTable1;
                    this.ddlDefaultPreFlightProfile.DataTextField = "ProfileName";
                    this.ddlDefaultPreFlightProfile.DataValueField = "Id";
                    this.ddlDefaultPreFlightProfile.DataBind();
                    this.ddlDefaultPreFlightProfile.Items.Insert(0, new ListItem("--- Select Profile ---", "0"));
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        str2 = dataRow["ProfileId"].ToString();
                        if (Convert.ToInt32(dataRow["IsEnabled"]) != 1)
                        {
                            this.hdn_IsPreFlight.Value = "0";
                            this.chkPreflightFiles.Visible = false;
                            this.ddlPreflightFiles.Visible = false;
                            this.divPreFlight.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            AttributeCollection attributes = this.chkPreflightFiles.Attributes;
                            clientID = new string[] { "javascript:EnablePreFlightDdl(", this.chkPreflightFiles.ClientID, ",", this.ddlPreflightFiles.ClientID, ");" };
                            attributes.Add("onclick", string.Concat(clientID));
                            this.hdn_IsPreFlight.Value = "1";
                        }
                    }
                    this.ddlPreflightFiles.SelectedIndex = this.ddlPreflightFiles.Items.IndexOf(this.ddlPreflightFiles.Items.FindByValue(str2));
                    this.chkPreflightFiles.Checked = false;
                    this.ddlPreflightFiles.Enabled = false;
                }
                else
                {
                    this.hdn_IsPreFlight.Value = "0";
                    this.chkPreflightFiles.Visible = false;
                    this.ddlPreflightFiles.Visible = false;
                    this.divPreFlight.Attributes.Add("style", "display:none");
                }
            }
            if (!base.IsPostBack)
            {
               if (commonClass.CheckFTPEnable())
                {
                    //div_FTP.Visible = true;
                    li_FTPOption.Visible = true;
                    BindFtpFolders();
                    BindTags();
                }
                else
                {
                    li_FTPOption.Visible = false;
                }
                SettingsBasePage.Bind_PressNames(this.ddlPressName, this.CompanyID);
                if (base.Request.Params["action"] == null || !(base.Request.Params["action"].ToString().ToLower() == "edit"))
                {


                    if (ConnectionClass.IsDecoration.ToLower()=="true")
                    {

                        SetDDItems(ddlDecoration1_Mandatory, "No");
                        SetDDItems(ddlDecoration2_Mandatory, "No");
                        SetDDItems(ddlDecoration3_Mandatory, "No");
                        SetDDItems(ddlDecoration4_Mandatory, "No");
                        SetDDItems(ddlDecoration5_Mandatory, "No");
                        SetDDItems(ddlDecoration6_Mandatory, "No");
                    }
                }
            }

           
            string str3 = this.objBaseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isadd", this.Page.Request.Url.ToString());
            string str4 = this.objBaseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdelete", this.Page.Request.Url.ToString());
            this.txt_lblItemtitle1.Text = this.objlang.GetValueOnLang("Item Title");
            this.txt_lblItemtitle.Text = this.objlang.GetValueOnLang("Item Title");
            this.txt_lblDescription.Text = this.objlang.GetValueOnLang("Description");
            this.txt_lblArtwork.Text = this.objlang.GetValueOnLang("Artwork");
            this.txt_lblColour.Text = this.objlang.GetValueOnLang("Colour");
            this.txt_lblSize.Text = this.objlang.GetValueOnLang("Size");
            this.txt_lblMaterial.Text = this.objlang.GetValueOnLang("Material");
            this.txt_lblDelivery.Text = this.objlang.GetValueOnLang("Delivery");
            this.txt_lblFinishing.Text = this.objlang.GetValueOnLang("Finishing");
            this.txt_lblProofs.Text = this.objlang.GetValueOnLang("Proofs");
            this.txt_lblPacking.Text = this.objlang.GetValueOnLang("Packing");
            this.txt_lblNotes.Text = this.objlang.GetValueOnLang("Notes");
            this.txt_lblInstructions.Text = this.objlang.GetValueOnLang("Terms/Instructions");
            this.chkNonEditable.Text = this.objlang.GetValueOnLang("Non-editable");
            this.btnCategorySave.Text = this.objlang.GetValueOnLang("Save");
            this.lblproductVisible.Text = this.objlang.GetLanguageConversion("Product_Visible_To_Customer_Public_Accounts");
            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnNext1.Text = this.objlang.GetLanguageConversion("Next");
            this.lblQuantity.Text = this.objlang.GetValueOnLang("Quantity");
            this.lblPrice.Text = this.objlang.GetValueOnLang("Price");
            this.btnPrevious1.Text = this.objlang.GetLanguageConversion("Previous");
            this.btnNext2.Text = this.objlang.GetLanguageConversion("Next");
            this.btnPriceSaveandStay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.btnPriceSave.Text = this.objlang.GetLanguageConversion("Save");
            this.ChkShortDescription.Text = this.objlang.GetLanguageConversion("Short_Description");
            this.ChkItemDescription.Text = this.objlang.GetLanguageConversion("Item_Description");
            this.ChkPriceStart.Text = this.objlang.GetLanguageConversion("Price_Start_from");
            this.ChkPriceList.Text = this.objlang.GetLanguageConversion("Price_List");
            this.chkpricesubtotaltax.Text = this.objlang.GetLanguageConversion("price_tax_subtotal");
            this.ChkUnitPrice.Text = this.objlang.GetLanguageConversion("Unit_Price");
            this.ChkPackPrice.Text = this.objlang.GetLanguageConversion("Pack_Price");
            this.btnPrevious2.Text = this.objlang.GetLanguageConversion("Previous");
            this.btnNext3.Text = this.objlang.GetLanguageConversion("Next");
            this.btnArtworkSaveandStay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.btnArtworkSave.Text = this.objlang.GetLanguageConversion("Save");
            this.GridWebOtherCostPendingOrders.MasterTableView.Columns[1].HeaderText = this.objlang.GetValueOnLang("Category");
            this.GridWebOtherCostPendingOrders.MasterTableView.Columns[2].HeaderText = this.objlang.GetValueOnLang("Name");
            this.GridWebOtherCostShippedOrders.MasterTableView.Columns[2].HeaderText = this.objlang.GetValueOnLang("Category");
            this.GridWebOtherCostShippedOrders.MasterTableView.Columns[3].HeaderText = this.objlang.GetValueOnLang("Name");
            this.btnPrevious3.Text = this.objlang.GetLanguageConversion("Previous");
            this.btnAdditionalSaveandStay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.btnFinalSave.Text = this.objlang.GetLanguageConversion("Save");
            this.btn_CouponCode_Previous.Text = this.objlang.GetLanguageConversion("Previous");
            this.btn_CouponCode_SaveStay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.btn_CouponCode_Save.Text = this.objlang.GetLanguageConversion("Save");
            this.btn_CouponCode_SaveMangeStock.Text = this.objlang.GetLanguageConversion("Save_Manage_Stock");
            this.rdbnoneditable.Text = this.objlang.GetLanguageConversion("Non_Editable");
            this.chkstockitem.Text = this.objlang.GetLanguageConversion("This_Is_A_Stock_Item");
            this.chkbackorders.Text = this.objlang.GetLanguageConversion("Allow_Back_Orders");
            this.ChkEditableProduct.Text = this.objlang.GetLanguageConversion("Editable");
            this.img_thumbNail.Title = this.objlang.GetLanguageConversion("ThumbNail_Img_Description");
            this.img_PrintReady_File.Title = this.objlang.GetLanguageConversion("Print_Ready_Img_Description");
            this.chkForceUser.Text = this.objlang.GetLanguageConversion("Force_user_to_view_and_approve_PDF_before_ordering");
            this.img_Help_ShortDescritpion_Link.Title = this.objlang.GetLanguageConversion("This_appears_in_the_Product_Category_Screen");
            this.img_help_Item_Description_Link.Title = this.objlang.GetLanguageConversion("This_appears_in_the_Product_Details_Screen");
            this.lblAvailableOptions.Text = this.objlang.GetLanguageConversion("Available_Options");
            this.lblSelectedOptions.Text = this.objlang.GetLanguageConversion("Selected_Options");
            this.text1.Title = this.objlang.GetLanguageConversion("Additional_Options_Help_Text");
            this.btngenstay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.btngensave.Text = this.objlang.GetLanguageConversion("Save");
            this.btngenmanagestock.Text = this.objlang.GetLanguageConversion("Save_Manage_Stock");
            this.btnprice_managestock.Text = this.objlang.GetLanguageConversion("Save_Manage_Stock");
            this.btnestoresavestock.Text = this.objlang.GetLanguageConversion("Save_Manage_Stock");
            this.btnadditionalstocksave.Text = this.objlang.GetLanguageConversion("Save_Manage_Stock");
            this.RadListBox3.Items[0].Text = this.objlang.GetLanguageConversion("Add_Group");
            this.RadListBox3.Items[1].Text = this.objlang.GetLanguageConversion("Remove_Group");
            this.GridWebOtherCostShippedOrders.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_Records_To_Display");
            this.GridWebOtherCostPendingOrders.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_Records_To_Display");
            this.lblOwnerShip.Text = this.objLanguage.GetLanguageConversion("Ownership");
            this.lblCustomers.Text = this.objLanguage.GetLanguageConversion("Customers");
            this.lblCustomerNone.Text = this.objLanguage.GetLanguageConversion("None");
            this.lblSpecificToCustomer.Text = this.objLanguage.GetLanguageConversion("Specific_To_Customer");
            this.lblCustomerSelectedAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.lblAllocation.Text = this.objlang.GetLanguageConversion("Allocation");
            this.lblMaxLenghtText1.Text = this.objlang.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000");
            this.lblMaxLenghtText2.Text = this.objlang.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000");
            this.spn_txtFinishing.InnerText = this.objlang.GetValueOnLang("Please enter Finishing");
            this.spn_txtDelivery.InnerText = this.objlang.GetValueOnLang("Please enter Delivery");
            this.spn_Size_Validation.InnerText = this.objlang.GetValueOnLang("Please enter Size");
            this.spn_colour_Validation.InnerText = this.objlang.GetValueOnLang("Please enter colorformat");
            this.spn_Arkwork_Validation.InnerText = this.objlang.GetValueOnLang("Please enter Artwork");
            this.lblDescription.Text = this.objlang.GetLanguageConversion("Description");
            this.spn_txtItemTitle.InnerText = this.objlang.GetLanguageConversion("Please_ENter_Item_Title");
            this.spn_Item_Name_Validation.InnerText = this.objlang.GetLanguageConversion("Please_enter_Item_Name");
            this.lblPriceing.Text = this.objlang.GetLanguageConversion("Pricing");
            this.lblGeneral.Text = this.objLanguage.GetLanguageConversion("General");
            this.lblheader.Text = string.Concat(this.objlang.GetLanguageConversion("Products"), " : ", this.objlang.GetLanguageConversion("Product_Catalogue"));
            this.lbleStoreSettingsPanel.Text = this.objlang.GetLanguageConversion("eStore_Settings_Panel");
            this.lblEditPRoduct.Text = this.objlang.GetLanguageConversion("Edit_Product");
            this.lblAdditionalOptions.Text = this.objlang.GetLanguageConversion("Additional_Options");
            this.lblItem_Code.Text = this.objLanguage.GetLanguageConversion("Item_Code");
            this.spn_Item_Code_Entry_Validation.InnerText = this.objlang.GetLanguageConversion("Please_enter_Item_Code");
            this.spn_Item_code_Exists_Validation.InnerText = this.objlang.GetLanguageConversion("Item_Code_already_exists");
            this.lblProductType.Text = this.objlang.GetLanguageConversion("Product_Type");
            this.lblManageStockPleaseNote.Text = this.objlang.GetLanguageConversion("Manage_Stock_PleaseNote");
            this.lblEdiatableTemplatePleaseNote.Text = this.objlang.GetLanguageConversion("Enable_Editable_Template_Please_Note");
            this.lblPRoductType1.Text = this.objLanguage.GetLanguageConversion("Product_Type");
            this.lblCategory_Name.Text = this.objlang.GetLanguageConversion("Category_Name");
            this.spn_CategoryName_Validation.InnerText = this.objlang.GetValueOnLang("Please enter Category Name");
            this.spn_Category_Name.InnerText = this.objlang.GetValueOnLang("Category Name");
            this.lblcustcode.Text = this.objLanguage.GetLanguageConversion("p_Customer_code");
            this.Label2.Text = this.objlang.GetLanguageConversion("Supplier");
            this.Span2.InnerText = this.objlang.GetValueOnLang("Please select Supplier");
            this.chksetPrAsProductimg.Text = this.objlang.GetLanguageConversion("chksetPrAsProductimg_CreateThumbnail");
            this.gloobj.setpagename("productcatalogue");
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            DataTable dataTable2 = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            this.hidweightunit.Value = dataTable2.Rows[0]["GeneralWeight"].ToString();
            this.Measurementvalue = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.Measurementvalue2 = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");

            if (this.Measurementvalue == "In.")
            {
                this.lblType.Text = "in inches";
            }
            else
            {
                this.lblType.Text = "in centimeters";
            }
            string GeneralWeight = SettingsBasePage.settings_companyweight_select(this.CompanyID);
            if (GeneralWeight.ToLower() == "kgs" || GeneralWeight.ToLower() == "kilogram")
            {
                this.Label8.Text = "Weight (kgs)";
            }
            else if (GeneralWeight.ToLower() == "lbs" || GeneralWeight.ToLower() == "pound")
            {
                this.Label8.Text = "Weight (lbs)";
            }
            else
            {
                this.Label8.Text = "Weight"; // Default if neither kgs, kilogram, lbs, nor pound
            }
            DataTable dataTable3 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            ProductCatalogue_item.CompanyName = dataTable3.Rows[0]["CompanyName"].ToString();
            ProductCatalogue_item.ManageStockPermission = Convert.ToInt32(dataTable3.Rows[0]["ProductStockManagement"]);
            DropDownList dropDownList = new DropDownList();
            CompanyBasePage.company_ownership_customer_bind(this.CompanyID, "customer", dropDownList);
            for (int i = 0; i < dropDownList.Items.Count; i++)
            {
                if (dropDownList.Items[i].Value == "0")
                {
                    ListItem listItem = new ListItem();
                    ListItem listItem1 = new ListItem();
                    if (i == 0)
                    {
                        listItem.Text = string.Concat("Owned By Self (", dataTable3.Rows[0]["CompanyName"].ToString(), ")");
                        listItem.Value = "1";
                        listItem1.Text = "Owned By Clients";
                        listItem1.Value = "space";
                        listItem1.Attributes.Add("disabled", "disabled");
                        this.lstownership.Items.Add(listItem);
                        this.lstownership.Items.Add(listItem1);
                    }
                }
                else
                {
                    ListItem listItem2 = new ListItem()
                    {
                        Text = base.SpecialDecode(dropDownList.Items[i].Text),
                        Value = dropDownList.Items[i].Value
                    };
                    this.lstownership.Items.Add(listItem2);
                }
            }
            if (base.Request.Params["id"] != null)
            {
                this.productCatalogID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (base.IsPostBack)
            {
                this.hidmode.Value = "";
            }
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["from"] != null)
            {
                this.RedirectTo = base.Request.Params["from"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString() != "")
            {
                this.item = base.Request.Params["item"].ToString();
            }
            if (base.Request.Params["action"] == null || !(base.Request.Params["action"].ToString().ToLower() == "edit"))
            {
                base.Navigation_Path(string.Concat("<a href='#' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../ProductCatalogue/PriceCatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Product_Catalogue"), "</a> &nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Product_Catalogue_Add")));
            }
            else
            {
                base.Navigation_Path(string.Concat("<a href='#' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../ProductCatalogue/PriceCatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Product_Catalogue"), "</a> &nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Product_Catalogue_Edit")));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
            if (base.Request.Params["id"] != null)
            {
                if (base.Request.Params["id"].ToString() != "")
                {
                    this.ProductCatalogueID = Convert.ToInt32(base.Request.Params["id"].ToString());
                }
                if (base.Request.Params["page"] != null)
                {
                    this.PageType = base.Request.Params["page"].ToString();
                }
            }
            if (base.Request.Params["action"] == null)
            {
                this.action = "add";
                this.hidmode.Value = "add";
            }
            else
            {
                this.action = base.Request.Params["action"].ToString();
            }
            if (base.Request.Params["clientID"] != null && base.Request.Params["clientID"].ToString() != "")
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientID"].ToString());
            }
            try
            {
                if (ConnectionClass.WebStore != null)
                {
                    ProductCatalogue_item.WebStore = ConnectionClass.WebStore.ToString();
                }
            }
            catch
            {
            }
            if (ProductCatalogue_item.WebStore.ToLower() != "yes")
            {
                this.btnNext2.Visible = true;
                this.div_NoPublicAccount.Style.Add("display", "block");
            }
            else
            {
                clientID = new string[1];
                string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
                clientID[0] = string.Concat(secureVirtualPath);
                string[] strArrays = clientID;
                this.RadEdit_txtItemdescriprion.ImageManager.UploadPaths = strArrays;
                this.RadEdit_txtItemdescriprion.ImageManager.ViewPaths = strArrays;
                this.RadEdit_txtItemdescriprion.FlashManager.ViewPaths = strArrays;
                this.RadEdit_txtItemdescriprion.FlashManager.UploadPaths = strArrays;
                this.RadEdit_txtItemdescriprion.DocumentManager.ViewPaths = strArrays;
                this.RadEdit_txtItemdescriprion.DocumentManager.UploadPaths = strArrays;
                this.RadEdit_txtItemdescriprion.Height = Unit.Pixel(235);
                this.RadEdit_txtItemdescriprion.Width = Unit.Pixel(660);
                if (ConnectionClass.RadEditorUploadSize != null)
                {
                    this.RadEdit_txtItemdescriprion.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
                }
                this.btnNext2.Visible = true;
                this.btnPriceSave.Visible = true;
                this.btnPriceSaveandStay.Visible = true;
                this.div_userArtwork.Attributes.Add("style", "display:block");
                this.publicAccount_label.Style.Add("display", "block");
                this.divproductVisible.Style.Add("display", "block");
            }
            if (ProductCatalogue_item.ManageStockPermission != 1)
            {
                this.div_stockcontentdiv.Style.Add("display", "none");
                this.divOwnership.Style.Add("display", "none");
                this.divproductType.Attributes.Add("style", "height:30px");
                this.divDrawStockFrom.Style.Add("display", "none");
            }
            else
            {
                this.div_stockcontentdiv.Style.Add("display", "block");
                this.divOwnership.Style.Add("display", "block");
                this.divDrawStockFrom.Style.Add("display", "block");
            }
            bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
            this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
            if (this.UnitOfMeasureKey)
            {
                this.div_UnitOfMeasure.Style.Add("display", "block");
            }
            if (!base.IsPostBack)
            {
                this.BindGroup("");
                this.Session[string.Concat("AllocatedCust_", this.productCatalogID)] = null;
                CompanyBasePage companyBasePage = new CompanyBasePage();
                DropDownList dropDownList1 = new DropDownList();
                this.objAcc.publicAccount_bind('x', this.CompanyID, dropDownList1);
                if (ProductCatalogue_item.WebStore.ToLower() == "yes" && dropDownList1.Items.Count > 0)
                {
                    this.totalPublicNo = dropDownList1.Items.Count;
                    this.publicAccount_label.Style.Add("display", "block");
                    for (int j = 0; j < dropDownList1.Items.Count; j++)
                    {
                        if (dropDownList1.Items[j].Value == "0")
                        {
                            RadListBoxItem radListBoxItem = new RadListBoxItem();
                            if (j == 0)
                            {
                                radListBoxItem.Text = "";
                                radListBoxItem.Value = "0";
                                this.lstStatus.Items.Add(radListBoxItem);
                            }
                        }
                        else
                        {
                            RadListBoxItem radListBoxItem1 = new RadListBoxItem()
                            {
                                Text = string.Concat(dropDownList1.Items[j].Text, " ", this.WebStorePathB2C),
                                Value = dropDownList1.Items[j].Value
                            };
                            radListBoxItem1.Style.Add("width", "125%");
                            this.lstStatus.Items.Add(radListBoxItem1);
                        }
                    }
                }
                if (this.action != "edit")
                {
                    this.lstStatus.SelectedValue = " None";
                }
                ProductCatalogue_item.TempProductID = 0;
                companyBasePage.company_supplier_select(this.CompanyID, this.ddlSupplier);
                if (base.Request.QueryString["suplrid"] != null)
                {
                    DropDownList dropDownList2 = this.ddlSupplier;
                    long num = Convert.ToInt64(base.Request.QueryString["suplrid"]);
                    dropDownList2.SelectedValue = num.ToString();
                }
                if (this.AccountingCode == "d")
                {
                    this.div_AccountCode.Visible = false;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
            }
            this.txt_lblItemtitle.Text = "Item Title";
            this.txt_lblDescription.Text = "Description";
            this.txt_lblArtwork.Text = "Artwork";
            this.txt_lblColour.Text = "Colour";
            this.txt_lblSize.Text = "Size";
            this.txt_lblMaterial.Text = "Material";
            this.txt_lblDelivery.Text = "Delivery";
            this.txt_lblFinishing.Text = "Finishing";
            this.txt_lblProofs.Text = "Proofs";
            this.txt_lblPacking.Text = "Packing";
            this.txt_lblNotes.Text = "notes";
            this.txt_lblInstructions.Text = "Terms/Instructions";
            this.txtItemTitle.Attributes.Add("onfocus", "this.select()");
            this.txtDescription.Attributes.Add("onfocus", "this.select()");
            this.txtArtwork.Attributes.Add("onfocus", "this.select()");
            this.txtNotes.Attributes.Add("onfocus", "this.select()");
            this.txtInstructions.Attributes.Add("onfocus", "this.select()");
            this.TakeItemDesc();
            if (!base.IsPostBack)
            {
                this.Session["WebOtherCostPendingOrders"] = null;
                this.Session["WebOtherCostShippedOrders"] = null;
                this.Session["AvaliableCouponCodes"] = null;
                this.Session["SelectedCouponCodes"] = null;
                DataTable dataTable4 = WebstoreBasePage.Select_ProductCategory_List((long)this.CompanyID, "ProductItem", (long)0);
                for (int k = 0; k < dataTable4.Columns.Count; k++)
                {
                    dataTable4.Columns[k].ReadOnly = false;
                }
                this.ddlPriceCatalogueCategory.DataSource = dataTable4;
                this.ddlPriceCatalogueCategory.DataTextField = "MultiLevelCategory";
                this.ddlPriceCatalogueCategory.DataValueField = "CategoryID";
                this.ddlPriceCatalogueCategory.DataBind();
                this.ddlMatrixType.Items.Insert(0, " ");
                this.ddlMatrixType.Items[0].Text = "Price Bands";
                this.ddlMatrixType.Items[0].Value = "pricebands";
                this.ddlMatrixType.Items.Insert(1, " ");
                this.ddlMatrixType.Items[1].Text = "Simple Matrix";
                this.ddlMatrixType.Items[1].Value = "simplematrix";
                this.ddlMatrixType.SelectedIndex = 1;
                this.ddlMatrixType.Items.Insert(2, " ");
                this.ddlMatrixType.Items[2].Text = "Large Format Matrix";
                this.ddlMatrixType.Items[2].Value = "signagematrix";
                if (this.action == "add")
                {
                    this.ddlMatrixType.SelectedValue = "simplematrix";
                }
                if (base.Request.Params["ToConvert"] != null && base.Request.Params["ToConvert"].ToLower() == "yes")
                {
                    this.ddlMatrixType.SelectedValue = "simplematrix";
                }
            }
            if (base.Request.Params["cop"] == "yes")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Copy_Of_Product_Catalogue_Is_Successfully_Done"), "msg-success", this.plhMessage);
            }
            if (ConnectionClass.IsHandy)
            {
                this.div_Sides.Style.Add("display", "block");
            }
            if (base.Request.Params["action"] != "edit")
            {
                if (!base.IsPostBack)
                {
                    DataTable autogenerateItemCode = WebstoreBasePage.getAutogenerate_ItemCode(this.CompanyID);
                    this.txtitemcode.Text = autogenerateItemCode.Rows[0][0].ToString();
                    this.div_ProductType.Style.Add("display", "none");
                    this.lstownership.Items[0].Selected = true;
                    if (base.Request.Params["ToConvert"] != null && base.Request.Params["ToConvert"].ToLower() == "yes")
                    {
                        this.action = "Create";
                        if (base.Request.Params["EstID"] != null)
                        {
                            this.EstID = Convert.ToInt64(base.Request.Params["EstID"].ToString());
                        }
                        if (base.Request.Params["EstItemID"] != null)
                        {
                            this.EstItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
                        }
                        if (base.Request.Params["EstType"] != null)
                        {
                            this.EstType = base.Request.Params["EstType"].ToString();
                        }
                        string empty = string.Empty;
                        string empty1 = string.Empty;
                        DataSet dataSet = WebstoreBasePage.select_ItemDetalis_ForProduct(this.CompanyID, this.EstID, this.EstItemID, this.EstType);
                        foreach (DataRow row1 in dataSet.Tables[0].Rows)
                        {
                            if (row1["IsItemTitle"].ToString().ToLower() == "true")
                            {
                                this.txtCatalogueName.Text = base.SpecialDecode(row1["ItemTitleValue"].ToString());
                                this.hdn_itemtitle.Value = row1["ItemTitleValue"].ToString();
                                this.txtItemTitle.Text = row1["ItemTitleValue"].ToString();
                            }
                            if (row1["IsDescription"].ToString().ToLower() == "true")
                            {
                                this.txtDescription.Text = base.SpecialDecode(row1["DescriptionValue"].ToString());
                            }
                            if (row1["IsArtwork"].ToString().ToLower() == "true")
                            {
                                this.txtArtwork.Text = base.SpecialDecode(row1["ArtworkValue"].ToString());
                            }
                            if (row1["IsColour"].ToString().ToLower() == "true")
                            {
                                this.txtColour.Text = base.SpecialDecode(row1["ColourValue"].ToString());
                            }
                            if (row1["IsSize"].ToString().ToLower() == "true")
                            {
                                this.txtSize.Text = base.SpecialDecode(row1["SizeValue"].ToString());
                            }
                            if (row1["IsMaterial"].ToString().ToLower() == "true")
                            {
                                this.txtMaterial.Text = base.SpecialDecode(row1["MaterialValue"].ToString());
                            }
                            if (row1["IsDelivery"].ToString().ToLower() == "true")
                            {
                                this.txtDelivery.Text = base.SpecialDecode(row1["DeliveryValue"].ToString());
                            }
                            if (row1["IsFinishing"].ToString().ToLower() == "true")
                            {
                                this.txtFinishing.Text = base.SpecialDecode(row1["FinishingValue"].ToString());
                            }
                            if (row1["IsProofs"].ToString().ToLower() == "true")
                            {
                                this.txtProofs.Text = base.SpecialDecode(row1["ProofsValue"].ToString());
                            }
                            if (row1["IsPacking"].ToString().ToLower() == "true")
                            {
                                this.txtPacking.Text = base.SpecialDecode(row1["PackingValue"].ToString());
                            }
                            if (row1["IsNotes"].ToString().ToLower() == "true")
                            {
                                this.txtNotes.Text = base.SpecialDecode(row1["NotesValue"].ToString());
                            }
                            if (row1["IsInstructions"].ToString().ToLower() == "true")
                            {
                                this.txtInstructions.Text = base.SpecialDecode(row1["InstructionsValue"].ToString());
                            }
                            if (row1["IsCustomDescription1"].ToString().ToLower() == "true")
                            {
                                this.txtCustom1.Text = base.SpecialDecode(row1["CustomDescriptionValue1"].ToString());
                            }
                            if (row1["IsCustomDescription2"].ToString().ToLower() == "true")
                            {
                                this.txtCustom2.Text = base.SpecialDecode(row1["CustomDescriptionValue2"].ToString());
                            }
                            if (row1["IsCustomDescription3"].ToString().ToLower() == "true")
                            {
                                this.txtCustom3.Text = base.SpecialDecode(row1["CustomDescriptionValue3"].ToString());
                            }
                            if (row1["IsCustomDescription4"].ToString().ToLower() == "true")
                            {
                                this.txtCustom4.Text = base.SpecialDecode(row1["CustomDescriptionValue4"].ToString());
                            }
                            if (row1["IsCustomDescription5"].ToString().ToLower() == "true")
                            {
                                this.txtCustom5.Text = base.SpecialDecode(row1["CustomDescriptionValue5"].ToString());
                            }
                            if (row1["IsCustomDescription6"].ToString().ToLower() == "true")
                            {
                                this.txtCustom6.Text = base.SpecialDecode(row1["CustomDescriptionValue6"].ToString());
                            }
                            if (row1["IsCustomDescription7"].ToString().ToLower() == "true")
                            {
                                this.txtCustom7.Text = base.SpecialDecode(row1["CustomDescriptionValue7"].ToString());
                            }
                            if (row1["IsCustomDescription8"].ToString().ToLower() == "true")
                            {
                                this.txtCustom8.Text = base.SpecialDecode(row1["CustomDescriptionValue8"].ToString());
                            }
                            if (row1["IsCustomDescription9"].ToString().ToLower() == "true")
                            {
                                this.txtCustom9.Text = base.SpecialDecode(row1["CustomDescriptionValue9"].ToString());
                            }
                            if (row1["IsCustomDescription10"].ToString().ToLower() == "true")
                            {
                                this.txtCustom10.Text = base.SpecialDecode(row1["CustomDescriptionValue10"].ToString());
                            }
                            if (row1["IsCustomDescription11"].ToString().ToLower() == "true")
                            {
                                this.txtCustom11.Text = base.SpecialDecode(row1["CustomDescriptionValue11"].ToString());
                            }
                            if (row1["IsCustomDescription12"].ToString().ToLower() == "true")
                            {
                                this.txtCustom12.Text = base.SpecialDecode(row1["CustomDescriptionValue12"].ToString());
                            }
                            if (row1["IsCustomDescription13"].ToString().ToLower() == "true")
                            {
                                this.txtCustom13.Text = base.SpecialDecode(row1["CustomDescriptionValue13"].ToString());
                            }
                            if (row1["IsCustomDescription14"].ToString().ToLower() == "true")
                            {
                                this.txtCustom14.Text = base.SpecialDecode(row1["CustomDescriptionValue14"].ToString());
                            }
                            if (row1["IsCustomDescription15"].ToString().ToLower() == "true")
                            {
                                this.txtCustom15.Text = base.SpecialDecode(row1["CustomDescriptionValue15"].ToString());
                            }
                            if (row1["IsCustomDescription16"].ToString().ToLower() == "true")
                            {
                                this.txtCustom16.Text = base.SpecialDecode(row1["CustomDescriptionValue16"].ToString());
                            }
                            if (row1["IsCustomDescription17"].ToString().ToLower() == "true")
                            {
                                this.txtCustom17.Text = base.SpecialDecode(row1["CustomDescriptionValue17"].ToString());
                            }
                            if (row1["IsCustomDescription18"].ToString().ToLower() == "true")
                            {
                                this.txtCustom18.Text = base.SpecialDecode(row1["CustomDescriptionValue18"].ToString());
                            }
                            if (row1["IsCustomDescription19"].ToString().ToLower() == "true")
                            {
                                this.txtCustom19.Text = base.SpecialDecode(row1["CustomDescriptionValue19"].ToString());
                            }
                            if (row1["IsCustomDescription20"].ToString().ToLower() == "true")
                            {
                                this.txtCustom20.Text = base.SpecialDecode(row1["CustomDescriptionValue20"].ToString());
                            }
                            if (row1["IsCustomDescription21"].ToString().ToLower() == "true")
                            {
                                this.txtCustom21.Text = base.SpecialDecode(row1["CustomDescriptionValue21"].ToString());
                            }
                            if (row1["IsCustomDescription22"].ToString().ToLower() == "true")
                            {
                                this.txtCustom22.Text = base.SpecialDecode(row1["CustomDescriptionValue22"].ToString());
                            }
                            if (row1["IsCustomDescription23"].ToString().ToLower() == "true")
                            {
                                this.txtCustom23.Text = base.SpecialDecode(row1["CustomDescriptionValue23"].ToString());
                            }
                            if (row1["IsCustomDescription24"].ToString().ToLower() == "true")
                            {
                                this.txtCustom24.Text = base.SpecialDecode(row1["CustomDescriptionValue24"].ToString());
                            }
                            if (row1["IsCustomDescription25"].ToString().ToLower() == "true")
                            {
                                this.txtCustom25.Text = base.SpecialDecode(row1["CustomDescriptionValue25"].ToString());
                            }
                            if (this.txtCustom1.Text != "" || this.txtCustom2.Text != "")
                            {
                                this.divcd_1.Style.Add("display", "block");
                            }
                            if (this.txtCustom3.Text != "" || this.txtCustom4.Text != "")
                            {
                                this.divcd_2.Style.Add("display", "block");
                            }
                            if (this.txtCustom5.Text != "" || this.txtCustom6.Text != "")
                            {
                                this.divcd_3.Style.Add("display", "block");
                            }
                            if (this.txtCustom7.Text != "" || this.txtCustom8.Text != "")
                            {
                                this.divcd_4.Style.Add("display", "block");
                            }
                            if (this.txtCustom9.Text != "" && this.txtCustom10.Text != "")
                            {
                                this.divcd_5.Style.Add("display", "block");
                            }
                            if (this.txtCustom11.Text != "" || this.txtCustom12.Text != "")
                            {
                                this.divcd_6.Style.Add("display", "block");
                            }
                            if (this.txtCustom13.Text != "" || this.txtCustom14.Text != "")
                            {
                                this.divcd_7.Style.Add("display", "block");
                            }
                            if (this.txtCustom15.Text != "" || this.txtCustom16.Text != "")
                            {
                                this.divcd_8.Style.Add("display", "block");
                            }
                            if (this.txtCustom17.Text != "" || this.txtCustom18.Text != "")
                            {
                                this.divcd_9.Style.Add("display", "block");
                            }
                            if (this.txtCustom19.Text != "" || this.txtCustom20.Text != "")
                            {
                                this.divcd_10.Style.Add("display", "block");
                            }
                            if (this.txtCustom21.Text != "" || this.txtCustom22.Text != "")
                            {
                                this.divcd_11.Style.Add("display", "block");
                            }
                            if (this.txtCustom23.Text != "" || this.txtCustom24.Text != "")
                            {
                                this.divcd_12.Style.Add("display", "block");
                            }
                            if (this.txtCustom25.Text != "")
                            {
                                this.divcd_13.Style.Add("display", "block");
                            }
                            this.objBaseClass.SetDDLValue(this.ddlSupplier, row1["SupplierID"].ToString());
                           
                        }
                        int num1 = 0;
                        string empty2 = string.Empty;
                        string empty3 = string.Empty;
                        string empty4 = string.Empty;
                        string empty5 = string.Empty;
                        string str5 = string.Empty;
                        string empty6 = string.Empty;
                        string str6 = string.Empty;
                        string empty7 = string.Empty;
                        string str7 = string.Empty;
                        if (this.MatrixType == "S")
                        {
                            empty2 = "display:none;";
                            empty5 = "13%";
                            empty3 = "width:10%;";
                            empty6 = "10%";
                            str6 = "0px";
                        }
                        if (this.MatrixType == "G")
                        {
                            empty3 = "width:0%;";
                            empty4 = "display:none;";
                            empty5 = "20%";
                            empty6 = "15%";
                            str6 = "7%";
                        }
                        if (this.MatrixType == "P")
                        {
                            empty5 = "13%";
                            empty3 = "width:10%;";
                            empty6 = "10%";
                            str6 = "7%";
                        }
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (DataRow dataRow1 in dataSet.Tables[1].Rows)
                        {
                            string str8 = "";
                            if (num1 != 0)
                            {
                                str8 = (num1 % 2 != 0 ? "#EFEFEF" : "");
                            }
                            if (dataRow1["ToQuantity"].ToString() == "0")
                            {
                                continue;
                            }
                            stringBuilder.Append(string.Concat("<div id='td_", num1, "'>"));
                            str = new object[] { "<div id='div_row_", num1, "' style='background-color:", str8, ";height:25px;vertical-align:middle;' >" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div class='only5px' style='width: 100%;'>");
                            stringBuilder.Append("<table style='width:100%; table-layout: fixed' cellpadding='0px' cellspacing='0px' border='0px' >");
                            stringBuilder.Append("<tr>");
                            str = new object[] { "<td style='width:", str6, "' align='right' id='td_txtfrmqty_", num1, "'>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div nowrap=nowarp>");
                            str = new object[] { "<input type='text' id='txtQty_from_", num1, "' style='width:50px;text-align:right;", empty2, "'    maxlength=7 type='text'  value='", Convert.ToDecimal(dataRow1["FromQuantity"]).ToString("0.##"), "'  class='textboxnew'>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div></td>");
                            str = new object[] { "<td style='width: ", str6, ";' align='center' id='td_txtcenterqty_", num1, "'>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div>");
                            str = new object[] { "<span id='spn_qty_sep_", num1, "' style='", empty2, "'>-</span>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div></td>");
                            stringBuilder.Append("<td style='width: 7%;' align='right' id='td_txttoqty'>");
                            stringBuilder.Append(string.Concat("<div id='div_txtQty_", num1, "' >"));
                            str = new object[] { "<input id='txtQty_", num1, "'   style='width:80px;text-align:right;'  maxlength=7 type='text' value='", Convert.ToDecimal(dataRow1["ToQuantity"]).ToString("0.##"), "'  class='textboxnew' />" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</td>");
                            str = new object[] { "<td style='width:", empty6, ";border:0px solid red;' align='right' id='txtCost_td", num1, "'>" };
                            stringBuilder.Append(string.Concat(str));
                            if (ConnectionClass.isMatrixCalculation.ToString().ToLower() == "true")
                            {
                                str = new object[] { "<input id='txtCost_", num1, "' type='text' onblur=calculateNewMarkup(this,", num1, ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Price"].ToString()), 6, "", false, false, false), "'/>" };
                            }
                            else
                            {
                                str = new object[] { "<input id='txtCost_", num1, "' type='text' onblur=CalculateSellPrice(this,", num1, ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Price"].ToString()), 6, "", false, false, false), "'/>" };
                            }
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</td>");
                            str = new object[] { "<td style='width: ", empty6, ";' align='right' id='txtMarkup_td", num1, "'>" };
                            stringBuilder.Append(string.Concat(str));
                            string str9 = "";
                            if (num1 != 0)
                            {
                                str9 = string.Concat("onblur=CalculateSellPrice(this,", num1, ",'markup');");
                            }
                            else
                            {
                                str = new object[] { "onblur=CalculateSellPrice(this,", num1, ",'markup');SetMarkupToAll(this,'", num1, "');" };
                                str9 = string.Concat(str);
                            }
                            if (ConnectionClass.isMatrixCalculation.ToString().ToLower() == "true")
                            {
                                str = new object[] { "<input id='txtMarkup_", num1, "' type='text' ", str9, "  maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Markup"].ToString()), 6, "", false, false, false), "' />" };
                            }
                            else
                            {
                                str = new object[] { "<input disabled id='txtMarkup_", num1, "' type='text' ", str9, "  maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Markup"].ToString()), 6, "", false, false, false), "' />" };
                            }
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</td>");
                            str = new object[] { "<td style='width: ", empty5, ";' align='right' id='txtSellingPrice_td", num1, "'>" };
                            stringBuilder.Append(string.Concat(str));
                            str = new object[] { "<input id='txtSellingPrice_", num1, "' onblur=Calculate_Markup(this,", num1, "); type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["SellingPrice"].ToString()), 6, "", false, false, false), "' />" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</td>");
                            str = new object[] { "<td style='width:", empty6, ";border:0px solid red;' align='right' id='txtWeight_td", num1, "' >" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div>");
                            str = new object[] { "<input id='txtWeight_", num1, "' maxlength='20' onblur='Weighttodecimal(this,", num1, ");' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Weight"].ToString()), 3, "", false, false, false), "'/>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(" </td>");
                            str = new object[] { "<td   id='txtWidth_td", num1, "' runat='server' style='border:0px solid red;", empty3, "' align='right' >" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div  >");
                            str = new object[] { "<input id='txtWidth_", num1, "' maxlength='20' onblur='Weighttodecimal(this,", num1, ");' style='width:80px;text-align:right;", empty4, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Width"].ToString()), 3, "", false, false, false), "'/>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(" </td>");
                            str = new object[] { "<td id='txtHeight_td", num1, "' runat='server' style='border:0px solid red;", empty3, "' align='right' >" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div>");
                            str = new object[] { "<input id='txtHeight_", num1, "' maxlength='20' onblur='Weighttodecimal(this,", num1, ");' style='width:80px;text-align:right;", empty4, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Height"].ToString()), 3, "", false, false, false), "'/>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(" </td>");
                            str = new object[] { "<td  id='txtLength_td", num1, "' runat='server' style='border:0px solid red;", empty3, "' align='right' >" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("<div>");
                            str = new object[] { "<input id='txtLength_", num1, "' maxlength='20' onblur='Weighttodecimal(this,", num1, ");' style='width:80px;text-align:right; ", empty4, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Length"].ToString()), 3, "", false, false, false), "'/>" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append(" </td>");
                            stringBuilder.Append(string.Concat("<td style='width:7%;' id='tdactn", num1, "' >"));
                            stringBuilder.Append("<div align='center'>");
                            str = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", num1, "); />" };
                            stringBuilder.Append(string.Concat(str));
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</td>");
                            stringBuilder.Append("</tr>");
                            stringBuilder.Append("</table>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</div>");
                            stringBuilder.Append("</div>µ");
                            num1++;
                        }
                        this.hid_data.Value = stringBuilder.ToString();
                        this.hid_Rows_On_Edit.Value = num1.ToString();
                        this.pnlCheckRow.Visible = true;
                    }
                }
                this.hdn_Matrixtypetext.Value = this.objlang.GetLanguageConversion("Product_Use_Note");
            }
            else
            {
                this.action = "edit";
                string empty8 = string.Empty;
                string empty9 = string.Empty;
                string empty10 = string.Empty;
                string str10 = string.Empty;
                string str11 = "";
                string str12 = "";
                string str133 = "";
                string str134 = "";
                this.div_btngeneral.Style.Add("display", "block");
                if (!base.IsPostBack)
                {
                    foreach (DataRow row2 in WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, this.ProductCatalogueID).Rows)
                    {
                        this.txtCategoryName.Text = row2["CategoryName"].ToString();
                        this.txtCatalogueName.Text = row2["CatalogueName"].ToString();
                        this.hdn_itemtitle.Value = row2["CatalogueName"].ToString();
                        this.txtitemcode.Text = row2["itemcode"].ToString();
                        this.txtcustomercode.Text = row2["CustomerCode"].ToString();
                        this.txtDescription.Text = row2["Description"].ToString();
                        empty10 = row2["PriceCatalogueCategoryID"].ToString();
                        this.ddlPriceCatalogueCategory.SelectedValue = empty10;
                        this.txtItemTitle.Text = row2["ItemTitle"].ToString();
                        this.txtArtwork.Text = row2["Artwork"].ToString();
                        this.txtColour.Text = row2["Color"].ToString();
                        this.txtSize.Text = row2["Size"].ToString();
                        this.txtMaterial.Text = row2["Material"].ToString();
                        this.txtDelivery.Text = row2["Delivery"].ToString();
                        this.txtFinishing.Text = row2["Finishing"].ToString();
                        this.txtProofs.Text = row2["Proofs"].ToString();
                        this.txtPacking.Text = row2["Packing"].ToString();
                        this.txtNotes.Text = row2["Notes"].ToString();
                        this.txtInstructions.Text = row2["Instructions"].ToString();
                        this.ddlFtpFolders.SelectedValue = row2["FTPFolderID"].ToString();
                        this.txtPrefix.Text = row2["Prefix"].ToString();
                        if (row2["FTPFileType"].ToString() == "Editable")
                        {
                            rdoEditable.Checked = true;
                        }
                        else if (row2["FTPFileType"].ToString() == "FTPFile")
                        {
                            rdoFTPFile.Checked = true;
                        }
                        else
                        {
                            rdoPrintReady.Checked = true;
                        }
                        str10 = row2["MatrixType"].ToString();
                        this.txtShortdescriprion.Text = row2["ShortDescription"].ToString();
                        this.RadEdit_txtItemdescriprion.Content = row2["ItemDesc"].ToString();
                        this.txtCustom1.Text = row2["CustomDescription1"].ToString();
                        this.txtCustom2.Text = row2["CustomDescription2"].ToString();
                        this.txtCustom3.Text = row2["CustomDescription3"].ToString();
                        this.txtCustom4.Text = row2["CustomDescription4"].ToString();
                        this.txtCustom5.Text = row2["CustomDescription5"].ToString();
                        this.txtCustom6.Text = row2["CustomDescription6"].ToString();
                        this.txtCustom7.Text = row2["CustomDescription7"].ToString();
                        this.txtCustom8.Text = row2["CustomDescription8"].ToString();
                        this.txtCustom9.Text = row2["CustomDescription9"].ToString();
                        this.txtCustom10.Text = row2["CustomDescription10"].ToString();
                        this.txtCustom11.Text = row2["CustomDescription11"].ToString();
                        this.txtCustom12.Text = row2["CustomDescription12"].ToString();
                        this.txtCustom13.Text = row2["CustomDescription13"].ToString();
                        this.txtCustom14.Text = row2["CustomDescription14"].ToString();
                        this.txtCustom15.Text = row2["CustomDescription15"].ToString();
                        this.txtCustom16.Text = row2["CustomDescription16"].ToString();
                        this.txtCustom17.Text = row2["CustomDescription17"].ToString();
                        this.txtCustom18.Text = row2["CustomDescription18"].ToString();
                        this.txtCustom19.Text = row2["CustomDescription19"].ToString();
                        this.txtCustom20.Text = row2["CustomDescription20"].ToString();
                        this.txtCustom21.Text = row2["CustomDescription21"].ToString();
                        this.txtCustom22.Text = row2["CustomDescription22"].ToString();
                        this.txtCustom23.Text = row2["CustomDescription23"].ToString();
                        this.txtCustom24.Text = row2["CustomDescription24"].ToString();
                        this.txtCustom25.Text = row2["CustomDescription25"].ToString();
                        this.txtWaterMarkPrintReady.Text = row2["PrintReadyFileWaterMarkText"].ToString();
                        this.ddlDefaultPreFlightProfile.SelectedIndex = this.ddlDefaultPreFlightProfile.Items.IndexOf(this.ddlDefaultPreFlightProfile.Items.FindByValue(row2["PreFlightProfile"].ToString()));

                        if (ConnectionClass.IsDecoration.ToLower() == "true")
                        {
                            txtdecoration1_title.Text = BaseClass.CheckStringNull(row2["Decoration1_Title"]);
                            txtdecoration2_title.Text = BaseClass.CheckStringNull(row2["Decoration2_Title"]);
                            txtdecoration3_title.Text = BaseClass.CheckStringNull(row2["Decoration3_Title"]);
                            txtdecoration4_title.Text = BaseClass.CheckStringNull(row2["Decoration4_Title"]);
                            txtdecoration5_title.Text = BaseClass.CheckStringNull(row2["Decoration5_Title"]);
                            txtdecoration6_title.Text = BaseClass.CheckStringNull(row2["Decoration6_Title"]);

                            Decoration1_Name.Text = BaseClass.CheckStringNull(row2["Decoration1_Name"]);
                            Decoration2_Name.Text = BaseClass.CheckStringNull(row2["Decoration2_Name"]);
                            Decoration3_Name.Text = BaseClass.CheckStringNull(row2["Decoration3_Name"]);
                            Decoration4_Name.Text = BaseClass.CheckStringNull(row2["Decoration4_Name"]);
                            Decoration5_Name.Text = BaseClass.CheckStringNull(row2["Decoration5_Name"]);
                            Decoration6_Name.Text = BaseClass.CheckStringNull(row2["Decoration6_Name"]);

                            Decoration1_Description.Text = BaseClass.CheckStringNull(row2["Decoration1_Description"]);
                            Decoration2_Description.Text = BaseClass.CheckStringNull(row2["Decoration2_Description"]);
                            Decoration3_Description.Text = BaseClass.CheckStringNull(row2["Decoration3_Description"]);
                            Decoration4_Description.Text = BaseClass.CheckStringNull(row2["Decoration4_Description"]);
                            Decoration5_Description.Text = BaseClass.CheckStringNull(row2["Decoration5_Description"]);
                            Decoration6_Description.Text = BaseClass.CheckStringNull(row2["Decoration6_Description"]);

                            Decoration1_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration1_SetupCost"]);
                            Decoration2_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration2_SetupCost"]);
                            Decoration3_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration3_SetupCost"]);
                            Decoration4_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration4_SetupCost"]);
                            Decoration5_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration5_SetupCost"]);
                            Decoration6_SetupCost.Text = BaseClass.CheckStringNull(row2["Decoration6_SetupCost"]);

                            Decoration1_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration1_PerItemCost"]);
                            Decoration2_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration2_PerItemCost"]);
                            Decoration3_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration3_PerItemCost"]);
                            Decoration4_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration4_PerItemCost"]);
                            Decoration5_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration5_PerItemCost"]);
                            Decoration6_PerItemCost.Text = BaseClass.CheckStringNull(row2["Decoration6_PerItemCost"]);

                            Decoration1_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration1_MinimiumCost"]);
                            Decoration2_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration2_MinimiumCost"]);
                            Decoration3_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration3_MinimiumCost"]);
                            Decoration4_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration4_MinimiumCost"]);
                            Decoration5_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration5_MinimiumCost"]);
                            Decoration6_Minimumcost.Text = BaseClass.CheckStringNull(row2["Decoration6_MinimiumCost"]);

                            SetDDItems(ddlDecoration1_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration1_Mandadory"]) == true ? "Yes" : "No");
                            SetDDItems(ddlDecoration2_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration2_Mandadory"]) == true ? "Yes" : "No");
                            SetDDItems(ddlDecoration3_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration3_Mandadory"]) == true ? "Yes" : "No");
                            SetDDItems(ddlDecoration4_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration4_Mandadory"]) == true ? "Yes" : "No");
                            SetDDItems(ddlDecoration5_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration5_Mandadory"]) == true ? "Yes" : "No");
                            SetDDItems(ddlDecoration6_Mandatory, BaseClass.CheckBooleanNull(row2["Decoration6_Mandadory"]) == true ? "Yes" : "No");



                        }
                        if (this.txtCustom1.Text != "" || this.txtCustom2.Text != "")
                        {
                            this.divcd_1.Style.Add("display", "block");
                        }
                        if (this.txtCustom3.Text != "" || this.txtCustom4.Text != "")
                        {
                            this.divcd_2.Style.Add("display", "block");
                        }
                        if (this.txtCustom5.Text != "" || this.txtCustom6.Text != "")
                        {
                            this.divcd_3.Style.Add("display", "block");
                        }
                        if (this.txtCustom7.Text != "" || this.txtCustom8.Text != "")
                        {
                            this.divcd_4.Style.Add("display", "block");
                        }
                        if (this.txtCustom9.Text != "" && this.txtCustom10.Text != "")
                        {
                            this.divcd_5.Style.Add("display", "block");
                        }
                        if (this.txtCustom11.Text != "" || this.txtCustom12.Text != "")
                        {
                            this.divcd_6.Style.Add("display", "block");
                        }
                        if (this.txtCustom13.Text != "" || this.txtCustom14.Text != "")
                        {
                            this.divcd_7.Style.Add("display", "block");
                        }
                        if (this.txtCustom15.Text != "" || this.txtCustom16.Text != "")
                        {
                            this.divcd_8.Style.Add("display", "block");
                        }
                        if (this.txtCustom17.Text != "" || this.txtCustom18.Text != "")
                        {
                            this.divcd_9.Style.Add("display", "block");
                        }
                        if (this.txtCustom19.Text != "" || this.txtCustom20.Text != "")
                        {
                            this.divcd_10.Style.Add("display", "block");
                        }
                        if (this.txtCustom21.Text != "" || this.txtCustom22.Text != "")
                        {
                            this.divcd_11.Style.Add("display", "block");
                        }
                        if (this.txtCustom23.Text != "" || this.txtCustom24.Text != "")
                        {
                            this.divcd_12.Style.Add("display", "block");
                        }
                        if (this.txtCustom25.Text != "")
                        {
                            this.divcd_13.Style.Add("display", "block");
                        }
                        if (base.Request.QueryString["suplrid"] == null)
                        {
                            this.ddlSupplier.SelectedValue = row2["SupplierID"].ToString();
                        }
                        if (!Convert.ToBoolean(row2["ProductVisible"].ToString()))
                        {
                            this.chkProductVisible.Checked = false;
                        }
                        else
                        {
                            this.chkProductVisible.Checked = true;
                        }
                        if (str10 == "P")
                        {
                            this.ddlMatrixType.SelectedIndex = 0;
                            this.hid_ddlMatrixType.Value = "P";
                        }
                        else if (str10 != "G")
                        {
                            this.ddlMatrixType.SelectedIndex = 1;
                            this.hid_ddlMatrixType.Value = "S";
                        }
                        else
                        {
                            this.ddlMatrixType.SelectedIndex = 2;
                            this.hid_ddlMatrixType.Value = "G";
                        }
                        if (!Convert.ToBoolean(row2["IsShortDescription"]))
                        {
                            this.ChkShortDescription.Checked = false;
                        }
                        else
                        {
                            this.ChkShortDescription.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsItemDescription"]))
                        {
                            this.ChkItemDescription.Checked = false;
                        }
                        else
                        {
                            this.ChkItemDescription.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsPriceStartFrom"]))
                        {
                            this.ChkPriceStart.Checked = false;
                        }
                        else
                        {
                            this.ChkPriceStart.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsPriceList"]))
                        {
                            this.ChkPriceList.Checked = false;
                        }
                        else
                        {
                            this.ChkPriceList.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsPrintReadyFile"]))
                        {
                            this.ChkPrintReadyFile.Checked = false;
                        }
                        else
                        {
                            this.ChkPrintReadyFile.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsEditableProduct"]))
                        {
                            this.ChkEditableProduct.Checked = false;
                            this.rdbnoneditable.Checked = true;
                        }
                        else
                        {
                            this.ChkEditableProduct.Checked = true;
                        }

                        if (!Convert.ToBoolean(row2["IsPrintReadyFileWaterMark"]))
                        {
                            this.chkAllowWaterMarksPrintReady.Checked = false;
                        }
                        else
                        {
                            this.chkAllowWaterMarksPrintReady.Checked = true;
                        }
                        this.ddlMatrixType.Attributes.Add("disabled", "true");
                        this.pnlShowMsg.Visible = true;
                        if (row2["ProductImage"].ToString() != "")
                        {
                            this.hid_ProductImage.Value = row2["ProductImage"].ToString();
                            this.ancUploadimage.Attributes.Add("style", "display:none");
                            this.lblProductImage.Attributes.Add("style", "display:block");
                            QueryString queryString = new QueryString()
                        {
                            { "doctype", "product" },
                            { "pid", Convert.ToString(this.ProductCatalogueID) }
                        };
                            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                            Label label = this.lblProductImage;
                            clientID = new string[] { "<a href='", this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", row2["ProductImage"].ToString(), "</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' onclick=RemoveImage('image'); title='Remove'>" };
                            label.Text = string.Concat(clientID);
                        }
                        if (!string.IsNullOrEmpty(row2["FTPFile"].ToString()))
                        {
                            QueryString queryString = new QueryString()
                            {
                                { "doctype", "product_ftp" },
                                { "pid", Convert.ToString(this.ProductCatalogueID) }
                            };
                            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                            string ftp_url = this.strSitePath + "DocManager.ashx" + queryString1.ToString().Trim(); 
                            lnkUploadedFile.Text = row2["FTPFile"].ToString();
                            lnkUploadedFile.NavigateUrl = ftp_url;
                            lnkUploadedFile.Visible = true;
                            fileUploader.Visible = false;
                            btnRemoveFTP.Visible = true;
                        }
                        else
                        {
                            // No file exists yet
                            lnkUploadedFile.Visible = false;
                            fileUploader.Visible = true;
                            btnRemoveFTP.Visible = false;
                        }
                        if (row2["PrintReadyFile"].ToString() != "")
                        {
                            this.hid_PrintReadyFile.Value = row2["PrintReadyFile"].ToString();
                            this.hid_ReportFile.Value = row2["ReportFileName"].ToString();
                            this.upPrintReadyFile.Attributes.Add("style", "display:none");
                            this.divPreFlight.Attributes.Add("style", "display:none");
                            this.lblPrintReadyFile.Attributes.Add("style", "display:block");
                            QueryString queryString2 = new QueryString()
                        {
                            { "doctype", "pr" },
                            { "pid", Convert.ToString(this.ProductCatalogueID) }
                        };
                            QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                            this.lblPrintReadyFile.ToolTip = row2["PrintReadyFile"].ToString();
                            if (row2["ReportFileName"].ToString() == "")
                            {
                                Label label1 = this.lblPrintReadyFile;
                                clientID = new string[] { "<a href='", this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim(), "'  target='_blank'>", row2["PrintReadyFile"].ToString(), "<td id='pdf_delete'><div class='div_printreadydelete'></a>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' onclick=RemoveImage('pdf'); title='Remove'></div></td>" };
                                label1.Text = string.Concat(clientID);
                            }
                            else
                            {
                                Label label2 = this.lblPrintReadyFile;
                                clientID = new string[] { "<a href='", this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim(), "'  target='_blank'>", row2["PrintReadyFile"].ToString(), "</a><br /><a href='", this.strSitePath, "DocManager.ashx?doctype=pr&filename=", row2["ReportFileName"].ToString(), "&rep=yes'  target='_blank'>Report File.pdf</a><td id='pdf_delete'><div class='div_printreadydelete'>&nbsp;&nbsp;&nbsp;&nbsp;<img src='../images/erase.png' onclick=RemoveImage('pdf'); title='Remove'></div></td>" };
                                label2.Text = string.Concat(clientID);
                            }
                        }
                        if (row2["ArtworkFile"].ToString().ToLower() == "y")
                        {
                            this.ChkArtworkFile.Checked = true;
                            this.ChkMandatoryArtworkFile.Checked = Convert.ToBoolean(row2["IsUploadMandatory"]);
                            this.ChkMandatoryArtworkFile.Enabled = true;
                            this.ddlArtCount.Enabled = true;
                            this.hid_ArtworkFileValue.Value = "Y";
                        }
                        else if (row2["ArtworkFile"].ToString().ToLower() != "m")
                        {
                            this.hid_ArtworkFileValue.Value = "N";
                        }
                        else
                        {
                            this.ChkArtworkFile.Checked = true;
                            this.ChkMandatoryArtworkFile.Checked = Convert.ToBoolean(row2["IsUploadMandatory"]);
                            this.ChkMandatoryArtworkFile.Enabled = true;
                            this.ddlArtCount.Enabled = true;
                            this.hid_ArtworkFileValue.Value = "M";
                        }
                        this.ddlArtCount.SelectedValue = row2["ArtworkCount"].ToString();
                        this.CustomerType = row2["CustomerType"].ToString();
                        if (row2["CustomerType"].ToString() == "A")
                        {
                            this.rdSelectedAll.Checked = true;
                        }
                        else if (row2["CustomerType"].ToString() == "S")
                        {
                            this.rdSelectedCustomer.Checked = true;
                        }
                        else if (row2["CustomerType"].ToString() == "N")
                        {
                            this.rdCustomerNone.Checked = true;
                        }
                        this.txtUnitOfMeasure.Text = row2["UnitOfMeasure"].ToString();
                        this.div_SoldinPack.Style.Add("display", "block");
                        this.txt_SoldinPack.Text = row2["SoldInPacksOf"].ToString();
                        if (Convert.ToBoolean(row2["IsCumulativePricing"].ToString()))
                        {
                            this.chk_EnableCumulative_Priceing.Checked = true;
                            this.chk_EnableCumulative_Priceing.Enabled = false;
                        }
                        if (!Convert.ToBoolean(row2["IsSides"]))
                        {
                            this.chk_ShowSides.Checked = false;
                        }
                        else
                        {
                            this.chk_ShowSides.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["AllowGroupRun"]))
                        {
                            this.chkAllowGroupRun.Checked = false;
                        }
                        else
                        {
                            this.chkAllowGroupRun.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["isCustomerCode"]))
                        {
                            this.chkCustomerCode.Checked = false;
                        }
                        else
                        {
                            this.chkCustomerCode.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["isItemCode"]))
                        {
                            this.chkItemCode.Checked = false;
                        }
                        else
                        {
                            this.chkItemCode.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsDisplayAdditionalOptions"]))
                        {
                            this.chkSubAdditionOption.Checked = false;
                        }
                        else
                        {
                            this.chkSubAdditionOption.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsStockItem"]))
                        {
                            this.chkstockitem.Checked = false;
                        }
                        else
                        {
                            this.chkstockitem.Checked = true;
                            if (ProductCatalogue_item.ManageStockPermission != 1)
                            {
                                this.div_stocklinkcontactmsg.Style.Add("display", "block");
                            }
                            else if (row2["drawstockfrom"].ToString().ToLower() != "x")
                            {
                                this.div_managestock.Style.Add("display", "block");
                            }
                        }
                        if (!Convert.ToBoolean(row2["IsBackOrder"]))
                        {
                            this.chkbackorders.Checked = false;
                        }
                        else
                        {
                            this.chkbackorders.Checked = true;
                        }
                        if (row2["drawstockfrom"].ToString().ToLower() == "s")
                        {
                            this.ddldrawstockfrom.SelectedIndex = 1;
                        }
                        else if (row2["drawstockfrom"].ToString().ToLower() == "o")
                        {
                            this.ddldrawstockfrom.SelectedIndex = 2;
                        }
                        else if (row2["drawstockfrom"].ToString().ToLower() == "a")
                        {
                            this.ddldrawstockfrom.SelectedIndex = 3;
                        }
                        else if (row2["drawstockfrom"].ToString().ToLower() == "p")
                        {
                            this.ddldrawstockfrom.SelectedIndex = 5;
                        }
                        else if (row2["drawstockfrom"].ToString().ToLower() != "m")
                        {
                            this.ddldrawstockfrom.SelectedIndex = 0;
                        }
                      
                        else
                        {
                            this.ddldrawstockfrom.SelectedIndex = 4;
                        }

                        if (!Convert.ToBoolean(row2["IsShowStock"]))
                        {
                            this.Chkshowstock.Checked = false;
                        }
                        else
                        {
                            this.Chkshowstock.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsShowSoldInPacksOf"]))
                        {
                            this.chkShowSoldPack.Checked = false;
                        }
                        else
                        {
                            this.chkShowSoldPack.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsShowUnitPrice"]))
                        {
                            this.ChkUnitPrice.Checked = false;
                        }
                        else
                        {
                            this.ChkUnitPrice.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsShowPackedPrice"]))
                        {
                            this.ChkPackPrice.Checked = false;
                        }
                        else
                        {
                            this.ChkPackPrice.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsShowJobName"]))
                        {
                            this.chkJobName.Checked = false;
                        }
                        else
                        {
                            this.chkJobName.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsShowPriceSubtotalTax"]))
                        {
                            this.chkpricesubtotaltax.Checked = false;
                        }
                        else
                        {
                            this.chkpricesubtotaltax.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsEditableProduct"]))
                        {
                            ProductCatalogue_item.ChkIsEditable = "false";
                        }
                        else
                        {
                            ProductCatalogue_item.ChkIsEditable = "true";
                        }
                        if (ProductCatalogue_item.ManageStockPermission != 1)
                        {
                            this.lstownership.SelectedValue = "1";
                        }
                        else if (Convert.ToInt32(row2["OwnerID"]) == 0 || Convert.ToInt32(row2["OwnerID"]) <= 1)
                        {
                            this.lstownership.SelectedValue = "1";
                        }
                        else if (this.lstownership.Items.FindByValue(row2["OwnerID"].ToString()) == null)
                        {
                            this.lstownership.SelectedValue = "1";
                        }
                        else
                        {
                            this.lstownership.SelectedValue = row2["OwnerID"].ToString();
                        }
                        if (!Convert.ToBoolean(row2["ForcePrintReadyFile"]))
                        {
                            this.chkForceUser.Checked = false;
                        }
                        else
                        {
                            this.chkForceUser.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["IsQuickItem"]))
                        {
                            this.chkQuickItemAdd.Checked = false;
                        }
                        else
                        {
                            this.chkQuickItemAdd.Checked = true;
                        }
                        if (!Convert.ToBoolean(row2["isAddtoCartandStay"]))
                        {
                            this.chkAddToCartStay.Checked = false;
                        }
                        else
                        {
                            this.chkAddToCartStay.Checked = true;
                        }
                        this.IsStockExist = Convert.ToBoolean(row2["IsStockExist"]);
                        str11 = Convert.ToString(row2["SalesTaxRate"]);
                        this.ddl_SaleTaxRate.SelectedValue = str11;
                        str12 = Convert.ToString(row2["pressID"]);
                        this.ddlPressName.SelectedValue = str12;
                        str133 = Convert.ToString(row2["AccountingCode"]);
                        if (str133 == "")
                        {
                            str133 = "0";
                        }
                        this.ddl_AccountingCode.SelectedValue = str133;
                        str134 = Convert.ToString(row2["PurAccountingCode"]);
                        if (str134 == "")
                        {
                            str134 = "0";
                        }
                        this.ddl_PurchaseAccountingCode.SelectedValue = str134;
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["CBMHeight"])))
                        {
                            this.TextBoxHeight.Text = Convert.ToDecimal(row2["CBMHeight"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["CBMWidth"])))
                        {
                            this.TextBoxWidth.Text = Convert.ToDecimal(row2["CBMWidth"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["CBMLength"])))
                        {
                            this.TextBoxLength.Text = Convert.ToDecimal(row2["CBMLength"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["CBMWeight"])))
                        {
                            this.TextBoxWeight.Text = Convert.ToDecimal(row2["CBMWeight"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["PerQuantity"])))
                        {
                            this.TextBoxPerQuantity.Text = Convert.ToDecimal(row2["PerQuantity"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["VolumetricWeight"])))
                        {
                            this.TextBoxVolumetricWeight.Text = Convert.ToDecimal(row2["VolumetricWeight"]).ToString("0.#####");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["CBMMeasurement"])))
                        {
                            this.TextBoxCBM.Text = Convert.ToDecimal(row2["CBMMeasurement"]).ToString("0.###");
                        }
                        if (!String.IsNullOrEmpty(Convert.ToString(row2["IsCBM"])))
                        {
                            if (!Convert.ToBoolean(row2["IsCBM"]))
                            {
                                this.chkCRMOverride.Checked = false;
                            }
                            else
                            {
                                this.chkCRMOverride.Checked = true;
                            }
                        }
                        else
                        {
                            this.chkCRMOverride.Checked = true;
                        }

                        
                    }
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:StockEnable();ownership_onchange();showstockbtn();", true);
                    foreach (DataRow dataRow2 in WebstoreBasePage.PriceCatalogueCustomer_Select((long)this.ProductCatalogueID, "Account").Rows)
                    {
                        for (int l = 0; l < this.lstStatus.Items.Count; l++)
                        {
                            if (this.lstStatus.Items[l].Value == dataRow2["AccountID"].ToString())
                            {
                                this.lstStatus.Items[l].Checked = true;
                                this.totalPublicNo_Selected = this.totalPublicNo_Selected + 1;
                            }
                        }
                    }
                    int num2 = 0;
                    string empty11 = string.Empty;
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    string str13 = string.Empty;
                    string empty14 = string.Empty;
                    string str14 = string.Empty;
                    string empty15 = string.Empty;
                    string str15 = string.Empty;
                    string empty16 = string.Empty;
                    string str16 = string.Empty;
                    string empty17 = string.Empty;
                    string chkHideWidth = string.Empty;
                    string chkHideDisplay = string.Empty;
                    if (str10 == "S")
                    {
                        empty11 = "style='display:none;'";
                        empty16 = "0px";
                        empty12 = "10%";
                        empty15 = "10%";
                        str14 = "10%";
                        str16 = "13%";
                        empty17 = "10%";
                        chkHideDisplay = "display:block;";
                        chkHideWidth = "width:5%;";
                    }
                    if (str10 == "P")
                    {
                        empty16 = "7%";
                        empty15 = "10%";
                        str14 = "10%";
                        empty12 = "10%";
                        str16 = "13%";
                        empty17 = "10%";
                        chkHideDisplay = "display:block;";
                        chkHideWidth = "width:5%;";
                    }
                    if (str10 == "G")
                    {
                        empty16 = "7%";
                        empty12 = "0%;";
                        empty13 = "display:none;";
                        str14 = "15%";
                        empty15 = "15%";
                        str16 = "20%";
                        empty17 = "15%";
                        chkHideDisplay = "display:none;";
                        chkHideWidth = "width:0%;";
                    }
                    if (this.AccountingCode == "d")
                    {
                        DropDownList dropDownList3 = this.ddlAccountCode;
                        int num3 = SettingsBasePage.PriceCatalogue_AccountingCode_Select((long)this.CompanyID, (long)this.ProductCatalogueID);
                        dropDownList3.SelectedValue = num3.ToString();
                    }
                    DataTable dataTable5 = WebstoreBasePage.settings_Product_CatalogueQty_Select(Convert.ToInt64(this.ProductCatalogueID));
                    StringBuilder stringBuilder1 = new StringBuilder();
                    foreach (DataRow row3 in dataTable5.Rows)
                    {
                        string str17 = "";
                        if (num2 != 0)
                        {
                            str17 = (num2 % 2 != 0 ? "#EFEFEF" : "");
                        }
                        if (row3["ToQuantity"].ToString() == "0")
                        {
                            continue;
                        }
                        stringBuilder1.Append(string.Concat("<div id='td_", num2, "'>"));
                        str = new object[] { "<div id='div_row_", num2, "' style='background-color:", str17, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("<div class='only5px' style='width: 100%;'>");
                        stringBuilder1.Append(" <table style='width:100%; table-layout: fixed' cellpadding='0px' cellspacing='0px' border='0px' >");
                        stringBuilder1.Append("<tr>");

                        
                            str = new object[] { "<td style='width:"+chkHideWidth+"' align='center' id='td_HideOnEStore_", num2, "'>" };
                            stringBuilder1.Append(string.Concat(str));
                            stringBuilder1.Append("<div nowrap=nowarp>");

                            bool isHideOnEStore = false;
                            bool.TryParse(row3["HideOnEStore"].ToString(), out isHideOnEStore);

                            string checkedAttr = isHideOnEStore ? "checked" : "";
                            str = new object[] { "<input type='checkbox' style='"+ chkHideDisplay + "' class='chkHideOnEStore' id='chkHideOnEStore_", num2, "' ", checkedAttr, " />" };
                            //str = new object[] { "<input type='checkbox' class='chkHideOnEStore' id='chkHideOnEStore_", num2, "' />" };

                            stringBuilder1.Append(string.Concat(str));

                            stringBuilder1.Append("</div></td>");
                        //if (str10 != "P")
                        //{
                        //    str = new object[] { "<td style='width:5%' align='center' id='td_HideOnEStore_", num2, "'>" };
                        //    stringBuilder1.Append(string.Concat(str));
                        //    stringBuilder1.Append("<div nowrap=nowarp>");

                        //    bool isHideOnEStore = false;
                        //    bool.TryParse(row3["HideOnEStore"].ToString(), out isHideOnEStore);

                        //    string checkedAttr = isHideOnEStore ? "checked" : "";
                        //    str = new object[] { "<input type='checkbox' class='chkHideOnEStore' id='chkHideOnEStore_", num2, "' ", checkedAttr, " />" };
                        //    //str = new object[] { "<input type='checkbox' class='chkHideOnEStore' id='chkHideOnEStore_", num2, "' />" };

                        //    stringBuilder1.Append(string.Concat(str));

                        //    stringBuilder1.Append("</div></td>");
                        //}

                        str = new object[] { "<td id='td_txtfrmqty_", num2, "' style='width: ", empty16, ";' align='right'>" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("<div>");
                        str = new object[] { "<input id='txtQty_from_", num2, "' ", empty11, "  maxlength=7 type='text' style='width:50px;text-align:right' value='", Convert.ToDecimal(row3["FromQuantity"]).ToString("0.##"), "'  class='textboxnew' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("</div></td>");
                        str = new object[] { "<td style='width: ", empty16, ";' align='center' id='td_txtcenterqty_", num2, "'>" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("<div>");
                        str = new object[] { "<span id='spn_qty_sep_", num2, "' ", empty11, ">-</span>" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("</div></td>");
                        stringBuilder1.Append("<td style='width:7%;' align='right'>");
                        stringBuilder1.Append(string.Concat("<div id='div_txtQty_", num2, "'>"));
                        str = new object[] { "<input id='txtQty_", num2, "' maxlength=7 type='text' style='width:80px;text-align:right;' value='", Convert.ToDecimal(row3["ToQuantity"]).ToString("0.##"), "'  class='textboxnew'  />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("</div></td>");
                        stringBuilder1.Append("</td>");
                        str = new object[] { "<td style='width: ", empty17, "' align='right'  id='txtCost_td", num2, "'>" };
                        stringBuilder1.Append(string.Concat(str));
                        if (ConnectionClass.isMatrixCalculation.ToString().ToLower() == "true")
                        {
                            str = new object[] { "<input id='txtCost_", num2, "' type='text' onblur=\"calculateNewMarkup(this,", num2, ",'cost');\" maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Price"].ToString()), 6, "", false, false, false), "' />" };
                        }
                        else
                        {
                            str = new object[] { "<input id='txtCost_", num2, "' type='text' onblur=\"CalculateSellPrice(this,", num2, ",'cost');\" maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Price"].ToString()), 6, "", false, false, false), "' />" };
                        }
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td style='width: ", str14, "' align='right' id='txtMarkup_td", num2, "'>" };
                        stringBuilder1.Append(string.Concat(str));
                        if (ConnectionClass.isMatrixCalculation.ToString().ToLower() == "true")
                        {
                            str = new object[] { "<input disabled id='txtMarkup_", num2, "' type='text' onblur=\"CalculateSellPrice(this,", num2, ",'markup');\" maxlength='20' style='width: 80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Markup"].ToString()), 6, "", false, false, false), "' />" };
                        }
                        else
                        {
                            str = new object[] { "<input id='txtMarkup_", num2, "' type='text' onblur=\"CalculateSellPrice(this,", num2, ",'markup');\" maxlength='20' style='width: 80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Markup"].ToString()), 6, "", false, false, false), "' />" };
                        }
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td style='width:", str16, "' align='right' id='txtSellingPrice_td", num2, "'>" };
                        stringBuilder1.Append(string.Concat(str));
                        str = new object[] { "<input id='txtSellingPrice_", num2, "' onblur=\"Calculate_Markup(this,", num2, ");\" type='text' maxlength='20'  style='width: 80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["SellingPrice"].ToString()), 6, "", false, false, false), "' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td style='width:", empty15, ";' align='right'  id='txtWeight_td", num2, "'>" };
                        stringBuilder1.Append(string.Concat(str));
                        str = new object[] { "<input id='txtWeight_", num2, "' type='text' maxlength='20' onblur='Weighttodecimal(this,", num2, ");' style='width:80px;text-align:right;' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Weight"].ToString()), 3, "", false, false, false), "' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td   id='txtWidth_td", num2, "' runat='server' style='width:", empty12, ";border:0px solid red;' align='right'  >" };
                        stringBuilder1.Append(string.Concat(str));
                        str = new object[] { "<input id='txtWidth_", num2, "'  type='text' maxlength='20' onblur='Weighttodecimal(this,", num2, ");' style='width:80px;text-align:right;", empty13, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Width"].ToString()), 3, "", false, false, false), "' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td id='txtHeight_td", num2, "' runat='server' style='width:", empty12, ";border:0px solid red;' align='right'>" };
                        stringBuilder1.Append(string.Concat(str));
                        str = new object[] { "<input id='txtHeight_", num2, "'  type='text' maxlength='20' onblur='Weighttodecimal(this,", num2, ");' style='width:80px;text-align:right;", empty13, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Height"].ToString()), 3, "", false, false, false), "' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        str = new object[] { "          <td  id='txtLength_td", num2, "' runat='server' style='width:", empty12, ";border:0px solid red;' align='right'>" };
                        stringBuilder1.Append(string.Concat(str));
                        str = new object[] { "<input id='txtLength_", num2, "' type='text' maxlength='20' onblur='Weighttodecimal(this,", num2, ");' style='width:80px;text-align:right;", empty13, "' class='textboxnew' value='", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Length"].ToString()), 3, "", false, false, false), "' />" };
                        stringBuilder1.Append(string.Concat(str));
                        stringBuilder1.Append("          </td>");
                        stringBuilder1.Append("          <td style='width: 7%;'>");
                        stringBuilder1.Append("              <div align='center'>");
                        if (str4.Trim().ToLower() != "false")
                        {
                            str = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", num2, "); />" };
                            stringBuilder1.Append(string.Concat(str));
                        }
                        stringBuilder1.Append("              </div>");
                        stringBuilder1.Append("          </td>");
                        stringBuilder1.Append("     </tr>");
                        stringBuilder1.Append(" </table>");
                        stringBuilder1.Append("</div>");
                        stringBuilder1.Append("</div>");
                        stringBuilder1.Append("</div>µ");
                        num2++;
                    }
                    string empty18 = string.Empty;
                    if (stringBuilder1.ToString().Trim().Length > 1)
                    {
                        empty18 = stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1);
                    }
                    this.hid_data.Value = empty18;
                    this.hid_Rows_On_Edit.Value = num2.ToString();
                    this.pnlCheckRow.Visible = true;
                    ProductCatalogue_item.htAdditionalGroup.Clear();
                    DataTable dataTable6 = WebstoreBasePage.settings_Product_CatalogueAdditional_Select((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID));
                    foreach (DataRow dataRow3 in dataTable6.Rows)
                    {
                        IList<ProductCatalogue_item.OrderNew> pendingOrders = this.PendingOrders;
                        ProductCatalogue_item.OrderNew order = ProductCatalogue_item.GetOrder(pendingOrders, Convert.ToInt64(dataRow3["WebOtherCostID"].ToString()));
                        if (order != null)
                        {
                            this.PendingOrders.Remove(order);
                        }
                        this.PendingOrders = pendingOrders;
                        this.GridWebOtherCostPendingOrders.Rebind();
                        long num4 = Convert.ToInt64(dataRow3["WebOtherCostID"].ToString());
                        if (!ProductCatalogue_item.htAdditionalGroup.ContainsKey(num4))
                        {
                            ProductCatalogue_item.htAdditionalGroup.Add(num4, Convert.ToInt64(dataRow3["AdditionalGroupID"].ToString()));
                        }
                        else
                        {
                            ProductCatalogue_item.htAdditionalGroup[num4] = Convert.ToInt64(dataRow3["AdditionalGroupID"].ToString());
                        }
                    }
                    DataTable dataTable7 = WebstoreBasePage.Product_CatalogueCouponCode_Select((long)this.CompanyID, Convert.ToInt64(this.ProductCatalogueID));
                    foreach (DataRow row4 in dataTable7.Rows)
                    {
                        IList<ProductCatalogue_item.CouponCodes> avaliableCouponCodes = this.AvaliableCouponCodes;
                        ProductCatalogue_item.CouponCodes couponCode = ProductCatalogue_item.GetCouponCode(avaliableCouponCodes, Convert.ToInt64(row4["CouponCodeID"].ToString()));
                        if (couponCode != null)
                        {
                            avaliableCouponCodes.Remove(couponCode);
                        }
                        this.AvaliableCouponCodes = avaliableCouponCodes;
                        this.GridAvaialbleCoupncodes.Rebind();
                    }
                }
                if (this.ddlMatrixType.SelectedValue != "pricebands")
                {
                    this.hdn_Matrixtypetext.Value = this.objlang.GetLanguageConversion("Product_Use_Note");
                }
                else
                {
                    this.hdn_Matrixtypetext.Value = this.objlang.GetLanguageConversion("Price_Band_Use_Note");
                }

            }
            if (base.Request.Url.ToString().ToLower().Contains("display") && !(base.Request.Url.ToString().ToLower().Contains(".hexihub.com")) && !(base.Request.Url.ToString().ToLower().Contains(".eprintsoftware.com")))
            {
                try
                {
                    if (Convert.ToInt32(base.Request.Params["display"].ToString()) == -1)
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Product_Catalogue_Already_Exists"), "msg-fail", this.plhMessage);
                    }
                    else
                    {
                        base.Message_Display(this.objlang.GetLanguageConversion("Product_Catalogue_Saved_Successfully"), "msg-success", this.plhMessage);
                        if (!base.IsPostBack)
                        {
                            this.txtCategoryName.Text = string.Empty;
                            this.txtCatalogueName.Text = string.Empty;
                            this.txtDescription.Text = string.Empty;
                        }
                    }
                }
                catch (Exception exception)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/pricecatalogue.aspx"));
                }
            }
            this.btnCategorySave.Attributes.Add("onclick", "javascript:return CategoryVaidate();");
            this.btnPriceSaveandStay.Attributes.Add("onclick", string.Concat("javascript:return PriceSave_andStay('saveandstay','", this.IsStockExist, "');"));
            this.btnPriceSave.Attributes.Add("onclick", string.Concat("javascript:return PriceSave_andStay('save','", this.IsStockExist, "');"));
            this.btnprice_managestock.Attributes.Add("onclick", string.Concat("javascript:return PriceSave_andStay('managestock','", this.IsStockExist, "');"));
            this.btnArtworkSaveandStay.Attributes.Add("onclick", string.Concat("javascript:return ArtworkSave_andStay('saveandstay','", this.IsStockExist, "');"));
            this.btnArtworkSave.Attributes.Add("onclick", string.Concat("javascript:return ArtworkSave_andStay('save','", this.IsStockExist, "');"));
            this.btnestoresavestock.Attributes.Add("onclick", string.Concat("javascript:return ArtworkSave_andStay('managestock','", this.IsStockExist, "');"));
            this.btnFinalSave.Attributes.Add("onclick", string.Concat("javascript:return Validate('save','", this.IsStockExist, "');"));
            this.btnAdditionalSaveandStay.Attributes.Add("onclick", string.Concat("javascript:return Validate('saveandstay','", this.IsStockExist, "');"));
            this.btnadditionalstocksave.Attributes.Add("onclick", string.Concat("javascript:return Validate('managestock','", this.IsStockExist, "');"));
            this.btngensave.Attributes.Add("onclick", string.Concat("javascript: var a = GeneralSave_Stay('save','", this.IsStockExist, "'); return a;"));
            this.btngenstay.Attributes.Add("onclick", string.Concat("javascript:return GeneralSave_Stay('saveandstay','", this.IsStockExist, "');"));
            this.btngenmanagestock.Attributes.Add("onclick", string.Concat("javascript:return GeneralSave_Stay('managestock','", this.IsStockExist, "');"));
            this.btn_CouponCode_Save.Attributes.Add("onclick", string.Concat("javascript:return Validate('savecc','", this.IsStockExist, "');"));
            this.btn_CouponCode_SaveStay.Attributes.Add("onclick", string.Concat("javascript:return Validate('saveandstaycc','", this.IsStockExist, "');"));
            this.btn_CouponCode_SaveMangeStock.Attributes.Add("onclick", string.Concat("javascript:return Validate('managestockcc','", this.IsStockExist, "');"));

         

            this.BtnDecorationSave.Attributes.Add("onclick", string.Concat("javascript: var a = GeneralSave_Stay('save','", this.IsStockExist, "'); return a;"));
            this.BtnDecorationSaveAndStay.Attributes.Add("onclick", string.Concat("javascript:return GeneralSave_Stay('saveandstay','", this.IsStockExist, "');"));

            this.btnFTPSave.Attributes.Add("onclick", string.Concat("javascript: var a = FTPSave_Stay(); return a;"));
            this.btnFTPSaveStay.Attributes.Add("onclick", string.Concat("javascript:return FTPSave_Stay();"));


            if (base.Request.Params["clientid"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
                if (this.ClientID != 0)
                {
                    this.CustomerType = "S";
                }
            }
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
            if (base.Request.QueryString["catid"] != null)
            {
                this.ddlPriceCatalogueCategory.SelectedValue = base.Request.QueryString["catid"].ToString();
            }
            Button button = (Button)this.ucEditableProduct.FindControl("btnSave");
            if (str3.Trim().ToLower() != "false")
            {
                this.btnAdditionalSaveandStay.Visible = true;
                this.btnPriceSaveandStay.Visible = true;
                this.btnArtworkSaveandStay.Visible = true;
                this.btnFinalSave.Visible = true;
                this.btnPriceSave.Visible = true;
                this.btnArtworkSave.Visible = true;
                this.btnSaveGroup.Visible = true;
                this.btnCategorySave.Visible = true;
                button.Visible = true;
            }
            else
            {
                this.btnAdditionalSaveandStay.Visible = false;
                this.btnPriceSaveandStay.Visible = false;
                this.btnArtworkSaveandStay.Visible = false;
                this.btngensave.Visible = false;
                this.btngenstay.Visible = false;
                this.btnFinalSave.Visible = false;
                this.btnPriceSave.Visible = false;
                this.btnArtworkSave.Visible = false;
                this.btnSaveGroup.Visible = false;
                this.btnCategorySave.Visible = false;
                button.Visible = false;
            }
            AttributeCollection attributeCollection = this.Select.Attributes;
            str = new object[] { "javascript:openPopUp('I','", this.ProductCatalogueID, "','", this.action, "');" };
            attributeCollection.Add("onclick", string.Concat(str));
            AttributeCollection attributes1 = this.Exclude.Attributes;
            str = new object[] { "javascript:openPopUp('E','", this.ProductCatalogueID, "','", this.action, "');" };
            attributes1.Add("onclick", string.Concat(str));
            if (this.Measurementvalue != "In.")
            {
                this.PaperMeasure = this.objLanguage.GetLanguageConversion("mtr");
                this.Measurementvalue = this.objLanguage.GetLanguageConversion("SquareMeter");
            }
            else
            {
                this.PaperMeasure = this.objLanguage.GetLanguageConversion("Feet");
                this.Measurementvalue = this.objLanguage.GetLanguageConversion("SquareFeet");
            }
            if (this.ddlMatrixType.SelectedIndex == 2)
            {
                this.div_SoldinPack.Style.Add("display", "none");
            }
            if (this.ddlMatrixType.SelectedValue == "simplematrix")
            {
                this.div_EnableCumulativePriceing.Style.Add("display", "block");
            }


            DataTable dataTable22 = SettingsBasePage.settings_companyprofile_select(Convert.ToInt16(base.Session["Companyid"]));
            string countryName = Convert.ToString(dataTable22.Rows[0]["Country"]);
            hdn_CountryName.Value = countryName;

            if (this.ProductCatalogueID <= 0 )
            {
                this.imgbtnaddcategory.Enabled = false;
                this.imgbtnaddcategory.Visible = false;
                this.btnaddcat.Visible = true;
            }
            else
            {
                this.imgbtnaddcategory.Enabled = true;
                this.imgbtnaddcategory.Visible = true;
                this.btnaddcat.Visible = false;
            }

            this.imgbtnaddcategory.Attributes.Add("onclick", string.Concat("javascript:AddMultipleCategories('", this.ProductCatalogueID, "','", this.CompanyID, "','0','0','order',);"));

           
        }

        public void SetDDItems(DropDownList ddl, string selectedText)
        {
            try
            {
                ddl.Items.Add("Yes");
                ddl.Items.Add("No");
                ListItem listItem = ddl.Items.FindByValue(selectedText);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        public void RedirectTOCRM()
        {
            QueryString queryString = new QueryString()
        {
            { "clientid", this.ClientID.ToString() },
            { "isnew", "2" },
            { "bypass", "1" },
            { "type", "customer" }
        };
            string str = string.Concat("../client/client_detail.aspx", this.jID, this.InvID);
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            str = string.Concat(str, queryString1.ToString());
            base.Response.Redirect(str);
        }

        public void SaveAdditionalRecords(int id)
        {
            this.GridWebOtherCostShippedOrders.AllowPaging = false;
            this.GridWebOtherCostShippedOrders.Rebind();
            string WebOtherCostIDs = string.Empty;
            WebstoreBasePage.settings_Product_CatalogueAdditional_Delete((long)this.CompanyID, id, "");
            for (int i = 0; i < this.GridWebOtherCostShippedOrders.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)this.GridWebOtherCostShippedOrders.Items[i].FindControl("Id_2");
                long num = (long)0;
                num = (!ProductCatalogue_item.htAdditionalGroup.ContainsKey(Convert.ToInt64(htmlInputCheckBox.Value)) ? (long)0 : Convert.ToInt64(ProductCatalogue_item.htAdditionalGroup[Convert.ToInt64(htmlInputCheckBox.Value)]));
                WebstoreBasePage.settings_Product_CatalogueAdditional_insert(this.CompanyID, (long)id, Convert.ToInt64(htmlInputCheckBox.Value), num);

                if (i == 0)
                {
                    WebOtherCostIDs = Convert.ToString(Convert.ToInt64(htmlInputCheckBox.Value));
                }
                else
                {
                    WebOtherCostIDs += " ," + Convert.ToString(Convert.ToInt64(htmlInputCheckBox.Value));
                }
            }

            WebstoreBasePage.settings_Product_CatalogueAdditional_Delete((long)this.CompanyID, id, WebOtherCostIDs);
        }

        private void SaveBlankPDFDetails(int UserId, int CompanyID, string PDFName, string ImageName, string Title, long PriceCatalogueID, double Pageheight, double Pagewidth, double zoomx, double zoomy, double zoompercentage, bool isOverPrintFileRequired, double CropMarkWidth, double CropMarkHeight, bool isAllowPDFPreviews, bool isPDFPreviewMandatory, bool isAllowWaterMark, string WaterMarkText, int NoOfPages)
        {
            SettingsBasePage settingsBasePage = new SettingsBasePage();
            long num = (long)0;
            if (ConnectionClass.ServerName != "")
            {
                num = SettingsBasePage.SelectDBID((long)CompanyID, ConnectionClass.ServerName);
            }
            settingsBasePage.MasterTemplate_InsertBlankPDFDetails(num, Convert.ToInt32(this.UserID), Convert.ToInt32(CompanyID), PDFName, ImageName, Title, Convert.ToInt64(PriceCatalogueID), Pageheight, Pagewidth, zoomx, zoomy, zoompercentage, isOverPrintFileRequired, 0, 0, isAllowPDFPreviews, isPDFPreviewMandatory, isAllowWaterMark, WaterMarkText, NoOfPages);
            settingsBasePage.Insert_BlankPDFDetails(Convert.ToInt32(this.UserID), Convert.ToInt32(CompanyID), PDFName, ImageName, Title, Convert.ToInt64(PriceCatalogueID), Pageheight, Pagewidth, zoomx, zoomy, zoompercentage, isOverPrintFileRequired, 0, 0, isAllowPDFPreviews, isPDFPreviewMandatory, isAllowWaterMark, WaterMarkText, NoOfPages);
        }

        public void SaveGroup()
        {
            long num = (long)0;
            string empty = string.Empty;
            if (this.action != "add")
            {
                ProductCatalogue_item.TempProductID = this.ProductCatalogueID;
            }
            else if (ProductCatalogue_item.TempProductID != 0)
            {
                ProductCatalogue_item.TempProductID = Convert.ToInt32(ProductCatalogue_item.TempProductID);
            }
            else
            {
                ProductCatalogue_item.TempProductID = base.GensNegValue(6);
            }
            if (!(this.txtGroupName.Text != "") || !(this.ddlGroup.SelectedValue == "-2"))
            {
                num = Convert.ToInt64(this.ddlGroup.SelectedValue);
                empty = base.ReplaceSingleQuote(this.ddlGroup.SelectedItem.Text);
            }
            else
            {
                this.ddlGroup.SelectedIndex = 0;
                num = WebstoreBasePage.AdditionalGroup_insert(Convert.ToInt64(ProductCatalogue_item.TempProductID), base.ReplaceSingleQuote(this.txtGroupName.Text));
                empty = base.ReplaceSingleQuote(this.txtGroupName.Text);
                this.BindGroup("add");
            }
            if (base.Request.Cookies["AdditionalGroupIDs"] != null)
            {
                IList<ProductCatalogue_item.OrderNew> shippedOrders = this.ShippedOrders;
                string[] strArrays = base.Request.Cookies["AdditionalGroupIDs"].Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i] != "")
                    {
                        long num1 = Convert.ToInt64(strArrays[i]);
                        if (!ProductCatalogue_item.htAdditionalGroup.ContainsKey(num1))
                        {
                            ProductCatalogue_item.htAdditionalGroup.Add(num1, Convert.ToInt64(num));
                        }
                        else
                        {
                            ProductCatalogue_item.htAdditionalGroup[num1] = num;
                        }
                        foreach (ProductCatalogue_item.OrderNew shippedOrder in shippedOrders)
                        {
                            if (shippedOrder.WebOtherCostID != Convert.ToInt64(strArrays[i]))
                            {
                                continue;
                            }
                            shippedOrder.AdditionalGroupID = Convert.ToInt64(num);
                            shippedOrder.GroupName = empty;
                        }
                    }
                }
                this.ShippedOrders = shippedOrders;
                this.GridWebOtherCostShippedOrders.Rebind();
                base.Message_Display(string.Concat(this.objlang.GetLanguageConversion("Group_Added_Successfully"), "!"), "msg-success", this.plhMessage);
            }
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        private void TakeItemDesc()
        {
            try
            {
                DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
                if (dataSet.Tables[0].Rows.Count > 0 && dataSet != null)
                {
                    if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle")
                    {
                        this.txt_lblItemtitle.Text = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
                        this.txt_lblItemtitle1.Text = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
                    }
                    if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description")
                    {
                        if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblDescription.Text = dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblDescription.Text = dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork")
                    {
                        if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblArtwork.Text = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblArtwork.Text = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour")
                    {
                        if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblColour.Text = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblColour.Text = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size")
                    {
                        if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblSize.Text = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblSize.Text = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material")
                    {
                        if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblMaterial.Text = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblMaterial.Text = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery")
                    {
                        if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblDelivery.Text = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblDelivery.Text = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing")
                    {
                        if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblFinishing.Text = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblFinishing.Text = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs")
                    {
                        if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblProofs.Text = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblProofs.Text = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing")
                    {
                        if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblPacking.Text = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblPacking.Text = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes")
                    {
                        if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblNotes.Text = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblNotes.Text = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
                        }
                    }
                    if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions")
                    {
                        if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "true")
                        {
                            this.txt_lblInstructions.Text = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
                        }
                        else if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "false")
                        {
                            this.txt_lblInstructions.Text = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
                        }
                    }
                    this.lblCustom1.Text = dataSet.Tables[0].Rows[12]["ScreenName"].ToString().Trim();
                    this.lblCustom2.Text = dataSet.Tables[0].Rows[13]["ScreenName"].ToString().Trim();
                    this.lblCustom3.Text = dataSet.Tables[0].Rows[14]["ScreenName"].ToString().Trim();
                    this.lblCustom4.Text = dataSet.Tables[0].Rows[15]["ScreenName"].ToString().Trim();
                    this.lblCustom5.Text = dataSet.Tables[0].Rows[16]["ScreenName"].ToString().Trim();
                    this.lblCustom6.Text = dataSet.Tables[0].Rows[17]["ScreenName"].ToString().Trim();
                    this.lblCustom7.Text = dataSet.Tables[0].Rows[18]["ScreenName"].ToString().Trim();
                    this.lblCustom8.Text = dataSet.Tables[0].Rows[19]["ScreenName"].ToString().Trim();
                    this.lblCustom9.Text = dataSet.Tables[0].Rows[20]["ScreenName"].ToString().Trim();
                    this.lblCustom10.Text = dataSet.Tables[0].Rows[21]["ScreenName"].ToString().Trim();
                    this.lblCustom11.Text = dataSet.Tables[0].Rows[22]["ScreenName"].ToString().Trim();
                    this.lblCustom12.Text = dataSet.Tables[0].Rows[23]["ScreenName"].ToString().Trim();
                    this.lblCustom13.Text = dataSet.Tables[0].Rows[24]["ScreenName"].ToString().Trim();
                    this.lblCustom14.Text = dataSet.Tables[0].Rows[25]["ScreenName"].ToString().Trim();
                    this.lblCustom15.Text = dataSet.Tables[0].Rows[26]["ScreenName"].ToString().Trim();
                    this.lblCustom16.Text = dataSet.Tables[0].Rows[27]["ScreenName"].ToString().Trim();
                    this.lblCustom17.Text = dataSet.Tables[0].Rows[28]["ScreenName"].ToString().Trim();
                    this.lblCustom18.Text = dataSet.Tables[0].Rows[29]["ScreenName"].ToString().Trim();
                    this.lblCustom19.Text = dataSet.Tables[0].Rows[30]["ScreenName"].ToString().Trim();
                    this.lblCustom20.Text = dataSet.Tables[0].Rows[31]["ScreenName"].ToString().Trim();
                    this.lblCustom21.Text = dataSet.Tables[0].Rows[32]["ScreenName"].ToString().Trim();
                    this.lblCustom22.Text = dataSet.Tables[0].Rows[33]["ScreenName"].ToString().Trim();
                    this.lblCustom23.Text = dataSet.Tables[0].Rows[34]["ScreenName"].ToString().Trim();
                    this.lblCustom24.Text = dataSet.Tables[0].Rows[35]["ScreenName"].ToString().Trim();
                    this.lblCustom25.Text = dataSet.Tables[0].Rows[36]["ScreenName"].ToString().Trim();
                }
            }
            catch
            {
            }
        }
        public string ExecuteCommandGhostLibrary(string commandInput, string commandOut)
        {
            try
            {
                int pageFrom = 1;
                int pageTo = 50;

                using (GhostscriptProcessor ghostscript = new GhostscriptProcessor())
                {
                    ghostscript.Processing += new GhostscriptProcessorProcessingEventHandler(ghostscript_Processing);

                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dSAFER");
                    switches.Add("-dBATCH");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOPROMPT");
                    switches.Add("-dFirstPage=" + pageFrom.ToString());
                    switches.Add("-dLastPage=" + pageTo.ToString());
                    switches.Add("-sDEVICE=png16m");
                    switches.Add("-r200");
               
                    switches.Add("-dTextAlphaBits=4");
                    switches.Add("-dGraphicsAlphaBits=4");
                    switches.Add(@"-sOutputFile=" + commandOut);
                    switches.Add(@"-f");
                    switches.Add(commandInput);

                    ghostscript.Process(switches.ToArray());
                }

                return "";

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ExecuteCommandGhostLibraryForThumbnail(string commandInput, string commandOut)
        {
            try
            {
                int pageFrom = 1;
                int pageTo = 50;

                using (GhostscriptProcessor ghostscript = new GhostscriptProcessor())
                {
                    ghostscript.Processing += new GhostscriptProcessorProcessingEventHandler(ghostscript_Processing);

                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dSAFER");
                    switches.Add("-dBATCH");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOPROMPT");
                    switches.Add("-dFirstPage=" + pageFrom.ToString());
                    switches.Add("-dLastPage=" + pageTo.ToString());
                    switches.Add("-sDEVICE=png16m");
                    //switches.Add("-r200");
                    //for thumbnail size image 
                    switches.Add("-r22.5");

                    switches.Add("-dTextAlphaBits=4");
                    switches.Add("-dGraphicsAlphaBits=4");
                    switches.Add(@"-sOutputFile=" + commandOut);
                    switches.Add(@"-f");
                    switches.Add(commandInput);

                    ghostscript.Process(switches.ToArray());
                }

                return "";

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        void ghostscript_Processing(object sender, GhostscriptProcessorProcessingEventArgs e)
        {
            Console.WriteLine(e.CurrentPage.ToString() + " / " + e.CurrentPage.ToString());
        }

        protected void ucEditableProduct_btnSave_ClickEventHandler(object sender, EventArgs e, string type)
        {
            if (type == "save")
            {
                this.FinalSave("editproduct", "save");
                return;
            }
            if (type == "savestay")
            {
                this.FinalSave("editproduct", "saveandstay");
            }
        }

        protected class CouponCodes
        {
            private long _CouponCodeID;

            private string _CouponCode;

            private string _CouponCodeUserFriendlyName;

            public string CouponCode
            {
                get
                {
                    return this._CouponCode;
                }
            }

            public long CouponCodeID
            {
                get
                {
                    return this._CouponCodeID;
                }
            }

            public string CouponCodeUserFriendlyName
            {
                get
                {
                    return this._CouponCodeUserFriendlyName;
                }
            }

            public CouponCodes(long CouponCodeID, string CouponCode, string CouponCodeUserFriendlyName)
            {
                this._CouponCodeID = CouponCodeID;
                this._CouponCode = CouponCode;
                this._CouponCodeUserFriendlyName = CouponCodeUserFriendlyName;
            }
        }

        protected class OrderNew
        {
            private string _OtherCostCategoryName;

            private string _WebOtherCostName;

            private string _UserFriendlyName;

            private long _webothercostid;

            private string _Description;

            private long _AdditionalGroupID;

            private string _GroupName;

            public long AdditionalGroupID
            {
                get
                {
                    return this._AdditionalGroupID;
                }
                set
                {
                    this._AdditionalGroupID = value;
                }
            }

            public string Description
            {
                get
                {
                    return this._Description;
                }
            }

            public string GroupName
            {
                get
                {
                    return this._GroupName;
                }
                set
                {
                    this._GroupName = value;
                }
            }

            public string OtherCostCategoryName
            {
                get
                {
                    return this._OtherCostCategoryName;
                }
            }

            public string UserFriendlyName
            {
                get
                {
                    return this._UserFriendlyName;
                }
            }

            public long WebOtherCostID
            {
                get
                {
                    return this._webothercostid;
                }
            }

            public string WebOtherCostName
            {
                get
                {
                    return this._WebOtherCostName;
                }
            }

            public OrderNew(long WebOtherCostID, string OtherCostCategoryName, string WebOtherCostName, string UserFriendlyName, string Description, long AdditionalGroupID, string GroupName)
            {
                this._webothercostid = WebOtherCostID;
                this._OtherCostCategoryName = OtherCostCategoryName;
                this._WebOtherCostName = WebOtherCostName;
                this._UserFriendlyName = UserFriendlyName;
                this._Description = Description;
                this._AdditionalGroupID = AdditionalGroupID;
                this._GroupName = GroupName;
            }
        }

        protected void lnkDecorationSaveAndStay_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }

            this.FinalSave("General", "saveandstay");
        }

        protected void lnkDecorationSave_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }

            this.FinalSave("General", "save");



        }

        protected void lnkFTPSaveAndStay_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }

            this.FinalSave("FTP", "saveandstay");
        }

        protected void lnkFTPSave_Click(object sender, EventArgs e)
        {
            if (this.action == "edit" && this.ChkEditableProduct.Checked)
            {
                this.ucEditableProduct.FinalSave();
            }

            this.FinalSave("FTP", "save");



        }
        private void BindFtpFolders()
        {
            ddlFtpFolders.Items.Clear();
            ddlFtpFolders.Items.Add(new ListItem("--- Select FTP Folder ---", "0"));

            var folders = SettingsBasePage.GetSavedFtpFolders(this.CompanyID);

            foreach (var folder in folders)
            {
                int id = folder.Key;
                string name = folder.Value;
                ddlFtpFolders.Items.Add(new ListItem(name, id.ToString()));
            }
        }
        private void BindTags()
        {
            // Sample static data - replace with DB fetch if needed
            var tags = new List<dynamic>
            {
                new { Tag = "{Date}", Description = "Current date. Format: DD.MM.YY (e.g., 07.05.25)" },
                new { Tag = "{Time}", Description = "Current time. Format: HH.MM.SS (e.g 10:30:00)" },
                new { Tag = "{OrderNumber}", Description = "Order number including item number. Example: ORD-0000137-001" },
                new { Tag = "{EstimateNumber}", Description = "Estimate number including item number. Example: Est-0000137-003" },
                new { Tag = "{JobNumber}", Description = "Job number associated with the item." },
                new { Tag = "{StoreName}", Description = "Name of the store. Spaces will be replaced with periods(.). Example: 'My Awesome Store' becomes 'My.Awesome.Store'" },
                new { Tag = "{SelectedFTPFolder}", Description = "The name/path of currently selected FTP folder.(e.g., /uploads/invoices/)" },
                new { Tag = "{Quantity}", Description = "Quantity of item purchased" }
            };

            gvTags.DataSource = tags;
            gvTags.DataBind();
        }
        protected void btnRemoveFTP_Click(object sender, ImageClickEventArgs e)
        {
            lnkUploadedFile.Visible = false;
            btnRemoveFTP.Visible = false;
            fileUploader.Visible = true;

            lnkUploadedFile.Text = "";
            lnkUploadedFile.NavigateUrl = "";
            string script = "gettabs('ft');";
            ClientScript.RegisterStartupScript(this.GetType(), "callTabFunction", script, true);
        }
    }
}