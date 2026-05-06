using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class inventory_import : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        private InventoryBasePage obj = new InventoryBasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass commclass = new commonClass();

        private object[] objRow;

        public string pg = string.Empty;

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

        public inventory_import()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/warehouse/warehouse.aspx?type=inventory");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand;
            string fileName = this.fileExcel.FileName;
            string str = Guid.NewGuid().ToString();
            if (this.fileExcel.HasFile)
            {
                object[] companyID = new object[] { this.SecureDocPath, ConnectionClass.ServerName, "//", this.CompanyID, "//Inventory" };
                if (!Directory.Exists(string.Concat(companyID)))
                {
                    object[] objArray = new object[] { this.SecureDocPath, ConnectionClass.ServerName, "//", this.CompanyID, "//Inventory" };
                    Directory.CreateDirectory(string.Concat(objArray));
                }
                FileUpload fileUpload = this.fileExcel;
                object[] companyID1 = new object[] { this.SecureDocPath, ConnectionClass.ServerName, "//", this.CompanyID, "//Inventory//", str, fileName };
                fileUpload.SaveAs(string.Concat(companyID1));
                string empty = string.Empty;
                object[] objArray1 = new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.SecureDocPath, ConnectionClass.ServerName, "//", this.CompanyID, "//Inventory//", str, fileName, ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;\"" };
                OleDbConnection oleDbConnection = new OleDbConnection(string.Concat(objArray1));
                oleDbConnection.Open();
                string[] excelSheetNames = this.GetExcelSheetNames(string.Concat(str, this.fileExcel.FileName));
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string.Concat("select * from [", excelSheetNames[0].ToString().Trim(), "]"), oleDbConnection);
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                oleDbConnection.Close();
                string str1 = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(str1);
                sqlConnection.Open();
                if (!this.rdoInsert.Checked)
                {
                    object[] num = new object[] { "insert into tb_inventoryImportRecords (categoryID,actionType,[fileName],userID,isImported) values (", Convert.ToInt64(this.ddlInvCategory.SelectedValue.ToString()), ", 'd', '", str + this.fileExcel.FileName, "', ", this.UserID, ",0)" };
                    sqlCommand = new SqlCommand(string.Concat(num), sqlConnection);
                }
                else
                {
                    object[] num1 = new object[] { "insert into tb_inventoryImportRecords (categoryID,actionType,[fileName],userID,isImported) values (", Convert.ToInt64(this.ddlInvCategory.SelectedValue.ToString()), ", 'i', '", str + this.fileExcel.FileName, "', ", this.UserID, ",0)" };
                    sqlCommand = new SqlCommand(string.Concat(num1), sqlConnection);
                }
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (dataTable.Rows.Count <= 0)
                {
                    base.Message_Display("No records found to Import!!!", "warningMsg", this.plhMessage);
                    this.divSubmit.Visible = false;
                    this.GridImport.Visible = false;
                }
                else
                {
                    this.Session["dtImport"] = dataTable;
                    this.divSubmit.Visible = true;
                    this.GridImport.Visible = true;
                    this.GridImport.DataSource = dataTable;
                    this.GridImport.DataBind();
                }
            }
            this.ddlInvCategory.Enabled = false;
            this.rdoDelete.Enabled = false;
            this.rdoInsert.Enabled = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            object obj;
            object[] companyID;
            this.GridImport.Visible = false;
            //if (this.Session["dtImport"] == null)
            //{
            //    base.Message_Display("No Records found to Import!!!", "msg-fail", this.plhMessage);
            //    return;
            //}
            //DataTable dataTable = this.obj.settings_InvCategory_selectall(this.CompanyID, this.ddlInvCategory.SelectedItem.Text.ToString());
            //DataTable item = (DataTable)this.Session["dtImport"];
            //string empty = string.Empty;
            //if (this.rdoDelete.Checked)
            //{
            //    empty = string.Concat("Select InventoryID into tempInventoryProperties from tb_InventoryProperties where InventoryID in (select InventoryID from tb_Inventory where CompanyID=", this.CompanyID, " and isdeleted =0) ");
            //    obj = empty;
            //    companyID = new object[] { obj, " Select InventoryID into tempInventory from tb_Inventory where CompanyID=", this.CompanyID, " and isdeleted=0 " };
            //    empty = string.Concat(companyID);
            //    object obj1 = empty;
            //    object[] objArray = new object[] { obj1, " update tb_InventoryProperties set isdeleted=1 where InventoryID in (select InventoryID from tb_Inventory where CompanyID=", this.CompanyID, " and isdeleted =0) " };
            //    empty = string.Concat(objArray);
            //    obj = empty;
            //    companyID = new object[] { obj, " update tb_Inventory set isdeleted=1 where CompanyID=", this.CompanyID, " and isdeleted =0  " };
            //    empty = string.Concat(companyID);
            //}
            //try
            //{
            //    try
            //    {
            //        foreach (DataRow row in item.Rows)
            //        {
            //            int count = item.Columns.Count;
            //            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            //            SqlConnection sqlConnection = new SqlConnection(str);
            //            string empty1 = string.Empty;
            //            string str1 = string.Empty;
            //            string empty2 = string.Empty;
            //            string str2 = string.Empty;
            //            int num = 0;
            //            int num1 = 0;
            //            int num2 = 0;
            //            int num3 = 0;
            //            string empty3 = string.Empty;
            //            string location = string.Empty;
            //            if (row[0].ToString().Trim() != null)
            //            {
            //                empty1 = row[0].ToString().Trim();
            //            }
            //            if (row[1].ToString().Trim() != null)
            //            {
            //                str1 = row[1].ToString().Trim();
            //            }
            //            if (row[2].ToString().Trim() != null)
            //            {
            //                empty2 = row[2].ToString().Trim();
            //            }
            //            if (row[3].ToString().Trim() != null)
            //            {
            //                str2 = row[3].ToString().Trim();
            //            }
            //            if (row[4].ToString().Trim() != null)
            //            {
            //                int num4 = 0;
            //                int.TryParse(row[4].ToString(), out num4);
            //                num = num4;
            //            }
            //            //-------------
            //            if (row[4].ToString().Trim() != null)
            //            {
            //                location = row[4].ToString();
            //                location = location.Trim();
            //            }
            //            //-------------
            //            if (row[5].ToString().Trim() != null)
            //            {
            //                int num5 = 0;
            //                int.TryParse(row[5].ToString(), out num5);
            //                num1 = num5;
            //            }
            //            if (row[6].ToString().Trim() != null)
            //            {
            //                int num6 = 0;
            //                int.TryParse(row[6].ToString(), out num6);
            //                num2 = num6;
            //            }
            //            if (row[8].ToString().Trim() != null)
            //            {
            //                int num7 = 0;
            //                empty3 = row[8].ToString();
            //                empty3 = row[8].ToString().Trim();
            //                try
            //                {
            //                    sqlConnection.Open();
            //                    string str3 = string.Empty;
            //                    if (empty3 == "")
            //                    {
            //                        companyID = new object[] { "select top 1 ClientID from tb_client where clientname like '", empty3, "' and companyid=", this.CompanyID, " and Isdelete=0 and companytype='supplier'" };
            //                        str3 = string.Concat(companyID);
            //                    }
            //                    else
            //                    {
            //                        companyID = new object[] { "select top 1 ClientID from tb_client where clientname like '%", empty3, "%' and companyid=", this.CompanyID, " and Isdelete=0 and companytype='supplier'" };
            //                        str3 = string.Concat(companyID);
            //                    }
            //                    num7 = (int)(new SqlCommand(str3, sqlConnection)).ExecuteScalar();
            //                    sqlConnection.Close();
            //                }
            //                catch
            //                {
            //                    string empty4 = string.Empty;
            //                    empty4 = this.Session["DateFormat"].ToString();
            //                    commonClass _commonClass = this.commclass;
            //                    commonClass _commonClass1 = this.commclass;
            //                    DateTime now = DateTime.Now;
            //                    string str4 = _commonClass.date_Check_new(empty4, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
            //                    DateTime dateTime = Convert.ToDateTime(str4);
            //                    string empty5 = string.Empty;
            //                    companyID = new object[] { "insert into tb_client (Clientname,CompanyID,companytype,[A/cOpened]) values ('", empty3, "',", this.CompanyID, ",'Supplier','", dateTime, "');" };
            //                    empty5 = string.Concat(companyID);
            //                    SqlCommand sqlCommand = new SqlCommand(string.Concat(empty5, "declare @ID bigint select @ID=scope_identity()"), sqlConnection)
            //                    {
            //                        CommandType = CommandType.Text,
            //                        Connection = sqlConnection
            //                    };
            //                    sqlCommand.ExecuteNonQuery();
            //                    SqlCommand sqlCommand1 = new SqlCommand("SELECT @@IDENTITY", sqlConnection);
            //                    num7 = Convert.ToInt32(sqlCommand1.ExecuteScalar());
            //                    sqlConnection.Close();
            //                }
            //                num3 = num7;
            //            }

            //            int reOrderQuantity = 0;
            //            if (row[7].ToString().Trim() != null)
            //            {
            //                reOrderQuantity = Convert.ToInt32(row[7].ToString().Trim());
            //            }

            //            obj = empty;

            //            string fname = "'" + str1 + "'";

            //            companyID = new object[] { obj, " insert into tb_Inventory(CompanyID,InventoryName,Description,InventoryCode,InventoryCategoryID,Location,InStock,ReorderLevel,ReOrderQuantity,SupplierID, FriendlyName) values(", this.CompanyID, ",'", empty1, "','", empty2, "','", str2, "',", this.ddlInvCategory.SelectedValue.ToString(), ",'", location, "',", num1, ",", num2, ",", reOrderQuantity, ",", num3, ",", fname, ")  " };

            //            empty = string.Concat(companyID);
            //            empty = string.Concat(empty, "declare @ID bigint select @ID=scope_identity() ");
            //            obj = empty;
            //            companyID = new object[] { obj, " insert into tb_InventoryHistory (inventoryID,description,userID,quantity,actionType,FinalQuantity) values (@ID,'Stock Added Through Import',", this.UserID, ",", num, ",'o',", num, ") " };
            //            empty = string.Concat(companyID);
            //            string str5 = "in.";
            //            string num8 = "";
            //            decimal num9 = new decimal(0);
            //            decimal num10 = new decimal(0);
            //            decimal num11 = new decimal(0);
            //            if (row[8].ToString().Trim() != null)
            //            {
            //                //string num12 ="";
            //                //string.TryParse(row[8].ToString(), out num12);
            //                num8 = row[8].ToString();
            //            }
            //            if (row[9].ToString().Trim() != null)
            //            {
            //                decimal num13 = new decimal(0);
            //                decimal.TryParse(row[9].ToString(), out num13);
            //                num9 = num13;
            //            }
            //            if (row[10].ToString().Trim() != null)
            //            {
            //                decimal num14 = new decimal(0);
            //                decimal.TryParse(row[10].ToString(), out num14);
            //                num10 = num14;
            //            }
            //            if (row[11].ToString().Trim() != null)
            //            {
            //                decimal num15 = new decimal(0);
            //                decimal.TryParse(row[11].ToString(), out num15);
            //                num11 = num15;
            //            }

            //            decimal abc = new decimal(0);
            //            if (row[12].ToString().Trim() != null)
            //            {
            //                decimal a = new decimal(0);
            //                decimal.TryParse(row[12].ToString(), out a);
            //                abc = a;
            //            }

            //            string str6 = "Cost,PerQuantity,PackedIn,PackedPrice,WidthType,InventoryID";
            //            companyID = new object[] { num9, ",", num10, ",", num11, ",", abc, ",'", str5, "',@ID " };
            //            string str7 = string.Concat(companyID);
            //            count = 11;
            //            decimal num16 = new decimal(0);
            //            decimal num17 = new decimal(0);
            //            decimal num18 = new decimal(0);
            //            try
            //            {
            //                if (Convert.ToBoolean(dataTable.Rows[0]["IsWeight"]))
            //                {
            //                    str6 = string.Concat(str6, ",BasisWeight");
            //                    if (row[13].ToString().Trim() != null)
            //                    {
            //                        decimal num19 = new decimal(0);
            //                        decimal.TryParse(row[13].ToString(), out num19);
            //                        num16 = num19;
            //                    }
            //                    str7 = string.Concat(str7, ",", num16);
            //                    count++;
            //                }
            //            }
            //            catch
            //            {
            //                str6 = string.Concat(str6, ",BasisWeight");
            //                if (row[13].ToString().Trim() != null)
            //                {
            //                    decimal num20 = new decimal(0);
            //                    decimal.TryParse(row[13].ToString(), out num20);
            //                    num16 = num20;
            //                }
            //                str7 = string.Concat(str7, ",", num16);
            //                count++;
            //            }
            //            try
            //            {
            //                if (Convert.ToBoolean(dataTable.Rows[0]["IsColor"]))
            //                {
            //                    str6 = string.Concat(str6, ",Colour");
            //                    str7 = string.Concat(str7, ",'", row[14].ToString().Trim(), "'");
            //                    count++;
            //                }
            //            }
            //            catch
            //            {
            //                str6 = string.Concat(str6, ",Colour");
            //                str7 = string.Concat(str7, ",'", row[14].ToString().Trim(), "'");
            //                count++;
            //            }
            //            try
            //            {
            //                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemCustomSize"]))
            //                {
            //                    str6 = string.Concat(str6, ",Height");
            //                    if (row[16].ToString().Trim() != null)
            //                    {
            //                        decimal num21 = new decimal(0);
            //                        decimal.TryParse(row[16].ToString(), out num21);
            //                        num17 = num21;
            //                    }
            //                    str7 = string.Concat(str7, ",", num17);
            //                    count++;
            //                    str6 = string.Concat(str6, ",Width");
            //                    if (row[17].ToString().Trim() != null)
            //                    {
            //                        decimal num22 = new decimal(0);
            //                        decimal.TryParse(row[17].ToString(), out num22);
            //                        num18 = num22;
            //                    }
            //                    str7 = string.Concat(str7, ",", num18);
            //                    count++;
            //                }
            //            }
            //            catch
            //            {
            //                str6 = string.Concat(str6, ",Height");
            //                if (row[16].ToString().Trim() != null)
            //                {
            //                    decimal num23 = new decimal(0);
            //                    decimal.TryParse(row[16].ToString(), out num23);
            //                    num17 = num23;
            //                }
            //                str7 = string.Concat(str7, ",", num17);
            //                count++;
            //                str6 = string.Concat(str6, ",Width");
            //                if (row[17].ToString().Trim() != null)
            //                {
            //                    decimal num24 = new decimal(0);
            //                    decimal.TryParse(row[17].ToString(), out num24);
            //                    num18 = num24;
            //                }
            //                str7 = string.Concat(str7, ",", num18);
            //                count++;
            //            }
            //            try
            //            {
            //                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemPaperSize"]))
            //                {
            //                    str6 = string.Concat(str6, ",PaperType");
            //                    str7 = string.Concat(str7, ",'", row[18].ToString().Trim(), "'");
            //                    count++;
            //                }
            //            }
            //            catch
            //            {
            //                str6 = string.Concat(str6, ",PaperType");
            //                str7 = string.Concat(str7, ",'", row[18].ToString().Trim(), "'");
            //                count++;
            //            }
            //            try
            //            {
            //                if (Convert.ToBoolean(dataTable.Rows[0]["IsCoatingType"]))
            //                {
            //                    str6 = string.Concat(str6, ",Coated");
            //                    str7 = string.Concat(str7, ",'", row[20].ToString().Trim(), "'");
            //                    count++;
            //                }
            //            }
            //            catch
            //            {
            //                str6 = string.Concat(str6, ",Coated");
            //                str7 = string.Concat(str7, ",'", row[20].ToString().Trim(), "'");
            //                count++;
            //            }
            //            string str8 = empty;
            //            string[] strArrays = new string[] { str8, " insert into tb_InventoryProperties(", str6, ") values (", str7, ")" };
            //            empty = string.Concat(strArrays);
            //            SqlCommand sqlCommand2 = new SqlCommand(empty, sqlConnection)
            //            {
            //                CommandType = CommandType.Text,
            //                Connection = sqlConnection
            //            };
            //            sqlConnection.Open();
            //            sqlCommand2.ExecuteNonQuery();
            //            sqlConnection.Close();
            //            empty = string.Empty;
            //        }
            //        base.Message_Display("Data Imported Successfully", "msg-success", this.plhMessage);
            //    }
            //    catch (Exception exception)
            //    {
            //        base.Message_Display(exception.ToString(), "msg-fail", this.plhMessage);
            //        if (this.rdoDelete.Checked)
            //        {
            //            empty = string.Empty;
            //            string str9 = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            //            SqlConnection sqlConnection1 = new SqlConnection(str9);
            //            empty = " update tb_InventoryProperties set isdeleted=0 where InventoryID in (select InventoryID from  tempInventoryProperties) ";
            //            empty = string.Concat(empty, " update tb_Inventory set isdeleted=0 where InventoryID in (select InventoryID from  tempInventory) ");
            //            SqlCommand sqlCommand3 = new SqlCommand(empty, sqlConnection1)
            //            {
            //                CommandType = CommandType.Text,
            //                Connection = sqlConnection1
            //            };
            //            sqlConnection1.Open();
            //            sqlCommand3.ExecuteNonQuery();
            //            sqlConnection1.Close();
            //        }
            //    }
            //}
            //finally
            //{
            //    if (this.rdoDelete.Checked)
            //    {
            //        empty = string.Empty;
            //        string str10 = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            //        SqlConnection sqlConnection2 = new SqlConnection(str10);
            //        empty = " drop table tempInventoryProperties;  drop table tempInventory";
            //        SqlCommand sqlCommand4 = new SqlCommand(empty, sqlConnection2)
            //        {
            //            CommandType = CommandType.Text,
            //            Connection = sqlConnection2
            //        };
            //        sqlConnection2.Open();
            //        sqlCommand4.ExecuteNonQuery();
            //        sqlConnection2.Close();
            //    }
            //}
            //base.Response.Redirect("inventory_import.aspx?t=s");
            base.Message_Display("Data Imported Successfully", "msg-success", this.plhMessage);
        }

        protected void ddlInvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getColumnHeaders();
        }

        private void getColumnHeaders()
        {
            DataTable dataTable = this.obj.settings_InvCategory_selectall(this.CompanyID, this.ddlInvCategory.SelectedItem.Text.ToString());
            DataTable dataTable1 = new DataTable("Table1");
            dataTable1.Columns.Add("Inventory Name", typeof(string));
            dataTable1.Columns.Add("Friendly Name", typeof(string));
            dataTable1.Columns.Add("Description", typeof(string));
            dataTable1.Columns.Add("Inventory Code", typeof(string));
            dataTable1.Columns.Add("Location", typeof(string));
            dataTable1.Columns.Add("In Stock", typeof(string));
            dataTable1.Columns.Add("Re Order Level", typeof(string));
            dataTable1.Columns.Add("Re Order Quantity", typeof(string));
            dataTable1.Columns.Add("Supplier", typeof(string));
            dataTable1.Columns.Add("Cost", typeof(string));
            dataTable1.Columns.Add("Per Quantity", typeof(string));
            dataTable1.Columns.Add("Packed In", typeof(string));
            dataTable1.Columns.Add("Pack Price", typeof(string));
            if (this.ddlInvCategory.SelectedIndex == 0)
            {
                dataTable1.Columns.Add("Basis Weight", typeof(string));
                dataTable1.Columns.Add("Colour", typeof(string));
                dataTable1.Columns.Add("Length", typeof(string));
                dataTable1.Columns.Add("Height", typeof(string));
                dataTable1.Columns.Add("Width", typeof(string));
                dataTable1.Columns.Add("Paper Type", typeof(string));
                dataTable1.Columns.Add("Large Format Material", typeof(string));
                dataTable1.Columns.Add("Coated", typeof(string));
                dataTable1.Columns.Add("Markup", typeof(string));
                dataTable1.Columns.Add("Caliper", typeof(string));
                this.Session["Headers"] = null;
                this.Session["Headers"] = dataTable1;
            }
            else
            {
                if (Convert.ToBoolean(dataTable.Rows[0]["IsWeight"]))
                {
                    dataTable1.Columns.Add("Basis Weight", typeof(string));
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsColor"]))
                {
                    dataTable1.Columns.Add("Colour", typeof(string));
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemCustomSize"]))
                {
                    dataTable1.Columns.Add("Height", typeof(string));
                    dataTable1.Columns.Add("Width", typeof(string));
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsItemPaperSize"]))
                {
                    dataTable1.Columns.Add("Length", typeof(string)).SetOrdinal(15);
                    dataTable1.Columns.Add("Paper Type", typeof(string));
                    dataTable1.Columns.Add("Large Format Material", typeof(string));
                }
                if (Convert.ToBoolean(dataTable.Rows[0]["IsCoatingType"]))
                {
                    dataTable1.Columns.Add("Coated", typeof(string));
                }
                dataTable1.Columns.Add("Markup", typeof(string));
                if (Convert.ToBoolean(dataTable.Rows[0]["IsWeight"]))
                {
                    dataTable1.Columns.Add("Caliper", typeof(string));
                }
                if (dataTable.Rows.Count > 0)
                {
                    this.Session["Headers"] = null;
                    this.Session["Headers"] = dataTable1;
                    return;
                }
            }
        }

        public string[] GetExcelSheetNames(string excelFile)
        {
            string[] strArrays;
            OleDbConnection oleDbConnection = null;
            DataTable oleDbSchemaTable = null;
            try
            {
                try
                {
                    object[] companyID = new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.SecureDocPath, ConnectionClass.ServerName, "//", this.CompanyID, "//Inventory//", excelFile, ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;\"" };
                    oleDbConnection = new OleDbConnection(string.Concat(companyID));
                    oleDbConnection.Open();
                    oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (oleDbSchemaTable != null)
                    {
                        string[] str = new string[oleDbSchemaTable.Rows.Count];
                        int num = 0;
                        foreach (DataRow row in oleDbSchemaTable.Rows)
                        {
                            str[num] = row["TABLE_NAME"].ToString();
                            num++;
                        }
                        strArrays = str;
                    }
                    else
                    {
                        strArrays = null;
                    }
                }
                catch (Exception exception)
                {
                    strArrays = null;
                }
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                    oleDbConnection.Dispose();
                }
                if (oleDbSchemaTable != null)
                {
                    oleDbSchemaTable.Dispose();
                }
            }
            return strArrays;
        }

        protected void GridImport_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void lnkDownLoadDefault_Click(object sender, EventArgs e)
        {
            this.getColumnHeaders();
            if (this.Session["Headers"] != null)
            {
                DataTable item = (DataTable)this.Session["Headers"];
                (new WebExport()).WebExportDetails(item, WebExport.ExportFormat.Excel, "InventoryImport.xls", "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("warehouse", "exportorimport", "");
            global.pageName = "Warehouse";
            global.pgName = "";
            this.gloobj.setpagename("Warehouse");
            this.pg = "inventory";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Inventory Import", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>Home</a>&nbsp;>&nbsp;<a href='../warehouse/warehouse.aspx?type=inventory' class='subnavigator'  style='text-decoration:underline;'>Warehouse: Inventory</a>", "&nbsp;>&nbsp;Inventory Import");
            if (!base.IsPostBack)
            {
                this.obj.Bind_Stock_Category(this.ddlInvCategory, this.CompanyID, "----- All -----");
                this.ddlInvCategory.SelectedIndex = 0;
                if (base.Request.QueryString["t"] != null)
                {
                    base.Message_Display("Data Imported Successfully", "msg-success", this.plhMessage);
                }
            }
        }
    }
}