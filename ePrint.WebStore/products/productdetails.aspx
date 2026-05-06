<%@ Page Title="Products" Language="C#" MasterPageFile="~/Templates/MasterPageDefault.master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="ePrint.WebStore.productdetails" EnableEventValidation="false" ViewStateEncryptionMode="Never" EnableTheming="false" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


</asp:Content>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">

        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>

    </asp:ScriptManager>

    <script type="text/javascript" src="../js/jquery.min_new.js?VN=<%=VersionNumber%>"></script>
    <script type="text/javascript" src="../js/jquery.easing.1.3.js?VN=<%=VersionNumber%>"></script>

    <script type="text/javascript" src="../js/min.js?VN=<%=VersionNumber%>"></script>
    <script type="text/javascript" src="../js/popup.js?VN=<%=VersionNumber%>"></script>

    <script type="text/javascript" src="../js/ImageMagnifier/jquery.jqzoom-core.js?VN=<%=VersionNumber%>"></script>
    <script type="text/javascript" src="../js/ImageMagnifier/jquery.jqzoom-core-pack.js?VN=<%=VersionNumber%>"></script>

    <script type="text/javascript" src="../js/commonloading.js?VN=<%=VersionNumber%>"></script>
    <script type="text/javascript" src="../js/product_item.js?VN=<%=VersionNumber%>"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/products.js?VN=<%=VersionNumber%>"></script>


    <script type="text/javascript" language="javascript">
        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }
    </script>


    <script type="text/javascript">
        var strSitepath = '<%=strSitepath %>';
        var PriceCatalogueID = '<%=PriceCatalogueID %>';
        var Mode = '<%=Mode %>';
        var CompanyID = '<%=CompanyID %>';
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var TheURL = '<%=TheURL %>';
        var IsSpendLimitEnable = '<%=IsSpendLimitEnable %>';
        var SpendLimitAmount = '<%=SpendLimitAmount %>';
        var SpendAmount = '<%=SpendAmount %>';
        var IsEnableHidePrice = '<%=IsEnableHidePrice %>';
        var MeasurementValue_Sq = '<%=MeasurementValue_Sq %>';
        var Stock_Availability = '<%=objLanguage.GetLanguageConversion("Stock_Availability") %>';
        var Please_enter_dimension = '<%=objLanguage.GetLanguageConversion("Please_enter_dimension") %>';
        var Please_enter_height = '<%=objLanguage.GetLanguageConversion("Please_enter_height") %>';
        var Please_enter_width = '<%=objLanguage.GetLanguageConversion("Please_enter_width") %>';
        var Minimum_Quantity_Is = '<%=objLanguage.GetLanguageConversion("Minimum_Quantity_Is") %>';
        var Maximum_Quantity_is = '<%=objLanguage.GetLanguageConversion("Maximum_Quantity_is") %>';
        var Minimum_Dimension_Is = '<%=objLanguage.GetLanguageConversion("Minimum_Dimension_Is") %>';
        var Maximum_Dimension_Is = '<%=objLanguage.GetLanguageConversion("Maximum_Dimension_Is") %>';
        var Please_enter_quantity_in_numbers = '<%=objLanguage.GetLanguageConversion("Please_enter_quantity_in_numbers") %>';
        var No_Stock_with_no_backorder_msg = '<%=objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock")  %>' + '.</br>' + '<%=objLanguage.GetLanguageConversion("It_is_not_currently_available_for_you_to_Order") %>';
        var No_Stock_with_backorder_msg = '<%=objLanguage.GetLanguageConversion("This_Product_is_out_of_Stock") %>' + '.</br>' + '<%=objLanguage.GetLanguageConversion("If_you_proceed_to_Order_this_will_be_a_Back_Order") %>';
        var IsCumulative = '<%=IsCumulative%>'.toLowerCase();
        var IsCumulativeQtyForUnitPrice = 0;
        var IsDisplayAdditionalOptions = '<%=IsDisplayAdditionalOptions %>'.toLowerCase().trim();
        var AllDimentions = '<%=Dimention %>';
        $(document).ready(function () {

            var priceQty = $("[id$='ddlPriceQty']");
            if (priceQty.is(":visible")) {
                priceQty.focus();
            }

            $('.jqzoom').jqzoom({
                zoomType: 'reverse',
                lens: true,
                preloadImages: false,
                alwaysOn: false
            });

        });

    </script>

    <style type="text/css">
        .deleteimage {
            padding-left: 140px;
        }

        .dropDownMultiple75:focus {
            border: 1px solid;
        }
        .paddingJobName {
            padding-top : 1px;
        }
    </style>
    <div id="container">
        <div id="c1">
            <div id="productMain_div">
                <div align="center" id="productMain_div_border">
                    <div align="center" id="productMain_Outerdiv">
                        <asp:Panel ID="pnlNormalDetails" runat="server">
                            <div align="center" id="top_div">
                                <table cellpadding="0" cellspacing="0" border="0" class="width100p">
                                    <tr>
                                        <td valign="top" id="leftPanel_td_div" runat="server">
                                            <div id="leftPanel_div">
                                                <div id="leftPanel">
                                                    <table cellpadding="0" cellspacing="0" class="width100p">
                                                        <tr>
                                                            <td class="paddingTop5">
                                                                <table cellpadding="0" cellspacing="0" align="left">
                                                                    <tr>
                                                                        <td valign="top" align="left" class="width210px">
                                                                            <div id="productMain_Leftpanel_Outerdiv">
                                                                                <div id="image">
                                                                                    <div class="clearfix" id="content">
                                                                                        <div class="clearfix">
                                                                                            <a id="cards1" runat="server" class="jqzoom" rel='gal1'>
                                                                                                <img border="0" id="cards" runat="server" style="max-width:250px;max-height:300px;" class="ImageStyle" alt=" ">
                                                                                            </a>&nbsp;&nbsp;
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="clearBoth">
                                                                                    </div>
                                                                                    <div id="div_PrintReadyFile" runat="server" class="DisplayNone">
                                                                                        <asp:Label ID="lblPrintReadyFile" runat="server" CssClass="Normaltext"></asp:Label><br />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div id="divLine" runat="server" class="horizontal_line_B2B">
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <%--<div id="DivUploadCsvFile" runat="server" class="DivUploadCsvFile">
                                                                                    <a id="UploadCsvFile" runat="server" class="jqzoom" rel='gal1' title="Upload CSV File"
                                                                                        onclick="javascript:OpenUploadFile();">
                                                                                        <img border="0" class=" UploadCsvFile">
                                                                                    </a>&nbsp;&nbsp;&nbsp;
                                                                                </div>--%>
                                                                                <div id="rightPanel">
                                                                                    <div id="div_ProductPriceList" runat="server" class="width210px">
                                                                                        <div id="rightPanel_Col1">
                                                                                            <div id="rightPanel_heading" class="Header_Background" style="padding-left: 0px;">
                                                                                                <strong>
                                                                                                    <asp:Label ID="Label" runat="server" Text="Price List"></asp:Label></strong>
                                                                                            </div>
                                                                                            <div id="priceBand">
                                                                                                <div id="div_PriceList">
                                                                                                    <asp:PlaceHolder ID="plhPriceList" runat="server"></asp:PlaceHolder>
                                                                                                </div>
                                                                                                <div id="div_PriceListMore" class="DisplayNone">
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
                                                                            </div>
                                                                        </td>
                                                                        <td align="left" class="ProductDetials_MainDiv">
                                                                            <asp:HiddenField ID="hdnIsBackOrder" runat="server" />
                                                                            <asp:HiddenField ID="hdnWebOtherCostID" runat="server" />
                                                                            <asp:HiddenField ID="hdnStockAddOption" runat="server" />
                                                                            <asp:HiddenField ID="hdnPriceCatalogueID" runat="server" />
                                                                            <asp:HiddenField ID="hdnDrawStockFrom" runat="server" />
                                                                            <asp:HiddenField ID="hdnStockManagement" runat="server" />
                                                                            <asp:HiddenField ID="hdnIsShowStock" runat="server" />
                                                                            <asp:HiddenField ID="hdnAvailableQty" runat="server" />
                                                                            <asp:HiddenField ID="hdnMashDivHeight" runat="server" />
                                                                            <asp:HiddenField ID="hdnShowPriceSubtotalTax" runat="server" />
                                                                            <asp:HiddenField ID="hdnShowUnitPrice" runat="server" />
                                                                            <asp:HiddenField ID="hdnShowPackPrice" runat="server" />
                                                                             <asp:HiddenField ID="hdnShowJobName" runat="server" />
                                                                             <asp:HiddenField ID="hdnJobName" runat="server" />
                                                                             <asp:HiddenField ID="hdnCartJobNameIsMandatory" runat="server" Value="0"/>
                                                                            <asp:HiddenField ID="hdnIsStockItem" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hdnStockForMultipleProducts" runat="server" />
                                                                            <asp:HiddenField ID="hdnMatrixCheckMultipleProduct" runat="server" Value="False" />
                                                                            <div id="divMask" runat="server" class="MaskDiv DisplayNone">
                                                                            </div>
                                                                            <div>
                                                                                <asp:PlaceHolder ID="plhContentTop" runat="server"></asp:PlaceHolder>
                                                                                <div class="TextAlignLeft">
                                                                                    <h3>
                                                                                        <asp:Label ID="lbl_CatalogueName2" runat="server"></asp:Label></h3>
                                                                                    <h4>
                                                                                        <asp:Label ID="Label5" runat="server"></asp:Label></h4>
                                                                                </div>
                                                                                <div class="EmptyDiv">
                                                                                </div>
                                                                                <div id="pnlStockMessage" runat="server" class="DisplayNone">
                                                                                    <asp:Label ID="lblStockMessage" runat="server" Text="Stock Not Available" CssClass="ColorRed"></asp:Label>
                                                                                    <div class="clearBoth clearTop">
                                                                                    </div>
                                                                                </div>
                                                                                <div class="EmptyDiv">
                                                                                </div>
                                                                                <div id="prod_description">
                                                                                    <asp:Label ID="lbl_Description" CssClass="Desc" runat="server"></asp:Label>
                                                                                </div>
                                                                                <div class="EmptyDiv">
                                                                                </div>
                                                                                <div id="divCustCode" class="DisplayNone">
                                                                                    <div class="floatLeft">
                                                                                        <%=objLanguage.GetLanguageConversion("Customer_Code") %>
                                                                                        :
                                                                                    </div>
                                                                                    <div class="floatRight">
                                                                                        <asp:Label runat="server" ID="lblCustomerCode"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="EmptyDiv">
                                                                                </div>
                                                                                <div id="divItemCode" class="DisplayNone">
                                                                                    <div class="floatLeft">
                                                                                        <%=objLanguage.GetLanguageConversion("Item_Code") %>
                                                                                    </div>
                                                                                    <div class="floatRight">
                                                                                        <asp:Label runat="server" ID="lblItemCode"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="EmptyDiv">
                                                                                </div>

                                                                                <div id="div_PriceMatrix" runat="server" style="display:block;">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <telerik:RadGrid ID="GridInkCostView" AutoGenerateColumns="false" runat="server"
                                                                                                    PageSize="50" Width="99%" HeaderStyle-Font-Bold="true" CssClass="RadGrid_Eprint_Skin"
                                                                                                    OnItemDataBound="GridInkCostView_OnItemDataBound">
                                                                                                    <MasterTableView>
                                                                                                        <Columns>
                                                                                                           
                                                                                                            <telerik:GridTemplateColumn HeaderText="Catalogue Name" HeaderStyle-HorizontalAlign="Left"
                                                                                                                ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lbl_CatalogueName" runat="server"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.CatalogueName", "{0}"))%></asp:Label><%--2--%>
                                                                                                                    <asp:HiddenField ID="hdninkType" runat="server" Value='<%#Eval("PriceCatalogueID")%>' />
                                                                                                                </ItemTemplate>
                                                                                                            </telerik:GridTemplateColumn>
                                                                                                            <telerik:GridTemplateColumn HeaderText="Quantity Ordered" HeaderStyle-HorizontalAlign="Right"
                                                                                                                ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Width="75px"
                                                                                                                        Text='<%#Eval("Markup")%>'></asp:TextBox><%--7--%>
                                                                                                                    <asp:DropDownList ID="ddl_Markup" AppendDataBoundItems="true"  DataTextField="ToQuantity" DataValueField="NewPrice" class="dropDownMultiple75" 
                                                                                                                        runat="server">
                                                                                                                        <asp:ListItem Text="--Select--" Value="" />
                                                                                                                    </asp:DropDownList><%--7--%>
                                                                                                                </ItemTemplate>
                                                                                                            </telerik:GridTemplateColumn>
                                                                                                            <telerik:GridTemplateColumn HeaderText="MarkupPrice" HeaderStyle-HorizontalAlign="Right"
                                                                                                                ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="MarkupPrice">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("AvailableQuantity")%>'></asp:Label><%--8--%>
                                                                                                                </ItemTemplate>
                                                                                                            </telerik:GridTemplateColumn>
                                                                                                            <telerik:GridTemplateColumn HeaderText="Price($)" HeaderStyle-HorizontalAlign="Right"
                                                                                                                ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="Price">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label><%--11--%>
                                                                                                                    <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("Price")%>' />
                                                                                                                    <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                                                                                                    
                                                                                                                </ItemTemplate>
                                                                                                            </telerik:GridTemplateColumn>
                                                                                                        </Columns>
                                                                                                    </MasterTableView>
                                                                                                </telerik:RadGrid>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="padding-right: 15px;">
                                                                                                <asp:PlaceHolder ID="plhTotalSellingPrice" runat="server"></asp:PlaceHolder>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>


                                                                                <div id="div_OtherMultipleProducts" runat="server" style="display:block">
                                                                                    <div class="floatLeft" style="width: 300px">
                                                                                        <asp:Label ID="Label4" runat="server">Select your option</asp:Label>
                                                                                        <span id="Spn_PrdoMandatory" runat="server" class="mandatoryField">*</span><br />
                                                                                        <asp:DropDownList ID="ddlOtherMultiple" runat="server" OnSelectedIndexChanged="ddlOtherMultiple1_OnSelectedIndexChanged"
                                                                                            AutoPostBack="true" CssClass="SelectBehalfText width180px" Style="width: 300px">
                                                                                        </asp:DropDownList>
                                                                                        <div id="div_ProdSelectErrorMSG" runat="server" style="display: none">
                                                                                            <span id="Span2" runat="server" class="floatLeft ColorRed">Plese select your product</span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="div_OtherMultipleProducts1" runat="server" style="display:none;">
                                                                                    <div class="floatLeft" style="width: 300px">
                                                                                        <asp:Label ID="Label6" runat="server">Select your option</asp:Label>
                                                                                        <span id="Spn_PrdoMandatory1" runat="server" class="mandatoryField">*</span><br />
                                                                                        <asp:DropDownList ID="ddlOtherMultiple1" runat="server" OnSelectedIndexChanged="ddlOtherMultiple2_OnSelectedIndexChanged"
                                                                                            AutoPostBack="true" CssClass="SelectBehalfText width180px" Style="width: 300px">
                                                                                        </asp:DropDownList>
                                                                                        <div id="div_ProdSelectErrorMSG1" runat="server" style="display: none">
                                                                                            <span id="Span4" runat="server" class="floatLeft ColorRed">Plese select your product</span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="div_OtherMultipleProducts2" runat="server" style="display:none;">
                                                                                    <div class="floatLeft" style="width: 300px">
                                                                                        <asp:Label ID="Label7" runat="server">Select your option</asp:Label>
                                                                                        <span id="Spn_PrdoMandatory2" runat="server" class="mandatoryField">*</span><br />
                                                                                        <asp:DropDownList ID="ddlOtherMultiple2" runat="server" OnSelectedIndexChanged="ddlOtherMultiple1_OnSelectedIndexChanged"
                                                                                            AutoPostBack="true" CssClass="SelectBehalfText width180px" Style="width: 300px">
                                                                                        </asp:DropDownList>
                                                                                        <div id="div_ProdSelectErrorMSG2" runat="server" style="display: none">
                                                                                            <span id="Span6" runat="server" class="floatLeft ColorRed">Plese select your product</span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="Div1" runat="server" class="clearBoth">
                                                                                </div>
                                                                                <div id="priceStartsFrom">
                                                                                    <asp:Label ID="lbl_priceStartsFrom" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lbl_priceStartsFrom1" runat="server" class="floatRight"></asp:Label>
                                                                                </div>
                                                                                <div id="div_soldinpack" runat="server" class="DisplayNone">
                                                                                    <div id="ShowSoldInPacksOf">
                                                                                        <asp:Label ID="lbl_ShowSoldInPacksOf" runat="server" Text="Sold In Packs Of : "></asp:Label>
                                                                                        <asp:Label ID="lbl_ShowSoldInPacksOf1" runat="server" class="floatRight" Text=""></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="divStockStatus" runat="server" class="DisplayNone clearBottom">
                                                                                    <asp:Label ID="lbl_stockStatus" runat="server" Text=""></asp:Label>
                                                                                    <asp:Label ID="lbl_stockStatus1" runat="server" class="floatRight" Text=""></asp:Label>
                                                                                </div>
                                                                                <%-- Added for Campaign Feild--%>
                                                                                <asp:PlaceHolder ID="plhContentMiddle" runat="server"></asp:PlaceHolder>
                                                                                <div id="clear" runat="server" class="clearBoth clearTop">
                                                                                </div>
                                                                                <div id="div_Campaign" runat="server" style="display: none">
                                                                                    <div class="floatLeft">
                                                                                        <asp:Label ID="lblSelectCampaign" runat="server"><%=objLanguage.GetLanguageConversion("Select_Campaign")%></asp:Label>
                                                                                        <span id="starspan" class="mandatoryField">*</span>
                                                                                    </div>
                                                                                    <div class="floatRight">
                                                                                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="SelectBehalfText width180px">
                                                                                        </asp:DropDownList>
                                                                                        <div id="div_CampaignErrorMsg" runat="server" style="display: none">
                                                                                            <span id="spn_CampaignErrMsg" runat="server" class="floatRight ColorRed">
                                                                                                <%=objLanguage.GetLanguageConversion("Please_Select_Your_Campaign")%></span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <%-- End--%>
                                                                                <div id="div_Below_Desc" runat="server">
                                                                                    <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
                                                                                    <asp:HiddenField ID="hdnCampaignValue" runat="server" Value="" />
                                                                                    <asp:HiddenField ID="hdnCampaignSelectedValue" runat="server" Value="" />
                                                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                                <ContentTemplate>--%>
                                                                                    <div id="price_calculator">
                                                                                        <div class="DisplayNone">
                                                                                            <a href="#">Can't find the option you need</a>
                                                                                        </div>









                                                                                        <div id="Price_CalculatorWithAddition1" runat="server">
                                                                                            <div id="price_table">
                                                                                                <div class="horizontal_line_B2B">
                                                                                                </div>
                                                                                                <div class="clearBoth paddingBottom5">
                                                                                                </div>
                                                                                                <div id="price_table_header">
                                                                                                    <%=objLanguage.GetLanguageConversion("Additional_Options")%>
                                                                                                    <%--<%=objLanguage.GetLanguageConversion("Please_Select_Your_Options_Below")%>--%>
                                                                                                </div>
                                                                                                <div id="price_table_content">
                                                                                                    <asp:PlaceHolder ID="plhPriceCalculator" runat="server" Visible="true"></asp:PlaceHolder>

                                                                                                    <%--Decoration Start--%>

                                                                                                    <%--                <div id="Div3" runat="server">
                                                                                            <div id="price_table_Decoration">
                                                                                                <div class="horizontal_line_B2B">
                                                                                                </div>
                                                                                                <div class="clearBoth paddingBottom5">
                                                                                                </div>
                                                                                                <div id="price_table_header_Decoration">
                                                                                                    <label>Decoration Options</label>

                                                                                                </div>
                                                                                                <div runat="server" id="price_table_content_Decoration1">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration1">Decoration1</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration1" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                             <asp:HiddenField runat="server" ID="hdnDecoration1" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration1Cost"></label>
                                                                                                             <asp:HiddenField runat="server" ID="hdnDecorationCost1" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                                 <div class="clearBoth">
                                                                                            </div>
                                                                                                           <div runat="server" id="price_table_content_Decoration2">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration2">Decoration2</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration2" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecoration2" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration2Cost"></label>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecorationCost2" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                           
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                            <div runat="server" id="price_table_content_Decoration3">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration3">Decoration3</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration3" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecoration3" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration3Cost"></label>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecorationCost3" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                          
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                                 <div runat="server" id="price_table_content_Decoration4">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration4">Decoration4</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration4" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                             <asp:HiddenField runat="server" ID="hdnDecoration4" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration4Cost"></label>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecorationCost4" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                          
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                                  <div runat="server" id="price_table_content_Decoration5">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration5">Decoration5</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration5" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                             <asp:HiddenField runat="server" ID="hdnDecoration5" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration5Cost"></label>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecorationCost5" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                          
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                                  <div runat="server" id="price_table_content_Decoration6">
                                                                                                    <div class="price_table_content_left_B2B paddingTop5 paddingBottom5">
                                                                                                        <label runat="server" id="lblDecoration6">Decoration6</label><div>
                                                                                                            <asp:DropDownList ID="ddlDecoration6" runat="server" CssClass="dropDownMultiple150" Style="width: 300px;">
                                                                                                            </asp:DropDownList>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecoration6" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="price_table_content_right_B2B">
                                                                                                        <div class="price_table_content_right_innerDiv2">
                                                                                                            <label runat="server" id="lblDecoration6Cost"></label>
                                                                                                            <asp:HiddenField runat="server" ID="hdnDecorationCost6" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                          
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                        </div>--%>

                                                                                                    <%-- Decoration End --%>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="divBehalfOf" class="clear" runat="server">
                                                                                            <div class="horizontal_line_B2B">
                                                                                            </div>
                                                                                            <div class="<%=BehalfOfStyle %>">
                                                                                            </div>
                                                                                            <div class="floatLeft">
                                                                                                <asp:Label ID="lbl_BehalfUsers" runat="server"></asp:Label>
                                                                                            </div>
                                                                                            <div id="divSelectBehalf" runat="server" class="floatRight clearLeft DisplayNone">
                                                                                                <asp:DropDownList ID="ddl_SelectBehalf" runat="server" CssClass="SelectBehalfText width180px">
                                                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                                    <asp:ListItem Text="User(s)" Value="1"></asp:ListItem>
                                                                                                    <asp:ListItem Text="Department(s)" Value="2"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                            <div id="divUserBehalf" runat="server" class="floatRight clearLeft DisplayNone paddingTop5 ">
                                                                                                <asp:DropDownList ID="ddl_BehalfUsers" CssClass="SelectBehalfText width180px" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                            <div id="divDeptBehalf" runat="server" class="floatRight clearLeft DisplayNone paddingTop5">
                                                                                                <asp:DropDownList ID="ddl_BehalfDepts" runat="server" CssClass="SelectBehalfText width180px">
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                            <div id="divattnof" class="floatLeft DisplayNone paddingTop5">
                                                                                                <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                            </div>
                                                                                            <div id="divDeptUsers" runat="server" class="floatRight clearLeft DisplayNone paddingTop5">
                                                                                                <asp:DropDownList ID="ddl_DeptUsers" runat="server" CssClass="SelectBehalfText width180px">
                                                                                                </asp:DropDownList>
                                                                                                <asp:HiddenField runat="server" ID="hdnDepuUserID" />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="clearBoth">
                                                                                        </div>
                                                                                        <div runat="server" id="div_replenishstockcontent">
                                                                                            <asp:RadioButton ID="rdbstkorder" GroupName="rdbgrp_rep" Checked="true" runat="server"
                                                                                                Text="    I want to Order" onchange="javascript:NeedStockReplenish();" />
                                                                                            <div class="StockRadioBtnsClearDiv">
                                                                                            </div>
                                                                                            <asp:RadioButton ID="rdstkbreplenish" GroupName="rdbgrp_rep" runat="server" Text="   I want to Replenish the Stock"
                                                                                                onchange="javascript:NeedStockReplenish();" />
                                                                                        </div>
                                                                                        <div class="clearBoth">
                                                                                        </div>
                                                                                        <div id="Price_CalculatorWithAddition2" runat="server">
                                                                                            <div id="artwork_div" class="artwork_div" runat="server">
                                                                                                <div class="horizontal_line_B2B">
                                                                                                </div>
                                                                                                <div class="artwork_header">
                                                                                                    <%=objLanguage.GetLanguageConversion("Artwork") %>
                                                                                                </div>
                                                                                                <div class="artwork_content_div">
                                                                                                    <%--<div class="artwork_content_lbl">
                                                                                                    </div>--%>
                                                                                                    <div id="DivUploadCsvFile" runat="server" class="artwork_content_lbl">
                                                                                                        <asp:Label ID="Label1" runat="server" Text="Upload your artwork file"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="clearBoth">
                                                                                                    </div>
                                                                                                    <div class="artwork_content_fileupload">
                                                                                                        <div class="paddingTop5">
                                                                                                            <asp:Label ID="lblfp_artwork" runat="server" class="floatLeft ColorBlue"></asp:Label>
                                                                                                            <div class="deleteimage">
                                                                                                                <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/images/StoreImages/erase.png" Visible="false"
                                                                                                                    OnClientClick="javascript:HideArtworkName('', 1);return false;" runat="server" />
                                                                                                            </div>
                                                                                                            <div class="clearBoth">
                                                                                                            </div>
                                                                                                            <asp:FileUpload ID="fp_artwork" runat="server" size="32" CssClass="fp_artwork_no_addoption" />
                                                                                                            <span id="spn_artworkFile" runat="server" class="DisplayNone ColorRed">
                                                                                                                <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <div class="paddingTop5">
                                                                                                            <asp:Label ID="lblfp_artwork1" runat="server" class="floatLeft ColorBlue"></asp:Label>
                                                                                                            <div class="deleteimage">
                                                                                                                <asp:ImageButton ID="ImgButtonErase1" ImageUrl="~/images/StoreImages/erase.png" runat="server"
                                                                                                                    Visible="false" OnClientClick="javascript:HideArtworkName('1', 2);return false;" />
                                                                                                            </div>
                                                                                                            <div class="clearBoth">
                                                                                                            </div>
                                                                                                            <asp:FileUpload ID="fp_artwork1" runat="server" size="32" CssClass="fp_artwork_no_addoption" />
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <div class="paddingTop5">
                                                                                                            <asp:Label ID="lblfp_artwork2" runat="server" class="floatLeft ColorBlue"></asp:Label>
                                                                                                            <div class="deleteimage">
                                                                                                                <asp:ImageButton ID="ImgButtonErase2" ImageUrl="~/images/StoreImages/erase.png" runat="server"
                                                                                                                    Visible="false" OnClientClick="javascript:HideArtworkName('2', 3);return false;" />
                                                                                                            </div>
                                                                                                            <div class="clearBoth">
                                                                                                            </div>
                                                                                                            <asp:FileUpload ID="fp_artwork2" runat="server" size="32" CssClass="fp_artwork_no_addoption" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="clearBoth">
                                                                                            </div>
                                                                                            <div id="price_table_button">
                                                                                                <div class="price_table_content_left_B2B">
                                                                                                </div>
                                                                                                <div class="floatRight">
                                                                                                    <div id="div_btnsave1" runat="server" class="DisplayBlock floatRight">
                                                                                                        <asp:Button ID="btnAddtoCart" runat="server" Text="Add to Cart" class="floatRight x-btnpro Grey main"
                                                                                                            OnClientClick="javascript:return Save_toCart('yes','div_btnsave1','div_btnsaveprocess1');"
                                                                                                            OnClick="btnAddtoCart_Click" />
                                                                                                    </div>
                                                                                                    <div id="div_btnsaveprocess1" class="x-btnpro Grey main" align="center" style="float: left !important">
                                                                                                        <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                                                                    </div>
                                                                                                    <%-- Add To Cart And Stay--%>
                                                                                                    <div id="div_btnsave2" class="DisplayBlock floatRight" style="padding-left: 5px; padding-right: 5px;">
                                                                                                        <asp:Button ID="btnAddtoCartStay" runat="server" Text="Add To Cart And Stay" class="floatRight x-btnpro Grey main"
                                                                                                            OnClientClick="javascript:return Save_toCart('yes','div_btnsave2','div_btnsaveprocess2');"
                                                                                                            OnClick="btnAddtoCartStay_Click" />
                                                                                                    </div>
                                                                                                    <div id="div_btnsaveprocess2" class="x-btnpro Grey main" align="center" style="margin-left: 105px; display: none; height: 16px; width: 65%;">
                                                                                                        <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                                                                    </div>
                                                                                                    <div id="div_btnsave4" class="DisplayBlock floatRight">
                                                                                                        <asp:Button ID="EditProduct2" OnClientClick="javascript:return Save_toCart('yes','div_btnsave4','div_btnsaveprocess1');"
                                                                                                            OnClick="btnEditTemplate_Click" runat="server" Text="Edit Product" class="floatRight x-btnpro Grey main" />
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>

                                                                                        </div>
                                                                                        <div id="artwork_div_no_addoption" class="artwork_div_no_addoption marginTop" runat="server">
                                                                                            <div class="horizontal_line_B2B">
                                                                                            </div>
                                                                                            <div runat="server" id="diveArtWorkHide" class="artwork_header_no_addoption">
                                                                                                <%=objLanguage.GetLanguageConversion("Artwork") %>
                                                                                            </div>
                                                                                            <div class="artwork_content_div_no_addoption">
                                                                                                <div class="artwork_content_lbl_no_addoption paddingTop5">
                                                                                                    <asp:Label ID="lblupload" runat="server" Text="Upload your artwork file"></asp:Label>
                                                                                                </div>
                                                                                                <div id="div_artwork_content_fileupload_no_addoption" class="artwork_content_fileupload_no_addoption"
                                                                                                    runat="server">
                                                                                                    <div class="paddingTop5">
                                                                                                        <asp:Label ID="lblfp_artwork_no_addoption1" runat="server" CssClass="floatLeft ColorBlue"></asp:Label>
                                                                                                        <div class="eraseimgmargin">
                                                                                                            <asp:ImageButton ID="ImgButtonErase_no_addoption1" ImageUrl="~/images/StoreImages/erase.png"
                                                                                                                runat="server" Visible="false" OnClientClick="javascript:HideArtworkName('_no_addoption1', 1);return false;" />
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <asp:FileUpload ID="fp_artwork_no_addoption1" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                                                                        <span id="spn_artworkFile1" runat="server" class="spn_artworkFile1">
                                                                                                            <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                                                                                    </div>
                                                                                                    <div style="padding-top: 5px">
                                                                                                        <asp:Label ID="lblfp_artwork_no_addoption2" runat="server" CssClass="floatLeft ColorBlue"></asp:Label>
                                                                                                        <div class="eraseimgmargin">
                                                                                                            <asp:ImageButton ID="ImgButtonErase_no_addoption2" ImageUrl="~/images/StoreImages/erase.png"
                                                                                                                runat="server" Visible="false" OnClientClick="javascript:HideArtworkName('_no_addoption2', 2);return false;" />
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <asp:FileUpload ID="fp_artwork_no_addoption2" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                                                                    </div>
                                                                                                    <div style="padding-top: 5px">
                                                                                                        <asp:Label ID="lblfp_artwork_no_addoption3" runat="server" CssClass="floatLeft ColorBlue"></asp:Label>
                                                                                                        <div class="eraseimgmargin">
                                                                                                            <asp:ImageButton ID="ImgButtonErase_no_addoption3" ImageUrl="~/images/StoreImages/erase.png"
                                                                                                                runat="server" Visible="false" OnClientClick="javascript:HideArtworkName('_no_addoption3', 3);return false;" />
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <asp:FileUpload ID="fp_artwork_no_addoption3" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="DivUpload_DownloadCsvFile" class="artwork_div_no_addoption marginTop" runat="server">
                                                                                            <div id="TempDataLine" runat="server" class="horizontal_line_B2B" style="display: none;">
                                                                                            </div>
                                                                                            <div class="artwork_header_no_addoption">
                                                                                                <%=objLanguage.GetLanguageConversion("Template_data")%>
                                                                                            </div>
                                                                                            <div class="artwork_content_div_no_addoption">
                                                                                                <div class="artwork_content_lbl_no_addoption paddingTop5" style="width: 180px;">
                                                                                                    <asp:Label ID="Label2" runat="server" Text="Upload your template data file"><%=objLanguage.GetLanguageConversion("Upload_your_template_data_file")%></asp:Label>
                                                                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                                                                                        ControlToValidate="Upload" ValidationGroup="Test"></asp:CustomValidator>
                                                                                                </div>
                                                                                                <div id="div2" class="artwork_content_fileupload_no_addoption" runat="server">
                                                                                                    <div class="paddingTop5">
                                                                                                        <asp:Label ID="Label3" runat="server" CssClass="floatLeft ColorBlue"></asp:Label>
                                                                                                        <div class="eraseimgmargin">
                                                                                                            <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/StoreImages/erase.png" runat="server"
                                                                                                                Visible="false" OnClientClick="javascript:HideArtworkName('_no_addoption1', 1);return false;" />
                                                                                                        </div>
                                                                                                        <div class="clearBoth">
                                                                                                        </div>
                                                                                                        <asp:FileUpload ID="Upload" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                                                                        <span id="Span1" runat="server" class="spn_artworkFile1">
                                                                                                            <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div style="clear: both">
                                                                                            </div>
                                                                                            <span id="Spn_ImageUploadFile" class="DisplayNone ColorRed" style="display: none; width: 185px;">
                                                                                                <%=objLanguage.GetLanguageConversion("Please_Upload_CSV_File")%></span>
                                                                                            <div style="clear: both">
                                                                                            </div>
                                                                                            <div id="DivDownloadCsvFile" runat="server" align="left" style="color: Gray; font-family: Verdana; font-size: 11px;">
                                                                                                <a id="DownloadCsvFile" runat="server" title="Download CSV File" style="text-decoration: underline;"
                                                                                                    onserverclick="DownloadCsvFile_Click">Click here</a> to download sample file
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="clearBoth">
                                                                                        </div>
                                                                                        <div id="div_btnAddtoCart1" class="div_btnAddtoCart1" runat="server" style="width: 55% !important">
                                                                                            <div id="div_btnsave" runat="server" class="DisplayBlock floatLeft">
                                                                                                <asp:Button ID="btnAddtoCart1" runat="server" Text="Add to Cart" class="x-btnpro Grey main"
                                                                                                    OnClick="btnAddtoCart_Click" OnClientClick="javascript:return Save_toCart('no','div_btnsave','div_btnsaveprocess');" />
                                                                                            </div>
                                                                                            <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center" style="float: left !important">
                                                                                                <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                                                            </div>
                                                                                            <%-- Add To Cart And Stay div_btnAddtoCartStay1--%>
                                                                                            <div id="div_btnsave3" class="DisplayBlock">
                                                                                                <asp:Button ID="btnAddtoCartStay1" runat="server" Text="Add To Cart And Stay" class="floatRight x-btnpro Grey main"
                                                                                                    OnClientClick="javascript:return Save_toCart('no','div_btnsave3','div_btnsaveprocess3');"
                                                                                                    OnClick="btnAddtoCartStay1_Click" />
                                                                                            </div>
                                                                                            <div id="div_btnsaveprocess3" class="x-btnpro Grey main" align="center" style="margin-left: 105px; display: none; height: 16px;">
                                                                                                <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                                                            </div>
                                                                                            <div id="div_btnsave2" class="DisplayBlock floatRight">
                                                                                                <asp:Button ID="EditProduct1" OnClientClick="javascript:return Save_toCart('no','div_btnsave2','div_btnsaveprocess');"
                                                                                                    OnClick="btnEditTemplate_Click" runat="server" Text="Edit Product" class="x-btnpro Grey main" />
                                                                                            </div>
                                                                                            <asp:PlaceHolder ID="plhAddtoCartClear" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                        <div class="clearBoth">
                                                                                        </div>
                                                                                    </div>
                                                                                    <%--</ContentTemplate>
                                                                                            </asp:UpdatePanel>--%>
                                                                                </div>
                                                                                <asp:PlaceHolder ID="plhContentBottom" runat="server"></asp:PlaceHolder>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                        <td id="rightPanel_div" align="right">
                                            <div id="rightPanel_image">
                                                <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlConfirmPRFile" runat="server" class="DisplayNone">
                            <div>
                                <table class="width100p">
                                    <tr>
                                        <td align="center" colspan="3" id="pdf_Confirm_ChkBx_td">
                                            <asp:CheckBox ID="chkconform" runat="server" Text=" I confirm that the PDF is correct" />
                                            <asp:HiddenField runat="server" ID="hdnPdfPath" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="width37p"></td>
                                        <td class="width26p" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBackToProDet" class="x-btnpro Grey main" runat="server" Text="Back"
                                                            OnClientClick="javasript:BackTo();return false;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_ConfirmAdd1" CssClass="x-btnpro Grey main DisplayNone" runat="server"
                                                            Text="Confirm and Add" OnClick="btnback_Click" />
                                                        <asp:Button ID="btn_ConfirmEditTemplate1" CssClass="x-btnpro Grey main DisplayNone"
                                                            runat="server" Text="Confirm and Edit Template" OnClick="btn_ConfirmEditTemplate_Click" />
                                                        <div id="divConfirmandAdd" class="x-btnpro Grey main" align="center">
                                                            <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                        </div>
                                                        <div id="divConfirmandEditTemplate" class="x-btnpro Grey main" align="center">
                                                            <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="width37p"></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <iframe runat="server" id="pdfframe" class="pdfframe" scrolling="no" title="PDF Preview"></iframe>
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
                    <div id="divBackGroundNew" class="DisplayNone">
                    </div>
                    <%--<div id="divrad" align="center">
                        <telerik:RadProgressManager ID="Radprogressmanager1" runat="server"></telerik:RadProgressManager>
                        <br />
                        <telerik:RadProgressArea ID="RadProgressArea1" runat="server" ProgressIndicators="FilesCountBar,SelectedFilesCount, CurrentFileName,TimeElapsed,TimeEstimated"
                            Style="">
                        </telerik:RadProgressArea>
                    </div>--%>
                    <%--<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                        ReloadOnShow="true" Title="Upload Csv File" AutoSize="false" Animation="Fade"
                        Behaviors="Close,Move,Reload" KeepInScreenBounds="true" ShowContentDuringLoad="false"
                        Modal="true" CssClass="RadWindowManager1">
                        <Windows>
                            <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Upload CSV File"
                                KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true" Modal="true"
                                ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="width400px">
                                        <td colspan="2">
                                            <asp:Label ID="ErrorMessage" runat="server" Text="Error Message" Visible="false"></asp:Label>
                                        </td>
                                        <tr>
                                            <td>
                                                <div id="div_FileUpload_Label">
                                                    Upload File:
                                                </div>
                                            </td>
                                            <td class="width300px">
                                                <div id="div_FileUpload_Main">
                                                    <asp:FileUpload ID="Upload" runat="server" size="40" CssClass="textboxnew" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <div id="div_FileUpload_ButtonDiv">
                                                    <asp:Button ID="UploadCAVFile" runat="server" Text="Upload" OnClick="UploadCsvFile_Click"
                                                        class="x-btnpro Grey main" OnClientClick="SetRadWindow('divrad', 'divBackGroundNew', '200');" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </telerik:RadWindow>
                        </Windows>
                    </telerik:RadWindowManager>--%>
                </div>
                <asp:HiddenField ID="hid_QuantityPrice" runat="server" />
                <asp:HiddenField ID="hid_QuantityPriceExcMarkup" runat="server" />
                <asp:HiddenField ID="hid_Markup" runat="server" />
                <asp:HiddenField ID="hid_QuestionLenght" runat="server" />
                <asp:HiddenField ID="hid_MultipleLenght" runat="server" />
                <asp:HiddenField ID="hid_MatrixLenght" runat="server" />
                <asp:HiddenField ID="hid_QuestionTextFreeLenght" runat="server" />
                <asp:HiddenField ID="hid_SaveToCart" runat="server" />
                <asp:HiddenField ID="hid_SaveToCartItems" runat="server" />
                <asp:HiddenField ID="hid_MultipleMatrixValues" runat="server" />
                <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
                <asp:HiddenField ID="hid_TempTotalPrice" runat="server" />
                <asp:HiddenField ID="hid_Quantity_Edit" runat="server" />
                <asp:HiddenField ID="hid_totalPrice_Edit" runat="server" />
                <asp:HiddenField ID="hdn_height" runat="server" />
                <asp:HiddenField ID="hdn_width" runat="server" />
                <asp:HiddenField ID="hdn_orderedheight" runat="server" />
                <asp:HiddenField ID="hdn_orderedwidth" runat="server" />
                <asp:HiddenField ID="hdn_orderedarea" runat="server" />
                <asp:HiddenField ID="hdn_orderedquantity" runat="server" />
            </div>
        </div>
        <div id="c2">
            <div class="content">
                <div class="Padding5px">
                    <div>
                        <div>
                            <input id="btnBack" value="Back" onclick="AnimateBack('#C1', 'easeInOutExpo');" class="WS_Buttons_Style" />
                            <asp:Label ID="lblFileName1" runat="server" CssClass="DisplayNone"></asp:Label>
                            <asp:HiddenField ID="hdnFileName1" runat="server"></asp:HiddenField>
                            <asp:Label ID="lblFileName2" runat="server" CssClass="DisplayNone"></asp:Label>
                            <asp:HiddenField ID="hdnFileName2" runat="server"></asp:HiddenField>
                            <asp:Label ID="lblFileName3" runat="server" CssClass="DisplayNone"></asp:Label>
                            <asp:HiddenField ID="hdnFileName3" runat="server"></asp:HiddenField>
                        </div>
                        <div>
                            <iframe id="Iframe1" runat="server" frameborder="1" marginwidth="1" class="EditProduct"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnSelectBehalf" runat="server" Value="" />
    <asp:HiddenField ID="hdnUserBehalf" runat="server" Value="" />
    <asp:HiddenField ID="hdnDeptBehalf" runat="server" Value="" />
    <asp:HiddenField ID="hdnPrintReadyFile" runat="server" Value="" />
    <asp:HiddenField ID="hdnSingleQuestionValues" runat="server" Value="" />
    <asp:HiddenField ID="hdnArtWorkDeleted1" runat="server" Value="" />
    <asp:HiddenField ID="hdnArtWorkDeleted2" runat="server" Value="" />
    <asp:HiddenField ID="hdnArtWorkDeleted3" runat="server" Value="" />
    <asp:HiddenField runat="server" ID="hdnDecoration1" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost1" />

    <asp:HiddenField runat="server" ID="hdnDecoration2" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost2" />

    <asp:HiddenField runat="server" ID="hdnDecoration3" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost3" />

     <asp:HiddenField runat="server" ID="hdnDecoration4" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost4" />

     <asp:HiddenField runat="server" ID="hdnDecoration5" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost5" />

    <asp:HiddenField runat="server" ID="hdnDecoration6" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost6" />



    <%--<telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
        <script type="text/javascript">
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            function OpenUploadFile() {
                window.radopen("", "RadWindow1");
            }      
        </script>
    </telerik:RadScriptBlock>--%>
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/progress_File.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        var RequestType = '<%=RequestType %>';
        var hdnPrintReadyFile = document.getElementById("<%=hdnPrintReadyFile.ClientID %>");
        var artworkFile = '<%=artworkFile%>';
        var spn_artworkFile = document.getElementById("<%=spn_artworkFile.ClientID %>");
        var spn_artworkFile1 = document.getElementById("<%=spn_artworkFile1.ClientID %>");
        var lblfp_artwork = document.getElementById("<%=lblfp_artwork.ClientID %>");
        var lblfp_artwork_no_addoption1 = document.getElementById("<%=lblfp_artwork_no_addoption1.ClientID %>");
        var fp_artwork = document.getElementById("<%=fp_artwork.ClientID %>");
        var fp_artwork_no_addoption1 = document.getElementById("<%=fp_artwork_no_addoption1.ClientID %>");

        var hid_matixType = document.getElementById("<%=hid_matixType.ClientID %>");
        var hid_qtyFromList = document.getElementById("<%=hid_qtyFromList.ClientID %>");
        var hid_qtyToList = document.getElementById("<%=hid_qtyToList.ClientID %>");
        var hid_priceList = document.getElementById("<%=hid_priceList.ClientID %>");
        var hdnsoldPackOV = document.getElementById("<%=hdnsoldPackOV.ClientID %>");
        var hid_CostExcMarkupList = document.getElementById("<%=hid_CostExcMarkupList.ClientID %>");
        var hid_MarkupList = document.getElementById("<%=hid_MarkupList.ClientID %>");
        var hid_QuantityPrice = document.getElementById("<%=hid_QuantityPrice.ClientID %>");
        var hid_QuantityPriceExcMarkup = document.getElementById("<%=hid_QuantityPriceExcMarkup.ClientID %>");
        var hid_Markup = document.getElementById("<%=hid_Markup.ClientID %>");
        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");
        var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
        var hid_MatrixLenght = document.getElementById("<%=hid_MatrixLenght.ClientID %>");
        var hid_QuestionTextFreeLenght = document.getElementById("<%=hid_QuestionTextFreeLenght.ClientID %>");
        
        var hid_SaveToCart = document.getElementById("<%=hid_SaveToCart.ClientID %>");
        var hid_SaveToCartItems = document.getElementById("<%=hid_SaveToCartItems.ClientID %>");
        var hid_MultipleMatrixValues = document.getElementById("<%=hid_MultipleMatrixValues.ClientID %>");
        var hid_SaveToAdditionalItems = document.getElementById("<%=hid_SaveToAdditionalItems.ClientID %>");
        var hid_TempTotalPrice = document.getElementById("<%=hid_TempTotalPrice.ClientID %>");
        var hid_Quantity_Edit = document.getElementById("<%=hid_Quantity_Edit.ClientID %>");
        var hdn_height = document.getElementById("<%=hdn_height.ClientID %>");
        var hdn_width = document.getElementById("<%=hdn_width.ClientID %>");
        var hid_totalPrice_Edit = document.getElementById("<%=hid_totalPrice_Edit.ClientID %>");
        var hdnSingleQuestionValues = document.getElementById("<%=hdnSingleQuestionValues.ClientID %>");
        var divUserBehalf = document.getElementById("<%=divUserBehalf.ClientID %>");
        var divDeptBehalf = document.getElementById("<%=divDeptBehalf.ClientID %>");
        var divSelectBehalf = document.getElementById("<%=divSelectBehalf.ClientID %>");
        var txtHeight = document.getElementById("txtHeight");
        var txtWidth = document.getElementById("txtWidth");
        var hdnArtWorkDeleted1 = document.getElementById("<%=hdnArtWorkDeleted1.ClientID %>");
        var hdnArtWorkDeleted2 = document.getElementById("<%=hdnArtWorkDeleted2.ClientID %>");
        var hdnArtWorkDeleted3 = document.getElementById("<%=hdnArtWorkDeleted3.ClientID %>");

        var rdbstkorder = document.getElementById("<%=rdbstkorder.ClientID %>");
        var rdstkbreplenish = document.getElementById("<%=rdstkbreplenish.ClientID %>");

        var lbltotal = document.getElementById("lbltotal");
        var TotalTaxValue = document.getElementById("lblTotalTax").innerHTML.replace("javascript:GetCurrencyinRequiredFormate('', true);", '');
        var TotalSellingPriceValue = document.getElementById("lblTotalSellingPrice").innerHTML.replace("javascript:GetCurrencyinRequiredFormate('', true);", '');

        var hdnlbltotal = document.getElementById("hdnlbltotal");
        var hdnTotalTaxValue = document.getElementById("hdnlblTotalTax");
        var hdnTotalSellingPriceValue = document.getElementById("hdnlblTotalSellingPrice");

        var hdn_orderedheight = document.getElementById("<%=hdn_orderedheight.ClientID %>");
        var hdn_orderedwidth = document.getElementById("<%=hdn_orderedwidth.ClientID %>");
        var hdn_orderedarea = document.getElementById("<%=hdn_orderedarea.ClientID %>");
        var hdn_orderedquantity = document.getElementById("<%=hdn_orderedquantity.ClientID %>");

        var hdn_Decoration1 = document.getElementById("<%=hdnDecoration1.ClientID %>");
        var hdn_Decoration2 = document.getElementById("<%=hdnDecoration2.ClientID %>");
        var hdn_Decoration3 = document.getElementById("<%=hdnDecoration3.ClientID %>");
        var hdn_Decoration4 = document.getElementById("<%=hdnDecoration4.ClientID %>");
        var hdn_Decoration5 = document.getElementById("<%=hdnDecoration5.ClientID %>");
        var hdn_Decoration6 = document.getElementById("<%=hdnDecoration6.ClientID %>");

        var hdn_DecorationCost1 = document.getElementById("<%=hdnDecorationCost1.ClientID %>");
        var hdn_DecorationCost2 = document.getElementById("<%=hdnDecorationCost2.ClientID %>");
        var hdn_DecorationCost3 = document.getElementById("<%=hdnDecorationCost3.ClientID %>");
        var hdn_DecorationCost4 = document.getElementById("<%=hdnDecorationCost4.ClientID %>");
        var hdn_DecorationCost5 = document.getElementById("<%=hdnDecorationCost5.ClientID %>");
        var hdn_DecorationCost6 = document.getElementById("<%=hdnDecorationCost6.ClientID %>");

        var decoration1_Mandadory = '<%=Decoration1_Mandadory %>';
        var decoration2_Mandadory = '<%=Decoration2_Mandadory %>';
        var decoration3_Mandadory = '<%=Decoration3_Mandadory %>';
        var decoration4_Mandadory ='<%=Decoration4_Mandadory %>';
        var decoration5_Mandadory ='<%=Decoration5_Mandadory %>';
        var decoration6_Mandadory = '<%=Decoration6_Mandadory %>';

        var decname1 = '<%=name1 %>';
        var decname2 = '<%=name2 %>';
        var decname3 = '<%=name3 %>';
        var decname4 ='<%=name4 %>';
        var decname5 ='<%=name5 %>';
        var decname6 = '<%=name6 %>';

      

        var isPDMyCartRightPannel = '<%=isPDMyCartRightPannel%>';
        if (isPDMyCartRightPannel == "0") {
            rightPanel_contents.style.display = "none";
        }

        var ProductID = '<%=PriceCatalogueID %>';

        if (hid_matixType.value == "P") {
            var Qty = document.getElementById("txtqty").value;
            document.getElementById("txtqty").focus();
        }
        else if (hid_matixType.value == "G") {
            var Qty = document.getElementById("txtqty").value;
            document.getElementById("txtqty").focus();
        }
        else {
            if (IsCumulative == "true") {
                var txt_Cumulative_PriceQty = document.getElementById("ctl00_ContentPlaceHolder1_txt_Cumulative_PriceQty");
                var txt_Cumulative_PriceQty_Text = txt_Cumulative_PriceQty.text;
                var txt_Cumulative_PriceQty_Value = txt_Cumulative_PriceQty.value;
            } else {
                var ddlPriceQty = document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty");
                var ddlPriceQtyText = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                var ddlPriceQtyvalue = ddlPriceQty.options[ddlPriceQty.selectedIndex].value;
            }
            Tocalculate_totalPrice('0', '0');
            CheckStockAvailability('0');
        }
        var spn_qty = document.getElementById("spn_qty");
        var spn_Dimensn = document.getElementById("spn_Dimensn");
        var spnDimensn = document.getElementById("spnDimensn");
        var div_PriceList = document.getElementById("div_PriceList");
        var div_PriceListMore = document.getElementById("div_PriceListMore");
        var divCustCode = document.getElementById("divCustCode");
        var divItemCode = document.getElementById("divItemCode");
        var isCustomerCode = '<%=isCustomerCode %>';
        var isItemCode = '<%=isItemCode %>';
        var SelectedDeptUser = '<%=SelectedDeptUser %>';
        var errase = document.getElementById("imge1");

        function HideArtworkName(id, Position) {

            var lblfp_artwork = document.getElementById("ctl00_ContentPlaceHolder1_lblfp_artwork" + id);
            var ImgButtonErase = document.getElementById("ctl00_ContentPlaceHolder1_ImgButtonErase" + id);
            var fp_artwork = document.getElementById("ctl00_ContentPlaceHolder1_fp_artwork" + id);

            lblfp_artwork.style.display = "none";
            ImgButtonErase.style.display = "none";
            fp_artwork.style.display = "block";
            lblfp_artwork.innerHTML = "";

            if (Position == '1') {
                hdnArtWorkDeleted1.value = "true";
            }
            else if (Position == '2') {
                hdnArtWorkDeleted2.value = "true";
            }
            else {
                hdnArtWorkDeleted3.value = "true";
            }

        }

        function ValidateFileUpload(Source, args) {

            var fuData = document.getElementById("<%=Upload.ClientID%>");
            var FileUploadPath = fuData.value;


            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                if (Extension == "csv") {
                    var divext = document.getElementById("Spn_ImageUploadFile");
                    divext.style.display = 'none';

                    args.IsValid = true; // Valid file type
                }
                else {
                    fuData.value = '';
                    var divext = document.getElementById("Spn_ImageUploadFile");
                    divext.style.display = 'block';

                    args.IsValid = false; // Not valid file type                        
                }
            }
        }

        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                VisibleAdditionaloption(ddlMultiple.getAttribute('weothercostid'));
            }
        }

    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            var keyCode = (window.event) ? e.which : e.keyCode;
            if (keyCode && keyCode == 13) {
                e.preventDefault();
                return false;
            }
        });

        window.onload = dispCustCodeandItemcode;

        setHeight();
        setmargin();
    </script>
    <style>
        #nav, #nav ul {
            /* all lists */
            padding: 12px;
            margin: 10px;
            list-style: none;
            line-height: 1;
        }
    </style>
</asp:Content>
