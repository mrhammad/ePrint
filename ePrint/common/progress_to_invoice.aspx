<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="progress_to_invoice.aspx.cs" Inherits="ePrint.common.progress_to_invoice" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        </asp:ScriptManager>
        <script src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
        <div id="divContacts" style="margin-left: 25px; margin-top: 25px;">
            <div class="bglabel" style="width: 132px">
                <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Invoice_Contact")%></asp:Label>
            </div>
            <div class="box" style='padding-top: 3px; padding-bottom: 2px;'>
                <asp:DropDownList ID="ddlContactList" Width="200px" runat="server" CssClass="normalText">
                </asp:DropDownList>
                <%--<asp:PlaceHolder ID="plhContactList" runat="server"></asp:PlaceHolder>--%>
                <br />
            </div>
            <div style="clear: both;">
            </div>
            <div class="bglabel" style="width: 132px">
                <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Sales_Person")%></asp:Label>
            </div>
            <div class="box" style='padding-top: 3px; padding-bottom: 2px;'>
                <asp:DropDownList ID="ddlSalesPerson" Width="200px" runat="server" CssClass="normalText">
                </asp:DropDownList>
                <br />
            </div>
            <div style="clear: both;">
            </div>
            <div class="bglabel" style="width: 132px">
                <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Invoice_Title")%></asp:Label>
                <span style="color: Red">*</span>
            </div>
            <div class="box" style='padding-top: 3px; padding-bottom: 2px;'>
                <asp:TextBox ID="txtInvoiceTitle" runat="server" CssClass="textboxnew_estNew" Width="195px"
                    onblur="javascript:TitleCheck();"></asp:TextBox>
                <br />
            </div>
            <div style="clear: both;">
            </div>
            <div style="float: left; margin-left: 146px;">
                <span id="spn_txtEstimateTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                    <%=objLangClass.GetLanguageConversion("Please_Enter_Invoice_Title")%></span>
            </div>
            <div style="clear: both;">
            </div>
            <div style="float: left; margin-left: 138px; margin-top: 5px;">
                <div class="box" style="margin-bottom: 6px;">
                    <asp:RadioButton ID="rdnProformaInvYes" runat="server" Checked="false" GroupName="ProformaInvoice"
                        Width="300px" /><br />
                    <asp:RadioButton ID="rdnProformaInvNo" runat="server" Checked="true" GroupName="ProformaInvoice"
                        Width="300px" /><br />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="float: left; margin-left: 144px; margin-top: 10px;">
                <div style="float: left;">
                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" CssClass="button" Style="margin-right: 5px;"
                        OnClientClick="javascript:ItemNext('back');return false;" />
                </div>
                <div style="float: left;">
                    <asp:Button ID="btnContactNext" runat="server" CssClass="button" Text="Raise and continue"
                        OnClientClick="javascript:FinalNext('continue');return false;" Style="margin-right: 5px;" /><%--OnClientClick="javascript:ContactNext();return false;"--%>
                    <div id="divContinue1" style="display: none; width: 108px; height: 14px; margin-right: 5px;"
                        class="button">
                        <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left;">
                    <asp:Button ID="btnContactNext2" runat="server" CssClass="button" Text="Raise and make payment"
                        OnClientClick="javascript:FinalNext('payment');return false;" />
                    <div id="divContinue2" style="display: none; width: 146px; height: 14px;" class="button">
                        <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
        <div id="divItems" style="word-break: break-word;">
            <div style="padding-top: 20px;">
                <telerik:RadGrid ID="ItemsGridView" runat="server" GridLines="None" AutoGenerateColumns="false"
                    BorderWidth="0" AllowPaging="true" PageSize="5000" Width="68%" PagerStyle-AlwaysVisible="false"
                    AllowFilteringByColumn="false" Style="padding-left: 20px;" onfocus="this.blur();">
                    <MasterTableView CommandItemDisplay="None">
                        <Columns>
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                AllowFiltering="false" HeaderStyle-Width="2%" ItemStyle-Width="2%" HeaderStyle-Wrap="false">
                                <HeaderTemplate>
                                    <div style="float: left; display: none;">
                                        <input id="Checkbox1" type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                    </div>
                                    <div id="div_chk" style="width: inherit; height: inherit;">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                            <tr>
                                                <td>
                                                    <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                        value='<%# Bind("AllIDs") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <%--<telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job Number" HeaderStyle-Font-Bold="true"
                            AllowFiltering="false" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="JobItemNumber" HeaderText="Job Item Number" HeaderStyle-Font-Bold="true"
                                AllowFiltering="false" AutoPostBackOnFilter="false" ItemStyle-Width="30%" CurrentFilterFunction="Contains">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ItemTitle" HeaderText="Item Title" HeaderStyle-Font-Bold="true"
                                AllowFiltering="false" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="button" Style="margin-left: 30px; margin-top: 15px;"
                OnClientClick="javascript:ItemNext('front');return false;" /><%--OnClick="btnNext_OnClick" --%>
            <asp:HiddenField ID="hdnSelectedIDs" runat="server" />
            <asp:HiddenField ID="hdnContactID" runat="server" />
            <asp:HiddenField ID="hdnNextType" runat="server" />
                 <asp:LinkButton ID="lnkOff" runat="server" OnClick="btnNext_OnClick"></asp:LinkButton>
        <asp:LinkButton ID="lnkOn" runat="server" OnClick="btnContactNext_Click"></asp:LinkButton>
        </div>
        <script language="javascript" type="text/javascript">
            var hdnSelectedIDs = document.getElementById('<%=hdnSelectedIDs.ClientID %>');
            var hdnContactID = document.getElementById('<%=hdnContactID.ClientID %>');
            var txtInvoiceTitle = document.getElementById('<%=txtInvoiceTitle.ClientID %>');
            var lnkOff = document.getElementById('<%=lnkOff.ClientID %>');
            var lnkOn = document.getElementById('<%=lnkOn.ClientID %>');
            var hdnNextType = document.getElementById('<%=hdnNextType.ClientID %>');

            var btnContactNext = document.getElementById('<%=btnContactNext.ClientID %>');
            var btnContactNext2 = document.getElementById('<%=btnContactNext2.ClientID %>');
            function ItemNext(chk) {
                if (chk == "back") {
                    document.getElementById("divContacts").style.display = "none";
                    document.getElementById("divItems").style.display = "block";
                }
                else {
                    var frm = document.forms[0];
                    hdnSelectedIDs.value = '';
                    var SelectedCnt = 0;

                    for (i = 0; i < frm.length; i++) {
                        e = frm.elements[i];

                        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                            if (e.checked == true) {
                                SelectedCnt++;
                                hdnSelectedIDs.value += e.value + ",";
                            }
                        }
                    }

                    if (SelectedCnt == 0) {
                        alert("Please select at least one item to progress to invoice.");
                        return false;
                    }
                    document.getElementById("divContacts").style.display = "block";
                    document.getElementById("divItems").style.display = "none";
                }
            }

            function TitleCheck() {
                if (txtInvoiceTitle.value.trim() == "") {
                    document.getElementById("spn_txtEstimateTitle").style.display = "block";
                }
                else {
                    document.getElementById("spn_txtEstimateTitle").style.display = "none";
                }
            }

            function ContactNext() {

                if (txtInvoiceTitle.value.trim() == "") {
                    document.getElementById("spn_txtEstimateTitle").style.display = "block";
                    txtInvoiceTitle.focus();
                }
                else {
                    document.getElementById("divContacts").style.display = "none";
                    document.getElementById("divItems").style.display = "block";

                    var masterTable = $find("<%=ItemsGridView.ClientID%>").get_masterTableView();
                    var check_All = masterTable.HeaderRow.cells[0].children[1].children[0].children[0].children[0].children[0].children[0];

                    check_All.checked = true;
                    CheckAll(check_All);
                }
            }

            function ItemListDisplay(result) {
                //            if (result == "yes") {
                //                document.getElementById("divContacts").style.display = "block";
                //                document.getElementById("divItems").style.display = "none";
                //            }
                //            else {
                //                document.getElementById("divContacts").style.display = "none";
                //                document.getElementById("divItems").style.display = "block";
                //                document.getElementById("ItemsGridView_ctl00_ctl02_ctl01_checkAll").checked = true;
                //                CheckAll(document.getElementById("ItemsGridView_ctl00_ctl02_ctl01_checkAll"));
                //            }
                if (document.getElementById("ItemsGridView_ctl00_ctl02_ctl01_checkAll") != null) {
                    document.getElementById("ItemsGridView_ctl00_ctl02_ctl01_checkAll").checked = true;
                    CheckAll(document.getElementById("ItemsGridView_ctl00_ctl02_ctl01_checkAll"));
                }
             

                if (result == "yes") {
                    document.getElementById("divContacts").style.display = "none";
                    document.getElementById("divItems").style.display = "block";
                }
                else {
                    document.getElementById("divContacts").style.display = "block";
                    document.getElementById("divItems").style.display = "none";
                }
            }

            function CheckAll(checkAllBox) {
                debugger;
                var frm = document.forms[0];
                var ChkState = checkAllBox.checked;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                    if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                }
            }

            function CheckChanged() {
                debugger;
                var frm = document.forms[0];
                var boolAllChecked;
                boolAllChecked = true;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                        if (e.checked == false) {
                            boolAllChecked = false;
                            break;
                        }
                }
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                        if (boolAllChecked == false)
                            e.checked = false;
                        else
                            e.checked = true;
                        break;
                    }
                }
            }

            function SelectedItems() {

                //rdoContact_

                var frm = document.forms[0];
                hdnSelectedIDs.value = '';
                var SelectedCnt = 0;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];

                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                        if (e.checked == true) {
                            SelectedCnt++;
                            hdnSelectedIDs.value += e.value + ",";
                        }
                    }
                    if (e.type == 'radio' && e.id.indexOf('rdoContact_') != -1) {
                        if (e.checked == true) {
                            var ID = e.id.replace('rdoContact_', '');;
                            hdnContactID.value = ID;
                        }
                    }
                }

                if (SelectedCnt == 0) {
                    alert("Please select at least one item to progress to invoice.");
                    return false;
                }

                return true;
            }

            function SelectedItems_ItemsSelected() {
                var frm = document.forms[0];

                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'radio' && e.id.indexOf('rdoContact_') != -1) {
                        if (e.checked == true) {
                            var ID = e.id.replace('rdoContact_', '');;
                            hdnContactID.value = ID;
                        }
                    }
                }
            }



            var IsItemSelected = '<%=IsItemSelected %>';

            function FinalNext(type) {

                if (txtInvoiceTitle.value.trim() == "") {
                    document.getElementById("spn_txtEstimateTitle").style.display = "block";
                    txtInvoiceTitle.focus();
                }
                else {
                    hdnNextType.value = type;

                    if (type == "continue") {
                        btnContactNext.style.display = "none";
                        document.getElementById("divContinue1").style.display = "block";
                    }
                    else {
                        btnContactNext2.style.display = "none";
                        document.getElementById("divContinue2").style.display = "block";
                    }

                    if (IsItemSelected.toLowerCase() == "true") {
                        __doPostBack('lnkOn', '');
                    }
                    else {
                        var frm = document.forms[0];
                        hdnSelectedIDs.value = '';
                        var SelectedCnt = 0;
                        for (i = 0; i < frm.length; i++) {
                            e = frm.elements[i];

                            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                                if (e.checked == true) {
                                    SelectedCnt++;
                                    hdnSelectedIDs.value += e.value + ",";
                                }
                            }
                        }
                        __doPostBack('lnkOff', '');
                    }
                }
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow)
                    oWindow = window.radWindow;
                else if (window.frameElement.radWindow)
                    oWindow = window.frameElement.radWindow;
                return oWindow;
            }

            function TakeOut(InvID, EstimateID) {

                var url = null;
                var IsJobFromEstore = '<%=IsJobFromEstore %>';
            var IsBrainTreePayment = '<%=IsBrainTreePayment%>';
            var oWindow = GetRadWindow();
            oWindow.close();

            if (IsJobFromEstore.toLowerCase() == 'yes') {
                if (IsBrainTreePayment.toLowerCase().trim() == 'true') {
                    url = "<%=strSitepath%>invoice/invoice_order_summary.aspx?estid=" + EstimateID + "&InvID=" + InvID + "";
                    oWindow.BrowserWindow.location.href = url;
                }
                else {
                    url = "<%=strSitepath%>invoice/invoice_order_summary.aspx?estid=0&InvID=" + InvID + "";
                    oWindow.BrowserWindow.location.href = url;
                }
            }
            else {
                url = "<%=strSitepath%>invoice/invoice_summary_reeng.aspx?estid=0&InvID=" + InvID + "";
                oWindow.BrowserWindow.location.href = url;
            }
            //            var url = "<%=strSitepath%>invoice/invoices_add.aspx?type=edit&estid=0&ReRun=Y&InvID=" + InvID + "";
                //            oWindow.BrowserWindow.location.href = url;
            }

        </script>
    </form>
</body>
<style>
    #ItemsGridView thead {
        display: none;
    }
    /*#ItemsGridView tbody .RadGrid_Default */
    .RadGrid_Default .rgAltRow {
        background: #fff;
    }

        .RadGrid_Default .rgAltRow td {
            border-color: #fff;
        }

    .RadGrid_Default .rgRow td {
    }
</style>
</html>
