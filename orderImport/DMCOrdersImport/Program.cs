using Eprint.DataAccessLayer;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace DMCOrdersImport
{
    //internal class Program
    public class Program
	{
		private static StringBuilder sbMessage;
        
        //public static string ConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //    }

        //}

        public static string ConnectionString
        {
            get;
            set;
        }

        public static string server_name
        {
            get;
            set;
        }
        public static string file_path
        {
            get;
            set;
        }
        static Program()
        {
            Program.sbMessage = new StringBuilder();
        }

        public Program(string serverName, string userId, string password, string filePath, string connectionString, string systemName)
        {
            //string[] args = { };
            //Main(args);
            Main_Method(serverName, userId, password, filePath, connectionString, systemName);
        }

		public static void CopyDataToTable(DataTable table)
		{
			SqlConnection dbConnection = new SqlConnection(Program.ConnectionString);
			try
			{
				dbConnection.Open();
				SqlBulkCopy s = new SqlBulkCopy(dbConnection);
				try
				{
					s.DestinationTableName = table.TableName;
					foreach (object column in table.Columns)
					{
						s.ColumnMappings.Add(column.ToString(), column.ToString());
					}
					s.WriteToServer(table);
				}
				finally
				{
					if (s != null)
					{
						((IDisposable)s).Dispose();
					}
				}
			}
			finally
			{
				if (dbConnection != null)
				{
					((IDisposable)dbConnection).Dispose();
				}
			}
		}

		public static string CreateTABLE(string tableName, DataTable table)
		{
			int maxLength;
			string sqlsc = string.Concat("CREATE TABLE ", tableName, "(");
			for (int i = 0; i < table.Columns.Count; i++)
			{
				sqlsc = string.Concat(sqlsc, "\n [", table.Columns[i].ColumnName, "] ");
				if (table.Columns[i].DataType.ToString().Contains("System.Int32"))
				{
					sqlsc = string.Concat(sqlsc, " int ");
				}
				else if (table.Columns[i].DataType.ToString().Contains("System.DateTime"))
				{
					sqlsc = string.Concat(sqlsc, " datetime ");
				}
				else if (!table.Columns[i].DataType.ToString().Contains("System.String"))
				{
					maxLength = table.Columns[i].MaxLength;
					sqlsc = string.Concat(sqlsc, " nvarchar(", maxLength.ToString(), ") ");
				}
				else
				{
					maxLength = table.Columns[i].MaxLength;
					sqlsc = string.Concat(sqlsc, " nvarchar(", maxLength.ToString(), ") ");
				}
				if (table.Columns[i].AutoIncrement)
				{
					string str = sqlsc;
					string[] strArrays = new string[] { str, " IDENTITY(", null, null, null, null };
					long autoIncrementSeed = table.Columns[i].AutoIncrementSeed;
					strArrays[2] = autoIncrementSeed.ToString();
					strArrays[3] = ",";
					autoIncrementSeed = table.Columns[i].AutoIncrementStep;
					strArrays[4] = autoIncrementSeed.ToString();
					strArrays[5] = ") ";
					sqlsc = string.Concat(strArrays);
				}
				if (!table.Columns[i].AllowDBNull)
				{
					sqlsc = string.Concat(sqlsc, " NOT NULL ");
				}
				sqlsc = string.Concat(sqlsc, ",");
			}
			string str1 = string.Concat(sqlsc.Substring(0, sqlsc.Length - 1), ")");
			return str1;
		}

        public static void ImportAllFiles(string systemName)
		{
			Exception ex;
			DataSet ds = Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.ConnectionString, CommandType.Text, "select * from tb_OrderImport where isImported=0");
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				try
				{
                    string FilePath = Program.file_path;
                    //string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
					//string[] str = new string[] { FilePath, dr["CompanyID"].ToString(), "\\eStoreOrder\\", dr["AccountID"].ToString(), "\\" };
                    //string[] str = new string[] { FilePath, Program.server_name, "\\", dr["CompanyID"].ToString(), "\\eStoreOrder\\", dr["AccountID"].ToString(), "\\" };                   
                    //string[] str = new string[] { FilePath, "test3", "\\", dr["CompanyID"].ToString(), "\\eStoreOrder\\", dr["AccountID"].ToString(), "\\" };
                    string[] str = new string[] { FilePath, systemName, "\\", dr["CompanyID"].ToString(), "\\eStoreOrder\\", dr["AccountID"].ToString(), "\\" };
					FilePath = string.Concat(str);
					DataTable dtImport = Import.ConnectFileNew(dr["FileName"].ToString(), FilePath);
					dtImport.TableName = "tb_OrderImportItems";
					DataColumn newColumn = new DataColumn("OrderImportID", typeof(long))
					{
						DefaultValue = Convert.ToInt64(dr["OrderImportID"])
					};
					dtImport.Columns.Add(newColumn);
					try
					{
						Program.CopyDataToTable(dtImport);
						Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.ConnectionString, CommandType.Text, string.Concat("update tb_OrderImport set isImported=1,Comments='' where OrderImportID=", dr["OrderImportID"].ToString()));
					}
					catch (Exception exception)
					{
						ex = exception;
						Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.ConnectionString, CommandType.Text, string.Concat("update tb_OrderImport set isImported=2,Comments='", Program.SpecialEncode(ex.Message.ToString()), "' where OrderImportID=", dr["OrderImportID"].ToString()));
					}
				}
				catch (Exception exception1)
				{
					ex = exception1;
					Eprint.DataAccessLayer.SQL.ExecuteDataset(Program.ConnectionString, CommandType.Text, string.Concat("update tb_OrderImport set isImported=2,Comments='", Program.SpecialEncode(ex.Message.ToString()), "' where OrderImportID=", dr["OrderImportID"].ToString()));
				}
			}
		}


		private static void Main(string[] args)
		{
			//Program.ImportAllFiles();
            ///*
            //kr
            string servername = (ConfigurationManager.AppSettings["ServerName"]).ToString(); //change in app.config
            string userid = (ConfigurationManager.AppSettings["UserId"]).ToString(); //change in app.config
            string password = (ConfigurationManager.AppSettings["Password"]).ToString(); //change in app.config
            try
            {
                string connectionString = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string strDBName = "";
                    using (SqlCommand command = new SqlCommand("select CRMConnectionString,a.ServerName , ab.IsActive, a.isEnableImportOrders from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName inner join tb_ClientInfo ab on c.HostName = ab.System_URL where a.isEnableImportOrders = 'true' and ab.IsActive=1", connection))
                    //using (SqlCommand command = new SqlCommand("select CRMConnectionString,ServerName from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName where a.HostName in ('demo.eprintsoftware.com')", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Program.server_name = reader[1].ToString();
                            string[] strArray = reader[0].ToString().Split(';');
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                if (strArray[i].Contains("Initial Catalog"))
                                {
                                    strDBName = strArray[i].ToString().Split('=')[1];
                                    if (Program.CheckIfDataBaseExists(strDBName, servername, userid, password) > 0)
                                    {
                                        if (Program.DBStatus(strDBName, servername, userid, password) == "ONLINE")
                                        {
                                            Program.ConnectionString = "";
                                            Program.ConnectionString = reader[0].ToString();
                                            //Program.ImportAllFiles();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
             //*/
		}

        // embed order import 
        private void Main_Method(string serverName, string userId, string Password, string FielPath, string connectionstring, string systemName)
        {
            string servername = serverName;
            string userid = userId;
            string password = Password;
            string fielPath = FielPath;
            Program.server_name = servername;
            Program.file_path = FielPath;
            
            //string servername = (ConfigurationManager.AppSettings["ServerName"]).ToString(); //change in app.config
            //string userid = (ConfigurationManager.AppSettings["UserId"]).ToString(); //change in app.config
            //string password = (ConfigurationManager.AppSettings["Password"]).ToString(); //change in app.config

           
            try
            {
                string connectionString = connectionstring;
                //Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                //string connectionString = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
                //string connectionString = "Data Source=172.31.6.188;Initial Catalog=eprint_master;Persist Security Info=true;User ID=eprint_dbconnect;Password=maznac-7Hocpo-ruknav;Pooling=false";
                Program.ConnectionString = connectionString;
                Program.ImportAllFiles(systemName);
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    string strDBName = "";
                //    using (SqlCommand command = new SqlCommand("select CRMConnectionString,a.ServerName , ab.IsActive, a.isEnableImportOrders from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName inner join tb_ClientInfo ab on c.HostName = ab.System_URL where a.isEnableImportOrders = 'true' and ab.IsActive=1", connection))
                //    //using (SqlCommand command = new SqlCommand("select CRMConnectionString,ServerName from tb_MIS_ConnectionStrings c inner join tb_MIS_AppSettings a on c.HostName = a.HostName where a.HostName in ('demo.eprintsoftware.com')", connection))
                //    {
                //        SqlDataReader reader = command.ExecuteReader();
                //        while (reader.Read())
                //        {
                //            Program.server_name = reader[1].ToString();
                //            string[] strArray = reader[0].ToString().Split(';');
                //            for (int i = 0; i < strArray.Length; i++)
                //            {
                //                if (strArray[i].Contains("Initial Catalog"))
                //                {
                //                    strDBName = strArray[i].ToString().Split('=')[1];
                //                    if (Program.CheckIfDataBaseExists(strDBName, servername, userid, password) > 0)
                //                    {
                //                        if (Program.DBStatus(strDBName, servername, userid, password) == "ONLINE")
                //                        {
                //                            Program.ConnectionString = "";
                //                            Program.ConnectionString = reader[0].ToString();
                //                            Program.ImportAllFiles();
                //                            //if (strDBName == "eprint_test3")
                //                            //{
                //                            //    Program.ImportAllFiles();
                //                            //}
                                           
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        public static int CheckIfDataBaseExists(string dbName, string servername, string userid, string password)
        {
            int val = 0;
            string connectionStringMaster = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
            using (SqlConnection connection = new SqlConnection(connectionStringMaster))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select count(*) from sys.sysdatabases where name= " + "'" + dbName + "'", connection))
                {
                    val = (int)(command.ExecuteScalar());
                }
            }
            return val;
        }

        public static string DBStatus(string dbName, string servername, string userid, string password)
        {
            string val = "";
            string connectionStringMaster = "Data Source=" + servername + ";Initial Catalog=eprint_master;Persist Security Info=true;User ID=" + userid + ";Password=" + password + "";
            using (SqlConnection connection = new SqlConnection(connectionStringMaster))
            {
                connection.Open();
                //select  DATABASEPROPERTYEX('eprint_reef', 'Status') AS DBStatus
                using (SqlCommand command = new SqlCommand("select  DATABASEPROPERTYEX('" + dbName + "', 'Status') AS DBStatus", connection))
                {
                    val = (string)(command.ExecuteScalar());
                }
            }
            return val;
        }

		public static void SendMailMessage()
		{
			int i;
			char[] chrArray;
			string FromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
			string FromName = ConfigurationManager.AppSettings["FromName"].ToString();
			string ToEmail = ConfigurationManager.AppSettings["ToEmail"].ToString();
			string bcc = ConfigurationManager.AppSettings["bcc"].ToString();
			string cc = ConfigurationManager.AppSettings["cc"].ToString();
			string Subject = "";
			string SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
			string SMTPServerUserName = ConfigurationManager.AppSettings["SMTPServerUserName"].ToString();
			string SMTPServerPassword = ConfigurationManager.AppSettings["SMTPServerPassword"].ToString();
			int SMTPPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
			bool SMTPClientEnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPClientEnableSsl"]);
			MailMessage mMailMessage = new MailMessage()
			{
				From = new MailAddress(FromEmail, FromName)
			};
			mMailMessage.To.Add(new MailAddress(ToEmail));
			if ((bcc == null ? false : bcc != string.Empty))
			{
				chrArray = new char[] { ',' };
				string[] arraybcc = bcc.Split(chrArray);
				for (i = 0; i < (int)arraybcc.Length; i++)
				{
					mMailMessage.Bcc.Add(new MailAddress(arraybcc[i]));
				}
			}
			if ((cc == null ? false : cc != string.Empty))
			{
				chrArray = new char[] { ',' };
				string[] arraycc = cc.Split(chrArray);
				for (i = 0; i < (int)arraycc.Length; i++)
				{
					mMailMessage.CC.Add(new MailAddress(arraycc[i]));
				}
			}
			DateTime now = DateTime.Now;
			mMailMessage.Subject = string.Concat(Subject, " Kings API Download Summary ", now.ToString());
			mMailMessage.Body = Program.sbMessage.ToString();
			mMailMessage.IsBodyHtml = false;
			mMailMessage.Priority = MailPriority.High;
			SmtpClient mSmtpClient = new SmtpClient(SMTPServerIP)
			{
				Credentials = new NetworkCredential(SMTPServerUserName, SMTPServerPassword),
				EnableSsl = SMTPClientEnableSsl,
				Port = SMTPPort
			};
			mSmtpClient.Send(mMailMessage);
		}

		public static string SpecialDecode(string OriginalString)
		{
			OriginalString = OriginalString.Replace("%27", "'");
			OriginalString = OriginalString.Replace("%22", "\"");
			return OriginalString;
		}

		public static string SpecialEncode(string OriginalString)
		{
			OriginalString = OriginalString.Replace("'", "%27");
			OriginalString = OriginalString.Replace("\"", "%22");
			return OriginalString;
		}
	}
}