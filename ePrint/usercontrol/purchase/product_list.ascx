<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_list.ascx.cs" Inherits="ePrint.usercontrol.purchase.product_list" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style>
    .whitespace_nowrap {
        white-space: nowrap;
    }
</style>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridAvailableCustomers">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="link_clrfilt_Warehous" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridProductList" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
<div align="center" style="width: 96%;">
    <div style="margin-top: -20px;">
        <div id="padding">
            <div align="center" id="div_InvItems" runat="server" style="width: 100%; padding-top: 5px;">
                <div style="width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="width: 100%;">
                                <div id="link_invent" style="text-align: left; width: 100%; padding-bottom: 5px; padding-top: 5px; margin-left: -2%;">
                                    <asp:LinkButton ID="link_clrfilt_Warehous" Style="text-decoration: underline; cursor: pointer"
                                        runat="server" Text="Clear_All_Filters" OnClick="clrFilters_Click_inventry" />
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_Main" runat="server" align="center" style="width: 100%; margin-left: -2%; border: 0px solid red;">
                                <div id="div_Grid">
                                     <telerik:RadGrid ID="GridProductList" runat="server" AllowPaging="true" PageSize="50" AllowCustomPaging="true"
                                        ShowStatusBar="true" Visible="true" Width="1050px" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left" ShowHeader="true" OnPageSizeChanged="GridProductList_PageSizeChanged"
                                        PagerStyle-AlwaysVisible="true" OnItemDataBound="GridProductList_OnRowDataBound"  OnPageIndexChanged="GridProductList_PageIndexChanged"  
                                        OnNeedDataSource="GridProductList_OnNeedDataSource" Skin="RadGrid_Eprint_Skin" OnItemCommand="GridProductList_ItemCommand"
                                        EnableEmbeddedSkins="false" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" FilterItemStyle-Wrap="true"
                                        CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                        PagerStyle-Wrap="true" AllowSorting="true" AllowFilteringByColumn="true">
                                        <GroupingSettings CaseSensitive="false" />
                                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <MasterTableView DataKeyNames="PriceCatalogueID" TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                    ItemStyle-Width="3%" Visible="true">
                                                    <HeaderTemplate>
                                                        <input id="checkAll_1" runat="server" name="checkAll" onclick="CheckAll_checkBoxes(this);"
                                                            type="checkbox" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input id="Id_1" runat="server" name="Id_1" onclick="CheckChanged();" type="checkbox"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                        <asp:HiddenField ID="hid_PriceCatalogueID" runat="server" Value='<%#Eval("PriceCatalogueID") %>' />
                                                        
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Item Code" HeaderStyle-Width="10%"
                                                    ItemStyle-Width="10%" DataField="ItemCode" UniqueName="ItemCode" SortExpression="ItemCode"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemCode" CssClass="normalText" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                 <telerik:GridTemplateColumn HeaderStyle-Width="10%" HeaderText="Item Title" ItemStyle-Width="10%"
                                                    DataField="ItemTitle" SortExpression="ItemTitle" UniqueName="ItemTitle" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemTitle" CssClass="normalText" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                                        <asp:Label ID="lblDrawStockFrom" Style="display: none;" runat="server" Text='<%#Eval("DrawStockFrom")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderStyle-Width="10%" HeaderText="Supplier" DataField="Supplier"
                                                    ItemStyle-Width="12%" UniqueName="Supplier" SortExpression="Supplier" AllowFiltering="true"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSupplierName" runat="server" Text='<%#Eval("Supplier")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Current Stock" HeaderStyle-Width="10%" DataField="CurrentStock"
                                                    UniqueName="CurrentStock" SortExpression="CurrentStock" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%" ItemStyle-Height="20px" AllowFiltering="true" HeaderStyle-HorizontalAlign="Right"
                                                    ItemStyle-HorizontalAlign="Right" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCurrentStock" runat="server" Text='<%#Eval("CurrentStock")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Allocated Stock" HeaderStyle-Width="10%"
                                                    DataField="AllocatedStock" SortExpression="AllocatedStock" UniqueName="AllocatedStock"
                                                    ItemStyle-Wrap="false" ItemStyle-Width="10%" AllowFiltering="true" ItemStyle-Height="20px"
                                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllocatedStock" runat="server" Text='<%#Eval("AllocatedStock")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Available Stock" HeaderStyle-Width="10%"
                                                    DataField="AvailableStock" UniqueName="AvailableStock" SortExpression="AvailableStock"
                                                    ItemStyle-Wrap="false" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right"
                                                    ItemStyle-Height="20px" AllowFiltering="true" HeaderStyle-HorizontalAlign="Right"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAvailableStock" runat="server" Text='<%#Eval("AvailableStock")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Stock Type" HeaderStyle-Width="10%"
                                                    DataField="StockType" UniqueName="StockType" SortExpression="StockType"
                                                    ItemStyle-Wrap="false" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                    ItemStyle-Height="20px" AllowFiltering="true" HeaderStyle-HorizontalAlign="Left"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStockType" CssClass="normalText" runat="server" Text='<%#Eval("StockType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Additional Options" HeaderStyle-Width="10%"
                                                    ItemStyle-Width="10%" DataField="AdditionalOptions" UniqueName="AdditionalOptions"
                                                    SortExpression="AdditionalOptions" ItemStyle-HorizontalAlign="Right"  AllowFiltering="false"
                                                    HeaderStyle-HorizontalAlign="Right" Display="false">
                                                    <HeaderStyle CssClass="whitespace_nowrap rgHeader rgHeaderOver" />
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hid_DrawStockFrom" runat="server" Value='<%#Eval("DrawStockFrom") %>' />
                                                        <asp:HiddenField ID="hid_PurchaseACcodeID" runat="server" Value='<%#Eval("PurAccountingCode") %>' />
                                                        <asp:DropDownList ID="ddlAddItems" runat="server" Visible="false" Width="75px">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="Hdn_PricelistFrom" runat="server" Value='0' />
                                                        <asp:HiddenField ID="Hdn_PricelistTo" runat="server" Value='0' />
                                                        <asp:HiddenField ID="Hdn_PricelistCostExcMarkup" runat="server" Value='0' />
                                                        <asp:HiddenField ID="hid_MarkupList" runat="server" Value='0' />
                                                        <asp:HiddenField ID="Hdn_SellingPrice" runat="server" Value='0' />
                                                        <asp:HiddenField ID="hid_matixType" runat="server" Value='0' />
                                                        <asp:HiddenField ID="hdn_IsCumulative" runat="server" Value='0' />
                                                        <asp:HiddenField ID="hdnFinal_QuantityPrice" runat="server" Value='0' />
                                                        <asp:HiddenField ID="hdn_ItemDescription" runat="server" Value='<%#Eval("ItemDescription") %>' />
                                                        <asp:HiddenField ID="hdn_FinalItemDescription" runat="server" Value='' />
                                                        <asp:HiddenField ID="hid_SalesTaxRate" runat="server" Value='0' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Quantity to Order" HeaderStyle-Width="10%"
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                    HeaderStyle-HorizontalAlign="Right">
                                                    <HeaderStyle CssClass="whitespace_nowrap rgHeader rgHeaderOver" />
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQuantityToOrder" CssClass="textboxnew" runat="server" Text=""
                                                            Style="text-align: right;" Width="50%" onfocus="javascript:Quantity_SelectFocus(this.id)" onkeypress="return IntergerValidation(event)"></asp:TextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                
                                                  <telerik:GridTemplateColumn HeaderText="Replenishment" HeaderStyle-Width="10%"
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                    HeaderStyle-HorizontalAlign="Right">
                                                    <HeaderStyle CssClass="whitespace_nowrap rgHeader rgHeaderOver" />
                                                    <ItemTemplate>
                                                        <input id="Checkboxrpt" runat="server" name="checkRpt" OnChange="btnAdd_OnClick" type="checkbox" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings AllowExpandCollapse="True">
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="right" id="div1" runat="server" style="width: 1030px; padding-top: 5px;">
                <div id="div_OtherCost_btn_Next" style="float: right;">
                    <div id="div_btnskip" style="display: block">
                        <asp:Button ID="btnAdd" CssClass="button" runat="server" Text="Add"  OnClientClick=" return CheckchkOne('add');" OnClick="btnAdd_Click" />
                    </div>
                    <div id="div_skipprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: right; width: 10px">
                    &nbsp;
                </div>
                <div style="float: right;">
                    <div id="div_btnfinish">
                        <asp:Button ID="btnAddClose" CssClass="button" runat="server" Text="Add & Close" 
                            OnClientClick="return CheckchkOne('add_close');" />
                    </div>
                    <div id="div_finishprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
</div>
<div>
    <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
</div>
<input value='0' id='hdn_orderedquantity' type='hidden' />
<input value='0' id='hid_QuantityPriceExcMarkup' type='hidden' />
<input value='0' id='hid_QuantityPrice' type='hidden' />

<script type="text/javascript">
    function CheckAll_checkBoxes(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1) e.checked = ChkState;
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) e.checked = ChkState;
        }
    }

    function CheckChanged() {
        debugger;
        var frm = '';
        frm = document.forms[0];

        var boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }
</script>

<script language="javascript" type="text/javascript">
    var pw = window.parent;
    function CheckchkOne(Type) {

        debugger;
        var Counter = 0;
        var frm = document.forms[0];
        var Ides = "";
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    var txtQuantityToOrder = document.getElementById(e.id.replace('Id_1', 'txtQuantityToOrder'));
                    Counter = Number(Counter) + 1;
                    var lblItemCode = document.getElementById(e.id.replace('Id_1', 'lblItemCode'));
                    var lblItemTitle = document.getElementById(e.id.replace('Id_1', 'lblItemTitle'));
                    var lblSupplierName = document.getElementById(e.id.replace('Id_1', 'lblSupplierName'));
                    var lblDrawStockFrom = document.getElementById(e.id.replace('Id_1', 'lblDrawStockFrom'));
                    var ddl = document.getElementById(e.id.replace('Id_1', 'ddlAddItems_' + e.value));
                    var Price = document.getElementById(e.id.replace('Id_1', 'hdnFinal_QuantityPrice_' + e.value));
                    var ItemDescription = document.getElementById(e.id.replace('Id_1', 'hdn_FinalItemDescription_' + e.value));
                    var hid_SalesTaxRate = document.getElementById(e.id.replace('Id_1', 'hid_SalesTaxRate_' + e.value));
                    var hid_PurchaseACcodeID = document.getElementById(e.id.replace('Id_1', 'hid_PurchaseACcodeID_' + e.value));
                    var AdditionVal = "";
                    var AdditionText = "";
                    if (ddl != null) {
                        AdditionText = ddl.options[ddl.selectedIndex].text;
                        AdditionVal = ddl.options[ddl.selectedIndex].value;
                    }
                    Ides = Ides + e.value + "µ" + lblItemCode.innerHTML + "µ" + ItemDescription.value + "µ" + lblDrawStockFrom.innerHTML + "µ" + txtQuantityToOrder.value + "µ" + AdditionText + "µ" + AdditionVal + "µ" + Price.value + "µ" + hid_SalesTaxRate.value + "µ" + hid_PurchaseACcodeID.value + "†";
                }
            }
        }

        if (Number(Counter) == 0) {
            //alert("Please check at least one 'row' to Add");
            alert('<%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Add")%>');
            return false;
        }
        else {
            Ides = Ides.substring(0, (Ides.length) - 1);
            var Id_Array = Ides.split('†');
            for (var i = 0; i < Id_Array.length; i++) {
                var Id_sprt = Id_Array[i];
                var Id_sprt2 = Id_sprt.split('µ');
                var Desc = Id_sprt2[2];
                if (Id_sprt2[5] != "") {
                    Desc = Desc + "\nAdditional Option:" + Id_sprt2[5];
                }
                pw.hdnDrawStockFrom.value = Id_sprt2[3];
                pw.hdnAdditionalID.value = Id_sprt2[6];
                pw.hdnOnlyItemTitle.value = Id_sprt2[2];


                pw.AddMoreItem(Id_sprt2[0], Id_sprt2[1], Desc, Id_sprt2[4], 0, Id_sprt2[7], 'W', '', 0, 0, 0, '', Id_sprt2[8], 0, Id_sprt2[9]);
                //AddMoreItem(ItemID, ItemCode, ItemName, Qty, PackedIn, Price, ItemType, IsDisplay, PerQty, PerPrice, PackedPrice, StockType, SalesTaxRate);
            }
            if (Type == "add_close") {
                window.close();
            }
        }
    }

    function Quantity_SelectFocus(id) {
        var txtQty = document.getElementById(id).value;
        var chkBx = document.getElementById(id.replace('txtQuantityToOrder', 'Id_1'));
        chkBx.checked = true;
    }

    function IntergerValidation(evt) {
        var charCode = (evt.which) ? evt.which : window.event.keyCode;

        if (charCode <= 13) {
            return true;
        }
        else {
            var keyChar = String.fromCharCode(charCode);
            var re = /[0-9]/
            return re.test(keyChar);
        }
    }
    function Tocalculate_totalPrice(Qty, PriceCatalogueID) {
        debugger;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    if (PriceCatalogueID == e.value) {
                        var hid_qtyFromList = document.getElementById(e.id.replace('Id_1', 'Hdn_PricelistFrom_' + e.value));
                        var hid_CostExcMarkupList = document.getElementById(e.id.replace('Id_1', 'Hdn_PricelistCostExcMarkup_' + e.value));
                        var hid_priceList = document.getElementById(e.id.replace('Id_1', 'Hdn_SellingPrice_' + e.value));
                        var hid_Markup = document.getElementById(e.id.replace('Id_1', 'hid_MarkupList_' + e.value));
                        var hid_matixType = document.getElementById(e.id.replace('Id_1', 'hid_matixType_' + e.value));
                        var hid_IsCumulative = document.getElementById(e.id.replace('Id_1', 'hdn_IsCumulative_' + e.value));
                        var hid_qtyToList = document.getElementById(e.id.replace('Id_1', 'Hdn_PricelistTo_' + e.value));
                        var hdnFinal_QuantityPrice = document.getElementById(e.id.replace('Id_1', 'hdnFinal_QuantityPrice_' + e.value));
                        var txtQuantityToOrder = document.getElementById(e.id.replace('Id_1', 'txtQuantityToOrder'));
                        var hid_SalesTaxRate = document.getElementById(e.id.replace('Id_1', 'hid_SalesTaxRate_' + e.value));
                    }
                }
            }
        }
        var IsCumulative = hid_IsCumulative.value;
        var arrQtyFrom = hid_qtyFromList.value.split('µ');
        var arrQtyTo = hid_qtyToList.value.split('µ');
        var arrCost = hid_CostExcMarkupList.value.split('µ');
        var arrPrice = hid_priceList.value.split('µ');
        var arrMarkup = hid_Markup.value.split('µ');
        TempSubTotal = 0;
        for (var j = 0; j < arrQtyTo.length - 1; j++) {
            if (j == arrQtyTo.length - 2) {
                QtyEndsTo = Number(arrQtyTo[j]);
            }
        }

        for (var i = 0; i < arrQtyFrom.length - 1; i++) {
            if (hid_matixType.value == "P") {
                if (Qty != '' && Number(Qty)) {

                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }


                    hdn_orderedquantity.value = Number(Qty);

                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        //hdnFinal_QuantityPrice.value = ActualPrice;
                        hdnFinal_QuantityPrice.value = hid_QuantityPriceExcMarkup.value;
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        //hdnFinal_QuantityPrice.value = ActualPrice;
                        hdnFinal_QuantityPrice.value = hid_QuantityPriceExcMarkup.value;
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        //hdnFinal_QuantityPrice.value = ActualPrice;
                        hdnFinal_QuantityPrice.value = hid_QuantityPriceExcMarkup.value;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            //hdnFinal_QuantityPrice.value = ActualPrice;
                            hdnFinal_QuantityPrice.value = hid_QuantityPriceExcMarkup.value;
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            hdnFinal_QuantityPrice.value = "0";
                        }
                    }
                }
                else {
                    if (!Number(Qty)) {
                        document.getElementById("txtqty").value = "";
                    }
                    else {
                        hdn_orderedquantity.value = Number(Qty);
                    }
                    hid_QuantityPrice.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                }
            }
            else if (hid_matixType.value == "G") {

            }
            else {

                if (IsCumulative == "true") {
                    if (Qty != '' && Number(Qty)) {

                        if (i == 0) {
                            QtyStartsfrom = Number(arrQtyFrom[i]);
                        }
                        hdn_orderedquantity.value = Number(Qty);
                        if (Number(Qty) > Number(QtyEndsTo)) {
                            alert("Maximum quantity is " + QtyEndsTo + "");
                            hdnFinal_QuantityPrice.value = "0.00";
                            txtQuantityToOrder.value = "";
                            break;
                        }
                        else if (Number(Qty) <= Number(arrQtyFrom[i])) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            hdnFinal_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            hdnFinal_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            hdnFinal_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else {
                            if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                                hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                                var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                                hid_QuantityPrice.value = ActualPrice;
                                hdnFinal_QuantityPrice.value = ActualPrice;
                                break;
                            }
                            else {
                                hid_QuantityPrice.value = "0";
                                hid_QuantityPriceExcMarkup.value = "0";
                            }
                        }
                    }
                    else {
                        hid_QuantityPrice.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                    }
                } else {
                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        var sellingPrice = arrPrice[i].split('~');
                        hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                        hid_QuantityPrice.value = sellingPrice[1];
                        QtyStartsfrom = arrQtyTo[i];
                        QtyEndsTo = arrQtyTo[i];
                        hdnFinal_QuantityPrice.value = sellingPrice[0];
                        hdn_orderedquantity.value = arrQtyTo[i];
                        break;
                    }
                    if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        var sellingPrice = arrPrice[i].split('~');
                        hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                        hid_QuantityPrice.value = sellingPrice[1];
                        QtyStartsfrom = arrQtyTo[i];
                        QtyEndsTo = arrQtyTo[i];
                        hdnFinal_QuantityPrice.value = sellingPrice[0];
                        hdn_orderedquantity.value = arrQtyTo[i];
                        break;
                    }
                    if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        var sellingPrice = arrPrice[i + 1].split('~');
                        hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                        hid_QuantityPrice.value = sellingPrice[1];
                        QtyStartsfrom = arrQtyTo[i];
                        QtyEndsTo = arrQtyTo[i];
                        hdnFinal_QuantityPrice.value = sellingPrice[0];
                        hdn_orderedquantity.value = arrQtyTo[i];
                        break;
                    }
                    if (Number(Qty) > Number(QtyEndsTo)) {
                        var sellingPrice = arrPrice[arrPrice.length - 2].split('~');
                        hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                        hid_QuantityPrice.value = sellingPrice[1];
                        hdnFinal_QuantityPrice.value = sellingPrice[0];
                        hdn_orderedquantity.value = arrQtyTo[i];
                        break;
                    }
                }
            }
        }

    }

</script>
