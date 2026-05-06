using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;


namespace ePrint.Delivery
{
    public partial class delivery_add : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        public string currentdate = string.Empty;

        private commonClass commclass = new commonClass();

        public int CompanyID;

        public int UserID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public long DeliveryID;

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

        public delivery_add()
        {
        }

        [WebMethod]
        public static void DeleteDeliveryItem(string CompID, string DeliveryItemID, string DeliveryID, string UserID)
        {
            string[] strArrays = DeliveryItemID.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                DeliveryBasePage.deliveryitem_delete(Convert.ToInt32(CompID), Convert.ToInt64(strArrays[i]), Convert.ToInt64(DeliveryID));
            }
            string deliveryItemID = DeliveryItemID;
            int num = Convert.ToInt32(UserID);
            notesclass _notesclass = new notesclass();
            try
            {
                _notesclass.ModuleName = "delivery";
                _notesclass.ModuleID = Convert.ToInt64(DeliveryID);
                if (deliveryItemID != "")
                {
                    deliveryItemID = deliveryItemID.ToString().Substring(0, deliveryItemID.ToString().Length - 1);
                }
                DataTable dataTable = DeliveryBasePage.deliveryitem_selectdeletedItem(Convert.ToInt32(CompID), deliveryItemID.ToString());
                long num1 = (long)0;
                string empty = string.Empty;
                int num2 = Convert.ToInt32(CompID);
                string str = string.Empty;
                BaseClass baseClass = new BaseClass();
                Notes note = new Notes();
                commonClass _commonClass = new commonClass();
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["ItemID"].ToString() == "0")
                    {
                        continue;
                    }
                    num1 = Convert.ToInt64(row["ItemID"].ToString());
                    empty = string.Concat(empty, num1, ",");
                }
                if (empty != "")
                {
                    empty = empty.ToString().Substring(0, empty.ToString().Length - 1);
                }
                DataTable dataTable1 = DeliveryBasePage.deliveryitem_GetDeletedItemValue(Convert.ToInt32(CompID), empty);
                if (dataTable1.Rows.Count >= 1)
                {
                    for (int j = 0; j < dataTable1.Columns.Count; j++)
                    {
                        dataTable1.Columns[j].ReadOnly = false;
                    }
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        dataRow["ItemTitle"] = baseClass.SpecialDecode(dataRow["ItemTitle"].ToString());
                        str = dataRow["ItemTitle"].ToString();
                    }
                }
                _notesclass.NotesType = Convert.ToString(Notes.NotesType.DeliveryDelUpdate);
                _notesclass.Del_ItemTitle = str;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), num2, num, true);
                _notesclass.CompanyID = num2;
                _notesclass.UserID = num;
                note.NotesAdd(_notesclass);
            }
            catch
            {
            }
        }

        [WebMethod]
        public static string GetClientName(string val)
        {
            return "";
        }

        [WebMethod]
        public static string GetContactAddress(string CompID, string ContactID)
        {
            string str = CompanyBasePage.company_contact_address_select(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            this.Session["TemplateTable"] = null;
            this.Session["isSplit"] = null;
            this.Session["TemplateID"] = null;
            global.pageName = "deliverynote";
            global.pgName = "";
            this.gloobj.setpagename("deliverynote");
            if (base.Request.Params["ID"] != null)
            {
                this.DeliveryID = Convert.ToInt64(base.Request.Params["ID"].ToString());
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.currentdate = dateTime.ToShortDateString();
            languageClass _languageClass = new languageClass();
            base.Title = _languageClass.convert(global.pageTitle("Delivery Note Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../delivery/delivery_view.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Delivery_Note_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Delivery_Note_Add")));
        }
    }
}