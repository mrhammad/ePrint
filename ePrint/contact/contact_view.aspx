<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="contact_view.aspx.cs" Inherits="ePrint.contact.contact_view" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:UpdateProgress ID="upProgress" runat="server">
        <ProgressTemplate>
            <div id="divBackGround1">
                <div id="divLoading" style="position: absolute; z-index: 800; display: block;">
                    <div class="Graphic">
                        <div style="padding-left: 25px">
                            <img src="<%=strImagepath %>loading_new.gif" border="0" />
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div id="ds00" style="display: block;">
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">
                                <%=objLangClass.GetLanguageConversion("Contacts_Details")%></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div id="content">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="divsuccmsg">
            <tr>
                <td>
                    <div style="margin-top: -5px;">
                        <asp:PlaceHolder ID="plhmsg" runat="server"></asp:PlaceHolder>
                    </div>
                </td>
            </tr>
        </table>
        <div>
            <%--borderWithoutTop--%>
            <div>
                <div style="height: 15px">
                    <div style="float: right; padding-left: 5px; margin-top: -5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                            cursor: pointer" runat="server"></asp:LinkButton>
                    </div>
                </div>
                <div align="left" style="width: 100%;">
                    <div style="width: 100%;">
                        <asp:HiddenField ID="hdnAlphabet" runat="server" />
                        <div align="left" style="padding-top: 5px; width: 100%;">
                            <div id="div_Main" runat="server">
                                <div id="div_Grid">
                                    <div id="div_popupAction" style="margin: 31px 0px 0px 9px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="divDropdownlist" style="border: 1px solid #CBCBCB; width: 130px; height: 15px;">
                                                        <asp:LinkButton ID="lnkDeleteSelected" Font-Underline="false" OnClientClick="javascript:return CallDelete('delete');"
                                                            OnClick="lnkDeleteSelected_OnClick" Style="text-decoration: none;" ForeColor="#333333"
                                                            Font-Size="11px" Text="Delete Selected" runat="server"><%=objLangClass.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                    </div>
                                                    <div class="divDropdownlist" style="border-top: 0px solid #CBCBCB; border-bottom: 1px solid #CBCBCB;
                                                        border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; width: 130px;
                                                        height: 15px;">
                                                        <asp:LinkButton ID="lnkSubscribeSelected" Font-Underline="false" Style="text-decoration: none;
                                                            padding-top: 15px;" ForeColor="#333333" Font-Size="11px" Text="Subscribe Selected"
                                                            runat="server" OnClientClick="javascript:return CallDelete('subscribe');" OnClick="lnkDeleteSelected_OnClick">
                                                            <%=objLangClass.GetLanguageConversion("Subscribe_Selected")%>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="divDropdownlist" style="border-top: 0px solid #CBCBCB; border-bottom: 1px solid #CBCBCB;
                                                        border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; width: 130px;
                                                        height: 15px;">
                                                        <asp:LinkButton ID="lnkUnSubscribeSelected" Font-Underline="false" Style="text-decoration: none;
                                                            padding-top: 15px;" ForeColor="#333333" Font-Size="11px" Text=" Unsubscribe Selected"
                                                            runat="server" OnClientClick="javascript:return CallDelete('unsubscribe')" OnClick="lnkDeleteSelected_OnClick">
                                                            <%=objLangClass.GetLanguageConversion("Unsubscribe_Selected")%>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="GridView1" AllowSorting="true" OnItemCommand="GridView1_ItemCommand"
                                        OnItemDataBound="OnRowDataBound_GridView1" ShowGroupPanel="true" AllowFilteringByColumn="true"
                                        ShowStatusBar="true" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        OnNeedDataSource="GridView1_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridView1_SortCommand"
                                        PageSize="50" Skin="RadGrid_Eprint_Skin" EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin"
                                        PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                        <HeaderStyle Width="120px" />
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                        <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true">
                                            <Columns>
                                                <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                                <telerik:GridBoundColumn DataField="ContactID" UniqueName="ContactID" SortExpression="ContactID"
                                                    HeaderText="ContactID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Width="3%" AllowFiltering="false" ItemStyle-Width="3%" HeaderStyle-Wrap="false"
                                                    Reorderable="false" UniqueName="DeleteColume">
                                                    <HeaderStyle HorizontalAlign="left" Width="1%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <div id="div_chk" style="width: inherit; height: inherit;">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Panel ID="pnl_chkImage" runat="server">
                                                                                        <div style="float: left; padding: padding: 0px 0px 0px 1px; display: block;">
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
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="padding-left: 7px;">
                                                            <input type="checkbox" runat="server" id="Id" onclick="CheckChanged(event, this, 'ctl00_ContentPlaceHolder1_GridView1');"
                                                                name="Id" value='<%# DataBinder.Eval(Container, "DataItem.contactid", "{0}") %>' />
                                                            <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.contactid", "{0}") %>'></asp:Label>
                                                            <asp:PlaceHolder ID="plhHistory" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="ContactName" UniqueName="ContactName" SortExpression="ContactName"
                                                    HeaderText="" ItemStyle-Width="120px" HeaderStyle-VerticalAlign="Middle" ItemStyle-Wrap="false"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="clientname" UniqueName="clientname" SortExpression="clientname"
                                                    HeaderText="" HeaderStyle-Width="5%" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="140px"
                                                    CurrentFilterFunction="Contains" ItemStyle-Wrap="false" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="department" UniqueName="department" SortExpression="department"
                                                    CurrentFilterFunction="Contains" HeaderText="" HeaderStyle-VerticalAlign="Middle"
                                                    AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="email" UniqueName="email" SortExpression="email"
                                                    CurrentFilterFunction="Contains" HeaderStyle-VerticalAlign="Middle" AutoPostBackOnFilter="true"
                                                    HeaderText="Contact Email">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="mobile" UniqueName="mobile" SortExpression="mobile"
                                                    CurrentFilterFunction="Contains" HeaderText="" HeaderStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Right" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Phone" UniqueName="Phone" SortExpression="Phone"
                                                    CurrentFilterFunction="Contains" HeaderText="" HeaderStyle-Width="3%" HeaderStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Right" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DefaultContactJobTitle1" UniqueName="DefaultContactJobTitle1"
                                                    SortExpression="DefaultContactJobTitle1" CurrentFilterFunction="Contains" HeaderText=""
                                                    HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="defaultcontactjobtitle2" UniqueName="defaultcontactjobtitle2"
                                                    SortExpression="defaultcontactjobtitle2" CurrentFilterFunction="Contains" HeaderText=""
                                                    HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="left" AutoPostBackOnFilter="true">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" AllowDragToGroup="false">
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </div>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                            <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
                        </div>
                        <div style="clear: both">
                            &nbsp;
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            KeepInScreenBounds="true" Opacity="100" runat="server" Width="1000" Height="610"
            OnClientClose="RadWinClose" Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <asp:HiddenField ID="hid_Delete_value1" runat="server" />
    <asp:HiddenField ID="hdn_ContactIDs" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Type" runat="server" Value="delete" />
    <script type="text/javascript" language="javascript">
        document.getElementById("ds00").style.display = "none";
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var strSitePath = '<%=strSitePath %>';
        var hdn_ContactIDs = document.getElementById("<%=hdn_ContactIDs.ClientID %>");
        var hdn_Type = document.getElementById("<%=hdn_Type.ClientID %>");

        function popupContact(ClientID, ContactID, popupContact) {

            popupContact = popupContact.toLowerCase();
            if (popupContact == 'false') {
                alert("You are not authorised to view this page");
                return false;
            }

            window.radopen(strSitePath + "contact/contact_add.aspx?action=edit&clientid=" + ClientID + "&contactid=" + ContactID + "&wintype=contactview&type=customer&pg=Client");
            SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;
        }

        function check4DefaultContact(val) {
            if (val == "True") {
                alert('Default contact cannot be delete.');
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete?');
            }
        }


        function show() {
            var img_actionsShow = document.getElementById("img_actionsShow");
            var img_actionsHide = document.getElementById("img_actionsHide");
            var div_chk = document.getElementById("div_chk");
            var div_popupAction = document.getElementById("div_popupAction");

            img_actionsHide.style.display = "block";

            img_actionsShow.style.display = "none";



            div_popupAction.style.display = "block";

        }

        function hide() {
            var img_actionsShow = document.getElementById("img_actionsShow");
            var img_actionsHide = document.getElementById("img_actionsHide");
            var div_chk = document.getElementById("div_chk");
            var div_popupAction = document.getElementById("div_popupAction");

            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";

            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";

            div_popupAction.style.display = "none";
        }

        function CallDelete(type) {

            hdn_Type.value = type;

            var ret = CheckOne_new(type);
            document.getElementById("<%=hid_Delete_value1.ClientID %>").value = ret;

            if (ret) {
                CheckGrid();
                return true;
            }
            else {
                return false;
            }
        }

        function CheckOne_new(chktype) {
            hdn_ContactIDs.value = '';
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (!e.disabled) {
                        if (e.checked) {
                            Counter = Number(Counter) + 1;
                            hdn_ContactIDs.value += e.value + ",";
                        }
                    }
                }
            }

            if (chktype == 'delete') {
                if (Number(Counter) == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                    return false;
                }
                else {
                    return window.confirm('<%=objLangClass.GetLanguageConversion("Record_Delete_Confirmation")%>');
                }
            }
            else if (chktype == 'subscribe') {
                if (Number(Counter) == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_check_atleast_one_row_to_subscribe")%>');
                    return false;
                }
                else {
                    return window.confirm('<%=objLangClass.GetLanguageConversion("Are_you_sure_you_want_to_subscribe")%>');
                }
            }
            else if (chktype == 'unsubscribe') {
                if (Number(Counter) == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_check_atleast_one_row_to_Unsubscribe")%>');
                    return false;
                }
                else {
                    return window.confirm('<%=objLangClass.GetLanguageConversion("Are_you_sure_you_want_to_Unsubscribe")%>');
                }
            }
        }
        window.setTimeout(function () {
            var label = document.getElementById('divsuccmsg');

            if (label != null) {
                label.style.display = 'none';
            }
        }, 7000);

        function ShowHistory(ContactID) {
            var RadWindowHistory = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?contactid=" + ContactID + "&type=ContactHistory&pg=contact&ItemID=0");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            RadWindowHistory.setSize(1000, 500);
            RadWindowHistory.center();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
