<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="ePrint.MyPublicStore.logout"  masterpagefile="~/Templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="logoutMain_div" class="contentArea_Background">
        <div id="logout_content">
            <div id="logoutHeader" class="Header_Background">
                <strong>You are now logged out </strong>
            </div>
            <div id="logoutArea">
                <asp:Label ID="Label1" runat="server" Text="You have logged out and will be redirecting in "></asp:Label>
                <asp:Label ID="lbl_cntDown" runat="server" Text="5"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="seconds"></asp:Label>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var time_left = 5;
        var cinterval;

        function time_dec() {
            var cntDown = document.getElementById("<%=lbl_cntDown.ClientID %>");
            time_left--;
            cntDown.innerHTML = " " + time_left;
            if (time_left == 0) {
                clearInterval(cinterval);
                window.location = "default.aspx";
            }
        }
        cinterval = setInterval('time_dec()', 1000);

    </script>
</asp:Content>


