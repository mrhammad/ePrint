using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class MapWithDirections : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        public int ClientID;

        public string ClientName = "";

        private BaseClass objbase = new BaseClass();

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

        public MapWithDirections()
        {
        }

        public void BindAddress()
        {
            DataSet dataSet = DepartmentBaseClass.Crm_Select_Addreess(Convert.ToInt64(this.ClientID), Convert.ToInt64(this.CompanyID));
            this.ddlAddress.DataSource = dataSet;
            this.ddlAddress.DataTextField = "ClientAddress";
            this.ddlAddress.DataValueField = "AddressID";
            this.ddlAddress.DataBind();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.txtFirstAddress.Text = row["CompanyAddress"].ToString();
                if (row["DefaultAddressID"].ToString().ToLower() == "0")
                {
                    continue;
                }
                this.objbase.SetDDLText(this.ddlAddress, row["ClientAddress"].ToString());
                this.txtSecondAddress.Text = row["ClientAddress"].ToString();
            }
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Clear();
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(this.txtFirstAddress.Text);
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(this.txtSecondAddress.Text);
        }

        protected void btnDrawDirections_Click(object sender, EventArgs e)
        {
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Clear();
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(this.txtFirstAddress.Text);
            this.GoogleMapForASPNet1.GoogleMapObject.Directions.Addresses.Add(this.hdnAddress.Value);
            this.txtSecondAddress.Text = this.hdnAddress.Value;
            for (int i = 0; i < this.ddlAddress.Items.Count; i++)
            {
                if (this.ddlAddress.Items[i].Value == this.hdnAddressID.Value)
                {
                    this.ddlAddress.SelectedIndex = i;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];
            this.GoogleMapForASPNet1.GoogleMapObject.Width = "98.5%";
            this.GoogleMapForASPNet1.GoogleMapObject.Height = "445px";
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            }
            if (this.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(this.Session["UserID"]);
            }
            if (base.Request.QueryString["clientid"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.QueryString["clientid"]);
            }
            if (base.Request.QueryString["clna"] != null)
            {
                this.ClientName = base.Request.QueryString["clna"];
                this.lblClientName.Text = this.objbase.SpecialDecode(this.ClientName);
            }
            if (!base.IsPostBack)
            {
                this.BindAddress();
            }
        }
    }
}