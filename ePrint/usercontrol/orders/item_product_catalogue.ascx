<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_product_catalogue.ascx.cs" Inherits="ePrint.usercontrol.orders.item_product_catalogue" %>




<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>

<script type="text/javascript" src="../js/jquery-1.3.2.js?VN='<%=VersionNumber%>'"
    language="javascript"></script>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<div id="ds00" style="display: block;">
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoadings" runat="server" />
</div>

<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/order_catalogue_item.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.height * 3 + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<script type="text/javascript">
    setLoadingPositionOfDivMove(div_Load);
</script>
<script type="text/javascript">
    var strImagepath = "<%=strImagepath %>";
    var RequestType = '<%=Request.QueryString["type"]%>';
    var ClientID = "<%=Pub_CustomerID %>";
    var ClienName = "<%=Pub_CustomerName %>";
    var CompanyID = '<%=CompanyID %>'
    var UserID = '<%=UserID %>'
    var MeasurementValue = "<%=MeasurementValue %>";
    var Please_enter_dimension = '<%=objLanguage.GetLanguageConversion("Please_enter_dimension") %>';
    var Please_enter_height = '<%=objLanguage.GetLanguageConversion("Please_enter_height") %>';
    var Please_enter_width = '<%=objLanguage.GetLanguageConversion("Please_enter_width") %>';

    


</script>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="Pnl_ddl">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="Panel1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="Pnl_btnclrall">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7" />
<div class="only5px">
</div>
<div style="padding: 2px 5px 5px 5px;">
    <div style="float: left; width: 98%;">
        <div style="float: left; text-align: left;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="width: 700px">
                        <div id="div_JobName" runat="server" style="margin: 0px 0px 0px 10px;">
                            <div class="price_table_content_left bglabel">
                                <asp:Label ID="Label2" runat="server" Text="Job Name"><%=objLanguage.GetLanguageConversion("Job_Name") %></asp:Label>
                            </div>
                            <div class="price_table_content_middle">
                                <div class="box" style="float: left; width: 100%">
                                    <asp:TextBox ID="txtJobName" runat="server" class="textboxnew" Style="width: 250px;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="Div2" runat="server" style="margin: 0px 0px 0px 10px;">
                            <div class="price_table_content_left bglabel">
                                <asp:Label ID="Label3" runat="server" Text="Product Name"><%=objLanguage.GetLanguageConversion("Product_Name") %></asp:Label>
                            </div>
                            <div class="price_table_content_middle" style="height: auto;">
                                <div class="box" style="float: left; width: 100%;">
                                    <asp:Label ID="lblProductName" runat="server"></asp:Label>
                                    <a href="#" onclick="showProductChaneDiv();"><span>
                                        <%=objLanguage.GetLanguageConversion("Change") %></span></a>
                                </div>
                            </div>
                            <div class="price_table_content_right" style="padding: 5px 0px 0px 0px">
                            </div>
                        </div>
                        <div id="divCampaign" runat="server" class="campaign_ddl">
                            <div class="price_table_content_left bglabel">
                                <asp:Label ID="lblCampaign" runat="server" Text="Product Name"><%=objLanguage.GetLanguageConversion("Campaign") %></asp:Label>
                            </div>
                            <div class="price_table_content_middle">
                                <div class="box campaing_dropdownleft">
                                    <asp:DropDownList ID="ddlCampaign" runat="server" Width="175px">
                                    </asp:DropDownList>
                                    <span id="div_CampaignErrorMsg" runat="server" style="color: #F00; float: right; display: none">
                                        <%=objLanguage.GetLanguageConversion("Please_Select_Your_Campaign")%></span>
                                </div>
                            </div>
                            <div class="price_table_content_right" style="padding: 5px 0px 0px 0px">
                            </div>
                        </div>
                        <div style="margin: 0px 0px 0px 10px;">
                            <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
                        </div>
                        <div id="artwork_div" runat="server" style="margin: 0px 0px 0px 10px; width: 700px">
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="left" id="Div_ItemDescn" runat="server" visible="true" style="clear: both; margin: 0px 0px 0px 10px;">
                <div class="price_table_content_left bglabel">
                    <asp:Label ID="Label1" runat="server" Text="Update Item Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_DEscription") %></asp:Label>
                    <a href="javascript:void(0);" title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                        <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                            class="tooltip" /></a>
                </div>
                <div class="box" style="float: left;">
                    <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="false" />
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="float: left; text-align: right; width: 100%">
        <div style="width: 42.5%">
            &nbsp;
        </div>
        <div style="float: left; width: 700px">
            <asp:Button ID="btnUpdate" CssClass="button" Text="Update" Width="65px" runat="server"
                OnClientClick="var a = Update_OrderItems();if(a) loadingimage(this.id,'div_Updateprocess');return a"  OnClick="Onclick_btnUpdate" />
            <div id="div_Updateprocess" style="display: none; float: right">
                <asp:Image ID="Image3" runat="server" AlternateText="loading" ImageUrl="~/images/radimg1.gif"
                    Style="margin-top: -2px" />
            </div>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
    </div>
</div>
<%--End of Rad --%>
<div>
    <asp:HiddenField ID="txtPriceCatalogueSerach" runat="server" />
    <asp:HiddenField ID="hdnEnabledCampaign" runat="server" />
</div>
<div>
    <asp:HiddenField ID="hdn_param" runat="server" />
</div>
<script type="text/javascript">
    //*** Function to make gridview scrollable ***//
    var takeIDofInterval = '';
    function CallAfter2sec() {
        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        var hidCatalogueCount = document.getElementById("<%=hidCatalogueCount.ClientID %>");

        if (hidCatalogueCount.value != '') {
            clearInterval(takeIDofInterval);
            var GridPriceCatalogue = document.getElementById("<%=GridPriceCatalogue.ClientID%>");
            var div_out_1 = document.getElementById("div_out_1");
            var div_in_2 = document.getElementById("div_in_2");
            var div_TotalRecInv = document.getElementById("div_TotalRecInv");
            document.getElementById("ds00").style.display = "none";
            document.getElementById("div_Load").style.display = "none";
        }
    }
</script>
<asp:HiddenField ID="hidCatalogueCount" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
    <contenttemplate>
        <asp:LinkButton ID="lnkLoadPriceCatalogue" runat="server" OnClick="lnkLoadPriceCatalogue_OnClick"></asp:LinkButton>
        <script type="text/javascript">
            function ddlonchange(ddlObj) {
                if (ddlObj.value == "Warehouse") {
                    var str = 'lnkLoadPriceCatalogue';
                    __doPostBack('ctl00$ContentPlaceHolder1$PriceCatalog$lnkLoadPriceCatalogue', '');
                }
            }
        </script>
        <asp:Label ID="lblTest" runat="server"></asp:Label>
    </contenttemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UPPro" runat="server">
    <%--AssociatedUpdatePanelID="UpdatePanel2"--%>
    <progresstemplate>
        <div align="left" style="position: absolute; height: 50px; width: 200px; top: 45%; left: 45%;">
            <UC:Loading ID="ucLoading1" runat="server" />
        </div>
    </progresstemplate>
</asp:UpdateProgress>
<div align="left">
    <asp:HiddenField ID="hidCatalogueID" runat="server" />
    <div id="divPriceCatalogue" align="left" style="float: left; position: absolute; width: 85%; min-height: 370px; display: none; z-index: 100">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" style="padding-top: 6px; text-align: center;">
                        <span id="spn_Catalogue_Name" style="color: Black;"><b>
                            <%=objLanguage.GetLanguageConversion("Catalogue_List") %></b></span>
                        <div style="float: right; padding-top: 6px; padding-right: 10px">
                            <div class="CancelButtonDiv">
                                <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                    runat="server" CausesValidation="false"  OnClientClick="javascript:HidePanle();return false;;" />
                            </div>
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
                <td class="popup-middlebg" align="center">
                    <asp:Panel ID="pnlCatalogue" runat="server" Style="display: block">
                        <div class="onlyEmpty">
                        </div>
                        <div class="removeTrancy">
                            <div align="left">
                                <div class="only5px">
                                </div>
                                <div id="div_price_qty_valid" style="display: none; padding-top: 4px;" align="center">
                                    <div align="center" style="width: 50%; padding: 3px;">
                                        <span id="span_price_qty_valid" class="spanerrorMsg" style="width: 100%">Please enter
                                            at least one Quantity</span>
                                    </div>
                                </div>
                                <div style="padding-left: 3px;">
                                    <%-- id="div_plh"--%>
                                    <asp:UpdatePanel ID="UPID12" runat="server" RenderMode="Block">
                                        <ContentTemplate>
                                            <asp:HiddenField ID="hid_query_details" runat="server" Value="" />
                                            <%--New Control on 12.10.2011--%>
                                            <div style="float: left; text-align: left; width: 74%; padding-bottom: 2px;">
                                                <div class="bglabel" style="width: 18%;">
                                                    <%=objLanguage.GetLanguageConversion("Show_PRoducts") %>:
                                                </div>
                                                <div class="box">
                                                    <asp:Panel ID="Pnl_ddl" runat="server">
                                                        <asp:DropDownList runat="server" ID="ddlCategoryBind" SkinID="onlyDDL" Width="150px"
                                                            OnSelectedIndexChanged="ddlCategoryBind_Onchange" AutoPostBack="true" EnableViewState="true"
                                                            Height="18px">
                                                            <asp:ListItem Text="Present Customer" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="All Items" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                            <div id="Link" style="float: left; text-align: right; width: 25%; padding-bottom: 1px;">
                                                <asp:Panel ID="Pnl_btnclrall" runat="server">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                                                        runat="server" Text="Clear all Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                </asp:Panel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--Rad Control,12.10.2011--%>
                                    <div id="Grid_Disp" runat="server" style="padding: 5px 5px 5px 3px; clear: both;">
                                        <asp:Panel ID="Panel1" runat="server">
                                            <telerik:RadGrid Width="99.5%" ID="GridPriceCatalogue" runat="server" GridLines="None"
                                                ShowStatusBar="true" PageSize="50" PagerStyle-AlwaysVisible="true" AutoGenerateColumns="False"
                                                HeaderStyle-Font-Bold="true" AllowPaging="true" AllowFilteringByColumn="true"
                                                OnNeedDataSource="GridPriceCatalogue_NeedDataSource" AllowSorting="true">
                                                <MasterTableView Width="100%" OverrideDataSourceControlSorting="true">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn SortExpression="PriceCatalogueCategoryName" UniqueName="PriceCatalogueCategoryName"
                                                            DataField="PriceCatalogueCategoryName" CurrentFilterFunction="Contains" HeaderStyle-Width="30%"
                                                            ShowSortIcon="true" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                                                            FilterControlWidth="120px" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHeaderName1" runat="server"><%=objLanguage.GetLanguageConversion("Category_Name") %></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <a href="javascript://" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                                                    <div title='<%#Eval("PriceCatalogueCategoryName")%>' style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                                                        <%#Eval("PriceCatalogueCategoryName")%>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="CatalogueName" DataField="CatalogueName"
                                                            ShowSortIcon="true" UniqueName="CatalogueName" CurrentFilterFunction="Contains"
                                                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                                                            FilterControlWidth="120px" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHeaderName2" runat="server"><%=objLanguage.GetLanguageConversion("Item_Title") %></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <a href="javascript://" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                                                    <div title='<%#Eval("CatalogueName")%>' style="float: left; width: 99%; overflow: hidden;"><%#Eval("CatalogueName") %></div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="Description" DataField="Description"
                                                            ShowSortIcon="true" UniqueName="Description" CurrentFilterFunction="Contains"
                                                            HeaderStyle-Width="40%" ItemStyle-Width="40%" Visible="true" HeaderStyle-HorizontalAlign="left"
                                                            FilterControlWidth="150px" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="left" />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHeaderName3" runat="server"><%=objLanguage.GetLanguageConversion("Description") %></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <a href="javascript://" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                                                    <div title='<%#Eval("Description") %>' style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                                                        <asp:Label ID="lblDescription" runat="server"> <%#Eval("Description") %></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn SortExpression="ItemCode" DataField="ItemCode"
                                                            ShowSortIcon="true" UniqueName="ItemCode" CurrentFilterFunction="Contains"
                                                            HeaderStyle-Width="40%" ItemStyle-Width="40%" Visible="true" HeaderStyle-HorizontalAlign="left"
                                                            FilterControlWidth="150px" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="left" />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHeaderName4" runat="server"><%=objLanguage.GetLanguageConversion("Item_Code") %></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <a href="javascript://" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                                                    <div title='<%#Eval("ItemCode") %>' style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                                                        <asp:Label ID="lbl_ItemCode" runat="server"><%#Eval("ItemCode") %></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true" AllowColumnsReorder="false"
                                                    AllowRowsDragDrop="false">
                                                    <ClientEvents />
                                                    <Scrolling ScrollHeight="330" UseStaticHeaders="true" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="only5px">
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </asp:Panel>
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
    <asp:LinkButton ID="lnkProductCatalogue" runat="server" OnClick="lnkProductCatalogue_OnClick"></asp:LinkButton>
    <asp:HiddenField ID="hid_matixType" runat="server" Value="" />
    <asp:HiddenField ID="hid_PriceCatalogueID" runat="server" Value="0" />
    <asp:HiddenField ID="hid_QuestionLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hid_QuestionTextFreeLenght" runat="server" />
    <asp:HiddenField ID="hid_MultipleLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hid_MatrixLenght" runat="server" Value="0" />
    <asp:HiddenField ID="hid_qtyFromList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_qtyToList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_CostExcMarkupList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_MarkupList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Markup" runat="server" />
    <asp:HiddenField ID="hid_priceList" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Maxquantity" runat="server" Value="0" />
    <asp:HiddenField ID="hid_QuantityPrice" runat="server" />
    <asp:HiddenField ID="hid_QuantityPriceExcMarkup" runat="server" />
    <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
    <asp:HiddenField ID="hid_UpdateToOrderItems" runat="server" />
    <asp:HiddenField ID="hid_artwork1" runat="server" />
    <asp:HiddenField ID="hid_artwork2" runat="server" />
    <asp:HiddenField ID="hid_artwork3" runat="server" />
    <asp:HiddenField ID="hid_OldPriceCatalogueID" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />
    <asp:HiddenField ID="hdn_orderedquantity" runat="server" />
    <asp:HiddenField ID="hdn_soldPackOV" runat="server" Value="1" />
    <asp:HiddenField ID="hdnDrawStockFrom" runat="server" />
    <asp:HiddenField ID="hdnIsStockItem" runat="server" />
    <asp:HiddenField ID="hdnStockAdditionalOption" runat="server" />
    <asp:HiddenField ID="hdn_orderedheight" runat="server" />
    <asp:HiddenField ID="hdn_orderedwidth" runat="server" />
    <asp:HiddenField ID="hdn_orderedarea" runat="server" />
    <asp:HiddenField runat="server" ID="hdnDecoration1" />
    <asp:HiddenField runat="server" ID="hdnDecoration2" />
    <asp:HiddenField runat="server" ID="hdnDecoration3" />
    <asp:HiddenField runat="server" ID="hdnDecoration4" />
    <asp:HiddenField runat="server" ID="hdnDecoration5" />
    <asp:HiddenField runat="server" ID="hdnDecoration6" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost1" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost2" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost3" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost4" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost5" />
    <asp:HiddenField runat="server" ID="hdnDecorationCost6" />

    <script type="text/javascript">
        debugger;
        var elem = document.getElementById('txtqty');
        if (elem) {
            setTimeout(function () { Tocalculate_totalPrice(document.getElementById("txtqty").value) }, 100);
        }
        else {
            setTimeout(function () { Tocalculate_totalPrice('0') }, 100);
        }
      
     

        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }
        var artworkFile = '<%=artworkFile%>';
        var ManageStockPermission = '<%=ManageStockPermission %>';
        var StockCancellationType = '<%=StockCancellationType %>';
        var modulename = '<%=modulename %>';

        var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

        var hid_matixType = document.getElementById("<%=hid_matixType.ClientID %>");

        var hid_qtyFromList = document.getElementById("<%=hid_qtyFromList.ClientID %>");
        var hid_qtyToList = document.getElementById("<%=hid_qtyToList.ClientID %>");
        var hid_priceList = document.getElementById("<%=hid_priceList.ClientID %>");
        var hid_Maxquantity = document.getElementById("<%=hid_Maxquantity.ClientID %>");
        var hid_CostExcMarkupList = document.getElementById("<%=hid_CostExcMarkupList.ClientID %>");
        var hid_MarkupList = document.getElementById("<%=hid_MarkupList.ClientID %>");
        var hid_Markup = document.getElementById("<%=hid_Markup.ClientID %>");

        var hid_QuantityPrice = document.getElementById("<%=hid_QuantityPrice.ClientID %>");
        var hid_QuantityPriceExcMarkup = document.getElementById("<%=hid_QuantityPriceExcMarkup.ClientID %>");
        var hdn_orderedheight = document.getElementById("<%=hdn_orderedheight.ClientID %>");
        var hdn_orderedwidth = document.getElementById("<%=hdn_orderedwidth.ClientID %>");
        var hdn_orderedarea = document.getElementById("<%=hdn_orderedarea.ClientID %>");
        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");
        var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
        var hid_MatrixLenght = document.getElementById("<%=hid_MatrixLenght.ClientID %>");
        var hid_QuestionTextFreeLenght = document.getElementById("<%=hid_QuestionTextFreeLenght.ClientID %>");
        var hid_SaveToAdditionalItems = document.getElementById("<%=hid_SaveToAdditionalItems.ClientID %>");
        var hid_UpdateToOrderItems = document.getElementById("<%=hid_UpdateToOrderItems.ClientID %>");

        var spn_artworkFile = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_lbl_reqartworkFile");

        var hid_PriceCatalogueID = document.getElementById("<%=hid_PriceCatalogueID.ClientID %>");
        var hid_OldPriceCatalogueID = document.getElementById("<%=hid_OldPriceCatalogueID.ClientID %>");

        var fp_artwork1 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_fp_artwork1");
        var fp_artwork2 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_fp_artwork2");
        var fp_artwork3 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_fp_artwork3");

        var lblartwork1 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_lblartwork1");
        var lblartwork2 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_lblartwork2");
        var lblartwork3 = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_lblartwork3");

        var hdn_orderedquantity = document.getElementById("<%=hdn_orderedquantity.ClientID %>");
        var hdn_soldPackOV = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hdn_soldPackOV");

       
        var hdn_Decoration1 = document.getElementById("<%=hdnDecoration1.ClientID %>");
        var hdn_Decoration2 = document.getElementById("<%=hdnDecoration2.ClientID %>");
        var hdn_Decoration3 = document.getElementById("<%=hdnDecoration3.ClientID %>");
        var hdn_Decoration4 = document.getElementById("<%=hdnDecoration4.ClientID %>");
        var hdn_Decoration5 = document.getElementById("<%=hdnDecoration5.ClientID %>");
        var hdn_Decoration6 = document.getElementById("<%=hdnDecoration6.ClientID %>");

        var hdn_DecorationCost1 = document.getElementById("<%=hdnDecorationCost1.ClientID %>");
        var hdn_DecorationCost2 = document.getElementById("<%=hdnDecorationCost2.ClientID %>");
        var hdn_DecorationCost3 = document.getElementById("<%=hdnDecorationCost3.ClientID %>");
        var hdn_DecorationCost4 = document.getElementById("<%=hdnDecorationCost4.ClientID %>");
        var hdn_DecorationCost5 = document.getElementById("<%=hdnDecorationCost5.ClientID %>");
        var hdn_DecorationCost6 = document.getElementById("<%=hdnDecorationCost6.ClientID %>");


        var txtHeight = document.getElementById("txtHeight");
        var txtWidth = document.getElementById("txtWidth");
        var RoundOff = '<%=RoundOff %>';
        var IsCumulative = '<%=IsCumulative %>'.toLowerCase();
        var hdnStockAdditionalOption = document.getElementById("<%=hdnStockAdditionalOption.ClientID %>");

        if (hid_matixType.value == "P") {
            var Qty = document.getElementById("txtqty").value;
        }
        else if (hid_matixType.value == "G") {
            var Qty = document.getElementById("txtqty").value;
            roundUp('txtHeight', txtHeight.value, RoundOff);
            roundUp('txtWidth', txtWidth.value, RoundOff);
        }
        else {
            if (IsCumulative == "true") {
                var txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty");
                var txt_Cumulative_PriceQty_Text = txt_Cumulative_PriceQty.text;
                var txt_Cumulative_PriceQty_Value = txt_Cumulative_PriceQty.value;
            } else {
                var ddlPriceQty = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlPriceQty");
                var ddlPriceQtyText = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                var ddlPriceQtyvalue = ddlPriceQty.options[ddlPriceQty.selectedIndex].value;
            }
        }

        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
                VisibleAdditionaloption_ForOrder(ddlMultiple.getAttribute('WeotherCostID'));
            }
        }
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/item/order_catalogue_item.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        function HidePanle() {
            document.getElementById("<%=pnlCatalogue.ClientID %>").style.display = "none";
            document.getElementById("divPriceCatalogue").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }

        function showProductChaneDiv() {
            showDivPopupCenter('divPriceCatalogue', '350');
            document.getElementById("<%=pnlCatalogue.ClientID %>").style.display = "block";
        }

        function UpdateCount(txt, index) {

            var calcType = document.getElementById("hdn_FreeTextQuestion_CalculationType_" + index)?.value || "l";
            var limit = calcType.toLowerCase() === "f" ? 100 : 1000;

            if (txt.value.length > limit) {
                txt.value = txt.value.substring(0, limit);
            }

            // update counter text
            var countSpan = document.getElementById("cnt_txtFreeTextQuestion_" + index);
            if (countSpan) {

                countSpan.innerHTML = txt.value.length + "/" + limit;

                // color handling
                if (txt.value.length >= limit) {
                    countSpan.style.color = "red";
                    txt.style.borderColor = "red";
                } else {
                    countSpan.style.color = "#555";
                    txt.style.borderColor = "";
                }
            }
        }
        var CataItemsInterValID = '';
        var Temp_CatalogueName = '';
        function TakeCatalogue(CatalogueID, CatalogueName) {

            document.getElementById("ds00").style.display = "block";
            document.getElementById("divPriceCatalogue").style.display = "none";
            var pnlCatalogue = document.getElementById("<%=pnlCatalogue.ClientID %>");
            if (pnlCatalogue != null) {
                pnlCatalogue.style.display = "none";
            }

            hid_PriceCatalogueID.value = CatalogueID;
            document.getElementById("<%=hidCatalogueID.ClientID %>").value = CatalogueID;
            document.getElementById("<%=hid_catalogue_items.ClientID %>").value = '';
            CataItemsInterValID = setInterval("ReCheckCatalogueList()", 5);
            __doPostBack('ctl00$ContentPlaceHolder1$ProductCatalogue$lnkProductCatalogue', '');
        }


        function ReCheckCatalogueList() {
            var hid_catalogue_items = document.getElementById("<%=hid_catalogue_items.ClientID %>");
            if (hid_catalogue_items.value != '') {
                document.getElementById("spn_Catalogue_Name").innerHTML = Temp_CatalogueName;
                document.getElementById("spn_Catalogue_Name").innerHTML = document.getElementById("spn_Catalogue_Name").innerHTML.length > 150 ? document.getElementById("spn_Catalogue_Name").innerHTML.substring(0, 150) + "..." : document.getElementById("spn_Catalogue_Name").innerHTML;

                CallAfter2sec();
                clearInterval(CataItemsInterValID);
                if (navigator.appName != "Microsoft Internet Explorer") {
                    showDivPopupCenter('divPriceCatalogue', '350');
                }
                else {
                    showDivPopupCenter('divPriceCatalogue', '350');
                }
            }
        }
    </script>
    <asp:HiddenField ID="hid_catalogue_items" runat="server" />
</div>
<div id="div_out_1" style="overflow-y: scroll; border: solid 1px red; width: 100%; display: none;">
    <div id="div_in_2" style="border: solid 1px blue;">
        Loading...
    </div>
    <div id="div_price_loading" style="position: absolute; top: 45%; left: 45%; z-index: 1000; display: none;">
        <div align="left" style="position: absolute; height: 50px; width: 200px; top: 45%; left: 45%;">
            <UC:Loading ID="ucLoading2" runat="server" />
        </div>
    </div>
    <asp:HiddenField ID="hid_Price_CustomerID" runat="server" />
    <asp:HiddenField ID="hid_Customer_Name" runat="server" />
    <%-- Javascript in ItemAdd.js File --%>
    <script type="text/javascript">
        var hid_Price_CustomerID = document.getElementById("<%=hid_Price_CustomerID.ClientID %>");
        var hid_Customer_Name = document.getElementById("<%=hid_Customer_Name.ClientID %>");
        var ddlCategory_id = document.getElementById("<%=ddlCategoryBind.ClientID %>").id;
        function MakeOtherNull(para) {
        }
        var GridItemTitle = document.getElementById("<%=GridPriceCatalogue.ClientID %>");
        function CallOverflow() {
            SetGridOverflow(GridItemTitle);
        }
    </script>
    <script type="text/javascript">
        //PRICE CATALOGUE             
        var div_price_catalogue = document.getElementById("div_price_catalogue");

    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <asp:HiddenField ID="hidCatalogueDataOnEdit" runat="server" Value="" />
    <asp:Panel ID="pnlCatalogueOnEdit" runat="server" Visible="false">
        <script type="text/javascript">
            var hidCatalogueDataOnEdit = document.getElementById("<%=hidCatalogueDataOnEdit.ClientID %>");
            CatalogueOnEdit(); //This function is in itemAdd.js File
        </script>
    </asp:Panel>
    <asp:HiddenField ID="hid_GetItemDescription" runat="server" />
    <script type="text/javascript">
        function Getitemdescription() {
            var hid_GetItemDescription = document.getElementById("<%=hid_GetItemDescription.ClientID %>");
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_item_title").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_design").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_art").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_color").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_size").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_material").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_delivery").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_finishing").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_Proofs").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_Packing").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_notes").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtcatalogue_terms").value + '~';
        }

        document.getElementById("ds00").style.display = "none";

        document.getElementById("div_Load").style.display = "none";


    </script>
</div>
