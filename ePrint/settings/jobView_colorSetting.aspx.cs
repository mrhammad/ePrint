using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class jobView_colorSetting : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected DropDownList ddlDeliveryDate;

        //protected TextBox tbDays;

        //protected ImageButton imgColor;

        //protected HiddenField hiddenid;

        //protected HiddenField hdnColorid1;

        //protected HiddenField hdnColoridElapsed;

        //protected HiddenField hdnDaysElapsed;

        //protected HiddenField hdnColorElapsed;

        //protected HiddenField hdnColoridOnSameDay;

        //protected HiddenField hdnNoOfDays;

        //protected HiddenField hdnColorSameDay;

        //protected HtmlGenericControl divAddnew;

        //protected CheckBox Chk_DeliveryColor;

        //protected LinkButton lnkDelete;

        //protected RadGrid grdcolorSetting;

        //protected UpdatePanel updatepnlgrdcolorSetting;

        //protected HiddenField hidoptionddlbind;

        //protected RadCodeBlock RadCodeBlock1;

        //protected HiddenField hdnoption;

        //protected HiddenField Hiddays;

        //protected DropDownList ddlProductionDate;

        //protected TextBox tbDays1;

        //protected ImageButton ImageButton1;

        //protected HiddenField HiddenField1;

        //protected HiddenField hdnColorid2;

        //protected HiddenField hdnColoridElapsed1;

        //protected HiddenField hdnDaysElapsed1;

        //protected HiddenField hdnColorElapsed1;

        //protected HiddenField hdnColoridOnSameDay1;

        //protected HiddenField hdnNoOfDays1;

        //protected HiddenField hdnColorSameDay1;

        //protected HtmlGenericControl div1;

        //protected CheckBox Chk_ProductionColor1;

        //protected LinkButton LinkButton1;

        //protected RadGrid RadGrid_ProductDate;

        //protected UpdatePanel UpdatePanel1;

        //protected HiddenField hidoptionddlbind1;

        //protected RadCodeBlock RadCodeBlock2;

        //protected HiddenField HiddenField10;

        //protected HiddenField HiddenField11;

        //protected HiddenField hdnIDPart;

        private Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        private commonClass objJava = new commonClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int colorid;

        public int UserID;

        public string optiontxt = string.Empty;

        public string noOfDays = string.Empty;

        public string colorCode = string.Empty;

        public string colorformat = string.Empty;

        private BasePage objLog = new BasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string DateTypeSelected = string.Empty;

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

        public jobView_colorSetting()
        {
        }

        public void btnDelete_OnClick(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            this.colorid = Convert.ToInt32(imageButton.CommandArgument.ToString());
            SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.ExecuteNonQuery();
            this.GridBind();
            this.grdcolorSetting.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void btnDelete_OnClick_prod(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            this.colorid = Convert.ToInt32(imageButton.CommandArgument.ToString());
            SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.ExecuteNonQuery();
            this.GridBind_prod();
            this.RadGrid_ProductDate.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void btnDelete_OnClick_comp(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            this.colorid = Convert.ToInt32(imageButton.CommandArgument.ToString());
            SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.ExecuteNonQuery();
            this.GridBind_comp();
            this.RadGrid_CompletionDate.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void chkbtnDelete_OnClick(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.grdcolorSetting.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkcolorId2");
                this.colorid = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@id", this.colorid);
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.ExecuteNonQuery();
            }
            this.GridBind();
            this.grdcolorSetting.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void chkbtnDelete_OnClick_prod(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.RadGrid_ProductDate.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkcolorId1");
                this.colorid = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@id", this.colorid);
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.ExecuteNonQuery();
            }
            this.GridBind_prod();
            this.RadGrid_ProductDate.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void chkbtnDelete_OnClick_comp(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.RadGrid_CompletionDate.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkcolorId2");
                this.colorid = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_JobviewColor_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@id", this.colorid);
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.ExecuteNonQuery();
            }
            this.GridBind_comp();
            this.RadGrid_CompletionDate.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Color_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        [WebMethod]
        public static void FindColor1(string ColorFrom, int CompanyID)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Apply", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", CompanyID);
            sqlCommand.Parameters.Add("@DateTypeSelected", ColorFrom);
            sqlCommand.ExecuteNonQuery();
        }

        protected void grdcolorSetting_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdcolorSetting.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdcolorSetting.MasterTableView.ClearEditItems();
            }
        }

        protected void grdcolorSetting_OnItemCommand_prod(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid_ProductDate.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid_ProductDate.MasterTableView.ClearEditItems();
            }
        }

        protected void grdcolorSetting_OnItemCommand_comp(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid_CompletionDate.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid_CompletionDate.MasterTableView.ClearEditItems();
            }
        }

        public void grdcolorSetting_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                string[] strArrays = this.hidoptionddlbind.Value.ToString().Trim().Split(new char[] { '>' });
                if ((int)strArrays.Length > 1)
                {
                    strArrays[0].ToString();
                    string str = strArrays[1].ToString();
                    string str1 = strArrays[2].ToString();
                    DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlDeliveryDate");
                    HtmlContainerControl htmlContainerControl = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                    TextBox textBox = (TextBox)e.Item.FindControl("tbDays");
                    ((HiddenField)e.Item.FindControl("hdndivColor")).Value = str1;
                    dropDownList.Attributes.Add("onchange", string.Concat("javascript:setDays(this,", textBox.ClientID, ");"));
                    if (str.ToLower() == "elapsed")
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "2";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() == "before")
                    {
                        dropDownList.SelectedValue = "1";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() != "on same day")
                    {
                        dropDownList.SelectedValue = "0";
                        textBox.Enabled = true;
                        htmlContainerControl.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
                    }
                    else
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "3";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                }
            }
            if (e.Item is GridEditableItem && e.Item.ItemIndex == -1)
            {
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlDeliveryDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("tbDays");
                dropDownList1.Attributes.Add("onchange", string.Concat("javascript:setDays(this,", textBox1.ClientID, ");"));
                dropDownList1.SelectedValue = "0";
                textBox1.Text = "";
                textBox1.Enabled = true;
                HtmlContainerControl htmlContainerControl1 = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                htmlContainerControl1.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbltxt");
                this.hidoptionddlbind.Value = label.Text.ToString();
                string[] strArrays1 = label.Text.ToString().Trim().Split(new char[] { '>' });
                string str2 = strArrays1[0].ToString();
                string str3 = strArrays1[1].ToString();
                string str4 = strArrays1[2].ToString();
                Label label1 = (Label)e.Item.FindControl("lblDisplayColor");
                label1.Style.Add("background-color", str4.ToString());
                label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                Label label2 = (Label)e.Item.FindControl("lblID");
                Label label3 = (Label)e.Item.FindControl("lnkeditcolor");
                if (str3.ToLower() == "elapsed")
                {
                    this.hdnColorid1.Value = label2.Text;
                    this.hdnColoridElapsed.Value = label2.Text.ToString();
                    this.hdnDaysElapsed.Value = str2.ToString();
                    this.hdnColorElapsed.Value = str4.ToString();
                    label.Text = "elapsed";
                }
                else if (str3.ToLower() != "before")
                {
                    this.hdnColoridOnSameDay.Value = label2.Text.ToString();
                    this.hdnNoOfDays.Value = str2.ToString();
                    this.hdnColorSameDay.Value = str4.ToString();
                    label.Text = "on same day";
                }
                else
                {
                    label.Text = string.Concat(str2, " Days before");
                }
                AttributeCollection attributes = label.Attributes;
                string[] strArrays2 = new string[] { "javascript:addnew('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributes.Add("onclick", string.Concat(strArrays2));
                AttributeCollection attributeCollection = label3.Attributes;
                string[] strArrays3 = new string[] { "javascript:addnew('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributeCollection.Add("onclick", string.Concat(strArrays3));
            }
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                foreach (GridColumn column in this.grdcolorSetting.MasterTableView.Columns)
                {
                    if (item[column.UniqueName].Text != "color")
                    {
                        continue;
                    }
                    item[column.UniqueName].Text = this.colorformat.ToString();
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdcolorSetting.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdcolorSetting.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void grdcolorSetting_OnItemDataBound_prod(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                string[] strArrays = this.hidoptionddlbind1.Value.ToString().Trim().Split(new char[] { '>' });
                if ((int)strArrays.Length > 1)
                {
                    strArrays[0].ToString();
                    string str = strArrays[1].ToString();
                    string str1 = strArrays[2].ToString();
                    DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlProductionDate");
                    HtmlContainerControl htmlContainerControl = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                    TextBox textBox = (TextBox)e.Item.FindControl("tbDays1");
                    ((HiddenField)e.Item.FindControl("hdndivColor")).Value = str1;
                    dropDownList.Attributes.Add("onchange", string.Concat("javascript:setDays(this,", textBox.ClientID, ");"));
                    if (str.ToLower() == "elapsed")
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "2";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() == "before")
                    {
                        dropDownList.SelectedValue = "1";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() != "on same day")
                    {
                        dropDownList.SelectedValue = "0";
                        textBox.Enabled = true;
                        htmlContainerControl.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
                    }
                    else
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "3";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                }
            }
            if (e.Item is GridEditableItem && e.Item.ItemIndex == -1)
            {
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlProductionDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("tbDays1");
                dropDownList1.Attributes.Add("onchange", string.Concat("javascript:setDays1(this,", textBox1.ClientID, ");"));
                dropDownList1.SelectedValue = "0";
                textBox1.Text = "";
                textBox1.Enabled = true;
                HtmlContainerControl htmlContainerControl1 = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                htmlContainerControl1.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbltxt1");
                this.hidoptionddlbind1.Value = label.Text.ToString();
                string[] strArrays1 = label.Text.ToString().Trim().Split(new char[] { '>' });
                string str2 = strArrays1[0].ToString();
                string str3 = strArrays1[1].ToString();
                string str4 = strArrays1[2].ToString();
                Label label1 = (Label)e.Item.FindControl("lblDisplayColor1");
                label1.Style.Add("background-color", str4.ToString());
                label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                Label label2 = (Label)e.Item.FindControl("lblID1");
                Label label3 = (Label)e.Item.FindControl("lnkeditcolor1");
                if (str3.ToLower() == "elapsed")
                {
                    this.hdnColorid2.Value = label2.Text;
                    this.hdnColoridElapsed1.Value = label2.Text.ToString();
                    this.hdnDaysElapsed1.Value = str2.ToString();
                    this.hdnColorElapsed1.Value = str4.ToString();
                    label.Text = "elapsed";
                }
                else if (str3.ToLower() != "before")
                {
                    this.hdnColoridOnSameDay1.Value = label2.Text.ToString();
                    this.hdnNoOfDays1.Value = str2.ToString();
                    this.hdnColorSameDay1.Value = str4.ToString();
                    label.Text = "on same day";
                }
                else
                {
                    label.Text = string.Concat(str2, " Days before");
                }
                AttributeCollection attributes = label.Attributes;
                string[] strArrays2 = new string[] { "javascript:addnew('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributes.Add("onclick", string.Concat(strArrays2));
                AttributeCollection attributeCollection = label3.Attributes;
                string[] strArrays3 = new string[] { "javascript:addnew('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributeCollection.Add("onclick", string.Concat(strArrays3));
            }
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                foreach (GridColumn column in this.RadGrid_ProductDate.MasterTableView.Columns)
                {
                    if (item[column.UniqueName].Text != "color")
                    {
                        continue;
                    }
                    item[column.UniqueName].Text = this.colorformat.ToString();
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid_ProductDate.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid_ProductDate.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void grdcolorSetting_OnItemDataBound_comp(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                string[] strArrays = this.hidoptionddlbind2.Value.ToString().Trim().Split(new char[] { '>' });
                if ((int)strArrays.Length > 1)
                {
                    strArrays[0].ToString();
                    string str = strArrays[1].ToString();
                    string str1 = strArrays[2].ToString();
                    DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlCompletionDate");
                    HtmlContainerControl htmlContainerControl = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                    TextBox textBox = (TextBox)e.Item.FindControl("tbDays2");
                    ((HiddenField)e.Item.FindControl("hdndivColor")).Value = str1;
                    dropDownList.Attributes.Add("onchange", string.Concat("javascript:setDays2(this,", textBox.ClientID, ");"));
                    if (str.ToLower() == "elapsed")
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "2";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() == "before")
                    {
                        dropDownList.SelectedValue = "1";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                    else if (str.ToLower() != "on same day")
                    {
                        dropDownList.SelectedValue = "0";
                        textBox.Enabled = true;
                        htmlContainerControl.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
                    }
                    else
                    {
                        textBox.Enabled = false;
                        dropDownList.SelectedValue = "3";
                        htmlContainerControl.Attributes.Add("style", string.Concat("background-color: ", str1, ";height: 20px; width: 30px; border: solid 1px gray;float: left;"));
                    }
                }
            }
            if (e.Item is GridEditableItem && e.Item.ItemIndex == -1)
            {
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlCompletionDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("tbDays2");
                dropDownList1.Attributes.Add("onchange", string.Concat("javascript:setDays2(this,", textBox1.ClientID, ");"));
                dropDownList1.SelectedValue = "0";
                textBox1.Text = "";
                textBox1.Enabled = true;
                HtmlContainerControl htmlContainerControl1 = (HtmlContainerControl)e.Item.FindControl("divColorDisploay");
                htmlContainerControl1.Attributes.Add("style", "background-color: #F2F2F2;height: 20px; width: 30px; border: solid 1px gray;float: left;");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbltxt2");
                this.hidoptionddlbind2.Value = label.Text.ToString();
                string[] strArrays1 = label.Text.ToString().Trim().Split(new char[] { '>' });
                string str2 = strArrays1[0].ToString();
                string str3 = strArrays1[1].ToString();
                string str4 = strArrays1[2].ToString();
                Label label1 = (Label)e.Item.FindControl("lblDisplayColor2");
                label1.Style.Add("background-color", str4.ToString());
                label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                Label label2 = (Label)e.Item.FindControl("lblID2");
                Label label3 = (Label)e.Item.FindControl("lnkeditcolor2");
                if (str3.ToLower() == "elapsed")
                {
                    this.hdnColorid3.Value = label2.Text;
                    this.hdnColoridElapsed2.Value = label2.Text.ToString();
                    this.hdnDaysElapsed2.Value = str2.ToString();
                    this.hdnColorElapsed2.Value = str4.ToString();
                    label.Text = "elapsed";
                }
                else if (str3.ToLower() != "before")
                {
                    this.hdnColoridOnSameDay2.Value = label2.Text.ToString();
                    this.hdnNoOfDays2.Value = str2.ToString();
                    this.hdnColorSameDay2.Value = str4.ToString();
                    label.Text = "on same day";
                }
                else
                {
                    label.Text = string.Concat(str2, " Days before");
                }
                AttributeCollection attributes = label.Attributes;
                string[] strArrays2 = new string[] { "javascript:addnew2('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributes.Add("onclick", string.Concat(strArrays2));
                AttributeCollection attributeCollection = label3.Attributes;
                string[] strArrays3 = new string[] { "javascript:addnew2('edit','", str3.ToString(), "','", str2.ToString(), "','", str4.ToString(), "','", label2.Text, "')" };
                attributeCollection.Add("onclick", string.Concat(strArrays3));
            }
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                foreach (GridColumn column in this.RadGrid_CompletionDate.MasterTableView.Columns)
                {
                    if (item[column.UniqueName].Text != "color")
                    {
                        continue;
                    }
                    item[column.UniqueName].Text = this.colorformat.ToString();
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid_ProductDate.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid_CompletionDate.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void GridBind()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("pc_settings_jobViewColor_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@DateType", "");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.grdcolorSetting.DataSource = dataSet;
        }

        public void GridBind_prod()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("pc_settings_jobViewColor_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@DateType", "Production");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.RadGrid_ProductDate.DataSource = dataSet;
        }

        public void GridBind_comp()
        {
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("pc_settings_jobViewColor_select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@DateType", "Completion");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.RadGrid_CompletionDate.DataSource = dataSet;
        }

        protected void gridcolorsetting_insert(object sender, GridCommandEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlDeliveryDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays");
            if (textBox.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            sqlCommand.Parameters.Add("@colorcode", this.hiddenid.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", " ");
            sqlCommand.ExecuteNonQuery();
            this.GridBind();
            this.grdcolorSetting.Rebind();
            if (this.hdnColorid1.Value == "0")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }


        protected void gridcolorsetting_insert_comp(object sender, GridCommandEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlCompletionDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays2");
            if (this.tbDays1.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            sqlCommand.Parameters.Add("@colorcode", this.hiddenid.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", "Completion");
            sqlCommand.ExecuteNonQuery();
            this.GridBind_comp();
            this.RadGrid_CompletionDate.Rebind();
            if (this.hdnColorid3.Value == "0")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }




        protected void gridcolorsetting_insert_prod(object sender, GridCommandEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", this.colorid);
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlProductionDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays1");
            if (this.tbDays1.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            sqlCommand.Parameters.Add("@colorcode", this.hiddenid.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", "Production");
            sqlCommand.ExecuteNonQuery();
            this.GridBind_prod();
            this.RadGrid_ProductDate.Rebind();
            if (this.hdnColorid2.Value == "0")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }

        protected void gridcolorsetting_update(object sender, GridCommandEventArgs e)
        {
            Label label = (Label)e.Item.FindControl("lblIdIneditmode");
            this.hdnColorid1.Value = label.Text;
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            if (label.Text == "0")
            {
                sqlCommand.Parameters.Add("@id", this.colorid);
            }
            else
            {
                sqlCommand.Parameters.Add("@id", Convert.ToInt32(label.Text));
            }
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlDeliveryDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays");
            if (textBox.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdndivColor");
            sqlCommand.Parameters.Add("@colorcode", hiddenField.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", " ");
            sqlCommand.ExecuteNonQuery();
            this.GridBind();
            this.grdcolorSetting.Rebind();
            if (label.Text == "0")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }

        protected void gridcolorsetting_update_prod(object sender, GridCommandEventArgs e)
        {
            Label label = (Label)e.Item.FindControl("lblIdIneditmode1");
            this.hdnColorid1.Value = label.Text;
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            if (label.Text == "0")
            {
                sqlCommand.Parameters.Add("@id", this.colorid);
            }
            else
            {
                sqlCommand.Parameters.Add("@id", Convert.ToInt32(label.Text));
            }
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlProductionDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays1");
            if (textBox.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdndivColor");
            sqlCommand.Parameters.Add("@colorcode", hiddenField.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", "Production");
            sqlCommand.ExecuteNonQuery();
            this.GridBind_prod();
            this.RadGrid_ProductDate.Rebind();
            if (label.Text == "0")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }

        protected void gridcolorsetting_update_comp(object sender, GridCommandEventArgs e)
        {
            Label label = (Label)e.Item.FindControl("lblIdIneditmode2");
            this.hdnColorid3.Value = label.Text;
            SqlCommand sqlCommand = new SqlCommand("PC_settings_jobViewColor_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            if (label.Text == "0")
            {
                sqlCommand.Parameters.Add("@id", this.colorid);
            }
            else
            {
                sqlCommand.Parameters.Add("@id", Convert.ToInt32(label.Text));
            }
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlCompletionDate");
            sqlCommand.Parameters.Add("@options", dropDownList.SelectedItem.Text);
            TextBox textBox = (TextBox)e.Item.FindControl("tbDays2");
            if (textBox.Text == null)
            {
                sqlCommand.Parameters.Add("@Days", SqlDbType.BigInt);
            }
            else
            {
                sqlCommand.Parameters.Add("@Days", textBox.Text);
            }
            //HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdndivColor");
            sqlCommand.Parameters.Add("@colorcode", hiddenid.Value);
            sqlCommand.Parameters.Add("@createdBy", this.UserID);
            sqlCommand.Parameters.Add("@createdOn", DateTime.Now);
            sqlCommand.Parameters.Add("@DateType", "Completion");
            sqlCommand.ExecuteNonQuery();
            this.GridBind_comp();
            this.RadGrid_CompletionDate.Rebind();
            if (label.Text == "0")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Color_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.hiddenid.Value = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hiddenid.Value = "";
              
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.colorformat = base.SpecialDecode(this.objLog.GetRegionalSettings(this.CompanyID, "colour"));
            this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("Settings_Job_View"), " ", this.colorformat);
            this.GridBind();
            this.GridBind_prod();
            this.GridBind_comp();
            this.SelectedDateType();
            bool isPostBack = base.IsPostBack;
            this.ddlDeliveryDate.Attributes.Add("onChange", "OntextChanged()");
            this.ddlCompletionDate.Attributes.Add("onChange", "OntextChanged2()");
            base.Title = this.objLanguage.convert(global.pageTitle(string.Concat("Job View ", this.colorformat), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Appearance_Customize_Job_View"), " ", this.colorformat.ToString()));
            this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Job_View"), " ", this.colorformat);
            this.grdcolorSetting.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
            this.RadGrid_ProductDate.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
            this.RadGrid_CompletionDate.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
        }

        public void SelectedDateType()
        {
            this.DateTypeSelected = EstimatesBasePage.settings_jobViewColor_SelectedDateType(this.CompanyID);
            if (this.DateTypeSelected == "Production")
            {
                this.Chk_ProductionColor1.Checked = true;
                return;
            }
            if (this.DateTypeSelected == "Delivery" || this.DateTypeSelected == "")
            {
                this.Chk_DeliveryColor.Checked = true;
            }
            if (this.DateTypeSelected == "Completion" || this.DateTypeSelected == "")
            {
                this.Chk_CompletionColor1.Checked = true;
            }
        }
    }
}