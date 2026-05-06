<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_quicklinks.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_quicklinks" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    #estoreaccordion ul li:hover {
        background-color: #EEEEEE;
        cursor: pointer;
        border-radius: 5px;
    }

    #estoreaccordion h1 a {
    }

        #estoreaccordion h1 a .ui-icon {
            float: right;
        }

    label {
        cursor: pointer;
    }

    .lisubItems {
        padding-left: 10px;
    }

    #divqlItems .activity-list {
        padding-left: 10px;
    }
</style>

<script type="text/javascript">
    function popup_attachments(estID, jobID) {
        debugger;
        var host = window.location.origin;
        var _url = window.location.href;
        var pageType = "";
        //pageType = 'estimate';
        var _redUrl = "";
        if (_url.includes("jobs/job_summary_reeng.aspx")) {
            pageType = 'job';
            _redUrl = host + "/common/common_popup.aspx?pagetype=general&type=attachments&estid=" + jobID + "&pg=" + pageType + "&action=CreateProof";
        }
        else if (_url.includes("orders/order_summary.aspx")) {
            pageType = 'webstoreorder';
            _redUrl = host + "/common/common_popup.aspx?pagetype=general&type=attachments&estid=" + estID + "&pg=" + pageType + "&action=CreateProof";
        }
        else {
            pageType = 'estimate';
            _redUrl = host + "/common/common_popup.aspx?pagetype=general&type=attachments&estid=" + estID + "&pg=" + pageType + "&action=CreateProof";
        }
        window.radopen(_redUrl, '900', '500');
        //AddnewFile_General();
        //var _redUrl = currentLocation.replace("type=proof", "type=attachments");
        //window.location.href = _redUrl;
    }


    function ItemSelected(ID, li) {
        document.cookie = "MainTabSelect=" + ID;
        document.cookie = "SubTabSelect=" + li;
    }


    function ReadCookie(CookieName) {
        var cookieStr = document.cookie;
        if (cookieStr.indexOf(CookieName) > -1) {
            var t = cookieStr.split(';');
            for (var j = 0; j < t.length; j++) {

                if (t[j].indexOf(CookieName) > -1) {
                    var n = t[j].split('=');
                    var selectedItem = n[1];
                    return selectedItem;
                }
            }
        }
        return "";
    }


    function getcookiesvalue() {
        debugger;
        var _url = window.location.href;
        var hdnGetCookiesValue, hdngetparticularLIid;
        if (_url.toLowerCase().includes("proofs/proof_summary.aspx")) {
            hdnGetCookiesValue = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_custdetails_quickLinks_hdnGetCookiesValue");
            hdngetparticularLIid = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_custdetails_quickLinks_hdngetparticularLIid");
        }
        else {
             hdnGetCookiesValue = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_custdetails_quickLinks_hdnGetCookiesValue");
             hdngetparticularLIid = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_custdetails_quickLinks_hdngetparticularLIid");
        }
        //var hdnGetCookiesValue = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_custdetails_quickLinks_hdnGetCookiesValue");
        //var hdngetparticularLIid = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_custdetails_quickLinks_hdngetparticularLIid");

        var imgup1 = document.getElementById("ctl00_imgup1");
        var imgup2 = document.getElementById("ctl00_imgup2");
        var imgup3 = document.getElementById("ctl00_imgup3");
        var imgup4 = document.getElementById("ctl00_imgup4");

        hdnGetCookiesValue.value = ReadCookie('MainTabSelect');
        hdngetparticularLIid.value = ReadCookie('SubTabSelect');


        if (hdnGetCookiesValue != null) {
            if (!window.location.href.toLowerCase().includes('proof_summary')) {
                $('ul#estoreaccordion > li > ul').hide();
            }
            //$('ul#estoreaccordion > li > ul').hide();
            $('#' + hdnGetCookiesValue.value).show();
            if (hdnGetCookiesValue.value == "Ul5") {
                $(".one").toggle('down');
                imgup1.style.display = 'none';
            }

            if (hdnGetCookiesValue.value == "ul7") {
                $(".three").toggle();
                imgup3.style.display = 'none';
            }
            if (hdnGetCookiesValue.value == "Ul3") {
                $(".four").toggle();
                imgup4.style.display = 'none';
            }
            $('#' + hdngetparticularLIid.value).addClass("estoreonmouseoverselected");
        }
    }
    var PrntEstItmIDs;
    var PrntEstItmIDs_List;
    if (window.location.href.includes('Proof_summary')) {
        PrntEstItmIDs = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnPrntEstItmIDs").value;
        PrntEstItmIDs_List = PrntEstItmIDs.split('ยง');
    }
    else {
        PrntEstItmIDs = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnPrntEstItmIDs").value;
        PrntEstItmIDs_List = PrntEstItmIDs.split('ยง');
    }



    $(document).ready(function () {
        if (!window.location.href.toLowerCase().includes('proof_summary')) {
            $('ul#estoreaccordion > li > ul').hide();
        }
        $('#Action').click(function () {
            $(".one").toggle();
            $("#Ul5").slideUp();
        });
        $('#AddSubItem').click(function () {
            $(".three").toggle();
            $("#ul7").slideUp();
        });
        $('#general').click(function () {
            $(".four").toggle();
            $("#Ul3").slideUp();
        });

        $('ul#estoreaccordion > li > h1').click(function () {
            if ($(this).next().css('display') == 'none') {
                $('ul#estoreaccordion > li > ul').slideUp();
                $(this).next().slideDown();
            }
            else {
                $(this).next().slideUp();
            }
        });

        for (var i = 0; i < PrntEstItmIDs_List.length - 1; i++) {
            $("#Ul3_" + PrntEstItmIDs_List[i].toString()).slideDown();
        }
        getcookiesvalue();
    });
</script>
<script language="javascript" type="text/javascript">

    function rotatearrow(id, header) {
        var imgup;
        var imgdown;
        if (header == 1) {
            imgup = document.getElementById("imgup1_" + id);
            imgdown = document.getElementById("imgdown1_" + id);

            if (imgup.style.display != "none" && imgdown.style.display == "none") {
                imgup.style.display = "none";
                imgdown.style.display = "block";

                if (document.getElementById("imgup3_" + id) != null) {
                    document.getElementById("imgup3_" + id).style.display = "block";
                }

                document.getElementById("imgup4_" + id).style.display = "block";

                if (document.getElementById("imgdown3_" + id) != null) {
                    document.getElementById("imgdown3_" + id).style.display = "none";
                }

                document.getElementById("imgdown4_" + id).style.display = "none";
            }
            else {
                imgup.style.display = "block";
                imgdown.style.display = "none";
            }
        }
        if (header == 3) {
            imgup = document.getElementById("imgup3_" + id);
            imgdown = document.getElementById("imgdown3_" + id);

            if (imgup.style.display != "none" && imgdown.style.display == "none") {
                imgup.style.display = "none";
                imgdown.style.display = "block";
                document.getElementById("imgup1_" + id).style.display = "block";
                document.getElementById("imgup4_" + id).style.display = "block";

                document.getElementById("imgdown1_" + id).style.display = "none";
                document.getElementById("imgdown4_" + id).style.display = "none";
            }
            else {
                imgup.style.display = "block";
                imgdown.style.display = "none";
            }
        }
        if (header == 4) {

            imgup = document.getElementById("imgup4_" + id);
            imgdown = document.getElementById("imgdown4_" + id);
            if (imgup.style.display != "none" && imgdown.style.display == "none") {
                imgup.style.display = "none";
                imgdown.style.display = "block";
                document.getElementById("imgup1_" + id).style.display = "block";

                if (document.getElementById("imgup3_" + id) != null) {
                    document.getElementById("imgup3_" + id).style.display = "block";
                }

                if (document.getElementById("imgup3_" + id) != null) {
                    document.getElementById("imgdown3_" + id).style.display = "none";
                }
                document.getElementById("imgdown1_" + id).style.display = "none";
            }
            else {
                imgup.style.display = "block";
                imgdown.style.display = "none";
            }
        }
    }
    function proof_rotatearrow(id) {
        debugger;
        var imgup;
        var imgdown;
        imgup = document.getElementById("imgup4_" + id);
        imgdown = document.getElementById("imgdown4_" + id);
        if (imgup.style.display != "none" && imgdown.style.display == "none") {
            imgup.style.display = "none";
            imgdown.style.display = "block";
        }
        else {
            imgup.style.display = "block";
            imgdown.style.display = "none";
        }
    }

</script>
<table id="tblQL" runat="server" style="width: 100%;" cellspacing="0" border="0">
    <tr>
        <td valign="top" align="right">
            <asp:PlaceHolder ID="plhSummaryBtns" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <div id="divJobCust" runat="server" style="display: none;">
                <div id="activity">
                    <div id="activity-header">
                        <%=objLangClass.GetLanguageConversion("Quick_Links")%>
                    </div>
                    <asp:PlaceHolder ID="plhjobLeftPanel" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </td>
    </tr>
</table>
<asp:PlaceHolder ID="plhItems" runat="server"></asp:PlaceHolder>
<asp:HiddenField ID="hdnPCPath" runat="server" Value="" />
<asp:HiddenField ID="hdnGetCookiesValue" runat="server" Value='' />
<asp:HiddenField ID="hdngetparticularLIid" runat="server" Value='' />
<style type="text/css">
    .rmRootGroup rmVertical {
        width: 100% !important;
    }
</style>
<div align="left" id="Div_RadSplit" runat="server">
    <table style="width: 100%" id="innerTable" border="0" cellpadding="0" cellspacing="0">
        <tr valign="top">
            <!--LEFTPANEL-->
            <td align="left">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlLeft" runat="server" Visible="true">
                                <div id="div_WebstoreContent" style="overflow: hidden;" runat="server">
                                    <div class="Summary_ItemDiv">
                                        <ul class="accordion setting_accordiondiv" id="estoreaccordion">
                                            <li id="liChangeFile" class="summary_itemsalign HeaderText" visible="false" runat="server" style="margin-top: 0px; min-height: 22px;">
                                                <a class="" href="#" style="color: Black; padding-left: 6px; vertical-align: sub; padding-top: 5px;">&nbsp;<%=objLanguage.GetLanguageConversion("Change_File")%></a>
                                            </li>
                                            <li id="liReRun" class="summary_itemsalign HeaderText" runat="server" style="margin-top: 0px; min-height: 22px;">
                                                <a class="" href="#" style="color: Black; padding-left: 6px; vertical-align: sub; padding-top: 5px;">&nbsp;<%=objLanguage.GetLanguageConversion("ReRun_Item")%></a>
                                            </li>
                                            <li id="RCM_Options" runat="server" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="plhAction" runat="server"></asp:PlaceHolder>
                                                <li id="liCopyItem" runat="server" class="Summary_PanelList"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Copy_Item")%></a></li>
                                                <li id="liDeleteItem" runat="server" class="Summary_PanelList"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Delete_Item")%></a></li>
                                                <li id="liEditJobCard" runat="server" class="Summary_PanelList"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Edit_Job_Card")%></a></li>
                                                <li id="liRevartItem" runat="server" class="Summary_PanelList"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Revert_Item")%></a></li>
                                                <asp:PlaceHolder ID="plhAction2" runat="server"></asp:PlaceHolder>
                                            </li>
                                            <li id="liaddItemhead" runat="server" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="plhSubItems" runat="server"></asp:PlaceHolder>
                                                <li id="lisheefedDigital" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; cursor: default;">&nbsp;<%=objLanguage.GetLanguageConversion("Sheet_Fed_Digital")%></a></li>
                                                <li id="lidigitalsingle" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;<%=objLanguage.GetLanguageConversion("Single_Item")%></a></li>
                                                <li id="lidigitalPad" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;<%=objLanguage.GetLanguageConversion("Pads")%></a></li>
                                                <li id="lisheetfedOffset" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; cursor: default;">&nbsp;<%=objLanguage.GetLanguageConversion("Sheet_Fed_Offset")%></a></li>
                                                <li id="lioffsetsingle" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;<%=objLanguage.GetLanguageConversion("Single_Item")%></a></li>
                                                <li id="lioffsetpads" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;<%=objLanguage.GetLanguageConversion("Pads")%></a></li>
                                                <li id="liOutwork" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Outwork")%></a></li>
                                                <li id="liProductCatalogue" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Product_Catalogue")%></a></li>
                                                <li id="liOtherCost" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Other_Cost")%></a></li>
                                                <li id="liDeliveryCost" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Delivery_Cost")%></a></li>
                                                <li id="liLargeItems" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; cursor: default;">&nbsp;<%=objLanguage.GetLanguageConversion("Large_Format")%></a></li>
                                                <li id="liLinear" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;<%=objLanguage.GetLanguageConversion("Linear")%></a></li>
                                                <li id="liSqMeter" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">
                                                    <asp:Label ID="aSqmeter" runat="server"></asp:Label>
                                                </a></li>
                                                <li id="liTilling" runat="server" class="Summary_PanelList lisubItems"><a class="anchor_fontsize"
                                                    href="#" style="color: Black; font-size: 11px;">&nbsp;Tilling</a></li>
                                                <li id="liInventory" runat="server" class="Summary_PanelList_main"><a class="anchor_fontsize"
                                                    href="#" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Inventory")%></a></li>
                                                <asp:PlaceHolder ID="plhSubItems2" runat="server"></asp:PlaceHolder>
                                            </li>
                                            <li id="liQl" runat="server" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="QL" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="plhQL" runat="server"></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="QL2" runat="server"></asp:PlaceHolder>
                                            </li>
                                            <li id="liViewJobAllocation" runat="server" visible="false" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="plhViewJobAllocation" runat="server"></asp:PlaceHolder>
                                            </li>
                                            <li id="liViewHistory" runat="server" visible="false" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="ViewHistory" runat="server"></asp:PlaceHolder>
                                            </li>
                                             <li id="liManualApprove" class="summary_itemsalign HeaderText" visible="false" runat="server" style="margin-top: 0px; min-height: 22px;">
                                                <a class="" href="#" style="color: Black; padding-left: 6px; vertical-align: sub; padding-top: 5px;">&nbsp;<%=objLanguage.GetLanguageConversion("Manual_Approve")%></a>
                                            </li>
                                               <li id="liManualReject" class="summary_itemsalign HeaderText" visible="false" runat="server" style="margin-top: 0px; min-height: 22px;">
                                                <a class="" href="#" style="color: Black; padding-left: 6px; vertical-align: sub; padding-top: 5px;">&nbsp;<%=objLanguage.GetLanguageConversion("Manual_Reject")%></a>
                                            </li>
                                            <li id="li2" runat="server" visible="true" class="summary_itemsalign">
                                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                            </li>
                                            <li id="quote_dtls" class="summary_itemsalign" runat="server" visible="false" style="height: 32px;">
                                                <asp:PlaceHolder ID="quote_details" runat="server"></asp:PlaceHolder>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<script language="javascript" type="text/javascript">


    function Open_ProductCatalogue(EstItemID, EstId, i) {
        debugger;
        jID = "&jID=" + jobID;
        InvID = "&InvID=" + InvoiceID;
        var hdnEstType = document.getElementById("hdnEstType_" + EstItemID).value;
        var strTypes = hdnEstType.split('~')
        var strPath = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_custdetails_quickLinks_hdnPCPath").value;
        window.location = strPath + "?EstID=" + EstId + "&EstItemID=" + EstItemID + "&ToConvert=Yes&EstType=" + strTypes[0] + "&pgFrom=" + strTypes[1] + "" + jID + "" + InvID + "";
    }


    function liRevartItem_JOb(EstId, EstItemID) {
        var x = confirm("Are you sure you want to revert this item ?");
        if (x == true) {
            item_summary.Job_Item_Revart(EstItemID, OnSuccess(EstId, EstItemID), onTimeout, onError);
        } else {
            return false;
        }
    }

    //function OpenProofs(CompanyID,EstimateID) {

    //    //debugger;
    //    //hdnEmailselectOrnot.value = "email";

    //    //showDivPopupCenter('Div_Proof_FileSelection', '250');

    //}




    function OpenProofs(CompanyID, EstimateID) {
        var pagetype = 'general';
        var _url = window.location.href;
        var Pgtype = "estimate";

       <%-- var EstimateID = "<%=EstimateID %>";
        var strSitepath = "<%=strSitepath %>";--%>
        debugger;
        var Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=proof&estid=" + EstimateID + "&pg=" + Pgtype + "&url=" + _url + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');

        if (window.window.screen.width > 1100) {
            if (window.window.screen.height > 450) {
                Rad_Attachment.setSize(1100, 555);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
                else {
                    Rad_Attachment.Center();
                }
            }
        }
        else {
            var screenwidth = window.window.screen.width;
            var screenheight = window.window.screen.height;
            if (window.window.screen.width > 1100 && screenheight > 450) {
                Rad_Attachment.setSize(screenwidth - 200, 550);
                Rad_Attachment.center();
            }
            else if (window.window.screen.width > 800) {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
            }
            else {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                Rad_Attachment.center();
            }
        }
    }
    function OnSuccessOpenProofs() {
        window.location = "../estimates/Proofs.aspx?estid=" + EstimateID;
    }

    function OnSuccess(EstId, EstItemID) {
        if (RowsCount <= 1) {
            if (window.location.href.indexOf("order_summary") > -1) {
                window.location = "../orders/order_summary.aspx?estid=" + EstimateID + "&ordid=" + EstimateID + "&EstItemID=" + EstItemID + "";
            }
            else {
                window.location = "../estimates/estimate_summary_reeng.aspx?estid=" + EstimateID + "&EstItemID=" + EstItemID + "";
            }
        }
        else {
            window.location.reload();
        }
    }
    function onTimeout(request, context) { }

    function onError(objError) {
    }


</script>
