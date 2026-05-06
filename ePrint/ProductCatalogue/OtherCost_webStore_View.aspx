<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="OtherCost_webStore_View.aspx.cs" Inherits="ePrint.ProductCatalogue.OtherCost_webStore_View" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <%--<div id="divFinishedGoods" style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <%=objlang.GetLanguageConversion("Products") %>&nbsp;:&nbsp;<asp:Label ID="lblHeader"
                                    runat="server"><%=objlang.GetLanguageConversion("WebStore_Other_Cost")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div>
        <div id="">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="left" style="width: 100%">
                <div align="left" class="div_spacing1">
                    <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <div id="div_Main" runat="server" align="left" style="width: 100%">
                        <div id="a">
                        </div>
                        <div id="div_popupAction" style="margin: 56px 0px 0px 9px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%">
                                            <div id="div_lnkbtnDelete" runat="server" class="divDropdownlist" style="padding-bottom: 7px;
                                                padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" Style="text-decoration: none;
                                                    font-size: 11px" ForeColor="Black" OnClientClick="javascript:return CallDelete();"
                                                    OnClick="btnDelete_OnClick"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--OnItemCommand="OnItemCommand_GridWebOtherCost"--%>
                        <div id="div_Grid">
                            <telerik:RadGrid Width="100%" ID="GridWebOtherCost" GridLines="None" runat="server"
                                ClientSettings-AllowRowsDragDrop="true" AllowAutomaticDeletes="True" ShowStatusBar="true"
                                AllowAutomaticInserts="True" PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True"
                                OnRowDrop="grdwWebStoreOthercost_RowDrop" OnNeedDataSource="grdwebstoreothercost_NeedDataSource"
                                AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" OnPageIndexChanged="GridWebOtherCost_PazeIndexChanged"
                                OnPageSizeChanged="GridWebOtherCost_PazeSizeChanged" AllowFilteringByColumn="True" AllowFiltering="True"
                                OnItemDataBound="GridWebOtherCost_OnItemDataBound">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView PagerStyle-AlwaysVisible="true" ToolTip="Drag and drop the rows to reorder"
                                    CommandItemDisplay="Top" Width="100%" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                                    DataKeyNames="WebOtherCostID">
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%;">
                                            <tr>
                                                <td align="left">
                                                    <div id="div_AddNewRecord" title="Add New Record" runat="server">
                                                        <asp:Button PostBackUrl="~/ProductCatalogue/Othercost_webstore.aspx?type=add" ID="btn_addnew"
                                                            CssClass="rgAdd" runat="server" /><a href="Othercost_webstore.aspx?type=add"><%=objlang.GetLanguageConversion("Add_New_Record") %>
                                                            </a>
                                                    </div>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                        cursor: pointer" runat="server" Text="Clear All Filters"><%=objlang.GetLanguageConversion("Clear_All_filters") %></asp:LinkButton>
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
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderText="Category"
                                            FilterControlWidth="110px" CurrentFilterFunction="Contains" HeaderStyle-Width="15%"
                                            DataField="OtherCostCategoryName" ItemStyle-Width="15%" UniqueName="OtherCostCategoryName"
                                            Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label4" runat="server"><%=objlang.GetLanguageConversion("Category")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="lblOtherCostCategoryName" CssClass="normalText" runat="server" Text='<%#Eval("OtherCostCategoryName")%>'
                                                        ToolTip='<%#Eval("OtherCostCategoryName")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdn_webothercostid_Categoryname" runat="server" Value='<%#Eval("WebOtherCostID")%>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="WebOtherCostName" HeaderText="Name" CurrentFilterFunction="Contains"
                                            DataField="WebOtherCostName" HeaderStyle-Width="30%" ItemStyle-Width="30%" UniqueName="WebOtherCostName"
                                            Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true"
                                            FilterControlWidth="110px">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label1" runat="server"><%=objlang.GetLanguageConversion("Name")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                    <asp:Label ID="lblOtherCostName" Visible="true" CssClass="normaltext" runat="server"
                                                        Text='<%#Eval("WebOtherCostName")%>' ToolTip='<%#Eval("WebOtherCostName")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="UserFriendlyName" CurrentFilterFunction="Contains"
                                            DataField="UserFriendlyName" HeaderStyle-Width="22%" ItemStyle-Width="22%" UniqueName="UserFriendlyName"
                                            Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true"
                                            FilterControlWidth="110px">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 90%; overflow: hidden">
                                                    <asp:Label ID="lblUserFriendlyName" runat="server"><%=objlang.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                    <asp:Label ID="lblUserFriendlyName" Visible="true" CssClass="normaltext" runat="server"
                                                        Text='<%#Eval("UserFriendlyName")%>' ToolTip='<%#Eval("UserFriendlyName")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                            CurrentFilterFunction="Contains" DataField="Description" HeaderStyle-Width="15%"
                                            ItemStyle-Width="15%" UniqueName="Description" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                            AutoPostBackOnFilter="true" FilterControlWidth="110px">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 90%; overflow: hidden">
                                                    <asp:Label ID="Label5" runat="server"><%=objlang.GetLanguageConversion("Help_Text")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 90%; overflow: hidden; height: 15px; overflow: hidden">
                                                    <asp:Label ID="lblDescription" CssClass="normalText" runat="server" Text='<%#Eval("Description")%>'
                                                        ToolTip='<%#Eval("Description") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="IsSubAdditionOption" CurrentFilterFunction="Contains"
                                            DataField="IsSubAdditionOption" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            UniqueName="IsSubAdditionOption" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                            AutoPostBackOnFilter="true" FilterControlWidth="110px">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 90%; overflow: hidden">
                                                    <asp:Label ID="lblIsSubAdditionOption" runat="server"><%=objlang.GetLanguageConversion("Option_Type")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                    <asp:Label ID="lblIsSubAdditionOption" Visible="true" CssClass="normaltext" runat="server"
                                                        Text='<%#Eval("IsSubAdditionOption")%>' ToolTip='<%#Eval("IsSubAdditionOption")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="Action" HeaderText="" AllowFiltering="false"
                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" Visible="true" HeaderStyle-HorizontalAlign="Right"
                                            ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <div style="float: right; width: 90%; overflow: hidden">
                                                    <asp:Label ID="lblaction_header" runat="server"><%=objlang.GetLanguageConversion("Action")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a href='<%=strSitepath%>ProductCatalogue/Othercost_webstore.aspx?type=edit&id=<%#Eval("WebOtherCostID")%>'
                                                    visible="false" style="display: none;">
                                                    <asp:Image ID="imgbtnEdit" runat="server" ImageUrl="~/images/edit.gif" ToolTip="Edit" />
                                                </a>
                                                <asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" ToolTip="Delete"
                                                    CommandName="Delete" CommandArgument='<%#Eval("WebOtherCostID")%>' OnCommand="imgbtnDelete_OnClick"
                                                    Text="Delete" UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return ImgButtonErase_ClientClick()">
                                                </asp:ImageButton>
                                                <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.png" ToolTip="Copy"
                                                    OnCommand="imgbtnCopy_OnCommand" OnClientClick="javascript:return CheckOne_copy();"
                                                    CommandArgument='<%#Eval("WebOtherCostID")%>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridDragDropColumn ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                            ItemStyle-Width="10%" DragImageUrl="~/images/drag_drop.gif" Visible="false">
                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                        </telerik:GridDragDropColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="3%" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left"
                                            ItemStyle-HorizontalAlign="left" AllowFiltering="false">
                                            <ItemTemplate>
                                                <div style="margin-left: -8px; background-image: url('../images/drag_drop.gif');
                                                    width: 13px; height: 15px; background-repeat: no-repeat; position: static;" align="center">
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
                &nbsp;</div>
            <div align="left">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
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
        function ImgButtonErase_ClientClick() {
            // return confirm("Are you sure you want to delete this record?");
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
                return window.confirm('Are you sure you want to delete this record?');
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
            var ret = CheckOne();
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
                return true;
            }
            else {
                return false;
            }
        }
        function OnRowClick(EditPage) {
            window.location = EditPage;
        }
    </script>
</asp:Content>
