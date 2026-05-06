<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="proof_summary_main.ascx.cs" Inherits="ePrint.usercontrol.Item.proof_summary_main" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagName="CustomerDetails" TagPrefix="UC" Src="~/usercontrol/Item/Item_Summary_CustomerDetails.ascx" %>
<%@ Register TagName="ItemTotal" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_total.ascx" %>
<%@ Register TagName="SingleItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_single_item.ascx" %>
<%@ Register TagName="PadItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_pad_item.ascx" %>
<%@ Register TagName="BookletItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_booklet_item.ascx" %>
<%@ Register TagName="LargeItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_large_item.ascx" %>
<%@ Register TagName="LithoSingleItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_litho_single_item.ascx" %>
<%@ Register TagName="LithoPadItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_litho_pad_item.ascx" %>
<%@ Register TagName="LithoBookletItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_litho_booklet_item.ascx" %>
<%@ Register TagName="LithoNCRItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_ncr_item.ascx" %>
<%@ Register TagName="QuickQuoteItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_quick_quote_item.ascx" %>
<%@ Register TagName="DeliveryCostItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_DeliveryCost_item.ascx" %>
<%@ Register TagName="WarehouseItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_warehouse_item.ascx" %>
<%@ Register TagName="OutworkItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_outwork_item.ascx" %>
<%@ Register TagName="PricecatalogueItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_pricecatalogue_item.ascx" %>
<%@ Register TagName="OthercostItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_othercost_item.ascx" %>
<%@ Register TagName="ProgressToJob" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_progress_to_job.ascx" %>
<%@ Register TagName="CopytoNewSameCustomer" TagPrefix="UC" Src="~/usercontrol/Item/Item_Summary_CopytoNew_SameCustomer.ascx" %>
<%@ Register TagName="ActivityHistory" TagPrefix="UC" Src="~/usercontrol/Item/notes.ascx" %>
<%@ Register TagName="ProgressToInvoice" TagPrefix="UC" Src="~/usercontrol/Item/Item_summary_ProgressTo_Invoice.ascx" %>
<%@ Register TagName="RaisePurchaseOrder" TagPrefix="UC" Src="~/usercontrol/Item/Item_Summary_RaisePO_From_Job.ascx" %>
<%@ Register TagName="PrinorEmailAllandSeletedItems" TagPrefix="UC" Src="~/usercontrol/Item/Item_Summary_PrintEmail_AllandSeletedItems.ascx" %>
<%@ Register TagName="SupplierQuote" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_supplierquotedetails.ascx" %>
<%@ Register TagName="quicklinksItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_quicklinks.ascx" %>
<%@ Register TagName="MoreOptions" TagPrefix="UC" Src="~/usercontrol/Item/itemsummary_moreoptions.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var asyncState = true;
    XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
    XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
        async = asyncState;
        var eventArgs = Array.prototype.slice.call(arguments);
        return this.original_open.apply(this, eventArgs);
    }
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";

    var div_Load = document.getElementById("div_Load");
    setLoadingPositionOfDivMove(div_Load);
    var ManageStockPermission = '<%=ManageStockPermission %>';
    var StockCancellationType = '<%=StockCancellationType %>';
    var RowsCount = '<%=RowsCount %>';
    var Delete_Confirmation_Common_Msg = '<%=objLangClass.GetLanguageConversion("Delete_Confirmation_Common_Msg")%>';
    var EstimateItemDeleteMsg = '<%=objLangClass.GetLanguageConversion("Note_For_deleting_the_estimate_item")%>';
    var OrderItemDeleteMsg = '<%=objLangClass.GetLanguageConversion("Note_For_deleting_the_order_item")%>';

    var Estimate_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Estimate_Status_Updated_Successfully") %>';
    var Job_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Job_Status_Updated_Successfully")%>';
    var Invoice_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Invoice_Status_Updated_Successfully")%>';
    var Status_not_changed = '<%=objLangClass.GetLanguageConversion("Status_not_changed")%>';
    var Estimate_Item_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Estimate_Item_Status_Updated_Successfully") %>';
    var Job_Item_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Job_Item_Status_Updated_Successfully")%>';
    var Invoice_Item_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Invoice_Item_Status_Updated_Successfully")%>';
    var Order_Item_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Order_Item_Status_Updated_Successfully")%>';
    var Order_Status_Updated_Successfully = '<%=objLangClass.GetLanguageConversion("Order_Status_Updated_Successfully")%>';
    var EstimateItemsLocked = '<%=EstimateItemsLocked %>';
    var EstimateItems = '<%=EstimateItems %>';
   

    //if (EstimateItemsLocked.toLowerCase() === "true") {

    //    debugger;

    //    var PrntEstItmIDs_List = EstimateItems.split('ยง');
    //    for (var i = 0; i < PrntEstItmIDs_List.length - 1; i++) {
    //        var obj = $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liReRun");

    //        //$("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liReRun").css('display', 'none');
    //        $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_RCM_Options").css('display', 'none');
    //        $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liaddItemhead").css('display', 'none');
    //        $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liaddItemhead").css('display', 'none');
           

           

    //    }


    //}

    $(document).ready(function () {
       
        if (EstimateItemsLocked.toLowerCase() === "true") {

       

        var PrntEstItmIDs_List = EstimateItems.split('ยง');
        for (var i = 0; i < PrntEstItmIDs_List.length - 1; i++) {
            //var obj = $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liReRun");

            $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liReRun").css('display', 'none');
            $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_RCM_Options").css('display', 'none');
            $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liaddItemhead").css('display', 'none');
            $("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_itemdetails_quickLinks_" + PrntEstItmIDs_List[i].toString() + "_liaddItemhead").css('display', 'none');
           

           

        }


    }
    });

</script>
<script src="<%=strSitepath %>js/wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<style type="text/css">
    .web_dialog_overlay_Address {
        position: absolute;
        top: 0px;
        right: 0;
        bottom: 0;
        left: 0;
        height: 135%;
        width: 125%;
        margin: 0;
        padding: 0;
        background: Black;
        opacity: .25;
        filter: alpha(opacity=25);
        -moz-opacity: .25;
        z-index: 10001;
        display: none;
    }
</style>
<style>
    #ctl00_ContentPlaceHolder1_UCProofSummaryMain_divstatus a {
        padding: 0px !important;
    }

    .ui-accordion .ui-accordion-header .ui-icon {
        margin-left: 170px !important;
    }

    .dd_color {
        padding-top: 4px;
        text-align: left;
        background-color: White !important;
    }

    .acc_height {
        height: 40px !important;
    }

    #spnStatusItems a, #spnStatus a {
        background: White !important;
        width: 167px;
        white-space: nowrap;
        overflow: hidden;
    }

    .RadWindow_Default .rwIcon, .RadWindow_Default .rwResize, .RadWindow_Default .rwCommandButton {
        color: black;
        cursor: default;
        background-repeat: no-repeat;
        width: 16px;
        height: 16px;
        top: 0;
        left: 0;
        position: relative;
        background-image: url('WebResource.axd?d=VU9P1qdfHCXTcukV57K2by3tsZCR0C59um7Lx4PJ8wWzu5tGqBUA5Oy7rAs2ebYu_8-7bLH6Fm_8mUb-BQzSBDIB8GUX3nc23TJj-5vO9Wx_AfvpJRiklwwtBTJ_TyrbVlbPBpgOTaaQVmxkKwtmx21OVFQYJ6cvGzxcF9yUfGWkBmHYk3voGY4WSPuv3IMk0&t=635827773860000000');
    }

    .RadWindow_Default {
        border: 0;
        background-color: transparent;
    }


    .RadWindow .rwIcon:before {
        display: none;
    }
</style>
<script type="text/javascript">
    
    $(document).ready(function () {
        $(function () {
            $("#accordion2").accordion({
                header: "h4", collapsible: true, autoHeight: false
            });
            $("#accordion2 span").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
            var accordionindex = 1000;

            $("#accordion2").accordion();

            if (accordionindex == 0) {
                $("#accordion2").accordion();
            }
            else {
                $("#accordion2").accordion();
                $("#accordion2").accordion('activate', accordionindex);

            }
            document.getElementById("tabs").style.visibility = 'visible';

        });
    });
    $(document).ready(function () {


       

        $(function () {
            $('#tabs').tabs();
            $('#tabs').tabs('select', '#tabs-2');

            if ('<%=tab %>' != '') {
                if ('<%=tab %>' == 'Q') {
                    $('#tabs').tabs('select', '#tabs-3');
                    $("#accordion2").accordion('activate', 0);
                }
            }

            $("#accordion").accordion({
                header: "h3", collapsible: true, autoHeight: false
            });

            $("#accordion #spnOptions").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnStatus").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnMoreAction").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnStatusItems").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnStatusLock").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnStatusUnLock").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            //Changed by Pradeep ------ 04-12-2012
            var accordionindex = 0;

            accordionindex = Number($("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnaccordionIndex").val());
            //            }
            //---------end----------.

            if (accordionindex == 0) {
                $("#accordion").accordion('activate', 1);
            }
            else {
                $("#accordion").accordion('activate', accordionindex);
            }
            document.getElementById("tabs").style.visibility = 'visible';

           
            if ($("#ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnIsSortingAllowed").val() == "true" && (window.location.href.includes("estimate_summary_reeng") || window.location.href.includes("job_order_summary") || window.location.href.includes("invoice_summary_reeng") || window.location.href.includes("invoice_order_summary") || window.location.href.includes("job_summary_reeng") || window.location.href.includes("order_summary"))) {


                $('#accordion').sortable({
                    placeholder: "placeholder",
                    axis: 'y',
                    items: 'h3[data-value="sortable"]',

                    stop: function (event, ui) {

                        document.getElementById("div_Load").style.display = "block";
                        var bar = new Promise((resolve, reject) => {

                         
                            $('[data-value]').each(function (i, item) {
                                var estimateItemId = $(this).attr('id');
                                console.log("position:" + i + "  >>  " + estimateItemId);

                                var pageName = "";
                                if (window.location.href.includes("estimate_summary_reeng")) {
                                    pageName = "estimate";
                                } else if (window.location.href.includes("job_order_summary") || window.location.href.includes("job_summary_reeng")) {
                                    pageName = "job";
                                } else if (window.location.href.includes("invoice_summary_reeng") || window.location.href.includes("invoice_order_summary")) {
                                    pageName = "invoice";
                                } else if (window.location.href.includes("order_summary")) {
                                    pageName = "order";
                                }

                                ePrint.press_select.Update_EstimateItems_SortingOrder(estimateItemId, i + 1, pageName);

                                if (i === $('[data-value]').length - 1) {
                                    resolve();
                                    window.location.reload(true);
                                }
                            });
                        });

                        bar.then(() => {
                            console.log('All done!');
                            document.getElementById("div_Load").style.display = "none";
                        });




                    }
                });
            }
            //$("#accordion").disableSelection();
        });


    });
    function CloseTab(tab) {

        $(document).ready(function () {
            $(function () {
                $("#accordion2").accordion({
                    header: "h4", collapsible: true, autoHeight: false
                });

                var accordionindex = tab;
                $("#accordion2").accordion('activate', accordionindex);
                document.getElementById("tabs").style.visibility = 'visible';

            });
        });
    }

  

   

</script>
<asp:HiddenField ID="hdnaccordionIndex" runat="server" Value="0" />
<asp:HiddenField ID="hdnIsProducttype" runat="server" Value="false" />
<asp:HiddenField ID="hdnIsinventoryBack" runat="server" Value="false" />
<asp:HiddenField ID="hdndeleteparm" runat="server" />
<asp:HiddenField ID="hdnPrntEstItmIDs" runat="server" Value="" />
<asp:HiddenField ID="hdnIsSortingAllowed" runat="server" Value="flase" />
<asp:ScriptManagerProxy ID="SMproxy" runat="server">
    <services>
        <asp:ServiceReference Path="~/item_summary.asmx" />
        <asp:ServiceReference Path="~/AutoFill.asmx" />
        <asp:ServiceReference Path="~/press_select.asmx" />

    </services>
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <contenttemplate>
        <UC:ActivityHistory ID="UCActivityHistory" runat="server" />
    </contenttemplate>
</asp:UpdatePanel>
<div id="divBackGroundNew" style="display: none;">
</div>
<div align="left" style="width: 100%;">
    <div id="div_forCrm" style="display: none;" class="divpadding" runat="server">
        <table id="tblforCrm" cellpadding="0" width="100%" cellspacing="0" border="0" runat="server">
            <tr>
                <td style="width: 30%;">
                    <div style="float: left;">
                        <asp:Button ID="Rdbtn_CopyEstimate" runat="server" Text="Copy Estimate" CssClass="button"
                            OnClientClick="javascript:return copytosameandnewcustomer();" />
                    </div>
                    <div style="float: left; padding-left: 10px; padding-top: 5px;">
                        <asp:DropDownList ID="ddlCopyEstimate" runat="server" CssClass="normaltext">
                            <asp:ListItem Text="To Same Customer" Value="1"></asp:ListItem>
                            <asp:ListItem Text="To New Customer" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="width: 20%">&nbsp;
                </td>
                <td style="width: 40%;" colspan="2">
                    <asp:PlaceHolder ID="plhcrmbuttons" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </div>
    <table width="99%" cellpadding="0" cellspacing="0" border="0">
        <tr style="display: none">
            <td style="display: none">
                <div align="left" style="padding: 2px 0px 0px 0px; float: left; border: 1px solid green;">
                    <div id="Div_CustomerDetail" class="SummaryTabs" nowrap="nowrap" style="height: 20px; cursor: pointer; float: left; padding: 0px 10px 0px 10px; line-height: 20px; margin-right: 2px">
                        <b><span id="ItemDetail" style="color: Red;" onclick="javascript:ShowSummaryDetail('CustomerDetail');">Customer Details </span></b>
                    </div>
                    <div id="Div_ItemSummary" class="SummaryTabs" nowrap="nowrap" style="height: 20px; cursor: pointer; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <b><span id="ItemSumry" onclick="javascript:ShowSummaryDetail('ItemSummaryDetail');">Item Summary Details </span></b>
                    </div>
                    <div>
                        <asp:Label ID="lbl_EstimateNo" runat="server" Text="Nattt"></asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr style="display: none">
            <td align="center" width="98%" style="border: 1px solid #CCCCCC; display: none">
                <div id="Div_Content">
                    <table width="99%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <div id="Div_CustomerInfo" style="display: block;">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Div_ItemSumaryDetail" align="left" style="display: none;">
                                </div>
                                <div style="clear: both;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <div id="Div_SuccMsg">
                    <asp:UpdatePanel ID="UPMessage" runat="server">
                        <ContentTemplate>
                            <table align="center" width="99%" border="0px">
                                <tr>
                                    <td align="center">
                                        <div>
                                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                        </div>
                                        <div align="center" style="float: left; margin-left: 40%;">
                                            <asp:Label ID="lblUpdateMsg" runat="server" CssClass="msg-success" Text="Status updated successfully"
                                                Style="display: none; text-align: left;"></asp:Label>
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="div_spacing1">
                    <div id="tabs" class="ui-tabs" style="width: 100%; border: solid 0px red; visibility: hidden">
                        <div id="divSupplierQuote" runat="server">
                            <%--By Naveen for Customer Details Accordion--%>
                            <div id='accordion' style='width: 100%; padding: 0px; margin: 0px;'>
                                <div style="width: 100%; margin-top: 5px;">
                                    <h3 class="acc_height">
                                        <a style="border-bottom-width: 0px;" href='#'>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="width: 185px;">
                                                        <span id="spnOptions">
                                                            <UC:MoreOptions ID="ucMore" runat="server" />
                                                        </span>
                                                    </td>
                                                    <td style="width: 20%;">
                                                        <asp:Label ID="lblText" Text="Customer Details" runat="server" CssClass="HeaderText"
                                                            Style="vertical-align: baseline;"><%=objLangClass.GetLanguageConversion("Customer_Deatils")%>:</asp:Label>
                                                        <asp:Label ID="LblCompanyName" runat="server" Font-Bold="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div id="divstatus" runat="server" style="float: left; margin-top: 4px;">
                                                            <asp:Label ID="lblEstNoText" runat="server" Font-Bold="true" Style="padding-left: 100px;"
                                                                Text="Estimate Number"></asp:Label>
                                                            <asp:Label ID="lblEstJobInvNo" runat="server" Font-Bold="false"></asp:Label>
                                                        </div>
                                                        <asp:HiddenField ID="hdnReduceStockTypeForCancelled" Value="false" runat="server" />
                                                        <asp:HiddenField ID="hdn_SelectedStatusID" runat="server" Value="0" />
                                                    </td>
                                                    <td>
                                                        <div id="divLocked" runat="server" style="float: left; margin-top: 4px;">
                                                            <asp:Label ID="lblLocked" runat="server" Font-Bold="true" Style="padding-right: 32px; color:red"></asp:Label>

                                                        </div>
                                                       
                                                    </td>
                                                    <td style="width: 190px;">
                                                        <span id="spnStatus">
                                                            <div id="ddlStatus" runat="server" class="btnstyle" style="width: 208px; padding-top: 4px; margin-right: 25px; text-align: left; overflow: hidden; white-space: nowrap;"
                                                                onmouseover="javascript:OpenStatus(); return false;"
                                                                onmouseout="javascript:CloseStatus(); return false;">
                                                                <div style="width: 185px; overflow: hidden; white-space: nowrap; float: left;">
                                                                    <asp:Label ID="lblStatusTitle" runat="server" Text="" Style="font-size: 12px; white-space: nowrap; overflow: hidden;"></asp:Label>
                                                                </div>
                                                                <div style="float: right; padding-top: 5px">
                                                                    <asp:Image ID="imgArrow" runat="server" ImageUrl="~/images/down_arrow.png" />
                                                                </div>
                                                            </div>
                                                            <div id="Div_StatusList" runat="server" style="width: 223px; padding: 0px;" class="Div_AccountList"
                                                                onmouseover="javascript:OpenStatus(); return false;" onmouseout="javascript:CloseStatus(); return false;">
                                                                <asp:PlaceHolder ID="plhStatusList" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div style="padding: 5px; margin: 0px; margin-top: -1px">
                                        <table style="width: 100%;" cellspacing="0" border="0">
                                            <tr>
                                                <td valign="top" style="width: 50px;">
                                                    <asp:PlaceHolder ID="plhdetailsqicklinks" runat="server"></asp:PlaceHolder>
                                                </td>
                                                <td valign="top" style="padding-left: 15px;">
                                                    <div id="Div_CustomerDetails" style="border: 0px solid red;">
                                                        <asp:PlaceHolder ID="plhCustomerInfo" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <asp:PlaceHolder ID="plhItems" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:HiddenField ID="hdnItems" runat="server" Value="" />
                                <asp:HiddenField ID="hdnPCPath" runat="server" Value="" />
                            </div>
                            <%--End By Naveen--%>
                        </div>

                    </div>
                    <div style="clear: both; padding-top: 10px">
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="divrad" style="display: none; position: absolute; vertical-align: middle; border: 0px solid; z-index: 100; width: 50%"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
        OnClientClose="RadWinClose" Behaviors="Close, Move,Reload,Resize" ReloadOnShow="true">
    </telerik:RadWindowManager>
</div>
<div id="div_ProgressToJob" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 40%; height: 50%"
    align="center">
    <asp:PlaceHolder ID="plhProgressToJob" runat="server"></asp:PlaceHolder>
</div>
<div id="div_ProgressToInvoice_reeng" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 30%; height: 40%"
    align="center">
    <asp:PlaceHolder ID="plhProgressToInvoice" runat="server"></asp:PlaceHolder>
</div>
<div id="div_CreatePurchase_reeng" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 30%; height: 40%"
    align="center">
    <asp:PlaceHolder ID="plhRaisePO" runat="server"></asp:PlaceHolder>
</div>
<div id="Div_Print_Email" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 30%; height: 40%"
    align="center">
    <asp:PlaceHolder ID="Plh_PrintandEmail" runat="server"></asp:PlaceHolder>
</div>
<div id="Div_Del_Select_Items" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 30%; height: 40%"
    align="center">
    <asp:PlaceHolder ID="Plh_DelSelectItems" runat="server"></asp:PlaceHolder>
</div>
<div id="Div_ItemSummaryCopy">
    <UC:CopytoNewSameCustomer ID="UCItemSummaryCopy" runat="server" />
</div>

<div id="div_AlertPopup" style="display: none; position: fixed; vertical-align: middle; top: 200px; left: 125px; z-index: 10; width: 85%;" align="center"></div>
<div id="div_AlertPopup_new" style="display: none; position: fixed; vertical-align: middle; top: 200px; left: 125px; z-index: 10; width: 85%;" align="center"></div>

<script type="text/javascript">
    var Pgtype = '<%=Pgtype %>';
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var strSitepath = '<%=strSitepath %>';
    var strImagepath = '<%=strImagepath %>';
    var Module = '<%=Module %>';
    var modulename = '<%=modulename %>';
    var submodulename = '<%=submodulename %>';
    var EstimateID = '<%=EstimateID %>';
    var jobID = '<%=jobID %>';
    var InvoiceID = '<%=InvoiceID %>';
    var RedirectPath = "<%=RedirectPath %>";
    var ParentEstimateItemID = "<%=ParentEstimateItemID %>";
    var ParentEstimateType = "<%=ParentEstimateType %>";
    var div_ProgressToJob = document.getElementById("div_ProgressToJob");
    var divBackGroundNew = document.getElementById("divBackGroundNew");
    var div_ProgressToInvoice_reeng = document.getElementById("div_ProgressToInvoice_reeng");
    var div_CreatePurchase_reeng = document.getElementById("div_CreatePurchase_reeng");
    var Div_Content_first = '<%=Div_Content_first %>';
    var div_RevertJob_reeng = document.getElementById("div_RevertJob_reeng");
    var hdnIsProducttype = document.getElementById("<%=hdnIsProducttype.ClientID %>");
    var hdnIsinventoryBack = document.getElementById("<%=hdnIsinventoryBack.ClientID %>");
    var IsFromeStore = "<%=IsFromeStore %>";

</script>
<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";


    // *** SubItem Call *** //
    function OnClientClicked(sender, args) {
        var cntrlID = sender.get_id().replace('btnStatus', 'RadContextMenu1');
        if (args.IsSplitButtonClick() || !sender.get_commandName()) {
            var currentLocation = $telerik.getLocation(sender.get_element());
            var contextMenu = $find(cntrlID);
            contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
        }
    }

    // Options view in Summary page.
    function OnClientClicked_Option(sender, args) {
        var CtrlID = sender.get_id().replace('Radbtn_Options', 'RCM_Options');
        if (args.IsSplitButtonClick() || !sender.get_commandName()) {
            var currentLocation = $telerik.getLocation(sender.get_element());
            var contextMenu = $find(CtrlID);
            contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
        }
    }

    function ShowItemSummaryContent(ParentEstID, Content, ShowDiv, HideDiv) {
        ShowDiv.style.display = "none";
        HideDiv.style.display = "block";
        Content.style.display = "block";
    }

    function HideItemSummaryContent(ParentEstID, Content, ShowDiv, HideDiv) {
        Content.style.display = "none";
        ShowDiv.style.display = "block";
        HideDiv.style.display = "none";
    }

    // Summary Tabs...
    function ShowSummaryDetail(Obj) {
        if (Obj == "ItemSummaryDetail") {
            document.getElementById("ItemSumry").style.color = "red";
            document.getElementById("ItemDetail").style.color = "black";
            document.getElementById("Div_CustomerInfo").style.display = "none";
            document.getElementById("Div_ItemSumaryDetail").style.display = "block";

        }
        if (Obj == "CustomerDetail") {
            document.getElementById("ItemDetail").style.color = "red";
            document.getElementById("ItemSumry").style.color = "black";
            document.getElementById("Div_CustomerInfo").style.display = "block";
            document.getElementById("Div_ItemSumaryDetail").style.display = "none";
        }
    }

    var plhItems = document.getElementById("<%=plhItems.ClientID %>");

    //for other cost
    var pgtype = '<%=pg %>';
</script>
<asp:HiddenField ID="hid_OtherCostValues_Load" runat="server" Value="" />
<asp:HiddenField ID="hid_EstimateItemID" runat="server" Value="0" />
<asp:HiddenField ID="hid_EstimateType" runat="server" Value="" />
<asp:HiddenField ID="hid_PressID" runat="server" Value="0" />
<asp:HiddenField ID="hid_PaperID" runat="server" Value="0" />
<asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
<asp:HiddenField ID="hid_OtherCostValuesFromTB" runat="server" Value="" />
<asp:HiddenField ID="hdnOtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hdnEditOtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hid_BookletSectionID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_IsOthercostsavedFromPopUp" runat="server" Value="no" />
<asp:HiddenField ID="hdnOtherCostSequenceIDs" runat="server" />
<asp:HiddenField ID="hdnItemDescs" runat="server" />
<asp:HiddenField ID="hdnHieght" runat="server" Value="0" />
<asp:HiddenField ID="hdn_EstItemIDforPODEL_Delete" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ImgClosebtn" runat="server" Value="true" />
<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/item/othercost_item.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">
    var strSitepath = "<%=strSitepath %>";
    var hid_OtherCostValues_Load = document.getElementById("<%=hid_OtherCostValues_Load.ClientID %>");
    var href_ShowOtherCostID = document.getElementById("href_ShowOtherCost");
    var hid_EstimateItemID = document.getElementById("<%=hid_EstimateItemID.ClientID %>");
    var hid_EstimateType = document.getElementById("<%=hid_EstimateType.ClientID %>");
    var hid_BookletSectionID = document.getElementById("<%=hid_BookletSectionID.ClientID %>");

    var hdnOtherCostValues = document.getElementById("<%=hdnOtherCostValues.ClientID %>");
    var hdnEditOtherCostValues = document.getElementById("<%=hdnEditOtherCostValues.ClientID %>");
    var hid_OtherCostValuesFromTB = document.getElementById("<%=hid_OtherCostValuesFromTB.ClientID %>");
    var hdn_IsOthercostsavedFromPopUp = document.getElementById("<%=hdn_IsOthercostsavedFromPopUp.ClientID %>");
    var hdnOtherCostSequenceIDs = document.getElementById("<%=hdnOtherCostSequenceIDs.ClientID %>");
    var hdn_ImgClosebtn = document.getElementById("<%=hdn_ImgClosebtn.ClientID %>");
    var lblUpdateMsg = document.getElementById("<%=lblUpdateMsg.ClientID %>");
    var ArrayOtherCost = new Array();
    var CompanyID = "<%=CompanyID %>";


   

    function SeletedStatusID(ObjID) {
        document.getElementById("<%=hdn_SelectedStatusID.ClientID%>").value = ObjID;
    }

</script>
<script type="text/javascript">
    var ReduceStockType = '<%=ReduceStockType %>';
    var divWidth = document.getElementById("tabs").offsetWidth;
    if (divWidth < 1200) {
        if (document.getElementById("orderStatus") != null && document.getElementById("orderStatus") != undefined) {
            document.getElementById("orderStatus").style.padding = "5px 0 0 10px";
        }
    }
    else {
        if (document.getElementById("liStatus") != null && document.getElementById("liStatus") != undefined) {
            document.getElementById("liStatus").style.width = "37%";
        }
        if (document.getElementById("orderStatus") != null && document.getElementById("orderStatus") != undefined) {
            document.getElementById("orderStatus").style.padding = "5px 0 0 14px";
        }
    }


    function copytosameandnewcustomer() {
        var ddlcopycustomer = document.getElementById("<%=ddlCopyEstimate.ClientID %>");


        if (ddlcopycustomer != null) {
            if (ddlcopycustomer.selectedIndex == '0') {

                EstimateCopyto_SameCust(Pgtype);
                return false;
            }
            if (ddlcopycustomer.selectedIndex == '1') {

                EstimateCopyto_NewCust(Pgtype);
                return false;
            }
        }
        return true;
    }



</script>
<script type="text/javascript">

    function SaveAccountingcode(CompanyID, EstitemID, Esttype, Code) {
        ePrint.press_select.AccountCode_Update_InSummary(CompanyID, EstitemID, Esttype, Code, sucus);
    }

    function sucus(result) {
    }

</script>
<script type="text/javascript">

    function CallSaveBtn(id, id2, CompanyID, EstType, EstID, QtyCnt, SectionCnt,ProofItemID) {
        debugger;
        var id = id2.split('_');
        var divID = id[0];
        var ItemID = divID;

        var hdnItemDescs = document.getElementById("<%=hdnItemDescs.ClientID %>");
        var Desc1 = document.getElementById("txtQtydesc1_" + divID);
        var Desc2 = document.getElementById("txtQtydesc2_" + divID);
        var Desc3 = document.getElementById("txtQtydesc3_" + divID);
        var Desc4 = document.getElementById("txtQtydesc4_" + divID);

        hdnItemDescs.value = Desc1.value + "~" + Desc2.value + "~" + Desc3.value + "~" + Desc4.value;

        var btnID = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_UcItemTotal_" + id2);

        document.getElementById("div_btnsave_" + divID).style.display = "none";
        document.getElementById("div_saveprocess_" + divID).style.display = "block";

        // btnID.click();
        CallProofSave(EstID, ItemID, EstType, QtyCnt, SectionCnt, 'save', ProofItemID);
        window.location.href = strSitepath + "Estimates" + "/" + "Proofs.aspx";
        return false;
    }
    function CallStayBtn(id, id2, CompanyID, EstType, EstID, QtyCnt, SectionCnt,ProofItemID,ProofID) {
        debugger;
        var id = id2.split('_');
        var divID = id[0];
        var ItemID = divID;
        var hdnItemDescs = document.getElementById("<%=hdnItemDescs.ClientID %>");
        var Desc1 = document.getElementById("txtQtydesc1_" + divID);
        var Desc2 = document.getElementById("txtQtydesc2_" + divID);
        var Desc3 = document.getElementById("txtQtydesc3_" + divID);
        var Desc4 = document.getElementById("txtQtydesc4_" + divID);

        hdnItemDescs.value = Desc1.value + "~" + Desc2.value + "~" + Desc3.value + "~" + Desc4.value;

        var btnID = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_UcItemTotal_" + id2);

        document.getElementById("div_btnstay_" + divID).style.display = "none";
        document.getElementById("div_stayprocess_" + divID).style.display = "block";

        CallProofSave(EstID, ItemID, EstType, QtyCnt, SectionCnt, 'stay', ProofItemID);
        //window.location.reload();
        // btnID.click();
        return true;
    }

    function ShowCartAdditional() {
        var pg = 'webstoreorder';
        var EstID = '<%=EstimateID %>';
        var OrderID = '<%=EstimateID %>';
        var OrderItemID = '<%=CartOrdrItemID %>';

        window.radopen("<%=nmsCommon.global.sitePath()%>common/CartAdditionalOption.aspx?pg=" + pg + "&estid=" + EstID + "&Ordid=" + OrderID + "&OrderItemID=" + OrderItemID + "", null, '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return false;
    }

</script>
<div id="div_Note" style="display: none; position: fixed; vertical-align: middle; top: 200px; z-index: 10; width: 100%;"
    align="center">
    <table cellpadding="0" cellspacing="0" width="45%" height="82%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" id="div_invoice_delete" class="Label-PopupHeading" style="float: right; padding-top: 6px; padding-right: 15px;">
                    <div class="CancelButtonDiv2">
                        <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv_All();return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">&nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">&nbsp;
            </td>
            <td class="popup-middlebg" align="center" valign="top">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td valign="top">
                            <div id="div_Delete_Invoice" style="display: none;">
                                <div id="div_rdb_Delete_Invoice" style="float: left; padding-bottom: 7px;">
                                    <span style="font-weight: bold;">
                                        <asp:RadioButton ID="rdb_Delete_Invoice" runat="server" GroupName="deleteInvoice"
                                            Checked="true" Text="Delete Invoice and keep Job/Estimate live" />
                                    </span>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div style="float: left; padding-bottom: 7px;">
                                    <span style="font-weight: bold;">
                                        <asp:RadioButton ID="rdb_Delete_Invoice_All" runat="server" GroupName="deleteInvoice"
                                            Text="Delete Invoice and its corresponding Estimate/Job" />
                                    </span>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                    <asp:Button ID="btn_Delete_Invoice" runat="server" Text="Delete" CssClass="button"
                                        OnClientClick="javascript:CloseDiv_All();Estimate_Job_Invoice_delete();" />
                                </div>
                                <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                    <asp:Button ID="btn_Delete_Cancel" runat="server" Text="Cancel" CssClass="button"
                                        OnClientClick="javascript:CloseDiv_All();return false;" />
                                </div>
                            </div>
                            <div id="div_Delete_JOb" style="display: none;">
                                <table>
                                    <tr>
                                        <td>
                                            <div align="left" id="div_Msg_Note" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-bottom: 7px; padding-left: 1px;">

                                                <span style="font-weight: bold;">Note:
                                                     <asp:Label ID="lbl_note" runat="server" Text="By deleting the job, its corresponding invoice will be deleted"></asp:Label>

                                                </span>


                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="div_rdb_Delete_Job" style="float: left; padding-bottom: 7px;">
                                                <span style="font-weight: bold;">
                                                    <asp:RadioButton ID="rdb_Delete_Job" runat="server" GroupName="deletejob" Checked="true"
                                                        Text="Delete Job/Job Item and keep Estimate/Estimate Item live" />
                                                </span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="clear: both;">
                                            </div>
                                            <div style="float: left; padding-bottom: 7px;">
                                                <span style="font-weight: bold;">
                                                    <asp:RadioButton ID="rdb_Delete_Job_All" runat="server" GroupName="deletejob" Text="Delete Job/Job Item and its corresponding Estimate/Estimate Item" />
                                                </span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div style="clear: both;">
                                </div>
                                <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                    <asp:Button ID="btn_Delete_JOb" runat="server" Text="Delete" CssClass="button" CausesValidation="false" OnClientClick="javascript:Item_PODel_Delete();return false;" />
                                </div>
                                <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" OnClientClick="javascript:CloseDiv_All();return false;" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px; background-color: #ffffff">&nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
            </td>
            <td class="popup-bottom-middlebg">&nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="div_Delete_PODEL" style="display: none; position: fixed; vertical-align: middle; top: 200px; z-index: 10; width: 100%;" align="center">
    <table cellpadding="0" cellspacing="0" width="45%" height="82%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" id="div_ImgCancel" class="Label-PopupHeading" style="float: right; padding-top: 6px; padding-right: 15px;">
                    <div class="CancelButtonDiv2">
                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" OnClientClick="javascript:CloseDiv_All_Imgbtn2(); Estimate_Job_Invoice_delete();" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">&nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">&nbsp;
            </td>
            <td class="popup-middlebg" align="center" valign="top">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td>
                            <div align="left" id="div_Msg_Note2" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-bottom: 7px; padding-left: 1px;">
                                <b>Note</b>:
                                <asp:Label ID="lbl_PODEL_Delete_Note" runat="server" Text="Please select below option for deleting Purchase Order and Delivery Note"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <div align="left" style="width: 100%;" id="revert2" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <div class="box" style="width: 100%;">
                                                <asp:CheckBox ID="Chk_DeletePO" runat="server" Checked="false" Text="Delete PO(s) Related to this Job" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="box" style="width: 100%">
                                                <asp:CheckBox ID="Chk_DeleteDN" runat="server" Checked="false" Text="Delete Delivery notes(s) Related to this Job" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div style="clear: both; height: 10px;">
                                </div>
                                <div runat="server" style="float: left; margin: 0px 10px 0px 0px; padding-left: 3.2%;">
                                    <div id="div_DeletePODEL" style="display: block">
                                        <asp:Button ID="btn_DeletePODEL" runat="server" Text="Continue" CssClass="button" OnClientClick="javascript:loadingimg('div_DeletePODEL','div_PODEL_Delete_Process');CloseDiv_All();Estimate_Job_Invoice_delete();" />
                                    </div>
                                    <div id="div_PODEL_Delete_Process" align="center" class="button" style="width: 50px; height: 13px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px; background-color: #ffffff">&nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
            </td>
            <td class="popup-bottom-middlebg">&nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    function CloseDiv_All() {
        document.getElementById("div_Note").style.display = "none";
        document.getElementById('divBackGroundNew').style.display = "none";
        document.getElementById('div_Delete_PODEL').style.display = "none";
    }
    function CloseDiv_All_Imgbtn2() {
        document.getElementById("div_Note").style.display = "none";
        document.getElementById('divBackGroundNew').style.display = "none";
        document.getElementById('div_Delete_PODEL').style.display = "none";
        hdn_ImgClosebtn.value = false;
    }
</script>
<script>
    function OpenStatus() {
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Div_StatusList").style.display = "block";
    }

    function CloseStatus() {
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Div_StatusList").style.display = "none";
    }

    function OpenItemStatus(ID) {
        document.getElementById("divItemStatusList_" + ID).style.display = "block";
        //var Lock = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnLock_" + ID + "").value;
        //if (Lock.toLowerCase() == 'true') {
        //    document.getElementById("divItemStatusList_" + ID).style.display = "none";
        //}
        //else {
        //    document.getElementById("divItemStatusList_" + ID).style.display = "block";
        //}
    }

    function CloseItemStatus(ID) {
        document.getElementById("divItemStatusList_" + ID).style.display = "none";
    }
</script>
<script language="javascript" type="text/javascript">
    function MessageDisplay() {
        var pnlMessage = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_ctl06_pnlMessage");
        if (typeof pnlMessage != 'undefined' && pnlMessage != undefined && pnlMessage != null) {
            setTimeout(function () { pnlMessage.style.display = "none"; }, 5000);
        }
    }

    function Item_PODel_Delete() {
        var hdn_EstItemIDforPODEL_Delete = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdn_EstItemIDforPODEL_Delete").value;
        document.getElementById("div_Note").style.display = "none";
        document.getElementById("div_Delete_PODEL").style.display = "block";
        document.getElementById("divBackGroundNew").style.display = "block";
        item_summary.DeliveryPurchase_Check(CompanyID, jobID, hdn_EstItemIDforPODEL_Delete, PODEL, Redirect);
    }
    function PODEL(result) {
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Chk_DeletePO").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Chk_DeleteDN").checked = false;
        var PO_DEL = result.split('«');
        if (PO_DEL[0] != 'true') {
            document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Chk_DeletePO").disabled = true;
        }
        if (PO_DEL[1] != 'true') {
            document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_Chk_DeleteDN").disabled = true;
        }
    }
</script>
