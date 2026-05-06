using MathFunctions;
using nmsCommon;
using nmsConnection;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

//namespace ePrint.MyPublicStore
//{
    /// <summary>
    /// Summary description for AutoFill
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class AutoFill : WebService
    {
        private commonclass comm = new commonclass();

        public AutoFill()
        {
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
        public int Check_EmailID_Duplicacy(int StoreUserID, string val, int AccountID)
        {
            string str = val;
            int num = LoginBasePage.CheckEmailID_Duplicacy(Convert.ToInt64(StoreUserID), str, (long)AccountID);
            return num;
        }

        [WebMethod]
        public int Delete_Address(int StoreUserID, long AddressID)
        {
            OrderBasePage.Delete_BillingShippingAddress(Convert.ToInt64(StoreUserID), Convert.ToInt64(AddressID));
            return 1;
        }

        [WebMethod]
        public int Delete_CartItem(string SessionID, int StoreUserID, int CartID, long CartItemID)
        {
            CartBasePage.Delete_CartItem(SessionID, Convert.ToInt64(StoreUserID), Convert.ToInt64(CartID), Convert.ToInt64(CartItemID));
            return 1;
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
        public string GetGroupRunUnitPrice(long ProductID, decimal TotalQty, string CartItemIDs, string CouponCode)
        {
            string empty = string.Empty;
            string[] strArrays = CartItemIDs.ToString().Split(new char[] { '±' });
            if ((int)strArrays.Length != 1)
            {
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    DataTable groupRunUintPrice = CartBasePage.GetGroupRunUintPrice(ProductID, TotalQty, Convert.ToInt64(strArrays[i].ToString()), CouponCode);
                    foreach (DataRow row in groupRunUintPrice.Rows)
                    {
                        string[] str = new string[] { row["UnitPrice"].ToString(), "»", row["ProductID"].ToString(), "»", row["CartItemID"].ToString(), "»", row["CartTotalPrice"].ToString(), "»", row["CouponCodeApplyed"].ToString() };
                        empty = string.Concat(str);
                    }
                }
            }
            else
            {
                DataTable dataTable = CartBasePage.GetGroupRunUintPrice(ProductID, TotalQty, Convert.ToInt64(strArrays[0].ToString()), CouponCode);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string[] str1 = new string[] { dataRow["UnitPrice"].ToString(), "»", dataRow["ProductID"].ToString(), "»", dataRow["CartItemID"].ToString(), "»", dataRow["CartTotalPrice"].ToString(), "»", dataRow["CouponCodeApplyed"].ToString() };
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
        public string QuickItemAdd(long PriceCatalogueID, int Quantity, decimal QtyPriceWithoutTax, decimal CartTax, int StoreUserID, decimal TaxRate, int TaxID, decimal UnitPrice, decimal MainPriceExcMarkup, string ProductName, string CookieID, decimal Height, decimal Width, long ChangedProductId, long MainProductId)
        {
            string empty = string.Empty;
            long num = (long)0;
            num = CartBasePage.Insert_into_Cart(CookieID, (long)StoreUserID, QtyPriceWithoutTax, CartTax, new decimal(0),false);
            if (num != (long)0)
            {
                CartBasePage.Insert_into_CartItem(num, ChangedProductId, "", (long)Quantity, UnitPrice, "", "", "", QtyPriceWithoutTax, TaxRate, MainPriceExcMarkup, (long)TaxID, Height, Width, "", "", "", MainProductId, "", "", "");
            }
            object[] str = new object[] { 0, "µ", Convert.ToString(PriceCatalogueID), "µ", ProductName };
            return string.Concat(str);
        }

        [WebMethod]
        public string Select_OtherCostAdditional_ItemsDetail(string OthercostID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            DataSet dataSet = ProductBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(OthercostID));
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
            DataTable dataTable = ProductBasePage.SubAdditionalOptions_Values(Convert.ToInt32(ChoiceID), Convert.ToInt32(OthercostID));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = string.Concat(empty, "@", row["WebOtherCostName"].ToString());
                str = string.Concat(str, row["webothercostid"].ToString(), "^");
            }
            return string.Concat(empty, "$", str);
        }

        [WebMethod(EnableSession = true)]
        public string Update_CartItems(string Values, string SaveToAdditionalItems, string CartID, string IsBackOrder_Check)
        {
            object[] str;
            bool flag = false;
            bool flag1 = true;
            string str1 = "";
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
                                str1 = (str1 != "" ? string.Concat(str1, "♣", dataRow["itemtitle"].ToString()) : dataRow["itemtitle"].ToString());
                            }
                            else
                            {
                                str1 = dataRow["itemtitle"].ToString();
                            }
                        }
                    }
                    if (item1.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in item1.Rows)
                        {
                            if (item1.Rows.Count != 1)
                            {
                                str1 = (str1 != "" ? string.Concat(str1, "♣", row1["itemtitle"].ToString()) : row1["itemtitle"].ToString());
                            }
                            else
                            {
                                str1 = row1["itemtitle"].ToString();
                            }
                        }
                    }
                }
            }
            if (flag1 && !flag)
            {
                base.Session["MultipleCartID"] = "";
                long num = (long)0;
                string empty = string.Empty;
                base.Session["MultipleCartID"] = CartID;
                char[] chrArray = new char[] { 'µ' };
                string[] strArrays = Values.Split(chrArray);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        string str2 = strArrays[i].ToString();
                        chrArray = new char[] { '»' };
                        string[] strArrays1 = str2.Split(chrArray);
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            if (strArrays1[j] != "")
                            {
                                string str3 = strArrays1[j].ToString();
                                chrArray = new char[] { '±' };
                                string[] strArrays2 = str3.Split(chrArray);
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
                string empty2 = string.Empty;
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                long num5 = (long)0;
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                string empty3 = string.Empty;
                int num8 = 0;
                int num9 = 0;
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                if (base.Session["StoreUserID"] != null)
                {
                    num1 = Convert.ToInt64(base.Session["StoreUserID"]);
                    CartBasePage.Cart_AdditionalOptions_Delete(num1);
                }
                chrArray = new char[] { 'µ' };
                string[] strArrays3 = SaveToAdditionalItems.Split(chrArray);
                for (int k = 0; k <= (int)strArrays3.Length - 1; k++)
                {
                    if (strArrays3[k] != "")
                    {
                        string str4 = strArrays3[k].ToString();
                        chrArray = new char[] { '±' };
                        string[] strArrays4 = str4.Split(chrArray);
                        for (int l = 0; l <= (int)strArrays4.Length - 1; l++)
                        {
                            if (strArrays4[l] != "")
                            {
                                string str5 = strArrays4[l];
                                chrArray = new char[] { '»' };
                                string[] strArrays5 = str5.Split(chrArray);
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
                                        empty2 = strArrays5[1];
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
                                        empty3 = strArrays5[1];
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
                        CartBasePage.Insert_To_CartAdditionalOptions(num1, empty1, num2, empty2, num3, num4, num5, empty3, num7, num6, num8, num9, num10, num11);
                    }
                }
            }
            commonclass _commonclass = new commonclass();
            string str6 = _commonclass.GetDisplayValue("isCheckOrderInfoPublic", Convert.ToInt64(ConnectionClass.AccountID)).ToLower().Trim();
            string str7 = _commonclass.GetDisplayValue("isCheckAddressInfo", Convert.ToInt64(ConnectionClass.AccountID)).ToLower().Trim();
            _commonclass.GetDisplayValue("isCheckPaymentInfo", Convert.ToInt64(ConnectionClass.AccountID)).ToLower().Trim();
            if (!(str6 == "false") || !(str7 == "false"))
            {
                base.Session["ConfirmBeforeOrdernew"] = null;
            }
            else
            {
                base.Session["ConfirmBeforeOrdernew"] = "1";
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
                long num12 = (long)0;
                if (base.Session["StoreUserID"] != null)
                {
                    num12 = Convert.ToInt64(base.Session["StoreUserID"].ToString());
                }
                string uniqueID = _commonclass.UniqueID;
                long num13 = (long)0;
                string str8 = "no";
                string empty4 = string.Empty;
                foreach (DataRow dataRow1 in LoginBasePage.StoreUser_select(num12).Rows)
                {
                    num13 = Convert.ToInt64(dataRow1["ClientID"].ToString());
                    if (str8 != "new")
                    {
                        str8 = (!Convert.ToBoolean(dataRow1["IsOrdered"].ToString()) ? "no" : "yes");
                    }
                    else
                    {
                        str8 = "no";
                    }
                }
                int num14 = 0;
                int num15 = 0;
                int num16 = 0;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                int num17 = 0;
                _commonclass.GetDisplayValue("CommentsDefaultValue", Convert.ToInt64(ConnectionClass.AccountID));
                DataTable dataTable2 = new DataTable();
                DataTable dataTable3 = LoginBasePage.Select_AccountDetails(Convert.ToInt64(ConnectionClass.CompanyID), Convert.ToInt64(ConnectionClass.AccountID));
                foreach (DataRow row2 in dataTable3.Rows)
                {
                    row2["accountType"].ToString();
                    row2["DateFormat"].ToString();
                    num17 = Convert.ToInt32(row2["createdBy"].ToString());
                }
                dataTable2 = OrderBasePage.SelectEstimatedDeliveryDays(Convert.ToInt64(ConnectionClass.CompanyID));
                foreach (DataRow dataRow2 in dataTable2.Rows)
                {
                    num14 = Convert.ToInt32(dataRow2["WorkingDaysFrom"]);
                    num15 = Convert.ToInt32(dataRow2["WorkingDaysTo"]);
                    num16 = Convert.ToInt32(dataRow2["DefaultEstimatedDelivery"]);
                }
                int num18 = Convert.ToInt32(_commonclass.GetDisplayValue("DeliveryRequiredByValue", Convert.ToInt64(ConnectionClass.AccountID)));
                string empty7 = string.Empty;
                if (num18 != -1)
                {
                    DateTime dateTime = _commonclass.ReturnWeekDate(DateTime.Now, num14, num15, num16);
                    _commonclass.Eprint_return_Date_Before_View(dateTime.ToString(), Convert.ToInt32(ConnectionClass.CompanyID), num17, false);
                }
                str = new object[] { num12, uniqueID, "0", "0", num13, str8, empty4, "", "", "", "", "0", "0" };
                dataTable1.Rows.Add(str);
                base.Session["InsertOrder"] = dataTable1;
            }
            str = new object[] { flag1.ToString(), "♠", str1, "♠", flag };
            return string.Concat(str);
        }

        [WebMethod(EnableSession = true)]
        public string Update_CartItemsNew(string Values, string SaveToAdditionalItems)
        {
            long num = (long)0;
            string empty = string.Empty;
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
            string str = string.Empty;
            long num2 = (long)0;
            string empty1 = string.Empty;
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            long num5 = (long)0;
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            string str1 = string.Empty;
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
                                    str = strArrays5[1];
                                }
                                else if (strArrays5[0] == "OthercostID")
                                {
                                    num2 = Convert.ToInt64(strArrays5[1]);
                                }
                                else if (strArrays5[0] == "Formula")
                                {
                                    empty1 = strArrays5[1];
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
                                    str1 = strArrays5[1];
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
                    CartBasePage.Insert_To_CartAdditionalOptions(num1, str, num2, empty1, num3, num4, num5, str1, num7, num6, num8, num9, num10, num11);
                }
            }
            return Values;
        }

        [WebMethod]
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
                    ProductBasePage.MeasurementValue((long)Convert.ToInt32(ConnectionClass.CompanyID));
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
                                str = str.Replace("[$ProductBasePrice$]", Convert.ToString(num1)).Replace("<quantity>", Convert.ToString(num2)).Replace("[$OrderedHeight$]", Convert.ToString(num10)).Replace("[$OrderedWidth$]", Convert.ToString(num11)).Replace("[$OrderedArea$]", Convert.ToString(num12)).Replace("[$MultipleOf$]", Convert.ToString(1));
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
//}
