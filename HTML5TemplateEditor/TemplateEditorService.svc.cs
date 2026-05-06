using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TemplateEditor;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
public class TemplateEditorService : ITemplateEditorService
{
    public static string HostName;

    private string Templateconnectionstring = "";

    static TemplateEditorService()
    {
        TemplateEditorService.HostName = string.Empty;
    }

    public TemplateEditorService()
    {
    }

    public int checkmaxupload(string ControlDetail, string templateID, string userid, string companyid, string _key)
    {
        return JsonConvert.DeserializeObject<List<TemplateFieldProperties>>(ControlDetail).Count;
    }

    public long CopyTemplateWithProperties(string copiedtemplateid, string currenttemplateid, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@templateid", (object)Convert.ToInt64(copiedtemplateid)), new SqlParameter("@CurrentTemplateID", (object)Convert.ToInt64(currenttemplateid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Copy_Template", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public string CreateProportionalImage(long companyid, long templateid, long userid, string originalFilename, string path, double canvasWidth, double canvasHeight, double originalWidth, double originalHeight, double _zoompercnt, string _key)
    {
        this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        string empty = string.Empty;
        char[] chrArray = new char[] { ',' };
        if ((int)originalFilename.Split(chrArray).Length == 1)
        {
            int num = Convert.ToInt32(canvasWidth);
            int num1 = Convert.ToInt32(canvasHeight);
            try
            {
                path = string.Concat(eprintConfigurationManager.AppSettings["USERPDFIMAGEPATH"].ToString(), companyid, "\\Images\\");
                Image image = Image.FromFile(string.Concat(path, originalFilename));
                empty = createThumbnail.CreateProportionalImage(image, path, originalFilename, "", num, num1, originalWidth, originalHeight, true, _zoompercnt, false);
                image.Dispose();
                GC.Collect();
            }
            catch (Exception exception)
            {
                exception.Message.ToString();
            }
        }
        return empty;
    }

    public long DeleteGalleryImages(string imageid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GalleryImages_Delete", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public List<HorzontalGroupDetails> DeleteHorizontalGroup(string templateid, string grpid, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<HorzontalGroupDetails> horzontalGroupDetails = new List<HorzontalGroupDetails>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@GroupID", (object)Convert.ToInt64(grpid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_DeleteAndReBind_Horizontal_Group", sqlParameter);
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
                    PageNumber = Convert.ToInt64(row["PageNumber"].ToString()),
                    GroupOption = row["GroupOption"].ToString()
                };
                horzontalGroupDetails.Add(horzontalGroupDetail);
            }
        }
        return horzontalGroupDetails;
    }

    public long DeleteImageCategory(string categoryid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ImageCategory_Delete", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public string DeleteMultipleFilesFolders(string categoryids, string imageids, string userid, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        string empty = string.Empty;
        if (categoryids != "")
        {
            string[] strArrays = categoryids.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CategoryID", (object)Convert.ToInt64(strArrays[i].ToString())), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray = sqlParameter;
                TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_MultipleImageCategory_Delete", sqlParameterArray);
                empty = string.Concat(empty, Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString()), ",");
            }
        }
        if (imageids != "")
        {
            string[] strArrays1 = imageids.Split(new char[] { ',' });
            for (int j = 0; j < (int)strArrays1.Length - 1; j++)
            {
                SqlParameter[] sqlParameter1 = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(strArrays1[j].ToString())), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray1 = sqlParameter1;
                TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_MultipleImageFiles_Delete", sqlParameterArray1);
                empty = string.Concat(empty, Convert.ToInt64(sqlParameterArray1[(int)sqlParameterArray1.Length - 1].Value.ToString()), ",");
            }
        }
        return empty;
    }

    public List<VerticalGroupDetails> DeleteVerticalGroup(string templateid, string grpid, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<VerticalGroupDetails> verticalGroupDetails = new List<VerticalGroupDetails>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@GroupID", (object)Convert.ToInt64(grpid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_DeleteAndReBind_Vertical_Group", sqlParameter);
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
                    PageNumber = Convert.ToInt64(row["PageNumber"].ToString()),
                    GroupOption = row["GroupOption"].ToString(),
                    IsParaGroup = Convert.ToBoolean(row["IsParaGroup"].ToString()),
                    IsConsiderLabel = Convert.ToBoolean(row["isConsiderLabel"].ToString())
                };
                verticalGroupDetails.Add(verticalGroupDetail);
            }
        }
        return verticalGroupDetails;
    }

    public List<ColorStyle> GetColorStyleDetailProperties(string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
        List<ColorStyle> colorStyles = new List<ColorStyle>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetColorStyleDetails", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            DataView defaultView = dataSet.Tables[0].DefaultView;
            defaultView.Sort = "ColorStyle ASC";
            DataTable dataTable = new DataTable();
            foreach (DataRow row in defaultView.ToTable().Rows)
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
        }
        return colorStyles;
    }

    public ColorStyle GetColorStyleDetails(string colorstyle, long _colorid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        ColorStyle colorStyle = new ColorStyle();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ColorStyle", colorstyle), new SqlParameter("@ColorID", (object)_colorid) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetColorStyle", sqlParameter);
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            colorStyle.C = row["C"].ToString();
            colorStyle.M = row["M"].ToString();
            colorStyle.Y = row["Y"].ToString();
            colorStyle.K = row["K"].ToString();
            colorStyle.R = Convert.ToDouble(row["R"]);
            colorStyle.G = Convert.ToDouble(row["G"]);
            colorStyle.B = Convert.ToDouble(row["B"]);
            colorStyle.A = Convert.ToDouble(row["A"]);
            colorStyle.ColorID = Convert.ToInt64(row["ColorID"].ToString());
            colorStyle.ColorStyleName = row["ColorStyle"].ToString();
            colorStyle.CompanyID = Convert.ToInt64(row["CompanyID"].ToString());
            colorStyle.SpotColor = Convert.ToBoolean(row["SpotColor"]);
            colorStyle.SpotColorRef = row["SpotColorRef"].ToString();
            colorStyle.TemplateID = Convert.ToInt64(row["TemplateID"].ToString());
            colorStyle.Tint = Convert.ToDouble(row["Tint"]);
            colorStyle.UserID = Convert.ToInt64(row["UserID"].ToString());
        }
        return colorStyle;
    }

    public List<QueryStringPara> GetDecriptedQuerySting(string _quertstr)
    {
        List<QueryStringPara> queryStringParas = new List<QueryStringPara>();
        string str = Encrypt.Decrypt(_quertstr);
        string[] strArrays = str.Split(new char[] { '&' });
        if ((int)strArrays.Length > 0)
        {
            QueryStringPara queryStringPara = new QueryStringPara();
            string[] strArrays1 = strArrays[0].Split(new char[] { '=' });
            queryStringPara.TemplateID = Convert.ToInt64(strArrays1[1]);
            string[] strArrays2 = strArrays[1].Split(new char[] { '=' });
            queryStringPara.PriceCatalogId = Convert.ToInt64(strArrays2[1]);
            string[] strArrays3 = strArrays[2].Split(new char[] { '=' });
            queryStringPara.CompanyID = Convert.ToInt64(strArrays3[1]);
            string[] strArrays4 = strArrays[3].Split(new char[] { '=' });
            queryStringPara.UserID = Convert.ToInt64(strArrays4[1]);
            string str1 = strArrays[4];
            char[] chrArray = new char[] { '=' };
            queryStringPara.dbKey = str1.Split(chrArray)[1];
            queryStringParas.Add(queryStringPara);
        }
        return queryStringParas;
    }

    public string GetDomainKey(string _EprintConnectKey)
    {
        DataTable dataTable = new DataTable();
        string str = "";
        string str1 = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@EprintConnectKey", _EprintConnectKey) };
        dataTable = TemplateEditor.SQL.ExecuteDataset(str1, CommandType.StoredProcedure, "et_GetDomainName", sqlParameter).Tables[0];
        if (dataTable.Rows.Count <= 0)
        {
            str = "";
            TemplateEditorService.HostName = "";
            this.Templateconnectionstring = "";
        }
        else
        {
            str = dataTable.Rows[0][0].ToString();
            TemplateEditorService.HostName = str;
        }
        return (new EprintConfigurationManager()).ConnectionStrings["TEMPLATECONNECTION"].ToString();
    }

    public bool GetFinalValue(double _parac, double _parau, string _parakey)
    {
        bool flag = false;
        try
        {
            string str = Encrypt.Decrypt(_parakey);
            string[] strArrays = str.Split(new char[] { '~' });
            DataTable dataTable = new DataTable();
            if ((int)strArrays.Length > 0)
            {
                EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
                this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
                SqlConnection sqlConnection = new SqlConnection()
                {
                    ConnectionString = this.Templateconnectionstring
                };
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = sqlConnection,
                    CommandText = "et_Check_Secured_Details",
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@UserID", SqlDbType.NVarChar);
                sqlCommand.Parameters["@UserID"].Value = strArrays[1];
                sqlCommand.Parameters.Add("@CompanyID", SqlDbType.NVarChar);
                sqlCommand.Parameters["@CompanyID"].Value = strArrays[0];
                sqlCommand.Parameters.Add("@returnID", SqlDbType.Bit);
                sqlCommand.Parameters["@returnID"].Value = false;
                sqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.Bit);
                sqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                flag = Convert.ToBoolean(sqlCommand.Parameters["@RETURN_VALUE"].Value);
                sqlConnection.Close();
                if (!flag)
                {
                    flag = false;
                }
            }
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    public List<TemplateEditor.Font> GetFontStyle(string FontStyle, string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@FontStyle", FontStyle) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetFontStyle", sqlParameter);
        List<TemplateEditor.Font> fonts = new List<TemplateEditor.Font>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            DataView defaultView = dataSet.Tables[0].DefaultView;
            defaultView.Sort = "FontStyle ASC";
            DataTable dataTable = new DataTable();
            foreach (DataRow row in defaultView.ToTable().Rows)
            {
                TemplateEditor.Font font = new TemplateEditor.Font()
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

    public List<CategoryList> GetImageCategoryByCompany(string companyid, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(userid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetImageCategory", sqlParameter);
        List<CategoryList> categoryLists = new List<CategoryList>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                CategoryList categoryList = new CategoryList()
                {
                    CategoryID = Convert.ToInt64(row["CategoryID"]),
                    MultiLevelCategory = row["MultiLevelCategory"].ToString()
                };
                categoryLists.Add(categoryList);
            }
        }
        return categoryLists;
    }

    public List<ImageCategory> GetImageGalleryAssignment(string companyid, string templateid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_SelectImageGalleryAssignment", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ImageCategory imageCategory = new ImageCategory()
                {
                    AssignmentID = Convert.ToInt64(row["AssignmentID"]),
                    ObjectID = row["ObjectID"].ToString(),
                    CompanyID = Convert.ToInt64(row["CompanyID"]),
                    TemplateID = Convert.ToInt64(row["TemplateID"]),
                    UserID = Convert.ToInt64(row["UserID"]),
                    Type = row["Type"].ToString().Trim(),
                    TypeID = Convert.ToInt64(row["TypeID"]),
                    IsDefault = Convert.ToBoolean(row["IsDefault"])
                };
                imageCategories.Add(imageCategory);
            }
        }
        return imageCategories;
    }

    public ImageGalleryParentResponse GetImageGallerySearch(string companyid, string categoryid, string userid, string searchtext, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@SearchText", searchtext) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ImageGallerySearchResult_Select", sqlParameter);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        List<ImageCategory> imageCategories1 = new List<ImageCategory>();
        long num = Convert.ToInt64(categoryid);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                imageCategories.Add(new ImageCategory(Convert.ToInt64(row["ImageID"]), Convert.ToInt64(row["CompanyID"]), Convert.ToInt64(row["CategoryID"]), Convert.ToInt64(row["UserID"]), row["UserType"].ToString(), row["OriginalFileName"].ToString(), row["FileName"].ToString(), Convert.ToInt64(row["FileSize"]), row["Description"].ToString(), row["MetaTags"].ToString(), Convert.ToBoolean(row["IsPdf"].ToString())));
            }
        }
        ImageGalleryParentResponse imageGalleryParentResponse = new ImageGalleryParentResponse()
        {
            ImageCategories = imageCategories1,
            ImageGallery = imageCategories,
            ParentID = num
        };
        return imageGalleryParentResponse;
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
        }
        return global;
    }

    public string GetProductName(string priceCatalogueID, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@PriceCatalogueID", priceCatalogueID) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_SelectProductName", sqlParameter);
        string str = "";
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            str = string.Concat(dataSet.Tables[0].Rows[0]["CatalogueName"].ToString().Replace("%27", "'").Replace("%22", "\""), " ", dataSet.Tables[0].Rows[0]["ItemCode"].ToString());
        }
        return str;
    }

    public ImageGalleryParentResponse GetSystemGalleryFoldersandFiles(string companyid, string categoryid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetImageGalleryCategories", sqlParameter);
        long num = (long)-1;
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        List<ImageCategory> imageCategories1 = new List<ImageCategory>();
        if (dataSet.Tables.Count > 0)
        {
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    imageCategories.Add(new ImageCategory(Convert.ToInt64(row["CategoryID"]), Convert.ToInt64(row["CompanyID"]), row["CategoryName"].ToString(), row["Description"].ToString(), Convert.ToInt64(row["ParentID"]), row["CategoryImage"].ToString(), Convert.ToInt64(row["CreatedBy"])));
                }
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                {
                    imageCategories1.Add(new ImageCategory(Convert.ToInt64(dataRow["ImageID"]), Convert.ToInt64(dataRow["CompanyID"]), Convert.ToInt64(dataRow["CategoryID"]), Convert.ToInt64(dataRow["UserID"]), dataRow["UserType"].ToString(), dataRow["OriginalFileName"].ToString(), dataRow["FileName"].ToString(), Convert.ToInt64(dataRow["FileSize"]), dataRow["Description"].ToString(), dataRow["MetaTags"].ToString(), Convert.ToBoolean(dataRow["IsPdf"].ToString())));
                }
            }
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow row1 in dataSet.Tables[2].Rows)
                {
                    num = Convert.ToInt64(dataSet.Tables[2].Rows[0]["ParentID"].ToString());
                }
            }
        }
        ImageGalleryParentResponse imageGalleryParentResponse = new ImageGalleryParentResponse()
        {
            ImageCategories = imageCategories,
            ImageGallery = imageCategories1,
            ParentID = num
        };
        return imageGalleryParentResponse;
    }

    public string GetValueOnPageLoaded(double _parac, double _parau, string _parakey)
    {
        string str = Encrypt.Encryption(string.Concat(_parac.ToString(), "~", _parau.ToString()));
        return str;
    }

    public List<HorzontalGroupDetails> HorizontalGroupDetails(string Companyid, string templateid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(Companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Select_HorizontalGroup_Details", sqlParameter);
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

    public void ImageGalleryAssignment_Delete(string compnayid, string templateid, string objectid, string type, string typeid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ObjectID", objectid), new SqlParameter("@CompanyID", (object)Convert.ToInt64(compnayid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@Type", type.Trim()), new SqlParameter("@TypeID", (object)Convert.ToInt32(typeid)) };
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_DeleteImageGalleryAssignment", sqlParameter);
    }

    public List<ImageCategory> ImageListAfterUpload(string ImageIDList, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<ImageCategory> imageCategories = new List<ImageCategory>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", ImageIDList.Substring(0, ImageIDList.Length - 1)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GetImageGalleryafterUpload", sqlParameter);
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
                    MetaTags = row["MetaTags"].ToString(),
                    IsPdf = Convert.ToBoolean(row["IsPdf"].ToString())
                };
                imageCategories.Add(imageCategory);
            }
        }
        return imageCategories;
    }

    public void Insert_ImageGalleryAssignment(string objectid, string companyid, string templateid, string userid, string types, string typeids, string defaultid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        (new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        }).Open();
        string[] strArrays = types.Split(new char[] { ',' });
        string[] strArrays1 = typeids.Split(new char[] { ',' });
        for (int i = 0; i < (int)strArrays.Length; i++)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ObjectID", objectid), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@Type", strArrays[i].ToString().Trim()), new SqlParameter("@TypeID", (object)Convert.ToInt32(strArrays1[i].ToString())), null };
            sqlParameter[6] = new SqlParameter("@IsDefault", (object)((Convert.ToInt32(defaultid) == Convert.ToInt32(strArrays1[i].ToString()) ? true : false)));
            TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ImageGalleryAssignment_Insert", sqlParameter);
        }
    }

    public void Insert_ImageGalleryAssignment_Onclick(string objectid, string companyid, string templateid, string userid, string type, string typeid, string isdefault, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ObjectID", objectid), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@Type", type.Trim()), new SqlParameter("@TypeID", (object)Convert.ToInt32(typeid)), null };
        sqlParameter[6] = new SqlParameter("@IsDefault", (object)((isdefault == "true" ? true : false)));
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ImageGalleryAssignment_Insert", sqlParameter);
    }

    public string insertGroup(string orentation, string groupname, string templateid, string companyid, string groupid, string keepoption, string controlspace, string positionx, string positiony, string align, string pagenumber, string grpOption, string IsParaGroup, string IsConsiderLabel, Boolean GroupMoveRelative, decimal GroupMovementValue, string _key)
    {
        string str = "";
        this.Templateconnectionstring = this.GetDomainKey(_key);
        if (orentation == "Vertical")
        {
            long num = this.InsertVerticalGroupDetail(groupname, Convert.ToInt64(templateid), Convert.ToInt64(companyid), Convert.ToInt64(groupid), keepoption, Convert.ToDouble(controlspace), Convert.ToDouble(positionx), Convert.ToDouble(positiony), align, Convert.ToInt64(pagenumber), grpOption, IsParaGroup, IsConsiderLabel, GroupMoveRelative, GroupMovementValue, _key);
            str = num.ToString();
        }
        else if (orentation == "Horizontal")
        {
            long num1 = this.InsertHorizontalGroupDetail(groupname, Convert.ToInt64(templateid), Convert.ToInt64(companyid), Convert.ToInt64(groupid), keepoption, Convert.ToDouble(controlspace), Convert.ToDouble(positionx), Convert.ToDouble(positiony), align, Convert.ToInt64(pagenumber), grpOption, GroupMoveRelative, GroupMovementValue, _key);
            str = num1.ToString();
        }
        return str;
    }

    public long InsertHorizontalGroupDetail(string groupname, long templateid, long companyid, long groupid, string keepoption, double controlspace, double positionx, double positiony, string align, long pagenumber, string grpOption, Boolean GroupMoveRelative,decimal GroupMovementValue, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_InsertHorizontalGroup",
            Connection = sqlConnection
        };
        sqlCommand.Parameters.Add("@GroupName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GroupName"].Value = groupname;
        sqlCommand.Parameters.Add("@TemplateID", SqlDbType.BigInt);
        sqlCommand.Parameters["@TemplateID"].Value = templateid;
        sqlCommand.Parameters.Add("@CompanyID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CompanyID"].Value = companyid;
        sqlCommand.Parameters.Add("@KeepOptions", SqlDbType.NVarChar);
        sqlCommand.Parameters["@KeepOptions"].Value = keepoption;
        sqlCommand.Parameters.Add("@GID", SqlDbType.BigInt);
        sqlCommand.Parameters["@GID"].Value = groupid;
        sqlCommand.Parameters.Add("@ControlSpace", SqlDbType.Decimal);
        sqlCommand.Parameters["@ControlSpace"].Value = controlspace;
        sqlCommand.Parameters.Add("@PositionX", SqlDbType.Decimal);
        sqlCommand.Parameters["@PositionX"].Value = positionx;
        sqlCommand.Parameters.Add("@PositionY", SqlDbType.Decimal);
        sqlCommand.Parameters["@PositionY"].Value = positiony;
        sqlCommand.Parameters.Add("@Alignment", SqlDbType.NVarChar);
        sqlCommand.Parameters["@Alignment"].Value = align;
        sqlCommand.Parameters.Add("@PageNumber", SqlDbType.BigInt);
        sqlCommand.Parameters["@PageNumber"].Value = pagenumber;
        sqlCommand.Parameters.Add("@GroupOption", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GroupOption"].Value = grpOption;
        sqlCommand.Parameters.Add("@GroupMoveRelative", SqlDbType.Bit);
        sqlCommand.Parameters["@GroupMoveRelative"].Value = GroupMoveRelative;
        sqlCommand.Parameters.Add("@GroupMovementValue", SqlDbType.Decimal);
        sqlCommand.Parameters["@GroupMovementValue"].Value = GroupMovementValue;
        sqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.BigInt);
        sqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        groupid = Convert.ToInt64(sqlCommand.Parameters["@RETURN_VALUE"].Value.ToString());
        sqlConnection.Close();
        return groupid;
    }

    public long InsertImageCategory(string companyid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryName", categoryname), new SqlParameter("@Description", description), new SqlParameter("@ParentID", (object)Convert.ToInt64(parentid)), new SqlParameter("@CategoryImage", categoryimage), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(createdby)), new SqlParameter("@UserType", "admin"), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_InsertImageCategory", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public string InsertImageGallery(string companyid, string templateid, string categoryid, string userid, string usertype, string fileList, string description, string metatags, string _key)
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
                char[] chrArray = new char[] { '.' };
                string str2 = str1.Split(chrArray)[0];
                string empty = string.Empty;
                empty = (strArrays1[0] == "" ? strArrays1[1] : string.Concat(strArrays1[0], "_", strArrays1[1]));
                string str3 = strArrays1[2];
                string[] strArrays2 = strArrays1[1].Split(new char[] { '.' });
                flag = (!strArrays2[(int)strArrays2.Length - 1].ToString().ToLower().Contains("pdf") ? false : true);
                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@UserType", usertype), new SqlParameter("@OriginalFileName", str2), new SqlParameter("@FileName", empty), new SqlParameter("@FileSize", (object)Convert.ToInt64(str3)), new SqlParameter("@Description", description), new SqlParameter("@MetaTags", metatags), new SqlParameter("@IsPDF", (object)flag), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray = sqlParameter;
                TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_InsertImageGallery", sqlParameterArray);
                str = string.Concat(str, sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString(), ",");
            }
        }
        return str;
    }

    public long InsertVerticalGroupDetail(string groupname, long templateid, long companyid, long groupid, string keepoption, double controlspace, double positionx, double positiony, string align, long pagenumber, string grpOption, string IsParaGroup, string IsConsiderLabel, Boolean GroupMoveRelative,decimal GroupMovementValue, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        EprintConfigurationManager eprintConfigurationManager = new EprintConfigurationManager();
        this.Templateconnectionstring = eprintConfigurationManager.ConnectionStrings["TEMPLATECONNECTION"].ToString();
        SqlConnection sqlConnection = new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        };
        SqlCommand sqlCommand = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "et_InsertVerticalGroup",
            Connection = sqlConnection
        };
        sqlCommand.Parameters.Add("@GroupName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GroupName"].Value = groupname;
        sqlCommand.Parameters.Add("@TemplateID", SqlDbType.BigInt);
        sqlCommand.Parameters["@TemplateID"].Value = templateid;
        sqlCommand.Parameters.Add("@CompanyID", SqlDbType.BigInt);
        sqlCommand.Parameters["@CompanyID"].Value = companyid;
        sqlCommand.Parameters.Add("@KeepOptions", SqlDbType.NVarChar);
        sqlCommand.Parameters["@KeepOptions"].Value = keepoption;
        sqlCommand.Parameters.Add("@GID", SqlDbType.BigInt);
        sqlCommand.Parameters["@GID"].Value = groupid;
        sqlCommand.Parameters.Add("@ControlSpace", SqlDbType.Decimal);
        sqlCommand.Parameters["@ControlSpace"].Value = controlspace;
        sqlCommand.Parameters.Add("@PositionX", SqlDbType.Decimal);
        sqlCommand.Parameters["@PositionX"].Value = positionx;
        sqlCommand.Parameters.Add("@PositionY", SqlDbType.Decimal);
        sqlCommand.Parameters["@PositionY"].Value = positiony;
        sqlCommand.Parameters.Add("@Alignment", SqlDbType.NVarChar);
        sqlCommand.Parameters["@Alignment"].Value = align;
        sqlCommand.Parameters.Add("@PageNumber", SqlDbType.BigInt);
        sqlCommand.Parameters["@PageNumber"].Value = pagenumber;
        sqlCommand.Parameters.Add("@GroupOption", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GroupOption"].Value = grpOption;
        sqlCommand.Parameters.Add("@IsParaGroup", SqlDbType.Bit);
        sqlCommand.Parameters["@IsParaGroup"].Value = IsParaGroup;
        sqlCommand.Parameters.Add("@IsConsiderLabel", SqlDbType.Bit);
        sqlCommand.Parameters["@IsConsiderLabel"].Value = IsConsiderLabel;
        sqlCommand.Parameters.Add("@GroupMoveRelative", SqlDbType.Bit);
        sqlCommand.Parameters["@GroupMoveRelative"].Value = GroupMoveRelative;
        sqlCommand.Parameters.Add("@GroupMovementValue", SqlDbType.Decimal);
        sqlCommand.Parameters["@GroupMovementValue"].Value = GroupMovementValue;
        sqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.BigInt);
        sqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        groupid = Convert.ToInt64(sqlCommand.Parameters["@RETURN_VALUE"].Value.ToString());
        sqlConnection.Close();
        return groupid;
    }
    

    public string IsDeleteMultipleFilesFoldersAssigned(string categoryids, string imageids, string templateid, string companyid, string objectid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        string empty = string.Empty;
        if (categoryids != "")
        {
            string[] strArrays = categoryids.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CategoryID", (object)Convert.ToInt64(strArrays[i].ToString())), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray = sqlParameter;
                TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Multiple_ImageCategory_IsAssigned", sqlParameterArray);
                empty = string.Concat(empty, Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString()), ",");
            }
        }
        if (imageids != "")
        {
            string[] strArrays1 = imageids.Split(new char[] { ',' });
            for (int j = 0; j < (int)strArrays1.Length - 1; j++)
            {
                SqlParameter[] sqlParameter1 = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(strArrays1[j].ToString())), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@ObjectID", objectid), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
                SqlParameter[] sqlParameterArray1 = sqlParameter1;
                TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Multiple_ImageFiles_ISAssigned", sqlParameterArray1);
                empty = string.Concat(empty, Convert.ToInt64(sqlParameterArray1[(int)sqlParameterArray1.Length - 1].Value.ToString()), ",");
            }
        }
        return empty;
    }

    public List<DatabaseContent> LoadDataBaseContents(string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<DatabaseContent> databaseContents = new List<DatabaseContent>();
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultContents");
        List<string> strs = new List<string>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DatabaseContent databaseContent = new DatabaseContent()
                {
                    Tag = row[0].ToString(),
                    Label = row[1].ToString(),
                    ActualField = row[2].ToString(),
                    ContentType = row[3].ToString()
                };
                databaseContents.Add(databaseContent);
            }
        }
        return databaseContents;
    }

    public List<CustomTag> LoadDefaultContactCustomFields(int companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<CustomTag> customTags = new List<CustomTag>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultContactCustomFields", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                CustomTag customTag = new CustomTag()
                {
                    FieldNameKey = row[1].ToString(),
                    FieldName = string.Concat("#", row[2].ToString().Replace("%27", "'").Replace("%22", "\""), "#"),
                    ScreenName = row[2].ToString().Replace("%27", "'").Replace("%22", "\"")
                };
                customTags.Add(customTag);
            }
        }
        return customTags;
    }

    public List<CustomTag> LoadDefaultDeptCustomFields(int companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        List<CustomTag> customTags = new List<CustomTag>();
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadDefaultDeptCustomFields", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                CustomTag customTag = new CustomTag()
                {
                    FieldNameKey = row[1].ToString(),
                    FieldName = string.Concat("#", row[2].ToString().Replace("%27", "'").Replace("%22", "\""), "#"),
                    ScreenName = row[2].ToString().Replace("%27", "'").Replace("%22", "\"")
                };
                customTags.Add(customTag);
            }
        }
        return customTags;
    }

    public List<TemplateEditor.Font> LoadFonts(string companyid, string _key)
    {
        List<TemplateEditor.Font> fonts = new List<TemplateEditor.Font>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadFontFamily", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateEditor.Font font = new TemplateEditor.Font()
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

    public List<TemplateFieldProperties> LoadFontStyle(string companyid, string _key)
    {
        List<TemplateFieldProperties> templateFieldProperties = new List<TemplateFieldProperties>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadFontStyles", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateFieldProperties templateFieldProperty = new TemplateFieldProperties()
                {
                    FontSyleID = Convert.ToInt64(row["FontID"]),
                    UserFontSyleName = row["FontStyle"].ToString()
                };
                templateFieldProperties.Add(templateFieldProperty);
            }
        }
        return templateFieldProperties;
    }

    public List<DeafultContent> LoadPhraseTitles(string companyid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_SelectPhraseTitle", sqlParameter);
        List<DeafultContent> deafultContents = new List<DeafultContent>();
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DeafultContent deafultContent = new DeafultContent()
                {
                    PhraseID = string.Concat(row[0].ToString(), "/", row[1].ToString()),
                    Title = row[2].ToString()
                };
                if (row[2].ToString() == "")
                {
                    deafultContent.Title = "Untitled";
                }
                deafultContents.Add(deafultContent);
            }
        }
        return deafultContents;
    }

    public TemplateDetails LoadTemplate(string templateid, string _key)
    {
        TemplateDetails templateDetail = new TemplateDetails();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@templateid", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_LoadTemplates", sqlParameter);
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
                templateDetail.CreatedBy = Convert.ToInt64(row["CreatedBy"].ToString());
                templateDetail.CreatedOn = Convert.ToDateTime(row["CreatedOn"].ToString());
                templateDetail.CropMarkHeight = Convert.ToDouble(row["CropMarkHeight"]);
                templateDetail.CropMarkWidth = Convert.ToDouble(row["CropMarkWidth"]);
                templateDetail.ImageName = row["ImageName"].ToString();
                templateDetail.IsAllowPDFPreviews = Convert.ToBoolean(row["IsAllowPDFPreviews"]);
                templateDetail.IsAllowWaterMark = Convert.ToBoolean(row["IsAllowWaterMark"]);
                templateDetail.IsConverted = Convert.ToBoolean(row["IsConverted"]);
                templateDetail.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);
                templateDetail.IsOverPrintFileRequired = Convert.ToBoolean(row["IsOverPrintFileRequired"]);
                templateDetail.isPDFPreviewMandatory = Convert.ToBoolean(row["IsPDFPreviewMandatory"]);
                templateDetail.PageHeight = Convert.ToDouble(row["PageHeight"]);
                templateDetail.PageWidth = Convert.ToDouble(row["PageWidth"]);
                templateDetail.PDFName = row["PDFName"].ToString();
                templateDetail.PriceCatalogueID = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                templateDetail.TemplateID = Convert.ToInt64(row["TemplateID"].ToString());
                templateDetail.TemplateName = row["TemplateName"].ToString();
                templateDetail.TemplateDescription = row["TemplateDescription"].ToString();
                templateDetail.Title = row["Title"].ToString();
                templateDetail.WaterMarkText = row["WaterMarkText"].ToString();
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
                templateDetail.IsGroupConsiderLabel = false;
            }
        }
        return templateDetail;
    }

    public List<TemplateFieldProperties> LoadTemplateControlls(string templateid, string _key)
    {
        List<TemplateFieldProperties> templateFieldProperties = new List<TemplateFieldProperties>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@templateid", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_TemplateProperties_Select_ByTemplateID_HTML5", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TemplateFieldProperties templateFieldProperty = new TemplateFieldProperties()
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
                    DatabaseContent = row["DatabaseContent"].ToString(),
                    DataType = row["DataType"].ToString(),
                    DefaultContent = row["DefaultContent"].ToString(),
                    Dropdowns = row["Dropdowns"].ToString(),
                    FontID = Convert.ToInt32(row["FontID"].ToString()),
                    LabelFontID = Convert.ToInt32(row["LabelFontID"].ToString()),
                    PhraseBookID = Convert.ToInt32(row["PhraseBookID"]),
                    PhraseType = row["PhraseType"].ToString(),
                    Edit = Convert.ToBoolean(row["Edit"]),
                    ExceedHeight = row["ExceedHeight"].ToString(),
                    ExceedImage = row["ExceedImage"].ToString(),
                    ExceedWidth = row["ExceedWidth"].ToString(),
                    FieldName = row["FieldName"].ToString(),
                    FontStyleName = row["FontStyleName"].ToString(),
                    FontFamily = row["FontFamily"].ToString(),
                    FontExtension = row["FontExtension"].ToString(),
                    ActualFontName = row["ActualFontFamilyName"].ToString()
                };
                if (row["ActualFontFamilyName"].ToString() == "")
                {
                    templateFieldProperty.ActualFontName = templateFieldProperty.FontFamily;
                }
                templateFieldProperty.FontSize = Convert.ToDouble(row["FontSize"]);
                templateFieldProperty.OriginalFontSize = Convert.ToDouble(row["FontSize"]);
                templateFieldProperty.FontStyle = row["FontStyle"].ToString();
                templateFieldProperty.FontWeight = row["FontWeight"].ToString();
                templateFieldProperty.Format = row["Format"].ToString();
                templateFieldProperty.FriendlyName = row["FriendlyName"].ToString();
                templateFieldProperty.GroupID = Convert.ToInt64(row["GroupID"].ToString());
                templateFieldProperty.Height = Convert.ToDouble(row["Height"]);
                templateFieldProperty.HelpText = row["HelpText"].ToString();
                templateFieldProperty.ImageLocation = row["ImageLocation"].ToString();
                templateFieldProperty.ImageSource = row["ImageSource"].ToString();
                templateFieldProperty.ImageGallery = row["ImageGallery"].ToString();
                templateFieldProperty.ImgUrl = row["ImageUrl"].ToString();
                templateFieldProperty.OrignalImageName = row["OriginalImageName"].ToString();
                templateFieldProperty.Indent = Convert.ToDouble(row["Indent"]);
                templateFieldProperty.K = row["K"].ToString();
                templateFieldProperty.LabelColor = row["LabelColor"].ToString();
                templateFieldProperty.LabelPosition = row["LabelPosition"].ToString();
                templateFieldProperty.Labels = row["Labels"].ToString();
                templateFieldProperty.LabelStyle = row["LabelStyle"].ToString();
                templateFieldProperty.LabelFontStyle = row["LabelFontStyle"].ToString();
                templateFieldProperty.IsLabelOnLeft = false;
                templateFieldProperty.Left = Convert.ToDouble(row["FieldLeft"]);
                templateFieldProperty.Lock = Convert.ToBoolean(row["Lock"]);
                templateFieldProperty.M = row["M"].ToString();
                templateFieldProperty.Mandatory = Convert.ToBoolean(row["Mandatory"]);
                templateFieldProperty.OrderNumber = Convert.ToInt16(row["ControlOrderNumber"]);
                string[] strArrays = row["ManualTracking"].ToString().Split(new char[] { ',' });
                if ((int)strArrays.Length != 1)
                {
                    templateFieldProperty.ManualTrackSign = strArrays[0];
                    templateFieldProperty.ManualTracking = Convert.ToDouble(strArrays[1]);
                    templateFieldProperty.ManualTrackDimension = strArrays[2];
                }
                else
                {
                    templateFieldProperty.ManualTrackSign = "+";
                    templateFieldProperty.ManualTracking = Convert.ToDouble(strArrays[0]);
                    templateFieldProperty.ManualTrackDimension = "pt";
                }
                templateFieldProperty.ParaLineSpace = Convert.ToDouble(row["LineSpacing"]);
                templateFieldProperty.MaxHeight = Convert.ToDouble(row["MaxHeight"]);
                templateFieldProperty.MaxShrink = Convert.ToDouble(row["MaxShrink"]);
                templateFieldProperty.MaxWidth = Convert.ToDouble(row["MaxWidth"]);
                templateFieldProperty.ObjectID = row["ObjectID"].ToString();
                templateFieldProperty.ObjTag = row["ObjectTag"].ToString();
                templateFieldProperty.LabelValue = row["Value"].ToString();
                templateFieldProperty.LabelFontSize = Convert.ToDouble(row["LabelFontSize"]);
                templateFieldProperty.OffsetHeight = row["OffsetHeight"].ToString();
                templateFieldProperty.OffsetLeft = row["OffsetLeft"].ToString();
                templateFieldProperty.OffsetTop = row["OffsetTop"].ToString();
                templateFieldProperty.OffsetWidth = row["OffsetWidth"].ToString();
                TemplateFieldProperties templateFieldProperty1 = templateFieldProperty;
                int? item = (int?)(row["PageNumber"] as int?);
                templateFieldProperty1.PageNumber = (item.HasValue ? item.GetValueOrDefault() : 1);
                templateFieldProperty.PixelHeight = row["Height"].ToString();
                templateFieldProperty.HideVisibility = Convert.ToBoolean(row["Hide"]);
                templateFieldProperty.PixelWidth = row["PixelWidth"].ToString();
                templateFieldProperty.PositionOffset = Convert.ToDouble(row["PositionX"]);
                templateFieldProperty.PositionX = Convert.ToDouble(row["PositionX"]);
                templateFieldProperty.PositionY = Convert.ToDouble(row["PositionY"]);
                templateFieldProperty.RotateAngle = Convert.ToDouble(row["RotateAngle"]);
                templateFieldProperty.SpotColor = Convert.ToBoolean(row["SpotColor"]);
                templateFieldProperty.SpotColorRef = row["SpotColorRef"].ToString();
                templateFieldProperty.TextAlign = row["TextAlign"].ToString();
                templateFieldProperty.LabelActualFontName = row["LabelActualFontName"].ToString();
                templateFieldProperty.LabelFontExtension = row["LabelFontExtension"].ToString();
                templateFieldProperty.Tint = Convert.ToDouble(row["Tint"]);
                templateFieldProperty.Top = Convert.ToDouble(row["FieldTop"]);
                templateFieldProperty.Type = row["FieldType"].ToString();
                templateFieldProperty.Visibility = Convert.ToBoolean(row["Visibility"]);
                templateFieldProperty.Width = Convert.ToDouble(row["Width"]);
                templateFieldProperty.Y = row["Y"].ToString();
                templateFieldProperty.R = Convert.ToDouble(row["R"]);
                templateFieldProperty.G = Convert.ToDouble(row["G"]);
                templateFieldProperty.B = Convert.ToDouble(row["B"]);
                templateFieldProperty.A = Convert.ToDouble(row["A"]);
                templateFieldProperty.GroupOrientation = row["GroupOrientation"].ToString();
                templateFieldProperty.KeepOption = row["KeepOptions"].ToString();
                templateFieldProperty.IsCropFromTop = Convert.ToBoolean(row["IsCropFromTop"].ToString());
                templateFieldProperty.IsFromBackEnd = Convert.ToBoolean(row["IsFromBackEnd"].ToString());
                templateFieldProperty.EditedImageName = row["EditedImageName"].ToString();
                templateFieldProperty.ZIndexValue = Convert.ToInt32(row["ZIndexValue"].ToString());
                templateFieldProperty.MinDPI = Convert.ToInt32(row["MinDPI"].ToString());
                templateFieldProperty.IsImageQuality = Convert.ToBoolean(row["IsImageQuality"].ToString());
                templateFieldProperty.IsFromPdf = Convert.ToBoolean(row["IsFromPdf"].ToString());
                templateFieldProperty.isDisplayonPDf = Convert.ToBoolean(row["isDisplayonPDf"]);
                templateFieldProperty.CustomFieldType = row["CustomFieldType"].ToString();
                templateFieldProperty.DefaultImageFrom = row["DefaultImageFrom"].ToString();
                templateFieldProperty.UsedImageId = Convert.ToInt32(row["UsedImageId"].ToString());
                try
                {
                    templateFieldProperty.AllowImageEdit = Convert.ToBoolean(row["AllowImageEdit"].ToString());
                    templateFieldProperty.IsJobNameField = Convert.ToBoolean(row["IsJobNameField"].ToString());
                    templateFieldProperty.PhoneFormat = (row["PhoneFormat"].ToString() != null ? row["PhoneFormat"].ToString() : "None");
                    templateFieldProperty.CurrencyFormat = (row["CurrencyFormat"].ToString() != null ? row["CurrencyFormat"].ToString() : "None");
                    templateFieldProperty.EditDropdown = Convert.ToBoolean(row["EditDropdown"].ToString());
                }
                catch
                {
                }
                templateFieldProperties.Add(templateFieldProperty);
            }
        }
        return templateFieldProperties;
    }

    public bool ResetAllControls(string templateid, string companyid, string _pagenumber, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = false;
        try
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@PageNumber", (object)Convert.ToInt64(_pagenumber)) };
            TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_ResetControls", sqlParameter);
            flag = true;
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    public string SaveAsNewImage_EditedImage(string OriginalImageName, string ImageUploadPath, string CompanyID, string DbKey, string TemplateID, string UserID)
    {
        TemplateEditorService templateEditorService = new TemplateEditorService();
        byte[] numArray = File.ReadAllBytes(string.Concat(GlobalVariables.SitePathPahysical, OriginalImageName));
        long length = (new FileInfo(string.Concat(GlobalVariables.SitePathPahysical, OriginalImageName))).Length;
        Image image = Image.FromStream(new MemoryStream(numArray));
        char[] chrArray = new char[] { '\u005F' };
        string str = OriginalImageName.Split(chrArray)[1];
        string imageUploadPath = ImageUploadPath;
        string str1 = string.Concat(imageUploadPath, CompanyID, "/Images/Gallery/OriginalImages");
        string str2 = string.Concat(imageUploadPath, CompanyID, "/Images");
        string str3 = string.Concat(imageUploadPath, CompanyID, "/Images/Gallery/ThumbnailImages");
        Guid guid = Guid.NewGuid();
        string str4 = guid.ToString().Substring(0, 5);
        image.Save(string.Concat(str1, "/", string.Concat(str4, "_", str)));
        image.Save(string.Concat(str2, "/", string.Concat(str4, "_", str)));
        string[] strArrays = new string[] { str4, "~", str, "~", length.ToString(), "," };
        templateEditorService.InsertImageGallery(CompanyID, TemplateID, "0", UserID, "admin", string.Concat(strArrays), "", "", DbKey);
        createThumbnail.CreateProportionalImage(image, string.Concat(str1, "/"), string.Concat(str3, "/"), string.Concat(str4, "_", str), 100, 100, (double)image.Width, (double)image.Height, true, 100, true);
        return string.Concat(str4, "_", str);
    }

    public List<string> SelectAllTemplateForCopyDropDown(string companyid, string templateid, string _key)
    {
        List<string> strs = new List<string>();
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Select_All_Template_For_Copy", sqlParameter);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string str = string.Concat(row["TemplateID"].ToString(), "~", row["TemplateName"].ToString());
                strs.Add(str);
            }
        }
        return strs;
    }

    public bool UpadteTemplateDetails(string TemplateDetail, string templateID, string userid, string companyid, string _key)
    {
        TemplateDetails templateDetail = JsonConvert.DeserializeObject<TemplateDetails>(TemplateDetail);
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = true;
        try
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateID)), new SqlParameter("@TemplateName", templateDetail.TemplateName), new SqlParameter("@TemplateDesc", templateDetail.TemplateDescription), new SqlParameter("@AddNewTextBlock", (object)templateDetail.AddNewTextBlock), new SqlParameter("@AddNewParagraph", (object)templateDetail.AddNewParagraph), new SqlParameter("@ShowEditor", (object)templateDetail.ShowEdiotr), new SqlParameter("@AddNewImage", (object)templateDetail.AddNewImage), new SqlParameter("@ShowEditablePages", (object)templateDetail.ShowEditablePages), new SqlParameter("@SendAttachment", (object)templateDetail.SendAttachment), new SqlParameter("@isGroupConsiderLabel", (object)templateDetail.IsGroupConsiderLabel), new SqlParameter("@zoompercentage", (object)templateDetail.ZoomPercent) };
            TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UpdateTemplateProc", sqlParameter);
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    public long UpdateImageCategory(string companyid, string categoryid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        long num = (long)0;
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@CategoryName", categoryname), new SqlParameter("@Description", description), new SqlParameter("@ParentID", (object)Convert.ToInt64(parentid)), new SqlParameter("@CategoryImage", categoryimage), new SqlParameter("@CreatedBy", (object)Convert.ToInt64(createdby)), new SqlParameter("@UserType", "admin"), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
        SqlParameter[] sqlParameterArray = sqlParameter;
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UpdateImageCategory", sqlParameterArray);
        num = Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value.ToString());
        return num;
    }

    public void UpdateImageDetails(string imageid, string companyid, string categoryid, string filename, string description, string metatags, string userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@CategoryID", (object)Convert.ToInt64(categoryid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@OriginalFileName", filename), new SqlParameter("@Description", description), new SqlParameter("@MetaTags", metatags) };
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_GalleryImages_Update", sqlParameter);
    }

    public string UpdateImageGallery(string CompanyID, string ImageIDs, string OriginalNames, string Descriptions, string MetaTags, string ObjectID, string TemplateID, string UserID, string _key, string DefaultImageName)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        (new SqlConnection()
        {
            ConnectionString = this.Templateconnectionstring
        }).Open();
        string[] strArrays = OriginalNames.Split(new char[] { '~' });
        string[] strArrays1 = MetaTags.Split(new char[] { '~' });
        string[] strArrays2 = Descriptions.Split(new char[] { '~' });
        string[] strArrays3 = ImageIDs.Split(new char[] { ',' });
        for (int i = 0; i < (int)strArrays.Length - 1; i++)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(strArrays3[i].ToString())), new SqlParameter("@CompanyID", (object)Convert.ToInt64(CompanyID)), new SqlParameter("@OriginalFileName", strArrays[i].ToString()), new SqlParameter("@Description", strArrays2[i].ToString()), new SqlParameter("@MetaTags", strArrays1[i].ToString()) };
            TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_UpdateImageGallery", sqlParameter);
        }
        return DefaultImageName;
    }

    public string UpdateTemplateProperties(string ControlDetail, string templateID, string userid, string companyid, string _key, string lastone)
    {
        TemplateFieldProperties templateFieldProperty = JsonConvert.DeserializeObject<TemplateFieldProperties>(ControlDetail);
        this.Templateconnectionstring = this.GetDomainKey(_key);
        bool flag = true;
        try
        {
            SqlParameter[] sqlParameter = new SqlParameter[108];
            sqlParameter[0] = new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateID));
            sqlParameter[1] = new SqlParameter("@UserID", (object)Convert.ToInt64(userid));
            sqlParameter[2] = new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid));
            sqlParameter[3] = new SqlParameter("@ObjectID", templateFieldProperty.ObjectID);
            sqlParameter[4] = new SqlParameter("@FieldName", templateFieldProperty.FieldName);
            sqlParameter[5] = new SqlParameter("@FriendlyName", templateFieldProperty.FriendlyName);
            sqlParameter[6] = new SqlParameter("@HelpText", templateFieldProperty.HelpText);
            sqlParameter[7] = new SqlParameter("@Mandatory", (object)templateFieldProperty.Mandatory);
            sqlParameter[8] = new SqlParameter("@Edit", (object)templateFieldProperty.Edit);
            sqlParameter[9] = new SqlParameter("@Visibility", (object)templateFieldProperty.Visibility);
            sqlParameter[10] = new SqlParameter("@PageNumber", (object)templateFieldProperty.PageNumber);
            sqlParameter[11] = new SqlParameter("@PositionX", (object)templateFieldProperty.PositionX);
            sqlParameter[12] = new SqlParameter("@PositionY", (object)templateFieldProperty.PositionY);
            sqlParameter[13] = new SqlParameter("@Lock", (object)templateFieldProperty.Lock);
            sqlParameter[14] = new SqlParameter("@MaxWidth", (object)templateFieldProperty.MaxWidth);
            sqlParameter[15] = new SqlParameter("@ExceedWidth", templateFieldProperty.ExceedWidth);
            sqlParameter[16] = new SqlParameter("@MaxShrink", (object)templateFieldProperty.MaxShrink);
            sqlParameter[17] = new SqlParameter("@RotateAngle", (object)templateFieldProperty.RotateAngle);
            sqlParameter[18] = new SqlParameter("@FontStyle", templateFieldProperty.FontStyle);
            sqlParameter[19] = new SqlParameter("@FontExtension", templateFieldProperty.FontExtension);
            sqlParameter[20] = new SqlParameter("@FontID", (object)templateFieldProperty.FontID);
            sqlParameter[21] = new SqlParameter("@LabelFontID", (object)templateFieldProperty.LabelFontID);
            sqlParameter[22] = new SqlParameter("@FontFamily", (templateFieldProperty.FontFamily == null ? "Arial" : templateFieldProperty.FontFamily));
            sqlParameter[23] = new SqlParameter("@ActualFontName", templateFieldProperty.ActualFontName);
            sqlParameter[24] = new SqlParameter("@FontSize", (object)templateFieldProperty.OriginalFontSize);
            object[] manualTrackSign = new object[] { templateFieldProperty.ManualTrackSign, ",", templateFieldProperty.ManualTracking, ",", templateFieldProperty.ManualTrackDimension };
            sqlParameter[25] = new SqlParameter("@ManualTracking", string.Concat(manualTrackSign));
            sqlParameter[26] = new SqlParameter("@TextAlign", templateFieldProperty.TextAlign);
            sqlParameter[27] = new SqlParameter("@Indent", (object)templateFieldProperty.Indent);
            sqlParameter[28] = new SqlParameter("@Capitalize", templateFieldProperty.Capitalize);
            sqlParameter[29] = new SqlParameter("@DataType", templateFieldProperty.DataType);
            sqlParameter[30] = new SqlParameter("@Format", templateFieldProperty.Format);
            sqlParameter[31] = new SqlParameter("@ColorStyle", templateFieldProperty.ColorStyle);
            sqlParameter[32] = new SqlParameter("@FontColor", templateFieldProperty.Color);
            sqlParameter[33] = new SqlParameter("@C", templateFieldProperty.C);
            sqlParameter[34] = new SqlParameter("@M", templateFieldProperty.M);
            sqlParameter[35] = new SqlParameter("@Y", templateFieldProperty.Y);
            sqlParameter[36] = new SqlParameter("@K", templateFieldProperty.K);
            sqlParameter[37] = new SqlParameter("@R", (object)templateFieldProperty.R);
            sqlParameter[38] = new SqlParameter("@G", (object)templateFieldProperty.G);
            sqlParameter[39] = new SqlParameter("@B", (object)templateFieldProperty.B);
            sqlParameter[40] = new SqlParameter("@A", (object)templateFieldProperty.A);
            sqlParameter[41] = new SqlParameter("@Tint", (object)templateFieldProperty.Tint);
            sqlParameter[42] = new SqlParameter("@SpotColor", (object)templateFieldProperty.SpotColor);
            sqlParameter[43] = new SqlParameter("@SpotColorRef", templateFieldProperty.SpotColorRef);
            sqlParameter[44] = new SqlParameter("@DefaultContent", templateFieldProperty.DefaultContent);
            sqlParameter[45] = new SqlParameter("@DatabaseContent", templateFieldProperty.DatabaseContent);
            sqlParameter[46] = new SqlParameter("@PhraseBookID", (object)templateFieldProperty.PhraseBookID);
            sqlParameter[47] = new SqlParameter("@PhraseType", templateFieldProperty.PhraseType);
            sqlParameter[48] = new SqlParameter("@Dropdowns", templateFieldProperty.Dropdowns);
            sqlParameter[49] = new SqlParameter("@Labels", templateFieldProperty.Labels);
            sqlParameter[50] = new SqlParameter("@Value", templateFieldProperty.LabelValue);
            sqlParameter[51] = new SqlParameter("@LabelFontSize", (object)templateFieldProperty.LabelFontSize);
            sqlParameter[52] = new SqlParameter("@LabelStyle", templateFieldProperty.LabelStyle);
            sqlParameter[53] = new SqlParameter("@LabelFontStyle", templateFieldProperty.LabelFontStyle);
            sqlParameter[54] = new SqlParameter("@LabelColor", templateFieldProperty.LabelColor);
            sqlParameter[55] = new SqlParameter("@LabelPosition", templateFieldProperty.LabelPosition);
            sqlParameter[56] = new SqlParameter("@CustomLeft", (object)templateFieldProperty.CustomLeft);
            sqlParameter[57] = new SqlParameter("@CustomTop", (object)templateFieldProperty.CustomTop);
            sqlParameter[58] = new SqlParameter("@CustomRight", (object)templateFieldProperty.CustomRight);
            sqlParameter[59] = new SqlParameter("@FieldType", templateFieldProperty.Type);
            sqlParameter[60] = new SqlParameter("@ImageUrl", templateFieldProperty.ImgUrl);
            sqlParameter[61] = new SqlParameter("@OriginalImageName", templateFieldProperty.OrignalImageName);
            sqlParameter[62] = new SqlParameter("@LineSpacing", (object)templateFieldProperty.ParaLineSpace);
            sqlParameter[63] = new SqlParameter("@MaxHeight", (object)templateFieldProperty.MaxHeight);
            sqlParameter[64] = new SqlParameter("@ExceedHeight", templateFieldProperty.ExceedHeight);
            sqlParameter[65] = new SqlParameter("@ExceedImage", templateFieldProperty.ExceedImage);
            sqlParameter[66] = new SqlParameter("@ImageLocation", templateFieldProperty.ImageLocation);
            sqlParameter[67] = new SqlParameter("@LabelFontExtension", templateFieldProperty.LabelFontExtension);
            sqlParameter[68] = new SqlParameter("@LabelActualFontName", templateFieldProperty.LabelActualFontName);
            sqlParameter[69] = new SqlParameter("@Align", templateFieldProperty.Align);
            sqlParameter[70] = new SqlParameter("@FieldTop", (object)templateFieldProperty.Top);
            sqlParameter[71] = new SqlParameter("@FieldLeft", (object)templateFieldProperty.Left);
            sqlParameter[72] = new SqlParameter("@Width", (object)templateFieldProperty.Width);
            sqlParameter[73] = new SqlParameter("@Height", (object)templateFieldProperty.Height);
            sqlParameter[74] = new SqlParameter("@FontWeight", templateFieldProperty.FontWeight);
            sqlParameter[75] = new SqlParameter("@FontStyleName", templateFieldProperty.FontStyleName);
            sqlParameter[76] = new SqlParameter("@BackgroundColor", templateFieldProperty.BackgroundImage);
            sqlParameter[77] = new SqlParameter("@OffsetWidth", templateFieldProperty.OffsetWidth);
            sqlParameter[78] = new SqlParameter("@OffsetHeight", templateFieldProperty.OffsetHeight);
            sqlParameter[79] = new SqlParameter("@OffsetTop", templateFieldProperty.OffsetTop);
            sqlParameter[80] = new SqlParameter("@OffsetLeft", templateFieldProperty.OffsetLeft);
            sqlParameter[81] = new SqlParameter("@PixelWidth", templateFieldProperty.PixelWidth);
            sqlParameter[82] = new SqlParameter("@Hide", (object)templateFieldProperty.HideVisibility);
            sqlParameter[83] = new SqlParameter("@CanChangeFontColor", (object)templateFieldProperty.CanChangeFontColor);
            sqlParameter[84] = new SqlParameter("@CanChangeFontSize", (object)templateFieldProperty.CanChangeFontSize);
            sqlParameter[85] = new SqlParameter("@CanChangeFont", (object)templateFieldProperty.CanChangeFont);
            sqlParameter[86] = new SqlParameter("@ObjectTag", templateFieldProperty.ObjTag);
            sqlParameter[87] = new SqlParameter("@GroupID", (object)templateFieldProperty.GroupID);
            sqlParameter[88] = new SqlParameter("@ImageSource", templateFieldProperty.ImageSource);
            sqlParameter[89] = new SqlParameter("@ImageGallery", templateFieldProperty.ImageGallery);
            sqlParameter[90] = new SqlParameter("@ControlOrderNumber", (object)templateFieldProperty.OrderNumber);
            sqlParameter[91] = new SqlParameter("@GroupOrientation", templateFieldProperty.GroupOrientation);
            sqlParameter[92] = new SqlParameter("@KeepOptions", templateFieldProperty.KeepOption);
            sqlParameter[93] = new SqlParameter("@IsFromBackEnd", (object)templateFieldProperty.IsFromBackEnd);
            sqlParameter[94] = new SqlParameter("@EditedImageName", templateFieldProperty.EditedImageName);
            sqlParameter[95] = new SqlParameter("@ZIndexValue", (object)templateFieldProperty.ZIndexValue);
            sqlParameter[96] = new SqlParameter("@IsCropFromTop", (object)templateFieldProperty.IsCropFromTop);
            sqlParameter[97] = new SqlParameter("@IsImageQuality", (object)templateFieldProperty.IsImageQuality);
            sqlParameter[98] = new SqlParameter("@MinDPI", (object)templateFieldProperty.MinDPI);
            sqlParameter[99] = new SqlParameter("@isDisplayonPDf", (object)templateFieldProperty.isDisplayonPDf);
            sqlParameter[100] = new SqlParameter("@CustomFieldType", templateFieldProperty.CustomFieldType);
            sqlParameter[101] = new SqlParameter("@DefaultImageFrom", templateFieldProperty.DefaultImageFrom);
            sqlParameter[102] = new SqlParameter("@UsedImageID", (object)templateFieldProperty.UsedImageId);
            sqlParameter[103] = new SqlParameter("@AllowImageEdit", (object)templateFieldProperty.AllowImageEdit);
            sqlParameter[104] = new SqlParameter("@IsJobNameField", (object)templateFieldProperty.IsJobNameField);
            sqlParameter[105] = new SqlParameter("@PhoneFormat", templateFieldProperty.PhoneFormat);
            sqlParameter[106] = new SqlParameter("@CurrencyFormat", templateFieldProperty.CurrencyFormat);
            sqlParameter[107] = new SqlParameter("@EditDropdown", (object)templateFieldProperty.EditDropdown);
            TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_InsertTemplatePropertiesProc_html5", sqlParameter);
        }
        catch
        {
            flag = false;
        }
        return string.Concat(flag, ",", lastone);
    }

    public void UploadImageDetails(long imageid, long companyid, string orgfilename, string filename, string filesize, long userid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@ImageID", (object)Convert.ToInt64(imageid)), new SqlParameter("@CompanyID", (object)Convert.ToInt64(companyid)), new SqlParameter("@UserID", (object)Convert.ToInt64(userid)), new SqlParameter("@OriginalFileName", orgfilename), new SqlParameter("@FileName", filename), new SqlParameter("@FileSize", filesize) };
        TemplateEditor.SQL.ExecuteNonQuery(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Gallery_UpdateImage", sqlParameter);
    }

    public List<VerticalGroupDetails> VerticalGroupDetails(string Companyid, string templateid, string _key)
    {
        this.Templateconnectionstring = this.GetDomainKey(_key);
        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)Convert.ToInt64(Companyid)), new SqlParameter("@TemplateID", (object)Convert.ToInt64(templateid)) };
        DataSet dataSet = TemplateEditor.SQL.ExecuteDataset(this.Templateconnectionstring, CommandType.StoredProcedure, "et_Select_VerticalGroup_Details", sqlParameter);
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