<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="job_NCR_item.aspx.cs" Inherits="ePrint.Jobs.job_NCR_item" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="NCRItem" Src="~/usercontrol/Item/NCR_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:NCRItem ID="UCNCRItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
