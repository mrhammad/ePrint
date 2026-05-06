<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="estimate_price_catalogueNew.ascx.cs" Inherits="ePrint.usercontrol.Item.estimate_price_catalogueNew" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"
    language="javascript"></script>
<div id="ds00" style="display: block;">
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoadings" runat="server" />
</div>
<asp:HiddenField ID="hdnQtyNumber" runat="server" Value="" />
<asp:HiddenField ID="hdnJobStatusID" runat="server" Value="" />
<asp:HiddenField ID="hdnEstimatePossible" runat="server" Value="" />
<asp:HiddenField ID="hdnddl_req_qty_1" runat="server" Value="" />
<asp:HiddenField ID="hdnddl_req_qty_2" runat="server" Value="" />
<asp:HiddenField ID="hdnddl_req_qty_3" runat="server" Value="" />
<asp:HiddenField ID="hdnddl_req_qty_4" runat="server" Value="" />
<asp:HiddenField ID="hdnLabelqtyPrice1" runat="server" Value="" />
<asp:HiddenField ID="hdnLabelqtyPrice2" runat="server" Value="" />
<asp:HiddenField ID="hdnLabelqtyPrice3" runat="server" Value="" />
<asp:HiddenField ID="hdnLabelqtyPrice4" runat="server" Value="" />
<asp:HiddenField ID="hdnTempfield1" runat="server" Value="0" />
<asp:HiddenField ID="hdnTempfield2" runat="server" Value="0" />
<asp:HiddenField ID="hdnTempfield3" runat="server" Value="0" />
<asp:HiddenField ID="hdnTempfield4" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice1_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice2_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice3_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice4_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice1_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice2_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice3_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice4_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice1_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice2_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice3_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice4_0" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice1_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice2_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice3_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice4_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice1_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice2_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice3_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice4_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice1_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice2_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice3_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice4_1" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice1_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice2_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice3_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice4_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice1_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice2_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice3_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice4_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice1_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice2_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice3_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice4_2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice1_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice2_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice3_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionTypePrice4_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice1_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice2_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice3_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MatrixTypePrice4_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice1_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice2_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice3_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_MultipleTypePrice4_3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_allselectedqty" runat="server" Value="" />
<asp:HiddenField ID="hdn_allTempSubTotal" runat="server" Value="0" />
<asp:HiddenField ID="hdn_allTypesAOTotal" runat="server" Value="0" />
<script type="text/javascript">

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_matixType");
    var hdn_allselectedqty = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdn_allselectedqty");
    var hdn_allTempSubTotal = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdn_allTempSubTotal");
    var hdn_allTypesAOTotal = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdn_allTypesAOTotal");

    var Alert_Msg = "<%=Alert_Msg%>";
    var ItemName = '<%=objLanguage.GetLanguageConversion("Item_Name") %>';
    var Quantity = '<%=objLanguage.GetLanguageConversion("Quantity") %>';
    var Price = '<%=objLanguage.GetLanguageConversion("Price") %>';


    function onddlChanged(ddlObj, index) {

        for (var k = 1; k <= 4; k++) {
            if (index == k) {
                //To access Total Selling Price($) as----->Price($).
                var hdnLabelqtyPrice = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnLabelqtyPrice" + k + "");
                var spn_Total_QtyPrice_1 = document.getElementById("spn_Total_QtyPrice_" + k + "");
                var LabelqtyPrice1 = document.getElementById("LabelqtyPrice" + k + "");
                LabelqtyPrice1.innerHTML = spn_Total_QtyPrice_1.innerHTML;
                hdnLabelqtyPrice.value = LabelqtyPrice1.innerHTML;

                //To access Selected quantity1 as---->quantity1.
                var hdnddl_req_qty = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnddl_req_qty_" + k + "");
                var selectedindexval1 = ddlObj.options[ddlObj.selectedIndex].text;
                var lblDescription1 = document.getElementById("Labelqty" + k + "");
                lblDescription1.innerHTML = selectedindexval1;
                hdnddl_req_qty.value = lblDescription1.innerHTML;
                return false;
            }
        }
    }

    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.height * 3 + "px";
    document.getElementById("ds00").style.display = "block";


    //    function funcBtnNextonclick() {
    function funcBtnNextonclick(PriceCatalogueID, CatalogueName, MatrixType) {

        var priceCatID = PriceCatalogueID;
        var CatName = CatalogueName;
        var MatType = MatrixType;
        storeToArrayAO(priceCatID, CatName, MatType);
        Getitemdescription();
        SaveCataloguetwo();

        document.getElementById("div_plh").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_pnlAdditionalOption").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_Div_BackSave").style.display = "block";

        var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_matixType");
        var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuestionLenght");
        var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_MultipleLenght");
        var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_MatrixLenght");

        if (hid_matixType.value == "P") {

            //---------------------------------

            for (var k = 1; k <= 4; k++) {


                var spn_Total_QtyPrice = document.getElementById("spn_Total_QtyPrice_" + k + "");
                var txt_req_qty = document.getElementById("txt_req_qty_" + k + "");
                var Labelqtytxt = document.getElementById("Labelqtytxt" + k + "");
                var LabelqtyPricetxt = document.getElementById("LabelqtyPricetxt" + k + "");
                var lbltotal = document.getElementById("lbltotal" + k + "");

                if (txt_req_qty.value == '') {

                    Labelqtytxt.innerHTML = '';
                    LabelqtyPricetxt.innerHTML = '';
                    lbltotal.innerHTML = '';
                    if (hid_QuestionLenght.value != "0") {
                        for (var j = 0; j <= hid_QuestionLenght.value - 1; j++) {
                            document.getElementById("lblPrice" + k + "_" + j + "").innerHTML = '';
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var j = 0; j <= hid_MatrixLenght.value - 1; j++) {
                            document.getElementById("lblMatrixPrice" + k + "_" + j + "").innerHTML = '';
                        }
                    }
                    if (hid_MultipleLenght.value != "0") {
                        for (var j = 0; j <= hid_MultipleLenght.value - 1; j++) {
                            document.getElementById("lblMultiplePrice" + k + "_" + j + "").innerHTML = '';
                        }
                    }

                }
                else {
                    //for quantity1.
                    Labelqtytxt.innerHTML = txt_req_qty.value;
                    //for Price.
                    LabelqtyPricetxt.innerHTML = spn_Total_QtyPrice.innerHTML;

                    lbltotal.innerHTML = LabelqtyPricetxt.innerHTML;
                }
            }
        }
        else {

            for (var k = 1; k <= 4; k++) {

                var ddl_req_qty = document.getElementById("ddl_req_qty_" + k + "");
                var lbltotal = document.getElementById("lbltotal" + k + "");

                if (ddl_req_qty.selectedIndex == 0 && ddl_req_qty.options[ddl_req_qty.selectedIndex].text == 'select') {

                    if (hid_QuestionLenght.value != "0") {
                        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                            document.getElementById("lblPrice" + k + "_" + i + "").innerHTML = '';
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var i = 0; i <= Number(hid_MatrixLenght.value) - 1; i++) {
                            document.getElementById("lblMatrixPrice" + k + "_" + i + "").innerHTML = '';
                        }
                    }
                    if (hid_MultipleLenght.value != "0") {
                        for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                            document.getElementById("lblMultiplePrice" + k + "_" + i + "").innerHTML = '';
                        }
                    }
                    document.getElementById("Labelqty" + k + "").innerHTML = '';
                    document.getElementById("LabelqtyPrice" + k + "").innerHTML = '';
                    lbltotal.innerHTML = '';


                }
                else {
                    var LabelqtyPrice = document.getElementById("LabelqtyPrice" + k + "");
                    LabelqtyPrice.innerHTML = document.getElementById("spn_Total_QtyPrice_" + k + "").innerHTML;
                }
            }
        }
        Tocall_mainFunc();
        document.getElementById("<%=pnlCatalogue.ClientID %>").style.display = "block";
        document.getElementById("divPriceCatalogue").style.display = "block";
        document.getElementById("divBackGroundNew").style.display = "block";
        return false;
    }

    function SaveCataloguetwo() {

        var Data = '';
        for (var i = 0; i < Price_Array.length; i++) {
            var objArr = Price_Array[i];
            Data += "PriceCatalogueID»" + objArr.PriceCatalogueID + "±";
            Data += "Quantity»" + objArr.Quantity + "±";
            Data += "Price»" + roundNumber(objArr.Price, 2) + "±";
            Data += "Cost»" + objArr.Cost + "±";
            Data += "CatalogueName»" + objArr.CatalogueName + "±";
            Data += "MultipleOf»" + objArr.MultipleOf + "±";
            Data += "Markup»" + objArr.Markup + "µ";
        }
        if (Data == '') {
            alert(' <%=objLanguage.GetLanguageConversion("Please_Select_At_Least_One_Catalogue_Item")%> ');
            return false;
        }
        else {
            hidCatalogueData.value = Data;
            return false;
        }
    }
    function prevpnlCatalogue() {
        //-------------------
        document.getElementById("div_plh").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_pnlAdditionalOption").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_Div_BackSave").style.display = "none";
        return false;
    }


</script>

<script type="text/javascript">
    var strImagepath = "<%=strImagepath %>";
    var SimpleMatBrowserHandy = '<%=SimpleMatBrowserHandy %>';
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
<div class="div_prodcatalogue">
    <asp:HiddenField ID="hid_Price_Data" runat="server" />
    <asp:UpdatePanel ID="UPID12" runat="server" RenderMode="Block">
        <ContentTemplate>
            <asp:HiddenField ID="hid_query_details" runat="server" Value="" />
            <%--New Control on 12.10.2011--%>
            <div style="float: left; text-align: left; width: 74%; padding-bottom: 2px;">
                <div class="bglabel" style="width: 18%;">
                    <%=objLanguage.GetLanguageConversion("Show_Products")%>:
                </div>
                <div class="box">
                    <asp:Panel ID="Pnl_ddl" runat="server">
                        <asp:DropDownList runat="server" ID="ddlCategoryBind" SkinID="onlyDDL" Width="350px"
                            OnSelectedIndexChanged="ddlCategoryBind_Onchange" AutoPostBack="true" EnableViewState="true"
                            Height="18px">
                            <asp:ListItem Text="Present Customer" Value="0"></asp:ListItem>
                            <asp:ListItem Text="All Items" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Unallocated Items" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                </div>
            </div>
            <div id="Link" style="float: left; text-align: right; width: 98%; margin-bottom: 1px; padding-top: 10px">
                <asp:Panel ID="Pnl_btnclrall" runat="server">
                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                        runat="server" Text="Clear all Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                </asp:Panel>
            </div>
            <div style="float: left; margin-left:0px;padding-top:0px;padding-bottom:5px;">
                            <asp:LinkButton ID="lnkPurchaseedit" runat="server" Style="text-decoration: underline;"
                                OnClientClick="javascript:return edit_estimatview();" OnClick="btnEditView_Click"><%=objLanguage.GetLanguageConversion("Edit_Add") %></asp:LinkButton>
                            <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display:none; cursor: pointer;
                                    color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Rad Control,12.10.2011--%>
    <div id="Grid_Disp" runat="server" style="padding: 5px 5px 5px 3px; clear: both;">
        <asp:Panel ID="Panel1" runat="server">
            <telerik:RadGrid Width="106%" ID="GridPriceCatalogue" runat="server" GridLines="None"
                ShowStatusBar="true" PageSize="50" PagerStyle-AlwaysVisible="true" AutoGenerateColumns="False"
                HeaderStyle-Font-Bold="true" AllowPaging="true" AllowFilteringByColumn="true"
                OnItemCommand="OnItemCommand_GridPriceCatalogue" OnNeedDataSource="GridPriceCatalogue_NeedDataSource"
                AllowSorting="true" OnItemDataBound="OnItemDataBound_GridPriceCatalogue">
                <MasterTableView Width="100%" OverrideDataSourceControlSorting="true">
                    <Columns>
                        <telerik:GridTemplateColumn SortExpression="PriceCatalogueCategoryName" UniqueName="PriceCatalogueCategoryName"
                            DataField="PriceCatalogueCategoryName" CurrentFilterFunction="Contains" HeaderStyle-Width="30%"
                            ShowSortIcon="true" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="120px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblHeaderName1" runat="server"><%=objLanguage.GetLanguageConversion("Category_Name")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <%-- <a href="javascript:void(0);" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">--%>
                                        <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.PriceCatalogueCategoryName","{0}"))%>
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
                                <asp:Label ID="lblHeaderName2" runat="server"><%=objLanguage.GetLanguageConversion("Item_title")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden;">
                                        <%--<a href="javascript:void(0);" onclick="TakeCatalogue(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">--%>
                                        <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.CatalogueName","{0}")) %>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn SortExpression="Description" DataField="Description"
                            ShowSortIcon="true" UniqueName="Description" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="40%" ItemStyle-Width="40%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="150px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblHeaderName3" runat="server"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblDescription" runat="server" ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Description","{0}")) %>'> <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Description","{0}")) %></asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn SortExpression="ItemCode" DataField="ItemCode" ShowSortIcon="true"
                            UniqueName="ItemCode" CurrentFilterFunction="Contains" HeaderStyle-Width="30%"
                            ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left" FilterControlWidth="100px"
                            AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblHeaderName4" runat="server"><%=objLanguage.GetLanguageConversion("Item_Code")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblitemcode" runat="server" ToolTip='<%#Eval("Description") %>'> <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.ItemCode","{0}"))%></asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn SortExpression="CustomerCode" DataField="CustomerCode"
                            ShowSortIcon="true" UniqueName="CustomerCode" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblHeaderName5" runat="server"><%=objLanguage.GetLanguageConversion("p_Customer_code")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblcustomercode" runat="server" ToolTip='<%#Eval("Description") %>'> <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.CustomerCode","{0}"))%></asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn SortExpression="ProductType" DataField="ProductType"
                            ShowSortIcon="true" UniqueName="ProductType" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername6" runat="server"><%=objLanguage.GetLanguageConversion("Product_Type")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblproducttype" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("ProductType") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Supplier" DataField="Supplier"
                            ShowSortIcon="true" UniqueName="Supplier" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername7" runat="server"><%=objLanguage.GetLanguageConversion("Supplier")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblsupplier" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Supplier") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="AllocatedCustomer" DataField="AllocatedCustomer"
                            ShowSortIcon="true" UniqueName="AllocatedCustomer" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername8" runat="server"><%=objLanguage.GetLanguageConversion("Allocated_Customer")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblallocatedcustomer" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("AllocatedCustomer") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="SalesTax" DataField="SalesTax"
                            ShowSortIcon="true" UniqueName="SalesTax" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername9" runat="server"><%=objLanguage.GetLanguageConversion("Sales_Tax")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblsalestax" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("SalesTax") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Artwork" DataField="Artwork"
                            ShowSortIcon="true" UniqueName="Artwork" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername10" runat="server"><%=objLanguage.GetLanguageConversion("Artwork")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblartwork" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Artwork") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Color" DataField="Color"
                            ShowSortIcon="true" UniqueName="Color" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername11" runat="server"><%=objLanguage.GetLanguageConversion("Color")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblcolor" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Color") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Size" DataField="Size"
                            ShowSortIcon="true" UniqueName="Size" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername12" runat="server"><%=objLanguage.GetLanguageConversion("Size")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblsize" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Size") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Material" DataField="Material"
                            ShowSortIcon="true" UniqueName="Material" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername13" runat="server"><%=objLanguage.GetLanguageConversion("Material")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblmaterial" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Material") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Delivery" DataField="Delivery"
                            ShowSortIcon="true" UniqueName="Delivery" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername14" runat="server"><%=objLanguage.GetLanguageConversion("Delivery")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lbldelivery" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Delivery") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Finishing" DataField="Finishing"
                            ShowSortIcon="true" UniqueName="Finishing" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername15" runat="server"><%=objLanguage.GetLanguageConversion("Finishing")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblfinishing" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Finishing") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Proofs" DataField="Proofs"
                            ShowSortIcon="true" UniqueName="Proofs" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername16" runat="server"><%=objLanguage.GetLanguageConversion("Proofs")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblproofs" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Proofs") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Packing" DataField="SalePackingsTax"
                            ShowSortIcon="true" UniqueName="Packing" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername17" runat="server"><%=objLanguage.GetLanguageConversion("Packing")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblpacking" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Packing") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="Notes" DataField="Notes"
                            ShowSortIcon="true" UniqueName="Notes" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername18" runat="server"><%=objLanguage.GetLanguageConversion("Notes")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblnotes" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Notes") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn SortExpression="PublicAccounts" DataField="PublicAccounts"
                            ShowSortIcon="true" UniqueName="PublicAccounts" CurrentFilterFunction="Contains"
                            HeaderStyle-Width="30%" ItemStyle-Width="30%" Visible="true" HeaderStyle-HorizontalAlign="left"
                            FilterControlWidth="100px" AutoPostBackOnFilter="true">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderTemplate>
                                <asp:Label ID="lblheadername19" runat="server"><%=objLanguage.GetLanguageConversion("Public_Accounts")%></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href="javascript:;" onclick="openproductwindow(<%#Eval("PriceCatalogueID") %>,'<%#Eval("CatalogueName") %>');">
                                    <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                        <asp:Label ID="lblpublicaccounts" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("PublicAccounts") %> </asp:Label>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true" AllowColumnsReorder="false"
                    AllowRowsDragDrop="false">
                    <ClientEvents />
                    <Scrolling ScrollHeight="370" UseStaticHeaders="true" />
                </ClientSettings>
            </telerik:RadGrid>
        </asp:Panel>
    </div>
    <div style="float: left; width: 99%; border: 0px solid green;">
        <div align="left" id="Div_ItemDescn" runat="server" visible="false">
            <div class="bglabelnewLarge" style="float: left; width: 18%">
                <asp:Label ID="Label7" runat="server" Text="Update Item Descriptions" CssClass="normaltext"></asp:Label>
                <a href="javascript:void(0);" class="tooltip" title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                    <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                        style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                        class="tooltip" /></a>
            </div>
            <div class="box" style="float: left;">
                <div id="div2" align="left">
                    <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="false" />
                </div>
            </div>
        </div>
        <div align="right" style="float: right; text-align: right;">
            <div style="float: left;">
                <div id="div_btnpriceprev" style="display: block">
                    <asp:Button ID="btnPricePrevious" CssClass="button" OnClick="btnprevious_onclick"
                        OnClientClick="javascript:loadingimg('div_btnpriceprev','div_priceprevprocess')"
                        Text="Previous" Width="65px" runat="server" />
                </div>
                <div id="div_priceprevprocess" class="button" align="center" style="width: 47px; display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                </div>
            </div>
            <div style="float: left; width: 10px">
                &nbsp;
            </div>
            <div style="float: left;">
                <div id="div_btnfinish" style="display: none">
                    <asp:HiddenField ID="hidCatalogueData" runat="server" />
                    <asp:Button ID="Button15" CssClass="button" Text="Finish" OnClientClick="javascript:var a=SvaeCatalogue();if(a) loadingimg('div_btnfinish','div_finishprocess');return a;"
                        Width="55px" runat="server" />
                    <asp:LinkButton ID="lnkCatalogueFinish" runat="server" OnClick="btnCatalogueFinish_OnClick"></asp:LinkButton>
                </div>
                <div id="div_finishprocess" class="button" align="center" style="width: 37px; display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                </div>
            </div>
        </div>
    </div>
    <div style="float: left; width: 98%; padding: 5px 0px 0px 2px; border: 0px solid red;">
        <div style="float: left; text-align: left;">
            <div align="left" style="width: 150px; padding-left: 2px;">
                <a id="hrefShowCatalogue" href="javascript://" onclick='ShowCatalogueList();' style="display: none; text-decoration: none;"><b>
                    <%=objLanguage.GetLanguageConversion("Show_Catalogue_Items")%></b></a>
            </div>
            <div id="div_selected_catalogue" style="display: none; width: 550px; position: absolute;">
                <div id="div_catalogue_items_header" align="left" class="bgcustomize" style="padding: 2px; padding-right: 0px;">
                </div>
                <div id="div_catalogue_items" align="left" class="divborderItem" style="overflow-y: scroll; clear: both; padding: 2px; height: 100px; background-color: white;">
                </div>
            </div>
        </div>
    </div>
    <%--End of Rad --%>
    <div>
        <asp:HiddenField ID="txtPriceCatalogueSerach" runat="server" />
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
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
    <contenttemplate>
        <asp:HiddenField ID="hdnUnitOfMeasure" runat="server" Value="0" />
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
<asp:UpdateProgress ID="UPPro" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
    <progresstemplate>
        <div align="left" style="position: absolute; height: 50px; width: 200px; top: 45%; left: 45%;">
            <UC:Loading ID="ucLoading1" runat="server" />
        </div>
    </progresstemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block">
    <contenttemplate>
        <div align="left">
            <asp:HiddenField ID="hdn_drawstockfrom" runat="server" Value="" />
            <asp:HiddenField ID="hdn_isbackorder" runat="server" Value="0" />
            <asp:HiddenField ID="hidCatalogueID" runat="server" Value="0" />
            <asp:HiddenField ID="hid_IsSides" runat="server" Value="0" />
            <asp:HiddenField ID="hdn_StockManagement" runat="server" Value="0" />
            <asp:HiddenField ID="hdn_IsStockItem" runat="server" Value="" />
            <asp:HiddenField ID="hdn_kitavailibility" runat="server" Value="0" />
            <asp:HiddenField ID="hdn_returnboolvalue" runat="server" Value="" />
            <asp:HiddenField ID="hdn_cataloguename" runat="server" Value="" />
            <div id="divPriceCatalogue" align="left" style="float: left; position: absolute; width: 85%; min-height: 450px; display: none; z-index: 10000">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="2" class="popup-top-leftcorner">&nbsp;
                        </td>
                        <td class="popup-top-middlebg">
                            <div align="left" style="padding-top: 6px; text-align: center;">
                                <span id="spn_Catalogue_Name" runat="server" style="color: Black;"></span>
                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                    <div class="CancelButtonDiv">
                                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                            runat="server" CausesValidation="false" OnClientClick="javascript:HidePanle(); return false;" />
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
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlOtherMultiple" runat="server" Visible="false">
                                        <div style="float: left; width: 100%">
                                            <div class="bgLabelnew" style="width: 11.7%; text-align: left; margin-left: 4.9px;">
                                                Other Multiple Products
                                            </div>
                                            <div class="box" style="width: 40%; text-align: left">
                                                <asp:DropDownList ID="ddlOtherMultiple" Width="72%" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlOtherMultiple_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Panel ID="pnlCatalogue" runat="server" Style="display: none">
                                <div id="div_pnlCatalogue" runat="server" style="display: block;">
                                    <div class="onlyEmpty">
                                    </div>
                                    <div class="removeTrancy">
                                        <div align="left">
                                            <div class="only5px">
                                            </div>
                                            <div id="div_price_qty_valid" style="display: none; padding-top: 2px;" align="center">
                                                <div align="center" style="width: 35%; padding: 2px 0px 2px 0px;">
                                                    <span id="span_price_qty_valid" class="spanerrorMsg">Please enter at least one quantity</span>
                                                </div>
                                            </div>
                                            <div style="padding-left: 3px;" id="div_plh">
                                                <asp:PlaceHolder ID="plhCatalogueList" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div style="clear: both;">
                                </div>                             
                                <div id="pnlAdditionalOption" runat="server" style="display: none; padding: 2px 0px 0px 5px; border: 0px solid red; height: 400px; overflow-y: scroll;">
                                    <asp:PlaceHolder ID="plhquantity" runat="server"></asp:PlaceHolder>
                                    <div id="Div_BackSave" runat="server" style="display: none; float: left; padding: 10px 0px 10px 275px;">
                                        <div style="display: inline; float: left">
                                            <div id="div_btnback" style="display: block">
                                                <asp:Button ID="btnBack" CssClass="button" Text="Back" Width="65px" runat="server"
                                                    OnClientClick="javascript:var a=prevpnlCatalogue();if(a)loadingimg('div_btnback','div_btnbackprocess');return a;" />
                                            </div>
                                            <div id="div_btnbackprocess" class="button" align="center" style="width: 47px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 5px">
                                            &nbsp;
                                        </div>
                                        <div style="display: inline; float: right">
                                            <div id="div_btnsave" style="display: block">
                                                <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                                                    OnClientClick="javascript:var a=Save_OrderItems();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return false;" />
                                                <asp:LinkButton ID="lnkbtnSave" runat="server" OnClick="Onclick_btnSave"></asp:LinkButton>
                                            </div>
                                            <div id="div_btnsaveprocess" class="button" align="center" style="width: 47px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
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
            <asp:LinkButton ID="lnkCatalogueList" runat="server" OnClick="lnkCatalogueList_OnClick"></asp:LinkButton>
            <asp:HiddenField ID="hid_matixType" runat="server" Value="" />
            <asp:HiddenField ID="hid_PriceCatalogueID" runat="server" Value="" />
            <asp:HiddenField ID="hid_QuestionLenght" runat="server" Value="0" />
            <asp:HiddenField ID="hid_MultipleLenght" runat="server" Value="0" />
            <asp:HiddenField ID="hid_MatrixLenght" runat="server" Value="0" />
            <asp:HiddenField ID="hid_qtyFromList" runat="server" Value="0" />
            <asp:HiddenField ID="hid_qtyToList" runat="server" Value="0" />
            <asp:HiddenField ID="hid_CostExcMarkupList" runat="server" Value="0" />
            <asp:HiddenField ID="hid_priceList" runat="server" Value="0" />
            <asp:HiddenField ID="hid_QuantityPrice1" runat="server" />
            <asp:HiddenField ID="hid_QuantityPrice2" runat="server" />
            <asp:HiddenField ID="hid_QuantityPrice3" runat="server" />
            <asp:HiddenField ID="hid_QuantityPrice4" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup1" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup2" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup3" runat="server" />
            <asp:HiddenField ID="hid_QuantityPriceExcMarkup4" runat="server" />
            <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
            <asp:HiddenField ID="hid_UpdateToOrderItems" runat="server" />
            <asp:HiddenField ID="hid_artwork1" runat="server" />
            <asp:HiddenField ID="hid_artwork2" runat="server" />
            <asp:HiddenField ID="hid_artwork3" runat="server" />
            <asp:HiddenField ID="hid_OldPriceCatalogueID" runat="server" Value="0" />
            <asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />
            <asp:HiddenField ID="hid_PriceCataloguename" runat="server" Value="" />
            <script type="text/javascript">

                var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_matixType");
                var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuestionLenght");
                var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_MultipleLenght");
                var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_MatrixLenght");


                var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                var hid_qtyFromList = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_qtyFromList");
                var hid_qtyToList = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_qtyToList");
                var hid_priceList = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_priceList");
                var hid_CostExcMarkupList = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_CostExcMarkupList");

                var hid_QuantityPrice1 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPrice1");
                var hid_QuantityPrice2 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPrice2");
                var hid_QuantityPrice3 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPrice3");
                var hid_QuantityPrice4 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPrice4");

                var hdnTempfield1 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnTempfield1");
                var hdnTempfield2 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnTempfield2");
                var hdnTempfield3 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnTempfield3");
                var hdnTempfield4 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdnTempfield4");


                var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPriceExcMarkup");
                var hid_QuantityPriceExcMarkup2 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPriceExcMarkup2");
                var hid_QuantityPriceExcMarkup3 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPriceExcMarkup3");
                var hid_QuantityPriceExcMarkup4 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_QuantityPriceExcMarkup4");


                var hid_SaveToAdditionalItems = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_SaveToAdditionalItems");
                var hid_UpdateToOrderItems = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_UpdateToOrderItems");


                var hid_OldPriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_OldPriceCatalogueID");
                var ManageStockPermission = '<%=ManageStockPermission %>';
                var StockCancellationType = '<%=StockCancellationType %>';
                var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

                var lbltotal1 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_lbltotal1");
                var lbltotal2 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_lbltotal2");
                var lbltotal3 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_lbltotal3");
                var lbltotal4 = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_lbltotal4");

            </script>
            <script type="text/javascript">
                var closepanel;
                function HidePanle() {
                    closepanel = "y";
                    var hdnDrawStockFrom = document.getElementById("<%=hdnDrawStockFrom.ClientID %>");
                    if (hdnDrawStockFrom.value == 'm') {
                        document.getElementById("divPriceCatalogue").style.display = "none";
                        document.getElementById("divBackGroundNew").style.display = "none";
                        document.getElementById("ds00").style.display = "none";
                    }
                    else {
                        document.getElementById("<%=pnlCatalogue.ClientID %>").style.display = "none";
                        document.getElementById("divPriceCatalogue").style.display = "none";
                        document.getElementById("divBackGroundNew").style.display = "none";
                    }
                }


                var CataItemsInterValID = '';
                var Temp_CatalogueName = '';


                function TakeCatalogue(CatalogueID, CatalogueName) {

                    document.getElementById("ds00").style.display = "block";
                    closepanel = "n";
                    var pnlCatalogue = document.getElementById("<%=pnlCatalogue.ClientID %>");
                    if (pnlCatalogue != null) {
                        pnlCatalogue.style.display = "none";
                    }

                    document.getElementById("<%=hidCatalogueID.ClientID %>").value = CatalogueID;
                    document.getElementById("<%=hid_catalogue_items.ClientID %>").value = '';

                    Temp_CatalogueName = CatalogueName;
                    document.getElementById("<%=hdn_cataloguename.ClientID %>").value = CatalogueName;
                    __doPostBack('ctl00$ContentPlaceHolder1$PriceCatalog$lnkCatalogueList', '');
                    CataItemsInterValID = setInterval("ReCheckCatalogueList()", 5);

                    HideCatalogueList();
                }

                function ReCheckCatalogueList() {
                    var hid_catalogue_items = document.getElementById("<%=hid_catalogue_items.ClientID %>");
                    var hdnDrawStockFrom = document.getElementById("<%=hdnDrawStockFrom.ClientID %>");

                    var DrawStockFrom = document.getElementById("<%=hdn_drawstockfrom.ClientID %>").value;
                    var IsStockItem = document.getElementById("<%=hdn_IsStockItem.ClientID %>").value;

                    if (hid_catalogue_items.value != '') {
                        if (closepanel != 'y') {
                            document.getElementById("<%=spn_Catalogue_Name.ClientID%>").innerHTML = SpecialDecode(document.getElementById("<%=hdn_cataloguename.ClientID %>").value);   // SpecialDecode(Temp_CatalogueName);
                            document.getElementById("<%=spn_Catalogue_Name.ClientID %>").innerHTML = document.getElementById("<%=hdn_cataloguename.ClientID %>").value.length > 150 ? document.getElementById("<%=hdn_cataloguename.ClientID %>").value.substring(0, 150) + "..." : SpecialDecode(document.getElementById("<%=hdn_cataloguename.ClientID %>").value);

                            CallAfter2sec();
                            clearInterval(CataItemsInterValID);

                            if (DrawStockFrom.toLowerCase() == "x" && IsStockItem.toLowerCase() == "true") {
                                alert("This stock product can't currently be used. Please go to the product settings and select where the stock should be drawn from");
                            }
                            else {
                                if (navigator.appName != "Microsoft Internet Explorer") {
                                    showDivPopupCenter('divPriceCatalogue', '350');
                                }
                                else {
                                    showDivPopupCenter('divPriceCatalogue', '350');
                                }
                            }
                        }

                    }
                }
            </script>
            <asp:HiddenField ID="hid_catalogue_items" runat="server" />
            <asp:HiddenField ID="hdnDrawStockFrom" runat="server" />
        </div>
    </contenttemplate>
</asp:UpdatePanel>
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
        var GridItemTitle = document.getElementById("<%=GridPriceCatalogue.ClientID %>");
        function CallOverflow() {
            SetGridOverflow(GridItemTitle);
        }
    </script>
    <script type="text/javascript">
        //PRICE CATALOGUE     
        var hid_Price_Data = document.getElementById("<%=hid_Price_Data.ClientID %>");
        var div_price_catalogue = document.getElementById("div_price_catalogue");
        var hidCatalogueData = document.getElementById("<%=hidCatalogueData.ClientID %>");
        var RequestType = '<%=Request.QueryString["type"]%>';
        var ClientID = "<%=Pub_CustomerID %>";
        var ClienName = "<%=Pub_CustomerName %>";
        var CompanyID = '<%=CompanyID %>'
        var UserID = '<%=UserID %>'
        var modulename = '<%=modulename%>';
        var Measurementvalue = '<%=Measurementvalue %>';

    </script>
    <script type="text/javascript" src="<%=strSitepath%>js/item/item_pricecatalog.js?VN='<%=VersionNumber%>'"></script>
    <asp:HiddenField ID="hidCatalogueDataOnEdit" runat="server" Value="" />
    <asp:Panel ID="pnlCatalogueOnEdit" runat="server" Visible="false">
        <script type="text/javascript">
            var hidCatalogueDataOnEdit = document.getElementById("<%=hidCatalogueDataOnEdit.ClientID %>");
            CatalogueOnEdit(); //This function is in itemAdd.js File
        </script>
    </asp:Panel>
    <asp:HiddenField ID="hid_GetItemDescription" runat="server" />
    <asp:HiddenField ID="hdn_title" runat="server" Value="" />
    <asp:HiddenField ID="hdn_description" runat="server" Value="" />
    <asp:HiddenField ID="hdn_artwork" runat="server" Value="" />
    <asp:HiddenField ID="hdn_color" runat="server" Value="" />
    <asp:HiddenField ID="hdn_size" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Material" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Delivery" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Finish" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Proofs" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Packing" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Notes" runat="server" Value="" />
    <asp:HiddenField ID="hdn_terms" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription1" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription2" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription3" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription4" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription5" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription6" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription7" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription8" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription9" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription10" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription11" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription12" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription13" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription14" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription15" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription16" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription17" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription18" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription19" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription20" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription21" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription22" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription23" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription24" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomDescription25" runat="server" Value="" />
    <asp:HiddenField ID="hdn_txttotalquantity" runat="server" Value="0" />
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
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription1").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription2").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription3").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription4").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription5").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription6").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription7").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription8").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription9").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription10").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription11").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription12").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription13").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription14").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription15").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription16").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription17").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription18").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription19").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription20").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription21").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription22").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription23").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription24").value + '~';
            hid_GetItemDescription.value += document.getElementById("txtCustomDiscription25").value + '~';

            document.getElementById("<%=hdn_title.ClientID %>").value = document.getElementById("txtcatalogue_item_title").value;
            document.getElementById("<%=hdn_description.ClientID %>").value = document.getElementById("txtcatalogue_design").value;
            document.getElementById("<%=hdn_artwork.ClientID %>").value = document.getElementById("txtcatalogue_art").value;
            document.getElementById("<%=hdn_color.ClientID %>").value = document.getElementById("txtcatalogue_color").value
            document.getElementById("<%=hdn_size.ClientID %>").value = document.getElementById("txtcatalogue_size").value;
            document.getElementById("<%=hdn_Material.ClientID %>").value = document.getElementById("txtcatalogue_material").value;
            document.getElementById("<%=hdn_Delivery.ClientID %>").value = document.getElementById("txtcatalogue_delivery").value;
            document.getElementById("<%=hdn_Finish.ClientID %>").value = document.getElementById("txtcatalogue_finishing").value;
            document.getElementById("<%=hdn_Proofs.ClientID %>").value = document.getElementById("txtcatalogue_Proofs").value;
            document.getElementById("<%=hdn_Packing.ClientID %>").value = document.getElementById("txtcatalogue_Packing").value;
            document.getElementById("<%=hdn_Notes.ClientID %>").value = document.getElementById("txtcatalogue_notes").value;
            document.getElementById("<%=hdn_terms.ClientID %>").value = document.getElementById("txtcatalogue_terms").value;

            document.getElementById("<%=hdn_CustomDescription1.ClientID %>").value = document.getElementById("txtCustomDiscription1").value;
            document.getElementById("<%=hdn_CustomDescription2.ClientID %>").value = document.getElementById("txtCustomDiscription2").value;
            document.getElementById("<%=hdn_CustomDescription3.ClientID %>").value = document.getElementById("txtCustomDiscription3").value;
            document.getElementById("<%=hdn_CustomDescription4.ClientID %>").value = document.getElementById("txtCustomDiscription4").value;
            document.getElementById("<%=hdn_CustomDescription5.ClientID %>").value = document.getElementById("txtCustomDiscription5").value;
            document.getElementById("<%=hdn_CustomDescription6.ClientID %>").value = document.getElementById("txtCustomDiscription6").value;
            document.getElementById("<%=hdn_CustomDescription7.ClientID %>").value = document.getElementById("txtCustomDiscription7").value;
            document.getElementById("<%=hdn_CustomDescription8.ClientID %>").value = document.getElementById("txtCustomDiscription8").value;
            document.getElementById("<%=hdn_CustomDescription9.ClientID %>").value = document.getElementById("txtCustomDiscription9").value;
            document.getElementById("<%=hdn_CustomDescription10.ClientID %>").value = document.getElementById("txtCustomDiscription10").value;
            document.getElementById("<%=hdn_CustomDescription11.ClientID %>").value = document.getElementById("txtCustomDiscription11").value;
            document.getElementById("<%=hdn_CustomDescription12.ClientID %>").value = document.getElementById("txtCustomDiscription12").value;
            document.getElementById("<%=hdn_CustomDescription13.ClientID %>").value = document.getElementById("txtCustomDiscription13").value;
            document.getElementById("<%=hdn_CustomDescription14.ClientID %>").value = document.getElementById("txtCustomDiscription14").value;
            document.getElementById("<%=hdn_CustomDescription15.ClientID %>").value = document.getElementById("txtCustomDiscription15").value;
            document.getElementById("<%=hdn_CustomDescription16.ClientID %>").value = document.getElementById("txtCustomDiscription16").value;
            document.getElementById("<%=hdn_CustomDescription17.ClientID %>").value = document.getElementById("txtCustomDiscription17").value;
            document.getElementById("<%=hdn_CustomDescription18.ClientID %>").value = document.getElementById("txtCustomDiscription18").value;
            document.getElementById("<%=hdn_CustomDescription19.ClientID %>").value = document.getElementById("txtCustomDiscription19").value;
            document.getElementById("<%=hdn_CustomDescription20.ClientID %>").value = document.getElementById("txtCustomDiscription20").value;
            document.getElementById("<%=hdn_CustomDescription21.ClientID %>").value = document.getElementById("txtCustomDiscription21").value;
            document.getElementById("<%=hdn_CustomDescription22.ClientID %>").value = document.getElementById("txtCustomDiscription22").value;
            document.getElementById("<%=hdn_CustomDescription23.ClientID %>").value = document.getElementById("txtCustomDiscription23").value;
            document.getElementById("<%=hdn_CustomDescription24.ClientID %>").value = document.getElementById("txtCustomDiscription24").value;
            document.getElementById("<%=hdn_CustomDescription25.ClientID %>").value = document.getElementById("txtCustomDiscription25").value;

        }
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";

    </script>
</div>
<script type="text/javascript">
    CallPriceCatalogueDiv();

    function Norowsalert() {
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
        document.getElementById("divPriceCatalogue").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
        alert('<%=objLanguage.GetLanguageConversion("No_Rows_ProductCatalogue_Alert")%>');

    }
</script>
<%----added by rakshith ------%>
<div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 80%"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1100" Height="610" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Resize">
    </telerik:RadWindowManager>
</div>
<script language="javascript" type="text/javascript">
    var PriceCatalogueID;
    var Cataloguename;
    var WindowOpend;
    var hid_PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_PriceCatalogueID").value;
    var hid_PriceCataloguename = document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hid_PriceCataloguename").value;
    var pagetype = "<%=QueryType %>";

    function pageLoad() {
        if (pagetype == "edit") {
            if (WindowOpend != "true") {
                WindowOpend = "false";
                openproductwindow(hid_PriceCatalogueID, hid_PriceCataloguename);
            }
        }
    }

    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }

    function openproductwindow(id, cataloguename) {
        debugger;

        //------------------ start

        var pageType = getUrlVars()["fromPageType"];
        var ddlValue = $("#ctl00_ContentPlaceHolder1_PriceCatalog_ddlCategoryBind").val();


        //------------------ end

        WindowOpend = "false";
        var ProductStockManagement = document.getElementById("<%=hdn_StockManagement.ClientID %>").value;
        PriceCatalogueID = id;
        Cataloguename = cataloguename;
        if (ProductStockManagement.toLowerCase() == "true") {
            AutoFill.IsStockItemProductCheck(id, Check_IsStockItem, onTimeout, onError);
        }
        else {
            var encodedCataloguename = encodeURIComponent(cataloguename);
            ////var Rad1Customer = window.radopen(strSitepath + "common/common_popup.aspx?type=estimateproductcatalogue&acntype=<%=QueryType %>&maintype=<%=MainType %>&PriceCatalogueID=" + id + "&estid=<%=EstimateID %>&jID=<%=jobID %>&InvID=<%=InvoiceID %>&estitemid=<%=EstimateItemID %>&modulename=<%=modulename %>&submodulename=<%=submodulename %>&esttype=<%=EstType %>&parentestitemid=<%=ParentEstimateItemID %>&parentesttype=<%=ParentEstimateType %>&frm=<%=frm %>&FromAddAnItem=<%=FromAddAnItem %>&ordid=<%=OrderID %>&sectionid=<%=EstimateBookletItemID %>&cataloguename=" + cataloguename + "&frmcopyitem=<%=frmcopyitem %>&oldPriceCatalogueID=" + hid_PriceCatalogueID + "&fromPageType=" + pageType + "&ddlValue=" + ddlValue, '1000', '500');
            var Rad1Customer = window.radopen(strSitepath + "common/common_popup.aspx?type=estimateproductcatalogue&acntype=<%=QueryType %>&maintype=<%=MainType %>&PriceCatalogueID=" + id + "&ddlValue=" + ddlValue + "&estid=<%=EstimateID %>&jID=<%=jobID %>&InvID=<%=InvoiceID %>&estitemid=<%=EstimateItemID %>&modulename=<%=modulename %>&submodulename=<%=submodulename %>&esttype=<%=EstType %>&parentestitemid=<%=ParentEstimateItemID %>&parentesttype=<%=ParentEstimateType %>&frm=<%=frm %>&FromAddAnItem=<%=FromAddAnItem %>&ordid=<%=OrderID %>&sectionid=<%=EstimateBookletItemID %>&cataloguename=" + encodedCataloguename + "&frmcopyitem=<%=frmcopyitem %>&oldPriceCatalogueID=" + hid_PriceCatalogueID + "&fromPageType=" + pageType   , '1000', '500');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad1Customer.setSize(1200, 590);
            Rad1Customer.center();
            Rad1Customer.id = "Radwindowstock";
            WindowOpend = "true";
        }
    }

    function onTimeout(request, context) {

    }
    function onError(objError) {

    }

    function Check_IsStockItem(result) {
        debugger;
        var StockDetails = result.split('~');
        var DrawStockFrom = StockDetails[0];
        var IsStockItem = StockDetails[1];
        if (DrawStockFrom.toLowerCase() == "x" && IsStockItem.toLowerCase() == "true") {
            alert("This stock product can't currently be used. Please go to the product settings and select where the stock should be drawn from");
            return false;
        }
        else {
            setInterval(function () { OpenWindow() }, 500);
        }
    }

    function OpenWindow() {
        if (WindowOpend != "true") {
            var pageType = getUrlVars()["fromPageType"];
            var ddlValue = $("#ctl00_ContentPlaceHolder1_PriceCatalog_ddlCategoryBind").val();
            var encodedCataloguename = encodeURIComponent(Cataloguename);
            var Rad1Customer = window.radopen(strSitepath + "common/common_popup.aspx?type=estimateproductcatalogue&acntype=<%=QueryType %>&maintype=<%=MainType %>&PriceCatalogueID=" + PriceCatalogueID + "&estid=<%=EstimateID %>&jID=<%=jobID %>&InvID=<%=InvoiceID %>&estitemid=<%=EstimateItemID%>&modulename=<%=modulename %>&submodulename=<%=submodulename %>&esttype=<%=EstType %>&parentestitemid=<%=ParentEstimateItemID %>&parentesttype=<%=ParentEstimateType %>&frm=<%=frm %>&FromAddAnItem=<%=FromAddAnItem %>&ordid=<%=OrderID %>&sectionid=<%=EstimateBookletItemID %>&cataloguename=" + encodedCataloguename + "&frmcopyitem=<%=frmcopyitem %>&oldPriceCatalogueID=" + hid_PriceCatalogueID + "&fromPageType=" + pageType + "&ddlValue=" + ddlValue, '1000', '500');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad1Customer.setSize(1300, 590);
            Rad1Customer.center();
            Rad1Customer.id = "Radwindowstock";
            WindowOpend = "true";
        }
    }

</script>
<%--added by rakshith ----%>


