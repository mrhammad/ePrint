<%@ Page Title="" Language="C#" MasterPageFile="~/innerMasterPage_withoutLeftTD.Master" AutoEventWireup="true" CodeBehind="Proofs.aspx.cs" Inherits="ePrint.Estimates.Proofs" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
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
            <telerik:AjaxSetting AjaxControlID="RadListBox2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListBox2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hdnaddress1" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress2" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress3" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress4" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress5" runat="server" Value="" />
    <div id="ds00" style="display: block;">
    </div>

    <script>
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";

    </script>
    <style type="text/css">
        .RadGrid .rgHeader {
            padding-right: 4px;
            padding-left: 2px;
        }

        .RadGrid .rgRow td {
            padding-left: 2px;
        }

        .RadGrid .rgAltRow td {
            padding-left: 2px;
        }

        .RadGrid .rgFilterRow td {
            padding-left: 2px;
            padding-right: 2px;
        }

        /*.RadGrid_Eprint_Skin .rgActiveRow, .RadGrid_Eprint_Skin .rgHoveredRow {
            background-color: #CFEBFA;
        }*/
        .RadGrid tr.rgRow:hover {
            /*background: #CFEBFA;*/
            cursor: pointer;
        }

        .RadGrid tr.rgAltRow:hover {
            /*background: #CFEBFA;*/
            cursor: pointer;
        }

        .RadGrid .rgHoveredRow {
            /*background-color: #CFEBFA;*/
            cursor: pointer;
        }

        .hyperlinkStyle {
            cursor: pointer;
            color: blue;
            text-decoration: underline;
        }
    </style>
   <%-- <asp:UpdateProgress ID="upProgress" runat="server">
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
    </asp:UpdateProgress>--%>
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
                <div align="left" style="width: 50%; position: absolute; left: 48%">
                    <div style="width: 290px;">
                        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>

            <div style="height: 18px; margin-top: -10px; margin-bottom: 10px;">
                <div id="div_ddlView" style="float: left; /*display: none*/">
                    <asp:DropDownList ID="ddl_View" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged" Width="110%"
                        AutoPostBack="true" runat="server" Style="height: 23px; outline: none; border-radius: 4px; cursor: pointer;">
                    </asp:DropDownList>
                </div>
                <div style="float: left; margin-left: 35px; padding-top: 3px;">
                    <asp:LinkButton ID="lnkPurchaseedit" runat="server" Style="text-decoration: underline;"
                        OnClientClick="javascript:return edit_estimatview();" OnClick="btnEditView_Click"><%=objLanguage.GetLanguageConversion("Edit_Add") %></asp:LinkButton>
                    <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display: none; cursor: pointer; color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                </div>
                <div style="float: right; padding-left: 0px; padding-top: 5px; margin-right: -1.2px;">
                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                        runat="server"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                </div>
                <div id="div_lblView" style="float: left; display: none">
                    <asp:Label ID="lblView" runat="server"></asp:Label>
                </div>
            </div>

        </div>
        <div align="left" style="width: 100%; margin-top: -4px;">
            <div style="width: 100%;">
                <asp:HiddenField ID="hdnAlphabet" runat="server" />
                <div align="left" style="padding-top: 5px; width: 100%;">
                    <div id="div_Main" runat="server">
                        <div id="div_Grid">
                            <div id="div_popupAction_View" style="" onmouseover="show();" onmouseout="hide();  ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <asp:Panel ID="pnl_StatusList" runat="server">
                                                    <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100%"
                                                        Skin="EprintListbox" EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                        BackColor="White">
                                                        <HeaderTemplate>
                                                            <span style="color: #333; line-height: 23px; font-weight: 100; padding: 5px 0px 5px 5px; font-family: Verdana; font-size: 10px;">
                                                                <asp:Label ID="lblChangeStatus" runat="server"><%=objLanguage.GetLanguageConversion("Change_Status") %></asp:Label></span>
                                                        </HeaderTemplate>
                                                        <Items>
                                                        </Items>
                                                    </telerik:RadListBox>
                                                </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <div id="divarchive" runat="server" class="divDropdownlist" onclick="javascript:return CheckchkOne('archive');"
                                                style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 0px solid #CBCBCB;">
                                                <asp:Label ID="lblArchive" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                   <%--  <tr>
                                        <td>
                                            <div id="divunarchive" runat="server" onclick="javascript:return CheckchkOne('unarchive');"
                                                class="divDropdownlist" style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 1px solid #CBCBCB;">
                                                <asp:Label ID="lblUnArchive" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <div id="divDelete" runat="server" onclick="javascript:return CheckchkOne('delete');"
                                                class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <telerik:RadGrid ID="GridView1" AllowSorting="true" OnItemDataBound="GridView1_ItemDataBound"
                                ShowGroupPanel="false" AllowFilteringByColumn="true" ShowStatusBar="true" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridView1_ColumnCreated"
                                OnNeedDataSource="GridView1_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridView1_SortCommand"
                                OnGroupHeaderItemDataBound="GridView1_GroupHeaderItemDataBound"
                                OnItemCommand="GridView1_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                EnableEmbeddedSkins="false" Width="100%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                FilterItemStyle-Wrap="true" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                <ClientSettings EnablePostBackOnRowClick="true"></ClientSettings>
                                <%--                                <ClientSettings EnableRowHoverStyle="true"></ClientSettings>--%>
                                <PagerStyle AlwaysVisible="false"></PagerStyle>
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <HeaderStyle CssClass="gv_ViewsHeader" Width="120px" />
                                <MasterTableView OverrideDataSourceControlSorting="true" AllowCustomSorting="true">
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input class="viewcheckboxpos" type="checkbox" runat="server" id="Id" onclick="CheckChanged(event, this, 'ctl00_ContentPlaceHolder1_GridView1');"
                                                    name="Id" />&nbsp;
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="1%" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="true" Width="1%" />
                                            <HeaderTemplate>
                                                <div class="absmiddle">
                                                    &nbsp;
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div align="left" class="view_displayflex">
                                                    <div>
                                                        <asp:PlaceHolder ID="plhConvertJob" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plhBackOrder" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_Error" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_EmailSent" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <%--Below Two line is for displaying H for customer status accounts on hold icon in view page  --%>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_customerstatus" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_stockproduct" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>
                                <FilterMenu OnClientShown="MenuShowing" />
                            </telerik:RadGrid>
                        </div>
                        <asp:LinkButton ID="lnkProofDelete" runat="server" Text=" " OnClick="lnkProofDelete_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkProofArchive" runat="server" Text=" " OnClick="lnkProofArchive_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkEstUnArchive" runat="server" Text=" "
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkEstimateCopy" runat="server" Text=""
                            CausesValidation="false" Visible="true"></asp:LinkButton>
                    </div>
                    <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                    <asp:HiddenField runat="server" ID="hdnEstimateItemID" Value="0" />

                    <%-- <script>

                                //By Thejesh Code Optimization

                                function testjs(val) {
                                    document.getElementById("<%=hdnEstimateID.ClientID %>").value = val;
                                    return window.confirm("Are you sure,You want to delete this estimate?")
                                }
                                function test11(id) {
                                    var chk = document.getElementById(id);
                                    alert(chk.checked);
                                }
                            </script>--%>
                </div>
                <div style="clear: both">
                    &nbsp;
                </div>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
          <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            KeepInScreenBounds="true" Opacity="100" runat="server" Width="1000" Height="610"
            OnClientClose="RadWinClose" Behaviors="Close,Move,Reload,Resize" style=" overflow:hidden;">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" RenderMode="Lightweight" EnableShadow="false"  OnClientClose="RadWinClose"
                    KeepInScreenBounds="true" VisibleTitlebar="true" Modal="true" Behaviors="Close,Reload"
                    DestroyOnClose="true">
                </telerik:RadWindow>

            </Windows>
        </telerik:RadWindowManager>
    </div>
     <div id="divBackGroundNew" style="display: none; overflow:hidden;">
    </div>
    <div id="divDeliveryDate" style=" display:none;overflow:hidden;">
     
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />


    <script type="text/javascript">
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        //var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");


        //By thejesh Code Optimization

        //var div_lblView = document.getElementById("div_lblView");
        //var div_ddlView = document.getElementById("div_ddlView");

        //function ChangeView() {
        //    if (div_lblView.style.display == 'block') {
        //        document.getElementById("spn_change").innerHTML = "Cancel";
        //        div_lblView.style.display = 'none';
        //        div_ddlView.style.display = 'block';
        //    }
        //    else {
        //        document.getElementById("spn_change").innerHTML = "Change";
        //        div_lblView.style.display = 'block';
        //        div_ddlView.style.display = 'none';
        //    }
        //}


        function setCookValue(val) {
            document.cookie = "TabViewCookies=" + val + "";
        }
    </script>
    <%--  <asp:UpdatePanel ID="updtehidnfield" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hdnSelectedChkfrmGrid" runat="server" Value='0' />
        </ContentTemplate>
        <Triggers>
            <ajax:AsyncPostBackTrigger ControlID="RadListBox1" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <script type="text/javascript">

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

            //below code for strange jump in scroll in safari browser
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


        function SelectGriditems(gridid, chkboxid, hdnID) {
            debugger;
            hide();
            var Counter = 0;
            var frm = document.getElementById(gridid);
            var frmCheckBox = frm.getElementsByTagName('input');
            var hdnCheckedID = document.getElementById(hdnID);
            hdnCheckedID.value = '';

            for (i = 0; i < frmCheckBox.length; i++) {
                var e = frmCheckBox[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1 && Number(e.value) != 0) {
                    if (e.checked) {
                        hdnCheckedID.value += e.value + ",";
                        Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Please_select_at_least_one_record_to_process") %>');
                return false;
            }
            else {
                return true;

            }
        }


    </script>
    <asp:HiddenField ID="edit_estViewID" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">
        function edit_estimatview() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var edit_estViewID = document.getElementById("<%=edit_estViewID.ClientID %>");
            edit_estViewID.value = ddl.options[ddl.selectedIndex].value;
        }

    </script>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">
        function DeleteInv() {
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkProofDelete', '');
        }
        function ArchiveEstimate() {
            debugger;
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkProofArchive', '');
        }
        function CheckchkOne(type) {

            var PageType = 'proof';
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
                    //alert("Please check at least one 'row' to Delete");
                    alert("<%=Delete_Row_Selection_Alert %>");
                }
                else if (type == "archive") {
                    //alert("Please check at least one 'row' to Archive");
                    alert("<%=Archive_Row_Selection_Alert %>");
                }

                return false;
            }
            else {
                var check = "";

                if (type == "delete") {

            // check = window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert") %>');
                            check = window.confirm('<%=objLanguage.GetLanguageConversion("Note_For_deleting_the_proof_item") %>');
                        }
                        else if (type == "archive") {
                            check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                        }
                        else if (type == "unarchive") {
                            check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
                }
                if (check) {
                    if (type == "delete") {
                        DeleteInv();

                    }
                    else if (type == "archive") {
                        ArchiveEstimate();

                    }

                    return false;
                }
                else {
                    return check;
                }
            }
        }

        function CheckOne(type, estimateid, estimateitemid) {

            var PageType = 'proof';
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
                            if (PageType == 'proof') {
                                ArchiveEstimate();
                            }

                        }
                        else if (type == "unarchive") {
                            //UnArchiveInv();
                            UnArchiveEstimate();
                        }
                        return false;
                    }
                    else {
                        return check;
                    }
                }

        function CheckAll(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                    e.checked = ChkState;
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1)
                    e.checked = ChkState;
            }
        }

        function OnRowClick(EditPage) {
            window.location = EditPage;
        }

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

        function OnApprovalDateClick(approvalDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?approvalDate=" +
                   approvalDate + "&type=approvaldate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

         }
        function OnSalesPersonClick(jobId, salesPersonId, clientId, type) {
            debugger;
            var RadWindowHistory = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?salesPersonId=" + salesPersonId + "&type=salesPerson&pg=&JobId=" + jobId + "&clientId=" + clientId + "&userType=" + type);
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindowHistory.setSize(450, 300);
            RadWindowHistory.center();
            return false;
        }

        function OnArtworkDateClick(artworkDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?artworkDate=" +
                artworkDate + "&type=artworkdate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
            return false;

        }

        function OnProofDateClick(proofDate, jobId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?proofDate=" +
                proofDate + "&type=proofdate_update&pg=&JobId=" + jobId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;
        }

        function OnDeliveryDateClick(deliveyDate, jobId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?deliveyDate=" +
            deliveyDate + "&type=deliverydate_update&pg=&JobId=" + jobId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
            return false;

        }

        function OnProductionDateClick(productionDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?productionDate=" +
                productionDate + "&type=productiondate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

         }
        //by gopi : grid loads if rows not selected fixed
       <%-- function OnClientSelectedIndexChanged(sender, args) {

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

        }--%>
    </script>
    <script type="text/javascript" language="javascript">
        function HideShowComments(val) {


            document.getElementById('addCommentsAndChangeStatus').style.display = val;
           <%-- var txtSupplierComments = document.getElementById("<%=txtSupplierComments.ClientID %>");
            var txtCustomerComments = document.getElementById("<%=txtCustomerComments.ClientID %>");
            txtSupplierComments.value = "";
            txtCustomerComments.value = "";--%>


        }


        $(document).ready(function () {
            debugger;
            console.log("ready!");
        });

    </script>

</asp:Content>
