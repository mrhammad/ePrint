using ePrint.usercontrol.Item;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ePrint.common
{
    public partial class Summary_Page_Common_popup : System.Web.UI.Page, IRequiresSessionState
    {
        public string type;

        public string item;

        public string From;

        public string module;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public Summary_Page_Common_popup()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pgName = "";
            try
            {
                if (base.Request.QueryString["type"] != null)
                {
                    this.type = base.Request.QueryString["type"].ToString();
                }
                if (base.Request.QueryString["module"] != null)
                {
                    this.module = base.Request.QueryString["module"].ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.QueryString["item"] != null)
                {
                    this.item = base.Request.QueryString["item"].ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.QueryString["From"] != null)
                {
                    this.From = base.Request.QueryString["From"].ToString();
                }
            }
            catch
            {
            }
            if (this.type == null)
            {
                base.Response.Write("No type found");
            }
            else
            {
                if (this.type.ToLower() == "copytonewcust" || this.type.ToLower() == "copytosamecust")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    if (this.type.ToLower() != "copytonewcust" && this.type.ToLower() != "copytosamecust")
                    {
                        base.Title = this.objLanguage.GetLanguageConversion("Alert");
                    }
                    else if (base.Request.QueryString["pg"] == "estimate")
                    {
                        base.Title = this.objLanguage.GetLanguageConversion("Copy_Estimate");
                    }
                    else if (base.Request.QueryString["pg"] == "job")
                    {
                        base.Title = this.objLanguage.GetLanguageConversion("Copy_Job");
                    }
                    else if (base.Request.QueryString["pg"] == "invoice")
                    {
                        base.Title = this.objLanguage.GetLanguageConversion("Copy_Invoice");
                    }
                    UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/Item/Item_Summary_CopytoNew_SameCustomer.ascx");
                    this.plhDiv.Controls.Add(userControl);
                }
                else if (this.type.ToLower() == "activityhistory")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = this.objLanguage.GetLanguageConversion("View_History");
                    notes num = (notes)base.LoadControl("~/usercontrol/Item/notes.ascx");
                    num.ItemID = Convert.ToInt64(base.Request.QueryString["ItemID"]);
                    this.plhDiv.Controls.Add(num);
                }
                else if (this.type.ToLower() == "contacthistory")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Contact History";
                    notes usercontrolItemNote = (notes)base.LoadControl("~/usercontrol/Item/notes.ascx");
                    usercontrolItemNote.ItemID = Convert.ToInt64(base.Request.QueryString["ItemID"]);
                    this.plhDiv.Controls.Add(usercontrolItemNote);
                }
                if (this.type.ToLower() == "reverttoestimate" && this.module == "order")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = this.objLanguage.GetLanguageConversion("Revert_To_Order");
                    UserControl userControl1 = (UserControl)base.LoadControl("~/usercontrol/Item/Job_Revert_To_Estimate.ascx");
                    this.plhDiv.Controls.Add(userControl1);
                    return;
                }
                if (this.type.ToLower() == "reverttoestimate" && this.module == "estimate")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = this.objLanguage.GetLanguageConversion("Revert_To_Estimate");
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Item/Job_Revert_To_Estimate.ascx");
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "deliverydate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Delivery Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/DeliveryDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtDeliveryDate = (TextBox)userControl2.FindControl("txtDeliveryDate");
                        txtDeliveryDate.Text = base.Request.QueryString["deliveyDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "proofdate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Proof Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/ProofDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtDeliveryDate = (TextBox)userControl2.FindControl("txtProofDate");
                        txtDeliveryDate.Text = base.Request.QueryString["proofDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "estimateddeliverydate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Estimated Delivery Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/EstimatedDeliveryDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtDeliveryDate = (TextBox)userControl2.FindControl("txtEstimatedDeliveryDate");
                        txtDeliveryDate.Text = base.Request.QueryString["estimatedDeliveyDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "actualdeliverydate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Actual Delivery Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/ActualDeliveryDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtDeliveryDate = (TextBox)userControl2.FindControl("txtActualDeliveryDate");
                        txtDeliveryDate.Text = base.Request.QueryString["actualDeliveyDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "jobdate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Job Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/JobDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtJobDate = (TextBox)userControl2.FindControl("txtJobDate");
                        txtJobDate.Text = base.Request.QueryString["jobDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "artworkdate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Artwork Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/Artwork_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtArtworkDate = (TextBox)userControl2.FindControl("txtArtworkDate");
                        txtArtworkDate.Text = base.Request.QueryString["artworkDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "completiondate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Completion Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/Completion_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtCompletionDate = (TextBox)userControl2.FindControl("txtCompletionDate");
                        txtCompletionDate.Text = base.Request.QueryString["completionDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "productiondate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Production Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/ProductionDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtProductionDate = (TextBox)userControl2.FindControl("txtProductionDate");
                        txtProductionDate.Text = base.Request.QueryString["productionDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "approvaldate_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Approval Date";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/ApprovalDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var txtApprovalDate = (TextBox)userControl2.FindControl("txtApprovalDate");
                        txtApprovalDate.Text = base.Request.QueryString["approvalDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "customdate1_update")
                {
                    var Datetitle = "";
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString())).Rows)
                    {
                        Datetitle = row["DefaultCustomDateTitle1"].ToString();
                       
                    }
                    base.Title = string.IsNullOrEmpty(Datetitle) ? "Change Custom Date 1" : Datetitle;

                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                  
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/CustomDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var lblDateTitle = (Label)userControl2.FindControl("lbldatetitle");
                        lblDateTitle.Text = string.IsNullOrEmpty(Datetitle) ? "Custom Date 1" : Datetitle; ;

                        var txtCustomDate = (TextBox)userControl2.FindControl("txtCustomDate");
                        txtCustomDate.Text = base.Request.QueryString["customDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];

                        var hdnDateNo = (HiddenField)userControl2.FindControl("hdnDateNo");
                        hdnDateNo.Value = "1";
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                if (this.type.ToLower() == "customdate2_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    var Datetitle = "";
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString())).Rows)
                    {
                        Datetitle = row["DefaultCustomDateTitle2"].ToString();

                    }
                    base.Title = string.IsNullOrEmpty(Datetitle) ? "Change Custom Date 2" : Datetitle;

                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/CustomDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var lblDateTitle = (Label)userControl2.FindControl("lbldatetitle");
                        lblDateTitle.Text = string.IsNullOrEmpty(Datetitle) ? "Custom Date 2" : Datetitle; ;

                        var txtCustomDate = (TextBox)userControl2.FindControl("txtCustomDate");
                        txtCustomDate.Text = base.Request.QueryString["customDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];

                        var hdnDateNo = (HiddenField)userControl2.FindControl("hdnDateNo");
                        hdnDateNo.Value = "2";
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "customdate3_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    var Datetitle = "";
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString())).Rows)
                    {
                        Datetitle = row["DefaultCustomDateTitle3"].ToString();

                    }
                    base.Title = string.IsNullOrEmpty(Datetitle) ? "Change Custom Date 3" : Datetitle;

                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/CustomDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var lblDateTitle = (Label)userControl2.FindControl("lbldatetitle");
                        lblDateTitle.Text = string.IsNullOrEmpty(Datetitle) ? "Custom Date 3" : Datetitle; ;

                        var txtCustomDate = (TextBox)userControl2.FindControl("txtCustomDate");
                        txtCustomDate.Text = base.Request.QueryString["customDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];

                        var hdnDateNo = (HiddenField)userControl2.FindControl("hdnDateNo");
                        hdnDateNo.Value = "3";
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "customdate4_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    var Datetitle = "";
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString())).Rows)
                    {
                        Datetitle = row["DefaultCustomDateTitle4"].ToString();

                    }
                    base.Title = string.IsNullOrEmpty(Datetitle) ? "Change Custom Date 4" : Datetitle;

                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/CustomDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var lblDateTitle = (Label)userControl2.FindControl("lbldatetitle");
                        lblDateTitle.Text = string.IsNullOrEmpty(Datetitle) ? "Custom Date 4" : Datetitle; ;

                        var txtCustomDate = (TextBox)userControl2.FindControl("txtCustomDate");
                        txtCustomDate.Text = base.Request.QueryString["customDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];

                        var hdnDateNo = (HiddenField)userControl2.FindControl("hdnDateNo");
                        hdnDateNo.Value = "4";
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
                if (this.type.ToLower() == "customdate5_update")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    var Datetitle = "";
                    foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString())).Rows)
                    {
                        Datetitle = row["DefaultCustomDateTitle5"].ToString();

                    }
                    base.Title = string.IsNullOrEmpty(Datetitle) ? "Change Custom Date 5" : Datetitle;

                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/CustomDate_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var lblDateTitle = (Label)userControl2.FindControl("lbldatetitle");
                        lblDateTitle.Text = string.IsNullOrEmpty(Datetitle) ? "Custom Date 5" : Datetitle; ;

                        var txtCustomDate = (TextBox)userControl2.FindControl("txtCustomDate");
                        txtCustomDate.Text = base.Request.QueryString["customDate"];

                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];

                        var hdnEstimateItemID = (HiddenField)userControl2.FindControl("hdnEstimateItemID");
                        hdnEstimateItemID.Value = base.Request.QueryString["estimateItemId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();

                        var hdnDateFormat = (HiddenField)userControl2.FindControl("hdnDateFormat");
                        hdnDateFormat.Value = base.Request.QueryString["format"];

                        var hdnDateNo = (HiddenField)userControl2.FindControl("hdnDateNo");
                        hdnDateNo.Value = "5";
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }


                if (this.type.ToLower() == "salesperson")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Change Sales Person";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/SalesPerson_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var hdnJobId = (HiddenField)userControl2.FindControl("hdnJobId");
                        hdnJobId.Value = base.Request.QueryString["JobId"];
                        
                        var hdnSalesPersonId = (HiddenField)userControl2.FindControl("hdnSalesPersonId");
                        hdnSalesPersonId.Value = base.Request.QueryString["salesPersonId"];

                        var hdnReloadUrl = (HiddenField)userControl2.FindControl("hdnReloadUrl");
                        hdnReloadUrl.Value = base.Request.UrlReferrer.ToString();
                        if(base.Request.QueryString["userType"] != null)
                        {
                            var hdnType = (HiddenField)userControl2.FindControl("hdnType");
                            hdnType.Value = base.Request.QueryString["userType"];
                            if (hdnType.Value == "estimator")
                            {
                                base.Title = "Change Estimator";
                            }
                        }
                        
                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }

                else if (this.type.ToLower() == "priority")
                {
                    this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                    base.Title = "Priority";
                    UserControl userControl2 = (UserControl)base.LoadControl("~/usercontrol/Fields/Priority_Update.ascx");

                    if (!Page.IsPostBack)
                    {
                        var hdnpg = (HiddenField)userControl2.FindControl("hdnpage");
                        hdnpg.Value = base.Request.QueryString["pg"];
                        var hdnid = (HiddenField)userControl2.FindControl("hdnId");
                        hdnid.Value = base.Request.QueryString["id"];

                        var hdnpriority = (HiddenField)userControl2.FindControl("hdnpriority");
                        hdnpriority.Value = base.Request.QueryString["priority"];

                    }
                    this.plhDiv.Controls.Add(userControl2);
                    return;
                }
            }
        }
    }
}