<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="ePrint.MyPublicStore.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/NewStyleSheet.css" rel="Stylesheet" type="text/css" />
</head>
<body id="mainDiv_error">
    <form id="form1" runat="server">
    <div>
        <div id="messageboxSessionLogout" class="contentArea_Background">
            <div>
                Your session has timed out. Please login again to reactive your session.</div>
            <div>
                <a href="#" onclick="javascript:redirectHome();">Please click here to Login</a></div>
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" type="text/javascript">
    function redirectHome() {
        var strSitepath = '<%=strSitepath %>';
        location.href = strSitepath;
    }
</script>
