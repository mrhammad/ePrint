<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="user_manager.aspx.cs" Inherits="ePrint.settings.user_manager" title="Settings: User" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .LockBtn
        {
            background-image: url(../images/lockclosed.png);
            cursor: pointer;
            display: block;
            height: 20px;
            width: 25px;
            background-repeat: no-repeat;
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
            margin-left: -8px;
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
            margin-top: -8px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridRole">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridRole" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("User_Manager")%></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div style="z-index: -20000; margin-top: -10px;" class="mis_header_panel11">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <br />
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <fieldset>
                        <legend id="lgdrole" runat="server"><b>
                            <%#objLanguage.GetLanguageConversion("Roles")%></b></legend>
                        <div align="left" style="width: 100%">
                            <div id="a">
                            </div>
                            <div id="div_Grid" style="z-index: -10000; margin-left: 6px">
                                <telerik:RadGrid Width="60%" ID="GridRole" GridLines="None" DataSourceID="SqlDataSource2"
                                    BorderWidth="0" runat="server" AllowAutomaticDeletes="True" ShowStatusBar="true"
                                    AllowAutomaticInserts="false" PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True"
                                    AutoGenerateColumns="False" OnItemDataBound="GridRole_OnItemDataBound" OnPageIndexChanged="GridRole_PageIndexChanged"
                                    OnPageSizeChanged="GridRole_PageSizeChanged" HeaderStyle-Font-Bold="true" GroupingSettings-CaseSensitive="false"
                                    AllowFilteringByColumn="true" OnPreRender="GridRole_PreRender" EnableLinqExpressions="false">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView PagerStyle-AlwaysVisible="true" Width="100%" CommandItemDisplay="Top"
                                        DataKeyNames="" HorizontalAlign="NotSet" AutoGenerateColumns="False">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <td align="left" style="text-decoration: underline">
                                                    <a href="roles_add.aspx?type=add">
                                                        <%=objLanguage.GetLanguageConversion("Add_New_Record")%></a>
                                                </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn SortExpression="Role" HeaderText="Role" HeaderStyle-Width="30%"
                                                ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="usertype">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Role")%></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a style="cursor: pointer;" href='<%=strSitepath %>settings/roles_edit.aspx?roleid=<%#DataBinder.Eval(Container.DataItem,"usertypeid") %>'>
                                                        <div style="float: left; width: 100%; overflow: hidden; cursor: pointer;">
                                                            <asp:Label ID="lblUserType1" Text=' <%# DataBinder.Eval(Container.DataItem, "usertype")%> '
                                                                runat="server"></asp:Label>
                                                            <%--<%# DataBinder.Eval(Container.DataItem, "usertype")%>--%>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                                HeaderStyle-Width="40%" ItemStyle-Width="40%" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="description">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Description")%></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a style="cursor: pointer;" href='<%=strSitepath %>settings/roles_edit.aspx?roleid=<%#DataBinder.Eval(Container.DataItem,"usertypeid") %>'>
                                                        <div style="float: left; width: 99%; overflow: hidden; cursor: pointer">
                                                            <asp:Label ID="lblbDescription" Text='  <%# DataBinder.Eval(Container.DataItem, "description")%> '
                                                                runat="server"></asp:Label>
                                                            <%-- <%# DataBinder.Eval(Container.DataItem, "description")%>--%>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Generated Type" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Generated_Type")%></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a style="cursor: pointer" href='<%=strSitepath %>settings/roles_edit.aspx?roleid=<%#DataBinder.Eval(Container.DataItem,"usertypeid") %>'>
                                                        <div style="float: left; width: 100%; overflow: hidden; cursor: pointer">
                                                            <asp:Label ID="lblUserType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "usertype")%>'
                                                                Style="display: none"></asp:Label>
                                                            <asp:Label ID="lblGenerateType" runat="server"></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <%-- By Jagat On 06/July/2012--%>
                                            <%--<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Right" HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href='<%=strSitepath%>settings/roles_edit.aspx?roleid=<%#DataBinder.Eval(Container.DataItem,"usertypeid") %>'>
                                                        <asp:Image ID="imgbtnEdit" runat="server" ImageUrl="~/images/edit.gif" ToolTip="Edit" />
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>--%>
                                            <%--End--%>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="PC_settings_user_rolegrid_select"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                            Type="int32" />
                                        <asp:ControlParameter ControlID="hdnFIlter" Name="FilterCondition" Type="String"
                                            DefaultValue="isdelete=0" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <asp:HiddenField ID="hdnFIlter" runat="server" />
                        </div>
                        <div class="only10px">
                        </div>
                        <div class="smallgraytext">
                            <%#objLanguage.GetLanguageConversion("Systemgenerate_Roles_Delete_Note")%>
                        </div>
                        <div style="clear: both">
                            &nbsp;</div>
                        <div style="float: left; cursor: pointer;">
                        </div>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="clear: both">
                &nbsp;</div>
            <div align="left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset>
                            <legend id="lgdusr" runat="server"><b>
                                <%#objLanguage.GetLanguageConversion("Users")%></b></legend>
                            <div align="left" style="width: 100%">
                                <div id="div_TotalRecUser" style="float: right; padding-right: 450px">
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div align="left" style="width: 100%; margin-top: -12px; margin-left: 7px;" nowrap="nowrap">
                                <div id="a1">
                                </div>
                                <div id="div_Grid1">
                                    <br />
                                    <telerik:RadGrid OnInsertCommand="RadGrid2_InsertCommand" OnUpdateCommand="RadGrid2_UpdateCommand"
                                        Width="60%" ID="RadGrid2" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                        BorderWidth="0" PagerStyle-AlwaysVisible="true" ShowStatusBar="true" AllowAutomaticInserts="false"
                                        PageSize="50" AllowAutomaticUpdates="false" AllowPaging="True" DataSourceID="SqlDataSource1"
                                        HeaderStyle-Font-Bold="true" AutoGenerateColumns="False" OnPageIndexChanged="RadGrid2_PageIndexChanged"
                                        OnPageSizeChanged="RadGrid2_PageSizeChanged" OnItemDataBound="RadGrid2_OnItemDataBound"
                                        AllowFilteringByColumn="true" OnPreRender="RadGrid2_PreRender">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="UserID" HorizontalAlign="NotSet"
                                            AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td align="left" style="text-decoration: underline">
                                                            <a href="user_add.aspx?type=add" onclick="javascript:return RestrictedPopUp();">
                                                                <%=objLanguage.GetLanguageConversion("Add_New_Record")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn SortExpression="Role" HeaderText="User Name" HeaderStyle-Width="30%"
                                                    ItemStyle-Width="25%" Visible="true" HeaderStyle-HorizontalAlign="Left" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" DataField="FirstName">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("User_Name")%></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href='<%=strSitepath%>settings/user_add.aspx?type=edit&userid=<%#Eval("UserId")%>'>
                                                            <div style="float: left; width: 99%; overflow: hidden; cursor: pointer;">
                                                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserId")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn SortExpression="Email" HeaderText="Email" HeaderStyle-Width="30%"
                                                    ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="Left" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" DataField="Email">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Email")%></div>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <a href='<%=strSitepath%>settings/user_add.aspx?type=edit&userid=<%#Eval("UserId")%>'>
                                                            <div style="float: left; width: 100%; overflow: hidden; cursor: pointer;">
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn SortExpression="usertypename" HeaderText="User Role"
                                                    HeaderStyle-Width="20%" ItemStyle-Width="20%" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="usertypename">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("User_Role")%></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href='<%=strSitepath%>settings/user_add.aspx?type=edit&userid=<%#Eval("UserId")%>'>
                                                            <div style="float: left; width: 99%; overflow: hidden; cursor: pointer;">
                                                                <div style="float: left; width: 99%; overflow: hidden; cursor: pointer;">
                                                                    <asp:Label ID="lblUserRole" runat="server" Text='<%#Eval("usertypename")%>'></asp:Label>
                                                                </div>
                                                                <%--<asp:Label ID="lblUserRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "usertypename")%>'></asp:Label>--%>
                                                                <%--<%# DataBinder.Eval(Container.DataItem, "usertypename")%>--%>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn SortExpression="description" HeaderText="Description"
                                                    HeaderStyle-Width="25%" ItemStyle-Width="25%" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" DataField="description">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Description") %></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href='<%=strSitepath%>settings/user_add.aspx?type=edit&userid=<%#Eval("UserId")%>'>
                                                            <div style="float: left; width: 99%; overflow: hidden; cursor: pointer;">
                                                                <%# DataBinder.Eval(Container.DataItem, "description")%>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="1%" SortExpression="IsValid"
                                                    ItemStyle-Width="1%" DataField="isvalid" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <div style="margin: 0px auto; width: 60px">
                                                            <div style="float: left; padding-left: 20px">
                                                                <asp:ImageButton ImageUrl="~/images/lockclosed.png" Height="20px" Width="20px" ID="btnAction"
                                                                    runat="server" ToolTip="Click here to unlock" OnCommand="Onclick_BtnDisableAccount"
                                                                    CommandArgument='<%#Eval("UserID")%>' CausesValidation="false"></asp:ImageButton>
                                                            </div>
                                                        </div>
                                                        <div style="margin: 0px auto; width: 60px">
                                                            <div style="float: left; padding-left: 20px">
                                                                <asp:ImageButton ImageUrl="~/images/lockopen.png" Height="20px" Width="20px" ID="ImgLockUser"
                                                                    runat="server" ToolTip="Click here to lock" OnClientClick="javascript:return ConfirmLock();"
                                                                    OnCommand="Onclick_ImgLockUser" CommandArgument='<%#Eval("UserID")%>' CausesValidation="false">
                                                                </asp:ImageButton>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--  By Jagat On 07/July/2012--%>
                                                <%--  <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Right" HeaderText="Action">
                                                    <ItemTemplate>
                                                        <a href='<%=strSitepath%>settings/user_add.aspx?type=edit&userid=<%#Eval("UserId")%>'>
                                                            <asp:Image ID="imgbtnEdit" runat="server" ImageUrl="~/images/edit.gif" ToolTip="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <%--End--%>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                            <ClientEvents />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="PC_users_select"
                                        SelectCommandType="StoredProcedure" DeleteCommand="PC_settings_user_delete" DeleteCommandType="StoredProcedure"
                                        InsertCommand="PC_settings_user_insert" InsertCommandType="StoredProcedure" UpdateCommand="PC_settings_user_update"
                                        UpdateCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                            <asp:ControlParameter ControlID="hdnUserfilter" Name="FilterCondition" Type="String"
                                                DefaultValue=" a.isdelete=0" />
                                        </SelectParameters>
                                        <DeleteParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                            <asp:Parameter Name="UserID" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                            <asp:Parameter Name="Email" Type="String" />
                                            <asp:Parameter Name="Name" Type="String" />
                                            <asp:Parameter Name="Password" Type="String" />
                                            <asp:Parameter Name="UserType" Type="String" />
                                            <asp:Parameter Name="Description" Type="String" />
                                            <asp:Parameter Name="Disable" Type="String" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                            <asp:Parameter Name="UserID" Type="Int32" DefaultValue="0" />
                                            <asp:Parameter Name="Email" Type="String" />
                                            <asp:Parameter Name="Name" Type="String" />
                                            <asp:Parameter Name="Password" Type="String" />
                                            <asp:Parameter Name="UserType" Type="String" />
                                            <asp:Parameter Name="Description" Type="String" />
                                            <asp:Parameter Name="Disable" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" SelectCommand="PC_settings_user_rolegrid_select"
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <asp:HiddenField ID="hdnUserfilter" runat="server" />
                            </div>
                            <div style="clear: both">
                                &nbsp;</div>
                            <div style="float: left; cursor: pointer;">
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;</div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">

    var UserCount = <%=UserCount %>;
    var NoOfUser = <%=NoOfUser %>;
       var RestrictionMsg=  '<%=objLanguage.GetLanguageConversion("Sorry_maximum_user_creation_limit_is_over_please_contact_supporteprintsoftwarecom_to_create_more_user")%>';

        function CallScroll() {
            var GridID = document.getElementById("<%=GridRole.ClientID%>");
            var div_HeaderID = document.getElementById("a");
            var div_BodyID = document.getElementById("div_Grid");
            var OuterDivID = document.getElementById("div_test_1");
            var InnerDivID = document.getElementById("div_test_2");
            var DivTotalRecID = document.getElementById("div_TotalRec");
            startset(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);

            var GridID1 = document.getElementById("<%=RadGrid2.ClientID%>");
            var div_HeaderID1 = document.getElementById("a1");
            var div_BodyID1 = document.getElementById("div_Grid1");
            var OuterDivID1 = document.getElementById("div_test_1");
            var InnerDivID1 = document.getElementById("div_test_2");
            var DivTotalRecID1 = document.getElementById("div_TotalRecUser");
            startset(GridID1, div_HeaderID1, div_BodyID1, OuterDivID1, InnerDivID1, DivTotalRecID1);
        }

        function ConfirmLock(){
        var res=window.confirm('Are you sure you want to lock this User? this action canot be undone.');
        if (res) {
            return true;
            }
         else {
             return false;
           }
        }

    </script>
    <asp:Panel ID="pnlCallScroll" runat="server" Visible="false">
        <script>

            if ('<%=totalrec %>' != 0) {
            }
            function ImgButtonErase_ClientClick(GridID, ImageButtonID) {
                if (confirm('<%=objLanguage.GetLanguageConversion("Delete_Template_Confirmation")%>')) {

                    return true;
                }
                else {
                    return false;
                }
            }
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
