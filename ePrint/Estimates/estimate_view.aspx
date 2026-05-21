<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.Master" CodeBehind="~/Estimates/estimate_view.aspx.cs" Inherits="ePrint.Printcenter.Views.Estimate.estimate_view" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ajaxsettings>
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
        </ajaxsettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hdnaddress1" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress2" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress3" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress4" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress5" runat="server" Value="" />
    <div id="ds00" style="display: block;">
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
                            <img src="<%=strImagepath %>loading_new.gif" border="0" />
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
                <div align="left" style="width: 50%;position:absolute;left:48%">
                    <div style="width: 290px;">
                        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="height: 18px; margin-top:-10px; margin-bottom:10px;">
                     <div id="div_ddlView" style="float: left; /*display: none*/">
                            <asp:DropDownList ID="ddl_View" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged" Width="110%"
                                AutoPostBack="true" runat="server" style="height:23px; outline:none; border-radius:4px;cursor:pointer;">
                            </asp:DropDownList>
                        </div>
                        <div style="float: left; margin-left:35px;padding-top:3px;">
                            <asp:LinkButton ID="lnkPurchaseedit" runat="server" Style="text-decoration: underline;"
                                OnClientClick="javascript:return edit_estimatview();" OnClick="btnEditView_Click"><%=objLanguage.GetLanguageConversion("Edit_Add") %></asp:LinkButton>
                            <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display:none; cursor: pointer;
                                    color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                        </div>
                    <div style="float: right; padding-left: 0px; padding-top:5px; margin-right:-1.2px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                            cursor: pointer" runat="server"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                    </div>
                    <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                        <div style="float: left;display: none"">
                            <span class="HeaderText" style="color: #787878">
                                <%=objLanguage.GetLanguageConversion("Current_View")%></span>
                        </div>
                        <div class="Only5pxWidth">
                            &nbsp;</div>
                        <div id="div_lblView" style="float: left; display: none">
                            <asp:Label ID="lblView" runat="server"></asp:Label>
                        </div>
                       
                        <div class="Only5pxWidth">
                            &nbsp;</div>
                        <div style="float: left; display: none;">
                            <span class="normalText" style="color: #787878">
                                <%=objLanguage.GetLanguageConversion("Or_Try")%></span><a href="../estimates/estimate_search.aspx"
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
                                    <div id="div_popupAction_View" style="" onmouseover="show();" onmouseout="hide();  ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <asp:Panel ID="pnl_StatusList" runat="server">
                                                            <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100%"
                                                                Skin="EprintListbox" EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                                OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged"
                                                                OnClientSelectedIndexChanged="OnClientSelectedIndexChanged" BackColor="White">
                                                                <headertemplate>
                                                                    <span style="color: #333; line-height: 23px; font-weight: 100; padding: 5px 0px 5px 5px;
                                                                        font-family: Verdana; font-size: 10px;">
                                                                        <asp:Label ID="lblChangeStatus" runat="server"><%=objLanguage.GetLanguageConversion("Change_Status") %></asp:Label></span>
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
                                                        <asp:Label ID="lblArchive" runat="server"></asp:Label></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divunarchive" runat="server" onclick="javascript:return CheckchkOne('unarchive');"
                                                        class="divDropdownlist" style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB;
                                                        border-top: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblUnArchive" runat="server"></asp:Label></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divDelete" runat="server" onclick="javascript:return CheckchkOne('delete');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblDelete" runat="server"></asp:Label></div>
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
                                        EnableEmbeddedSkins="true" Width="100%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                        <pagerstyle alwaysvisible="false"></pagerstyle>
                                        <filtermenu cssclass="RadMenu_Eprint_Skin" />
                                        <headerstyle cssclass="gv_ViewsHeader" width="120px" />
                                        <mastertableview overridedatasourcecontrolsorting="true" allowcustomsorting="true">
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
                                                        <input class="viewcheckboxpos" type="checkbox" runat="server" id="Id" onclick="CheckChanged(event, this, 'ctl00_ContentPlaceHolder1_GridView1');"
                                                            name="Id" />&nbsp;
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="1%" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Width="1%" />
                                                    <HeaderTemplate>
                                                        <div class="absmiddle">
                                                            &nbsp;</div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="left" class="view_displayflex">
                                                            <div>
                                                                <asp:PlaceHolder ID="plh_EstimateRowIcon" runat="server"></asp:PlaceHolder>
                                                            </div>
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
                                        </mastertableview>
                                        <clientsettings allowcolumnsreorder="false" reordercolumnsonclient="false" allowdragtogroup="false">
                                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                        </clientsettings>
                                        <filtermenu onclientshown="MenuShowing" />
                                    </telerik:RadGrid>
                                </div>
                                <asp:LinkButton ID="lnkEstDelete" runat="server" Text=" " OnClick="lnkEstDelete_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkEstArchive" runat="server" Text=" " OnClick="lnkEstArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkEstUnArchive" runat="server" Text=" " OnClick="lnkUnEstArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkEstimateCopy" runat="server" Text="" OnClick="lnkEstimateCopy_OnClick"
                                    CausesValidation="false" Visible="true"></asp:LinkButton>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />

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
                            &nbsp;</div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
            <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
        </div>
    </div>
    <div id="commentPopup" style="display:none; position:fixed; left:50%; top:50%; transform:translate(-50%, -50%); background:white; border:1px solid #ccc; padding:20px; z-index:1000; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);">
        <span id="closePopup" style="position:absolute; top:10px; right:10px; font-size:20px; font-weight:bold; cursor:pointer;">&times;</span>
        <label style="font-weight: bold; margin-bottom: 10px; display: block;">Edit Comment:</label>
        <textarea id="txtComment" rows="4" cols="50" style="width: 100%; margin-bottom: 10px; padding: 5px; border: 1px solid #ccc;"></textarea>
        <asp:Button ID="btnSaveComment" runat="server" Text="Save" OnClick="btnSaveComment_Click" style="cursor: pointer;" />

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

        function CloseDiv() {
            document.getElementById("div_Note").style.display = "none";
            document.getElementById('divBackGroundNew').style.display = "none";
        }
        function RadWinClose() {
            debugger;
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }

     
        function OnPriorityClick(estid,priority) {
            var type = "priority";
            var RadWindowHistory = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?type=priority&priority=" + priority +"&pg=estimate&id=" + estid );
               SetRadWindow('divrad', 'divBackGroundNew');
               RadWindowHistory.setSize(450, 300);
               RadWindowHistory.center();
               return false;
           }

    </script>



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

        function DeleteInv() {
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkEstDelete', '');
        }
        function ArchiveEstimate() {
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkEstArchive', '');
        }

        function UnArchiveEstimate() {
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkEstUnArchive', '');
        }

        function CopyEstimate() {
            document.getElementById("<%=hdnEstimateIds.ClientID %>").value = document.getElementById("ctl00_tint_hdnIDs").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkEstimateCopy', '')
        }


        function setCookValue(val) {
            document.cookie = "TabViewCookies=" + val + "";
        }
    </script>
    <asp:UpdatePanel ID="updtehidnfield" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hdnSelectedChkfrmGrid" runat="server" Value='0' />
        </ContentTemplate>
        <Triggers>
            <ajax:AsyncPostBackTrigger ControlID="RadListBox1" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
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
        var IsItemSelected = "<%=IsItemSelected%>";
        function CheckchkOne(type) {

            var PageType = 'estimate';
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
                else if (type == "unarchive") {
                    //alert("Please check at least one 'row' to Un-Archive");
                    alert("<%=UnArchive_Row_Selection_Alert %>");
                }
        return false;
    }
    else {
        var check = "";

        if (type == "delete") {

            // check = window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert") %>');

            if (IsItemSelected.toLowerCase() == "true") {

                check = window.confirm('<%=objLanguage.GetLanguageConversion("Note_For_deleting_the_estimate_item") %>');

                    }
                    else {

                        check = window.confirm('<%=objLanguage.GetLanguageConversion("Note_For_deleting_the_estimate") %>');
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
                DeleteInv();

            }
            else if (type == "archive") {
                if (PageType == 'estimate') {
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
        }

        function CheckOne(type,estimateid,estimateitemid) {

            var PageType = 'estimate';
            //-----------------------------
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");

            if (IsItemSelected.toLowerCase() == "true") {
                hdnIDs.value = estimateitemid + ",";
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
                if (PageType == 'estimate') {
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
    //    sender.set_autoPostBack(false);
        //alert('Please select at least one row.');

        // Cancel selection change so server event is not triggered
        // Revert to previous selected item
        var oldItem = sender.get_selectedItem();
        if (oldItem) {
            oldItem.unselect();
        }
        args.get_item().unselect();
    }
    <%--else {
        sender.set_autoPostBack(true);
        __doPostBack("<%=RadListBox1.ClientID%>", '');
    }--%>

}
    </script>
    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=strSitepath%>" + "estimates/customview.aspx";
        }
    </script>
</asp:Content>

