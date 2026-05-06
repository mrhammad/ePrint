<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="large_format_view.aspx.cs" Inherits="ePrint.settings.large_format_view"  title="Settings: Plant and Presses" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Winows7" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <style>
    .RadGrid_Default .rgCommandRow 
     {

background:none;

}
.RadGrid_Default .rgCommandRow a {
color: #10357F;
text-decoration: none;
margin-left:-9px;

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
  float: left;
}


element {
 
    width: 60%;
    float: left;
}

    </style>
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div align="left" id="pnldetails">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Large_Format_View")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div style="width: 100%;margin-top:-10px" class="mis_header_panel" align="left">
                <div id="">
                    <div align="left">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div align="left" style="width: 100%">
                        <div style="width: 49%; padding-bottom: 5px;margin-top:-12px; float: left">
                            <div style="float: left">
                            </div>
                        </div>
                        <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                        </div>
                    </div>
                  
                        <div id="a">
                        </div>
                        <div >
                            <div id="div_popupAction" style="margin: 57px 0px 0px 9px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CommandName="Delete"
                                                        CausesValidation="false" OnClick="btnDelete_OnClick" ForeColor="#333333" Font-Size="11px"
                                                        Style="text-decoration: none"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                            </div>
                                        </td>
                                    </tr>
                                
                    
</table></div>
  <div id="div_Main" runat="server" align="left" style="width: 100%">
 
                            <telerik:RadGrid Width="60%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True" BorderWidth="0"
                                ShowStatusBar="true" AllowAutomaticInserts="True" PageSize="50" AllowAutomaticUpdates="True"
                                PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true" AllowPaging="True"
                                AutoGenerateColumns="False" OnPageIndexChanged="RadGrid1_PageIndexChanged" OnPageSizeChanged="RadGrid1_PageSizeChanged"
                                OnItemDataBound="RadGrid1_ItemDataBound">
                                <MasterTableView CommandItemDisplay="Top" Width="100%" HorizontalAlign="NotSet" AutoGenerateColumns="False">
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%;">
                                            <tr>
                                                <td align="left" style="text-decoration:underline">
                                                   <a href="plantpresses_largeformat.aspx"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                            <HeaderTemplate>
                                                <div style="float: left">
                                                    <div style="float: left; display: none;">
                                                        <input type="checkbox" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                        value='<%# DataBinder.Eval(Container, "DataItem.PressID", "{0}") %>' />
                                                </div>
                                                <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.PressID", "{0}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="Name" HeaderText="Name" HeaderStyle-Width="50%"
                                            ItemStyle-Width="50%" UniqueName="Name" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label1" runat="server" Width="100%" Text='<%#objLanguage.GetLanguageConversion("Name")%>'></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a title='<%#Eval("PressName")%>' style="cursor: pointer" href='<%=strSitepath %>settings/plantpresses_largeformat.aspx?action=edit&pressid=<%#DataBinder.Eval(Container.DataItem,"PressID") %>'>
                                                    <div style="float: left; width: 99%; overflow: hidden;">
                                                        <%# DataBinder.Eval(Container.DataItem, "PressName")%>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn SortExpression="description" HeaderText="Description"
                                            HeaderStyle-Width="47%" ItemStyle-Width="47%" UniqueName="Description" Visible="true"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden">
                                                    <asp:Label ID="Label2" runat="server" Width="100%" Text='<%#objLanguage.GetLanguageConversion("Description")%>'></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <a title='<%#Eval("description")%>' style="cursor: pointer" href='<%=strSitepath %>settings/plantpresses_largeformat.aspx?action=edit&pressid=<%#DataBinder.Eval(Container.DataItem,"PressID") %>'>
                                                    <div style="float: left; width: 99%; overflow: hidden;">
                                                        <%# DataBinder.Eval(Container.DataItem, "description")%>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="IsDefaultPress" HeaderStyle-HorizontalAlign="Center"
                                            AllowFiltering="false" HeaderStyle-Width="5%" HeaderText="" ItemStyle-Width="5%"
                                            SortExpression="Enabled" UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.PressID", "{0}") %>,'contact');">
                                                    <div style="float: none; width: 100%; overflow: hidden; height: 18px;">
                                                        <asp:HiddenField ID="hdn_DefaultDigitalPress" runat="server" Value='<%#Eval("IsDefaultPress")%>' />
                                                       <center><asp:ImageButton ID="img_DefaultDigitalPress" runat="server" CommandName="Set as default"
                                                            CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("PressID")%>'
                                                            OnCommand="setDefaultPress_OnClick"></asp:ImageButton></center> 
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                              <center>  <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/images/erase.png" CommandArgument='<%#Eval("PressID")%>'
                                                    OnCommand="imgbtnDelete_OnCommand" ToolTip="Delete" OnClientClick="javascript:return EraseCheck();"
                                                    runat="server" />
                                                  <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.png" ToolTip="Copy"
                                                        CommandArgument='<%#Eval("PressID")%>' OnCommand="imgCopy_OnCommand" />
                                              </center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>    
                     
                 </div>
                    <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false" Width="60%">
                    </asp:Panel>
                </div>
                <div style="clear: both">
                </div>
            
        </div>
        </div>
    </div>
   
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <script>
        function CallScroll() {
            var GridID = document.getElementById("<%=RadGrid1.ClientID%>");
            var div_HeaderID = document.getElementById("a");
            var div_BodyID = document.getElementById("div_Grid");
            var OuterDivID = document.getElementById("div_test_1");
            var InnerDivID = document.getElementById("div_test_2");
            var DivTotalRecID = document.getElementById("div_TotalRec");
        }
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    </script>
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <script type="text/javascript">
        function EraseCheck() {
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



        function ChkOneDel() {
            alert("Calling...");
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) > 1 && EraseCheck()) {
                alert("Invalid...");
                return false;
            }
        }







        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=RadGrid1.ClientID %>").getElementsByTagName("input");
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

        function setAsDefault(ID, val) {

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
