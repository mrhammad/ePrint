using ePrint.usercontrol.crm;
using java.lang;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class EstimateInvoiceAndJobMenu : System.Web.UI.UserControl
    {
       

            //protected ScriptManagerProxy smproxy;

            //protected RadAjaxManager RadAjaxManager1;

            //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

            //protected UpdatePanel UpdatePanel4;

            //protected UpdateProgress upProgress;

            //protected HtmlGenericControl divLoadingImageCus;

            //protected LinkButton LinkButton26;

            //protected Label lblti;

            //protected Label lblnotecount;

            //protected Label lblAllnotessucmsg;

            //protected Label lblAllNotes;

            //protected LinkButton LinkButton29;

            //protected Label lblclosetask;

            //protected Label lblClCounts;

            //protected Label lblAllClMsg;

            //protected Label lblAllCl;

            //protected LinkButton LinkButton28;

            //protected Label lblopentask;

            //protected Label lblopenActivityCount;

            //protected Label Label145;

            //protected Label lblAllOA;

            //protected LinkButton LinkButton22;

            //protected Button btnmoreactionpopup;

            //protected Label Label126;

            //protected Label lbldetStatus;

            //protected Label Label128;

            //protected Label lblDetSubject;

            //protected Label Label127;

            //protected Label lbldetType;

            //protected Label Label129;

            //protected Label lbldetDueDate;

            //protected Label Label130;

            //protected Label lbldetContactName;

            //protected Label Label153;

            //protected Label lbldetContactMobile;

            //protected Label Label131;

            //protected Label lbldetContactPhone;

            //protected Label Label133;

            //protected Label lbldetAssignTo;

            //protected Label Label141;

            //protected Label lbldetDescription;

            //protected Button btnDelEdit;

            //protected Button btnDelDelete;

            //protected Button btndetComplete;

            //protected LinkButton LinkButton33;

            //protected LinkButton Lnkedit;

            //protected HtmlGenericControl DivMoreActionForPopup;

            //protected LinkButton LinkButton27;

            //protected Label Label142;

            //protected Label lbldetNoteTitle;

            //protected Label Label146;

            //protected Label lbldetSpecifictoContact;

            //protected Label Label148;

            //protected Label lbldetAddedBy;

            //protected Label Label150;

            //protected Label lbldetDate;

            //protected Label Label144;

            //protected Label lbldetNoteContent;

            //protected Button btnDetailsEdit;

            //protected Button btndeleteDetNotes;

            //protected Button btnviewdetattachedfile;

            //protected LinkButton LnkCloseTaskPopup;

            //protected LinkButton LinkButton2;

            //protected Label Label113;

            //protected Label Label56;

            //protected DropDownList ddlassigneto;

            //protected Label LblSubject;

            //protected ImageButton ImageButton9;

            //protected ImageButton ImgClearSubject;

            //protected DropDownList ddlsubject;

            //protected Label Label59;

            //protected ImageButton ImageButton2;

            //protected ImageButton imgClearcontacts;

            //protected DropDownList ddlTaskContacts;

            //protected Label Label57;

            //protected DropDownList ddlstatus;

            //protected Label Label58;

            //protected DropDownList ddlpriority;

            //protected Label Label60;

            //protected Label Label149;

            //protected TextBox txtduedate;

            //protected Telerik.Web.UI.RadTimePicker RadTimePicker;

            //protected Label Label61;

            //protected TextBox txtNotesDesc;

            //protected Button btnsavenotes;

            //protected LinkButton lblAddSubject;

            //protected Label Label92;

            //protected Label Label64;

            //protected TextBox txtSubject;

            //protected Button lnkSaveSubject;

            //protected HtmlAnchor Add_Task;

            //protected HtmlAnchor Add_Call;

            //protected HtmlGenericControl div10;

            //protected HtmlGenericControl AddCallnTask;

            //protected LinkButton LinkButton5;

            //protected LinkButton LinkButton6;

            //protected Label Label118;

            //protected Label Label89;

            //protected DropDownList ddlowner;

            //protected Label Label75;

            //protected ImageButton ImageButton11;

            //protected DropDownList ddlCallSubject;

            //protected Label Label76;

            //protected DropDownList ddlCallAssignTo;

            //protected DropDownList ddlCallPurpose;

            //protected Label Label80w;

            //protected DropDownList ddlCallDetailsType;

            //protected RadioButton RdoCurrentCall;

            //protected RadioButton RdoCompletedCall;

            //protected RadioButton RdoScheduledCall;

            //protected HtmlGenericControl DivFirstStartButton;

            //protected HtmlGenericControl DivFirstPauseButton;

            //protected HiddenField hdncallstaTime;

            //protected HiddenField hdncallHours;

            //protected HtmlGenericControl DivButtonResart;

            //protected Label Label81;

            //protected Label Label100;

            //protected TextBox txtcallstartdate;

            //protected Telerik.Web.UI.RadTimePicker RadTimePicker4;

            //protected DropDownList ddlcallHours;

            //protected DropDownList ddlcallMinute;

            //protected DropDownList ddlcalltime;

            //protected Label Label82;

            //protected TextBox txtcallMinute;

            //protected Label Label83;

            //protected TextBox txtcallSecond;

            //protected Label Label84;

            //protected Label Label99;

            //protected DropDownList ddlCallType;

            //protected Label Label147;

            //protected Label Label90;

            //protected TextBox txtCallDesc;

            //protected Button btnCloseCallPopup;

            //protected Button btnSaveCall;

            //protected Label Label86;

            //protected Label Label87;

            //protected Label Label88;

            //protected TextBox txtcallresult;

            //protected CheckBox ChkBillable;

            //protected Button bynBackCallPopup;

            //protected Button btnSaveCall1;

            //protected LinkButton LinkButton21;

            //protected Label Label124;

            //protected Label Label125;

            //protected TextBox txtCallSubjects;

            //protected Button btnSaveCallSubject;

            //protected LinkButton LinkButton12;

            //protected LinkButton lnkEditCloseOA;

            //protected Label Label119;

            //protected Label Label12;

            //protected DropDownList ddlEditassignto;

            //protected Label Label11;

            //protected ImageButton imgeditaddcontact;

            //protected DropDownList ddlEditsubject;

            //protected Label Label16;

            //protected ImageButton ImageButton7;

            //protected ImageButton ImageButton8;

            //protected DropDownList ddlEditContact;

            //protected Label Label13;

            //protected DropDownList ddlEditStataus;

            //protected Label Label14;

            //protected DropDownList ddlEditPriority;

            //protected Label lblEditDueDate;

            //protected Label Label152;

            //protected TextBox txtEditDueDate;

            //protected Telerik.Web.UI.RadTimePicker RadTimePicker1;

            //protected DropDownList ddlEdithour;

            //protected DropDownList ddlEditminute;

            //protected Label Label42;

            //protected TextBox txtEditTaskDesc;

            //protected Label Label36;

            //protected LinkButton LinkButton13;

            //protected Button btnEditCloseTask;

            //protected HiddenField hdnTaskID;

            //protected Button btncompletetask;

            //protected Button btnEditUpdateTask;

            //protected Label Label35;

            //protected Label Label40;

            //protected Button Button8;

            //protected Button btnEditUpdateTask1;

            //protected LinkButton LinkButton11;

            //protected Label Label38;

            //protected Label Label39;

            //protected TextBox txtEditSubject;

            //protected Button lnlAddSub;

            //protected LinkButton LinkButton18;

            //protected LinkButton LinkButton19;

            //protected Label Label120;

            //protected Label Labsel89;

            //protected DropDownList ddlEditowner;

            //protected Label Label80;

            //protected ImageButton imgeditcallsubject;

            //protected DropDownList ddlCallSubjectEdit;

            //protected Label Label107;

            //protected DropDownList ddlEditCallContact;

            //protected Label Label104;

            //protected DropDownList ddleditCallPurpose;

            //protected Label Label105;

            //protected DropDownList DropDownList3;

            //protected TextBox TextBox3;

            //protected ImageButton ImageButton10;

            //protected Label Label106;

            //protected DropDownList DropDownList4;

            //protected TextBox TextBox4;

            //protected Label Label108;

            //protected DropDownList ddlEditCallDetails;

            //protected Label Label109;

            //protected Label Label102;

            //protected TextBox txtEditCallStartdate;

            //protected Telerik.Web.UI.RadTimePicker RadTimePicker5;

            //protected DropDownList ddleditCallHours;

            //protected DropDownList ddleditCallSecond;

            //protected DropDownList ddlEditCallTime;

            //protected Label Label110;

            //protected TextBox txtEditCallMin;

            //protected Label Label111;

            //protected TextBox txtEditCallSec;

            //protected Label Label112;

            //protected Label Label103;

            //protected DropDownList ddlEditCallType;

            //protected Label Label151;

            //protected Label Label116;

            //protected LinkButton LinkButton20;

            //protected Label Labesl90;

            //protected TextBox txtEditCallDesc;

            //protected Button Button18;

            //protected Button btncompletecall;

            //protected Button btnUpdateEditcall;

            //protected Label Label114;

            //protected Label Label115;

            //protected Label Label828;

            //protected TextBox txtEditcallressult;

            //protected CheckBox ChkEditBillable;

            //protected Button bynBacksCallPopup;

            //protected Button btnUpdateEditcall1;

            //protected LinkButton lnkCloseContactPopup;

            //protected Label Label93;

            //protected RadGrid RadGridContact;

            //protected UpdatePanel UpdatePanel5;

            //protected LinkButton lnlcloseAddnotepopup;

            //protected LinkButton LinkButton24;

            //protected LinkButton LinkButton23;

            //protected FileUpload NotesFileUpload;

            //protected Label lblvalidatetoploadfile;

            //protected TextBox TextBox2;

            //protected LinkButton LinkButton8;

            //protected Label lblAddNoteTitle;

            //protected Label Label136;

            //protected TextBox txtnoteTitle;

            //protected Label Label137;

            //protected TextBox txtNoteDesc;

            //protected Label Label138;

            //protected DropDownList ddlspecificTo;

            //protected LinkButton lnkUoloadFile;

            //protected LinkButton LinkButton9;

            //protected FileUpload file_upload;

            //protected Label lblOldFile;

            //protected Label lblOldFileSize;

            //protected LinkButton lnkRemoveOldFile;

            //protected Button BtnNotesSave;

            //protected Button btnUpdateNotes;

            //protected Button btnUpdateAllNotes;

            //protected LinkButton LnkSummary;

            //protected LinkButton lnkDepartment;

            //protected LinkButton lnlCostCentre;

            //protected HtmlGenericControl DivlnlCostCentre;

            //protected LinkButton lnkContact;

            //protected LinkButton lnkAddressBook;

            //protected LinkButton lnkEstore;

            //protected HtmlGenericControl divlnkEstore;

            //protected LinkButton lnlProducts;

            //protected HtmlGenericControl DivlnlProducts;

            //protected LinkButton lnkEmail;

            //protected LinkButton lnkRecords;

            //protected HtmlGenericControl DivlnkRecords;

            //protected HiddenField ddnAttachID;

            //protected Button btnScroll;

            //protected HtmlTableCell DivLeftPanel;

            //protected Button btnCancel;

            //protected Button btnConvertToCstmr;

            //protected HtmlGenericControl converttocust;

            //protected Label lbltitlecompanyname;

            protected Label PanelName = new Label();

            //protected HtmlGenericControl Div14;

            //protected ImageButton lnkNextClientRecord;

            //protected HtmlGenericControl DivlnkNextClientRecord;

            //protected ImageButton lnkPreviousPage;

            //protected HtmlGenericControl DivlnkPreviousPage;

            //protected Button Button1;

            //protected HtmlGenericControl Div9;

            protected Button btn_AddNewDepartment = new Button();

            //protected Button btn_ClearFilters_Dept;

            //protected UpdatePanel UpdatePanel2;

            //protected HtmlGenericControl div_DeptControls;

            protected Button btn_AddNewContact = new Button();

            //protected Button btn_ClearFilter_Contact;

            //protected UpdatePanel UpdatePanel10;

            //protected HtmlGenericControl div_ContactControls=new HtmlGenericControl();

            protected Button btn_AddNewCostCenter = new Button();

            //protected Button btn_ClearFilter_Costcenter;

            //protected UpdatePanel UpdatePanel8;

            // protected HtmlGenericControl div_CostcenterControls=new  HtmlGenericControl();

            protected Button btn_AddNewAddress = new Button();

            //protected Button btn_ClearFilter_Address;

            //protected UpdatePanel UpdatePanel9;

            // protected HtmlGenericControl div_AddressControls=new HtmlGenericControl();

            protected Button btn_AddNewProduct = new Button();

            //protected Button btn_ClearFilter_Product;

            //  protected HtmlGenericControl div_ProductsControls=new HtmlGenericControl();

            protected Button btn_AddNewEmail = new Button();

            //protected Button btn_ClearFilterEmail;

            // protected HtmlGenericControl div_EmailControls= new HtmlGenericControl();

            //protected Button btn_ClearFilter_Estimaterecords;

            // protected HtmlGenericControl div_EstimateControls = new HtmlGenericControl();

            //protected Button btn_ClearFilter_Jobrecords;

            // protected HtmlGenericControl div_JobControls = new HtmlGenericControl();

            //protected Button btn_ClearFilter_Invoicerecords;

            // protected HtmlGenericControl div_InvoiceControls = new HtmlGenericControl();

            //protected Button btn_ClearFilter_eStorerecords;

            // protected HtmlGenericControl div_eStoreControls = new HtmlGenericControl();

            //protected Button btnSearch;

            //protected HtmlGenericControl DivsearchButton;

            //protected Button btnDelete;

            //protected HtmlGenericControl divbtndelete;

            //protected Button btnEdit;

            //protected HtmlGenericControl divbtnedit;

            //protected HtmlGenericControl DivButtonsHeader;

            //protected PlaceHolder plhClient;

            //protected HiddenField hid_ClientID;

            //protected Label Label55;

            //protected Label Label139;

            //protected Label Label140;

            //protected TextBox txtallsearchcontant;

            //protected TextBox txtsearchstartdate;

            //protected TextBox txtsearchenddate;

            //protected Button btnFinalSearch;

            //protected HtmlGenericControl Divdiv_btnSearch;

            //protected Button btnClear;

            //protected HtmlGenericControl Div23;

            //protected CheckBox Chk_Task;

            //protected CheckBox Chk_Call;

            //protected CheckBox Chk_Note;

            //protected Label Search_Note;

            //protected LinkButton LinkButton25;

            //protected Button btnPrintClInfoAndAddress;

            //protected Button btnPrintClInfoAndNotes;

            //protected Button btnPrintClInfoWithDeptInfo;

            //protected Button btnPrintMap;

            //protected Label lbl1;

            //protected Label lblCompanyName;

            //protected Label lblConName;

            //protected Label lblContactname;

            //protected Label Label15;

            //protected Label lblBusinessEmail;

            //protected Label lblph;

            //protected Label lblPhoneNumber;

            //protected Label Label30;

            //protected Label lblSalesPerson;

            //protected LinkButton lnkShowdetail;

            //protected LinkButton lnkHideDetails;

            //protected Label Label3;

            //protected Label lblCompanyAlias;

            //protected Label lblcrr;

            //protected Label lbliscarrier;

            //protected HtmlGenericControl Div_Carrier;

            //protected Label Label23;

            //protected Label lblPaymentTerms;

            //protected Label lbl_url;

            //protected Label lblURL;

            //protected Label Label18;

            //protected Label lblCreditLimit;

            //protected Label Label19;

            //protected Label lblCreditRef;

            //protected Label Label20;

            //protected Label lblTax1;

            //protected Label Label21;

            //protected Label lblTax2;

            //protected HtmlGenericControl div_Tax2;

            //protected Label lbl_desc;

            //protected Label lblDescription;

            //protected Label lblbusiemail;

            protected Label lblActualBusinessEmail = new Label();

            //protected Label Label5;

            //protected Label lblAccountStatus;

            //protected Label Label4;

            //protected Label lblType;

            //protected Label Label24;

            protected Label LblEstimateToJob1 = new Label();

            //protected Label Label6;

            //protected Label lblAccountNumber;

            //protected Label Label25;

            //protected Label lblProfitMargin;

            //protected Label Label22;

            //protected Label lblTaxRegNo;

            //protected Label Label26;

            //protected Label lblAcOpened;

            //protected Label Label27;

            //protected Label lblBankCode;

            //protected Label Label28;

            //protected Label lblBankAccountNumber;

            //protected Label Label29;

            //protected Label lblAccountName;

            //protected Label LabelReference;

            //protected Label lbl_Referencedby;

            //protected Label lblRoyalityFee;

            //protected Label lblRoyalityFree;

            //protected HtmlGenericControl DivChkRoyalityFree;

            //protected Label Label31;

            //protected Label lblTaxNumber;

            //protected Label Label32;

            //protected Label lblBalance;

            //protected HtmlGenericControl div_Supplier;

            //protected Label lblnotessumm;

            //protected Label Label91;

            //protected Label lblNotesTitle1;

            //protected HtmlGenericControl Ifattachedfiles;

            //protected Label lblNotesTitleHide;

            //protected Label lblNotesTitleHide1;

            //protected LinkButton lnkShowmoreNotes;

            //protected LinkButton lnkHidemoreNotes;

            //protected HtmlGenericControl DivMoreNotes;

            //protected Label lblNotesDescripitions;

            //protected HtmlGenericControl DivViewNotes;

            //protected Label Label10;

            //protected HtmlGenericControl DivopenActivities;

            //protected Label lblSuccMesg;

            //protected Label lblNotesMessage;

            //protected Label lblNotesTitle;

            //protected PlaceHolder plsOpenActivities;

            //protected DropDownList OpenCloseTasknCall;

            //protected Label lblOpenActivities;

            //protected Label lblcloseActivity;

            //protected Label lblNoActivi;

            //protected Label Label37;

            //protected HtmlGenericControl DivContactLabel;

            //protected Label lblContactMessage;

            //protected PlaceHolder plstopfivecontact;

            //protected Label lbltopfivecontact;

            //protected Label lblPrintCusDetailsWithAddress;

            //protected Label lblPrintCusDetailsWithAllNotes;

            //protected Label lblPrintCusDetailsWithDeptInfo;

            //protected Button btnCreateAcc_Or_view;

            //protected UpdatePanel up_CleintInfo;

            //protected HtmlGenericControl div_ClientMain;

            //protected PlaceHolder plhContact;

            //protected UpdatePanel UPMessageNew;

            //protected RadListBoxItem Delete_Hide;

            //protected RadListBox RadListBox_Contact;

            //protected HiddenField hdn_ContactIDs;

            //protected LinkButton lnk_ContactsRadList;

            //protected RadGrid RadGrid_Contact;

            //protected HtmlGenericControl div1;

            //protected UpdatePanel up_ContactDetails;

            //protected HtmlGenericControl div_ContactMain;

            //protected PlaceHolder plhDepartment;

            //protected UpdatePanel UpdatePanel1;

            //protected RadListBox RadListBox_Department;

            //protected HtmlGenericControl DIv_ListBox;

            //protected HiddenField hdn_deptIDs;

            //protected HiddenField hdn_assignedDeptID;

            //protected LinkButton lnk_DeptRadList;

            //protected RadGrid RadGrid_Department;

            //protected Label Label2;

            //protected ImageButton ImageButton1;

            //protected Label lblStatus;

            //protected DropDownList ddl_deptList;

            //protected UpdatePanel pnl_accountList;

            //protected Button btn_saveDept;

            //protected UpdatePanel up_saveDept;

            //protected HtmlGenericControl div_save;

            //protected HtmlGenericControl div2;

            //protected HiddenField IsConfirmDepts;

            //protected UpdatePanel up_DeptDetails;

            //protected HtmlGenericControl div_DepartmentMain;

            //protected PlaceHolder plhAddress;

            //protected RadListBox RadListBox_Address;

            //protected HiddenField hdn_AddressIDs;

            //protected LinkButton lnk_AddressRadList;

            //protected RadGrid RadGrid_Address;

            //protected HtmlGenericControl div3;

            //protected UpdatePanel up_AddressDetails;

            //protected HtmlGenericControl div_AddressMain;

            //protected PlaceHolder plh_2b2Details;

            //protected UpdatePanel up_2b2Details;

            //protected HtmlGenericControl div_b2bMain;

            //protected PlaceHolder plh_ProductDetails;

            //protected UpdatePanel up_ProductDetails;

            //protected HtmlGenericControl div_ProductsMain;

            //protected PlaceHolder plhNotes;

            //protected UpdatePanel UpdatePanel3;

            //protected Button btnsave;

            //protected HtmlGenericControl DivAddNewRecords;

            //protected Button btn_print;

            //protected HtmlGenericControl DivPrint;

            //protected ImageButton btn_SortDirection;

            //protected LinkButton lnk_SortDirection;

            //protected LinkButton lnk_delete;

            //protected PlaceHolder plhNote;

            //protected HtmlGenericControl div_NoRecords;

            //protected UpdatePanel updnotes;

            //protected HiddenField hdnAttachmentID;

            //protected HtmlGenericControl div4;

            //protected PlaceHolder ph_notesPrint;

            //protected HtmlGenericControl div_NotesMain;

            //protected PlaceHolder plh_EmailsDetails;

            //protected UpdatePanel up_EmailsDetails;

            //protected HtmlGenericControl div_EmailMain;

            //protected PlaceHolder plh_ActivitiesDetails;

            //protected UpdatePanel up_ActivitiesDetails;

            //protected HtmlGenericControl div_ActivitiesMain;

            //protected PlaceHolder plhCoceCEn;

            //protected UpdatePanel UpdatePanel7;

            //protected LinkButton lnkDeletecostcentre;

            //protected HiddenField hdncostcenterids;

            //protected RadGrid grdcostcentre;

            //protected UpdatePanel UpdatePanel6;

            //protected RadCodeBlock RadCodeBlock1;

            //protected HtmlGenericControl div_CostcentreMain;

            //protected HtmlGenericControl DivAnotherDesign;

            //protected LinkButton lblGoToTop;

            //protected HtmlTableCell DivRightPanel;

            //protected LinkButton lnkRightArrow;

            //protected LinkButton lnkLeftArrow;

            //protected LinkButton lnlCustomerInfoWithAddress;

            //protected LinkButton lnlCustomerInfowithDepartment;

            //protected LinkButton lnkMap;

            //protected LinkButton lnlAllNotes;

            //protected HtmlGenericControl DivPrintOptions;

            //protected HtmlTable tablemainpanel;

            //protected Label lblNavigations;

            //protected HiddenField hdntodaydate;

            //protected HiddenField hdnCommanID;

            //protected HiddenField hdnSectionName;

            //protected HiddenField hdnbuttonid;

            //protected HiddenField hdnTaskFollowParentID;

            //protected HiddenField hdnTaskFollowParentType;

            //protected HiddenField hdnCallFollowParentID;

            //protected HiddenField hdnCallFollowParentType;

            //protected HiddenField hdnTaskFollowParentIDDet;

            //protected HiddenField hdnTaskFollowParentTypeDet;

            //protected HiddenField hdnCallFollowParentIDDet;

            //protected HiddenField hdnCallFollowParentTypeDet;

            protected HiddenField hdnDefaultTaskSubject = new HiddenField();

            protected HiddenField hdnDefaultCallSubject = new HiddenField();

            //protected RadWindowManager RadWindowManager1;

            //protected HiddenField hdnprintNotesValue;

            //protected HiddenField hdnPrintCusDetailsWithAddress;

            //protected HiddenField hdnPrintCusDetailsWithAllNotes;

            //protected HiddenField hdnPrintCusDetailsWithDeptInfo;

            //protected HiddenField AttID;

            //protected Label lbl_ClientTab;

            //protected LinkButton lnk_ClientTab;

            //protected UpdatePanel up_ClientTabs;

            //protected Label lbl_DeptTab;

            //protected LinkButton lnk_DeptTab;

            //protected UpdatePanel up_DeptTabs;

            //protected Label lblcostcentretabs;

            //protected LinkButton LinkButton1;

            //protected HtmlGenericControl div_costcentretabs;

            //protected HtmlGenericControl li_costcentre;

            //protected UpdatePanel Up_costcentre;

            //protected Label lbl_ContactTab;

            //protected LinkButton lnk_ContactTab;

            //protected UpdatePanel up_ContactsTabs;

            //protected Label lbl_AddressTab;

            //protected LinkButton lnk_AddressTab;

            //protected HtmlGenericControl div_AddressTabs;

            //protected UpdatePanel up_Address;

            //protected Label lbl_b2bTab;

            //protected LinkButton lnk_b2bTab;

            //protected UpdatePanel up_b2b;

            //protected Label lbl_ProductsTab;

            //protected LinkButton lnk_ProductsTab;

            //protected UpdatePanel up_Product;

            //protected HiddenField hdnPrintNotes;

            //protected Label lbl_NotesTab;

            //protected LinkButton lnk_NotesTab;

            //protected HtmlGenericControl div_NotesTabs;

            //protected UpdatePanel up_Notes;

            //protected Label lbl_EmailsTab;

            //protected LinkButton lnk_EmailsTab;

            //protected HtmlGenericControl div_EmailsTabs;

            //protected UpdatePanel up_Emails;

            //protected Label Label1;

            //protected LinkButton lnk_CostCenterTab;

            //protected HtmlGenericControl divCostCenter;

            //protected UpdatePanel up_CostCenter;

            //protected Label lbl_ActivitiesTab;

            //protected LinkButton lnk_ActivitiesTab;

            //protected HtmlGenericControl div_ActivitiesTabs;

            //protected UpdatePanel up_Activities;

            //protected Panel pnl_MoreThan1Selected;

            //protected Panel pnl_MoreThan1Selected_Dept;

            //protected Panel pnl_MoreThan1Selected_Address;

            private CompanyBasePage objcomm = new CompanyBasePage();

            private DepartmentBaseClass objDept = new DepartmentBaseClass();

            private commonClass objcom = new commonClass();

            public BaseClass basecls = new BaseClass();

            private commonClass objCommonClass = new commonClass();

            public languageClass objLanguage = new languageClass();

            private SettingsBasePage objSetBase = new SettingsBasePage();

            private commonClass commclass = new commonClass();

            //private BaseClass objBase = new BaseClass();

            public int CompanyID;

            public int UserID;

            public int ClientID;

            public int AccountID;

            public int isnew = 2;

            public int DeliveryAddressID;

            public int InvoiceAddressID;

            public int cntPostbox;

            public int cntDelete;

            public int cntDefault;

            public int cntActivate;

            public int cntDeactivate;

            public int SetDefaultContactID;

            public int SetDefaultDeptID;

            public int Index;

            public static int ChangeOrder;

            public static string SalesPersonID;

            public static string IsEditOnlyHisRecords;

            public static int Contactflag;

            public static int Filtering;

            public string ImgPath = global.imagePath();

            public string strSitepath = global.sitePath();

            public string strimgpath = global.strimagepath;

            public string CompanyName = string.Empty;

            public string CompanyType = string.Empty;

            public string redirectFrom = string.Empty;

            public string web_key = string.Empty;

            public string WebStorePath = string.Empty;

            public string FileExtension = string.Empty;

            public string QSsuc = string.Empty;

            public string strSuc = string.Empty;

            public string DateFormat = string.Empty;

            public string companyName = string.Empty;

            public string From = string.Empty;

            public string Tax2 = string.Empty;

            public string uploadedfile;

            public string subject;

            public string fileName;

            public string url;

            public string sectionName;

            public string WebStorePathB2B = string.Empty;

            public string WebStorePathB2C = string.Empty;

            public string isView = string.Empty;

            public DataTable dt_Contact;

            public DataTable dt_Department;

            public DataTable dt_Address;

            public DataTable dt_Notes;

            public string VersionNumber = ConnectionClass.VersionNumber;

            public string AccountName = string.Empty;

            public languageClass objLangClass = new languageClass();

            public string SectionName;

            public int SectionID;

            public int UserIDN;

            public int attachID;

            public string CreateddateN = DateTime.Now.ToString();

            public string tasktype = "";

            public int tasktypeid;

            public int ClientIDTask;

            public string SecureDocFilepath = global.SecureDocFilepath();

            public string ServerName = string.Empty;

            public string TodayDate = string.Empty;

            private bool IsApprovalSystemEnable;

            public string TodDate = string.Empty;

            public int UserTypeID;

            public string CompanyTypeNew = "";

            public string ShowRecords = "All";

            public string CompanyCusName = "";

            public string UniqueID = "";

            public string Types = "";

            public bool PopupOpen;

            private DataTable dtsource = new DataTable();

            public string WhereConditionContact = string.Empty;

            public string WhereConditionDepartment = string.Empty;

            public string WhereConditionCostcenter = string.Empty;

            public string WhereConditionAddress = string.Empty;

            public int TaskId;

            public string ActivityType = string.Empty;

            protected DefaultProfile Profile
            {
                get
                {
                    return (DefaultProfile)this.Context.Profile;
                }
            }

   
        

           
          

            public void BindPyortyDrop()
            {
                this.ddlpriority.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlpriority.Items.Insert(1, this.objLanguage.convert("High"));
                this.ddlpriority.Items.Insert(2, this.objLanguage.convert("Low"));
                this.ddlpriority.Items.Insert(3, this.objLanguage.convert("Normal"));
                this.ddlpriority.Items[0].Value = "";
                this.ddlpriority.SelectedIndex = 3;
            }

            public void BindStatusDrop()
            {
                taskClass _taskClass = new taskClass();
                this.ddlstatus.DataSource = _taskClass.dtrTaskStatus(int.Parse(base.Session["companyID"].ToString()));
                this.ddlstatus.DataTextField = "taskStatus";
                this.ddlstatus.DataValueField = "taskStatusId";
                this.ddlstatus.DataBind();
                this.ddlstatus.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                this.ddlstatus.Items[0].Value = "";
                this.ddlstatus.SelectedIndex = 4;
            }

            public void BindSubJectDropdown()
            {
                DataTable dataTable = Settings.settings_subject_select(Convert.ToInt32(this.CompanyID));
                if (dataTable.Rows.Count > 0)
                {
                    this.ddlsubject.DataSource = dataTable;
                    this.ddlsubject.DataTextField = "sampleSubject";
                    this.ddlsubject.DataValueField = "sampleSubjectId";
                    this.ddlsubject.DataBind();
                    this.ddlsubject.Items.Insert(0, string.Concat("--- ", this.objLanguage.convert("Select"), " ---"));
                    this.ddlsubject.Items[0].Value = "";
                    this.ddlsubject.SelectedIndex = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["IsDefault"].ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        this.basecls.SetDDLValue(this.ddlsubject, row["sampleSubjectId"].ToString());
                        this.hdnDefaultTaskSubject.Value = row["sampleSubjectId"].ToString();
                    }
                }
            }

           


            protected void btnCancel_OnClick(object sender, EventArgs e)
            {
                if (this.redirectFrom.ToLower() == "accounts")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "accounts/accounts_view.aspx?type=", this.CompanyType));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx?type=", this.CompanyType));
            }

           

            protected void btnCreateAcc_Or_view_Click(object sender, EventArgs e)
            {
                if (this.AccountID == 0)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_new_create.aspx?from=client&type=Customer&mode=add&clientID=", this.ClientID));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_details.aspx?from=client&type=Customer&mode=view&clientID=", this.ClientID));
            }

           

          

          
           

         

           

           

            protected void Page_Load(object sender, EventArgs e)
            {
                string[] strArrays;
                object[] languageConversion;
                this.SectionName = "client";
                this.UserIDN = Convert.ToInt32(base.Session["UserID"]);
                
                if (ConnectionClass.ServerName != null)
                {
                    this.ServerName = ConnectionClass.ServerName;
                }
              
                this.ImageButton9.ToolTip = this.objLangClass.GetLanguageConversion("Add_new_subject");
                this.LinkButton26.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.LinkButton29.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.LinkButton28.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.LinkButton22.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.btnDelEdit.Text = this.objLangClass.GetLanguageConversion("Edit");
                this.btnDelDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
                this.btndetComplete.Text = this.objLangClass.GetLanguageConversion("Complete");
                this.LinkButton27.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.btnDetailsEdit.Text = this.objLangClass.GetLanguageConversion("Edit");
                this.btndeleteDetNotes.Text = this.objLangClass.GetLanguageConversion("Delete");
                this.btnviewdetattachedfile.Text = this.objLangClass.GetLanguageConversion("View_Attached_File");
                this.LnkCloseTaskPopup.ToolTip = this.objLangClass.GetLanguageConversion("Close");
                this.ImageButton9.ToolTip = this.objLangClass.GetLanguageConversion("Add_new_subject");
              
                this.btnsavenotes.Text = this.objLangClass.GetLanguageConversion("Save");
                this.lnkSaveSubject.Text = this.objLangClass.GetLanguageConversion("Save");
               
                this.LnkSummary.Text = this.objLangClass.GetLanguageConversion("Summary_Information");
                this.lnkDepartment.Text = this.objLangClass.GetLanguageConversion("Departments");
                this.lnlCostCentre.Text = this.objLangClass.GetLanguageConversion("Cost_Centres");
                this.lnkContact.Text = this.objLangClass.GetLanguageConversion("Contacts");
                this.lnkAddressBook.Text = this.objLangClass.GetLanguageConversion("Address_Book");
              
               
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
                DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
                if (dataTable.Rows.Count > 0 && Convert.ToBoolean(dataTable.Rows[0]["IsDisplayCostCentre"]))
                {
                    this.DivlnlCostCentre.Style.Add("display", "block");
                }
                if (!base.IsPostBack)
                {
                    if (this.web_key != "")
                    {
                        
                    }
                    if (ConnectionClass.Tax2 != null)
                    {
                        this.Tax2 = ConnectionClass.Tax2;
                        
                    }
                }
                if (ConnectionClass.FileExtension != null)
                {
                    this.FileExtension = ConnectionClass.FileExtension.ToString();
                }
                if (ConnectionClass.WebStore != null)
                {
                    this.web_key = ConnectionClass.WebStore;
                }
                if (ConnectionClass.FileExtension != null)
                {
                    this.FileExtension = ConnectionClass.FileExtension.ToString();
                }
                if (ConnectionClass.B2CURL != null)
                {
                    this.WebStorePathB2C = ConnectionClass.B2CURL.ToString();
                    this.WebStorePathB2C = string.Concat(this.WebStorePathB2C, "login", this.FileExtension);
                }
                try
                {
                    string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                    ArrayList arrayLists = Encryption.querystrvalue(str);
                    this.ClientID = int.Parse(arrayLists[1].ToString());
                    this.SectionID = this.ClientID;
                    base.Session["ClientID"] = arrayLists[1].ToString();
                    this.CompanyType = arrayLists[7].ToString().ToLower().Trim();
                    this.CompanyName = arrayLists[3].ToString();
                    this.redirectFrom = arrayLists[9].ToString();
                    this.UniqueID = arrayLists[9].ToString();
                    this.Types = arrayLists[11].ToString();
                    this.TaskId = Convert.ToInt16(arrayLists[9]);
                    this.ActivityType = arrayLists[11].ToString();
                }
                catch
                {
                }
                if (this.UniqueID == "" && this.Types == "")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:SetContentWidth();", true);
                }
                else if (base.Session["Popup"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:SetContentWidth();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:SetContentWidthPopup();", true);
                    base.Session["Popup"] = null;
                }
                if (ConnectionClass.B2BURL != null)
                {
                    this.WebStorePathB2B = ConnectionClass.B2BURL.ToString();
                    this.WebStorePathB2B = string.Concat(this.WebStorePathB2B, "login", this.FileExtension);
                }
              
                DataTable dataTable1 = DepartmentBaseClass.department_getAllDetails(this.CompanyID, this.UserID, this.ClientID, (long)0);
               
                DataTable dataTable2 = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.CompanyType);
                if (dataTable2.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable2.Rows)
                    {
                        this.AccountID = Convert.ToInt32(row["AccountID"].ToString());
                        ClientSubSection.SalesPersonID = row["SalesPerson"].ToString();
                        this.CompanyCusName = row["clientName"].ToString();
                    }
                }
                foreach (DataRow dataRow in DepartmentBaseClass.IsApprovalSystem_Enable(this.AccountID).Rows)
                {
                    this.IsApprovalSystemEnable = Convert.ToBoolean(dataRow["IsActive"]);
                }
               
                if (!base.IsPostBack)
                {
                   
                    if (base.Request.Cookies["ContactFiterState"] != null)
                    {
                        base.Request.Cookies["ContactFiterState"].Value = null;
                    }
                    if (base.Request.Cookies["DeptFiterState"] != null)
                    {
                        base.Request.Cookies["DeptFiterState"].Value = null;
                    }
                    if (base.Request.Cookies["AddressFiterState"] != null)
                    {
                        base.Request.Cookies["AddressFiterState"].Value = null;
                    }
                    if (base.Request.Cookies["NotesFiterState"] != null)
                    {
                        base.Request.Cookies["NotesFiterState"].Value = null;
                    }
                 
                }
             
             
              
                
                string empty10 = string.Empty;
                ClientSubSection.IsEditOnlyHisRecords = this.basecls.ReturnRoles_Privileges_Others("editrecords");
               
               
             
                this.DateFormat = base.Session["DateFormat"].ToString();
                this.TodayDate = DateTime.Today.ToString();
                this.txtduedate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
                this.txtduedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
                this.txtduedate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
              
                DataSet dataSet = DepartmentBaseClass.CRM_Select_Type_fromUsertype(this.UserID);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow3 in dataSet.Tables[0].Rows)
                    {
                        this.UserTypeID = Convert.ToInt32(dataRow3["UsertypeID"].ToString());
                    }
                }
                DataSet dataSet1 = DepartmentBaseClass.CRM_Select_Type_fromUsertype(this.CompanyID, this.UserTypeID);
                if (dataSet1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row4 in dataSet1.Tables[0].Rows)
                    {
                        if (row4["CompanyType"].ToString() != "")
                        {
                            this.CompanyTypeNew = row4["CompanyType"].ToString().Substring(0, row4["CompanyType"].ToString().Length - 1);
                        }
                        this.ShowRecords = row4["ShowRecords"].ToString();
                    }
                }
                DataSet dataSet2 = DepartmentBaseClass.CRM_Select_Conversion_Persentage_Est_Job(this.ClientID, this.CompanyID);
                if (dataSet2.Tables[0].Rows.Count <= 0)
                {
                    this.LblEstimateToJob1.Text = "0%";
                }
                else
                {
                    foreach (DataRow dataRow4 in dataSet2.Tables[0].Rows)
                    {
                        Label lblEstimateToJob1 = this.LblEstimateToJob1;
                        string languageConversion1 = this.objLangClass.GetLanguageConversion("Estimate_to_Job");
                        decimal num = System.Math.Round(Convert.ToDecimal(dataSet2.Tables[0].Rows[0]["JobConversionPercentage"]), 0);
                        lblEstimateToJob1.Text = string.Concat(languageConversion1, " ", num.ToString(), "%");
                    }
                }
              
                try
                {
                    commonClass _commonClass = this.commclass;
                    DateTime now = DateTime.Now;
                    string str12 = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                    string[] strArrays1 = str12.Split(new char[] { ' ' });
                    this.hdntodaydate.Value = strArrays1[0].ToString();
                    this.TodDate = this.hdntodaydate.Value;
                }
                catch
                {
                }
              
                
               
                DataSet dataSet3 = DepartmentBaseClass.CRM_Select_SalesTarget(this.UserID, Convert.ToInt32(this.CompanyID));
                DataTable dataTable5 = new DataTable();
                if (dataSet3.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row5 in dataSet3.Tables[0].Rows)
                    {
                        if (row5["IsCustomAccessRight"].ToString().ToLower() == "false")
                        {
                            this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                            this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks_Calls");
                            dataTable5.Columns.Add("Value", typeof(string));
                            dataTable5.Columns.Add("Text", typeof(string));
                            DataRowCollection rows = dataTable5.Rows;
                            languageConversion = new object[] { "0", "None" };
                            rows.Add(languageConversion);
                            DataRowCollection dataRowCollection = dataTable5.Rows;
                            languageConversion = new object[] { "1", this.objLangClass.GetLanguageConversion("Call") };
                            dataRowCollection.Add(languageConversion);
                            DataRowCollection rows1 = dataTable5.Rows;
                            languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                            rows1.Add(languageConversion);
                            DataRowCollection dataRowCollection1 = dataTable5.Rows;
                            languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                            dataRowCollection1.Add(languageConversion);
                        }
                        else if (row5["IsTaskEventCall"].ToString().ToLower() != "1")
                        {
                            this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks");
                            this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks");
                            dataTable5.Columns.Add("Value", typeof(string));
                            dataTable5.Columns.Add("Text", typeof(string));
                            DataRowCollection rows2 = dataTable5.Rows;
                            languageConversion = new object[] { "0", "None" };
                            rows2.Add(languageConversion);
                            DataRowCollection dataRowCollection2 = dataTable5.Rows;
                            languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                            dataRowCollection2.Add(languageConversion);
                            DataRowCollection rows3 = dataTable5.Rows;
                            languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                            rows3.Add(languageConversion);
                        }
                        else
                        {
                            this.lblopentask.Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                            this.lblclosetask.Text = this.objLangClass.GetLanguageConversion("Close_Tasks_Calls");
                            dataTable5.Columns.Add("Value", typeof(string));
                            dataTable5.Columns.Add("Text", typeof(string));
                            DataRowCollection dataRowCollection3 = dataTable5.Rows;
                            languageConversion = new object[] { "0", "None" };
                            dataRowCollection3.Add(languageConversion);
                            DataRowCollection rows4 = dataTable5.Rows;
                            languageConversion = new object[] { "1", this.objLangClass.GetLanguageConversion("Call") };
                            rows4.Add(languageConversion);
                            DataRowCollection dataRowCollection4 = dataTable5.Rows;
                            languageConversion = new object[] { "3", this.objLangClass.GetLanguageConversion("Task") };
                            dataRowCollection4.Add(languageConversion);
                            DataRowCollection rows5 = dataTable5.Rows;
                            languageConversion = new object[] { "4", this.objLangClass.GetLanguageConversion("Note") };
                            rows5.Add(languageConversion);
                        }
                    }
                }
                this.btn_AddNewDepartment.Text = this.objLangClass.GetLanguageConversion("Add_New_Department");
                this.btn_AddNewDepartment.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Department");
                this.btn_AddNewDepartment.OnClientClick = string.Concat("javascript:addNewDepartment('dept','add','", this.ClientID, "','0');return false;");
                this.btn_AddNewCostCenter.Text = this.objLangClass.GetLanguageConversion("Add_New_Cost_Centre");
                this.btn_AddNewCostCenter.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Cost_Centre");
                this.btn_AddNewCostCenter.OnClientClick = string.Concat("javascript:addNewCostcenter('costcentre','add','", this.ClientID, "');return false;");
                this.btn_AddNewAddress.Text = this.objLangClass.GetLanguageConversion("Add_New_Address");
                this.btn_AddNewAddress.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Address");
                this.btn_AddNewAddress.OnClientClick = string.Concat("javascript:addNewAddress('Address','add','", this.ClientID, "','0');return false;");
                this.btn_AddNewProduct.Text = this.objLangClass.GetLanguageConversion("Add_New_Product");
                this.btn_AddNewProduct.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Product");
                this.btn_AddNewProduct.OnClientClick = string.Concat("javascript:addNewProduct('Product','add','", this.ClientID, "','0');return false;");
                this.btn_AddNewContact.Text = this.objLangClass.GetLanguageConversion("Add_New_Contact");
                this.btn_AddNewContact.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Contact");
                this.btn_AddNewContact.OnClientClick = string.Concat("javascript:addNewcontact('contact','add','", this.ClientID, "','0');return false;");
                string empty12 = string.Empty;
                empty12 = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                Button btnAddNewEmail = this.btn_AddNewEmail;
                languageConversion = new object[] { "javascript:PopupCenter_Email('0','add','", this.ClientID, "','", empty12, "'); return false;" };
                btnAddNewEmail.OnClientClick = string.Concat(languageConversion);
                this.btn_AddNewEmail.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Email");
                this.btn_AddNewEmail.Text = this.objLangClass.GetLanguageConversion("Add_New_Email");
               
            }

            protected void RadGrid_Address_ItemCommand(object sender, GridCommandEventArgs e)
            {
                DataTable dataTable = new DataTable();
                if (e.CommandName == "Filter")
                {
                    Pair commandArgument = (Pair)e.CommandArgument;
                    string str = commandArgument.Second.ToString();
                    TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                    item.Text = this.basecls.ReplaceSingleQuote(item.Text);
                    this.WhereConditionAddress = "";
                    if (base.Session[string.Concat("searchAddress", this.ClientID)] == null)
                    {
                        dataTable.Columns.Add("ColumnName");
                        dataTable.Columns.Add("Filter");
                        dataTable.Columns.Add("FilterText");
                    }
                    if (base.Session[string.Concat("searchAddress", this.ClientID)] != null)
                    {
                        dataTable = (DataTable)base.Session[string.Concat("searchAddress", this.ClientID)];
                    }
                    DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(second);
                    }
                    else
                    {
                        dataTable.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            dataTable.Rows.Add(objArray);
                        }
                    }
                    base.Session[string.Concat("searchAddress", this.ClientID)] = dataTable;
                
                   
                }
            }

            protected void RadGrid_Address_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
            {
                this.dt_Address = DepartmentBaseClass.address_select_for_filter(this.ClientID, this.CompanyID, "Yes", this.WhereConditionAddress);
              
            }

            protected void RadGrid_Contact_ItemCommand(object sender, GridCommandEventArgs e)
            {
                DataTable dataTable = new DataTable();
                if (e.CommandName == "Filter")
                {
                    Pair commandArgument = (Pair)e.CommandArgument;
                    string str = commandArgument.Second.ToString();
                    TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                    item.Text = this.basecls.ReplaceSingleQuote(item.Text);
                    this.WhereConditionContact = "";
                    if (base.Session[string.Concat("searchContact", this.ClientID)] == null)
                    {
                        dataTable.Columns.Add("ColumnName");
                        dataTable.Columns.Add("Filter");
                        dataTable.Columns.Add("FilterText");
                    }
                    if (base.Session[string.Concat("searchContact", this.ClientID)] != null)
                    {
                        dataTable = (DataTable)base.Session[string.Concat("searchContact", this.ClientID)];
                    }
                    DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(second);
                    }
                    else
                    {
                        dataTable.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            dataTable.Rows.Add(objArray);
                        }
                    }
                    base.Session[string.Concat("searchContact", this.ClientID)] = dataTable;
                  
                    
                }
            }

            protected void RadGrid_Contact_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
            {
                this.dt_Contact = CompanyBasePage.client_contacts_select_for_filter(this.CompanyID, this.ClientID, this.WhereConditionContact);
               
            }

            protected void RadGrid_Department_ItemCommand(object sender, GridCommandEventArgs e)
            {
                DataTable dataTable = new DataTable();
                if (e.CommandName == "Filter")
                {
                    Pair commandArgument = (Pair)e.CommandArgument;
                    string str = commandArgument.Second.ToString();
                    TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                    item.Text = this.basecls.ReplaceSingleQuote(item.Text);
                    this.WhereConditionDepartment = "";
                    if (base.Session[string.Concat("searchDepartment", this.ClientID)] == null)
                    {
                        dataTable.Columns.Add("ColumnName");
                        dataTable.Columns.Add("Filter");
                        dataTable.Columns.Add("FilterText");
                    }
                    if (base.Session[string.Concat("searchDepartment", this.ClientID)] != null)
                    {
                        dataTable = (DataTable)base.Session[string.Concat("searchDepartment", this.ClientID)];
                    }
                    DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(second);
                    }
                    else
                    {
                        dataTable.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            dataTable.Rows.Add(objArray);
                        }
                    }
                
                   
                    
                }
            }

            protected void RadGrid_Department_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
            {
                this.dt_Department = DepartmentBaseClass.department_getAllDetails_for_filter(this.CompanyID, this.UserID, this.ClientID, (long)0, this.WhereConditionDepartment);
                
            }

            protected void RadGridAddress_OnRowDataBound(object sender, GridItemEventArgs e)
            {
                try
                {
                    if (e.Item.ItemType == GridItemType.CommandItem)
                    {
                        string empty = string.Empty;
                        empty = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
                        HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("DivAddNewRecord");
                        if (empty.Trim().ToLower() != "false")
                        {
                            htmlControl.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            htmlControl.Attributes.Add("style", "display:none");
                        }
                    }
                    if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                    {
                        string str = string.Empty;
                        str = this.basecls.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
                        Panel panel = (Panel)e.Item.FindControl("PanelDeleteAddress");
                        if (str.Trim().ToLower() != "false")
                        {
                            panel.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            panel.Attributes.Add("style", "display:none;");
                        }
                        Label label = (Label)e.Item.FindControl("lbl_Address");
                        HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Address");
                        HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_City");
                        HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_Suburb");
                        HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_PostCode");
                        HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_Country");
                        HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_AddressLabel");
                        HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_AddressLine2");
                        HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdn_DefaultDelivery");
                        HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdn_DefaultBilling");
                        HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hdn_DefaultPostBox");
                        Image image = (Image)e.Item.FindControl("img_DefaultDelivery");
                        Image image1 = (Image)e.Item.FindControl("img_DefaultBilling");
                        Image image2 = (Image)e.Item.FindControl("img_DefaultPostBox");
                        HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkBox_Address");
                        Image image3 = (Image)e.Item.FindControl("ImgButtonDeleteAddress");
                        if (hiddenField8.Value != "True")
                        {
                            image1.ImageUrl = string.Concat(this.ImgPath, "1t.gif");
                        }
                        else
                        {
                            image1.ImageUrl = string.Concat(this.ImgPath, "check.gif");
                        }
                        if (hiddenField9.Value != "True")
                        {
                            image2.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                        }
                        else
                        {
                            image2.ImageUrl = string.Concat(this.ImgPath, "ICON_checkboxNew.gif");
                        }
                    }
                }
                catch
                {
                }
            }

          

           

        }
    }