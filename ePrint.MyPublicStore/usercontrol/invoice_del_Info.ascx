<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="invoice_del_Info.ascx.cs" Inherits="ePrint.MyPublicStore.usercontrol.invoice_del_Info" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="/App_Themes/Theme1/Menu.css" rel="stylesheet" type="text/css" />

<script src="/js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="/js/Slide/jsPopup.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rdgrd_ship_choose">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lnkOrderDate_ship" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rdgrd_bill_choose">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lnkOrderDate_bill" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave_Bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="imgSearch_Bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
                <telerik:AjaxUpdatedControl ControlID="imgSearch_Bill" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="imgSearch_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
                <telerik:AjaxUpdatedControl ControlID="imgSearch_Ship" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lnkEdit_Bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkEdit_Bill" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="sdf" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="chkCopytoInvoice" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lnkEdit_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkEdit_Ship" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_Update_bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btn_Update_bill" />
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_Update_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btn_Update_Ship" />
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkDelAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnTotalAddressCount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<style type="text/css">
    .RadGrid_Default .rgRow a, .RadGrid_Default .rgAltRow a, .RadGrid_Default .rgEditRow a, .RadGrid_Default tr.rgEditRow a, .RadGrid_Default tr.rgHoveredRow a, .RadGrid_Default tr.rgActiveRow a, .RadGrid_Default .rgFooter a, .RadGrid_Default .rgEditForm a
    {
        color: #777777;
    }
    .RadGrid_Default .rgSelectedRow a
    {
        color: white;
    }
</style>
<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1">
</telerik:RadAjaxLoadingPanel>
<div id="checkout_addressinfo_MainDiv">
    <table id="checkout_addressinfo">
        <tr id="tr_AddressInfoHeader" runat="server">
            <td colspan="2" class="CheckOutAddressHeader">
                <asp:Label ID="lblAddressInfoHeader" runat="server">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td id="td_Deladdr" runat="server" class="checkout_address_td">
                <div>
                    <div>
                        <h3>
                            <asp:Label ID="lblDelivery_Address" runat="server"></asp:Label></h3>
                    </div>
                    <div class="paddingTop5">
                        <asp:Label ID="lblShippingAddress" runat="server"></asp:Label>
                    </div>
                </div>
            </td>
            <td id="td_invaddr" runat="server" class="checkout_address_td">
                <div class="InvoiceDiv">
                    <div>
                        <h3>
                            <asp:Label ID="lblInvoice_Address" runat="server"></asp:Label></h3>
                    </div>
                    <div class="paddingTop5">
                        <asp:Label ID="lblBillingAddress" runat="server"></asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr id="trChangeAddress" runat="server">
            <td id="td_Del_Choose" runat="server">
                <div>
                    <table>
                        <tr>
                            <td id="tdEditAddress1" runat="server">
                                <asp:LinkButton ID="lnkEdit_Ship" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:ShowDialog_Both('Delivery','edit');"
                                    OnClick="lnkEdit_Ship_Click">
                                    <%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;<asp:Label ID="lblDeliveryLine"
                                        runat="server">|&nbsp;&nbsp;</asp:Label></asp:LinkButton>
                            </td>
                            <td id="tdChooseAddress1" runat="server">
                                <a href="javascript:void(0);" id="lnk_ChooseAddress_Ship" class="lnkAddressButton">
                                    <%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;| &nbsp;</a>
                            </td>
                            <td id="tdAddAddress1" runat="server">
                                <a href="javascript:ShowDialog_Both('Delivery','new');" class="lnkAddressButton">
                                    <%=objLanguage.GetLanguageConversion("Add_New_Address") %>
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td id="td_Inv_Choose" runat="server">
                <div class="InvoiceDiv">
                    <table>
                        <tr>
                            <td id="tdEditAddress" runat="server">
                                <asp:LinkButton ID="lnkEdit_Bill" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:ShowDialog_Both('Invoice','edit');"
                                    OnClick="lnkEdit_Bill_Click">
                                    <%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;<asp:Label ID="Label1"
                                        runat="server">|&nbsp;&nbsp;</asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td id="tdChooseAddress" runat="server">
                                <a href="javascript:void(0);" id="lnk_ChooseAddress_Bill" class="lnkAddressButton">
                                    <%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;| &nbsp;</a>
                            </td>
                            <td id="tdAddAddress" runat="server">
                                <a href="javascript:ShowDialog_Both('Invoice','new');" class="lnkAddressButton">
                                    <%=objLanguage.GetLanguageConversion("Add_New_Address") %>
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div>
        <div id="output">
        </div>
        <div id="overlay" class="web_dialog_overlay_Address">
        </div>
        <div id="dialog" class="web_dialog_Address">
            <table align="center" class="popuptable_Address">
                <tr>
                    <td class="web_dialog_title_Address">
                        <div id="div_NewAddress">
                            <b>
                                <asp:Label ID="lblNew_Address" runat="server"></asp:Label></b>
                        </div>
                        <div id="div_EditAddress">
                            <b>
                                <asp:Label ID="lblEdit_Address" runat="server"></asp:Label></b>
                        </div>
                    </td>
                    <td class="align_right" align="right">
                        <a href="#" id="btnClose_bill" title="Close">
                            <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddress_LAbel" runat="server"></asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txtaddressLabelBilling" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="Example-Style" id="spnExample" style="margin-left: 7px;" runat="server">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddressBill1" runat="server"></asp:Label>
                        <asp:Label ID="lblBillAdd1_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_address_billing1" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Address1" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing1"
                            Enabled="false" Display="None" Text="This is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddressBill2" runat="server"></asp:Label>
                        <asp:Label ID="lblBillAdd2_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_address_billing2" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Address2" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing2"
                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddressBill3" runat="server"></asp:Label>
                        <asp:Label ID="lblBillAdd3_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_address_billing3" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Address3" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing3"
                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddressBill4" runat="server"></asp:Label>
                        <asp:Label ID="lblBillAdd4_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_address_billing4" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Address4" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing4"
                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblAddressBill5" runat="server"></asp:Label>
                        <asp:Label ID="lblBillAdd5_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_address_billing5" runat="server" CssClass="width-180px"></asp:TextBox>
                        <span class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Address5" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing5"
                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lbl_Country" runat="server"></asp:Label><span class="mandatoryField">*</span>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="width-dropdownlist">
                        </asp:DropDownList>
                        <span id="sdf" runat="server" class="mandatoryField validationmsg">&nbsp;&nbsp;<asp:RequiredFieldValidator
                            ID="Required_Country" runat="server" ValidationGroup="Checkout" InitialValue="0"
                            ControlToValidate="ddlCountry" Text="This is a required field."></asp:RequiredFieldValidator></span>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lbl_Telephne" runat="server"></asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_telephone_billing" runat="server" CssClass="width-180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:TextBox ID="txt_fax_billing" runat="server" CssClass="width-180px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="CopyAddress" runat="server">
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:CheckBox ID="chkCopytoInvoice" runat="server" />
                    </td>
                    <td style="padding-top:2px;">
                        <asp:Label ID="lblcopyaddress" runat="server" Text="Copy the above to Invoice Address"></asp:Label>
                    </td>
                </tr>
                <tr id="MakeDefaultAddress_Delivery" runat="server">
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:CheckBox ID="Chk_makedefaultAddres_Delivery" runat="server" />
                    </td>
                    <td style="padding-top:2px;">
                        <asp:Label ID="lblMakedeafultaddres_Delivery" runat="server" Text="Make this as default Delivey Address"></asp:Label>
                    </td>
                </tr>
                <tr id="CopyInvtoDelAddress" runat="server">
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:CheckBox ID="ChkcopytoDel" runat="server" />
                    </td>
                    <td style="padding-top:2px;">
                        <asp:Label ID="lblcopyInvaddress" runat="server" Text="Copy the above to Delivery Address"></asp:Label>
                    </td>
                </tr>
                <tr id="MakeDefaultAddress_Invoice" runat="server" >
                    <td class="leftCellNewAdd_table textalignRight">
                        <asp:CheckBox ID="Chk_makedefaultAddres_Invoice" runat="server" />
                    </td>
                    <td style="padding-top:2px;">
                        <asp:Label ID="lblMakedeafultaddres_Invoice" runat="server" Text="Make this as default Invoice Address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table">
                    </td>
                    <td class="rightCellNewAdd_table">
                        <div id="Savebtn_Invoice" class="displayBlock">
                            <asp:Button ID="btnSave_Bill" runat="server" Text="Save and Use this Address" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnSave_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Savebtn_Invoice','div_btnsaveprocess12');">
                            </asp:Button>
                        </div>
                        <div id="Savebtn_Delivery" class="displayBlock">
                            <asp:Button ID="btnSave_Ship" runat="server" Text="Save and Use this Address" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnSave_Ship_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Savebtn_Delivery','div_btnsaveprocess12');">
                            </asp:Button>
                        </div>
                        <div id="div_btnsaveprocess12" class="x-btnpro Grey main" align="center">
                            <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />
                        </div>
                        <div id="divSave_UC" class="x-btnpro Grey main" align="center">
                            <img src="/images/radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                        <div id="Updatebtn_Invoice" class="displayBlock">
                            <asp:Button ID="btn_Update_bill" runat="server" Text="Update" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnUpdate_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Invoice','div_btnsaveprocessUpdate');">
                            </asp:Button>
                        </div>
                        <div id="div_btnsaveprocessUpdate" class="x-btnpro Grey main" align="center">
                            <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />
                        </div>
                        <div id="Updatebtn_Delivery" class="displayBlock">
                            <asp:Button ID="btn_Update_Ship" runat="server" Text="Update" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnUpdate_Ship_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Delivery','div_btnsaveprocessUpdate');">
                            </asp:Button>
                        </div>
                        <div id="divUpdate_UC" class="x-btnpro Grey main" align="center">
                            <img src="/images/radimg1.gif" class="trans" alt="loading" border="0" /><%--loadingimg('divSave_UC', 'Savebtn_Invoice');--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div id="Output_bill_Choose">
        </div>
        <div id="Overlay_bill_Choose" class="web_dialog_overlay">
        </div>
        <div id="dialog_bill_Choose" class="web_dialog">
            <table class="popuptable">
                <tr>
                    <td>
                        <div class="web_dialog_title">
                            <asp:Label ID="lblAddress_Book" runat="server"></asp:Label></div>
                    </td>
                    <td class="align_right">
                        <a href="#" id="btnClose_bill_Choose" title="Close">
                            <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="paddingleft-12px paddingBottom10">
                        <div class="CkOut_Address_Search_TxtBxDiv">
                            <div class="floatLeft">
                                <telerik:RadTextBox ID="grd_Search_bill" onkeydown = "return (event.keyCode!=13);" runat="server" EmptyMessage="Search Address"
                                    Width="200px" EmptyMessageStyle-ForeColor="#B2B2B2" BorderColor="Transparent"
                                    Style="margin: 1px 0px 2px 0px; outline: 0;">
                                </telerik:RadTextBox>
                            </div>
                            <div>
                                <asp:ImageButton ID="imgSearch_Bill" runat="server" ImageUrl="~/images/StoreImages/Search1.png"
                                    OnClick="grd_Search_bill_OnTextChanged" CssClass="CkOut_Address_Search_Img" ToolTip="Search" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="CkOut_Address_ListAvlble_Div">
                        <span class="CkOut_Address_ListAvlble_lbl">
                            <asp:Label ID="lblListofAllAddress" runat="server"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="paddingleft-12px">
                        <telerik:RadGrid ID="rdGrd_bill_Choose" runat="server" CssClass="width-474px" AutoGenerateColumns="false"
                            AllowSorting="false" AllowFilteringByColumn="false" AllowPaging="true" OnNeedDataSource="rdgrd_ship_choose_OnNeedDataSource"
                            OnItemDataBound="rdGrd_bill_Choose_OnItemDataBound" PageSize="1000" BorderColor="Transparent"
                            AlternatingItemStyle-BackColor="Transparent">
                            <ClientSettings AllowRowsDragDrop="false" AllowColumnsReorder="false" ReorderColumnsOnClient="false">
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                <Scrolling AllowScroll="true" ScrollHeight="300px" UseStaticHeaders="true" />
                            </ClientSettings>
                            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="" Position="Bottom" ShowPagerText="false" />
                            <MasterTableView TableLayout="Fixed" ShowHeader="false">
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="AddressID" DataField="AddressID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="BillAddress" ItemStyle-HorizontalAlign="Left"
                                        AllowFiltering="false" ItemStyle-BorderColor="#DFDFDF">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkOrderDate_bill" Text='<%#Bind("Address")%>' runat="server"
                                                CssClass="gridlinkbutton" ToolTip='<%#Bind("Address")%>' OnCommand="lnkOrderDate_bill_Click"
                                                CausesValidation="false" CommandArgument='<%#Eval("AddressID")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <NoRecordsTemplate>
                                    <span>No Records</span>
                                </NoRecordsTemplate>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div id="Output_ship_Choose">
        </div>
        <div id="Overlay_ship_Choose" class="web_dialog_overlay">
        </div>
        <div id="dialog_ship_Choose" class="web_dialog">
            <table class="popuptable">
                <tr>
                    <td>
                        <div class="web_dialog_title">
                            Address Book</div>
                    </td>
                    <td class="align_right">
                        <a href="#" id="btnClose_ship_Choose" title="Close">
                            <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="paddingleft-12px paddingBottom10">
                        <div class="CkOut_Address_Search_TxtBxDiv">
                            <div class="floatLeft">
                                <telerik:RadTextBox ID="grd_Search_ship" onkeydown = "return (event.keyCode!=13);" runat="server" EmptyMessage="Search Address"
                                    Width="200px" EmptyMessageStyle-ForeColor="#B2B2B2" BorderColor="Transparent"
                                    Style="margin: 1px 0px 2px 0px; outline: 0;">
                                </telerik:RadTextBox>
                            </div>
                            <div>
                                <asp:ImageButton ID="imgSearch_Ship" runat="server" ImageUrl="~/images/StoreImages/Search1.png"
                                    OnClick="grd_Search_ship_OnTextChanged" CssClass="CkOut_Address_Search_Img" ToolTip="Search" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="CkOut_Address_ListAvlble_Div">
                        <span class="CkOut_Address_ListAvlble_lbl" id="spnList" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="paddingleft-12px">
                        <telerik:RadGrid ID="rdgrd_ship_choose" runat="server" CssClass="width-474px" AutoGenerateColumns="false"
                            AllowSorting="false" AllowFilteringByColumn="false" AllowPaging="true" OnNeedDataSource="rdgrd_ship_choose_OnNeedDataSource"
                            OnItemDataBound="rdgrd_ship_choose_OnItemDataBound" PageSize="1000" BorderColor="Transparent"
                            AlternatingItemStyle-BackColor="Transparent">
                            <ClientSettings AllowRowsDragDrop="false" AllowColumnsReorder="false" ReorderColumnsOnClient="false">
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                <Scrolling AllowScroll="true" ScrollHeight="300px" UseStaticHeaders="true" />
                            </ClientSettings>
                            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="" Position="Bottom" ShowPagerText="false" />
                            <MasterTableView TableLayout="Fixed" ShowHeader="false">
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="AddressID" DataField="AddressID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ShipAddress" HeaderText="Address" HeaderStyle-Font-Bold="true"
                                        ItemStyle-BorderColor="#DFDFDF">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkOrderDate_ship" Text='<%#Bind("Address")%>' runat="server"
                                                CssClass="gridlinkbutton" ToolTip='<%#Bind("Address")%>' OnCommand="lnkOrderDate_ship_Click"
                                                CausesValidation="false" CommandArgument='<%#Eval("AddressID")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="hdnChkInvAddress" runat="server" Value="0" />
    <asp:HiddenField ID="hdnChkDelAddress" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTotalAddressCount" runat="server" Value="0" />
</div>
