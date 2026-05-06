<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Campaign.aspx.cs" Inherits="ePrint.WebStore.Campaign" masterpagefile="~/templates/MasterPageDefault.master" %>

<%@ Register Src="~/usercontrol/invoice_del_Info.ascx" TagName="AddressInfo" TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/default.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Slide/jsPopup.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <style type="text/css">
        .RadGrid_Default .rgCommandCell
        {
            border-style: none;
            outline: none;
        }
        
        .RadGrid_Default
        {
            background: #fff; /* font-family: Helvetica,sans-serif;
            font-size: 13px; */
            border: 0;
            border-bottom: 1px solid gray;
            outline: none;
        }
        
        
        div.AddBorders .rgAltRow td, div.AddBorders .rgRow td
        {
            border-width: 0px 0px 1px 0px;
        }
        
        div.AddBorders .rgHeader
        {
            border-width: 1px 0px 0px 0px;
            border-style: solid;
            border-color: #808080;
            border-bottom: 1px #808080;
        }
        
        .RadGrid .rgPagerLabel, .RadGrid_Default .rgInfoPart strong
        {
            color: #808080;
        }
        
        .rgStatus
        {
            display: none;
        }
        
        .RadGrid_Default td.rgPagerCell
        {
            border-width: 1px 0px 1px 0px;
        }
        
        .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default
        {
            font: inherit;
        }
        .imagePadding
        {
            padding-top: 5px;
        }
        .address
        {
            color: Gray;
            font-size: 12px;
            font-weight: bold;
        }
        .addressGridwidth
        {
            width: 493px;
            height: 300px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var DateFormat = '<%=DateFormat %>';    
    </script>
    <script src="js/swazz_calendar_store.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"
        EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
              <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radgrdCampaign">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radgrdCampaign" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="Label1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radgrdCampaign" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdgrd_ship_choose">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grd_Search_ship">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="imgSearch_Ship">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_SaveAddress">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdgrd_ship_choose" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="Campaign" align="center">
        <div align="left" id="div_CampaignMain">
            <div align="left" id="Campaign_background">
                <div id="CampaignContent_div">
                    <div id="Campaign_div" runat="server">
                        <div id="middle_div">
                            <div class="RadGridcampaign">
                                <div id="div_message" class="msg-success_campaign">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div style="width: 98%; padding: 0px 0px 0px 0px; margin: 0px auto; text-align: left;
                                    margin: 5px auto;">
                                    <div id="div_popupAction" class="div_popupAction_campaign" onmouseover="show();"
                                        onmouseout="hide();">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div>
                                                        <div class="divDropdownlist_campaign">
                                                            <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="" CommandName="Delete"
                                                                Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CallDelete();"
                                                                CausesValidation="false" OnClick="btn_MangeClient_OnClick"><%=objLanguage.GetLanguageConversion("Delete_Selected")%></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" ChildrenAsTriggers="false" UpdateMode="Conditional"
                                        runat="server">
                                        <ContentTemplate>
                                            <telerik:RadGrid ID="radgrdCampaign" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                                ShowStatusBar="true" AllowAutomaticInserts="false" PageSize="50" AllowAutomaticUpdates="false"
                                                AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SessionDataSource1"
                                                PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true" AllowSorting="true"
                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                GroupingSettings-CaseSensitive="false" HeaderStyle-BackColor="White" CellPadding="0"
                                                CellSpacing="0" ShowFooter="false" AlternatingItemStyle-BackColor="White" HeaderStyle-ForeColor="#525252"
                                                Skin="Default" CssClass="AddBorders radgrid_marginleft" HeaderStyle-Height="20px"
                                                HeaderStyle-Font-Size="13px" OnUpdateCommand="radgrdCampaign_UpdateCommand" OnInsertCommand="radgrdCampaign_InsertCommand"
                                                OnItemCommand="radgrdCampaign_ItemCommand" OnItemDataBound="radgrdCampaign_OnRowDataBound"
                                                OnNeedDataSource="radgrdCampaign_OnNeedDataSource" AllowFilteringByColumn="false"
                                                HeaderStyle-BorderStyle="Double">
                                                <AlternatingItemStyle BackColor="White" />
                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                <MasterTableView Width="100%" CommandItemSettings-RefreshText="" CommandItemSettings-ShowRefreshButton="false"
                                                    CommandItemDisplay="Top" DataKeyNames="ManageID" DataSourceID="SessionDataSource1"
                                                    AllowFilteringByColumn="false" HorizontalAlign="NotSet" AutoGenerateColumns="false"
                                                    EnableNoRecordsTemplate="true" InsertItemPageIndexAction="ShowItemOnFirstPage"
                                                    CssClass="MyDesign_GridMasterTable" HeaderStyle-BorderStyle="Double">
                                                    <NoRecordsTemplate>
                                                        <div style="margin-left: 7px; color: Gray; font-weight: bold;">
                                                            <%=objLanguage.GetLanguageConversion("No_records_to_display")%>
                                                        </div>
                                                    </NoRecordsTemplate>
                                                    <CommandItemTemplate>
                                                        <table class="rgCommandTable" style="width: 100%; border-style: none !important;">
                                                            <tr>
                                                                <td align="left" style="background-color: White  !important;">
                                                                    <div style="margin: -10px 0px 10px 0px">
                                                                        <asp:LinkButton ID="btnAdd" Text="" CommandName="InitInsert" runat="server" Style="text-decoration: underline;
                                                                            cursor: pointer; color: rgb(0, 126, 213); padding-left: 0px; text-align: left;
                                                                            font-weight: bold;"><%=objLanguage.GetLanguageConversion("Add_new_record")%></asp:LinkButton>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="background-color: White  !important;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn UniqueName="Checkbox" AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" Width="5%" HorizontalAlign="Left" />
                                                            <ItemStyle Width="5%" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="floatLeft">
                                                                    <div class="floatLeft DisplayNone">
                                                                        <input id="Checkbox1" type="checkbox" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                    </div>
                                                                    <div id="div_chk" class="div_grid_chk">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <div class="floatLeft">
                                                                                        <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Panel ID="pnl_chkImage" runat="server">
                                                                                        <div class="divimg_campaign">
                                                                                            <img src="images/StoreImages/ArrowDown.gif" id="img_actionsShow" class="divimg_arrowdown"
                                                                                                onclick="show();" alt='' />
                                                                                            <img src="images/StoreImages/ArrowUP.GIF" id="img_actionsHide" class="divimg_arrowup"
                                                                                                onclick="hide();" alt='' />
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="clear: both;">
                                                                    </div>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div class="chkbox_margin" style="padding-top: 5px;">
                                                                    <input type="checkbox" runat="server" id="chkId" name="chkId" onclick="CheckChanged();"
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.ManageID", "{0}") %>' />
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="Eventcode" DataField="Eventcode" AutoPostBackOnFilter="true"
                                                            AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblEventCode" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Event_Code")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lblEventCodeValue" runat="server" Text='<%#Eval("Eventcode")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="EventName" DataField="EventName" AutoPostBackOnFilter="true"
                                                            AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblEvent" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Event_Name")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lblEventTitle" runat="server" CssClass="imagePadding" Text='<%#Eval("Eventname")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="Ordernumber" DataField="Ordernumber"
                                                            AutoPostBackOnFilter="true" AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblOrdNo" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Order_Number")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lbl_OrdNo" runat="server" CssClass="imagePadding" Text='<%#Eval("OrderNumber")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="Venue" DataField="Venue" AutoPostBackOnFilter="true"
                                                            AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblVenue" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Venue")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lblVenueTitle" runat="server" CssClass="imagePadding" Text='<%#Eval("Venue")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="DeliveryAddress" DataField="DeliveryAddress"
                                                            AutoPostBackOnFilter="true" AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" Wrap="false" />
                                                            <ItemStyle Wrap="true" HorizontalAlign="Left" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lbl_DeliveryAddress" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="height: 15px; width: 100px; cursor: pointer; overflow: hidden" class="imagePadding">
                                                                    <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="imagePadding" Text='<%#Eval("DeliveryAddress")%>'
                                                                        ToolTip='<%#Eval("DeliveryAddress")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="DeliveryDate" SortExpression="DeliveryDate"
                                                            CurrentFilterFunction="EqualTo" AllowFiltering="false" DataField="DeliveryDate"
                                                            AutoPostBackOnFilter="true">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Center" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblDeliveryDate" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Delivery_Required_By")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="DeliveryDate_view" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DeliveryDate", "{0}") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="EventStartdate" SortExpression="EventStartdate"
                                                            CurrentFilterFunction="EqualTo" AllowFiltering="false" DataField="EventStartdate"
                                                            AutoPostBackOnFilter="true">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Center" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblEventstartdate" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("Start_Date")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lblstartdate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EventStartdate", "{0}") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="EventEnddate" SortExpression="EventEnddate"
                                                            CurrentFilterFunction="EqualTo" AllowFiltering="false" DataField="EventEnddate"
                                                            AutoPostBackOnFilter="true">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Center" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lblEventenddate" runat="server" Text="" Visible="true"><%=objLanguage.GetLanguageConversion("End_Date")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="width: 100%; cursor: pointer;" class="imagePadding">
                                                                    <asp:Label ID="lblenddate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EventEnddate", "{0}") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="false" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lbl_default_text" runat="server" Text="In Use" Visible="true"><%=objLanguage.GetLanguageConversion("In_Use")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <center>
                                                                        <asp:Image ID="img_InUse" runat="server" CssClass="imagePadding" />
                                                                        <asp:HiddenField ID="hdnMangeID" runat="server" Value='<%#Eval("ManageID")%>' />
                                                                    </center>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="false" Height="22px" />
                                                            <HeaderTemplate>
                                                                <div class="grd_headermargin">
                                                                    <asp:Label ID="lbl_Archive_text" runat="server" Text="In Use" Visible="true"><%=objLanguage.GetLanguageConversion("Archive")%></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <center>
                                                                        <asp:Image ID="img_Archive" runat="server" CssClass="imagePadding" />
                                                                    </center>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="false" Height="22px" />
                                                            <HeaderTemplate>
                                                                <center>
                                                                    <div class="grd_headermargin">
                                                                        <asp:Label ID="Label1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label>
                                                                    </div>
                                                                </center>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImgButtonErase" ImageUrl="images/StoreImages/erase.png" CssClass="imagePadding"
                                                                            CommandName="Delete" CommandArgument='<%#Eval("ManageID") %>' OnClientClick="javascript:return ImgButtonErase_ClientClick();"
                                                                            Text="Delete" UniqueName="DeleteColumn" runat="server" OnCommand="lnkDelete_onclick"
                                                                            ToolTip="Delete"></asp:ImageButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings ColumnNumber="2" EditFormType="Template" CaptionDataField="TaxName">
                                                        <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                        <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                        <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                            Width="100%" />
                                                        <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                        <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                        <EditColumn UniqueName="EditColumn">
                                                        </EditColumn>
                                                        <FormTemplate>
                                                            <table border="0" cellpadding="2" width="100%" style="margin: 10px;">
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblevent" runat="server" Text="Order Status Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Name")%></asp:Label>
                                                                            <span style="color: Red">*</span>
                                                                        </div>
                                                                        <asp:HiddenField ID="hdn_ManID" runat="server" Value='<%#Eval("ManageID")%>' />
                                                                    </td>
                                                                    <td class="divtd_padding">
                                                                        <asp:TextBox ID="txtEventName" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("Eventname")%>'
                                                                            MaxLength="100" CssClass="textboxnew" Style="float: left">
                                                                        </asp:TextBox>
                                                                        <div style="float: left; padding-left: 10px">
                                                                            <asp:Label ID="lblrecordexists" runat="server" Style="display: none; color: Red;"></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <%--<%=objLanguage.GetLanguageConversion("Campaign_already_exists")%>--%>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvTxtStatus" runat="server" ControlToValidate="txtEventName"
                                                                        CssClass="errorMsg" ErrorMessage="Please Enter Event name"><%=objLanguage.GetLanguageConversion("Please_Enter_Event_Name")%></asp:RequiredFieldValidator>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblEventcode" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Code")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td class="divtd_padding">
                                                                        <asp:TextBox ID="txteventcode" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("Eventcode")%>'
                                                                            MaxLength="100" CssClass="textboxnew">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblOrdNo" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Order_Number")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOrdNo" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("OrderNumber")%>'
                                                                            CssClass="textboxnew">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblVenue" runat="server" Text="Venue" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Venue")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtVenue" TextMode="MultiLine" Height="50px" Width="200px" Columns="23"
                                                                            Text='<%#Eval("Venue")%>' runat="server" SkinID="textPad" CssClass="textboxnew">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width divtd_padding">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblAddress" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                                                            <div style="float: right;">
                                                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton7" runat="server" CausesValidation="False"
                                                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:ShowDialog4(true);AllocateID(this.id);return false;">
                                                                                </asp:ImageButton>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                    <td style="vertical-align: middle; padding-bottom: 5px; padding-top: 5px">
                                                                        <div style="float: left; max-width: 50%; overflow: hidden;">
                                                                            <asp:Label ID="lblDeliveryaddress" runat="server" Text='<%#Eval("DeliveryAddress")%>'
                                                                                ToolTip='<%#Eval("DeliveryAddress")%>' CssClass="address "></asp:Label>
                                                                            <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value='<%# Bind("DeliveryAddressID")%>' />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblDeliverydate" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Required_By")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDeliveryDate" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("DeliveryDate")%>'
                                                                            CssClass="textboxnew" Style="float: left">
                                                                        </asp:TextBox>
                                                                        <div style="float: left; padding-left: 10px">
                                                                            <span id="span_DeliveryDate_validator" class="mandatoryField DisplayNone paddingTop5"
                                                                                style="color: Red">
                                                                                <%=objLanguage.GetLanguageConversion("Please_enter_the_valid_date")%></span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblEventStartdate" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Start_Date")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEventStartdate" runat="server" Width="200px" SkinID="textPad"
                                                                            Text='<%#Eval("EventStartdate")%>' CssClass="textboxnew" Style="float: left">
                                                                        </asp:TextBox>
                                                                        <div style="float: left; padding-left: 10px">
                                                                            <span id="span_StartDate_validator" class="mandatoryField DisplayNone paddingTop5"
                                                                                style="color: Red">
                                                                                <%=objLanguage.GetLanguageConversion("Please_enter_the_valid_date")%></span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblEventEnddate" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_End_Date")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEventEnddate" Text='<%#Eval("EventEnddate")%>' runat="server"
                                                                            Width="200px" SkinID="" CssClass="textboxnew" Style="float: left">
                                                                        </asp:TextBox>
                                                                        <div style="float: left; padding-left: 10px">
                                                                            <span id="span_EndDate_validator" class="mandatoryField DisplayNone paddingTop5"
                                                                                style="color: Red">
                                                                                <%=objLanguage.GetLanguageConversion("Please_enter_the_valid_date")%></span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="divtd_width">
                                                                        <div class="bglabelFormtemplate">
                                                                            <asp:Label ID="lblArchive" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Archive")%></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkArchive" Text='<%#Eval("IsArchive")%>' runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btncancel" runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>'
                                                                            CommandName="Cancel" CausesValidation="false" CssClass="x-btnpro Grey main" />
                                                                        <span style="padding-left: 5px"></span>
                                                                        <asp:Button ID="btnsave" runat="server" CssClass="x-btnpro Grey main" Style="display: none;"
                                                                            Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' />
                                                                        <asp:Button ID="btnsave1" runat="server" CssClass="x-btnpro Grey main" OnClientClick="javascript:Campaign_Check(this.id);return false;"
                                                                            Text='<%#objLanguage.GetLanguageConversion("Save")%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FormTemplate>
                                                        <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                                <ClientSettings EnableRowHoverStyle="true">
                                                    <KeyboardNavigationSettings AllowSubmitOnEnter="true" />
                                                    <ClientEvents OnRowClick="Rowclick" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                                    </telerik:RadWindowManager>
                                    <br />
                                    <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.LoginNew.LoginBasePage"
                                        SelectMethod="b2b_Campaign_Select">
                                        <SelectParameters>
                                            <asp:SessionParameter DefaultValue="0" Name="AccountID" SessionField="AccountID"
                                                Type="Int64" />
                                            <asp:SessionParameter DefaultValue="0" Name="CompanyID" SessionField="CompanyID"
                                                Type="Int64" />
                                            <asp:SessionParameter DefaultValue="0" Name="StoreUserID" SessionField="StoreUserID"
                                                Type="Int64" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="false" UpdateMode="Conditional"
        runat="server">
        <ContentTemplate>
            <div>
                <div id="Output_ship_Choose">
                </div>
                <div id="Overlay_ship_Choose" class="web_dialog_overlay">
                </div>
                <div id="dialog_ship_Choose" class="web_dialog" style="width: 530px">
                    <table class="popuptable" id="tblAddressList" style="width: 530px">
                        <tr>
                            <td style="width: 210px">
                                <div class="web_dialog_title">
                                    <asp:Label ID="lblAddressBook1" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td class="align_right" align="right" style="width: 300px">
                                <a href="javascript:void(0);" id="btnClose_ship_Choose" title="Close" class="floatRight">
                                    <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" onclick="javascript:HideDialog4();" /></a>
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
                            <td class="paddingleft-12px paddingBottom5 paddingTop5">
                                <span runat="server" id="spn_ListAllAdddress1" class="Color007ED3_Blue"></span>
                            </td>
                            <td class=" paddingBottom5 paddingTop5" style="padding-left: 190px">
                                <asp:LinkButton ID="lnkbtnAddNewAddress" CssClass="Color007ED3_Blue" runat="server"
                                    Font-Underline="true" OnClientClick="javascript:AddnewDialogue();"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="paddingleft-12px">
                                <telerik:RadGrid ID="rdgrd_ship_choose" runat="server" CssClass="addressGridwidth"
                                    AutoGenerateColumns="false" AllowSorting="false" AllowFilteringByColumn="false"
                                    AllowPaging="true" OnItemDataBound="rdgrd_ship_choose_OnItemDataBound" OnNeedDataSource="rdgrd_ship_choose_OnNeedDataSource"
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
                                                        CssClass="gridlinkbutton" ToolTip='<%#Bind("AddressNew")%>' OnCommand="lnkAddress_Select_Click"
                                                        CausesValidation="false" CommandArgument='<%#Eval("AddressID")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table align="center" class="popuptable_Address" id="tblAddressAdd" style="display: none;
                            width: 530px">
                            <tr>
                                <td class="web_dialog_title_Address">
                                    <div id="div_NewAddress">
                                        <b>
                                            <asp:Label ID="lblNewAddress" runat="server"></asp:Label></b>
                                    </div>
                                </td>
                                <td class="align_right" align="right">
                                    <a href="javascript:void(0);" id="btnClose_bill" title="Close" class="floatRight">
                                        <img alt="" src="images/storeimages/close2.png" class="btnClose_Img" onclick="javascript:HideDialog4();" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddress_Label" runat="server" Style=""></asp:Label></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <div>
                                        <asp:TextBox ID="txtaddressLabelBilling" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                                        <span class="Example-Style">&nbsp;<asp:Label ID="lnlExample_Note" runat="server"></asp:Label>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight" style="white-space: nowrap;">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddressBill1" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillAdd1_UC" runat="server" class="mandatoryField">
                        *</asp:Label></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <div>
                                        <asp:TextBox ID="txt_address_billing1" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                                        <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                                            ID="Required_Address1" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing1"
                                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddressBill2" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillAdd2_UC" runat="server" class="mandatoryField">
                        *</asp:Label></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <div>
                                        <asp:TextBox ID="txt_address_billing2" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                                        <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                                            ID="Required_Address2" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing2"
                                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddressBill3" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillAdd3_UC" runat="server" class="mandatoryField">
                        *</asp:Label></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <div>
                                        <asp:TextBox ID="txt_address_billing3" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                                        <span class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                                            ID="Required_Address3" runat="server" ValidationGroup="Checkout" ControlToValidate="txt_address_billing3"
                                            Enabled="false" Display="None" Text="This
                        is a required field."></asp:RequiredFieldValidator></span></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddressBill4" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillAdd4_UC" runat="server" class="mandatoryField">
                        *</asp:Label></div>
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
                                    <div style="height: 25px">
                                        <asp:Label ID="lblAddressBill5" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillAdd5_UC" runat="server" class="mandatoryField">
                        *</asp:Label></div>
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
                                    <div style="height: 25px">
                                        <asp:Label ID="lblCountry" runat="server"></asp:Label><span class="mandatoryField">
                                            *</span></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="width-dropdownlist">
                                    </asp:DropDownList>
                                    <span id="sdf" runat="server" class="mandatoryField Validationfont">&nbsp;&nbsp;<asp:RequiredFieldValidator
                                        ID="Required_Country" runat="server" ValidationGroup="Checkout" InitialValue="0"
                                        ControlToValidate="ddlCountry" Text="This is a required field."></asp:RequiredFieldValidator></span>
                                    <asp:HiddenField ID="hdnCountryID" runat="server" Value="0" />
                                </td>
                            </tr>
                            <tr>
                                <td class="leftCellNewAdd_table TextAlignRight">
                                    <div style="height: 25px">
                                        <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                        <asp:Label ID="lblBillPhone_UC" runat="server" class="mandatoryField"> *</asp:Label></div>
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
                                    <div style="height: 25px">
                                        <asp:Label ID="lblFax" runat="server"></asp:Label></div>
                                </td>
                                <td class="rightCellNewAdd_table">
                                    <asp:TextBox ID="txt_fax_billing" runat="server" CssClass="AddressDetails_Txtbx"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="margin-left: 160px; width: 100%">
                                        <asp:Button ID="btnBack_toList" runat="server" Text="Back to Address List" class="x-btnpro Grey main"
                                            ValidationGroup="Checkout" OnClientClick="javascript:ShowAddresslist();return false;">
                                        </asp:Button>
                                        <asp:Button ID="btn_SaveAddress" runat="server" Text="Save Address and Use" class="x-btnpro Grey main"
                                            ValidationGroup="Checkout" OnClick="btnSave_NewAddress_Click"></asp:Button>
                                        <%--<div id="div_btnsaveprocess12" class="x-btnpro Grey main" align="center" style="float: right;
                                        margin-right: 10px">
                                        <img src="images/radimg1.gif" class="trans2" alt="loading" border="0" />--%>
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
                <script type="text/javascript">
                    $(document).keypress(function (e) {
                        var keyCode = (window.event) ? e.which : e.keyCode;
                        //            if (keyCode && keyCode == 13) {
                        //                e.preventDefault();
                        //                return false;
                        //            }
                    });
                </script>
                <asp:HiddenField ID="hdnLabelID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" language="javascript">

        var frm = document.getElementById("<%=radgrdCampaign.ClientID %>").getElementsByTagName("input");
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var Chkrow = '<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>';
        var confirmation = '<%=objLanguage.GetLanguageConversion("Are_you_sure_you_want_to_delete_this_campaign")%>';
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        var div_message = document.getElementById("div_message");
        var lblMessage = document.getElementById("ctl00_ContentPlaceHolder1_lblmsg");
        var div_dialog_Ship_choose = document.getElementById("dialog_ship_Choose");
        var div_AddnewAddress_Dialog = document.getElementById("Add_NewAddress_dialog");
        var btnSave;
        var lblrecordexists;
        var span_StartDate_validator;
        var span_EndDate_validator;
        var span_DeliveryDate_validator;

        function Campaign_Check(id) {

            var ManageID = document.getElementById(id.replace('btnsave1', 'hdn_ManID')).value;
            btnSave = document.getElementById(id.replace('btnsave1', 'btnsave'));
            var EventName = document.getElementById(id.replace('btnsave1', 'txtEventName')).value;
            lblrecordexists = document.getElementById(id.replace('btnsave1', 'lblrecordexists'));
            var txtEventStartdate = document.getElementById(id.replace('btnsave1', 'txtEventStartdate'));
            var txtEventEnddate = document.getElementById(id.replace('btnsave1', 'txtEventEnddate'));
            var txtDeliveryDate = document.getElementById(id.replace('btnsave1', 'txtDeliveryDate'));
            var Please_Enter_Event_Name = '<%=objLanguage.GetLanguageConversion("Please_Enter_Event_Name")%>';
            var AccountID = '<%=AccountID %>';
            var CompanyID = '<%=CompanyID %>';
            //            if (Date.parse(txtEventStartdate) < Date.parse(txtEventEnddate)) {
            //                lbldatevalidator.style.display = "none";
            //            }
            //            else {

            //                lbldatevalidator.innerHTML = Please_enter_valid_end_date;
            //                lbldatevalidator.style.display = "block";
            //                return false;
            //            }

            span_StartDate_validator = document.getElementById(id.replace('btnsave1', 'span_StartDate_validator'));
            span_EndDate_validator = document.getElementById(id.replace('btnsave1', 'span_EndDate_validator'));
            span_DeliveryDate_validator = document.getElementById(id.replace('btnsave1', 'span_EndDate_validator'));

            if (txtDeliveryDate.value != "") {
                if (ValidateForm(txtDeliveryDate, 'span_DeliveryDate_validator', DateFormat) == false) {
                    span_DeliveryDate_validator.style.display = "block";
                }
            }
            if (txtEventStartdate.value != "") {

                if (ValidateForm(txtEventStartdate, 'span_StartDate_validator', DateFormat) == false) {
                    span_StartDate_validator.style.display = "block";
                }
            }
            if (txtEventEnddate.value != "") {
                if (ValidateForm(txtEventEnddate, 'span_EndDate_validator', DateFormat) == false) {
                    span_EndDate_validator.style.display = "block";
                }
            }


            if (EventName != '') {
                if (ManageID == '') {
                    ManageID = 0;
                }

                AutoFill.Campaign_Duplicate_Check(ManageID, AccountID, CompanyID, EventName, GetResult, onTimeout, onError);
            }
            else {
                lblrecordexists.innerHTML = Please_Enter_Event_Name;
                lblrecordexists.style.display = "block";
            }
        }

        function GetResult(result) {

            if (result) {
                btnSave.click();
            }
            else {
                var Campaign_already_exists = '<%=objLanguage.GetLanguageConversion("Campaign_already_exists")%>';
                lblrecordexists.innerHTML = Campaign_already_exists;
                lblrecordexists.style.display = "block";
            }
        }

        function onTimeout(request, context) { }
        function onError(objError) { }

        var hdnLabelID = document.getElementById("<%=hdnLabelID.ClientID %>");
        function AllocateID(id) {
            hdnLabelID.value = id;
            ShowAddresslist();
        }

        function Assign_Address_To_Label(AddressValue, Addressid) {
            var id = hdnLabelID.value;
            var lblDeliveryaddress = document.getElementById(id.replace("ImageButton7", "lblDeliveryaddress"));
            var hid_DeliveryAddressID = document.getElementById(id.replace("ImageButton7", "hid_DeliveryAddressID"));

            //lblDeliveryaddress.title = AddressValue;
            lblDeliveryaddress.innerHTML = AddressValue;
            lblDeliveryaddress.style.cursor = "pointer";

            hid_DeliveryAddressID.value = Addressid;
        }
        function AddnewDialogue() {
            document.getElementById("tblAddressAdd").style.display = "block";
            document.getElementById("tblAddressList").style.display = "none";
        }
        function ShowAddresslist() {
            document.getElementById("tblAddressAdd").style.display = "none";
            document.getElementById("tblAddressList").style.display = "block";
        }
    </script>
</asp:Content>

