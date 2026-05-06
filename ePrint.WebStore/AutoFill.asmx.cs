using MathFunctions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using ShipEngine.ApiClient.Api;
using ShipEngine.ApiClient.Model;
using ShipEngine.ApiClient.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text.Json;
using RestSharp;

[ScriptService]
[WebService(Namespace = "http://www.eprintsoftware.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AutoFill : WebService
{
    public string StyleSheetPath = string.Empty;

    public languageClass objLanguage = new languageClass();
    
    public string ShipApiKey = ConnectionClass.ShipApiKey;

    public AutoFill()
    {
    }

    [XmlRoot(ElementName = "errorInfo")]
    public class ErrorInfo
    {

        [XmlElement(ElementName = "errorCode")]                 //error code of result
        public string ErrorCode { get; set; }

        [XmlElement(ElementName = "errorMessage")]              //error message
        public string ErrorMessage { get; set; }

        [XmlElement(ElementName = "errorMessageVerbose")]       //detailzed error message in case critical error
        public string ErrorMessageVerbose { get; set; }

        [XmlElement(ElementName = "elapsedTime")]               //elapsed time for request processing
        public string ElapsedTime { get; set; }

        [XmlElement(ElementName = "startTime")]                 //start time for request processing
        public string StartTime { get; set; }

        [XmlElement(ElementName = "endTime")]                   //end time for request processing
        public string EndTime { get; set; }

        [XmlElement(ElementName = "ServerName")]                //Server's name for request processing
        public string ServerName { get; set; }

        [XmlElement(ElementName = "Version")]                   //actual version of API
        public string Version { get; set; }

        [XmlElement(ElementName = "warnings")]                  //List of warning messages
        public object Warnings { get; set; }
    }

    [XmlRoot(ElementName = "rateDetail")]
    public class RateDetail
    {

        [XmlElement(ElementName = "jurisdictionLevel")]         //jurisdiction level
        public string JurisdictionLevel { get; set; }

        [XmlElement(ElementName = "jurisdictionCode")]          //jurisdiction Code (if any)
        public string JurisdictionCode { get; set; }

        [XmlElement(ElementName = "taxRate")]                   //tax rate
        public string TaxRate { get; set; }

        [XmlElement(ElementName = "authorityName")]             //authority name whoi managed tax
        public string AuthorityName { get; set; }
    }

    [XmlRoot(ElementName = "rateDetails")]                      //tax breakout basic class
    public class RateDetails
    {

        [XmlElement(ElementName = "rateDetail")]                //list of breakout
        public List<RateDetail> RateDetail { get; set; }
    }

    [XmlRoot(ElementName = "rateInfo")]
    public class RateInfo
    {

        [XmlElement(ElementName = "rateDetails")]               //tax breakout basic class
        public RateDetails RateDetails { get; set; }
    }

    [XmlRoot(ElementName = "salesTax")]
    public class SalesTax
    {

        [XmlElement(ElementName = "taxRate")]
        public string TaxRate { get; set; }

        [XmlElement(ElementName = "rateInfo")]
        public RateInfo RateInfo { get; set; }
    }

    [XmlRoot(ElementName = "useTax")]
    public class UseTax
    {

        [XmlElement(ElementName = "taxRate")]
        public string TaxRate { get; set; }

        [XmlElement(ElementName = "rateInfo")]
        public RateInfo RateInfo { get; set; }
    }

    [XmlRoot(ElementName = "noteDetail")]
    public class NoteDetail
    {

        [XmlElement(ElementName = "jurisdiction")]
        public string Jurisdiction { get; set; }

        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [XmlElement(ElementName = "note")]
        public string Note { get; set; }
    }

    [XmlRoot(ElementName = "noteDetails")]
    public class NoteDetails
    {

        [XmlElement(ElementName = "noteDetail")]
        public List<NoteDetail> NoteDetail { get; set; }
    }

    [XmlRoot(ElementName = "notes")]
    public class Notes
    {

        [XmlElement(ElementName = "noteDetails")]
        public NoteDetails NoteDetails { get; set; }
    }

    [XmlRoot(ElementName = "address")]
    public class Address
    {

        [XmlElement(ElementName = "addressLine1")]          // street address
        public string AddressLine1 { get; set; }

        [XmlElement(ElementName = "addressLine2")]          // additional street address
        public string AddressLine2 { get; set; }

        [XmlElement(ElementName = "place")]                 // city (place)
        public string Place { get; set; }

        [XmlElement(ElementName = "state")]                 // state		
        public string State { get; set; }

        [XmlElement(ElementName = "zipCode")]               // zip code
        public string ZipCode { get; set; }

        [XmlElement(ElementName = "county")]                // county
        public string County { get; set; }

        [XmlElement(ElementName = "latitude")]              // latitude
        public string Latitude { get; set; }

        [XmlElement(ElementName = "longitude")]             // longitude
        public string Longitude { get; set; }

        [XmlElement(ElementName = "salesTax")]              // class for sales Tax info
        public SalesTax SalesTax { get; set; }

        [XmlElement(ElementName = "useTax")]                // class for Use Tax info
        public UseTax UseTax { get; set; }

        [XmlElement(ElementName = "notes")]                 // class for list of notes
        public Notes Notes { get; set; }
    }

    [XmlRoot(ElementName = "addresses")]                    //class for searched addresses
    public class Addresses
    {

        [XmlElement(ElementName = "address")]
        public List<Address> Address { get; set; }
    }

    [XmlRoot(ElementName = "addressInfo")]
    public class AddressInfo
    {

        [XmlElement(ElementName = "addressResolution")]
        public string AddressResolution { get; set; }

        [XmlElement(ElementName = "addresses")]
        public Addresses Addresses { get; set; }
    }

    [XmlRoot(ElementName = "z2tLookup")]
    public class Z2tLookup
    {

        [XmlElement(ElementName = "errorInfo")]
        public ErrorInfo ErrorInfo { get; set; }

        [XmlElement(ElementName = "addressInfo")]
        public AddressInfo AddressInfo { get; set; }
    }
    public class ShipAddress
    {
        public string address_line1 { get; set; }
        public string city_locality { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }
    public class ShippingRate
    {
        public string RateId { get; set; }
        public decimal ShippingAmount { get; set; }
        public string CarrierId { get; set; }
        public string CarrierFriendlyName { get; set; }
        public string CarrierCode { get; set; }
        public string ServiceType { get; set; }
        public string ServiceCode { get; set; }
    }
    public class ShippingInfo
    {
        public string[] carrier_ids { get; set; }
        public string from_country_code { get; set; }
        public string from_postal_code { get; set; }
        public string to_country_code { get; set; }
        public string to_postal_code { get; set; }
        public string to_city_locality { get; set; }
        public string to_state_province { get; set; }
        public ShipingWeight Weight { get; set; }
        public ShipingDimensions Dimensions { get; set; } 
        public string Confirmation { get; set; }
        public string AddressResidentialIndicator { get; set; }
        public ShippingInfo()
        {
            Weight = new ShipingWeight();
            Dimensions = new ShipingDimensions();
        }
    }

    public class ShipingWeight
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }

    public class ShipingDimensions
    {
        public string Unit { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
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
    public string CalculateQtyListCost(long PriceCatalogueId)
    {
        string qtyFromList = "";
        string qtyToList = "";
        string CostExcMarkupList = "";
        string MarkupList = "";
        string priceList = "";
        foreach (DataRow row in ProductBasePage.Product_CatalogueQty_Select((long)PriceCatalogueId).Rows)
        {
            qtyFromList = string.Concat(qtyFromList, row["FromQuantity"].ToString(), "µ");
            qtyToList = string.Concat(qtyToList, row["ToQuantity"].ToString(), "µ");
            CostExcMarkupList = string.Concat(CostExcMarkupList, row["Price"].ToString(), "µ");
            MarkupList = string.Concat(MarkupList, row["Markup"].ToString(), "µ");
            priceList = string.Concat(priceList, row["SellingPrice"].ToString(), "µ");
        }
        return string.Concat(qtyFromList, "~", qtyToList, "~", CostExcMarkupList, "~", MarkupList, "~", priceList, "~");
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
    public string Update_deliveryCost(string DeliveryCost, long StoreUserID, string selectedOptionText)
    {
        string empty = string.Empty;
        long num = (long)0;
        DataTable dataTable = CartBasePage.Check_Delivery_Cart();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToBoolean(row["IsDeliveryCost"]))
                {
                    CartBasePage.Update_Delivery_Cart((long)row["CartID"], Convert.ToDecimal(DeliveryCost), selectedOptionText);
                    CartBasePage.Update_Delivery_CartItem((long)row["CartitemID"], Convert.ToDecimal(DeliveryCost));
                }
            }
        }
        else
        {
            num = CartBasePage.Insert_into_Cart("", StoreUserID, Convert.ToDecimal(DeliveryCost), 0, new decimal(0) , true);
            CartBasePage.Update_Cart_TotalWithDc(num, Convert.ToDecimal(DeliveryCost), selectedOptionText);
            if (num != (long)0)
            {
                CartBasePage.Insert_into_CartItem(num, 0, "Delivery Cost", (long)1, Convert.ToDecimal(DeliveryCost), "", "", "", Convert.ToDecimal(DeliveryCost), 0, 0, (long)0, "C", "", "", "", (long)0, (long)0, 0, (long)0, 0, 0, (long)0, 0, "", "", "");
            }
        }
        return empty;
    }

    [WebMethod(EnableSession = true)]
    public string Get_Zip2tax(string val1, string val2, string AccID)
    {
        string Result = "";
        bool IsZip2taxEnabled;
        string username = "sample";
        string password = "password";
        string zipCode = "90210"; //sample zip code must be between 90001 and 90999
        IsZip2taxEnabled = CartBasePage.Select_IsZip2taxEnabled(Convert.ToInt32(ConnectionClass.CompanyID), Convert.ToInt64(AccID));
        if (IsZip2taxEnabled != true)
        {
            Result = "0";
        }
        else
        {
            DataTable dataTable = CartBasePage.Setting_ZiptoTax_Select(Convert.ToInt64(AccID), Convert.ToInt64(ConnectionClass.CompanyID));
            foreach (DataRow row in dataTable.Rows)
            {
                username = row["ZipTaxUserName"].ToString();
                password = row["ZipTaxPassword"].ToString();

            }
            foreach (DataRow row in OrderBasePage.Select_BillingShippingAddress_DeliveryCost(Convert.ToInt64(val1),false, Convert.ToInt64(ConnectionClass.CompanyID)).Rows)
            {
                zipCode = row["Address5"].ToString();
            }
            string url = "https://api.zip2tax.com/TaxRate-USA.xml?username=" + username + "&password=" + password + "&zip=" + zipCode;
            string strxml;

            string zipCodeValue = "";
            string SalesTaxRateValue = "";
            string PostOfficeCityValue = "";
            string countyValue = "";
            string stateValue = "";
            //string useTaxRateValue = "";
            //string ischippingTaxableValue = "";
            string Response = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    //Download the xml document as a string


                    strxml = client.DownloadString(url);
                    XmlSerializer serializer = new XmlSerializer(typeof(Z2tLookup));

                    using (StringReader reader = new StringReader(strxml))
                    {
                        Z2tLookup APIresponseData = (Z2tLookup)serializer.Deserialize(reader);
                        Response = APIresponseData.ErrorInfo.ErrorCode +'-'+ APIresponseData.ErrorInfo.ErrorMessage +' '+ APIresponseData.ErrorInfo.ErrorMessageVerbose;
                        if (APIresponseData.ErrorInfo.ErrorMessage == "Success")
                        {
                            zipCodeValue = APIresponseData.AddressInfo.Addresses.Address[0].ZipCode;
                            PostOfficeCityValue = APIresponseData.AddressInfo.Addresses.Address[0].Place;
                            countyValue = APIresponseData.AddressInfo.Addresses.Address[0].County;
                            stateValue = APIresponseData.AddressInfo.Addresses.Address[0].State;
                            //SalesTaxRateValue = APIresponseData.AddressInfo.Addresses.Address[0].SalesTax.TaxRate;
                            SalesTaxRateValue = APIresponseData.AddressInfo.Addresses.Address[0].SalesTax.TaxRate;
                            CartBasePage.Update_ZipTax_Cart(Convert.ToDecimal(SalesTaxRateValue));
                            //useTaxRateValue = APIresponseData.AddressInfo.Addresses.Address[0].UseTax.TaxRate;

                            //NoteDetail note = APIresponseData.AddressInfo.Addresses.Address[0].Notes.NoteDetails.NoteDetail.Where(n => n.Category == "Tax on Shipping").FirstOrDefault();
                            //if (note != null)
                              //  ischippingTaxableValue = note.Note;
                           // else ischippingTaxableValue = "Shipping charges are not taxable";
                        }
                        else
                        {
                            CartBasePage.Update_DefaultTax_Cart(Convert.ToInt32(ConnectionClass.CompanyID));
                        }
                        CartBasePage.Setting_ZiptoTax_Update(Convert.ToInt64(AccID), Convert.ToInt64(ConnectionClass.CompanyID), url, Response);
                    }

                }

            }
            catch (Exception ex)
            {
                string error = "";
            }
        }


        return Result;
    }

    [WebMethod(EnableSession = true)]
    public string Get_DeliveryCost(string val1, string val2, string AccID)
    {
        String Result = "0";
        DataTable dataTable = CartBasePage.Select_DeliveryCost_SEItemsDetail(AccID);
        long num = (long)0;
            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataShip = CartBasePage.PC_select_DeliveryCost_Settings(Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(AccID));
                foreach (DataRow row2 in dataShip.Rows)
                {
                    if (Convert.ToInt32(row2["IsEnableDC"]) != 0)
                    {
                        if (Convert.ToBoolean(row["FromShipEngine"]) != false)
                        {
                        try
                        {
                            if (Convert.ToInt32(row2["IsEnableShipEngine"]) != 0)
                            {
                                Double cost = this.SEDeliveryCost(row["Formula"].ToString(), val1, AccID, Convert.ToInt32(row["CompanyID"]));
                                CartBasePage.Update_DeliveryCost_ItemsDetail(Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(row["DeliveryCostID"]), cost);
                            }
                            else
                            {
                                CartBasePage.Delete_ShipRates_SEItemsDetail(row["Formula"].ToString());
                            }
                        }catch (Exception ex)
                        {
                            Result = ex.Message;
                        }
                        }
                        else
                        {
                            int Qty = 0;
                            int totalQty = 0;
                            string cartid = this.Session["MultipleCartID"].ToString();
                            DataTable CartValues = CartBasePage.Select_CBMCartItems_DC(cartid);
                            foreach (DataRow row1 in CartValues.Rows)
                            {
                                Qty = Convert.ToInt32(row1["Quantity"]);
                                totalQty += Qty;
                                Qty = totalQty;
                            }
                            string Formula = row["Type"].ToString();
                            string math = Formula.Replace("<quantity>", Qty.ToString()).Replace("[$ProductBasePrice$]", "2").Replace("[$OrderedHeight$]", "3").Replace("[$OrderedWidth$]", "4").Replace("$OrderedArea$]", "5").Replace("[$MultipleOf$]", "6");
                            string cost = new DataTable().Compute(math, null).ToString();
                            CartBasePage.Update_DeliveryCost_ItemsDetail(Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(row["DeliveryCostID"]), Convert.ToDouble(cost));
                            CartBasePage.Update_Rates_NonSE((row["label"]).ToString(), Convert.ToDouble(cost));
                        }
                    }
                }

                num = Convert.ToInt64(row["DeliveryCostID"]);
            }

        return Result;
    }

    public Double SEDeliveryCost(string val, string address1, string AccID, int CompanyID)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        Double CBMHeight = 0;
        Double CBMLenght = 0;
        Double CBMWidth = 0;
        int CBMWeight = 0;
        int VolumetricWeight = 0;
        int FinalWeight = 0;
        string WeightMeasurement = "";
        string DiMeasurement = "";
        var shipment = new AddressValidatingShipment();
        var shippingweight = new ShipingWeight();
        var shippingdimensions = new ShipingDimensions();
        var apiKey = ShipApiKey;
        if (String.IsNullOrWhiteSpace(apiKey))
        {
            apiKey = "TEST_1PltA1iiloyrhM/82FF9k7WY4pLAtt/1ylzPp7vPX9U";
        }
        var carriersApi = new CarriersApi();
        var carrier = carriersApi.CarriersGet(val, apiKey);
        string cartid = this.Session["MultipleCartID"].ToString();
        DataTable CBMValues = CartBasePage.Select_CBMCartItems_DC(cartid);
        foreach (DataRow row in CBMValues.Rows)
        {
            CBMHeight = Convert.ToDouble(row["CBMHeight"]);
            CBMLenght = Convert.ToDouble(row["CBMLength"]);
            CBMWidth = Convert.ToDouble(row["CBMWidth"]);
            if (Convert.ToInt32(row["PerQuantity"]) == 0)
            {
                row["PerQuantity"] = 1;
            }
            VolumetricWeight = (Convert.ToInt32(row["VolumetricWeight"]) / Convert.ToInt32(row["PerQuantity"])) * Convert.ToInt32(row["Quantity"]);
            CBMWeight = (Convert.ToInt32(row["CBMWeight"]) / Convert.ToInt32(row["PerQuantity"])) * Convert.ToInt32(row["Quantity"]);
            WeightMeasurement = (row["GeneralWeight"]).ToString();
            DiMeasurement = (row["PaperMeasure"]).ToString();
            if (VolumetricWeight > CBMWeight)
            {
                FinalWeight = FinalWeight + VolumetricWeight;
            }
            else
            {
                FinalWeight = FinalWeight + CBMWeight;
            }
        }
        if (WeightMeasurement == "lbs")
        {
            shippingweight = new ShipingWeight { Value = FinalWeight, Unit = "Pound" };
        }
        else if (WeightMeasurement == "kgs")
        {
            shippingweight = new ShipingWeight { Value = FinalWeight, Unit = "Kilogram" };
        }
        else
        {
            throw new ArgumentException("Invalid weight measurement unit");
        }

        if (DiMeasurement == "In.")
        {
            shippingdimensions = new ShipingDimensions { Length = CBMLenght, Width = CBMWidth, Height = CBMHeight, Unit = "inch" };
        }
        else if (DiMeasurement == "mm")
        {
            shippingdimensions = new ShipingDimensions { Length = CBMLenght, Width = CBMWidth, Height = CBMHeight, Unit = "centimeter" };
        }
        else
        {
            throw new ArgumentException("Invalid dimension measurement unit");
        }

        shipment.ShipFrom = GetAddress(apiKey, "0", new AddressDTO("John Doe", "5551234567", "Acme Corp.", "100 Main St.", null, null, "Austin", "TX", "78610", "US"), true, CompanyID);

        shipment.ShipTo = GetAddress(apiKey, address1, new AddressDTO("John Doe", "5551234567", "Acme Corp.", "100 Main St.", null, null, "Houston", "TX", "77002", "US"), false, CompanyID);

        var selectedRate = new ShippingRate();
        DataTable dataTable = CartBasePage.Select_ShipRates_SEItemsDetail(carrier.CarrierId);
        var rates = ChooseRate(shipment, shippingweight, shippingdimensions, carrier, apiKey , AccID);
        if (rates.Count > 0)
        {
            double FinalCost = 0;
            var Markup = CartBasePage.Select_DefaultMarkup(CompanyID);
            for (var i = 0; i < rates.Count; i++)
            {
                bool rateExists = DoesRateExist(dataTable, rates[i].CarrierId, rates[i].ServiceCode);
                if (rateExists)
                {
                    FinalCost = Convert.ToDouble(rates[i].ShippingAmount) + (Convert.ToDouble(rates[i].ShippingAmount) * Convert.ToDouble(Markup) / 100);
                    CartBasePage.Update_ShipRates_SEItemsDetail(rates[i].RateId, rates[i].CarrierId, rates[i].CarrierFriendlyName, rates[i].CarrierCode, rates[i].ServiceType, rates[i].ServiceCode, FinalCost);
                }
                else
                {
                    FinalCost = Convert.ToDouble(rates[i].ShippingAmount) + (Convert.ToDouble(rates[i].ShippingAmount) * Convert.ToDouble(Markup) / 100);
                    CartBasePage.Insert_ShipRates_SEItemsDetail(rates[i].RateId, rates[i].CarrierId, rates[i].CarrierFriendlyName, rates[i].CarrierCode, rates[i].ServiceType, rates[i].ServiceCode, FinalCost);
                }

                selectedRate = rates[i];
            }

            var rate = selectedRate;
            return Convert.ToDouble(rate.ShippingAmount);
        }
        else
        {
            CartBasePage.Delete_ShipRates_SEItemsDetail(carrier.CarrierId);
            return Convert.ToDouble(0);
        }
    }

    static bool DoesRateExist(DataTable dataTable, string CarrierID, string ServiceCode)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            string id = row["CarrierId"].ToString();
            string code = row["ServiceCode"].ToString();
            if ((id == CarrierID) && (code == ServiceCode))
            {
                return true;
            }
        }
        return false;
    }

    static AddressDTO GetAddress(string apiKey, string AddressID, AddressDTO defaultAddress, bool isfrom , int CompanyID)
    {
        //var address = new AddressDTO();
        var address = new ShipAddress();
        var Validatedaddress = new AddressDTO();

        foreach (DataRow row in OrderBasePage.Select_BillingShippingAddress_DeliveryCost(Convert.ToInt64(AddressID), isfrom , Convert.ToInt64(CompanyID)).Rows)
        {
            if (String.IsNullOrWhiteSpace(row["Address1"].ToString()))
            {
                Validatedaddress.AddressLine1 = defaultAddress.AddressLine1;
                Validatedaddress.CityLocality = defaultAddress.CityLocality;
                address.state_province = defaultAddress.StateProvince;
                Validatedaddress.StateProvince = defaultAddress.PostalCode;
                Validatedaddress.PostalCode = defaultAddress.CountryCode;
            }
            else
            {

                Validatedaddress.AddressLine1 = row["Address1"].ToString();
                Validatedaddress.CityLocality = row["Address3"].ToString();
                Validatedaddress.StateProvince = row["Address4"].ToString();
                Validatedaddress.PostalCode = row["Address5"].ToString();
                if (row["Country"].ToString().Length > 2)
                {
                    Validatedaddress.CountryCode = row["CountryCode"].ToString().TrimEnd();
                }
                else
                {
                    Validatedaddress.CountryCode = row["Country"].ToString();
                }
            }
        }
        

        //Validatedaddress = validateaddress(address, apiKey);

        return Validatedaddress;
    }

    static AddressDTO validateaddress(ShipAddress address, string apiKey)
    {
        //List<AddressDTO> addresses = new List<AddressDTO>();
        AddressDTO matchedaddress = new AddressDTO();
        List<ShipAddress> addresses = new List<ShipAddress>();
        addresses.Add(address);
        var client = new RestClient("https://api.shipengine.com/v1/addresses/validate");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Host", "api.shipengine.com");
        request.AddHeader("API-Key", apiKey);
        request.AddHeader("Content-Type", "application/json");
        string body = JsonSerializer.Serialize(addresses, new JsonSerializerOptions { WriteIndented = true });
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        var responseObject = JsonSerializer.Deserialize<JsonElement[]>(response.Content);
        var matchedAddress = responseObject[0].GetProperty("matched_address");
        matchedaddress.AddressLine1 = matchedAddress.GetProperty("address_line1").GetString();
        matchedaddress.CityLocality = matchedAddress.GetProperty("city_locality").GetString();
        matchedaddress.StateProvince = matchedAddress.GetProperty("state_province").GetString();
        matchedaddress.PostalCode = matchedAddress.GetProperty("postal_code").GetString();
        matchedaddress.CountryCode = matchedAddress.GetProperty("country_code").GetString();
        return matchedaddress;
        //AddressValidationApi instance = new AddressValidationApi();
        //var response = instance.AddressValidationValidateAddresses(addresses, apiKey);
        //return response[0].MatchedAddress;
    }

    static List<ShippingRate> ChooseRate(AddressValidatingShipment shipment, ShipingWeight shippingweight, ShipingDimensions shippingdimensions, Carrier carrier, string apiKey, string AccId)
    {

        try
        {
            List<ShippingRate> Rates = new List<ShippingRate>();
            ShippingInfo shippingInfo = new ShippingInfo();
            string errorMessage = "";
            var client = new RestClient("https://api.shipengine.com/v1/rates/estimate");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Host", "api.shipengine.com");
            request.AddHeader("API-Key", apiKey);
            request.AddHeader("Content-Type", "application/json");
            shippingInfo.carrier_ids = new[] { carrier.CarrierId };
            shippingInfo.from_country_code = shipment.ShipFrom.CountryCode;
            shippingInfo.from_postal_code = shipment.ShipFrom.PostalCode;
            shippingInfo.to_country_code = shipment.ShipTo.CountryCode;
            shippingInfo.to_postal_code = shipment.ShipTo.PostalCode;
            shippingInfo.to_city_locality = shipment.ShipTo.CityLocality;
            shippingInfo.to_state_province = shipment.ShipTo.StateProvince;
            shippingInfo.Weight.Value = Convert.ToDouble(shippingweight.Value);
            shippingInfo.Weight.Unit = shippingweight.Unit;
            shippingInfo.Dimensions.Unit = shippingdimensions.Unit;
            shippingInfo.Dimensions.Length = Convert.ToDouble(shippingdimensions.Length);
            shippingInfo.Dimensions.Width = Convert.ToDouble(shippingdimensions.Width);
            shippingInfo.Dimensions.Height = Convert.ToDouble(shippingdimensions.Height);
            shippingInfo.Confirmation = "none";
            shippingInfo.AddressResidentialIndicator = "no";
            string json = JsonSerializer.Serialize(shippingInfo, new JsonSerializerOptions { WriteIndented = true });
            CartBasePage.Update_ShipEngine_PayloadDetail(carrier.CarrierId, json);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {

                var responseObject = JsonSerializer.Deserialize<JsonElement[]>(response.Content);
                List<ShippingRate> shippingRates = new List<ShippingRate>();
                foreach (var element in responseObject)
                {
                    if (element.GetProperty("rate_details").GetArrayLength() == 0)
                    {
                        errorMessage = element.GetProperty("error_messages")[0].ToString();
                        CartBasePage.Update_ShipEngine_ErrDetail(carrier.CarrierId, errorMessage);
                        throw new Exception("Error occurred while processing shipping rate details: " + errorMessage);
                    }
                    else
                    {
                        ShippingRate rate = new ShippingRate
                        {
                            RateId = element.GetProperty("rate_type").GetString(),
                            CarrierId = element.GetProperty("carrier_id").GetString(),
                            ShippingAmount = element.GetProperty("shipping_amount").GetProperty("amount").GetDecimal(),
                            CarrierFriendlyName = element.GetProperty("carrier_friendly_name").GetString(),
                            CarrierCode = element.GetProperty("carrier_code").GetString(),
                            ServiceType = element.GetProperty("service_type").GetString(),
                            ServiceCode = element.GetProperty("service_code").GetString()
                        };
                        Rates.Add(rate);
                        CartBasePage.Update_ShipEngine_ErrDetail(carrier.CarrierId,"");
                    }
                }
                CartBasePage.ShipEnginecall_Details_Insert(carrier.CarrierId, AccId, false, json, errorMessage);
                return Rates;
            }
            else
            {

                return null;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod(EnableSession = true)]
    public string GetGroupRunUnitPrice(long ProductID, decimal TotalQty, string CartItemIDs, string CouponCode, string AccountID, double StoreCredit = 0)
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
                double UnitPrice = 0;
                double CartTotalPrice;
                double Tax = 0;
                double Tax1 = 0;
                double StoreCreditUsed = 0;
                CartTotalPrice = Convert.ToDouble(dataRow["CartTotalPrice"]);
                UnitPrice = Convert.ToDouble(dataRow["UnitPrice"]);
                Tax = Convert.ToDouble(dataRow["CartTax"]);

                //if (!Convert.ToBoolean(dataRow["IsLockStoreCredit"]))
                //{




                DataTable dtStoreCredit = CartBasePage.Select_CartItemsStoreCredit(Convert.ToInt64(dataRow["UserId"]), Convert.ToInt64(strArrays[0].ToString()));
                double storeCreditUnUsed = 0;
                foreach (DataRow rowCredit in dtStoreCredit.Rows)
                {
                    storeCreditUnUsed = Convert.ToDouble(rowCredit["StoreCredit"]==DBNull.Value?0: rowCredit["StoreCredit"]);
                }
                if (storeCreditUnUsed > 0)
                {
                    var value = assignStoreCredit(dtStoreCredit, StoreCredit);
                    StoreCreditUsed = value;

                    CartTotalPrice = Convert.ToDouble(dataRow["CartTotalPrice"]) - value;
                    if (CartTotalPrice > 0)
                    {
                        foreach (DataRow row in dtStoreCredit.Rows)
                        {
                            UnitPrice = CartTotalPrice / Convert.ToDouble(TotalQty);
                            Tax = CartTotalPrice * (Convert.ToDouble(row["tax"]) / 100);

                            CartBasePage.Save_CartItemsStoreCredit(Convert.ToInt64(strArrays[0].ToString()), Tax, UnitPrice, CartTotalPrice);
                        }
                    }
                    else
                    {
                        UnitPrice = 0;
                        CartTotalPrice = 0;
                        foreach (DataRow row in dtStoreCredit.Rows)
                        {
                            Tax1 = Convert.ToDouble(dataRow["CartTotalPrice"]) * (Convert.ToDouble(row["tax"]) / 100);

                            CartBasePage.Save_CartItemsStoreCredit(Convert.ToInt64(strArrays[0].ToString()), Tax1, 0, 0);
                        }
                    }
                }

                //}
                StoreCreditUsed = StoreCreditUsed + Tax1;
                base.Session["StoreCredit"] = StoreCreditUsed + StoreCredit + Tax1;

                string[] str1 = new string[] { UnitPrice.ToString(), "»", dataRow["ProductID"].ToString(), "»", dataRow["CartItemID"].ToString(), "»", CartTotalPrice.ToString(), "»", Tax.ToString(), "»", dataRow["CouponCodeApplyed"].ToString(), "»", StoreCreditUsed.ToString() };
                empty = string.Concat(str1);
            }
        }
        return empty;
    }
    double assignStoreCredit(DataTable dt, double StoreCrditUsed)
    {
        double StoreCreditWithCartId = 0;
        double StoreCreditValue = 0;


        foreach (DataRow row in dt.Rows)
        {

            StoreCreditValue = Convert.ToDouble(row["StoreCredit"]) - StoreCrditUsed;

        }

        foreach (DataRow item in dt.Rows)
        {


            if (StoreCreditValue > 0)
            {
                StoreCreditWithCartId = Math.Round(((StoreCreditValue - (Convert.ToDouble(item["Quantity"]) * Convert.ToDouble(item["UnitPrice"])) > 0 ? (Convert.ToDouble(item["Quantity"]) * Convert.ToDouble(item["UnitPrice"])) : StoreCreditValue)),2);
                StoreCreditValue = StoreCreditValue - Math.Round(Convert.ToDouble(item["MainItemPrice"]),2);
            }


        }
        return StoreCreditWithCartId;

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
        num = CartBasePage.Insert_into_Cart("", (long)StoreUserID, QtyPriceWithoutTax, CartTax, new decimal(0), false);
        if (num != (long)0)
        {
            CartBasePage.Insert_into_CartItem(num, ChangedProductID, "", (long)Quantity, UnitPrice, "", "", "", QtyPriceWithoutTax, TaxRate, MainPriceExcMarkup, (long)TaxID, "C", "", "", "", (long)0, (long)0, 0, (long)0, Height, Width, (long)0, MainProductId, "", "", "");
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

    [WebMethod(EnableSession = true)]
    public void StoreBehalfTypeSession(string BehalfType)
    {
        base.Session["OrderBehalfType"] = BehalfType;
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
        BaseClass baseClass = new BaseClass();
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
                            CartBasePage.Update_CartItems_JobName(num, baseClass.SpecialEncode(empty));
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
                empty = strArrays1[1].ToString();
                CartBasePage.Update_CartItems_JobName(num, (new BaseClass()).SpecialEncode(empty));
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