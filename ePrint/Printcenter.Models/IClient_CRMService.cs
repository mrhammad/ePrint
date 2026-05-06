using System;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IClient_CRMService
{
	[OperationContract]
	[WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.Wrapped, UriTemplate="json/ClientNotesAdd")]
	void ClientNotesAdd(string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string CreateUserID, string Subject, string Title);
}