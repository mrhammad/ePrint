<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="import_order.aspx.cs" Inherits="ePrint.Import_Order.import_order" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--  <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID %>';
        var DateFormat = '<%=DateFormat %>';
    </script>
    <style type="text/css">
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -9px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-left: -12px;
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
        
        .element
        {
            margin-top: -12px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="hdnrecordtype" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div style="float: left;" id="pnldetails" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div class="mis_header_panel">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <div class="normaltext bglabel" style="width: 200px; margin: 0px 0px 0px 0px; height: 16px;">
                                        <asp:Label ID="lblBrowseFile" runat="server" class="normaltext"><%=objLanguage.GetLanguageConversion("Browse_File")%></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileuploadBrowseFile" runat="server" CssClass="textboxnew" />
                                </td>
                                <td align="left">
                                    <div style="float: left;">
                                        <asp:RequiredFieldValidator ID="rfvFileUpload" Style="vertical-align: middle; background-color: #FFEBE8;
                                            border: 1px solid #DD3C10; font-family: 'Verdana', Verdana, Arial, Helvetica;
                                            font-size: 11px; font-weight: bold; color: #333333;" ControlToValidate="fileuploadBrowseFile"
                                            runat="server" Display="Dynamic" ValidationGroup="vf" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                    <div style="float: left;">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileuploadBrowseFile"
                                            Style="vertical-align: middle; background-color: #FFEBE8; border: 1px solid #DD3C10;
                                            font-family: 'Verdana', Verdana, Arial, Helvetica; font-size: 11px; font-weight: bold;
                                            color: #333333;" Display="Dynamic" ValidationGroup="vf" ValidationExpression="^.+(.csv|.CSV)$"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <div style="float: left; margin-left: 1px;">
                                        <asp:Label ID="lblNote" runat="server" class="smallerfontgrey"><%=objLanguage.GetLanguageConversion("HelpText_of_OrderImport")%></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="margin-top: -2px; margin-left: 5px;">
                                        <asp:LinkButton ID="lnkDownloadFile" runat="server" Style="color: #10357F;" OnClick="lnkDownLoadDefault_Click"></asp:LinkButton>
                                    </div>
                                </td>
                                <td colspan="2">
                                    <div class="box" style="margin-top: 4px;">
                                        <div style="display: inline; float: left;">
                                            <div id="div_btn_cancel" style="float: left;">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick">
                                                </asp:Button>
                                            </div>
                                            <div id="div_btn_cancelprocess" class="button" align="center" style="height: 14px;
                                                width: 43px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="display: inline; float: left; margin-left: 13px;">
                                            <div id="div_btnsave" style="float: left;">
                                                <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" ValidationGroup="vf"
                                                    OnClick="btnSave_OnClick" />
                                            </div>
                                            <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 43px;
                                                display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-top: 20px;">
                        <div>
                            <asp:Label ID="lblImportHistory" runat="server" Style="color: #7d7d7d; font-weight: bold;
                                font-size: 14px; margin-left: 9px;"><%=objLanguage.GetLanguageConversion("Import_History")%></asp:Label>
                        </div>
                        <div style="margin-left: 3px;">
                            <telerik:RadGrid ID="grdImportHistory" runat="server" AutoGenerateColumns="False"
                                BorderWidth="0" PageSize="50" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                                AllowPaging="True" Width="50%" PagerStyle-AlwaysVisible="true" GroupingEnabled="False"
                                AllowSorting="True" ShowGroupPanel="True" GridLines="None" AllowFilteringByColumn="false"
                                OnItemDataBound="grdImportHistory_RowDataBound">
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView DataKeyNames="OrderImportID" ToolTip="" CommandItemDisplay="Top">
                                    <CommandItemTemplate>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                            AutoPostBackOnFilter="true">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div style="height: 15px; width: 100%;">
                                                    <asp:Label ID="lblFileName" runat="server"><%=objLanguage.GetLanguageConversion("File_Name")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="height: 15px; width: 100%;">
                                                    <a href="<%=strSitepath %>Import_Order/orderimportitems.aspx?id=<%#Eval("OrderImportID")%>">
                                                        <%#Eval("ActualFileName")%></a>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Height="20px" Wrap="False" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                            AutoPostBackOnFilter="true">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <HeaderStyle Font-Bold="true" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderTemplate>
                                                <div style="height: 15px;">
                                                    <asp:Label ID="lblDateImported" runat="server"><%=objLanguage.GetLanguageConversion("Date_Imported")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="height: 15px;">
                                                    <asp:Label ID="lblItemDateImported" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedDate", "{0}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Height="20px" Wrap="False" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                            AutoPostBackOnFilter="true">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <HeaderStyle Font-Bold="true" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderTemplate>
                                                <div style="height: 15px;">
                                                    <asp:Label ID="lblStatus" runat="server"><%=objLanguage.GetLanguageConversion("Status")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="height: 15px;">
                                                    <asp:Label ID="lblItemStatus" runat="server" Text='<%#Eval("IsImported")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Height="20px" Wrap="False" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                            AutoPostBackOnFilter="true">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div style="height: 15px; width: 100%">
                                                    <asp:Label ID="lblComments" runat="server"><%=objLanguage.GetLanguageConversion("Comments")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="height: 15px; width: 100%;">
                                                    <asp:Label ID="lblItemComments" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Height="20px" Wrap="False" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <PagerStyle AlwaysVisible="True" />
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
            language="javascript">
        </script>
        <script type="text/javascript">
            //            function loadingimage() {

            //            }
        </script>
    </div>
</asp:Content>
