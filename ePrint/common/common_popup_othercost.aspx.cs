using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
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

namespace ePrint.common
{
    public partial class common_popup_othercost : BaseClass, IRequiresSessionState
    {

        public string type;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private Global gloobj = new Global();

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

        public common_popup_othercost()
        {
        }

        [WebMethod]
        public static string CalculateFormulaCost(string FormulaVals)
        {
            return (new MathParser()).Calculate(FormulaVals).ToString();
        }

        [WebMethod]
        public static string CalculateFormulaCost_ForOtherCost(string FormulaVals)
        {
            return (new MathParser()).Calculate_ForOtherCostFormulCalculation(FormulaVals).ToString();
        }

        [WebMethod]
        public static int FindOutNew(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.ReplaceSingleQuote(strArrays[1]);
            string str2 = baseClass.ReplaceSingleQuote(strArrays[2]);
            long num = Convert.ToInt64(strArrays[3]);
            InventoryBasePage inventoryBasePage = new InventoryBasePage();
            int num1 = inventoryBasePage.warehouse_inventoryduplicacy_check(Convert.ToInt32(str), str1, str2, num);
            return num1;
        }

        [WebMethod]
        public static string GetPaperHeightWidth(string val)
        {
            string[] strArrays = val.Split(new char[] { '&' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            DataTable dataTable = SettingsBasePage.settings_papersize_select(Convert.ToInt32(str), Convert.ToInt32(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Height"].ToString();
                empty1 = row["Width"].ToString();
            }
            return string.Concat(empty, "µ", empty1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pgName = "";
            try
            {
                this.type = base.Request.QueryString["type"].ToString();
            }
            catch
            {
            }
            if (this.type == null)
            {
                base.Response.Write("No type found");
            }
            else if (this.type == "othercost")
            {
                this.gloobj.setpagename(base.Request.Params["pg"].ToString().ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle("Other Cost", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/Item/othercost_selector_new.ascx");
                this.plhDiv.Controls.Add(userControl);
                return;
            }
        }

        [WebMethod]
        public static void RemoveAttachmentFile(string CompID, string AttachmentID)
        {
            EstimateBasePage.estimates_attachment_delete(Convert.ToInt32(CompID), Convert.ToInt64(AttachmentID));
        }

        private void usr2_name_command(string name, int id)
        {
            base.Response.Write(string.Concat(name, "<br/>", id));
            base.Response.End();
        }
    }
}