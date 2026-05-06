using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ePrint.common
{
    public partial class common_addnew_costcentre : System.Web.UI.Page, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        public int DepartmentID;

        public int ClientID;

        public int ContactID;

        public int CostCentreID;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public static languageClass objLanguage;

        public BaseClass objjBase = new BaseClass();

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

        static common_addnew_costcentre()
        {
            common_addnew_costcentre.objLanguage = new languageClass();
        }

        public common_addnew_costcentre()
        {
        }

        protected void btnsave_onclick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            if (this.chk_ApplyDept.Checked)
            {
                num = 1;
            }
            if (this.chk_CostDefault.Checked)
            {
                num1 = 1;
            }
            DepartmentBaseClass.costcenter_details_insert(this.CompanyID, this.ClientID, this.objjBase.SpecialEncode(this.txtcostcentercode.Text), this.objjBase.SpecialEncode(this.txtcostcentername.Text), num, num1, this.UserID);
            SqlCommand sqlCommand = new SqlCommand("PC_DepartmentCostCentre_DeptId_Insert", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ClientID", this.ClientID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", this.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.CostCentreID = Convert.ToInt32(dataTable.Rows[0][0]);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "LoadCostCentre();GetRadWindow().close();", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.chk_CostDefault.Text = common_addnew_costcentre.objLanguage.GetLanguageConversion("Make_this_as_Default");
            this.chk_ApplyDept.Text = common_addnew_costcentre.objLanguage.GetLanguageConversion("Apply_to_all_existing_department");
            this.btnsave.Text = common_addnew_costcentre.objLanguage.GetLanguageConversion("Save");
            this.btncancel.Text = common_addnew_costcentre.objLanguage.GetLanguageConversion("Cancel");
            this.Page.Title = "Add New Cost Centre";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (Convert.ToInt32(base.Request.Params["DeptID"]) != 0)
            {
                this.DepartmentID = Convert.ToInt32(base.Request.Params["DeptID"]);
            }
            if (Convert.ToInt32(base.Request.Params["ClientID"]) != 0)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["ClientID"]);
            }
            if (Convert.ToInt32(base.Request.Params["ContactID"]) != 0)
            {
                this.ContactID = Convert.ToInt32(base.Request.Params["ContactID"]);
            }
        }

        [WebMethod]
        public static int Check_Cost_Centre_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
        {
            return CompanyBasePage.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
        }
    }
}