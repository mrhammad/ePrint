<%@ page title="OldData" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Default.aspx.cs" Inherits="ePrint.olddata.Default" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">Old Data </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="borderWithoutTop">
        <div id="padding">
            <span class="HeaderText" id="spn_Selectfile" runat="server">Select File: &nbsp;</span>
            <asp:DropDownList ID="ddlFiles" runat="server" SkinID="onlyDDL" OnSelectedIndexChanged="ddlFiles_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            <div class="only10px">
            </div>
            <div>
                <!-- content start -->
                <div id="divMsg" runat="server" style="float: left;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

                    <script type="text/javascript">
                        function RowDblClick(sender, eventArgs) {
                            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                        }
                    </script>

                </telerik:RadCodeBlock>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                <telerik:AjaxUpdatedControl ControlID="divMsg" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="btnclrAllFilters">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>

                <div id="clearLink" style="float: right; text-align: right; width: 99%; padding-bottom: 1px;
                        padding-right: 35px;" runat="server">
                        <asp:Panel ID="Pnl_btnclrAllFilter" runat="server">
                            <asp:LinkButton ID="btnclrAllFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                cursor: pointer" runat="server"><%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                        </asp:Panel>
                    </div>
                    <div class="onlyEmpty" style="height:5px;">
                    </div>

                <telerik:RadGrid ID="RadGrid1" AutoGenerateColumns="true" AllowFilteringByColumn="true"
                    OnItemDataBound="radGrid1_ItemDataBound" ShowStatusBar="true" runat="server"
                    AllowPaging="true" AllowSorting="true" DataSourceID="ObjectDataSource1" OnColumnCreated="radGrid1_ColumnCreated">
                </telerik:RadGrid>
                <asp:ObjectDataSource ID="ObjectDataSource1" TypeName="OLDDATA" SelectMethod="GetDate"
                    runat="server">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlFiles" Name="FilePath" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <!-- content end -->
            </div>
        </div>
    </div>
</asp:Content>
