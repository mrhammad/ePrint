using MathFunctions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

namespace ePrint.WebStore
{
    [ScriptService]
    [WebService(Namespace = "http://www.eprintsoftware.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class StoreAutoFill : System.Web.Services.WebService
    {

        public string StyleSheetPath = string.Empty;

        public languageClass objLanguage = new languageClass();

        public StoreAutoFill()
        {
        }

        [WebMethod]
        public virtual DataTable AdditionalOptions_Value(long CartItemID, int SortOrderNo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_AdditionalItems_SortOrderNo");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int16, SortOrderNo);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        [WebMethod]
        public string AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, string IsBackOrder, string WebOtherCostID, string ChoiceID)
        {
            if (WebOtherCostID == "" && WebOtherCostID == null)
            {
                WebOtherCostID = "0";
            }
            if (ChoiceID == "" && ChoiceID == null)
            {
                ChoiceID = "0";
            }
            string empty = string.Empty;
            DataTable dataTable = ProductBasePage.AddOptionsProductDetails_Select(PriceCatalogueID, Quantity, Convert.ToBoolean(IsBackOrder), Convert.ToInt32(WebOtherCostID), Convert.ToInt32(ChoiceID));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["AvailableStock"].ToString();
            }
            return empty;
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
        public string CalculateFormulaCost_ForMultipleChoice(string FormulaVals, decimal Markup, string ID)
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

        [WebMethod]
        public bool Campaign_Duplicate_Check(long ManageID, long AccountID, long CompanyID, string EventName)
        {
            bool flag = false;
            flag = (LoginBasePage.Campaign_Duplicate_Check(ManageID, AccountID, CompanyID, EventName) != 0 ? false : true);
            return flag;
        }

        [WebMethod(EnableSession = true)]
        public void CatgoryNotReqApproval(string Result)
        {
            base.Session["CatgoryNotReqApproval"] = Result;
        }

        [WebMethod]
        public int Check_EmailID_Duplicacy(int StoreUserID, string val, int AccountID)
        {
            string str = val;
            int num = LoginBasePage.CheckEmailID_Duplicacy(Convert.ToInt64(StoreUserID), str, (long)AccountID);
            return num;
        }

        [WebMethod]
        public virtual int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
        {
            return LoginBasePage.Check_EmailID_Duplicacy_for_Account(EmailID, Client_ID, Contact_ID);
        }

        [WebMethod]
        public int CheckDept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
        {
            return LoginBasePage.Check_Dept_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
        }

        [WebMethod]
        public int Delete_Address(int StoreUserID, long AddressID)
        {
            OrderBasePage.Delete_BillingShippingAddress(Convert.ToInt64(StoreUserID), Convert.ToInt64(AddressID));
            return 1;
        }

        [WebMethod]
        public int Delete_CartItem(string SessionID, int StoreUserID, int CartItemID, long CartID)
        {
            CartBasePage.Delete_CartItem_B2B(Convert.ToInt64(CartItemID), CartID);
            return 1;
        }

        [WebMethod(EnableSession = true)]
        public void DepartmentNotReqApproval(string Result)
        {
            base.Session["DepartmentNotReqApproval"] = Result;
        }

        [WebMethod]
        public long ExistanceOfEmail(string Email, long AccountID)
        {
            return LoginBasePage.ExistanceOfEmail(Email, AccountID);
        }

        [WebMethod]
        public long ExistanceOfPassword(long StoreUserID, string Password)
        {
            return LoginBasePage.ExistanceOfPassword(StoreUserID, Password);
        }

        [WebMethod]
        public string Get_Address(long StoreUserID, long AddressID)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShippingAddress_OnAddressID(StoreUserID, AddressID).Rows)
            {
                string[] str = new string[] { row["FirstName"].ToString(), "µ", row["LastName"].ToString(), "µ", row["Phone"].ToString(), "µ", row["Fax"].ToString(), "µ", row["Address1"].ToString(), "µ", row["Address2"].ToString(), "µ", row["Address3"].ToString(), "µ", row["Address4"].ToString(), "µ", row["Address5"].ToString(), "µ", row["CountryID"].ToString(), "µ", row["AddressLabel"].ToString(), "µ", row["AddressID"].ToString(), "µ" };
                empty = string.Concat(str);
            }
            return empty;
        }

        [WebMethod]
        public string Get_RegionalSetting_Country(int CompanyID)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.settings_companyprofile_select(CompanyID).Rows)
            {
                empty = row["CountryID"].ToString();
            }
            return empty;
        }

        [WebMethod]
        public string GetGroupRunUnitPrice(long ProductID, decimal TotalQty, string CartItemIDs, string CouponCode, string AccountID)
        {
            string empty = string.Empty;
            string[] strArrays = CartItemIDs.ToString().Split(new char[] { '±' });
            if ((int)strArrays.Length != 1)
            {
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    DataTable groupRunUnitPrice = CartBasePage.GetGroupRunUnitPrice(ProductID, TotalQty, Convert.ToInt64(strArrays[i].ToString()), CouponCode, Convert.ToInt64(AccountID));
                    foreach (DataRow row in groupRunUnitPrice.Rows)
                    {
                        string[] str = new string[] { row["UnitPrice"].ToString(), "»", row["ProductID"].ToString(), "»", row["CartItemID"].ToString(), "»", row["CartTotalPrice"].ToString(), "»", row["CartTax"].ToString(), "»", row["CouponCodeApplyed"].ToString() };
                        empty = string.Concat(str);
                    }
                }
            }
            else
            {
                DataTable dataTable = CartBasePage.GetGroupRunUnitPrice(ProductID, TotalQty, Convert.ToInt64(strArrays[0].ToString()), CouponCode, Convert.ToInt64(AccountID));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string[] str1 = new string[] { dataRow["UnitPrice"].ToString(), "»", dataRow["ProductID"].ToString(), "»", dataRow["CartItemID"].ToString(), "»", dataRow["CartTotalPrice"].ToString(), "»", dataRow["CartTax"].ToString(), "»", dataRow["CouponCodeApplyed"].ToString() };
                    empty = string.Concat(str1);
                }
            }
            return empty;
        }

        [WebMethod]
        public string GetMatrixValue(int OthercostID, int Qtytofind, int ID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataSet dataSet = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(OthercostID));
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
                DataTable dataTable = ProductBasePage.Select_OtherCostMatrix_Value((long)OthercostID, Convert.ToInt32(empty2));
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
        public string GetStoreUserOnDeptID(long DeptID)
        {
            return ProductBasePage.GetStoreUserOnDeptID(DeptID);
        }

        [WebMethod]
        public string OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, string IsBackOrder)
        {
            string empty = string.Empty;
            DataTable dataTable = OrderBasePage.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, Convert.ToBoolean(IsBackOrder));
            foreach (DataRow row in dataTable.Rows)
            {
                string[] str = new string[] { row["OtherMultipleID"].ToString(), "~", row["KitItemID"].ToString(), "~", row["TotalQuantity"].ToString(), "~", row["AllocatedQuantity"].ToString(), "~", row["AvailableQuantity"].ToString() };
                empty = string.Concat(str);
            }
            return empty;
        }

        [WebMethod]
        public string OtherProductDetails_Select(long PriceCatalogueID, int Quantity)
        {
            string empty = string.Empty;
            return (new BaseClass()).Check_MaxKit_Availability(PriceCatalogueID, Quantity).ToString();
        }

        [WebMethod]
        public bool Product_Exists_Check(int ProductID)
        {
            bool flag = false;
            flag = (CartBasePage.Product_Exists_Check(ProductID) != (long)0 ? false : true);
            return flag;
        }

        [WebMethod]
        public string QuickItemAdd(long PriceCatalogueID, int Quantity, decimal QtyPriceWithoutTax, decimal CartTax, int StoreUserID, decimal TaxRate, int TaxID, decimal UnitPrice, decimal MainPriceExcMarkup, string ProductName, decimal Height, decimal Width, long ChangedProductID, int MainProductId)
        {
            string empty = string.Empty;
            long num = (long)0;
            num = CartBasePage.Insert_into_Cart("", (long)StoreUserID, QtyPriceWithoutTax, CartTax, new decimal(0));
            if (num != (long)0)
            {
                //CartBasePage.Insert_into_CartItem(num, ChangedProductID, "", (long)Quantity, UnitPrice, "", "", "", QtyPriceWithoutTax, TaxRate, MainPriceExcMarkup, (long)TaxID, "C", "", "", "", (long)0, (long)0, 0, (long)0, Height, Width, (long)0, MainProductId);
            }
            DataTable dataTable = new DataTable();
            dataTable = CartBasePage.Get_CartItemCount(Convert.ToInt64(StoreUserID));
            if (dataTable.Rows.Count > 0)
            {
                empty = (dataTable.Rows[0]["Count"].ToString() != "0" ? string.Concat(dataTable.Rows[0]["Count"].ToString(), "  Items in cart") : "No Item In cart");
            }
            string[] str = new string[] { empty, "µ", Convert.ToString(PriceCatalogueID), "µ", ProductName };
            return string.Concat(str);
        }

        [WebMethod(EnableSession = true)]
        public void StoreBehalfTypeSession(string BehalfType)
        {
            base.Session["OrderBehalfType"] = BehalfType;
        }

        [WebMethod]
        public string ToCalculate_TotalPrice(string Qty, string FromList, string ToList, string CostExcMarkupList, string PriceList, string MarkupList, string SoldinPackof, string MatixType, string Height, string Width, string SimpleMatrix_DDL_details)
        {
            decimal num;
            string[] strArrays = FromList.Split(new char[] { 'µ' });
            string[] strArrays1 = ToList.Split(new char[] { 'µ' });
            string[] strArrays2 = CostExcMarkupList.Split(new char[] { 'µ' });
            PriceList.Split(new char[] { 'µ' });
            string[] strArrays3 = MarkupList.Split(new char[] { 'µ' });
            int num1 = Convert.ToInt32(SoldinPackof);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            string str = "all good";
            string str1 = "all good";
            bool flag = true;
            for (int i = 0; i < (int)strArrays1.Length - 1; i++)
            {
                if (MatixType != "S" && i == (int)strArrays1.Length - 2)
                {
                    num4 = Convert.ToDecimal(strArrays1[i]);
                }
            }
            for (int j = 0; j < (int)strArrays.Length - 1; j++)
            {
                if (MatixType == "P")
                {
                    if (!(Qty != "") || !decimal.TryParse(Qty, out num))
                    {
                        if (!decimal.TryParse(Qty, out num))
                        {
                            str = "Empty the quantity";
                            flag = false;
                        }
                        num5 = new decimal(0);
                        num6 = new decimal(0);
                        num7 = new decimal(0);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            num3 = Convert.ToDecimal(strArrays[j]);
                        }
                        string str2 = strArrays[j + 1];
                        if (str2.Trim() == "")
                        {
                            str2 = "0";
                        }
                        if (Convert.ToDecimal(Qty) <= Convert.ToDecimal(strArrays[j]))
                        {
                            num5 = Convert.ToDecimal(Qty) * Convert.ToDecimal(strArrays2[j]);
                            num7 = Convert.ToDecimal(strArrays3[j]);
                            decimal num8 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                            num6 = num8;
                            break;
                        }
                        else if (Convert.ToDecimal(Qty) >= Convert.ToDecimal(strArrays[j]) && Convert.ToDecimal(Qty) <= Convert.ToDecimal(strArrays1[j]))
                        {
                            num5 = Convert.ToDecimal(Qty) * Convert.ToDecimal(strArrays2[j]);
                            num7 = Convert.ToDecimal(strArrays3[j]);
                            decimal num9 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                            num6 = num9;
                            break;
                        }
                        else if (Convert.ToDecimal(Qty) > Convert.ToDecimal(strArrays1[j]) && Convert.ToDecimal(Qty) < Convert.ToDecimal(str2))
                        {
                            num5 = Convert.ToDecimal(Qty) * Convert.ToDecimal(strArrays2[j]);
                            num7 = Convert.ToDecimal(strArrays3[j]);
                            decimal num10 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                            num6 = num10;
                            break;
                        }
                        else if (Convert.ToDecimal(j) != (Convert.ToDecimal((int)strArrays.Length) - Convert.ToDecimal(2)))
                        {
                            num5 = new decimal(0);
                            num6 = new decimal(0);
                            num7 = new decimal(0);
                        }
                        else
                        {
                            num5 = Convert.ToDecimal(Qty) * Convert.ToDecimal(strArrays2[j]);
                            num7 = Convert.ToDecimal(strArrays3[j]);
                            decimal num11 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                            num6 = num11;
                            break;
                        }
                    }
                }
                else if (MatixType != "G")
                {
                    string[] strArrays4 = SimpleMatrix_DDL_details.Split(new char[] { '\u00A7' });
                    string[] strArrays5 = strArrays4[0].Split(new char[] { '~' });
                    num5 = Convert.ToDecimal(strArrays5[0]);
                    num6 = Convert.ToDecimal(strArrays5[1]);
                    num3 = Convert.ToDecimal(strArrays4[1]);
                    num4 = Convert.ToDecimal(strArrays4[1]);
                }
                else if (!(Qty != "") || !decimal.TryParse(Qty, out num))
                {
                    if (!decimal.TryParse(Qty, out num))
                    {
                        str = "Empty the quantity";
                        flag = false;
                    }
                    num5 = new decimal(0);
                    num6 = new decimal(0);
                    num7 = new decimal(0);
                }
                else if (Height == "" || Width == "")
                {
                    str = "Height or Width is Empty or Zero";
                    flag = false;
                }
                else if (Convert.ToDecimal(Height) == new decimal(0) || Convert.ToDecimal(Width) == new decimal(0))
                {
                    str = "Height or Width is Empty or Zero";
                    flag = false;
                }
                else
                {
                    if (j == 0)
                    {
                        num3 = Convert.ToDecimal(strArrays[j]);
                    }
                    num2 = (ProductBasePage.MeasurementValue((long)Convert.ToInt32(ConnectionClass.CompanyID)) != "In." ? (Convert.ToDecimal(Height) * Convert.ToDecimal(Width)) / new decimal(1000000) : (Convert.ToDecimal(Height) * Convert.ToDecimal(Width)) / new decimal(144));
                    string str3 = strArrays[j + 1];
                    if (str3.Trim() == "")
                    {
                        str3 = "0";
                    }
                    if (num2 <= Convert.ToDecimal(strArrays[j]))
                    {
                        num5 = (num2 * Convert.ToDecimal(Qty)) * Convert.ToDecimal(strArrays2[j]);
                        num7 = Convert.ToDecimal(strArrays3[j]);
                        decimal num12 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                        num6 = num12;
                        break;
                    }
                    else if (num2 >= Convert.ToDecimal(strArrays[j]) && num2 <= Convert.ToDecimal(strArrays1[j]))
                    {
                        num5 = (num2 * Convert.ToDecimal(Qty)) * Convert.ToDecimal(strArrays2[j]);
                        num7 = Convert.ToDecimal(strArrays3[j]);
                        decimal num13 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                        num6 = num13;
                        break;
                    }
                    else if (num2 > Convert.ToDecimal(strArrays1[j]) && num2 < Convert.ToDecimal(str3))
                    {
                        num5 = (num2 * Convert.ToDecimal(Qty)) * Convert.ToDecimal(strArrays2[j]);
                        num7 = Convert.ToDecimal(strArrays3[j]);
                        decimal num14 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                        num6 = num14;
                        break;
                    }
                    else if (j != Convert.ToInt32((int)strArrays.Length) - 2)
                    {
                        num5 = new decimal(0);
                        num6 = new decimal(0);
                        num7 = new decimal(0);
                    }
                    else
                    {
                        num5 = (num2 * Convert.ToDecimal(Qty)) * Convert.ToDecimal(strArrays2[j]);
                        num7 = Convert.ToDecimal(strArrays3[j]);
                        decimal num15 = Convert.ToDecimal(num5) + ((Convert.ToDecimal(num5) / new decimal(100)) * Convert.ToDecimal(strArrays3[j]));
                        num6 = num15;
                        break;
                    }
                }
            }
            if (MatixType == "P" && Qty != "" && decimal.TryParse(Qty, out num))
            {
                if (num3 > Convert.ToDecimal(Qty))
                {
                    str1 = string.Concat("minimum§", num3);
                }
                else if (num4 >= Convert.ToDecimal(Qty))
                {
                    str1 = (Convert.ToInt32(Qty) % num1 == 0 ? "all good" : "multiples");
                }
                else
                {
                    str1 = string.Concat("maximum§", num4);
                }
            }
            if (MatixType == "G" && num2 != new decimal(0))
            {
                if (num3 <= num2)
                {
                    str1 = (num4 >= num2 ? "all good" : string.Concat("maximum§", num4));
                }
                else
                {
                    str1 = string.Concat("minimum§", num3);
                }
            }
            object[] objArray = new object[] { str, "ƒ", num5, "ƒ", num6, "ƒ", num7, "ƒ", str1, "ƒ", flag, "ƒ", num3, "ƒ", num4 };
            return string.Concat(objArray);
        }

        [WebMethod(EnableSession = true)]
        public string Update_CartItems(string Values, string SaveToAdditionalItems, string CartID, string SelfApproval, bool IsOrderedMultiple, string Order_BehalfType, string IsBackOrder_Check)
        {
            bool flag = false;
            bool flag1 = true;
            string str = "";
            if (IsBackOrder_Check == "BackOrder_Check")
            {
                DataSet backOrderStockCheck = CartBasePage.Get_BackOrderStock_Check(CartID);
                DataTable item = backOrderStockCheck.Tables[0];
                DataTable dataTable = backOrderStockCheck.Tables[1];
                DataTable item1 = backOrderStockCheck.Tables[2];
                foreach (DataRow row in backOrderStockCheck.Tables[3].Rows)
                {
                    flag = Convert.ToBoolean(row[0].ToString());
                    if (!flag)
                    {
                        continue;
                    }
                    flag = Convert.ToBoolean(row[0].ToString());
                    flag1 = false;
                    break;
                }
                if (item.Rows.Count > 0 || item1.Rows.Count > 0)
                {
                    flag1 = false;
                    if (item.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in item.Rows)
                        {
                            if (dataRow["itemtitle"] == null)
                            {
                                continue;
                            }
                            if (item.Rows.Count != 1)
                            {
                                str = (str != "" ? string.Concat(str, "♣", dataRow["itemtitle"].ToString()) : dataRow["itemtitle"].ToString());
                            }
                            else
                            {
                                str = dataRow["itemtitle"].ToString();
                            }
                        }
                    }
                    if (item1.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in item1.Rows)
                        {
                            if (item1.Rows.Count != 1)
                            {
                                str = (str != "" ? string.Concat(str, "♣", row1["itemtitle"].ToString()) : row1["itemtitle"].ToString());
                            }
                            else
                            {
                                str = row1["itemtitle"].ToString();
                            }
                        }
                    }
                }
            }
            if (flag1 && !flag)
            {
                base.Session["OrderBehalfType"] = Order_BehalfType;
                if (!IsOrderedMultiple)
                {
                    base.Session["Order_With_Multiple_User"] = "false";
                }
                else
                {
                    base.Session["Order_With_Multiple_User"] = "true";
                }
                base.Session["MultipleCartID"] = "";
                long num = (long)0;
                string empty = string.Empty;
                base.Session["MultipleCartID"] = CartID;
                base.Session["SelfApproval_ItemID"] = SelfApproval;
                string[] strArrays = Values.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '»' });
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            if (strArrays1[j] != "")
                            {
                                string[] strArrays2 = strArrays1[j].ToString().Split(new char[] { '±' });
                                if (strArrays2[0] != "")
                                {
                                    if (strArrays2[0] == "CartItemID")
                                    {
                                        num = Convert.ToInt64(strArrays2[1].ToString());
                                    }
                                    else if (strArrays2[0] == "JobName")
                                    {
                                        empty = strArrays2[1].ToString();
                                    }
                                }
                                CartBasePage.Update_CartItems_JobName(num, empty);
                            }
                        }
                    }
                }
                long num1 = (long)0;
                string empty1 = string.Empty;
                long num2 = (long)0;
                string str1 = string.Empty;
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                long num5 = (long)0;
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                string empty2 = string.Empty;
                int num8 = 0;
                int num9 = 0;
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                if (base.Session["StoreUserID"] != null)
                {
                    num1 = Convert.ToInt64(base.Session["StoreUserID"]);
                    CartBasePage.Cart_AdditionalOptions_Delete(num1);
                }
                string[] strArrays3 = SaveToAdditionalItems.Split(new char[] { 'µ' });
                for (int k = 0; k <= (int)strArrays3.Length - 1; k++)
                {
                    if (strArrays3[k] != "")
                    {
                        string[] strArrays4 = strArrays3[k].ToString().Split(new char[] { '±' });
                        for (int l = 0; l <= (int)strArrays4.Length - 1; l++)
                        {
                            if (strArrays4[l] != "")
                            {
                                string[] strArrays5 = strArrays4[l].Split(new char[] { '»' });
                                if (strArrays5[0] != "")
                                {
                                    if (strArrays5[0] == "StoreUserID")
                                    {
                                        num1 = Convert.ToInt64(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "SessionID")
                                    {
                                        empty1 = strArrays5[1];
                                    }
                                    else if (strArrays5[0] == "OthercostID")
                                    {
                                        num2 = Convert.ToInt64(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "Formula")
                                    {
                                        str1 = strArrays5[1];
                                    }
                                    else if (strArrays5[0] == "MarkUp")
                                    {
                                        num3 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "TotalPrice")
                                    {
                                        num4 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "SelectedID")
                                    {
                                        num5 = Convert.ToInt64(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "SelectedValue")
                                    {
                                        empty2 = strArrays5[1];
                                    }
                                    else if (strArrays5[0] == "SelectedPrice")
                                    {
                                        num7 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "MarkUpValue")
                                    {
                                        num6 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "SortOrderNo")
                                    {
                                        num8 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "CartAdditionalTaxID")
                                    {
                                        num9 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "CartAdditionalTaxPercentage")
                                    {
                                        num10 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (strArrays5[0] == "CartAdditionalTaxValue")
                                    {
                                        num11 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                }
                            }
                        }
                        CartBasePage.Insert_To_CartAdditionalOptions(num1, empty1, num2, str1, num3, num4, num5, empty2, num7, num6, num8, num9, num10, num11);
                    }
                }
            }
            object[] objArray = new object[] { flag1.ToString(), "♠", str, "♠", flag };
            return string.Concat(objArray);
        }

        [WebMethod(EnableSession = true)]
        public void Update_JobName(string Values)
        {
            long num = (long)0;
            string empty = string.Empty;
            string[] strArrays = Values.Split(new char[] { '$' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '±' });
                    num = Convert.ToInt64(strArrays1[0].ToString());
                    CartBasePage.Update_CartItems_JobName(num, strArrays1[1].ToString());
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public string UpdateAdditionalValues(long ProductID, decimal TotalQty, string CartItemIDs)
        {
            string empty = string.Empty;
            string[] strArrays = CartItemIDs.ToString().Split(new char[] { '±' });
            long num = (long)0;
            if ((int)strArrays.Length == 1)
            {
                num = Convert.ToInt64(strArrays[0].ToString());
                foreach (DataRow row in CartBasePage.Select_CartAdditionalItems(num).Rows)
                {
                    string str = string.Empty;
                    double num1 = 0;
                    double num2 = 0;
                    long num3 = (long)0;
                    double num4 = 0;
                    long num5 = (long)0;
                    ProductBasePage.MeasurementValue((long)Convert.ToInt32(base.Session["CompanyID"]));
                    if (row["MainCalculationType"].ToString().ToLower() == "c")
                    {
                        DataTable dataTable = CartBasePage.Update_Select_OtherCostAdditional_Onoptionid(num, Convert.ToInt64(row["OptionID"]), ProductID, TotalQty, Convert.ToInt64(row["CartAdditionalItemID"]));
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            str = dataRow["OrgFormula"].ToString();
                            num1 = Convert.ToDouble(dataRow["GpRunNewBasePrice"]);
                            num2 = Convert.ToDouble(dataRow["Quantity"]);
                            num3 = Convert.ToInt64(dataRow["CartAdditionalItemID"]);
                            num5 = Convert.ToInt64(dataRow["CartItemID"]);
                            decimal num6 = new decimal(0);
                            decimal num7 = new decimal(0);
                            num6 = Convert.ToDecimal(dataRow["Height"]);
                            num7 = Convert.ToDecimal(dataRow["Width"]);
                            decimal num8 = num6 * num7;
                            if (str.Contains("[$ProductBasePrice$]") || str.Contains("<quantity>") || str.ToLower().Contains("[$orderedwidth$]") || str.ToLower().Contains("[$orderedheight$]") || str.ToLower().Contains("[$orderedarea$]") || str.ToLower().Contains("[$multipleof$]"))
                            {
                                str = str.Replace("[$ProductBasePrice$]", Convert.ToString(num1)).Replace("<quantity>", Convert.ToString(num2)).Replace("[$OrderedHeight$]", Convert.ToString(num6)).Replace("[$OrderedWidth$]", Convert.ToString(num7)).Replace("[$OrderedArea$]", Convert.ToString(num8)).Replace("[$MultipleOf$]", Convert.ToString(1));
                                decimal num9 = (new MathParser()).Calculate(str);
                                num4 = double.Parse(num9.ToString()) + double.Parse(dataRow["MarkUpvalue"].ToString());
                                string str1 = "[$ProductBasePrice$]/<quantity>+((([$ProductBasePrice$]/<quantity>)*Markup)/100)";
                                str1 = str1.Replace("[$ProductBasePrice$]", Convert.ToString(num1)).Replace("<quantity>", Convert.ToString(num2)).Replace("Markup", dataRow["Markup"].ToString());
                                CartBasePage.update_singlequestion_additionaloptions(num5, num3, str1, num4);
                            }
                            object obj = empty;
                            object[] objArray = new object[] { obj, num5, "»", dataRow["OptionID"].ToString(), "»", num4, "»", num3, "»", dataRow["UnitPrice"].ToString(), "»", dataRow["ProductID"].ToString(), "»", dataRow["CartItemID"].ToString(), "»", dataRow["CartTotalPrice"].ToString(), "»", dataRow["CartTax"].ToString(), "»", dataRow["CouponCodeApplyed"].ToString(), "∅" };
                            empty = string.Concat(objArray);
                        }
                    }
                    if (row["MainCalculationType"].ToString().ToLower() != "q")
                    {
                        if (row["MainCalculationType"].ToString().ToLower() != "m")
                        {
                            continue;
                        }
                        DataTable dataTable1 = CartBasePage.Update_Select_OtherCostAdditional_Onoptionid(num, Convert.ToInt64(row["OptionID"]), ProductID, TotalQty, Convert.ToInt64(row["CartAdditionalItemID"]));
                        foreach (DataRow row1 in dataTable1.Rows)
                        {
                            object obj1 = empty;
                            object[] objArray1 = new object[] { obj1, Convert.ToInt64(row1["CartItemID"]), "»", row1["OptionID"].ToString(), "»", num4, "»", Convert.ToInt64(row1["CartAdditionalItemID"]), "»", row1["UnitPrice"].ToString(), "»", row1["ProductID"].ToString(), "»", row1["CartItemID"].ToString(), "»", row1["CartTotalPrice"].ToString(), "»", row1["CartTax"].ToString(), "»", row1["CouponCodeApplyed"].ToString(), "∅" };
                            empty = string.Concat(objArray1);
                        }
                    }
                    else
                    {
                        str = string.Empty;
                        num1 = 0;
                        num2 = 0;
                        num3 = (long)0;
                        num4 = 0;
                        num5 = (long)0;
                        DataTable dataTable2 = CartBasePage.Update_Select_OtherCostAdditional_Onoptionid(num, Convert.ToInt64(row["OptionID"]), ProductID, TotalQty, Convert.ToInt64(row["CartAdditionalItemID"]));
                        foreach (DataRow dataRow1 in dataTable2.Rows)
                        {
                            str = dataRow1["OrgFormula"].ToString();
                            num1 = Convert.ToDouble(dataRow1["GpRunNewBasePrice"]);
                            num2 = Convert.ToDouble(dataRow1["SelectedValue"]);
                            num3 = Convert.ToInt64(dataRow1["CartAdditionalItemID"]);
                            num5 = Convert.ToInt64(dataRow1["CartItemID"]);
                            decimal num10 = new decimal(0);
                            decimal num11 = new decimal(0);
                            num10 = Convert.ToDecimal(dataRow1["Height"]);
                            num11 = Convert.ToDecimal(dataRow1["Width"]);
                            decimal num12 = num10 * num11;
                            if (str.Contains("[$ProductBasePrice$]") || str.Contains("<quantity>") || str.ToLower().Contains("[$orderedwidth$]") || str.ToLower().Contains("[$orderedheight$]") || str.ToLower().Contains("[$orderedarea$]") || str.ToLower().Contains("[$multipleof$]"))
                            {
                                str = str.Replace("[$ProductBasePrice$]", Convert.ToString(num1)).Replace("<question>", Convert.ToString(num2)).Replace("[$OrderedHeight$]", Convert.ToString(num10)).Replace("[$OrderedWidth$]", Convert.ToString(num11)).Replace("[$OrderedArea$]", Convert.ToString(num12)).Replace("[$MultipleOf$]", Convert.ToString(1));
                                decimal num13 = (new MathParser()).Calculate(str);
                                num4 = double.Parse(num13.ToString());
                                CartBasePage.update_singlequestion_additionaloptions(num5, num3, str, num4);
                            }
                            object obj2 = empty;
                            object[] str2 = new object[] { obj2, num5, "»", dataRow1["webothercostid"].ToString(), "»", num4, "»", num3, "»", dataRow1["UnitPrice"].ToString(), "»", dataRow1["ProductID"].ToString(), "»", dataRow1["CartItemID"].ToString(), "»", dataRow1["CartTotalPrice"].ToString(), "»", dataRow1["CartTax"].ToString(), "»", dataRow1["CouponCodeApplyed"].ToString(), "∅" };
                            empty = string.Concat(str2);
                        }
                    }
                }
            }
            return empty;
        }
    }
}
