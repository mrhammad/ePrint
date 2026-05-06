using com.lowagie.text;
using com.lowagie.text.pdf;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Stripe;
using Stripe.Checkout;
using DocumentFormat.OpenXml.Drawing;


using System.Drawing;
using System.Drawing.Imaging;
using Printcenter.UI.EstimatesNew;
using Path = System.IO.Path;
using System.Threading;
using System.Threading.Tasks;

public class pdfGenerate : BaseClass
{
    private commonClass objJava = new commonClass();

    private Hashtable htItemDesc = new Hashtable();

    private Hashtable hsGroup = new Hashtable();

    private Hashtable hsGroupAutoExpandTop = new Hashtable();

    private Hashtable hsHGroup = new Hashtable();

    public string strFilePath = global.filePath();

    private DataTable dtPDFExportFromInvoiceReport = new DataTable();

    private DataTable dtQty = new DataTable();

    public string firstItemTaxrate = string.Empty;

    public string stripeUrl = string.Empty;

    public int firstPOPrint = 0;
    // first item quantity
    public int firstItemQuantity1 = 0;

    public int firstItemQuantity2 = 0;

    public int firstItemQuantity3 = 0;

    public int firstItemQuantity4 = 0;

    public string SecureDocFilepath = global.SecureDocFilepath();

    public DataTable DefaultInvoiceReportValues;

    protected string CompanyName = string.Empty;

    protected string MyCompanyAddress1 = string.Empty;

    protected string MyCompanyAddress2 = string.Empty;

    protected string MyCompanyAddress3 = string.Empty;

    protected string MyCompanyAddress4 = string.Empty;

    protected string MyCompanyCountry = string.Empty;

    protected string MyCompanyEmail = string.Empty;

    protected string MyCompanyFax = string.Empty;

    protected string MyCompanyName = string.Empty;

    protected string MyCompanyNumber = string.Empty;

    protected string MyCompanyPhone = string.Empty;

    protected string MyCompanyTaxNumber = string.Empty;

    protected string MyCompanyURL = string.Empty;

    protected string CustomerAddress1 = string.Empty;

    protected string CustomerAddress2 = string.Empty;

    protected string CustomerAddress3 = string.Empty;

    protected string CustomerAddress4 = string.Empty;

    protected string CustomerCountry = string.Empty;

    protected string CustomerEmail = string.Empty;

    protected string CustomerFax = string.Empty;

    protected string CustomerName = string.Empty;

    protected string CustomerPhone = string.Empty;

    protected string CustomerWebsite = string.Empty;

    protected string CRMTaxRate = string.Empty;

    protected string PaymentTerms = string.Empty;

    protected string TodaysDate = string.Empty;

    protected string _todaysDate = string.Empty;

    protected string AccountStatus = string.Empty;

    protected string CustomerDescription = string.Empty;

    protected string InvoiceContact = string.Empty;

    protected string InvoiceContactEmail = string.Empty;

    protected int SupplierID;

    protected string SupplierName = string.Empty;

    protected int SupplierContactID;

    protected string SupplierContactName = string.Empty;

    protected string SupplierAddress1 = string.Empty;

    protected string SupplierAddress2 = string.Empty;

    protected string SupplierAddress3 = string.Empty;

    protected string SupplierAddress4 = string.Empty;

    protected string SupplierAddress5 = string.Empty;

    protected string SupplierCountry = string.Empty;

    protected string SupplierPhone = string.Empty;

    protected string SupplierFax = string.Empty;

    protected string SupplierEmail = string.Empty;

    protected string SupplierPaymentTerms = string.Empty;

    protected string SupplierWebsite = string.Empty;

    protected string SupplierAccountNumber = string.Empty;

    protected string SupplierDescription = string.Empty;

    protected string SupplierAccountStatus = string.Empty;

    protected string CustomerContactSalutation = string.Empty;

    protected string CustomerContactFirstName = string.Empty;

    protected string CustomerContactLastName = string.Empty;

    protected string CustomerContactMiddleName = string.Empty;

    protected string CustomerContactFullName = string.Empty;

    protected string CustomerContactDepartment = string.Empty;

    protected string CustomerContactJobTitle1 = string.Empty;

    protected string CustomerContactJobTitle2 = string.Empty;

    protected string CustomerContactBusinessAddressLine1 = string.Empty;

    protected string CustomerContactBusinessAddressLine2 = string.Empty;

    protected string CustomerContactBusinessAddressLine3 = string.Empty;

    protected string CustomerContactBusinessAddressLine4 = string.Empty;

    protected string CustomerContactBusinessAddressLine5 = string.Empty;

    protected string CustomerContactBusinessCountry = string.Empty;

    protected string CustomerContactBusinessTelephone = string.Empty;

    protected string CustomerContactBusinessFax = string.Empty;

    protected string CustomerContactBusinessEmail = string.Empty;

    protected string CustomerContactMobile = string.Empty;

    protected string CustomerContactPhone = string.Empty;

    protected string CustomerContactPersonalFax = string.Empty;

    protected string SupplierContactSalutation = string.Empty;

    protected string SupplierContactFirstName = string.Empty;

    protected string SupplierContactLastName = string.Empty;

    protected string SupplierContactMiddleName = string.Empty;

    protected string SupplierContactFullName = string.Empty;

    protected string SupplierContactDepartment = string.Empty;

    protected string SupplierContactJobTitle1 = string.Empty;

    protected string SupplierContactJobTitle2 = string.Empty;

    protected string SupplierContactBusinessAddressLine1 = string.Empty;

    protected string SupplierContactBusinessAddressLine2 = string.Empty;

    protected string SupplierContactBusinessAddressLine3 = string.Empty;

    protected string SupplierContactBusinessAddressLine4 = string.Empty;

    protected string SupplierContactBusinessAddressLine5 = string.Empty;

    protected string SupplierContactBusinessCountry = string.Empty;

    protected string SupplierContactBusinessTelephone = string.Empty;

    protected string SupplierContactBusinessFax = string.Empty;

    protected string SupplierContactBusinessEmail = string.Empty;

    protected string SupplierContactMobile = string.Empty;

    protected string SupplierContactCompanyName = string.Empty;

    protected string SupplierContactPhone = string.Empty;

    protected string SupplierContactPersonalFax = string.Empty;

    protected string CostCentre = string.Empty;
    protected string CostCentreOfJob = string.Empty;
    protected string CustomerContactOfJob = string.Empty;

    protected string Greeting = string.Empty;

    protected string Header = string.Empty;

    protected string Footer = string.Empty;

    protected string OrderNumber = string.Empty;

    protected string CustomerOrderNumber = string.Empty;

    protected string SalesPerson = string.Empty;

    protected string EstimatedBy = string.Empty;

    protected string EstimatorEmail = string.Empty;

    protected string EstimatorPhone = string.Empty;

    protected string EstimatorMobile = string.Empty;

    protected string EstimatorJobTitle = string.Empty;

    protected string Estimator = string.Empty;

    protected string CreatedBy = string.Empty;

    protected string ValidFor = string.Empty;

    protected string CreatedDate = string.Empty;

    protected string _createdDate = string.Empty;

    protected string SalesPersonEmail = string.Empty;

    protected string SalesPersonPhone = string.Empty;

    protected string SalesPersonFax = string.Empty;

    protected string SalesPersonMobile = string.Empty;

    protected string TodayDate = string.Empty;

    protected string AccountNo = string.Empty;

    protected string Attention = string.Empty;

    protected string Department = string.Empty;

    protected string ProductImage = string.Empty;

    protected string OrderedBy = string.Empty;

    protected string SalesPersonJobTitle = string.Empty;

    protected string EstimateCustomer = string.Empty;

    protected string EstimateAddress1 = string.Empty;

    protected string EstimateTitle = string.Empty;

    protected string EstimateNumber = string.Empty;

    protected string EstimateNumberWithoutPrefix = string.Empty;

    protected string EstimatedDate = string.Empty;

    protected string CustomDate1 = string.Empty;
    protected string CustomDate2 = string.Empty;
    protected string CustomDate3 = string.Empty;
    protected string CustomDate4 = string.Empty;
    protected string CustomDate5 = string.Empty;

    protected string EstimateStatus = string.Empty;

    protected string EstimateAddress2 = string.Empty;

    protected string EstimateAddress3 = string.Empty;

    protected string EstimateAddress4 = string.Empty;

    protected string EstimateAddress5 = string.Empty;

    protected string EstimateCountry = string.Empty;

    protected string EstimateTelephone = string.Empty;

    protected string EstimateFax = string.Empty;

    protected string EstimatedArtwork = string.Empty;

    protected string EstimatedDelivery = string.Empty;

    protected int EstimateInvoiceAddressID;

    protected string EstimateInvoiceAddress = string.Empty;

    protected string EstimateAddressLabel = string.Empty;

    protected string InvoiceAddressLabel = string.Empty;

    protected string DeliveryAddressLabel = string.Empty;

    protected string DeliveryAddressEmail = string.Empty;

    protected string CustomerContactAddressLabel = string.Empty;

    protected string CarrierAddressLabel = string.Empty;

    protected string SupplierContactAddressLabel = string.Empty;

    protected string CopiedEstimateNumber = string.Empty;

    protected string JobAddress1 = string.Empty;

    protected string JobTitle = string.Empty;

    protected string JobNumber = string.Empty;

    protected string JobStatus = string.Empty;

    protected string JobAddress2 = string.Empty;

    protected string JobAddress3 = string.Empty;

    protected string JobAddress4 = string.Empty;

    protected string JobCountry = string.Empty;

    protected string JobCustomer = string.Empty;

    protected string JobCompletionDate = string.Empty;

    protected string CopiedJobNumber = string.Empty;

    protected string Job_OrderedDate = string.Empty;

    protected string jobOrderedDate = string.Empty;

    protected string InvoiceAddress1 = string.Empty;

    protected string InvoiceTitle = string.Empty;

    protected string InvoiceNumber = string.Empty;

    protected string InvoiceStatus = string.Empty;

    protected string InvoicedDate = string.Empty;

    protected string InvoiceAddress2 = string.Empty;

    protected string InvoiceAddress3 = string.Empty;

    protected string InvoiceAddress4 = string.Empty;

    protected string InvoiceAddress5 = string.Empty;

    protected string InvoiceTelephone = string.Empty;

    protected string InvoiceFax = string.Empty;

    protected string InvoiceCountry = string.Empty;

    protected string InvoiceCustomer = string.Empty;

    protected string OrderTotalPrice = string.Empty;

    protected string CurrencyCode = string.Empty;

    protected string PaypalPaymentLink = string.Empty;

    protected string StripePaymentLink = string.Empty;

    protected string Paypalbusiness = string.Empty;

    protected string StripeKey = string.Empty;

    protected string SessionId = string.Empty;

    protected string InvoicePaid = string.Empty;

    protected decimal InvoiceAmountPaid;

    protected decimal InvoiceAmountoutstanding;

    protected string CustomerInvoiceAddressType = string.Empty;

    protected int CustomerInvoiceAddressID;

    protected string EstimateItemNo = string.Empty;

    protected string OrderCBM;

    protected string OrderWeight;

    protected int CustomerInvoiceAddressClientID;

    protected string CustomerInvoiceAddress = string.Empty;

    protected string InvoiceDueDate = string.Empty;

    protected string InvoicedDateNew = string.Empty;

    protected string InvoiceDueDateNew = string.Empty;

    protected string CopiedInvoiceNumber = string.Empty;

    protected string CustomerCreditLimit = string.Empty;

    protected string CustomerCreditReference = string.Empty;

    protected string CustomerTaxName = string.Empty;

    protected string CustomerCompanyNumber = string.Empty;

    protected string CustomerCompanyType = string.Empty;

    protected string CustomerSalesPerson = string.Empty;

    protected string CustomerProfitMarginPercentage = string.Empty;

    protected string CustomerContactName = string.Empty;

    protected string CustomerTaxRegNumber = string.Empty;

    protected string CustomerAccountOpenedDate = string.Empty;

    protected string CustomerBankCode = string.Empty;

    protected string CustomerBankAccountNumber = string.Empty;

    protected string CustomerAccountName = string.Empty;

    protected string CustomerReferredBy = string.Empty;

    protected string QtyDescription1 = string.Empty;

    protected string QtyDescription2 = string.Empty;

    protected string QtyDescription3 = string.Empty;

    protected string QtyDescription4 = string.Empty;

    protected string ReferredBy = string.Empty;

    protected string ItemStatus = string.Empty;

    protected string JobContact = string.Empty;

    protected string JobContactAddressLabel = string.Empty;

    protected string JobContactAddress1 = string.Empty;

    protected string JobContactAddress2 = string.Empty;

    protected string JobContactAddress3 = string.Empty;

    protected string JobContactAddress4 = string.Empty;

    protected string JobContactAddress5 = string.Empty;

    protected string JobContactAddressCountry = string.Empty;

    protected string JobContactAddressTelephone = string.Empty;

    protected string JobContactAddressFax = string.Empty;

    protected string SupplierCreditLimit = string.Empty;

    protected string SupplierCreditReference = string.Empty;

    protected string SupplierTaxName = string.Empty;

    protected string SupplierCompanyNumber = string.Empty;

    protected string SupplierCompanyType = string.Empty;

    protected string SupplierSalesPerson = string.Empty;

    protected string SupplierProfitMarginPercentage = string.Empty;

    protected string SupplierTaxRegNumber = string.Empty;

    protected string SupplierAccountOpenedDate = string.Empty;

    protected string SupplierBankCode = string.Empty;

    protected string SupplierBankAccountNumber = string.Empty;

    protected string SupplierAccountName = string.Empty;

    protected string SupplierReferredBy = string.Empty;

    protected decimal OrderedWidth;

    protected decimal OrderedHeight;

    protected decimal Productwidth;

    protected decimal ProductHeight;

    protected string OrderTitle = string.Empty;

    protected string OrderStatus = string.Empty;

    protected string OrderedDate = string.Empty;

    protected string PaymentType = string.Empty;

    protected string OrderComments = string.Empty;

    protected string ProductSalesCode = string.Empty;

    protected string ProductPurchaseCode = string.Empty;

    protected string EstimateComments = string.Empty;

    protected string ApprovalStatus = string.Empty;

    protected string PurchaseAddress1 = string.Empty;

    protected string PurchaseNumber = string.Empty;

    protected string RaisedBy = string.Empty;

    protected string RequiredDate = string.Empty;

    protected string PODate = string.Empty;

    protected string PurchaseComments = string.Empty;

    protected string PurchaseRefNo = string.Empty;

    protected string ItemCode = string.Empty;

    protected string POJobNumber = string.Empty;

    protected string PONotes = string.Empty;

    protected string PODescription = string.Empty;

    protected string PurchaseAddress2 = string.Empty;

    protected string PurchaseAddress3 = string.Empty;

    protected string PurchaseAddress4 = string.Empty;

    protected string PurchaseCountry = string.Empty;

    protected string SupplierQuoteNumber = string.Empty;

    protected string SupplierInvoiceNumber = string.Empty;

    protected string CarrierInformation = string.Empty;

    protected string DeliveryTo = string.Empty;

    protected string DeliveryToAccountNumber = string.Empty;

    protected string SupplierInvoiceDate = string.Empty;

    protected string CarrierURL = string.Empty;

    protected int CarrierID;

    protected string CarrierName = string.Empty;

    protected string CarrierAddress1 = string.Empty;

    protected string CarrierAddress2 = string.Empty;

    protected string CarrierAddress3 = string.Empty;

    protected string CarrierAddress4 = string.Empty;

    protected string CarrierAddress5 = string.Empty;

    protected string CarrierCountry = string.Empty;

    protected string CarrierPhone = string.Empty;

    protected string CarrierFax = string.Empty;

    protected string CarrierEmail = string.Empty;

    protected string CarrierAccountNumber = string.Empty;

    protected string RaisedByEmail = string.Empty;

    protected string RaisedByPhone = string.Empty;

    protected string RaisedByFax = string.Empty;

    protected string RaisedByMobile = string.Empty;

    protected string DeliveryAddress1 = string.Empty;

    protected string DeliveryNumber = string.Empty;

    protected string DeliveryDate = string.Empty;

    protected string ShippedTo = string.Empty;

    protected string Carrier = string.Empty;

    protected string DeliveryAddress2 = string.Empty;

    protected string DeliveryAddress3 = string.Empty;

    protected string DeliveryAddress4 = string.Empty;

    protected string DeliveryCountry = string.Empty;

    protected string DeliveryTelephone = string.Empty;

    protected string DeliveryFax = string.Empty;

    protected string DeliveryEmail = string.Empty;

    protected string DeliveryComments = string.Empty;

    protected string DeliveryRefNo = string.Empty;

    protected string ConsignmentNumber = string.Empty;

    protected string DeliveryNoteActualDeliveryDate = string.Empty;

    protected string EstoreOrderNumber = string.Empty;

    protected string EstoreOrderTitle = string.Empty;

    protected string RFQDesc = string.Empty;

    public int CompanyID;

    public long EstimateID;

    public string InvoiceContactName = string.Empty;
    public string InvoiceContEmail = string.Empty;

    public string InvoiceContactId = string.Empty;

    public long EstimateItemID;

    protected int EstID;

    public string PDFKey = string.Empty;

    public string PageType = string.Empty;

    public long TemplateID;

    protected bool IsCustom;

    protected string[] arryTag;

    protected string TagNames = string.Empty;

    protected decimal strFinalTotalPrice1ExTax;

    protected decimal strFinalTotalPrice2ExTax;

    protected decimal strFinalTotalPrice3ExTax;

    protected decimal strFinalTotalPrice4ExTax;

    protected decimal strFinalTotalTaxValue1;

    protected decimal strFinalTotalTaxValue2;

    protected decimal strFinalTotalTaxValue3;

    protected decimal strFinalTotalTaxValue4;

    protected decimal strFinalTotalQuantity1;

    protected decimal strFinalTotalQuantity2;

    protected decimal strFinalTotalQuantity3;

    protected decimal strFinalTotalQuantity4;

    protected decimal strFinalTotalProfitMarginPrice1;

    protected decimal strFinalTotalProfitMarginPrice2;

    protected decimal strFinalTotalProfitMarginPrice3;

    protected decimal strFinalTotalProfitMarginPrice4;

    protected decimal strFinalTotalCostPrice1ExMarkup;

    protected decimal strFinalTotalCostPrice1InMarkup;

    protected decimal strFinalTotalMarkupPrice1;

    protected decimal strFinalTotalGrossProfitPrice1;

    protected decimal strFinalTotalGrossProfitPercentage1;

    protected decimal FinalTotalPrice1ExTax;

    protected decimal FinalTotalPrice2ExTax;

    protected decimal FinalTotalPrice3ExTax;

    protected decimal FinalTotalPrice4ExTax;

    protected decimal FinalTotalTaxValue1;

    protected decimal FinalTotalTaxValue2;

    protected decimal FinalTotalTaxValue3;

    protected decimal FinalTotalTaxValue4;

    protected decimal FinalTotalQuantity1;

    protected decimal FinalTotalQuantity2;

    protected decimal FinalTotalQuantity3;

    protected decimal FinalTotalQuantity4;

    protected decimal FinalTotalProfitMarginPrice1;

    protected decimal FinalTotalProfitMarginPrice2;

    protected decimal FinalTotalProfitMarginPrice3;

    protected decimal FinalTotalProfitMarginPrice4;

    protected decimal FinalTotalCostPrice1ExMarkup;

    protected decimal FinalTotalCostPrice1InMarkup;

    protected decimal FinalTotalMarkupPrice1;

    protected decimal FinalTotalGrossProfitPrice1;

    protected decimal FinalTotalGrossProfitPercentage1;

    protected string objTagItem = string.Empty;

    protected string objValueItem = string.Empty;

    protected string objTypeItem = string.Empty;

    protected Color color;

    private string PDFFileName = string.Empty;

    protected Template objTemplates = new Template();

    protected FontStyle objFontStyle;

    protected string[] arrayAfterBreak;

    protected int isMUltipleItems;

    protected string ispreview = string.Empty;

    protected bool isFirstTime;

    protected int CustomerID;

    protected int AddressID;

    protected string AddressType = string.Empty;

    protected string EstAddress = string.Empty;

    protected string JobcntAddress = string.Empty;

    protected int DeliveryAddressID;

    protected string DeliveryAddressType = string.Empty;

    protected string DeliveryAddress = string.Empty;

    // delivery invoice address
    protected string DeliveryInvoiceAddressLabel = string.Empty;
    protected string DeliveryInvoiceAddress1 = string.Empty;
    protected string DeliveryInvoiceAddress2 = string.Empty;
    protected string DeliveryInvoiceAddress3 = string.Empty;
    protected string DeliveryInvoiceAddress4 = string.Empty;
    protected string DeliveryInvoiceAddress5 = string.Empty;
    protected string DeliveryInvoiceAddressCountry = string.Empty;
    protected string DeliveryInvoiceAddressTelephone = string.Empty;
    protected string DeliveryInvoiceAddressFax = string.Empty;

    protected string EstCreatedDate = string.Empty;

    protected string objValueTag = string.Empty;

    protected int ContactID;

    protected string CreatedByName = string.Empty;

    protected DataTable dtrPBValue;

    protected DataTable dtGeneralTags;

    protected string MainOutworkstrFileName = string.Empty;

    protected string PDFID = string.Empty;

    protected string FooterSpace = string.Empty;

    protected string HeaderSpace = string.Empty;

    protected string PDFName = string.Empty;

    protected string ImageName = string.Empty;

    protected bool flag;

    protected bool flagItem;

    protected bool flagsubItem;

    protected bool footerFlag;

    protected string objTag = string.Empty;

    protected string objValue = string.Empty;

    protected string objType = string.Empty;

    protected int TopSeparator;

    protected int EndSeparator;

    protected int SubItemTopSeparator;

    protected int SubItemEndSeparator;

    protected int IncreasedHeight;

    protected int SingleItemHeight;

    protected int objTop;

    protected int LastItemTopPlusHeight;

    protected int footercount;

    protected int PreviousFooterTop;

    protected decimal TopTotalQty1;

    protected decimal TopTotalQty2;

    protected decimal TopTotalQty3;

    protected decimal TopTotalQty4;

    protected decimal TopTotalSubTotal1;

    protected decimal TopTotalSubTotal2;

    protected decimal TopTotalSubTotal3;

    protected decimal TopTotalSubTotal4;

    protected decimal TopTotalTax1;

    protected decimal TopTotalTax2;

    protected decimal TopTotalTax3;

    protected decimal TopTotalTax4;

    protected decimal TopTotalProfitMarginPrice1;

    protected decimal TopTotalProfitMarginPrice2;

    protected decimal TopTotalProfitMarginPrice3;

    protected decimal TopTotalProfitMarginPrice4;

    protected decimal TopTotalProfitMarginPercentage1;

    protected decimal TopTotalProfitMarginPercentage2;

    protected decimal TopTotalProfitMarginPercentage3;

    protected decimal TopTotalProfitMarginPercentage4;

    protected decimal TopTotalSellingPrice1;

    protected decimal TopTotalSellingPrice2;

    protected decimal TopTotalSellingPrice3;

    protected decimal TopTotalSellingPrice4;

    protected decimal SellingPricePerSQM1;

    protected decimal SellingPricePerSQM2;

    protected decimal SellingPricePerSQM3;

    protected decimal SellingPricePerSQM4;

    protected decimal TopTotalCostPrice1ExMarkup;

    protected decimal TopTotalMarkupPrice1;

    protected decimal TopTotalMarkupPrice2;

    protected decimal TopTotalMarkupPrice3;

    protected decimal TopTotalMarkupPrice4;

    protected decimal TopTotalGrossProfitPrice1;

    protected decimal TopTotalGrossProfitPercentage1;

    protected decimal TotalProductAdditionalOptionsPrice1;

    protected decimal TotalProductAdditionalOptionsPrice2;

    protected decimal TotalProductAdditionalOptionsPrice3;

    protected decimal TotalProductAdditionalOptionsPrice4;

    protected string TotalPricePer1000;

    protected Hashtable htTotQtyNum = new Hashtable();

    protected Hashtable htQtyNum = new Hashtable();

    protected Hashtable htTopTotQtyNum = new Hashtable();

    protected string EstItemType = string.Empty;

    protected int SupCount;

    protected int TotSupCount;

    protected decimal FooterTop;

    protected decimal LastElementHeight;

    protected string WarePartCode = string.Empty;

    protected string WareLocation = string.Empty;

    protected decimal WareCost;

    protected decimal WarePackedIn;

    protected decimal WarePackPrice;

    protected decimal WareWeight;

    public int UserID;

    public bool UnitOfMeasureKey;

    private string strItemTotal = string.Empty;

    private bool isFromReport;

    public long EstItemID;

    public string strMainModuel = string.Empty;

    public string IsFrom = string.Empty;

    private long oldEstimateItemID;

    public string ServerName = string.Empty;

    public string PSupplierID = string.Empty;

    public string PCSupplierID = string.Empty;

    public long jobID;

    public double DeliveryItemTotalCostExMarkup = 0;

    public long InvoiceID;

    public long temp_ordid;

    public long OrdID;

    public string jID = string.Empty;

    public string InvID = string.Empty;

    public string SelectedItems = string.Empty;

    public string ItemIDs = string.Empty;

    public string purchaseitemnumber = string.Empty;

    public string companytype = string.Empty;

    public string estimateitemids = "";

    public string hdnPdf = string.Empty;

    public string hdnisSplit = string.Empty;

    public bool isSplitSubitem = false;

    public bool isGroupingBasedOnStockLocation = false;

    public string hdnisKeepWithPrevious = string.Empty;

    public string isdirect = string.Empty;


    protected Random rGen;

    protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    protected string contactTitle { get; set; }
    private commonClass commclass = new commonClass();

    public pdfGenerate()
    {
    }

    public string AddExtraPagestoPdfIfMainPDFHasLessPagesThenRequiredPages(string sourcePdfPath, int RequiredPages, int FirstPages)
    {
        string str = this.strFilepath;
        Guid guid = Guid.NewGuid();
        string str1 = string.Concat(str, "tempattachment/", guid.ToString().Substring(0, 20), ".pdf");
        PdfReader pdfReader = new PdfReader(sourcePdfPath);
        com.lowagie.text.Rectangle pageSizeWithRotation = pdfReader.getPageSizeWithRotation(1);
        FileStream fileStream = new FileStream(str1, FileMode.Create);
        PdfStamper pdfStamper = null;
        pdfStamper = new PdfStamper(pdfReader, fileStream);
        int num = 0;
        num = (FirstPages <= 1 ? 2 : 1 + FirstPages);
        RequiredPages = RequiredPages - pdfReader.getNumberOfPages();
        for (int i = 0; i < RequiredPages; i++)
        {
            pdfStamper.insertPage(num, pageSizeWithRotation);
            num++;
        }
        pdfStamper.close();
        pdfReader.close();
        return str1;
    }

    public string AddExtraPagestoPdfIfMainPDFHasLessPagesThenRequiredPages_OLD(string sourcePdfPath, int RequiredPages)
    {
        string str = this.strFilepath;
        Guid guid = Guid.NewGuid();
        string str1 = string.Concat(str, "tempattachment/", guid.ToString().Substring(0, 20), ".pdf");
        PdfReader pdfReader = new PdfReader(sourcePdfPath);
        com.lowagie.text.Rectangle pageSizeWithRotation = pdfReader.getPageSizeWithRotation(1);
        FileStream fileStream = new FileStream(str1, FileMode.Create);
        PdfStamper pdfStamper = null;
        pdfStamper = new PdfStamper(pdfReader, fileStream);
        int num = 2;
        RequiredPages = RequiredPages - pdfReader.getNumberOfPages();
        for (int i = 0; i < RequiredPages; i++)
        {
            pdfStamper.insertPage(num, pageSizeWithRotation);
            num++;
        }
        pdfStamper.close();
        pdfReader.close();
        return str1;
    }

    private void ClearSupplierValues()
    {
        this.SupplierName = "";
        this.SupplierAddress1 = "";
        this.SupplierAddress2 = "";
        this.SupplierAddress3 = "";
        this.SupplierAddress4 = "";
        this.SupplierAddress5 = "";
        this.SupplierCountry = "";
        this.SupplierPhone = "";
        this.SupplierFax = "";
        this.SupplierEmail = "";
        this.SupplierPaymentTerms = "";
        this.SupplierWebsite = "";
        this.SupplierAccountNumber = "";
        this.SupplierDescription = "";
        this.SupplierContactSalutation = "";
        this.SupplierContactFirstName = "";
        this.SupplierContactLastName = "";
        this.SupplierContactMiddleName = "";
        this.SupplierContactFullName = "";
        this.SupplierContactDepartment = "";
        this.SupplierContactJobTitle1 = "";
        this.SupplierContactJobTitle2 = "";
        this.SupplierContactBusinessAddressLine1 = "";
        this.SupplierContactBusinessAddressLine2 = "";
        this.SupplierContactBusinessAddressLine3 = "";
        this.SupplierContactBusinessAddressLine4 = "";
        this.SupplierContactBusinessCountry = "";
        this.SupplierContactBusinessTelephone = "";
        this.SupplierContactBusinessFax = "";
        this.SupplierContactBusinessEmail = "";
        this.SupplierContactMobile = "";
        this.SupplierContactCompanyName = "";
    }

    public string ColorFromHexaToRGB(string hexColor)
    {
        if (hexColor.IndexOf('#') != -1)
        {
            hexColor = hexColor.Replace("#", "");
        }
        int num = 0;
        int num1 = 0;
        int num2 = 0;
        if (hexColor.Length == 6)
        {
            num = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            num1 = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            num2 = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
        else if (hexColor.Length == 3)
        {
            string str = hexColor[0].ToString();
            char chr = hexColor[0];
            num = int.Parse(string.Concat(str, chr.ToString()), NumberStyles.AllowHexSpecifier);
            string str1 = hexColor[1].ToString();
            char chr1 = hexColor[1];
            num1 = int.Parse(string.Concat(str1, chr1.ToString()), NumberStyles.AllowHexSpecifier);
            string str2 = hexColor[2].ToString();
            char chr2 = hexColor[2];
            num2 = int.Parse(string.Concat(str2, chr2.ToString()), NumberStyles.AllowHexSpecifier);
        }
        string[] strArrays = new string[] { "rgb(", num.ToString(), ",", num1.ToString(), ",", num2.ToString(), ")" };
        return string.Concat(strArrays);
    }

    public string CreatedBlankPDF(int noofPages)
    {
        string str = this.strFilepath;
        Guid guid = Guid.NewGuid();
        string str1 = string.Concat(str, "tempattachment/", guid.ToString().Substring(0, 20), ".pdf");
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
        ////  PdfWriter.getInstance(document, new FileStream(str1, FileMode.Create));
        iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(str1, FileMode.Create));
        document.Open();
        for (int i = 0; i < noofPages; i++)
        {
            document.Add(new iTextSharp.text.Paragraph(" "));
            document.NewPage();
        }
        document.Close();
        return str1;
    }

    public void DeletePages(string pageRange, string SourcePdfPath, string OutputPdfPath, string Password)
    {
        List<int> nums = new List<int>();
        if (pageRange.IndexOf(",") != -1)
        {
            string[] strArrays = pageRange.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (str.IndexOf("-") == -1)
                {
                    nums.Add(Convert.ToInt32(str));
                }
                else
                {
                    string[] strArrays1 = str.Split(new char[] { '-' });
                    for (int j = Convert.ToInt32(strArrays1[0]); j <= Convert.ToInt32(strArrays1[1]); j++)
                    {
                        nums.Add(j);
                    }
                }
            }
        }
        else if (pageRange.IndexOf("-") == -1)
        {
            nums.Add(Convert.ToInt32(pageRange));
        }
        else
        {
            string[] strArrays2 = pageRange.Split(new char[] { '-' });
            for (int k = Convert.ToInt32(strArrays2[0]); k <= Convert.ToInt32(strArrays2[1]); k++)
            {
                nums.Add(k);
            }
        }
        PdfReader pdfReader = new PdfReader(SourcePdfPath, (new ASCIIEncoding()).GetBytes(Password));
        Document document = new Document(pdfReader.getPageSize(1));
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PdfWriter instance = PdfWriter.getInstance(document, memoryStream);
            document.open();
            document.addDocListener(instance);
            for (int l = 1; l <= pdfReader.getNumberOfPages(); l++)
            {
                if (nums.FindIndex((int s) => s == l) == -1)
                {
                    document.setPageSize(pdfReader.getPageSize(l));
                    document.newPage();
                    PdfContentByte pdfContentByte = instance.directContent;
                    PdfImportedPage importedPage = instance.getImportedPage(pdfReader, l);
                    int pageRotation = pdfReader.getPageRotation(l);
                    if (pageRotation == 90 || pageRotation == 270)
                    {
                        pdfContentByte.addTemplate(importedPage, 0f, -1f, 1f, 0f, 0f, pdfReader.getPageSizeWithRotation(l).height());
                    }
                    else
                    {
                        pdfContentByte.addTemplate(importedPage, 1f, 0f, 0f, 1f, 0f, 0f);
                    }
                }
            }
            pdfReader.close();
            document.close();
            System.IO.File.WriteAllBytes(OutputPdfPath, memoryStream.ToArray());
        }
    }

    public string ExtractPages(string sourcePdfPath, string extractRange)
    {
        string str = this.strFilepath;
        Guid guid = Guid.NewGuid();
        string str1 = string.Concat(str, "tempattachment/", guid.ToString().Substring(0, 20), ".pdf");
        List<int> listInt = pdfGenerate.StringRangeToListInt(extractRange);
        PdfReader pdfReader = new PdfReader(sourcePdfPath, (new ASCIIEncoding()).GetBytes(""));
        Document document = new Document(pdfReader.getPageSize(1));
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PdfWriter instance = PdfWriter.getInstance(document, memoryStream);
            document.open();
            document.addDocListener(instance);
            for (int i = 1; i <= pdfReader.getNumberOfPages(); i++)
            {
                if (listInt.FindIndex((int s) => s == i) != -1)
                {
                    document.setPageSize(pdfReader.getPageSize(i));
                    document.newPage();
                    PdfContentByte pdfContentByte = instance.directContent;
                    PdfImportedPage importedPage = instance.getImportedPage(pdfReader, i);
                    int pageRotation = pdfReader.getPageRotation(i);
                    if (pageRotation == 90 || pageRotation == 270)
                    {
                        pdfContentByte.addTemplate(importedPage, 0f, -1f, 1f, 0f, 0f, pdfReader.getPageSizeWithRotation(i).height());
                    }
                    else
                    {
                        pdfContentByte.addTemplate(importedPage, 1f, 0f, 0f, 1f, 0f, 0f);
                    }
                }
            }
            pdfReader.close();
            document.close();
            System.IO.File.WriteAllBytes(str1, memoryStream.ToArray());
        }
        return str1;
    }

    private void generatePDF(DataTable dt, string PDFID, string FooterSpace, string HeaderSpace, string PDFName, decimal FooterTop, decimal LastElementHeight, int SupCount, int TotSupCount, string ImageName, int OutWorkItemID, int SupplierID, ref bool Main_RetRefforPDFVisible, ref ArrayList Main_ArryList_StrFileName, ref bool Main_RetRefforisFromReport)
    {
        double num = 3.77;
        double num1 = 0;
        double num2 = 0;
        num1 = Convert.ToDouble(FooterSpace) * num;
        num2 = Convert.ToDouble(HeaderSpace) * num;
        this.GeneratePDF(dt, PDFID, num1.ToString(), num2.ToString(), FooterTop, PDFName, SupCount, ImageName, TotSupCount, OutWorkItemID, SupplierID, ref Main_RetRefforPDFVisible, ref Main_ArryList_StrFileName, ref Main_RetRefforisFromReport);
    }

    private void GeneratePDF(DataTable dt, string PDFID, string FooterSpace, string HeaderSpace, decimal FooterTop, string PDFName, int SupCount, string ImageName, int TotSupCount, int OutWorkItemID, int SupplierID, ref bool Main_RetRefforPDFVisible, ref ArrayList Main_ArryList_StrFileName, ref bool Main_RetRefforisFromReport)
    {
        object[] estimateNumber;
        int numberOfPages;
        dt = this.ReturnActualPositionsOfAllTags(dt, PDFID, FooterSpace, HeaderSpace, FooterTop, PDFName, SupCount, ImageName, TotSupCount, OutWorkItemID, SupplierID);

        foreach (DataRow rw in dt.Rows)
        {
            if (rw["objname"].ToString() == "Total No Of Pages")
            {
                rw["repeat"] = "true";
                dt.AcceptChanges();
                rw.SetModified();
            }
        }
        DataRow[] dataRowArray = dt.Select("pagenumber = max(pagenumber)");
        int num = 0;
        if ((int)dataRowArray.Length > 0)
        {
            num = Convert.ToInt32(dataRowArray[0]["pagenumber"]);
        }
        if (num > 1)
        {
            dt = this.RepeatControls(dt, num);
        }
        DataTable firstandLastPagedetails = SettingsBasePage.GetFirstandLastPagedetails(Convert.ToInt32(PDFID));
        int num1 = 0;
        int num2 = 0;
        foreach (DataRow row in firstandLastPagedetails.Rows)
        {
            num1 = Convert.ToInt32(row["FirstPageNo"]);
            num2 = Convert.ToInt32(row["LastPageNo"]);
        }
        FooterTop = Convert.ToDecimal(FooterTop * Convert.ToDecimal(0.75));
        string empty = string.Empty;
        string str = string.Empty;
        string empty1 = string.Empty;
        DataTable dataTable = new DataTable();
        if (this.PageType.ToLower() != "job")
        {
            dataTable = (this.PageType.ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.EstimateID, this.PageType.ToString()) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.InvoiceID, this.PageType.ToString()));
        }
        else
        {
            dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.jobID, this.PageType.ToString());
        }
        foreach (DataRow dataRow in dataTable.Rows)
        {
            this.EstimateNumber = dataRow["Number"].ToString();
            str = dataRow["TemNameLastCounter"].ToString();
        }
        if (this.PageType.ToLower() != "printbroker")
        {
            empty = string.Concat(this.EstimateNumber, "-", str, ".pdf");
            empty1 = string.Concat(this.EstimateNumber, "_", str);
        }
        else
        {
            estimateNumber = new object[] { this.EstimateNumber, "_", OutWorkItemID, "-", SupplierID, "-", str, ".pdf" };
            empty = string.Concat(estimateNumber);
            estimateNumber = new object[] { this.EstimateNumber, "_", OutWorkItemID, "-", SupplierID };
            empty1 = string.Concat(estimateNumber);
        }
        FontFactory.registerDirectory("D:\\inetpub\\vhosts\\eprintsoftware.com\\httpdocs\\LiveDocuments\\document\\SecureDoc\\fonts");
        //FontFactory.registerDirectory("C:\\WINDOWS\\Fonts");
        string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//" };
        if (!Directory.Exists(string.Concat(secureDocPath)))
        {
            secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//" };
            Directory.CreateDirectory(string.Concat(secureDocPath));
        }
        secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//", PDFName.ToString(), ".pdf" };
        string str1 = string.Concat(secureDocPath);
        if (System.IO.File.Exists(str1))
        {
            PdfReader pdfReader = new PdfReader(str1);
            string str2 = "0";
            if (num1 + num2 == 0)
            {
                if (pdfReader.getNumberOfPages() > num)
                {
                    if (num != 1)
                    {
                        string str3 = (num - 1).ToString();
                        numberOfPages = pdfReader.getNumberOfPages();
                        str2 = string.Concat("1-", str3, ",", numberOfPages.ToString());
                        str1 = this.ExtractPages(str1, str2);
                    }
                    else
                    {
                        str2 = "1";
                        str1 = this.ExtractPages(str1, str2);
                    }
                }
                else if (pdfReader.getNumberOfPages() < num)
                {
                    str1 = this.AddExtraPagestoPdfIfMainPDFHasLessPagesThenRequiredPages_OLD(str1, num);
                }
            }
            else if (pdfReader.getNumberOfPages() > num + num1 + num2)
            {
                if (num + num1 + num2 != 1)
                {
                    if (num2 <= 0)
                    {
                        numberOfPages = num + num1;
                        str2 = string.Concat("1-", numberOfPages.ToString());
                    }
                    else
                    {
                        secureDocPath = new string[] { "1-", null, null, null, null, null };
                        numberOfPages = num + num1;
                        secureDocPath[1] = numberOfPages.ToString();
                        secureDocPath[2] = ",";
                        numberOfPages = pdfReader.getNumberOfPages() + 1 - num2;
                        secureDocPath[3] = numberOfPages.ToString();
                        secureDocPath[4] = "-";
                        numberOfPages = pdfReader.getNumberOfPages();
                        secureDocPath[5] = numberOfPages.ToString();
                        str2 = string.Concat(secureDocPath);
                    }
                    str1 = this.ExtractPages(str1, str2);
                }
                else
                {
                    str2 = "1";
                    str1 = this.ExtractPages(str1, str2);
                }
            }
            else if (pdfReader.getNumberOfPages() < num + num1 + num2)
            {
                str1 = this.AddExtraPagestoPdfIfMainPDFHasLessPagesThenRequiredPages(str1, num + num1 + num2, num1);
            }
        }
        else
        {
            str1 = this.CreatedBlankPDF(num);
        }
        PdfReader pdfReader1 = new PdfReader(str1);
        Guid guid = Guid.NewGuid();
        empty = string.Concat(empty1, "_", guid.ToString().Substring(0, 5), ".pdf");
        if (this.isFromReport)
        {
            empty = empty.Replace(this.EstimateNumber, "Invoice-Statement");
        }
        if (this.PageType.ToLower() == "printbroker")
        {
            if (this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] != null)
            {
                estimateNumber = new object[] { OutWorkItemID, "_", SupplierID, "_", this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())].ToString() };
                SettingsBasePage.settings_template_emailed_update(empty, string.Concat(estimateNumber));
            }
        }
        else if (this.isFromReport)
        {
            SettingsBasePage.settings_template_emailed_update(empty, string.Concat(this.PDFKey, this.EstimateID.ToString().Trim()));
        }
        else if (this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] == null)
        {
            SettingsBasePage.settings_template_emailed_update(empty, Convert.ToString(this.Session["NewTempKey0"]));
        }
        else
        {
            SettingsBasePage.settings_template_emailed_update(empty, Convert.ToString(this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())]));
        }
        FileStream fileStream = new FileStream(string.Concat(this.strFilepath, "tempattachment/", empty), FileMode.Create);
        PdfStamper pdfStamper = null;
        pdfStamper = new PdfStamper(pdfReader1, fileStream);
        PdfContentByte overContent = pdfStamper.getOverContent(1);
        int num3 = 1;
        foreach (DataRow row1 in dt.Rows)
        {
            try
            {
                string str4 = row1["objValue"].ToString().Replace("<1linebreak>", "");
                str4 = base.SpecialDecode(str4);
                str4 = str4.Replace("[PageNumber]", num3.ToString());
                string str5 = row1["objName"].ToString();
                string str6 = row1["objType"].ToString();
                string str7 = row1["fontfamily"].ToString();
                string str8 = row1["fontsize"].ToString();
                string str9 = row1["fontweight"].ToString();
                string str10 = row1["fontstyle"].ToString();
                string str11 = row1["left"].ToString();
                string str12 = row1["top"].ToString();
                string str13 = row1["width"].ToString();
                string str14 = row1["height"].ToString();
                string str15 = row1["fontcolor"].ToString();
                string str16 = row1["textdecoration"].ToString();

                // total number of pages on estiamte templae
                //str4 = str4.Replace("[TotalPages]", Convert.ToString(num));
                str4 = str4.Replace("[TotalNoOfPages]", Convert.ToString(num));

                if (row1["textAlign"].ToString().Trim().Length == 0)
                {
                }
                string[] strArrays = str15.Split(new char[] { ',' });
                Convert.ToDouble(str11);
                Convert.ToDouble(str12);
                Convert.ToDouble(str14);
                Convert.ToDouble(str13);
                num3 = Convert.ToInt32(row1["pagenumber"]) + num1;
                overContent = pdfStamper.getOverContent(num3);
                double num4 = Convert.ToDouble(row1["llx"]);
                double num5 = Convert.ToDouble(row1["lly"]);
                double num6 = Convert.ToDouble(row1["urx"]);
                double num7 = Convert.ToDouble(row1["ury"]);
                float single = (float)num4;
                float single1 = (float)num5;
                float single2 = (float)num6;
                float single3 = (float)num7;
                if (str6.Trim().Length > 0)
                {
                    try
                    {
                        if (Convert.ToInt32(str6) == 3 || Convert.ToInt32(str6) == 8 || Convert.ToInt32(str6) == 9 || Convert.ToInt32(str6) == 10 || Convert.ToInt32(str6) == 11 || Convert.ToInt32(str6) == 12 || Convert.ToInt32(str6) == 14 || Convert.ToInt32(str6) == 15 || Convert.ToInt32(str6) == 16)
                        {
                            if (Convert.ToInt32(str6) == 3)
                            {
                                str5 = str5.Replace(this.SecureSitePath, this.SecureDocFilepath);
                                com.lowagie.text.Image instance = com.lowagie.text.Image.getInstance(str5);
                                instance.setAbsolutePosition(single, single1 + 4f);
                                instance.scaleAbsolute(single2 - single, single3 - single1);
                                overContent.addImage(instance);
                            }
                            if (Convert.ToInt32(str6) == 10)
                            {

                                string str17 = AppDomain.CurrentDomain.BaseDirectory + "images\\HRline.jpg";
                                com.lowagie.text.Image image = com.lowagie.text.Image.getInstance(str17);
                                image.setAbsolutePosition(single, single1 + 20f);
                                image.scaleAbsolute(single2 - single, 1f);
                                overContent.addImage(image);

                            }
                        }
                        else if (Convert.ToInt32(str6) != 13)
                        {
                            if (str4.Trim().ToLower().IndexOf("www.paypal.com") != -1)
                            {
                                com.lowagie.text.Image instance1 = com.lowagie.text.Image.getInstance(AppDomain.CurrentDomain.BaseDirectory + "images\\paymentlogo.jpg");
                                instance1.setAnnotation(new Annotation(single, single1, single2, single3, str4.Replace("&amp;", "&").Replace("¤cy_code", "&currency_code")));
                                instance1.setAbsolutePosition(single, single1 + 20f);
                                instance1.scaleAbsolute(single2 - single, single3 - single1);
                                overContent.addImage(instance1);
                            }
                            if (str4.Trim().ToLower().IndexOf("checkout.stripe.com") != -1)
                            {
                                string currency = "";
                                DataTable currencySymbolCurrency = this.objJava.Get_Currency_Company(CompanyID);
                                if (currencySymbolCurrency != null)
                                {
                                    currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
                                }

                                DataTable _dt = this.objTemplates.settings_template_FieldValue_select(CompanyID, this.InvoiceID, "invoice");
                                foreach (DataRow current in _dt.Rows)
                                {
                                    this.InvoiceTitle = current["InvoiceTitle"].ToString();
                                    this.InvoiceNumber = current["InvoiceNumber"].ToString();
                                    this.OrderTotalPrice = this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(current["OrderTotalPrice"].ToString()), 0, "", false, false, true);
                                }
                                string _host = HttpContext.Current.Request.Url.Host.ToString();
                                if (_host.Trim().ToLower() == "localhost" || _host.Trim().ToLower() == "192.168.1.6")
                                {
                                    _host = ConfigurationManager.AppSettings["HostName"].ToString();
                                }
                                DataTable stripeTbl = SettingsBasePage.GetStripeDetails(Convert.ToInt32(CompanyID), _host);
                                string stripeImage = string.Empty;
                                string stripeImagePath = string.Empty;
                                foreach (DataRow dr in stripeTbl.Rows)
                                {
                                    stripeImage = dr["StripeImage"].ToString();
                                    if (!string.IsNullOrEmpty(stripeImage))
                                    {
                                        string[] secureDocPath3 = new string[] { this.SecureDocPath, this.ServerName, "/", CompanyID.ToString(), "/Stripe/", stripeImage };
                                        stripeImagePath = string.Concat(secureDocPath3);
                                    }
                                    else
                                    {
                                        stripeImagePath = AppDomain.CurrentDomain.BaseDirectory + "images/stripe.jpg";
                                    }
                                }
                                //com.lowagie.text.Image instance1 = com.lowagie.text.Image.getInstance(AppDomain.CurrentDomain.BaseDirectory + "images\\stripe.jpg");
                                com.lowagie.text.Image instance1 = com.lowagie.text.Image.getInstance(stripeImagePath);
                                //instance1.setAnnotation(new Annotation(single, single1, single2, single3, str4.Replace("&amp;", "&").Replace("¤cy_code", "&currency_code")));
                                instance1.setAnnotation(new Annotation(single, single1, single2, single3, "" + global.sitePath() + "/StripePaymentHandler.ashx?InvID=" + this.InvoiceID + "&EstimateID=" + _dt.Rows[0]["EstimateID"].ToString() + "&InvoiceNumber=" + this.InvoiceNumber + "&InvoiceTitle=" + this.InvoiceTitle + "&OrderTotalPrice=" + this.OrderTotalPrice + ""));
                                instance1.setAnnotation(new Annotation(single, single1, single2, single3, "" + global.sitePath() + "/StripePaymentHandler.ashx?InvID=" + this.InvoiceID + "&EstimateID=" + _dt.Rows[0]["EstimateID"].ToString() + "&InvoiceNumber=" + this.InvoiceNumber + "&InvoiceTitle=" + this.InvoiceTitle + "&OrderTotalPrice=" + this.OrderTotalPrice + "&Currency=" + (string.IsNullOrEmpty(currency) ? "AUD" : currency + "")));
                                instance1.setAbsolutePosition(single, single1 + 20f);
                                instance1.scaleAbsolute(single2 - single, single3 - single1);
                                overContent.addImage(instance1);
                            }
                            else if (str7.Trim().ToLower().IndexOf("barcode39") != -1)
                            {
                                Barcode128 barcode128 = new Barcode128();
                                try
                                {
                                    str4 = str4.Trim();
                                    barcode128.setCode(str4);
                                    barcode128.setStartStopText(false);
                                    barcode128.setAltText("");
                                    if (str7.Trim().ToLower().IndexOf("extended") != -1)
                                    {
                                        barcode128.setExtended(true);
                                    }
                                    com.lowagie.text.Image image1 = barcode128.createImageWithBarcode(overContent, null, null);
                                    image1.setAbsolutePosition(single, single1 + 20f);
                                    image1.scaleAbsolute(single2 - single, single3 - single1);
                                    overContent.addImage(image1);

                                }

                                catch (Exception exception)
                                {
                                    barcode128.setCode("info");
                                    barcode128.setStartStopText(false);
                                    com.lowagie.text.Image image2 = barcode128.createImageWithBarcode(overContent, null, null);
                                    image2.setAbsolutePosition(single, single1 + 20f);
                                    image2.scaleAbsolute(single2 - single, single3 - single1);
                                    overContent.addImage(image2);
                                }
                            }
                            else if (str5.Trim().ToLower() == "jobestfile")
                            {

                                //string str17 = str4;
                                //com.lowagie.text.Image image = com.lowagie.text.Image.getInstance(string.Concat(this.SecureDocFilepath, this.ServerName, "/", this.CompanyID, "/attachments/", str17));
                                //image.setAbsolutePosition(single, single1 + 20f);
                                //image.scaleAbsolute(single2 - single, single3 - single1);
                                ////image.setAbsolutePosition(single, single1 + 20f);
                                ////image.scaleAbsolute(single2 - single, 1f);
                                ////image.scaleToFit(250f, 250f);
                                //image.scalePercent(75f);
                                //overContent.addImage(image);


                                try
                                {
                                    string str17 = str4;
                                    com.lowagie.text.Image instance2 = com.lowagie.text.Image.getInstance(string.Concat(this.SecureDocFilepath, this.ServerName, "/", this.CompanyID, "/attachments/", str17));
                                    instance2.setDpi(300, 300);
                                    instance2.setAbsolutePosition(single, single1 + 4f);
                                    if (instance2.height() < instance2.width())
                                    {
                                        float single4 = 0f;
                                        single4 = (float)(single2 - single) / instance2.width();
                                        instance2.scalePercent(single4 * 100f);
                                    }
                                    else
                                    {
                                        float single5 = 0f;
                                        single5 = (float)(single3 - single1) / instance2.height();
                                        instance2.scalePercent(single5 * 100f);
                                    }
                                    overContent.addImage(instance2);
                                }
                                catch (Exception ex)
                                {

                                }

                            }
                            else if (str5.Trim().ToLower().IndexOf("product image") == -1)
                            {
                                int num8 = 0;
                                this.objFontStyle = FontStyle.Regular;
                                if (str9.ToLower().Trim() == "bolder" && str10.ToLower().Trim() == "italic")
                                {
                                    num8 = 3;
                                    this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                                }
                                else if (str9.ToLower().Trim() == "bolder" && str10.ToLower().Trim() != "italic")
                                {
                                    num8 = 1;
                                    this.objFontStyle = FontStyle.Bold;
                                }
                                else if (str9.ToLower().Trim() != "bolder" && str10.ToLower().Trim() == "italic")
                                {
                                    num8 = 2;
                                    this.objFontStyle = FontStyle.Italic;
                                }
                                if (str16.Trim().ToLower() == "underline")
                                {
                                    num8 = num8 | 4;
                                    this.objFontStyle = FontStyle.Underline;
                                }
                                if ((int)strArrays.Length <= 0)
                                {
                                    this.color = Color.Black;
                                }
                                else
                                {
                                    try
                                    {
                                        int num9 = Convert.ToInt32(strArrays[0]);
                                        int num10 = Convert.ToInt32(strArrays[1]);
                                        int num11 = Convert.ToInt32(strArrays[2]);
                                        this.color = Color.FromArgb(num9, num10, num11);
                                    }
                                    catch
                                    {
                                        this.color = Color.Black;
                                    }
                                }
                                com.lowagie.text.Font font = FontFactory.getFont(str7, "Cp1252", true, (float)Convert.ToInt32(str8), num8, this.color);


                                font.getBaseFont();
                                font.getCalculatedBaseFont(true);

                                /*System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                                privateFonts.AddFontFile("C:\\Windows\\Fonts\\SketchFlow Print.ttf");
                                System.Drawing.Font font1 = new System.Drawing.Font(privateFonts.Families[0], 12);
                                */

                                System.Drawing.Font font1 = new System.Drawing.Font(str7, (float)Convert.ToInt32(str8), this.objFontStyle, GraphicsUnit.Pixel);
                                int num12 = Convert.ToInt32(row1["textalign"]);
                                if (str5.Trim().ToLower() != "supplierquotedirectlink")
                                {
                                    Phrase phrase = new Phrase(str4, font);
                                    ColumnText columnText = new ColumnText(overContent);
                                    columnText.setSimpleColumn(phrase, single, single1, single2, single3, 0f, num12);
                                    try
                                    {
                                        columnText.go();
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    secureDocPath = new string[] { "~|~" };
                                    string[] strArrays1 = str4.Split(secureDocPath, StringSplitOptions.None);
                                    com.lowagie.text.Anchor anchor = new com.lowagie.text.Anchor(strArrays1[0], font);
                                    anchor.setReference(string.Concat(this.strSitepath, "Supplier/SupplierQuote.aspx?KeyCD=", strArrays1[1]));
                                    anchor.setName("top");
                                    ColumnText columnText1 = new ColumnText(overContent);
                                    columnText1.setSimpleColumn(anchor, single, single1, single2, single3, 0f, num12);
                                    try
                                    {
                                        columnText1.go();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else
                            {
                                //if (str4 != "") //KR added.
                                //{
                                /////////////////////////////////////////////////
                                ///
                                //float width = _width;
                                //float height = _height;

                                //str4 = str4.Replace(this.SecureSitePath, this.SecureDocFilepath);
                                //com.lowagie.text.Image image = com.lowagie.text.Image.getInstance(str4);
                                //float h = image.scaledHeight();
                                //float w = image.scaledWidth();
                                //float scalePercent;
                                //// scale percentage is dependent on whether the image is 
                                //// 'portrait' or 'landscape'        
                                //if (h > w)
                                //{
                                //    // only scale image if it's height is __greater__ than
                                //    // the document's height, accounting for margins
                                //    if (h > height)
                                //    {
                                //        scalePercent = height / h;
                                //        image.setAbsolutePosition(w * scalePercent, h * scalePercent);
                                //    }
                                //}
                                //else
                                //{
                                //    // same for image width        
                                //    if (w > width)
                                //    {
                                //        scalePercent = width / w;
                                //        image.setAbsolutePosition(w * scalePercent, h * scalePercent);
                                //    }
                                //}
                                //image.setAbsolutePosition(single, single1 + 4f);
                                //float single5 = 0f;
                                //single5 = (float)(single3 - single1) / image.height();
                                //image.scalePercent(single5 * 100f);
                                //document.Add(image);



                                str4 = str4.Replace(this.SecureSitePath, this.SecureDocFilepath);
                                com.lowagie.text.Image instance2 = com.lowagie.text.Image.getInstance(str4);
                                instance2.setDpi(300, 300);
                                //instance2.setAbsolutePosition(single, single1 + 4f);
                                if (instance2.height() < instance2.width())
                                {
                                    if (instance2.height() < (instance2.width() / 3))
                                    {
                                        instance2.setAbsolutePosition(single, (single1 + (single3 - single1)) - 10f);
                                    }
                                    if (instance2.height() < (instance2.width() / 2) && instance2.height() > (instance2.width() / 3))
                                    {
                                        instance2.setAbsolutePosition(single, (single1 + (single3 - single1)) - 70f);
                                    }
                                    if (instance2.height() > (instance2.width() / 2))
                                    {
                                        //instance2.setAbsolutePosition(single, (single1 + (single3 - single1)) - 100f);
                                        instance2.setAbsolutePosition(single, single1 + 4f);
                                    }
                                    float single5 = 0f;
                                    single5 = (float)(single2 - single) / instance2.width();
                                    instance2.scalePercent(single5 * 100f);
                                }
                                else
                                {
                                    instance2.setAbsolutePosition(single, single1 + 4f);
                                    float single5 = 0f;
                                    single5 = (float)(single3 - single1) / instance2.height();
                                    instance2.scalePercent(single5 * 100f);

                                }

                                overContent.addImage(instance2);
                                //}
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        pdfStamper.close();
        pdfReader1.close();

     


        if (this.PageType.ToLower() != "printbroker")
        {
            Main_ArryList_StrFileName.Add(empty);
            this.hdnPdf = empty;
            if (this.isFromReport)
            {
                Main_RetRefforisFromReport = true;
                return;
            }
            Main_RetRefforPDFVisible = true;
        }
        else
        {
            Main_ArryList_StrFileName.Add(empty);
            if (this.PSupplierID == this.PCSupplierID)
            {
                this.MainOutworkstrFileName = empty;
            }
            if (SupCount == TotSupCount)
            {
                this.hdnPdf = this.MainOutworkstrFileName;
                Main_RetRefforPDFVisible = true;
                return;
            }
        }
    }

  

    // test code font
    //public static iTextSharp.text.Font GetTahoma()
    //{
    //    var fontName = "Tahoma";
    //    if (!FontFactory.register(fontName))
    //    {
    //        var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
    //        FontFactory.Register(fontPath);
    //    }
    //    return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    //}
    public new string GenPassWithCap(int i)
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

    private string GetCarrierAddress(int CompanyID, int CarrierID, string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            foreach (DataRow row in this.objTemplates.templates_company_client_address_select(CompanyID, CarrierID).Rows)
            {
                this.CarrierName = row["ClientName"].ToString();
                this.CarrierAddressLabel = row["BusinessAddressLabel"].ToString();
                this.CarrierAddress1 = row["BusinessAddressLine1"].ToString();
                this.CarrierAddress2 = row["BusinessAddressLine2"].ToString();
                this.CarrierAddress3 = row["BusinessAddressLine3"].ToString();
                this.CarrierAddress4 = row["BusinessAddressLine4"].ToString();
                this.CarrierAddress5 = row["BusinessAddressLine5"].ToString();
                this.CarrierCountry = row["BusinessCountry"].ToString();
                this.CarrierPhone = row["BusinessTelephone"].ToString();
                this.CarrierFax = row["fax"].ToString();
                this.CarrierEmail = row["BusinessEmail"].ToString();
            }
            objValue = objValue.Replace("[CarrierName]", this.CarrierName);
            objValue = objValue.Replace("[CarrierAddressLabel]", this.CarrierAddressLabel);
            objValue = objValue.Replace("[CarrierAddress1]", this.CarrierAddress1);
            objValue = objValue.Replace("[CarrierAddress2]", this.CarrierAddress2);
            objValue = objValue.Replace("[CarrierAddress3]", this.CarrierAddress3);
            objValue = objValue.Replace("[CarrierAddress4]", this.CarrierAddress4);
            objValue = objValue.Replace("[CarrierAddress5]", this.CarrierAddress5);
            objValue = objValue.Replace("[CarrierAddressCountry]", this.CarrierCountry);
            objValue = objValue.Replace("[CarrierAddressPhone]", this.CarrierPhone);
            objValue = objValue.Replace("[CarrierAddressFax]", this.CarrierFax);
            objValue = objValue.Replace("[CarrierEmail]", this.CarrierEmail);
        }
        return objValue;
    }

    private string GetCompanyAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[CompanyName]", this.CompanyName).Replace("[CompanyName]", this.CompanyName);
            objValue = objValue.Replace("[MyCompanyAddress1]", this.MyCompanyAddress1).Replace("[MyCompanyAddress1]", this.MyCompanyAddress1);
            objValue = objValue.Replace("[MyCompanyAddress2]", this.MyCompanyAddress2).Replace("[MyCompanyAddress2]", this.MyCompanyAddress2);
            objValue = objValue.Replace("[MyCompanyAddress3]", this.MyCompanyAddress3).Replace("[MyCompanyAddress3]", this.MyCompanyAddress3);
            objValue = objValue.Replace("[MyCompanyAddress4]", this.MyCompanyAddress4).Replace("[MyCompanyAddress4]", this.MyCompanyAddress4);
            objValue = objValue.Replace("[MyCompanyAddressCountry]", this.MyCompanyCountry).Replace("[MyCompanyCountry]", this.MyCompanyCountry);
            objValue = objValue.Replace("[MyCompanyEmail]", this.MyCompanyEmail).Replace("[MyCompanyEmail]", this.MyCompanyEmail);
            objValue = objValue.Replace("[MyCompanyAddressFax]", this.MyCompanyFax).Replace("[MyCompanyFax]", this.MyCompanyFax);
            objValue = objValue.Replace("[MyCompanyName]", this.MyCompanyName).Replace("[MyCompanyName]", this.MyCompanyName);
            objValue = objValue.Replace("[MyCompanyNumber]", this.MyCompanyNumber).Replace("[MyCompanyNumber]", this.MyCompanyNumber);
            objValue = objValue.Replace("[MyCompanyAddressPhone]", this.MyCompanyPhone).Replace("[MyCompanyPhone]", this.MyCompanyPhone);
            objValue = objValue.Replace("[MyCompanyTaxNumber]", this.MyCompanyTaxNumber).Replace("[MyCompanyTaxNumber]", this.MyCompanyTaxNumber);
            objValue = objValue.Replace("[MyCompanyURL]", this.MyCompanyURL).Replace("[MyCompanyURL]", this.MyCompanyURL);
        }
        return objValue;
    }

    private string GetContactAddress(string objValue, int CompanyID, int ContactID)
    {
        if (objValue.IndexOf('[') > -1)
        {
            string str = CompanyBasePage.company_contact_address_select(CompanyID, ContactID);
            string empty = string.Empty;
            string empty1 = string.Empty;
            string[] strArrays = str.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (strArrays1[0].ToString().Trim() == "Address")
                {
                    empty = strArrays1[1].ToString();
                }
            }
            objValue = objValue.Replace("[ContactAddress]", empty);
        }
        return objValue;
    }

    private string GetCustomerAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[CustomerAddress1]", this.CustomerAddress1).Replace("[CustomerAddress 1]", this.CustomerAddress1);
            objValue = objValue.Replace("[CustomerAddress2]", this.CustomerAddress2).Replace("[CustomerAddress 2]", this.CustomerAddress2);
            objValue = objValue.Replace("[CustomerAddress3]", this.CustomerAddress3).Replace("[CustomerAddress 3]", this.CustomerAddress3);
            objValue = objValue.Replace("[CustomerAddress4]", this.CustomerAddress4).Replace("[CustomerAddress4]", this.CustomerAddress4);
            objValue = objValue.Replace("[CustomerAddressCountry]", this.CustomerCountry).Replace("[CustomerCountry]", this.CustomerCountry);
            objValue = objValue.Replace("[CustomerEmail]", this.CustomerEmail).Replace("[CustomerEmail]", this.CustomerEmail);
            objValue = objValue.Replace("[CustomerAddressFax]", this.CustomerFax).Replace("[CustomerFax]", this.CustomerFax);
            objValue = objValue.Replace("[CustomerName]", this.CustomerName).Replace("[CustomerName]", this.CustomerName);
            objValue = objValue.Replace("[CustomerAddressPhone]", this.CustomerPhone).Replace("[CustomerPhone]", this.CustomerPhone);
            objValue = objValue.Replace("[CustomerWebsite]", this.CustomerWebsite).Replace("[CustomerWebsite]", this.CustomerWebsite);
            objValue = objValue.Replace("[CustomerPaymentTerms]", this.PaymentTerms).Replace("[CustomerPaymentTerms]", this.PaymentTerms);
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            this.TodaysDate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
            this._todaysDate = now.ToString();
            objValue = objValue.Replace("[TodayDate]", this.TodaysDate).Replace("[TodayDate]", this.TodaysDate);
            //objValue = objValue.Replace("[TodaysDateDay]", this.TodaysDate).Replace("[TodaysDateDay]", this.TodaysDate);
            objValue = objValue.Replace("[TodaysDateDay]", ReturnFullDayAndDate(this.TodaysDate, this._todaysDate));
            objValue = objValue.Replace("[TodaysDateDayABV]", ReturnShortDayAndDate(this.TodaysDate, this._todaysDate));
            objValue = objValue.Replace("[CustomerAccountStatus]", this.AccountStatus).Replace("[AccountStatus]", this.AccountStatus);
            objValue = objValue.Replace("[CustomerDescription]", this.CustomerDescription);
            objValue = objValue.Replace("[InvoiceContact]", string.IsNullOrEmpty(this.InvoiceContactName) ? this.InvoiceContact : this.InvoiceContactName);
            objValue = objValue.Replace("[InvoiceContactEmail]", String.IsNullOrEmpty(this.InvoiceContEmail) ? this.InvoiceContactEmail : this.InvoiceContEmail);

            objValue = objValue.Replace("[CRMTaxRate]", this.CRMTaxRate);
        }
        return objValue;
    }

    private void GetCustomerandCompanyAddressFromDataBase(int CompanyID, int CustomerID)
    {
        foreach (DataRow row in CompanyBasePage.company_client_select(CompanyID, CustomerID, "Customer").Rows)
        {
            this.CustomerAddress1 = row["BusinessAddressLine1"].ToString();
            this.CustomerAddress2 = row["BusinessAddressLine2"].ToString();
            this.CustomerAddress3 = row["BusinessAddressLine3"].ToString();
            this.CustomerAddress4 = row["BusinessAddressLine4"].ToString();
            this.CustomerCountry = row["BusinessCountry"].ToString();
            this.CustomerEmail = row["BusinessEmail"].ToString();
            this.CustomerFax = row["fax"].ToString();
            this.CustomerName = row["clientName"].ToString();
            this.CustomerPhone = row["BusinessTelephone"].ToString();
            this.CustomerWebsite = row["WebSite"].ToString();
            this.PaymentTerms = row["PaymentTermName"].ToString();
            this.TodaysDate = row["TodaysDate"].ToString();
            this.AccountStatus = row["AccountStatusName"].ToString();
            this.CustomerDescription = row["CustomerDescription"].ToString();
            this.InvoiceContact = row["InvoiceContact"].ToString();
            if (this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice")
            {
                this.InvoiceContact = row["InvoiceContactName"].ToString();
                this.InvoiceContactEmail = row["InvoiceContactEmail"].ToString();
            }

            this.CRMTaxRate = Convert.ToString(row["CRMTaxRate"]);
        }
        foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(CompanyID).Rows)
        {
            this.CompanyName = dataRow["CompanyName"].ToString();
            this.MyCompanyAddress1 = dataRow["AddressLine1"].ToString();
            this.MyCompanyAddress2 = dataRow["AddressLine2"].ToString();
            this.MyCompanyAddress3 = dataRow["AddressLine3"].ToString();
            this.MyCompanyAddress4 = dataRow["PostalCode"].ToString();
            this.MyCompanyCountry = dataRow["Country"].ToString();
            this.MyCompanyEmail = dataRow["Email"].ToString();
            this.MyCompanyFax = dataRow["Fax"].ToString();
            this.MyCompanyName = dataRow["CompanyName"].ToString();
            this.MyCompanyNumber = dataRow["CompanyNumber"].ToString();
            this.MyCompanyPhone = dataRow["Telephone"].ToString();
            this.MyCompanyTaxNumber = dataRow["TaxNumber"].ToString();
            this.MyCompanyURL = dataRow["URL"].ToString();
        }
    }

    private void GetInvoiceContactFromDataBase(int CompanyID, int EstimateID, int invoiceid)
    {
        if (EstimateID != 0)
        {
            foreach (DataRow row in CompanyBasePage.company_InvoiceContact_select(CompanyID, EstimateID, "estid").Rows)
            {
                this.InvoiceContactName = row["InvoiceContactName"].ToString();
                this.InvoiceContEmail = row["InvoiceContactEmail"].ToString();
                this.InvoiceContactId = row["InvoiceContactId"].ToString();

            }
        }
        else
        {
            foreach (DataRow row in CompanyBasePage.company_InvoiceContact_select(CompanyID, invoiceid, "invid").Rows)
            {
                this.InvoiceContactName = row["InvoiceContactName"].ToString();
                this.InvoiceContEmail = row["InvoiceContactEmail"].ToString();
                this.InvoiceContactId = row["InvoiceContactId"].ToString();

            }
        }

    }

    private void GetCustomerContactAddressFromDataBase(int CompanyID, int ContactID)
    {
        foreach (DataRow row in this.objTemplates.settings_template_ContactInfo(CompanyID, ContactID).Rows)
        {
            this.CustomerContactSalutation = row["ContactSalutation"].ToString();
            this.CustomerContactFirstName = row["ContactFirstName"].ToString();
            this.CustomerContactLastName = row["ContactLastName"].ToString();
            this.CustomerContactMiddleName = row["ContactMiddleName"].ToString();
            this.CustomerContactFullName = row["ContactFullName"].ToString();
            this.CustomerContactDepartment = row["ContactDepartment"].ToString();
            this.CustomerContactJobTitle1 = row["ContactJobTitle1"].ToString();
            this.CustomerContactJobTitle2 = row["ContactJobTitle2"].ToString();
            if (this.PageType.ToLower() == "note" || this.PageType.ToLower() == "webstoreorder")
            {
                this.CustomerContactAddressLabel = row["ContactBusinessAddressLabel"].ToString();
                this.CustomerContactBusinessAddressLine1 = row["ContactBusinessAddressLine1"].ToString();
                this.CustomerContactBusinessAddressLine2 = row["ContactBusinessAddressLine2"].ToString();
                this.CustomerContactBusinessAddressLine3 = row["ContactBusinessAddressLine3"].ToString();
                this.CustomerContactBusinessAddressLine4 = row["ContactBusinessAddressLine4"].ToString();
                this.CustomerContactBusinessAddressLine5 = row["ContactBusinessAddressLine5"].ToString();
                this.CustomerContactBusinessCountry = row["ContactBusinessCountry"].ToString();
                this.CustomerContactBusinessTelephone = row["ContactBusinessTelephone"].ToString();
                this.CustomerContactBusinessFax = row["ContactBusinessFax"].ToString();
            }
            this.CustomerContactBusinessEmail = row["ContactBusinessEmail"].ToString();
            this.CustomerContactPhone = row["CustomerContactPhone"].ToString();
            this.CustomerContactPersonalFax = row["CustomerContactPersonalFax"].ToString();
            this.CustomerContactMobile = row["ContactMobile"].ToString();
        }
    }

    private string GetCustomerContactAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[CustomerContactSalutation]", this.CustomerContactSalutation);
            objValue = objValue.Replace("[CustomerContactFirstName]", this.CustomerContactFirstName);
            objValue = objValue.Replace("[CustomerContactLastName]", this.CustomerContactLastName);
            objValue = objValue.Replace("[CustomerContactMiddleName]", this.CustomerContactMiddleName);
            objValue = objValue.Replace("[CustomerContactFullName]", this.CustomerContactFullName);
            objValue = objValue.Replace("[CustomerContactDepartment]", this.CustomerContactDepartment);
            objValue = objValue.Replace("[CustomerContactJobTitle1]", this.CustomerContactJobTitle1);
            objValue = objValue.Replace("[CustomerContactJobTitle2]", this.CustomerContactJobTitle2);
            if (this.PageType.ToLower() == "note" || this.PageType.ToLower() == "webstoreorder")
            {
                objValue = objValue.Replace("[CustomerContactAddressLabel]", this.CustomerContactAddressLabel);
                objValue = objValue.Replace("[CustomerContactAddressLine1]", this.CustomerContactBusinessAddressLine1);
                objValue = objValue.Replace("[CustomerContactAddressLine2]", this.CustomerContactBusinessAddressLine2);
                objValue = objValue.Replace("[CustomerContactAddressLine3]", this.CustomerContactBusinessAddressLine3);
                objValue = objValue.Replace("[CustomerContactAddressLine4]", this.CustomerContactBusinessAddressLine4);
                objValue = objValue.Replace("[CustomerContactAddressLine5]", this.CustomerContactBusinessAddressLine5);
                objValue = objValue.Replace("[CustomerContactAddressCountry]", this.CustomerContactBusinessCountry);
                objValue = objValue.Replace("[CustomerContactAddressTelephone]", this.CustomerContactBusinessTelephone);
                objValue = objValue.Replace("[CustomerContactAddressFax]", this.CustomerContactBusinessFax);
            }
            objValue = objValue.Replace("[CustomerContactEmail]", this.CustomerContactBusinessEmail);
            objValue = objValue.Replace("[CustomerContactMobile]", this.CustomerContactMobile);
            objValue = objValue.Replace("[CustomerContactPhone]", this.CustomerContactPhone);
            objValue = objValue.Replace("[CustomerContactPersonalFax]", this.CustomerContactPersonalFax);
        }
        return objValue;
    }

    private string GetDeliveryAddress(string objValue, int CompanyID, long EstimateID, int DeliveryAddressID, string DeliveryAddressType, string DeliveryAddress)
    {
        if (objValue.IndexOf('[') > -1)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            if (this.PageType.ToLower() == "note")
            {
                if (DeliveryAddressType.ToLower() != "r")
                {
                    DeliveryAddressType = "a";
                }
                if (DeliveryAddressType.ToLower() == "a" && DeliveryAddress != "")
                {
                    string[] strArrays = DeliveryAddress.Split(new char[] { '±' });
                    this.DeliveryAddressLabel = strArrays[0].ToString();
                    this.DeliveryAddressEmail = strArrays[9].ToString();
                    empty = strArrays[1].ToString();
                    str = strArrays[2].ToString();
                    empty1 = strArrays[3].ToString();
                    str1 = strArrays[4].ToString();
                    empty2 = strArrays[5].ToString();
                    str2 = strArrays[6].ToString();
                    empty3 = strArrays[7].ToString();
                    str3 = strArrays[8].ToString();
                    empty4 = strArrays[9].ToString();
                    str4 = strArrays[10].ToString();
                }
            }
            else if (this.PageType.ToLower() != "note")
            {
                if (this.PageType.ToLower() == "purchase" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice")
                {
                    DataTable dataTable = new DataTable();
                    dataTable = this.objTemplates.templates_company_additional_address_select(CompanyID, DeliveryAddressID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.DeliveryAddressLabel = row["AddressLabel"].ToString();
                        this.DeliveryAddressEmail = row["Email"].ToString();
                        empty = row["Address"].ToString();
                        str = row["AddressLine2"].ToString();
                        empty1 = row["City"].ToString();
                        str1 = row["State"].ToString();
                        empty2 = row["ZipCode"].ToString();
                        str2 = row["Country"].ToString();
                        empty3 = row["Telephone"].ToString();
                        str3 = row["Fax"].ToString();
                        empty4 = row["Email"].ToString();
                        str4 = row["DeliveryCompanyName"].ToString();
                    }
                    if (this.PageType.ToLower() == "purchase")
                    {
                        DataTable pODeliveryAddress = PurchaseBasePage.getPODeliveryAddress(CompanyID, EstimateID, (long)DeliveryAddressID, DeliveryAddressType, EstimateID);
                        if (pODeliveryAddress.Rows.Count > 0)
                        {
                            DeliveryAddressType = pODeliveryAddress.Rows[0]["POAddress"].ToString();
                        }
                    }
                }
                else
                {
                    DataTable dataTable1 = new DataTable();
                    dataTable1 = EstimateBasePage.Estimate_DeliveryAddressID_Select(CompanyID, EstimateID, this.PageType.ToLower());
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        DeliveryAddressID = Convert.ToInt32(dataRow["DeliveryAddress"].ToString());
                        DeliveryAddressType = dataRow["DeliveryAddressType"].ToString();
                        this.DeliveryAddressLabel = dataRow["AddressLabel"].ToString();
                        this.DeliveryAddressEmail = dataRow["Email"].ToString();
                        empty = dataRow["Address"].ToString();
                        str = dataRow["AddressLine2"].ToString();
                        empty1 = dataRow["City"].ToString();
                        str1 = dataRow["State"].ToString();
                        empty2 = dataRow["ZipCode"].ToString();
                        str2 = dataRow["Country"].ToString();
                        empty3 = dataRow["Telephone"].ToString();
                        str3 = dataRow["Fax"].ToString();
                        empty4 = dataRow["Email"].ToString();
                    }
                }
            }
            if (DeliveryAddressType.ToLower() == "r")
            {
                foreach (DataRow row1 in this.objTemplates.templates_company_address_select(CompanyID).Rows)
                {
                    empty = row1["Address"].ToString();
                    str = row1["City"].ToString();
                    empty1 = row1["AddressLine3"].ToString();
                    str1 = row1["Zip"].ToString();
                    empty2 = "";
                    str2 = row1["Country"].ToString();
                    empty3 = row1["Telephone"].ToString();
                    str3 = row1["Fax"].ToString();
                    empty4 = row1["MarketingEmail"].ToString();
                    str4 = row1["companyName"].ToString();
                }
            }
            objValue = objValue.Replace("[DeliveryAddressLabel]", this.DeliveryAddressLabel);
            objValue = objValue.Replace("[DeliveryAddressEmail]", this.DeliveryAddressEmail);
            objValue = objValue.Replace("[DeliveryAddress1]", empty);
            objValue = objValue.Replace("[DeliveryAddress2]", str);
            objValue = objValue.Replace("[DeliveryAddress3]", empty1);
            objValue = objValue.Replace("[DeliveryAddress4]", str1);
            objValue = objValue.Replace("[DeliveryAddress5]", empty2);
            objValue = objValue.Replace("[DeliveryAddressCountry]", str2);
            objValue = objValue.Replace("[DeliveryAddressTelephone]", empty3);
            objValue = objValue.Replace("[DeliveryAddressFax]", str3);
            objValue = objValue.Replace("[DeliveryEmail]", empty4);
            objValue = objValue.Replace("[DeliveryAddressCompanyName]", str4);
        }
        return objValue;
    }

    private void GetEstimateJobInvoicePurchaseDeliveryAddressFromDataBase(int CompanyID, int AddressID, string AddressType, string EstAddress)
    {
        string empty = string.Empty;
        empty = EstAddress;
        if (empty != "")
        {
            string[] strArrays = empty.Replace("<br />", "±").Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                this.EstimateAddressLabel = strArrays[0].ToString();
                this.EstimateAddress1 = strArrays[1].ToString();
                this.EstimateAddress2 = strArrays[2].ToString();
                this.EstimateAddress3 = strArrays[3].ToString();
                this.EstimateAddress4 = strArrays[4].ToString();
                this.EstimateAddress5 = strArrays[5].ToString();
                this.EstimateCountry = strArrays[6].ToString();
                this.EstimateTelephone = strArrays[7].ToString();
                this.EstimateFax = strArrays[8].ToString();
            }
        }
        string jobcntAddress = string.Empty;
        jobcntAddress = this.JobcntAddress;
        if (jobcntAddress != "")
        {
            string[] strArrays1 = jobcntAddress.Replace("<br />", "±").Split(new char[] { '±' });
            for (int j = 0; j < (int)strArrays1.Length; j++)
            {
                this.JobContactAddressLabel = strArrays1[0].ToString();
                this.JobContactAddress1 = strArrays1[1].ToString();
                this.JobContactAddress2 = strArrays1[2].ToString();
                this.JobContactAddress3 = strArrays1[3].ToString();
                this.JobContactAddress4 = strArrays1[4].ToString();
                this.JobContactAddress5 = strArrays1[5].ToString();
                this.JobContactAddressCountry = strArrays1[6].ToString();
                this.JobContactAddressTelephone = strArrays1[7].ToString();
                this.JobContactAddressFax = strArrays1[8].ToString();
            }
        }
    }

    private string GetEstimateJobInvoicePurchaseDeliveryAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[CustomerContactAddressLabel]", this.EstimateAddressLabel);
            objValue = objValue.Replace("[CustomerContactAddressLine1]", this.EstimateAddress1);
            objValue = objValue.Replace("[CustomerContactAddressLine2]", this.EstimateAddress2);
            objValue = objValue.Replace("[CustomerContactAddressLine3]", this.EstimateAddress3);
            objValue = objValue.Replace("[CustomerContactAddressLine4]", this.EstimateAddress4);
            objValue = objValue.Replace("[CustomerContactAddressLine5]", this.EstimateAddress5);
            objValue = objValue.Replace("[CustomerContactAddressCountry]", this.EstimateCountry);
            objValue = objValue.Replace("[CustomerContactAddressTelephone]", this.EstimateTelephone);
            objValue = objValue.Replace("[CustomerContactAddressFax]", this.EstimateFax);
            objValue = objValue.Replace("[SupplierContactAddressLabel]", this.EstimateAddressLabel);
            objValue = objValue.Replace("[SupplierContactAddressLine1]", this.EstimateAddress1);
            objValue = objValue.Replace("[SupplierContactAddressLine2]", this.EstimateAddress2);
            objValue = objValue.Replace("[SupplierContactAddressLine3]", this.EstimateAddress3);
            objValue = objValue.Replace("[SupplierContactAddressLine4]", this.EstimateAddress4);
            objValue = objValue.Replace("[SupplierContactAddressLine5]", this.EstimateAddress5);
            objValue = objValue.Replace("[SupplierContactAddressCountry]", this.EstimateCountry);
            objValue = objValue.Replace("[SupplierContactAddressTelephone]", this.EstimateTelephone);
            objValue = objValue.Replace("[SupplierContactAddressFax]", this.EstimateFax);
            objValue = objValue.Replace("[EstimateAddress1]", this.EstimateAddress1);
            objValue = objValue.Replace("[EstimateAddress2]", this.EstimateAddress2);
            objValue = objValue.Replace("[EstimateAddress3]", this.EstimateAddress3);
            objValue = objValue.Replace("[EstimateAddress4]", this.EstimateAddress4);
            objValue = objValue.Replace("[EstimateAddress5]", this.EstimateAddress5);
            objValue = objValue.Replace("[EstimateAddressCountry]", this.EstimateCountry);
            objValue = objValue.Replace("[EstimateAddressTelephone]", this.EstimateTelephone);
            objValue = objValue.Replace("[EstimateAddressFax]", this.EstimateFax);


            // delivery invoice address
            if ((this.PageType.ToLower() == "note") && (this.EstimateAddress1 == "" && this.EstimateAddress2 == "" && this.EstimateAddress3 == "" && this.EstimateAddress4 == "" && this.EstimateAddress5 == "" && this.EstimateCountry == "" && this.EstimateTelephone == "" && this.EstimateFax == ""))
            {
                objValue = objValue.Replace("[InvoiceAddressLabel]", this.DeliveryInvoiceAddressLabel);
                objValue = objValue.Replace("[InvoiceAddress1]", this.DeliveryInvoiceAddress1);
                objValue = objValue.Replace("[InvoiceAddress2]", this.DeliveryInvoiceAddress2);
                objValue = objValue.Replace("[InvoiceAddress3]", this.DeliveryInvoiceAddress3);
                objValue = objValue.Replace("[InvoiceAddress4]", this.DeliveryInvoiceAddress4);
                objValue = objValue.Replace("[InvoiceAddress5]", this.DeliveryInvoiceAddress5);
                objValue = objValue.Replace("[InvoiceAddressCountry]", this.DeliveryInvoiceAddressCountry);
                objValue = objValue.Replace("[InvoiceAddressTelephone]", this.DeliveryInvoiceAddressTelephone);
                objValue = objValue.Replace("[InvoiceAddressFax]", this.DeliveryInvoiceAddressFax);
            }
            else
            {
                objValue = objValue.Replace("[InvoiceAddressLabel]", this.EstimateAddressLabel);
                objValue = objValue.Replace("[InvoiceAddress1]", this.EstimateAddress1);
                objValue = objValue.Replace("[InvoiceAddress2]", this.EstimateAddress2);
                objValue = objValue.Replace("[InvoiceAddress3]", this.EstimateAddress3);
                objValue = objValue.Replace("[InvoiceAddress4]", this.EstimateAddress4);
                objValue = objValue.Replace("[InvoiceAddress5]", this.EstimateAddress5);
                objValue = objValue.Replace("[InvoiceAddressCountry]", this.EstimateCountry);
                objValue = objValue.Replace("[InvoiceAddressTelephone]", this.EstimateTelephone);
                objValue = objValue.Replace("[InvoiceAddressFax]", this.EstimateFax);
            }
            objValue = objValue.Replace("[JobAddress1]", this.EstimateAddress1);
            objValue = objValue.Replace("[JobAddress2]", this.EstimateAddress2);
            objValue = objValue.Replace("[JobAddress3]", this.EstimateAddress3);
            objValue = objValue.Replace("[JobAddress4]", this.EstimateAddress4);
            objValue = objValue.Replace("[JobAddress5]", this.EstimateAddress5);
            objValue = objValue.Replace("[JobAddressCountry]", this.EstimateCountry);
            objValue = objValue.Replace("[JobAddressTelephone]", this.EstimateTelephone);
            objValue = objValue.Replace("[JobAddressFax]", this.EstimateFax);
            objValue = objValue.Replace("[PurchaseAddress1]", this.EstimateAddress1);
            objValue = objValue.Replace("[PurchaseAddress2]", this.EstimateAddress2);
            objValue = objValue.Replace("[PurchaseAddress3]", this.EstimateAddress3);
            objValue = objValue.Replace("[PurchaseAddress4]", this.EstimateAddress4);
            objValue = objValue.Replace("[PurchaseAddress5]", this.EstimateAddress5);
            objValue = objValue.Replace("[PurchaseAddressCountry]", this.EstimateCountry);
            objValue = objValue.Replace("[PurchaseAddressTelephone]", this.EstimateTelephone);
            objValue = objValue.Replace("[PurchaseAddressFax]", this.EstimateFax);
            objValue = objValue.Replace("[JobContact]", this.JobContact);
            objValue = objValue.Replace("[JobContactAddressLabel]", this.JobContactAddressLabel);
            objValue = objValue.Replace("[JobContactAddress1]", this.JobContactAddress1);
            objValue = objValue.Replace("[JobContactAddress2]", this.JobContactAddress2);
            objValue = objValue.Replace("[JobContactAddress3]", this.JobContactAddress3);
            objValue = objValue.Replace("[JobContactAddress4]", this.JobContactAddress4);
            objValue = objValue.Replace("[JobContactAddress5]", this.JobContactAddress5);
            objValue = objValue.Replace("[JobContactAddressCountry]", this.JobContactAddressCountry);
            objValue = objValue.Replace("[JobContactAddressTelephone]", this.JobContactAddressTelephone);
            objValue = objValue.Replace("[JobContactAddressFax]", this.JobContactAddressFax);
        }
        return objValue;
    }

    private void GetGeneralInformationFromDataBase(int CompanyID, long ID, string ModuleName)
    {
        DataTable dataTable = this.objTemplates.settings_template_FieldValue_select(CompanyID, ID, ModuleName,
                base.Session["TemplateID"] != null ? Convert.ToString(base.Session["TemplateID"]) : ""
            );

        string OrderCBM = "0.000";
        string OrderWeight = "0.000";

        if (dataTable.Rows.Count > 0)
        {
            OrderCBM = Convert.ToDecimal(dataTable.Compute("SUM(OrderCBM)", string.Empty)).ToString("0.###");
            OrderWeight = Convert.ToDecimal(dataTable.Compute("SUM(OrderWeight)", string.Empty)).ToString("0.###");
        }

        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            if (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                this.Greeting = current["Greeting"].ToString();
                this.Header = current["Header"].ToString();
                this.Footer = current["Footer"].ToString();
                this.SalesPerson = current["SalesPerson"].ToString();
                this.EstimatedBy = current["EstimatedBy"].ToString();
                if ((this.PageType.ToLower() == "estimate") || (this.PageType.ToLower() == "printbroker"))
                {
                    this.EstimatorEmail = current["EstimatorEmail"].ToString();
                    this.EstimatorPhone = current["EstimatorPhone"].ToString();
                    this.EstimatorMobile = current["EstimatorMobile"].ToString();
                    this.EstimatorJobTitle = current["EstimatorJobTitle"].ToString();
                }
                if ((this.PageType.ToLower() == "job") || (this.PageType.ToLower() == "invoice"))
                {
                    this.EstimatorEmail = current["EstimatorEmail"].ToString();
                    this.EstimatorPhone = current["EstimatorPhone"].ToString();
                    this.Estimator = current["Estimator"].ToString();
                }
                if((this.PageType.ToLower() == "estimate"))
                {
                    this.Estimator = current["Estimator"].ToString();
                }
                this.CreatedBy = current["EstimatedBy"].ToString();
                this.ValidFor = current["ValidFor"].ToString();
                this.CreatedDate = this.objJava.Eprint_return_Date_Before_View(current["CreatedDate"].ToString(), CompanyID, this.UserID, false);

                if (!string.IsNullOrEmpty(current["CustomDate1"].ToString()))
                    this.CustomDate1 = this.objJava.Eprint_return_Date_Before_View(current["CustomDate1"].ToString(), CompanyID, this.UserID, false);
                else
                    this.CustomDate1 = "";

                if (!string.IsNullOrEmpty(current["CustomDate2"].ToString()))
                    this.CustomDate2 = this.objJava.Eprint_return_Date_Before_View(current["CustomDate2"].ToString(), CompanyID, this.UserID, false);
                else
                    this.CustomDate2 = "";

                if (!string.IsNullOrEmpty(current["CustomDate3"].ToString()))
                    this.CustomDate3 = this.objJava.Eprint_return_Date_Before_View(current["CustomDate3"].ToString(), CompanyID, this.UserID, false);
                else
                    this.CustomDate3 = "";

                if (!string.IsNullOrEmpty(current["CustomDate4"].ToString()))
                    this.CustomDate4 = this.objJava.Eprint_return_Date_Before_View(current["CustomDate4"].ToString(), CompanyID, this.UserID, false);
                else
                    this.CustomDate4 = "";

                if (!string.IsNullOrEmpty(current["CustomDate5"].ToString()))
                    this.CustomDate5 = this.objJava.Eprint_return_Date_Before_View(current["CustomDate5"].ToString(), CompanyID, this.UserID, false);
                else
                    this.CustomDate5 = "";

                this._createdDate = current["CreatedDate"].ToString();
                this.SalesPersonEmail = current["SalesPersonEmail"].ToString();
                this.SalesPersonPhone = current["SalesPersonPhone"].ToString();
                this.SalesPersonFax = current["SalesPersonFax"].ToString();
                this.SalesPersonMobile = current["SalesPersonMobile"].ToString();
                this.TodayDate = DateTime.Now.ToShortDateString();
                this.AccountNo = current["AccountNumber"].ToString();
                this.Attention = current["Attention"].ToString();
                this.SalesPersonJobTitle = current["SalesPersonJobTitle"].ToString();       
                if (ModuleName.Trim().ToLower() == "estimate")
                {
                    this.EstimateComments = current["Comments"].ToString();
                    this.EstimateTitle = current["EstimateTitle"].ToString();
                    this.EstimateNumber = current["EstimateNumber"].ToString();
                    this.EstimateItemNo = current["EstimateItemNumber"].ToString();
                    this.EstimateNumberWithoutPrefix = current["EstimateNumberWithoutPrefix"].ToString();
                    this.EstimatedDate = current["EstimateDate"].ToString();
                    this.EstimateStatus = current["EstimateStatus"].ToString();
                    this.EstimateCustomer = current["Customer"].ToString();
                    this.EstimatedArtwork = current["EstimatedArtwork"].ToString();
                    this.EstimatedDelivery = current["EstimatedDelivery"].ToString();
                    this.Department = current["DepartmentName"].ToString();
                    this.CustomerOrderNumber = current["CustomerOrderNumber"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.CopiedEstimateNumber = current["CopiedEstimateNumber"].ToString();
                    this.CopiedInvoiceNumber = current["CopiedInvoiceNumber"].ToString();
                    this.CopiedJobNumber = current["CopiedJobNumber"].ToString();
                    this.CustomerCreditLimit = current["CustomerCreditLimit"].ToString();
                    this.CustomerCreditReference = current["CustomerCreditReference"].ToString();
                    this.CustomerTaxName = current["CustomerTaxName"].ToString();
                    this.CustomerCompanyNumber = current["CustomerCompanyNumber"].ToString();
                    this.CustomerCompanyType = current["CustomerCompanyType"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                    this.CustomerProfitMarginPercentage = current["CustomerProfitMarginPercentage"].ToString();
                    this.CustomerTaxRegNumber = current["CustomerTaxRegNumber"].ToString();
                    this.CustomerAccountOpenedDate = current["CustomerAccountOpenedDate"].ToString();
                    this.CustomerBankCode = current["CustomerBankCode"].ToString();
                    this.CustomerBankAccountNumber = current["CustomerBankAccountNumber"].ToString();
                    this.CustomerAccountName = current["CustomerAccountName"].ToString();
                    this.CustomerReferredBy = current["CustomerReferredBy"].ToString();
                    this.ItemStatus = current["EstimateItemStatus"].ToString();
                    this.contactTitle = current["ContactTitle"].ToString();
                    //if (ConnectionClass.StripeKey != null)
                    //{
                    //    this.StripeKey = ConnectionClass.StripeKey.ToString();
                    //}
                    //if (string.IsNullOrEmpty(this.SessionId))
                    //{
                    //    StripeConfiguration.ApiKey = this.StripeKey;


                    //    var options = new SessionCreateOptions
                    //    {
                    //        SuccessUrl = "http://localhost:11111//success?id={CHECKOUT_SESSION_ID}",
                    //        CancelUrl = "http://localhost:11111//cancel",
                    //        PaymentMethodTypes = new List<string>
                    //        {
                    //            "card",
                    //        },
                    //        LineItems = new List<SessionLineItemOptions>
                    //        {
                    //            new SessionLineItemOptions{
                    //                Name = "Test",
                    //                Amount = 2500,
                    //                Quantity = 2,
                    //                Currency = "usd",
                    //                Description = "Payment through checkout"
                    //            },
                    //        },
                    //        Mode = "payment",
                    //    };
                    //    var service = new SessionService();
                    //    Session session = service.Create(options);
                    //    this.SessionId = session.Id;
                    //}
                    //string[] Stripelink = new string[] { "https://checkout.stripe.com/pay/", this.SessionId, "#fidkdWxOYHwnPyd1blpxYHZxWjA0T2RHdTBGUmBGMnBVRFFudWFEU0lzTFNTZzRhdz13R1ZGQUs9bG9MMm1wTFVySG5BTmlucHBndXxxdFJ3QmdpMEJBbmNGSHM9b018YEh0Y21dUHdzaVdfNTVgSX1QSFVibicpJ2hsYXYnP34nYnBsYSc%2FJ0tEJyknaHBsYSc%2FJ0tEJykndmxhJz8nS0QneCknZ2BxZHYnP15YKSdpZHxqcHFRfHVgJz8ndmxrYmlgWmxxYGgnKSd3YGNgd3dgd0p3bGJsayc%2FJ21xcXU%2FKippamZkaW1qdnE%2FMzQxMzEneCUl" };
                    //this.StripePaymentLink = string.Concat(Stripelink);
                    if (string.IsNullOrEmpty(this.DeliveryNumber) && current["DeliveryNumber"].ToString() != "" && current["DeliveryNumber"].ToString() != null)
                    {
                        this.DeliveryNumber = dataTable.Rows[0]["DeliveryNumber"].ToString();
                    }

                }
                if (ModuleName.Trim().ToLower() == "job" || ModuleName.Trim().ToLower() == "jobcard")
                {
                    this.EstimateNumber = current["EstimateNumber"].ToString();
                    this.JobTitle = current["JobTitle"].ToString();
                    this.JobNumber = current["JobNumber"].ToString();
                    this.JobStatus = current["JobStatus"].ToString();
                    this.JobCustomer = current["Customer"].ToString();
                    this.JobCompletionDate = current["CompletionDate"].ToString();
                    this.OrderComments = current["Comments"].ToString();
                    this.ConsignmentNumber = current["ConsignmentNumber"].ToString();
                    this.Department = current["DepartmentName"].ToString();
                    this.OrderNumber = current["OrderNumber"].ToString();
                    this.CustomerOrderNumber = current["CustomerOrderNumber"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.CopiedEstimateNumber = current["CopiedEstimateNumber"].ToString();
                    this.CopiedInvoiceNumber = current["CopiedInvoiceNumber"].ToString();
                    this.CopiedJobNumber = current["CopiedJobNumber"].ToString();
                    this.CustomerCreditLimit = current["CustomerCreditLimit"].ToString();
                    this.CustomerCreditReference = current["CustomerCreditReference"].ToString();
                    this.CustomerTaxName = current["CustomerTaxName"].ToString();
                    this.CustomerCompanyNumber = current["CustomerCompanyNumber"].ToString();
                    this.CustomerCompanyType = current["CustomerCompanyType"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                    this.CustomerProfitMarginPercentage = current["CustomerProfitMarginPercentage"].ToString();
                    this.CustomerTaxRegNumber = current["CustomerTaxRegNumber"].ToString();
                    this.CustomerAccountOpenedDate = current["CustomerAccountOpenedDate"].ToString();
                    this.CustomerBankCode = current["CustomerBankCode"].ToString();
                    this.CustomerBankAccountNumber = current["CustomerBankAccountNumber"].ToString();
                    this.CustomerAccountName = current["CustomerAccountName"].ToString();
                    this.CustomerReferredBy = current["CustomerReferredBy"].ToString();
                    this.Job_OrderedDate = this.objJava.Eprint_return_Date_Before_View(current["OrderedDate"].ToString(), CompanyID, this.UserID, true);
                    this.jobOrderedDate = current["OrderedDate"].ToString();
                    this.ItemStatus = current["JobItemStatus"].ToString();
                    this.companytype = current["clienttype"].ToString();
                    if (string.IsNullOrEmpty(this.DeliveryNumber) && current["DeliveryNumber"].ToString() != "" && current["DeliveryNumber"].ToString() != null)
                    {
                        this.DeliveryNumber = current["DeliveryNumber"].ToString();
                    }
                }
                if (ModuleName.Trim().ToLower() == "job")
                {
                    this.OrderedBy = current["OrderedBy"].ToString();
                }
                if (ModuleName.Trim().ToLower() == "invoice")
                {
                    this.JobTitle = current["JobTitle"].ToString();
                    this.EstimateNumber = current["EstimateNumber"].ToString();
                    this.JobNumber = current["JobNumber"].ToString();
                    this.InvoiceTitle = current["InvoiceTitle"].ToString();
                    this.InvoiceNumber = current["InvoiceNumber"].ToString();
                    this.InvoiceStatus = current["InvoiceStatus"].ToString();
                    this.InvoicedDate = current["InvoicedDate"].ToString();
                    this.InvoicedDateNew = current["InvoicedDateNew"].ToString();
                    this.InvoiceDueDateNew = current["InvoiceDueDateNew"].ToString();
                    this.InvoiceCustomer = current["Customer"].ToString();
                    this.OrderTotalPrice = this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(current["OrderTotalPrice"].ToString()), 0, "", false, false, true);
                    this.CurrencyCode = current["CurrencyCode"].ToString();
                    this.OrderComments = current["Comments"].ToString();
                    this.EstimatedDelivery = current["EstimatedDelivery"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.CopiedEstimateNumber = current["CopiedEstimateNumber"].ToString();
                    this.CopiedInvoiceNumber = current["CopiedInvoiceNumber"].ToString();
                    this.CopiedJobNumber = current["CopiedJobNumber"].ToString();
                    this.CustomerCreditLimit = current["CustomerCreditLimit"].ToString();
                    this.CustomerCreditReference = current["CustomerCreditReference"].ToString();
                    this.CustomerTaxName = current["CustomerTaxName"].ToString();
                    this.CustomerCompanyNumber = current["CustomerCompanyNumber"].ToString();
                    this.CustomerCompanyType = current["CustomerCompanyType"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                    this.CustomerProfitMarginPercentage = current["CustomerProfitMarginPercentage"].ToString();
                    this.CustomerTaxRegNumber = current["CustomerTaxRegNumber"].ToString();
                    this.CustomerAccountOpenedDate = current["CustomerAccountOpenedDate"].ToString();
                    this.CustomerBankCode = current["CustomerBankCode"].ToString();
                    this.CustomerBankAccountNumber = current["CustomerBankAccountNumber"].ToString();
                    this.CustomerAccountName = current["CustomerAccountName"].ToString();
                    this.CustomerReferredBy = current["CustomerReferredBy"].ToString();
                    this.ItemStatus = current["InvoiceItemStatus"].ToString();
                    this.contactTitle = current["ContactTitle"].ToString();
                    ////ticket 94335
                    if (this.InvoiceTitle == "" || string.IsNullOrEmpty(this.InvoiceTitle))
                    {
                        this.InvoiceTitle = " ";
                    }
                    if (ConnectionClass.Paypalbusiness != null)
                    {
                        this.Paypalbusiness = ConnectionClass.Paypalbusiness.ToString();
                    }
                    string[] orderTotalPrice = new string[] { "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&amount=", this.OrderTotalPrice, "&business=", this.Paypalbusiness, "&currency_code=", this.CurrencyCode, "&item_name=Payment+for+invoice+", this.InvoiceNumber, "&shipping=0&pbtype=service&bn=Xero_Acct_ST" };
                    this.PaypalPaymentLink = string.Concat(orderTotalPrice);

                    if (ConnectionClass.StripeKey != null)
                    {
                        this.StripeKey = ConnectionClass.StripeKey.ToString();
                    }
                    //if (string.IsNullOrEmpty(this.SessionId))
                    //{
                    //    StripeConfiguration.ApiKey = this.StripeKey;
                    //    long TAmount = 1000;
                    //    if (Convert.ToInt32(current["OrderTotalPrice"]) != 0 && Convert.ToInt32(current["OrderTotalPrice"]) > 0)
                    //    {
                    //        //TAmount = Convert.ToInt64(current["OrderTotalPrice"]) * 100;
                    //        decimal total = Convert.ToDecimal(current["OrderTotalPrice"]);
                    //        TAmount = Convert.ToInt64(total * 100);
                    //    }
                    //    string SuccessUrl = this.strSitepath + "/success?id={CHECKOUT_SESSION_ID}";
                    //    string CancelUrl = this.strSitepath + "/cancel";
                    //    var options = new SessionCreateOptions
                    //    {
                    //        SuccessUrl = SuccessUrl,
                    //        CancelUrl = CancelUrl,
                    //        PaymentMethodTypes = new List<string>
                    //        {
                    //            "card",
                    //        },
                    //        LineItems = new List<SessionLineItemOptions>
                    //        {
                    //            new SessionLineItemOptions{
                    //                Name = this.InvoiceNumber,
                    //                Amount = TAmount,
                    //                Quantity = 1,
                    //                Currency = "AUD",
                    //                Description = this.InvoiceTitle
                    //            },
                    //        },
                    //        Mode = "payment",
                    //    };
                    //    var service = new SessionService();
                    //    Session session = service.Create(options);
                    //    this.SessionId = session.Id;
                    //    this.stripeUrl = session.Url;
                    //}
                    //string[] Stripelink = new string[] { "https://checkout.stripe.com/pay/", this.SessionId, "#fidkdWxOYHwnPyd1blpxYHZxWjA0T2RHdTBGUmBGMnBVRFFudWFEU0lzTFNTZzRhdz13R1ZGQUs9bG9MMm1wTFVySG5BTmlucHBndXxxdFJ3QmdpMEJBbmNGSHM9b018YEh0Y21dUHdzaVdfNTVgSX1QSFVibicpJ2hsYXYnP34nYnBsYSc%2FJ0tEJyknaHBsYSc%2FJ0tEJykndmxhJz8nS0QneCknZ2BxZHYnP15YKSdpZHxqcHFRfHVgJz8ndmxrYmlgWmxxYGgnKSd3YGNgd3dgd0p3bGJsayc%2FJ21xcXU%2FKippamZkaW1qdnE%2FMzQxMzEneCUl" };
                    //this.StripePaymentLink = string.Concat(Stripelink);
                    this.StripePaymentLink = "https://checkout.stripe.com/pay/";
                    if (!Convert.ToBoolean(current["IsPaid"]))
                    {
                        this.InvoicePaid = "Outstanding";
                    }
                    else
                    {
                        decimal num = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(current["InvoiceAmount"]), 0, "", false, false, true));
                        if (Convert.ToDecimal(current["InvoiceAmountPaid"].ToString()) < num)
                        {
                            this.InvoicePaid = "Partially Paid";
                        }
                        else
                        {
                            this.InvoicePaid = "Paid in Full";
                        }
                    }
                    this.InvoiceAmountoutstanding = Convert.ToDecimal(current["InvoiceAmountOutStanding"].ToString());
                    this.InvoiceAmountPaid = Convert.ToDecimal(current["InvoiceAmountPaid"].ToString());
                    this.ConsignmentNumber = current["ConsignmentNumber"].ToString();
                    this.Department = current["DepartmentName"].ToString();
                    this.OrderNumber = current["OrderNumber"].ToString();
                    this.CustomerOrderNumber = current["CustomerOrderNumber"].ToString();
                    this.InvoiceDueDate = current["InvoiceDueDate"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.PurchaseNumber = current["PoNo"].ToString();
                    if (string.IsNullOrEmpty(this.DeliveryNumber) && current["DeliveryNumber"].ToString() != "" && current["DeliveryNumber"].ToString() != null)
                    {
                        this.DeliveryNumber = current["DeliveryNumber"].ToString();
                    }
                }
                if (ModuleName.Trim().ToLower() == "purchase")
                {
                    this.EstimateTitle = current["EstimateTitle"].ToString();
                    this.Greeting = string.Concat("Dear ", current["Greeting"].ToString());
                    this.PurchaseNumber = current["PurchaseNumber"].ToString();
                    this.RaisedBy = current["RaisedBy"].ToString();
                    this.RequiredDate = current["RequiredDate"].ToString();
                    this.PODate = current["PODate"].ToString();
                    this.OrderComments = current["Comments"].ToString();
                    this.PurchaseComments = current["PurchaseComments"].ToString();
                    this.SupplierQuoteNumber = current["SupplierQuoteNumber"].ToString();
                    this.SupplierInvoiceNumber = current["SupplierInvoiceNumber"].ToString();
                    this.SupplierContactName = current["SupplierContactName"].ToString();
                    this.PurchaseRefNo = current["RefNo"].ToString();
                    this.JobNumber = current["RefNo"].ToString();
                    this.CarrierInformation = current["CarrierName"].ToString();
                    this.JobStatus = current["JobStatus"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                    this.CustomerContactName = current["CustomerContactName"].ToString();
                    this.DeliveryTo = current["DeliveryTo"].ToString();
                    this.DeliveryToAccountNumber = current["DeliveryToAccountNumber"].ToString();
                    this.CarrierAccountNumber = current["CarrierAccountNumber"].ToString();
                    this.EstimateNumber = current["EstimateNumber"].ToString();
                    this.DeliveryDate = current["DeliveryDate"].ToString();
                    this.OrderNumber = current["OrderNumber"].ToString();
                    this.SupplierInvoiceDate = current["SupplierInvoiceDate"].ToString();
                    this.CarrierURL = current["CarrierURL"].ToString();
                    this.RaisedByEmail = current["RaisedByEmail"].ToString();
                    this.RaisedByPhone = current["RaisedByPhone"].ToString();
                    this.RaisedByFax = current["RaisedByFax"].ToString();
                    this.RaisedByMobile = current["RaisedByMobile"].ToString();
                    this.CustomerOrderNumber = current["OrderNumber"].ToString();
                    if (string.IsNullOrEmpty(this.DeliveryNumber) && current["DeliveryNumber"].ToString() != "" && current["DeliveryNumber"].ToString() != null)
                    {
                        this.DeliveryNumber = current["DeliveryNumber"].ToString();
                    }
                }
                if (ModuleName.Trim().ToLower() == "note")
                {
                    this.DeliveryNumber = current["DeliveryNumber"].ToString();
                    this.DeliveryDate = current["DeliveryDate"].ToString();
                    this.ShippedTo = current["ShippedTo"].ToString();
                    this.Carrier = current["Carrier"].ToString();
                    this.OrderComments = current["Comments"].ToString();
                    this.DeliveryComments = current["DeliveryComments"].ToString();
                    this.DeliveryRefNo = current["RefNo"].ToString();
                    this.JobTitle = current["JobTitle"].ToString();
                    this.EstimateNumber = current["EstimateNumber"].ToString();
                    this.ConsignmentNumber = current["ConsignmentNumber"].ToString();
                    this.DeliveryNoteActualDeliveryDate = current["ActualDeliveryDate"].ToString();
                    this.CustomerOrderNumber = current["CustomerOrderNumber"].ToString();
                    this.JobNumber = current["jobnumber"].ToString();
                    this.InvoiceNumber = current["InvoiceNumber"].ToString();
                    this.CarrierURL = current["CarrierURL"].ToString();
                    this.CarrierInformation = current["CarrierName"].ToString();
                    this.CarrierAccountNumber = current["CarrierAccountNumber"].ToString();
                    this.EstoreOrderNumber = current["EstoreOrderNumber"].ToString();
                    this.EstoreOrderTitle = current["EstoreOrderTitle"].ToString();
                    this.CustomerCreditLimit = current["CustomerCreditLimit"].ToString();
                    this.CustomerCreditReference = current["CustomerCreditReference"].ToString();
                    this.CustomerTaxName = current["CustomerTaxName"].ToString();
                    this.CustomerCompanyNumber = current["CustomerCompanyNumber"].ToString();
                    this.CustomerCompanyType = current["CustomerCompanyType"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                    this.CustomerProfitMarginPercentage = current["CustomerProfitMarginPercentage"].ToString();
                    this.CustomerTaxRegNumber = current["CustomerTaxRegNumber"].ToString();
                    this.CustomerAccountOpenedDate = current["CustomerAccountOpenedDate"].ToString();
                    this.CustomerBankCode = current["CustomerBankCode"].ToString();
                    this.CustomerBankAccountNumber = current["CustomerBankAccountNumber"].ToString();
                    this.CustomerAccountName = current["CustomerAccountName"].ToString();
                    this.CustomerReferredBy = current["CustomerReferredBy"].ToString();
                    this.PurchaseNumber = current["PurchaseNumber"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.OrderedBy = current["OrderedBy"].ToString();

                    this.OrderCBM = Convert.ToString(OrderCBM);
                    this.OrderWeight = Convert.ToString(OrderWeight);
                }
                if (ModuleName.Trim().ToLower() == "webstoreorder")
                {
                    this.OrderTitle = current["OrderTitle"].ToString();
                    this.OrderStatus = current["OrderStatus"].ToString();
                    this.OrderedDate = current["CreatedDate"].ToString();
                    this.PaymentType = current["PaymentType"].ToString();
                    this.DeliveryDate = current["DeliveryDate"].ToString();
                    this.OrderComments = current["Comments"].ToString();
                    this.ConsignmentNumber = current["ConsignmentNumber"].ToString();
                    this.OrderNumber = current["OrderNumber"].ToString();
                    this.CustomerOrderNumber = current["CustomerOrderNumber"].ToString();
                    this.Department = current["DepartmentName"].ToString();
                    this.CostCentre = current["CostCentreName"].ToString();
                    this.ItemStatus = current["OrderItemStatus"].ToString();
                    this.ApprovalStatus = current["Approvalstatus"].ToString();
                    this.OrderedBy = current["OrderedBy"].ToString();
                    this.CustomerSalesPerson = current["CustomerSalesPerson"].ToString();
                }
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

    private string GetGeneralInformationFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[Greeting]", this.Greeting);
            objValue = objValue.Replace("[Header]", this.Header);
            objValue = objValue.Replace("[Footer]", this.Footer);
            objValue = objValue.Replace("[SalesPerson]", this.SalesPerson);
            objValue = objValue.Replace("[EstimatedBy]", this.EstimatedBy);
            if ((this.PageType.ToLower() == "estimate") || (this.PageType.ToLower() == "printbroker"))
            {
                objValue = objValue.Replace("[EstimatorEmail]", this.EstimatorEmail);
                objValue = objValue.Replace("[EstimatorPhone]", this.EstimatorPhone);
                objValue = objValue.Replace("[EstimatorMobile]", this.EstimatorMobile);
                objValue = objValue.Replace("[EstimatorJobTitle]", this.EstimatorJobTitle);
            }
            if ((this.PageType.ToLower() == "job") || (this.PageType.ToLower() == "invoice"))
            {
                objValue = objValue.Replace("[EstimatorEmail]", this.EstimatorEmail);
                objValue = objValue.Replace("[EstimatorPhone]", this.EstimatorPhone);
                objValue = objValue.Replace("[Estimator]", this.Estimator);
            }
            if(this.PageType.ToLower() == "estimate")
            {
                objValue = objValue.Replace("[Estimator]", this.Estimator);
            }
            objValue = objValue.Replace("[CreatedBy]", this.CreatedBy);
            objValue = objValue.Replace("[ValidFor]", this.ValidFor);
            objValue = objValue.Replace("[CreatedDate]", this.CreatedDate);

            objValue = objValue.Replace("[CustomDate1]", this.CustomDate1);
            objValue = objValue.Replace("[CustomDate2]", this.CustomDate2);
            objValue = objValue.Replace("[CustomDate3]", this.CustomDate3);
            objValue = objValue.Replace("[CustomDate4]", this.CustomDate4);
            objValue = objValue.Replace("[CustomDate5]", this.CustomDate5);


            //objValue = objValue.Replace("[CreatedDateDay]", this.CreatedDate);
            objValue = objValue.Replace("[CreatedDateDay]", ReturnFullDayAndDate(this.CreatedDate, this._createdDate));
            objValue = objValue.Replace("[CreatedDateDayABV]", ReturnShortDayAndDate(this.CreatedDate, this._createdDate));
            objValue = objValue.Replace("[SalesPersonEmail]", this.SalesPersonEmail);
            objValue = objValue.Replace("[SalesPersonAddressPhone]", this.SalesPersonPhone);
            objValue = objValue.Replace("[SalesPersonAddressFax]", this.SalesPersonFax);
            objValue = objValue.Replace("[SalesPersonMobile]", this.SalesPersonMobile);
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            objValue = objValue.Replace("[TodayDate]", _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            objValue = objValue.Replace("[AccountNo]", this.AccountNo);
            objValue = objValue.Replace("[CustomerAccountNumber]", this.AccountNo);
            objValue = objValue.Replace("[Contact]", this.Attention);
            objValue = objValue.Replace("[SalesPersonJobTitle]", this.SalesPersonJobTitle);
            objValue = objValue.Replace("[EstimateTitle]", this.EstimateTitle);
            objValue = objValue.Replace("[EstimatedDate]", this.objJava.Eprint_return_Date_Before_View(this.EstimatedDate, this.CompanyID, this.UserID, false));
            objValue = objValue.Replace("[EstimateStatus]", this.EstimateStatus);
            objValue = objValue.Replace("[Company]", this.EstimateCustomer);
            if (this.PageType.ToLower() == "estimate")
            {
                objValue = objValue.Replace("[Comments]", this.EstimateComments);
                objValue = objValue.Replace("[EstimateNumber]", this.EstimateNumber);
                //objValue = objValue.Replace("[EstItemNo]", this.EstimateItemNo);
                objValue = objValue.Replace("[EstimateNumberWithoutPrefix]", this.EstimateNumberWithoutPrefix);
                objValue = objValue.Replace("[EstimatedArtworkDate]", this.objJava.Eprint_return_Date_Before_View(this.EstimatedArtwork, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[EstimatedDeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.EstimatedDelivery, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.EstimatedDelivery, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[Department]", this.Department);
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[CostCentre]", this.CostCentre);
                objValue = objValue.Replace("[CustomerCreditLimit]", this.CustomerCreditLimit);
                objValue = objValue.Replace("[CustomerCreditReference]", this.CustomerCreditReference);
                objValue = objValue.Replace("[CustomerTaxName]", this.CustomerTaxName);
                objValue = objValue.Replace("[CustomerDescription]", this.CustomerDescription);
                objValue = objValue.Replace("[CustomerCompanyNumber]", this.CustomerCompanyNumber);
                objValue = objValue.Replace("[CustomerCompanyType]", this.CustomerCompanyType);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
                objValue = objValue.Replace("[CustomerProfitMarginPercentage]", this.CustomerProfitMarginPercentage);
                objValue = objValue.Replace("[CustomerTaxRegNumber]", this.CustomerTaxRegNumber);
                objValue = objValue.Replace("[CustomerAccountOpenedDate]", this.CustomerAccountOpenedDate);
                objValue = objValue.Replace("[CustomerBankCode]", this.CustomerBankCode);
                objValue = objValue.Replace("[CustomerBankAccountNumber]", this.CustomerBankAccountNumber);
                objValue = objValue.Replace("[CustomerAccountName]", this.CustomerAccountName);
                objValue = objValue.Replace("[CustomerReferredBy]", this.CustomerReferredBy);
                objValue = objValue.Replace("[ItemStatus]", this.ItemStatus);
                objValue = objValue.Replace("[ContactTitle]", this.contactTitle);
                //ticket # 120846
                // objValue = objValue.Replace("[StripePaymentLink]", this.StripePaymentLink);
                objValue = objValue.Replace("[StripePaymentLink]", "");
            }
            if (this.PageType.ToLower() == "job")
            {
                objValue = objValue.Replace("[OrderedDate]", this.Job_OrderedDate);
                //objValue = objValue.Replace("[OrderedDateDay]", this.Job_OrderedDate);
                objValue = objValue.Replace("[OrderedDateDay]", ReturnFullDayAndDate(this.Job_OrderedDate, this.jobOrderedDate));
                objValue = objValue.Replace("[OrderedDateDayABV]", ReturnShortDayAndDate(this.Job_OrderedDate, this.jobOrderedDate));
                objValue = objValue.Replace("[OrderedBy]", this.OrderedBy);
            }
            else if (this.PageType.Trim().ToLower() != "webstoreorder")
            {
                objValue = objValue.Replace("[OrderedDate]", this.objJava.Eprint_return_Date_Before_View(this.OrderedDate, this.CompanyID, this.UserID, false));
            }
            else
            {
                objValue = objValue.Replace("[OrderedDate]", this.objJava.Eprint_return_Date_Before_View(this.OrderedDate, this.CompanyID, this.UserID, true));
            }
            objValue = objValue.Replace("[JobStatus]", this.JobStatus);
            objValue = objValue.Replace("[Company]", this.JobCustomer);
            objValue = objValue.Replace("[JobCompletionDate]", this.objJava.Eprint_return_Date_Before_View(this.JobCompletionDate, this.CompanyID, this.UserID, false));
            //objValue = objValue.Replace("[JobCompletionDateDay]", this.objJava.Eprint_return_Date_Before_View(this.JobCompletionDate, this.CompanyID, this.UserID, false));
            objValue = objValue.Replace("[JobCompletionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(this.JobCompletionDate, this.CompanyID, this.UserID, false), this.JobCompletionDate));
            objValue = objValue.Replace("[JobCompletionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(this.JobCompletionDate, this.CompanyID, this.UserID, false), this.JobCompletionDate));

            if (this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
            {
                objValue = objValue.Replace("[Comments]", this.OrderComments);
                objValue = objValue.Replace("[ConsignmentNoteNumber]", this.ConsignmentNumber);
                objValue = objValue.Replace("[Department]", this.Department);
                objValue = objValue.Replace("[OrderNumber]", this.OrderNumber);
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[CostCentre]", this.CostCentre);
                objValue = objValue.Replace("[EstimateNumber]", this.EstimateNumber);
                objValue = objValue.Replace("[JobNumber]", this.JobNumber);
                objValue = objValue.Replace("[CustomerCreditLimit]", this.CustomerCreditLimit);
                objValue = objValue.Replace("[CustomerCreditReference]", this.CustomerCreditReference);
                objValue = objValue.Replace("[CustomerTaxName]", this.CustomerTaxName);
                objValue = objValue.Replace("[CustomerDescription]", this.CustomerDescription);
                objValue = objValue.Replace("[CustomerCompanyNumber]", this.CustomerCompanyNumber);
                objValue = objValue.Replace("[CustomerCompanyType]", this.CustomerCompanyType);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
                objValue = objValue.Replace("[CustomerProfitMarginPercentage]", this.CustomerProfitMarginPercentage);
                objValue = objValue.Replace("[CustomerTaxRegNumber]", this.CustomerTaxRegNumber);
                objValue = objValue.Replace("[CustomerAccountOpenedDate]", this.CustomerAccountOpenedDate);
                objValue = objValue.Replace("[CustomerBankCode]", this.CustomerBankCode);
                objValue = objValue.Replace("[CustomerBankAccountNumber]", this.CustomerBankAccountNumber);
                objValue = objValue.Replace("[CustomerAccountName]", this.CustomerAccountName);
                objValue = objValue.Replace("[CustomerReferredBy]", this.CustomerReferredBy);
                objValue = objValue.Replace("[ItemStatus]", this.ItemStatus);
                objValue = objValue.Replace("[JobTitle]", this.JobTitle);
                objValue = objValue.Replace("[CompanyType]", this.companytype);
            }
            objValue = objValue.Replace("[InvoiceNumber]", this.InvoiceNumber);
            objValue = objValue.Replace("[InvoiceTitle]", this.InvoiceTitle);
            objValue = objValue.Replace("[InvoicedDate]", this.objJava.Eprint_return_Date_Before_View(this.InvoicedDate, this.CompanyID, this.UserID, false));
            objValue = objValue.Replace("[InvoiceStatus]", this.InvoiceStatus);
            objValue = objValue.Replace("[Company]", this.InvoiceCustomer);
            objValue = objValue.Replace("[CopiedEstimateNumber]", this.CopiedEstimateNumber);
            objValue = objValue.Replace("[CopiedJobNumber]", this.CopiedJobNumber);
            objValue = objValue.Replace("[CopiedInvoiceNumber]", this.CopiedInvoiceNumber);
            if (this.PageType.ToLower() == "webstoreorder")
            {
                objValue = objValue.Replace("[OrderTitle]", this.OrderTitle);
                objValue = objValue.Replace("[OrderStatus]", this.OrderStatus);
                objValue = objValue.Replace("[PaymentType]", this.PaymentType);
                objValue = objValue.Replace("[Comments]", this.OrderComments);
                objValue = objValue.Replace("[OrderNumber]", this.OrderNumber);
                objValue = objValue.Replace("[ConsignmentNoteNumber]", this.ConsignmentNumber);
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[Department]", this.Department);
                objValue = objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.DeliveryDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[CostCentre]", this.CostCentre);
                objValue = objValue.Replace("[ApprovalStatus]", this.ApprovalStatus);
                objValue = objValue.Replace("[ItemStatus]", this.ItemStatus);
                objValue = objValue.Replace("[OrderedBy]", this.OrderedBy);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
            }
            if (objValue.Contains("[PurchaseNumber]") && this.firstPOPrint == 0)
            {
                objValue = objValue.Replace("[PurchaseNumber]", this.PurchaseNumber);
                this.firstPOPrint = 1;
            }
            objValue = objValue.Replace("[DeliveryNumber]", this.DeliveryNumber);
            objValue = objValue.Replace("[RaisedBy]", this.RaisedBy);
            objValue = objValue.Replace("[PODeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.RequiredDate, this.CompanyID, this.UserID, false));
            objValue = objValue.Replace("[PODate]", this.objJava.Eprint_return_Date_Before_View(this.PODate, this.CompanyID, this.UserID, false));
            objValue = objValue.Replace("[Comments/DeliveryInstructions]", this.PurchaseComments);
            objValue = objValue.Replace("[SupplierQuoteNumber]", this.SupplierQuoteNumber);
            objValue = objValue.Replace("[SupplierInvoiceNumber]", this.SupplierInvoiceNumber);
            if (this.PageType.ToLower() == "purchase")
            {
                objValue = objValue.Replace("[EstimateTitleHeader]", this.EstimateTitle);
                objValue = objValue.Replace("[JobTitleHeader]", this.EstimateTitle);
                objValue = objValue.Replace("[RefNo]", this.PurchaseRefNo);
                objValue = objValue.Replace("[POJobNumber]", this.PurchaseRefNo);
                objValue = objValue.Replace("[CarrierInformation]", this.CarrierInformation);
                objValue = objValue.Replace("[DeliveryTo]", this.DeliveryTo);
                objValue = objValue.Replace("[DeliveryToAccountNumber]", this.DeliveryToAccountNumber);
                objValue = objValue.Replace("[CarrierAccountNumber]", this.CarrierAccountNumber);
                objValue = objValue.Replace("[Comments]", this.OrderComments);
                objValue = objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.DeliveryDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[OrderNumber]", this.OrderNumber);
                objValue = objValue.Replace("[SupplierInvoiceDate]", this.objJava.Eprint_return_Date_Before_View(this.SupplierInvoiceDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[CarrierURL]", this.CarrierURL);
                objValue = objValue.Replace("[RaisedByEmail]", this.RaisedByEmail);
                objValue = objValue.Replace("[RaisedByPhone]", this.RaisedByPhone);
                objValue = objValue.Replace("[RaisedByFax]", this.RaisedByFax);
                objValue = objValue.Replace("[RaisedByMobile]", this.RaisedByMobile);
                objValue = objValue.Replace("[EstimateNumber]", this.EstimateNumber);
                objValue = objValue.Replace("[JobNumber]", this.JobNumber);
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
                objValue = objValue.Replace("[JobContactName]", this.CustomerContactName);
                objValue = objValue.Replace("[ProductSalesCode]", this.ProductSalesCode);
                objValue = objValue.Replace("[ProductPurchaseCode]", this.ProductPurchaseCode);
            }
            if (this.PageType.ToLower() == "note")
            {
                objValue = objValue.Replace("[EstimateNumber]", this.EstimateNumber);
                objValue = objValue.Replace("[JobNumber]", this.JobNumber);
                objValue = objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.DeliveryDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[ShippedTo]", this.ShippedTo);
                objValue = objValue.Replace("[Carrier]", this.Carrier);
                objValue = objValue.Replace("[Comments]", this.OrderComments);
                objValue = objValue.Replace("[DeliveryComments]", this.DeliveryComments);
                objValue = objValue.Replace("[RefNo]", this.DeliveryRefNo);
                objValue = objValue.Replace("[ConsignmentNoteNumber]", this.ConsignmentNumber);
                objValue = objValue.Replace("[DeliveryNoteActualDeliveryDate]", this.objJava.Eprint_return_DateTime_Before_View(this.DeliveryNoteActualDeliveryDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[CarrierURL]", this.CarrierURL);
                objValue = objValue.Replace("[CarrierInformation]", this.CarrierInformation);
                objValue = objValue.Replace("[CarrierAccountNumber]", this.CarrierAccountNumber);
                objValue = objValue.Replace("[EstoreOrderNumber]", this.EstoreOrderNumber);
                objValue = objValue.Replace("[EstoreOrderTitle]", this.EstoreOrderTitle);
                objValue = objValue.Replace("[CustomerCreditLimit]", this.CustomerCreditLimit);
                objValue = objValue.Replace("[CustomerCreditReference]", this.CustomerCreditReference);
                objValue = objValue.Replace("[CustomerTaxName]", this.CustomerTaxName);
                objValue = objValue.Replace("[CustomerDescription]", this.CustomerDescription);
                objValue = objValue.Replace("[CustomerCompanyNumber]", this.CustomerCompanyNumber);
                objValue = objValue.Replace("[CustomerCompanyType]", this.CustomerCompanyType);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
                objValue = objValue.Replace("[CustomerProfitMarginPercentage]", this.CustomerProfitMarginPercentage);
                objValue = objValue.Replace("[CustomerTaxRegNumber]", this.CustomerTaxRegNumber);
                objValue = objValue.Replace("[CustomerAccountOpenedDate]", this.CustomerAccountOpenedDate);
                objValue = objValue.Replace("[CustomerBankCode]", this.CustomerBankCode);
                objValue = objValue.Replace("[CustomerBankAccountNumber]", this.CustomerBankAccountNumber);
                objValue = objValue.Replace("[CustomerAccountName]", this.CustomerAccountName);
                objValue = objValue.Replace("[CustomerReferredBy]", this.CustomerReferredBy);
                objValue = objValue.Replace("[CostCentre]", this.CostCentre);
                objValue = objValue.Replace("[OrderedBy]", this.OrderedBy);
                objValue = objValue.Replace("[JobTitle]", this.JobTitle);

                objValue = objValue.Replace("[OrderedBy]", this.OrderedBy);
                objValue = objValue.Replace("[OrderWeight]", this.OrderWeight);
                objValue = objValue.Replace("[OrderCBM]", this.OrderCBM);
            }
            if (this.PageType.ToLower() == "invoice")
            {
                objValue = objValue.Replace("[PaypalPaymentLink]", this.PaypalPaymentLink);
                objValue = objValue.Replace("[StripePaymentLink]", this.StripePaymentLink);
                objValue = objValue.Replace("[EstimateNumber]", this.EstimateNumber);
                objValue = objValue.Replace("[OrderNumber]", this.OrderNumber);
                objValue = objValue.Replace("[JobNumber]", this.JobNumber);
                objValue = objValue.Replace("[IsPaid]", this.InvoicePaid);
                objValue = objValue.Replace("[Comments]", this.OrderComments);
                objValue = objValue.Replace("[ConsignmentNoteNumber]", this.ConsignmentNumber);
                objValue = objValue.Replace("[Department]", this.Department);
                objValue = objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);
                objValue = objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(this.EstimatedDelivery, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[InvoiceDueDate]", this.objJava.Eprint_return_Date_Before_View(this.InvoiceDueDate, this.CompanyID, this.UserID, false));
                objValue = objValue.Replace("[InvoiceDueDateNew]", this.InvoiceDueDateNew);
                objValue = objValue.Replace("[InvoicedDateNew]", this.InvoicedDateNew);
                objValue = objValue.Replace("[CostCentre]", this.CostCentre);
                objValue = objValue.Replace("[InvoiceAmountPaid]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.InvoiceAmountPaid, 0, "", false, false, true), true));
                objValue = objValue.Replace("[InvoiceAmountoutstanding]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.InvoiceAmountoutstanding, 0, "", false, false, true), true));
                objValue = objValue.Replace("[CustomerCreditLimit]", this.CustomerCreditLimit);
                objValue = objValue.Replace("[CustomerCreditReference]", this.CustomerCreditReference);
                objValue = objValue.Replace("[CustomerTaxName]", this.CustomerTaxName);
                objValue = objValue.Replace("[CustomerDescription]", this.CustomerDescription);
                objValue = objValue.Replace("[CustomerCompanyNumber]", this.CustomerCompanyNumber);
                objValue = objValue.Replace("[CustomerCompanyType]", this.CustomerCompanyType);
                objValue = objValue.Replace("[CustomerSalesPerson]", this.CustomerSalesPerson);
                objValue = objValue.Replace("[CustomerProfitMarginPercentage]", this.CustomerProfitMarginPercentage);
                objValue = objValue.Replace("[CustomerTaxRegNumber]", this.CustomerTaxRegNumber);
                objValue = objValue.Replace("[CustomerAccountOpenedDate]", this.CustomerAccountOpenedDate);
                objValue = objValue.Replace("[CustomerBankCode]", this.CustomerBankCode);
                objValue = objValue.Replace("[CustomerBankAccountNumber]", this.CustomerBankAccountNumber);
                objValue = objValue.Replace("[CustomerAccountName]", this.CustomerAccountName);
                objValue = objValue.Replace("[CustomerReferredBy]", this.CustomerReferredBy);
                objValue = objValue.Replace("[ItemStatus]", this.ItemStatus);
                objValue = objValue.Replace("[JobTitle]", this.JobTitle);
                objValue = objValue.Replace("[ContactTitle]", this.contactTitle);
                objValue = objValue.Replace("[ProductSalesCode]", this.ProductSalesCode);
                objValue = objValue.Replace("[ProductPurchaseCode]", this.ProductPurchaseCode);
            }
        }
        return objValue;
    }

    private string GetInvoiceAddress(string objValue, int CompanyID, int CustomerInvoiceAddressID, string CustomerInvoiceAddressType, string CustomerInvoiceAddress, int CustomerInvoiceAddressClientID)
    {
        if (objValue.IndexOf('[') > -1)
        {
            string empty = string.Empty;
            empty = CustomerInvoiceAddress;
            if (empty != "")
            {
                string[] strArrays = empty.Replace("<br />", "±").Split(new char[] { '±' });
                this.InvoiceAddressLabel = strArrays[0].ToString();
                this.InvoiceAddress1 = strArrays[1].ToString();
                this.InvoiceAddress2 = strArrays[2].ToString();
                this.InvoiceAddress3 = strArrays[3].ToString();
                this.InvoiceAddress4 = strArrays[4].ToString();
                this.InvoiceAddress5 = strArrays[5].ToString();
                this.InvoiceCountry = strArrays[6].ToString();
                this.InvoiceTelephone = strArrays[7].ToString();
                this.InvoiceFax = strArrays[8].ToString();
            }
            objValue = objValue.Replace("[InvoiceAddressLabel]", this.InvoiceAddressLabel);
            objValue = objValue.Replace("[InvoiceAddress1]", this.InvoiceAddress1);
            objValue = objValue.Replace("[InvoiceAddress2]", this.InvoiceAddress2);
            objValue = objValue.Replace("[InvoiceAddress3]", this.InvoiceAddress3);
            objValue = objValue.Replace("[InvoiceAddress4]", this.InvoiceAddress4);
            objValue = objValue.Replace("[InvoiceAddress5]", this.InvoiceAddress5);
            objValue = objValue.Replace("[InvoiceAddressCountry]", this.InvoiceCountry);
            objValue = objValue.Replace("[InvoiceAddressTelephone]", this.InvoiceTelephone);
            objValue = objValue.Replace("[InvoiceAddressFax]", this.InvoiceFax);
        }
        return objValue;
    }

    private double GetDelivryItemTotalExTax(int CompanyID, string Estitemid)
    {
        double total = 0;
        foreach (DataRow row in this.objTemplates.templates_GetDelivryItemTotalExTax_select(CompanyID, Estitemid).Rows)
        {
            double price = string.IsNullOrEmpty(row["Price"].ToString()) ? 0 : Convert.ToDouble(row["Price"].ToString());
            total += price;

        }
        return total;
    }

    private void GetSupplierAddressFromDataBase(int CompanyID, int SupplierID)
    {
        foreach (DataRow row in this.objTemplates.templates_company_client_address_select(CompanyID, SupplierID).Rows)
        {
            this.SupplierName = row["ClientName"].ToString();
            this.SupplierAddress1 = row["BusinessAddressLine1"].ToString();
            this.SupplierAddress2 = row["BusinessAddressLine2"].ToString();
            this.SupplierAddress3 = row["BusinessAddressLine3"].ToString();
            this.SupplierAddress4 = row["BusinessAddressLine4"].ToString();
            this.SupplierAddress5 = row["BusinessAddressLine5"].ToString();
            this.SupplierCountry = row["BusinessCountry"].ToString();
            this.SupplierPhone = row["BusinessTelephone"].ToString();
            this.SupplierFax = row["fax"].ToString();
            this.SupplierEmail = row["BusinessEmail"].ToString();
            this.SupplierPaymentTerms = row["PaymentTerms"].ToString();
            this.SupplierWebsite = row["WebSite"].ToString();
            this.SupplierAccountNumber = row["AccountNumber"].ToString();
            this.SupplierDescription = row["Description"].ToString();
            this.SupplierAccountStatus = row["AccountStatusName"].ToString();
        }
    }

    private string GetSupplierAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[SupplierName]", this.SupplierName);
            objValue = objValue.Replace("[SupplierAddress1]", this.SupplierAddress1);
            objValue = objValue.Replace("[SupplierAddress2]", this.SupplierAddress2);
            objValue = objValue.Replace("[SupplierAddress3]", this.SupplierAddress3);
            objValue = objValue.Replace("[SupplierAddress4]", this.SupplierAddress4);
            objValue = objValue.Replace("[SupplierAddress5]", this.SupplierAddress5);
            objValue = objValue.Replace("[SupplierAddressCountry]", this.SupplierCountry);
            objValue = objValue.Replace("[SupplierAddressPhone]", this.SupplierPhone);
            objValue = objValue.Replace("[SupplierAddressFax]", this.SupplierFax);
            objValue = objValue.Replace("[SupplierPaymentTerms]", this.SupplierPaymentTerms);
            objValue = objValue.Replace("[SupplierEmail]", this.SupplierEmail);
            objValue = objValue.Replace("[SupplierWebsite]", this.SupplierWebsite);
            objValue = objValue.Replace("[SupplierMobileNumber]", "");
            objValue = objValue.Replace("[SupplierAccountNumber]", this.SupplierAccountNumber);
            objValue = objValue.Replace("[SupplierDescription]", this.SupplierDescription);
            objValue = objValue.Replace("[SupplierAccountStatus]", this.SupplierAccountStatus);
        }
        return objValue;
    }

    private void GetSupplierContactAddressFromDataBase(int CompanyID, int ContactID)
    {
        this.SupplierContactSalutation = "";
        this.SupplierContactFirstName = "";
        this.SupplierContactLastName = "";
        this.SupplierContactMiddleName = "";
        this.SupplierContactFullName = "";
        this.SupplierContactDepartment = "";
        this.SupplierContactJobTitle1 = "";
        this.SupplierContactJobTitle2 = "";
        this.SupplierContactBusinessAddressLine1 = "";
        this.SupplierContactBusinessAddressLine2 = "";
        this.SupplierContactBusinessAddressLine3 = "";
        this.SupplierContactBusinessAddressLine4 = "";
        this.SupplierContactBusinessAddressLine5 = "";
        this.SupplierContactBusinessCountry = "";
        this.SupplierContactBusinessTelephone = "";
        this.SupplierContactBusinessFax = "";
        this.SupplierContactBusinessEmail = "";
        this.SupplierContactMobile = "";
        this.SupplierContactCompanyName = "";
        this.SupplierContactPhone = "";
        this.SupplierContactPersonalFax = "";
        this.SupplierContactAddressLabel = "";
        foreach (DataRow row in this.objTemplates.settings_template_ContactInfo(CompanyID, ContactID).Rows)
        {
            this.SupplierContactSalutation = row["ContactSalutation"].ToString();
            this.SupplierContactFirstName = row["ContactFirstName"].ToString();
            this.SupplierContactLastName = row["ContactLastName"].ToString();
            this.SupplierContactMiddleName = row["ContactMiddleName"].ToString();
            this.SupplierContactFullName = row["ContactFullName"].ToString();
            this.SupplierContactDepartment = row["ContactDepartment"].ToString();
            this.SupplierContactJobTitle1 = row["ContactJobTitle1"].ToString();
            this.SupplierContactJobTitle2 = row["ContactJobTitle2"].ToString();
            this.SupplierContactAddressLabel = row["ContactBusinessAddressLabel"].ToString();
            this.SupplierContactBusinessAddressLine1 = row["ContactBusinessAddressLine1"].ToString();
            this.SupplierContactBusinessAddressLine2 = row["ContactBusinessAddressLine2"].ToString();
            this.SupplierContactBusinessAddressLine3 = row["ContactBusinessAddressLine3"].ToString();
            this.SupplierContactBusinessAddressLine4 = row["ContactBusinessAddressLine4"].ToString();
            this.SupplierContactBusinessAddressLine5 = row["ContactBusinessAddressLine5"].ToString();
            this.SupplierContactBusinessCountry = row["ContactBusinessCountry"].ToString();
            this.SupplierContactBusinessTelephone = row["ContactBusinessTelephone"].ToString();
            this.SupplierContactBusinessFax = row["ContactBusinessFax"].ToString();
            this.SupplierContactBusinessEmail = row["ContactBusinessEmail"].ToString();
            this.SupplierContactMobile = row["ContactMobile"].ToString();
            this.SupplierContactCompanyName = row["ContactCompanyName"].ToString();
            this.SupplierContactPhone = row["CustomerContactPhone"].ToString();
            this.SupplierContactPersonalFax = row["CustomerContactPersonalFax"].ToString();
            this.SupplierContactMobile = row["ContactMobile"].ToString();
        }
    }

    private string GetSupplierContactAddressFromPage(string objValue)
    {
        if (objValue.IndexOf('[') > -1)
        {
            objValue = objValue.Replace("[SupplierContactSalutation]", this.SupplierContactSalutation);
            objValue = objValue.Replace("[SupplierContactFirstName]", this.SupplierContactFirstName);
            objValue = objValue.Replace("[SupplierContactLastName]", this.SupplierContactLastName);
            objValue = objValue.Replace("[SupplierContactMiddleName]", this.SupplierContactMiddleName);
            objValue = objValue.Replace("[SupplierContactFullName]", this.SupplierContactFullName);
            objValue = objValue.Replace("[SupplierContactDepartment]", this.SupplierContactDepartment);
            objValue = objValue.Replace("[SupplierContactJobTitle1]", this.SupplierContactJobTitle1);
            objValue = objValue.Replace("[SupplierContactJobTitle2]", this.SupplierContactJobTitle2);
            if (this.PageType.ToLower() == "printbroker" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
            {
                objValue = objValue.Replace("[SupplierContactAddressLabel]", this.SupplierContactAddressLabel);
                objValue = objValue.Replace("[SupplierContactAddressLine1]", this.SupplierContactBusinessAddressLine1);
                objValue = objValue.Replace("[SupplierContactAddressLine2]", this.SupplierContactBusinessAddressLine2);
                objValue = objValue.Replace("[SupplierContactAddressLine3]", this.SupplierContactBusinessAddressLine3);
                objValue = objValue.Replace("[SupplierContactAddressLine4]", this.SupplierContactBusinessAddressLine4);
                objValue = objValue.Replace("[SupplierContactAddressLine5]", this.SupplierContactBusinessAddressLine5);
                objValue = objValue.Replace("[SupplierContactAddressCountry]", this.SupplierContactBusinessCountry);
                objValue = objValue.Replace("[SupplierContactAddressTelephone]", this.SupplierContactBusinessTelephone);
                objValue = objValue.Replace("[SupplierContactAddressFax]", this.SupplierContactBusinessFax);
            }
            objValue = objValue.Replace("[SupplierContactBusinessEmail]", this.SupplierContactBusinessEmail);
            objValue = objValue.Replace("[SupplierContactEmail]", this.SupplierContactBusinessEmail);
            objValue = objValue.Replace("[SupplierContactMobile]", this.SupplierContactMobile);
            objValue = objValue.Replace("[SupplierContactCompanyName]", this.SupplierContactCompanyName);
            objValue = objValue.Replace("[SupplierContactPhone]", this.SupplierContactPhone);
            objValue = objValue.Replace("[SupplierContactPersonalFax]", this.SupplierContactPersonalFax);
        }
        return objValue;
    }

    public float getTextheight(BaseFont baseFont, float fontSize, string strCtrlValue)
    {
        float ascentPoint = baseFont.getAscentPoint(strCtrlValue, fontSize);
        return ascentPoint - baseFont.getDescentPoint(strCtrlValue, fontSize);
    }

    private double HeightForMultiply(string ImageHeight, string PDFHeight, double top)
    {
        top = top / Convert.ToDouble(ImageHeight) * Convert.ToDouble(PDFHeight);
        return top;
    }

    public DataTable InvoiceReportAdjustMent(DataTable dt)
    {
        object[] item;
        Guid guid;
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("TemplateID", typeof(long));
        dataTable.Columns.Add("CompanyID", typeof(int));
        dataTable.Columns.Add("objID", typeof(string));
        dataTable.Columns.Add("objType", typeof(string));
        dataTable.Columns.Add("objName", typeof(string));
        dataTable.Columns.Add("type", typeof(string));
        dataTable.Columns.Add("objValue", typeof(string));
        dataTable.Columns.Add("imgsrc", typeof(string));
        dataTable.Columns.Add("title", typeof(string));
        dataTable.Columns.Add("align", typeof(string));
        dataTable.Columns.Add("position", typeof(string));
        dataTable.Columns.Add("top", typeof(decimal));
        dataTable.Columns.Add("left", typeof(decimal));
        dataTable.Columns.Add("width", typeof(decimal));
        dataTable.Columns.Add("height", typeof(decimal));
        dataTable.Columns.Add("zindex", typeof(string));
        dataTable.Columns.Add("padding", typeof(string));
        dataTable.Columns.Add("display", typeof(string));
        dataTable.Columns.Add("overflow", typeof(string));
        dataTable.Columns.Add("fontfamily", typeof(string));
        dataTable.Columns.Add("fontsize", typeof(string));
        dataTable.Columns.Add("fontweight", typeof(string));
        dataTable.Columns.Add("fontstyle", typeof(string));
        dataTable.Columns.Add("fontcolor", typeof(string));
        dataTable.Columns.Add("textdecoration", typeof(string));
        dataTable.Columns.Add("textalign", typeof(string));
        dataTable.Columns.Add("border", typeof(string));
        dataTable.Columns.Add("backgroundcolor", typeof(string));
        dataTable.Columns.Add("visibility", typeof(string));
        dataTable.Columns.Add("maxlength", typeof(string));
        dataTable.Columns.Add("offsetwidth", typeof(string));
        dataTable.Columns.Add("offsetheight", typeof(string));
        dataTable.Columns.Add("offsettop", typeof(string));
        dataTable.Columns.Add("offsetleft", typeof(string));
        dataTable.Columns.Add("pixelwidth", typeof(string));
        dataTable.Columns.Add("pixelheight", typeof(string));
        dataTable.Columns.Add("pixeltop", typeof(string));
        dataTable.Columns.Add("lock", typeof(string));
        dataTable.Columns.Add("canmove", typeof(string));
        dataTable.Columns.Add("canchangefontcolor", typeof(string));
        dataTable.Columns.Add("canchangefontsize", typeof(string));
        dataTable.Columns.Add("canchangefont", typeof(string));
        dataTable.Columns.Add("class", typeof(string));
        dataTable.Columns.Add("onmouseoverclass", typeof(string));
        dataTable.Columns.Add("objTag", typeof(string));
        dataTable.Columns.Add("isItem", typeof(string));
        dataTable.Columns.Add("GroupID", typeof(long));
        dataTable.Columns.Add("HGroupID", typeof(long));
        dataTable.Columns.Add("isHGroupMain", typeof(string));
        dataTable.Columns.Add("AssociatedLabel", typeof(string));
        dataTable.Columns.Add("isAutoExpand", typeof(bool));
        dataTable.Columns.Add("ItemNumber", typeof(string));
        dataTable.Columns.Add("Repeat", typeof(string));
        this.DefaultInvoiceReportValues = CompanyBasePage.InvoiceReportGenrated_select();
        if (ConnectionClass.ServerName.Trim().ToLower() == "handyenvelopes" || ConnectionClass.ServerName.Trim().ToLower() == "handyexpress")
        {
            bool flag = false;
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            if (this.isFromReport)
            {
                foreach (DataRow row in dt.Rows)
                {
                    item = new object[] { row["TemplateID"], row["CompanyID"], row["objID"], row["objType"], row["objName"], row["type"], row["objValue"], row["imgsrc"], row["title"], row["align"], row["position"], Convert.ToDouble(row["top"]) + num2, row["left"], row["width"], row["height"], row["zindex"], row["padding"], row["display"], row["overflow"], row["fontfamily"], row["fontsize"], row["fontweight"], row["fontstyle"], row["fontcolor"], row["textdecoration"], row["textalign"], row["border"], row["backgroundcolor"], row["visibility"], row["maxlength"], row["offsetwidth"], row["offsetheight"], row["offsettop"], row["offsetleft"], row["pixelwidth"], row["pixelheight"], row["pixeltop"], row["lock"], row["canmove"], row["canchangefontcolor"], row["canchangefontsize"], row["canchangefont"], row["class"], row["onmouseoverclass"], row["objTag"], "n", row["GroupID"], row["HGroupID"], row["isHGroupMain"], row["AssociatedLabel"], row["isAutoExpand"], "0", row["Repeat"] };
                    dataTable.Rows.Add(item);
                    num = Convert.ToDouble(row["top"]);
                    num1 = num;
                    Convert.ToInt32(row["objType"]);
                    if (Convert.ToInt32(row["objType"]) == 9)
                    {
                        flag = true;
                    }
                    if (Convert.ToInt32(row["objType"]) == 8)
                    {
                        flag = false;
                    }
                    int num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["DefaultWidth"]);
                    int num4 = 18;
                    if (!flag)
                    {
                        continue;
                    }
                    double num5 = 30;
                    foreach (DataColumn column in this.dtPDFExportFromInvoiceReport.Columns)
                    {
                        if (!(column.ColumnName.Trim().ToLower() != "estimateid") || !(column.ColumnName.Trim().ToLower() != "invoiceid"))
                        {
                            continue;
                        }
                        string str = "left";
                        string empty = string.Empty;
                        if (column.ColumnName.Trim().ToLower() == "invoicenumber")
                        {
                            empty = "Invoice #";
                            str = "left";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicenumber"]);
                        }
                        else if (column.ColumnName.Trim().ToLower() == "company")
                        {
                            empty = "Company";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["company"]);
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "invoicetitle")
                        {
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicetitle"]);
                            empty = "Invoice Title";
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "salesperson")
                        {
                            empty = "Sales Person";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["salesperson"]);
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "progressedby")
                        {
                            empty = "Created By";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["progressedby"]);
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "createddate")
                        {
                            empty = "Created On";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["createddate"]);
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "status")
                        {
                            empty = "Status";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["status"]);
                            str = "left";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "progresseddate")
                        {
                            empty = "Invoice Date";
                            str = "center";
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["progresseddate"]);
                        }
                        else if (column.ColumnName.Trim().ToLower() == "invoicevalue")
                        {
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicevalue"]);
                            empty = string.Concat("Inv Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str = "right";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "ordernumber")
                        {
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["ordernumber"]);
                            empty = "Cust Order #";
                            str = "center";
                        }
                        else if (column.ColumnName.Trim().ToLower() == "invoiceamountpaid")
                        {
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountpaid"]);
                            empty = string.Concat("Amount Paid (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str = "right";
                        }
                        else if (column.ColumnName.Trim().ToLower() != "invoiceamountoutstanding")
                        {
                            num5 = 100;
                            str = "left";
                            empty = column.ColumnName.ToString();
                        }
                        else
                        {
                            num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountoutstanding"]);
                            empty = string.Concat("Amount Outstanding (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str = "right";
                        }
                        object[] columnName = new object[52];
                        columnName[0] = row["TemplateID"];
                        columnName[1] = row["CompanyID"];
                        guid = Guid.NewGuid();
                        columnName[2] = guid.ToString();
                        columnName[3] = "1";
                        columnName[4] = column.ColumnName;
                        columnName[5] = "divobj";
                        columnName[6] = empty;
                        columnName[7] = "";
                        columnName[8] = "";
                        columnName[9] = str;
                        columnName[10] = "absolute";
                        columnName[11] = num1;
                        columnName[12] = num5;
                        columnName[13] = num3;
                        columnName[14] = num4;
                        columnName[15] = "";
                        columnName[16] = "";
                        columnName[17] = "";
                        columnName[18] = "";
                        columnName[19] = "Arial";
                        columnName[20] = "11pt";
                        columnName[21] = "bolder";
                        columnName[22] = "normal";
                        columnName[23] = "rgb(0, 0, 0)";
                        columnName[24] = "none";
                        columnName[25] = str;
                        columnName[26] = "";
                        columnName[27] = "";
                        columnName[28] = "";
                        columnName[29] = "";
                        columnName[30] = num3;
                        columnName[31] = num4;
                        columnName[32] = num1;
                        columnName[33] = num5;
                        columnName[34] = num3;
                        columnName[35] = num4;
                        columnName[36] = num1;
                        columnName[37] = false;
                        columnName[38] = "1";
                        columnName[39] = "1";
                        columnName[40] = "1";
                        columnName[41] = "1";
                        columnName[42] = "putpointer";
                        columnName[43] = "putpointer";
                        columnName[44] = "";
                        columnName[45] = "y";
                        columnName[46] = row["GroupID"];
                        columnName[47] = row["HGroupID"];
                        columnName[48] = row["isHGroupMain"];
                        columnName[49] = row["AssociatedLabel"];
                        columnName[50] = row["isAutoExpand"];
                        columnName[51] = "0";
                        dataTable.Rows.Add(columnName);
                        num5 = num5 + (double)num3 + 3;
                    }
                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["DefaultWidth"]);
                    double num6 = 0;
                    foreach (DataRow dataRow in this.dtPDFExportFromInvoiceReport.Rows)
                    {
                        num1 = num1 + 20;
                        num5 = 30;
                        int num7 = 0;
                        foreach (DataColumn dataColumn in this.dtPDFExportFromInvoiceReport.Columns)
                        {
                            if (dataColumn.ColumnName.Trim().ToLower() != "estimateid" && dataColumn.ColumnName.Trim().ToLower() != "invoiceid")
                            {
                                string str1 = "left";
                                string empty1 = string.Empty;
                                if (dataColumn.ColumnName.Trim().ToLower() == "createddate")
                                {
                                    str1 = "center";
                                    empty1 = this.objJava.Eprint_return_Date_Before_View(dataRow[num7].ToString(), this.CompanyID, this.UserID, false);
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["createddate"]);
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "progresseddate")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["progresseddate"]);
                                    str1 = "center";
                                    empty1 = this.objJava.Eprint_return_Date_Before_View(dataRow[num7].ToString(), this.CompanyID, this.UserID, false);
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "invoicevalue")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicevalue"]);
                                    str1 = "right";
                                    num6 = num6 + Convert.ToDouble(dataRow[num7]);
                                    empty1 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow[num7].ToString()), 0, "", false, false, true);
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "invoicenumber")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicenumber"]);
                                    empty1 = dataRow[num7].ToString();
                                    str1 = "left";
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "invoicetitle")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicetitle"]);
                                    empty1 = dataRow[num7].ToString();
                                    str1 = "left";
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "ordernumber")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["ordernumber"]);
                                    empty1 = dataRow[num7].ToString();
                                    str1 = "center";
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() == "invoiceamountpaid")
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountpaid"]);
                                    str1 = "right";
                                    num6 = num6 + Convert.ToDouble(dataRow[num7]);
                                    empty1 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow[num7].ToString()), 0, "", false, false, true);
                                }
                                else if (dataColumn.ColumnName.Trim().ToLower() != "invoiceamountoutstanding")
                                {
                                    empty1 = dataRow[num7].ToString();
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["DefaultWidth"]);
                                    str1 = "left";
                                }
                                else
                                {
                                    num3 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountoutstanding"]);
                                    str1 = "right";
                                    num6 = num6 + Convert.ToDouble(dataRow[num7]);
                                    empty1 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow[num7].ToString()), 0, "", false, false, true);
                                }
                                object[] objArray = new object[] { row["TemplateID"], row["CompanyID"], Guid.NewGuid().ToString(), "1", dataColumn.ColumnName, "divobj", empty1, "", "", str1, "absolute", num1, num5, num3, num4, "", "", "", "", "Arial", "9pt", "normal", "normal", "rgb(0, 0, 0)", "none", str1, "", "", "", "", num3, num4, num1, num5, num3, num4, num1, false, "1", "1", "1", "1", "putpointer", "putpointer", "", "y", row["GroupID"], row["HGroupID"], row["isHGroupMain"], row["AssociatedLabel"], row["isAutoExpand"], "0" };
                                dataTable.Rows.Add(objArray);
                                num5 = num5 + (double)num3 + 3;
                            }
                            num7++;
                        }
                    }
                    this.strItemTotal = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num6), 0, "", false, false, true);
                    num2 = num1 - num;
                }
            }
        }
        else
        {
            bool flag1 = false;
            double num8 = 0;
            double num9 = 0;
            double num10 = 0;
            if (this.isFromReport)
            {
                foreach (DataRow row1 in dt.Rows)
                {
                    object[] item1 = new object[] { row1["TemplateID"], row1["CompanyID"], row1["objID"], row1["objType"], row1["objName"], row1["type"], row1["objValue"], row1["imgsrc"], row1["title"], row1["align"], row1["position"], Convert.ToDouble(row1["top"]) + num10, row1["left"], row1["width"], row1["height"], row1["zindex"], row1["padding"], row1["display"], row1["overflow"], row1["fontfamily"], row1["fontsize"], row1["fontweight"], row1["fontstyle"], row1["fontcolor"], row1["textdecoration"], row1["textalign"], row1["border"], row1["backgroundcolor"], row1["visibility"], row1["maxlength"], row1["offsetwidth"], row1["offsetheight"], row1["offsettop"], row1["offsetleft"], row1["pixelwidth"], row1["pixelheight"], row1["pixeltop"], row1["lock"], row1["canmove"], row1["canchangefontcolor"], row1["canchangefontsize"], row1["canchangefont"], row1["class"], row1["onmouseoverclass"], row1["objTag"], "n", row1["GroupID"], row1["HGroupID"], row1["isHGroupMain"], row1["AssociatedLabel"], row1["isAutoExpand"], "0", row1["Repeat"] };
                    dataTable.Rows.Add(item1);
                    num8 = Convert.ToDouble(row1["top"]);
                    num9 = num8;
                    Convert.ToInt32(row1["objType"]);
                    if (Convert.ToInt32(row1["objType"]) == 9)
                    {
                        flag1 = true;
                    }
                    if (Convert.ToInt32(row1["objType"]) == 8)
                    {
                        flag1 = false;
                    }
                    int num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["DefaultWidth"]);
                    int num12 = 18;
                    if (!flag1)
                    {
                        continue;
                    }
                    double num13 = 30;
                    foreach (DataColumn column1 in this.dtPDFExportFromInvoiceReport.Columns)
                    {
                        if (!(column1.ColumnName.Trim().ToLower() != "estimateid") || !(column1.ColumnName.Trim().ToLower() != "invoiceid"))
                        {
                            continue;
                        }
                        string str2 = "left";
                        string empty2 = string.Empty;
                        if (column1.ColumnName.Trim().ToLower() == "invoicenumber")
                        {
                            empty2 = "Invoice #";
                            str2 = "left";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicenumber"]);
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "company")
                        {
                            empty2 = "Company";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["company"]);
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "invoicetitle")
                        {
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicetitle"]);
                            empty2 = "Invoice Title";
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "salesperson")
                        {
                            empty2 = "Sales Person";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["salesperson"]);
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "progressedby")
                        {
                            empty2 = "Created By";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["progressedby"]);
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "createddate")
                        {
                            empty2 = "Created On";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["createddate"]);
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "status")
                        {
                            empty2 = "Status";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["status"]);
                            str2 = "left";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "progresseddate")
                        {
                            empty2 = "Invoice Date";
                            str2 = "center";
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["progresseddate"]);
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "invoicevalue")
                        {
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoicevalue"]);
                            empty2 = string.Concat("Inv Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str2 = "right";
                        }
                        else if (column1.ColumnName.Trim().ToLower() == "invoiceamountpaid")
                        {
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountpaid"]);
                            empty2 = string.Concat("Amount Paid (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str2 = "right";
                        }
                        else if (column1.ColumnName.Trim().ToLower() != "invoiceamountoutstanding")
                        {
                            num13 = 100;
                            str2 = "left";
                            empty2 = column1.ColumnName.ToString();
                        }
                        else
                        {
                            num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["invoiceamountoutstanding"]);
                            empty2 = string.Concat("Amount Outstanding (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                            str2 = "right";
                        }
                        object[] objArray1 = new object[] { row1["TemplateID"], row1["CompanyID"], Guid.NewGuid().ToString(), "1", column1.ColumnName, "divobj", empty2, "", "", str2, "absolute", num9, num13, num11, num12, "", "", "", "", "Arial", "11pt", "bolder", "normal", "rgb(0, 0, 0)", "none", str2, "", "", "", "", num11, num12, num9, num13, num11, num12, num9, false, "1", "1", "1", "1", "putpointer", "putpointer", "", "y", row1["GroupID"], row1["HGroupID"], row1["isHGroupMain"], row1["AssociatedLabel"], row1["isAutoExpand"], "0" };
                        dataTable.Rows.Add(objArray1);
                        num13 = num13 + (double)num11 + 3;
                    }
                    num11 = Convert.ToInt32(this.DefaultInvoiceReportValues.Rows[0]["DefaultWidth"]);
                    double num14 = 0;
                    foreach (DataRow dataRow1 in this.dtPDFExportFromInvoiceReport.Rows)
                    {
                        num9 = num9 + 20;
                        num13 = 30;
                        int num15 = 0;
                        foreach (DataColumn dataColumn1 in this.dtPDFExportFromInvoiceReport.Columns)
                        {
                            if (dataColumn1.ColumnName.Trim().ToLower() != "estimateid" && dataColumn1.ColumnName.Trim().ToLower() != "invoiceid")
                            {
                                string str3 = "left";
                                string empty3 = string.Empty;
                                if (dataColumn1.ColumnName.Trim().ToLower() == "createddate")
                                {
                                    str3 = "center";
                                    empty3 = this.objJava.Eprint_return_Date_Before_View(dataRow1[num15].ToString(), this.CompanyID, this.UserID, false);
                                    num11 = 100;
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() == "progresseddate")
                                {
                                    num11 = 100;
                                    str3 = "center";
                                    empty3 = this.objJava.Eprint_return_Date_Before_View(dataRow1[num15].ToString(), this.CompanyID, this.UserID, false);
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() == "invoicevalue")
                                {
                                    num11 = 100;
                                    str3 = "right";
                                    num14 = num14 + Convert.ToDouble(dataRow1[num15]);
                                    empty3 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1[num15].ToString()), 0, "", false, false, true);
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() == "invoicenumber")
                                {
                                    num11 = 100;
                                    empty3 = dataRow1[num15].ToString();
                                    str3 = "left";
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() == "invoicetitle")
                                {
                                    num11 = 450;
                                    empty3 = dataRow1[num15].ToString();
                                    str3 = "left";
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() == "invoiceamountpaid")
                                {
                                    num11 = 200;
                                    str3 = "right";
                                    num14 = num14 + Convert.ToDouble(dataRow1[num15]);
                                    empty3 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1[num15].ToString()), 0, "", false, false, true);
                                }
                                else if (dataColumn1.ColumnName.Trim().ToLower() != "invoiceamountoutstanding")
                                {
                                    empty3 = dataRow1[num15].ToString();
                                    num11 = 100;
                                    str3 = "left";
                                }
                                else
                                {
                                    num11 = 250;
                                    str3 = "right";
                                    num14 = num14 + Convert.ToDouble(dataRow1[num15]);
                                    empty3 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1[num15].ToString()), 0, "", false, false, true);
                                }
                                item = new object[52];
                                item[0] = row1["TemplateID"];
                                item[1] = row1["CompanyID"];
                                guid = Guid.NewGuid();
                                item[2] = guid.ToString();
                                item[3] = "1";
                                item[4] = dataColumn1.ColumnName;
                                item[5] = "divobj";
                                item[6] = empty3;
                                item[7] = "";
                                item[8] = "";
                                item[9] = str3;
                                item[10] = "absolute";
                                item[11] = num9;
                                item[12] = num13;
                                item[13] = num11;
                                item[14] = num12;
                                item[15] = "";
                                item[16] = "";
                                item[17] = "";
                                item[18] = "";
                                item[19] = "Arial";
                                item[20] = "9pt";
                                item[21] = "normal";
                                item[22] = "normal";
                                item[23] = "rgb(0, 0, 0)";
                                item[24] = "none";
                                item[25] = str3;
                                item[26] = "";
                                item[27] = "";
                                item[28] = "";
                                item[29] = "";
                                item[30] = num11;
                                item[31] = num12;
                                item[32] = num9;
                                item[33] = num13;
                                item[34] = num11;
                                item[35] = num12;
                                item[36] = num9;
                                item[37] = false;
                                item[38] = "1";
                                item[39] = "1";
                                item[40] = "1";
                                item[41] = "1";
                                item[42] = "putpointer";
                                item[43] = "putpointer";
                                item[44] = "";
                                item[45] = "y";
                                item[46] = row1["GroupID"];
                                item[47] = row1["HGroupID"];
                                item[48] = row1["isHGroupMain"];
                                item[49] = row1["AssociatedLabel"];
                                item[50] = row1["isAutoExpand"];
                                item[51] = "0";
                                dataTable.Rows.Add(item);
                                num13 = num13 + (double)num11 + 3;
                            }
                            num15++;
                        }
                    }
                    this.strItemTotal = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num14), 0, "", false, false, true);
                    num10 = num9 - num8;
                }
            }
        }
        return dataTable;
    }

    public void MainFunction(long Main_EstimateID, long Main_jobID, long Main_InvoiceID, string Main_jID, string Main_invid, string Main_PageType, string Main_PDFKey, string Main_IsFrom, string Main_isdirect, long Main_temp_ordid, long Main_OrdID, long Main_TemplateID, long Main_EstimateItemID, long Main_CompanyID, long Main_UserID, ref bool Main_RetRefforPDFVisible, ref ArrayList Main_ArryList_StrFileName, ref bool Main_RetRefforisFromReport)
    {
        DataSet dataSet;
        char[] chrArray;
        object[] item;
        string[] strArrays;
        string str;
        object obj;
        if (ConnectionClass.ServerName != null)
        {
            this.ServerName = ConnectionClass.ServerName;
        }

        this.CompanyID = Convert.ToInt32(Main_CompanyID);
        this.UserID = Convert.ToInt32(Main_UserID);
        this.EstimateID = Main_EstimateID;
        this.jobID = Main_jobID;
        this.InvoiceID = Main_InvoiceID;
        this.jID = Main_jID;
        this.InvID = Main_invid;
        this.PageType = Main_PageType;
        this.PDFKey = Main_PDFKey;
        this.IsFrom = Main_IsFrom;
        this.isdirect = Main_isdirect;
        this.temp_ordid = Main_temp_ordid;
        this.OrdID = Main_OrdID;
        this.TemplateID = Main_TemplateID;
        this.EstimateItemID = Main_EstimateItemID;
        if (this.Session["SelectedItemForPrint"] != null)
        {
            this.SelectedItems = this.Session["SelectedItemForPrint"].ToString();
        }
        if (this.EstimateID == (long)-1)
        {
            this.isFromReport = true;
            Hashtable hashtables = (Hashtable)this.Session["ExportReportToPDF"];
            this.DefaultInvoiceReportValues = CompanyBasePage.InvoiceReportGenrated_select();
            if (this.DefaultInvoiceReportValues.Rows[0]["Query"].ToString().Trim().Length != 0)
            {
                string str1 = string.Concat(this.DefaultInvoiceReportValues.Rows[0]["Query"].ToString(), " AND LTRIM(clnt.clientname) = '", this.PDFKey, "' ORDER BY InvoiceNumber ASC ");
                SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = sqlConnection,
                    CommandText = str1
                };
                (new SqlDataAdapter(sqlCommand)).Fill(this.dtPDFExportFromInvoiceReport);
                sqlConnection.Close();
            }
            else if (hashtables != null)
            {
                string str2 = hashtables[this.PDFKey.Replace("&", "").Replace("+", "")].ToString();
                if (str2.Trim().Length > 0)
                {
                    SqlConnection sqlConnection1 = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
                    sqlConnection1.Open();
                    SqlCommand sqlCommand1 = new SqlCommand()
                    {
                        Connection = sqlConnection1,
                        CommandText = str2
                    };
                    (new SqlDataAdapter(sqlCommand1)).Fill(this.dtPDFExportFromInvoiceReport);
                    sqlConnection1.Close();
                }
            }
        }
        if (!base.IsPostBack)
        {
            this.Session["dtReturnTOPFromGroup"] = null;
            this.Session["dtReturnTOPFromGroupForAll"] = null;
        }
        if (this.PageType.ToLower() == "job" && this.EstimateItemID > (long)0)
        {
            this.PageType = "jobcard";
        }
        bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
        this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
        this.Session["dtTotalPr"] = null;
        this.Session["dtTotalPr_AllItem"] = null;
        if (this.PageType.ToLower() != "printbroker")
        {
            this.strMainModuel = this.PageType;
        }
        else
        {
            this.strMainModuel = string.Concat(this.PageType, "_", this.IsFrom);
        }
        if (this.Session["SelectedItemForPrint"] != null)
        {
            this.ItemIDs = this.Session["SelectedItemForPrint"].ToString();
        }
        if (this.PageType.ToLower() == "jobcard" && this.Session["SelectedItemForPrint"] == null)
        {
            this.ItemIDs = this.EstimateItemID.ToString();
        }
        DataSet dataSet1 = this.objTemplates.settings_template_GetTemplateData_New_tbl(this.CompanyID, this.TemplateID, Convert.ToInt64(this.EstimateID), this.strMainModuel, this.ItemIDs, this.jobID, this.InvoiceID);
        dataSet1.Tables["Table2"].DefaultView.ToTable(true, "EstimateItemId");
        if (this.Session["SelectedItemForPrint"] != null)
        {
            string str3 = this.Session["SelectedItemForPrint"].ToString();
            chrArray = new char[] { ',' };
            string[] strArrays1 = str3.Split(chrArray);
            DataView dataViews = new DataView(dataSet1.Tables[2]);
            bool flag = true;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (this.PageType.Trim().ToLower() != "webstoreorder")
                {
                    dataViews.RowFilter = string.Concat(" EstimateItemID  = ", strArrays1[i]);
                }
                else
                {
                    dataViews.RowFilter = string.Concat(" estitemid = ", strArrays1[i]);
                }
                if (dataViews.Count > 0)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                this.Session["SelectedItemForPrint"] = null;
            }
            else
            {
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    if (this.PageType.Trim().ToLower() != "webstoreorder")
                    {
                        dataViews.RowFilter = string.Concat(" EstimateItemID  = ", strArrays1[j]);
                    }
                    else
                    {
                        dataViews.RowFilter = string.Concat(" estitemid  = ", strArrays1[j]);
                    }
                }
                dataSet1.Tables[2].AcceptChanges();
            }
        }
        if (this.EstimateID == (long)-1 && this.dtPDFExportFromInvoiceReport != null && this.dtPDFExportFromInvoiceReport.Rows.Count > 0)
        {
            this.InvoiceID = (long)Convert.ToInt32(this.dtPDFExportFromInvoiceReport.Rows[0]["Invoiceid"]);
        }
        foreach (DataRow row in dataSet1.Tables[0].Rows)
        {
            this.PDFID = row["PDFID"].ToString();
            this.FooterSpace = row["FooterSpace"].ToString();
            this.HeaderSpace = row["HeaderSpace"].ToString();
            this.PDFName = row["PDFKey"].ToString();
            this.ImageName = row["ImageName"].ToString();
            this.hdnisSplit = row["ItemSplitStatus"].ToString();
            this.isSplitSubitem = Convert.ToBoolean(row["isSplitSubitem"]);
            this.hdnisKeepWithPrevious = row["isKeepWithPrevious"].ToString();
            this.isGroupingBasedOnStockLocation = Convert.ToBoolean(row["isGroupingBasedOnStockLocation"]);
        }
        if (this.TemplateID > (long)0 && !base.IsPostBack)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TemplateID", typeof(long));
            dataTable.Columns.Add("CompanyID", typeof(int));
            dataTable.Columns.Add("objID", typeof(string));
            dataTable.Columns.Add("objType", typeof(string));
            dataTable.Columns.Add("objName", typeof(string));
            dataTable.Columns.Add("type", typeof(string));
            dataTable.Columns.Add("objValue", typeof(string));
            dataTable.Columns.Add("imgsrc", typeof(string));
            dataTable.Columns.Add("title", typeof(string));
            dataTable.Columns.Add("align", typeof(string));
            dataTable.Columns.Add("position", typeof(string));
            dataTable.Columns.Add("top", typeof(decimal));
            dataTable.Columns.Add("left", typeof(decimal));
            dataTable.Columns.Add("width", typeof(decimal));
            dataTable.Columns.Add("height", typeof(decimal));
            dataTable.Columns.Add("zindex", typeof(string));
            dataTable.Columns.Add("padding", typeof(string));
            dataTable.Columns.Add("display", typeof(string));
            dataTable.Columns.Add("overflow", typeof(string));
            dataTable.Columns.Add("fontfamily", typeof(string));
            dataTable.Columns.Add("fontsize", typeof(string));
            dataTable.Columns.Add("fontweight", typeof(string));
            dataTable.Columns.Add("fontstyle", typeof(string));
            dataTable.Columns.Add("fontcolor", typeof(string));
            dataTable.Columns.Add("textdecoration", typeof(string));
            dataTable.Columns.Add("textalign", typeof(string));
            dataTable.Columns.Add("border", typeof(string));
            dataTable.Columns.Add("backgroundcolor", typeof(string));
            dataTable.Columns.Add("visibility", typeof(string));
            dataTable.Columns.Add("maxlength", typeof(string));
            dataTable.Columns.Add("offsetwidth", typeof(string));
            dataTable.Columns.Add("offsetheight", typeof(string));
            dataTable.Columns.Add("offsettop", typeof(string));
            dataTable.Columns.Add("offsetleft", typeof(string));
            dataTable.Columns.Add("pixelwidth", typeof(string));
            dataTable.Columns.Add("pixelheight", typeof(string));
            dataTable.Columns.Add("pixeltop", typeof(string));
            dataTable.Columns.Add("lock", typeof(string));
            dataTable.Columns.Add("canmove", typeof(string));
            dataTable.Columns.Add("canchangefontcolor", typeof(string));
            dataTable.Columns.Add("canchangefontsize", typeof(string));
            dataTable.Columns.Add("canchangefont", typeof(string));
            dataTable.Columns.Add("class", typeof(string));
            dataTable.Columns.Add("onmouseoverclass", typeof(string));
            dataTable.Columns.Add("objTag", typeof(string));
            dataTable.Columns.Add("isItem", typeof(string));
            dataTable.Columns.Add("GroupID", typeof(long));
            dataTable.Columns.Add("HGroupID", typeof(long));
            dataTable.Columns.Add("isHGroupMain", typeof(string));
            dataTable.Columns.Add("AssociatedLabel", typeof(string));
            dataTable.Columns.Add("isAutoExpand", typeof(string));
            dataTable.Columns.Add("ItemNumber", typeof(string));
            dataTable.Columns.Add("Repeat", typeof(string));
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("TemplateID", typeof(long));
            dataTable1.Columns.Add("CompanyID", typeof(int));
            dataTable1.Columns.Add("objID", typeof(string));
            dataTable1.Columns.Add("objType", typeof(string));
            dataTable1.Columns.Add("objName", typeof(string));
            dataTable1.Columns.Add("type", typeof(string));
            dataTable1.Columns.Add("objValue", typeof(string));
            dataTable1.Columns.Add("imgsrc", typeof(string));
            dataTable1.Columns.Add("title", typeof(string));
            dataTable1.Columns.Add("align", typeof(string));
            dataTable1.Columns.Add("position", typeof(string));
            dataTable1.Columns.Add("top", typeof(decimal));
            dataTable1.Columns.Add("left", typeof(decimal));
            dataTable1.Columns.Add("width", typeof(decimal));
            dataTable1.Columns.Add("height", typeof(decimal));
            dataTable1.Columns.Add("zindex", typeof(string));
            dataTable1.Columns.Add("padding", typeof(string));
            dataTable1.Columns.Add("display", typeof(string));
            dataTable1.Columns.Add("overflow", typeof(string));
            dataTable1.Columns.Add("fontfamily", typeof(string));
            dataTable1.Columns.Add("fontsize", typeof(string));
            dataTable1.Columns.Add("fontweight", typeof(string));
            dataTable1.Columns.Add("fontstyle", typeof(string));
            dataTable1.Columns.Add("fontcolor", typeof(string));
            dataTable1.Columns.Add("textdecoration", typeof(string));
            dataTable1.Columns.Add("textalign", typeof(string));
            dataTable1.Columns.Add("border", typeof(string));
            dataTable1.Columns.Add("backgroundcolor", typeof(string));
            dataTable1.Columns.Add("visibility", typeof(string));
            dataTable1.Columns.Add("maxlength", typeof(string));
            dataTable1.Columns.Add("offsetwidth", typeof(string));
            dataTable1.Columns.Add("offsetheight", typeof(string));
            dataTable1.Columns.Add("offsettop", typeof(string));
            dataTable1.Columns.Add("offsetleft", typeof(string));
            dataTable1.Columns.Add("pixelwidth", typeof(string));
            dataTable1.Columns.Add("pixelheight", typeof(string));
            dataTable1.Columns.Add("pixeltop", typeof(string));
            dataTable1.Columns.Add("lock", typeof(string));
            dataTable1.Columns.Add("canmove", typeof(string));
            dataTable1.Columns.Add("canchangefontcolor", typeof(string));
            dataTable1.Columns.Add("canchangefontsize", typeof(string));
            dataTable1.Columns.Add("canchangefont", typeof(string));
            dataTable1.Columns.Add("class", typeof(string));
            dataTable1.Columns.Add("onmouseoverclass", typeof(string));
            dataTable1.Columns.Add("objTag", typeof(string));
            dataTable1.Columns.Add("isItem", typeof(string));
            dataTable1.Columns.Add("GroupID", typeof(long));
            dataTable1.Columns.Add("HGroupID", typeof(long));
            dataTable1.Columns.Add("isHGroupMain", typeof(string));
            dataTable1.Columns.Add("AssociatedLabel", typeof(string));
            dataTable1.Columns.Add("isAutoExpand", typeof(bool));
            dataTable1.Columns.Add("ItemNumber", typeof(string));
            dataTable1.Columns.Add("Repeat", typeof(string));
            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("TemplateID", typeof(long));
            dataTable2.Columns.Add("CompanyID", typeof(int));
            dataTable2.Columns.Add("objID", typeof(string));
            dataTable2.Columns.Add("objType", typeof(string));
            dataTable2.Columns.Add("objName", typeof(string));
            dataTable2.Columns.Add("type", typeof(string));
            dataTable2.Columns.Add("objValue", typeof(string));
            dataTable2.Columns.Add("imgsrc", typeof(string));
            dataTable2.Columns.Add("title", typeof(string));
            dataTable2.Columns.Add("align", typeof(string));
            dataTable2.Columns.Add("position", typeof(string));
            dataTable2.Columns.Add("top", typeof(decimal));
            dataTable2.Columns.Add("left", typeof(decimal));
            dataTable2.Columns.Add("width", typeof(decimal));
            dataTable2.Columns.Add("height", typeof(decimal));
            dataTable2.Columns.Add("zindex", typeof(string));
            dataTable2.Columns.Add("padding", typeof(string));
            dataTable2.Columns.Add("display", typeof(string));
            dataTable2.Columns.Add("overflow", typeof(string));
            dataTable2.Columns.Add("fontfamily", typeof(string));
            dataTable2.Columns.Add("fontsize", typeof(string));
            dataTable2.Columns.Add("fontweight", typeof(string));
            dataTable2.Columns.Add("fontstyle", typeof(string));
            dataTable2.Columns.Add("fontcolor", typeof(string));
            dataTable2.Columns.Add("textdecoration", typeof(string));
            dataTable2.Columns.Add("textalign", typeof(string));
            dataTable2.Columns.Add("border", typeof(string));
            dataTable2.Columns.Add("backgroundcolor", typeof(string));
            dataTable2.Columns.Add("visibility", typeof(string));
            dataTable2.Columns.Add("maxlength", typeof(string));
            dataTable2.Columns.Add("offsetwidth", typeof(string));
            dataTable2.Columns.Add("offsetheight", typeof(string));
            dataTable2.Columns.Add("offsettop", typeof(string));
            dataTable2.Columns.Add("offsetleft", typeof(string));
            dataTable2.Columns.Add("pixelwidth", typeof(string));
            dataTable2.Columns.Add("pixelheight", typeof(string));
            dataTable2.Columns.Add("pixeltop", typeof(string));
            dataTable2.Columns.Add("lock", typeof(string));
            dataTable2.Columns.Add("canmove", typeof(string));
            dataTable2.Columns.Add("canchangefontcolor", typeof(string));
            dataTable2.Columns.Add("canchangefontsize", typeof(string));
            dataTable2.Columns.Add("canchangefont", typeof(string));
            dataTable2.Columns.Add("class", typeof(string));
            dataTable2.Columns.Add("onmouseoverclass", typeof(string));
            dataTable2.Columns.Add("objTag", typeof(string));
            dataTable2.Columns.Add("isItem", typeof(string));
            dataTable2.Columns.Add("GroupID", typeof(long));
            dataTable2.Columns.Add("HGroupID", typeof(long));
            dataTable2.Columns.Add("isHGroupMain", typeof(string));
            dataTable2.Columns.Add("AssociatedLabel", typeof(string));
            dataTable2.Columns.Add("isAutoExpand", typeof(bool));
            dataTable2.Columns.Add("ItemNumber", typeof(string));
            dataTable2.Columns.Add("Repeat", typeof(string));
            this.htTotQtyNum.Add("1", "1");
            this.htTotQtyNum.Add("2", "2");
            this.htTotQtyNum.Add("3", "3");
            this.htTotQtyNum.Add("4", "4");
            if (this.PageType.ToLower() == "printbroker")
            {
                DataTable item1 = dataSet1.Tables[2];
                if (string.IsNullOrEmpty(this.isdirect))
                {
                    dataSet = SettingsBasePage.Estimate_Outwork_Supplier_Select((long)this.CompanyID, this.EstimateID);
                }
                else
                {
                    foreach (DataRow dataRow in item1.Rows)
                    {
                        if (Convert.ToInt64(dataRow["EstimateItemID"]) == this.EstimateItemID)
                        {
                            continue;
                        }
                        dataRow.Delete();
                    }
                    item1.AcceptChanges();
                    dataSet = SettingsBasePage.Estimate_Outwork_Supplier_Select_per_Item(this.EstimateItemID);
                }
                this.EstItemType = "O";
                this.SupCount = 1;
                this.TotSupCount = item1.Rows.Count;
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    this.PSupplierID = dataSet.Tables[0].Rows[0]["SupplierID"].ToString();
                }
                foreach (DataRow row1 in item1.Rows)
                {
                    this.SupplierID = Convert.ToInt32(row1["SupplierID"].ToString());
                    this.SupplierContactID = Convert.ToInt32(row1["SupplierContactID"].ToString());
                    this.SupplierName = row1["SupplierName"].ToString();
                    this.SupplierContactName = row1["ContactName"].ToString();
                    this.CustomerOrderNumber = row1["CustomerOrderNumber"].ToString();
                    this.Header = row1["Header"].ToString();
                    this.Footer = row1["Footer"].ToString();
                    this.RFQDesc = row1["RFQDescription"].ToString();
                    string str4 = row1["KeyCode"].ToString();
                    this.isFirstTime = false;
                    dataTable.Clear();
                    // firstitem qty 1 - 4
                    int pbrow1 = item1.Rows.IndexOf(row1);
                    int fiqestitemid = 0;
                    if (pbrow1 == 0)
                    {
                        fiqestitemid = Convert.ToInt32(row1["EstimateItemID"]);
                    }

                    foreach (DataRow dataRow1 in dataSet1.Tables[1].Rows)
                    {
                        this.objValue = dataRow1["objValue"].ToString();
                        if (dataRow1["objName"].ToString().Trim().ToLower() == "supplierquotedirectlink")
                        {
                            this.objValue = string.Concat(this.objValue, "~|~", str4);
                        }
                        if (this.objValue.IndexOf('[') != -1)
                        {
                            this.objTag = dataRow1["objTag"].ToString();
                            this.objType = dataRow1["objType"].ToString();
                            this.objTop = Convert.ToInt32(dataRow1["top"]);
                            if (this.objType == "3" || this.objType == "8" || this.objType == "9" || this.objType == "10" || this.objType == "11" || this.objType == "12")
                            {
                                this.objValue = dataRow1["objValue"].ToString();
                                if (this.objType == "9")
                                {
                                    this.TopSeparator = Convert.ToInt32(dataRow1["top"]);
                                }
                                if (this.objType == "8")
                                {
                                    this.EndSeparator = Convert.ToInt32(dataRow1["top"]);
                                }
                            }
                            this.IncreasedHeight = this.EndSeparator - this.TopSeparator;
                            this.SingleItemHeight = this.IncreasedHeight;

                            // 52385 first item quantity      
                            if ((this.objValue == "[FirstItemQuantity1]") || (this.objValue == "[FirstItemQuantity2]") || (this.objValue == "[FirstItemQuantity3]") || (this.objValue == "[FirstItemQuantity4]"))
                            {
                                DataTable tblPrintBrokerQuantity = new DataTable();
                                tblPrintBrokerQuantity = this.objTemplates.templates_quantity_details_select_new(this.CompanyID, 0, Convert.ToInt64(fiqestitemid), this.EstItemType, this.PageType);

                                for (int rowno = 0; rowno < tblPrintBrokerQuantity.Rows.Count; rowno++)
                                {
                                    if (tblPrintBrokerQuantity.Rows.Count == 4)
                                    {
                                        switch (rowno)
                                        {
                                            case 0:
                                                this.firstItemQuantity1 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 1:
                                                this.firstItemQuantity2 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 2:
                                                this.firstItemQuantity3 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 3:
                                                this.firstItemQuantity4 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;
                                        }
                                    }
                                    if (tblPrintBrokerQuantity.Rows.Count == 8)
                                    {
                                        switch (rowno)
                                        {
                                            case 0:
                                                this.firstItemQuantity1 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 2:
                                                this.firstItemQuantity2 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 4:
                                                this.firstItemQuantity3 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;

                                            case 6:
                                                this.firstItemQuantity4 = Convert.ToInt32(tblPrintBrokerQuantity.Rows[rowno]["Quantity"]);
                                                break;
                                        }
                                    }

                                }
                            }

                            // end

                            this.objValue = this.Return_Top_TotalPrice_Details(this.objValue, this.CompanyID, this.EstimateID, this.PageType, this.TemplateID);
                            this.objValue = this.Return_Top_TotalPrice_Details_AllItem(this.objValue, this.CompanyID, this.EstimateID, this.PageType, this.TemplateID);
                            Hashtable hashtables1 = new Hashtable()
                            {
                                { "1", "1" },
                                { "2", "2" },
                                { "3", "3" },
                                { "4", "4" }
                            };
                            int num = 1;
                            bool flag1 = false;
                            if (!this.isFirstTime)
                            {
                                this.dtQty = this.objTemplates.templates_quantity_details_select_new(this.CompanyID, this.EstimateID, Convert.ToInt64(row1["EstimateItemID"].ToString()), this.EstItemType, this.PageType);
                            }
                            foreach (DataRow row2 in this.dtQty.Rows)
                            {
                                this.objValue = this.objValue.Replace("[JobCompletionDate]", this.objJava.Eprint_return_Date_Before_View(row2["JobCompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                                this.objValue = this.objValue.Replace("[RFQReturnDate]", this.objJava.Eprint_return_Date_Before_View(row2["RFQReturnDate"].ToString(), this.CompanyID, this.UserID, false));
                                this.objValue = this.objValue.Replace("[RFQReturnTime]", row2["RFQReturnTime"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierCreditLimit]", row2["SupplierCreditLimit"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierCreditReference]", row2["SupplierCreditReference"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierTaxName]", row2["SupplierTaxName"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierDescription]", row2["SupplierDescription"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierCompanyNumber]", row2["SupplierCompanyNumber"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierCompanyType]", row2["SupplierCompanyType"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierSalesPerson]", row2["SupplierSalesPerson"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierProfitMarginPercentage]", row2["SupplierProfitMarginPercentage"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierTaxRegNumber]", row2["SupplierTaxRegNumber"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierAccountOpenedDate]", row2["SupplierAccountOpenedDate"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierBankCode]", row2["SupplierBankCode"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierBankAccountNumber]", row2["SupplierBankAccountNumber"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierAccountName]", row2["SupplierAccountName"].ToString());
                                this.objValue = this.objValue.Replace("[SupplierReferredBy]", row2["SupplierReferredBy"].ToString());
                                this.objValue = this.objValue.Replace("[QuantityDescription1]", row2["QtyDescription1"].ToString());
                                this.objValue = this.objValue.Replace("[QuantityDescription2]", row2["QtyDescription2"].ToString());
                                this.objValue = this.objValue.Replace("[QuantityDescription3]", row2["QtyDescription3"].ToString());
                                this.objValue = this.objValue.Replace("[QuantityDescription4]", row2["QtyDescription4"].ToString());
                                if (this.PageType.ToLower() == "printbroker")
                                {
                                    this.objValue = this.objValue.Replace("[CustomDate1]", row2["Customdate1"].ToString());
                                    this.objValue = this.objValue.Replace("[CustomDate2]", row2["Customdate2"].ToString());
                                    this.objValue = this.objValue.Replace("[CustomDate3]", row2["Customdate3"].ToString());
                                    this.objValue = this.objValue.Replace("[CustomDate4]", row2["Customdate4"].ToString());
                                    this.objValue = this.objValue.Replace("[CustomDate5]", row2["Customdate5"].ToString());
                                }



                                if (Convert.ToBoolean(row2["IsSelected"].ToString()) && row2["QuantityNumber"].ToString() != "0")
                                {
                                    this.objValue = this.objValue.Replace(string.Concat("[SupplierQuote#", row2["QuantityNumber"].ToString(), "]"), row2["SupplierRefNo"].ToString());
                                }
                                if (this.SupplierID != Convert.ToInt32(row2["SupplierID"]))
                                {
                                    continue;
                                }
                                this.PCSupplierID = row2["SupplierID"].ToString();
                                if (row2["Quantity"].ToString() != "0")
                                {
                                    hashtables1.Remove(num);
                                    this.objValue = this.objValue.Replace(string.Concat("[Quantity", num, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["Quantity"].ToString()), 0, "", true, false, true));
                                    this.objValue = this.objValue.Replace(string.Concat("[Tax", num, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TaxValue"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[Price", num, "(exTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalSubTotal1"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[Price", num, "(inTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["PriceInTax"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[ProfitMarginPrice", num, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["ProfitMarginValue"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[CostPrice", num, "(exMarkup)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["CostExMarkup"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[CostPrice", num, "(InMarkup)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["CostInMarkup"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[MarkupPrice", num, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["MarkupPrice"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[GrossProfitPrice", num, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["GrossProfitPrice"].ToString()), 0, "", false, false, true), true));
                                    this.objValue = this.objValue.Replace(string.Concat("[GrossProfitPercentage", num, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["GrossProfitPercentage"].ToString()), 0, "", false, false, true), " %"));
                                    this.objValue = this.objValue.Replace(string.Concat("[SubTotal", num, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalSubTotal1"].ToString()), 0, "", false, false, true), true));

                                    if (!flag1)
                                    {
                                        if (num == 1)
                                        {
                                            this.FinalTotalPrice1ExTax = this.FinalTotalPrice1ExTax + Convert.ToDecimal(row2["TotalSubTotal1"]);
                                            this.FinalTotalTaxValue1 = this.FinalTotalTaxValue1 + Convert.ToDecimal(row2["TaxValue"]);
                                            try
                                            {
                                                this.FinalTotalQuantity1 = this.FinalTotalQuantity1 + Convert.ToInt32(row2["Quantity"].ToString());
                                                this.FinalTotalProfitMarginPrice1 = this.FinalTotalProfitMarginPrice1 + Convert.ToDecimal(row2["ProfitMarginValue"].ToString());
                                                this.FinalTotalCostPrice1ExMarkup = this.FinalTotalCostPrice1ExMarkup + Convert.ToDecimal(row2["CostExMarkup"]);
                                                this.FinalTotalMarkupPrice1 = this.FinalTotalMarkupPrice1 + Convert.ToDecimal(row2["MarkupPrice"]);
                                                this.FinalTotalGrossProfitPrice1 = this.FinalTotalGrossProfitPrice1 + Convert.ToDecimal(row2["GrossProfitPrice"]);
                                                this.FinalTotalGrossProfitPercentage1 = this.FinalTotalGrossProfitPercentage1 + Convert.ToDecimal(row2["GrossProfitPercentage"]);
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        if (num == 2)
                                        {
                                            this.FinalTotalPrice2ExTax = this.FinalTotalPrice2ExTax + Convert.ToDecimal(row2["TotalSubTotal1"]);
                                            this.FinalTotalTaxValue2 = this.FinalTotalTaxValue2 + Convert.ToDecimal(row2["TaxValue"]);
                                            try
                                            {
                                                this.FinalTotalQuantity2 = this.FinalTotalQuantity2 + Convert.ToInt32(row2["Quantity"].ToString());
                                                this.FinalTotalProfitMarginPrice2 = this.FinalTotalProfitMarginPrice2 + Convert.ToDecimal(row2["ProfitMarginValue"].ToString());
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        if (num == 3)
                                        {
                                            this.FinalTotalPrice3ExTax = this.FinalTotalPrice3ExTax + Convert.ToDecimal(row2["TotalSubTotal1"]);
                                            this.FinalTotalTaxValue3 = this.FinalTotalTaxValue3 + Convert.ToDecimal(row2["TaxValue"]);
                                            try
                                            {
                                                this.FinalTotalQuantity3 = this.FinalTotalQuantity3 + Convert.ToInt32(row2["Quantity"].ToString());
                                                this.FinalTotalProfitMarginPrice3 = this.FinalTotalProfitMarginPrice3 + Convert.ToDecimal(row2["ProfitMarginValue"].ToString());
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        if (num == 4)
                                        {
                                            this.FinalTotalPrice4ExTax = this.FinalTotalPrice4ExTax + Convert.ToDecimal(row2["TotalSubTotal1"]);
                                            this.FinalTotalTaxValue4 = this.FinalTotalTaxValue4 + Convert.ToDecimal(row2["TaxValue"]);
                                            try
                                            {
                                                this.FinalTotalQuantity4 = this.FinalTotalQuantity4 + Convert.ToInt32(row2["Quantity"].ToString());
                                                this.FinalTotalProfitMarginPrice4 = this.FinalTotalProfitMarginPrice4 + Convert.ToDecimal(row2["ProfitMarginValue"].ToString());
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                }
                                num++;
                            }
                            this.strFinalTotalPrice1ExTax = this.FinalTotalPrice1ExTax;
                            this.strFinalTotalPrice2ExTax = this.FinalTotalPrice2ExTax;
                            this.strFinalTotalPrice3ExTax = this.FinalTotalPrice3ExTax;
                            this.strFinalTotalPrice4ExTax = this.FinalTotalPrice4ExTax;
                            this.strFinalTotalTaxValue1 = this.FinalTotalTaxValue1;
                            this.strFinalTotalTaxValue2 = this.FinalTotalTaxValue2;
                            this.strFinalTotalTaxValue3 = this.FinalTotalTaxValue3;
                            this.strFinalTotalTaxValue4 = this.FinalTotalTaxValue4;
                            this.strFinalTotalQuantity1 = this.FinalTotalQuantity1;
                            this.strFinalTotalQuantity2 = this.FinalTotalQuantity2;
                            this.strFinalTotalQuantity3 = this.FinalTotalQuantity3;
                            this.strFinalTotalQuantity4 = this.FinalTotalQuantity4;
                            this.strFinalTotalProfitMarginPrice1 = this.FinalTotalProfitMarginPrice1;
                            this.strFinalTotalProfitMarginPrice2 = this.FinalTotalProfitMarginPrice2;
                            this.strFinalTotalProfitMarginPrice3 = this.FinalTotalProfitMarginPrice3;
                            this.strFinalTotalProfitMarginPrice4 = this.FinalTotalProfitMarginPrice4;
                            this.strFinalTotalCostPrice1ExMarkup = this.FinalTotalCostPrice1ExMarkup;
                            this.strFinalTotalMarkupPrice1 = this.FinalTotalMarkupPrice1;
                            this.strFinalTotalGrossProfitPrice1 = this.FinalTotalGrossProfitPrice1;
                            this.strFinalTotalGrossProfitPercentage1 = this.FinalTotalGrossProfitPercentage1;
                            if (this.objValue.IndexOf('[') > -1)
                            {
                                foreach (string value in hashtables1.Values)
                                {
                                    if (!this.objValue.Contains(string.Concat("[Quantity", value, "]")) && !this.objValue.Contains(string.Concat("[Tax", value, "]")) && !this.objValue.Contains(string.Concat("[Price", value, "(inTax)]")) && !this.objValue.Contains(string.Concat("[Price", value, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value, "(inTax)]")) && !this.objValue.Contains(string.Concat("[TotalTax", value, "]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalProfitMarginPrice", value, "]")) && !this.objValue.Contains(string.Concat("[ProfitMarginPrice", value, "]")) && !this.objValue.Contains(string.Concat("[CostPrice", value, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[MarkupPrice", value, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPrice", value, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPercentage", value, "]")) && !this.objValue.Contains(string.Concat("[SubTotal", value, "]")) && !this.objValue.Contains(string.Concat("[TotalCostPrice", value, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[TotalMarkupPrice", value, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPrice", value, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPercentage", value, "]")) && !this.objValue.Contains(string.Concat("[SupplierQuote#", value, "]")) && !this.objValue.Contains(string.Concat("[CostPrice", value, "(InMarkup)]")) && !this.objValue.Contains("[QuantityDescription1]") && !this.objValue.Contains("[QuantityDescription2]") && !this.objValue.Contains("[QuantityDescription3]") && !this.objValue.Contains("[QuantityDescription4]"))
                                    {
                                        continue;
                                    }
                                    this.objValue = this.objValue.Replace(this.objValue, "");
                                    break;
                                }
                            }
                            if (this.PageType.ToLower() == "job")
                            {
                                SqlConnection sqlConnection2 = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
                                SqlCommand sqlCommand2 = new SqlCommand("[PC_job_details_select_forheaderandfooter]");
                                sqlConnection2.Open();
                                sqlCommand2.Connection = sqlConnection2;
                                sqlCommand2.CommandType = CommandType.StoredProcedure;
                                sqlCommand2.Parameters.Add("@CompanyID", this.CompanyID);
                                sqlCommand2.Parameters.Add("@EstimateID", this.EstimateID);
                                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                                DataSet dataSet2 = new DataSet();
                                sqlDataAdapter.Fill(dataSet2);
                                sqlConnection2.Close();
                                foreach (DataRow dataRow2 in dataSet2.Tables[0].Rows)
                                {
                                    this.Header = BaseClass.WrapString(dataRow2["Header"].ToString(), 210);
                                    this.objValue = this.objValue.Replace("[Header]", this.Header);
                                    this.Footer = BaseClass.WrapString(dataRow2["Footer"].ToString(), 210);
                                    this.objValue = this.objValue.Replace("[Footer]", this.Footer);
                                }
                            }
                            this.objValue = this.objValue.Replace("[SupplierName]", this.SupplierName);
                            this.objValue = this.objValue.Replace("[SupplierContactFullName]", this.SupplierContactName);
                            this.objValue = this.objValue.Replace("[Header]", this.Header);
                            this.objValue = this.objValue.Replace("[Footer]", this.Footer);
                            string str5 = this.objValue;
                            string supplierContactName = this.SupplierContactName;
                            chrArray = new char[] { ' ' };
                            this.objValue = str5.Replace("[Greeting]", string.Concat("Dear ", supplierContactName.Split(chrArray)[0].ToString()));
                            this.objValue = this.objValue.Replace("[CustomerOrderNumber]", this.CustomerOrderNumber);

                            if (objValue.Contains("[TotalPriceDeliveryItemsExTax]"))
                            {
                                try
                                {
                                    string itemsid = "";
                                    using (SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString()))
                                    {
                                        string query = @"SELECT DISTINCT ItemID FROM tb_DeliveryItem WHERE DeliveryID = @DeliveryID AND IsDeleted = 0";
                                        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                                        {
                                            cmd.Parameters.AddWithValue("@DeliveryID", Convert.ToInt64(this.EstimateID));
                                            sqlConnection.Open();
                                            using (SqlDataReader reader = cmd.ExecuteReader())
                                            {
                                                List<string> itemIds = new List<string>();
                                                while (reader.Read())
                                                {
                                                    itemIds.Add(reader["ItemID"].ToString());
                                                }
                                                itemsid = string.Join(",", itemIds);
                                            }
                                        }
                                    }

                                    this.DeliveryItemTotalCostExMarkup = GetDelivryItemTotalExTax(this.CompanyID, itemsid);
                                    this.objValue = this.objValue.Replace("[TotalPriceDeliveryItemsExTax]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.DeliveryItemTotalCostExMarkup.ToString()), 0, "", false, false, true), true));
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            this.objValue = this.Return_ItemDescriptionForSupplier(this.objValue, this.RFQDesc, this.EstItemType);
                            decimal num1 = this.strFinalTotalPrice1ExTax + this.strFinalTotalTaxValue1;
                            decimal num2 = this.strFinalTotalPrice2ExTax + this.strFinalTotalTaxValue2;
                            decimal num3 = this.strFinalTotalPrice3ExTax + this.strFinalTotalTaxValue3;
                            decimal num4 = this.strFinalTotalPrice4ExTax + this.strFinalTotalTaxValue4;

                            if (objValue.Contains("[LineItems]"))
                            {
                                try
                                {
                                    var itemcount = dataSet1.Tables[2].Rows.Count;
                                    this.objValue = this.objValue.Replace("[LineItems]", itemcount.ToString());
                                }
                                catch (Exception ex)
                                {
                                }
                            }



                            if (this.FinalTotalQuantity1 > new decimal(0))
                            {
                                this.objValue = this.objValue.Replace("[TotalPrice1(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice1ExTax), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalTax1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue1), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalQuantity1]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity1), 0, "", true, false, true));
                                this.objValue = this.objValue.Replace("[TotalProfitMarginPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice1), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalPrice1(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num1), 0, "", false, false, true), true));
                            }
                            if (this.FinalTotalQuantity2 > new decimal(0))
                            {
                                this.objValue = this.objValue.Replace("[TotalPrice2(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice2ExTax), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalTax2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue2), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalQuantity2]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity2), 0, "", true, false, true));
                                this.objValue = this.objValue.Replace("[TotalProfitMarginPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice2), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalPrice2(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num2), 0, "", false, false, true), true));
                            }
                            if (this.FinalTotalQuantity3 > new decimal(0))
                            {
                                this.objValue = this.objValue.Replace("[TotalPrice3(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice3ExTax), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalTax3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue3), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalQuantity3]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity3), 0, "", true, false, true));
                                this.objValue = this.objValue.Replace("[TotalProfitMarginPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice3), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalPrice3(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3), 0, "", false, false, true), true));
                            }
                            if (this.FinalTotalQuantity4 > new decimal(0))
                            {
                                this.objValue = this.objValue.Replace("[TotalPrice4(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice4ExTax), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalTax4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue4), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalQuantity4]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity4), 0, "", true, false, true));
                                this.objValue = this.objValue.Replace("[TotalProfitMarginPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice4), 0, "", false, false, true), true));
                                this.objValue = this.objValue.Replace("[TotalPrice4(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num4), 0, "", false, false, true), true));
                            }
                            hashtables1.Clear();
                            hashtables1.Add("1", "1");
                            hashtables1.Add("2", "2");
                            hashtables1.Add("3", "3");
                            hashtables1.Add("4", "4");
                            if (this.objValue.IndexOf('[') > -1)
                            {
                                foreach (string value1 in hashtables1.Values)
                                {
                                    if (!this.objValue.Contains(string.Concat("[Quantity", value1, "]")) && !this.objValue.Contains(string.Concat("[Tax", value1, "]")) && !this.objValue.Contains(string.Concat("[Price", value1, "(inTax)]")) && !this.objValue.Contains(string.Concat("[Price", value1, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value1, "(inTax)]")) && !this.objValue.Contains(string.Concat("[TotalTax", value1, "]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value1, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value1, "(ex Tax)]")) && !this.objValue.Contains(string.Concat("[TotalProfitMarginPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[ProfitMarginPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[CostPrice", value1, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[MarkupPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPercentage", value1, "]")) && !this.objValue.Contains(string.Concat("[SubTotal", value1, "]")) && !this.objValue.Contains(string.Concat("[TotalCostPrice", value1, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[TotalMarkupPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPrice", value1, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPercentage", value1, "]")) && !this.objValue.Contains(string.Concat("[SupplierQuote#", value1, "]")) && !this.objValue.Contains(string.Concat("[TotalQuantity", value1, "]")) && !this.objValue.Contains(string.Concat("[CostPrice", value1, "(InMarkup)]")))
                                    {
                                        continue;
                                    }
                                    this.objValue = this.objValue.Replace(this.objValue, "");
                                    break;
                                }
                            }
                            if (!this.isFirstTime)
                            {
                                this.dtrPBValue = this.objTemplates.settings_template_FieldValue_select(this.CompanyID, Convert.ToInt32(this.EstimateID));
                            }
                            foreach (DataRow row3 in this.dtrPBValue.Rows)
                            {
                                this.CustomerID = Convert.ToInt32(row3["CustomerID"]);
                                this.AddressID = Convert.ToInt32(row3["AddressID"]);
                                this.AddressType = row3["AddressType"].ToString();
                                if (this.PageType.ToLower() != "printbroker")
                                {
                                    this.EstAddress = row3["Address"].ToString();
                                }
                                else
                                {
                                    this.EstAddress = row3["EstimateInvoiceAddress"].ToString();
                                }
                                this.DeliveryAddressID = Convert.ToInt32(row3["DeliveryAddressID"]);
                                this.DeliveryAddressType = row3["DeliveryAddressType"].ToString();
                                this.Attention = row3["Attention"].ToString();
                                if (this.PageType.ToLower() == "estimate")
                                {
                                    this.EstCreatedDate = row3["EstCreatedDate"].ToString();
                                }
                                this.objValue = this.objValue.Replace("[EstimatedDate]", this.objJava.Eprint_return_Date_Before_View(row3["EstimatedDate"].ToString(), this.CompanyID, this.UserID, false));
                                this.objValue = this.objValue.Replace("[CreatedDate]", this.objJava.Eprint_return_Date_Before_View(row3["EstCreatedDate"].ToString(), this.CompanyID, this.UserID, false));
                                this.objValue = this.objValue.Replace("[DeliveryDate]", this.objJava.Eprint_return_Date_Before_View(row3["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false));
                                this.objValue = this.objValue.Replace("[Contact]", row3["Attention"].ToString());
                                try
                                {
                                    string str6 = this.objTag.ToString().Trim();
                                    if (str6.Length > 2)
                                    {
                                        str6 = str6.Substring(1, str6.Length - 2);
                                        if (row3.Table.Columns.Contains(str6))
                                        {
                                            this.objValueTag = row3[str6].ToString();
                                            this.objValue = this.objValue.Replace(this.objTag, this.objValueTag);
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (!this.isFirstTime)
                            {
                                this.GetInvoiceContactFromDataBase(this.CompanyID, Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.InvoiceID));
                                this.GetCustomerandCompanyAddressFromDataBase(this.CompanyID, this.CustomerID);
                                this.GetSupplierAddressFromDataBase(this.CompanyID, this.SupplierID);
                                this.GetSupplierContactAddressFromDataBase(this.CompanyID, this.SupplierContactID);
                                this.GetEstimateJobInvoicePurchaseDeliveryAddressFromDataBase(this.CompanyID, this.AddressID, this.AddressType, this.EstAddress);
                                this.isFirstTime = true;
                            }
                            if (this.PageType.ToLower() == "estimate")
                            {
                                this.EstCreatedDate = this.objJava.Eprint_return_Date_Before_View(this.EstCreatedDate, this.CompanyID, this.UserID, false);
                                this.objValue = this.objValue.Replace("[CreatedDate]", this.EstCreatedDate);
                            }
                            this.objValue = this.GetCustomerAddressFromPage(this.objValue);
                            this.objValue = this.GetCompanyAddressFromPage(this.objValue);
                            this.objValue = this.GetSupplierAddressFromPage(this.objValue);
                            this.objValue = this.GetSupplierContactAddressFromPage(this.objValue);
                            if (this.PageType.ToLower() != "invoice")
                            {
                                this.objValue = this.GetDeliveryAddress(this.objValue, this.CompanyID, this.EstimateID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                            }
                            else
                            {
                                this.objValue = this.GetDeliveryAddress(this.objValue, this.CompanyID, this.InvoiceID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                            }
                            this.objValue = this.GetEstimateJobInvoicePurchaseDeliveryAddressFromPage(this.objValue);
                        }
                        item = new object[] { dataRow1["TemplateID"], dataRow1["CompanyID"], dataRow1["objID"], dataRow1["objType"], dataRow1["objName"], dataRow1["type"], this.objValue, dataRow1["imgsrc"], dataRow1["title"], dataRow1["align"], dataRow1["position"], dataRow1["top"], dataRow1["left"], dataRow1["width"], dataRow1["height"], dataRow1["zindex"], dataRow1["padding"], dataRow1["display"], dataRow1["overflow"], dataRow1["fontfamily"], dataRow1["fontsize"], dataRow1["fontweight"], dataRow1["fontstyle"], dataRow1["fontcolor"], dataRow1["textdecoration"], dataRow1["textalign"], dataRow1["border"], dataRow1["backgroundcolor"], dataRow1["visibility"], dataRow1["maxlength"], dataRow1["offsetwidth"], dataRow1["offsetheight"], dataRow1["offsettop"], dataRow1["offsetleft"], dataRow1["pixelwidth"], dataRow1["pixelheight"], dataRow1["pixeltop"], dataRow1["lock"], dataRow1["canmove"], dataRow1["canchangefontcolor"], dataRow1["canchangefontsize"], dataRow1["canchangefont"], dataRow1["class"], dataRow1["onmouseoverclass"], dataRow1["objTag"], "n", dataRow1["GroupID"], dataRow1["HGroupID"], dataRow1["isHGroupMain"], dataRow1["AssociatedLabel"], dataRow1["isAutoExpand"], "0", dataRow1["Repeat"] };
                        dataTable.Rows.Add(item);
                    }
                    this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = dataTable;
                    foreach (DataRow dataRow3 in dataSet1.Tables[3].Rows)
                    {
                        this.FooterTop = Convert.ToDecimal(dataRow3["FooterTop"]);
                        this.LastElementHeight = Convert.ToDecimal(dataRow3["LastElementHeight"]);
                    }
                    this.generatePDF(dataTable, this.PDFID, this.FooterSpace, this.HeaderSpace, this.PDFName, this.FooterTop, this.LastElementHeight, this.SupCount, this.TotSupCount, this.ImageName, Convert.ToInt32(row1["EstimateItemID"]), this.SupplierID, ref Main_RetRefforPDFVisible, ref Main_ArryList_StrFileName, ref Main_RetRefforisFromReport);
                    pdfGenerate supCount = this;
                    supCount.SupCount = supCount.SupCount + 1;
                }
            }
            else if (this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] != null)
            {
                dataTable = (DataTable)this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())];
                GC.Collect();
                string empty = string.Empty;
                string empty1 = string.Empty;
                DataTable dataTable3 = new DataTable();
                if (this.PageType.ToString().ToLower() != "job")
                {
                    dataTable3 = (this.PageType.ToString().ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.EstimateID, this.PageType.ToString()) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.InvoiceID, this.PageType.ToString()));
                }
                else
                {
                    dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.jobID, this.PageType.ToString());
                }
                foreach (DataRow row4 in dataTable3.Rows)
                {
                    empty = row4["Number"].ToString();
                    empty1 = row4["TemNameLastCounter"].ToString();
                }
                string str7 = string.Concat(empty, "-", empty1, ".pdf");
                if (this.PDFKey != "")
                {
                    SettingsBasePage.settings_template_emailed_insert(str7, this.PDFKey, (long)this.CompanyID);
                }
                this.generatePDF(dataTable, this.PDFID, this.FooterSpace, this.HeaderSpace, this.PDFName, Convert.ToDecimal(this.Session["FooterTop"]), Convert.ToDecimal(this.Session["LastElementHeight"]), 0, 0, this.ImageName, 0, 0, ref Main_RetRefforPDFVisible, ref Main_ArryList_StrFileName, ref Main_RetRefforisFromReport);
            }
            else
            {
                bool flag2 = false;
                string deliveryNoteProductTitle = string.Empty; // if not used remoeve
                var lstdeliveryNoteProductTitle = new List<string>();
                bool isTitleAdded = false;
                bool isLine = false;
                DataSet _ds = this.objTemplates.settings_template_CustomeFieldValue_select(this.CompanyID, Convert.ToInt64(this.EstimateID), this.PageType.ToLower());

                foreach (DataRow dataRow4 in dataSet1.Tables[1].Rows)
                {
                    string str8 = dataRow4["objValue"].ToString();
                    this.objValue = dataRow4["objValue"].ToString();
                    this.objTag = dataRow4["objTag"].ToString();
                    this.objType = dataRow4["objType"].ToString();
                    this.objTop = Convert.ToInt32(dataRow4["top"]);
                    if ((this.PageType.ToLower() == "job" || this.PageType.ToLower() == "purchase") && this.EstimateItemID <= (long)0)
                    {
                        this.objValue = this.Return_ArtWorkDateDetails(this.objValue, Convert.ToInt32(this.EstimateID), this.PageType);
                    }
                    if (this.objType == "3" || this.objType == "8" || this.objType == "9" || this.objType == "10" || this.objType == "11" || this.objType == "12" || this.objType == "15" || this.objType == "16")
                    {
                        this.objValue = dataRow4["objValue"].ToString();
                        if (this.objType == "9")
                        {
                            this.TopSeparator = Convert.ToInt32(dataRow4["top"]);
                            this.flag = true;
                        }
                        if (this.objType == "16")
                        {
                            flag2 = true;
                            this.SubItemTopSeparator = Convert.ToInt32(dataRow4["top"]);
                            this.flagsubItem = true;
                            this.flag = false;
                        }
                        if (this.objType == "15")
                        {
                            flag2 = true;
                            this.SubItemEndSeparator = Convert.ToInt32(dataRow4["top"]);
                            this.flagsubItem = false;
                            this.flag = true;
                        }
                        if (this.objType == "8")
                        {
                            this.EndSeparator = Convert.ToInt32(dataRow4["top"]);
                            this.flag = false;
                            this.flagItem = true;
                        }
                    }
                    this.IncreasedHeight = this.EndSeparator - this.TopSeparator;
                    this.SingleItemHeight = this.IncreasedHeight;
                    if (this.PageType.ToLower() == "estimate" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "purchase")
                    {
                        if (_ds.Tables.Contains("DepartmentFields"))
                        {
                            ReplaceCustomFields(_ds.Tables["DepartmentFields"], "DepartmentCustomFields");
                        }

                        if (_ds.Tables.Contains("ContactFields"))
                        {
                            ReplaceCustomFields(_ds.Tables["ContactFields"], "ContactCustomFields");
                        }
                    }
                    if (!this.isFirstTime)
                    {
                        this.dtrPBValue = new DataTable();
                        if (this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
                        {
                            this.GetGeneralInformationFromDataBase(this.CompanyID, this.jobID, this.PageType);
                        }
                        else if (this.PageType.ToLower() != "invoice")
                        {
                            this.GetGeneralInformationFromDataBase(this.CompanyID, this.EstimateID, this.PageType);
                        }
                        else
                        {
                            this.GetGeneralInformationFromDataBase(this.CompanyID, this.InvoiceID, this.PageType);
                        }
                        if (this.PageType.ToLower() == "note")
                        {
                            this.dtrPBValue = this.objTemplates.templates_delivery_notes_Allfields_value_select(this.CompanyID, Convert.ToInt32(this.EstimateID));
                        }
                        else if (this.PageType.ToLower() == "purchase")
                        {
                            this.dtrPBValue = this.objTemplates.templates_purchase_Allfields_value_select(this.CompanyID, Convert.ToInt32(this.EstimateID));
                        }
                        else if (this.PageType.ToLower() != "invoice")
                        {
                            this.dtrPBValue = this.objTemplates.settings_template_FieldValue_select(this.CompanyID, Convert.ToInt32(this.EstimateID));
                        }
                        else
                        {
                            this.dtrPBValue = this.objTemplates.settings_template_FieldValue_select_Invoice(this.CompanyID, this.InvoiceID);
                        }
                    }

                    // 52385 first item quantity                    
                    long firstitemestitemid = 0;
                    string firstitemestimatetype = string.Empty;
                    if ((this.objValue == "[FirstItemQuantity1]") || (this.objValue == "[FirstItemQuantity2]") || (this.objValue == "[FirstItemQuantity3]") || (this.objValue == "[FirstItemQuantity4]"))
                    {
                        foreach (DataRow row in dataSet1.Tables[2].Rows)
                        {
                            int firstrow = dataSet1.Tables[2].Rows.IndexOf(row);
                            if (firstrow == 0)
                            {
                                firstitemestitemid = Convert.ToInt32(row["EstimateItemID"]);
                                firstitemestimatetype = Convert.ToString(row["EstimateType"]);
                            }

                        }

                        DataTable tblQuantity = new DataTable();
                        tblQuantity = this.objTemplates.templates_quantity_details_select_new(this.CompanyID, this.EstimateID, Convert.ToInt64(firstitemestitemid), firstitemestimatetype, this.PageType);
                        if ((this.PageType.ToLower() == "invoice") || (this.PageType.ToLower() == "job"))
                        {
                            this.firstItemQuantity1 = Convert.ToInt32(Convert.ToDecimal(tblQuantity.Rows[0]["Quantity"].ToString()));
                        }

                        if ((this.PageType.ToLower() == "estimate"))
                        {
                            for (int rowno = 0; rowno < tblQuantity.Rows.Count; rowno++)
                            {
                                if (tblQuantity.Rows.Count == 4)
                                {
                                    switch (rowno)
                                    {
                                        case 0:
                                            this.firstItemQuantity1 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 1:
                                            this.firstItemQuantity2 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 2:
                                            this.firstItemQuantity3 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 3:
                                            this.firstItemQuantity4 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;
                                    }
                                }
                                if (tblQuantity.Rows.Count == 8)
                                {
                                    switch (rowno)
                                    {
                                        case 0:
                                            this.firstItemQuantity1 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 2:
                                            this.firstItemQuantity2 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 4:
                                            this.firstItemQuantity3 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;

                                        case 6:
                                            this.firstItemQuantity4 = Convert.ToInt32(tblQuantity.Rows[rowno]["Quantity"]);
                                            break;
                                    }
                                }

                            }
                        }

                    }
                    // end first item qty

                    if (this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
                    {
                        this.objValue = this.Return_Top_TotalPrice_Details(this.objValue, this.CompanyID, this.jobID, this.PageType, this.TemplateID);
                        this.objValue = this.Return_Top_TotalPrice_Details_AllItem(this.objValue, this.CompanyID, this.jobID, this.PageType, this.TemplateID);
                    }
                    else if (this.PageType.ToLower() != "invoice")
                    {
                        this.objValue = this.Return_Top_TotalPrice_Details(this.objValue, this.CompanyID, this.EstimateID, this.PageType, this.TemplateID);
                        this.objValue = this.Return_Top_TotalPrice_Details_AllItem(this.objValue, this.CompanyID, this.EstimateID, this.PageType, this.TemplateID);
                    }
                    else
                    {
                        this.objValue = this.Return_Top_TotalPrice_Details(this.objValue, this.CompanyID, this.InvoiceID, this.PageType, this.TemplateID);
                        this.objValue = this.Return_Top_TotalPrice_Details_AllItem(this.objValue, this.CompanyID, this.InvoiceID, this.PageType, this.TemplateID);
                    }
                    this.objValue = this.GetGeneralInformationFromPage(this.objValue);
                    foreach (DataRow row5 in this.dtrPBValue.Rows)
                    {
                        if (this.PageType.ToLower() == "estimate")
                        {
                            this.EstCreatedDate = row5["EstCreatedDate"].ToString();
                            this.EstimateInvoiceAddressID = Convert.ToInt32(row5["EstimateInvoiceAddressID"]);
                            this.EstimateInvoiceAddress = row5["EstimateInvoiceAddress"].ToString();
                        }
                        if (this.PageType.ToLower() == "purchase")
                        {
                            this.EstimateTitle = row5["EstimateTitle"].ToString();
                            this.CustomerID = Convert.ToInt32(row5["CustomerID"].ToString());
                            this.SupplierID = Convert.ToInt32(row5["SupplierID"].ToString());
                            this.SupplierContactID = Convert.ToInt32(row5["ContactID"].ToString());
                            this.objValue = this.objValue.Replace("[PurchaseNumber]", row5["PONo"].ToString());
                            this.AddressID = Convert.ToInt32(row5["AddressID"].ToString());
                            this.AddressType = row5["AddressType"].ToString();
                            this.EstAddress = row5["Address"].ToString();
                            this.ContactID = Convert.ToInt32(row5["ContactID"].ToString());
                            this.DeliveryAddressID = Convert.ToInt32(row5["DeliveryAddressID"].ToString());
                            this.DeliveryAddressType = row5["DeliveryAddressType"].ToString();
                            this.DeliveryAddress = row5["DeliveryAddress"].ToString();
                            this.CarrierID = Convert.ToInt32(row5["CarrierID"]);
                            this.ProductPurchaseCode = Convert.ToString(row5["ProductPurchaseCode"]);
                            this.ProductSalesCode = Convert.ToString(row5["ProductSalesCode"]);

                            this.TotalPricePer1000 = this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(row5["TotalPricePer1000(exTax)_AllItem"].ToString()), 0, "", false, false, true);
                            this.objValue = this.objValue.Replace("[TotalPricePer1000(exTax)_AllItem]", this.TotalPricePer1000);

                        }
                        else
                        {
                            this.CustomerID = Convert.ToInt32(row5["CustomerID"]);
                            this.ContactID = Convert.ToInt32(row5["AttentionID"]);
                           
                            if (this.PageType.ToLower() != "note")
                            {
                                this.AddressID = Convert.ToInt32(row5["AddressID"]);
                                this.AddressType = row5["AddressType"].ToString();
                                this.EstAddress = row5["Address"].ToString();
                                this.DeliveryAddressID = Convert.ToInt32(row5["DeliveryAddressID"]);
                                this.DeliveryAddressType = row5["DeliveryAddressType"].ToString();
                                this.EstimateInvoiceAddressID = Convert.ToInt32(row5["EstimateInvoiceAddressID"]);
                                this.EstimateInvoiceAddress = row5["EstimateInvoiceAddress"].ToString();
                                this.CustomerInvoiceAddressType = row5["CustomerInvoiceAddressType"].ToString();
                                this.CustomerInvoiceAddressID = Convert.ToInt32(row5["CustomerInvoiceAddressID"]);
                                this.CustomerInvoiceAddress = row5["CustomerInvoiceAddress"].ToString();
                                this.CustomerInvoiceAddressClientID = Convert.ToInt32(row5["CustomerInvoiceAddressClientID"]);
                                if (this.PageType.ToLower() == "invoice")
                                {
                                    this.JobContact = row5["Jobcontact"].ToString();
                                    this.JobcntAddress = row5["Jobcontactaddress"].ToString();
                                    this.ProductSalesCode = row5["ProductSalesCode"].ToString();
                                    this.ProductPurchaseCode = row5["ProductPurchaseCode"].ToString();
                                }
                            }
                        }
                        if (this.PageType.ToLower() != "note")
                        {
                            continue;
                        }
                        this.CustomerID = Convert.ToInt32(row5["CustomerID"]);
                        this.DeliveryAddressID = Convert.ToInt32(row5["DeliveryAddressID"].ToString());
                        this.DeliveryAddressType = row5["DeliveryAddressType"].ToString();
                        this.DeliveryAddress = string.Concat(row5["AdditonalDeliveryAddress"].ToString(), '±', row5["DeliveryCompanyName"].ToString());
                        this.CustomerName = row5["Customer"].ToString();
                        this.CarrierID = Convert.ToInt32(row5["CarrierID"]);

                        // delivery invoice address
                        if (this.PageType.ToLower() == "note")
                        {
                            this.DeliveryInvoiceAddressLabel = row5["InvoiceAddressLabel"].ToString();
                            this.DeliveryInvoiceAddress1 = row5["InvoiceAddress1"].ToString();
                            this.DeliveryInvoiceAddress2 = row5["InvoiceAddress2"].ToString();
                            this.DeliveryInvoiceAddress3 = row5["InvoiceAddress3"].ToString();
                            this.DeliveryInvoiceAddress4 = row5["InvoiceAddress4"].ToString();
                            this.DeliveryInvoiceAddress5 = row5["InvoiceAddress5"].ToString();
                            this.DeliveryInvoiceAddressCountry = row5["InvoiceAddressCountry"].ToString();
                            this.DeliveryInvoiceAddressTelephone = row5["InvoiceAddressTelephone"].ToString();
                            this.DeliveryInvoiceAddressFax = row5["InvoiceAddressFax"].ToString();
                        }
                    }
                    /////////////////////////////
                    //if(this.objValue == "[EmailedCustomerPickupDate]")
                    //{
                    //    DataTable _dt=this.objTemplates.get_latest_customer_email(this.jobID);
                    //    string createdDate = "";
                    //    foreach(DataRow dr in _dt.Rows)
                    //    {
                    //        this.objValue = this.objValue.Replace("[EmailedCustomerPickupDate]", this.objJava.Eprint_return_Date_Before_View(dr["CreateDate"].ToString(), this.CompanyID, this.UserID, false));
                    //    }
                    //    if(_dt.Rows.Count == 0)
                    //    {
                    //        this.objValue = this.objValue.Replace("[EmailedCustomerPickupDate]", "");
                    //    }
                    //}
                    /////////////////////////////
                    if (this.objValue.IndexOf('[') > -1 && (this.PageType.ToLower() == "estimate" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard" || this.PageType.ToLower() == "invoice" || this.PageType.ToLower() == "webstoreorder"))
                    {
                        this.objValue = this.GetInvoiceAddress(this.objValue, this.CompanyID, this.EstimateInvoiceAddressID, this.CustomerInvoiceAddressType, this.EstimateInvoiceAddress, this.CustomerInvoiceAddressClientID);

                        //ticket # 52550  
                        if (this.PageType.ToLower() == "estimate" || (this.PageType.ToLower() == "job"))
                        {
                            if (this.objValue == "[SubItemPrice1]" || this.objValue == "[SubItemTitle]")
                            {
                                this.objTagItem = this.objValue;
                                foreach (DataRow dataRow5 in dataSet1.Tables[2].Rows)
                                {
                                    var num5 = Convert.ToInt64(dataRow5["EstimateItemID"]);
                                    this.objValue = GetSubItemValues(num5);
                                }
                            }
                        }

                    }
                    if (!this.isFirstTime)
                    {
                        this.GetInvoiceContactFromDataBase(this.CompanyID, Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.InvoiceID));
                        this.GetCustomerandCompanyAddressFromDataBase(this.CompanyID, this.CustomerID);
                        this.GetSupplierAddressFromDataBase(this.CompanyID, this.SupplierID);
                        this.GetCustomerContactAddressFromDataBase(this.CompanyID, this.ContactID);
                        this.GetSupplierContactAddressFromDataBase(this.CompanyID, this.SupplierContactID);
                        this.GetEstimateJobInvoicePurchaseDeliveryAddressFromDataBase(this.CompanyID, this.AddressID, this.AddressType, this.EstAddress);
                        this.isFirstTime = true;
                    }

                    if (objValue.Contains("[TotalPriceDeliveryItemsExTax]"))
                    {
                        try
                        {
                            string itemsid = "";
                            using (SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString()))
                            {
                                string query = @"SELECT DISTINCT ItemID FROM tb_DeliveryItem WHERE DeliveryID = @DeliveryID AND IsDeleted = 0";
                                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                                {
                                    cmd.Parameters.AddWithValue("@DeliveryID", Convert.ToInt64(this.EstimateID));
                                    sqlConnection.Open();
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        List<string> itemIds = new List<string>();
                                        while (reader.Read())
                                        {
                                            itemIds.Add(reader["ItemID"].ToString());
                                        }
                                        itemsid = string.Join(",", itemIds);
                                    }
                                }
                            }

                            this.DeliveryItemTotalCostExMarkup = GetDelivryItemTotalExTax(this.CompanyID, itemsid);
                            this.objValue = this.objValue.Replace("[TotalPriceDeliveryItemsExTax]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.DeliveryItemTotalCostExMarkup.ToString()), 0, "", false, false, true), true));
                        }
                        catch (Exception ex)
                        {
                        }
                    }



                    if (this.PageType.ToLower() == "job" && !this.flag)
                    {
                        foreach (DataRow dataRow5 in dataSet1.Tables[2].Rows)
                        {
                            if (!this.estimateitemids.Contains(dataRow5["EstimateItemID"].ToString()))
                            {
                                pdfGenerate _pdfGenerate = this;
                                _pdfGenerate.estimateitemids = string.Concat(_pdfGenerate.estimateitemids, dataRow5["EstimateItemID"].ToString(), ",");
                            }
                            long num5 = Convert.ToInt64(dataRow5["EstimateItemID"]);
                            this.EstItemType = dataRow5["EstimateType"].ToString();
                            this.objValue = this.Return_JobCardDetails(this.objValue, Convert.ToInt32(num5), this.EstItemType);
                        }
                    }

                    if (objValue.Contains("[LineItems]"))
                    {
                        try
                        {
                            var itemcount = dataSet1.Tables[2].Rows.Count;
                            this.objValue = this.objValue.Replace("[LineItems]", itemcount.ToString());
                        }
                        catch (Exception ex)
                        {
                        }
                    }



                    if (this.PageType.ToLower() == "jobcard")
                    {
                        foreach (DataRow row6 in dataSet1.Tables[2].Rows)
                        {
                            if (Convert.ToInt64(row6["EstimateItemID"]) != this.EstimateItemID)
                            {
                                continue;
                            }
                            this.EstItemType = row6["EstimateType"].ToString();
                            this.objValue = this.Return_JobCardDetails(this.objValue, Convert.ToInt32(this.EstimateItemID), this.EstItemType);
                        }
                    }
                    if (this.isFromReport && (this.objType == "8" || this.objType == "9"))
                    {
                        item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "y", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                        dataTable.Rows.Add(item);
                    }
                    if (this.flag)
                    {
                        if (dataRow4["objTag"].ToString() == "[EstimateNumber]" || dataRow4["objTag"].ToString() == "[EstimateNumberWithoutPrefix]")
                        {
                            dataRow4["objValue"] = str8;
                        }
                        item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "n", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                        object[] objArray = item;
                        if (dataRow4["objTag"].ToString() == "[EstimateNumber]" || dataRow4["objTag"].ToString() == "[EstimateNumberWithoutPrefix]")
                        {
                            objArray[6] = str8;
                        }
                        if (dataRow4["objTag"].ToString() == "[JobNumber]")
                        {
                            objArray[6] = str8;
                        }
                        if (dataRow4["objTag"].ToString() == "[InvoiceNumber]")
                        {
                            objArray[6] = str8;
                        }
                        if (dataRow4["objTag"].ToString() == "[OrderNumber]")
                        {
                            objArray[6] = str8;
                        }
                        if (dataRow4["objTag"].ToString() == "[DeliveryNumber]")
                        {
                            objArray[6] = str8;
                        }
                        dataTable1.Rows.Add(objArray);
                    }
                    else if (this.flagsubItem)
                    {
                        if (this.objType == "15" || this.objType == "16")
                        {
                            item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "y", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                            dataTable1.Rows.Add(item);
                        }
                        else
                        {
                            item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "n", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                            dataTable2.Rows.Add(item);
                        }
                    }
                    else if (!this.flagItem)
                    {
                        if (this.flag || this.flagItem)
                        {
                            continue;
                        }
                        decimal num6 = this.strFinalTotalPrice1ExTax + this.strFinalTotalTaxValue1;
                        decimal num7 = this.strFinalTotalPrice2ExTax + this.strFinalTotalTaxValue2;
                        decimal num8 = this.strFinalTotalPrice3ExTax + this.strFinalTotalTaxValue3;
                        decimal num9 = this.strFinalTotalPrice4ExTax + this.strFinalTotalTaxValue4;
                        if (this.FinalTotalQuantity1 > new decimal(0))
                        {
                            this.objValue = this.objValue.Replace("[TotalPrice1(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice1ExTax), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalTax1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue1), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalQuantity1]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity1), 0, "", true, false, true));
                            this.objValue = this.objValue.Replace("[TotalProfitMarginPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice1), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalPrice1(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num6), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalCostPrice1(exMarkup)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalCostPrice1ExMarkup), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalMarkupPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalMarkupPrice1), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalGrossProfitPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalGrossProfitPrice1), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalGrossProfitPercentage1]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalGrossProfitPercentage1), 0, "", false, false, true), " %"));
                        }
                        if (this.FinalTotalQuantity2 > new decimal(0))
                        {
                            this.objValue = this.objValue.Replace("[TotalPrice2(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice2ExTax), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalTax2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue2), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalQuantity2]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity2), 0, "", true, false, true));
                            this.objValue = this.objValue.Replace("[TotalProfitMarginPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice2), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalPrice2(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num7), 0, "", false, false, true), true));
                        }
                        if (this.FinalTotalQuantity3 > new decimal(0))
                        {
                            this.objValue = this.objValue.Replace("[TotalPrice3(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice3ExTax), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalTax3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue3), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalQuantity3]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity3), 0, "", true, false, true));
                            this.objValue = this.objValue.Replace("[TotalProfitMarginPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice3), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalPrice3(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num8), 0, "", false, false, true), true));
                        }
                        if (this.FinalTotalQuantity4 > new decimal(0))
                        {
                            this.objValue = this.objValue.Replace("[TotalPrice4(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalPrice4ExTax), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalTax4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalTaxValue4), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalQuantity4]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalQuantity4), 0, "", true, false, true));
                            this.objValue = this.objValue.Replace("[TotalProfitMarginPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.strFinalTotalProfitMarginPrice4), 0, "", false, false, true), true));
                            this.objValue = this.objValue.Replace("[TotalPrice4(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num9), 0, "", false, false, true), true));
                        }
                        this.htQtyNum.Clear();
                        this.htQtyNum.Add("1", "1");
                        this.htQtyNum.Add("2", "2");
                        this.htQtyNum.Add("3", "3");
                        this.htQtyNum.Add("4", "4");
                        if (this.objValue.IndexOf('[') > -1)
                        {
                            foreach (string value2 in this.htQtyNum.Values)
                            {
                                if (!this.objValue.Contains(string.Concat("[Quantity", value2, "]")) && !this.objValue.Contains(string.Concat("[Tax", value2, "]")) && !this.objValue.Contains(string.Concat("[Price", value2, "(inTax)]")) && !this.objValue.Contains(string.Concat("[Price", value2, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value2, "(inTax)]")) && !this.objValue.Contains(string.Concat("[TotalTax", value2, "]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value2, "(exTax)]")) && !this.objValue.Contains(string.Concat("[TotalPrice", value2, "(ex Tax)]")) && !this.objValue.Contains(string.Concat("[TotalProfitMarginPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[TotalQuantity", value2, "]")) && !this.objValue.Contains(string.Concat("[ProfitMarginPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[CostPrice", value2, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[MarkupPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[GrossProfitPercentage", value2, "]")) && !this.objValue.Contains(string.Concat("[SubTotal", value2, "]")) && !this.objValue.Contains(string.Concat("[TotalCostPrice", value2, "(exMarkup)]")) && !this.objValue.Contains(string.Concat("[TotalMarkupPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPrice", value2, "]")) && !this.objValue.Contains(string.Concat("[TotalGrossProfitPercentage", value2, "]")) && !this.objValue.Contains(string.Concat("[SupplierQuote#", value2, "]")) && !this.objValueItem.Contains(string.Concat("[PricePerUnitofMeasureQty", value2, "]")) && !this.objValueItem.Contains(string.Concat("[PricePerUnit", value2, "]")) && !this.objValueItem.Contains("[ProductImage]") && !this.objValue.Contains("[ProductImage]") && !this.objValueItem.Contains("[JobName]") && !this.objValue.Contains("[JobName]") && !this.objValue.Contains("[LargeFormat_DPI]") && !this.objValue.Contains("[LargeFormat_PressSpeed]") && !this.objValue.Contains("[ProductAdditionalOptionsValue]") && !this.objValue.Contains("[QuantityDescription1]") && !this.objValue.Contains("[ProductItemCode]") && !this.objValueItem.Contains(string.Concat("[CostPrice", value2, "(InMarkup)]")) && !this.objValue.Contains("[JobTitle]") && !this.objValue.Contains("[ItemTitle]") && !this.objValue.Contains("[LastJobUsed]") && !this.objValue.Contains("[TaxPercentage]") && !this.objValue.Contains("[StockLocation]") && !this.objValue.Contains("[StockToPick]") && !this.objValue.Contains("[StockCustomField2]") && !this.objValue.Contains("[StockCustomField3]") && !this.objValue.Contains("[StockCustomField4]") && !this.objValue.Contains("[StockCustomField5]") && !this.objValue.Contains("[StockCustomField6]") && !this.objValue.Contains("[WarehouseLocation]") && !this.objValue.Contains("[SubItemPrice1]") && !this.objValue.Contains("[SubItemPrice2]") && !this.objValue.Contains("[SubItemPrice3]") && !this.objValue.Contains("[SubItemPrice4]") && !this.objValue.Contains("[SubItemTitle]") && !this.objValueItem.Contains(string.Concat("[PricePer1000Unit", value2, "]")) && !this.objValueItem.Contains(string.Concat("[PricePer1000Unit4Decimal", value2, "]")))
                                {
                                    continue;
                                }
                                this.objValue = this.objValue.Replace(this.objValue, "");
                                break;
                            }
                        }
                        if (this.objValue.IndexOf('[') > -1)
                        {
                            this.objValue = this.GetCustomerAddressFromPage(this.objValue);
                            this.objValue = this.GetCompanyAddressFromPage(this.objValue);
                            this.objValue = this.GetSupplierAddressFromPage(this.objValue);
                            this.objValue = this.GetCustomerContactAddressFromPage(this.objValue);
                            this.objValue = this.GetSupplierContactAddressFromPage(this.objValue);
                        }
                        if (this.objValue.IndexOf('[') > -1)
                        {
                            if (this.PageType.ToLower() != "invoice")
                            {
                                this.objValue = this.GetDeliveryAddress(this.objValue, this.CompanyID, this.EstimateID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                            }
                            else
                            {
                                this.objValue = this.GetDeliveryAddress(this.objValue, this.CompanyID, this.InvoiceID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                            }
                            this.objValue = this.GetCarrierAddress(this.CompanyID, this.CarrierID, this.objValue);
                            this.objValue = this.GetEstimateJobInvoicePurchaseDeliveryAddressFromPage(this.objValue);
                        }
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringBuilder1 = new StringBuilder();
                        if (this.OrdID == (long)0)
                        {
                            this.OrdID = this.EstimateID;
                        }
                        if (this.objValue.Contains("[CartAdditionalOptionName]") || this.objValue.Contains("[CartAdditionalOptionPrice]"))
                        {
                            DataTable dataTable4 = new DataTable();
                            if (this.PageType.ToLower() != "invoice")
                            {
                                dataTable4 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, (long)0);
                            }
                            else
                            {
                                dataTable4 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.EstimateItemID);
                            }
                            foreach (DataRow dataRow6 in dataTable4.Rows)
                            {
                                stringBuilder.Append(string.Concat(dataRow6["SelectedValue"].ToString(), "\n"));
                                stringBuilder1.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow6["CartAdditionalOptionPrice"]), 0, "", false, false, true), true), "\n"));
                            }
                            if (dataTable4.Rows.Count > 0)
                            {
                                this.objValue = this.objValue.Replace("[CartAdditionalOptionName]", string.Concat("\n", stringBuilder.ToString()));
                                this.objValue = this.objValue.Replace("[CartAdditionalOptionPrice]", string.Concat("\n", stringBuilder1.ToString()));
                            }
                            else if (this.objValue.Contains("[CartAdditionalOptionName]") || this.objValue.Contains("[CartAdditionalOptionPrice]"))
                            {
                                this.objValue = this.objValue.Replace(this.objValue, "");
                            }
                        }
                        if (!this.footerFlag || this.isMUltipleItems != 1)
                        {
                            item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "n", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                            dataTable.Rows.Add(item);
                        }
                        else
                        {
                            int num10 = 0;
                            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("maspro.eprintsoftware.com") || HttpContext.Current.Request.Url.ToString().ToLower().Contains("handyenvelopes.eprintsoftware.com"))
                            {
                                num10 = Convert.ToInt32(dataRow4["top"]);
                            }
                            else
                            {
                                num10 = (this.footercount != 0 ? num10 + (Convert.ToInt32(dataRow4["top"]) - this.PreviousFooterTop) : this.LastItemTopPlusHeight - this.EndSeparator + Convert.ToInt32(dataRow4["top"]));
                                this.PreviousFooterTop = Convert.ToInt32(dataRow4["top"]);
                            }
                            //ticket 115654
                            if (dataRow4["lock"].ToString().Trim().ToLower() == "true")
                            {
                                num10 = Convert.ToInt32(dataRow4["top"]);
                            }
                            item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], num10, dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "n", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                            dataTable.Rows.Add(item);
                        }
                    }
                    else
                    {
                        if (this.objType == "8")
                        {
                            item = new object[] { dataRow4["TemplateID"], dataRow4["CompanyID"], dataRow4["objID"], dataRow4["objType"], dataRow4["objName"], dataRow4["type"], this.objValue, dataRow4["imgsrc"], dataRow4["title"], dataRow4["align"], dataRow4["position"], dataRow4["top"], dataRow4["left"], dataRow4["width"], dataRow4["height"], dataRow4["zindex"], dataRow4["padding"], dataRow4["display"], dataRow4["overflow"], dataRow4["fontfamily"], dataRow4["fontsize"], dataRow4["fontweight"], dataRow4["fontstyle"], dataRow4["fontcolor"], dataRow4["textdecoration"], dataRow4["textalign"], dataRow4["border"], dataRow4["backgroundcolor"], dataRow4["visibility"], dataRow4["maxlength"], dataRow4["offsetwidth"], dataRow4["offsetheight"], dataRow4["offsettop"], dataRow4["offsetleft"], dataRow4["pixelwidth"], dataRow4["pixelheight"], dataRow4["pixeltop"], dataRow4["lock"], dataRow4["canmove"], dataRow4["canchangefontcolor"], dataRow4["canchangefontsize"], dataRow4["canchangefont"], dataRow4["class"], dataRow4["onmouseoverclass"], dataRow4["objTag"], "y", dataRow4["GroupID"], dataRow4["HGroupID"], dataRow4["isHGroupMain"], dataRow4["AssociatedLabel"], dataRow4["isAutoExpand"], "0", dataRow4["Repeat"] };
                            dataTable1.Rows.Add(item);
                        }
                        int num11 = 0;
                        int num12 = 0;
                        this.EstItemType = string.Empty;
                        int num13 = 0;
                        int num14 = 0;
                        if (this.Session["SelectedItemForPrint"] != null)
                        {
                            this.SelectedItems = this.Session["SelectedItemForPrint"].ToString();
                        }




                        var dt = new DataTable();
                        if (this.PageType.ToLower() == "invoice")
                        {
                            dt = dataSet1.Tables["Table2"].DefaultView.ToTable(true, "EstimateItemId", "EstimateID");
                        }
                        else
                        {
                            dt = dataSet1.Tables["Table2"].DefaultView.ToTable(true, "EstimateItemId");
                        }

                        foreach (DataRow row in dt.Rows)
                        {


                            num14++;
                            this.EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
                            if (this.PageType.ToLower() == "invoice")
                            {
                                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                            }
                            DataTable results = (from myRow in dataSet1.Tables["Table2"].AsEnumerable()
                                                     //where Convert.ToInt64( myRow.Field<Int64>("EstimateItemId")) == EstimateItemID
                                                 where Convert.ToInt64(myRow["EstimateItemId"].ToString()) == EstimateItemID
                                                 select myRow).CopyToDataTable<DataRow>();

                            DataRow row7 = results.Rows[0];

                            if (this.PageType.ToLower() == "purchase" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "webstoreorder")
                            {
                                this.EstItemID = Convert.ToInt64(row7["EstItemID"]);
                            }
                            this.EstItemType = row7["EstimateType"].ToString();
                            bool flag3 = false;
                            DataTable dataTable5 = new DataTable();
                            if (flag2)
                            {
                                dataTable5 = this.objTemplates.PCR_Template_subitems_select(this.EstimateItemID, this.PageType);
                            }
                            int num15 = 0;
                            int subItemEndSeparator = this.SubItemEndSeparator - this.SubItemTopSeparator;
                            foreach (DataRow dataRow7 in dataTable1.Rows)
                            {
                                this.objTop = Convert.ToInt32(dataRow7["top"]) + this.IncreasedHeight * num11 + num13;
                                int increasedHeight = 0;
                                if (ConnectionClass.ServerName.Trim().ToLower() == "handyenvelopes" || ConnectionClass.ServerName.Trim().ToLower() == "handyexpress")
                                {
                                    increasedHeight = 837 + this.IncreasedHeight * num12;
                                }
                                this.objTypeItem = dataRow7["objType"].ToString();
                                if (this.objTypeItem == "16" && flag2)
                                {
                                    foreach (DataRow row8 in dataTable5.Rows)
                                    {
                                        DataTable dataTable6 = new DataTable();
                                        if (Convert.ToInt64(row8["EstimateItemID"]) > (long)0)
                                        {
                                            dataTable6 = this.objTemplates.PCR_Template_GetAllDetails_By_EstimateItemID(Convert.ToInt64(row8["EstimateItemID"]), row8["EstimateType"].ToString(), this.EstimateItemID);
                                            if (dataTable6.Rows.Count > 0)
                                            {
                                                if (num15 > 0)
                                                {
                                                    num13 = num13 + subItemEndSeparator;
                                                }
                                                foreach (DataRow dataRow8 in dataTable2.Rows)
                                                {
                                                    this.objValueItem = dataRow8["objValue"].ToString();
                                                    this.objTagItem = dataRow8["objTag"].ToString();
                                                    if (!(this.objTagItem.Trim().ToLower() == "[subitemtitle]") && !(this.objTagItem.Trim().ToLower() == "[subitemprice1]") && !(this.objTagItem.Trim().ToLower() == "[subitemprice2]") && !(this.objTagItem.Trim().ToLower() == "[subitemprice3]") && !(this.objTagItem.Trim().ToLower() == "[subitemprice4]"))
                                                    {
                                                        continue;
                                                    }
                                                    this.objTop = Convert.ToInt32(dataRow8["top"]) + this.IncreasedHeight * num11 + num13;
                                                    this.objValueItem = this.objValueItem.Replace("[SubItemTitle]", dataTable6.Rows[0]["ItemTitle"].ToString());
                                                    if (this.objTagItem.Trim().ToLower() == "[subitemprice1]")
                                                    {
                                                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty1"]) <= (long)0)
                                                        {
                                                            this.objValueItem = "";
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[SubItemPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal1"]), 0, "", false, false, true), true));
                                                        }
                                                    }
                                                    if (this.objTagItem.Trim().ToLower() == "[subitemprice2]")
                                                    {
                                                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty2"]) <= (long)0)
                                                        {
                                                            this.objValueItem = "";
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[SubItemPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal2"]), 0, "", false, false, true), true));
                                                        }
                                                    }
                                                    if (this.objTagItem.Trim().ToLower() == "[subitemprice3]")
                                                    {
                                                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty3"]) <= (long)0)
                                                        {
                                                            this.objValueItem = "";
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[SubItemPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal3"]), 0, "", false, false, true), true));
                                                        }
                                                    }
                                                    if (this.objTagItem.Trim().ToLower() == "[subitemprice4]")
                                                    {
                                                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty4"]) <= (long)0)
                                                        {
                                                            this.objValueItem = "";
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[SubItemPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal4"]), 0, "", false, false, true), true));
                                                        }
                                                    }
                                                    item = new object[] { dataRow8["TemplateID"], dataRow8["CompanyID"], dataRow8["objID"], dataRow8["objType"], dataRow8["objName"], dataRow8["type"], this.objValueItem, dataRow8["imgsrc"], dataRow8["title"], dataRow8["align"], dataRow8["position"], this.objTop, dataRow8["left"], dataRow8["width"], dataRow8["height"], dataRow8["zindex"], dataRow8["padding"], dataRow8["display"], dataRow8["overflow"], dataRow8["fontfamily"], dataRow8["fontsize"], dataRow8["fontweight"], dataRow8["fontstyle"], dataRow8["fontcolor"], dataRow8["textdecoration"], dataRow8["textalign"], dataRow8["border"], dataRow8["backgroundcolor"], dataRow8["visibility"], dataRow8["maxlength"], dataRow8["offsetwidth"], dataRow8["offsetheight"], dataRow8["offsettop"], dataRow8["offsetleft"], dataRow8["pixelwidth"], dataRow8["pixelheight"], dataRow8["pixeltop"], dataRow8["lock"], dataRow8["canmove"], dataRow8["canchangefontcolor"], dataRow8["canchangefontsize"], dataRow8["canchangefont"], dataRow8["class"], dataRow8["onmouseoverclass"], dataRow8["objTag"], "y", dataRow8["GroupID"], dataRow8["HGroupID"], dataRow8["isHGroupMain"], dataRow8["AssociatedLabel"], dataRow8["isAutoExpand"], num14.ToString(), dataRow4["Repeat"] };
                                                    dataTable.Rows.Add(item);
                                                }
                                            }
                                        }
                                        num15++;
                                    }
                                }
                                this.objTypeItem = dataRow7["objType"].ToString();
                                this.objValueItem = dataRow7["objValue"].ToString();
                                this.objTagItem = dataRow7["objTag"].ToString();
                                if (this.PageType.ToLower() != "purchase" && this.PageType.ToLower() != "note" && this.PageType.ToLower() != "webstoreorder" && (this.objTagItem.Trim().ToLower() == "[mainitemprice1]" || this.objTagItem.Trim().ToLower() == "[mainitemprice2]" || this.objTagItem.Trim().ToLower() == "[mainitemprice3]" || this.objTagItem.Trim().ToLower() == "[mainitemprice4]"))
                                {
                                    DataTable dataTable7 = new DataTable();
                                    if (this.EstimateItemID > (long)0)
                                    {
                                        dataTable7 = this.objTemplates.PCR_Template_GetAllDetails_By_EstimateItemID(Convert.ToInt64(this.EstimateItemID), row7["EstimateType"].ToString(), this.EstimateItemID);
                                        if (dataTable7.Rows.Count > 0)
                                        {
                                            if (this.objTagItem.Trim().ToLower() == "[mainitemprice1]")
                                            {
                                                if (Convert.ToInt64(dataTable7.Rows[0]["TotalQty1"]) <= (long)0)
                                                {
                                                    this.objValueItem = "";
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[MainItemPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[0]["TotalSubTotal1"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (this.objTagItem.Trim().ToLower() == "[mainitemprice2]")
                                            {
                                                if (Convert.ToInt64(dataTable7.Rows[0]["TotalQty2"]) <= (long)0)
                                                {
                                                    this.objValueItem = "";
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[MainItemPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[0]["TotalSubTotal2"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (this.objTagItem.Trim().ToLower() == "[mainitemprice3]")
                                            {
                                                if (Convert.ToInt64(dataTable7.Rows[0]["TotalQty3"]) <= (long)0)
                                                {
                                                    this.objValueItem = "";
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[MainItemPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[0]["TotalSubTotal3"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (this.objTagItem.Trim().ToLower() == "[mainitemprice4]")
                                            {
                                                if (Convert.ToInt64(dataTable7.Rows[0]["TotalQty4"]) <= (long)0)
                                                {
                                                    this.objValueItem = "";
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[MainItemPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[0]["TotalSubTotal4"]), 0, "", false, false, true), true));
                                                }
                                            }
                                        }
                                        else if (this.objValueItem.Contains("[MainItemPrice1]") || this.objValueItem.Contains("[MainItemPrice2]") || this.objValueItem.Contains("[MainItemPrice3]") || this.objValueItem.Contains("[MainItemPrice4]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                    }
                                }
                                this.htQtyNum.Clear();
                                this.htQtyNum.Add("1", "1");
                                this.htQtyNum.Add("2", "2");
                                this.htQtyNum.Add("3", "3");
                                this.htQtyNum.Add("4", "4");
                                this.htItemDesc.Clear();
                                this.htItemDesc.Add("ItemTitle", "ItemTitle");
                                this.htItemDesc.Add("Description", "Description");
                                this.htItemDesc.Add("Artwork", "Artwork");
                                this.htItemDesc.Add("Colour", "Colour");
                                this.htItemDesc.Add("Size", "Size");
                                this.htItemDesc.Add("Material", "Material");
                                this.htItemDesc.Add("Delivery", "Delivery");
                                this.htItemDesc.Add("Finishing", "Finishing");
                                this.htItemDesc.Add("Proofs", "Proofs");
                                this.htItemDesc.Add("Packing", "Packing");
                                this.htItemDesc.Add("Notes", "Notes");
                                this.htItemDesc.Add("Instructions", "Instructions");
                                if (this.objValueItem.IndexOf('[') > -1 && (this.objValueItem.Contains("[ProductAdditionalOptionsValue]") || this.objValueItem.Contains("[eStoreAdditionalOptionName]") || this.objValueItem.Contains("[eStoreAdditionalOptionPrice]") || this.objValueItem.Contains("[CartAdditionalOptionName]") || this.objValueItem.Contains("[CartAdditionalOptionPrice]") || this.objValueItem.Contains("[ProductAdditionalOptionsName]") || this.objValueItem.Contains("[AllProductAdditionalOptionNames]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice1]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice2]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice3]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice4]")))
                                {
                                    if (this.PageType.ToLower() == "webstoreorder" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard" || this.PageType.ToLower() == "invoice" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "purchase")
                                    {
                                        long num16 = (long)0;
                                        num16 = (this.PageType.ToLower() == "purchase" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "webstoreorder" ? this.EstItemID : this.EstimateItemID);
                                        DataSet dataSet3 = OrderBasePage.Select_OrderItems_WithAdditionalItems(num16);
                                        DataTable item2 = dataSet3.Tables[1];
                                        DataTable item3 = dataSet3.Tables[3];
                                        StringBuilder stringBuilder2 = new StringBuilder();
                                        StringBuilder stringBuilder3 = new StringBuilder();
                                        StringBuilder stringBuilder4 = new StringBuilder();
                                        StringBuilder stringBuilder5 = new StringBuilder();
                                        StringBuilder stringBuilder6 = new StringBuilder();
                                        foreach (DataRow row9 in item2.Rows)
                                        {
                                            stringBuilder4.Append(string.Concat(row9["eStoreAdditionalOptionSelectedValue"].ToString(), "\n"));
                                            stringBuilder2.Append(string.Concat(row9["webothercostName"].ToString(), ": ", row9["eStoreAdditionalOptionSelectedValue"].ToString(), "\n"));
                                            stringBuilder3.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row9["TotalPrice"]), 0, "", false, false, true), true), "\n"));
                                        }
                                        foreach (DataRow dataRow9 in item3.Rows)
                                        {
                                            stringBuilder4.Append(string.Concat(dataRow9["ProductAdditionalOptionSelectedValue"].ToString(), "\n"));
                                            stringBuilder2.Append(string.Concat(dataRow9["ProductAdditionalOptionName"].ToString(), ": ", dataRow9["ProductAdditionalOptionSelectedValue"].ToString(), "\n"));
                                            stringBuilder3.Append("");
                                        }
                                        if (item2.Rows.Count > 0)
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsValue]", stringBuilder4.ToString());
                                            this.objValueItem = this.objValueItem.Replace("[eStoreAdditionalOptionName]", string.Concat("\n", stringBuilder2.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[eStoreAdditionalOptionPrice]", string.Concat("\n", stringBuilder3.ToString()));
                                        }
                                        else if (this.objValueItem.Contains("[eStoreAdditionalOptionName]") || this.objValueItem.Contains("[eStoreAdditionalOptionPrice]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                        if (item3.Rows.Count > 0)
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsValue]", string.Concat(stringBuilder4.ToString(), "\n"));
                                        }
                                        else if (this.objValueItem.Contains("[ProductAdditionalOptionsValue]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                        if (this.EstItemType.ToLower() != "u")
                                        {
                                            StringBuilder stringBuilder7 = new StringBuilder();
                                            StringBuilder stringBuilder8 = new StringBuilder();
                                            if (this.temp_ordid == (long)0)
                                            {
                                                this.temp_ordid = this.EstimateID;
                                            }
                                            DataTable dataTable8 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.EstimateItemID);
                                            foreach (DataRow row10 in dataTable8.Rows)
                                            {
                                                stringBuilder7.Append(string.Concat(row10["SelectedValue"].ToString(), "\n"));
                                                stringBuilder8.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row10["CartAdditionalOptionPrice"]), 0, "", false, false, true), true), "\n"));
                                            }
                                            if (dataTable8.Rows.Count > 0)
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[CartAdditionalOptionName]", string.Concat("\n", stringBuilder7.ToString()));
                                                this.objValueItem = this.objValueItem.Replace("[CartAdditionalOptionPrice]", string.Concat("\n", stringBuilder8.ToString()));
                                            }
                                            else if (this.objValueItem.Contains("[CartAdditionalOptionName]") || this.objValueItem.Contains("[CartAdditionalOptionPrice]"))
                                            {
                                                this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                            }
                                        }
                                        else if (this.objValueItem.Contains("[CartAdditionalOptionName]") || this.objValueItem.Contains("[CartAdditionalOptionPrice]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                    }
                                    if (this.PageType.ToLower() == "estimate")
                                    {
                                        StringBuilder stringBuilder9 = new StringBuilder();
                                        StringBuilder stringBuilder10 = new StringBuilder();
                                        StringBuilder stringBuilder11 = new StringBuilder();
                                        StringBuilder stringBuilder12 = new StringBuilder();
                                        StringBuilder stringBuilder13 = new StringBuilder();
                                        StringBuilder stringBuilder14 = new StringBuilder();
                                        StringBuilder alladditionaloptionnames = new StringBuilder();

                                        DataTable dataTable9 = EstimateBasePage.ProductAdditional_Price_Select(this.EstimateID, this.EstimateItemID, this.PageType);
                                        foreach (DataRow dataRow10 in dataTable9.Rows)
                                        {
                                            stringBuilder9.Append(string.Concat(dataRow10["ProductAdditionalOptionSelectedValue"].ToString(), "\n"));
                                            stringBuilder10.Append(string.Concat(dataRow10["ProductAdditionalOptionName"].ToString(), "\n"));
                                            alladditionaloptionnames.Append(string.Concat(dataRow10["AllProductAdditionalOptionNames"].ToString()));
                                            stringBuilder11.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow10["ProductAdditionalOptionsPrice1"]), 0, "", false, false, true), true), "\n"));
                                            stringBuilder12.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow10["ProductAdditionalOptionsPrice2"]), 0, "", false, false, true), true), "\n"));
                                            stringBuilder13.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow10["ProductAdditionalOptionsPrice3"]), 0, "", false, false, true), true), "\n"));
                                            stringBuilder14.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow10["ProductAdditionalOptionsPrice4"]), 0, "", false, false, true), true), "\n"));
                                        }
                                        if (dataTable9.Rows.Count > 0)
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsValue]", string.Concat(stringBuilder9.ToString(), "\n"));
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsName]", string.Concat("\n", stringBuilder10.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[AllProductAdditionalOptionNames]", string.Concat("\n", alladditionaloptionnames.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice1]", string.Concat("\n", stringBuilder11.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice2]", string.Concat("\n", stringBuilder12.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice3]", string.Concat("\n", stringBuilder13.ToString()));
                                            this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice4]", string.Concat("\n", stringBuilder14.ToString()));
                                        }
                                        else if (this.objValueItem.Contains("[ProductAdditionalOptionsName]") || this.objValueItem.Contains("[AllProductAdditionalOptionNames]") || this.objValueItem.Contains("[ProductAdditionalOptionsValue]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice1]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice2]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice3]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice4]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                    }
                                    else if (this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice")
                                    {
                                        long estimateItemID = this.EstimateItemID;
                                        if (this.EstItemType.ToLower() != "x")
                                        {
                                            StringBuilder stringBuilder15 = new StringBuilder();
                                            StringBuilder stringBuilder16 = new StringBuilder();
                                            StringBuilder stringBuilder17 = new StringBuilder();
                                            StringBuilder alladditionaloptionnames = new StringBuilder();

                                            if (this.EstimateID <= 0)
                                            {
                                                this.EstimateID = approveForDepartment(this.EstimateItemID);
                                            }

                                            DataTable dataTable10 = EstimateBasePage.ProductAdditional_Price_Select(this.EstimateID, this.EstimateItemID, this.PageType);
                                            foreach (DataRow row11 in dataTable10.Rows)
                                            {
                                                stringBuilder15.Append(string.Concat(row11["ProductAdditionalOptionSelectedValue"].ToString(), "\n"));
                                                stringBuilder16.Append(string.Concat(row11["ProductAdditionalOptionName"].ToString(), "\n"));
                                                alladditionaloptionnames.Append(string.Concat(row11["AllProductAdditionalOptionNames"].ToString(), "\n"));
                                                stringBuilder17.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row11["ProductAdditionalOptionsPrice"]), 0, "", false, false, true), true), "\n"));
                                            }
                                            if (dataTable10.Rows.Count > 0)
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsValue]", string.Concat(stringBuilder15.ToString(), "\n"));
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsName]", string.Concat("\n", stringBuilder16.ToString()));
                                                this.objValueItem = this.objValueItem.Replace("[AllProductAdditionalOptionNames]", string.Concat("\n", alladditionaloptionnames.ToString()));
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice1]", string.Concat("\n", stringBuilder17.ToString()));
                                            }
                                            else if (this.objValueItem.Contains("[ProductAdditionalOptionsName]") || this.objValueItem.Contains("[AllProductAdditionalOptionNames]") || this.objValueItem.Contains("[ProductAdditionalOptionsValue]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice1]"))
                                            {
                                                this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                            }
                                        }
                                        else
                                        {
                                            StringBuilder stringBuilder18 = new StringBuilder();
                                            StringBuilder stringBuilder19 = new StringBuilder();
                                            StringBuilder stringBuilder20 = new StringBuilder();
                                            DataTable item4 = OrderBasePage.Select_OrderItems_WithAdditionalItems(estimateItemID).Tables[1];
                                            foreach (DataRow dataRow11 in item4.Rows)
                                            {
                                                stringBuilder18.Append(string.Concat(dataRow11["eStoreAdditionalOptionSelectedValue"].ToString(), "\n"));
                                                stringBuilder19.Append(string.Concat(dataRow11["webothercostName"].ToString(), "\n"));
                                                stringBuilder20.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow11["totalPrice"]), 0, "", false, false, true), true), "\n"));
                                            }
                                            if (item4.Rows.Count > 0)
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsValue]", string.Concat(stringBuilder18.ToString(), "\n"));
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsName]", string.Concat("\n", stringBuilder19.ToString()));
                                                this.objValueItem = this.objValueItem.Replace("[ProductAdditionalOptionsPrice1]", string.Concat("\n", stringBuilder20.ToString()));
                                            }
                                            else if (this.objValueItem.Contains("[ProductAdditionalOptionsValue]") || this.objValueItem.Contains("[ProductAdditionalOptionsName]") || this.objValueItem.Contains("[ProductAdditionalOptionsPrice1]"))
                                            {
                                                this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                            }
                                        }
                                    }
                                }
                                if (this.PageType.ToLower() == "job")
                                {
                                    this.objValueItem = this.Return_JobCardDetails(this.objValueItem, Convert.ToInt32(this.EstimateItemID), this.EstItemType);
                                }
                                int num17 = 1;
                                if (this.oldEstimateItemID != this.EstimateItemID)
                                {
                                    if (!this.isGroupingBasedOnStockLocation) {
                                        this.dtQty = this.objTemplates.templates_quantity_details_select_new(this.CompanyID, this.EstimateID, this.EstimateItemID, this.EstItemType, this.PageType);
                                    }
                                    else {
                                        this.dtQty = this.objTemplates.templates_quantity_details_select_LocationGrouping(this.CompanyID, this.EstimateID, this.EstimateItemID, this.EstItemType, this.PageType);
                                    }
                                }
                                this.oldEstimateItemID = this.EstimateItemID;
                                //first item tax rate
                                int index = dataSet1.Tables[2].Rows.IndexOf(row7);
                                if (index == 0)
                                {
                                    if ((this.dtQty.Rows.Count > 0) && ((this.PageType.ToLower() == "estimate")))
                                    {
                                        for (int rowno = 0; rowno < this.dtQty.Rows.Count; rowno++)
                                        {
                                            switch (rowno)
                                            {
                                                case 0:
                                                    this.firstItemQuantity1 = Convert.ToInt32(this.dtQty.Rows[rowno]["Quantity"]);
                                                    break;

                                                case 1:
                                                    this.firstItemQuantity2 = Convert.ToInt32(this.dtQty.Rows[rowno]["Quantity"]);
                                                    break;

                                                case 2:
                                                    this.firstItemQuantity3 = Convert.ToInt32(this.dtQty.Rows[rowno]["Quantity"]);
                                                    break;

                                                case 3:
                                                    this.firstItemQuantity4 = Convert.ToInt32(this.dtQty.Rows[rowno]["Quantity"]);
                                                    break;
                                            }

                                        }
                                    }
                                    if ((this.dtQty.Rows.Count > 0) && ((this.PageType.ToLower() == "invoice") || (this.PageType.ToLower() == "job")))
                                    {
                                        // this.dtQty.Rows[0]["TaxValue"]
                                        //this.firstItemTaxrate = this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.dtQty.Rows[0]["TaxValue"]), 0, "", false, false, true), true);
                                        //Safdar Aheer
                                        //this.firstItemQuantity1 = Convert.ToInt32(this.dtQty.Rows[0]["Quantity"]);
                                        this.firstItemQuantity1 = Convert.ToInt32(Convert.ToDecimal(this.dtQty.Rows[0]["Quantity"].ToString()));

                                        DataColumnCollection columns = this.dtQty.Columns;
                                        if (columns.Contains("TaxName"))
                                        {
                                            //this.firstItemTaxrate = Convert.ToString(this.dtQty.Rows[0]["TaxName"]);  
                                            //this.firstItemTaxrate = Convert.ToString(this.dtQty.Rows[0]["Tax"]);  
                                            this.firstItemTaxrate = Convert.ToString(string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.dtQty.Rows[0]["Tax"]), 0, "", false, false, true), "%"));
                                        }

                                    }
                                }
                                foreach (DataRow row12 in this.dtQty.Rows)
                                {
                                    if (this.PageType.ToLower() == "note")
                                    {
                                        //this.objValueItem = this.objValueItem.Replace("[Quantity1]", row12["Quantity"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[Quantity1]", row12["Quantity1"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[QuantityDelivered]", row12["Quantity"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[DeliveryNoteDescription]", row12["Description"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[JobName]", row12["JobName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[Tax1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["TaxValue"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[Price1(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["SubTotal"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[Price1(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PriceInTax"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[ItemTitle]", row12["ItemTitle"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[ItemPacking]", row12["PackingValue"].ToString());

                                        this.objValueItem = this.objValueItem.Replace("[UnitCBM]", Convert.ToDecimal(row12["UnitCBM"]).ToString("0.###"));

                                        this.objValueItem = this.objValueItem.Replace("[LineCBM]", Convert.ToDecimal(row12["LineCBM"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[UnitWeight]", Convert.ToDecimal(row12["UnitWeight"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[LineWeight]", Convert.ToDecimal(row12["LineWeight"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductLength]", Convert.ToDecimal(row12["ProductLength"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductWidth]", Convert.ToDecimal(row12["ProductWidth"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductHeight]", Convert.ToDecimal(row12["ProductHeight"]).ToString("0.###"));
                                        try
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[ProductItemCode]", row12["ProductItemCode"].ToString());
                                            this.objValueItem = this.objValueItem.Replace("[SoldInPacksOf]", row12["SoldInPacksOf"].ToString());
                                            if ((this.objValueItem.Contains("[DeliveryItemNotes]")) && (Convert.ToString(row12["Notes"]) != "Enter line detail here"))
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[DeliveryItemNotes]", row12["Notes"].ToString());
                                            }
                                            else
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[DeliveryItemNotes]", "");
                                            }
                                            this.objValueItem = this.objValueItem.Replace("[ProductCustomerCode]", row12["ProductCustomerCode"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            if (this.EstItemType.ToLower() == "c" || this.EstItemType.ToLower() == "x")
                                            {
                                                StringBuilder stringBuilder21 = new StringBuilder();
                                                StringBuilder stringBuilder22 = new StringBuilder();
                                                string str9 = row12["Stock Location"].ToString();
                                                chrArray = new char[] { ',' };
                                                string[] strArrays2 = str9.Split(chrArray);
                                                string empty2 = string.Empty;
                                                string empty3 = string.Empty;
                                                string empty4 = string.Empty;
                                                string empty5 = string.Empty;
                                                string empty6 = string.Empty;
                                                string empty7 = string.Empty;
                                                string empty8 = string.Empty;
                                                string empty9 = string.Empty;
                                                string empty10 = string.Empty;
                                                string empty11 = string.Empty;
                                                DataTable dataTable11 = SettingsBasePage.productcatalogue_warehousestock_select(this.CompanyID);
                                                for (int k = 0; k <= (int)strArrays2.Length - 1; k++)
                                                {
                                                    string str10 = strArrays2[k];
                                                    chrArray = new char[] { '$' };
                                                    string[] strArrays3 = str10.Split(chrArray);
                                                    string str11 = strArrays3[0];
                                                    chrArray = new char[] { '@' };
                                                    string[] strArrays4 = str11.Split(chrArray);
                                                    string str12 = strArrays4[0];
                                                    chrArray = new char[] { '\u005E' };
                                                    string[] strArrays5 = str12.Split(chrArray);
                                                    strArrays4[0] = strArrays5[1];
                                                    string str13 = strArrays3[1];
                                                    chrArray = new char[] { '\u005E' };
                                                    string[] strArrays6 = str13.Split(chrArray);
                                                    for (int l = 0; l <= (int)strArrays4.Length - 1; l++)
                                                    {
                                                        if (strArrays4[l].ToString() != "")
                                                        {
                                                            strArrays = new string[] { empty2, base.SpecialDecode(dataTable11.Rows[l]["screenName"].ToString()), ": ", strArrays4[l].ToString(), " " };
                                                            empty2 = string.Concat(strArrays);
                                                            if (l == 0)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty9))
                                                                {
                                                                    empty9 = string.Concat(empty9, strArrays4[l].ToString(), "\n");
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty9 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                }
                                                            }
                                                            if (l == 1)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty4))
                                                                {
                                                                    empty4 = string.Concat(empty4, strArrays4[l].ToString(), "\n ");
                                                                    empty11 = strArrays4[l].ToString();///////////////////
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty4 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                    empty11 = strArrays4[l].ToString();///////////////////
                                                                }
                                                            }
                                                            if (l == 2)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty5))
                                                                {
                                                                    empty5 = string.Concat(empty5, strArrays4[l].ToString(), "\n ");
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty5 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                }
                                                            }
                                                            if (l == 3)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty6))
                                                                {
                                                                    empty6 = string.Concat(empty6, strArrays4[l].ToString(), "\n ");
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty6 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                }
                                                            }
                                                            if (l == 4)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty7))
                                                                {
                                                                    empty7 = string.Concat(empty7, strArrays4[l].ToString(), "\n ");
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty7 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                }
                                                            }
                                                            if (l == 5)
                                                            {
                                                                if (!string.IsNullOrEmpty(empty8))
                                                                {
                                                                    empty8 = string.Concat(empty8, strArrays4[l].ToString(), "\n ");
                                                                }
                                                                else if (!string.IsNullOrEmpty(Convert.ToString(strArrays4[l])))
                                                                {
                                                                    empty8 = string.Concat(strArrays4[l].ToString(), "\n ");
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (string.IsNullOrEmpty(strArrays3[1]))
                                                    {
                                                        empty3 = (!string.IsNullOrEmpty(empty3) ? string.Concat(empty3, strArrays5[0], "\n") : string.Concat(strArrays5[0], "\n"));
                                                        empty10 = strArrays5[0].ToString();///////////////////
                                                    }
                                                    else if (strArrays6[1] == strArrays5[0])
                                                    {
                                                        str = empty3;
                                                        strArrays = new string[] { str, strArrays6[0], "  ", strArrays6[1], "\n" };
                                                        empty3 = string.Concat(strArrays);
                                                    }
                                                    else if (!string.IsNullOrEmpty(empty3))
                                                    {
                                                        empty3 = string.Concat(empty3, Convert.ToInt32(strArrays5[0]) - Convert.ToInt32(strArrays6[1]), "\n");
                                                        str = empty3;
                                                        strArrays = new string[] { str, strArrays6[0], "  ", strArrays6[1], "\n" };
                                                        empty3 = string.Concat(strArrays);
                                                    }
                                                    else
                                                    {
                                                        empty3 = string.Concat(empty3, Convert.ToInt32(strArrays5[0]) - Convert.ToInt32(strArrays6[1]), "\n");
                                                        str = empty3;
                                                        strArrays = new string[] { str, strArrays6[0], "  ", strArrays6[1], "\n" };
                                                        empty3 = string.Concat(strArrays);
                                                    }
                                                    stringBuilder21.Append(string.Concat(empty2, "\n"));
                                                    empty2 = "";
                                                    stringBuilder22.Append(string.Concat(empty11, " : ", empty10, "\n"));
                                                }
                                                this.objValueItem = this.objValueItem.Replace("[StockLocation]", stringBuilder21.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockToPick]", empty3.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockCustomField2]", empty4.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockCustomField3]", empty5.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockCustomField4]", empty6.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockCustomField5]", empty7.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[StockCustomField6]", empty8.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[WarehouseLocation]", empty9.ToString());
                                                this.objValueItem = this.objValueItem.Replace("[Rack/stock on hand]", stringBuilder22.ToString());
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        this.RFQDesc = row12["RFQDescription"].ToString();
                                    }
                                    else if (this.PageType.ToLower() != "purchase")
                                    {
                                        this.objValueItem = this.objValueItem.Replace("[Quantity1]", row12["Quantity"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[QuantityDelivered]", row12["Quantity"].ToString());
                                        if (this.PageType.ToLower() == "estimate")
                                        {
                                            if ((this.objValueItem == "[ProductTotalCost1]") || (this.objValueItem == "[ProductTotalCost2]") || (this.objValueItem == "[ProductTotalCost3]") || (this.objValueItem == "[ProductTotalCost4]"))
                                            {
                                                if (this.EstItemType.ToLower() == "c")
                                                {
                                                    DataTable _dt3 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
                                                    decimal TotalEXcMarkup1 = new decimal(0);
                                                    decimal TotalEXcMarkup2 = new decimal(0);
                                                    decimal TotalEXcMarkup3 = new decimal(0);
                                                    decimal TotalEXcMarkup4 = new decimal(0);
                                                    foreach (DataRow dataRow2 in _dt3.Rows)
                                                    {
                                                        TotalEXcMarkup1 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup1"]);
                                                        TotalEXcMarkup2 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup2"]);
                                                        TotalEXcMarkup3 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup3"]);
                                                        TotalEXcMarkup4 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup4"]);
                                                    }

                                                    string[] totalCostArray = row12["ProductTotalCost"].ToString().Split(',');
                                                    if (this.objValueItem == "[ProductTotalCost1]")
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace("[ProductTotalCost1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (TotalEXcMarkup1 + Convert.ToDecimal(totalCostArray[0])), 0, "", false, false, true), true));
                                                    }
                                                    if (this.objValueItem == "[ProductTotalCost2]")
                                                    {
                                                        if((TotalEXcMarkup2 + Convert.ToDecimal(totalCostArray[1])) > 0)
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[ProductTotalCost2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (TotalEXcMarkup2 + Convert.ToDecimal(totalCostArray[1])), 0, "", false, false, true), true));
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[ProductTotalCost2]", "");
                                                        }
                                                    }

                                                    if (this.objValueItem == "[ProductTotalCost3]")
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace("[ProductTotalCost3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (TotalEXcMarkup3 + Convert.ToDecimal(totalCostArray[2])), 0, "", false, false, true), true));
                                                    }

                                                    if (this.objValueItem == "[ProductTotalCost4]")
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace("[ProductTotalCost4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (TotalEXcMarkup4 + Convert.ToDecimal(totalCostArray[3])), 0, "", false, false, true), true));
                                                    }
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[ProductTotalCost1]", "");
                                                    this.objValueItem = this.objValueItem.Replace("[ProductTotalCost2]", "");
                                                    this.objValueItem = this.objValueItem.Replace("[ProductTotalCost3]", "");
                                                    this.objValueItem = this.objValueItem.Replace("[ProductTotalCost4]", "");

                                                }

                                            }

                                        }
                                        if (this.PageType.ToLower() == "invoice")
                                        {
                                            if ((this.objValueItem == "[ProductTotalCost]"))
                                            {
                                                if (this.EstItemType.ToLower() == "c")
                                                {
                                                    DataTable _dt4 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
                                                    decimal TotalEXcMarkup1 = new decimal(0);
                                                    foreach (DataRow dataRow2 in _dt4.Rows)
                                                    {
                                                        TotalEXcMarkup1 = Convert.ToDecimal(dataRow2["SelPriceTotalExMarkup1"]);
                                                    }

                                                    string totalCost = row12["ProductTotalCost"].ToString();
                                                    if (this.objValueItem == "[ProductTotalCost]")
                                                    {
                                                        if((TotalEXcMarkup1 + Convert.ToDecimal(totalCost)) > 0)
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[ProductTotalCost]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (TotalEXcMarkup1 + Convert.ToDecimal(totalCost)), 0, "", false, false, true), true));
                                                        }
                                                        else
                                                        {
                                                            this.objValueItem = this.objValueItem.Replace("[ProductTotalCost]", "");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[ProductTotalCost]", "");

                                                }

                                            }
                                        }


                                        if (this.PageType.ToLower() == "invoice" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[QuantityDescription1]", row12["QtyDescription1"].ToString());
                                            if (!(this.EstItemType.ToLower() != "x") || !(this.EstItemType.ToLower() != "c"))
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[CostForEachSet1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                            }
                                            else
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[CostForEachSet1]", "");
                                            }
                                            if (this.PageType.ToLower() == "job")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[LastJobUsed]", row12["LastJobUsedSplitON"].ToString());
                                                StringBuilder stringBuilder22 = new StringBuilder();
                                                if (this.EstItemType.ToLower() == "c" || this.EstItemType.ToLower() == "x")
                                                {
                                                    string str14 = row12["Stock Location"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays7 = str14.Split(chrArray);
                                                    string empty10 = string.Empty;
                                                    DataTable dataTable12 = SettingsBasePage.productcatalogue_warehousestock_select(this.CompanyID);
                                                    for (int m = 0; m <= (int)strArrays7.Length - 1; m++)
                                                    {
                                                        string str15 = strArrays7[m];
                                                        chrArray = new char[] { '@' };
                                                        string[] strArrays8 = str15.Split(chrArray);
                                                        for (int n = 0; n <= (int)strArrays8.Length - 1; n++)
                                                        {
                                                            if (strArrays8[n].ToString() != "")
                                                            {
                                                                strArrays = new string[] { empty10, base.SpecialDecode(dataTable12.Rows[n]["screenName"].ToString()), ": ", strArrays8[n].ToString(), " " };
                                                                empty10 = string.Concat(strArrays);
                                                            }
                                                        }
                                                        stringBuilder22.Append(string.Concat(empty10, "\n"));
                                                        empty10 = "";
                                                    }
                                                }
                                                if (this.EstItemType.ToLower() == "b" || this.EstItemType.ToLower() == "k")
                                                {
                                                    string str16 = this.dtQty.Rows[0]["Total landscapevalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays9 = str16.Split(chrArray);
                                                    string str17 = this.dtQty.Rows[0]["Total portraitvalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays10 = str17.Split(chrArray);
                                                    string str18 = this.dtQty.Rows[0]["No Of Pages"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays11 = str18.Split(chrArray);
                                                    string str19 = this.dtQty.Rows[0]["Print layout"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays12 = str19.Split(chrArray);
                                                    string empty11 = string.Empty;
                                                    string empty12 = string.Empty;
                                                    string empty13 = string.Empty;
                                                    for (int o = 0; o <= (int)strArrays12.Length - 1; o++)
                                                    {
                                                        if (strArrays12[o].ToLower().Trim() == "portrait")
                                                        {
                                                            obj = empty11;
                                                            item = new object[] { obj, "Section ", o + 1, ": ", strArrays10[o], "\n" };
                                                            empty11 = string.Concat(item);
                                                        }
                                                        else if (strArrays12[o].ToLower().Trim() == "landscape")
                                                        {
                                                            obj = empty11;
                                                            item = new object[] { obj, "Section ", o + 1, ": ", strArrays9[o], "\n" };
                                                            empty11 = string.Concat(item);
                                                        }
                                                        obj = empty12;
                                                        item = new object[] { obj, "Section ", o + 1, ": ", strArrays11[o], "\n" };
                                                        empty12 = string.Concat(item);
                                                        obj = empty13;
                                                        item = new object[] { obj, "Section ", o + 1, ": ", strArrays12[o], "\n" };
                                                        empty13 = string.Concat(item);
                                                    }
                                                    this.objValueItem = this.objValueItem.Replace("[TotalSection]", row12["Total Section"].ToString());
                                                    this.objValueItem = this.objValueItem.Replace("[TotalNoOfPages]", row12["Total No Of Pages"].ToString());
                                                    this.objValueItem = this.objValueItem.Replace("[PrintLayoutNumber]", string.Concat("\n", empty11.ToString()));
                                                    this.objValueItem = this.objValueItem.Replace("[NumberOfPagesInSection]", string.Concat("\n", empty12.ToString()));
                                                    this.objValueItem = this.objValueItem.Replace("[Printlayout]", string.Concat("\n", empty13.ToString()));
                                                }
                                                if (this.EstItemType.ToLower() == "n")
                                                {
                                                    string str20 = this.dtQty.Rows[0]["Total landscapevalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays13 = str20.Split(chrArray);
                                                    string str21 = this.dtQty.Rows[0]["Total portraitvalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays14 = str21.Split(chrArray);
                                                    string str22 = this.dtQty.Rows[0]["Print layout"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays15 = str22.Split(chrArray);
                                                    string empty14 = string.Empty;
                                                    string empty15 = string.Empty;
                                                    for (int p = 0; p <= (int)strArrays15.Length - 1; p++)
                                                    {
                                                        if (strArrays15[p].ToLower().Trim() == "portrait")
                                                        {
                                                            obj = empty14;
                                                            item = new object[] { obj, "Part ", p + 1, ": ", strArrays14[p], " " };
                                                            empty14 = string.Concat(item);
                                                        }
                                                        else if (strArrays15[p].ToLower().Trim() == "landscape")
                                                        {
                                                            obj = empty14;
                                                            item = new object[] { obj, "Part ", p + 1, ": ", strArrays13[p], " " };
                                                            empty14 = string.Concat(item);
                                                        }
                                                        obj = empty15;
                                                        item = new object[] { obj, "Part ", p + 1, ": ", strArrays15[p], " " };
                                                        empty15 = string.Concat(item);
                                                    }
                                                    this.objValueItem = this.objValueItem.Replace("[PrintLayoutNumber]", string.Concat("\n", empty14.ToString()));
                                                    this.objValueItem = this.objValueItem.Replace("[Printlayout]", string.Concat("\n", empty15.ToString()));
                                                }
                                                if (this.EstItemType.ToLower() == "s" || this.EstItemType.ToLower() == "p" || this.EstItemType.ToLower() == "f" || this.EstItemType.ToLower() == "d" || this.EstItemType.ToLower() == "l")
                                                {
                                                    string str23 = this.dtQty.Rows[0]["Print layout"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays16 = str23.Split(chrArray);
                                                    string str24 = this.dtQty.Rows[0]["Total landscapevalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays17 = str24.Split(chrArray);
                                                    string str25 = this.dtQty.Rows[0]["Total portraitvalue"].ToString();
                                                    chrArray = new char[] { ',' };
                                                    string[] strArrays18 = str25.Split(chrArray);
                                                    string empty16 = string.Empty;
                                                    string empty17 = string.Empty;
                                                    for (int q = 0; q <= (int)strArrays16.Length - 1; q++)
                                                    {
                                                        if (strArrays16[q].ToLower().Trim() == "portrait")
                                                        {
                                                            empty17 = string.Concat(empty17, strArrays18[q], "\n");
                                                        }
                                                        else if (strArrays16[q].ToLower().Trim() == "landscape")
                                                        {
                                                            empty17 = string.Concat(empty17, strArrays17[q], "\n");
                                                        }
                                                        empty16 = strArrays16[q];
                                                    }
                                                    this.objValueItem = this.objValueItem.Replace("[Printlayout]", string.Concat("\n", empty16.ToString()));
                                                    this.objValueItem = this.objValueItem.Replace("[PrintLayoutNumber]", string.Concat("\n", empty17.ToString()));
                                                }
                                                this.objValueItem = this.objValueItem.Replace("[StockLocation]", stringBuilder22.ToString());
                                                string str26 = (row12["PaperWeight"] == null ? "" : string.Concat(row12["PaperWeight"].ToString(), " ", this.objpage.GetRegionalSettings(this.CompanyID, "Weight")));
                                                if (!(str26 == "") || !this.objValueItem.Contains("[PaperWeight]"))
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[PaperWeight]", str26);
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                                }
                                                if (!string.IsNullOrEmpty(row12["PoNo"].ToString()))
                                                {
                                                    this.purchaseitemnumber = row12["PoNo"].ToString();
                                                    this.objValueItem = this.objValueItem.Replace("[PurchaseNumber#]", this.purchaseitemnumber);
                                                }
                                            }
                                            if (this.PageType.ToLower() == "invoice")
                                            {
                                                if (objValueItem == "[SubItemPrice1]" || objValueItem == "[SubItemTitle]")
                                                {
                                                    this.objTagItem = objValueItem;
                                                    foreach (DataRow dataRow5 in dataSet1.Tables[2].Rows)
                                                    {
                                                        var num5 = Convert.ToInt64(dataRow5["EstimateItemID"]);
                                                        objValueItem = GetSubItemValues(num5);
                                                    }
                                                }
                                                this.objValueItem = this.objValueItem.Replace("[AccountingCode]", row12["AccountingCode"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[MergedJobTitle]", row12["MergedJobTitle"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[CustomerOrderNumberbyItem]", row12["CustomerOrderNumberByItem"].ToString());
                                                
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[TaxPercentage]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Tax"]), 0, "", false, false, true), "%"));
                                                    this.objValueItem = this.objValueItem.Replace("[TaxName]", row12["TaxName"].ToString());
                                                    this.objValueItem = this.objValueItem.Replace("[CustomerContactOfJob]", row12["CustomerContactOfJob"].ToString());
                                                    this.objValueItem = this.objValueItem.Replace("[CostCentreOfJob]", row12["CostCentreOfJob"].ToString());
                                                    if (objValueItem.Contains("[PurchaseNumber]"))
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace("[PurchaseNumber]", row12["PoNo"].ToString());
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        else if (this.PageType.ToLower() == "webstoreorder" || this.PageType.ToLower() == "order")
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[QuantityDescription1]", row12["QtyDescription1"].ToString());
                                            if (!string.IsNullOrEmpty(row12["CostForEachSet"].ToString()))
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[CostForEachSet1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                            }
                                        }
                                        else
                                        {
                                            if (row12["QtyDescription1"].ToString() != "0")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription1]", row12["QtyDescription1"].ToString());
                                            }
                                            else if (row12["QtyDescription1"].ToString() == "0" && this.objValueItem == "[QuantityDescription1]")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription1]", "");
                                            }
                                            if (row12["QtyDescription2"].ToString() != "0")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription2]", row12["QtyDescription2"].ToString());
                                            }
                                            else if (row12["QtyDescription2"].ToString() == "0" && this.objValueItem == "[QuantityDescription2]")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription2]", "");
                                            }
                                            if (row12["QtyDescription3"].ToString() != "0")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription3]", row12["QtyDescription3"].ToString());
                                            }
                                            else if (row12["QtyDescription3"].ToString() == "0" && this.objValueItem == "[QuantityDescription3]")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription3]", "");
                                            }
                                            if (row12["QtyDescription4"].ToString() != "0")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription4]", row12["QtyDescription4"].ToString());
                                            }
                                            else if (row12["QtyDescription4"].ToString() == "0" && this.objValueItem == "[QuantityDescription4]")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[QuantityDescription4]", "");
                                            }
                                            if (num17 == 1)
                                            {
                                                if (this.EstItemType.ToLower() != "c")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet1]", "");
                                                }
                                                else if (row12["CostForEachSet"].ToString() != "0")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (num17 == 2)
                                            {
                                                if (this.EstItemType.ToLower() != "c")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet2]", "");
                                                }
                                                else if (row12["CostForEachSet"].ToString() != "0")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (num17 == 3)
                                            {
                                                if (this.EstItemType.ToLower() != "c")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet3]", "");
                                                }
                                                else if (row12["CostForEachSet"].ToString() != "0")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                                }
                                            }
                                            if (num17 == 4)
                                            {
                                                if (this.EstItemType.ToLower() != "c")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet4]", "");
                                                }
                                                else if (row12["CostForEachSet"].ToString() != "0")
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[CostForEachSet4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostForEachSet"]), 0, "", false, false, true), true));
                                                }
                                            }
                                        }
                                        try
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[ProductItemCode]", row12["ProductItemCode"].ToString());
                                            this.objValueItem = this.objValueItem.Replace("[ProductCustomerCode]", row12["ProductCustomerCode"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        if (row12["Quantity"].ToString() != "0")
                                        {
                                            this.htQtyNum.Remove(num17);
                                            this.htTotQtyNum.Remove(num17);
                                            try
                                            {
                                                if (Convert.ToInt32(row12["MultipleOf"]) <= 1)
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[Quantity", num17, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true));
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[QuantityWithMultipleOf", num17, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true));
                                                }
                                                else
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[Quantity", num17, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true));
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[QuantityWithMultipleOf", num17, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true), " X ", row12["MultipleOf"].ToString()));
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            if (this.objValueItem.Contains(string.Concat("[Tax", num17, "]")))
                                            {
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[Tax", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["TaxValue"]), 0, "", false, false, true), true));
                                                    //  LogException(string.Concat(this.SecureDocFilepath, this.ServerName, "/", "exception_log.txt"));
                                                }
                                                catch (Exception ex)
                                                {
                                                    LogException(ex);
                                                }
                                            }
                                            if (this.objValueItem.Contains(string.Concat("[Price", num17, "(exTax)]")))
                                            {
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[Price", num17, "(exTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["SubTotal"]), 0, "", false, false, true), true));
                                                    // LogException(this.objValueItem);
                                                }
                                                catch (Exception ex)
                                                {
                                                    LogException(ex);
                                                }
                                            }
                                            if (this.objValueItem.Contains(string.Concat("[Price", num17, "(inTax)]")))
                                            {
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[Price", num17, "(inTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PriceInTax"]), 0, "", false, false, true), true));
                                                    // LogException(this.objValueItem);
                                                }
                                                catch (Exception ex)
                                                {
                                                    LogException(ex);
                                                }
                                            }
                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[ProfitMarginPrice", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["ProfitMarginValue"]), 0, "", false, false, true), true));
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[ProfitMarginPercentage", num17, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["ProfitMargin"]), 0, "", false, false, true), "%"));
                                            }
                                            catch
                                            {
                                            }

                                            try
                                            {
                                                if (this.objValueItem.Contains(string.Concat("[MarkUp$", num17, "]")))
                                                {
                                                    var testvalue = this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["ProfitMarginValue"]), 0, "", false, false, true), true);
                                                    if(testvalue== "$0.00" || testvalue == "0.00")
                                                    {
                                                        testvalue = "\u200B";
                                                    }
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[MarkUp$", num17, "]"), testvalue);
                                                  

                                                }
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[MarkUp%", num17, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["ProfitMargin"]), 0, "", false, false, true), "%"));
                                            }
                                            catch
                                            {
                                            }


                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[ItemNegativeMarkup", num17, "]"), Convert.ToDecimal(row12["MarkupPrice"]) < 0 ? this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(row12["MarkupPrice"]), 0, "", false, false, true), true) : "");
                                            }
                                            catch
                                            {
                                            }

                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[NegativeMarkup", num17, "]"), (Convert.ToDecimal(row12["MarkupPrice"])+ Convert.ToDecimal(row12["ProfitMarginValue"])) < 0 ? this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (Convert.ToDecimal(row12["MarkupPrice"]) + Convert.ToDecimal(row12["ProfitMarginValue"])), 0, "", false, false, true), true) : "");
                                            }
                                            catch
                                            {
                                            }

                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[ItemCostexMarkup", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostexMarkup"]), 0, "", false, false, true), true));
                                            }
                                            catch
                                            {
                                            }




                                            try
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[OrderNumber]", row12["OrderNumber"].ToString());
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                string empty18 = string.Empty;
                                                string empty19 = string.Empty;
                                                string empty20 = string.Empty;
                                                string empty21 = string.Empty;
                                                if (row12["Orderedwidth"] != null)
                                                {
                                                    empty18 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Orderedwidth"]), 2, "", false, false, true);
                                                }
                                                if (row12["OrderedHeight"] != null)
                                                {
                                                    empty19 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["OrderedHeight"]), 2, "", false, false, true);
                                                }
                                                if (row12["Productwidth"] != null)
                                                {
                                                    empty20 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Productwidth"]), 2, "", false, false, true);
                                                }
                                                if (row12["ProductHeight"] != null)
                                                {
                                                    empty21 = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["ProductHeight"]), 2, "", false, false, true);
                                                }
                                                if (empty18 == "0.00")
                                                {
                                                    empty18 = "";
                                                }
                                                if (empty19 == "0.00")
                                                {
                                                    empty19 = "";
                                                }
                                                if (empty20 == "0.00")
                                                {
                                                    empty20 = "";
                                                }
                                                if (empty21 == "0.00")
                                                {
                                                    empty21 = "";
                                                }
                                                //this.objValueItem = this.objValueItem.Replace("[$Product_Width$]", empty20);
                                                this.objValueItem = this.objValueItem.Replace("[$Product_Width$]", empty18);
                                                //this.objValueItem = this.objValueItem.Replace("[$Product_Height$]", empty21);
                                                this.objValueItem = this.objValueItem.Replace("[$Product_Height$]", empty19);
                                                this.objValueItem = this.objValueItem.Replace("[$Ordered_Width$]", empty18);
                                                this.objValueItem = this.objValueItem.Replace("[$Ordered_Height$]", empty19);
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace(string.Concat("[CostPricePlusTax", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, ((Convert.ToDecimal(row12["CostExMarkup"]) * Convert.ToDecimal(row12["Tax"])) / new decimal(100)) + Convert.ToDecimal(row12["CostExMarkup"]), 0, "", false, false, true), true));
                                                }
                                                catch
                                                {
                                                }
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[CostPrice", num17, "(exMarkup)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostExMarkup"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[CostPrice", num17, "(InMarkup)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["CostInMarkup"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[MarkupPrice", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["MarkupPrice"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[SubTotal", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["SubTotal"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[GrossProfitPrice", num17, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["GrossProfitPrice"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[GrossProfitPercentage", num17, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["GrossProfitPercentage"]), 0, "", false, false, true), " %"));
                                                this.objValueItem = this.objValueItem.Replace(string.Concat("[SupplierQuote#", num17, "]"), row12["SupplierRefNo"].ToString());
                                                if (this.UnitOfMeasureKey)
                                                {
                                                    if (this.EstItemType != "B" && this.EstItemType != "K" && this.EstItemType != "N" && this.EstItemType != "W" && this.EstItemType != "U" && this.EstItemType != "O")
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace(string.Concat("[PricePerUnitofMeasureQty", num17, "]"), row12["PricePerQty"].ToString());
                                                    }
                                                    else if (this.objValueItem.Contains(string.Concat("[PricePerUnitofMeasureQty", num17, "]")))
                                                    {
                                                        this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            if (this.PageType.ToLower() != "webstoreorder")
                                            {
                                                this.objValueItem = this.Return_PricePerUnit(this.objValueItem, Convert.ToDecimal(row12["SubTotal"]), Convert.ToDecimal(row12["Quantity"]), num17, Convert.ToDecimal(row12["TaxValue"]));
                                            }
                                            else
                                            {
                                                decimal num18 = Convert.ToDecimal(row12["CostExMarkup"]) + Convert.ToDecimal(row12["MarkupPrice"]);
                                                this.objValueItem = this.Return_PricePerUnit(this.objValueItem, num18, Convert.ToDecimal(row12["Quantity"]), num17, Convert.ToDecimal(row12["TaxValue"]));
                                            }
                                            this.objValueItem = this.Return_CostPerUnit(this.objValueItem, Convert.ToDecimal(row12["CostExMarkup"]), Convert.ToDecimal(row12["Quantity"]));
                                            this.objValueItem = this.Return_WarehouseDetails(this.objValueItem, this.EstimateItemID, this.EstItemType);
                                            if (this.PageType.ToLower() == "webstoreorder")
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[JobName]", row12["JobName"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[AdditionalOptionTotalPrice(ExMarkup)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["AdditionalOptionPriceExMarkup"]), 0, "", false, false, true), true));
                                                this.objValueItem = this.objValueItem.Replace("[AdditionalOptionTotalPrice(InMarkup)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["AdditionalOptionPriceInMarkup"]), 0, "", false, false, true), true));
                                            }
                                            else
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[JobTitle]", row12["JobTitle"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[EstimateTitle]", row12["JobTitle"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[InvoiceTitle]", row12["JobTitle"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[JobNumber]", row12["JobNUmber"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[CustomerName]", row12["CustomerName"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[PODate]", row12["PoDate"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[CustomerPaymentTerms]", row12["PaymentTerms"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[ContactName]", row12["ContactName"].ToString());
                                                this.objValueItem = this.objValueItem.Replace("[JobName]", row12["JobName"].ToString());

                                                //this.objValueItem = this.objValueItem.Replace("[EstimateTitleHeader]", row12["JobTitle"].ToString());
                                                //this.objValueItem = this.objValueItem.Replace("[JobTitleHeader]", row12["JobTitle"].ToString());
                                            }
                                            this.RFQDesc = row12["RFQDescription"].ToString();
                                            if (!flag3)
                                            {
                                                if (num17 == 1)
                                                {
                                                    this.FinalTotalPrice1ExTax = this.FinalTotalPrice1ExTax + Convert.ToDecimal(row12["SubTotal"]);
                                                    this.FinalTotalTaxValue1 = this.FinalTotalTaxValue1 + Convert.ToDecimal(row12["TaxValue"]);
                                                    try
                                                    {
                                                        this.FinalTotalQuantity1 = this.FinalTotalQuantity1 + Convert.ToDecimal(row12["Quantity"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalProfitMarginPrice1 = this.FinalTotalProfitMarginPrice1 + Convert.ToDecimal(row12["ProfitMarginValue"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalCostPrice1ExMarkup = this.FinalTotalCostPrice1ExMarkup + Convert.ToDecimal(row12["CostExMarkup"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalMarkupPrice1 = this.FinalTotalMarkupPrice1 + Convert.ToDecimal(row12["MarkupPrice"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalGrossProfitPrice1 = this.FinalTotalGrossProfitPrice1 + Convert.ToDecimal(row12["GrossProfitPrice"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalGrossProfitPercentage1 = this.FinalTotalGrossProfitPercentage1 + Convert.ToDecimal(row12["GrossProfitPercentage"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if (num17 == 2)
                                                {
                                                    this.FinalTotalPrice2ExTax = this.FinalTotalPrice2ExTax + Convert.ToDecimal(row12["SubTotal"]);
                                                    this.FinalTotalTaxValue2 = this.FinalTotalTaxValue2 + Convert.ToDecimal(row12["TaxValue"]);
                                                    try
                                                    {
                                                        this.FinalTotalQuantity2 = this.FinalTotalQuantity2 + Convert.ToDecimal(row12["Quantity"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalProfitMarginPrice2 = this.FinalTotalProfitMarginPrice2 + Convert.ToDecimal(row12["ProfitMarginValue"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if (num17 == 3)
                                                {
                                                    this.FinalTotalPrice3ExTax = this.FinalTotalPrice3ExTax + Convert.ToDecimal(row12["SubTotal"]);
                                                    this.FinalTotalTaxValue3 = this.FinalTotalTaxValue3 + Convert.ToDecimal(row12["TaxValue"]);
                                                    try
                                                    {
                                                        this.FinalTotalQuantity3 = this.FinalTotalQuantity3 + Convert.ToDecimal(row12["Quantity"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalProfitMarginPrice3 = this.FinalTotalProfitMarginPrice3 + Convert.ToDecimal(row12["ProfitMarginValue"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if (num17 == 4)
                                                {
                                                    this.FinalTotalPrice4ExTax = this.FinalTotalPrice4ExTax + Convert.ToDecimal(row12["SubTotal"]);
                                                    this.FinalTotalTaxValue4 = this.FinalTotalTaxValue4 + Convert.ToDecimal(row12["TaxValue"]);
                                                    try
                                                    {
                                                        this.FinalTotalQuantity4 = this.FinalTotalQuantity4 + Convert.ToDecimal(row12["Quantity"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    try
                                                    {
                                                        this.FinalTotalProfitMarginPrice4 = this.FinalTotalProfitMarginPrice4 + Convert.ToDecimal(row12["ProfitMarginValue"]);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }

                                            // Ticket #9310 ART FOR LIFE - ESTIMATE AND INVOICE TEMPLATE 												
                                            try
                                            {
                                                if (objValueItem.Contains("[CostPriceIncMarkup]"))
                                                {
                                                    this.objValueItem = this.Return_CostPriceIncMarkup(this.objValueItem, Convert.ToDecimal(row12["CostInMarkup"]), Convert.ToDecimal(row12["Quantity"]));
                                                }
                                                else
                                                {
                                                    objValueItem = objValueItem.Replace("[CostPriceIncMarkup]", "");
                                                }

                                            }
                                            catch (Exception ex)
                                            {

                                                throw ex;
                                            }

                                            // job item no 												
                                            try
                                            {
                                                if (objValueItem.Contains("[JobItemNo]") && Convert.ToString(row12["JobNumber"]) != "")
                                                {
                                                    this.objValueItem = objValueItem.Replace("[JobItemNo]", Convert.ToString(row12["JobNumber"]));
                                                }
                                                else
                                                {
                                                    objValueItem = objValueItem.Replace("[JobItemNo]", "");
                                                }

                                            }
                                            catch (Exception ex)
                                            {

                                                throw ex;
                                            }
                                            // Estimate item no 	
                                            //try
                                            //{
                                            //    if (this.PageType.ToLower() == "estimate")
                                            //    {
                                            //        if (this.objTagItem.Contains("[EstItemNo]") && Convert.ToString(row12["EstimateItemNo"]) != "")
                                            //        {

                                            //            this.objValueItem = objValueItem.Replace(this.objValueItem.ToString(), Convert.ToString(row12["EstimateItemNo"]));
                                            //        }
                                            //        else
                                            //        {
                                            //            objValueItem = objValueItem.Replace("[EstItemNo]", "");
                                            //        }
                                            //    }

                                            //}
                                            //catch (Exception ex)
                                            //{

                                            //    throw ex;
                                            //}

                                            // Ticket #9300 TAX Name and TaxPercentage added for estimate template    
                                            if (objValueItem.Contains("[TaxPercentage]") || objValueItem.Contains("[TaxName]"))
                                            {
                                                try
                                                {
                                                    this.objValueItem = this.objValueItem.Replace("[TaxPercentage]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Tax"]), 0, "", false, false, true), "%"));
                                                    this.objValueItem = this.objValueItem.Replace("[TaxName]", row12["TaxName"].ToString());
                                                }
                                                catch
                                                {
                                                }
                                            }
                                            else
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[TaxPercentage]", "");
                                                this.objValueItem = this.objValueItem.Replace("[TaxName]", "");
                                            }


                                        }
                                    }
                                    else
                                    {
                                        this.objValueItem = this.objValueItem.Replace("[Quantity1]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true));
                                        this.objValueItem = this.objValueItem.Replace("[QuantityDelivered]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["Quantity"]), 0, "", true, false, true));
                                        this.objValueItem = this.objValueItem.Replace("[Tax1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["TaxValue"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[Price1(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["SubTotal"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[Price1(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PriceInTax"]), 0, "", false, false, true), true));
                                        // var priceper1000 = (Convert.ToDecimal(row12["SubTotal"]) / Convert.ToDecimal(row12["Quantity"])) * 1000;
                                        // ticket 111298
                                        if (Convert.ToDecimal(row12["Quantity"]) != 0)
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[PricePer1000]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(row12["SubTotal"]) / Convert.ToDecimal(row12["Quantity"])) * 1000, 0, "", false, false, true), true));
                                        }
                                        else
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[PricePer1000]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(row12["SubTotal"]) / 1) * 1000, 0, "", false, false, true), true));
                                        }
                                        if (this.objValueItem == "[InventoryName]")
                                        {
                                            if (!string.IsNullOrEmpty(row12["InventoryName"].ToString()))
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[InventoryName]", row12["InventoryName"].ToString());
                                            }
                                            else
                                            {
                                                this.objValueItem = this.objValueItem.Replace("[InventoryName]", "");
                                            }
                                        }

                                        this.objValueItem = this.objValueItem.Replace("[PODescription]", row12["Description"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[ItemCode]", row12["ItemCode"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[UnitCBM]", Convert.ToDecimal(row12["UnitCBM"]).ToString("0.###"));

                                        this.objValueItem = this.objValueItem.Replace("[LineCBM]", Convert.ToDecimal(row12["LineCBM"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[UnitWeight]", Convert.ToDecimal(row12["UnitWeight"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[LineWeight]", Convert.ToDecimal(row12["LineWeight"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductLength]", Convert.ToDecimal(row12["ProductLength"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductWidth]", Convert.ToDecimal(row12["ProductWidth"]).ToString("0.###"));
                                        this.objValueItem = this.objValueItem.Replace("[ProductHeight]", Convert.ToDecimal(row12["ProductHeight"]).ToString("0.###"));
                                        // Ticket #9589 added a tag for the products customer code in the purchase order template
                                        this.objValueItem = this.objValueItem.Replace("[POProductCustomerCode]", row12["POProductCustomerCode"].ToString());

                                        this.objValueItem = this.objValueItem.Replace("[MainItemTitle]", row12["MainItemTitle"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[MainItemProductCode]", row12["MainItemProductCode"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[inventoryDescription]", row12["inventoryDescription"].ToString());

                                        this.objValueItem = this.objValueItem.Replace("[ProductItemCode]", row12["ProductItemCode"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[PONotes]", row12["PoNotes"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[CustomerName]", row12["CustomerName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[JobTitle]", row12["JobTitle"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[EstimateTitle]", row12["JobTitle"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[InvoiceTitle]", row12["JobTitle"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[RefNo]", row12["JobNUmber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[JobNumber]", row12["JobNUmber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[POJobNumber]", row12["JobNUmber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[PODate]", row12["PoDate"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[CustomerPaymentTerms]", row12["PaymentTerms"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[ContactName]", row12["ContactName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[JobName]", row12["JobName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierCreditLimit]", row12["SupplierCreditLimit"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierCreditReference]", row12["SupplierCreditReference"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierTaxName]", row12["SupplierTaxName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierDescription]", row12["SupplierDescription"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierCompanyNumber]", row12["SupplierCompanyNumber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierCompanyType]", row12["SupplierCompanyType"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierSalesPerson]", row12["SupplierSalesPerson"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierProfitMarginPercentage]", row12["SupplierProfitMarginPercentage"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierTaxRegNumber]", row12["SupplierTaxRegNumber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierAccountOpenedDate]", row12["SupplierAccountOpenedDate"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierBankCode]", row12["SupplierBankCode"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierBankAccountNumber]", row12["SupplierBankAccountNumber"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierAccountName]", row12["SupplierAccountName"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[SupplierReferredBy]", row12["SupplierReferredBy"].ToString());
                                        this.objValueItem = this.objValueItem.Replace("[QuantityDescription1]", row12["QuantityDescription"].ToString());
                                        if ((row12["PaperSize"].ToString() == "0" || row12["PaperSize"].ToString() == "") && this.objValueItem.Contains("[PaperSize]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                        else
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[PaperSize]", row12["PaperSize"].ToString());
                                        }
                                        string str27 = (row12["PaperWeight"] == null ? "" : string.Concat(row12["PaperWeight"].ToString(), " ", this.objpage.GetRegionalSettings(this.CompanyID, "Weight")));
                                        if (!(str27 == "") || !this.objValueItem.Contains("[PaperWeight]"))
                                        {
                                            this.objValueItem = this.objValueItem.Replace("[PaperWeight]", str27);
                                        }
                                        else
                                        {
                                            this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        }
                                        this.objValueItem = this.objValueItem.Replace("[InventoryPackedIn]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PackedInQty"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[InventoryPackPrice]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PackPrice"]), 0, "", false, false, true), true));
                                        //this.objValueItem = this.objValueItem.Replace("[PricePerUnit1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PricePerUnit1"]), 0, "", false, false, true), true));
                                        this.objValueItem = this.objValueItem.Replace("[PricePerUnit]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row12["PricePerUnit1"]), 0, "", false, false, true), true));
                                        try
                                        {
                                            this.objValueItem = this.Return_PricePerUnitInclTax(this.objValueItem, Convert.ToDecimal(row12["SubTotal"]), Convert.ToDecimal(row12["Quantity"]), num17, Convert.ToDecimal(row12["TaxValue"]));
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                        this.RFQDesc = row12["RFQDescription"].ToString();
                                    }
                                    num17++;
                                    if ((this.PageType.ToLower() == "estimate" || this.PageType.ToLower() == "webstoreorder" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "purchase") && row12["ProductImage"].ToString() != "")
                                    {
                                        string str28 = this.objValueItem;
                                        item = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/Product/", row12["ProductImage"].ToString() };
                                        this.objValueItem = str28.Replace("[ProductImage]", string.Concat(item));
                                    }
                                    if (this.PageType.ToLower() != "job")
                                    {
                                        continue;
                                    }
                                    this.objValueItem = this.objValueItem.Replace("[LargeFormat_DPI]", row12["LargeFormat_DPI"].ToString());
                                    this.objValueItem = this.objValueItem.Replace("[LargeFormat_PressSpeed]", row12["LargeFormat_PressSpeed"].ToString());
                                }
                                flag3 = true;
                                if (this.objValueItem.IndexOf('[') > -1)
                                {
                                    foreach (string value3 in this.htQtyNum.Values)
                                    {
                                        if (!this.objValueItem.Contains(string.Concat("[Quantity", value3, "]")) && !this.objValueItem.Contains(string.Concat("[Tax", value3, "]")) && !this.objValueItem.Contains(string.Concat("[Price", value3, "(inTax)]")) && !this.objValueItem.Contains(string.Concat("[Price", value3, "(exTax)]")) && !this.objValueItem.Contains(string.Concat("[TotalPrice", value3, "(inTax)]")) && !this.objValueItem.Contains(string.Concat("[TotalTax", value3, "]")) && !this.objValueItem.Contains(string.Concat("[TotalPrice", value3, "(exTax)]")) && !this.objValueItem.Contains(string.Concat("[TotalProfitMarginPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[TotalQuantity", value3, "]")) && !this.objValueItem.Contains(string.Concat("[ProfitMarginPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[CostPrice", value3, "(exMarkup)]")) && !this.objValueItem.Contains(string.Concat("[MarkupPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[GrossProfitPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[GrossProfitPercentage", value3, "]")) && !this.objValueItem.Contains(string.Concat("[SubTotal", value3, "]")) && !this.objValueItem.Contains(string.Concat("[TotalCostPrice", value3, "(exMarkup)]")) && !this.objValueItem.Contains(string.Concat("[TotalMarkupPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[TotalGrossProfitPrice", value3, "]")) && !this.objValueItem.Contains(string.Concat("[TotalGrossProfitPercentage", value3, "]")) && !this.objValueItem.Contains(string.Concat("[SupplierQuote#", value3, "]")) && !this.objValueItem.Contains(string.Concat("[PricePerUnitofMeasureQty", value3, "]")) && !this.objValueItem.Contains(string.Concat("[PricePerUnit", value3, "]")) && !this.objValueItem.Contains(string.Concat("[QuantityWithMultipleOf", value3, "]")) && !this.objValueItem.Contains("[ProductImage]") && !this.objValueItem.Contains("[JobName]") && !this.objValueItem.Contains("[ProductAdditionalOptionsPrice1]") && !this.objValueItem.Contains("[eStoreAdditionalOptionValue]") && !this.objValueItem.Contains(string.Concat("[CostPrice", value3, "(InMarkup)]")) && !this.objValueItem.Contains("[LastJobUsed]") && !this.objValueItem.Contains("[TaxPercentage]") && !this.objValueItem.Contains("[TotalNoOfPages]") && !this.objValueItem.Contains("[Printlayout]") && !this.objValueItem.Contains("[TotalSection]") && !this.objValueItem.Contains("[PrintLayoutNumber]") && !this.objValueItem.Contains("[NumberOfPagesInSection]") && !this.objValueItem.Contains("[SubItemTitle]") && !this.objValueItem.Contains("[DeliveryNoteDescription]") && !this.objValueItem.Contains("[ContactName]") && !this.objValueItem.Contains("[RefNo]") && !this.objValueItem.Contains(string.Concat("[CostPricePlusTax", value3, "]")) && !this.objValueItem.Contains("[SubItemPrice1]") && !this.objValueItem.Contains("[SubItemPrice2]") && !this.objValueItem.Contains("[SubItemPrice3]") && !this.objValueItem.Contains("[SubItemPrice4]") && !this.objValueItem.Contains("[Supplier cost]") && !this.objValueItem.Contains("[StockLocation]") && !this.objValueItem.Contains("[Description]") && !this.objValueItem.Contains("[ProductCustomerCode]") && !this.objValueItem.Contains(string.Concat("[TotalProfitMarginPrice", value3, "_AllItem]")) && !this.objValueItem.Contains("[PaperWeight]") && !this.objValueItem.Contains(string.Concat("[ProfitMarginPercentage", value3, "]")) && !this.objValueItem.Contains("[PurchaseNumber#]") && !this.objValueItem.Contains("[POJobNumber]") && !this.objValueItem.Contains("[StockToPick]") && !this.objValueItem.Contains("[StockCustomField2]") && !this.objValueItem.Contains("[StockCustomField3]") && !this.objValueItem.Contains("[StockCustomField4]") && !this.objValueItem.Contains("[StockCustomField5]") && !this.objValueItem.Contains("[StockCustomField6]") && !this.objValueItem.Contains("[WarehouseLocation]") && !this.objValueItem.Contains("[Rack/stock on hand]") && !this.objValueItem.Contains(string.Concat("[PricePerUnit4Decimal", value3, "]")) && !this.objValueItem.Contains(string.Concat("[PricePer1000Unit", value3, "]")) && !this.objValueItem.Contains(string.Concat("[PricePer1000Unit4Decimal", value3, "]")) && !this.objValueItem.Contains(string.Concat("[MarkUp%", value3, "]")) && !this.objValueItem.Contains(string.Concat("[MarkUp$", value3, "]")) && !this.objValueItem.Contains(string.Concat("[SubTotalPerUnit", value3, "]")) && !this.objValueItem.Contains(string.Concat("[PricePerUnit", value3, "incTax]")) && !objValueItem.Contains(string.Concat("[NegativeMarkup", value3, "]")) && !objValueItem.Contains(string.Concat("[ItemNegativeMarkup", value3, "]")) && !objValueItem.Contains(string.Concat("[ItemCostexMarkup", value3, "]"))) 
                                        {
                                            continue;
                                        }
                                        this.objValueItem = this.objValueItem.Replace(this.objValueItem, "");
                                        break;
                                    }
                                }
                                if (this.objValueItem.IndexOf('[') > -1)
                                {
                                    if (this.PageType.ToLower() == "purchase" || this.PageType.ToLower() == "note" || this.PageType.ToLower() == "webstoreorder")
                                    {
                                        //Ticket #8063 Multi Mail - delivery note number field showing multiple numbers
                                        if ((this.PageType.ToLower() == "note") && (Convert.ToString(this.DeliveryNumber) != ""))
                                        {
                                            this.objValueItem = this.Return_ItemDescriptionByDeliveyId(this.objValueItem, this.EstItemID, Convert.ToString(this.DeliveryNumber));
                                        }
                                        else
                                        {
                                            this.objValueItem = this.Return_ItemDescription(this.objValueItem, this.EstItemID);
                                        }
                                    }
                                    else
                                    {
                                        this.objValueItem = this.Return_ItemDescription(this.objValueItem, this.EstimateItemID);
                                    }
                                }
                                if (this.objValueItem.IndexOf('[') > -1)
                                {
                                    this.objValueItem = this.GetCustomerAddressFromPage(this.objValueItem);
                                    this.objValueItem = this.GetCompanyAddressFromPage(this.objValueItem);
                                    this.objValueItem = this.GetSupplierAddressFromPage(this.objValueItem);
                                    this.objValueItem = this.GetCustomerContactAddressFromPage(this.objValueItem);
                                    this.objValueItem = this.GetSupplierContactAddressFromPage(this.objValueItem);
                                }
                                if (this.objValueItem.IndexOf('[') > -1)
                                {
                                    if (this.PageType.ToLower() != "invoice")
                                    {
                                        this.objValueItem = this.GetDeliveryAddress(this.objValueItem, this.CompanyID, this.EstimateID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                                    }
                                    else
                                    {
                                        this.objValueItem = this.GetDeliveryAddress(this.objValueItem, this.CompanyID, this.InvoiceID, this.DeliveryAddressID, this.DeliveryAddressType, this.DeliveryAddress);
                                    }
                                    this.objValueItem = this.GetEstimateJobInvoicePurchaseDeliveryAddressFromPage(this.objValueItem);
                                }
                                if (this.PageType.ToLower() != "note")
                                {
                                    item = new object[] { dataRow7["TemplateID"], dataRow7["CompanyID"], dataRow7["objID"], dataRow7["objType"], dataRow7["objName"], dataRow7["type"], this.objValueItem, dataRow7["imgsrc"], dataRow7["title"], dataRow7["align"], dataRow7["position"], this.objTop, dataRow7["left"], dataRow7["width"], dataRow7["height"], dataRow7["zindex"], dataRow7["padding"], dataRow7["display"], dataRow7["overflow"], dataRow7["fontfamily"], dataRow7["fontsize"], dataRow7["fontweight"], dataRow7["fontstyle"], dataRow7["fontcolor"], dataRow7["textdecoration"], dataRow7["textalign"], dataRow7["border"], dataRow7["backgroundcolor"], dataRow7["visibility"], dataRow7["maxlength"], dataRow7["offsetwidth"], dataRow7["offsetheight"], dataRow7["offsettop"], dataRow7["offsetleft"], dataRow7["pixelwidth"], dataRow7["pixelheight"], dataRow7["pixeltop"], dataRow7["lock"], dataRow7["canmove"], dataRow7["canchangefontcolor"], dataRow7["canchangefontsize"], dataRow7["canchangefont"], dataRow7["class"], dataRow7["onmouseoverclass"], dataRow7["objTag"], "y", dataRow7["GroupID"], dataRow7["HGroupID"], dataRow7["isHGroupMain"], dataRow7["AssociatedLabel"], dataRow7["isAutoExpand"], num14.ToString(), dataRow7["Repeat"] };
                                    dataTable.Rows.Add(item);
                                    this.LastItemTopPlusHeight = this.objTop + Convert.ToInt32(dataRow7["height"]);
                                }
                                else if (row7["isDuplicate"].ToString().Trim().ToLower() != "y")
                                {
                                    item = new object[] { dataRow7["TemplateID"], dataRow7["CompanyID"], dataRow7["objID"], dataRow7["objType"], dataRow7["objName"], dataRow7["type"], this.objValueItem, dataRow7["imgsrc"], dataRow7["title"], dataRow7["align"], dataRow7["position"], this.objTop, dataRow7["left"], dataRow7["width"], dataRow7["height"], dataRow7["zindex"], dataRow7["padding"], dataRow7["display"], dataRow7["overflow"], dataRow7["fontfamily"], dataRow7["fontsize"], dataRow7["fontweight"], dataRow7["fontstyle"], dataRow7["fontcolor"], dataRow7["textdecoration"], dataRow7["textalign"], dataRow7["border"], dataRow7["backgroundcolor"], dataRow7["visibility"], dataRow7["maxlength"], dataRow7["offsetwidth"], dataRow7["offsetheight"], dataRow7["offsettop"], dataRow7["offsetleft"], dataRow7["pixelwidth"], dataRow7["pixelheight"], dataRow7["pixeltop"], dataRow7["lock"], dataRow7["canmove"], dataRow7["canchangefontcolor"], dataRow7["canchangefontsize"], dataRow7["canchangefont"], dataRow7["class"], dataRow7["onmouseoverclass"], dataRow7["objTag"], "y", dataRow7["GroupID"], dataRow7["HGroupID"], dataRow7["isHGroupMain"], dataRow7["AssociatedLabel"], dataRow7["isAutoExpand"], num14.ToString(), dataRow7["Repeat"] };
                                    dataTable.Rows.Add(item);
                                    //UpdateOrAddRow(dataTable, "objValue", this.objValueItem, item, lstdeliveryNoteProductTitle, ref isTitleAdded, ref isLine);
                                    this.LastItemTopPlusHeight = this.objTop + Convert.ToInt32(dataRow7["height"]);
                                }
                                else
                                {
                                    if (ConnectionClass.ServerName.Trim().ToLower() == "handyenvelopes" || ConnectionClass.ServerName.Trim().ToLower() == "handyexpress")
                                    {
                                        increasedHeight = (this.TemplateID != (long)304 ? increasedHeight + 84 : increasedHeight + 20);
                                    }
                                    item = new object[] { dataRow7["TemplateID"], dataRow7["CompanyID"], dataRow7["objID"], dataRow7["objType"], dataRow7["objName"], dataRow7["type"], this.objValueItem, dataRow7["imgsrc"], dataRow7["title"], dataRow7["align"], dataRow7["position"], increasedHeight, dataRow7["left"], dataRow7["width"], dataRow7["height"], dataRow7["zindex"], dataRow7["padding"], dataRow7["display"], dataRow7["overflow"], dataRow7["fontfamily"], dataRow7["fontsize"], dataRow7["fontweight"], dataRow7["fontstyle"], dataRow7["fontcolor"], dataRow7["textdecoration"], dataRow7["textalign"], dataRow7["border"], dataRow7["backgroundcolor"], dataRow7["visibility"], dataRow7["maxlength"], dataRow7["offsetwidth"], dataRow7["offsetheight"], dataRow7["offsettop"], dataRow7["offsetleft"], dataRow7["pixelwidth"], dataRow7["pixelheight"], dataRow7["pixeltop"], dataRow7["lock"], dataRow7["canmove"], dataRow7["canchangefontcolor"], dataRow7["canchangefontsize"], dataRow7["canchangefont"], dataRow7["class"], dataRow7["onmouseoverclass"], dataRow7["objTag"], "y", dataRow7["GroupID"], dataRow7["HGroupID"], dataRow7["isHGroupMain"], dataRow7["AssociatedLabel"], dataRow7["isAutoExpand"], num14.ToString(), dataRow7["Repeat"] };
                                    dataTable.Rows.Add(item);
                                }
                            }
                            if (row7["isDuplicate"].ToString().Trim().ToLower() == "y")
                            {
                                num12++;
                            }
                            num11++;
                        }
                        if (num11 > 1)
                        {
                            this.isMUltipleItems = 1;
                        }
                        this.strFinalTotalPrice1ExTax = this.FinalTotalPrice1ExTax;
                        this.strFinalTotalPrice2ExTax = this.FinalTotalPrice2ExTax;
                        this.strFinalTotalPrice3ExTax = this.FinalTotalPrice3ExTax;
                        this.strFinalTotalPrice4ExTax = this.FinalTotalPrice4ExTax;
                        this.strFinalTotalTaxValue1 = this.FinalTotalTaxValue1;
                        this.strFinalTotalTaxValue2 = this.FinalTotalTaxValue2;
                        this.strFinalTotalTaxValue3 = this.FinalTotalTaxValue3;
                        this.strFinalTotalTaxValue4 = this.FinalTotalTaxValue4;
                        this.strFinalTotalQuantity1 = this.FinalTotalQuantity1;
                        this.strFinalTotalQuantity2 = this.FinalTotalQuantity2;
                        this.strFinalTotalQuantity3 = this.FinalTotalQuantity3;
                        this.strFinalTotalQuantity4 = this.FinalTotalQuantity4;
                        this.strFinalTotalProfitMarginPrice1 = this.FinalTotalProfitMarginPrice1;
                        this.strFinalTotalProfitMarginPrice2 = this.FinalTotalProfitMarginPrice2;
                        this.strFinalTotalProfitMarginPrice3 = this.FinalTotalProfitMarginPrice3;
                        this.strFinalTotalProfitMarginPrice4 = this.FinalTotalProfitMarginPrice4;
                        this.strFinalTotalCostPrice1ExMarkup = this.FinalTotalCostPrice1ExMarkup;
                        this.strFinalTotalMarkupPrice1 = this.FinalTotalMarkupPrice1;
                        this.strFinalTotalGrossProfitPrice1 = this.FinalTotalGrossProfitPrice1;
                        this.strFinalTotalGrossProfitPercentage1 = this.FinalTotalGrossProfitPercentage1;
                        this.flagItem = false;
                        this.footerFlag = true;
                    }
                }

                this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = dataTable;
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                foreach (DataRow dataRow12 in dataSet1.Tables[3].Rows)
                {
                    num19 = Convert.ToDecimal(dataRow12["FooterTop"]);
                    num20 = Convert.ToDecimal(dataRow12["LastElementHeight"]);
                }
                this.Session["FooterTop"] = num19;
                this.Session["LastElementHeight"] = num20;
                this.generatePDF(dataTable, this.PDFID, this.FooterSpace, this.HeaderSpace, this.PDFName, num19, num20, 0, 0, this.ImageName, 0, 0, ref Main_RetRefforPDFVisible, ref Main_ArryList_StrFileName, ref Main_RetRefforisFromReport);
                string str29 = this.estimateitemids;
                chrArray = new char[] { ',' };
                string[] strArrays19 = str29.Split(chrArray);
                if (this.PageType.ToLower().Trim().Contains("job"))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(this.EstimateItemID)))
                    {
                        HttpSessionState session = this.Session;
                        string str30 = this.EstimateID.ToString().Trim();
                        long num21 = Convert.ToInt64(this.EstimateItemID);
                        session[string.Concat("Return_JobCardDetails_dtCard", str30, "_", num21.ToString().Trim())] = null;
                        HttpSessionState httpSessionStates = this.Session;
                        string str31 = this.EstimateID.ToString().Trim();
                        num21 = Convert.ToInt64(this.EstimateItemID);
                        httpSessionStates[string.Concat("Return_JobCardDetails_dtQty1", str31, "_", num21.ToString().Trim())] = null;
                        return;
                    }
                    for (int r = 0; r < (int)strArrays19.Length; r++)
                    {
                        if (strArrays19[r].ToString() != "" && strArrays19[r].ToString() != "0")
                        {
                            this.Session[string.Concat("Return_JobCardDetails_dtCard", this.EstimateID.ToString().Trim(), "_", strArrays19[r])] = null;
                            this.Session[string.Concat("Return_JobCardDetails_dtQty1", this.EstimateID.ToString().Trim(), "_", strArrays19[r])] = null;
                        }
                    }
                    return;
                }
            }
        }
    }

    void UpdateOrAddRow(DataTable dt, string columnName, object searchValue, object[] rowData, List<string> lstdeliveryNoteProductTitle, ref bool isTitleAdded, ref bool isLine)
    {
        string itemName = Convert.ToString(rowData[4]);
        if ((Convert.ToString(rowData[6]).Contains("_____") || Convert.ToString(rowData[6]).Contains("hrDiv")
            || Convert.ToString(rowData[6]).Contains("images/items-line.gif")))
        {
            if (!isLine && !isTitleAdded)
            {
                return;
            }
            if (isLine == true)
            {
                isLine = false;
            }
            else
            {
                return;
            }
        }

        if (itemName == "Item Title")
        {
            if (lstdeliveryNoteProductTitle.IndexOf(Convert.ToString(searchValue)) == -1)
            {
                lstdeliveryNoteProductTitle.Add(Convert.ToString(searchValue));
                isTitleAdded = true;
            }
            else
            {
                return;
            }
        }

        if (itemName == "Quantity1" || itemName == "Shipped" || itemName == "Skid" || itemName == "Unit Weight" ||
            itemName == "Line Weight" || itemName == "Product Item Code" || itemName == "Item Notes" ||
            itemName == "Item Packing" || itemName == "Item Terms/Instructions")
        //if (isTitleAdded && (itemName == "Quantity1" || itemName == "Shipped" || itemName == "Unit Weight" ||
        //    itemName == "Line Weight"))
        {
            bool add = false;
            if (isTitleAdded)
            {
                //Update
                add = true;
            }
            else
            {
                //Add 
                add = false;
            }
            //if (isTitleAdded && lstdeliveryNoteProductTitle.IndexOf(Convert.ToString(searchValue)) != -1)
            //{
            int index = -1;
            string productTitle = lstdeliveryNoteProductTitle.FindLast(l => l != string.Empty);
            // Search for existing product title row by product title
            DataRow[] existingRows = dt.Select($"{columnName} = '{productTitle}'");

            int rowsCount = dt.Rows.Count;
            if (existingRows.Length > 0)
            {
                index = dt.Rows.IndexOf(existingRows[0]);
                // Update the existing row
                if (itemName == "Unit Weight")
                {
                    index = index + 1;
                    if ((rowsCount - 1) < index && add)
                    {
                        dt.Rows.Add(rowData);
                        return;
                    }
                    DataRow rowToUpdate = dt.Rows[index];
                    if (rowToUpdate != null)
                    {
                        var existingValue = rowToUpdate[columnName];
                        // Split existing and new value by space and add both value at 0 index and append the lbs
                        var initialValue = searchValue.ToString().Split(' ')[0];
                        var existingValueInt = existingValue.ToString().Split(' ')[0];
                        rowToUpdate[columnName] = Convert.ToString(Convert.ToDecimal(initialValue) + Convert.ToDecimal(existingValueInt))
                            + " " + existingValue.ToString().Split(' ')[1];
                        return;
                    }
                }
                else if (itemName == "Line Weight")
                {
                    index = index + 2;
                    if ((rowsCount - 1) < index && add)
                    {
                        dt.Rows.Add(rowData);
                        return;
                    }
                    DataRow rowToUpdate = dt.Rows[index];
                    if (rowToUpdate != null)
                    {
                        var existingValue = rowToUpdate[columnName];
                        // Split existing and new value by space and add both value at 0 index and append the lbs
                        var initialValue = searchValue.ToString().Split(' ')[0];
                        var existingValueInt = existingValue.ToString().Split(' ')[0];
                        rowToUpdate[columnName] = Convert.ToString(Convert.ToDecimal(initialValue) + Convert.ToDecimal(existingValueInt))
                         + " " + existingValue.ToString().Split(' ')[1];
                        return;
                    }
                }
                else if (itemName == "Quantity1")
                {
                    index = index + 4;
                    if ((rowsCount - 1) < index && add)
                    {
                        dt.Rows.Add(rowData);
                        return;
                    }
                    DataRow rowToUpdate = dt.Rows[index];
                    if (rowToUpdate != null)
                    {
                        var existingValue = rowToUpdate?[columnName];
                        // Split existing and new value by space and add both value at 0 index and append the lbs
                        var initialValue = searchValue.ToString().Split(' ')[0];
                        var existingValueInt = existingValue.ToString().Split(' ')[0];
                        rowToUpdate[columnName] = Convert.ToDecimal(searchValue) + Convert.ToDecimal(existingValue);
                        return;
                    }

                }
                else
                {
                    if (add)
                    {
                        dt.Rows.Add(rowData);
                    }
                }
            }
        }
        else
        {
            dt.Rows.Add(rowData);
        }
        if (itemName == "Item Notes" && Convert.ToString(rowData[6]) == string.Empty && isTitleAdded)
        {
            isTitleAdded = false;
            isLine = true;
        }
    }



    public void LogException(Exception ex)
    {

        //string.Concat(this.SecureDocFilepath, this.ServerName, "/", "exception_log.txt")
        // Define the path to the log file
        string logFilePath = string.Concat(this.SecureDocFilepath, this.ServerName, "/", "exception_log.txt");

        // Open the file in append mode or create it if it doesn't exist
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            // Write the exception details along with timestamp to the file
            writer.WriteLine($"[{DateTime.Now}] Exception: {ex.Message}");
            writer.WriteLine($"StackTrace: {ex.StackTrace}");
            writer.WriteLine();
        }

        Console.WriteLine("Exception logged successfully.");
    }

    static void LogException(string ex)
    {
        // Define the path to the log file
        string logFilePath = "D:\\inetpub\\vhosts\\eprintsoftware.com\\httpdocs\\LiveDocuments\\document\\SecureDoc\\demo\\exception_log.txt";

        // Open the file in append mode or create it if it doesn't exist
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            // Write the exception details along with timestamp to the file
            writer.WriteLine($"[{DateTime.Now}] value: {ex}");
            //writer.WriteLine($"StackTrace: {ex.StackTrace}");
            //writer.WriteLine();
        }

        Console.WriteLine("Exception logged successfully.");
    }


    public string GetSubItemValues(Int64 EstimateItemID)
    {
        DataTable dataTable5 = new DataTable();

        dataTable5 = this.objTemplates.PCR_Template_subitems_select(EstimateItemID, this.PageType);

        StringBuilder subitemtitle = new StringBuilder();
        StringBuilder subitemprice = new StringBuilder();

        foreach (DataRow row8 in dataTable5.Rows)
        {
            DataTable dataTable6 = new DataTable();
            if (Convert.ToInt64(row8["EstimateItemID"]) > (long)0)
            {
                dataTable6 = this.objTemplates.PCR_Template_GetAllDetails_By_EstimateItemID(Convert.ToInt64(row8["EstimateItemID"]), row8["EstimateType"].ToString(), this.EstimateItemID);
                if (dataTable6.Rows.Count > 0)
                {
                    subitemtitle.Append(Convert.ToString(dataTable6.Rows[0]["ItemTitle"])).AppendLine();
                    if (this.objTagItem.Trim().ToLower() == "[subitemprice1]")
                    {
                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty1"]) <= (long)0)
                        {
                        }
                        else
                        {
                            subitemprice.Append(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal1"]), 0, "", false, false, true), true)).AppendLine();
                        }
                    }
                    if (this.objTagItem.Trim().ToLower() == "[subitemprice2]")
                    {
                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty2"]) <= (long)0)
                        {

                        }
                        else
                        {
                            subitemprice.Append(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal2"]), 0, "", false, false, true), true)).AppendLine();
                        }
                    }
                    if (this.objTagItem.Trim().ToLower() == "[subitemprice3]")
                    {
                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty3"]) <= (long)0)
                        {

                        }
                        else
                        {
                            subitemprice.Append(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal3"]), 0, "", false, false, true), true)).AppendLine();
                        }
                    }
                    if (this.objTagItem.Trim().ToLower() == "[subitemprice4]")
                    {
                        if (Convert.ToInt64(dataTable6.Rows[0]["TotalQty4"]) <= (long)0)
                        {

                        }
                        else
                        {
                            subitemprice.Append(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable6.Rows[0]["TotalSubTotal4"]), 0, "", false, false, true), true)).AppendLine();
                        }
                    }


                }
            }

        }
        string result = string.Empty;
        if (this.PageType.ToLower() == "estimate" || (this.PageType.ToLower() == "job"))
        {
            this.objValue = this.objValue.Replace("[SubItemTitle]", Convert.ToString(subitemtitle));
            this.objValue = this.objValue.Replace("[SubItemPrice1]", Convert.ToString(subitemprice));
            result = this.objValue;
        }
        else
        {
            this.objValueItem = this.objValueItem.Replace("[SubItemTitle]", Convert.ToString(subitemtitle));
            this.objValueItem = this.objValueItem.Replace("[SubItemPrice1]", Convert.ToString(subitemprice));
            result = this.objValueItem;
        }


        return result;

    }

    private DataTable RepeatControls(DataTable dt, int TotalPages)
    {
        DataTable dataTable = new DataTable("Repeat");
        dataTable = dt.Copy();
        DataRow[] dataRowArray = dt.Select("Repeat='true'");
        for (int i = 0; i < (int)dataRowArray.Length; i++)
        {
            DataRow dataRow = dataRowArray[i];
            for (int j = 1; j <= TotalPages; j++)
            {
                DataRow dataRow1 = dataRow;
                dataRow1["pagenumber"] = j;
                dataTable.ImportRow(dataRow1);
            }
        }
        dataTable.DefaultView.Sort = "pagenumber asc";
        return dataTable.DefaultView.ToTable();
    }

    public string ReplaceBreak(string ToReplace)
    {
        return ToReplace;
    }

    private string Return_ArtWorkDateDetails(string objVal, int EstID, string PageType)
    {
        if (objVal.IndexOf('[') > -1)
        {
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
            SqlCommand sqlCommand = new SqlCommand("pc_artwork_detail_select_fortemplate");
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.Add("@EstimateID", EstID);
            sqlCommand.Parameters.Add("@JobID", this.jobID);
            sqlCommand.Parameters.Add("@PageType", PageType.ToLower());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            sqlConnection.Close();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                objVal = objVal.Replace("[EstimatedArtworkDate]", this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedProofDate]", this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedApprovalDate]", this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedProductionDate]", this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedCompletionDate]", this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedDeliveryDate]", this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualArtworkDate]", this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualProofDate]", this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualApprovalDate]", this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualProductionDate]", this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualCompletionDate]", this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualDeliveryDate]", this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false));


                objVal = objVal.Replace("[EstimatedArtworkDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false), row["ArtworkDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProofDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false), row["ProofDate"].ToString()));
                objVal = objVal.Replace("[EstimatedApprovedDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false), row["ApprovalDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProductionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false), row["ProductionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedCompletionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false), row["CompletionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedDeliveryDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), row["DeliveryDate"].ToString()));
                objVal = objVal.Replace("[ActualArtworkDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false), row["ArtworkDate"].ToString()));
                objVal = objVal.Replace("[ActualProofDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false), row["ProofDate"].ToString()));
                objVal = objVal.Replace("[ActualApprovalDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false), row["ApprovalDate"].ToString()));
                objVal = objVal.Replace("[ActualProductionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false), row["ProductionDate"].ToString()));
                objVal = objVal.Replace("[ActualCompletionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false), row["CompletionDate"].ToString()));
                objVal = objVal.Replace("[ActualDeliveryDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), row["DeliveryDate"].ToString()));

                objVal = objVal.Replace("[EstimatedArtworkDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false), row["ArtworkDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProofDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false), row["ProofDate"].ToString()));
                objVal = objVal.Replace("[EstimatedApprovedDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false), row["ApprovalDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProductionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false), row["ProductionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedCompletionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false), row["CompletionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedDeliveryDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), row["DeliveryDate"].ToString()));
                objVal = objVal.Replace("[ActualArtworkDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), this.CompanyID, this.UserID, false), row["ArtworkDate"].ToString()));
                objVal = objVal.Replace("[ActualProofDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), this.CompanyID, this.UserID, false), row["ProofDate"].ToString()));
                objVal = objVal.Replace("[ActualApprovalDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), this.CompanyID, this.UserID, false), row["ApprovalDate"].ToString()));
                objVal = objVal.Replace("[ActualProductionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), this.CompanyID, this.UserID, false), row["ProductionDate"].ToString()));
                objVal = objVal.Replace("[ActualCompletionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, this.UserID, false), row["CompletionDate"].ToString()));
                objVal = objVal.Replace("[ActualDeliveryDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), row["DeliveryDate"].ToString()));
            }
        }
        return objVal;
    }

    private string Return_CostPerUnit(string objValueItem, decimal COstExMarkup, decimal Quantity)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            decimal num = new decimal(0);
            if (Quantity > new decimal(0))
            {
                num = COstExMarkup / Quantity;
            }
            objValueItem = objValueItem.Replace("[CostPerUnit]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true), true));
        }
        return objValueItem;
    }
    private string Return_EstoreAddition(string objValueItem, long EstItemID)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            DataTable item = OrderBasePage.Select_OrderItems_WithAdditionalItems(EstItemID).Tables[1];
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (DataRow row in item.Rows)
            {
                stringBuilder2.Append(string.Concat(row["eStoreAdditionalOptionSelectedValue"].ToString(), "\n"));
                stringBuilder.Append(string.Concat(row["webothercostName"].ToString(), ": ", row["SelectedValue"].ToString(), "\n"));
                stringBuilder1.Append(string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalPrice"]), 0, "", false, false, true), true), "\n"));
            }
            if (item.Rows.Count > 0)
            {
                objValueItem = objValueItem.Replace("[eStoreAdditionalOptionValue]", string.Concat("\n", stringBuilder2.ToString()));
                objValueItem = objValueItem.Replace("[eStoreAdditionalOptionName]", string.Concat("\n", stringBuilder.ToString()));
                objValueItem = objValueItem.Replace("[eStoreAdditionalOptionPrice]", string.Concat("\n", stringBuilder1.ToString()));
            }
            else if (objValueItem.Contains("[eStoreAdditionalOptionName]") || objValueItem.Contains("[eStoreAdditionalOptionPrice]") || objValueItem.Contains("[eStoreAdditionalOptionValue]"))
            {
                objValueItem = objValueItem.Replace(objValueItem, "");
            }
        }
        return objValueItem;
    }
    //Ticket #8063 Multi Mail - delivery note number field showing multiple numbers
    // Get Item description by deliveryid 
    private string Return_ItemDescriptionByDeliveyId(string objValueItem, long estItemID, string deliveryId)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            // DataTable dataTable = this.objJava.Select_itemDescriptions((long)this.CompanyID, estItemID);
            DataTable dataTable = this.objJava.Select_itemDescriptionsByDeliveryId((long)this.CompanyID, estItemID, deliveryId);
            if (dataTable.Rows.Count > 0)
            {
                if (this.PageType.ToLower() == "webstoreorder" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice")
                {
                    objValueItem = objValueItem.Replace("[EventName]", dataTable.Rows[0]["EventName"].ToString());
                    objValueItem = objValueItem.Replace("[EventCodeNumber]", dataTable.Rows[0]["EventCodeNumber"].ToString());
                    objValueItem = objValueItem.Replace("[EventName]", dataTable.Rows[0]["EventName"].ToString());
                    objValueItem = objValueItem.Replace("[CampaignSignNumber]", dataTable.Rows[0]["CampaignSignNumber"].ToString());
                    objValueItem = objValueItem.Replace("[EventVenue]", dataTable.Rows[0]["EventVenue"].ToString());
                }
                objValueItem = objValueItem.Replace("[EstimateNumber]", dataTable.Rows[0]["EstimateNumber"].ToString());
                objValueItem = objValueItem.Replace("[JobNumber]", dataTable.Rows[0]["JobNumber"].ToString());
                objValueItem = objValueItem.Replace("[InvoiceNumber]", dataTable.Rows[0]["InvoiceNumber"].ToString());
                objValueItem = objValueItem.Replace("[OrderNumber]", dataTable.Rows[0]["OrderNumber"].ToString());
                objValueItem = objValueItem.Replace("[DeliveryNumber]", dataTable.Rows[0]["DeliveryNumber"].ToString());
                objValueItem = objValueItem.Replace("[EstimateNumberWithoutPrefix]", dataTable.Rows[0]["EstimateItemNumberwithoutprifix"].ToString());
                objValueItem = objValueItem.Replace("[JobItemTitle]", dataTable.Rows[0]["ItemTitleValue"].ToString());
                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemTitleTemplate"]) && dataTable.Rows[0]["ItemTitleValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemTitleLabel]", dataTable.Rows[0]["ItemTitleLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemTitle]", dataTable.Rows[0]["ItemTitleValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsDescriptionTemplate"]) && dataTable.Rows[0]["DescriptionValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemDescriptionLabel]", dataTable.Rows[0]["DescriptionLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemDescription]", dataTable.Rows[0]["DescriptionValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsArtworkTemplate"]) && dataTable.Rows[0]["ArtworkValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemArtworkLabel]", dataTable.Rows[0]["ArtworkLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemArtwork]", dataTable.Rows[0]["ArtworkValue"].ToString());
                }
                if (dataTable.Rows[0]["ArtWorkFiles"].ToString().Trim().Length <= 0)
                {
                    objValueItem = objValueItem.Replace("[ArtWorkFiles]", "");
                }
                else
                {
                    objValueItem = objValueItem.Replace("[ArtWorkFiles]", dataTable.Rows[0]["ArtWorkFiles"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsColourTemplate"]) && dataTable.Rows[0]["ColourValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemColourLabel]", dataTable.Rows[0]["ColourLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemColour]", dataTable.Rows[0]["ColourValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsSizeTemplate"]) && dataTable.Rows[0]["SizeValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemSizeLabel]", dataTable.Rows[0]["SizeLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemSize]", dataTable.Rows[0]["SizeValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsMaterialTemplate"]) && dataTable.Rows[0]["MaterialValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemMaterialLabel]", dataTable.Rows[0]["MaterialLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemMaterial]", dataTable.Rows[0]["MaterialValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsDeliveryTemplate"]) && dataTable.Rows[0]["DeliveryValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemDeliveryLabel]", dataTable.Rows[0]["DeliveryLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemDelivery]", dataTable.Rows[0]["DeliveryValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsFinishingTemplate"]) && dataTable.Rows[0]["FinishingValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemFinishingLabel]", dataTable.Rows[0]["FinishingLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemFinishing]", dataTable.Rows[0]["FinishingValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsProofsTemplate"]) && dataTable.Rows[0]["ProofsValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemProofsLabel]", dataTable.Rows[0]["ProofsLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemProofs]", dataTable.Rows[0]["ProofsValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsPackingTemplate"]) && dataTable.Rows[0]["PackingValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemPackingLabel]", dataTable.Rows[0]["PackingLabel"].ToString());
                    //objValueItem = objValueItem.Replace("[ItemPacking]", dataTable.Rows[0]["PackingValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsNotesTemplate"]) && dataTable.Rows[0]["NotesValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemNotesLabel]", dataTable.Rows[0]["NotesLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemNotes]", dataTable.Rows[0]["NotesValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsInstructionsTemplate"]) && dataTable.Rows[0]["InstructionsValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemTerms/InstructionsLabel]", dataTable.Rows[0]["InstructionsLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemTerms/Instructions]", dataTable.Rows[0]["InstructionsValue"].ToString());
                }

                // JobQuantityDescription1
                if (dataTable.Rows[0]["JobQuantityDescription1"].ToString().Trim().Length <= 0)
                {
                    objValueItem = objValueItem.Replace("[JobQuantityDescription1]", "");
                }
                else
                {
                    objValueItem = objValueItem.Replace("[JobQuantityDescription1]", dataTable.Rows[0]["JobQuantityDescription1"].ToString());
                }

                for (int i = 1; i < 26; i++)
                {
                    if (Convert.ToBoolean(dataTable.Rows[0][string.Concat("isCustomDescription", i.ToString(), "Template")]) && dataTable.Rows[0][string.Concat("CustomDescriptionValue", i.ToString())].ToString().Trim().Length > 0)
                    {
                        objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", i.ToString(), "Label]"), dataTable.Rows[0][string.Concat("CustomDescriptionLabel", i.ToString())].ToString());
                        objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", i.ToString(), "]"), dataTable.Rows[0][string.Concat("CustomDescriptionValue", i.ToString())].ToString());
                    }
                }
            }
            if (objValueItem.Contains("[ItemTitleLabel]") || objValueItem.Contains("[ItemDescriptionLabel]") || objValueItem.Contains("[ItemArtworkLabel]") || objValueItem.Contains("[ItemColourLabel]") || objValueItem.Contains("[ItemSizeLabel]") || objValueItem.Contains("[ItemMaterialLabel]") || objValueItem.Contains("[ItemDeliveryLabel]") || objValueItem.Contains("[ItemFinishingLabel]") || objValueItem.Contains("[ItemProofsLabel]") || objValueItem.Contains("[ItemPackingLabel]") || objValueItem.Contains("[ItemNotesLabel]") || objValueItem.Contains("[ItemTerms/InstructionsLabel]") || objValueItem.Contains("[CustomDescription1Label]") || objValueItem.Contains("[CustomDescription2Label]") || objValueItem.Contains("[CustomDescription3Label]") || objValueItem.Contains("[CustomDescription4Label]") || objValueItem.Contains("[CustomDescription5Label]") || objValueItem.Contains("[CustomDescription6Label]") || objValueItem.Contains("[CustomDescription7Label]") || objValueItem.Contains("[CustomDescription8Label]") || objValueItem.Contains("[CustomDescription9Label]") || objValueItem.Contains("[CustomDescription10Label]") || objValueItem.Contains("[CustomDescription11Label]") || objValueItem.Contains("[CustomDescription12Label]") || objValueItem.Contains("[CustomDescription13Label]") || objValueItem.Contains("[CustomDescription14Label]") || objValueItem.Contains("[CustomDescription15Label]") || objValueItem.Contains("[CustomDescription16Label]") || objValueItem.Contains("[CustomDescription17Label]") || objValueItem.Contains("[CustomDescription18Label]") || objValueItem.Contains("[CustomDescription19Label]") || objValueItem.Contains("[CustomDescription20Label]") || objValueItem.Contains("[CustomDescription21Label]") || objValueItem.Contains("[CustomDescription22Label]") || objValueItem.Contains("[CustomDescription23Label]") || objValueItem.Contains("[CustomDescription24Label]") || objValueItem.Contains("[CustomDescription25Label]") || objValueItem.Contains("[ItemTitle]") || objValueItem.Contains("[ItemDescription]") || objValueItem.Contains("[ItemArtwork]") || objValueItem.Contains("[ItemColour]") || objValueItem.Contains("[ItemSize]") || objValueItem.Contains("[ItemMaterial]") || objValueItem.Contains("[ItemDelivery]") || objValueItem.Contains("[ItemFinishing]") || objValueItem.Contains("[ItemProofs]") || objValueItem.Contains("[ItemPacking]") || objValueItem.Contains("[ItemNotes]") || objValueItem.Contains("[ItemTerms/Instructions]") || objValueItem.Contains("[CustomDescription1]") || objValueItem.Contains("[CustomDescription2]") || objValueItem.Contains("[CustomDescription3]") || objValueItem.Contains("[CustomDescription4]") || objValueItem.Contains("[CustomDescription5]") || objValueItem.Contains("[CustomDescription6]") || objValueItem.Contains("[CustomDescription7]") || objValueItem.Contains("[CustomDescription8]") || objValueItem.Contains("[CustomDescription9]") || objValueItem.Contains("[CustomDescription10]") || objValueItem.Contains("[CustomDescription11]") || objValueItem.Contains("[CustomDescription12]") || objValueItem.Contains("[CustomDescription13]") || objValueItem.Contains("[CustomDescription14]") || objValueItem.Contains("[CustomDescription15]") || objValueItem.Contains("[CustomDescription16]") || objValueItem.Contains("[CustomDescription17]") || objValueItem.Contains("[CustomDescription18]") || objValueItem.Contains("[CustomDescription19]") || objValueItem.Contains("[CustomDescription20]") || objValueItem.Contains("[CustomDescription21]") || objValueItem.Contains("[CustomDescription22]") || objValueItem.Contains("[CustomDescription23]") || objValueItem.Contains("[CustomDescription24]") || objValueItem.Contains("[CustomDescription25]") || objValueItem.Contains("[EventName]") || objValueItem.Contains("[CostPrice1(InMarkup)]"))
            {
                objValueItem = "";
            }
        }
        return objValueItem;
    }

    private string Return_ItemDescription(string objValueItem, long estItemID)
    {
        object[] item;
        if (objValueItem.IndexOf('[') > -1)
        {
            DataTable dataTable = this.objJava.Select_itemDescriptions((long)this.CompanyID, estItemID);
            if (dataTable.Rows.Count > 0)
            {
                if (this.PageType.ToLower() == "webstoreorder" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "invoice")
                {
                    objValueItem = objValueItem.Replace("[EventName]", dataTable.Rows[0]["EventName"].ToString());
                    objValueItem = objValueItem.Replace("[EventCodeNumber]", dataTable.Rows[0]["EventCodeNumber"].ToString());
                    objValueItem = objValueItem.Replace("[EventName]", dataTable.Rows[0]["EventName"].ToString());
                    objValueItem = objValueItem.Replace("[CampaignSignNumber]", dataTable.Rows[0]["CampaignSignNumber"].ToString());
                    objValueItem = objValueItem.Replace("[EventVenue]", dataTable.Rows[0]["EventVenue"].ToString());
                }
                if (this.PageType.ToLower() == "estimate" || this.PageType.ToLower() == "job")
                {
                    if (objValueItem.Contains("[JobEstFile]"))
                    {

                        objValueItem = objValueItem.Replace("[JobEstFile]", dataTable.Rows[0]["JobEstFile"].ToString());
                    }
                }
                if (objValueItem.Contains("[EstItemNo]"))
                {
                    objValueItem = objValueItem.Replace("[EstItemNo]", dataTable.Rows[0]["EstimateItemNo"].ToString());
                }
                if (objValueItem.Contains("[PressName]"))
                {
                    objValueItem = Job_PaperPressGuillotineItem_Costs_Select(objValueItem, this.CompanyID, Convert.ToInt64(dataTable.Rows[0]["EstimateItemid"]), dataTable.Rows[0]["Estimatetype"].ToString());
                }
                objValueItem = objValueItem.Replace("[EstimateNumber]", dataTable.Rows[0]["EstimateNumber"].ToString());
                //   objValueItem = objValueItem.Replace("[EstItemNo]", dataTable.Rows[0]["EstItemNo"].ToString());
                objValueItem = objValueItem.Replace("[JobNumber]", dataTable.Rows[0]["JobNumber"].ToString());
                objValueItem = objValueItem.Replace("[InvoiceNumber]", dataTable.Rows[0]["InvoiceNumber"].ToString());
                objValueItem = objValueItem.Replace("[OrderNumber]", dataTable.Rows[0]["OrderNumber"].ToString());
                objValueItem = objValueItem.Replace("[DeliveryNumber]", dataTable.Rows[0]["DeliveryNumber"].ToString());
                objValueItem = objValueItem.Replace("[EstimateNumberWithoutPrefix]", dataTable.Rows[0]["EstimateItemNumberwithoutprifix"].ToString());
                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemTitleTemplate"]) && dataTable.Rows[0]["ItemTitleValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemTitleLabel]", dataTable.Rows[0]["ItemTitleLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemTitle]", dataTable.Rows[0]["ItemTitleValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsDescriptionTemplate"]) && dataTable.Rows[0]["DescriptionValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemDescriptionLabel]", dataTable.Rows[0]["DescriptionLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemDescription]", dataTable.Rows[0]["DescriptionValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsArtworkTemplate"]) && dataTable.Rows[0]["ArtworkValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemArtworkLabel]", dataTable.Rows[0]["ArtworkLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemArtwork]", dataTable.Rows[0]["ArtworkValue"].ToString());
                }
                if (dataTable.Rows[0]["ArtWorkFiles"].ToString().Trim().Length <= 0)
                {
                    objValueItem = objValueItem.Replace("[ArtWorkFiles]", "");
                }
                else
                {
                    objValueItem = objValueItem.Replace("[ArtWorkFiles]", dataTable.Rows[0]["ArtWorkFiles"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsColourTemplate"]) && dataTable.Rows[0]["ColourValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemColourLabel]", dataTable.Rows[0]["ColourLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemColour]", dataTable.Rows[0]["ColourValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsSizeTemplate"]) && dataTable.Rows[0]["SizeValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemSizeLabel]", dataTable.Rows[0]["SizeLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemSize]", dataTable.Rows[0]["SizeValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsMaterialTemplate"]) && dataTable.Rows[0]["MaterialValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemMaterialLabel]", dataTable.Rows[0]["MaterialLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemMaterial]", dataTable.Rows[0]["MaterialValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsDeliveryTemplate"]) && dataTable.Rows[0]["DeliveryValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemDeliveryLabel]", dataTable.Rows[0]["DeliveryLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemDelivery]", dataTable.Rows[0]["DeliveryValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsFinishingTemplate"]) && dataTable.Rows[0]["FinishingValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemFinishingLabel]", dataTable.Rows[0]["FinishingLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemFinishing]", dataTable.Rows[0]["FinishingValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsProofsTemplate"]) && dataTable.Rows[0]["ProofsValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemProofsLabel]", dataTable.Rows[0]["ProofsLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemProofs]", dataTable.Rows[0]["ProofsValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsPackingTemplate"]) && dataTable.Rows[0]["PackingValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemPackingLabel]", dataTable.Rows[0]["PackingLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemPacking]", dataTable.Rows[0]["PackingValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsNotesTemplate"]) && dataTable.Rows[0]["NotesValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemNotesLabel]", dataTable.Rows[0]["NotesLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemNotes]", dataTable.Rows[0]["NotesValue"].ToString());
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsInstructionsTemplate"]) && dataTable.Rows[0]["InstructionsValue"].ToString().Trim().Length > 0)
                {
                    objValueItem = objValueItem.Replace("[ItemTerms/InstructionsLabel]", dataTable.Rows[0]["InstructionsLabel"].ToString());
                    objValueItem = objValueItem.Replace("[ItemTerms/Instructions]", dataTable.Rows[0]["InstructionsValue"].ToString());
                }
                for (int i = 1; i < 26; i++)
                {
                    if (Convert.ToBoolean(dataTable.Rows[0][string.Concat("isCustomDescription", i.ToString(), "Template")]) && dataTable.Rows[0][string.Concat("CustomDescriptionValue", i.ToString())].ToString().Trim().Length > 0)
                    {
                        objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", i.ToString(), "Label]"), dataTable.Rows[0][string.Concat("CustomDescriptionLabel", i.ToString())].ToString());
                        objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", i.ToString(), "]"), dataTable.Rows[0][string.Concat("CustomDescriptionValue", i.ToString())].ToString());
                    }
                }
            }
            if (objValueItem.Contains("[ItemTitleLabel]") || objValueItem.Contains("[ItemDescriptionLabel]") || objValueItem.Contains("[ItemArtworkLabel]") || objValueItem.Contains("[ItemColourLabel]") || objValueItem.Contains("[ItemSizeLabel]") || objValueItem.Contains("[ItemMaterialLabel]") || objValueItem.Contains("[ItemDeliveryLabel]") || objValueItem.Contains("[ItemFinishingLabel]") || objValueItem.Contains("[ItemProofsLabel]") || objValueItem.Contains("[ItemPackingLabel]") || objValueItem.Contains("[ItemNotesLabel]") || objValueItem.Contains("[ItemTerms/InstructionsLabel]") || objValueItem.Contains("[CustomDescription1Label]") || objValueItem.Contains("[CustomDescription2Label]") || objValueItem.Contains("[CustomDescription3Label]") || objValueItem.Contains("[CustomDescription4Label]") || objValueItem.Contains("[CustomDescription5Label]") || objValueItem.Contains("[CustomDescription6Label]") || objValueItem.Contains("[CustomDescription7Label]") || objValueItem.Contains("[CustomDescription8Label]") || objValueItem.Contains("[CustomDescription9Label]") || objValueItem.Contains("[CustomDescription10Label]") || objValueItem.Contains("[CustomDescription11Label]") || objValueItem.Contains("[CustomDescription12Label]") || objValueItem.Contains("[CustomDescription13Label]") || objValueItem.Contains("[CustomDescription14Label]") || objValueItem.Contains("[CustomDescription15Label]") || objValueItem.Contains("[CustomDescription16Label]") || objValueItem.Contains("[CustomDescription17Label]") || objValueItem.Contains("[CustomDescription18Label]") || objValueItem.Contains("[CustomDescription19Label]") || objValueItem.Contains("[CustomDescription20Label]") || objValueItem.Contains("[CustomDescription21Label]") || objValueItem.Contains("[CustomDescription22Label]") || objValueItem.Contains("[CustomDescription23Label]") || objValueItem.Contains("[CustomDescription24Label]") || objValueItem.Contains("[CustomDescription25Label]") || objValueItem.Contains("[ItemTitle]") || objValueItem.Contains("[ItemDescription]") || objValueItem.Contains("[ItemArtwork]") || objValueItem.Contains("[ItemColour]") || objValueItem.Contains("[ItemSize]") || objValueItem.Contains("[ItemMaterial]") || objValueItem.Contains("[ItemDelivery]") || objValueItem.Contains("[ItemFinishing]") || objValueItem.Contains("[ItemProofs]") || objValueItem.Contains("[ItemPacking]") || objValueItem.Contains("[ItemNotes]") || objValueItem.Contains("[ItemTerms/Instructions]") || objValueItem.Contains("[CustomDescription1]") || objValueItem.Contains("[CustomDescription2]") || objValueItem.Contains("[CustomDescription3]") || objValueItem.Contains("[CustomDescription4]") || objValueItem.Contains("[CustomDescription5]") || objValueItem.Contains("[CustomDescription6]") || objValueItem.Contains("[CustomDescription7]") || objValueItem.Contains("[CustomDescription8]") || objValueItem.Contains("[CustomDescription9]") || objValueItem.Contains("[CustomDescription10]") || objValueItem.Contains("[CustomDescription11]") || objValueItem.Contains("[CustomDescription12]") || objValueItem.Contains("[CustomDescription13]") || objValueItem.Contains("[CustomDescription14]") || objValueItem.Contains("[CustomDescription15]") || objValueItem.Contains("[CustomDescription16]") || objValueItem.Contains("[CustomDescription17]") || objValueItem.Contains("[CustomDescription18]") || objValueItem.Contains("[CustomDescription19]") || objValueItem.Contains("[CustomDescription20]") || objValueItem.Contains("[CustomDescription21]") || objValueItem.Contains("[CustomDescription22]") || objValueItem.Contains("[CustomDescription23]") || objValueItem.Contains("[CustomDescription24]") || objValueItem.Contains("[CustomDescription25]") || objValueItem.Contains("[EventName]") || objValueItem.Contains("[CostPrice1(InMarkup)]"))
            {
                objValueItem = "";
            }
        }
        return objValueItem;
    }

    // Ticket #9300 System template tags required
    private string Return_ProductSubitem_Details(string objValueItem, string estItemIDs)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            StringBuilder productSubitemDetails = new StringBuilder();
            StringBuilder subitemwidth = new StringBuilder();
            StringBuilder subitemheight = new StringBuilder();
            StringBuilder finalQuantity = new StringBuilder();

            decimal width, height;
            int subitemquantity = 0;
            string[] estimateItemIds = estItemIDs.Split(new char[] { ',' });
            for (int n = 0; n < (int)estimateItemIds.Length; n++)
            {
                int estimateItemId = 0;
                if (Convert.ToString(estimateItemIds[n]) != string.Empty)
                {
                    estimateItemId = Convert.ToInt32(estimateItemIds[n]);
                }
                else
                {
                    break;
                }

                DataTable dataTable = this.objJava.Select_ProductSubitem_Details((long)this.CompanyID, estimateItemId);
                if (dataTable.Rows.Count > 0)
                {
                    string itemtitle = string.Empty;
                    string itemdescription = string.Empty;
                    width = Convert.ToDecimal(dataTable.Rows[0]["Width"]);
                    subitemwidth.Append(String.Format("{0:0.00}", width)).AppendLine();
                    height = Convert.ToDecimal(dataTable.Rows[0]["Height"]);
                    subitemheight.Append(String.Format("{0:0.00}", height)).AppendLine();

                    subitemquantity = Convert.ToInt32(dataTable.Rows[0]["Quantity"]);
                    finalQuantity.Append(subitemquantity).AppendLine();

                    itemdescription = Convert.ToString(dataTable.Rows[0]["ItemDescription"]);
                    itemdescription = itemdescription.Replace("%27", "'");
                    itemdescription = itemdescription.Replace("%22", "\"");

                    // item description splitting
                    if (itemdescription.Trim().Length > 0)
                    {
                        string[] strArrays1 = itemdescription.ToString().Split(new char[] { 'µ' });
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            string[] strArrays2 = strArrays1[i].ToString().Split(new char[] { '»' });
                            if ((int)strArrays2.Length > 3)
                            {
                                if (string.Compare(strArrays2[0], "ItemTitle", true) == 0)
                                {
                                    //if (strArrays2[2].ToString().Trim().Length > 0 && !objItems.ItemTitle.Contains("<br/>"))
                                    //{
                                    //    objItems.ItemTitle = strArrays2[2].ToString().Replace("\r\n", "<br/>");
                                    //}
                                    productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                }
                                else if (string.Compare(strArrays2[0], "Description", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Description = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Artwork", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Artwork = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Colour", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Colour = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Size", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Size = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Material", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Material = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Delivery", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Delivery = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Finishing", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Finishing = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Proofs", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Proofs = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Packing", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Packing = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Notes", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Notes = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Instructions", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.Instructions = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 1", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription1 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 2", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription2 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 3", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription3 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 4", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription4 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 5", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription5 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 6", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription6 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 7", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription7 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 8", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription8 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 9", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription9 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 10", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription10 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 11", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription11 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 12", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription12 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 13", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription13 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 14", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription14 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 15", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription15 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 16", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription16 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 17", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription17 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 18", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription18 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 19", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription19 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 20", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription20 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 21", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription21 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 22", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription22 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 23", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription23 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 24", true) == 0)
                                {
                                    if (strArrays2[2].ToString().Trim().Length > 0)
                                    {
                                        //objItems.CustomDescription24 = strArrays2[2].ToString();
                                        productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "Custom Description 25", true) == 0 && strArrays2[2].ToString().Trim().Length > 0)
                                {
                                    //objItems.CustomDescription25 = strArrays2[2].ToString();
                                    productSubitemDetails.Append(strArrays2[1].ToString() + ": " + strArrays2[2].ToString()).AppendLine();
                                }
                            }
                        }
                    }

                }// end of if statement datatable rows count

            }// end of loop to get estimatItemId

            objValueItem = objValueItem.Replace("[ProductSubitem]", productSubitemDetails.ToString());
            objValueItem = objValueItem.Replace("[ProductSubitemWidth]", String.Format("{0:0.00}", subitemwidth));
            objValueItem = objValueItem.Replace("[ProductSubitemHeight]", String.Format("{0:0.00}", subitemheight));

            objValueItem = objValueItem.Replace("[SubItemQuantity]", Convert.ToString(finalQuantity));
        }

        return objValueItem;
    }
    private string Return_SubItemAdditionaloptions_Details(string objValueItem, string estItemIDs)
    {
        if (objValueItem.IndexOf('[') > -1)
        {

            string itemdescription = string.Empty;
            string[] estimateItemIds = estItemIDs.Split(new char[] { ',' });
            for (int n = 0; n < (int)estimateItemIds.Length; n++)
            {
                int estimateItemId = 0;
                if (Convert.ToString(estimateItemIds[n]) != string.Empty)
                {
                    estimateItemId = Convert.ToInt32(estimateItemIds[n]);
                }
                else
                {
                    break;
                }

                DataTable dataTable = this.objJava.Select_ProductSubitem_Details((long)this.CompanyID, estimateItemId);
                if (dataTable.Rows.Count > 0)
                {
                    itemdescription = string.Empty;
                    var data = dataTable.Rows[0]["SubItemAdditionaloptions"].ToString().Split('¶');
                    foreach (var item in data)
                    {
                        itemdescription = itemdescription + item + Environment.NewLine;
                    }




                    itemdescription = itemdescription.Replace("%27", "'");
                    itemdescription = itemdescription.Replace("%22", "\"");

                    // item description splitting


                }// end of if statement datatable rows count

            }// end of loop to get estimatItemId

            objValueItem = objValueItem.Replace("[subitemadditionaloptions]", itemdescription.ToString());


        }

        return objValueItem;
    }

    public string Job_ProductSubitem_EstimateItemIds_select(string objVal, long estimateitemid)
    {
        // string objVal = string.Empty;
        DataTable dataTable = this.objJava.Job_ProductSubitem_EstimateItemIds_select((long)this.jobID, (long)this.EstimateID, estimateitemid);
        // for each loop to get item ids passs these item ids 
        if (dataTable.Rows.Count > 0)
        {
            string estimateItemId = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                estimateItemId += Convert.ToString(dataTable.Rows[i]["EstimateItemID"]) + " ,";
            }
            if (objVal == "[subitemadditionaloptions]")
            {
                objVal = this.Return_SubItemAdditionaloptions_Details(objVal, estimateItemId);

            }
            else
            {
                objVal = this.Return_ProductSubitem_Details(objVal, estimateItemId);
            }

        }
        else
        {
            objVal = objVal.Replace("[ProductSubitem]", "");
            objVal = objVal.Replace("[ProductSubitemWidth]", "");
            objVal = objVal.Replace("[ProductSubitemHeight]", "");
            objVal = objVal.Replace("[subitemadditionaloptions]", "");

            objVal = objVal.Replace("[SubItemQuantity]", "");
        }

        return objVal;
    }

    // Ticket #9188 added new job template tags PaperCost, PressCost , Guillotine and AdditionalItemCost  
    public string Job_PaperPressGuillotineItem_Costs_Select(string objVal, int companyId, long estiateItemId, string estimatetype)
    {
        if (objVal.IndexOf("[") > -1)
        {

            //switch (estimatetype)
            //{
            //    case "S": // Sheet Fed Digital Single estimate_single_item_select
            decimal PaperCostExMarkup1, PaperCostExMarkup2, PaperCostExMarkup3, PaperCostExMarkup4,
                       PaperMarkupPrice1, PaperMarkupPrice2, PaperMarkupPrice3,
                        PressCostExMarkup1, PressMarkupPrice1,
                       PaperMarkupPrice4, PaperCostInMarkup2, PaperCostInMarkup3, PaperCostInMarkup4,
                       PressCostExMarkup2, PressCostExMarkup3, PressCostExMarkup4,
                       PressMarkupPrice2, PressMarkupPrice3, PressMarkupPrice4, PressCostInMarkup2, PressCostInMarkup3, PressCostInMarkup4,
                        GuillotineCostExMarkup1, GuillotineMarkupPrice1,
                        GuillotineCostExMarkup2, GuillotineCostExMarkup3, GuillotineCostExMarkup4, GuillotineMarkupPrice2, GuillotineMarkupPrice3, GuillotineMarkupPrice4, GuillotineCostInMarkup2, GuillotineCostInMarkup3, GuillotineCostInMarkup4;
            //string doubleSidedLayout = "";

            string PressName = "";
            decimal PaperCostInMarkup1 = new decimal(0);
            decimal PressCostInMarkup1 = new decimal(0);
            decimal GuillotineCostInMarkup1 = new decimal(0);
            decimal[] paperCostInMarkup1 = new decimal[4];
            decimal[] pressCostInMarkup1 = new decimal[4];
            decimal[] guillotineCostInMarkup1 = new decimal[4];

            DataTable dataTable = this.objJava.Job_PaperPressGuillotineItem_Costs_Details((int)companyId, (long)estiateItemId, estimatetype);


            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    PaperCostExMarkup1 = Convert.ToDecimal(row["PaperCostExMarkup1"]);
                    PaperCostExMarkup2 = Convert.ToDecimal(row["PaperCostExMarkup2"]);
                    PaperCostExMarkup3 = Convert.ToDecimal(row["PaperCostExMarkup3"]);
                    PaperCostExMarkup4 = Convert.ToDecimal(row["PaperCostExMarkup4"]);
                    PaperMarkupPrice1 = Convert.ToDecimal(row["PaperMarkupPrice1"]);
                    PaperMarkupPrice2 = Convert.ToDecimal(row["PaperMarkupPrice2"]);
                    PaperMarkupPrice3 = Convert.ToDecimal(row["PaperMarkupPrice3"]);
                    PaperMarkupPrice4 = Convert.ToDecimal(row["PaperMarkupPrice4"]);
                    PaperCostInMarkup1 = PaperCostExMarkup1 + PaperMarkupPrice1;
                    PaperCostInMarkup2 = PaperCostExMarkup2 + PaperMarkupPrice2;
                    PaperCostInMarkup3 = PaperCostExMarkup3 + PaperMarkupPrice3;
                    PaperCostInMarkup4 = PaperCostExMarkup4 + PaperMarkupPrice4;
                    paperCostInMarkup1[0] = paperCostInMarkup1[0] + PaperCostInMarkup1;
                    paperCostInMarkup1[1] = paperCostInMarkup1[1] + PaperCostInMarkup2;
                    paperCostInMarkup1[2] = paperCostInMarkup1[2] + PaperCostInMarkup3;
                    paperCostInMarkup1[3] = paperCostInMarkup1[3] + PaperCostInMarkup4;

                    PressCostExMarkup1 = Convert.ToDecimal(row["PressCostExMarkup1"]);
                    PressCostExMarkup2 = Convert.ToDecimal(row["PressCostExMarkup2"]);
                    PressCostExMarkup3 = Convert.ToDecimal(row["PressCostExMarkup3"]);
                    PressCostExMarkup4 = Convert.ToDecimal(row["PressCostExMarkup4"]);
                    PressMarkupPrice1 = Convert.ToDecimal(row["PressMarkupPrice1"]);
                    PressMarkupPrice2 = Convert.ToDecimal(row["PressMarkupPrice2"]);
                    PressMarkupPrice3 = Convert.ToDecimal(row["PressMarkupPrice3"]);
                    PressMarkupPrice4 = Convert.ToDecimal(row["PressMarkupPrice4"]);
                    PressCostInMarkup1 = PressCostExMarkup1 + PressMarkupPrice1;
                    PressCostInMarkup2 = PressCostExMarkup2 + PressMarkupPrice2;
                    PressCostInMarkup3 = PressCostExMarkup3 + PressMarkupPrice3;
                    PressCostInMarkup4 = PressCostExMarkup4 + PressMarkupPrice4;
                    pressCostInMarkup1[0] = pressCostInMarkup1[0] + PressCostInMarkup1;
                    pressCostInMarkup1[1] = pressCostInMarkup1[1] + PressCostInMarkup2;
                    pressCostInMarkup1[2] = pressCostInMarkup1[2] + PressCostInMarkup3;
                    pressCostInMarkup1[3] = pressCostInMarkup1[3] + PressCostInMarkup4;

                    PressName = row["PressName"].ToString();

                    GuillotineCostExMarkup1 = Convert.ToDecimal(row["GuillotineCostExMarkup1"]);
                    GuillotineCostExMarkup2 = Convert.ToDecimal(row["GuillotineCostExMarkup2"]);
                    GuillotineCostExMarkup3 = Convert.ToDecimal(row["GuillotineCostExMarkup3"]);
                    GuillotineCostExMarkup4 = Convert.ToDecimal(row["GuillotineCostExMarkup4"]);
                    GuillotineMarkupPrice1 = Convert.ToDecimal(row["GuillotineMarkupPrice1"]);
                    GuillotineMarkupPrice2 = Convert.ToDecimal(row["GuillotineMarkupPrice2"]);
                    GuillotineMarkupPrice3 = Convert.ToDecimal(row["GuillotineMarkupPrice3"]);
                    GuillotineMarkupPrice4 = Convert.ToDecimal(row["GuillotineMarkupPrice4"]);
                    GuillotineCostInMarkup1 = GuillotineCostExMarkup1 + GuillotineMarkupPrice1;
                    GuillotineCostInMarkup2 = GuillotineCostExMarkup2 + GuillotineMarkupPrice2;
                    GuillotineCostInMarkup3 = GuillotineCostExMarkup3 + GuillotineMarkupPrice3;
                    GuillotineCostInMarkup4 = GuillotineCostExMarkup4 + GuillotineMarkupPrice4;

                    guillotineCostInMarkup1[0] = guillotineCostInMarkup1[0] + GuillotineCostInMarkup1;
                    guillotineCostInMarkup1[1] = guillotineCostInMarkup1[1] + GuillotineCostInMarkup2;
                    guillotineCostInMarkup1[2] = guillotineCostInMarkup1[2] + GuillotineCostInMarkup3;
                    guillotineCostInMarkup1[3] = guillotineCostInMarkup1[3] + GuillotineCostInMarkup4;

                    //if (estimatetype == "K")
                    //{
                    //    if (objVal.Contains("[DoubleSidedLayout]") &&
                    //       (row.Table.Columns.Contains("DoubleSidedLayout") && row["DoubleSidedLayout"].ToString().Trim().Length != 0))
                    //    {
                    //        doubleSidedLayout = objVal.Replace("[DoubleSidedLayout]", row["DoubleSidedLayout"].ToString());
                    //    }
                    //}

                }
                //if (estimatetype == "K" && objVal.Contains("[DoubleSidedLayout]"))
                //{
                //    if (doubleSidedLayout.Trim().Length != 0)
                //    {
                //        objVal = objVal.Replace("[DoubleSidedLayout]", doubleSidedLayout);
                //    }
                //    else
                //    {
                //        objVal = "";
                //    }
                //}
                if (estimatetype == "N")
                {
                    objVal = objVal.Replace("[PaperCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", paperCostInMarkup1[0]), true));
                    objVal = objVal.Replace("[PressCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", pressCostInMarkup1[0]), true));
                    objVal = objVal.Replace("[GuillotineCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", guillotineCostInMarkup1[0]), true));
                    objVal = objVal.Replace("[PressName]", PressName);
                }
                else if (estimatetype != "N")
                {
                    objVal = objVal.Replace("[PaperCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", PaperCostInMarkup1), true));
                    objVal = objVal.Replace("[PressCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", PressCostInMarkup1), true));
                    objVal = objVal.Replace("[GuillotineCost]", this.objJava.GetCurrencyinRequiredFormate(String.Format("{0:0.00}", GuillotineCostInMarkup1), true));
                    objVal = objVal.Replace("[PressName]", PressName);
                }




            }
            else if (objVal.Contains("[PaperCost]") || objVal.Contains("[PressCost]") || objVal.Contains("[GuillotineCost]") || objVal.Contains("[PressName]"))
            {
                objVal = "";
            }
            //        break;

            //}

            //   PaperCostExMarkup1 = Convert.ToDecimal(dataTable.Rows[0]["PaperCostExMarkup1"]);
            //   PaperMarkupPrice1 = Convert.ToDecimal(dataTable.Rows[0]["PaperMarkupPrice1"]);
            //   PaperCostInMarkup1 = PaperCostExMarkup1 + PaperMarkupPrice1;

            ////   paperCostInMarkup1[0] = paperCostInMarkup1[0] + PaperCostInMarkup1;

            //   PressCostExMarkup1 = Convert.ToDecimal(dataTable.Rows[0]["PressCostExMarkup1"]);
            //   PressMarkupPrice1 = Convert.ToDecimal(dataTable.Rows[0]["PressMarkupPrice1"]);
            //   PressCostInMarkup1 = PressCostExMarkup1 + PressMarkupPrice1;

            //   GuillotineCostExMarkup1 = Convert.ToDecimal(dataTable.Rows[0]["GuillotineCostExMarkup1"]);
            //   GuillotineMarkupPrice1 = Convert.ToDecimal(dataTable.Rows[0]["GuillotineMarkupPrice1"]);
            //   GuillotineCostInMarkup1 = GuillotineCostExMarkup1 + GuillotineMarkupPrice1;
        }
        return objVal;
    }

    public string estimate_othercost_item_select(string objVal, int companyId, long estiateItemId, string estimatetype)
    {
        if (objVal.IndexOf("[") > -1)
        {
            DataRow[] dataRowArray;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal CostPriceInMarkup1 = new decimal(0);
            decimal CostPriceInMarkup2 = new decimal(0);
            decimal CostPriceInMarkup3 = new decimal(0);
            decimal CostPriceInMarkup4 = new decimal(0);
            StringBuilder othercostitem = new StringBuilder();
            DataTable dataTable = this.objJava.estimate_othercost_item_select((int)companyId, (long)estiateItemId);
            //  DataTable dataTable = this.commclass.estimate_othercost_item_select((int)companyId, (long)estiateItemId);
            if (dataTable.Rows.Count > 0)
            {
                //dataRowArray = dataTable.Select(string.Concat("EstOtherCostID=", (long)estiateItemId));
                //DataRow[] dataRowArray1 = dataRowArray;
                //for (int i = 0; i < (int)dataRowArray1.Length; i++)
                //{
                //  DataRow dataRow = dataRowArray1[i];
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //this.EstOtherCostID = Convert.ToInt64(dataRow["EstOtherCostID"]);
                    //this.hdnestothercostid.Value = this.EstOtherCostID.ToString();
                    //this.hdnEstimateItemID.Value = this.EstimateItemID.ToString();
                    //num2 = Convert.ToInt64(dataRow["TypeID"]);
                    //string str4 = dataRow["ItemTitle_New"].ToString();
                    string othercostname = dataRow["OthercostName"].ToString();
                    // this.OtherCostID = Convert.ToInt64(dataRow["OtherCostID"]);

                    int num3 = Convert.ToInt16(dataRow["SetupTime"]);
                    decimal num4 = Convert.ToDecimal(dataRow["HourlyRate"]);
                    decimal num5 = (num3 * num4) / new decimal(60);
                    decimal num6 = Convert.ToDecimal(dataRow["Cost"]) - num5;
                    decimal num7 = Convert.ToDecimal(dataRow["Cost1"]) - num5;
                    decimal num8 = Convert.ToDecimal(dataRow["Cost2"]) - num5;
                    decimal num9 = Convert.ToDecimal(dataRow["Cost3"]) - num5;
                    //estimatesItem.Qtydesc1 = dataRow["QTYDescription1"].ToString();
                    //estimatesItem.Qtydesc2 = dataRow["QTYDescription2"].ToString();
                    //estimatesItem.Qtydesc3 = dataRow["QTYDescription3"].ToString();
                    //estimatesItem.Qtydesc4 = dataRow["QTYDescription4"].ToString();
                    decimal num10 = Convert.ToDecimal(dataRow["Markup"]);
                    decimal num11 = Convert.ToDecimal(dataRow["Markup1"]);
                    decimal num12 = Convert.ToDecimal(dataRow["Markup2"]);
                    decimal num13 = Convert.ToDecimal(dataRow["Markup3"]);
                    decimal num14 = Convert.ToDecimal(dataRow["MinimumCost"]);
                    decimal num15 = new decimal(0);
                    decimal num16 = new decimal(0);
                    decimal num17 = new decimal(0);
                    decimal num18 = new decimal(0);
                    decimal num19 = new decimal(0);
                    decimal num20 = new decimal(0);
                    decimal num21 = new decimal(0);
                    decimal num22 = new decimal(0);
                    num15 = num6;
                    num17 = num7;
                    num19 = num8;
                    num21 = num9;
                    decimal num23 = (num6 * num10) / new decimal(100);
                    decimal num24 = (num7 * num11) / new decimal(100);
                    decimal num25 = (num8 * num12) / new decimal(100);
                    decimal num26 = (num9 * num13) / new decimal(100);

                    num16 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num15, num10, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num18 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num17, num11, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num20 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num19, num12, num14, out num, out num1, ref num5);
                    num5 = (num3 * num4) / new decimal(60);
                    num22 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num21, num13, num14, out num, out num1, ref num5);
                    CostPriceInMarkup1 = num16;
                    CostPriceInMarkup2 = num18;
                    CostPriceInMarkup3 = num20;
                    CostPriceInMarkup4 = num22;
                    string price1 = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CostPriceInMarkup1, 0, "", false, false, true), true);

                    othercostitem.Append(othercostname + ":  " + price1).AppendLine();
                }

                objVal = objVal.Replace("[AdditionalItemCost]", Convert.ToString(othercostitem));
            }
            else
            {
                objVal = objVal.Replace("[AdditionalItemCost]", "");
            }
        }
        return objVal;
    }

    private string Return_ItemDescriptionForSupplier(string objValueItem, string Description, string EstItemType)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            string[] strArrays = Description.ToString().Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '»' });
                if ((int)strArrays1.Length > 3)
                {
                    if (objValueItem.Contains("[ItemTitleLabel]") && string.Compare(strArrays1[0], "ItemTitle", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemTitleLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemDescriptionLabel]") && string.Compare(strArrays1[0], "Description", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemDescriptionLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemArtworkLabel]") && string.Compare(strArrays1[0], "Artwork", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemArtworkLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemColourLabel]") && string.Compare(strArrays1[0], "Colour", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemColourLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemSizeLabel]") && string.Compare(strArrays1[0], "Size", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemSizeLabel]", strArrays1[1].ToString().Replace(".0000", " ").Replace(".00", " "));
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemMaterialLabel]") && string.Compare(strArrays1[0], "Material", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemMaterialLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemDeliveryLabel]") && string.Compare(strArrays1[0], "Delivery", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemDeliveryLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemFinishingLabel]") && string.Compare(strArrays1[0], "Finishing", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemFinishingLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemProofsLabel]") && string.Compare(strArrays1[0], "Proofs", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemProofsLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemPackingLabel]") && string.Compare(strArrays1[0], "Packing", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemPackingLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemNotesLabel]") && string.Compare(strArrays1[0], "Notes", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemNotesLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemTerms/InstructionsLabel]") && string.Compare(strArrays1[0], "Instructions", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemTerms/InstructionsLabel]", strArrays1[1].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    for (int j = 1; j <= 25; j++)
                    {
                        if (objValueItem.Contains(string.Concat("[CustomDescription", j, "Label]")) && string.Compare(strArrays1[0], string.Concat("Custom Description ", j), true) == 0)
                        {
                            objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", j, "Label]"), strArrays1[1].ToString());
                            if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                            {
                                objValueItem = "";
                            }
                        }
                    }
                    if (objValueItem.Contains("[ItemTitle]") && string.Compare(strArrays1[0], "ItemTitle", true) == 0) //This ProductItemTitle
                    {
                        objValueItem = objValueItem.Replace("[ItemTitle]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemDescription]") && string.Compare(strArrays1[0], "Description", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemDescription]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemArtwork]") && string.Compare(strArrays1[0], "Artwork", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemArtwork]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemColour]") && string.Compare(strArrays1[0], "Colour", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemColour]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemSize]") && string.Compare(strArrays1[0], "Size", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemSize]", strArrays1[2].ToString().Replace(".0000", " ").Replace(".00", " "));
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemMaterial]") && string.Compare(strArrays1[0], "Material", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemMaterial]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemDelivery]") && string.Compare(strArrays1[0], "Delivery", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemDelivery]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemFinishing]") && string.Compare(strArrays1[0], "Finishing", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemFinishing]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemProofs]") && string.Compare(strArrays1[0], "Proofs", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemProofs]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemPacking]") && string.Compare(strArrays1[0], "Packing", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemPacking]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemNotes]") && string.Compare(strArrays1[0], "Notes", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemNotes]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    if (objValueItem.Contains("[ItemTerms/Instructions]") && string.Compare(strArrays1[0], "Instructions", true) == 0)
                    {
                        objValueItem = objValueItem.Replace("[ItemTerms/Instructions]", strArrays1[2].ToString());
                        if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false")
                        {
                            objValueItem = "";
                        }
                    }
                    for (int k = 1; k <= 25; k++)
                    {
                        if (objValueItem.Contains(string.Concat("[CustomDescription", k, "]")) && string.Compare(strArrays1[0], string.Concat("Custom Description ", k), true) == 0)
                        {
                            objValueItem = objValueItem.Replace(string.Concat("[CustomDescription", k, "]"), strArrays1[2].ToString());
                            if (strArrays1[2].ToString().Trim().Length == 0 || strArrays1[3].ToString().ToLower().Trim() == "false" || strArrays1[1].ToString().Trim().Length == 0)
                            {
                                objValueItem = "";
                            }
                        }
                    }
                }
            }
            if (objValueItem.Contains("[ItemTitle]") || objValueItem.Contains("[ItemDescription]") || objValueItem.Contains("[ItemArtwork]") || objValueItem.Contains("[ItemColour]") || objValueItem.Contains("[ItemSize]") || objValueItem.Contains("[ItemMaterial]") || objValueItem.Contains("[ItemDelivery]") || objValueItem.Contains("[ItemFinishing]") || objValueItem.Contains("[ItemProofs]") || objValueItem.Contains("[ItemPacking]") || objValueItem.Contains("[ItemNotes]") || objValueItem.Contains("[ItemTerms/Instructions]"))
            {
                objValueItem = "";
            }
        }
        return objValueItem;
    }

    private string Return_JobCardDetails(string objVal, int EstItemID, string EstType)
    {
        DataTable dataTable = new DataTable();
        if (this.Session[string.Concat("Return_JobCardDetails_dtQty1", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())] == null)
        {
            dataTable = this.objTemplates.templates_quantity_details_select_new(this.CompanyID, this.EstimateID, (long)EstItemID, EstType, this.PageType);
            this.Session[string.Concat("Return_JobCardDetails_dtQty1", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())] = dataTable;
        }
        else
        {
            dataTable = (DataTable)this.Session[string.Concat("Return_JobCardDetails_dtQty1", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())];
        }
        //75298-- Basharat
        if (objVal.Contains("Gutter") && (dataTable.Rows[0]["GutterHorizontal"].ToString() == "0.0000000000") && (dataTable.Rows[0]["GutterVertical"].ToString() == "0.0000000000"))
        {
            objVal = "";
        }

        if ((objVal.Contains("[FlatBookletItemSizeTitle]") && (dataTable.Rows[0]["JobHeight"].ToString() == "0.0000000000") && (dataTable.Rows[0]["JobWidth"].ToString() == "0.0000000000")) || (objVal.Contains("[FlatBookletItemSizeTitle]") && dataTable.Rows[0]["BookletType"].ToString().Trim().Equals("perfectbound")))
        {
            objVal = "";
        }
        else
        {
            if (objVal.Contains("[FlatBookletItemSizeTitle]")) objVal = "Flat Item Size";
        }

        if (objVal.IndexOf('[') > -1)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            if (this.PageType.ToLower() == "jobcard" || this.PageType.ToLower() == "job")
            {

                int num8 = 1;
                string empty = string.Empty;
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ClearSupplierValues();
                    objVal = objVal.Replace("[JobNumber]", row["JobNumber"].ToString());
                    if (Convert.ToInt32(row["SupplierID"]) > 0)
                    {
                        this.GetSupplierAddressFromDataBase(this.CompanyID, Convert.ToInt32(row["SupplierID"]));
                        if (row["SupplierContactID"] != DBNull.Value)
                        {
                            this.GetSupplierContactAddressFromDataBase(this.CompanyID, Convert.ToInt32(row["SupplierContactID"]));
                        }
                    }
                    if (!objVal.Contains("[SupplierName]") || row["SupplierName"].ToString().Trim().Length != 0)
                    {
                        objVal = objVal.Replace("[SupplierName]", row["SupplierName"].ToString());
                    }
                    else
                    {
                        objVal = "";
                    }
                    //if (objVal.Contains("[DoubleSidedLayout]"))
                    //{
                    //    if ((row.Table.Columns.Contains("DoubleSidedLayout") && row["DoubleSidedLayout"].ToString().Trim().Length != 0))
                    //    {
                    //        objVal = objVal.Replace("[DoubleSidedLayout]", row["DoubleSidedLayout"].ToString());
                    //    }
                    //    else
                    //    {
                    //        objVal = "";
                    //    }

                    //}
                    // Ticket # 10942 add the 'sold in packs of' field as a tag in the jobs system template
                    if (objVal.Contains("[SoldInPacksOf]"))
                    {
                        if ((row.Table.Columns.Contains("SoldInPacksOf") && Convert.ToString(row["SoldInPacksOf"]).Trim().Length != 0))
                        {
                            objVal = objVal.Replace("[SoldInPacksOf]", Convert.ToString(row["SoldInPacksOf"]));
                        }
                        else
                        {
                            objVal = "";
                        }

                    }

                    // JobItemNo
                    if (objVal.Contains("[JobItemNo]"))
                    {
                        if ((row.Table.Columns.Contains("JobNumber") && Convert.ToString(row["JobNumber"]).Trim().Length != 0))
                        {
                            objVal = objVal.Replace("[JobItemNo]", Convert.ToString(row["JobNumber"]));
                        }
                        else
                        {
                            objVal = "";
                        }

                    }
                    //75298-- Basharat
                    // Gutter
                    if (objVal.Contains("[Gutter]"))
                    {
                        if (row.Table.Columns.Contains("GutterHorizontal") && row.Table.Columns.Contains("GutterVertical"))
                        {
                            string GutterHorizontal = string.Concat(Math.Round(Convert.ToDouble(row["GutterHorizontal"].ToString()), 2), " mm");
                            string GutterVertical = string.Concat(Math.Round(Convert.ToDouble(row["GutterVertical"].ToString()), 2), " mm");

                            objVal = objVal.Replace("[Gutter]", string.Concat("Height: " + GutterVertical, " Width: " + GutterHorizontal));
                        }
                        else
                        {
                            objVal = "";
                        }

                    }
                    //75298-- Basharat
                    // FlatBookletItemSize

                    if (objVal.Contains("[FlatBookletItemSize]"))
                    {
                        if ((dataTable.Rows[0]["BookletType"].ToString().Trim().Equals("perfectbound")))
                        {
                            objVal = string.Empty;
                        }
                        else
                        {
                            if (row.Table.Columns.Contains("JobHeight") && row.Table.Columns.Contains("JobWidth"))
                            {
                                double JH = Math.Round(double.Parse(row["JobHeight"].ToString()), 2);
                                double JW = Math.Round(double.Parse(row["JobWidth"].ToString()), 2);

                                if (JH > 0 || JW > 0)
                                {
                                    string FlatBookletWidth = string.Empty, FlatBookletHeight = string.Empty;
                                    string NewHeight = string.Empty, NewWidth = string.Empty;
                                    if (JH > JW)
                                    {
                                        FlatBookletWidth = (JW * 2).ToString();
                                        FlatBookletHeight = JH.ToString();

                                    }
                                    else
                                    {
                                        FlatBookletWidth = JW.ToString();
                                        FlatBookletHeight = (JH * 2).ToString();
                                    }

                                    if (Convert.ToInt32(FlatBookletHeight) > Convert.ToInt32(FlatBookletWidth))
                                    {
                                        NewHeight = FlatBookletWidth;
                                        NewWidth = FlatBookletHeight;
                                    }
                                    else
                                    {
                                        NewHeight = FlatBookletHeight;
                                        NewWidth = FlatBookletWidth;
                                    }

                                    string regionalSettings = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
                                    string BookletHeight = string.Concat(NewHeight, " ", regionalSettings);
                                    string BookletWidth = string.Concat(NewWidth, " ", regionalSettings);

                                    objVal = objVal.Replace("[FlatBookletItemSize]", string.Concat("Height: " + BookletHeight, " Width: " + BookletWidth));
                                }
                                else
                                {
                                    objVal = string.Empty;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(row["MultipleOf"]) <= 1)
                    {
                        objVal = objVal.Replace(string.Concat("[Quantity", num8, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"].ToString()), 0, "", true, false, true));
                        this.objValueItem = this.objValueItem.Replace(string.Concat("[QuantityWithMultipleOf", num8, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"]), 0, "", true, false, true));
                    }
                    else
                    {
                        objVal = objVal.Replace(string.Concat("[Quantity", num8, "]"), this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"]), 0, "", true, false, true));
                        this.objValueItem = this.objValueItem.Replace(string.Concat("[QuantityWithMultipleOf", num8, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"]), 0, "", true, false, true), " X ", row["MultipleOf"].ToString()));
                    }
                    objVal = objVal.Replace(string.Concat("[CostPrice", num8, "(exMarkup)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["CostExMarkup"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[MarkupPrice", num8, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MarkupPrice"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[GrossProfitPrice", num8, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GrossProfitPrice"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[GrossProfitPercentage", num8, "]"), string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GrossProfitPercentage"].ToString()), 0, "", false, false, true), " %"));
                    objVal = objVal.Replace(string.Concat("[SubTotal", num8, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SubTotal"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[Tax", num8, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TaxValue"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[Price", num8, "(exTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SubTotal"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[Price", num8, "(inTax)]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PriceInTax"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[ProfitMarginPrice", num8, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ProfitMarginValue"].ToString()), 0, "", false, false, true), true));
                    objVal = objVal.Replace(string.Concat("[SupplierQuote#", num8, "]"), row["SupplierRefNo"].ToString());
                    objVal = this.Return_PricePerUnit(objVal, Convert.ToDecimal(row["SubTotal"]), Convert.ToDecimal(row["Quantity"]), num8, Convert.ToDecimal(row["TaxValue"].ToString()));
                    objVal = this.Return_CostPerUnit(objVal, Convert.ToDecimal(row["CostExMarkup"]), Convert.ToDecimal(row["Quantity"]));
                    objVal = this.Return_WarehouseDetails(objVal, (long)EstItemID, this.EstItemType);
                    row["RFQDescription"].ToString();
                    if (this.UnitOfMeasureKey)
                    {
                        if (this.EstItemType != "B" && this.EstItemType != "K" && this.EstItemType != "N" && this.EstItemType != "W" && this.EstItemType != "U" && this.EstItemType != "O")
                        {
                            objVal = objVal.Replace(string.Concat("[PricePerUnitofMeasureQty", num8, "]"), row["PricePerQty"].ToString());
                        }
                        else if (objVal.Contains(string.Concat("[PricePerUnitofMeasureQty", num8, "]")))
                        {
                            objVal = objVal.Replace(objVal, "");
                        }
                    }
                    if (num8 == 1)
                    {
                        num = num + Convert.ToDecimal(row["SubTotal"]);
                        num1 = num1 + Convert.ToDecimal(row["TaxValue"]);
                        num2 = num2 + Convert.ToDecimal(row["Quantity"]);
                        num3 = num3 + Convert.ToDecimal(row["ProfitMarginValue"]);
                        num4 = num4 + Convert.ToDecimal(row["CostExMarkup"]);
                        num5 = num5 + Convert.ToDecimal(row["MarkupPrice"]);
                        num6 = num6 + Convert.ToDecimal(row["GrossProfitPrice"]);
                        num7 = num7 + Convert.ToDecimal(row["GrossProfitPercentage"]);
                    }
                    num8++;
                }
                objVal = this.Return_ItemDescription(objVal, (long)EstItemID);

                // Ticket #9300 System template tags required
                //  objVal = this.Return_ProductSubitem_Details(objVal, (long)EstItemID);
                if (objVal.Contains("[ProductSubitem]") || objVal.Contains("[ProductSubitemWidth]") || objVal.Contains("[ProductSubitemHeight]") || objVal.Contains("[subitemadditionaloptions]") || objVal.Contains("[SubItemQuantity]"))
                {
                    if (!this.isSplitSubitem)
                    {
                        objVal = Job_ProductSubitem_EstimateItemIds_select(objVal, (long)EstItemID);
                    }
                    else
                    {
                        objVal = objVal.Replace("[ProductSubitem]", "");
                        objVal = objVal.Replace("[ProductSubitemWidth]", "");
                        objVal = objVal.Replace("[ProductSubitemHeight]", "");
                        objVal = objVal.Replace("[subitemadditionaloptions]", "");
                        objVal = objVal.Replace("[SubItemQuantity]", "");
                    }
                }


                // Ticket #9188 added new job template tags PaperCost, PressCost , Guillotine and AdditionalItemCost  

                objVal = Job_PaperPressGuillotineItem_Costs_Select(objVal, this.CompanyID, (long)EstItemID, EstType);

                objVal = estimate_othercost_item_select(objVal, this.CompanyID, (long)EstItemID, EstType);

                objVal = this.Return_EstoreAddition(objVal, (long)EstItemID);
                this.strFinalTotalPrice1ExTax = num;
                this.strFinalTotalTaxValue1 = num1;
                this.strFinalTotalQuantity1 = num2;
                this.strFinalTotalProfitMarginPrice1 = num3;
                this.strFinalTotalCostPrice1ExMarkup = num4;
                this.strFinalTotalMarkupPrice1 = num5;
                this.strFinalTotalGrossProfitPrice1 = num6;
                this.strFinalTotalGrossProfitPercentage1 = num7;
            }
            DataTable item = new DataTable();
            if (this.Session[string.Concat("Return_JobCardDetails_dtCard", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())] == null)
            {
                item = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, EstItemID);
                this.Session[string.Concat("Return_JobCardDetails_dtCard", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())] = item;
            }
            else
            {
                item = (DataTable)this.Session[string.Concat("Return_JobCardDetails_dtCard", this.EstimateID.ToString().Trim(), "_", EstItemID.ToString().Trim())];
            }
            foreach (DataRow dataRow in item.Rows)
            {
                objVal = objVal.Replace("[EstimatedArtworkDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqArtworkDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedProofDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProofDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedApprovalDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqApprovalDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedProductionDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProductionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedCompletionDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqCompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[EstimatedDeliveryDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ReqDeliveryDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualArtworkDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActArtworkdate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualProofDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActProofDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualApprovalDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActApprovalDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualProductionDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActProductionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualCompletionDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActCompletionDate"].ToString(), this.CompanyID, this.UserID, false));
                objVal = objVal.Replace("[ActualDeliveryDate]", this.objJava.Eprint_return_Date_Before_View(dataRow["ActDeliveryDate"].ToString(), this.CompanyID, this.UserID, false));

                objVal = objVal.Replace("[EstimatedArtworkDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqArtworkDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqArtworkDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProofDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProofDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqProofDate"].ToString()));
                objVal = objVal.Replace("[EstimatedApprovedDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqApprovalDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqApprovalDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProductionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProductionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqProductionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedCompletionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqCompletionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqCompletionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedDeliveryDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqDeliveryDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqDeliveryDate"].ToString()));
                objVal = objVal.Replace("[ActualArtworkDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActArtworkdate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActArtworkdate"].ToString()));
                objVal = objVal.Replace("[ActualProofDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActProofDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActProofDate"].ToString()));
                objVal = objVal.Replace("[ActualApprovalDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActApprovalDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActApprovalDate"].ToString()));
                objVal = objVal.Replace("[ActualProductionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActProductionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActProductionDate"].ToString()));
                objVal = objVal.Replace("[ActualCompletionDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActCompletionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActCompletionDate"].ToString()));
                objVal = objVal.Replace("[ActualDeliveryDateDay]", ReturnFullDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActDeliveryDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActDeliveryDate"].ToString()));

                objVal = objVal.Replace("[EstimatedArtworkDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqArtworkDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqArtworkDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProofDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProofDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqProofDate"].ToString()));
                objVal = objVal.Replace("[EstimatedApprovedDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqApprovalDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqApprovalDate"].ToString()));
                objVal = objVal.Replace("[EstimatedProductionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqProductionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqProductionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedCompletionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqCompletionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqCompletionDate"].ToString()));
                objVal = objVal.Replace("[EstimatedDeliveryDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ReqDeliveryDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ReqDeliveryDate"].ToString()));
                objVal = objVal.Replace("[ActualArtworkDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActArtworkdate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActArtworkdate"].ToString()));
                objVal = objVal.Replace("[ActualProofDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActProofDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActProofDate"].ToString()));
                objVal = objVal.Replace("[ActualApprovalDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActApprovalDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActApprovalDate"].ToString()));
                objVal = objVal.Replace("[ActualProductionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActProductionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActProductionDate"].ToString()));
                objVal = objVal.Replace("[ActualCompletionDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActCompletionDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActCompletionDate"].ToString()));
                objVal = objVal.Replace("[ActualDeliveryDateDayABV]", ReturnShortDayAndDate(this.objJava.Eprint_return_Date_Before_View(dataRow["ActDeliveryDate"].ToString(), this.CompanyID, this.UserID, false), dataRow["ActDeliveryDate"].ToString()));

                string lower = dataRow["EstimateType"].ToString().ToLower();
                if (lower == "f" || lower == "d" || lower == "k" || lower == "n")
                {
                    objVal = objVal.Replace("[EstimatedJobTime]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["EstimateJobTime"]), 0, "", false, false, true));
                    objVal = objVal.Replace("[ActualJobTime]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ActualJobTime"]), 0, "", false, false, true));
                }
                else
                {
                    objVal = objVal.Replace("[EstimatedJobTime]", "");
                    objVal = objVal.Replace("[ActualJobTime]", "");
                }
                // Ticket #10399 Added new tag [LargeFormatPressTime] in job templates
                if (objVal.Contains("[LargeFormatPressTime]"))
                {
                    if (lower == "l")
                    {
                        if (!dataRow.IsNull("LargeFormatPressTime"))
                        {
                            //dataRow["LargeFormatPressTime"]
                            objVal = objVal.Replace("[LargeFormatPressTime]", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["LargeFormatPressTime"]), 0, "", false, false, true));
                        }
                        else
                        {
                            objVal = objVal.Replace("[LargeFormatPressTime]", "");
                        }
                    }
                    else
                    {
                        objVal = objVal.Replace("[LargeFormatPressTime]", "");
                    }
                }
                objVal = objVal.Replace("[EstimatedPrePress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqPrePress"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualPrePress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActPrePress"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedPress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqPress"].ToString().Replace(".00", " "))));
                //objVal = objVal.Replace("[EstimatedPress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqPress"].ToString())));
                objVal = objVal.Replace("[ActualPress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActPress"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedPostPress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqPostPress"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualPostPress]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActPostPress"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedWarehouse]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqWarehouse"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualWarehouse]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActWarehouse"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedPriceCatalogue]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqPriceCatalogue"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualPriceCatalogue]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActPriceCatalogue"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedOutwork]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqOutwork"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualOutwork]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActOutwork"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedAdmin]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ReqAdmin"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[ActualAdmin]", string.Concat("<br/>", this.ReplaceBreak(dataRow["ActAdmin"].ToString().Replace(".00", " "))));
                objVal = objVal.Replace("[EstimatedPaper]", string.Concat("<br/>", dataRow["ReqPaper"].ToString()));
                objVal = objVal.Replace("[EstimatedInk]", string.Concat("<br/>", dataRow["ReqInk"].ToString()));
                objVal = objVal.Replace("[EstimatedPlates]", string.Concat("<br/>", dataRow["ReqPlates"].ToString()));
                objVal = objVal.Replace("[EstimatedGuillotine]", string.Concat("<br/>", dataRow["ReqGuillotine"].ToString()));
                objVal = objVal.Replace("[EstimatedWashUp]", string.Concat("<br/>", dataRow["ReqWashUp"].ToString()));
                objVal = objVal.Replace("[EstimatedMakeReady]", string.Concat("<br/>", dataRow["ReqMakeReady"].ToString()));
                objVal = objVal.Replace("[ActualPaper]", string.Concat("<br/>", dataRow["ActPaper"].ToString()));
                objVal = objVal.Replace("[ActualInk]", string.Concat("<br/>", dataRow["ActInk"].ToString()));
                objVal = objVal.Replace("[ActualPlates]", string.Concat("<br/>", dataRow["ActPlates"].ToString()));
                objVal = objVal.Replace("[ActualGuillotine]", string.Concat("<br/>", dataRow["ActGuillotine"].ToString()));
                objVal = objVal.Replace("[ActualWashUp]", string.Concat("<br/>", dataRow["ActWashUp"].ToString()));
                objVal = objVal.Replace("[ActualWashUp]", string.Concat("<br/>", dataRow["ActWashUp"].ToString()));
                objVal = objVal.Replace("[ActualWashUp]", string.Concat("<br/>", dataRow["ActWashUp"].ToString()));
                objVal = objVal.Replace("[ActualMakeReady]", string.Concat("<br/>", dataRow["ActMakeReady"].ToString()));
            }
        }
        return objVal;
    }

    private string Return_PricePerUnit(string objValueItem, decimal SubTotal, decimal Quantity, int cnt, decimal Tax)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            decimal num = new decimal(0);
            decimal ppuIncTax = new decimal(0);
            if (Quantity > new decimal(0))
            {
                num = SubTotal / Quantity;
            }
            if (Quantity > new decimal(0))
            {
                ppuIncTax = (SubTotal + Tax) / Quantity;
            }


            objValueItem = objValueItem.Replace(string.Concat("[PricePerUnit", cnt, "incTax]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(ppuIncTax), 0, "", false, false, true), true));
            objValueItem = objValueItem.Replace(string.Concat("[PricePerUnit", cnt, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true), true));
            objValueItem = objValueItem.Replace(string.Concat("[SubTotalPerUnit", cnt, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true), true));

            // Ticket #10266 Added  new estimate tags [PricePerUnit4Decimal1], [PricePerUnit4Decimal2], [PricePerUnit4Decimal3] and [PricePerUnit4Decimal4] and ivoice tag [PricePerUnit4Decimal1] in system templates
            objValueItem = objValueItem.Replace(string.Concat("[PricePerUnit4Decimal", cnt, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 4, "", false, false, true), true));
            // 76247 Basharat
            if (objValueItem.Contains("PricePer1000Unit"))
            {
                decimal thousandvalue = new decimal(0);
                thousandvalue = num * 1000;
                objValueItem = objValueItem.Replace(string.Concat("[PricePer1000Unit", cnt, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(thousandvalue), 0, "", false, false, true), true));
            }
            if (objValueItem.Contains("PricePer1000Unit4Decimal"))
            {
                decimal thousandvalue = new decimal(0);
                //thousandvalue = num / 1000;
                thousandvalue = num * 1000;
                objValueItem = objValueItem.Replace(string.Concat("[PricePer1000Unit4Decimal", cnt, "]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(thousandvalue), 4, "", false, false, true), true));
            }

        }
        return objValueItem;
    }

    private string Return_PricePerUnitInclTax(string objValueItem, decimal SubTotal, decimal Quantity, int cnt, decimal Tax)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
          
            decimal ppuIncTax = new decimal(0);
           
            if (Quantity > new decimal(0))
            {
                ppuIncTax = (SubTotal + Tax) / Quantity;
            }


            objValueItem = objValueItem.Replace(string.Concat("[PricePerUnit1incTax]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(ppuIncTax), 0, "", false, false, true), true));
        }
        return objValueItem;
    }





    //Ticket #9310 ART FOR LIFE - ESTIMATE AND INVOICE TEMPLATE 
    private string Return_CostPriceIncMarkup(string objValueItem, decimal SubTotal, decimal Quantity)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            decimal num = new decimal(0);
            if (Quantity > new decimal(0))
            {
                num = SubTotal / Quantity;
            }
            objValueItem = objValueItem.Replace(string.Concat("[CostPriceIncMarkup]"), this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true), true));
        }
        return objValueItem;
    }

    private string Return_ResizedImage(string ConvertedString)
    {
        string convertedString = ConvertedString;
        string str = "10";
        if (convertedString.Contains("<img"))
        {
            convertedString.Replace("width: 100%; height: 100%;", " ");
            string[] strArrays = new string[] { "width:" };
            string[] strArrays1 = convertedString.Split(strArrays, StringSplitOptions.None);
            string empty = string.Empty;
            try
            {
                if ((int)strArrays1.Length == 4)
                {
                    empty = strArrays1[(int)strArrays1.Length - 2].Substring(0, strArrays1[1].ToString().IndexOf("px"));
                }
                if ((int)strArrays1.Length == 3)
                {
                    empty = strArrays1[(int)strArrays1.Length - 2].Substring(0, strArrays1[1].ToString().IndexOf("px"));
                }
                else if ((int)strArrays1.Length < 3)
                {
                    empty = strArrays1[1].Substring(0, strArrays1[1].ToString().IndexOf("px"));
                }
            }
            catch
            {
            }
            string[] strArrays2 = new string[] { "height:" };
            string[] strArrays3 = convertedString.Split(strArrays2, StringSplitOptions.None);
            string empty1 = string.Empty;
            try
            {
                if ((int)strArrays3.Length == 4)
                {
                    empty1 = strArrays3[(int)strArrays3.Length - 2].Substring(0, strArrays3[1].ToString().IndexOf("px"));
                    if (empty1.Contains("p"))
                    {
                        empty1 = empty1.Replace("p", "");
                    }
                }
                else if ((int)strArrays3.Length == 3)
                {
                    empty1 = strArrays3[(int)strArrays3.Length - 1].Substring(0, strArrays3[1].ToString().IndexOf("px"));
                }
                else if ((int)strArrays3.Length < 3)
                {
                    empty1 = strArrays3[1].Substring(0, strArrays3[1].ToString().IndexOf("px"));
                }
                if (convertedString.Contains("<start") || convertedString.Contains(string.Concat("objtype=\"", str.Trim(), "\"")))
                {
                    empty1 = "1";
                }
            }
            catch
            {
            }
            string[] strArrays4 = new string[] { "width=" };
            string[] strArrays5 = convertedString.Split(strArrays4, StringSplitOptions.None);
            string str1 = string.Empty;
            try
            {
                str1 = strArrays5[1].Substring(0, strArrays5[1].ToString().IndexOf("height"));
            }
            catch
            {
            }
            string[] strArrays6 = new string[] { "height=" };
            string[] strArrays7 = convertedString.Split(strArrays6, StringSplitOptions.None);
            string empty2 = string.Empty;
            try
            {
                empty2 = strArrays7[1].Substring(0, strArrays7[1].ToString().IndexOf(">"));
            }
            catch
            {
            }
            convertedString = convertedString.Replace(string.Concat("width=", str1), string.Concat("width=\"", empty.Trim(), "\" "));
            convertedString = convertedString.Replace(string.Concat("height=", empty2), string.Concat("height=\"", empty1.Trim(), "\" "));
        }
        return convertedString;
    }

    private string Return_Top_TotalPrice_Details(string objValue, int CompanyID, long ModuleID, string PageType, long TemplateID)
    {
        if (objValue.IndexOf('[') > -1)
        {
            this.htTopTotQtyNum.Clear();
            this.htTopTotQtyNum.Add("1", "1");
            this.htTopTotQtyNum.Add("2", "2");
            this.htTopTotQtyNum.Add("3", "3");
            this.htTopTotQtyNum.Add("4", "4");
            DataTable dataTable = new DataTable();
            if (this.Session["dtTotalPr"] == null)
            {
                dataTable = this.objTemplates.templates_total_price_details_select(CompanyID, ModuleID, PageType, this.SelectedItems, TemplateID);
                this.Session["dtTotalPr"] = dataTable;
            }
            else
            {
                dataTable = (DataTable)this.Session["dtTotalPr"];
            }
            decimal num = new decimal(0);
            foreach (DataRow row in dataTable.Rows)
            {
                this.TopTotalQty1 = Convert.ToDecimal(row["TotalQuantity1"]);
                this.TopTotalQty2 = Convert.ToDecimal(row["TotalQuantity2"]);
                this.TopTotalQty3 = Convert.ToDecimal(row["TotalQuantity3"]);
                this.TopTotalQty4 = Convert.ToDecimal(row["TotalQuantity4"]);
                this.TopTotalSubTotal1 = Convert.ToDecimal(row["TotalSubTotal1"]);
                this.TopTotalSubTotal2 = Convert.ToDecimal(row["TotalSubTotal2"]);
                this.TopTotalSubTotal3 = Convert.ToDecimal(row["TotalSubTotal3"]);
                this.TopTotalSubTotal4 = Convert.ToDecimal(row["TotalSubTotal4"]);
                this.TopTotalTax1 = Convert.ToDecimal(row["TotalTaxValue1"]);
                this.TopTotalTax2 = Convert.ToDecimal(row["TotalTaxValue2"]);
                this.TopTotalTax3 = Convert.ToDecimal(row["TotalTaxValue3"]);
                this.TopTotalTax4 = Convert.ToDecimal(row["TotalTaxValue4"]);
                this.TopTotalProfitMarginPrice1 = Convert.ToDecimal(row["TotalProfitMarginValue1"]);
                this.TopTotalProfitMarginPrice2 = Convert.ToDecimal(row["TotalProfitMarginValue2"]);
                this.TopTotalProfitMarginPrice3 = Convert.ToDecimal(row["TotalProfitMarginValue3"]);
                this.TopTotalProfitMarginPrice4 = Convert.ToDecimal(row["TotalProfitMarginValue4"]);
                this.TopTotalProfitMarginPercentage1 = Convert.ToDecimal(row["totalProfitMarginpercentage1"]);
                this.TopTotalProfitMarginPercentage2 = Convert.ToDecimal(row["totalProfitMarginpercentage2"]);
                this.TopTotalProfitMarginPercentage3 = Convert.ToDecimal(row["totalProfitMarginpercentage3"]);
                this.TopTotalProfitMarginPercentage4 = Convert.ToDecimal(row["totalProfitMarginpercentage4"]);
                this.TopTotalSellingPrice1 = Convert.ToDecimal(row["TotalPrice1InTax"]);
                this.TopTotalSellingPrice2 = Convert.ToDecimal(row["TotalPrice2InTax"]);
                this.TopTotalSellingPrice3 = Convert.ToDecimal(row["TotalPrice3InTax"]);
                this.TopTotalSellingPrice4 = Convert.ToDecimal(row["TotalPrice4InTax"]);

                if (PageType.ToLower() == "estimate" || PageType.ToLower() == "invoice")
                {
                    this.SellingPricePerSQM1 = Convert.ToDecimal(row["SellingPricePerSQM1"]);
                    this.TopTotalMarkupPrice1 = Convert.ToDecimal(row["TotalMarkupPrice1"]);

                    if (PageType.ToLower() == "estimate")
                    {
                        this.SellingPricePerSQM2 = Convert.ToDecimal(row["SellingPricePerSQM2"]);
                        this.SellingPricePerSQM3 = Convert.ToDecimal(row["SellingPricePerSQM3"]);
                        this.SellingPricePerSQM4 = Convert.ToDecimal(row["SellingPricePerSQM4"]);

                        this.TopTotalMarkupPrice2 = Convert.ToDecimal(row["TotalMarkupPrice2"]);
                        this.TopTotalMarkupPrice3 = Convert.ToDecimal(row["TotalMarkupPrice3"]);
                        this.TopTotalMarkupPrice4 = Convert.ToDecimal(row["TotalMarkupPrice4"]);
                    }
                }
                if (PageType.ToLower() == "estimate")
                {
                    this.TotalProductAdditionalOptionsPrice1 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice1"]);
                    this.TotalProductAdditionalOptionsPrice2 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice2"]);
                    this.TotalProductAdditionalOptionsPrice3 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice3"]);
                    this.TotalProductAdditionalOptionsPrice4 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice4"]);
                }
                if (PageType.ToLower() == "job" || PageType.ToLower() == "jobcard" || PageType.ToLower() == "invoice")
                {
                    this.TopTotalCostPrice1ExMarkup = Convert.ToDecimal(row["TotalCostPrice1ExMarkup"]);
                    this.TopTotalMarkupPrice1 = Convert.ToDecimal(row["TotalMarkupPrice1"]);
                    this.TopTotalGrossProfitPrice1 = Convert.ToDecimal(row["TotalGrossProfitPrice1"]);
                    this.TopTotalGrossProfitPercentage1 = Convert.ToDecimal(row["TotalGrossProfitPercentage1"]);
                    this.TotalProductAdditionalOptionsPrice1 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice"]);
                    try
                    {
                        num = Convert.ToDecimal(row["TotalCostPricePlusTax1"]);
                    }
                    catch
                    {
                    }
                }
                if (this.TopTotalQty1 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(1);
                }
                if (this.TopTotalQty2 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(2);
                }
                if (this.TopTotalQty3 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(3);
                }
                if (this.TopTotalQty4 == new decimal(0))
                {
                    continue;
                }
                this.htTotQtyNum.Remove(4);
            }
            if (this.TopTotalQty1 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity1]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty1, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice1(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax1, 0, "", false, false, true), true));
                if ((objValue.Contains("[FirstItemTaxRate]")) && (this.firstItemTaxrate != ""))
                {
                    objValue = objValue.Replace("[FirstItemTaxRate]", this.firstItemTaxrate);
                }
                else
                {
                    objValue = objValue.Replace("[FirstItemTaxRate]", "");
                }

                //52385 first item quantity
                if ((objValue.Contains("[FirstItemQuantity1]")) && (this.firstItemQuantity1 != 0))
                {
                    objValue = objValue.Replace("[FirstItemQuantity1]", Convert.ToString(this.firstItemQuantity1));
                }
                else
                {
                    objValue = objValue.Replace("[FirstItemQuantity1]", "");
                }

                if ((objValue.Contains("[FirstItemQuantity2]")) && (this.firstItemQuantity2 != 0))
                {
                    objValue = objValue.Replace("[FirstItemQuantity2]", Convert.ToString(this.firstItemQuantity2));
                }
                else
                {
                    objValue = objValue.Replace("[FirstItemQuantity2]", "");
                }

                if ((objValue.Contains("[FirstItemQuantity3]")) && (this.firstItemQuantity3 != 0))
                {
                    objValue = objValue.Replace("[FirstItemQuantity3]", Convert.ToString(this.firstItemQuantity3));
                }
                else
                {
                    objValue = objValue.Replace("[FirstItemQuantity3]", "");
                }
                if ((objValue.Contains("[FirstItemQuantity4]")) && (this.firstItemQuantity4 != 0))
                {
                    objValue = objValue.Replace("[FirstItemQuantity4]", Convert.ToString(this.firstItemQuantity4));
                }
                else
                {
                    objValue = objValue.Replace("[FirstItemQuantity4]", "");
                }

                objValue = objValue.Replace("[TotalProfitMarginPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice1(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPercentage1]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage1, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp%1]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage1, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp$1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice1, 0, "", false, false, true), true));
                if (PageType.ToLower() == "estimate" || PageType.ToLower() == "invoice")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice1, 0, "", false, false, true), true));
                }
                if (PageType.ToLower() == "job" || PageType.ToLower() == "jobcard")
                {
                    objValue = objValue.Replace("[TotalCostPrice1(exMarkup)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalCostPrice1ExMarkup, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalMarkupPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalGrossProfitPrice1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalGrossProfitPrice1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalGrossProfitPercentage1]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalGrossProfitPercentage1, 0, "", false, false, true), " %"));
                    objValue = objValue.Replace("[TotalCostPricePlusTax1]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, num, 0, "", false, false, true));
                }
            }
            if (this.TopTotalQty2 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity2]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty2, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice2(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice2(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPercentage2]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage2, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp%2]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage2, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp$2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice2, 0, "", false, false, true), true));

                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM2, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice2, 0, "", false, false, true), true));
                }
            }
            if (this.TopTotalQty3 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity3]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty3, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice3(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice3(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPercentage3]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage3, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp%3]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage3, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp$3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice3, 0, "", false, false, true), true));

                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM3, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice3, 0, "", false, false, true), true));
                }
            }
            if (this.TopTotalQty4 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity4]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty4, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice4(exTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice4(inTax)]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPercentage4]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage4, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp%4]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPercentage4, 0, "", false, false, true), " %"));
                //objValue = objValue.Replace("[MarkUp$4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice4, 0, "", false, false, true), true));

                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM4, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice4, 0, "", false, false, true), true));
                }
            }
            if (objValue.IndexOf('[') > -1)
            {
                foreach (string value in this.htTotQtyNum.Values)
                {
                    if (!objValue.Contains(string.Concat("[TotalPrice", value, "(inTax)]")) && !objValue.Contains(string.Concat("[SellingPricePerSQM", value, "]")) && !objValue.Contains(string.Concat("[TotalTax", value, "]")) && !objValue.Contains(string.Concat("[TotalPrice", value, "(exTax)]")) && !objValue.Contains(string.Concat("[TotalProfitMarginPrice", value, "]")) && !objValue.Contains(string.Concat("[TotalQuantity", value, "]")) && !objValue.Contains(string.Concat("[TotalCostPrice", value, "(exMarkup)]")) && !objValue.Contains(string.Concat("[TotalMarkupPrice", value, "]")) && !objValue.Contains(string.Concat("[TotalGrossProfitPrice", value, "]")) && !objValue.Contains(string.Concat("[TotalGrossProfitPercentage", value, "]")) && !objValue.Contains(string.Concat("[TotalProductAdditionalOptionsPrice", value, "]")) && !objValue.Contains(string.Concat("[TotalCostPricePlusTax", value, "]")) && !objValue.Contains(string.Concat("[TotalProfitMarginPercentage", value, "]")) && !objValue.Contains(string.Concat("[ItemMarkup", value, "]")))
                    {
                        continue;
                    }
                    objValue = objValue.Replace(objValue, "");
                    break;
                }
            }

        }
        return objValue;
    }

    private string Return_Top_TotalPrice_Details_AllItem(string objValue, int CompanyID, long ModuleID, string PageType, long TemplateID)
    {
        if (objValue.IndexOf('[') > -1)
        {
            this.htTopTotQtyNum.Clear();
            this.htTopTotQtyNum.Add("1", "1");
            this.htTopTotQtyNum.Add("2", "2");
            this.htTopTotQtyNum.Add("3", "3");
            this.htTopTotQtyNum.Add("4", "4");
            DataTable dataTable = new DataTable();
            if (this.Session["dtTotalPr_AllItem"] == null)
            {
                dataTable = this.objTemplates.templates_total_price_details_select_AllItem(CompanyID, ModuleID, PageType, this.SelectedItems, TemplateID);
                this.Session["dtTotalPr_AllItem"] = dataTable;
            }
            else
            {
                dataTable = (DataTable)this.Session["dtTotalPr_AllItem"];
            }
            decimal num = new decimal(0);
            foreach (DataRow row in dataTable.Rows)
            {
                this.TopTotalQty1 = Convert.ToDecimal(row["TotalQuantity1"]);
                this.TopTotalQty2 = Convert.ToDecimal(row["TotalQuantity2"]);
                this.TopTotalQty3 = Convert.ToDecimal(row["TotalQuantity3"]);
                this.TopTotalQty4 = Convert.ToDecimal(row["TotalQuantity4"]);
                this.TopTotalSubTotal1 = Convert.ToDecimal(row["TotalSubTotal1"]);
                this.TopTotalSubTotal2 = Convert.ToDecimal(row["TotalSubTotal2"]);
                this.TopTotalSubTotal3 = Convert.ToDecimal(row["TotalSubTotal3"]);
                this.TopTotalSubTotal4 = Convert.ToDecimal(row["TotalSubTotal4"]);
                this.TopTotalTax1 = Convert.ToDecimal(row["TotalTaxValue1"]);
                this.TopTotalTax2 = Convert.ToDecimal(row["TotalTaxValue2"]);
                this.TopTotalTax3 = Convert.ToDecimal(row["TotalTaxValue3"]);
                this.TopTotalTax4 = Convert.ToDecimal(row["TotalTaxValue4"]);
                this.TopTotalProfitMarginPrice1 = Convert.ToDecimal(row["TotalProfitMarginValue1"]);
                this.TopTotalProfitMarginPrice2 = Convert.ToDecimal(row["TotalProfitMarginValue2"]);
                this.TopTotalProfitMarginPrice3 = Convert.ToDecimal(row["TotalProfitMarginValue3"]);
                this.TopTotalProfitMarginPrice4 = Convert.ToDecimal(row["TotalProfitMarginValue4"]);
                this.TopTotalSellingPrice1 = Convert.ToDecimal(row["TotalPrice1InTax"]);
                this.TopTotalSellingPrice2 = Convert.ToDecimal(row["TotalPrice2InTax"]);
                this.TopTotalSellingPrice3 = Convert.ToDecimal(row["TotalPrice3InTax"]);
                this.TopTotalSellingPrice4 = Convert.ToDecimal(row["TotalPrice4InTax"]);
                if (PageType.ToLower() == "estimate" || PageType.ToLower() == "invoice")
                {
                    this.SellingPricePerSQM1 = Convert.ToDecimal(row["SellingPricePerSQM1"]);
                    this.TopTotalMarkupPrice1 = Convert.ToDecimal(row["TotalMarkupPrice1"]);
                    if (PageType.ToLower() == "estimate")
                    {
                        this.SellingPricePerSQM2 = Convert.ToDecimal(row["SellingPricePerSQM2"]);
                        this.SellingPricePerSQM3 = Convert.ToDecimal(row["SellingPricePerSQM3"]);
                        this.SellingPricePerSQM4 = Convert.ToDecimal(row["SellingPricePerSQM4"]);

                        this.TopTotalMarkupPrice2 = Convert.ToDecimal(row["TotalMarkupPrice2"]);
                        this.TopTotalMarkupPrice3 = Convert.ToDecimal(row["TotalMarkupPrice3"]);
                        this.TopTotalMarkupPrice4 = Convert.ToDecimal(row["TotalMarkupPrice4"]);
                    }
                }
                if (PageType.ToLower() == "estimate")
                {
                    this.TotalProductAdditionalOptionsPrice1 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice1"]);
                    this.TotalProductAdditionalOptionsPrice2 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice2"]);
                    this.TotalProductAdditionalOptionsPrice3 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice3"]);
                    this.TotalProductAdditionalOptionsPrice4 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice4"]);
                }
                if (PageType.ToLower() == "job" || PageType.ToLower() == "jobcard" || PageType.ToLower() == "invoice")
                {
                    this.TopTotalCostPrice1ExMarkup = Convert.ToDecimal(row["TotalCostPrice1ExMarkup"]);
                    this.TopTotalMarkupPrice1 = Convert.ToDecimal(row["TotalMarkupPrice1"]);
                    this.TopTotalGrossProfitPrice1 = Convert.ToDecimal(row["TotalGrossProfitPrice1"]);
                    this.TopTotalGrossProfitPercentage1 = Convert.ToDecimal(row["TotalGrossProfitPercentage1"]);
                    this.TotalProductAdditionalOptionsPrice1 = Convert.ToDecimal(row["TotalProductAdditionalOptionsPrice"]);
                    try
                    {
                        num = Convert.ToDecimal(row["TotalCostPricePlusTax1"]);
                    }
                    catch
                    {
                    }
                }
                if (this.TopTotalQty1 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(1);
                }
                if (this.TopTotalQty2 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(2);
                }
                if (this.TopTotalQty3 != new decimal(0))
                {
                    this.htTotQtyNum.Remove(3);
                }
                if (this.TopTotalQty4 == new decimal(0))
                {
                    continue;
                }
                this.htTotQtyNum.Remove(4);
            }
            if (this.TopTotalQty1 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity1_AllItem]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty1, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice1(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice1(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice1, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice1(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSubTotal1 * Convert.ToDecimal(0.5)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalTax1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalTax1 * Convert.ToDecimal(0.5)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice1(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice1 * Convert.ToDecimal(0.5)), 0, "", false, false, true), true));
                //KR Ticket 78308, 83124
                objValue = objValue.Replace("[25%TotalPrice1(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice1 * Convert.ToDecimal(0.25)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[30%TotalPrice1(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice1 * Convert.ToDecimal(0.30)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[40%TotalPrice1(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice1 * Convert.ToDecimal(0.40)), 0, "", false, false, true), true));
                //KR END Ticket 78308, 83124 

                // ticket 82651 SellingPricePerSQM1 tag
                if (PageType.ToLower() == "estimate" || PageType.ToLower() == "invoice")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup1]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice1, 0, "", false, false, true), true));
                }
                if (PageType.ToLower() == "job" || PageType.ToLower() == "jobcard")
                {
                    objValue = objValue.Replace("[TotalCostPrice1(exMarkup)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalCostPrice1ExMarkup, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalMarkupPrice1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalGrossProfitPrice1_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalGrossProfitPrice1, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[TotalGrossProfitPercentage1_AllItem]", string.Concat(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalGrossProfitPercentage1, 0, "", false, false, true), " %"));
                    objValue = objValue.Replace("[TotalCostPricePlusTax1_AllItem]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, num, 0, "", false, false, true));
                }
            }
            if (this.TopTotalQty2 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity2_AllItem]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty2, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice2(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice2(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSubTotal2 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax2_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice2_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice2(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice2_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice2, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice2(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice2 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalTax2_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalTax2 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM2, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup2]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice2, 0, "", false, false, true), true));
                }

            }
            if (this.TopTotalQty3 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity3_AllItem]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty3, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice3(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice3(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSubTotal3 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax3_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice3_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice3(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice3_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice3, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice3(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice3 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalTax3_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalTax3 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM3, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup3]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice3, 0, "", false, false, true), true));
                }

            }
            if (this.TopTotalQty4 != new decimal(0))
            {
                objValue = objValue.Replace("[TotalQuantity4_AllItem]", this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalQty4, 0, "", true, false, true));
                objValue = objValue.Replace("[TotalPrice4(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSubTotal4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice4(exTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSubTotal4 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalTax4_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalTax4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProfitMarginPrice4_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalProfitMarginPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalPrice4(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalSellingPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[TotalProductAdditionalOptionsPrice4_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TotalProductAdditionalOptionsPrice4, 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalPrice4(inTax)_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalSellingPrice4 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                objValue = objValue.Replace("[50%TotalTax4_AllItem]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, (this.TopTotalTax4 * Convert.ToDecimal(0.50)), 0, "", false, false, true), true));
                if (PageType.ToLower() == "estimate")
                {
                    objValue = objValue.Replace("[SellingPricePerSQM4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.SellingPricePerSQM4, 0, "", false, false, true), true));
                    objValue = objValue.Replace("[ItemMarkup4]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, this.TopTotalMarkupPrice4, 0, "", false, false, true), true));
                }

            }
            if (objValue.IndexOf('[') > -1)
            {
                foreach (string value in this.htTotQtyNum.Values)
                {
                    if (!objValue.Contains(string.Concat("[TotalPrice", value, "(inTax)_AllItem]")) && !objValue.Contains(string.Concat("[SellingPricePerSQM", value)) && !objValue.Contains(string.Concat("[TotalTax", value, "_AllItem]")) && !objValue.Contains(string.Concat("[TotalPrice", value, "(exTax)_AllItem]")) && !objValue.Contains(string.Concat("[TotalProfitMarginPrice", value, "]_AllItem")) && !objValue.Contains(string.Concat("[TotalQuantity", value, "_AllItem]")) && !objValue.Contains(string.Concat("[TotalCostPrice", value, "(exMarkup)_AllItem]")) && !objValue.Contains(string.Concat("[TotalMarkupPrice", value, "_AllItem]")) && !objValue.Contains(string.Concat("[TotalGrossProfitPrice", value, "_AllItem]")) && !objValue.Contains(string.Concat("[TotalGrossProfitPercentage", value, "_AllItem]")) && !objValue.Contains(string.Concat("[TotalProductAdditionalOptionsPrice", value, "_AllItem]")) && !objValue.Contains(string.Concat("[ItemMarkup", value, "]")))
                    {
                        continue;
                    }
                    objValue = objValue.Replace(objValue, "");
                    break;
                }
            }
        }
        return objValue;
    }

    private string Return_WarehouseDetails(string objValueItem, long EstimateItemID, string EstItemType)
    {
        if (objValueItem.IndexOf('[') > -1)
        {
            if (EstItemType == "W")
            {
                string regionalSettings = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in this.objTemplates.templates_warehouse_details_select(this.CompanyID, EstimateItemID).Rows)
                {
                    this.WarePartCode = row["PartCode"].ToString();
                    this.WareLocation = row["Location"].ToString();
                    this.WareCost = Convert.ToDecimal(row["UnitPrice"]);
                    this.WarePackedIn = Convert.ToDecimal(row["PackedIn"]);
                    this.WarePackPrice = Convert.ToDecimal(row["PackPrice"]);
                    this.WareWeight = Convert.ToDecimal(row["Weight"]);
                    empty = row["PaperType"].ToString();
                    str = row["InvCategoryName"].ToString();
                    empty1 = row["InkType"].ToString();
                }
                if (str != "" && (str.ToLower() != "ink" || str.ToLower() != "inks") && empty1.ToLower() == "m")
                {
                    this.WarePackedIn = new decimal(0);
                    this.WarePackPrice = new decimal(0);
                }
                objValueItem = objValueItem.Replace("[InventoryPartCode]", this.WarePartCode);
                if (this.WareLocation != "")
                {
                    objValueItem = objValueItem.Replace("[InventoryLocation]", this.WareLocation);
                }
                else if (objValueItem.Contains("[InventoryLocation]"))
                {
                    objValueItem = objValueItem.Replace(objValueItem, "");
                }
                objValueItem = objValueItem.Replace("[InventoryCost]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.WareCost, 0, "", false, false, true), true));
                if (empty.ToLower() != "web printing")
                {
                    if (this.WarePackedIn > new decimal(0))
                    {
                        objValueItem = objValueItem.Replace("[InventoryPackedIn]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.WarePackedIn, 0, "", false, false, true), true));
                    }
                    else if (objValueItem.Contains("[InventoryPackedIn]"))
                    {
                        objValueItem = objValueItem.Replace(objValueItem, "");
                    }
                    if (this.WarePackPrice > new decimal(0))
                    {
                        objValueItem = objValueItem.Replace("[InventoryPackPrice]", this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.WarePackPrice, 0, "", false, false, true), true));
                    }
                    else if (objValueItem.Contains("[InventoryPackPrice]"))
                    {
                        objValueItem = objValueItem.Replace(objValueItem, "");
                    }
                }
                else if (objValueItem.Contains("[InventoryPackedIn]") || objValueItem.Contains("[InventoryPackPrice]"))
                {
                    objValueItem = objValueItem.Replace(objValueItem, "");
                }
                if (!(this.WareWeight == new decimal(0)) || !objValueItem.Contains("[InventoryWeight]"))
                {
                    objValueItem = objValueItem.Replace("[InventoryWeight]", string.Concat(this.objJava.GetCurrencyinRequiredFormate(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.WareWeight, 0, "", false, false, true), true), " ", regionalSettings));
                }
                else
                {
                    objValueItem = objValueItem.Replace(objValueItem, "");
                }
            }
            else if (objValueItem.Contains("[InventoryPartCode]") || objValueItem.Contains("[InventoryLocation]") || objValueItem.Contains("[InventoryCost]") || objValueItem.Contains("[InventoryPackedIn]") || objValueItem.Contains("[InventoryPackPrice]") || objValueItem.Contains("[InventoryWeight]"))
            {
                objValueItem = objValueItem.Replace(objValueItem, "");
            }
        }
        return objValueItem;
    }

    private DataTable ReturnActualPositionsOfAllTags(DataTable dt, string PDFID, string FooterSpace, string HeaderSpace, decimal FooterTop, string PDFName, int SupCount, string ImageName, int TotSupCount, int OutWorkItemID, int SupplierID)
    {
        object[] estimateNumber;
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("TemplateID", typeof(long));
        dataTable.Columns.Add("CompanyID", typeof(int));
        dataTable.Columns.Add("objID", typeof(string));
        dataTable.Columns.Add("objType", typeof(string));
        dataTable.Columns.Add("objName", typeof(string));
        dataTable.Columns.Add("type", typeof(string));
        dataTable.Columns.Add("objValue", typeof(string));
        dataTable.Columns.Add("imgsrc", typeof(string));
        dataTable.Columns.Add("title", typeof(string));
        dataTable.Columns.Add("align", typeof(string));
        dataTable.Columns.Add("position", typeof(string));
        dataTable.Columns.Add("top", typeof(decimal));
        dataTable.Columns.Add("left", typeof(decimal));
        dataTable.Columns.Add("width", typeof(decimal));
        dataTable.Columns.Add("height", typeof(decimal));
        dataTable.Columns.Add("zindex", typeof(string));
        dataTable.Columns.Add("padding", typeof(string));
        dataTable.Columns.Add("display", typeof(string));
        dataTable.Columns.Add("overflow", typeof(string));
        dataTable.Columns.Add("fontfamily", typeof(string));
        dataTable.Columns.Add("fontsize", typeof(string));
        dataTable.Columns.Add("fontweight", typeof(string));
        dataTable.Columns.Add("fontstyle", typeof(string));
        dataTable.Columns.Add("fontcolor", typeof(string));
        dataTable.Columns.Add("textdecoration", typeof(string));
        dataTable.Columns.Add("textalign", typeof(string));
        dataTable.Columns.Add("border", typeof(string));
        dataTable.Columns.Add("backgroundcolor", typeof(string));
        dataTable.Columns.Add("visibility", typeof(string));
        dataTable.Columns.Add("maxlength", typeof(string));
        dataTable.Columns.Add("offsetwidth", typeof(string));
        dataTable.Columns.Add("offsetheight", typeof(string));
        dataTable.Columns.Add("offsettop", typeof(string));
        dataTable.Columns.Add("offsetleft", typeof(string));
        dataTable.Columns.Add("pixelwidth", typeof(string));
        dataTable.Columns.Add("pixelheight", typeof(string));
        dataTable.Columns.Add("pixeltop", typeof(string));
        dataTable.Columns.Add("lock", typeof(string));
        dataTable.Columns.Add("canmove", typeof(string));
        dataTable.Columns.Add("canchangefontcolor", typeof(string));
        dataTable.Columns.Add("canchangefontsize", typeof(string));
        dataTable.Columns.Add("canchangefont", typeof(string));
        dataTable.Columns.Add("class", typeof(string));
        dataTable.Columns.Add("onmouseoverclass", typeof(string));
        dataTable.Columns.Add("objTag", typeof(string));
        dataTable.Columns.Add("isItem", typeof(string));
        dataTable.Columns.Add("GroupID", typeof(long));
        dataTable.Columns.Add("HGroupID", typeof(long));
        dataTable.Columns.Add("isHGroupMain", typeof(string));
        dataTable.Columns.Add("AssociatedLabel", typeof(string));
        dataTable.Columns.Add("isAutoExpand", typeof(string));
        dataTable.Columns.Add("llx", typeof(decimal));
        dataTable.Columns.Add("lly", typeof(decimal));
        dataTable.Columns.Add("urx", typeof(decimal));
        dataTable.Columns.Add("ury", typeof(decimal));
        dataTable.Columns.Add("pagenumber", typeof(int));
        dataTable.Columns.Add("LineNumber", typeof(int));
        dataTable.Columns.Add("Repeat", typeof(string));
        this.hsGroup = new Hashtable();
        this.hsGroupAutoExpandTop = new Hashtable();
        this.hsHGroup = new Hashtable();
        dt = this.UpdateValuesIfinHGROUPIsDeleteisTrue(dt);
        if (this.isFromReport)
        {
            dt = this.InvoiceReportAdjustMent(dt);
        }
        FooterTop = Convert.ToDecimal(FooterTop * Convert.ToDecimal(0.75));
        string empty = string.Empty;
        string str = string.Empty;
        DataTable dataTable1 = new DataTable();
        dataTable1 = (this.PageType.ToString().ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.EstimateID, this.PageType.ToString()) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.InvoiceID, this.PageType.ToString()));
        foreach (DataRow row in dataTable1.Rows)
        {
            this.EstimateNumber = row["Number"].ToString();
            str = row["TemNameLastCounter"].ToString();
        }
        if (this.PageType.ToLower() != "printbroker")
        {
            empty = string.Concat(this.EstimateNumber, "-", str, ".pdf");
        }
        else
        {
            estimateNumber = new object[] { this.EstimateNumber, "_", OutWorkItemID, "-", SupplierID, "-", str, ".pdf" };
            empty = string.Concat(estimateNumber);
        }
        if (this.isFromReport)
        {
            empty = empty.Replace(this.EstimateNumber, "Invoice-Statement");
        }
        //FontFactory.registerDirectory("C:\\WINDOWS\\Fonts");
        // int totalfonts = FontFactory.registerDirectory("C:\\WINDOWS\\Fonts");
        int totalfonts = FontFactory.registerDirectory("D:\\inetpub\\vhosts\\eprintsoftware.com\\httpdocs\\LiveDocuments\\document\\SecureDoc\\fonts");
        string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//" };
        if (!Directory.Exists(string.Concat(secureDocPath)))
        {
            secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//" };
            Directory.CreateDirectory(string.Concat(secureDocPath));
        }
        secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//", PDFName.ToString(), ".pdf" };
        string str1 = string.Concat(secureDocPath);
        if (!System.IO.File.Exists(str1))
        {
            str1 = this.CreatedBlankPDF(1);
        }
        PdfReader pdfReader = new PdfReader(str1);
        com.lowagie.text.Rectangle pageSizeWithRotation = pdfReader.getPageSizeWithRotation(1);
        int num = 0;
        secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID.ToString(), "//TemplatePDF//", ImageName.ToString() };
        string str2 = string.Concat(secureDocPath);
        string str3 = "0";
        string str4 = "0";
        string str5 = "0";
        string str6 = "0";
        double num1 = 0;
        if (!System.IO.File.Exists(str2))
        {
            str3 = "925";
            str4 = "1285";
            str5 = pageSizeWithRotation.height().ToString();
            str6 = pageSizeWithRotation.width().ToString();
            num1 = Convert.ToDouble(str5) - 10;
        }
        else
        {
            Bitmap bitmap = new Bitmap(str2);
            str3 = bitmap.Width.ToString();
            str4 = bitmap.Height.ToString();
            str5 = pageSizeWithRotation.height().ToString();
            str6 = pageSizeWithRotation.width().ToString();
            num1 = Convert.ToDouble(str5) - 10;
        }
        int num2 = 0;
        ArrayList arrayLists = new ArrayList();
        int num3 = 0;
        HeaderSpace = Convert.ToString(Convert.ToDouble(HeaderSpace));
        FooterSpace = Convert.ToString(Convert.ToDouble(FooterSpace));
        double num4 = 0;
        double num5 = 0;
        double num6 = 0;
        int num7 = 0;
        int num8 = 1;
        foreach (DataRow dataRow in dt.Rows)
        {
            try
            {
                string str7 = dataRow["objValue"].ToString();
                str7 = str7.Replace("[InvoiceReportTotal]", this.strItemTotal);
                str7.IndexOf("Cash Sales");
                string str8 = dataRow["objName"].ToString();
                string str9 = dataRow["objType"].ToString();
                string str10 = dataRow["fontfamily"].ToString();
                string str11 = dataRow["fontsize"].ToString();
                string str12 = dataRow["fontweight"].ToString();
                string str13 = dataRow["fontstyle"].ToString();
                string str14 = dataRow["left"].ToString();
                string str15 = dataRow["top"].ToString();
                string str16 = dataRow["width"].ToString();
                string str17 = dataRow["height"].ToString();
                string rGB = dataRow["fontcolor"].ToString();
                string str18 = dataRow["textdecoration"].ToString();
                string str19 = dataRow["textAlign"].ToString();
                if (str19.Trim().Length == 0)
                {
                    str19 = "left";
                }
                str7 = str7.Replace("\r\n", "<br/>");
                str7 = str7.Replace("\n", "<br/>");
                if (str8.Trim().ToLower().IndexOf("product image") != -1)
                {
                    str9 = "3";
                }
                str7 = str7.Replace("<br />", "<br/>");
                str7 = str7.Replace("<br>", "<br/>");
                str7 = str7.Replace("< br>", "<br/>");
                str7 = str7.Replace("<br >", "<br/>");
                str7 = str7.Replace("< br >", "<br/>");
                secureDocPath = new string[] { "<1linebreak>" };
                if (str10 == "century-gothic")
                {
                    str10 = str10.Replace("-", " ");
                }
                str10 = str10.Replace("-", " ");
                str10 = str10.Replace("_", "-");
                string[] strArrays = str7.ToString().Split(secureDocPath, StringSplitOptions.None);
                if ((int)strArrays.Length > 1)
                {
                    str7 = "";
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (strArrays[i].Replace("<br/>", "").Trim().Length > 0)
                        {
                            str7 = string.Concat(str7, strArrays[i].ToString(), "<1linebreak>");
                        }
                    }
                    if (str7.Length > 12)
                    {
                        str7 = str7.Substring(0, str7.Length - 12);
                    }
                }
                secureDocPath = new string[] { "<br/>" };
                string[] strArrays1 = secureDocPath;
                string[] strArrays2 = str7.ToString().Split(strArrays1, StringSplitOptions.None);
                if ((int)strArrays2.Length > 1)
                {
                    str7 = "";
                    ArrayList arrayLists1 = new ArrayList();
                    bool flag = false;
                    int num9 = 0;
                    for (int j = 0; j < (int)strArrays2.Length; j++)
                    {
                        if (strArrays2[j].Trim().ToLower() != "" || flag)
                        {
                            flag = true;
                            str7 = (j == (int)strArrays2.Length - 1 ? string.Concat(str7, strArrays2[j].ToString()) : string.Concat(str7, strArrays2[j].ToString(), "<br/>"));
                        }
                    }
                    strArrays2 = str7.ToString().Split(strArrays1, StringSplitOptions.None);
                    for (int k = 0; k < (int)strArrays2.Length; k++)
                    {
                        if (strArrays2[k].Trim().ToLower() != "")
                        {
                            num9 = k;
                        }
                    }
                    str7 = "";
                    for (int l = 0; l <= num9; l++)
                    {
                        str7 = (l == num9 ? string.Concat(str7, strArrays2[l].ToString()) : string.Concat(str7, strArrays2[l].ToString(), "<br/>"));
                    }
                }
                if (rGB.Length <= 0)
                {
                    rGB = "";
                }
                else
                {
                    if (rGB.ToLower().IndexOf("rgb") == -1)
                    {
                        rGB = this.ColorFromHexaToRGB(rGB);
                    }
                    rGB = rGB.Replace("(", "").Replace(")", "").Replace("rgb", "");
                }
                char[] chrArray = new char[] { ',' };
                string[] strArrays3 = rGB.Split(chrArray);
                if (str14.Trim().Length == 0)
                {
                    str14 = "0";
                }
                if (str15.Trim().Length == 0)
                {
                    str15 = "0";
                }
                if (str17.Trim().Length == 0)
                {
                    str17 = "0";
                }
                if (str16.Trim().Length == 0)
                {
                    str16 = "0";
                }
                double num10 = Convert.ToDouble(str14.Replace("px", ""));
                double num11 = Convert.ToDouble(str15.Replace("px", ""));
                double num12 = Convert.ToDouble(str17.Replace("px", ""));
                double num13 = Convert.ToDouble(str16.Replace("px", ""));
                num10 = this.WidthForMultiply(str3, str6, num10);
                num11 = this.HeightForMultiply(str4, str5, num11);
                num12 = this.HeightForMultiply(str4, str5, num12);
                num13 = this.HeightForMultiply(str4, str5, num13);
                double num14 = num11;
                str7.IndexOf("Press Name: Heidelberg GTO52 2 Colour");
                double num15 = 0;
                double num16 = 0;
                double num17 = num11;
                double num18 = 0;
                if (Convert.ToBoolean(dataRow["isAutoExpand"]) && Convert.ToInt64(dataRow["GroupID"]) > (long)0)
                {
                    num16 = num12;
                    num12 = this.ReturnIncreasedHeight(str10, str11, str12, str13, str18, strArrays3, num13, str7, str19, num12);
                    if (this.hsGroupAutoExpandTop.ContainsKey(dataRow["GroupID"]))
                    {
                        if (ConnectionClass.ServerName.Trim().ToLower() == "sks" || this.PageType.ToLower() == "job" || this.PageType.ToLower() == "jobcard")
                        {
                            num18 = Convert.ToDouble(this.hsGroupAutoExpandTop[dataRow["GroupID"]]);
                        }
                        else
                        {
                            num11 = num11 + Convert.ToDouble(this.hsGroupAutoExpandTop[dataRow["GroupID"]]);
                        }
                    }
                    if (num16 < num12)
                    {
                        num5 = 0;
                        if (this.hsGroupAutoExpandTop.ContainsKey(dataRow["GroupID"]))
                        {
                            num5 = Convert.ToDouble(this.hsGroupAutoExpandTop[dataRow["GroupID"]]);
                        }
                        num5 = num5 + (num12 - num16);
                        if (!this.hsGroupAutoExpandTop.ContainsKey(dataRow["GroupID"]))
                        {
                            this.hsGroupAutoExpandTop.Add(dataRow["GroupID"], num5);
                        }
                        else
                        {
                            this.hsGroupAutoExpandTop.Remove(dataRow["GroupID"]);
                            this.hsGroupAutoExpandTop.Add(dataRow["GroupID"], num5);
                        }
                        if (this.hsGroupAutoExpandTop.ContainsKey(dataRow["GroupID"]))
                        {
                            num15 = num12 - num16;
                        }
                    }
                }
                if (ConnectionClass.ServerName.Trim().ToLower() != "sks" && this.PageType.ToLower() != "job" && this.PageType.ToLower() != "jobcard")
                {
                    if (str7.Trim().Length == 0 && Convert.ToInt64(dataRow["GroupID"]) > (long)0)
                    {
                        num4 = 0;
                        if (this.hsGroup.ContainsKey(dataRow["GroupID"]))
                        {
                            num4 = Convert.ToDouble(this.hsGroup[dataRow["GroupID"]]);
                        }
                        num4 = num4 + num12;
                        if (!this.hsGroup.ContainsKey(dataRow["GroupID"]))
                        {
                            this.hsGroup.Add(dataRow["GroupID"], num4);
                        }
                        else
                        {
                            this.hsGroup.Remove(dataRow["GroupID"]);
                            this.hsGroup.Add(dataRow["GroupID"], num4);
                        }
                    }
                    if (this.hdnisKeepWithPrevious.Trim().ToLower().Length > 0 && Convert.ToBoolean(this.hdnisKeepWithPrevious) && Convert.ToInt64(dataRow["GroupID"]) > (long)0 && this.hsGroup.ContainsKey(dataRow["GroupID"]))
                    {
                        num4 = Convert.ToDouble(this.hsGroup[dataRow["GroupID"]]);
                        num11 = num11 - num4;
                    }
                }
                else if (this.hdnisKeepWithPrevious.Trim().ToLower().Length > 0 && Convert.ToBoolean(this.hdnisKeepWithPrevious) && Convert.ToInt64(dataRow["GroupID"]) > (long)0)
                {
                    double num19 = this.ReturnTOPFromGroupNew(Convert.ToInt32(dataRow["GroupID"]), num11, str7, num14);
                    if (num19 > 0)
                    {
                        num11 = num19;
                        num11 = num11 + num18;
                    }
                }
                if (this.hdnisKeepWithPrevious.Trim().ToLower().Length > 0 && Convert.ToBoolean(this.hdnisKeepWithPrevious) && Convert.ToInt64(dataRow["HGroupID"]) > (long)0)
                {
                    if (this.hsHGroup.ContainsKey(dataRow["HGroupID"]) && dataRow["isHGroupMain"].ToString().Trim().ToLower() == "true")
                    {
                        this.hsHGroup.Remove(dataRow["HGroupID"]);
                        this.hsHGroup.Add(dataRow["HGroupID"], num11);
                    }
                    else if (!this.hsHGroup.ContainsKey(dataRow["HGroupID"]) && dataRow["isHGroupMain"].ToString().Trim().ToLower() == "true")
                    {
                        this.hsHGroup.Add(dataRow["HGroupID"], num11);
                    }
                    else if (this.hsHGroup.ContainsKey(dataRow["HGroupID"]) && dataRow["isHGroupMain"].ToString().Trim().ToLower() == "false")
                    {
                        num11 = Convert.ToDouble(this.hsHGroup[dataRow["HGroupID"]]);
                    }
                }
                float single = 0f;
                if (num == 0 || dataRow["lock"].ToString().Trim().ToLower() == "true")
                {
                    single = (float)(num1 - (num11 + num12));
                }
                else
                {
                    single = (float)(num1 - Convert.ToDouble(HeaderSpace) - num12);
                    if (num11 - num6 > 0)
                    {
                        single = (float)((double)single - (num11 - num6));
                    }
                }
                bool flag1 = false;
                bool flag2 = false;
                try
                {
                    if (Convert.ToInt32(str9) == 9)
                    {
                        num3++;
                        if ((this.hdnisSplit.Trim().Length > 0) || (this.isSplitSubitem == true))
                        {
                            if (this.hdnisSplit.ToString().Trim() == "a")
                            {
                                flag1 = (ConnectionClass.ISDisableItemSplit ? this.ReturnItemPosition_DisableItemSplit(dt, FooterSpace, num, ref num6, num2, arrayLists, num3, num11, str3, str4, str5, str6, HeaderSpace) : this.ReturnItemPosition(dt, FooterSpace, num, ref num6, num2, arrayLists, num3, num11, str3, str4, str5, str6, HeaderSpace));
                            }
                            else if ((this.hdnisSplit.ToString().Trim() == "s") || (this.isSplitSubitem == true))
                            {
                                num7++;
                                flag2 = true;
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (Convert.ToInt32(str9) != 3 && Convert.ToInt32(str9) != 8 && Convert.ToInt32(str9) != 9 && Convert.ToInt32(str9) != 10 && Convert.ToInt32(str9) != 11 && Convert.ToInt32(str9) != 12 && Convert.ToInt32(str9) != 13 && Convert.ToInt32(str9) != 14 && (double)single - Convert.ToDouble(FooterSpace) < 0 && (dataRow["lock"].ToString().Trim().ToLower() == "false" || dataRow["lock"].ToString().Trim().Length == 0))
                    {
                        num++;
                        single = (float)(num1 - Convert.ToDouble(HeaderSpace) - num12);
                        num8 = num + 1;
                        num6 = num17;
                        this.hsGroupAutoExpandTop.Clear();
                        this.hsGroup.Clear();
                        this.Session["dtReturnTOPFromGroup"] = null;
                        this.Session["dtReturnTOPFromGroupForAll"] = null;
                        this.hsGroupAutoExpandTop.Add(dataRow["GroupID"], num15);
                        this.hsHGroup.Clear();
                    }
                    if (Convert.ToInt32(str9) == 9 && flag1)
                    {
                        num++;
                        single = (float)(num1 - Convert.ToDouble(HeaderSpace) - num12);
                        num8 = num + 1;
                        num6 = num17;
                        this.hsGroupAutoExpandTop.Clear();
                        this.hsGroup.Clear();
                        this.Session["dtReturnTOPFromGroup"] = null;
                        this.Session["dtReturnTOPFromGroupForAll"] = null;
                        this.hsGroupAutoExpandTop.Add(dataRow["GroupID"], num15);
                        this.hsHGroup.Clear();
                    }
                    if (flag2 && num7 > 1)
                    {
                        num++;
                        single = (float)(num1 - Convert.ToDouble(HeaderSpace) - num12);
                        num8 = num + 1;
                        num6 = num17;
                        this.hsGroupAutoExpandTop.Clear();
                        this.hsGroup.Clear();
                        this.Session["dtReturnTOPFromGroup"] = null;
                        this.Session["dtReturnTOPFromGroupForAll"] = null;
                        this.hsGroupAutoExpandTop.Add(dataRow["GroupID"], num15);
                        this.hsHGroup.Clear();
                    }
                }
                catch
                {
                }
                float single1 = (float)num10;
                float single2 = (float)num12;
                float single3 = (float)num13;
                if (str9.Trim().Length > 0)
                {
                    try
                    {
                        if (Convert.ToInt32(str9) == 3 || Convert.ToInt32(str9) == 8 || Convert.ToInt32(str9) == 9 || Convert.ToInt32(str9) == 10 || Convert.ToInt32(str9) == 11 || Convert.ToInt32(str9) == 12 || Convert.ToInt32(str9) == 14 || str7.Trim().ToLower().IndexOf("www.paypal.com") != -1 || str7.Trim().ToLower().IndexOf("checkout.stripe.com") != -1)
                        {
                            estimateNumber = new object[] { dataRow["TemplateID"], dataRow["CompanyID"], dataRow["objID"], dataRow["objType"], dataRow["objName"], dataRow["type"], dataRow["objValue"], dataRow["imgsrc"], dataRow["title"], dataRow["align"], dataRow["position"], dataRow["top"], dataRow["left"], dataRow["width"], dataRow["height"], dataRow["zindex"], dataRow["padding"], dataRow["display"], dataRow["overflow"], dataRow["fontfamily"], dataRow["fontsize"], dataRow["fontweight"], dataRow["fontstyle"], dataRow["fontcolor"], dataRow["textdecoration"], dataRow["textalign"], dataRow["border"], dataRow["backgroundcolor"], dataRow["visibility"], dataRow["maxlength"], dataRow["offsetwidth"], dataRow["offsetheight"], dataRow["offsettop"], dataRow["offsetleft"], dataRow["pixelwidth"], dataRow["pixelheight"], dataRow["pixeltop"], dataRow["lock"], dataRow["canmove"], dataRow["canchangefontcolor"], dataRow["canchangefontsize"], dataRow["canchangefont"], dataRow["class"], dataRow["onmouseoverclass"], dataRow["objTag"], "n", dataRow["GroupID"], dataRow["HGroupID"], dataRow["isHGroupMain"], dataRow["AssociatedLabel"], dataRow["isAutoExpand"], single1, single, single1 + (float)single3, single + single2, num8, 0, dataRow["Repeat"] };
                            dataTable.Rows.Add(estimateNumber);
                        }
                        else if (Convert.ToInt32(str9) != 13)
                        {
                            if (str10.Length == 0)
                            {
                                str10 = "Arial";
                            }
                            if (str11.Length == 0)
                            {
                                str11 = "9";
                            }
                            int num20 = 0;
                            this.objFontStyle = FontStyle.Regular;
                            if (str12.ToLower().Trim() == "bolder" && str13.ToLower().Trim() == "italic")
                            {
                                num20 = 3;
                                this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                            }
                            else if (str12.ToLower().Trim() == "bolder" && str13.ToLower().Trim() != "italic")
                            {
                                num20 = 1;
                                this.objFontStyle = FontStyle.Bold;
                            }
                            else if (str12.ToLower().Trim() != "bolder" && str13.ToLower().Trim() == "italic")
                            {
                                num20 = 2;
                                this.objFontStyle = FontStyle.Italic;
                            }
                            if (str18.Trim().ToLower() == "underline")
                            {
                                num20 = num20 | 4;
                                this.objFontStyle = FontStyle.Underline;
                            }
                            str11 = str11.ToLower().Replace("pt", "").Replace("px", "");
                            if ((int)strArrays3.Length <= 0)
                            {
                                this.color = Color.Black;
                            }
                            else
                            {
                                try
                                {
                                    int num21 = Convert.ToInt32(strArrays3[0]);
                                    int num22 = Convert.ToInt32(strArrays3[1]);
                                    int num23 = Convert.ToInt32(strArrays3[2]);
                                    this.color = Color.FromArgb(num21, num22, num23);
                                }
                                catch
                                {
                                    this.color = Color.Black;
                                }
                            }
                            com.lowagie.text.Font font = FontFactory.getFont(str10, "Cp1252", true, (float)Convert.ToInt32(str11), num20, this.color);


                            font.getBaseFont();
                            font.getCalculatedBaseFont(true);



                            /*System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                            privateFonts.AddFontFile("C:\\Windows\\Fonts\\SketchFlow Print.ttf");
                            System.Drawing.Font font1 = new System.Drawing.Font(privateFonts.Families[0], 12);
                            */


                            System.Drawing.Font font1 = new System.Drawing.Font(str10, (float)Convert.ToInt32(str11), this.objFontStyle, GraphicsUnit.Pixel);


                            Graphics graphic = Graphics.FromImage(new Bitmap(1, 1));
                            SizeF sizeF = graphic.MeasureString(str7, font1);
                            int width = (int)sizeF.Width;
                            float single4 = single3;
                            str7.IndexOf("2 pgs invoice NO");
                            if (width > Convert.ToInt32(single3))
                            {
                                string str20 = str7.Replace("<br>", "ê").Replace("<BR>", "ê").Replace("<br/>", "ê").Replace("<BR/>", "ê").Replace("<br />", "ê").Replace("<BR />", "ê");
                                chrArray = new char[] { 'ê' };
                                string[] strArrays4 = str20.Split(chrArray);
                                string empty1 = string.Empty;
                                for (int m = 0; m < (int)strArrays4.Length; m++)
                                {
                                    single3 = single4;
                                    sizeF = graphic.MeasureString(strArrays4[m].ToString(), font1);
                                    int width1 = (int)sizeF.Width;
                                    if (width1 > Convert.ToInt32(single3))
                                    {
                                        single3 = (float)width1;
                                        int num24 = Convert.ToInt32(single3 / (float)strArrays4[m].ToString().Length);
                                        num24 = Convert.ToInt32(single4 / (float)num24);
                                        string[] strArrays5 = this.WrapWord(strArrays4[m].ToString(), single4, graphic, font1);
                                        for (int n = 0; n < (int)strArrays5.Length; n++)
                                        {
                                            if (!(strArrays5[0].ToString().Trim() == "<br/>") && !(strArrays5[0].ToString().Trim() == "<BR/>") && !(strArrays5[0].ToString().Trim() == "<br />") && !(strArrays5[0].ToString().Trim() == "<BR />") && !(strArrays5[0].ToString().Trim() == "<br>") && !(strArrays5[0].ToString().Trim() == "<BR>"))
                                            {
                                                if (n == (int)strArrays5.Length - 1)
                                                {
                                                    if (strArrays5[n].Trim().Length > 0)
                                                    {
                                                        empty1 = string.Concat(empty1, strArrays5[n].ToString(), "<br/>");
                                                    }
                                                }
                                                else if (strArrays5[n].Trim().Length > 0)
                                                {
                                                    empty1 = string.Concat(empty1, strArrays5[n].ToString(), "<br/>");
                                                }
                                            }
                                        }
                                    }
                                    else if (m == (int)strArrays4.Length - 1)
                                    {
                                        if (strArrays4[m].Trim().Length > 0)
                                        {
                                            empty1 = string.Concat(empty1, strArrays4[m].ToString(), "<br/>");
                                        }
                                    }
                                    else if (strArrays4[m].Trim().Length > 0)
                                    {
                                        empty1 = string.Concat(empty1, strArrays4[m].ToString(), "<br/>");
                                    }
                                }
                                str7 = empty1;
                            }
                            single3 = single4;
                            float single5 = 0f;
                            int num25 = 0;
                            if (str19.Trim().ToLower() == "center")
                            {
                                num25 = 1;
                            }
                            else if (str19.Trim().ToLower() == "right")
                            {
                                num25 = 2;
                            }
                            if (str9.Trim().ToLower() != "1000")
                            {
                                string str21 = str7.Replace("&amp;", "&").Replace("<br>", "ê").Replace("<BR>", "ê").Replace("<br/>", "ê").Replace("<BR/>", "ê").Replace("<br />", "ê").Replace("<BR />", "ê").Replace("<em>", "").Replace("</em>", "").Replace("<strong>", "").Replace("</strong>", "").Replace("<EM>", "").Replace("</EM>", "").Replace("<STRONG>", "").Replace("</STRONG>", "").Replace("<b>", "ê").Replace("</b>", "ê").Replace("<u>", "ê").Replace("</u>", "ê").Replace("&quot;", "\"");
                                chrArray = new char[] { 'ê' };
                                this.arrayAfterBreak = str21.Split(chrArray);
                                double num26 = 0;
                                int num27 = 1;
                                for (int o = 0; o < (int)this.arrayAfterBreak.Length; o++)
                                {
                                    bool flag3 = false;
                                    if (this.arrayAfterBreak[o].ToString().Trim().Length > 0)
                                    {
                                        float height = (float)font1.GetHeight();
                                        num26 = num26 + (double)height;
                                        sizeF = graphic.MeasureString(this.arrayAfterBreak[o].ToString(), font1);
                                        float width2 = sizeF.Width;
                                        if (o > 0)
                                        {
                                            single = single - (height + (float)0);
                                        }
                                        single5 = single5 + height;
                                        if (single5 <= single2 && o > 0)
                                        {
                                            flag3 = true;
                                        }
                                        else if (o == 0)
                                        {
                                            flag3 = true;
                                        }
                                        // Ticket #11014 rolled back
                                        // Ticket #11014 sub-item details not showing
                                        //if (!flag3 && o > 0)
                                        //{
                                        //    if (Convert.ToString(dataRow["objTag"]).Contains("[SubItemQuantity]") || Convert.ToString(dataRow["objTag"]).Contains("[ProductSubitem]") || Convert.ToString(dataRow["objTag"]).Contains("[ProductSubitemWidth]") || Convert.ToString(dataRow["objTag"]).Contains("[ProductSubitemHeight]"))
                                        //    {
                                        //        flag3 = true;
                                        //    }
                                        //}
                                        if (flag3)
                                        {
                                            estimateNumber = new object[] { dataRow["TemplateID"], dataRow["CompanyID"], dataRow["objID"], dataRow["objType"], str8, str9, this.arrayAfterBreak[o].ToString().Trim().Replace("~~!!@@", ""), dataRow["imgsrc"], dataRow["title"], dataRow["align"], dataRow["position"], single, single1, single3, single2, dataRow["zindex"], dataRow["padding"], dataRow["display"], dataRow["overflow"], str10, str11, str12, str13, rGB, str18, num25, dataRow["border"], dataRow["backgroundcolor"], dataRow["visibility"], dataRow["maxlength"], dataRow["offsetwidth"], dataRow["offsetheight"], dataRow["offsettop"], dataRow["offsetleft"], dataRow["pixelwidth"], dataRow["pixelheight"], dataRow["pixeltop"], dataRow["lock"], dataRow["canmove"], dataRow["canchangefontcolor"], dataRow["canchangefontsize"], dataRow["canchangefont"], dataRow["class"], dataRow["onmouseoverclass"], dataRow["objTag"], dataRow["isItem"], dataRow["GroupID"], dataRow["HGroupID"], dataRow["isHGroupMain"], dataRow["AssociatedLabel"], dataRow["isAutoExpand"], single1, single, single1 + (float)single3, single + single2, num8, num27, dataRow["Repeat"] };
                                            dataTable.Rows.Add(estimateNumber);
                                            num27++;
                                        }
                                    }
                                }
                                str7.IndexOf("GAJ TEST");
                                if (ConnectionClass.ServerName.Trim().ToLower() != "sks" && num26 > 0 && (double)single2 > num26 && Convert.ToInt64(dataRow["GroupID"]) > (long)0)
                                {
                                    num4 = 0;
                                    if (this.hsGroup.ContainsKey(dataRow["GroupID"]))
                                    {
                                        num4 = Convert.ToDouble(this.hsGroup[dataRow["GroupID"]]);
                                    }
                                    num4 = num4 + ((double)single2 - num26);
                                    if (!this.hsGroup.ContainsKey(dataRow["GroupID"]))
                                    {
                                        this.hsGroup.Add(dataRow["GroupID"], num4);
                                    }
                                    else
                                    {
                                        this.hsGroup.Remove(dataRow["GroupID"]);
                                        this.hsGroup.Add(dataRow["GroupID"], num4);
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        pdfReader.close();
        return dataTable;
    }

    public double ReturnExact2Decimal(double Amount)
    {
        return Amount;
    }

    public double ReturnIncreasedHeight(string strCtrlFont, string strCtrlFontSize, string strCtrlFontWeight, string strCtrlStyle, string strCtrlIsUnderline, string[] colorarray, double width, string strCtrlValue, string strTextAlign, double height)
    {
        if (strCtrlFont.Length == 0)
        {
            strCtrlFont = "Arial";
        }
        if (strCtrlFontSize.Length == 0)
        {
            strCtrlFontSize = "9";
        }
        int num = 0;
        this.objFontStyle = FontStyle.Regular;
        if (strCtrlFontWeight.ToLower().Trim() == "bolder" && strCtrlStyle.ToLower().Trim() == "italic")
        {
            num = 3;
            this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
        }
        else if (strCtrlFontWeight.ToLower().Trim() == "bolder" && strCtrlStyle.ToLower().Trim() != "italic")
        {
            num = 1;
            this.objFontStyle = FontStyle.Bold;
        }
        else if (strCtrlFontWeight.ToLower().Trim() != "bolder" && strCtrlStyle.ToLower().Trim() == "italic")
        {
            num = 2;
            this.objFontStyle = FontStyle.Italic;
        }
        if (strCtrlIsUnderline.Trim().ToLower() == "underline")
        {
            num = num | 4;
            this.objFontStyle = FontStyle.Underline;
        }
        strCtrlFontSize = strCtrlFontSize.ToLower().Replace("pt", "").Replace("px", "");
        if ((int)colorarray.Length <= 0)
        {
            this.color = Color.Black;
        }
        else
        {
            try
            {
                int num1 = Convert.ToInt32(colorarray[0]);
                int num2 = Convert.ToInt32(colorarray[1]);
                int num3 = Convert.ToInt32(colorarray[2]);
                this.color = Color.FromArgb(num1, num2, num3);
            }
            catch
            {
                this.color = Color.Black;
            }
        }
        com.lowagie.text.Font font = FontFactory.getFont(strCtrlFont, "Cp1252", true, (float)Convert.ToInt32(strCtrlFontSize), num, this.color);
        font.getBaseFont();
        font.getCalculatedBaseFont(true);
        System.Drawing.Font font1 = new System.Drawing.Font(strCtrlFont, (float)Convert.ToInt32(strCtrlFontSize), this.objFontStyle, GraphicsUnit.Pixel);
        Graphics graphic = Graphics.FromImage(new Bitmap(1, 1));
        int num4 = (int)graphic.MeasureString(strCtrlValue, font1).Width;
        float single = (float)width;
        if (num4 > Convert.ToInt32(width))
        {
            string[] strArrays = strCtrlValue.Replace("<br>", "ê").Replace("<BR>", "ê").Replace("<br/>", "ê").Replace("<BR/>", "ê").Replace("<br />", "ê").Replace("<BR />", "ê").Split(new char[] { 'ê' });
            string empty = string.Empty;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                width = (double)single;
                SizeF sizeF = graphic.MeasureString(strArrays[i].ToString(), font1);
                int num5 = (int)sizeF.Width;
                if (num5 > Convert.ToInt32(width))
                {
                    width = (double)num5;
                    int num6 = Convert.ToInt32(width / (double)strArrays[i].ToString().Length);
                    num6 = Convert.ToInt32(single / (float)num6);
                    string[] strArrays1 = this.WrapWord(strArrays[i].ToString(), single, graphic, font1);
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        if (!(strArrays1[0].ToString().Trim() == "<br/>") && !(strArrays1[0].ToString().Trim() == "<BR/>") && !(strArrays1[0].ToString().Trim() == "<br />") && !(strArrays1[0].ToString().Trim() == "<BR />") && !(strArrays1[0].ToString().Trim() == "<br>") && !(strArrays1[0].ToString().Trim() == "<BR>"))
                        {
                            if (j == (int)strArrays1.Length - 1)
                            {
                                if (strArrays1[j].Trim().Length > 0)
                                {
                                    empty = string.Concat(empty, strArrays1[j].ToString(), "<br/>");
                                }
                            }
                            else if (strArrays1[j].Trim().Length > 0)
                            {
                                empty = string.Concat(empty, strArrays1[j].ToString(), "<br/>");
                            }
                        }
                    }
                }
                else if (i == (int)strArrays.Length - 1)
                {
                    if (strArrays[i].Trim().Length > 0)
                    {
                        empty = string.Concat(empty, strArrays[i].ToString(), "<br/>");
                    }
                }
                else if (strArrays[i].Trim().Length > 0)
                {
                    empty = string.Concat(empty, strArrays[i].ToString(), "<br/>");
                }
            }
            strCtrlValue = empty;
        }
        width = Convert.ToDouble(single);
        string str = strCtrlValue.Replace("&amp;", "&").Replace("<br>", "ê").Replace("<BR>", "ê").Replace("<br/>", "ê").Replace("<BR/>", "ê").Replace("<br />", "ê").Replace("<BR />", "ê").Replace("<em>", "").Replace("</em>", "").Replace("<strong>", "").Replace("</strong>", "").Replace("<EM>", "").Replace("</EM>", "").Replace("<STRONG>", "").Replace("</STRONG>", "").Replace("<b>", "ê").Replace("</b>", "ê").Replace("<u>", "ê").Replace("</u>", "ê");
        char[] chrArray = new char[] { 'ê' };
        this.arrayAfterBreak = str.Split(chrArray);
        double num7 = 0;
        for (int k = 0; k < (int)this.arrayAfterBreak.Length; k++)
        {
            if (this.arrayAfterBreak[k].ToString().Trim().Length > 0)
            {
                (new StringFormat()).Alignment = StringAlignment.Near;
                num7 = num7 + (double)font1.GetHeight();
            }
        }
        if (num7 > height)
        {
            height = num7;
        }
        return height;
    }

    private bool ReturnItemPosition(DataTable dt, string FooterSpace, int counter, ref double lastTop, int TagTopCounter, ArrayList objTagTop, int itemCounter, double currenttop, string ImageWidth, string ImageHeight, string PDFHeight, string PDFWidth, string HeaderSpace)
    {
        bool flag;
        bool flag1 = false;
        DataTable dataTable = new DataTable("gajtable");
        dataTable = dt.Clone();
        double num = 0;
        int num1 = 0;
        double num2 = Convert.ToDouble(PDFHeight) - 10;
        Convert.ToInt32(num2);
        foreach (DataRow row in dt.Rows)
        {
            string str = row["objType"].ToString();
            try
            {
                if (Convert.ToInt32(str) == 9)
                {
                    flag1 = true;
                    num1++;
                    if (itemCounter == num1)
                    {
                        string str1 = row["top"].ToString();
                        double num3 = Convert.ToDouble(str1.Replace("px", ""));
                        num = currenttop - this.HeightForMultiply(ImageHeight, PDFHeight, num3);
                    }
                }
                if (Convert.ToInt32(str) == 8)
                {
                    flag1 = false;
                    if (itemCounter == num1)
                    {
                        break;
                    }
                }
            }
            catch
            {
            }
            if (!flag1 || itemCounter != num1)
            {
                continue;
            }
            dataTable.ImportRow(row);
        }
        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                try
                {
                    current["objValue"].ToString();
                    string str2 = current["objType"].ToString();
                    string str3 = current["left"].ToString();
                    string str4 = current["top"].ToString();
                    string str5 = current["width"].ToString();
                    string str6 = current["height"].ToString();
                    if (str3.Trim().Length == 0)
                    {
                        str3 = "0";
                    }
                    if (str4.Trim().Length == 0)
                    {
                        str4 = "0";
                    }
                    if (str6.Trim().Length == 0)
                    {
                        str6 = "0";
                    }
                    if (str5.Trim().Length == 0)
                    {
                        str5 = "0";
                    }
                    double num4 = Convert.ToDouble(str3.Replace("px", ""));
                    double num5 = Convert.ToDouble(str4.Replace("px", ""));
                    double num6 = Convert.ToDouble(str6.Replace("px", ""));
                    double num7 = Convert.ToDouble(str5.Replace("px", ""));
                    num4 = this.WidthForMultiply(ImageWidth, PDFWidth, num4);
                    num5 = this.HeightForMultiply(ImageHeight, PDFHeight, num5);
                    num6 = this.HeightForMultiply(ImageHeight, PDFHeight, num6);
                    num7 = this.HeightForMultiply(ImageHeight, PDFHeight, num7);
                    num5 = num5 + num;
                    float single = 0f;
                    if (counter != 0)
                    {
                        single = (float)(num2 - Convert.ToDouble(HeaderSpace) - num6);
                        single = (float)((double)single - (num5 - lastTop));
                        single = single - 10f;
                    }
                    else
                    {
                        single = (float)(num2 - (num5 + num6));
                    }
                    try
                    {
                        if (Convert.ToInt32(str2) != 3 && Convert.ToInt32(str2) != 8 && Convert.ToInt32(str2) != 9 && Convert.ToInt32(str2) != 10 && Convert.ToInt32(str2) != 11 && Convert.ToInt32(str2) != 12 && Convert.ToInt32(str2) != 13 && Convert.ToInt32(str2) != 14 && (double)single - Convert.ToDouble(FooterSpace) < 0)
                        {
                            flag = true;
                            return flag;
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            return false;
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        return flag;
    }

    private bool ReturnItemPosition_DisableItemSplit(DataTable dt, string FooterSpace, int counter, ref double lastTop, int TagTopCounter, ArrayList objTagTop, int itemCounter, double currenttop, string ImageWidth, string ImageHeight, string PDFHeight, string PDFWidth, string HeaderSpace)
    {
        bool flag;
        bool flag1 = false;
        DataTable dataTable = new DataTable("gajtable");
        dataTable = dt.Clone();
        double num = 0;
        int num1 = 0;
        double num2 = Convert.ToDouble(PDFHeight) - 10;
        Convert.ToInt32(num2);
        foreach (DataRow row in dt.Rows)
        {
            string str = row["objType"].ToString();
            try
            {
                if (Convert.ToInt32(str) == 9)
                {
                    flag1 = true;
                    num1++;
                    if (itemCounter == num1)
                    {
                        string str1 = row["top"].ToString();
                        double num3 = Convert.ToDouble(str1.Replace("px", ""));
                        num = currenttop - this.HeightForMultiply(ImageHeight, PDFHeight, num3);
                    }
                }
                if (Convert.ToInt32(str) == 8)
                {
                    flag1 = false;
                    if (itemCounter == num1)
                    {
                        break;
                    }
                }
            }
            catch
            {
            }
            if (!flag1 || itemCounter != num1)
            {
                continue;
            }
            dataTable.ImportRow(row);
        }
        Hashtable hashtables = new Hashtable();
        Hashtable hashtables1 = new Hashtable();
        Hashtable hashtables2 = new Hashtable();
        IEnumerator enumerator = dataTable.Rows.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                DataRow current = (DataRow)enumerator.Current;
                try
                {
                    string str2 = current["objValue"].ToString();
                    str2 = str2.Replace("\r\n", "<br/>");
                    str2 = str2.Replace("\n", "<br/>");
                    str2 = str2.Replace("<br />", "<br/>");
                    str2 = str2.Replace("<br>", "<br/>");
                    str2 = str2.Replace("< br>", "<br/>");
                    str2 = str2.Replace("<br >", "<br/>");
                    str2 = str2.Replace("< br >", "<br/>");
                    string[] strArrays = new string[] { "<1linebreak>" };
                    string[] strArrays1 = str2.ToString().Split(strArrays, StringSplitOptions.None);
                    if ((int)strArrays1.Length > 1)
                    {
                        str2 = "";
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            if (strArrays1[i].Replace("<br/>", "").Trim().Length > 0)
                            {
                                str2 = string.Concat(str2, strArrays1[i].ToString(), "<1linebreak>");
                            }
                        }
                        if (str2.Length > 12)
                        {
                            str2 = str2.Substring(0, str2.Length - 12);
                        }
                    }
                    string[] strArrays2 = new string[] { "<br/>" };
                    string[] strArrays3 = str2.ToString().Split(strArrays2, StringSplitOptions.None);
                    if ((int)strArrays3.Length > 1)
                    {
                        str2 = "";
                        ArrayList arrayLists = new ArrayList();
                        bool flag2 = false;
                        int num4 = 0;
                        for (int j = 0; j < (int)strArrays3.Length; j++)
                        {
                            if (strArrays3[j].Trim().ToLower() != "" || flag2)
                            {
                                flag2 = true;
                                str2 = (j == (int)strArrays3.Length - 1 ? string.Concat(str2, strArrays3[j].ToString()) : string.Concat(str2, strArrays3[j].ToString(), "<br/>"));
                            }
                        }
                        strArrays3 = str2.ToString().Split(strArrays2, StringSplitOptions.None);
                        for (int k = 0; k < (int)strArrays3.Length; k++)
                        {
                            if (strArrays3[k].Trim().ToLower() != "")
                            {
                                num4 = k;
                            }
                        }
                        str2 = "";
                        for (int l = 0; l <= num4; l++)
                        {
                            str2 = (l == num4 ? string.Concat(str2, strArrays3[l].ToString()) : string.Concat(str2, strArrays3[l].ToString(), "<br/>"));
                        }
                    }
                    string str3 = current["objType"].ToString();
                    string str4 = current["left"].ToString();
                    string str5 = current["top"].ToString();
                    string str6 = current["width"].ToString();
                    string str7 = current["height"].ToString();
                    if (str4.Trim().Length == 0)
                    {
                        str4 = "0";
                    }
                    if (str5.Trim().Length == 0)
                    {
                        str5 = "0";
                    }
                    if (str7.Trim().Length == 0)
                    {
                        str7 = "0";
                    }
                    if (str6.Trim().Length == 0)
                    {
                        str6 = "0";
                    }
                    double num5 = Convert.ToDouble(str4.Replace("px", ""));
                    double num6 = Convert.ToDouble(str5.Replace("px", ""));
                    double num7 = Convert.ToDouble(str7.Replace("px", ""));
                    double num8 = Convert.ToDouble(str6.Replace("px", ""));
                    num5 = this.WidthForMultiply(ImageWidth, PDFWidth, num5);
                    num6 = this.HeightForMultiply(ImageHeight, PDFHeight, num6);
                    num7 = this.HeightForMultiply(ImageHeight, PDFHeight, num7);
                    num8 = this.HeightForMultiply(ImageHeight, PDFHeight, num8);
                    string str8 = current["fontfamily"].ToString();
                    string str9 = current["fontsize"].ToString();
                    string str10 = current["fontweight"].ToString();
                    string str11 = current["fontstyle"].ToString();
                    string str12 = current["fontcolor"].ToString();
                    string str13 = current["textdecoration"].ToString();
                    string str14 = current["textAlign"].ToString();
                    if (str14.Trim().Length == 0)
                    {
                        str14 = "left";
                    }
                    string[] strArrays4 = str12.Split(new char[] { ',' });
                    num6 = num6 + num;
                    double num9 = 0;
                    if (Convert.ToBoolean(current["isAutoExpand"]))
                    {
                        if (Convert.ToInt64(current["GroupID"]) > (long)0)
                        {
                            num9 = num7;
                            num7 = this.ReturnIncreasedHeight(str8, str9, str10, str11, str13, strArrays4, num8, str2, str14, num7);
                            if (hashtables1.ContainsKey(current["GroupID"]))
                            {
                                num6 = num6 + Convert.ToDouble(hashtables1[current["GroupID"]]);
                            }
                        }
                        if (num9 < num7)
                        {
                            double num10 = 0;
                            if (hashtables1.ContainsKey(current["GroupID"]))
                            {
                                num10 = Convert.ToDouble(hashtables1[current["GroupID"]]);
                            }
                            num10 = num10 + (num7 - num9);
                            if (!hashtables1.ContainsKey(current["GroupID"]))
                            {
                                hashtables1.Add(current["GroupID"], num10);
                            }
                            else
                            {
                                hashtables1.Remove(current["GroupID"]);
                                hashtables1.Add(current["GroupID"], num10);
                            }
                            hashtables1.ContainsKey(current["GroupID"]);
                        }
                    }
                    double num11 = 0;
                    if (str2.Trim().Length == 0 && Convert.ToInt64(current["GroupID"]) > (long)0)
                    {
                        num11 = 0;
                        if (hashtables.ContainsKey(current["GroupID"]))
                        {
                            num11 = Convert.ToDouble(hashtables[current["GroupID"]]);
                        }
                        num11 = num11 + num7;
                        if (!hashtables.ContainsKey(current["GroupID"]))
                        {
                            hashtables.Add(current["GroupID"], num11);
                        }
                        else
                        {
                            hashtables.Remove(current["GroupID"]);
                            hashtables.Add(current["GroupID"], num11);
                        }
                    }
                    if (this.hdnisKeepWithPrevious.Trim().ToLower().Length > 0 && Convert.ToBoolean(this.hdnisKeepWithPrevious) && Convert.ToInt64(current["GroupID"]) > (long)0 && hashtables.ContainsKey(current["GroupID"]))
                    {
                        num11 = Convert.ToDouble(hashtables[current["GroupID"]]);
                        num6 = num6 - num11;
                    }
                    float single = 0f;
                    if (counter != 0)
                    {
                        single = (float)(num2 - Convert.ToDouble(HeaderSpace) - num7);
                        single = (float)((double)single - (num6 - lastTop));
                        single = single - 10f;
                    }
                    else
                    {
                        single = (float)(num2 - (num6 + num7));
                    }
                    try
                    {
                        if (Convert.ToInt32(str3) != 3 && Convert.ToInt32(str3) != 8 && Convert.ToInt32(str3) != 9 && Convert.ToInt32(str3) != 10 && Convert.ToInt32(str3) != 11 && Convert.ToInt32(str3) != 12 && Convert.ToInt32(str3) != 13 && Convert.ToInt32(str3) != 14 && (double)single - Convert.ToDouble(FooterSpace) < 0 && Convert.ToInt32(current["GroupID"]) > 0)
                        {
                            flag = true;
                            return flag;
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            return false;
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        return flag;
    }

    public double ReturnTOPFromGroup(int GroupID, double CurrentTop, string strCtrlValue)
    {
        double num = 0;
        DataTable dataTable = new DataTable();
        if (this.Session["dtReturnTOPFromGroup"] != null)
        {
            dataTable = (DataTable)this.Session["dtReturnTOPFromGroup"];
            try
            {
                object[] groupID = new object[] { "GroupID=", GroupID, " and CurrentTop=", Convert.ToInt32(CurrentTop) };
                DataRow[] dataRowArray = dataTable.Select(string.Concat(groupID));
                if ((int)dataRowArray.Length > 0)
                {
                    DataRow[] dataRowArray1 = dataRowArray;
                    for (int i = 0; i < (int)dataRowArray1.Length; i++)
                    {
                        DataRow dataRow = dataRowArray1[i];
                        dataTable.Rows.Remove(dataRow);
                        dataTable.AcceptChanges();
                    }
                }
            }
            catch
            {
            }
            object[] objArray = new object[] { GroupID, CurrentTop, dataTable.Rows.Count + 1, strCtrlValue };
            dataTable.Rows.Add(objArray);
            dataTable.AcceptChanges();
        }
        else
        {
            dataTable.Columns.Add("GroupID", typeof(long));
            dataTable.Columns.Add("CurrentTop", typeof(long));
            dataTable.Columns.Add("Counter", typeof(int));
            dataTable.Columns.Add("textValue", typeof(string));
            object[] groupID1 = new object[] { GroupID, CurrentTop, 1, strCtrlValue };
            dataTable.Rows.Add(groupID1);
            this.Session["dtReturnTOPFromGroup"] = dataTable;
        }
        DataRow[] dataRowArray2 = dataTable.Select(string.Concat("GroupID=", GroupID));
        if ((int)dataRowArray2.Length <= 0)
        {
            num = 0;
        }
        else
        {
            DataRow[] dataRowArray3 = dataRowArray2;
            int num1 = 0;
            if (num1 < (int)dataRowArray3.Length)
            {
                DataRow dataRow1 = dataRowArray3[num1];
                num = Convert.ToDouble(dataRowArray2[0]["CurrentTop"]);
                if (strCtrlValue.ToLower().Replace("<br/>", "").Replace("<br>", "").Replace("<\n>", "").Trim().Length > 0)
                {
                    dataTable.Rows.Remove(dataRowArray2[0]);
                    dataTable.AcceptChanges();
                }
            }
        }
        return num;
    }

    public double ReturnTOPFromGroupNew(int GroupID, double CurrentTop, string strCtrlValue, double topForGroup)
    {
        DataTable dataTable = new DataTable();
        if (this.Session["dtReturnTOPFromGroupForAll"] != null)
        {
            dataTable = (DataTable)this.Session["dtReturnTOPFromGroupForAll"];
            object[] groupID = new object[] { GroupID, topForGroup };
            dataTable.Rows.Add(groupID);
            dataTable.AcceptChanges();
        }
        else
        {
            dataTable.Columns.Add("GroupID", typeof(long));
            dataTable.Columns.Add("topForGroup", typeof(decimal));
            object[] objArray = new object[] { GroupID, topForGroup };
            dataTable.Rows.Add(objArray);
            this.Session["dtReturnTOPFromGroupForAll"] = dataTable;
            dataTable.AcceptChanges();
        }
        double num = 0;
        DataRow[] dataRowArray = dataTable.Select(string.Concat("GroupID=", GroupID));
        if ((int)dataRowArray.Length > 1)
        {
            num = Convert.ToDouble(dataRowArray[(int)dataRowArray.Length - 1]["topForGroup"]) - Convert.ToDouble(dataRowArray[(int)dataRowArray.Length - 2]["topForGroup"]);
        }
        double currentTop = 0;
        DataTable item = new DataTable();
        if (this.Session["dtReturnTOPFromGroup"] != null)
        {
            item = (DataTable)this.Session["dtReturnTOPFromGroup"];
            DataRow[] dataRowArray1 = item.Select(string.Concat("GroupID=", GroupID));
            if ((int)dataRowArray1.Length <= 0)
            {
                object[] groupID1 = new object[] { GroupID, CurrentTop, item.Rows.Count + 1, strCtrlValue };
                item.Rows.Add(groupID1);
                item.AcceptChanges();
                currentTop = CurrentTop;
            }
            else
            {
                DataRow[] dataRowArray2 = dataRowArray1;
                int num1 = 0;
                if (num1 < (int)dataRowArray2.Length)
                {
                    DataRow dataRow = dataRowArray2[num1];
                    currentTop = Convert.ToDouble(dataRowArray1[0]["CurrentTop"]);
                    if (strCtrlValue.ToLower().Replace("<br/>", "").Replace("<br>", "").Replace("<\n>", "").Trim().Length > 0)
                    {
                        item.Rows.Remove(dataRowArray1[0]);
                        object[] objArray1 = new object[] { GroupID, currentTop + num, item.Rows.Count + 1, strCtrlValue };
                        item.Rows.Add(objArray1);
                        item.AcceptChanges();
                        item.AcceptChanges();
                    }
                    currentTop = currentTop + num;
                }
            }
        }
        else
        {
            item.Columns.Add("GroupID", typeof(long));
            item.Columns.Add("CurrentTop", typeof(long));
            item.Columns.Add("Counter", typeof(int));
            item.Columns.Add("textValue", typeof(string));
            object[] groupID2 = new object[] { GroupID, CurrentTop, 1, strCtrlValue };
            item.Rows.Add(groupID2);
            this.Session["dtReturnTOPFromGroup"] = item;
            currentTop = CurrentTop;
        }
        return currentTop;
    }

    private static List<int> StringRangeToListInt(string userRange)
    {
        List<int> nums = new List<int>();
        if (userRange.IndexOf(",") != -1)
        {
            string[] strArrays = userRange.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (str.IndexOf("-") == -1)
                {
                    nums.Add(Convert.ToInt32(str));
                }
                else
                {
                    string[] strArrays1 = str.Split(new char[] { '-' });
                    for (int j = Convert.ToInt32(strArrays1[0]); j <= Convert.ToInt32(strArrays1[1]); j++)
                    {
                        nums.Add(j);
                    }
                }
            }
        }
        else if (userRange.IndexOf("-") == -1)
        {
            nums.Add(Convert.ToInt32(userRange));
        }
        else
        {
            string[] strArrays2 = userRange.Split(new char[] { '-' });
            for (int k = Convert.ToInt32(strArrays2[0]); k <= Convert.ToInt32(strArrays2[1]); k++)
            {
                nums.Add(k);
            }
        }
        return nums;
    }

    public DataTable UpdateAssociatedLabelIfMainTextisBlank(DataTable dt)
    {
        DataRow[] dataRowArray = dt.Select("  AssociatedLabel<>'none'");
        for (int i = 0; i < (int)dataRowArray.Length; i++)
        {
            DataRow dataRow = dataRowArray[i];
            if (dataRow["objValue"].ToString().Trim().Replace("<br/>", "").Replace("\n", "").Replace("\r", "").Trim().Length == 0)
            {
                double num = Convert.ToDouble(dataRow["top"]);
                string[] str = new string[] { " objID='", dataRow["AssociatedLabel"].ToString(), "'and [top]>", null, null, null, null };
                str[3] = (num - 5).ToString();
                str[4] = " and [top]< ";
                str[5] = (num + 5).ToString();
                str[6] = "  and objtype in (1,2,3)";
                DataRow[] dataRowArray1 = dt.Select(string.Concat(str));
                for (int j = 0; j < (int)dataRowArray1.Length; j++)
                {
                    DataRow dataRow1 = dataRowArray1[j];
                    dataRow1["objValue"] = "";
                    dataRow1["imgsrc"] = "";
                    dataRow1["objName"] = "";
                }
            }
        }
        return dt;
    }

    public DataTable UpdateValuesIfinHGROUPIsDeleteisTrue(DataTable dt)
    {
        DataRow[] dataRowArray = dt.Select("  HGroupID>0 and isHGroupMain='true'");
        for (int i = 0; i < (int)dataRowArray.Length; i++)
        {
            DataRow dataRow = dataRowArray[i];
            if (dataRow["objValue"].ToString().Trim().Replace("<br/>", "").Replace("\n", "").Replace("\r", "").Trim().Length == 0)
            {
                double num = Convert.ToDouble(dataRow["top"]);
                dt.Select(string.Concat(" HGroupID=", dataRow["HGroupID"].ToString()));
                string[] str = new string[] { " HGroupID=", dataRow["HGroupID"].ToString(), "and [top]>", null, null, null, null };
                str[3] = (num - 5).ToString();
                str[4] = " and [top]< ";
                str[5] = (num + 5).ToString();
                str[6] = "  and objtype in (1,2,3)";
                DataRow[] dataRowArray1 = dt.Select(string.Concat(str));
                for (int j = 0; j < (int)dataRowArray1.Length; j++)
                {
                    DataRow dataRow1 = dataRowArray1[j];
                    dataRow1["objValue"] = "";
                    dataRow1["imgsrc"] = "";
                    dataRow1["objName"] = "";
                }
            }
        }
        dt = this.UpdateAssociatedLabelIfMainTextisBlank(dt);
        return dt;
    }

    private double WidthForMultiply(string ImageWidth, string PDFWidth, double left)
    {
        left = left / Convert.ToDouble(ImageWidth) * Convert.ToDouble(PDFWidth);
        return left;
    }

    public string[] WrapWord(string text, float maxLength, Graphics objGraphics, System.Drawing.Font objFont)
    {
        string[] strArrays = text.Split(new char[] { ' ' });
        ArrayList arrayLists = new ArrayList();
        string str = "";
        string empty = string.Empty;
        string[] strArrays1 = strArrays;
        for (int i = 0; i < (int)strArrays1.Length; i++)
        {
            string str1 = strArrays1[i];
            if (str1.Length > 0)
            {
                str = (str.Trim().Length != 0 ? string.Concat(str, " ", str1) : str1);
                if ((float)((int)objGraphics.MeasureString(str, objFont).Width) > maxLength)
                {
                    arrayLists.Add(empty);
                    str = str1;
                    empty = string.Empty;
                }
                empty = (empty.Trim().Length != 0 ? string.Concat(empty, " ", str1) : str1);
            }
        }
        if (str != "")
        {
            arrayLists.Add(str);
        }
        string[] strArrays2 = new string[arrayLists.Count];
        arrayLists.CopyTo(strArrays2, 0);
        return strArrays2;
    }

    private Int64 approveForDepartment(Int64 estimateItemID)
    {
        Int64 estimateid = 0;
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DataSet dataSet = new DataSet();
        string query = "select * from tb_EstimateItem where EstimateItemID =  " + estimateItemID;
        SqlCommand cmd = new SqlCommand(query);
        dataSet = database.ExecuteDataSet(cmd);

        if (dataSet.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dataSet.Tables[0].Rows[0];
            estimateid = Convert.ToInt64(dr["EstimateID"]);
        }


        return estimateid;

    }


    private string ReturnFullDayAndDate(string shortDate, string fullDate)
    {
        string _date = string.Empty;
        DateTime _dateTime = new DateTime();
        if (!string.IsNullOrEmpty(shortDate))
        {
            _dateTime = this.objJava.Eprint_return_ActualDate_Before_View(fullDate, this.CompanyID, this.UserID, false);
            _date = string.Concat(_dateTime.ToString("dddd"), " ", shortDate);
        }
        return _date;
    }
    private string ReturnShortDayAndDate(string shortDate, string fullDate)
    {
        string _date = string.Empty;
        DateTime _dateTime = new DateTime();
        if (!string.IsNullOrEmpty(shortDate))
        {
            _dateTime = this.objJava.Eprint_return_ActualDate_Before_View(fullDate, this.CompanyID, this.UserID, false);
            _date = string.Concat(_dateTime.ToString("ddd"), " ", shortDate);
        }
        return _date;
    }

    private void ReplaceCustomFields(DataTable table, string prefix)
    {
        foreach (DataRow row in table.Rows)
        {
            string label = row["FieldLabel"].ToString();
            string value = row["FieldValue"]?.ToString() ?? "";
            string fieldKey = row["FieldNameKey"].ToString(); // e.g. "CustomField1"

            // Extract the number from CustomField1 → 1
            int fieldNo = 0;
            if (fieldKey.StartsWith("CustomField"))
            {
                int.TryParse(fieldKey.Replace("CustomField", ""), out fieldNo);
            }

            if (fieldNo > 0)
            {
                // Replace Label and Value tags dynamically
                this.objValue = this.objValue.Replace($"[{prefix}{fieldNo}Label]", label);
                this.objValue = this.objValue.Replace($"[{prefix}{fieldNo}]", value);
            }
        }
    }

}