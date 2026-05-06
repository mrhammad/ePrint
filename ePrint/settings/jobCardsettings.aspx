<%@ page title="Job Card Settings" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="jobCardsettings.aspx.cs" Inherits="ePrint.settings.jobCardsettings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlEstimateTypes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="TagsGrid" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlEstimateTypes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlItemType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlItemType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridJobCardSettings">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TagsGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TagsGrid" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReset">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridJobCardSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7" />
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">
                                <%=objLanguage.GetLanguageConversion("Job_Card_Settings")%></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div align="left" style="width: 100%; margin-top: 8px" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePanelMessage" runat="server" RenderMode="Inline" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="RadButton2" Text="Restore Default" CssClass="button" runat="server"
                    OnClientClick="javascript:if(!RestoreDefaultSettings()) return false;" OnClick="btnReset_Clicked" />
                <asp:Button ID="RadButton1" Text="Save" CssClass="button" runat="server" OnClick="btnSave_Clicked" />
                <br />
                <br />
                <div style="clear: both">
                    &nbsp;</div>
                <div align="left" nowrap="nowrap">
                    <div align="left" style="float: left; padding-top: 7px;">
                        <asp:Label ID="lbl_estimateType" Text="Estimate Type" runat="server"><%=objLanguage.GetLanguageConversion("Estimate_Type")%></asp:Label>
                    </div>
                    <div align="left" style="float: left; padding-left: 5px;">
                        <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlEstimateTypes" runat="server" CssClass="normaltext" Width="150px"
                                    OnSelectedIndexChanged="ddlEstimateTypes_OnSelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div align="left" style="float: left; padding: 7px 0px 0px 20px;">
                        <asp:Label ID="lblItemType" Text="Item Type" runat="server"><%=objLanguage.GetLanguageConversion("Item_Type")%></asp:Label>
                    </div>
                    <div align="left" style="float: left; padding-left: 5px;">
                        <asp:UpdatePanel ID="UpdatePanel3" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="false"
                            runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlItemType" runat="server" CssClass="normaltext" Width="100px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlItemType_OnSelectedIndexChanged">
                                    <asp:ListItem Text="Main Item" Value="main"></asp:ListItem>
                                    <asp:ListItem Text="Sub Item" Value="sub"></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="clear: both">
                    &nbsp;</div>
                <%--  By Jagat On 20/July/2012--%>
                <div>
                    <table width="85%" border="0">
                        <tr>
                            <td align="left" style="width: 70%">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="gridJobCardSettings" Width="97%" GridLines="None" runat="server"
                                            AutoGenerateColumns="false" AllowSorting="true">
                                            <MasterTableView>
                                                <Columns>
                                                    <telerik:GridTemplateColumn UniqueName="SectionName" DataField="SectionName" SortExpression="Section Name"
                                                        DataType="System.String" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                        HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label1" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Section_Name")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSectionName" Text='<%#Bind("SectionName")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblEstimateType" Text='<%#Bind("EstimateType")%>' runat="server" Visible="false"></asp:Label>
                                                            <asp:HiddenField ID="hdnItemType" runat="server" Value='<%#Bind("ItemType")%>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Description" DataField="Description" SortExpression="Description"
                                                        DataType="System.String" HeaderStyle-Width="62%" HeaderStyle-Font-Bold="true"
                                                        ItemStyle-Width="62%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label2" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Description") %></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDescription" SkinID="textPad" onfocus="javascript:OnTxtDescriptionFocused_CheckboxChecked('ctl00_ContentPlaceHolder1_gridJobCardSettings',this.id);"
                                                                Wrap="true" runat="server" TextMode="MultiLine" Text='<%#Bind("Description")%>'
                                                                Width="100%" Height="150px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="InUse" UniqueName="Chkbx" AllowFiltering="false"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <center>
                                                                    <asp:Label ID="Label3" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("InUse")%></center>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:CheckBox runat="server" ID="Chkbx1" Checked='<%#Bind("ISChecked")%>' />
                                                                <input type="hidden" id="hdnUPDOWN" runat="server" /></center>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="restoreDefault" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderText="Action"
                                                        HeaderStyle-Font-Bold="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <center>
                                                                    <asp:Label ID="Label4" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Action") %></center>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:ImageButton OnClientClick="javascript:OnRestoreDefaultClicked_CheckboxChecked('ctl00_ContentPlaceHolder1_gridJobCardSettings',this.id);"
                                                                    OnClick="RestoreDefault_Clicked" ImageUrl="~/Images/restore_default.gif" ID="imgRestoreDefault"
                                                                    Height="15px" ToolTip="Restore Default" runat="server" />
                                                                <asp:CheckBox runat="server" ID="Chkbx2" Style="display: none" /></center>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="true" AllowAutoScrollOnDragDrop="true" Scrolling-AllowScroll="true">
                                                <Scrolling UseStaticHeaders="true" SaveScrollPosition="true" ScrollHeight="500" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="top" style="width: 25%; height: 200px;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="TagsGrid" Width="97%" AllowSorting="true" GridLines="None" runat="server"
                                            AutoGenerateColumns="false" ShowStatusBar="true" AllowFilteringByColumn="true">
                                            <MasterTableView AllowFilteringByColumn="true" CommandItemSettings-RefreshText=""
                                                CommandItemSettings-ShowRefreshButton="false" Width="100%" HorizontalAlign="NotSet">
                                                <Columns>
                                                    <telerik:GridTemplateColumn UniqueName="TagName" DataField="TagName" FilterControlWidth="100px"
                                                        SortExpression="TagName" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                        AutoPostBackOnFilter="true" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="50%"
                                                        CurrentFilterFunction="Contains" AllowFiltering="true" ItemStyle-Width="50%">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label5" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Tag_Name")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTagName" Width="220px" onclick="select();" Text='<%#Eval("TagName")%>'
                                                                ReadOnly="true" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Description" DataField="TagName" HeaderText="Description"
                                                        SortExpression="Description" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                        FilterControlWidth="80px" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="20%"
                                                        ItemStyle-Width="20%" Visible="false">
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="true" AllowAutoScrollOnDragDrop="true" Scrolling-AllowScroll="true">
                                                <Scrolling UseStaticHeaders="true" SaveScrollPosition="true" ScrollHeight="463" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--End--%>
                <br />
                <asp:Button ID="btnReset" Text="Restore default" CssClass="button" runat="server"
                    OnClick="btnReset_Clicked" OnClientClick="javascript:if(!RestoreDefaultSettings()) return false;" />
                <asp:Button ID="btnSave" Text="Save" CssClass="button" runat="server" OnClick="btnSave_Clicked" />
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        function ValueChanged() {
            var frm = tabledragdrop.getElementsByTagName("input");
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('hdnUPDOWN') != -1) {
                    frm[l].value = i;
                    i++;

                }
            }
        }
        function OnRestoreDefaultClicked_CheckboxChecked(GridID, ImageButtonID) {
            var chkidnew = ImageButtonID.replace("imgRestoreDefault", "Chkbx2");
            var chkid = document.getElementById(chkidnew);
            chkid.checked = true;
        }
        function OnTxtDescriptionFocused_CheckboxChecked(GridID, TextBoxID) {
            var chkidnew = TextBoxID.replace("txtDescription", "Chkbx1");
            var chkid = document.getElementById(chkidnew);
            chkid.checked = true;
        }
        function OnTxtLineSpacingFocused_CheckboxChecked(GridID, TextBoxID) {
            var chkidnew = TextBoxID.replace("txtLineSpacing", "Chkbx1");
            var chkid = document.getElementById(chkidnew);
            chkid.checked = true;
        }
        function toInteger(TextBoxID) {
            var TextBoxIDNew = document.getElementById(TextBoxID);
            TextBoxIDNew.value = Math.ceil(TextBoxIDNew.value);
        }

        function DisableDdl(ChkItem) {
            var ddlItemType = document.getElementById("<%=ddlItemType.ClientID %>");
            if (ChkItem == "True") {
                ddlItemType.options[0].selected = true;
                ddlItemType.disabled = true;
            }
            else {
                ddlItemType.disabled = false;
            }

        }


        function RestoreDefaultSettings() {
            return confirm("Do you want to restore default settings?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

