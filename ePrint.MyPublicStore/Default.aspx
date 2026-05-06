<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ePrint.MyPublicStore.Default" MasterPageFile="~/Templates/MasterPageDefault.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="/js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>

    <script type="text/javascript" src="<%=strSitePath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="/js/jquery-ui.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager runat="server" ID="SM">
        <Services>
            <%-- <asp:ServiceReference Path="~/StoreAutoFill.asmx" />--%>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
  <%--   <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    </telerik:RadAjaxManager>--%>
    <script type="text/javascript" language="javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=CompanyID %>'
    </script>
      <%-- <style type="text/css">
        .RadTreeView_Default .rtHover .rtIn
        {
            color: #777;
            border-color: #B7B7B7;
            background-color: #F5F5F5;
            background: #F5F5F5;
            border-radius: 3px;
        }
        .RadTreeView_Default .rtSelected .rtIn
        {
            color: #454545;
            border-color: #B7B7B7;
            background: #E1E1E1;
            border-radius: 3px;
        }
        .RadTreeView_Default, .RadTreeView_Default a.rtIn, .RadTreeView_Default .rtEdit .rtIn input
        {
            color: rgb(68, 68, 68);
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        #ctl00_ContentPlaceHolder1_radCategoryTree{
             height : auto;
            min-height : 200px;
        }
    </style>--%>
    <div id="contentArea" class="contentArea_Background container-fluid plr-0">
        <br />
        <div id="div_slidder" runat="server" class="displayBlock">
            <div id="contentTop" class="displayBlock">
                <div id="slider1">
                    <!-- Image sliding with discrition starts (css/SlidingDescription.css) -->
                    <div id="slider">
                        <div id="mask-gallery">
                            <asp:PlaceHolder ID="plh_imageBanner" runat="server"></asp:PlaceHolder>
                            <asp:HiddenField ID="hdnBannerSliderTime" runat="server" />
                        </div>
                        <div id="mask-excerpt">
                            <asp:PlaceHolder ID="plh_imageBannerDescription" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="contentbottom" class="container-fluid">
            <div>
                <div class="row">
                    <div class="col-lg-2">
                        <div id="div_ProductsDetailsList" runat="server" class="left_div">
                            <div class="center_div_header Header_Background">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Product_Categories")%>
                                </strong>
                            </div>
                            <div class="center_div_content">
                                <asp:PlaceHolder ID="plh_ProductsDetailsList" runat="server"></asp:PlaceHolder>
                              <%--   <telerik:RadTreeView ID="radCategoryTree" runat="server" Enabled="true" CheckBoxes="false"
                                        CheckChildNodes="false" TriStateCheckBoxes="false" autopostbackoncheck="false"
                                        OnNodeExpand="RadTreeView1_NodeExpand" OnClientNodeCollapsed="onNodeCollapsed"
                                        Skin="Default" OnNodeClick="radCategoryTree_NodeClick" CssClass="radCategoryTree" />--%>
                            </div>
                        </div>
                        <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
                    </div>
                    <div id="sitemap_Backgroung" style="display: none">
                        <div>

                            <div class="SiteMap_PlcHoldr_Div">
                                <asp:PlaceHolder runat="server" ID="phSiteMap"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-10">
                        <div>
                            <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" VisibleTitlebar="true"
                                        VisibleStatusbar="false" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move" AutoSize="true" AutoSizeBehaviors="WidthProportional">
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
                        <div id="center_div">
                            <div id="divCustomTex" runat="server" class="displayNone">
                                <asp:Label ID="lblCustomText" Text="" runat="server"></asp:Label>
                            </div>
                            <div id="div_headerCustomer" runat="server" class="center_div_header Header_Background">
                                <strong>
                                    <asp:Label ID="lbl_centerPaneltext" runat="server" Text="New Products"></asp:Label>
                                </strong>
                            </div>
                            <div id="div_FeatureProducts" runat="server" class="FeatureProducts_Div">
                                <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                            </div>
                            <div id="div_NewProducts" runat="server" class="NewProducts_Div" style="text-align: -webkit-center">
                                <asp:PlaceHolder ID="plh_NewProductsDetails" runat="server" Visible="true"></asp:PlaceHolder>
                            </div>
                            <div id="div_Customize" runat="server" class="Div_404 displayNone">
                                <asp:PlaceHolder ID="plh_Customize" runat="server"></asp:PlaceHolder>
                            </div>
                            <div id="div_Customize_new" runat="server" class="div_customize_home">
                                <asp:PlaceHolder ID="plh_Customize_new" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div id="right_div">
                            <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
    <%-- <script type="text/javascript">
         function onNodeCollapsed(sender, args) {
             $find("ctl00_ContentPlaceHolder1_RadAjaxManager1").ajaxRequest();
         }
     </script>--%>
    <style type="text/css">
        .ProductCatagoryImage {
            max-width: 200px;
            max-height: 150px;
        }
    </style>
    <script type="text/javascript">

        var RewriteModule = '<%=RewriteModule %>';
        var centerDivWidth = '<%=centerDivWidth %>';
        var cnt_right = '<%=cnt_right %>';
        var cnt_getProductCatagories = '<%=cnt_getProductCatagories %>';
        var isProductCategory = '<%=isProductCategory %>';
        var isHomeRightBanner = '<%=isHomeRightBanner %>';
        var count_leftbanner = '<%=count_leftbanner %>';
        var isRightBanner = '<%=isRightBanner %>';
        var newProductCount = '<%=newProductCount %>';
        var right_div = document.getElementById("right_div");
        var center_div = document.getElementById("center_div");
        var div_Customize_new = document.getElementById("ctl00_ContentPlaceHolder1_div_Customize_new");

        function Onclick_Product(ID, Name) {
            if (RewriteModule.toLowerCase() == "on") {
                window.location = "<%=strSitePath %>" + "products/" + RemoveIllegalChars(Name) + KeySeparator + ID + KeySeparator + "0" + FileExtension;
            }
            else {
                window.location = "<%=strSitePath %>" + "products/productdetails.aspx?ID=" + ID + "&amp;type=0";
            }
        }
        function Onclick_Login(ID, Name) {
            ShowLoginonProduct(ID, Name);
        }

        function setWidth() {
            if (AccountType == 'p') {

            }
            else {
                if (isProductCategory == "1") {
                    if (cnt_right == 0) {

                        right_div.style.border = "none";
                        right_div.style.width = "0px";
                        //center_div.style.width = "755px";
                    }

                    if (centerDivWidth == 2) {
                        //center_div.style.width = "575px";
                    }
                    else if (centerDivWidth == 3) {
                        //center_div.style.width = "755px";
                    }
                    else if (centerDivWidth == 4) {
                        //center_div.style.width = "942px";
                    }
                }


                if (isHomeRightBanner == '1' && isProductCategory == "0" && centerDivWidth == 3) {//isHomeRightBanner = 0 means it will not display in home page(from db)
                    //center_div.style.width = "755px";
                    div_Customize_new.style.width = '755px';
                }
                if (count_leftbanner != '0' && isProductCategory == "0" && centerDivWidth == 3) {//count_leftbanner != 0 means it will display in home page
                    //center_div.style.width = "755px";
                    div_Customize_new.style.width = '755px';
                }
                if (count_leftbanner != '0' && cnt_right != '0' && isProductCategory == "0") {
                    //center_div.style.width = "575px";
                    div_Customize_new.style.width = '575px';
                }
                if (count_leftbanner == '0' && cnt_right == '0' && isProductCategory == "0" && centerDivWidth == 4) {
                    //center_div.style.width = "942px";
                }

                else if (isHomeRightBanner == '0' && isProductCategory != "0") {
                    right_div.style.display = "none";
                    right_div.style.border = "none";
                    right_div.style.width = "0px";
                    //center_div.style.width = "755px";
                }

                else {
                    if (cnt_right == 0) {
                        right_div.style.display = "none";
                        right_div.style.border = "none";
                        right_div.style.width = "0px";
                    }
                }

                if (div_Customize_new.style.display == 'block') {
                    if (isRightBanner == '0') {

                        right_div.style.display = "none";
                        if (centerDivWidth == 4) {
                            div_Customize_new.style.width = '942px';
                            //center_div.style.width = "942px";
                        }
                        else {
                            div_Customize_new.style.width = '755px';
                            // center_div.style.width = "755px";
                        }

                    }
                    else {
                        right_div.style.display = "block";
                        right_div.style.border = "none";
                        //// div_Customize_new.style.width = '575px';
                        //// center_div.style.width = "575px";
                    }
                }

            }
            if (newProductCount == 0 && cnt_right == '0' && count_leftbanner == '0' && isProductCategory == '0') {
                // center_div.style.width = "942px";
            }
        }
        window.onload = setWidth;

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

        function shouldMakeAdaptiveRadWindow() {
            //true for touch devices that are narrower than 768px which is a common tablet size
            return Telerik.Web.BrowserFeatures.touchEvents && $telerik.$(window).width() < 768;
        }

        function OnClientShow(sender, args) {
            if (shouldMakeAdaptiveRadWindow()) {
                //leave only the close button
                sender.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                sender.set_visibleStatusbar(false);
                //maximize so it takes up the entire viewport and reacts to size changes
                sender.maximize();
            }
        }



    </script>

    <script type="text/javascript">
        (function () {
            /*var lst = $('.SiteMap_PlcHoldr_Div > ul > li');
            lst[0].style.display = 'none';
            lst[2].style.display = 'none';
            lst[3].style.display = 'none';
            lst[4].style.display = 'none';
            
            $('.SiteMap_PlcHoldr_Div > ul > li > a').each(function () {
                if ($(this).text() == 'Products')
                    $(this).text('');
            });
            $('..center_div_content').focusout(function () {
                $('.SiteMap_PlcHoldr_Div').hide();
            });
            $('.SiteMap_PlcHoldr_Div').hide();*/

        })();
        function settooltip(id) {
            debugger
            var data = document.getElementById(id).textContent;
            var elementfortooltip = 'div' + id;
            document.getElementById(elementfortooltip).setAttribute('title', data);
        }
        function showsubcat(id) {
            $('.SiteMap_PlcHoldr_Div').show();
            var lstdiv = $('.center_div_content > div');
            var lstid = [];
            for (var i = 0; i < lstdiv.length; i++) {
                lstid.push(lstdiv[i].id.slice(3));
            }

            for (var j = 0; j < lstid.length; j++) {
                if (id == lstid[j]) {
                    $('#' + lstid[j]).show();
                }
                else {
                    $('#' + lstid[j]).hide();
                }
            }

        }
    </script>


    <%-- <script type="text/javascript">
        SendRequest();
        function SendRequest() {
            debugger;
            var message = ePrint.PublicStores.AutoFill.CalculateFormulaCost(1, 1, message, onTimeout, onError);
        }
        function message(result) {
            debugger;
        }
        function onTimeout(request, context) { }
        function onError(er) {
            debugger;
        }
    </script>--%>
</asp:Content>



