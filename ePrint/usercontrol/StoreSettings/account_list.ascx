<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="account_list.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.account_list" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath%>js/HelpText/Mask.js?VN='<%#VersionNumber%>'"></script>
<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'"></script>--%>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="div_accountsList" style="display: none; position: absolute; z-index: 100;
    width: 45%;">
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="" Behaviors="Move,Close"
        VisibleStatusbar="false" Modal="true" Top="1000px" OnClientClose="RadWindowclose">
        <Windows>
            <telerik:RadWindow ID="cataloguewindow" DestroyOnClose="true" Width="470" Height="140"
                runat="server">
                <ContentTemplate>
                    <div align="center" class="AddTaskEvent">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="popup-middlebg" align="left">
                                    <div style="padding-top: 5px;">
                                        <div class="autotable">
                                            <div class="bglabel AcctPopUp">
                                                <asp:Label ID="lblStatus" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Customer_List") %></asp:Label>
                                            </div>
                                            <div class="box">
                                                <div style="float: left;">
                                                    <%-- <asp:UpdatePanel ID="pnl_accountList" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                        <ContentTemplate>--%>
                                                    <asp:DropDownList ID="ddl_accountsList" runat="server" CssClass="textboxnew" Width="280px">
                                                    </asp:DropDownList>
                                                    <%--</ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_error" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                    <span>Please select valid account</span>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="div_save" runat="server" style="margin: 15px 0px 5px 0px">
                                                    <asp:Button ID="btn_saveReorder" runat="server" Text="" CssClass="button" OnClick="btn_saveReorder_OnClick" />
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
<%--<div id="divradaccountlist" style="display: none;" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManagerAccountList" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
        Top="30%" Left="150%" Behaviors="Close, Move,Reload,Resize" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>--%>
<div id="div_EmailaccountsList" style="display: none; position: absolute; z-index: 100;
    width: 40%">
    <telerik:RadWindowManager runat="server" ID="RadWindowManager1" Title="" Behaviors="Move,Close"
        VisibleStatusbar="false" Modal="true" Top="1000px" OnClientClose="RadWindowclose">
        <Windows>
            <telerik:RadWindow ID="RadWindowEmailToCustomer" DestroyOnClose="true" Width="480"
                Height="220" runat="server">
                <ContentTemplate>
                    <div align="center" class="AddTaskEvent">
                        <table cellpadding="0" cellspacing="0" class="emaillisttable">
                            <%--     <tr>
                            <td colspan="2" class="popup-top-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-top-middlebg">
                                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                    <b>Email Accounts List</b>
                                    <asp:Label ID="Label1" runat="server"></asp:Label></div>
                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                    <div class="CancelButtonDiv">
                                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                            runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('email');" />
                                    </div>
                                </div>
                            </td>
                            <td colspan="2" class="popup-top-rightcorner">
                                &nbsp;
                            </td>
                        </tr>--%>
                            <tr>
                                <%-- <td class="popup-middle-leftcorner">
                                &nbsp;
                            </td>
                            <td style="width: 15px; background-color: #ffffff">
                                &nbsp;
                            </td>--%>
                                <td class="popup-middlebg" align="left">
                                    <div style="padding-top: 5px">
                                        <div style="float: left; width: 100%;">
                                            <div class="bglabel emailtabletd" runat="server">
                                                <asp:Label ID="lbl_email" runat="server" Text="Email Accounts List" CssClass="normaltext"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <div id="div_PrivateAccounts" runat="server" style="display: block;">
                                                    <div style="float: left;">
                                                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                        <ContentTemplate>--%>
                                                        <asp:ListBox ID="lst_EmailaccountsList" runat="server" CssClass="emailacctlstbox"
                                                            SelectionMode="Multiple"></asp:ListBox>
                                                        <br />
                                                        <asp:Label ID="lbl" runat="server" Text="(Use ctrl for multiple seletion)" CssClass="smallgraytext"></asp:Label>
                                                        <%-- </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="Div2" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                        <span>Please select valid account</span>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="div3" runat="server" style="margin: 15px 0px 5px 0px">
                                                        <asp:Button ID="btn_saveEmail" runat="server" Text="Copy Email" CssClass="button"
                                                            OnClientClick="javascript: var a = Emailvalidate(); if(a)loadingimage(this.id,'div_Save_Copy_Email'); return a;" OnClick="btn_saveEmail_OnClick" />
                                                    </div>
                                                    <div id="div_Save_Copy_Email" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <%--   <td style="width: 10px; background-color: #ffffff">
                                &nbsp;
                            </td>
                            <td align="right" class="popup-middle-rightcorner">
                                &nbsp;
                            </td>--%>
                            </tr>
                            <%--  <tr>
                            <td colspan="2" class="popup-bottom-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-bottom-middlebg">
                                &nbsp;
                            </td>
                            <td colspan="2" class="popup-bottom-rightcorner">
                                &nbsp;
                            </td>
                        </tr>--%>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
<div id="div_CopyAccounts" style="display: none; position: absolute; z-index: 100;
    width: 40%">
    <telerik:RadWindowManager runat="server" ID="RadWindowManager2" Title="" Behaviors="Move,Close"
        VisibleStatusbar="false" Modal="true" Top="1000px" OnClientClose="RadWindowclose">
        <Windows>
            <telerik:RadWindow ID="RadWindowShoppingCart" DestroyOnClose="true" Width="500" Height="300"
                runat="server">
                <ContentTemplate>
                    <div align="center" class="AddTaskEvent">
                        <table cellpadding="0" cellspacing="0" class="emaillisttable">
                            <%--      <tr>
                                <td colspan="2" class="popup-top-leftcorner">
                                    &nbsp;
                                </td>
                                <td class="popup-top-middlebg">
                                    <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                        <b>Accounts List</b>
                                        <div style="float: right; padding-top: 6px; padding-right: 10px">
                                            <div class="CancelButtonDiv">
                                                <asp:ImageButton ID="ImageButton" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                    runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('copy');" />
                                            </div>
                                        </div>
                                </td>
                                <td colspan="2" class="popup-top-rightcorner">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <%-- <td class="popup-middle-leftcorner">
                                    &nbsp;
                                </td>
                                <td style="width: 15px; background-color: #ffffff">
                                    &nbsp;
                                </td>--%>
                                <td class="popup-middlebg" align="left">
                                    <div style="padding-top: 5px">
                                        <div style="float: left; width: 100%;">
                                            <div id="Div1" class="bglabel" runat="server" style="width: 30%; display: none; height: 76px">
                                                <asp:Label ID="lbl_private" runat="server" CssClass="normaltext"> Customers</asp:Label>
                                            </div>
                                            <div class="box" id="div_CustomerList" style="display: none">
                                                <div id="div5" runat="server" style="display: block;">
                                                    <div style="float: left;">
                                                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                            <ContentTemplate>--%>
                                                        <asp:ListBox ID="lstAccountPrivate_popup" runat="server" Height="82px" Width="300px"
                                                            SelectionMode="Multiple"></asp:ListBox>
                                                        <br />
                                                        <div style="float: left; margin: 0px 10px 0px 0px">
                                                            <a href="javascript:void(0);" id="href_selectAll_Private_popup" onclick="selectAll('private','yes')"
                                                                runat="server" style="display: block;">Select All </a><a href="javascript:void(0);"
                                                                    id="href_selectNone_Private_popup" onclick="selectAll('private','no')" runat="server"
                                                                    style="display: none;">None </a>
                                                        </div>
                                                        <div style="float: left; color: Gray; font-size: 10px">
                                                            <asp:Label ID="Label5" runat="server" Text="(Use ctrl for multiple seletion)" CssClass="smallgraytext"></asp:Label>
                                                        </div>
                                                        <%--    </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="Div6" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                        <span>Please select valid account</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Div7" class="bglabel" runat="server" style="width: 30%; height: 76px">
                                                <asp:Label ID="lbl_public" runat="server" CssClass="normaltext"> Public Accounts List</asp:Label>
                                            </div>
                                            <div class="box">
                                                <div id="div_PublicAccounts" runat="server" style="display: block;">
                                                    <div style="float: left;">
                                                        <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                            <ContentTemplate>--%>
                                                        <asp:ListBox ID="lstAccountPublic_popup" runat="server" Height="82px" Width="300px"
                                                            SelectionMode="Multiple"></asp:ListBox>
                                                        <br />
                                                        <div style="float: left; margin: 0px 10px 0px 0px">
                                                            <a href="javascript:void(0);" id="href_selectAll_Public_popup" onclick="selectAll('public','yes')"
                                                                runat="server" style="display: block;">Select All </a><a href="javascript:void(0);"
                                                                    id="href_selectNone_Public_popup" onclick="selectAll('public','no')" runat="server"
                                                                    style="display: none;">None </a>
                                                        </div>
                                                        <div style="float: left; color: Gray; font-size: 10px">
                                                            <asp:Label ID="Label4" runat="server" Text="(Use ctrl for multiple seletion)" CssClass="smallgraytext"></asp:Label>
                                                        </div>
                                                        <%--  </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="Div3" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                        <span>Please select valid account</span>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="div_Copy" runat="server" style="float: left; width: 120%; display: none;">
                                                        <div id="div10" style="float: left; width: 8%;">
                                                            <asp:CheckBox ID="chk_Copy" runat="server" />
                                                        </div>
                                                        <div id="div9" style="float: left; width: 90%; margin: 3px 0px 0px 0px;">
                                                            <asp:Label ID="lbl_Copy" runat="server" Text="Copy all products of the select category to the above selected Customers and Public accounts"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="div_accountLocation" runat="server" style="float: left; color: Gray; width: 300px;
                                                        font-size: 11px; display: none;">
                                                        <asp:Label ID="lbl_accountLocation" runat="server" Text="Note: Account locations will not be copied to the selected Account(s)"
                                                            CssClass="smallgraytext"></asp:Label>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="up_btnSave" runat="server" style="margin: 15px 0px 5px 0px">
                                                        <%-- <asp:UpdatePanel ID="up_btnSave" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>--%>
                                                        <div id="div_btncopy" style="display: block">
                                                            <asp:Button ID="btn_Copy" runat="server" Text="Allocate & Save" CssClass="button"
                                                                OnClick="btn_Copy_OnClick" OnClientClick="javascript:var a= validate();if(a)loadingimg('div_btncopy','div_btncopyprocess');return a;" />
                                                        </div>
                                                        <div id="div_btncopyprocess" class="button" align="center" style="width: 101px; display: none">
                                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                        </div>
                                                        <%-- </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <%-- <td style="width: 10px; background-color: #ffffff">
                                    &nbsp;
                                </td>
                                <td align="right" class="popup-middle-rightcorner">
                                    &nbsp;
                                </td>--%>
                            </tr>
                            <%--          <tr>
                                <td colspan="2" class="popup-bottom-leftcorner">
                                    &nbsp;
                                </td>
                                <td class="popup-bottom-middlebg">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="popup-bottom-rightcorner">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
<div id="div_AdditionalOption" style="display: none; position: absolute; z-index: 100;
    width: 40%">
    <table cellpadding="0" cellspacing="0" width="100%; height:200px">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b>Additional Option</b>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="ImageButtonClose" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('addoption');" />
                        </div>
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="left">
                <div style="padding-left: 5px; padding-top: 5px">
                    <div style="float: left; width: 100%;">
                        <div id="Div11" class="bglabel" runat="server" style="width: 30%;">
                            <asp:Label ID="lbl_Category" runat="server" Text="Category" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <div id="div51" runat="server" style="display: block;">
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel_category" runat="server" UpdateMode="Conditional"
                                        RenderMode="Inline">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddl_categoty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcategoty_OnSelectedIndexChanged"
                                                CssClass="textboxnew" Width="300px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div id="Div71" class="bglabel" runat="server" style="width: 30%; height: 76px">
                            <asp:Label ID="lbl_AddOption" runat="server" Text="Additional Option" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <div id="div6" runat="server" style="display: block;">
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:ListBox ID="lstAddOption" runat="server" Height="82px" Width="300px" SelectionMode="Multiple">
                                            </asp:ListBox>
                                            <div id="div_SelectAll" runat="server" style="float: left; margin: 0px 10px 0px 0px">
                                                <a href="javascript:void(0);" id="href_selectAll_AddOption" onclick="selectAll('addoption','yes')"
                                                    runat="server" style="display: block;">Select All </a>
                                                <a href="javascript:void(0);" id="href_selectNone_AddOption" onclick="selectAll('addoption','no')" 
                                                    runat="server" style="display: none;">None </a>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="float: left; color: Gray; font-size: 10px">
                                        <asp:Label ID="Label41" runat="server" Text="(Use ctrl for multiple seletion)" CssClass="smallgraytext"></asp:Label>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div41" runat="server" style="margin: 15px 0px 5px 0px">
                                    <asp:UpdatePanel ID="up_AddOption" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_AddOption" runat="server" Text="Save" CssClass="button" OnClick="btn_Copy_OnClick"
                                                OnClientClick="javascript:loading();" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="div_CouponCodeOption" style="display: none; position: absolute; z-index: 100;
    width: 40%">
    <table cellpadding="0" cellspacing="0" width="100%; height:200px">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b>CouponCode Option</b>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="img_CouponCode_Close" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('couponcode');" />
                        </div>
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="left">
                <div style="padding-left: 5px; padding-top: 5px">
                    <div style="float: left; width: 100%;">
                        <div id="div_lblCouponCode_AccountName" class="bglabel" runat="server" style="width: 30%;">
                            <asp:Label ID="lblCouponCode_AccountName" runat="server" Text="Company" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <div id="div_CouponCode_Accountlist" runat="server" style="display: block;">
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="up_CouponCode_Accountlist" runat="server" UpdateMode="Conditional"
                                        RenderMode="Inline">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddl_CouponCode_Accountlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_CouponCode_Accountlist_SelectedIndexChanged"
                                                CssClass="textboxnew" Width="300px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div id="div_lblCouponCodeOption" class="bglabel" runat="server" style="width: 30%; height: 76px">
                            <asp:Label ID="lblCouponCodeOption" runat="server" Text="CouponCode Option" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <div id="div_CouponCode_list" runat="server" style="display: block;">
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="up_CouponCode_list" runat="server">
                                        <ContentTemplate>
                                            <asp:ListBox ID="lst_CouponCode_list" runat="server" Height="82px" Width="300px" SelectionMode="Multiple">
                                            </asp:ListBox>
                                            <div id="div_CouponCode_selectall" runat="server" style="float: left; margin: 0px 10px 0px 0px">
                                                <a href="javascript:void(0);" id="href_Selectall_CouponCode" onclick="selectAll('couponcode','yes')"
                                                    runat="server" style="display: block;">Select All </a>
                                                <a href="javascript:void(0);" id="href_Selectnone_CouponCode" onclick="selectAll('couponcode','no')" 
                                                    runat="server" style="display: none;">None </a>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="float: left; color: Gray; font-size: 10px">
                                        <asp:Label ID="lbl_CouponCode_multipleselecionMsg" runat="server" Text="(Use ctrl for multiple seletion)" CssClass="smallgraytext"></asp:Label>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div_CouponCode_Allocate_Save" runat="server" style="margin: 15px 0px 5px 0px">
                                    <asp:UpdatePanel ID="up_CouponCode_Allocate_Save" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_CouponCode_Allocate_Save" runat="server" Text="Save" CssClass="button" OnClick="btn_Copy_OnClick"
                                                OnClientClick="javascript:loading();" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="div_managebanner" style="display: none; position: absolute; z-index: 100;
    width: 40%">
    <telerik:RadWindowManager runat="server" ID="RadWindowManager3" Title="" Behaviors="Move,Close"
        VisibleStatusbar="false" Modal="true" Top="1000px" OnClientClose="RadWindowclose">
        <Windows>
            <telerik:RadWindow ID="RadWindowManageBanner" DestroyOnClose="true" Width="500" Height="225"
                runat="server">
                <ContentTemplate>
                    <div align="center" class="AddTaskEvent">
                        <table cellpadding="0" cellspacing="0" class="emaillisttable">
                            <%--         <tr>
                                <td colspan="2" class="popup-top-leftcorner">
                                    &nbsp;
                                </td>
                                <td class="popup-top-middlebg">
                                    <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                        <b>Accounts List</b>
                                        <asp:Label ID="Label3" runat="server"></asp:Label></div>
                                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                                        <div class="CancelButtonDiv">
                                            <asp:ImageButton ID="ImageButton3" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('copy');" />
                                        </div>
                                    </div>
                                </td>
                                <td colspan="2" class="popup-top-rightcorner">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <%-- <td class="popup-middle-leftcorner">
                                    &nbsp;
                                </td>
                                <td style="width: 15px; background-color: #ffffff">
                                    &nbsp;
                                </td>--%>
                                <td class="popup-middlebg" align="left">
                                    <div style="padding-top: 5px">
                                        <div style="float: left; width: 100%;">
                                            <div id="Div12" class="bglabel" runat="server" style="width: 30%">
                                                <asp:Label ID="Label6" runat="server" Text="Customer's List" CssClass="normaltext"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <div id="div13" runat="server" style="display: block;">
                                                    <div style="float: left;">
                                                        <%-- <asp:UpdatePanel ID="updtpnlMngBanner" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>--%>
                                                        <asp:ListBox ID="list_mngbannerlist" runat="server" CssClass="shoppingcartlstbox"
                                                            SelectionMode="Multiple"></asp:ListBox>
                                                        <br />
                                                        <div style="float: left; margin: 0px 10px 0px 0px">
                                                            <a href="javascript:void(0);" id="href_selectAll_All_popup" onclick="selectAll('all','yes')"
                                                                runat="server" style="display: block;">Select All </a><a href="javascript:void(0);"
                                                                    id="href_selectNone_All_popup_none" onclick="selectAll('all','no')" runat="server"
                                                                    style="display: none;">None </a>
                                                        </div>
                                                        <div style="float: left; color: Gray; font-size: 10px">
                                                            <asp:Label ID="Labelbnrmng" runat="server" Text="(Use ctrl for multiple seletion)"
                                                                CssClass="smallgraytext"></asp:Label>
                                                        </div>
                                                        <%--  </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="Div14" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                        <span>Please select valid account</span>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <%--           <div id="div_Copy" runat="server" style="float: left; width: 120%; display: none;">
                                    <div id="div10" style="float: left; width: 8%;">
                                        <asp:CheckBox ID="chk_Copy" runat="server" />
                                    </div>
                                    <div id="div9" style="float: left; width: 90%; margin: 3px 0px 0px 0px;">
                                        <asp:Label ID="lbl_Copy" runat="server" Text="Copy all products of the selected category to the above selected Public and Private accounts"></asp:Label>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div_accountLocation" runat="server" style="float: left; color: Gray; width: 300px;
                                    font-size: 11px; display: none;">
                                    <asp:Label ID="lbl_accountLocation" runat="server" Text="Note: Account locations will not be copied to the selected Account(s)"
                                        CssClass="smallgraytext"></asp:Label>
                                </div>
                                <div style="clear: both">
                                </div>--%>
                                                    <div id="div15" runat="server" style="margin: 15px 0px 5px 0px">
                                                        <asp:Button ID="btnSavemngbanner" runat="server" Text="Allocate & Save" CssClass="button"
                                                            OnClientClick="javascript:validate();" OnClick="btn_mngbannerSave" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <%--    <td style="width: 10px; background-color: #ffffff">
                                    &nbsp;
                                </td>
                                <td align="right" class="popup-middle-rightcorner">
                                    &nbsp;
                                </td>--%>
                            </tr>
                            <%--    <tr>
                                <td colspan="2" class="popup-bottom-leftcorner">
                                    &nbsp;
                                </td>
                                <td class="popup-bottom-middlebg">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="popup-bottom-rightcorner">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdn_AccountID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_AccountName" runat="server" Value="0" />
<asp:HiddenField ID="hdn_lst_EmailaccountsList" runat="server" Value="0" />
<script type="text/javascript" language="javascript">

    var hdn_lst_EmailaccountsList = document.getElementById("<%=hdn_lst_EmailaccountsList.ClientID %>");
    var div_managebanner = document.getElementById("div_managebanner");
    var ddl_accountsList = document.getElementById("<%=ddl_accountsList.ClientID %>");
    var spn_error = document.getElementById("spn_error");
    var div_accountsList = document.getElementById("div_accountsList");
    var div_CopyAccounts = document.getElementById("div_CopyAccounts");
    var div_EmailaccountsList = document.getElementById("div_EmailaccountsList");

    var list_mngbannerlist = document.getElementById("<%=list_mngbannerlist.ClientID %>");
    var lstAccountPrivate_popup = document.getElementById("<%=lstAccountPrivate_popup.ClientID %>");
    var lstAccountPublic_popup = document.getElementById("<%=lstAccountPublic_popup.ClientID %>");
    var lst_EmailaccountsList = document.getElementById("<%=lst_EmailaccountsList.ClientID %>");

    var href_selectAll_All_popup = document.getElementById("<%=href_selectAll_All_popup.ClientID %>");
    var href_selectNone_All_popup_none = document.getElementById("<%=href_selectNone_All_popup_none.ClientID %>");

    var href_selectAll_Private_popup = document.getElementById("<%=href_selectAll_Private_popup.ClientID %>");
    var href_selectNone_Private_popup = document.getElementById("<%=href_selectNone_Private_popup.ClientID %>");
    var href_selectAll_Public_popup = document.getElementById("<%=href_selectAll_Public_popup.ClientID %>");
    var href_selectNone_Public_popup = document.getElementById("<%=href_selectNone_Public_popup.ClientID %>");

    var href_selectAll_AddOption = document.getElementById("<%=href_selectAll_AddOption.ClientID %>");
    var href_selectNone_AddOption = document.getElementById("<%=href_selectNone_AddOption.ClientID %>");
    var lstAddOption = document.getElementById("<%=lstAddOption.ClientID %>");
    var list_mngbannerlist = document.getElementById("<%=list_mngbannerlist.ClientID %>");
    
    var lst_CouponCode_list = document.getElementById("<%=lst_CouponCode_list.ClientID %>");
    var href_Selectall_CouponCode = document.getElementById("<%=href_Selectall_CouponCode.ClientID %>");
    var href_Selectnone_CouponCode = document.getElementById("<%=href_Selectnone_CouponCode.ClientID %>");

    function hideDiv(value) {

        //        document.getElementById("ds00").style.display = "block";
        //        document.getElementById("div_Load").style.display = "block";

        //        setTimeout("LoadingImgEnd()", 2000);

        var value = value.toLowerCase();
        if (value == 'accountlist') {
            document.getElementById("div_accountsList").style.display = "none";
        }
        if (value == 'email' || value == 'copy') {
            document.getElementById("div_EmailaccountsList").style.display = "none";
            //private account
            for (i = 0; i < lstAccountPrivate_popup.options.length; i++) {
                lstAccountPrivate_popup.options[i].selected = false;
            }
            href_selectAll_Private_popup.style.display = "block";
            href_selectNone_Private_popup.style.display = "none";

            document.getElementById("div_CopyAccounts").style.display = "none";
            document.getElementById("div_managebanner").style.display = "none";
            href_selectAll_All_popup.style.display = "block";
            href_selectNone_All_popup_none.style.display = "none";
            //public account
            for (i = 0; i < lstAccountPublic_popup.options.length; i++) {
                lstAccountPublic_popup.options[i].selected = false;
            }
            href_selectAll_Public_popup.style.display = "block";
            href_selectNone_Public_popup.style.display = "none";
        }
        if (value == 'addoption') {
            document.getElementById("div_AdditionalOption").style.display = "none";

            for (i = 0; i < lstAddOption.options.length; i++) {
                lstAddOption.options[i].selected = false;
            }
            href_selectAll_AddOption.style.display = "block";
            href_selectNone_AddOption.style.display = "none";
        }
        if (value == 'couponcode') {
            document.getElementById("div_CouponCodeOption").style.display = "none";
            for (i = 0; i < lst_CouponCode_list.options.length; i++) {
                lst_CouponCode_list.options[i].selected = false;
            }
            href_Selectall_CouponCode.style.display = "block";
            href_Selectnone_CouponCode.style.display = "none";
        }
        document.getElementById("divBackGroundNew").style.display = "none";
        UnCheckAll();
        if (document.location.href.indexOf('productcatalogue/pricecatalogue.aspx') >= 0) {
            refreshGrid();
        }
        return false;
    }

    function ShowPopUpEmail() {
        var oWnd = $find("<%=RadWindowEmailToCustomer.ClientID%>");
        oWnd.show();
    }

    function ShowPopUp() {
        var oWnd = $find("<%=cataloguewindow.ClientID%>");
        oWnd.show();
    }
    function ShowPopUpShoppingCart() {
        var oWnd = $find("<%=RadWindowShoppingCart.ClientID%>");
        oWnd.show();
    }
    function ShowPopUpManageBanner() {
        var oWnd = $find("<%=RadWindowManageBanner.ClientID%>");
        oWnd.show();
    }

    function RadWindowclose() {
        //document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    function UnCheckAll() {
        if (document.location.href.indexOf('StoreSettings/manage_banner.aspx') >= 0) {
            var cookieName = readCookie('CopyBanners');
            if (cookieName.toLowerCase() == 'home')
                checkAll_Home(this);
            if (cookieName.toLowerCase() == 'left')
                checkAll_Left(this);
            if (cookieName.toLowerCase() == 'right')
                checkAll_Right(this);
        }
        else {
            checkAll_new(this);
        }
    }

    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    function selectAll(type, selectAll) {
        
        setTimeout("LoadingImgEnd()", 2000);
        lstAddOption = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_lstAddOption");
        var href_selectAll_AddOption = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_href_selectAll_AddOption");
        var href_selectNone_AddOption = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_href_selectNone_AddOption");
        var ddl_categoty = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_ddl_categoty");

        var lst_CouponCode_list = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_lst_CouponCode_list");
        var href_Selectall_CouponCode = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_href_Selectall_CouponCode");
        var href_Selectnone_CouponCode = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_href_Selectnone_CouponCode");
        var ddl_CouponCode_Accountlist = document.getElementById("ctl00_ContentPlaceHolder1_ctl01_ddl_CouponCode_Accountlist");

        if (type == 'all') {
            if (selectAll == 'yes') {
                for (i = 0; i < list_mngbannerlist.options.length; i++) {
                    list_mngbannerlist.options[i].selected = true;
                }
                href_selectAll_All_popup.style.display = "none";
                href_selectNone_All_popup_none.style.display = "block";
            }
            if (selectAll == 'no') {
                for (i = 0; i < list_mngbannerlist.options.length; i++) {
                    list_mngbannerlist.options[i].selected = false;
                }
                href_selectAll_All_popup.style.display = "block";
                href_selectNone_All_popup_none.style.display = "none";
            }
        }


        if (type == 'private') {
            if (selectAll == 'yes') {
                for (i = 0; i < lstAccountPrivate_popup.options.length; i++) {
                    lstAccountPrivate_popup.options[i].selected = true;
                }
                href_selectAll_Private_popup.style.display = "none";
                href_selectNone_Private_popup.style.display = "block";
            }
            if (selectAll == 'no') {
                for (i = 0; i < lstAccountPrivate_popup.options.length; i++) {
                    lstAccountPrivate_popup.options[i].selected = false;
                }
                href_selectAll_Private_popup.style.display = "block";
                href_selectNone_Private_popup.style.display = "none";
            }
        }
        if (type == 'public') {
            if (selectAll == 'yes') {
                for (i = 0; i < lstAccountPublic_popup.options.length; i++) {
                    lstAccountPublic_popup.options[i].selected = true;
                }
                href_selectAll_Public_popup.style.display = "none";
                href_selectNone_Public_popup.style.display = "block";
            }
            if (selectAll == 'no') {
                for (i = 0; i < lstAccountPublic_popup.options.length; i++) {
                    lstAccountPublic_popup.options[i].selected = false;
                }
                href_selectAll_Public_popup.style.display = "block";
                href_selectNone_Public_popup.style.display = "none";
            }
        }
        if (type == 'addoption') {
            if (selectAll == 'yes') {
                for (i = 0; i < lstAddOption.options.length; i++) {
                    lstAddOption.options[i].selected = true;
                }
                href_selectAll_AddOption.style.display = "none";
                href_selectNone_AddOption.style.display = "block";
            }
            if (selectAll == 'no') {
                for (i = 0; i < lstAddOption.options.length; i++) {
                    lstAddOption.options[i].selected = false;
                }
                href_selectAll_AddOption.style.display = "block";
                href_selectNone_AddOption.style.display = "none";
            }
        }
        if (type == 'couponcode') {
            if (selectAll == 'yes') {
                for (i = 0; i < lst_CouponCode_list.options.length; i++) {
                    lst_CouponCode_list.options[i].selected = true;
                }
                href_Selectall_CouponCode.style.display = "none";
                href_Selectnone_CouponCode.style.display = "block";
            }
            if (selectAll == 'no') {
                for (i = 0; i < lst_CouponCode_list.options.length; i++) {
                    lst_CouponCode_list.options[i].selected = false;
                }
                href_Selectall_CouponCode.style.display = "block";
                href_Selectnone_CouponCode.style.display = "none";
            }
        }
    }

    function validate() {
        var accPrivate = 0;
        var accPublic = 0;
        var accAll = 0;
        var accEmail = 0;
        for (i = 0; i < lstAccountPrivate_popup.options.length; i++) {
            if (lstAccountPrivate_popup.options[i].selected) {
                accPrivate++;
            }
        }

        for (i = 0; i < lstAccountPublic_popup.options.length; i++) {
            if (lstAccountPublic_popup.options[i].selected) {
                accPublic++;
            }
        }
        for (i = 0; i < list_mngbannerlist.options.length; i++) {
            if (list_mngbannerlist.options[i].selected) {
                accAll++;
            }
        }
        for (i = 0; i < lst_EmailaccountsList.options.length; i++) {
            if (lst_EmailaccountsList.options[i].selected) {
                accEmail++;
            }
        }
        if (accPrivate == 0 && accPublic == 0 && accEmail == 0) {
            alert('Please select at least one from Private/Public account');
            return false;
        }
        else {
            setTimeout("LoadingImgStart()", 0);
            setTimeout("LoadingImgEnd()", 2000);
            document.cookie = "ProductCatagory=Yes";
            return true;
        }
        if (accAll == 0) {
            alert('Please select at least one from Accountlist');
            return false;
        }
        else {
            setTimeout("LoadingImgStart()", 0);
            setTimeout("LoadingImgEnd()", 2000);
            return true;
        }

    }

    function Bind_Grid(val) {
        // alert(val);
        loading();

        if (val == 'product')
            __doPostBack('ctl00$ContentPlaceHolder1$lnk_load', '');
        else if (val == 'catagory')
            __doPostBack('ctl00$ContentPlaceHolder1$lnk_loadCatagory', '')
        else if (val == 'banners')
            __doPostBack('ctl00$ContentPlaceHolder1$RadGrid_bannerHome$ctl00$ctl04$lnk_CopyBanners', '');
    }

    function loading() {
        setTimeout("LoadingImgStart()", 0);
        setTimeout("LoadingImgEnd()", 2000);
    }

    function LoadingImgEnd() {
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    }

    function LoadingImgStart() {
        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
    }

    LoadingImgEnd();

    //    var prm = Sys.WebForms.PageRequestManager.getInstance();
    //    prm.add_endRequest(EndRequest);

    //    function EndRequest(sender, args) {

    //        document.getElementById("ds00").style.display = "none";
    //        document.getElementById("div_Load").style.display = "none";
    //        document.getElementById("divBackGroundNew").style.display = "none";
    //    }


</script>
<%--<script type="text/javascript">
    var $ = $telerik.$;
    function pageLoad() {

        $(window).resize(function () {
            var oWindow = GetRadWindow();
            if (oWindow.isVisible()) {
                oWindow.center();
            }
        });
    }

    function GetRadWindow() {
        return $find("<%=cataloguewindow.ClientID %>");
    } 

</script>--%>
<asp:Panel ID="pnlMngbannerupdate" runat="server" Visible="false">
    <script type="text/javascript">

        function Bind_GridMng(val) {
            loading();
            if (document.location.href.indexOf('StoreSettings/manage_banner.aspx') >= 0) {
                var cookieName = readCookie('CopyBanners');
                if (cookieName.toLowerCase() == 'home') {
                    __doPostBack('ctl00$ContentPlaceHolder1$lnkbtncopy', '');
                }
                if (cookieName.toLowerCase() == 'left') {
                    __doPostBack('ctl00$ContentPlaceHolder1$lnkbtncopy', '');
                }
                if (cookieName.toLowerCase() == 'right') {
                    __doPostBack('ctl00$ContentPlaceHolder1$lnkbtncopy', '');

                }
            }
            else {
                checkAll_new(this);
            }

        }
        Bind_GridMng('banners');
    </script>
</asp:Panel>
