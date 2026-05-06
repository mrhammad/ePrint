<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="jobs_view.aspx.cs" Inherits="ePrint.Jobs.jobs_view" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/AlphabetSearch.ascx" TagName="AlphabetSearch" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
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
    <div id="div_Note" style="display: none; position: fixed; vertical-align: middle; z-index: 100; width: 100%;"
        align="center">
        <table cellpadding="0" cellspacing="0" width="35%" height="82%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" id="div_Job_delete" class="Label-PopupHeading" style="float: right; padding-top: 6px; padding-right: 15px;">
                        <div class="CancelButtonDiv2">
                            <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv();return false;" />
                        </div>
                    </div>
                </td>
                <td colspan="2" class="popup-top-rightcorner">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="popup-middle-leftcorner">&nbsp;
                </td>
                <td style="width: 15px; background-color: #ffffff">&nbsp;
                </td>
                <td class="popup-middlebg" align="center" valign="top">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td valign="top">
                                <div id="div_Delete_JOb">
                                    <div id="div_rdb_Delete_Job" style="float: left; padding-bottom: 7px;">
                                        <span style="font-weight: bold;">
                                            <asp:RadioButton ID="rdb_Delete_Job" runat="server" GroupName="delete" Checked="true"
                                                Text="Delete Job and keep Estimate live" />
                                        </span>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div style="float: left; padding-bottom: 7px;">
                                        <span style="font-weight: bold;">
                                            <asp:RadioButton ID="rdb_Delete_All" runat="server" GroupName="delete" Text="Delete Job and its corresponding Estimate/Estimate Item" />
                                        </span>
                                    </div>
                                    <div align="left" id="div_Msg_Note" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-bottom: 7px; padding-left: 1px;">
                                        <b>Note: </b>
                                        <asp:Label ID="lbl_note" runat="server" Text="By deleteing the job,its corresponding invoice will be deleted"></asp:Label>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                        <asp:Button ID="btn_Delete_JOb" runat="server" Text="Delete" CssClass="button" OnClientClick="javascript:DeleteInv();return false;" />
                                        <div id="div_loading_btn_Delete_JOb" style="display: none; width: 52px; padding-bottom: 1px; padding-top: 1px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
                                            <image src="../images/radimg1.gif" alt="loading" class="loadingimg"></image>
                                        </div>
                                    </div>
                                    <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                        <asp:Button ID="btn_Delete_Cancel" runat="server" Text="Cancel" CssClass="button"
                                            OnClientClick="javascript:CloseDiv();return false;" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px; background-color: #ffffff">&nbsp;
                </td>
                <td align="right" class="popup-middle-rightcorner">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
                </td>
                <td class="popup-bottom-middlebg">&nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }

        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";

        function CloseDiv() {
            document.getElementById("div_Note").style.display = "none";
            document.getElementById('divBackGroundNew').style.display = "none";
        }
        function RadWinClose() {
            debugger;
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            window.location.reload();

        }
       
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

        .hyperlinkStyle {
            cursor: pointer;
            color: blue;
            text-decoration: underline;
        }

        .hyperlinkNoUnderline {
            cursor: pointer;
            color: blue;
        }

        .header-style-class {
            white-space: nowrap;
            overflow: hidden;
        }
    </style>
    <div id="content">
        <div style="margin-top: -2px;">
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
                    <div style="width: 290px">
                        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="height: 18px; margin-top: -10px; margin-bottom: 10px;">
                    <div id="div_ddlView" style="float: left; /*display: none*/">
                        <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged"
                            Width="110%" Style="height: 23px; border-radius: 4px; background-color: white; outline: none; cursor: pointer;"
                            AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-left: 35px; padding-top: 3px;">
                        <asp:LinkButton ID="lnkJobsedit" runat="server" Text="Edit View" Style="text-decoration: underline;"
                            OnClientClick="javascript:return editviewID_job();" OnClick="btnEditViewJob_Click"><%=objLanguage.GetLanguageConversion("Edit_Add") %></asp:LinkButton>
                        <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change") %></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display: none; cursor: pointer; color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                    </div>
                    <div style="float: right; padding-left: 0px; padding-top: 5px; padding-right: 15px;">
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
                                <%=objLanguage.GetLanguageConversion("Or_Try")%></span><a href="../jobs/job_search.aspx"
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
                                        <table border="0" cellpadding="0" cellspacing="0" runat="server">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <asp:Panel ID="pnlChangeStatus" runat="server">
                                                            <telerik:RadListBox runat="server" ID="RadListBox2" SelectionMode="Single" Width="100%"
                                                                OnSelectedIndexChanged="RadListBox2_SelectedIndexChanged" Skin="EprintListbox"
                                                                EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                                OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
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
                                                    <div id="divDelete" runat="server" onclick="javascript:CountSameJobid(this.id);"
                                                        class="divDropdownlist" style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <%--This is done after discussion with Gaj--%>
                                                <td>
                                                    <div id="divPaid" runat="server" onclick="javascript:return CheckchkOne('paid');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblRecordPayment" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divProgToInv" runat="server" onclick="javascript:return CountSameJobid(this.id);"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblProgressToInvoice" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="td_sendbulkemail">
                                                    <div id="sendbulkemail" runat="server" onclick="javascript:return CheckchkOne('sendbulkemail');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblsendbulkemail" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="GridView1" runat="server" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridView1"
                                        ShowGroupPanel="false" AllowFilteringByColumn="true" ShowStatusBar="true" 
                                        AutoGenerateColumns="false" AllowPaging="true" OnNeedDataSource="GridView1_NeedDataSource"
                                        GroupingEnabled="false" OnSortCommand="GridView1_SortCommand" 
                                        OnGroupHeaderItemDataBound="GridView1_GroupHeaderItemDataBound"
                                        OnItemCommand="GridView1_ItemCommand" Skin="Sunset" AllowCustomPaging="true"
                                        EnableEmbeddedSkins="true" Width="99%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                        FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin" OnPreRender="GridView1_PreRender">
                                        <HeaderStyle CssClass="gv_ViewsHeader" />
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false"></PagerStyle>
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            AllowCustomSorting="true">
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" AllowFiltering="false"
                                                    Reorderable="false" HeaderText="Action" ItemStyle-Wrap="false" Visible="true">
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
                                                        <input class="viewcheckboxpos" type="checkbox" runat="server" id="Id" onclick="CheckChanged(event,this,'ctl00_ContentPlaceHolder1_GridView1');"
                                                            name="Id" value='<%#String.Concat(Eval("JobID").ToString(),"_",Eval("estimateid").ToString(),"_",Eval("EstimateItemID").ToString(),"_",Eval("Cust_ID").ToString(),"_",Eval("InvAddress_ID").ToString(),"_",Eval("InvAddress_ID").ToString(),"_",Eval("IsFromWebStore").ToString(),"_",Eval("PaymentType").ToString()) %>' />&nbsp;
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
                                                                <asp:PlaceHolder ID="plhInv" runat="server"></asp:PlaceHolder>
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
                                        <HeaderStyle Width="120px" />
                                    </telerik:RadGrid>
                                </div>
                                <asp:LinkButton ID="lnkJobDelete" runat="server" Text=" " OnClick="lnkJobDelete_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkJobArchive" runat="server" Text=" " OnClick="lnkJobArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkJobUnArchive" runat="server" Text=" " OnClick="lnkJobUnArchive_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCopyJob" runat="server" Text=" " OnClick="lnkCopyJob_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkPaidInvoice" runat="server" Text=" " OnClick="lnkPaidInvoice_OnClick"
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkProgToInv" runat="server" Text=" "
                                    CausesValidation="false" Visible="false"></asp:LinkButton>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnJobID" Value="0" />
                            <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                        </div>
                        <div style="clear: both">
                            &nbsp;
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
            <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
            <asp:HiddenField ID="hdnInvoiceEstimateIds" runat="server" Value="0" />
            <asp:HiddenField ID="hdnJobDelete" runat="server" Value="0" />
        </div>
        <asp:UpdatePanel ID="updtehidnfield" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hdnSelectedChkfrmGrid" runat="server" Value='0' />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RadListBox2" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            KeepInScreenBounds="true" Opacity="100" runat="server" Width="1000" Height="610"
            OnClientClose="RadWinClose" Behaviors="Close,Move,Reload,Resize" Style="overflow: hidden;">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" RenderMode="Lightweight" EnableShadow="false" OnClientClose="RadWinClose"
                    KeepInScreenBounds="true" VisibleTitlebar="true" Modal="true" Behaviors="Close,Reload"
                    DestroyOnClose="true">
                </telerik:RadWindow>

            </Windows>
        </telerik:RadWindowManager>
    </div>
    <div id="divBackGroundNew" style="display: none; overflow: hidden;">
    </div>
    <div id="divDeliveryDate" style="display: none; overflow: hidden;">
    </div>

    <asp:HiddenField ID="hdn_stockBack" runat="server" Value="no" />
    <asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />

    <div id="commentPopup" style="display: none; position: fixed; left: 50%; top: 50%; transform: translate(-50%, -50%); background: white; border: 1px solid #ccc; padding: 20px; z-index: 1000; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);">
        <span id="closePopup" style="position: absolute; top: 10px; right: 10px; font-size: 20px; font-weight: bold; cursor: pointer;">&times;</span>
        <label style="font-weight: bold; margin-bottom: 10px; display: block;">Edit Comment:</label>
        <textarea id="txtComment" rows="4" cols="50" style="width: 100%; margin-bottom: 10px; padding: 5px; border: 1px solid #ccc;"></textarea>
        <asp:Button ID="btnSaveComment" runat="server" Text="Save" OnClick="btnSaveComment_Click" Style="cursor: pointer;" />

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

        function OnPriorityClick(estid, priority) {
            var type = "priority";
            var RadWindowHistory = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?type=priority&priority=" + priority + "&pg=job&id=" + estid);
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindowHistory.setSize(450, 300);
            RadWindowHistory.center();
            return false;
        }

    </script>
    <script type="text/javascript">
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var IsInvoicePossible = '';

        //By Thejesh Code Optimization

        <%--var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var div_lblView = document.getElementById("div_lblView");
        var div_ddlView = document.getElementById("div_ddlView");

        function ChangeView() {
            if (div_lblView.style.display == 'block') {
                div_lblView.style.display = 'none';
                div_ddlView.style.display = 'block';
                document.getElementById("spn_change").innerHTML = '<%=objLanguage.GetLanguageConversion("Cancel")%>'
            }
            else {
                div_lblView.style.display = 'block';
                div_ddlView.style.display = 'none';
                document.getElementById("spn_change").innerHTML = '<%=objLanguage.GetLanguageConversion("Change")%>'
            }
        }--%>

       <%-- function testjs(val) {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = val;
            return window.confirm("Are you sure,You want to delete this estimate?")
        }
        function test11(id) {
            var chk = document.getElementById(id);
            alert(chk.checked);
        }--%>

        function DeleteInv() {

            var InventoryManagement = '<%=InventoryManagement %>';
            var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
            var hdn_ISInventoryStockBack = document.getElementById("<%=hdn_ISInventoryStockBack.ClientID %>");
            document.getElementById("<%=hdnJobID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;

            var ManageStockPermission = '<%=ManageStockPermission %>';
            var StockCancellationType = '<%=StockCancellationType %>';
            var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p") {

                    if (window.confirm('Do you want quantity adjusted if any to be added back to the inventory?')) {
                        hdn_ISInventoryStockBack.value = 'yes';
                    }
                }
            }

            if (ManageStockPermission == 1) {
                if (StockCancellationType.toString().toLowerCase() == "a") {
                    hdn_stockBackwarehoue.value = 'yes';
                }
            }
            __doPostBack('ctl00$ContentPlaceHolder1$lnkJobDelete', '');
            //added loading image : ticket 13745(13746)
            document.getElementById('ctl00_ContentPlaceHolder1_btn_Delete_JOb').style.display = 'none';
            document.getElementById('div_loading_btn_Delete_JOb').style.display = 'block';

        }

        <%--function prog_to_invoice() {
            debugger;
            var IDs = document.getElementById("<%=hdnIDs.ClientID %>").value;
            var IsItemSelected = '<%=IsItemSelected %>';
            var idArray = IDs.split(',');
            if (idArray.length > 101) {
                alert("You can select a maximum of 100 items only.");
                return false;
            }
            document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value = hdnIDs.value;
            createCookie("jobviewestids", hdnIDs.value, 1);

            var oWnd = $find("<%= RadWindow1.ClientID %>");
            oWnd.setUrl("<%=strSitepath %>common/progress_to_invoice.aspx?IDs=" + IDs + "&IsItemSelected=" + IsItemSelected + "");
            oWnd.setSize(600, 520);
            oWnd.center();
            oWnd.show();
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;

        }--%>

        <%-- function prog_to_invoice() {
            debugger;
            var IDs = document.getElementById("<%= hdnIDs.ClientID %>").value;
            var IsItemSelected = '<%= IsItemSelected %>';
            var idArray = IDs.split(',');

            if (idArray.length > 101) {
                alert("You can select a maximum of 100 items only.");
                return false;
            }

            var oWnd = $find("<%= RadWindow1.ClientID %>");
            if (!oWnd) {
                alert("Popup not available.");
                return false;
            }

            // Reset any previous content
            //oWnd.setUrl("");
            oWnd.setUrl("<%=strSitepath %>common/progress_to_invoice.aspx");
            oWnd.set_title("Progress to Invoice");
            oWnd.setSize(600, 520);
            oWnd.center();
            oWnd.show();

            // Delay to ensure iframe is ready
            setTimeout(function () {
                var wndFrame = oWnd.get_contentFrame();
                if (!wndFrame) {
                    console.warn("Popup iframe not ready.");
                    return;
                }

                var frameWin = wndFrame.contentWindow;
                var frameDoc = frameWin.document;

                frameDoc.open();
                frameDoc.write("<html><head><title>Loading...</title></head><body></body></html>");
                frameDoc.close();

                // Create form inside the iframe
                var form = frameDoc.createElement("form");
                form.method = "POST";
                form.action = "<%=strSitepath %>common/progress_to_invoice.aspx";

        var inputIDs = frameDoc.createElement("input");
        inputIDs.type = "hidden";
        inputIDs.name = "IDs";
        inputIDs.value = IDs;
        form.appendChild(inputIDs);

        var inputSelected = frameDoc.createElement("input");
        inputSelected.type = "hidden";
        inputSelected.name = "IsItemSelected";
        inputSelected.value = IsItemSelected;
        form.appendChild(inputSelected);

        frameDoc.body.appendChild(form);
        form.submit();
    }, 300);

            return false;
        }--%>

        function prog_to_invoice() {
            debugger;
            var IDs = document.getElementById("<%= hdnIDs.ClientID %>").value;
            var IsItemSelected = '<%= IsItemSelected %>';
            var idArray = IDs.split(',');

            if (idArray.length > 101) {
                alert("You can select a maximum of 100 items only.");
                return false;
            }

            var oWnd = $find("<%= RadWindow1.ClientID %>");
    if (!oWnd) {
        alert("Popup not available.");
        return false;
    }

    // Open RadWindow
<%--    oWnd.setUrl("<%=strSitepath %>common/progress_to_invoice.aspx");--%>
    oWnd.setUrl("");
    oWnd.set_title("Progress to Invoice");
    oWnd.setSize(600, 520);
    oWnd.center();
    oWnd.show();

    // Delay to ensure RadWindow iframe is ready
    setTimeout(function () {
        // Create form in parent doc, not inside iframe
        var form = document.createElement("form");
        form.method = "POST";
        form.action = "<%=strSitepath %>common/progress_to_invoice.aspx";
        form.target = oWnd.get_name();   // important: target the RadWindow iframe

        // Hidden field for IDs
        var inputIDs = document.createElement("input");
        inputIDs.type = "hidden";
        inputIDs.name = "IDs";
        inputIDs.value = IDs;
        form.appendChild(inputIDs);

        // Hidden field for IsItemSelected
        var inputSelected = document.createElement("input");
        inputSelected.type = "hidden";
        inputSelected.name = "IsItemSelected";
        inputSelected.value = IsItemSelected;
        form.appendChild(inputSelected);

        // Append, submit, cleanup
        document.body.appendChild(form);
        form.submit();
        document.body.removeChild(form);
    }, 300);

            return false;
        }

        function ArchiveJob() {
            document.getElementById("<%=hdnJobID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkJobArchive', '');
        }
        function UnArchiveJob() {
            document.getElementById("<%=hdnJobID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkJobUnArchive', '');
        }

        function CopyJob(Ides, EstIDs) {
            document.getElementById("<%=hdnJobID.ClientID %>").value = Ides;
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = EstIDs;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkCopyJob', '');
        }

        function paid() {
            document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value = hdnIDs.value;
            createCookie("jobviewestids", hdnIDs.value, 1);
            PageMethods.SetEstimateID(document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value, '<%=CompanyID %>', ShowViewMsg, ShowMsg_Failure);
            return true;
        }

        function createCookie(name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            }
            else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        function ShowMsg_Failure(error) { }

        function ShowViewMsg(result) {
            var IsItemSelected = '<%=IsItemSelected %>';

            document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value = result;
            if (document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value != "") {
                var url = window.location.href;

                var oWnd = $find("<%= RadWindow1.ClientID %>");
                if (IsItemSelected.toLowerCase() == "true") {
                    oWnd.setUrl("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=0&IsPaid=0&Module=job_View&OrderID=0&IsItemSelected=1");
                }
                else {
                    oWnd.setUrl("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=0&IsPaid=0&Module=job_View&OrderID=0&IsItemSelected=0");
                }

                oWnd.setSize(500, 520);
                oWnd.center();
                oWnd.show();
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else {
                alert('<%=objLanguage.GetLanguageConversion("For_your_selected_jobs_invoice_is_not_created") %>');
            }
        }


        function OpenPaidPopup() {
            var url = window.location.href;
            var module;
            if (url.indexOf("Jobs/jobs_view") != -1) {
                module = "job_View";
            }
            window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=0&IsPaid=0&Module=" + module + "&OrderID=0", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;
        }
        var checktrue = false;
        function checkall(tblid) {
            debugger;
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
    <script type="text/javascript" language="javascript">
        var selectedvalue_replenish = 0;
        function SelectGriditems(gridid, chkboxid, hdnID, seltext, SelVal) {
            debugger
            selectedvalue_replenish = SelVal;
            var Replenish_JobStatusID ='<%=Replenish_JobStatusID%>';
            var InventoryManagement = '<%=InventoryManagement %>';
            var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
            var hdn_stockBack = document.getElementById("<%=hdn_stockBack.ClientID %>");
            var ManageStockPermission = '<%=ManageStockPermission %>';
            var StockCancellationType = '<%=StockCancellationType %>';
            var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a" && seltext.toLowerCase() == "cancelled") {
                    if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                        hdn_stockBack.value = "yes";
                    }
                    else {
                        hdn_stockBack.value = "no";
                    }
                }
            }

            if (ManageStockPermission == 1) {
                if (StockCancellationType.toString().toLowerCase() == "a" && seltext.toLowerCase() == "cancelled") {
                    hdn_stockBackwarehoue.value = "yes";
                }
            }

            var Counter = 0;
            var frm = document.getElementById(gridid);
            var frmCheckBox = frm.getElementsByTagName('input');
            var hdnCheckedID = document.getElementById(hdnID);
            hdnCheckedID.value = '';

            for (i = 0; i < frmCheckBox.length; i++) {
                var e = frmCheckBox[i];
                if (e.type == 'checkbox' && e.name.indexOf(chkboxid) != -1 && Number(e.value) != 0) {
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
                if (SelVal == Replenish_JobStatusID) {
                    alert('Replenishment not possible in Job View, please go to summary and change the status.');
                    return false;
                } else {
                    return true;
                }
            }
            hide();
        }


    </script>
    <asp:HiddenField ID="editJobViewID" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=nmsCommon.global.sitePath()%>jobs/customviewjob.aspx";
        }
    </script>
    <script type="text/javascript">
        function editviewID_job() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var editJobViewID = document.getElementById("<%=editJobViewID.ClientID %>");
            editJobViewID.value = ddl.options[ddl.selectedIndex].value;

        }
    </script>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_ISInventoryStockBack" runat="server" Value="No" />
    <script type="text/javascript" language="javascript">
        var jobcountselectednew = '';
        var JobCountForSameJobidnew = '';
        var JobIdnotequalsnew = '';
        var checktype = '';
        var progresstoinvoicedivid = '';
        var FinalJobidnew = '';
        var IsItemSelected = "<%=IsItemSelected %>";
        var rdb_Delete_All = <%=rdb_Delete_All.ClientID %>;
        var rdb_Delete_Job = <%=rdb_Delete_Job.ClientID %>;
        function CountSameJobid(id) {
            progresstoinvoicedivid = id;
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

            var FullIds = new Array();
            FullIds = Ides.split(',');
            var JobIds = new Array();
            for (k = 0; k < FullIds.length - 1; k++) {
                JobIds[k] = FullIds[k].split('_')[0];
            }
            var jobidcount = 0;
            JobIdnotequals = "no";
            JobIdnotequalsnew = "no";
            if (JobIds.length > 1) {
                jobidcount = 1;
                for (l = 0; l <= JobIds.length - 1; ++l) {
                    if (JobIds[l] == JobIds[l + 1]) {
                        jobidcount = jobidcount + 1;
                        var FinalJobid = JobIds[l];
                    }
                    else if (l != JobIds.length - 1) {
                        JobIdnotequals = "yes";
                        JobIdnotequalsnew = "yes";
                    }
                }
            }
            else {
                jobidcount = 1;
                FinalJobid = JobIds[0];
            }
            JobCountSelected = jobidcount.toString();
            if (FinalJobid == NaN || FinalJobid == undefined) {
                FinalJobid = JobIds[0];
            }
            else {
                FinalJobid = parseInt(FinalJobid);
                FinalJobidnew = parseInt(FinalJobid);
            }
            //var JobCount;
            JobCounts(FinalJobid);
            jobcountselectednew = JobCountSelected;

        }

        var IsAllocationExist = false;
        function CheckchkOne(type) {
            debugger;
            asyncState = false;
            IsInvoicePossible = true;
            IsAllocationExist = false;
            document.getElementById('ctl00_ContentPlaceHolder1_btn_Delete_JOb').style.display = 'block';

            var PageType = 'job';
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
                else if (type == "paid") {
                    alert("<%=Invoice_Paid_Row_Select_Note %>");
                }
                else if (type == "invoice") {
                    alert("<%=Progress_To_Invoice_Selection_Alert %>");
                }
                else if (type == "sendbulkemail") {
                    alert('<%=Please_Check_Atleast_One_Row %>' + ' ' + 'to send email');
                }
                return false;
            }
            else {
                var check = "";

                if (type == "sendbulkemail") {
                    var All_IDs1 = Ides.split(',');
                    var EmailGroupID = randomString(5);
                    if (EmailGroupID != undefined && EmailGroupID != null && EmailGroupID != '') {
                        for (var k = 0; k < All_IDs1.length - 1; k++) {
                            var All_IDs2 = All_IDs1[k].split('_');
                            PDFGenration.Send_BulkEmail_Insert(All_IDs2[0].toString(), 'job', EmailGroupID, sendbulkemailisert_Success);
                        }
                    }

                    var frm = document.forms[0];

                    for (i = 0; i < frm.length; i++) {
                        e = frm.elements[i];
                        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                            e.checked = false;
                        }
                    }
                    alert('Email will be send in next few minutes.');
                }
                else if (type == "delete") {
                    var NormalOrderCount = 0;
                    var BrainTreePaypalCount = 0;
                    document.getElementById('div_loading_btn_Delete_JOb').style.display = 'none';
                    checktype = type;
                    var StrIDSArray = Ides.split(',');

                    for (var i = 0; i <= StrIDSArray.length - 1; i++) {
                        if ((StrIDSArray[i].indexOf("Paypal") >= 0 || StrIDSArray[i].indexOf("Braintree") >= 0 || StrIDSArray[i].indexOf("Stripe") >= 0) && StrIDSArray[i] != '') {
                            BrainTreePaypalCount = BrainTreePaypalCount + 1;
                        } else if (StrIDSArray[i] != '') {
                            NormalOrderCount = NormalOrderCount + 1;
                        }
                    }

                    if (NormalOrderCount > 0 && BrainTreePaypalCount > 0) {
                        alert('Please select only either Normal Payment or BrainTree credit card / Paypal / Stripe ');
                        return false;
                    }
                    else {
                        document.getElementById('divBackGroundNew').style.display = 'block';
                        document.getElementById('div_Note').style.display = "block";
                        SetRadWindow('divrad', 'divBackGroundNew', '200');

                        if (Ides.indexOf("Paypal") >= 0 || Ides.indexOf("Braintree") >= 0 || Ides.indexOf("Stripe") >= 0) {
                            rdb_Delete_Job.disabled = true;
                            rdb_Delete_All.disabled = false;
                            rdb_Delete_Job.checked = false;
                            rdb_Delete_All.checked = true;
                        } else {
                            rdb_Delete_Job.disabled = false;
                            rdb_Delete_All.disabled = false;
                            rdb_Delete_Job.checked = true;
                            rdb_Delete_All.checked = false;
                        }
                    }
                }
                else if (type == "archive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                }
                else if (type == "unarchive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
                }
                else if (type == "paid") {
                    check = true;
                }
                else if (type == "invoice") {
                    check = true;
                }
                if (check) {
                    if (type == "delete") {
                        DeleteInv();
                    }
                    else if (type == "archive") {
                        if (PageType == 'job') {
                            ArchiveJob();
                        }
                    }
                    else if (type == "unarchive") {
                        UnArchiveJob();
                    }
                    else if (type == "paid") {
                        var isDifferentCustomer = false;
                        var isDifferentInvAddress = false;
                        var ItemProgToInv_Chk = false;
                        var ItemProgToInv_Cnt = 0;
                        var Cust_ID = '';
                        var InvAddress_ID = '';
                        var All_IDs1 = Ides.split(',');

                        for (var k = 0; k < All_IDs1.length - 1; k++) {
                            var All_IDs2 = All_IDs1[k].split('_');

                            if (k == 0) {
                                Cust_ID = All_IDs2[3].toString();
                            }
                            else if (Cust_ID != All_IDs2[3].toString()) {
                                isDifferentCustomer = true;
                            }

                            if (k == 0) {
                                InvAddress_ID = All_IDs2[4].toString();
                            }
                            else if (InvAddress_ID != All_IDs2[4].toString()) {
                                isDifferentInvAddress = true;
                            }

                            var hdnProgToInvChk = document.getElementById("hdnProgToInvChk_" + All_IDs2[0].toString() + "_" + All_IDs2[1].toString() + "_" + All_IDs2[2].toString());

                            if (hdnProgToInvChk != null) {
                                if (hdnProgToInvChk.value == "true") {
                                    ItemProgToInv_Chk = true;
                                    ItemProgToInv_Cnt++;
                                }
                            }
                        }
                        if (ItemProgToInv_Chk) {
                            paid();
                        }
                        else {
                            alert('<%=objLanguage.GetLanguageConversion("For_your_selected_jobs_invoice_is_not_created") %>');
                        }
                    }
                    else if (type == "invoice") {

                        if (Ides.indexOf("no") > -1 && Ides.indexOf("yes") > -1) {
                            alert('<%=objLanguage.GetLanguageConversion("MIS_Estore_Jobs_Merging_Validation_Msg") %>');
                        }
                        else if (((Ides.indexOf("Paypal") > -1 || Ides.indexOf("Braintree") > -1 || Ides.indexOf("Stripe") > -1)) && ((JobCountSelected != JobCountForSameJobid) || (JobIdnotequals == "yes"))) {

                            alert('You are not able to merge jobs into a single invoice when one of the jobs has already been paid by BrainTree credit card or Paypal or Stripe');
                        }
                        else {
                            var isDifferentCustomer = false;
                            var isDifferentInvAddress = false;
                            var ItemProgToInv_Chk = false;
                            var ItemProgToInv_Cnt = 0;
                            var Cust_ID = '';
                            var InvAddress_ID = '';
                            var All_IDs1 = Ides.split(',');
                            for (var k = 0; k < All_IDs1.length - 1; k++) {
                                var All_IDs2 = All_IDs1[k].split('_');

                                if (k == 0) {
                                    Cust_ID = All_IDs2[3].toString();
                                }
                                else if (Cust_ID != All_IDs2[3].toString()) {
                                    isDifferentCustomer = true;
                                }

                                if (k == 0) {
                                    InvAddress_ID = All_IDs2[4].toString();
                                }
                                else if (InvAddress_ID != All_IDs2[4].toString()) {
                                    isDifferentInvAddress = true;
                                }

                                var hdnProgToInvChk = document.getElementById("hdnProgToInvChk_" + All_IDs2[0].toString() + "_" + All_IDs2[1].toString() + "_" + All_IDs2[2].toString());

                                if (hdnProgToInvChk != null) {
                                    if (hdnProgToInvChk.value == "true") {
                                        ItemProgToInv_Chk = true;
                                        ItemProgToInv_Cnt++;
                                    }
                                }

                                AutoFill.CheckInvoicePossiblenew(All_IDs2[0].toString(), All_IDs2[2].toString(), IsInvoicePossibleSelectedFromJobnew);
                                if (!IsInvoicePossible) {
                                    break;
                                }
                            }

                            var IsItemSelected = '<%=IsItemSelected %>';

                            if (ItemProgToInv_Chk) {

                                if (IsItemSelected.toLowerCase() == "true") {
                                    if (ItemProgToInv_Cnt == 1) {
                                        if ((All_IDs1.length - 1) > 1) {
                                            alert('<%=objLanguage.GetLanguageConversion("Already_Invoice_Raised_Alert_Msg_2") %>');
                                        }
                                        else {
                                            alert('<%=objLanguage.GetLanguageConversion("Already_Invoice_Raised_Alert_Msg_1") %>');
                                        }
                                    }
                                    else {
                                        alert('<%=objLanguage.GetLanguageConversion("Already_Invoice_Raised_Alert_Msg_3") %>');
                                    }
                                }
                                else {
                                    if (ItemProgToInv_Cnt == (All_IDs1.length - 1)) {
                                        alert('All item(s) in the selected job(s) has been progressed to invoice');
                                    }
                                    else {
                                        if (isDifferentCustomer) {
                                            alert('<%=objLanguage.GetLanguageConversion("Selection_Of_Same_Customer_Alert") %>');
                                        }
                                        else {
                                            if (isDifferentInvAddress) {
                                                alert('<%=objLanguage.GetLanguageConversion("Selection_Of_Same_InvoiceAddress_Alert") %>');
                                            }
                                            else {
                                                prog_to_invoice();
                                            }
                                        }
                                    }
                                }
                            }
                            else if (IsInvoicePossible) {
                                if (isDifferentCustomer) {
                                    alert('<%=objLanguage.GetLanguageConversion("Selection_Of_Same_Customer_Alert") %>');
                                }
                                else {
                                    if (isDifferentInvAddress) {
                                        alert('<%=objLanguage.GetLanguageConversion("Selection_Of_Same_InvoiceAddress_Alert") %>');
                                    }
                                    else {
                                        if (IsInvoicePossible && '<%=SR_WhenStockReduced%>' == 'j') {
                                            for (var k = 0; k < All_IDs1.length - 1; k++) {
                                                var All_IDs2 = All_IDs1[k].split('_');
                                                if (!IsAllocationExist) {
                                                    AutoFill.CheckAllocationExist(Number(All_IDs2[0].toString()), Number(All_IDs2[2].toString()), IsInvoiceAllocationExist);
                                                    if (IsAllocationExist) {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        prog_to_invoice();
                                    }
                                }
                            }
                        }
                    }
                    return false;
                }
                else {
                    return check;
                }
            }
        }



        function CheckOne(type, combined) {

            var PageType = 'job';
            //-----------------------------
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");

 
                hdnIDs.value = combined + ",";
   

                    var check = "";

                    if (type == "archive") {
                        check = window.confirm('<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>');
                }
                else if (type == "unarchive") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>');
                    }
                    if (check) {

                        if (type == "archive") {
                            if (PageType == 'job') {
                                ArchiveJob();
                            }

                        }
                        else if (type == "unarchive") {
                            //UnArchiveInv();
                            UnArchiveJob();
                        }
                        return false;
                    }
                    else {
                        return check;
                    }
                }





        function sendbulkemailisert_Success() {

        }

        function randomString(len) {
            var str = "";                                         // String result
            for (var i = 0; i < len; i++) {                             // Loop `len` times
                var rand = Math.floor(Math.random() * 62);        // random: 0..61
                var charCode = rand += rand > 9 ? (rand < 36 ? 55 : 61) : 48; // Get correct charCode
                str += String.fromCharCode(charCode);             // add Character to str
            }
            return str;       // After all loops are done, return the concatenated string

            //OR We Can do this one also

            //var r="";
            //while(n--)r+=String.fromCharCode((r=Math.random()*62|0,r+=r>9?(r<36?55:61):48));
            //return r;
        }


        var checkcalledcountitems = false;
        function JobCounts(FinalJobid) {
            PageMethods.GetItemCount(FinalJobid, ShowViewMsg1);
            //return res;
        }
        function ShowViewMsg1(result1) {
            JobCountForSameJobid = result1;
            JobCountForSameJobidnew = result1;
            checkcalledcountitems = true;
            if (progresstoinvoicedivid == 'ctl00_ContentPlaceHolder1_divProgToInv') {
                CheckchkOne('invoice');
            }
            if (progresstoinvoicedivid == 'ctl00_ContentPlaceHolder1_divDelete') {
                CheckchkOne('delete');
            }
        }
        function OnRowClick(EditPage) {
            window.location = EditPage;
        }

        function OnDeliveryDateClick(deliveyDate, jobId) {

 //           var local = "http://localhost:1111/";
          <%--  var RadWindow= window.radopen(local + "common/Summary_Page_Common_popup.aspx?deliveyDate=" +
                deliveyDate + "&type=deliverydate_update&pg=&JobId=" + jobId + "&format=" +"<%= DateFormat %>"  );--%>
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?deliveyDate=" +
                deliveyDate + "&type=deliverydate_update&pg=&JobId=" + jobId + "&format=" +"<%= DateFormat %>");
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
        function OnEstimatedDeliveryDateClick(deliveyDate, jobId, estimateItemId) {

 //           var local = "http://localhost:1111/";
          <%--  var RadWindow= window.radopen(local + "common/Summary_Page_Common_popup.aspx?deliveyDate=" +
                deliveyDate + "&type=deliverydate_update&pg=&JobId=" + jobId + "&format=" +"<%= DateFormat %>"  );--%>
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?estimatedDeliveyDate=" +
                deliveyDate + "&type=estimateddeliverydate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
            return false;

        }
        function OnActualDeliveryDateClick(deliveyDate, jobId, estimateItemId) {

 //           var local = "http://localhost:1111/";
          <%--  var RadWindow= window.radopen(local + "common/Summary_Page_Common_popup.aspx?deliveyDate=" +
                deliveyDate + "&type=deliverydate_update&pg=&JobId=" + jobId + "&format=" +"<%= DateFormat %>"  );--%>
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?actualDeliveyDate=" +
                deliveyDate + "&type=actualdeliverydate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
            return false;

        }
        function OnJobDateClick(jobDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?jobDate=" +
                jobDate + "&type=jobdate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
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
        function OnCompletionDateClick(completionDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?completionDate=" +
                completionDate + "&type=completiondate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
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

        function OnApprovalDateClick(approvalDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?approvalDate=" +
                approvalDate + "&type=approvaldate_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindow.setSize(450, 300);
            RadWindow.center();
            return false;

        }
        

        function OnCustomdate1Click(customDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?customdate=" +
                customDate + "&type=customdate1_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
              SetRadWindow('divrad', 'divBackGroundNew');
              RadWindow.setSize(450, 300);
              RadWindow.center();
              return false;

        }

        function OnCustomdate2Click(customDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?customdate=" +
                 customDate + "&type=customdate2_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

        }

        function OnCustomdate3Click(customDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?customdate=" +
                 customDate + "&type=customdate3_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

        }

        function OnCustomdate4Click(customDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?customdate=" +
                 customDate + "&type=customdate4_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

        }

        function OnCustomdate5Click(customDate, jobId, estimateItemId) {
            var RadWindow = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?customdate=" +
                 customDate + "&type=customdate5_update&pg=&JobId=" + jobId + "&estimateItemId=" + estimateItemId + "&format=" + "<%= DateFormat %>");
             SetRadWindow('divrad', 'divBackGroundNew');
             RadWindow.setSize(450, 300);
             RadWindow.center();
             return false;

         }

        function OnSalesPersonClick(jobId, salesPersonId, clientId) {
            var type = "salesPerson";
            var RadWindowHistory = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?salesPersonId=" + salesPersonId + "&type=salesPerson&pg=&JobId=" + jobId + "&clientId=" + clientId + "&userType=" + type);
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindowHistory.setSize(450, 300);
            RadWindowHistory.center();
            return false;
        }

        function IsInvoicePossibleSelectedFromJob(IsInvoicePossibleFromJob) {
            if (!IsInvoicePossibleFromJob) {
                IsInvoicePossible = false;
                alert('One or more products has an allocation quantity that is greater than the quantity on hand for that location. You need to add stock to the correct location to enable the allocation to be released.');
                return false;
            }
        }
        function IsInvoicePossibleSelectedFromJobnew(result) {

            var data = result;

            if (!data.IsInvoicePossible) {

                IsInvoicePossible = false;

                alert(
                    'Invoice cannot be created for Job: ' +
                    data.JobNumber + ' Product : ' + data.ItemCode +
                    '\n\nOne or more products has an allocation quantity that is greater than the quantity on hand for that location. You need to add stock to the correct location to enable the allocation to be released.'
                );

                return false;
            }
        }

        function IsInvoiceAllocationExist(Result_IsAllocationExist) {
            if (Result_IsAllocationExist) {
                var ServerName = '<%=ServerName%>';
                if (ServerName != 'dmc' || ServerName != 'dmc2') {
                    IsAllocationExist = true;
                    alert('You have not reduced the stock of this product by changing the job status.\nIf you create an invoice for this record that will reduce the stock of the product.');
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function AllocationPopUp(id) {
            var path = '<%=strSitepath%>'
            var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1330', '520');
            //SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            //SetRadWindow('divrad', 'divBackGroundNew', '200');
            Rad1Customer.setSize(1330, 520);
            Rad1Customer.center();
            Rad1Customer.id = "Radwindowstock";
            return false;
        }
        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
            var Div_Customer = document.getElementById(divMaskID);
            var divBackGroundNew = document.getElementById(divBackgroundID);

            if (document.getElementById(divMaskID).style.display == "none") {

                if (navigator.appName != "Microsoft Internet Explorer") {
                    setLoadingPositionOfDivCenter_Ver2(Div_Customer);
                }
                showDivPopupCenter_Ver2(divMaskID);
            }
            else {
                showDivPopupCenter_Ver2(divMaskID);
            }
        }

        function OpenDelivery_List(ID) {
            var RadCustomer = window.radopen("<%=nmsCommon.global.sitePath()%>Settings/DeliveryNo_List.aspx?EstimateID=" + ID, '600', '350');
            //SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
            RadCustomer.setSize(600, 350);
            RadCustomer.center();
        }
        function OpenPurchase_List(ID) {
            var RadCustomer = window.radopen("<%=nmsCommon.global.sitePath()%>Settings/PurchaseNo_List.aspx?EstimateID=" + ID, '600', '350');
            //SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
            RadCustomer.setSize(600, 350);
            RadCustomer.center();
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

            if (column.get_dataType() == "System.Decimal") {
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
            var Replenish_JobStatusID = '<%=Replenish_JobStatusID%>';
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
            if (Number(Counter) == 0 || Number(selectedvalue_replenish) == Number(Replenish_JobStatusID)) {
                sender.set_autoPostBack(false);
            }
            else {
                sender.set_autoPostBack(true);
                __doPostBack("<%=RadListBox2.ClientID%>", '');
            }

        }
    </script>
</asp:Content>
