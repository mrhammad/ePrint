<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error_report.aspx.cs" Inherits="ePrint.WebStore.error_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="<%=StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle1"
        rel="Stylesheet" type="text/css" />
    <link href="<%=StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link2" rel="Stylesheet"
        type="text/css" />
</head>
<body>
    <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    <%--<table style="height: 100%; background-color: #FFFFFF" frame="border" 
        border="0" cellspacing="0" cellpadding="0" align="center">
        <tr valign="top">
            <td>
                <table border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
                    <tr>
                        <td align="left" style="width: 138px" class="toptext1">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <table width="76%" border="0" cellspacing="0" cellpadding="0" align="right">
                                <tr>
                                    <td align="left" class="normaltext">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 9">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="80%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 100%;
                                margin-top: 15%">
                                <tr>
                                    <td align="center">
                                        <div class="messageboxErrorSupport_ErrorPage">
                                            <div style="margin-bottom: 4px; margin-top: 4px;">
                                                <div>
                                                    The system has experienced an error. You can click back on your browser and try
                                                    again.</div>
                                                <div>If the problem re-appears, you can report the error to here.<a  onclick="javascript:OpenEmailClient()"> Send report</a></div>
                                                <div class="only5px"></div> 
                                                <div><a href="<%=returnURL%>"> click here to go back</a></div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
    <table cellpadding="0" cellspacing="0" align="center" class="Error_report_Tbl">
        <tr>
            <td align="center">
                <div class="messageboxErrorSupport_ErrorPage">
                    <div>
                        The system has experienced an error. You can click back on your browser and try
                        again.
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" align="left" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:PlaceHolder ID="plhFooter" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
    <script>
        function OpenEmailClient() {

            location.href = "mailto:" + 'phil@hexicomsoftware.com' + "?cc=" + '' + "&subject=" + 'Error Report' + "&body=" + '' + "";
        }    
    </script>
</body>
</html>