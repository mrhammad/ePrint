<%@ page title="Print Management Software : Job Summary" language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="job_summary_reeng.aspx.cs" Inherits="ePrint.Jobs.job_summary_reeng" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="UcItemSummaryMain" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_main.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:UcItemSummaryMain ID="UCItemSummaryMain" runat="server" />
    <script>
        var Ispaidenable = '<%=Ispaidenable %>';    
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
