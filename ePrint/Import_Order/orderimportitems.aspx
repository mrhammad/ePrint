<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderimportitems.aspx.cs" Inherits="ePrint.Import_Order.orderimportitems" masterpagefile="~/Templates/SettingsEstore.Master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #ctl00_ContentPlaceHolder1_header_spn_change
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function checkerror() {
            document.getElementById("ctl00_ContentPlaceHolder1_chkError").style.cursor = "pointer";
        }
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rad_orderimport_items">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rad_orderimport_items" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkError">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rad_orderimport_items" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <div style="float: left;" id="pnldetails" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div class="mis_header_panel" style="padding-right: 10px;">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div class="box" style="margin-top: 4px;">
                        <div style="display: inline; float: left; margin-left: 2px;">
                            <div id="div_btn_cancel" style="float: left;">
                                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="button" OnClick="btnCancel_OnClick">
                                </asp:Button>
                            </div>
                            <div id="div_btn_cancelprocess" class="button" align="center" style="display: none;
                                height: 14px; width: 28px;">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="DivOrder1" runat="server" class="floatLeft clearBottom DisplayBlock">
                            <div style="float: left; margin-left: 8px; margin-top: 5px;">
                                <asp:LinkButton ID="btnclrFilters" OnClick="lnkOrderFilters_Click" Style="text-decoration: underline;
                                    cursor: pointer" runat="server"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                            </div>
                            <div style="float: left; padding-left: 10px; margin-top: 5px;">
                                <asp:LinkButton ID="btnNewExport" OnClick="btnExportOrder_OnClick" Style="text-decoration: underline;
                                    cursor: pointer" runat="server" Text="Export"><%=objLanguage.GetLanguageConversion("Export_To_Excel")%></asp:LinkButton>
                            </div>
                            <div style="float: left; padding-left: 10px; margin-top: 5px;">
                                <asp:CheckBox ID="chkError" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="chkError_OnClick" />
                            </div>
                            <div style="float: left; padding-left: 1px; margin-top: 5px;">
                                <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("To_display_error_messages_only")%></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div style="margin: 10px 10px 10px 3px; float: left;">
                        <asp:UpdatePanel ID="UpdatePanel2" ChildrenAsTriggers="false" UpdateMode="Conditional"
                            runat="server">
                            <ContentTemplate>
                                <telerik:RadGrid ID="rad_orderimport_items" runat="server" AutoGenerateColumns="false"
                                    AllowAutomaticUpdates="false" Width="55%" BorderWidth="0" GridLines="None" HeaderStyle-Font-Bold="true"
                                    PageSize="50" AllowAutomaticInserts="false" AllowPaging="true" PagerStyle-AlwaysVisible="true"
                                    AllowAutomaticDeletes="false" OnNeedDataSource="rad_orderimport_items_OnNeedDataSource"
                                    OnItemDataBound="rad_orderimport_items_RowDataBound" OnPageSizeChanged="rad_orderimport_items_PageSizeChanged"
                                    OnPageIndexChanged="rad_orderimport_items_PageIndexChanged">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false" Position="Bottom"></PagerStyle>
                                    <MasterTableView AllowFilteringByColumn="true" AllowCustomSorting="true">
                                        <CommandItemTemplate>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="ErrorMessage">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Error_Message" runat="server"><%=objLanguage.GetLanguageConversion("Error_Message")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server" Text='<%#Eval("ErrorMessage")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Date" AutoPostBackOnFilter="true">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDate" runat="server"><%=objLanguage.GetLanguageConversion("Date")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblItemDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date", "{0}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                                DataField="Base">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lblBase" runat="server"><%=objLanguage.GetLanguageConversion("Base")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblBaseItem" runat="server" Text='<%#Eval("Base")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="GST" AutoPostBackOnFilter="true">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lblGST" runat="server"><%=objLanguage.GetLanguageConversion("GST")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblGSTItem" runat="server" Text='<%#Eval("GST")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Postage">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lblPostage" runat="server"><%=objLanguage.GetLanguageConversion("Postage")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblPostageItem" runat="server" Text='<%#Eval("Postage")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                                DataField="Total Amount">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Total_Amount" runat="server"><%=objLanguage.GetLanguageConversion("Total_Amount")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Total Amount")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                                DataField="First Name">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_First_Name" runat="server"><%=objLanguage.GetLanguageConversion("First_Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("First Name")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Last Name">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Last_Name" runat="server"><%=objLanguage.GetLanguageConversion("Last_Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Last Name")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account Address 1">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_Address1" runat="server"><%=objLanguage.GetLanguageConversion("Account_Address_1")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountAddress1" runat="server" Text='<%#Eval("Account Address 1")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account Address 2">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_Address2" runat="server"><%=objLanguage.GetLanguageConversion("Account_Address_2")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountAddress2" runat="server" Text='<%#Eval("Account Address 2")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account Suburb">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_Suburb" runat="server"><%=objLanguage.GetLanguageConversion("Account_Suburb")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountSuburb" runat="server" Text='<%#Eval("Account Suburb")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account State">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_State" runat="server"><%=objLanguage.GetLanguageConversion("Account_State")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountState" runat="server" Text='<%#Eval("Account State")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account Postcode">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_Postcode" runat="server"><%=objLanguage.GetLanguageConversion("Account_Postcode")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountPostcode" runat="server" Text='<%#Eval("Account Postcode")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Account Country">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Account_Country" runat="server"><%=objLanguage.GetLanguageConversion("Account_Country")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblAccountCountry" runat="server" Text='<%#Eval("Account Country")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Address 1">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Address1" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address_1")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryAddress1" runat="server" Text='<%#Eval("Delivery Address 1")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Address 2">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Address2" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address_2")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryAddress2" runat="server" Text='<%#Eval("Delivery Address 2")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Suburb">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Suburb" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Suburb")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliverySuburb" runat="server" Text='<%#Eval("Delivery Suburb")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery State">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_State" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_State")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryState" runat="server" Text='<%#Eval("Delivery State")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Postcode">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Postcode" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Postcode")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryPostcode" runat="server" Text='<%#Eval("Delivery Postcode")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Country">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Country" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Country")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryCountry" runat="server" Text='<%#Eval("Delivery Country")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Method">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Method" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Method")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryMethod" runat="server" Text='<%#Eval("Delivery Method")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Delivery Notes">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Delivery_Notes" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Notes")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDeliveryNotes" runat="server" Text='<%#Eval("Delivery Notes")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Mobile">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Mobile" runat="server"><%=objLanguage.GetLanguageConversion("Mobile")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Email Address">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Email" runat="server"><%=objLanguage.GetLanguageConversion("Email_Address")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblEmailAddress" runat="server" Text='<%#Eval("Email Address")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="SKU">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_SKU" runat="server"><%=objLanguage.GetLanguageConversion("SKU")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblSKU" runat="server" Text='<%#Eval("SKU")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Product Title">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Product_Title" runat="server"><%=objLanguage.GetLanguageConversion("Product_Title")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblProductTitle" runat="server" Text='<%#Eval("Product Title")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Size">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Size" runat="server"><%=objLanguage.GetLanguageConversion("Size")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Units">
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Units" runat="server"><%=objLanguage.GetLanguageConversion("Units")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Customer Comments">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Customer_Comments" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Comments")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblCustomerComments" runat="server" Text='<%#Eval("Customer Comments")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="true" AutoPostBackOnFilter="true" DataField="Internal Comments">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lbl_Internal_Comments" runat="server"><%=objLanguage.GetLanguageConversion("Internal_Comments")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblInternalComments" runat="server" Text='<%#Eval("Internal Comments")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

