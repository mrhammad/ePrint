using Printcenter.BusinessAccessLayer.Webstore;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.Webstores
{
    public class WebstoreBasePage : BaseClass
    {
        public WebstoreBasePage()
        {
        }

        public static void AdditionalGroup_delete(long AdditionalGroupID, long PricecatalogueID)
        {
            Webstore.AdditionalGroup_delete(AdditionalGroupID, PricecatalogueID);
        }

        public static long AdditionalGroup_insert(long PricecatalogueID, string GroupName)
        {
            return Webstore.AdditionalGroup_insert(PricecatalogueID, GroupName);
        }

        public static void AdditionalGroup_ProductID_Update(long TempProductID, long PricecatalogueID)
        {
            Webstore.AdditionalGroup_ProductID_Update(TempProductID, PricecatalogueID);
        }

        public static DataTable AdditionalGroup_select(long PricecatalogueID)
        {
            return Webstore.AdditionalGroup_select(PricecatalogueID);
        }

        public static DataTable AdditionalOption_Select(int CompanyID, int CategoryID)
        {
            return Webstore.AdditionalOption_Select(CompanyID, CategoryID);
        }

        public static void Assign_ProductCatatoryToAccountsOrCustomer(long categoryID, long customerID, long accountID)
        {
            Webstore.Assign_ProductCatatoryToAccountsOrCustomer(categoryID, customerID, accountID);
        }

        public static DataSet Available_couponCode_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Webstore.Available_couponCode_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static void bannerDelete(int bannerID)
        {
            Webstore.bannerDelete(bannerID);
        }

        public static void bannerImageUpdate(int bannerID, string bannerImage)
        {
            Webstore.bannerImageUpdate(bannerID, bannerImage);
        }

        public static int bannerInsert(int bannerID, int companyID, int accountID, string bannerTitle, string bannerDescription, string bannerImage, string URL, string type, int imageSortOrderNo, string bannerName)
        {
            return Webstore.bannerInsert(bannerID, companyID, accountID, bannerName, bannerTitle, bannerDescription, bannerImage, URL, type, imageSortOrderNo);
        }

        public static void bannerLocationInsert(int bannerID, string location, int pageID)
        {
            Webstore.bannerLocationInsert(bannerID, location, pageID);
        }

        public static DataSet bannerSelect(int bannerID, int companyID, int accountID, string type)
        {
            return Webstore.bannerSelect(bannerID, companyID, accountID, type);
        }

        public static void bannerSort(int bannerID, int companyID, int accountID, int imageSortOrderNo)
        {
            Webstore.bannerSort(bannerID, companyID, accountID, imageSortOrderNo);
        }

        public static DataTable BindBanner(int AccountID, int PageID, string Location, string Page)
        {
            return Webstore.BindBanner(AccountID, PageID, Location, Page);
        }

        public static DataTable Category_ClientDepartment_select(long CustomerID, string Departmentids)
        {
            return Webstore.Category_ClientDepartment_select(CustomerID, Departmentids);
        }

        public static int Check_pages_Duplicacy(long CompanyID, long AccountID, long PageID, string PageName)
        {
            return Webstore.Check_pages_Duplicacy(CompanyID, AccountID, PageID, PageName);
        }

        public static long Checking_ShopCartCostDetails(long webothercostid, long AccountID)
        {
            return Webstore.Checking_ShopCartCostDetails(webothercostid, AccountID);
        }

        public static void client_defaultLand(int CompanyID, int AccountID, int pageID)
        {
            Webstore.client_defaultLand(CompanyID, AccountID, pageID);
        }

        public static void CopyBanners(int BannerID, int AccountID, string Type, string bannerImgName)
        {
            Webstore.CopyBanners(BannerID, AccountID, Type, bannerImgName);
        }

        public static long CouponCode_Insertupdate(long CompanyID, long CouponID, long AccountID, string type, string CouponCode, string FriendlyName, decimal Discount, string DiscountType, bool CanbeuseMultipleTime)
        {
            return Webstore.CouponCode_Insertupdate(CompanyID, CouponID, AccountID, type, CouponCode, FriendlyName, Discount, DiscountType, CanbeuseMultipleTime);
        }

        public static DataSet CouponCode_Select(long CompanyID, long CouponCodeID, long AccountID, string type)
        {
            return Webstore.CouponCode_Select(CompanyID, CouponCodeID, AccountID, type);
        }

        public static void CouponCode_Webstore_Delete_Per_Account(int CompanyID, long CouponCodeID, long AccountID)
        {
            Webstore.CouponCode_Webstore_Delete_Per_Account(CompanyID, CouponCodeID, AccountID);
        }

        public static DataTable CouponCodeOption_Select(int CompanyID, int AccountID)
        {
            return Webstore.CouponCodeOption_Select(CompanyID, AccountID);
        }

        public static long DefaultProductStock_Self_Insert(long PricecatalogueID, long UserID, long CompanyID, DateTime date)
        {
            return Webstore.DefaultProductStock_Self_Insert(PricecatalogueID, UserID, CompanyID, date);
        }

        public static DataTable EmailTags_Select(string TagEvent, int AccountID)
        {
            return Webstore.EmailTags_Select(TagEvent, AccountID);
        }

        public static void EmailToAdmin_EnableUpdate(long CompanyID, string Type)
        {
            Webstore.EmailToAdmin_EnableUpdate(CompanyID, Type);
        }

        public static DataTable EmailToCustomer_Select(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailFor)
        {
            return Webstore.EmailToCustomer_Select(CompanyID, AccountID, EmailToCustomerID, TagEvent, EmailFor);
        }

        public static long EmailToCustomer_Update(long EmailToCustomerID, int CompanyID, int AccountID, string Subject, string Body, int IsActive, DateTime ModifiedDate, string IsEnable, string IsFromCopy, int IsArtwork, int IsOrderPdf, int StatusID, int IsProductName, int IsJobName, int IsQuantity, int IsTotalPrice, int IsOrderedWidth, int IsOrderedHeight, int IsProductWidth, int IsProductHeight, int IsAdditionalOption, int IsItemNumber, int IsItemCode, int IsCustomerCode, int IsUnitOfMeasure, int isItemDescription, int isWeight, int isCubicMeasurment, int isOrderedWeight, int isOrderedCubicMeasurment, int isPerQuantity, int IsDimensions)
        {
            return Webstore.EmailToCustomer_Update(EmailToCustomerID, CompanyID, AccountID, Subject, Body, IsActive, ModifiedDate, IsEnable, IsFromCopy, IsArtwork, IsOrderPdf, StatusID, IsProductName, IsJobName, IsQuantity, IsTotalPrice, IsOrderedWidth, IsOrderedHeight, IsProductWidth, IsProductHeight, IsAdditionalOption, IsItemNumber, IsItemCode, IsCustomerCode, IsUnitOfMeasure, isItemDescription, isWeight, isCubicMeasurment, isOrderedWeight, isOrderedCubicMeasurment, isPerQuantity, IsDimensions);
        }

        public static void estore_phrasebook_delete(int phraseBookID)
        {
            Webstore.estore_phrasebook_delete(new WebstoreItem()
            {
                PhraseBookID = phraseBookID
            });
        }

        public static void estore_phrasebook_insert(int companyID, string phraseType, string phraseText, bool isDefaultPhrase, long AccountID)
        {
            WebstoreItem webstoreItem = new WebstoreItem()
            {
                CompanyID = companyID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                IsDefaultPhrase = isDefaultPhrase,
                AccountID = AccountID
            };
            Webstore.estore_phrasebook_insert(webstoreItem);
        }

        public static DataTable estore_phrasebook_select(int CompanyID, string phraseType, int AccountID)
        {
            return Webstore.estore_phrasebook_select(CompanyID, phraseType, AccountID);
        }

        public static void estore_phrasebook_update(int phraseBookID, string phraseType, string phraseText, bool isDefaultPhrase)
        {
            WebstoreItem webstoreItem = new WebstoreItem()
            {
                PhraseBookID = phraseBookID,
                PhraseType = phraseType,
                PhraseText = phraseText,
                IsDefaultPhrase = isDefaultPhrase
            };
            Webstore.estore_phrasebook_update(webstoreItem);
        }

        public static void EstoreReports_AllocatedCustomers_Delete(long ReportID, long CustomerID, string ReportName, string ModuleName)
        {
            Webstore.EstoreReports_AllocatedCustomers_Delete(ReportID, CustomerID, ReportName, ModuleName);
        }

        public static void EstoreReports_AllocatedCustomers_Insert(long ReportID, long CustomerID, string ReportType, string EstoreReportType)
        {
            Webstore.EstoreReports_AllocatedCustomers_Insert(ReportID, CustomerID, ReportType, EstoreReportType);
        }

        public static DataTable EstoreSystemReport_CustomerCount(string pagename)
        {
            return Webstore.EstoreSystemReport_CustomerCount(pagename);
        }

        public static void FeaturedProducts_Insert(long CompanyID, long AccountID, long PriceCatalogueID, long OrderNo)
        {
            Webstore.FeaturedProducts_Insert(CompanyID, AccountID, PriceCatalogueID, OrderNo);
        }

        public static DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
        {
            return Webstore.FeaturedProducts_Select(CompanyID, AccountID);
        }

        public static void FeaturedProducts_Update(long CompanyID, long AccountID)
        {
            Webstore.FeaturedProducts_Update(CompanyID, AccountID);
        }

        public static DataTable getAutogenerate_ItemCode(int CompanyID)
        {
            return Webstore.getAutogenerate_ItemCode(CompanyID);
        }

        public static DataSet GetCatgoryList(int CompanyID, int AccountID, long StoreUserID)
        {
            return Webstore.GetCatgoryList(CompanyID, AccountID, StoreUserID);
        }

        public static DataTable GetContentByAccountId(long AccountID)
        {
            return Webstore.GetContentByAccountId(AccountID);
        }

        public static DataTable GetEditText(long EditID, long AccountID, long CompanyID)
        {
            return Webstore.GetEditText(EditID, AccountID, CompanyID);
        }

        public static int Group_Insert_Update(long PriceCatalogueGroupID, string GroupName, int companyID)
        {
            return Webstore.Group_Insert_Update(PriceCatalogueGroupID, GroupName, companyID);
        }

        public static void headerInsert(int appID, int companyID, int accountID, string logoImage, string logoText, string logoTemplate, string logoType, string type, bool IsLogoEnlarged, bool IsLogoResized, int LogoResizedsize)
        {
            Webstore.headerInsert(appID, companyID, accountID, logoImage, logoText, logoTemplate, logoType, type, IsLogoEnlarged, IsLogoResized, LogoResizedsize);
        }

        public static DataTable headerSelect(int CompanyID, int AccountID, string type)
        {
            return Webstore.headerSelect(CompanyID, AccountID, type);
        }

        public static DataTable homePageSelect(long pageID, int CompanyID, int AccountID)
        {
            return Webstore.homePageSelect(pageID, CompanyID, AccountID);
        }

        public static long homePageUpdate(long pageID, int IsSliddingBanners, string CenterPanelText, string CenterPanelOption, string CustomText)
        {
            return Webstore.homePageUpdate(pageID, IsSliddingBanners, CenterPanelText, CenterPanelOption, CustomText);
        }

        public static void ImageGallery_Insert(long UserID, long CompanyID, string ImageName, string type)
        {
            Webstore.ImageGallery_Insert(UserID, CompanyID, ImageName, type);
        }

        public static DataTable ImageGallery_Select(long UserID, long CompanyID)
        {
            return Webstore.ImageGallery_Select(UserID, CompanyID);
        }

        public static void InsertUpdate_Custom_Alphbetic_Order(bool IsAlphabticOrder, bool IsCustomOrder, long CompanyID, long AccountID, string Module)
        {
            Webstore.InsertUpdate_Custom_Alphbetic_Order(IsAlphabticOrder, IsCustomOrder, CompanyID, AccountID, Module);
        }

        public static bool IsApprovalFeaturesOn_Select(long CompanyID)
        {
            return Webstore.IsApprovalFeaturesOn_Select(CompanyID);
        }

        public static void Orderingprocess_settings(int companyID, int accountID, bool Is_Select_AllCartItems, bool IsHideMISJob, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool IsHideMISInvoice, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, string jobScreenName, bool jobScreenNameShow, bool jobScreenNameRequired,
            bool attachConNumToUrl)
        {
            Webstore.Orderingprocess_settings(companyID, accountID, Is_Select_AllCartItems, IsHideMISJob, Is_Only_User_Jobs, Is_Only_User_DepartmentJobs, Is_User_All_Jobs, IsHideMISInvoice, Is_only_User_Invoice, Is_only_user_DepartmentInvoice, Is_User_All_Invoice, Is_Only_User_Orders, Is_Only_User_DepartmentOrders, Is_User_All_Orders, jobScreenName, jobScreenNameShow, jobScreenNameRequired,
                attachConNumToUrl);
        }

        public static DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            return Webstore.OrderMangerOptions_Select(CompanyID, AccountID);
        }

        public static void OtherCost_WebStore_AllocatetoOtherAccounts(int WebOtherCostID, int AccountID, string AccountType)
        {
            Webstore.OtherCost_WebStore_AllocatetoOtherAccounts(WebOtherCostID, AccountID, AccountType);
        }

        public static void Othercost_Webstore_Delete(int CompanyID, long webothercostid)
        {
            Webstore.Othercost_Webstore_Delete(CompanyID, webothercostid);
        }

        public static void Othercost_Webstore_Delete_Per_Account(int CompanyID, long webothercostid, long AccountID, string Type)
        {
            Webstore.Othercost_Webstore_Delete_Per_Account(CompanyID, webothercostid, AccountID, Type);
        }

        public static long OtherCost_WebStore_Insertupdate(long webothercostid, long CompanyID, long UserID, string webothercostName, string Description, string UserFriendlyName, long CategoryId, string MainCalculationType, string AdditionalType, int VisibletoCart, int SupplierID, bool IsSubAdditionOption, bool IsMandatory)
        {
            return Webstore.OtherCost_WebStore_Insertupdate(webothercostid, CompanyID, UserID, webothercostName, Description, UserFriendlyName, CategoryId, MainCalculationType, AdditionalType, VisibletoCart, SupplierID, IsSubAdditionOption, IsMandatory);
        }

        public static long OtherCost_WebStore_Insertupdate_ShopCartCost(long webothercostid, long CompanyID, long UserID, string webothercostName, string Description, string UserFriendlyName, long CategoryId, string MainCalculationType, string AdditionalType, int VisibletoCart, long AccountID, string AllocationStatus, bool IsCartmandatory, bool IsSubAdditionOption)
        {
            return Webstore.OtherCost_WebStore_Insertupdate_ShopCartCost(webothercostid, CompanyID, UserID, webothercostName, Description, UserFriendlyName, CategoryId, MainCalculationType, AdditionalType, VisibletoCart, AccountID, AllocationStatus, IsCartmandatory, IsSubAdditionOption);
        }

        public static DataTable OtherCost_WebStore_Select(long webothercostid, long CompanyID, long UserID)
        {
            return Webstore.OtherCost_WebStore_Select(webothercostid, CompanyID, UserID);
        }

        public static void Othercost_WebstoreChoice_Delete(long webothercostid, long ChoiceID)
        {
            Webstore.Othercost_WebstoreChoice_Delete(webothercostid, ChoiceID);
        }

        public static void Othercost_WebstoreChoice_Insertupdate(long ChoiceID, long webothercostid, string Label, string CalculationType, string Formula, decimal Markup, long InventoryID, int sortorder, int Reorderposition, long GroupID, int SubadditionCount, bool IsMandatoryField)
        {
            Webstore.Othercost_WebstoreChoice_Insertupdate(ChoiceID, webothercostid, Label, CalculationType, Formula, Markup, InventoryID, sortorder, Reorderposition, GroupID, SubadditionCount, IsMandatoryField);
        }

        public static DataTable Othercost_WebstoreChoice_Select(long webothercostid)
        {
            return Webstore.Othercost_WebstoreChoice_Select(webothercostid);
        }

        public static void Othercost_WebstoreMatrix_Delete(long webothercostid, long MatrixID)
        {
            Webstore.Othercost_WebstoreMatrix_Delete(webothercostid, MatrixID);
        }

        public static void Othercost_WebstoreMatrix_Insertupdate(long MatrixID, long webothercostid, string MatrixType, int FromQuantity, int ToQuantity, decimal Price, decimal Markup, decimal sellingPrice, int Reorderposition)
        {
            Webstore.Othercost_WebstoreMatrix_Insertupdate(MatrixID, webothercostid, MatrixType, FromQuantity, ToQuantity, Price, Markup, sellingPrice, Reorderposition);
        }

        public static DataTable Othercost_WebstoreMatrix_Select(long webothercostid)
        {
            return Webstore.Othercost_WebstoreMatrix_Select(webothercostid);
        }

        public static void Othercost_WebstoreQuestion_Delete(long webothercostid)
        {
            Webstore.Othercost_WebstoreQuestion_Delete(webothercostid);
        }

        public static void Othercost_WebstoreQuestion_Insertupdate(long QuestionID, long webothercostid, string Question, string formula)
        {
            Webstore.Othercost_WebstoreQuestion_Insertupdate(QuestionID, webothercostid, Question, formula);
        }
        public static void Othercost_WebstoreFreeTextQuestion_Insertupdate(long QuestionID, long webothercostid, string Question, string formula, bool HideAdditionalName, bool chkMandatory)
        {
            Webstore.Othercost_WebstoreFreeTextQuestion_Insertupdate(QuestionID, webothercostid, Question, formula, HideAdditionalName, chkMandatory);
        }

        public static DataTable Othercost_WebstoreQuestion_Select(long webothercostid)
        {
            return Webstore.Othercost_WebstoreQuestion_Select(webothercostid);
        }

        public static DataTable OtherMultiple_DefaultItem_Select(long ProductCatalogueID)
        {
            return Webstore.OtherMultiple_DefaultItem_Select(ProductCatalogueID);
        }

        public static void pageDelete(int pageID)
        {
            Webstore.pageDelete(pageID);
        }

        public static DataTable pagesDetails(int pageID, int CompanyID, int AccountID)
        {
            return Webstore.pagesDetails(pageID, CompanyID, AccountID);
        }

        public static int pagesInsert(int pageID, int companyID, int accountID, string systemName, string pageName, DateTime modifiedDate, int sortOrderID, string pageBody, string metatitle, string metadescription, string metakeywords, char showPagesIn, DateTime createdDate)
        {
            return Webstore.pagesInsert(pageID, companyID, accountID, systemName, pageName, modifiedDate, sortOrderID, pageBody, metatitle, metadescription, metakeywords, showPagesIn, createdDate);
        }

        public static DataTable pagesSelect(int CompanyID, int AccountID, string type)
        {
            return Webstore.pagesSelect(CompanyID, AccountID, type);
        }

        public static void pagesSort(int pageID, int companyID, int accountID, int sortOrderID)
        {
            Webstore.pagesSort(pageID, companyID, accountID, sortOrderID);
        }

        public static void paymentInsert(int PaymentID, int companyID, int accountID, string paymentMode, string defaultPaymentMode, string creaditCardTypes, string CreditCardBrainTreeTypes, string CreditCardStripeTypes, int IsEnable)
        {
            Webstore.paymentInsert(PaymentID, companyID, accountID, paymentMode, defaultPaymentMode, creaditCardTypes, CreditCardBrainTreeTypes, CreditCardStripeTypes, IsEnable);
        }

        public static DataTable paymentSelect(int CompanyID, int AccountID)
        {
            return Webstore.paymentSelect(CompanyID, AccountID);
        }

        public static void pricecatalogue_Categorycustomer_delete(long PriceCatalogueCategoryID, long PriceCategoryCustomerID)
        {
            Webstore.pricecatalogue_Categorycustomer_delete(PriceCatalogueCategoryID, PriceCategoryCustomerID);
        }

        public static void pricecatalogue_other_delete(int ProductCatalogueID)
        {
            Webstore.pricecatalogue_other_delete(ProductCatalogueID);
        }

        public static DataTable pricecatalogue_other_select(int ProductCatalogueID)
        {
            return Webstore.pricecatalogue_other_select(ProductCatalogueID);
        }

        public static DataTable OtherProductStockAllocationExist(long CompanyID,long ProductCatalogueID)
        {
            return Webstore.OtherProductStockAllocationExist(CompanyID,ProductCatalogueID);
        }

        public static DataTable pricecataloguecategory_allocatedcustomer_select(long PriceCatalogueCategoryID, long CompanyID)
        {
            return Webstore.pricecataloguecategory_allocatedcustomer_select(PriceCatalogueCategoryID, CompanyID);
        }

        public static void PriceCatalogueCustomer_Delete(long PriceCatalogueID)
        {
            Webstore.PriceCatalogueCustomer_Delete(PriceCatalogueID);
        }

        public static void PriceCatalogueCustomer_Insert(long PriceCatalogueID, long CustomerID, long AccountID, string customerType)
        {
            Webstore.PriceCatalogueCustomer_Insert(PriceCatalogueID, CustomerID, AccountID, customerType);
        }

        public static void PriceCatalogueCustomer_Public_Delete(long PriceCatalogueID)
        {
            Webstore.PriceCatalogueCustomer_Public_Delete(PriceCatalogueID);
        }

        public static DataTable PriceCatalogueCustomer_Select(long PriceCatalogueID, string Type)
        {
            return Webstore.PriceCatalogueCustomer_Select(PriceCatalogueID, Type);
        }

        public static string pricecataloguestock_actiontype_check(long PricecatalogueID, string From)
        {
            return Webstore.pricecataloguestock_actiontype_check(PricecatalogueID, From);
        }

        public static string pricecataloguestock_actiontype_checkAdditional(long ProductCatalogueID)
        {
            return Webstore.pricecataloguestock_actiontype_checkAdditional(ProductCatalogueID);
        }

        public static long pricecataloguestock_additional_insert(int id, string optionname, string optionvalue, int openingstock, string customfield1, string customfield2, string customfield3, string customfield4, string customfield5, string customfield6, int webothercostid, int UserID, DateTime date, decimal price, string actiontype, int choiceid, string Notes)
        {
            return Webstore.pricecataloguestock_additional_insert(id, optionname, optionvalue, openingstock, customfield1, customfield2, customfield3, customfield4, customfield5, customfield6, webothercostid, UserID, date, price, actiontype, choiceid, Notes);
        }

        public static DataTable pricecataloguestock_additional_select(int ProductCatalogueID)
        {
            return Webstore.pricecataloguestock_additional_select(ProductCatalogueID);
        }

        public static void pricecataloguestock_AdditionalAdjustments_update(long AdditionalStockID, char Operator, int AdjustQty, long PricecatalogueID, long UserID, string AdjustmentType, long ChoiceID, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6)
        {
            Webstore.pricecataloguestock_AdditionalAdjustments_update(AdditionalStockID, Operator, AdjustQty, PricecatalogueID, UserID, AdjustmentType, ChoiceID, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6);
        }

        public static void pricecataloguestock_additionaloption_Delete(int ProductCatalogueID)
        {
            Webstore.pricecataloguestock_additionaloption_Delete(ProductCatalogueID);
        }

        public static DataTable pricecataloguestock_additionaloptions_stocklevels(long ProductCatalogueID)
        {
            return Webstore.pricecataloguestock_additionaloptions_stocklevels(ProductCatalogueID);
        }

        public static void pricecataloguestock_adjustments_update(long StockselfID, char Operator, int AdjustQty, long PricecatalogueID, long UserID, string AdjustmentType, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6,string ManualNotes)
        {
            Webstore.pricecataloguestock_adjustments_update(StockselfID, Operator, AdjustQty, PricecatalogueID, UserID, AdjustmentType, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6,ManualNotes);
        }

        public static DataSet pricecataloguestock_history_select(long ProductCatalogueID, int PageSize, int PageNumber, string WhereCondition)
        {
            return Webstore.pricecataloguestock_history_select(ProductCatalogueID, PageSize, PageNumber, WhereCondition);
        }

        public static void pricecataloguestock_other_insert(int ProductCatalogueID, long kititemid, int unit, int UserID)
        {
            Webstore.pricecataloguestock_other_insert(ProductCatalogueID, kititemid, unit, UserID);
        }
        public static void pricecataloguestock_other_update(int id,int ProductCatalogueID, long kititemid, int unit, int UserID)
        {
            Webstore.pricecataloguestock_other_update(id,ProductCatalogueID, kititemid, unit, UserID);
        }
        public static void pricecataloguestock_other_delete(int id)
        {
            Webstore.pricecataloguestock_other_delete(id);
        }
        public static void pricecataloguestock_othermultiple_insert(int ProductCatalogueID, long KitItemID, int isdefault, int UserID)
        {
            Webstore.pricecataloguestock_othermultiple_insert(ProductCatalogueID, KitItemID, isdefault, UserID);
        }

        public static DataTable Pricecataloguestock_Othermultiple_select(long PricecatalogueID)
        {
            return Webstore.Pricecataloguestock_Othermultiple_select(PricecatalogueID);
        }

        public static void pricecataloguestock_Quantity_Update(long ProductCatalogueID, int TotalQuantity, int AvailableQuantity, int AllocatedQuantity)
        {
            Webstore.pricecataloguestock_Quantity_Update(ProductCatalogueID, TotalQuantity, AvailableQuantity, AllocatedQuantity);
        }

        public static void pricecataloguestock_self_delete(int PricecatalogueID)
        {
            Webstore.pricecataloguestock_self_delete(PricecatalogueID);
        }

        public static long pricecataloguestock_self_insert(int PricecatalogueID, int openingstock, string Customfield1, string Customfield2, string Customfield3, string Customfield4, string Customfield5, string Customfield6, decimal Price, int UserID, DateTime date, string actiontype, string Notes,string ManualNotes)
        {
            return Webstore.pricecataloguestock_self_insert(PricecatalogueID, openingstock, Customfield1, Customfield2, Customfield3, Customfield4, Customfield5, Customfield6, Price, UserID, date, actiontype, Notes,ManualNotes);
        }

        public static DataTable pricecataloguestock_self_select(int ProductCatalogueID)
        {
            return Webstore.pricecataloguestock_self_select(ProductCatalogueID);
        }

        public static void pricecataloguestock_stockdetails_update(int ProductCatalogueID, string DrawStockFrom, int ReorderLevel, int ReorderQty, string AlertUser, string UserEmail, int TotalQuantity, int AllocatedQuantity, int AvailableQuantity, bool detail)
        {
            Webstore.pricecataloguestock_stockdetails_update(ProductCatalogueID, DrawStockFrom, ReorderLevel, ReorderQty, AlertUser, UserEmail, TotalQuantity, AllocatedQuantity, AvailableQuantity, detail);
        }

        public static void Product_CatalogueCouponCode_insert(int CompanyID, long PriceCatalogueID, long CouponCodeID)
        {
            Webstore.Product_CatalogueCouponCode_insert(CompanyID, PriceCatalogueID, CouponCodeID);
        }

        public static DataTable Product_CatalogueCouponCode_Select(long CompanyID, long PriceCatalogueID)
        {
            return Webstore.Product_CatalogueCouponCode_Select(CompanyID, PriceCatalogueID);
        }

        public static void ProductCatalogue_CouponCode_Delete(long CompanyID, long PriceCatalogueID)
        {
            Webstore.ProductCatalogue_CouponCode_Delete(CompanyID, PriceCatalogueID);
        }

        public static int ProductCatalogueCategory_Insert_Update(long PriceCatalogueCategoryID, string catagoryName, string description, string catagoryType, int companyID, long userID, string catagoryImage, long ParentCategoryID, int IsCategoryVisible, bool Isallocated, bool IsApprovalNotRequired)
        {
            return Webstore.ProductCatalogueCategory_Insert_Update(PriceCatalogueCategoryID, catagoryName, description, catagoryType, companyID, userID, catagoryImage, ParentCategoryID, IsCategoryVisible, Isallocated, IsApprovalNotRequired);
        }

        public static DataTable ProductCatalogueCategory_Select(int category)
        {
            return Webstore.ProductCatalogueCategory_Select(category);
        }

        public static DataSet ProductCatalogueCategory_SelectViewAll(int companyID, int userID, string sortedBy, string sortdirection, string whereCondition)
        {
            return Webstore.ProductCatalogueCategory_SelectViewAll(companyID, userID, sortedBy, sortdirection, whereCondition);
        }

        public static void ProductCatalogueCategory_UpdateImage(int CategoryID, string catagoryImage)
        {
            Webstore.ProductCatalogueCategory_UpdateImage(CategoryID, catagoryImage);
        }

        public static void ProductCatalogueCategoryCustomer_Delete(long categoryID)
        {
            Webstore.ProductCatalogueCategoryCustomer_Delete(categoryID);
        }

        public static long ProductCatalogueCategoryCustomer_Insert(long categoryID, long customerID, long accountID, string catagoryType, long DepartmentID, string DeptAllocationType)
        {
            return Webstore.ProductCatalogueCategoryCustomer_Insert(categoryID, customerID, accountID, catagoryType, DepartmentID, DeptAllocationType);
        }

        public static void ProductCatalogueCategoryCustomer_Public_Delete(long categoryID)
        {
            Webstore.ProductCatalogueCategoryCustomer_Public_Delete(categoryID);
        }

        public static DataTable ProductCatalogueCategoryCustomer_Select(long categoryID, long accountID)
        {
            return Webstore.ProductCatalogueCategoryCustomer_Select(categoryID, accountID);
        }

        public static long ProductCatalogueGroup_Insert(long ProductWebOtherCostid, long GroupID, long WebOthercostID, bool IsAllocated, string WebOtherCostName)
        {
            return (long)Webstore.ProductCatalogueGroup_Insert(ProductWebOtherCostid, GroupID, WebOthercostID, IsAllocated, WebOtherCostName);
        }

        public static DataTable ProductCatalogueGroup_SelectViewAll(int CompanyID, long PriceCatalogueGroupID, string searchgroupName)
        {
            return Webstore.ProductCatalogueGroup_SelectViewAll(CompanyID, PriceCatalogueGroupID, searchgroupName);
        }

        public static DataTable JobItem_Select(int CompanyID, string jobItem, long StatusId)
        {
            return Webstore.JobItem_Select(CompanyID, jobItem, StatusId);
        }
        public static DataTable JobItemStatus_Select(int CompanyID, string statustitle)
        {
            return Webstore.JobItemStatus_Select(CompanyID, statustitle);
        }
        public static void ProductCategory_CustomerDepartment_insert(long PriceCategoryCustomerID, long DepartmentID)
        {
            Webstore.ProductCategory_CustomerDepartment_insert(PriceCategoryCustomerID, DepartmentID);
        }

        public static void productCategory_Delete(int catagoryID)
        {
            Webstore.productCategory_Delete(catagoryID);
        }

        public static void productGroup_Delete(int GroupID)
        {
            Webstore.productGroup_Delete(GroupID);
        }

        public static void ProductGroupSubAdditionalOptions_Delete(long PriceCatalogueGroupID)
        {
            Webstore.ProductGroupSubAdditionalOptions_Delete(PriceCatalogueGroupID);
        }

        public static DataSet ProductJobList_Select(long PriceCatalogueID, string SearchParameter)
        {
            return Webstore.ProductJobList_Select(PriceCatalogueID, SearchParameter);
        }

        public static DataTable products_Select(long CompanyID, long AccountID)
        {
            return Webstore.products_Select(CompanyID, AccountID);
        }

        public static DataTable products_Select_Select_Basedon_CatID(long CompanyID, long AccountID, long PriceCatalogueCategoryID)
        {
            return Webstore.products_Select_Select_Basedon_CatID(CompanyID, AccountID, PriceCatalogueCategoryID);
        }

        public static void ProductsReorder_Delete(long CompanyID, long AccountID, int key,int catid)
        {
            Webstore.ProductsReorder_Delete(CompanyID, AccountID, key,catid);
        }

        public static void ProductsReorder_Insert_Update(int CompanyID, int AccountID, int PriceCatalogueID, int SortOrderNo, int ClientID,int CatID)
        {
            Webstore.ProductsReorder_Insert_Update(CompanyID, AccountID, PriceCatalogueID, SortOrderNo, ClientID, CatID);
        }

        public static DataTable PublicAccount_List_Select(long CompanyID, string accounttype)
        {
            return Webstore.PublicAccount_List_Select(CompanyID, accounttype);
        }

        public static void PublicSettings_Options(int accountID, int Order_Check, int Address_Check)
        {
            Webstore.PublicSettings_Options(accountID, Order_Check, Address_Check);
        }

        public static DataTable RestrictedUser(long CompanyID)
        {
            return Webstore.RestrictedUser(CompanyID);
        }

        public static void Retaining_ShopCartCostDetails_To_OtherAccounts(long webothercostid, long CompanyID, long AccountID)
        {
            Webstore.Retaining_ShopCartCostDetails_To_OtherAccounts(webothercostid, CompanyID, AccountID);
        }

        public static DataTable Select_ConsignmentNote(long StoreUserID, long OrderID)
        {
            return Webstore.Select_ConsignmentNote(StoreUserID, OrderID);
        }

        public static DataTable Select_Custom_OR_Alphbetic_Order(long CompanyID, long AccountID, string Module)
        {
            return Webstore.Select_Custom_OR_Alphbetic_Order(CompanyID, AccountID, Module);
        }

        public static DataSet Select_Inventory_PopUp_Select(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Webstore.Select_Inventory_PopUp_Select(CompanyID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static DataTable Select_InventoryProperties(int CompanyID, long InventoryID)
        {
            return Webstore.Select_InventoryProperties(CompanyID, InventoryID);
        }

        public static DataSet select_ItemDetalis_ForProduct(int CompanyID, long EstimateID, long EstItemID, string EstType)
        {
            return Webstore.select_ItemDetalis_ForProduct(CompanyID, EstimateID, EstItemID, EstType);
        }

        public static DataTable Select_OrderAdditionalItems(long OrderItemID)
        {
            return Webstore.Select_OrderAdditionalItems(OrderItemID);
        }

        public static DataTable Select_OrderAdditionalOptions(long StoreUserID, long OrderID)
        {
            return Webstore.Select_OrderAdditionalOptions(StoreUserID, OrderID);
        }

        public static DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            return Webstore.Select_OrderItems(OrderID, StoreUserID);
        }

        public static DataTable Select_ProductCategory_based_on_accountid(long CompanyID, string PageType, int AccountID)
        {
            return Webstore.Select_ProductCategory_based_on_accountid(CompanyID, PageType, AccountID);
        }

        public static DataTable Select_ProductCategory_List(long CompanyID, string PageType, long PriceCatalogueCategoryID)
        {
            return Webstore.Select_ProductCategory_List(CompanyID, PageType, PriceCatalogueCategoryID);
        }

        public static DataTable Select_ProductDetailsTag(int CompanyID, int AccountID, long EmailToCustomerID)
        {
            return Webstore.Select_ProductDetailsTag(CompanyID, AccountID, EmailToCustomerID);
        }

        public static int Select_WebOtherCostID(int GroupID)
        {
            return Webstore.Select_WebOtherCostID(GroupID);
        }

        public static string SelectAccountType(int AccountID)
        {
            return Webstore.SelectAccountType(AccountID);
        }

        public static DataTable SelectRadioButtonStatus(int CompanyID, int AccountID)
        {
            return Webstore.SelectRadioButtonStatus(CompanyID, AccountID);
        }

        public static int Settings_Product_Catalogue_InsertUpdate(int CompanyID, int PriceCatalogueID, string itemcode, string CategoryName, string CatalogueName, string Description, int UserID, int PriceCatalogueCategoryID, string ItemTitle, string Artwork, string Color, string Size, string Material, string Delivery, string Finishing, string Notes, string Terms, string MatrixType, string Proofs, string Packing, string ProductImage, string ArtworkFile, int ProductVisible, string ShortDescription, string ItemDescription, int UnitOfMeasure, int ArtworkCount, string CustomerType, int IsSides, int IsPrintReadyFile, int IsShortDescription, int IsItemDescription, int IsPriceStartFrom, int IsPriceList, bool IsUploadMandatory, int SupplierID, string CustomDescription1, string CustomDescription2, string CustomDescription3, string CustomDescription4, string CustomDescription5, string CustomDescription6, string CustomDescription7, string CustomDescription8, string CustomDescription9, string CustomDescription10, string CustomDescription11, string CustomDescription12, string CustomDescription13, string CustomDescription14, string CustomDescription15, string CustomDescription16, string CustomDescription17, string CustomDescription18, string CustomDescription19, string CustomDescription20, string CustomDescription21, string CustomDescription22, string CustomDescription23, string CustomDescription24, string CustomDescription25, int IsEditableProduct, int IsStockItem, int IsBackOrder, int IsShowStock, int OwnerID, long EstItemID, string EstType, string CustomerCode, int SoldInPacks, int IsShowSoldInPacks, bool AllowGroupRun, bool isCustomerCode, bool isItemcode, int IsShowPriceSubtotalTax, int IsShowUnitPrice, int IsShowPackPrice, bool IsShowJobName, bool isQuickitemadd, bool isAddtoCartandStay, bool IsCumulativePricing, bool IsDisplayAdditionalOptions, string drawStockFrom, int SalesTaxRate, int PressNameID, int DefaultPreflightProfile, string Decoration1_Title, string Decoration2_Title, string Decoration3_Title, string Decoration4_Title, string Decoration5_Title, string Decoration6_Title, string Decoration1_Name, string Decoration2_Name, string Decoration3_Name, string Decoration4_Name, string Decoration5_Name, string Decoration6_Name, string Decoration1_Description, string Decoration2_Description, string Decoration3_Description, string Decoration4_Description, string Decoration5_Description, string Decoration6_Description, double Decoration1_SetupCost, double Decoration2_SetupCost, double Decoration3_SetupCost, double Decoration4_SetupCost, double Decoration5_SetupCost, double Decoration6_SetupCost, double Decoration1_PerItemCost, double Decoration2_PerItemCost, double Decoration3_PerItemCost, double Decoration4_PerItemCost, double Decoration5_PerItemCost, double Decoration6_PerItemCost, double Decoration1_MinimiumCost, double Decoration2_MinimiumCost, double Decoration3_MinimiumCost, double Decoration4_MinimiumCost, double Decoration5_MinimiumCost, double Decoration6_MinimiumCost, Boolean Decoration1_Mandadory, Boolean Decoration2_Mandadory, Boolean Decoration3_Mandadory, Boolean Decoration4_Mandadory, Boolean Decoration5_Mandadory, Boolean Decoration6_Mandadory,long FTPFolderID, string Prefix,string FTPFileName,string FTPFileType, int AccountingCode = 0, int isWaterMarkReady = 0, string waterMarkText = "", double CBMHeight = 0.00, double CBMWidth = 0.00, double CBMLength = 0.00, double CBMWeight = 0.00, double CBMMeasurement = 0.00, bool IsCBM = false, int PurAccountingCode = 0, double PerQuantity = 0.00, double VolumetricWeight = 0.00)
        {
            return Webstore.Settings_Product_Catalogue_InsertUpdate(CompanyID, PriceCatalogueID, itemcode, CategoryName, CatalogueName, Description, UserID, PriceCatalogueCategoryID, ItemTitle, Artwork, Color, Size, Material, Delivery, Finishing, Notes, Terms, MatrixType, Proofs, Packing, ProductImage, ArtworkFile, ProductVisible, ShortDescription, ItemDescription, UnitOfMeasure, ArtworkCount, CustomerType, IsSides, IsPrintReadyFile, IsShortDescription, IsItemDescription, IsPriceStartFrom, IsPriceList, IsUploadMandatory, SupplierID, CustomDescription1, CustomDescription2, CustomDescription3, CustomDescription4, CustomDescription5, CustomDescription6, CustomDescription7, CustomDescription8, CustomDescription9, CustomDescription10, CustomDescription11, CustomDescription12, CustomDescription13, CustomDescription14, CustomDescription15, CustomDescription16, CustomDescription17, CustomDescription18, CustomDescription19, CustomDescription20, CustomDescription21, CustomDescription22, CustomDescription23, CustomDescription24, CustomDescription25, IsEditableProduct, IsStockItem, IsBackOrder, IsShowStock, OwnerID, EstItemID, EstType, CustomerCode, SoldInPacks, IsShowSoldInPacks, AllowGroupRun, isCustomerCode, isItemcode, IsShowPriceSubtotalTax, IsShowUnitPrice, IsShowPackPrice, IsShowJobName, isQuickitemadd, isAddtoCartandStay, IsCumulativePricing, IsDisplayAdditionalOptions, drawStockFrom, SalesTaxRate, PressNameID, DefaultPreflightProfile, Decoration1_Title, Decoration2_Title, Decoration3_Title, Decoration4_Title, Decoration5_Title, Decoration6_Title, Decoration1_Name, Decoration2_Name, Decoration3_Name, Decoration4_Name, Decoration5_Name, Decoration6_Name, Decoration1_Description, Decoration2_Description, Decoration3_Description, Decoration4_Description, Decoration5_Description, Decoration6_Description, Decoration1_SetupCost, Decoration2_SetupCost, Decoration3_SetupCost, Decoration4_SetupCost, Decoration5_SetupCost, Decoration6_SetupCost, Decoration1_PerItemCost, Decoration2_PerItemCost, Decoration3_PerItemCost, Decoration4_PerItemCost, Decoration5_PerItemCost, Decoration6_PerItemCost, Decoration1_MinimiumCost, Decoration2_MinimiumCost, Decoration3_MinimiumCost, Decoration4_MinimiumCost, Decoration5_MinimiumCost, Decoration6_MinimiumCost, Decoration1_Mandadory, Decoration2_Mandadory, Decoration3_Mandadory, Decoration4_Mandadory, Decoration5_Mandadory, Decoration6_Mandadory,FTPFolderID,Prefix,FTPFileName,FTPFileType, AccountingCode, isWaterMarkReady, waterMarkText, CBMHeight, CBMWidth, CBMLength, CBMWeight, CBMMeasurement, IsCBM, PurAccountingCode, PerQuantity, VolumetricWeight);
        }

        public static DataTable Settings_Product_Catalogue_Select(int CompanyID, int PriceCatalogueID)
        {
            return Webstore.Settings_Product_Catalogue_Select(CompanyID, PriceCatalogueID);
        }

        public static void settings_Product_CatalogueAdditional_Delete(long CompanyID, long PriceCatalogueID, string WebOtherCostIDs)
        {
            Webstore.settings_Product_CatalogueAdditional_Delete(CompanyID, PriceCatalogueID, WebOtherCostIDs);
        }

        public static void settings_Product_CatalogueAdditional_insert(int CompanyID, long PriceCatalogueID, long WebOtherCostID, long AdditionalGroupID)
        {
            Webstore.settings_Product_CatalogueAdditional_insert(CompanyID, PriceCatalogueID, WebOtherCostID, AdditionalGroupID);
        }

        public static DataTable settings_Product_CatalogueAdditional_Select(long CompanyID, long PriceCatalogueID)
        {
            return Webstore.settings_Product_CatalogueAdditional_Select(CompanyID, PriceCatalogueID);
        }

        public static void settings_Product_CatalogueImage_Update(long CompanyID, long PriceCatalogueID, string ProductImage, string ImageOrPdfFile, bool ForceUser, string ReportFileName)
        {
            Webstore.settings_Product_CatalogueImage_Update(CompanyID, PriceCatalogueID, ProductImage, ImageOrPdfFile, ForceUser, ReportFileName);
        }

        public static void Settings_Product_CatalogueQty_delete(int PriceCatalogueID)
        {
            Webstore.Settings_Product_CatalogueQty_delete(PriceCatalogueID);
        }

        public static void settings_Product_CatalogueQty_insert(int CompanyID, int PriceCatalogueID, decimal FromQuantity, decimal ToQuantity, decimal Price, decimal Markup, decimal SellingPrice, decimal Weight, decimal Width, decimal Height, decimal Length, bool HideOnEStore)
        {
            Webstore.settings_Product_CatalogueQty_insert(CompanyID, PriceCatalogueID, FromQuantity, ToQuantity, Price, Markup, SellingPrice, Weight, Width, Height, Length,HideOnEStore);
        }

        public static DataTable settings_Product_CatalogueQty_Select(long PriceCatalogueID)
        {
            return Webstore.settings_Product_CatalogueQty_Select(PriceCatalogueID);
        }

        public static DataTable settings_Product_Matrix_EnableCheck(long PriceCatalogueID)
        {
            return Webstore.settings_Product_Matrix_EnableCheck(PriceCatalogueID);
        }

        public static int settingsWeb_othercostduplicacy_check(long CompanyID, string webothercostName, long webothercostid)
        {
            return Webstore.settingsWeb_othercostduplicacy_check(CompanyID, webothercostName, webothercostid);
        }

        public static long SettingsWebStore_OtherCost_Copy(int CompanyID, long WebOtherCostID)
        {
            return Webstore.SettingsWebStore_OtherCost_Copy(CompanyID, WebOtherCostID);
        }

        public static long SettingsWebStore_OtherCost_Copy_ShopCartCost(int CompanyID, long WebOtherCostID)
        {
            return Webstore.SettingsWebStore_OtherCost_Copy_ShopCartCost(CompanyID, WebOtherCostID);
        }

        public static DataSet SettingsWebStore_OtherCost_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string AdditionalType, bool IsSubAdditionOption)
        {
            return Webstore.SettingsWebStore_OtherCost_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, AdditionalType, IsSubAdditionOption);
        }

        public static DataSet SettingsWebStore_OtherCost_PageText_ShopCartCost(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string AdditionalType, long AccountID)
        {
            return Webstore.SettingsWebStore_OtherCost_PageText_ShopCartCost(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, AdditionalType, AccountID);
        }

        public static void ShowOrderInformation_Update(long accountId, long companyId, string lbl_OrderTitle, string lbl_OrdNum, string lbl_DelReq, string lbl_Comments, string lbl_costcenter, string txt_OrdTit_Screen, string txt_OrdNum_Screen, string txt_DelReq_Screen, string txt_Comments_Screen, string txt_costcenter_screen, bool chk_OrdTit_Show, bool chk_OrdNum_Show, bool chk_DelReq_Show, bool chek_Comments_Show, bool chk_OrdTit_Req, bool chk_OrdNum_Req, bool chk_DelReq_Req, bool chk_Comments_Req, bool chkCostCenter_Req, bool Chk_Mandotory_Del, bool chk_Mandotory_Inv, bool Chk_Display_Del, bool Chk_Display_Inv, bool chk_EnableOrder, bool Chk_EnableAddress, int EstimateDelivery, int ddlWorkingdaysFrom, int ddlWorkingDaysTo,CheckBoxList chkColumnsList,string dateType,String dateRange, bool isDisplayDates = false)
        {
            Webstore.ShowOrderInformation_Update(accountId, companyId, lbl_OrderTitle, lbl_OrdNum, lbl_DelReq, lbl_Comments, lbl_costcenter, txt_OrdTit_Screen, txt_OrdNum_Screen, txt_DelReq_Screen, txt_Comments_Screen, txt_costcenter_screen, chk_OrdTit_Show, chk_OrdNum_Show, chk_DelReq_Show, chek_Comments_Show, chk_OrdTit_Req, chk_OrdNum_Req, chk_DelReq_Req, chk_Comments_Req, chkCostCenter_Req, Chk_Mandotory_Del, chk_Mandotory_Inv, Chk_Display_Del, Chk_Display_Inv, chk_EnableOrder, Chk_EnableAddress, EstimateDelivery, ddlWorkingdaysFrom, ddlWorkingDaysTo,  chkColumnsList, dateType, dateRange, isDisplayDates);
        }

        public static DataTable stockcustomfields_select(int CompanyID)
        {
            return Webstore.stockcustomfields_select(CompanyID);
        }

        public static DataTable stockmanagementsettings_select(int CompanyID)
        {
            return Webstore.stockmanagementsettings_select(CompanyID);
        }

        public static void stockmanagementsettings_update(string SA_eprintmisjobs, int SA_EprintJobstatusID, string SA_EstoreOrdersJobs, int SA_EstoreJobstatusID, string SR_StockReductionMethod, int SR_IsStockPickSingleLocation, string SR_WhenStockReduced, int SR_JobStatusID, string SC_IFJobCancelled, int StatusMessage, int CompanyID, int UserID, int Replenish_JobStatusID,string SA_WhenStockAdded)
        {
            Webstore.stockmanagementsettings_update(SA_eprintmisjobs, SA_EprintJobstatusID, SA_EstoreOrdersJobs, SA_EstoreJobstatusID, SR_StockReductionMethod, SR_IsStockPickSingleLocation, SR_WhenStockReduced, SR_JobStatusID, SC_IFJobCancelled, StatusMessage, CompanyID, UserID, Replenish_JobStatusID, SA_WhenStockAdded);
        }

        public static void StockScanningJobOrPOStatus_Update(Int32 StockScanFullJobStatusID, int StockScanPartialJobStatusID, Int32 StockScanFullPOStatusID, Int32 StockScanPartialPOStatusID,Int32 CompanyId)
        {
            Webstore.StockScanningJobOrPOStatus_Update(StockScanFullJobStatusID, StockScanPartialJobStatusID, StockScanFullPOStatusID, StockScanPartialPOStatusID, CompanyId);
        }

        public static void StoreEmailSetting_Insert_Update(int CompanyID, int StoreEmailSettingsID, string AdminTo, string AdminCc, string AdminBcc, string CustomerFrom, string CustomerCc, string CustomerBcc)
        {
            Webstore.StoreEmailSetting_Insert_Update(CompanyID, StoreEmailSettingsID, AdminTo, AdminCc, AdminBcc, CustomerFrom, CustomerCc, CustomerBcc);
        }

        public static DataTable StoreEmailSetting_Select(int CompanyID)
        {
            return Webstore.StoreEmailSetting_Select(CompanyID);
        }

        public static DataTable SubAdditionalOptions_SubValues(int ChoiceID, int OthercostID)
        {
            return Webstore.SubAdditionalOptions_SubValues(ChoiceID, OthercostID);
        }

        public static DataTable SubAdditionalOptions_Values(int ChoiceID, int OthercostID)
        {
            return Webstore.SubAdditionalOptions_Values(ChoiceID, OthercostID);
        }

        public static void TermsAndConditions_Insert(int companyID, int accountID, int isTerms, string TermsAndConditions)
        {
            Webstore.TermsAndConditions_Insert(companyID, accountID, isTerms, TermsAndConditions);
        }

        public static DataTable TermsAndConditions_Select(int CompanyID, int AccountID)
        {
            return Webstore.TermsAndConditions_Select(CompanyID, AccountID);
        }

        public static void Update_customerType(long PriceCatalogueID, string CustomerType)
        {
            Webstore.Update_customerType(PriceCatalogueID, CustomerType);
        }

        public static void Update_Disable_Account(long UserID)
        {
            Webstore.Update_Disable_Account(UserID);
        }

        public static void Update_lock_account(long UserID)
        {
            Webstore.Update_lock_account(UserID);
        }

        public static void WebStore_AccountingCode_Insert(int CompanyID, long WebOthercostID, int AccountCodeID)
        {
            Webstore.WebStore_AccountingCode_Insert(CompanyID, WebOthercostID, AccountCodeID);
        }

        public static int WebStore_AccountingCode_Select(int CompanyID, long WebOthercostID)
        {
            return Webstore.WebStore_AccountingCode_Select(CompanyID, WebOthercostID);
        }
    }
}