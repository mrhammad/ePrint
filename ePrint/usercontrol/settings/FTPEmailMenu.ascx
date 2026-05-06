<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FTPEmailMenu.ascx.cs" Inherits="ePrint.usercontrol.settings.FTPEmailMenu" %>

<style>
    .ftp-sidebar {
        width: 200px;
        background-color: #f7f9fc;
        border-right: 1px solid #ddd;
        padding: 0;
        border-radius: 8px 0 0 8px;
        box-shadow: inset -1px 0 0 #e0e0e0;
        margin-top:12px;
    }

    .ftp-sidebar-header {
        font-weight: bold;
        color: #2c3e50;
        padding: 10px 16px;
        border-bottom: 1px solid #ddd;
/*        background: #eef2f7;
*/        background:#eaeaea;
        border-radius: 8px 0 0 0;
    }

    .ftp-nav {
        list-style: none;
        margin: 0;
        padding: 0;
    }

    .ftp-nav-item {
        cursor: pointer;
        padding: 8px 16px;
        border-left: 4px solid transparent;
        transition: background-color 0.3s, border-left-color 0.3s;
        color: #333;
    }

    .ftp-nav-item:hover {
        background-color: #d8ecff;
    }

    .ftp-nav-item.active {
        background-color: #cce5ff;
        border-left-color: #0078d4;
        font-weight: bold;
        color: #004c94;
    }
</style>

<div class="ftp-sidebar">
    <div class="ftp-sidebar-header">
        <%=objLanguage.GetLanguageConversion("FTP_Emails")%>
    </div>
    <ul class="ftp-nav">
        <li class='ftp-nav-item <%=(Request.RawUrl.ToLower().Contains("ftpsuccessemail.aspx") ? "active" : "")%>'
            onclick="window.location.href='../Settings/FTPSuccessEmail.aspx';">
            <%=objLanguage.GetLanguageConversion("FTP_Success")%>
        </li>
        <li class='ftp-nav-item <%=(Request.RawUrl.ToLower().Contains("ftpfailureemail.aspx") ? "active" : "")%>'
            onclick="window.location.href='../Settings/FTPFailureEmail.aspx';">
            <%=objLanguage.GetLanguageConversion("FTP_Failure")%>
        </li>
    </ul>
</div>
