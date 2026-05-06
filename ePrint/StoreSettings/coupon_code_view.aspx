<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="coupon_code_view.aspx.cs" Inherits="ePrint.StoreSettings.coupon_code_view" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridCouponCode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridCouponCode" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridCouponCode" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            text-decoration: underline;
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
        .RadGrid_Default .rgAdd
        {
            display: none;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript" language="javascript"></script>
    <div style="float: left;" class="estore_settingBox">
        <UC:Header ID="header" runat="server" />
        <div id="divFinishedGoods" style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <asp:Label ID="lblHeader" runat="server"><%=objLanguage.GetLanguageConversion("Estore_Settings")%>: <%=objLanguage.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                    <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                        href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                        <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                    </a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="manageedit">
            <div id="">
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div align="left" style="width: 100%">
                    <div align="left" style="width: 100%">
                        <div id="div_TotalRec" style="float: right; padding-right: 40%; padding-bottom: 5px">
                        </div>
                        <div id="div_Main" runat="server" align="left" style="width: 100%">
                            <div id="a">
                            </div>
                            <div id="div_popupAction" style="margin: 63px 0px 0px 11px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%; margin:-6px 0px 0px -3px;">
                                                <div style="padding-bottom: 7px; padding-top: 7px; width: 130px;" class="divDropdownlist">
                                                    <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" Style="text-decoration: none;"
                                                        Width="150px" OnClientClick="javascript:return CallDelete();" OnClick="btnDelete_OnClick"
                                                        ForeColor="#333333" Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_Grid">
                                <telerik:RadGrid Width="80%" ID="GridCouponCode" GridLines="None" runat="server"
                                    BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="True"
                                    PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True" AutoGenerateColumns="False"
                                    HeaderStyle-Font-Bold="true" OnPageIndexChanged="GridCouponCode_PageIndexChanged"
                                    OnPageSizeChanged="GridCouponCode_PageSizeChanged" OnItemDataBound="GridCouponCode_ItemDataBound"
                                    AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="false">
                                    <MasterTableView PagerStyle-AlwaysVisible="true" CommandItemDisplay="Top" Width="100%"
                                        HorizontalAlign="NotSet" AutoGenerateColumns="False" DataKeyNames="CouponCodeID">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%; margin-top: -10px">
                                                <td align="left" style="text-decoration: underline; margin-left: -10px">
                                                    <a href="coupon_code_add.aspx?type=add">
                                                        <%=objLanguage.GetLanguageConversion("Add_New_Record")%>
                                                    </a>
                                                </td>
                                                <td align="right" style="text-decoration: underline; margin-right: -10px">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                        margin-right: -10px; cursor: pointer" runat="server" Text='<%#objLanguage.GetLanguageConversion("Clear_All_Filters") %>' />
                                                </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll(this);" type="checkbox" />
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
                                                    <div style="padding-left: 2px">
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>' />
                                                    </div>
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="CouponCode" HeaderText="Coupon Code"
                                                CurrentFilterFunction="Contains" HeaderStyle-Width="19%" DataField="CouponCode"
                                                ItemStyle-Width="19%"  Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                AutoPostBackOnFilter="true">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="Label4" runat="server"><%=objLanguage.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <div style="float: left; width: 99%; word-break: break-word; overflow: hidden">
                                                            <asp:Label ID="lblOtherCostCategoryName" CssClass="normalText" runat="server" Text='<%#Eval("CouponCode")%>'
                                                                ToolTip='<%#Eval("CouponCode")%>'></asp:Label>
                                                        </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>                                            
                                            <telerik:GridTemplateColumn SortExpression="UserFriendlyName" CurrentFilterFunction="Contains"
                                                DataField="UserFriendlyName" HeaderStyle-Width="19%" ItemStyle-Width="19%" UniqueName="UserFriendlyName"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="Label11" runat="server"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <div style="float: left; width: 99%; word-break: break-word; overflow: hidden; height: 15px; overflow: hidden">
                                                            <%#Eval("UserFriendlyName")%>
                                                            <asp:Label ID="lblUserFriendlyName" Visible="false" CssClass="normaltext" runat="server"
                                                                Text='<%#Eval("UserFriendlyName")%>' ToolTip='<%#Eval("UserFriendlyName")%>'></asp:Label>
                                                        </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="CouponCodeDiscountType" CurrentFilterFunction="Contains"
                                                DataField="CouponCodeDiscountType" HeaderStyle-Width="15%" ItemStyle-Width="15%" UniqueName="CouponCodeDiscountType"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lbl_DiscountType" runat="server"><%=objLanguage.GetLanguageConversion("Type")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                            <%#Eval("CouponCodeDiscountType")%>
                                                            <asp:Label ID="lbl_CouponCodeDiscountType" Visible="false" CssClass="normaltext" runat="server"
                                                                Text='<%#Eval("CouponCodeDiscountType")%>' ToolTip='<%#Eval("CouponCodeDiscountType")%>'></asp:Label>
                                                        </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn> 
                                            <telerik:GridTemplateColumn SortExpression="Discount" CurrentFilterFunction="Contains"
                                                DataField="Discount" HeaderStyle-Width="10%" ItemStyle-Width="10%" UniqueName="Discount"
                                                Visible="true" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblUserFriendlyName" runat="server"><%=objLanguage.GetLanguageConversion("Discount")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                            <%#Eval("Discount")%>
                                                            <asp:Label ID="lblDiscount" Visible="false" CssClass="normaltext" runat="server"
                                                                Text='<%#Eval("Discount")%>' ToolTip='<%#Eval("Discount")%>'></asp:Label>
                                                        </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridTemplateColumn> 
                                            
                                             <telerik:GridTemplateColumn SortExpression="Can be used multiple time" AllowFiltering="false" 
                                                HeaderStyle-Width="18%" ItemStyle-Width="18%" UniqueName="CanbeuseMultipleTime"
                                                Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                                <HeaderTemplate>
                                                    <div style="width: 99%; overflow: hidden">
                                                        <asp:Label ID="lblcanbeusemultipletime" runat="server">
                                                        <%=objLanguage.GetLanguageConversion("Can_be_use_multiple_time")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>                                                        
                                                        <asp:HiddenField ID="hdncanitbeusemultipletime" runat="server" Value='<%#Eval("CanbeuseMultipleTime")%>' />
                                                           <asp:Image id="imgcanbeusemultipletime" runat="server"/>                                                                                                                    
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>  
                                            <telerik:GridTemplateColumn SortExpression="alreadyused" AllowFiltering="false"
                                                HeaderStyle-Width="20%" ItemStyle-Width="20%" UniqueName="alreadyused"
                                                Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                                <HeaderTemplate>
                                                    <div style="width: 99%; overflow: hidden">                                                  
                                                        <asp:Label ID="lblalreadyused" runat="server">
                                                        <%=objLanguage.GetLanguageConversion("Already_Used_")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <div style="width: 99%; overflow: hidden; height: 15px; overflow: hidden">
                                                        <asp:HiddenField runat="server" ID="hdnalreaduused" Value='<%#Eval("IsAlreadyused")%>' />
                                                           <asp:Image id="imgalreadyused" runat="server"/> 
                                                        </div>
                                                </ItemTemplate> 
                                                <ItemStyle HorizontalAlign="Center" />                                               
                                            </telerik:GridTemplateColumn> 
                                                                                      
                                            <telerik:GridTemplateColumn SortExpression="Action" HeaderText="Action" AllowFiltering="false"
                                                Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                        CommandArgument='<%#Eval("CouponCodeID")%>' OnCommand="imgbtnDelete_OnClick" OnClientClick="avascript:return imgbtnDelete_Click()"
                                                     tooltip="Delete"  Text="Delete" UniqueName="DeleteColumn" runat="server">  <%--OnClientClick='<%#Eval("CouponCodeID", "javascript:return ImgButtonErase_ClientClick({0});")%>'--%>
                                                    </asp:ImageButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>                              
                                <asp:HiddenField ID="hdnAccountID" runat="server"></asp:HiddenField>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <asp:HiddenField ID="hid_Allocate_IDs" runat="server" Value="" />
    <script type="text/javascript">

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
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
    <script type="text/javascript">

        function ImgButtonErase_ClientClick(id) {

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
                return true;
            }
        }

        function CallDelete() {
            var ret = CheckOnehere();
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = document.getElementById("<%=GridCouponCode.ClientID %>").getElementsByTagName("input");
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('Id') != -1) {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
                document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = IDs;
                ShowDelete();
                ShowDeletePopUp();
                return false;
            }
            else {
                return false;
            }
        }

        function CheckOnehere() {
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
                alert("Please check at least one row to Delete");
                return false;
            }
            if (Number(Counter) > 0) {

                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
            }
        }


        function checkAll(checkAllBox) {

            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }
        function imgbtnDelete_Click() {
            return confirm('<%=objLanguage.GetLanguageConversion("Delete_This_Record") %>');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

