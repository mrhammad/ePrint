using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Xls;
using Spire.Xls.Collections;
using Spire.Xls.Core.Spreadsheet;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System.Data.Common;
using System.Configuration;
using Printcenter.UI.Webstores;
using Printcenter.UI.Jobs;

namespace ePrint.settings
{
    public partial class StockScanning : BaseClass, IRequiresSessionState
    {



        private Global gloobj = new Global();

        private SettingsBasePage objSet = new SettingsBasePage();
        private languageClass objLanguage = new languageClass();
        private BaseClass objBaseClass = new BaseClass();
        public int UserID;
        public int CompanyID;
        public string ActualFileName;
        public string SystemName = string.Empty;
        Hashtable hs = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.gloobj.setpagename("setting");
            this.header_mis.SettingName = "Stock Scanning";
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_new(this.ddlJobComplete, this.CompanyID, "Select Job Status", "job");
                this.objSet.Bind_Status_new(this.ddlJobPartial, this.CompanyID, "Select Job Status", "job");
                this.objSet.Bind_Status_new(this.ddlPartialItem, this.CompanyID, "Select Job Status", "job");
                this.objSet.Bind_Status_new(this.ddlPOComplete, this.CompanyID, "Select PO Status", "purchase");
                this.objSet.Bind_Status_new(this.ddlPOPartial, this.CompanyID, "Select PO Status", "purchase");
                getStockSettingDetails();
            }
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();

            this.SystemName = ConnectionClass.ServerName;
            this.UserID = Convert.ToInt32(this.Session["UserID"]);


        }
        DataTable ReadSaveCSVFile(FileType Stocktype)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString().Substring(0, 10);
            string fileName = "";
            if ((int)Stocktype == 0)
                fileName = this.fileReplineshStock.FileName;
            else if ((int)Stocktype == 1)
                fileName = this.fileDeductStock.FileName;
            else
                fileName = this.fileStockAdd.FileName;
            this.ActualFileName = fileName;
            string[] strArrays = fileName.Split(new char[] { '\\' });
            string str1 = strArrays[(int)strArrays.Length - 1];
            string.Concat("Import/", strArrays[(int)strArrays.Length - 1]);

            if (!Directory.Exists(base.Server.MapPath("./Import/")))
            {
                Directory.CreateDirectory(base.Server.MapPath("./Import/"));
            }
            if (!Directory.Exists(string.Concat(base.Server.MapPath("./Import/"), this.SystemName)))
            {
                Directory.CreateDirectory(string.Concat(base.Server.MapPath("./Import/"), this.SystemName));
                string[] strArrays1 = new string[] { base.Server.MapPath("./Import/"), this.SystemName, "\\", str, str1 };
                string str2 = string.Concat(strArrays1);
                if (!File.Exists(str2))
                {
                    if ((int)Stocktype == 0)
                        this.fileReplineshStock.SaveAs(str2);
                    else if ((int)Stocktype == 0)
                        this.fileDeductStock.SaveAs(str2);
                    else
                        this.fileStockAdd.SaveAs(str2);
                    fileName = string.Concat(str, str1);
                }
            }
            string[] strArrays2 = new string[] { base.Server.MapPath("./Import/"), this.SystemName, "\\", str, str1 };
            string str3 = string.Concat(strArrays2);
            if (!File.Exists(str3))
            {
                if ((int)Stocktype == 0)
                    this.fileReplineshStock.SaveAs(str3);
                else if ((int)Stocktype == 1)
                    this.fileDeductStock.SaveAs(str3);
                else
                    this.fileStockAdd.SaveAs(str3);
                fileName = string.Concat(str, str1);
            }
            var ds = ConnectFile(fileName, str3);
            return ds.Tables[0];
        }

        protected void btnReplineshImport_Click(object sender, EventArgs e)
       {

            var dt1 = ReadSaveCSVFile(FileType.StockReplinesh);
            item_summary item_summary = new item_summary();
            string Itemcode = "";
            Int32 Qty = 0;
            string PONO = "";
            string Location = "";
            string Customfield1 = "";
            string Customfield2 = "";
            string Customfield3 = "";
            string Customfield4 = "";
            string Customfield5 = "";
            string Customfield6 = "";
            int Openingstock = 0;
            DateTime DateTime = DateTime.Now;
            string empty = string.Empty;

            Int32 POCompleteStatusId = 0;
            Int32 POPartialStatusId = 0;
            Int32 StatusId = 0;
            if (this.ddlPOComplete.SelectedIndex != -1)
            {
                POCompleteStatusId = Convert.ToInt32(this.ddlPOComplete.SelectedItem.Value);
            }
            if (this.ddlPOPartial.SelectedIndex != -1)
            {
                POPartialStatusId = Convert.ToInt32(this.ddlPOPartial.SelectedItem.Value);
            }

            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr[0].ToString().Trim() != null)
                    {
                        Itemcode = dr[0].ToString().Trim();
                    }
                    if (dr[2].ToString().Trim() != null)
                    {
                        PONO = dr[2].ToString().Trim();
                    }
                    if (dr[3].ToString().Trim() != null)
                    {
                        Location = dr[3].ToString().Trim();
                    }
                    if (dr[1].ToString().Trim() != null)
                    {
                        Openingstock = Convert.ToInt32(dr[1].ToString().Trim());
                    }
                    //if (dr[9].ToString().Trim() != null)
                    if (dr[9].ToString().Trim() != null && dr[9].ToString().Trim() != "")
                    {
                        DateTime = Convert.ToDateTime(dr[9].ToString().Trim());
                    }
                    Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                    DataTable dataTable = new DataTable();
                    DbCommand storedProcCommand = database.GetSqlStringCommand(" SELECT tb_Purchase.PurchaseID,Jobid,tb_PurchaseItem.PurchaseItemID, tb_PurchaseItem.WarehouseItemID, tb_PurchaseItem.ItemCode, tb_PurchaseItem.Qty, tb_PurchaseItem.Price, tb_PurchaseItem.EstimateItemID, tb_Purchase.PONO FROM  tb_PurchaseItem INNER JOIN  tb_Purchase ON tb_PurchaseItem.PurchaseID = tb_Purchase.PurchaseID where PONO=@PONO");

                    database.AddInParameter(storedProcCommand, "@PONO", DbType.String, PONO);
                    using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                    {
                        dataTable.Load(dataReader);
                    }

                    foreach (DataRow item in dataTable.Rows)
                    {
                        try
                        {
                            foreach (DataRow row in JobBasePage.Job_Select_By_JobID(this.CompanyID, Convert.ToInt64(item["Jobid"])).Rows)
                            {
                                empty = row["JobNumber"].ToString();
                            }


                            var PricecatalogueID = PriceCatalogue_PriceCatalogueID_Exsists(this.CompanyID, 0, Itemcode, "");
                            var LocationId = getWarehouseLocationID(Location, CompanyID);
                            var dt = LoadpriceCatalogueSelf(PricecatalogueID, LocationId);
                            foreach (DataRow self in dt.Rows)
                            {
                                Customfield1 = self["Customfield1"].ToString();
                                Customfield2 = self["Customfield2"].ToString();
                                Customfield3 = self["Customfield3"].ToString();
                                Customfield4 = self["Customfield4"].ToString();
                                Customfield5 = self["Customfield5"].ToString();
                                Customfield6 = self["Customfield6"].ToString();
                                //    Openingstock=Convert.ToInt32( self["OpeningStock"]);
                            }
                            string str = WebstoreBasePage.pricecataloguestock_actiontype_check((long)PricecatalogueID, "self");
                            WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, Openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Convert.ToInt64(item["Price"]), this.UserID, DateTime, str, string.Concat("Stock added through Stock Scanning ", empty),"");
                            this.objBaseClass.GoodsAdded_updatepurchaseitem(Convert.ToInt64(item["PurchaseItemID"].ToString()), Openingstock); //modification
                            this.objBaseClass.Replenished_updatepurchaseitem(Convert.ToInt64(item["EstimateItemID"].ToString()));
                            if (IsPartialOrFullStockReplinesh(Convert.ToInt64(item["PurchaseItemID"].ToString())))
                            {
                                StatusId = POCompleteStatusId;

                            }
                            else
                            {
                                StatusId = POPartialStatusId;
                            }
                            item_summary.DelPurchaseOrdStatusUpdate(this.CompanyID, "purchase", StatusId, Convert.ToInt64(item["PurchaseID"]), "");
                            SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, PONO, Openingstock, Itemcode, PricecatalogueID, Convert.ToInt32(item["EstimateItemID"]), Convert.ToInt32(item["PurchaseItemID"].ToString()), true, "Stock Replenished", this.UserID, ActualFileName, DateTime);
                        }
                        catch (Exception ex)
                        {
                            SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, PONO, Openingstock, Itemcode, 0, Convert.ToInt32(item["EstimateItemID"]), Convert.ToInt32(item["PurchaseItemID"].ToString()), false, ex.Message, this.UserID, ActualFileName, DateTime);

                        }

                    }


                }
            }
            base.Message_Display("PO file imported successfully", "msg-success", this.plhMessage);
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();
        }

        protected void btnDeductImport_Click(object sender, EventArgs e)
        {
            var dt = ReadSaveCSVFile(FileType.StockDeduction);
            DeductStockData(dt);
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();
        }
        public static DataSet ConnectFile(string filename, string FilePath)
        {
            Workbook workbook;
            Worksheet sheet;
            int counter;
            DataSet dataSet;
            DataSet ds = new DataSet();
            try
            {
                string fileextension = Path.GetExtension(filename);
                if (fileextension.ToLower() == ".csv")
                {
                    workbook = new Workbook();
                    workbook.LoadFromFile(string.Concat(FilePath), ",");
                    sheet = workbook.Worksheets[0];
                    counter = 1;
                    ds.Tables.Add(sheet.ExportDataTable());
                    dataSet = ds;
                }
                else if (fileextension.ToLower() == ".xls")
                {
                    workbook = new Workbook();
                    workbook.LoadFromFile(string.Concat(FilePath), ExcelVersion.Version97to2003);
                    sheet = workbook.Worksheets[0];
                    ds.Tables.Add(sheet.ExportDataTable());
                    dataSet = ds;
                }
                else if (fileextension.ToLower() == ".xlsx")
                {
                    workbook = new Workbook();
                    workbook.LoadFromFile(string.Concat(FilePath), ExcelVersion.Version2007);
                    sheet = workbook.Worksheets[0];
                    ds.Tables.Add(sheet.ExportDataTable());
                    dataSet = ds;
                }
                else if (!(fileextension.ToLower() == ".xlsm"))
                {
                    dataSet = ds;
                    return dataSet;
                }
                else
                {
                    workbook = new Workbook();
                    workbook.LoadFromFile(string.Concat(FilePath), ExcelVersion.Version2010);
                    sheet = workbook.Worksheets[0];
                    counter = 1;
                    CellRange[] columns = sheet.Columns;
                    for (int i = 0; i < (int)columns.Length; i++)
                    {
                        CellRange cl = columns[i];
                        Guid guid = Guid.NewGuid();
                        sheet.SetCellValue(1, counter, guid.ToString().Substring(0, 10));
                        counter++;
                    }
                    ds.Tables.Add(sheet.ExportDataTable());
                    dataSet = ds;
                }

            }
            catch (Exception exception)
            {
                Exception ex = exception;
                ds = null;
                throw ex;
            }
            return dataSet;
        }
        public void DeductStockData(DataTable dt1)
        {

            string Itemcode = "";
            Int32 Qty = 0;
            string JobCode = "";
            string Location = "";
            Int32 JobCompleteStatusId = 0;
            Int32 JobPartialStatusId = 0;
            Int32 ItemPartialStatusId = 0;

            if (this.ddlJobComplete.SelectedIndex != -1)
            {
                JobCompleteStatusId = Convert.ToInt32(this.ddlJobComplete.SelectedItem.Value);
            }
            if (this.ddlJobComplete.SelectedIndex != -1)
            {
                JobPartialStatusId = Convert.ToInt32(this.ddlJobPartial.SelectedItem.Value);
            }
            if (this.ddlPartialItem.SelectedIndex != -1)
            {
                ItemPartialStatusId = Convert.ToInt32(this.ddlPartialItem.SelectedItem.Value);
            }


            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    try
                    {
                        if (dr[0].ToString().Trim() != null)
                        {
                            Itemcode = dr[0].ToString().Trim();
                        }
                        if (dr[2].ToString().Trim() != null)
                        {
                            JobCode = dr[2].ToString().Trim();
                        }
                        if (dr[3].ToString().Trim() != null)
                        {
                            Location = dr[3].ToString().Trim();
                        }
                        if (dr[1].ToString().Trim() != null)
                        {
                            Qty = Convert.ToInt32(dr[1].ToString().Trim());
                        }
                        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                        DataTable dataTable = new DataTable();
                        DbCommand storedProcCommand = database.GetSqlStringCommand(" SELECT tb_job.JobID , tb_EstimateItem.EstimateItemID, tb_job.EstimateID FROM tb_job INNER JOIN tb_EstimateItem ON tb_job.JobID = tb_EstimateItem.JOBID  where JobNumber=@JobCode");

                        database.AddInParameter(storedProcCommand, "@JobCode", DbType.String, JobCode);
                        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                        {
                            dataTable.Load(dataReader);
                        }
                        foreach (DataRow item in dataTable.Rows)
                        {
                            var num11 = PriceCatalogue_PriceCatalogueID_Exsists(this.CompanyID, 0, Itemcode, "");
                            var CatalogueID = PriceCatalogue_Individual_Exsists(this.CompanyID, Convert.ToInt32(item["EstimateItemID"]),Itemcode);
                            BaseClass baseClass = new BaseClass();
                            var empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "self", Qty, Convert.ToInt32(item["EstimateItemID"]), "Job", (long)this.UserID, 0);
                            item_summary itemSummary = new item_summary();
                            Int32 AllocatedQty = IsPartialOrFullStockDeduction(num11, 0, "self", Convert.ToInt32(item["EstimateItemID"]), "job");
                            Int32 StatusId = 0;
                            if (AllocatedQty > 0)
                            {
                                StatusId = JobPartialStatusId;
                            }
                            else
                            {
                                StatusId = JobCompleteStatusId;
                            }
                            if (ItemPartialStatusId > 0 && CatalogueID != -1)
                            {
                                itemSummary.EstJobInvIduvidualItemStatuS_Update(this.CompanyID, (long)item["EstimateItemID"], (long)item["EstimateID"], ItemPartialStatusId, "job");
                            }
                            else
                            {
                                itemSummary.UpdateStatus(this.CompanyID, Convert.ToInt32(item["EstimateID"]), StatusId, "job", this.UserID, Convert.ToInt32(item["JobID"]));
                            }
                                SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, JobCode, Qty, Itemcode, 0, Convert.ToInt32(item["EstimateItemID"]), 0, true, "Stock Released", this.UserID, ActualFileName, DateTime.Now);
                        }
                    }
                    catch (Exception ex)
                    {

                        SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, JobCode, Qty, Itemcode, 0, 0, 0, false, ex.Message, this.UserID, ActualFileName, DateTime.Now);
                    }

                }
            }
            base.Message_Display("Job file imported successfully", "msg-success", this.plhMessage);
        }

        public static int PriceCatalogue_PriceCatalogueID_Exsists(int CompanyID, int CategoryID, string Itemcode, string Itemtitle)
        {
            System.Data.SqlClient.SqlParameter[] sqlParameter = new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyID", (object)CompanyID), new System.Data.SqlClient.SqlParameter("@CategoryID", (object)CategoryID), new System.Data.SqlClient.SqlParameter("@Itemcode", Itemcode), new System.Data.SqlClient.SqlParameter("@ItemTitle", Itemtitle), new System.Data.SqlClient.SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            System.Data.SqlClient.SqlParameter[] SqlParameter = sqlParameter;


            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_PriceCatalogueID_Exsists_CSVStock");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            database.AddInParameter(storedProcCommand, "@Itemcode", DbType.String, Itemcode);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));




        }
        public static int PriceCatalogue_Individual_Exsists(int CompanyID,int EstimateItemID,string Itemcode)
        {
            System.Data.SqlClient.SqlParameter[] sqlParameter = new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyID", (object)CompanyID), new System.Data.SqlClient.SqlParameter("@EstimateItemID", (object)EstimateItemID), new System.Data.SqlClient.SqlParameter("@Itemcode", Itemcode), new System.Data.SqlClient.SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            System.Data.SqlClient.SqlParameter[] SqlParameter = sqlParameter;


            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_PriceCatalogueID_Individual_Exsists_CSVStock");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Itemcode", DbType.String, Itemcode);

            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));




        }

        void DeleteProductStockHistory(Int32 PriceCatalogueId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetSqlStringCommand("update   tb_ProductStock_History set IsDeleted=1  where PricecatalogueID=@PricecatalogueID ");

            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, PriceCatalogueId);

            database.ExecuteDataSet(storedProcCommand);


        }

        void DeleteProductStockTransaction(Int32 PriceCatalogueId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetSqlStringCommand("delete from tb_ProductStock_Transaction where PricecatalogueID= @PriceCatalogueId ");

            database.AddInParameter(storedProcCommand, "@PriceCatalogueId", DbType.Int32, PriceCatalogueId);

            database.ExecuteDataSet(storedProcCommand);


        }

        void UpdatePriceCatalogueStock(Int32 PriceCatalogueId, Int64 Qty)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand;
           
                storedProcCommand = database.GetSqlStringCommand(" update tb_PriceCatalogue set AvailableQuantity=@Qty ,TotalQuantity=@Qty,AllocatedQuantity=0");
           

            database.AddInParameter(storedProcCommand, "@PriceCatalogueId", DbType.Int32, PriceCatalogueId);
            database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Qty);


            database.ExecuteDataSet(storedProcCommand);


        }

        DataTable LoadpriceCatalogueSelf(Int32 PriceCatalogueId, Int32 LocationId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetSqlStringCommand("select * from tb_PricecatalogueStock_Self where PricecatalogueID=@PriceCatalogueId and CustomField1=@CustomField1");

            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, PriceCatalogueId);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, LocationId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
        DataTable LoadpriceCatalogue(Int32 PriceCatalogueId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetSqlStringCommand(" select AvailableQuantity,TotalQuantity from tb_PriceCatalogue where PricecatalogueID= @PriceCatalogueId");

            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, PriceCatalogueId);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
        private static int getWarehouseLocationID(string name, int companyid)
        {

            int taxID = 0;
            try
            {


                string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(str);

                String sqlQuery = "select top 1 * from tb_WarehouseLocation where [LocationName] = @nameParm AND CompanyID = @companyparm AND IsDeleted = 0";
                SqlParameter nameParm = new SqlParameter();
                nameParm.ParameterName = "@nameParm";
                nameParm.Value = name.Trim();

                SqlParameter companyparm = new SqlParameter();
                companyparm.ParameterName = "@companyparm";
                companyparm.Value = companyid;

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                cmd.Parameters.Add(nameParm);
                cmd.Parameters.Add(companyparm);

                sqlConnection.Open();
                SqlDataReader datareader = cmd.ExecuteReader();


                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string returnedid = datareader["LocationId"].ToString();
                        taxID = Convert.ToInt32(returnedid);
                    }

                }
                else
                {
                    //
                }
                sqlConnection.Close();
                return taxID;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private bool IsPartialOrFullStockReplinesh(Int64 PurchaseItemID)
        {

            int Qty = 0;
            int GoodsReceived = 0;
            Boolean Result = false;
            try
            {


                string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(str);

                String sqlQuery = "select FLOOR(qty) as qty, isnull( GoodsReceived,0) as GoodsReceived  from tb_PurchaseItem where PurchaseItemID=@PurchaseItemID";
                SqlParameter nameParm = new SqlParameter();
                nameParm.ParameterName = "@PurchaseItemID";
                nameParm.Value = PurchaseItemID;



                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                cmd.Parameters.Add(nameParm);


                sqlConnection.Open();
                SqlDataReader datareader = cmd.ExecuteReader();


                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string returnedid = datareader[0].ToString();
                        GoodsReceived = Convert.ToInt32(datareader[1].ToString());
                        Qty = Convert.ToInt32(returnedid);
                    }

                }
                else
                {
                    //
                }
                sqlConnection.Close();
                if (GoodsReceived >= Qty)
                {
                    Result = true;
                }
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        Int32 IsPartialOrFullStockDeduction(Int64 PriceCatalogueID, Int64 KitID, string str, Int64 ModuleID, string ModuleName)
        {
            Int32 num2 = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            DataTable item = dataSet.Tables[0];

            foreach (DataRow row2 in item.Rows)
            {
                num2 = Convert.ToInt32(row2["AllocatedQty"].ToString());
            }

            return num2;
        }
        public void getStockSettingDetails()
        {
            int num = 0;
            DataTable dataTable = WebstoreBasePage.stockmanagementsettings_select(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {


                    if (row["StockScanFullJobStatusID"] != null)
                    {
                        this.setddlval(this.ddlJobComplete, Convert.ToInt32(row["StockScanFullJobStatusID"]));
                    }
                    if (row["StockScanPartialJobStatusID"] != null)
                    {
                        this.setddlval(this.ddlJobPartial, Convert.ToInt32(row["StockScanPartialJobStatusID"]));
                    }
                    if (row["StockScanFullPOStatusID"] != null)
                    {
                        this.setddlval(this.ddlPOComplete, Convert.ToInt32(row["StockScanFullPOStatusID"]));
                    }
                    if (row["StockScanPartialPOStatusID"] != null)
                    {
                        this.setddlval(this.ddlPOPartial, Convert.ToInt32(row["StockScanPartialPOStatusID"]));
                    }
                }
            }

        }
        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Int32 JobCompleteStatusId = 0;
            Int32 JobPartialStatusId = 0;
            Int32 POCompleteStatusId = 0;
            Int32 POPartialStatusId = 0;

            if (this.ddlJobComplete.SelectedIndex != -1)
            {
                JobCompleteStatusId = Convert.ToInt32(this.ddlJobComplete.SelectedItem.Value);
            }
            if (this.ddlJobPartial.SelectedIndex != -1)
            {
                JobPartialStatusId = Convert.ToInt32(this.ddlJobPartial.SelectedItem.Value);
            }
            if (this.ddlPOComplete.SelectedIndex != -1)
            {
                POCompleteStatusId = Convert.ToInt32(this.ddlPOComplete.SelectedItem.Value);
            }
            if (this.ddlPOPartial.SelectedIndex != -1)
            {
                POPartialStatusId = Convert.ToInt32(this.ddlPOPartial.SelectedItem.Value);
            }

            WebstoreBasePage.StockScanningJobOrPOStatus_Update(JobCompleteStatusId, JobPartialStatusId, POCompleteStatusId, POPartialStatusId, this.CompanyID);
            getStockSettingDetails();
        }

        public virtual DataTable grdImportHistory_BindGrid()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ScanningStockHistory_Select");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, this.CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    row["Comments"] = this.objBase.SpecialDecode(row["Comments"].ToString());
            //}
            return dataTable;
        }

        protected void grdImportHistory_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        private void UpdateProductStock()
        {
            var dt1 = ReadSaveCSVFile(FileType.StockAdd);



            string Itemcode = "";

            string PONO = "";
            string Location = "";
            string Customfield1 = "";
            string Customfield2 = "";
            string Customfield3 = "";
            string Customfield4 = "";
            string Customfield5 = "";
            string Customfield6 = "";
            int Openingstock = 0;
            string empty = string.Empty;
            decimal price = 0;
            DateTime date = DateTime.Now;
            List<priceCatalogue> priceCatalogueList = new List<priceCatalogue>();




            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr[0].ToString().Trim() != null)
                    {
                        Itemcode = dr[0].ToString().Trim();
                    }
                    if (dr[1].ToString().Trim() != null)
                    {
                        Openingstock = Convert.ToInt32(dr[1]);
                    }
                    if (dr[2].ToString().Trim() != null)
                    {
                        Location = dr[2].ToString().Trim();
                    }
                    if (dr[3].ToString().Trim() != null)
                    {
                        Customfield2 = dr[3].ToString().Trim();
                    }
                    if (dr[4].ToString().Trim() != null)
                    {
                        Customfield3 = dr[4].ToString().Trim();
                    }
                    if (dr[5].ToString().Trim() != null)
                    {
                        Customfield4 = dr[5].ToString().Trim();
                    }
                    if (dr[6].ToString().Trim() != null)
                    {
                        Customfield5 = dr[6].ToString().Trim();
                    }
                    if (dr[7].ToString().Trim() != null)
                    {
                        Customfield6 = dr[7].ToString().Trim();
                    }
                    if (dr[8] != System.DBNull.Value)
                    {
                        price = Convert.ToDecimal(dr[8]);
                    }
                    if (dr[9] != System.DBNull.Value)
                    {
                        //date = Convert.ToDateTime(dr[9]);
                       date =  DateTime.ParseExact(dr[9].ToString(), "dd/MM/yyyy", null);
                    }


                    try
                    {



                        var PricecatalogueID = PriceCatalogue_PriceCatalogueID_Exsists(this.CompanyID, 0, Itemcode, "");
                        var LocationId = getWarehouseLocationID(Location, CompanyID);
                        if (LocationId == 0)
                        {
                            SettingsBasePage.productcatalogue_warehouselocation_insert(this.CompanyID, Location, "", "", "", "", "", "", 0);
                            LocationId = getWarehouseLocationID(Location, CompanyID);
                        }
                        //var dt = LoadpriceCatalogueSelf(PricecatalogueID, LocationId);
                        //foreach (DataRow self in dt.Rows)
                        //{
                        //    Customfield1 = self["Customfield1"].ToString();
                        //    Customfield2 = self["Customfield2"].ToString();
                        //    Customfield3 = self["Customfield3"].ToString();
                        //    Customfield4 = self["Customfield4"].ToString();
                        //    Customfield5 = self["Customfield5"].ToString();
                        //    Customfield6 = self["Customfield6"].ToString();
                        //    //    Openingstock=Convert.ToInt32( self["OpeningStock"]);
                        //}
                        var cata = priceCatalogueList.Where(c => c.PricecatalogueID == PricecatalogueID).SingleOrDefault();
                        if (cata==null)
                        {
                            WebstoreBasePage.pricecataloguestock_self_delete(PricecatalogueID);
                            UpdatePriceCatalogueStock(PricecatalogueID, 0);
                        }
                        else
                        {

                            //var dtCatalogue = LoadpriceCatalogue(PricecatalogueID);
                            //long total = priceCatalogueList.Where(item => item.PricecatalogueID == PricecatalogueID).Sum(item => item.Quantity);
                           // total =  Openingstock;
                           // UpdatePriceCatalogueStock(PricecatalogueID, 0);
                        }

                        //DeleteProductStockHistory(PricecatalogueID);
                        //DeleteProductStockTransaction(PricecatalogueID);
                        string str = WebstoreBasePage.pricecataloguestock_actiontype_check((long)PricecatalogueID, "self");
                        WebstoreBasePage.pricecataloguestock_self_insert(PricecatalogueID, Openingstock, LocationId.ToString(), Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, price, this.UserID, date, str, string.Concat("Stock added through CSV file"),"");
                        priceCatalogue pc = new priceCatalogue();
                        pc.PricecatalogueID = PricecatalogueID;
                        pc.Quantity = Openingstock;
                        priceCatalogueList.Add(pc);

                        SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, Itemcode, Openingstock, Itemcode, PricecatalogueID, 0, 0, true, "Stock Added", this.UserID, ActualFileName, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        SettingsBasePage.ScanningStockHistory_InsertOrUpdate(0, this.CompanyID, PONO, Openingstock, Itemcode, 0, 0, 0, false, ex.Message, this.UserID, ActualFileName, DateTime.Now);

                    }


                }
            }
            base.Message_Display("Stock file imported successfully", "msg-success", this.plhMessage);
            this.grdImportHistory.DataSource = this.grdImportHistory_BindGrid();
            this.grdImportHistory.DataBind();
        }

        protected void btnCSVFile_Click(object sender, EventArgs e)
        {
            UpdateProductStock();
        }
    }
    enum FileType
    {
        StockReplinesh = 0,
        StockDeduction = 1,
        StockAdd = 2,

    }

    public class priceCatalogue
    {
        public Int32 PricecatalogueID { get; set; }
        public long Quantity { get; set; }
    }
}

