using Eprint.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DMCOrdersImportProcess
{
    public class Program
    {
        public static string strConnectionString;

        public static string CompanyID;

        public static string ClientID;

        public static string AccountID;

        public static string Prod_Id;

        protected static Random rGen;

        protected static string[] strCharacters;

        protected static string strDBName = "";

        static Program()
        {
            //Program.strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //Program.CompanyID = ConfigurationManager.AppSettings["CompanyID"].ToString();
            Program.strConnectionString = "";
            Program.CompanyID = "0";
            Program.ClientID = "0";
            Program.AccountID = "0";
            Program.Prod_Id = string.Empty;
            Program.strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        }

        public Program(string serverName, string userId, string password, string connectionString)
        {
            Main_Method(serverName, userId, password, connectionString);
        }

        public static int address_insert(int CompanyID, int UserID, int ClientID, string Address, string City, string State, string Country, string Telephone, string Fax, string ZipCode, string Ref, string Email, bool IsDefaultEmail, bool IsDefaultDeliveryAddress, bool IsDefaultBillingAddress, string CreatedDate, bool IsDefaultPostBoxAddress, string AddressLabel, string AddressLine2, string URL, string isHideAddress)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, ZipCode);
            database.AddInParameter(storedProcCommand, "@Ref", DbType.String, Ref);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@IsDefaultEmail", DbType.Boolean, IsDefaultEmail);
            database.AddInParameter(storedProcCommand, "@IsDefaultDeliveryAddress", DbType.Boolean, IsDefaultDeliveryAddress);
            database.AddInParameter(storedProcCommand, "@IsDefaultBillingAddress", DbType.Boolean, IsDefaultBillingAddress);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.Date, CreatedDate);
            database.AddInParameter(storedProcCommand, "@IsDefaultPostBoxAddress", DbType.Boolean, IsDefaultPostBoxAddress);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, URL);
            database.AddInParameter(storedProcCommand, "@isHideAddress", DbType.String, isHideAddress);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public static void btn_confirm_OnClick()
        {
            DataTable dataTable;
            Guid guid;
            DateTime now;
            object[] str;
            string str1 = "0";
            DataSet dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("SELECT  DISTINCT a.AccountID,a.OrderImportID,[Order],c.ClientID,d.ClientName,a.UserID,b.Date as EstDate from tb_OrderImport a \r\n            INNER JOIN tb_OrderImportItems b ON a.OrderImportID=b.OrderImportID\r\n            INNER JOIN tb_Accounts c ON a.AccountID=c.accountID\r\n             INNER JOIN tb_Client d ON d.ClientID=c.ClientID\r\n             WHERE isnull(a.IsImported,0)=1 AND isnull(b.isItemProcessCompleted,0)=0  and a.CompanyID=", Program.CompanyID));
            //DataSet dataSet = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("SELECT a.AccountID,a.OrderImportID,[Order],c.ClientID,d.ClientName,a.UserID from tb_OrderImport a \r\n            INNER JOIN tb_OrderImportItems b ON a.OrderImportID=b.OrderImportID\r\n            INNER JOIN tb_Accounts c ON a.AccountID=c.accountID\r\n             INNER JOIN tb_Client d ON d.ClientID=c.ClientID\r\n             WHERE isnull(a.IsImported,0)=1 AND isnull(b.isItemProcessCompleted,0)=0  and a.CompanyID=", Program.CompanyID));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                bool flag = true;
                string empty = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                Program.AccountID = row["AccountID"].DBNullToString();
                Program.ClientID = row["ClientID"].DBNullToString();
                int num = row["UserID"].DBNullToInt32();
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                long num4 = (long)0;
                int num5 = 0;
                string str2 = "";
                string str3 = Program.strConnectionString;
                if (Eprint.DataAccessLayer.SQL.ExecuteDataset(str3, CommandType.Text, string.Concat(new object[] { "SELECT [Order] from tb_OrderImport a \r\n            INNER JOIN tb_OrderImportItems b ON a.OrderImportID=b.OrderImportID\r\n             WHERE dbo.MyHTMLENcode(isnull(b.[Order],''))='", Program.SpecialEncode(row["Order"].ToString()), "' AND isnull(b.OrderImportID,0)!=", row["OrderImportID"], " and AccountID=", row["AccountID"], "  and a.CompanyID=", Program.CompanyID })).Tables[0].Rows.Count > 0)
                {
                    stringBuilder.Append(string.Concat("Order # ", Program.SpecialEncode(row["Order"].ToString()), " already processed in the past hence skipped."));
                    flag = false;
                }
                if (!flag)
                {
                    string str4 = Program.strConnectionString;
                    str = new object[] { "update tb_OrderImportItems set isItemProcessCompleted=4,ErrorMessage='", stringBuilder.ToString(), "' where dbo.MyHTMLENcode(isnull([Order],''))='", Program.SpecialEncode(row["Order"].ToString()), "' AND isnull(OrderImportID,0)=", row["OrderImportID"] };
                    Eprint.DataAccessLayer.SQL.ExecuteDataset(str4, CommandType.Text, string.Concat(str));
                }
                else
                {
                    string str5 = Program.strConnectionString;
                    str = new object[] { "SELECT * from tb_OrderImport a \r\n            INNER JOIN tb_OrderImportItems b ON a.OrderImportID=b.OrderImportID\r\n             WHERE dbo.MyHTMLENcode(isnull(b.[Order],''))='", Program.SpecialEncode(row["Order"].ToString()), "' AND isnull(b.OrderImportID,0)=", row["OrderImportID"].DBNullToInt32(), " and AccountID=", row["AccountID"].DBNullToString(), "  and CompanyID=", Program.CompanyID };
                    DataSet dataSet1 = Eprint.DataAccessLayer.SQL.ExecuteDataset(str5, CommandType.Text, string.Concat(str));
                    foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                    {
                        str2 = string.Concat(dataRow["Delivery Method"].DBNullToString(), " ", dataRow["Delivery Notes"].DBNullToString(), " ", dataRow["Customer Comments"].DBNullToString(), " ", dataRow["internal Comments"].DBNullToString());
                        string str6 = Program.strConnectionString;
                        string[] strArrays = new string[] { " SELECT a.contactId,a.DepartmentID,b.ClientID,b.ClientName,isnull((SELECT DeliveryAddressID FROM tb_Department td WHERE td.DeptID=a.DepartmentID),0) as DeliveryAddressID FROM tb_Contact a inner join tb_Client b on a.ClientID=b.ClientID  WHERE a.Email='", Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), "'  AND a.ClientID=", Program.ClientID, " and a.IsDelete=0    and a.CompanyID=", Program.CompanyID };
                        DataSet dataSet2 = Eprint.DataAccessLayer.SQL.ExecuteDataset(str6, CommandType.Text, string.Concat(strArrays));
                        if (dataSet2.Tables[0].Rows.Count <= 0)
                        {
                            DataSet dataSet3 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat(" SELECT DeptID,DeliveryAddressID FROM tb_Department td WHERE isnull(td.IsDefault,0)=1 AND td.CustomerID=", Program.ClientID, " and isnull(td.IsDeleted,0)=0 "));
                            //int num5 = 0;
                            if (dataSet3.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row1 in dataSet3.Tables[0].Rows)
                                {
                                    num4 = row1["DeptID"].DBNullToint64();
                                    num5 = row1["DeliveryAddressID"].DBNullToInt32();
                                }
                            }
                            //if (Program.strDBName == "eprint_demo")
                            if (Program.strDBName == "eprint_birchprint")
                            {
                                num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), 0, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", Program.SpecialEncode(dataRow["ACC Number"].DBNullToString()), Program.SpecialEncode(dataRow["Customer Type"].DBNullToString()), "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            else
                            {
                                num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), 0, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }

                            long num6 = (long)0;
                            string str7 = Program.SpecialEncode(dataRow["First Name"].DBNullToString());
                            string str8 = Program.SpecialEncode(dataRow["Last Name"].DBNullToString());
                            string str9 = Program.SpecialEncode(dataRow["Email Address"].DBNullToString());
                            guid = Guid.NewGuid();
                            str1 = Convert.ToString(Program.Create_StoreUser(num6, str7, str8, str9, guid.ToString().Substring(0, 10), Convert.ToInt64(Program.CompanyID), Convert.ToInt64(Program.AccountID), "", row["clientName"].ToString(), 0));
                            string str10 = Program.strConnectionString;
                            str = new object[] { " update Ws_StoreUser set ContactID=", num1, " where StoreUserID=", str1 };
                            Eprint.DataAccessLayer.SQL.ExecuteNonQuery(str10, CommandType.Text, string.Concat(str));
                        }
                        else
                        {
                            // birchprint order import
                            //if (Program.strDBName == "eprint_demo")
                            if (Program.strDBName == "eprint_birchprint")
                            {
                                if(!string.IsNullOrEmpty(Program.SpecialEncode(dataRow["Email Address"].DBNullToString())))
                                {
                                    DataTable _dt = Program.GetContactIDAndCountByEmail(Convert.ToInt32(Program.ClientID), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()));
                                    int contact_id = 0;
                                    int contact_count = 0;
                                    foreach (DataRow dr in _dt.Rows)
                                    {
                                        contact_id = int.Parse(dr["contact_id"].ToString());
                                        contact_count = int.Parse(dr["contact_count"].ToString());
                                    }
                                    if (contact_count == 0)
                                    {
                                        num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), 0, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", Program.SpecialEncode(dataRow["ACC Number"].DBNullToString()), Program.SpecialEncode(dataRow["Customer Type"].DBNullToString()), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    else
                                    {
                                        num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), contact_id, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", Program.SpecialEncode(dataRow["ACC Number"].DBNullToString()), Program.SpecialEncode(dataRow["Customer Type"].DBNullToString()), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                }
                                else
                                {
                                    num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), 0, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", Program.SpecialEncode(dataRow["ACC Number"].DBNullToString()), Program.SpecialEncode(dataRow["Customer Type"].DBNullToString()), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                }
                            }
                            string[] strnewArrays = new string[] { " SELECT a.contactId,a.DepartmentID,b.ClientID,b.ClientName,isnull((SELECT DeliveryAddressID FROM tb_Department td WHERE td.DeptID=a.DepartmentID),0) as DeliveryAddressID FROM tb_Contact a inner join tb_Client b on a.ClientID=b.ClientID  WHERE a.Email='", Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), "'  AND a.ClientID=", Program.ClientID, " and a.IsDelete=0    and a.CompanyID=", Program.CompanyID };
                            dataSet2.Clear();
                            dataSet2 = Eprint.DataAccessLayer.SQL.ExecuteDataset(str6, CommandType.Text, string.Concat(strnewArrays));

                            foreach (DataRow dataRow1 in dataSet2.Tables[0].Rows)
                            {
                                num1 = dataRow1["contactId"].DBNullToInt32();
                                num4 = (long)dataRow1["DepartmentID"].DBNullToInt32();
                                string str11 = Program.strConnectionString;
                                str = new object[] { " SELECT StoreUserID FROM ws_storeuser  WHERE dbo.MyHTMLENcode(EmailID)='", Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), "'  AND ContactID=", dataRow1["ContactID"], " and IsDeleted=0    and CompanyID=", Program.CompanyID };
                                DataSet dataSet4 = Eprint.DataAccessLayer.SQL.ExecuteDataset(str11, CommandType.Text, string.Concat(str));
                                //if (Program.strDBName != "eprint_demo")

                                if (Program.strDBName != "eprint_birchprint")
                                {
                                    num1 = Program.Contact_InsertUpdate(Convert.ToInt32(Program.CompanyID), num1, Convert.ToInt32(Program.ClientID), "", Program.SpecialEncode(dataRow["First Name"].DBNullToString()), "", Program.SpecialEncode(dataRow["Last Name"].DBNullToString()), "", Program.SpecialEncode(row["ClientName"].DBNullToString()), "", "", Program.SpecialEncode(dataRow["Mobile"].DBNullToString()), Program.SpecialEncode(dataRow["Email Address"].DBNullToString()), num, num, num4, "", num5, false, 0, 0, "", Program.SpecialEncode(dataRow["ACC Number"].DBNullToString()), Program.SpecialEncode(dataRow["Customer Type"].DBNullToString()), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                }
                                if (dataSet4.Tables[0].Rows.Count <= 0)
                                {
                                    long num7 = (long)0;
                                    string str12 = Program.SpecialEncode(dataRow["First Name"].DBNullToString());
                                    string str13 = Program.SpecialEncode(dataRow["Last Name"].DBNullToString());
                                    string str14 = Program.SpecialEncode(dataRow["Email Address"].DBNullToString());
                                    guid = Guid.NewGuid();
                                    str1 = Convert.ToString(Program.Create_StoreUser(num7, str12, str13, str14, guid.ToString().Substring(0, 10), Convert.ToInt64(Program.CompanyID).DBNullToint64(), row["AccountID"].DBNullToint64(), "", dataRow1["clientName"].ToString(), 0));
                                    Program.Update_ContactID_ForB2B(Convert.ToInt64(str1), Convert.ToInt64(dataRow1["DeliveryAddressID"]), Convert.ToInt64(dataRow1["DeliveryAddressID"].DBNullToint64()), Convert.ToInt32(dataRow1["contactId"]));
                                }
                                else
                                {
                                    str1 = dataSet4.Tables[0].Rows[0]["StoreUserID"].DBNullToString();
                                }
                            }
                        }
                        StringBuilder stringBuilder1 = new StringBuilder();
                        stringBuilder1.Append(string.Concat("SELECT AddressID from tb_CompanyAddress where  ClientID=", Program.ClientID, " and isnull(IsDelete,0)=0 "));
                        stringBuilder1.Append(string.Concat(" and Address='", Program.SpecialEncode(dataRow["Account Address 1"].DBNullToString()), "'"));
                        stringBuilder1.Append(string.Concat(" and AddressLine2='", Program.SpecialEncode(dataRow["Account Address 2"].DBNullToString()), "'"));
                        stringBuilder1.Append(string.Concat(" and City='", Program.SpecialEncode(dataRow["Account Suburb"].DBNullToString()), "'"));
                        stringBuilder1.Append(string.Concat(" and State='", Program.SpecialEncode(dataRow["Account State"].DBNullToString()), "'"));
                        stringBuilder1.Append(string.Concat(" and ZipCode='", Program.SpecialEncode(dataRow["Account Postcode"].DBNullToString()), "'"));
                        stringBuilder1.Append(string.Concat(" and Country='", Program.SpecialEncode(dataRow["Account Country"].DBNullToString()), "'"));
                        DataSet dataSet5 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, stringBuilder1.ToString());
                        if (dataSet5.Tables[0].Rows.Count <= 0)
                        {
                            int num8 = Convert.ToInt32(Program.CompanyID);
                            int num9 = Convert.ToInt32(Program.ClientID);
                            string str15 = Program.SpecialEncode(dataRow["Account Address 1"].DBNullToString());
                            string str16 = Program.SpecialEncode(dataRow["Account Suburb"].DBNullToString());
                            string str17 = Program.SpecialEncode(dataRow["Account State"].DBNullToString());
                            string str18 = Program.SpecialEncode(dataRow["Account Country"].DBNullToString());
                            string str19 = Program.SpecialEncode(dataRow["Mobile"].DBNullToString());
                            string str20 = Program.SpecialEncode(dataRow["Account Postcode"].DBNullToString());
                            string str21 = Program.SpecialEncode(dataRow["Email Address"].DBNullToString());
                            now = DateTime.Now;
                            num3 = Program.address_insert(num8, num, num9, str15, str16, str17, str18, str19, "", str20, "", str21, false, false, true, now.ToString(), false, "", Program.SpecialEncode(dataRow["Account Address 2"].DBNullToString()), "", "1");
                        }
                        else
                        {
                            num3 = dataSet5.Tables[0].Rows[0]["AddressID"].DBNullToInt32();
                        }
                        StringBuilder stringBuilder2 = new StringBuilder();
                        stringBuilder2.Append(string.Concat("SELECT AddressID from tb_CompanyAddress where  ClientID=", Program.ClientID, " and isnull(IsDelete,0)=0 "));
                        stringBuilder2.Append(string.Concat(" and Address='", Program.SpecialEncode(dataRow["Delivery Address 1"].DBNullToString()), "'"));
                        stringBuilder2.Append(string.Concat(" and AddressLine2='", Program.SpecialEncode(dataRow["Delivery Address 2"].DBNullToString()), "'"));
                        stringBuilder2.Append(string.Concat(" and City='", Program.SpecialEncode(dataRow["Delivery Suburb"].DBNullToString()), "'"));
                        stringBuilder2.Append(string.Concat(" and State='", Program.SpecialEncode(dataRow["Delivery State"].DBNullToString()), "'"));
                        stringBuilder2.Append(string.Concat(" and ZipCode='", Program.SpecialEncode(dataRow["Delivery Postcode"].DBNullToString()), "'"));
                        stringBuilder2.Append(string.Concat(" and Country='", Program.SpecialEncode(dataRow["Delivery Country"].DBNullToString()), "'"));
                        DataSet dataSet6 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, stringBuilder2.ToString());
                        if (dataSet6.Tables[0].Rows.Count <= 0)
                        {
                            int num10 = Convert.ToInt32(Program.CompanyID);
                            int num11 = Convert.ToInt32(Program.ClientID);
                            string str22 = Program.SpecialEncode(dataRow["Delivery Address 1"].DBNullToString());
                            string str23 = Program.SpecialEncode(dataRow["Delivery Suburb"].DBNullToString());
                            string str24 = Program.SpecialEncode(dataRow["Delivery State"].DBNullToString());
                            string str25 = Program.SpecialEncode(dataRow["Delivery Country"].DBNullToString());
                            string str26 = Program.SpecialEncode(dataRow["Mobile"].DBNullToString());
                            string str27 = Program.SpecialEncode(dataRow["Delivery Postcode"].DBNullToString());
                            string str28 = Program.SpecialEncode(dataRow["Email Address"].DBNullToString());
                            now = DateTime.Now;
                            num2 = Program.address_insert(num10, num, num11, str22, str23, str24, str25, str26, "", str27, "", str28, false, false, true, now.ToString(), false, "", Program.SpecialEncode(dataRow["Delivery Address 2"].DBNullToString()), "", "1");
                        }
                        else
                        {
                            num2 = dataSet6.Tables[0].Rows[0]["AddressID"].DBNullToInt32();
                        }
                        StringBuilder stringBuilder3 = new StringBuilder();
                        stringBuilder3.Append("INSERT INTO ws_cart(CookieID, UserID, CreatedDate, CartTotalPrice, CartTax, CartShipping) VALUES (");
                        stringBuilder3.Append("'',");
                        stringBuilder3.Append(string.Concat(str1, ","));
                        now = DateTime.Now;
                        stringBuilder3.Append(string.Concat("getdate()", ","));
                        stringBuilder3.Append("0,0,0)");
                        Eprint.DataAccessLayer.SQL.ExecuteNonQuery(Program.strConnectionString, CommandType.Text, stringBuilder3.ToString());
                        int num12 = 0;
                        DataSet dataSet7 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("select top 1 cartid from ws_cart where UserID=", str1, " order by CartID desc"));
                        foreach (DataRow row2 in dataSet7.Tables[0].Rows)
                        {
                            num12 = Convert.ToInt32(row2["CartID"]);
                        }
                        int num13 = 0;
                        bool flag1 = false;
                        DataSet dataSet8 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("select PricecatalogueID,DrawStockFrom,AvailableQuantity from tb_PriceCatalogue tpc WHERE isnull(IsDeleted,0)=0  and (CustomerCode='", dataRow["SKU"].DBNullToString(), "' OR  ItemCode='", dataRow["SKU"].DBNullToString(), "') AND CompanyID=", Program.CompanyID));
              
                        //start 83138
                        // if (Program.strDBName == "eprint_demo")
                        if (Program.strDBName == "eprint_precisionafl")
                        {
                            foreach (DataRow dataRow2 in dataSet8.Tables[0].Rows)
                            {
                                object[] Querystr;
                                int pc_ID = Convert.ToInt32(dataRow2["PricecatalogueID"]);
                                string conStr = Program.strConnectionString;

                                string custDesc1 = Convert.ToString(dataRow["OrderNo"]);
                                string custDesc2 = Convert.ToString(dataRow["OrderLineItem"]);
                                string custDesc3 = Convert.ToString(dataRow["ClubCode"]);
                                string custDesc4 = Convert.ToString(dataRow["Card"]);
                                string custDesc5 = Convert.ToString(dataRow["Fulfilment"]);
                                string custDesc6 = Convert.ToString(dataRow["C_CONSIGNMENT_ID"]);

                                Querystr = new object[] { "update tb_PriceCatalogue set CustomDescription1='", custDesc1, "',CustomDescription2='", custDesc2, "',CustomDescription3='", custDesc3, "',CustomDescription4='", custDesc4, "',CustomDescription5='", custDesc5, "',CustomDescription6='", custDesc6, "' where PricecatalogueID=", pc_ID };
                                Eprint.DataAccessLayer.SQL.ExecuteDataset(conStr, CommandType.Text, string.Concat(Querystr));
                            }


                            if (num1 > 0)
                            {
                                object[] QuerystrContactUpdate;
                                string conStrContact = Program.strConnectionString;
                                string AcctIdDesc = Convert.ToString(dataRow["AcctId"]);

                                QuerystrContactUpdate = new object[] { "update tb_Contact set CustomField1='", AcctIdDesc, "' where ContactID=", num1 };
                                Eprint.DataAccessLayer.SQL.ExecuteDataset(conStrContact, CommandType.Text, string.Concat(QuerystrContactUpdate));
                            }



                        }
                        //end 83138


                        if (dataRow["Units"].ToString().Trim().Length == 0)
                        {
                            dataRow["Units"] = "0";
                        }
                        if (dataRow["Units"].ToString().Contains(","))
                        {
                            dataRow["Units"] = dataRow["Units"].ToString().Replace(",", "");
                        }

                        Decimal _unit = Convert.ToDecimal(dataRow["Units"]);
                        foreach (DataRow dataRow2 in dataSet8.Tables[0].Rows)
                        {
                            num13 = Convert.ToInt32(dataRow2["PricecatalogueID"]);
                            if (dataRow2["DrawStockFrom"].ToString().ToLower() == "m")
                            {
                                dataTable = Program.OtherMultipleProductDetails_Select(Convert.ToInt64(dataRow2["PricecatalogueID"]), Convert.ToInt32(dataRow["Units"]), true);
                                foreach (DataRow row3 in dataTable.Rows)
                                {
                                    //if (Convert.ToInt32(row3["AvailableQuantity"]) < Convert.ToInt32(dataRow["Units"]))
                                    if (Convert.ToInt32(row3["AvailableQuantity"]) < Convert.ToInt32(_unit))
                                    {
                                        flag1 = true;
                                    }
                                }
                            }
                            //else if (Convert.ToInt32(dataRow2["AvailableQuantity"]) < Convert.ToInt32(dataRow["Units"]))
                            else if (Convert.ToInt32(dataRow2["AvailableQuantity"]) < Convert.ToInt32(_unit))
                            {
                                flag1 = true;
                            }
                        }
                        string TaxName = string.Empty;
                        decimal TaxRate = 0;
                        long TaxID = 0;
                        //  DataTable dtTax = ProductBasePage.Tax_Bind(CompanyID);
                        DataTable dtTax = Program.GetTaxDetails(CompanyID, str1.ToString());
                        foreach (DataRow drTax in dtTax.Rows)
                        {
                            TaxID = Convert.ToInt64(drTax["TaxID"]);
                            TaxName = drTax["TaxName"].ToString();
                            TaxRate = Convert.ToDecimal(drTax["TaxRate"].ToString());
                        }


                        //long ProductID = PriceCatalogueID;//Convert.ToInt64(Request.Params["ID"].ToString());
                        long Quantity = 0;
                        decimal UnitPrice = 0;
                        decimal MainTotalPriceIncMarkup = 0;
                        decimal TaxPercent = 0;
                        decimal MainPriceExcMarkup = 0;
                        decimal Height = 0;
                        decimal Width = 0;


                        // Quantity = item.Quantity.DBNullToInt32();
                        //Quantity = dataRow["units"].DBNullToInt32();
                        //Quantity = Convert.ToInt32(_unit);
                        Quantity = _unit.DBNullToInt32();





                        DataTable dtProductPricingDetails = GetProductPricingDetails_ByProductid(Convert.ToInt32(Quantity),num13);

                        if (Quantity > 0)
                        {
                            foreach (DataRow drProductPricingDetails in dtProductPricingDetails.Rows)
                            {

                                MainPriceExcMarkup = Convert.ToDecimal(drProductPricingDetails["Price"]) * Quantity;
                                decimal Markup = Convert.ToDecimal(drProductPricingDetails["Markup"]);
                                MainTotalPriceIncMarkup = ((MainPriceExcMarkup * Markup) / 100) + MainPriceExcMarkup;
                                UnitPrice = MainTotalPriceIncMarkup / Quantity;
                                TaxPercent = TaxRate;
                                MainPriceExcMarkup = (MainPriceExcMarkup * Markup) / 100; // This seems wrong but it is correct as we are passing markup price here

                            }
                        }
                        else
                        {
                            Quantity = 0;
                        }

                        if (flag1)
                        {
                            Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("update tb_OrderImportItems set isItemProcessCompleted=2,ErrorMessage='Back Order is not switched on for this Product' where  ID=", dataRow["ID"]));
                        }
                        //else //KR ticket 11352 [order should be created for non stock items also]
                        {
                            StringBuilder stringBuilder4 = new StringBuilder();
                            stringBuilder4.Append("INSERT into ws_cartitems(CartID, ProductID, JobName, Quantity, UnitPrice, IsDelete, IsConvertedToOrder, UploadFile, UploadFile1, \r\n                            UploadFile2, MainItemPrice, Tax, MainItemMarkupPrice, TaxID, TemplateID, OrderStatus, PDFNameFromCart, OriginalUploadFileName, OriginalUploadFileName1, OriginalUploadFileName2, \r\n                            SavedDesignName, Order_Behalf_UserID, Order_behalf_DeptID, IsStockReplenish, CampaignID, Height, Width,MainProductID)\r\n                            VALUES (");//kr
                            stringBuilder4.Append(string.Concat(num12, ","));
                            stringBuilder4.Append(string.Concat(num13, ","));
                            stringBuilder4.Append("'',");
                            //stringBuilder4.Append(string.Concat(dataRow["Units"].DBNullToInt32(), ","));
                            stringBuilder4.Append(string.Concat(_unit.DBNullToInt32(), ","));
                            stringBuilder4.Append(string.Concat(UnitPrice, ","));//unitprice
                            stringBuilder4.Append("0,");//isdelete
                            stringBuilder4.Append("0,");//isconvertedtoorder
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append(string.Concat(MainTotalPriceIncMarkup, ","));//MainItemPrice...1  MainPriceExcMarkup
                            stringBuilder4.Append(string.Concat(TaxPercent, ","));//Tax TaxPercent
                            stringBuilder4.Append(string.Concat(MainPriceExcMarkup, ","));//MainItemMarkupPrice...1
                            stringBuilder4.Append(string.Concat(TaxID, ","));//TaxID Taxid
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("'C',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("'',");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0,");
                            stringBuilder4.Append("0");//kr for MainProductID
                            stringBuilder4.Append(")");
                            Eprint.DataAccessLayer.SQL.ExecuteNonQuery(Program.strConnectionString, CommandType.Text, stringBuilder4.ToString());
                            int num14 = 0;
                            DataSet dataSet9 = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("select top 1 CartItemID FROM Ws_CartItems WHERE isnull(IsConvertedToOrder,0)=0 AND CartID= ", num12, " order by cartitemID desc"));
                            foreach (DataRow dataRow3 in dataSet9.Tables[0].Rows)
                            {
                                num14 = Convert.ToInt32(dataRow3["CartItemID"]);
                            }
                            if (num14 > 0)
                            {
                                empty = string.Concat(empty, num14.ToString(), ",");
                            }
                            Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("update tb_OrderImportItems set isItemProcessCompleted=4,ErrorMessage='' where  ID=", dataRow["ID"]));
                            string str29 = Program.strConnectionString;
                            str = new object[] { "update Ws_CartItems set OrderImportDetailID=", dataRow["ID"], " where  CartItemID=", num14 };
                            Eprint.DataAccessLayer.SQL.ExecuteDataset(str29, CommandType.Text, string.Concat(str));
                        }
                    }
                    if (empty.Trim().Length > 0)
                    {
                        empty = empty.Substring(0, empty.Length - 1);
                    }
                    if (empty.Trim().Length <= 0)
                    {
                        string str30 = Program.strConnectionString;
                        str = new object[] { "update tb_OrderImportItems set isItemProcessCompleted=4,ErrorMessage='No Items to process' where dbo.MyHTMLENcode(isnull([Order],''))='", Program.SpecialEncode(row["Order"].ToString()), "' AND isnull(OrderImportID,0)=", row["OrderImportID"] };
                        Eprint.DataAccessLayer.SQL.ExecuteDataset(str30, CommandType.Text, string.Concat(str));
                    }
                    else
                    {
                        DataSet dataSet10 = Program.Select_OrderItems_BeforeOrder(str1.DBNullToint64(), empty);
                        DataTable item = dataSet10.Tables[0];
                       if (item.Rows.Count > 0)
                        {
                            foreach (DataRow row4 in item.Rows)
                            {
                                if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    try
                                    {
                                        if (Convert.ToInt32(row4["AvailableQuantity"]) < Convert.ToInt32(row4["Quantity"]))
                                        {
                                            Program.Prod_Id = string.Concat(Program.Prod_Id, row4["ProductID"].ToString(), "$");
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    dataTable = Program.OtherMultipleProductDetails_Select(Convert.ToInt64(row4["ProductID"]), Convert.ToInt16(row4["Quantity"]), true);
                                    foreach (DataRow dataRow4 in dataTable.Rows)
                                    {
                                        try
                                        {
                                            if (Convert.ToInt32(dataRow4["AvailableQuantity"]) < Convert.ToInt32(row4["Quantity"]))
                                            {
                                                Program.Prod_Id = string.Concat(Program.Prod_Id, row4["ProductID"].ToString(), "$");
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                        }
                        long num15 = (long)num1;
                        DataTable dataTable1 = new DataTable();
                        dataTable1.Columns.Add("StoreUserID", typeof(string));
                        dataTable1.Columns.Add("SessionKey", typeof(string));
                        dataTable1.Columns.Add("InvoiceAddressID", typeof(string));
                        dataTable1.Columns.Add("DeliveryAddressID", typeof(string));
                        dataTable1.Columns.Add("ClientID", typeof(string));
                        dataTable1.Columns.Add("IsOrdered", typeof(string));
                        dataTable1.Columns.Add("PaymentType", typeof(string));
                        dataTable1.Columns.Add("RequiredBy", typeof(string));
                        dataTable1.Columns.Add("Comments", typeof(string));
                        dataTable1.Columns.Add("OrderTitle", typeof(string));
                        dataTable1.Columns.Add("OrderNumber", typeof(string));
                        dataTable1.Columns.Add("OrderID", typeof(string));
                        dataTable1.Columns.Add("CostCentreID", typeof(string));
                        dataTable1.Columns.Add("DesignatedApproverEmail", typeof(string));
                        dataTable1.Columns.Add("CostCentreName", typeof(string));
                        dataTable1.Columns.Add("DeptID", typeof(string));
                        dataTable1.Columns.Add("orderbehalftype", typeof(string));
                        dataTable1.Columns.Add("OrderForUserID", typeof(string));
                        dataTable1.Columns.Add("EstimateOrderDate", typeof(string));//kr123
                        var _date = row["EstDate"].ToString();
                        object[] objArray = new object[] { str1, "", num3.ToString(), num2.ToString(), Program.ClientID, true, "", "1/1/1900", str2, Program.SpecialEncode(row["Order"].ToString()), Program.SpecialEncode(row["Order"].ToString()), "0", "0", "", "", num4, "", num15, Program.SpecialEncode(row["EstDate"].ToString()) };
                        dataTable1.Rows.Add(objArray);
                        Program.OrderPayment(str1.DBNullToint64(), empty, dataTable1);
                    }
                }
            }
        }

        public static int Check_MaxKit_Availability(long PriceCatalogueID, int NumberOfKit)
        {
            string empty = string.Empty;
            int num = 0;
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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
                num = (numArray.Length == 0 ? 0 : numArray.Min());
            }
            return (num == 0 ? num : num);
        }

        public static DataTable GetTaxDetails(string CompanyID, string StoreUserID)
        {
            commonclass objcom = new commonclass();
            Database db = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataTable dt = new DataTable();
            DbCommand cmd = db.GetStoredProcCommand("PC_B2B_Tax_SelectByStoreUserID");
            db.AddInParameter(cmd, "@CompanyID", DbType.String, CompanyID);
            db.AddInParameter(cmd, "@StoreUserID", DbType.String, StoreUserID);


            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                dt.Load(reader);
            }
            return dt;
        }

        public static DataTable GetProductPricingDetails_ByProductid(int quantity,int productid)
        {
            commonclass objcom = new commonclass();
            Database db = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataTable dt = new DataTable();
            DbCommand cmd = db.GetStoredProcCommand("DMCOrderimport_GetProductPricingDetails_ByProductid");
            
            db.AddInParameter(cmd, "@totalqty", DbType.Int32, quantity);
            db.AddInParameter(cmd, "@ProductID", DbType.Int32, productid);


            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                dt.Load(reader);
            }
            return dt;
        }

        public static int Contact_InsertUpdate(int CompanyID, int ContactID, int ClientID, string Salutation, string FirstName, string MiddleName, string LastName, string ContactAlias, string CompanyName, string JobTitle, string HomeTelephone, string Mobile, string Email, int ReportToUserID, int CreateUserID, long DepartmentID, string PersonalFax, int ContactAddressID, bool MainApprover, int ChkSubscribed, int IsReceiveMailOut, string AlternateNumbers, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[DMC_ORDER_PC_Contact_InsertUpdate]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Salutation", DbType.String, Salutation);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@MiddleName", DbType.String, MiddleName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@ContactAlias", DbType.String, ContactAlias);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@JobTitle", DbType.String, JobTitle);
            database.AddInParameter(storedProcCommand, "@HomeTelephone", DbType.String, HomeTelephone);
            database.AddInParameter(storedProcCommand, "@Mobile", DbType.String, Mobile);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@ReportToUserID", DbType.Int32, ReportToUserID);
            database.AddInParameter(storedProcCommand, "@CreateUserID", DbType.Int32, CreateUserID);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.AddInParameter(storedProcCommand, "@PersonalFax", DbType.String, PersonalFax);
            database.AddInParameter(storedProcCommand, "@ContactAddressID", DbType.Int32, ContactAddressID);
            database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int32, ChkSubscribed);
            database.AddInParameter(storedProcCommand, "@MainApprover", DbType.Boolean, MainApprover);
            database.AddInParameter(storedProcCommand, "@IsReceiveMailOut", DbType.Int32, IsReceiveMailOut);
            database.AddInParameter(storedProcCommand, "@AlternateNumbers", DbType.String, AlternateNumbers);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, CustomField1);
            database.AddInParameter(storedProcCommand, "@CustomField2", DbType.String, CustomField2);
            database.AddInParameter(storedProcCommand, "@CustomField3", DbType.String, CustomField3);
            database.AddInParameter(storedProcCommand, "@CustomField4", DbType.String, CustomField4);
            database.AddInParameter(storedProcCommand, "@CustomField5", DbType.String, CustomField5);
            database.AddInParameter(storedProcCommand, "@CustomField6", DbType.String, CustomField6);
            database.AddInParameter(storedProcCommand, "@CustomField7", DbType.String, CustomField7);
            database.AddInParameter(storedProcCommand, "@CustomField8", DbType.String, CustomField8);
            database.AddInParameter(storedProcCommand, "@CustomField9", DbType.String, CustomField9);
            database.AddInParameter(storedProcCommand, "@CustomField10", DbType.String, CustomField10);
            database.AddInParameter(storedProcCommand, "@CustomField11", DbType.String, CustomField11);
            database.AddInParameter(storedProcCommand, "@CustomField12", DbType.String, CustomField12);
            database.AddInParameter(storedProcCommand, "@CustomField13", DbType.String, CustomField13);
            database.AddInParameter(storedProcCommand, "@CustomField14", DbType.String, CustomField14);
            database.AddInParameter(storedProcCommand, "@CustomField15", DbType.String, CustomField15);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }
        public static DataTable GetContactIDAndCountByEmail(int ClientID, string Email)
        {
            DataTable dataTable = new DataTable();
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetContactIDAndCountByEmail");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public static long Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUser_Import_order");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@IsPsw", DbType.String, IsPsw);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int64, subscribe_newsletter);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public static void Estimate_insertFrom_WebOrders(int CompanyID, long ClientID, long StoreUserID, long OrderID, DateTime Date, string CreatedDateTime, bool IsApproved, string ApproverEmail)
        {
            try
            {
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_B2B_Estimate_insertFrom_WebOrders]");
                storedProcCommand.CommandTimeout = 0;
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
                database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
                database.AddInParameter(storedProcCommand, "@Date", DbType.DateTime, Date);
                database.AddInParameter(storedProcCommand, "@IsApproved", DbType.Boolean, IsApproved);
                database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
                database.AddInParameter(storedProcCommand, "@CreatedDateTime", DbType.String, CreatedDateTime);
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch
            {
            }
        }

        public static string GenPassWithCap(int i)
        {
            Program.rGen = new Random();
            int num = 0;
            string str = "";
            for (int i1 = 0; i1 <= i; i1++)
            {
                num = Program.rGen.Next(0, 60);
                str = string.Concat(str, Program.strCharacters[num]);
            }
            return str;
        }

        public static bool Get_Dept_IsApprovalNotRequired(long DepartmentID)
        {
            bool flag;
            DataTable dataTable = new DataTable();
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase((Program.strConnectionString));
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_Get_Dept_IsApprovalNotRequired");
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            object obj = database.ExecuteScalar(storedProcCommand);
            try
            {
                if (obj != null)
                {
                    flag = (!(bool)obj ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static long GetParentIDOfOtherMultipleProduct(long KitItemID)
        {
            long num = (long)0;
            DataSet dataSet = new DataSet();
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetParentIDOfOtherMultipleProduct");
            database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, KitItemID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                num = Convert.ToInt64(row["PriceCatalogueID"].ToString());
            }
            return num;
        }

        public static DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_price_for_pack_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public string eprint_checkdateformat_returnonlymmddyyyy(string DateFormat, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (Convert.ToInt32(strArrays[0].ToString()) > 12)
                {
                    string[] str = new string[] { strArrays[1].ToString(), "/", strArrays[0].ToString(), "/", strArrays[2].ToString() };
                    txtvalue = string.Concat(str);
                }
                else if (Convert.ToInt32(strArrays[1].ToString()) > 12)
                {
                    string[] str1 = new string[] { strArrays[0].ToString(), "/", strArrays[1].ToString(), "/", strArrays[2].ToString() };
                    txtvalue = string.Concat(str1);
                }
                else if (DateFormat == "dd/mm/yyyy")
                {
                    string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays1);
                }
                else if (DateFormat == "mm/dd/yyyy")
                {
                    string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays2);
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        public static DateTime addDaysToDate(int NoOfDaysToBeAdded, List<string> lst, DateTime estdate)
        {
            int count = 0;
            DateTime dt = new DateTime();
            dt = estdate;
            while (count < NoOfDaysToBeAdded)
            {
                dt = dt.AddDays(1);
                string day = dt.DayOfWeek.ToString();
                if (lst.Contains(day))
                {
                    count = count + 1;
                }
            }
            return dt;
        }

        private static string Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType, string RequiredDate, string Comments, string OrderTitle, string OrderNo, string strMultipleCartID, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long DeptID, string orderbehalftype, long OrderForUserID, DateTime EstimateOrderDate)
        {
            string str = Program.GenPassWithCap(12);
            string empty = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            string str1 = "1/1/1900";

            #region dates handling

            DataTable dt = Price_For_Whole_Pack_Select(Convert.ToInt32(Program.CompanyID));
            int NoOfDaysAddedForArtWork = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedArtwork"]);
            int NoOfDaysAddedForProof = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProof"]);
            int NoOfDaysAddedForApproval = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedApproval"]);
            int NoOfDaysAddedForProduction = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProduction"]);
            int NoOfDaysAddedForCompletion = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedCompletion"]);
            int NoOfDaysAddedForDelivery = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedDelivery"]);

            int WorkingDaysFrom = Convert.ToInt32(dt.Rows[0]["WorkingDaysFrom"]);
            int WorkingDaysTo = Convert.ToInt32(dt.Rows[0]["WorkingDaysTo"]);

            var myList = new List<KeyValuePair<string, int>>();
            myList.Add(new KeyValuePair<string, int>("Sunday", 1));
            myList.Add(new KeyValuePair<string, int>("Monday", 2));
            myList.Add(new KeyValuePair<string, int>("Tuesday", 3));
            myList.Add(new KeyValuePair<string, int>("Wednesday", 4));
            myList.Add(new KeyValuePair<string, int>("Thursday", 5));
            myList.Add(new KeyValuePair<string, int>("Friday", 6));
            myList.Add(new KeyValuePair<string, int>("Saturday", 7));

            List<string> lst = new List<string>();

            if (WorkingDaysFrom < WorkingDaysTo)
            {
                for (int i = WorkingDaysFrom; i <= WorkingDaysTo; i++)
                {
                    foreach (var val in myList)
                    {
                        if (val.Value == i)
                        {
                            if (lst.Contains(val.Key) == false)
                                lst.Add(val.Key);
                        }
                    }
                }
            }
            else if (WorkingDaysFrom > WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (val.Value < WorkingDaysFrom && val.Value > WorkingDaysTo)
                    {

                    }
                    else
                    {
                        if (lst.Contains(val.Key) == false)
                            lst.Add(val.Key);
                    }
                }
            }
            else if (WorkingDaysFrom == WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (lst.Contains(val.Key) == false)
                        lst.Add(val.Key);
                }
            }

            DateTime EstimatedArtwork = new DateTime();
            EstimatedArtwork = addDaysToDate(NoOfDaysAddedForArtWork, lst, EstimateOrderDate);
            DateTime EstProofDate = new DateTime();
            EstProofDate = addDaysToDate(NoOfDaysAddedForProof, lst, EstimateOrderDate);
            DateTime EstApprovalDate = new DateTime();
            EstApprovalDate = addDaysToDate(NoOfDaysAddedForApproval, lst, EstimateOrderDate);
            DateTime EstProductionDate = new DateTime();
            EstProductionDate = addDaysToDate(NoOfDaysAddedForProduction, lst, EstimateOrderDate);
            DateTime EstCompletionDate = new DateTime();
            EstCompletionDate = addDaysToDate(NoOfDaysAddedForCompletion, lst, EstimateOrderDate);
            DateTime EstimatedDelivery = new DateTime();
            EstimatedDelivery = addDaysToDate(NoOfDaysAddedForDelivery, lst, EstimateOrderDate);


            #endregion



            long num3 = Program.Insert_Orders(StoreUserID, Convert.ToInt64(Program.AccountID), "", num, num1, num2, BillingAddressID, ShippingAddressID, Convert.ToInt64(Program.CompanyID), ClientID, PaymentType, EstimateOrderDate, Convert.ToDateTime(str1), Comments, str, OrderTitle, OrderNo, "", OrderForUserID, DeptID, IsApproved, CostCentreID, StoreUserID, orderbehalftype, EstimatedArtwork, EstProofDate, EstApprovalDate, EstProductionDate, EstCompletionDate, EstimatedDelivery);
            DataTable dataTable = new DataTable();
            if (Program.strDBName == "eprint_birchprint")
                //if (Program.strDBName == "eprint_demo")
            {
                dataTable = Program.Select_birch_MultipleCartItems(CookieID, "", StoreUserID, strMultipleCartID);
            }
            else
            {
                dataTable = Program.Select_MultipleCartItems(CookieID, "", StoreUserID, strMultipleCartID);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                bool flag = false;
                if (!string.IsNullOrEmpty(Program.Prod_Id))
                {
                    string[] strArrays = Program.Prod_Id.Split(new char[] { '$' });
                    int num4 = 0;
                    while (num4 < (int)strArrays.Length)
                    {
                        if (strArrays[num4].ToString() != row["ProductID"].ToString())
                        {
                            num4++;
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                Program.Insert_OrdersItems(num3, Convert.ToInt64(row["CartItemID"]), flag, Convert.ToInt64(Program.CompanyID), IsApproved, StoreUserID, "", ClientID, dataTable.Rows.Count);
                Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.strConnectionString, CommandType.Text, string.Concat("update tb_OrderImportItems set isItemProcessCompleted=1,ErrorMessage='' where  ID in (select OrderImportDetailID from Ws_CartItems where CartItemID= ", row["CartItemID"].ToString(), ")"));
               // CalculateGrossProfit((Convert.ToInt64(row["CartItemID"])), Convert.ToInt32(Program.CompanyID));//KR1
            }
            string str2 = DateTime.Now.ToString();
            Program.Estimate_insertFrom_WebOrders(Convert.ToInt32(Program.CompanyID), ClientID, StoreUserID, num3, dateTime, str2, IsApproved, "");
            return num3.ToString();
        }

        public static void CalculateGrossProfit(Int64 cartItemId, Int32 companyID)
        {
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("updateGrossProfit");
                database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, cartItemId);
                database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
                storedProcCommand.CommandTimeout = Int32.MaxValue;
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static long Insert_Orders(long StoreUserID, long AccountID, string OrderNo, decimal TotalPrice, decimal Tax, decimal OrderShipping, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, string ApproverEmail, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long OrderedBy, string orderbehalftype, DateTime EstimatedArtwork, DateTime EstProofDate, DateTime EstApprovalDate, DateTime EstProductionDate, DateTime EstCompletionDate, DateTime EstimatedDelivery)
        {
            try
            {
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_OrdersDetails_MIS_importProcess");
                storedProcCommand.CommandTimeout = 0;
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
                database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
                database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
                database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
                database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
                database.AddInParameter(storedProcCommand, "@PaymentType", DbType.String, PaymentType);
                database.AddInParameter(storedProcCommand, "@OrderDate", DbType.DateTime, OrderDate);
                database.AddInParameter(storedProcCommand, "@RequiredDate", DbType.DateTime, RequiredDate);
                database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
                database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
                database.AddInParameter(storedProcCommand, "@OrderTitle", DbType.String, OrderTitle);
                database.AddInParameter(storedProcCommand, "@UserRefOrderNo", DbType.String, UserRefOrderNo);
                database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
                database.AddInParameter(storedProcCommand, "@Order_Behalf_UserID", DbType.Int64, BehalfUserID);
                database.AddInParameter(storedProcCommand, "@Order_behalf_DeptID", DbType.Int64, BehalfDeptID);
                database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
                database.AddInParameter(storedProcCommand, "@OrderedBy", DbType.Int64, OrderedBy);
                database.AddInParameter(storedProcCommand, "@OrderPrefix", DbType.String, "ORD-");
                database.AddInParameter(storedProcCommand, "@orderbehalftype", DbType.String, orderbehalftype);
                database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, 0);
                database.AddInParameter(storedProcCommand, "@BT_OrderID", DbType.String, "");
                database.AddInParameter(storedProcCommand, "@BT_AuthorizationCode", DbType.String, "");
                database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
                database.AddInParameter(storedProcCommand, "@IsTwoWayApproval", DbType.String, "");
                database.AddInParameter(storedProcCommand, "@DepartmentApproval", DbType.String, "");
                database.AddInParameter(storedProcCommand, "@MainApproval", DbType.String, "");
                database.AddInParameter(storedProcCommand, "@ApprovalEmails", DbType.String, "");

                database.AddInParameter(storedProcCommand, "@EstProofDate", DbType.DateTime, EstProofDate);
                database.AddInParameter(storedProcCommand, "@EstApprovalDate", DbType.DateTime, EstApprovalDate);
                database.AddInParameter(storedProcCommand, "@EstProductionDate", DbType.DateTime, EstProductionDate);
                database.AddInParameter(storedProcCommand, "@EstCompletionDate", DbType.DateTime, EstCompletionDate);
                database.AddInParameter(storedProcCommand, "@EstimatedArtwork", DbType.DateTime, EstimatedArtwork);
                database.AddInParameter(storedProcCommand, "@EstimatedDelivery", DbType.DateTime, EstimatedDelivery);


                database.ExecuteNonQuery(storedProcCommand);
                object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
                return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void Insert_OrdersItems(long OrderID, long CartItemID, bool BKOrder, long CompanyID, bool ApproveStatus, long StoreUserID, string ApproverEmail, long ClientID, int ItemCount)
        {
            try
            {
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("DMCOrder_PC_B2B_OrderItem_Insert");
                database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
                database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, BKOrder);
                database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, OrderID);
                database.AddInParameter(storedProcCommand, "@Companyid", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand, "@ApproveStatus", DbType.Boolean, ApproveStatus);
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
                database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
                database.AddInParameter(storedProcCommand, "@EstimateItemCount", DbType.Int32, ItemCount);
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void KitStockAllocationOrReduction(long PriceCatalogueID, int Quantity, char Type, long CreatedBy)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Kit_AllocationOrReduction");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        private static void Main(string[] args)
        {
            //Program.btn_confirm_OnClick(); //kr
            string servername = (ConfigurationManager.AppSettings["ServerName"]).ToString(); //change in app.config
            string userid = (ConfigurationManager.AppSettings["UserId"]).ToString(); //change in app.config
            string password = (ConfigurationManager.AppSettings["Password"]).ToString(); //change in app.config
            try
            {
                string connectionString = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //string strDBName = "";
                    using (SqlCommand command = new SqlCommand("select CRMConnectionString from tb_MIS_ConnectionStrings where HostName in ('demo.eprintsoftware.com')", connection))
                    //using (SqlCommand command = new SqlCommand("select distinct CRMConnectionString,a.ServerName , ab.IsActive, a.isEnableImportOrders from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName inner join tb_ClientInfo ab on c.HostName = ab.System_URL where a.isEnableImportOrders = 'true' and ab.IsActive=1", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] strArray = reader[0].ToString().Split(';');
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                if (strArray[i].Contains("Initial Catalog"))
                                {
                                    Program.strDBName = strArray[i].ToString().Split('=')[1];
                                    if (Program.CheckIfDataBaseExists(Program.strDBName, servername, userid, password) > 0)
                                    {
                                        if (Program.DBStatus(Program.strDBName, servername, userid, password) == "ONLINE")
                                        {
                                            Program.strConnectionString = "";
                                            Program.strConnectionString = reader[0].ToString();
                                            Program.GoForImportProcess(Program.strConnectionString); //For DMC Order Import Process.
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Main_Method(string serverName, string userId, string passWord, string connectionstring)
        {
            string servername = serverName;
            string userid = userId;
            string password = passWord;
            Program.strConnectionString = connectionstring;
            //Program.GoForImportProcess(Program.strConnectionString);
            try
            {
                //string connectionString = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    //string strDBName = "";
                //    using (SqlCommand command = new SqlCommand("select CRMConnectionString from tb_MIS_ConnectionStrings where HostName in ('demo.eprintsoftware.com')", connection))
                //    //using (SqlCommand command = new SqlCommand("select distinct CRMConnectionString,a.ServerName , ab.IsActive, a.isEnableImportOrders from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName inner join tb_ClientInfo ab on c.HostName = ab.System_URL where a.isEnableImportOrders = 'true' and ab.IsActive=1", connection))
                //    {
                //        SqlDataReader reader = command.ExecuteReader();
                //        while (reader.Read())
                //        {
                string[] strArray = connectionstring.Split(';');
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Contains("Initial Catalog"))
                    {
                        Program.strDBName = strArray[i].ToString().Split('=')[1];
                        //if (Program.CheckIfDataBaseExists(Program.strDBName, servername, userid, password) > 0)
                        //{
                        //    if (Program.DBStatus(Program.strDBName, servername, userid, password) == "ONLINE")
                        //    {
                                //Program.strConnectionString = "";
                                //Program.strConnectionString = reader[0].ToString();
                                Program.GoForImportProcess(Program.strConnectionString); //For DMC Order Import Process.
                        //    }
                        //}

                    }
                }
                //}
                //}
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Program.btn_confirm_OnClick(); //kr
            //string servername = (ConfigurationManager.AppSettings["ServerName"]).ToString(); //change in app.config
            //string userid = (ConfigurationManager.AppSettings["UserId"]).ToString(); //change in app.config
            //string password = (ConfigurationManager.AppSettings["Password"]).ToString(); //change in app.config


            //try
            //{
            //    string connectionString = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        //string strDBName = "";
            //        using (SqlCommand command = new SqlCommand("select CRMConnectionString from tb_MIS_ConnectionStrings where HostName in ('demo.eprintsoftware.com')", connection))
            //        //using (SqlCommand command = new SqlCommand("select distinct CRMConnectionString,a.ServerName , ab.IsActive, a.isEnableImportOrders from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName inner join tb_ClientInfo ab on c.HostName = ab.System_URL where a.isEnableImportOrders = 'true' and ab.IsActive=1", connection))
            //        {
            //            SqlDataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                string[] strArray = reader[0].ToString().Split(';');
            //                for (int i = 0; i < strArray.Length; i++)
            //                {
            //                    if (strArray[i].Contains("Initial Catalog"))
            //                    {
            //                        Program.strDBName = strArray[i].ToString().Split('=')[1];
            //                        if (Program.CheckIfDataBaseExists(Program.strDBName, servername, userid, password) > 0)
            //                        {
            //                            if (Program.DBStatus(Program.strDBName, servername, userid, password) == "ONLINE")
            //                            {
            //                                Program.strConnectionString = "";
            //                                Program.strConnectionString = reader[0].ToString();
            //                                Program.GoForImportProcess(Program.strConnectionString); //For DMC Order Import Process.
            //                                //if (Program.strDBName == "eprint_test3")
            //                                //{
            //                                //    Program.GoForImportProcess(Program.strConnectionString); //For DMC Order Import Process.
            //                                //}

            //                            }
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private static void GoForImportProcess(string clientDBConnectionString)
        {
            try
            {
                string connectionString = clientDBConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select distinct CompanyID from tb_OrderImport oi inner join tb_OrderImportItems oii on oi.OrderImportID = oii.OrderImportID where oii.isItemProcessCompleted = 0", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Program.CompanyID = reader[0].ToString();
                            Program.strConnectionString = clientDBConnectionString;
                            Program.btn_confirm_OnClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CheckIfDataBaseExists(string dbName, string servername, string userid, string password)
        {
            int val = 0;
            //servername = "LAPTOP-6FCTKC96";//just for local
            string connectionStringMaster = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
            using (SqlConnection connection = new SqlConnection(connectionStringMaster))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select count(*) from sys.sysdatabases where name= " + "'" + dbName + "'", connection))
                {
                    val = (int)(command.ExecuteScalar());
                }
            }
            return val;
        }

        public static string DBStatus(string dbName, string servername, string userid, string password)
        {
            string val = "";
            //servername = "LAPTOP-6FCTKC96";//just for local
            string connectionStringMaster = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
            using (SqlConnection connection = new SqlConnection(connectionStringMaster))
            {
                connection.Open();
                //select  DATABASEPROPERTYEX('eprint_reef', 'Status') AS DBStatus
                using (SqlCommand command = new SqlCommand("select  DATABASEPROPERTYEX('" + dbName + "', 'Status') AS DBStatus", connection))
                {
                    val = (string)(command.ExecuteScalar());
                }
            }
            return val;
        }


        public static void OrderPayment(long StoreUserID, string strMultipleCartID, DataTable dt_InsertOrder)
        {
            DateTime orderDate = new DateTime();
            commonclass _common = new commonclass();
            foreach (DataRow row in dt_InsertOrder.Rows)
            {
                //kr123
                DateTime EstimateOrderDate = new DateTime();
                string systemDateFormat = Program.return_regional_datetimeformat(row["EstimateOrderDate"].ToString(), int.Parse(Program.CompanyID));
                try
                {
                    if (row["EstimateOrderDate"] == null || (row["EstimateOrderDate"]).ToString() == "")
                        //EstimateOrderDate = DateTime.Now.ToString(systemDateFormat);
                        EstimateOrderDate = DateTime.Now;

                    else
                        EstimateOrderDate = Convert.ToDateTime(_common.Return_Date_Before_View1(row["EstimateOrderDate"].ToString(), systemDateFormat));
                    //EstimateOrderDate = Convert.ToDateTime(row["EstimateOrderDate"]);
                    //EstimateOrderDate= DateTime.Parse(row["EstimateOrderDate"].ToString());

                }
                catch (Exception ex)
                {
                    if (systemDateFormat == "dd/mm/yyyy")
                    {
                        if (row["EstimateOrderDate"] == null || (row["EstimateOrderDate"]).ToString() == "")
                            EstimateOrderDate = DateTime.Now;
                        else
                            EstimateOrderDate = Convert.ToDateTime(_common.Return_Date_Before_View1(row["EstimateOrderDate"].ToString(), "mm/dd/yyyy"));
                    }
                    else
                    {
                        if (row["EstimateOrderDate"] == null || (row["EstimateOrderDate"]).ToString() == "")
                            EstimateOrderDate = DateTime.Now;
                        else
                            EstimateOrderDate = Convert.ToDateTime(_common.Return_Date_Before_View1(row["EstimateOrderDate"].ToString(), "dd/mm/yyyy"));

                    }

                }

                //EstimateOrderDate = (Convert.ToDateTime(row["EstimateOrderDate"].ToString())).ToString(systemDateFormat);
                //EstimateOrderDate = DateTime.Parse(DateTime.Parse(row["EstimateOrderDate"].ToString()).ToString(systemDateFormat));
                //EstimateOrderDate = DateTime.ParseExact(row["EstimateOrderDate"].ToString(), systemDateFormat, CultureInfo.InvariantCulture);
                string str = Program.Insert_Order(row["SessionKey"].ToString(), Convert.ToInt64(row["StoreUserID"]), Convert.ToInt64(row["InvoiceAddressID"]), Convert.ToInt64(row["DeliveryAddressID"]), Convert.ToInt64(row["ClientID"]), row["IsOrdered"].ToString(), row["PaymentType"].ToString(), row["RequiredBy"].ToString(), row["Comments"].ToString(), row["OrderTitle"].ToString(), row["OrderNumber"].ToString(), strMultipleCartID, (long)0, (long)0, true, Convert.ToInt64(row["CostCentreID"]), Convert.ToInt64(row["DeptID"]), row["orderbehalftype"].ToString(), Convert.ToInt64(row["OrderForUserID"]), EstimateOrderDate);//kr123
                foreach (DataRow dataRow in Program.Select_OrderItems(Convert.ToInt64(str), StoreUserID).Rows)
                {
                    dataRow["OrderKey"].ToString();
                    long num = Convert.ToInt64(dataRow["ProductID"]);
                    int num1 = Convert.ToInt32(dataRow["Quantity"]);
                    decimal num2 = Convert.ToDecimal(dataRow["UnitPrice"]);
                    long num3 = Convert.ToInt64(dataRow["EstimateItemID"]);
                    long num4 = Convert.ToInt64(dataRow["OrderItemID"]);
                    Convert.ToBoolean(dataRow["IsStockReplenish"]);
                    string str1 = Program.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str2 = Program.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    DataTable dataTable = Program.ProductStockType_Select(Convert.ToInt64(Program.CompanyID), num);
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (row1["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            Program.StockAllocationProcess(Convert.ToInt64(Program.CompanyID), Convert.ToInt64(num), (long)0, num1, str1, "self", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            Program.StockAllocation_Others(Convert.ToInt64(Program.CompanyID), num, num1, str1, Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "a")
                        {
                            Program.StockAllocationForAdditionalOption(Convert.ToInt64(Program.CompanyID), num, num1, str1, "additional option", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID, Convert.ToInt64(str), num4);
                        }
                        else if (row1["DrawStockFrom"].ToString().ToLower() == "m")
                        {
                            foreach (DataRow dataRow1 in Program.OtherMultipleProductDetails_Select(num, num1, true).Rows)
                            {
                                Program.StockAllocationProcess(Convert.ToInt64(Program.CompanyID), Convert.ToInt64(dataRow1["KitItemID"].ToString()), num, num1, str1, "multiple", Convert.ToBoolean(str2), num3, "Job", num2, StoreUserID);
                            }
                        }
                    }
                }
            }
        }

        public static string return_regional_datetimeformat(string strDate, int companyID)
        {
            string _str;
            try
            {
                DataTable dataTable = new DataTable();
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("DMC_Orderimportprocesses_regional_datetimeformat");
                database.AddInParameter(storedProcCommand, "@datevalue", DbType.String, strDate);
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                    _str = dataTable.Rows[0]["DateFormat"].ToString();
                }
                
            }
            catch
            {
                _str = strDate;
            }
            return _str;
        }




        public static DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
        {
            DataTable dataTable = new DataTable();
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultipleProductDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public static DataTable ProductStockType_Select(long CompanyID, long PriceCatalogueID)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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

        public static string Return_StockManagementSettings(string Name)
        {
            string empty = string.Empty;
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementSettings_Select");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, Convert.ToInt64(Program.CompanyID));
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count > 0)
            {
                DataTable item = dataSet.Tables[0];
                foreach (DataRow row in item.Rows)
                {
                    foreach (DataColumn column in item.Columns)
                    {
                        if (column.ColumnName.ToString().Trim().ToLower() == Name.ToLower())
                        {
                            empty = row[column.ColumnName].ToString();
                        }
                    }
                }
            }
            return empty;
        }

        public static DataTable Select_MultipleCartItems(string CookieID, string type, long StoreUserID, string strMultipleCartID)
        {
            try
            {
                DataTable dataTable = new DataTable();
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_MultipleCartItems");
                database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
                database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                database.AddInParameter(storedProcCommand, "@MultipleCartID", DbType.String, strMultipleCartID);

                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static DataTable Select_birch_MultipleCartItems(string CookieID, string type, long StoreUserID, string strMultipleCartID)
        {
            try
            {
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_birch_Select_MultipleCartItems");
                database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
                database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                database.AddInParameter(storedProcCommand, "@MultipleCartID", DbType.String, strMultipleCartID);

                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            try
            {
                DataTable dataTable = new DataTable();
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
                Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
                DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_OrderItems");
                database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
                database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static DataSet Select_OrderItems_BeforeOrder(long StoreUserID, string MultipleCartID)
        {
            try
            {
                //string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();//kr
                string str = Program.strConnectionString;
                SqlConnection sqlConnection = new SqlConnection(str);
                sqlConnection.Open();
                DataSet dataSet = new DataSet();
                SqlCommand sqlCommand = new SqlCommand("WS_B2B_Select_OrderItems_BeforeOrder", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
                sqlCommand.Parameters.AddWithValue("@MultipleCartID", MultipleCartID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
                sqlConnection.Close();
                return dataSet;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static string SpecialDecode(string OriginalString)
        {
            OriginalString = OriginalString.Replace("%27", "'");
            OriginalString = OriginalString.Replace("%22", "\"");
            return OriginalString;
        }

        public static string SpecialEncode(string OriginalString)
        {
            OriginalString = OriginalString.Replace("'", "%27");
            OriginalString = OriginalString.Replace("\"", "%22");
            return OriginalString;
        }

        public static void StockAllocation(long PriceCatalogueID, long PricecatalogueStockID, int AllocatedQty, long CreatedBy)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
            database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public static string StockAllocation_Others(long CompanyID, long PriceCatalogueID, int MaxKitAvailable, string MetohdType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
        {
            string empty = string.Empty;
            long num = (long)0;
            int num1 = 0;
            empty = "No Stock Available";
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FinalKitStockDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NumberOfKit", DbType.Int32, MaxKitAvailable);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count > 0)
            {
                DataTable item = dataSet.Tables[0];
                if (item.Rows.Count <= 0)
                {
                    empty = "No Stock Available";
                }
                else
                {
                    foreach (DataRow row in item.Rows)
                    {
                        num = Convert.ToInt64(row["KitItemID"].ToString());
                        num1 = Convert.ToInt32(row["TotalRequiredQtyPerKit"].ToString());
                        empty = Program.StockAllocationProcess(CompanyID, num, PriceCatalogueID, num1, MetohdType, "others", IsPickStockFromOneLocation, ModuleID, ModuleName, Price, CreatedBy);
                        if ((empty == null ? false : empty != ""))
                        {
                            empty = string.Concat(empty, ",");
                        }
                    }
                    if ((empty.Contains("Stock allocated with back order successfully") ? true : empty.Contains("Stock allocated successfully")))
                    {
                        string str = string.Empty;
                        bool flag = false;
                        if (empty.Contains("Stock allocated with back order successfully"))
                        {
                            flag = true;
                            str = string.Concat("Stock allocated with backorder for Job #", ModuleID);
                        }
                        else if (empty.Contains("Stock allocated successfully"))
                        {
                            flag = false;
                            str = string.Concat("Stock allocated for Job #", ModuleID);
                        }
                        long num2 = Program.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, PriceCatalogueID, ModuleID, ModuleName, "others", (long)0, MaxKitAvailable, 0, "Allocated", Price, CreatedBy, flag);
                        Program.KitStockAllocationOrReduction(PriceCatalogueID, MaxKitAvailable, 'a', CreatedBy);
                        Program.StockAllocationManagementHistory_Save(num2, PriceCatalogueID, "Allocated", str, MaxKitAvailable, 0, 0, 0, CreatedBy, (long)0);
                    }
                }
            }
            return empty;
        }

        public static void StockAllocationAddOpt(long PriceCatalogueID, long PricecatalogueStockAdditionalId, int AllocatedQty, long CreatedBy)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Allocation_AdditionalOption");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@PricecatalogueStockAdditionalId", DbType.Int64, PricecatalogueStockAdditionalId);
            database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, AllocatedQty);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public static string StockAllocationForAdditionalOption(long CompanyID, long PriceCatalogueID, int Quantity, string MetohdType, string ProcessType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy, long OrderID, long OrderItemID)
        {
            string str;
            string str1;
            string str2;
            string str3;
            long num;
            string str4;
            string str5;
            long num1;
            string empty = string.Empty;
            string empty1 = string.Empty;
            int quantity = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            bool flag = false;
            string empty2 = string.Empty;
            empty = "No Stock Available";
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_StockAdditionalOptionsDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
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
                    str = dataRow["webothercostName"].ToString();
                    str1 = dataRow["Label"].ToString();
                    str2 = dataRow["webothercostid"].ToString();
                    str3 = dataRow["ChoiceID"].ToString();
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        if ((str != row1["OptionName"].ToString() ? false : str3 == row1["choiceid"].ToString()))
                        {
                            empty2 = (Convert.ToInt32(row1["AvailableStock"].ToString()) < Quantity ? string.Concat(empty2, "true,") : string.Concat(empty2, "false,"));
                        }
                    }
                }
                foreach (DataRow dataRow1 in item1.Rows)
                {
                    quantity = Quantity;
                    if (empty2.Contains("false"))
                    {
                        foreach (DataRow row2 in item.Rows)
                        {
                            num = Convert.ToInt64(row2["PricecatalogueStockAdditionalId"].ToString());
                            num5 = Convert.ToInt32(row2["OpeningStock"].ToString());
                            num4 = Convert.ToInt32(row2["AllocatedStock"].ToString());
                            num3 = Convert.ToInt32(row2["AvailableStock"].ToString());
                            str2 = row2["webothercostid"].ToString();
                            str4 = row2["webothercostName"].ToString();
                            str5 = row2["Label"].ToString();
                            str3 = row2["ChoiceID"].ToString();
                            if (quantity != 0)
                            {
                                if ((!(dataRow1["webothercostName"].ToString() == str4) || !(dataRow1["ChoiceID"].ToString() == str3) ? false : dataRow1["webothercostid"].ToString() == str2))
                                {
                                    if (quantity > num3)
                                    {
                                        num2 = num3;
                                        quantity -= num2;
                                        num3 = 0;
                                    }
                                    else
                                    {
                                        num2 = quantity;
                                        num3 -= num2;
                                        quantity = 0;
                                    }
                                    num4 += num2;
                                    empty1 = string.Concat("Additional Options Stock allocated for Job #", ModuleID);
                                    if (num2 != 0)
                                    {
                                        num1 = Program.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, ProcessType, num, num2, 0, "Allocated", Price, CreatedBy, false);
                                        Program.StockAllocationAddOpt(PriceCatalogueID, num, num2, CreatedBy);
                                        Program.StockAllocationManagementHistory_Save(num1, PriceCatalogueID, "Allocated", empty1, num2, num5, num4, num3, CreatedBy, num);
                                    }
                                }
                            }
                        }
                        empty = "Stock allocated successfully";
                    }
                    else if (!flag)
                    {
                        empty = "Back order not available for this stock";
                    }
                    else
                    {
                        foreach (DataRow dataRow2 in dataTable1.Rows)
                        {
                            str = dataRow1["webothercostName"].ToString();
                            str1 = dataRow1["Label"].ToString();
                            str2 = dataRow1["webothercostid"].ToString();
                            str3 = dataRow1["ChoiceID"].ToString();
                            if ((str != dataRow2["OptionName"].ToString() ? false : str3 == dataRow2["choiceid"].ToString()))
                            {
                                num7 = Convert.ToInt32(dataRow2["AvailableStock"].ToString());
                            }
                        }
                        num6 = quantity - num7;
                        foreach (DataRow row3 in item.Rows)
                        {
                            num = Convert.ToInt64(row3["PricecatalogueStockAdditionalId"].ToString());
                            num5 = Convert.ToInt32(row3["OpeningStock"].ToString());
                            num4 = Convert.ToInt32(row3["AllocatedStock"].ToString());
                            num3 = Convert.ToInt32(row3["AvailableStock"].ToString());
                            str2 = row3["webothercostid"].ToString();
                            str4 = row3["webothercostName"].ToString();
                            str5 = row3["Label"].ToString();
                            if (quantity != 0)
                            {
                                if ((!(dataRow1["webothercostName"].ToString() == str4) || !(dataRow1["Label"].ToString() == str5) ? false : dataRow1["webothercostid"].ToString() == str2))
                                {
                                    if (quantity > num3)
                                    {
                                        num2 = num3;
                                        quantity -= num2;
                                        num3 = 0;
                                    }
                                    else
                                    {
                                        num2 = quantity;
                                        num3 -= num2;
                                        quantity = 0;
                                    }
                                    num4 += num2;
                                    empty1 = string.Concat("Stock allocated with backorder for Job #", ModuleID);
                                    if (num6 == quantity)
                                    {
                                        num2 += num6;
                                        num4 += num6;
                                        num3 = num5 - num4;
                                        quantity = 0;
                                    }
                                    if (num2 != 0)
                                    {
                                        num1 = Program.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, (long)0, ModuleID, ModuleName, ProcessType, num, num2, 0, "Allocated", Price, CreatedBy, false);
                                        Program.StockAllocationAddOpt(PriceCatalogueID, num, num2, CreatedBy);
                                        Program.StockAllocationManagementHistory_Save(num1, PriceCatalogueID, "Allocated", empty1, num2, num5, num4, num3, CreatedBy, num);
                                    }
                                }
                            }
                        }
                        empty = "Stock allocated with backorder successfully";
                    }
                }
            }
            return empty;
        }

        public static void StockAllocationManagementHistory_Save(long TransactionID, long PriceCatalogueID, string ActionType, string Notes, int Quantity, int StockInHand, int AllocatedStock, int AvailableStock, long CreatedBy, long PricecatalogueStockID)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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

        public static string StockAllocationProcess(long CompanyID, long PriceCatalogueID, long KitID, int Quantity, string MetohdType, string ProcessType, bool IsPickStockFromOneLocation, long ModuleID, string ModuleName, decimal Price, long CreatedBy)
        {
            string str;
            string[] strArrays;
            long num;
            string empty = string.Empty;
            string empty1 = string.Empty;
            int quantity = Quantity;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            empty = "No stock available";
            if ((ProcessType.ToLower() == "multiple" ? false : KitID == (long)0))
            {
                KitID = Program.GetParentIDOfOtherMultipleProduct(PriceCatalogueID);
            }
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, MetohdType);
            database.AddInParameter(storedProcCommand, "@IsPickStockFromOneLocation", DbType.Boolean, IsPickStockFromOneLocation);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count > 0)
            {
                DataTable item = dataSet.Tables[0];
                DataTable dataTable = dataSet.Tables[1];
                Queue queues = new Queue();
                foreach (DataRow row in item.Rows)
                {
                    queues.Enqueue(string.Concat(new string[] { row["PricecatalogueStockID"].ToString(), "~", row["AvailableStock"].ToString(), "~", row["AllocatedStock"].ToString(), "~", row["OpeningStock"].ToString() }));
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (Convert.ToInt32(dataRow["AvailableQuantity"]) < Quantity)
                    {
                        bool flag = false;
                        if ((ProcessType.ToLower() == "others" ? true : ProcessType.ToLower() == "multiple"))
                        {
                            DataSet dataSet1 = new DataSet();
                            DbCommand dbCommand = database.GetStoredProcCommand("PC_CheckKitBackorder");
                            database.AddInParameter(dbCommand, "@PriceCatalogueID", DbType.Int64, KitID);
                            dataSet1 = database.ExecuteDataSet(dbCommand);
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
                            empty = "Back order not available for this stock";
                        }
                        else
                        {
                            num6 = Convert.ToInt32(dataRow["AvailableQuantity"]);
                            num5 = quantity - num6;
                            if (queues.Count > 0)
                            {
                                while (quantity != 0)
                                {
                                    if (queues.Count > 0)
                                    {
                                        str = queues.Dequeue().ToString();
                                        strArrays = str.Split(new char[] { '~' });
                                        num2 = Convert.ToInt32(strArrays[1].ToString());
                                        num3 = Convert.ToInt32(strArrays[2].ToString());
                                        num4 = Convert.ToInt32(strArrays[3].ToString());
                                        if (quantity > num2)
                                        {
                                            num1 = num2;
                                            quantity -= num1;
                                            num2 = 0;
                                        }
                                        else
                                        {
                                            num1 = quantity;
                                            num2 -= num1;
                                            quantity = 0;
                                        }
                                        num3 += num1;
                                        empty1 = string.Concat("Stock allocated with backorder for Job #", ModuleID);
                                        if (num5 == quantity)
                                        {
                                            num1 += num5;
                                            num3 += num5;
                                            num2 = num4 - num3;
                                            quantity = 0;
                                        }
                                        if (num1 != 0)
                                        {
                                            num = Program.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, ProcessType, Convert.ToInt64(strArrays[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, true);
                                            Program.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays[0].ToString()), num1, CreatedBy);
                                            Program.StockAllocationManagementHistory_Save(num, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, Convert.ToInt64(strArrays[0].ToString()));
                                            Program.UpdateKitProduct_StockLevels(PriceCatalogueID, Quantity, "allocated", CreatedBy);
                                        }
                                    }
                                }
                                empty = "Stock allocated with back order successfully";
                            }
                        }
                    }
                    else if (queues.Count > 0)
                    {
                        while (quantity != 0)
                        {
                            if (queues.Count > 0)
                            {
                                str = queues.Dequeue().ToString();
                                strArrays = str.Split(new char[] { '~' });
                                num2 = Convert.ToInt32(strArrays[1].ToString());
                                num3 = Convert.ToInt32(strArrays[2].ToString());
                                num4 = Convert.ToInt32(strArrays[3].ToString());
                                if (quantity > num2)
                                {
                                    num1 = num2;
                                    quantity -= num1;
                                    num2 = 0;
                                }
                                else
                                {
                                    num1 = quantity;
                                    num2 -= num1;
                                    quantity = 0;
                                }
                                num3 += num1;
                                empty1 = string.Concat("Stock allocated for Job #", ModuleID);
                                if (num1 != 0)
                                {
                                    num = Program.StockManagementTransaction_Save((long)0, CompanyID, PriceCatalogueID, KitID, ModuleID, ModuleName, ProcessType, Convert.ToInt64(strArrays[0].ToString()), num1, 0, "Allocated", Price, CreatedBy, false);
                                    Program.StockAllocation(PriceCatalogueID, Convert.ToInt64(strArrays[0].ToString()), num1, CreatedBy);
                                    Program.StockAllocationManagementHistory_Save(num, PriceCatalogueID, "Allocated", empty1, num1, num4, num3, num2, CreatedBy, Convert.ToInt64(strArrays[0].ToString()));
                                    Program.UpdateKitProduct_StockLevels(PriceCatalogueID, Quantity, "allocated", CreatedBy);
                                }
                            }
                        }
                        empty = "Stock allocated successfully";
                    }
                }
            }
            return empty;
        }

        public static void StockCancellation(long PriceCatalogueID, long PricecatalogueStockID, int TotalCancelQty, int AllocatedQty, int ReleasedQty, long CreatedBy, string DawStockFrom)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Cancellation");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, PricecatalogueStockID);
            database.AddInParameter(storedProcCommand, "@TotalCancelQty", DbType.Int32, TotalCancelQty);
            database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, AllocatedQty);
            database.AddInParameter(storedProcCommand, "@ReleasedQty", DbType.Int32, ReleasedQty);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DawStockFrom);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public static void StockCancellationHistory_Save(long TransactionID, long PriceCatalogueID, long PricecatalogueStockID, int TotalCancelQty, int AllocatedQty, int ReleasedQty, string Notes, long CreatedBy, string ActionType)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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

        public static string StockCancellationProcess(long CompanyID, long PriceCatalogueID, long KitID, string DawStockFrom, long ModuleID, string ModuleName, long CreatedBy, string CancelType)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            long num4 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            str = "No Stock Availables";
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockCancelDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DawStockFrom);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@CancelType", DbType.String, CancelType);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables.Count <= 0)
            {
                str = "Failure";
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
                    empty = string.Concat("Stock cancelled for job#", ModuleID);
                    Program.StockCancelTransaction_Save(num3, PriceCatalogueID, ModuleID, ModuleName, 0, 0, "Cancelled", CreatedBy);
                    Program.StockCancellation(PriceCatalogueID, num4, num, num1, num2, CreatedBy, DawStockFrom);
                    Program.StockCancellationHistory_Save(num3, PriceCatalogueID, num4, num, num1, num2, empty, CreatedBy, "Cancelled");
                    Program.UpdateKitProduct_StockLevels(PriceCatalogueID, num, "Cancelled", CreatedBy);
                }
                str = "Success";
            }
            return str;
        }

        public static void StockCancelTransaction_Save(long TransactionID, long PriceCatalogueID, long ModuleID, string ModuleName, int AllocatedQty, int ReleasedQty, string ActionType, long CreatedBy)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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

        public static long StockManagementTransaction_Save(long TransactionID, long CompanyID, long PriceCatalogueID, long KITTransactionID, long ModuleID, string ModuleName, string DrawStockFrom, long PricecatalogueStockID, int AllocatedQty, int ReleasedQty, string ActionType, decimal Price, long CreatedBy, bool IsbackOrder)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
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

        public static DataTable StockProductRerunDetails_Select(long PriceCatalogueID, long KitID, long CompanyID, string DawStockFrom, long ModuleID)
        {
            DataTable dataTable = new DataTable();
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementRerunDetails_select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitID", DbType.Int64, KitID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DawStockFrom", DbType.String, DawStockFrom);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public static void Update_ContactID_ForB2B(long StoreUserID, long DefaultBillingID, long DefaultShippingID, int ContactID)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ContactID_ForB2B");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@DefaultBillingID", DbType.Int64, DefaultBillingID);
            database.AddInParameter(storedProcCommand, "@DefaultShippingID", DbType.Int64, DefaultShippingID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public static void UpdateKitProduct_StockLevels(long PricecatalogueID, int Quantity, string Type, long CreatedBy)
        {
            //Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            Database database = CustomDatabaseFactory.CreateDatabase(Program.strConnectionString);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateKitProduct_Stocklevels");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }
    }
}