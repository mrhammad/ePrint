<%@ Page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="ProductCatalogueGroup.aspx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogueGroup" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/item/ProductCatalogue.js"></script>
    <%--  <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lnk_loadCatagory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMenu1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdallocatedcustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Image_Attachment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--   <telerik:AjaxSetting AjaxControlID="Image_Attachment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--   <telerik:AjaxSetting AjaxControlID="customerwindow">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <!--POPUP START-->
    <div>
        <%--<UC:accountList ID="AccountList" runat="server" />--%>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose" Top="115" Left="174"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" OnClientClose="bindUploadimgname"
                    Title="Category Image" OnClientPageLoad="OnClientPageLoad" KeepInScreenBounds="true"
                    VisibleTitlebar="true" VisibleStatusbar="true" Modal="true" ShowContentDuringLoad="false"
                    Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'"
        language="javascript"></script>
    <%-- <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
    <script type="text/javascript" src="../js/Item/price_catalogue.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var DecimalValue = 0;
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);


    </script>
    <div style="padding-top: 1%;">
        <div style="width: 100%;">
            <asp:Panel ID="Panel1" runat="server" class="div_prod_margin">
                <fieldset>
                    <legend class="HeaderText">
                       Add Additional Options Group</legend>
                    <div align="left" style="width: 100%; padding: 0px; border: 0px solid red">
                        <div style="width: 65%;">
                            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 65%; padding: 10px;">
                        <div class="onlyEmpty" id="divitemcode" runat="server">
                            <div class="bglabel">
                                Additional Option Group Name
                                <span style="color: red">*</span>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:TextBox runat="server" ID="txtGroupName" SkinID="textPad" Style="display: block;"
                                        Width="40%"></asp:TextBox>
                                    <%--onblur="CallonBlur(this.value,'spn_txtitemcode');" --%>
                                    <span id="spn_accountName" style="display: none; width: auto; padding-left: 4px; padding-right: 4px" class="spanerrorMsg">
                                        Please enter Additional Option Group Name
                                    </span>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty" id="div_catagoryType" runat="server">
                            <div class="bglabel">
                                <div style="float: left; width: 88%;">
                                    <span><%=objlang.GetLanguageConversion("Allocate_Sub_Options")%></span>
                                </div>
                            </div>
                            <div align="left" style="float: left; width: 50%;">
                                <div align="left" class="onlyEmpty" style="height: 20px;">
                                    <div id="div_selectLnk" style="float: left; padding-left: 5px; padding-top: 3px;">
                                        <a id="Select" runat="server" href="javascript:void(0);">
                                            <%=objlang.GetLanguageConversion("Select") %></a>
                                        <%--onclick="javascript:openPopUp('I','<%=PriceCatalogueCategoryID %>','<%=hdn_categoryName.Value %>','<%=action %>');"--%>
                                        <%----%>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_categoryName" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_fromflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_validateflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_finalvalues" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_iscopychecked" runat="server" Value="false" />
                            <asp:HiddenField ID="hdn_WebOtherCostIDs" runat="server" Value="" />
                            <asp:HiddenField ID="hid_Delete_IDs" runat="server" Value="" />
                            <%--optimization--%>
                            <asp:HiddenField ID="hdn_addoption_groupid" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_addoption_groupname" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_addoption_mode" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_SubCount" runat="server" Value="" />
                        </div>


                        <div class="onlyEmpty" style="padding-top: 10px;">
                            <div class="bglabel" style="visibility: hidden">
                                &nbsp;
                            </div>
                            <div class="box">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_cancel" style="display: block">
                                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="" Style="padding-top: 3px;"
                                            OnClick="btnCancel_Click" CommandName="Cancel" CausesValidation="false" OnClientClick="javascript:return loadingimage(this.id,'div_cancelprocess');"></asp:Button>
                                        <%-- <telerik:RadButton ID="btnCancel" Skin="EprintbtnSkin" EnableEmbeddedSkins="false"
                                        runat="server" Text="" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_Click">
                                    </telerik:RadButton>--%>
                                    </div>
                                    <div id="div_cancelprocess" class="button" align="center" style="width: 38px; height: 14px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div id="Divdiv_btnsave" runat="server" style="display: inline; float: left">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="" OnClientClick="javascript:var a=txtValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                            Style="padding-top: 3px;" OnClick="btnSave_Click"></asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset id="Hidefieldset" runat="server">
                    <legend class="HeaderText">Additional Options Group</legend>
                    <div id="div_Resize" align="left" style="width: 80%; display: block">
                        <div align="left" style="padding: 0px 0px 0px 10px;">
                            <div style="width: 65%">
                                <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage_Delete" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--<div id="div_popupAction" style="display: none; z-index: 999999; width: 160px; position: absolute; margin: 66px 0px 0px 20px"
                            onmouseover="show();" onmouseout="hide();">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="df" runat="server" style="width: 100%;">
                                            <telerik:RadMenu ID="RadMenu1" runat="server" Width="160px" EnableEmbeddedSkins="false" Skin="Eprint_Skin" Flow="Vertical">
                                                <Items>
                                                    <telerik:RadMenuItem Text="Delete Selected" Value="Delete" Style="cursor: pointer;"
                                                        onclick="javascript:return OnDeleteClicked_CheckboxChecked1();">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenu>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
                        <div>
                            <div id="div_popupAction" style="display: none; z-index: 999999; width: 130px; position: absolute; margin: 66px 0px 0px 20px" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CommandName="Delete"
                                                        CausesValidation="false" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                        OnClick="btnDelete_OnClick"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 100%;">

                                <div style="clear: both">
                                </div>
                                <div align="left" style="padding-top: 10px; padding-left: 10px; width: 100%;">
                                    <div id="div_Main" runat="server">
                                        <div id="div_Grid">
                                            <telerik:RadGrid ID="GridView1" runat="server" AllowFilteringByColumn="true" AllowPaging="true"
                                                AllowSorting="true" AutoGenerateColumns="false" GridLines="None" GroupingEnabled="false"
                                                OnDeleteCommand="lnkDelete_OnClick" OnItemDataBound="OnRowDataBound_GridView1"
                                                HeaderStyle-Font-Bold="true" AllowCustomPaging="false" Width="42%"
                                                PagerStyle-CssClass="RadComboBox_Eprint_Skin" PageSize="50" ShowGroupPanel="false"
                                                ShowStatusBar="true">
                                                <GroupingSettings CaseSensitive="false" />
                                                <%--<HeaderStyle Width="100px" />--%>
                                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                <PagerStyle Mode="NextPrevAndNumeric" />
                                                <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" HorizontalAlign="NotSet"
                                                    OverrideDataSourceControlSorting="true" Width="100%" PagerStyle-AlwaysVisible="true">
                                                    <CommandItemTemplate>
                                                        <table border="0" class="rgCommandTable" style="width: 100%;">
                                                            <tr>
                                                                <%--<td align="left">
                                                                    <div id="div_AddNewRecord" runat="server">
                                                                        <asp:Button ID="btnAddNewRecord" runat="server" class="rgAdd" PostBackUrl="ProductCatalogueGroup.aspx?&amp;mode=add" /><a
                                                                            href="ProductCatalogueGroup.aspx?&amp;mode=add"><%=objlang.GetLanguageConversion("Add_new_record")%></a>
                                                                    </div>
                                                                </td>--%>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="btnclrFilters" runat="server" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                                                                        Text=""><%=objlang.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                            HeaderStyle-Width="1%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                            ItemStyle-Width="1%" Visible="true">
                                                            <HeaderTemplate>
                                                                <div style="float: left">
                                                                    <div style="float: left; display: none;">
                                                                        <input id="checkAll_Copy1" runat="server" name="checkAll" type="checkbox" />
                                                                    </div>
                                                                    <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="float: left">
                                                                                        <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                            type="checkbox" />
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                        <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="show();" alt='' />
                                                                                        <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="hide();" alt='' />
                                                                                    </div>
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
                                                                    <input id="checkBox_Copy1" runat="server" name="Id" onclick="CheckChanged();" type="checkbox"
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.PricatalogueGroupID", "{0}") %>' />
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="left"
                                                            ItemStyle-Width="1%" Visible="false">
                                                            <HeaderTemplate>
                                                                <input id="checkAll_Copy" runat="server" name="checkAll" onclick="CheckAll(this);"
                                                                    type="checkbox" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input id="checkBox_Copy" runat="server" name="Id" onclick="CheckChanged();" type="checkbox"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.PricatalogueGroupID", "{0}") %>' />
                                                                <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="GroupName"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Additional Options Group Name"
                                                            ItemStyle-Width="20%" SortExpression="GroupName" UniqueName="GroupName"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <a  style="cursor:pointer;" onclick="javascript:Additions_options_group_edit('<%#Eval("GroupName")%>','<%#Eval("PricatalogueGroupID")%>','<%#Eval("SuboptionCount")%>');" >
                                                                    <div style="float: left; width: 99%; height: auto">
                                                                        <%--&catagoryImage=<%#Eval("categoryImage")%> href='ProductCatalogueGroup.aspx?&amp;mode=edit&amp;GroupID=<%#Eval("PricatalogueGroupID")%>'--%>
                                                                    <asp:label id="lblgroupname" runat = "server" Text= '<%#Eval("GroupName")%>'> '<%#Eval("GroupName")%>' </asp:label>   
                                                                    </div>
                                                                </a>

                                                                <%--<asp:Label ID="lblPriceCatalogueCategoryName" Visible="false" runat="server" Text="<%#Eval("PriceCatalogueCategoryID")%>"></asp:Label>--%>
                                                                <input id="hdnPriceCatalogueCategoryName" runat="server" type="hidden" value='<%#Eval("GroupName")%>' />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>


                                                        <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="true" HeaderStyle-Width="5%"
                                                            HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" UniqueName="restoreDefault">
                                                            <ItemTemplate>
                                                                <%--<a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'>
                                                                <asp:Image ID="imgbtnEdit" runat="server" ImageUrl="~/images/edit.gif" ToolTip="Edit" /></a>&nbsp;--%>
                                                                <asp:ImageButton ID="imgDelete" runat="server" Height="15px" ImageUrl="~/Images/erase.png"
                                                                    OnCommand="imgDelete_OnCommand" CommandArgument='<%#Eval("PricatalogueGroupID")%>'
                                                                    OnClientClick="javascript:return EraseCheck();"
                                                                    ToolTip="Delete" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView><ClientSettings AllowColumnsReorder="false" AllowDragToGroup="false"
                                                    ReorderColumnsOnClient="true" EnableRowHoverStyle="true">
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                </fieldset>
                &nbsp;&nbsp;
            </asp:Panel>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var categoryID = '<%=PriceCatalogueGroupID %>';
        var checkBoxID = '';
        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");

        // Check for Browser Name (If IE Browser then change style) BY 018
        function checkBrowserName() {
            if (navigator.appName.toLowerCase() == 'microsoft internet explorer') {
                document.getElementById("div_popupAction").style.margin = "100px 0px 0px 17px"
            }
        }
        checkBrowserName();

        function EraseCheck() {
            return window.confirm('Are you sure you want to delete this record?');
        }
        function CallDelete() {
            
            var ret = CheckOne();
            if (ret) {
                var IDs = '';
                var frm = document.getElementById("<%=GridView1.ClientID %>").getElementsByTagName("input");
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('checkBox_Copy1') != -1) {
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
        function CheckOne() {
            
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Copy1') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');
                //  return true;
            }
        }

        var CheckFinal = false;
        function txtValidation() {
            var Actiontype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value;
            var txtGroupName = document.getElementById("<%=txtGroupName.ClientID %>");
            CheckFinal = false;
            if (txtGroupName.value == "" || trim12(txtGroupName.value) == "") {
                document.getElementById("spn_accountName").style.display = "block";
                txtGroupName.focus();
                CheckFinal = true;
            }
            var HdnID = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>");
            var CustumerCount = document.getElementById("<%=hdn_SubCount.ClientID %>").value
            var Mode = document.getElementById("<%=hdn_addoption_mode.ClientID %>").value
            if (Mode == "edit") {
                if (CustumerCount == '0') {
                    if (HdnID.value == "" || trim12(HdnID.value) == "") {
                        alert("Please select Sub Options to save this Additional Option Group");
                        CheckFinal = true;
                    }
                }
            }
            else
            {
                if (HdnID.value == "" || trim12(HdnID.value) == "") {
                    alert("Please select Sub Options to save this Additional Option Group");
                    CheckFinal = true;
                }
            }
            if (Actiontype == '' || Actiontype == 'add' || Actiontype == 'edit') {
                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }

        }

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

        function Show_CopyAccountsDiv() {
            hide();
            showDivPopupCenter('div_CopyAccounts', '220');
        }



        function checkAll_new(checkAllBox) {
            checkBoxID = 'checkBox_Copy';
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(checkBoxID) != -1) {
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


        function openPopUp(PriceCatalogueGroupID, action, Name) {
            var txtGroupName = document.getElementById("<%=txtGroupName.ClientID %>");
            if (txtGroupName.value == "" || trim12(txtGroupName.value) == "") {
                alert("Please enter Additional Option Group name");
            }
            else {
                window.radopen(path + "ProductCatalogue/ProductCatalogueSubAdditionOption_Allocation.aspx?id=" + PriceCatalogueGroupID + "&action=" + action + "&Name=" + Name);
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }

        function clearCookie(name) {
            var date = new Date();
            date.setDate(date.getDate() - 1);
            document.cookie = name + "=''; expires=" + date + "; path=/";
            // alert('Successfully erased Cookie ' + name);
        }

        function readCookie(name) {
            return (name = new RegExp('(?:^|;\\s*)' + ('' + name).replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&') + '=([^;]*)').exec(document.cookie)) && name[1];
        }


        function OnClientPageLoad(sender, args) {
            if (contentCell && loadingSign) {
                contentCell.removeChild(loadingSign);
                contentCell.style.verticalAlign = "";
                loadingSign.style.display = "none";
            }
        }
        //optimization
        var groupname_ongridclick = '';
        var groupid_ongridclick = '0';
        var groupmode_ongrdclick = 'add';
        function Additions_options_group_edit(groupname, groupid,SubCount) {
            document.getElementById("<%=txtGroupName.ClientID %>").value = SpecialDecode(groupname);
            document.getElementById("<%=hdn_addoption_groupid.ClientID %>").value = groupid;
            document.getElementById("<%=hdn_addoption_groupname.ClientID %>").value = groupname;
            document.getElementById("<%=hdn_addoption_mode.ClientID %>").value = 'edit';  
            document.getElementById("<%=hdn_SubCount.ClientID %>").value = SubCount;
        }

        function openPopUp1(groupid_ongridclick, groupmode_ongrdclick, groupname_ongridclick) {
            groupid_ongridclick = document.getElementById("<%=hdn_addoption_groupid.ClientID %>").value;
            groupname_ongridclick = document.getElementById("<%=hdn_addoption_groupname.ClientID %>").value
            groupmode_ongrdclick = document.getElementById("<%=hdn_addoption_mode.ClientID %>").value;
            groupname_ongridclick = SpecialEncode(groupname_ongridclick);
            
            if (groupmode_ongrdclick == "") {
                groupmode_ongrdclick = 'add';
            }
            if (groupid_ongridclick == "") {
                groupid_ongridclick = '0';
            }
            var txtGroupName = document.getElementById("<%=txtGroupName.ClientID %>");            
            if (txtGroupName.value == "" || trim12(txtGroupName.value) == "") {
                alert("Please enter Additional Option Group name");
            }
            else {
                window.radopen(path + "ProductCatalogue/ProductCatalogueSubAdditionOption_Allocation.aspx?id=" + groupid_ongridclick + "&action=" + groupmode_ongrdclick + "&Name=" + groupname_ongridclick);
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        function SpecialEncode(OriginalString) {
            OriginalString = OriginalString.split("'").join('%27');
            OriginalString = OriginalString.split('"').join('%22');
            return OriginalString;
        }
        function SpecialDecode(OriginalString) {
            OriginalString = OriginalString.split('%27').join("'");
            OriginalString = OriginalString.split('%22').join('"');
            return OriginalString;
        }
    </script>

</asp:Content>