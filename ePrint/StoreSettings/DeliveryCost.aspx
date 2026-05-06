<%@ page title="Delivery Cost" Language="C#" masterpagefile="~/Templates/SettingsEstore.master" AutoEventWireup="true" CodeBehind="DeliveryCost.aspx.cs" Inherits="ePrint.StoreSettings.DeliveryCost" enableviewstatemac="false" enableEventValidation="false" theme="Theme1"%>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
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
        .hiddenCheckBox {
            display: none;
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
                                <%--  --%>
                                <div style="padding: 10px;">
                        <table style="vertical-align: middle">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkEnable" runat="server" />
                                </td>
                                <td>
                                    <span>Enable Delivery Costs</span>
                                </td>
                            </tr>
                        </table>
                            <table style="vertical-align: middle">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkShipEngine" runat="server" />
                                    </td>
                                    <td>
                                        <span>Enable Ship-Engine</span><br />
                                        <span id="msg" class="smallerfontgrey" style="clear: both;">Ship Engine requires an API key to work.Please contact support@hexicomsoftware.com
                                        if you haven't set up the API.
                                        </span>
                                    </td></tr>
                            </table>
                            <table style="vertical-align: middle">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkAllowpickup" runat="server" />
                                    </td>
                                    <td>
                                        <span>Allow Pick-up</span>
                                    </td></tr>
                            </table>
                            </div>
                                <div class="box">
                                <div style="float: left; margin-bottom: 1px">
                                    <div id="div_btn1" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" OnClick="btnShipImport_OnClick" EnableEmbeddedSkins="false" ID="Button1"
                                            runat="server" Text="Import Ship-Engine Carriers"  ></asp:Button>
                                    </div>
                                    <div id="div_btn1Process" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <%--<img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />--%>
                                    </div>
                                </div>
                            <%--<div style="float: left; margin-bottom: 1px; margin-left: 15px">
                                    <div id="div_btn2" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="Button2"
                                            runat="server" Text="Import From Other Store"  ></asp:Button>
                                    </div>
                                    <div id="div_btn2Process" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                    </div>
                                </div>--%>
                                    <div style="float: left; margin-bottom: 1px; margin-left: 15px">
                                    <div id="div_btn13" style="display: block">
                                        <input type="button" value="Import From Other Store" class="button" style="width: 180px" onclick="javascript: SelectOtherStore(0,'order'); return false;" />
                                    </div>
                                    <div id="div_btn13Process" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <%--<img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />--%>
                                    </div>
                                </div>
                            </div>
                        <br/><br />
                                <div style="width:98.6%"><hr class="hrcolor"></div>
                                <div id="div_btnSavOrdr" style="display: block; margin-left: -3px">
                                    <asp:Button ID="btnSavOrdr" runat="server" Text="Save Order" CssClass="button" CausesValidation="false"
                                        OnClick="btnUpDown_OnClick" />
                                </div>
                                <div id="div_btnSavOrdrprocess" class="button" align="center" style="height: 14px;
                                    width: 65px; display: none">
                                    <img src="../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div align="left" style="width: 80%;">
                                <div id="div_popupAction" style="margin: 57px 0px 0px 9px;" onmouseover="show();"
                                    onmouseout="hide(); ">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="width: 100%;">
                                                    <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                        <asp:LinkButton ID="btnDel" runat="server" Text="Delete Selected" OnClick="btn_DeleteStatusOrders_OnClick"
                                                            OnClientClick="javascript:return CallDelete();" Style="text-decoration: none;"
                                                            ForeColor="#333333" Font-Size="11px"></asp:LinkButton></div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <telerik:RadGrid ID="GridOrders" runat="server" AutoGenerateColumns="False" PageSize="50"
                                    AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AllowPaging="True"
                                    BorderWidth="0" Width="70%" PagerStyle-AlwaysVisible="true" GroupingEnabled="False"
                                    AllowSorting="True" ShowGroupPanel="True" GridLines="None" AllowFilteringByColumn="false"
                                    OnItemDataBound="GridOrders_OnRowDataBound" OnRowDrop="grdPendingOrders_RowDrop"
                                    OnInsertCommand="GridOrders_InsertCommand" OnNeedDataSource="grdPendingOrders_NeedDataSource"
                                    OnUpdateCommand="GridOrders_UpdateCommand" OnItemCommand="GridOrders_OnItemCommand">
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView DataKeyNames="DeliveryCostID" ToolTip="Drag and drop the rows to reorder"
                                        CommandItemDisplay="Top">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:LinkButton ID="btnAdd" Text='<%#objLanguage.GetLanguageConversion("Add_New_Record")%>'
                                                            CommandName="InitInsert" runat="server" Font-Underline="True"></asp:LinkButton>
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
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" ItemStyle-Width="20px"
                                                ItemStyle-Wrap="false">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderStyle HorizontalAlign="left" Width="20px" Wrap="false" />
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input id="Checkbox1" runat="server" onclick="checkAll_new(this);" name="checkAll" type="checkbox" />
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
                                                            value='<%# DataBinder.Eval(Container, "DataItem.DeliveryCostID", "{0}") %>' />
                                                    </div>
                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                    <asp:HiddenField ID="hdn_deliverycostid" runat="server" Value='<%#Eval("DeliveryCostID")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="200px"
                                                SortExpression="Status">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderTemplate>
                                                    <div style="height: 15px; width: 100%">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Name" Visible="true"><%=objLanguage.GetLanguageConversion("Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="height: 15px; width: 100%; cursor: pointer;">
                                                        <asp:Label ID="lblDeliveryCostID" runat="server" Text='<%#Eval("DeliveryCostID")%>' Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="lnkStatus" runat="server" CausesValidation="false" Text='<%#Eval("DeliveryCostTitle")%>'
                                                            ToolTip='<%#Eval("DeliveryCostTitle") %>' Visible="false"></asp:LinkButton>
                                                        <%#Eval("DeliveryCostTitle")%>
                                                    </div>
                                                    <%-- </a>--%>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("DeliveryCostID")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Height="20px" Wrap="False" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblUserFrndName" runat="server" Text="User Friendly Name"><%=objLanguage.GetLanguageConversion("Type")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="height: 15px; cursor: pointer;">
                                                        <asp:Label ID="lblUserFrndNameID" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                    </div>
                                                    <%-- </a>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <HeaderTemplate>
                                                    <center>
                                                        <asp:Label ID="lbl_Orders" runat="server" Text="Default" Visible="false"><%=objLanguage.GetLanguageConversion("Default")%></asp:Label></center>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="float: none; overflow: hidden; cursor: pointer;">
                                                        <center>
                                                            <asp:Image ID="img_orders" runat="server" />
                                                            <asp:HiddenField ID="hdn_Orders" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                        </center>
                                                    </div>
                                                    <%-- </a>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbl_default_text" runat="server" Text="In Use" Visible="false"><%=objLanguage.GetLanguageConversion("In_Use")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <center>
                                                            <asp:Image ID="img_default_value" runat="server" /></center>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridDragDropColumn DragImageUrl="~/images/drag_drop.gif" HeaderText="Action"
                                                ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" Visible="false">
                                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </telerik:GridDragDropColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="11%" HeaderText="Action" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-Width="11%">
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <div align="center" style="background-image: url('../images/drag_drop.gif'); width: 15px;
                                                        height: 15px; background-repeat: no-repeat; position: static;">
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                                <ItemStyle HorizontalAlign="Center" Width="11%" />
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                            <FormTableItemStyle Wrap="false" />
                                            <FormCaptionStyle CssClass="EditFormHeader" />
                                            <FormMainTableStyle GridLines="None" CellPadding="0" BackColor="White" Width="100%" />
                                            <FormTableStyle CellPadding="0" Height="10px" BackColor="White" />
                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                            <EditColumn UniqueName="EditColumn">
                                            </EditColumn>
                                            <FormTemplate>
                                                <table border="0" cellpadding="0" width="100%" style="margin: 5px">
                                                    <tr>
                                                        <td valign="top" style="width: 140px;">
                                                            <div class="bglabel" style="width: 135px; margin: 0px">
                                                                <asp:HiddenField ID="hdn_deliverycostid" runat="server" Value='<%#Eval("DeliveryCostID")%>' />
                                                                <asp:Label ID="lblOdrStsTtl" runat="server" Text="Order Status Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Option_Name")%></asp:Label>
                                                                <span style="color: Red">*</span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; width: 100%;">
                                                                <telerik:RadTextBox ID="txtOdrStsTtl" Width="150px" runat="server" CssClass="textboxnew"
                                                                    onblur="getstring();" Text='<%#Eval("DeliveryCostTitle")%>' MaxLength="100">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="rfvTxtStatus" runat="server" ControlToValidate="txtOdrStsTtl"
                                                                    ErrorMessage="Please Enter Orders Status Title" CssClass="RFV_Message" Style="width: auto;
                                                                    padding-left: 4px; padding-right: 4px; float: right;margin-right: 184px;" ForeColor=""><%=objLanguage.GetLanguageConversion("Please_Enter_Delivery_Option_Name")%></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="width: 140px;">
                                                            <div class="bglabel" style="width: 135px; margin: 0px">
                                                                <asp:Label ID="lblUsrFrndlyName" runat="server" Text="User Friendly Name" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Formula")%></asp:Label>
                                                                <span style="color: Red">*</span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; width: 100%;">
                                                                <telerik:RadTextBox ID="txtUsrFrndlyName" runat="server" Width="150px" CssClass="textboxnew"
                                                                    Text='<%#Eval("Type")%>' MaxLength="100">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="txtUsrFrndlyName" ID="rfvUsrFrndName"
                                                                    runat="server" ErrorMessage="Please Enter User Friendly Name" CssClass="RFV_Message"
                                                                    Style="width: auto; padding-left: 4px; padding-right: 4px; float: right;margin-right: 179px;" ForeColor=""><%=objLanguage.GetLanguageConversion("Please_Enter_Delivery_Cost_Formula")%></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="width: 140px;">
                                                            <div class="bglabel" style="width: 135px; margin: 0px; display:none">
                                                                <asp:Label ID="lblOdrStsDisp" runat="server" Text="Default" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default") %></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="Chk_OrdersDefault" runat="server" CssClass="hiddenCheckBox" Checked='<%# (DataBinder.Eval(Container.DataItem,"IsDefault") is DBNull ?false:Eval("IsDefault")) %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; padding-right: 5px">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCanceleStoreOrdrs"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                    CausesValidation="false">
                                                                </telerik:RadButton>
                                                            </div>
                                                            <div style="float: left;">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSaveeStoreOrdrs"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </div>
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
                            </div>
                            <div align="left" style="padding-top: 5px">
                            </div>
                             <div id="div_tags" style="display:block" runat="server">
                                 <span class="graytext">
                                     <%=objLanguage.GetLanguageConversion("Formula_Tags")%>
                                     : [$ProductBasePrice$], &ltquantity&gt , [$OrderedHeight$], [$OrderedWidth$], [$OrderedArea$], [$MultipleOf$] </span>

                             </div>
                            <br />
                            <div class="box">
                                <div style="float: left; margin-bottom: 10px">
                                    <div id="div_btn3" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" OnClick="btnCancel_OnClick" EnableEmbeddedSkins="false" ID="Button3"
                                            runat="server" Text="Cancel"  ></asp:Button>
                                    </div>
                                    <div id="div_btn3Process" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <%--<img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />--%>
                                    </div>
                                </div>
                            <div style="float: left; margin-bottom: 10px; margin-left: 15px">
                                    <div id="div_btn4" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" OnClick="btnSave_OnClick" EnableEmbeddedSkins="false" ID="Button4"
                                            runat="server" Text="Save"  ></asp:Button>
                                    </div>
                                    <div id="div_btn4Process" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <%--<img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />--%>
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <script type="text/javascript">

        function getstring() {

            var txtOdrStsTtl = document.getElementById('ctl00_ContentPlaceHolder1_GridOrders_ctl00_ctl02_ctl03_txtOdrStsTtl_text');
            var txtUsrFrndlyName = document.getElementById('ctl00_ContentPlaceHolder1_GridOrders_ctl00_ctl02_ctl03_txtUsrFrndlyName_text');

            if (txtUsrFrndlyName.value == "") {
                txtUsrFrndlyName.focus();
                txtUsrFrndlyName.value = txtOdrStsTtl.value;

            }

        }
        
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_Button2').click(function () {
                // ...
                return false;
            });
        });
        var strSitePath = "<%=strSitepath %>";
        var AccID = "<%=AccountID %>";
        var CompanyID = "<%=CompanyID %>";
        function SelectOtherStore(InvoiceID, page) {
            debugger
            var Rad_Attachment = window.radopen(strSitePath + "common/common_popup.aspx?pagetype=general&type=select_otherstore&companyid=" + CompanyID + "&invoiceid=" + AccID + "&page=" + page + "&pg=" + page + "");
            //SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad_Attachment.setSize(800, 300);
            Rad_Attachment.center();
        }

    </script>
    <script type="text/javascript">
        function Rowclick(sender, eventArgs) {
            var divTags = document.getElementById("ctl00_ContentPlaceHolder1_div_tags");
            divTags.style.display = "block";
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
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
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <script type="text/javascript">
        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=GridOrders.ClientID %>").getElementsByTagName("input");
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
    </script>
    <script type="text/javascript">
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        function show() {
            img_actionsHide.style.display = "block";
            img_actionsShow.style.display = "none";

            div_chk.style.border = "inset 1px";
            div_chk.style.background = "#CBCBCB";

            div_popupAction.style.display = "block";
        }

        function hide() {
            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";

            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";

            div_popupAction.style.display = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

