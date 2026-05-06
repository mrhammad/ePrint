using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.DataAccessLayer.Cart;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class approvalpending : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected Telerik.Web.UI.RadAjaxLoadingPanel RadAjaxLoadingPanel;

        //protected Telerik.Web.UI.RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected RadTabStrip RadTabStrip1;

        //protected HtmlImage ImgRegisApproved;

        //protected Label LblRegistrationMSG;

        //protected HtmlGenericControl DivregistrationMGS;

        //protected HtmlImage ImgProfileApproved;

        //protected Label LblUSermessage;

        //protected HtmlGenericControl DivUserApproved;

        //protected RadGrid radGridUser;

        //protected RadGrid AddressPending;

        //protected HtmlGenericControl div_approval;

        //protected Label lblErrorMsg;

        //protected LinkButton lnkGoBack;

        //protected HtmlTable tb_IncorrectLink;

        public long StoreUserID;

        public long AccountID;

        public string Email = string.Empty;

        public string strSitepath = string.Empty;

        public long AddressID;

        public int CompanyID;

        public languageClass objLanguage = new languageClass();

        private BaseClass objBaseClass = new BaseClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ApprovalType = string.Empty;

        private commonclass comm = new commonclass();

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public approvalpending()
        {
        }

        public void AddressGridBind(string Email, long AccountID)
        {
            try
            {
                DataTable editProfileApprovalPending = (new DBCart()).Get_Edit_Profile_Approval_Pending(Email, AccountID);
                foreach (DataRow row in editProfileApprovalPending.Rows)
                {
                    row["FirstName"] = base.SpecialDecode(row["FirstName"].ToString());
                    row["LastName"] = base.SpecialDecode(row["LastName"].ToString());
                    row["EmailID"] = base.SpecialDecode(row["EmailID"].ToString());
                    row["DesignatedApprovedEmail"] = base.SpecialDecode(row["DesignatedApprovedEmail"].ToString());
                    row["AddressLabel"] = base.SpecialDecode(row["AddressLabel"].ToString());
                }
                this.AddressPending.DataSource = editProfileApprovalPending;
                if (editProfileApprovalPending.Rows.Count <= 0)
                {
                    this.DivregistrationMGS.Attributes.Add("style", "display:none");
                    this.AddressPending.AllowPaging = false;
                }
                else
                {
                    this.AddressPending.AllowPaging = true;
                    if (editProfileApprovalPending.Rows[0]["IsApproved"].ToString().ToLower() != "true")
                    {
                        this.LblUSermessage.Visible = false;
                        this.ImgProfileApproved.Visible = false;
                    }
                    else
                    {
                        this.LblUSermessage.Visible = true;
                        this.ImgProfileApproved.Visible = true;
                        this.LblUSermessage.Text = "Edit Profile Approved Successfully";
                        this.RadTabStrip1.SelectedIndex = 1;
                    }
                    if (editProfileApprovalPending.Rows[0]["Rejected"].ToString().ToLower() != "true")
                    {
                        this.LblUSermessage.Visible = false;
                        this.ImgProfileApproved.Visible = false;
                    }
                    else
                    {
                        this.LblUSermessage.Visible = true;
                        this.ImgProfileApproved.Visible = true;
                        this.LblUSermessage.Text = "Edit Profile Rejected Successfully";
                        this.RadTabStrip1.SelectedIndex = 1;
                    }
                }
                this.AddressPending.DataBind();
            }
            catch
            {
            }
        }

        protected void AddressPending_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("btnAddressApproved");
                    if (((DataRowView)e.Item.DataItem)["Rejected"].ToString().ToLower() != "true")
                    {
                        imageButton.ImageUrl = "~/images/StoreImages/eye.png";
                        imageButton.CssClass = "ApprovedBtn";
                        imageButton.Enabled = true;
                    }
                    else
                    {
                        imageButton.ImageUrl = "~/images/StoreImages/Reject.png";
                        imageButton.CssClass = "ApprovedBtn1";
                        imageButton.Enabled = false;
                        imageButton.ToolTip = "Edit Profile Rejected";
                    }
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.AddressPending.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.AddressPending.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
            catch
            {
            }
        }

        protected void AddressPending_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataTable editProfileApprovalPending = (new DBCart()).Get_Edit_Profile_Approval_Pending(this.Email, this.AccountID);
                foreach (DataRow row in editProfileApprovalPending.Rows)
                {
                    row["FirstNAme"] = base.SpecialDecode(row["FirstNAme"].ToString());
                    row["LastNAme"] = base.SpecialDecode(row["LastNAme"].ToString());
                    row["AddressLabel"] = base.SpecialDecode(row["AddressLabel"].ToString());
                }
                if (editProfileApprovalPending.Rows.Count <= 0)
                {
                    this.AddressPending.AllowPaging = false;
                }
                else
                {
                    this.AddressPending.AllowPaging = true;
                }
                this.AddressPending.DataSource = editProfileApprovalPending;
            }
            catch
            {
            }
        }

        public void bindgrid(string Email, long AccountID)
        {
            try
            {
                this.AddressPending.MasterTableView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("First_Name");
                this.AddressPending.MasterTableView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("LAst_Name");
                this.AddressPending.MasterTableView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Email");
                this.AddressPending.MasterTableView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Approver_Email");
                this.AddressPending.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Address_Label");
                this.AddressPending.MasterTableView.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                this.radGridUser.MasterTableView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("First_Name");
                this.radGridUser.MasterTableView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("LAst_Name");
                this.radGridUser.MasterTableView.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Email");
                this.radGridUser.MasterTableView.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                this.RadTabStrip1.Tabs[0].Text = this.objLanguage.GetLanguageConversion("Registration_Pending");
                this.RadTabStrip1.Tabs[1].Text = this.objLanguage.GetLanguageConversion("Edit_Profile_Pending");
                DataTable _pendingApprovalUser = (new DBCart()).Get_pendingApprovalUser(Email, AccountID);
                foreach (DataRow row in _pendingApprovalUser.Rows)
                {
                    row["FirstName"] = base.SpecialDecode(row["FirstName"].ToString());
                    row["LastName"] = base.SpecialDecode(row["LastName"].ToString());
                    row["EmailID"] = base.SpecialDecode(row["EmailID"].ToString());
                    row["DesignatedApproverEmail"] = base.SpecialDecode(row["DesignatedApproverEmail"].ToString());
                }
                this.radGridUser.DataSource = _pendingApprovalUser;
                if (_pendingApprovalUser.Rows.Count <= 0)
                {
                    this.DivUserApproved.Attributes.Add("style", "display:none");
                    this.radGridUser.AllowPaging = false;
                }
                else
                {
                    this.radGridUser.AllowPaging = true;
                }
                this.radGridUser.DataBind();
                if (this.Session["PendingMessage"] != null && this.Session["PendingMessage"] != null)
                {
                    if (this.Session["PendingMessage"].ToString() == "Approved")
                    {
                        this.LblRegistrationMSG.Visible = true;
                        this.ImgRegisApproved.Visible = true;
                        this.LblRegistrationMSG.Text = "User Registration Approved Successfully";
                        this.DivUserApproved.Attributes.Add("style", "display:none");
                    }
                    if (this.Session["PendingMessage"].ToString() == "Rejected")
                    {
                        this.LblRegistrationMSG.Visible = true;
                        this.ImgRegisApproved.Visible = true;
                        this.LblRegistrationMSG.Text = "User Registration rejected Successfully";
                        this.DivUserApproved.Attributes.Add("style", "display:none");
                    }
                }
                this.Session["PendingMessage"] = null;
            }
            catch
            {
            }
        }

        protected void btnAction_Click(object sender, CommandEventArgs e)
        {
            QueryString queryString = new QueryString()
        {
            { "userID", e.CommandArgument.ToString() },
            { "AccountID", this.AccountID.ToString() }
        };
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            base.Response.Redirect(string.Concat(this.strSitepath, "userregisterapproval.aspx", queryString1.ToString()));
        }

        protected void btnAddressApproved_Click(object sender, CommandEventArgs e)
        {
            this.Session["RegisterPendingUserID"] = e.CommandArgument.ToString();
            base.Response.Redirect(string.Concat(this.strSitepath, "userprofileapproval.aspx"));
        }

        protected void lnkGoBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
        }

        public void Logout()
        {
            HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
            if (item != null)
            {
                commonclass _commonclass = new commonclass();
                SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                sqlCommand.ExecuteNonQuery();
                _commonclass.closeConnection();
                base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
            }
            HttpCookie dateTime = base.Response.Cookies["ResumeSessionID"];
            commonclass _commonclass1 = this.comm;
            DateTime dateTime1 = DateTime.Now.AddDays(-1);
            dateTime.Expires = Convert.ToDateTime(_commonclass1.Eprint_return_ActualDate_Before_View(dateTime1.ToString(), this.CompanyID, Convert.ToInt32(this.Session["StoreUserID"]), true));
            this.Session["StoreUserID"] = "";
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            base.Response.Redirect(string.Concat(this.strSitepath, "logout.aspx?id=", this.AccountID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "approvalpending.aspx'></a> ", this.objLanguage.GetLanguageConversion("Approval_Pending"));
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }
            if (this.Session["EmailID"] != null)
            {
                this.Email = this.Session["EmailID"].ToString();
            }
            if (this.Session["AccountID"] != null)
            {
                this.AccountID = Convert.ToInt64(this.Session["AccountID"]);
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && this.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            this.lnkGoBack.Text = this.objLanguage.GetLanguageConversion("Go_Back");
            this.objBaseClass.Assign_ApprovalSystemSettings_ForAccount(this.AccountID);
            if (this.Session["ApprovalSystem"] == null)
            {
                this.div_approval.Visible = false;
                this.tb_IncorrectLink.Visible = true;
                this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("Approval_Feature_Disabled_Msg");
                ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                return;
            }
            if (this.Session["ApprovalSystem"].ToString() != "on")
            {
                this.div_approval.Visible = false;
                this.tb_IncorrectLink.Visible = true;
                this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("Approval_Feature_Disabled_Msg");
                ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                return;
            }
            this.ApprovalType = this.objBaseClass.Return_ApprovalSystem_Settings("approvaltype");
            if (this.ApprovalType == "u")
            {
                this.Logout();
            }
            else if (this.ApprovalType == "a" || this.ApprovalType == "da")
            {
                string empty = string.Empty;
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                empty = LoginBasePage.UserTypeCheck(this.StoreUserID);
                if (empty.ToLower() == "u")
                {
                    this.Logout();
                }
                if (this.ApprovalType == "a" && empty.ToLower() == "d")
                {
                    this.Logout();
                }
            }
            this.bindgrid(this.Email, this.AccountID);
            base.Title = commonclass.pageTitle(this.objLanguage.GetLanguageConversion("Approval_Pending"), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
        }

        protected void radGridUser_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("btnAction");
                    if (((DataRowView)e.Item.DataItem)["IsUserRejected"].ToString().ToLower() != "true")
                    {
                        imageButton.ImageUrl = "~/images/StoreImages/eye.png";
                        imageButton.CssClass = "ApprovedBtn";
                        imageButton.Enabled = true;
                    }
                    else
                    {
                        imageButton.ImageUrl = "~/images/StoreImages/Reject.png";
                        imageButton.CssClass = "ApprovedBtn1";
                        imageButton.Enabled = false;
                        imageButton.ToolTip = "User Registration Rejected";
                    }
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.radGridUser.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.radGridUser.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
            catch
            {
            }
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (this.RadTabStrip1.SelectedIndex == 0)
            {
                this.radGridUser.Visible = true;
                this.AddressPending.Visible = false;
                this.bindgrid(this.Email, this.AccountID);
                return;
            }
            this.DivregistrationMGS.Attributes.Add("style", "display:none");
            this.DivUserApproved.Attributes.Add("style", "display:block");
            this.AddressPending.Visible = true;
            this.radGridUser.Visible = false;
            this.AddressGridBind(this.Email, this.AccountID);
        }
    }
}