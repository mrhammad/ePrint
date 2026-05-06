<%@ page language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="estimate_single_item.aspx.cs" autoeventwireup="true" Inherits="ePrint.estimate_single_item" title="Single Item" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="SingleItem" Src="~/usercontrol/Item/single_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:SingleItem ID="UCSingleItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
 