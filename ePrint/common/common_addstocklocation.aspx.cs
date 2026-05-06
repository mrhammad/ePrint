using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Sample.Web.UI.Compatibility;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class common_addstocklocation : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label lblLocationName;

        //protected TextBox txtlocationName;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldlocationname;

        //protected Label lbl_Address1;

        //protected TextBox txtaddress;

        //protected Label lbl_Address3;

        //protected TextBox txtcity;

        //protected Label lbl_Address4;

        //protected TextBox txt_suburb;

        //protected Label lbl_Address5;

        //protected TextBox txt_postCode;

        //protected Label Label42;

        //protected DropDownList ddlcountry;

        //protected Label Label43;

        //protected TextBox txttelephone;

        //protected Label Label1;

        //protected CheckBox chkdefault;

        //protected Button btnsave;

        public static int companyid;

        public static int UserID;

        private CompanyBasePage comnyobj = new CompanyBasePage();

        private BaseClass objBase = new BaseClass();

        public static string LocationName;

        public static int LocationID;

        public static languageClass objLanguage;

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

        static common_addstocklocation()
        {
            common_addstocklocation.companyid = 0;
            common_addstocklocation.UserID = 0;
            common_addstocklocation.LocationName = string.Empty;
            common_addstocklocation.LocationID = 0;
            common_addstocklocation.objLanguage = new languageClass();
        }

        public common_addstocklocation()
        {
        }

        protected void btnsave_onclick(object sender, EventArgs e)
        {
            int num = 0;
            string text = "";
            if (this.chkdefault.Checked)
            {
                num = 1;
            }
            if (this.ddlcountry.SelectedIndex != 0)
            {
                text = this.ddlcountry.SelectedItem.Text;
            }
            SettingsBasePage.productcatalogue_warehouselocation_insert(common_addstocklocation.companyid, this.objBase.SpecialEncode(this.txtlocationName.Text), this.objBase.SpecialEncode(this.txtaddress.Text), this.objBase.SpecialEncode(this.txtcity.Text), this.objBase.SpecialEncode(this.txt_suburb.Text), this.objBase.SpecialEncode(this.txt_postCode.Text), text, this.txttelephone.Text, num);
            SqlCommand sqlCommand = new SqlCommand("PC_GetTopWarehouseLocationDetails", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", common_addstocklocation.companyid);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            common_addstocklocation.LocationID = Convert.ToInt32(dataTable.Rows[0][0]);
            common_addstocklocation.LocationName = dataTable.Rows[0][1].ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "SetTopLocation();GetRadWindow().close();", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnsave.Text = common_addstocklocation.objLanguage.GetLanguageConversion("Save");
            this.txtlocationName.Focus();
            base.Title = "Add Stock Location";
            common_addstocklocation.companyid = Convert.ToInt32(this.Session["CompanyID"].ToString());
            common_addstocklocation.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (!base.IsPostBack)
            {
                this.comnyobj.company_country_select(this.ddlcountry);
            }
        }
    }
}