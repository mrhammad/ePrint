<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mass_adjustment.ascx.cs" Inherits="ePrint.usercontrol.warehouse.mass_adjustment" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadScriptManager ID="ScriptManager1" runat="server">
</telerik:RadScriptManager>--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridInventory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <%-- <telerik:AjaxSetting AjaxControlID="btnSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnShowAll">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="txtSearch" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
        <%--By Natraj--%>
        <telerik:AjaxSetting AjaxControlID="ddlCategory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnTaxRatesSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<style>
    .RadGrid_Default .rgCommandRow
    {
        background: none;
    }
    .RadGrid_Default .rgCommandRow a
    {
        color: #10357F;
        text-decoration: none;
        margin-left: -8px;
    }
    .RadGrid_Default .rgCommandCell
    {
        border: none;
    }
    .RadGrid_Default .rgHeader
    {
        border: 0;
        border-top: 1px solid #828282;
        border-bottom: 1px solid #828282;
    }
    .RadGrid_Default
    {
        outline: none;
    }
</style>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Winows7" runat="server">
</telerik:RadAjaxLoadingPanel>
<script type="text/javascript">
    var path = "<%=strSitepath %>";
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
</script>
<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<div class="navigatorpanel" style="display: none;">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLangClass.GetLanguageConversion("Settings") %>: <%=objLangClass.GetLanguageConversion("Inventory_Adjustment")%></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>
<div id="">
    <div>
        <div align="left" style="width: 100%;" class="mis_header_panel">
            <div id="">
                <div style="width: 65%;">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <div align="left" style="width: 100%; border: 0px solid">
                        <div style="float: left; width: 300px; border: 0px solid red; margin: 0px 0px 0px 0px">
                            <div class="bglabel" style="width: 100px;">
                                <asp:Label ID="lblSelectCategory" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Select_Category")%></asp:Label>
                            </div>
                            <div class="ddlsetting;" style="margin-left: 3px; border: 0px solid yellow;">
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="normalText" Width="160px"
                                    OnSelectedIndexChanged="OnSelectedIndexChanged_ddlCategory" AutoPostBack="true"
                                    Style="margin-left: 2px;">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="float: left; width: 400px; border: 0px solid green;">
                            <div align="left">
                                <div style="float: left">
                                    <asp:RadioButton ID="rdlChangeInd" runat="server" Text="Change Individually" Checked="true"
                                        GroupName="rdlInvAdjust" onclick="javascript:showQtyPrice();" />
                                </div>
                            </div>
                            <div style="float: left; margin-left: 16px;">
                                <asp:RadioButton ID="rdlChangeAll" runat="server" Text="Change All" onclick="javascript:ShowQtyAll();"
                                    GroupName="rdlInvAdjust" /></div>
                            <div class="only10px">
                            </div>
                            <div id="divChangeAll" align="left" style="padding-left: 172px; width: 400px; display: none;
                                border: 0px solid" nowrap="nowrap">
                                <div style="float: left;">
                                    <%=objLangClass.GetLanguageConversion("Alter_Stock_Quantity")%>
                                </div>
                                <div style="float: left; margin-left: 20px">
                                    <asp:DropDownList ID="ddlChangeAllMinusPlus" runat="server" Style="height: 19px"
                                        onchange="ToggleChangeAll(this.value);">
                                        <asp:ListItem Text="+" Value="plus" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="-" Value="minus"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAlterStock" runat="server" SkinID="textPad" Width="80px" onblur="javascript:SetNumber(this,this.value)"
                                        MaxLength="8" onkeyup="javascript:SetNumber(this,this.value)" onkeychange="javascript:SetNumber(this,this.value)">0</asp:TextBox>
                                </div>
                                <div class="onlyEmpty">
                                    &nbsp;
                                </div>
                                <div style="float: left; border: 0px solid">
                                    <%=objLangClass.GetLanguageConversion("Alter_Cost_Price")%>
                                    <%--(<%=cmns.GetCurrencyinRequiredFormate("", true)%>)--%>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlChangeAllMinusPlusCP" runat="server" Style="height: 19px;
                                        margin-left: 34px;">
                                        <asp:ListItem Text="+" Value="plus" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="-" Value="minus"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAlterCost" runat="server" CssClass="" SkinID="textPad" Width="80px"
                                        onblur="javascript:SetNumber(this,this.value);setFloat(this,this.value);todecimal_function(this,this.value);"
                                        onkeyup="javascript:SetNumber(this,this.value);setFloat(this,this.value);todecimal_function(this,this.value);"
                                        onkeychange="jjavascript:SetNumber(this,this.value);setFloat(this,this.value);todecimal_function(this,this.value);"
                                        MaxLength="12">0.00</asp:TextBox>
                                    <asp:DropDownList ID="ddlcostin" runat="server" Style="height: 19px">
                                        <%--<asp:ListItem Text="%" Value="%" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="$" Value="$"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>
                                <div class="onlyEmpty">
                                    &nbsp;
                                </div>
                                <div style="float: left; border: 0px solid">
                                    <%=objLangClass.GetLanguageConversion("Notes")%>&nbsp;
                                    <asp:TextBox ID="txtChangeAllReasonadjustment" runat="server" SkinID="textPad" TextMode="MultiLine"
                                        Height="35px" Width="125px" Style="text-align: left; margin-left: 95px;" Text="Stock Replenished"></asp:TextBox>
                                </div>
                            </div>
                            <script type="text/javascript">
                                var rdl_ChangeInd = document.getElementById("<%=rdlChangeInd.ClientID %>");
                                var rdl_ChangeAll = document.getElementById("<%=rdlChangeAll.ClientID %>");
                                rdl_ChangeInd.checked = true;
                                function showQtyPrice() {
                                    document.getElementById("divChangeAll").style.display = "none";
                                    var MakeDisable = false;
                                    showQtyPrice_Common(MakeDisable);

                                }
                                function ShowQtyAll() {
                                    document.getElementById("divChangeAll").style.display = "block";
                                    document.getElementById("<%=txtAlterStock.ClientID %>").focus();
                                    var MakeDisable = true;
                                    showQtyPrice_Common(MakeDisable);
                                }
                                function showQtyPrice_Common(para) {
                                    var grid = document.getElementById("<%=GridInventory.ClientID%>");
                                    for (var i = 0; i < grid.rows; i++) {
                                        var inputs = grid.rows[i].getElementsByTagName("input");
                                        for (var j = 0; j < inputs.length; j++) {
                                            if (inputs[j].type == "text") {
                                                inputs[j].disabled = para;
                                            }
                                        }
                                    }
                                }                          
                            </script>
                        </div>
                    </div>
                    <div id="Link" style="float: right; text-align: right; width: 99%; padding-bottom: 1px;
                        padding-right: 35px;">
                        <asp:Panel ID="Pnl_btnclrall" runat="server">
                            <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                cursor: pointer" runat="server"><%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                        </asp:Panel>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" style="width: 100%; border: 0px solid; padding-top: 5px;">
                        <div class="onlyEmpty">
                        </div>
                        <asp:UpdatePanel ID="a1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadGrid Width="1450px" ID="GridInventory" GridLines="None" runat="server"
                                    PagerStyle-AlwaysVisible="true" AllowAutomaticDeletes="True" ShowStatusBar="true"
                                    OnPageIndexChanged="GridInventory_PageIndexChanged" AllowAutomaticInserts="True"
                                    PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True" BorderWidth="0"
                                    OnPageSizeChanged="GridInventory_PageSizeChanged" AutoGenerateColumns="false"
                                    OnItemDataBound="GridInventory_OnRowDataBound" OnNeedDataSource="GridInventory_OnNeedDataSource"
                                    HeaderStyle-Font-Bold="true" AllowMultiRowEdit="true" AllowFilteringByColumn="true">
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <GroupingSettings CaseSensitive ="false" />
                                    <MasterTableView Width="100%" OverrideDataSourceControlSorting="true" DataKeyNames="InventoryID">
                                        <EditItemStyle></EditItemStyle>
                                        <Columns>
                                            <telerik:GridTemplateColumn SortExpression="InventoryName" HeaderStyle-Width="12%"
                                                ItemStyle-Width="12%" UniqueName="InventoryName" DataField="InventoryName" Visible="true"
                                                HeaderStyle-HorizontalAlign="Left" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <div style="float: left; width: 145px; overflow: hidden">
                                                        <asp:Label ID="Label1" runat="server"><%=objLangClass.GetLanguageConversion("Item_Name")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="float: left; overflow: hidden; width: 150px; height: 15px">
                                                        <asp:Label ID="lblInventoryID" runat="server" Visible="false" Text='<%#Eval("InventoryID")%>'></asp:Label>
                                                        <asp:Label ID="lblInventoryPropertyID" runat="server" Visible="false" Text='<%#Eval("InventoryPropertyID")%>'></asp:Label>
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("InventoryName")%>' ToolTip='<%#Eval("InventoryName")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="InventoryCode" UniqueName="InventoryCode"
                                                DataField="InventoryCode" HeaderText="Item Code" CurrentFilterFunction="Contains"
                                                HeaderStyle-Width="11%" ItemStyle-Width="11%" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                AutoPostBackOnFilter="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("InventoryCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="Date" HeaderText="Date" UniqueName="CreatedDate"
                                                HeaderStyle-Width="11%" ItemStyle-Width="11%" CurrentFilterFunction="EqualTo"
                                                DataType="System.DateTime" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                FilterControlWidth="60px" ItemStyle-Wrap="false" DataField="Date" ItemStyle-HorizontalAlign="Left"
                                                AutoPostBackOnFilter="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label></ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-Wrap="true" SortExpression="Description" UniqueName="Description"
                                                DataField="Description" HeaderStyle-Width="13%" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Left"
                                                CurrentFilterFunction="Contains" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                AutoPostBackOnFilter="true">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label2" runat="server"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="width: 98%; overflow: hidden;">
                                                        <div style="width: 230px; overflow: hidden; height: 18px;">
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' ToolTip='<%#Eval("Description")%>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="SupplierName" HeaderText="Supplier" UniqueName="SupplierName"
                                                HeaderStyle-Width="11%" ItemStyle-Width="11%" CurrentFilterFunction="Contains"
                                                DataField="SupplierName" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                ItemStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("SupplierName")%>' ToolTip='<%#Eval("SupplierName")%>'></asp:Label></ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="InStock" HeaderText="In Stock Qty" HeaderStyle-Width="8%"
                                                ItemStyle-Width="8%" UniqueName="InStock" Visible="true" DataField="InStock"
                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblInStock" Text='<%#Eval("InStock") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="cost" HeaderText="Price ($)" HeaderStyle-Width="8%"
                                                ItemStyle-Width="8%" UniqueName="cost" Visible="true" HeaderStyle-HorizontalAlign="Right"
                                                ItemStyle-HorizontalAlign="Right" DataField="cost" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCost" runat="server" Text='<%#Eval("cost")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Alter Stock Qty" AllowFiltering="false" ItemStyle-Width="14%"
                                                HeaderStyle-Width="14%" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden;">
                                                        <asp:DropDownList ID="ddlMinusPlus" runat="server" Style="height: 19px">
                                                            <asp:ListItem Text="+" Value="plus" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="-" Value="minus"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtPerQty" runat="server" Text='0' SkinID="textPad" MaxLength="8"
                                                            Width="70px" onblur="javascript:SetNumber(this,this.value)" Style="text-align: right;"></asp:TextBox>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Notes" HeaderStyle-Width="13%" ItemStyle-Width="13%"
                                                AllowFiltering="false" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtReasonadjustment" runat="server" SkinID="textPad" TextMode="MultiLine"
                                                        Height="35px" Width="125px" Style="text-align: left;" Text="Stock Replenished"></asp:TextBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="AlterPrice" SortExpression="cost" HeaderText="Alter Price($)"
                                                HeaderStyle-Width="14%" AllowFiltering="false" ItemStyle-Width="14%" Visible="true"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="cost">
                                                <ItemTemplate>
                                                    <div style="width: 110%; overflow: hidden;">
                                                        <asp:DropDownList ID="ddlcosttype" runat="server" Style="height: 19px">
                                                            <%--<asp:ListItem Text='$' Value="$" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="%" Value="%"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtCost" runat="server" SkinID="textPad" Text='<%#Eval("cost")%>'
                                                            MaxLength="20" Width="75px" onblur="javascript:todecimal_function(this,this.value);"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true" AllowColumnsReorder="false"
                                        AllowRowsDragDrop="false">
                                        <ClientEvents />
                                        <Scrolling ScrollHeight="380" UseStaticHeaders="true" />
                                        <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                    </ClientSettings>
                                    <FilterMenu OnClientShown="MenuShowing" />
                                    <ValidationSettings EnableValidation="false" />
                                </telerik:RadGrid>
                                <asp:ObjectDataSource ID="odsInventory" runat="server"></asp:ObjectDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="onlyEmpty">
                        </div>
                        <div align="left" style="width: 98%; padding-bottom: 5px; padding-top: 10px">
                            <div style="float: right; padding-right: 2px;">
                                <div style="float: left">
                                    <%-- <asp:Button EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false" CssClass="button"
                                        ID="btnTaxRatesCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />--%>
                                    <div id="div_btnTaxRatesCancel" style="display: block">
                                        <asp:LinkButton CssClass="button" ID="btnTaxRatesCancel" runat="server" Text="Cancel"
                                            CommandName="Cancel" ForeColor="Black" CausesValidation="false" OnClick="btnTaxRatesCancel_OnClick"></asp:LinkButton>
                                    </div>
                                    <div id="div_btnTaxRatesCancelprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;</div>
                                <div style="float: left">
                                    <%-- <asp:Button CssClass="button" CausesValidation="false" ID="btnTaxRatesSave" runat="server"
                                        Text="Save" OnClick="btnTaxRatesSave_OnClick" />--%>
                                    <%-- <asp:LinkButton ID="btnTaxRatesSave" runat="server" OnClick="btnTaxRatesSave_OnClick"
                                        Text="Save" CssClass="button" Width="35px" Height="15px" Style="color: #000000;
                                        text-align: center; font: 11px,Verdana, Arial, Helvetica, sans-serif;
                                        padding-left: 8px; padding-bottom: 4px; padding-right: 8px; text-decoration: none;"></asp:LinkButton>--%><%-- OnClientClick="onclick_btnSave();"--%>
                                    <%--display: inline-block;--%>
                                    <asp:LinkButton ID="btnTaxRatesSave" runat="server" ForeColor="Black" OnClick="btnTaxRatesSave_OnClick"
                                        Text="Save" CssClass="button" Style="text-decoration: none"></asp:LinkButton>
                                </div>
                                <div style="float: left; width: 7%; padding: 2px; display: none">
                                    <a href="#" onclick="javascript:AddMoreItems('new');">Add More</a></div>
                                <div style="float: left; padding: 2px; display: none">
                                    <a href="#" onclick="javascript:DeleteMoreItems();">Remove</a></div>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function setFloat(obj, val) {
        val = parseFloat(val).toFixed(10);
        obj.value = val;

    }
    //Only Grid Refreshing....
    function onclick_btnSave() {
        __doPostBack('ctl00$ContentPlaceHolder1$InvAdjustmentID$lnkSave', '');
        //WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$ContentPlaceHolder1$InvAdjustmentID$lnkSave&quot;, &quot;&quot;, true, &quot;&quot;, &quot;&quot;, false, true))
    }

    function Check_zeros() {
        var txtAlterStock = document.getElementById('<%= txtAlterStock.ClientID%>');
        var txtAlterCost = document.getElementById('<%=txtAlterCost.ClientID %>');
        var rdAll = document.getElementById('<%=rdlChangeAll.ClientID %>');

        if (rdAll.checked == true) {
            if ((txtAlterStock.value == 0) && (txtAlterCost.value == 0)) {
                return window.confirm('You are saving zeros to database... Proceed Anyway?');
            }
        }
    }
</script>
<%--By Natraj--%>
<div style="visibility: hidden;">
    <div class="bglabel" style="width: 30%">
        <asp:Label ID="lblSearch" runat="server" CssClass="normaltext" Text="Search Criteria"></asp:Label>
    </div>
    <div class="box" style="border: 0px solid; width: 65%">
        <div style="float: left">
            <asp:UpdatePanel ID="pnlSearch" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtSearch" SkinID="textPad" runat="server" Width="65%"></asp:TextBox></ContentTemplate>
            </asp:UpdatePanel>
            <asp:RequiredFieldValidator ID="Rfv_txtSearch" ControlToValidate="txtSearch" ErrorMessage="Please enter Text"
                CssClass="errorMsg" Style="float: left; padding-left: 0px; margin-top: -19px;
                margin-left: 190px" runat="server" ForeColor="" Visible="false"></asp:RequiredFieldValidator></div>
        <div class="only5px">
        </div>
        <div style="float: left; padding-left: 0px; border: 0px solid">
            <asp:Button EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false" CssClass="button"
                ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" />
        </div>
        <div style="float: left; width: 5px">
            &nbsp;
        </div>
        <div style="float: left;">
            <asp:Button EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false" CausesValidation="false"
                CssClass="button" ID="btnShowAll" runat="server" Text="Show All Inventory" OnClick="btnShowAll_OnClick"
                Visible="false" />
        </div>
    </div>
</div>
<%--End--%>
<script type="text/javascript">
    var GridItemTitle = document.getElementById("<%=GridInventory.ClientID %>");
    function CallOverflow() {
        SetGridOverflow(GridItemTitle);
    }
    function Toggle(ddlValue, txtID) {

        if (txtID != "") {
            var ids = txtID.split('_');
            var txtReasonadjustment = '';
            var frm = GridItemTitle.getElementsByTagName("textarea");
            for (var i = 0; i <= ids.length - 1; i++) {
                if (i != 6) {
                    txtReasonadjustment = txtReasonadjustment + ids[i] + "_";
                }
                else if (i == 6) {
                    txtReasonadjustment = txtReasonadjustment + "txtReasonadjustment";
                }
            }
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('txtReasonadjustment') != -1) {
                    if (txtReasonadjustment == frm[l].id) {
                        if (ddlValue == "minus") {
                            frm[l].value = "Stock Reduced";
                        }
                        else {
                            frm[l].value = "Stock Replenished";
                        }
                    }
                }
            }
        }
    }

    var ddlChangeAllMinusPlus = document.getElementById("<%=ddlChangeAllMinusPlus.ClientID %>");
    var txtChangeAllReasonadjustment = document.getElementById("<%=txtChangeAllReasonadjustment.ClientID %>");

    function ToggleChangeAll(ddlvalue) {
        if (ddlvalue == 'plus') {
            txtChangeAllReasonadjustment.value = "Stock Replenished";
        }
        else {
            txtChangeAllReasonadjustment.value = "Stock Reduced";
        }
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

</script>
