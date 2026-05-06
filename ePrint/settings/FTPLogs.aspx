<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="FTPLogs.aspx.cs" Inherits="ePrint.settings.FTPLogs" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgFtpLog">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgFtpLog" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgFtpLog" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <style>
        .clear-link {
            color: blue !important;
            text-decoration: underline !important;
            font-size: 11px !important;
            margin-right: 5px !important;
        }

        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: none;
                margin-left: -9px;
            }

        .RadGrid_Default .rgCommandCell {
            border: none;
        }

        .RadGrid_Default .rgHeader {
            border: 0;
            border-bottom: 1px solid #828282;
        }

        .RadGrid_Default {
            outline: none;
            margin-top: -8px;
            color: black;
        }
        /*.rgNoRecords td {
            text-align: center !important;
            color:black;
        }
      .RadGrid_Eprint_Skin .rgHeader th {
        padding: 12px 20px !important;
    }*/

        /* Pager row background */
        /*.RadGrid_Eprint_Skin .rgPager {
        background-color: #f0f0f0 !important;
        padding: 8px;
    }*/
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 84%; margin-top: -18px" class="mis_header_panel">
            <div style="text-align: right; margin-bottom: 5px;">
                <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                    runat="server"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
            </div>

            <%--  <telerik:RadGrid ID="rgFtpLog" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" PageSize="25" AllowFilteringByColumn="True" ShowHeader="true" EnableEmbeddedSkins="false"
                Skin="RadGrid_Eprint_Skin" GridLines="None" OnNeedDataSource="rgFtpLog_NeedDataSource" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>--%>
            <telerik:RadGrid ID="rgFtpLog" runat="server" AutoGenerateColumns="false"
                BorderWidth="0" OnNeedDataSource="rgFtpLog_NeedDataSource" HeaderStyle-Font-Bold="true"
                PageSize="25" AllowAutomaticInserts="false" AllowPaging="true" PagerStyle-AlwaysVisible="true"
                AllowAutomaticDeletes="false" AllowFilteringByColumn="true">
                <MasterTableView>
                    <Columns>
                      <%--  <telerik:GridBoundColumn DataField="TimeStamp" HeaderText="Time Stamp" UniqueName="TimeStamp"
                            CurrentFilterFunction="Contains" ShowFilterIcon="true" AutoPostBackOnFilter="true" />--%>
                          <telerik:GridBoundColumn DataField="TimeStamp" HeaderText="Time Stamp" UniqueName="TimeStamp"   AllowFiltering="false" />

                        <telerik:GridTemplateColumn HeaderText="Status" UniqueName="Status" AutoPostBackOnFilter="true">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server"
                                    Text='<%# Eval("Status") %>'
                                    ForeColor='<%# Eval("Status").ToString() == "Success" ? System.Drawing.Color.Green : System.Drawing.Color.Red %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="TargetDestination" HeaderText="Target Destination"
                            UniqueName="TargetDestination" CurrentFilterFunction="Contains" ShowFilterIcon="true" AutoPostBackOnFilter="true" />

                        <telerik:GridBoundColumn DataField="FailureReasons" HeaderText="Failure Reasons"
                            UniqueName="FailureReasons" CurrentFilterFunction="Contains" ShowFilterIcon="true" AutoPostBackOnFilter="true" />

                        <telerik:GridBoundColumn DataField="FileName" HeaderText="File Name"
                            UniqueName="FileName" CurrentFilterFunction="Contains" ShowFilterIcon="true" AutoPostBackOnFilter="true" />

                        <telerik:GridTemplateColumn HeaderText="Product Code" UniqueName="ProductCode" AutoPostBackOnFilter="true">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlProduct" runat="server" CssClass="clear-link"
                                    NavigateUrl='<%# this.strSitepath + "/ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=" + Eval("PriceCatalogueID") %>'
                                    Text='<%# Eval("ProductCode") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Order/Estimate No" UniqueName="OrderEstimateNo" AutoPostBackOnFilter="true">
                            <ItemTemplate>
                                <%# 
            Eval("OrderEstimateNo").ToString() == "Direct Job" || Eval("OrderEstimateNo").ToString() == "Direct Invoice" 
            ? Eval("OrderEstimateNo").ToString() 
            : "<a class='clear-link' href='" + 
              (Eval("OrderEstimateNo").ToString().ToLower().Contains("ord") 
                    ? this.strSitepath + "/orders/order_summary.aspx?frm=view&ordid=" + Eval("EstimateID") + "&estid=" + Eval("EstimateID") 
                    : this.strSitepath + "/estimates/estimate_summary_reeng.aspx?estid=" + Eval("EstimateID") + "&EstItemID=" + Eval("EstimateItemID")
              ) + "'>" + Eval("OrderEstimateNo").ToString() + "</a>"
                                %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Job Number" UniqueName="JobNumber" AutoPostBackOnFilter="true">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlJob" runat="server" CssClass="clear-link"
                                    NavigateUrl='<%# (Eval("OrderEstimateNo").ToString().ToLower().Contains("ord") 
                            ?  this.strSitepath + "jobs/job_order_summary.aspx?frm=view&ordid=" + Eval("EstimateID") + "&estid=" + Eval("EstimateID") + "&jID=" + Eval("JobID")  
                            : this.strSitepath + "jobs/job_summary_reeng.aspx?estid=" + Eval("EstimateID") + "&jID=" + Eval("JobID") + "&EstItemID=" + Eval("EstimateItemID")) %>'
                                    Text='<%# Eval("JobNumber") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>

                </MasterTableView>

            </telerik:RadGrid>
        </div>
        <div style="clear: both;">
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
