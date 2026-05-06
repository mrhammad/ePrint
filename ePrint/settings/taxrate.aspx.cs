using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class taxrate : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel_ascx header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadCodeBlock RadCodeBlock1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_loading_ascx ucLoading;

        //protected LinkButton lnkDeleteTax;

        //protected RadGrid RadGrid1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor2;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        //protected Panel panel2;

        //protected Button btnUpDown;

        //protected LinkButton lnkDeleteStatus;

        //protected RadGrid GridStatus;

        //protected ObjectDataSource odsStatus;

        //protected Label lbl_message;

        //protected Panel Panel1;

        //protected Label Label2;

        //protected DropDownList DropDownList1;

        //protected Button Button2;

        //protected Button Button3;

        //protected Button Button4;

        //protected Label Label3;

        //protected TextBox TextBox2;

        //protected Button Button5;

        //protected Button Button6;

        //protected HtmlGenericControl div_JobCardStatus;

        //protected HiddenField hidGridCount;

        //protected HiddenField hdnreturn;

        //protected Panel pnlCallScroll;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int statusidedit;

        public string TaxNames;

        public string Alias;

        private Global gloobj = new Global();

        public int CompanyID;

        public string StatusTitle = string.Empty;

        public int StatusID;

        public string strSitepath = global.sitePath();

        public int totalrec;

        public string type = string.Empty;

        public string strImagepath;

        public string mode = string.Empty;

        public int StatusEditID;

        public int UserID;

        public int estimate;

        public int job;

        public int invoice;

        public int purchase;

        public int delivery;
        public int proof;

        public int PageSize = 10000;

        private commonClass objJava = new commonClass();

        public string param = string.Empty;

        public languageClass objlang = new languageClass();

        public static Hashtable ht;

        public string WebStore = ConnectionClass.WebStore;

        private string gridMessage;
        public bool proofPermission = commonClass.CheckProofPermission();


        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<taxrate.OrderNew> PendingOrders
        {
            get
            {
                IList<taxrate.OrderNew> orderNews;
                try
                {
                    object item = this.Session["Status"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<taxrate.OrderNew>();
                        }
                        else
                        {
                            this.Session["Status"] = item;
                        }
                    }
                    orderNews = (IList<taxrate.OrderNew>)item;
                }
                catch
                {
                    this.Session["Status"] = null;
                    return new List<taxrate.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["Status"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static taxrate()
        {
            taxrate.ht = new Hashtable();
        }

        public taxrate()
        {
        }

        protected void btnCancelStatus_Clicked(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnSaveStatus_OnClick(object sender, EventArgs e)
        {
        }

        protected void btnUpDown_OnClick(object sender, EventArgs e)
        {
            foreach (long key in taxrate.ht.Keys)
            {
                SettingsBasePage.settings_estimatestatus_order_number_update(this.CompanyID, Convert.ToInt32(key), Convert.ToInt32(taxrate.ht[key]));
                SettingsBasePage.settings_estimatestatus_sortalpha_update(this.CompanyID, Convert.ToInt32(key), "False");
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Order_ReArranged_Successfully"), "msg-success", this.plhMessage);
        }

        private void DisplayMessage(string text)
        {
            this.RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        private static taxrate.OrderNew GetOrder(IEnumerable<taxrate.OrderNew> ordersToSearchIn, long StatusID)
        {
            taxrate.OrderNew orderNew;
            using (IEnumerator<taxrate.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    taxrate.OrderNew current = enumerator.Current;
                    if (current.StatusID != StatusID)
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

        protected IList<taxrate.OrderNew> GetOrders()
        {
            IList<taxrate.OrderNew> orderNews = new List<taxrate.OrderNew>();
            DataTable dataTable = this.GridStatusBindTable();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["StatusID"].ToString());
                        string str = base.SpecialDecode(row["StatusTitle"].ToString());
                        string str1 = row["Estimate"].ToString();
                        string str2 = row["Job"].ToString();
                        string str3 = row["Invoice"].ToString();
                        string str4 = row["Purchase"].ToString();
                        string str5 = row["Delivery"].ToString();
                        string str6 = base.SpecialDecode(row["UserFriendlyName"].ToString());
                        string str7 = base.SpecialDecode(row["Probability"].ToString());
                        string str8 = base.SpecialDecode(row["Proof"].ToString());
                        string str9 = base.SpecialDecode(row["StatusColorCode"].ToString());
                        //string str10 = base.SpecialDecode(row["StatusColorCode"].ToString());
                        string empty = string.Empty;
                        orderNews.Add(new taxrate.OrderNew(num, str, str1, str2, str3, str4, str5, empty, str6, str7, str8, str9));
                    }
                    this.Session["Status"] = dataTable;
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
            this.GridStatus.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            taxrate.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridStatus.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridStatus.ClientID)
            {
                IList<taxrate.OrderNew> pendingOrders = this.PendingOrders;
                taxrate.OrderNew order = taxrate.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("StatusID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<taxrate.OrderNew> orderNews = new List<taxrate.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    taxrate.OrderNew orderNew = taxrate.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("StatusID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (taxrate.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    taxrate.ht.Add(pendingOrders[i].StatusID, i + 1);
                }
                this.GridStatus.DataSource = this.PendingOrders;
                this.GridStatus.Rebind();
                int pageSize = num - this.GridStatus.PageSize * this.GridStatus.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        public void GridBind()
        {
            this.SessionDataSource1.TypeName = "Printcenter.UI.Setting.SettingsBasePage";
            this.SessionDataSource1.SelectMethod = "settings_taxrate_select";
            this.SessionDataSource1.SelectParameters.Clear();
            this.SessionDataSource1.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void GridStatus_InsertCommand(object sender, GridCommandEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num9 = 0;
            GridItem item = e.Item;
            TextBox empty = (TextBox)e.Item.FindControl("txtStatus");
            TextBox textBox = (TextBox)e.Item.FindControl("txt_UserFriendlyName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtProbability");
            DropDownList ddl1 = (DropDownList)e.Item.FindControl("ddlStatusColor");
            CheckBoxList checkBoxList = (CheckBoxList)e.Item.FindControl("chk_modname");
            CheckBoxList checkBoxList1 = (CheckBoxList)e.Item.FindControl("chk_default");
            this.estimate = Convert.ToInt32(checkBoxList.Items[0].Selected);
            this.job = Convert.ToInt32(checkBoxList.Items[1].Selected);
            this.invoice = Convert.ToInt32(checkBoxList.Items[2].Selected);
            this.purchase = Convert.ToInt32(checkBoxList.Items[3].Selected);
            this.delivery = Convert.ToInt32(checkBoxList.Items[4].Selected);
            if (proofPermission)
            {
                this.proof = Convert.ToInt32(checkBoxList.Items[5].Selected);
            }
            if (this.estimate == 1)
            {
                num = Convert.ToInt32(checkBoxList1.Items[0].Selected);
            }
            if (this.job == 1)
            {
                num1 = Convert.ToInt32(checkBoxList1.Items[1].Selected);
            }
            if (this.invoice == 1)
            {
                num2 = Convert.ToInt32(checkBoxList1.Items[2].Selected);
            }
            if (this.purchase == 1)
            {
                num3 = Convert.ToInt32(checkBoxList1.Items[3].Selected);
            }
            if (this.delivery == 1)
            {
                num4 = Convert.ToInt32(checkBoxList1.Items[4].Selected);
            }
            if (proofPermission)
            {
                if (this.proof == 1)
                {
                    num9 = Convert.ToInt32(checkBoxList1.Items[5].Selected);
                }
            }

            int num5 = 0;
            for (int i = 0; i < checkBoxList1.Items.Count; i++)
            {
                if (checkBoxList1.Items[i].Selected)
                {
                    num5 = 1;
                }
            }
            int num6 = 0;
            int num7 = 0;
            num6 = (textBox1.Text != "" ? Convert.ToInt32(textBox1.Text) : 0);
            if (!proofPermission)
            {
                num7 = SettingsBasePage.settings_estimatestatus_insert_new(this.CompanyID, base.SpecialEncode(empty.Text), this.estimate, this.job, this.invoice, this.purchase, this.delivery, 0, num, num1, num2, num3, num4, 0, num5, base.SpecialEncode(textBox.Text), Convert.ToInt32(num6), ddl1.SelectedItem.Value);
            }
            else
            {
                num7 = SettingsBasePage.settings_estimatestatus_insert_new_proof(this.CompanyID, base.SpecialEncode(empty.Text), this.estimate, this.job, this.invoice, this.purchase, this.delivery, this.proof, 0, num, num1, num2, num3, num4, num9, 0, num5, base.SpecialEncode(textBox.Text), Convert.ToInt32(num6), ddl1.SelectedItem.Value);
            }
            empty.Text = string.Empty;
            if (num7 == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Status_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Status_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            this.GridStatus.DataSource = this.GridStatusBindTable();
            this.GridStatus.DataBind();
        }

        protected void GridStatus_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridStatus.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.GridStatus.MasterTableView.ClearEditItems();
            }
        }

        protected void GridStatus_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                //if (this.WebStore.ToLower() != "yes")
                //{
                //    this.GridStatus.Columns[2].Visible = false;
                //}
                //else
                //{
                //    this.GridStatus.Columns[2].Visible = true;
                //}
                if (proofPermission)
                {
                    this.GridStatus.Columns[9].Visible = true;
                }
                else
                {
                    this.GridStatus.Columns[9].Visible = false;
                }
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkAll");
                HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)e.Item.FindControl("Id");
                Label label = (Label)e.Item.FindControl("lblStatusID");
                Image image = (Image)e.Item.FindControl("img_default_value");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkStatus");
                if (label != null)
                {
                    if (SettingsBasePage.settings_estimatestatus_delete_check_all_module(this.CompanyID, Convert.ToInt32(label.Text), linkButton.Text.ToString()) != -1)
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        htmlInputCheckBox1.Disabled = true;
                        image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (linkButton != null)
                {
                    if (linkButton.Text.ToString().ToLower() == "locked")
                    {
                        htmlInputCheckBox1.Disabled = true;
                    }
                }
                if (linkButton != null)
                {
                    if (linkButton.Text.ToString().ToLower() == "cancelled")
                    {
                        htmlInputCheckBox1.Disabled = true;
                    }
                }

                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_statusid");
                if (hiddenField != null)
                {
                    this.statusidedit = Convert.ToInt32(hiddenField.Value);
                }
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_estimate");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_job");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_invoice");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_purchase");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_delivery");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_isdefault");
                Image image1 = (Image)e.Item.FindControl("img_estimate");
                Image image2 = (Image)e.Item.FindControl("img_job");
                Image image3 = (Image)e.Item.FindControl("img_invoice");
                Image image4 = (Image)e.Item.FindControl("img_purchase");
                Image image5 = (Image)e.Item.FindControl("img_delivery");

                Image image6 = (Image)e.Item.FindControl("img_isdefault");
                if ((new BaseClass()).Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID)).Trim().ToLower() != "true")
                {
                    this.GridStatus.Columns[3].Visible = false;
                }
                else
                {
                    this.GridStatus.Columns[3].Visible = true;
                }
                if (hiddenField1 != null)
                {
                    if (hiddenField1.Value.ToLower() != "true")
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (hiddenField2 != null)
                {
                    if (hiddenField2.Value != "True")
                    {
                        image2.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image2.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (hiddenField3 != null)
                {
                    if (hiddenField3.Value != "True")
                    {
                        image3.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image3.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (hiddenField4 != null)
                {
                    if (hiddenField4.Value != "True")
                    {
                        image4.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image4.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (hiddenField5 != null)
                {
                    if (hiddenField5.Value != "True")
                    {
                        image5.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image5.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }

                if (hiddenField6 != null)
                {
                    if (hiddenField6.Value != "True")
                    {
                        image6.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image6.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                }
                if (proofPermission)
                {

                    HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdn_proof");
                    Image image7 = (Image)e.Item.FindControl("img_proof");
                    if (hiddenField7 != null)
                    {
                        if (hiddenField7.Value != "True")
                        {
                            image7.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                        }
                        else
                        {
                            image7.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        }
                    }
                }


            }
            catch
            {
            }
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivProbability");
                if ((new BaseClass()).Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID)).Trim().ToLower() != "true")
                {
                    htmlControl.Style.Add("display", "none");
                }
                else
                {
                    //htmlControl.Style.Add("display", "block");//Ticket 14366
                }
                TextBox textBox = (TextBox)e.Item.FindControl("txtStatus");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txt_UserFriendlyName");
                DropDownList ddl1 = (DropDownList)e.Item.FindControl("ddlStatusColor");
                CheckBoxList languageConversion = (CheckBoxList)e.Item.FindControl("chk_modname");
                CheckBoxList flag = (CheckBoxList)e.Item.FindControl("chk_default");
                languageConversion.Items[0].Text = this.objlang.GetLanguageConversion("Estimate");
                languageConversion.Items[1].Text = this.objlang.GetLanguageConversion("Job");
                languageConversion.Items[2].Text = this.objlang.GetLanguageConversion("Invoice");
                languageConversion.Items[3].Text = this.objlang.GetLanguageConversion("Purchase");
                languageConversion.Items[4].Text = this.objlang.GetLanguageConversion("Delivery Note");
                if (proofPermission)
                {
                    languageConversion.Items[5].Text = this.objlang.GetLanguageConversion("Proof");

                }
                textBox.Focus();
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox1.Text = base.SpecialDecode(textBox1.Text);
                if (textBox.Text != "")
                {
                    DataTable dataTable = new DataTable();
                    dataTable = SettingsBasePage.get_jobStatus_Title(this.CompanyID, this.statusidedit);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ddl1.SelectedValue = row["StatusColorCode"].ToString();
                        languageConversion.Items[0].Selected = Convert.ToBoolean(row["Estimate"].ToString());
                        languageConversion.Items[1].Selected = Convert.ToBoolean(row["Job"].ToString());
                        languageConversion.Items[2].Selected = Convert.ToBoolean(row["Invoice"].ToString());
                        languageConversion.Items[3].Selected = Convert.ToBoolean(row["Purchase"].ToString());
                        languageConversion.Items[4].Selected = Convert.ToBoolean(row["Delivery"].ToString());
                        if (proofPermission)
                        {
                            if (!string.IsNullOrEmpty(row["Proof"].ToString()))
                            {
                                languageConversion.Items[5].Selected = Convert.ToBoolean(row["Proof"].ToString());
                            }
                            else
                            {
                                languageConversion.Items[5].Selected = false;
                            }
                        }

                        flag.Items[0].Selected = Convert.ToBoolean(row["EstimateDefault"].ToString());
                        flag.Items[1].Selected = Convert.ToBoolean(row["JobDefault"].ToString());
                        flag.Items[2].Selected = Convert.ToBoolean(row["InvoiceDefault"].ToString());
                        flag.Items[3].Selected = Convert.ToBoolean(row["PurchaseDefault"].ToString());
                        flag.Items[4].Selected = Convert.ToBoolean(row["DeliveryDefault"].ToString());
                        if (proofPermission)
                        {
                            if (!string.IsNullOrEmpty(row["ProofDefault"].ToString()))
                            {
                                flag.Items[5].Selected = Convert.ToBoolean(row["ProofDefault"].ToString());
                            }
                            else
                            {
                                flag.Items[5].Selected = false;
                            }
                        }

                    }
                }
                if (!proofPermission)
                {
                    languageConversion.Items.RemoveAt(5);
                    flag.Items.RemoveAt(5);
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridStatus.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridStatus.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridStatus_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num9 = 0;
            GridItem item = e.Item;
            CheckBoxList checkBoxList = (CheckBoxList)e.Item.FindControl("chk_modname");
            CheckBoxList checkBoxList1 = (CheckBoxList)e.Item.FindControl("chk_default");
            TextBox empty = (TextBox)e.Item.FindControl("txtStatus");
            TextBox textBox = (TextBox)e.Item.FindControl("txt_UserFriendlyName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtProbability");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_statusid");
            DropDownList ddl1 = (DropDownList)e.Item.FindControl("ddlStatusColor");
            int num5 = Convert.ToInt32(hiddenField.Value);
            this.estimate = Convert.ToInt32(checkBoxList.Items[0].Selected);
            this.job = Convert.ToInt32(checkBoxList.Items[1].Selected);
            this.invoice = Convert.ToInt32(checkBoxList.Items[2].Selected);
            this.purchase = Convert.ToInt32(checkBoxList.Items[3].Selected);
            this.delivery = Convert.ToInt32(checkBoxList.Items[4].Selected);
            if (proofPermission)
            {
                this.proof = Convert.ToInt32(checkBoxList.Items[5].Selected);
            }
            if (this.estimate == 1)
            {
                num = Convert.ToInt32(checkBoxList1.Items[0].Selected);
            }
            if (this.job == 1)
            {
                num1 = Convert.ToInt32(checkBoxList1.Items[1].Selected);
            }
            if (this.invoice == 1)
            {
                num2 = Convert.ToInt32(checkBoxList1.Items[2].Selected);
            }
            if (this.purchase == 1)
            {
                num3 = Convert.ToInt32(checkBoxList1.Items[3].Selected);
            }
            if (this.delivery == 1)
            {
                num4 = Convert.ToInt32(checkBoxList1.Items[4].Selected);
            }
            if (proofPermission)
            {
                if (this.proof == 1)
                {
                    num9 = Convert.ToInt32(checkBoxList1.Items[5].Selected);
                }
            }

            int num6 = 0;
            for (int i = 0; i < checkBoxList1.Items.Count; i++)
            {
                if (checkBoxList1.Items[i].Selected)
                {
                    num6 = 1;
                }
            }
            int num7 = 0;
            int num8 = 0;
            num7 = (textBox1.Text != "" ? Convert.ToInt32(textBox1.Text) : 0);
            if (!proofPermission)
            {
                num8 = SettingsBasePage.settings_estimatestatus_update_new(this.CompanyID, num5, base.SpecialEncode(empty.Text), Convert.ToInt32(this.estimate), Convert.ToInt32(this.job), Convert.ToInt32(this.invoice), Convert.ToInt32(this.purchase), Convert.ToInt32(this.delivery), 0, num, num1, num2, num3, num4, 0, num6, base.SpecialEncode(textBox.Text), Convert.ToInt32(num7),ddl1.SelectedItem.Value);
            }
            else
            {
                num8 = SettingsBasePage.settings_estimatestatus_update_new_proof(this.CompanyID, num5, base.SpecialEncode(empty.Text), Convert.ToInt32(this.estimate), Convert.ToInt32(this.job), Convert.ToInt32(this.invoice), Convert.ToInt32(this.purchase), Convert.ToInt32(this.delivery), Convert.ToInt32(this.proof), 0, num, num1, num2, num3, num4, num9, 0, num6, base.SpecialEncode(textBox.Text), Convert.ToInt32(num7),ddl1.SelectedItem.Value);

            }
            if (num8 != -1)
            {
                empty.Text = string.Empty;
            }
            if (num8 == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Status_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Status_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            this.GridStatus.DataSource = this.GridStatusBindTable();
            this.GridStatus.DataBind();
        }

        protected DataTable GridStatusBindTable()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_estimatestatus_select_new(this.CompanyID, this.param.ToString().Trim());
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = base.SpecialDecode(row["StatusTitle"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
                row["Probability"] = base.SpecialDecode(row["Probability"].ToString());
            }
            return dataTable;
        }

        protected void GridStatusBindTableAlpha(object source, GridSortCommandEventArgs e)
        {
            this.param = "alpha";
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_estimatestatus_select_new(this.CompanyID, this.param.ToString().Trim());
            this.GridStatus.DataSource = dataTable;
            this.GridStatus.DataBind();
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_delete_new");
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.String, e.CommandArgument);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            base.Message_Display(this.objLanguage.GetLanguageConversion("Tax_Rate_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDeleteStatus_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridStatus.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridStatus.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_estimatestatus_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.GridStatus.DataSource = this.GridStatusBindTable();
            this.GridStatus.DataBind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            base.Message_Display(this.objlang.GetLanguageConversion("Status_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDeleteTax_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.MasterTableView.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("Id1");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_taxrate_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.RadGrid1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Tax_Rate_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void ObjDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Tax_Rate_already_exists"), "msg-fail", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Tax_Rate_Successfully_Inserted"), "msg-success", this.plhMessage);
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void ObjDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Tax_Rate_already_exists"), "msg-fail", this.plhMessage);
                return;
            }
            base.Message_Display(this.objlang.GetLanguageConversion("Tax_Rate_successfully_updated"), "msg-success", this.plhMessage);
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            this.btnUpDown.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnUpDownprocess');");
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.strImagepath = global.imagePath();
            if (base.Request.Params["type"].ToString() != null)
            {
                this.type = base.Request.Params["type"].ToString();
                if (this.type == "TR")
                {
                    this.Panel1.Visible = false;
                    this.panel2.Visible = true;
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Tax_Rates")));
                    base.Title = this.objlang.convert(global.pageTitle("Tax Rates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objlang.GetLanguageConversion("Tax_Rates");
                    this.lblheader.Text = this.objlang.GetLanguageConversion("Settings_TaxRates");
                    this.RadGrid1.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Tax_Name");
                    this.RadGrid1.MasterTableView.Columns[2].HeaderText = "Alias";
                    this.RadGrid1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Tax_Rate");
                    this.RadGrid1.MasterTableView.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Action");
                    this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
                }
                else if (this.type == "JS")
                {
                    this.Panel1.Visible = true;
                    this.panel2.Visible = false;
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Status")));
                    base.Title = this.objlang.convert(global.pageTitle("Status", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objlang.GetLanguageConversion("Status");
                    this.GridStatus.Columns[10].HeaderText = this.objlang.GetLanguageConversion("Action");
                    this.GridStatus.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
                    this.lblheader.Text = string.Concat(this.objlang.GetLanguageConversion("Settings"), " : ", this.objlang.GetLanguageConversion("Status"));
                }
                if (!(this.type == "TR") && this.type == "JS")
                {
                    if (!base.IsPostBack)
                    {
                        this.Session["Status"] = null;
                        string str = SettingsBasePage.settings_estimatestatus_sortalpha_select(this.CompanyID);
                        if (str != null && str.ToString() != "")
                        {
                        }
                    }
                    if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString() != "")
                    {
                        this.plhMessage.Visible = true;
                        base.Message_Display(this.objlang.GetLanguageConversion("Status_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                DataTable dataTable = this.GridStatusBindTable();
                foreach (DataRow row in dataTable.Rows)
                {
                    row["StatusTitle"] = base.SpecialDecode(row["StatusTitle"].ToString());
                    row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
                    row["Probability"] = base.SpecialDecode(row["Probability"].ToString());
                }
                this.GridStatus.DataSource = dataTable;
                if (!base.IsPostBack)
                {
                    this.pnlCallScroll.Visible = true;
                    this.GridBind();
                }
                this.btnUpDown.Visible = true;
                if (!base.IsPostBack && base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() != "" && base.Request.Params["mode"].ToString().ToLower() == "update" && base.Request.Params["editid"].ToString() != "")
                {
                    DataTable jobStatusTitle = new DataTable();
                    jobStatusTitle = SettingsBasePage.get_jobStatus_Title(this.CompanyID, Convert.ToInt32(base.Request.Params["editid"].ToString()));
                    foreach (DataRow dataRow in jobStatusTitle.Rows)
                    {
                    }
                }
                if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
                {
                    this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
                }
            }
            this.btnUpDown.Text = this.objLanguage.GetLanguageConversion("Save_Order");
        }

        protected void RadGrid1_DataBound(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridMessage))
            {
                this.DisplayMessage(this.gridMessage);
            }
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtTaxName");
            RadTextBox radTextBox2 = (RadTextBox)e.Item.FindControl("Alias");
            string str = base.SpecialEncode(radTextBox.Text);
            string str2 = base.SpecialEncode(radTextBox2.Text);
            this.SessionDataSource1.InsertParameters.Add("CompanyID", this.CompanyID.ToString());
            this.SessionDataSource1.InsertParameters.Add("taxName", str);
            this.SessionDataSource1.InsertParameters.Add("Alias", str2);
        }

        protected void RadGrid1_ItemCreated(object source, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridItem item = e.Item;
                RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtTaxName");
                this.ReplaceSingleQuote1(radTextBox.Text);
            }
        }

        protected void radGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                RadTextBox radTextBox = item.FindControl("txtTaxName") as RadTextBox;
                RequiredFieldValidator languageConversion = item.FindControl("RequiredFieldValidator2") as RequiredFieldValidator;
                RadButton radButton = item.FindControl("btnCancel") as RadButton;
                RadButton languageConversion1 = item.FindControl("RadButton1") as RadButton;
                languageConversion.ErrorMessage = this.objlang.GetLanguageConversion("Enter_Tax_Name");
                radButton.Text = this.objlang.GetLanguageConversion("Cancel");
                languageConversion1.Text = this.objlang.GetLanguageConversion("Save");
                radTextBox.Text = base.SpecialDecode(radTextBox.Text);
                radTextBox.Focus();
            }
            if (e.Item is GridDataItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = gridDataItem.FindControl("lblTaxRate") as Label;
                Label text = gridDataItem.FindControl("lblTaxName") as Label;
                text.Text = base.SpecialDecode(text.Text);
                text.ToolTip = text.Text;
                label.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text.ToString()), 4, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label label1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGrid1_ItemUpdated(object source, GridUpdatedEventArgs e)
        {
            GridEditableItem item = e.Item;
        }

        protected void RadGrid1_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid1.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid1.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditFormItem item = (GridEditFormItem)e.Item;
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtTaxName");
            RadTextBox radTextBox2 = (RadTextBox)e.Item.FindControl("Alias");
            this.TaxNames = base.SpecialEncode(radTextBox.Text);
            this.Alias = base.SpecialEncode(radTextBox2.Text);
            this.SessionDataSource1.UpdateParameters.Add("CompanyID", this.CompanyID.ToString());
            this.SessionDataSource1.UpdateParameters.Add("taxName", this.TaxNames);
            this.SessionDataSource1.UpdateParameters.Add("Alias", this.Alias);
        }

        public string ReplaceSingleQuote1(string OriginalString)
        {
            return OriginalString.Replace("'", "`");
        }

        private void SetMessage(string message)
        {
            this.gridMessage = message;
        }

        protected class OrderNew
        {
            private long _StatusID;

            private string _StatusTitle;

            private string _Estimate;

            private string _Job;

            private string _Proof;

            private string _Invoice;

            private string _Purchase;

            private string _Delivery;

            private string _InUse;

            private string _UserFriendlyName;

            private string _Probability;
        
            private string _StatusColorCode;

            public string Delivery
            {
                get
                {
                    return this._Delivery;
                }
            }

            public string Estimate
            {
                get
                {
                    return this._Estimate;
                }
            }

            public string InUse
            {
                get
                {
                    return this._InUse;
                }
            }

            public string Invoice
            {
                get
                {
                    return this._Invoice;
                }
            }

            public string Proof
            {
                get
                {
                    return this._Proof;
                }
            }

            public string Job
            {
                get
                {
                    return this._Job;
                }
            }

            public string Probability
            {
                get
                {
                    return this._Probability;
                }
            }

            public string Purchase
            {
                get
                {
                    return this._Purchase;
                }
            }

            public long StatusID
            {
                get
                {
                    return this._StatusID;
                }
            }

            public string StatusTitle
            {
                get
                {
                    return this._StatusTitle;
                }
            }

          

            public string StatusColorCode
            {
                get
                {
                    return this._StatusColorCode;
                }
            }

            public string UserFriendlyName
            {
                get
                {
                    return this._UserFriendlyName;
                }
            }

            public OrderNew(long StatusID, string StatusTitle, string Estimate, string Job, string Invoice, string Purchase, string Delivery, string InUse, string UserFriendlyName, string Probability, string Proof, string StatusColorCode)
            {
                this._StatusID = StatusID;
                this._StatusTitle = StatusTitle;
                this._Estimate = Estimate;
                this._Job = Job;
                this._Invoice = Invoice;
                this._Purchase = Purchase;
                this._Delivery = Delivery;
                this._InUse = InUse;
                this._Proof = Proof;
                this._UserFriendlyName = UserFriendlyName;
                this._Probability = Probability;
                this._StatusColorCode = StatusColorCode;
            }
        }
    }
}


