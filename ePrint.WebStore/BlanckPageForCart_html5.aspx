<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlanckPageForCart_html5.aspx.cs" Inherits="ePrint.WebStore.BlanckPageForCart_html5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  
</head>
<body class="Template_Body">
    <form id="form1" runat="server">
    <div class="Template_OuterDiv">
        <asp:Image ID="LoadingImage" CssClass="Template_Image" runat="server" />
        <br />
        <asp:Label ID="Label1" Text="Please Wait Saving Data..." runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
