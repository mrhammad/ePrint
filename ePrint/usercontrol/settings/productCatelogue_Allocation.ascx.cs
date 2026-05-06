using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.settings
{
    public partial class productCatelogue_Allocation : System.Web.UI.UserControl
    {
        public int CompanyID;

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSetting = new SettingsBasePage();

        private BaseClass objBase = new BaseClass();

        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        public string AllocationType = string.Empty;

        public string Action = string.Empty;

        public string From = string.Empty;

        public long productCatalogueID;

        public string CustomerValues = string.Empty;

        public string ReportIDs = string.Empty;

        protected IList<productCatelogue_Allocation.CustomaerList> AllocatedCustomers
        {
            get
            {
                IList<productCatelogue_Allocation.CustomaerList> customaerLists;
                try
                {
                    object item = base.Session["AllocatedCustomers"];
                    if (item == null)
                    {
                        item = this.GetAllocatedCustomers();
                        if (item == null)
                        {
                            item = new List<productCatelogue_Allocation.CustomaerList>();
                        }
                        else
                        {
                            base.Session["AllocatedCustomers"] = item;
                        }
                    }
                    customaerLists = (IList<productCatelogue_Allocation.CustomaerList>)item;
                }
                catch
                {
                    base.Session["AllocatedCustomers"] = null;
                    return new List<productCatelogue_Allocation.CustomaerList>();
                }
                return customaerLists;
            }
            set
            {
                base.Session["AllocatedCustomers"] = value;
            }
        }

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<productCatelogue_Allocation.CustomaerList> AvailableCustomers
        {
            get
            {
                IList<productCatelogue_Allocation.CustomaerList> customaerLists;
                try
                {
                    object item = base.Session["PendingCustomers"];
                    if (item == null)
                    {
                        item = this.GetCustomers();
                        if (item == null)
                        {
                            item = new List<productCatelogue_Allocation.CustomaerList>();
                        }
                        else
                        {
                            base.Session["PendingCustomers"] = item;
                        }
                    }
                    customaerLists = (IList<productCatelogue_Allocation.CustomaerList>)item;
                }
                catch
                {
                    base.Session["PendingCustomers"] = null;
                    return new List<productCatelogue_Allocation.CustomaerList>();
                }
                return customaerLists;
            }
            set
            {
                base.Session["PendingCustomers"] = value;
            }
        }

        protected IList<productCatelogue_Allocation.CustomaerList> ExcludedCustomers
        {
            get
            {
                IList<productCatelogue_Allocation.CustomaerList> customaerLists;
                try
                {
                    object item = base.Session["ExcludedCustomers"];
                    if (item == null)
                    {
                        item = this.GetExcludedCustomers();
                        if (item == null)
                        {
                            item = new List<productCatelogue_Allocation.CustomaerList>();
                        }
                        else
                        {
                            base.Session["ExcludedCustomers"] = item;
                        }
                    }
                    customaerLists = (IList<productCatelogue_Allocation.CustomaerList>)item;
                }
                catch
                {
                    base.Session["ExcludedCustomers"] = null;
                    return new List<productCatelogue_Allocation.CustomaerList>();
                }
                return customaerLists;
            }
            set
            {
                base.Session["ExcludedCustomers"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public productCatelogue_Allocation()
        {
        }

        protected void BtnMove_Onclick(object sender, EventArgs e)
        {
            IList<productCatelogue_Allocation.CustomaerList> allocatedCustomers = this.AllocatedCustomers;
            IList<productCatelogue_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["MoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["MoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        productCatelogue_Allocation.CustomaerList customers = productCatelogue_Allocation.GetCustomers(availableCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            allocatedCustomers.Add(customers);
                            this.AvailableCustomers.Remove(customers);
                        }
                    }
                }
            }
            base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
            this.AvailableCustomers = availableCustomers;
            this.AllocatedCustomers = allocatedCustomers;
            if (this.From.ToLower() == "category")
            {
                this.GridAvailableCustomers.Rebind();
                this.GridSelectedCustomer.Rebind();
                return;
            }
            this.ProductGridSelectedCustomers.Rebind();
            this.GridAvailableCustomers.Rebind();
        }

        protected void BtnMoveExclude_Onclick(object sender, EventArgs e)
        {
            IList<productCatelogue_Allocation.CustomaerList> excludedCustomers = this.ExcludedCustomers;
            IList<productCatelogue_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["MoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["MoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        productCatelogue_Allocation.CustomaerList customers = productCatelogue_Allocation.GetCustomers(availableCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            excludedCustomers.Add(customers);
                            this.AvailableCustomers.Remove(customers);
                        }
                    }
                }
            }
            this.AvailableCustomers = availableCustomers;
            this.ExcludedCustomers = excludedCustomers;
            if (this.From.ToLower() == "category")
            {
                this.GridAvailableCustomers.Rebind();
                this.GridSelectedCustomer.Rebind();
                return;
            }
            this.ProductGridSelectedCustomers.Rebind();
            this.GridAvailableCustomers.Rebind();
        }

        protected void BtnReMove_Onclick(object sender, EventArgs e)
        {
            IList<productCatelogue_Allocation.CustomaerList> allocatedCustomers = this.AllocatedCustomers;
            IList<productCatelogue_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["RemoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["RemoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        productCatelogue_Allocation.CustomaerList customers = productCatelogue_Allocation.GetCustomers(allocatedCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            this.AvailableCustomers.Add(customers);
                            allocatedCustomers.Remove(customers);
                        }
                    }
                    this.objSetting.PriceCatalogue_Allocation_Remove(Convert.ToInt32(this.productCatalogueID), this.AllocationType.ToString(), Convert.ToInt32(strArrays[i]), this.From);
                }
            }
            base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
            this.AllocatedCustomers = allocatedCustomers;
            this.AvailableCustomers = availableCustomers;
            if (this.From.ToLower() == "category")
            {
                this.GridAvailableCustomers.Rebind();
                this.GridSelectedCustomer.Rebind();
                return;
            }
            this.ProductGridSelectedCustomers.Rebind();
            this.GridAvailableCustomers.Rebind();
        }

        protected void btnReMoveExclude_Onclick(object sender, EventArgs e)
        {
            IList<productCatelogue_Allocation.CustomaerList> excludedCustomers = this.ExcludedCustomers;
            IList<productCatelogue_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["RemoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["RemoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        productCatelogue_Allocation.CustomaerList customers = productCatelogue_Allocation.GetCustomers(excludedCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            this.AvailableCustomers.Add(customers);
                            excludedCustomers.Remove(customers);
                        }
                    }
                    if (this.productCatalogueID != (long)0)
                    {
                        this.objSetting.PriceCatalogue_Allocation_Remove(Convert.ToInt32(this.productCatalogueID), this.AllocationType.ToString(), Convert.ToInt32(strArrays[i]), this.From);
                    }
                }
            }
            this.AllocatedCustomers = excludedCustomers;
            this.AvailableCustomers = availableCustomers;
            if (this.From.ToLower() == "category")
            {
                this.GridAvailableCustomers.Rebind();
                this.GridSelectedCustomer.Rebind();
                return;
            }
            this.ProductGridSelectedCustomers.Rebind();
            this.GridAvailableCustomers.Rebind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.FinalSave();
            this.popUpClose.Visible = true;
            if (this.AllocationType.ToLower() == "i")
            {
                int num = 0;
                foreach (productCatelogue_Allocation.CustomaerList allocatedCustomer in this.AllocatedCustomers)
                {
                    if (num == 0)
                    {
                        base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
                    }
                    HttpSessionState session = base.Session;
                    HttpSessionState httpSessionStates = session;
                    string str = string.Concat("AllocatedCust_", this.productCatalogueID);
                    object item = httpSessionStates[str];
                    long clientid = allocatedCustomer.Clientid;
                    session[str] = string.Concat(item, clientid.ToString(), '~');
                    string value = this.hdn_finalvalues.Value;
                    string[] strArrays = this.hdn_finalvalues.Value.Split(new char[] { '\u005E' });
                    long num1 = (long)0;
                    string str1 = "A";
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        string[] strArrays1 = strArrays[i].Split(new char[] { '\u00B6' });
                        if (strArrays1[0] != "" && strArrays1[0] != null)
                        {
                            num1 = (long)Convert.ToInt32(strArrays1[0]);
                            base.Session[string.Concat("AllocatedDeptCust_", num1)] = null;
                            str1 = strArrays1[1].ToString();
                            string str2 = strArrays1[2];
                            char[] chrArray = new char[] { ',' };
                            if ((int)str2.Split(chrArray).Length > 1 && str1.ToLower() == "s")
                            {
                                string[] strArrays2 = strArrays1[2].Split(new char[] { ',' });
                                for (int j = 0; j < (int)strArrays2.Length; j++)
                                {
                                    if (strArrays2[j] != null && strArrays2[j] != "")
                                    {
                                        HttpSessionState session1 = base.Session;
                                        HttpSessionState httpSessionStates1 = session1;
                                        string str3 = string.Concat("AllocatedDeptCust_", num1);
                                        string str4 = str3;
                                        session1[str3] = string.Concat(httpSessionStates1[str4], strArrays2[j].ToString(), ",");
                                    }
                                }
                            }
                        }
                    }
                    num++;
                }
            }
        }

        protected void btnselectallocate_OnClick(object sender, EventArgs e)
        {
            if (this.Action.ToLower() == "allocatemultiple" && this.chk_Copy.Checked)
            {
                this.hdn_iscopychecked.Value = "true";
            }
            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:AllocateCategory();", true);
        }

        public void FinalSave()
        {
            if (this.From.ToLower() != "category")
            {
                if (this.From.ToLower() == "product")
                {
                    if (this.AllocationType.ToLower() == "i")
                    {
                        foreach (productCatelogue_Allocation.CustomaerList allocatedCustomer in this.AllocatedCustomers)
                        {
                            HiddenField hdnCustomerList = this.hdn_CustomerList;
                            hdnCustomerList.Value = string.Concat(hdnCustomerList.Value, allocatedCustomer.Clientid, ",");
                        }
                    }
                    else if (this.AllocationType.ToLower() == "e")
                    {
                        foreach (productCatelogue_Allocation.CustomaerList excludedCustomer in this.ExcludedCustomers)
                        {
                            HiddenField hiddenField = this.hdn_CustomerList;
                            hiddenField.Value = string.Concat(hiddenField.Value, excludedCustomer.Clientid, ",");
                        }
                    }
                    if (this.From.ToLower() == "product" && this.Action.ToLower() == "allocatemultiple")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:assignmultiple();", true);
                        return;
                    }
                }
                else if (this.From.ToLower() == "reports")
                {
                    if (this.AllocationType.ToLower() == "i")
                    {
                        foreach (productCatelogue_Allocation.CustomaerList customaerList in this.AllocatedCustomers)
                        {
                            HiddenField hdnCustomerList1 = this.hdn_CustomerList;
                            hdnCustomerList1.Value = string.Concat(hdnCustomerList1.Value, customaerList.Clientid, ",");
                        }
                    }
                    else if (this.AllocationType.ToLower() == "e")
                    {
                        foreach (productCatelogue_Allocation.CustomaerList excludedCustomer1 in this.ExcludedCustomers)
                        {
                            HiddenField hiddenField1 = this.hdn_CustomerList;
                            hiddenField1.Value = string.Concat(hiddenField1.Value, excludedCustomer1.Clientid, ",");
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:assignReportCustomers();", true);
                }
                return;
            }
            this.hdn_CustomerList.Value = this.hdn_finalvalues.Value;
            if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
            {
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                string[] strArrays = this.CustomerValues.Split(new char[] { '~' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    this.objSetting.Category_Customer_Select((long)this.CompanyID, Convert.ToInt64(strArrays[i]));
                    if (base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])] != null)
                    {
                        string[] strArrays1 = base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])].ToString().Split(new char[] { ',' });
                        for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                        {
                            HiddenField hdnDeptallocationtype = this.hdn_deptallocationtype;
                            hdnDeptallocationtype.Value = string.Concat(hdnDeptallocationtype.Value, strArrays[i], "~*S^");
                            if (strArrays1[j].ToString() != "")
                            {
                                HiddenField hdnMovecookievalue = this.hdn_movecookievalue;
                                string value = hdnMovecookievalue.Value;
                                string[] str = new string[] { value, strArrays[i], "*~", strArrays1[j].ToString(), "^" };
                                hdnMovecookievalue.Value = string.Concat(str);
                            }
                        }
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:assigndeptval();", true);
        }

        protected IList<productCatelogue_Allocation.CustomaerList> GetAllocatedCustomers()
        {
            IList<productCatelogue_Allocation.CustomaerList> customaerLists = new List<productCatelogue_Allocation.CustomaerList>();
            DataTable dataTable = this.objSetting.PriceCatalogue_Allocation_Select(this.CompanyID, this.AllocationType, this.productCatalogueID, this.From);
            if (dataTable.Rows.Count <= 0)
            {
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                string[] strArrays = this.CustomerValues.Split(new char[] { '~' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string str = this.objSetting.Category_Customer_Select((long)this.CompanyID, Convert.ToInt64(strArrays[i]));
                    if (base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])] != null)
                    {
                        string[] strArrays1 = base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])].ToString().Split(new char[] { ',' });
                        for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                        {
                            HiddenField hdnDeptallocationtype = this.hdn_deptallocationtype;
                            hdnDeptallocationtype.Value = string.Concat(hdnDeptallocationtype.Value, strArrays[i], "~*S^");
                            if (strArrays1[j].ToString() != "")
                            {
                                HiddenField hdnMovecookievalue = this.hdn_movecookievalue;
                                string value = hdnMovecookievalue.Value;
                                string[] str1 = new string[] { value, strArrays[i], "*~", strArrays1[j].ToString(), "^" };
                                hdnMovecookievalue.Value = string.Concat(str1);
                            }
                        }
                    }
                    customaerLists.Add(new productCatelogue_Allocation.CustomaerList(Convert.ToInt64(strArrays[i]), this.objBase.SpecialDecode(str)));
                }
            }
            else
            {
                try
                {
                    for (int k = 0; k < dataTable.Columns.Count; k++)
                    {
                        dataTable.Columns[k].ReadOnly = false;
                    }
                    if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
                    {
                        this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                        string[] strArrays2 = this.CustomerValues.Split(new char[] { '~' });
                        for (int l = 0; l < (int)strArrays2.Length - 1; l++)
                        {
                            string str2 = this.objSetting.Category_Customer_Select((long)this.CompanyID, Convert.ToInt64(strArrays2[l]));
                            if (base.Session[string.Concat("AllocatedDeptCust_", strArrays2[l])] != null)
                            {
                                string[] strArrays3 = base.Session[string.Concat("AllocatedDeptCust_", strArrays2[l])].ToString().Split(new char[] { ',' });
                                for (int m = 0; m < (int)strArrays3.Length - 1; m++)
                                {
                                    HiddenField hiddenField = this.hdn_deptallocationtype;
                                    hiddenField.Value = string.Concat(hiddenField.Value, strArrays2[l], "~*S^");
                                    if (strArrays3[m].ToString() != "")
                                    {
                                        HiddenField hdnMovecookievalue1 = this.hdn_movecookievalue;
                                        string value1 = hdnMovecookievalue1.Value;
                                        string[] str3 = new string[] { value1, strArrays2[l], "*~", strArrays3[m].ToString(), "^" };
                                        hdnMovecookievalue1.Value = string.Concat(str3);
                                    }
                                }
                            }
                            customaerLists.Add(new productCatelogue_Allocation.CustomaerList(Convert.ToInt64(strArrays2[l]), this.objBase.SpecialDecode(str2)));
                        }
                    }
                    else
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["clientname"] = this.objBase.SpecialDecode(row["clientName"].ToString());
                            long num = Convert.ToInt64(row["clientID"].ToString());
                            string str4 = row["clientname"].ToString();
                            if (this.From.ToLower() == "category")
                            {
                                if (row["DepartmentAllocationType"] != null)
                                {
                                    HiddenField hdnDeptallocationtype1 = this.hdn_deptallocationtype;
                                    string value2 = hdnDeptallocationtype1.Value;
                                    string[] strArrays4 = new string[] { value2, row["clientID"].ToString(), "~*", row["DepartmentAllocationType"].ToString(), "^" };
                                    hdnDeptallocationtype1.Value = string.Concat(strArrays4);
                                    HiddenField hdnCheckallocationtype = this.hdn_checkallocationtype;
                                    string value3 = hdnCheckallocationtype.Value;
                                    string[] str5 = new string[] { value3, row["clientID"].ToString(), "$", row["DepartmentAllocationType"].ToString(), "," };
                                    hdnCheckallocationtype.Value = string.Concat(str5);
                                }
                                if (row["DepartmentValues"].ToString() != "")
                                {
                                    this.hdn_movecookievalue.Value = "";
                                    this.hdn_movecookievalue.Value = string.Concat(row["DepartmentValues"].ToString(), "^");
                                }
                            }
                            customaerLists.Add(new productCatelogue_Allocation.CustomaerList(num, str4));
                        }
                    }
                    base.Session["AllocatedCustomers"] = dataTable;
                }
                catch
                {
                    customaerLists.Clear();
                }
            }
            return customaerLists;
        }

        protected IList<productCatelogue_Allocation.CustomaerList> GetCustomers()
        {
            IList<productCatelogue_Allocation.CustomaerList> customaerLists = new List<productCatelogue_Allocation.CustomaerList>();
            DataTable dataTable = new DataTable();
            if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
            {
                dataTable = this.objSetting.Product_Customer_Select((long)this.CompanyID, (long)0, this.AllocationType, this.From);
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
            }
            else
            {
                dataTable = this.objSetting.Product_Customer_Select((long)this.CompanyID, (long)0, this.AllocationType, this.From);
                this.CustomerValues = "0";
            }
            if (this.Action.ToLower() == "edit")
            {
                dataTable = this.objSetting.Product_Customer_Select((long)this.CompanyID, this.productCatalogueID, this.AllocationType, this.From);
            }
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        dataTable.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                        long num = Convert.ToInt64(row["clientid"].ToString());
                        string str = row["clientname"].ToString();
                        if (this.CustomerValues.ToString().Contains(num.ToString()))
                        {
                            continue;
                        }
                        customaerLists.Add(new productCatelogue_Allocation.CustomaerList(num, str));
                    }
                    base.Session["PendingCustomers"] = dataTable;
                }
                catch
                {
                    customaerLists.Clear();
                }
            }
            return customaerLists;
        }

        private static productCatelogue_Allocation.CustomaerList GetCustomers(IEnumerable<productCatelogue_Allocation.CustomaerList> CustomerToSearchIn, long clientID)
        {
            productCatelogue_Allocation.CustomaerList customaerList;
            using (IEnumerator<productCatelogue_Allocation.CustomaerList> enumerator = CustomerToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    productCatelogue_Allocation.CustomaerList current = enumerator.Current;
                    if (current.Clientid != clientID)
                    {
                        continue;
                    }
                    customaerList = current;
                    return customaerList;
                }
                return null;
            }
            return customaerList;
        }

        protected IList<productCatelogue_Allocation.CustomaerList> GetExcludedCustomers()
        {
            IList<productCatelogue_Allocation.CustomaerList> customaerLists = new List<productCatelogue_Allocation.CustomaerList>();
            DataTable dataTable = this.objSetting.PriceCatalogue_Allocation_Select(this.CompanyID, this.AllocationType, this.productCatalogueID, this.From);
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        dataTable.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                        long num = Convert.ToInt64(row["clientID"].ToString());
                        string str = row["clientname"].ToString();
                        if (this.From.ToLower() == "category" && row["DepartmentValues"].ToString() != "")
                        {
                            this.hdn_movecookievalue.Value = "";
                            this.hdn_movecookievalue.Value = string.Concat(row["DepartmentValues"].ToString(), "^");
                        }
                        customaerLists.Add(new productCatelogue_Allocation.CustomaerList(num, str));
                    }
                    base.Session["ExcludedCustomers"] = dataTable;
                }
                catch
                {
                    customaerLists.Clear();
                }
            }
            return customaerLists;
        }

        protected void GridAvailableCustomers_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem parentItem = e.DetailTableView.ParentItem;
            if (e.DetailTableView.Name.ToString().ToLower() == "departmentgrid")
            {
                string str = parentItem.GetDataKeyValue("clientid").ToString();
                DataTable dataTable = WebstoreBasePage.Category_ClientDepartment_select(Convert.ToInt64(str), "");
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns["DeptName"] == null)
                    {
                        continue;
                    }
                    row["DeptName"] = this.objBase.SpecialDecode(row["DeptName"].ToString());
                }
                e.DetailTableView.DataSource = dataTable;
                ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:chkselectdept();chkselectbuffervalues();deptcheckmoved();", true);
            }
        }

        protected void GridAvailableCustomers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridAvailableCustomers.DataSource = this.AvailableCustomers;
        }

        protected void GridSelectedCustomer_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridNestedViewItem)
            {
                GridNestedViewItem item = e.Item as GridNestedViewItem;
                item.NestedViewCell.PreRender += new EventHandler(this.NestedViewCell_PreRender);
            }
        }

        protected void GridSelectedCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Panel panel = (Panel)e.Item.FindControl("pnldeptallocation");
                if (this.AllocationType.ToLower() == "e")
                {
                    if (panel != null)
                    {
                        panel.Visible = false;
                        return;
                    }
                }
                else if (this.AllocationType.ToLower() == "i" && panel != null)
                {
                    panel.Visible = true;
                }
            }
        }

        protected void GridSelectedCustomer_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.From.ToLower() == "category")
            {
                if (this.AllocationType.ToLower() == "i")
                {
                    this.GridSelectedCustomer.DataSource = this.AllocatedCustomers;
                    return;
                }
                this.GridSelectedCustomer.DataSource = this.ExcludedCustomers;
                return;
            }
            if (this.AllocationType.ToLower() == "i")
            {
                this.ProductGridSelectedCustomers.DataSource = this.AllocatedCustomers;
                return;
            }
            this.ProductGridSelectedCustomers.DataSource = this.ExcludedCustomers;
        }

        protected void GridSelectedCustomer_PreRender(object sender, EventArgs e)
        {
            foreach (object item in this.GridSelectedCustomer.MasterTableView.Items)
            {
                string[] strArrays = this.hdn_checkallocationtype.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '$' });
                    if (strArrays1[0] != "" && strArrays1[0] != null && strArrays1[1].ToString().ToLower() == "s")
                    {
                        this.GridSelectedCustomer.MasterTableView.Items[i].Expanded = true;
                    }
                }
            }
        }

        private void NestedViewCell_PreRender(object sender, EventArgs e)
        {
            ((Control)sender).Controls[0].SetRenderMethodDelegate(new RenderMethod(this.NestedViewTable_Render));
        }

        protected void NestedViewTable_Render(HtmlTextWriter writer, Control control)
        {
            control.SetRenderMethodDelegate(null);
            writer.Write("<div style='height: 150px; overflow-y: scroll; border-bottom:1px solid #828282'>");
            control.RenderControl(writer);
            writer.Write("</div>");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridSelectedCustomer.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
            GridFilterMenu gridFilterMenu = this.GridAvailableCustomers.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (gridFilterMenu.Items[j].Text == "Custom")
                {
                    gridFilterMenu.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "between")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
            }
            GridFilterMenu filterMenu1 = this.ProductGridSelectedCustomers.FilterMenu;
            for (int k = filterMenu.Items.Count - 1; k >= 0; k--)
            {
                if (filterMenu1.Items[k].Text == "Custom")
                {
                    filterMenu1.Items[k].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu1.Items[k].Text.ToLower() == "isempty")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "notisempty")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "isnull")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "notisnull")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "between")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "notbetween")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "greaterthan")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "lessthan")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu1.Items[k].Visible = false;
                }
                if (filterMenu1.Items[k].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu1.Items[k].Visible = false;
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnMove.ToolTip = this.objLanguage.GetLanguageConversion("Move");
            this.btnReMove.ToolTip = this.objLanguage.GetLanguageConversion("Remove");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Allocate");
            this.btnselectallocate.Text = this.objLanguage.GetLanguageConversion("Save_Allocate");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (base.Request.Params["from"] != null)
            {
                this.From = base.Request.Params["from"].ToString();
            }
            if (base.Request.Params["ReportIds"] != null)
            {
                this.ReportIDs = this.objBase.SpecialEncode(base.Request.Params["ReportIds"].ToString());
            }
            if (base.Request.Params["type"] != null)
            {
                this.AllocationType = base.Request.Params["type"].ToString();
            }
            if (base.Request.Params["id"] != null)
            {
                this.productCatalogueID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (base.Request.Params["action"] != null)
            {
                this.Action = base.Request.Params["action"].ToString();
            }
            if (this.AllocationType.ToLower() != "i")
            {
                if (this.From.ToLower() != "category")
                {
                    this.grd_header.InnerHtml = this.objLanguage.GetLanguageConversion("Excluded_Customers");
                }
                else
                {
                    this.grd_header.InnerHtml = this.objLanguage.GetLanguageConversion("Excluded_Customers");
                }
                this.Spn_header.InnerHtml = this.objLanguage.GetLanguageConversion("Allocated_Customers");
                this.BtnMoveExclude.Visible = true;
                this.btnReMoveExclude.Visible = true;
            }
            else
            {
                if (this.From.ToLower() != "category")
                {
                    this.grd_header.InnerHtml = this.objLanguage.GetLanguageConversion("Allocated_Customers");
                }
                else
                {
                    this.grd_header.InnerHtml = this.objLanguage.GetLanguageConversion("Allocated_Customers_Departments");
                }
                this.Spn_header.InnerHtml = this.objLanguage.GetLanguageConversion("Available_Customers");
                this.btnMove.Visible = true;
                this.btnReMove.Visible = true;
            }
            if (!base.IsPostBack)
            {
                base.Session["PendingCustomers"] = null;
                base.Session["AllocatedCustomers"] = null;
                base.Session["ExcludedCustomers"] = null;
            }
            if (this.Action.ToLower() == "allocatemultiple")
            {
                this.btnSave.Visible = false;
            }
            if (this.From.ToLower() != "category")
            {
                this.btnselectallocate.Visible = false;
            }
            else
            {
                this.btnselectallocate.Visible = true;
                this.GridSelectedCustomer.Visible = true;
                this.ProductGridSelectedCustomers.Visible = false;
            }
            if (!(this.Action.ToLower() == "allocatemultiple") || !(this.From.ToLower() == "product"))
            {
                this.btnproductsaveallocate.Visible = false;
            }
            else
            {
                this.btnproductsaveallocate.Visible = true;
            }
            if ((this.Action.ToLower() == "allocatemultiple" || this.Action.ToLower() == "allocatesingle") && this.From.ToLower() == "category")
            {
                this.div_Copy.Style.Add("display", "block");
            }
            else
            {
                this.div_Copy.Style.Add("display", "none");
            }
            if (this.AllocationType.ToLower() == "e" && this.From.ToLower() == "category")
            {
                this.pnlstyle.Visible = true;
            }
            if (this.Action.ToLower() == "allocatemultiple" && this.From.ToLower() == "reports")
            {
                this.btnproductsaveallocate.Visible = true;
            }
        }

        protected class CustomaerList
        {
            private long _Clientid;

            private string _CustomerName;

            public long Clientid
            {
                get
                {
                    return this._Clientid;
                }
            }

            public string CustomerName
            {
                get
                {
                    return this._CustomerName;
                }
            }

            public CustomaerList(long clientid, string customerName)
            {
                this._Clientid = clientid;
                this._CustomerName = customerName;
            }
        }
    }
}