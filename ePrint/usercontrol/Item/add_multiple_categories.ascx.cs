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
using Printcenter.UI.Webstores;
using System;
using System.Collections;
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

namespace ePrint.usercontrol.Item
{
    public partial class add_multiple_categories : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();
        public string VersionNumber = ConnectionClass.VersionNumber;

        public long ProductCatalogueID;
        public int CompanyID;
        public long JobID;
        public long InvoiceID;
        public string Pgtype = string.Empty;
        public string MainItemNumber = string.Empty;
        public string RedirectTo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.page_type.Value = base.Request.QueryString["page"].ToString();
            this.hdnURL.Value = strSitepath.ToString();
            if (base.Request.QueryString["productcatalogueid"] != null)
            {
                this.ProductCatalogueID = Convert.ToInt64(base.Request.QueryString["productcatalogueid"].ToString());
                this.hdnPriceCatalogueID.Value = this.ProductCatalogueID.ToString();

            }
            if (base.Request.QueryString["companyid"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Request.QueryString["companyid"].ToString());
            }
            if (base.Request.QueryString["jobid"] != null)
            {
                this.JobID = Convert.ToInt64(base.Request.QueryString["jobid"].ToString());
            }
            if (base.Request.QueryString["invoiceid"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.QueryString["invoiceid"].ToString());
            }
            if (base.Request.QueryString["page"] != null)
            {
                this.Pgtype = base.Request.QueryString["page"].ToString().ToLower();
            }

          

            if (this.Pgtype.ToLower() == "fromgrid")
            {
                this.theDiv.Visible = false;
            }
            else
            {
                this.theDiv.Visible = true;
            }

            DataTable dataTable4 = WebstoreBasePage.Select_ProductCategory_List((long)this.CompanyID, "ProductItem", (long)0);
            for (int k = 0; k < dataTable4.Columns.Count; k++)
            {
                dataTable4.Columns[k].ReadOnly = false;
            }

            DataRow row = dataTable4.NewRow();
            row["CategoryID"] = 0;
            row["MultiLevelCategory"] = "-- Select --";
            dataTable4.Rows.Add(row);


            this.ddlCategory2.DataSource = dataTable4;
            this.ddlCategory2.DataTextField = "MultiLevelCategory";
            this.ddlCategory2.DataValueField = "CategoryID";
            this.ddlCategory2.DataBind();

            this.ddlCategory3.DataSource = dataTable4;
            this.ddlCategory3.DataTextField = "MultiLevelCategory";
            this.ddlCategory3.DataValueField = "CategoryID";
            this.ddlCategory3.DataBind();

            this.ddlCategory4.DataSource = dataTable4;
            this.ddlCategory4.DataTextField = "MultiLevelCategory";
            this.ddlCategory4.DataValueField = "CategoryID";
            this.ddlCategory4.DataBind();

            this.ddlCategory5.DataSource = dataTable4;
            this.ddlCategory5.DataTextField = "MultiLevelCategory";
            this.ddlCategory5.DataValueField = "CategoryID";
            this.ddlCategory5.DataBind();

            this.ddlCategory6.DataSource = dataTable4;
            this.ddlCategory6.DataTextField = "MultiLevelCategory";
            this.ddlCategory6.DataValueField = "CategoryID";
            this.ddlCategory6.DataBind();

            if (ProductCatalogueID > 0)
            {
                DataTable dataTable1 = this.select_multiple_product_categories(this.ProductCatalogueID);
                if (dataTable1.Rows.Count > 0)
                {
                    this.ddlCategory2.SelectedValue = dataTable1.Rows[0]["PriceCatalogueCategoryID_2"].ToString();
                    this.ddlCategory3.SelectedValue = dataTable1.Rows[0]["PriceCatalogueCategoryID_3"].ToString();
                    this.ddlCategory4.SelectedValue = dataTable1.Rows[0]["PriceCatalogueCategoryID_4"].ToString();
                    this.ddlCategory5.SelectedValue = dataTable1.Rows[0]["PriceCatalogueCategoryID_5"].ToString();
                    this.ddlCategory6.SelectedValue = dataTable1.Rows[0]["PriceCatalogueCategoryID_6"].ToString();

                    if (base.Request.QueryString["page"] == "FromGrid")
                    {
                        this.ddlCategory2.Enabled = false;
                        this.ddlCategory3.Enabled = false;
                        this.ddlCategory4.Enabled = false;
                        this.ddlCategory5.Enabled = false;
                        this.ddlCategory6.Enabled = false;
                    }
                    this.catLabel_1.Text = dataTable1.Rows[0]["CategoryName"].ToString();
                }
            }
            else
            {
                this.ddlCategory2.SelectedValue = "0".ToString();
                this.ddlCategory3.SelectedValue = "0".ToString();
                this.ddlCategory4.SelectedValue = "0".ToString();
                this.ddlCategory5.SelectedValue = "0".ToString();
                this.ddlCategory6.SelectedValue = "0".ToString();
            }
        }

        public virtual DataTable select_multiple_product_categories(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("select_multiple_product_categories");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }




        protected void imgbtnaddcategory_Click(object sender, System.EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] lower = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogueCategory.aspx?type=product&post=settings&mode=add"};

            string url = string.Concat(lower);
            //Response.Write("<script>top.location='" + url + "';parent.location='" + url + "';</script>");

            response.Redirect(string.Concat(lower));
            return;
        }
    }
}