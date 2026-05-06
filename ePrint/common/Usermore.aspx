<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Usermore.aspx.cs" Inherits="ePrint.common.Usermore" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdScreenName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdScreenName" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <table cellspacing="0" cellpadding="0" width="100%" class="estore_settingBox" align="left"
        border="0">
        <tr>
            <td style="display: none;">
                <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0" height="26">
                    <tr>
                        <td width="1%" valign="top" align="left" class="bgcustomize">
                            <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                        </td>
                        <td width="98%" class="bgcustomize" align="left">
                            <%--background="<%=strImagepath%>r2.jpg"--%>
                            <span class="navigatorpanel">
                                <%=objLanguage.GetLanguageConversion("Tab_Setting_For")%>&nbsp;</span>
                            <asp:Label ID="lblusertype" runat="server" CssClass="navigatorpanel" Style="vertical-align: top"></asp:Label>
                        </td>
                        <td width="1%" valign="top" align="right" class="bgcustomize">
                            <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" border="0" height="5" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <UC:Header_MIS ID="header_mis" runat="server" />
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr>
                                    <td>
                                        <img alt="" src="<%=strImagepath%>nil.gif" width="1" height="7" />
                                    </td>
                                </tr>
                                <tr>
                                    <div align="left" style="width: 100%;">
                                        <div style="width: 50%; padding: 10px 0px 0px 10px; margin-bottom: -10px;">
                                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                                <ContentTemplate>
                                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </tr>
                                <tr>
                                    <td>
                                        <img alt="" src="<%=strImagepath%>nil.gif" width="1" height="5" />
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td width="10px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlGrid" runat="server">
                                            <telerik:RadGrid ID="grdScreenName" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                                BorderWidth="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false"
                                                ClientSettings-AllowRowsDragDrop="true" PagerStyle-AlwaysVisible="true" GroupingEnabled="false"
                                                ShowGroupPanel="false" ShowStatusBar="true" Width="35%" OnItemDataBound="grdScreenName_ItemDataBound"
                                                OnRowDrop="grdScreenName_RowDrop">
                                                <%-- OnRowDrop="RadGrid1_RowDrop"--%>
                                                <HeaderStyle Font-Bold="true" />
                                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                <PagerStyle Mode="NextPrevAndNumeric" />
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Usertabid,HeaderID" HorizontalAlign="NotSet"
                                                    OverrideDataSourceControlSorting="true">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-Width="350px" ItemStyle-Width="350px" UniqueName="TabName" HeaderText="Sections">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTabName" runat="server" Text='<%#Eval("tabName") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="2%" ItemStyle-Width="2%" UniqueName="Display" HeaderText="Display">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <input type="checkbox" runat="server" id="chkDisplay" name="Id" checked='<%#Eval("IsDisplay") %>'
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.HeaderID", "{0}") %>' />
                                                                    <asp:Image ID="imgDisplay" runat="server" Visible="false" />
                                                                    <asp:PlaceHolder ID="plhImg" runat="server"></asp:PlaceHolder>
                                                                </center>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="Screen Name"
                                                            UniqueName="ScreenName">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtScreenName" runat="server" Text='<%#Eval("ScreenName") %>' MaxLength="14"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnHeaderName" runat="server" Value='<%#Eval("HeaderName") %>' />
                                                                <asp:Label ID="lblScreenName" runat="server" Text='<%#Eval("ScreenName") %>' Visible="false"
                                                                    Width="50px"></asp:Label>
                                                                <asp:RequiredFieldValidator ID="reqScreenName" runat="server" ControlToValidate="txtScreenName"
                                                                    ErrorMessage="Please Enter ScreenName" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Reorder"
                                                            UniqueName="Action" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                                            <ItemTemplate>
                                                                <div>
                                                                    <center>
                                                                        <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                            background-repeat: no-repeat; margin: 0px 0px 0px 12px;">
                                                                    </center>
                                                                </div>
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
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" style="margin-left: 5px;">
                                <tr>
                                    <%-- <td style="width: 16%">
                                    </td>--%>
                                    <td style="padding-bottom: 5px;">
                                        <span style="padding-left: 16%"></span>&nbsp;
                                        <div id="div_btnsave" style="display: block">
                                            <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click"
                                                CausesValidation="true" />
                                        </div>
                                        <div id="div_btnsaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 2px;" class="loadingimg"
                                                alt="loading" border="0" />
                                        </div>
                                    </td>
                                    <td style="display: none">
                                        <asp:Button ID="btncancel" runat="server" CssClass="button" CausesValidation="False"
                                            Text="Cancel" OnClick="btncancel_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function onRowDropping(sender, args) {
            if (sender.get_id() == "<%=grdScreenName.ClientID %>") {

                var node = args.get_destinationHtmlElement();
                if (!isChildOf('<%=grdScreenName.ClientID %>', node) && !isChildOf('<%=grdScreenName.ClientID %>', node)) {
                    args.set_cancel(true);
                }
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
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
