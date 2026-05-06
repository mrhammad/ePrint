<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="delivery_add.aspx.cs" Inherits="ePrint.Delivery.delivery_add" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/Delivery/delivery_add.ascx" TagName="Delivery" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <UC:Delivery ID="UCDeliveryNote" runat="server" BaseSection="deliverynote"></UC:Delivery>

    <script type="text/javascript">
        var currentdate = '<%=currentdate%>';
        function SetFollowupContact(sub, hid) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_UCTask_txtcontacttype").value = SpecialDecode(sub);
        }
        function printemail() {

            var val = Validate_delivery();
            if (val) {
                document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_Mode").value = "print";
                __doPostBack('ctl00$ContentPlaceHolder1$UCDeliveryNote$lnkSave', '');
            }
            else {
                return false;
            }
        }
        function Copy_Delivery() {
            debugger;
            var DeliveryID = "<%=DeliveryID %>";
            __doPostBack('ctl00$ContentPlaceHolder1$UCDeliveryNote$lnkDeliveryCopy', '');

        }

        function ShowNotes() {

            var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?id=" + <%=DeliveryID %> + "&type=ActivityHistory&pg=Delivery");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            RadWindow_Paid.setSize(1000, 500);
            RadWindow_Paid.center();
        }
        function hideDiv(divid) {
            document.getElementById(divid).style.display = "none";
            //dropdown show//
            selects = document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].style.display = "block";
            }
            if (divid == "div_ActivityHistory_add") {
                document.getElementById("divBackGroundNew").style.display = "block";
            }
            else {
                document.getElementById("divBackGroundNew").style.display = "none";
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

