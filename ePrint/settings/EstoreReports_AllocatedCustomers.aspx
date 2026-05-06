<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstoreReports_AllocatedCustomers.aspx.cs" Inherits="ePrint.settings.EstoreReports_AllocatedCustomers" masterpagefile="~/Templates/popUpMasterPage_new.master" %>

<%@ Register Src="~/usercontrol/StoreSettings/EstoreReports_AllocatedCustomers.ascx"
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

