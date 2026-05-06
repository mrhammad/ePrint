<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchproducts.aspx.cs" Inherits="ePrint.MyPublicStore.products.searchproducts" masterpagefile="~/Templates/masterPageDefault.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/product_item.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-1.7.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager runat="server" ID="SM">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=companyID %>';

    </script>
    <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" VisibleTitlebar="true"
                VisibleStatusbar="false" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move">
                <ContentTemplate>
                    <div id="dialog">
                        <table>
                            <tr>
                                <td>
                                    <div id="divQuickAddnotification">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <img id="imgSucess" runat="server" alt="" />
                                                </td>
                                                <td>
                                                    <div id="divQuickaddLabelSucess">
                                                        <asp:Label ID="lblSucess" Text="ram" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr class="quickaddsplittd">
                                <td>
                                    <asp:Button ID="btnQuickNotificationOk" CssClass="btnConfirmationDialogueQuickAdd"
                                        runat="server" class="x-btn Grey main" OnClientClick="javascript:HideDialog();return false">
                                    </asp:Button>
                                </td>
                                <td>
                                    <asp:Button ID="btnGotoCart" runat="server" Text="Go to Shopping Cart" CssClass="btnConfirmationDialogueQuickAdd"
                                        OnClientClick="displayloading();return false"></asp:Button>
                                    <div id="div_btnGotoCart" class="btnGotoCartLoading">
                                        <img border="0" class="trans" src="<%=strSitePath %>images/radimg1.gif">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <div id="ProductCatagoryMain_div" class="contentArea_Background">
        <div class="navigation_div displayBlock">
            <a href="<%=strSitePath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <asp:Label ID="lbl_nav" runat="server" Text="Product Search"><%=objLanguage.GetLanguageConversion("Product_Search") %></asp:Label>
        </div>
        <div id="ProductCatagoryContent_div">
            <table id="SrchPrdct_Outer_tbl">
                <tr>
                    <td valign="top">
                        <div id="left_div" class="SrchPrdct_Details_Div">
                            <div id="heading" class="Header_Background">
                                <strong>&nbsp;&nbsp;&nbsp;<span id="spn_headding" runat="server">
                                    <%=objLanguage.GetLanguageConversion("Search_Results") %>
                                </span>&nbsp; </strong>
                                <asp:Label ID="lbl_searchResult" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                        </div>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <style type="text/css">
        .ProductCatagoryImage
        {
            max-width: 200px;
            max-height: 150px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        var Rewritemodule = '<%=Rewritemodule %>';
        function Onclick_Product(ID, Name) {
            if (Rewritemodule.toLowerCase() == "on") {
                window.location = '<%=strSitePath %>' + 'products/' + RemoveIllegalChars(Name) + KeySeparator + ID + KeySeparator + "1" + FileExtension;
            }
            else {
                window.location = "<%=strSitePath %>" + "products/productdetails.aspx?ID=" + ID + "&amp;type=1";
            }

        }

        function Onclick_My_product(PriceCatalogueCategoryID) {
            if (Rewritemodule.toLowerCase() == "on") {
                window.location = "<%=strSitePath %>" + "products" + KeySeparator + PriceCatalogueCategoryID + FileExtension;
            }
            else {
                window.location = "<%=strSitePath%>" + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
            }
        }

        function loadradwindow() {
            var RadPopupwin;
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            RadPopupwin.setSize(530, 180);
            RadPopupwin.show();
        }

        function closeredwindow() {
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            RadPopupwin.close();
        }

    </script>
</asp:Content>

