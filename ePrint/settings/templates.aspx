<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/settingpage.master" CodeBehind="templates.aspx.cs" Inherits="ePrint.settings.templates" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridTemplate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridTemplate" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <style>
    .RadGrid_Default .rgCommandRow 
     {

background:none;

}
.RadGrid_Default .rgCommandRow a {
color: #10357F;
text-decoration: none;
margin-left:-8px;
}
.RadGrid_Default .rgCommandCell {
border:none;

}
.RadGrid_Default .rgHeader {
border: 0;
border-top: 1px solid #828282;
border-bottom: 1px solid #828282;
}
.RadGrid_Default {

 outline:none;
}



    </style>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var path = "<%=sitepath %>";
    </script>
    <div align="left">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel" runat="server" id="spnheader"></span>
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
            <div class="mis_header_panel"  style=" margin-top: -10px;">
                <div style="width: 70%; margin-left: 10px;" align="left">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="float: left">
                    </div>
                </div>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadGrid ID="GridTemplate" Width="55%" runat="server" AllowAutomaticDeletes="True" BorderWidth="0"
                                PagerStyle-AlwaysVisible="true" ShowStatusBar="true" AllowAutomaticInserts="True"
                                PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True" AutoGenerateColumns="False"
                                OnPageSizeChanged="GridTemplate_PageSizeChanged" OnPageIndexChanged="GridTemplate_PageIndexChanged"
                                HeaderStyle-Font-Bold="true" OnItemDataBound="GridTemplate_OnRowDataBound" ItemStyle-Height="15px">
                                <MasterTableView CommandItemDisplay="Top" AutoGenerateColumns="False" DataKeyNames="ModuleName">
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%;">
                                            <td align="left">
                                                
                                                <asp:LinkButton runat="server" OnClick="btnAdd_OnClick" ID="lnkbtnAddNewRecord" Font-Underline="True"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                            </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn ItemStyle-Width="40%" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="Left" DataField="Name" HeaderStyle-Wrap="false"
                                            SortExpression="Name">
                                            <HeaderTemplate>
                                                <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Template_Name")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkName" Width="99%" ToolTip='<%#Eval("Name")%>'> <%#Eval("Name")%></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="90%" HeaderStyle-Width="50%" SortExpression="Description"
                                            HeaderText="Description" UniqueName="Description" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                            DataField="Description">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderTemplate>
                                                <asp:Label ID="Label12" runat="server"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden; width: 99%; cursor: pointer;">
                                                    <asp:LinkButton runat="server" ID="lnkDescription" Width="99%" ToolTip='<%#Eval("Description") %>'> <%#Eval("Description") %></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="Left" DataField="ModifiedDate" HeaderStyle-Wrap="false"
                                            SortExpression="ModifiedDate">
                                            <HeaderTemplate>
                                                <asp:Label ID="Label13" runat="server"><%=objLanguage.GetLanguageConversion("Modified_Date")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkModifiedDate" Width="10%" ToolTip='<%#Eval("ModifiedDate")%>'> <%#Eval("ModifiedDate")%></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="Left" DataField="ModifiedBy" HeaderStyle-Wrap="false"
                                            SortExpression="ModifiedBy">
                                            <HeaderTemplate>
                                                <asp:Label ID="Label14" runat="server"><%=objLanguage.GetLanguageConversion("Modified_By")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkModifiedBy" Width="10%" ToolTip='<%#Eval("ModifiedBy")%>'> <%#Eval("ModifiedBy")%></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="left"
                                            HeaderStyle-HorizontalAlign="Left" DataField="LastUsed" HeaderStyle-Wrap="false"
                                            SortExpression="LastUsed">
                                            <HeaderTemplate>
                                                <asp:Label ID="Label15" runat="server"><%=objLanguage.GetLanguageConversion("Date_Last_Used")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkLastUsed" Width="10%" ToolTip='<%#Eval("LastUsed")%>'> <%#Eval("LastUsed")%></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Default" UniqueName="Default" Visible="true"
                                            HeaderStyle-HorizontalAlign="Center" DataField="IsDefault" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.TemplateID", "{0}") %>,'template');">
                                                    <div style="float: none;  overflow: hidden; height: 18px;">
                                                        <asp:HiddenField ID="hdn_DefaultTemplate" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                       <center> <asp:ImageButton ID="img_DefaultTemplate" runat="server" CommandName="Set as default"
                                                            CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("TemplateID")%>'
                                                            OnCommand="setDefaulTemplate_OnClick" ToolTip="Set As Default"></asp:ImageButton></center>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="" Visible="true" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <center><asp:ImageButton runat="server" ID="btnimgeditproperty" ImageUrl="~/images/edit.gif"
                                                    ToolTip="Edit Properties" Visible="false" />
                                                <asp:ImageButton runat="server" ID="btnimgdelete" OnClientClick='<%# Eval("TemplateID","return testjs({0})") %>'
                                                    ImageUrl="~/images/erase.png" OnClick="btn_Delete" ToolTip="Delete" />
                                                <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.png" ToolTip="Copy" /></center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:ObjectDataSource ID="odsTemplate" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                    SelectMethod="settings_templates_select"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnID" Value="0" />
    <script>
        function testjs(val) {
            document.getElementById("<%=hdnID.ClientID %>").value = val;
            return window.confirm('<%=objLanguage.GetLanguageConversion("Template_Delete_Confirmation")%>')
        }
    </script>
    <script language="javascript" type="text/javascript">
        function setAsDefault(ID, val) {
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

