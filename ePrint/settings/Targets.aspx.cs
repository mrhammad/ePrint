using Newtonsoft.Json;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public class MonthlyTarget
    {
        public decimal MonthlyTarget1 { get; set; }
        public decimal MonthlyTarget2 { get; set; }
        public decimal MonthlyTarget3 { get; set; }
        public decimal MonthlyTarget4 { get; set; }
        public decimal MonthlyTarget5 { get; set; }
        public decimal MonthlyTarget6 { get; set; }
        public decimal MonthlyTarget7 { get; set; }
        public decimal MonthlyTarget8 { get; set; }
        public decimal MonthlyTarget9 { get; set; }
        public decimal MonthlyTarget10 { get; set; }
        public decimal MonthlyTarget11 { get; set; }
        public decimal MonthlyTarget12 { get; set; }


    }
    public class DailyTarget
    {
        public decimal DailyTarget1 { get; set; }
        public decimal DailyTarget2 { get; set; }
        public decimal DailyTarget3 { get; set; }
        public decimal DailyTarget4 { get; set; }
        public decimal DailyTarget5 { get; set; }
        public decimal DailyTarget6 { get; set; }
        public decimal DailyTarget7 { get; set; }
        public decimal DailyTarget8 { get; set; }
        public decimal DailyTarget9 { get; set; }
        public decimal DailyTarget10 { get; set; }
        public decimal DailyTarget11 { get; set; }
        public decimal DailyTarget12 { get; set; }

        public decimal DailyTarget13 { get; set; }
        public decimal DailyTarget14 { get; set; }
        public decimal DailyTarget15 { get; set; }
        public decimal DailyTarget16 { get; set; }
        public decimal DailyTarget17 { get; set; }
        public decimal DailyTarget18 { get; set; }
        public decimal DailyTarget19 { get; set; }
        public decimal DailyTarget20 { get; set; }
        public decimal DailyTarget21 { get; set; }
        public decimal DailyTarget22 { get; set; }
        public decimal DailyTarget23 { get; set; }
        public decimal DailyTarget24 { get; set; }

        public decimal DailyTarget25 { get; set; }
        public decimal DailyTarget26 { get; set; }
        public decimal DailyTarget27 { get; set; }
        public decimal DailyTarget28 { get; set; }
        public decimal DailyTarget29 { get; set; }
        public decimal DailyTarget30 { get; set; }
        public decimal DailyTarget31 { get; set; }
    }
    public partial class Targets : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        public int CompanyID;

        public int UserID;
        protected void btnSaveTarget_Click(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string dataType= RadioButtonList1.SelectedValue;
            this.Session["TargetsSavedAt"] = RadioButtonList1.SelectedValue;
            MonthlyTarget monthlyTarget = new MonthlyTarget();
             monthlyTarget.MonthlyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget1.Text) ? "0" : this.MonthlyTarget1.Text);
            monthlyTarget.MonthlyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget2.Text) ? "0" : this.MonthlyTarget2.Text);
            monthlyTarget.MonthlyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget3.Text) ? "0" : this.MonthlyTarget3.Text);
            monthlyTarget.MonthlyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget4.Text) ? "0" : this.MonthlyTarget4.Text);
            monthlyTarget.MonthlyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget5.Text) ? "0" : this.MonthlyTarget5.Text);
            monthlyTarget.MonthlyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget6.Text) ? "0" : this.MonthlyTarget6.Text);
            monthlyTarget.MonthlyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget7.Text) ? "0" : this.MonthlyTarget7.Text);
            monthlyTarget.MonthlyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget8.Text) ? "0" : this.MonthlyTarget8.Text);
            monthlyTarget.MonthlyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget9.Text) ? "0" : this.MonthlyTarget9.Text);
            monthlyTarget.MonthlyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget10.Text) ? "0" : this.MonthlyTarget10.Text);
            monthlyTarget.MonthlyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget11.Text) ? "0" : this.MonthlyTarget11.Text);
            monthlyTarget.MonthlyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget12.Text) ? "0" : this.MonthlyTarget12.Text);
            DailyTarget dailyTarget = new DailyTarget();
            dailyTarget.DailyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget1.Text) ? "0" : this.DailyTarget1.Text);
            dailyTarget.DailyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget2.Text) ? "0" : this.DailyTarget2.Text);
            dailyTarget.DailyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget3.Text) ? "0" : this.DailyTarget3.Text);
            dailyTarget.DailyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget4.Text) ? "0" : this.DailyTarget4.Text);
            dailyTarget.DailyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget5.Text) ? "0" : this.DailyTarget5.Text);
            dailyTarget.DailyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget6.Text) ? "0" : this.DailyTarget6.Text);
            dailyTarget.DailyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget7.Text) ? "0" : this.DailyTarget7.Text);
            dailyTarget.DailyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget8.Text) ? "0" : this.DailyTarget8.Text);
            dailyTarget.DailyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget9.Text) ? "0" : this.DailyTarget9.Text);
            dailyTarget.DailyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget10.Text) ? "0" : this.DailyTarget10.Text);
            dailyTarget.DailyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget11.Text) ? "0" : this.DailyTarget11.Text);
            dailyTarget.DailyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget12.Text) ? "0" : this.DailyTarget12.Text);
            dailyTarget.DailyTarget13 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget13.Text) ? "0" : this.DailyTarget13.Text);
            dailyTarget.DailyTarget14 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget14.Text) ? "0" : this.DailyTarget14.Text);
            dailyTarget.DailyTarget15 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget15.Text) ? "0" : this.DailyTarget15.Text);
            dailyTarget.DailyTarget16 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget16.Text) ? "0" : this.DailyTarget16.Text);
            dailyTarget.DailyTarget17 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget17.Text) ? "0" : this.DailyTarget17.Text);
            dailyTarget.DailyTarget18 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget18.Text) ? "0" : this.DailyTarget18.Text);
            dailyTarget.DailyTarget19 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget19.Text) ? "0" : this.DailyTarget19.Text);
            dailyTarget.DailyTarget20 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget20.Text) ? "0" : this.DailyTarget20.Text);
            dailyTarget.DailyTarget21 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget21.Text) ? "0" : this.DailyTarget21.Text);
            dailyTarget.DailyTarget22 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget22.Text) ? "0" : this.DailyTarget22.Text);
            dailyTarget.DailyTarget23 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget23.Text) ? "0" : this.DailyTarget23.Text);
            dailyTarget.DailyTarget24 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget24.Text) ? "0" : this.DailyTarget24.Text);
            dailyTarget.DailyTarget25 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget25.Text) ? "0" : this.DailyTarget25.Text);
            dailyTarget.DailyTarget26 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget26.Text) ? "0" : this.DailyTarget26.Text);
            dailyTarget.DailyTarget27 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget27.Text) ? "0" : this.DailyTarget27.Text);
            dailyTarget.DailyTarget28 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget28.Text) ? "0" : this.DailyTarget28.Text);
            dailyTarget.DailyTarget29 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget29.Text) ? "0" : this.DailyTarget29.Text);
            dailyTarget.DailyTarget30 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget30.Text) ? "0" : this.DailyTarget30.Text);
            dailyTarget.DailyTarget31 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget31.Text) ? "0" : this.DailyTarget31.Text);
            SettingsBasePage.Settings_Save_Targets(this.CompanyID, this.UserID, dataType, dailyTarget, monthlyTarget);
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Customize_setting_saved_Successfully"), "msg-success", this.plhMessage);
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Dashboard_Targets");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("Dashboard_Targets");
            if (!base.IsPostBack)
            {
                DataTable dt = SettingsBasePage.Settings_Targets_Select(this.CompanyID, this.UserID, "Daily");
                foreach (DataRow dr in dt.Rows)
                {

                    this.MonthlyTarget1.Text = string.IsNullOrEmpty(dr["MonthlyTarget1"].ToString()) ? "0" : dr["MonthlyTarget1"].ToString();
                    this.MonthlyTarget2.Text = string.IsNullOrEmpty(dr["MonthlyTarget2"].ToString()) ? "0" : dr["MonthlyTarget2"].ToString();
                    this.MonthlyTarget3.Text = string.IsNullOrEmpty(dr["MonthlyTarget3"].ToString()) ? "0" : dr["MonthlyTarget3"].ToString();
                    this.MonthlyTarget4.Text = string.IsNullOrEmpty(dr["MonthlyTarget4"].ToString()) ? "0" : dr["MonthlyTarget4"].ToString();
                    this.MonthlyTarget5.Text = string.IsNullOrEmpty(dr["MonthlyTarget5"].ToString()) ? "0" : dr["MonthlyTarget5"].ToString();
                    this.MonthlyTarget6.Text = string.IsNullOrEmpty(dr["MonthlyTarget6"].ToString()) ? "0" : dr["MonthlyTarget6"].ToString();
                    this.MonthlyTarget7.Text = string.IsNullOrEmpty(dr["MonthlyTarget7"].ToString()) ? "0" : dr["MonthlyTarget7"].ToString();
                    this.MonthlyTarget8.Text = string.IsNullOrEmpty(dr["MonthlyTarget8"].ToString()) ? "0" : dr["MonthlyTarget8"].ToString();
                    this.MonthlyTarget9.Text = string.IsNullOrEmpty(dr["MonthlyTarget9"].ToString()) ? "0" : dr["MonthlyTarget9"].ToString();
                    this.MonthlyTarget10.Text = string.IsNullOrEmpty(dr["MonthlyTarget10"].ToString()) ? "0" : dr["MonthlyTarget10"].ToString();
                    this.MonthlyTarget11.Text = string.IsNullOrEmpty(dr["MonthlyTarget11"].ToString()) ? "0" : dr["MonthlyTarget11"].ToString();
                    this.MonthlyTarget12.Text = string.IsNullOrEmpty(dr["MonthlyTarget12"].ToString()) ? "0" : dr["MonthlyTarget12"].ToString();

                    this.DailyTarget1.Text = string.IsNullOrEmpty(dr["DailyTarget1"].ToString()) ? "0" : dr["DailyTarget1"].ToString();
                    this.DailyTarget2.Text = string.IsNullOrEmpty(dr["DailyTarget2"].ToString()) ? "0" : dr["DailyTarget2"].ToString();
                    this.DailyTarget3.Text = string.IsNullOrEmpty(dr["DailyTarget3"].ToString()) ? "0" : dr["DailyTarget3"].ToString();
                    this.DailyTarget4.Text = string.IsNullOrEmpty(dr["DailyTarget4"].ToString()) ? "0" : dr["DailyTarget4"].ToString();
                    this.DailyTarget5.Text = string.IsNullOrEmpty(dr["DailyTarget5"].ToString()) ? "0" : dr["DailyTarget5"].ToString();
                    this.DailyTarget6.Text = string.IsNullOrEmpty(dr["DailyTarget6"].ToString()) ? "0" : dr["DailyTarget6"].ToString();
                    this.DailyTarget7.Text = string.IsNullOrEmpty(dr["DailyTarget7"].ToString()) ? "0" : dr["DailyTarget7"].ToString();
                    this.DailyTarget8.Text = string.IsNullOrEmpty(dr["DailyTarget8"].ToString()) ? "0" : dr["DailyTarget8"].ToString();
                    this.DailyTarget9.Text = string.IsNullOrEmpty(dr["DailyTarget9"].ToString()) ? "0" : dr["DailyTarget9"].ToString();
                    this.DailyTarget10.Text = string.IsNullOrEmpty(dr["DailyTarget10"].ToString()) ? "0" : dr["DailyTarget10"].ToString();
                    this.DailyTarget11.Text = string.IsNullOrEmpty(dr["DailyTarget11"].ToString()) ? "0" : dr["DailyTarget11"].ToString();
                    this.DailyTarget12.Text = string.IsNullOrEmpty(dr["DailyTarget12"].ToString()) ? "0" : dr["DailyTarget12"].ToString();
                    this.DailyTarget13.Text = string.IsNullOrEmpty(dr["DailyTarget13"].ToString()) ? "0" : dr["DailyTarget13"].ToString();
                    this.DailyTarget14.Text = string.IsNullOrEmpty(dr["DailyTarget14"].ToString()) ? "0" : dr["DailyTarget14"].ToString();
                    this.DailyTarget15.Text = string.IsNullOrEmpty(dr["DailyTarget15"].ToString()) ? "0" : dr["DailyTarget15"].ToString();
                    this.DailyTarget16.Text = string.IsNullOrEmpty(dr["DailyTarget16"].ToString()) ? "0" : dr["DailyTarget16"].ToString();
                    this.DailyTarget17.Text = string.IsNullOrEmpty(dr["DailyTarget17"].ToString()) ? "0" : dr["DailyTarget17"].ToString();
                    this.DailyTarget18.Text = string.IsNullOrEmpty(dr["DailyTarget18"].ToString()) ? "0" : dr["DailyTarget18"].ToString();
                    this.DailyTarget19.Text = string.IsNullOrEmpty(dr["DailyTarget19"].ToString()) ? "0" : dr["DailyTarget19"].ToString();
                    this.DailyTarget20.Text = string.IsNullOrEmpty(dr["DailyTarget20"].ToString()) ? "0" : dr["DailyTarget20"].ToString();
                    this.DailyTarget21.Text = string.IsNullOrEmpty(dr["DailyTarget21"].ToString()) ? "0" : dr["DailyTarget21"].ToString();
                    this.DailyTarget22.Text = string.IsNullOrEmpty(dr["DailyTarget22"].ToString()) ? "0" : dr["DailyTarget22"].ToString();
                    this.DailyTarget23.Text = string.IsNullOrEmpty(dr["DailyTarget23"].ToString()) ? "0" : dr["DailyTarget23"].ToString();
                    this.DailyTarget24.Text = string.IsNullOrEmpty(dr["DailyTarget24"].ToString()) ? "0" : dr["DailyTarget24"].ToString();
                    this.DailyTarget25.Text = string.IsNullOrEmpty(dr["DailyTarget25"].ToString()) ? "0" : dr["DailyTarget25"].ToString();
                    this.DailyTarget26.Text = string.IsNullOrEmpty(dr["DailyTarget26"].ToString()) ? "0" : dr["DailyTarget26"].ToString();
                    this.DailyTarget27.Text = string.IsNullOrEmpty(dr["DailyTarget27"].ToString()) ? "0" : dr["DailyTarget27"].ToString();
                    this.DailyTarget28.Text = string.IsNullOrEmpty(dr["DailyTarget28"].ToString()) ? "0" : dr["DailyTarget28"].ToString();
                    this.DailyTarget29.Text = string.IsNullOrEmpty(dr["DailyTarget29"].ToString()) ? "0" : dr["DailyTarget29"].ToString();
                    this.DailyTarget30.Text = string.IsNullOrEmpty(dr["DailyTarget30"].ToString()) ? "0" : dr["DailyTarget30"].ToString();
                    this.DailyTarget31.Text = string.IsNullOrEmpty(dr["DailyTarget31"].ToString()) ? "0" : dr["DailyTarget31"].ToString();
                }
                if (this.Session["TargetsSavedAt"] != null)
                {
                    if (this.Session["TargetsSavedAt"].ToString() == "Monthly")
                    {
                        RadioButtonList1.Items.FindByValue("Monthly").Selected = true;
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "TargetChange();", true);
                    }
                    else
                    {
                        RadioButtonList1.Items.FindByValue("Daily").Selected = true;
                    }
                }
            }
          
        }
        [WebMethod]
        public static string LoadTargetData(string DataType)
        {
            int CompanyID = Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString());
            int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            DataTable dt = SettingsBasePage.Settings_Targets_Select(CompanyID,UserID, DataType);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
    }
}