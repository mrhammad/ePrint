<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true"  CodeBehind="department_custom_fields.aspx.cs" Inherits="ePrint.settings.department_custom_fields" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="radmanager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnstocksave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grddeptcustomfields" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div style="padding: 10px 0px 0px 10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div align="left" style="width: 100%; padding-top: 0px;" class="mis_header_panel">
            <telerik:RadGrid ID="grdcustomfields" AutoGenerateColumns="false" runat="server"
                BorderWidth="0" ShowStatusBar="true" ItemStyle-Height="2%" GridLines="None" Width="38%"
                HeaderStyle-Font-Bold="true">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Field Name" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"
                            HeaderStyle-Width="20%">
                            <HeaderTemplate>
                                <div>
                                    <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Field_Name")%></div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnLabelID" runat="server" Value='<%#Eval("LabelID")%>' />
                                <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("FieldName")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText=" Screen Name" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"
                            HeaderStyle-Width="20%">
                            <HeaderTemplate>
                                <div>
                                    <asp:Label ID="Label2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Screen_Name")%></div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtScreenName" CssClass="textboxnew" runat="server" Text='<%#Eval("ScreenName")%>'
                                    Height="15px" Width="250px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <div style="clear: both; height: 12px">
            </div>
            <div style="float: left; width: 100%; padding-bottom: 10px;">
                <div id="div_btnupdate" style="display: block;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_OnClick"
                        OnClientClick="loadingimage(this.id,'div_btnupdateprocess');" class="button">
                    </asp:Button>
                </div>
                <div id="div_btnupdateprocess" style="display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

