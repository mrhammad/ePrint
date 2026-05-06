using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TemplateEditorFrontEnd;

[ServiceContract]
public interface ITemplateEditorFrontEndSevice
{
	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool CreateImageForAttachment(string templateid, string cartitemid, string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string CreateImageThumbnails(long companyid, long templateid, long userid, string filenames, string finalFilesize, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<string> CreateResizedImage(long companyid, long templateid, long userid, string originalFilename, string path, double canvasWidth, double canvasHeight, double _zoompercnt, bool _iscropfromtop, bool Thumbnail100x100, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	long DeleteGalleryImages(string imageid, string templateid, string objectid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	long DeleteImageCategory(string categoryid, string templateid, string objectid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	int DeleteMultipleFilesFolders(string categoryids, string imageids, int templateid, int companyid, string objectid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool DeleteWsTemplateProperties(string templateid, string cartitemid, string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<ColorStyle> GetColorStyleDetailProperties(string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<QueryStringPara> GetDecriptedQuerySting(string _quertstr);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string GetDomainKey(string _EprintConnectKey);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<Font> GetFontStyle(string FontStyle, string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	ImageGalleryParentResponse GetFrontendUserImageGallery(string companyid, string categoryid, string userid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<ImageCategory> GetImageCategoryByFrontendUser(string companyid, string userid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	Globals GetKeyValuesForPath(string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string GetProductName(string priceCatalogueID, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	ImageGalleryParentResponse GetSystemGalleryFoldersandFiles(string companyid, string categoryid, string templateid, string objectid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<ImageCategory> GetSystemGallerySearch(string companyid, string categoryid, string templateid, string objectid, string searchtext, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	ImageGalleryParentResponse GetSystemGallerySubFoldersandFiles(string companyid, string categoryid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<ImageCategory> GetUserGallerySearch(string companyid, string categoryid, string userid, string searchtext, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<HorzontalGroupDetails> HorizontalGroupDetails(string Companyid, string templateid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<ImageCategory> ImageListAfterUpload(string ImageIDList, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	long InsertImageCategory(string companyid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string InsertTemplateProperties(string PropertiesDetail, string templateid, string sessionid, string userid, string companyid, string cartitemid, string _key, string lastone);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string InsertUserImageGallery(string companyid, string templateid, string categoryid, string userid, string usertype, string fileList, string description, string metatags, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<AddressBook> LoadDataBaseContentsAddress(string userid, string cartitemid, string type, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<DefaultPhrase> LoadDataBasePhraseTextForDropDowns(string Companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<string> LoadDataBasePhrasstextBasedOnType(string userid, string cartitemid, string phraseid, string templateid, string type, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<string> LoadDataForDropDownDepartment(string cartitemid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<string> LoadDataForDropDownsContact(string StoreuserID, string Type, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<Font> LoadFonts(string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<TemplateFieldPropertiesFrontEnd> LoadFontStyle(string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<TemplateFieldPropertiesFrontEnd> LoadTemplateControlls(string cartitemid, string templateid, string userid, string companyid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	TemplateDetails LoadTemplateDetails(string templateid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	string LoadUserAccountDetails(int CompanyID, int AccountID, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool UpdateAddCartStatus(long CartItemId, string PDFname, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool UpdateDesignName(long CartItemId, string designname, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	long UpdateImageCategory(string companyid, string categoryid, string categoryname, string description, string parentid, string categoryimage, string createdby, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	void UpdateImageDetails(string imageid, string companyid, string categoryid, string filename, string description, string metatags, string userid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool UpdatePreviewStatus(long CartItemId, string PDFname, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	bool UpdateSaveStatus(long CartItemId, string PreviewType, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	void UploadImageDetails(long imageid, long companyid, string orgfilename, string filename, string filesize, long userid, string _key);

	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
	List<VerticalGroupDetails> VerticalGroupDetails(string Companyid, string templateid, string _key);
}