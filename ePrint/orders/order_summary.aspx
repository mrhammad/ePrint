<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="order_summary.aspx.cs" Inherits="ePrint.orders.order_summary" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="UC" TagName="UcItemSummaryMain" Src="~/usercontrol/Item/item_summary_main.ascx" %>
<%@ Register TagName="ActivityHistory" TagPrefix="UC" Src="~/usercontrol/Item/notes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:UcItemSummaryMain ID="UCItemSummaryMain" runat="server" />
    <services>
        <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
    </services>
    <script language="javascript" type="text/javascript">
        function ShowNotes() {

            var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + <%=OrderID %> + "&type=ActivityHistory&pg=orders");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            RadWindow_Paid.setSize(1000, 500);
            RadWindow_Paid.center();
        }

        function hideDiv(divid) {
            document.getElementById(divid).style.display = "none";
            selects = document.getElementsByTagName("select");
            document.getElementById("divBackGroundNew").style.display = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>




