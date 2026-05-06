using nmsCommon;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;

namespace ePrint
{


    [ScriptService]
    [WebService(Namespace = "http://www.eprintsoftware.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class press_select : WebService
    {
        public press_select()
        {
        }

        [WebMethod]
        public void AccountCode_Update_InSummary(int CompanyID, long EstimateItemID, string EstimateType, int AccountCodeID)
        {
            EstimatesBasePage.AccountCode_Update_InSummary(CompanyID, EstimateItemID, EstimateType, AccountCodeID);
        }

        [WebMethod]
        public void Update_EstimateItems_SortingOrder(string EstimateItemID, string SortingOrderId, string  pageName)
        {
            EstimatesBasePage.Update_EstimateItems_SortingOrder(Convert.ToInt64(EstimateItemID),Convert.ToInt32(SortingOrderId), pageName);
        }

        [WebMethod]
        public string DeliveryQty_Update(int CompanyID, long DeliveryID, long DeliveryItemID, long EstimateItemID, string EstimateType, long DeliveryAddressID, string DeliveryAddressType, int Quantity)
        {
            JobsBasePage.Job_DeliveryNote_DeliveryQty_Update(CompanyID, DeliveryID, DeliveryItemID, EstimateItemID, EstimateType, DeliveryAddressID, DeliveryAddressType, Quantity);
            return DeliveryItemID.ToString();
        }

        [WebMethod]
        public string estimate_select_litho_ink_count(string id)
        {
            string[] strArrays = new string[] { "±" };
            string[] strArrays1 = id.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            DataTable dataTable = EstimatesBasePage.estimate_select_litho_ink_count(Convert.ToInt32(strArrays1[0].ToString()), Convert.ToInt32(strArrays1[1].ToString()));
            return dataTable.Rows[0][0].ToString();
        }

        [WebMethod]
        public string GetClientAddress_Delivery(string val)
        {
            string empty = string.Empty;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            string[] strArrays = val.Split(new char[] { '±' });
            DataTable dataTable = CompanyBasePage.company_client_alladdress_select_clientname(Convert.ToInt32(strArrays[0].ToString()), Convert.ToInt32(strArrays[1].ToString()), strArrays[2].ToString());
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            return VuMgr.RenderView("~/UserControl/AutoFill/Splitdelivery.ascx", dataSet);
        }

        [WebMethod]
        public string GetEditedTemplateName(string PDFKey)
        {
            string empty = string.Empty;
            return SettingsBasePage.settings_template_emailed_select(PDFKey);
        }

        [WebMethod]
        public string GetNotes(int CompanyID, int AttachmentID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_attachment_detail", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@attachmentid", AttachmentID);
            sqlCommand.Parameters.AddWithValue("@companyid", CompanyID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                empty = string.Concat(sqlDataReader["subject"].ToString(), "µ");
                str = string.Concat(sqlDataReader["filename"].ToString(), "µ");
                str1 = sqlDataReader["title"].ToString();
                empty1 = string.Concat(empty, str, str1);
            }
            _commonClass.closeConnection();
            return empty1;
        }

        [WebMethod]
        public string GetWarehouse_Details(int CompanyID, long EstimateItemID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            foreach (DataRow row in JobsBasePage.jobs_deliverynote_warehouse_details_select(CompanyID, EstimateItemID).Rows)
            {
                empty = row["EstimateType"].ToString();
                num = Convert.ToInt32(row["Quantity"]);
                if (empty != "W")
                {
                    str = (empty == "U" ? string.Concat(row["EstimateType"].ToString(), "µ0") : string.Concat(row["EstimateType"].ToString(), "µ", num));
                }
                else
                {
                    object[] objArray = new object[] { row["EstimateType"].ToString(), "µ", row["InventoryCode"].ToString(), "±", row["Description"].ToString(), "±", row["InventoryName"].ToString(), "±", num, "±", row["Location"].ToString() };
                    str = string.Concat(objArray);
                }
            }
            return str;
        }

        [WebMethod]
        public string Litho_press_select(string id)
        {
            string[] strArrays = new string[] { "±" };
            string[] strArrays1 = id.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            DataTable dataTable = EstimatesBasePage.estimate_select_litho_details_all(Convert.ToInt32(strArrays1[0].ToString()), Convert.ToInt32(strArrays1[1].ToString()));
            return dataTable.Rows[0][0].ToString();
        }

        [WebMethod]
        public void update_multiple_product_categories(long PriceCatalogueID, int PriceCatalogueCategoryID_2, int PriceCatalogueCategoryID_3, int PriceCatalogueCategoryID_4, int PriceCatalogueCategoryID_5, int PriceCatalogueCategoryID_6)
        {
            EstimatesBasePage.update_multiple_product_categories(PriceCatalogueID, PriceCatalogueCategoryID_2, PriceCatalogueCategoryID_3, PriceCatalogueCategoryID_4, PriceCatalogueCategoryID_5, PriceCatalogueCategoryID_6);
        }
    }
}