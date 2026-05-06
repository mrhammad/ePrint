<%@ page title="" language="C#" autoeventwireup="true" CodeBehind="logout.aspx.cs" Inherits="ePrint.WebStore.logout"  enableEventValidation="false" viewStateEncryptionMode="Never" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="<%#StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="Link1" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link2" rel="Stylesheet"
        type="text/css" />
</head>
<body id="logout_body" class="loginpage-body">
    <form id="form1" runat="server">
    <table id="tblheaderimage" runat="server">
        <tr>
            <td id="tdheaderimage" runat="server">
                <asp:PlaceHolder ID="ph_headerLeft" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
    <div class="paddingTop10p">
        <center>
            <table>
                <tr>
                    <td align="center">
                        <div>
                            <asp:Label ID="lblLogOutHead" runat="server" Text="Visit Again" CssClass="LogoutHearderText"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="paddingTop5">
                            <asp:LinkButton ID="Label1" CssClass="ClickHereText" runat="server" Text="" OnClick="Label1_LogInAgain"></asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <div align="left" id="footer_content">
        <%----------- Footer Area div -------------%>
        <div class="footer_div DisplayNone">
            <asp:PlaceHolder ID="ph_footer" runat="server"></asp:PlaceHolder>
        </div>
        <div class="clearBoth">
        </div>
        <div align="left" id="divfooterMain" runat="server">
            <div id="divfootersub" runat="server">
                <asp:Label ID="lbl_copyWriter" runat="server" Visible="false"></asp:Label>
                <asp:PlaceHolder ID="ph_copyWriter" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    var strSitePath = '<%=strSitePath %>';
    var AccountID = '<%=AccountID %>';

    var t;
    window.onload = resetTimer;
    document.onkeypress = resetTimer;

    // (strSitePath + "login.aspx?id=" + AccountID)

    function logout() {
        location.href = strSitePath + 'login.aspx?id=' + AccountID
    }
    function resetTimer() {
        clearTimeout(t);
        t = setTimeout(logout, 5000)
    }
 
   
</script>
</html>
