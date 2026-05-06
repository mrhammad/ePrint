using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.BusinessAccessLayer;
using Printcenter.BusinessAccessLayer.Company;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Company
{
    public class DbCompany : DataAccess
    {
        public DbCompany()
        {
        }

        public virtual DataTable Account_Number_Generate(long CompanyID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ClientBankAccount_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryEstimate(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryEstimate");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryEstimate_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryEstimate_Filter");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionEstimate);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryEstimate_SplitItems(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryEstimate_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryEstimate_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryEstimate_Filter_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionEstimate);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryeStore(int CompanyID, int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryeStore");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryeStore_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryeStore_Filter");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionEstore);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryeStore_SplitItems_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryeStore_Filter_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionEstore);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryInvoice(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryInvoice");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryInvoice_Filter(int ClientID, string SalesPersonCondition, string WhereConditionInvoice)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryInvoice_Filter");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionInvoice);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryInvoice_SplitItems(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryInvoice_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryInvoice_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryInvoice_Filter_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereConditionJob", DbType.String, WhereConditionJob);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryJobs(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryJobs");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryJobs_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJobs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryJobs_Filter");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionJobs);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryJobs_SplitItems(int ClientID, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryJobs_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActiveHistoryJobs_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActiveHistoryJobs_Filter_SplitItems");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonCondition);
            database.AddInParameter(storedProcCommand, "@WhereConditionJob", DbType.String, WhereConditionJob);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void address_delete(int companyid, int addressid, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@Addressid", DbType.Int32, addressid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int address_insert(CompanyItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_insert");

            // Ticket #8781 increased time-out to fix timeout error: "when trying to add an address via a delivery note, using the pop-up dialogue box"
            storedProcCommand.CommandTimeout = 600;

            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, item.UserID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, item.ClientID);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, item.Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, item.City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, item.State);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, item.Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, item.Telephone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, item.Fax);
            database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, item.ZipCode);
            database.AddInParameter(storedProcCommand, "@Ref", DbType.String, item.Ref);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, item.Email);
            database.AddInParameter(storedProcCommand, "@IsDefaultEmail", DbType.Boolean, item.IsDefaultEmail);
            database.AddInParameter(storedProcCommand, "@IsDefaultDeliveryAddress", DbType.Boolean, item.IsDefaultDeliveryAddress);
            database.AddInParameter(storedProcCommand, "@IsDefaultBillingAddress", DbType.Boolean, item.IsDefaultBillingAddress);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.String, item.CreatedDate);
            database.AddInParameter(storedProcCommand, "@IsDefaultPostBoxAddress", DbType.Boolean, item.IsDefaultPostBoxAddress);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, item.AddressLabel);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, item.AddressLine2);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, item.URL);
            database.AddInParameter(storedProcCommand, "@isHideAddress", DbType.String, item.isHideAddress);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);

            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void address_select(int companyid, int userid, int addresssid, TextBox txtaddress, TextBox txtcity, TextBox txtstate, DropDownList ddlcountry, TextBox txttelephone, TextBox txtfax, TextBox txtzipcode, TextBox txtref, TextBox txtemail, CheckBox chkemail, CheckBox chkdelivery, CheckBox chkbilling, CheckBox chkpostbox, TextBox txt_AddressLabel, TextBox txt_addressline5, TextBox txtURL, CheckBox isHideAddress)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select_For_Edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@Addressid", DbType.Int32, addresssid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            IDataReader dataReader = database.ExecuteReader(storedProcCommand);
            string empty = string.Empty;
            while (dataReader.Read())
            {
                txtaddress.Text = baseClass.SpecialDecode(dataReader["Address"].ToString());
                txtcity.Text = baseClass.SpecialDecode(dataReader["City"].ToString());
                txtstate.Text = baseClass.SpecialDecode(dataReader["State"].ToString());
                empty = baseClass.SpecialDecode(dataReader["Country"].ToString());
                txttelephone.Text = baseClass.SpecialDecode(dataReader["Telephone"].ToString());
                txtfax.Text = baseClass.SpecialDecode(dataReader["Fax"].ToString());
                txtzipcode.Text = baseClass.SpecialDecode(dataReader["ZipCode"].ToString());
                txtref.Text = baseClass.SpecialDecode(dataReader["Ref"].ToString());
                txtemail.Text = baseClass.SpecialDecode(dataReader["Email"].ToString());
                chkemail.Checked = Convert.ToBoolean(dataReader["IsDefaultEmail"].ToString());
                chkdelivery.Checked = Convert.ToBoolean(dataReader["IsDefaultDeliveryAddress"].ToString());
                chkbilling.Checked = Convert.ToBoolean(dataReader["IsDefaultBillingAddress"].ToString());
                chkpostbox.Checked = Convert.ToBoolean(dataReader["IsDefaultPostBoxAddress"].ToString());
                txt_AddressLabel.Text = baseClass.SpecialDecode(dataReader["AddressLabel"].ToString());
                txt_addressline5.Text = baseClass.SpecialDecode(dataReader["AddressLine2"].ToString());
                txtURL.Text = baseClass.SpecialDecode(dataReader["URL"].ToString());
                if (dataReader["isHideAddress"].ToString().ToLower() != "y")
                {
                    isHideAddress.Checked = false;
                }
                else
                {
                    isHideAddress.Checked = true;
                }
            }
            storedProcCommand.Dispose();
            dataReader.Dispose();
            for (int i = 0; i < ddlcountry.Items.Count; i++)
            {
                if (ddlcountry.Items[i].Text == empty)
                {
                    ddlcountry.SelectedIndex = i;
                }
            }
        }

        public virtual DataTable address_select_For_Edit(int CompanyID, int AddressID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select_For_Edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, AddressID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.String, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void address_update(CompanyItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_update");

            // Ticket #8781 increased time-out to fix timeout error: "when trying to add an address via a delivery note, using the pop-up dialogue box"
            storedProcCommand.CommandTimeout = 600;

            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, item.UserID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, item.ClientID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, item.AddressID);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, item.Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, item.City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, item.State);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, item.Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, item.Telephone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, item.Fax);
            database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, item.ZipCode);
            database.AddInParameter(storedProcCommand, "@Ref", DbType.String, item.Ref);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, item.Email);
            database.AddInParameter(storedProcCommand, "@IsDefaultEmail", DbType.Boolean, item.IsDefaultEmail);
            database.AddInParameter(storedProcCommand, "@IsDefaultDeliveryAddress", DbType.Boolean, item.IsDefaultDeliveryAddress);
            database.AddInParameter(storedProcCommand, "@IsDefaultBillingAddress", DbType.Boolean, item.IsDefaultBillingAddress);
            database.AddInParameter(storedProcCommand, "@IsDefaultPostBoxAddress", DbType.Boolean, item.IsDefaultPostBoxAddress);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, item.AddressLabel);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, item.AddressLine2);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, item.URL);
            database.AddInParameter(storedProcCommand, "@isHideAddress", DbType.String, item.isHideAddress);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Campaign_customview_count(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Campaign_customview_count");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int Check_Dept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Check_Dept_Duplicacy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@DeptName", DbType.String, DeptName);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int32, DeptID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int Check_Cost_Centre_Duplicacy(int CompanyID, int ClientID, string Code, int CostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Check_Cost_Centre_Duplicacy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Code", DbType.String, Code);
            database.AddInParameter(storedProcCommand, "@CostID", DbType.Int32, CostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicacy_for_Account");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, Client_ID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, Contact_ID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int Check_EmailID_Duplicate_for_Account(string EmailID, long Client_ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicate_for_Account");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, Client_ID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicacy");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable client_contact_selectnew(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Contact_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable client_contacts_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contacts_select");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@clientid", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Selectall", DbType.String, "Yes");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet client_contacts_select_for_filter(int CompanyID, int ClientID, int pageno, int pagesize, string WhereConditionContact)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataset = new DataSet();
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contacts_select_for_filter");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@clientid", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, pageno);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, pagesize);
            database.AddInParameter(storedProcCommand, "@Selectall", DbType.String, "Yes");
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionContact);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                //dataTable.Load(dataReader);
                //dataset.Tables.Add(dataTable);
                do
                {
                    var table = new DataTable();
                    table.Load(dataReader);
                    dataset.Tables.Add(table);
                }
                while (!dataReader.IsClosed);

            }

            return dataset;
        }

        public virtual DataTable client_contacts_select_Praveen(int CompanyID, int ClientID)
        {
            string str = string.Concat("client_contacts", CompanyID);
            DataTable item = HttpContext.Current.Cache[str] as DataTable;
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_client_contacts_select", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@clientid", ClientID);
            sqlCommand.Parameters.AddWithValue("@Selectall", "Yes");
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            item = dataTable;
            SqlCacheDependency sqlCacheDependency = new SqlCacheDependency(sqlCommand);
            HttpContext.Current.Cache.Insert(str, item, sqlCacheDependency);
            return item;
        }

        public virtual void client_defaultcontact(int CompanyID, int ClientID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_defaultcontact");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Client_GetLast_Account(int CompanyID, string CompanyType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Client_GetLast_Account");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Client_ReferencedBy_Insert(int CompanyID, int retClientID, string ReferencedBy, int ReferencedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Client_ReferencedBy_Insert_ReEng");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, retClientID);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, ReferencedBy);
            database.AddInParameter(storedProcCommand, "@ReferencedID", DbType.Int32, ReferencedID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable Clientaddresslabels(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_clientaddresslabels");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable ClientReferencedByName_Select(string Name, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ClientReferencedByName_Select");
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, Name);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_activityhistory_select(int CompanyID, int CustomerID, string SearchText, string ModuleType, string DateType, string FromDate, string ToDate)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_company_activityhistory_select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
            sqlCommand.Parameters.AddWithValue("@SearchText", SearchText);
            sqlCommand.Parameters.AddWithValue("@ModuleType", ModuleType);
            sqlCommand.Parameters.AddWithValue("@DateType", DateType);
            sqlCommand.Parameters.AddWithValue("@FromDate", FromDate);
            sqlCommand.Parameters.AddWithValue("@ToDate", ToDate);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            DataTable dataTable = new DataTable();
            return dataSet.Tables[1];
        }

        public virtual DataTable company_address_select(int ClientID, int CompanyID, string SelectAll)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SelectAll", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_address_select_one(int CompanyID, int AddressID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select_one");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, AddressID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_autocomplete(int CompanyID, string CompanyType, string ClientName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_autocomplete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ClientName", DbType.String, ClientName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_carrier_supplier_select(int companyid, DropDownList ddlsupplier)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_carrier_supplier_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                dataSet.Tables[0].Columns[i].ReadOnly = false;
            }
            if (dataSet.Tables[0] != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (!row.Table.Columns.Contains("ClientName"))
                    {
                        continue;
                    }
                    row["ClientName"] = baseClass.SpecialDecode(row["ClientName"].ToString());
                }
            }
            ddlsupplier.DataSource = dataSet;
            ddlsupplier.DataTextField = "clientname";
            ddlsupplier.DataValueField = "clientid";
            ddlsupplier.DataBind();
            ddlsupplier.Items.Insert(0, " ");
            ddlsupplier.Items[0].Text = "--- Select ---";
            ddlsupplier.Items[0].Value = "0";
            storedProcCommand.Dispose();
        }

        public virtual DataTable company_client_address_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_address_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_client_alladdress_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_alladdress_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_client_alladdress_select_clientname(int CompanyID, int ClientID, string ClientAddress)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_alladdress_select_clientname");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, ClientAddress);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_client_alladdress_select_split(int CompanyID, int ClientID, string FreeText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_alladdress_select_split");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Freetext", DbType.String, FreeText);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_client_defaultaddresstype_update(int CompanyID, int ClientID, string IsDelOrInv, string DefaultType, int DefaultID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_defaultaddresstype_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@IsDelOrInv", DbType.String, IsDelOrInv);
            database.AddInParameter(storedProcCommand, "@DefaultType", DbType.String, DefaultType);
            database.AddInParameter(storedProcCommand, "@DefaultID", DbType.Int32, DefaultID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable company_client_defaultdeliverytype_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_defaultdeliverytype_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_client_delete(int CompanyID, int ClientID)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void company_client_email_delete(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_email_temp_data_delete");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void company_client_email_insert(int UserID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_email_temp_data_insert");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable company_client_email_select(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_email_temp_data_select");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string company_client_fax_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_fax_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable company_client_For_subsection(int CompanyID, int ClientID, string CompanyType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_company_client_For_subsection");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int company_client_insert(int CompanyID, int ClientID, string Query, bool IsDefaultDeliveryAddress, bool IsDefaultInvoiceAddress)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.AddInParameter(storedProcCommand, "@IsDefaultDeliveryAddress", DbType.Boolean, IsDefaultDeliveryAddress);
            database.AddInParameter(storedProcCommand, "@IsDefaultInvoiceAddress", DbType.Boolean, IsDefaultInvoiceAddress);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? 0 : int.Parse(obj.ToString()));
        }

        public virtual DataTable company_InvoiceContact_select(int CompanyID, int EstID, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_company_invoiceContact_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, type);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_client_select(int CompanyID, int ClientID, string CompanyType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_company_client_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string company_contact_address_select(int CompanyID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_address_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual bool HasInvoiceContact(int CompanyID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoiceContact_Check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable company_contact_address_select_new(int CompanyID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_address_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_contact_address_selectall(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_address_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_contact_address_selectall_new(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_address_selectall_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_contact_deladdr_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_deladdr_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_contact_delete(int CompanyID, int ClientID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int company_contact_insert(int CompanyID, int ClientID, int ContactID, string Query, bool DefaultContact, bool DefaultDeliveryAddress, bool DefaultInvoiceAddress)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.AddInParameter(storedProcCommand, "@DefaultContact", DbType.Boolean, DefaultContact);
            database.AddInParameter(storedProcCommand, "@DefaultDeliveryAddress", DbType.Boolean, DefaultDeliveryAddress);
            database.AddInParameter(storedProcCommand, "@DefaultInvoiceAddress", DbType.Boolean, DefaultInvoiceAddress);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? 0 : int.Parse(obj.ToString()));
        }

        public virtual DataTable company_contact_select(int CompanyID, int ContactID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contact_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_contacts_byid_select(int CompanyID, int ClientID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contacts_byid_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_company_contactByContactId_select(int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_contactByContactId_select");

            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_company_StoreCredit_select(int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_StoreCredit_select");

            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable company_contacts_select(int CompanyID, int ClientID, string SelectAll)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contacts_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@SelectAll", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void company_convert_to_customer(int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_conver_to_customer");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void company_country_select(DropDownList ddlcountry)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_country_select");
            IDataReader dataReader = database.ExecuteReader(storedProcCommand);
            ddlcountry.DataSource = dataReader;
            ddlcountry.DataTextField = "Countryname";
            ddlcountry.DataValueField = "Countryid";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, "");
            ddlcountry.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
            ddlcountry.Items[0].Value = "0";
            storedProcCommand.Dispose();
            dataReader.Dispose();
        }

        public virtual DataTable company_customer_autocomplete(int CompanyID, string ClientName, string isDisplaySupplier)
        {
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DataTable dataTable = new DataTable();

                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customer_autocomplete");
                storedProcCommand.CommandTimeout = Int32.MaxValue;

                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
                database.AddInParameter(storedProcCommand, "@ClientName", DbType.String, ClientName);
                database.AddInParameter(storedProcCommand, "@isDisplaySupplier", DbType.String, isDisplaySupplier);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public virtual void company_customer_bind(int companyid, DropDownList ddlcustomer)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customer_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            ddlcustomer.DataSource = database.ExecuteDataSet(storedProcCommand);
            ddlcustomer.DataTextField = "clientname";
            ddlcustomer.DataValueField = "clientid";
            ddlcustomer.DataBind();
            ddlcustomer.Items.Insert(0, " ");
            ddlcustomer.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
            ddlcustomer.Items[0].Value = "0";
            storedProcCommand.Dispose();
        }

        public virtual DataTable company_customer_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customer_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable company_customer_select_by_clientID(int CompanyID, long ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customer_select_by_clientid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual string company_customizedvalue_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customizedvalue_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable company_customizefield_select(string pg, int CompanyID, int UserID, int CustomizeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_customizefield_select");
            database.AddInParameter(storedProcCommand, "@pg", DbType.String, pg);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CustomizeID", DbType.Int32, CustomizeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Company_InsertUpdate(int CompanyID, int ClientID, string CompanyType, string ClientName, string ClientAlias, string Type, string AccountStatus, string AccountNumber, string BusinessEmail, string WebSite, string CreditLimit, string CreditRef, int Tax1, int Tax2, string TaxRegNo, string PaymentTerms, string CompanyNumber, string ProfitMargin, DateTime AcOpened, string BankCode, string BankAccountNumber, string AccountName, int SalesPerson, string TaxNumber, string Balance, string Description, DateTime ModifiedDate, int ModifyUserId, int ReferencedID, int iscarrier, bool RoyalityFree, string ClientTypeID, string ClientType, bool TaxPrecedence)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Company_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@ClientName", DbType.String, ClientName);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ClientAlias", DbType.String, ClientAlias);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@AccountStatus", DbType.String, AccountStatus);
            database.AddInParameter(storedProcCommand, "@AccountNumber", DbType.String, AccountNumber);
            database.AddInParameter(storedProcCommand, "@BusinessEmail", DbType.String, BusinessEmail);
            database.AddInParameter(storedProcCommand, "@WebSite", DbType.String, WebSite);
            database.AddInParameter(storedProcCommand, "@CreditLimit", DbType.String, CreditLimit);
            database.AddInParameter(storedProcCommand, "@CreditRef", DbType.String, CreditRef);
            database.AddInParameter(storedProcCommand, "@Tax1", DbType.Int32, Tax1);
            database.AddInParameter(storedProcCommand, "@Tax2", DbType.Int32, Tax2);
            database.AddInParameter(storedProcCommand, "@TaxRegNo", DbType.String, TaxRegNo);
            database.AddInParameter(storedProcCommand, "@PaymentTerms", DbType.String, PaymentTerms);
            database.AddInParameter(storedProcCommand, "@CompanyNumber", DbType.String, CompanyNumber);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.String, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@AcOpened", DbType.DateTime, AcOpened);
            database.AddInParameter(storedProcCommand, "@BankCode", DbType.String, BankCode);
            database.AddInParameter(storedProcCommand, "@BankAccountNumber", DbType.String, BankAccountNumber);
            database.AddInParameter(storedProcCommand, "@AccountName", DbType.String, AccountName);
            database.AddInParameter(storedProcCommand, "@SalesPerson", DbType.Int32, SalesPerson);
            database.AddInParameter(storedProcCommand, "@TaxNumber", DbType.String, TaxNumber);
            database.AddInParameter(storedProcCommand, "@Balance", DbType.String, Balance);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ModifyUserId", DbType.Int32, ModifyUserId);
            database.AddInParameter(storedProcCommand, "@ReferencedID", DbType.Int32, ReferencedID);
            database.AddInParameter(storedProcCommand, "@Iscarrier", DbType.Int32, iscarrier);
            database.AddInParameter(storedProcCommand, "@RoyalityFree", DbType.Boolean, RoyalityFree);
            database.AddInParameter(storedProcCommand, "@ClientTypeID", DbType.String, ClientTypeID);
            database.AddInParameter(storedProcCommand, "@ClientType", DbType.String, ClientType);
            database.AddInParameter(storedProcCommand, "@TaxPrecedence", DbType.Boolean, TaxPrecedence);


            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable company_logo_select(int CompanyID, string LogoType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_company_logo_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, LogoType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_ownership_customer_bind(int companyid, string companytype, DropDownList ddlAccount)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ClientName_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@Companytype", DbType.String, companytype);
            IDataReader dataReader = database.ExecuteReader(storedProcCommand);
            ddlAccount.DataSource = dataReader;
            ddlAccount.DataTextField = "ClientName";
            ddlAccount.DataValueField = "ClientID";
            ddlAccount.DataBind();
            ddlAccount.Items.Insert(0, " ");
            ddlAccount.Items[0].Text = "--- Select ---";
            ddlAccount.Items[0].Value = "0";
            storedProcCommand.Dispose();
            dataReader.Dispose();
        }

        public virtual DataTable company_prospect_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_prospect_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_prospect_to_customer(int CompanyID, int Clientid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_prospect_to_customer");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Clientid", DbType.Int32, Clientid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet company_select(int CompanyID, string companytype)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_company_select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@companytype", companytype);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable company_select_By_ID(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_select_By_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@clientid", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_supplier_select(int companyid, DropDownList ddlsupplier)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_supplier_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                dataSet.Tables[0].Columns[i].ReadOnly = false;
            }
            if (dataSet.Tables[0] != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (!row.Table.Columns.Contains("clientname"))
                    {
                        continue;
                    }
                    row["clientname"] = baseClass.SpecialDecode(row["clientname"].ToString());
                }
            }
            ddlsupplier.DataSource = dataSet;
            ddlsupplier.DataTextField = "clientname";
            ddlsupplier.DataValueField = "clientid";
            ddlsupplier.DataBind();
            ddlsupplier.Items.Insert(0, " ");
            ddlsupplier.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
            ddlsupplier.Items[0].Value = "0";
            storedProcCommand.Dispose();
        }

        public virtual DataTable company_supplierddl_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_supplier_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void CompanyAddress_Update(long CompanyID, string Type, long ClientID, long ContactID, long InvoiceAddressID, int IsDefaultDelivery, int IsDefaultInvoice, long DeliveryAddressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CompanyAddress_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int64, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@IsDefaultDelivery", DbType.Int32, IsDefaultDelivery);
            database.AddInParameter(storedProcCommand, "@IsDefaultInvoice", DbType.Int32, IsDefaultInvoice);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long CompanyDefaultAddress_InsertUpdate(long AddressID, long ClientID, string Address, string City, string State, string ZipCode, string Country, string Telephone, string Fax, string URL, int CreatedUserID, string CreatedDate, string AddressLabel, string AddressLine2, string Email, string IsHideAddress)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CompanyDefaultAddress_InsertUpdate");

            // Ticket #8781 increased time-out to fix timeout error: "when trying to add an address via a delivery note, using the pop-up dialogue box"
            storedProcCommand.CommandTimeout = 600;

            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
            database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, ZipCode);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, URL);
            database.AddInParameter(storedProcCommand, "@CreatedUserID", DbType.Int32, CreatedUserID);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.String, CreatedDate);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@IsHideAddress", DbType.String, IsHideAddress);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable contact_default_info(int CompanyID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_contact_default_info");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void contact_delete(int companyid, string contactids, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contact_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@ContactIDs", DbType.String, contactids);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Contact_InsertUpdate(int CompanyID, int ContactID, int ClientID, string Salutation, string FirstName, string MiddleName, string LastName, string ContactAlias, string CompanyName, string JobTitle, string JobTitle2, string HomeTelephone, string Mobile, string Email, int ReportToUserID, int CreateUserID, long DepartmentID, string PersonalFax, int ContactAddressID, bool MainApprover, int ChkSubscribed, int IsReceiveMailOut, string AlternateNumbers, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, string ActualFilename, string OriginalFileName, bool IsPdf, DateTime TodaysDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Contact_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Salutation", DbType.String, Salutation);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@MiddleName", DbType.String, MiddleName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@ContactAlias", DbType.String, ContactAlias);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@JobTitle", DbType.String, JobTitle);
            database.AddInParameter(storedProcCommand, "@JobTitle2", DbType.String, JobTitle2);
            database.AddInParameter(storedProcCommand, "@HomeTelephone", DbType.String, HomeTelephone);
            database.AddInParameter(storedProcCommand, "@Mobile", DbType.String, Mobile);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@ReportToUserID", DbType.Int32, ReportToUserID);
            database.AddInParameter(storedProcCommand, "@CreateUserID", DbType.Int32, CreateUserID);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.AddInParameter(storedProcCommand, "@PersonalFax", DbType.String, PersonalFax);
            database.AddInParameter(storedProcCommand, "@ContactAddressID", DbType.Int32, ContactAddressID);
            database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int32, ChkSubscribed);
            database.AddInParameter(storedProcCommand, "@MainApprover", DbType.Boolean, MainApprover);
            database.AddInParameter(storedProcCommand, "@IsReceiveMailOut", DbType.Int32, IsReceiveMailOut);
            database.AddInParameter(storedProcCommand, "@AlternateNumbers", DbType.String, AlternateNumbers);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, CustomField1);
            database.AddInParameter(storedProcCommand, "@CustomField2", DbType.String, CustomField2);
            database.AddInParameter(storedProcCommand, "@CustomField3", DbType.String, CustomField3);
            database.AddInParameter(storedProcCommand, "@CustomField4", DbType.String, CustomField4);
            database.AddInParameter(storedProcCommand, "@CustomField5", DbType.String, CustomField5);
            database.AddInParameter(storedProcCommand, "@CustomField6", DbType.String, CustomField6);
            database.AddInParameter(storedProcCommand, "@CustomField7", DbType.String, CustomField7);
            database.AddInParameter(storedProcCommand, "@CustomField8", DbType.String, CustomField8);
            database.AddInParameter(storedProcCommand, "@CustomField9", DbType.String, CustomField9);
            database.AddInParameter(storedProcCommand, "@CustomField10", DbType.String, CustomField10);
            database.AddInParameter(storedProcCommand, "@CustomField11", DbType.String, CustomField11);
            database.AddInParameter(storedProcCommand, "@CustomField12", DbType.String, CustomField12);
            database.AddInParameter(storedProcCommand, "@CustomField13", DbType.String, CustomField13);
            database.AddInParameter(storedProcCommand, "@CustomField14", DbType.String, CustomField14);
            database.AddInParameter(storedProcCommand, "@CustomField15", DbType.String, CustomField15);
            database.AddInParameter(storedProcCommand, "@ActualFilename", DbType.String, ActualFilename);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@IsPdf", DbType.Boolean, IsPdf);
            database.AddInParameter(storedProcCommand, "@TodaysDate", DbType.DateTime, DateTime.Now);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void Contact_or_Dept_SpendLimitUpdate(int CompanyID, long ContactId, string Duration, decimal Amount, string Type, Boolean EnableRollOver, string RollOverLimit, DateTime RollOverStart)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_SpendAmountDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.String, ContactId);
            database.AddInParameter(storedProcCommand, "@SpendLimitPeriod", DbType.String, Duration);
            database.AddInParameter(storedProcCommand, "@SpendLimitAmount", DbType.Decimal, Amount);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@EnableRollOver", DbType.Boolean, EnableRollOver);
            database.AddInParameter(storedProcCommand, "@RollOverLimit", DbType.String, RollOverLimit);
            database.AddInParameter(storedProcCommand, "@RollOverStart", DbType.DateTime, RollOverStart);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void StoreCreditUpdate(int CompanyID, long ContactId, Double StoreCredit)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_StoreCredit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.String, ContactId);
            database.AddInParameter(storedProcCommand, "@StoreCredit", DbType.String, StoreCredit);

            database.ExecuteNonQuery(storedProcCommand);
        }
        

        public virtual void contact_Subscribe_Unsubscribe(int companyid, string contactids, int userid, bool IsSubscribe, DateTime TodaysDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contact_Subscribe");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@ContactIDs", DbType.String, contactids);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.AddInParameter(storedProcCommand, "@IsSubscribe", DbType.Boolean, IsSubscribe);
            database.AddInParameter(storedProcCommand, "@TodaysDate", DbType.DateTime, TodaysDate);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable contactcustomfields(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_contactcustomfields");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ContactCustomFields_ScreenName_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ContactCustomFields_ScreenName_Select");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUser");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@IsPsw", DbType.String, IsPsw);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int64, subscribe_newsletter);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void crm_clientType_add(long CompanyID, long ClientID, long TypeID, string ClientType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ClientType_Insert");
            database.AddInParameter(storedProcCommand, "@ClientID ", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@ClientType", DbType.String, ClientType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void crm_common_attachment_add(int CompanyID, string SectionName, int SectionID, string FileName, string FileSize, DateTime CreateDate, DateTime ModifiedDate, int CreateUserID, int ModifyUserID, string Subject, string Title)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_attachment_add");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, SectionName);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, SectionID);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, FileSize);
            database.AddInParameter(storedProcCommand, "@createDate", DbType.DateTime, CreateDate);
            database.AddInParameter(storedProcCommand, "@modifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, CreateUserID);
            database.AddInParameter(storedProcCommand, "@modifyUserId", DbType.Int32, ModifyUserID);
            database.AddInParameter(storedProcCommand, "@isDelete", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, Title);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void crm_common_attachment_delete(int AttachmentID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_attachment_delete");
            database.AddInParameter(storedProcCommand, "@attachmentid", DbType.Int32, AttachmentID);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable crm_common_attachment_detail(int CompanyID, int AttachmentID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_attachment_detail");
            database.AddInParameter(storedProcCommand, "@attachmentid", DbType.Int32, AttachmentID);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void crm_common_attachment_edit(int CompanyID, int AttachmentID, string FileName, string FileSize, DateTime ModifiedDate, int ModifyUserID, string Subject, string Title)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_attachment_edit");
            database.AddInParameter(storedProcCommand, "@attachmentid", DbType.Int32, AttachmentID);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, FileSize);
            database.AddInParameter(storedProcCommand, "@modifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@modifyUserID", DbType.Int32, ModifyUserID);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, Title);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void crm_common_email_delete(string pg, int sl, int Client, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_email_delete");
            database.AddInParameter(storedProcCommand, "@pg", DbType.String, pg);
            database.AddInParameter(storedProcCommand, "@sl", DbType.Int32, sl);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, Client);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable crm_common_select_accessrightOfUserType(int companyid, int usertypeid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_select_accessrightOfUserTypeOnlyChecked");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@usertypeid", DbType.Int64, usertypeid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable crm_common_select_all_email_new(int CompanyID, int ClientID, string SelectAll)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_select_all_email_new");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Selectall", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("TO"))
                    {
                        continue;
                    }
                    row["TO"] = baseClass.SpecialDecode(row["TO"].ToString());
                }
            }
            return dataTable;
        }

        public virtual DataTable crm_common_select_all_email_new_filter(int CompanyID, int ClientID, string SelectAll, string WhereCondition)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Common_Select_All_Email_Filter");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Selectall", DbType.String, SelectAll);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("TO"))
                    {
                        continue;
                    }
                    row["TO"] = baseClass.SpecialDecode(row["TO"].ToString());
                }
            }
            return dataTable;
        }

        public virtual DataTable crm_common_select_attachment(int ClientID, string SectionName, int CompanyID, string SelectAll)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_select_attachment");
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, SectionName);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Selectall", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable crm_select_HeaderImage_new1(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_select_HeaderImage_new1");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@userID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@selectedSection", DbType.String, "");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Customer_code_select(int companyid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_customer_code_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Customer_COde_Update(int companyid, long LastCount)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_customer_code_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@LastCount", DbType.Int64, LastCount);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Customer_Company_Select(int companyid, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_customer_company_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Customer_Products_Select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Customer_Products_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Customer_Products_Select_Filter(int CompanyID, int ClientID, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Customer_Products_Select_Filter");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Deactivate_SpendLimitUser(int CompanyID, string IDs, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Deactivate_SpendLimit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@IDs", DbType.String, IDs);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void Deactivate_StoreCredit(int CompanyID, string IDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Deactivate_StoreCredit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@IDs", DbType.String, IDs);
            
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual string default_address_select(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_default_address_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void default_delivery_address_update(int CompanyID, int ClientID, int CommonID, string AddressType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_default_delivery_address_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CommonID", DbType.Int32, CommonID);
            database.AddInParameter(storedProcCommand, "@AddressType", DbType.String, AddressType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Delivery_Address_Select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Delivery_Address_Select");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable departmentcustomfields(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_departmentcustomfields");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet eprintreport_select(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("pc_SelectEstimate_eprintReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Get_AccountName(int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_GetAccountName");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_B2bAccountName(int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_GetAccountName");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string get_module_number(int CompanyID, string pagename, int moduleid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_module_number");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@pagename", DbType.String, pagename);
            database.AddInParameter(storedProcCommand, "@moduleid", DbType.Int32, moduleid);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet GetDeptAddressDetails(int CompanyID, int DeptID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_GetDeptAddressDetails", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@DeptID", DeptID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable getEstimateTitle_autofill(int CompanyID, string SearchParameter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ItemTitle_AutoComplete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, "Estimate Title");
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, SearchParameter);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetImageNames_CopyTemplates(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetImageNameFor_TemplateCopy");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable getItemtitleItemcode_autofill(int CompanyID, string SearchParameter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductItemCodeTitle_AutoComplete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchParameter", DbType.String, SearchParameter);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable getOldPDFName_CopyTemplates(long PriceCatalogueID, long NewPriceCatalogueID, string _newpdfnameforcopied)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetPDFNameFor_TemplateCopy");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NewPriceCatalogueID", DbType.Int32, NewPriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NewPDFName", DbType.String, _newpdfnameforcopied);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable getwarehouselocation_autofill(int CompanyID, string SearchParameter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouseLocation_AutoComplete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LocationName", DbType.String, SearchParameter);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_BillingShipping_Address");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
            database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
            database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
            database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
            database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
            database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Int16, IsDefaultBilling);
            database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Int16, IsDefaultShipping);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable InvoiceReportGenrated_select()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("PC_InvoiceReportGenrated_select")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void MailChimp_Insert(int CompanyID, string MailChimpAPIKey, string MailChimpListId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_MailchimpIntegration");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@MailChimpAPIKey", DbType.String, MailChimpAPIKey);
            database.AddInParameter(storedProcCommand, "@MailChimpListId", DbType.String, MailChimpListId);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable main_company_address_select(int ClientID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_main_company_address_select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable main_company_address_select_new(int ClientID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_main_company_address_select_new");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        

        public virtual string main_company_salesperson_select(int ClientID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_main_company_salesperson_select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string main_company_invoicecontact_select(int ClientID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_main_company_invoicecontact_select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public string Measurment(int CompanyID)
        {
            string str = "";
            DataTable dataTable = new DataTable();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_PaperStockMeasure_Type");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                str = dataTable.Rows[0][0].ToString();
            }
            catch (Exception exception)
            {
            }
            return str;
        }

        public virtual DataTable PreflightProfile_Select()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("PC_PreflightProfile_Select")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int pricecatalogueTemplate_ToanotherSystem_copy(string ServerName, long PriceCatalogueID, string FromSystem, string ToSystem, long FromCompanyid, long ToCompanyid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_pricecatalogueTemplate_ToanotherSystem_copy");
            database.AddInParameter(storedProcCommand, "@ServerName", DbType.String, ServerName);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@FromSystem", DbType.String, FromSystem);
            database.AddInParameter(storedProcCommand, "@ToSystem", DbType.String, ToSystem);
            database.AddInParameter(storedProcCommand, "@FromCompanyid", DbType.Int64, FromCompanyid);
            database.AddInParameter(storedProcCommand, "@ToCompanyid", DbType.Int64, ToCompanyid);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Select_BillingShipping_Address(long StoreUserID, string type, long DefaultBillingID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_BillingShipping_Address");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@StoreContactID", DbType.Int64, DefaultBillingID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Isadmin(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Isadmin");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet selectall_AddressValue_FromSetting(int CompanyID)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_AddressValue_FromSetting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataTable selectall_MailchimpIntegration(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_MailchimpIntegration_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void SetDefaultAddressID(int ClientID, int SetDefault_AddressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SetDefaultAddressID");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, SetDefault_AddressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long settings_lastcounter_select(int CompanyID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lastcounter_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void settings_lastcounter_update(int CompanyID, string ModuleType, long LastCounter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lastcounter_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@LastCounter", DbType.Int64, LastCounter);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void StoreUser_AccountIsActivate(int CompanyID, int ContactID, int Isactive)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_StoreUser_AccountIsActivate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@Isactive", DbType.Int32, Isactive);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable StoreUser_select(long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_StoreUser_select");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_ContactID_ForB2B(long StoreUserID, long DefaultBillingID, long DefaultShippingID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ContactID_ForB2B");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@DefaultBillingID", DbType.Int64, DefaultBillingID);
            database.AddInParameter(storedProcCommand, "@DefaultShippingID", DbType.Int64, DefaultShippingID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Updatecontactcustomfields(int CompanyID, int LabelID, string ScreenName)
        {
            SqlCommand sqlCommand = new SqlCommand("pc_Update_contactcustomfields", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", CompanyID);
            sqlCommand.Parameters.Add("@labelID", LabelID);
            sqlCommand.Parameters.Add("@ScreenName", ScreenName);
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateDepartmentcustomfields(int CompanyID, int LabelID, string ScreenName)
        {
            SqlCommand sqlCommand = new SqlCommand("pc_Update_departmentcustomfields", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@CompanyID", CompanyID);
            sqlCommand.Parameters.Add("@labelID", LabelID);
            sqlCommand.Parameters.Add("@ScreenName", ScreenName);
            sqlCommand.ExecuteNonQuery();
        }

        public virtual void UpdateImageName_CopyTemplates(long New_PriceCatalogueID, string ControlID, string _newimgname)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateImageNameFor_Copy");
            database.AddInParameter(storedProcCommand, "@New_PriceCatalogueID", DbType.Int32, New_PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@ObjectID", DbType.String, ControlID);
            database.AddInParameter(storedProcCommand, "@ImageUrl", DbType.String, _newimgname);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int UserCheck_forSupportTeam(int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UserCheck_forSupportTeam");
            database.AddInParameter(storedProcCommand, "@userID", DbType.Int32, userid);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void View_Delete(int CompanyID, string PageName, long ViewID, int UserID, string KeyName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_View_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@pg", DbType.String, PageName);
            database.AddInParameter(storedProcCommand, "@ViewID", DbType.Int64, ViewID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@KeyName", DbType.String, KeyName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet ViewContacts(int CompanyID, string Selectall, string para, int PageNumber, int PageSize, string SortBy, string SortDirection)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_client_contacts_select_all", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@Selectall", Selectall);
            sqlCommand.Parameters.AddWithValue("@para", para);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@SortColumn", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }
    }
}