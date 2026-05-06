<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="my_design.aspx.cs" Inherits="ePrint.WebStore.my_design"  enableEventValidation="false" viewStateEncryptionMode="Never" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/cart.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Default.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <style type="text/css">
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        
        .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default
        {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        
        .RadTabStrip_Default .rtsLI, .RadTabStrip_Default .rtsLink
        {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        
        .RadTabStrip .rtsLevel1 .rtsTxt, .RadTabStripVertical .rtsLevel1 .rtsTxt
        {
            margin-left: -9px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridMyDesign">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridMyDesign" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="SavedDraft" align="center">
        <div align="center" id="ShoppingcardMain_div">
            <div align="center" id="Shoppingcard_background">
                <div id="ShoppingcardContent_div">
                    <div id="Shoppingcard_div" runat="server">
                        <div id="top_div" class="widthAuto">
                            <div id="heading" class="Header_Background">
                                <strong class="floatLeft DisplayNone">Saved Design</strong> <strong>
                                    <asp:Label ID="LblMessage" Visible="false" CssClass="LblMessage" Text="Item delete successfully from cart"
                                        runat="server"></asp:Label>
                                </strong>
                            </div>
                        </div>
                        <div id="middle_div">
                            <div id="productAdded" class="productAdded DisplayNone" runat="server">
                                <div id="productAdded_image">
                                    <img id="imgSucess" runat="server" alt=" " />
                                </div>
                                <div id="productAdded_sucessMsg">
                                    <asp:Label ID="lblSucess" runat="server" Text=""><%=objLanguage.GetLanguageConversion("No_Items_In_Cart")%></asp:Label>
                                </div>
                            </div>
                            <div class="RadGridMyDesignDiv" style="padding-top:0px; margin-top:-10px;">
                                <telerik:RadGrid ID="RadGridMyDesign" GridLines="none" runat="server" AllowSorting="false"
                                    ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                    AllowFilteringByColumn="false" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                    HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                    ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                    ShowFooter="false" AlternatingItemStyle-BackColor="White" OnNeedDataSource="RadGridMyDesign_OnNeedDataSource"
                                    HeaderStyle-ForeColor="#525252" Skin="Default" HeaderStyle-BorderColor="#000000"
                                    HeaderStyle-Font-Size="13px" HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double"
                                    CssClass="AddBorders RadGridMyDesign_Style">
                                    <AlternatingItemStyle BackColor="White" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                    <%--  <AlternatingItemStyle BackColor="White" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />--%>
                                    <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="false"
                                        HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                        ShowFooter="false" CssClass="MyDesign_GridMasterTable">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-Width="6%" HeaderStyle-Width="6%" ItemStyle-Height="22px">
                                                <ItemTemplate>
                                                    <div id="div_Action">
                                                        <div class="floatLeft">
                                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="deleteBtn" ToolTip="Delete"
                                                                CausesValidation="false" CommandArgument='<%# Eval("CartItemID") %>' CommandName='<%# Eval("CartID") %>'
                                                                OnClientClick="javascript:return Delete()" OnCommand="btnDelete_Click">
                                                            </asp:LinkButton>
                                                        </div>
                                                        <div class="floatLeft paddingLeft5">
                                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="editBtn" Height="15px" Width="15px"
                                                                ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("CartItemID") %>'
                                                                OnCommand="btnEdit_Click"></asp:LinkButton>
                                                        </div>
                                                        <div id="pdfdiv" class="floatLeft paddingLeft5 DisplayBlock">
                                                          <img id="img_Pdf" class='WS_Cursor_Style' src="<%=strSitepath%>ImageHandler.ashx?ImageName=pdf.png&amp;type=r&amp;aid=<%=AccountID %> &amp;cid=<%=CompanyID %>"
                                                                title="Generate Pdf" style="padding-left: 4px;" onclick=javascript:Pdf_Open_Design('ID=<%#Eval("PriceCatalogueID")%>&CartItemID=<%#Eval("CartItemID")%>&TemplateID=<%#Eval("TemplateID")%>&CompanyID=<%=CompanyID %>&PreviewType=<%#Eval("PreviewType") %>') />
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn HeaderText="" UniqueName="CatalogueName" DataField="CatalogueName"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                SortExpression="CatalogueName" ItemStyle-Width="25%" HeaderStyle-Width="25%"
                                                FilterControlWidth="120px" ItemStyle-Height="22px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="" UniqueName="SavedDesignName" DataField="SavedDesignName"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                SortExpression="SavedDesignName" ItemStyle-Width="25%" HeaderStyle-Width="25%"
                                                FilterControlWidth="120px" ItemStyle-Height="22px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn SortExpression="UnitPrice" HeaderStyle-Width="14%" ItemStyle-Width="14%"
                                                UniqueName="UnitPrice" DataField="UnitPrice" DataFormatString="{0:###,##0.00}"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                ItemStyle-Height="22px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="" UniqueName="Quantity" DataField="Quantity"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                SortExpression="Quantity" ItemStyle-Width="13%" HeaderStyle-Width="13%" ItemStyle-Height="22px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn SortExpression="CartTotalPrice" HeaderStyle-Width="14%"
                                                ItemStyle-Width="14%" UniqueName="CartTotalPrice" DataField="CartTotalPrice"
                                                DataFormatString="{0:###,##0.00}" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right"
                                                HeaderStyle-HorizontalAlign="Right" AllowFiltering="false" ItemStyle-Height="22px">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <div id="div_NoRecords">
                                                No records found</div>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID %>';
        var CompanyID = '<%=CompanyID %>';
        var strSitepath = '<%=strSitepath%>';        
    </script>
</asp:Content>
