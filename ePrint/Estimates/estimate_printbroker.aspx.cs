using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ePrint.Estimates
{
    public partial class estimate_printbroker : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_Item_item_printbroker_new divprintbroker;

        //protected CheckBox chkPBItemTitle;

        //protected TextBox txt_lblPBItemTitle;

        //protected ImageButton ImageButton36;

        //protected HiddenField hdn_lblPBItemTitle;

        //protected TextBox txtPBItemTitle;

        //protected CheckBox chk_Outwork_Phrase_ItemTitle;

        //protected CheckBox chkPBDescription;

        //protected TextBox txt_lblPBDescription;

        //protected ImageButton ImageButton37;

        //protected HiddenField hdn_lblPBDescription;

        //protected TextBox txtPBDesign;

        //protected CheckBox chk_Outwork_Phrase_Design;

        //protected CheckBox chkPBArtwork;

        //protected TextBox txt_lblPBArtwork;

        //protected ImageButton ImageButton38;

        //protected HiddenField hdn_lblPBArtwork;

        //protected TextBox txtPBArtwork;

        //protected CheckBox chk_Outwork_Phrase_Artwork;

        //protected CheckBox chkPBColour;

        //protected TextBox txt_lblPBColour;

        //protected ImageButton ImageButton39;

        //protected HiddenField hdn_lblPBColour;

        //protected TextBox txtPBColour;

        //protected CheckBox chk_Outwork_Phrase_Colour;

        //protected CheckBox chkPBSize;

        //protected TextBox txt_lblPBSize;

        //protected ImageButton ImageButton40;

        //protected HiddenField hdn_lblPBSize;

        //protected TextBox txtPBSize;

        //protected CheckBox chk_Outwork_Phrase_Size;

        //protected CheckBox chkPBMaterials;

        //protected TextBox txt_lblPBMaterials;

        //protected ImageButton ImageButton41;

        //protected HiddenField hdn_lblPBMaterials;

        //protected TextBox txtPBMaterials;

        //protected CheckBox chk_Outwork_Phrase_Material;

        //protected CheckBox chkPBDelivery;

        //protected TextBox txt_lblPBDelivery;

        //protected ImageButton ImageButton42;

        //protected HiddenField hdn_lblPBDelivery;

        //protected TextBox txtPBDelivery;

        //protected CheckBox chk_Outwork_Phrase_Delivery;

        //protected CheckBox chkPBFinishing;

        //protected TextBox txt_lblPBFinishing;

        //protected ImageButton ImageButton43;

        //protected HiddenField hdn_lblPBFinishing;

        //protected TextBox txtPBFinishing;

        //protected CheckBox chk_Outwork_Phrase_Finishing;

        //protected CheckBox chkPBNotes;

        //protected TextBox txt_lblPBNotes;

        //protected ImageButton ImageButton44;

        //protected HiddenField hdn_lblPBNotes;

        //protected TextBox txtPBNotes;

        //protected CheckBox chk_Outwork_Phrase_Notes;

        //protected CheckBox chkPBInstructions;

        //protected TextBox txt_lblPBInstructions;

        //protected ImageButton ImageButton68;

        //protected HiddenField hdn_lblPBInstructions;

        //protected TextBox txtPBInstructions;

        //protected CheckBox chk_Outwork_Phrase_Instructions;

        //protected HiddenField hdn_OutworkDesc;

        //protected TextBox txtItemTitle;

        //protected HiddenField hid_Estimate_Type;

        //protected HiddenField hid_single_outworkData;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public long EstSingleItemID;

        public long EstPadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        private Global gloobj = new Global();

        public string FromSummary = string.Empty;

        public int IsItemCompleted;

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

        public estimate_printbroker()
        {
        }

        [WebMethod]
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
        }

        [WebMethod]
        public static string GetSuppliers_List(string StrCompanyID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.supplier_select_in_printbroker(Convert.ToInt32(StrCompanyID));
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("estimate");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            try
            {
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
                if (base.Request.QueryString["estitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
                }
            }
            catch
            {
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                if (base.Request.QueryString["esttype"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                    this.Select_OutWork_Item();
                }
                string empty = string.Empty;
                foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                {
                    this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                }
                if (this.FromSummary == "sum" || this.QueryType == "edit")
                {
                    object[] estimateID = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                    empty = string.Concat(estimateID);
                }
                if (this.IsItemCompleted == 1)
                {
                    string[] languageConversion = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Edit_Outwork")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Estimate Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else if (this.IsItemCompleted == 0)
                {
                    base.Navigation_Path(string.Concat("<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Outwork")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
            }
            if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
            {
                string str = string.Empty;
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                    {
                        object[] objArray = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                        str = string.Concat(objArray);
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Outwork")));
                    }
                }
                else if (base.Request.Params["maintype"] != "edit")
                {
                    string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", str };
                    base.Navigation_Path(string.Concat(languageConversion1), this.objLanguage.GetLanguageConversion("Estimate_Add_Outwork"));
                }
                else
                {
                    object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                    str = string.Concat(estimateID1);
                    string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", str };
                    base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Outwork")));
                }
                base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
        }

        private void Select_OutWork_Item()
        {
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            if (this.EstimateItemID != (long)0)
            {
                string str = EstimateBasePage.Estimate_Outwork_By_ID(this.CompanyID, this.EstimateItemID);
                this.hid_single_outworkData.Value = string.Concat(str, "µ");
            }
        }
    }
}