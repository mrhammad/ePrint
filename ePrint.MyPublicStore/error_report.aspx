<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error_report.aspx.cs" Inherits="ePrint.MyPublicStore.error_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="<%=StyleSheetPathMaster +"/Themes/StyleSheet.css"%>" id="MainStyle1"
        rel="Stylesheet" type="text/css" />
    <link href="<%=StyleSheetPath +"/Themes/StyleSheet.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <link href="<%=StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link1" rel="Stylesheet"
        type="text/css" />
    <style type="text/css">
        *
        {
            margin: auto;
        }
        
        caption, th, td
        {
            text-align: center;
        }
        
        a
        {
            color: -webkit-link;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    <table  class="ErrorReport_Maintable" frame="border" cellspacing="0" cellpadding="0"
        align="center">
        <tr>
            <td>                
               <table align="center" cellspacing="0" cellpadding="0">
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table cellpadding="0" cellspacing="0" align="center" class="ErrorReport_Msgtable">
                                <tr>
                                    <td align="center">
                                        <div class="messageboxErrorSupport_ErrorPage">
                                            <div class="ErrorReport_Msg_Div">
                                            <div>The system has experienced an error. You can click back on your browser and try again.</div>
                                            <%--<div>If the problem re-appears, you can report the error to here.<a  onclick="javascript:OpenEmailClient()"> Send report</a></div>--%>
                                            <%--<div class="only5px"></div> --%>
                                            <%--<div><a href="<%=returnURL%>"> click here to go back</a></div>--%>
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
   <table class="width100p" align="left" cellspacing="0" cellpadding="0">
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
