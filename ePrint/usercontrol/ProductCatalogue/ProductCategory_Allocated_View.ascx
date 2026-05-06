<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategory_Allocated_View.ascx.cs" Inherits="ePrint.usercontrol.ProductCatalogue.ProductCategory_Allocated_View" %>

<%--<%@ control language="C#" autoeventwireup="true" inherits="usercontrol_ProductCatalogue_ProductCategory_Allocated_View, App_Web_productcategory_allocated_view.ascx.263d4c31" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadAjaxManager ID="RadAjaxallocated" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdallocatedcustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server"></telerik:RadAjaxLoadingPanel>--%>
<div style="margin-left:10px" >
<asp:UpdatePanel ID="pnl" runat="server">
<ContentTemplate>
    <telerik:RadGrid ID="grdallocatedcustomer" runat="server" AutoGenerateColumns="false"
        GridLines="None" AllowSorting="true" PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true"
        OnNeedDataSource="grdallocatedcustomer_NeedDataSource" AllowPaging="true" Width="98%"
        AllowFilteringByColumn="true">
        <MasterTableView>
            <Columns>
                <telerik:GridTemplateColumn DataField="ClientName" UniqueName="ClientName" FilterControlWidth="18%"
                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Name")%></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustomer" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.ClientName", "{0}")) %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true">
            <Scrolling UseStaticHeaders="true" ScrollHeight="180" />
        </ClientSettings>
    </telerik:RadGrid>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>