<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Job_Revert_To_Estimate.ascx.cs" Inherits="ePrint.usercontrol.Item.Job_Revert_To_Estimate" %>


<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<div id="div_RevertJob_reeng" align="left" style="display: block; position: absolute; z-index: 1000;">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <div align="left" style="width: 100%" id="main" runat='server'>
                    <div align="left" id="div_revert2estimate" runat="server">
                        <div align="left">
                            <div align="left" style="width: 100%">
                                <div align="left" style="width: 100%">
                                    <b>Are you sure you wish to revert this job?</b>
                                </div>
                                <div align="left" style="width: 100%;" id="revert2" runat="server">
                                    <div class="box">
                                        <asp:CheckBox ID="Chk_DeletePO" runat="server" Checked="false" Text="Delete PO(s) Related to this Job" />
                                    </div>
                                    <div class="box" style="width: 99%">
                                        <asp:CheckBox ID="Chk_DeleteDN" runat="server" Checked="false" Text="Delete Delivery notes(s) Related to this Job" />
                                    </div>
                                    <div id="div_invchk" class="box" style="width: 99%; display: none;">
                                        <asp:CheckBox ID="Chk_InvaAjusted" runat="server" Checked="false" Text="Do you want inventory adjusted if any to be added back to the system?" />
                                    </div>
                                    <div id="divStockChk" class="box" style="width: 99%; display: none;">
                                        <asp:CheckBox ID="Chk_StockCancel" runat="server" Checked="false" Text="Do you want stock adjusted if any to be added back to the system?" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 100%; height: 30%">
                            <div style="clear: both">
                                &nbsp;
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div align="left" style="width: 100%;">
                            <div style="float: left;">
                                &nbsp;
                            </div>
                            <div id="div6" style="float: left;">
                                <div id="div_btnrevert" style="display: block">
                                    <asp:Button ID="btnRevertJob" runat="server" Text="Revert To Estimate" CssClass="button"
                                        OnClientClick="javascript:loadingimg('div_btnrevert','div_revertprocess');return RevertJobNew_reeng();" /><%--RevertJobNew();--%>
                                </div>
                                <div id="div_revertprocess" class="button" align="center" style="width: 114px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="clear: both">
                            </div>
                        </div>
                    </div>
                    <div id="div_Itemlist" runat="server">
                        <div class="box" style="width: 99%; padding-bottom: 3px; margin-bottom: 3px;">
                            <asp:RadioButton ID="rdb_All_Item" runat="server" Checked="true" Text="Revert All Item To Estimate"
                                Font-Bold="true" GroupName="Revert" onclick="javascript:Revert_To_Estimate('all');" />
                        </div>
                        <div>
                            <div class="box" style="width: 99%; padding-bottom: 3px; margin-bottom: 3px;">
                                <asp:RadioButton ID="rdb_Selected_Item" runat="server" Checked="false" Text="Revert Selected Item To Estimate"
                                    Font-Bold="true" font-weight="bold" GroupName="Revert" onclick="javascript:Revert_To_Estimate('selected');" />
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div id="divItemList" style="<%=divItemList_Style%>">
                                <asp:PlaceHolder ID="plhItemsList" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                        <%-- <div style="padding-left: 21px; padding-top: 5px;">
                            <asp:Button ID="rdb_Revert_Job" runat="server" Text="Next" CssClass="button" />
                        </div>--%>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdnIsinventoryBack" runat="server" Value="true" />
<asp:HiddenField ID="hdnReduceStockTypeForCancelledNew" Value="false" runat="server" />
<asp:HiddenField ID="hdnStockCancelChk" runat="server" Value="false" />
<asp:HiddenField ID="hidchkDeleteDel" runat="server" Value="false" />
<asp:HiddenField ID="hidchkDeletepo" runat="server" Value="false" />
<asp:HiddenField ID="hdnrevertitem" runat="server" Value="" />
<asp:HiddenField ID="hdnEstItemsSelected" runat="server" Value="" />
<asp:HiddenField ID="hdnEstItemsSelectedCount" runat="server" Value="0" />
<asp:LinkButton ID="lnk_RevertToJob" runat="server" OnClick="btnAddTraining_Click" />
<script language="javascript" type="text/javascript">
    var InventoryManagement = "<%=InventoryManagement %>";
    var Module = "<%=modulename %>";
    var ReduceStockTypeForCancelledVal = "<%=ReduceStockTypeForCancelled %>";

    var Chk_DeletePO = document.getElementById("<%=Chk_DeletePO.ClientID %>");
    var Chk_DeleteDN = document.getElementById("<%=Chk_DeleteDN.ClientID %>");
    var Chk_InvaAjusted = document.getElementById("<%=Chk_InvaAjusted.ClientID %>");
    var Chk_StockCancel = document.getElementById("<%=Chk_StockCancel.ClientID %>");

    var hdnIsinventoryBack = document.getElementById("<%=hdnIsinventoryBack.ClientID %>");
    var hdnReduceStockTypeForCancelledNew = document.getElementById("<%=hdnReduceStockTypeForCancelledNew.ClientID %>");
    var hdnStockCancelChk = document.getElementById("<%=hdnStockCancelChk.ClientID %>");
    var hidchkDeleteDel = document.getElementById("<%=hidchkDeleteDel.ClientID %>");
    var hidchkDeletepo = document.getElementById("<%=hidchkDeletepo.ClientID %>");

    var Modultype = "<%=module%>";

    function WindowClose() {

        window.close();
        if (Modultype == "estimate") {
            parent.location.href = "<%=strSitepath%>Estimates/estimate_summary_reeng.aspx?frm=view&estid=" + '<%=EstID %>';
        }
        else {
            parent.location.href = "<%=strSitepath%>orders/order_summary.aspx?frm=view&ordid=" + '<%=EstID %>' + "&estid=" + '<%=EstID %>';
        }
    }

    function Revert_To_Estimate(type) {
        if (type == 'all') {
            divItemList.style.display = "none";
        }
        else {
            divItemList.style.display = "block";
        }
    }

    function revert_item() {

        var hdnrevertitem = document.getElementById("<%=hdnrevertitem.ClientID %>");
        var hdnEstItemsSelected = document.getElementById("<%=hdnEstItemsSelected.ClientID %>");
        var rdb_Selected_Item = document.getElementById("<%=rdb_Selected_Item.ClientID%>");
        var rdb_All_Item = document.getElementById("<%=rdb_All_Item.ClientID%>");
        var div_revert2estimate = document.getElementById("<%=div_revert2estimate.ClientID%>");
        var div_Itemlist = document.getElementById("<%=div_Itemlist.ClientID%>");
        var Count = 0;

        if (hdnEstItemsSelected.value != "") {
            var AllDetails = hdnEstItemsSelected.value.split('»');

            if (rdb_All_Item.checked) {
                hdnrevertitem.value = '';

                hdnrevertitem.value = hdnEstItemsSelected.value;
                Count = 1;

            }
            else if (rdb_Selected_Item.checked) {
                hdnrevertitem.value = '';
                for (n = 0; n < AllDetails.length - 1; n++) {
                    var chk = document.getElementById("chkEstItems_" + AllDetails[n]);
                    if (chk.checked) {
                        hdnrevertitem.value += AllDetails[n] + "»";
                        Count++;
                    }

                }
            }
        }

        if (Count == 0) {
            alert("Please check at least one item");

        }
        else {
            div_revert2estimate.style.display = "block";
            div_Itemlist.style.display = "none";

        }
    }

</script>
<script type="text/javascript" lang="javascript">
    var hdnEstItemsSelectedCount = document.getElementById("<%=hdnEstItemsSelectedCount.ClientID%>");
    var hdnEstItemsSelected = document.getElementById("<%=hdnEstItemsSelected.ClientID%>");
    var selectedEstimateItemID = new Array();

    function EstimateItemIDCount() {
        if (hdnEstItemsSelected.value != "") {
            selectedEstimateItemID = hdnEstItemsSelected.value.split('»');
        }
        for (var i = 0; i < selectedEstimateItemID.length - 1; i++) {
            var chkID = 'chkEstItems_' + selectedEstimateItemID[i];
            if (document.getElementById(chkID).checked == true) {
                if (hdnEstItemsSelectedCount.value == 0) {
                    hdnEstItemsSelectedCount.value = selectedEstimateItemID[i];
                } else {
                    hdnEstItemsSelectedCount.value = hdnEstItemsSelectedCount.value + '»' + selectedEstimateItemID[i];
                }
            }
        }
    }
</script>
