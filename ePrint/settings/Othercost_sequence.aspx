<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true"  CodeBehind="Othercost_sequence.aspx.cs" Inherits="ePrint.settings.Othercost_sequence" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        div.RadListBox .rlbTransferTo, div.RadListBox .rlbTransferToDisabled, div.RadListBox .rlbTransferAllToDisabled, div.RadListBox .rlbTransferAllTo
        {
            display: none;
        }
    </style>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-top: -8px;
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
    <%--By Jagat On 25/July--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridAvailableOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlCategory" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridAvailableOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnMove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridAvailableOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnReMove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridAvailableOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnSave" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left; width: 100%" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Othercost_Sequence")%></asp:Label>
                            <asp:Label ID="lblphrase" runat="server" Text="SASA" Visible="false" Style="display: block;"></asp:Label>
                            <asp:HiddenField runat="server" ID="hdn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel" style="margin-left: 10px">
            <div style="width: 100%;">
                <div style="width: 100%;">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="float: left; width: 15%; margin-left: -10px">
                <asp:UpdatePanel ID="update_EstTypes" runat="server" UpdateMode="Conditional" RenderMode="Block">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%;" height="80%">
                            <tr>
                                <td valign="top" style="border: solid 1px #cccccc;">
                                    <div class="only5px">
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td style="padding-right: 10px; padding-left: 10px" width="17%" valign="top">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td>
                                                                        <b>
                                                                            <%=objLanguage.GetLanguageConversion("Sheet_Fed_Digital")%></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table id="tableID1" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                                <tr class="VMenu">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0"
                                                                            style="padding-left: 0px;">
                                                                    </td>
                                                                    <td width="100%" id="Td_0" style="cursor: pointer" nowrap="nowrap" class="Caption2Out"
                                                                        onclick="javascript:return Showhidesequence('S',this.id);">
                                                                        <%=objLanguage.GetLanguageConversion("Single_Item")%>
                                                                    </td>
                                                                </tr>
                                                                <tr class="VMenu">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_1" onclick="javascript:return Showhidesequence('B',this.id);"
                                                                        class="Caption2Out" style="cursor: pointer" nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Booklet")%>
                                                                    </td>
                                                                </tr>
                                                                <tr class="VMenu">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_2" style="cursor: pointer" class="Caption2Out" onclick="javascript:return Showhidesequence('P',this.id);"
                                                                        nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Pads")%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td>
                                                                        <b>
                                                                            <%=objLanguage.GetLanguageConversion("Sheet_Fed_Offset")%></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table id="tableID4" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                                <tr class="VMenu">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_3" style="cursor: pointer" class="Caption2Out" onclick="javascript:return Showhidesequence('F',this.id);"
                                                                        nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Single_Item") %>
                                                                    </td>
                                                                </tr>
                                                                <tr class="VMenu" onmouseover="tdOver(this,'Td21')" onmouseout="tdOut(this,'Td21')">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_4" style="cursor: pointer" class="Caption2Out" onclick="javascript:return Showhidesequence('D',this.id);"
                                                                        nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Pads") %>
                                                                    </td>
                                                                </tr>
                                                                <tr class="VMenu" onmouseover="tdOver(this,'Td22')" onmouseout="tdOut(this,'Td22')">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_5" style="cursor: pointer" class="Caption2Out" onclick="javascript:return Showhidesequence('N',this.id);"
                                                                        nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("NCR")%>
                                                                    </td>
                                                                </tr>
                                                                <tr class="VMenu" onmouseover="tdOver(this,'Td33')" onmouseout="tdOut(this,'Td33')">
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td class="VMenuIcon">
                                                                        <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                                    </td>
                                                                    <td width="100%" id="Td_6" style="cursor: pointer" class="Caption2Out" onclick="javascript:return Showhidesequence('K',this.id);"
                                                                        nowrap="nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Booklet")%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td width="100%" id="Td_7" style="cursor: pointer; height: 20px;" class="Caption2Out"
                                                                        nowrap="nowrap" onclick="javascript:return Showhidesequence('L',this.id);">
                                                                        <asp:Label ID="lbl_LargeFormate" runat="server"> <b><%=objLanguage.GetLanguageConversion("Large_Format")%></b></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td width="100%" id="Td_8" nowrap="nowrap" style="cursor: pointer; height: 20px;"
                                                                        class="Caption2Out" onclick="javascript:return Showhidesequence('O',this.id);">
                                                                        <b>
                                                                            <%=objLanguage.GetLanguageConversion("Outwork")%></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td width="100%" id="Td_9" nowrap="nowrap" style="cursor: pointer; height: 20px;"
                                                                        class="Caption2Out" onclick="javascript:return Showhidesequence('W',this.id);">
                                                                        <b>
                                                                            <%=objLanguage.GetLanguageConversion("Warehouse")%></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 2%">
                                                                    </td>
                                                                    <td width="100%" id="Td_10" nowrap="nowrap" style="cursor: pointer; height: 20px;"
                                                                        class="Caption2Out" onclick="javascript:return Showhidesequence('C',this.id);">
                                                                        <b>
                                                                            <%=objLanguage.GetLanguageConversion("Product_Catalogue")%></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="only10px">
                </div>
            </div>
            <div style="float: left; width: 5px;">
                &nbsp;</div>
            <div style="float: left; width: 80%;">
                <div align="left" id="div_category" runat="server" style="display: block; padding-bottom: 8px;
                    margin-top: -12px;">
                    <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <fieldset style="width: 100%; height: 100%; margin-left: 10px; margin-top: 10px;
                                padding: 10px 0px 8px 10px;">
                                <legend>
                                    <asp:Label runat="server"><%=objLanguage.GetLanguageConversion("Other_Cost_Sequence")%></asp:Label></legend>
                                <div align="left" style="width:100%;">
                                    <div class="bglabel" style="width: 18%;">
                                        <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box">
                                        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="normalText" Width="50%"
                                            OnSelectedIndexChanged="ddlcategory_OnSelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <span id="spn_ddlCategory" class="spanerrorMsg" style="display: none; width: 175px">
                                            Please select Category</span>
                                        <asp:HiddenField ID="hid_CategoryID" runat="server"></asp:HiddenField>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </div>
                                <div align="left" id="div_list_new">
                                    <table id="Table1" runat="server" width="99%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="47%">
                                                <strong>
                                                    <asp:Label runat="server"><%=objLanguage.GetLanguageConversion("Available_Other_Cost")%></asp:Label></strong>
                                                <div class="only5px">
                                                </div>
                                                <telerik:RadGrid runat="server" ID="GridAvailableOtherCost" OnNeedDataSource="GridAvailableOtherCost_NeedDataSource"
                                                    AllowPaging="True" Width="100%" OnRowDrop="grdAvailableOtherCost_RowDrop" AllowMultiRowSelection="true"
                                                    BorderWidth="0" CssClass="RadGrid_Eprint_Skin" PageSize="200" EnableHeaderContextMenu="true"
                                                    AutoGenerateColumns="false" AllowFilteringByColumn="true" Height="400px">
                                                    <GroupingSettings CaseSensitive="false" />
                                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                    <HeaderStyle Width="120px" />
                                                    <MasterTableView DataKeyNames="OtherCostID" TableLayout="Fixed">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                                <HeaderTemplate>
                                                                    <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <input type="checkbox" runat="server" id="Id_1" onclick="CheckChanged('move');" name="Id"
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>' />
                                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridDragDropColumn HeaderStyle-Width="5%" Visible="false" />
                                                            <telerik:GridTemplateColumn SortExpression="OthercostName" HeaderText="Other Cost Name"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="OthercostName"
                                                                HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderTemplate>
                                                                    <div>
                                                                        <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Other_Cost_Name")%></div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left; width: 99%;">
                                                                        <a title='<%#Eval("OthercostName")%>'>
                                                                            <asp:Label ID="lblCostName" CssClass="normalText" runat="server" Text='<%#Eval("OthercostName")%>'></asp:Label></a>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="Description"
                                                                HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderTemplate>
                                                                    <div>
                                                                        <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Description")%></div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left; width: 99%;">
                                                                        <a title='<%#Eval("OthercostName")%>'>
                                                                            <asp:Label ID="lblDescription" CssClass="normalText" runat="server" Text='<%#Eval("Description")%>'></asp:Label></a>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ClientSettings AllowRowsDragDrop="True">
                                                        <Resizing AllowColumnResize="true" />
                                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                        <ClientEvents OnRowDropping="onRowDropping" />
                                                        <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="400px" />
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                            </td>
                                            <td style="padding: 0px 15px 0px 15px;">
                                                <asp:LinkButton ID="btnMove" runat="server" Text=">>" ToolTip="Move" CssClass="button"
                                                    OnClientClick="javascript:return CallSelect('move');" OnClick="BtnMove_Onclick"></asp:LinkButton>
                                                <div class="only10px">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <asp:LinkButton ID="btnReMove" runat="server" Text="<<" ToolTip="Remove" CssClass="button"
                                                    OnClientClick="javascript:return CallSelect('remove');" OnClick="BtnReMove_Onclick"></asp:LinkButton>
                                            </td>
                                            <td width="47%">
                                                <strong>
                                                    <asp:Label runat="server"><%=objLanguage.GetLanguageConversion("Selected_Other_Cost")%></asp:Label></strong>&nbsp;
                                                <div class="only5px">
                                                </div>
                                                <telerik:RadGrid runat="server" Width="100%" AllowPaging="True" ID="GridSelectedOtherCost"
                                                    OnNeedDataSource="grdSelectedOtherCost_NeedDataSource" OnRowDrop="grdSelectedOtherCost_RowDrop"
                                                    BorderWidth="0" AllowMultiRowSelection="true" PageSize="200" Height="400px" CssClass="RadGrid_Eprint_Skin"
                                                    AutoGenerateColumns="false" AllowFilteringByColumn="true">
                                                    <GroupingSettings CaseSensitive="false" />
                                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                    <MasterTableView DataKeyNames="OtherCostID" Width="100%">
                                                        <Columns>
                                                            <telerik:GridDragDropColumn Visible="false" />
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="12%" ItemStyle-Width="12%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                                <HeaderTemplate>
                                                                    <input type="checkbox" id="checkAll_2" onclick="CheckAll_New(this);" runat="server"
                                                                        name="checkAll" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left;">
                                                                        <input type="checkbox" runat="server" id="Id_2" onclick="CheckChanged('remove');"
                                                                            name="Id" value='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>' />
                                                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>'></asp:Label>
                                                                    </div>
                                                                    <a title="Reorder">
                                                                        <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                            float: right; background-repeat: no-repeat; padding 0px 0px 0px 10px;" align="right">
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn SortExpression="OthercostName" HeaderText="Other Cost Name"
                                                                CurrentFilterFunction="Contains" HeaderStyle-Width="30%" ItemStyle-Width="30%"
                                                                DataField="OthercostName" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                AutoPostBackOnFilter="true">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <div style="float: left;">
                                                                        <a title='<%#Eval("OthercostName")%>'>
                                                                            <asp:Label ID="lblOtherCostName" CssClass="normalText" runat="server" Text='<%#Eval("OthercostName")%>'></asp:Label></a>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                HeaderStyle-Width="12%" ItemStyle-Width="12%" HeaderText="Mandatory" HeaderStyle-Wrap="false"
                                                                AllowFiltering="false">
                                                                <HeaderTemplate>
                                                                    <div>
                                                                        <center>
                                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Mandatory")%></center>
                                                                    </div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:CheckBox ID="Id_3" runat="server" Checked='<%# Eval("isMandatory") %>' /></center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                        <NoRecordsTemplate>
                                                            <div style="height: 30px; cursor: pointer;">
                                                                <%=objLanguage.GetLanguageConversion("No_Records_Available")%></div>
                                                        </NoRecordsTemplate>
                                                    </MasterTableView>
                                                    <ClientSettings AllowRowsDragDrop="True">
                                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                        <ClientEvents OnRowDropping="onRowDropping" />
                                                        <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="425px" />
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="BtnSave_Onclick" /><%--OnClick="btnSave_OnClick"--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </fieldset>
                            <asp:LinkButton ID="lnkShowSequence" runat="server" OnClick="lnkShowSequence_OnClick"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <asp:HiddenField ID="hdn_Estimatetype" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Actiontype" runat="server" Value="" />
    <asp:HiddenField ID="hid_OtherCostMoveOrders" runat="server" Value="" />
    <asp:HiddenField ID="hid_OtherCostRemoveOrders" runat="server" Value="" />
    <script type="text/javascript">
        var hdn_Estimatetype = document.getElementById("<%=hdn_Estimatetype.ClientID %>");
        var div_category = document.getElementById("<%=div_category.ClientID %>");
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var TakeTimaeCount = 0;
        function Showhidesequence(estimatetype, TdId) {
            var itemID = TdId.split('_');
            for (var i = 0; i <= 10; i++) {
                if (i == itemID[1]) {
                    document.getElementById("Td_" + i).style.backgroundColor = "#DFDFDF";
                }
                else {
                    document.getElementById("Td_" + i).style.backgroundColor = "#FFFFFF";
                }
            }

            hdn_Estimatetype.value = estimatetype;
            div_category.style.display = "block";
            __doPostBack('ctl00$ContentPlaceHolder1$lnkShowSequence', '')
            return false;
        }

        function tdOver(obj, id) {


        }

        function tdOut(obj, id) {
        }
    
    </script>
    <script type="text/javascript">

        //function CallonChange(val, spanid) {
        //    if (trim12(val) != "0") {
        //        document.getElementById(spanid).style.display = "none";
        //        return false;
        //    }
        //    else {
        //        document.getElementById(spanid).style.display = "block";
        //        return true;
        //    }
        //}

        function estimate(val) {
            try {
                if (val == 'block') {

                    document.getElementById("showestimate").style.display = 'none'
                    document.getElementById("estimate").style.display = 'block'
                }
                else {

                    document.getElementById("showestimate").style.display = 'block'
                    document.getElementById("estimate").style.display = 'none'
                }
            }
            catch (err) {

            }

            return false;
        }

        function email(val) {
            try {
                if (val == 'none') {

                    document.getElementById("showemail").style.display = 'block';
                    document.getElementById("email").style.display = 'none';
                }
                else {

                    document.getElementById("showemail").style.display = 'none';
                    document.getElementById("email").style.display = 'block';
                }
            }
            catch (err) {
            }
        }

        var EstimateType = '<%=EstimateType %>'
        Showhidesequence(EstimateType, '');

        if (EstimateType == "S") {
            document.getElementById("Td_0").style.backgroundColor = "#DFDFDF";
        }


        function CheckChanged(value) {
            var frm = '';
            frm = document.forms[0];
            if (value == "move") {
                var boolAllChecked; boolAllChecked = true;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1)
                        if (e.checked == false) {
                            boolAllChecked = false; break;
                        }
            }
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) {
                    if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
                }
            }
        }
        else if (value == "remove") {
            var boolAllChecked; boolAllChecked = true;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1)
                    if (e.checked == false) {
                        boolAllChecked = false; break;
                    }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_2') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }
}

function CheckAll(checkAllBox) {

    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) e.checked = ChkState;
    }
}
function CallSelect(value) {

    var hid_OtherCostMoveOrders = document.getElementById("<%=hid_OtherCostMoveOrders.ClientID%>");
    var ret = CheckOne(value);
    if (ret) {
        CheckGrid();
        var IDs = '';
        var frm = '';
        if (value == 'move') {
            frm = document.getElementById("<%=GridAvailableOtherCost.ClientID%>").getElementsByTagName("input");
        }
        else if (value == 'remove') {
            frm = document.getElementById("<%=GridSelectedOtherCost.ClientID%>").getElementsByTagName("input");
        }
        var i = 1;

        if (value == 'move') {
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id_1') != -1) {
                    if (frm[l].type == "checkbox") {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
            }
            document.cookie = "OtherCostMoveOrders=" + IDs;
        }
        else {
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id_2') != -1) {
                    if (frm[l].type == "checkbox") {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
            }
            document.cookie = "OtherCostRemoveOrders=" + IDs;
        }
        return true;

    }
    else {
        return false;
    }

}

function CheckGrid() {
    clsTimeID = setInterval("CheckFor1min()", 800);
}

function CheckOne(value) {
    var Counter = 0;
    var frm = '';
    var frm = document.forms[0];
    if (value == "move") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }
    else if (value == "remove") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }
    if (Number(Counter) == 0) {
        if (value == "move") {
            alert("Please check at least one row to Move");
        }
        else if (value == "remove") {
            alert("Please check at least one row to Remove");
        }
        return false;
    }
    else {
        return true;
    }
}

function onRowDropping(sender, args) {
    if (sender.get_id() == "<%=GridAvailableOtherCost.ClientID %>") {

        var node = args.get_destinationHtmlElement();
        if (!isChildOf('<%=GridSelectedOtherCost.ClientID %>', node) && !isChildOf('<%=GridAvailableOtherCost.ClientID %>', node)) {
            args.set_cancel(true);
        }
    }

}

function CheckAll_New(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('checkAll_2') != -1) e.checked = ChkState;
    }
}

function CheckFor1min() {
    if (hidGridCount.value != '') {
        clearInterval(clsTimeID);
        CallScroll();
    }
    TakeTimaeCount++;

    if (TakeTimaeCount > 20) {
        clearInterval(clsTimeID);
    }
}

function isChildOf(parentId, element) {
    while (element) {
        if (element.id && element.id.indexOf(parentId) > -1) {
            return true;
        }
        element = element.parentNode;
    }
    return false;
}

function ValidateOtherCostSequanceCategory() {
    var ddlCategory = document.getElementById("<%=ddlCategory.ClientID%>");
    if (Number(ddlCategory.options[ddlCategory.selectedIndex].value) == Number(0)) {
        document.getElementById("spn_ddlCategory").style.display = "block";
    } else {
        document.getElementById("spn_ddlCategory").style.display = "none";
    }
}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
