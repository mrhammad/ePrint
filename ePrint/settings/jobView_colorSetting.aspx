<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="jobView_colorSetting.aspx.cs" Inherits="ePrint.settings.jobView_colorSetting" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }
        function paletteOpen() {

            palette = window.open("", "paletteWindow", "toolbar=0,location=0,menubar=0,scrollbars=0,resizable=0,width=300,height=200,top=300,left=500");
            palette.location.href = "<%=strSitepath %>" + "settings/color_picker.html";
            return false;
        }

        function imgbtnDelete_ClientClick() {
            return confirm("Delete this record?");
        }
    </script>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -10px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
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
    </style>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"></asp:Label><%--<%=colorformat%>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div align="left" style="width: 100%; margin-top: -8px;" class="mis_header_panel">
                <div id="">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="grdcolorSetting">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="grdcolorSetting" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadGrid_ProductDate">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid_ProductDate" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>

                         <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadGrid_CompletionDate">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid_CompletionDate" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
                    <div align="left" style="width: 100%; border: 0px solid red">
                        <div id="divAddnew" style="width: 60%; display: none; padding-top: 15px;" runat="server">
                            <table border="0" cellpadding="0px" cellspacing="0px" id="a" style="display: none;">
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=objLanguage.GetLanguageConversion("Delivery_Dates")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 150px; padding-left: 5px;">
                                            <asp:DropDownList ID="ddlDeliveryDate" runat="server" Width="150px">
                                                <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="divValidate" style="float: left; padding-left: 10px; width: 350px;">
                                            <span id="spn_ddlDelDate" style="display: none; width: 200px" class="error">Please select
                                                Delivery Date </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=objLanguage.GetLanguageConversion("Days")%>
                                        :&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 30px; padding-left: 5px;">
                                            <asp:TextBox runat="server" ID="tbDays" Width="28px"></asp:TextBox>
                                        </div>
                                        <div id="divDayValidate" style="padding-left: 10px; float: left; width: 280px;">
                                            <span id="spn_txtdays" style="display: none; width: 200px" class="error">Please enter
                                                # of Days</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=colorformat%>:&nbsp;
                                    </td>
                                    <td valign="top" align="left" style="padding-left: 5px;">
                                        <div id="divColorDisploay" style="height: 20px; width: 30px; border: solid 1px gray;
                                            float: left;">
                                        </div>
                                        <div style="float: left; padding: 3px 0px 2px 10px;">
                                            <asp:ImageButton ID="imgColor" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                OnClientClick="javascript:paletteOpen();return false" />
                                        </div>
                                        <asp:HiddenField ID="hiddenid" runat="server" Value="#F2F2F2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 15px;">
                                        <asp:HiddenField ID="hdnColorid1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridElapsed" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnDaysElapsed" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorElapsed" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridOnSameDay" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnNoOfDays" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorSameDay" runat="server" Value="0" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Div_Del">
                            <asp:CheckBox ID="Chk_DeliveryColor" runat="server" Text="Delivery Date" onclick="javascript:FindColor('Delivery');"
                                Font-Bold="true" />
                        </div>
                        <div style="width: 60%">
                        </div>
                        <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete Selected" OnClick="chkbtnDelete_OnClick"
                                                    Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CallDelete();"
                                                    CausesValidation="false"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_Grid" style="width: 900px;">
                            <asp:UpdatePanel ID="updatepnlgrdcolorSetting" ChildrenAsTriggers="false" UpdateMode="Conditional"
                                RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <telerik:RadGrid ID="grdcolorSetting" AutoGenerateColumns="false" runat="server"
                                        BorderWidth="0" OnInsertCommand="gridcolorsetting_insert" OnUpdateCommand="gridcolorsetting_update"
                                        OnItemDataBound="grdcolorSetting_OnItemDataBound" OnItemCommand="grdcolorSetting_OnItemCommand"
                                        ItemStyle-Heigh="2%" GridLines="None" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                                        PageSize="50" Width="50%" HeaderStyle-Font-Bold="true">
                                        <MasterTableView CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                                Font-Underline="True">
                                                    <%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <EditItemStyle></EditItemStyle>
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                    Width="100%" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn UniqueName="EditColumn">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="0px" cellspacing="0px" id="a" style="padding-top: 10px">
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=objLanguage.GetLanguageConversion("Delivery_Dates")%>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 150px; padding-left: 5px">
                                                                    <asp:DropDownList ID="ddlDeliveryDate" runat="server" Width="150px">
                                                                        <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <script type="text/javascript">
                                                                        registeredElements.push('<%# Container.FindControl("ddlDeliveryDate").ClientID %>');
                                                                    </script>
                                                                </div>
                                                                <div id="divValidate" style="float: left; padding-left: 10px; width: 350px;">
                                                                    <span id="spn_ddlDelDate" style="display: none; width: 200px" class="error">Please select
                                                                        Delivery Date </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=objLanguage.GetLanguageConversion("Days")%>&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 30px; padding-left: 5px;">
                                                                    <asp:TextBox runat="server" ID="tbDays" onkeypress="return onlyNos(event,this);"
                                                                        Width="28px" Text='<%# Bind("days") %>'></asp:TextBox>
                                                                </div>
                                                                <div id="divDayValidate" style="padding-left: 10px; float: left; width: 280px;">
                                                                    <span id="spn_txtdays" style="display: none; width: 200px" class="error">Please enter
                                                                        # of Days</span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=colorformat%>&nbsp;
                                                            </td>
                                                            <td valign="top" align="left" style="padding-left: 5px;">
                                                                <div id="divColorDisploay" runat="server" style="height: 20px; width: 30px; border: solid 1px gray;
                                                                    float: left;">
                                                                    <asp:HiddenField ID="hdndivColor" runat="server" Value="" />
                                                                </div>
                                                                <div style="float: left; padding: 3px 0px 2px 10px;">
                                                                    <asp:ImageButton ID="imgColor" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                                        OnClientClick="javascript:paletteOpen();setID(this.id);return false" />
                                                                    <asp:Label ID="lblIdIneditmode" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:HiddenField ID="hiddenid" runat="server" Value="#F2F2F2" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td style="padding: 5px 0px 5px 5px;">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                    CausesValidation="false">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                            </div>
                                                            <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left">
                                                                                <input id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
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
                                                            <input type="checkbox" runat="server" id="chkcolorId2" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.id", "{0}") %>'
                                                                onclick="CheckChanged();" />
                                                        </div>
                                                        <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Option" HeaderStyle-HorizontalAlign="Left"
                                                    UniqueName="Option" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Option") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="#">
                                                            <asp:Label ID="lbltxt" runat="server" Text='<%#Eval("options")%>' Width="100%"></asp:Label></a><%--Text='<%#Eval("new")%>'--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="color" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=colorformat%></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <a href="#">
                                                                <asp:Label ID="lnkeditcolor" runat="server" Width="100%">
                                                                    <asp:Label runat="server" ID="lblDisplayColor" Style="height: 5px; width: 30px; border: solid 1px black;"></asp:Label>
                                                                </asp:Label>
                                                            </a>
                                                        </center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:ImageButton ID="btndeletecolor" ImageUrl="~/Images/erase.png" CommandArgument='<%#Eval("id")%>'
                                                                ToolTip="Delete" runat="server" OnClick="btnDelete_OnClick" OnClientClick="javascript:return ImgButtonErase_ClientClick();">
                                                            </asp:ImageButton></center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                                    </telerik:RadGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:HiddenField ID="hidoptionddlbind" runat="server" />
                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                <script type="text/javascript">
                                    function RowDblClick(sender, eventArgs) {
                                        sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                    }
                                </script>
                            </telerik:RadCodeBlock>
                            <asp:HiddenField ID="hdnoption" runat="server" />
                            <asp:HiddenField ID="Hiddays" runat="server" />
                        </div>
                    </div>



                    <div align="left" style="width: 100%; border: 0px solid red">
                        <div id="div1" style="width: 60%; padding-top: 15px;" runat="server">
                            <table border="0" cellpadding="0px" cellspacing="0px" id="Table1" style="display: none;">
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=objLanguage.GetLanguageConversion("Production_Dates")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 150px; padding-left: 5px;">
                                            <asp:DropDownList ID="ddlProductionDate" runat="server" Width="150px">
                                                <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="div2" style="float: left; padding-left: 10px; width: 350px;">
                                            <span id="Span1" style="display: none; width: 200px" class="error">Please select Delivery
                                                Date </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=objLanguage.GetLanguageConversion("Days")%>
                                        :&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 30px; padding-left: 5px;">
                                            <asp:TextBox runat="server" ID="tbDays1" Width="28px"></asp:TextBox>
                                        </div>
                                        <div id="div3" style="padding-left: 10px; float: left; width: 280px;">
                                            <span id="Span2" style="display: none; width: 200px" class="error">Please enter # of
                                                Days</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=colorformat%>:&nbsp;
                                    </td>
                                    <td valign="top" align="left" style="padding-left: 5px;">
                                        <div id="divColorDisploay1" style="height: 20px; width: 30px; border: solid 1px gray;
                                            float: left;">
                                        </div>
                                        <div style="float: left; padding: 3px 0px 2px 10px;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                OnClientClick="javascript:paletteOpen();return false" />
                                        </div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="#F2F2F2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 15px;">
                                        <asp:HiddenField ID="hdnColorid2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridElapsed1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnDaysElapsed1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorElapsed1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridOnSameDay1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnNoOfDays1" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorSameDay1" runat="server" Value="0" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Div_Production" style="margin-top: 10px;">
                            <asp:CheckBox ID="Chk_ProductionColor1" runat="server" Text="Production Date" onclick="javascript:FindColor('Production');"
                                Font-Bold="true" />
                        </div>
                        <div style="width: 60%">
                        </div>
                        <div id="div_popupAction1" style="margin: 58px 0px 0px 9px;" onmouseover="show1();"
                            onmouseout="hide1(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete Selected" OnClick="chkbtnDelete_OnClick_prod"
                                                    Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CallDelete();"
                                                    CausesValidation="false"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div6" style="width: 900px;">
                            <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="false" UpdateMode="Conditional"
                                RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <telerik:RadGrid ID="RadGrid_ProductDate" AutoGenerateColumns="false" runat="server"
                                        BorderWidth="0" OnInsertCommand="gridcolorsetting_insert_prod" OnUpdateCommand="gridcolorsetting_update_prod"
                                        OnItemDataBound="grdcolorSetting_OnItemDataBound_prod" OnItemCommand="grdcolorSetting_OnItemCommand_prod"
                                        ItemStyle-Heigh="2%" GridLines="None" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                                        PageSize="50" Width="50%" HeaderStyle-Font-Bold="true">
                                        <MasterTableView CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                                Font-Underline="True">
                                                    <%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <EditItemStyle></EditItemStyle>
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                    Width="100%" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn UniqueName="EditColumn">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="0px" cellspacing="0px" id="a" style="padding-top: 10px">
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=objLanguage.GetLanguageConversion("Production_Dates")%>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 150px; padding-left: 5px">
                                                                    <asp:DropDownList ID="ddlProductionDate" runat="server" Width="150px">
                                                                        <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <script type="text/javascript">
                                                                        registeredElements.push('<%# Container.FindControl("ddlProductionDate").ClientID %>');
                                                                    </script>
                                                                </div>
                                                                <div id="divValidate" style="float: left; padding-left: 10px; width: 350px;">
                                                                    <span id="spn_ddlDelDate" style="display: none; width: 200px" class="error">Please select
                                                                        Delivery Date </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=objLanguage.GetLanguageConversion("Days")%>&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 30px; padding-left: 5px;">
                                                                    <asp:TextBox runat="server" ID="tbDays1" Width="28px" onkeypress="return onlyNos(event,this);"
                                                                        Text='<%# Bind("days") %>'></asp:TextBox>
                                                                </div>
                                                                <div id="divDayValidate" style="padding-left: 10px; float: left; width: 280px;">
                                                                    <span id="spn_txtdays" style="display: none; width: 200px" class="error">Please enter
                                                                        # of Days</span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=colorformat%>&nbsp;
                                                            </td>
                                                            <td valign="top" align="left" style="padding-left: 5px;">
                                                                <div id="divColorDisploay" runat="server" style="height: 20px; width: 30px; border: solid 1px gray;
                                                                    float: left;">
                                                                    <asp:HiddenField ID="hdndivColor" runat="server" Value="" />
                                                                </div>
                                                                <div style="float: left; padding: 3px 0px 2px 10px;">
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                                        OnClientClick="javascript:paletteOpen();setID_ProductDate(this.id);return false" />
                                                                    <asp:Label ID="lblIdIneditmode1" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:HiddenField ID="hiddenid" runat="server" Value="#F2F2F2" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td style="padding: 5px 0px 5px 5px;">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                    CausesValidation="false">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input id="Checkbox1" type="checkbox" runat="server" name="checkAll" onclick="CheckAll1(this);" />
                                                            </div>
                                                            <div id="div_chk1" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left">
                                                                                <input id="checkAll2" runat="server" name="checkAll" onclick="CheckAll1(this);" type="checkbox" />
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Panel ID="pnl_chkImage1" runat="server">
                                                                                <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow1" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show1();" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide1" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide1();" alt='' />
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
                                                            <input type="checkbox" runat="server" id="chkcolorId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.id", "{0}") %>'
                                                                onclick="CheckChanged();" />
                                                        </div>
                                                        <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%#Eval("id")%>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Option" HeaderStyle-HorizontalAlign="Left"
                                                    UniqueName="Option" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Option") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="#">
                                                            <asp:Label ID="lbltxt1" runat="server" Text='<%#Eval("options")%>' Width="100%"></asp:Label></a><%--Text='<%#Eval("new")%>'--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="color" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label ID="Label2" runat="server"></asp:Label><%=colorformat%></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <a href="#">
                                                                <asp:Label ID="lnkeditcolor1" runat="server" Width="100%">
                                                                    <asp:Label runat="server" ID="lblDisplayColor1" Style="height: 5px; width: 30px;
                                                                        border: solid 1px black;"></asp:Label>
                                                                </asp:Label>
                                                            </a>
                                                        </center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label ID="Label3" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:ImageButton ID="btndeletecolor" ImageUrl="~/Images/erase.png" CommandArgument='<%#Eval("id")%>'
                                                                ToolTip="Delete" runat="server" OnClick="btnDelete_OnClick_prod" OnClientClick="javascript:return ImgButtonErase_ClientClick();">
                                                            </asp:ImageButton></center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                                    </telerik:RadGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:HiddenField ID="hidoptionddlbind1" runat="server" />
                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                <script type="text/javascript">
                                    function RowDblClick(sender, eventArgs) {
                                        sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                    }
                                </script>
                            </telerik:RadCodeBlock>
                            <asp:HiddenField ID="HiddenField10" runat="server" />
                            <asp:HiddenField ID="HiddenField11" runat="server" />
                        </div>
                    </div>




                       <div align="left" style="width: 100%; border: 0px solid red">
                        <div id="divaddnew2" style="width: 60%;  padding-top: 15px;" runat="server">
                            <table border="0" cellpadding="0px" cellspacing="0px" id="a" style="display: none;">
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        Completion Date
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 150px; padding-left: 5px;">
                                            <asp:DropDownList ID="ddlCompletionDate" runat="server" Width="150px">
                                                <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="div2" style="float: left; padding-left: 10px; width: 350px;">
                                            <span id="Span1" style="display: none; width: 200px" class="error">Please select
                                                Completion Date </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=objLanguage.GetLanguageConversion("Days")%>
                                        :&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <div style="float: left; width: 30px; padding-left: 5px;">
                                            <asp:TextBox runat="server" ID="tbDays2" Width="28px"></asp:TextBox>
                                        </div>
                                        <div id="div3" style="padding-left: 10px; float: left; width: 280px;">
                                            <span id="spn_txtdays2" style="display: none; width: 200px" class="error">Please enter
                                                # of Days</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bglabel" style="width: 100px;">
                                        <%=colorformat%>:&nbsp;
                                    </td>
                                    <td valign="top" align="left" style="padding-left: 5px;">
                                        <div id="divColorDisploay" style="height: 20px; width: 30px; border: solid 1px gray;
                                            float: left;">
                                        </div>
                                        <div style="float: left; padding: 3px 0px 2px 10px;">
                                            <asp:ImageButton ID="ImageButton2" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                OnClientClick="javascript:paletteOpen();return false" />
                                        </div>
                                        <asp:HiddenField ID="HiddenField4" runat="server" Value="#F2F2F2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 15px;">
                                        <asp:HiddenField ID="hdnColorid3" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridElapsed2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnDaysElapsed2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorElapsed2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColoridOnSameDay2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnNoOfDays2" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnColorSameDay2" runat="server" Value="0" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Div_Completion">
                            <asp:CheckBox ID="Chk_CompletionColor1" runat="server" Text="Completion Date" onclick="javascript:FindColor('Completion');"
                                Font-Bold="true" />
                        </div>
                        <div style="width: 60%">
                        </div>
                        <div id="div_popupAction2" style="margin: 58px 0px 0px 9px;" onmouseover="show2();"
                            onmouseout="hide2(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="linkDelete" runat="server" Text="Delete Selected" OnClick="chkbtnDelete_OnClick_comp"
                                                    Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CallDelete2();"
                                                    CausesValidation="false"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div6" style="width: 900px;">
                            <asp:UpdatePanel ID="UpdatePanel2" ChildrenAsTriggers="false" UpdateMode="Conditional"
                                RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <telerik:RadGrid ID="RadGrid_CompletionDate" AutoGenerateColumns="false" runat="server"
                                        BorderWidth="0" OnInsertCommand="gridcolorsetting_insert_comp" OnUpdateCommand="gridcolorsetting_update_comp"
                                        OnItemDataBound="grdcolorSetting_OnItemDataBound_comp" OnItemCommand="grdcolorSetting_OnItemCommand_comp"
                                        ItemStyle-Heigh="2%" GridLines="None" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                                        PageSize="50" Width="50%" HeaderStyle-Font-Bold="true">
                                        <MasterTableView CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                                Font-Underline="True">
                                                    <%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <EditItemStyle></EditItemStyle>
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                    Width="100%" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn UniqueName="EditColumn">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="0px" cellspacing="0px" id="a" style="padding-top: 10px">
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                Completion Date
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 150px; padding-left: 5px">
                                                                    <asp:DropDownList ID="ddlCompletionDate" runat="server" Width="150px">
                                                                        <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Elapsed" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="On same day" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <script type="text/javascript">
                                                                        registeredElements.push('<%# Container.FindControl("ddlCompletionDate").ClientID %>');
                                                                    </script>
                                                                </div>
                                                                <div id="divValidate" style="float: left; padding-left: 10px; width: 350px;">
                                                                    <span id="spn_ddlCompDate" style="display: none; width: 200px" class="error">Please select
                                                                        Completion Date </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=objLanguage.GetLanguageConversion("Days")%>&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <div style="float: left; width: 30px; padding-left: 5px;">
                                                                    <asp:TextBox runat="server" ID="tbDays2" onkeypress="return onlyNos(event,this);"
                                                                        Width="28px" Text='<%# Bind("days") %>'></asp:TextBox>
                                                                </div>
                                                                <div id="divDayValidate" style="padding-left: 10px; float: left; width: 280px;">
                                                                    <span id="spn_txtdays2" style="display: none; width: 200px" class="error">Please enter
                                                                        # of Days</span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="bglabel" style="width: 100px;">
                                                                <%=colorformat%>&nbsp;
                                                            </td>
                                                            <td valign="top" align="left" style="padding-left: 5px;">
                                                                <div id="divColorDisploay" runat="server" style="height: 20px; width: 30px; border: solid 1px gray;
                                                                    float: left;">
                                                                    <asp:HiddenField ID="hdndivColor" runat="server" Value="" />
                                                                </div>
                                                                <div style="float: left; padding: 3px 0px 2px 10px;">
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="15px" Width="15px" ImageUrl="~/images/colorcube.gif"
                                                                        OnClientClick="javascript:paletteOpen();setID_CompletionDate(this.id);return false" />
                                                                    <asp:Label ID="lblIdIneditmode2" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:HiddenField ID="hiddenid" runat="server" Value="#F2F2F2" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td style="padding: 5px 0px 5px 5px;">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton11"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                    CausesValidation="false">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton22"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input type="Checkbox2" runat="server" name="checkAll" onclick="CheckAll2(this);" />
                                                            </div>
                                                            <div id="div_chk2" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left">
                                                                                <input id="checkAll2" runat="server" name="checkAll" onclick="CheckAll2(this);" type="checkbox" />
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Panel ID="pnl_chkImage2" runat="server">
                                                                                <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow2" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show2();" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide2" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide2();" alt='' />
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
                                                            <input type="checkbox" runat="server" id="chkcolorId2" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.id", "{0}") %>'
                                                                onclick="CheckChanged();" />
                                                        </div>
                                                        <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID2" runat="server" Text='<%#Eval("id")%>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Option" HeaderStyle-HorizontalAlign="Left"
                                                    UniqueName="Option" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Option") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="#">
                                                            <asp:Label ID="lbltxt2" runat="server" Text='<%#Eval("options")%>' Width="100%"></asp:Label></a><%--Text='<%#Eval("new")%>'--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="color" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=colorformat%></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <a href="#">
                                                                <asp:Label ID="lnkeditcolor2" runat="server" Width="100%">
                                                                    <asp:Label runat="server" ID="lblDisplayColor2" Style="height: 5px; width: 30px; border: solid 1px black;"></asp:Label>
                                                                </asp:Label>
                                                            </a>
                                                        </center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:ImageButton ID="btndeletecolor" ImageUrl="~/Images/erase.png" CommandArgument='<%#Eval("id")%>'
                                                                ToolTip="Delete" runat="server" OnClick="btnDelete_OnClick_comp" OnClientClick="javascript:return ImgButtonErase_ClientClick();">
                                                            </asp:ImageButton></center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                                    </telerik:RadGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:HiddenField ID="hidoptionddlbind2" runat="server" />
                            <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                <script type="text/javascript">
                                    function RowDblClick(sender, eventArgs) {
                                        sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                    }
                                </script>
                            </telerik:RadCodeBlock>
                            <asp:HiddenField ID="HiddenField13" runat="server" />
                            <asp:HiddenField ID="HiddenField14" runat="server" />
                        </div>
                    </div>











                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnIDPart" runat="server" Value="" />
    <script type="text/javascript">
        var hiddenid = document.getElementById("ctl00_ContentPlaceHolder1_hiddenid");
        var hdncoloridid = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid1");
        var tbDays = document.getElementById("ctl00_ContentPlaceHolder1_tbDays");
        var divColorDisploay = document.getElementById("ctl00_ContentPlaceHolder1_divColorDisploay");
        var hdnDaysElapsed = document.getElementById("ctl00_ContentPlaceHolder1_hdnDaysElapsed");
        var hdnColorElapsed = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorElapsed");
        var Elapsedhiddenid = document.getElementById("ctl00_ContentPlaceHolder1_hdnColoridElapsed");

        var hdnNoOfDays = document.getElementById("ctl00_ContentPlaceHolder1_hdnNoOfDays");
        var hdnColorSameDay = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorSameDay");
        var hdnColoridOnSameDay = document.getElementById("ctl00_ContentPlaceHolder1_hdnColoridOnSameDay");


        var ddlDeliveryDate = document.getElementById("ctl00_ContentPlaceHolder1_ddlDeliveryDate");


      

        function CheckAll(chk) {

            $('#<%=grdcolorSetting.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

        function CheckAll1(chk) {
            $('#<%=RadGrid_ProductDate.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

        function CheckAll2(chk) {
            $('#<%=RadGrid_CompletionDate.ClientID %>').find("input:checkbox").each(function () {
                 if (this != chk) {
                     this.checked = chk.checked;
                 }
             });
         }
        function CallDelete() {
            Elapsedhiddenid.value = "0";
            hdnColoridOnSameDay.value = "0";
            var ret = CheckOne();
            if (ret)
            { CheckGrid(); return true; }
            else
            { return false; }
        }

      
        function CheckOne() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete") %>');
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation") %>');
            }
        }


        function colorFieldFill(color) {
            var IDPart = document.getElementById("ctl00_ContentPlaceHolder1_hdnIDPart");
            var DivID = IDPart.value + "divColorDisploay";
            var hdnDivcolor = IDPart.value + "hdndivColor";
            document.getElementById(hdnDivcolor).value = color;
            document.getElementById(DivID).style.backgroundColor = color;
            var hid = document.getElementById("ctl00_ContentPlaceHolder1_hiddenid");
            hid.value = color;
        }

        function addnew(type, option, days, strcolor, colorid) {
            if (type == "add") {

                ddlDeliveryDate.selectedIndex = 0;
                tbDays.value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid1").value = "0";
            }
            else if (type == "edit") {
                if (option.toString().toLowerCase() == "before") {
                    ddlDeliveryDate.selectedIndex = 1;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = false;
                }
                else if (option.toString().toLowerCase() == "elapsed") {
                    ddlDeliveryDate.selectedIndex = 2;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = true;
                }
                else if (option.toString().toLowerCase() == "on same day") {
                    ddlDeliveryDate.selectedIndex = 3;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = true;
                }
                else {
                    ddlDeliveryDate.selectedIndex = 0;
                }
                tbDays.value = days;
                hiddenid.value = strcolor;
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid1").value = colorid
            }
            document.getElementById("ctl00_ContentPlaceHolder1_divAddnew").style.display = "block";
            document.getElementById("spn_txtdays").style.display = "none";
            document.getElementById("spn_ddlDelDate").style.display = "none";

        }

        var ddlCompletionDate = document.getElementById("ctl00_ContentPlaceHolder1_ddlCompletionDate");
        var hiddenid2 = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField4");
        var hdncoloridid2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid3");
        var tbDays2 = document.getElementById("ctl00_ContentPlaceHolder1_tbDays2");
        var divColorDisplay2 = document.getElementById("ctl00_ContentPlaceHolder1_divColorDisploay");
        var hdnDaysElapsed2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnDaysElapsed2");
        var hdnColorElapsed2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorElapsed2");
        var Elapsedhiddenid2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnColoridElapsed2");

        var hdnNoOfDays2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnNoOfDays2");
        var hdnColorSameDay2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnColorSameDay2");
        var hdnColoridOnSameDay2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnColoridOnSameDay2");

        function CallDelete2() {
            Elapsedhiddenid2.value = "0";
            hdnColoridOnSameDay2.value = "0";
            var ret = CheckOne();
            if (ret) { CheckGrid(); return true; }
            else { return false; }
        }
        function CheckOne() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete") %>');
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation") %>');
            }
        }

        function addnew2(type, option, days, strcolor, colorid) {
            if (type == "add") {

                ddlCompletionDate.selectedIndex = 0;
                tbDays2.value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid3").value = "0";
            }
            else if (type == "edit") {
                if (option.toString().toLowerCase() == "before") {
                    ddlCompletionDate.selectedIndex = 1;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = false;
                }
                else if (option.toString().toLowerCase() == "elapsed") {
                    ddlCompletionDate.selectedIndex = 2;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = true;
                }
                else if (option.toString().toLowerCase() == "on same day") {
                    ddlCompletionDate.selectedIndex = 3;
                    document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = true;
                }
                else {
                    ddlCompletionDate.selectedIndex = 0;
                }
                tbDays2.value = days;
                hiddenid2.value = strcolor;
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid3").value = colorid
            }
            document.getElementById("ctl00_ContentPlaceHolder1_divAddnew2").style.display = "block";
            document.getElementById("spn_txtdays2").style.display = "none";
            document.getElementById("spn_ddlCompDate").style.display = "none";

        }

        function CallCancel() {
            document.getElementById("ctl00_ContentPlaceHolder1_divAddnew").style.display = "none";
        }




        function OntextChanged() {
            var ddlDeliveryDate = document.getElementById("ctl00_ContentPlaceHolder1_ddlDeliveryDate");
            tbDays.value = "0";
            if (ddlDeliveryDate.options[ddlDeliveryDate.selectedIndex].value == "1") {
                tbDays.value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid1").value = "0";
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = false;
            }
            else if (ddlDeliveryDate.options[ddlDeliveryDate.selectedIndex].value == "2") {
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = true;
                if (Elapsedhiddenid.value != "0") {
                    if (window.confirm('Elapsed color is already exists, Are you sure, you want to Edit this Color?')) {
                        hdncoloridid.value = Elapsedhiddenid.value;
                        tbDays.value = hdnDaysElapsed.value;
                        //   divColorDisploay.style.backgroundColor = hdnColorElapsed.value;
                    }
                    else {
                        hdncoloridid.value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_divAddnew").style.display = "none";
                    }
                }
            }
            else if (ddlDeliveryDate.options[ddlDeliveryDate.selectedIndex].value == "3") {
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays").disabled = true;
                if (hdnColoridOnSameDay.value != "0") {
                    if (window.confirm('On same day color is already exists, Are you sure, you want to Edit this Color?')) {
                        hdncoloridid.value = hdnColoridOnSameDay.value;
                        tbDays.value = hdnNoOfDays.value;
                    }
                    else {
                        hdncoloridid.value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_divAddnew").style.display = "none";
                    }
                }
            }
        }


        function OntextChanged2() {
            var ddlCompletionDate = document.getElementById("ctl00_ContentPlaceHolder1_ddlCompletionDate");
            tbDays2.value = "0";
            if (ddlCompletionDate.options[ddlCompletionDate.selectedIndex].value == "1") {
                tbDays2.value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnColorid3").value = "0";
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = false;
            }
            else if (ddlCompletionDate.options[ddlCompletionDate.selectedIndex].value == "2") {
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = true;
                if (Elapsedhiddenid2.value != "0") {
                    if (window.confirm('Elapsed color is already exists, Are you sure, you want to Edit this Color?')) {
                        hdncoloridid3.value = Elapsedhiddenid2.value;
                        tbDays2.value = hdnDaysElapsed2.value;
                        //   divColorDisploay.style.backgroundColor = hdnColorElapsed.value;
                    }
                    else {
                        hdncoloridid3.value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_divAddnew2").style.display = "none";
                    }
                }
            }
            else if (ddlCompletionDate.options[ddlCompletionDate.selectedIndex].value == "3") {
                document.getElementById("ctl00_ContentPlaceHolder1_tbDays2").disabled = true;
                if (hdnColoridOnSameDay2.value != "0") {
                    if (window.confirm('On same day color is already exists, Are you sure, you want to Edit this Color?')) {
                        hdncoloridid3.value = hdnColoridOnSameDay2.value;
                        tbDays2.value = hdnNoOfDays2.value;
                    }
                    else {
                        hdncoloridid3.value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_divAddnew2").style.display = "none";
                    }
                }
            }
        }





        function ImgButtonErase_ClientClick() {
            if (confirm("Are you sure you want to delete this record?")) {

                Elapsedhiddenid.value = "0";
                hdnColoridOnSameDay.value = "0";
                return true;
            }
            else {
                return false;
            }
        }


        function ColorValidation() {
            var checkValid = false;

            if (ddlDeliveryDate.selectedIndex == 0) {
                document.getElementById("spn_ddlDelDate").style.display = "block";
                checkValid = true;
            }
            if (tbDays.value == "") {
                document.getElementById("spn_txtdays").style.display = "block";
                checkValid = true;
            }
            if (checkValid) {
                return false;
            }
            else {
                return true;
            }
        }

    </script>
    <script>
        function setID(id) {
            var idpart = id.replace("imgColor", "");
            document.getElementById("ctl00_ContentPlaceHolder1_hdnIDPart").value = idpart;

        }
        function setID_ProductDate(id) {
            var idpart = id.replace("ImageButton1", "");
            document.getElementById("ctl00_ContentPlaceHolder1_hdnIDPart").value = idpart;

        }
        function setID_CompletionDate(id) {
            var idpart = id.replace("ImageButton2", "");
            document.getElementById("ctl00_ContentPlaceHolder1_hdnIDPart").value = idpart;

        }
    </script>
    <script type="text/javascript">
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        function show() {
            img_actionsHide.style.display = "block";
            img_actionsShow.style.display = "none";

            div_chk.style.border = "inset 1px";
            div_chk.style.background = "gray";

            div_popupAction.style.display = "block";
        }

        function hide() {
            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";

            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";

            div_popupAction.style.display = "none";
        }

        function setDays(title, grdTbDays) {
            if (title.value == "2" || title.value == "3") {
                grdTbDays.disabled = true;
                grdTbDays.value = '0';
            }
            else {
                grdTbDays.disabled = false;
                grdTbDays.value = '';
            }
        }


        var div_chk1 = document.getElementById("div_chk1");
        var div_popupAction1 = document.getElementById("div_popupAction1");
        var div_popupAction2 = document.getElementById("div_popupAction2");
        function show1() {
            img_actionsHide1.style.display = "block";
            img_actionsShow1.style.display = "none";

            div_chk1.style.border = "inset 1px";
            div_chk1.style.background = "gray";

            div_popupAction1.style.display = "block";
        }
       

        function hide1() {
            img_actionsHide1.style.display = "none";
            img_actionsShow1.style.display = "block";

            div_chk1.style.border = "outset 1px";
            div_chk1.style.background = "";

            div_popupAction1.style.display = "none";
        }

        function setDays1(title, grdTbDays) {
            if (title.value == "2" || title.value == "3") {
                grdTbDays.disabled = true;
                grdTbDays.value = '0';
            }
            else {
                grdTbDays.disabled = false;
                grdTbDays.value = '';
            }
        }

        function show2() {
            img_actionsHide2.style.display = "block";
            img_actionsShow2.style.display = "none";

            div_chk2.style.border = "inset 1px";
            div_chk2.style.background = "gray";

            div_popupAction2.style.display = "block";
        }
        function hide2() {
            img_actionsHide2.style.display = "none";
            img_actionsShow2.style.display = "block";

            div_chk2.style.border = "outset 1px";
            div_chk2.style.background = "";

            div_popupAction2.style.display = "none";
        }

        function setDays2(title, grdTbDays) {
            if (title.value == "2" || title.value == "3") {
                grdTbDays.disabled = true;
                grdTbDays.value = '0';
            }
            else {
                grdTbDays.disabled = false;
                grdTbDays.value = '';
            }
        }

        function FindColor(From) {
            var CompanyID = '<%=CompanyID %>';
            var Deliverydate = document.getElementById('ctl00_ContentPlaceHolder1_Chk_DeliveryColor');
            var Productiondate = document.getElementById('ctl00_ContentPlaceHolder1_Chk_ProductionColor1');
            var Completiondate = document.getElementById('ctl00_ContentPlaceHolder1_Chk_CompletionColor1');
            var ColorFrom;
            if (From == 'Delivery') {
                Productiondate.checked = false;
                Completiondate.checked = false;
                //                if (Deliverydate.checked == false) {
                //                    ColorFrom = ""
                //                }
            }
            if (From == 'Production') {
                Deliverydate.checked = false;
                Completiondate.checked = false;
                //                if (Productiondate.checked == false) {
                //                    ColorFrom = ""
                //                }
            }

            if (From == 'Completion') {
                Deliverydate.checked = false;
                Productiondate.checked = false;
                //                if (Productiondate.checked == false) {
                //                    ColorFrom = ""
                //                }
            }

            if (Deliverydate.checked) {
                ColorFrom = "Delivery"
            }
            if (Productiondate.checked) {
                ColorFrom = "Production"
            }
            if (Completiondate.checked) {
                ColorFrom = "Completion"
            }
            if (Deliverydate.checked == false && Productiondate.checked == false && Completiondate.checked==false) {
                ColorFrom = "NotSelected"
            }
            PageMethods.FindColor1(ColorFrom, CompanyID);
        }
    </script>
</asp:Content>
