<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="guillotine_add.aspx.cs" Inherits="ePrint.settings.guillotine_add" title="Settings: Plant and Presses" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>
<%@ Register Src="~/usercontrol/Settings/guillotine_add.ascx" TagName="Guillotine"
    TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <UC:Guillotine ID="guillotine" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
