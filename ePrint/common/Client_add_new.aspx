<%@ page title="" language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true"  CodeBehind="Client_add_new.aspx.cs" Inherits="ePrint.common.Client_add_new" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/crm/Client_add_new.ascx" TagName="ClientAdd" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <UC:ClientAdd ID="ClientAddID" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
