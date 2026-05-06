<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/popUpMasterPage.master" AutoEventWireup="true" CodeBehind="Summary_Page_Common_popup.aspx.cs" Inherits="ePrint.common.Summary_Page_Common_popup" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register Src="~/usercontrol/Item/Item_Summary_CopytoNew_SameCustomer.ascx" TagName="CopyNewCust"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Item/notes.ascx" TagName="ActivityHistory"
    TagPrefix="UC" %>

<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="callClass" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function saveCallback() {
            parent.location.href = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnReloadUrl").value;
        }
       
    </script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div>
        <UC:callClass ID="usrCallclass" runat="server" />
    </div>

    <div>
        <asp:PlaceHolder ID="plhDiv" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
