<%@ page language="C#" autoeventwireup="true" CodeBehind="account_new_create_withoutTemplate.aspx.cs" Inherits="ePrint.Account.account_new_create_withoutTemplate" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/usercontrol/Accounts/accounts_new_create.ascx" TagName="AccountAdd"
    TagPrefix="UC" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scptmanager" runat="server" ></asp:ScriptManager>
    <div>
        <div>
            <UC:AccountAdd ID="AccountNew" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
