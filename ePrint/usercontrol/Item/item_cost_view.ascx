<%@ control language="C#" autoeventwireup="true" CodeBehind="item_cost_view.ascx.cs" Inherits="ePrint.usercontrol.Item.item_cost_view"  enableviewstate="false" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="divLoading" style="display: block; width: 200px; height: 50px; position: absolute;
    top: 45%; left: 45%">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript" language="javascript">
    var CompanyID = "<%=CompanyID %>";
    var para = "<%=para %>";
    var UserID = "<%=UserID %>";
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "none";

</script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/item_cost_view_new.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var divLoading = document.getElementById("divLoading");
    setLoadingPositionOfDivMove(divLoading);
</script>
<div style="width: 750px;">
    &nbsp;</div>
<div id="div_loading" align="left" style="position: absolute; height: 50px; width: 200px;
    top: 45%; left: 45%; display: none;">
    <UC:Loading ID="Loading1" runat="server" />
</div>
<asp:Panel ID="pnlCostView" runat="server" Visible="false">
    <div align="left" id="div_Complete" runat="server">
        <div align="left" style="width: 100%;">
            <%--<div style="width: 100%;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <asp:Label ID="lblCostViewTitle" runat="server">Item Cost Centre View</asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>--%>
            <div style="margin-top: -15px">
                <%-- class="divBorderItem"--%>
                <div align="left" style="width: 100%;">
                    <asp:Label ID="lblCostViewTitle" runat="server" Style="display: none">Item Cost Centre View</asp:Label>
                    <div align="left">
                        <div align="left" style="padding-left: 10px; width: 100%;">
                            <asp:PlaceHolder ID="plhItemCostView" runat="server"></asp:PlaceHolder>
                            <div id="div_ZoneTotal" runat="server" style="display: none">
                                <asp:Label ID="Zone_TotalSellingPrice1" runat="server" CssClass="normalText"></asp:Label><br />
                                <asp:Label ID="Zone_TotalSellingPrice2" runat="server" CssClass="normalText"></asp:Label><br />
                                <asp:Label ID="Zone_TotalSellingPrice3" runat="server" CssClass="normalText"></asp:Label><br />
                                <asp:Label ID="Zone_TotalSellingPrice4" runat="server" CssClass="normalText"></asp:Label>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <%--Below Div are not used because it giveing the Design issues--%>
                        </div>
                        <div align="left" style="width: 100%; clear: both; display: none;">
                            <div style="float: right; width: 20%;">
                                <div style="float: left;">
                                    <asp:Button ID="btnCancelItemView" CssClass="button" OnClientClick="javascript:window.close();"
                                        runat="server" Text="Cancel" />
                                </div>
                                <div style="float: left; width: 10px;">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button ID="btnSaveItemView" CssClass="button" OnClientClick="javascript:return ItemMarkupSave();"
                                        runat="server" Style="display: none;" Text="Save" OnClick="lnkbtnSaveItemView_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdn_Markup" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_Markup2" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_Markup3" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_Markup4" runat="server" Value="0" />
                <asp:HiddenField ID="hidItemList" runat="server" Value="" />
                <asp:HiddenField ID="hdn_SaveItemViewMarkup" runat="server" Value="" />
                <asp:HiddenField ID="hdn_LithoMarkup" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_PriceSubCnt" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_ZoneSide2Markup" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_PressType" runat="server" Value="" />
                <asp:HiddenField ID="hdn_ZoneSideColor1" runat="server" Value="" />
                <asp:HiddenField ID="hdn_ZoneSideColor2" runat="server" Value="" />
                <asp:HiddenField ID="hdn_ZoneSaveItem" runat="server" Value="" />
                <asp:HiddenField ID="hdn_IsDoubleSided" runat="server" Value="false" />
                <asp:HiddenField ID="hdn_MarkupPrice1" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_MarkupPrice2" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_MarkupPrice3" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_MarkupPrice4" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_CostExMarkup1" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_CostExMarkup2" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_CostExMarkup3" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_CostExMarkup4" runat="server" Value="0" />

                <asp:HiddenField ID="hdn_MarkupValue2" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_MarkupValue3" runat="server" Value="0" />
                <asp:HiddenField ID="hdn_MarkupValue4" runat="server" Value="0" />

                <script type="text/javascript">

                    var hdn_SaveItemViewMarkup = document.getElementById("<%=hdn_SaveItemViewMarkup.ClientID %>");
                    var MarkupIdList = "<%=MarkupIdList %>";
                    var hdn_Markup = document.getElementById("<%=hdn_Markup.ClientID %>");
                    var hdn_Markup2 = document.getElementById("<%=hdn_Markup2.ClientID %>");
                    var hdn_Markup3 = document.getElementById("<%=hdn_Markup3.ClientID %>");
                    var hdn_Markup4 = document.getElementById("<%=hdn_Markup4.ClientID %>");
                    var hdn_LithoMarkup = document.getElementById("<%=hdn_LithoMarkup.ClientID %>");
                    var hdn_PriceSubCnt = document.getElementById("<%=hdn_PriceSubCnt.ClientID %>");
                    var hdn_ZoneSide2Markup = document.getElementById("<%=hdn_ZoneSide2Markup.ClientID %>");
                    var hdn_PressType = document.getElementById("<%=hdn_PressType.ClientID %>");
                    var hdn_ZoneSideColor1 = document.getElementById("<%=hdn_ZoneSideColor1.ClientID %>");
                    var hdn_ZoneSideColor2 = document.getElementById("<%=hdn_ZoneSideColor2.ClientID %>");
                    var hdn_ZoneSaveItem = document.getElementById("<%=hdn_ZoneSaveItem.ClientID %>");

                    var hdn_MarkupPrice1 = document.getElementById("<%=hdn_MarkupPrice1.ClientID %>");
                    var hdn_MarkupPrice2 = document.getElementById("<%=hdn_MarkupPrice2.ClientID %>");
                    var hdn_MarkupPrice3 = document.getElementById("<%=hdn_MarkupPrice3.ClientID %>");
                    var hdn_MarkupPrice4 = document.getElementById("<%=hdn_MarkupPrice4.ClientID %>");

                    var hdn_CostExMarkup1 = document.getElementById("<%=hdn_CostExMarkup1.ClientID %>");
                    var hdn_CostExMarkup2 = document.getElementById("<%=hdn_CostExMarkup2.ClientID %>");
                    var hdn_CostExMarkup3 = document.getElementById("<%=hdn_CostExMarkup3.ClientID %>");
                    var hdn_CostExMarkup4 = document.getElementById("<%=hdn_CostExMarkup4.ClientID %>");

                    var Zone_TotalSellingPrice1 = document.getElementById("<%=Zone_TotalSellingPrice1.ClientID %>");
                    var Zone_TotalSellingPrice2 = document.getElementById("<%=Zone_TotalSellingPrice2.ClientID %>");
                    var Zone_TotalSellingPrice3 = document.getElementById("<%=Zone_TotalSellingPrice3.ClientID %>");
                    var Zone_TotalSellingPrice4 = document.getElementById("<%=Zone_TotalSellingPrice4.ClientID %>");

                    var ZonePressCalType = '<%=ZonePressCalType %>';

                    var div_Complete = document.getElementById("<%=div_Complete.ClientID %>");



                    var hdn_MarkupValue2 = document.getElementById("<%=hdn_MarkupValue2.ClientID %>");
                    var hdn_MarkupValue3 = document.getElementById("<%=hdn_MarkupValue3.ClientID %>");
                    var hdn_MarkupValue4 = document.getElementById("<%=hdn_MarkupValue4.ClientID %>");
                    //ItemMarkupOnBlur(Markup,ID);
                    //SubItemOtherCostBlur();
                    //InkMarkupOnBlur();
                    //WarehouseMarkupOnBlur()
                    //ItemOutworkMarkupOnBlur()


                    function CallOnLoad() {
                        var idlist = MarkupIdList.split('±');
                        for (var i = 0; i < idlist.length; i++) {
                            if (idlist[i] != '') {
                                var spn = "spnSellingPrice_" + idlist[i] + "";
                                var mar = "txtMarkUp_" + idlist[i] + "";
                                var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "";

                                var Markup = document.getElementById(mar).value;
                                var SellValue = document.getElementById(spnSellExMark).innerHTML.replace(/,/, '');
                                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;

                                if (i == 0) {
                                    hdn_Markup.value = Markup;
                                    hdn_CostExMarkup1.value = SellValue;
                                    hdn_MarkupPrice1.value = MarkupValue;
                                }
                                else if (i == 1) {
                                    hdn_Markup2.value = Markup;
                                    hdn_CostExMarkup2.value = SellValue;
                                    hdn_MarkupPrice2.value = MarkupValue;
                                }
                                else if (i == 2) {
                                    hdn_Markup3.value = Markup;
                                    hdn_CostExMarkup3.value = SellValue;
                                    hdn_MarkupPrice3.value = MarkupValue;
                                }
                                else if (i == 3) {
                                    hdn_Markup4.value = Markup;
                                    hdn_CostExMarkup4.value = SellValue;
                                    hdn_MarkupPrice4.value = MarkupValue;
                                }
                            }
                        }
                        //                        alert(hdn_Markup.value + "==" + hdn_Markup2.value + "==" + hdn_Markup3.value + "==" + hdn_Markup4.value);
                        //                        alert(hdn_CostExMarkup1.value + "==" + hdn_CostExMarkup2.value + "==" + hdn_CostExMarkup3.value + "==" + hdn_CostExMarkup4.value);
                        //                        alert(hdn_MarkupPrice1.value + "==" + hdn_MarkupPrice2.value + "==" + hdn_MarkupPrice3.value + "==" + hdn_MarkupPrice4.value);
                    }

                    //CallOnLoad();//to be called on complete of re-eng when fetched value from db 


                    //To Save Markup to the database -- event called in itemform//
                    function ItemMarkupSave() {
                        debugger
                        div_Complete.style.display = "none";
                        document.getElementById("ds00").style.display = "none";
                        document.getElementById("divLoading").style.display = "none";
                        var ItemFrom = "<%=ItemFrom %>";

                        if (ItemFrom == "SPL" || ItemFrom == "B") {
                            if (hdn_Markup.value == "") {
                                document.getElementById("spn_error").style.display = "block";
                                return false;
                            }

                            else {
                                var CompID = '<%=CompanyID %>';
                                var EstCalID = '<%=EstCalculationID %>';
                                var Markup = hdn_Markup.value;
                                var EstType = '<%=para %>';

                                var MarkupSide2 = hdn_ZoneSide2Markup.value;

                                if (hdn_PressType.value != '' && hdn_PressType.value == "Z")//&& ZonePressCalType.toLowerCase() == "false"
                                {
                                    hdn_ZoneSaveItem.value = CompID + "µ" + EstCalID + "µ" + Markup + "µ" + EstType + "µ" + hdn_ZoneSideColor1.value + "±" + CompID + "µ" + EstCalID + "µ" + MarkupSide2 + "µ" + EstType + "µ" + hdn_ZoneSideColor2.value;
                                }
                                hdn_SaveItemViewMarkup.value = CompID + "µ" + EstCalID + "µ" + Markup + "µ" + EstType;
                            }
                        }
                        else if (ItemFrom == "IW") {
                            var hidItemList = document.getElementById("<%=hidItemList.ClientID %>").value;
                            var Arr1 = hidItemList.split('±');
                            var StoreMarkup = '';
                            for (var i = 0; i < Arr1.length; i++) {
                                if (Arr1[i] != '') {
                                    var WareID = Arr1[i];
                                    var MarkUpID = "txtMarkUp_" + Arr1[i] + "";
                                    var MarkUpValue = document.getElementById(MarkUpID).value;
                                    StoreMarkup += "EstItemWarehouseID«" + WareID + "±MarkUp«" + MarkUpValue + "µ";
                                }
                            }
                            hdn_SaveItemViewMarkup.value = StoreMarkup;
                        }
                        else if (ItemFrom == "IU") {
                            var hidItemList = document.getElementById("<%=hidItemList.ClientID %>").value;
                            var Arr1 = hidItemList.split('±');
                            var StoreMarkup = '';
                            for (var i = 0; i < Arr1.length; i++) {
                                if (Arr1[i] != '') {
                                    var WareID = Arr1[i];
                                    var MarkUpID = "txtMarkUp_" + Arr1[i] + "";
                                    var MarkUpValue = document.getElementById(MarkUpID).value;
                                    StoreMarkup += "EstOtherCostID«" + WareID + "±MarkUp«" + MarkUpValue + "µ";
                                }
                            }

                            hdn_SaveItemViewMarkup.value = StoreMarkup;
                        }
                        else if (ItemFrom == "IO") {
                            var hidItemList = document.getElementById("<%=hidItemList.ClientID %>").value;
                            var Arr1 = hidItemList.split('±');
                            var StoreMarkup = '';
                            for (var i = 0; i < Arr1.length; i++) {
                                if (Arr1[i] != '') {
                                    var WareID = Arr1[i];
                                    var MarkUpID = "txtMarkUp_" + Arr1[i] + "";
                                    var SellingPriceID = "spnSellingPrice_" + Arr1[i] + "";
                                    var MarkUpValue = document.getElementById(MarkUpID).value;
                                    //                                    var SellingPriceValue = document.getElementById(SellingPriceID).innerHTML.replace('$', '').replace(/,/, '');
                                    var SellingPriceValue = document.getElementById(SellingPriceID).innerHTML.replace(/,/, '').replace("javascript:GetCurrencyinRequiredFormate('', true);", '');
                                    //                                    alert("SellingPriceValue=" + SellingPriceValue);
                                    StoreMarkup += "EstItemOutworkSupplierID«" + WareID + "±MarkUp«" + MarkUpValue + "±TotalPrice«" + SellingPriceValue + "µ";
                                }
                            }

                            hdn_SaveItemViewMarkup.value = StoreMarkup;
                        }
                        else if (ItemFrom == "W") {
                            var hidItemList = document.getElementById("<%=hidItemList.ClientID %>").value;
                                var Arr1 = hidItemList.split('±');
                                for (var i = 0; i < Arr1.length; i++) {
                                    var MarkUpID = "txtMarkUp_" + Arr1[i] + "";
                                    var MarkUpValue = "";
                                    if (document.getElementById(MarkUpID) != null) {
                                        MarkUpValue = document.getElementById(MarkUpID).value;
                                    }
                                    else {
                                        MarkUpValue = 0;
                                    }

                                    var MarkUpID2 = "txtMarkUp2_" + Arr1[i] + "";
                                    if (document.getElementById(MarkUpID2) != null) {
                                        var MarkUpValue2 = document.getElementById(MarkUpID2).value;
                                        hdn_MarkupValue2.value = MarkUpValue2;
                                    }
                                   

                                    var MarkUpID3 = "txtMarkUp3_" + Arr1[i] + "";
                                    if (document.getElementById(MarkUpID3) != null) {
                                        var MarkUpValue3 = document.getElementById(MarkUpID3).value;
                                        hdn_MarkupValue3.value = MarkUpValue3;
                                    }


                                    var MarkUpID4 = "txtMarkUp4_" + Arr1[i] + "";
                                    if (document.getElementById(MarkUpID4) != null) {
                                        var MarkUpValue4 = document.getElementById(MarkUpID4).value;
                                        hdn_MarkupValue4.value = MarkUpValue4;
                                    }


                                    hdn_SaveItemViewMarkup.value = MarkUpValue + "»" + Arr1[i];

                                    break;
                                }
                            }
                            else if (ItemFrom == "C") {
                                var PriceData = '';
                                for (var i = 0; i < 4; i++) {
                                    var txtmarkupId = "txtMarkUp_" + i + "";
                                    var txtCostPrice = "txtCostPrice_" + i + "";
                                    var spn_id = "spn_id_" + i + "";
                                    if (document.getElementById(txtmarkupId) != null) {
                                        var EstPriceCatalogueID = document.getElementById(spn_id).innerHTML;
                                        var Markup = document.getElementById(txtmarkupId).value;
                                        PriceData += "EstPriceCatalogueID«" + EstPriceCatalogueID + "±MarkUp«" + Markup + "µ";
                                    }
                                    if (document.getElementById(txtCostPrice) != null) {
                                        var EstPriceCatalogueID = document.getElementById(spn_id).innerHTML;
                                        var Markup = document.getElementById(txtmarkupId).value;
                                        var Price = document.getElementById(txtCostPrice).value;
                                        PriceData += "EstPriceCatalogueID«" + EstPriceCatalogueID + "±MarkUp«" + Markup + "±Price«" + Price+"µ";
                                    }
                                }

                                hdn_SaveItemViewMarkup.value = PriceData;
                            }
                            else if (ItemFrom == "IC") {
                                var PriceData = '';
                                var PriceCnt = Number(hdn_PriceSubCnt.value);
                                for (var i = 0; i < PriceCnt; i++) {
                                    var txtmarkupId = "txtMarkUp_" + i + "";
                                    var spn_id = "spn_id_" + i + "";
                                    if (document.getElementById(txtmarkupId) != null) {
                                        var EstPriceCatalogueID = document.getElementById(spn_id).innerHTML;
                                        var Markup = document.getElementById(txtmarkupId).value;
                                        PriceData += "EstPriceCatalogueID«" + EstPriceCatalogueID + "±MarkUp«" + Markup + "µ";
                                    }
                                }

                                hdn_SaveItemViewMarkup.value = PriceData;
                            }

            return true;
        }
                </script>
            </div>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="pnlCallAfterUpdate" runat="server" Visible="false">
    <script type="text/javascript">

        function CallNow() {

            document.getElementById("<%=pnlCostView.ClientID %>").style.display = "none";
            var ParentEstimateItemID = "<%=ParentEstimateItemID %>";
            //            if (ParentEstimateItemID == 0) {
            //                window.parent.CallItemItemMarkupSave("<%=EstimateItemID %>", ""); // Using only for refresh the parent page.
            //            }
            //            else {
            //                window.parent.CallItemItemMarkupSave(ParentEstimateItemID, "");
            //            }
            setTimeout("TakeOut()", 1000);
            //added var  get_urlparent for ticket 13391 & comment reload
            var get_urlparent = '<%=get_urlofparentpage %>'
            parent.location = get_urlparent;
            //  parent.location.reload();
        }
        function TakeOut() {
            window.close();
        }
        CallNow();
    </script>
</asp:Panel>
<script>

    if (para.toLowerCase() == 'paper') {
        document.getElementById("<%=div_Complete.ClientID %>").style.width = "950px";
    }
    else if (para.toLowerCase() == 'press') {
        document.getElementById("<%=div_Complete.ClientID %>").style.width = "1200px";
    }
    else if (para.toLowerCase() == 'guillotine') {
        document.getElementById("<%=div_Complete.ClientID %>").style.width = "1200px";
    }
    else {
        document.getElementById("<%=div_Complete.ClientID %>").style.width = "1000px";
    }
document.getElementById("ds00").style.display = "none";
document.getElementById("divLoading").style.display = "none";
</script>

