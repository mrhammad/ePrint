<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Delivery_Cost_selector.ascx.cs" Inherits="ePrint.usercontrol.Delivery_Cost_selector" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="InventoryAdd"
    TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script>

    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<script type="text/javascript">

    var div_Load = document.getElementById("div_Load");
    setLoadingPositionOfDivMove(div_Load);
    document.getElementById("div_Load").style.display = "block";

</script>
<script>
    var pw;

    pw = window.parent;
    function setpaperid(Invid, value, papertype, PaperWeight) {
        debugger
        var formula = PaperWeight;
        //var quantity = document.getElementById("ctl00_ContentPlaceHolder1_UcDeliveryCost_txtQuantity").value;
        var FormulaTagMul01 = PaperWeight.replaceAll('<quantity>', 1).replaceAll('[$ProductBasePrice$]', 2).replaceAll('[$OrderedHeight$]', 3).replaceAll('[$OrderedWidth$]', Number(4)).replaceAll('[$OrderedArea$]', Number(5)).replaceAll('[$MultipleOf$]', Number(6));
        var result = eval(FormulaTagMul01);
        PaperWeight = parseInt(PaperWeight).toFixed(2);
        //PaperWeight = PaperWeight + ' ' + '<%=paperWeight %>';
        PaperWeight = result;
        pw.SendPaperIDandName(Invid, SpecialDecode(value), papertype, formula, PaperWeight);
    }
    function TimerToClose() {
        window.close();

    }

    function setplatesid(id, value) {
        pw.SendPlatesIDandName(id, value);
    }

</script>

<asp:ScriptManagerProxy ID="SMproxy" runat="server">
</asp:ScriptManagerProxy>
<div id="divBackGroundNew" style="display: none;">
</div>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate>
        <div id="divradcust" style="display: block; position: absolute; border: 0px solid;
            left: 20%; top: 45%; z-index: 100; width: 100%" align="center">
            <UC:Loading ID="ucLoadinggrid" runat="server" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<div id="div_Content" align="left" style="width: 100%">
   
    <div>
        <%--class="borderWithoutTop"--%>
        <div>
            <%--id="padding"--%>
            <div id="div_MainInv" runat="server" align="left" style="width: 100%">
                <div id="div_Grid" class="gridborder">
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <div id="a" style="padding-bottom: 10px; padding-left: 1px;">
                                <asp:LinkButton ID="btnInvclrFilters" Style="text-decoration: underline; cursor: pointer"
                                    runat="server" OnClick="InvclrFilters_Click"><%=objlang.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                            </div>
                            <telerik:RadGrid ID="GridInventory" runat="server" AllowPaging="true" PageSize="50"
                                AllowSorting="true" AllowFilteringByColumn="true" ShowStatusBar="true" Visible="true"
                                Width="99%" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left"
                                ShowHeader="true" PagerStyle-AlwaysVisible="true" OnItemDataBound="GridInventory_OnRowDataBound"
                                OnNeedDataSource="GridBindInv_OnNeedDataSource" GroupingSettings-CaseSensitive="false">
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView DataKeyNames="DeliveryCostID" OverrideDataSourceControlSorting="true"
                                    AllowFilteringByColumn="true" CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <div id="DivbtnAddNewRecord" runat="server">
                                            
                                        </div>
                                    </CommandItemTemplate>
                                    <%-- ItemTemplate change by Jagat--%>
                                    <Columns>
                                        <telerik:GridTemplateColumn AllowFiltering="true" HeaderStyle-Width="10%" AutoPostBackOnFilter="true"
                                            ItemStyle-Width="10%" DataField="Type" UniqueName="Type" SortExpression="Type"
                                            CurrentFilterFunction="Contains">
                                            <ItemTemplate>
                                                <a title='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>'
                                                    href="#" id='lnkInvCode' onclick="javascript:setpaperid('<%#Eval("DeliveryCostID")%>','<%#objBase.SpecialEncode((string)Eval("DeliveryCostTitle"))%>','<%#Eval("Formula") %>','<%#Eval("Type") %>');TimerToClose();return false;">
                                                    <%# objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>
                                                </a>
                                                <asp:Label ID="lblInvID" runat="server" Text='<%#Eval("DeliveryCostID")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="10%" HeaderText="Name" ItemStyle-Width="10%"
                                            AutoPostBackOnFilter="true" DataField="DeliveryCostTitle" SortExpression="DeliveryCostTitle"
                                            UniqueName="DeliveryCostTitle" CurrentFilterFunction="Contains">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; width: 200px">
                                                    <a title='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>'
                                                        style="display: none" href="#" id='<%#Eval("DeliveryCostID")%>' onclick="javascript:setpaperid(this.id,this.innerHTML,'<%#Eval("Formula") %>','<%#Eval("type") %>');">
                                                        <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>
                                                    </a>
                                                    <asp:LinkButton ID="lnkInvName1" runat="server" ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Formula","{0}"))%>'
                                                        Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Formula","{0}"))%>'
                                                        OnClientClick="javascript:setpaperid('<%#Eval('DeliveryCostID')%>','<%#objBase.SpecialEncode((string)Eval('DeliveryCostTitle'))%>','<%#Eval('Formula') %>');TimerToClose();return false;"></asp:LinkButton>
                                                    <asp:HiddenField ID="hid_InventoryID" runat="server" Value='<%#Eval("DeliveryCostID") %>' />
                                                    <asp:Label ID="lblInvName" runat="server" Text='<%#Eval("DeliveryCostTitle")%>' Visible="false"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="10%" DataField="CompanyID" AutoPostBackOnFilter="true"
                                            ItemStyle-Width="10%" UniqueName="CompanyID" SortExpression="CompanyID" AllowFiltering="true"
                                            CurrentFilterFunction="EqualTo">
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden">
                                                    <a title='<%#Eval("DeliveryCostID")%>' href="#" id='lnkInvCode' onclick="javascript:setpaperid('<%#Eval("DeliveryCostID")%>','<%#objBase.SpecialEncode((string)Eval("DeliveryCostTitle"))%>','<%#Eval("Formula") %>','<%#Eval("type") %>');TimerToClose();return false;">
                                                        <asp:Label ID="lblInvWeightSize" runat="server" Text='<%#Eval("Type")%>'></asp:Label>

                                                        <asp:Label ID="lblPaperSize" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                        <asp:HiddenField ID="hid_Height" runat="server" Value='<%#Eval("Type")%>' />
                                                        <asp:HiddenField ID="hid_Width" runat="server" Value="" />
                                                        <asp:HiddenField ID="hid_Length" runat="server" Value="" />
                                                        <asp:HiddenField ID="hid_WidthType" runat="server" Value="" />
                                                        <asp:HiddenField ID="hid_LengthType" runat="server" Value="" />
                                                        <asp:HiddenField ID="hid_PaperType" runat="server" Value='<%#Eval("Formula") %>' />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        
                                    </Columns>
                                    <%--End--%>
                                    <NoRecordsTemplate>
                                        <div style="padding: 0px 0px 0px 10px">
                                            <%=objlang.GetLanguageConversion("No_records_To_Display") %>
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div id="div_MainInk" runat="server" align="left" style="width: 100%">
                <div id="a1">
                </div>
                <div id="div_Grid1" class="gridborder">
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadGrid ID="GridInk" runat="server" AllowPaging="true" ShowStatusBar="true"
                                AllowFilteringByColumn="true" Visible="true" Width="99%" HeaderStyle-Font-Bold="true"
                                AutoGenerateColumns="false" AllowSorting="true" HeaderStyle-HorizontalAlign="Left"
                                ShowHeader="true" PagerStyle-AlwaysVisible="true" OnNeedDataSource="GridBindInk_OnNeedDataSource"
                                OnItemDataBound="GridInk_OnRowDataBound" PageSize="50">
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView DataKeyNames="DeliveryCostID" OverrideDataSourceControlSorting="true"
                                    AllowFilteringByColumn="true" CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <div id="DivAddNewPlate" runat="server">
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button runat="server" OnClientClick="javascript:ShowInvAddDiv();return false;"
                                                            ID="btnAddNewInk" class="rgAdd" />
                                                        <%--   LinkButton Add by Jagat On 24/July/2012--%>
                                                        <%-- <a href="#" onclick="javascript:ShowInvAddDiv();return false;" id="lblAddNew" runat="server">
                                                Add New Platej</a>--%>
                                                        <asp:LinkButton ID="lnkAddNew" OnClientClick="ShowInvAddDiv();return false;" runat="server"></asp:LinkButton>
                                                        <asp:HiddenField ID="hidtxtSearch" runat="server" />
                                                    </td>
                                                    <td align="right">
                                                        <%-- <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer"
                                                runat="server" Text='<%#objlang.GetValueOnLang("Clear All Filtersj")%>' OnClick="InkclrFilters_Click" />--%>
                                                        <asp:LinkButton ID="btnInkclrFilters" Style="text-decoration: underline; cursor: pointer"
                                                            runat="server" Text="Clear All Filter" OnClick="InkclrFilters_Click"><%=objlang.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                        <%--OnClick="clrFilters_Click" --%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <%-- Change ItemTemplate By Jagat on 23/July/2012--%>
                                        <telerik:GridTemplateColumn DataField="FromShipEngine" UniqueName="FromShipEngine"
                                            DataType="System.String" SortExpression="FromShipEngine" AllowFiltering="true"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                            <ItemStyle Width="40%" />
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="lnkInkName" runat="server" Text='<%#Eval("FromShipEngine")%>'
                                                        OnClientClick="javascript:setvalue(''); return false;"></asp:LinkButton>--%>
                                                <a href="#" id='<%#Eval("DeliveryCostID")%>' style="display: none" onclick="setvalue(this.id,this.innerHTML,'')">
                                                    <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>
                                                </a>
                                                <asp:LinkButton ID="lnkInvName1" runat="server" ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>'
                                                    Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>'></asp:LinkButton>
                                                <asp:Label ID="lblInvName" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.DeliveryCostTitle","{0}"))%>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblInkID" runat="server" Text='<%#Eval("DeliveryCostID")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%-- <a title='<%#Eval("Type")%>' href="#" id='lnkInvCode' onclick="javascript:setpaperid('<%#Eval("DeliveryCostID")%>','<%#Eval("DeliveryCostTitle")%>','<%#Eval("Formula") %>');TimerToClose();return false;">--%>
                                        <telerik:GridTemplateColumn DataField="Description" UniqueName="Description" DataType="System.String"
                                            SortExpression="Description" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains">
                                            <ItemStyle Width="40%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDescription" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Description","{0}"))%>'>
                                                </asp:LinkButton>
                                                <%--  <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="PackedIn" UniqueName="PackedIn" SortExpression="PackedIn"
                                            AllowFiltering="true">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <div style="overflow: hidden; width: 90px; cursor: pointer;">
                                                    <asp:LinkButton ID="lnkPackQty" runat="server" Text='<%#Eval("PackedIn")%>'>
                                                    </asp:LinkButton>
                                                    <%--   <asp:Label ID="lblInkPackQty" Text='<%Eval("PackedIn")%>' runat="server"></asp:Label>--%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="PackedPrice" UniqueName="PackedPrice" SortExpression="PackedPrice"
                                            AllowFiltering="true" AutoPostBackOnFilter="true">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <div style="overflow: hidden; width: 90px;">
                                                    <%-- <a href="#" id='<%#Eval("InventoDeliveryCostIDryID")%>' onclick="javascript:setplatesid('<%#Eval("DeliveryCostID")%>','<%#Eval("DeliveryCostTitle")%>');TimerToClose();return false;">
                                                <asp:Label ID="lblInkPackPrice" Text='<%(PackedPrice)%>' runat="server"></asp:Label>
                                            </a>--%>
                                                    <asp:LinkButton ID="lnkPackPrice" runat="server" Text='<%(PackedPrice)%>'>
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--End--%>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <div style="padding: 0px 0px 0px 10px">
                                            No records found
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                    <ClientEvents />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div style="clear: both; padding-top: 10px">
        </div>
    </div>

</div>
<div align="left" id="div_InventoryAdd" style="width: 96%; display: none;">
    <UC:InventoryAdd ID="UCInventory_Add" runat="server" />

</div>
<div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
    display: none">
    <div id="div_test_2" style="width: 100%; border: solid 1px red;">
        Loading...</div>
</div>
<asp:HiddenField ID="hidGridCount" runat="server" Value="" />

<script type="text/javascript">

    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");   
</script>
<script type="text/javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender;
        var items = menu.get_items();

        if (column.get_dataType() == "System.String") {
            var i = 0;

            while (i < items.get_count() - 1) {
                if (items.getItem(i).get_value() in { 'GreaterThan': '', 'GreaterThanOrEqualTo': '', 'LessThan': '', 'LessThanOrEqualTo': '' }) {
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
    }

    function filterMenuShowing(sender, eventArgs) {
        column = eventArgs.get_column();
    }
</script>
<script type="text/javascript">

    function setvalue(id, val) {
        if ('<%=IsColororwhiteink %>'.toLowerCase() == 'white') {
            var lbl = "spnwhiteInk" + '<%=inkid %>';
            var hdn = "hdnwhiteInk" + '<%=inkid %>';
            var img = "imgwhiteInk" + '<%=inkid %>';


            var val1 = trim12(val);
            val1 = val1.length > 25 ? val1 = val1.substring(0, 25) + '...' : val1;
            pw.document.getElementById(lbl).title = SpecialDecode(val);

            pw.document.getElementById(lbl).innerHTML = SpecialDecode(val1) + "&nbsp;<img style='cursor:pointer'  id='imgwhiteInk" + '<%=inkid %>' + "' alt='Clear this ink' src='<%=strImagepath%>close.gif' onclick=\"clear_ink(this.id,'" + val + "');\"  />";
            pw.document.getElementById(hdn).value = id;

            pw.document.getElementById("spn_whiteInk").style.display = 'none';
        }
        else {
            var lbl = "spn" + '<%=inkid %>';
            var hdn = "hdn" + '<%=inkid %>';
            var img = "img" + '<%=inkid %>';

            var val1 = trim12(val);
            val1 = val1.length > 25 ? val1 = val1.substring(0, 25) + '...' : val1;
            pw.document.getElementById(lbl).title = SpecialDecode(val);

            pw.document.getElementById(lbl).innerHTML = SpecialDecode(val1) + "&nbsp;<img style='cursor:pointer'  id='img" + '<%=inkid %>' + "' alt='Clear this ink' src='<%=strImagepath%>close.gif' onclick=\"clear_ink(this.id,'" + val + "');\"  />";
            pw.document.getElementById(hdn).value = id;

            pw.document.getElementById("spn_ink").style.display = 'none';
        }
        window.close();
    }
    function ShowInvAddDiv() {
        var cattype = '<%=ItemType%>';
        document.getElementById("div_InventoryAdd").style.display = "block";
        document.getElementById("div_Content").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCInventory_Add_txtInvName").focus();
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCInventory_Add_colourPanel").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCInventory_Add_Content").removeAttribute("class");

        for (var i = 0; i < ddlInvCategoryID.length; i++) {
            if (cattype == 'paper') {

                if (ddlInvCategoryID.options[i].text.toLowerCase() == "paper") {
                    ddlInvCategoryID.selectedIndex = i;

                }
            }
            else if (cattype == 'inks') {

                if (ddlInvCategoryID.options[i].text.toLowerCase() == "inks") {
                    ddlInvCategoryID.selectedIndex = i;
                }
            }
            else if (cattype == 'plates') {

                if (ddlInvCategoryID.options[i].text.toLowerCase() == "plates") {
                    ddlInvCategoryID.selectedIndex = i;
                }
            }
        }
        ddlInvCategoryID.disabled = true;
        ShowCategoryWise(ddlInvCategoryID);
        hdn_InvCatID.value = ddlInvCategoryID.value;

        var catval = '<%=CatValue1 %>';
        document.getElementById("div_Load").style.display = "none";
    }


</script>
<asp:Panel ID="pnlAddNewPaper" runat="server" Visible="false">
    <script type="text/javascript">

        var id = '<%=InvID %>';
        var value = '<%=InvName %>';
        if (id != '') {
            if ('<%=AddedItem %>'.toLowerCase() == 'paper') {
                setpaperid(id, value);

            }
            else if ('<%=AddedItem %>'.toLowerCase() == 'ink') {

                setvalue(id, value);
            }
            else {

                setplatesid(id, value);
            }
        }

    </script>
</asp:Panel>
<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>




