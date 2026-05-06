<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="common_popup_othercost.aspx.cs" Inherits="ePrint.common.common_popup_othercost" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/Item/othercost_selector_new.ascx" TagName="OtherCost"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div>
    </div>
    <div style="overflow: hidden;">
        <asp:PlaceHolder ID="plhDiv" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
