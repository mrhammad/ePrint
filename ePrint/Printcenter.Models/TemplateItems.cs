using System;
using System.Collections;
using System.Data;
using System.Drawing;

public class TemplateItems : BaseClass
{
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

	protected string PaymentTerms = string.Empty;

	protected string TodaysDate = string.Empty;

	protected string AccountStatus = string.Empty;

	protected string CustomerDescription = string.Empty;

	protected string InvoiceContact = string.Empty;

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

	protected string Greeting = string.Empty;

	protected string Header = string.Empty;

	protected string Footer = string.Empty;

	protected string OrderNumber = string.Empty;

	protected string CustomerOrderNumber = string.Empty;

	protected string SalesPerson = string.Empty;

	protected string EstimatedBy = string.Empty;

	protected string CreatedBy = string.Empty;

	protected string ValidFor = string.Empty;

	protected string CreatedDate = string.Empty;

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

	protected string EstimatedDate = string.Empty;

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

	protected string Paypalbusiness = string.Empty;

	protected string InvoicePaid = string.Empty;

	protected decimal InvoiceAmountPaid;

	protected decimal InvoiceAmountoutstanding;

	protected string CustomerInvoiceAddressType = string.Empty;

	protected int CustomerInvoiceAddressID;

	protected int CustomerInvoiceAddressClientID;

	protected string CustomerInvoiceAddress = string.Empty;

	protected string InvoiceDueDate = string.Empty;

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

	protected int CompanyID;

	protected int EstimateID;

	protected long EstimateItemID;

	protected int EstID;

	protected string PDFKey = string.Empty;

	protected string PageType = string.Empty;

	protected long TemplateID;

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

	protected decimal TopTotalCostPrice1ExMarkup;

	protected decimal TopTotalMarkupPrice1;

	protected decimal TopTotalGrossProfitPrice1;

	protected decimal TopTotalGrossProfitPercentage1;

	protected decimal TotalProductAdditionalOptionsPrice1;

	protected decimal TotalProductAdditionalOptionsPrice2;

	protected decimal TotalProductAdditionalOptionsPrice3;

	protected decimal TotalProductAdditionalOptionsPrice4;

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

	protected TemplateItems()
	{
	}
}