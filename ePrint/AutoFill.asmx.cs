using MathFunctions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

//namespace ePrint
//{

[ScriptService]
[WebService(Namespace = "http://www.eprintsoftware.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AutoFill : WebService
{
    private BaseClass objbase = new BaseClass();

    public static Hashtable PID_HashList;

    static AutoFill()
    {
        AutoFill.PID_HashList = new Hashtable();
    }

    public AutoFill()
    {
    }

    [WebMethod(EnableSession = true)]
    public string AssignIDs_to_Sessions(string UniqueID, string Type)
    {
        base.Session["UniqueID"] = UniqueID;
        base.Session["Type"] = Type;
        return "Returnresult";
    }

    [WebMethod(EnableSession = true)]
    public string BindCustomers_ForHeader(string CompanyID, string SearchParameter, string isDisplaySupplier)
    {
        BaseClass baseClass = new BaseClass();
        CompanyBasePage companyBasePage = new CompanyBasePage();
        SearchParameter = this.objbase.SpecialEncode(SearchParameter);
        DataTable dataTable = companyBasePage.company_customer_autocomplete(Convert.ToInt32(CompanyID), SearchParameter, isDisplaySupplier);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        base.Session["BindCustomers_FromHeader"] = "yes";
        string str = VuMgr.RenderView("~/UserControl/AutoFill/MachedCustomer_FromHeader.ascx", dataSet);
        base.Session["BindCustomers_FromHeader"] = null;
        return str;
    }

    [WebMethod]
    public string CalculateFormulaCost(string FormulaVals, int ID)
    {
        MathParser mathParser = new MathParser();
        if (FormulaVals.Substring(0, 1) == "-")
        {
            FormulaVals = string.Concat("0", FormulaVals);
        }
        string str = mathParser.Calculate(FormulaVals).ToString();
        return string.Concat(str, "~", ID);
    }

    [WebMethod]
    public string CalculateFormulaCost_ForMultipleChoice(string FormulaVals, decimal Markup, long ID)
    {
        MathParser mathParser = new MathParser();
        if (FormulaVals.Substring(0, 1) == "-")
        {
            FormulaVals = string.Concat("0", FormulaVals);
        }
        string str = mathParser.Calculate(FormulaVals).ToString();
        decimal num = Convert.ToDecimal(str) + ((Convert.ToDecimal(str) * Markup) / new decimal(100));
        string str1 = string.Concat(num.ToString(), "~", ID);
        return str1;
    }

    [WebMethod]
    public string CalculateFormulaCost_ForSUBMultipleChoice(string FormulaVals, decimal Markup, string ID)
    {
        MathParser mathParser = new MathParser();
        if (FormulaVals.Substring(0, 1) == "-")
        {
            FormulaVals = string.Concat("0", FormulaVals);
        }
        string str = mathParser.Calculate(FormulaVals).ToString();
        decimal num = Convert.ToDecimal(str) + ((Convert.ToDecimal(str) * Markup) / new decimal(100));
        return string.Concat(num.ToString(), "~", ID);
    }

    [WebMethod(EnableSession = true)]
    public string Check_Direct_Job_Invoice_Possible(long PriceCatalogueID, int Quantity, string Module)
    {
        string empty = string.Empty;
        if (base.Session["ProductStockManagement"] != null)
        {
            if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
            {
                empty = "true";
            }
            else
            {
                BaseClass baseClass = new BaseClass();
                empty = baseClass.Check_Estimate_Possible(PriceCatalogueID, Quantity, Module, (long)0);
            }
        }
        return empty;
    }

    [WebMethod]
    public int Check_EmailID_Duplicacy(int StoreUserID, string val, int AccountID)
    {
        string str = val;
        int num = CompanyBasePage.CheckEmailID_Duplicacy(Convert.ToInt64(StoreUserID), str, (long)AccountID);
        return num;
    }

    [WebMethod]
    public int Check_EmailID_Duplicacy_for_Account(string val, int Client_ID, long Contact_ID)
    {
        return CompanyBasePage.Check_EmailID_Duplicacy_for_Account(val, (long)Client_ID, Contact_ID);
    }

    [WebMethod]
    public int Check_EmailID_Duplicate_for_Account(string val, int Client_ID)
    {
        return CompanyBasePage.Check_EmailID_Duplicate_for_Account(val, (long)Client_ID);
    }

    [WebMethod]
    public int Check_page_Duplicacy(long CompanyID, long AccountID, long PageID, string PageName)
    {
        return WebstoreBasePage.Check_pages_Duplicacy(CompanyID, AccountID, PageID, PageName);
    }

    [WebMethod(EnableSession = true)]
    public bool Check_ProductCatalogue_ISStockExist(long CompanyID, long PriceCatalogueID)
    {
        bool flag = false;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Check_ProductCatalogue_ISStockExist");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        flag = Convert.ToBoolean(Convert.ToString(dataTable.Rows[0]["ISStockExist"]));
        return flag;
    }

    [WebMethod(EnableSession = true)]
    public bool CheckAllocationExist(long JobID, long EstimateItemID)
    {
        return InvoiceBasePage.CheckAllocationExist(JobID, EstimateItemID);
    }

    [WebMethod]
    public int CheckDept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
    {
        return CompanyBasePage.Check_Dept_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
    }

    [WebMethod]
    public int Check_Cost_Centre_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
    {
        return CompanyBasePage.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
    }

    [WebMethod]
    public static int Check_Cost_Centre_Duplicacy_copy(int CompanyID, int ClientID, string DeptName, int DeptID)
    {
        return CompanyBasePage.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
    }

    [WebMethod(EnableSession = true)]
    public string CheckEstimatePossible(long PriceCatalogueID, int Quantity)
    {
        string empty = string.Empty;
        if (base.Session["ProductStockManagement"] != null)
        {
            if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
            {
                empty = "true";
            }
            else
            {
                BaseClass baseClass = new BaseClass();
                empty = baseClass.Check_Estimate_Possible(PriceCatalogueID, Quantity, "", (long)0);
            }
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public bool CheckInvoicePossible(long JobID, long EstimateItemID)
    {
        return InvoiceBasePage.CheckInvoicePossible(JobID, EstimateItemID);
    }

    public class InvoicePossibleResult
    {
        public bool IsInvoicePossible { get; set; }
        public string JobNumber { get; set; }
        public string ItemCode { get; set; }
    }

    [WebMethod(EnableSession = true)]
    public InvoicePossibleResult CheckInvoicePossiblenew(long JobID,long EstimateItemID)
    {
        var result = new InvoicePossibleResult();

        // Existing logic
        result.IsInvoicePossible = InvoiceBasePage.CheckInvoicePossible(JobID, EstimateItemID);

        // 🔹 Get CompanyID from session
        int companyId = Convert.ToInt32(Session["CompanyID"]);

        DataTable dataTable = new DataTable();
        dataTable = InvoiceBasePage.Get_JobNumber_ProductID_ForAlert(JobID, EstimateItemID, companyId);
        foreach (DataRow row in dataTable.Rows)
        {
            result.JobNumber = row["JobNumber"].ToString();
            result.ItemCode = row["ItemCode"].ToString();
        }

        return result;
    }


    [WebMethod(EnableSession = true)]
    public bool CheckisInvoiceCopyPossible(long InvoiceID)
    {
        bool flag;
        DataTable dataTable = new DataTable();
        dataTable = InvoiceBasePage.Job_Card_Info_Select_By_InvoiceID(InvoiceID);
        Hashtable hashtables = new Hashtable();
        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                DataTable dataTable1 = EstimatesBasePage.price_catalogue_select_by_estimateitem_id_new(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt64(current["EstimateItemID"]));
                string empty = string.Empty;
                IEnumerator enumerator1 = dataTable1.Rows.GetEnumerator();
                try
                {
                    while (enumerator1.MoveNext())
                    {
                        DataRow num = (DataRow)enumerator1.Current;
                        if (!hashtables.Contains(Convert.ToInt64(num["PriceCatalogueID"])))
                        {
                            hashtables.Add(Convert.ToInt64(num["PriceCatalogueID"]), Convert.ToInt32(num["Quantity"]) * Convert.ToInt32(num["MultipleOf"]));
                            empty = this.objbase.Check_Estimate_Possible(Convert.ToInt64(num["PriceCatalogueID"]), Convert.ToInt32(num["Quantity"]) * Convert.ToInt32(num["MultipleOf"]), "invoice", (long)0);
                        }
                        else
                        {
                            hashtables[Convert.ToInt64(num["PriceCatalogueID"])] = Convert.ToInt64(hashtables[Convert.ToInt64(num["PriceCatalogueID"])]) + Convert.ToInt64(num["Quantity"]) * Convert.ToInt64(num["MultipleOf"]);
                            empty = this.objbase.Check_Estimate_Possible(Convert.ToInt64(num["PriceCatalogueID"]), Convert.ToInt32(hashtables[Convert.ToInt64(num["PriceCatalogueID"])]), "invoice", (long)0);
                        }
                        if (string.IsNullOrEmpty(empty) || !empty.ToLower().Contains("false"))
                        {
                            continue;
                        }
                        hashtables.Clear();
                        flag = false;
                        return flag;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator1 as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                DataSet dataSet = EstimatesBasePage.sub_item_summary(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt64(current["EstimateItemID"]), Convert.ToString(current["Itemtype"]));
                IEnumerator enumerator2 = dataSet.Tables[5].Rows.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        DataRow dataRow = (DataRow)enumerator2.Current;
                        if (!hashtables.Contains(Convert.ToInt64(dataRow["PriceCatalogueID"])))
                        {
                            hashtables.Add(Convert.ToInt64(dataRow["PriceCatalogueID"]), Convert.ToInt32(dataRow["SubItemQuantity"]));
                            empty = this.objbase.Check_Estimate_Possible(Convert.ToInt64(dataRow["PriceCatalogueID"]), Convert.ToInt32(dataRow["SubItemQuantity"]), "invoice", (long)0);
                        }
                        else
                        {
                            hashtables[Convert.ToInt64(dataRow["PriceCatalogueID"])] = Convert.ToInt64(hashtables[Convert.ToInt64(dataRow["PriceCatalogueID"])]) + Convert.ToInt64(dataRow["SubItemQuantity"]);
                            empty = this.objbase.Check_Estimate_Possible(Convert.ToInt64(dataRow["PriceCatalogueID"]), Convert.ToInt32(hashtables[Convert.ToInt64(dataRow["PriceCatalogueID"])]), "invoice", (long)0);
                        }
                        if (string.IsNullOrEmpty(empty) || !empty.ToLower().Contains("false"))
                        {
                            continue;
                        }
                        hashtables.Clear();
                        flag = false;
                        return flag;
                    }
                }
                finally
                {
                    IDisposable disposable1 = enumerator2 as IDisposable;
                    if (disposable1 != null)
                    {
                        disposable1.Dispose();
                    }
                }
            }
            hashtables.Clear();
            return true;
        }
        finally
        {
            IDisposable disposable2 = enumerator as IDisposable;
            if (disposable2 != null)
            {
                disposable2.Dispose();
            }
        }

    }

    [WebMethod(EnableSession = true)]
    public string CheckJobCopyPossible(long JobID)
    {
        string empty = string.Empty;
        IEnumerator enumerator = JobBasePage.Job_Card_Info_Select_By_JobID(JobID).Rows.GetEnumerator();
        try
        {
            do
            {
                if (!enumerator.MoveNext())
                {
                    break;
                }
                DataRow current = (DataRow)enumerator.Current;
                empty = this.CheckProgressToJobPossible(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt64(current["EstimateItemID"]), Convert.ToString(current["ItemType"]), Convert.ToInt32(current["QtyNumber"]), "job");
            }
            while (!empty.ToLower().Contains("false"));
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public string CheckPartialReduction_WithBackorder(long PriceCatalogueID, long CompanyID, int QtyNumber, int StatusID)
    {
        string empty = string.Empty;
        if (base.Session["ProductStockManagement"] != null)
        {
            if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
            {
                empty = "true~0";
            }
            else
            {
                BaseClass baseClass = new BaseClass();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DataSet dataSet = new DataSet();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CheckPartialReduction_WithBackorder");
                database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
                database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    empty = string.Concat(row["IsEstimatePossible"].ToString(), "~", row["AvailableQuantity"].ToString());
                }
            }
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public string CheckProgressToJobPossible(int CompanyID, long EstimateItemID, string ItemType, int QtyNumber, string Module)
    {
        string empty = string.Empty;
        if (base.Session["ProductStockManagement"] != null)
        {
            if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
            {
                empty = "true";
            }
            else
            {
                BaseClass baseClass = new BaseClass();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DataSet dataSet = new DataSet();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_info_select_by_qtynumber_new");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
                database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
                database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
                database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
                dataSet = database.ExecuteDataSet(storedProcCommand);
                baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                DataTable dataTable = new DataTable();
                if (ItemType.ToLower() == "x" || ItemType.ToLower() == "c")
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        if (Module == "order")
                        {
                            if (row["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "self", EstimateItemID);
                            }
                            else if (row["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select((long)0, Convert.ToInt64(row["PriceCatalogueID"]), (long)CompanyID, "others", EstimateItemID);
                            }
                            else if (row["DrawStockFrom"].ToString().ToLower() == "m")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "multiple", EstimateItemID);
                            }
                            else if (row["DrawStockFrom"].ToString().ToLower() == "a")
                            {
                                dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row["PriceCatalogueID"]), (long)0, (long)CompanyID, "additional option", EstimateItemID);
                            }
                        }
                        if (dataTable.Rows.Count <= 0)
                        {
                            long num = Convert.ToInt64(row["PriceCatalogueID"]);
                            int num1 = Convert.ToInt32(row["Quantity"]);
                            if (!AutoFill.PID_HashList.ContainsKey(num))
                            {
                                AutoFill.PID_HashList.Add(num, num1);
                            }
                            else
                            {
                                num1 = num1 + Convert.ToInt32(AutoFill.PID_HashList[num].ToString());
                                AutoFill.PID_HashList[num] = num1;
                            }
                            if (!Convert.ToBoolean(row["IsStockReplenish"].ToString()))
                            {
                                empty = baseClass.Check_Estimate_Possible(num, num1, Module, Convert.ToInt64(row["JobItemStatusID"]));
                                if (empty == "false")
                                {
                                    break;
                                }
                                empty = "true";
                            }
                            else
                            {
                                empty = "true";
                            }
                        }
                        else
                        {
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (Convert.ToInt32(dataRow["TotalOldQty"].ToString()) == Convert.ToInt32(row["Quantity"]))
                                {
                                    empty = "true";
                                }
                                else
                                {
                                    long num2 = Convert.ToInt64(row["PriceCatalogueID"]);
                                    int num3 = Convert.ToInt32(row["Quantity"]);
                                    if (!AutoFill.PID_HashList.ContainsKey(num2))
                                    {
                                        AutoFill.PID_HashList.Add(num2, num3);
                                    }
                                    else
                                    {
                                        num3 = num3 + Convert.ToInt32(AutoFill.PID_HashList[num2].ToString());
                                        AutoFill.PID_HashList[num2] = num3;
                                    }
                                    if (!Convert.ToBoolean(row["IsStockReplenish"].ToString()))
                                    {
                                        empty = baseClass.Check_Estimate_Possible(num2, num3, Module, Convert.ToInt64(row["JobItemStatusID"]));
                                        if (empty == "false")
                                        {
                                            break;
                                        }
                                        empty = "true";
                                    }
                                    else
                                    {
                                        empty = "true";
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (DataRow row1 in dataSet.Tables[8].Rows)
                {
                    if (!dataSet.Tables[8].Columns.Contains("PriceCatalogueID"))
                    {
                        continue;
                    }
                    if (Module == "order")
                    {
                        if (row1["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "self", Convert.ToInt64(row1["EstimateItemID"]));
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            dataTable = baseClass.StockProductRerunDetails_Select((long)0, Convert.ToInt64(row1["PriceCatalogueID"]), (long)CompanyID, "others", Convert.ToInt64(row1["EstimateItemID"]));
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "m")
                        {
                            dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "multiple", Convert.ToInt64(row1["EstimateItemID"]));
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "a")
                        {
                            dataTable = baseClass.StockProductRerunDetails_Select(Convert.ToInt64(row1["PriceCatalogueID"]), (long)0, (long)CompanyID, "additional option", Convert.ToInt64(row1["EstimateItemID"]));
                        }
                    }
                    if (dataTable.Rows.Count <= 0)
                    {
                        empty = baseClass.Check_Estimate_Possible((long)Convert.ToInt32(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]), Module, Convert.ToInt64(row1["JobItemStatusID"]));
                        if (empty == "false")
                        {
                            break;
                        }
                        empty = "true";
                    }
                    else
                    {
                        foreach (DataRow dataRow1 in dataTable.Rows)
                        {
                            if (Convert.ToInt32(dataRow1["TotalOldQty"].ToString()) == Convert.ToInt32(row1["Quantity"]))
                            {
                                empty = "true";
                            }
                            else
                            {
                                empty = baseClass.Check_Estimate_Possible((long)Convert.ToInt32(row1["PriceCatalogueID"]), Convert.ToInt32(row1["Quantity"]), Module, Convert.ToInt64(row1["JobItemStatusID"]));
                                if (empty == "false")
                                {
                                    break;
                                }
                                empty = "true";
                            }
                        }
                    }
                }
            }
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public void ClearHashTable()
    {
        AutoFill.PID_HashList.Clear();
    }

    [WebMethod]
    public string ClientReferencedByName_Select(string Name)
    {
        string empty = string.Empty;
        DataTable dataTable = CompanyBasePage.ClientReferencedByName_Select(Name, 0);
        for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
        {
            empty = string.Concat(empty, dataTable.Rows[i][0], "¶");
        }
        return empty;
    }

    [WebMethod]
    public string crm_common_select_accessrightOfUserType(int companyid, int usertypeid)
    {
        string empty = string.Empty;
        DataTable dataTable = CompanyBasePage.crm_common_select_accessrightOfUserType(companyid, usertypeid);
        int count = dataTable.Rows.Count;
        for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
        {
            empty = string.Concat(empty, dataTable.Rows[i]["screenname"], ",");
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public void DefaultProductStock_Self_Insert(int CompanyID, long PriceCatalogueID)
    {
        commonClass _commonClass = new commonClass();
        string str = Convert.ToString(base.Session["DateFormat"]);
        DateTime now = DateTime.Now;
        string str1 = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(str, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, Convert.ToInt32(base.Session["userID"]), true));
        WebstoreBasePage.DefaultProductStock_Self_Insert(PriceCatalogueID, Convert.ToInt64(base.Session["userID"]), (long)CompanyID, Convert.ToDateTime(str1));
    }

    [WebMethod]
    public void Delete_OtherCost_Choice(long webothercostid, long ChoiceID)
    {
        WebstoreBasePage.Othercost_WebstoreChoice_Delete(webothercostid, ChoiceID);
    }

    [WebMethod]
    public void Delete_OtherCost_Mtrix(long MatrixID)
    {
        WebstoreBasePage.Othercost_WebstoreMatrix_Delete((long)0, MatrixID);
    }

    [WebMethod]
    public string DeleteImageCategory(long CategoryID, long UserID)
    {
        string str = "false";
        str = (!SettingsBasePage.DeleteImageCategory(CategoryID, UserID).Contains("-1") ? "true" : "false");
        return str;
    }

    [WebMethod]
    public string DeleteMultipleImageCategory(long CompanyID, long UserID, string CategoryIDs, string ImgIDs)
    {
        if (SettingsBasePage.DeleteMultipleImageCategory_Check(CompanyID, UserID, CategoryIDs, ImgIDs).Contains("-1"))
        {
            return "false";
        }
        return "true";
    }

    [WebMethod]
    public string DeleteRootImage(long ImageID, long UserID)
    {
        string str = "false";
        str = (!SettingsBasePage.DeleteRootImage(ImageID, UserID).Contains("-1") ? "true" : "false");
        return str;
    }

    [WebMethod]
    public void DeleteSingleInUseCategory(string CategoryID, long UserID)
    {
        SettingsBasePage.DeleteSingleInUseCategory(CategoryID, UserID);
    }

    [WebMethod]
    public void DeleteSingleInUseImage(string ImgID, long UserID)
    {
        SettingsBasePage.DeleteSingleInUseImage(ImgID, UserID);
    }

    [WebMethod(EnableSession = true)]
    public string DismissAlertNotification(int ID, int CompanyID, string SectionName)
    {
        DepartmentBaseClass.Crm_DismissAlert_Notifications(Convert.ToInt64(ID), Convert.ToInt64(CompanyID), SectionName);
        return this.GetAlertNotification();
    }

    [WebMethod]
    public string Get_Carrier_Consigneeurl(long clientid)
    {
        string str = "";
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_GetConsignee_Url");
        database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, clientid);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        str = dataTable.Rows[0]["WebSite"].ToString();
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string GetAlertNotification()
    {
        this.objbase.Session_Check();
        string str = global.sitePath();
        commonClass _commonClass = new commonClass();
        int num = 0;
        string str1 = DateTime.Now.ToString();
        string str2 = _commonClass.Eprint_return_DateTime_Before_View_For_AlertNotifications(str1, Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["userID"]), true);
        string str3 = this.objbase.Return_IsEnable_CRM(Convert.ToInt32(Convert.ToInt32(base.Session["CompanyID"])));
        DataSet dataSet = DepartmentBaseClass.Crm_Select_Alert_Notifications(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["userID"]), str2, Convert.ToBoolean(str3));
        StringBuilder stringBuilder = new StringBuilder();
        languageClass _languageClass = new languageClass();
        int num1 = 0;
        int num2 = 0;
        bool flag = false;
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        stringBuilder.Append("<div id='divloadingdisplay' style='margin-top: 112px; margin-right:0px; height: 10px; display: none; position: absolute;right: 0%; top: 5%; width: 300px;  z-index: 55555555555;'>");
        stringBuilder.Append("<div style='background-color:#B7B7B7; width:140px; height:22px;border-radius:5px;opacity: 1.5; margin-right:95px; float:right;box-shadow: 6px 7px 10px #000000;'>");
        stringBuilder.Append("<table>");
        stringBuilder.Append("<tr>");
        stringBuilder.Append("<td>");
        stringBuilder.Append("<div style='margin-top:0px; margin-left:9px;'>");
        stringBuilder.Append(string.Concat("<span style='font-size: 12px; color:black;'>", _languageClass.GetLanguageConversion("Hidden_successfully"), "</span>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("</table>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("<div id='divalertcontant' class='ddM3' onclick='javascript:StayonAlertDiv();' style='margin-top: 21px; margin-right:5px; height: 10px; display: none; position: absolute;right: 0%; top: 5%; width: 300px; max-height: 200px; min-height: 200px; z-index: 55555; background-color: White; border-radius: 3px;'>");
        stringBuilder.Append("<table cellpadding='0' cellspacing='0' id='taskheaderback' style='height: 20px; width: 300px;'>");
        stringBuilder.Append("<tr>");
        stringBuilder.Append("<td id='divtaskbackground' style='width:149px;' class='alerttabnew'>");
        if (!flag)
        {
            DataRow[] dataRowArray = dataSet.Tables[0].Select("Type = 'task'");
            stringBuilder.Append("<div class='alertmaintab' id='taskborderright' style='font-weight: bold; margin-top:-5px;margin-left:-5px; border-top-left-radius:3px;cursor:pointer; color: black; height:22px;padding-top:5px; padding-left:5px;' onclick='javascript:opentaskdiv(); return false;'>");
            stringBuilder.Append("<table>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-4px;'>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-3px;margin-left:-8px;'>");
            stringBuilder.Append(string.Concat("<span id='taskfontcolor' style='margin-left:6px; font-weight:bold; font-size:13px; color:white;'>", _languageClass.GetLanguageConversion("Tasks"), "</span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-3px;'>");
            stringBuilder.Append("<div style='margin-top:-2px; padding:1px 5px 2px 0px;'>");
            stringBuilder.Append(string.Concat("<span id='TaskCount' style='font-size: 11px;font-weight:bold;color:white'>(", (int)dataRowArray.Length, ")</span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div id='div_Add_New_Task' onclick='javascript:return Open_AddTask_PopUp_FromHeader();' style='margin-top:-3px;'>");
            stringBuilder.Append(string.Concat("<img id='imgbtnplus_Add_New_Task' title='Add Task' src='", str, "images/Plus_Header.png' style='cursor:pointer;'/>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            stringBuilder.Append("</table>");
            stringBuilder.Append("<div id='divtashbottomcolor' style='display:none'>");
            stringBuilder.Append("<div id='div_imgarrowup' style='margin-left:42px; margin-top:-3px;'>");
            stringBuilder.Append(string.Concat("<span style='font-size: 11px;'><img src='", str, "images/arrow_white_up.png' style='cursor:pointer;'/></span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            flag = true;
        }
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td id='divcallbackground' style='width:149px;' class='alerttabnew'>");
        if (!flag1)
        {
            DataRow[] dataRowArray1 = dataSet.Tables[0].Select("Type = 'Call'");
            stringBuilder.Append("<div class='alertmaintab' id='Callborderright' style='font-weight: bold; color: black;margin-top:-5px;cursor:pointer;height:22px;padding-top:5px; padding-left:5px;' onclick='javascript:opencalldiv(); return false;'>");
            stringBuilder.Append("<table>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-4px;'>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-3px;margin-left:-8px;'>");
            stringBuilder.Append(string.Concat("<span id='callfontcolor' style='margin-left:6px; font-weight:bold; font-size:13px; color:white;'>", _languageClass.GetLanguageConversion("Calls"), "</span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div style='margin-top:-3px;'>");
            stringBuilder.Append("<div style='margin-top:-2px; padding:1px 5px 2px 0px;'>");
            stringBuilder.Append(string.Concat("<span id='CallCount' style='font-size: 11px;font-weight:bold;color:white'>(", (int)dataRowArray1.Length, ")</span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td valign='top'>");
            stringBuilder.Append("<div id='div_Add_New_Call' onclick='javascript:return Open_AddCallPopup_FromHeader();' style='margin-top:-3px;'>");
            stringBuilder.Append(string.Concat("<img id='imgbtnplus_Add_New_Call' title='Add Call' src='", str, "images/Plus_Header.png' style='cursor:pointer;'/>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            stringBuilder.Append("</table>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("<div id='divcallbottomcolor' style='display:none'>");
            stringBuilder.Append("<div style='margin-left:39px; margin-top:-6px;'>");
            stringBuilder.Append(string.Concat("<span style='font-size: 11px;'><img src='", str, "images/arrow_white_up.png' style='cursor:pointer;'/></span>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            flag1 = true;
        }
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td id='divnotesbackground' style='width:149px;' class='alerttabnew'>");
        stringBuilder.Append("<div class='alertmaintab' id='Notesborderright' style='font-weight: bold; color: black;margin-top:-5px;margin-left: 1px;margin-right:-4.5px;cursor:pointer; border-top-right-radius:3px; height:22px;padding-top:5px; padding-left:5px;' onclick='javascript:opennotesdiv(); return false;'>");
        stringBuilder.Append("<table>");
        stringBuilder.Append("<tr>");
        stringBuilder.Append("<td valign='top'>");
        stringBuilder.Append("<div style='margin-top:-4px;'>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td valign='top'>");
        stringBuilder.Append("<div style='margin-top:-3px;'>");
        stringBuilder.Append(string.Concat("<span id='Notesfontcolor' style='margin-left:6px; font-weight:bold; font-size:13px; color:white;'>", _languageClass.GetLanguageConversion("Notes"), "</span>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td valign='top'>");
        stringBuilder.Append("<div style='margin-top:-3px;'>");
        stringBuilder.Append("<div style='margin-top:-2px; padding:1px 5px 2px 0px;'>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td valign='top'>");
        stringBuilder.Append("<div id='div_Add_New_Note' onclick='javascript:return addnote_FromHeader();' style='margin-top:-3px;'>");
        stringBuilder.Append(string.Concat("<img id='imgbtnplus_Add_New_Note' title='Add Note' src='", str, "images/Plus_Header.png' style='cursor:pointer;'/>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("</table>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("<div id='divNotebottomcolor' style='display:none'>");
        stringBuilder.Append("<div style='margin-left:39px; margin-top:-6px;'>");
        stringBuilder.Append(string.Concat("<span style='font-size: 11px;'><img src='", str, "images/arrow_white_up.png' style='cursor:pointer;'/></span>"));
        stringBuilder.Append("</div>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("</td>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("</table>");
        stringBuilder.Append("<div id='div_taskheaderback' style='overflow: auto; overflow-x: hidden; height:177px;'>");
        if (dataSet.Tables.Count <= 0)
        {
            if (!flag2)
            {
                stringBuilder.Append("<div id='DivtaskNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:block;'>");
                stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                stringBuilder.Append("</div>");
                flag2 = true;
            }
            if (!flag3)
            {
                stringBuilder.Append("<div id='DivcallNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:block;'>");
                stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                stringBuilder.Append("</div>");
                flag3 = true;
            }
        }
        else if (dataSet.Tables[0].Rows.Count <= 0)
        {
            if (!flag2)
            {
                stringBuilder.Append("<div id='DivtaskNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:block;'>");
                stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                stringBuilder.Append("</div>");
                flag2 = true;
            }
            if (!flag3)
            {
                stringBuilder.Append("<div id='DivcallNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:block;'>");
                stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                stringBuilder.Append("</div>");
                flag3 = true;
            }
        }
        else
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["Type"].ToString().ToLower() == "task")
                {
                    num++;
                    stringBuilder.Append("<div id='notaskrecords'>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append(string.Concat("<div id='TaskDiv_", num, "'>"));
                    stringBuilder.Append("<table id='TaskDiv' border='0' cellpadding='0' cellspacing='0' width='300px' class='rowtable' style='border-bottom:1px solid #E9E5E2;word-wrap: break-word;'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    base.Session["Popup"] = "Popup";
                    StringBuilder stringBuilder1 = new StringBuilder();
                    string[] strArrays = new string[] { "clientid=", row["clientid"].ToString(), "&isnew=2&bypass=1&type=", row["clienttype"].ToString(), "&TaskID=", row["UniqueID"].ToString(), "&ActivityType=", row["Type"].ToString() };
                    stringBuilder1.Append(string.Concat(strArrays));
                    stringBuilder.Append("<div style='margin-top: 8px; margin-left: 5px; width:239px; float:left;'>");
                    object[] objArray = new object[] { "<span ><a href=javascript:void(null);Open_task_Call_details_FromHeader('", stringBuilder1.ToString().Trim(), "','TaskDiv_", num, "'); style='cursor:pointer; color:black; font-weight:bold' title='", this.objbase.SpecialDecode(row["Subject"].ToString()), "'>", this.objbase.SpecialDecode(row["Subject"].ToString()), " </a></span>" };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='margin-top: 8px; margin-left: 2px;float:left;' class='hidealert'>");
                    stringBuilder.Append("<div style='margin-top:1px;'>");
                    object[] item = new object[] { "<span id='imgdismiss_", num1, "' onclick=\"dismiss_alert_notification('", row["UniqueId"], "','", row["companyid"], "','", row["Type"].ToString(), "',this.id);return false;\" title='", _languageClass.GetLanguageConversion("Hide"), "' style='cursor:pointer; padding-left: 4px;'/>", _languageClass.GetLanguageConversion("Hide"), "</span>" };
                    stringBuilder.Append(string.Concat(item));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='margin-top: -1px; margin-left: 6px; margin-bottom:10px; width: 80%;'>");
                    object[] objArray1 = new object[] { "<span ><a href=javascript:void(null);Open_task_Call_details_FromHeader('", stringBuilder1.ToString().Trim(), "','TaskDiv_", num, "'); style='cursor:pointer; color:black;' title='", this.objbase.SpecialDecode(row["ContactName"].ToString().Trim()), " ", this.objbase.SpecialDecode(row["ClientName"].ToString()), "'>", this.objbase.SpecialDecode(row["ContactName"].ToString().Trim()), " ", this.objbase.SpecialDecode(row["ClientName"].ToString()), "</a></span>" };
                    stringBuilder.Append(string.Concat(objArray1));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='margin-top: -9px; margin-left: 6px;  margin-bottom:5px;'>");
                    string str4 = _commonClass.Eprint_return_DateTime_Before_View(row["Date"].ToString(), Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["UserID"]), false);
                    string[] strArrays1 = str4.ToString().Split(new char[] { ' ' });
                    string[] strArrays2 = new string[] { "<span Style='color: Gray; font-size: 10px; margin-left: 0px;' CssClass='normalText'>", strArrays1[0], " ", row["Time"].ToString(), "</span>" };
                    stringBuilder.Append(string.Concat(strArrays2));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    num1++;
                }
                else if (!flag2)
                {
                    stringBuilder.Append("<div id='DivtaskNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:none;'>");
                    stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                    stringBuilder.Append("</div>");
                    flag2 = true;
                }
                if (row["Type"].ToString().ToLower() != "call")
                {
                    if (flag3)
                    {
                        continue;
                    }
                    stringBuilder.Append("<div id='DivcallNorecords' style='margin-top: 8px; margin-left: 3px;float:left; display:none;'>");
                    stringBuilder.Append(string.Concat("<span style='margin-left:3px;'>", _languageClass.GetLanguageConversion("No_Records_Found"), "</span>"));
                    stringBuilder.Append("</div>");
                    flag3 = true;
                }
                else
                {
                    num++;
                    stringBuilder.Append("<div id='nocallrecords'>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append(string.Concat("<div id='CallDiv_", num, "'style='display:none;'>"));
                    stringBuilder.Append("<table  border='0' cellpadding='0' cellspacing='0' width='299px' class='rowtable' style='border-bottom:1px solid #E9E5E2;'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    base.Session["Popup"] = "Popup";
                    StringBuilder stringBuilder2 = new StringBuilder();
                    string[] strArrays3 = new string[] { "clientid=", row["clientid"].ToString(), "&isnew=2&bypass=1&type=", row["clienttype"].ToString(), "&TaskID=", row["UniqueID"].ToString(), "&ActivityType=", row["Type"].ToString() };
                    stringBuilder2.Append(string.Concat(strArrays3));
                    stringBuilder.Append("<div style='margin-top: 5px; margin-left: 5px; width:240px; float:left;'>");
                    object[] objArray2 = new object[] { "<span ><a href=javascript:void(null);Open_task_Call_details_FromHeader('", stringBuilder2.ToString().Trim(), "','CallDiv_", num, "'); style='cursor:pointer; color:black; font-weight:bold' title='", this.objbase.SpecialDecode(row["Subject"].ToString()), "'>", this.objbase.SpecialDecode(row["Subject"].ToString()), " </a></span>" };
                    stringBuilder.Append(string.Concat(objArray2));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='margin-top: 8px; margin-left: 2px;float:left;' class='hidealert'>");
                    stringBuilder.Append("<div style='margin-top:1px;'>");
                    object[] item1 = new object[] { "<span id='imgdismiss_", num2, "' onclick=\"dismiss_alert_notification('", row["UniqueId"], "','", row["companyid"], "','", row["Type"].ToString(), "',this.id);return false;\" title='", _languageClass.GetLanguageConversion("Hide"), "' style='cursor:pointer; padding-left: 4px;'>", _languageClass.GetLanguageConversion("Hide"), "</span>" };
                    stringBuilder.Append(string.Concat(item1));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='margin-top: -6px; margin-left: 6px;  margin-bottom:5px; width: 80%;'>");
                    object[] objArray3 = new object[] { "<span ><a href=javascript:void(null);Open_task_Call_details_FromHeader('", stringBuilder2.ToString().Trim(), "','CallDiv_", num, "'); style='cursor:pointer; color:black;' title='", this.objbase.SpecialDecode(row["ContactName"].ToString().Trim()), " ", this.objbase.SpecialDecode(row["ClientName"].ToString()), "'>", this.objbase.SpecialDecode(row["ContactName"].ToString().Trim()), " ", this.objbase.SpecialDecode(row["ClientName"].ToString()), "</a></span>" };
                    stringBuilder.Append(string.Concat(objArray3));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='margin-top: -4px; margin-left: 6px;  margin-bottom:5px;'>");
                    string str5 = _commonClass.Eprint_return_DateTime_Before_View(row["Date"].ToString(), Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["UserID"]), false);
                    string[] strArrays4 = str5.ToString().Split(new char[] { ' ' });
                    string[] strArrays5 = new string[] { "<span Style='color: Gray; font-size: 10px; margin-left: 0px;' CssClass='normalText'>", strArrays4[0], " ", row["Time"].ToString(), "</span>" };
                    stringBuilder.Append(string.Concat(strArrays5));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    num2++;
                }
            }
        }
        stringBuilder.Append("</div>");
        stringBuilder.Append("</div>");
        return string.Concat(stringBuilder.ToString(), "†", num);
    }

    [WebMethod]
    public string GetClientAll(string CompanyID, string SearchParameter)
    {
        CompanyBasePage companyBasePage = new CompanyBasePage();
        DataSet dataSet = companyBasePage.company_select(Convert.ToInt32(CompanyID), SearchParameter);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedClientAll.ascx", dataSet);
    }

    [WebMethod]
    public string GetColor(double Red, double Green, double Blue)
    {
        Convert.ToByte(Red);
        Convert.ToByte(Green);
        Convert.ToByte(Blue);
        Color color = new Color();
        color = Color.FromArgb(235, Convert.ToInt16(Red), Convert.ToInt16(Green), Convert.ToInt16(Blue));
        string str = color.R.ToString("X2");
        string str1 = color.G.ToString("X2");
        byte b = color.B;
        string str2 = string.Concat("#", str, str1, b.ToString("X2"));
        return str2;
    }

    [WebMethod]
    public string GetContactAddress(string CompID, string ContactID)
    {
        string str = CompanyBasePage.company_contact_address_select(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
        return str;
    }

    [WebMethod]
    public bool GetInvoiceContact(string CompID, string ContactID)
    {
        bool hasInvoiceContact = CompanyBasePage.HasInvoiceContact(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
        return hasInvoiceContact;
    }

    [WebMethod]
    public string GetContactName(string CompanyID, string ClientID, string SearchParameter)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        DataTable contactNames = DepartmentBaseClass.GetContactNames(Convert.ToInt32(ClientID), Convert.ToInt32(CompanyID), SearchParameter);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(contactNames);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedContact.ascx", dataSet);
    }

    [WebMethod(EnableSession = true)]
    public string GetCustomer(string CompanyID, string SearchParameter, string isDisplaySupplier)
    {
        BaseClass baseClass = new BaseClass();
        CompanyBasePage companyBasePage = new CompanyBasePage();
        SearchParameter = this.objbase.SpecialEncode(SearchParameter);
        DataTable dataTable = companyBasePage.company_customer_autocomplete(Convert.ToInt32(CompanyID), SearchParameter, isDisplaySupplier);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedCustomer.ascx", dataSet);
    }

    [WebMethod]
    public string GetCustomer_Report(string CompanyID, string SearchParameter, string isDisplaySupplier)
    {
        CompanyBasePage companyBasePage = new CompanyBasePage();
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        DataTable dataTable = companyBasePage.company_customer_autocomplete(Convert.ToInt32(CompanyID), SearchParameter, isDisplaySupplier);
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            dataTable.Columns[i].ReadOnly = false;
        }
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains("ClientName"))
                {
                    row["ClientName"] = this.objbase.SpecialDecode(row["ClientName"].ToString());
                }
                if (row.Table.Columns.Contains("Contacts"))
                {
                    row["Contacts"] = this.objbase.SpecialDecode(row["Contacts"].ToString());
                }
                if (row.Table.Columns.Contains("DeliveryAddress"))
                {
                    row["DeliveryAddress"] = this.objbase.SpecialDecode(row["DeliveryAddress"].ToString());
                }
                if (row.Table.Columns.Contains("DepartmentName"))
                {
                    row["DepartmentName"] = this.objbase.SpecialDecode(row["DepartmentName"].ToString());
                }
                if (row.Table.Columns.Contains("InvoiceAddress"))
                {
                    row["InvoiceAddress"] = this.objbase.SpecialDecode(row["InvoiceAddress"].ToString());
                }
                if (row.Table.Columns.Contains("ContactAddress"))
                {
                    row["ContactAddress"] = this.objbase.SpecialDecode(row["ContactAddress"].ToString());
                }
                if (!row.Table.Columns.Contains("ConcatDelAddress"))
                {
                    continue;
                }
                row["ConcatDelAddress"] = this.objbase.SpecialDecode(row["ConcatDelAddress"].ToString());
            }
        }
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedClientAll_Report.ascx", dataSet);
    }

    [WebMethod]
    public string GetCustomFieldAutoFill(long CompanyID, string SearchParameter, string StockType, string CustomField)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WarehouseCustomField_Autofill");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@SearchParameter", DbType.String, SearchParameter);
        database.AddInParameter(storedProcCommand, "@CustomField", DbType.String, CustomField);
        database.AddInParameter(storedProcCommand, "@StockType", DbType.String, StockType);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/userControl/AutoFill/MachedProductStockCustomField_Select.ascx", dataSet);
    }

    [WebMethod(EnableSession = true)]
    public void GetDefaultClient(int CompanyID, int ClientID, int ContactID)
    {
        (new CompanyBasePage()).client_defaultcontact(CompanyID, ClientID, ContactID);
    }

    [WebMethod]
    public string GetDeptAddressDetails(int CompanyID, int DeptID)
    {
        string empty = string.Empty;
        string str = string.Empty;
        string empty1 = string.Empty;
        DataSet deptAddressDetails = CompanyBasePage.GetDeptAddressDetails(CompanyID, DeptID);
        foreach (DataRow row in deptAddressDetails.Tables[0].Rows)
        {
            string[] strArrays = new string[] { row["InvoiceAddressID"].ToString(), "µ", row["Address"].ToString(), "µ", row["AddressLine2"].ToString(), "µ", row["City"].ToString(), "µ", row["State"].ToString(), "µ", row["ZipCode"].ToString(), "µ", row["Country"].ToString(), "µ", row["Telephone"].ToString(), "µ", row["Fax"].ToString(), "µ", row["AddressLabel"].ToString(), "µ" };
            str = string.Concat(strArrays);
        }
        foreach (DataRow dataRow in deptAddressDetails.Tables[1].Rows)
        {
            string[] str1 = new string[] { dataRow["DeliveryAddressID"].ToString(), "µ", dataRow["Address"].ToString(), "µ", dataRow["AddressLine2"].ToString(), "µ", dataRow["City"].ToString(), "µ", dataRow["State"].ToString(), "µ", dataRow["ZipCode"].ToString(), "µ", dataRow["Country"].ToString(), "µ", dataRow["Telephone"].ToString(), "µ", dataRow["Fax"].ToString(), "µ", dataRow["AddressLabel"].ToString(), "µ" };
            empty1 = string.Concat(str1);
        }
        return string.Concat(str, '±', empty1);
    }

    [WebMethod]
    public string GetEstimateTitle(int CompanyID, string SearchParameter)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        DataTable estimateTitleAutofill = CompanyBasePage.getEstimateTitle_autofill(CompanyID, SearchParameter);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(estimateTitleAutofill);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedEstimateTitle.ascx", dataSet);
    }

    [WebMethod(EnableSession = true)]
    public string GetGroupNames(string CompanyID, string GroupName)
    {
        DataTable dataTable = WebstoreBasePage.ProductCatalogueGroup_SelectViewAll(Convert.ToInt32(CompanyID), (long)0, GroupName);
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            dataTable.Columns[i].ReadOnly = false;
        }
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (!row.Table.Columns.Contains("GroupName"))
                {
                    continue;
                }
                row["GroupName"] = this.objbase.SpecialDecode(row["GroupName"].ToString());
            }
        }
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedGroupNames.ascx", dataSet);
    }

    [WebMethod]
    public string GetIncoiceAddressDetails(int CompanyID, int ClientID)
    {
        string empty = string.Empty;
        foreach (DataRow row in InvoiceBasePage.GetInvoiceAddressDetails(CompanyID, ClientID).Rows)
        {
            string[] str = new string[] { row["AddressID"].ToString(), "µ", row["AddressType"].ToString(), "µ", row["Address"].ToString(), "µ", row["ClientID"].ToString() };
            empty = string.Concat(str);
        }
        return empty;
    }

    [WebMethod]
    public string GetInks(int CompanyID, string ItemType, string InkType, string SearchParameter)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        DataTable dataTable = InventoryBasePage.autocomplete_inventory_selectink(Convert.ToInt32(CompanyID), ItemType, InkType, SearchParameter);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MachedInks.ascx", dataSet);
    }

    [WebMethod]
    public string GetIsConverted(int PriceCatalogueID, int DBID)
    {
        return SettingsBasePage.SelectIsConverted((long)PriceCatalogueID, (long)DBID);
    }

    [WebMethod]
    public string GetIsConvertedCroped(int PriceCatalogueID, int DBID)
    {
        return SettingsBasePage.SelectIsConverted_Croped((long)PriceCatalogueID, DBID);
    }

    [WebMethod]
    public string GetItemCodeTitle(int CompanyID, string SearchParameter)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        DataTable itemtitleItemcodeAutofill = CompanyBasePage.getItemtitleItemcode_autofill(CompanyID, SearchParameter);
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(itemtitleItemcodeAutofill);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedItemCodeTitle.ascx", dataSet);
    }

    [WebMethod]
    public string GetLanguageConversionJS(string languageKey)
    {
        return (new languageClass()).GetLanguageConversion(languageKey);
    }

    [WebMethod]
    public string GetMatrixValue(int OthercostID, int Qtytofind, int ID)
    {
        string empty = string.Empty;
        string str = string.Empty;
        string empty1 = string.Empty;
        string str1 = string.Empty;
        DataSet dataSet = OrderBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(OthercostID));
        DataTable item = dataSet.Tables[1];
        string str2 = "";
        StringBuilder stringBuilder = new StringBuilder();
        foreach (DataRow row in item.Rows)
        {
            stringBuilder.Append(string.Concat(row["FromQuantity"].ToString(), ",", row["ToQuantity"].ToString(), ","));
            str2 = row["matrixType"].ToString();
        }
        if (str2 == "pricebands")
        {
            string empty2 = string.Empty;
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = stringBuilder.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (Qtytofind == Convert.ToInt32(strArrays1[i]))
                {
                    empty2 = Qtytofind.ToString();
                }
            }
            if (empty2 == "")
            {
                if (Qtytofind < Convert.ToInt32(strArrays1[0].ToString()))
                {
                    empty2 = strArrays1[0].ToString();
                }
                else if (Qtytofind <= Convert.ToInt32(strArrays1[(int)strArrays1.Length - 2].ToString()))
                {
                    for (int j = 0; j < (int)strArrays1.Length - 3; j++)
                    {
                        if (Qtytofind > Convert.ToInt32(strArrays1[j].ToString()) && Qtytofind < Convert.ToInt32(strArrays1[j + 1].ToString()))
                        {
                            empty2 = strArrays1[j].ToString();
                        }
                    }
                }
                else
                {
                    empty2 = strArrays1[(int)strArrays1.Length - 2].ToString();
                }
            }
            DataTable dataTable = OrderBasePage.Select_OtherCostMatrix_Value((long)OthercostID, Convert.ToInt32(empty2));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                empty = dataRow["sellingPrice"].ToString();
                str = dataRow["Price"].ToString();
                empty1 = dataRow["Markup"].ToString();
                str1 = dataRow["matrixID"].ToString();
            }
        }
        object[] d = new object[] { empty, "~", ID, "~", str, "~", empty1, "~", str1, "~", Qtytofind.ToString() };
        empty = string.Concat(d);
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public int GetMaxKitAvail(long PricecatalogueID, int Quantity)
    {
        return (new BaseClass()).Check_MaxKit_Availability(PricecatalogueID, Quantity);
    }

    [WebMethod]
    public int GetNoOFContactForDept(int CompanyID, int UserID, int ClientID, int DeptID)
    {
        int num;
        DataTable dataTable = DepartmentBaseClass.department_getAllDetails(CompanyID, UserID, ClientID, (long)DeptID);
        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            if (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                num = Convert.ToInt32(current["NoOfContacts"].ToString());
            }
            else
            {
                return 0;
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        return num;
    }

    [WebMethod]
    public int GetNoOFCountForAddress(int CompanyID, int AddressID, int UserID)
    {
        int num;
        DataTable dataTable = CompanyBasePage.address_select_For_Edit(CompanyID, AddressID, UserID);
        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            if (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                num = Convert.ToInt32(current["NoOfCount"].ToString());
            }
            else
            {
                return 0;
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        return num;
    }

    [WebMethod(EnableSession = true)]
    public string GetNotificationCount()
    {
        commonClass _commonClass = new commonClass();
        DateTime now = DateTime.Now;
        string str = _commonClass.Eprint_return_DateTime_Before_View_For_AlertNotifications(now.ToString(), Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["userID"]), true);
        DataSet dataSet = DepartmentBaseClass.Crm_Select_Alert_Notifications(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["userID"]), str, true);
        int num = 0;
        if (dataSet.Tables.Count > 0 && dataSet.Tables[1].Rows.Count > 0)
        {
            IEnumerator enumerator = dataSet.Tables[1].Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    num = Convert.ToInt32(current["CountTask"].ToString());
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
        return num.ToString();
    }

    [WebMethod]
    public string GetSupplier(string CompanyID, string SearchParameter)
    {
        CompanyBasePage companyBasePage = new CompanyBasePage();
        SearchParameter = this.objbase.SpecialEncode(SearchParameter);
        DataTable dataTable = companyBasePage.company_autocomplete(Convert.ToInt32(CompanyID), "Supplier", SearchParameter);
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            dataTable.Columns[i].ReadOnly = false;
        }
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains("ClientName"))
                {
                    row["ClientName"] = this.objbase.SpecialDecode(row["ClientName"].ToString());
                }
                if (row.Table.Columns.Contains("Contacts"))
                {
                    row["Contacts"] = this.objbase.SpecialDecode(row["Contacts"].ToString());
                }
                if (row.Table.Columns.Contains("ConcatDelAddress"))
                {
                    row["ConcatDelAddress"] = this.objbase.SpecialDecode(row["ConcatDelAddress"].ToString());
                }
                if (!row.Table.Columns.Contains("ClientType"))
                {
                    continue;
                }
                row["ClientType"] = this.objbase.SpecialDecode(row["ClientType"].ToString());
            }
        }
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedSupplier.ascx", dataSet);
    }

    [WebMethod]
    public string GetSupplierProductDetails(int CompanyID, string SearchParameter)
    {
        SearchParameter = this.objbase.ReplaceSingleQuote(SearchParameter);
        SearchParameter = this.objbase.ReplaceDoubleQuote(SearchParameter);
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SupplierProductDetails_AutoComplete");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@SearchParameter", DbType.String, SearchParameter);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        dataSet.Tables.Add(dataTable);
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains("ItemtitleDisplay"))
                {
                    row["ItemTitleDisplay"] = this.objbase.SpecialDecode(row["ItemTitleDisplay"].ToString());
                }
                if (row.Table.Columns.Contains("ItemCode"))
                {
                    row["ItemCode"] = this.objbase.SpecialDecode(row["ItemCode"].ToString());
                }
                if (row.Table.Columns.Contains("DescriptionDisplay"))
                {
                    row["DescriptionDisplay"] = this.objbase.SpecialDecode(row["DescriptionDisplay"].ToString());
                }
                if (!row.Table.Columns.Contains("CustomerCode"))
                {
                    continue;
                }
                row["CustomerCode"] = this.objbase.SpecialDecode(row["CustomerCode"].ToString());
            }
        }
        return VuMgr.RenderView("~/userControl/AutoFill/MatchedSupplierProductDetails.ascx", dataSet);
    }

    [WebMethod]
    public string GetWarehouseLocation(int CompanyID, string SearchParameter)
    {
        SearchParameter = this.objbase.SpecialEncode(SearchParameter);
        DataTable dataTable = CompanyBasePage.getwarehouselocation_autofill(CompanyID, SearchParameter);
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            dataTable.Columns[i].ReadOnly = false;
        }
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (!row.Table.Columns.Contains("LocationName"))
                {
                    continue;
                }
                row["LocationName"] = this.objbase.SpecialDecode(row["LocationName"].ToString());
            }
        }
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return VuMgr.RenderView("~/UserControl/AutoFill/MatchedWarehouseLocation.ascx", dataSet);
    }

    [WebMethod]
    public string IsGalleryCategoryAssigned(long CategoryID, long UserID)
    {
        string str = "false";
        str = (!SettingsBasePage.IsGalleryCategoryAssigned(CategoryID, UserID).Contains("-1") ? "true" : "false");
        return str;
    }

    [WebMethod]
    public string IsGalleryImageAssigned(long ImageID, long UserID)
    {
        string str = "false";
        str = (!SettingsBasePage.IsGalleryImageAssigned(ImageID, UserID).Contains("-1") ? "true" : "false");
        return str;
    }

    [WebMethod(EnableSession = true)]
    public bool ISReplenishmnetItemExists(int CompanyID, long ReplenishModuleID, long EstimateItemID, string IsFrom)
    {
        bool flag;
        bool empty = false;
        DataTable dataTable = new DataTable();
        dataTable = EstimateBasePage.Select_EstimateItemDetails(CompanyID, ReplenishModuleID, EstimateItemID, IsFrom);
        foreach (DataRow row in dataTable.Rows)
        {
            bool b = bool.Parse(row["FlagRpt"].ToString());
            if (b)
            {
                empty = false; ///modification warehouse stage 2
                string cs = string.Empty;
                string pricecatalougeid = row["PriceCatalogueID"].ToString();
                string purchaseitemid = row["PurchaseItemID"].ToString();
                cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(cs);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(string.Concat("update tb_PriceCatalogueQty set flag = 0 where PriceCatalogueID=", pricecatalougeid, ";update tb_PurchaseItem set IsGoodsAdded = 1 where PurchaseItemID =", purchaseitemid), sqlConnection);
                pricecatalougeid = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();

            }
            else
            {
                empty = (EstimateBasePage.Select_EstimateItemDetails(CompanyID, ReplenishModuleID, EstimateItemID, IsFrom).Rows.Count <= 0 ? false : true);
            }
        }

        flag = empty;
        return flag;
    }

    [WebMethod(EnableSession = true)]
    public string IsStockItemProductCheck(long PriceCatalogueID)
    {
        string empty = string.Empty;
        BaseClass baseClass = new BaseClass();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsStockItemProductCheck");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            empty = string.Concat(row["Drawstockfrom"].ToString(), "~", row["IsStockItem"].ToString());
        }
        return empty;
    }

    [WebMethod]
    public string LoadDDLCostCentre(int CompamyID, int ClientID, int DepartmentID, int ContactID)
    {
        string empty = string.Empty;
        DataTable costCentreAutofill = EstimateBasePage.GetCostCentre_Autofill(CompamyID, ClientID, DepartmentID, ContactID);
        return costCentreAutofill.Rows[0][0].ToString();
    }

    [WebMethod]
    public void PaperUnitPrice_estimate_Lock_Unlock(string estItemId, string unitPrice)
    {
    }

    [WebMethod]
    public string ProductJobList_Select(long PriceCatalogueID, string SearchParameter)
    {
        return VuMgr.RenderView("~/usercontrol/AutoFill/MatchedJobRelease.ascx", WebstoreBasePage.ProductJobList_Select(PriceCatalogueID, SearchParameter));
    }

    [WebMethod]
    public void ProductVisibility(string type, string IDs)
    {
        if (type.ToLower() == "visible")
        {
            SettingsBasePage.ProductVisibility_Item("visible", IDs);
            return;
        }
        if (type.ToLower() == "invisible")
        {
            SettingsBasePage.ProductVisibility_Item("invisible", IDs);
        }
    }

    [WebMethod(EnableSession = true)]
    public long purchase_insert(string PurchaseID, string CompanyID, string hid_ClientID, string hid_ContactID, string hdnAddressID, string txtComments, string hid_FootNote, string lblPONo, string txtDate, string txtRefNo, string txtSuppQuote, string txtSuppInv, string ddlRaisedBy, string txtReqDate, string chkGoodsReceived, string chkInvoiceReceived, string ddlStatus, string UserID, string POCODE, string hid_AddressType, string PurEstimateID, string hid_HeaderText, string DeliveryAddressID, string DeliveryAddressType, string CourierID, string txtSuppInvDate, string chk_FollowupTask, string hidFollowupTask, string DateFormat, string pgmode, string EstimateID, string hdnTaskID)
    {
        commonClass _commonClass = new commonClass();
        DateTime now = DateTime.Now;
        DateTime dateTime = Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), Convert.ToInt32(CompanyID), Convert.ToInt32(UserID), true));
        long num = (long)0;
        num = PurchaseBasePage.purchase_insert((long)Convert.ToInt32(PurchaseID), Convert.ToInt32(CompanyID), Convert.ToInt32(hid_ClientID), Convert.ToInt32(hid_ContactID), Convert.ToInt64(hdnAddressID), txtComments, hid_FootNote, lblPONo, Convert.ToDateTime(txtDate), txtRefNo, txtSuppQuote, txtSuppInv, Convert.ToInt64(ddlRaisedBy), Convert.ToDateTime(txtReqDate), Convert.ToBoolean(chkGoodsReceived), Convert.ToBoolean(chkInvoiceReceived), Convert.ToInt32(ddlStatus), Convert.ToInt32(UserID), Convert.ToInt32(UserID), dateTime, Convert.ToInt64(POCODE), hid_AddressType, Convert.ToInt64(PurEstimateID), hid_HeaderText, (long)0, dateTime, Convert.ToInt64(DeliveryAddressID), DeliveryAddressType, Convert.ToInt32(CourierID), (long)0, Convert.ToDateTime(txtSuppInvDate), "");
        return num;
    }

    [WebMethod(EnableSession = true)]
    public void purchaseitem_delete(long CompanyID, long DelItemID, long PurchaseID)
    {
        PurchaseBasePage.purchaseitem_delete(Convert.ToInt32(CompanyID), Convert.ToInt64(DelItemID), PurchaseID);
    }

    [WebMethod(EnableSession = true)]
    public long purchaseitem_insert_new(string CompanyID, string PurchaseItemID, string ret, string ItemID, string ItemType, string ItemCode, string ItemDesc, string ItemQty, string PackedIn, string PackedPrice, string Tax, string TaxValue, string AccountCodeID, string Notes, string GoodsReceived, string EstimateItemID, string AdditionalOptionDetails, bool IsCompleted)
    {
        long num = (long)0;
        num = PurchaseBasePage.purchaseitem_insert_new(Convert.ToInt32(CompanyID), Convert.ToInt64(PurchaseItemID), Convert.ToInt64(ret), Convert.ToInt64(ItemID), ItemType, ItemCode, ItemDesc, Convert.ToDecimal(ItemQty), Convert.ToDecimal(PackedIn), Convert.ToDecimal(PackedPrice), Convert.ToInt32(Tax), Convert.ToDecimal(TaxValue), Convert.ToInt32(AccountCodeID), Notes, Convert.ToBoolean(GoodsReceived), Convert.ToInt64(EstimateItemID), ItemType, AdditionalOptionDetails, IsCompleted);
        return num;
    }

    [WebMethod]
    public string RemoveSubItemsNew1(string EstType, long EstmateItemID, int CompanyID, int UserID, string UserName, long EstimateID, long ParentEstItemID, string MainType, string ModuleType)
    {
        notesclass _notesclass = new notesclass();
        Notes note = new Notes();
        commonClass _commonClass = new commonClass();
        string empty = string.Empty;
        string str = string.Empty;
        string empty1 = string.Empty;
        DataTable dataTable = Notes.select_item_number_for_Activity_History(EstimateID, Convert.ToInt64(ParentEstItemID), ModuleType);
        foreach (DataRow row in dataTable.Rows)
        {
            empty = row["rownumber"].ToString();
        }
        foreach (DataRow dataRow in Notes.select_EstimateType_for_Activity_History(EstimateID, Convert.ToInt64(ParentEstItemID)).Rows)
        {
            empty1 = dataRow["EstimateType"].ToString();
        }
        DataTable dataTable1 = Notes.select_item_Title_for_Activity_History(CompanyID, EstimateID, Convert.ToInt64(ParentEstItemID), empty1);
        foreach (DataRow row1 in dataTable1.Rows)
        {
            str = row1["itemtitle"].ToString();
        }
        _notesclass.Item_number = string.Concat("Item ", empty);
        _notesclass.Item_title = str;
        _notesclass.ModuleName = "estimate";
        _notesclass.NotesType = Convert.ToString(Notes.NotesType.EstSubItemDelte);
        _notesclass.ModuleID = EstimateID;
        _notesclass.CustomerName = UserName;
        DateTime now = DateTime.Now;
        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
        _notesclass.CompanyID = CompanyID;
        _notesclass.UserID = UserID;
        note.NotesAdd(_notesclass);
        EstimatesBasePage.estimate_subitem_delete_FromSummary(EstType, EstmateItemID);
        object[] estimateID = new object[] { EstimateID, "~", ParentEstItemID, "~", MainType };
        return string.Concat(estimateID).ToString();
    }

    [WebMethod(EnableSession = true)]
    public string ReturnCustomerInfoWithAllNotes(string CompanyID, string ClientID, string CompanyType)
    {
        languageClass _languageClass = new languageClass();
        commonClass _commonClass = new commonClass();
        StringBuilder stringBuilder = new StringBuilder();
        BaseClass baseClass = new BaseClass();
        DataSet dataSet = DepartmentBaseClass.CRM_Print_Customer_Info_with_Main_Contact_and_Address(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID), CompanyType);
        try
        {
            if (dataSet.Tables.Count > 0)
            {
                Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    commonClass _commonClass1 = new commonClass();
                    stringBuilder.Append("<div style='width:1000px; margin-top:5px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:12px; margin-left:1px;'>", _languageClass.GetLanguageConversion("Customer_Deatils"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:15px;'>");
                    stringBuilder.Append("<table style='width:1000px;' border='0' cellpadding='0' cellspacing='0'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Name"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["clientName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["DefaultContactName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Sales_Person"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["SalesPersonName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Phone"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", row["Mobile"].ToString(), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Number"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["CompanyNumber"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Email"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["BusinessEmail"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["ctype"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:20px; margin-bottom:15px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:13px; margin-left:1px; margin-bottom:10px;'>", _languageClass.GetLanguageConversion("Account_Notes"), "</span>"));
                    stringBuilder.Append("</div>");
                }
            }
        }
        catch
        {
        }
        DataSet dataSet1 = DepartmentBaseClass.CRM_Select_TopFiveNotes(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID));
        try
        {
            if (dataSet1.Tables.Count > 0)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                int num1 = 0;
                foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                {
                    BaseClass baseClass1 = new BaseClass();
                    commonClass _commonClass2 = new commonClass();
                    string str = _commonClass2.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(dataRow["createDate"].ToString(), Convert.ToInt32(CompanyID), num, false);
                    string[] strArrays = str.Split(new char[] { ' ' });
                    string empty = string.Empty;
                    int num2 = Convert.ToInt32(dataRow["attachmentId"].ToString());
                    DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
                    stringBuilder.Append("<div style='width:800px; border-bottom:1px solid #EFEFEF;'>");
                    stringBuilder.Append("<table>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td colspan='6' style='margin-top:8px; width:800px'>");
                    stringBuilder.Append("<div style='float:left;'>");
                    stringBuilder.Append(string.Concat("<span style='font-weight:bold;'>", baseClass1.SpecialDecode(dataRow["title"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    int num3 = 0;
                    Label label = new Label()
                    {
                        ID = string.Concat("lbl_notes_", num3 + 1),
                        Text = dataRow["subject"].ToString().Replace(Environment.NewLine, "~±")
                    };
                    string[] strArrays1 = label.Text.Split(new char[] { '~' });
                    string empty1 = string.Empty;
                    if ((int)strArrays1.Length > 0)
                    {
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            empty1 = string.Concat(empty1, baseClass1.InsertAtIntervals(strArrays1[i], 180, "<br/>"));
                        }
                    }
                    label.Text = baseClass1.SpecialDecode(empty1.Replace("\n", "<br/>"));
                    if (dataRow["title"].ToString() == "")
                    {
                        stringBuilder.Append("<td colspan='6' style='margin-top:-7px;'>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span>", HttpUtility.HtmlDecode(label.Text), "</span>"));
                        stringBuilder.Append("<div>");
                        stringBuilder.Append("</td>");
                    }
                    else
                    {
                        stringBuilder.Append("<td colspan='6'>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span>", HttpUtility.HtmlDecode(label.Text), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    if (dataRow["filename"].ToString() == "")
                    {
                        stringBuilder.Append("<td style='margin-bottom:7px;height:18px;'>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span style='color:#4D77E8;font-size:10px;'>", baseClass1.SpecialDecode(dataRow["UserName"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span style='margin-left:10px; color: gray;font-size:10px;'>", strArrays[0], "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                    }
                    else
                    {
                        stringBuilder.Append("<td style='margin-bottom:7px;height:18px;'>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span style='color:#4D77E8; font-size:10px;'>", baseClass1.SpecialDecode(dataRow["UserName"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("<div style='float:left;'>");
                        stringBuilder.Append(string.Concat("<span style='margin-left:10px; color: gray;font-size:10px;'>", strArrays[0], "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='float:right;'>");
                    object[] objArray = new object[] { "<span id='DeleteNotes_", num1, "' style='margin-left:5px; display:none'><a href='javascript://'><img title='Delete Note' src='../images/delete.gif' style='cursor:pointer;' onclick=\"delete_note('", num2, "');return false;\"/> </a></span>" };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='float:right;'>");
                    stringBuilder.Append(string.Concat("<span id='Seprator_", num1, "' style='display:none;'>&nbsp;</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='float:right;'>");
                    object[] objArray1 = new object[] { "<span id='EditNotes_", num1, "' style='margin-left:10px;display:none;'><a href='javascript://'><img onclick=\"Edit_notes('", num2, "');return false;\" title='Edit Note' src='../images/Edit.gif' style='cursor:pointer;'/> </a></span>" };
                    stringBuilder.Append(string.Concat(objArray1));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='float:right; display:none;'>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td style='float:right'>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    num1++;
                }
            }
        }
        catch
        {
        }
        return stringBuilder.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string ReturnCustomerInfoWithDeptInfo(string CompanyID, string ClientID, string CompanyType)
    {
        languageClass _languageClass = new languageClass();
        commonClass _commonClass = new commonClass();
        StringBuilder stringBuilder = new StringBuilder();
        BaseClass baseClass = new BaseClass();
        DataSet dataSet = DepartmentBaseClass.CRM_Print_Customer_Info_with_Main_Contact_and_Address(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID), CompanyType);
        try
        {
            if (dataSet.Tables.Count > 0)
            {
                Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    commonClass _commonClass1 = new commonClass();
                    stringBuilder.Append("<div style='width:1000px; margin-top:5px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:12px; margin-left:1px;'>", _languageClass.GetLanguageConversion("Customer_Deatils"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:15px;'>");
                    stringBuilder.Append("<table style='width:1000px;' border='0' cellpadding='0' cellspacing='0'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Name"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["clientName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["DefaultContactName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Sales_Person"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["SalesPersonName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Phone"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", row["Mobile"].ToString(), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Number"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["CompanyNumber"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Email"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["BusinessEmail"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["ctype"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:20px; margin-bottom:15px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:13px; margin-left:1px; margin-bottom:10px;'>", _languageClass.GetLanguageConversion("Department_Information"), "</span>"));
                    stringBuilder.Append("</div>");
                }
            }
        }
        catch
        {
        }
        DataSet dataSet1 = DepartmentBaseClass.CRM_Print_Customer_Info_with_Dept_Info(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID));
        try
        {
            if (dataSet1.Tables.Count > 0)
            {
                Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                stringBuilder.Append("<table id='tbOpenActivities' style='width:1000px' cellpadding='0' cellspacing='0'>");
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<td class='bgcustomizeNew' style='width:200px;'>");
                stringBuilder.Append("<div style='margin-left:5px;'>");
                stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Department_Name"), "</span>"));
                stringBuilder.Append("</div>");
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td class='bgcustomizeNew' style='width:400px;'>");
                stringBuilder.Append("<div style='margin-top:0px;'>");
                stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Delivery_Address"), "</span>"));
                stringBuilder.Append("</div>");
                stringBuilder.Append("</td>");
                stringBuilder.Append("<td class='bgcustomizeNew' style='width:400px;'>");
                stringBuilder.Append("<div style='margin-top:0px;'>");
                stringBuilder.Append(string.Concat("<span style='color:black;font-weight:bold;'>", _languageClass.GetLanguageConversion("Invoice_Address"), "</span>"));
                stringBuilder.Append("</div>");
                stringBuilder.Append("</td>");
                stringBuilder.Append("</tr>");
                if (dataSet1.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                    {
                        stringBuilder.Append("<tr>");
                        stringBuilder.Append("<td valign='top' class='NewTableRowsNew' style='width:200px;'>");
                        stringBuilder.Append("<div style='margin-top:2px;margin-bottom:2px; margin-left:5px;'>");
                        stringBuilder.Append(string.Concat("<span style='line-height:20px;'>", baseClass.SpecialDecode(dataRow["DepartmentName"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("<td  valign='top' class='NewTableRowsNew' style='width:400px;'>");
                        stringBuilder.Append("<div style='margin-top:2px;margin-bottom:2px;'>");
                        stringBuilder.Append(string.Concat("<span style='line-height:20px;'>", baseClass.SpecialDecode(dataRow["DeliveryAddress"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("<td  valign='top' class='NewTableRowsNew' style='width:400px;'>");
                        stringBuilder.Append("<div style='margin-top:2px; margin-bottom:2px;'>");
                        stringBuilder.Append(string.Concat("<span style='line-height:20px;'>", baseClass.SpecialDecode(dataRow["InvoiceAddress"].ToString()), "</span>"));
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>");
                        stringBuilder.Append("</tr>");
                    }
                }
                stringBuilder.Append("</table>");
            }
        }
        catch
        {
        }
        return stringBuilder.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string ReturnCustomerInfoWithMainContact(string CompanyID, string ClientID, string CompanyType)
    {
        languageClass _languageClass = new languageClass();
        commonClass _commonClass = new commonClass();
        StringBuilder stringBuilder = new StringBuilder();
        BaseClass baseClass = new BaseClass();
        DataSet dataSet = DepartmentBaseClass.CRM_Print_Customer_Info_with_Main_Contact_and_Address(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID), CompanyType);
        try
        {
            if (dataSet.Tables.Count > 0)
            {
                Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    commonClass _commonClass1 = new commonClass();
                    stringBuilder.Append("<div style='width:1000px; margin-top:5px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:12px; margin-left:1px;'>", _languageClass.GetLanguageConversion("Customer_Details"), ":</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:15px;'>");
                    stringBuilder.Append("<table style='width:1000px;' border='0' cellpadding='0' cellspacing='0'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Name"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["clientName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["DefaultContactName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Sales_Person"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["SalesPersonName"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Phone"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", row["Mobile"].ToString(), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Company_Number"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["CompanyNumber"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Default_Contact_Email"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["BusinessEmail"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Type"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style=' width:320px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["ctype"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:15px;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText' style='font-weight:bold; font-size:12px; margin-left:1px;'>", _languageClass.GetLanguageConversion("Default_Address"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div style='width:1000px; margin-top:15px;'>");
                    stringBuilder.Append("<table style='width:1000px;' border='0' cellpadding='0' cellspacing='0'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Billing_Address"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:830px;'>");
                    stringBuilder.Append("<div style='width:820px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["DefaultcontactDepartmentInvoiceAddress"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td valign='top' style='width:170px;'>");
                    stringBuilder.Append("<div style='width:170px; float: left;background-color: #EEEEEE;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", _languageClass.GetLanguageConversion("Delivery_Address"), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("<td valign='top' style='width:830px;'>");
                    stringBuilder.Append("<div style='width:820px; float: left;padding: 5px; clear: left; vertical-align: middle; margin: 0px 0px 2px 0px;font-size:11px;color:Black;'>");
                    stringBuilder.Append(string.Concat("<span class='normalText'>", baseClass.SpecialDecode(row["DefaultcontactDepartmentDelAddress"].ToString()), "</span>"));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("</div>");
                }
            }
        }
        catch
        {
        }
        return stringBuilder.ToString();
    }

    [WebMethod]
    public string Select_OtherCostAdditional_ItemsDetail(string OthercostID)
    {
        string empty = string.Empty;
        string str = string.Empty;
        DataSet dataSet = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(OthercostID));
        foreach (DataRow row in dataSet.Tables[1].Rows)
        {
            empty = string.Concat(empty, "@", row["Label"].ToString());
            str = string.Concat(str, "@", row["FormulaNew"].ToString());
        }
        return string.Concat(empty, "♠", str);
    }

    [WebMethod]
    public string SubAdditionalOptions_Values(string ChoiceID, string OthercostID)
    {
        string empty = string.Empty;
        string str = string.Empty;
        DataTable dataTable = WebstoreBasePage.SubAdditionalOptions_Values(Convert.ToInt32(ChoiceID), Convert.ToInt32(OthercostID));
        foreach (DataRow row in dataTable.Rows)
        {
            empty = string.Concat(empty, "@", row["WebOtherCostName"].ToString());
            str = string.Concat(str, row["webothercostid"].ToString(), "^");
        }
        return string.Concat(empty, "$", str);
    }

    [WebMethod]
    public void SubTotal_estimate_Lock_Unlock(string EstTotalID, string LockOrUnlock)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_Lock_Unlock");
        database.AddInParameter(storedProcCommand, "@EstTotalID", DbType.String, EstTotalID);
        database.AddInParameter(storedProcCommand, "@LockOrUnlock", DbType.Int32, LockOrUnlock);
        database.ExecuteNonQuery(storedProcCommand);
    }

    [WebMethod(EnableSession = true)]
    public void UpgradeNotificationClose()
    {
        string versionNumber = ConnectionClass.VersionNumber;
        DataTable dataTable = new DataTable();
        foreach (DataRow row in EstimateBasePage.Notification_select(versionNumber).Rows)
        {
            string str = row["Notification"].ToString();
            long num = Convert.ToInt64(row["NotificationID"]);
            if (string.IsNullOrEmpty(str))
            {
                continue;
            }
            EstimateBasePage.NoticationSeen_insert(Convert.ToInt64(base.Session["userID"]), num);
        }
    }
}
//}