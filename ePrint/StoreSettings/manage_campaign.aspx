<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_campaign.aspx.cs" Inherits="ePrint.StoreSettings.manage_campaign" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js\item\general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID %>';
        var DateFormat = '<%=DateFormat %>';
        var ClientID = '<%=ClientID %>';
        var pg = "campaign";
        var strSitepath = "<%=strSitepath %>";
    </script>
    <style type="text/css">
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -9px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-left: -12px;
        }
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }
        .RadGrid_Default
        {
            outline: none;
        }
        
        .element
        {
            margin-top: -12px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="hdnrecordtype" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="530" OnClientClose="RadWinClose"
            Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <div style="float: left;" id="pnldetails" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div class="mis_header_panel">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="margin-top: 5px;">
                        <div class="cellsSlider" style="float: left;">
                            <asp:CheckBox ID="Chkenablecamp" checked="true" runat="server" />
                            <%--   <input type="checkbox" id="Chkenablecamp" checked="false" onclick="javascript:ChkenablecampcheckCahnge();" />--%>
                        </div>
                        <div style="font-weight: bold; float: left; padding: 2px 0px 0px 0px; margin-left: 15px;">
                            <%=objLanguage.GetLanguageConversion("Enable_Campaign")%>
                        </div>
                    </div>
                    <div style="float: left; margin: -5px 0px 0px 10px;">
                        <div id="div_btnsave" style="display: block">
                            <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" OnClick="btn_Save_Click"
                                OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                        </div>
                        <div id="div_btnsaveprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 0.5px" class="loadingimg"
                                alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div class="only10px">
                        <div id="div_popupAction" style="margin: 57px 0px 0px 9px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="btnDel" runat="server" Text="Delete Selected" OnClick="btn_MangeClient_OnClick"
                                                    OnClientClick="javascript:return CallDelete();" Style="text-decoration: none;"
                                                    ForeColor="#333333" Font-Size="11px"></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div>
                        <telerik:RadGrid ID="grdmanagecampign" runat="server" AutoGenerateColumns="False"
                            BorderWidth="0" PageSize="50" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                            AllowPaging="True" Width="50%" PagerStyle-AlwaysVisible="true" GroupingEnabled="False"
                            AllowSorting="True" ShowGroupPanel="True" GridLines="None" AllowFilteringByColumn="true"
                            OnItemDataBound="grdmanagecampign_OnRowDataBound" OnInsertCommand="grdmanagecampign_InsertCommand"
                            OnItemCommand="grdmanagecampign_ItemCommand" OnNeedDataSource="grdmanagecampign_NeedDataSource"
                            OnUpdateCommand="grdmanagecampign_UpdateCommand">
                            <PagerStyle Mode="NextPrevAndNumeric" />
                            <MasterTableView DataKeyNames="ManageID" ToolTip="" CommandItemDisplay="Top">
                                <CommandItemTemplate>
                                    <table class="rgCommandTable" border="0" style="width: 100%;">
                                        <tr>
                                            <td align="left">
                                                <asp:LinkButton ID="btnAdd" Text='<%#objLanguage.GetLanguageConversion("Add_New_Record")%>'
                                                    OnClientClick="javascript:recordtype();" CommandName="InitInsert" runat="server"
                                                    Font-Underline="True"></asp:LinkButton>
                                            </td>
                                            <td align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" ItemStyle-Width="4%"
                                        AllowFiltering="false" ItemStyle-Wrap="false">
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderStyle HorizontalAlign="left" Width="4%" Wrap="false" />
                                        <HeaderTemplate>
                                            <div style="float: left">
                                                <div style="float: left; display: none;">
                                                    <input id="Checkbox1" runat="server" onclick="checkAll_new(this);" name="checkAll"
                                                        type="checkbox" />
                                                </div>
                                                <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                    -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                        <tr>
                                                            <td>
                                                                <div style="float: left">
                                                                    <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                        type="checkbox" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Panel ID="pnl_chkImage" runat="server">
                                                                    <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                        <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                            border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                        <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                            border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
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
                                            <div style="padding-left: 2px">
                                                <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                    value='<%# DataBinder.Eval(Container, "DataItem.ManageID", "{0}") %>' />
                                            </div>
                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                            <%-- <asp:HiddenField ID="hdn_statusid" runat="server" Value='<%#Eval("StatusID")%>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="Eventcode"
                                        AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lblEventcode_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Event_Code")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblEvent_code_Value" runat="server" Text='<%#Eval("Eventcode")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" AllowFiltering="true" SortExpression="Status"
                                        DataField="Eventname" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lblEvent_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Event_name")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblEventTitle_Value" runat="server" Text='<%#Eval("Eventname")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="OrderNumber"
                                        AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lblOrdNo_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Order_Number")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblOrderNo_Value" runat="server" Text='<%#Eval("OrderNumber")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="Venue" AllowFiltering="false"
                                        AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lblVenue_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Venue")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblVenue_Value" runat="server" Text='<%#Eval("Venue")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="DeliveryAddress"
                                        AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 120px">
                                                <asp:Label ID="lblDel_Address_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 120px; cursor: pointer; overflow: hidden">
                                                <asp:Label ID="lblDelAddress_Value" runat="server" Text='<%#Eval("DeliveryAddress")%>'
                                                    ToolTip='<%#Eval("DeliveryAddress")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="true" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="DeliveryDate"
                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="center" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lbldelDate_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Delivery_Required_By")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lbldel_Date_Value" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="EventStartDate"
                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="center" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lbl_EventStartDate_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("Start_Date")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblEventStartDate_Value" runat="server" Text='<%#Eval("EventStartDate")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                        CurrentFilterFunction="Contains" SortExpression="Status" DataField="EventEndDate"
                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="center" Wrap="false" />
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderTemplate>
                                            <div style="height: 15px; width: 100%">
                                                <asp:Label ID="lbl_EventEndDate_View" runat="server" Text="Status" Visible="true"><%=objLanguage.GetLanguageConversion("End_Date")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 15px; width: 100%; cursor: pointer;">
                                                <asp:Label ID="lblEventEndDate_Value" runat="server" Text='<%#Eval("EventEndDate")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Height="20px" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"
                                        AllowFiltering="false" ItemStyle-Wrap="false">
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lbl_default_text" runat="server" Text="In Use" Visible="true"><%=objLanguage.GetLanguageConversion("In_Use")%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="float: none; overflow: hidden; cursor: pointer;">
                                                <center>
                                                    <asp:Image ID="img_InUse" runat="server" />
                                                    <asp:HiddenField ID="hdnMangeID" runat="server" Value='<%#Eval("ManageID")%>' />
                                                </center>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"
                                        AllowFiltering="false" ItemStyle-Wrap="false">
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lbl_isArchive" runat="server" Text="In Use" Visible="true"><%=objLanguage.GetLanguageConversion("Archive")%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="float: none; overflow: hidden; cursor: pointer;">
                                                <center>
                                                    <asp:Image ID="img_isArchive" runat="server" />
                                                </center>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"
                                        AllowFiltering="false" ItemStyle-Wrap="false">
                                        <HeaderStyle Font-Bold="true" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAction" runat="server" Text="Action" Visible="true"><%=objLanguage.GetLanguageConversion("Action")%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                CommandArgument='<%#Eval("ManageID") %>' OnClientClick="javascript:return ImgButtonErase_ClientClick();"
                                                Text="Delete" UniqueName="DeleteColumn" runat="server" OnCommand="lnkDelete_onclick" ToolTip="Delete">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                    <FormTableItemStyle Wrap="false" />
                                    <FormCaptionStyle CssClass="EditFormHeader" />
                                    <FormMainTableStyle GridLines="None" CellPadding="3" CellSpacing="0" BackColor="White"
                                        Width="100%" />
                                    <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                    <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                    <EditColumn UniqueName="EditColumn">
                                    </EditColumn>
                                    <FormTemplate>
                                        <table border="0" cellpadding="1" width="100%" style="margin: 5px 0px 8px 0px;">
                                            <tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:HiddenField ID="hdn_ManID" runat="server" Value='<%#Eval("ManageID")%>' />
                                                        <asp:Label ID="lblevent" runat="server" Text="Order Status Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Name")%></asp:Label>
                                                        <span style="color: Red">*</span>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEventName" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("Eventname")%>'
                                                        MaxLength="100">
                                                    </asp:TextBox>
                                                    <%-- <asp:RequiredFieldValidator ID="rfvTxtStatus" runat="server" ControlToValidate="txtEventName"
                                                        ValidationGroup="v" ErrorMessage="Please Enter Event name"><%=objLanguage.GetLanguageConversion("Please_Enter_Event_name")%></asp:RequiredFieldValidator>--%>
                                                    <div id="spnreferror" style="display: none; width: auto;">
                                                        <div class="RFV_Message" style="width: auto">
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Event_name_Already_Exists")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div id="spnRqdStyleName" style="display: none; width: auto;">
                                                        <div class="RFV_Message" style="width: auto">
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Event_name")%></span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:Label ID="lblEventcode" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Code")%></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txteventcode" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("Eventcode")%>'
                                                        MaxLength="100">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
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
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:Label ID="lblVenue" runat="server" Text="Venue" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Venue")%></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVenue" TextMode="MultiLine" Height="50px" Width="200px" Columns="23"
                                                        Text='<%#Eval("Venue")%>' runat="server" SkinID="textPad" CssClass="textboxnew"
                                                        onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <tr>
                                                    <td class="campaigntd">
                                                        <div class="bglabelCampaign">
                                                            <asp:Label ID="lblDeliveryAddress" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                                            <div style="float: right;">
                                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton7" runat="server" CausesValidation="False"
                                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:more_Deladdress(this.id);return false;">
                                                                </asp:ImageButton>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="float: left; padding: 5 0 4 4px; width: 50%; max-width: 50%; overflow: hidden;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblDeliveryAddressValue" runat="server" Text='<%#Eval("DeliveryAddress")%>'
                                                                CssClass="graytext" Width="220px" Style="cursor: pointer;"></asp:Label>
                                                            <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value='<%# Bind("DeliveryAddressID")%>' />
                                                    </td>
                                                    </div>
                                                </tr>
                                                <tr>
                                                    <td class="campaigntd">
                                                        <div class="bglabelCampaign">
                                                            <asp:Label ID="lblDeliveryDate" runat="server" Text="Venue" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Required_By")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDeliveryDate" Width="200px" runat="server" SkinID="textPad" Text='<%#Eval("DeliveryDate")%>'
                                                            CssClass="textboxnew" Style="float: left">
                                                        </asp:TextBox>
                                                        <div style="float: left; padding-left: 5px">
                                                            <span id="span_DeliveryDate_validator" class="RFV_Message" style="float: left; padding-left: 4px;
                                                                padding-right: 4px; display: none; width: auto">
                                                                <%=objLanguage.GetLanguageConversion("Invalid_Date_Format")%></span></div>
                                                    </td>
                                                </tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:Label ID="lblEventStartdate" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_Start_Date")%></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEventStartdate" runat="server" Width="200px" SkinID="textPad"
                                                        Text='<%#Eval("EventStartdate")%>' CssClass="textboxnew" Style="float: left">
                                                    </asp:TextBox>
                                                    <div style="float: left; padding-left: 5px">
                                                        <span id="span_StartDate_validator" class="RFV_Message" style="float: left; padding-left: 4px;
                                                            padding-right: 4px; display: none; width: auto">
                                                            <%=objLanguage.GetLanguageConversion("Invalid_Date_Format")%></span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:Label ID="lblEventEnddate" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event_End_Date")%></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEventEnddate" Text='<%#Eval("EventEnddate")%>' runat="server"
                                                        Width="200px" SkinID="" CssClass="textboxnew" Style="float: left"></asp:TextBox>
                                                    <div style="float: left; padding-left: 5px">
                                                        <span id="span_EndDate_validator" class="RFV_Message" style="float: left; padding-left: 4px;
                                                            padding-right: 4px; width: auto; display: none">
                                                            <div id="datevalidator" style="display: none; width: auto;">
                                                                <div class="RFV_Message" style="width: auto">
                                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_End_Date")%>
                                                                    </span>
                                                                </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="campaigntd">
                                                    <div class="bglabelCampaign">
                                                        <asp:Label ID="lbl_Archive" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Archive")%></asp:Label>
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
                                                    <div style="float: left; padding-right: 5px">
                                                        <asp:Button ID="btnCanceleStoreOrdrs" runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>'
                                                            CssClass="button" CommandName="Cancel" CausesValidation="false"></asp:Button>
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:Button CssClass="button" ID="btnSaveCampaign" runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>'
                                                            OnClientClick="if (!validateCampaign(this)) {return false;}" CommandName='<%#(Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                        </asp:Button>
                                                    </div>
                                                    <span>
                                                        <asp:HiddenField ID="hdn_CampaignID" runat="server" Value='<%# Bind("ManageID")%>' />
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </FormTemplate>
                                </EditFormSettings>
                                <PagerStyle AlwaysVisible="True" />
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                <ClientEvents OnRowClick="Rowclick" />
                            </ClientSettings>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                        <asp:UpdatePanel ID="updpnl" UpdateMode="Always" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hdnrecordtype" runat="server" Value="" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
        <asp:HiddenField ID="hdnEventNames" runat="server" Value="" />
        <script type="text/javascript">
            function Rowclick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

        </script>
        <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
            language="javascript">
        </script>
        <script type="text/javascript">
            var span_StartDate_validator;
            var span_EndDate_validator;
            var span_DeliveryDate_validator;
            function CallDelete() {
                var ret = CheckOne();
                if (ret) {
                    CheckGrid();
                    var IDs = '';
                    var frm = document.getElementById("<%=grdmanagecampign.ClientID %>").getElementsByTagName("input");
                    var i = 1;
                    for (l = 0; l < frm.length; l++) {
                        if (frm[l].id.indexOf('Id') != -1) {
                            if (frm[l].checked) {
                                IDs = IDs + frm[l].value + ",";
                            }
                        }
                    }
                    document.getElementById("<%=hidGridCount.ClientID %>").value = IDs;
                    return true;
                }
                else {
                    return false;
                }
            }


            function ChkenablecampcheckCahnge() {
                var checkbox = document.getElementById("<%=Chkenablecamp.ClientID %>");
                if (checkbox.checked == true) {
                    document.getElementById("<%=btn_Save.ClientID %>").style.display = 'block';
                }
                else {
                    document.getElementById("<%=btn_Save.ClientID %>").style.display = 'none';

                }
            }


            function ImgButtonErase_ClientClick() {
                return window.confirm("Are you sure you want to delete this campaign?");
            }

            function recordtype() {
                document.getElementById("<%=hdnrecordtype.ClientID %>").value = 'addnew';
            }


            function validateCampaign(obj) {
                var Valid = true;
                var CampID = document.getElementById(obj.id.replace('btnSaveCampaign', 'hdn_CampaignID'));
                var txtEventName = document.getElementById(obj.id.replace('btnSaveCampaign', 'txtEventName'));
                var txtDeliveryDate = document.getElementById(obj.id.replace('btnSaveCampaign', 'txtDeliveryDate'));
                var txtEventStartdate = document.getElementById(obj.id.replace('btnSaveCampaign', 'txtEventStartdate'));
                var txtEventEnddate = document.getElementById(obj.id.replace('btnSaveCampaign', 'txtEventEnddate'));
                var hdnEventNames = document.getElementById("<%=hdnEventNames.ClientID %>");
                var action = document.getElementById("<%=hdnrecordtype.ClientID %>").value;
                var splitval = hdnEventNames.value.split(',');

                span_StartDate_validator = document.getElementById(obj.id.replace('btnSaveCampaign', 'span_StartDate_validator'));
                span_EndDate_validator = document.getElementById(obj.id.replace('btnSaveCampaign', 'span_EndDate_validator'));
                span_DeliveryDate_validator = document.getElementById(obj.id.replace('btnSaveCampaign', 'span_DeliveryDate_validator'));

                if (txtDeliveryDate.value != "") {
                    if (ValidateForm(txtDeliveryDate, 'span_DeliveryDate_validator', DateFormat) == false) {
                        return false;
                    }
                }
                if (txtEventStartdate.value != "") {

                    if (ValidateForm(txtEventStartdate, 'span_StartDate_validator', DateFormat) == false) {
                        return false;
                    }
                }
                if (txtEventEnddate.value != "") {
                    if (ValidateForm(txtEventEnddate, 'span_EndDate_validator', DateFormat) == false) {
                        return false;
                    }
                }


                //                if (Date.parse(txteventstartdate.value) > Date.parse(txteventenddate.value)) {
                //                    document.getElementById("datevalidator").style.display = "block";
                //                }
                //                else {
                //                    document.getElementById("datevalidator").style.display = "none";
                //                }
                if (txtEventName.value == "") {
                    document.getElementById("spnRqdStyleName").style.display = "block";
                    document.getElementById("spnreferror").style.display = "none";
                    txtEventName.focus();
                    Valid = false;
                }
                else {
                    for (var i = 0; i < splitval.length; i++) {
                        if (splitval[i].trim() != "") {
                            var Name_ID = splitval[i].trim().split('~');
                            var Name = Name_ID[0].trim();
                            var ID = Name_ID[1].trim();
                            if (action == 'addnew') {
                                if (Name.toLowerCase() == txtEventName.value.trim().toLowerCase()) {
                                    document.getElementById("spnreferror").style.display = "block";
                                    Valid = false;
                                    return false;
                                }
                            }
                            else {
                                if (ID != CampID.value) {
                                    if (Name.toLowerCase() == txtEventName.value.trim().toLowerCase()) {
                                        document.getElementById("spnreferror").style.display = "block";
                                        document.getElementById("spnRqdStyleName").style.display = "none";
                                        Valid = false;
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    return Valid;
                }
            }


        </script>
        <script type="text/javascript">

            function checkAll_new(checkAllBox) {
                var frm = document.forms[0];
                var ChkState = checkAllBox.checked;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
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

        </script>
    </div>
    <script language="javascript" type="text/javascript">
        function more_Deladdress(id) {
            //PopupCenter(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + ClientID + "&pg=" + pg, '700', '400');
            window.radopen("<%=strSitepath %>common/common_popup.aspx?type=deliveryaddress&mode=view&pg=" + pg + "&clientid=" + ClientID + "&controlid=" + id + "");
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
    </script>
    <script type="text/javascript" language="javascript">
        function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype, controlid) {

            for (var i = 0; i < values.length; i++) {
                values = values.replace('<br/>', '');
                i++;
            }

            var lblDeliveryAddressValue = document.getElementById(controlid.replace("ImageButton7", "lblDeliveryAddressValue"));
            var hid_DeliveryAddressID = document.getElementById(controlid.replace("ImageButton7", "hid_DeliveryAddressID"));

            lblDeliveryAddressValue.title = SpecialDecode(tooltip);
            lblDeliveryAddressValue.innerHTML = SpecialDecode(trim12(values));

            lblDeliveryAddressValue.style.cursor = "pointer";

            hid_DeliveryAddressID.value = id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

