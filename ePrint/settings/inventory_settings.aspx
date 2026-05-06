<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="inventory_settings.aspx.cs" Inherits="ePrint.settings.inventory_settings" title="Settings: Inventory" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridStockCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridStockCategory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridStockCategory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridStockCategory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
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
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Inventory_Settings_View")%></asp:Label>
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
        <div style="width: 100%; padding-bottom: 0px; margin-top: -10px;" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePanelMessage" runat="server" RenderMode="Inline" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div align="left" style="width: 100%; padding-bottom: 10px; border: 0px solid red">
                    <div id="padding_div">
                        <asp:UpdatePanel ID="pnlStockCategory" ChildrenAsTriggers="false" UpdateMode="Conditional"
                            RenderMode="inline" runat="server">
                            <ContentTemplate>
                                <div id="div_Grid">
                                    <div id="div_popupAction" style="margin: 57px 0px 0px 9px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                            <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" Style="text-decoration: none;"
                                                                ForeColor="#333333" Font-Size="11px" Width="150px" OnClientClick="javascript:return CallDelete();"
                                                                OnClick="btnDelete_OnClick"><%=objLanguage.GetLanguageConversion("Detele_Selected") %></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="div_Main" runat="server" align="left" style="width: 100%">
                                        <telerik:RadGrid Width="50%" ID="GridStockCategory" GridLines="None" runat="server"
                                            BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="false"
                                            PagerStyle-AlwaysVisible="true" PageSize="50" AllowAutomaticUpdates="false" AllowPaging="True"
                                            OnItemCommand="GridStockCategory_OnItemCommand" AutoGenerateColumns="False" DataSourceID="odsStockCategory"
                                            OnPageIndexChanged="GridStockCategory_OnPageChanged" HeaderStyle-Font-Bold="true"
                                            OnInsertCommand="GridStockCategory_OnInsertCommand" OnUpdateCommand="GridStockCategory_UpdateCommand"
                                            OnItemDataBound="GridStockCategory_ItemDataBound">
                                            <MasterTableView Width="100%" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                                                DataKeyNames="CategoryID" CommandItemDisplay="Top" CommandItemSettings-RefreshText=""
                                                InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                <CommandItemTemplate>
                                                    <table class="rgCommandTable" border="0" style="width: 100%;">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                                    Font-Underline="True"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </CommandItemTemplate>
                                                <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                    <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                    <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                    <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="0" BackColor="White"
                                                        Width="100%" />
                                                    <FormTableStyle CellSpacing="0" CellPadding="0" Height="10px" BackColor="White" />
                                                    <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                    <EditColumn UniqueName="EditColumn">
                                                    </EditColumn>
                                                    <FormTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 8px; margin-top: 4px;">
                                                            <tr>
                                                                <td>
                                                                    <div class="bglabel" style="width: 100%">
                                                                        <%=objLanguage.GetLanguageConversion("Category_Code")%><span style="color: Red"> *</span>
                                                                    </div>
                                                                </td>
                                                                <td align="left" style="padding-left: 14px; vertical-align: top;">
                                                                    <asp:TextBox ID="txtCode" runat="server" SkinID="textPad" MaxLength="20" TabIndex="1"
                                                                        Text='<%#Bind("CategoryCode")%>' Style="float: left;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage='<%#objLanguage.GetLanguageConversion("Please_Enter_Category_Code") %>'
                                                                            ControlToValidate="txtCode" Display="Dynamic" CssClass="RFV_Message" ForeColor=""
                                                                            Style="width: auto; margin-left: 4px; padding-left: 4px; padding-right: 4px"></asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:HiddenField ID="hdn_CategoryID" Value='<%# Bind("CategoryID") %>' runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="bglabel" style="width: 100%">
                                                                        <%=objLanguage.GetLanguageConversion("Category_Name")%><span style="color: Red"> *</span>
                                                                    </div>
                                                                </td>
                                                                <td align="left" style="padding-left: 14px; vertical-align: top;">
                                                                    <asp:TextBox ID="txtName" runat="server" SkinID="textPad" MaxLength="50" TabIndex="2"
                                                                        Text='<%#Bind("CategoryName")%>' Style="float: left;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="RFVName" runat="server" ErrorMessage='<%#objLanguage.GetLanguageConversion("Please_Enter_Category_Name") %>'
                                                                            ControlToValidate="txtName" Display="Dynamic" CssClass="RFV_Message" ForeColor=""
                                                                            Style="width: auto; margin-left: 4px; padding-left: 4px; padding-right: 4px"></asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="bglabel" style="height: 84px; width: 100%">
                                                                        <%=objLanguage.GetLanguageConversion("Description")%>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left; width: 100%; padding-left: 14px; vertical-align: top;">
                                                                        <asp:TextBox ID="txtDescription" Rows="2" Height="82px" Width="172px" runat="server"
                                                                            TextMode="MultiLine" SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"
                                                                            TabIndex="3" Text='<%#Bind("Description")%>'></asp:TextBox></div>
                                                                    <div style="float: left; padding-left: 1px">
                                                                        <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 175px;">
                                                                            <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%>
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <div class="bglabel" style="width: 100%">
                                                                        <%=objLanguage.GetLanguageConversion("Properties")%>
                                                                    </div>
                                                                </td>
                                                                <td align="left">
                                                                    <div style="width: 100%; padding-left: 12px; padding-bottom: 8px;">
                                                                        <asp:CheckBoxList ID="chkproperties" Visible="true" runat="server" RepeatColumns="2"
                                                                            RepeatDirection="vertical" CellSpacing="0" TabIndex="5">
                                                                            <asp:ListItem Value="0" Text="Weight"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Colour"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Item Custom Size"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Estimate Enabled"></asp:ListItem>
                                                                            <asp:ListItem Value="4" Text="Coating Type"></asp:ListItem>
                                                                            <asp:ListItem Value="5" Text="Printing"></asp:ListItem>
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left; padding: 5px 0px 10px 5px;">
                                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                            runat="server" Text='<%#objLanguage.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                            CausesValidation="false">
                                                                        </telerik:RadButton>
                                                                        <div style="float: left; width: 10px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                                            runat="server" Text='<%#objLanguage.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                        </telerik:RadButton>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--</div>--%>
                                                    </FormTemplate>
                                                    <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                                </EditFormSettings>
                                                <Columns>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                        <HeaderStyle HorizontalAlign="left" Width="5%" Wrap="false" />
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div style="float: left; display: none;">
                                                                    <input type="checkbox" id="CheckBox1" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                            <div style="padding-left: 2px">
                                                                <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.CategoryID", "{0}") %>' />
                                                            </div>
                                                            <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.CategoryID", "{0}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="CategoryName" HeaderText="Category Name"
                                                        HeaderStyle-Width="50%" ItemStyle-Width="50%" UniqueName="CategoryName" Visible="true"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#objLanguage.GetLanguageConversion("Category_Name")%>'></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%; overflow: hidden; cursor: pointer">
                                                                <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("CategoryName")%>' ToolTip='<%#Eval("CategoryName")%>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                                        HeaderStyle-Width="47%" ItemStyle-Width="47%" UniqueName="Description" Visible="true"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#objLanguage.GetLanguageConversion("Description")%>'></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div align="left" style="width: 99%; float: left; cursor: pointer">
                                                                <div style="padding-left: 5px; display: block; overflow: hidden">
                                                                    <div style="width: 100%; display: block; overflow: hidden; width: 200px">
                                                                        <div style="white-space: nowrap; display: block;">
                                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' ToolTip='<%#Eval("Description")%>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderText="Action">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Action") %></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--By Jagat On 26/July--%>
                                                            <center>
                                                                <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandArgument='<%#Eval("CategoryID")%>'
                                                                    Text="Delete" runat="server" OnCommand="lnkDelete_onclick" OnClientClick="javascript:return ImgButtonErase_ClientClick();"
                                                                    CommandName="Delete" ToolTip="Delete" UniqueName="DeleteColumn"></asp:ImageButton></center>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings EnableRowHoverStyle="true">
                                                <ClientEvents OnRowClick="RowDblClick" />
                                            </ClientSettings>
                                        </telerik:RadGrid></div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:ObjectDataSource ID="odsStockCategory" runat="server" TypeName="Printcenter.UI.Inventories.InventoryBasePage"
                            SelectMethod="settings_stockcategory_select"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
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
    <script type="text/javascript">
        function ImgButtonErase_ClientClick() {
            return confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
        }

        function CallDelete() {
            var ret = CheckOne_new();
            //alert(ret);
            if (ret) {
                CheckGrid();
                return true;
            }
            else {
                return false;
            }
        }

        function CheckOne_new() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                //alert(Counter);
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                //alert("call Btn");
                return window.confirm('Are you sure you want to delete this record(s)?');
            }
        }
    </script>
    <div style="clear: both">
        &nbsp;</div>
    <div align="left" style="display: none;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend><b>
                        <%=objLanguage.GetLanguageConversion("Inventory_SubCategories")%></b></legend>
                    <div align="left" style="width: 60%;" nowrap="nowrap">
                        <div style="float: right; padding-right: 5px">
                            <span class="normalText">
                                <%=objLanguage.GetLanguageConversion("Total_Records")%>:</span> <b>
                                    <asp:Label ID="lblTotalRecordsSubCategory" runat="server"></asp:Label></b></div>
                        <div class="onlyEmpty">
                        </div>
                        <asp:GridView ID="GridStockSubCategory" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="10" DataSourceID="odsStockSubCategory" GridLines="Horizontal"
                            SkinID="GridStyle" OnRowDataBound="GridStockSubCategory_OnRowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="SubCategory Name" ItemStyle-Wrap="false" ItemStyle-Width="20%">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" Wrap="false" />
                                    <ItemTemplate>
                                        <a href="<%=strSitepath%>settings/inventorysettings_newsubstock.aspx?type=edit&id=<%#Eval("SubCategoryID")%>">
                                            <asp:Label ID="lbl22" CssClass="normaltext" runat="server" Text='<%#Eval("SubCategoryName")%>'></asp:Label>
                                        </a><a href="#">
                                            <asp:Label ID="lblSubCategoryName" runat="server" Text='<%#Eval("SubCategoryName")%>'
                                                Visible="false"></asp:Label>
                                        </a>
                                        <asp:Label ID="lblSubcategoryID" runat="server" Text='<%#Eval("SubCategoryID")%>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category Name" ItemStyle-Wrap="false" ItemStyle-Width="20%">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblParentCategory" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Wrap="false" ItemStyle-Width="29%">
                                    <HeaderStyle HorizontalAlign="Left" Width="29%" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsStockSubCategory" runat="server" TypeName="Printcenter.UI.Inventories.InventoryBasePage"
                            SelectMethod="settings_stocksubcategory_select"></asp:ObjectDataSource>
                    </div>
                    <div style="clear: both">
                        &nbsp;</div>
                    <div style="float: left; cursor: pointer;">
                        <asp:Button ID="btnAddInventorySubCat" runat="server" Text="Add New Inventory SubCategory"
                            CssClass="button" PostBackUrl="inventorysettings_newsubstock.aspx?type=add" Width="220px" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;</div>
                    <div style="float: left; cursor: pointer;">
                        <asp:LinkButton ID="lnkShowAll" runat="server" Visible="false" OnCommand="lnkShowAll_OnCommand"
                            Style="text-decoration: underline"><%=objLanguage.GetLanguageConversion("Show_All")%></asp:LinkButton>
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div> </div>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            <%=objlang.GetValueOnLang ("Loading") %>...</div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <script> </script>
    <script>        function CallScroll() {
            var GridID = document.getElementById("<%=GridStockCategory.ClientID%>");
            var div_HeaderID = document.getElementById("a"); var div_BodyID = document.getElementById("div_Grid");
            var OuterDivID = document.getElementById("div_test_1"); var InnerDivID = document.getElementById("div_test_2");
            var DivTotalRecID = document.getElementById("div_TotalRec"); startset(GridID, div_HeaderID,
    div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
        } </script>
    <script>
        
    </script>
    <asp:Panel ID="pnlCallScroll" runat="server" Visible="false">
        <script>
            if ('<%=totalrec %>' != 0) {
            }
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
