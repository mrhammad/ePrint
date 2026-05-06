<%@ page title="" language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="contact_add.aspx.cs" Inherits="ePrint.contact.contact_add" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/crm/contact_add_new.ascx" TagName="CONTACT" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:CONTACT ID="UCContact" runat="server" />

    <script>
        document.getElementById("ctl00_ContentPlaceHolder1_UCContact_txtTitle").focus();
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
