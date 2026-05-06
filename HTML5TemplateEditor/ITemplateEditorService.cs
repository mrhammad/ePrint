using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TemplateEditor;

[ServiceContract]
public interface ITemplateEditorService
{
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    int checkmaxupload(string ControlDetail, string templateID, string userid, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    long CopyTemplateWithProperties(string copiedtemplateid, string currenttemplateid, string userid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string CreateProportionalImage(long companyid, long templateid, long userid, string originalFilename, string path, double canvasWidth, double canvasHeight, double originalWidth, double originalHeight, double _zoompercnt, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    long DeleteGalleryImages(string imageid, string templateid, string objectid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<HorzontalGroupDetails> DeleteHorizontalGroup(string templateid, string grpid, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    long DeleteImageCategory(string categoryid, string templateid, string objectid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string DeleteMultipleFilesFolders(string categoryids, string imageids, string userid, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<VerticalGroupDetails> DeleteVerticalGroup(string templateid, string grpid, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<ColorStyle> GetColorStyleDetailProperties(string companyid, string _key);

    [OperationContract]
    ColorStyle GetColorStyleDetails(string colorstyle, long _colorid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string GetDomainKey(string _EprintConnectKey);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<Font> GetFontStyle(string FontStyle, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<CategoryList> GetImageCategoryByCompany(string companyid, string userid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<ImageCategory> GetImageGalleryAssignment(string companyid, string templateid, string objectid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    ImageGalleryParentResponse GetImageGallerySearch(string companyid, string categoryid, string userid, string searchtext, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    Globals GetKeyValuesForPath(string _key);

    [OperationContract]
    string GetProductName(string priceCatalogueID, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    ImageGalleryParentResponse GetSystemGalleryFoldersandFiles(string companyid, string categoryid, string _key);

    [OperationContract]
    List<HorzontalGroupDetails> HorizontalGroupDetails(string Companyid, string templateid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void ImageGalleryAssignment_Delete(string compnayid, string templateid, string objectid, string type, string typeid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<ImageCategory> ImageListAfterUpload(string ImageIDList, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void Insert_ImageGalleryAssignment(string objectid, string companyid, string templateid, string userid, string types, string typeids, string defaultid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void Insert_ImageGalleryAssignment_Onclick(string objectid, string companyid, string templateid, string userid, string type, string typeid, string isdefault, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string insertGroup(string orentation, string groupname, string templateid, string companyid, string groupid, string keepoption, string controlspace, string positionx, string positiony, string align, string pagenumber, string grpOption, string IsParaGroup, string IsConsiderLabel, Boolean GroupMoveRelative,decimal GroupMovementValue, string _key);

    [OperationContract]
    long InsertHorizontalGroupDetail(string groupname, long templateid, long companyid, long groupid, string keepoption, double controlspace, double positionx, double positiony, string align, long pagenumber, string grpOption, Boolean GroupMoveRelative, decimal GroupMovementValue, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    long InsertImageCategory(string companyid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key);

    [OperationContract]
    string InsertImageGallery(string companyid, string templateid, string categoryid, string userid, string usertype, string fileList, string description, string metatags, string _key);

    [OperationContract]
    long InsertVerticalGroupDetail(string groupname, long templateid, long companyid, long groupid, string keepoption, double controlspace, double positionx, double positiony, string align, long pagenumber, string grpOption, string IsParaGroup, string IsConsiderLabel, Boolean GroupMoveRelative, decimal GroupMovementValue, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string IsDeleteMultipleFilesFoldersAssigned(string categoryids, string imageids, string templateid, string companyid, string objectid, string _key);

    [OperationContract]
    List<DatabaseContent> LoadDataBaseContents(string _key);

    [OperationContract]
    List<CustomTag> LoadDefaultContactCustomFields(int companyid, string _key);

    [OperationContract]
    List<CustomTag> LoadDefaultDeptCustomFields(int companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<Font> LoadFonts(string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<TemplateFieldProperties> LoadFontStyle(string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<DeafultContent> LoadPhraseTitles(string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    TemplateDetails LoadTemplate(string templateid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<TemplateFieldProperties> LoadTemplateControlls(string templateid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    bool ResetAllControls(string templateid, string companyid, string _pagenumber, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string SaveAsNewImage_EditedImage(string OriginalImageName, string ImageUploadPath, string CompanyID, string DbKey, string TemplateID, string UserID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<string> SelectAllTemplateForCopyDropDown(string companyid, string templateid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    bool UpadteTemplateDetails(string TemplateDetail, string templateID, string userid, string companyid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    long UpdateImageCategory(string companyid, string categoryid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void UpdateImageDetails(string imageid, string companyid, string categoryid, string filename, string description, string metatags, string userid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string UpdateImageGallery(string CompanyID, string ImageIDs, string OriginalNames, string Descriptions, string MetaTags, string ObjectID, string TemplateID, string UserID, string _key, string DefaultImageName);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    string UpdateTemplateProperties(string ControlDetail, string templateID, string userid, string companyid, string _key, string lastone);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void UploadImageDetails(long imageid, long companyid, string orgfilename, string filename, string filesize, long userid, string _key);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<VerticalGroupDetails> VerticalGroupDetails(string Companyid, string templateid, string _key);
}