<%@ page language="C#" autoeventwireup="true" CodeBehind="ProductCatalogueSubAdditionOption_Allocation.aspx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogueSubAdditionOption_Allocation" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/usercontrol/ProductCatalogue/ProductCatalogueSubAdditionOption_Allocation.ascx" TagName="ProductCatalogueSubAdditionOption"
    TagPrefix="UC" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scr1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" src="../js/item/ProductCatalogue.js"></script>
    <div>
        <UC:ProductCatalogueSubAdditionOption ID="AllocationID" runat="server" />
        <%--<UC:ProductCatalogueSubAdditionOption ID="AllocationID1" runat="server" />--%>
    </div>
    </form>
</body>
</html>

