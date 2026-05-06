<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="ePrint.WebStore.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <link href="<%#StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="Link1" rel="Stylesheet"
            type="text/css" />
        <link href="<%#StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
            type="text/css" />
        <link href="<%#StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link2" rel="Stylesheet"
            type="text/css" />
    </asp:PlaceHolder>
    <script type="text/javascript" language="javascript">
        var StyleSheetPath = '<%=StyleSheetPath %>';
        var StyleSheetPathMaster = '<%=StyleSheetPathMaster%>';
    </script>
</head>
<body id="mainDiv_error">
    <form id="form1" runat="server">
    <div>
        <div id="messageboxSessionLogout">
            <div>
                Please use your account name and login</div>
            <br />
            <div class="Validationfont">
                Example:<%=strSitepath%>AccountName</div>
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function redirectHome() {
        var strSitepath = '<%=strSitepath %>';
        location.href = strSitepath;
    }
</script>
