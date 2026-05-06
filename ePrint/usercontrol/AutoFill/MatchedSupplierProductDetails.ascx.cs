using nmsLanguage;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.AutoFill
{
    public partial class MatchedSupplierProductDetails : System.Web.UI.UserControl
    {

        public DataSet data;

        public BaseClass ObjBase = new BaseClass();

        public languageClass ObjLanguage = new languageClass();

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

        public MatchedSupplierProductDetails()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.data.Tables[0].Rows.Count <= 0)
            {
                this.pnlitem.Style.Add("display", "none");
                return;
            }
            this.pnlitem.Style.Add("display", "block");
            foreach (DataRow row in this.data.Tables[0].Rows)
            {
                if (row.Table.Columns["ItemTitle"] != null)
                {
                    row["ItemTitle"] = row["ItemTitle"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["CustomerCode"] != null)
                {
                    row["CustomerCode"] = row["CustomerCode"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Description"] != null)
                {
                    row["Description"] = row["Description"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Artwork"] != null)
                {
                    row["Artwork"] = row["Artwork"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Color"] != null)
                {
                    row["Color"] = row["Color"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Size"] != null)
                {
                    row["Size"] = row["Size"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Material"] != null)
                {
                    row["Material"] = row["Material"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Delivery"] != null)
                {
                    row["Delivery"] = row["Delivery"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Finishing"] != null)
                {
                    row["Finishing"] = row["Finishing"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Proofs"] != null)
                {
                    row["Proofs"] = row["Proofs"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Packing"] != null)
                {
                    row["Packing"] = row["Packing"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Notes"] != null)
                {
                    row["Notes"] = row["Notes"].ToString().Replace(Environment.NewLine, "");
                }
                if (row.Table.Columns["Instructions"] == null)
                {
                    continue;
                }
                row["Instructions"] = row["Instructions"].ToString().Replace(Environment.NewLine, "");
            }
            this.uc.DataSource = this.data.Tables[0];
            this.uc.DataBind();
        }

        protected void Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("ClientName");
                Label label = (Label)e.Item.FindControl("hdnClientID");
                Label label1 = (Label)e.Item.FindControl("hdnClientName");
                Label label2 = (Label)e.Item.FindControl("hdnContacts");
                Label label3 = (Label)e.Item.FindControl("hdnAccountNo");
                Label label4 = (Label)e.Item.FindControl("hdnContactDelAddress");
                Label label5 = (Label)e.Item.FindControl("hdnDepartmentName");
                Label label6 = (Label)e.Item.FindControl("hdnDepartmentID");
                Label label7 = (Label)e.Item.FindControl("hdnInvoiceAddressID");
                Label label8 = (Label)e.Item.FindControl("hdnInvoiceAddress");
                Label label9 = (Label)e.Item.FindControl("hdnContactAddress");
                Label label10 = (Label)e.Item.FindControl("hdnContactAddressID");
            }
        }
    }
}