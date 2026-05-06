<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="guillotine_view.aspx.cs" Inherits="ePrint.settings.guillotine_view" title="Settings: Guillotine" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridGuillotine">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridGuillotine" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridGuillotine" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Winows7" runat="server">
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
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>:<%=objLanguage.GetLanguageConversion("Guillotine_View")%> </asp:Label>
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
            <div style="width: 100%; margin-top: -6px" class="mis_header_panel">
                <div id="">
                    <div align="left" style="width: 100%">
                        <div style="width: 50%">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div align="left" style="width: 100%;">
                        <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                        </div>
                        <div id="div_Main" runat="server" align="left" style="width: 100%;">
                            <div id="a">
                            </div>
                            <div id="div_Grid">
                                <div id="div_popupAction" style="margin: 57px 0px 0px 9px;" onmouseover="show();"
                                    onmouseout="hide(); ">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="width: 100%;">
                                                    <div id="deletedropdown" runat="server" class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CommandName="Delete"
                                                            CausesValidation="false" OnClick="btnDelete_OnClick" Style="text-decoration: none;"
                                                            ForeColor="#333333" Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <telerik:RadGrid Width="55%" ID="GridGuillotine" GridLines="None" runat="server"
                                    BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="True"
                                    PagerStyle-AlwaysVisible="true" PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True"
                                    AutoGenerateColumns="False" OnPageIndexChanged="GridGuillotine_PageIndexChanged"
                                    HeaderStyle-Font-Bold="true" OnPageSizeChanged="GridGuillotine_PageSizeChanged"
                                    OnItemDataBound="GridGuillotine_OnItemDataBound">
                                    <MasterTableView Width="100%" CommandItemDisplay="Top" HorizontalAlign="NotSet" AutoGenerateColumns="False">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <td align="left">
                                                    <asp:LinkButton runat="server" Text="Add New Record" OnClick="btnAddNew_OnClick"
                                                        Font-Underline="True"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input type="checkbox" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                            value='<%# DataBinder.Eval(Container, "DataItem.GuillotineID", "{0}") %>' />
                                                    </div>
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.GuillotineID", "{0}") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="GuillotineName" HeaderText="Guillotine Name"
                                                HeaderStyle-Width="47%" ItemStyle-Width="47%" UniqueName="GuillotineName" Visible="true"
                                                HeaderStyle-HorizontalAlign="Left" DataField="GuillotineName">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <%--<HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblhdrname" runat="server" Text='<%#objLanguage.GetLanguageConversion("Guillotine_Name")%>'></asp:Label>
                                                    </div>
                                                </HeaderTemplate>--%>
                                                <ItemTemplate>
                                                    <a title='<%#Eval("GuillotineName") %>' href='<%=nmsCommon.global.sitePath()%>settings/guillotine_add.aspx?type=edit&id=<%#Eval("GuillotineID")%><%=ParaForLarge %>'>
                                                        <div style="float: left; width: 99%; overflow: hidden;">
                                                            <asp:Label ID="lblGuillotineName" runat="server" Text='<%#Eval("GuillotineName")%>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                                HeaderStyle-Width="50%" ItemStyle-Width="50%" UniqueName="Description" Visible="true"
                                                HeaderStyle-HorizontalAlign="Left" DataField="Description">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblhdrdesc" runat="server" Text='<%#objLanguage.GetLanguageConversion("Description")%>'></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <a title='<%#Eval("Description") %>' href='<%=nmsCommon.global.sitePath()%>settings/guillotine_add.aspx?type=edit&id=<%#Eval("GuillotineID")%><%=ParaForLarge %>'>
                                                        <div style="float: left; width: 99%; overflow: hidden;">
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/images/erase.png" CommandArgument='<%#Eval("GuillotineID")%>'
                                                            OnCommand="imgbtnDelete_OnCommand" ToolTip="Delete" OnClientClick="javascript:return EraseCheck();"
                                                            runat="server" />
                                                        <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.png" ToolTip="Copy"
                                                        CommandArgument='<%#Eval("GuillotineID")%>' OnCommand="imgCopy_OnCommand" />
                                                    </center>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px red;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <script>
    
    </script>
    <script>

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    </script>
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <script type="text/javascript">
        function EraseCheck() {
            return confirm("Delete this record?");
        }
        function CallDelete() {

            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=GridGuillotine.ClientID %>").getElementsByTagName("input");
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
