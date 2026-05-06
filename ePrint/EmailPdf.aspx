<%@ page language="C#" autoeventwireup="true" CodeBehind="EmailPdf.aspx.cs" Inherits="ePrint.EmailPdf" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Email Pdf</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="padding: 12px">
        <iframe id="iframe_pdf" name="iframe_pdf" runat="server" width="90%" height="842px">
        </iframe>
    </div>
    </form>
    <script type="text/javascript">
        var strSitepath = '<%=SecureSitePath %>';
        var ServerName = '<%=ServerName %>';
        var CompanyID = '<%=CompanyID %>';

        function Pdf_OpenFromEmail(FileName, AccountID) {
            var FileName = getUrlVars()["File"];
            CompanyID = getUrlVars()["CompanyID"];
            var Type = getUrlVars()["type"];
            var AccountID = getUrlVars()["accountid"];
            if (Type == 'pr') {
                document.getElementById('iframe_pdf').src = strSitepath + ServerName + "/" + CompanyID + "/Product/PrintReady/" + FileName;
            }
            else if (Type == 'et') {
                document.getElementById('iframe_pdf').src = strSitepath + ServerName + "/store/" + AccountID + "/Pdf/" + FileName;
            }
            else {
                document.getElementById('iframe_pdf').src = strSitepath + ServerName + "/" + CompanyID + "/attachments/" + FileName;
            }
            // window.open(strSitepath + ServerName + "/" + CompanyID + "/Product/PrintReady/" + FileName, '_self');
        }

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        window.onload = Pdf_OpenFromEmail;
    </script>
</body>
</html>
