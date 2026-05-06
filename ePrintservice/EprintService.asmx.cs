using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace com.eprintsoftware.www
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("System.Web.Services", "4.0.30319.18408")]
    [WebServiceBinding(Name = "EprintServiceSoap", Namespace = "http://www.eprintsoftware.com/")]
    public class EprintService : SoapHttpClientProtocol
    {
        private SendOrPostCallback ReturnCurrentDateTimeByTimeZoneIDOperationCompleted;

        public EprintService()
        {
            string item = ConfigurationManager.AppSettings["com.eprintsoftware.www.eprintservice"];
            if (item != null)
            {
                base.Url = item;
                return;
            }
            base.Url = "http://192.168.1.41/EprintAPI/eprintservice.asmx";
        }

        public IAsyncResult BeginReturnCurrentDateTimeByTimeZoneID(DateTime dt, string TimeZoneID, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { dt, TimeZoneID };
            return base.BeginInvoke("ReturnCurrentDateTimeByTimeZoneID", objArray, callback, asyncState);
        }

        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        public string EndReturnCurrentDateTimeByTimeZoneID(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        private void OnReturnCurrentDateTimeByTimeZoneIDOperationCompleted(object arg)
        {
            if (this.ReturnCurrentDateTimeByTimeZoneIDCompleted != null)
            {
                InvokeCompletedEventArgs invokeCompletedEventArg = (InvokeCompletedEventArgs)arg;
                this.ReturnCurrentDateTimeByTimeZoneIDCompleted(this, new ReturnCurrentDateTimeByTimeZoneIDCompletedEventArgs(invokeCompletedEventArg.Results, invokeCompletedEventArg.Error, invokeCompletedEventArg.Cancelled, invokeCompletedEventArg.UserState));
            }
        }

        [SoapDocumentMethod("http://www.eprintsoftware.com/ReturnCurrentDateTimeByTimeZoneID", RequestNamespace = "http://www.eprintsoftware.com/", ResponseNamespace = "http://www.eprintsoftware.com/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string ReturnCurrentDateTimeByTimeZoneID(DateTime dt, string TimeZoneID)
        {
            object[] objArray = new object[] { dt, TimeZoneID };
            return (string)base.Invoke("ReturnCurrentDateTimeByTimeZoneID", objArray)[0];
        }

        public void ReturnCurrentDateTimeByTimeZoneIDAsync(DateTime dt, string TimeZoneID)
        {
            this.ReturnCurrentDateTimeByTimeZoneIDAsync(dt, TimeZoneID, null);
        }

        public void ReturnCurrentDateTimeByTimeZoneIDAsync(DateTime dt, string TimeZoneID, object userState)
        {
            if (this.ReturnCurrentDateTimeByTimeZoneIDOperationCompleted == null)
            {
                this.ReturnCurrentDateTimeByTimeZoneIDOperationCompleted = new SendOrPostCallback(this.OnReturnCurrentDateTimeByTimeZoneIDOperationCompleted);
            }
            object[] objArray = new object[] { dt, TimeZoneID };
            base.InvokeAsync("ReturnCurrentDateTimeByTimeZoneID", objArray, this.ReturnCurrentDateTimeByTimeZoneIDOperationCompleted, userState);
        }

        public event ReturnCurrentDateTimeByTimeZoneIDCompletedEventHandler ReturnCurrentDateTimeByTimeZoneIDCompleted;
    }
}