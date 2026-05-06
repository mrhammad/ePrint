<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/popUpMasterPage_new.master" CodeBehind="DeliveryNo_List.aspx.cs" Inherits="ePrint.settings.DeliveryNo_List" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/StoreSettings/DeliveryNo_ListShow.ascx"
    TagName="CustomerName" TagPrefix="UC" %>
    
<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="callClass" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <UC:callClass ID="usrCallclass" runat="server" />
    </div>
    <div style="padding: 10px;">
        <UC:CustomerName ID="ucCustomerName" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
