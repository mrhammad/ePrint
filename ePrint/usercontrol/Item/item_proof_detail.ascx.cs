using DocumentFormat.OpenXml.ExtendedProperties;
using Ghostscript.NET.Processor;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.UI.Estimates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_proof_detail : System.Web.UI.UserControl
    {

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private commonClass commclass = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public Int32 ProofID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public int QtyCount;

        public int SectionCount;

        public int QtyNumber;

        private decimal DefaultTaxrate;

        private int DefaultTaxID;

        public bool Check_SpecialPrivilege;

        public bool UnitOfMeasureKey;

        public bool IsShowOW1;

        public bool IsShowOW2;

        public bool IsShowOW3;

        public bool IsShowOW4;

        public string IsFromActHist = string.Empty;

        public string tblWidth = string.Empty;

        public string tblWidth_MinWidth = string.Empty;

        public bool IsAccountingCode;

        public int OrderItemApprovalStatus;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string btnType = string.Empty;

        public string SaveValues = string.Empty;
        public static int AttachmentID;
        private commonClass objJava = new commonClass();
        public string SecureDocPath = global.SecureDocPath();
        public long ProofItemID;
        //public string ServerName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int num = 0;
            if (base.Request.QueryString["ProofID"] != null)
            {
                this.ProofID = Convert.ToInt32(base.Request.Params["ProofID"]);
            }
            //object[] estimateItemID;

            //ControlCollection controls32 = this.plhItemTotal.Controls;
            //estimateItemID = new object[] { "onchange=javascript:Tax_OnChange(this.value,", 1, ",", this.EstimateItemID, ",", num, ");" };
            //string str19 = string.Concat(estimateItemID);
            //estimateItemID = new object[] { "<select id='ddlProofFiles_", this.EstimateItemID, "_", num, "' class='normaltext' ", str19, " style='width:150px;display:block;' >" };
            //controls32.Add(new LiteralControl(string.Concat(estimateItemID)));

            //this.plhItemTotal.Controls.Add(new LiteralControl(this.Load_Proof_Values(0 ,0) ?? ""));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </select>"));


            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<tr id='trCostExMarkup' >")));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td id='tdspn' style='width: 16%;'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div class='bglabelItem_summary' style='width: 160px; clear: both;'>", this.objLanguage.GetLanguageConversion("Cost_Price_Ex_Markup"), "</div>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: right; width: 21%;border:solid 0px red; >")));

            ControlCollection controls4 = this.plhItemTotal.Controls;
            this.plhItemTotal.Controls.Add(new LiteralControl("<table style='padding-top:20px' runat='server'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<tr>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<td id='td_" + this.ProofID + "_" + this.EstimateItemID + "'>"));
            //var _ProofAprovedFilesDetail = EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, this.EstimateItemID);
            var _ProofAprovedFilesDetail = EstimateBasePage.GetDefaultSelectedImage(this.ProofID, this.EstimateItemID,this.ProofItemID);
            string _latestImagePath = string.Empty;
            foreach (DataRow row in _ProofAprovedFilesDetail.Rows)
            {
                string[] secureDocPath = new string[] { this.SecureDocPath, ConnectionClass.ServerName, @"\", this.Session["CompanyID"].ToString(), @"\attachments" ,@"\", this.objBase.SpecialDecode(row["FileName"].ToString()) };
                string filePath = string.Concat(secureDocPath);
                string empty1 = filePath.Replace(".pdf", "");
                string imagePath = string.Concat(empty1, ".png");
                item_proof_detail.ExecuteCommandGhostLibrary(filePath, imagePath);
                string _image = imagePath;
                string serverName = ConnectionClass.ServerName;
                _latestImagePath = ""+this.strSitepath+"/document/securedoc/"+serverName+"/"+ this.Session["CompanyID"].ToString()+"/attachments/"+ this.objBase.SpecialDecode(row["FileName"].ToString()) + "";
                string _ImagePath = _latestImagePath.Replace(".pdf", ".png");
                string ImgPath=_ImagePath.Replace(" ", "%20");
                string fileExtension = Path.GetExtension(ImgPath);
                ImgPath = this.GetIconPath(fileExtension, ImgPath);
                //System.Drawing.Image image = new Bitmap(_image);
                this.plhItemTotal.Controls.Add(new LiteralControl("<img src=" + ImgPath + " style='height:380px;width:380px;overflow:hidden;object-fit:contain;' onmouseover='changeCurser(this)' onclick=javascript:ShowAttachment('" + row["fileName"] + "','" + row["OriginalFileName"] + "');>"));
                this.plhItemTotal.Controls.Add(new LiteralControl());
                //this.plhItemTotal.Controls.Add(new LiteralControl("<img src='/images/Attachment_1.png' title='" + this.objBase.SpecialDecode(row["FileName"].ToString()) + "' style='width:150px' onmouseover='changeCurser(this)'   onclick=javascript:ShowAttachment('" + row["FileName"].ToString()+ "','" + row["OriginalFileName"].ToString() + "');>&nbsp;&nbsp;"));
            }
            //this.plhItemTotal.Controls.Add(new LiteralControl("<img src='/images/Attachment_1.png' style='height:60px;width:60px;border:1px solid grey'>&nbsp;&nbsp;<img src='/images/Attachment_1.png' style='height:60px;width:60px;border:1px solid grey'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
            string[] tblWidthMinWidth;
            AttachmentID = this.GetAttachmentID(this.ProofID, this.EstimateItemID,this.ProofItemID);
            DataTable dt = EstimateBasePage.ProofDefaultAttachmentHistory(this.ProofID, this.EstimateItemID, AttachmentID,this.ProofItemID);

            //if (dt.Rows.Count == 1)
            //{
            //    tblWidthMinWidth = new string[] { "<table id='tblSingleItem'  width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='border:2px solid #bfbfbf;margin-top:-75px", this.tblWidth_MinWidth, "'>" };
            //}
            //else if (dt.Rows.Count == 2)
            //{
            //    tblWidthMinWidth = new string[] { "<table id='tblSingleItem'  width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='border:2px solid #bfbfbf;margin-top:-23px", this.tblWidth_MinWidth, "'>" };
            //}
            //else
            //{
            //    tblWidthMinWidth = new string[] { "<table id='tblSingleItem'  width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='border:2px solid #bfbfbf;", this.tblWidth_MinWidth, "'>" };
            //}



            this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
            tblWidthMinWidth = new string[] { "<table id='tblSingleItem'  width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='margin-left:410px;margin-top:-383px", this.tblWidth_MinWidth, "'>" };
            controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
            this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trQuantity' style='margin-bottom:20px;'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<td id='tdlbl'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<div style='width: 90px; clear: both'>Artwork File</ div>"));
            this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: left;", 100, "'>")));

            object[] estimateItemID;
            ControlCollection controls32 = this.plhItemTotal.Controls;

            //estimateItemID = new object[] { "onchange=javascript:ProofChange(this.value,", 1, ",", this.EstimateItemID, ",", num, ");" };
            //string str19 = string.Concat(estimateItemID);
            //estimateItemID = new object[] { "<select id='ddlProofFiles_", this.EstimateItemID, "' class='normaltext' onchange='ChangeAttachment(" + this.EstimateItemID + "," + this.ProofID + ");ChangeAttachmentImage(" + this.EstimateItemID + "," + this.ProofID + ")' ", " style='width:391px;display:block;height:25px' >" };
            //controls32.Add(new LiteralControl(string.Concat(estimateItemID)));
            //var empty = string.Concat("<button type='button' name='SPLHistory'  onclick=javascript:ShowProofHistory(", this.EstimateItemID, ");>", "History", "</button>");
            //this.plhItemTotal.Controls.Add(new LiteralControl(this.Load_Proof_Values(this.ProofID, this.EstimateItemID) ?? ""));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </select>"));
            this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<span ID='ProofFile' CssClass='normalText_summarypage'><a href='"+_latestImagePath+ "' target='_blank'>", this.Load_Proof_Values(this.ProofID, this.EstimateItemID,this.ProofItemID), "</a></span>")));

            this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: left; width: 21%;border:0px solid red;'>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText_summarypage'>", empty, "</span>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trHistory'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper11' style='text-align: left;  : 21%;border:0px solid red;'>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
            DataTable Approvaltbl = EstimateBasePage.GetProofApproval(this.ProofItemID);
            string proofApproval = string.Empty;
            string secondApprovalName = string.Empty;
            string secondApprovalEmail = string.Empty;
            foreach (DataRow dr in Approvaltbl.Rows)
            {
                proofApproval = dr["Two_Stage_Approval"].ToString();
                secondApprovalName = dr["SecondApproverName"].ToString();
                secondApprovalEmail = dr["SecondApproverEmail"].ToString();
            }
            this.plhItemTotal.Controls.Add(new LiteralControl("<br><table style='margin-left:404px;'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<tr>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
            if (proofApproval.ToLower() == "true")
            {
                this.plhItemTotal.Controls.Add(new LiteralControl("<input type='checkbox' checked OnClick='DisplayEmailAndName(" + this.ProofItemID + ");' id='approval_chk_" + this.ProofItemID + "'/>"));
            }
            else
            {
                this.plhItemTotal.Controls.Add(new LiteralControl("<input type='checkbox' OnClick='DisplayEmailAndName(" + this.ProofItemID + ");' id='approval_chk_" + this.ProofItemID + "'/>"));
            }
            this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label id='approval_chk_" + this.ProofItemID + "'>" + this.objLanguage.GetLanguageConversion("approval_proof_lbl") + " </label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            if (proofApproval.ToLower() == "true")
            {
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='approver_name_row_" + this.ProofItemID + "'>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='margin-left:3px;' id='approver_name_lbl_" + this.ProofItemID + "'>" + this.objLanguage.GetLanguageConversion("Approver_Name_Lbl") + " </label>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<input type='text' style='width:196px;' value='"+secondApprovalName+"' id='approver_name_" + this.ProofItemID + "' />"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='approver_email_row_" + this.ProofItemID + "'>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='margin-left:3px;' id='approver_email_lbl_" + this.ProofItemID + "'>" + this.objLanguage.GetLanguageConversion("Approver_Email_Lbl") + " </label>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<input type='text' style='width:196px;' value='" + secondApprovalEmail + "' id='approver_email_" + this.ProofItemID + "' onblur='UpdateTwoStageApproval(" + this.ProofItemID + ")' />"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            }
            else
            {
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='approver_name_row_" + this.ProofItemID + "'>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='display:none;margin-left:3px;' id='approver_name_lbl_" + this.ProofItemID + "'>" + this.objLanguage.GetLanguageConversion("Approver_Name_Lbl") + " </label>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<input style='display:none;width:196px;' type='text' id='approver_name_" + this.ProofItemID + "' />"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='approver_email_row_" + this.ProofItemID + "'>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='display:none;margin-left:3px;' id='approver_email_lbl_" + this.ProofItemID + "'>" + this.objLanguage.GetLanguageConversion("Approver_Email_Lbl") + " </label>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<input style='display:none;width:196px;' type='text' id='approver_email_" + this.ProofItemID + "' onblur='UpdateTwoStageApproval(" + this.ProofItemID + ")' />"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            }   

            this.plhItemTotal.Controls.Add(new LiteralControl("</table><br>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<table class='historyTable' id='historyTable_" + this.ProofID + "_" + this.EstimateItemID + "' style='width:100%;margin-top:5px;display:block;max-height:422px;overflow-y: auto;width:720px;margin-left:410px;'>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("<thead>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<tr>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<th style='padding:5px;min-width:115px'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px;'>Date/Time</label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</th>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<th style='padding:5px;min-width:95px'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px;font-weight:bold'>User</label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</th>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<th style='padding:5px;width:200px'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px;font-weight:bold'>Message</label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</th>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<th style='padding:5px;width:95px'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px;font-weight:bold'>File Status</label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</th>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<th style='padding:5px;width:200px'>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px;font-weight:bold'>File</label>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</th>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            this.plhItemTotal.Controls.Add(new LiteralControl("</thead>"));
            foreach (DataRow dr in dt.Rows)
            {
                commonClass _commonClass1 = this.objJava;
                //DateTime dateTime = Convert.ToDateTime(dr["ProofDate"].ToString());
                //string proofDate = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                //string _proofDate = "";
                //if (!string.IsNullOrEmpty(proofDate))
                //{
                //    char spearator = ' ';
                //    _proofDate = proofDate.Split(spearator)[0];
                //}
                this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='tr_" + this.ProofID + "_" + this.EstimateItemID + "'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>" + dr["CreatedDate"].ToString() + "</label>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>" + dr["User"] + "</label>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>" + dr["Comments"] + "</label>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>" + dr["Status"] + "</label>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>" + dr["OriginalFileName"] + "</label>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            }


            //this.plhItemTotal.Controls.Add(new LiteralControl("<tr>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>2.45pm <br/>07/10/2020</label>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>Jones</label>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>Please see revision</label>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td style='padding:5px'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<label style='padding-top:10px'>Awaiting Approval</label>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

            this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
            //string[] tblWidthMinWidth = new string[] { "<table id='tblSingleItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
            //controls4.Add(new LiteralControl(string.Concat(tblWidthMinWidth)));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trQuantity' style='margin-bottom:20px;'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 160px; clear: both'>Artwork File</ div>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: left; width: 43%; ", 100, "'>")));

            //object[] estimateItemID;

            //ControlCollection controls32 = this.plhItemTotal.Controls;

            ////estimateItemID = new object[] { "onchange=javascript:ProofChange(this.value,", 1, ",", this.EstimateItemID, ",", num, ");" };
            ////string str19 = string.Concat(estimateItemID);
            //estimateItemID = new object[] { "<select id='ddlProofFiles_", this.EstimateItemID, "' class='normaltext' ", " style='width:300px;display:block;height:25px' >" };
            //controls32.Add(new LiteralControl(string.Concat(estimateItemID)));
            //var empty = string.Concat("<button type='button' name='SPLHistory'  onclick=javascript:ShowProofHistory(", this.EstimateItemID,  ");>", "History", "</button>");
            //this.plhItemTotal.Controls.Add(new LiteralControl(this.Load_Proof_Values(this.ProofID, this.EstimateItemID) ?? ""));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </select>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper1' style='text-align: left; width: 21%;border:0px solid red;'>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<span ID='spnPaperPrice1' CssClass='normalText_summarypage'>", empty, "</span>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trHistory'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdPaper11' style='text-align: left;  : 21%;border:0px solid red;'>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div align='left'  style='width: 100%; border:0px solid red; margin-top:20px; float:left;'  >")));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</br>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</br>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</br>"));
            //var ProofAprovedFilesDetail = EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, this.EstimateItemID);
            //foreach (DataRow row in ProofAprovedFilesDetail.Rows)
            //{
            //    //  Load_Proof_History(BaseClass.CheckIntegerNull((row["AttachmentId"])));
            //    Load_Proof_History(BaseClass.CheckIntegerNull(row["AttachmentId"]));
            //    var hidden = estimateItemID = new object[] { "<input type='hidden' id='hdn_ProofHistory_", this.EstimateItemID, "_", row["AttachmentId"], "' value='", row["AttachmentId"], "' />" };
            //    plhItemTotal.Controls.Add(new LiteralControl(string.Concat(estimateItemID)));
            //}
            /////////

            //ControlCollection controls = this.plhItemTotal.Controls;
            //string[] tblDynamic = new string[] { "<table id='tblSingleItem' width='", this.tblWidth, "' cellpadding='0' cellspacing='0' border='0' style='", this.tblWidth_MinWidth, "'>" };
            //controls4.Add(new LiteralControl(string.Concat(tblDynamic)));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<tr id='trQuantity' style='margin-bottom:5px;'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<td id='tdlbl' style='width: 16%'>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("<div class='bglabelItem_summary' style='width: 160px; clear: both'>Artwork File</ div>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td id='tdQty1' style='text-align: left; width: 43%; ", 100, "'>")));
            //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));
            //this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));

        }
        private string GetIconPath(string fileExtension,string filePath)
        {
            switch (fileExtension)
            {
                case ".xlsx": return "" + this.strSitepath + "/images/excel-icon.png";
                case ".xls": return "" + this.strSitepath + "/images/excel-icon.png";
                case ".docx": return "" + this.strSitepath + "/images/word-icon.png";
                case ".doc": return "" + this.strSitepath + "/images/word-icon.png";
                case ".pptx": return "" + this.strSitepath + "/images/ppt-icon.jpg";
                case ".txt": return "" + this.strSitepath + "/images/txt-icon.png";
                case ".csv": return "" + this.strSitepath + "/images/csv-icon.jpg";
                case ".gdoc": return "" + this.strSitepath + "/images/google-docs-icon.jpg";
                case ".gsheet": return "" + this.strSitepath + "/images/google-sheet-icon.jpg";
                case ".gslides": return "" + this.strSitepath + "/images/google-slide-icon.jpg";
                default: return filePath; // Default case if no match is found
            }
        }
        public static string ExecuteCommandGhostLibrary(string commandInput, string commandOut)
        {
            try
            {
                int pageFrom = 1;
                int pageTo = 50;



                using (GhostscriptProcessor ghostscript = new GhostscriptProcessor())
                {
                    ghostscript.Processing += new GhostscriptProcessorProcessingEventHandler(ghostscript_Processing);

                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dSAFER");
                    switches.Add("-dBATCH");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOPROMPT");
                    switches.Add("-dFirstPage=" + pageFrom.ToString());
                    switches.Add("-dLastPage=" + pageTo.ToString());
                    //switches.Add("-sDEVICE=png16m");
                    //switches.Add("-sDEVICE=pngalpha");
                    //switches.Add("-r300");
                    switches.Add("-r72");
                    //switches.Add("-r50");

                    switches.Add("-sDEVICE=png16m");
                    switches.Add("-dOptimize=true");

                    switches.Add("-dTextAlphaBits=4");
                    switches.Add("-dGraphicsAlphaBits=4");
                    switches.Add(@"-sOutputFile=" + commandOut);
                    switches.Add(@"-f");
                    switches.Add(commandInput);

                    ghostscript.Process(switches.ToArray());
                }

                return "";

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static void ghostscript_Processing(object sender, GhostscriptProcessorProcessingEventArgs e)
        {
            Console.WriteLine(e.CurrentPage.ToString() + " / " + e.CurrentPage.ToString());
        }

        private string Load_Proof_Values(Int32 ProofId, long EstimateItemID,long ProofItemID)
        {
            //decimal Taxrate = 00;
            //string empty = string.Empty;
            //int count = 0;
            string fileName = string.Empty;
            var ProofAprovedFilesDetail = EstimateBasePage.Get_ProofAttachments(ProofId, EstimateItemID,ProofItemID);
            foreach (DataRow row in ProofAprovedFilesDetail.Rows)
            {

                //ControlCollection controls = this.plhItemTotal.Controls;
                fileName = row["OriginalFileName"].ToString();
                //controls.Add(new LiteralControl(fileName));
                //string[] str = new string[] { "<option value='", row["AttachmentId"].ToString(), "' ", empty, ">", this.objBase.SpecialDecode(row["FileName"].ToString()), "</option>" };
                //controls.Add(new LiteralControl(string.Concat(str)));
                //if(count == 0)
                //{
                //    AttachmentID = int.Parse(row["AttachmentId"].ToString());
                //}
                //count++;
            }
            return fileName;
        }

        private int GetAttachmentID(Int32 ProofId, long EstimateItemID, long ProofItemID)
        {
            int AttachmentId = 0;
            var ProofAprovedFilesDetail = EstimateBasePage.Get_ProofAttachments(ProofId, EstimateItemID, ProofItemID);
            foreach (DataRow row in ProofAprovedFilesDetail.Rows)
            {
                AttachmentId = int.Parse(row["AttachmentId"].ToString());
            }
            return AttachmentId;
        }
        //private int GetAttachmentID(Int32 ProofId, long EstimateItemID)
        //{
        //   int count = 0;
        //    var ProofAprovedFilesDetail = EstimateBasePage.Get_ProofAprovedFilesDetail(ProofId, EstimateItemID);
        //    foreach (DataRow row in ProofAprovedFilesDetail.Rows)
        //    {

        //        if (count == 0)
        //        {
        //            AttachmentID = int.Parse(row["AttachmentId"].ToString());
        //        }
        //        count++;
        //    }
        //    return AttachmentID;
        //}
        private string Load_Proof_History(Int32 AttachmentID)
        {
            decimal Taxrate = 00;
            string empty = string.Empty;
            ControlCollection controls4 = this.plhItemTotal.Controls;
            string[] tblDynamic = new string[] { "<table  width='750' cellpadding='2' cellspacing='0' id=ProofTable_", AttachmentID.ToString(), "  style= 'display: none; ", this.tblWidth_MinWidth, "'>" };
            controls4.Add(new LiteralControl(string.Concat(tblDynamic)));
            foreach (DataRow row in EstimateBasePage.Get_Proof_History(AttachmentID).Rows)
            {
                //this.plhItemTotal.Controls.Add(new LiteralControl("<tr class='bglabelItem_summary'>"));
                //this.plhItemTotal.Controls.Add(new LiteralControl("<td style='border:none;' >"));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 400px;'>", row["AccessNotes"].ToString(), "</div>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 180px;'>", row["AccessByUser"].ToString(), "</div>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 90px;'>", BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("dd/MM/yyyy"), "</div>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 80px;padding-right: 10px;'>", BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("HH:mm"), "</div>")));
                //this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                //this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

                this.plhItemTotal.Controls.Add(new LiteralControl("<tr class='bglabelItem_summary'>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("<td style='border:none;' >"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 225px;'>", "Proof History", "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<div  style='width: 400px;'><b>Created By:</b>&nbsp;&nbsp;", row["AccessByUser"].ToString(), "<br/> <b>Created On:</b>&nbsp;&nbsp;", BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("dd/MM/yyyy"), " ", BaseClass.CheckDateTimeNull(row["AccessDate"]).ToString("HH:mm"), "<br/><b>Customer Name:</b>&nbsp;&nbsp;", row["CustomerName"].ToString(), "<br/><b>Customer Comments:</b>&nbsp;&nbsp;", row["CustomerComments"].ToString(), "</div>")));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl(string.Concat("<td style='border:none;'>")));
                this.plhItemTotal.Controls.Add(new LiteralControl(" </td>"));
                this.plhItemTotal.Controls.Add(new LiteralControl("</tr>"));

            }
            this.plhItemTotal.Controls.Add(new LiteralControl("</table>"));
            return this.plhItemTotal.ToString();
        }
        public void SaveClick(string type, string finalvalues, string JobID, string InvoiceID, string ItemDesc)
        {
            string[] strArrays = ItemDesc.Split(new char[] { '\u25AC' });
            EstimateCommonMethods.EditUpdateIDescriptionsInSummary(Convert.ToInt32(strArrays[0]), Convert.ToInt64(strArrays[1]), Convert.ToInt64(strArrays[2]), strArrays[3].ToString(), strArrays[4].ToString(), Convert.ToBoolean(strArrays[5]), Convert.ToBoolean(strArrays[6]), Convert.ToBoolean(strArrays[7]), strArrays[8].ToString(), strArrays[9].ToString());
            this.btnType = type;
            this.SaveValues = finalvalues;
            this.jID = JobID;
            this.InvID = InvoiceID;
            this.btnStay_Click(null, null);
        }
        protected void btnStay_Click(object sender, EventArgs e)
        {

        }
        private decimal ToDecimal(string Value)
        {
            if (Value.Length == 0)
            {
                return new decimal(0);
            }
            return decimal.Parse(Value.Replace(" ", ""));
        }
       

    }
}