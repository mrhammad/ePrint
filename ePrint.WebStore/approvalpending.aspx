<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/masterPageDefault.master" CodeBehind="approvalpending.aspx.cs" Inherits="ePrint.WebStore.approvalpending" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%#strSitepath%>js/Account.js?VN='<%#VersionNumber%>'"></script>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radGridUser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridUser" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="AddressPending">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AddressPending" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridUser" LoadingPanelID="RadAjaxLoadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="AddressPending" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadTabStrip1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1">
    </telerik:RadAjaxLoadingPanel>
    <style type="text/css">
        .RadGrid_Default
        {
            background: #fff;
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default
        {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        .RadTabStrip_Default .rtsLI, .RadTabStrip_Default .rtsLink
        {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
    </style>
    <div id="div_approval" runat="server">
        <div id="approvalpending_tab_div">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Default" MultiPageID="RadMultiPage2"
                SelectedIndex="0" CssClass="tabStrip" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="Registration Pending">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Edit Profile Pending">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div id="accountInfoMain_div">
            <div id="accountInfo_background">
                <div id="accountInfoContent_div">
                    <div class="accountInfoContent_innerdiv">
                        <div class="accountclearleft20">
                            <div id="DivregistrationMGS" runat="server" clientidmode="Static">
                                <img src="images/StoreImages/Ok-icon.png" id="ImgRegisApproved" visible="false" runat="server" />
                                <asp:Label ID="LblRegistrationMSG" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="paddingTop5">
                                <div id="DivUserApproved" runat="server" clientidmode="Static">
                                    <img src="images/StoreImages/Ok-icon.png" id="ImgProfileApproved" visible="false"
                                        runat="server" />
                                    <asp:Label ID="LblUSermessage" Visible="false" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div id="div_radGridUser" align="center">
                            <telerik:RadGrid ID="radGridUser" runat="server" Width="99.7%" CssClass="AddBorders"
                                EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False" AllowFilteringByColumn="false"
                                AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                HeaderStyle-Font-Bold="true" AllowPaging="true" GridLines="None" HeaderStyle-BorderWidth="0"
                                ItemStyle-BorderWidth="0" LoadingPanelID="RadAjaxLoadingPanel" OnItemDataBound="radGridUser_OnItemDataBound"
                                HeaderStyle-Height="20px">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="First Name" HeaderStyle-Width="8%" UniqueName="FirstName"
                                            ItemStyle-Width="10%" DataField="FirstName" ItemStyle-VerticalAlign="Top" SortExpression="FirstName"
                                            FilterControlWidth="60%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Last Name" HeaderStyle-Width="8%" SortExpression="LastName"
                                            ItemStyle-Width="6%" DataField="LastName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Email" HeaderStyle-Width="8%" SortExpression="Email"
                                            ItemStyle-Width="6%" DataField="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="1%" SortExpression="Action"
                                            ItemStyle-Width="1%" DataField="Action" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div id="div_ApprovalAction">
                                                    <div class="floatLeft accountclearleft20">
                                                        <asp:LinkButton ID="btnAction" runat="server" CssClass="ApprovedBtn" Height="15px"
                                                            Width="15px" ToolTip="Click here to Approve" OnCommand="btnAction_Click" CommandArgument='<%#Eval("StoreUserID")%>'
                                                            CommandName='<%#Eval("ApproverID")%>' CausesValidation="false"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                        <div id="div_AddressPending" align="center">
                            <telerik:RadGrid ID="AddressPending" runat="server" Width="99.7%" CssClass="AddBorders"
                                EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False" AllowFilteringByColumn="false"
                                AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                HeaderStyle-Font-Bold="true" AllowPaging="true" GridLines="None" HeaderStyle-BorderWidth="0"
                                ItemStyle-BorderWidth="0" LoadingPanelID="RadAjaxLoadingPanel1" Visible="false"
                                OnItemDataBound="AddressPending_OnItemDataBound" HeaderStyle-Height="20px" OnNeedDataSource="AddressPending_OnNeedDataSource">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="First Name" HeaderStyle-Width="8%" UniqueName="FirstName"
                                            ItemStyle-Width="10%" DataField="FirstName" ItemStyle-VerticalAlign="Top" SortExpression="FirstName"
                                            FilterControlWidth="60%" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblFirst" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Last Name" HeaderStyle-Width="8%" SortExpression="LastName"
                                            ItemStyle-Width="6%" DataField="LastName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblLast" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Email" HeaderStyle-Width="8%" SortExpression="Email"
                                            ItemStyle-Width="6%" DataField="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Approver Email" HeaderStyle-Width="8%" SortExpression="DesignatedApprovedEmail"
                                            ItemStyle-Width="6%" DataField="DesignatedApprovedEmail" ItemStyle-VerticalAlign="Top"
                                            ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true"
                                            ItemStyle-Height="21px" CurrentFilterFunction="Contains">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblDesignatedApprovedEmail" runat="server" Text='<%#Eval("DesignatedApprovedEmail") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Address Label" HeaderStyle-Width="8%" SortExpression="AddressLabel"
                                            ItemStyle-Width="6%" DataField="AddressLabel" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div class="paddingTop2">
                                                    <asp:Label ID="lblAddressLabel" runat="server" Text='<%#Eval("AddressLabel") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="1%" SortExpression="Action"
                                            ItemStyle-Width="1%" DataField="Action" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                            ItemStyle-Height="21px">
                                            <ItemTemplate>
                                                <div id="div_ApprovalAction">
                                                    <div class="floatLeft accountclearleft20">
                                                        <asp:LinkButton ID="btnAddressApproved" runat="server" CssClass="ApprovedBtn" Height="15px"
                                                            Width="15px" ToolTip="Click here to Approve" OnCommand="btnAddressApproved_Click"
                                                            CommandArgument='<%#Eval("StoreUserID")%>' CommandName='<%#Eval("ApproverID")%>'
                                                            CausesValidation="false"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tb_IncorrectLink"
        runat="server" visible="false">
        <tr>
            <td>
                <br />
                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 100%;
                    margin-top: 15%; margin-bottom: 20%;">
                    <tr>
                        <td align="center">
                            <div class="messageboxSessionLogoutNew" style="padding-top: 10px; padding-bottom: 10px;">
                                <div>
                                    <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:LinkButton ID="lnkGoBack" runat="server" CssClass="button" OnClick="lnkGoBack_Click"></asp:LinkButton>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

