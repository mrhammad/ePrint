using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
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

namespace ePrint.usercontrol.Item
{
    public partial class supplier_addmore : UsercontrolBasePage
    {

        private Global gloobj = new Global();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long ParentEstimateItemID;

        public long EstimateItemID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Module = string.Empty;

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

        public supplier_addmore()
        {
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.hdnSupplierAddMore.Value = this.hdnSupplierAddMore.Value.Remove(this.hdnSupplierAddMore.Value.Length - 1);
            this.hdnSupplierAddMore.Value = this.hdnSupplierAddMore.Value.Substring(1);
            string[] strArrays = this.hdnSupplierAddMore.Value.Split(new char[] { '@' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].ToString().Split(new char[] { ';' });
                string str = strArrays1[0].ToString();
                string str1 = strArrays1[1].ToString();
                EstimatesBasePage.AddMore_Supplier(Convert.ToInt64(str), Convert.ToInt64(str1), this.EstimateItemID);
            }
            string empty = string.Empty;
            if (this.Module.ToLower() != "estimate")
            {
                object[] estimateID = new object[] { this.strSitepath, "orders/order_quotedetails_panel.aspx?estid=", this.EstimateID, "&estitemID=", this.EstimateItemID, "&Module=", this.Module };
                empty = string.Concat(estimateID);
            }
            else
            {
                object[] objArray = new object[] { this.strSitepath, "Estimates/estimate_quotedetails_panel.aspx?estid=", this.EstimateID, "&estitemID=", this.EstimateItemID, "&Module=", this.Module };
                empty = string.Concat(objArray);
            }
            base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", empty, "';</script>"));
        }

        protected void btnSaveAndPrint_OnClick(object sender, EventArgs e)
        {
            this.hdnSupplierAddMore.Value = this.hdnSupplierAddMore.Value.Remove(this.hdnSupplierAddMore.Value.Length - 1);
            this.hdnSupplierAddMore.Value = this.hdnSupplierAddMore.Value.Substring(1);
            string[] strArrays = this.hdnSupplierAddMore.Value.Split(new char[] { '@' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].ToString().Split(new char[] { ';' });
                string str = strArrays1[0].ToString();
                string str1 = strArrays1[1].ToString();
                EstimatesBasePage.AddMore_Supplier(Convert.ToInt64(str), Convert.ToInt64(str1), this.EstimateItemID);
            }
            string empty = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
            {
                empty = row["CustomerID"].ToString();
                empty1 = row["CompanyType"].ToString();
            }
            string empty2 = string.Empty;
            if (this.Module.ToLower() != "estimate")
            {
                object[] estimateID = new object[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", empty, "&sectionname=PrintBroker&type=", empty1, "&page=PrintBroker&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID };
                empty2 = string.Concat(estimateID);
            }
            else
            {
                object[] objArray = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", empty, "&sectionname=PrintBroker&type=", empty1, "&page=PrintBroker&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID };
                empty2 = string.Concat(objArray);
            }
            base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", empty2, "';</script>"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.Params["EstimateItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
            }
            if (base.Request.Params["Module"] != null)
            {
                this.Module = base.Request.Params["Module"];
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.btnSaveAndEmail.Visible = false;
        }
    }
}