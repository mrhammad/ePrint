using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Prefligt;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Ionic.Zip;

namespace ePrint.usercontrol.Item
{
    public partial class attachments : UsercontrolBasePage
    {

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string SecureDocFilepath = global.SecureDocFilepath();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureSitePath = global.SecureSitePath();

        public string PublicDocPath = global.PublicDocPath();

        public string ServerName = string.Empty;

        public string estoredisplay = "0";

        public string pdfimagedisplay = "0";

        public bool val;

        public bool val1;

        public int CompanyID;

        public int UserID;

        public string firstName = string.Empty;

        public string ItemNo = string.Empty;

        public long AttachmentID;

        public string AttachmentType = string.Empty;

        public string type = string.Empty;

        public long AttachmentTypeID;

        public string FileName = string.Empty;

        public string OriginalAttachFileName = string.Empty;

        public string FileID = string.Empty;

        public string Mode = string.Empty;

        public string TabSelection = string.Empty;

        public long EstimateID;

        public long PurchaseID;

        public string EstimateItemID = string.Empty;

        public string EstimateType = string.Empty;

        public string ItemTitle = string.Empty;

        public string[] ArryEstType;

        public string[] ArrEstItemID;

        public string ddlSelect = string.Empty;

        public string ddlSelectType = string.Empty;

        public string pg = string.Empty;

        public string ItemType = string.Empty;

        public long DeliveryID;

        public long Estimateitemid;

        public long EstPurchaseID;

        public long StoreUserID;

        public static long AccountID;

        public long OrderID;

        public long AttachmentTypeID_eStore;

        private notesclass objnotes = new notesclass();

        private commonClass commclass = new commonClass();

        private Notes objN = new Notes();

        public string DateFormat = string.Empty;

        public string newdate = string.Empty;

        public long DeliveryItemID;

        public static bool Isddlbind;

        public string StrDownload = string.Empty;

        public string strFilepath = global.filePath();

        public string FileCheck = string.Empty;

        public string EstNo = string.Empty;

        public string NewFileName = string.Empty;

        public string FileduplicacyCheck = string.Empty;

        public string AttachSupRFQ = string.Empty;

        public string ActualSupRFQ = string.Empty;

        public string AttachImageID = string.Empty;

        public string UploadedBy = string.Empty;

        public string StreStorAttach = string.Empty;

        public string FrmAttach = string.Empty;

        public string ModuleType = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        public commonClass objcommon = new commonClass();

        public Preflight_documents objPreflight = new Preflight_documents();

        public string cellvalue_AttachFile = string.Empty;

        public string AttachmentSection = string.Empty;
        public static string _url;
        public static int proofID;
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

        static attachments()
        {
        }

        public attachments()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            for (int i = 0; i < this.RadGrid_Specific.Columns.Count; i++)
            {
                if (this.RadGrid_Specific.Columns[i].SortExpression.ToLower() == "filename")
                {
                    this.cellvalue_AttachFile = this.RadGrid_Specific.Columns[i].SortExpression;
                }
            }
        }

        protected void btnUpload_OnClick_General(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string originalAttachFileName = string.Empty;
            string originalAttachFileName1 = string.Empty;
            string str1 = string.Empty;
            //if (this.chk_displayFileToPdf.Checked)
            //{
            //    this.pdfimagedisplay = "true";
            //    this.val = Convert.ToBoolean(this.pdfimagedisplay);
            //}
            if (this.FileUpload4.HasFile || this.FileUpload4.FileName != "")
            {
                this.CallFileUpload_General(this.FileUpload4, Convert.ToInt64(this.hid_AttachmentID4.Value), out this.FileName, out this.OriginalAttachFileName);//, this.val);
                empty = this.commclass.ReplaceSplSymbol(this.FileName);
                originalAttachFileName = this.OriginalAttachFileName;
                notesclass _notesclass = this.objnotes;
                string[] secureSitePath = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>" };
                _notesclass.attachments = string.Concat(secureSitePath);
            }
            if (this.FileUpload5.HasFile || this.FileUpload5.FileName != "")
            {
                this.CallFileUpload_General(this.FileUpload5, Convert.ToInt64(this.hid_AttachmentID5.Value), out this.FileName, out this.OriginalAttachFileName);//, this.val);
                str = this.commclass.ReplaceSplSymbol(this.FileName);
                originalAttachFileName1 = this.OriginalAttachFileName;
                if (!this.FileUpload4.HasFile)
                {
                    notesclass _notesclass1 = this.objnotes;
                    string[] strArrays = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>" };
                    _notesclass1.attachments = string.Concat(strArrays);
                }
                else
                {
                    notesclass _notesclass2 = this.objnotes;
                    string[] secureSitePath1 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>" };
                    _notesclass2.attachments = string.Concat(secureSitePath1);
                }
            }
            if (this.FileUpload6.HasFile || this.FileUpload6.FileName != "")
            {
                this.CallFileUpload_General(this.FileUpload6, Convert.ToInt64(this.hid_AttachmentID6.Value), out this.FileName, out this.OriginalAttachFileName);//, this.val);
                empty1 = this.commclass.ReplaceSplSymbol(this.FileName);
                str1 = this.OriginalAttachFileName;
                if (this.FileUpload5.HasFile)
                {
                    notesclass _notesclass3 = this.objnotes;
                    string[] strArrays1 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass3.attachments = string.Concat(strArrays1);
                }
                if (this.FileUpload4.HasFile)
                {
                    notesclass _notesclass4 = this.objnotes;
                    string[] secureSitePath2 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass4.attachments = string.Concat(secureSitePath2);
                }
                if (!this.FileUpload5.HasFile || !this.FileUpload4.HasFile)
                {
                    notesclass _notesclass5 = this.objnotes;
                    string[] strArrays2 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass5.attachments = string.Concat(strArrays2);
                }
                else
                {
                    notesclass _notesclass6 = this.objnotes;
                    string[] secureSitePath3 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass6.attachments = string.Concat(secureSitePath3);
                }
            }
            if (base.Request.Params["pg"].ToString().ToLower() == "estimate")
            {
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "job")
            {
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "webstoreorder")
            {
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderAdd_attachment);
            }
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass7 = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass7.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.pg.ToLower() == "webstoreorder")
            {
                this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            }
            else if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
            {
                this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Uploaded_Successfully"), "msg-success", this.plhMessage);
        }

        protected void btnUpload_OnClick_Specific(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string originalAttachFileName = string.Empty;
            string originalAttachFileName1 = string.Empty;
            string str1 = string.Empty;
            this.estoredisplay = this.hid_displaytoestore.Value;
            if (this.chk_displayFileToEstore.Checked)
            {
                this.estoredisplay = "true";
                this.val = Convert.ToBoolean(this.estoredisplay);
            }
            if (this.chk_displayFileToPdf.Checked)
            {
                this.pdfimagedisplay = "true";
                this.val1 = Convert.ToBoolean(this.pdfimagedisplay);
            }
            if (this.FileUpload1.HasFile || this.FileUpload1.FileName != "")
            {
                this.CallFileUpload_specific(this.FileUpload1, Convert.ToInt64(this.hid_AttachmentID1.Value), out this.FileName, out this.OriginalAttachFileName, this.val, this.val1);
                empty = this.commclass.ReplaceSplSymbol(this.FileName);
                originalAttachFileName = this.OriginalAttachFileName;
                notesclass _notesclass = this.objnotes;
                string[] secureSitePath = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>" };
                _notesclass.attachments = string.Concat(secureSitePath);
            }
            if (this.FileUpload2.HasFile || this.FileUpload2.FileName != "")
            {
                this.CallFileUpload_specific(this.FileUpload2, Convert.ToInt64(this.hid_AttachmentID2.Value), out this.FileName, out this.OriginalAttachFileName, this.val, this.val1);
                str = this.commclass.ReplaceSplSymbol(this.FileName);
                originalAttachFileName1 = this.OriginalAttachFileName;
                if (!this.FileUpload1.HasFile)
                {
                    notesclass _notesclass1 = this.objnotes;
                    string[] strArrays = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>" };
                    _notesclass1.attachments = string.Concat(strArrays);
                }
                else
                {
                    notesclass _notesclass2 = this.objnotes;
                    string[] secureSitePath1 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>" };
                    _notesclass2.attachments = string.Concat(secureSitePath1);
                }
            }
            if (this.FileUpload3.HasFile || this.FileUpload3.FileName != "")
            {
                this.CallFileUpload_specific(this.FileUpload3, Convert.ToInt64(this.hid_AttachmentID3.Value), out this.FileName, out this.OriginalAttachFileName, this.val, this.val1);
                empty1 = this.commclass.ReplaceSplSymbol(this.FileName);
                str1 = this.OriginalAttachFileName;
                if (this.FileUpload2.HasFile)
                {
                    notesclass _notesclass3 = this.objnotes;
                    string[] strArrays1 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass3.attachments = string.Concat(strArrays1);
                }
                if (this.FileUpload1.HasFile)
                {
                    notesclass _notesclass4 = this.objnotes;
                    string[] secureSitePath2 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass4.attachments = string.Concat(secureSitePath2);
                }
                if (!this.FileUpload2.HasFile || !this.FileUpload1.HasFile)
                {
                    notesclass _notesclass5 = this.objnotes;
                    string[] strArrays2 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass5.attachments = string.Concat(strArrays2);
                }
                else
                {
                    notesclass _notesclass6 = this.objnotes;
                    string[] secureSitePath3 = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(originalAttachFileName), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", str, "' target='_blank'>", Convert.ToString(originalAttachFileName1), "</a>, <a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty1, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                    _notesclass6.attachments = string.Concat(secureSitePath3);
                }
            }
            if (base.Request.Params["pg"].ToString().ToLower() == "estimate")
            {
                if (base.Request.QueryString["estid"].ToString().Contains(","))
                {
                    List<string> _estimateIDs = new List<string>(base.Request.QueryString["estid"].ToString().Split(new string[] { "," }, StringSplitOptions.None));
                    this.EstimateID = Convert.ToInt64(_estimateIDs[0]);
                }
                else
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);

                }
                this.objnotes.ModuleName = "estimate";
                this.objnotes.ItemID = this.AttachmentTypeID;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstAdd_attachment);
                string statusID = this.proof_status.SelectedValue;
                if (string.IsNullOrEmpty(statusID))
                {
                    statusID = "0";
                }
                if (_url.Contains("ProofID"))
                {
                    if (this.chk_IsAttachProof.Checked)
                    {
                        DataTable dt = new DataTable();
                        if ((this.FileUpload1.HasFile || this.FileUpload1.FileName != "") && (this.FileUpload2.HasFile || this.FileUpload2.FileName != "") && (this.FileUpload3.HasFile || this.FileUpload3.FileName != ""))
                        {
                            if(string.IsNullOrEmpty(this.EstimateItemID))
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 3, 0);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(0, Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now,this.CompanyID, int.Parse(statusID));
                                }
                            }
                            else
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 3, int.Parse(this.EstimateItemID));
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(int.Parse(this.EstimateItemID), Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now, this.CompanyID, int.Parse(statusID));
                                }
                            }
                           
                        }
                        else if ((this.FileUpload1.HasFile || this.FileUpload1.FileName != "") && (this.FileUpload2.HasFile || this.FileUpload2.FileName != ""))
                        {
                            if (string.IsNullOrEmpty(this.EstimateItemID))
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 2, 0);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(0, Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now,this.CompanyID, int.Parse(statusID));
                                }
                            }
                            else
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 2, int.Parse(this.EstimateItemID));
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(int.Parse(this.EstimateItemID), Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now, this.CompanyID, int.Parse(statusID));
                                }
                            }
                           
                        }
                        else if (this.FileUpload1.HasFile || this.FileUpload1.FileName != "")
                        {
                            if (string.IsNullOrEmpty(this.EstimateItemID))
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 1, 0);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(0, Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now, this.CompanyID, int.Parse(statusID));
                                }
                            }
                            else
                            {
                                dt = EstimateBasePage.GetProofAttachmentID(this.EstimateID, UserID, 1, int.Parse(this.EstimateItemID));
                                foreach (DataRow dr in dt.Rows)
                                {
                                    EstimateBasePage.Create_proof_detail(int.Parse(this.EstimateItemID), Convert.ToInt64(dr["AttachmentID"].ToString()), proofID, UserID, DateTime.Now, this.CompanyID, int.Parse(statusID));
                                }
                            }
                        
                        }
                    }
                }

            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "job")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.objnotes.ModuleName = "job";
                this.objnotes.ItemID = this.AttachmentTypeID;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "invoice")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.objnotes.ModuleName = "invoice";
                this.objnotes.ItemID = this.AttachmentTypeID;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "purchase")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["PurchaseID"]);
                this.objnotes.ModuleName = "Purchase";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "deliverynote")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["DeliveryID"]);
                this.objnotes.ModuleName = "deliverynote";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelAdd_attachment);
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "webstoreorder")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.ItemID = this.AttachmentTypeID;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderAdd_attachment);
            }
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass7 = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass7.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
            {
                this.RadGrid_Specific_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            }
            if (this.pg.ToLower() == "purchase")
            {
                this.RadGrid_PO_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.PurchaseID);
            }
            else if (this.pg.ToLower() == "deliverynote")
            {
                this.RadGrid_DN_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.DeliveryID, this.EstimateID);
            }
            else if (this.pg.ToLower() == "webstoreorder")
            {
                this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Uploaded_Successfully"), "msg-success", this.plhMessage);
        }

        public void CallFileUpload_General(FileUpload FileUploadName, long AttachmentID, out string FileName, out string OriginalAttachFileName)//, bool val
        {
            string empty = string.Empty;
            FileName = string.Empty;
            OriginalAttachFileName = string.Empty;

            string newFileName = this.objcommon.ReplaceSplSymbol(FileUploadName.FileName);
            string fileName = FileUploadName.FileName;
            if (FileUploadName.HasFile || FileUploadName.FileName != "")
            {
                string[] strArrays = FileUploadName.FileName.ToString().Trim().Split(new char[] { '.' });
                newFileName = string.Concat(this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo);
                newFileName = this.objBase.ReplaceSingleQuote(newFileName);
                DataTable dataTable = EstimateBasePage.Attachment_Duplicate_CheckChange(this.EstimateID, this.objBase.ReplaceSingleQuote(newFileName));
                if (dataTable.Rows.Count < 1)
                {
                    string[] strArrays1 = new string[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, ".", strArrays[(int)strArrays.Length - 1] };
                    newFileName = string.Concat(strArrays1);
                }
                else
                {
                    newFileName = string.Concat(this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_");
                    newFileName = this.objBase.ReplaceSingleQuote(newFileName);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        attachments usercontrolItemAttachment = this;
                        usercontrolItemAttachment.FileCheck = string.Concat(usercontrolItemAttachment.FileCheck, row["Filename"].ToString(), "‡");
                    }
                    int num = 1;
                    string[] strArrays2 = this.FileCheck.Split(new char[] { '‡' });
                    for (int i = 0; i < (int)strArrays2.Length - 1; i++)
                    {
                        string[] strArrays3 = strArrays2[i].Split(new char[] { '.' });
                        string str = strArrays3[0];
                        string str1 = strArrays3[0].Substring(strArrays3[0].LastIndexOf('\u005F') + 1);
                        if (!(str.Remove(str.Length - 1) == newFileName) || Convert.ToInt32(str1) != num)
                        {
                            object[] objArray = new object[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_", 1, ".", strArrays[(int)strArrays.Length - 1] };
                            this.NewFileName = string.Concat(objArray);
                        }
                        else
                        {
                            num++;
                            object[] objArray1 = new object[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_", num, ".", strArrays[(int)strArrays.Length - 1] };
                            this.NewFileName = string.Concat(objArray1);
                        }
                    }
                    newFileName = this.NewFileName;
                }
                string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", this.objBase.ReplaceSingleQuote(newFileName) };
                FileUploadName.SaveAs(string.Concat(secureDocPath));
                string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                empty = string.Concat(secureDocPath1);
            }
            else
            {
                newFileName = string.Empty;
                empty = string.Empty;
            }
            if (base.Request.Params["pg"].ToString().ToLower() == "estimate")
            {
                this.AttachmentType = "E";
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "job")
            {
                this.AttachmentType = "J";
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "invoice")
            {
                this.AttachmentType = "I";
            }
            else if (base.Request.Params["pg"].ToString().ToLower() == "webstoreorder")
            {
                this.AttachmentType = " ";
            }
            EstimateItem estimateItem = new EstimateItem()
            {
                CompanyID = this.CompanyID,
                AttachmentID = AttachmentID,
                OriginalFileName = fileName
            };
            //if (this.pg.ToLower() == "webstoreorder")
            {
                estimateItem.AttachmentType = this.AttachmentType;
                estimateItem.AttachmentTypeID = this.Estimateitemid;
                if (this.pg.ToLower() == "webstoreorder")
                {
                    estimateItem.AttachmentType = this.AttachmentType;
                    estimateItem.AttachmentTypeID = (long)0;
                }
                else if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
                {
                    estimateItem.AttachmentType = "";
                    estimateItem.AttachmentTypeID = (long)0;
                }
                estimateItem.EstimateID = this.EstimateID;
                estimateItem.UploadedBy = this.UserID;
                estimateItem.ModuleType = this.ModuleType;
                // estimateItem.IsDisplayToPdf = val;
                estimateItem.FileName = this.objBase.ReplaceSingleQuote(newFileName);
                FileName = newFileName;
                OriginalAttachFileName = fileName;
                if (estimateItem.FileName.Trim() != "")
                {
                    string[] strArrays4 = estimateItem.FileName.ToString().Split(new char[] { '.' });
                    if (this.chkPreflightGeneral != null && this.chkPreflightGeneral.Checked && strArrays4[(int)strArrays4.Length - 1].ToString().ToLower() == "pdf")
                    {
                        PreflightParameters preflightParameter = this.objPreflight.Preflight_file(estimateItem.FileName, this.ddlPreflightGeneral.SelectedItem.Text, attachments.AccountID.ToString(), this.CompanyID.ToString(), empty);
                        if (preflightParameter.IsPreflighted)
                        {
                            estimateItem.FileName = preflightParameter.CorrectedFile;
                            estimateItem.ReportFile = preflightParameter.ReportFile;
                        }
                    }
                }
                EstimateBasePage.etimates_attachment_insert(estimateItem);
                this.chkPreflightGeneral.Checked = false;
            }
        }

        public void CallFileUpload_specific(FileUpload FileUploadName, long AttachmentID, out string FileName, out string OriginalAttachFileName, bool val,bool val1)
        {
            string newFileName = this.objcommon.ReplaceSplSymbol(FileUploadName.FileName);
            string fileName = FileUploadName.FileName;
            string empty = string.Empty;
            EstimateItem estimateItem = new EstimateItem()
            {
                CompanyID = this.CompanyID,
                AttachmentID = AttachmentID,
                OriginalFileName = fileName
            };
            if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
            {
                estimateItem.AttachmentType = this.hdn_ddlEstType.Value;
                this.AttachmentType = this.hdn_ddlEstType.Value;
                estimateItem.AttachmentTypeID = Convert.ToInt64(this.hdn_ddlEstitemID.Value);
                this.AttachmentTypeID = Convert.ToInt64(this.hdn_ddlEstitemID.Value);
                estimateItem.EstimateID = this.EstimateID;
            }
            else if (this.pg.ToLower() == "purchase")
            {
                DataTable dataTable = EstimateBasePage.EstimateItemID_Select(this.CompanyID, this.UserID, this.PurchaseID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.EstPurchaseID = Convert.ToInt64(row["Estimateitemid"].ToString());
                    this.EstimateID = Convert.ToInt64(row["EstimateID"].ToString());
                    this.EstNo = row["PONO"].ToString();
                }
                estimateItem.AttachmentType = "Y";
                this.AttachmentType = "Y";
                estimateItem.AttachmentTypeID = (long)0;
                this.AttachmentTypeID = this.EstPurchaseID;
                estimateItem.EstimateID = this.PurchaseID;
                this.EstimateID = this.PurchaseID;
            }
            else if (this.pg.ToLower() == "deliverynote")
            {
                foreach (DataRow dataRow in EstimateBasePage.DeliveryNote_ItemID_Select(this.DeliveryID).Rows)
                {
                    this.DeliveryItemID = Convert.ToInt64(dataRow["ItemID"].ToString());
                    this.EstimateID = Convert.ToInt64(dataRow["EstimateID"].ToString());
                    this.EstNo = dataRow["DeliveryNumber"].ToString();
                }
                estimateItem.AttachmentType = "Z";
                this.AttachmentType = "Z";
                estimateItem.AttachmentTypeID = (long)0;
                this.AttachmentTypeID = this.DeliveryItemID;
                estimateItem.EstimateID = this.DeliveryID;
                this.EstimateID = this.DeliveryID;
            }
            else if (this.pg.ToLower() == "webstoreorder")
            {
                if (this.hdn_ddlEstitemID.Value != "0")
                {
                    this.AttachmentTypeID_eStore = Convert.ToInt64(this.hdn_ddlEstitemID.Value);
                }
                else
                {
                    DataTable dataTable1 = EstimateBasePage.EstimateItemID_Select_eStore(this.CompanyID, this.UserID, this.EstimateID);
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        this.AttachmentTypeID_eStore = Convert.ToInt64(row1["Estimateitemid"].ToString());
                    }
                }
                estimateItem.AttachmentType = "X";
                this.AttachmentType = "X";
                estimateItem.AttachmentTypeID = this.AttachmentTypeID_eStore;
                this.AttachmentTypeID = this.AttachmentTypeID_eStore;
                estimateItem.EstimateID = this.EstimateID;
            }
            string attachmentType = this.AttachmentType;
            char[] chrArray = new char[] { '‡' };
            this.AttachmentType = attachmentType.Split(chrArray)[0];
            string[] strArrays = FileUploadName.FileName.ToString().Trim().Split(new char[] { '.' });
            newFileName = string.Concat(this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo);
            newFileName = this.objBase.ReplaceSingleQuote(newFileName);
            DataTable dataTable2 = EstimateBasePage.Attachment_Duplicate_CheckChange_ForItemSpecific(this.EstimateID, this.AttachmentTypeID, this.AttachmentType, this.objBase.ReplaceSingleQuote(newFileName), this.pg);
            if (dataTable2.Rows.Count <= 0)
            {
                string[] estNo = new string[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", null, null, null, null, null };
                Guid guid = Guid.NewGuid();
                estNo[2] = guid.ToString().Substring(0, 5);
                estNo[3] = "_";
                estNo[4] = this.EstNo;
                estNo[5] = ".";
                estNo[6] = strArrays[(int)strArrays.Length - 1];
                newFileName = string.Concat(estNo);
            }
            else
            {
                newFileName = string.Concat(this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_");
                newFileName = this.objBase.ReplaceSingleQuote(newFileName);
                foreach (DataRow dataRow1 in dataTable2.Rows)
                {
                    attachments usercontrolItemAttachment = this;
                    usercontrolItemAttachment.FileCheck = string.Concat(usercontrolItemAttachment.FileCheck, dataRow1["Filename"].ToString(), "‡");
                }
                int num = 1;
                string[] strArrays1 = this.FileCheck.Split(new char[] { '‡' });
                for (int i = 0; i < (int)strArrays1.Length - 1; i++)
                {
                    string[] strArrays2 = strArrays1[i].Split(new char[] { '.' });
                    string str = strArrays2[0];
                    string str1 = strArrays2[0].Substring(strArrays2[0].LastIndexOf('\u005F') + 1);
                    if (!(str.Remove(str.Length - 1) == newFileName) || Convert.ToInt32(str1) != num)
                    {
                        object[] objArray = new object[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_", 1, ".", strArrays[(int)strArrays.Length - 1] };
                        this.NewFileName = string.Concat(objArray);
                    }
                    else
                    {
                        num++;
                        object[] objArray1 = new object[] { this.objcommon.ReplaceSplSymbol(strArrays[0]), "_", this.EstNo, "_", num, ".", strArrays[(int)strArrays.Length - 1] };
                        this.NewFileName = string.Concat(objArray1);
                    }
                }
                newFileName = this.NewFileName;
            }
            if (FileUploadName.HasFile || FileUploadName.FileName != "")
            {
                string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", this.objBase.ReplaceSingleQuote(newFileName) };
                FileUploadName.SaveAs(string.Concat(secureDocPath));
                string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/" };
                empty = string.Concat(secureDocPath1);
            }
            else
            {
                newFileName = string.Empty;
                empty = string.Empty;
            }
            estimateItem.UploadedBy = this.UserID;
            estimateItem.FileName = this.objBase.ReplaceSingleQuote(newFileName);
            estimateItem.ModuleType = this.ModuleType;
            estimateItem.IsDisplayToEstore = val;
            estimateItem.IsDisplayToPdf = val1;
            FileName = newFileName;
            OriginalAttachFileName = fileName;
            if (estimateItem.FileName.Trim() != "")
            {
                string[] strArrays3 = estimateItem.FileName.ToString().Split(new char[] { '.' });
                if (this.chkPreflightItem != null && this.chkPreflightItem.Checked && strArrays3[(int)strArrays3.Length - 1].ToString().ToLower() == "pdf")
                {
                    PreflightParameters preflightParameter = this.objPreflight.Preflight_file(estimateItem.FileName, this.ddlPreflightItem.SelectedItem.Text, attachments.AccountID.ToString(), this.CompanyID.ToString(), empty);
                    if (preflightParameter.IsPreflighted)
                    {
                        estimateItem.FileName = preflightParameter.CorrectedFile;
                        estimateItem.ReportFile = preflightParameter.ReportFile;
                    }
                }
            }
            EstimateBasePage.etimates_attachment_insert(estimateItem);
            this.chkPreflightItem.Checked = false;
        }

        public void ddl_Specific_Bind()
        {
            Label label = (Label)this.RadGrid_Specific.FindControl("lbl_ItemSpecific_Add");
            DropDownList dropDownList = (DropDownList)this.RadGrid_Specific.FindControl("ddl_Specific_Add");
            var actionPage = Request.QueryString["ActionPage"];
            DataTable dataTable = new DataTable();
            if (!string.IsNullOrEmpty(actionPage))
            {
                dataTable = EstimatesBasePage.Estimate_ProofItems_RFQdescription_Select(this.CompanyID, this.EstimateID, this.ModuleType);
            }
            else
            {
                 dataTable = EstimatesBasePage.Estimate_Items_RFQdescription_Select(this.CompanyID, this.EstimateID, this.ModuleType);
            }
            dataTable.Columns[3].ReadOnly = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["EstimateTitle"] = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
            }
            int num = 0;
            this.ddl_Specific.DataSource = dataTable;
            this.ddl_Specific.DataTextField = "EstimateTitle";
            this.ddl_Specific.DataValueField = "EstimateItemID";
            this.ddl_Specific.DataBind();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.EstimateType = string.Concat(this.EstimateType, dataRow["EstimateType"].ToString(), "‡");
                this.EstimateItemID = dataRow["EstimateItemID"].ToString();
                this.ItemTitle = dataRow["EstimateTitle"].ToString();
                if (dataTable.Rows.Count <= 1)
                {
                    this.ddl_Specific.Visible = false;
                    this.lbl_ItemSpecific.Visible = true;
                    this.lbl_ItemSpecific.Text = this.objBase.SpecialDecode(this.ItemTitle);
                    this.hdn_ddlEstitemID.Value = this.EstimateItemID.ToString();
                    this.hdn_ddlEstType.Value = this.EstimateType;
                }
                else
                {
                    this.ddl_Specific.Visible = true;
                    this.lbl_ItemSpecific.Visible = false;
                    if (num == 0)
                    {
                        this.hdn_ddlEstType.Value = this.EstimateType;
                        this.hdn_ddlEstitemID.Value = this.EstimateItemID.ToString();
                    }
                }
                num++;
            }
        }

        protected void DeleteSelected_ItemSpcfc_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                if (htmlInputCheckBox.Checked)
                {
                    EstimateBasePage.Attachments_General_Delete(Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
                }
            }
            if (this.pg.ToLower() == "deliverynote")
            {
                DataTable dataTable = EstimateBasePage.Attachment_DN_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.DeliveryID, this.EstimateID);
                this.RadGrid_Specific.DataSource = dataTable;
                if (dataTable.Rows.Count > 0)
                {
                    this.RadGrid_Specific.Visible = true;
                    this.RadGrid_Specific.DataBind();
                    this.RadGrid_Specific.AllowCustomPaging = true;
                    this.RadGrid_Specific.VirtualItemCount = dataTable.Rows.Count;
                }
            }
            else if (this.pg.ToLower() != "purchase")
            {
                DataTable dataTable1 = EstimateBasePage.Attachments_ItemSpecific_Select(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                this.RadGrid_Specific.DataSource = dataTable1;
                if (dataTable1.Rows.Count > 0)
                {
                    this.AddBoundColumns(dataTable1, this.RadGrid_Specific);
                    this.RadGrid_Specific.DataBind();
                    this.RadGrid_Specific.AllowCustomPaging = true;
                    this.RadGrid_Specific.VirtualItemCount = dataTable1.Rows.Count;
                }
                if (this.pg.ToLower() == "webstoreorder")
                {
                    this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
                    this.pnl_CloseWebstore.Visible = true;
                }
            }
            else
            {
                DataTable dataTable2 = EstimateBasePage.Attachment_PO_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.PurchaseID);
                this.RadGrid_Specific.DataSource = dataTable2;
                if (dataTable2.Rows.Count > 0)
                {
                    this.RadGrid_Specific.Visible = true;
                    this.RadGrid_Specific.DataBind();
                    this.RadGrid_Specific.AllowCustomPaging = true;
                    this.RadGrid_Specific.VirtualItemCount = dataTable2.Rows.Count;
                }
            }
            this.RadGrid_Specific.MasterTableView.Rebind();
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Deleted_Successfully"), "msg-success", this.plhMessage);
        }
        
        protected void update_proof_OnClick(object sender, EventArgs e)
        {
            int _proofID = proofID;
            int _estimateItemID = int.Parse(this.EstimateItemID);
            bool selectedItem = false;
            int selectedItemCount = 0;
            if (_proofID !=0 && _estimateItemID!=0)
            {
                for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                    if (htmlInputCheckBox.Checked)
                    {
                        selectedItem = true;
                        selectedItemCount = selectedItemCount + 1;
                    }
                }
                for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                    var AttachmentID = int.Parse(Request.QueryString["AttachmentID"]);
                    var ProofItemID = int.Parse(Request.QueryString["ProofItemID"]);
                    if (selectedItemCount < 2)
                    {
                        this.DivSelect1.Visible = false;
                        if (selectedItem)
                        {
                            this.ErrorDiv.Visible = false;
                            if (htmlInputCheckBox.Checked)
                            {
                                EstimateBasePage.UpdateProofHistory(AttachmentID, _estimateItemID, _proofID, this.UserID, true, BaseClass.CheckIntegerNull(htmlInputCheckBox.Value),ProofItemID);
                            }
                        }
                        else
                        {
                            this.ErrorDiv.Visible = true;
                        }
                    }
                    else
                    {
                        this.DivSelect1.Visible = true;
                    }
                   
                }
            }
            string _domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + _proofID + "";

            if (selectedItemCount < 2)
            {
                if (selectedItem)
                {
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", redirectUrl, "';</script>"));
                }
            }
          
            //for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
            //{
            //    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
            //    htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
            //    if (htmlInputCheckBox.Checked)
            //    {
            //        selectedAttachment = true;
            //        Int32 proof_id = 0;
            //        if (proofId == proof_id)
            //        {
            //            if (this.pg.ToLower().ToString() == "estimate")
            //            {
            //                proofId = EstimateBasePage.Create_proof(this.CompanyID, this.EstimateID, 0, DateTime.Now, int.Parse(statusID));
            //            }
            //            else
            //            {
            //                string est_id = EstimateBasePage.GetEstimateIDByJobID(this.CompanyID, this.EstimateID);
            //                proofId = EstimateBasePage.Create_proof(this.CompanyID, (long)Convert.ToDouble(est_id), 0, DateTime.Now, int.Parse(statusID));
            //            }
            //        }
            //        //EstimateBasePage.Attachments_General_Delete(Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
            //        EstimateBasePage.Create_proof_detail(0, BaseClass.CheckIntegerNull(htmlInputCheckBox.Value), proofId, UserID, DateTime.Now);
            //        this.objBase.Message_Display("Proof Created", "msg-success", this.plhMessage);
            //    }
            //}

        }
        protected void DeleteSelected_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_General.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_General.Items[i].Cells[0].FindControl("Id1");
                if (htmlInputCheckBox.Checked)
                {
                    EstimateBasePage.Attachments_General_Delete(Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
                }
            }
            DataTable dataTable = EstimateBasePage.Attachments_Select_For_General(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            this.RadGrid_General.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGrid_General.DataBind();
                this.RadGrid_General.AllowCustomPaging = true;
                this.RadGrid_General.VirtualItemCount = dataTable.Rows.Count;
            }
            this.RadGrid_General.Rebind();
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.ddl_Specific_Bind();
        }

        public void deliveryandpurchase()
        {
            this.RadGrid_Specific.Visible = true;
            this.RadGrid_Specific.MasterTableView.Columns[2].Visible = false;
            this.RadGrid_Specific.MasterTableView.Columns[3].Visible = false;
            this.Div_Labels.Visible = false;
            this.RadGrid_General.Enabled = false;
            this.RadGrid_General.Visible = false;
            if (this.pg.ToLower() == "purchase")
            {
                this.RadGrid_PO_Bind(this.CompanyID, this.UserID, "Y", this.AttachmentTypeID, this.EstimateID, this.PurchaseID);
                return;
            }
            if (this.pg.ToLower() == "deliverynote")
            {
                this.RadGrid_DN_Bind(this.CompanyID, this.UserID, "Z", this.AttachmentTypeID, this.DeliveryID, this.EstimateID);
            }
        }

        public void EmailAttach_ItemSpecific_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                if (((HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1")).Checked)
                {
                    LinkButton linkButton = (LinkButton)this.RadGrid_Specific.Items[i].Cells[1].FindControl("lbl_FileName");
                    HiddenField hiddenField = (HiddenField)this.RadGrid_Specific.Items[i].Cells[1].FindControl("hdn_ActualFileName");
                    this.FileName = linkButton.Text;
                    attachments usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName.Replace("'", @"\'"), "‡");
                    attachments usercontrolItemAttachment1 = this;
                    usercontrolItemAttachment1.ActualSupRFQ = string.Concat(usercontrolItemAttachment1.ActualSupRFQ, hiddenField.Value, "‡");
                }
            }
            if (base.Request.QueryString["Section"].ToLower() != "printbroker")
            {
                this.pnl_AttachCustomer.Visible = true;
            }
            else
            {
                this.pnl_AttacClose.Visible = true;
            }
            this.pnl_WindowClose.Visible = true;
        }

        public void EmailAttach_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_General.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                if (((HtmlInputCheckBox)this.RadGrid_General.Items[i].Cells[0].FindControl("Id1")).Checked)
                {
                    LinkButton linkButton = (LinkButton)this.RadGrid_General.Items[i].Cells[1].FindControl("lbl_FileName");
                    HiddenField hiddenField = (HiddenField)this.RadGrid_General.Items[i].Cells[1].FindControl("hdn_ActualFileName");
                    this.FileName = linkButton.Text;
                    attachments usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName, "‡");
                    attachments usercontrolItemAttachment1 = this;
                    usercontrolItemAttachment1.ActualSupRFQ = string.Concat(usercontrolItemAttachment1.ActualSupRFQ, hiddenField.Value, "‡");
                }
            }
            if (base.Request.QueryString["Section"].ToLower() != "printbroker")
            {
                this.pnl_AttachCustomer.Visible = true;
            }
            else
            {
                this.pnl_AttacClose.Visible = true;
            }
            this.pnl_WindowClose.Visible = true;
        }

        public void GeneralEmailAttachLink_Onclick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_General.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                if (((HtmlInputCheckBox)this.RadGrid_General.Items[i].Cells[0].FindControl("Id1")).Checked)
                {
                    LinkButton linkButton = (LinkButton)this.RadGrid_General.Items[i].Cells[1].FindControl("lbl_FileName");
                    HiddenField hiddenField = (HiddenField)this.RadGrid_General.Items[i].Cells[1].FindControl("hdn_ActualFileName");
                    this.FileName = linkButton.Text;
                    attachments usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName, "‡");
                    attachments usercontrolItemAttachment1 = this;
                    usercontrolItemAttachment1.ActualSupRFQ = string.Concat(usercontrolItemAttachment1.ActualSupRFQ, hiddenField.Value, "‡");
                }
            }
            if (base.Request.QueryString["Section"].ToLower() != "printbroker")
            {
                this.pnl_AttachLinkCustomer.Visible = true;
            }
            else
            {
                this.Pnl_AttachLinkForSupplier.Visible = true;
            }
            this.pnl_WindowClose.Visible = true;
        }

        protected void imgbtnDelete_OnClick_General(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_General_Delete");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, Convert.ToInt64(e.CommandArgument));
            database.ExecuteNonQuery(storedProcCommand);
            DataTable dataTable = EstimateBasePage.Attachments_Select_For_General(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            this.RadGrid_General.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGrid_General.DataBind();
            }
            this.RadGrid_General.Rebind();
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDelete_OnClick_Specific(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_General_Delete");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, Convert.ToInt64(e.CommandArgument));
            database.ExecuteNonQuery(storedProcCommand);
            if (this.pg.ToLower() == "deliverynote" || this.pg.ToLower() == "purchase")
            {
                this.deliveryandpurchase();
            }
            else
            {
                DataTable dataTable = EstimateBasePage.Attachments_ItemSpecific_Select(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                this.RadGrid_Specific.DataSource = dataTable;
                if (dataTable.Rows.Count > 0)
                {
                    this.AddBoundColumns(dataTable, this.RadGrid_Specific);
                    this.RadGrid_Specific.DataBind();
                }
            }
            if (this.pg.ToLower() == "webstoreorder")
            {
                this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
                this.pnl_CloseWebstore.Visible = true;
            }
            this.RadGrid_Specific.Rebind();
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Files_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.ddl_Specific_Bind();
        }

        public void ISEmail_AttachLink_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                if (((HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1")).Checked)
                {
                    LinkButton linkButton = (LinkButton)this.RadGrid_Specific.Items[i].Cells[1].FindControl("lbl_FileName");
                    HiddenField hiddenField = (HiddenField)this.RadGrid_Specific.Items[i].Cells[1].FindControl("hdn_ActualFileName");
                    this.FileName = linkButton.Text;
                    attachments usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName, "‡");
                    attachments usercontrolItemAttachment1 = this;
                    usercontrolItemAttachment1.ActualSupRFQ = string.Concat(usercontrolItemAttachment1.ActualSupRFQ, hiddenField.Value, "‡");
                }
            }
            if (base.Request.QueryString["Section"].ToLower() != "printbroker")
            {
                this.pnl_AttachLinkCustomer.Visible = true;
            }
            else
            {
                this.Pnl_AttachLinkForSupplier.Visible = true;
            }
            this.pnl_WindowClose.Visible = true;
        }

        protected void DownloadAll_OnClick(object sender, EventArgs e)
        {
            List<string> DocPath = new List<string>();
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                    if (htmlInputCheckBox.Checked)
                    {
                        string[] SecureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/attachments/" };
                        this.StrDownload = string.Concat(SecureDocPath);

                        DataTable attachment = EstimateBasePage.GetAttachmentByAttachmentID(BaseClass.CheckIntegerNull(htmlInputCheckBox.Value), this.pg.ToLower(),this.EstimateID);
                        string fileName = string.Empty;
                        string orderNumber = string.Empty;
                        foreach (DataRow dr in attachment.Rows)
                        {
                            fileName = dr["FileName"].ToString();
                            orderNumber= dr["OrderNumber"].ToString();
                            string filePath = string.Concat(StrDownload, fileName);
                            string newfilePath = string.Concat(StrDownload, orderNumber + "_" + fileName);
                            DocPath.Add(newfilePath);
                            if (!File.Exists(newfilePath))
                            {
                                File.Copy(filePath, newfilePath);
                            }
                            zip.AddFile(newfilePath, "Files");

                        }
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                foreach(var file in DocPath)
                {
                    File.Delete(file);
                }
                Response.End();
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            var actionPage = Request.QueryString["action"];
            var _page = Request.QueryString["ActionPage"];
            if (actionPage == "CreateProof" || _page == "proof")
            {
                this.objBase.ReturnRoles_Privileges_Tabs("proofs", "isadd", "");
                this.chk_displayFileToEstore.Visible = false;
                this.lbl_displayFileToEstore.Visible = false;
                this.chk_displayFileToPdf.Visible = false;
                this.lbl_displayFileToPdf.Visible = false;
            }
            else
            {
                this.chk_displayFileToEstore.Visible = true;
                this.lbl_displayFileToEstore.Visible = true;
                this.chk_displayFileToPdf.Visible = true;
                this.lbl_displayFileToPdf.Visible = true;
            }
            if (base.Request.QueryString["pg"] != null)
            {
                this.pg = base.Request.QueryString["pg"].ToString().ToLower();
            }
            if (!IsPostBack)
            {
                _url = Request.UrlReferrer.OriginalString.ToString();
                Uri proofUrl = new Uri(_url);
                if (_url.Contains("ProofID"))
                {
                    //this.chk_IsAttachProof.Visible = true;
                    //this.lbl_IsAttachProof.Visible = true;
                    this.chk_IsAttachProof.Visible = false;
                    this.lbl_IsAttachProof.Visible = false;
                    proofID = int.Parse(HttpUtility.ParseQueryString(proofUrl.Query).Get("ProofID"));
                }
                else
                {
                    this.chk_IsAttachProof.Visible = false;
                    this.lbl_IsAttachProof.Visible = false;
                }
            }
            if (commonClass.CheckProofPermission())
            {

                if (_url.Contains("estimates/estimate_summary_reeng.aspx") || _url.Contains("jobs/job_summary_reeng.aspx") || actionPage == "CreateProof" )
                {
                    if(!string.IsNullOrEmpty(actionPage))
                    {
                        this.btncreate_proof.Visible = true;
                    }
                    else
                    {
                        this.btncreate_proof.Visible = false;
                    }
                    this.btnclose.Visible = true;
                    this.btncancel_Genrl.Visible = false;
                }
                else
                {
                    this.btncreate_proof.Visible = false;
                    this.btnclose.Visible = false;
                    this.btncancel_Genrl.Visible = true;
                }
            }

            if (commonClass.CheckProofPermission())
            {
                if (_url.ToLower().Contains("proofs/proof_summary.aspx"))
                {
                    this.btnupdate.Visible = true;
                }
                else
                {
                    this.btnupdate.Visible = false;
                }
            }
            if(this.pg.ToLower() == "job" || this.pg.ToLower() == "webstoreorder" || this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice")
            {
                this.btn_downloadAll.Visible = true;
            }
            else
            {
                this.btn_downloadAll.Visible = false;
            }
            this.ModuleType = this.pg;
            this.Page.Header.DataBind();
            if (!base.IsPostBack)
            {
                this.RadGrid_General.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("File_Name");
                this.RadGrid_General.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Uploaded_By");
                this.RadGrid_General.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Uploaded_On");
                this.RadGrid_General.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                this.btn_Delete.Text = this.objLanguage.GetLanguageConversion("Delete");
                this.btn_AttachGeneral.Text = this.objLanguage.GetLanguageConversion("Attach_As_Attachment");
                this.btn_AttachLinkGeneral.Text = this.objLanguage.GetLanguageConversion("Attach_As_Link");
                this.btn_delSpecific.Text = this.objLanguage.GetLanguageConversion("Delete");
                this.RadGrid_Specific.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("File_Name");
                if (this.pg.ToLower() == "estimate" && _page == "proof")
               {
                   this.RadGrid_Specific.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Order_Estimate_Job_Number");
               }

                else if (this.pg.ToLower() == "estimate")
                {
                    this.RadGrid_Specific.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number");
                }
                else if (this.pg.ToLower() == "job")
                {
                    this.RadGrid_Specific.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Job_Number");
                }
                else if (this.pg.ToLower() == "invoice")
                {
                    this.RadGrid_Specific.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Number");
                }
                else if (this.pg.ToLower() == "webstoreorder")
                {
                    this.RadGrid_Specific.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Order_Number");
                }
                this.RadGrid_Specific.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                this.RadGrid_Specific.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Uploaded_By");
                this.RadGrid_Specific.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Uploaded_On");
                this.RadGrid_Specific.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                this.RadGrid_Specific.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_display");
                this.RadGrid_General.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
                this.RadStrp_Attch.Tabs[0].Text = this.objLanguage.GetLanguageConversion("General");
                this.RadStrp_Attch.Tabs[1].Text = this.objLanguage.GetLanguageConversion("Item_Specific");
                this.btn_CancelGen.Text = this.objLanguage.GetLanguageConversion("Cancel");
                this.btncancel_Itm.Text = this.objLanguage.GetLanguageConversion("Cancel");
            }
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            string strRemove = string.Empty; 
            if (this.pg.ToLower() == "job")
            {
                empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
            }
            else if (this.pg.ToLower() != "invoice")
            {
                empty = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()));
                strRemove = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString()));

            }
            else
            {
                empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                strRemove = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
            }
            if (empty.Trim().ToLower() != "false")
            {
                this.btn_Delete.Visible = true;
                this.btn_delSpecific.Visible = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(strRemove) && strRemove.Trim() == "1")
                {
                    this.btn_Delete.Visible = true;
                    this.btn_delSpecific.Visible = true;
                }
                else
                {
                    this.btn_Delete.Visible = false;
                    this.btn_delSpecific.Visible = false;
                }
               
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/attachments/" };
            this.StrDownload = string.Concat(secureSitePath);
            if (!base.IsPostBack)
            {
                if (commonClass.CheckProofPermission())
                {
                    if (_url.Contains("estimates/estimate_summary_reeng.aspx") || _url.Contains("jobs/job_summary_reeng.aspx") || _url.Contains("orders/order_summary.aspx"))
                    {
                        //this.statuslbl.Visible = true;
                        //this.proof_status.Visible = true;
                        DropDownList prof_status_list = (DropDownList)this.proof_status;
                        DataTable profStatusTable = EstimateBasePage.GetProofStatusAll(this.CompanyID);
                        foreach (DataRow dr in profStatusTable.Rows)
                        {
                            prof_status_list.Items.Add(new ListItem(dr["StatusTitle"].ToString(), dr["StatusID"].ToString()));
                            if (dr["ProofDefault"] != null)
                            {
                                if (dr["ProofDefault"].ToString() == "True")
                                {
                                    prof_status_list.Items.FindByValue(dr["StatusID"].ToString()).Selected = true;
                                }
                            }
                        }
                    }
                   
                }

            }
            if (base.Request.QueryString["estid"] != null && this.pg.ToLower() == "job")
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            }
            else if (base.Request.QueryString["estid"] == null || !(this.pg.ToLower() == "invoice"))
            {
                if(base.Request.QueryString["estid"].ToString().Contains(","))
                {
                    List<string> _estimateIDs = new List<string>(base.Request.QueryString["estid"].ToString().Split(new string[] { "," }, StringSplitOptions.None));
                    this.EstimateID = Convert.ToInt64(_estimateIDs[0]);
                }
                else
                {
                    this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
                }
            }
            else
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            }
            if (base.Request.QueryString["AttachImageID"] != null)
            {
                this.AttachImageID = base.Request.QueryString["AttachImageID"].ToString();
            }
            DataTable dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.EstimateID, base.Request.QueryString["pg"].ToString());
            foreach (DataRow row in dataTable.Rows)
            {
                this.EstNo = row["Number"].ToString();
            }
            DataTable dataTable1 = EstimateBasePage.EstimateItemID_Select_eStore(this.CompanyID, this.UserID, this.EstimateID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                this.AttachmentTypeID = Convert.ToInt64(dataRow["EstimateItemID"]);
            }
            if (this.pg.ToLower() == "purchase" && base.Request.Params["PurchaseID"] != null)
            {
                this.PurchaseID = (long)Convert.ToInt32(base.Request.Params["PurchaseID"]);
            }
            if (base.Request.QueryString["pagetype"].ToLower() == "emailtemplate")
            {
                this.btn_AttachGeneral.Visible = true;
                this.btn_AttachIS.Visible = true;
                this.btn_AttachLinkGeneral.Visible = true;
                this.Btn_ISAttachLink.Visible = true;
            }
            else
            {
                this.btn_AttachGeneral.Visible = false;
                this.btn_AttachIS.Visible = false;
                this.btn_AttachLinkGeneral.Visible = false;
                this.Btn_ISAttachLink.Visible = false;
            }
            if (this.pg.ToLower() == "deliverynote" && base.Request.Params["DeliveryID"] != null)
            {
                this.DeliveryID = (long)Convert.ToInt32(base.Request.Params["DeliveryID"]);
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable2 = SettingsBasePage.PreFlight_Options_Select("MIS", this.CompanyID);
                string str = "0";
                if (dataTable2.Rows.Count != 0)
                {
                    DataTable dataTable3 = CompanyBasePage.PreflightProfile_Select();
                    this.ddlPreflightItem.DataSource = dataTable3;
                    this.ddlPreflightItem.DataTextField = "ProfileName";
                    this.ddlPreflightItem.DataValueField = "Id";
                    this.ddlPreflightItem.DataBind();
                    this.ddlPreflightItem.Items.Insert(0, new ListItem("---Select Profile---", "0"));
                    this.ddlPreflightGeneral.DataSource = dataTable3;
                    this.ddlPreflightGeneral.DataTextField = "ProfileName";
                    this.ddlPreflightGeneral.DataValueField = "Id";
                    this.ddlPreflightGeneral.DataBind();
                    this.ddlPreflightGeneral.Items.Insert(0, new ListItem("---Select Profile---", "0"));
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        str = row1["ProfileId"].ToString();
                        if (Convert.ToInt32(row1["IsEnabled"]) != 1)
                        {
                            this.chkPreflightItem.Visible = false;
                            this.chkPreflightGeneral.Visible = false;
                            this.ddlPreflightItem.Visible = false;
                            this.ddlPreflightGeneral.Visible = false;
                            this.hdn_IsPreFlightEnabled.Value = "0";
                        }
                        else
                        {
                            AttributeCollection attributes = this.chkPreflightItem.Attributes;
                            string[] clientID = new string[] { "javascript:EnablePreFlightDdl(", this.chkPreflightItem.ClientID, ",", this.ddlPreflightItem.ClientID, ");" };
                            attributes.Add("onclick", string.Concat(clientID));
                            AttributeCollection attributeCollection = this.chkPreflightGeneral.Attributes;
                            string[] strArrays = new string[] { "javascript:EnablePreFlightDdl(", this.chkPreflightGeneral.ClientID, ",", this.ddlPreflightGeneral.ClientID, ");" };
                            attributeCollection.Add("onclick", string.Concat(strArrays));
                            this.hdn_IsPreFlightEnabled.Value = "1";
                        }
                    }
                    this.ddlPreflightItem.SelectedIndex = this.ddlPreflightItem.Items.IndexOf(this.ddlPreflightItem.Items.FindByValue(str));
                    this.ddlPreflightGeneral.SelectedIndex = this.ddlPreflightGeneral.Items.IndexOf(this.ddlPreflightGeneral.Items.FindByValue(str));
                    this.chkPreflightItem.Checked = false;
                    this.ddlPreflightItem.Enabled = false;
                    this.chkPreflightGeneral.Checked = false;
                    this.ddlPreflightGeneral.Enabled = false;
                }
                else
                {
                    this.chkPreflightItem.Visible = false;
                    this.chkPreflightGeneral.Visible = false;
                    this.ddlPreflightItem.Visible = false;
                    this.ddlPreflightGeneral.Visible = false;
                    this.hdn_IsPreFlightEnabled.Value = "0";
                }
            }
            if (!base.IsPostBack)
            {
                if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
                {
                    if (this.RadStrp_Attch.SelectedIndex == 0)
                    {
                        this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                    }
                    else if (this.RadStrp_Attch.SelectedIndex == 1)
                    {
                        this.RadGrid_Specific_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                    }
                }
                else if (this.pg.ToLower() != "webstoreorder")
                {
                    if (this.pg.ToLower() == "deliverynote" || this.pg.ToLower() == "purchase")
                    {
                        this.RadStrp_Attch.SelectedIndex = 1;
                        this.RadMultiPage_Attach.SelectedIndex = 1;
                        this.RadStrp_Attch.SelectedTab.Text = "File Upload";
                        this.RadStrp_Attch.SelectedTab.Width = 100;
                        this.RadStrp_Attch.SelectedTab.ToolTip = "";
                        this.RadStrp_Attch.SelectedTab.Attributes.Add("style", "cursor:normal;");
                        if (this.RadStrp_Attch.Tabs.Count > 0)
                        {
                            this.RadStrp_Attch.Tabs.RemoveAt(0);
                            this.RadStrp_Attch.Enabled = false;
                        }
                    }
                }
                else if (this.RadStrp_Attch.SelectedIndex == 0)
                {
                    this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                }
                else if (this.RadStrp_Attch.SelectedIndex == 1)
                {
                    this.Div_Labels.Visible = true;
                    this.Div_Labels.Visible = true;
                    this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
                    this.ddl_Specific_Bind();
                }
            }

            if(actionPage == "CreateProof")
            {
                if (this.RadStrp_Attch.SelectedIndex == 0)
                {
                    this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                }
                else if (this.RadStrp_Attch.SelectedIndex == 1)
                {
                    this.RadGrid_Specific_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                }
            }
            if (this.pg.ToLower() == "deliverynote" || this.pg.ToLower() == "purchase")
            {
                this.RadGrid_Specific.Columns[2].Visible = false;
                this.deliveryandpurchase();
            }
            if (base.Request.QueryString["ordID"] != null)
            {
                this.OrderID = (long)Convert.ToInt32(base.Request.QueryString["ordID"].ToString());
            }
            if (base.Request.QueryString["FrmAttach"] != null)
            {
                this.FrmAttach = base.Request.QueryString["FrmAttach"].ToString();
            }
            if (this.OrderID == (long)0)
            {
                this.OrderID = this.EstimateID;
            }
            OrderBasePage.Order_select(this.CompanyID, this.OrderID);
            if (this.pg.ToLower() == "deliverynote")
            {
                this.OrderID = this.DeliveryID;
            }
            if (this.pg.ToLower() == "purchase")
            {
                this.OrderID = this.PurchaseID;
            }
            if (_url.ToLower().Contains("proofs/proof_summary.aspx"))
            {
                Uri myUri = new Uri(_url);
                this.OrderID = int.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("estid"));
                //this.OrderID= int.Parse(base.Request.QueryString["estid"].ToString());
            }
            attachments.AccountID = OrderBasePage.Select_AccountID(this.CompanyID, this.OrderID, this.ModuleType);
            if (!base.IsPostBack)
            {
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//attachments" };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", attachments.AccountID, "//pdf" };
                if (!Directory.Exists(string.Concat(secureDocPath1)))
                {
                    object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", attachments.AccountID, "//pdf" };
                    Directory.CreateDirectory(string.Concat(objArray1));
                }
            }
            object[] secureSitePath1 = new object[] { this.SecureSitePath, this.ServerName, "/store/", attachments.AccountID, "/pdf/" };
            this.StreStorAttach = string.Concat(secureSitePath1);
            this.ddl_Specific_Bind();
        }

        public void RadGrid_DN_Bind(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long DeliveryID, long EstimateID)
        {
            DataTable dataTable = EstimateBasePage.Attachment_DN_Select(CompanyID, UserID, AttachmentType, AttachmentTypeID, DeliveryID, EstimateID);
            this.RadGrid_Specific.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGrid_Specific.Visible = true;
                this.RadGrid_Specific.DataBind();
            }
        }

        public void RadGrid_eStoreOrder_General_Bind(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, string pg)
        {
            DataTable dataTable = EstimateBasePage.Attachments_eStore_General(CompanyID, UserID, AttachmentType, AttachmentTypeID, EstimateID, pg);
            this.RadGrid_Specific.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.AddBoundColumns(dataTable, this.RadGrid_Specific);
                this.RadGrid_Specific.DataBind();
            }
        }

        public void RadGrid_General_Bind(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {
            DataTable dataTable = EstimateBasePage.Attachments_Select_For_General(CompanyID, UserID, AttachmentType, EstimateID, ModuleType);
            this.RadGrid_General.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGrid_General.DataBind();
            }
        }

        protected void RadGrid_General_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = EstimateBasePage.Attachments_Select_For_General(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
            this.RadGrid_General.DataSource = dataTable;
        }

        public void RadGrid_PO_Bind(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, long PurchaseID)
        {
            DataTable dataTable = EstimateBasePage.Attachment_PO_Select(CompanyID, UserID, AttachmentType, AttachmentTypeID, EstimateID, PurchaseID);
            this.RadGrid_Specific.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGrid_Specific.Visible = true;
                this.RadGrid_Specific.DataBind();
            }
        }

        public void RadGrid_Specific_Bind(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {

            var actionPage = Request.QueryString["ActionPage"];
            DataTable dataTable = new DataTable();
            if (!string.IsNullOrEmpty(actionPage))
            {
                int jobID = 0;
                if(Request.QueryString["jID"] != null)
                {
                    jobID = int.Parse(Request.QueryString["jID"].ToString());
                }
                var ProofID= int.Parse(Request.QueryString["ProofID"]);
                dataTable = EstimateBasePage.Attachments_ProofItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID, "proof",ProofID, jobID);
            }
            else
            {
                 dataTable = EstimateBasePage.Attachments_ItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID, ModuleType);
            }
            this.RadGrid_Specific.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.AddBoundColumns(dataTable, this.RadGrid_Specific);
                this.RadGrid_Specific.DataBind();
            }
        }

        protected void RadGrid_Specific_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (this.pg.ToLower() == "deliverynote")
            {
                DataTable dataTable = EstimateBasePage.Attachment_DN_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.DeliveryID, this.EstimateID);
                this.RadGrid_Specific.DataSource = dataTable;
                return;
            }
            if (this.pg.ToLower() != "purchase")
            {
                DataTable dataTable1 = EstimateBasePage.Attachments_ItemSpecific_Select(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                this.RadGrid_Specific.DataSource = dataTable1;
                return;
            }
            DataTable dataTable2 = EstimateBasePage.Attachment_PO_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.PurchaseID);
            this.RadGrid_Specific.DataSource = dataTable2;
        }

        protected void RadGridGenereal_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                item.FindControl("Upld_DateGen");
                Label label = item.FindControl("lbl_UpldOn") as Label;
                var actionPage = Request.QueryString["ActionPage"];
                if (!string.IsNullOrEmpty(actionPage))
                {
                    string dt= this.commclass.Eprint_return_DateTime_Before_View(label.Text, this.CompanyID, this.UserID, true);
                    if(!string.IsNullOrEmpty(dt))
                    {
                        dt = dt.Substring(0, dt.Length - 6);
                    }
                    label.Text = dt;
                }
                else
                {
                    label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
                }
                ImageButton imageButton = (ImageButton)item.FindControl("imgbtnDelete");
                if (imageButton != null)
                {
                    string empty = string.Empty;
                    string strRemove = string.Empty;
                    if (this.pg.ToLower() == "job")
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                        strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                    }
                    else if (this.pg.ToLower() != "invoice")
                    {
                        empty = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()));
                        strRemove = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString()));
                    }
                    else
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                        strRemove = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                    }
                    if (empty.Trim().ToLower() == "false")
                    {
                        if (!string.IsNullOrEmpty(strRemove) && strRemove.Trim() == "1")
                        {
                            imageButton.Visible = true;
                        }
                        else
                        {
                            imageButton.Visible = false;
                        }
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                if (base.Request.QueryString["Section"] == null)
                {
                    this.AttachmentSection = "normal";
                }
                else if (base.Request.QueryString["Section"].ToLower() == "custmtemp")
                {
                    this.AttachmentSection = "custmtemp";
                }
                if (this.AttachmentSection.ToString().ToLower() != "custmtemp" && (this.pg.ToLower() == "job" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "webstoreorder"))
                {
                    e.Item.Visible = false;
                    GridDataItem gridDataItem = (GridDataItem)e.Item;
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    gridDataItem[this.cellvalue_AttachFile].Attributes.Add("align", "left");
                    gridDataItem[this.cellvalue_AttachFile].Style.Add("cursor", "pointer");
                    string str = string.Empty;
                    try
                    {
                        string empty1 = string.Empty;
                        string str1 = string.Empty;
                        string[] strArrays = dataItem["ImageNameFromCart"].ToString().Split(new char[] { ',' });
                        string[] strArrays1;
                        if(this.pg.ToLower() == "job" || this.pg.ToLower() == "webstoreorder")
                        {
                            DataTable attachment = EstimateBasePage.GetAttachmentByAttachmentID(BaseClass.CheckIntegerNull(dataItem["AttachmentID"].ToString()), this.pg.ToLower(),this.EstimateID);
                            string orderNumber = string.Empty;
                            foreach (DataRow dr in attachment.Rows)
                            {
                                orderNumber = dr["OrderNumber"].ToString();

                            }
                            strArrays1 = new string[] { "<a id='ancFileName' href='javascript://' title='", dataItem["OriginalFileName"].ToString(), "'  onclick=\"DownloadAttachment('", dataItem["FileName"].ToString(), "','", orderNumber , "','", dataItem["IsEdtiablePDF"].ToString(), "');\"/>", dataItem["OriginalFileName"].ToString(), "</a><br/>" };
                        }
                        else
                        {
                            strArrays1 = new string[] { "<a id='ancFileName' href='javascript://' title='", dataItem["OriginalFileName"].ToString(), "'  onclick=\"OpenAttach('", dataItem["FileName"].ToString(), "','", dataItem["IsEdtiablePDF"].ToString(), "');\"/>", dataItem["OriginalFileName"].ToString(), "</a><br/>" };

                        }
                        empty1 = string.Concat(strArrays1);
                        if (dataItem["ReportFileName"].ToString() != "")
                        {
                            string[] str2 = new string[] { empty1, "<a id='ancFileName' href='javascript://' title='", dataItem["ReportFileName"].ToString(), "'  onclick=\"OpenAttach('", dataItem["ReportFileName"].ToString(), "','", dataItem["IsEdtiablePDF"].ToString(), "');\"/>Report File.pdf</a><br/>" };
                            empty1 = string.Concat(str2);
                        }
                        if ((dataItem["PreviewType"].ToString() == "pdfimg" || dataItem["PreviewType"].ToString() == "img") && dataItem["ImageNameFromCart"].ToString() != "")
                        {
                            for (int i = 0; i < (int)strArrays.Length - 1; i++)
                            {
                                string[] strArrays2 = dataItem["OriginalFileName"].ToString().Split(new char[] { '.' });
                                object[] objArray = new object[] { strArrays2[0], "(", i, ").png" };
                                str1 = string.Concat(objArray);
                                string[] str3 = new string[] { empty1, "<br/><a id='ancFileName' title='", str1, "' href='javascript://'  onclick=\"OpenAttach('", strArrays[i], "','", dataItem["IsEdtiablePDF"].ToString(), "');\"/>", str1, "</a>" };
                                empty1 = string.Concat(str3);
                            }
                        }
                        gridDataItem[this.cellvalue_AttachFile].Text = empty1;
                    }
                    catch
                    {
                    }
                }
            }
            GridTableView masterTableView = this.RadGrid_Specific.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("DivAddNewRecords");
            string empty2 = string.Empty;
            if (this.pg.ToLower() == "job")
            {
                empty2 = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
            }
            else if (this.pg.ToLower() != "invoice")
            {
                empty2 = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()));
            }
            else
            {
                empty2 = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
            }
            if (empty2.Trim().ToLower() == "false")
            {
                htmlControl.Visible = false;
                return;
            }
            htmlControl.Visible = true;
        }

        protected void Create_proof_OnClick(object sender, EventArgs e)
        {
            string proof_count = "";
            string est_id = "";
            if (this.pg.ToLower().ToString()=="estimate" || this.pg.ToLower().ToString() == "webstoreorder")
            {
                proof_count = EstimateBasePage.GetProofAttachmentCount(this.EstimateID, this.pg,0);
            }
            else
            {
                est_id = EstimateBasePage.GetEstimateIDByJobID(this.CompanyID, this.EstimateID);
                proof_count = EstimateBasePage.GetProofAttachmentCount((long)Convert.ToDouble(est_id),this.pg,this.EstimateID);
            }
            if(proof_count=="1")
            {
                EstimateBasePage.InsertProofLastCounter(this.CompanyID);
                string statusID = this.proof_status.SelectedValue;
                if(string.IsNullOrEmpty(statusID))
                {
                    statusID = "0";
                }
                Int32 proofId = 0;
                bool selectedAttachment = false;
                for (int i = this.RadGrid_Specific.Items.Count-1; i >= 0; i--)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                    if (htmlInputCheckBox.Checked)
                    {
                        selectedAttachment = true;
                        Int32 proof_id = 0;
                        if (proofId == proof_id)
                        {
                            if (this.pg.ToLower().ToString() == "estimate" || this.pg.ToLower().ToString() == "webstoreorder")
                            {
                                proofId = EstimateBasePage.Create_proof(this.CompanyID, this.EstimateID, 0, DateTime.Now, int.Parse(statusID));
                                this.commclass.SendInternalMailOnModuleStatusChange(this.CompanyID, proofId, int.Parse(statusID), "proof");
                            }
                            else
                            {
                                est_id = EstimateBasePage.GetEstimateIDByJobID(this.CompanyID, this.EstimateID);
                                proofId = EstimateBasePage.Create_proof(this.CompanyID, (long)Convert.ToDouble(est_id), 0, DateTime.Now, int.Parse(statusID));
                                this.commclass.SendInternalMailOnModuleStatusChange(this.CompanyID, proofId, int.Parse(statusID), "proof");
                            }
                        }
                        //EstimateBasePage.Attachments_General_Delete(Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
                        EstimateBasePage.Create_proof_detail(0, BaseClass.CheckIntegerNull(htmlInputCheckBox.Value), proofId, UserID, DateTime.Now, this.CompanyID, int.Parse(statusID));
                        this.objBase.Message_Display("Proof Created", "msg-success", this.plhMessage);
                    }
                }
                if (selectedAttachment)
                {
                    DataTable _dt = EstimateBasePage.GetProofEstimateItemIDs(proofId);
                    foreach (DataRow dr in _dt.Rows)
                    {
                        EstimateBasePage.AddProofItemDetails(proofId, Convert.ToInt64(dr["EstimateItemID"].ToString()), DateTime.Now, int.Parse(statusID));
                    }
                }
                if (this.pg.ToLower() == "deliverynote")
                {
                    DataTable dataTable = EstimateBasePage.Attachment_DN_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.DeliveryID, this.EstimateID);
                    this.RadGrid_Specific.DataSource = dataTable;
                    if (dataTable.Rows.Count > 0)
                    {
                        this.RadGrid_Specific.Visible = true;
                        this.RadGrid_Specific.DataBind();
                        this.RadGrid_Specific.AllowCustomPaging = true;
                        this.RadGrid_Specific.VirtualItemCount = dataTable.Rows.Count;
                    }
                }
                else if (this.pg.ToLower() != "purchase")
                {
                    DataTable dataTable1 = EstimateBasePage.Attachments_ItemSpecific_Select(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                    this.RadGrid_Specific.DataSource = dataTable1;
                    if (dataTable1.Rows.Count > 0)
                    {
                        this.AddBoundColumns(dataTable1, this.RadGrid_Specific);
                        this.RadGrid_Specific.DataBind();
                        this.RadGrid_Specific.AllowCustomPaging = true;
                        this.RadGrid_Specific.VirtualItemCount = dataTable1.Rows.Count;
                    }
                    if (this.pg.ToLower() == "webstoreorder")
                    {
                        this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
                        this.pnl_CloseWebstore.Visible = true;
                    }
                }
                else
                {
                    DataTable dataTable2 = EstimateBasePage.Attachment_PO_Select(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.PurchaseID);
                    this.RadGrid_Specific.DataSource = dataTable2;
                    if (dataTable2.Rows.Count > 0)
                    {
                        this.RadGrid_Specific.Visible = true;
                        this.RadGrid_Specific.DataBind();
                        this.RadGrid_Specific.AllowCustomPaging = true;
                        this.RadGrid_Specific.VirtualItemCount = dataTable2.Rows.Count;
                    }
                }
                this.RadGrid_Specific.MasterTableView.Rebind();
                string redirectUrl = string.Empty;
                if (selectedAttachment)
                {
                    string _domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    if (this.pg.ToLower().ToString() == "estimate" || this.pg.ToLower().ToString() == "webstoreorder")
                    {
                        redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + proofId + "";
                    }
                    else
                    {
                        redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + est_id + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + proofId + "";
                    }
                    //redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + proofId + "";
                }
                //else if (this.chk_IsAttachProof.Checked)
                //{
                //    string _domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                //    redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + proofId + "";
                //}
                else
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    List<string> s = new List<string>(url.Split(new string[] { "url=" }, StringSplitOptions.None));
                    if (s.Count > 1)
                    {
                        redirectUrl = s[1];
                    }
                    else
                    {
                        redirectUrl = s[0];
                    }
                    redirectUrl = redirectUrl.Replace("%2f", "/").Replace("%3a", ":").Replace("%3f", "?").Replace("%3d", "=");
                }
                if (!selectedAttachment)
                {
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>alert('Please select at least 1 attachment. ')</script>"));
                }
                else
                {
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", redirectUrl, "';</script>"));
                }
            }
            else
            {
                base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>alert('These attachments already proofed. ')</script>"));
            }

        }
        protected void RadGridGenerealOne_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                item.FindControl("Upld_DateGen");
                Label label = item.FindControl("lbl_UpldOn") as Label;
                label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
                ImageButton imageButton = (ImageButton)item.FindControl("imgbtnDelete");
                if (imageButton != null)
                {
                    string empty = string.Empty;
                    string strRemove = string.Empty;
                    if (this.pg.ToLower() == "job")
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                        strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isremove", this.Page.Request.Url.ToString());
                    }
                    else if (this.pg.ToLower() != "invoice")
                    {
                        empty = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()));
                        strRemove = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isremove", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isremove", this.Page.Request.Url.ToString()));
                    }
                    else
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                        strRemove = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isremove", this.Page.Request.Url.ToString());
                    }
                    if (empty.Trim().ToLower() == "false")
                    {
                        if(!string.IsNullOrEmpty(strRemove) && strRemove.Trim() == "1")
                        {
                            imageButton.Visible = true;
                        }
                        else
                        {
                            imageButton.Visible = false;
                        }
                    }
                }
            }
            GridTableView masterTableView = this.RadGrid_General.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("DivAddNew");
            string str = string.Empty;
            if (this.pg.ToLower() == "job")
            {
                str = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString());
            }
            else if (this.pg.ToLower() != "invoice")
            {
                str = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()));
            }
            else
            {
                str = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString());
            }
            if (str.Trim().ToLower() == "false")
            {
                htmlControl.Visible = false;
                return;
            }
            htmlControl.Visible = true;
        }

        public void RadStrp_Attch_OnTabClick(object sender, RadTabStripEventArgs e)
        {
            if (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "job")
            {
                if (this.RadStrp_Attch.SelectedIndex == 0)
                {
                    this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                    this.RadGrid_General.Rebind();
                    return;
                }
                this.RadGrid_Specific_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                this.ddl_Specific_Bind();
                if (this.ddl_Specific.Items.Count > 0)
                {
                    this.ddl_Specific.SelectedValue[0].ToString();
                }
                this.RadGrid_Specific.Rebind();
                return;
            }
            if (this.pg.ToLower() == "webstoreorder")
            {
                if (this.RadStrp_Attch.SelectedIndex == 0)
                {
                    this.RadGrid_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, this.ModuleType);
                    this.RadGrid_General.Rebind();
                    return;
                }
                if (this.RadStrp_Attch.SelectedIndex == 1)
                {
                    this.RadGrid_eStoreOrder_General_Bind(this.CompanyID, this.UserID, this.AttachmentType, this.AttachmentTypeID, this.EstimateID, this.pg);
                    this.ddl_Specific_Bind();
                    if (this.ItemTitle == "")
                    {
                        this.ddl_Specific.Visible = false;
                    }
                    this.RadGrid_Specific.Rebind();
                }
            }
        }

        protected void ddl_Specific_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}