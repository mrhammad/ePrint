using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace ePrint
{


    [ScriptService]
    [WebService(Namespace = "http://contentmanagement.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ContentManagementWebService : WebService
    {
        private commonClass objCommon = new commonClass();

        public string strSitepath = global.sitePath();

        public string SecureSitePath = global.SecureSitePath();

        public string SecureDocPath = global.SecureDocPath();

        public string ServerName = ConnectionClass.ServerName;

        public string SecureDocFilePath = global.SecureDocFilepath();

        public ContentManagementWebService()
        {
        }

        private StringBuilder GenerateAllBanner(StringBuilder strBuil)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string[] strArrays = null;
            strArrays = strBuil.ToString().Split(new char[] { 'μ' });
            string str = strArrays[3].ToString().Trim();
            string empty1 = string.Empty;
            if (strArrays[6].ToString().Trim() != "")
            {
                string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/store/", strArrays[1], "/banners/", strArrays[6] };
                empty1 = string.Concat(secureSitePath);
            }
            stringBuilder.Append(string.Concat("<div style='cursor:move;' id='div_", str, "'>"));
            string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_", str, "'  value='", str, "'>" };
            stringBuilder.Append(string.Concat(strArrays1));
            stringBuilder.Append("<div class='module_cube_banner'>");
            stringBuilder.Append(string.Concat("<img src=\"", empty1, "\" border='0'>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("Ø");
            return stringBuilder;
        }

        private string GenerateAllCategory(StringBuilder strBuil)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = null;
            strArrays = strBuil.ToString().Split(new char[] { 'μ' });
            string empty = string.Empty;
            string str = strArrays[4].ToString();
            string str1 = strArrays[3].ToString().Trim();
            string str2 = strArrays[5].ToString().Trim();
            if (strArrays[7].ToString().Trim() != "")
            {
                string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", strArrays[2], "/ProductCatalogueCategory/t_", strArrays[7] };
                empty = string.Concat(secureSitePath);
            }
            else
            {
                empty = string.Concat(this.strSitepath, "Images/StoreImages/t_category-icon.png");
            }
            stringBuilder.Append(string.Concat("<div style='cursor:move;padding:5px 0px 10px 0px;' id='div_", str1, "'>"));
            string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_", str1, "'  value='", str1, "'>" };
            stringBuilder.Append(string.Concat(strArrays1));
            stringBuilder.Append("<div class='productDetails_div' style='padding-top:10px;'><div class='productDetails_Style'>");
            stringBuilder.Append(string.Concat("<div class='productName_div'><span>", str, "</span></div>"));
            stringBuilder.Append("<div style='clear:both'></div>");
            stringBuilder.Append("<div class='productImage_div'>");
            stringBuilder.Append("<div style='display: table-cell;min-height:150px;min-width:220px;height: 150px;text-align:centre;vertical-align:bottom;'>");
            string[] strArrays2 = new string[] { "<img title='", str, "' style='border:none;border-color:White;' src=\"", empty, "\" alt=' ' /></div>" };
            stringBuilder.Append(string.Concat(strArrays2));
            stringBuilder.Append("</div>");
            stringBuilder.Append("<div style='clear:both'></div>");
            stringBuilder.Append(string.Concat("<div class='productCategoryDescription_div' title=''><span> ", str2, "</span></div>"));
            stringBuilder.Append("<div style='clear:both'></div></div></div>");
            stringBuilder.Append("Ø");
            return stringBuilder.ToString();
        }

        private object GenerateAllCustomText(StringBuilder strBuil)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = strBuil.ToString().Split(new char[] { 'μ' });
            string str = strArrays[5].ToString();
            string str1 = strArrays[6].ToString();
            string str2 = strArrays[3].ToString().Trim();
            string str3 = strArrays[4].ToString();
            string str4 = string.Concat("div_", str2);
            string str5 = string.Concat(this.strSitepath, "images/delete.gif");
            string str6 = string.Concat(this.strSitepath, "images/edit.gif");
            stringBuilder.Append(string.Concat("<div style='cursor:normal;' id=", str4, ">"));
            string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_", str2, "' value='", str2, "'>" };
            stringBuilder.Append(string.Concat(strArrays1));
            string[] strArrays2 = new string[] { "<div id=", str2, " class='resizable' style='height:", str, "px; width:", str1, "px;'>" };
            stringBuilder.Append(string.Concat(strArrays2));
            string[] strArrays3 = new string[] { "<img style='cursor:pointer;padding:5px;' onclick='Delete(", str2, ",", str4, ");'  src=\"", str5, "\" />" };
            stringBuilder.Append(string.Concat(strArrays3));
            string[] strArrays4 = new string[] { "<img style='cursor:pointer;padding:5px;' onclick='OpenEditor(", str2, ");'  src=\"", str6, "\" />" };
            stringBuilder.Append(string.Concat(strArrays4));
            stringBuilder.Append("<div style='padding:5px; cursor:pointer;'>");
            stringBuilder.Append(str3);
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("Ø");
            return stringBuilder;
        }

        [WebMethod]
        public string GenerateAllItems(long CompanyID, long AccountID, string TypeID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            string[] strArrays = TypeID.Split(new char[] { ',' });
            if ((int)strArrays.Length > 0)
            {
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    StringBuilder stringBuilder1 = new StringBuilder();
                    DataTable dataTable = new DataTable();
                    DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectProductCategoryList");
                    database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
                    database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
                    database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int32, Convert.ToInt32(strArrays[i].Trim()));
                    using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                    {
                        dataTable.Load(dataReader);
                    }
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            stringBuilder1.Append(dataTable.Rows[0][j].ToString());
                            stringBuilder1.Append("μ");
                        }
                        if (stringBuilder1[0].ToString() == "C")
                        {
                            stringBuilder = stringBuilder.Append(this.GenerateAllCategory(stringBuilder1));
                        }
                        if (stringBuilder1[0].ToString() == "B")
                        {
                            stringBuilder = stringBuilder.Append(this.GenerateAllBanner(stringBuilder1));
                        }
                        if (stringBuilder1[0].ToString() == "T")
                        {
                            stringBuilder = stringBuilder.Append(this.GenerateAllCustomText(stringBuilder1));
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private StringBuilder GenerateBanner(StringBuilder strBuil)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string[] strArrays = null;
            strArrays = strBuil.ToString().Split(new char[] { 'μ' });
            string str = string.Empty;
            if (strArrays[6].ToString().Trim() != "")
            {
                string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/store/", strArrays[1], "/banners/", strArrays[6] };
                str = string.Concat(secureSitePath);
            }
            stringBuilder.Append(string.Concat("<div style='cursor:move;' id='div_", strArrays[3], "'>"));
            string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_", strArrays[3].Trim(), "'  value='", strArrays[3], "'>" };
            stringBuilder.Append(string.Concat(strArrays1));
            stringBuilder.Append("<div class='module_cube_banner'>");
            stringBuilder.Append(string.Concat("<img src=\"", str, "\" border='0'>"));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            strBuil.Append("Ø");
            return stringBuilder;
        }

        private StringBuilder GenerateCategory(StringBuilder strBuil)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            string[] strArrays = null;
            strArrays = strBuil.ToString().Split(new char[] { 'μ' });
            if (strArrays[7].ToString().Trim() != "")
            {
                string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", strArrays[2], "/ProductCatalogueCategory/t_", strArrays[7] };
                empty = string.Concat(secureSitePath);
            }
            else
            {
                empty = string.Concat(this.strSitepath, "Images/StoreImages/t_category-icon.png");
            }
            stringBuilder.Append(string.Concat("<div style='cursor:move;' id='div_", strArrays[3], "'>"));
            string[] strArrays1 = new string[] { "<input type='hidden' id='hdn_", strArrays[3].Trim(), "'  value='", strArrays[3], "'>" };
            stringBuilder.Append(string.Concat(strArrays1));
            stringBuilder.Append("<div class='productDetails_div'><div class='productDetails_Style'>");
            stringBuilder.Append(string.Concat("<div class='productName_div'><span>", strArrays[4].ToString(), "</span></div>"));
            stringBuilder.Append("<div style='clear:both'></div>");
            stringBuilder.Append("<div class='productImage_div'>");
            string[] str1 = new string[] { "<img title='", strArrays[4].ToString(), "' style='border:none;border-color:White;' src=\"", empty, "\" alt=' '></div>" };
            stringBuilder.Append(string.Concat(str1));
            stringBuilder.Append("<div style='clear:both'></div>");
            stringBuilder.Append(string.Concat("<div class='productCategoryDescription_div' title=''><span> ", strArrays[5].ToString(), "</span></div>"));
            stringBuilder.Append("<div style='clear:both'></div></div></div>");
            return stringBuilder;
        }

        private StringBuilder GenerateCustomText(DataRow dr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = dr["customTextID"].ToString().Trim();
            string str1 = string.Concat("div_", str);
            string str2 = string.Concat(this.strSitepath, "images/delete.gif");
            string str3 = string.Concat(this.strSitepath, "images/edit.gif");
            stringBuilder.Append(string.Concat("<div style='cursor:move;' id=", str1, " >"));
            string[] strArrays = new string[] { "<input type='hidden' id='hdn_", str, "'  value='", str, "'>" };
            stringBuilder.Append(string.Concat(strArrays));
            stringBuilder.Append("<div class='resizable'>");
            stringBuilder.Append("<div style='cursor:pointer;padding:5px;'>");
            string[] strArrays1 = new string[] { "<img style='padding:5px;' onclick='Delete(", str, ",", str1, ");'  src=\"", str2, "\" />" };
            stringBuilder.Append(string.Concat(strArrays1));
            string[] strArrays2 = new string[] { "<img style='padding:5px;' onclick='OpenEditor(", str, ");'  src=\"", str3, "\" />" };
            stringBuilder.Append(string.Concat(strArrays2));
            stringBuilder.Append("</div>");
            stringBuilder.Append(dr["customText"].ToString());
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            return stringBuilder;
        }

        [WebMethod]
        public string GetTemplateData(long CompanyID, long AccountID, int TypeID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectProductCategoryList");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int32, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    stringBuilder.Append(dataTable.Rows[0][i].ToString());
                    stringBuilder.Append("μ");
                }
                stringBuilder = (stringBuilder[0].ToString() != "C" ? this.GenerateBanner(stringBuilder) : this.GenerateCategory(stringBuilder));
            }
            return stringBuilder.ToString();
        }

        [WebMethod]
        public int IsRightBanner(long CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsRightBanner");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        [WebMethod]
        public void RemoveCategoryAndBanner(int TypeID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_RemoveCategoryAndBanner");
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        [WebMethod]
        public string SaveCustomText(long CustomTextID, long CompanyID, long AccountID, string CustomText, string Hieght, string Width)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertUpdateCustomText");
            database.AddInParameter(storedProcCommand, "@CustomTextID", DbType.Int64, CustomTextID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CustomText", DbType.String, CustomText);
            database.AddInParameter(storedProcCommand, "@Hieght", DbType.String, Hieght);
            database.AddInParameter(storedProcCommand, "@Width", DbType.String, Width);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    stringBuilder = this.GenerateCustomText(row);
                }
            }
            return stringBuilder.ToString();
        }

        [WebMethod]
        public void SaveIsRightBanner(long CompanyID, long AccountID, int IsRightBanner)
        {
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateIsRightBanner");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
                database.AddInParameter(storedProcCommand, "@IsRightBanner", DbType.Int32, IsRightBanner);
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch
            {
            }
        }

        [WebMethod]
        public string SaveProductBannerListOrder(int ComapnyID, long AccountID, long TypeID, string Type, int SelectedOrder)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProductListTemplate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, ComapnyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@SelectedOrderNew", DbType.Int32, SelectedOrder);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return ((parameterValue == null ? 0 : int.Parse(parameterValue.ToString()))).ToString();
        }

        [WebMethod]
        public void UpdateCustomOrder(long AccountID, string TypeID)
        {
            if (TypeID != "" && TypeID.Length > 0)
            {
                string[] strArrays = TypeID.Split(new char[] { 'μ' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i] != "")
                    {
                        Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
                        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateCustomOrder");
                        database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
                        database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, strArrays[i]);
                        database.AddInParameter(storedProcCommand, "@SelectedOrderNew", DbType.Int64, i + 1);
                        database.ExecuteNonQuery(storedProcCommand);
                    }
                }
            }
        }

        [WebMethod]
        public void UpdateCustomText(long AccountID, string strIDandSize)
        {
            string[] strArrays = strIDandSize.Split(new char[] { 'Ø' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { 'μ' });
                    if ((int)strArrays1.Length > 1)
                    {
                        Database database = CustomDatabaseFactory.CreateDatabase(this.objCommon.strConnection);
                        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateCustomTextHieghtWidth");
                        database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
                        database.AddInParameter(storedProcCommand, "@CustomTextID", DbType.Int32, Convert.ToInt32(strArrays1[0]));
                        database.AddInParameter(storedProcCommand, "@Height", DbType.String, Convert.ToInt32(strArrays1[1]));
                        database.AddInParameter(storedProcCommand, "@Width", DbType.String, Convert.ToInt32(strArrays1[2]));
                        database.ExecuteNonQuery(storedProcCommand);
                    }
                }
            }
        }
    }

}