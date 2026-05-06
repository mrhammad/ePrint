<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="delivery_view.aspx.cs" Inherits="ePrint.Delivery.delivery_view" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="GridViewDelivery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListBox1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
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
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";
    </script>
    <style type="text/css">
        .RadGrid .rgHeader
        {
            padding-right: 4px;
            padding-left: 2px;
        }
        .RadGrid .rgRow td
        {
            padding-left: 2px;
        }
        .RadGrid .rgAltRow td
        {
            padding-left: 2px;
        }
        .RadGrid .rgFilterRow td
        {
            padding-left: 2px;
            padding-right: 2px;
        }
        .hyperlinkNoUnderline {
            cursor: pointer;
            color: blue;
        }
    </style>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">
                                <%=objLangClass.GetLanguageConversion("Delivery_Notes")%>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div id="content">
        <div>
            <div id="">
                <div align="center" style="width: 100%">
                    <div style="width: 90%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="height: 18px; margin-top:-10px; margin-bottom:10px;">
                     <div id="div_ddlView" style="float: left; /*display: none*/">
                            <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged" Width="110%"
                               style="height:23px;border-radius:4px;background-color:white; outline:none; cursor:pointer;" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div style="float: left; margin-left:35px;padding-top:3px;">
                            <asp:LinkButton ID="lnkDeliveryedit" runat="server" Text="Edit View" Style="text-decoration: underline;"
                                OnClientClick="javascript:return editviewID_delivery();" OnClick="btnEditViewDelivery_Click"><%=objLanguage.GetLanguageConversion("Edit_Add")%></asp:LinkButton>
                            <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLangClass.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display:none; cursor: pointer;
                                    color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                        </div>
                    <div style="float: right; padding-left: 0px; padding-top:5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                            cursor: pointer" runat="server" Text="" />
                    </div>
                    <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                        <div style="float: left; display: none;">
                            <span class="HeaderText" style="color: #787878">
                                <%=objLangClass.GetLanguageConversion("Current_View")%></span>
                        </div>
                        <div class="Only5pxWidth">
                            &nbsp;</div>
                        <div id="div_lblView" style="float: left; display: none;">
                            <asp:Label ID="lblView" runat="server"></asp:Label>
                        </div>
                       
                        <div class="Only5pxWidth">
                            &nbsp;</div>
                        <div style="float: left; display: none;">
                            <span class="normalText" style="color: #787878">
                                <%=objLangClass.GetLanguageConversion("Or_Try")%></span><a href="../delivery/delivery_search.aspx"
                                    id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                    <%=objLangClass.GetLanguageConversion("Advanced_Search")%></a>
                        </div>
                    </div>
                </div>
                <div align="left" style="width: 100%; margin-top: -4px;">
                    <div style="width: 100%;">
                        <div align="left" style="padding-top: 5px; width: 100%;">
                            <div id="div_Main" runat="server">
                                <div id="div_Grid">
                                    <div id="div_popupAction_View" style="" onmouseover="show();" onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <asp:Panel ID="pnlStatusList" runat="server">
                                                            <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100%"
                                                                OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged" Skin="EprintListbox"
                                                                EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                                OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                                                                <headertemplate>
                                                                    <span style="color: #333; line-height: 23px; font-weight: 100; padding: 5px 0px 5px 5px;
                                                                        font-family: Verdana; font-size: 10px;">
                                                                        <asp:Label ID="lblChange_Status" runat="server"><%=objLangClass.GetLanguageConversion("Change_Status") %></asp:Label>
                                                                    </span>
                                                                </headertemplate>
                                                                <items>
                                                                </items>
                                                            </telerik:RadListBox>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divarchive" runat="server" class="divDropdownlist" onclick="javascript:return CheckchkOne('archive');"
                                                        style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 0px solid #CBCBCB;">
                                                        <asp:Label ID="lblArchive" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="DivdivDropdownlist" runat="server">
                                                        <div onclick="javascript:return CheckchkOne('delete');" class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                            <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="GridViewDelivery" runat="server" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewDelivery"
                                        ShowGroupPanel="false" AllowFilteringByColumn="true" ShowStatusBar="true"
                                        AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridViewDelivery_ColumnCreated"
                                        OnNeedDataSource="GridViewDelivery_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewDelivery_SortCommand"
                                         OnGroupHeaderItemDataBound="GridView1_GroupHeaderItemDataBound"
                                        OnItemCommand="GridViewDelivery_ItemCommand" Skin="Sunset" AllowCustomPaging="true"
                                        EnableEmbeddedSkins="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                        <headerstyle cssclass="gv_ViewsHeader" />
                                        <filtermenu cssclass="RadMenu_Eprint_Skin" />
                                        <pagerstyle mode="NextPrevAndNumeric" wrap="true" alwaysvisible="false"></pagerstyle>
                                        <mastertableview overridedatasourcecontrolsorting="true" allowfilteringbycolumn="true"
                                            allowcustomsorting="true">
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" AllowFiltering="false"
                                                    Reorderable="false" HeaderText="Action" Visible="true" ItemStyle-Wrap="false">
                                                    <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <div id="div_chk" style="width: inherit; height: inherit;">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input class="viewcheckboxpos" type="checkbox" runat="server" id="Id" onclick="CheckChanged(event, this, 'ctl00_ContentPlaceHolder1_GridViewDelivery');"
                                                            name="Id" value='<%# DataBinder.Eval(Container, "DataItem.DeliveryID", "{0}") %>' />&nbsp;
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="1%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <HeaderTemplate>
                                                        <div class="absmiddle">
                                                            &nbsp;</div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="left" class="view_displayflex">
                                                            <div>
                                                                <asp:PlaceHolder ID="plh_Error" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <div>
                                                                <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </mastertableview>
                                        <clientsettings allowcolumnsreorder="false" reordercolumnsonclient="false" allowdragtogroup="false">
                                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                        </clientsettings>
                                        <filtermenu onclientshown="MenuShowing" />
                                        <headerstyle width="120px" />
                                    </telerik:RadGrid>
                                </div>
                                <asp:LinkButton ID="lnkDelveryDelete" runat="server" OnClick="lnkDelveryDelete_OnClick"
                                    CausesValidation="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkDelveryArchive" runat="server" OnClick="lnkDelveryArchive_OnClick"
                                    CausesValidation="false"></asp:LinkButton>
                                <asp:HiddenField ID="hidDelveryID" runat="server" Value="" />
                            </div>
                            <div style="clear: both">
                                &nbsp;</div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="updtehidnfield" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnSelectedChkfrmGrid" runat="server" Value='0' />
                </ContentTemplate>
                <Triggers>
                    <ajax:AsyncPostBackTrigger ControlID="RadListBox1" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Alert"
        Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
        <windows>
            <telerik:RadWindow ID="DeliveryStatus" DestroyOnClose="true" Width="350" Height="150"
                runat="server">
                <ContentTemplate>
                    <div class="StatusMain">
                        <div align="center">
                            <asp:Label ID="StatusChangeNote" runat="server"><%=objLangClass.GetLanguageConversion("This_status_change_will_send_Delivery_data_to_Kings_Do_you_want_to_proceed")%></asp:Label>
                        </div>
                        <div class="StatusBtnSpace">
                        </div>
                        <div class="BtnMain" align="center">
                            <div style="float: left">
                                <div id="div_btnyes" style="display: block">
                                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="button" OnClick="btnYes_Onclick"
                                        OnClientClick="javascript:RadWinClose1();" />
                                    <%--OnClientClick="javascript:YesClick();return false;" --%>
                                </div>
                                <%--<div id="div_btnyesprocess" class="button" align="center" style="width: 26px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>--%>
                            </div>
                            <div>
                            </div>
                            <div style="margin-left: 50px">
                                <div id="div_btnno" style="display: block;">
                                    <asp:Button ID="btnNo" runat="server" Text="No" CssClass="button" OnClientClick="javascript:NoClick();return false;" />
                                </div>
                                <%--<div id="div_btnnoprocess" class="button" align="center" style="width: 21px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </windows>
    </telerik:RadWindowManager>
    <div id="commentPopup" style="display:none; position:fixed; left:50%; top:50%; transform:translate(-50%, -50%); background:white; border:1px solid #ccc; padding:20px; z-index:1000; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);">
        <span id="closePopup" style="position:absolute; top:10px; right:10px; font-size:20px; font-weight:bold; cursor:pointer;">&times;</span>
        <label style="font-weight: bold; margin-bottom: 10px; display: block;">Edit Comment:</label>
        <textarea id="txtComment" rows="4" cols="50" style="width: 100%; margin-bottom: 10px; padding: 5px; border: 1px solid #ccc;"></textarea>
        <asp:Button ID="btnSaveComment" runat="server" Text="Save" OnClick="btnSaveComment_Click" style="cursor: pointer;" />

    </div>

    <asp:HiddenField ID="hiddenCommentId" runat="server" />
    <asp:HiddenField ID="hiddenCommentText" runat="server" />
    
    <script type="text/javascript">
        function openCommentPopup(id, comment) {
            if (comment.trim() === "...") {
                comment = ""; // Set to empty if it is only '...'
            }
            document.getElementById('txtComment').value = comment;
            document.getElementById('<%= hiddenCommentId.ClientID %>').value = id;
            document.getElementById('commentPopup').style.display = 'block';
        }

        document.getElementById('<%= btnSaveComment.ClientID %>').onclick = function () {
            var newComment = document.getElementById('txtComment').value;
            document.getElementById('<%= hiddenCommentText.ClientID %>').value = newComment;
        };

        document.getElementById('closePopup').onclick = function () {
            document.getElementById('commentPopup').style.display = 'none';
        };

    </script>

    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=strSitepath%>" + "delivery/customviewdelivery.aspx";
        }
    </script>
    <script type="text/javascript">

        var div_lblView = document.getElementById("div_lblView");
        var div_ddlView = document.getElementById("div_ddlView");

        function ChangeView() {
            if (div_lblView.style.display == 'block') {
                div_lblView.style.display = 'none';
                div_ddlView.style.display = 'block';
                document.getElementById("spn_change").innerHTML = "Cancel";
            }
            else {
                div_lblView.style.display = 'block';
                div_ddlView.style.display = 'none';
                document.getElementById("spn_change").innerHTML = "Change";
            }
        }

        function testjs(val) {
            document.getElementById("<%=hidDelveryID.ClientID %>").value = val;
            return window.confirm("Are you sure,You want to delete this estimate?")
        }
        function test11(id) {
            var chk = document.getElementById(id);
            alert(chk.checked);
        }

        var hidDelveryID = document.getElementById("<%=hidDelveryID.ClientID %>");
        function DeleteDelivery(DelveryID) {
            hidDelveryID.value = DelveryID;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkDelveryDelete', '');
        }
        function ArchiveDelivery(DelveryID) {
            hidDelveryID.value = DelveryID;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkDelveryArchive', '');
        }

        var checktrue = false;
        function checkall(tblid) {
            var tbl = document.getElementById(tblid);
            var tagcount = tbl.getElementsByTagName("input");
            for (var i = 0; i < tagcount.length; i++) {
                if (tagcount[i].type == 'checkbox') {
                    if (tagcount[0].checked) {
                        tagcount[i].checked = true;
                        checktrue = true;
                        document.getElementById("lnkpo").className = "normalText";
                    }
                    else {
                        tagcount[i].checked = false;
                        checktrue = false;
                        document.getElementById("lnkpo").className = "disable";
                        document.getElementById("divmessage").style.display = "none";
                    }
                }
            }
        }
        function setCookValue(val) {
            document.cookie = "TabViewCookies=" + val + "";
        }

        document.getElementById("ds00").style.display = "none";

    </script>
    <script>

        document.getElementById("ds00").style.display = "none";

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction_View = document.getElementById("div_popupAction_View");

        function show() {
            img_actionsHide.style.display = "block";
            img_actionsShow.style.display = "none";
            div_chk.style.border = "inset 1px";
            div_chk.style.background = "#C5C5C5";
            div_popupAction_View.style.display = "block";
            div_popupAction_View.style.visibility = "visible";
        }

        function hide() {
            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";
            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";
            //note: do not use the display:none for below div. below code for strange jump in scroll in safari browser
            div_popupAction_View.style.display = "none";
            div_popupAction_View.style.visibility = "hidden";
        }

    </script>
    <script>
        function SelectGriditems(gridid, chkboxid, hdnID) {
            hide();
            var Counter = 0;
            var frm = document.getElementById(gridid);
            var frmCheckBox = frm.getElementsByTagName('input');
            var hdnCheckedID = document.getElementById(hdnID);
            hdnCheckedID.value = '';

            for (i = 0; i < frmCheckBox.length; i++) {
                var e = frmCheckBox[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked) {
                        hdnCheckedID.value += e.value + ",";
                        Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert('<%=objLangClass.GetLanguageConversion("Please_select_at_least_one_record_to_process") %>');
                return false;
            }
            else {
                return true;
            }
        }


    </script>
    <asp:HiddenField ID="editDeliveryViewID" runat="server" Value="0" />
    <script type="text/javascript">
        function editviewID_delivery() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var editDeliveryViewID = document.getElementById("<%=editDeliveryViewID.ClientID %>");
            editDeliveryViewID.value = ddl.options[ddl.selectedIndex].value;

        }

    </script>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <asp:HiddenField ID="hdnStatus" runat="server" Value="False" />
    <asp:HiddenField ID="hdn_KitStockValues" runat="server" Value="False" />
    <script>
        function CheckchkOne(type) {
            var PageType = 'delivery';
            //-----------------------------
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked) {
                        Counter = Number(Counter) + 1;
                        Ides = Ides + e.value + ",";
                    }
                }
            }
            hdnIDs.value = Ides;

            if (Number(Counter) == 0) {
                if (type == "delete") {
                    alert("<%=Delete_Row_Selection_Alert %>");
                }
                else if (type == "archive") {
                    alert("<%=Archive_Row_Selection_Alert %>");
                }
                else if (type == "unarchive") {
                    alert("<%=UnArchive_Row_Selection_Alert %>");
                }
        return false;
    }
    else {
        var check = "";
        if (type == "delete") {
            check = window.confirm('<%=objLangClass.GetLanguageConversion("Delete_Confirmation_Alert") %>');
                }
                else if (type == "archive") {
                    check = window.confirm('<%=objLangClass.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                }
                else if (type == "unarchive") {
                    check = window.confirm('<%=objLangClass.GetLanguageConversion("Are_You_Sure_You_Want_To_UnArchive_This_Records") %>');
                }
        if (check) {
            if (type == "delete") {
                if (PageType == "delivery") {
                    DeleteDelivery(Ides);
                }

            }
            else if (type == "archive") {
                if (PageType == "delivery") {
                    ArchiveDelivery(Ides);
                }

            }
            else if (type == "unarchive") {
                UnArchiveInv();
            }
            return false;
        }
        else {
            return check;
        }
    }
}

        function CheckOne(type, estimateid, estimateitemid) {

            var PageType = 'delivery';
            //-----------------------------
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");

        
            hdnIDs.value = estimateid + ",";
          

            var check = "";

            if (type == "archive") {
                check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                }
                else if (type == "unarchive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
            }
            if (check) {

                if (type == "archive") {
                    if (PageType == 'delivery') {
                        ArchiveDelivery(hdnIDs.value);
                    }

                }
                else if (type == "unarchive") {
                    //UnArchiveInv();
                    UnArchiveInv();
                }
                return false;
            }
            else {
                return check;
            }
        }

function OnRowClick(EditPage) {
    window.location = EditPage;
}

    </script>
    <script type="text/javascript" language="javascript">
        var column = null;
        function MenuShowing(sender, args) {
            if (column == null) return;
            var menu = sender; var items = menu.get_items();
            if (column.get_dataType() == "System.DateTime") {
                var i = 0;
                while (i < items.get_count()) {
                    if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '', 'GreaterThan': '', 'LessThan': '' })) {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(false);
                    }
                    else {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(true);
                    } i++;
                }
            }

            if (column.get_dataType() == "System.String") {
                var i = 0;
                while (i < items.get_count()) {
                    if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'Contains': '', 'DoesNotContain': '', 'StartsWith': '', 'EndsWith': '', 'EqualTo': '' })) {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(false);
                    }
                    else {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(true);
                    } i++;
                }
            }

            if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
                var i = 0;
                while (i < items.get_count()) {
                    if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '' })) {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(false);
                    }
                    else {
                        var item = items.getItem(i);
                        if (item != null)
                            item.set_visible(true);
                    } i++;
                }
            }
            column = null;
            menu.repaint();
        }
        function filterMenuShowing(sender, eventArgs) {
            column = eventArgs.get_column();
        }

        function ShowPopUp(sender, eventArgs) {

            var oWnd = $find("<%=DeliveryStatus.ClientID%>");
            oWnd.show();
        }


        function NoClick() {

            RadWinClose1();
            return false;
        }

        function YesClick() {

            var hdnStatus = document.getElementById("<%=hdnStatus.ClientID%>");
            var hdnSelectedChkfrmGrid = document.getElementById("<%=hdnSelectedChkfrmGrid.ClientID%>");
            hdnStatus.value = "true";
            RadWinClose1();
            return false;
        }

        function RadWinClose1() {
            var oWnd = $find("<%=DeliveryStatus.ClientID%>");
            oWnd.close();
        }
        //by gopi : grid loads if rows not selected fixed
        function OnClientSelectedIndexChanged(sender, args) {

            var frm = document.forms[0];
            var Counter = 0;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked) {
                        Counter = Number(Counter) + 1;
                    }
                }
            }
            if (Number(Counter) == 0) {
                sender.set_autoPostBack(false);
            }
            else {
                sender.set_autoPostBack(true);
                __doPostBack("<%=RadListBox1.ClientID%>", '');
            }
        }
    </script>
</asp:Content>


