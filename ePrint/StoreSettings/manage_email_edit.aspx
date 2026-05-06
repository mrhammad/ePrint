<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_email_edit.aspx.cs" Inherits="ePrint.StoreSettings.manage_email_edit" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList"
    TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <%-- <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <!--POPUP START-->
    <div>
        <%--<UC:accountList ID="AccountList" runat="server" />--%>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
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
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Manage_Email_Edit")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp;
                                        <%--<a href="#?"
                                            rel="popup1" class="poplight" style="color: White; text-decoration: underline">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                            </a> </span>--%>
                                        <a id="A1" href="#" style="color: White; text-decoration: underline" runat="server"
                                            onclick="Show_accountListDiv();" visible="false">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %> </asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="height: auto;">
                <div align="left" style="width: 100%;">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div id="div_EmailEdit" class="manageedit">
                    <div>
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_Event" runat="server" Text="Event" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Event") %></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <%--<asp:TextBox ID="txt_Event" CssClass="textboxnew" runat="server" ReadOnly="true" ></asp:TextBox>--%>
                            <asp:Label ID="lbl_EventValue" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div>
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_Subject" runat="server" Text="Subject" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Subject") %></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:TextBox ID="txt_Subject" runat="server" Width="692px" Height="15px" CssClass="textboxnew"></asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div id="div_body" runat="server">
                        <div class="bglabel" style="width: 20%">
                            <asp:Label ID="lbl_body" runat="server" Text="Body" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Body") %></asp:Label>
                        </div>
                        <div>
                            <div style="float: left; width: 200px;">
                                <div class="box">
                                    <div id="divFckEditor" style="border: 0px solid; float: left;">
                                        <%--  <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/fckEditor/">
                                        </FCKeditorV2:FCKeditor>--%>
                                        <telerik:RadEditor ID="RadEditor1" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                            ExternalDialogsPath="~/RadEditorDialogs" ContentAreaMode="Iframe" imagemanager-viewmode="Grid"
                                            OnClientLoad="OnClientLoad">
                                            <Content>
                                                                          
                                            </Content>
                                            <CssFiles>
                                                <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                            </CssFiles>
                                        </telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div>
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_Activate" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Enable_This_Email")%></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:CheckBox ID="chk_Activate" runat="server" />
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div id="div_Artwork" runat="server">
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_Artwork" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Attachments")%></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:CheckBox ID="chk_Artwork" runat="server" />
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div id="dv_pdf" runat="server">
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lblOrderPdf" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Order_Template_As_Pdf")%></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:CheckBox ID="chk_OrderPdf" runat="server" />
                        </div>
                    </div>
                     <div style="clear: both;">
                    </div>
                    <%--<div>
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_Attachment" runat="server" Text="Attachment" CssClass="normaltext">Attachment</asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:CheckBox ID="chk_Attachment" runat="server" />
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>--%>
                    <div id="div_status" runat="server" style="display: none;">
                        <div class="bglabel" style="width: 20%;">
                            <asp:Label ID="lbl_status" runat="server" Text="Trigger this email when job status is changed to"
                                CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Trigger_This_Email_When_Job_Status_Is_Changed_To")%></asp:Label>
                        </div>
                        <div style="float: left; width: 200px;" class="box">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="Server" UpdateMode="conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlStatus" CssClass="normaltext" runat="server" Width="175px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div style="padding: 10px 0px 0px 0px">
                    <div class="bglabel" style="width: 21%; background-color: Transparent;">
                    </div>
                    <div style="float: left; width: 200px;" class="box">
                        <div style="display: inline; float: left; padding: 3px">
                            <div id="div_btn_cancel" style="display: block;">
                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_click" />
                            </div>
                            <div id="div_btn_cancelprocess" class="button" align="center" style="width: 44px;
                                display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="display: inline; float: left; padding: 3px">
                            <div id="div_btnsubmit" style="display: block">
                                <asp:Button ID="btn_submit" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_btnsubmitprocess');return a;"
                                    OnClick="btn_submit_Click" />
                            </div>
                            <div id="div_btnsubmitprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <br />
                <div id="events" style="width: 100%; padding: 5px 0px 10px 10px;">
                    <asp:UpdatePanel ID="UpdatePanel_CustomTags" runat="server" UpdateMode="Conditional"
                        ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <telerik:RadGrid ID="RadGrid_CustomTags" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
                                GroupingEnabled="false" PageSize="50" Width="700px" ShowGroupPanel="false" ShowStatusBar="true"
                                HeaderStyle-Font-Bold="true" OnItemDataBound="RadGrid_CustomTags_OnRowDataBound">
                                <HeaderStyle Width="100px" />
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="TagID" HorizontalAlign="NotSet"
                                    OverrideDataSourceControlSorting="true" Width="100%">
                                    <Columns>
                                        <telerik:GridTemplateColumn DataField="TagEvent" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="35%" HeaderText="Tag name" ItemStyle-Width="35%" UniqueName="TagEvent"
                                            Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden">
                                                    <input type='text' name="TagName" size="30" value='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'
                                                        onclick="this.select();" id="TagName" />
                                                    <asp:Label ID="lbl_TagEvent" runat="server"></asp:Label>
                                                </div>
                                                <%--<asp:Label ID="lbl_TagEvent" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'></asp:Label>--%>
                                                <asp:HiddenField ID="hdn_TagEvent" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'>
                                                </asp:HiddenField>
                                                <asp:HiddenField ID="hdn_TagName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TagName", "{0}") %>'>
                                                </asp:HiddenField>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="TagDescription" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="60%" HeaderText="Description" ItemStyle-Width="60%" UniqueName="TagEvent"
                                            Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Description")%>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="left" class="view_displayflex">
                                                    <div style="padding-top: 15px">
                                                        <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TagDescription", "{0}") %>'
                                                            Style="vertical-align: middle"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <table style="empty-cells: hide; border: 1px solid  transparent">
                                                            <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkProductName" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" clientidmode="Static" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkJobName" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" clientidmode="Static" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkQty" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkTotalprice" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkOrderedHeight" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkOrderedWidth" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkProductHeight" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkProductWidth" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkAdditionalOptions" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkOrderItemNumbers" runat="server" Visible="false" CssClass="chkBoxListEst"
                                                                        onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkItemCode" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkCustomerCode" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkUnitOfMeasure" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                          
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkItemDescription" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                          
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkWeight" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                            
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkCubicMeasurement" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                           </tr>
                                                             <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkOrderedWeight" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                           
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkOrderedCubicMeasurement" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                          
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkPerQuantity" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkDimensions" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                              </tr>
                                                            <%--  <tr>
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkWidth" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                          
                                                                <td style="border: 1px solid  transparent">
                                                                    <asp:CheckBox ID="chkHeight" runat="server" Visible="false" CssClass="chkBoxListEst" onclick="checkAll_new(this);" />
                                                                </td>
                                                              </tr>--%>
                                                            <tr>
                                                                <td colspan="4" style="border: 1px solid  transparent">
                                                                    <asp:Label ID="lbl_Helptext" runat="server" class="smallgraytext" Style="padding-left: 5px;
                                                                        vertical-align: top;" Visible="false">
                                                                        <%=objLanguage.GetLanguageConversion("Tick_the_items_you_want_to_include_in_the_product_details_tag")%>
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <div style="padding: 0px 0px 0px 10px">
                                            <%=objLanguage.GetLanguageConversion("No_Record_Found") %>
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                    AllowDragToGroup="false">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                </ClientSettings>
                            </telerik:RadGrid>
                            <%--<telerik:RadGrid ID="RadGrid_CustomTags" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
                                GroupingEnabled="false" PageSize="50" Width="700px" ShowGroupPanel="false" ShowStatusBar="true"
                                HeaderStyle-Font-Bold="true" EnableEmbeddedSkins="false" Skin="RadGrid_Eprint_Skin"
                                CssClass="RadGrid_Eprint_Skin" OnItemDataBound="RadGrid_CustomTags_OnRowDataBound">
                                <HeaderStyle Width="100px" />
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="TagID" HorizontalAlign="NotSet"
                                    OverrideDataSourceControlSorting="true" Width="100%">
                                    <Columns>
                                        <telerik:GridTemplateColumn DataField="TagEvent" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="30%" HeaderText="Tag name" ItemStyle-Width="35%" UniqueName="TagEvent"
                                            Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:Label ID="lbl_TagEvent" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdn_TagEvent" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'>
                                                    </asp:HiddenField>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="TagDescription" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="60%" HeaderText="Description" ItemStyle-Width="45%" UniqueName="TagEvent"
                                            Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TagDescription", "{0}") %>'></asp:Label></div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <div style="padding: 0px 0px 0px 10px">
                                            No records found
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                    AllowDragToGroup="false">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                </ClientSettings>
                            </telerik:RadGrid>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="clear: both;">
                </div>
                <div id="div_note" runat="server" class="manageedit">
                    <asp:Label ID="lbl_Note" runat="server" Text=" "><span style='color:red;'>*</span><%=objLanguage.GetLanguageConversion("Mark_Tag_Note_For_Email") %>.</asp:Label>
                </div>
                <div id="divOrderShipping" runat="server" class="show_hide manageedit">
                    <span class="smallgraytext">
                        <%=objLanguage.GetLanguageConversion("Please_Note_This_Email_is_not_applicable_for_ePrint_jobs_To_configuare_ePrint_job_email") %>.<a
                            href="../Settings/system_autojobalert_email.aspx"><%=objLanguage.GetLanguageConversion("Click_Here") %></a></span>
                </div>
                <asp:HiddenField ID="hdnProductName" runat="server" />
                <asp:HiddenField ID="hdnJobName" runat="server" />
                <asp:HiddenField ID="hdnQty" runat="server" />
                <asp:HiddenField ID="hdnTotalPrice" runat="server" />
                <asp:HiddenField ID="hdnOrderedHeight" runat="server" />
                <asp:HiddenField ID="hdnOrderedWidth" runat="server" />
                <asp:HiddenField ID="hdnProductHeight" runat="server" />
                <asp:HiddenField ID="hdnProductWidth" runat="server" />
                <asp:HiddenField ID="hdnAdditionalOption" runat="server" />
                <asp:HiddenField ID="hdnItemNumber" runat="server" />
                <asp:HiddenField ID="hdnItemCode" runat="server" />
                <asp:HiddenField ID="hdnCustomerCode" runat="server" />
                <asp:HiddenField ID="hdnUnitOfMeasure" runat="server" />

                <asp:HiddenField ID="hdnItemDescription" runat="server" />
                <asp:HiddenField ID="hdnWeight" runat="server" />
                <asp:HiddenField ID="hdnCubicMeasurement" runat="server" />
                <asp:HiddenField ID="hdnOrderedWeight" runat="server" />
                <asp:HiddenField ID="hdnOrderedCubicMeasurement" runat="server" />
                <asp:HiddenField ID="hdnPerQuantity" runat="server" />
                <asp:HiddenField ID="hdnDimensions" runat="server" />
              <%--  <asp:HiddenField ID="hdnWidth" runat="server" />
                <asp:HiddenField ID="hdnHeight" runat="server" />--%>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
    <%--    <asp:Button ID="Button1" runat="server" Text="Test" CssClass="button" OnClick="btn_Test_Click" />--%>
    <script type="text/javascript" language="javascript">



        function Show_accountListDiv() {
            showDivPopupCenter('div_accountsList', '200');
        }


        function checkAll_new(chkboxid) {

            var hdnProductName = document.getElementById("ctl00_ContentPlaceHolder1_hdnProductName");
            var hdnJobName = document.getElementById("ctl00_ContentPlaceHolder1_hdnJobName");
            var hdnQty = document.getElementById("ctl00_ContentPlaceHolder1_hdnQty");
            var hdnTotalPrice = document.getElementById("ctl00_ContentPlaceHolder1_hdnTotalPrice");
            var hdnOrderedHeight = document.getElementById("ctl00_ContentPlaceHolder1_hdnOrderedHeight");
            var hdnOrderedWidth = document.getElementById("ctl00_ContentPlaceHolder1_hdnOrderedWidth");
            var hdnProductHeight = document.getElementById("ctl00_ContentPlaceHolder1_hdnProductHeight");
            var hdnProductWidth = document.getElementById("ctl00_ContentPlaceHolder1_hdnProductWidth");
            var hdnAdditionalOption = document.getElementById("ctl00_ContentPlaceHolder1_hdnAdditionalOption");
            var hdnItemNumber = document.getElementById("ctl00_ContentPlaceHolder1_hdnItemNumber");
            var hdnItemCode = document.getElementById("ctl00_ContentPlaceHolder1_hdnItemCode");
            var hdnCustomerCode = document.getElementById("ctl00_ContentPlaceHolder1_hdnCustomerCode");
            var hdnUnitOfMeasure = document.getElementById("ctl00_ContentPlaceHolder1_hdnUnitOfMeasure");

            var hdnItemDescription = document.getElementById("ctl00_ContentPlaceHolder1_hdnItemDescription");
            var hdnWeight = document.getElementById("ctl00_ContentPlaceHolder1_hdnWeight");
            var hdnCubicMeasurement = document.getElementById("ctl00_ContentPlaceHolder1_hdnCubicMeasurement");
            var hdnOrderedWeight = document.getElementById("ctl00_ContentPlaceHolder1_hdnOrderedWeight");
            var hdnOrderedCubicMeasurement = document.getElementById("ctl00_ContentPlaceHolder1_hdnOrderedCubicMeasurement");
            var hdnPerQuantity = document.getElementById("ctl00_ContentPlaceHolder1_hdnPerQuantity");
            var hdnDimensions = document.getElementById("ctl00_ContentPlaceHolder1_hdnDimensions");
            //var hdnWidth = document.getElementById("ctl00_ContentPlaceHolder1_hdnWidth");
            //var hdnHeight = document.getElementById("ctl00_ContentPlaceHolder1_hdnHeight");

            var ChkValue = chkboxid.checked;
            if (chkboxid.id.indexOf("chkProductName") != -1) {
                hdnProductName.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkJobName") != -1) {
                hdnJobName.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkQty") != -1) {
                hdnQty.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkTotalprice") != -1) {
                hdnTotalPrice.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkOrderedHeight") != -1) {
                hdnOrderedHeight.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkOrderedWidth") != -1) {
                hdnOrderedWidth.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkProductHeight") != -1) {
                hdnProductHeight.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkProductWidth") != -1) {
                hdnProductWidth.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkAdditionalOptions") != -1) {
                hdnAdditionalOption.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkOrderItemNumbers") != -1) {
                hdnItemNumber.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkItemCode") != -1) {
                hdnItemCode.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkCustomerCode") != -1) {
                hdnCustomerCode.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkUnitOfMeasure") != -1) {
                hdnUnitOfMeasure.value = ChkValue;
            }

            else if (chkboxid.id.indexOf("chkItemDescription") != -1) {
                hdnItemDescription.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkWeight") != -1) {
                hdnWeight.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkCubicMeasurement") != -1) {
                hdnCubicMeasurement.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkOrderedWeight") != -1) {
                hdnOrderedWeight.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkOrderedCubicMeasurement") != -1) {
                hdnOrderedCubicMeasurement.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkPerQuantity") != -1) {
                hdnPerQuantity.value = ChkValue;
            }
            else if (chkboxid.id.indexOf("chkDimensions") != -1) {
                hdnDimensions.value = ChkValue;
            }
            //else if (chkboxid.id.indexOf("chkWidth") != -1) {
            //    hdnWidth.value = ChkValue;
            //}
            //else if (chkboxid.id.indexOf("chkHeight") != -1) {
            //    hdnHeight.value = ChkValue;
            //}
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
