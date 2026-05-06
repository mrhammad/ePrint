using ePrint.usercontrol;
using nmsCommon;
using EPRINT;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ClosedXML.Excel;
using ePrint.ePrintUtilities;
namespace ePrint.Delivery
{
    public partial class delivery_report : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass objJava = new commonClass();

        public string ColumnNames = string.Empty;

        public string CompanyName = string.Empty;

        public string cs = string.Empty;

        public int CompanyID;

        public string DateFormat = string.Empty;

        public int UserID;

        public string startdate_quart = string.Empty;

        public string enddate_quart = string.Empty;

        public string[] day;

        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] enquardate;

        public string[] stlastweek;

        public string[] enlastweek;

        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string[] from_halffiscalyear;

        public string[] to_halffiscalyear;

        public string year = string.Empty;

        public string pagename = string.Empty;

        public int cellvalue_deliveryDate;

        public int cellvalue_jobDate;

        public string flag_jobDate = string.Empty;

        public int cellvalue_ActivityNotes;

        public string flag_deliveryDate = string.Empty;

        public int cellvalue_createdOn;

        public string flag_createdOn = string.Empty;

        public string flag_ActivityNotes = string.Empty;

        public int cellvalue_carrier;

        public string flag_carrier = string.Empty;

        public int cellvalue_quantity;

        public string flag_quantity = string.Empty;

        public int cellvalue_description;

        public string flag_description = string.Empty;

        public int cellvalue_itemnotes;

        public string flag_itemnotes = string.Empty;

        public int cellvalue_deladdlabel;
        public string flag_deladdlabel = string.Empty;

        //-- new field added to del report
        public int cellvalue_deladdline1;
        public string flag_deladdline1 = string.Empty;

        public int cellvalue_deladdline2;
        public string flag_deladdline2 = string.Empty;

        public int cellvalue_deladdline3;
        public string flag_deladdline3 = string.Empty;

        public int cellvalue_deladdline4;
        public string flag_deladdline4 = string.Empty;

        public int cellvalue_deladdline5;
        public string flag_deladdline5 = string.Empty;

        public int cellvalue_contactcustomfield1;
        public string flag_contactcustomfield1 = string.Empty;

        public int cellvalue_contactcustomfield2;
        public string flag_contactcustomfield2 = string.Empty;

        public int cellvalue_jobquantityordered;
        public string flag_jobquantityordered = string.Empty;

        public int cellvalue_shippedto;

        public string flag_shippedto = string.Empty;

        public int cellvalue_costcentre;

        public string flag_costcentre = string.Empty;

        public string FreeTextColoumn = string.Empty;

        public int cellvalue_itemtitle;

        public string flag_itemtitle = string.Empty;

        public int cellvalue_JobValue;

        public string flag_JobValue = string.Empty;

        public int PageSize = 100;

        public int totalrec;

        private int PageNumber = 1;

        public string pg = string.Empty;

        public static string divVisibility;

        public static string imgVisibility;

        public string export = string.Empty;

        public int cellvalue_CustomDate1;

        public string flag_CustomDate1 = string.Empty;
        public int cellvalue_CustomDate2;

        public string flag_CustomDate2 = string.Empty;
        public int cellvalue_CustomDate3;

        public string flag_CustomDate3 = string.Empty;
        public int cellvalue_CustomDate4;

        public string flag_CustomDate4 = string.Empty;
        public int cellvalue_CustomDate5;

        public string flag_CustomDate5 = string.Empty;

        public string customDatetitle1 = String.Empty;
        public string customDatetitle2 = String.Empty;
        public string customDatetitle3 = String.Empty;
        public string customDatetitle4 = String.Empty;
        public string customDatetitle5 = String.Empty;

        public languageClass objLangClass = new languageClass();

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

        static delivery_report()
        {
            delivery_report.divVisibility = "none";
            delivery_report.imgVisibility = "block";
        }

        public delivery_report()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.pagename.ToString().ToLower().Trim() == "report")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "common/report.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx"));
        }

        public void btnExport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            DataSet estimateData = this.GetEstimateData(0);
            foreach (DataRow row in estimateData.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("DeliveryDate"))
                {
                    row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("JobDate"))
                {
                    row["JobDate"] = this.objJava.Eprint_return_Date_Before_View(row["JobDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (!row.Table.Columns.Contains("CreatedDate"))
                {
                    continue;
                }
                row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
            }
            DataTable item = estimateData.Tables[0];
            if (item.Columns.Contains("deliveryid"))
            {
                item.Columns.Remove("deliveryid");
            }
            //HttpContext current = HttpContext.Current;
            //current.Response.Clear();
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("<html><body><table border='1'>");
            //stringBuilder.Append("<tr>");
            foreach (DataColumn column in item.Columns)
            {
                //stringBuilder.Append("<th>");
                //stringBuilder.Append(column.ColumnName);
                //stringBuilder.Append("</th>");
                for (int j = 0; j < item.Columns.Count; j++)
                {
                    if (item.Columns[j].ColumnName == "CompanyName")
                    {
                        item.Columns[j].ColumnName = "Company Name";
                    }
                    else if (item.Columns[j].ColumnName == "ShippedTo")
                    {
                        item.Columns[j].ColumnName = "Shipped To";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryNumber")
                    {
                        item.Columns[j].ColumnName = "Delivery No";
                    }
                    else if (item.Columns[j].ColumnName == "JobNumber")
                    {
                        item.Columns[j].ColumnName = "Job Number";
                    }
                    else if (item.Columns[j].ColumnName == "JobTitle")
                    {
                        item.Columns[j].ColumnName = "Job Title";
                    }
                    else if (item.Columns[j].ColumnName == "JobValue")
                    {
                        item.Columns[j].ColumnName = string.Concat("Job Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    else if (item.Columns[j].ColumnName == "ContactName")
                    {
                        item.Columns[j].ColumnName = "Contact Name";
                    }
                    else if (item.Columns[j].ColumnName == "ContactJobTitle1")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 1";
                    }
                    else if (item.Columns[j].ColumnName == "ContactJobTitle2")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 2";
                    }
                    else if (item.Columns[j].ColumnName == "JobContactName")
                    {
                        item.Columns[j].ColumnName = "Job Contact Name";
                    }
                    else if (item.Columns[j].ColumnName == "CreatedDate")
                    {
                        item.Columns[j].ColumnName = "Created On";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryDate")
                    {
                        item.Columns[j].ColumnName = "Delivery Date";
                    }
                    else if (item.Columns[j].ColumnName == "JobDate")
                    {
                        item.Columns[j].ColumnName = "Job Date";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[j].ColumnName = "Delivery Address";
                    }
                    else if (item.Columns[j].ColumnName == "CustomerOrderNumber")
                    {
                        item.Columns[j].ColumnName = "Customer OrderNumber";
                    }
                    else if (item.Columns[j].ColumnName == "GoodsDelivered")
                    {
                        item.Columns[j].ColumnName = "Goods Delivered";
                    }
                    else if (item.Columns[j].ColumnName == "ConsignmentNoteNumber")
                    {
                        item.Columns[j].ColumnName = "Consignment NoteNumber";
                    }
                    else if (item.Columns[j].ColumnName == "ConsigneeURL")
                    {
                        item.Columns[j].ColumnName = "Consignee URL";
                    }
                    else if (item.Columns[j].ColumnName == "ActivityNotes")
                    {
                        item.Columns[j].ColumnName = "Activity Notes";
                    }
                    else if (item.Columns[j].ColumnName == "ItemTitle")
                    {
                        item.Columns[j].ColumnName = "Item Title";
                    }
                    else if (item.Columns[j].ColumnName == "Quantity")
                    {
                        item.Columns[j].ColumnName = "Quantity";
                    }
                    else if (item.Columns[j].ColumnName == "Description")
                    {
                        item.Columns[j].ColumnName = "Description";
                    }
                    else if (item.Columns[j].ColumnName == "ItemNotes")
                    {
                        item.Columns[j].ColumnName = "Item Notes";
                    }
                    else if (item.Columns[j].ColumnName == "CustomerCode")
                    {
                        item.Columns[j].ColumnName = "Customer Code";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLabel")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Label";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine1")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 1";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine2")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 2";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine3")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 3";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine4")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 4";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine5")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 5";
                    }
                    else if (item.Columns[j].ColumnName == "ContactCustomField1")
                    {
                        item.Columns[j].ColumnName = "Contact Custom Field 1";
                    }
                    else if (item.Columns[j].ColumnName == "ContactCustomField2")
                    {
                        item.Columns[j].ColumnName = "Contact Custom Field 2";
                    }
                    else if (item.Columns[j].ColumnName == "JobQuantityOrdered")
                    {
                        item.Columns[j].ColumnName = "Job Quantity Ordered";
                    }
                    
                }
            }
            //stringBuilder.Append("</tr>");
            //stringBuilder.Append(Environment.NewLine);
            //foreach (DataRow dataRow in item.Rows)
            //{
            //stringBuilder.Append("<tr>");
            //for (int k = 0; k < item.Columns.Count; k++)
            //{
            //stringBuilder.Append("<td>");
            //string str = dataRow.ItemArray[k].ToString();
            //str = Regex.Replace(str, "'", "ˈ");
            //if (str.IndexOf("¶") >= 0)
            //{
            //str = str.Replace("¶", " ");
            //}
            //stringBuilder.Append(str);
            //stringBuilder.Append("</td>");
            //}
            //stringBuilder.Append("</tr>");
            //stringBuilder.Append(Environment.NewLine);
            //}
            //stringBuilder.Append("</table></body></html>");
            //string str1 = "DeliveryNote_List.xls";
            //current.Response.ContentType = "application/vnd.ms-excel";
            //current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str1, "\""));
            //current.Response.ContentEncoding = Encoding.Unicode;
            //base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            //current.Response.Write(stringBuilder);
            //current.Response.End();
            //current.Response.Close();
            //current.Response.Flush();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            DataSet ds = new DataSet();
            DataTable dtCopy1 = item.Copy();
            ds.Tables.Add(dtCopy1);
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable _dt in ds.Tables)
                {
                    wb.Worksheets.Add(_dt);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=DeliveryNote_List.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            //WebExport webExport = new WebExport();
            //webExport.Export_with_XSLT_Web(item, "DeliveryNote_List.xls");
        }
        private DataTable SetDeliveryReportColumns(DataSet deliveryData)
        {
            DataSet estimateData = deliveryData;
            foreach (DataRow row in estimateData.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("DeliveryDate"))
                {
                    row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("JobDate"))
                {
                    row["JobDate"] = this.objJava.Eprint_return_Date_Before_View(row["JobDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (!row.Table.Columns.Contains("CreatedDate"))
                {
                    continue;
                }
                row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
            }
            DataTable item = estimateData.Tables[0];
            if (item.Columns.Contains("deliveryid"))
            {
                item.Columns.Remove("deliveryid");
            }
            foreach (DataColumn column in item.Columns)
            {
                for (int j = 0; j < item.Columns.Count; j++)
                {
                    if (item.Columns[j].ColumnName == "CompanyName")
                    {
                        item.Columns[j].ColumnName = "Company Name";
                    }
                    else if (item.Columns[j].ColumnName == "ShippedTo")
                    {
                        item.Columns[j].ColumnName = "Shipped To";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryNumber")
                    {
                        item.Columns[j].ColumnName = "Delivery No";
                    }
                    else if (item.Columns[j].ColumnName == "JobNumber")
                    {
                        item.Columns[j].ColumnName = "Job Number";
                    }
                    else if (item.Columns[j].ColumnName == "JobTitle")
                    {
                        item.Columns[j].ColumnName = "Job Title";
                    }
                    else if (item.Columns[j].ColumnName == "JobValue")
                    {
                        item.Columns[j].ColumnName = string.Concat("Job Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    else if (item.Columns[j].ColumnName == "ContactName")
                    {
                        item.Columns[j].ColumnName = "Contact Name";
                    }
                    else if (item.Columns[j].ColumnName == "ContactJobTitle1")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 1";
                    }
                    else if (item.Columns[j].ColumnName == "ContactJobTitle2")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 2";
                    }
                    else if (item.Columns[j].ColumnName == "JobContactName")
                    {
                        item.Columns[j].ColumnName = "Job Contact Name";
                    }
                    else if (item.Columns[j].ColumnName == "CreatedDate")
                    {
                        item.Columns[j].ColumnName = "Created On";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryDate")
                    {
                        item.Columns[j].ColumnName = "Delivery Date";
                    }
                    else if (item.Columns[j].ColumnName == "JobDate")
                    {
                        item.Columns[j].ColumnName = "Job Date";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[j].ColumnName = "Delivery Address";
                    }
                    else if (item.Columns[j].ColumnName == "CustomerOrderNumber")
                    {
                        item.Columns[j].ColumnName = "Customer OrderNumber";
                    }
                    else if (item.Columns[j].ColumnName == "GoodsDelivered")
                    {
                        item.Columns[j].ColumnName = "Goods Delivered";
                    }
                    else if (item.Columns[j].ColumnName == "ConsignmentNoteNumber")
                    {
                        item.Columns[j].ColumnName = "Consignment NoteNumber";
                    }
                    else if (item.Columns[j].ColumnName == "ConsigneeURL")
                    {
                        item.Columns[j].ColumnName = "Consignee URL";
                    }
                    else if (item.Columns[j].ColumnName == "ActivityNotes")
                    {
                        item.Columns[j].ColumnName = "Activity Notes";
                    }
                    else if (item.Columns[j].ColumnName == "ItemTitle")
                    {
                        item.Columns[j].ColumnName = "Item Title";
                    }
                    else if (item.Columns[j].ColumnName == "Quantity")
                    {
                        item.Columns[j].ColumnName = "Quantity";
                    }
                    else if (item.Columns[j].ColumnName == "Description")
                    {
                        item.Columns[j].ColumnName = "Description";
                    }
                    else if (item.Columns[j].ColumnName == "ItemNotes")
                    {
                        item.Columns[j].ColumnName = "Item Notes";
                    }
                    else if (item.Columns[j].ColumnName == "CustomerCode")
                    {
                        item.Columns[j].ColumnName = "Customer Code";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLabel")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Label";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine1")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 1";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine2")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 2";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine3")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 3";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine4")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 4";
                    }
                    else if (item.Columns[j].ColumnName == "DeliveryAddressLine5")
                    {
                        item.Columns[j].ColumnName = "Delivery Address Line 5";
                    }
                    else if (item.Columns[j].ColumnName == "ContactCustomField1")
                    {
                        item.Columns[j].ColumnName = "Contact Custom Field 1";
                    }
                    else if (item.Columns[j].ColumnName == "ContactCustomField2")
                    {
                        item.Columns[j].ColumnName = "Contact Custom Field 2";
                    }
                    else if (item.Columns[j].ColumnName == "JobQuantityOrdered")
                    {
                        item.Columns[j].ColumnName = "Job Quantity Ordered";
                    }

                }
            }
            return item;
        }
        public void btnExport_vivid_OnClick(object sender, EventArgs e)
        {
            this.export = "true";
            this.Session["DeleteMsg"] = null;
            string value = this.hdnInnerHtml.Value;
            string str = "DeliveryNote_List.xls";
            base.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            base.Response.Clear();
            base.Response.Charset = "";
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.ContentEncoding = Encoding.Unicode;
            base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            base.Response.AppendHeader("content-disposition", string.Concat("attachment;filename=\"", str, "\""));
            this.EnableViewState = false;
            base.Response.Write("\r\n");
            string str1 = Regex.Replace(value, "'", "ˈ");
            base.Response.Write(str1);
            base.Response.End();
        }

        protected void btnfilter_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            if (this.Session["SaveAsNew"] != null)
            {
                this.btnSaveRun.Text = "Save and Run";
            }
            else
            {
                this.btnSaveRun.Text = "Save as New";
            }
            delivery_report.imgVisibility = "block";
            delivery_report.divVisibility = "none";
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            this.btnExportPPT.Visible = true;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetSelect();", true);
        }

        public void btngo_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.txt1.Text != "")
            {
                try
                {
                    this.paging_OnPageChange(Convert.ToInt32(this.txt1.Text));
                    delivery_report.imgVisibility = "none";
                    delivery_report.divVisibility = "none";
                }
                catch
                {
                    this.paging_OnPageChange(Convert.ToInt32("1"));
                    delivery_report.imgVisibility = "none";
                    delivery_report.divVisibility = "none";
                }
            }
        }

        public void btnRunReport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.btnUpdateExisting.Visible = false;
            this.btnRunReport.Visible = true;
            this.btnSaveRun.Text = "Save and Run";
            int num = 0;
            this.divtab.Visible = false;
            delivery_report.imgVisibility = "none";
            delivery_report.divVisibility = "none";
            this.btnfilter.Visible = true;
            if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("delivery notes", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.divtoolbar.Visible = true;
            this.txt1.Visible = true;
            this.btngo.Visible = true;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.divtoolbar.Visible = true;
                return;
            }
            DataSet estimateData = this.GetEstimateData(1);
            DataTable dt = new DataTable();
            if (this.ddlGrouprecords.SelectedIndex != 0)
            {
                this.GridEstReport.Visible = false;
                this.usrPaging.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                return;
            }
            if (estimateData.Tables.Count <= 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.btnExportPPT.Visible = false;
                this.lblTotalRecords.Text = "0";
                return;
            }
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.btnExportPPT.Visible = false;
                return;
            }
            if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
            {
                this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                this.GridEstReport.Visible = true;
                this.div_Total.Visible = false;
                this.pnlEmptyRecords.Visible = false;
                dt = SetDeliveryReportColumns(estimateData);
                this.GridEstReport.DataSource = dt;
                //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                this.GridEstReport.DataBind();
                //this.usrPaging.Visible = true;
                this.usrPaging.Visible = false;
                pagingreport.intCurrentPage = this.PageNumber;
                pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                this.usrPaging.CreatePaging();
                //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                this.CallPagingBtn_ScrollGrid(this.usrPaging);
                return;
            }
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.btnExportPPT.Visible = true;
            dt = SetDeliveryReportColumns(estimateData);
            this.GridEstReport.DataSource = dt;
            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            //this.usrPaging.Visible = true;
            this.usrPaging.Visible = false;
            pagingreport.intCurrentPage = this.PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        public void btnSaveRun_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.SaveReports("Save");
            this.RunReportOnClick();
        }

        public void btnUpdateExisting_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            if (this.hdn_reportID.Value == "")
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_GetReportID", this.objJava.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
                sqlCommand.Parameters.AddWithValue("@Pagename", "deliverynote");
                (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
                this.objJava.closeConnection();
                foreach (DataRow row in dataTable.Rows)
                {
                    this.hdn_reportID.Value = row["ReportID"].ToString();
                }
            }
            this.SaveReports("Update");
            this.RunReportOnClick();
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton = (LinkButton)usrPagingID.FindControl("lnkstart");
            LinkButton linkButton1 = (LinkButton)usrPagingID.FindControl("lnkPrev");
            LinkButton linkButton2 = (LinkButton)usrPagingID.FindControl("lnkNext");
            LinkButton linkButton3 = (LinkButton)usrPagingID.FindControl("lnkEnd");
            if (linkButton.Enabled)
            {
                linkButton.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton1.Enabled)
            {
                linkButton1.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton1.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton2.Enabled)
            {
                linkButton2.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton2.OnClientClick = "javascript:Disablelnk();";
            }
            if (!linkButton3.Enabled)
            {
                linkButton3.OnClientClick = "javascript:Disablelnk();";
                return;
            }
            linkButton3.OnClientClick = "javascript:showWaitMessage();";
        }

        public string CurrentQuater()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime.Month;
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int num = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (month == 1 || month == 2 || month == 3)
            {
                int month1 = dateTime.Month;
                if (month1 == 1)
                {
                    int num1 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num1, 31);
                }
                else if (month1 == 2)
                {
                    month1--;
                    int num2 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num2, 31);
                }
                else if (month1 == 3)
                {
                    month1 = month1 - 2;
                    int num3 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num3, 31);
                }
            }
            else if (month == 4 || month == 5 || month == 6)
            {
                int month2 = dateTime.Month;
                if (month2 == 4)
                {
                    int num4 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num4, 30);
                }
                else if (month2 == 5)
                {
                    month2--;
                    int num5 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num5, 30);
                }
                else if (month2 == 6)
                {
                    month2 = month2 - 2;
                    int num6 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num6, 30);
                }
            }
            else if (month == 7 || month == 8 || month == 9)
            {
                int month3 = dateTime.Month;
                if (month3 == 7)
                {
                    int num7 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num7, 30);
                }
                else if (month3 == 8)
                {
                    month3--;
                    int num8 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num8, 30);
                }
                else if (month3 == 9)
                {
                    month3 = month3 - 2;
                    int num9 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num9, 30);
                }
            }
            else if (month == 10 || month == 11 || month == 12)
            {
                int month4 = dateTime.Month;
                if (month4 == 10)
                {
                    int num10 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num10, 31);
                }
                if (month4 == 11)
                {
                    month4--;
                    int num11 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num11, 31);
                }
                else if (month4 == 12)
                {
                    month4 = month4 - 2;
                    int num12 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num12, 31);
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        private void dgGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    e.Item.Cells[i].Style.Add("border-bottom", "1px solid #BE1333");
                    e.Item.Cells[0].Visible = false;
                    if (e.Item.Cells[i].Text.ToLower() == "deliverynumber")
                    {
                        e.Item.Cells[i].Text = "Delivery Number";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "deliverydate")
                    {
                        e.Item.Cells[i].Text = "Delivery Date";
                        this.cellvalue_deliveryDate = i;
                        this.flag_deliveryDate = "true";
                        e.Item.Cells[this.cellvalue_deliveryDate].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Item.Cells[i].Text = "Created On";
                        this.cellvalue_createdOn = i;
                        this.flag_createdOn = "true";
                        e.Item.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "shippedto")
                    {
                        e.Item.Cells[i].Text = "Shipped To";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "activitynotes")
                    {
                        this.cellvalue_ActivityNotes = i;
                        this.flag_ActivityNotes = "true";
                        e.Item.Cells[i].Text = "Activity Notes";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate1")
                    {

                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate2")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate3")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate4")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate5")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    e.Item.Cells[j].Width = Unit.Percentage(20);
                    e.Item.Cells[j].Attributes.Add("align", "left");
                    e.Item.Cells[j].Style.Add("border-bottom", "solid thin silver");
                    e.Item.Cells[j].Style.Add("color", "#000000");
                    e.Item.Cells[j].Style.Add("font", "10px Arial");
                    e.Item.Cells[j].Style.Add("height", "50px");
                    e.Item.Cells[0].Visible = false;
                    if (this.flag_createdOn == "true")
                    {
                        e.Item.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                    if (this.flag_deliveryDate == "true")
                    {
                        e.Item.Cells[this.cellvalue_deliveryDate].Attributes.Add("align", "center");
                    }
                    if (this.flag_ActivityNotes == "true")
                    {
                        int num = 0;
                        while (num < e.Item.Controls.Count)
                        {
                            string str = e.Item.Cells[this.cellvalue_ActivityNotes].Text.Replace("¶", "<br/>");
                            this.lblActivityNotes.Text = base.Server.HtmlDecode(str);
                            e.Item.Cells[this.cellvalue_ActivityNotes].Text = this.lblActivityNotes.Text;
                            string str1 = e.Item.Cells[this.cellvalue_itemtitle].Text.Replace("<br/>", "<br />");
                            this.lblItemTitle.Text = base.Server.HtmlDecode(base.SpecialDecode(str1));
                            e.Item.Cells[this.cellvalue_itemtitle].Text = this.lblItemTitle.Text;
                            j++;
                        }
                    }
                }
            }
        }

        private DataSet GetEstimateData(int PageNumber)
        {
            object[] companyID;
            string[] strArrays;
            DateTime now;
            char[] chrArray;
            DataSet dataSet = new DataSet();
            StringBuilder stringBuilder = new StringBuilder();
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
            string empty5 = string.Empty;
            string str5 = string.Empty;
            if (!this.chkColumns.Items[0].Selected)
            {
                stringBuilder.Append(" a.deliveryid");
            }
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value == "CompanyName")
                    {
                        stringBuilder.Append(" a.deliveryid, Replace(Replace(Replace(isnull(b.clientName,''),'%22','\"'),'%27%27',''''),'%27','''') as CompanyName");
                    }
                    if (this.chkColumns.Items[i].Value == "ShippedTo")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.ShippedTo,'%22','\"'),'%27%27',''''),'%27','''') as ShippedTo");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.ShippedTo,'%22','\"'),'%27%27',''''),'%27','''') as ShippedTo");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryNumber")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.DeliveryNumber,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryNumber");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.DeliveryNumber,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryNumber");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobNumber")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(string.Concat(" Replace(Replace(Replace((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0 and isdeleted=0 and Isreverted=0) AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''')  as JobNumber "));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat(", Replace(Replace(Replace((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0 and isdeleted=0 and Isreverted=0 ) AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''')  as JobNumber "));
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobTitle")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(" Replace(Replace(Replace(isnull(e.EstimateTitle ,''),'%22','\"'),'%27%27',''''),'%27','''') as JobTitle ");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(isnull(e.EstimateTitle ,''),'%22','\"'),'%27%27',''''),'%27','''')  as JobTitle ");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobValue")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(" isnull( (select sum(jobvalue) from (select case when jc.qtynumber=1 then  TotalSellingPrice1 when jc.qtynumber=2 then  TotalSellingPrice2 when jc.qtynumber=3 then  TotalSellingPrice3 when jc.qtynumber=4 then  TotalSellingPrice4  else TotalSellingPrice1 end as jobvalue from tb_esttotalpricedetails et left join tb_jobcard jc on jc.estimateitemid=et.estimateitemid where et.estimateitemid in (select estimateitemid from tb_estimateitem where jobid=j.JobID) )vw)  ,0)  as JobValue");
                        }
                        else
                        {
                            stringBuilder.Append(", isnull( (select sum(jobvalue) from (select case when jc.qtynumber=1 then  TotalSellingPrice1 when jc.qtynumber=2 then  TotalSellingPrice2 when jc.qtynumber=3 then  TotalSellingPrice3 when jc.qtynumber=4 then  TotalSellingPrice4  else TotalSellingPrice1 end as jobvalue from tb_esttotalpricedetails et left join tb_jobcard jc on jc.estimateitemid=et.estimateitemid where et.estimateitemid in (select estimateitemid from tb_estimateitem where jobid=j.JobID) )vw)  ,0)  as JobValue");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ContactName")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((isnull(ct.firstName,'')+' '+isnull(ct.lastName,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactName");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((isnull(ct.firstName,'')+' '+isnull(ct.lastName,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactName");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ContactJobTitle1")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(ct.JobTitle,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle1");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(ct.JobTitle,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle1");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ContactJobTitle2")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(ct.JobTitle2,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle2");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(ct.JobTitle2,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle2");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobContactName")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select isnull(firstName,'')+' '+isnull(lastName,'') from tb_contact where contactId=e.AttentionID),'%22','\"'),'%27%27',''''),'%27','''')  as  JobContactName");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select isnull(firstName,'')+' '+isnull(lastName,'') from tb_contact where contactId=e.AttentionID),'%22','\"'),'%27%27',''''),'%27','''')  as  JobContactName");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CreatedDate")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryDate")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),a.DeliveryDate,101) as DeliveryDate");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),a.DeliveryDate,101) as DeliveryDate");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobDate")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),j.JobDate,101) as JobDate");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),j.JobDate,101) as JobDate");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryAddress")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(Address,'')+' '+IsNull(Addressline2,'')+' '+IsNull(City,'')+' '+IsNull(State,'')+' '+IsNull(ZipCode,'')+' '+IsNull(Country,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddress");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(Address,'')+' '+IsNull(Addressline2,'')+' '+IsNull(City,'')+' '+IsNull(State,'')+' '+IsNull(ZipCode,'')+' '+IsNull(Country,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddress");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Comments")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.Comments,'%22','\"'),'%27%27',''''),'%27','''') as Comments");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.Comments,'%22','\"'),'%27%27',''''),'%27','''') as Comments");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Status")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select isnull(StatusTitle,'') from tb_EstimateStatus where StatusID=a.Status),'%22','\"'),'%27%27',''''),'%27','''') as Status");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select isnull(StatusTitle,'') from tb_EstimateStatus where StatusID=a.Status),'%22','\"'),'%27%27',''''),'%27','''') as Status");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "RefNo")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.RefNo,'%22','\"'),'%27%27',''''),'%27','''') as RefNo");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.RefNo,'%22','\"'),'%27%27',''''),'%27','''') as RefNo");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CustomerOrderNumber")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.OrderNo,'%22','\"'),'%27%27',''''),'%27','''') as CustomerOrderNumber");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.OrderNo,'%22','\"'),'%27%27',''''),'%27','''') as CustomerOrderNumber");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "GoodsDelivered")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(case when a.GoodsDelivered='0' then 'No' else 'Yes' end,'%22','\"'),'%27%27',''''),'%27','''') as GoodsDelivered");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(case when a.GoodsDelivered='0' then 'No' else 'Yes' end,'%22','\"'),'%27%27',''''),'%27','''') as GoodsDelivered");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Carrier")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select isnull(ClientName,'') from tb_client ct where ct.clientID=a.CarrierID and ct.IsCarrier=1 and ct.isDelete=0),'%22','\"'),'%27%27',''''),'%27','''') as Carrier");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select isnull(ClientName,'') from tb_client ct where ct.clientID=a.CarrierID and ct.IsCarrier=1 and ct.isDelete=0),'%22','\"'),'%27%27',''''),'%27','''') as Carrier");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ConsignmentNoteNumber")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.ConsignmentNumber,'%22','\"'),'%27%27',''''),'%27','''') as ConsignmentNoteNumber");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.ConsignmentNumber,'%22','\"'),'%27%27',''''),'%27','''') as ConsignmentNoteNumber");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ConsigneeURL")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(a.ConsigneeUrl,'%22','\"'),'%27%27',''''),'%27','''') as ConsigneeURL");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(a.ConsigneeUrl,'%22','\"'),'%27%27',''''),'%27','''') as ConsigneeURL");
                        }
                    }
                    else if (this.chkColumns.Items[i].Value == "ActivityNotes")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(string.Concat("Replace(Replace(Replace(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.DeliveryID and IsDelete=0 and ModuleName='delivery') AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                        }
                        else if (this.ddlNotesType.SelectedValue == "0")
                        {
                            stringBuilder.Append(string.Concat(",Replace(Replace(Replace(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.DeliveryID and IsDelete=0 and ModuleName='delivery') AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                        }
                        else if (this.ddlNotesType.SelectedValue == "System")
                        {
                            stringBuilder.Append(string.Concat(",Replace(Replace(Replace(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.DeliveryID and IsDelete=0 and type='System' and ModuleName='delivery') AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                        }
                        else if (this.ddlNotesType.SelectedValue == "General")
                        {
                            stringBuilder.Append(string.Concat(",Replace(Replace(Replace(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.DeliveryID and IsDelete=0 and type='General' and ModuleName='delivery') AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                        }
                        else if (this.ddlNotesType.SelectedValue == "Error")
                        {
                            stringBuilder.Append(string.Concat(",Replace(Replace(Replace(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.DeliveryID and IsDelete=0 and type='Error' and ModuleName='delivery') AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ItemTitle")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(string.Concat("Replace(Replace(Replace((select  STUFF((SELECT ',' + ItemTitleValue FROM (SELECT rtrim(ltrim(ItemTitleValue)) as ItemTitleValue from tb_EstItemDescription  where CompanyID=", this.CompanyID, " and EstimateItemID=di.ItemID AND EstimateItemID!=0) AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''') as ItemTitle"));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat(",Replace(Replace(Replace((select  STUFF((SELECT ',' + ItemTitleValue FROM (SELECT rtrim(ltrim(ItemTitleValue)) as ItemTitleValue from tb_EstItemDescription  where CompanyID=", this.CompanyID, " and EstimateItemID=di.ItemID AND EstimateItemID!=0) AS T FOR XML PATH('')),1,1,'') ),'%22','\"'),'%27%27',''''),'%27','''')  as ItemTitle"));
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Quantity")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("di.Quantity as Quantity");
                        }
                        else
                        {
                            stringBuilder.Append(",di.Quantity as Quantity");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Description")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(di.Description,'%22','\"'),'%27%27',''''),'%27','''') as Description");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(di.Description,'%22','\"'),'%27%27',''''),'%27','''') as Description");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ItemNotes")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace(di.Notes,'%22','\"'),'%27%27',''''),'%27','''') as ItemNotes");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace(di.Notes,'%22','\"'),'%27%27',''''),'%27','''') as ItemNotes");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CustomerCode")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            companyID = new object[] { "Replace(Replace(Replace(case when e.IsFromWebStore='yes' then (select isnull(CustomerCode,'') from tb_PriceCatalogue  where CompanyID=", this.CompanyID, " and PriceCatalogueID=di.PriceCatalogueID and IsDeleted=0) else (select isnull(CustomerCode,'') from tb_PriceCatalogue where CompanyID=", this.CompanyID, " and PriceCatalogueID=di.PriceCatalogueID and IsDeleted=0) end,'%22','\"'),'%27%27',''''),'%27','''') as CustomerCode " };
                            stringBuilder.Append(string.Concat(companyID));
                        }
                        else
                        {
                            companyID = new object[] { ",Replace(Replace(Replace(case when e.IsFromWebStore='yes' then (select isnull(CustomerCode,'') from tb_PriceCatalogue  where CompanyID=", this.CompanyID, " and PriceCatalogueID=di.PriceCatalogueID and IsDeleted=0) else (select isnull(CustomerCode,'') from tb_PriceCatalogue where CompanyID=", this.CompanyID, " and PriceCatalogueID=di.PriceCatalogueID and IsDeleted=0) end,'%22','\"'),'%27%27',''''),'%27','''') as CustomerCode  " };
                            stringBuilder.Append(string.Concat(companyID));
                        }
                    }      
                    // new fields added to del report
                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLine1")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(Address,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine1");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(Address,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine1");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLine2")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(Addressline2,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine2");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(Addressline2,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine2");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLine3")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(City,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine3");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(City,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine3");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLine4")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(State,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine4");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(State,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine4");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLine5")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(ZipCode,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine5");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(ZipCode,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLine5");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ContactCustomField1")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((isnull(ct.CustomField1,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactCustomField1");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((isnull(ct.CustomField1,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactCustomField1");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ContactCustomField2")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((isnull(ct.CustomField2,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactCustomField2");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((isnull(ct.CustomField2,'')),'%22','\"'),'%27%27',''''),'%27','''') as  ContactCustomField2");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "JobQuantityOrdered")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append(" isnull( (select top 1 JobQuantityOrdered from (select case when jc.qtynumber=1 then  CAST(et.QTYDescription1 AS nvarchar(max)) when jc.qtynumber=2 then  CAST(et.QTYDescription2 AS nvarchar(max)) when jc.qtynumber=3 then  CAST(et.QTYDescription3 AS nvarchar(max)) when jc.qtynumber=4 then  CAST(et.QTYDescription4 AS nvarchar(max))  else CAST(et.QTYDescription1 AS nvarchar(max)) end as JobQuantityOrdered from tb_esttotalpricedetails et left join tb_jobcard jc on jc.estimateitemid=et.estimateitemid where et.estimateitemid=di.ItemID )vw)  ,0)  as JobQuantityOrdered");
                        }
                        else
                        {
                            stringBuilder.Append(", isnull( (select top 1 JobQuantityOrdered from (select case when jc.qtynumber=1 then  CAST(et.QTYDescription1 AS nvarchar(max)) when jc.qtynumber=2 then  CAST(et.QTYDescription2 AS nvarchar(max)) when jc.qtynumber=3 then  CAST(et.QTYDescription3 AS nvarchar(max)) when jc.qtynumber=4 then  CAST(et.QTYDescription4 AS nvarchar(max))  else CAST(et.QTYDescription1 AS nvarchar(max)) end as JobQuantityOrdered from tb_esttotalpricedetails et left join tb_jobcard jc on jc.estimateitemid=et.estimateitemid where et.estimateitemid=di.ItemID )vw)  ,0)  as JobQuantityOrdered");
                        }
                    }

                    if (this.chkColumns.Items[i].Value == "CustomDate1")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),e.EstCustomDate1,101) as CustomDate1");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),e.EstCustomDate1,101) as CustomDate1");
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CustomDate2")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),e.EstCustomDate2,101) as CustomDate2");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),e.EstCustomDate2,101) as CustomDate2");
                        }
                    }
                     if (this.chkColumns.Items[i].Value == "CustomDate3")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),e.EstCustomDate3,101) as CustomDate3");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),e.EstCustomDate3,101) as CustomDate3");
                        }
                    }
                     if (this.chkColumns.Items[i].Value == "CustomDate4")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),e.EstCustomDate4,101) as CustomDate4");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),e.EstCustomDate4,101) as CustomDate4");
                        }
                    }
                     if (this.chkColumns.Items[i].Value == "CustomDate5")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("CONVERT(VARCHAR(10),e.EstCustomDate5,101) as CustomDate5");
                        }
                        else
                        {
                            stringBuilder.Append(",CONVERT(VARCHAR(10),e.EstCustomDate5,101) as CustomDate5");
                        }
                    }

                    if (this.chkColumns.Items[i].Value == "DeliveryAddressLabel")
                    {
                        if (stringBuilder.ToString() == "")
                        {
                            stringBuilder.Append("Replace(Replace(Replace((select IsNull(IsNull(AddressLabel,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLabel");
                        }
                        else
                        {
                            stringBuilder.Append(",Replace(Replace(Replace((select IsNull(IsNull(AddressLabel,''),'') from tb_CompanyAddress where AddressID=a.DeliveryAddressID and clientid=a.customerid),'%22','\"'),'%27%27',''''),'%27','''') as  DeliveryAddressLabel");
                        }
                    }

                }
            }
            empty = string.Concat("from tb_Delivery a left join tb_DeliveryItem di on di.DeliveryID=a.DeliveryID  and di.isdeleted=0 left join tb_Client b on b.ClientID=a.CustomerID and b.isdelete=0 left join tb_Estimate e on e.EstimateID=di.EstimateID and e.IsDeleted=0 left join tb_job j on j.EstimateID=e.EstimateID and j.IsDeleted=0  left join tb_contact ct on ct.contactId=a.AttentionID and ct.isdelete=0  ");
            if (CheckXeroTracking())
                empty = string.Concat(empty , " left join tb_user uu on uu.userID=a.CreatedBy left join TrackingOption tr on tr.Id=uu.TrackingOptionId ");
            empty = string.Concat(empty, " where a.companyid=", this.CompanyID, " and e.IsDeleted=0 and a.IsDeleted=0 ");
            if (this.txtFreetext.Text != "")
            {
                int num = 0;
                for (int j = 0; j < this.chkfreetext.Items.Count; j++)
                {
                    if (this.chkfreetext.Items[j].Selected)
                    {
                        num++;
                    }
                }
                int num1 = 0;
                for (int k = 0; k < this.chkfreetext.Items.Count; k++)
                {
                    if (num > 1)
                    {
                        if (this.chkfreetext.Items[k].Selected)
                        {
                            if (this.chkfreetext.Items[k].Value == "CustomerName")
                            {
                                empty = string.Concat(empty, " and ( (b.clientName like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "ShippedTo")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  (a.ShippedTo like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "DeliveryNumber")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  (a.DeliveryNumber like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "JobNumber")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                companyID = new object[] { empty, "  ((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0) AS T FOR XML PATH('')),1,1,'') ) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')" };
                                empty = string.Concat(companyID);
                            }
                            if (this.chkfreetext.Items[k].Value == "ContactName")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  ((isnull(ct.firstName,'')+' '+isnull(ct.lastName,'')) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "JobContactName")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  ((select isnull(firstName,'')+' '+isnull(lastName,'') from tb_contact where contactId=e.AttentionID)    like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "Status")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  ((select isnull(StatusTitle,'') from tb_EstimateStatus where StatusID=a.Status) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "RefNo")
                            {
                                empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                empty = string.Concat(empty, "  (a.RefNo like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            num1++;
                        }
                    }
                    else if (num == 1 && this.chkfreetext.Items[k].Selected)
                    {
                        if (this.chkfreetext.Items[k].Value == "CustomerName")
                        {
                            empty = string.Concat(empty, " and ( (b.clientName like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "ShippedTo")
                        {
                            empty = string.Concat(empty, " and ( (a.ShippedTo like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "DeliveryNumber")
                        {
                            empty = string.Concat(empty, " and ( (a.DeliveryNumber like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "JobNumber")
                        {
                            companyID = new object[] { empty, " and ( ((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0) AS T FOR XML PATH('')),1,1,'') ) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')" };
                            empty = string.Concat(companyID);
                        }
                        if (this.chkfreetext.Items[k].Value == "ContactName")
                        {
                            empty = string.Concat(empty, " and ( ((isnull(ct.firstName,'')+' '+isnull(ct.lastName,'')) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "JobContactName")
                        {
                            empty = string.Concat(empty, " and ( ((select isnull(firstName,'')+' '+isnull(lastName,'') from tb_contact where contactId=e.AttentionID)  like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "Status")
                        {
                            empty = string.Concat(empty, " and ( ((select isnull(StatusTitle,'') from tb_EstimateStatus where StatusID=a.Status) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                        if (this.chkfreetext.Items[k].Value == "RefNo")
                        {
                            empty = string.Concat(empty, " and ( (a.RefNo like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                        }
                    }
                }
                if (num != 0)
                {
                    empty = string.Concat(empty, " ) ");
                }
                base.SpecialEncode(this.txtFreetext.Text);
            }
            if (CheckXeroTracking())
            {
                if (this.ddlLocation.SelectedIndex > 0)
                {
                   
                    empty = string.Concat(empty, " and tr.TrackingOption=","'", ddlLocation.SelectedItem.Text,"' ");
                }
            }

            if (this.txtName.Text != "")
            {
                empty = string.Concat(empty, "and a.CustomerID=", this.hid_ClientID.Value);
                string text = this.txtName.Text;
            }
            if (this.chkDateOption.Checked)
            {
                if (this.rdlDate.SelectedValue == "daily")
                {
                    string str6 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) = '", str6, "' ");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    string str7 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) = '", str7, "' ");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    string str8 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str9 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str8, "' and '", str9, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    string str10 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str11 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str10, "' and '", str11, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    string str10 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat.Replace("mm", "MM")));
                    string str11 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str10, "' and '", str11, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    string str12 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str12, "' and '", str13, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    empty = string.Concat(empty, "and YEAR(a.DeliveryDate) like '%", this.year, "%' ");
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str14, "' and '", str15, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    commonClass _commonClass = this.objJava;
                    now = DateTime.Now;
                    string str16 = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    chrArray = new char[] { ' ' };
                    string[] strArrays1 = str16.Split(chrArray);
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) < '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays1[0].ToString()), "' ");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    string str17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtFrom.Text));
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtTo.Text));
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) BETWEEN '", str17, "' AND '", str18, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str14, "' and '", str15, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str14, "' and '", str15, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.DeliveryDate)) between '", str14, "' and '", str15, "' " };
                    empty = string.Concat(strArrays);
                }
            }
            if (this.chkJobDate.Checked)
            {
                if (this.ddlJobdate.SelectedValue == "daily")
                {
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) = '", str19, "' ");
                }
                else if (this.ddlJobdate.SelectedValue == "yesterday")
                {
                    string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) = '", str20, "' ");
                }
                else if (this.ddlJobdate.SelectedValue == "thismonth")
                {
                    string str21 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str22 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str21, "' and '", str22, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "thisquarter")
                {
                    string str23 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str24 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str23, "' and '", str24, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    string str23 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat).ToString());
                    string str24 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str23, "' and '", str24, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "lastquater")
                {
                    string str25 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str26 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str25, "' and '", str26, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "thisyear")
                {
                    empty = string.Concat(empty, "and YEAR(a.CreatedDate) like '%", this.year, "%' ");
                }
                else if (this.ddlJobdate.SelectedValue == "halfyear")
                {
                    string str27 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str28 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str27, "' and '", str28, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "tilldate")
                {
                    commonClass _commonClass1 = this.objJava;
                    now = DateTime.Now;
                    string str29 = _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    chrArray = new char[] { ' ' };
                    string[] strArrays2 = str29.Split(chrArray);
                    empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) < '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays2[0].ToString()), "' ");
                }
                else if (this.ddlJobdate.SelectedValue == "daterange")
                {
                    string str30 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobFrom.Text));
                    string str31 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtJobTo.Text));
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) BETWEEN '", str30, "' AND '", str31, "' " };
                    empty = string.Concat(strArrays);
                }

                else if (this.ddlJobdate.SelectedValue == "lastweek")
                {
                    string str25 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str26 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str25, "' and '", str26, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "lastmonth")
                {
                    string str25 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str26 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str25, "' and '", str26, "' " };
                    empty = string.Concat(strArrays);
                }
                else if (this.ddlJobdate.SelectedValue == "lastyear")
                {
                    string str25 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str26 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    strArrays = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,j.JobDate)) between '", str25, "' and '", str26, "' " };
                    empty = string.Concat(strArrays);
                }
            }

            SqlConnection sqlConnection = new SqlConnection(this.cs);
            if (this.ddlGrouprecords.SelectedIndex == 0)
            {
                StringBuilder stringBuilder1 = new StringBuilder();
                if (PageNumber != 0)
                {
                    //int pageNumber = PageNumber * 100 - 100;
                    //int num2 = 100;
                    if (this.chkColumns.Items[21].Selected || this.chkColumns.Items[22].Selected || this.chkColumns.Items[23].Selected || this.chkColumns.Items[24].Selected)
                    {
                        companyID = new object[] { "select  ", stringBuilder, " ", empty };
                        stringBuilder1.Append(string.Concat(companyID));
                    }
                    else
                    {
                        companyID = new object[] { "select Distinct ", stringBuilder, " ", empty };
                        stringBuilder1.Append(string.Concat(companyID));
                    }

                    // Estimator Drop down filter
                    if (this.ddlEstimator.SelectedItem.Value != string.Empty)
                    {
                        stringBuilder.Append(" and exists( ");

                        companyID = new object[] { " Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u where u.CompanyID=", this.CompanyID,
                    " and u.UserID=a.EstimatorId and u.IsDelete=0 and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'",
                    base.SpecialEncode(this.ddlEstimator.SelectedItem.Text), "'+ '%')" };
                        stringBuilder.Append(string.Concat(companyID));
                    }

                    // Sales Person Drop down filter
                    if (this.ddlSalesPerson.SelectedItem.Value != string.Empty)
                    {
                        stringBuilder.Append(" and exists( ");

                        companyID = new object[] { " Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u where u.CompanyID=", this.CompanyID,
                    " and u.UserID=a.SalesPerson and u.IsDelete=0 and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'",
                    base.SpecialEncode(this.ddlSalesPerson.SelectedItem.Text), "'+ '%')" };
                        stringBuilder.Append(string.Concat(companyID));
                    }
                    //Customer Sales Person filter
                    if (this.ddlCustomerSalesPerson.SelectedItem.Value != string.Empty)
                    {
                        stringBuilder.Append(" and exists( ");

                        companyID = new object[] { " Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u " +
                        " inner join tb_client clnt" +
                        " on clnt.SalesPerson = u.userID " +
                        "where u.CompanyID=", this.CompanyID, " and u.IsDelete=0 and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'",
                    base.SpecialEncode(this.ddlCustomerSalesPerson.SelectedItem.Text), "'+ '%') " };
                        stringBuilder.Append(string.Concat(companyID));
                    }

                    if (this.HdnSortBy.Value.ToLower() == "none")
                    {
                        //stringBuilder1.Append(" ");
                        stringBuilder1.Append(" order by DeliveryNumber ASC  ");
                    }
                    else if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                    {
                        stringBuilder1.Append(string.Concat("order by ", this.HdnSortBy.Value));
                        if (this.ddldirection.SelectedValue == "ASC")
                        {
                            stringBuilder1.Append(" ASC ");
                        }
                        else if (this.ddldirection.SelectedValue == "DESC")
                        {
                            stringBuilder1.Append(" DESC ");
                        }
                    }
                    //companyID = new object[] { " offset ", pageNumber, " rows fetch next ", num2, " rows only;" };
                    //stringBuilder1.Append(string.Concat(companyID));
                    stringBuilder1.Append(string.Concat(" select count(*) ", empty.ToString()));
                }
                else
                {
                    companyID = new object[] { "select distinct ", stringBuilder, " ", empty };
                    stringBuilder1.Append(string.Concat(companyID));
                    if (this.HdnSortBy.Value.ToLower() == "none")
                    {
                        stringBuilder1.Append(" ");
                    }
                    else if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                    {
                        stringBuilder1.Append(string.Concat("order by ", this.HdnSortBy.Value));
                        if (this.ddldirection.SelectedValue == "ASC")
                        {
                            stringBuilder1.Append(" ASC ");
                        }
                        else if (this.ddldirection.SelectedValue == "DESC")
                        {
                            stringBuilder1.Append(" DESC ");
                        }
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder1.ToString(), sqlConnection);
                sqlDataAdapter.Fill(dataSet);
            }
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "1")
            {
                int num3 = 0;
                this.btnExport.Visible = false;
                this.btnExportPPT.Visible = true;
                DataSet dataSet1 = new DataSet();
                string str32 = string.Concat("select distinct isnull(CONVERT(VARCHAR(10),a.CreatedDate,101),'') as CreatedDate ", empty, " order by CreatedDate");
                (new SqlDataAdapter(str32, sqlConnection)).Fill(dataSet1);
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>"));
                    Label label = new Label();
                    commonClass _commonClass2 = this.objJava;
                    now = Convert.ToDateTime(row["CreatedDate"]);
                    label.Text = _commonClass2.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                    this.plhdetails.Controls.Add(label);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100% class='callreport_grpby' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                    if (this.chkColumns.Items[0].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[1].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Shipped_To"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[2].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[3].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[4].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[5].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("New_job_Value"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[6].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[7].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Contact_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[8].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Created_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[9].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[10].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[11].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Address"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[12].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Comments"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[13].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Status"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[14].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Ref_No"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[15].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Customer_Order_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[16].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Goods_Delivered"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[17].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Carrier"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[18].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Consignment_Note_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[19].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Consignee_url"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[20].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Activity_Notes"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[21].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Item_Title"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[22].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Quantity"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[23].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[24].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("p_Customer_code"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[25].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Job_Title1"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[26].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Job_Title2"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[27].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Item_Notes"), "</b>&nbsp;</div></td>")));
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    StringBuilder stringBuilder2 = new StringBuilder();
                    commonClass _commonClass3 = this.objJava;
                    now = Convert.ToDateTime(row["CreatedDate"]);
                    string str33 = _commonClass3.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                    companyID = new object[] { "select ", stringBuilder, " ", empty, " and isnull(CONVERT(VARCHAR(10),a.CreatedDate,101),'') = '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, str33), "'" };
                    stringBuilder2.Append(string.Concat(companyID));
                    SqlCommand sqlCommand = new SqlCommand(stringBuilder2.ToString(), sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    int num4 = 0;
                    if (!sqlDataReader.HasRows)
                    {
                        this.plhdetails.Controls.Clear();
                    }
                    string empty6 = string.Empty;
                    string empty7 = string.Empty;
                    string empty8 = string.Empty;
                    string empty9 = string.Empty;
                    string empty10 = string.Empty;
                    string empty11 = string.Empty;
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    string empty14 = string.Empty;
                    string empty15 = string.Empty;
                    string empty16 = string.Empty;
                    string empty17 = string.Empty;
                    string empty18 = string.Empty;
                    string empty19 = string.Empty;
                    string empty20 = string.Empty;
                    string empty21 = string.Empty;
                    string empty22 = string.Empty;
                    while (sqlDataReader.Read())
                    {
                        num3++;
                        num4++;
                        if (num4 % 2 != 0)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        }
                        else
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                        }
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CompanyName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ShippedTo"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["JobNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["JobTitle"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            try
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["JobValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            catch
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>&nbsp;</div></td>"));
                            }
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["JobContactName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader["JobDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Comments"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Status"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["RefNo"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CustomerOrderNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["GoodsDelivered"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Carrier"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ConsignmentNoteNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ConsigneeURL"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ActivityNotes"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Quantity"].ToString(), "</div></td>")));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Description"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CustomerCode"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (!this.chkColumns.Items[26].Selected)
                        {
                            continue;
                        }
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ItemNotes"].ToString(), "&nbsp;</div></td>")));
                         //-- new field added to del report
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLine1"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLine2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLine3"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLine4"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLine5"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactCustomField1"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactCustomField2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["JobQuantityOrdered"].ToString(), "&nbsp;</div></td>")));
                        //this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddressLabel"].ToString(), "&nbsp;</div></td>")));
                    }
                    sqlConnection.Close();
                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
                this.lblTotalRecords.Text = num3.ToString();
            }
            else if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "2")
            {
                int num5 = 0;
                this.btnExport.Visible = false;
                this.btnExportPPT.Visible = true;
                DataSet dataSet2 = new DataSet();
                companyID = new object[] { "select distinct (select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0) AS T FOR XML PATH('')),1,1,'') ) as JobNumber ", empty, " " };
                string str34 = string.Concat(companyID);
                (new SqlDataAdapter(str34, sqlConnection)).Fill(dataSet2);
                foreach (DataRow dataRow in dataSet2.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>"));
                    Label label1 = new Label();
                    string str35 = base.SpecialDecode(dataRow["JobNumber"].ToString());
                    dataRow["JobNumber"] = base.SpecialEncode(dataRow["JobNumber"].ToString());
                    if (str35 != "")
                    {
                        label1.Text = str35;
                    }
                    else
                    {
                        label1.Text = "Not Specified";
                    }
                    this.plhdetails.Controls.Add(label1);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100% class='callreport_grpby' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                    if (this.chkColumns.Items[0].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[1].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Shipped_To"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[2].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[3].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[4].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[5].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("New_job_Value"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[6].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[7].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Contact_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[8].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Created_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[9].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[10].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Date"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[11].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Delivery_Address"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[12].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Comments"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[13].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Status"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[14].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Ref_No"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[15].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Customer_Order_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[16].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Goods_Delivered"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[17].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Carrier"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[18].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Consignment_Note_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[19].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Consignee_url"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[20].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Activity_Notes"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[21].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Item_Title"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[22].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Quantity"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[23].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[24].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("p_Customer_code"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[25].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Job_Title1"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[26].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Job_Title2"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[27].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Item_Notes"), "</b>&nbsp;</div></td>")));
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    StringBuilder stringBuilder3 = new StringBuilder();
                    companyID = new object[] { "select distinct ", stringBuilder, " ", empty, " and (select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID='", this.CompanyID, "' and EstimateID=di.EstimateID and EstimateID !=0) AS T FOR XML PATH('')),1,1,'') ) = '", dataRow["JobNumber"].ToString().TrimStart(new char[0]).TrimEnd(new char[0]), "'" };
                    stringBuilder3.Append(string.Concat(companyID));
                    SqlCommand sqlCommand1 = new SqlCommand(stringBuilder3.ToString(), sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                    int num6 = 0;
                    if (!sqlDataReader1.HasRows)
                    {
                        this.plhdetails.Controls.Clear();
                    }
                    string empty23 = string.Empty;
                    string empty24 = string.Empty;
                    string empty25 = string.Empty;
                    string empty26 = string.Empty;
                    string empty27 = string.Empty;
                    string empty28 = string.Empty;
                    string empty29 = string.Empty;
                    string empty30 = string.Empty;
                    string empty31 = string.Empty;
                    string empty32 = string.Empty;
                    string empty33 = string.Empty;
                    string empty34 = string.Empty;
                    string empty35 = string.Empty;
                    string empty36 = string.Empty;
                    string str36 = string.Empty;
                    string empty37 = string.Empty;
                    string str37 = string.Empty;
                    while (sqlDataReader1.Read())
                    {
                        num5++;
                        num6++;
                        if (num6 % 2 != 0)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        }
                        else
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                        }
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["CompanyName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ShippedTo"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["JobNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["JobTitle"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            try
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["JobValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            catch
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>&nbsp;</div></td>"));
                            }
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["JobContactName"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader1["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader1["JobDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Comments"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Status"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["RefNo"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["CustomerOrderNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["GoodsDelivered"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Carrier"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ConsignmentNoteNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ConsigneeURL"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ActivityNotes"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Quantity"].ToString(), "</div></td>")));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Description"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["CustomerCode"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (!this.chkColumns.Items[26].Selected)
                        {
                            continue;
                        }
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ItemNotes"].ToString(), "&nbsp;</div></td>")));
                        //-- new field added to del report
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLine1"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLine2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLine3"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLine4"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLine5"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactCustomField1"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactCustomField2"].ToString(), "&nbsp;</div></td>")));
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["JobQuantityOrdered"].ToString(), "&nbsp;</div></td>")));
                        //this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddressLabel"].ToString(), "&nbsp;</div></td>")));
                    }
                    sqlConnection.Close();
                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
                this.lblTotalRecords.Text = num5.ToString();
            }
            if (this.ddlGrouprecords.SelectedIndex == 0)
            {
                foreach (DataRow row1 in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row1[0].ToString());
                }
            }
            return dataSet;
        }

        public void GetPageBind(int PageNumber)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            DataSet estimateData = this.GetEstimateData(PageNumber);
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.btnExportPPT.Visible = false;
                return;
            }
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            DataTable dt = SetDeliveryReportColumns(estimateData);
            this.GridEstReport.DataSource = dt;
            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            //this.usrPaging.Visible = true;
            this.usrPaging.Visible = false;
            pagingreport.intCurrentPage = PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        [WebMethod]
        public static string GetSupplierName(string val)
        {
            string[] strArrays = val.Split(new char[] { '&' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = companyBasePage.company_autocomplete(Convert.ToInt32(str), "Supplier", baseClass.ReplaceSingleQuote(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["ClientID"].ToString();
                empty1 = row["ClientName"].ToString();
                empty2 = row["Contacts"].ToString();
                str2 = row["CustomizedValue"].ToString();
                empty3 = companyBasePage.default_address_select(Convert.ToInt32(str), Convert.ToInt32(empty));
                string[] strArrays1 = new string[] { empty, "$", empty1, "$", empty2, "$", str2, "$", empty3, "µ" };
                empty4 = string.Concat(empty4, string.Concat(strArrays1));
            }
            return empty4;
        }

        protected void GridEstReport_DataBound(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected && (i == 0 || i == 1 || i == 2 || i == 3 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20))
                {
                    num++;
                }
            }
            this.GridEstReport.HeaderStyle.CssClass = "commonheaderstylereport11";
            //for (int j = 0; j < this.GridEstReport.Items.Count; j++)
            //{
            //    string text = this.GridEstReport.Items[j].Cells[0].Text;
            //    for (int k = j + 1; k < this.GridEstReport.Items.Count; k++)
            //    {
            //        if (string.Compare(text, this.GridEstReport.Items[k].Cells[0].Text, true) == 0)
            //        {
            //            for (int l = 1; l <= num; l++)
            //            {
            //                if (string.Compare(this.GridEstReport.Items[j].Cells[l].Text, this.GridEstReport.Items[k].Cells[l].Text, true) == 0)
            //                {
            //                    this.GridEstReport.Items[k].Cells[l].Text = string.Empty;
            //                }
            //            }
            //        }
            //    }
            //}
        }
        protected void GridDelivery_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (base.IsPostBack)
            {
                DataSet deliveryData = this.GetEstimateData(this.PageNumber);
                DataTable dt = SetDeliveryReportColumns(deliveryData);
                this.GridEstReport.DataSource = dt;
            }

        }
        protected void GridDelivery_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void GridDelivery_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageSize = e.NewPageSize;
        }
        private void GridEstReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                this.pnlGridview.Visible = true;
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    e.Row.Cells[0].Visible = false;
                    if (e.Row.Cells[i].Text.ToLower() == "companyname")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Company_Name");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "shippedto")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Shipped_To");
                        this.cellvalue_shippedto = i;
                        this.flag_shippedto = "true";
                        e.Row.Cells[this.cellvalue_shippedto].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliverynumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Number");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobnumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Number");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobtitle")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Title");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobvalue")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("New_job_Value"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.cellvalue_JobValue = i;
                        this.flag_JobValue = "true";
                        e.Row.Cells[i].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactname")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactjobtitle1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title1");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactjobtitle2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title2");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobcontactname")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Contact_Name");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Created_On");
                        this.cellvalue_createdOn = i;
                        this.flag_createdOn = "true";
                        e.Row.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliverydate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
                        this.cellvalue_deliveryDate = i;
                        this.flag_deliveryDate = "true";
                        e.Row.Cells[this.cellvalue_deliveryDate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobdate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Date");
                        this.cellvalue_jobDate = i;
                        this.flag_jobDate = "true";
                        e.Row.Cells[this.cellvalue_jobDate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliveryaddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "comments")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Comments");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "status")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Status");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "refno")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Ref_No");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customerordernumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Customer_Order_Number");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "goodsdelivered")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Goods_Delivered");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "carrier")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Carrier");
                        this.cellvalue_carrier = i;
                        this.flag_carrier = "true";
                        e.Row.Cells[this.cellvalue_carrier].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "consignmentnotenumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Consignment_Note_Number");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "consigneeurl")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Consignee_url");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "activitynotes")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Activity_Notes");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        this.cellvalue_ActivityNotes = i;
                        this.flag_ActivityNotes = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "itemtitle")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Item_Title");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        this.cellvalue_itemtitle = i;
                        this.flag_itemtitle = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "quantity")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Quantity");
                        this.cellvalue_quantity = i;
                        this.flag_quantity = "true";
                        e.Row.Cells[this.cellvalue_quantity].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "description")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Description");
                        this.cellvalue_description = i;
                        this.flag_description = "true";
                        e.Row.Cells[this.cellvalue_description].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "ItemNotes")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Item_Notes");
                        this.cellvalue_itemnotes = i;
                        this.flag_itemnotes = "true";
                        e.Row.Cells[this.cellvalue_itemnotes].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customercode")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("p_Customer_code");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }               
                    //-- new field added to del report
                    if (e.Row.Cells[i].Text.ToLower() == "DeliveryAddressLine1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line1");
                        this.cellvalue_deladdline1 = i;
                        this.flag_deladdline1 = "true";
                        e.Row.Cells[this.cellvalue_deladdline1].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "DeliveryAddressLine2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line2");
                        this.cellvalue_deladdline2 = i;
                        this.flag_deladdline2 = "true";
                        e.Row.Cells[this.cellvalue_deladdline2].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "DeliveryAddressLine3")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line3");
                        this.cellvalue_deladdline3 = i;
                        this.flag_deladdline3 = "true";
                        e.Row.Cells[this.cellvalue_deladdline3].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "DeliveryAddressLine4")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line4");
                        this.cellvalue_deladdline4 = i;
                        this.flag_deladdline4 = "true";
                        e.Row.Cells[this.cellvalue_deladdline4].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "DeliveryAddressLine5")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line5");
                        this.cellvalue_deladdline5 = i;
                        this.flag_deladdline5 = "true";
                        e.Row.Cells[this.cellvalue_deladdline5].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "ContactCustomField1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
                        this.cellvalue_contactcustomfield1 = i;
                        this.flag_contactcustomfield1 = "true";
                        e.Row.Cells[this.cellvalue_contactcustomfield1].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "ContactCustomField2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
                        this.cellvalue_contactcustomfield2 = i;
                        this.flag_contactcustomfield2 = "true";
                        e.Row.Cells[this.cellvalue_contactcustomfield2].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "JobQuantityOrdered")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Quantity_Ordered");
                        this.cellvalue_jobquantityordered = i;
                        this.flag_jobquantityordered = "true";
                        e.Row.Cells[this.cellvalue_jobquantityordered].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliveryaddresslabel")
                    {
                        e.Row.Cells[i].Text = "Delivery Address Label";
                        this.cellvalue_deladdlabel = i;
                        this.flag_deladdlabel = "true";
                        e.Row.Cells[this.cellvalue_deladdlabel].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate1")
                    {
                        e.Row.Cells[i].Text = "CustomDate1";
                        this.cellvalue_CustomDate1 = i;
                        this.flag_CustomDate1 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate1].Attributes.Add("align", "left");
                    }

                    if (e.Row.Cells[i].Text.ToLower() == "customdate2")
                    {
                        e.Row.Cells[i].Text = "CustomDate2";
                        this.cellvalue_CustomDate2 = i;
                        this.flag_CustomDate2 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate2].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate3")
                    {
                        e.Row.Cells[i].Text = "CustomDate3";
                        this.cellvalue_CustomDate3 = i;
                        this.flag_CustomDate3 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate3].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate4")
                    {
                        e.Row.Cells[i].Text = "CustomDate4";
                        this.cellvalue_CustomDate4 = i;
                        this.flag_CustomDate4 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate4].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate5")
                    {
                        e.Row.Cells[i].Text = "CustomDate5";
                        this.cellvalue_CustomDate5 = i;
                        this.flag_CustomDate5 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate5].Attributes.Add("align", "left");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.pnlGridview.Visible = true;
                e.Row.Cells[0].Visible = false;
                for (int j = 0; j < e.Row.Controls.Count; j++)
                {
                    string str = e.Row.Cells[this.cellvalue_ActivityNotes].Text.Replace("¶", "<br/>");
                    this.lblActivityNotes.Text = base.Server.HtmlDecode(str);
                    e.Row.Cells[this.cellvalue_ActivityNotes].Text = this.lblActivityNotes.Text;
                    string text = e.Row.Cells[this.cellvalue_itemtitle].Text;
                    this.lblItemTitle.Text = base.Server.HtmlDecode(base.SpecialDecode(text));
                    e.Row.Cells[this.cellvalue_itemtitle].Text = this.lblItemTitle.Text;
                    if (j == this.cellvalue_deliveryDate && this.flag_deliveryDate == "true")
                    {
                        e.Row.Cells[this.cellvalue_deliveryDate].Attributes.Add("align", "center");
                        e.Row.Cells[this.cellvalue_deliveryDate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_deliveryDate].Text, this.CompanyID, this.UserID, false), "</div>");
                    }
                    if (j == this.cellvalue_jobDate && this.flag_jobDate == "true")
                    {
                        e.Row.Cells[this.cellvalue_jobDate].Attributes.Add("align", "center");
                        e.Row.Cells[this.cellvalue_jobDate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_jobDate].Text, this.CompanyID, this.UserID, false), "</div>");
                    }
                    if (j == this.cellvalue_createdOn && this.flag_createdOn == "true")
                    {
                        e.Row.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                        e.Row.Cells[this.cellvalue_createdOn].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_createdOn].Text, this.CompanyID, this.UserID, false), "</div>");
                    }
                    if (this.flag_carrier == "true")
                    {
                        e.Row.Cells[this.cellvalue_carrier].Text = string.Concat("<div>", base.SpecialDecode(e.Row.Cells[this.cellvalue_carrier].Text), "</div>");
                    }
                    if (this.flag_quantity == "true")
                    {
                        e.Row.Cells[this.cellvalue_quantity].Attributes.Add("align", "right");
                        e.Row.Cells[this.cellvalue_quantity].Text = string.Concat("<div style='min-width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_quantity].Text), "</div>");
                    }
                    if (this.flag_description == "true")
                    {
                        string str1 = e.Row.Cells[this.cellvalue_description].Text.Replace("\n", "<br/>");
                        e.Row.Cells[this.cellvalue_description].Text = string.Concat("<div>", base.SpecialDecode(base.Server.HtmlDecode(str1)), "</div>");
                    }
                    if (this.flag_shippedto == "true")
                    {
                        e.Row.Cells[this.cellvalue_shippedto].Text = string.Concat("<div style='min-width: 100px;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_shippedto].Text), "</div>");
                    }
                    if (this.flag_JobValue == "true")
                    {
                        try
                        {
                            e.Row.Cells[this.cellvalue_JobValue].Attributes.Add("align", "right");
                            e.Row.Cells[this.cellvalue_JobValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_JobValue].Text), 0, "", false, false, true);
                        }
                        catch
                        {
                            e.Row.Cells[this.cellvalue_JobValue].Text = "";
                        }
                    }
                }
                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", base.SpecialDecode(e.Row.Cells[k].Text), "</div></div>");
                }
            }
        }

        public string HalfFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            int month = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToString());
            int num = dateTime.Month;
            DateTime dateTime3 = dateTime.AddMonths(5);
            int month1 = dateTime3.Month;
            int year = 0;
            int num1 = 0;
            int month2 = dateTime.Month;
            int num2 = dateTime2.Month;
            int month3 = dateTime3.Month;
            if (num <= 7)
            {
                num1 = DateTime.DaysInMonth(dateTime.Year, month1);
            }
            else
            {
                year = dateTime.AddYears(1).Year;
                num1 = DateTime.DaysInMonth(year, month1);
            }
            if (num2 <= month1 || dateTime2.Year != dateTime3.Year)
            {
                dateTimeArray[0] = new DateTime(dateTime.Year, num, 1);
                dateTimeArray[1] = new DateTime(dateTime3.Year, month1, num1);
            }
            else
            {
                dateTimeArray[0] = new DateTime(dateTime3.Year, month1 + 1, 1);
                dateTimeArray[1] = dateTime1;
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string LastQuarter()
        {
            SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime.Month;
            int num = (new DateTime()).Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (month == 1 || month == 2 || month == 3)
            {
                int month1 = dateTime.Month;
                if (month1 == 1)
                {
                    month1 = month1 + 9;
                    int num1 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year - 1, num1, 31);
                }
                else if (month1 == 2)
                {
                    month1 = month1 + 8;
                    int num2 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year - 1, num2, 31);
                }
                else if (month1 == 3)
                {
                    month1 = month1 + 7;
                    int num3 = month1 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year - 1, num3, 31);
                }
            }
            else if (month == 4 || month == 5 || month == 6)
            {
                int month2 = dateTime.Month;
                if (month2 == 4)
                {
                    month2 = month2 - 3;
                    int num4 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num4, 31);
                }
                else if (month2 == 5)
                {
                    month2 = month2 - 4;
                    int num5 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num5, 31);
                }
                else if (month2 == 6)
                {
                    month2 = month2 - 5;
                    int num6 = month2 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num6, 31);
                }
            }
            else if (month == 7 || month == 8 || month == 9)
            {
                int month3 = dateTime.Month;
                if (month3 == 7)
                {
                    month3 = month3 - 3;
                    int num7 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num7, 30);
                }
                else if (month3 == 8)
                {
                    month3 = month3 - 4;
                    int num8 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num8, 30);
                }
                else if (month3 == 9)
                {
                    month3 = month3 - 5;
                    int num9 = month3 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num9, 30);
                }
            }
            else if (month == 10 || month == 11 || month == 12)
            {
                int month4 = dateTime.Month;
                if (month4 == 10)
                {
                    month4 = month4 - 3;
                    int num10 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num10, 30);
                }
                if (month4 == 11)
                {
                    month4 = month4 - 4;
                    int num11 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num11, 30);
                }
                else if (month4 == 12)
                {
                    month4 = month4 - 5;
                    int num12 = month4 + 2;
                    dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                    dateTimeArray[1] = new DateTime(dateTime.Year, num12, 30);
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Reports("delivery notes", "showreport", "");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("delivery notes", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            if (baseClass.ReturnRoles_Privileges_ReportStatus("delivery notes", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.pg = "deliverynote";
            if (base.Request.Params["pg"] == null)
            {
                this.pagename = "deliverynote";
            }
            else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
            {
                this.pagename = "Report";
            }
            global.pageName = this.pagename;
            global.pgName = "";
            this.gloobj.setpagename(this.pagename);
            base.Title = (new languageClass()).convert(global.pageTitle(this.objLangClass.GetLanguageConversion("DeliveryNote_Report") ?? "", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (this.pagename.ToString().ToLower().Trim() != "report")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../delivery/delivery_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Delivery_Note_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Delivery_Note_Report")));
            }
            else
            {
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Delivery_Note_Report")));
            }
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
        
            this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("select CompanyName from tb_Company where CompanyID=", this.CompanyID, " and isdelete=0"), sqlConnection);
            this.CompanyName = (string)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            DateTime dateTime = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            commonClass _commonClass1 = this.objJava;
            DateTime now1 = DateTime.Now;
            string str = _commonClass1.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
            char[] chrArray = new char[] { ' ' };
            this.day = str.Split(chrArray);
            this.spn_daily.InnerText = string.Concat("(", this.day[0].ToString(), ")");
            this.spnjob_t.InnerText = string.Concat("(", this.day[0].ToString(), ")");
            commonClass _commonClass2 = this.objJava;
            string str1 = dateTime.AddDays(-1).ToString();
            char[] chrArray1 = new char[] { ' ' };
            string str2 = _commonClass2.Eprint_return_Date_Before_View(str1.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray2 = new char[] { ' ' };
            this.yestday = str2.Split(chrArray2);
            this.spn_yest.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
            this.spnjob_y.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime3 = dateTime2.AddMonths(1).AddDays(-1);
            string str3 = this.objJava.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray3 = new char[] { ' ' };
            this.stdate = str3.Split(chrArray3);
            string str4 = this.objJava.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray4 = new char[] { ' ' };
            this.endate = str4.Split(chrArray4);
            HtmlGenericControl spnMonth = this.spn_month;
            string[] strArrays = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
            spnMonth.InnerText = string.Concat(strArrays);
            HtmlGenericControl spnjobM = this.spnjob_m;
            string[] strArrays1 = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
            spnjobM.InnerText = string.Concat(strArrays1);
            try
            {
                string[] strArrays2 = this.CurrentQuater().Split(new char[] { ',' });
                string str5 = this.objJava.Eprint_return_Date_Before_View(strArrays2[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray5 = new char[] { ' ' };
                this.stquardate = str5.Split(chrArray5);
                string str6 = this.objJava.Eprint_return_Date_Before_View(strArrays2[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray6 = new char[] { ' ' };
                this.enquardate = str6.Split(chrArray6);
                HtmlGenericControl spnQuarter = this.spn_quarter;
                string[] strArrays3 = new string[] { "(", this.stquardate[0].ToString(), " to ", this.enquardate[0].ToString(), ")" };
                spnQuarter.InnerText = string.Concat(strArrays3);
                HtmlGenericControl spnjobCq = this.spnjob_cq;
                string[] strArrays4 = new string[] { "(", this.stquardate[0].ToString(), " to ", this.enquardate[0].ToString(), ")" };
                spnjobCq.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            try
            {
                string[] strArrays5 = this.LastQuarter().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastquardate = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays5[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastquardate = str8.Split(chrArray8);
                HtmlGenericControl spnLastque = this.spn_lastque;
                string[] strArrays6 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnLastque.InnerText = string.Concat(strArrays6);
                HtmlGenericControl spnjobLq = this.spnjob_lq;
                string[] strArrays7 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnjobLq.InnerText = string.Concat(strArrays7);
            }
            catch
            {
            }

            HtmlGenericControl spn_ddlJobdate_annualYear1 = this.spn_ddlJobdate_annualYear;
            string[] strArrays777 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                            ,
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                               ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" };
            spn_ddlJobdate_annualYear1.InnerText = string.Concat(strArrays777);

            HtmlGenericControl spn_rdlDate_AnnualYear1 = this.spn_rdlDate_AnnualYear;
            string[] strArrays888 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat)
                        , this.CompanyID, this.UserID, false)
                            ,
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                              ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" };
            spn_rdlDate_AnnualYear1.InnerText = string.Concat(strArrays888);

            try
            {
                string[] strArrays3 = this.Lastweek().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastweek = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastweek = str8.Split(chrArray8);
                HtmlGenericControl spnLastweek = this.spn_lastweek;
                string[] strArrays4 = new string[] { "(", this.stlastweek[0].ToString(), " to ", this.enlastweek[0].ToString(), ")" };
                spnLastweek.InnerText = string.Concat(strArrays4);

                HtmlGenericControl spnLastweek_t = this.spn_lastweek_t;
                strArrays4 = new string[] { "(", this.stlastweek[0].ToString(), " to ", this.enlastweek[0].ToString(), ")" };
                spnLastweek_t.InnerText = string.Concat(strArrays4);


            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastmonth().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastmonth = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastmonth = str8.Split(chrArray8);
                HtmlGenericControl spnLastmonth = this.spn_lastmonth;
                string[] strArrays4 = new string[] { "(", this.stlastmonth[0].ToString(), " to ", this.enlastmonth[0].ToString(), ")" };
                spnLastmonth.InnerText = string.Concat(strArrays4);

                HtmlGenericControl spnLastmonth_t = this.spn_lastmonth_t;
                strArrays4 = new string[] { "(", this.stlastmonth[0].ToString(), " to ", this.enlastmonth[0].ToString(), ")" };
                spnLastmonth_t.InnerText = string.Concat(strArrays4);


            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastyear().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastyear = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastyear = str8.Split(chrArray8);
                HtmlGenericControl spnLastyear = this.spn_lastyear;
                string[] strArrays4 = new string[] { "(", this.stlastyear[0].ToString(), " to ", this.enlastyear[0].ToString(), ")" };
                spnLastyear.InnerText = string.Concat(strArrays4);


                HtmlGenericControl spnLastyear_t = this.spn_lastyear_t;
                strArrays4 = new string[] { "(", this.stlastyear[0].ToString(), " to ", this.enlastyear[0].ToString(), ")" };
                spnLastyear_t.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            string[] strArrays8 = this.HalfFiscalYear().Split(new char[] { ',' });
            string str9 = this.objJava.Eprint_return_Date_Before_View(strArrays8[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray9 = new char[] { ' ' };
            this.from_halffiscalyear = str9.Split(chrArray9);
            string str10 = this.objJava.Eprint_return_Date_Before_View(strArrays8[1].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray10 = new char[] { ' ' };
            this.to_halffiscalyear = str10.Split(chrArray10);
            HtmlGenericControl spanHalfyear = this.span_halfyear;
            string[] strArrays9 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
            spanHalfyear.InnerText = string.Concat(strArrays9);
            HtmlGenericControl spnjobHy = this.spnjob_hy;
            string[] strArrays10 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
            spnjobHy.InnerText = string.Concat(strArrays10);
            this.year = dateTime.Year.ToString();
            this.spn_year.InnerText = string.Concat("(", this.year, ")");
            this.spnjob_year.InnerText = string.Concat("(", this.year, ")");
            this.txtName.Attributes.Add("autocomplete", "off");
            if (!base.IsPostBack)
            {
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_Listbox(this.lstStatus, this.CompanyID, "--- Any ---", "delivery");
                this.pnlDateOption_Disable.Visible = true;
                this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox = this.txtFrom;
                commonClass _commonClass3 = this.objJava;
                DateTime now2 = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
                this.txtjobFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox1 = this.txtjobFrom;
                commonClass _commonClass4 = this.objJava;
                DateTime now3 = DateTime.Now;
                textBox1.Text = _commonClass4.Eprint_return_Date_Before_View(now3.ToString(), this.CompanyID, this.UserID, true);
                this.txtTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox2 = this.txtTo;
                commonClass _commonClass5 = this.objJava;
                DateTime now4 = DateTime.Now;
                textBox2.Text = _commonClass5.Eprint_return_Date_Before_View(now4.ToString(), this.CompanyID, this.UserID, true);
                this.txtJobTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox3 = this.txtJobTo;
                commonClass _commonClass6 = this.objJava;
                DateTime dateTime4 = DateTime.Now;
                textBox3.Text = _commonClass6.Eprint_return_Date_Before_View(dateTime4.ToString(), this.CompanyID, this.UserID, true);
            }
            if (!base.IsPostBack)
            {
                this.usrPaging.Visible = false;
                if (CheckXeroTracking())
                {
                    divLocation.Visible = true;
                    DataTable dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                    DataRow toInsert = dataTableOptions.NewRow();
                    toInsert[0] = 0;
                    toInsert[1] = "Select Location";
                    dataTableOptions.Rows.InsertAt(toInsert, 0);
                    this.ddlLocation.DataSource = dataTableOptions;
                    this.ddlLocation.DataTextField = "TrackingOPtion";
                    this.ddlLocation.DataValueField = "Id";
                    this.ddlLocation.DataBind();
                    //ddlLocation.Items.Insert(0, new ListItem("Select Location", "0"));
                }
            }
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            if (!base.IsPostBack)
            {
                this.Session["DeleteMsg"] = null;
                this.Session["SaveAsNew"] = null;
                this.pnlReports.Visible = true;

                this.BindEstimatorDropDown();
                this.BindSalesPersonDropDown();
                this.BindCustomerSalesPersonDropDown();

            }
            delivery_report.divVisibility = "none";
            delivery_report.imgVisibility = "block";
            this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
            this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
            this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
            this.usrReportsave.OnPageIndexChanged += new OnPageIndexChangedClick(this.usrReportsave_OnPageIndexChanged);
            this.usrReportsave.OnPageSizeChanged += new OnPageSizeChangedClick(this.usrReportsave_OnPageSizeChanged);
            this.chkDateOption.Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            this.chkJobDate.Text = this.objLangClass.GetLanguageConversion("Job_Date");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
            this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
            this.btnfilter.ToolTip = this.objLangClass.GetLanguageConversion("Back_To_Search_Option");
            this.btnExport.ToolTip = this.objLangClass.GetLanguageConversion("Export");
            this.btngo.ToolTip = this.objLangClass.GetLanguageConversion("GoTo");
            this.RadPanelBar1.Items[0].Text = this.objLangClass.GetLanguageConversion("Select_Columns_To_Run_Report");
            this.RadPanelBar1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sort_The_Records");
            this.RadPanelBar1.Items[2].Text = this.objLangClass.GetLanguageConversion("Report_Filters");
            this.RadPanelBar1.Items[3].Text = this.objLangClass.GetLanguageConversion("Save_Report_Options");
            this.rdlDate.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
            this.rdlDate.Items[1].Text = this.objLangClass.GetLanguageConversion("Yesterday");
            this.rdlDate.Items[2].Text = this.objLangClass.GetLanguageConversion("Current_Month");
            this.rdlDate.Items[3].Text = this.objLangClass.GetLanguageConversion("Current_Quarter");
            this.rdlDate.Items[4].Text = ePrintConstants.CurrentYearText;
            this.rdlDate.Items[5].Text = this.objLangClass.GetLanguageConversion("Last_Quarter");
            this.rdlDate.Items[6].Text = this.objLangClass.GetLanguageConversion("Current_Year_Fiscal");
            this.rdlDate.Items[7].Text = this.objLangClass.GetLanguageConversion("Half_Fiscal_year");
            this.rdlDate.Items[8].Text = this.objLangClass.GetLanguageConversion("Till_Date");
            this.rdlDate.Items[9].Text = this.objLangClass.GetLanguageConversion("Select_Date");
            this.ddldirection.Items[0].Text = this.objLangClass.GetLanguageConversion("Ascending");
            this.ddldirection.Items[1].Text = this.objLangClass.GetLanguageConversion("Descending");
            this.ddlSortBy.Items[0].Text = this.objLangClass.GetLanguageConversion("None");
            this.chkColumns.Items[0].Text = this.objLangClass.GetLanguageConversion("Company_Name");
            this.chkColumns.Items[1].Text = this.objLangClass.GetLanguageConversion("Shipped_To");
            this.chkColumns.Items[2].Text = this.objLangClass.GetLanguageConversion("Delivery_Number");
            this.chkColumns.Items[3].Text = this.objLangClass.GetLanguageConversion("Job_Number");
            this.chkColumns.Items[4].Text = this.objLangClass.GetLanguageConversion("Job_Title");
            this.chkColumns.Items[5].Text = string.Concat(this.objLangClass.GetLanguageConversion("New_job_Value"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.chkColumns.Items[6].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
            this.chkColumns.Items[7].Text = this.objLangClass.GetLanguageConversion("Job_Contact_Name");
            this.chkColumns.Items[8].Text = this.objLangClass.GetLanguageConversion("Created_Date");
            this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Job_Date");
            this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Delivery_Address");
            this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Comments");
            this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Status");
            this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Ref_No");
            this.chkColumns.Items[15].Text = this.objLangClass.GetLanguageConversion("Customer_Order_Number");
            this.chkColumns.Items[16].Text = this.objLangClass.GetLanguageConversion("Goods_Delivered");
            this.chkColumns.Items[17].Text = this.objLangClass.GetLanguageConversion("Carrier");
            this.chkColumns.Items[18].Text = this.objLangClass.GetLanguageConversion("Consignment_Note_Number");
            this.chkColumns.Items[19].Text = this.objLangClass.GetLanguageConversion("Consignee_url");
            this.chkColumns.Items[20].Text = this.objLangClass.GetLanguageConversion("Activity_Notes");
            this.chkColumns.Items[21].Text = this.objLangClass.GetLanguageConversion("Item_Title");
            this.chkColumns.Items[22].Text = this.objLangClass.GetLanguageConversion("Quantity");
            this.chkColumns.Items[23].Text = this.objLangClass.GetLanguageConversion("Description");
            this.chkColumns.Items[24].Text = this.objLangClass.GetLanguageConversion("p_Customer_code");
            this.chkColumns.Items[25].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title1");
            this.chkColumns.Items[26].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title2");
            this.chkColumns.Items[27].Text = this.objLangClass.GetLanguageConversion("Item_Notes");       
            //-- new field added to del report
            this.chkColumns.Items[28].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line1");
            this.chkColumns.Items[29].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line2");
            this.chkColumns.Items[30].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line3");
            this.chkColumns.Items[31].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line4");
            this.chkColumns.Items[32].Text = this.objLangClass.GetLanguageConversion("Delivery_Address_Line5");
            this.chkColumns.Items[33].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
            this.chkColumns.Items[34].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
            this.chkColumns.Items[35].Text = this.objLangClass.GetLanguageConversion("Job_Quantity_Ordered");
            this.chkColumns.Items[36].Text = "Delivery Address Label";
            //foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            //{
            //    customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
            //    customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
            //    customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
            //    customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
            //    customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            //}
            //this.chkColumns.Items[37].Text = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
            //this.chkColumns.Items[38].Text = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
            //this.chkColumns.Items[39].Text = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
            //this.chkColumns.Items[40].Text = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
            //this.chkColumns.Items[41].Text = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;


            this.chkfreetext.Items[0].Text = this.objLangClass.GetLanguageConversion("Customer_Name");
            this.chkfreetext.Items[1].Text = this.objLangClass.GetLanguageConversion("Shipped_To");
            this.chkfreetext.Items[2].Text = this.objLangClass.GetLanguageConversion("Delivery_Number");
            this.chkfreetext.Items[3].Text = this.objLangClass.GetLanguageConversion("Job_Number");
            this.chkfreetext.Items[4].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
            this.chkfreetext.Items[5].Text = this.objLangClass.GetLanguageConversion("Job_Contact_Name");
            this.chkfreetext.Items[6].Text = this.objLangClass.GetLanguageConversion("Status");
            this.chkfreetext.Items[7].Text = this.objLangClass.GetLanguageConversion("Ref_No");
            this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            AttributeCollection attributes = this.chkColumns.Items[9].Attributes;
            string[] text = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[9].Text, "','", this.chkColumns.Items[9].Value, "','9')" };
            attributes.Add("onclick", string.Concat(text));
            AttributeCollection attributeCollection = this.chkColumns.Items[2].Attributes;
            string[] text1 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[2].Text, "','", this.chkColumns.Items[2].Value, "','2')" };
            attributeCollection.Add("onclick", string.Concat(text1));
            AttributeCollection attributes1 = this.chkColumns.Items[8].Attributes;
            string[] text2 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[8].Text, "','", this.chkColumns.Items[8].Value, "','8')" };
            attributes1.Add("onclick", string.Concat(text2));
            AttributeCollection attributeCollection1 = this.chkColumns.Items[17].Attributes;
            string[] text3 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[17].Text, "','", this.chkColumns.Items[17].Value, "','17')" };
            attributeCollection1.Add("onclick", string.Concat(text3));
            AttributeCollection attributes2 = this.chkColumns.Items[1].Attributes;
            string[] text4 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[1].Text, "','", this.chkColumns.Items[1].Value, "','1')" };
            attributes2.Add("onclick", string.Concat(text4));
            AttributeCollection attributeCollection2 = this.chkColumns.Items[7].Attributes;
            string[] text5 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[7].Text, "','", this.chkColumns.Items[7].Value, "','7')" };
            attributeCollection2.Add("onclick", string.Concat(text5));
            this.ddlSortBy.Attributes.Add("onchange", "javascript:ddlsortByOnchange();");
        }



        public string Lastweek()
        {
            DateTime today = DateTime.Today;
            DayOfWeek currentDayOfWeek = today.DayOfWeek;

            // Calculate the start date of last week
            DateTime lastWeekStartDate = today.AddDays(-(int)currentDayOfWeek - 6);

            // Calculate the end date of last week
            DateTime lastWeekEndDate = lastWeekStartDate.AddDays(6);

            return lastWeekStartDate.ToString() + "," + lastWeekEndDate.ToString();
        }
        public string Lastmonth()
        {
            DateTime today = DateTime.Today;

            // Get the first day of the current month
            DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);

            // Get the last day of the previous month
            DateTime lastDayOfLastMonth = firstDayOfThisMonth.AddDays(-1);

            // Get the first day of the previous month
            DateTime firstDayOfLastMonth = new DateTime(lastDayOfLastMonth.Year, lastDayOfLastMonth.Month, 1);



            return firstDayOfLastMonth.ToString() + "," + lastDayOfLastMonth.ToString();
        }
        public string Lastyear()
        {
            DateTime currentDate = DateTime.Today;

            // Get start date of last year
            DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);

            // Get end date of last year
            DateTime lastYearEndDate = new DateTime(currentDate.Year - 1, 12, 31);


            return lastYearStartDate.ToString() + "," + lastYearEndDate.ToString();
        }
        bool CheckXeroTracking()
        {
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Xero_Tracking_Select")
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
            return true;
            return (bool)sqlCommand.ExecuteScalar();
        }

        private void paging_OnPageChange(int PageNumber1)
        {
            //if (PageNumber1 <= 0)
            //{
            //    this.GridEstReport.PageIndex = PageNumber1;
            //}
            //else
            //{
            //    this.GridEstReport.PageIndex = PageNumber1 - 1;
            //}
            this.GetPageBind(PageNumber1);
            delivery_report.imgVisibility = "none";
            delivery_report.divVisibility = "none";
            this.GridEstReport.DataBind();
        }

        private void ReportDetails(int ReportID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                this.chkColumns.Items[i].Selected = false;
            }
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_GetReport_Details", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            this.objJava.closeConnection();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["Columns"].ToString();
                row["Status"].ToString();
                string[] strArrays = empty.Split(new char[] { 'µ' });
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    if (strArrays[j].Trim() == "CompanyName")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ShippedTo")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryNumber")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobNumber")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobTitle")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobValue")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ContactName")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobContactName")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "CreatedDate")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryDate")
                    {
                        this.chkColumns.Items[9].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobDate")
                    {
                        this.chkColumns.Items[10].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddress")
                    {
                        this.chkColumns.Items[11].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "Comments")
                    {
                        this.chkColumns.Items[12].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "Status")
                    {
                        this.chkColumns.Items[13].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "RefNo")
                    {
                        this.chkColumns.Items[14].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "CustomerOrderNumber")
                    {
                        this.chkColumns.Items[15].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "GoodsDelivered")
                    {
                        this.chkColumns.Items[16].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "Carrier")
                    {
                        this.chkColumns.Items[17].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ConsignmentNoteNumber")
                    {
                        this.chkColumns.Items[18].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ConsigneeURL")
                    {
                        this.chkColumns.Items[19].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ActivityNotes")
                    {
                        this.chkColumns.Items[20].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ItemTitle")
                    {
                        this.chkColumns.Items[21].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "Quantity")
                    {
                        this.chkColumns.Items[22].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "Description")
                    {
                        this.chkColumns.Items[23].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "CustomerCode")
                    {
                        this.chkColumns.Items[24].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ContactJobTitle1")
                    {
                        this.chkColumns.Items[25].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ContactJobTitle2")
                    {
                        this.chkColumns.Items[26].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ItemNotes")
                    {
                        this.chkColumns.Items[27].Selected = true;
                    }
                    //-- new field added to del report
                    else if (strArrays[j].Trim() == "DeliveryAddressLine1")
                    {
                        this.chkColumns.Items[28].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddressLine2")
                    {
                        this.chkColumns.Items[29].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddressLine3")
                    {
                        this.chkColumns.Items[30].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddressLine4")
                    {
                        this.chkColumns.Items[31].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddressLine5")
                    {
                        this.chkColumns.Items[32].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ContactCustomField1")
                    {
                        this.chkColumns.Items[33].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "ContactCustomField2")
                    {
                        this.chkColumns.Items[34].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "JobQuantityOrdered")
                    {
                        this.chkColumns.Items[35].Selected = true;
                    }
                    else if (strArrays[j].Trim() == "DeliveryAddressLabel")
                    {
                        this.chkColumns.Items[36].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate1")
                    {
                        this.chkColumns.Items[37].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate2")
                    {
                        this.chkColumns.Items[38].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate3")
                    {
                        this.chkColumns.Items[39].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate14")
                    {
                        this.chkColumns.Items[40].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate5")
                    {
                        this.chkColumns.Items[41].Selected = true;
                    }

                    else if (strArrays[j] == "DESC")
                    {
                        this.ddldirection.SelectedValue = "DESC";
                        this.HdnSortBy.Value = strArrays[j - 1];
                    }
                    else if (strArrays[j] == "ASC")
                    {
                        this.ddldirection.SelectedValue = "ASC";
                        this.HdnSortBy.Value = strArrays[j - 1];
                    }
                }
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = base.SpecialDecode(row["ReportName"].ToString());
                }
                if (row["Description"].ToString() != "")
                {
                    this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                }
                if (row["CompanyName"].ToString() != "")
                {
                    this.txtName.Text = row["CompanyName"].ToString();
                }
                if (row["customerID"].ToString() != "")
                {
                    this.hid_ClientID.Value = row["customerID"].ToString();
                }
                if (row["SearchKeyword"].ToString() != "")
                {
                    this.txtFreetext.Text = row["SearchKeyword"].ToString();
                }
                if (CheckXeroTracking() && row["TrackingLocation"].ToString() != "")
                {
                    this.ddlLocation.SelectedValue = ddlLocation.Items.FindByText(row["TrackingLocation"].ToString()).Value;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(row["SalesPersonId"])) && row["SalesPersonId"].ToString().Trim() != "0")
                {
                    this.ddlSalesPerson.SelectedValue = row["SalesPersonId"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(row["EstimatorId"])) && row["EstimatorId"].ToString().Trim() != "0")
                {
                    this.ddlEstimator.SelectedValue = row["EstimatorId"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(row["CustomerSalesPersonId"])) && row["CustomerSalesPersonId"].ToString().Trim() != "0")
                {
                    this.ddlCustomerSalesPerson.SelectedValue = row["CustomerSalesPersonId"].ToString();
                }

                empty1 = row["SelectedSearchText"].ToString();
                string[] strArrays1 = empty1.Split(new char[] { 'µ' });
                this.chkfreetext.Items[0].Selected = false;
                this.chkfreetext.Items[1].Selected = false;
                this.chkfreetext.Items[2].Selected = false;
                this.chkfreetext.Items[3].Selected = false;
                this.chkfreetext.Items[4].Selected = false;
                this.chkfreetext.Items[5].Selected = false;
                this.chkfreetext.Items[6].Selected = false;
                this.chkfreetext.Items[7].Selected = false;
                for (int k = 0; k < (int)strArrays1.Length; k++)
                {
                    if (strArrays1[k] == "CustomerName")
                    {
                        this.chkfreetext.Items[0].Selected = true;
                    }
                    if (strArrays1[k] == "ShippedTo")
                    {
                        this.chkfreetext.Items[1].Selected = true;
                    }
                    if (strArrays1[k] == "DeliveryNumber")
                    {
                        this.chkfreetext.Items[2].Selected = true;
                    }
                    if (strArrays1[k] == "JobNumber")
                    {
                        this.chkfreetext.Items[3].Selected = true;
                    }
                    if (strArrays1[k] == "ContactName")
                    {
                        this.chkfreetext.Items[4].Selected = true;
                    }
                    if (strArrays1[k] == "JobContactName")
                    {
                        this.chkfreetext.Items[5].Selected = true;
                    }
                    if (strArrays1[k] == "Status")
                    {
                        this.chkfreetext.Items[6].Selected = true;
                    }
                    if (strArrays1[k] == "RefNo")
                    {
                        this.chkfreetext.Items[7].Selected = true;
                    }
                }
                if (row["NotesType"].ToString() != "0")
                {
                    base.SetDDLValue(this.ddlNotesType, row["NotesType"].ToString());
                }
                if (Convert.ToInt32(row["GroupedBy"]) != 0)
                {
                    base.SetDDLValue(this.ddlGrouprecords, row["GroupedBy"].ToString());
                }
                if (Convert.ToInt32(row["IsCreatedDate"]) != 1)
                {
                    this.chkDateOption.Checked = false;
                }
                else
                {
                    this.chkDateOption.Checked = true;
                    if (row["CreatedDateType"].ToString().Trim() == "t")
                    {
                        this.rdlDate.SelectedValue = "daily";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "y")
                    {
                        this.rdlDate.SelectedValue = "yesterday";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cm")
                    {
                        this.rdlDate.SelectedValue = "thismonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cq")
                    {
                        this.rdlDate.SelectedValue = "thisquarter";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ay")
                    {
                        this.rdlDate.SelectedValue = ePrintConstants.ThisAnnualYear;
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lq")
                    {
                        this.rdlDate.SelectedValue = "lastquater";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cy")
                    {
                        this.rdlDate.SelectedValue = "thisyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "hy")
                    {
                        this.rdlDate.SelectedValue = "halfyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "td")
                    {
                        this.rdlDate.SelectedValue = "tilldate";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lw")
                    {
                        this.rdlDate.SelectedValue = "lastweek";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lm")
                    {
                        this.rdlDate.SelectedValue = "lastmonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ly")
                    {
                        this.rdlDate.SelectedValue = "lastyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "dr")
                    {
                        this.rdlDate.SelectedValue = "daterange";
                        this.txtFrom.Enabled = true;
                        this.txtTo.Enabled = true;
                        this.txtFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtTo.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                }
                if (Convert.ToInt32(row["IsJobDate"]) != 1)
                {
                    this.chkJobDate.Checked = false;
                }
                else
                {
                    this.chkJobDate.Checked = true;
                    this.ddlJobdate.Enabled = true;
                    if (row["JobDateType"].ToString().Trim() == "t")
                    {
                        this.ddlJobdate.SelectedValue = "daily";
                        this.spnjob_t.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "y")
                    {
                        this.ddlJobdate.SelectedValue = "yesterday";
                        this.spnjob_y.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "cm")
                    {
                        this.ddlJobdate.SelectedValue = "thismonth";
                        this.spnjob_m.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "cq")
                    {
                        this.ddlJobdate.SelectedValue = "thisquarter";
                        this.spnjob_cq.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "ay")
                    {
                        this.ddlJobdate.SelectedValue = ePrintConstants.ThisAnnualYear;
                        this.spn_ddlJobdate_annualYear.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "lq")
                    {
                        this.ddlJobdate.SelectedValue = "lastquater";
                        this.spnjob_lq.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "cy")
                    {
                        this.ddlJobdate.SelectedValue = "thisyear";
                        this.spnjob_year.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "hy")
                    {
                        this.ddlJobdate.SelectedValue = "halfyear";
                        this.spnjob_hy.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "lw")
                    {
                        this.ddlJobdate.SelectedValue = "lastweek";
                        this.spn_lastweek_t.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "lm")
                    {
                        this.ddlJobdate.SelectedValue = "lastmonth";
                        this.spn_lastmonth_t.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() == "ly")
                    {
                        this.ddlJobdate.SelectedValue = "lastyear";
                        this.spn_lastyear_t.Style.Add("display", "block");
                    }
                    else if (row["JobDateType"].ToString().Trim() != "td")
                    {
                        if (row["JobDateType"].ToString().Trim() != "dr")
                        {
                            continue;
                        }
                        this.ddlJobdate.SelectedValue = "daterange";
                        this.txtjobFrom.Enabled = true;
                        this.txtJobTo.Enabled = true;
                        this.txtjobFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["JobDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtJobTo.Text = this.objJava.Eprint_return_Date_Before_View(row["JobDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.ddlJobdate.SelectedValue = "tilldate";
                    }
                }
            }
        }

        private void RunReportOnClick()
        {
            this.btnUpdateExisting.Visible = true;
            this.btnRunReport.Visible = true;
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.btnSaveRun.Text = "Save as new";
            int num = 0;
            this.divtab.Visible = false;
            delivery_report.imgVisibility = "none";
            delivery_report.divVisibility = "none";
            this.btnfilter.Visible = true;
            if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("delivery notes", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.divtoolbar.Visible = true;
            this.txt1.Visible = true;
            this.btngo.Visible = true;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.divtoolbar.Visible = true;
            }
            else
            {
                DataSet estimateData = this.GetEstimateData(1);
                this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                if (estimateData.Tables[0].Rows.Count == 0)
                {
                    this.pnlEmptyRecords.Visible = true;
                    this.GridEstReport.Visible = false;
                    this.btnExport.Visible = false;
                    this.divtoolbar.Visible = true;
                    this.txt1.Visible = false;
                    this.btngo.Visible = false;
                    this.btnExportPPT.Visible = false;
                    return;
                }
                if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
                {
                    this.GridEstReport.Visible = true;
                    this.div_Total.Visible = false;
                    this.pnlEmptyRecords.Visible = false;
                    DataTable dt = SetDeliveryReportColumns(estimateData);
                    this.GridEstReport.DataSource = dt;
                    //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                    this.GridEstReport.DataBind();
                    //this.usrPaging.Visible = true;
                    this.usrPaging.Visible = false;
                    pagingreport.intCurrentPage = this.PageNumber;
                    pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                    this.usrPaging.CreatePaging();
                    //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                    this.CallPagingBtn_ScrollGrid(this.usrPaging);
                    if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                    {
                        this.btnExport.Visible = false;
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        return;
                    }
                }
                else
                {
                    this.txt1.Visible = false;
                    this.btngo.Visible = false;
                    ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                    ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                    this.GridEstReport.Visible = true;
                    this.div_Total.Visible = false;
                    this.pnlEmptyRecords.Visible = false;
                    DataTable dt = SetDeliveryReportColumns(estimateData);
                    this.GridEstReport.DataSource = dt;
                    //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                    this.GridEstReport.DataBind();
                    //this.usrPaging.Visible = true;
                    this.usrPaging.Visible = false;
                    pagingreport.intCurrentPage = this.PageNumber;
                    pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                    this.usrPaging.CreatePaging();
                    //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                    this.CallPagingBtn_ScrollGrid(this.usrPaging);
                    if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                    {
                        this.btnExport.Visible = false;
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        return;
                    }
                }
            }
        }

        private void SaveReports(string value)
        {
            string str = this.hid_ClientID.Value;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (i != 0)
                    {
                        empty1 = this.chkColumns.Items[i].Value;
                        delivery_report deliveryDeliveryReport = this;
                        deliveryDeliveryReport.ColumnNames = string.Concat(deliveryDeliveryReport.ColumnNames, "µ", empty1);
                    }
                    else
                    {
                        empty1 = this.chkColumns.Items[i].Value;
                        this.ColumnNames = empty1;
                    }
                }
            }
            if (this.HdnSortBy.Value.ToLower() == "none")
            {
                delivery_report deliveryDeliveryReport1 = this;
                deliveryDeliveryReport1.ColumnNames = string.Concat(deliveryDeliveryReport1.ColumnNames, " ");
            }
            else
            {
                delivery_report deliveryDeliveryReport2 = this;
                string columnNames = deliveryDeliveryReport2.ColumnNames;
                string[] strArrays = new string[] { columnNames, "µ", this.HdnSortBy.Value, "µ", this.ddldirection.SelectedValue };
                deliveryDeliveryReport2.ColumnNames = string.Concat(strArrays);
            }
            stringBuilder.Append(" Columns");
            stringBuilder1.Append(string.Concat(" '", this.ColumnNames, "'"));
            stringBuilder.Append(" ,EstCount");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstTotal");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstAverage");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstMaximum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstMinimum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstConvertedCount");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetTotal");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetAverage");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetMaximum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetMinimum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,PriceRange");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstNoAssignedValue");
            stringBuilder1.Append(", 0");
            if (this.txtFreetext.Text != "")
            {
                stringBuilder.Append(" ,SearchKeyword");
                stringBuilder1.Append(string.Concat(" ,'", base.ReplaceSingleQuote(this.txtFreetext.Text), "'"));
            }
            for (int j = 0; j < this.chkfreetext.Items.Count; j++)
            {
                if (this.chkfreetext.Items[j].Selected)
                {
                    if (j != 0)
                    {
                        this.FreeTextColoumn = this.chkfreetext.Items[j].Value;
                        str1 = string.Concat(str1, "µ", this.FreeTextColoumn);
                    }
                    else
                    {
                        this.FreeTextColoumn = this.chkfreetext.Items[j].Value;
                        str1 = string.Concat(str1, this.FreeTextColoumn);
                    }
                }
            }
            stringBuilder.Append(" ,SelectedSearchText");
            stringBuilder1.Append(string.Concat(" ,'", str1, "'"));
            if (this.ddlNotesType.SelectedValue.ToString().Trim() != "0")
            {
                stringBuilder.Append(" ,NotesType");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlNotesType.SelectedValue, "'"));
            }
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "0")
            {
                stringBuilder.Append(" ,ReportType,GroupedBy");
                stringBuilder1.Append(" ,'',0");
            }
            else
            {
                stringBuilder.Append(" ,ReportType,GroupedBy");
                stringBuilder1.Append(string.Concat(" ,'',", this.ddlGrouprecords.SelectedValue));
            }
            if (this.txtName.Text != "")
            {
                stringBuilder.Append(" ,CompanyName");
                stringBuilder1.Append(string.Concat(" ,'", base.ReplaceSingleQuote(this.txtName.Text), "'"));
                stringBuilder.Append(" ,customerID");
                stringBuilder1.Append(string.Concat(" ,'", this.hid_ClientID.Value, "'"));
            }
            if (!this.chkDateOption.Checked)
            {
                stringBuilder.Append(" ,IsCreatedDate,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                stringBuilder1.Append(" ,0,'','',''");
            }
            else
            {
                stringBuilder.Append(" ,IsCreatedDate");
                stringBuilder1.Append(" ,1");
                if (this.rdlDate.SelectedValue == "daily")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 't','',''");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'y','',''");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cm','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cq','',''");
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'ay','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lq','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cy','',''");
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'hy','',''");
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'td','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lw','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lm','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'ly','',''");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    string[] strArrays1 = new string[] { ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtTo.Text), "'" };
                    stringBuilder1.Append(string.Concat(strArrays1));
                }
            }
            if (!this.chkJobDate.Checked)
            {
                stringBuilder.Append(" ,IsJobDate,JobDateType,JobDateFrom,JobDateTo");
                stringBuilder1.Append(" ,0,'','',''");
            }
            else
            {
                stringBuilder.Append(" ,IsJobDate");
                stringBuilder1.Append(" ,1");
                if (this.ddlJobdate.SelectedValue == "daily")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 't','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "yesterday")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'y','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "thismonth")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'cm','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "thisquarter")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'cq','',''");
                }
                else if (this.ddlJobdate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'ay','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "lastquater")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'lq','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "thisyear")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'cy','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "halfyear")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'hy','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "tilldate")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'td','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "lastweek")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'lw','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "lastmonth")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'lm','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "lastyear")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    stringBuilder1.Append(", 'ly','',''");
                }
                else if (this.ddlJobdate.SelectedValue == "daterange")
                {
                    stringBuilder.Append(" ,JobDateType,JobDateFrom,JobDateTo");
                    string[] strArrays2 = new string[] { ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtjobFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtJobTo.Text), "'" };
                    stringBuilder1.Append(string.Concat(strArrays2));
                }
            }
            if (CheckXeroTracking() && this.ddlLocation.SelectedIndex >= 0)
            {
                stringBuilder.Append(" ,TrackingLocation");
                stringBuilder1.Append(string.Concat(" ,'", ddlLocation.SelectedItem.Text, "'"));
            }

            if (this.ddlSalesPerson.SelectedValue != "")
            {
                stringBuilder.Append(" ,SalesPersonId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlSalesPerson.SelectedValue, "'"));
            }
            if (this.ddlEstimator.SelectedValue != "")
            {
                stringBuilder.Append(" ,EstimatorId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlEstimator.SelectedValue, "'"));
            }
            if (this.ddlCustomerSalesPerson.SelectedValue != "")
            {
                stringBuilder.Append(" ,CustomerSalesPersonId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlCustomerSalesPerson.SelectedValue, "'"));
            }

            stringBuilder.Append(" ,EstConvertionDate,EstConvertionDateType,EstConvertionDateFrom,EstConvertionDateTo,ApplyDates");
            stringBuilder1.Append(" ,0,'','','',0");
            if (this.txtSaveReports.Text != "")
            {
                stringBuilder.Append(" ,ReportName");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtSaveReports.Text), "'"));
            }
            if (this.txtDescription.Text != "")
            {
                stringBuilder.Append(" ,Description");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtDescription.Text), "'"));
            }
            stringBuilder.Append(" ,PageName,CompanyID,UserID");
            object[] num = new object[] { ", '", this.pg, "',", Convert.ToInt32(this.Session["companyid"].ToString()), ",", Convert.ToInt32(this.Session["UserID"].ToString()) };
            stringBuilder1.Append(string.Concat(num));
            if (value == "Save")
            {
                object[] objArray = new object[] { "Insert into tb_Reports_Save(", stringBuilder, ") Values (", stringBuilder1, ")" };
                empty = string.Concat(objArray);
            }
            else if (value == "Update")
            {
                empty = string.Concat("delete tb_reports_save where ReportID=", Convert.ToInt32(this.hdn_reportID.Value));
                object[] objArray1 = new object[] { " ", empty, "Insert into tb_Reports_Save(", stringBuilder, ") Values (", stringBuilder1, ")" };
                empty = string.Concat(objArray1);
                this.hdn_reportID.Value = "";
            }
            SqlCommand sqlCommand = new SqlCommand(empty, this.objJava.openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
        }

        private void usrReportsave_OnDeleteClick(int ReportID)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_Reports_Delete", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
            this.pnlSavedReports.Visible = true;
            this.Session["DeleteMsg"] = "SelectDeleteTab";
            this.Session["SaveAsNew"] = null;
        }

        private void usrReportsave_OnEditClick(int ReportID)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.pnlSavedReports.Visible = false;
            delivery_report.divVisibility = "none";
            delivery_report.imgVisibility = "block";
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            this.btnUpdateExisting.Visible = true;
            this.btnRunReport.Visible = false;
            this.btnSaveRun.Text = "Save as New";
            this.ReportDetails(ReportID);
            this.hdn_reportID.Value = ReportID.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "selected", "javascript:OnEditReport();", true);
        }

        private void usrReportsave_OnPageIndexChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnPageSizeChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnReportClick(int ReportID)
        {
            this.Session["DeleteMsg"] = null;
            this.ReportDetails(ReportID);
            this.RunReportOnClick();
            this.hdn_reportID.Value = ReportID.ToString();
        }

        private void BindEstimatorDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlEstimator.DataSource = dataTable;
            this.ddlEstimator.DataTextField = "LimitName";
            this.ddlEstimator.DataValueField = "UserID";
            this.ddlEstimator.DataBind();

            this.ddlEstimator.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        private void BindSalesPersonDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlSalesPerson.DataSource = dataTable;
            this.ddlSalesPerson.DataTextField = "LimitName";
            this.ddlSalesPerson.DataValueField = "UserID";
            this.ddlSalesPerson.DataBind();

            this.ddlSalesPerson.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void BindCustomerSalesPersonDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlCustomerSalesPerson.DataSource = dataTable;
            this.ddlCustomerSalesPerson.DataTextField = "LimitName";
            this.ddlCustomerSalesPerson.DataValueField = "UserID";
            this.ddlCustomerSalesPerson.DataBind();

            this.ddlCustomerSalesPerson.Items.Insert(0, new ListItem("-- Select --", ""));
        }
    }
}