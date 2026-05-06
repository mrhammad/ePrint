<%@ page language="C#" autoeventwireup="true" CodeBehind="logout.aspx.cs" Inherits="ePrint.logout" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" align="center" style="width:100%; height:100%;">
                <tr>
                    <td align="center" style="height:500px">                       
                            <div class="messageboxlogout">
                                <div style="margin-bottom:4px;margin-top:4px;">                                           
                                <div><b><asp:Label ID ="lbl_ThankyouNote" runat="server"></asp:Label> </b></div>
                                <div class="onlyEmpty"></div>
                                <div><a href='~/Login/Login.aspx'><asp:Label ID ="lbl_ClickHere" runat="server"></asp:Label></a></div>
                                </div>
                            </div>                                  
                    </td>
                </tr>
            </table>
           </div>       
    </form>
</body>
</html>
