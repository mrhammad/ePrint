using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.FileIO;
using nmsCommon;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.contact
{
    public partial class contact_imports : /*System.Web.UI.Page,*/BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();
        public string strImagepath = global.imagePath();
        private Global gloobj = new Global();
        public string pg;
        private int CompanyID;

        protected void Btn_Import(Object sender, EventArgs e)
        {
            if (fileCsv.HasFiles)
            {
                List<string> listA = new List<string>();
                long number1 = 0;
                using (TextFieldParser parser = new TextFieldParser(fileCsv.FileContent))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        int isInsert = 0;
                        //Processing row
                        string[] fields = parser.ReadFields();

                        if (fields[0] != "" && fields[0] != "Company Name")
                        {
                            int companyID;
                            int UserID;

                            companyID = Convert.ToInt32(base.Session["companyID"].ToString());
                            UserID = Convert.ToInt32(base.Session["UserID"].ToString());

                            if (fields != null && fields.Length > 0)
                            {
                                DataTable datatable1 = new DataTable();
                                DataTable dataTable2 = new DataTable();
                                int email_count;
                                datatable1 = GetByUserIDAndCompanyName(companyID, fields[0]);
                                email_count = CheckContactEmail(companyID, fields[0], fields[10]);
                                if (datatable1.Rows.Count > 0)
                                {

                                    #region "Insert or update customer contacts"

                                    int clientID = Convert.ToInt32(datatable1.Rows[0]["clientID"]);
                                    string companyName = fields[0];
                                    string contactTitle = fields[1];
                                    string contactFirstName = fields[2];
                                    string contactMiddleName = fields[3];
                                    string contactLastName = fields[4];
                                    string defaultContact = fields[5];
                                    string department = fields[6];
                                    string jobTitle = fields[7];
                                    string contactPhone = fields[8];
                                    string contactMobile = fields[9];
                                    string contactEmail = fields[10];
                                    string contactFax = fields[11];
                                    string alternateNumber = fields[12];
                                    string mainApprover = fields[13];
                                    string subscribeNewsletter = fields[14];
                                    string receiveMailOut = fields[15];
                                    string contactCustomerField1 = fields[16];
                                    string contactCustomerField2 = fields[17];
                                    string contactCustomerField3 = fields[18];
                                    string contactCustomerField4 = fields[19];
                                    string contactCustomerField5 = fields[20];
                                    string contactCustomerField6 = fields[21];
                                    string contactCustomerField7 = fields[22];
                                    string contactCustomerField8 = fields[23];
                                    string contactCustomerField9 = fields[24];
                                    string contactCustomerField10 = fields[25];
                                    string contactCustomerField11 = fields[26];
                                    string contactCustomerField12 = fields[27];
                                    string contactCustomerField13 = fields[28];
                                    string contactCustomerField14 = fields[29];
                                    string contactCustomerField15 = fields[30];
                                    string IsB2BUser = fields[39];
                                    string isSingleLogin = fields[40];
                                    string contactAddressLabel = fields[41];
                                    string B2BPassword = fields[42];
                                    int contactid_returned=0;
                                    if (email_count == 0)
                                    {
                                        contactid_returned=InsertUpdateCustomerContact(companyID, UserID, clientID, companyName, contactTitle, contactFirstName, contactMiddleName, contactLastName, defaultContact, department, jobTitle, contactPhone, contactMobile, contactEmail, contactFax, alternateNumber, mainApprover, subscribeNewsletter, receiveMailOut, contactCustomerField1, contactCustomerField2, contactCustomerField3, contactCustomerField4, contactCustomerField5, contactCustomerField6, contactCustomerField7, contactCustomerField8, contactCustomerField9, contactCustomerField10, contactCustomerField11, contactCustomerField12, contactCustomerField13, contactCustomerField14, contactCustomerField15,/* contactAddressLine1, contactAddressLine2, contactAddressCity, contactAddressState, contactAddressPostCode, contactAddressCountry, contactAddressTelephone, contactAddressFax, */IsB2BUser, isSingleLogin, contactAddressLabel, B2BPassword,"Insert");

                                    }
                                    else
                                    {
                                        dataTable2 = GetContactEmail(companyID, fields[0], fields[10]);
                                        foreach(DataRow dr in dataTable2.Rows)
                                        {
                                            contactid_returned = InsertUpdateCustomerContact(companyID, UserID, clientID, companyName, contactTitle, contactFirstName, contactMiddleName, contactLastName, defaultContact, department, jobTitle, contactPhone, contactMobile, contactEmail, contactFax, alternateNumber, mainApprover, subscribeNewsletter, receiveMailOut, contactCustomerField1, contactCustomerField2, contactCustomerField3, contactCustomerField4, contactCustomerField5, contactCustomerField6, contactCustomerField7, contactCustomerField8, contactCustomerField9, contactCustomerField10, contactCustomerField11, contactCustomerField12, contactCustomerField13, contactCustomerField14, contactCustomerField15, /*contactAddressLine1, contactAddressLine2, contactAddressCity, contactAddressState, contactAddressPostCode, contactAddressCountry, contactAddressTelephone, contactAddressFax, */IsB2BUser, isSingleLogin, contactAddressLabel, B2BPassword,"Update", Int32.Parse(dr["contactId"].ToString()));
                                        }
                                    }
                                    #endregion
                                    #region "Insert customer addresses"

                                    string contactAddressLine1 = fields[31];
                                    string contactAddressLine2 = fields[32];
                                    string contactAddressCity = fields[33];
                                    string contactAddressState = fields[34];
                                    string contactAddressPostCode = fields[35];
                                    string contactAddressCountry = fields[36];
                                    string contactAddressTelephone = fields[37];
                                    string contactAddressFax = fields[38];
                                    int address_count = MatchAddressWithExisting(clientID,contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);
                                    int address_count1 = MatchAddressWithExisting1(clientID, contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);
                                    int duplicateAddressCount = CheckDuplicateAddress(clientID, contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);

                                    

                                    //int address_label_count = CheckExistingAddressLabel(clientID, contactAddressLabel);
                                    if(duplicateAddressCount > 0)
                                    {
                                        int address_id = GetAddressIDForDuplicate(clientID, contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);
                                        if (address_id > 0)
                                        {
                                            UpdateContactAddress(contactid_returned, address_id);
                                        }
                                    }
                                    else if (address_count > 0)
                                    {
                                        int address_id = GetAddressID(clientID, contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);
                                        UpdateAddressLabel(address_id, contactAddressLabel);
                                        if (address_id > 0)
                                        {
                                            UpdateContactAddress(contactid_returned, address_id);
                                        }
                                    }
                                    else if (address_count1 > 0)
                                    {
                                        string address_lebel = GetMatchedAddressLabel(clientID, contactAddressLabel, contactAddressLine2, contactAddressLine1, contactAddressPostCode, contactAddressTelephone, contactAddressCountry, contactAddressCity, contactAddressState, contactAddressFax);
                                        int address_id= InsertContactAddress(companyID, UserID, clientID, address_lebel, contactAddressLine1, contactAddressLine2, contactAddressCity, contactAddressState, contactAddressPostCode, contactAddressCountry, contactAddressTelephone, contactAddressFax);
                                        if (address_id > 0)
                                        {
                                            UpdateContactAddress(contactid_returned, address_id);
                                        }
                                    }
                                    else
                                    {
                                        int address_id = InsertContactAddress(companyID, UserID, clientID, contactAddressLabel, contactAddressLine1, contactAddressLine2, contactAddressCity, contactAddressState, contactAddressPostCode, contactAddressCountry, contactAddressTelephone, contactAddressFax);
                                        if (address_id > 0)
                                        {
                                            UpdateContactAddress(contactid_returned, address_id);
                                        }
                                    }
                                    #endregion
                                    #region "Department Section"
                                    int dept_count =CheckDepartmentExist(clientID, department);
                                    if(dept_count == 0)
                                    {
                                        int dept_id = GetDefaultDepartmentID(clientID);
                                        UpdateContactDepartment(dept_id, contactid_returned);
                                    }
                                    else
                                    {
                                        int dept_id = GetDepartmentID(clientID, department);
                                        if (dept_id > 0)
                                        {
                                            UpdateContactDepartment(dept_id, contactid_returned);
                                        }
                                    }
                                    #endregion
                                    #region "Create B2b User"

                                    if (contactid_returned > 0 && IsB2BUser.ToLower() == "yes")
                                    {

                                        // start create user in ws_StoreUser
                                        Int32 b2buserid = get_Ws_StoreUser(contactid_returned, contactEmail);

                                        int b2bAccountID = get_tb_Accounts(clientID);

                                        if (b2bAccountID == 0)
                                        {
                                            string hostname = HttpContext.Current.Request.Url.Host.ToString();
                                            if (hostname.Trim().ToLower() == "localhost" || hostname.Trim().ToLower() == "192.168.1.6")
                                            {
                                                hostname = ConfigurationManager.AppSettings["HostName"].ToString();
                                            }
                                            string storeURL = GetStoreUrlByHost(hostname);
                                            b2bAccountID = PC_accounts_create(Convert.ToString(clientID), companyName, companyName.Replace(' ', '-'), "", Convert.ToString(DateTime.Now), 0, 0, 0, "p", "M", Convert.ToString(companyID), storeURL, ".aspx");
                                        }
                                        int b2bUserID = WS_Create_StoreUser(b2buserid, contactFirstName, contactLastName, contactEmail, B2BPassword, companyID, b2bAccountID, "", companyName, 0);

                                        Update_ContactID_ForB2B(b2bUserID, 1, 2, contactid_returned);
                                        //end create user in ws_StoreUser
                                        if (b2bAccountID > 0)
                                        {
                                            Int32 approvalRegisterID = getApprovalRegisterIDInformation(b2bAccountID);

                                            if (isSingleLogin.ToLower() == "yes")
                                            {
                                                ApprovalRegistration_AddOrEdit(approvalRegisterID, b2bAccountID, 0, companyID, "L", 0, "", "", 1, 1, 1);
                                            }
                                        }
                                        else
                                        {

                                            if (isSingleLogin.ToLower() == "yes")
                                            {
                                                ApprovalRegistration_AddOrEdit(0, b2bAccountID, 0, companyID, "L", 0, "", "", 1, 1, 1);
                                            }
                                        }

                                    }




                                    //if (IsB2BUser.ToLower() == "yes")
                                    //{
                                    //    InsertB2BUser(companyID, clientID, contactFirstName, contactLastName, contactEmail, B2BPassword, companyName);
                                    //}

                                    #endregion
                                }
                            }
                            else
                            {
                                lblMessage.Text = "Please select a file with valid data.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (parser.LineNumber != -1)
                        {
                            number1 = parser.LineNumber;
                        }

                    }
                    lblMessage.Text = "Records successfully imported!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }



            }
            else
            {
                lblMessage.Text = "Please Select File to Upload";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public string GetStoreUrlByHost(string HostName)
        {
            try
            {
                
                string connetionString = null;
                connetionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
                SqlConnection con;
                string QueryString = "select B2BURL from tb_MIS_AppSettings where HostName=@HostName";
                con = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(QueryString, con);
                cmd.Parameters.AddWithValue("@HostName", DbType.Int32).Value = HostName;

                con.Open();
                cmd.CommandType = CommandType.Text;
                string store_url = (string)cmd.ExecuteScalar();

                con.Close();
                return store_url;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int CheckDepartmentExist(int clientID, string dept_name)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int dept_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) from tb_Department where CustomerID=@clientID and DeptName=@departmentName and IsDeleted=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@clientID", DbType.Int32).Value = clientID;
                cmd.Parameters.AddWithValue("@departmentName", DbType.String).Value = dept_name;
                con.Open();
                cmd.CommandType = CommandType.Text;
                dept_count = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return dept_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int GetDefaultDepartmentID(int clientID)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int dept_id = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select top 1  DeptID  from tb_Department where CustomerID=@clientID and IsDefault=1 and IsDeleted=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@clientID", DbType.Int32).Value = clientID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                dept_id = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return dept_id;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int GetDepartmentID(int clientID,string DepartmentName)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int dept_id = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select top 1  DeptID  from tb_Department where CustomerID=@clientID and DeptName=@DepartmentName and IsDeleted=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@clientID", DbType.Int32).Value = clientID;
                cmd.Parameters.AddWithValue("@DepartmentName", DbType.Int32).Value = DepartmentName;
                con.Open();
                cmd.CommandType = CommandType.Text;
                dept_id = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return dept_id;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool UpdateContactDepartment(int DepartmentID,int ContactID)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                string constring = commonClass.strConnection;
                String sqlQuery = "update tb_contact set DepartmentID=@DepartmentID where contactId=@ContactID";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@DepartmentID", DbType.Int32).Value = DepartmentID;
                cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = ContactID;

                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable GetByUserIDAndCompanyName(int CompanyID, string ClientName)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                DataTable dataTable = new DataTable();
                string constring = commonClass.strConnection;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tb_client c where c.clientName='" + ClientName + "' and c.companyID='" + CompanyID + "'  and isDelete=0", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dataTable);
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int CheckContactEmail(int CompanyID, string ClientName, string Email)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int email_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) as email_exist from tb_contact c where c.CompanyName=@ClientName and c.companyID =@CompanyID and c.email=@Email and isDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int32).Value = CompanyID;
                cmd.Parameters.AddWithValue("@ClientName", DbType.String).Value = ClientName;
                cmd.Parameters.AddWithValue("@Email", DbType.String).Value = Email;
                con.Open();
                cmd.CommandType = CommandType.Text;
                email_count =Int32.Parse(cmd.ExecuteScalar().ToString()) ;
                con.Close();
                return email_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable GetContactEmail(int CompanyID, string ClientName, string Email)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                DataTable dataTable = new DataTable();
                string constring = commonClass.strConnection;
                String sqlQuery = "select * from tb_contact c where c.CompanyName=@ClientName and c.companyID =@CompanyID and c.email=@Email and isDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int32).Value = CompanyID;
                cmd.Parameters.AddWithValue("@ClientName", DbType.String).Value = ClientName;
                cmd.Parameters.AddWithValue("@Email", DbType.String).Value = Email;
                con.Open();
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dataTable);
                    }
                }
                con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int MatchAddressWithExisting(int ClientID,string contactAddressLabel, string AddressLine2,string AddressLine1,string PostalCode, string Telephone, string Country,string City,string State,string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int address_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) from tb_CompanyAddress where ClientId=@ClientID and Address=@AddressLine1 and ZipCode=@PostalCode and AddressLine2=@AddressLine2 and Telephone=@Telephone and City=@City and Country=@Country and State=@State and Fax=@Fax and AddressLabel != @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                address_count = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return address_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int GetAddressID(int ClientID, string contactAddressLabel, string AddressLine2, string AddressLine1, string PostalCode, string Telephone, string Country, string City, string State, string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int AddressId = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select AddressId from tb_CompanyAddress where ClientId=@ClientID and Address=@AddressLine1 and ZipCode=@PostalCode and AddressLine2=@AddressLine2 and Telephone=@Telephone and City=@City and Country=@Country and State=@State and Fax=@Fax and AddressLabel != @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                AddressId = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return AddressId;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int GetAddressIDForDuplicate(int ClientID, string contactAddressLabel, string AddressLine2, string AddressLine1, string PostalCode, string Telephone, string Country, string City, string State, string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int AddressId = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select AddressId from tb_CompanyAddress where ClientId=@ClientID and Address=@AddressLine1 and ZipCode=@PostalCode and AddressLine2=@AddressLine2 and Telephone=@Telephone and City=@City and Country=@Country and State=@State and Fax=@Fax and AddressLabel = @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                AddressId = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return AddressId;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int CheckExistingAddressLabel(int ClientID, string contactAddressLabel)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int address_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) from tb_CompanyAddress where ClientId=@ClientID and AddressLabel=@contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;

                con.Open();
                cmd.CommandType = CommandType.Text;
                address_count = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return address_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int InsertUpdateCustomerContact(int companyID, int UserID, int clientID, string companyName, string contactTitle, string contactFirstName, string contactMiddleName, string contactLastName, string defaultContact, string department, string jobTitle, string contactPhone, string contactMobile, string contactEmail, string contactFax, string alternateNumber, string mainApprover, string subscribeNewsletter, string receiveMailOut, string contactCustomerField1, string contactCustomerField2, string contactCustomerField3, string contactCustomerField4, string contactCustomerField5, string contactCustomerField6, string contactCustomerField7, string contactCustomerField8, string contactCustomerField9, string contactCustomerField10, string contactCustomerField11, string contactCustomerField12, string contactCustomerField13, string contactCustomerField14, string contactCustomerField15, /*string contactAddressLine1, string contactAddressLine2, string contactAddressCity, string contactAddressState, string contactAddressPostCode, string contactAddressCountry, string contactAddressTelephone, string contactAddressFax, */string IsB2BUser, string isSingleLogin, string contactAddressLabel, string B2BPassword,string Action,int contactID=0)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);

                SqlCommand cmd = new SqlCommand("PC_ClientContact_InsertUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyID", DbType.Int32).Value = companyID;
                cmd.Parameters.AddWithValue("@UserID", DbType.Int32).Value = UserID;
                cmd.Parameters.AddWithValue("@clientID", DbType.Int32).Value = clientID;
                cmd.Parameters.AddWithValue("@companyName", DbType.Int32).Value = companyName;
                cmd.Parameters.AddWithValue("@contactTitle", DbType.String).Value = contactTitle;
                cmd.Parameters.AddWithValue("@contactFirstName", DbType.String).Value = contactFirstName;
                cmd.Parameters.AddWithValue("@contactMiddleName", DbType.String).Value = contactMiddleName;
                cmd.Parameters.AddWithValue("@contactLastName", DbType.String).Value = contactLastName;
                cmd.Parameters.AddWithValue("@defaultContact", DbType.String).Value = defaultContact;
                cmd.Parameters.AddWithValue("@department", DbType.String).Value = department;
                cmd.Parameters.AddWithValue("@jobTitle", DbType.String).Value = jobTitle;
                cmd.Parameters.AddWithValue("@contactPhone", DbType.String).Value = contactPhone;
                cmd.Parameters.AddWithValue("@contactMobile", DbType.String).Value = contactMobile;
                cmd.Parameters.AddWithValue("@contactEmail", DbType.String).Value = contactEmail;
                cmd.Parameters.AddWithValue("@contactFax", DbType.Int32).Value = contactFax;
                cmd.Parameters.AddWithValue("@alternateNumber", DbType.Int32).Value = alternateNumber;
                cmd.Parameters.AddWithValue("@contactCustomerField1", DbType.String).Value = contactCustomerField1;
                cmd.Parameters.AddWithValue("@contactCustomerField2", DbType.String).Value = contactCustomerField2;
                cmd.Parameters.AddWithValue("@contactCustomerField3", DbType.String).Value = contactCustomerField3;
                cmd.Parameters.AddWithValue("@contactCustomerField4", DbType.String).Value = contactCustomerField4;
                cmd.Parameters.AddWithValue("@contactCustomerField5", DbType.String).Value = contactCustomerField5;
                cmd.Parameters.AddWithValue("@contactCustomerField6", DbType.String).Value = contactCustomerField6;
                cmd.Parameters.AddWithValue("@contactCustomerField7", DbType.String).Value = contactCustomerField7;
                cmd.Parameters.AddWithValue("@contactCustomerField8", DbType.String).Value = contactCustomerField8;
                cmd.Parameters.AddWithValue("@contactCustomerField9", DbType.String).Value = contactCustomerField9;
                cmd.Parameters.AddWithValue("@contactCustomerField10", DbType.String).Value = contactCustomerField10;
                cmd.Parameters.AddWithValue("@contactCustomerField11", DbType.String).Value = contactCustomerField11;
                cmd.Parameters.AddWithValue("@contactCustomerField12", DbType.String).Value = contactCustomerField12;
                cmd.Parameters.AddWithValue("@contactCustomerField13", DbType.String).Value = contactCustomerField13;
                cmd.Parameters.AddWithValue("@contactCustomerField14", DbType.String).Value = contactCustomerField14;
                cmd.Parameters.AddWithValue("@contactCustomerField15", DbType.String).Value = contactCustomerField15;
                //cmd.Parameters.AddWithValue("@contactAddressLine1", DbType.String).Value = contactAddressLine1;
                //cmd.Parameters.AddWithValue("@contactAddressLine2", DbType.String).Value = contactAddressLine2;
                //cmd.Parameters.AddWithValue("@contactAddressCity", DbType.String).Value = contactAddressCity;
                cmd.Parameters.AddWithValue("@IsApproved", DbType.Boolean).Value = true;

                //cmd.Parameters.AddWithValue("@contactAddressState", DbType.String).Value = contactAddressState;
                //cmd.Parameters.AddWithValue("@contactAddressPostCode", DbType.String).Value = contactAddressPostCode;
                //cmd.Parameters.AddWithValue("@contactAddressCountry", DbType.Int32).Value = contactAddressCountry;
                //cmd.Parameters.AddWithValue("@contactAddressTelephone", DbType.Int32).Value = contactAddressTelephone;
                //cmd.Parameters.AddWithValue("@contactAddressFax", DbType.Int32).Value = contactAddressFax;
                if (mainApprover.ToLower() == "yes")
                {
                    cmd.Parameters.AddWithValue("@mainApprover", DbType.Boolean).Value = true;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@mainApprover", DbType.Boolean).Value = false;
                }
                if (receiveMailOut.ToLower() == "yes")
                {
                    cmd.Parameters.AddWithValue("@receiveMailOut", DbType.Boolean).Value = true;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@receiveMailOut", DbType.Boolean).Value = false;
                }
                if (subscribeNewsletter.ToLower() == "yes")
                {
                    cmd.Parameters.AddWithValue("@subscribeNewsletter", DbType.Boolean).Value = true;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@subscribeNewsletter", DbType.Boolean).Value = false;
                }
                if (IsB2BUser.ToLower() == "yes")
                {
                    cmd.Parameters.AddWithValue("@IsB2BUser", DbType.Boolean).Value = true;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsB2BUser", DbType.Boolean).Value = false;
                }
                if (isSingleLogin.ToLower() == "yes")
                {
                    cmd.Parameters.AddWithValue("@isSingleLogin", DbType.Boolean).Value = true;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@isSingleLogin", DbType.Boolean).Value = false;
                }
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@B2BPassword", DbType.String).Value = B2BPassword;
                cmd.Parameters.AddWithValue("@Action", DbType.String).Value = Action;
                cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = contactID;



                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@ReturnID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string customerId = outPutParameter.Value.ToString();
                con.Close();
                return Convert.ToInt32(customerId);

                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                //return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertContactAddress(int companyID, int UserID, int clientID,string contactAddressLabel, string contactAddressLine1, string contactAddressLine2, string contactAddressCity, string contactAddressState, string contactAddressPostCode, string contactAddressCountry, string contactAddressTelephone, string contactAddressFax )
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);

                SqlCommand cmd = new SqlCommand("PC_InsertClientAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyID", DbType.Int32).Value = companyID;
                cmd.Parameters.AddWithValue("@UserID", DbType.Int32).Value = UserID;
                cmd.Parameters.AddWithValue("@clientID", DbType.Int32).Value = clientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@contactAddressLine1", DbType.String).Value = contactAddressLine1;
                cmd.Parameters.AddWithValue("@contactAddressLine2", DbType.String).Value = contactAddressLine2;
                cmd.Parameters.AddWithValue("@contactAddressCity", DbType.String).Value = contactAddressCity;
                cmd.Parameters.AddWithValue("@contactAddressState", DbType.String).Value = contactAddressState;
                cmd.Parameters.AddWithValue("@contactAddressPostCode", DbType.String).Value = contactAddressPostCode;
                cmd.Parameters.AddWithValue("@contactAddressCountry", DbType.Int32).Value = contactAddressCountry;
                cmd.Parameters.AddWithValue("@contactAddressTelephone", DbType.Int32).Value = contactAddressTelephone;
                cmd.Parameters.AddWithValue("@contactAddressFax", DbType.Int32).Value = contactAddressFax;
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@ReturnID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);
                con.Open();
                cmd.ExecuteNonQuery();
                string addressId = outPutParameter.Value.ToString();

                con.Close();
                return Convert.ToInt32(addressId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateContactAddress(int contactID, int addressID)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                string query = "update tb_contact set ContactAddressID=@addressID where contactId=@contactID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@contactID", DbType.Int32).Value = contactID;
                cmd.Parameters.AddWithValue("@addressID", DbType.Int32).Value = addressID;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAddressLabel(int addressID, string addressLabel)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                string query= "update tb_CompanyAddress set AddressLabel=@addressLabel where AddressId=@addressID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@addressID", DbType.Int32).Value = addressID;
                cmd.Parameters.AddWithValue("@addressLabel", DbType.String).Value = addressLabel;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MatchAddressWithExisting1(int ClientID, string contactAddressLabel, string AddressLine2, string AddressLine1, string PostalCode, string Telephone, string Country, string City, string State, string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int address_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) from tb_CompanyAddress where ClientId=@ClientID and Address !=@AddressLine1 and ZipCode !=@PostalCode and AddressLine2 != @AddressLine2 and Telephone != @Telephone and City != @City and Country != @Country and State != @State and Fax != @Fax and AddressLabel = @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                address_count = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return address_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int CheckDuplicateAddress(int ClientID, string contactAddressLabel, string AddressLine2, string AddressLine1, string PostalCode, string Telephone, string Country, string City, string State, string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                int address_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "select count(*) from tb_CompanyAddress where ClientId=@ClientID and Address =@AddressLine1 and ZipCode =@PostalCode and AddressLine2 = @AddressLine2 and Telephone = @Telephone and City = @City and Country = @Country and State = @State and Fax = @Fax and AddressLabel = @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                address_count = Int32.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return address_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string GetMatchedAddressLabel(int ClientID, string contactAddressLabel, string AddressLine2, string AddressLine1, string PostalCode, string Telephone, string Country, string City, string State, string Fax)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                string address_label = "";
                string constring = commonClass.strConnection;
                String sqlQuery = "select AddressLabel from tb_CompanyAddress where ClientId=@ClientID and Address !=@AddressLine1 and ZipCode !=@PostalCode and AddressLine2 != @AddressLine2 and Telephone != @Telephone and City != @City and Country != @Country and State != @State and Fax != @Fax and AddressLabel = @contactAddressLabel and IsDelete=0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@contactAddressLabel", DbType.String).Value = contactAddressLabel;
                cmd.Parameters.AddWithValue("@AddressLine2", DbType.String).Value = AddressLine2;
                cmd.Parameters.AddWithValue("@Telephone", DbType.String).Value = Telephone;
                cmd.Parameters.AddWithValue("@AddressLine1", DbType.String).Value = AddressLine1;
                cmd.Parameters.AddWithValue("@PostalCode", DbType.String).Value = PostalCode;
                cmd.Parameters.AddWithValue("@Country", DbType.String).Value = Country;
                cmd.Parameters.AddWithValue("@City", DbType.String).Value = City;
                cmd.Parameters.AddWithValue("@State", DbType.String).Value = State;
                cmd.Parameters.AddWithValue("@Fax", DbType.String).Value = Fax;
                con.Open();
                cmd.CommandType = CommandType.Text;
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    address_label = reader.GetString(0);
                }
                con.Close();
                return address_label;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool InsertB2BUser(int CompanyID,  int ClientID, string FirstName, string LastName, string Email, string Password,string CompanyName)
        {
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);

                SqlCommand cmd = new SqlCommand("PC_InsertB2BUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int32).Value = CompanyID;
                cmd.Parameters.AddWithValue("@ClientID", DbType.Int32).Value = ClientID;
                cmd.Parameters.AddWithValue("@CompanyName", DbType.String).Value = CompanyName;
                cmd.Parameters.AddWithValue("@FirstName", DbType.String).Value = FirstName;
                cmd.Parameters.AddWithValue("@LastName", DbType.String).Value = LastName;
                cmd.Parameters.AddWithValue("@Email", DbType.String).Value = Email;
                cmd.Parameters.AddWithValue("@Password", DbType.String).Value = Password;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int get_Ws_StoreUser(int contactID, string email)
        {
            Int32 toreturn = 0;
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                //string cachedConnectionString = (string)Cache["newConnectionString"];
                //SqlConnection con;
                //con = new SqlConnection(cachedConnectionString);
                String sqlQuery = "select * from Ws_StoreUser where ContactID = @ContactID AND EmailID = @EmailID and IsDeleted=0";
                SqlParameter ContactID = new SqlParameter();
                ContactID.ParameterName = "@ContactID";
                ContactID.Value = contactID;
                SqlParameter EmailID = new SqlParameter();
                EmailID.ParameterName = "@EmailID";
                EmailID.Value = email;

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(ContactID);
                cmd.Parameters.Add(EmailID);

                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();


                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string returnedid = datareader["StoreUserID"].ToString();
                        toreturn = Convert.ToInt32(returnedid);
                    }
                }
                else
                {
                    toreturn = 0;
                }
                con.Close();
                return toreturn;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private int get_tb_Accounts(int ClientID)
        {
            int toreturn = 0;
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                String sqlQuery = "select top 1 * from tb_Accounts where clientID = @clientID and isDeleted=0";
                SqlParameter clientID = new SqlParameter();
                clientID.ParameterName = "@clientID";
                clientID.Value = ClientID;


                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(clientID);

                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();


                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string returnedid = datareader["accountID"].ToString();
                        toreturn = Convert.ToInt32(returnedid);
                    }
                }
                else
                {
                    toreturn = 0;
                }
                con.Close();
                return toreturn;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int WS_Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID
        , string IsPsw, string CompanyName, long subscribe_newsletter)
        {
            try
            {
                
                //string cachedConnectionString = (string)Cache["newConnectionString"];
                //string connetionString = null;
                //connetionString = "data source=DESKTOP-G9INHA9;initial catalog=eprint_ukdemo;Integrated Security=SSPI;";
                //SqlConnection con;
                //con = new SqlConnection(cachedConnectionString);
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                SqlCommand cmd = new SqlCommand("WS_Create_StoreUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StoreUserID", DbType.Int64).Value = StoreUserID;
                cmd.Parameters.AddWithValue("@FirstName", DbType.String).Value = FirstName;
                cmd.Parameters.AddWithValue("@LastName", DbType.String).Value = LastName;
                cmd.Parameters.AddWithValue("@EmailID", DbType.String).Value = EmailID;
                cmd.Parameters.AddWithValue("@Password", DbType.String).Value = Password;
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int64).Value = CompanyID;
                cmd.Parameters.AddWithValue("@AccountID", DbType.Int64).Value = AccountID;
                cmd.Parameters.AddWithValue("@IsPsw", DbType.String).Value = IsPsw;
                cmd.Parameters.AddWithValue("@CompanyName", DbType.String).Value = CompanyName;
                cmd.Parameters.AddWithValue("@subscribe_newsletter", DbType.Int64).Value = subscribe_newsletter;

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@ReturnID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string customerId = outPutParameter.Value.ToString();

                con.Close();

                return Convert.ToInt32(customerId);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public void Update_ContactID_ForB2B(long StoreUserID, long DefaultBillingID, long DefaultShippingID, int ContactID)
        {
            try
            {
                
                //string cachedConnectionString = (string)Cache["newConnectionString"];
                //string connetionString = null;
                //connetionString = "data source=DESKTOP-G9INHA9;initial catalog=eprint_ukdemo;Integrated Security=SSPI;";
                //SqlConnection con;
                //con = new SqlConnection(cachedConnectionString);
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                SqlCommand cmd = new SqlCommand("WS_Update_ContactID_ForB2B", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StoreUserID", DbType.Int64).Value = StoreUserID;
                cmd.Parameters.AddWithValue("@DefaultBillingID", DbType.Int64).Value = DefaultBillingID;
                cmd.Parameters.AddWithValue("@DefaultShippingID", DbType.Int64).Value = DefaultShippingID;
                cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = ContactID;

                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }
        private int getApprovalRegisterIDInformation(int accountID)
        {
            int toreturn = 0;
            try
            {
                
                commonClass commonClass = new commonClass();
                SqlConnection con;
                con = new SqlConnection(commonClass.strConnection);
                String sqlQuery = "select top 1 * from tb_ApprovalRegistration where AccountID = @clientID and IsDelete=0";
                SqlParameter clientID = new SqlParameter();
                clientID.ParameterName = "@clientID";
                clientID.Value = accountID;


                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(clientID);

                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();


                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string returnedid = datareader["ApprovalRegisterID"].ToString();
                        toreturn = Convert.ToInt32(returnedid);
                    }
                }
                else
                {
                    toreturn = 0;
                }
                con.Close();
                return toreturn;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int ApprovalRegistration_AddOrEdit(long ApprovalRegisterID, long AccountID, long CreatedBy, long CompanyID, string userDeptType, Int32 DepartmentID,
         string RegisterEmailAddress, string ApprovedEmailAddress, Int32 PrefilAdded, Int32 OverwriteAdded, Int32 IsSelfRegister)
        {
            commonClass commonClass = new commonClass();
            SqlConnection con;
            con = new SqlConnection(commonClass.strConnection);
            SqlCommand cmd = new SqlCommand("PC_B2B_ApprovalRegistration_AddOREdit", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@ApprovalRegisterID", DbType.Int64).Value = ApprovalRegisterID;
            cmd.Parameters.AddWithValue("@AccountID", DbType.Int64).Value = AccountID;
            cmd.Parameters.AddWithValue("@CreatedBy", DbType.Int64).Value = CreatedBy;
            cmd.Parameters.AddWithValue("@CompanyID", DbType.Int64).Value = CompanyID;
            cmd.Parameters.AddWithValue("@userDeptType", DbType.String).Value = userDeptType;
            cmd.Parameters.AddWithValue("@DepartmentID", DbType.Int32).Value = DepartmentID;
            cmd.Parameters.AddWithValue("@RegisterEmailAddress", DbType.String).Value = RegisterEmailAddress;
            cmd.Parameters.AddWithValue("@ApprovedEmailAddress", DbType.String).Value = ApprovedEmailAddress;
            cmd.Parameters.AddWithValue("@PrefilAdded", DbType.Int32).Value = PrefilAdded;
            cmd.Parameters.AddWithValue("@OverwriteAdded", DbType.Int32).Value = OverwriteAdded;
            cmd.Parameters.AddWithValue("@IsSelfRegister", DbType.Int32).Value = IsSelfRegister;
            cmd.Parameters.AddWithValue("@AddNewDept", DbType.Boolean).Value = 0;
            cmd.Parameters.AddWithValue("@DeptScreenName", DbType.String).Value = "Department";
            cmd.Parameters.AddWithValue("@IsSingleField", DbType.Boolean).Value = 1;


            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@ReturnID";
            outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);

            con.Open();
            cmd.ExecuteNonQuery();

            string customerId = outPutParameter.Value.ToString();

            con.Close();

            return Convert.ToInt32(customerId);
        }
        public int PC_accounts_create(string clientID, string clientName, string accountName, string accountPrefix, string createdOn, Int32 createdBy,
          Int32 defaultContactID, Int32 defaultAddressID, string accountType, string addressType, string CompanyID, string StoreURL, string FileExtension)
        {
            
            commonClass commonClass = new commonClass();
            SqlConnection con;
            con = new SqlConnection(commonClass.strConnection);
            SqlCommand cmd = new SqlCommand("PC_accounts_create", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@clientID", DbType.String).Value = clientID;
            cmd.Parameters.AddWithValue("@clientName", DbType.String).Value = clientName;
            cmd.Parameters.AddWithValue("@accountName", DbType.String).Value = accountName;
            cmd.Parameters.AddWithValue("@accountPrefix", DbType.String).Value = accountPrefix;
            cmd.Parameters.AddWithValue("@createdOn", DbType.String).Value = createdOn;
            cmd.Parameters.AddWithValue("@createdBy", DbType.Int32).Value = createdBy;
            cmd.Parameters.AddWithValue("@defaultContactID", DbType.Int32).Value = defaultContactID;
            cmd.Parameters.AddWithValue("@defaultAddressID", DbType.Int32).Value = defaultAddressID;
            cmd.Parameters.AddWithValue("@accountType", DbType.String).Value = accountType;
            cmd.Parameters.AddWithValue("@addressType", DbType.String).Value = addressType;
            cmd.Parameters.AddWithValue("@CompanyID", DbType.String).Value = CompanyID;
            cmd.Parameters.AddWithValue("@StoreURL", DbType.String).Value = StoreURL;
            cmd.Parameters.AddWithValue("@FileExtension", DbType.String).Value = "FileExtension";


            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@ReturnID";
            outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);

            con.Open();
            cmd.ExecuteNonQuery();

            string customerId = outPutParameter.Value.ToString();

            con.Close();

            return Convert.ToInt32(customerId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = int.Parse(this.Session["companyid"].ToString());
            global.pageName = "Client";
            global.pgName = "";
            this.gloobj.setpagename("Client");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "Client";
            languageClass _languageClass = new languageClass();

            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home"), "</a> > <a href=../client/client_view.aspx class='subnavigator' style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("CRM"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", "Import Contact"));

        }
    }
}