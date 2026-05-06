using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using Printcenter.UI.Webstores;
using System.Data;

namespace ePrint.ProductCatalogue
{
    public partial class ProductCatalogueItem_Stock_Other : System.Web.UI.UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;
        
        public int CompanyID;

        public int UserID;
        
        public static languageClass objLanguage;

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string PageType = "productcatalogue";

        private BaseClass objbaseclass = new BaseClass();

        protected void btnStockOtherSave_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            char[] chrArray;
            string value2 = this.hdnOtherProductDetails.Value;
            chrArray = new char[] { 'µ' };
            string[] strArrays7 = value2.Split(chrArray);

            if (strArrays7[0] != "")
            {
                long num9 = (long)0;
                int num10 = 0;
                string str23 = strArrays7[0];
                chrArray = new char[] { '±' };
                string[] strArrays8 = str23.Split(chrArray);
                for (int n = 0; n < (int)strArrays8.Length; n++)
                {
                    string str24 = strArrays8[n];
                    chrArray = new char[] { '»' };
                    string[] strArrays9 = str24.Split(chrArray);
                    if (string.Compare(strArrays9[0], "kititemid", true) == 0)
                    {
                        if (strArrays9[1] != "")
                        {
                            num9 = Convert.ToInt64(strArrays9[1]);
                        }
                    }
                    else if (string.Compare(strArrays9[0], "unit", true) == 0)
                    {
                        num10 = Convert.ToInt32(strArrays9[1]);
                    }
                }
                WebstoreBasePage.pricecataloguestock_other_update(int.Parse(id),ProductCatalogueItem_Stock.ProductCatalogueID, num9, num10, this.UserID);
            }
            string str22 = WebstoreBasePage.pricecataloguestock_actiontype_check(int.Parse(id), "other");
            int num11 = this.objbaseclass.Check_MaxKit_Availability((long)ProductCatalogueItem_Stock.ProductCatalogueID, 0);
            WebstoreBasePage.pricecataloguestock_Quantity_Update((long)ProductCatalogueItem_Stock.ProductCatalogueID, num11, num11, 0);
            if (str22.ToLower() == "opening")
            {
                this.objbaseclass.StockAllocationManagementHistory_Save((long)0, (long)ProductCatalogueItem_Stock.ProductCatalogueID, str22, "Opening stock Added", num11, 0, 0, 0, (long)this.UserID, (long)0);
            }
            else if (str22.ToLower() == "added")
            {
                this.objbaseclass.StockAllocationManagementHistory_Save((long)0, (long)ProductCatalogueItem_Stock.ProductCatalogueID, str22, "Stock Added Manually", num11, 0, 0, 0, (long)this.UserID, (long)0);
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "closeAndRedirect("+ProductCatalogueItem_Stock.ProductCatalogueID+");", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string kitItemID = Request.QueryString["kitItemID"];
            string itemCode = Request.QueryString["itemCode"];
            string itemTitle = Request.QueryString["itemTitle"];
            string qty = Request.QueryString["qty"];
            this.CompanyID = int.Parse(Request.QueryString["companyID"]);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table id='tblother-edit' style='width:100%;border-collapse:collapse;' cellpadding='3px' cellspacing='3px' border='0px' >");
            stringBuilder.Append("<tr  style='width:100%;background-color: #DDDDDD;'>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Code<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 11%;' align='left'>");
            stringBuilder.Append("<span>Item Title<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='left'>");
            stringBuilder.Append("<span>Stock to be adjusted against 1 unit<span>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            object[] objArray = new object[] { "<tr style='width:100%;background-color:#EFEFEF;'>" };
            stringBuilder.Append(string.Concat(objArray));
            stringBuilder.Append("<td style='width: 10%;' align='left'>");
            object[] item = new object[] { "<input  id='txtitemcode-edit' type='text' style='width:253px;text-align:left' value='", itemCode , "' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID-edit','txtitemtitle-edit','Products','", this.CompanyID, "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID-edit','txtitemtitle-edit','Products','", this.CompanyID, "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle-edit');  class='textboxnew' />" };
            stringBuilder.Append(string.Concat(item));
            object[] item1 = new object[] { "<input type='hidden' id='hdnOtherKitItemID-edit' value='", kitItemID , "' />" };
            stringBuilder.Append(string.Concat(item1));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 18%;' align='left'>");
            object[] objArray1 = new object[] { "<input id='txtitemtitle-edit' type='text' style='width:365px;text-align:left' value='", itemTitle , "'  class='textboxnew' />" };
            stringBuilder.Append(string.Concat(objArray1));
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td style='width: 4%;' align='left'>");
            object[] item2 = new object[] { "<input type='text' style='width:75px;text-align:right' id='txtunit-edit'  onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'   value='", qty , "' class='textboxnew' />" };
            stringBuilder.Append(string.Concat(item2));
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            stringBuilder.Append("</table>");
            this.plhotherproducts.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }
    }
}