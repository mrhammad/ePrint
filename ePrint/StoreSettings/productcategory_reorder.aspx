<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="productcategory_reorder.aspx.cs" Inherits="ePrint.StoreSettings.productcategory_reorder" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <%--   <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lnk_accountsList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCategorySelect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <div style="float: left;" class="estore_settingBox" id="pnldetails">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Product_Category_Reorder")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div class="manageedit">
                <div style="padding-left: 5px;">
                    <div align="left" style="width: 100%; border: 0px solid red">
                        <div style="width: 60%">
                            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div align="left" style="width: 50%;">
                    <div id="div1" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <%-- <td>
                                </td>--%>
                                <td>
                                    <div style="height: 25px;">
                                        <asp:RadioButton ID="rdbAutoAlphabetic" GroupName="Order" runat="server" Text="Auto Alphabetical Order" />
                                    </div>
                                    <div style="height: 30px;">
                                        <asp:RadioButton ID="rdbCustom" GroupName="Order" runat="server" Text="Custom Order" />
                                    </div>
                                    <div id="div_save" runat="server" style="padding: 0px 0px 8px 0px; margin-left: 6px">
                                        <div id="div_btnsave" style="display: block">
                                            <asp:Button ID="btn_saveReorder" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_btnsaveprocess'); return a;"
                                                OnClick="btnSaveOrder_Onclick" />
                                        </div>
                                        <div id="div_btnsaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </td>
                                <%--<td>
                                    
                                </td>--%>
                                <td style="padding-top: 44px;">
                                    <div class="productcategory_reorder_ddl">
                                        <asp:DropDownList ID="ddlCategorySelect" CssClass="normaltext" runat="server" Width="190px"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlCategorySelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div id="div_norecords" runat="server" style="display: none;">
                            <div id="padding" class="emptyrecords" align="center">
                                <span class="HeaderText" style="text-align: center">
                                    <%=objLanguage.GetLanguageConversion("No_Record_Found")%></span>
                            </div>
                        </div>
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="GridView1" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                    BorderWidth="0" OnNeedDataSource="grdPendingOrders_NeedDataSource" AllowPaging="false"
                                    AllowSorting="false" AutoGenerateColumns="false" ClientSettings-AllowRowsDragDrop="true"
                                    PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="500" ShowGroupPanel="true"
                                    Width="100%" ShowStatusBar="true" OnRowDrop="grdPendingOrders_RowDrop">
                                    <HeaderStyle Width="100px" Font-Bold="true" />
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="PriceCatalogueCategoryID"
                                        HorizontalAlign="NotSet" OverrideDataSourceControlSorting="true" Width="100%">
                                        <Columns>
                                            <telerik:GridDragDropColumn ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                ItemStyle-Width="10%" HeaderText="Reorder" DragImageUrl="~/images/drag_drop.gif"
                                                Visible="false">
                                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                            </telerik:GridDragDropColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="Contains" HeaderText="Reorder"
                                                HeaderStyle-Width="11%" ItemStyle-Width="11%" HeaderStyle-HorizontalAlign="Right"
                                                ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <div style="float: right; padding-right: 3px; width: 100px">
                                                        <center>
                                                            <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("ReOrder")%></center>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                        background-repeat: no-repeat; position: static;" align="center">
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="PriceCatalogueCategoryName"
                                                HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="42%" HeaderText="Category Name"
                                                ItemStyle-Width="30%" SortExpression="Description" UniqueName="Description" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        <%=objLanguage.GetLanguageConversion("Category_Name")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="float: left; cursor: pointer; width: 99%; overflow: hidden; height: 15px">
                                                        <asp:Label ID="lblPriceCatalogueCategoryName" runat="server" ToolTip='<%#Eval("PriceCatalogueCategoryName")%>'><%#Eval("PriceCatalogueCategoryName")%></a></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="Description"
                                                HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="42%" HeaderText="Description"
                                                ItemStyle-Width="30%" SortExpression="Description" UniqueName="Description" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                        <%=objLanguage.GetLanguageConversion("Description")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="float: left; cursor: pointer; width: 99%; overflow: hidden; height: 15px">
                                                        <asp:Label ID="lblDescription" runat="server" ToolTip=' <%#Eval("Description")%>'><%#Eval("Description")%></a></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true"
                                        AllowDragToGroup="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        //        function Show_accountListDiv() {
        //            showDivPopupCenter('div_accountsList', '200');
        //        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

