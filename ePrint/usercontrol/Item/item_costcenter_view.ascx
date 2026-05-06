<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_costcenter_view.ascx.cs" Inherits="ePrint.usercontrol.Item.item_costcenter_view" %>

    <%@ Register TagPrefix="UC" TagName="Loading" src="~/usercontrol/settings/Loading.ascx" %>
   
   <script type="text/javascript" src="<%=strSitepath %>js/Item/item_cost_view.js?VN='<%=VersionNumber%>'"></script>
<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>

<div id="ds00" style="display:block;" >
</div>
<div id="divLoading" style="display:block; width:200px; height:50px; position:absolute">        
        <UC:Loading id="ucLoading" runat="server" />      
</div>
<script>
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "none";
</script>
    <script type="text/javascript">
        setLoadingPositionOfDivMove(divLoading);
    </script>
<div style="width:750px;">&nbsp;</div>
<div id="div_loading" align="left" style="position: absolute;height:50px; width:200px; top:45%; left:45%;display:none;">
    <UC:Loading id="Loading1" runat="server" />      
</div>
<asp:Panel ID="pnlCostView" runat="server" Visible="false">
<div align="left" style="width:100%;" id="div_Complete">
    <div align="left">
        <div style="width: 100%;" class="navigatorpanel">
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
        </div>
        <div class="divBorderItem" >
            <div align="left" style="width:100%;">
                <div align="left">
                    <div align="left" style="border:1px solid white;padding-left:10px;">
                        <asp:PlaceHolder ID="plhItemCostView" runat="server"></asp:PlaceHolder>
                        <%--Below Div are not used because it giveing the Design issues--%>
                        <div align="left" style="clear: both;display:none" >
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
                                        runat="server" Text="Save" OnClick="lnkbtnSaveItemView_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdn_Markup" runat="server" Value="0" />
            <asp:HiddenField ID="hidItemList" runat="server" Value="" />
            <asp:HiddenField ID="hdn_SaveItemViewMarkup" runat="server" Value="" />
            
            <script>
                var hdn_SaveItemViewMarkup = document.getElementById("<%=hdn_SaveItemViewMarkup.ClientID %>");
                var MarkupIdList = "<%=MarkupIdList %>";
                var hdn_Markup = document.getElementById("<%=hdn_Markup.ClientID %>");

                //ItemMarkupOnBlur(Markup,ID);
                //SubItemOtherCostBlur();
                //InkMarkupOnBlur();
                //WarehouseMarkupOnBlur()
                //ItemOutworkMarkupOnBlur()

                //To Save Markup to the database -- event called in itemform//
                function ItemMarkupSave() {
                    document.getElementById("div_Complete").style.display = "none";
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
                                 var SellingPriceValue = document.getElementById(SellingPriceID).innerHTML.replace("javascript:GetCurrencyinRequiredFormate('',true);", '').replace(/,/, '');
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
                                var MarkUpValue = document.getElementById(MarkUpID).value;
                                hdn_SaveItemViewMarkup.value = MarkUpValue + "»" + Arr1[i];
                                break;
                            }
                        }
                        else if (ItemFrom == "C") {
                            var PriceData = '';
                            for (var i = 0; i < 4; i++) {
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
<div id="div_after_cost_view">
</div>
<asp:Panel ID="pnlCallAfterUpdate" runat="server" Visible="false">
    <script>
        CallNow();
        function CallNow() {
            document.getElementById("<%=pnlCostView.ClientID %>").style.display = "none";
                document.getElementById("div_after_cost_view").style.top = "42%";
                document.getElementById("div_after_cost_view").style.left = "40%";
                document.getElementById("div_after_cost_view").innerHTML = "<span>Please wait Re-Calculating</span>";
                document.getElementById("div_after_cost_view").className = "loading";
                window.parent.CallItemItemMarkupSave("<%=EstimateItemID %>", "");
                setTimeout("TakeOut()", 1000);
            }
            function TakeOut() {
                window.close();
            }
    </script>
</asp:Panel>
<script>
    document.getElementById("ds00").style.display = "none";
    document.getElementById("divLoading").style.display = "none";
</script>