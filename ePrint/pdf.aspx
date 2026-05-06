
<%@ page language="C#" autoeventwireup="true" CodeBehind="pdf.aspx.cs" Inherits="ePrint.pdf" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PDF Template</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divmsg" runat="server" style="display: none;">
        <table style="height: 100%; background-color: #FFFFFF" frame="border" width="779"
            border="0" cellspacing="0" cellpadding="0" align="center">
            <tr valign="top">
                <td>
                    <table width="779" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="images_home/header.gif" width="779" height="193">--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 100%;
                                    margin-top: 25%">
                                    <tr>
                                        <td align="center">
                                            <div class="messageboxSessionLogoutNew" style="padding: 6px 0px 5px 0px">
                                                <div>
                                                    <div style="padding: 10px 0px 0px 0px;">
                                                        <%=objLanguage.GetLanguageConversion("Sorry_file_resource_not_found")%></div>
                                                    <div class="only5px">
                                                    </div>
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
        </table>
    </div>
    <div align="center" style="padding: 12px">
        <iframe id="iframe_pdf" name="iframe_pdf" runat="server" width="90%" height="842px">
            <%--<%=strSitepath %>pdf_generate.aspx?page=<%=PageType %>&EstID=<%=EstimateID %>--%>
        </iframe>
        <script>
            var tempname = '<%=TemplateName %>';
            if (tempname == '') {
                document.getElementById("<%=divmsg.ClientID %>").style.display = 'block';
                document.getElementById("<%=iframe_pdf.ClientID %>").style.display = 'none';
            }
            else {
                document.getElementById("<%=iframe_pdf.ClientID %>").style.display = 'block';
                document.getElementById("<%=divmsg.ClientID %>").style.display = 'none';
                document.getElementById("<%=iframe_pdf.ClientID %>").src = "open_template.aspx?tempname=" + '<%=TemplateName %>' + "&CID=" + '<%=CompanyID %>';
            }
        </script>
    </div>
    </form>
</body>
</html>
