<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="cart_additional_options_view.aspx.cs" Inherits="ePrint.StoreSettings.cart_additional_options_view" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridWebOtherCost">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: underline;
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
        .RadGrid_Default .rgAdd
        {
            display: none;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div id="overlay" class="web_dialog_overlay_Address">
    </div>
    <div id="div_DeleteConfirm" style="display: none; position: absolute; z-index: 1000;
        width: 40%; left: 37%;">
        <telerik:RadWindowManager runat="server" ID="RadWindowManager2" Title="" Behaviors="Move,Close"
            VisibleStatusbar="false" Modal="true" Top="1000px" OnClientClose="RadWindowclose">
            <Windows>
                <telerik:RadWindow ID="RadWindowDeleteConfirm" DestroyOnClose="true" Width="400"
                    Height="150" runat="server">
                    <ContentTemplate>
                        <div align="center" class="AddTaskEvent">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="popup-middlebg" align="left" style="padding-bottom: 15px;">
                                        <div style="padding-top: 5px">
                                            <div style="float: left; width: 100%;">
                                                <asp:RadioButton ID="rdoDeleteInd" runat="server" Text="Delete from this account"
                                                    GroupName="Delete" Checked="true" />
                                                <asp:RadioButton ID="rdoDeleteAll" runat="server" Text="Delete from All accounts"
                                                    GroupName="Delete" />
                                            </div>
                                        </div>
                                        <div style="padding-left: 5px; padding-top: 5px">
                                            &nbsp;
                                        </div>
                                        <div style="padding-left: 5px; padding-top: 5px">
                                            <div id="div_delete">
                                                <asp:Button ID="btnDeleteAll" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_OnClick"
                                                    OnClientClick="javascript:loadingimg('div_delete','div_Dltprocess');" />
                                            </div>
                                            <div id="div_Dltprocess" class="button" align="center" style="width: 37px; height: 14px;
                                                display: none; margin: 2px 2px 1px 2px;">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <div style="float: left;" class="estore_settingBox">
        <UC:Header ID="header" runat="server" />
        <div id="divFinishedGoods" style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <asp:Label ID="lblHeader" runat="server"><%=objLanguage.GetLanguageConversion("Estore_Settings")%>: <%=objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option")%></asp:Label>
                                    <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                        href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                        <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                    </a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="manageedit">
            <div id="">
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div align="left" style="width: 100%">
                    <div align="left" style="width: 100%">
                        <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                        </div>
                        <div id="div_Main" runat="server" align="left" style="width: 100%">
                            <div id="a">
                            </div>
                            <div id="div_popupAction" style="margin: 53px 0px 0px 11px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%">
                                                <div style="padding-bottom: 7px; padding-top: 7px; width: 130px;" class="divDropdownlist">
                                                    <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" Style="text-decoration: none;"
                                                        Width="150px" OnClientClick="javascript:return CallDelete();" OnClick="btnDelete_OnClick"
                                                        ForeColor="#333333" Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 100%">
                                                <div style="padding-bottom: 7px; padding-top: 7px; width: 130px;" class="divDropdownlist">
                                                    <asp:LinkButton ID="lnkbtnAllocate" runat="server" Text="Allocate Selected" Style="text-decoration: none;"
                                                        Width="150px" OnClientClick="javascript:Show_EmailaccountListDiv(); return false;"
                                                        ForeColor="#333333" Font-Size="11px">
                                                    <%=objLanguage.GetLanguageConversion("Allocate_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_Grid">
                                <telerik:RadGrid Width="80%" ID="GridWebOtherCost" GridLines="None" runat="server"
                                    BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="True"
                                    PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True" AutoGenerateColumns="False"
                                    HeaderStyle-Font-Bold="true" OnPageIndexChanged="GridWebOtherCost_PazeIndexChanged"
                                    OnPageSizeChanged="GridWebOtherCost_PazeSizeChanged" OnItemDataBound="GridWebOtherCost_OnItemDataBound"
                                    AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="false">
                                    <MasterTableView PagerStyle-AlwaysVisible="true" CommandItemDisplay="Top" Width="100%"
                                        HorizontalAlign="NotSet" AutoGenerateColumns="False" DataKeyNames="WebOtherCostID">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%; margin-top: -10px">
                                                <td align="left" style="text-decoration: underline; margin-left: -10px">
                                                    <a href="cart_additional_options.aspx?type=add">
                                                        <%=objLanguage.GetLanguageConversion("Add_New_Record")%>
                                                    </a>
                                                </td>
                                                <td align="right" style="text-decoration: underline; margin-right: -10px">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                        margin-right: -10px; cursor: pointer" runat="server" Text='<%#objLanguage.GetLanguageConversion("Clear_All_Filters") %>' />
                                                </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false" AllowFiltering="false">
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
                                                            value='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>' />
                                                    </div>
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderText="Category"
                                                CurrentFilterFunction="Contains" HeaderStyle-Width="15%" DataField="OtherCostCategoryName"
                                                ItemStyle-Width="15%" UniqueName="LithoPressName" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                AutoPostBackOnFilter="true">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="Label4" runat="server"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a title='<%#Eval("WebOtherCostName")%>' href="<%=strSitepath%>storesettings/cart_additional_options.aspx?type=edit&id=<%#Eval("WebOtherCostID")%>">
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblOtherCostCategoryName" CssClass="normalText" runat="server" Text='<%#Eval("OtherCostCategoryName")%>'
                                                                ToolTip='<%#Eval("OtherCostCategoryName")%>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="WebOtherCostName" HeaderText="Name" CurrentFilterFunction="Contains"
                                                DataField="WebOtherCostName" HeaderStyle-Width="20%" ItemStyle-Width="20%" UniqueName="WebOtherCostName"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a title='<%#Eval("WebOtherCostName")%>' href="<%=strSitepath%>storesettings/cart_additional_options.aspx?type=edit&id=<%#Eval("WebOtherCostID")%>">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                            <%#Eval("WebOtherCostName")%>
                                                            <asp:Label ID="lblOtherCostName" Visible="false" CssClass="normaltext" runat="server"
                                                                Text='<%#Eval("WebOtherCostName")%>' ToolTip='<%#Eval("WebOtherCostName")%>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="UserFriendlyName" CurrentFilterFunction="Contains"
                                                DataField="UserFriendlyName" HeaderStyle-Width="20%" ItemStyle-Width="20%" UniqueName="UserFriendlyName"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblUserFriendlyName" runat="server"><%=objLanguage.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a title='<%#Eval("UserFriendlyName")%>' href="<%=strSitepath%>storesettings/cart_additional_options.aspx?type=edit&id=<%#Eval("WebOtherCostID")%>">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                            <%#Eval("UserFriendlyName")%>
                                                            <asp:Label ID="lblUserFriendlyName" Visible="false" CssClass="normaltext" runat="server"
                                                                Text='<%#Eval("UserFriendlyName")%>' ToolTip='<%#Eval("UserFriendlyName")%>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                                CurrentFilterFunction="Contains" DataField="Description" HeaderStyle-Width="25%"
                                                ItemStyle-Width="25%" AutoPostBackOnFilter="true" UniqueName="Description" Visible="true"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="Label5" runat="server"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a title='<%#Eval("UserFriendlyName")%>' href="<%=strSitepath%>storesettings/cart_additional_options.aspx?type=edit&id=<%#Eval("WebOtherCostID")%>">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                            <asp:Label ID="lblDescription" CssClass="normalText" runat="server" Text='<%#Eval("Description")%>'
                                                                ToolTip='<%#Eval("Description") %>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="Action" HeaderText="Action" AllowFiltering="false"
                                                Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%-- By Jagat On 06-july-2012--%>
                                                    <asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                        CommandArgument='<%#Eval("WebOtherCostID")%>' OnCommand="imgbtnDelete_OnClick"
                                                        Text="Delete" UniqueName="DeleteColumn" runat="server" OnClientClick='<%#Eval("WebOtherCostID", "javascript:return ImgButtonErase_ClientClick({0});")%>'>
                                                    </asp:ImageButton>
                                                    <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.gif" ToolTip="Copy"
                                                        Height="20px" OnCommand="imgbtnCopy_OnCommand" OnClientClick="javascript:return CheckOne_copy();"
                                                        CommandArgument='<%#Eval("WebOtherCostID")%>' />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                                <asp:ObjectDataSource ID="odsPriceCatalogue" runat="server" TypeName="Printcenter.UI.Webstores.WebstoreBasePage"
                                    SelectMethod="SettingsWebStore_OtherCost_PageText_ShopCartCost">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                                        <asp:Parameter Name="PageSize" DefaultValue="10000" Type="Int32" />
                                        <asp:Parameter Name="PageNumber" DefaultValue="1" Type="Int32" />
                                        <asp:Parameter Name="SortBy" DefaultValue="WebOtherCostID" Type="String" />
                                        <asp:SessionParameter Name="SortDirection" DefaultValue="desc" Type="String" />
                                        <asp:SessionParameter Name="WhereCondition" DefaultValue=" " Type="String" />
                                        <asp:Parameter Name="AdditionalType" DefaultValue="c" Type="String" />
                                        <asp:ControlParameter Name="AccountID" ControlID="hdnAccountID" Type="Int64" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField ID="hdnAccountID" runat="server"></asp:HiddenField>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <asp:HiddenField ID="hid_Allocate_IDs" runat="server" Value="" />
    <script type="text/javascript">

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");

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

        function hideDelete() {
            document.getElementById("div_DeleteConfirm").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            document.getElementById("overlay").style.display = "none";
            return false;
        }

        function ShowDelete() {
            document.getElementById("ctl00_ContentPlaceHolder1_RadWindowDeleteConfirm_C_btnDeleteAll").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_RadWindowDeleteConfirm_C_btnDeleteAll").style.float = "left";
            document.getElementById("div_DeleteConfirm").style.display = "block";
            document.getElementById("divBackGroundNew").style.display = "block";
            document.getElementById("overlay").style.display = "block";
            return false;
        }

        function ImgButtonErase_ClientClick(id) {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) > 1) {
                alert("Please check only one row to Delete");
                return false;
            }
            else {
                document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = id;
                ShowDelete();
                ShowDeletePopUp();
                return false;
                //return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation") %>');
            }
        }
        function CheckOne_copy() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) > 1) {
                alert("Please check only one row to copy");
                return false;
            }
        }
        function CallDelete() {
            var ret = CheckOnehere();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=GridWebOtherCost.ClientID %>").getElementsByTagName("input");
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('Id') != -1) {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
                document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = IDs;
                ShowDelete();
                ShowDeletePopUp();
                return false;
                //return true;
            }
            else {
                return false;
            }
        }

        function CheckOnehere() {
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
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return true;
            }
        }

        function ShowDeletePopUp() {
            var oWnd = $find("<%=RadWindowDeleteConfirm.ClientID%>");
            oWnd.show();
        }
        function RadWindowclose() {
            document.getElementById("divBackGroundNew").style.display = "none";
            document.getElementById("overlay").style.display = "none";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

