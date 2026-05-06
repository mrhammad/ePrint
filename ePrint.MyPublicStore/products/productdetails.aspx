<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="ePrint.MyPublicStore.products.productdetails" masterpagefile="~/Templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">
        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }
    </script>
    <script type="text/javascript" src="../js/min.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/popup.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/ImageMagnifier/jquery-1.6.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/ImageMagnifier/jquery.jqzoom-core.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/ImageMagnifier/jquery.jqzoom-core-pack.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery.min_new.js" type="text/javascript?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/jquery.easing.1.3.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">

        var strSitepath = '<%=strSitepath %>';
        var PriceCatalogueID = '<%=PriceCatalogueID %>';
        var CompanyID = '<%=CompanyID %>';
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var TheURL = '<%=TheURL %>';
        var ServerName = '<%=ServerName %>'
        var MeasurementValue_Sq = '<%=MeasurementValue_Sq %>';
        var Rewritemodule = '<%=Rewritemodule %>'; //modification
        var Please_enter_dimension = '<%=objLanguage.GetLanguageConversion("Please_enter_dimension") %>';
        var Please_enter_height = '<%=objLanguage.GetLanguageConversion("Please_enter_height") %>';
        var Please_enter_width = '<%=objLanguage.GetLanguageConversion("Please_enter_width") %>';
        var Minimum_Quantity_Is = '<%=objLanguage.GetLanguageConversion("Minimum_Quantity_Is")%>';
        var Maximum_Quantity_is = '<%=objLanguage.GetLanguageConversion("Maximum_Quantity_is")%>';
        var Minimum_Dimension_Is = '<%=objLanguage.GetLanguageConversion("Minimum_Dimension_Is") %>';
        var Maximum_Dimension_Is = '<%=objLanguage.GetLanguageConversion("Maximum_Dimension_Is") %>';
        var No_Stock_with_no_backorder_msg = '<%=objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock")  %>' + '.</br>' + '<%=objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order") %>';
        var No_Stock_with_backorder_msg = '<%=objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock") %>' + '.</br>' + '<%=objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order") %>';


        $(document).ready(function () {
            $('.jqzoom').jqzoom({
                zoomType: 'reverse',
                lens: true,
                preloadImages: false,
                alwaysOn: false
            });
            //$('.jqzoom').jqzoom();
        });

    </script>
    <style type="text/css">
        .common-sprite {
            background-image: url('../images/common_sprite_v1.png');
            background-repeat: no-repeat;
        }
    </style>
    <div id="productDetails_Main_Div">
        <div id="productMain_div" class="contentArea_Background">
            <div class="navigation_div displayBlock" id="navigation_div" runat="server">
                <a href="<%=strSitepath %>">
                    <asp:Label ID="lbl_home" runat="server"></asp:Label>
                </a>
                <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
                <a href="#" onclick="Onclick_My_product('0')">
                    <asp:Label ID="lbl_nav_catagoty" runat="server" Text="Product Categories"><%=objLanguage.GetLanguageConversion("Product_Categories")%></asp:Label></a>&nbsp;>
                <a href="#" onclick="Onclick_My_product('<%=PriceCatalogueCategoryID %>')">
                    <asp:Label ID="lbl_nav_product" runat="server" Text=""></asp:Label></a> >
                <asp:Label ID="lbl_nav_productName" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbl_nav" runat="server" Text=""></asp:Label>
            </div>
            <div class="navigation_div displayNone" id="div_searchProduct" runat="server">
                <a href="<%=strSitepath %>">Home</a> > <a href="#" onclick="Onclick_Searchproduct('<%=searchCookie %>')">
                    <asp:Label ID="href_Searchproduct" runat="server" Text=""></asp:Label>
                </a>>
                <asp:Label ID="lbl_Searchproduct" runat="server" Text=""></asp:Label>
            </div>
            <div id="productMain_div_border">
                <div align="center" id="productMain_Innerdiv">
                    <asp:Panel ID="pnlNormalDetails" runat="server">
                        <div id="top_div">
                            <asp:PlaceHolder ID="plhFirst" runat="server"></asp:PlaceHolder>
                            <div id="heading" class="Header_Background">
                                <strong>&nbsp;&nbsp;<asp:Label ID="lbl_CatalogueName1" runat="server"></asp:Label></strong>
                            </div>
                            <asp:PlaceHolder ID="plh_innertable_starting" runat="server"></asp:PlaceHolder>
                            <div id="image"  style="text-align: -webkit-center;">
                                <div class="clearfix" id="content">
                                    <div class="clearfix">
                                        <a id="cards1" runat="server" class="jqzoom" rel='gal1'>
                                            <img id="cards" style="max-width:250px;max-height:300px;" runat="server" alt=" ">
                                        </a>&nbsp;&nbsp;&nbsp;
                                    </div>
                                </div>
                            </div>
                            <div id="div_PrintReadyFile" runat="server" class="displayNone">
                                <asp:Label ID="lblPrintReadyFile" runat="server" CssClass="Normaltext"></asp:Label><br />
                            </div>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="rightPanel">
                                <div id="div_ProductPriceList" runat="server">
                                    <div id="rightPanel_Col1">
                                        <div id="rightPanel_heading" class="Header_Background">
                                            <strong>
                                                <asp:Label ID="Label" runat="server" Text="Price Band (ex Tax)"><%=objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket")%></asp:Label></strong>
                                        </div>
                                        <div id="priceBand">
                                            <div id="div_PriceList">
                                                <asp:PlaceHolder ID="plhPriceList" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <div id="div_PriceListMore" class="displayNone">
                                                <asp:PlaceHolder ID="plhPriceListMore" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <asp:HiddenField ID="hid_qtyFromList" runat="server" />
                                            <asp:HiddenField ID="hid_qtyToList" runat="server" />
                                            <asp:HiddenField ID="hid_CostExcMarkupList" runat="server" />
                                            <asp:HiddenField ID="hid_MarkupList" runat="server" />
                                            <asp:HiddenField ID="hid_priceList" runat="server" />
                                            <asp:HiddenField ID="hdnsoldPackOV" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:PlaceHolder ID="plh_innertable_middle_tds" runat="server"></asp:PlaceHolder>
                            <asp:HiddenField ID="hdnIsBackOrder" runat="server" />
                            <asp:HiddenField ID="hdnPriceCatalogueID" runat="server" />
                            <asp:HiddenField ID="hdnDrawStockFrom" runat="server" />
                            <asp:HiddenField ID="hdnStockManagement" runat="server" />
                            <asp:HiddenField ID="hdnIsShowStock" runat="server" />
                            <asp:HiddenField ID="hdnAvailableQty" runat="server" />
                            <asp:HiddenField ID="hdnMashDivHeight" runat="server" />
                            <asp:HiddenField ID="hdnIsStockItem" runat="server" Value="" />
                            <asp:HiddenField ID="hdnWebOtherCostID" runat="server" />
                            <asp:HiddenField ID="hdnStockAddOption" runat="server" />
                            <asp:HiddenField ID="hdnselectedddlmultipleid" runat="server" />
                            <asp:HiddenField ID="hdnselectedwebothercostid" runat="server" />
                            <div id="divMask" runat="server" class="MaskDiv displayNone">
                            </div>
                            <asp:PlaceHolder ID="plh_Contents" runat="server"></asp:PlaceHolder>
                            <br />
                            <div class="textalignLeft">
                                <h3>
                                    <asp:Label ID="lbl_CatalogueName2" runat="server"></asp:Label></h3>
                            </div>
                            <div id="pnlStockMessage" runat="server" class="displayNone">
                                <asp:Label ID="lblStockMessage" runat="server" Text="Stock Not Available" CssClass="colorRed"></asp:Label>
                                <div class="clearBoth paddingTop10">
                                </div>
                            </div>
                            <div class="textalignLeft" runat="server">
                                <h4>
                                    <asp:Label ID="lblSubProductName" runat="server"></asp:Label></h4>
                            </div>
                            <div id="prod_description" style="word-break: break-all;">
                                <asp:Label ID="lbl_Description" runat="server"></asp:Label>
                            </div>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="divCustCode" class="displayNone">
                                <div class="floatLeft">
                                    <%=objLanguage.GetLanguageConversion("Customer_Code") %>:
                                </div>
                                <div class="productDetails_code_OuterDiv">
                                    <asp:Label runat="server" ID="lblCustomerCode"></asp:Label>
                                </div>
                            </div>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="divItemCode" class="displayNone">
                                <div class="floatLeft">
                                    <%=objLanguage.GetLanguageConversion("Item_Code") %>:
                                </div>
                                <div class="productDetails_code_OuterDiv">
                                    <asp:Label runat="server" ID="lblItemCode"></asp:Label>
                                </div>
                            </div>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="div_ProductOptions" runat="server" style="display: none;">
                                <div id="div_Product" class="floatLeft" style="width: 300px;">
                                    <asp:Label ID="lblSelectOption" runat="server" Text="Select the Options"></asp:Label>
                                    <span id="Spn_PrdoMandatory" runat="server" class="mandatoryField">*</span><br />
                                    <asp:DropDownList ID="ddlProductList" runat="server" Style="float: left; margin-right: 3%; width: 300px;"
                                        OnSelectedIndexChanged="ddlProductList_OnSelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <div id="div_ProdSelectErrorMSG" runat="server" style="display: none">
                                        <span id="Span2" runat="server" style="float: left; color: Red;">Plese select
                                            your product</span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="priceStartsFrom" class="paddingBottom10">
                                <asp:Label ID="lbl_priceStartsFrom" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_priceStartsFrom1" runat="server" CssClass="Stock_Pricestarts_SoldInPacks_lbl"></asp:Label>
                            </div>
                            <div id="divStockStatus" runat="server" class="displayNone">
                                <asp:Label ID="lbl_stockStatus" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_stockStatus1" runat="server" CssClass="Stock_Pricestarts_SoldInPacks_lbl"
                                    Text=""></asp:Label>
                            </div>
                            <div id="div_soldinpack" runat="server" class="displayNone">
                                <div id="ShowSoldInPacksOf" class="paddingBottom10">
                                    <asp:Label ID="lbl_ShowSoldInPacksOf" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lbl_ShowSoldInPacksOf1" runat="server" CssClass="Stock_Pricestarts_SoldInPacks_lbl"></asp:Label>
                                </div>
                            </div>
                            <asp:PlaceHolder ID="plh_above_div_PriceStartFrom" runat="server"></asp:PlaceHolder>
                            <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
                            <div class="clearBoth paddingTop5">
                            </div>
                            <div id="div_Below_Desc" class="col-lg-12 col-xs-5" runat="server">
                                <div id="artwork_div_no_addoption" class="artwork_div_no_addoption" runat="server">
                                    <div class="horizontal_lineFull">
                                    </div>
                                    <div class="artwork_header_no_addoption">
                                        <%=objLanguage.GetLanguageConversion("Artwork")%>
                                    </div>
                                    <div class="artwork_content_div_no_addoption">
                                        <div class="artwork_content_lbl_no_addoption">
                                            <asp:Label ID="lblupload" runat="server"></asp:Label>
                                        </div>
                                        <div id="div_artwork_content_fileupload_no_addoption" class="artwork_content_fileupload_no_addoption"
                                            runat="server">
                                            <div>
                                                <asp:FileUpload ID="fp_artwork_no_addoption1" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                <span id="spn_artworkFile1" runat="server" class="FileUpload_Validation_Msg">This is
                                                    a required field.</span>
                                            </div>
                                            <div>
                                                <asp:FileUpload ID="fp_artwork_no_addoption2" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                            </div>
                                            <div>
                                                <asp:FileUpload ID="fp_artwork_no_addoption3" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div class="AddToCart_Btn1_OuterDiv">
                                    <div id="div_btnAddtoCart1" runat="server" class="AddToCart_Btn1_InnerDiv">
                                        <asp:Button ID="btnAddtoCart1" runat="server" Text="Add to Cart" class="WS_Buttons_Style"
                                            Style="<%=AddBtn_Style%>" OnClientClick="javascript:var a=Save_toCart('no');if(a)loadingimage(this.id,'div_btnAddToCartProcess1');return a;"
                                            OnClick="btnAddtoCart_Click" />
                                    </div>
                                    <div id="div_btnAddToCartProcess1" class="WS_Buttons_Style displayNone textalignCenter floatRight">
                                        <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                    </div>
                                    <div id="div_btnsave2" class="DisplayBlock floatRight">
                                        <asp:Button ID="EditProduct1" OnClientClick="javascript:var a=Save_toCart('no');if(a)loadingimage(this.id,'div_btnAddToCartProcess1');return a;"
                                            OnClick="btnEditTemplate_Click" runat="server" Text="Edit Product" class="WS_Buttons_Style" />
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="price_calculator" style="<%=price_calculator_Style%>">
                                    <div class="displayNone">
                                        <a href="#">Can't find the option you need</a>
                                    </div>
                                    <div id="Price_CalculatorWithAddition" runat="server">
                                        <div id="price_table">
                                            <div class="horizontal_line">
                                            </div>
                                            <div id="price_table_header" style="<%=price_table_header_Style%>">
                                                <%=objLanguage.GetLanguageConversion("Additional_Options")%>
                                                <%--<%=objLanguage.GetLanguageConversion("Please_Select_Your_Options_Below")%>--%>
                                            </div>
                                            <div id="col-lg-12 col-xs-5 price_table_content">
                                                <asp:PlaceHolder ID="plhPriceCalculator" runat="server" Visible="true"></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <%--<br />--%>
                                        <div id="artwork_div" class="artwork_div" runat="server">
                                            <div class="horizontal_line">
                                            </div>
                                            <div class="artwork_header">
                                                <%=objLanguage.GetLanguageConversion("Artwork")%>
                                            </div>
                                            <div class="artwork_content_div">
                                                <div class="artwork_content_lbl">
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </div>
                                                <div class="artwork_content_fileupload">
                                                    <div>
                                                        <asp:FileUpload ID="fp_artwork" runat="server" size="32" CssClass="fp_artwork" />
                                                        <span id="spn_artworkFile" runat="server" class="displayNone colorRed">
                                                            <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                                    </div>
                                                    <div>
                                                        <asp:FileUpload ID="fp_artwork1" runat="server" size="32" CssClass="fp_artwork" />
                                                    </div>
                                                    <div>
                                                        <asp:FileUpload ID="fp_artwork2" runat="server" size="32" CssClass="fp_artwork" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div class="AddToCart_Btn2_OuterDiv">
                                            <div id="div_btnAddCart">
                                                <asp:Button ID="btnAddtoCart" runat="server" Text="Add to Cart" class="WS_Buttons_Style"
                                                    OnClientClick="javascript:var a=Save_toCart('yes');if(a)loadingimage(this.id,'div_btnAddtocartProcess');return a;"
                                                    OnClick="btnAddtoCart_Click" />
                                            </div>
                                            <div id="div_btnAddtocartProcess" class='WS_Buttons_Style displayNone floatRight'>
                                                <center>
                                                    <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                                </center>
                                            </div>
                                            <div id="div_btnsave4" class="DisplayBlock floatRight">
                                                <asp:Button ID="EditProduct2" OnClientClick="javascript:var a=Save_toCart('yes');if(a)loadingimage(this.id,'div_btnAddtocartProcess');return a;"
                                                    OnClick="btnEditTemplate_Click" runat="server" Text="Edit Product" class="WS_Buttons_Style" />
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <%--<div class="clear">
                                    </div>--%>
                                </div>
                            </div>
                            <div class="textalignLeft">
                                <h3>
                                    <asp:Label ID="lbl_CatalogueName2_2" style="display: none;" runat="server"></asp:Label></h3>
                            </div>
                            <div id="prod_description_2"   style="display: none; word-break: break-all;">
                                <asp:Label ID="lbl_Description_2" runat="server"></asp:Label>
                            </div>
                            <div id="div_PrintReadyFile_2" runat="server" style="display: none;" class="displayNone">
                                <asp:Label ID="lblPrintReadyFile_2" runat="server" CssClass="Normaltext"></asp:Label><br />
                            </div>
                            <asp:PlaceHolder ID="plh_below_div_Below_desc" runat="server"></asp:PlaceHolder>
                            <div id="rightPanel_image">
                                <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                            </div>
                            <asp:PlaceHolder ID="plhLast" runat="server"></asp:PlaceHolder>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlConfirmPRFile" runat="server" CssClass="displayNone">
                        <div>
                            <table class="prod_detls_prntRdyFle_Tbl">
                                <tr>
                                    <td id="td_chkconform" align="center" colspan="3">
                                        <asp:CheckBox ID="chkconform" runat="server" Text=" I have previewed the PDF and consider it to be correct" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="prod_detls_prntRdyFle_SideCell"></td>
                                    <td class="prod_detls_prntRdyFle_CenterCell" align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnBackToProDet" class="WS_Buttons_Style" runat="server" Text="Back"
                                                        OnClientClick="javasript:BackTo();return false;" /><%--OnClick="btnBackToProDet_Click"--%>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_ConfirmAdd1" class="WS_Buttons_Style displayNone" runat="server"
                                                        Text="Confirm and Add To Cart" OnClick="btnback_Click" />
                                                    <asp:Button ID="btn_ConfirmEditTemplate1" class="WS_Buttons_Style displayNone" runat="server"
                                                        Text="Confirm and Edit Template" OnClick="btn_ConfirmEditTemplate_Click" />
                                                    <div id="divConfirmandAdd" class="WS_Buttons_Style" align="center">
                                                        <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="prod_detls_prntRdyFle_SideCell"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:HtmlIframe runat="server" id="pdfframe"  scrolling="no" title="pdf preview" class="prod_details_iframe_style"></asp:HtmlIframe>
                                       

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div id="bottom_div" class="height100p">
                    <div id="subHeading_header">
                        <strong>&nbsp;&nbsp;Instant Price Quote </strong>
                    </div>
                    <div id="subHeading_content">
                        <table>
                            <tr>
                                <td valign="top">
                                    <div id="left">
                                        <strong>
                                            <asp:Label ID="lbl_CatalogueName3" runat="server"></asp:Label></strong><br />
                                        <h2>Price Bands</h2>
                                        <asp:HiddenField ID="hid_matixType" runat="server" />
                                        <div id="div_PriceTable" runat="server">
                                            <div class="clearBoth floatLeft">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td valign="top"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hid_QuantityPrice" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup" runat="server" />
            <asp:HiddenField ID="hid_Markup" runat="server" />
            <asp:HiddenField ID="hid_QuestionLenght" runat="server" />
            <asp:HiddenField ID="hid_MultipleLenght" runat="server" />
            <asp:HiddenField ID="hid_MatrixLenght" runat="server" />
            <asp:HiddenField ID="hid_SaveToCart" runat="server" />
            <asp:HiddenField ID="hid_SaveToCartItems" runat="server" />
            <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
            <asp:HiddenField ID="hid_TempTotalPrice" runat="server" />
            <asp:HiddenField ID="hdnShowPriceSubtotalTax" runat="server" />
             <asp:HiddenField ID="hdnShowUnitPrice" runat="server" />
             <asp:HiddenField ID="hdnShowPackPrice" runat="server" />

            <asp:HiddenField ID="hdn_orderedheight" runat="server" />
            <asp:HiddenField ID="hdn_orderedwidth" runat="server" />
            <asp:HiddenField ID="hdn_orderedarea" runat="server" />
            <asp:HiddenField ID="hdn_orderedquantity" runat="server" />
        </div>
    </div>
    <asp:HiddenField ID="hdnPrintReadyFile" runat="server" Value="" />
    <asp:HiddenField ID="hdnSingleQuestionValues" runat="server" Value="" />
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        function setHeight() {
            document.getElementById('ctl00_ContentPlaceHolder1_hdnMashDivHeight').value = document.getElementById("productMain_div_border").offsetHeight + "px";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("productMain_div_border").offsetHeight + "px";
        }

    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/products.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        var RequestType = '<%=RequestType %>';
        var hdnPrintReadyFile = document.getElementById("<%=hdnPrintReadyFile.ClientID %>");

        var artworkFile = '<%=artworkFile%>';
        var spn_artworkFile = document.getElementById("<%=spn_artworkFile.ClientID %>");
        var spn_artworkFile1 = document.getElementById("<%=spn_artworkFile1.ClientID %>");
        var fp_artwork = document.getElementById("<%=fp_artwork.ClientID %>");
        var fp_artwork_no_addoption1 = document.getElementById("<%=fp_artwork_no_addoption1.ClientID %>");

        var hid_matixType = document.getElementById("<%=hid_matixType.ClientID %>");

        var hid_qtyFromList = document.getElementById("<%=hid_qtyFromList.ClientID %>");
        var hid_qtyToList = document.getElementById("<%=hid_qtyToList.ClientID %>");
        var hid_priceList = document.getElementById("<%=hid_priceList.ClientID %>");
        var hid_CostExcMarkupList = document.getElementById("<%=hid_CostExcMarkupList.ClientID %>");
        var hid_MarkupList = document.getElementById("<%=hid_MarkupList.ClientID %>");
        var hdnsoldPackOV = document.getElementById("<%=hdnsoldPackOV.ClientID %>");
        var hid_Markup = document.getElementById("<%=hid_Markup.ClientID %>");
        var hid_QuantityPrice = document.getElementById("<%=hid_QuantityPrice.ClientID %>");
        var hid_QuantityPriceExcMarkup = document.getElementById("<%=hid_QuantityPriceExcMarkup.ClientID %>");

        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");
        var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
        var hid_MatrixLenght = document.getElementById("<%=hid_MatrixLenght.ClientID %>");

        var hid_SaveToCart = document.getElementById("<%=hid_SaveToCart.ClientID %>");
        var hid_SaveToCartItems = document.getElementById("<%=hid_SaveToCartItems.ClientID %>");
        var hid_SaveToAdditionalItems = document.getElementById("<%=hid_SaveToAdditionalItems.ClientID %>");
        var hid_TempTotalPrice = document.getElementById("<%=hid_TempTotalPrice.ClientID %>");

        var txtHeight = document.getElementById("txtHeight");
        var txtWidth = document.getElementById("txtWidth");

        var lbltotal = document.getElementById("lbltotal");
        var TotalTaxValue = document.getElementById("lblTotalTax").innerHTML.replace("javascript:GetCurrencyinRequiredFormate('', true);", '');
        var TotalSellingPriceValue = document.getElementById("lblTotalSellingPrice").innerHTML.replace("javascript:GetCurrencyinRequiredFormate('', true);", '');
        var hdnSingleQuestionValues = document.getElementById("<%=hdnSingleQuestionValues.ClientID %>");

        var hdnlbltotal = document.getElementById("hdnlbltotal");
        var hdnTotalTaxValue = document.getElementById("hdnlblTotalTax");
        var hdnTotalSellingPriceValue = document.getElementById("hdnlblTotalSellingPrice");

        var hdn_orderedheight = document.getElementById("<%=hdn_orderedheight.ClientID %>");
        var hdn_orderedwidth = document.getElementById("<%=hdn_orderedwidth.ClientID %>");
        var hdn_orderedarea = document.getElementById("<%=hdn_orderedarea.ClientID %>");
        var hdn_orderedquantity = document.getElementById("<%=hdn_orderedquantity.ClientID %>");

        var isPDMyCartRightPannel = '<%=isPDMyCartRightPannel%>';
        if (isPDMyCartRightPannel == "0") {
            rightPanel_contents.style.display = "none";
        }

        var ProductID = '<%=PriceCatalogueID %>';
        var spn_qty = document.getElementById("spn_qty");
        var spn_Dimensn = document.getElementById("spn_Dimensn");
        var spnDimensn = document.getElementById("spnDimensn");
        var div_PriceList = document.getElementById("div_PriceList");
        var div_PriceListMore = document.getElementById("div_PriceListMore");
        var isCustomerCode = '<%=isCustomerCode %>';
        var isItemCode = '<%=isItemCode %>';
        var IsCumulative = '<%=IsCumulative %>'.toLowerCase();
        var IsCumulativeQtyForUnitPrice = 0;

        if (hid_matixType.value == "P") {
            var Qty = document.getElementById("txtqty").value;
        }
        else if (hid_matixType.value == "G") {
            var Qty = document.getElementById("txtqty").value;
        }
        else {

            if (IsCumulative == "true") {
                var txt_Cumulative_PriceQty = document.getElementById("ctl00_ContentPlaceHolder1_txt_Cumulative_PriceQty");
            } else {
                var ddlPriceQty = document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty");
                var ddlPriceQtyText = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                var ddlPriceQtyvalue = ddlPriceQty.options[ddlPriceQty.selectedIndex].value;
            }
            Tocalculate_totalPrice('0');
            CheckStockAvailability('0');
        }

        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                VisibleAdditionaloption(ddlMultiple.getAttribute('weothercostid'));
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        if (hid_matixType.value == "S") {
            Tocalculate_totalPrice(ddlPriceQtyText);
        }
        else {
            Tocalculate_totalPrice(Qty);
        }

        // for enhancement id : 2575
        function dispCustCodeandItemcode() {
            if (isCustomerCode.toLowerCase() == 'true') {
                divCustCode.style.display = "block";
            }
            else {
                divCustCode.style.display = "none";
            }
            if (isItemCode.toLowerCase() == 'true') {
                divItemCode.style.display = "block";
            }
            else {
                divItemCode.style.display = "none";
            }

        }
        window.onload = dispCustCodeandItemcode;

    </script>
    <script type="text/javascript">
        function Animate2id(id, ease) { //the id to animate, the easing type
            var animSpeed = 2000; //set animation speed
            var $container = $("#container"); //define the container to move
            if (ease) { //check if ease variable is set
                var easeType = ease;
            } else {
                var easeType = "easeOutQuart"; //set default easing type
            }
            //do the animation
            $container.stop().animate({ "left": -($(id).position().left) }, animSpeed, easeType);
            $('body,html').css('overflow-x', 'hidden');
            $(window).scrollTop();
            $('body,html').scrollTop(10);

        }

        function AnimateBack(id, ease) { //the id to animate, the easing type

            var animSpeed = 2000; //set animation speed
            var $container = $("#container"); //define the container to move
            if (ease) { //check if ease variable is set
                var easeType = ease;
            } else {
                var easeType = "easeOutQuart"; //set default easing type
            }
            //do the animation
            $container.stop().animate({ left: "0px" }, 2000, "easeOutQuart");
            $('body,html').css('overflow-x', 'hidden');
            document.getElementById("div_editbtnload").style.display = "none";

        }
        $('body,html').css('overflow-x', 'hidden');
    </script>
    <script type="text/javascript">
        function BackTo() {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlNormalDetails").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_pnlConfirmPRFile").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btn_ConfirmAdd1").style.display = "none";
        }

    </script>
    <asp:Panel ID="pnladdoptionvalidate" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">
            CheckStockAvailability(0);
        </script>
    </asp:Panel>
</asp:Content>
