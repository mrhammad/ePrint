<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" CodeBehind="order_view.aspx.cs" Inherits="ePrint.orders.order_view" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagName="ProgressToJob" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_progress_to_job.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type ="hidden" name ="hdnOrderProgressToJob" id="hdnOrderProgressToJob" value="0"/>
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
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListBox1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div id="ds00" style="display: block;">
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
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
        .hyperlinkNoUnderline {
            cursor: pointer;
            color: blue;
        }
    </style>
    <asp:UpdateProgress ID="upProgress" runat="server">
        <ProgressTemplate>
            <div id="divBackGround1">
                <div id="divLoading" style="position: absolute; z-index: 800; display: block;">
                    <div class="Graphic">
                        <div style="padding-left: 25px">
                            <img src="<%=strImagepath %>loading_new.gif" border="0" alt='loading' />
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
                <div style="height: 18px; margin-top: -10px; margin-bottom: 10px;">
                    <div id="div_ddlView" style="float: left; /*display: none; */">
                        <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged" Width="110%"
                            Style="height: 23px; border-radius: 4px; background-color: white; outline: none; cursor: pointer;" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-left: 35px; padding-top: 3px;">
                        <asp:LinkButton ID="lnkOrderedit" runat="server" Style="text-decoration: underline;"
                            OnClientClick="javascript:return editviewID_order();" OnClick="btnEditViewOrder_Click"><%=objLanguage.GetLanguageConversion("Edit_Add")%></asp:LinkButton>
                        <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; cursor: pointer; display: none; color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                    </div>
                    <div style="float: right; padding-left: 0px; padding-top: 5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                            runat="server"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                    </div>
                    <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                        <div style="float: left; display: none">
                            <span class="HeaderText" style="color: #787878">
                                <%=objLanguage.GetLanguageConversion("Current_View")%></span>
                        </div>
                        <div class="Only5pxWidth">
                            &nbsp;
                        </div>
                        <div id="div_lblView" style="float: left; display: none">
                            <asp:Label ID="lblView" runat="server"></asp:Label>
                        </div>

                        <div class="Only5pxWidth">
                            &nbsp;
                        </div>
                        <div style="float: left; display: none;">
                            <span class="normalText" style="color: #787878">
                                <%=objLanguage.GetLanguageConversion("Or_Try")%></span><a href="../orders/order_search.aspx"
                                    id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                    <%=objLanguage.GetLanguageConversion("Advanced_Search")%></a>
                        </div>
                    </div>
                </div>
                <div align="left" style="width: 100%; margin-top: -4px;">
                    <div style="width: 100%;">
                        <asp:HiddenField ID="hdnAlphabet" runat="server" />
                        <div align="left" style="padding-top: 5px; width: 100%;">
                            <div id="div_Main" runat="server">
                                <div id="div_Grid">
                                    <div id="div_popupAction_View" style="" onmouseover="show();" onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100%"
                                                            Skin="EprintListbox" EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                            OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged"
                                                            OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                                                            <HeaderTemplate>
                                                                <span style="color: #333; line-height: 23px; font-weight: 100; padding: 5px 0px 5px 5px; font-family: Verdana; font-size: 10px;">
                                                                    <asp:Label ID="lblChangeStatus" runat="server"><%=objLanguage.GetLanguageConversion("Change_Status") %></asp:Label></span>
                                                            </HeaderTemplate>
                                                            <Items>
                                                            </Items>
                                                        </telerik:RadListBox>
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
                                                    <div id="divunarchive" runat="server" onclick="javascript:return CheckchkOne('unarchive');"
                                                        class="divDropdownlist" style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblUnArchive" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divDelete" runat="server" onclick="javascript:return CheckchkOne('delete');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div id="divProgressToJob" runat="server" onclick="javascript:return ShowProgressToJob_Individual();"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="ProgressToJob" runat="server">Progress to Job</asp:Label>
                                                    </div>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="GridView1" runat="server" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridView1"
                                        ShowGroupPanel="false" AllowFilteringByColumn="true" ShowStatusBar="true" 
                                        AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridView1_ColumnCreated"
                                        OnNeedDataSource="GridView1_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridView1_SortCommand"
                                         OnGroupHeaderItemDataBound="GridView1_GroupHeaderItemDataBound"
                                        OnItemCommand="GridView1_ItemCommand" Skin="Sunset" AllowCustomPaging="true"
                                        EnableEmbeddedSkins="true" Width="100%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                        FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false"></PagerStyle>
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <HeaderStyle Width="120px" />
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
                                                            name="Id" value='<%#String.Concat(Eval("OrderID"),"_",Eval("estimateid").ToString(),"_",Eval("EstimateItemID").ToString()) %>' />&nbsp;
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="1%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
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
                                                                <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <div>
                                                                <asp:PlaceHolder ID="plhHasReplenishItem" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <%--Below Two line is for displaying H for customer status accounts on hold icon in view page --%>
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
                                <asp:LinkButton ID="lnkOrderDelete" runat="server" Text=" " OnClick="lnkOrderDelete_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkOrderArchive" runat="server" Text=" " OnClick="lnkOrderArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkOrderUnArchive" runat="server" Text=" " OnClick="lnkOrderUnArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnOrderID" Value="0" />
                            <script>
                                function testjs(val) {
                                    document.getElementById("<%=hdnOrderID.ClientID %>").value = val;
                                    return window.confirm("Are you sure,You want to delete this Order?")
                                }
                                function test11(id) {
                                    var chk = document.getElementById(id);
                                    alert(chk.checked);
                                }
                            </script>
                        </div>
                        <div style="clear: both">
                            &nbsp;
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
            <asp:HiddenField ID="hdnOrderIds" runat="server" Value="0" />
        </div>
        <asp:UpdatePanel ID="updtehidnfield" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hdnSelectedChkfrmGrid" runat="server" Value='0' />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RadListBox1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=strSitepath%>" + "orders/customvieworder.aspx";
        }
    </script>
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
    <script type="text/javascript">
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var div_lblView = document.getElementById("div_lblView");
        var div_ddlView = document.getElementById("div_ddlView");

        function ChangeView() {
            if (div_lblView.style.display == 'block') {
                document.getElementById("spn_change").innerHTML = "Cancel";
                div_lblView.style.display = 'none';
                div_ddlView.style.display = 'block';
            }
            else {
                document.getElementById("spn_change").innerHTML = "Change";
                div_lblView.style.display = 'block';
                div_ddlView.style.display = 'none';
            }
        }

        function DeleteOrder() {
            document.getElementById("<%=hdnOrderIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkOrderDelete', '');
        }
        function ArchiveOrder() {
            document.getElementById("<%=hdnOrderIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkOrderArchive', '');
        }
        function UnArchiveOrder() {
            document.getElementById("<%=hdnOrderIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkOrderUnArchive', '');
        }
    </script>
    <script>
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
                alert('<%=objLanguage.GetLanguageConversion("Please_select_at_least_one_record_to_process") %>');
                return false;
            }
            else {
                return true;
            }
        }


    </script>
    <div id="div_ProgressToJob" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 40%; height: 50%"
        align="center">
        <asp:PlaceHolder ID="plhProgressToJob" runat="server"></asp:PlaceHolder>
    </div>
    <asp:HiddenField ID="editOrderViewID" runat="server" Value="0" />
    <script type="text/javascript">
        function editviewID_order() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var editOrderViewID = document.getElementById("<%=editOrderViewID.ClientID %>");
            editOrderViewID.value = ddl.options[ddl.selectedIndex].value;

        }
    </script>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <script type="text/javascript">
        var IsItemSelected = "<%=IsItemSelected%>";
        function CheckchkOne(type) {
            debugger;
            var PageType = 'orders';
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
                    // check = window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert") %>');
                    if (IsItemSelected.toLowerCase() == "true") {

                        check = window.confirm('<%=objLanguage.GetLanguageConversion("Note_For_deleting_the_order_item") %>');

                    }
                    else {

                        check = window.confirm('<%=objLanguage.GetLanguageConversion("Note_For_deleting_the_order") %>');
                    }
                }
                else if (type == "archive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                }
                else if (type == "unarchive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
                }
                if (check) {
                    if (type == "delete") {
                        if (PageType == "orders") {
                            DeleteOrder(Ides);
                        }

                    }
                    else if (type == "archive") {
                        if (PageType == "orders") {
                            ArchiveOrder(Ides);
                        }

                    }
                    else if (type == "unarchive") {
                        UnArchiveOrder();
                    }
                    return false;
                }
                else {
                    return check;
                }
            }
        }


        function CheckOne(type, estimateid, estimateitemid) {

            var PageType = 'orders';
            //-----------------------------
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");

                if (IsItemSelected.toLowerCase() == "true") {
                    hdnIDs.value = estimateid + "_"+estimateid + "_"+estimateitemid + ",";
                }
                else {
                    hdnIDs.value = estimateid + ",";
                }

                var check = "";

                if (type == "archive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
}
else if (type == "unarchive") {
    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
            }
            if (check) {

                if (type == "archive") {
                    if (PageType == 'orders') {
                        ArchiveOrder();
                    }

                }
                else if (type == "unarchive") {
                    //UnArchiveInv();
                    UnArchiveOrder();
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

        function ShowProgressToJob_Individual() {

            debugger;

            //var hdnCheckJobCreate = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCheckJobCreate");
            //hdnCheckJobCreate.value = "true";

            //var hdnIndJobCreateItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnIndJobCreateItemID");
            //hdnIndJobCreateItemID.value = id;

            //if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "order") {
            //    //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            //    alert(AccountsOnHoldOrderProgressToJob);
            //}
            //if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "estimate") {
            //    //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            //    alert(AccountsOnHoldEstimateProgressToJob);
            //}
            //else {
            //    div_showinprospect.style.display = "none";
            //    if (CompanyType == "Prospect") {
            //        div_showinprospect.style.display = "block";
            //        if (div_ProgressToJob.style.display == "none") {
            //            showDivPopupCenter('div_ProgressToJob', '200');
            //            var selects = document.getElementsByTagName("select");
            //            for (i = 0; i != selects.length; i++) {
            //                selects[i].style.display = 'none';
            //            }
            //        }
            //        else {
            //            div_ProgressToJob.style.display = "none";
            //            divBackGroundNew.style.display = "none";
            //        }
            //    }
            //    else {
            //        if (div_ProgressToJob.style.display == "none") {
            //            showDivPopupCenter('div_ProgressToJob', '200');

            //            document.getElementById("divEstItemsList").style.display = "none";
            //            if (IsArchive == "true") {
            //                document.getElementById("div_IsArchive").style.display = "block";
            //                document.getElementById("divdates").style.display = "none";

            //                document.getElementById("divIsArchivePrompt").style.display = "none";
            //                document.getElementById("divProgressToJob").style.display = "block";
            //            }
            //            else {
            //                document.getElementById("div_IsArchive").style.display = "none";
            //                document.getElementById("divdates").style.display = "block";
            //                EstItemListNext_Individual();
            //            }

            //            var selects = document.getElementsByTagName("select");
            //        }
            //        else {
            //            div_ProgressToJob.style.display = "none";
            //            divBackGroundNew.style.display = "none";
            //        }
            //    }
            //}

            var PageType = 'orders';
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
            document.getElementById("hdnOrderProgressToJob").value = Ides;
            document.getElementById("ctl00_ContentPlaceHolder1_UcProgressToJob_hdn_OrderProgressToJob").value = document.getElementById("hdnOrderProgressToJob").value;
            if (Number(Counter) == 0) {
                alert("Please check at least one row to progress to job");
                return false;
            } else {
                showDivPopupCenter('div_ProgressToJob', '200');
            }
        }

        function CloseDiv() {
            document.getElementById("div_ProgressToJob").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            //if (hdnEmailselectOrnot.value == "email") {
            //    document.getElementById("div_ProgressToJob").style.display = "none";
            //    document.getElementById("Div_Print_Email").style.display = "none";
            //    document.getElementById("divBackGroundNew").style.display = "none";
            //    hdnEmailselectOrnot.value = "";
            //}
            //else {
            //    location.reload();
            //}
        }
    </script>
</asp:Content>
