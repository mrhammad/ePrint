<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_template.aspx.cs" Inherits="ePrint.MyPublicStore.products.edit_template" MasterPageFile="~/Templates/masterPageDefault.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <div class="navigation_div navigation_div_editProd" id="navigation_div" runat="server">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="#" onclick="Onclick_My_product('0')">
                <asp:Label ID="lbl_nav_catagoty" runat="server" Text="Product Categories"><%=objLanguage.GetLanguageConversion("Product_Categories")%></asp:Label></a>&nbsp;>
            <a href="#" onclick="Onclick_My_product('<%=PriceCatalogueCategoryID %>')">
                <asp:Label ID="lbl_nav_product" runat="server" Text=""></asp:Label></a> >
            <asp:Label ID="lbl_nav_productName" runat="server" Text=""></asp:Label>
        </div>
        <div class="editableProduct_div1 col-lg-12 col-xs-12" id="editableProduct_div1" runat="server" align="center">
            <div style="float: right;" id="div_expandBtn" runat="server">
                <asp:Button ID="btnExpand" runat="server" Text="" OnClick="Expand_OnClick" ToolTip="Expand"
                    Style="background-image: url(../images/StoreImages/image_07_rgt.png); width: 20px;
                    height: 25px; display: block; box-shadow: 0px 1px 4px rgba(0, 0, 0, 0.2);" />
            </div>
            <div class="editableProduct_div2" style="height: 701px;">
                <div class="editableProduct_div3">
                    <asp:HtmlIframe id="Iframe1" runat="server" frameborder="1" marginwidth="1" class="editableProduct_Iframe col-lg-12 col-xs-12">
                    </asp:HtmlIframe>
                </div>
            </div>
        </div>
    </div>
    <a name="EditTemplate"></a>
    <script type="text/javascript" src="<%=strSitepath %>js/products.js?VN='<%=VersionNumber%>'"></script>
</asp:Content>
