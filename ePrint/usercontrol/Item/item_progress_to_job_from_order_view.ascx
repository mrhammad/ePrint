<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_progress_to_job_from_order_view.ascx.cs" Inherits="ePrint.usercontrol.Item.item_progress_to_job_from_order_view" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div style="float: left; width: 100%; clear: both;">
    <script type="text/javascript" language="javascript">
        var RemainingItemCnt = "<%=RemainingItemCnt%>"
        var IsArchive = "<%=IsArchive %>";
        var Module = '<%=Module %>';
        var Accountsonhold = <%=objLanguage.GetLanguageConversion("Accoutns_On_Hold") %>;
        var AccountsOnHoldEstimateProgressToJob = '<%=objLanguage.GetLanguageConversion("Accounts_On_Hold_Estimate_Progress_To_Job") %>';
        var AccountsOnHoldOrderProgressToJob = '<%=objLanguage.GetLanguageConversion("Accounts_On_Hold_Estimate_Progress_To_Order") %>';
    </script>
    <%--div added in progress to job For to check all po checkboxes gets created--%>
    <div id="divbackground_new_selected" style="display: none; position: absolute; filter: alpha(opacity=50); opacity: 0.50; -moz-opacity: 0.50; z-index: 0; left: 0px; width: 100%; height: 100%; top: 0px;">
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" height="82%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" id="divIsArchivePrompt" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px; display: none;">
                    <%--<%=divIsArchivePrompt_style%>--%>
                    <b>Alert(Default)</b>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
                <div align="left" id="divProgressToJob" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px; <%=divProgressToJob_style%>">
                    <b>
                        <%=objLanguage.GetLanguageConversion("Progress_To_Job")%></b>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton7" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv();return false;" />
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
                            <asp:UpdateProgress ID="upProgress" runat="server">
                                <ProgressTemplate>
                                    <div id="div_Pro_Load" class="loading_new">
                                        <UC:Loading ID="ucLoading_Pro" runat="server" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div>
                                <asp:UpdatePanel ID="UpProg" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblTest" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnCheckJobCreate" runat="server" />
                                        <asp:HiddenField ID="hdnIndJobCreateItemID" runat="server" Value="0" />
                                        <asp:HiddenField ID="hid_Progress_Items" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_Progress_Items_Chkd" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnCompanyID" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_Selected_Items" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_Selected_Items_P2J_Clck" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_Remaining_Items" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_All_Items" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_TxtOrderNo" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnEstItemsSelected" runat="server" />
                                        <asp:HiddenField ID="hdnEstItemsSelected_P2J" runat="server" />
                                        <asp:HiddenField ID="hdnSubItemsIDs" runat="server" />
                                        <asp:HiddenField ID="hdnSubItemsIDs_OtherCost" runat="server" />
                                        <asp:HiddenField ID="hdnSubItemsIDs_OtherCost_PO" runat="server" />
                                        <asp:HiddenField ID="hdnSubItemsIDs_PO" runat="server" />
                                        <asp:HiddenField ID="hdnLFSubItemsIDs_PO" runat="server" />
                                        <asp:HiddenField ID="hdnEstItems" runat="server" />
                                        <asp:HiddenField ID="hdnEstItemsSelected_PO" runat="server" />
                                        <asp:HiddenField ID="hdnLFSelected_PO" runat="server" />
                                        <asp:HiddenField ID="hdn_Job_Archive" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnProductAddItemsIDs" runat="server" />
                                        <asp:HiddenField ID="hdnProductAddItemsIDs_PO" runat="server" />
                                        <asp:HiddenField ID="hdn_estimatetypeinv" runat="server" />
                                        <asp:HiddenField ID="hdn_getselected_supplier" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername1" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername2" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername3" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername4" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername_singleqty_O" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername_singleqty_C" runat="server" />
                                        <asp:HiddenField ID="hdn_suppliername_singleqty_W" runat="server" />
                                        <asp:HiddenField ID="hdn_getselected_supplier_c_o" runat="server" />
                                        <asp:HiddenField ID="hdn_checkprogresstojob" runat="server" />
                                        <asp:LinkButton ID="lnkNext_SlctedItems" runat="server" OnClick="btnNext_SelectedItems"></asp:LinkButton><%--OnClick="btnNext_SlctedItems_OnClick"--%>
                                        <asp:LinkButton ID="lnkNext" runat="server" OnClick="btnProgNext_OnClick"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkProgress" runat="server" OnClick="lnkProgress_OnClick"></asp:LinkButton>
                                        <asp:PlaceHolder runat="server" ID="plhProJob"></asp:PlaceHolder>
                                        <asp:HiddenField ID="hdn_OrderProgressToJob" runat="server" />
                                        <script type="text/javascript">
                                            var hdn_select1 = document.getElementById("<%=hid_Selected_Items.ClientID %>");
                                            var hdn_select2 = document.getElementById("<%=hid_Selected_Items_P2J_Clck.ClientID %>");
                                            var IsStockMgmtEnabled = '<%=IsStockMgmtEnabled %>';
                                            var FullCheck = true;
                                            var Count1 = 0;
                                            var Count2 = 0;
                                            var NoP2J_Msg = '<%=objLanguage.GetLanguageConversion("Cannot_Progress_To_Job_Msg")%>';
                                            var P2J_already_done_Msg = '<%=objLanguage.GetLanguageConversion("Estimate_Already_Progressed_To_Job_Msg")%>';
                                            var hdnEstItemsSelected_P2J = document.getElementById("<%=hdnEstItemsSelected_P2J.ClientID %>");

                                            function Ok_and_Next_Before() {
                                                debugger;
                                                //Count1 = 0;
                                                //Count2 = 0;
                                                //AutoFill.ClearHashTable(NoResponse);
                                                document.getElementById("ctl00_ContentPlaceHolder1_UcProgressToJob_hdn_OrderProgressToJob").value = document.getElementById("hdnOrderProgressToJob").value;
                                                __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkProgress', '');
                                                return false;
                                                <%--var hdnEstItemsSelected = document.getElementById("<%=hdnEstItemsSelected.ClientID %>");
                                                var hdnEstItemsSelected_PO = document.getElementById("<%=hdnEstItemsSelected_PO.ClientID %>");
                                                var hdnSubItemsIDs = document.getElementById("<%=hdnSubItemsIDs.ClientID %>");
                                                var hdnSubItemsIDs_PO = document.getElementById("<%=hdnSubItemsIDs_PO.ClientID %>");
                                                var hdnLFSubItemsIDs_PO = document.getElementById("<%=hdnLFSubItemsIDs_PO.ClientID %>");
                                                var hdnLFSelected_PO = document.getElementById("<%=hdnLFSelected_PO.ClientID %>");

                                                var hdnSubItemsIDs_OtherCost = document.getElementById("<%=hdnSubItemsIDs_OtherCost.ClientID %>");
                                                var hdnSubItemsIDs_OtherCost_PO = document.getElementById("<%=hdnSubItemsIDs_OtherCost_PO.ClientID %>");

                                                // For Product Addtional Items
                                                var hdnProductAddItemsIDs = document.getElementById("<%=hdnProductAddItemsIDs.ClientID %>");
                                                var hdnProductAddItemsIDs_PO = document.getElementById("<%=hdnProductAddItemsIDs_PO.ClientID %>");

                                                if (RemainingItemCnt == 1 && document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value != "" && document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value.trim().toLowerCase() == "w") {
                                                    document.getElementById("divdates").style.display = "block";
                                                    document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value = hdnEstItemsSelected_var;
                                                    // __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');

                                                }
                                                if (document.getElementById('divdates').style.display != "none") {
                                                    if (hdnEstItemsSelected.value == "null" || hdnEstItemsSelected.value == "") {
                                                        hdnEstItemsSelected.value = hdnEstItemsSelected_var_3;
                                                    }
                                                    var AllDetails = hdnEstItemsSelected.value.split('±');
                                                    var SubItemsIDs = hdnSubItemsIDs.value.split('▲');
                                                    var SubItemsIDs_OtherCost = hdnSubItemsIDs_OtherCost.value.split('▲');
                                                    var AllProductAddItems = hdnProductAddItemsIDs.value.split('±');

                                                    var Selected_PO = "";
                                                    var LargeFormatSelected_PO = "";

                                                    for (var t = 0; t < AllDetails.length - 1; t++) {
                                                        var IndITems = AllDetails[t].split('»');

                                                        if (IndITems[1].toLowerCase() == "l") {
                                                            var lblMatIDS = document.getElementById("lblMaterialIds_" + IndITems[0]).innerHTML;
                                                            var lblMaterialIds = lblMatIDS.split('▼');

                                                            for (var h = 0; h < lblMaterialIds.length - 1; h++) {
                                                                var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_" + IndITems[0] + "_" + lblMaterialIds[h]);
                                                                if (chkRaisePO.checked) {
                                                                    LargeFormatSelected_PO += IndITems[0] + "_" + lblMaterialIds[h] + "▼";
                                                                }
                                                            }
                                                        }
                                                        else {
                                                            var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_" + IndITems[0]);
                                                            if (chkRaisePO.checked) {
                                                                Selected_PO += IndITems[0] + "↑";
                                                            }
                                                        }
                                                    }
                                                    hdnEstItemsSelected_PO.value = Selected_PO;
                                                    hdnLFSelected_PO.value = LargeFormatSelected_PO;


                                                    var Selected_SubItem_PO = "";
                                                    var Selected_SubItem_PO_OtherCost = "";
                                                    var LargeFormatSelected_SubItem_PO = "";
                                                    var OtherCostDone = false;

                                                    for (var n = 0; n < SubItemsIDs.length - 1; n++) {
                                                        var ItmsChk1 = SubItemsIDs[n].split('»');

                                                        if (ItmsChk1[1].toLowerCase() == "l") {

                                                            var lblCheck = document.getElementById("lblMaterialIds_" + ItmsChk1[0]);
                                                            if (lblCheck != null && lblCheck != undefined) {
                                                                var lblMatIDS = lblCheck.innerHTML;
                                                                var lblMaterialIds = lblMatIDS.split('▼');

                                                                for (var h = 0; h < lblMaterialIds.length - 1; h++) {

                                                                    var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_" + ItmsChk1[0] + "_" + lblMaterialIds[h]);
                                                                    if (chkRaisePO != null && chkRaisePO != undefined) {
                                                                        if (chkRaisePO.checked) {
                                                                            LargeFormatSelected_SubItem_PO += ItmsChk1[0] + "_" + lblMaterialIds[h] + "▼";
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (ItmsChk1[1].toLowerCase() == "u") {
                                                            if (OtherCostDone == false) {
                                                                for (var a = 0; a < SubItemsIDs_OtherCost.length - 1; a++) {

                                                                    var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_" + SubItemsIDs_OtherCost[a]);
                                                                    if (chkRaisePO != null && chkRaisePO != undefined) {
                                                                        if (chkRaisePO.checked) {
                                                                            Selected_SubItem_PO_OtherCost += SubItemsIDs_OtherCost[a] + "↑";
                                                                        }
                                                                    }
                                                                }
                                                                OtherCostDone = true;
                                                            }
                                                        }
                                                        else {

                                                            var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_" + ItmsChk1[0]);
                                                            if (chkRaisePO != null && chkRaisePO != undefined) {
                                                                if (chkRaisePO.checked) {
                                                                    Selected_SubItem_PO += ItmsChk1[0] + "↑";
                                                                }
                                                            }
                                                        }
                                                    }
                                                    hdnSubItemsIDs_PO.value = Selected_SubItem_PO;
                                                    hdnLFSubItemsIDs_PO.value = LargeFormatSelected_SubItem_PO;
                                                    hdnSubItemsIDs_OtherCost_PO.value = Selected_SubItem_PO_OtherCost;

                                                    var ProductAddItemsIDs_PO = "";

                                                    for (var y = 0; y < AllProductAddItems.length - 1; y++) {
                                                        var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_chkRaisePO_PrAdIt_" + AllProductAddItems[y]);
                                                        if (chkRaisePO.checked) {
                                                            ProductAddItemsIDs_PO += AllProductAddItems[y] + "↑";
                                                        }
                                                    }
                                                    hdnProductAddItemsIDs_PO.value = ProductAddItemsIDs_PO;

                                                    if ('<%=Ordernumbervalidtiononlyforcoralcoastsystem%>' == 'yes' && Module.toLowerCase() != 'order') {
                                                        var TxtOrderNo = document.getElementById("<%=TxtOrderNo.ClientID%>");
                                                        if (TxtOrderNo.value != '') {
                                                            var hdnCompanyID = document.getElementById("<%=hdnCompanyID.ClientID %>");
                                                            var hid_Remaining_Items = document.getElementById("<%=hid_Remaining_Items.ClientID %>");
                                                            var hid_Progress_Items = document.getElementById("<%=hid_Progress_Items.ClientID %>");
                                                            var cK = hid_Progress_Items.value + 'Â±' + hid_Remaining_Items.value;
                                                            cK = cK.substring(0, cK.length - 1);
                                                            var StrMnArry = cK.split('±');

                                                            var chkNoProductsType = true;
                                                            for (var i = 0; i < StrMnArry.length; i++) {
                                                                var StrSubArry = StrMnArry[i].toString().split('»');
                                                                if (typeof StrSubArry != 'undefined' && StrSubArry != undefined && StrSubArry != null && StrSubArry != '' &&
                                                                    typeof hdnEstItemsSelected_P2J != 'undefined' && hdnEstItemsSelected_P2J != undefined && hdnEstItemsSelected_P2J != null && hdnEstItemsSelected_P2J != '') {
                                                                    if (hdnEstItemsSelected_P2J.value.indexOf(StrSubArry[0]) !== -1) {

                                                                        var EstItem_ID = StrSubArry[0];
                                                                        var Est_Type = StrSubArry[1];
                                                                        var Qty_Number = StrSubArry[2];

                                                                        //if (Est_Type == 'C' || Est_Type == 'X') {
                                                                        if (IsStockMgmtEnabled == 'true') {
                                                                            Count1++;
                                                                            chkNoProductsType = false;
                                                                            AutoFill.CheckProgressToJobPossible(hdnCompanyID.value, EstItem_ID, Est_Type, Qty_Number, Module.toLowerCase(), GetJobPossible_Full, onTimeout, onError);
                                                                        }
                                                                        //}
                                                                    }
                                                                }
                                                            }

                                                            if (chkNoProductsType) {
                                                                document.getElementById("divdates").style.display = "none";
                                                                var chkCheckProspect = document.getElementById("<%=chkprospectYes.ClientID%>");
                                                                var TxtOrderNo = document.getElementById("<%=TxtOrderNo.ClientID%>");
                                                                document.getElementById("<%=hid_TxtOrderNo.ClientID%>").value = TxtOrderNo.value;
                                                                document.getElementById("<%=hdn_checkprogresstojob.ClientID %>").value = 'yes';
                                                                __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkProgress', '');
                                                                return false;
                                                            }
                                                        }
                                                        else {
                                                            document.getElementById('spn_txtorderno').style.display = "block";
                                                            return false;
                                                        }
                                                    }
                                                    else {
                                                        var hdnCompanyID = document.getElementById("<%=hdnCompanyID.ClientID %>");
                                                        var hid_Remaining_Items = document.getElementById("<%=hid_Remaining_Items.ClientID %>");
                                                        var hid_Progress_Items = document.getElementById("<%=hid_Progress_Items.ClientID %>");
                                                        var cK = hid_Progress_Items.value + 'Â±' + hid_Remaining_Items.value;
                                                        cK = cK.substring(0, cK.length - 1);
                                                        var StrMnArry = cK.split('±');

                                                        var chkNoProductsType = true;
                                                        for (var i = 0; i < StrMnArry.length; i++) {
                                                            var StrSubArry = StrMnArry[i].toString().split('»');
                                                            if (typeof StrSubArry != 'undefined' && StrSubArry != undefined && StrSubArry != null && StrSubArry != '' &&
                                                                typeof hdnEstItemsSelected_P2J != 'undefined' && hdnEstItemsSelected_P2J != undefined && hdnEstItemsSelected_P2J != null && hdnEstItemsSelected_P2J != '') {
                                                                if (hdnEstItemsSelected_P2J.value.indexOf(StrSubArry[0]) !== -1) {

                                                                    var EstItem_ID = StrSubArry[0];
                                                                    var Est_Type = StrSubArry[1];
                                                                    var Qty_Number = StrSubArry[2];

                                                                    //if (Est_Type == 'C' || Est_Type == 'X') {
                                                                    if (IsStockMgmtEnabled == 'true') {
                                                                        Count1++;
                                                                        chkNoProductsType = false;
                                                                        AutoFill.CheckProgressToJobPossible(hdnCompanyID.value, EstItem_ID, Est_Type, Qty_Number, Module.toLowerCase(), GetJobPossible_Full, onTimeout, onError);
                                                                    }
                                                                    //}
                                                                }
                                                            }
                                                        }

                                                        document.getElementById("<%=hdn_checkprogresstojob.ClientID %>").value = 'no';
                                                        if (chkNoProductsType) {
                                                            document.getElementById("divdates").style.display = "none";
                                                            var chkCheckProspect = document.getElementById("<%=chkprospectYes.ClientID%>");
                                                            var TxtOrderNo = document.getElementById("<%=TxtOrderNo.ClientID%>");
                                                            document.getElementById("<%=hid_TxtOrderNo.ClientID%>").value = TxtOrderNo.value;
                                                            document.getElementById("<%=hdn_checkprogresstojob.ClientID %>").value = 'yes';
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkProgress', '');
                                                            return false;
                                                        }
                                                    }
                                                }--%>
                                            }

                                            function GetJobPossible_Full(result) {
                                                Count2++;
                                                //Order progress to job available stock check removed as required in ticket # 6246 by Bilal 20-11-2017
                                                //if (result == "false") { 
                                                //FullCheck = false;
                                                //}
                                                if (Count1 == Count2) {
                                                    if (FullCheck) {
                                                        document.getElementById("divdates").style.display = "none";
                                                        var chkCheckProspect = document.getElementById("<%=chkprospectYes.ClientID%>");
                                                        var TxtOrderNo = document.getElementById("<%=TxtOrderNo.ClientID%>");
                                                        document.getElementById("<%=hid_TxtOrderNo.ClientID%>").value = TxtOrderNo.value;
                                                        document.getElementById("<%=hdn_checkprogresstojob.ClientID %>").value = 'yes';
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkProgress', '');
                                                        // __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    }
                                                    else {
                                                        document.getElementById("div_ProgressToJob").style.display = "none";
                                                        document.getElementById("divBackGroundNew").style.display = "none";
                                                        document.getElementById("div_Pro_Load").style.display = "none";
                                                        alert(NoP2J_Msg);
                                                        window.location.reload();
                                                        return false;
                                                    }
                                                }
                                            }

                                            var FullCheck2 = true;
                                            function GetJobPossible(result) {
                                                if (result == "false") {
                                                    document.getElementById("div_ProgressToJob").style.display = "none";
                                                    document.getElementById("divBackGroundNew").style.display = "none";
                                                    document.getElementById("div_Pro_Load").style.display = "none";
                                                    alert(NoP2J_Msg);
                                                    FullCheck2 = false;
                                                    window.location.reload();
                                                    return false;
                                                }
                                            }

                                            var hdnEstItemsSelected_var = '';
                                            var strarray_items_5 = '';
                                            var hdnEstItemsSelected_var_3 = '';

                                            function Ok_and_Next(para) {
                                                var hdnCheckJobCreate = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCheckJobCreate");
                                                if (document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value != "") {
                                                    hdnEstItemsSelected_var = document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value; //added for 13568
                                                }
                                                document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value = "";
                                                var spn_info = document.getElementById("spn_info_" + para + "").innerHTML;
                                                var StrArry1 = spn_info.split('»');

                                                var EstItemID = StrArry1[0];
                                                var EstType = StrArry1[1];

                                                get_qty_no(spn_info);

                                                //added for ticket 13568
                                                document.getElementById("divIsArchivePrompt").style.display = "none";
                                                document.getElementById("divProgressToJob").style.display = "block";

                                                if (RemainingItemCnt == 1) {
                                                    document.getElementById("divEstItemsList").style.display = "none";
                                                    // document.getElementById("divdates").style.display = "block";
                                                    document.getElementById("div_IsArchive").style.display = "none";
                                                    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = 'none';
                                                }
                                                else {
                                                    document.getElementById("divEstItemsList").style.display = "none";
                                                    document.getElementById("div_IsArchive").style.display = "none";
                                                    document.getElementById("divdates").style.display = "none";
                                                    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = "block";
                                                }

                                                var get_estimateitemqty_count_multipleitems_var = "<%=get_estimateitemqty_count_multipleitems %>";
                                                //if (EstType == 'C' || EstType == 'X') {
                                                var hid_Progress_Items = document.getElementById("<%=hid_Progress_Items.ClientID %>");
                                                var hid_Progress_Items_Chkd = document.getElementById("<%=hid_Progress_Items_Chkd.ClientID %>");
                                                var hdnCompanyID = document.getElementById("<%=hdnCompanyID.ClientID %>");
                                                var StrArry2 = hid_Progress_Items_Chkd.value.split('Â±');
                                                //added for product catalogue type 13568
                                                if (hdnCheckJobCreate.value == "true") {
                                                    document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = hdnEstItemsSelected_var;
                                                    document.getElementById("divEstItemsList").style.display = "none";
                                                    document.getElementById("divdates").style.display = "block";
                                                    //Added To check po checkboxes Created or not
                                                    document.getElementById("divbackground_new_selected").style.display = "block";
                                                    document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                    __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                }


                                                for (var j = 0; j < StrArry2.length - 1; j++) {
                                                    var StrArry3 = StrArry2[j].split('Â»');
                                                    //if (StrArry3[1] == 'C' || StrArry3[1] == 'X') {
                                                    debugger;
                                                    AutoFill.CheckProgressToJobPossible(hdnCompanyID.value, StrArry3[0], StrArry3[1], StrArry3[2], Module.toLowerCase(), GetJobPossible, onTimeout, onError);
                                                    // }
                                                }


                                                <%--if (RemainingItemCnt > 1 && EstType == 'C' && (get_estimateitemqty_count_multipleitems_var.indexOf('2') > -1 ||
                                                        get_estimateitemqty_count_multipleitems_var.indexOf('3') > -1 ||
                                                        get_estimateitemqty_count_multipleitems_var.indexOf('4') > -1)) {

                                                        document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = hdnEstItemsSelected_var;
                                                        if (document.getElementById("<%=hid_Selected_Items.ClientID%>").value != "") {
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                        }
                                                        else {
                                                            if (FullCheck2)
                                                                document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = 'none';
                                                            document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = hdnEstItemsSelected_var;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        }
                                                    }
                                                    else {
                                                        if (EstType == 'C' && RemainingItemCnt > 1) {
                                                            if (FullCheck2)
                                                                document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = 'none';
                                                            document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = hdnEstItemsSelected_var;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        }
                                                    }--%>


                                                if (document.getElementById("<%=hid_Selected_Items.ClientID %>").value == '') {
                                                    if (FullCheck2) {
                                                        //Added To check po checkboxes Created or not
                                                        document.getElementById("divbackground_new_selected").style.display = "block";
                                                        document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                        document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value = hdnEstItemsSelected_var;
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        document.getElementById("divBackGroundNew").style.display = "block";
                                                        document.getElementById("div_Pro_Load").style.display = "block";
                                                        document.getElementById('divdates').style.display = "block";
                                                        document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg').style.display = 'none';
                                                    }
                                                    else {

                                                        document.getElementById('divdates').style.display = "block";
                                                        document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg').style.display = 'none';
                                                        document.getElementById("div_ProgressToJob").style.display = "none";
                                                        document.getElementById("divBackGroundNew").style.display = "none";
                                                        document.getElementById("div_Pro_Load").style.display = "none";
                                                        alert(NoP2J_Msg);
                                                    }
                                                }
                                                else {
                                                    __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = "block";
                                                }

                                                <%--}
                                                else {

                                                    if (document.getElementById("<%=hid_Selected_Items.ClientID %>").value == '') {
                                                        if (FullCheck2) {
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value = hdnEstItemsSelected_var;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                            document.getElementById("divBackGroundNew").style.display = "block";
                                                            document.getElementById("div_Pro_Load").style.display = "block";
                                                            document.getElementById('divdates').style.display = "block";
                                                            document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg').style.display = 'none';
                                                        }
                                                        else {

                                                            document.getElementById('divdates').style.display = "block";
                                                            document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg').style.display = 'none';
                                                            document.getElementById("div_ProgressToJob").style.display = "none";
                                                            document.getElementById("divBackGroundNew").style.display = "none";
                                                            document.getElementById("div_Pro_Load").style.display = "none";
                                                            alert(NoP2J_Msg);
                                                        }
                                                    }
                                                    else {
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                        document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_UpProg").style.display = "block";
                                                    }
                                                }--%>
                                            }

                                            function onTimeout(request, context) { }

                                            function onError(objError) { }

                                            function NoResponse() {
                                            }



                                            function get_qty_no(spn_info) {

                                                var Arry_0 = spn_info.split('»');
                                                var EstItemID = Arry_0[0];
                                                var EstType = Arry_0[1];

                                                var hid_Progress_Items = document.getElementById("<%=hid_Progress_Items.ClientID %>");
                                                var hid_Progress_Items_Chkd = document.getElementById("<%=hid_Progress_Items_Chkd.ClientID %>");


                                                if (document.getElementById("rd_1_" + EstItemID + "") != null) {
                                                    if (document.getElementById("rd_1_" + EstItemID + "").checked) {
                                                        hid_Progress_Items.value = hid_Progress_Items.value + EstItemID + "»" + EstType + "»1±";
                                                        hid_Progress_Items_Chkd.value = EstItemID + "»" + EstType + "»1±";
                                                    }
                                                }
                                                if (document.getElementById("rd_2_" + EstItemID + "") != null) {
                                                    if (document.getElementById("rd_2_" + EstItemID + "").checked) {
                                                        hid_Progress_Items.value = hid_Progress_Items.value + EstItemID + "»" + EstType + "»2±";
                                                        hid_Progress_Items_Chkd.value = EstItemID + "»" + EstType + "»2±";
                                                    }
                                                }
                                                if (document.getElementById("rd_3_" + EstItemID + "") != null) {
                                                    if (document.getElementById("rd_3_" + EstItemID + "").checked) {
                                                        hid_Progress_Items.value = hid_Progress_Items.value + EstItemID + "»" + EstType + "»3±";
                                                        hid_Progress_Items_Chkd.value = EstItemID + "»" + EstType + "»3±";
                                                    }
                                                }
                                                if (document.getElementById("rd_4_" + EstItemID + "") != null) {
                                                    if (document.getElementById("rd_4_" + EstItemID + "").checked) {
                                                        hid_Progress_Items.value = hid_Progress_Items.value + EstItemID + "»" + EstType + "»4±";
                                                        hid_Progress_Items_Chkd.value = EstItemID + "»" + EstType + "»4±";
                                                    }
                                                }
                                            }

                                            function Promt_For_Archive() {
                                                document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_upProgress').style.display = 'block';
                                                var hdnCheckJobCreate = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCheckJobCreate");
                                                var hdn_Job_Archive = document.getElementById("<%=hdn_Job_Archive.ClientID %>");
                                                var rdb_Generate_Job_keep_the_Estimate_live = document.getElementById("<%=rdb_Generate_Job_keep_the_Estimate_live.ClientID %>");
                                                var rdb_Generate_Job_archive_the_Estimate = document.getElementById("<%=rdb_Generate_Job_archive_the_Estimate.ClientID %>");
                                                document.getElementById("div_IsArchive").style.display = "none";

                                                if (rdb_Generate_Job_keep_the_Estimate_live.checked) {
                                                    hdn_Job_Archive.value = "Live";
                                                }
                                                else if (rdb_Generate_Job_archive_the_Estimate.checked) {
                                                    hdn_Job_Archive.value = "Archive";
                                                }
                                                var get_hdnitems_selected = document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value;
                                                if (hdnCheckJobCreate.value == "true") {
                                                    //var RdoBtn_Selected = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_RdoBtn_Selected");
                                                    //RdoBtn_Selected.checked = true;
                                                    document.getElementById("div_IsArchive").style.display = "none";
                                                    EstItemListNext_Individual();
                                                    return false;
                                                }
                                                else {

                                                    document.getElementById("divIsArchivePrompt").style.display = "none";
                                                    document.getElementById("divProgressToJob").style.display = "block";

                                                    if (RemainingItemCnt == 1) {
                                                        document.getElementById("divEstItemsList").style.display = "none";
                                                        //  document.getElementById("divdates").style.display = "block";
                                                        document.getElementById("div_IsArchive").style.display = "none";
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    }
                                                    else {
                                                        //document.getElementById("divEstItemsList").style.display = "none";
                                                        document.getElementById("div_IsArchive").style.display = "none";
                                                        // document.getElementById("divdates").style.display = "block";                                                       
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    }
                                                    var get_hdnitems_selected = document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value;
                                                    hdnEstItemsSelected_var_3 = get_hdnitems_selected;
                                                    var get_all_estimatetypesvar = "<%=get_all_estimatetypes %>";
                                                    //added to check items quantity for 13568 
                                                    var ItemsWithSingleQty_Chk = "";
                                                    if (document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value != "null" ||
                                                        document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value != 'undefined') {
                                                        ItemsWithSingleQty_Chk = document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value.split('±');
                                                    }

                                                    var OnlyMultipleQtyItems = "";
                                                    var selecteditemids = '';
                                                    var check_havingmultipleqty = OnlyMultipleQtyItems;
                                                    //checking inventory(single item) is need to progress for job(13568)
                                                    if (RemainingItemCnt == 1 && document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value != ""
                                                        && document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value.trim().toLowerCase() == "w"
                                                        && get_all_estimatetypesvar.length == 1) {
                                                        document.getElementById("divdates").style.display = "block";
                                                        //Added To check po checkboxes Created or not
                                                        document.getElementById("divbackground_new_selected").style.display = "block";
                                                        document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                    }
                                                    else {
                                                        if (document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value.trim().toLowerCase() == "w"
                                                            && get_all_estimatetypesvar.length == 1) {
                                                            document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        }
                                                        else if (get_all_estimatetypesvar > 1) {
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                        }
                                                    }

                                                    //checking quickquote(single item) (13568)
                                                    var check_multipleqtyquickquote = document.getElementById("<%= hid_Selected_Items.ClientID%>").value;
                                                    document.getElementById("<%= hdnEstItemsSelected.ClientID%>").value = check_multipleqtyquickquote;
                                                    if (document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value.trim().toLowerCase() == "q"
                                                        && RemainingItemCnt == 1 && check_multipleqtyquickquote != "" && check_multipleqtyquickquote != 'null') {
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    }
                                                    else {
                                                        if (document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value.trim().toLowerCase() == "q"
                                                            && get_all_estimatetypesvar.length == 1) {
                                                            document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        }
                                                        else if (get_all_estimatetypesvar > 1) {
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                        }
                                                    }

                                                    var getqtycount = document.getElementById("<%=hid_Remaining_Items.ClientID%>").value;
                                                    var get_estimateitemqty_count_var = "<%=get_estimateitemqty_count %>";
                                                    var cK = getqtycount;
                                                    cK = cK.substring(0, cK.length - 1);
                                                    var StrMnArry = cK.split('±');
                                                    var Qty_Number = "";
                                                    var chkNoProductsType = true;
                                                    for (var i = 0; i < StrMnArry.length; i++) {
                                                        var StrSubArry = StrMnArry[i].toString().split('»');
                                                        var EstItem_ID = StrSubArry[0];
                                                        var Est_Type = StrSubArry[1];
                                                        var Qty_Number = StrSubArry[2];
                                                    }

                                                    //get selected items quantity number 
                                                    var get_all_estimateitemid_var = "<%=get_all_estimateitemid %>";
                                                    var itemids = get_all_estimateitemid_var.split(',');
                                                    var selectedqty_new = '';
                                                    var selected_itemids3 = '';
                                                    var get_estimateitemqty_count_multipleitems_var2 = "<%=get_estimateitemqty_count_multipleitems %>";
                                                    var selected_itemids2 = '';
                                                    selected_itemids2 = get_hdnitems_selected.split('±');
                                                    var selected_itemids4 = selected_itemids2;
                                                    var selecteditemidsnew = '';

                                                    for (var k = 0; k < selected_itemids4.length; k++) {
                                                        var selected_itemids7 = selected_itemids4[k].split('»');
                                                        selecteditemidsnew += selected_itemids7[0] + ",";
                                                    }

                                                    //get selected items quantity number 13568
                                                    var selected_itemids6 = selecteditemidsnew.split(',');
                                                    for (var s = 0; s < selected_itemids6.length - 1; s++) {
                                                        if (itemids[s] != "") {
                                                            for (var t = 0; t < itemids.length - 1; t++) {
                                                                if (itemids[t] == selected_itemids6[s]) {
                                                                    selectedqty_new += get_estimateitemqty_count_multipleitems_var2[t]; //contains max qty number of each item
                                                                }
                                                            }
                                                        }
                                                    }

                                                    var type_new = document.getElementById("<%=hdn_estimatetypeinv.ClientID%>").value;
                                                    if (type_new.trim().toLowerCase() == "x") {
                                                        document.getElementById("divdates").style.display = "block";
                                                        //Added To check po checkboxes Created or not
                                                        document.getElementById("divbackground_new_selected").style.display = "block";
                                                        document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                        document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = get_hdnitems_selected;
                                                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                    }
                                                    if (RemainingItemCnt == 1 &&
                                                        (type_new.trim().toLowerCase() != "q" || type_new.trim().toLowerCase() != "w" || type_new.trim().toLowerCase() == "x")) {
                                                        if (get_estimateitemqty_count_var == "1" && (typeof get_estimateitemqty_count_var != 'undefined')
                                                            && get_estimateitemqty_count_var != "") {
                                                            document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = get_hdnitems_selected;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                        }
                                                    }
                                                    else {
                                                        document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = get_hdnitems_selected;
                                                        //added to check any item has multiple quatity(13568) 
                                                        if (selectedqty_new.indexOf('2') > -1 ||
                                                            selectedqty_new.indexOf('3') > -1 ||
                                                            selectedqty_new.indexOf('4') > -1 && selectedqty_new != '') {
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                        }
                                                        else {
                                                            document.getElementById("divdates").style.display = "block";
                                                            //Added To check po checkboxes Created or not
                                                            document.getElementById("divbackground_new_selected").style.display = "block";
                                                            document.getElementById("divbackground_new_selected").style.zIndex = 110;
                                                            document.getElementById("<%=hdnEstItemsSelected.ClientID%>").value = get_hdnitems_selected;
                                                            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
                                                            return false;
                                                        }
                                                    }


                                                    return false;

                                                    // var chkNoProductsType = true;
                                                    //  if (chkNoProductsType) {
                                                    //    document.getElementById("divdates").style.display = "none";
                                                    //  
                                                    //     var chkCheckProspect = document.getElementById("<%=chkprospectYes.ClientID%>");
                                                    // document.getElementById("<%=hid_TxtOrderNo.ClientID%>").value = TxtOrderNo.value;
                                                    ///   __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
                                                    //    return false;
                                                    // }
                                                }
                                            }
                                            function pageLoad() {

                                                if (typeof document.getElementById("divbackground_new_selected") !== 'undefined'
                                                    || document.getElementById("divbackground_new_selected") !== 'null') {
                                                    document.getElementById("divbackground_new_selected").style.zIndex = '0';
                                                    document.getElementById("divbackground_new_selected").style.display = 'none';
                                                }
                                            }
                                        </script>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div id="div_IsArchive" style="<%=divIsArchive_Style%>">
                                <div style="float: left; padding-bottom: 7px;">
                                    <span style="font-weight: bold;">
                                        <asp:RadioButton ID="rdb_Generate_Job_keep_the_Estimate_live" runat="server" GroupName="archive"
                                            Text="Generate Job and keep the Estimate live" />
                                    </span>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div style="float: left; padding-bottom: 7px;">
                                    <span style="font-weight: bold;">
                                        <asp:RadioButton ID="rdb_Generate_Job_archive_the_Estimate" runat="server" GroupName="archive"
                                            Text="Generate Job and archive the Estimate" />
                                    </span>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                    <asp:Button ID="btn_Prompt_Archive" runat="server" Text="Next" OnClientClick="javascript:return Promt_For_Archive();"
                                        CssClass="button" />
                                </div>
                            </div>
                            <div id="divEstItemsList" style="<%=divEstItemsList_Style%>">
                                <asp:PlaceHolder ID="plhEstItemsList" runat="server"></asp:PlaceHolder>
                            </div>
                            <div id="divdates" style="<%=divdates_Style%>">
                                <div align="left">
                                    <div align="left" id="div_CON" runat="server" style="display:none;">
                                        <div class="bglabel">
                                            <asp:Label ID="Label13" runat="server" Text="Customer Order Number" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Customer_Order_Number")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="TxtOrderNo" runat="server" SkinID="textPad"></asp:TextBox>
                                            <span id="spn_txtorderno" class="spanerrorMsg" style="display: none; width: 175px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Customer_Order_Number")%></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div_ArtworkNew" runat="server" style="display: block;">
                                        <div class="bglabel">
                                            <asp:Label ID="Label65" runat="server" Text="Artwork Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Artwork_date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtartworkdate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtartworkdate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div_ProofNew" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label14" runat="server" Text="Proof Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Proof_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtproofdate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtproofdate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div_ApprovalNew" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label66" runat="server" Text="Approval Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Approval_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtapprovaldate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtapprovaldate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="divProductionDate" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label68" runat="server" Text="Production Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Production_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtproductiondate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtproductiondate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="divJobCompletionDate" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label15" runat="server" Text="Completion Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Completion_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtcompletiondate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtcompletiondate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div_deliverydate" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label16" runat="server" Text="Delivery Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtdeliverydate" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                            <span id="spn_txtdeliverydate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div1" style="border: 1px solid red; clear: both; display: none;">
                                        <div class="bglabel">
                                            <asp:Label ID="Label1" runat="server" Text="Delivery Date" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Date")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtdemo_date" runat="server" SkinID="textPad"></asp:TextBox>
                                            <br />
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                    </div>

                                      <div align="left" id="div_customdate1" runat="server">
                                          <div class="bglabel">
                                              <asp:Label ID="lblcustdate1" runat="server" Text="Custom Date 1" CssClass="normaltext">Custom Date 1</asp:Label>
                                          </div>
                                          <div class="box">
                                              <asp:TextBox ID="txtcustdate1" runat="server" SkinID="textPad"></asp:TextBox>
                                              <br />
                                              <span id="spn_txtcustdate1" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                          </div>
                                      </div>
                                                 <div align="left" id="div_customdate2" runat="server">
                                             <div class="bglabel">
                                                 <asp:Label ID="lblcustdate2" runat="server" Text="Custom Date 2" CssClass="normaltext">Custom Date 2</asp:Label>
                                             </div>
                                             <div class="box">
                                                 <asp:TextBox ID="txtcustdate2" runat="server" SkinID="textPad"></asp:TextBox>
                                                 <br />
                                                 <span id="spn_txtcustdate2" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                             </div>
                                         </div>
                                          <div align="left" id="div_customdate3" runat="server">
                                             <div class="bglabel">
                                                 <asp:Label ID="lblcustdate3" runat="server" Text="Custom Date 3" CssClass="normaltext">Custom Date 3</asp:Label>
                                             </div>
                                             <div class="box">
                                                 <asp:TextBox ID="txtcustdate3" runat="server" SkinID="textPad"></asp:TextBox>
                                                 <br />
                                                 <span id="spn_txtcustdate3" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                             </div>
                                         </div>
                                         <div align="left" id="div_customdate4" runat="server">
                                             <div class="bglabel">
                                                 <asp:Label ID="lblcustdate4" runat="server" Text="Custom Date 4" CssClass="normaltext">Custom Date 4</asp:Label>
                                             </div>
                                             <div class="box">
                                                 <asp:TextBox ID="txtcustdate4" runat="server" SkinID="textPad"></asp:TextBox>
                                                 <br />
                                                 <span id="spn_txtcustdate4" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                             </div>
                                         </div>
                                         <div align="left" id="div_customdate5" runat="server">
                                             <div class="bglabel">
                                                 <asp:Label ID="lblcustdate5" runat="server" Text="Custom Date 5" CssClass="normaltext">Custom Date 5</asp:Label>
                                             </div>
                                             <div class="box">
                                                 <asp:TextBox ID="txtcustdate5" runat="server" SkinID="textPad"></asp:TextBox>
                                                 <br />
                                                 <span id="spn_txtcustdate5" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                             </div>
                                          </div>


                                    <div align="left" id="div_RaiseDelivery" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="Label69" runat="server" Text="Raise Delivery Note" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Raise_Delivery_Note")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:CheckBox ID="chkDeliveryNote" runat="server" Checked="true" />
                                        </div>
                                    </div>

                                    <div align="left" id="div_RaisePOs" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="lblRaisePOs" runat="server" Text="Create PO" CssClass="normaltext">Create PO</asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:CheckBox ID="chkCreatePOs" runat="server" Checked="true" />
                                        </div>
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePnlPORaise" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnlPORaise" runat="server">
                                               
                                                <div align="left">
                                                    <asp:PlaceHolder ID="plhRaisePO" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <%-- start style="display:none" --%>


                                    <div id="divRadPO" runat="server" style="display:block">
                                        <asp:Panel ID="pnlradiopurchase" runat="server">
                                            <span id="spnRadPO" runat="server">&nbsp;</span>
                                            <asp:RadioButtonList runat="server" ID="radioButtonList" />
                                        </asp:Panel>

                                        <asp:HiddenField ID="hdisCombinedPO" runat="server" />
                                        <asp:HiddenField ID="hdnCombinedValue" runat="server" />
                                        <asp:HiddenField id="hdnIsPOPup" runat="server"/>
                                    </div>


                                    <%-- end --%>

                                    <div align="left" id="div_showinprospect" style="display:block;">
                                        <div class="bglabel">
                                            <asp:Label ID="lblProspettocustomer" runat="server" Text="Convert Prospect to a Customer?"
                                                CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Convert_Prospect_to_A_Customer")%></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:CheckBox ID="chkprospectYes" Checked="true" runat="server" />
                                            <br />
                                            <span class="smallgraytext">[By selecting this option, the prospect used in this estimate
                                                will be converted to a customer]</span>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdncheckprospect" runat="server" />
                                </div>
                                <div align="left" style="display: none">
                                    <fieldset>
                                        <legend class="HeaderText">
                                            <%=objLanguage.GetLanguageConversion("Item_List")%></legend>
                                        <div align="left" style="padding: 2px;">
                                            <div style="float: left;">
                                                <asp:CheckBox ID="chkItem1" runat="server" Text="Business Cards" OnClick="javascript:showJobQty('item1');" />
                                            </div>
                                            <div style="float: left;">
                                                <asp:CheckBox ID="chkItem2" runat="server" Text="Letter Heads" OnClick="javascript:showJobQty('item2');" />
                                            </div>
                                            <div style="float: left;">
                                                <asp:CheckBox ID="chkItem3" runat="server" Text="16pp" OnClick="javascript:showJobQty('item3');" />
                                            </div>
                                            <div class="onlyEmpty">
                                            </div>
                                        </div>
                                        <div align="left" style="padding-left: 2px">
                                            <asp:CheckBox ID="chkAllItem" runat="server" Text="All Items" OnClick="javascript:showJobQty('allitems');" />
                                        </div>
                                    </fieldset>
                                </div>
                                <div id="divQtyList" align="left" style="display: none">
                                    <fieldset>
                                        <legend class="HeaderText">
                                            <%=objLanguage.GetLanguageConversion("Quantity_List")%></legend>
                                        <div class="only5px">
                                        </div>
                                        <div align="left">
                                            <div style="float: left; width: 21%; padding-left: 6px">
                                                <%=objLanguage.GetLanguageConversion("Quantity")%>
                                            </div>
                                            <div style="float: left">
                                                Item Total ('<%=commclass.GetCurrencyinRequiredFormate("", true) %>')
                                            </div>
                                        </div>
                                        <div class="only5px">
                                        </div>
                                        <div id="divJobQty1" align="left" style="display: block">
                                            <div style="float: left; width: 22%;">
                                                <asp:RadioButton ID="rdlQty1" runat="server" Text="Qty: 1000" Checked="true" GroupName="JobQTy" />
                                            </div>
                                            <div style="float: left; padding: 5px">
                                                1316.17
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <div id="divJobQty2" align="left" style="display: none">
                                            <div style="float: left; width: 22%;">
                                                <asp:RadioButton ID="rdlQty2" runat="server" Text="Qty: 2000" Checked="false" GroupName="JobQTy" />
                                            </div>
                                            <div style="float: left; padding: 5px">
                                                1549.15
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <div id="divJobQty3" align="left" style="display: none">
                                            <div style="float: left; width: 22%;">
                                                <asp:RadioButton ID="rdlQty3" runat="server" Text="Qty: 3000" Checked="false" GroupName="JobQTy" />
                                            </div>
                                            <div style="float: left; padding: 5px">
                                                1781.75
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%;">
                                    <div style="float: left; width: 31%">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; display: none">
                                        <input type="button" value="Cancel" class="button" style="width: 65px" onclick="javascript: hideDiv1('hide')" />
                                    </div>
                                    <div style="float: left; margin-top: 8px" id="div_ClearDates" runat="server">
                                        <a id="href_ClearDates" onclick="javascript:ClearDates();" class="linkbutton" style="cursor: pointer; text-decoration: underline;">
                                            <%=objLanguage.GetLanguageConversion("Clear_Dates")%></a>
                                    </div>
                                    <div style="float: left;">
                                        &nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <div id="div_btnnext" style="display: block; padding-top: 8px;">
                                            <%--<input id="btn_Ok_and_Next_Before" type="button" value='<%=objLanguage.GetLanguageConversion("Ok")%>'
                                                class="button" style="width: 50px" onclick="l" runat="server" />--%>

                                            <asp:Button runat="server" Text="Ok" OnClientClick="javascript:Hideme();" OnClick="lnkProgress_OnClick" CssClass="button"/>

                                        </div>
                                        <div id="div_nextprocess" class="button" style="display: none; height: 13px; width: 32px;">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 5px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 5px">
                                        &nbsp;
                                    </div>
                                </div>
                                <div id="divItems" style="display: block;">
                                    <asp:PlaceHolder runat="server" ID="phItem"></asp:PlaceHolder>
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
    <asp:HiddenField ID="hdn_MaxKitAvailable" runat="server" />
    <asp:HiddenField ID="hdnOtherCostSelectedValuesRaisePO" Value="" runat="server" />
</div>
<script type="text/javascript">
    var estimateconvertedtojob = '<%=estimateconvertedtojob %>';
    var customerstatustitle = '<%=customerstatustitle %>';
    var CompanyType = '<%=CompanyType %>';

    var div_showinprospect = document.getElementById("div_showinprospect");

    var txtartworkdate = document.getElementById("<%=txtartworkdate.ClientID %>");
    var txtproofdate = document.getElementById("<%=txtproofdate.ClientID %>");
    var txtapprovaldate = document.getElementById("<%=txtapprovaldate.ClientID %>");
    var txtproductiondate = document.getElementById("<%=txtproductiondate.ClientID %>");
    var txtcompletiondate = document.getElementById("<%=txtcompletiondate.ClientID %>");
    var txtdeliverydate = document.getElementById("<%=txtdeliverydate.ClientID %>");
    var txtdemo_date = document.getElementById("<%=txtdemo_date.ClientID %>");
    var txtcustdate1 = document.getElementById("<%=txtcustdate1.ClientID %>");
    var txtcustdate2 = document.getElementById("<%=txtcustdate2.ClientID %>");
    var txtcustdate3 = document.getElementById("<%=txtcustdate3.ClientID %>");
    var txtcustdate4 = document.getElementById("<%=txtcustdate4.ClientID %>");
    var txtcustdate5 = document.getElementById("<%=txtcustdate5.ClientID %>");

    function ClearDates() {
        txtartworkdate.value = '';
        txtproofdate.value = '';
        txtapprovaldate.value = '';
        txtproductiondate.value = '';
        txtcompletiondate.value = '';
        txtdeliverydate.value = 
        txtcustdate1.value = '';
        txtcustdate2.value = '';
        txtcustdate3.value = '';
        txtcustdate4.value = '';
        txtcustdate5.value = '';
    }

    function Hideme() {
        document.getElementById("div_btnnext").style.display = "none";
    }
    

    var hdnEstItemsSelected = document.getElementById("<%=hdnEstItemsSelected.ClientID %>");
    var hdnEstItemsSelected_P2J = document.getElementById("<%=hdnEstItemsSelected_P2J.ClientID %>");
    var hdnEstItems = document.getElementById("<%=hdnEstItems.ClientID %>");

    function EstItemListNext() {
        AutoFill.ClearHashTable(NoResponse);
        var SelectItemsList = "";
        if (hdnEstItems.value != "") {
            var IDs = hdnEstItems.value.split('»');
            var AllDetails = hdnEstItemsSelected.value.split('±');
            var Cnt = 0;
            for (var i = 0; i < IDs.length - 1; i++) {
                var chk = document.getElementById("chkEstItems_" + IDs[i]);
                if (chk.checked) {
                    SelectItemsList += AllDetails[i] + "±";
                    Cnt++;
                }
            }

            if (Cnt == 0) {
                alert("Please check at least one item");
                return false;
            }

            hdnEstItemsSelected.value = SelectItemsList;
            hdnEstItemsSelected_P2J.value = SelectItemsList;
        }

        document.getElementById("divEstItemsList").style.display = "none";

        if (IsArchive == "true") {
            document.getElementById("div_IsArchive").style.display = "block";
            document.getElementById("divdates").style.display = "none";

            document.getElementById("divIsArchivePrompt").style.display = "none";
            document.getElementById("divProgressToJob").style.display = "block";
        }
        else {
            document.getElementById("div_IsArchive").style.display = "none";
            Promt_For_Archive();
        }
    }

    //for individual items change order of windows 13568
    var hdnEstItemsSelected_var_individual = document.getElementById("<%=hdnEstItemsSelected.ClientID %>").value;
    var get_estimateitemqty_count_multipleitems_var_1 = "<%=get_estimateitemqty_count_multipleitems %>";

    function EstItemListNext_Individual() {

        var hdnIndJobCreateItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnIndJobCreateItemID");

        var SelectItemsList = "";
        var j = '';
        if (hdnEstItems.value != "") {
            var IDs = hdnEstItems.value.split('»');
            var AllDetails = hdnEstItemsSelected.value.split('±');
            var Cnt = 0;
            for (var i = 0; i < IDs.length - 1; i++) {

                if (AllDetails[i].indexOf(hdnIndJobCreateItemID.value) > -1) {
                    SelectItemsList += AllDetails[i] + "±";
                    Cnt++;
                }

            }
            var itemidswithqty = '<%=getqtynumberwithitemids %>';  //133253,1>>13321,2>>
            var itemidsqtysplit = itemidswithqty.split('»');
            var qtypeqty = "";
            var lastChar = "1";
            if (SelectItemsList != "") {
                for (var p = 0; p < itemidsqtysplit.length; p++) {
                    var itemidsqtysplit1 = itemidsqtysplit[p].split(',');
                    if (itemidsqtysplit1[0].indexOf(hdnIndJobCreateItemID.value) > -1) {
                        lastChar = itemidsqtysplit1[1];
                    }
                }
            }
            var a = SelectItemsList.split('»');
            var esttype_newqw = a[1];
            j = IDs.length;
            var index = IDs.indexOf(a[0]);

            if (Cnt == 0) {
                alert("Please check at least one item");
                return false;
            }
            hdnEstItemsSelected.value = SelectItemsList;
            hdnEstItemsSelected_P2J.value = SelectItemsList;
        }

        if ((lastChar.indexOf('2') > -1 || lastChar.indexOf('3') > -1 || lastChar.indexOf('4') > -1)) {
            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext', '');
            document.getElementById("divdates").style.display = "none";
        }
        else {
            document.getElementById("divEstItemsList").style.display = "none";
            document.getElementById("divdates").style.display = "block";
            //Added To check po checkboxes Created or not
            document.getElementById("divbackground_new_selected").style.display = "block";
            document.getElementById("divbackground_new_selected").style.zIndex = 110;
            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
        }
    }

</script>
