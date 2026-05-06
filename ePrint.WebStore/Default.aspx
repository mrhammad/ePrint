<%@ Page Language="C#" MasterPageFile="~/Templates/masterPageDefault.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ePrint.WebStore.Default" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%#strSitePath %>js/general.js?VN='<%#VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%#strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-1.7.min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
    </script>
    <style type="text/css">
        .RadTreeView_Default .rtHover .rtIn {
            color: #777;
            border-color: #B7B7B7;
            background-color: #F5F5F5;
            background: #F5F5F5;
            border-radius: 3px;
        }

        .RadTreeView_Default .rtSelected .rtIn {
            color: #454545;
            border-color: #B7B7B7;
            background: #E1E1E1;
            border-radius: 3px;
        }

        .RadTreeView_Default, .RadTreeView_Default a.rtIn, .RadTreeView_Default .rtEdit .rtIn input {
            color: rgb(68, 68, 68);
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }

        .ProductCatagoryImage {
            max-width: 200px;
            max-height: 150px;
        }
    </style>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    </telerik:RadAjaxManager>
    <div align="center" id="contentArea">
        <div id="div_slidder" runat="server" class="DisplayNone">
            <div id="contentTop" class="DisplayBlock width100p">
                <div id="slider1">
                    <div id="slider">
                        <div id="mask-gallery">
                            <asp:PlaceHolder ID="plh_imageBanner" runat="server"></asp:PlaceHolder>
                        </div>
                        <div id="mask-excerpt">
                            <asp:PlaceHolder ID="plh_imageBannerDescription" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="contentbottom_outerdiv">
            <div id="contentbottom" class="DisplayBlock">
                <table class="width100p">
                    <tr>
                        <td class="floatLeft">
                            <div id="div_ProductsDetailsList" runat="server" class="left_div floatLeft overflow_Auto">
                                <div id="div_ProductsDetailsList_Header" class="center_div_header Header_Background">
                                    <strong>Product Categories </strong>
                                </div>
                                <div class="center_div_content TextAlignLeft floatLeft">
                                    <asp:PlaceHolder ID="plh_ProductsDetailsList" runat="server" Visible="false"></asp:PlaceHolder>
                                    <telerik:RadTreeView ID="radCategoryTree" runat="server" Enabled="true" CheckBoxes="false"
                                        CheckChildNodes="false" TriStateCheckBoxes="false" autopostbackoncheck="false"
                                        OnNodeExpand="RadTreeView1_NodeExpand" OnClientNodeCollapsed="onNodeCollapsed"
                                        Skin="Default" OnNodeClick="radCategoryTree_NodeClick" CssClass="radCategoryTree" />
                                </div>
                            </div>
                            <div class="floatLeft">
                                <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                        <td class="vertsep" style="display: <%=displayverticalsep%>;"></td>
                        <td>
                            <div>
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
                                                                                    <asp:Label ID="lblSucess" runat="server" Text="No items in cart"></asp:Label>
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
                                                                    runat="server" class="x-btn Grey main" OnClientClick="javascript:HideDialog();return false"></asp:Button>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnGotoCart" runat="server" Text="Go to Shopping Cart" CssClass="btnConfirmationDialogueQuickAdd"
                                                                    OnClientClick="displayloading();return false"></asp:Button>
                                                                <div id="div_btnGotoCart" class="btnGotoCartLoading">
                                                                    <img border="0" class="trans" src="images/radimg1.gif">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ContentTemplate>
                                        </telerik:RadWindow>
                                    </Windows>
                                </telerik:RadWindowManager>
                            </div>
                        </td>
                        <td class="width100p paddingRight5">
                            <div id="center_div">
                                <div id="divCustomTex" runat="server" class="DisplayNone">
                                    <asp:Label ID="lblCustomText" Text="" runat="server"></asp:Label>
                                </div>
                                <div id="div_headerCustomer" runat="server" class="center_div_header Header_Background">
                                    <strong class="floatLeft">
                                        <asp:Label ID="lbl_centerPaneltext" runat="server" Text="New Products"></asp:Label>
                                    </strong>
                                </div>
                                <div id="div_FeatureProducts" runat="server" class="div_FeatureProducts">
                                    <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                                </div>
                                <div id="div_NewProducts" runat="server" class="div_NewProducts">
                                    <asp:PlaceHolder ID="plh_NewProductsDetails" runat="server" Visible="true"></asp:PlaceHolder>
                                </div>
                                <div id="div_Customize" runat="server" class="div_Customize">
                                    <asp:PlaceHolder ID="plh_Customize" runat="server"></asp:PlaceHolder>
                                </div>
                                <div id="div_Customize_new" runat="server" class="div_customize_home">
                                    <asp:PlaceHolder ID="plh_Customize_new" runat="server"></asp:PlaceHolder>
                                </div>
                                <div id="div_customcat_repeater" class="width100p">
                                    <asp:Repeater ID="RepCustomproducts" runat="server">
                                        <ItemTemplate>
                                            <div class="productDetails_div">
                                                <div>
                                                    <div class="productName_div">
                                                        <label>
                                                            <%#Eval("Name") %>
                                                        </label>
                                                    </div>
                                                    <div class="clearBoth">
                                                    </div>
                                                    <div class="productImage_div">
                                                        <div class="productName_Link">
                                                            <a href='<%#Eval("Productpath") %>'>
                                                                <img title='<%#Eval("Image") %>' src='<%#Eval("ImagePath")%>' alt="" /></a>
                                                        </div>
                                                    </div>
                                                    <div class="clearBoth">
                                                    </div>
                                                    <div class='productCategoryDescription_div' title=''>
                                                        <label>
                                                            <%#Eval("Description") %>
                                                        </label>
                                                    </div>
                                                    <div class="clearBoth">
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </td>
                        <td class="widthAuto">
                            <div id="right_div" class="floatRight paddingRight5">
                                <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
    </div>
    <script type="text/javascript">
        var div_customcat_repeater = document.getElementById("div_customcat_repeater");
        var div_newproduct = document.getElementById('<%=div_NewProducts.ClientID %>'); //new products
        var div_FeatureProducts = document.getElementById('<%=div_FeatureProducts.ClientID %>'); // featured products
        var centrepaneltype = '<%=centrepaneltype%>';
    </script>
    <script type="text/javascript">
        var RewriteModule = '<%=RewriteModule %>';
        var centerDivWidth = '<%=centerDivWidth %>';
        var cnt_right = '<%=cnt_right %>';
        var cnt_getProductCatagories = '<%=cnt_getProductCatagories %>';
        var isProductCategory = '<%=isProductCategory %>';
        var isHomeRightBanner = '<%=isHomeRightBanner %>';
        var isRightBanner = '<%=isRightBanner %>';
        var right_div = document.getElementById("right_div");
        var center_div = document.getElementById("center_div");
        var div_Customize_new = document.getElementById("ctl00_ContentPlaceHolder1_div_Customize_new");
        var strSitePath = '<%=strSitePath%>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=CompanyID %>';


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
