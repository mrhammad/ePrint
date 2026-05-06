<%@ Page Title="Order details" Language="C#" MasterPageFile="~/Templates/masterPageDefault.master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="ePrint.WebStore.order" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="js/Slide/jsPopup.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Js_Wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>


    <script type="text/javascript" src="<%=strSitepath %>js/default.js?VN='<%=VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        var StoreUserID = '<%=StoreUserID%>';
        var imagePath = '<%=imagePath %>';
        var CompanyID = '<%=CompanyID %>';

        var hid_MultiplePrice = document.getElementById("<%= hid_MultiplePrice.ClientID%>");
        function ShowDialog(value) {
            var hdnActionType = document.getElementById('ctl00_ContentPlaceHolder1_hdnActionType');
            hdnActionType.value = value;
            $("#overlay").show();
            $("#dialog").fadeIn(300);
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(300);
        }

        $(document).ready(function () {
            $("#btnClose_bill").click(function (e) {
                HideDialog();
                e.preventDefault();
            });
        });

    </script>
    <style>
        
    </style>
    <asp:HiddenField ID="hid_MultiplePrice" runat="server" Value="0" />
    <script src="js/cart.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/pdf_preview.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateExistanceOfPassword(Value, StoreUserID) {
            AutoFill.ExistanceOfPassword(StoreUserID, Value, GetApproverID);
        }
        function GetApproverID(result) {
            if (result != 0) {
                return true;
            }
            else {
                var msg = '<%=objLanguage.GetLanguageConversion("Approver_password_not_contains_in_this_Account")%>';
                alert(msg);
                return false;
            }
        }
    </script>




    <%-- Start --%>




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
                    <td colspan="2"></td>
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
                <tr id="CopyDeltoInvAddress" runat="server" style="display: none;">
                    <td style="float: right;" class="leftCellNewAdd_table TextAlignRight">
                        <asp:CheckBox ID="Chk_copy_to_invaddress" runat="server" />
                    </td>
                    <td class="rightCellNewAdd_table">
                        <asp:Label ID="lblcopyDeladdress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="CopyInvtoDelAddress" runat="server" style="display: none;">
                    <td style="float: right;" class="leftCellNewAdd_table textalignRight">
                        <asp:CheckBox ID="Chk_copy_to_deladdress" runat="server" />
                    </td>
                    <td style="padding-top: 4px;">
                        <asp:Label ID="lblcopyInvaddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCellNewAdd_table"></td>
                    <td class="rightCellNewAdd_table">
                        <div id="Savebtn_Invoice" class="DisplayBlock">
                            <asp:Button ID="btnSave_Bill" runat="server" Text="Save and Use this Address" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnSave_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Savebtn_Invoice','div_btnsaveprocess12');"></asp:Button>
                        </div>
                        <div id="Savebtn_Delivery" class="DisplayBlock">
                            <asp:Button ID="btnSave_Ship" runat="server" Text="Save and Use this Address" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnSave_Ship_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Savebtn_Delivery','div_btnsaveprocess12');"></asp:Button>
                        </div>
                        <div id="div_btnsaveprocess12" class="x-btnpro Grey main" align="center">
                            <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />
                        </div>
                        <div id="divSave_UC" class="x-btnpro Grey main" align="center">
                            <img src="/images/radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                        <div id="Updatebtn_Invoice" class="DisplayBlock">
                            <asp:Button ID="btn_Update_bill" runat="server" Text="Update" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnUpdate_Bill_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Invoice','div_btnsaveprocessUpdate');"></asp:Button>
                        </div>
                        <div id="div_btnsaveprocessUpdate" class="x-btnpro Grey main" align="center">
                            <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />
                        </div>
                        <div id="Updatebtn_Delivery" class="DisplayBlock">
                            <asp:Button ID="btn_Update_Ship" runat="server" Text="Update" class="x-btn Grey main"
                                ValidationGroup="Checkout" OnClick="btnUpdate_Ship_OnClick" OnClientClick="if(Page_ClientValidate()) loadingimg('Updatebtn_Delivery','div_btnsaveprocessUpdate');"></asp:Button>
                        </div>
                        <div id="divUpdate_UC" class="x-btnpro Grey main" align="center">
                            <img src="/images/radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
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



    <%-- End --%>
    <div id="OrderPage">
        <div>
            <%--<div id="output">
            </div>
            <div id="overlay" class="web_dialog_overlay_Address">
            </div>--%>
            <%--<div id="dialog" class="web_dialog_Address">
                <table align="center" class="widthAuto heightAuto">
                    <tr>
                        <td class="web_dialog_title_Address width48p">
                            <div id="div_NewAddress">
                                <b>Approver Password</b>
                            </div>
                        </td>
                        <td class="align_right width52p" align="right">
                            <a href="#" id="btnClose_bill" title="Close" class="closeStyle floatRight">
                                <img alt="" class="imageclose DisplayBlock" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="leftCellNewAdd_table">
                            Approver Password<label id="Label1" class="mandatoryField">
                                *</label>
                        </td>
                        <td class="rightCellNewAdd_table">
                            <asp:TextBox ID="txtApproverPwd" runat="server" CssClass="ApproverPswd_Txtbx" TextMode="Password"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator ID="reqemail" runat="server" ControlToValidate="txtApproverPwd"
                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="CreateAccount"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnApprPassword_Save" runat="server" Text="Save" class="x-btnpro Grey main"
                                ValidationGroup="CreateAccount" OnClick="btnApprPassword_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>--%>
        </div>
        <div id="OrderMain_div">
            <div id="Order_background_Outer">
                <div id="Order_background">
                    <div id="OrderContent_div">
                        <div id="Order_heading" class="Header_Background">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Orders_Details") %></strong>
                        </div>
                        <div class="clearBoth paddingTop5">
                        </div>
                        <div id="Order_area" runat="server">
                            <div class="width100p">
                                <div class="orderDetails_div">
                                    <div class="orderDetails1">
                                        <div class="clearBoth">
                                        </div>
                                        <table class="width750px">
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="lblOrderNo" runat="server"><%=objLanguage.GetLanguageConversion("Order_Reference") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td class="Order_areaDetailsTD1">
                                                    <div class="orderDetails_right5">
                                                        <asp:Label ID="lbl_OrderNo" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="lblname" runat="server"><%=objLanguage.GetLanguageConversion("Ordered_For") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td class="Order_areaDetailsTD2">
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lbl_name" runat="server"></asp:Label><span id="spnattn" runat="server"
                                                            class="DisplayNone floatLeft smallfont"><%=objLanguage.GetLanguageConversion("For_the_attention_of")%><asp:Label
                                                                ID="lblatnfor" CssClass="smallfontgrey" runat="server"></asp:Label>
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblOrderDate" runat="server"><%=objLanguage.GetLanguageConversion("Order_Date") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lbl_OrderDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblemail" runat="server"><%=objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321 --%>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblOrderTitle" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <%--                                                        <asp:Label ID="lbl_OrderTitle" runat="server"></asp:Label>--%>
                                                        <input type="text" id="lbl_OrderTitle" runat="server" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <%=objLanguage.GetLanguageConversion("Ordered_By") %>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_Orderedby" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321--%>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblUserRefOrderNo" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <%--                                                        <asp:Label ID="lbl_UserRefOrderNo" runat="server"></asp:Label>--%>
                                                        <input type="text" id="lbl_UserRefOrderNo" runat="server" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblordbyemail" runat="server"><%=objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <div class="floatLeft">
                                                            <asp:Label ID="lbl_Orderedbyemail" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321 --%>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left OrderDetailsClearTop2">
                                                        <asp:Label ID="lblDelivery" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right4">
                                                        <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td id="tdlblStatus" runat="server">
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblstatus" runat="server"><%=objLanguage.GetLanguageConversion("Status") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td id="tdStatus" runat="server">
                                                    <div class="floatLeft orderDetails_right3">
                                                        <asp:Label ID="lbl_Status" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="floatLeft paddingLeft5">
                                                        <asp:Image ImageUrl="images/StoreImages/Reject.png" CssClass="CursorPointer" ID="RejectImage"
                                                            runat="server" Visible="false" />
                                                    </div>
                                                </td>


                                                <td>
                                                    <div class="orderDetails_left OrderDetailsClearTop2">
                                                        <asp:Label ID="Label7" runat="server">Attachments</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:FileUpload ID="fp_artwork" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" class="x-btnpro Grey main" OnClick="fileUploadControl_Click" />
                                                        <br />
                                                        <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Visible="false" />
                                                    </div>
                                                </td>


                                            </tr>
                                            <tr id="TrCost" runat="server">

                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <%-- <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("CostCentre")%></asp:Label>--%>
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lblCostcenter" runat="server"></asp:Label>
                                                    </div>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="Label3" runat="server">Consignment Number</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div id="divconsignment" class="orderDetails_right2" style="width: 295px">
                                                        <div class="orderDetails_right3" style="display: none; width: 205px">
                                                            <asp:Label ID="lbl_ConsignmentNoteNumber" Style="display: none; width: 205px" runat="server"></asp:Label>
                                                        </div>


                                                    </div>
                                                </td>

                                                <td>
                                                    <div class="orderDetails_left OrderDetailsClearTop2">
                                                        <asp:Label ID="lbl_attachmentlist" runat="server">Attachment's List</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:GridView ID="attachmentGridView" AutoGenerateColumns="false" OnRowDeleting="attachmentGridView_RowDeleting" GridLines="Horizontal" runat="server">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="208px" HeaderText="Attachment Name">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="downloadLink" runat="server" Target="_blank" NavigateUrl='<%# Eval("AttachmentPath") %>' Text='<%# Eval("OriginalAttachmentName") %>' />
                                                                        <%--<%# Eval("AttachmentName") %>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:LinkButton ID="deleteLink" ForeColor="Red" runat="server" CommandName="Delete" CommandArgument='<%# Eval("AttachmentId") %>' Text="X" OnClick="deletelink_click" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <%--             <asp:FileUpload ID="FileUpload1" runat="server" size="30" CssClass="fp_artwork_no_addoption" />
                                                        <asp:Button ID="Button1" runat="server" Text="Upload" class="x-btnpro Grey main" OnClick="fileUploadControl_Click"/>--%>
                                                        <br />
                                                        <asp:Label ID="Label9" runat="server" Text="Attachments" ForeColor="Red" Visible="false" />
                                                    </div>
                                                </td>


                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2" id="Div_CouponCode" runat="server" style="display: none">
                                                        <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" id="Divlbl_CouponCode" runat="server" style="display: none; width: 205px">
                                                        <asp:Label ID="lblCouponCode" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div runat="server" id="div_paymentmode" class="DisplayBlock">
                                                        <div class="orderDetails_left2">
                                                            <asp:Label ID="lblPayment" runat="server"><%=objLanguage.GetLanguageConversion("Payment_Mode")%></asp:Label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3" style="<%=PaymentMode_Style%>">
                                                        <asp:Label ID="lbl_Payment" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_consigneeurl" class="DisplayNone">
                                            <div class="orderDetails_left paddingTop3">
                                                <asp:Label ID="lblConsigneeurl" runat="server"><%=objLanguage.GetLanguageConversion("Consignee_Url")%></asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width: 295px">
                                                <a id="ancConsigneeurl" target="_blank" class="ColorBlue TextUnderline"></a>
                                            </div>
                                            <%--       <div id="divconsignment" class="orderDetails_right" style="width: 295px">--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <br />
                                <div>
                                    <div id="order_billingAddress" runat="server" class="order_billingAddress" style="word-break: break-all">
                                        <div class="order_Address_header paddingBottom5 paddingTop5">
                                            <strong>
                                                <asp:Label ID="lbl_BliingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label></strong><br />
                                        </div>
                                        <div class="order_Address_content">
                                            <asp:Label ID="lbl_BliingAddress" runat="server" CssClass="line_height20px">Invoice Address</asp:Label><br />
                                        </div>



                                        <div class="InvoiceDiv">
                                            <table>
                                                <tr>
                                                    <td id="tdEditAddress" runat="server">

                                                        <asp:LinkButton ID="lnkEdit_Bill" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:callFunc('Invoice','edit'); return false;"><%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;&nbsp;</asp:LinkButton>

                                                        <%--<asp:LinkButton ID="LinkButton12" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:callFunc('Invoice','edit'); return false;">Call Service</asp:LinkButton>--%>


                                                    </td>
                                                    <%--<td id="tdChooseAddress" runat="server">
                                                            <asp:LinkButton ID="lnkChooseBillAddress" runat="server" CssClass="lnkAddressButton"
                                                                OnClientClick="javascript:ShowDialog3(true);return false;" OnClick="lnkChooseBillAddress_Click"><%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                                                        </td>--%>
                                                    <td id="tdAddAddress" runat="server">
                                                        <a href="javascript:callFunc('Invoice','new');" class="lnkAddressButton">
                                                            <%=objLanguage.GetLanguageConversion("Add_New_Address") %>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>


                                    </div>





                                    <div id="divDeliveryAddress" runat="server" class="order_shippingAddress" style="word-break: break-all">
                                        <div id="divShippingAddress" runat="server" class="order_Address_header paddingBottom5 paddingTop5">
                                            <strong>
                                                <asp:Label ID="lbl_ShippingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label></strong><br />
                                        </div>
                                        <div class="order_Address_content">
                                            <asp:Label ID="lbl_ShippingAddress" CssClass="line_height20px" runat="server">Delivery Address</asp:Label>
                                        </div>



                                        <div>
                                            <table>
                                                <tr>
                                                    <td id="tdEditAddress1" runat="server">
                                                        <asp:LinkButton ID="lnkEdit_Ship" runat="server" CssClass="lnkAddressButton" OnClientClick="javascript:callFunc('Delivery','edit'); return false;"><%=objLanguage.GetLanguageConversion("Edit_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                                                    </td>
                                                    <%--<td id="tdChooseAddress1" runat="server">
                                                            <asp:LinkButton ID="lnkChooseShipAddress" runat="server" CssClass="lnkAddressButton"
                                                                OnClientClick="javascript:ShowDialog4(true);return false;" OnClick="lnkChooseShipAddress_Click"><%=objLanguage.GetLanguageConversion("Choose_Address") %>&nbsp;&nbsp;</asp:LinkButton>
                                                        </td--%>
                                                    <td id="tdAddAddress1" runat="server">
                                                        <a href="javascript:callFunc('Delivery','new');" class="lnkAddressButton">
                                                            <%=objLanguage.GetLanguageConversion("Add_New_Address") %>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>





                                    </div>
                                </div>

                                <div>
                                    <div class="PaymentMode_details_right">
                                        <asp:TextBox name="txtComments" ID="txtComments" runat="server" CssClass="MulilineText_Comment" TextMode="MultiLine"></asp:TextBox>
                                        <div class="floatLeft paddingLeft5">
                                            <span id="spn_Comments" class="mandatoryField DisplayNone paddingTop5">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Comments")%></span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="clearBoth">
                            </div>
                            <div id="orderConfirm_header" style="margin-right: 50px; width: 100%" class="clearBottom">
                                <table border="0" id="CartItems_table" class="b_productName_table" style="width: 100%;">
                                    <tr>
                                        <td style="width: auto">
                                            <div id="HeaderCheckbox" runat="server" style="display: none; width: 75px;" class="CheckBoxAlign">
                                                <div class="floatLeft">
                                                    <input id="checkAll" runat="server" checked="checked" name="checkAll" onclick="CheckAll(this);"
                                                        type="checkbox" />
                                                </div>
                                            </div>
                                        </td>
                                        <td id="orderreference" runat="server" style="white-space: nowrap; text-align: center; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="width: 125px">
                                                <%--<asp:Label ID="ordref" Font-Bold="true" runat="server"></asp:Label>--%>
                                                <strong>&nbsp;<%=objLanguage.GetLanguageConversion("Order_Reference")%>
                                            </div>
                                        </td>
                                        <td style="white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 190px;">
                                                <strong>&nbsp;<%=objLanguage.GetLanguageConversion("Product_Name")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="productdesc" runat="server" style="white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 190px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Product_Description")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td style="text-align: center; white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="width: 100px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Delivery_Date")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="qty" runat="server" style="text-align: right; white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="width: 35px; float: right">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Qty")%></strong>
                                            </div>
                                        </td>
                                        <td id="CampaignSignNumber" runat="server" visible="false" style="white-space: nowrap; padding-left: 4px; width: auto" align="center">
                                            <div class="clearTopBottom" style="width: 90px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Sign_Number")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="Campaign_Td" runat="server" visible="false" style="white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 110px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Campaign_Name")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="tdStaus" runat="server" style="text-align: left; white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 145px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Order_Status")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="tdApprovedStaus" runat="server" visible="false" style="white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 115px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Approved")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="ItemMaterial" runat="server" style="white-space: nowrap; padding-left: 4px; width: auto">
                                            <div class="clearTopBottom" style="min-width: 110px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Item_Material")%>
                                                </strong>
                                            </div>
                                        </td>
                                        <td id="JobName" runat="server" align="left" style="padding-top: 5px; white-space: nowrap; padding-left: 4px; width: auto">
                                            <div id="divJobName" runat="server" class="Job_NameDiv" style="width: 140px">
                                                <asp:Label runat="server" ID="lblJobname" Style="font-weight: bold;"></asp:Label>
                                                <%--<strong>&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Job_Name_Details")%>
                                                    </strong>--%>
                                            </div>
                                        </td>
                                        <td align="left" style="white-space: nowrap; padding-left: 4px;" runat="server" id="tdBeUser"
                                            visible="false">
                                            <div class="clearTopBottom" style="width: 85px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Behalf_of_User")%></strong>
                                            </div>
                                        </td>
                                        <td align="left" style="white-space: nowrap; padding-left: 4px;" runat="server" id="tdBeDept"
                                            visible="false">
                                            <div class="clearTopBottom" style="width: 85px">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Behalf_of_Department")%></strong>
                                            </div>
                                        </td>
                                        <td id="tdUnitprice" runat="server" style="white-space: nowrap; padding-left: 4px; width: auto" align="right">
                                            <div class="clearTopBottom" style="width: 85px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Unit_Price")%>
                                                        (<%=comm.GetCurrencyinRequiredFormate("",true)%>) </strong>
                                            </div>
                                        </td>
                                        <td id="tdTaxApplicable" runat="server" style="white-space: nowrap; padding-left: 10px; width: auto" align="left">
                                            <div class="clearTopBottom" style="width: 150px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Tax_Applicable")%></strong>
                                            </div>
                                        </td>
                                        <td id="td_CouponCodeDiscount" runat="server" style="white-space: nowrap; display: none; padding-left: 4px; width: auto"
                                            align="right">
                                            <div class="clearTopBottom" style="width: 110px;">
                                                <strong>
                                                    <%=objLanguage.GetLanguageConversion("Discount")%>
                                                        (<%=comm.GetCurrencyinRequiredFormate("",true)%>) </strong>
                                            </div>
                                        </td>
                                        <td id="tdTotal" runat="server" style="white-space: nowrap; padding-left: 4px; width: auto" align="right">
                                            <div class="clearTopBottom" style="min-width: 85px;">
                                                <asp:Label ID="lblTotal" runat="server" Style="font-weight: bolder;"> 
                                                        <%=objLanguage.GetLanguageConversion("Total_ex_Tax")%>
                                                </asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <asp:PlaceHolder ID="plhorder" runat="server"></asp:PlaceHolder>
                                    <asp:HiddenField ID="hdnOrderItemID" runat="server" Value="" />
                                    <!--   </table>
                               </div>
                                <div class="clearBoth clearBottom">
                                    <table border="0" id="orderConfirm_footer_Main">-->
                                    <tr style="border-bottom-style: none;">
                                        <td colspan="18">
                                            <div id="orderConfirm_footer" class="width100p" style="margin-top: 15px">
                                                <table border="0" class="width100p">
                                                    <tr>
                                                        <td align="right">
                                                            <div id="orderConfirm_footer_right" style="margin-right: 3px">
                                                                <asp:Label ID="lbl_subTotal_cost" runat="server" Text="0.00"></asp:Label><br />
                                                                <div class="paddingTop5">
                                                                    <asp:PlaceHolder ID="plhOrdAddOptionsPrice" runat="server"></asp:PlaceHolder>
                                                                </div>
                                                                <div class="div_Tax">
                                                                    <asp:Label ID="lbl_TaxValue" runat="server" Text="0.00"></asp:Label>
                                                                </div>
                                                                <div id="div1" runat="server">
                                                                </div>
                                                                <div id="div3" runat="server" class="horizontal_line_B2B2">
                                                                </div>
                                                                <div class="lbl_grandTotalDiv">
                                                                    <asp:Label ID="lbl_grandTotal_cost" CssClass="Grandtotal" runat="server" Text="0.00"></asp:Label>
                                                                </div>
                                                                <div id="div4" runat="server" class="horizontal_line_B2B2 floatRight">
                                                                </div>
                                                            </div>
                                                            <div id="orderConfirm_footer_left">
                                                                <asp:Label ID="lbl_subTotal" runat="server" CssClass="lbl_subTotal" Text=""><%=objLanguage.GetLanguageConversion("Price_ex_Tax_New") %></asp:Label><br />
                                                                <div class="OrdAddOptionsDiv">
                                                                    <asp:PlaceHolder ID="plhOrdAddOptions" runat="server"></asp:PlaceHolder>
                                                                </div>
                                                                <div class="div_Tax2">
                                                                    <asp:Label ID="lbl_tax" runat="server" CssClass="fontBold" Text="Total Tax"><%=objLanguage.GetLanguageConversion("Total_Tax") %></asp:Label>
                                                                </div>
                                                                <div id="div5" runat="server" class="horizontal_line_B2B2">
                                                                </div>
                                                                <div class="lbl_grandTotalDiv">
                                                                    <asp:Label ID="lbl_grandTotal" runat="server" CssClass="Grandtotal" Text=""><%=objLanguage.GetLanguageConversion("Grand_Total") %></asp:Label>
                                                                </div>
                                                                <div id="div6" runat="server" class="horizontal_line_B2B2 floatRight">
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="DivApproverPassword" runat="server">
                                                                <div class="lblApproverPasswordDiv" id="div2" runat="server">
                                                                    <asp:Label ID="lblpwd" CssClass="contactAddressTest" runat="server" Text="Please enter Approver Password"></asp:Label>
                                                                </div>
                                                                <table class="ApprovalTable">
                                                                    <tr>
                                                                        <td class="ProfileText2">
                                                                            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                                                                            <label id="Label6" class="mandatoryField">
                                                                                *</label>
                                                                        </td>
                                                                        <td class="Padding paddingLeft5">
                                                                            <div>
                                                                                <asp:TextBox ID="txtApproverPassword" TextMode="Password" class="ws_txtWidth260"
                                                                                    runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div>
                                                                                <asp:Label ID="lblReqiPassword" runat="server" Visible="false" CssClass="ColorRed"><%=objLanguage.GetLanguageConversion("Approver_password_not_contains_in_this_Account")%></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <div runat="server" id="divButtons" style="margin-top: 10px;" visible="false">
                                                                <div id="DivReject" class="floatLeft">
                                                                    <asp:Button ID="btn_Reject" runat="server" Text="Reject" CssClass="x-btnpro Grey main"
                                                                        OnClick="btn_Reject_Click" ValidationGroup="CreateAccount1" />
                                                                </div>
                                                                <div id="DivRejectloa" style="display: none;" class="x-btnpro Grey main" align="center">
                                                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                                </div>
                                                                <div id="div_btnApproved">
                                                                    <asp:Button ID="btn_Approve" runat="server" Text="Approve" CssClass="x-btnpro Grey main"
                                                                        OnClick="btn_Approve_Click" />
                                                                </div>
                                                                <div id="div_btnApprovedloa" style="display: none;" class="x-btnpro Grey main" align="center">
                                                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div class="clearBoth">
                                </div>
                            </div>
                            <%-- <div class="orderDetails_txtReasonDiv">
                                    <asp:TextBox ID="txtReason" runat="server" Text="" CssClass="order_ReasonTxtBx" TextMode="MultiLine" /></div>
                                <div id="divReason" class="orderDetails_req_ReasonDiv">
                                    <span id="req_Reason">
                                        <%=objLanguage.GetLanguageConversion("Please_enter_reason_for_rejecting_the_order")%></span>
                                </div>--%>
                            <telerik:RadWindow ID="RadWindow2" Skin="Default" runat="server" Height="210px" Width="450px"
                                EnableShadow="true" VisibleOnPageLoad="true" Visible="false" Top="250px" Left="510px"
                                ShowContentDuringLoad="false" OnClientClose="CloseBackground" Behaviors="Close,Move,Reload">
                                <ContentTemplate>
                                    <div class="disapprove_WindowDiv">
                                        <table border="0" cellpadding="0" cellspacing="0" class="width100p">
                                            <tr>
                                                <td class="disapprove_WindowTbl_TD1">
                                                    <asp:Label ID="lblDis" runat="server" Text="Reject Reason"></asp:Label>
                                                    <label id="Label4" class="mandatoryField">
                                                    </label>
                                                </td>
                                                <td>
                                                    <div>
                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="Validationfont ColorRed">
                                                        <asp:RequiredFieldValidator ID="RequiredlstDepartment" runat="server" ValidationGroup="Reject"
                                                            ControlToValidate="txtReason" Display="Dynamic" ErrorMessage="Please Enter Reject Reason">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td class="clearTop">
                                                    <div id="Div_Ok" class="floatLeft">
                                                        <asp:Button ID="btnOk" runat="server" Text="Ok" Style="width: 75px; height: 27px;"
                                                            ValidationGroup=" " class="x-btnpro Grey" OnClick="btnOk_Click" OnClientClick="javascript:loadingimg('Div_Ok', 'divok_load');" />
                                                    </div>
                                                    <div id="divok_load" style="display: none; display: none; float: left; margin-left: 0px;"
                                                        class="x-btnpro Grey main" align="center">
                                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </telerik:RadWindow>
                            <div>
                                <div align="center">
                                    <div class="clearBoth">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnActionType" runat="server" Value="" />
        <script type="text/javascript" language="javascript">

            var IsPPW_SystemName = '<%=IsPPW_SystemName %>';
            var order_billingAddress = document.getElementById("ctl00_ContentPlaceHolder1_order_billingAddress");

            function IfB2B_System() {
                if (IsPPW_SystemName == "True")
                    order_billingAddress.style.display = "none";
            }
            var consigneeurl = '<%=consigneeurl %>';
            var consignementnum = '<%=consignementnum %>';
            var myDiv = document.getElementById('divconsignment');



            function checkforconsigneeurl() {

                var consigneeurlarray = consigneeurl.split(',');
                var consignementarray = consignementnum.split(',');
                if (consignementnum != '' || consigneeurl != '') {
                    debugger;
                    for (i = 0; i < consignementarray.length; i++) {

                        var lineBreak = document.createElement("br");
                        var lineBreak2 = document.createElement("br");
                        var lineBreak3 = document.createElement("br");

                        if (consignementarray[i] != '' && consignementarray[i] != null) {
                            var label = document.createElement('label');
                            label.textContent = consignementarray[i];
                            myDiv.appendChild(label);
                            myDiv.appendChild(lineBreak2);
                        }


                        if (consigneeurlarray[i] != '' && consigneeurlarray[i] != null) {
                            // Create an anchor element
                            var anchor = document.createElement('a');
                            anchor.href = consigneeurlarray[i];
                            anchor.target = '_blank';
                            anchor.style = "color: blue;text-decoration: underline; "
                            anchor.textContent = 'Click here to track your Consignment';
                            myDiv.appendChild(anchor);
                            myDiv.appendChild(lineBreak3);
                        }


                    }
                    //  document.getElementById("div_consigneeurl").style.display = "block";
                }


                //if (consigneeurl != '') {
                //    document.getElementById("div_consigneeurl").style.display = "block";
                //    document.getElementById("ancConsigneeurl").href = consigneeurl;
                //    document.getElementById("ancConsigneeurl").innerHTML = "Click here to track your Consignment";

                //}
                //else {
                //    document.getElementById("div_consigneeurl").style.display = "none";
                //}
            }
            checkforconsigneeurl();
        </script>
        <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Artwork View"
                    KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true" Modal="true"
                    ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
            <script type="text/javascript">
                function openArtworkPopup(CartItemID, OrderItemID, OrderID, Page) {

                    var oWnd = $find("<%= RadWindow1.ClientID %>");

                    oWnd.setUrl('<%=strSitepath %>' + "common/artwork_common.aspx?CartItemID=" + CartItemID + "&OrderItemId=" + OrderItemID + "&from=" + Page + "&OrderID=" + OrderID);
                    oWnd.setSize(600, 300);
                    oWnd.center();
                    oWnd.show();
                }
            </script>
        </telerik:RadScriptBlock>
    </div>
    <script type="text/javascript">
        function CheckAll(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }
        function CheckChanged(id) {
            var frm = document.forms[0];
            var boolAllChecked;
            // var hdnChecked = document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked");
            var Id;
            boolAllChecked = true;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1)
                    if (!e.disabled) {
                        if (e.checked == false) {
                            boolAllChecked = false;
                            break;
                        }
                    }
            }
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                    }
                    else {
                        e.checked = true;
                        break;
                    }
                }
            }
        }
        var textval = '';
        function Validate(val) {

            textval = val;
            var Counter = 0
            var frm = document.getElementById("CartItems_table");
            var frmCheckBox = frm.getElementsByTagName('input');
            var Id;
            var CartId;
            var hdnOrderItemID = document.getElementById('<%=hdnOrderItemID.ClientID %>');
            hdnOrderItemID.value = "";
            var valid = true;
            for (i = 0; i < frmCheckBox.length; i++) {
                e = frmCheckBox[i];
                if (e.type == 'checkbox' && e.id.indexOf('chkEachLine') != -1) {
                    if (!e.disabled) {
                        if (e.checked) {
                            Counter = Number(Counter) + 1;
                            Id = e.id.split("chkEachLine");
                            hdnOrderItemID.value += Id[1] + ',';
                        }
                    }
                }
            }
            if (val == 'Approve') {
                if (Number(Counter) == 0) {
                    alert("Please check at least one item to Approve");
                    valid = false;
                }
                else {
                    loadingimg('div_btnApproved', 'div_btnApprovedloa');
                }
            }
            if (val == 'Reject') {
                if (Number(Counter) == 0) {
                    alert("Please check at least one item to Reject");
                    valid = false;
                }
                else {
                    loadingimg('DivReject', 'DivRejectloa');
                }
            }

            if (valid) {
                return true;
            }
            else {
                return false;
            }


        }

        function get_background_onreject() {

            document.getElementById('divBackGroundLeftPanelMasterPage').style.display = 'block';
            document.getElementById('divBackGroundLeftPanelMasterPage').style.zIndex = 500;
            document.getElementById('divBackGroundLeftPanelMasterPage').style.background = 'white';
            document.getElementById('divBackGroundLeftPanelMasterPage').style.opacity = 0.5;
            document.getElementById('divBackGroundLeftPanelMasterPage').style.width = '100%';
            document.getElementById('divBackGroundLeftPanelMasterPage').style.height = '100%';
        }
        function CloseBackground() {
            document.getElementById('divBackGroundLeftPanelMasterPage').style.display = 'none';
        }
        function callFunc(modal, type) {

            $("#overlay").show();
            $("#dialog").fadeIn(300);
            document.getElementById("div_btnsaveprocess12").style.display = "none";       //Added by ved for loading image 
            document.getElementById("div_btnsaveprocessUpdate").style.display = "none";   //Added by ved for loading image 
            if (type == "new") {
                document.getElementById("div_NewAddress").style.display = "block";
                document.getElementById("div_EditAddress").style.display = "none";
                if (modal == "Invoice") {
                    $("#overlay").unbind("click");
                    RegionalSettingCountryForAddress();
                    document.getElementById("Savebtn_Invoice").style.display = "block";
                    document.getElementById("Savebtn_Delivery").style.display = "none";
                    document.getElementById("Updatebtn_Invoice").style.display = "none";
                    document.getElementById("Updatebtn_Delivery").style.display = "none";

                    document.getElementById("ctl00_ContentPlaceHolder1_CopyDeltoInvAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_CopyInvtoDelAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Chk_copy_to_deladdress").checked = false;

                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddressLabelBilling").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_telephone_billing").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_fax_billing").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing1").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing2").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing3").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing4").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing5").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddressLabelBilling").focus();
                    RegionalSettingCountryForAddress();
                }
                else if (modal == "Delivery") {
                    $("#overlay").unbind("click");
                    RegionalSettingCountryForAddress();
                    document.getElementById("Savebtn_Invoice").style.display = "none";
                    document.getElementById("Savebtn_Delivery").style.display = "block";
                    document.getElementById("Updatebtn_Invoice").style.display = "none";
                    document.getElementById("Updatebtn_Delivery").style.display = "none";

                    document.getElementById("ctl00_ContentPlaceHolder1_CopyInvtoDelAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_CopyDeltoInvAddress").style.display = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_Chk_copy_to_invaddress").checked = false;

                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddressLabelBilling").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_telephone_billing").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_fax_billing").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing1").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing2").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing3").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing4").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing5").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddressLabelBilling").focus();

                    RegionalSettingCountryForAddress();
                }
                else {
                    $("#overlay").click(function (e) {
                        HideDialog();
                    });
                }
            }
            else if (type == "edit") {
                document.getElementById("div_NewAddress").style.display = "none";
                document.getElementById("div_EditAddress").style.display = "block";
                if (modal == "Invoice") {
                    $("#overlay").unbind("click");
                    document.getElementById("Savebtn_Invoice").style.display = "none";
                    document.getElementById("Savebtn_Delivery").style.display = "none";
                    document.getElementById("Updatebtn_Invoice").style.display = "block";
                    document.getElementById("Updatebtn_Delivery").style.display = "none";

                    document.getElementById("ctl00_ContentPlaceHolder1_CopyDeltoInvAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_CopyInvtoDelAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Chk_copy_to_deladdress").checked = false;
                }
                else if (modal == "Delivery") {
                    $("#overlay").unbind("click");
                    document.getElementById("Savebtn_Invoice").style.display = "none";
                    document.getElementById("Savebtn_Delivery").style.display = "none";
                    document.getElementById("Updatebtn_Invoice").style.display = "none";
                    document.getElementById("Updatebtn_Delivery").style.display = "block";

                    document.getElementById("ctl00_ContentPlaceHolder1_CopyInvtoDelAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_CopyDeltoInvAddress").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Chk_copy_to_invaddress").checked = false;
                }
                else {
                    $("#overlay").click(function (e) {
                        HideDialog();
                    });
                }
            }



            if (type == "edit") {
                PageMethods.lnkEdit_Bill_Click_Service(modal, function (result) {

                    //alert(result.AddressLine1);

                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddressLabelBilling").value = result.AddressLabel;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_telephone_billing").value = result.phone;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_fax_billing").value = result.Fax;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing1").value = result.AddressLine1;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing2").value = result.AddressLine2;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing3").value = result.Address2;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing4").value = result.Address3;
                    document.getElementById("ctl00_ContentPlaceHolder1_txt_address_billing5").value = result.Address4;


                });
            }
        }

    </script>
    <%--<script>
            function ValidateReject() {
                var textBox = document.getElementById("<%=txtReason.ClientID %>");
                if (textBox.value != "") {
                    loadingimg('Div_Ok', 'divok_load')
                }
            }
        </script>--%>
    </div>

    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID%>';
        var PDFToURLPath = '<%=PDFToURLPath%>';
        function GetRadWindow() {
            var oWindow = null;
            oWindow = $find("<%=ImagePopWindow.ClientID %>");
            return oWindow;
        }

    </script>
    <telerik:RadWindow ID="ImagePopWindow" Title="Image Preview" Height="420px" Width="835px" ResizeMode="NoResize" BackColor="Gray" runat="server" Modal="True" ReloadOnShow="true">
        <ContentTemplate>
            <div class="divTitle">
                <img style="float: right; cursor: pointer" title="Download" src="images/downloadImage.png" onclick="downloadImage_click();" />
            </div>

            <ul runat="server" class="slider div_imagePreview" id="div_imagePreview" style="overflow: hidden; background: #323639;"></ul>
            <div style="margin-top: 15px;">
                <input type="button" id="btn_previous" value="Previous" style="float: left" onclick="btnPrevoius_clicked();" />
                <input type="button" id="btn_next" value="Next" style="float: right" onclick="btnNext_clciked();" />
            </div>
        </ContentTemplate>
    </telerik:RadWindow>

</asp:Content>
