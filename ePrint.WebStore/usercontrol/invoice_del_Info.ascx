<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="invoice_del_Info.ascx.cs" Inherits="ePrint.WebStore.usercontrol.invoice_del_Info" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="/js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<style type="text/css">
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: #C9C9C9;
        border-width: 0 0 1px 0px; /*top right bottom left*/
    }
    .RowMouseOver td
    {
        background-color: #D4D4D4 !important;
        height: auto;
    }
    .RowMouseOut
    {
        background: #ffffff;
        height: auto;
    }
    
    .RadGrid .rgSelectedRow
    {
        background-color: #D4D4D4 !important;
        background-image: none !important;
        height: auto;
    }
    
    .RadGrid_Default
    {
        border: 1px solid #828282;
        background: #fff;
        font-family: Helvetica,sans-serif;
        font-size: 13px;
    }
    
    .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default
    {
        font-family: Helvetica,sans-serif;
        font-size: 13px;
    }
    html body .RadInput_Default .riTextBox, html body .RadInputMgr_Default
    {
        border-color: #8e8e8e #b8b8b8 #b8b8b8 #8e8e8e;
        background: #fff;
        font-family: Helvetica,sans-serif;
        font-size: 13px;
    }
    
    html body .RadInput_Default .riEmpty, html body .RadInput_Empty_Default
    {
        color: rgb(68, 68, 68);
    }
    
    .RadGrid_Default .rgRow a, .RadGrid_Default .rgAltRow a, .RadGrid_Default .rgEditRow a, .RadGrid_Default tr.rgEditRow a, .RadGrid_Default tr.rgHoveredRow a, .RadGrid_Default tr.rgActiveRow a, .RadGrid_Default .rgFooter a, .RadGrid_Default .rgEditForm a
    {
        color: #777777;
    }
    .RadGrid_Default .rgSelectedRow a
    {
        color: white;
    }
    .overlay-image {
    position: absolute;
    top: 250px;
    left: 600px;
    z-index: 9999; /* Set a high z-index to place the image above other elements */
    }
    .disabled-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 9999;
    opacity: 0;
    pointer-events: none;
    }
    #customCheckbox {
        display: block;

    }
    #customCheckbox + label:before {
        content: '';
        display: inline-block;
        width: 20px;
        height: 20px;
        border: 1px solid #000;
        text-align: center;
        line-height: 20px;
        margin-right: 5px;
        cursor: pointer;

    }
    #customCheckbox:checked + label:before {
        content: '✓';

    }
</style>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rdgrd_ship_choose">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lnkOrderDate_ship" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
                <telerik:AjaxUpdatedControl ControlID="lnkChooseShipAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rdgrd_bill_choose">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lnkOrderDate_bill" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
                <telerik:AjaxUpdatedControl ControlID="lnkChooseBillAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave_Bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
                 <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="imgSearch_Bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
                <telerik:AjaxUpdatedControl ControlID="imgSearch_Bill" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="imgSearch_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
                <telerik:AjaxUpdatedControl ControlID="imgSearch_Ship" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lnkChooseBillAddress">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkChooseBillAddress" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lnkChooseShipAddress">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkChooseShipAddress" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="LoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
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
                <telerik:AjaxUpdatedControl ControlID="txt_email_billing" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_bill" />
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
                <telerik:AjaxUpdatedControl ControlID="txt_email_billing" />
                <telerik:AjaxUpdatedControl ControlID="grd_Search_ship" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_Update_bill">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btn_Update_bill" />
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_email_billing" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_Update_Ship">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btn_Update_Ship" />
                <telerik:AjaxUpdatedControl ControlID="dialog" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_bill_choose" />
                <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                <telerik:AjaxUpdatedControl ControlID="lblBillingAddress" />
                <telerik:AjaxUpdatedControl ControlID="lblShippingAddress" />
                <telerik:AjaxUpdatedControl ControlID="hdnshippingaddr" />
                <telerik:AjaxUpdatedControl ControlID="txtaddressLabelBilling" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing1" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing2" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing3" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing4" />
                <telerik:AjaxUpdatedControl ControlID="txt_address_billing5" />
                <telerik:AjaxUpdatedControl ControlID="ddlCountry" />
                <telerik:AjaxUpdatedControl ControlID="txt_telephone_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_fax_billing" />
                <telerik:AjaxUpdatedControl ControlID="txt_email_billing" />
                <telerik:AjaxUpdatedControl ControlID="hdnChkInvAddress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1">
</telerik:RadAjaxLoadingPanel>
<div id="div_dcloading" align="center" style="display:none">
    <img src="images/radimg1.gif" class="overlay-image" alt="loading" border="0" />
</div>
<table id="tb_Address_Details">
    <tr id="tr_AddressInfoHeader" runat="server">
        <td colspan="2" class="CheckOutAddressHeader">
            <asp:Label ID="lblAddressInfoHeader" runat="server">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td id="td_invaddr" runat="server" class="clearBottom AddressDetails_Td">
            <div class="InvoiceDiv">
                <div class="HeaderColor">
                    <h3>
                        <asp:Label ID="lblInvoice_Address" runat="server"></asp:Label></h3>
                </div>
                <div class="paddingTop5">
                    <asp:Label ID="lblBillingAddress" runat="server"></asp:Label>
                </div>
            </div>
        </td>
        <td id="td_Deladdr" runat="server" class="clearBottom AddressDetails_Td">
            <div>
                <div class="HeaderColor">
                    <h3>
                        <asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label></h3>
                    <asp:HiddenField ID="hdnChkInvAddress" runat="server" />
                </div>
                <div class="paddingTop5">
                    <asp:Label ID="lblShippingAddress" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnshippingaddr" runat="server" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trChangeAddress" runat="server">
        <td id="td_Inv_Choose" runat="server" class="AddressDetails_Td">
            <div class="InvoiceDiv">
                <table>
                    <tr>
                        <td id="tdEditAddress" runat="server">
                            <asp:LinkButton ID="lnkEdit_Bill" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:ShowDialog_Both('Invoice','edit');"
                                OnClick="lnkEdit_Bill_Click"><%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                        </td>
                        <td id="tdChooseAddress" runat="server">
                            <asp:LinkButton ID="lnkChooseBillAddress" runat="server" CssClass="lnkAddressButton"
                                OnClientClick="javascript:ShowDialog3(true);" OnClick="lnkChooseBillAddress_Click"><%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;&nbsp;</asp:LinkButton>
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
        <td id="td_Del_Choose" runat="server" class="AddressDetails_Td">
            <div>
                <table>
                    <tr>
                        <td id="tdEditAddress1" runat="server">
                            <asp:LinkButton ID="lnkEdit_Ship" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:ShowDialog_Both('Delivery','edit');"
                                OnClick="lnkEdit_Ship_Click"><%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                        </td>
                        <td id="tdChooseAddress1" runat="server">
                            <asp:LinkButton ID="lnkChooseShipAddress" runat="server" CssClass="lnkAddressButton"
                                OnClientClick="javascript:ShowDialog4(true);" OnClick="lnkChooseShipAddress_Click"><%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                        </td>
                        <td id="tdAddAddress1" runat="server">
                            <a href="javascript:ShowDialog_Both('Delivery','new');" class="lnkAddressButton">
                                <%=objLanguage.GetLanguageConversion("Add_New_Address") %>
                            </a>
                        </td>
                        <td id="tdOrderPickup1" runat="server">
                            <a class="lnkAddressButton">
                                <%=objLanguage.GetLanguageConversion("Order_to_be_Picked_up") %>
                            </a>
                        </td>
                        <td id="tdChkPickup1" runat="server">
                            <asp:CheckBox ID="customCheckbox" runat="server" OnCheckedChanged="customCheckbox_CheckedChanged" Checked="false" />
                            <input type="hidden" id="hiddenCheckboxValue" runat="server" />
                            
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<div id="overlayDc" class="disabled-overlay"></div>
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
                            <asp:Label ID="lblNewAddress" runat="server"></asp:Label></b>
                    </div>
                    <div id="div_EditAddress">
                        <b>
                            <asp:Label ID="lblEditAddress" runat="server"></asp:Label></b>
                    </div>
                </td>
                <td class="align_right" align="right">
                    <a href="#" id="btnClose_bill" title="Close" class="floatRight">
                        <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                    <%--width="20px" height="20px" style="margin-right: -10px;" --%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblAddress_Label" runat="server"></asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txtaddressLabelBilling" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="Example-Style">&nbsp;<asp:Label ID="lnlExample_Note" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight" style="white-space: nowrap">
                    <asp:Label ID="lblAddressBill1" runat="server"></asp:Label>
                    <asp:Label ID="lblBillAdd1_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_address_billing1" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Address1" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing1"
                        Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblAddressBill2" runat="server"></asp:Label>
                    <asp:Label ID="lblBillAdd2_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_address_billing2" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Address2" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing2"
                        Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblAddressBill3" runat="server"></asp:Label>
                    <asp:Label ID="lblBillAdd3_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_address_billing3" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Address3" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing3"
                        Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblAddressBill4" runat="server"></asp:Label>
                    <asp:Label ID="lblBillAdd4_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_address_billing4" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Address4" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing4"
                        Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblAddressBill5" runat="server"></asp:Label>
                    <asp:Label ID="lblBillAdd5_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_address_billing5" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Address5" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing5"
                        Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblCountry" runat="server"></asp:Label><span class="mandatoryField">
                        *</span>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="width-dropdownlist">
                    </asp:DropDownList>
                    <span id="sdf" runat="server" class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Country" runat="server" ValidationGroup="Checkout" InitialValue="0"
                        ControlToValidate="ddlCountry" Text="This is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                    <asp:Label ID="lblBillPhone_UC" runat="server" class="mandatoryField">
                        *</asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_telephone_billing" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                    <span id="Span1" runat="server" class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="Required_Phone" runat="server" ValidationGroup="Checkout" Enabled="false"
                        Display="None" InitialValue="" ControlToValidate="txt_telephone_billing" Text="This is a required field."></asp:RequiredFieldValidator></span>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblFax" runat="server"></asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_fax_billing" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table TextAlignRight">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:TextBox ID="txt_email_billing" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                </td>
            </tr>
            <tr id="CopyDeltoInvAddress" runat="server">
                <td style="float: right;" class="leftCellNewAdd_table TextAlignRight">
                    <asp:CheckBox ID="Chk_copy_to_invaddress" runat="server" />
                </td>
                <td class="rightCellNewAdd_table">
                    <asp:Label ID="lblcopyDeladdress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="CopyInvtoDelAddress" runat="server">
                <td style="float: right;" class="leftCellNewAdd_table textalignRight">
                    <asp:CheckBox ID="Chk_copy_to_deladdress" runat="server" />
                </td>
                <td style="padding-top: 4px;">
                    <asp:Label ID="lblcopyInvaddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="leftCellNewAdd_table">
                </td>
                <td class="rightCellNewAdd_table">
                    <div id="Savebtn_Invoice" class="DisplayBlock">
                        <asp:Button ID="btnSave_Bill" runat="server" Text="Save and Use this Address" class="x-btn Grey main"
                            ValidationGroup="Checkout" OnClick="btnSave_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Savebtn_Invoice','div_btnsaveprocess12');">
                        </asp:Button>
                    </div>
                    <div id="Savebtn_Delivery" class="DisplayBlock">
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
                    <div id="Updatebtn_Invoice" class="DisplayBlock">
                        <asp:Button ID="btn_Update_bill" runat="server" Text="Update" class="x-btn Grey main"
                            ValidationGroup="Checkout" OnClick="btnUpdate_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Invoice','div_btnsaveprocessUpdate');">
                        </asp:Button>
                    </div>
                    <div id="div_btnsaveprocessUpdate" class="x-btnpro Grey main" align="center">
                        <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />
                    </div>
                    <div id="Updatebtn_Delivery" class="DisplayBlock">
                        <asp:Button ID="btn_Update_Ship" runat="server" Text="Update" class="x-btn Grey main"
                            ValidationGroup="Checkout" OnClick="btnUpdate_Ship_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Delivery','div_btnsaveprocessUpdate');">
                        </asp:Button>
                    </div>
                    <div id="divUpdate_UC" class="x-btnpro Grey main" align="center">
                        <img src="/images/radimg1.gif" class="trans" alt="loading" border="0" />
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
                        <asp:Label ID="lblAddressBook" runat="server"></asp:Label>
                    </div>
                </td>
                <td class="align_right">
                    <a href="#" id="btnClose_bill_Choose" title="Close" class="floatRight">
                        <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px paddingBottom5" style="padding-bottom: 5px;">
                    <div class="div_SearchTextBox">
                        <div class="floatLeft">
                            <asp:Panel DefaultButton="imgSearch_Bill" ID="Panel2" runat="server">
                                <telerik:RadTextBox ID="grd_Search_bill" runat="server" EmptyMessage="Search Address"
                                    CssClass="txt_Search" Width="200px" BorderColor="Transparent">
                                </telerik:RadTextBox>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:ImageButton ID="imgSearch_Bill" runat="server" ImageUrl="~/images/StoreImages/Search1.png"
                                OnClick="grd_Search_bill_OnTextChanged" CssClass="img_Search" ToolTip="Search" />
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px paddingBottom5 paddingTop5">
                    <span runat="server" id="spn_ListAllAdddress" class="Color007ED3_Blue"></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px">
                    <telerik:RadGrid ID="rdGrd_bill_Choose" runat="server" CssClass="width-474px" AutoGenerateColumns="false"
                        AllowSorting="false" AllowFilteringByColumn="false" AllowPaging="true" OnItemDataBound="rdGrd_bill_Choose_OnItemDataBound"
                        PageSize="1000" BorderColor="Transparent" AlternatingItemStyle-BackColor="Transparent">
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
                                        <asp:LinkButton ID="lnkOrderDate_bill" Text='<%#Bind("AddressNew")%>' runat="server"
                                            CssClass="gridlinkbutton" ToolTip='<%#Bind("AddressNew")%>' OnCommand="lnkOrderDate_bill_Click"
                                            CausesValidation="false" CommandArgument='<%#Eval("AddressID")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("No_Records")%></span>
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
                        <asp:Label ID="lblAddressBook1" runat="server"></asp:Label>
                    </div>
                </td>
                <td class="align_right">
                    <a href="#" id="btnClose_ship_Choose" title="Close" class="floatRight">
                        <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px paddingBottom5">
                    <div class="div_SearchTextBox">
                        <div class="floatLeft">
                            <asp:Panel DefaultButton="imgSearch_Ship" ID="Panel1" runat="server">
                                <telerik:RadTextBox ID="grd_Search_ship" runat="server" EmptyMessage="Search Address"
                                    Width="200px" BorderColor="Transparent" CssClass="txt_Search">
                                </telerik:RadTextBox>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:ImageButton ID="imgSearch_Ship" runat="server" ImageUrl="~/images/StoreImages/Search1.png"
                                OnClick="grd_Search_ship_OnTextChanged" CssClass="img_Search" />
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px paddingBottom5 paddingTop5">
                    <span runat="server" id="spn_ListAllAdddress1" class="Color007ED3_Blue"></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="paddingleft-12px">
                    <telerik:RadGrid ID="rdgrd_ship_choose" runat="server" CssClass="width-474px" AutoGenerateColumns="false"
                        AllowSorting="false" AllowFilteringByColumn="false" AllowPaging="true" OnItemDataBound="rdgrd_ship_choose_OnItemDataBound"
                        PageSize="1000" BorderColor="Transparent" AlternatingItemStyle-BackColor="Transparent">
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
                                        <asp:LinkButton ID="lnkOrderDate_ship" Text='<%#Bind("AddressNew")%>' runat="server"
                                            CssClass="gridlinkbutton" ToolTip='<%#Bind("AddressNew")%>' OnCommand="lnkOrderDate_ship_Click"
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
    <script type="text/javascript">
        $(document).keypress(function (e) {
            var keyCode = (window.event) ? e.which : e.keyCode;
            //            if (keyCode && keyCode == 13) {
            //                e.preventDefault();
            //                return false;
            //            }
        });
    </script>
</div>
