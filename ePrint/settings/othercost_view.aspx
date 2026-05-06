<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="othercost_view.aspx.cs" Inherits="ePrint.settings.othercost_view" title="Settings: Cost Centre" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridOtherCost">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCategorySelect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridOtherCost" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
    .RadGrid_Default .rgCommandRow 
     {

background:none;

}
.RadGrid_Default .rgCommandRow a {
color: #10357F;
text-decoration: none;
margin-left:-8px;
margin-top:-10px;
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div id="divFinishedGoods" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblHeader" runat="server"><%=objLanguage.GetLanguageConversion("Settings")%>: <%=objLanguage.GetLanguageConversion("Other_Costs")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="" class="mis_header_panel" style="margin-top:-5px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="left" style="width: 100%">
                <div align="left" style="width: 100%;">
                    <div style="float: left;">
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                                <td style="float: right;">
                                    <table style="padding: -16px 12px 0px 0px;">
                                        <tr>
                                            <td  >
                                                <div style="width: 150px;margin-left:-11px;" class="bglabel"  >
                                                    <%=objLanguage.GetLanguageConversion("Filter_By_Category")%>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCategorySelect" CssClass="normaltext" runat="server" Width="175px"
                                                    OnSelectedIndexChanged="ddlCategorySelect_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <div id="div_Main" runat="server" align="left" style="width: 100%; margin-bottom: -5px;">
                        <div id="a">
                        </div>
                        <div id="div_Grid">
                            <div id="div_popupAction" style="margin: 46px 0px 0px 9px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Seleted" CommandName="Delete"
                                                        ForeColor="#333333" Font-Size="11px" CausesValidation="false" Style="text-decoration: none;"
                                                        OnClick="btnDelete_OnClick" OnClientClick="javascript:return CallDelete();"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                                  <telerik:RadGrid Width="80%" ID="GridOtherCost" GridLines="None" runat="server" AllowAutomaticDeletes="True" BorderWidth="0" 
                                ShowStatusBar="True" AllowAutomaticInserts="True" OnItemCommand="GridView1_ItemCommand" OnPageIndexChanged="GridOtherCost_PageIndexChanged"
                                AllowAutomaticUpdates="True" OnPageSizeChanged="GridOtherCost_PageSizeChanged" PageSize="50"  OnNeedDataSource="GridOtherCost_items_OnNeedDataSource"
                                AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" AllowFilteringByColumn="True" AllowPaging="True"
                                OnItemDataBound="GridOtherCost_OnItemDataBound">  
                                      <GroupingSettings CaseSensitive="false" />                              
                                <MasterTableView PagerStyle-AlwaysVisible="true" CommandItemDisplay="Top" Width="100%"  InsertItemPageIndexAction="ShowItemOnFirstPage"
                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" DataKeyNames="OtherCostID" AllowFilteringByColumn="true" AllowCustomSorting="true">
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%; margin-top:-12px;">
                                            <tr>
                                                <td align="left"  Style="text-decoration: underline;">
                                                    <a href="othercost_add.aspx"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></a>
                                                </td>
                                                <td align="right">
                                                    <%-- By Jagat on 05-July-2012--%>
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;margin-right: -10px;
                                                        float: right; cursor: pointer" runat="server" Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div style="float: left">
                                                    <div style="float: left; display: none;">
                                                        <input type="checkbox" runat="server" name="checkAll" />
                                                    </div>
                                                    <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                        -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left">
                                                                        <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Panel ID="pnl_chkImage" runat="server">
                                                                        <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                            <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                                border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                            <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                                border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
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
                                                        value='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>' />
                                                </div>
                                                <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.OtherCostID", "{0}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderText="Category"
                                            CurrentFilterFunction="Contains" HeaderStyle-Width="20%" DataField="OtherCostCategoryName"
                                            ItemStyle-Width="20%" UniqueName="OtherCostCategoryName" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                            AutoPostBackOnFilter="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label4" runat="server"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a title='<%#Eval("OtherCostName")%>' href="<%=strSitepath%>settings/othercost_add.aspx?type=edit&id=<%#Eval("OtherCostID")%>">
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblOtherCostCategoryName" CssClass="normalText" runat="server" Text='<%#Eval("OtherCostCategoryName")%>' 
                                                         ToolTip='<%#Eval("OtherCostCategoryName")%>'></asp:Label>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="OtherCostName" HeaderText="Name" CurrentFilterFunction="Contains"
                                            DataField="OtherCostName" HeaderStyle-Width="32%" ItemStyle-Width="32%" UniqueName="OtherCostName"
                                            AllowFiltering="true" Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Name")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a title='<%#Eval("OtherCostName")%>' href="<%=strSitepath%>settings/othercost_add.aspx?type=edit&id=<%#Eval("OtherCostID")%>">
                                                    <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                        <%#Eval("OtherCostName")%>
                                                        <asp:Label ID="lblOtherCostName" Visible="false" CssClass="normaltext" runat="server"
                                                            Text='<%#Eval("OtherCostName")%>'></asp:Label>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="Description" HeaderText="Description"
                                            CurrentFilterFunction="Contains" DataField="Description" HeaderStyle-Width="25%"
                                            ItemStyle-Width="25%" UniqueName="Description" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                            AutoPostBackOnFilter="true">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label5" runat="server"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a title='<%#Eval("OtherCostName")%>' href="<%=strSitepath%>settings/othercost_add.aspx?type=edit&id=<%#Eval("OtherCostID")%>">
                                                    <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                        <asp:Label ID="lblDescription" CssClass="normalText" runat="server" Text='<%#Eval("Description")%>'
                                                            ToolTip='<%#Eval("Description") %>'></asp:Label>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="Action" HeaderText="Action" AllowFiltering="false"
                                            Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="0.5%" />
                                            <ItemTemplate>
                                               <center><asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                    CommandArgument='<%#Eval("OtherCostID")%>' OnCommand="imgbtnDelete_OnClick" Text="Delete"
                                                    UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return ImgButtonErase_ClientClick()">
                                                </asp:ImageButton>
                                                <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.png" ToolTip="Copy"
                                                    OnCommand="imgbtnCopy_OnCommand" OnClientClick="javascript:return CheckOne_copy();"
                                                    CommandArgument='<%#Eval("OtherCostID")%>' /></center> 
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div align="left">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <script type="text/javascript">

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    </script>
    <script type="text/javascript">
        function ImgButtonErase_ClientClick() {
            //return confirm("Are you sure you want to delete this record?");
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) > 1) {
                alert("Please check only one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record?');
            }
        }
        function CheckOne_copy() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            //***Bug ID :653, on 08.11.2011, by Natraj
            if (Number(Counter) > 1) {
                alert("Please check only one row to copy");
                return false;
            }
        }
        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=GridOtherCost.ClientID %>").getElementsByTagName("input");
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('Id') != -1) {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
                document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = IDs;
                return true;
            }
            else {
                return false;
            }
        }
     
    </script>
    <script type="text/javascript">
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
