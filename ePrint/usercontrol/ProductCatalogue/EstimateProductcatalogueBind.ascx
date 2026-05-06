<%@ control language="C#" autoeventwireup="true" CodeBehind="EstimateProductcatalogueBind.ascx.cs" Inherits="ePrint.usercontrol.ProductCatalogue.EstimateProductcatalogueBind" %>

<script type="text/javascript" src="<%=strSitepath %>js/item/item_pricecatalog.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<div>
    <asp:HiddenField ID="hdn_drawstockfrom" runat="server" Value="" />
    <asp:HiddenField ID="hdn_isbackorder" runat="server" Value="0" />
    <asp:HiddenField ID="hidCatalogueID" runat="server" Value="0" />
    <asp:HiddenField ID="hid_IsSides" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_StockManagement" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_kitavailibility" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_returnboolvalue" runat="server" Value="" />
    <asp:HiddenField ID="hdn_cataloguename" runat="server" Value="" />
    <asp:HiddenField ID="hid_catalogue_items" runat="server" />
    <asp:HiddenField ID="hdnDrawStockFrom" runat="server" />
    <asp:HiddenField ID="hdnQtyNumber" runat="server" Value="" />
    <asp:HiddenField ID="hid_matixType" runat="server" Value="" />
    <asp:HiddenField ID="hid_qtyFromList" runat="server" Value="0" />
    <asp:HiddenField ID="hdnUnitOfMeasure" runat="server" Value="0" />
    <asp:HiddenField ID="hid_qtyToList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_CostExcMarkupList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_MarkupList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Markup" runat="server" Value="0" />
    <asp:HiddenField ID="hid_priceList" runat="server" Value="0" />
    <asp:HiddenField ID="hdnLabelqtyPrice1" runat="server" Value="" />
    <asp:HiddenField ID="hdnLabelqtyPrice2" runat="server" Value="" />
    <asp:HiddenField ID="hdnLabelqtyPrice3" runat="server" Value="" />
    <asp:HiddenField ID="hdnLabelqtyPrice4" runat="server" Value="" />
    <asp:HiddenField ID="hid_QuestionLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hid_QuestionTextFreeLenght" runat="server" />
    <asp:HiddenField ID="hid_MultipleLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hid_MatrixLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hidCatalogueData" runat="server" />
    <asp:HiddenField ID="hid_GetItemDescription" runat="server" />
    <asp:HiddenField ID="hidCatalogueDataOnEdit" runat="server" Value="" />
    <asp:HiddenField ID="hdn_title" runat="server" Value="" />
    <asp:HiddenField ID="hdn_description" runat="server" Value="" />
    <asp:HiddenField ID="hdn_artwork" runat="server" Value="" />
    <asp:HiddenField ID="hdn_color" runat="server" Value="" />
    <asp:HiddenField ID="hdn_size" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Material" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Delivery" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Finish" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Proofs" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Packing" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Notes" runat="server" Value="" />
    <asp:HiddenField ID="hdn_terms" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription1" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription2" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription3" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription4" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription5" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription6" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription7" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription8" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription9" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription10" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription11" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription12" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription13" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription14" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription15" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription16" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription17" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription18" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription19" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription20" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription21" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription22" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription23" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription24" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription25" runat="server" Value="" />
    <asp:HiddenField ID="hdn_txttotalquantity" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />
    <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
    <asp:HiddenField ID="hdn_allselectedqty" runat="server" Value="" />
    <asp:HiddenField ID="hid_OldPriceCatalogueID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
    <asp:HiddenField ID="hid_Price_CustomerID" runat="server" />
    <asp:HiddenField ID="hid_Customer_Name" runat="server" />
    <asp:HiddenField ID="hid_PriceCatalogueID" runat="server" Value="0" />
    <asp:HiddenField ID="hdnJobStatusID" runat="server" Value="" />
    <asp:HiddenField ID="hid_Price_Data" runat="server" />
    <asp:HiddenField ID="hid_QuantityPrice1" runat="server" />
    <asp:HiddenField ID="hid_QuantityPrice2" runat="server" />
    <asp:HiddenField ID="hid_QuantityPrice3" runat="server" />
    <asp:HiddenField ID="hid_QuantityPrice4" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup1" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup2" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup3" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup4" runat="server" />
    <asp:HiddenField ID="hdn_allTypesAOTotal" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTempfield1" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTempfield2" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTempfield3" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTempfield4" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_allTempSubTotal" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_parenturl" runat="server" Value="" />
    <asp:HiddenField ID="hdnddl_req_qty_1" runat="server" Value="" />
    <asp:HiddenField ID="hdnddl_req_qty_2" runat="server" Value="" />
    <asp:HiddenField ID="hdnddl_req_qty_3" runat="server" Value="" />
    <asp:HiddenField ID="hdnddl_req_qty_4" runat="server" Value="" />
    <asp:HiddenField ID="hid_UpdateToOrderItems" runat="server" />
    <asp:HiddenField ID="hdn_chkitemdescription" runat="server" Value="false" />
    <asp:HiddenField ID="hdnOrderedHeight1" runat="server" />
    <asp:HiddenField ID="hdnOrderedHeight2" runat="server" />
    <asp:HiddenField ID="hdnOrderedHeight3" runat="server" />
    <asp:HiddenField ID="hdnOrderedHeight4" runat="server" />
    <asp:HiddenField ID="hdnOrderedwidth1" runat="server" />
    <asp:HiddenField ID="hdnOrderedwidth2" runat="server" />
    <asp:HiddenField ID="hdnOrderedwidth3" runat="server" />
    <asp:HiddenField ID="hdnOrderedwidth4" runat="server" />
    <asp:HiddenField ID="hdnOrderedarea1" runat="server" />
    <asp:HiddenField ID="hdnOrderedarea2" runat="server" />
    <asp:HiddenField ID="hdnOrderedarea3" runat="server" />
    <asp:HiddenField ID="hdnOrderedarea4" runat="server" />
    <asp:HiddenField ID="hdn_orderedquantity1" runat="server" Value="" />
    <asp:HiddenField ID="hdn_orderedquantity2" runat="server" Value="" />
    <asp:HiddenField ID="hdn_orderedquantity3" runat="server" Value="" />
    <asp:HiddenField ID="hdn_orderedquantity4" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Update_Item_Descriptions" runat="server" Value="false" />
    <asp:HiddenField ID="hdn_SoldInPacksof" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_ReturnSoldInPacksof" runat="server" Value="true" />
    <asp:HiddenField ID="hdn_IsCumulative" runat="server" Value="false" />
    <asp:HiddenField ID="hdn_isAddMore" runat="server" Value ="0" />
     <asp:HiddenField runat="server" ID="hdnDecoration1" />
    <asp:HiddenField runat="server" ID="hdnDecoration2" />
    <asp:HiddenField runat="server" ID="hdnDecoration3" />
    <asp:HiddenField runat="server" ID="hdnDecoration4" />
    <asp:HiddenField runat="server" ID="hdnDecoration5" />
    <asp:HiddenField runat="server" ID="hdnDecoration6" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost1" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost2" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost3" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost4" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost5" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost6" />


    <script>

        var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");
        var hdn_allselectedqty = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allselectedqty");
        var hdn_allTempSubTotal = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allTempSubTotal");
        var hdn_allTypesAOTotal = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allTypesAOTotal");
        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");

        var Alert_Msg = "<%=Alert_Msg%>";
        var Measurementvalue = '<%=Measurementvalue %>';
        var ItemName = '<%=objLanguage.GetLanguageConversion("Item_Name") %>';
        var Quantity = '<%=objLanguage.GetLanguageConversion("Quantity") %>';
        var Price = '<%=objLanguage.GetLanguageConversion("Price") %>';
        var strImagepath = "<%=strImagepath %>";
        var SimpleMatBrowserHandy = '<%=SimpleMatBrowserHandy %>';
        var IsStockItem = '<%=IsStockItem%>';
        var IsDirectJob = '<%=IsDirectJob%>';

        var hdn_DecorationCost1 = document.getElementById("<%=hdnDecorationCost1.ClientID %>");
        var hdn_DecorationCost2 = document.getElementById("<%=hdnDecorationCost2.ClientID %>");
        var hdn_DecorationCost3 = document.getElementById("<%=hdnDecorationCost3.ClientID %>");
        var hdn_DecorationCost4 = document.getElementById("<%=hdnDecorationCost4.ClientID %>");
        var hdn_DecorationCost5 = document.getElementById("<%=hdnDecorationCost5.ClientID %>");
        var hdn_DecorationCost6 = document.getElementById("<%=hdnDecorationCost6.ClientID %>");

        var hdn_Decoration1 = document.getElementById("<%=hdnDecoration1.ClientID %>");
        var hdn_Decoration2 = document.getElementById("<%=hdnDecoration2.ClientID %>");
        var hdn_Decoration3 = document.getElementById("<%=hdnDecoration3.ClientID %>");
        var hdn_Decoration4 = document.getElementById("<%=hdnDecoration4.ClientID %>");
        var hdn_Decoration5 = document.getElementById("<%=hdnDecoration5.ClientID %>");
        var hdn_Decoration6 = document.getElementById("<%=hdnDecoration6.ClientID %>");

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

    </script>
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

        var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");
        var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
        var hid_QuestionTextFreeLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionTextFreeLenght");
        var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
        var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");


        var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
        var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
        var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
        var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

        var hid_qtyFromList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_qtyFromList");
        var hid_qtyToList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_qtyToList");
        var hid_priceList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_priceList");
        var hid_CostExcMarkupList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_CostExcMarkupList");
        var hid_MarkupList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MarkupList");
        var hid_Markup = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_Markup");

        var hid_QuantityPrice1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice1");
        var hid_QuantityPrice2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice2");
        var hid_QuantityPrice3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice3");
        var hid_QuantityPrice4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice4");

        var hdnTempfield1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield1");
        var hdnTempfield2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield2");
        var hdnTempfield3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield3");
        var hdnTempfield4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield4");


        var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup");
        var hid_QuantityPriceExcMarkup2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup2");
        var hid_QuantityPriceExcMarkup3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup3");
        var hid_QuantityPriceExcMarkup4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup4");


        var hid_SaveToAdditionalItems = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_SaveToAdditionalItems");
        var hid_UpdateToOrderItems = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_UpdateToOrderItems");

        var hid_PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_PriceCatalogueID");
        var hid_OldPriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_OldPriceCatalogueID");
        var ManageStockPermission = '<%=ManageStockPermission %>';
        var StockCancellationType = '<%=StockCancellationType %>';
        var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

        var lbltotal1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_lbltotal1");
        var lbltotal2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_lbltotal2");
        var lbltotal3 = document.getElementById("cctl00_ContentPlaceHolder1_ctl00_lbltotal3");
        var lbltotal4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_lbltotal4");


        var hdnOrderedHeight1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedHeight1");
        var hdnOrderedHeight2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedHeight2");
        var hdnOrderedHeight3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedHeight3");
        var hdnOrderedHeight4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedHeight4");

        var hdnOrderedwidth1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedwidth1");
        var hdnOrderedwidth2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedwidth2");
        var hdnOrderedwidth3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedwidth3");
        var hdnOrderedwidth4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedwidth4");

        var hdnOrderedarea1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedarea1");
        var hdnOrderedarea2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedarea2");
        var hdnOrderedarea3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedarea3");
        var hdnOrderedarea4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnOrderedarea4");

        var hdn_orderedquantity1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_orderedquantity1");
        var hdn_orderedquantity2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_orderedquantity2");
        var hdn_orderedquantity3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_orderedquantity3");
        var hdn_orderedquantity4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_orderedquantity4");

        var hdn_Update_Item_Descriptions = document.getElementById("chk_Update_Item_Descriptions");
        var hdn_IsCumulative = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_IsCumulative");

    </script>
    <asp:LinkButton ID="lnkCatalogueFinish" runat="server" OnClick="btnCatalogueFinish_OnClick"></asp:LinkButton>
    <div id="div_price_qty_valid" style="display: none; margin-top: -10px; padding-top: 0px;"
        align="center">
        <div align="center" style="width: 35%; padding: 0px 0px 30px 0px;">
            <span id="span_price_qty_valid" class="spanerrorMsg">Please enter at least one quantity</span>
        </div>
    </div>
     <div id="div_ProductSelect_valid" style="display: none; margin-top: -10px; padding-top: 0px;"
        align="center">
        <div align="center" style="width: 35%; padding: 0px 0px 30px 0px;">
            <span id="span_ProductSelect_valid" style="width: 50%; margin-left: 60px;" class="spanerrorMsg">Please select product</span>
        </div>
    </div>
    <asp:Panel ID="pnlOtherMultiple" runat="server" Visible="false">
        <div style="float: left; width: 100%">
            <div id="div_OtherMultipleProducts" class="bgLabelnew" style="width: 11.7%; text-align: left; margin-left: 4.9px;">
                Other Multiple Products
            </div>
            <div class="box" style="width: 40%; text-align: left">
                <asp:DropDownList ID="ddlOtherMultiple" Width="72%" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlOtherMultiple_OnSelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <%--  <div style="clear: both">
        </div>--%>
    </asp:Panel>
    <asp:Panel ID="pnlOtherMultiple1" runat="server" Visible="false">
        <div style="float: left; width: 100%">
            <div id="div_OtherMultipleProducts1" class="bgLabelnew" style="width: 11.7%; text-align: left; margin-left: 4.9px;">
                Other Multiple Products
            </div>
            <div class="box" style="width: 40%; text-align: left">
                <asp:DropDownList ID="ddlOtherMultiple1" Width="72%" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlOtherMultiple1_OnSelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <%--  <div style="clear: both">
        </div>--%>
    </asp:Panel>
    <asp:Panel ID="pnlOtherMultiple2" runat="server" Visible="false">
        <div style="float: left; width: 100%">
            <div id="div_OtherMultipleProducts2" class="bgLabelnew" style="width: 11.7%; text-align: left; margin-left: 4.9px;">
                Other Multiple Products
            </div>
            <div class="box" style="width: 40%; text-align: left">
                <asp:DropDownList ID="ddlOtherMultiple2" Width="72%" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlOtherMultiple2_OnSelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <%--  <div style="clear: both">
        </div>--%>
    </asp:Panel>
    <asp:Panel ID="pnlCatalogue" runat="server" Style="display: none">
        <div id="div_pnlCatalogue" runat="server" style="display: block;">
            <%--  <div class="onlyEmpty">
            </div>--%>
            <div class="removeTrancy">
                <div align="left">
                    <%--  <div class="only5px">
                    </div>--%>
                    <div style="padding-left: 3px;" id="div_plh">
                        <asp:PlaceHolder ID="plhCatalogueList" runat="server"></asp:PlaceHolder>
                    </div>
                    <%--  <div class="only5px">
                    </div>--%>
                </div>
            </div>
            <%--  <div class="onlyEmpty">
            </div>--%>
        </div>
        <%--     <div style="clear: both;">
        </div>--%>
        <br />
        <div id="pnlAdditionalOption" runat="server" style="display: none; margin-top: 10px; padding: 2px 0px 0px 5px; border: 0px solid red; height: 400px; overflow-y: scroll;">
            <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
            <div id="Div_BackSave" runat="server" style="display: none; float: left; padding: 10px 0px 10px 275px;">
                <div style="display: inline; float: left">
                    <div id="div_btnback" style="display: block">
                        <asp:Button ID="btnBack" CssClass="button" Text="Back" Width="65px" runat="server"
                            OnClientClick="javascript:var a=prevpnlCatalogue();if(a)loadingimg('div_btnback','div_btnbackprocess');return a;" />
                    </div>
                    <div id="div_btnbackprocess" class="button" align="center" style="width: 47px; display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 5px">
                    &nbsp;
                </div>
                <div style="display: inline; float: right">
                    <div id="div_btnsave" style="display: block">
                        <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                            OnClientClick="javascript:var a=Save_OrderItems('saveandgo');if(a)loadingimg('div_btnsave','div_btnsaveprocess');return false;" />
                        <asp:LinkButton ID="lnkbtnSave" runat="server" OnClick="Onclick_btnSave"></asp:LinkButton>
                    </div>
                    <div id="div_btnsaveprocess" class="button" align="center" style="width: 47px; display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                    </div>
                </div>


                <%-- start --%>
                <div style="float: right; width: 5px">
                    &nbsp;
                </div>

                <div id="divNewAdd" style="display:none; float: right" runat="server">
                    <div id="div_btnsave_new" style="display: block">
                        <asp:Button ID="Button1" CssClass="button" Text="Save & Add Another" Width="130px" runat="server"
                            OnClientClick="javascript:var a=Save_OrderItems('addmore');if(a)loadingimg('div_btnsave_new','div_btnsaveprocess_new');return false;" />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Onclick_btnSave"></asp:LinkButton>
                    </div>
                    <div id="div_btnsaveprocess_new" class="button" align="center" style="width: 47px; display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                    </div>
                </div>

                <%-- end --%>


            </div>
        </div>
    </asp:Panel>
</div>
<div style="clear: both">
</div>
<script type="text/javascript">
    //PRICE CATALOGUE     
    var hid_Price_Data = document.getElementById("<%=hid_Price_Data.ClientID %>");
    var div_price_catalogue = document.getElementById("div_price_catalogue");
    var hidCatalogueData = document.getElementById("<%=hidCatalogueData.ClientID %>");
    var RequestType = '<%=Request.QueryString["type"]%>';
    var ClientID = "<%=Pub_CustomerID %>";
    var ClienName = "<%=Pub_CustomerName %>";
    var CompanyID = '<%=CompanyID %>'
    var UserID = '<%=UserID %>'
    var modulename = '<%=modulename%>';
    var Please_enter_height = '<%=objLanguage.GetLanguageConversion("Please_enter_height") %>';
    var Please_enter_width = '<%=objLanguage.GetLanguageConversion("Please_enter_width") %>';
    var Noofi = '<%=Noofi%>';
    var MainType = '<%=MainType%>';
    var MatrixType = '<%=MatrixType%>';
    var MaxQuantity = '<%=MaxQuantity%>';
</script>
<script type="text/javascript">
    function Getitemdescription() {
        var hid_GetItemDescription = document.getElementById("<%=hid_GetItemDescription.ClientID %>");
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_item_title").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_design").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_art").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_color").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_size").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_material").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_delivery").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_finishing").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_Proofs").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_Packing").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_notes").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtcatalogue_terms").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription1").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription2").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription3").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription4").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription5").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription6").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription7").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription8").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription9").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription10").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription11").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription12").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription13").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription14").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription15").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription16").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription17").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription18").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription19").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription20").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription21").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription22").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription23").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription24").value + '~';
        hid_GetItemDescription.value += document.getElementById("txtCustomDiscription25").value + '~';

        document.getElementById("<%=hdn_title.ClientID %>").value = document.getElementById("txtcatalogue_item_title").value;
        document.getElementById("<%=hdn_description.ClientID %>").value = document.getElementById("txtcatalogue_design").value;
        document.getElementById("<%=hdn_artwork.ClientID %>").value = document.getElementById("txtcatalogue_art").value;
        document.getElementById("<%=hdn_color.ClientID %>").value = document.getElementById("txtcatalogue_color").value
        document.getElementById("<%=hdn_size.ClientID %>").value = document.getElementById("txtcatalogue_size").value;
        document.getElementById("<%=hdn_Material.ClientID %>").value = document.getElementById("txtcatalogue_material").value;
        document.getElementById("<%=hdn_Delivery.ClientID %>").value = document.getElementById("txtcatalogue_delivery").value;
        document.getElementById("<%=hdn_Finish.ClientID %>").value = document.getElementById("txtcatalogue_finishing").value;
        document.getElementById("<%=hdn_Proofs.ClientID %>").value = document.getElementById("txtcatalogue_Proofs").value;
        document.getElementById("<%=hdn_Packing.ClientID %>").value = document.getElementById("txtcatalogue_Packing").value;
        document.getElementById("<%=hdn_Notes.ClientID %>").value = document.getElementById("txtcatalogue_notes").value;
        document.getElementById("<%=hdn_terms.ClientID %>").value = document.getElementById("txtcatalogue_terms").value;

        document.getElementById("<%=hdn_CustomDescription1.ClientID %>").value = document.getElementById("txtCustomDiscription1").value;
        document.getElementById("<%=hdn_CustomDescription2.ClientID %>").value = document.getElementById("txtCustomDiscription2").value;
        document.getElementById("<%=hdn_CustomDescription3.ClientID %>").value = document.getElementById("txtCustomDiscription3").value;
        document.getElementById("<%=hdn_CustomDescription4.ClientID %>").value = document.getElementById("txtCustomDiscription4").value;
        document.getElementById("<%=hdn_CustomDescription5.ClientID %>").value = document.getElementById("txtCustomDiscription5").value;
        document.getElementById("<%=hdn_CustomDescription6.ClientID %>").value = document.getElementById("txtCustomDiscription6").value;
        document.getElementById("<%=hdn_CustomDescription7.ClientID %>").value = document.getElementById("txtCustomDiscription7").value;
        document.getElementById("<%=hdn_CustomDescription8.ClientID %>").value = document.getElementById("txtCustomDiscription8").value;
        document.getElementById("<%=hdn_CustomDescription9.ClientID %>").value = document.getElementById("txtCustomDiscription9").value;
        document.getElementById("<%=hdn_CustomDescription10.ClientID %>").value = document.getElementById("txtCustomDiscription10").value;
        document.getElementById("<%=hdn_CustomDescription11.ClientID %>").value = document.getElementById("txtCustomDiscription11").value;
        document.getElementById("<%=hdn_CustomDescription12.ClientID %>").value = document.getElementById("txtCustomDiscription12").value;
        document.getElementById("<%=hdn_CustomDescription13.ClientID %>").value = document.getElementById("txtCustomDiscription13").value;
        document.getElementById("<%=hdn_CustomDescription14.ClientID %>").value = document.getElementById("txtCustomDiscription14").value;
        document.getElementById("<%=hdn_CustomDescription15.ClientID %>").value = document.getElementById("txtCustomDiscription15").value;
        document.getElementById("<%=hdn_CustomDescription16.ClientID %>").value = document.getElementById("txtCustomDiscription16").value;
        document.getElementById("<%=hdn_CustomDescription17.ClientID %>").value = document.getElementById("txtCustomDiscription17").value;
        document.getElementById("<%=hdn_CustomDescription18.ClientID %>").value = document.getElementById("txtCustomDiscription18").value;
        document.getElementById("<%=hdn_CustomDescription19.ClientID %>").value = document.getElementById("txtCustomDiscription19").value;
        document.getElementById("<%=hdn_CustomDescription20.ClientID %>").value = document.getElementById("txtCustomDiscription20").value;
        document.getElementById("<%=hdn_CustomDescription21.ClientID %>").value = document.getElementById("txtCustomDiscription21").value;
        document.getElementById("<%=hdn_CustomDescription22.ClientID %>").value = document.getElementById("txtCustomDiscription22").value;
        document.getElementById("<%=hdn_CustomDescription23.ClientID %>").value = document.getElementById("txtCustomDiscription23").value;
        document.getElementById("<%=hdn_CustomDescription24.ClientID %>").value = document.getElementById("txtCustomDiscription24").value;
        document.getElementById("<%=hdn_CustomDescription25.ClientID %>").value = document.getElementById("txtCustomDiscription25").value;

    }

</script>
<script>


    function Norowsalert() {
        alert('<%=objLanguage.GetLanguageConversion("No_Rows_ProductCatalogue_Alert")%>');
        GetRadWindow().close();
    }
    var isProceedable = true;
    var IsEmptyorZero = true;

    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
            VisibleAdditionaloption(ddlMultiple.getAttribute('weothercostid'));
        }
    }

    function UpdateCount(txt, index) {
        // get calculation type
        var calcType = document.getElementById("hdn_FreeTextQuestion_CalculationType_" + index)?.value || "l";

        var limit = calcType.toLowerCase() === "f" ? 100 : 1000;

        if (txt.value.length > limit) {
            txt.value = txt.value.substring(0, limit);
        }

        // update counter text
        var countSpan = document.getElementById("cnt_txtFreeTextQuestion_" + index);
        if (countSpan) {

            countSpan.innerHTML = txt.value.length + "/" + limit;

            // color handling
            if (txt.value.length >= limit) {
                countSpan.style.color = "red";
                txt.style.borderColor = "red";
            } else {
                countSpan.style.color = "#555";
                txt.style.borderColor = "";
            }
        }
    }

    //function UpdateCount(txt, index) {
    //    var max = parseInt(txt.getAttribute("maxlength"));
    //    var current = txt.value.length;

    //    if (current >= max) {
    //        txt.value = txt.value.substring(0, max);
    //        current = max;
    //    }

    //    var cnt = document.getElementById("cnt_txtFreeTextQuestion_" + index);
    //    cnt.innerHTML = current + "/" + max;

    //    if (current >= max) {
    //        cnt.style.color = "red";
    //    } else {
    //        cnt.style.color = "green";
    //    }
    //}


    function funcBtnNextonclick(PriceCatalogueID, CatalogueName, MatrixType) {

        debugger;
        IsEmptyorZero = true;
        var priceCatID = PriceCatalogueID;
        var CatName = CatalogueName;
        var MatType = MatrixType;
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple") != null && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple") != undefined) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple").value == "--Select--") {
                document.getElementById("div_ProductSelect_valid").style.display = "block";
                return false;
            }
        }
        storeToArrayAO(priceCatID, CatName, MatType);
        if (IsEmptyorZero) {
            Getitemdescription();
            SaveCataloguetwo();
            if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value === "true") {
                if (isProceedable) {
                    document.getElementById("div_plh").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_pnlAdditionalOption").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_Div_BackSave").style.display = "block";
                    if (document.getElementById("div_OtherMultipleProducts") != null && document.getElementById("div_OtherMultipleProducts") != undefined) {
                        document.getElementById("div_OtherMultipleProducts").style.width = "250px";
                    }

                    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");
                    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
                    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
                    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");

                    if (hid_matixType.value == "P") {
                        for (var k = 1; k <= 4; k++) {
                            var spn_Total_QtyPrice = document.getElementById("spn_Total_QtyPrice_" + k + "");
                            var txt_req_qty = document.getElementById("txt_req_qty_" + k + "");
                            var Labelqtytxt = document.getElementById("Labelqtytxt" + k + "");
                            var LabelqtyPricetxt = document.getElementById("LabelqtyPricetxt" + k + "");
                            var lbltotal = document.getElementById("lbltotal" + k + "");

                            if (txt_req_qty.value == '') {

                                Labelqtytxt.innerHTML = '';
                                LabelqtyPricetxt.innerHTML = '';
                                lbltotal.innerHTML = '';
                                if (hid_QuestionLenght.value != "0") {
                                    for (var j = 0; j <= hid_QuestionLenght.value - 1; j++) {
                                        document.getElementById("lblPrice" + k + "_" + j + "").innerHTML = '';
                                    }
                                }
                                if (hid_MatrixLenght.value != "0") {
                                    for (var j = 0; j <= hid_MatrixLenght.value - 1; j++) {
                                        document.getElementById("lblMatrixPrice" + k + "_" + j + "").innerHTML = '';
                                    }
                                }
                                if (hid_MultipleLenght.value != "0") {
                                    for (var i = 0; i <= hid_MultipleLenght.value - 1; i++) {
                                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                } else {
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                    document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                }
                                            }
                                        } else {
                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                }
                            }
                            else {
                                if (hid_MultipleLenght.value != "0") {
                                    for (var i = 0; i <= hid_MultipleLenght.value - 1; i++) {
                                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                } else {
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                    document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                }
                                            }
                                        } else {
                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                }
                                //for quantity1.
                                Labelqtytxt.innerHTML = txt_req_qty.value;
                                //for Price.
                                LabelqtyPricetxt.innerHTML = spn_Total_QtyPrice.innerHTML;

                                lbltotal.innerHTML = LabelqtyPricetxt.innerHTML;
                            }
                        }
                    }
                    else if (hid_matixType.value == "G") {
                        for (var k = 1; k <= 4; k++) {
                            var spn_Total_QtyPrice = document.getElementById("spn_Total_QtyPrice_" + k + "");
                            var txt_req_qty = document.getElementById("txt_req_qty_" + k + "");
                            var Labelqtytxt = document.getElementById("Labelqtytxt" + k + "");
                            var LabelqtyPricetxt = document.getElementById("LabelqtyPricetxt" + k + "");
                            var lbltotal = document.getElementById("lbltotal" + k + "");

                            if (txt_req_qty.value == '') {

                                Labelqtytxt.innerHTML = '';
                                LabelqtyPricetxt.innerHTML = '';
                                lbltotal.innerHTML = '';
                                if (hid_QuestionLenght.value != "0") {
                                    for (var j = 0; j <= hid_QuestionLenght.value - 1; j++) {
                                        document.getElementById("lblPrice" + k + "_" + j + "").innerHTML = '';
                                    }
                                }
                                if (hid_MatrixLenght.value != "0") {
                                    for (var j = 0; j <= hid_MatrixLenght.value - 1; j++) {
                                        document.getElementById("lblMatrixPrice" + k + "_" + j + "").innerHTML = '';
                                    }
                                }
                                if (hid_MultipleLenght.value != "0") {
                                    for (var i = 0; i <= hid_MultipleLenght.value - 1; i++) {
                                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                } else {
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                    document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                }
                                            }
                                        } else {
                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                }
                            }
                            else {

                                if (hid_MultipleLenght.value != "0") {
                                    for (var i = 0; i <= hid_MultipleLenght.value - 1; i++) {
                                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                } else {
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                    document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                    document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                }
                                            }
                                        } else {
                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                }
                                //for quantity1.
                                Labelqtytxt.innerHTML = txt_req_qty.value;
                                //for Price.
                                LabelqtyPricetxt.innerHTML = spn_Total_QtyPrice.innerHTML;
                                lbltotal.innerHTML = LabelqtyPricetxt.innerHTML;
                            }
                        }
                    }
                    else {
                        if (SimpleMatBrowserHandy == 'yes') {
                            for (var k = 1; k <= 4; k++) {

                                var ddltxt_req_qty = document.getElementById("ddltxt_req_qty_" + k + "");
                                var lbltotal = document.getElementById("lbltotal" + k + "");
                                var Labelqty = document.getElementById("Labelqty" + k + "");
                                //Total Label - 1 spn_Total_QtyPrice_1
                                if (ddltxt_req_qty.value == 0 && ddltxt_req_qty.value == '') {
                                    if (hid_QuestionLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                                            document.getElementById("lblPrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                    if (hid_MatrixLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MatrixLenght.value) - 1; i++) {
                                            document.getElementById("lblMatrixPrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                    if (hid_MultipleLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                        if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                            for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                                var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                                document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                            }
                                                        } else {
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                }
                                            } else {
                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                            }
                                        }
                                    }
                                    document.getElementById("Labelqty" + k + "").innerHTML = '';
                                    document.getElementById("LabelqtyPrice" + k + "").innerHTML = '';
                                    lbltotal.innerHTML = '';
                                }
                                else {

                                    if (hid_MultipleLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                        if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                            for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                                var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                                document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                            }
                                                        } else {
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                }
                                            } else {
                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                            }
                                        }
                                    }
                                    var SelectedQuantity = '';
                                    var ddlObj = document.getElementById("ddltxt_req_qty_" + k + "");
                                    if (ddlObj != null && ddlObj != '' && ddlObj != 'undefiend') {
                                        SelectedQuantity = ddlObj.value;//.options[ddlObj.selectedIndex].text;
                                    }
                                    Labelqty.innerHTML = SelectedQuantity;
                                    var LabelqtyPrice = document.getElementById("LabelqtyPrice" + k + "");
                                    LabelqtyPrice.innerHTML = document.getElementById("spn_Total_QtyPrice_" + k + "").innerHTML;
                                }
                            }
                        }
                        else {
                            var Check = true;
                            for (var k = 1; k <= 4; k++) {

                                if (hdn_IsCumulative.value == "true") {
                                    var ddl_req_qty = document.getElementById("txt_Cumulative_PriceQty_" + k + "");
                                } else {
                                    var ddl_req_qty = document.getElementById("ddl_req_qty_" + k + "");
                                }
                                var lbltotal = document.getElementById("lbltotal" + k + "");
                                var Labelqty = document.getElementById("Labelqty" + k + "");
                                //Total Label - 1 spn_Total_QtyPrice_1

                                if (hdn_IsCumulative.value == "true") {
                                    if (ddl_req_qty.value == 0 && ddl_req_qty.value != '0') {
                                        Check = false;
                                    } else {
                                        Check = true;
                                    }
                                } else {
                                    if (ddl_req_qty.selectedIndex == 0 && ddl_req_qty.options[ddl_req_qty.selectedIndex].text == 'select') {
                                        Check = false;
                                    } else {
                                        Check = true;
                                    }
                                }

                                if (!Check) {
                                    if (hid_QuestionLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                                            document.getElementById("lblPrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                    if (hid_MatrixLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MatrixLenght.value) - 1; i++) {
                                            document.getElementById("lblMatrixPrice" + k + "_" + i + "").innerHTML = '';
                                        }
                                    }
                                    if (hid_MultipleLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                        if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                            for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                                var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                                document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                            }
                                                        } else {
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                }
                                            } else {
                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                            }
                                        }
                                    }
                                    document.getElementById("Labelqty" + k + "").innerHTML = '';
                                    document.getElementById("LabelqtyPrice" + k + "").innerHTML = '';
                                    lbltotal.innerHTML = '';
                                }
                                else {
                                    if (hid_MultipleLenght.value != "0") {
                                        for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                                if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                                    ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '') {
                                                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                                        if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                                            for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                                                var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = '';
                                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";

                                                                document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                            }
                                                        } else {
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                            document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                        }
                                                    } else {
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").innerHTML = '';
                                                        document.getElementById("lblMultiplePrice" + k + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + "0").style.display = "block";

                                                        document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + k).style.display = 'block';
                                                    }
                                                }
                                            } else {
                                                document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                                            }
                                        }
                                    }

                                    var SelectedQuantity = '';
                                    if (hdn_IsCumulative.value == "true") {
                                        var ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + k + "");
                                        if (ddlObj != null && ddlObj != '' && ddlObj != 'undefiend') {
                                            SelectedQuantity = ddlObj.value;
                                        }
                                    } else {
                                        var ddlObj = document.getElementById("ddl_req_qty_" + k + "");
                                        if (ddlObj != null && ddlObj != '' && ddlObj != 'undefiend') {
                                            SelectedQuantity = ddlObj.options[ddlObj.selectedIndex].text;
                                        }
                                    }
                                    Labelqty.innerHTML = SelectedQuantity;
                                    var LabelqtyPrice = document.getElementById("LabelqtyPrice" + k + "");
                                    LabelqtyPrice.innerHTML = document.getElementById("spn_Total_QtyPrice_" + k + "").innerHTML;
                                }
                            }
                        }
                    }
                    Tocall_mainFunc();
                    document.getElementById("<%=pnlCatalogue.ClientID %>").style.display = "block";
                    return false;
                }
            }
        }
    }

    function SaveCataloguetwo() {
        var Data = '';
        for (var i = 0; i < Price_Array.length; i++) {
            var objArr = Price_Array[i];
            Data += "PriceCatalogueID»" + objArr.PriceCatalogueID + "±";
            Data += "Quantity»" + objArr.Quantity + "±";
            Data += "Price»" + roundNumber(objArr.Price, 2) + "±";
            Data += "Cost»" + objArr.Cost + "±";
            Data += "CatalogueName»" + objArr.CatalogueName + "±";
            Data += "MultipleOf»" + objArr.MultipleOf + "±";
            Data += "Markup»" + objArr.Markup + "±";
            Data += "Height»" + objArr.Height + "±";
            Data += "Width»" + objArr.Width + "±";
            //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
            //    Data += "ReplenishProduct»" + objArr.ReplenishProduct + "±";
            //} else {
            //    Data += "ReplenishProduct»false±";
            //}
            Data += "ReplenishProduct»" + objArr.ReplenishProduct + "±";
            Data += "QtyusedforCalculation»" + objArr.QtyusedforCalculation + "µ";
        }
        if (Data == '') {
            isProceedable = false;
            return false;
        }
        else {
            hidCatalogueData.value = Data;
            isProceedable = true;
            return false;
        }
    }

    function prevpnlCatalogue() {
        //------------------- 
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_Div_BackSave").style.display = "none";
        document.getElementById("div_plh").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_pnlAdditionalOption").style.display = "none";
        if (document.getElementById("div_OtherMultipleProducts") != null && document.getElementById("div_OtherMultipleProducts") != undefined) {
            document.getElementById("div_OtherMultipleProducts").style.width = "11.7%";
        }
        return false;
    }

    function onddlChanged(ddlObj, index) {
        debugger;
        for (var k = 1; k <= 4; k++) {
            if (index == k) {
                //To access Total Selling Price($) as----->Price($).
                var hdnLabelqtyPrice = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnLabelqtyPrice" + k + "");
                var spn_Total_QtyPrice_1 = document.getElementById("spn_Total_QtyPrice_" + k + "");
                var LabelqtyPrice1 = document.getElementById("LabelqtyPrice" + k + "");
                LabelqtyPrice1.innerHTML = spn_Total_QtyPrice_1.innerHTML;
                hdnLabelqtyPrice.value = LabelqtyPrice1.innerHTML;

                //To access Selected quantity1 as---->quantity1.
                var hdnddl_req_qty = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnddl_req_qty_" + k + "");
                var selectedindexval1 = ddlObj.options[ddlObj.selectedIndex].text;
                var lblDescription1 = document.getElementById("Labelqty" + k + "");
                lblDescription1.innerHTML = selectedindexval1;
                hdnddl_req_qty.value = lblDescription1.innerHTML;
                return false;
            }
        }
    }

    if (MainType == 'edit' && hid_PriceCatalogueID.value == '<%=PriceCatalogueID%>') {
        if (MatrixType == 'G' || MatrixType == 'P') {
            var txt_req_qty_1 = document.getElementById("txt_req_qty_1");
            var txt_req_qty_2 = document.getElementById("txt_req_qty_2");
            var txt_req_qty_3 = document.getElementById("txt_req_qty_3");
            var txt_req_qty_4 = document.getElementById("txt_req_qty_4");
            CalculateQtyPrice(txt_req_qty_1, txt_req_qty_1.value, '1', Noofi);
            CalculateQtyPrice(txt_req_qty_2, txt_req_qty_2.value, '2', Noofi);
            CalculateQtyPrice(txt_req_qty_3, txt_req_qty_3.value, '3', Noofi);
            CalculateQtyPrice(txt_req_qty_4, txt_req_qty_4.value, '4', Noofi);

            if (MatrixType == 'G') {
                var txt_Width_1 = document.getElementById("txt_Width_1");
                var txt_Width_2 = document.getElementById("txt_Width_2");
                var txt_Width_3 = document.getElementById("txt_Width_3");
                var txt_Width_4 = document.getElementById("txt_Width_4");
                var txt_Height_1 = document.getElementById("txt_Height_1");
                var txt_Height_2 = document.getElementById("txt_Height_2");
                var txt_Height_3 = document.getElementById("txt_Height_3");
                var txt_Height_4 = document.getElementById("txt_Height_4");
                roundUp(txt_Width_1.id, txt_Width_1.value, '<%=RoundOff%>');
                roundUp(txt_Width_2.id, txt_Width_2.value, '<%=RoundOff%>');
                roundUp(txt_Width_3.id, txt_Width_3.value, '<%=RoundOff%>');
                roundUp(txt_Width_4.id, txt_Width_4.value, '<%=RoundOff%>');
                roundUp(txt_Height_1.id, txt_Height_1.value, '<%=RoundOff%>');
                roundUp(txt_Height_2.id, txt_Height_2.value, '<%=RoundOff%>');
                roundUp(txt_Height_3.id, txt_Height_3.value, '<%=RoundOff%>');
                roundUp(txt_Height_4.id, txt_Height_4.value, '<%=RoundOff%>');
            }
        } else if (MatrixType == 'S') {
            if (SimpleMatBrowserHandy == 'yes') {
                var ddltxt_req_qty_1 = document.getElementById("ddltxt_req_qty_1");
                var ddltxt_req_qty_2 = document.getElementById("ddltxt_req_qty_2");
                var ddltxt_req_qty_3 = document.getElementById("ddltxt_req_qty_3");
                var ddltxt_req_qty_4 = document.getElementById("ddltxt_req_qty_4");
                TakeSellPrice_Handy(ddltxt_req_qty_1, ddltxt_req_qty_1.value, '1', 1);
                TakeSellPrice_Handy(ddltxt_req_qty_2, ddltxt_req_qty_2.value, '2', 1);
                TakeSellPrice_Handy(ddltxt_req_qty_3, ddltxt_req_qty_3.value, '3', 1);
                TakeSellPrice_Handy(ddltxt_req_qty_4, ddltxt_req_qty_4.value, '4', 1);
            } else {
                if (hdn_IsCumulative.value == "true") {
                    var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                    var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                    var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                    var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                    CalculateQtyPrice(ddl_req_qty_1, ddl_req_qty_1.value, '1', Noofi);
                    CalculateQtyPrice(ddl_req_qty_2, ddl_req_qty_2.value, '2', Noofi);
                    CalculateQtyPrice(ddl_req_qty_3, ddl_req_qty_3.value, '3', Noofi);
                    CalculateQtyPrice(ddl_req_qty_4, ddl_req_qty_4.value, '4', Noofi);

                } else {
                    var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                    var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                    var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                    var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                    TakeSellPrice(ddl_req_qty_1, '1');
                    TakeSellPrice(ddl_req_qty_2, '2');
                    TakeSellPrice(ddl_req_qty_3, '3');
                    TakeSellPrice(ddl_req_qty_4, '4');
                }
            }
        }
    }

    function CancelandSelectDiffProduct() {
        GetRadWindow().close();
    }

</script>

