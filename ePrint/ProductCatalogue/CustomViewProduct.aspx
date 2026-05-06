<%@ page title="" language="C#" masterpagefile="~/Templates/productcatalogue.master" autoeventwireup="true" CodeBehind="CustomViewProduct.aspx.cs" Inherits="ePrint.ProductCatalogue.CustomViewProduct" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomView" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewProduct.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <uc:CustomView runat="server" ID="ucCustomView" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

