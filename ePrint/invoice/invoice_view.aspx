<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="invoice_view.aspx.cs" Inherits="ePrint.invoice.invoice_view" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridViewInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewInvoice" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewInvoice" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewInvoice" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridViewInvoice" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListBox1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hdnaddress1" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress2" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress3" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress4" runat="server" Value="" />
    <asp:HiddenField ID="hdnaddress5" runat="server" Value="" />
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
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">
                                <%=objLanguage.GetLanguageConversion("Invoices")%></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div id="div_Note" style="display: none; position: fixed; vertical-align: middle;
        z-index: 100; width: 100%;" align="center">
        <table cellpadding="0" cellspacing="0" width="35%" height="82%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" id="div_invoice_delete" class="Label-PopupHeading" style="float: right;
                        padding-top: 6px; padding-right: 15px;">
                        <div class="CancelButtonDiv2">
                            <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv();return false;" />
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
                <td class="popup-middlebg" align="center" valign="top">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td valign="top">
                                <div id="div_Delete_Invoice">
                                    <div id="div_rdb_Delete_Invoice" style="float: left; padding-bottom: 7px; display: block;">
                                        <span style="font-weight: bold;">
                                            <asp:RadioButton ID="rdb_Delete_Invoice" runat="server" GroupName="delete" Checked="true"
                                                Text="Delete Invoice and keep Job/Estimate live" />
                                        </span>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div style="float: left; padding-bottom: 7px;">
                                        <span style="font-weight: bold;">
                                            <asp:RadioButton ID="rdb_Delete_All" runat="server" GroupName="delete" Text="Delete Invoice and its corresponding Estimate/Job" />
                                        </span>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div align="left" id="div_Msg_Note" class="Label-PopupHeading" style="float: left;
                                        padding-top: 6px; padding-bottom: 7px; padding-left: 8px;">
                                        <b>Note: </b>
                                        <asp:Label ID="lbl_note" runat="server" Text="If this item is a stock item and you delete the estimate and job the stock quantity allocated to this item will be added back to the product"><%=objLanguage.GetLanguageConversion("Stock_Item_Delete_Alert_Message")%></asp:Label>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                    <div style="padding-top: 5px; float: left; padding-left: 3.2%;">
                                        <asp:Button ID="btn_Delete_Invoice" runat="server" Text="Delete" CssClass="button"
                                            OnClientClick="javascript:DeleteInv();return false;" />
                                        <div id="div_loading_btn_Delete_Invoice" style="display: none; width: 52px; padding-bottom: 1px;
                                            padding-top: 1px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center;
                                            background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
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
                            Width="110%" Style="height: 23px; border-radius: 4px; background-color: white;
                            outline: none; cursor: pointer;" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-left: 35px; padding-top: 3px;">
                        <asp:LinkButton ID="lnkInvoiceedit" runat="server" Text="" Style="text-decoration: underline;"
                            OnClientClick="javascript:return editviewID_invoice();" OnClick="btnEditViewInvoice_Click"><%=objLanguage.GetLanguageConversion("Edit_Add")%></asp:LinkButton>
                        <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display: none;
                                    cursor: pointer; color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                    </div>
                    <div style="float: right; padding-right: 15px; padding-top: 5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                            cursor: pointer" runat="server" Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%> </asp:LinkButton>
                    </div>
                    <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                        <div style="float: left; display: none;">
                            <span class="HeaderText" style="color: #787878">
                                <%=objLanguage.GetLanguageConversion("Current_View")%></span>
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
                                <%=objLanguage.GetLanguageConversion("Or_Try")%></span><a href="../invoice/invoice_search.aspx"
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
                                    <div id="div_popupAction_View" style="margin-left: 6px;" onmouseover="show();" onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <asp:Panel ID="pnlChangeStatus" runat="server">
                                                            <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100%"
                                                                OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged" Skin="EprintListbox"
                                                                EnableEmbeddedSkins="false" AutoPostBack="true" Height="150px"
                                                                OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                                                                <HeaderTemplate>
                                                                    <span style="color: #333; line-height: 23px; font-weight: 100; padding: 5px 0px 5px 5px;
                                                                        font-family: Verdana; font-size: 10px;">
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
                                                    <div id="divDeleteSelected" runat="server" onclick="javascript:CheckchkOne('delete');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblDelete" runat="server"></asp:Label></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="divPaid" runat="server" onclick="javascript:return CheckchkOne('paid');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblRecordPayment" runat="server"></asp:Label></div>
                                                </td>
                                            </tr>   

                                             <tr>
                                                <td>
                                                    <div id="divExported" runat="server" onclick="javascript:return CheckchkOne('exported');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblExported" runat="server"></asp:Label></div>
                                                </td>
                                            </tr> 
                                             <tr>
                                                <td>
                                                    <div id="divUnExported" runat="server" onclick="javascript:return CheckchkOne('unexported');"
                                                        class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                        <asp:Label ID="lblUnExported" runat="server"></asp:Label></div>
                                                </td>
                                            </tr> 
                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="GridViewInvoice" runat="server" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewInvoice"
                                        ShowGroupPanel="false" AllowFilteringByColumn="true" ShowStatusBar="true" 
                                        AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridViewInvoice_ColumnCreated"
                                        OnNeedDataSource="GridViewInvoice_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewInvoice_SortCommand"
                                         OnGroupHeaderItemDataBound="GridView1_GroupHeaderItemDataBound"
                                        OnItemCommand="GridViewInvoice_ItemCommand" Skin="Sunset" AllowCustomPaging="true"
                                        EnableEmbeddedSkins="true" HeaderStyle-Wrap="true"
                                        Width="99%" ItemStyle-Wrap="false" FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false"></PagerStyle>
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            AllowCustomSorting="true">
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
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged(event,this,'ctl00_ContentPlaceHolder1_GridViewInvoice');"
                                                            name="Id" value='<%#String.Concat(Eval("InvoiceID"),"_",Eval("Estimateid").ToString(),"_",Eval("EstimateItemID").ToString(),"_",Eval("Cust_ID").ToString(),"_",Eval("PaymentType").ToString()) %>' />&nbsp;
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
                                                                <asp:PlaceHolder ID="plh_backorder" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <div>
                                                                <asp:PlaceHolder ID="plh_Error" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <div>
                                                                <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
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
                            </div>
                        </div>
                        <asp:LinkButton ID="lnkInvoiceDelete" runat="server" Text=" " OnClick="lnkInvoiceDelete_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkInvoiceArchive" runat="server" Text=" " OnClick="lnkInvoiceArchive_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkInvoiceUnArchive" runat="server" Text=" " OnClick="lnkInvoiceUnArchive_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkInvoiceCopy" runat="server" Text=" " OnClick="lnkInvoiceCopy_OnClick"
                            CausesValidation="false" Visible="true"></asp:LinkButton>
                        <asp:LinkButton ID="lnkInvoiceExported" runat="server" Text=" " OnClick="lnkInvoiceExported_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lnkInvoiceUnExported" runat="server" Text=" " OnClick="lnkInvoiceUnexported_OnClick"
                            CausesValidation="false" Visible="false"></asp:LinkButton>


                        <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                        <asp:HiddenField runat="server" ID="hdnInvoiceID" Value="0" />
                        <asp:HiddenField ID="hdnInvoiceEstimateIds" runat="server" Value="0" />
                    </div>
                </div>
                <div style="clear: both">
                    &nbsp;</div>
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
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" OnClientClose="RadWinClose"
                    KeepInScreenBounds="true" VisibleTitlebar="true" Modal="true" Behaviors="Close,Move,Reload,Resize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
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


        function OnPriorityClick(estid, priority) {
            var type = "priority";
            var RadWindowHistory = window.radopen('<%= strSitepath %>' + "common/Summary_Page_Common_popup.aspx?type=priority&priority=" + priority + "&pg=invoice&id=" + estid);
            SetRadWindow('divrad', 'divBackGroundNew');
            RadWindowHistory.setSize(450, 300);
            RadWindowHistory.center();
            RadWindowHistory.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Reload);
            RadWindowHistory.add_close(OnPopupClosed);
            return false;
        }

        function OnPopupClosed(sender, args) {
            // Reload parent page when popup closes (via X or programmatically)
            location.reload();
        }
    </script>

    <script>
        var currentdate = '<%=newdate %>';
        var rdb_Delete_All = <%=rdb_Delete_All.ClientID %>;
        var rdb_Delete_Invoice = <%=rdb_Delete_Invoice.ClientID %>;
        function DeleteInv() {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            var InventoryManagement = '<%=InventoryManagement %>';
            var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
            var hdn_ISInventoryStockBack = document.getElementById("<%=hdn_ISInventoryStockBack.ClientID %>");
            var ManageStockPermission = '<%=ManageStockPermission %>';
            var StockCancellationType = '<%=StockCancellationType %>';
            var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");
            if (InventoryManagement.toString().toLowerCase() == "im" && ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p") {
                if (window.confirm('Do you want quantity adjusted if any to be added back to the inventory?')) {
                    hdn_ISInventoryStockBack.value = 'yes';
                }
            }
            if (ManageStockPermission == 1) {
                if (StockCancellationType.toString().toLowerCase() == "p") {
                    if (window.confirm('Do you want stock adjusted if any to be added back to the system?')) {
                        hdn_stockBackwarehoue.value = 'yes';
                    }
                    else { hdn_stockBackwarehoue.value = 'no'; }
                }
            }

            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceDelete', '');
            //added loading image . ticket 13745(13746)
            document.getElementById('ctl00_ContentPlaceHolder1_btn_Delete_Invoice').style.display = 'none';
            document.getElementById('div_loading_btn_Delete_Invoice').style.display = 'block';
        }
        function ArchiveInvoice() {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceArchive', '');
        }

        function UnArchiveInvoice() {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceUnArchive', '');
        }

        function Exported() {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceExported', '');
        }

        function UnExported() {
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceUnexported', '');
        }

        function CopyInvoice(Ides, EstIDs) {
            document.getElementById("<%= hdnInvoiceID.ClientID%>").value = Ides;
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = EstIDs;

            __doPostBack('ctl00$ContentPlaceHolder1$lnkInvoiceCopy', '')

        }

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
            document.getElementById("<%=hdnEstimateID.ClientID %>").value = val;
            return window.confirm("Are you sure,You want to delete this estimate?")
        }
        function test11(id) {
            var chk = document.getElementById(id);
            alert(chk.checked);
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
        function SelectGriditems(gridid, chkboxid, hdnID, seltext) {
            hide();
            
            //Removed for the ticket --> 13916 in V4.0.1
            <%--var InventoryManagement = '<%=InventoryManagement %>';
            var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
            var hdn_ISInventoryStockBack = document.getElementById("<%=hdn_ISInventoryStockBack.ClientID %>");
            var ManageStockPermission = '<%=ManageStockPermission %>';
            var StockCancellationType = '<%=StockCancellationType %>';
            var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p" && seltext.toLowerCase() == "cancelled") {
                    if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                        hdn_ISInventoryStockBack.value = "yes";
                    }
                    else {
                        hdn_ISInventoryStockBack.value = "no";
                    }
                }
            }--%>

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
    <asp:HiddenField ID="editInvoiceViewID" runat="server" Value="0" />
    <script type="text/javascript">
        function editviewID_invoice() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var editInvoiceViewID = document.getElementById("<%=editInvoiceViewID.ClientID %>");
            editInvoiceViewID.value = ddl.options[ddl.selectedIndex].value;

        }
    
    </script>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_ISInventoryStockBack" runat="server" Value="No" />
    <asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />
    <asp:HiddenField ID="hdnInvoiceDelete" runat="server" Value="false" />
    <script type="text/javascript">
        //added to check payment type and same
        //added fun countsame inv id 1-6-2016
        var IsItemSelected = "<%=IsItemSelected %>";
        var invoicedivid_deleteselected = '';
        function CountSameInvid(deleteid) {
            invoicedivid_deleteselected = deleteid;
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
            var InvIds = new Array();
            for (k = 0; k < FullIds.length - 1; k++) {
                InvIds[k] = FullIds[k].split('_')[0];
            }
            var invidcount = 0;
            InvIdnotequals = "no";
            if (InvIds.length > 1) {
                invidcount = 1;
                for (l = 0; l <= InvIds.length - 1; ++l) {
                    if (InvIds[l] == InvIds[l + 1]) {
                        invidcount = invidcount + 1;
                        var FinalInvid = InvIds[l];
                    }
                    else if (l != InvIds.length - 1) {
                        InvIdnotequals = "yes";
                    }
                }
            }
            else {
                invidcount = 1;
                FinalInvid = InvIds[0];
            }
            InvCountSelected = invidcount.toString();
            if (FinalInvid == NaN || FinalInvid == undefined) {
                FinalInvid = InvIds[0];
            }
            else {
                FinalInvid = parseInt(FinalInvid);
            }
            //var JobCount;
            InvCounts(FinalInvid);
            //now



        }
        function InvCounts(FinalInvid) {
            PageMethods.GetItemCount(FinalInvid, ShowViewMsg1);
            // return res;
        }
        function ShowViewMsg1(result1) {
            InvCountForSameInvid = result1;
            if (invoicedivid_deleteselected == "ctl00_ContentPlaceHolder1_divDeleteSelected") {
                CheckchkOne('delete');            
            }
            
        }
        function CheckchkOne(type) {
            var PageType = 'invoice';
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
                else if (type == "exported") {
                    alert("<%=Export_Row_Select_Note %>");
                }
                else if (type == "unexported") {
                    alert("<%=Unexport_Row_Select_Note %>");
                }
                return false;
            }
            else {
                var check = "";
                if (type == "delete") {
                    var NormalOrderCount=0;
                    var BrainTreePaypalCount=0;
                    document.getElementById('div_loading_btn_Delete_Invoice').style.display = 'none';
                    document.getElementById('ctl00_ContentPlaceHolder1_btn_Delete_Invoice').style.display = 'block';

                    var StrIDSArray=Ides.split(',');
                    for(var i=0;i<=StrIDSArray.length-1;i++){
                        if ((StrIDSArray[i].indexOf("Paypal") >= 0 || StrIDSArray[i].indexOf("Braintree") >= 0 || StrIDSArray[i].indexOf("Stripe") >= 0) && StrIDSArray[i]!='') {
                            BrainTreePaypalCount=BrainTreePaypalCount+1;
                        }else if(StrIDSArray[i]!=''){
                            NormalOrderCount=NormalOrderCount+1;
                        }
                    }

                    if(NormalOrderCount>0 && BrainTreePaypalCount>0 ){
                        alert('Please select only either Normal Payment or BrainTree credit card / Paypal / Stripe ');
                        return false;
                    }
                    else
                    {
                        document.getElementById('divBackGroundNew').style.display = 'block';
                        document.getElementById('div_Note').style.display = "block";
                        SetRadWindow('divrad', 'divBackGroundNew', '200');

                        if (Ides.indexOf("Paypal") == -1 && Ides.indexOf("Braintree") == -1 && Ides.indexOf("Stripe") == -1) {
                            rdb_Delete_Invoice.disabled =false;
                            rdb_Delete_All.disabled =false;
                            rdb_Delete_Invoice.checked=true;
                            rdb_Delete_All.checked=false;
                        } else {
                            rdb_Delete_Invoice.disabled =true;
                            rdb_Delete_All.disabled =false;
                            rdb_Delete_Invoice.checked=false;
                            rdb_Delete_All.checked=true;
                        }
                        return false;
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
                else if (type == "exported") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("Exported_Confirmation_Alert") %>');
                }
                else if (type == "unexported") {
                    check = window.confirm('<%=objLanguage.GetLanguageConversion("UnExported_Confirmation_Alert") %>');
                }


                if (check) {
                    if (type == "delete") {
                        DeleteInv();
                    }
                    else if (type == "archive") {
                        ArchiveInvoice();
                    }
                    else if (type == "unarchive") {
                        UnArchiveInvoice();
                    }
                    else if (type == "paid") {
                        paid();
                    }
                    else if (type == "exported") {
                        Exported();
                    }
                    else if (type == "unexported") {
                        UnExported();
                    }
                    return false;
                }
                else {
                    return check;
                }
            }
        }


        function CheckOne(type, combined) {

            var PageType = 'invoice';
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
                            if (PageType == 'invoice') {
                                ArchiveInvoice();
                            }

                        }
                        else if (type == "unarchive") {
                            //UnArchiveInv();
                            UnArchiveInvoice();
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

        function CloseDiv() {
            document.getElementById("div_Note").style.display = "none";
            document.getElementById('divBackGroundNew').style.display = "none";
        }

        function paid() {

            document.getElementById("<%=hdnInvoiceEstimateIds.ClientID %>").value = hdnIDs.value;
            createCookie("invoiceviewestids", hdnIDs.value, 1);
            var url = window.location.href;
            var module;
            if (url.indexOf("Invoice/invoice_view") != -1) {
                module = "invoice_View";
            }
            var oWnd = $find("<%= RadWindow1.ClientID %>");
            oWnd.setUrl("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=0&IsPaid=0&Module=invoice_View&OrderID=0");
            oWnd.setSize(500, 520);
            oWnd.center();
            oWnd.show();
            SetRadWindow('divrad', 'divBackGroundNew', '200');

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
    </script>
    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=strSitepath%>" + "invoice/customviewinvoice.aspx";
        }
    </script>
</asp:Content>
