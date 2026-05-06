using nmsCommon;
using nmsConnection;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.WebStore
{
    public partial class qcb2blink : System.Web.UI.Page, IRequiresSessionState
    {

        private DateTime UTCDate = DateTime.Now;

        private bool isDateSent;

        private string ipaddress = string.Empty;

        private string REquestedQueryString = string.Empty;

        private string CompleteQueryString = string.Empty;

        private string Email = string.Empty;

        private string UserName = string.Empty;

        private string Password = string.Empty;

        private long ID;

        public string ConnectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public qcb2blink()
        {
        }

        public void _Login(string Email, string Password, long AccID)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            loginclass _loginclass = new loginclass();
            BaseClass baseClass = new BaseClass();
            commonclass _commonclass = new commonclass();
            bool flag = false;
            bool flag1 = false;
            this.Session["IsHomePageVisible"] = null;
            this.Session["IsPPW"] = null;
            long num = (long)0;
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            string sitePath = string.Empty;
            if (ConnectionClass.SitePath != null)
            {
                sitePath = ConnectionClass.SitePath;
            }
            DataTable dataTable1 = LoginBasePage.LoginTo_Store(baseClass.SpecialEncode(Email), Password, AccID, ConnectionClass.AccountType);
            foreach (DataRow row in dataTable1.Rows)
            {
                base.Response.Cookies["B2BAccountID"].Value = row["AccountID"].ToString();
                num = Convert.ToInt64(row["StoreUserID"]);
                AccID = Convert.ToInt64(row["AccountID"]);
                dataTable = CMSBasePage.GetDisplaySettings(AccID);
                if (!Convert.ToBoolean(row["IsActive"]))
                {
                    flag = false;
                    flag1 = true;
                    this.Session["IsHomePageVisible"] = null;
                    this.Session["IsPPW"] = null;
                }
                else
                {
                    this.Session["AccountID"] = AccID;
                    this.Session["eStoreDisplaySetting"] = dataTable;
                    flag = true;
                    flag1 = false;
                    this.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    this.Session["IsPPW"] = row["IsPPW"].ToString();
                    this.Session["LanguageConversion"] = row["LanguageConversionFile"].ToString();
                    baseClass.Assign_ApprovalSystemSettings_ForAccount(AccID);
                }
            }
            if (!flag)
            {
                if (flag1)
                {
                    this.LogRequest(string.Concat(Email, "Your account is deactivated"));
                    if (url.ToLower().Contains("kulbardi"))
                    {
                        base.Response.Redirect("https://kulbardi.com.au/");
                    }
                    else
                    {
                        base.Response.Redirect("http://www.quickcorporate.com.au/");
                    }
                    return;
                }
                this.LogRequest(string.Concat(Email, " ~~~Invalid Login Details"));
                if (url.ToLower().Contains("kulbardi"))
                {
                    base.Response.Redirect("https://kulbardi.com.au/");
                }
                else
                {
                    base.Response.Redirect("http://www.quickcorporate.com.au/");
                }
                return;
            }
            empty = _commonclass.UniqueID;
            _loginclass.Insert_intoResume_Session(baseClass.SpecialEncode(Email), Password, (long)Convert.ToInt32(this.Session["AccountID"]));
            _loginclass.LogInFromDefault(baseClass.SpecialEncode(Email), Password);
            CartBasePage.Update_Cart_StoreUserID(empty, num);
            if (this.Session["fromEmail"] != null && this.Session["fromEmail"] != null)
            {
                this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
                base.Response.Redirect(this.Session["fromEmail"].ToString());
                return;
            }
            if (this.Session["RedirectToUserRegApprovalPage"] != null && this.Session["RedirectToUserRegApprovalPage"] != null)
            {
                this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
                base.Response.Redirect(this.Session["RedirectToUserRegApprovalPage"].ToString());
            }
            if (this.Session["RedirectToProfModApprovalPage"] != null && this.Session["RedirectToProfModApprovalPage"] != null)
            {
                this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
                base.Response.Redirect(this.Session["RedirectToProfModApprovalPage"].ToString());
            }
            if (this.Session["RedirectToApproverOrderPage"] != null && this.Session["RedirectToApproverOrderPage"] != null)
            {
                this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
                base.Response.Redirect(this.Session["RedirectToApproverOrderPage"].ToString());
            }
            if (this.Session["RedirectToUserOrderPage"] != null && this.Session["RedirectToUserOrderPage"] != null)
            {
                this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
                base.Response.Redirect(this.Session["RedirectToUserOrderPage"].ToString());
            }
            this.LogRequest(string.Concat(Email, " ~~~Sucessfull login"));
            base.Response.Redirect(string.Concat(sitePath, "products/product.aspx?ID=0"));
        }

        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] numArray;
            int num = 0;
            byte[] bytes = HexEncoding.GetBytes(Message, out num);
            Message = Convert.ToBase64String(bytes, 0, (int)bytes.Length);
            Message = Message.Replace(' ', '+');
            byte[] numArray1 = new byte[8];
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            byte[] bytes1 = Encoding.UTF8.GetBytes(Passphrase);
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
            {
                Key = bytes1,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = numArray1
            };
            byte[] numArray2 = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                numArray = cryptoTransform.TransformFinalBlock(numArray2, 0, (int)numArray2.Length);
            }
            finally
            {
                tripleDESCryptoServiceProvider.Clear();
            }
            return uTF8Encoding.GetString(numArray);
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] bytes;
            byte[] numArray = new byte[8];
            byte[] bytes1 = Encoding.UTF8.GetBytes(toEncrypt);
            string str = "S3cr3tP4SSW0RD1312432100";
            if (!useHashing)
            {
                bytes = Encoding.UTF8.GetBytes(str);
            }
            else
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                bytes = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(str));
                mD5CryptoServiceProvider.Clear();
            }
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
            {
                Key = bytes,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros,
                IV = numArray
            };
            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
            byte[] numArray1 = cryptoTransform.TransformFinalBlock(bytes1, 0, (int)bytes1.Length);
            tripleDESCryptoServiceProvider.Clear();
            return HexEncoding.ToString(numArray1);
        }

        public string HashCode(string str)
        {
            byte[] bytes = (new ASCIIEncoding()).GetBytes(str);
            SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
            string str1 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
            return str1;
        }

        public string Login(string Email)
        {
            string empty = string.Empty;
            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = string.Concat("select top 1 * from Ws_StoreUser where EmailID='", Email.Replace("'", "`"), "' and  isDeleted=0 and isActive=1 and isApproved=1select top 1 * from Ws_StoreUser where EmailID='", Email.Replace("'", "`"), "' and  isDeleted=0 and isActive=1 and isApproved=1")
            };
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                return "invalid";
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.UserName = row["EmailID"].ToString();
                this.Password = row["password"].ToString();
                this.ID = Convert.ToInt64(row["accountid"]);
            }
            return "valid";
        }

        public void LogRequest(string Status)
        {
            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text
            };
            this.CompleteQueryString = base.Request.QueryString.ToString();
            string[] strArrays = new string[] { "insert into tb_QCBtoBLink(QS,IPAddress,RequestStatus) values ('", this.CompleteQueryString.Replace("'", "`"), "','", this.ipaddress.Replace("'", "`"), "','", Status.Replace("'", "`"), "')" };
            sqlCommand.CommandText = string.Concat(strArrays);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            this.ipaddress = base.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (this.ipaddress == "" || this.ipaddress == null)
            {
                this.ipaddress = base.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["enc"] != null && base.Request.QueryString["sha1"] != null)
                {
                    try
                    {
                        this.REquestedQueryString = base.Request.QueryString["enc"].Trim();
                        var querystr = base.Request.QueryString["enc"].Trim();
                        string str = qcb2blink.DecryptString(querystr, "S3cr3tP4SSW0RD1312432100");
                        int index = str.IndexOf("}");
                        if (index > 0)
                            str = str.Substring(0, index + 1);
                        //if (this.HashCode(str).Trim().ToLower() != base.Request.QueryString["sha1"].Trim().ToLower())
                        //{
                        //    this.LogRequest(string.Concat(this.Email, " ~~~Hash Code did not matched"));
                        //    base.Response.Write("Invalid Login Details");
                        //    base.Response.Redirect("http://www.quickcorporate.com.au/");
                        //}
                        //else
                        {
                            foreach (KeyValuePair<string, object> keyValuePair in (Dictionary<string, object>)(new JavaScriptSerializer()).DeserializeObject(str))
                            {
                                if (keyValuePair.Key.ToString().Trim() != "email")
                                {
                                    if (keyValuePair.Key.ToString().Trim() != "expiry")
                                    {
                                        continue;
                                    }
                                    this.UTCDate = Convert.ToDateTime(keyValuePair.Value);
                                    this.isDateSent = true;
                                }
                                else
                                {
                                    this.Email = keyValuePair.Value.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        this.LogRequest(string.Concat(this.Email, " ~~~Error  ", exception.Message.ToString()));
                        if(url.ToLower().Contains("kulbardi"))
                        {
                            base.Response.Redirect("https://kulbardi.com.au/");
                        }
                        else
                        {
                            base.Response.Redirect("http://www.quickcorporate.com.au/");
                        }
                    }
                    if (!this.isDateSent)
                    {
                        this.LogRequest(string.Concat(this.Email, " ~~~Date Was Missing"));
                        if (url.ToLower().Contains("kulbardi"))
                        {
                            base.Response.Redirect("https://kulbardi.com.au/");
                        }
                        else
                        {
                            base.Response.Redirect("http://www.quickcorporate.com.au/");
                        }
                        return;
                    }
                    DateTime universalTime = DateTime.Now.ToUniversalTime();
                    double totalMinutes = (universalTime - this.UTCDate).TotalMinutes;
                    if (totalMinutes < 0)
                    {
                        totalMinutes = -totalMinutes;
                    }
                    if (totalMinutes > 5)
                    {
                        this.LogRequest(string.Concat(this.Email, " ~~~Date Does not Match"));
                        if (url.ToLower().Contains("kulbardi"))
                        {
                            base.Response.Redirect("https://kulbardi.com.au/");
                        }
                        else
                        {
                            base.Response.Redirect("http://www.quickcorporate.com.au/");
                        }
                        return;
                    }
                    string str1 = this.Login(this.Email);
                    if (str1.Trim().ToLower() != "invalid" && str1.Trim().Length > 0)
                    {
                        this._Login(this.UserName, this.Password, this.ID);
                        return;
                    }
                    this.LogRequest(string.Concat(this.Email, " ~~~Invalid Login Details"));
                    if (url.ToLower().Contains("kulbardi"))
                    {
                        base.Response.Redirect("https://kulbardi.com.au/");
                    }
                    else
                    {
                        base.Response.Redirect("http://www.quickcorporate.com.au/");
                    }
                    return;
                }
                this.LogRequest(string.Concat(this.Email, " ~~~Missing Query string values"));
                if (url.ToLower().Contains("kulbardi"))
                {
                    base.Response.Redirect("https://kulbardi.com.au/");
                }
                else
                {
                    base.Response.Redirect("http://www.quickcorporate.com.au/");
                }
            }
        }

        public static string TEST(string toEncrypt)
        {
            int num = 0;
            byte[] bytes = HexEncoding.GetBytes(toEncrypt, out num);
            return Convert.ToBase64String(bytes, 0, (int)bytes.Length);
        }
    }
}