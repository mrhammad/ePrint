using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using nmsLogin;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BaseClass : System.Web.UI.Page
{
    public languageClass objLanguage = new languageClass();

    public static string ExportReport;

    private loginClass login = new loginClass();

    public string tabcolor = "";

    public int companyid;

    public BasePage objpage = new BasePage();

    public string Padding;

    public string rtn;

    public string strSitepath = global.sitePath();

    public string TemplatesitePath = global.TemplatesitePath();

    public string strImagepath = global.imagePath();

    public string strFilepath = global.filePath();

    public string strSecureDocFilepath = global.SecureDocFilepath();

    public string SecureDocPath = global.SecureDocPath();

    public string SecureSitePath = global.SecureSitePath();

    public string PublicDocPath = global.PublicDocPath();

    public string SecureVirtualPath = global.SecureVirtualPath();

    public static string isDelete;

    protected Random rGen;

    protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    protected Random rNewGen;

    protected string[] strNewCharacters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

    static BaseClass()
    {
        BaseClass.ExportReport = string.Empty;
        BaseClass.isDelete = "0";
    }

    public BaseClass()
    {
        StringWriter stringWriter = new StringWriter();
        this.Padding = "&nbsp;&nbsp;&nbsp;";
        base.Server.HtmlDecode(this.Padding, stringWriter);
        this.Padding = stringWriter.ToString();
    }

    private static bool TryParseTimeZoneOrderNumber(string value, out double orderNumber)
    {
        return double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out orderNumber);
    }

    private double GetSessionTimeZoneOrderNumber(double serverTimeZoneOrderNumber)
    {
        if (this.Session == null || this.Session["TimeZoneOrderNumber"] == null)
        {
            return serverTimeZoneOrderNumber;
        }
        double orderNumber;
        if (TryParseTimeZoneOrderNumber(this.Session["TimeZoneOrderNumber"].ToString(), out orderNumber))
        {
            return orderNumber;
        }
        return serverTimeZoneOrderNumber;
    }

    public string ApplyTimeZone(string date)
    {
        double num;
        TryParseTimeZoneOrderNumber(global.ServerTimeZoneOrderNumber(), out num);
        int num1 = 0;
        int.TryParse(global.AdjustableNumber(), out num1);
        double num2 = 0;
        double num3 = 0;
        if (this.Session != null && this.Session["TimeZoneOrderNumber"] != null)
        {
            double num4;
            if (!TryParseTimeZoneOrderNumber(this.Session["TimeZoneOrderNumber"].ToString(), out num4))
            {
                num4 = num;
            }
            if (num > num4)
            {
                double num5 = num4 - num;
                string[] strArrays = num5.ToString("N2").ToString().Split(new char[] { '.' });
                num2 = Convert.ToDouble(strArrays[0]);
                num3 = Convert.ToDouble(strArrays[1]);
                if (num3 < -30)
                {
                    num3 = -30;
                }
            }
            else if (num >= num4)
            {
            }
            else
            {
                double num6 = num4 - num;
                string[] strArrays1 = num6.ToString("N2").ToString().Split(new char[] { '.' });
                num2 = Convert.ToDouble(strArrays1[0]);
                num3 = Convert.ToDouble(strArrays1[1]);
                if (num3 > 30)
                {
                    num3 = 30;
                }
            }
            if (num1 != 0)
            {
                num2 = num2 - (double)num1;
            }
        }
        DateTime dateTime = Convert.ToDateTime(date);
        dateTime = dateTime.AddHours(num2);
        dateTime = dateTime.AddMinutes(num3);
        dateTime = dateTime.AddSeconds(0);
        return dateTime.ToString();
    }

    public void callJavascript(Control ctrPanel, string divid)
    {
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(ctrPanel, ctrPanel.GetType(), "setLoadingPositionOfDivMove__", string.Concat("setLoadingPositionOfDivMove(document.getElementById('", divid, "'));"), true);
    }

    public string callstockreplenish_process(long UserID, long CompanyID, long PriceCatalogueID, int Quantity, string ProductStockType, long EstimateItemID, long OrderID, long OrderItemId, string JobNumber, long EstimateID)
    {
        DataTable dataTable = new DataTable();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_StockReplenish_Process");
        database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
        database.AddInParameter(storedProcCommand, "@ProductStockType", DbType.String, ProductStockType);
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
        database.AddInParameter(storedProcCommand, "@OrderItemId", DbType.Int64, OrderItemId);
        database.AddInParameter(storedProcCommand, "@JobNumber", DbType.String, JobNumber);
        database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
        database.ExecuteNonQuery(storedProcCommand);
        this.UpdateKitProduct_StockLevels(PriceCatalogueID, Quantity, "replenish");
        return "Stock Replenished successfully";
    }

    public void CallStyle(PlaceHolder plhStyle, string tabcolor, string forecolor)
    {
        plhStyle.Controls.Add(new LiteralControl("<style>"));
        plhStyle.Controls.Add(new LiteralControl(".navigator"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl("font-size:11px;"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("color:", forecolor, ";")));
        plhStyle.Controls.Add(new LiteralControl("font-family:Verdana,Arial;"));
        plhStyle.Controls.Add(new LiteralControl("font-weight: Bold;"));
        plhStyle.Controls.Add(new LiteralControl("vertical-align: middle;"));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl(".navigatorpanel,.loggedin"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl("font-size:11px;"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("color:", forecolor, ";")));
        plhStyle.Controls.Add(new LiteralControl("FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;"));
        plhStyle.Controls.Add(new LiteralControl("font-weight: Bold;"));
        plhStyle.Controls.Add(new LiteralControl("vertical-align: middle;"));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl(".bgcustomize"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("background-color:", tabcolor, ";")));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("color:", forecolor, ";")));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl("A.subnavigator,A.subnavigator:hover,A.subnavigator:visited"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl("text-decoration: none;"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("COLOR:", forecolor, ";")));
        plhStyle.Controls.Add(new LiteralControl("FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;"));
        plhStyle.Controls.Add(new LiteralControl("font-weight: Bold;"));
        plhStyle.Controls.Add(new LiteralControl("FONT-SIZE: 11px;"));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl(".norecords"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl("font-size:11px;"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("color:", forecolor, ";")));
        plhStyle.Controls.Add(new LiteralControl("vertical-align: middle;"));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl("div.t"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("height: 23px;padding: 0;margin: 0;overflow: hidden;vertical-align:middle;color:", forecolor, ";")));
        ControlCollection controls = plhStyle.Controls;
        string[] strArrays = new string[] { "background:", tabcolor, " url(", this.strImagepath, "j_border.png) 0 0 repeat-x;" };
        controls.Add(new LiteralControl(string.Concat(strArrays)));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl("div.t div.t"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("background:url(", this.strImagepath, "rt_tabnotch.gif) 100% 0 no-repeat;")));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl("div.t div.t div.t"));
        plhStyle.Controls.Add(new LiteralControl("{"));
        plhStyle.Controls.Add(new LiteralControl(string.Concat("background: url(", this.strImagepath, "lt_tabnotch.gif) 0 0 no-repeat;")));
        plhStyle.Controls.Add(new LiteralControl("}"));
        plhStyle.Controls.Add(new LiteralControl("</style>"));
    }

    public string CapitalizeWords(string value)
    {
        StringBuilder stringBuilder = new StringBuilder(value);
        try
        {
            stringBuilder[0] = char.ToUpper(stringBuilder[0]);
            if (stringBuilder[0] == '\'' || stringBuilder[0] == '\"')
            {
                for (int i = 2; i < stringBuilder.Length; i++)
                {
                    if (!char.IsWhiteSpace(stringBuilder[i - 1]))
                    {
                        stringBuilder[i] = char.ToLower(stringBuilder[i]);
                    }
                    else
                    {
                        stringBuilder[i] = char.ToUpper(stringBuilder[i]);
                    }
                }
            }
            else
            {
                for (int j = 1; j < stringBuilder.Length; j++)
                {
                    if (!char.IsWhiteSpace(stringBuilder[j - 1]))
                    {
                        stringBuilder[j] = char.ToLower(stringBuilder[j]);
                    }
                    else
                    {
                        stringBuilder[j] = char.ToUpper(stringBuilder[j]);
                    }
                }
            }
        }
        catch
        {
        }
        return stringBuilder.ToString();
    }

    public string capsconvertion(string sectionname)
    {
        string str = sectionname;
        string str1 = str;
        if (str != null)
        {
            switch (str1)
            {
                case "lead":
                    {
                        this.rtn = "Lead";
                        break;
                    }
                case "contact":
                    {
                        this.rtn = "Contact";
                        break;
                    }
                case "client":
                    {
                        this.rtn = "Client";
                        break;
                    }
                case "opportunity":
                    {
                        this.rtn = "Opportunity";
                        break;
                    }
                case "forecast":
                    {
                        this.rtn = "Forecast";
                        break;
                    }
                case "campaign":
                    {
                        this.rtn = "Campaign";
                        break;
                    }
                case "product":
                    {
                        this.rtn = "Product";
                        break;
                    }
                case "asset":
                    {
                        this.rtn = "Asset";
                        break;
                    }
                case "solution":
                    {
                        this.rtn = "Solution";
                        break;
                    }
                case "ticket":
                    {
                        this.rtn = "Ticket";
                        break;
                    }
                case "contract":
                    {
                        this.rtn = "Contract";
                        break;
                    }
            }
        }
        return this.rtn;
    }

    public string Check_Estimate_Possible(long PriceCatalogueID, int Quantity, string Module, long JobItemStatusID)
    {
        long num = (long)0;
        string empty = string.Empty;
        if (!string.IsNullOrEmpty(Convert.ToString(this.Session["CompanyID"])) || Convert.ToUInt64(this.Session["CompanyID"]) != (long)0)
        {
            num = Convert.ToInt64(this.Session["CompanyID"].ToString());
        }
        foreach (DataRow row in this.ProductStockType_Select(num, PriceCatalogueID).Rows)
        {
            if (row["DrawStockFrom"].ToString().ToLower() == "s" || row["DrawStockFrom"].ToString().ToLower() == "a" || row["DrawStockFrom"].ToString().ToLower() == "m" || row["DrawStockFrom"].ToString().ToLower() == "x")
            {
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DataSet dataSet = new DataSet();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CheckEstimatePossible");
                database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, num);
                database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
                database.AddInParameter(storedProcCommand, "@DrawStockFrom", DbType.String, row["DrawStockFrom"].ToString().ToLower());
                database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
                database.AddInParameter(storedProcCommand, "@JobItemStatusID", DbType.Int64, JobItemStatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand);
                if (dataSet.Tables.Count <= 0)
                {
                    continue;
                }
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    empty = dataRow["IsEstimatePossible"].ToString();
                }
            }
            else
            {
                if (row["DrawStockFrom"].ToString().ToLower() != "o")
                {
                    continue;
                }
                int num1 = 0;
                num1 = this.Check_MaxKit_Availability(PriceCatalogueID, Quantity);
                if (row["IsBackOrder"].ToString().ToLower() != "false")
                {
                    empty = (Quantity <= num1 || !(Module == "invoice") ? "true" : "false");
                }
                else
                {
                    empty = (Quantity <= num1 ? "true" : "false");
                }
            }
        }
        return empty;
    }

    public int Check_MaxKit_Availability(long PriceCatalogueID, int NumberOfKit)
    {
        string empty = string.Empty;
        int num = 0;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActualKitStockDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@NumberOfKit", DbType.Int32, NumberOfKit);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            int[] numArray = new int[item.Rows.Count];
            for (int i = 0; i < item.Rows.Count; i++)
            {
                numArray[i] = Convert.ToInt32(item.Rows[i]["MaxNumKitAvailable"].ToString());
            }
            num = ((int)numArray.Length <= 0 ? 0 : numArray.Min());
        }
        if (num != 0)
        {
            return num;
        }
        return num;
    }

    public string Check_Rerun_Delete_Revert_On_Reduction(long PriceCatalogueID, long CompanyID, long EstimateItemID, long EstimateID, string DrawStockFrom)
    {
        string empty = string.Empty;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Check_Rerun_Delete_Revert_On_Reduction");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["IsDisplay"].ToString();
            }
        }
        return empty;
    }

    public bool Check_SpecialPrivilege_For_User(long UserID, long CompanyID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Check_SpecialPrivilege_For_User");
        database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        return (bool)database.ExecuteScalar(storedProcCommand);
    }

    public int CheckForDST(double CustomerOrderNo)
    {
        int num = Convert.ToInt32(global.AdjustableNumber());
        int num1 = 0;
        if (CustomerOrderNo == 23 && num != 0)
        {
            num1 = 1;
        }
        return num1;
    }

    public string CheckforStockReplenished(long EstimateItemID)
    {
        commonClass _commonClass = new commonClass();
        Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Check_ProductStock_Replenished");
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.String, 10);
        database.ExecuteNonQuery(storedProcCommand);
        _commonClass.closeConnection();
        object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
        return (parameterValue == null ? "false" : parameterValue.ToString());
    }

    public string CheckReplenished_ToProcessAllocation(long EstimateID)
    {
        commonClass _commonClass = new commonClass();
        Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CheckReplenished_ToProcessAllocation");
        database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
        database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.String, 10);
        database.ExecuteNonQuery(storedProcCommand);
        _commonClass.closeConnection();
        object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
        return (parameterValue == null ? "false" : parameterValue.ToString());
    }

    private void CheckUserAccessRight()
    {
        string empty = string.Empty;
        empty = this.GetSubDomainName(base.Request.Url.ToString());
        string str = string.Empty;
        string[] strArrays = base.Request.Url.AbsolutePath.Split(new char[] { '/' });
        if (empty.Length > 0 && empty.ToLower() != "www" && empty.ToLower() != "192")
        {
            if ((int)strArrays.Length > 1)
            {
                str = Convert.ToString(strArrays[1]);
            }
        }
        else if ((int)strArrays.Length > 2)
        {
            str = Convert.ToString(strArrays[2]);
        }
        bool flag = true;
        SqlCommand sqlCommand = new SqlCommand("pc_CheckUserAccessRight", (new commonClass()).openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        if (this.Session["userID"] != null)
        {
            sqlCommand.Parameters.Add("@userid", long.Parse(this.Session["userID"].ToString()));
        }
        else
        {
            sqlCommand.Parameters.Add("@userid", SqlDbType.BigInt);
        }
        if (str.ToLower() == "client" || str.ToLower() == "accounts")
        {
            str = "clients";
        }
        if (str.ToLower() == "setting" || str.ToLower() == "settings")
        {
            str = "SETTINGS";
        }
        if (str.ToLower() == "estimate")
        {
            str = "ESTIMATES";
        }
        if (str.ToLower() == "job")
        {
            str = "JOBS";
        }
        if (str.ToLower() == "purchase")
        {
            str = "PURCHASES";
        }
        if (str.ToLower() == "invoice")
        {
            str = "INVOICES";
        }
        if (str.ToLower() == "document")
        {
            str = "DOCUMENTS";
        }
        if (str.ToLower() == "report")
        {
            str = "REPORTS";
        }
        if (str.ToLower() == "delivery")
        {
            str = "DELIVERYNOTE";
        }
        if (str.ToLower() == "contact")
        {
            str = "clients";
        }
        if (str.ToLower() == "orders")
        {
            str = "webstoreorder";
        }
        if (str.ToLower() == "storesettings")
        {
            str = "SETTINGS";
        }
        if (base.Request.Url.AbsolutePath.ToLower().Contains("report.aspx"))
        {
            sqlCommand.Parameters.AddWithValue("@tabnameReport", "REPORTS");
            if (str.ToLower() == "common")
            {
                str = "REPORTS";
            }
        }
        else
        {
            if (str.Contains(".aspx"))
            {
                str = "Home";
            }
            if (str.ToLower() == "common" && base.Request.Url.AbsolutePath.ToLower().Contains("usermore.aspx"))
            {
                str = "settings";
            }
            sqlCommand.Parameters.AddWithValue("@tabnameReport", "none");
        }
        sqlCommand.Parameters.AddWithValue("@tabname", str);
        try
        {
            flag = ((int)sqlCommand.ExecuteScalar() != 1 ? false : true);
        }
        catch
        {
        }
        if (str.ToLower() != "eprint" && !base.Request.Url.PathAndQuery.ToLower().Contains("localhost") && !flag && str != "common")
        {
            this.Context.Response.Redirect(string.Concat(this.strSitepath, "unauthorized_access.aspx"));
        }
    }

    public void CheckUserAccessRight(string tabname)
    {
        bool flag = true;
        commonClass _commonClass = new commonClass();
        SqlCommand sqlCommand = new SqlCommand("pc_CheckUserAccessRight", _commonClass.openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        if (this.Session["userID"] != null)
        {
            sqlCommand.Parameters.Add("@userid", long.Parse(this.Session["userID"].ToString()));
        }
        else
        {
            sqlCommand.Parameters.Add("@userid", SqlDbType.BigInt);
        }
        if (tabname.ToLower() == "client" || tabname.ToLower() == "accounts")
        {
            tabname = "clients";
        }
        if (tabname.ToLower() == "setting")
        {
            tabname = "SETTINGS";
        }
        if (tabname.ToLower() == "estimate")
        {
            tabname = "ESTIMATES";
        }
        if (tabname.ToLower() == "job")
        {
            tabname = "JOBS";
        }
        if (tabname.ToLower() == "purchase")
        {
            tabname = "PURCHASES";
        }
        if (tabname.ToLower() == "invoice")
        {
            tabname = "INVOICES";
        }
        if (tabname.ToLower() == "document")
        {
            tabname = "DOCUMENTS";
        }
        if (tabname.ToLower() == "report")
        {
            tabname = "REPORTS";
        }
        if (tabname.ToLower() == "delivery")
        {
            tabname = "DELIVERYNOTE";
        }
        if (tabname.ToLower() == "contact")
        {
            tabname = "clients";
        }
        sqlCommand.Parameters.AddWithValue("@tabnameReport", "none");
        sqlCommand.Parameters.AddWithValue("@tabname", tabname);
        try
        {
            flag = ((int)sqlCommand.ExecuteScalar() != 1 ? false : true);
        }
        catch
        {
            flag = true;
        }
        _commonClass.closeConnection();
        if (!flag)
        {
            this.Context.Response.Redirect(string.Concat(this.strSitepath, "unauthorized_access.aspx"));
        }
        _commonClass.closeConnection();
    }

    public bool CheckUserAccessRight(string tabname, string leftPanel)
    {
        bool flag;
        bool flag1 = true;
        SqlCommand sqlCommand = new SqlCommand("pc_CheckUserAccessRight", (new commonClass()).openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        if (this.Session["userID"] != null)
        {
            sqlCommand.Parameters.Add("@userid", long.Parse(this.Session["userID"].ToString()));
        }
        else
        {
            sqlCommand.Parameters.Add("@userid", SqlDbType.BigInt);
        }
        sqlCommand.Parameters.AddWithValue("@tabname", tabname);
        sqlCommand.Parameters.AddWithValue("@tabnameReport", "none");
        try
        {
            if ((int)sqlCommand.ExecuteScalar() != 1)
            {
                flag1 = false;
                flag = flag1;
            }
            else
            {
                flag = flag1;
            }
        }
        catch
        {
            flag = true;
        }
        return flag;
    }

    public string date_Check(string DateFormat, string txtvalue)
    {
        string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
        if (DateFormat == "dd/mm/yyyy")
        {
            string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
            txtvalue = string.Concat(strArrays1);
        }
        else if (DateFormat == "mm/dd/yyyy")
        {
            string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
            txtvalue = string.Concat(strArrays2);
        }
        return txtvalue;
    }

    public string DateFormat_Return_As_MM_DD_YYYY(string DateFormat, string txtvalue)
    {
        string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
        if (Convert.ToInt32(strArrays[0].ToString()) > 12)
        {
            string[] str = new string[] { strArrays[2].ToString(), "/", strArrays[1].ToString(), "/", strArrays[0].ToString() };
            txtvalue = string.Concat(str);
        }
        else if (Convert.ToInt32(strArrays[1].ToString()) > 12)
        {
            string[] str1 = new string[] { strArrays[2].ToString(), "/", strArrays[0].ToString(), "/", strArrays[1].ToString() };
            txtvalue = string.Concat(str1);
        }
        else if (DateFormat == "dd/mm/yyyy")
        {
            string[] strArrays1 = new string[] { strArrays[2], "/", strArrays[1], "/", strArrays[0] };
            txtvalue = string.Concat(strArrays1);
        }
        else if (DateFormat == "mm/dd/yyyy")
        {
            string[] strArrays2 = new string[] { strArrays[2], "/", strArrays[0], "/", strArrays[1] };
            txtvalue = string.Concat(strArrays2);
        }
        return txtvalue;
    }

    public static DateTime[] DatesOfQuarter(DateTime dtmValue)
    {
        DateTime[] dateTime = new DateTime[2];
        int num = (int)Math.Ceiling(dtmValue.Month / new decimal(3));
        int num1 = num * 3;
        int num2 = num1 - 2;
        int num3 = DateTime.DaysInMonth(dtmValue.Year, num1);
        dateTime[0] = new DateTime(dtmValue.Year, num2, 1);
        dateTime[1] = new DateTime(dtmValue.Year, num1, num3);
        return dateTime;
    }

    public bool DeliveryItemID_Reduction_Check(long DeliveryItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryItemID_Reduction_Check");
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
        return Convert.ToBoolean((int)database.ExecuteScalar(storedProcCommand));
    }

    public void DeliveryItemID_Reduction_Save(long TransactionID, long DeliveryItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryItemID_Reduction_Insert");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void DirectPO_StockItem_Update(long PurchaseItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DirectPO_StockItem_Update");
        database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string dispstr(string st, int len)
    {
        string empty = string.Empty;
        ArrayList arrayLists = new ArrayList();
        int num = 0;
        int num1 = len;
        if (st.Length <= num1)
        {
            return st;
        }
        while (num + num1 <= st.Length)
        {
            try
            {
                arrayLists.Add(st.Substring(num, num1));
            }
            catch
            {
            }
            num = num + num1;
        }
        if (st.Length - num > 0)
        {
            arrayLists.Add(st.Substring(num, st.Length - num));
        }
        for (int i = 0; i < arrayLists.Count; i++)
        {
            empty = string.Concat(empty, arrayLists[i].ToString(), "<br/>");
        }
        return empty;
    }

    public string dispstrtxtbox(string st, int len)
    {
        string empty = string.Empty;
        ArrayList arrayLists = new ArrayList();
        int num = 0;
        int num1 = len;
        if (st.Length <= num1)
        {
            return st;
        }
        while (num + num1 <= st.Length)
        {
            try
            {
                arrayLists.Add(st.Substring(num, num1));
            }
            catch
            {
            }
            num = num + num1;
        }
        if (st.Length - num > 0)
        {
            arrayLists.Add(st.Substring(num, st.Length - num));
        }
        for (int i = 0; i < arrayLists.Count; i++)
        {
            empty = string.Concat(empty, arrayLists[i].ToString(), "\n");
        }
        return empty;
    }

    public string GenerateErrorString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("<div id=\"__asptrace\">");
        stringBuilder.Append("<span style=\"background-color: white;color: black;font: 10pt verdana, arial;\">");
        stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"width: 100%; border-collapse: collapse;clear: left;font: 10pt verdana, arial;cellspacing: 0;cellpadding: 0;margin-bottom: 25;\">");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\">");
        stringBuilder.Append("<th class=\"alt\" align=\"left\" style\"padding: 0,3,0,3;\" colspan=\"10\">");
        stringBuilder.Append("<h3 >");
        stringBuilder.Append("<b>Form values Collection</b></h3>");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Name");
        stringBuilder.Append("</th>");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Value");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
        {
            stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.Form.GetKey(i).ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.Form[i].ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
        }
        stringBuilder.Append("</table>");
        stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"width: 100%; border-collapse: collapse;\">");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
        stringBuilder.Append("<th class=\"alt\" align=\"left\" colspan=\"10\">");
        stringBuilder.Append("<h3>");
        stringBuilder.Append("<b>Cookies values Collection</b></h3>");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("<tr class=\"subhead\" align=\"left\">");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Name");
        stringBuilder.Append("</th>");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Value");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        for (int j = 0; j < HttpContext.Current.Request.Cookies.Count; j++)
        {
            stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.Cookies.GetKey(j).ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.Cookies[j].Value.ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
        }
        stringBuilder.Append("</table>");
        stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"width: 100%; border-collapse: collapse;\">");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
        stringBuilder.Append("<th class=\"alt\" align=\"left\" colspan=\"10\">");
        stringBuilder.Append("<h3>");
        stringBuilder.Append("<b>Server Variables Collection</b></h3>");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("<tr class=\"subhead\" align=\"left\">");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Name");
        stringBuilder.Append("</th>");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Value");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        for (int k = 0; k < HttpContext.Current.Request.ServerVariables.Count; k++)
        {
            stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.ServerVariables.GetKey(k).ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.ServerVariables[k].ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
        }
        stringBuilder.Append("</table>");
        stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"width: 100%; border-collapse: collapse;\">");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
        stringBuilder.Append("<th class=\"alt\" align=\"left\" colspan=\"10\">");
        stringBuilder.Append("<h3>");
        stringBuilder.Append("<b>Query String Collection</b></h3>");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("<tr class=\"subhead\" align=\"left\">");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Name");
        stringBuilder.Append("</th>");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Value");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        for (int l = 0; l < HttpContext.Current.Request.QueryString.Count; l++)
        {
            stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.QueryString.GetKey(l).ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Request.QueryString[l].ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
        }
        stringBuilder.Append("</table>");
        stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"width: 100%; border-collapse: collapse;\">");
        stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
        stringBuilder.Append("<th class=\"alt\" align=\"left\" colspan=\"10\">");
        stringBuilder.Append("<h3>");
        stringBuilder.Append("<b>Session Collection</b></h3>");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        stringBuilder.Append("<tr class=\"subhead\" align=\"left\">");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Name");
        stringBuilder.Append("</th>");
        stringBuilder.Append("<th style\"padding: 0,3,0,3;\">");
        stringBuilder.Append("Value");
        stringBuilder.Append("</th>");
        stringBuilder.Append("</tr>");
        for (int m = 0; m < HttpContext.Current.Session.Count; m++)
        {
            stringBuilder.Append("<tr style=\"background-color: #cccccc;\" align=\"left\">");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Session.Keys[m].ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(HttpContext.Current.Session[m].ToString());
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
        }
        stringBuilder.Append("</table>");
        stringBuilder.Append("</span>");
        stringBuilder.Append("</div>");
        return stringBuilder.ToString();
    }

    public string GenPassWithCap(int i)
    {
        this.rGen = new Random();
        int num = 0;
        string str = "";
        for (int i1 = 0; i1 <= i; i1++)
        {
            num = this.rGen.Next(0, 60);
            str = string.Concat(str, this.strCharacters[num]);
        }
        return str;
    }
    public int GensNegValue(int i)
    {
        this.rNewGen = new Random();
        int num = 0;
        for (int i1 = 0; i1 <= i; i1++)
        {
            num = this.rNewGen.Next(1, 100);
        }
        return Convert.ToInt32(string.Concat("-", num));
    }
    public string GetCountryName(int CompanyID, int CountryID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_countryname_select");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
        database.AddInParameter(storedProcCommand, "@CountryID", DbType.Int32, CountryID);
        return (string)database.ExecuteScalar(storedProcCommand);
    }

    public long GetParentIDOfOtherMultipleProduct(long KitItemID)
    {
        long num = (long)0;
        DataSet dataSet = new DataSet();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetParentIDOfOtherMultipleProduct");
        database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, KitItemID);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            num = Convert.ToInt64(row["PriceCatalogueID"].ToString());
        }
        return num;
    }

    public string GetSubDomainName(string Url)
    {
        if (Url.Contains("://"))
        {
            Url = Url.ToLower().Replace("http://", "").Replace("http://", "");
        }
        if (Url.IndexOf(".") <= 1)
        {
            Url = string.Empty;
        }
        else
        {
            char[] chrArray = new char[] { '.' };
            Url = Url.Split(chrArray)[0].ToString();
        }
        return Url;
    }

    public void GoodsAdded_updatepurchaseitem(long PurchaseItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateDirectPO_GoodsReceived");
        database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void GoodsAdded_updatepurchaseitem(long PurchaseItemID, int GoodsReceived) ////Modification By Bilal Stage 3.3
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateDirectPO_GoodsReceived_New");
        database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
        database.AddInParameter(storedProcCommand, "@GoodsReceived", DbType.Int32, GoodsReceived);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void GoodsAdded_updateestimateitem(long EstimateItemID, int GoodsReceived) ////Modification By Bilal
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateEstimateItem_GoodsReceived_New");
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.AddInParameter(storedProcCommand, "@GoodsReceived", DbType.Int32, GoodsReceived);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string[] IncrypetHrefValue(string str)
    {
        string[] strArrays = new string[2];
        string empty = string.Empty;
        string empty1 = string.Empty;
        string str1 = string.Empty;
        str = str.Replace("</a>", "");
        string[] strArrays1 = str.Split(new char[] { '>' });
        if ((int)strArrays1.Length > 1)
        {
            string[] strArrays2 = strArrays1[0].ToString().Split(new char[] { '=' });
            if ((int)strArrays2.Length > 1)
            {
                str1 = strArrays2[(int)strArrays2.Length - 1].ToString();
                string[] strArrays3 = strArrays2[(int)strArrays2.Length - 2].ToString().Split(new char[] { '?' });
                if ((int)strArrays2.Length > 1)
                {
                    empty = strArrays3[0].ToString();
                    empty1 = strArrays3[1].ToString();
                    QueryString queryString = new QueryString()
					{
						{ empty1, str1 },
						{ "isnew", "2" }
					};
                    string str2 = empty;
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    str2 = string.Concat(str2, queryString1.ToString());
                    strArrays[0] = str2;
                    strArrays[1] = strArrays1[1].ToString();
                }
            }
        }
        return strArrays;
    }

    public string InsertAtIntervals(string s, int interval, string value)
    {
        if (s == null || s.Length <= interval)
        {
            return s;
        }
        StringBuilder stringBuilder = new StringBuilder(s);
        for (int i = interval * ((s.Length - 1) / interval); i > 0; i = i - interval)
        {
            stringBuilder.Insert(i, value);
        }
        return stringBuilder.ToString();
    }

    public bool IsDeliveryItemStatusChanges(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom_Del, int DelItemQuantity, int JobQty, long ModuleID, bool IsKit)
    {
        string[] strArrays = DrawStockFrom_Del.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        bool flag = false;
        int jobQty = 0;
        this.Session["IsUpdateKingsQty"] = "";
        string empty = string.Empty;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, "job");
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, num);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0)
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, "job");
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, 0);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count <= 0)
        {
            int num1 = 0;
            if (this.Session["UserID"] != null && this.Session["UserID"] != null)
            {
                num1 = Convert.ToInt32(this.Session["UserID"].ToString());
            }
            string str1 = this.Return_StockManagementSettings("SR_StockReductionMethod");
            string str2 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
            if (str.ToLower() == "self")
            {
                this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, JobQty, str1, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
            }
            else if (str.ToLower() == "other")
            {
                this.StockAllocation_Others(CompanyID, KitID, JobQty, string.Concat(str1, "¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
            }
            else if (str.ToLower() == "additional option")
            {
                if (this.Session["StockItemType"] == null || this.Session["StockItemType"] == null)
                {
                    this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, JobQty, str1, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
                }
                else if (!(this.Session["StockItemType"].ToString() == "x") || this.Session["ALC_OrderItemId"] == null || this.Session["ALC_OrderItemId"] == null)
                {
                    this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, JobQty, str1, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
                }
                else
                {
                    this.StockAllocationForAdditionalOptionEstore(CompanyID, PriceCatalogueID, JobQty, str1, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1, (long)0, Convert.ToInt64(this.Session["ALC_OrderItemId"].ToString()));
                }
                this.Session["StockItemType"] = "";
                this.Session["ALC_OrderItemId"] = "";
            }
            else if (str.ToLower() == "multiple")
            {
                if (this.Session["StockItemType"] == null || this.Session["StockItemType"] == null)
                {
                    this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, JobQty, str1, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
                }
                else if (this.Session["StockItemType"].ToString() != "x")
                {
                    this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, JobQty, str1, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
                }
                else
                {
                    foreach (DataRow row in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, JobQty, true).Rows)
                    {
                        this.StockAllocationProcess(CompanyID, Convert.ToInt64(row["KitItemID"].ToString()), PriceCatalogueID, JobQty, str1, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", new decimal(0), (long)num1);
                    }
                }
                this.Session["StockItemType"] = "";
                this.Session["ALC_OrderItemId"] = "";
            }
            flag = this.IsDeliveryItemStatusChangesNew(CompanyID, PriceCatalogueID, KitID, DrawStockFrom_Del, DelItemQuantity, JobQty, ModuleID);
        }
        else
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count <= 0)
            {
                int num2 = 0;
                if (this.Session["UserID"] != null && this.Session["UserID"] != null)
                {
                    num2 = Convert.ToInt32(this.Session["UserID"].ToString());
                }
                string str3 = this.Return_StockManagementSettings("SR_StockReductionMethod");
                string str4 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                if (str.ToLower() == "self")
                {
                    this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, DelItemQuantity, str3, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                }
                else if (str.ToLower() == "other")
                {
                    this.StockAllocation_Others(CompanyID, KitID, JobQty, string.Concat(str3, "¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                }
                else if (str.ToLower() == "additional option")
                {
                    if (this.Session["StockItemType"] == null || this.Session["StockItemType"] == null)
                    {
                        this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, JobQty, str3, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                    }
                    else if (!(this.Session["StockItemType"].ToString() == "x") || this.Session["ALC_OrderItemId"] == null || this.Session["ALC_OrderItemId"] == null)
                    {
                        this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, JobQty, str3, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                    }
                    else
                    {
                        this.StockAllocationForAdditionalOptionEstore(CompanyID, PriceCatalogueID, JobQty, str3, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2, (long)0, Convert.ToInt64(this.Session["ALC_OrderItemId"].ToString()));
                    }
                    this.Session["StockItemType"] = "";
                    this.Session["ALC_OrderItemId"] = "";
                }
                else if (str.ToLower() == "multiple")
                {
                    if (this.Session["StockItemType"] == null || this.Session["StockItemType"] == null)
                    {
                        this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, JobQty, str3, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                    }
                    else if (this.Session["StockItemType"].ToString() != "x")
                    {
                        this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, JobQty, str3, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                    }
                    else
                    {
                        foreach (DataRow dataRow in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, JobQty, true).Rows)
                        {
                            this.StockAllocationProcess(CompanyID, Convert.ToInt64(dataRow["KitItemID"].ToString()), PriceCatalogueID, JobQty, str3, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", new decimal(0), (long)num2);
                        }
                    }
                    this.Session["StockItemType"] = "";
                    this.Session["ALC_OrderItemId"] = "";
                }
                flag = this.IsDeliveryItemStatusChangesNew(CompanyID, PriceCatalogueID, KitID, DrawStockFrom_Del, DelItemQuantity, JobQty, ModuleID);
            }
            else
            {
                foreach (DataRow row1 in item.Rows)
                {
                    DataSet dataSet1 = new DataSet();
                    if (str.ToLower() == "additional option")
                    {
                        DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_IsKingsAdditionalOptionStockReducable_check");
                        database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                        database.AddInParameter(storedProcCommand1, "@PricecatalogueStockAdditionalId", DbType.Int64, Convert.ToInt64(row1["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(storedProcCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row1["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(storedProcCommand1);
                    }
                    else if (str.ToLower() != "other")
                    {
                        DbCommand dbCommand1 = database.GetStoredProcCommand("PC_IsKingsStockReducable_check");
                        database.AddInParameter(dbCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                        database.AddInParameter(dbCommand1, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row1["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(dbCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row1["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(dbCommand1);
                    }
                    else if (PriceCatalogueID == Convert.ToInt64(row1["PriceCatalogueID"].ToString()))
                    {
                        DbCommand storedProcCommand2 = database.GetStoredProcCommand("PC_IsKingsStockReducable_check");
                        database.AddInParameter(storedProcCommand2, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                        database.AddInParameter(storedProcCommand2, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row1["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(storedProcCommand2, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row1["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(storedProcCommand2);
                    }
                    if (dataSet1.Tables.Count <= 0)
                    {
                        continue;
                    }
                    foreach (DataRow dataRow1 in dataSet1.Tables[0].Rows)
                    {
                        empty = string.Concat(empty, dataRow1["IsStockReducable"].ToString(), ",");
                    }
                }
                if (!empty.Contains("false"))
                {
                    if (KitID == (long)0 || !(str.ToLower() == "other"))
                    {
                        DataTable dataTable = dataSet.Tables[0];
                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row2 in dataTable.Rows)
                            {
                                jobQty = JobQty;
                                DataSet dataSet2 = new DataSet();
                                DbCommand dbCommand2 = database.GetStoredProcCommand("PC_ProductStockDetails_Select");
                                database.AddInParameter(dbCommand2, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row2["PriceCatalogueID"].ToString()));
                                dataSet2 = database.ExecuteDataSet(dbCommand2);
                                if (dataSet2.Tables.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow2 in dataSet2.Tables[0].Rows)
                                {
                                    Convert.ToInt32(dataRow2["TotalQuantity"].ToString());
                                    Convert.ToInt32(dataRow2["QtySendToKings"].ToString());
                                    this.Session["PriceCatalogueID_othermultiple"] = dataRow2["PriceCatalogueID"].ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable item1 = dataSet.Tables[0];
                        if (item1.Rows.Count > 0)
                        {
                            for (int i = 0; i < item1.Rows.Count; i++)
                            {
                                if (PriceCatalogueID == Convert.ToInt64(item1.Rows[i]["PriceCatalogueID"].ToString()))
                                {
                                    int num3 = Convert.ToInt32(item1.Rows[i]["Quantity"].ToString());
                                    jobQty = JobQty * num3;
                                    DataSet dataSet3 = new DataSet();
                                    DbCommand storedProcCommand3 = database.GetStoredProcCommand("PC_ProductStockDetails_Select");
                                    database.AddInParameter(storedProcCommand3, "@PriceCatalogueID", DbType.Int64, KitID);
                                    dataSet3 = database.ExecuteDataSet(storedProcCommand3);
                                    if (dataSet3.Tables.Count > 0)
                                    {
                                        foreach (DataRow row3 in dataSet3.Tables[0].Rows)
                                        {
                                            Convert.ToInt32(row3["TotalQuantity"].ToString());
                                            Convert.ToInt32(row3["QtySendToKings"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DelItemQuantity <= jobQty || IsKit)
                    {
                        flag = true;
                        this.Session["IsUpdateKingsQty"] = "true";
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
        }
        return flag;
    }

    public string IsDeliveryItemStatusChanges_Kit(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom, int DelItemQuantity, int JobQty, long ModuleID)
    {
        string empty = string.Empty;
        int jobQty = 0;
        string str = string.Empty;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, "job");
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count <= 0)
        {
            empty = "false";
        }
        else
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (PriceCatalogueID != Convert.ToInt64(row["PriceCatalogueID"].ToString()))
                {
                    continue;
                }
                DataSet dataSet1 = new DataSet();
                DbCommand dbCommand = database.GetStoredProcCommand("PC_IsStockReducable_check");
                database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                database.AddInParameter(dbCommand, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                database.AddInParameter(dbCommand, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                dataSet1 = database.ExecuteDataSet(dbCommand);
                foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                {
                    str = string.Concat(str, dataRow["IsStockReducable"].ToString(), ",");
                }
            }
            if (!str.Contains("false"))
            {
                DataTable item = dataSet.Tables[0];
                for (int i = 0; i < item.Rows.Count; i++)
                {
                    if (PriceCatalogueID == Convert.ToInt64(item.Rows[i]["PriceCatalogueID"].ToString()))
                    {
                        int num = Convert.ToInt32(item.Rows[i]["Quantity"].ToString());
                        jobQty = JobQty * num;
                    }
                }
                empty = (DelItemQuantity > jobQty ? string.Concat(empty, "false,") : string.Concat(empty, "true,"));
            }
            else
            {
                empty = "false,";
            }
        }
        return empty;
    }
    public bool IsDeliveryItemStatusChangesNew(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom_Del, int DelItemQuantity, int JobQty, long ModuleID)
    {
        string[] strArrays = DrawStockFrom_Del.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        bool flag = false;
        int jobQty = 0;
        this.Session["IsUpdateKingsQty"] = "";
        string empty = string.Empty;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, "job");
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, num);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0)
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, "job");
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, 0);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count <= 0)
        {
            flag = false;
        }
        else
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count <= 0)
            {
                flag = false;
            }
            else
            {
                foreach (DataRow row in item.Rows)
                {
                    DataSet dataSet1 = new DataSet();
                    if (str.ToLower() == "additional option")
                    {
                        DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_IsKingsAdditionalOptionStockReducable_check");
                        database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                        database.AddInParameter(storedProcCommand1, "@PricecatalogueStockAdditionalId", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(storedProcCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(storedProcCommand1);
                    }
                    else if (str.ToLower() != "other")
                    {
                        DbCommand dbCommand1 = database.GetStoredProcCommand("PC_IsKingsStockReducable_check");
                        database.AddInParameter(dbCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                        database.AddInParameter(dbCommand1, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(dbCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(dbCommand1);
                    }
                    else if (PriceCatalogueID == Convert.ToInt64(row["PriceCatalogueID"].ToString()))
                    {
                        DbCommand storedProcCommand2 = database.GetStoredProcCommand("PC_IsKingsStockReducable_check");
                        database.AddInParameter(storedProcCommand2, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                        database.AddInParameter(storedProcCommand2, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                        database.AddInParameter(storedProcCommand2, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                        dataSet1 = database.ExecuteDataSet(storedProcCommand2);
                    }
                    if (dataSet1.Tables.Count <= 0)
                    {
                        continue;
                    }
                    foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                    {
                        empty = string.Concat(empty, dataRow["IsStockReducable"].ToString(), ",");
                    }
                }
                if (!empty.Contains("false"))
                {
                    if (KitID == (long)0 || !(str.ToLower() == "other"))
                    {
                        DataTable dataTable = dataSet.Tables[0];
                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in dataTable.Rows)
                            {
                                jobQty = JobQty;
                                DataSet dataSet2 = new DataSet();
                                DbCommand dbCommand2 = database.GetStoredProcCommand("PC_ProductStockDetails_Select");
                                database.AddInParameter(dbCommand2, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                                dataSet2 = database.ExecuteDataSet(dbCommand2);
                                if (dataSet2.Tables.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (DataRow dataRow1 in dataSet2.Tables[0].Rows)
                                {
                                    Convert.ToInt32(dataRow1["TotalQuantity"].ToString());
                                    Convert.ToInt32(dataRow1["QtySendToKings"].ToString());
                                    this.Session["PriceCatalogueID_othermultiple"] = dataRow1["PriceCatalogueID"].ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable item1 = dataSet.Tables[0];
                        if (item1.Rows.Count > 0)
                        {
                            for (int i = 0; i < item1.Rows.Count; i++)
                            {
                                if (PriceCatalogueID == Convert.ToInt64(item1.Rows[i]["PriceCatalogueID"].ToString()))
                                {
                                    int num1 = Convert.ToInt32(item1.Rows[i]["Quantity"].ToString());
                                    jobQty = JobQty * num1;
                                    DataSet dataSet3 = new DataSet();
                                    DbCommand storedProcCommand3 = database.GetStoredProcCommand("PC_ProductStockDetails_Select");
                                    database.AddInParameter(storedProcCommand3, "@PriceCatalogueID", DbType.Int64, KitID);
                                    dataSet3 = database.ExecuteDataSet(storedProcCommand3);
                                    if (dataSet3.Tables.Count > 0)
                                    {
                                        foreach (DataRow row2 in dataSet3.Tables[0].Rows)
                                        {
                                            Convert.ToInt32(row2["TotalQuantity"].ToString());
                                            Convert.ToInt32(row2["QtySendToKings"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (DelItemQuantity <= jobQty)
                    {
                        flag = true;
                        this.Session["IsUpdateKingsQty"] = "true";
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
        }
        return flag;
    }

    public bool IsDisplaySettings(string tagName)
    {
        return Convert.ToBoolean(this.Session[tagName]);
    }

    public string IsReduction_Possible(long PriceCatalogueID, long EstimateItemID)
    {
        string empty = string.Empty;
        long num = (long)0;
        if (this.Session["CompanyID"] != null)
        {
            num = Convert.ToInt64(this.Session["CompanyID"].ToString());
        }
        foreach (DataRow row in this.ProductStockType_Select(num, PriceCatalogueID).Rows)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsPartialReduction_Requires");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, num);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, row["DrawStockFrom"].ToString().ToLower());
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, EstimateItemID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count <= 0)
            {
                continue;
            }
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string[] str = new string[] { dataRow["IsParReductionReq"].ToString(), "~", dataRow["IsCompleteRedReq"].ToString(), "~", dataRow["TotalQty"].ToString(), "~", dataRow["TransAllocatedQty"].ToString(), "~", dataRow["PartialQty"].ToString(), "~", dataRow["IsBackOrder"].ToString() };
                empty = string.Concat(str);
            }
        }
        return empty;
    }
    public void KitStockAllocationOrReduction(long PriceCatalogueID, int Quantity, char Type, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Kit_AllocationOrReduction");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Quantity);
        database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }
    public string MakeToUserDate_11(string date)
    {
        double num;
        TryParseTimeZoneOrderNumber(global.ServerTimeZoneOrderNumber(), out num);
        int.TryParse(global.AdjustableNumber(), out _);
        double num1 = this.GetSessionTimeZoneOrderNumber(num);
        double num2 = 0;
        double num3 = 0;
        if (num > num1)
        {
            double num4 = num1 - num;
            string[] strArrays = num4.ToString("N2").ToString().Split(new char[] { '.' });
            num2 = Convert.ToDouble(strArrays[0]);
            num3 = Convert.ToDouble(strArrays[1]);
            if (num3 < -30)
            {
                num3 = -30;
            }
        }
        else if (num >= num1)
        {
        }
        else
        {
            double num5 = num1 - num;
            string[] strArrays1 = num5.ToString("N2").ToString().Split(new char[] { '.' });
            num2 = Convert.ToDouble(strArrays1[0]);
            num3 = Convert.ToDouble(strArrays1[1]);
            if (num3 > 30)
            {
                num3 = 30;
            }
        }
        num2 = num2 + (double)this.CheckForDST(num1);
        DateTime dateTime = Convert.ToDateTime(date);
        dateTime = dateTime.AddHours(num2);
        dateTime = dateTime.AddMinutes(num3);
        dateTime = dateTime.AddSeconds(0);
        return dateTime.ToString();
    }

    public string ManuallyStockReductionProcess(long Estimateid, long PriceCatalogueID, long CompanyID, int Quantity, long CreatedBy)
    {
        int quantity = Quantity;
        int num = 0;
        int num1 = 0;
        long num2 = (long)0;
        long num3 = (long)0;
        long num4 = (long)0;
        long num5 = (long)0;
        string empty = string.Empty;
        string str = string.Empty;
        decimal num6 = new decimal(0);
        string empty1 = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManualReleaseDetails_select");
        database.AddInParameter(storedProcCommand, "@Estimateid", DbType.Int64, Estimateid);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataSet dataSet1 = new DataSet();
                DbCommand dbCommand = database.GetStoredProcCommand("PC_IsStockReducable_check");
                database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                database.AddInParameter(dbCommand, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                database.AddInParameter(dbCommand, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                dataSet1 = database.ExecuteDataSet(dbCommand);
                foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                {
                    empty1 = string.Concat(empty1, dataRow["IsStockReducable"].ToString(), ",");
                }
            }
            if (!empty1.Contains("false"))
            {
                foreach (DataRow row1 in dataSet.Tables[0].Rows)
                {
                    num1 = Convert.ToInt32(row1["AllocatedQty"].ToString());
                    num2 = Convert.ToInt64(row1["TransactionID"].ToString());
                    num5 = Convert.ToInt64(row1["PricecatalogueStockID"].ToString());
                    PriceCatalogueID = Convert.ToInt64(row1["PriceCatalogueID"].ToString());
                    num3 = Convert.ToInt64(row1["ModuleID"].ToString());
                    num4 = Convert.ToInt64(row1["KITTransactionID"].ToString());
                    empty = row1["ModuleName"].ToString();
                    num6 = Convert.ToDecimal(row1["Price"].ToString());
                    if (quantity >= num1)
                    {
                        num = num1;
                        quantity = quantity - num1;
                        num1 = 0;
                    }
                    else if (quantity < num1)
                    {
                        num = quantity;
                        num1 = num1 - quantity;
                        quantity = 0;
                    }
                    str = string.Concat(this.objLanguage.GetLanguageConversion("Stock_released_manually_for_Job"), " #", num3);
                    if (num == 0)
                    {
                        continue;
                    }
                    num2 = this.StockManagementTransaction_Save(num2, CompanyID, PriceCatalogueID, num4, num3, empty, "self", num5, num1, num, "ALC-REL", num6, CreatedBy, false);
                    this.StockReduction(PriceCatalogueID, num5, num1, num, CreatedBy);
                    this.StockReductionManagementHistory_Save(num2, PriceCatalogueID, num5, num, str, CreatedBy, "Released");
                    this.UpdateKitProduct_StockLevels(PriceCatalogueID, num, "Released");
                }
                languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
            }
            else
            {
                languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available");
            }
        }
        return languageConversion;
    }

    public string ManuallyStockReductionProcessForAdditionalOption(long Estimateid, long PriceCatalogueID, long CompanyID, int Quantity, long CreatedBy)
    {
        int quantity = Quantity;
        int num = 0;
        int num1 = 0;
        long num2 = (long)0;
        long num3 = (long)0;
        long num4 = (long)0;
        string empty = string.Empty;
        string str = string.Empty;
        decimal num5 = new decimal(0);
        string empty1 = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManualReleaseDetails_select");
        database.AddInParameter(storedProcCommand, "@Estimateid", DbType.Int64, Estimateid);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataSet dataSet1 = new DataSet();
                DbCommand dbCommand = database.GetStoredProcCommand("PC_IsAdditionalOptionStockReducable_check");
                database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                database.AddInParameter(dbCommand, "@PricecatalogueStockAdditionalId", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                database.AddInParameter(dbCommand, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                dataSet1 = database.ExecuteDataSet(dbCommand);
                foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                {
                    empty1 = string.Concat(empty1, dataRow["IsStockReducable"].ToString(), ",");
                }
            }
            if (!empty1.Contains("false"))
            {
                foreach (DataRow row1 in dataSet.Tables[0].Rows)
                {
                    num1 = Convert.ToInt32(row1["AllocatedQty"].ToString());
                    num2 = Convert.ToInt64(row1["TransactionID"].ToString());
                    num4 = Convert.ToInt64(row1["PricecatalogueStockID"].ToString());
                    PriceCatalogueID = Convert.ToInt64(row1["PriceCatalogueID"].ToString());
                    num3 = Convert.ToInt64(row1["ModuleID"].ToString());
                    empty = row1["ModuleName"].ToString();
                    num5 = Convert.ToDecimal(row1["Price"].ToString());
                    if (quantity == num1)
                    {
                        num = num1;
                        quantity = quantity - num1;
                        num1 = 0;
                    }
                    else if (quantity < num1)
                    {
                        num = quantity;
                        num1 = num1 - quantity;
                        quantity = 0;
                    }
                    str = string.Concat(this.objLanguage.GetLanguageConversion("Additional_Option_Stock_released_manually_for_Job"), " #", num3);
                    num2 = this.StockManagementTransaction_Save(num2, CompanyID, PriceCatalogueID, (long)0, num3, empty, "additional option", num4, num1, num, "ALC-REL", num5, CreatedBy, false);
                    this.StockReductionForAdditionalOption(PriceCatalogueID, num4, num1, num, CreatedBy);
                    this.StockReductionManagementHistory_Save(num2, PriceCatalogueID, num4, num, str, CreatedBy, "Released");
                }
                languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
            }
            else
            {
                languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available");
            }
        }
        return languageConversion;
    }

    public void Message_Display(string strMsg, string cssclass, PlaceHolder plh)
    {
        plh.Controls.Clear();
        UserControl userControl = (UserControl)base.LoadControl("~/Usercontrol/message_display.ascx");
        plh.Controls.Add(userControl);
        Timer timer = (Timer)userControl.FindControl("TimerMessage");
        Label label = (Label)userControl.FindControl("lblMessage");
        Panel panel = (Panel)userControl.FindControl("pnlMessage");
        timer.Enabled = false;
        panel.CssClass = cssclass;
        timer.Interval = 5000;
        label.Text = strMsg;
    }

    public void Navigation_Path(string nodes, string cureentnode)
    {
        UserControl userControl = (UserControl)base.Master.FindControl("header2");
        Label label = (Label)userControl.FindControl("lblsitepath");
        string[] strArrays = new string[] { "<span class='navigatorpanel'><b>", nodes, "</b></span><span class='navigatorpanel'><b>", cureentnode, "</b></span>" };
        label.Text = string.Concat(strArrays);
        label.Text = label.Text.Replace("subnavigator", "subnavigatorblack").Replace("navigatorpanel", "navigatorpanelblack");
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.Session_Check();
    }

    private void TryApplyTheme(string themeName)
    {
        if (string.IsNullOrWhiteSpace(themeName) || this.Page == null)
        {
            return;
        }

        try
        {
            this.Page.Theme = themeName.Trim();
        }
        catch (HttpException)
        {
            // Some pages use inline <% %> blocks; keep default declarative theme instead.
        }
    }

    private bool ShouldApplyRuntimeTheme()
    {
        string setting = ConfigurationManager.AppSettings["EnableRuntimePageTheme"];
        return string.Equals(setting, "true", StringComparison.OrdinalIgnoreCase);
    }

    public void Page_Error(object sender, EventArgs e)
    {
        //string str = global.sitePath();
        //string empty = string.Empty;
        //if (this.Session["CompanyName"] != null)
        //{
        //    empty = this.SpecialDecode(this.Session["CompanyName"].ToString());
        //}
        //Exception baseException = base.Server.GetLastError().GetBaseException();

        //var trace = new System.Diagnostics.StackTrace(baseException, true);

        //StringBuilder strTrace = new StringBuilder();
        //if (trace != null)
        //{
        //    var frames = trace.GetFrames();
        //    foreach (var frame in frames)
        //    {
        //        if (!frame.ToString().ToLower().Contains("unknown"))
        //        {
        //            string info = "Line#" + frame.GetFileLineNumber() + ";\nFile Name:" + frame.GetFileName()
        //                + ";\nMethod Name:" + frame.GetMethod().Name;
        //            strTrace.Append("Debug Trace: \n " + frame.ToString() + Environment.NewLine + info);
        //        }
        //    }
        //}

        //StringBuilder stringBuilder = new StringBuilder();
        //string[] strArrays = new string[] { "[", EprintConfigurationManager.AppSettings["ServerName"].ToString(), "] ", empty, "an error occured." };
        //string str1 = string.Concat(strArrays);
        //stringBuilder.Append(" An error has been occoured \n");
        //stringBuilder.Append(string.Concat("\n Error in: ", base.Request.Url.ToString(), "\n"));
        //stringBuilder.Append(string.Concat("\n Error Message: ", baseException.Message.ToString(), "\n"));
        //stringBuilder.Append(string.Concat("\n Stack Trace:", baseException.StackTrace.ToString(), "\n"));

        //stringBuilder.Append(string.Concat("\n Debug Trace:", strTrace.ToString(), "\n"));

        //stringBuilder.Append("\n");
        //stringBuilder.Append("\n Thanks ");
        //stringBuilder.Append("\n Regards ");
        //stringBuilder.Append("\n support@eprintsoftware.com \n");

        //DateTime now = DateTime.Now;
        //stringBuilder.Append(string.Concat("\n Date:", now.ToString()));
        //if (stringBuilder.ToString().Trim().ToLower().IndexOf("invalid length for a base-64 char array") == -1 && stringBuilder.ToString().Trim().ToLower().IndexOf("unable to read beyond the end of the stream") == -1)
        //{
        //    BaseClass.SendMailMessage("errorlogs@hexicomsoftware.com", "errorlogs@hexicomsoftware.com", "errorlogs@hexicomsoftware.com", "errorlogs@hexicomsoftware.com", str1, stringBuilder.ToString(), "", false);
        //}
        //base.Server.ClearError();

        //base.Response.Redirect(string.Concat(str, "error_report.aspx?returnUrl=", base.Request.Url.ToString()));
    }

    public string PartialStockReductionProcess(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        int quantity = Quantity;
        int num = 0;
        int num1 = 0;
        long num2 = (long)0;
        long num3 = (long)0;
        string empty = string.Empty;
        string str = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (KitID == (long)0 || !(DrawStockFrom == "other"))
                {
                    PriceCatalogueID = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                }
                else if (PriceCatalogueID != Convert.ToInt64(row["PriceCatalogueID"].ToString()) && KitID == Convert.ToInt64(row["KITTransactionID"].ToString()))
                {
                    PriceCatalogueID = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                    quantity = Quantity;
                    int num4 = Convert.ToInt32(row["Quantity"].ToString());
                    quantity = quantity * num4;
                }
                num1 = Convert.ToInt32(row["AllocatedQty"].ToString());
                num2 = Convert.ToInt64(row["TransactionID"].ToString());
                num3 = Convert.ToInt64(row["PricecatalogueStockID"].ToString());
                if (quantity >= num1)
                {
                    num = num1;
                    quantity = quantity - num1;
                    num1 = 0;
                }
                else if (quantity < num1)
                {
                    num = quantity;
                    num1 = num1 - quantity;
                    quantity = 0;
                }
                empty = string.Concat(this.objLanguage.GetLanguageConversion("Stock_released_for_Job"), " #", ModuleID);
                if (num == 0)
                {
                    continue;
                }
                num2 = this.StockManagementTransaction_Save(num2, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, DrawStockFrom, num3, num1, num, "ALC-REL", Price, CreatedBy, false);
                this.StockReduction(PriceCatalogueID, num3, num1, num, CreatedBy);
                this.StockReductionManagementHistory_Save(num2, PriceCatalogueID, num3, num, empty, CreatedBy, "Released");
                this.UpdateKitProduct_StockLevels(PriceCatalogueID, num, "Released");
            }
            languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
        }
        return languageConversion;
    }

    public string PartialStockReductionProcessForAdditionalOption(long CompanyID, long PriceCatalogueID, string DrawStockFrom, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        int quantity = Quantity;
        int num = 0;
        int num1 = 0;
        long num2 = (long)0;
        long num3 = (long)0;
        string empty = string.Empty;
        string str = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, 0);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                num1 = Convert.ToInt32(row["AllocatedQty"].ToString());
                num2 = Convert.ToInt64(row["TransactionID"].ToString());
                num3 = Convert.ToInt64(row["PricecatalogueStockID"].ToString());
                PriceCatalogueID = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                if (quantity >= num1)
                {
                    num = num1;
                    quantity = quantity - num1;
                    num1 = 0;
                }
                else if (quantity < num1)
                {
                    num = quantity;
                    num1 = num1 - quantity;
                    quantity = 0;
                }
                empty = string.Concat(this.objLanguage.GetLanguageConversion("Additional_Option_Stock_released_for_Job"), " #", ModuleID);
                num2 = this.StockManagementTransaction_Save(num2, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, DrawStockFrom, num3, num1, num, "ALC-REL", Price, CreatedBy, false);
                this.StockReductionForAdditionalOption(PriceCatalogueID, num3, num1, num, CreatedBy);
                this.StockReductionManagementHistory_Save(num2, PriceCatalogueID, num3, num, empty, CreatedBy, "Released");
            }
            languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
        }
        return languageConversion;
    }

    public DataTable ProductStockType_Select(long CompanyID, long PriceCatalogueID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStockType_Select");
        database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public string ReplaceDoubleQuote(string originalString)
    {
        string str = string.Concat("", '\"');
        originalString.Replace(str, "");
        return originalString.Trim();
    }

    public string ReplaceSingleQuote(string OriginalString)
    {
        return OriginalString.Replace("'", "`");
    }

    public void Replenished_updatepurchaseitem(long EstimateItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateCheck_Purchaseitem_Replenish");
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.ExecuteNonQuery(storedProcCommand);
    }
    public bool Replenished_EstimateItem_IsStockReplenishItem(long EstimateItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItem_IsStockReplenishItem");
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        bool isStockReplenishItem = false;
        DataTable dataTable = new DataTable();
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        if (dataTable.Rows.Count > 0)
        {
            if ((bool)dataTable.Rows[0]["IsStockReplenishItem"] == true)
            {
                isStockReplenishItem = true;
            }

        }
        return isStockReplenishItem;
    }

    public string Return_IsEnable_CRM(int CompanyID)
    {
        string empty = string.Empty;
        string str = HttpContext.Current.Request.Url.Host.ToString();
        if (str.Trim().ToLower() == "localhost" || str.Trim().ToLower() == "192.168.1.6")
        {
            str = ConfigurationManager.AppSettings["HostName"].ToString();
        }
        DataSet dataSet = SettingsBasePage.CRM_Select_IsAdvance_Crm(Convert.ToInt32(CompanyID), str);
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            empty = (row["IsAdvancedCrm"].ToString().ToLower() != "true" ? "false" : "true");
        }
        return empty;
    }

    public string Return_StockManagementSettings(string Name)
    {
        string empty = string.Empty;
        if (this.Session["ProductStockManagement"] != null && this.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true" && this.Session["CompanyID"] != null)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementSettings_Select");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"]));
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count > 0)
            {
                DataTable item = dataSet.Tables[0];
                foreach (DataRow row in item.Rows)
                {
                    foreach (DataColumn column in item.Columns)
                    {
                        if (column.ColumnName.ToString().Trim().ToLower() != Name.ToLower())
                        {
                            continue;
                        }
                        empty = row[column.ColumnName].ToString();
                    }
                }
            }
        }
        return empty;
    }

    public string ReturnDataBaseScreenName(string strHeaderName, int type, string diplay)
    {
        string empty = string.Empty;
        if (type != 1)
        {
            empty = strHeaderName;
            empty = this.ReturnSigular_Or_Plural(empty, "s");
        }
        else
        {
            empty = strHeaderName;
            empty = this.ReturnSigular_Or_Plural(empty, "p");
        }
        return this.ToTitleCase(empty, diplay);
    }

    public string ReturnRoles_Privileges_ForGrid(string module, string fieldName, string Path)
    {
        string empty = string.Empty;
        try
        {
            if (this.Session["CustomAccessRight"] != null && this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true" && this.Session["Roles_Privileges_Tabs"] != null)
            {
                DataTable item = (DataTable)this.Session["Roles_Privileges_Tabs"];
                foreach (DataRow row in item.Rows)
                {
                    if (row["sectionName"].ToString().Trim().ToLower() != module)
                    {
                        continue;
                    }
                    foreach (DataColumn column in item.Columns)
                    {
                        if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                        {
                            continue;
                        }
                        empty = row[column.ColumnName].ToString();
                    }
                }
            }
        }
        catch
        {
        }
        return empty;
    }

    public string ReturnRoles_Privileges_Others(string Name)
    {
        string empty = string.Empty;
        try
        {
            if (this.Session["CustomAccessRight"] != null)
            {
                if (this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true")
                {
                    if (this.Session["Roles_Privileges_Others"] != null)
                    {
                        DataTable item = (DataTable)this.Session["Roles_Privileges_Others"];
                        foreach (DataRow row in item.Rows)
                        {
                            foreach (DataColumn column in item.Columns)
                            {
                                if (column.ColumnName.ToString().Trim().ToLower() != Name)
                                {
                                    continue;
                                }
                                empty = row[column.ColumnName].ToString();
                            }
                        }
                    }
                }
                else if (Name.Trim().ToLower() != "showcostexmarkup")
                {
                    empty = "NA";
                }
                else
                {
                    empty = (this.Check_SpecialPrivilege_For_User(Convert.ToInt64(this.Session["UserID"]), Convert.ToInt64(this.Session["CompanyID"])) ? "NA" : "true");
                }
            }
        }
        catch
        {
        }
        return empty;
    }

    public void ReturnRoles_Privileges_Reports(string module, string fieldName, string Path)
    {
        try
        {
            if (this.Session["CustomAccessRight"] != null && this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true")
            {
                string empty = string.Empty;
                if (this.Session["Roles_Privileges_Reports"] != null)
                {
                    DataTable item = (DataTable)this.Session["Roles_Privileges_Reports"];
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["ReportItems"].ToString().Trim().ToLower() != module)
                        {
                            continue;
                        }
                        foreach (DataColumn column in item.Columns)
                        {
                            if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                            {
                                continue;
                            }
                            empty = row[column.ColumnName].ToString();
                        }
                    }
                }
                if (empty.Trim().ToLower() == "false")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
                else if (empty == "0")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
                else if (empty == "2")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
            }
        }
        catch
        {
        }
    }

    public string ReturnRoles_Privileges_ReportStatus(string module, string fieldName)
    {
        string empty = string.Empty;
        try
        {
            if (this.Session["CustomAccessRight"] != null && this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true" && this.Session["Roles_Privileges_Reports"] != null)
            {
                DataTable item = (DataTable)this.Session["Roles_Privileges_Reports"];
                foreach (DataRow row in item.Rows)
                {
                    if (row["ReportItems"].ToString().Trim().ToLower() != module)
                    {
                        continue;
                    }
                    foreach (DataColumn column in item.Columns)
                    {
                        if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                        {
                            continue;
                        }
                        empty = row[column.ColumnName].ToString();
                    }
                }
            }
        }
        catch
        {
        }
        return empty;
    }

    public void ReturnRoles_Privileges_Tabs(string module, string fieldName, string Path)
    {
        try
        {
            if (this.Session["CustomAccessRight"] != null && this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "true")
            {
                string empty = string.Empty;
                if (this.Session["Roles_Privileges_Tabs"] != null)
                {
                    DataTable item = (DataTable)this.Session["Roles_Privileges_Tabs"];
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["sectionName"].ToString().Trim().ToLower() != module)
                        {
                            continue;
                        }
                        foreach (DataColumn column in item.Columns)
                        {
                            if (column.ColumnName.ToString().Trim().ToLower() != fieldName)
                            {
                                continue;
                            }
                            empty = row[column.ColumnName].ToString();
                        }
                    }
                }
                string.Concat(this.strSitepath, "accessdenied.aspx");
                if (empty.Trim().ToLower() == "false")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
                else if (empty == "0")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
                else if (empty == "2")
                {
                    this.Session["CurrentPagePath"] = Path;
                    this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
                }
            }
        }
        catch
        {
        }
    }

    public string GetUserRolePrivilege(string module, string action)
    {
        try
        {
            if (Session["CustomAccessRight"]?.ToString().Trim().Equals("true", StringComparison.OrdinalIgnoreCase) == true &&
                Session["Roles_Privileges_Tabs"] is DataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (string.Equals(row["sectionName"]?.ToString(), module, StringComparison.OrdinalIgnoreCase))
                    {
                        if (table.Columns.Contains(action))
                        {
                            return row[action]?.ToString().ToLower() ?? string.Empty;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

        return string.Empty;
    }
    public string ReturnScreenName(string strHeaderName, int type, string diplay)
    {
        string empty = string.Empty;
        if (type != 1)
        {
            empty = Convert.ToString(this.Session[string.Concat("S_", strHeaderName)]);
            empty = this.ReturnSigular_Or_Plural(empty, "s");
        }
        else
        {
            empty = Convert.ToString(this.Session[string.Concat("S_", strHeaderName)]);
            empty = this.ReturnSigular_Or_Plural(empty, "p");
        }
        return this.ToTitleCase(empty, diplay);
    }

    public string ReturnSigular_Or_Plural(string str, string type)
    {
        try
        {
            if (type == "s")
            {
                str = this.SpecialDecode(str);
                char[] charArray = str.ToLower().ToCharArray();
                if (charArray[(int)charArray.Length - 1] == '\'' || charArray[(int)charArray.Length - 1] == '\"')
                {
                    char chr = charArray[(int)charArray.Length - 1];
                    if (charArray[(int)charArray.Length - 2] == 's' && charArray[(int)charArray.Length - 3] == 'e' && charArray[(int)charArray.Length - 4] == 'i')
                    {
                        str = str.Substring(0, str.Length - 4);
                        str = string.Concat(str, "y");
                        str = string.Concat(str, chr);
                    }
                    else if (charArray[(int)charArray.Length - 2] == 's' && (charArray[(int)charArray.Length - 3] != 'e' || charArray[(int)charArray.Length - 4] != 'i'))
                    {
                        str = str.Substring(0, str.Length - 2);
                        str = string.Concat(str, chr);
                    }
                }
                else if (charArray[(int)charArray.Length - 1] == 's' && charArray[(int)charArray.Length - 2] == 'e' && charArray[(int)charArray.Length - 3] == 'i')
                {
                    str = str.Substring(0, str.Length - 3);
                    str = string.Concat(str, "y");
                }
                else if (charArray[(int)charArray.Length - 1] == 's' && (charArray[(int)charArray.Length - 2] != 'e' || charArray[(int)charArray.Length - 3] != 'i'))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else if (type == "p")
            {
                str = this.SpecialDecode(str);
                char[] chrArray = str.ToLower().ToCharArray();
                if (chrArray[(int)chrArray.Length - 1] != '\'' && chrArray[(int)chrArray.Length - 1] != '\"')
                {
                    if (chrArray[(int)chrArray.Length - 1] == 'y')
                    {
                        str = str.Substring(0, str.Length - 1);
                        str = string.Concat(str, "ies");
                    }
                    else if (chrArray[(int)chrArray.Length - 1] != 'y' && chrArray[(int)chrArray.Length - 1] != 's')
                    {
                        str = string.Concat(str, "s");
                    }
                }
                else if (chrArray[(int)chrArray.Length - 2] == 'y')
                {
                    char chr1 = chrArray[(int)chrArray.Length - 1];
                    str = str.Substring(0, str.Length - 2);
                    str = string.Concat(str, "ies");
                    str = string.Concat(str, chr1);
                }
                else if (chrArray[(int)chrArray.Length - 2] != 'y' && chrArray[(int)chrArray.Length - 2] != 's')
                {
                    char chr2 = chrArray[(int)chrArray.Length - 1];
                    str = str.Substring(0, str.Length - 1);
                    str = string.Concat(str, "s");
                    str = string.Concat(str, chr2);
                }
            }
        }
        catch
        {
        }
        return str;
    }

    public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml)
    {
        BaseClass baseClass = new BaseClass();
        long num = (long)0;
        string empty = string.Empty;
        if (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() == "1")
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else if (HttpContext.Current.Session["email"] == null)
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else
        {
            from = HttpContext.Current.Session["email"].ToString();
        }
        try
        {
            empty = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString()));
        }
        catch
        {
            //empty = "support@eprintsoftware.com";
            empty = "support@hexicomsoftware.com";
        }
        if (HttpContext.Current.Session["userID"] != null)
        {
            num = long.Parse(HttpContext.Current.Session["userID"].ToString());
        }
        long num1 = (long)0;
        string str = string.Empty;
        if (HttpContext.Current.Session["RegistrationCid"] == null)
        {
            num1 = long.Parse(HttpContext.Current.Session["companyID"].ToString());
            str = HttpContext.Current.Session["email"].ToString();
        }
        else
        {
            num1 = long.Parse(HttpContext.Current.Session["RegistrationCid"].ToString());
            str = empty;
            HttpContext.Current.Session["RegistrationCid"] = null;
        }
        string str1 = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
        string str2 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
        SqlConnection sqlConnection = new SqlConnection(str2);
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand.Parameters.AddWithValue("@ServerName", str1);
        sqlCommand.Parameters.AddWithValue("@CompanyID", num1);
        sqlCommand.Parameters.AddWithValue("@DBID", 0);
        sqlCommand.Parameters.AddWithValue("@FromEmail", from);
        sqlCommand.Parameters.AddWithValue("@ReplyTo", str);
        sqlCommand.Parameters.AddWithValue("@ToEmails", baseClass.SpecialDecode(to));
        sqlCommand.Parameters.AddWithValue("@CCEmails", baseClass.SpecialDecode(cc));
        sqlCommand.Parameters.AddWithValue("@BCCEmails", baseClass.SpecialDecode(bcc));
        sqlCommand.Parameters.AddWithValue("@EmailSubject", baseClass.SpecialDecode(subject));
        sqlCommand.Parameters.AddWithValue("@EmailBody", baseClass.SpecialDecode(body));
        sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
        sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
        sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
        SqlParameterCollection parameters = sqlCommand.Parameters;
        DateTime now = DateTime.Now;
        parameters.AddWithValue("@CreatedOn", now.ToString());
        sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
        sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
        sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
        sqlCommand.Parameters.AddWithValue("@StoreName", "");
        sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        sqlConnection.Dispose();
    }

    public static void SendMailMessage_DeliveryStatusChange(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml, int DelStatusID, int Deliveryid)
    {
        BaseClass baseClass = new BaseClass();
        long num = (long)0;
        string empty = string.Empty;
        if (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() == "1")
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else if (HttpContext.Current.Session["email"] == null)
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else
        {
            from = HttpContext.Current.Session["email"].ToString();
        }
        try
        {
            empty = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString()));
        }
        catch
        {
            //empty = "support@eprintsoftware.com";
            empty = "support@hexicomsoftware.com";
        }
        if (HttpContext.Current.Session["userID"] != null)
        {
            num = long.Parse(HttpContext.Current.Session["userID"].ToString());
        }
        if (HttpContext.Current.Session["userID"] != null)
        {
            num = long.Parse(HttpContext.Current.Session["userID"].ToString());
        }
        string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
        string str1 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
        SqlConnection sqlConnection = new SqlConnection(str1);
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("PC_SendMailMessage_DeliveryStatusChange", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand.Parameters.AddWithValue("@ServerName", str);
        if (HttpContext.Current.Session["RegistrationCid"] != null)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(HttpContext.Current.Session["RegistrationCid"].ToString()));
            HttpContext.Current.Session["RegistrationCid"] = null;
        }
        else if (HttpContext.Current.Session["companyID"] != null)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(HttpContext.Current.Session["companyID"].ToString()));
        }
        sqlCommand.Parameters.AddWithValue("@DBID", 0);
        sqlCommand.Parameters.AddWithValue("@FromEmail", from);
        sqlCommand.Parameters.AddWithValue("@ReplyTo", HttpContext.Current.Session["email"].ToString());
        sqlCommand.Parameters.AddWithValue("@ToEmails", to);
        sqlCommand.Parameters.AddWithValue("@CCEmails", baseClass.SpecialDecode(cc));
        sqlCommand.Parameters.AddWithValue("@BCCEmails", baseClass.SpecialDecode(bcc));
        sqlCommand.Parameters.AddWithValue("@EmailSubject", baseClass.SpecialDecode(subject));
        sqlCommand.Parameters.AddWithValue("@EmailBody", baseClass.SpecialDecode(body));
        sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
        sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
        sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
        SqlParameterCollection parameters = sqlCommand.Parameters;
        DateTime now = DateTime.Now;
        parameters.AddWithValue("@CreatedOn", now.ToString());
        sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
        sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
        sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
        sqlCommand.Parameters.AddWithValue("@StoreName", "");
        sqlCommand.Parameters.AddWithValue("@JobStatusID", DelStatusID);
        sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
        sqlCommand.Parameters.AddWithValue("@DeliveryID", Deliveryid);
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        sqlConnection.Dispose();
    }

    public static void SendMailMessageJobStatusChange(string from, string to, string bcc, string cc, string subject, string body, string strattachments, bool isHtml, int JobStatusID, int JobID)
    {
        BaseClass baseClass = new BaseClass();
        long num = (long)0;
        string empty = string.Empty;
        if (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() == "1")
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else if (HttpContext.Current.Session["email"] == null)
        {
            from = EprintConfigurationManager.AppSettings["FromEmail"].ToString();
        }
        else
        {
            from = HttpContext.Current.Session["email"].ToString();
        }
        try
        {
            empty = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString()));
        }
        catch
        {
            //empty = "support@eprintsoftware.com";
            empty = "support@hexicomsoftware.com";
        }
        if (HttpContext.Current.Session["userID"] != null)
        {
            num = long.Parse(HttpContext.Current.Session["userID"].ToString());
        }
        if (HttpContext.Current.Session["userID"] != null)
        {
            num = long.Parse(HttpContext.Current.Session["userID"].ToString());
        }
        string str = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
        string str1 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
        SqlConnection sqlConnection = new SqlConnection(str1);
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("PC_SendMailMessageJobStatusChange", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand.Parameters.AddWithValue("@ServerName", str);
        if (HttpContext.Current.Session["RegistrationCid"] != null)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(HttpContext.Current.Session["RegistrationCid"].ToString()));
            HttpContext.Current.Session["RegistrationCid"] = null;
        }
        else if (HttpContext.Current.Session["companyID"] != null)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyID", long.Parse(HttpContext.Current.Session["companyID"].ToString()));
        }
        sqlCommand.Parameters.AddWithValue("@DBID", 0);
        sqlCommand.Parameters.AddWithValue("@FromEmail", from);
        sqlCommand.Parameters.AddWithValue("@ReplyTo", HttpContext.Current.Session["email"].ToString());
        sqlCommand.Parameters.AddWithValue("@ToEmails", to);
        sqlCommand.Parameters.AddWithValue("@CCEmails", baseClass.SpecialDecode(cc));
        sqlCommand.Parameters.AddWithValue("@BCCEmails", baseClass.SpecialDecode(bcc));
        sqlCommand.Parameters.AddWithValue("@EmailSubject", baseClass.SpecialDecode(subject));
        sqlCommand.Parameters.AddWithValue("@EmailBody", baseClass.SpecialDecode(body));
        sqlCommand.Parameters.AddWithValue("@EmailAttachment", strattachments);
        sqlCommand.Parameters.AddWithValue("@IsHtml", isHtml);
        sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
        SqlParameterCollection parameters = sqlCommand.Parameters;
        DateTime now = DateTime.Now;
        parameters.AddWithValue("@CreatedOn", now.ToString());
        sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
        sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
        sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
        sqlCommand.Parameters.AddWithValue("@StoreName", "");
        sqlCommand.Parameters.AddWithValue("@JobStatusID", JobStatusID);
        sqlCommand.Parameters.AddWithValue("@JobID", JobID);
        sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        sqlConnection.Dispose();
    }
    //public static void SendMailMessageSecondApprover(int ProofID, string ServerName, int CompanyID, bool IsHtml, string HostName, int UserID, int ClientID, int EstimateID, string Name, string Email)
    //{
    //    long num = (long)0;
    //    string empty = string.Empty;
    //    DataTable dt = SettingsBasePage.PC_SecondApproval_Email(CompanyID, ProofID, "Second Approval Emails");
    //    try
    //    {
    //        empty = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(CompanyID));
    //    }
    //    catch
    //    {
    //        empty = "support@eprintsoftware.com";
    //    }
    //    num = long.Parse(dt.Rows[0]["UserID"].ToString());
    //    long num1 = (long)0;
    //    string str = string.Empty;
    //    num1 = long.Parse(CompanyID.ToString());
    //    string msgBody = dt.Rows[0]["Body"].ToString();
    //    if (msgBody.Contains("[$ApproverName$]"))
    //    {
    //        msgBody = msgBody.Replace("[$ApproverName$]", Name);
    //    }
    //    if (msgBody.Contains("[$ApproverEmail$]"))
    //    {
    //        msgBody = msgBody.Replace("[$ApproverEmail$]", Email);
    //    }


    //    DateTime _date = DateTime.Now;
    //    string dateTime = string.Format("{0:MM/dd/yyyyhh:mm:ss}", _date).Replace("/", "").Replace(":", "");
    //    var url = HostName + "/proof/";
    //    string[] _params;
    //    _params = new string[] { "hName=", HostName, "&uID=", UserID.ToString() , "&cID=", CompanyID.ToString(), "&PID=", ProofID.ToString(), "&EID=", EstimateID.ToString(), "&CLID=", ClientID.ToString() };
    //    string _parameters = string.Concat(_params);
    //    string encryptedUrl = commonClass.Base64Encode(_parameters);
    //    string urlWithParams = url + "ProofListingItem?params=" + encryptedUrl;
    //    string finalUrl = string.Concat(urlWithParams, dateTime);
    //    msgBody = msgBody.Replace(url, finalUrl);

    //    string str2 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
    //    SqlConnection sqlConnection = new SqlConnection(str2);
    //    sqlConnection.Open();
    //    SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
    //    {
    //        CommandType = CommandType.StoredProcedure
    //    };
    //    sqlCommand.Parameters.AddWithValue("@ServerName", ServerName);
    //    sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
    //    sqlCommand.Parameters.AddWithValue("@DBID", 0);
    //    sqlCommand.Parameters.AddWithValue("@FromEmail", dt.Rows[0]["FromEmail"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@ReplyTo", dt.Rows[0]["FromEmail"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@ToEmails", Email);
    //    sqlCommand.Parameters.AddWithValue("@CCEmails", "");
    //    sqlCommand.Parameters.AddWithValue("@BCCEmails", "");
    //    sqlCommand.Parameters.AddWithValue("@EmailSubject", dt.Rows[0]["Subject"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@EmailBody", msgBody);
    //    sqlCommand.Parameters.AddWithValue("@EmailAttachment", "");
    //    sqlCommand.Parameters.AddWithValue("@IsHtml", IsHtml);
    //    sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
    //    SqlParameterCollection parameters = sqlCommand.Parameters;
    //    DateTime now = DateTime.Now;
    //    parameters.AddWithValue("@CreatedOn", now);
    //    sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
    //    sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
    //    sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
    //    sqlCommand.Parameters.AddWithValue("@StoreName", "");
    //    sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
    //    sqlCommand.ExecuteNonQuery();
    //    sqlConnection.Close();
    //    sqlConnection.Dispose();
    //}
    //public static void SendProofMailMessage(int ProofID, string ServerName, int CompanyID, bool IsHtml, string Comments, string Status, long EstimateID)
    //{
    //    long num = (long)0;
    //    string empty = string.Empty;
    //    DataTable dt = SettingsBasePage.PC_GetProofEmailDetails(ProofID, CompanyID);
    //    string cc = string.Empty;
    //    string bcc = string.Empty;
    //    if (!string.IsNullOrEmpty(dt.Rows[0]["CC"].ToString()))
    //    {
    //        cc = dt.Rows[0]["CC"].ToString();
    //    }
    //    if (!string.IsNullOrEmpty(dt.Rows[0]["BCC"].ToString()))
    //    {
    //        bcc = dt.Rows[0]["BCC"].ToString();
    //    }
    //    try
    //    {
    //        empty = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(CompanyID));
    //    }
    //    catch
    //    {
    //        empty = "support@eprintsoftware.com";
    //    }
    //    num = long.Parse(dt.Rows[0]["UserID"].ToString());
    //    long num1 = (long)0;
    //    string str = string.Empty;
    //    num1 = long.Parse(CompanyID.ToString());
    //    string msgBody = dt.Rows[0]["Body"].ToString();
    //    if (msgBody.Contains("[$CustomerComments$]"))
    //    {
    //        msgBody = msgBody.Replace("[$CustomerComments$]", Comments);
    //    }
    //    if (msgBody.Contains("[$FileStatus$]"))
    //    {
    //        msgBody = msgBody.Replace("[$FileStatus$]", Status);
    //    }
    //    if (EstimateID != 0)
    //    {
    //        DataTable dt1 = SettingsBasePage.settings_proof_template_select(CompanyID, EstimateID, "");
    //        foreach (DataRow dr in dt1.Rows)
    //        {
    //            if (msgBody.Contains("[$EstimateOrJobname$]"))
    //            {
    //                msgBody = msgBody.Replace("[$EstimateOrJobname$]", dr["Title"].ToString());
    //            }
    //            if (msgBody.Contains("[$CustomerName$]"))
    //            {
    //                msgBody = msgBody.Replace("[$CustomerName$]", dr["CustomerName"].ToString());
    //            }
    //            if (msgBody.Contains("[$CustomerContactName$]"))
    //            {
    //                msgBody = msgBody.Replace("[$CustomerContactName$]", dr["CustomerContactFullName"].ToString());
    //            }
    //            if (msgBody.Contains("[$ProofNumber$]"))
    //            {
    //                msgBody = msgBody.Replace("[$ProofNumber$]", dr["ProofNumber"].ToString());
    //            }
    //            if (msgBody.Contains("[$EstimateNumber$]"))
    //            {
    //                msgBody = msgBody.Replace("[$EstimateNumber$]", dr["EstimateNumber"].ToString());
    //            }
    //            if (msgBody.Contains("[$OrderNumber$]"))
    //            {
    //                msgBody = msgBody.Replace("[$OrderNumber$]", dr["JobOrderNumber"].ToString());
    //            }
    //            if (msgBody.Contains("[$JobNumber$]"))
    //            {
    //                msgBody = msgBody.Replace("[$JobNumber$]", dr["JobNumber"].ToString());
    //            }
    //        }
    //    }
    //    string str2 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
    //    SqlConnection sqlConnection = new SqlConnection(str2);
    //    sqlConnection.Open();
    //    SqlCommand sqlCommand = new SqlCommand("PC_EmailsToSend_Insert", sqlConnection)
    //    {
    //        CommandType = CommandType.StoredProcedure
    //    };
    //    sqlCommand.Parameters.AddWithValue("@ServerName", ServerName);
    //    sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
    //    sqlCommand.Parameters.AddWithValue("@DBID", 0);
    //    sqlCommand.Parameters.AddWithValue("@FromEmail", dt.Rows[0]["FromEmail"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@ReplyTo", dt.Rows[0]["FromEmail"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@ToEmails", dt.Rows[0]["ToEmail"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@CCEmails", cc);
    //    sqlCommand.Parameters.AddWithValue("@BCCEmails", bcc);
    //    sqlCommand.Parameters.AddWithValue("@EmailSubject", dt.Rows[0]["Subject"].ToString());
    //    sqlCommand.Parameters.AddWithValue("@EmailBody", msgBody);
    //    sqlCommand.Parameters.AddWithValue("@EmailAttachment", "");
    //    sqlCommand.Parameters.AddWithValue("@IsHtml", IsHtml);
    //    sqlCommand.Parameters.AddWithValue("@CreatedBY", num);
    //    SqlParameterCollection parameters = sqlCommand.Parameters;
    //    DateTime now = DateTime.Now;
    //    parameters.AddWithValue("@CreatedOn", now);
    //    sqlCommand.Parameters.AddWithValue("@IsEmailSent", 0);
    //    sqlCommand.Parameters.AddWithValue("@EmailSentOn", "");
    //    sqlCommand.Parameters.AddWithValue("@ErrorMessage", "No Error");
    //    sqlCommand.Parameters.AddWithValue("@StoreName", "");
    //    sqlCommand.Parameters.AddWithValue("@FromEmailName", empty);
    //    sqlCommand.ExecuteNonQuery();
    //    sqlConnection.Close();
    //    sqlConnection.Dispose();
    //}

    public void Session_Check()
    {
        if (this.Session["pagename"] == null)
        {
            HttpCookie item = this.Context.Request.Cookies["SessionStarted"];
            if (item != null)
            {
                this.Session["pagename"] = item.Value;
            }
        }
        if (this.Session["accessdenied"] != null)
        {
            this.Context.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
        }
        if (this.Session["CompanyID"] == null)
        {
            HttpCookie httpCookie = this.Context.Request.Cookies["hdnSessionId"];
            if (httpCookie != null)
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_resumeSession_select", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@hdnSessionID", httpCookie.Value.ToString());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader["ScreenResolutionWidth"].ToString() == "")
                    {
                        this.Session["ScreenResolutionWidth"] = 1366;
                    }
                    else
                    {
                        this.Session["ScreenResolutionWidth"] = sqlDataReader["ScreenResolutionWidth"].ToString();
                    }
                    loginClass _loginClass = new loginClass();
                    _loginClass.LogInFromBaseClass(sqlDataReader["email"].ToString(), sqlDataReader["password"].ToString());
                }
                sqlDataReader.Close();
                _commonClass.closeConnection();
            }
        }
        commonClass _commonClass1 = new commonClass();
        SqlCommand sqlCommand1 = new SqlCommand("crm_selecttheme", _commonClass1.openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand1.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        if (this.Session["CompanyID"] != null)
        {
            sqlCommand1.Parameters.Add("@companyId", Convert.ToInt32(this.Session["CompanyID"]));
        }
        else
        {
            sqlCommand1.Parameters.Add("@companyId", "0");
        }
        SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
        while (sqlDataReader1.Read())
        {
            if (this.ShouldApplyRuntimeTheme())
            {
                this.TryApplyTheme(sqlDataReader1["theme"].ToString());
            }
            global.strimagepath = string.Concat(global.sitePath(), sqlDataReader1["ImageFolder"].ToString(), "/");
        }
        sqlDataReader1.Close();
        if (string.IsNullOrEmpty(global.strimagepath))
        {
            if (this.ShouldApplyRuntimeTheme())
            {
                this.TryApplyTheme("Theme1");
            }
            global.strimagepath = string.Concat(global.sitePath(), "images/");
        }
        _commonClass1.closeConnection();
        commonClass _commonClass2 = new commonClass();
        SqlCommand sqlCommand2 = new SqlCommand("crm_groupenable_select", _commonClass2.openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand2.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        if (this.Session["CompanyID"] != null)
        {
            sqlCommand2.Parameters.Add("@companyId", Convert.ToInt32(this.Session["CompanyID"]));
        }
        else
        {
            sqlCommand2.Parameters.Add("@companyId", "0");
        }
        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
        while (sqlDataReader2.Read())
        {
            if (sqlDataReader2["isgroupenabled"].ToString().ToLower().Trim() != "true")
            {
                this.Session["isgroupenabled"] = "false";
            }
            else
            {
                this.Session["isgroupenabled"] = "true";
            }
        }
        sqlDataReader2.Close();
        _commonClass2.closeConnection();
        commonClass _commonClass3 = new commonClass();
        SqlCommand sqlCommand3 = new SqlCommand("crm_common_assignment", _commonClass3.openConnection())
        {
            CommandType = CommandType.StoredProcedure
        };
        sqlCommand3.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
        if (this.Session["userID"] != null)
        {
            sqlCommand3.Parameters.Add("@userid", Convert.ToInt32(this.Session["userID"]));
        }
        else
        {
            sqlCommand3.Parameters.Add("@userid", "0");
        }
        if (this.Session["companyID"] != null)
        {
            sqlCommand3.Parameters.Add("@companyid", Convert.ToInt32(this.Session["companyID"]));
        }
        else
        {
            sqlCommand3.Parameters.Add("@companyid", "0");
        }
        SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
        while (sqlDataReader3.Read())
        {
            if (sqlDataReader3["AssignmentSetting"].ToString().ToLower() != "a")
            {
                this.Session["IsAutomaticSetting"] = "false";
            }
            else
            {
                this.Session["IsAutomaticSetting"] = "true";
            }
            if (sqlDataReader3["isMyRecordsOnly"].ToString().ToLower() != "false")
            {
                this.Session["ViewAll"] = "false";
            }
            else
            {
                this.Session["ViewAll"] = "true";
            }
        }
        sqlDataReader3.Close();
        _commonClass3.closeConnection();
        if (this.Session["CompanyID"] == null)
        {
            this.Session["DirectLogin"] = base.Request.Url.ToString();
            this.Context.Response.Redirect(string.Concat(this.strSitepath, "default.aspx"));
        }
        if (this.Session["email"] != null)
        {
            int num = HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("securitycheck");
            int num1 = HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("default");
            int num2 = HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("error");
            int num3 = HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("error_report");
            if (int.Parse(num.ToString()) > 0 | int.Parse(num1.ToString()) > 0 | int.Parse(num2.ToString()) > 0 | int.Parse(num3.ToString()) > 0)
            {
                string str = this.Session["email"].ToString();
                bool flag = (string)HttpContext.Current.Cache[str] != this.Session.SessionID.ToString();
            }
        }
        if (this.Session["userTypeID"] != null)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_RolesAndPrivileges_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int32, Convert.ToInt32(this.Session["userTypeID"]));
            dataSet = database.ExecuteDataSet(storedProcCommand);
            this.Session["Roles_Privileges_Others"] = dataSet.Tables[0];
            this.Session["Roles_Privileges_Tabs"] = dataSet.Tables[1];
            this.Session["Roles_Privileges_Reports"] = dataSet.Tables[2];
        }
    }

    public void SetDDLText(DropDownList ddl, string value)
    {
        try
        {
            ListItem listItem = ddl.Items.FindByText(value);
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
        catch
        {
        }
    }

    public void SetDDLValue(DropDownList ddl, string value)
    {
        try
        {
            ListItem listItem = ddl.Items.FindByValue(value);
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
        catch
        {
            ddl.SelectedIndex = 0;
        }
    }

    public string SpecialDecode(string OriginalString)
    {
        if (string.IsNullOrEmpty(OriginalString))
        {
            return string.Empty;
        }
        if (OriginalString.Contains("Tickets req%27d for AKL"))
        {
            var id = 0;
        }
        OriginalString = OriginalString.Replace("%27", "'");
        OriginalString = OriginalString.Replace("%22", "\"");
       
        return OriginalString;
    }

    public string SpecialEncode(string OriginalString)
    {
        if (string.IsNullOrEmpty(OriginalString))
        {
            return string.Empty;
        }
        OriginalString = OriginalString.Replace("'", "%27");
        OriginalString = OriginalString.Replace("\"", "%22");
        return OriginalString;
    }

    public string RemoveLineBreak(string OriginalString)
    {
        OriginalString = OriginalString.Replace("\n", "");
        OriginalString = OriginalString.Replace("\r", "");
        return OriginalString;
    }

    public void StockAllocation(long PriceCatalogueID, long PricecatalogueStockID, int AllocatedQty, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockAllocation_Others(long CompanyID, long PriceCatalogueID, int MaxKitAvailable, string Metohd_Type, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
    {
        string[] strArrays = Metohd_Type.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        string empty = string.Empty;
        long num1 = (long)0;
        int num2 = 0;
        empty = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FinalKitStockDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NumberOfKit", DbType.Int32, MaxKitAvailable);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_FinalKitStockDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@NumberOfKit", DbType.Int32, MaxKitAvailable);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count <= 0)
            {
                empty = this.objLanguage.GetLanguageConversion("No_Stock_Available");
            }
            else
            {
                foreach (DataRow row in item.Rows)
                {
                    num1 = Convert.ToInt64(row["KitItemID"].ToString());
                    num2 = Convert.ToInt32(row["TotalRequiredQtyPerKit"].ToString());
                    empty = this.StockAllocationProcess(CompanyID, num1, PriceCatalogueID, num2, str, string.Concat("others¶", num.ToString()), IsPickStockFromOneLocation, ModuleID, ModuleName, Price, CreatedBy);
                    if (empty == null || !(empty != ""))
                    {
                        continue;
                    }
                    empty = string.Concat(empty, ",");
                }
                if (empty.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")) || empty.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")))
                {
                    string empty1 = string.Empty;
                    bool flag = false;
                    if (empty.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        flag = true;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_with_backorder_for_Job"), " #", ModuleID);
                    }
                    else if (empty.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")))
                    {
                        flag = false;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_for_Job"), " #", ModuleID);
                    }
                    long num3 = (long)0;
                    num3 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, PriceCatalogueID, ModuleID, ModuleName, "others", (long)0, MaxKitAvailable, 0, "Allocated", Price, CreatedBy, flag) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, PriceCatalogueID, ModuleID, ModuleName, "others", (long)0, MaxKitAvailable, 0, "Allocated", Price, CreatedBy, flag, num));
                    this.KitStockAllocationOrReduction(PriceCatalogueID, MaxKitAvailable, 'a', CreatedBy);
                    this.StockAllocationManagementHistory_Save(num3, PriceCatalogueID, "Allocated", empty1, MaxKitAvailable, 0, 0, 0, CreatedBy, (long)0);
                }
            }
        }
        return empty;
    }

    public void StockAllocationAddOpt(long PriceCatalogueID, long PricecatalogueStockAdditionalId, int AllocatedQty, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation_AdditionalOption");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockAdditionalId", DbType.Int64, PricecatalogueStockAdditionalId);
        database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockAllocationForAdditionalOption(long CompanyID, long PriceCatalogueID, int Quantity, string MetohdType, string Process_Type, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
    {
        string[] strArrays = Process_Type.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        string empty = string.Empty;
        string empty1 = string.Empty;
        int quantity = 0;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        bool flag = false;
        string str1 = string.Empty;
        empty = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAdditionalOptionsDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAdditionalOptionsDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(dbCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(dbCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            DataTable dataTable = dataSet.Tables[1];
            DataTable item1 = dataSet.Tables[2];
            DataTable dataTable1 = dataSet.Tables[3];
            foreach (DataRow row in dataTable.Rows)
            {
                flag = Convert.ToBoolean(row["IsBackOrder"].ToString());
            }
            foreach (DataRow dataRow in item1.Rows)
            {
                string str2 = dataRow["webothercostName"].ToString();
                string str3 = dataRow["Label"].ToString();
                dataRow["webothercostid"].ToString();
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    if (!(str2 == row1["OptionName"].ToString()) || !(str3 == row1["OptionValue"].ToString()))
                    {
                        continue;
                    }
                    str1 = (Convert.ToInt32(row1["AvailableStock"].ToString()) < Quantity ? string.Concat(str1, "true,") : string.Concat(str1, "false,"));
                }
            }
            foreach (DataRow dataRow1 in item1.Rows)
            {
                quantity = Quantity;
                if (str1.Contains("false"))
                {
                    foreach (DataRow row2 in item.Rows)
                    {
                        long num7 = Convert.ToInt64(row2["PricecatalogueStockAdditionalId"].ToString());
                        num4 = Convert.ToInt32(row2["OpeningStock"].ToString());
                        num3 = Convert.ToInt32(row2["AllocatedStock"].ToString());
                        num2 = Convert.ToInt32(row2["AvailableStock"].ToString());
                        int num8 = Convert.ToInt32(row2["webothercostid"].ToString());
                        string str4 = row2["webothercostName"].ToString();
                        string str5 = row2["Label"].ToString();
                        if (quantity == 0 || !(dataRow1["webothercostName"].ToString() == str4) || !(dataRow1["Label"].ToString() == str5) || Convert.ToInt32(dataRow1["webothercostid"].ToString()) != num8)
                        {
                            continue;
                        }
                        if (quantity > num2)
                        {
                            num1 = num2;
                            if (num2 < 0)
                            {
                                num1 = 0;
                            }
                            quantity = quantity - num1;
                            num2 = 0;
                        }
                        else
                        {
                            num1 = quantity;
                            num2 = num2 - num1;
                            quantity = 0;
                        }
                        num3 = num3 + num1;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Additional_Options_Stock_allocated_for_Job"), " #", ModuleID);
                        if (num1 == 0)
                        {
                            continue;
                        }
                        long num9 = (long)0;
                        num9 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num7, num1, 0, "Allocated", Price, CreatedBy, false) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num7, num1, 0, "Allocated", Price, CreatedBy, false, num));
                        this.StockAllocationAddOpt(PriceCatalogueID, num7, num1, CreatedBy);
                        this.StockAllocationManagementHistory_Save(num9, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, num7);
                    }
                    empty = this.objLanguage.GetLanguageConversion("Stock_allocated_successfully");
                }
                else if (!flag)
                {
                    empty = this.objLanguage.GetLanguageConversion("Back_order_not_available_for_this_stock");
                }
                else
                {
                    foreach (DataRow dataRow2 in dataTable1.Rows)
                    {
                        string str6 = dataRow1["webothercostName"].ToString();
                        string str7 = dataRow1["Label"].ToString();
                        dataRow1["webothercostid"].ToString();
                        if (!(str6 == dataRow2["OptionName"].ToString()) || !(str7 == dataRow2["OptionValue"].ToString()))
                        {
                            continue;
                        }
                        num6 = Convert.ToInt32(dataRow2["AvailableStock"].ToString());
                    }
                    num5 = quantity - num6;
                    if (num6 < 0)
                    {
                        num5 = quantity;
                    }
                    foreach (DataRow row3 in item.Rows)
                    {
                        long num10 = Convert.ToInt64(row3["PricecatalogueStockAdditionalId"].ToString());
                        num4 = Convert.ToInt32(row3["OpeningStock"].ToString());
                        num3 = Convert.ToInt32(row3["AllocatedStock"].ToString());
                        num2 = Convert.ToInt32(row3["AvailableStock"].ToString());
                        int num11 = Convert.ToInt32(row3["webothercostid"].ToString());
                        string str8 = row3["webothercostName"].ToString();
                        string str9 = row3["Label"].ToString();
                        if (quantity == 0 || !(dataRow1["webothercostName"].ToString() == str8) || !(dataRow1["Label"].ToString() == str9) || Convert.ToInt32(dataRow1["webothercostid"].ToString()) != num11)
                        {
                            continue;
                        }
                        if (quantity > num2)
                        {
                            num1 = num2;
                            if (num2 < 0)
                            {
                                num1 = 0;
                            }
                            quantity = quantity - num1;
                            num2 = 0;
                        }
                        else
                        {
                            num1 = quantity;
                            num2 = num2 - num1;
                            quantity = 0;
                        }
                        num3 = num3 + num1;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_with_backorder_for_Job"), " #", ModuleID);
                        if (num5 == quantity)
                        {
                            num1 = num1 + num5;
                            num3 = num3 + num5;
                            num2 = num4 - num3;
                            quantity = 0;
                        }
                        if (num1 != 0)
                        {
                            long num12 = (long)0;
                            num12 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num10, num1, 0, "Allocated", Price, CreatedBy, true) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num10, num1, 0, "Allocated", Price, CreatedBy, true, num));
                            this.StockAllocationAddOpt(PriceCatalogueID, num10, num1, CreatedBy);
                            this.StockAllocationManagementHistory_Save(num12, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, num10);
                        }
                        empty = this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully");
                    }
                }
            }
        }
        return empty;
    }

    public string StockAllocationForAdditionalOptionEstore(long CompanyID, long PriceCatalogueID, int Quantity, string MetohdType, string Process_Type, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy, long OrderID, long OrderItemID)
    {
        string[] strArrays = Process_Type.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        string empty = string.Empty;
        string empty1 = string.Empty;
        int quantity = 0;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        bool flag = false;
        string str1 = string.Empty;
        empty = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_StockAdditionalOptionsDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_B2B_StockAdditionalOptionsDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(dbCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(dbCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            DataTable dataTable = dataSet.Tables[1];
            DataTable item1 = dataSet.Tables[2];
            DataTable dataTable1 = dataSet.Tables[3];
            foreach (DataRow row in dataTable.Rows)
            {
                flag = Convert.ToBoolean(row["IsBackOrder"].ToString());
            }
            foreach (DataRow dataRow in item1.Rows)
            {
                string str2 = dataRow["webothercostName"].ToString();
                string str3 = dataRow["Label"].ToString();
                dataRow["webothercostid"].ToString();
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    if (!(str2 == row1["OptionName"].ToString()) || !(str3 == row1["OptionValue"].ToString()))
                    {
                        continue;
                    }
                    str1 = (Convert.ToInt32(row1["AvailableStock"].ToString()) < Quantity ? string.Concat(str1, "true,") : string.Concat(str1, "false,"));
                }
            }
            foreach (DataRow dataRow1 in item1.Rows)
            {
                quantity = Quantity;
                if (str1.Contains("false"))
                {
                    foreach (DataRow row2 in item.Rows)
                    {
                        long num7 = Convert.ToInt64(row2["PricecatalogueStockAdditionalId"].ToString());
                        num4 = Convert.ToInt32(row2["OpeningStock"].ToString());
                        num3 = Convert.ToInt32(row2["AllocatedStock"].ToString());
                        num2 = Convert.ToInt32(row2["AvailableStock"].ToString());
                        int num8 = Convert.ToInt32(row2["webothercostid"].ToString());
                        string str4 = row2["webothercostName"].ToString();
                        string str5 = row2["Label"].ToString();
                        if (quantity == 0 || !(dataRow1["webothercostName"].ToString() == str4) || !(dataRow1["Label"].ToString() == str5) || Convert.ToInt32(dataRow1["webothercostid"].ToString()) != num8)
                        {
                            continue;
                        }
                        if (quantity > num2)
                        {
                            num1 = num2;
                            if (num2 < 0)
                            {
                                num1 = 0;
                            }
                            quantity = quantity - num1;
                            num2 = 0;
                        }
                        else
                        {
                            num1 = quantity;
                            num2 = num2 - num1;
                            quantity = 0;
                        }
                        num3 = num3 + num1;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Additional_Options_Stock_allocated_for_Job"), " #", ModuleID);
                        if (num1 == 0)
                        {
                            continue;
                        }
                        long num9 = (long)0;
                        num9 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num7, num1, 0, "Allocated", Price, CreatedBy, false) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num7, num1, 0, "Allocated", Price, CreatedBy, false, num));
                        this.StockAllocationAddOpt(PriceCatalogueID, num7, num1, CreatedBy);
                        this.StockAllocationManagementHistory_Save(num9, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, num7);
                    }
                    empty = this.objLanguage.GetLanguageConversion("Stock_allocated_successfully");
                }
                else if (!flag)
                {
                    empty = this.objLanguage.GetLanguageConversion("Back_order_not_available_for_this_stock");
                }
                else
                {
                    foreach (DataRow dataRow2 in dataTable1.Rows)
                    {
                        string str6 = dataRow1["webothercostName"].ToString();
                        string str7 = dataRow1["Label"].ToString();
                        dataRow1["webothercostid"].ToString();
                        if (!(str6 == dataRow2["OptionName"].ToString()) || !(str7 == dataRow2["OptionValue"].ToString()))
                        {
                            continue;
                        }
                        num6 = Convert.ToInt32(dataRow2["AvailableStock"].ToString());
                    }
                    num5 = quantity - num6;
                    if (num6 < 0)
                    {
                        num5 = quantity;
                    }
                    foreach (DataRow row3 in item.Rows)
                    {
                        long num10 = Convert.ToInt64(row3["PricecatalogueStockAdditionalId"].ToString());
                        num4 = Convert.ToInt32(row3["OpeningStock"].ToString());
                        num3 = Convert.ToInt32(row3["AllocatedStock"].ToString());
                        num2 = Convert.ToInt32(row3["AvailableStock"].ToString());
                        int num11 = Convert.ToInt32(row3["webothercostid"].ToString());
                        string str8 = row3["webothercostName"].ToString();
                        string str9 = row3["Label"].ToString();
                        if (quantity == 0)
                        {
                            continue;
                        }
                        if (dataRow1["webothercostName"].ToString() == str8 && dataRow1["Label"].ToString() == str9 && Convert.ToInt32(dataRow1["webothercostid"].ToString()) == num11)
                        {
                            if (quantity > num2)
                            {
                                num1 = num2;
                                if (num2 < 0)
                                {
                                    num1 = 0;
                                }
                                quantity = quantity - num1;
                                num2 = 0;
                            }
                            else
                            {
                                num1 = quantity;
                                num2 = num2 - num1;
                                quantity = 0;
                            }
                            num3 = num3 + num1;
                            empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_with_backorder_for_Job"), " #", ModuleID);
                            if (num5 == quantity)
                            {
                                num1 = num1 + num5;
                                num3 = num3 + num5;
                                num2 = num4 - num3;
                                quantity = 0;
                            }
                            if (num1 != 0)
                            {
                                long num12 = (long)0;
                                num12 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num10, num1, 0, "Allocated", Price, CreatedBy, true) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num10, num1, 0, "Allocated", Price, CreatedBy, true, num));
                                this.StockAllocationAddOpt(PriceCatalogueID, num10, num1, CreatedBy);
                                this.StockAllocationManagementHistory_Save(num12, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, num10);
                            }
                        }
                        empty = this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully");
                    }
                }
            }
        }
        return empty;
    }

    public void StockAllocationManagementHistory_Save(long TransactionID, long PriceCatalogueID, string ActionType, string Notes, int Quantity, int StockInHand, int AllocatedStock, int AvailableStock, long CreatedBy, long PricecatalogueStockID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementHistory_Save");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
        database.AddInParameter(storedProcCommand, "@AllocatedStock", DbType.Int32, AllocatedStock);
        database.AddInParameter(storedProcCommand, "@AvailableStock", DbType.Int32, AvailableStock);
        database.AddInParameter(storedProcCommand, "@StockInHand", DbType.Int32, StockInHand);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockAllocationProcess(long CompanyID, long PriceCatalogueID, long KitID, int Quantity, string MetohdType, string Process_Type, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
    {
        string[] strArrays = Process_Type.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        string empty = string.Empty;
        string empty1 = string.Empty;
        int quantity = Quantity;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        empty = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        if (str.ToLower() != "multiple" && KitID == (long)0)
        {
            KitID = this.GetParentIDOfOtherMultipleProduct(PriceCatalogueID);
        }
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(dbCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(dbCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            DataTable dataTable = dataSet.Tables[1];
            Queue queues = new Queue();
            foreach (DataRow row in item.Rows)
            {
                string[] str1 = new string[] { row["PricecatalogueStockID"].ToString(), "~", row["AvailableStock"].ToString(), "~", row["AllocatedStock"].ToString(), "~", row["OpeningStock"].ToString() };
                queues.Enqueue(string.Concat(str1));
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (Convert.ToInt32(dataRow["AvailableQuantity"].ToString()) < Quantity)
                {
                    bool flag = false;
                    if (!(str.ToLower() != "others") || !(str.ToLower() != "multiple"))
                    {
                        DataSet dataSet1 = new DataSet();
                        DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_CheckKitBackorder");
                        database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, KitID);
                        dataSet1 = database.ExecuteDataSet(storedProcCommand1);
                        foreach (DataRow row1 in dataSet1.Tables[0].Rows)
                        {
                            flag = Convert.ToBoolean(row1["IsBackOrder"].ToString());
                        }
                    }
                    else
                    {
                        flag = Convert.ToBoolean(dataRow["IsBackOrder"].ToString());
                    }
                    if (!flag)
                    {
                        empty = this.objLanguage.GetLanguageConversion("Back_order_not_available_for_this_stock");
                    }
                    else
                    {
                        num6 = Convert.ToInt32(dataRow["AvailableQuantity"].ToString());
                        num5 = quantity - num6;
                        if (num6 < 0)
                        {
                            num5 = quantity;
                        }
                        if (queues.Count <= 0)
                        {
                            continue;
                        }
                        while (quantity != 0)
                        {
                            if (queues.Count <= 0)
                            {
                                num5 = quantity;
                                foreach (DataRow dataRow1 in item.Rows)
                                {
                                    string[] strArrays1 = new string[] { dataRow1["PricecatalogueStockID"].ToString(), "~", dataRow1["AvailableStock"].ToString(), "~", dataRow1["AllocatedStock"].ToString(), "~", dataRow1["OpeningStock"].ToString() };
                                    queues.Enqueue(string.Concat(strArrays1));
                                }
                            }
                            else
                            {
                                string str2 = queues.Dequeue().ToString();
                                string[] strArrays2 = str2.Split(new char[] { '~' });
                                num2 = Convert.ToInt32(strArrays2[1].ToString());
                                num3 = Convert.ToInt32(strArrays2[2].ToString());
                                num4 = Convert.ToInt32(strArrays2[3].ToString());
                                if (quantity > num2)
                                {
                                    num1 = num2;
                                    if (num2 < 0)
                                    {
                                        num1 = 0;
                                    }
                                    quantity = quantity - num1;
                                    num2 = 0;
                                }
                                else
                                {
                                    num1 = quantity;
                                    num2 = num2 - num1;
                                    quantity = 0;
                                }
                                num3 = num3 + num1;
                                empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_with_backorder_for_Job"), " #", ModuleID);
                                if (num5 == quantity)
                                {
                                    num1 = num1 + num5;
                                    num3 = num3 + num5;
                                    num2 = num4 - num3;
                                    quantity = 0;
                                }
                                if (num1 == 0)
                                {
                                    continue;
                                }
                                long num7 = (long)0;
                                num7 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, Convert.ToInt64(strArrays2[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, true) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, Convert.ToInt64(strArrays2[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, true, num));
                                this.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays2[0].ToString()), num1, CreatedBy);
                                this.StockAllocationManagementHistory_Save(num7, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, Convert.ToInt64(strArrays2[0].ToString()));
                                this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "allocated");
                            }
                        }
                        empty = this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully");
                    }
                }
                else
                {
                    if (queues.Count <= 0)
                    {
                        continue;
                    }
                    while (quantity != 0)
                    {
                        if (queues.Count <= 0)
                        {
                            break;
                        }
                        string str3 = queues.Dequeue().ToString();
                        string[] strArrays3 = str3.Split(new char[] { '~' });
                        num2 = Convert.ToInt32(strArrays3[1].ToString());
                        num3 = Convert.ToInt32(strArrays3[2].ToString());
                        num4 = Convert.ToInt32(strArrays3[3].ToString());
                        if (quantity > num2)
                        {
                            num1 = num2;
                            if (num2 < 0)
                            {
                                num1 = 0;
                            }
                            quantity = quantity - num1;
                            num2 = 0;
                        }
                        else
                        {
                            num1 = quantity;
                            num2 = num2 - num1;
                            quantity = 0;
                        }
                        num3 = num3 + num1;
                        empty1 = string.Concat(this.objLanguage.GetLanguageConversion("Stock_allocated_for_Job"), " #", ModuleID);
                        if (num1 == 0)
                        {
                            continue;
                        }
                        long num8 = (long)0;
                        num8 = (num <= (long)0 ? this.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, Convert.ToInt64(strArrays3[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, false) : this.StockManagementTransaction_Save_Del((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, Convert.ToInt64(strArrays3[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, false, num));
                        this.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays3[0].ToString()), num1, CreatedBy);
                        this.StockAllocationManagementHistory_Save(num8, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, Convert.ToInt64(strArrays3[0].ToString()));
                        this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "allocated");

                    }
                    empty = this.objLanguage.GetLanguageConversion("Stock_allocated_successfully");
                }
            }
        }
        return empty;
    }

    public void StockCancellation(long PriceCatalogueID, long PricecatalogueStockID, int TotalCancelQty, int AllocatedQty, int ReleasedQty, long CreatedBy, string DrawStockFrom)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Cancellation");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@TotalCancelQty", DbType.Int32, TotalCancelQty);
        database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void StockCancellationHistory_Save(long TransactionID, long PriceCatalogueID, long PricecatalogueStockID, int TotalCancelQty, int AllocatedQty, int ReleasedQty, string Notes, long CreatedBy, string ActionType)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockCancellationHistory_Save");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@TotalCancelQty", DbType.Int32, TotalCancelQty);
        database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockCancellationProcess(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom, long ModuleID, string ModuleName, long CreatedBy, string CancelType)
    {
        int num = 0;
        int num1 = 0;
        int num2 = 0;
        long num3 = (long)0;
        long num4 = (long)0;
        string empty = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Availables");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockCancelDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        database.AddInParameter(storedProcCommand, "@CancelType", DbType.String, CancelType);
        dataSet = database.ExecuteDataSet(storedProcCommand);
        if (dataSet.Tables.Count <= 0)
        {
            languageConversion = this.objLanguage.GetLanguageConversion("failure");
        }
        else
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                num = Convert.ToInt32(row["TotalCancelQty"].ToString());
                num1 = Convert.ToInt32(row["AllocatedQty"].ToString());
                num2 = Convert.ToInt32(row["ReleasedQty"].ToString());
                num3 = Convert.ToInt64(row["TransactionID"].ToString());
                num4 = Convert.ToInt64(row["PricecatalogueStockID"].ToString());
                PriceCatalogueID = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                empty = string.Concat(this.objLanguage.GetLanguageConversion("Stock_Cancelled_For_Job"), "#", ModuleID);
                this.StockCancelTransaction_Save(num3, PriceCatalogueID, ModuleID, ModuleName, 0, 0, "Cancelled", CreatedBy);
                this.StockCancellation(PriceCatalogueID, num4, num, num1, num2, CreatedBy, DrawStockFrom);
                this.StockCancellationHistory_Save(num3, PriceCatalogueID, num4, num, num1, num2, empty, CreatedBy, "Cancelled");
                this.UpdateKitProduct_StockLevels(PriceCatalogueID, num, "Cancelled");
            }
            languageConversion = this.objLanguage.GetLanguageConversion("success");
        }
        return languageConversion;
    }

    public void StockCancelTransaction_Save(long TransactionID, long PriceCatalogueID, long ModuleID, string ModuleName, int AllocatedQty, int ReleasedQty, string ActionType, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockCancelTransaction_Save");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockDirectAllocationReductionCheck(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        string empty = string.Empty;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        empty = (database.ExecuteDataSet(storedProcCommand).Tables.Count <= 0 ? "Allocate_And_Reduce" : "Reduce");
        return empty;
    }

    public long StockManagementTransaction_Save(long TransactionID, long CompanyID, long PriceCatalogueID, long KITTransactionID, long ModuleID, string ModuleName, string DrawStockFrom, long PricecatalogueStockID, int AllocatedQty, int ReleasedQty, string ActionType, decimal Price, long CreatedBy, bool IsbackOrder)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementTransaction_Save");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KITTransactionID", DbType.Int64, KITTransactionID);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        database.AddInParameter(storedProcCommand, "@DrawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.AddInParameter(storedProcCommand, "@IsbackOrder", DbType.Boolean, IsbackOrder);
        database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
        database.ExecuteNonQuery(storedProcCommand);
        object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
        return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
    }

    public long StockManagementTransaction_Save_Del(long TransactionID, long CompanyID, long PriceCatalogueID, long KITTransactionID, long ModuleID, string ModuleName, string DrawStockFrom, long PricecatalogueStockID, int AllocatedQty, int ReleasedQty, string ActionType, decimal Price, long CreatedBy, bool IsbackOrder, long DeliveryItemID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementTransaction_Save_Delivery");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KITTransactionID", DbType.Int64, KITTransactionID);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        database.AddInParameter(storedProcCommand, "@DrawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
        database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.AddInParameter(storedProcCommand, "@IsbackOrder", DbType.Boolean, IsbackOrder);
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
        database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
        database.ExecuteNonQuery(storedProcCommand);
        object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
        return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
    }

    public DataTable StockProductRerunDetails_Select(long PriceCatalogueID, long KitID, long CompanyID, string DrawStockFrom, long ModuleID)
    {
        DataTable dataTable = new DataTable();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementRerunDetails_select");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DrawStockFrom);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public void StockReduction(long PriceCatalogueID, long PricecatalogueStockID, int AllocatedQty, int ReleasedQty, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Reduction");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@ActualReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void StockReductionForAdditionalOption(long PriceCatalogueID, long PricecatalogueStockAdditionalId, int AllocatedQty, int ReleasedQty, long CreatedBy)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Reduction_AdditionalOption");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockAdditionalId", DbType.Int64, PricecatalogueStockAdditionalId);
        database.AddInParameter(storedProcCommand, "@ActualReleasedQty", DbType.Int32, ReleasedQty);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public DataTable StockReductionForDeliveryItem(long DeliveryItemID)
    {
        DataTable dataTable = new DataTable();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryItemStockReduction");
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public DataTable StockReductionForDeliveryItemNew(long DeliveryItemID)
    {
        DataTable dataTable = new DataTable();
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryItemStockReductionNew");
        database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public void StockReductionManagementHistory_Save(long TransactionID, long PriceCatalogueID, long PricecatalogueStockID, int ActualReleasedQty, string Notes, long CreatedBy, string ActionType)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockReductionManagementHistory_Save");
        database.AddInParameter(storedProcCommand, "@TransactionID", DbType.Int64, TransactionID);
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
        database.AddInParameter(storedProcCommand, "@ActualReleasedQty", DbType.Int32, ActualReleasedQty);
        database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
        database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
        database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public string StockReductionProcess(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom_Del, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        string[] strArrays = DrawStockFrom_Del.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        int quantity = Quantity;
        int num1 = 0;
        int num2 = 0;
        long num3 = (long)0;
        long num4 = (long)0;
        string empty = string.Empty;
        string empty1 = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0)
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
                database.AddInParameter(storedProcCommand1, "@KitID", DbType.Int64, KitID);
                database.AddInParameter(storedProcCommand1, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand1, "@DawStockFrom", DbType.String, str);
                database.AddInParameter(storedProcCommand1, "@ModuleID", DbType.Int64, ModuleID);
                database.AddInParameter(storedProcCommand1, "@ModuleName", DbType.String, ModuleName);
                database.AddInParameter(storedProcCommand1, "@DeliveryItemID", DbType.Int64, 0);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
        }
        if (dataSet.Tables.Count <= 0)
        {
            string str1 = this.Return_StockManagementSettings("SR_StockReductionMethod");
            string str2 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
            string empty2 = string.Empty;
            if (str.ToLower() == "self")
            {
                empty2 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str1, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("self¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
            else if (str.ToLower() == "other")
            {
                empty2 = this.StockAllocation_Others(CompanyID, KitID, Quantity, string.Concat(str1, "¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, (long)0, KitID, string.Concat("other¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
            else if (str.ToLower() == "multiple")
            {
                foreach (DataRow row in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, true).Rows)
                {
                    empty2 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str1, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                }
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("multiple¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
        }
        else
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count <= 0)
            {
                string str3 = this.Return_StockManagementSettings("SR_StockReductionMethod");
                string str4 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string empty3 = string.Empty;
                if (str.ToLower() == "self")
                {
                    empty3 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str3, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("self¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
                else if (str.ToLower() == "other")
                {
                    empty3 = this.StockAllocation_Others(CompanyID, KitID, Quantity, string.Concat(str3, "¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, (long)0, KitID, string.Concat("other¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
                else if (str.ToLower() == "multiple")
                {
                    foreach (DataRow dataRow in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, true).Rows)
                    {
                        empty3 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str3, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    }
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("multiple¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
            }
            else
            {
                foreach (DataRow row1 in item.Rows)
                {
                    DataSet dataSet1 = new DataSet();
                    DbCommand dbCommand1 = database.GetStoredProcCommand("PC_IsStockReducable_check");
                    database.AddInParameter(dbCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                    database.AddInParameter(dbCommand1, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row1["PricecatalogueStockID"].ToString()));
                    database.AddInParameter(dbCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row1["AllocatedQty"].ToString()));
                    dataSet1 = database.ExecuteDataSet(dbCommand1);
                    foreach (DataRow dataRow1 in dataSet1.Tables[0].Rows)
                    {
                        empty1 = string.Concat(empty1, dataRow1["IsStockReducable"].ToString(), ",");
                    }
                }
                if (empty1.Contains("false"))
                {
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available");
                }
                else if (empty1.Contains("true"))
                {
                    foreach (DataRow row2 in item.Rows)
                    {
                        if (KitID == (long)0 || !(str == "other"))
                        {
                            PriceCatalogueID = Convert.ToInt64(row2["PriceCatalogueID"].ToString());
                        }
                        else if (PriceCatalogueID != Convert.ToInt64(row2["PriceCatalogueID"].ToString()) && KitID == Convert.ToInt64(row2["KITTransactionID"].ToString()))
                        {
                            PriceCatalogueID = Convert.ToInt64(row2["PriceCatalogueID"].ToString());
                            quantity = Quantity;
                            int num5 = Convert.ToInt32(row2["Quantity"].ToString());
                            quantity = quantity * num5;
                        }
                        num2 = Convert.ToInt32(row2["AllocatedQty"].ToString());
                        num3 = Convert.ToInt64(row2["TransactionID"].ToString());
                        num4 = Convert.ToInt64(row2["PricecatalogueStockID"].ToString());
                        empty = string.Concat(this.objLanguage.GetLanguageConversion("Stock_released_for_Job"), " #", ModuleID);
                        if (num <= (long)0 || num2 <= 0)
                        {
                            if (quantity >= num2)
                            {
                                num1 = num2;
                                quantity = quantity - num2;
                                num2 = 0;
                            }
                            else if (quantity < num2)
                            {
                                num1 = quantity;
                                num2 = num2 - quantity;
                                quantity = 0;
                            }
                            if (num1 == 0)
                            {
                                continue;
                            }
                            num3 = this.StockManagementTransaction_Save(num3, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, num4, num2, num1, "ALC-REL", Price, CreatedBy, false);
                            this.StockReduction(PriceCatalogueID, num4, num2, num1, CreatedBy);
                            this.StockReductionManagementHistory_Save(num3, PriceCatalogueID, num4, num1, empty, CreatedBy, "Released");
                            this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "Released");
                        }
                        else
                        {
                            if (quantity >= num2)
                            {
                                num1 = num2;
                                quantity = quantity - num2;
                                num2 = 0;
                            }
                            else if (quantity < num2)
                            {
                                num1 = quantity;
                                num2 = num2 - quantity;
                                quantity = 0;
                            }
                            if (num1 == 0)
                            {
                                continue;
                            }
                            num3 = this.StockManagementTransaction_Save(num3, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, num4, num2, num1, "ALC-REL", Price, CreatedBy, false);
                            this.DeliveryItemID_Reduction_Save(num3, num);
                            this.StockReduction(PriceCatalogueID, num4, num2, num1, CreatedBy);
                            this.StockReductionManagementHistory_Save(num3, PriceCatalogueID, num4, num1, empty, CreatedBy, "Released");
                            this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "Released");
                            if (quantity != 0)
                            {
                                continue;
                            }
                            break;
                        }
                    }
                    if (KitID != (long)0 && str == "other")
                    {
                        DataSet dataSet2 = new DataSet();
                        if (num <= (long)0)
                        {
                            DbCommand storedProcCommand2 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
                            database.AddInParameter(storedProcCommand2, "@PriceCatalogueID", DbType.Int64, KitID);
                            database.AddInParameter(storedProcCommand2, "@KitID", DbType.Int64, KitID);
                            database.AddInParameter(storedProcCommand2, "@CompanyID", DbType.Int64, CompanyID);
                            database.AddInParameter(storedProcCommand2, "@DawStockFrom", DbType.String, "Self");
                            database.AddInParameter(storedProcCommand2, "@ModuleID", DbType.Int64, ModuleID);
                            database.AddInParameter(storedProcCommand2, "@ModuleName", DbType.String, ModuleName);
                            dataSet2 = database.ExecuteDataSet(storedProcCommand2);
                        }
                        else
                        {
                            DbCommand dbCommand2 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                            database.AddInParameter(dbCommand2, "@PriceCatalogueID", DbType.Int64, KitID);
                            database.AddInParameter(dbCommand2, "@KitID", DbType.Int64, KitID);
                            database.AddInParameter(dbCommand2, "@CompanyID", DbType.Int64, CompanyID);
                            database.AddInParameter(dbCommand2, "@DawStockFrom", DbType.String, "Self");
                            database.AddInParameter(dbCommand2, "@ModuleID", DbType.Int64, ModuleID);
                            database.AddInParameter(dbCommand2, "@ModuleName", DbType.String, ModuleName);
                            database.AddInParameter(dbCommand2, "@DeliveryItemID", DbType.Int64, num);
                            dataSet2 = database.ExecuteDataSet(dbCommand2);
                            if (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count == 0)
                            {
                                DbCommand storedProcCommand3 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                                database.AddInParameter(storedProcCommand3, "@PriceCatalogueID", DbType.Int64, KitID);
                                database.AddInParameter(storedProcCommand3, "@KitID", DbType.Int64, KitID);
                                database.AddInParameter(storedProcCommand3, "@CompanyID", DbType.Int64, CompanyID);
                                database.AddInParameter(storedProcCommand3, "@DawStockFrom", DbType.String, "Self");
                                database.AddInParameter(storedProcCommand3, "@ModuleID", DbType.Int64, ModuleID);
                                database.AddInParameter(storedProcCommand3, "@ModuleName", DbType.String, ModuleName);
                                database.AddInParameter(storedProcCommand3, "@DeliveryItemID", DbType.Int64, 0);
                                dataSet2 = database.ExecuteDataSet(storedProcCommand3);
                            }
                        }
                        if (dataSet2.Tables.Count > 0)
                        {
                            foreach (DataRow dataRow2 in dataSet2.Tables[0].Rows)
                            {
                                num3 = Convert.ToInt64(dataRow2["TransactionID"].ToString());
                                num3 = this.StockManagementTransaction_Save(num3, CompanyID, KitID, KitID, ModuleID, ModuleName, str, (long)0, 0, Quantity, "ALC-REL", Price, CreatedBy, false);
                                this.KitStockAllocationOrReduction(KitID, Quantity, 'r', CreatedBy);
                                this.StockReductionManagementHistory_Save(num3, KitID, (long)0, Quantity, empty, CreatedBy, "Released");
                            }
                        }
                    }
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
                }
            }
        }
        return languageConversion;
    }

    public string StockReductionProcess_Delivery(long CompanyID, long PriceCatalogueID, long KitID, string DrawStockFrom_Del, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        string[] strArrays = DrawStockFrom_Del.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        int quantity = Quantity;
        int num1 = 0;
        int num2 = 0;
        long num3 = (long)0;
        long num4 = (long)0;
        string empty = string.Empty;
        string empty1 = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0)
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
                database.AddInParameter(storedProcCommand1, "@KitID", DbType.Int64, KitID);
                database.AddInParameter(storedProcCommand1, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand1, "@DawStockFrom", DbType.String, str);
                database.AddInParameter(storedProcCommand1, "@ModuleID", DbType.Int64, ModuleID);
                database.AddInParameter(storedProcCommand1, "@ModuleName", DbType.String, ModuleName);
                database.AddInParameter(storedProcCommand1, "@DeliveryItemID", DbType.Int64, 0);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
        }
        if (dataSet.Tables.Count <= 0)
        {
            string str1 = this.Return_StockManagementSettings("SR_StockReductionMethod");
            string str2 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
            string empty2 = string.Empty;
            if (str.ToLower() == "self")
            {
                empty2 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str1, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("self¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
            else if (str.ToLower() == "other")
            {
                empty2 = this.StockAllocation_Others(CompanyID, KitID, Quantity, string.Concat(str1, "¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, (long)0, KitID, string.Concat("other¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
            else if (str.ToLower() == "multiple")
            {
                foreach (DataRow row in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, true).Rows)
                {
                    empty2 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str1, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                }
                if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("multiple¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
        }
        else
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count <= 0)
            {
                string str3 = this.Return_StockManagementSettings("SR_StockReductionMethod");
                string str4 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string empty3 = string.Empty;
                if (str.ToLower() == "self")
                {
                    empty3 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str3, string.Concat("self¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("self¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
                else if (str.ToLower() == "other")
                {
                    empty3 = this.StockAllocation_Others(CompanyID, KitID, Quantity, string.Concat(str3, "¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, (long)0, KitID, string.Concat("other¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
                else if (str.ToLower() == "multiple")
                {
                    foreach (DataRow dataRow in PurchaseBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, true).Rows)
                    {
                        empty3 = this.StockAllocationProcess(CompanyID, PriceCatalogueID, (long)0, Quantity, str3, string.Concat("multiple¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                    }
                    if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcess(CompanyID, PriceCatalogueID, (long)0, string.Concat("multiple¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
            }
            else
            {
                foreach (DataRow row1 in item.Rows)
                {
                    DataSet dataSet1 = new DataSet();
                    DbCommand dbCommand1 = database.GetStoredProcCommand("PC_IsStockReducable_check");
                    database.AddInParameter(dbCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                    database.AddInParameter(dbCommand1, "@PricecatalogueStockID", DbType.Int64, Convert.ToInt64(row1["PricecatalogueStockID"].ToString()));
                    database.AddInParameter(dbCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row1["AllocatedQty"].ToString()));
                    dataSet1 = database.ExecuteDataSet(dbCommand1);
                    foreach (DataRow dataRow1 in dataSet1.Tables[0].Rows)
                    {
                        empty1 = string.Concat(empty1, dataRow1["IsStockReducable"].ToString(), ",");
                    }
                }
                if (empty1.Contains("false"))
                {
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available");
                }
                else if (empty1.Contains("true"))
                {
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        if (KitID == (long)0 || !(str == "other"))
                        {
                            PriceCatalogueID = Convert.ToInt64(row2["PriceCatalogueID"].ToString());
                            num2 = Convert.ToInt32(row2["AllocatedQty"].ToString());
                            num3 = Convert.ToInt64(row2["TransactionID"].ToString());
                            num4 = Convert.ToInt64(row2["PricecatalogueStockID"].ToString());
                            empty = string.Concat(this.objLanguage.GetLanguageConversion("Stock_released_for_Job"), " #", ModuleID);
                        }
                        else if (PriceCatalogueID == Convert.ToInt64(row2["PriceCatalogueID"].ToString()) && KitID == Convert.ToInt64(row2["KITTransactionID"].ToString()))
                        {
                            PriceCatalogueID = Convert.ToInt64(row2["PriceCatalogueID"].ToString());
                            quantity = Quantity;
                            int num5 = Convert.ToInt32(row2["Quantity"].ToString());
                            quantity = quantity * num5;
                            num2 = Convert.ToInt32(row2["AllocatedQty"].ToString());
                            num3 = Convert.ToInt64(row2["TransactionID"].ToString());
                            num4 = Convert.ToInt64(row2["PricecatalogueStockID"].ToString());
                            empty = string.Concat(this.objLanguage.GetLanguageConversion("Stock_released_for_Job"), " #", ModuleID);
                        }
                        if (num <= (long)0 || num2 <= 0)
                        {
                            if (quantity >= num2)
                            {
                                num1 = num2;
                                quantity = quantity - num2;
                                num2 = 0;
                            }
                            else if (quantity < num2)
                            {
                                num1 = quantity;
                                num2 = num2 - quantity;
                                quantity = 0;
                            }
                            if (num1 == 0)
                            {
                                continue;
                            }
                            num3 = this.StockManagementTransaction_Save(num3, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, num4, num2, num1, "ALC-REL", Price, CreatedBy, false);
                            this.StockReduction(PriceCatalogueID, num4, num2, num1, CreatedBy);
                            this.StockReductionManagementHistory_Save(num3, PriceCatalogueID, num4, num1, empty, CreatedBy, "Released");
                            this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "Released");
                        }
                        else
                        {
                            if (quantity >= num2)
                            {
                                num1 = num2;
                                quantity = quantity - num2;
                                num2 = 0;
                            }
                            else if (quantity < num2)
                            {
                                num1 = quantity;
                                num2 = num2 - quantity;
                                quantity = 0;
                            }
                            if (num1 == 0)
                            {
                                continue;
                            }
                            num3 = this.StockManagementTransaction_Save(num3, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, str, num4, num2, num1, "ALC-REL", Price, CreatedBy, false);
                            this.DeliveryItemID_Reduction_Save(num3, num);
                            this.StockReduction(PriceCatalogueID, num4, num2, num1, CreatedBy);
                            this.StockReductionManagementHistory_Save(num3, PriceCatalogueID, num4, num1, empty, CreatedBy, "Released");
                            this.UpdateKitProduct_StockLevels(PriceCatalogueID, num1, "Released");
                            if (quantity != 0)
                            {
                                continue;
                            }
                            break;
                        }
                    }
                    if (KitID != (long)0 && str == "other")
                    {
                        DataSet dataSet2 = new DataSet();
                        if (num <= (long)0)
                        {
                            DbCommand storedProcCommand2 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
                            database.AddInParameter(storedProcCommand2, "@PriceCatalogueID", DbType.Int64, KitID);
                            database.AddInParameter(storedProcCommand2, "@KitID", DbType.Int64, KitID);
                            database.AddInParameter(storedProcCommand2, "@CompanyID", DbType.Int64, CompanyID);
                            database.AddInParameter(storedProcCommand2, "@DawStockFrom", DbType.String, "Self");
                            database.AddInParameter(storedProcCommand2, "@ModuleID", DbType.Int64, ModuleID);
                            database.AddInParameter(storedProcCommand2, "@ModuleName", DbType.String, ModuleName);
                            dataSet2 = database.ExecuteDataSet(storedProcCommand2);
                        }
                        else
                        {
                            DbCommand dbCommand2 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                            database.AddInParameter(dbCommand2, "@PriceCatalogueID", DbType.Int64, KitID);
                            database.AddInParameter(dbCommand2, "@KitID", DbType.Int64, KitID);
                            database.AddInParameter(dbCommand2, "@CompanyID", DbType.Int64, CompanyID);
                            database.AddInParameter(dbCommand2, "@DawStockFrom", DbType.String, "Self");
                            database.AddInParameter(dbCommand2, "@ModuleID", DbType.Int64, ModuleID);
                            database.AddInParameter(dbCommand2, "@ModuleName", DbType.String, ModuleName);
                            database.AddInParameter(dbCommand2, "@DeliveryItemID", DbType.Int64, num);
                            dataSet2 = database.ExecuteDataSet(dbCommand2);
                            if (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count == 0)
                            {
                                DbCommand storedProcCommand3 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                                database.AddInParameter(storedProcCommand3, "@PriceCatalogueID", DbType.Int64, KitID);
                                database.AddInParameter(storedProcCommand3, "@KitID", DbType.Int64, KitID);
                                database.AddInParameter(storedProcCommand3, "@CompanyID", DbType.Int64, CompanyID);
                                database.AddInParameter(storedProcCommand3, "@DawStockFrom", DbType.String, "Self");
                                database.AddInParameter(storedProcCommand3, "@ModuleID", DbType.Int64, ModuleID);
                                database.AddInParameter(storedProcCommand3, "@ModuleName", DbType.String, ModuleName);
                                database.AddInParameter(storedProcCommand3, "@DeliveryItemID", DbType.Int64, 0);
                                dataSet2 = database.ExecuteDataSet(storedProcCommand3);
                            }
                        }
                        if (dataSet2.Tables.Count > 0)
                        {
                            foreach (DataRow dataRow2 in dataSet2.Tables[0].Rows)
                            {
                                num3 = Convert.ToInt64(dataRow2["TransactionID"].ToString());
                                num3 = this.StockManagementTransaction_Save(num3, CompanyID, KitID, KitID, ModuleID, ModuleName, str, (long)0, 0, Quantity, "ALC-REL", Price, CreatedBy, false);
                                this.KitStockAllocationOrReduction(KitID, Quantity, 'r', CreatedBy);
                                this.StockReductionManagementHistory_Save(num3, KitID, (long)0, Quantity, empty, CreatedBy, "Released");
                            }
                        }
                    }
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
                }
            }
        }
        return languageConversion;
    }

    public string StockReductionProcessForAdditionalOption(long CompanyID, long PriceCatalogueID, string DrawStockFrom_Del, int Quantity, long ModuleID, string ModuleName, long CreatedBy, decimal Price)
    {
        string[] strArrays = DrawStockFrom_Del.Split(new char[] { '\u00B6' });
        string str = strArrays[0].ToString();
        long num = (long)0;
        if ((int)strArrays.Length > 1 && strArrays[1].ToString().Trim() != "")
        {
            num = Convert.ToInt64(strArrays[1]);
        }
        int quantity = Quantity;
        int num1 = 0;
        int num2 = 0;
        long num3 = (long)0;
        long num4 = (long)0;
        string empty = string.Empty;
        string empty1 = string.Empty;
        string languageConversion = string.Empty;
        languageConversion = this.objLanguage.GetLanguageConversion("No_Stock_Available");
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        if (num <= (long)0)
        {
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, 0);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
        }
        else
        {
            DbCommand dbCommand = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(dbCommand, "@KitID", DbType.Int64, 0);
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(dbCommand, "@DawStockFrom", DbType.String, str);
            database.AddInParameter(dbCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(dbCommand, "@DeliveryItemID", DbType.Int64, num);
            dataSet = database.ExecuteDataSet(dbCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0)
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("PC_StockAllocatedDetails_Select_Delivery");
                database.AddInParameter(storedProcCommand1, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
                database.AddInParameter(storedProcCommand1, "@KitID", DbType.Int64, 0);
                database.AddInParameter(storedProcCommand1, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand1, "@DawStockFrom", DbType.String, str);
                database.AddInParameter(storedProcCommand1, "@ModuleID", DbType.Int64, ModuleID);
                database.AddInParameter(storedProcCommand1, "@ModuleName", DbType.String, ModuleName);
                database.AddInParameter(storedProcCommand1, "@DeliveryItemID", DbType.Int64, 0);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
        }
        if (dataSet.Tables.Count > 0)
        {
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count > 0)
            {
                foreach (DataRow row in item.Rows)
                {
                    DataSet dataSet1 = new DataSet();
                    DbCommand dbCommand1 = database.GetStoredProcCommand("PC_IsAdditionalOptionStockReducable_check");
                    database.AddInParameter(dbCommand1, "@PriceCatalogueID", DbType.Int64, Convert.ToInt64(row["PriceCatalogueID"].ToString()));
                    database.AddInParameter(dbCommand1, "@PricecatalogueStockAdditionalId", DbType.Int64, Convert.ToInt64(row["PricecatalogueStockID"].ToString()));
                    database.AddInParameter(dbCommand1, "@AllocatedQty", DbType.Int32, Convert.ToInt32(row["AllocatedQty"].ToString()));
                    dataSet1 = database.ExecuteDataSet(dbCommand1);
                    foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                    {
                        empty1 = string.Concat(empty1, dataRow["IsStockReducable"].ToString(), ",");
                    }
                }
                if (!empty1.Contains("false"))
                {
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num2 = Convert.ToInt32(row1["AllocatedQty"].ToString());
                        num3 = Convert.ToInt64(row1["TransactionID"].ToString());
                        num4 = Convert.ToInt64(row1["PricecatalogueStockID"].ToString());
                        PriceCatalogueID = Convert.ToInt64(row1["PriceCatalogueID"].ToString());
                        if (quantity >= num2)
                        {
                            num1 = num2;
                            quantity = quantity - num2;
                            num2 = 0;
                        }
                        else if (quantity < num2)
                        {
                            num1 = quantity;
                            num2 = num2 - quantity;
                            quantity = 0;
                        }
                        empty = string.Concat(this.objLanguage.GetLanguageConversion("Additional_Option_Stock_released_for_Job"), " #", ModuleID);
                        num3 = this.StockManagementTransaction_Save(num3, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, str, num4, num2, num1, "ALC-REL", Price, CreatedBy, false);
                        this.StockReductionForAdditionalOption(PriceCatalogueID, num4, num2, num1, CreatedBy);
                        this.StockReductionManagementHistory_Save(num3, PriceCatalogueID, num4, num1, empty, CreatedBy, "Released");
                    }
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_successfull");
                }
                else
                {
                    languageConversion = this.objLanguage.GetLanguageConversion("Stock_reduction_failed_as_no_stock_available");
                }
            }
            else if (this.Session["StockItemType"] != null)
            {
                string str1 = this.Return_StockManagementSettings("SR_StockReductionMethod");
                string str2 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string empty2 = string.Empty;
                if (str.ToLower() == "additional option")
                {
                    if (this.Session["StockItemType"].ToString() != "X")
                    {
                        empty2 = this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, Quantity, str1, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy);
                    }
                    else if (this.Session["ALC_OrderItemId"] != null)
                    {
                        empty2 = this.StockAllocationForAdditionalOptionEstore(CompanyID, PriceCatalogueID, Quantity, str1, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str2), ModuleID, "Job", Price, CreatedBy, (long)0, Convert.ToInt64(this.Session["ALC_OrderItemId"].ToString()));
                    }
                    if (empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty2.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                    {
                        languageConversion = this.StockReductionProcessForAdditionalOption(CompanyID, PriceCatalogueID, string.Concat("additional option¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                    }
                }
            }
        }
        else if (this.Session["StockItemType"] != null)
        {
            string str3 = this.Return_StockManagementSettings("SR_StockReductionMethod");
            string str4 = this.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
            string empty3 = string.Empty;
            if (str.ToLower() == "additional option")
            {
                if (this.Session["StockItemType"].ToString() != "X")
                {
                    empty3 = this.StockAllocationForAdditionalOption(CompanyID, PriceCatalogueID, Quantity, str3, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy);
                }
                else if (this.Session["ALC_OrderItemId"] != null)
                {
                    empty3 = this.StockAllocationForAdditionalOptionEstore(CompanyID, PriceCatalogueID, Quantity, str3, string.Concat("additional option¶", num.ToString()), Convert.ToBoolean(str4), ModuleID, "Job", Price, CreatedBy, (long)0, Convert.ToInt64(this.Session["ALC_OrderItemId"].ToString()));
                    this.Session["StockItemType"] = "";
                    this.Session["ALC_OrderItemId"] = "";
                }
                if (empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_successfully")) || empty3.Contains(this.objLanguage.GetLanguageConversion("Stock_allocated_with_back_order_successfully")))
                {
                    languageConversion = this.StockReductionProcessForAdditionalOption(CompanyID, PriceCatalogueID, string.Concat("additional option¶", num.ToString()), Quantity, ModuleID, "Job", CreatedBy, Price);
                }
            }
        }
        return languageConversion;
    }

    public string TakeErrorForColor()
    {
        return "333333";
    }

    public Color TakeErrorForColors()
    {
        return Color.FromArgb(333333);
    }

    public string ToTitleCase(string mText, string diplay)
    {
        string empty = string.Empty;
        if (diplay == "p")
        {
            empty = this.CapitalizeWords(mText);
        }
        else if (diplay == "u")
        {
            empty = mText.ToUpper();
        }
        else if (diplay == "l")
        {
            empty = mText.ToLower();
        }
        return empty;
    }

    public void UpdateKingsQtySent(long PriceCatalogueID, int QtySendToKings)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateKingsQtySent");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
        database.AddInParameter(storedProcCommand, "@QtySendToKings", DbType.Int32, QtySendToKings);
        database.ExecuteNonQuery(storedProcCommand);
    }

    public void UpdateKitProduct_StockLevels(long PricecatalogueID, int Quantity, string Type)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateKitProduct_Stocklevels");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PricecatalogueID);
        database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
        database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
        database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, Convert.ToInt64(this.Session["UserID"]));
        database.ExecuteNonQuery(storedProcCommand);
    }

    public virtual DataTable UserAccessRights_OnConditionally(long CompanyID, long UserID)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UserAccessRights_OnConditionally");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
        database.AddInParameter(storedProcCommand, "@userID", DbType.Int32, UserID);
        using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
        {
            dataTable.Load(dataReader);
        }
        return dataTable;
    }

    public bool ValidatePageURL(int CompanyID, string ModuleType, long ModuleID, long EstimateItemID, string EstimateType, string PageMode)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataTable dataTable = new DataTable();
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_check_pageurl");
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
        database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
        database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
        database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
        database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
        database.ExecuteNonQuery(storedProcCommand);
        object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
        if ((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())) != -1)
        {
            return true;
        }
        return false;
    }

    public static List<string> Wrap(string text, int maxLength)
    {
        if (text.Length == 0)
        {
            return new List<string>();
        }
        string[] strArrays = text.Split(new char[] { ' ' });
        List<string> strs = new List<string>();
        string str = "";
        string[] strArrays1 = strArrays;
        for (int i = 0; i < (int)strArrays1.Length; i++)
        {
            string str1 = strArrays1[i];
            if (str.Length > maxLength || str.Length + str1.Length > maxLength)
            {
                strs.Add(str);
                str = "";
            }
            str = (str.Length <= 0 ? string.Concat(str, str1) : string.Concat(str, " ", str1));
        }
        if (str.Length > 0)
        {
            strs.Add(str);
        }
        return strs;
    }

    public static string WrapString(string text, int maxLength)
    {
        string str = "";
        foreach (string str1 in BaseClass.Wrap(text, maxLength))
        {
            str = string.Concat(str, str1, "<br/>");
        }
        return str;
    }

    public static string CheckStringNull(object obj)

    {

        try

        {


            if (obj == null)

            {

                return string.Empty;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return string.Empty;

                }

                else

                {

                    return obj.ToString();

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckStringNull", ex);

        }

    }


    public static int CheckIntegerNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if ((obj == DBNull.Value) || (obj is string && string.IsNullOrEmpty((string)obj)))

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToInt32(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckIntegerNull", ex);

        }

    }

    public static Int64 CheckInteger64Null(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if ((obj == DBNull.Value) || (obj is string && string.IsNullOrEmpty((string)obj)))

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToInt64(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckIntegerNull", ex);

        }

    }

    public static Int16 CheckInteger16Null(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if ((obj == DBNull.Value) || (obj is string && string.IsNullOrEmpty((string)obj)))

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToInt16(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckIntegerNull", ex);

        }

    }

    public static byte CheckByteNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if ((obj == DBNull.Value) || (obj is string && string.IsNullOrEmpty((string)obj)))

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToByte(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckIntegerNull", ex);

        }

    }

    public static long CheckLongNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToInt64(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckLongNull", ex);

        }

    }


    public static double CheckDoubleNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return 0;

                }
                else if (obj == "")
                {
                    return 0;
                }
                else

                {

                    return System.Convert.ToDouble(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckDoubleNull", ex);

        }

    }


    public static bool CheckBooleanNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return false;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return false;

                }

                else

                {

                    return System.Convert.ToBoolean(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckDoubleNull", ex);

        }

    }


    public static short CheckShortNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return 0;

                }

                else

                {

                    return ((short)(obj));

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckIntegerNull", ex);

        }

    }

    public static DateTime CheckDateTimeNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return System.DateTime.Now;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return System.DateTime.Now;

                }

                else

                {

                    return (Convert.ToDateTime(obj));

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckDateTimeNull", ex);

        }

    }


    public static Decimal CheckDecimalNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return 0;

                }

                else

                {

                    return System.Convert.ToDecimal(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckDecimalNull", ex);

        }

    }

    public static float CheckfloatNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return 0;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return 0;

                }

                else

                {

                    return float.Parse(obj.ToString());

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckfloatNull", ex);

        }

    }

    public static byte[] CheckImageNull(object obj)

    {

        try

        {

            if (obj == null)

            {

                return null;

            }

            else

            {

                if (obj == DBNull.Value)

                {

                    return null;

                }

                else

                {

                    return (System.Byte[])(obj);

                }

            }

        }

        catch (Exception ex)

        {

            throw new Exception("CheckfloatNull", ex);

        }

    }


    public string SimpleStockReduction(long PricecatalogueID, long Quantity)
    {
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SimpleStock_Reduction");
        database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PricecatalogueID);
        database.AddInParameter(storedProcCommand, "@TotalQuantity", DbType.Int64, Quantity);
        database.ExecuteNonQuery(storedProcCommand);
        return "Stock Reduced";
    }
}