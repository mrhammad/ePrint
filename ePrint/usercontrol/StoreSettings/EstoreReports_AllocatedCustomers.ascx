<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstoreReports_AllocatedCustomers.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.EstoreReports_AllocatedCustomers" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadAjaxManager ID="RAM_Attch" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadGrid_Customer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Customer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" SkinID="Windows7">
</telerik:RadAjaxLoadingPanel>

<div>
    <div id="div_popupAction" style="margin: 38px 0px 0px 16px;" onmouseover="show();"
            onmouseout="hide(); ">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div style="width: 100%;">
                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;" >
                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CommandName="Delete"
                                    CausesValidation="false" Style="text-decoration: none;padding-bottom: 0px; padding-top: 0px; width: 130px;height:13px;display:inline-block;" ForeColor="#333333" Font-Size="11px"
                                    OnClick="btnDelete_OnClick" OnClientClick="javascript:return CallDelete();"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    <div id="padding">
        
        <div align="left" id="Div_customer" runat="server" style="width: 100%; height: auto;"
            visible="true">
            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGrid_Customer" runat="server" ShowHeader="true" Width="100%"
                        AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" ShowStatusBar="true"
                        AllowSorting="true" PagerStyle-AlwaysVisible="true" AllowFilteringByColumn="true"
                        Visible="true" EnableEmbeddedBaseStylesheet="true" EnableEmbeddedSkins="true"
                        ItemStyle-Height="15px" EnableEmbeddedScripts="true" EnableTheming="true" AllowPaging="true"
                        PageSize="50" GridLines="None" OnItemDataBound="RadGrid_Customer_OnItemDataBound">
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <MasterTableView AllowFilteringByColumn="true" OverrideDataSourceControlSorting="true">
                            <Columns>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div style="float: left">
                                            <div style="float: left; display: none;">
                                                <input type="checkbox" runat="server" name="checkAll" />
                                            </div>
                                            <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                <table width="70%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                    <tr>
                                                        <td>
                                                            <div style="float: left">
                                                                <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);" type="checkbox" />
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnl_chkImage" runat="server">
                                                                <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                        onclick="show();" alt='' />
                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                        onclick="hide();" alt='' />
                                                                </div>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="clear: both;">
                                            </div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="padding-left: 5px">
                                            <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                value='<%# DataBinder.Eval(Container, "DataItem.clientID", "{0}") %>' />
                                        </div>
                                        <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.clientID", "{0}") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Customer Name" HeaderStyle-Width="10%"
                                    ItemStyle-Width="50%" CurrentFilterFunction="Contains" DataField="ClientName"
                                    SortExpression="ClientName" UniqueName="ClientName" FilterControlWidth="18%" AutoPostBackOnFilter="true">
                                    <ItemTemplate>
                                        <div style="float: left; width: 70%; padding-left: 0px; max-height: 18px; height: 18px;">
                                            <asp:Label runat="server" ID="lblCustomerName" Text='<%#Eval("ClientName")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center" 
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="false"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete.gif" CommandName="Delete"
                                            Style='cursor: pointer' OnCommand="imgbtnDelete_Click"
                                            OnClientClick="javascript:return window.confirm('Are you sure you want to remove this Allocated Customer?');" CommandArgument='<%#Eval("clientID")%>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>

                        <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                            AllowDragToGroup="false" Scrolling-AllowScroll="true">
                            <Scrolling UseStaticHeaders="true" ScrollHeight="160" />
                        </ClientSettings>

                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdn_AllocatedClietIDs" runat="server" Value="" />
<script type="text/javascript" language="javascript">

    Sys.Application.add_load(function () {
        var Header = document.getElementById("ctl00_ContentPlaceHolder1_ucCustomerName_RadGrid_Customer_GridHeader");
        Header.style.paddingRight = "0px";
    });  
   
    function show() {
        img_actionsHide.style.display = "block";
        img_actionsShow.style.display = "none";

        div_chk.style.border = "inset 1px";
        div_chk.style.background = "#CBCBCB";

        div_popupAction.style.display = "block";
    }

    function hide() {
        img_actionsHide.style.display = "none";
        img_actionsShow.style.display = "block";

        div_chk.style.border = "outset 1px";
        div_chk.style.background = "";

        div_popupAction.style.display = "none";
    }
    function checkAll_new(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
        }
    }

    function CallDelete() {
        var ret = CheckOne();
        if (ret) {
            var IDs = '';
            var frm = document.getElementById("<%=RadGrid_Customer.ClientID %>").getElementsByTagName("input");
            var hdn_AllocatedClietIDs = document.getElementById("ctl00_ContentPlaceHolder1_ucCustomerName_hdn_AllocatedClietIDs");
            hdn_AllocatedClietIDs.value = "";
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id') != -1) {
                    if (frm[l].checked) {
                        IDs = IDs + frm[l].value + ",";
                    }
                }
            }
            hdn_AllocatedClietIDs.value = IDs;
            return true;
        }
        else {
            return false;
        }
    }
    function CheckOne() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
        if (Number(Counter) == 0) {
            alert("Please check at least one row to remove Allocated Customer(s).");
            return false;
        }
        else {
            return window.confirm('Are you sure you want to remove this Allocated Customer(s)?');
            //  return true;
        }
    }
</script>