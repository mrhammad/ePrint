<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="client_add.aspx.cs" Inherits="ePrint.client.client_add" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>
<%@ Register Src="~/usercontrol/crm/Client_add_new.ascx" TagName="ClientAdd" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div>
        <UC:ClientAdd ID="ClientAddID" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

