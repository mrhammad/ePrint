using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Activation;
using TemplateEditorFrontEnd;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class TemplateEditorFrontEndSevice : ITemplateEditorFrontEndSevice
{
    public static string HostName;

    private string Templateconnectionstring = "";

    private static long Draftid;

    private List<TemplateFieldPropertiesFrontEnd> AllProperties = new List<TemplateFieldPropertiesFrontEnd>();

    static TemplateEditorFrontEndSevice()
    {
        TemplateEditorFrontEndSevice.HostName = string.Empty;
    }

    public TemplateEditorFrontEndSevice()
    {
    }

    public bool CreateImageForAttachment(string templateid, string cartitemid, string companyid, string _key)
    {
        bool flag = false;
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection
        };
        sqlCommand.Parameters.Add("@templateid", SqlDbType.BigInt);
        sqlCommand.Parameters["@templateid"].Value = Convert.ToInt64(templateid);
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = Convert.ToInt64(cartitemid);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "et_GetImageNameFor_Attachment";
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        this.AllProperties.Clear();
        sqlDataAdapter.SelectCommand = sqlCommand;
        sqlDataAdapter.Fill(dataTable);
        int count = dataTable.Columns.Count;
        List<string> strs = new List<string>();
        foreach (DataRow row in dataTable.Rows)
        {
            bool flag1 = Convert.ToBoolean(row["IsFromBackend"].ToString());
            bool flag2 = Convert.ToBoolean(row["IsFromPdf"].ToString());
            string str = row["ImageUrl"].ToString();
            string str1 = row["OriginalImageName"].ToString();
            str1 = str1.Replace(".png", ".pdf").Replace(".PNG", ".pdf");
            string str2 = row["UserId"].ToString();
            if (str == string.Empty)
            {
                continue;
            }
            string str3 = string.Concat(eprintConfigurationManager.AppSettings["UserPDfImagePath"].ToString(), companyid, "/Images/", str);
            string str4 = string.Concat(eprintConfigurationManager.AppSettings["ImagePathToSave"].ToString(), templateid, "/Images/", str);
            string str5 = string.Concat(eprintConfigurationManager.AppSettings["SecurePath"].ToString(), companyid, "/attachments/", str);
            if (!Directory.Exists(string.Concat(eprintConfigurationManager.AppSettings["SecurePath"].ToString(), companyid, "/attachments")))
            {
                Directory.CreateDirectory(string.Concat(eprintConfigurationManager.AppSettings["SecurePath"].ToString(), companyid, "/attachments"));
            }
            flag = true;
            if (!flag1)
            {
                if (!File.Exists(str4))
                {
                    continue;
                }
                File.Copy(str4, str5, true);
                if (!flag2)
                {
                    continue;
                }
                str5 = string.Concat(eprintConfigurationManager.AppSettings["SecurePath"].ToString(), companyid, "/attachments/", str1);
                string[] strArrays = new string[] { eprintConfigurationManager.AppSettings["ImagePathToSave"].ToString(), "UsersImages/", str2, "/pdf/", str1 };
                str4 = string.Concat(strArrays);
                File.Copy(str4, str5, true);
            }
            else
            {
                if (!File.Exists(str3))
                {
                    continue;
                }
                File.Copy(str3, str5, true);
                if (!flag2)
                {
                    continue;
                }
                str5 = string.Concat(eprintConfigurationManager.AppSettings["SecurePath"].ToString(), companyid, "/attachments/", str1);
                str3 = string.Concat(eprintConfigurationManager.AppSettings["UserPDfImagePath"].ToString(), companyid, "/pdf/", str1);
                File.Copy(str3, str5, true);
            }
        }
        return flag;
    }

    public string CreateImageThumbnails(long companyid, long templateid, long userid, string filenames, string finalFilesize, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        string str = "";
        string[] strArrays = filenames.Split(new char[] { ',' });
        string[] strArrays1 = strArrays[0].Split(new char[] { '.' });
        if (strArrays1[(int)strArrays1.Length - 1].ToString().ToLower().Contains("pdf") && finalFilesize != string.Empty)
        {
            string str1 = eprintConfigurationManager.AppSettings["ImagePathToSave"].ToString();
            string[] strArrays2 = finalFilesize.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays2.Length - 1; i++)
            {
                if (Convert.ToInt64(strArrays2[i]) <= (long)2097152)
                {
                    string str2 = strArrays[i];
                    string str3 = str2.Remove(str2.Length - 4);
                    object[] objArray = new object[] { str1, "UsersImages/", userid, "/pdf/", str2 };
                    string str4 = string.Concat(objArray);
                    object[] objArray1 = new object[] { str1, "UsersImages/", userid, "/Gallery/OriginalImages/", str3, ".png" };
                    string str5 = string.Concat(objArray1);
                    object[] objArray2 = new object[] { str1, "UsersImages/", userid, "/Gallery/ThumbnailImages/t_", str3, ".png" };
                    string.Concat(objArray2);
                    object[] objArray3 = new object[] { str1, "UsersImages/", userid, "/Gallery/OriginalImages/", str3 };
                    string.Concat(objArray3);
                    object[] objArray4 = new object[] { str1, "UsersImages/", userid, "/Gallery/OriginalImages" };
                    if (!Directory.Exists(string.Concat(objArray4)))
                    {
                        object[] objArray5 = new object[] { str1, "UsersImages/", userid, "/Gallery/OriginalImages" };
                        Directory.CreateDirectory(string.Concat(objArray5));
                    }
                    object[] objArray6 = new object[] { str1, "UsersImages/", userid, "/Gallery/ThumbnailImages" };
                    if (!Directory.Exists(string.Concat(objArray6)))
                    {
                        object[] objArray7 = new object[] { str1, "UsersImages/", userid, "/Gallery/ThumbnailImages" };
                        Directory.CreateDirectory(string.Concat(objArray7));
                    }
                    if (File.Exists(str4))
                    {
                        string empty = string.Empty;
                        empty = "imgconvert -units pixelspercentimeter -density 800 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"";
                        empty = empty.Replace("[PDF]", string.Concat(str4, "[0]")).Replace("[Image]", str5);
                        try
                        {
                            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", string.Concat("/c ", empty))
                            {
                                UseShellExecute = false,
                                CreateNoWindow = true
                            };
                            Process process = new Process()
                            {
                                StartInfo = processStartInfo
                            };
                            process.Start();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                str = string.Concat(str3, ".png");
                                str = (File.Exists(str5) ? string.Concat(str3, ".png") : string.Concat(str3, "-0.png"));
                                if (process.ExitCode == 0)
                                {
                                    SqlConnection sqlConnection = new SqlConnection()
                                    {
                                        ConnectionString = this.Templateconnectionstring
                                    };
                                    sqlConnection.Open();
                                    SqlCommand sqlCommand = new SqlCommand()
                                    {
                                        CommandType = CommandType.StoredProcedure,
                                        CommandText = "et_GetPDFtoConvertImage",
                                        Connection = sqlConnection
                                    };
                                    sqlCommand.ExecuteNonQuery();
                                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
                                    {
                                        SelectCommand = sqlCommand
                                    };
                                    DataSet dataSet = new DataSet();
                                    sqlDataAdapter.Fill(dataSet);
                                    foreach (DataRow row in dataSet.Tables[0].Rows)
                                    {
                                        if (row["UserType"].ToString().ToLower().Trim() != "user")
                                        {
                                            continue;
                                        }
                                        string str6 = "";
                                        str6 = (!row["OriginalFileName"].ToString().Contains(".pdf") ? row["OriginalFileName"].ToString() : row["OriginalFileName"].ToString().Remove(row["OriginalFileName"].ToString().Length - 4));
                                        string str7 = string.Concat(str3, ".png");
                                        str7 = (File.Exists(str5) ? string.Concat(str3, ".png") : string.Concat(str3, "-0.png"));
                                        this.UpdatePDFDetails(row["CompanyID"].ToString(), row["ImageID"].ToString(), str6, str7, _key);
                                        sqlConnection.Close();
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        return str;
    }


    public List<string> CreateResizedImage(long companyid, long templateid, long userid, string originalFilename, string path, double canvasWidth, double canvasHeight, double _zoompercnt, bool _iscropfromtop, bool Thumbnail100x100, string _key)
    {
        this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        List<string> strs = new List<string>();
        string empty = string.Empty;
        char[] chrArray = new char[] { ',' };
        if ((int)originalFilename.Split(chrArray).Length == 1)
        {
            Convert.ToInt32(canvasWidth);
            Convert.ToInt32(canvasHeight);
            try
            {
                path = string.Concat(eprintConfigurationManager.AppSettings["ImagePathToSave"].ToString(), templateid, "\\Images\\");
                Image image = Image.FromFile(string.Concat(path, originalFilename));
                int width = image.Width;
                int height = image.Height;
                createThumbnail _createThumbnail = new createThumbnail();
                image.Dispose();
                GC.Collect();
                string[] strArrays = empty.Split(new char[] { '~' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    strs.Add(strArrays[i].ToString());
                }
            }
            catch (Exception exception)
            {
                exception.Message.ToString();
            }
        }
        return strs;
    }

    public long DeleteGalleryImages(string imageid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GalleryImages_Delete", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public long DeleteImageCategory(string categoryid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ImageCategory_Delete", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public int DeleteMultipleFilesFolders(string categoryids, string imageids, int templateid, int companyid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        int num = 0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoriesID", categoryids), new SqlParameter("@FileIDs", imageids) };
        TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_DeleteMultipleFilesAndFolders", sqlParameter);
        return num;
    }

    public bool DeleteWsTemplateProperties(string templateid, string cartitemid, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = true;
        try
        {
            SqlConnection sqlConnection = new SqlConnection()
            {
                ConnectionString = this.Templateconnectionstring
            };
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "et_WS_TemplateProperties_Delete"
            };
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@TemplateID", SqlDbType.BigInt);
            sqlCommand.Parameters["@TemplateID"].Value = Convert.ToInt64(templateid);
            sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
            sqlCommand.Parameters["@CartItemID"].Value = Convert.ToInt64(cartitemid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    public List<ColorStyle> GetColorStyleDetailProperties(string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
        List<ColorStyle> colorStyles = new List<ColorStyle>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetColorStyleDetails", sqlParameter);
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            ColorStyle colorStyle = new ColorStyle()
            {
                C = row["C"].ToString(),
                M = row["M"].ToString(),
                Y = row["Y"].ToString(),
                K = row["K"].ToString(),
                R = Convert.ToDouble(row["R"]),
                G = Convert.ToDouble(row["G"]),
                B = Convert.ToDouble(row["B"]),
                A = Convert.ToDouble(row["A"]),
                ColorID = Convert.ToInt64(row["ColorID"].ToString()),
                ColorStyleName = row["ColorStyle"].ToString(),
                CompanyID = Convert.ToInt64(row["CompanyID"].ToString()),
                SpotColor = Convert.ToBoolean(row["SpotColor"]),
                SpotColorRef = row["SpotColorRef"].ToString(),
                TemplateID = Convert.ToInt64(row["TemplateID"].ToString()),
                Tint = Convert.ToDouble(row["Tint"]),
                UserID = Convert.ToInt64(row["UserID"].ToString())
            };
            colorStyles.Add(colorStyle);
        }
        return colorStyles;
    }

    public List<QueryStringPara> GetDecriptedQuerySting(string _quertstr)
    {
        List<QueryStringPara> queryStringParas = new List<QueryStringPara>();
        string str = Encrypt.Decrypt(_quertstr);
        string[] strArrays = str.Split(new char[] { '&' });
        if ((int)strArrays.Length > 0)
        {
            QueryStringPara queryStringPara = new QueryStringPara();
            try
            {
                string[] strArrays1 = strArrays[0].Split(new char[] { '=' });
                queryStringPara.TemplateID = Convert.ToInt64(strArrays1[1]);
                string str1 = strArrays[1];
                char[] chrArray = new char[] { '=' };
                queryStringPara.SessionID = str1.Split(chrArray)[1];
                string[] strArrays2 = strArrays[2].Split(new char[] { '=' });
                queryStringPara.CompanyID = Convert.ToInt64(strArrays2[1]);
                string[] strArrays3 = strArrays[3].Split(new char[] { '=' });
                queryStringPara.CartItemID = Convert.ToInt64(strArrays3[1]);
                string[] strArrays4 = strArrays[4].Split(new char[] { '=' });
                queryStringPara.PriceCatalogId = Convert.ToInt64(strArrays4[1]);
                string[] strArrays5 = strArrays[5].Split(new char[] { '=' });
                queryStringPara.StoreUserID = Convert.ToInt64(strArrays5[1]);
                string str2 = strArrays[6];
                char[] chrArray1 = new char[] { '=' };
                queryStringPara.dbKey = str2.Split(chrArray1)[1];
                string str3 = strArrays[7];
                char[] chrArray2 = new char[] { '=' };
                queryStringPara.Type = str3.Split(chrArray2)[1];
                string[] strArrays6 = strArrays[8].Split(new char[] { '=' });
                queryStringPara.AccountID = Convert.ToInt64(strArrays6[1]);
                queryStringParas.Add(queryStringPara);
            }
            catch
            {
            }
        }
        return queryStringParas;
    }

    public string GetDomainKey(string _EprintConnectKey)
    {
        DataTable dataTable = new DataTable();
        string str = "";
        string str1 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@EprintConnectKey", _EprintConnectKey) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(str1, CommandType.StoredProcedure, "et_GetDomainName", sqlParameter);
        dataTable = dataSet.Tables[0];
        if (dataTable.Rows.Count <= 0)
        {
            str = "";
            TemplateEditorFrontEndSevice.HostName = "";
            this.Templateconnectionstring = "";
        }
        else
        {
            str = dataTable.Rows[0][0].ToString();
            TemplateEditorFrontEndSevice.HostName = str;
        }
        return (new EprintConfigurationManager()).ConnectionStrings["TEMPLATECONNECTION"].ToString();
    }

    public List<TemplateEditorFrontEnd.Font> GetFontStyle(string FontStyle, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@FontStyle", FontStyle) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetFontStyle", sqlParameter);
        List<TemplateEditorFrontEnd.Font> fonts = new List<TemplateEditorFrontEnd.Font>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateEditorFrontEnd.Font font = new TemplateEditorFrontEnd.Font()
                {
                    Capitalize = row["Capitalize"].ToString(),
                    CompanyID = Convert.ToInt64(row["CompanyID"].ToString()),
                    DataType = row["DataType"].ToString(),
                    FontFamily = row["FontFamily"].ToString(),
                    FontID = Convert.ToInt64(row["FontID"].ToString()),
                    FontSize = Convert.ToDouble(row["FontSize"]),
                    FontStyleName = row["FontStyle"].ToString(),
                    Format = row["Format"].ToString(),
                    Indent = Convert.ToDouble(row["Indent"])
                };
                string str = row["ManualTracking"].ToString();
                string[] strArrays = str.Split(new char[] { ',' });
                font.TrackOffSet = strArrays[(int)strArrays.Length - 3];
                font.ManualTracking = Convert.ToDouble(strArrays[(int)strArrays.Length - 2]);
                font.TrackPoint = strArrays[(int)strArrays.Length - 1];
                font.TemplateID = Convert.ToInt64(row["TemplateID"].ToString());
                font.TextAlign = row["TextAlign"].ToString();
                font.UserID = Convert.ToInt64(row["UserID"].ToString());
                fonts.Add(font);
            }
        }
        return fonts;
    }

    public ImageGalleryParentResponse GetFrontendUserImageGallery(string companyid, string categoryid, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetFrontendUserGallery", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        List<ImageCategory> imageCategories1 = new List<ImageCategory>();
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            imageCategories.Add(new ImageCategory(Convert.ToInt64(row["CategoryID"].ToString()), Convert.ToInt64(row["CompanyID"].ToString()), row["CategoryName"].ToString(), row["Description"].ToString(), Convert.ToInt64(row["ParentID"].ToString()), row["CategoryImage"].ToString(), Convert.ToInt64(row["CreatedBy"].ToString())));
        }
        foreach (DataRow dataRow in dataSet.Tables[1].Rows)
        {
            imageCategories1.Add(new ImageCategory(Convert.ToInt64(dataRow["ImageID"].ToString()), Convert.ToInt64(dataRow["CompanyID"].ToString()), Convert.ToInt64(dataRow["CategoryID"].ToString()), Convert.ToInt64(dataRow["UserID"].ToString()), dataRow["UserType"].ToString(), dataRow["OriginalFileName"].ToString(), dataRow["FileName"].ToString(), Convert.ToInt64(dataRow["FileSize"].ToString()), dataRow["Description"].ToString(), dataRow["MetaTags"].ToString(), Convert.ToBoolean(dataRow["IsPdf"].ToString())));
        }
        long num = (long)-1;
        foreach (DataRow row1 in dataSet.Tables[2].Rows)
        {
            num = Convert.ToInt64(dataSet.Tables[2].Rows[0]["ParentID"].ToString());
        }
        ImageGalleryParentResponse imageGalleryParentResponse = new ImageGalleryParentResponse()
        {
            ImageCategories = imageCategories,
            ImageGallery = imageCategories1,
            ParentID = num
        };
        return imageGalleryParentResponse;
    }

    public List<ImageCategory> GetImageCategoryByFrontendUser(string companyid, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(userid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UserImageCategory_Select", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                imageCategories.Add(new ImageCategory(Convert.ToInt64(row["CategoryID"].ToString()), row["MultiLevelCategory"].ToString()));
            }
        }
        return imageCategories;
    }

    public Globals GetKeyValuesForPath(string _key)
    {
        Globals global = new Globals();
        if (_key != "")
        {
            this.GetDomainKey(_key);
            EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
            this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
            global.PdfImageUploadPath = eprintConfigurationManager.AppSettings["USERPDFIMAGEPATH"].ToString();
            global.PdfImagePath = eprintConfigurationManager.AppSettings["PDFIMAGEPATH"].ToString();
            global.BackendSitePath = eprintConfigurationManager.AppSettings["BACKENDSITEPATH"].ToString();
            global.FrontEndSitePath = eprintConfigurationManager.AppSettings["FrontEndSitePath"].ToString();
            global.FileUploadPath = eprintConfigurationManager.AppSettings["FILEUPLOADPATH"].ToString();
            global.FontPath = eprintConfigurationManager.AppSettings["FONTFILEPATH"].ToString();
            global.B2BSitePath = eprintConfigurationManager.AppSettings["B2BSITEPATH"].ToString();
            global.PublicSitePath = eprintConfigurationManager.AppSettings["PublicSitePath"].ToString();
            global.FrontEndUploadPath = eprintConfigurationManager.AppSettings["ImagePathToSave"].ToString();
            global.FrontEndDocumentPath = eprintConfigurationManager.AppSettings["FrontPath"].ToString();
            global.PDFAPIPath = eprintConfigurationManager.AppSettings["PDFAPIPath"].ToString();
            global.SecurePath = eprintConfigurationManager.AppSettings["SECUREPATH"];
        }
        return global;
    }

    public string GetProductName(string priceCatalogueID, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@PriceCatalogueID", priceCatalogueID) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_SelectProductName", sqlParameter);
        string str = "";
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            str = dataSet.Tables[0].Rows[0]["CatalogueName"].ToString().Replace("%27", "'").Replace("%22", "\"");
        }
        return str;
    }

    public ImageGalleryParentResponse GetSystemGalleryFoldersandFiles(string companyid, string categoryid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetFrontendSystemGallery_HTML5", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        List<ImageCategory> imageCategories1 = new List<ImageCategory>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables.Count > 0)
        {
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    imageCategories.Add(new ImageCategory(Convert.ToInt64(row["CategoryID"].ToString()), Convert.ToInt64(row["CompanyID"].ToString()), row["CategoryName"].ToString(), row["Description"].ToString(), Convert.ToInt64(row["ParentID"].ToString()), row["CategoryImage"].ToString(), Convert.ToInt64(row["CreatedBy"].ToString())));
                }
            }
            if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                {
                    imageCategories1.Add(new ImageCategory(Convert.ToInt64(dataRow["ImageID"].ToString()), Convert.ToInt64(dataRow["CompanyID"].ToString()), Convert.ToInt64(dataRow["CategoryID"].ToString()), Convert.ToInt64(dataRow["UserID"].ToString()), dataRow["UserType"].ToString(), dataRow["OriginalFileName"].ToString(), dataRow["FileName"].ToString(), Convert.ToInt64(dataRow["FileSize"].ToString()), dataRow["Description"].ToString(), dataRow["MetaTags"].ToString(), Convert.ToBoolean(dataRow["IsPdf"].ToString())));
                }
            }
        }
        return new ImageGalleryParentResponse()
        {
            ImageCategories = imageCategories,
            ImageGallery = imageCategories1
        };
    }

    public List<ImageCategory> GetSystemGallerySearch(string companyid, string categoryid, string templateid, string objectid, string searchtext, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", categoryid), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("@SearchText", searchtext) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "[et_HtmlEndUserGallerySearch_Select]", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            imageCategories.Add(new ImageCategory(Convert.ToInt64(row["ImageID"].ToString()), Convert.ToInt64(row["CompanyID"].ToString()), Convert.ToInt64(row["CategoryID"].ToString()), Convert.ToInt64(row["UserID"].ToString()), row["UserType"].ToString(), row["OriginalFileName"].ToString(), row["FileName"].ToString(), Convert.ToInt64(row["FileSize"].ToString()), row["Description"].ToString(), row["MetaTags"].ToString(), Convert.ToBoolean(row["IsPdf"].ToString())));
        }
        return imageCategories;
    }

    public ImageGalleryParentResponse GetSystemGallerySubFoldersandFiles(string companyid, string categoryid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetImageGalleryCategories", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        List<ImageCategory> imageCategories1 = new List<ImageCategory>();
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            imageCategories.Add(new ImageCategory(Convert.ToInt64(row["CategoryID"].ToString()), Convert.ToInt64(row["CompanyID"].ToString()), row["CategoryName"].ToString(), row["Description"].ToString(), Convert.ToInt64(row["ParentID"].ToString()), row["CategoryImage"].ToString(), Convert.ToInt64(row["CreatedBy"].ToString())));
        }
        foreach (DataRow dataRow in dataSet.Tables[1].Rows)
        {
            imageCategories1.Add(new ImageCategory(Convert.ToInt64(dataRow["ImageID"].ToString()), Convert.ToInt64(dataRow["CompanyID"].ToString()), Convert.ToInt64(dataRow["CategoryID"].ToString()), Convert.ToInt64(dataRow["UserID"].ToString()), dataRow["UserType"].ToString(), dataRow["OriginalFileName"].ToString(), dataRow["FileName"].ToString(), Convert.ToInt64(dataRow["FileSize"].ToString()), dataRow["Description"].ToString(), dataRow["MetaTags"].ToString(), Convert.ToBoolean(dataRow["IsPdf"].ToString())));
        }
        long num = (long)-1;
        foreach (DataRow row1 in dataSet.Tables[2].Rows)
        {
            num = Convert.ToInt64(dataSet.Tables[2].Rows[0]["ParentID"].ToString());
        }
        ImageGalleryParentResponse imageGalleryParentResponse = new ImageGalleryParentResponse()
        {
            ImageCategories = imageCategories,
            ImageGallery = imageCategories1,
            ParentID = num
        };
        return imageGalleryParentResponse;
    }

    public List<ImageCategory> GetUserGallerySearch(string companyid, string categoryid, string userid, string searchtext, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@SearchText", searchtext) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UserGallerySearchResult_Select", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            imageCategories.Add(new ImageCategory(Convert.ToInt64(row["ImageID"].ToString()), Convert.ToInt64(row["CompanyID"].ToString()), Convert.ToInt64(row["CategoryID"].ToString()), Convert.ToInt64(row["UserID"].ToString()), row["UserType"].ToString(), row["OriginalFileName"].ToString(), row["FileName"].ToString(), Convert.ToInt64(row["FileSize"].ToString()), row["Description"].ToString(), row["MetaTags"].ToString(), Convert.ToBoolean(row["IsPdf"].ToString())));
        }
        return imageCategories;
    }

    public List<HorzontalGroupDetails> HorizontalGroupDetails(string Companyid, string templateid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(Companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Select_HorizontalGroup_Details", sqlParameter);
        List<HorzontalGroupDetails> horzontalGroupDetails = new List<HorzontalGroupDetails>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                HorzontalGroupDetails horzontalGroupDetail = new HorzontalGroupDetails()
                {
                    GID = Convert.ToInt64(row["GID"].ToString()),
                    TemplateID = Convert.ToInt64(row["TEMPLATEID"].ToString()),
                    CompanyID = Convert.ToInt64(row["COMPANYID"].ToString()),
                    GroupName = row["GROUPNAME"].ToString(),
                    GrpKeepOption = row["KeepOptions"].ToString(),
                    Alignment = row["Alignment"].ToString(),
                    ControlSpace = Convert.ToDouble(row["ControlSpacing"].ToString()),
                    PositionX = Convert.ToDouble(row["PositionX"].ToString()),
                    PositionY = Convert.ToDouble(row["PositionY"].ToString()),
                    CurrentPositionX = Convert.ToDouble(row["PositionX"].ToString()),
                    CurrentPositionY = Convert.ToDouble(row["PositionY"].ToString()),
                    PageNumber = Convert.ToInt64(row["PageNumber"].ToString()),
                    GroupOption = row["GroupOption"].ToString(),
                    GroupMoveRelative = Convert.ToBoolean(row["GroupMoveRelative"].ToString()),
                    GroupMovementValue = Convert.ToDecimal(row["GroupMovementValue"].ToString())

                };
                horzontalGroupDetails.Add(horzontalGroupDetail);
            }
        }
        return horzontalGroupDetails;
    }

    public List<ImageCategory> ImageListAfterUpload(string ImageIDList, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", ImageIDList.Substring(0, ImageIDList.Length - 1)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetImageGalleryafterUpload", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ImageCategory imageCategory = new ImageCategory()
                {
                    ImageID = Convert.ToInt64(row["ImageID"].ToString()),
                    CompanyID = Convert.ToInt64(row["CompanyID"].ToString()),
                    CategoryID = Convert.ToInt64(row["CategoryID"].ToString()),
                    UserID = Convert.ToInt64(row["UserID"].ToString()),
                    UserType = row["UserType"].ToString(),
                    OriginalFileName = row["OriginalFileName"].ToString(),
                    FileName = row["FileName"].ToString(),
                    FileSize = Convert.ToInt64(row["FileSize"].ToString()),
                    Description = row["Description"].ToString(),
                    MetaTags = row["MetaTags"].ToString()
                };
                imageCategories.Add(imageCategory);
            }
        }
        return imageCategories;
    }

    public long InsertImageCategory(string companyid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryName", categoryname), new SqlParameter("@Description", description), new SqlParameter("@ParentID", (object)Convert.ToInt64(parentid)), new SqlParameter("@CategoryImage", categoryimage), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(createdby)), new SqlParameter("@UserType", "user"), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_InsertImageCategory", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public string InsertTemplateProperties(string PropertiesDetail, string templateid, string sessionid, string userid, string companyid, string cartitemid, string _key, string lastone)
    {
        TemplateFieldPropertiesFrontEnd templateFieldPropertiesFrontEnd = JsonConvert.DeserializeObject<TemplateFieldPropertiesFrontEnd>(PropertiesDetail);
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = true;
        try
        {
            SqlConnection sqlConnection = new SqlConnection()
            {
                ConnectionString = this.Templateconnectionstring
            };
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection
            };
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@DraftID", SqlDbType.BigInt);
            sqlCommand.Parameters["@DraftID"].Value = TemplateEditorFrontEndSevice.Draftid;
            sqlCommand.Parameters.Add("@TemplateID", SqlDbType.BigInt);
            sqlCommand.Parameters["@TemplateID"].Value = Convert.ToInt64(templateid);
            sqlCommand.Parameters.Add("@SessionID", SqlDbType.NVarChar);
            sqlCommand.Parameters["@SessionID"].Value = sessionid;
            sqlCommand.Parameters.Add("@CartIdOrOrderId", SqlDbType.BigInt);
            sqlCommand.Parameters["@CartIdOrOrderId"].Value = Convert.ToInt64(cartitemid);
            sqlCommand.Parameters.Add("@UserID", SqlDbType.BigInt);
            sqlCommand.Parameters["@UserID"].Value = Convert.ToInt64(userid);
            sqlCommand.Parameters.Add("@CompanyID", SqlDbType.BigInt);
            sqlCommand.Parameters["@CompanyID"].Value = Convert.ToInt64(companyid);
            sqlCommand.Parameters.Add("@ObjectID", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ObjectID"].Value = templateFieldPropertiesFrontEnd.ObjectID;
            sqlCommand.Parameters.Add("@FieldName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FieldName"].Value = templateFieldPropertiesFrontEnd.FieldName;
            sqlCommand.Parameters.Add("@FriendlyName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FriendlyName"].Value = templateFieldPropertiesFrontEnd.FriendlyName;
            sqlCommand.Parameters.Add("@HelpText", SqlDbType.NVarChar);
            sqlCommand.Parameters["@HelpText"].Value = templateFieldPropertiesFrontEnd.HelpText;
            sqlCommand.Parameters.Add("@Mandatory", SqlDbType.Bit);
            sqlCommand.Parameters["@Mandatory"].Value = templateFieldPropertiesFrontEnd.Mandatory;
            sqlCommand.Parameters.Add("@Edit", SqlDbType.Bit);
            sqlCommand.Parameters["@Edit"].Value = templateFieldPropertiesFrontEnd.Edit;
            sqlCommand.Parameters.Add("@Visibility", SqlDbType.Bit);
            sqlCommand.Parameters["@Visibility"].Value = templateFieldPropertiesFrontEnd.Visibility;
            sqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int);
            sqlCommand.Parameters["@PageNumber"].Value = templateFieldPropertiesFrontEnd.PageNumber;
            sqlCommand.Parameters.Add("@PositionX", SqlDbType.NVarChar);
            sqlCommand.Parameters["@PositionX"].Value = templateFieldPropertiesFrontEnd.PositionX;
            sqlCommand.Parameters.Add("@PositionY", SqlDbType.NVarChar);
            sqlCommand.Parameters["@PositionY"].Value = templateFieldPropertiesFrontEnd.PositionY;
            sqlCommand.Parameters.Add("@Lock", SqlDbType.Bit);
            sqlCommand.Parameters["@Lock"].Value = templateFieldPropertiesFrontEnd.Lock;
            sqlCommand.Parameters.Add("@MaxWidth", SqlDbType.Decimal);
            sqlCommand.Parameters["@MaxWidth"].Value = templateFieldPropertiesFrontEnd.MaxWidth;
            sqlCommand.Parameters.Add("@IsFromBackEnd", SqlDbType.Bit);
            sqlCommand.Parameters["@IsFromBackEnd"].Value = templateFieldPropertiesFrontEnd.IsFromBackEnd;
            sqlCommand.Parameters.Add("@ExceedWidth", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ExceedWidth"].Value = templateFieldPropertiesFrontEnd.ExceedWidth;
            sqlCommand.Parameters.Add("@MaxShrink", SqlDbType.Decimal);
            sqlCommand.Parameters["@MaxShrink"].Value = templateFieldPropertiesFrontEnd.MaxShrink;
            sqlCommand.Parameters.Add("@RotateAngle", SqlDbType.Decimal);
            sqlCommand.Parameters["@RotateAngle"].Value = templateFieldPropertiesFrontEnd.RotateAngle;
            sqlCommand.Parameters.Add("@FontStyle", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontStyle"].Value = templateFieldPropertiesFrontEnd.FontStyle;
            sqlCommand.Parameters.Add("@FontFamily", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontFamily"].Value = templateFieldPropertiesFrontEnd.FontFamily;
            sqlCommand.Parameters.Add("@FontSize", SqlDbType.Decimal);
            sqlCommand.Parameters["@FontSize"].Value = templateFieldPropertiesFrontEnd.FontSize;
            sqlCommand.Parameters.Add("@FontID", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontID"].Value = templateFieldPropertiesFrontEnd.FontID;
            sqlCommand.Parameters.Add("@LabelFontID", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelFontID"].Value = templateFieldPropertiesFrontEnd.LabelFontID;
            sqlCommand.Parameters.Add("@ManualTracking", SqlDbType.NVarChar);
            string[] manualTrackSign = new string[] { templateFieldPropertiesFrontEnd.ManualTrackSign, ",", templateFieldPropertiesFrontEnd.ManualTracking, ",", templateFieldPropertiesFrontEnd.ManualTrackDimension };
            string str = string.Concat(manualTrackSign);
            sqlCommand.Parameters["@ManualTracking"].Value = str;
            sqlCommand.Parameters.Add("@TextAlign", SqlDbType.NVarChar);
            sqlCommand.Parameters["@TextAlign"].Value = templateFieldPropertiesFrontEnd.TextAlign;
            sqlCommand.Parameters.Add("@Indent", SqlDbType.Decimal);
            sqlCommand.Parameters["@Indent"].Value = templateFieldPropertiesFrontEnd.Indent;
            sqlCommand.Parameters.Add("@Capitalize", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Capitalize"].Value = templateFieldPropertiesFrontEnd.Capitalize;
            sqlCommand.Parameters.Add("@DataType", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DataType"].Value = templateFieldPropertiesFrontEnd.DataType;
            sqlCommand.Parameters.Add("@Format", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Format"].Value = templateFieldPropertiesFrontEnd.Format;
            sqlCommand.Parameters.Add("@ColorStyle", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ColorStyle"].Value = templateFieldPropertiesFrontEnd.ColorStyle;
            sqlCommand.Parameters.Add("@FontColor", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontColor"].Value = templateFieldPropertiesFrontEnd.Color;
            sqlCommand.Parameters.Add("@C", SqlDbType.NVarChar);
            sqlCommand.Parameters["@C"].Value = templateFieldPropertiesFrontEnd.C;
            sqlCommand.Parameters.Add("@M", SqlDbType.NVarChar);
            sqlCommand.Parameters["@M"].Value = templateFieldPropertiesFrontEnd.M;
            sqlCommand.Parameters.Add("@Y", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Y"].Value = templateFieldPropertiesFrontEnd.Y;
            sqlCommand.Parameters.Add("@K", SqlDbType.NVarChar);
            sqlCommand.Parameters["@K"].Value = templateFieldPropertiesFrontEnd.K;
            sqlCommand.Parameters.Add("@R", SqlDbType.Decimal);
            sqlCommand.Parameters["@R"].Value = templateFieldPropertiesFrontEnd.R;
            sqlCommand.Parameters.Add("@G", SqlDbType.Decimal);
            sqlCommand.Parameters["@G"].Value = templateFieldPropertiesFrontEnd.G;
            sqlCommand.Parameters.Add("@B", SqlDbType.Decimal);
            sqlCommand.Parameters["@B"].Value = templateFieldPropertiesFrontEnd.B;
            sqlCommand.Parameters.Add("@A", SqlDbType.Decimal);
            sqlCommand.Parameters["@A"].Value = templateFieldPropertiesFrontEnd.A;
            sqlCommand.Parameters.Add("@Tint", SqlDbType.Decimal);
            sqlCommand.Parameters["@Tint"].Value = templateFieldPropertiesFrontEnd.Tint;
            sqlCommand.Parameters.Add("@SpotColor", SqlDbType.Bit);
            sqlCommand.Parameters["@SpotColor"].Value = templateFieldPropertiesFrontEnd.SpotColor;
            sqlCommand.Parameters.Add("@SpotColorRef", SqlDbType.NVarChar);
            sqlCommand.Parameters["@SpotColorRef"].Value = templateFieldPropertiesFrontEnd.SpotColorRef;
            sqlCommand.Parameters.Add("@DefaultContent", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DefaultContent"].Value = templateFieldPropertiesFrontEnd.DefaultContent;
            sqlCommand.Parameters.Add("@DatabaseContent", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DatabaseContent"].Value = templateFieldPropertiesFrontEnd.DatabaseContent;
            sqlCommand.Parameters.Add("@PhraseBookID", SqlDbType.Int);
            sqlCommand.Parameters["@PhraseBookID"].Value = templateFieldPropertiesFrontEnd.PhraseBookID;
            sqlCommand.Parameters.Add("@PhraseType", SqlDbType.NVarChar);
            sqlCommand.Parameters["@PhraseType"].Value = templateFieldPropertiesFrontEnd.PhraseType;
            sqlCommand.Parameters.Add("@Dropdowns", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Dropdowns"].Value = templateFieldPropertiesFrontEnd.Dropdowns;
            sqlCommand.Parameters.Add("@Labels", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Labels"].Value = templateFieldPropertiesFrontEnd.Labels;
            sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Value"].Value = templateFieldPropertiesFrontEnd.LabelValue;
            sqlCommand.Parameters.Add("@LabelFontSize", SqlDbType.Decimal);
            sqlCommand.Parameters["@LabelFontSize"].Value = templateFieldPropertiesFrontEnd.LabelFontSize;
            sqlCommand.Parameters.Add("@LabelStyle", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelStyle"].Value = templateFieldPropertiesFrontEnd.LabelStyle;
            sqlCommand.Parameters.Add("@LabelFontStyle", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelFontStyle"].Value = templateFieldPropertiesFrontEnd.LabelFontStyle;
            sqlCommand.Parameters.Add("@LabelColor", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelColor"].Value = templateFieldPropertiesFrontEnd.LabelColor;
            sqlCommand.Parameters.Add("@LabelPosition", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelPosition"].Value = templateFieldPropertiesFrontEnd.LabelPosition;
            sqlCommand.Parameters.Add("@CustomLeft", SqlDbType.Decimal);
            sqlCommand.Parameters["@CustomLeft"].Value = templateFieldPropertiesFrontEnd.CustomLeft;
            sqlCommand.Parameters.Add("@CustomTop", SqlDbType.Decimal);
            sqlCommand.Parameters["@CustomTop"].Value = templateFieldPropertiesFrontEnd.CustomTop;
            sqlCommand.Parameters.Add("@CustomRight", SqlDbType.Decimal);
            sqlCommand.Parameters["@CustomRight"].Value = templateFieldPropertiesFrontEnd.CustomRight;
            sqlCommand.Parameters.Add("@FieldType", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FieldType"].Value = templateFieldPropertiesFrontEnd.Type;
            sqlCommand.Parameters.Add("@ImageUrl", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ImageUrl"].Value = templateFieldPropertiesFrontEnd.ImgUrl;
            sqlCommand.Parameters.Add("@OriginalImageName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OriginalImageName"].Value = templateFieldPropertiesFrontEnd.OrignalImageName;
            sqlCommand.Parameters.Add("@LineSpacing", SqlDbType.Decimal);
            sqlCommand.Parameters["@LineSpacing"].Value = templateFieldPropertiesFrontEnd.ParaLineSpace;
            sqlCommand.Parameters.Add("@MaxHeight", SqlDbType.Decimal);
            sqlCommand.Parameters["@MaxHeight"].Value = templateFieldPropertiesFrontEnd.MaxHeight;
            sqlCommand.Parameters.Add("@ExceedHeight", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ExceedHeight"].Value = templateFieldPropertiesFrontEnd.ExceedHeight;
            sqlCommand.Parameters.Add("@ExceedImage", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ExceedImage"].Value = templateFieldPropertiesFrontEnd.ExceedImage;
            sqlCommand.Parameters.Add("@ImageLocation", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ImageLocation"].Value = templateFieldPropertiesFrontEnd.ImageLocation;
            sqlCommand.Parameters.Add("@LabelActualFontName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelActualFontName"].Value = templateFieldPropertiesFrontEnd.LabelActualFontName;
            sqlCommand.Parameters.Add("@LabelFontExtension", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LabelFontExtension"].Value = templateFieldPropertiesFrontEnd.LabelFontExtension;
            sqlCommand.Parameters.Add("@Align", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Align"].Value = templateFieldPropertiesFrontEnd.Align;
            sqlCommand.Parameters.Add("@FieldTop", SqlDbType.Decimal);
            sqlCommand.Parameters["@FieldTop"].Value = templateFieldPropertiesFrontEnd.Top;
            sqlCommand.Parameters.Add("@FieldLeft", SqlDbType.Decimal);
            sqlCommand.Parameters["@FieldLeft"].Value = templateFieldPropertiesFrontEnd.Left;
            sqlCommand.Parameters.Add("@Width", SqlDbType.Decimal);
            sqlCommand.Parameters["@Width"].Value = templateFieldPropertiesFrontEnd.Width;
            sqlCommand.Parameters.Add("@Height", SqlDbType.Decimal);
            sqlCommand.Parameters["@Height"].Value = templateFieldPropertiesFrontEnd.Height;
            sqlCommand.Parameters.Add("@FontWeight", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontWeight"].Value = templateFieldPropertiesFrontEnd.FontWeight;
            sqlCommand.Parameters.Add("@FontStyleName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontStyleName"].Value = templateFieldPropertiesFrontEnd.FontStyleName;
            sqlCommand.Parameters.Add("@BackgroundColor", SqlDbType.NVarChar);
            sqlCommand.Parameters["@BackgroundColor"].Value = templateFieldPropertiesFrontEnd.BackgroundImage;
            sqlCommand.Parameters.Add("@OffsetWidth", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OffsetWidth"].Value = templateFieldPropertiesFrontEnd.OffsetWidth;
            sqlCommand.Parameters.Add("@OffsetHeight", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OffsetHeight"].Value = templateFieldPropertiesFrontEnd.OffsetHeight;
            sqlCommand.Parameters.Add("@OffsetTop", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OffsetTop"].Value = templateFieldPropertiesFrontEnd.OffsetTop;
            sqlCommand.Parameters.Add("@OffsetLeft", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OffsetLeft"].Value = templateFieldPropertiesFrontEnd.OffsetLeft;
            sqlCommand.Parameters.Add("@PixelWidth", SqlDbType.NVarChar);
            sqlCommand.Parameters["@PixelWidth"].Value = templateFieldPropertiesFrontEnd.PixelWidth;
            sqlCommand.Parameters.Add("@OrderStatus", SqlDbType.NVarChar);
            sqlCommand.Parameters["@OrderStatus"].Value = "S";
            sqlCommand.Parameters.Add("@Hide", SqlDbType.Bit);
            sqlCommand.Parameters["@Hide"].Value = templateFieldPropertiesFrontEnd.HideVisibility;
            sqlCommand.Parameters.Add("@CanChangeFontColor", SqlDbType.Bit);
            sqlCommand.Parameters["@CanChangeFontColor"].Value = templateFieldPropertiesFrontEnd.CanChangeFontColor;
            sqlCommand.Parameters.Add("@CanChangeFontSize", SqlDbType.Bit);
            sqlCommand.Parameters["@CanChangeFontSize"].Value = templateFieldPropertiesFrontEnd.CanChangeFontSize;
            sqlCommand.Parameters.Add("@CanChangeFont", SqlDbType.Bit);
            sqlCommand.Parameters["@CanChangeFont"].Value = templateFieldPropertiesFrontEnd.CanChangeFont;
            sqlCommand.Parameters.Add("@ObjectTag", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ObjectTag"].Value = templateFieldPropertiesFrontEnd.ObjTag;
            sqlCommand.Parameters.Add("@GroupID", SqlDbType.BigInt);
            sqlCommand.Parameters["@GroupID"].Value = templateFieldPropertiesFrontEnd.GroupID;
            sqlCommand.Parameters.Add("@ControlOrderNumber", SqlDbType.Int);
            sqlCommand.Parameters["@ControlOrderNumber"].Value = templateFieldPropertiesFrontEnd.OrderNumber;
            sqlCommand.Parameters.Add("@GroupOrientation", SqlDbType.NVarChar);
            sqlCommand.Parameters["@GroupOrientation"].Value = templateFieldPropertiesFrontEnd.GroupOrientation;
            sqlCommand.Parameters.Add("@IsDefaultContentChanged", SqlDbType.Bit);
            sqlCommand.Parameters["@IsDefaultContentChanged"].Value = templateFieldPropertiesFrontEnd.IsDefaultContentChanged;
            sqlCommand.Parameters.Add("@KeepOptions", SqlDbType.NVarChar);
            sqlCommand.Parameters["@KeepOptions"].Value = templateFieldPropertiesFrontEnd.KeepOptions;
            sqlCommand.Parameters.Add("@FontExtension", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FontExtension"].Value = templateFieldPropertiesFrontEnd.FontExtension;
            sqlCommand.Parameters.Add("@ActualFontName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ActualFontName"].Value = templateFieldPropertiesFrontEnd.ActualFontName;
            sqlCommand.Parameters.Add("@ImageGallery", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ImageGallery"].Value = templateFieldPropertiesFrontEnd.ImageGallery;
            sqlCommand.Parameters.Add("@ImageSource", SqlDbType.NVarChar);
            sqlCommand.Parameters["@ImageSource"].Value = templateFieldPropertiesFrontEnd.ImageSource;
            sqlCommand.Parameters.Add("@IsCropFromTop", SqlDbType.Bit);
            sqlCommand.Parameters["@IsCropFromTop"].Value = templateFieldPropertiesFrontEnd.IsCropFromTop;
            sqlCommand.Parameters.Add("@IsCropped", SqlDbType.Bit);
            sqlCommand.Parameters["@IsCropped"].Value = templateFieldPropertiesFrontEnd.IsCropped;
            sqlCommand.Parameters.Add("@EditedImageName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@EditedImageName"].Value = templateFieldPropertiesFrontEnd.EditedImageName;
            sqlCommand.Parameters.Add("@ZIndexValue", SqlDbType.Int);
            sqlCommand.Parameters["@ZIndexValue"].Value = templateFieldPropertiesFrontEnd.ZIndexValue;
            sqlCommand.Parameters.Add("@IsImageQuality", SqlDbType.Bit);
            sqlCommand.Parameters["@IsImageQuality"].Value = templateFieldPropertiesFrontEnd.IsImageQuality;
            sqlCommand.Parameters.Add("@MinDPI", SqlDbType.Int);
            sqlCommand.Parameters["@MinDPI"].Value = templateFieldPropertiesFrontEnd.MinDPI;
            sqlCommand.Parameters.Add("@isDisplayonPDf", SqlDbType.Bit);
            sqlCommand.Parameters["@isDisplayonPDf"].Value = templateFieldPropertiesFrontEnd.isDisplayonPDf;
            sqlCommand.Parameters.Add("@DefaultImageFrom", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DefaultImageFrom"].Value = templateFieldPropertiesFrontEnd.DefaultImageFrom;
            sqlCommand.Parameters.Add("@CustomFieldType", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CustomFieldType"].Value = templateFieldPropertiesFrontEnd.CustomFieldType;
            sqlCommand.Parameters.Add("@UsedImageID", SqlDbType.Int);
            sqlCommand.Parameters["@UsedImageID"].Value = templateFieldPropertiesFrontEnd.UsedImageId;
            sqlCommand.Parameters.Add("@IsFromPdf", SqlDbType.Bit);
            sqlCommand.Parameters["@IsFromPdf"].Value = templateFieldPropertiesFrontEnd.IsFromPdf;
            sqlCommand.Parameters.Add("@AllowImageEdit", SqlDbType.Bit);
            sqlCommand.Parameters["@AllowImageEdit"].Value = templateFieldPropertiesFrontEnd.AllowImageEdit;
            sqlCommand.Parameters.Add("@IsJobNameField", SqlDbType.Bit);
            sqlCommand.Parameters["@IsJobNameField"].Value = templateFieldPropertiesFrontEnd.IsJobNameField;
            sqlCommand.Parameters.Add("@PhoneFormat", SqlDbType.NVarChar);
            sqlCommand.Parameters["@PhoneFormat"].Value = templateFieldPropertiesFrontEnd.PhoneFormat;
            sqlCommand.Parameters.Add("@CurrencyFormat", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CurrencyFormat"].Value = templateFieldPropertiesFrontEnd.CurrencyFormat;
            sqlCommand.Parameters.Add("@EditDropdown", SqlDbType.Bit);
            sqlCommand.Parameters["@EditDropdown"].Value = templateFieldPropertiesFrontEnd.EditDropdown;
            sqlCommand.CommandText = "[et_WS_TemplateProperties_Insert_HTML5]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception exception)
        {
            flag = false;
        }
        return string.Concat(flag, ",", lastone);
    }

    public string InsertUserImageGallery(string companyid, string templateid, string categoryid, string userid, string usertype, string fileList, string description, string metatags, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = true;
        string[] strArrays = fileList.Split(new char[] { ',' });
        string str = "";
        for (int i = 0; i < (int)strArrays.Length; i++)
        {
            if (strArrays[i] != "")
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '~' });
                string str1 = strArrays1[1];
                string str2 = string.Concat(strArrays1[0], "_", strArrays1[1]);
                string str3 = strArrays1[2];
                string[] strArrays2 = str1.ToString().Split(new char[] { '.' });
                flag = (!strArrays2[(int)strArrays2.Length - 1].ToString().ToLower().Contains("pdf") ? false : true);
                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@UserType", usertype), new SqlParameter("@OriginalFileName", str1), new SqlParameter("@FileName", str2), new SqlParameter("@FileSize", (object)Convert.ToInt64(str3)), new SqlParameter("@Description", description), new SqlParameter("@MetaTags", metatags), new SqlParameter("@IsPDF", (object)flag), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray = sqlParameter;
                TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_InsertImageGallery", sqlParameterArray);
                str = string.Concat(str, sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString(), ",");
            }
        }
        return str;
    }

    public List<AddressBook> LoadDataBaseContentsAddress(string userid, string cartitemid, string type, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_LoadDefaultContent_BasedOnContact_HTML"
        };
        sqlCommand.Parameters.Add("@StoreuserID", SqlDbType.BigInt);
        sqlCommand.Parameters["@StoreuserID"].Value = Convert.ToInt64(userid);
        sqlCommand.Parameters.Add("@cartitemid", SqlDbType.BigInt);
        sqlCommand.Parameters["@cartitemid"].Value = Convert.ToInt64(cartitemid);
        sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar);
        sqlCommand.Parameters["@Type"].Value = type;
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        List<AddressBook> addressBooks = new List<AddressBook>();
        sqlDataAdapter.SelectCommand = sqlCommand;
        using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter1.Fill(dataTable);
        }
        foreach (DataRow row in dataTable.Rows)
        {
            AddressBook addressBook = new AddressBook()
            {
                Label = row["label"].ToString().Replace("%27", "'").Replace("%22", "\"")
            };
            object[] objArray = new object[] { row["AddressLine1"].ToString().Replace("%27", "'").Replace("%22", "\""), "\r\n", row["AddressLine2"].ToString().Replace("%27", "'").Replace("%22", "\""), "\r\n", row["City"].ToString().Replace("%27", "'").Replace("%22", "\""), ' ', row["State"].ToString().Replace("%27", "'").Replace("%22", "\""), ' ', row["Country"].ToString().Replace("%27", "'").Replace("%22", "\""), ' ', row["ZipCode"].ToString().Replace("%27", "'").Replace("%22", "\"") };
            addressBook.Address = string.Concat(objArray);
            addressBooks.Add(addressBook);
        }
        return addressBooks;
    }

    public List<DefaultPhrase> LoadDataBasePhraseTextForDropDowns(string Companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_SelectPhraseText"
        };
        sqlCommand.Parameters.Add("@CompanyID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CompanyID"].Value = Convert.ToInt64(Companyid);
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        List<DefaultPhrase> defaultPhrases = new List<DefaultPhrase>();
        sqlDataAdapter.SelectCommand = sqlCommand;
        using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter1.Fill(dataTable);
        }
        foreach (DataRow row in dataTable.Rows)
        {
            DefaultPhrase defaultPhrase = new DefaultPhrase()
            {
                PhraseID = Convert.ToInt32(row["PhraseBookID"]),
                Type = row["Type"].ToString(),
                Title = row["Title"].ToString(),
                PhrasText = row["PhraseText"].ToString().Replace("%27", "'").Replace("%22", "\""),
                Seperator = row["LineSeparator"].ToString()
            };
            try
            {
                defaultPhrase.LabelSeparator = row["LabelSeparator"].ToString();
            }
            catch (Exception exception)
            {
                defaultPhrase.LabelSeparator = string.Empty;
            }
            defaultPhrases.Add(defaultPhrase);
        }
        return defaultPhrases;
    }

    public List<string> LoadDataBasePhrasstextBasedOnType(string userid, string cartitemid, string phraseid, string templateid, string type, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_GetPhraseDetails_BasedOnType"
        };
        sqlCommand.Parameters.Add("@StoreuserID", SqlDbType.BigInt);
        sqlCommand.Parameters["@StoreuserID"].Value = Convert.ToInt64(userid);
        sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar);
        sqlCommand.Parameters["@Type"].Value = type;
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        List<string> strs = new List<string>();
        sqlDataAdapter.SelectCommand = sqlCommand;
        using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter1.Fill(dataTable);
        }
        SqlCommand num = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_SelectPhraseText_BasedOnID",
            Connection = sqlConnection
        };
        num.Parameters.Add("@TemplateID", SqlDbType.BigInt);
        num.Parameters["@TemplateID"].Value = Convert.ToInt64(templateid);
        num.Parameters.Add("@PhraseBookID", SqlDbType.BigInt);
        num.Parameters["@PhraseBookID"].Value = Convert.ToInt64(phraseid);
        DataTable dataTable1 = new DataTable();
        (new SqlDataAdapter()).SelectCommand = num;
        using (SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(num))
        {
            sqlDataAdapter2.Fill(dataTable1);
        }
        string str = dataTable1.Rows[0]["PhraseText"].ToString().Replace("%27", "'").Replace("%22", "\"");
        string str1 = dataTable1.Rows[0]["LineSeparator"].ToString();
        string empty = string.Empty;
        try
        {
            dataTable1.Rows[0]["LabelSeparator"].ToString();
        }
        catch (Exception exception)
        {
        }
        foreach (DataRow row in dataTable.Rows)
        {
            string lower = str.ToLower();
            foreach (DataColumn column in dataTable.Columns)
            {
                lower = lower.Replace(string.Concat("[#", column.ColumnName.ToLower(), "#]"), row[column.ColumnName].ToString().Replace("%27", "'").Replace("%22", "\"")).Trim();
            }
            lower = lower.Replace("\\\\", str1);
            strs.Add(lower);
        }
        return (
            from i in strs
            orderby i
            select i).ToList<string>();
    }

    public List<string> LoadDataForDropDownDepartment(string cartitemid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_Get_Behalf_DeptId"
        };
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = Convert.ToInt64(cartitemid);
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        List<string> strs = new List<string>();
        sqlDataAdapter.SelectCommand = sqlCommand;
        using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter1.Fill(dataTable);
        }
        foreach (DataRow row in dataTable.Rows)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                strs.Add(row[column].ToString().Replace("%27", "'").Replace("%22", "\""));
            }
        }
        return strs;
    }

    public List<string> LoadDataForDropDownsContact(string StoreuserID, string Type, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            Connection = sqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_LoadDefaultContent_BasedOnContactType"
        };
        sqlCommand.Parameters.Add("@StoreuserID", SqlDbType.BigInt);
        sqlCommand.Parameters["@StoreuserID"].Value = Convert.ToInt64(StoreuserID);
        sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar);
        sqlCommand.Parameters["@Type"].Value = Type;
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        List<string> strs = new List<string>();
        sqlDataAdapter.SelectCommand = sqlCommand;
        using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter1.Fill(dataTable);
        }
        foreach (DataRow row in dataTable.Rows)
        {
            string[] strArrays = new string[] { row[0].ToString().Replace("%27", "'").Replace("%22", "\""), " ", row[1].ToString().Replace("%27", "'").Replace("%22", "\""), " ", row[2].ToString().Replace("%27", "'").Replace("%22", "\"") };
            strs.Add(string.Concat(strArrays));
        }
        return strs;
    }

    public List<TemplateEditorFrontEnd.Font> LoadFonts(string companyid, string _key)
    {
        List<TemplateEditorFrontEnd.Font> fonts = new List<TemplateEditorFrontEnd.Font>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadFontFamily", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateEditorFrontEnd.Font font = new TemplateEditorFrontEnd.Font()
                {
                    DisplayFontName = row["FontName"].ToString(),
                    ActualFontName = row["ActualFontFamilyName"].ToString(),
                    FontID = (long)Convert.ToInt32(row["FontID"].ToString()),
                    FontFilePath = row["FontFilePath"].ToString()
                };
                fonts.Add(font);
            }
        }
        return fonts;
    }

    public List<TemplateFieldPropertiesFrontEnd> LoadFontStyle(string companyid, string _key)
    {
        List<TemplateFieldPropertiesFrontEnd> templateFieldPropertiesFrontEnds = new List<TemplateFieldPropertiesFrontEnd>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadFontStyles", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateFieldPropertiesFrontEnd templateFieldPropertiesFrontEnd = new TemplateFieldPropertiesFrontEnd()
                {
                    FontSyleID = Convert.ToInt64(row["FontID"]),
                    UserFontSyleName = row["FontStyle"].ToString()
                };
                templateFieldPropertiesFrontEnds.Add(templateFieldPropertiesFrontEnd);
            }
        }
        return templateFieldPropertiesFrontEnds;
    }

    public List<TemplateFieldPropertiesFrontEnd> LoadTemplateControlls(string cartitemid, string templateid, string userid, string companyid, string _key)
    {
        double num;
        string str;
        GlobalSitePaths globalSitePath = new GlobalSitePaths();
        Globals sitePaths = globalSitePath.GetSitePaths((long)Convert.ToInt32(companyid), _key);
        List<TemplateFieldPropertiesFrontEnd> templateFieldPropertiesFrontEnds = new List<TemplateFieldPropertiesFrontEnd>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@templateid", (object)Convert.ToInt64(templateid)), new SqlParameter("@CartItemID", (object)Convert.ToInt64(cartitemid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Load_FrontEnd_TemplateProperties_HTML5", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateFieldPropertiesFrontEnd templateFieldPropertiesFrontEnd = new TemplateFieldPropertiesFrontEnd()
                {
                    Align = row["Align"].ToString(),
                    BackgroundImage = row["BackgroundColor"].ToString(),
                    C = row["C"].ToString(),
                    CanChangeFont = Convert.ToBoolean(row["CanChangeFont"]),
                    CanChangeFontColor = Convert.ToBoolean(row["CanChangeFontColor"]),
                    CanChangeFontSize = Convert.ToBoolean(row["CanChangeFontSize"]),
                    CanMove = Convert.ToBoolean(row["Edit"]),
                    Capitalize = row["Capitalize"].ToString(),
                    Color = row["FontColor"].ToString(),
                    ColorStyle = row["ColorStyle"].ToString(),
                    CoordsX = Convert.ToDouble(row["PositionX"]),
                    CoordsY = Convert.ToDouble(row["PositionY"]),
                    Copy = false,
                    CustomLeft = Convert.ToDouble(row["CustomLeft"]),
                    CustomRight = Convert.ToDouble(row["CustomRight"]),
                    CustomTop = Convert.ToDouble(row["CustomTop"]),
                    Dropdowns = row["Dropdowns"].ToString(),
                    DatabaseContent = row["DatabaseContent"].ToString(),
                    DefaultContent = row["DefaultContent"].ToString()
                };
                if (templateFieldPropertiesFrontEnd.DefaultContent != string.Empty || Convert.ToBoolean(row["IsOrderBehalfChange"]))
                {
                    if (templateFieldPropertiesFrontEnd.Dropdowns == "Contact" && templateFieldPropertiesFrontEnd.DatabaseContent != "")
                    {
                        SqlParameter[] sqlParameterArray = new SqlParameter[] { new SqlParameter("@CompanyId", (object)Convert.ToInt64(companyid)), new SqlParameter("@StoreuserID", (object)Convert.ToInt64(userid)), new SqlParameter("@CartitemID", (object)Convert.ToInt64(cartitemid)), new SqlParameter("@Type", templateFieldPropertiesFrontEnd.Dropdowns) };
                        DataSet dataSet1 = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultCustomFields_BasedOnContactDepartment", sqlParameterArray);
                        if (dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0)
                        {
                            DataTable item = dataSet1.Tables[0];
                            string str1 = templateFieldPropertiesFrontEnd.DefaultContent.ToString().Replace("\n", "");
                            if (Convert.ToBoolean(row["IsOrderBehalfChange"]))
                            {
                                str1 = templateFieldPropertiesFrontEnd.DatabaseContent.ToString().Replace("\n", "");
                            }
                            string str2 = str1;
                            foreach (DataRow dataRow in item.Rows)
                            {
                                foreach (DataColumn column in item.Columns)
                                {
                                    str2 = str2.Replace(string.Concat("#", column.ColumnName, "#"), dataRow[column.ColumnName].ToString().Replace("%27", "'").Replace("%22", "\"")).Trim();
                                }
                                if (templateFieldPropertiesFrontEnd.DefaultContent.Trim().ToLower() != templateFieldPropertiesFrontEnd.DatabaseContent.Trim().ToLower())
                                {
                                    continue;
                                }
                                templateFieldPropertiesFrontEnd.DefaultContent = str2.Replace("%27", "'").Replace("%22", "\"");
                            }
                            if (dataSet1.Tables.Count > 1 && dataSet1.Tables[1] != null)
                            {
                                DataTable dataTable = dataSet1.Tables[1];
                                foreach (DataRow row1 in dataTable.Rows)
                                {
                                    foreach (DataColumn dataColumn in dataTable.Columns)
                                    {
                                        str2 = str2.Replace(string.Concat("#", dataColumn.ColumnName.Replace("%27", "'").Replace("%22", "\""), "#"), row1[dataColumn.ColumnName].ToString().Replace("%27", "'").Replace("%22", "\"")).Trim();
                                    }
                                }
                            }
                            templateFieldPropertiesFrontEnd.DefaultContent = str2.Replace("%27", "'").Replace("%22", "\"");
                        }
                    }
                    else if (templateFieldPropertiesFrontEnd.Dropdowns == "Department" && templateFieldPropertiesFrontEnd.DatabaseContent != "")
                    {
                        SqlParameter[] sqlParameter1 = new SqlParameter[] { new SqlParameter("@CompanyId", (object)Convert.ToInt64(companyid)), new SqlParameter("@StoreuserID", (object)Convert.ToInt64(userid)), new SqlParameter("@CartitemID", (object)Convert.ToInt64(cartitemid)), new SqlParameter("@Type", templateFieldPropertiesFrontEnd.Dropdowns) };
                        DataSet dataSet2 = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultCustomFields_BasedOnContactDepartment", sqlParameter1);
                        string str3 = templateFieldPropertiesFrontEnd.DefaultContent.ToString().Replace("\n", "");
                        if (Convert.ToBoolean(row["IsOrderBehalfChange"]))
                        {
                            str3 = templateFieldPropertiesFrontEnd.DatabaseContent.ToString().Replace("\n", "");
                        }
                        if (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
                        {
                            DataTable item1 = dataSet2.Tables[0];
                            string str4 = str3;
                            foreach (DataRow dataRow1 in item1.Rows)
                            {
                                foreach (DataColumn column1 in item1.Columns)
                                {
                                    str4 = str4.Replace(string.Concat("#", column1.ColumnName, "#"), dataRow1[column1.ColumnName.Replace("%27", "'").Replace("%22", "\"")].ToString()).Trim();
                                }
                                if (templateFieldPropertiesFrontEnd.DefaultContent.Trim().ToLower() != templateFieldPropertiesFrontEnd.DatabaseContent.Trim().ToLower())
                                {
                                    continue;
                                }
                                templateFieldPropertiesFrontEnd.DefaultContent = str4.Replace("%27", "'").Replace("%22", "\"");
                            }
                            if (dataSet2.Tables.Count > 1 && dataSet2.Tables[1] != null)
                            {
                                DataTable dataTable1 = dataSet2.Tables[1];
                                foreach (DataRow row2 in dataTable1.Rows)
                                {
                                    foreach (DataColumn dataColumn1 in dataTable1.Columns)
                                    {
                                        str4 = str4.Replace(string.Concat("#", dataColumn1.ColumnName.Replace("%27", "'").Replace("%22", "\""), "#"), row2[dataColumn1.ColumnName].ToString().Replace("%27", "'").Replace("%22", "\""));
                                    }
                                }
                            }
                            templateFieldPropertiesFrontEnd.DefaultContent = str4.Replace("%27", "'").Replace("%22", "\"");
                        }
                    }
                    else if (templateFieldPropertiesFrontEnd.Dropdowns == "Address" && templateFieldPropertiesFrontEnd.DatabaseContent != "")
                    {
                        sqlParameter = new SqlParameter[] { new SqlParameter("@cartitemid", (object)Convert.ToInt64(cartitemid)), new SqlParameter("@StoreuserID", (object)Convert.ToInt64(userid)), new SqlParameter("@Type", templateFieldPropertiesFrontEnd.Dropdowns) };
                        DataSet dataSet3 = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultContent_BasedOnContact", sqlParameter);
                        string str5 = templateFieldPropertiesFrontEnd.DefaultContent.ToString().Replace("\n", "");
                        if (dataSet3.Tables.Count > 0 && dataSet3.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dataRow2 in dataSet3.Tables[0].Rows)
                            {
                                string str6 = str5;
                                foreach (DataColumn column2 in dataSet3.Tables[0].Columns)
                                {
                                    str6 = str6.Replace(string.Concat("#", column2.ColumnName, "#"), dataRow2[column2.ColumnName].ToString()).Trim();
                                }
                                templateFieldPropertiesFrontEnd.DefaultContent = str6;
                            }
                        }
                    }
                }
                templateFieldPropertiesFrontEnd.IsDefaultContentChanged = Convert.ToBoolean(row["IsDefaultContentChanged"]);
                templateFieldPropertiesFrontEnd.DataType = row["DataType"].ToString();
                templateFieldPropertiesFrontEnd.PhraseBookID = Convert.ToInt32(row["PhraseBookID"]);
                templateFieldPropertiesFrontEnd.PhraseType = row["PhraseType"].ToString();
                templateFieldPropertiesFrontEnd.Edit = Convert.ToBoolean(row["Edit"]);
                templateFieldPropertiesFrontEnd.ExceedHeight = row["ExceedHeight"].ToString();
                templateFieldPropertiesFrontEnd.ExceedImage = row["ExceedImage"].ToString();
                templateFieldPropertiesFrontEnd.ExceedWidth = row["ExceedWidth"].ToString();
                templateFieldPropertiesFrontEnd.FieldName = row["FieldName"].ToString();
                templateFieldPropertiesFrontEnd.Font = row["FontStyleName"].ToString();
                templateFieldPropertiesFrontEnd.FontFamily = row["FontFamily"].ToString();
                templateFieldPropertiesFrontEnd.FontExtension = row["FontExtension"].ToString();
                templateFieldPropertiesFrontEnd.ActualFontName = row["ActualFontFamilyName"].ToString();
                templateFieldPropertiesFrontEnd.FontID = Convert.ToInt32(row["FontID"].ToString());
                templateFieldPropertiesFrontEnd.LabelFontID = Convert.ToInt32(row["LabelFontID"].ToString());
                templateFieldPropertiesFrontEnd.TextAlign = row["TextAlign"].ToString();
                templateFieldPropertiesFrontEnd.FontSize = Convert.ToDouble(row["FontSize"]);
                templateFieldPropertiesFrontEnd.OriginalFontSize = Convert.ToDouble(row["FontSize"]);
                templateFieldPropertiesFrontEnd.FontStyle = row["FontStyle"].ToString();
                templateFieldPropertiesFrontEnd.ObjType = row["FieldType"].ToString();
                templateFieldPropertiesFrontEnd.FontStyleName = row["FontStyleName"].ToString();
                templateFieldPropertiesFrontEnd.FontWeight = row["FontWeight"].ToString();
                templateFieldPropertiesFrontEnd.Format = row["Format"].ToString();
                templateFieldPropertiesFrontEnd.FriendlyName = row["FriendlyName"].ToString();
                templateFieldPropertiesFrontEnd.GroupID = Convert.ToInt64(row["GroupID"].ToString());
                templateFieldPropertiesFrontEnd.Height = Convert.ToDouble(row["Height"]);
                templateFieldPropertiesFrontEnd.HelpText = row["HelpText"].ToString();
                templateFieldPropertiesFrontEnd.ImageLocation = row["ImageLocation"].ToString();
                templateFieldPropertiesFrontEnd.ImgUrl = row["ImageUrl"].ToString();
                templateFieldPropertiesFrontEnd.AllowImageEdit = Convert.ToBoolean(row["AllowImageEdit"]);
                if (templateFieldPropertiesFrontEnd.ImgUrl == "noimage.jpg" || templateFieldPropertiesFrontEnd.ImgUrl == "Images/noimage.jpg")
                {
                    templateFieldPropertiesFrontEnd.Status = "User";
                }
                else
                {
                    templateFieldPropertiesFrontEnd.Status = "Admin";
                }
                templateFieldPropertiesFrontEnd.OrignalImageName = row["OriginalImageName"].ToString();
                templateFieldPropertiesFrontEnd.ImageGallery = row["ImageGallery"].ToString();
                templateFieldPropertiesFrontEnd.ImageSource = row["ImageSource"].ToString();
                templateFieldPropertiesFrontEnd.IsFromBackEnd = Convert.ToBoolean(row["IsFromBackEnd"]);
                templateFieldPropertiesFrontEnd.Indent = Convert.ToDouble(row["Indent"]);
                templateFieldPropertiesFrontEnd.K = row["K"].ToString();
                templateFieldPropertiesFrontEnd.LabelColor = row["LabelColor"].ToString();
                templateFieldPropertiesFrontEnd.LabelPosition = row["LabelPosition"].ToString();
                templateFieldPropertiesFrontEnd.Labels = row["Labels"].ToString();
                templateFieldPropertiesFrontEnd.LabelFontSize = Convert.ToDouble(row["LabelFontSize"]);
                templateFieldPropertiesFrontEnd.LabelStyle = row["LabelStyle"].ToString();
                templateFieldPropertiesFrontEnd.LabelFontStyle = row["LabelFontStyle"].ToString();
                templateFieldPropertiesFrontEnd.Left = Convert.ToDouble(row["FieldLeft"]);
                templateFieldPropertiesFrontEnd.Lock = Convert.ToBoolean(row["Lock"]);
                templateFieldPropertiesFrontEnd.M = row["M"].ToString();
                templateFieldPropertiesFrontEnd.Mandatory = Convert.ToBoolean(row["Mandatory"]);
                string[] strArrays = row["ManualTracking"].ToString().Split(new char[] { ',' });
                if ((int)strArrays.Length != 1)
                {
                    templateFieldPropertiesFrontEnd.ManualTrackSign = strArrays[0];
                    templateFieldPropertiesFrontEnd.ManualTracking = strArrays[1];
                    templateFieldPropertiesFrontEnd.ManualTrackDimension = strArrays[2];
                }
                else
                {
                    templateFieldPropertiesFrontEnd.ManualTrackSign = "+";
                    templateFieldPropertiesFrontEnd.ManualTracking = strArrays[0];
                    templateFieldPropertiesFrontEnd.ManualTrackDimension = "pt";
                }
                TemplateFieldPropertiesFrontEnd templateFieldPropertiesFrontEnd1 = templateFieldPropertiesFrontEnd;
                string manualTrackSign = templateFieldPropertiesFrontEnd.ManualTrackSign;
                if (templateFieldPropertiesFrontEnd.ManualTrackDimension == "pt")
                {
                    num = Convert.ToDouble(templateFieldPropertiesFrontEnd.ManualTracking) * 0.75;
                    str = num.ToString();
                }
                else
                {
                    num = Convert.ToDouble(templateFieldPropertiesFrontEnd.ManualTracking) * 3.779527559;
                    str = num.ToString();
                }
                templateFieldPropertiesFrontEnd1.ManualTrackingOriginal = string.Concat(manualTrackSign, str);
                templateFieldPropertiesFrontEnd.ParaLineSpace = Convert.ToDouble(row["LineSpacing"]);
                templateFieldPropertiesFrontEnd.MaxHeight = Convert.ToDouble(row["MaxHeight"]);
                templateFieldPropertiesFrontEnd.MaxShrink = Convert.ToDouble(row["MaxShrink"]);
                templateFieldPropertiesFrontEnd.MaxWidth = Convert.ToDouble(row["MaxWidth"]);
                templateFieldPropertiesFrontEnd.ObjectID = row["ObjectID"].ToString();
                templateFieldPropertiesFrontEnd.ObjTag = row["ObjectTag"].ToString();
                templateFieldPropertiesFrontEnd.LabelValue = row["Value"].ToString();
                templateFieldPropertiesFrontEnd.OffsetHeight = row["OffsetHeight"].ToString();
                templateFieldPropertiesFrontEnd.OffsetLeft = row["OffsetLeft"].ToString();
                templateFieldPropertiesFrontEnd.OffsetTop = row["OffsetTop"].ToString();
                templateFieldPropertiesFrontEnd.OffsetWidth = row["OffsetWidth"].ToString();
                templateFieldPropertiesFrontEnd.PageNumber = Convert.ToInt32(row["PageNumber"].ToString());
                templateFieldPropertiesFrontEnd.PixelHeight = row["Height"].ToString();
                templateFieldPropertiesFrontEnd.HideVisibility = Convert.ToBoolean(row["Hide"]);
                templateFieldPropertiesFrontEnd.PixelWidth = row["PixelWidth"].ToString();
                templateFieldPropertiesFrontEnd.PositionOffset = Convert.ToDouble(row["PositionX"]);
                if (templateFieldPropertiesFrontEnd.TextAlign == "Center")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["OffsetLeft"]);
                }
                if (templateFieldPropertiesFrontEnd.TextAlign == "Right")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["OffsetLeft"]);
                }
                if (templateFieldPropertiesFrontEnd.TextAlign == "Left")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["PositionX"]);
                }
                if (templateFieldPropertiesFrontEnd.TextAlign == "Justify")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["PositionX"]);
                }
                if (templateFieldPropertiesFrontEnd.ObjType == "Image")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["PositionX"]);
                }
                if (templateFieldPropertiesFrontEnd.Labels == "Use Labels" && templateFieldPropertiesFrontEnd.GroupID == (long)0 && templateFieldPropertiesFrontEnd.CustomLeft > 0 && templateFieldPropertiesFrontEnd.TextAlign == "Left")
                {
                    templateFieldPropertiesFrontEnd.PositionX = Convert.ToDouble(row["OffsetLeft"]);
                }
                templateFieldPropertiesFrontEnd.OffsetLeft = templateFieldPropertiesFrontEnd.Left.ToString();
                templateFieldPropertiesFrontEnd.PositionY = Convert.ToDouble(row["PositionY"]);
                templateFieldPropertiesFrontEnd.OrignalPositionY = Convert.ToDouble(row["PositionY"]);
                templateFieldPropertiesFrontEnd.OrignalPositionX = Convert.ToDouble(row["PositionX"]);
                templateFieldPropertiesFrontEnd.RotateAngle = Convert.ToDouble(row["RotateAngle"]);
                templateFieldPropertiesFrontEnd.SpotColor = Convert.ToBoolean(row["SpotColor"]);
                templateFieldPropertiesFrontEnd.SpotColorRef = row["SpotColorRef"].ToString();
                templateFieldPropertiesFrontEnd.LabelFontExtension = row["LabelFontExtension"].ToString();
                templateFieldPropertiesFrontEnd.LabelActualFontName = row["LabelActualFontName"].ToString();
                templateFieldPropertiesFrontEnd.Tint = Convert.ToDouble(row["Tint"]);
                templateFieldPropertiesFrontEnd.Top = Convert.ToDouble(row["FieldTop"]);
                templateFieldPropertiesFrontEnd.Type = row["FieldType"].ToString();
                templateFieldPropertiesFrontEnd.Visibility = Convert.ToBoolean(row["Visibility"]);
                templateFieldPropertiesFrontEnd.Width = Convert.ToDouble(row["Width"]);
                templateFieldPropertiesFrontEnd.Y = row["Y"].ToString();
                templateFieldPropertiesFrontEnd.R = Convert.ToDouble(row["R"]);
                templateFieldPropertiesFrontEnd.G = Convert.ToDouble(row["G"]);
                templateFieldPropertiesFrontEnd.B = Convert.ToDouble(row["B"]);
                templateFieldPropertiesFrontEnd.A = Convert.ToDouble(row["A"]);
                templateFieldPropertiesFrontEnd.Color = "";
                templateFieldPropertiesFrontEnd.OrderNumber = Convert.ToInt32(row["ControlOrderNumber"]);
                templateFieldPropertiesFrontEnd.GroupOrientation = row["GroupOrientation"].ToString();
                if (templateFieldPropertiesFrontEnd.GroupOrientation == "Vertical" && templateFieldPropertiesFrontEnd.GroupID == (long)0)
                {
                    templateFieldPropertiesFrontEnd.PositionY = templateFieldPropertiesFrontEnd.Top;
                }
                templateFieldPropertiesFrontEnd.KeepOptions = row["KeepOptions"].ToString();
                templateFieldPropertiesFrontEnd.IsCropFromTop = Convert.ToBoolean(row["IsCropFromTop"]);
                templateFieldPropertiesFrontEnd.IsCropped = Convert.ToBoolean(row["IsCropped"]);
                templateFieldPropertiesFrontEnd.IsFromBackEnd = Convert.ToBoolean(row["IsFromBackEnd"].ToString());
                templateFieldPropertiesFrontEnd.EditedImageName = row["EditedImageName"].ToString();
                templateFieldPropertiesFrontEnd.ZIndexValue = Convert.ToInt32(row["ZIndexValue"].ToString());
                templateFieldPropertiesFrontEnd.IsImageQuality = Convert.ToBoolean(row["IsImageQuality"].ToString());
                templateFieldPropertiesFrontEnd.MinDPI = Convert.ToInt32(row["MinDPI"].ToString());
                templateFieldPropertiesFrontEnd.isDisplayonPDf = Convert.ToBoolean(row["isDisplayonPDf"]);
                templateFieldPropertiesFrontEnd.DefaultImageFrom = row["DefaultImageFrom"].ToString();
                templateFieldPropertiesFrontEnd.CustomFieldType = row["CustomFieldType"].ToString();
                templateFieldPropertiesFrontEnd.UsedImageId = Convert.ToInt32(row["UsedImageID"]);
                templateFieldPropertiesFrontEnd.IsFromPdf = Convert.ToBoolean(row["IsFromPdf"].ToString());
                templateFieldPropertiesFrontEnd.IsJobNameField = Convert.ToBoolean(row["IsJobNameField"]);
                templateFieldPropertiesFrontEnd.PhoneFormat = row["PhoneFormat"].ToString();
                templateFieldPropertiesFrontEnd.CurrencyFormat = row["CurrencyFormat"].ToString();
                templateFieldPropertiesFrontEnd.EditDropdown = Convert.ToBoolean(row["EditDropdown"]);
                if ((templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim().ToLower() == "contact" || templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim().ToLower() == "department") && templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim() != "")
                {
                    templateFieldPropertiesFrontEnd.IsFromBackEnd = true;
                }
                if (templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim().ToLower() == "contact" && templateFieldPropertiesFrontEnd.IsFromBackEnd)
                {
                    string str7 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str7 = string.Concat(str7, companyid.ToString(), "\\ContactImages\\");
                    string str8 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str8 = string.Concat(str8, "editabletemplatebackend\\", companyid, "\\images\\");
                    string str9 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str9 = string.Concat(str9, "editabletemplatebackend\\", companyid, "\\pdf\\");
                    sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyId", (object)Convert.ToInt64(companyid)), new SqlParameter("@StoreuserID", (object)Convert.ToInt64(userid)), new SqlParameter("@CartitemID", (object)Convert.ToInt64(cartitemid)), new SqlParameter("@Type", "contact") };
                    DataSet dataSet4 = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_getcontactordepartmentimage_HTML5", sqlParameter);
                    if (dataSet4.Tables.Count > 0 && dataSet4.Tables[0].Rows.Count > 0)
                    {
                        string str10 = dataSet4.Tables[0].Rows[0]["ActualFileName"].ToString();
                        bool flag = Convert.ToBoolean(dataSet4.Tables[0].Rows[0]["IsPdf"]);
                        if (File.Exists(string.Concat(str7, str10)))
                        {
                            if (File.Exists(string.Concat(str8, str10)))
                            {
                                templateFieldPropertiesFrontEnd.ImgUrl = str10;
                                templateFieldPropertiesFrontEnd.OrignalImageName = str10;
                                templateFieldPropertiesFrontEnd.IsFromPdf = flag;
                            }
                            else
                            {
                                File.Copy(string.Concat(str7, str10), string.Concat(str8, str10));
                                templateFieldPropertiesFrontEnd.ImgUrl = str10;
                                templateFieldPropertiesFrontEnd.OrignalImageName = str10;
                                templateFieldPropertiesFrontEnd.IsFromPdf = flag;
                                if (flag)
                                {
                                    File.Copy(string.Concat(str7, str10.Replace(".png", ".pdf")), string.Concat(str9, str10.Replace(".png", ".pdf")));
                                }
                            }
                        }
                    }
                }
                else if (templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim().ToLower() == "department" && templateFieldPropertiesFrontEnd.IsFromBackEnd)
                {
                    string str11 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str11 = string.Concat(str11, companyid.ToString(), "\\DepartmentImages\\");
                    string str12 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str12 = string.Concat(str12, "editabletemplatebackend\\", companyid, "\\images\\");
                    string str13 = sitePaths.FrontEndUploadPath.Replace("editabletemplatefrontend", "").Replace("TemplateEditorForntEnd", "");
                    str13 = string.Concat(str13, "editabletemplatebackend\\", companyid, "\\pdf\\");
                    sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyId", (object)Convert.ToInt64(companyid)), new SqlParameter("@StoreuserID", (object)Convert.ToInt64(userid)), new SqlParameter("@CartitemID", (object)Convert.ToInt64(cartitemid)), new SqlParameter("@Type", "department") };
                    DataSet dataSet5 = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_getcontactordepartmentimage_HTML5", sqlParameter);
                    if (dataSet5.Tables.Count > 0 && dataSet5.Tables[0].Rows.Count > 0)
                    {
                        string str14 = dataSet5.Tables[0].Rows[0]["ActualFileName"].ToString();
                        bool flag1 = Convert.ToBoolean(dataSet5.Tables[0].Rows[0]["IsPdf"]);
                        if (File.Exists(string.Concat(str11, str14)))
                        {
                            if (File.Exists(string.Concat(str12, str14)))
                            {
                                templateFieldPropertiesFrontEnd.ImgUrl = str14;
                                templateFieldPropertiesFrontEnd.OrignalImageName = str14;
                                templateFieldPropertiesFrontEnd.IsFromPdf = flag1;
                            }
                            else
                            {
                                File.Copy(string.Concat(str11, str14), string.Concat(str12, str14));
                                templateFieldPropertiesFrontEnd.ImgUrl = str14;
                                templateFieldPropertiesFrontEnd.OrignalImageName = str14;
                                templateFieldPropertiesFrontEnd.IsFromPdf = flag1;
                                if (flag1)
                                {
                                    File.Copy(string.Concat(str11, str14.Replace(".png", ".pdf")), string.Concat(str13, str14.Replace(".png", ".pdf")));
                                }
                            }
                        }
                    }
                }
                else if (templateFieldPropertiesFrontEnd.DefaultImageFrom.Trim().ToLower() == "frompdf")
                {
                    templateFieldPropertiesFrontEnd.IsFromPdf = Convert.ToBoolean(row["isFromPdf"]);
                }
                templateFieldPropertiesFrontEnds.Add(templateFieldPropertiesFrontEnd);
            }
        }
        return templateFieldPropertiesFrontEnds;
    }

    public TemplateDetails LoadTemplateDetails(string templateid, string _key)
    {
        TemplateDetails templateDetail = new TemplateDetails();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@templateid", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetPDFImageFile", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                templateDetail.AddNewImage = Convert.ToBoolean(row["AddNewImage"]);
                templateDetail.AddNewParagraph = Convert.ToBoolean(row["AddNewParagraph"]);
                templateDetail.AddNewTextBlock = Convert.ToBoolean(row["AddNewTextBlock"]);
                TemplateDetails templateDetail1 = templateDetail;
                bool? item = (bool?)(row["ShowEditor"] as bool?);
                templateDetail1.ShowEdiotr = (item.HasValue ? item.GetValueOrDefault() : false);
                templateDetail.CropMarkHeight = Convert.ToDouble(row["CropMarkHeight"]);
                templateDetail.CropMarkWidth = Convert.ToDouble(row["CropMarkWidth"]);
                templateDetail.ImageName = row["ImageName"].ToString();
                templateDetail.IsAllowPDFPreviews = Convert.ToBoolean(row["IsAllowPDFPreviews"]);
                templateDetail.isPDFPreviewMandatory = Convert.ToBoolean(row["IsPDFPreviewMandatory"]);
                templateDetail.PageHeight = Convert.ToDouble(row["PageHeight"]);
                templateDetail.PageWidth = Convert.ToDouble(row["PageWidth"]);
                templateDetail.PDFName = row["PDFName"].ToString();
                templateDetail.ZoomX = Convert.ToDouble(row["ZoomX"]);
                templateDetail.ZoomY = Convert.ToDouble(row["ZoomY"]);
                templateDetail.Totalpage = (double)Convert.ToInt64(row["TotalPageNumber"].ToString());
                templateDetail.ZoomPercent = Convert.ToDouble(row["ZoomPercentage"]);
                TemplateDetails templateDetail2 = templateDetail;
                bool? nullable = (bool?)(row["ShowEditablePages"] as bool?);
                templateDetail2.ShowEditablePages = (nullable.HasValue ? nullable.GetValueOrDefault() : false);
                TemplateDetails templateDetail3 = templateDetail;
                bool? item1 = (bool?)(row["SendAttachment"] as bool?);
                templateDetail3.SendAttachment = (item1.HasValue ? item1.GetValueOrDefault() : false);
                templateDetail.CropedImageName = row["CropedImageName"].ToString();
                templateDetail.CropedPDFName = row["CropedPDFName"].ToString();
                templateDetail.IsGroupConsiderLabel = false;
                try
                {
                    templateDetail.PreviewType = row["PreviewType"].ToString();
                }
                catch
                {
                }
            }
        }
        return templateDetail;
    }

    public string LoadUserAccountDetails(int CompanyID, int AccountID, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        string empty = string.Empty;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(CompanyID)), new SqlParameter("@AccountID", (object)AccountID) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "Ws_Select_AccountDetails", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["DateFormat"].ToString();
            }
        }
        return empty;
    }

    public bool UpdateAddCartStatus(long CartItemId, string PDFname, string _key)
    {
        string domainKey = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = domainKey
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            Connection = sqlConnection,
            CommandText = "et_UpdateCartStatus"
        };
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = CartItemId;
        sqlCommand.Parameters.Add("@PDFNameFromCart", SqlDbType.NVarChar);
        sqlCommand.Parameters["@PDFNameFromCart"].Value = PDFname;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return true;
    }

    public bool UpdateDesignName(long CartItemId, string designname, string _key)
    {
        string domainKey = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = domainKey
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            Connection = sqlConnection,
            CommandText = "et_UpdateDesignName"
        };
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = CartItemId;
        sqlCommand.Parameters.Add("@DesignName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@DesignName"].Value = designname;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return true;
    }

    public long UpdateImageCategory(string companyid, string categoryid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@CategoryName", categoryname), new SqlParameter("@Description", description), new SqlParameter("@ParentID", (object)Convert.ToInt64(parentid)), new SqlParameter("@CategoryImage", categoryimage), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(createdby)), new SqlParameter("@UserType", "admin"), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UpdateImageCategory", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public void UpdateImageDetails(string imageid, string companyid, string categoryid, string filename, string description, string metatags, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@OriginalFileName", filename), new SqlParameter("@Description", description), new SqlParameter("@MetaTags", metatags) };
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GalleryImages_Update", sqlParameter);
    }

    public void UpdatePDFDetails(string CompanyID, string ImageID, string OriginalFileName, string FileName, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_UpdateIsPDFtoImageConverted",
            Connection = sqlConnection
        };
        sqlCommand.Parameters.Add("@CompanyID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CompanyID"].Value = CompanyID;
        sqlCommand.Parameters.Add("@ImageID", SqlDbType.BigInt);
        sqlCommand.Parameters["@ImageID"].Value = ImageID;
        sqlCommand.Parameters.Add("@OriginalFileName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@OriginalFileName"].Value = OriginalFileName;
        sqlCommand.Parameters.Add("@FileName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@FileName"].Value = FileName;
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
    }

    public bool UpdatePreviewStatus(long CartItemId, string PDFname, string _key)
    {
        string domainKey = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = domainKey
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            Connection = sqlConnection,
            CommandText = "et_UpdatePreviewStatus"
        };
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = CartItemId;
        sqlCommand.Parameters.Add("@PDFName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@PDFName"].Value = PDFname;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return true;
    }

    public bool UpdateSaveStatus(long CartItemId, string PreviewType, string _key)
    {
        string domainKey = this.GetDomainKey(_key);
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = domainKey
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            Connection = sqlConnection,
            CommandText = "et_UpdateSaveStatus"
        };
        sqlCommand.Parameters.Add("@CartItemID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CartItemID"].Value = CartItemId;
        sqlCommand.Parameters.Add("@PreviewType", SqlDbType.NVarChar);
        sqlCommand.Parameters["@PreviewType"].Value = PreviewType;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return true;
    }

    public void UploadImageDetails(long imageid, long companyid, string orgfilename, string filename, string filesize, long userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@OriginalFileName", orgfilename), new SqlParameter("@FileName", filename), new SqlParameter("@FileSize", filesize) };
        TemplateEditorFrontEnd.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Gallery_UpdateImage", sqlParameter);
    }

    public List<VerticalGroupDetails> VerticalGroupDetails(string Companyid, string templateid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(Companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditorFrontEnd.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Select_VerticalGroup_Details", sqlParameter);
        List<VerticalGroupDetails> verticalGroupDetails = new List<VerticalGroupDetails>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                VerticalGroupDetails verticalGroupDetail = new VerticalGroupDetails()
                {
                    GID = Convert.ToInt64(row["GID"].ToString()),
                    TemplateID = Convert.ToInt64(row["TEMPLATEID"].ToString()),
                    CompanyID = Convert.ToInt64(row["COMPANYID"].ToString()),
                    GroupName = row["GROUPNAME"].ToString(),
                    GrpKeepOption = row["KeepOptions"].ToString(),
                    Alignment = row["Alignment"].ToString(),
                    ControlSpace = Convert.ToDouble(row["ControlSpacing"].ToString()),
                    PositionX = Convert.ToDouble(row["PositionX"].ToString()),
                    PositionY = Convert.ToDouble(row["PositionY"].ToString()),
                    CurrentPositionX = Convert.ToDouble(row["PositionX"].ToString()),
                    CurrentPositionY = Convert.ToDouble(row["PositionY"].ToString()),
                    PageNumber = Convert.ToInt64(row["PageNumber"].ToString()),
                    GroupOption = row["GroupOption"].ToString(),
                    IsParaGroup = Convert.ToBoolean(row["IsParaGroup"].ToString()),
                    IsConsiderLabel = Convert.ToBoolean(row["isConsiderLabel"].ToString()),

                    GroupMoveRelative = Convert.ToBoolean(row["GroupMoveRelative"].ToString()),

                    GroupMovementValue = Convert.ToDecimal(row["GroupMovementValue"].ToString())
                };
                verticalGroupDetails.Add(verticalGroupDetail);
            }
        }
        return verticalGroupDetails;
    }

}
