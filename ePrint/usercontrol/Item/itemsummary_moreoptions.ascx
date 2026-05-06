<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="itemsummary_moreoptions.ascx.cs" Inherits="ePrint.usercontrol.Item.itemsummary_moreoptions" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="../js/approvalsystem.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="../js/item/item_summary.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<style>
    .olhedaer {
        list-style: none;
        padding-left: 0px;
    }

    .olAdd_items {
        list-style: none;
        padding-left: 10px;
    }

        .olAdd_items li:hover {
            background-color: #D3D3D3;
            cursor: pointer;
            border-radius: 5px;
        }

    .divHedaer {
        background-color: #FCFCFC;
        color: Lime;
    }

    .olhedaer li {
        color: black;
        padding-left: 15px;
        font-size: 12px;
    }

    .olhedaer #li_p2j #li_attatchments #li_copy #li_revert #li_rerun {
        padding-left: 0px !important;
    }

    .olhedaer li:hover {
        background-color: #D3D3D3;
        cursor: pointer;
        border-radius: 5px;
    }

    .lisubItems {
        padding: 3px 0px 3px 15px;
    }

    .main_options {
        list-style: none;
        padding-left: 0px;
    }

        .main_options li:hover {
            background-color: #EEEEEE;
            cursor: pointer;
            border-radius: 5px;
        }

    .olhedaer .mainitems {
        padding-left: 0px !important;
    }

        .olhedaer .mainitems:hover {
            background-color: #EEEEEE !important;
            cursor: pointer !important;
            border-radius: 5px !important;
        }

    #ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_li_additems img {
        margin-top: 3px;
    }

    #ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_DivMoreAction a {
        background: white !important;
        font-size: 12 !important;
        color: #000000 !important;
    }

        #ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_DivMoreAction a img {
            margin-top: -1px;
        }

        #ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_DivMoreAction a:hover {
            background-color: #EEEEEE !important;
            cursor: pointer !important;
            border-radius: 5px !important;
        }
</style>
<div id="divLoadingImageCus" runat="server" style="display: none;">
    <div id="DivLayer" class="loading_background">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
    </div>
</div>
<asp:Panel runat="server" ID="pnlCustomize">
    <asp:PlaceHolder ID="plhLeftPanel" runat="server" Visible="false"></asp:PlaceHolder>
    <div id="Div_EstSummary" runat="server">
        <div style="float: left; margin-left: -2px;">
            <asp:Button ID="btnMoreOptions" runat="server" Text="More Actions" CssClass="moreoptions white"
                onmouseover="javascript:OpenEstimateOptions(); return false;" onmouseout="javascript:ClosedMoreActions(); return false;"
                Width="160px" OnClientClick="javascript:return false;" Style="background: url(../images/down_arrow.png) 95% no-repeat; font-size: 12px; padding-top: 2px; text-align: left;"></asp:Button>
        </div>
        <div id="DivMoreAction" runat="server" class="ddM3" style="display: none; margin-top: 25px; width: 180px; height: auto;"
            onmouseover="javascript:OpenEstimateOptions(); return false;"
            onmouseout="javascript:ClosedMoreActions(); return false;">
            <div id="div_options" runat="server">
                <ol class="main_options">
                    <li>
                        <div id="div_printmail" runat="server" class="divHedaer">
                            <ol class="olhedaer">

                                <li id="li_pm" runat="server" class="mainitems showhide_pm" style="cursor: pointer;">
                                    <a href="#">
                                        <%=objLangClass.GetLanguageConversion("Print_Email")%><img id="img_arrow_pm" style='<%=img_arrow_pmstyle %>; float: right;'
                                            src="<%=strSitepath %>images/mo_arrow_left.png" alt="img" /></a></li>
                               
                            </ol>
                            <div class="slidediv_pm">
                                <ol class="olhedaer">
                                    <li id="li_allitems" class="lisubItems" runat="server" style="cursor: pointer;"></li>
                                    <li id="li_selecteditems" class="lisubItems" runat="server" style="cursor: pointer;">
                                        <%=objLangClass.GetLanguageConversion("Selected_Items")%></li>
                                    <li id="li_outwork_supplier" class="lisubItems" visible="false" runat="server" style="cursor: pointer;">
                                        <%=objLangClass.GetLanguageConversion("Outwork_Supplier")%></li>
                                </ol>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div id="div_additems" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_additems" runat="server" class="mainitems" style="cursor: pointer;"><a
                                    href="#" class="showhide_items">
                                    <%--<%=objLangClass.GetLanguageConversion("Add_Item")%><img id="img_arrow_additems" src="<%=strSitepath %>images/mo_arrow_left.png"--%>
                                    <%=objLangClass.GetLanguageConversion("Add_Main_Item")%><img id="img_arrow_additems" src="<%=strSitepath %>images/mo_arrow_left.png"
                                        style="float: right;" alt="img" /></a></li>
                            </ol>
                            <div class="slidediv_items">
                                <ol class="olAdd_items">
                                    <div id="div_Sheet_Fed_Digital" runat="server">
                                        <li id="li_Sheet_Fed_Digital" runat="server" style="cursor: pointer;"><a href="#"
                                            class="showhide_digital_items">
                                            <%=objLangClass.GetLanguageConversion("Sheet_Fed_Digital")%><img id="img_arrow_digital"
                                                src="<%=strSitepath %>images/mo_arrow_left.png" style="float: right;" alt="img" /></a></li>
                                        <div class="slidediv_digital_items">
                                            <ol class="olhedaer">
                                                <li id="li_sheetfed_digital_single" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('S');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Single_Item")%>
                                                </li>
                                                <li id="li_sheetfed_digital_booklet" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('B');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Booklet")%>
                                                </li>
                                                <li id="li_sheetfed_digital_NCR" class="lisubItems" runat="server" onclick="javascript:AddAnItem_Call('R');return false;">
                                                    <%=objLangClass.GetLanguageConversion("NCR")%>
                                                </li>
                                                <li id="li_sheetfed_digital_pads" class="lisubItems" runat="server" onclick="javascript:AddAnItem_Call('P');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Pads")%>
                                                </li>
                                            </ol>
                                        </div>
                                    </div>
                                    <div id="div_Sheet_Fed_offset" runat="server">
                                        <li id="li_Sheet_Fed_offset" runat="server" style="cursor: pointer;"><a href="#"
                                            class="showhide_offset_items">
                                            <%=objLangClass.GetLanguageConversion("Sheet_Fed_Offset")%><img id="img_arrow_offset"
                                                src="<%=strSitepath %>images/mo_arrow_left.png" style="float: right;" alt="img" /></a></li>
                                        <div class="slidediv_offset_items">
                                            <ol class="olhedaer">
                                                <li id="li_sheetfed_offset_single" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('F');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Single_Item")%></li>
                                                <li id="li_sheetfed_offset_booklet" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('K');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Booklet")%></li>
                                                <li id="li_sheetfed_offset_ncr" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('N');return false;">
                                                    <%=objLangClass.GetLanguageConversion("NCR")%></li>
                                                <li id="li_sheetfed_offset_pads" class="lisubItems" runat="server" style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('D');return false;">
                                                    <%=objLangClass.GetLanguageConversion("Pads")%></li>
                                            </ol>
                                        </div>
                                    </div>
                                    <li id="li_outwork" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('O');return false;">
                                        <a href="#">
                                            <%=objLangClass.GetLanguageConversion("Outwork")%></a></li>
                                    <li id="li_product_catalogue" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('C');return false;">
                                        <a href="#">
                                            <%=objLangClass.GetLanguageConversion("Product_Catalogue")%></a></li>
                                    <li id="li_other_cost" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('U');return false;">
                                        <a href="#">
                                            <%--<%=objLangClass.GetLanguageConversion("Other_Costs")%>--%></a></li>
                                    <li id="li_large_format" runat="server" style="cursor: pointer;"><a href="#" class="showhide_large_items">
                                        <%=objLangClass.GetLanguageConversion("Large_Format")%><img id="img_arrow_large"
                                            src="<%=strSitepath %>images/mo_arrow_left.png" style="float: right;" alt="img" /></a></li>
                                    <div class="slidediv_large_items">
                                        <ol class="olhedaer">
                                            <li id="li_large_linear" class="lisubItems" runat="server" style="cursor: pointer;"
                                                onclick="javascript:AddAnItem_Call('L');return false;">
                                                <%=objLangClass.GetLanguageConversion("Linear")%></li>
                                            <li id="li_large_sm" class="lisubItems" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('Sq');return false;"></li>
                                            <li id="li_large_tilling" class="lisubItems" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('ti');return false;">Tilling</li>
                                        </ol>
                                    </div>
                                    <li id="li_warehouse" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('W');return false;">
                                        <a href="#">
                                            <%=objLangClass.GetLanguageConversion("Warehouse")%></a></li>
                                    <li id="li_quick_qoute" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('Q');return false;">
                                        <a href="#">
                                            <%=objLangClass.GetLanguageConversion("Quick_Quote")%></a></li>
                                    <li id="li_delivery_cost" runat="server" style="cursor: pointer;" onclick="javascript:AddAnItem_Call('T');return false;">
                                        <a href="#">
                                            <%=objLangClass.GetLanguageConversion("Delivery_Cost")%></a></li>
                                </ol>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div id="div_p2job" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_p2j" runat="server" class="mainitems" style="cursor: pointer; display: none"
                                    onclick="javascript:ShowProgressToJob();return false;"><a href="#" class="showhide_P2J">
                                        <%=objLangClass.GetLanguageConversion("Progress_To_Job")%></a></li>
                            </ol>
                        </div>
                    </li>
                    <li>
                        <div id="div_attachments" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_attatchments" class="mainitems" runat="server" style="cursor: pointer;"><a
                                    href="#" class="showhide_Att">
                                    <%=objLangClass.GetLanguageConversion("Attachments")%></a></li>
                            </ol>
                        </div>
                    </li>
                    <li>
                        <div id="div_copy" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_copy" runat="server" class="mainitems" style="cursor: pointer;"><a href="#"
                                    class="showhide_Copy">
                                    <asp:Label ID="lblCopy" Text="" runat="server"></asp:Label>
                                    <img id="img_arrow_CopyItems" src="<%=strSitepath %>images/mo_arrow_left.png" style="float: right;"
                                        alt="img" /></a></li>
                            </ol>
                            <div class="slidediv_Copy">
                                <ol class="olhedaer">
                                    <li id="li_copy2same" class="lisubItems" runat="server" style="cursor: pointer;"
                                        onclick="javascript:EstimateCopyto_SameCust();return false;">
                                        <%=objLangClass.GetLanguageConversion("To_Same_Customer")%></li>
                                    <li id="li_copy2new" class="lisubItems" runat="server" style="cursor: pointer;" onclick="javascript:EstimateCopyto_NewCust();return false;">
                                        <%=objLangClass.GetLanguageConversion("To_New_Customer")%></li>
                                </ol>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div id="div_revert" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_revert" runat="server" class="mainitems" style="cursor: pointer; display: none">
                                    <a href="#" class="showhide_revert">
                                        <asp:Label ID="lblrevert" runat="server"></asp:Label></a></li>
                            </ol>
                        </div>
                    </li>
                    <li>
                        <div id="div_lock" runat="server" class="divHedaer" visible="false">
                            <ol class="olhedaer">
                                <li id="liUnlock" runat="server" class="mainitems" style="cursor: none;">
                                    <a href="#" class="showhide_revert">
                                        <asp:Label ID="lblLockUnlock" runat="server" Text="Lock Job"></asp:Label></a></li>
                            </ol>
                        </div>
                    </li>
                    <li>
                        <div id="div_rerun" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_rerun" runat="server" class="mainitems" style="cursor: pointer;" onclick="javascript:ReRunEstimateInfo();">
                                    <a href="#" class="showhide_Rerun">
                                        <%=objLangClass.GetLanguageConversion("Re_run_Customer_Info")%></a></li>
                            </ol>
                        </div>
                    </li>

                    <li>
                        <div id="div_reorder" runat="server" class="divHedaer" visible="true">
                            <ol class="olhedaer">
                                <li id="li_reorder" runat="server" class="mainitems" style="cursor: pointer;">
                                    <a href="#" class="showhide_reorder">Reorder Items
                                    </a>
                                </li>
                            </ol>
                        </div>
                    </li>

                </ol>
            </div>
        </div>
         <div style="float: left; margin-left: -2px;">
            <asp:Button ID="btnMoreProofOptions" runat="server" Text="More Actions" CssClass="moreoptions white"
                onmouseover="javascript:OpenProofOptions(); return false;" onmouseout="javascript:ClosedMoreProofActions(); return false;"
                Width="160px" OnClientClick="javascript:return false;" Style="background: url(../images/down_arrow.png) 95% no-repeat; font-size: 12px; padding-top: 2px; text-align: left;"></asp:Button>
        </div>
        <div id="DivMoreProofAction" runat="server" class="ddM3" style="display: none; margin-top: 25px; width: 180px; height: auto;"
            onmouseover="javascript:OpenProofOptions(); return false;"
            onmouseout="javascript:ClosedMoreProofActions(); return false;">
            <div id="div_proofoptions" runat="server">
                <ol class="main_options">
                     <li>
                        <div id="div_printproofmail" runat="server" class="divHedaer">
                            <ol class="olhedaer">
                                <li id="li_proofemail" runat="server" class="mainitems showhideproof_pm" style="cursor: pointer;">
                                    <a href="#">
                                        <%=objLangClass.GetLanguageConversion("Proof_Email")%><img id="img_arrow_pm_proof" style='<%=img_arrow_pmstyle %>; float: right;'
                                            src="<%=strSitepath %>images/mo_arrow_left.png" alt="img" /></a></li>
                            </ol>
                            <div class="slidedivproof_pm">
                                <ol class="olhedaer">
                                    <li id="li_proofallitems" class="lisubItems" runat="server" style="cursor: pointer;"></li>
                                    <%--<li id="li_proofselecteditems" class="lisubItems" runat="server" style="cursor: pointer;">
                                        <%=objLangClass.GetLanguageConversion("Selected_Items")%></li>
                                    <li id="li_proofoutwork_supplier" class="lisubItems" visible="false" runat="server" style="cursor: pointer;">
                                        <%=objLangClass.GetLanguageConversion("Outwork_Supplier")%></li>--%>
                                </ol>
                            </div>
                        </div>
                    </li>
                   

                </ol>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_PrintEmail" runat="server" Value="" />
</asp:Panel>
<style type="text/css">
    .RadPanelBar, .RadPanelBar .rpSlide, .RadPanelBar .rpGroup, .RadPanelBar .rpItem, .RadPanelBar .rpTemplate {
        overflow: visible !important;
    }

    div.RadPanelBar .rpLevel1 .rpItem {
        padding: 0;
    }

    * html .RadPanelBar .RadMenu ul.rmRootGroup {
        zoom: 1;
    }

    div.RadMenu .rmRootGroup {
        border: 0;
    }

    div.RadMenu .rmLink {
        float: none;
    }

    .leftPanelBarContainer {
        float: left;
        width: 250px;
        height: 250px;
        overflow: auto;
        position: relative; /* Required to workaround IE rendering bug*/
    }
</style>
<asp:HiddenField ID="hdnPCPath" runat="server" Value="" />
<asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
<asp:HiddenField ID="editViewID" runat="server" Value="0" />
<asp:HiddenField ID="CompanyID_change" runat="server" />
<asp:HiddenField ID="hidchkDeletepo" runat="server" Value="false" />
<asp:HiddenField ID="hidchkDeleteDel" runat="server" Value="false" />
<asp:HiddenField ID="hdnReduceStockTypeForCancelledNew" Value="false" runat="server" />
<asp:HiddenField ID="hdnStockCancelChk" runat="server" Value="false" />
<asp:LinkButton ID="lnk_RevertToJob" runat="server" OnClick="btnAddTraining_Click"
    Style="display: none" />
<asp:HiddenField ID="hdnOrderID" Value="0" runat="server" />
<asp:HiddenField ID="hdnEstimateID" Value="0" runat="server" />
<asp:HiddenField ID="hdnJObID" Value="0" runat="server" />
<asp:HiddenField ID="hdnEmailselectOrnot" runat="server" Value="" />
<asp:HiddenField ID="hdnIsdirectJob" runat="server" Value="" />
<asp:HiddenField ID="hdbstatustitlesamecustomer" runat="server" Value="" />
<%--<div id="divBackGroundNew" style="display: none;">
</div>--%>
<script>
    var strSitepath = '<%=strSitepath  %>';
    var LockStatusId = '<%=LockStatusId  %>';
    var UnLockStatusId = '<%=UnLockStatusId  %>';
    var CompanyID_change = document.getElementById("<%=CompanyID_change.ClientID %>");
    var hdnReduceStockTypeForCancelledNew = document.getElementById("<%= hdnReduceStockTypeForCancelledNew.ClientID%>");
    var hidchkDeletepo = document.getElementById("<%= hidchkDeletepo.ClientID%>");
    var hidchkDeleteDel = document.getElementById("<%= hidchkDeleteDel.ClientID%>");
    var ManageStockPermission = '<%=ManageStockPermission  %>';
    var StockCancellationType = '<%=StockCancellationType  %>';
    var hdnEstimateID = document.getElementById("<%=hdnEstimateID.ClientID%>");
    var hdnJObID = document.getElementById("<%=hdnJObID.ClientID%>");
    var hdnEmailselectOrnot = document.getElementById("<%=hdnEmailselectOrnot.ClientID%>");
    var hdbstatustitlesamecustomer = document.getElementById("<%=hdbstatustitlesamecustomer.ClientID%>");
    var ApprovedOrderCount = '<%=ApprovedOrderCount%>';
    var IsJobLocked = '<%=IsJobLocked%>';
    var CanIgnoreLock = '<%=CanIgnoreLock%>';
    debugger;

    function ReorderItems(EstimateID, CompanyID, JobID, InvoiceID, page) {
        var Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=reorderitems&estimateid=" + EstimateID + "&companyid=" + CompanyID + "&jobid=" + JobID + "&invoiceid=" + InvoiceID + "&page=" + page + "&pg=" + page + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        Rad_Attachment.setSize(1035, 555);
        Rad_Attachment.center();
    }
    if (IsJobLocked.toLowerCase() === "true" && CanIgnoreLock != "true") {
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_rerun").css('display', 'none');
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_additems").css('display', 'none');
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_revert").css('display', 'none');
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_lblLockUnlock").text("Unlock Job");
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblLocked").text("[LOCKED]");

    }

    function editview() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_job() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_invoice() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }



    function editview_order() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_purchase() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_delivery() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_inventory() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_store() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View1');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_item() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View2');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_campaign() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_sectionView_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function Copy_campaign() {
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = campaignid;
    }

    function CheckchkOne(type) {
        var PageType = '<%=PageType %>';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        var Ides = "";

        hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                }
            }
        }
        hdnIDs.value = Ides;

        if (Number(Counter) == 0) {
            if (type == "delete") {
                alert("Please check at least one row to Delete");
            }
            else if (type == "archive") {
                alert("Please check at least one row to Archive");
            }
            else if (type == "unarchive") {
                alert("Please check at least one row to Un-Archive");
            }
            return false;
        }
        else {
            var check = "";
            if (type == "delete") {
                check = window.confirm('Are you sure you want to delete this record(s)?');
            }
            else if (type == "archive") {
                check = window.confirm('Are you sure you want to archive this record(s)?');
            }
            else if (type == "unarchive") {
                check = window.confirm('Are you sure you want to un-archive this record(s)?');
            }
            if (check) {
                if (type == "delete") {
                    if (PageType == "purchase") {
                        DeletePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        DeleteDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        DeleteOrder(Ides);
                    }
                    else {
                        DeleteInv();
                    }
                }
                else if (type == "archive") {
                    if (PageType == 'estimate') {
                        ArchiveEstimate();
                    }
                    else if (PageType == 'job') {
                        ArchiveJob();
                    }
                    else if (PageType == 'invoice') {
                        ArchiveInvoice();
                    }
                    else if (PageType == "purchase") {
                        ArchivePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        ArchiveDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        ArchiveOrder(Ides);
                    }
                    else {
                        ArchiveInv();
                    }
                }
                else if (type == "unarchive") {
                    UnArchiveInv();
                }
                return false;
            }
            else {
                return check;
            }
            //  return true;
        }
    }

    function DelArc_Estimate(type) {
        var PageType = '<%=PageType %>';
        var check = "";
        if (type == "delete") {
            check = window.confirm('Are you sure you want to delete this record?');
        }
        else {
            check = window.confirm('Are you sure you want to archive this record?');
        }
        if (check) {
            if (PageType == 'estimate' && type == "archive") {
                Archive_Estimate();
            }
            else if (PageType == 'estimate' && type == "delete") {
                Delete_Estimate();
            }
            //return false;
        }
        else {
            return check;
        }
    }
    function CheckchkOnlyOne() {
        var PageType = '<%=PageType %>';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
        var Ides = "";
        var EstIDs = "";
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                    if (PageType == 'job' || PageType == 'invoice') {
                        var EstimateID = document.getElementById("hid_EstimateID_" + e.value + "").value;
                        EstIDs = EstIDs + EstimateID + ",";
                    }
                }
            }
        }
        hdnIDs.value = Ides;
        if (Number(Counter) == 0) {
            if (PageType == 'estimate') {
                alert("Please select at least one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == 'job') {
                alert("Please select at least one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Purchase_To_Copy_To_New_Purchase")%>');
                return false;
            }
        }
        else if (Number(Counter) == 1) {
            if (PageType == 'estimate') {
                CopyEstimate();
                return false;
            }
            else if (PageType == 'job') {
                CopyJob(Ides, EstIDs);
                return false;
            }
            else if (PageType == 'invoice') {
                CopyInvoice(Ides, EstIDs);
                return false;
            }
            else if (PageType == "purchase") {
                CopyPurchase(Ides);
                return false;
            }
        }
        else if (Number(Counter) > 1) {
            if (PageType == 'estimate') {
                alert("Please select only one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == "job") {
                alert("Please select only one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                alert("Please select only one Purchase to Copy To New Purchase");
                return false;
            }
        }
    }
</script>
<script type="text/javascript">
    function hideDivNew1() {
        document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');

    }

    function Save1(val) {
        if (val == 'Y') {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        }
        else {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        }
    }

    function RevertJobNew() {
        var chkInvadjusted = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkInvadjusted");
        if (chkInvadjusted.checked) {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
        }
        else {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        }

        var chkDeletepo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeletepo");
        var chkDeleteDel = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeleteDel");
        if (chkDeletepo.checked) {
            hidchkDeletepo.value = "true";
        }
        if (chkDeleteDel.checked) {
            hidchkDeleteDel.value = "true";
        }
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        return false;
    }
</script>
<script>
    var menuids = new Array("verticalmenu", "jobverticalmenu") //Enter id(s) of UL menus, separated by commas                
    var submenuoffset = -2 //Offset of submenus from main menu. Default is -2 pixels.

    function createcssmenu() {

        for (var i = 0; i < menuids.length; i++) {
            var ultags = '';
            try {
                ultags = document.getElementById(menuids[i]).getElementsByTagName("ul")
            }
            catch (err) {
            }

            for (var t = 0; t < ultags.length; t++) {
                var spanref = document.createElement("span")

                spanref.className = "arrowdiv";
                spanref.innerHTML = "&nbsp;&nbsp;";

                ultags[t].parentNode.onmouseover = function () {
                    this.getElementsByTagName("ul")[0].style.left = this.parentNode.offsetWidth + submenuoffset + "px";
                    this.getElementsByTagName("ul")[0].style.display = "block";
                }
                ultags[t].parentNode.onmouseout = function () {
                    this.getElementsByTagName("ul")[0].style.display = "none"
                }
            }
        }
    }


    if (window.addEventListener)
        window.addEventListener("load", createcssmenu, false)
    else if (window.attachEvent)
        window.attachEvent("onload", createcssmenu)
</script>
<script type="text/javascript" language="javascript">
    function set_height(divid, divheight) {

        document.getElementById("div6").style.height = "140px";
    }
    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }

    function estimate(val) {


        if (val == 'none') {
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'none';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'block';
            document.getElementById("divrecentitem_1").style.display = 'none';
        }
        else {
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'block';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'none';
            document.getElementById("divrecentitem_1").style.display = 'block';
        }
    }
</script>
<script>
    function CallConfirm() {
        var ret = window.confirm("Are you sure you want to create delivery note against this job?");
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }

</script>
<%--Sachin --%>
<script type="text/javascript" language="javascript">
    function Open_ProductCatalogue(EstItemID, EstId, i) {
        var hdnEstType = document.getElementById("hdnEstType_" + i).value;
        var strTypes = hdnEstType.split('~');
        var strPath = document.getElementById("ctl00_tint_hdnPCPath").value;
        window.location = strPath + "?EstID=" + EstId + "&EstItemID=" + EstItemID + "&ToConvert=Yes&EstType=" + strTypes[0] + "&pgFrom=" + strTypes[1] + "";
    }
    function OpenCreateInvoice(EstID, ItemID, Type, JobID) {
        var hdnOrderID = document.getElementById("<%=hdnOrderID.ClientID%>");
        var url = window.location.href;
        var module;

        if (url.toLowerCase().indexOf("job_order_summary") != -1) {
            module = "ProgressToInvoiceFromOrder";
        }
        else if (url.toLowerCase().indexOf("job_summary_reeng") != -1) {
            module = "ProgressToInvoiceFromJob";
        }

        var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + EstID + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID.value + "&JID=" + JobID + "&ItemID=" + ItemID + "&Type=" + Type);

        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(510, 520);
        RadWindow_Paid.center();

        return false;
    }

    function OpenCreateInvoiceForRecordView(EstID, IsJobFromWebstore, JobID) {
        var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + EstID + "&JID=" + JobID + "&IsPaid=1&Module=JobRecordView&&IsJobFromWebstore=" + IsJobFromWebstore + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(680, 500);
        RadWindow_Paid.center();
        return false;
    }
</script>
<script>
    function OnMenuClick(sender, args) {
        var cntrlID = sender.get_id().replace('SplitButton', 'RadPanelBar_LeftPanel');
        if (args.IsSplitButtonClick() || !sender.get_commandName()) {
            var currentLocation = $telerik.getLocation(sender.get_element());
            var contextMenu = $find(cntrlID);
            contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
        }
    }
</script>
<script>
    function OpenEstimateOptions() {
        var currentURL = window.location.href;
        if (currentURL.includes("Proofs/Proof_summary.aspx")) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_ucMore_DivMoreAction").style.display = "block";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_DivMoreAction").style.display = "block";
        }
    }
    function ClosedMoreActions() {
        var currentURL = window.location.href;
        if (currentURL.includes("Proofs/Proof_summary.aspx")) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_ucMore_DivMoreAction").style.display = "none";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_DivMoreAction").style.display = "none";
        }
    }
    function OpenProofOptions() {
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_ucMore_DivMoreProofAction").style.display = "block";
    }
    function ClosedMoreProofActions() {
        document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_ucMore_DivMoreProofAction").style.display = "none";
    }
    $(document).ready(function () {
        $('.slidediv_pm').hide();
        $('.slidedivproof_pm').hide();
        $('.slidediv_items').hide();
        $('.slidediv_Copy').hide();
        $('.slidediv_digital_items').hide();
        $('.slidediv_offset_items').hide();
        $('.slidediv_large_items').hide();
    });


    $(function () {
        $('.showhide_pm').click(function () {
            $(".slidediv_pm").slideToggle();
            $('.slidediv_items').slideUp();
            $('.slidediv_Copy').slideUp();
            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_pm"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }
            $("#img_arrow_pm").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_additems").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_CopyItems").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });
        //  ----------------- Start Proof --------------------
        $('.showhideproof_pm').click(function () {
            $(".slidedivproof_pm").slideToggle();
            $('.slidedivproof_items').slideUp();
            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_pm_proof"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }
            $("#img_arrow_pm_proof").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_additems_proof").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });

        $('.showhideproof_items').click(function () {
            $(".slidedivproof_pm").slideUp();
            $('.slidedivproof_items').slideToggle();
            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_additems_proof"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }
            $("#img_arrow_additems_proof").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_pm_proof").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });


        // ------------------- End Proof ----------------
        $('.showhide_items').click(function () {
            $(".slidediv_pm").slideUp();
            $('.slidediv_items').slideToggle();
            $('.slidediv_Copy').slideUp();
            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_additems"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }
            $("#img_arrow_additems").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_pm").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_CopyItems").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });

        $('.showhide_Copy').click(function () {
            $(".slidediv_pm").slideUp();
            $('.slidediv_items').slideUp();
            $('.slidediv_Copy').slideToggle();

            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_CopyItems"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }
            $("#img_arrow_CopyItems").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_additems").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_pm").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });

        $('.showhide_digital_items').click(function () {
            $('.slidediv_digital_items').slideToggle();
            $('.slidediv_offset_items').slideUp();
            $('.slidediv_large_items').slideUp();

            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_digital"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }

            $("#img_arrow_digital").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_offset").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_large").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });

        $('.showhide_offset_items').click(function () {
            $('.slidediv_offset_items').slideToggle();
            $('.slidediv_digital_items').slideUp();
            $('.slidediv_large_items').slideUp();

            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_offset"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }

            $("#img_arrow_offset").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_digital").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_large").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });

        });

        $('.showhide_large_items').click(function () {
            $('.slidediv_large_items').slideToggle();
            $('.slidediv_digital_items').slideUp();
            $('.slidediv_offset_items').slideUp();

            var rotateAngle = 0;
            rotateAngle = getRotationDegrees($("#img_arrow_large"));
            if (rotateAngle == 0) {
                rotateAngle = -90;
            }
            else {
                rotateAngle = 0;
            }

            $("#img_arrow_large").css({
                '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
                '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
                '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
                'transform': 'rotate(' + rotateAngle + 'deg)',
                '-webkit-transition': '-webkit-transform 1s',
                '-moz-transition': '-moz-transform 1s',
                ' -ms-transition': '-ms-transform 1s',
                'transition': 'transform 1s'
            });
            $("#img_arrow_digital").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
            $("#img_arrow_offset").css({
                '-webkit-transform': 'rotate(' + 0 + 'deg)',
                '-moz-transform': 'rotate(' + 0 + 'deg)',
                '-ms-transform': 'rotate(' + 0 + 'deg)',
                'transform': 'rotate(' + 0 + 'deg)'
            });
        });

    });

    function getRotationDegrees(obj) {
        var matrix = obj.css("-webkit-transform") ||
            obj.css("-moz-transform") ||
            obj.css("-ms-transform") ||
            obj.css("-o-transform") ||
            obj.css("transform");
        if (matrix == "rotate(0deg)") {
            var angle = 0;
            return (angle < 0) ? angle += 360 : angle;
        }
        if (matrix !== 'none') {
            var values = matrix.split('(')[1].split(')')[0].split(',');
            var a = values[0];
            var b = values[1];
            var angle = Math.round(Math.atan2(b, a) * (180 / Math.PI));
        } else { var angle = 0; }
        return (angle < 0) ? angle += 360 : angle;
    }

</script>
<script type="text/javascript" language="javascript">
    function ReRunEstimateInfo() {

        var EstimateID = '<%=EstID  %>';
        var JobID = '<%=jobID  %>';
        var InvoiceID = '<%=InvoiceID  %>';
        var IsFromWebStore = '<%=IsFromWebStore%>';
        var hdnIsdirectJob = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_hdnIsdirectJob").value;
        if (Module.toLowerCase() == "job") {
            if (hdnIsdirectJob == '1') {
                var res = window.confirm('<%=objLangClass.GetLanguageConversion("IsdirectJob_Customer_Info_Edit_Alert")%>');
            }
            else {
                var res = window.confirm('<%=objLangClass.GetLanguageConversion("Job_Customer_Info_Edit_Alert")%>');
            }
            if (res == true) {
                if (IsFromWebStore.toLowerCase() == "yes") {
                    window.location = strSitepath + "Orders/order_summary_rerun.aspx?type=job&orderid=" + EstimateID + "&estid=" + EstimateID + "&jID=" + JobID;
                }
                else {
                    window.location = strSitepath + "jobs/job_add.aspx?type=edit&estid=" + EstimateID + "&ReRun=Y&jID=" + JobID + "&IsFromWebStore=" + IsFromWebStore + "";
                }
            }
            else {
                return false;
            }
        }
        else if (Module.toLowerCase() == "invoice") {
            window.location = strSitepath + "invoice/invoices_add.aspx?type=edit&estid=" + EstimateID + "&ReRun=Y&InvID=" + InvoiceID + "&IsFromWebStore=" + IsFromWebStore + "";
        }
        else if (Module.toLowerCase() == "order") {
            window.location = strSitepath + "Orders/order_summary_rerun.aspx?type=webstoreorder&orderid=" + EstimateID + "&estid=" + EstimateID + "";
        }
        else {
            window.location = strSitepath + "estimates/estimates_add.aspx?type=edit&estid=" + EstimateID + "&ReRun=Y";
        }
    }
    function CheckApprovedOrderAllItems() {
        if (ApprovedOrderCount == "0") {        //To check approved order count
            alert('Print/Email option cannot be accessed as all the order items in this order is awaiting approval');
            return false;
        }
        else {
            window.location = strSitepath + "orders/templates_view1.aspx?sectionid=" + '<%=sectionid%>' + "&sectionname=webstoreorder&type=" + '<%=companytype%>' + "&page=webstoreorder&ordid=" + '<%=EstID%>' + "&EstID=" + '<%=EstID%>' + "&GenPdf=all";
        }
    }
    function CheckApprovedOrder() {
        if (ApprovedOrderCount == "0") {        //To check approved order count
            alert('Print/Email option cannot be accessed as all the order items in this order is awaiting approval');
            return false;
        }
        else {
            window.location = strSitepath + "orders/templates_view1.aspx?sectionid=" + '<%=sectionid%>' + "&sectionname=webstoreorder&type=" + '<%=companytype%>' + "&page=webstoreorder&ordid=" + '<%=EstID%>' + "&EstID=" + '<%=EstID%>' + "&GenPdf=all";
        }
    }

    function CheckApprovedOrder() {
        if (ApprovedOrderCount == "0") {        //To check approved order count
            alert('Print/Email option cannot be accessed as all the order items in this order is awaiting approval');
            return false;
        }
        else {
            window.location = strSitepath + "orders/templates_view1.aspx?sectionid=" + '<%=sectionid%>' + "&sectionname=webstoreorder&type=" + '<%=companytype%>' + "&page=webstoreorder&ordid=" + '<%=EstID%>' + "&EstID=" + '<%=EstID%>' + "&GenPdf=all";
        }
    }
</script>
