<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="ProofSettings.aspx.cs" Inherits="ePrint.settings.ProofSettings" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .custom-grid {
            padding: 8px;
        }
    </style>
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePnl" ChildrenAsTriggers="false" UpdateMode="Conditional"
                    RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="50%">
                            <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkDisplyModuleNumber" runat="server" />
                                    <asp:Label ID="lblModuleNumber" runat="server"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkItemPanelState" runat="server" />
                                    <asp:Label ID="lblItemPanelState" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkProofItemDescription" runat="server" />
                                    <asp:Label ID="lblProofItemDescription" runat="server"></asp:Label>
                                </td>
                            </tr>

                             <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkDownloadFileBeforeApprove" runat="server" />
                                    <asp:Label ID="lblDownloadFileBeforeApprove" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkMultiApproval" runat="server" />
                                    <asp:Label ID="lblMultiApproval" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkChangeProofDescription" runat="server" />
                                    <asp:Label ID="lblChangeProofDescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td align="left" style="padding: 5px;">
                                    <asp:CheckBox ID="chkProofCustomerComment" runat="server" />
                                    <asp:Label ID="lblProofCustomerComment" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top:5px;">
                                    <asp:Label ID="Label1" style="font-weight:bold;padding:10px;" runat="server"></asp:Label>
                                    <%--<table class="rgMasterTable" style="width:100%;table-layout:auto;empty-cells:show;">
                                        <thead>
                                            <tr>
                                                <th class="rgHeader">Field Name</th>
                                                <th class="rgHeader"></th>
                                            </tr>

                                        </thead>
                                        <tbody>
                                            <tr class="rgRow">
                                                <td>
                                                   <asp:Label ID="LabelItemTitle" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkItemTitle" runat="server" />
                                                </td>
                                            </tr>
                                             <tr class="rgRow">
                                                <td>
                                                   <asp:Label ID="LabelDescription" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkDescription" runat="server" />
                                                </td>
                                            </tr>
                                             <tr class="rgRow">
                                                <td>
                                                   <asp:Label ID="LabelArtwork" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkArtwork" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>--%>
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" Width="50%" CssClass="custom-grid" ShowStatusBar="true"
                                        ItemStyle-Height="2%" BorderWidth="0" HeaderStyle-Font-Bold="true"
                                        OnItemDataBound="RadGrid1_ItemDataBound">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Column1" HeaderText="Field Name" UniqueName="Column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="HeaderCheckBox" runat="server" onclick="HeaderCheckboxClicked(this)" />
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                    <%-- <div id="padding">
                        <div align="left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <telerik:RadGrid ID="GridItemDescription" AutoGenerateColumns="false" runat="server" BorderWidth="0"
                                        ShowStatusBar="true" ItemStyle-Height="2%" GridLines="None" Width="50%" HeaderStyle-Font-Bold="true"
                                        OnItemDataBound="OnItemDataBound_GridItemDescription">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Field Name" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%"
                                                    HeaderStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("DatabaseFieldName")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnFieldName" runat="server" Value='<%#Eval("DatabaseFieldName")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center"
                                                    HeaderStyle-Width="50%" ItemStyle-Width="50%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                    <HeaderTemplate>
                                                        <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image ID="ImgisChecked" ImageUrl="~/images/check.gif" runat="server" Visible="false" />
                                                        <asp:CheckBox ID="isChecked" runat="server" Checked='<%#Eval("IsChecked")%>' />
                                                        <asp:HiddenField ID="isCheckedID" runat="server" Value="0" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                            <Selecting EnableDragToSelectRows="false" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="custom-grid">
                                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                        OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;" OnClick="btnSave_Click"></asp:Button>
                                    <div id="div_btnSave" style="display: none; float: left">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <div style="clear: both;">
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function CheckValidation() {
            return true;
        }     
      function HeaderCheckboxClicked(headerCheckbox) {
        var grid = $find("<%= RadGrid1.ClientID %>");
        var tableView = grid.get_masterTableView();
        var gridItems = tableView.get_dataItems();

        var isChecked = headerCheckbox.checked;
        for (var i = 0; i < gridItems.length; i++) {
            var checkbox = gridItems[i].findElement("CheckBox1");
            if (i !== 0) {
                checkbox.checked = isChecked;
            }
        }
    }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
