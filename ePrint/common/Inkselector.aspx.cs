using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class Inkselector : System.Web.UI.Page
    {
        private Global gloobj = new Global();

        public int CompanyID;

        public int cnt = 1;

        public int Pressid;

        public long estitemid;

        public string type = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = string.Empty;

        public string Side = string.Empty;

        public string side1values = string.Empty;

        public string side2values = string.Empty;

        public string ddlval = string.Empty;

        public static long EstimateLithoNCRItemID;

        public static long EstimateLithobookletItemID;

        public string InkType = string.Empty;

        public static int Section;

        private BaseClass objBase = new BaseClass();

        private string SectionName = string.Empty;

        private string InkID = string.Empty;

        private string InkName = string.Empty;

        private string InkCoverage = string.Empty;

        private string SidesPrinted = string.Empty;

        public static string Esttype;

        public static string sidenumber;

        public static string Pgtype;

        public static string PressChangeVal;

        public string LithoTypeID = "0";

        public languageClass objLanguage = new languageClass();

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

        static Inkselector()
        {
            Inkselector.EstimateLithoNCRItemID = (long)0;
            Inkselector.EstimateLithobookletItemID = (long)0;
            Inkselector.Section = 0;
            Inkselector.Esttype = string.Empty;
            Inkselector.sidenumber = string.Empty;
            Inkselector.Pgtype = string.Empty;
            Inkselector.PressChangeVal = string.Empty;
        }

        public Inkselector()
        {
        }

        public void btnSave_onclick(object sender, EventArgs e)
        {
            this.Getinks();
        }

        public void Getinks()
        {
            string str;
            DataTable dataTable = new DataTable();
            if (this.Session["dtinks"] != null)
            {
                dataTable = (DataTable)this.Session["dtinks"];
            }
            else
            {
                dataTable.Columns.Add("SectionName", typeof(string));
                dataTable.Columns.Add("InkID", typeof(string));
                dataTable.Columns.Add("InkCoverage", typeof(string));
                dataTable.Columns.Add("SidesPrinted", typeof(string));
                dataTable.Columns.Add("sidenumber", typeof(string));
                dataTable.Columns.Add("InkName", typeof(string));
                if (Inkselector.Esttype == "K")
                {
                    dataTable.Columns.Add("LithoTypeID", typeof(string));
                }
                dataTable.Columns.Add("InkCostExMarkup1", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup2", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup3", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup4", typeof(string));
                dataTable.Columns.Add("InkMarkup1", typeof(string));
                dataTable.Columns.Add("InkMarkup2", typeof(string));
                dataTable.Columns.Add("InkMarkup3", typeof(string));
                dataTable.Columns.Add("InkMarkup4", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice1", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice2", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice3", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice4", typeof(string));
                dataTable.Columns.Add("InkSetupCharge", typeof(string));
                dataTable.Columns.Add("InkMinimumCharge", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual1", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual2", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual3", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual4", typeof(string));
            }
            if (this.hdn_Save.Value != "")
            {
                string value = this.hdn_Save.Value;
                char[] chrArray = new char[] { '~' };
                this.SectionName = value.Split(chrArray)[0];
                string value1 = this.hdn_Save.Value;
                char[] chrArray1 = new char[] { '~' };
                this.InkID = value1.Split(chrArray1)[1];
                string str1 = this.hdn_Save.Value;
                char[] chrArray2 = new char[] { '~' };
                this.InkCoverage = str1.Split(chrArray2)[2];
                string value2 = this.hdn_Save.Value;
                char[] chrArray3 = new char[] { '~' };
                this.SidesPrinted = value2.Split(chrArray3)[3];
                string str2 = this.hdn_Save.Value;
                char[] chrArray4 = new char[] { '~' };
                Inkselector.sidenumber = str2.Split(chrArray4)[4];
                string value3 = this.hdn_Save.Value;
                char[] chrArray5 = new char[] { '~' };
                this.InkName = value3.Split(chrArray5)[5];
            }
            string str3 = "New";
            if (Inkselector.Esttype != "K")
            {
                string[] sectionName = new string[] { "SectionName='", this.SectionName, "' and sidenumber='", Inkselector.sidenumber, "'" };
                DataRow[] dataRowArray = dataTable.Select(string.Concat(sectionName));
                if ((int)dataRowArray.Length > 0)
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                }
                string[] strArrays = this.InkCoverage.Split(new char[] { '±' });
                string str4 = "";
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    str4 = string.Concat(str4, "0±");
                }
                object[] objArray = new object[] { this.SectionName, this.InkID, this.InkCoverage, this.SidesPrinted, Inkselector.sidenumber, this.objBase.SpecialEncode(this.InkName), str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4, str4 };
                dataTable.Rows.Add(objArray);
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!(this.LithoTypeID == row["LithoTypeID"].ToString()) || !(this.LithoTypeID != "0"))
                    {
                        continue;
                    }
                    str3 = "Old";
                }
                str = (str3 != "New" ? string.Concat("LithoTypeID='", this.LithoTypeID, "'") : string.Concat("SectionName='", this.SectionName, "'"));
                DataRow[] dataRowArray1 = dataTable.Select(string.Concat(str, " and sidenumber='", Inkselector.sidenumber, "'"));
                if ((int)dataRowArray1.Length > 0)
                {
                    dataTable.Rows.Remove(dataRowArray1[0]);
                }
                string[] strArrays1 = this.InkCoverage.Split(new char[] { '±' });
                string str5 = "";
                for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                {
                    str5 = string.Concat(str5, "0±");
                }
                object[] sectionName1 = new object[] { this.SectionName, this.InkID, this.InkCoverage, this.SidesPrinted, Inkselector.sidenumber, this.objBase.SpecialEncode(this.InkName), this.LithoTypeID, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5, str5 };
                dataTable.Rows.Add(sectionName1);
            }
            if (this.type.ToLower().Trim() == "edit")
            {
                SettingsBasePage.CheckInksWhileRerun(this.CompanyID, this.estitemid, Inkselector.EstimateLithoNCRItemID, Inkselector.EstimateLithobookletItemID, Inkselector.sidenumber);
            }
            this.Session["dtinks"] = dataTable;
            this.pnlClose.Visible = true;
        }

        public void Onclick_AddNewInk(object sender, EventArgs e)
        {
            this.Add_NewInkID.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Ink Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.strImagepath = global.imagePath();
            this.gloobj.setpagename("estimate");
            if (base.Request.Params["Section"] != null)
            {
                Inkselector.Section = Convert.ToInt32(base.Request.Params["Section"]);
            }
            if (base.Request.Params["cnt"] != null)
            {
                this.cnt = Convert.ToInt32(base.Request.Params["cnt"]);
            }
            if (base.Request.Params["id"] != null)
            {
                this.Pressid = Convert.ToInt32(base.Request.Params["id"]);
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            if (base.Request.Params["estitemid"] != null)
            {
                this.estitemid = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (base.Request.Params["Side"] != null)
            {
                this.Side = base.Request.Params["Side"].ToString();
            }
            if (base.Request.Params["ddlval"] != null)
            {
                this.ddlval = base.Request.Params["ddlval"].ToString();
            }
            if (base.Request.Params["EstimateLithoNCRItemID"] != null)
            {
                Inkselector.EstimateLithoNCRItemID = Convert.ToInt64(base.Request.Params["EstimateLithoNCRItemID"].ToString());
            }
            if (base.Request.Params["EstimateLithobookletItemID"] != null)
            {
                Inkselector.EstimateLithobookletItemID = Convert.ToInt64(base.Request.Params["EstimateLithobookletItemID"].ToString());
                this.LithoTypeID = base.Request.Params["EstimateLithobookletItemID"].ToString();
            }
            if (base.Request.Params["Esttype"] != null)
            {
                Inkselector.Esttype = base.Request.Params["Esttype"].ToString();
            }
            if (base.Request.Params["sidenumber"] != null)
            {
                Inkselector.sidenumber = base.Request.Params["sidenumber"].ToString();
            }
            if (base.Request.Params["PressChangeVal"] != null)
            {
                Inkselector.PressChangeVal = base.Request.Params["PressChangeVal"].ToString();
            }
            if (!base.IsPostBack)
            {
                this.btnAddInk.Text = this.objLanguage.GetLanguageConversion("Add_New_Ink");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
                if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString() == "yes")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Item_Added_Successfully"), "successfulMsg", this.plhMessage);
                }
            }
            foreach (DataRow row in InventoryBasePage.warehouse_inventory_selectink_withinktype(this.CompanyID, (long)this.Pressid).Rows)
            {
                this.InkType = Convert.ToString(row["InkType"]);
            }
            this.plhink.Controls.Add(new LiteralControl("<div style='float:left;width:468px;border:solid 0px blue'>"));
            if (this.InkType.ToLower() != "m")
            {
                this.plhink.Controls.Add(new LiteralControl(string.Concat("<div style='float:right' class='HeaderText'>", this.objLanguage.GetLanguageConversion("Coverage"), "</div>")));
            }
            this.plhink.Controls.Add(new LiteralControl("</div><div style='clear:both'></div>"));
            this.plhink.Controls.Add(new LiteralControl("<table align='left' cellpadding='0px' cellspacing='0px' border='0' height='100%' width='100%' nowrap='nowrap'>"));
            this.plhink.Controls.Add(new LiteralControl("<tr valign='middle'>"));
            this.plhink.Controls.Add(new LiteralControl("<td>"));
            this.plhink.Controls.Add(new LiteralControl("<div id='padding'>"));
            try
            {
                for (int i = 1; i <= this.cnt; i++)
                {
                    ControlCollection controls = this.plhink.Controls;
                    object[] languageConversion = new object[] { "<div style='float:left;width:175px' class='bglabel'><asp:Label ID='lbl_", i, "' runat='server' >", this.objLanguage.GetLanguageConversion("Ink"), i, "</asp:Label>" };
                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                    if (i == 1)
                    {
                        this.plhink.Controls.Add(new LiteralControl("<span style='color:red'>*</span>"));
                    }
                    this.plhink.Controls.Add(new LiteralControl("</div>"));
                    this.plhink.Controls.Add(new LiteralControl("<div style='float:left;padding-left:5px'>"));
                    TextBox textBox = new TextBox();
                    TextBox str = new TextBox()
                    {
                        Width = 200,
                        CssClass = "textboxnew"
                    };
                    AttributeCollection attributes = str.Attributes;
                    object[] inkType = new object[] { "javascript:displayInks(this,'inks','", this.InkType, "','", this.CompanyID, "','", i, "','1',event);TosetCount('", i, "');" };
                    attributes.Add("onkeyup", string.Concat(inkType));
                    AttributeCollection attributeCollection = str.Attributes;
                    object[] objArray = new object[] { "javascript:displayInks(this,'inks','", this.InkType, "','", this.CompanyID, "','", i, "','1',event);TosetCount('", i, "');" };
                    attributeCollection.Add("onclick", string.Concat(objArray));
                    str.ID = string.Concat("txtInkName_", i);
                    str.AutoCompleteType = AutoCompleteType.Disabled;
                    str.Attributes.Add("autocomplete", "off");
                    this.plhink.Controls.Add(str);
                    Label label = new Label()
                    {
                        ID = string.Concat("lblInkID_", i)
                    };
                    this.plhink.Controls.Add(label);
                    Label label1 = new Label()
                    {
                        ID = string.Concat("lblInkName_", i)
                    };
                    this.plhink.Controls.Add(label1);
                    this.plhink.Controls.Add(new LiteralControl(string.Concat("<span id='spntext_", i, "' class='spanerrorMsg spanerrorMsg_border' style='float:left;padding-left:5px;display: none;width: 120px'>Please select Ink</span>")));
                    InventoryBasePage.Litho_Bind_Inkname_popup(str, label, this.CompanyID, "--- Select ---", i, this.Pressid, this.type, this.estitemid, this.Side, Inkselector.EstimateLithoNCRItemID, Inkselector.EstimateLithobookletItemID, this.InkType, Inkselector.sidenumber, Inkselector.PressChangeVal, Inkselector.Esttype);
                    textBox.Width = 50;
                    textBox.CssClass = "normaltext";
                    textBox.Attributes.Add("onblur", "AllowNumber(this,this.value);AmountTo2Decimal(this,this.value);");
                    textBox.ID = string.Concat("txtbx_", i);
                    InventoryBasePage.Litho_Bind_coverage_popup(textBox, this.CompanyID, i, this.Pressid, this.type, this.estitemid, this.Side, Inkselector.EstimateLithoNCRItemID, Inkselector.EstimateLithobookletItemID, Inkselector.sidenumber, Inkselector.PressChangeVal, Inkselector.Esttype);
                    if (this.Session["dtinks"] != null)
                    {
                        DataTable item = (DataTable)this.Session["dtinks"];
                        object[] section = new object[] { "SectionName='Parts", Inkselector.Section, "'  and sidenumber='", Inkselector.sidenumber, "'" };
                        DataRow[] dataRowArray = item.Select(string.Concat(section));
                        if ((int)dataRowArray.Length > 0)
                        {
                            string[] strArrays = dataRowArray[0]["InkID"].ToString().Split(new char[] { '±' });
                            string[] strArrays1 = dataRowArray[0]["InkCoverage"].ToString().Split(new char[] { '±' });
                            string[] strArrays2 = dataRowArray[0]["InkName"].ToString().Split(new char[] { '±' });
                            if ((int)strArrays.Length > i - 1)
                            {
                                label.Text = strArrays[i - 1].ToString();
                                textBox.Text = strArrays1[i - 1].ToString();
                                str.Text = strArrays2[i - 1].ToString();
                            }
                        }
                    }
                    this.plhink.Controls.Add(new LiteralControl("</div><div style='float:left;padding-left:10px;'>"));
                    if (this.InkType.ToLower() != "m")
                    {
                        this.plhink.Controls.Add(textBox);
                        this.plhink.Controls.Add(new LiteralControl("&nbsp;%</div><div style='clear:both'></div>"));
                    }
                    else
                    {
                        this.plhink.Controls.Add(new LiteralControl("</div><div style='clear:both'></div>"));
                    }
                }
            }
            catch
            {
            }
            this.plhink.Controls.Add(new LiteralControl("</div>"));
            this.plhink.Controls.Add(new LiteralControl("</td>"));
            this.plhink.Controls.Add(new LiteralControl("</tr>"));
            this.plhink.Controls.Add(new LiteralControl("</table>"));
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).ToLower() == "false")
            {
                this.btnAddInk.Visible = false;
                return;
            }
            this.btnAddInk.Visible = true;
        }
    }
}