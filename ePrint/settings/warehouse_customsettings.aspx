<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true"  CodeBehind="warehouse_customsettings.aspx.cs" Inherits="ePrint.settings.warehouse_customsettings"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="radmanager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnsave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdgeneralsettings" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnstocksave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdstocksettings" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text=""><%=objLanguage.GetLanguageConversion("Stock_Custom_Fields") %></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="min-height: 430px" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel" >
            <div style="width: 65%;">
                <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="float: left; width: 50%">
                <div class="bglabel" style="width: 235px">
                    <asp:Label ID="lbldetailedstock" CssClass="normaltext" runat="server">Maintain detailed information of Stock</asp:Label></div>
                <div class="box" style="float: left">
                    <asp:CheckBox ID="chkstkdetail" onclick="javascript:EnableDisable();" runat="server"
                        Text="" />
                </div>
            </div>
            <div style="clear: both; height: 5px; width: 100%">
            </div>
            <telerik:RadGrid ID="grdstocksettings" AutoGenerateColumns="false" runat="server"
                BorderWidth="0" ShowStatusBar="true" OnItemDataBound="grdstocksettings_ItemDataBound"
                ItemStyle-Height="2%" GridLines="None" Width="35%" HeaderStyle-Font-Bold="true">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("DataFieldName")%>'></asp:Label>
                                <asp:HiddenField ID="hdnFieldName" runat="server" Value='<%#Eval("DataFieldName")%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center"
                            HeaderText="" HeaderStyle-Wrap="false" AllowFiltering="false">
                            <ItemTemplate>
                                <center>
                                    <asp:Image ID="ImgisChecked" ImageUrl="~/images/check.gif" runat="server" Visible="false" />
                                    <asp:CheckBox ID="isChecked" runat="server" Checked='<%#Eval("IsDisplay")%>' />
                                    <asp:HiddenField ID="isCheckedID" runat="server" Value="0" />
                                </center>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" HeaderStyle-Width="55%">
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
            <div style="float: left; width: 100%">
                <div class="bgLabelempty" style="width: 12.5%; visibility: hidden; float: left">
                    empty</div>
                <div class="box" style="width: 10%;">
                    <center>
                        <asp:Button ID="btnstocksave" runat="server" OnClick="btnstocksave_Onclick" CssClass="button"
                            Text="Save" /></center>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>

            function EnableDisable() {
                var mainchk = document.getElementById('<%=chkstkdetail.ClientID %>');
                var grid = document.getElementById('<%=grdstocksettings.ClientID %>');
                if (mainchk.checked) {
                    if (grid != null) {
                        var Inputs = grid.getElementsByTagName('input');
                        for (i = 0; i < Inputs.length; i++) {
                            if (Inputs[i].type == 'checkbox' || Inputs[i].type == 'text') {
                                Inputs[i].disabled = false;
                            }
                        }
                    }
                }
                else {
                    if (grid != null) {
                        var Inputs = grid.getElementsByTagName('input');
                        for (i = 0; i < Inputs.length; i++) {
                            if (Inputs[i].type == 'checkbox' || Inputs[i].type == 'text') {
                                Inputs[i].disabled = true;
                            }
                        }
                    }
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

