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
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Item
{
    public partial class prof_attachment_selection : UsercontrolBasePage
    {

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string SecureDocFilepath = global.SecureDocFilepath();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureSitePath = global.SecureSitePath();

        public string PublicDocPath = global.PublicDocPath();

        public string ServerName = string.Empty;

        public string estoredisplay = "0";

        public bool val;

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

        static prof_attachment_selection()
        {
        }

        public prof_attachment_selection()
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





        public void CallFileUpload_General(FileUpload FileUploadName, long AttachmentID, out string FileName, out string OriginalAttachFileName)
        {
            string empty = string.Empty;
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
                        prof_attachment_selection usercontrolItemAttachment = this;
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
            estimateItem.FileName = this.objBase.ReplaceSingleQuote(newFileName);
            FileName = newFileName;
            OriginalAttachFileName = fileName;


        }

        public void CallFileUpload_specific(FileUpload FileUploadName, long AttachmentID, out string FileName, out string OriginalAttachFileName, bool val)
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
                    prof_attachment_selection usercontrolItemAttachment = this;
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
            FileName = newFileName;
            OriginalAttachFileName = fileName;
            if (estimateItem.FileName.Trim() != "")
            {
                string[] strArrays3 = estimateItem.FileName.ToString().Split(new char[] { '.' });

            }
            EstimateBasePage.etimates_attachment_insert(estimateItem);

        }
        public void Attachment_OnClick()
        {

        }
        public void ddl_Specific_Bind()
        {
            Label label = (Label)this.RadGrid_Specific.FindControl("lbl_ItemSpecific_Add");
            DropDownList dropDownList = (DropDownList)this.RadGrid_Specific.FindControl("ddl_Specific_Add");
            DataTable dataTable = EstimatesBasePage.Estimate_Items_RFQdescription_Select(this.CompanyID, this.EstimateID, "Proof");
            dataTable.Columns[3].ReadOnly = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["EstimateTitle"] = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
            }
            int num = 0;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.EstimateType = string.Concat(this.EstimateType, dataRow["EstimateType"].ToString(), "‡");
                this.EstimateItemID = dataRow["EstimateItemID"].ToString();
                this.ItemTitle = dataRow["EstimateTitle"].ToString();
                if (dataTable.Rows.Count <= 1)
                {

                    this.hdn_ddlEstitemID.Value = this.EstimateItemID.ToString();
                    this.hdn_ddlEstType.Value = this.EstimateType;
                }
                else
                {

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
            EstimateBasePage.InsertProofLastCounter(this.CompanyID);
            string statusID = this.proof_status.SelectedValue;
            Int32 proofId = EstimateBasePage.Create_proof(this.CompanyID, this.EstimateID, 0, DateTime.Now,int.Parse(statusID));
            bool selectedAttachment = false;
            for (int i = 0; i < this.RadGrid_Specific.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_Specific.Items[i].Cells[0].FindControl("Id1");
                if (htmlInputCheckBox.Checked)
                {
                    selectedAttachment = true;
                    //EstimateBasePage.Attachments_General_Delete(Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
                    EstimateBasePage.Create_proof_detail(0, BaseClass.CheckIntegerNull(htmlInputCheckBox.Value), proofId,UserID,DateTime.Now,this.CompanyID,int.Parse(statusID));
                    this.objBase.Message_Display("Proof Created", "msg-success", this.plhMessage);
                }
            }
            if (selectedAttachment)
            {
                DataTable _dt = EstimateBasePage.GetProofEstimateItemIDs(proofId);
                foreach(DataRow dr in _dt.Rows)
                {
                    EstimateBasePage.AddProofItemDetails(proofId,Convert.ToInt64(dr["EstimateItemID"].ToString()), DateTime.Now, int.Parse(statusID));
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
                redirectUrl = _domainName + "/Proofs/Proof_summary.aspx?estid=" + this.EstimateID + "&EstItemID=" + this.EstimateItemID + "&ProofID=" + proofId + "";
            }
            else
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                List<string> s = new List<string>(url.Split(new string[] { "url=" }, StringSplitOptions.None));
                redirectUrl = s[1];
                redirectUrl = redirectUrl.Replace("%2f", "/").Replace("%3a", ":").Replace("%3f", "?").Replace("%3d", "=");
            }
            base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", redirectUrl, "';</script>"));

        }



        public void deliveryandpurchase()
        {
            this.RadGrid_Specific.Visible = true;
            this.RadGrid_Specific.MasterTableView.Columns[2].Visible = false;
            this.RadGrid_Specific.MasterTableView.Columns[3].Visible = false;


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
                    prof_attachment_selection usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName.Replace("'", @"\'"), "‡");
                    prof_attachment_selection usercontrolItemAttachment1 = this;
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
                    prof_attachment_selection usercontrolItemAttachment = this;
                    usercontrolItemAttachment.AttachSupRFQ = string.Concat(usercontrolItemAttachment.AttachSupRFQ, this.FileName, "‡");
                    prof_attachment_selection usercontrolItemAttachment1 = this;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.QueryString["pg"] != null)
            {
                this.pg = base.Request.QueryString["pg"].ToString().ToLower();
            }
            if (!base.IsPostBack)
            {
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

            //this.attachment_btn.ToolTip = "Upload File";
            this.ModuleType = this.pg;
            this.Page.Header.DataBind();
            if (!base.IsPostBack)
            {

                this.RadGrid_Specific.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("File_Name");
                if (this.pg.ToLower() == "estimate")
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

            }
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (this.pg.ToLower() == "job")
            {
                empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
            }
            else if (this.pg.ToLower() != "invoice")
            {
                empty = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()));
            }
            else
            {
                empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
            }

            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            
            this.DateFormat = base.Session["Dateformat"].ToString();
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/attachments/" };
            this.StrDownload = string.Concat(secureSitePath);
            if (base.Request.QueryString["estid"] != null && this.pg.ToLower() == "job")
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            }
            else if (base.Request.QueryString["estid"] == null || !(this.pg.ToLower() == "invoice"))
            {
                string _estimateID = base.Request.QueryString["estid"].ToString();
                if (_estimateID.Contains(","))
                {
                    List<string> s = new List<string>(_estimateID.Split(new string[] { "," }, StringSplitOptions.None));
                    string estID = s[0];
                    this.EstimateID= Convert.ToInt64(estID);
                }
                else
                {
                    this.EstimateID = Convert.ToInt64(_estimateID);
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

            if (this.pg.ToLower() == "deliverynote" && base.Request.Params["DeliveryID"] != null)
            {
                this.DeliveryID = (long)Convert.ToInt32(base.Request.Params["DeliveryID"]);
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable2 = SettingsBasePage.PreFlight_Options_Select("MIS", this.CompanyID);
                string str = "0";

            }
            if (!base.IsPostBack)
            {

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
            //this.attachment_btn.Attributes.Add("onclick", string.Concat("javascript:ShowAttachments('", this.EstimateID, "','attachments');"));

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
            DataTable dataTable = EstimateBasePage.Attachments_ItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID, ModuleType);
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
                DataTable dataTable1 = EstimateBasePage.Attachments_ItemSpecific_Select(this.CompanyID, this.UserID, this.AttachmentType, this.EstimateID, "Proof");
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
                label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
                ImageButton imageButton = (ImageButton)item.FindControl("imgbtnDelete");
                if (imageButton != null)
                {
                    string empty = string.Empty;
                    if (this.pg.ToLower() == "job")
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString());
                    }
                    else if (this.pg.ToLower() != "invoice")
                    {
                        empty = (this.pg.ToLower() != "webstoreorder" ? baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()) : baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdelete", this.Page.Request.Url.ToString()));
                    }
                    else
                    {
                        empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString());
                    }
                    if (empty.Trim().ToLower() == "false")
                    {
                        imageButton.Visible = false;
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
                        string[] strArrays1 = new string[] { "<a id='ancFileName' href='javascript://' title='", dataItem["OriginalFileName"].ToString(), "'  onclick=\"OpenAttach('", dataItem["FileName"].ToString(), "','", dataItem["IsEdtiablePDF"].ToString(), "');\"/>", dataItem["OriginalFileName"].ToString(), "</a><br/>" };
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
            //GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            //HtmlControl htmlControl = (HtmlControl)items.FindControl("DivAddNewRecords");
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
            //if (empty2.Trim().ToLower() == "false")
            //{
            //    htmlControl.Visible = false;
            //    return;
            //}
            // htmlControl.Visible = true;
        }





        protected void ddl_Specific_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnDelete_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}