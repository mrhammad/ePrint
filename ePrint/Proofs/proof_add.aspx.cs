using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Estimates;

namespace ePrint.Proofs
{
    public partial class proof_add : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public string EstimateType = string.Empty;

        private Global gloobj = new Global();

        public string newdate = string.Empty;

        public string DateFormat = string.Empty;
        public long ProofID;
        public bool HasValue(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (o == DBNull.Value)
            {
                return false;
            }
            if (o is string && ((string)o).Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("estimates", "isadd", "");
            global.pageName = "proof";
            global.pgName = "";
            this.pg = "proof";
            this.gloobj.setpagename("proof");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            languageClass _languageClass = new languageClass();
            this.DateFormat = this.Session["DateFormat"].ToString();
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Estimates/Proofs.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Proof_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Estimate_Add")));
            base.Title = _languageClass.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!this.HasValue(base.Request.Params["type"]))
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "Estimates/Proofs.aspx"));
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    EstimateBasePage.etimates_tempattachment_delete(this.CompanyID, this.UserID);
                }
                if (base.Request.Params["type"].ToLower().Trim() == "edit")
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    this.ProofID = Convert.ToInt64(base.Request.Params["proofid"]);

                    object[] estimateID = new object[] { "<a href='", this.strSitepath, "Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=0&ProofID="+this.ProofID+"' class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Proof_Summary"), "</a>&nbsp;>&nbsp", _languageClass.GetLanguageConversion("Proof_Add") };
                    string str = string.Concat(estimateID);
                    if (base.Request.Params["prev"] != null && base.Request.Params["prev"].ToLower().Trim() == "y")
                    {
                        str = _languageClass.GetLanguageConversion("Proof_Add");
                    }
                    base.Navigation_Path(string.Concat("<a href=../Estimates/Proofs.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Proof_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", str, _languageClass.GetLanguageConversion("Estimate_Edit")));
                    base.Title = _languageClass.convert(global.pageTitle("Estimate Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    if (!this.HasValue(base.Request.Params["estid"]))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
                    }
                    if (base.Request.Params["EstItemID"] != null)
                    {
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
                        this.EstimateType = base.Request.Params["esttype"].ToString();
                    }
                    if (!base.ValidatePageURL(this.CompanyID, "estimate", this.EstimateID, this.EstimateItemID, this.EstimateType, "edit"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "Estimates/Proofs.aspx"));
                    }
                }
            }
        }

    }
}