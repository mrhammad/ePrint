<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="othercost_category_view.aspx.cs" Inherits="ePrint.settings.othercost_category_view" title="Settings: Other Costs" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="ScriptManager2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridCostCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridCostCategory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridCostCategory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
            margin-left: -10px;
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
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div id="divFinishedGoods" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblHeader" runat="server"><%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Other_Cost_Categories")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="" class="mis_header_panel" style="margin-top: -10px">
            <div align="left" style="width: 100%">
                <div style="width: 80%;">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <div align="left" style="width: 90%;">
                    <div style="clear: both">
                    </div>
                    <div id="a">
                    </div>
                    <div id="div_Grid">
                        <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CausesValidation="false"
                                                    OnClick="btnDelete_OnClick" OnClientClick="javascript:return CallDelete();" ForeColor="#333333"
                                                    Font-Size="11px" Style="text-decoration: none;"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadGrid Width="65%" ID="GridCostCategory" GridLines="None" runat="server"
                                    BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowSorting="true"
                                    PageSize="50" DataSourceID="odsCostCategory" AllowPaging="True" PagerStyle-AlwaysVisible="true"
                                    AutoGenerateColumns="False" OnPageIndexChanged="GridCostCategory_PageIndexChanged"
                                    HeaderStyle-Font-Bold="true" OnPageSizeChanged="GridCostCategory_PageSizeChanged"
                                    OnUpdateCommand="GridCostCategory_UpdateCommand" OnInsertCommand="GridCostCategory_InsertCommand"
                                    OnItemDataBound="GridCostCategory_OnItemDataBound" OnItemCommand="GridCostCategory_OnItemCommand">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView AllowFilteringByColumn="true" Width="100%" HorizontalAlign="NotSet"
                                        CommandItemSettings-RefreshText="" CommandItemSettings-ShowRefreshButton="false"
                                        AutoGenerateColumns="False" DataKeyNames="OtherCostCategoryID" CommandItemDisplay="Top"
                                        InsertItemPageIndexAction="ShowItemOnFirstPage">
                                        <CommandItemTemplate>
                                            <%--By Jagat on 05-July-2012--%>
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <tr>
                                                    <td align="left " style="margin-left: -10px;">
                                                        <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                            Font-Underline="True"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                    </td>
                                                    <td align="right">
                                                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                            margin-right: -9px; float: right; cursor: pointer" runat="server" Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <EditFormSettings ColumnNumber="2" EditFormType="Template" CaptionDataField="OtherCostCategoryID"
                                            CaptionFormatString="Edit Category {0}">
                                            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="0" BackColor="White"
                                                Width="100%" />
                                            <FormTableStyle CellSpacing="0" CellPadding="0" Height="10px" BackColor="White" />
                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                            <EditColumn UniqueName="EditColumn">
                                            </EditColumn>
                                            <FormTemplate>
                                                <table border="0" cellpadding="0" width="100%" id="a" style="margin: 5px">
                                                    <tr>
                                                        <td style="width: 130px">
                                                            <div class="bglabel" runat="server" style="width: 130px; margin: 0px">
                                                                <asp:Label ID="labelName" runat="server" Text='<%#objLanguage.GetLanguageConversion("Name") %>'></asp:Label>
                                                                <span style="color: Red">*</span>
                                                            </div>
                                                        </td>
                                                        <td style="padding-left: 3px;">
                                                            <telerik:RadTextBox ID="txtCategoryName" MaxLength="100" Width="200px" runat="server"
                                                                Text='<%# Bind("OtherCostCategoryName") %>' Style="float:left">
                                                            </telerik:RadTextBox>
                                                            <span style="color: Red">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCategoryName"
                                                                    ErrorMessage="Enter Category Name" runat="server" CssClass="RFV_Message" ForeColor=""
                                                                    Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                                </asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 130px">
                                                            <div id="Div1" class="bglabel" runat="server" style="width: 130px; margin: 0px">
                                                                <asp:Label ID="Label1" CssClass="normaltext" runat="server"><%=objLanguage.GetLanguageConversion("Job_Card_Catagory")%></asp:Label>
                                                                <span style="color: Red">*</span>
                                                            </div>
                                                        </td>
                                                        <td style="padding-left: 2px;">
                                                            <asp:DropDownList ID="ddlJobcardCategory" runat="server" CssClass="normalText" Width="204px">
                                                                <asp:ListItem Text="Pre Press" Value="Pre Press"></asp:ListItem>
                                                                <asp:ListItem Text="Press" Value="Press"></asp:ListItem>
                                                                <asp:ListItem Text="Post Press" Value="Post Press"></asp:ListItem>
                                                                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                                                <asp:ListItem Text="Packing" Value="Packing"></asp:ListItem>
                                                                <asp:ListItem Text="Dispatch" Value="Dispatch"></asp:ListItem>
                                                                <asp:ListItem Text="Admin 2" Value="Admin 2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnOtherCostCategoryID" runat="server" Value='<%#Eval("OtherCostCategoryID")%>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 2px">
                                                            <span id="Span1" class="smallgraytext" style="display: block; width: auto">(<%=objLanguage.GetLanguageConversion("Please_Specify_Where_You_Would_Like_This_Category_To_Appear_On_The_Job_Card")%>)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 130px">
                                                        </td>
                                                        <td style="padding: 4px">
                                                            <div style="float: left">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                    CausesValidation="false">
                                                                </telerik:RadButton>
                                                            </div>
                                                            <div style="float: left; width: 10px">
                                                                &nbsp;
                                                            </div>
                                                            <div style="float: left">
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                                    runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                                                    OnClick="btnSave_OnClick">
                                                                </telerik:RadButton>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FormTemplate>
                                        </EditFormSettings>
                                        <Columns>
                                            <%--ItemTemplete Change by Jagat On 14/July/2012--%>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="2%" ItemStyle-Width="2%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input type="checkbox" runat="server" name="checkAll" />
                                                        </div>
                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
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
                                                    <div style="padding-left: 5px">
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.OtherCostCategoryID", "{0}") %>' />
                                                        <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.OtherCostCategoryID", "{0}") %>'></asp:Label>
                                                        <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderStyle-Width="45%"
                                                DataField="OtherCostCategoryName" ItemStyle-Width="45%" UniqueName="OtherCostCategoryName"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Category_Name")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden; cursor: pointer">
                                                        <asp:Label ID="lblCategoryName" Visible="true" CssClass="normaltext" runat="server"
                                                            Text='<%#Eval("OtherCostCategoryName")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="JobcardCategory" HeaderStyle-Width="45%"
                                                DataField="JobcardCategory" ItemStyle-Width="45%" UniqueName="JobcardCategory"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label2" runat="server" Width="100%"><%=objLanguage.GetLanguageConversion("Job_Card_Category")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden; cursor: pointer">
                                                        <asp:Label ID="lblJobcardCategory" CssClass="normaltext" runat="server" Text='<%#Eval("JobcardCategory")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label4" Text="" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action")%></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <div>
                                                            <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/Images/erase.png" runat="server" OnClientClick="javascript:return CheckDelete();"
                                                                CommandArgument='<%#Eval("OtherCostCategoryID")%>' ToolTip="Delete" OnCommand="imgbtnDelete_OnClick" />
                                                    </center>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents OnRowClick="RowDblClick" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:ObjectDataSource ID="odsCostCategory" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                            SelectMethod="settings_othercostcategory_selectall_new">
                            <SelectParameters>
                                <asp:SessionParameter Name="companyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                                <%--  <asp:Parameter Name="Type" Type="String" />--%>
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:SessionParameter Name="companyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                                <asp:Parameter Name="OtherCostCategoryID" Type="Int32" />
                                <asp:Parameter Name="OtherCostCategoryName" Type="String" />
                                <asp:Parameter Name="PreStatus" Type="Int32" />
                                <asp:Parameter Name="JobcardCategory" Type="String" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:SessionParameter Name="companyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                                <asp:Parameter Name="OtherCostCategoryID" Type="Int32" />
                                <asp:Parameter Name="OtherCostCategoryName" Type="String" />
                                <asp:Parameter Name="PreStatus" Type="Int32" />
                                <asp:Parameter Name="JobcardCategory" Type="String" />
                            </InsertParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div align="left">
            </div>
        </div>
    </div>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <script>
       
    </script>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                return true;
            }
            else {
                return false;
            }
        }
        function CheckDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
        
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/drag.js?VN='<%=VersionNumber%>'"
        language="javascript"></script>
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
