<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="order_summary.ascx.cs" Inherits="ePrint.usercontrol.orders.order_summary" %>




<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagName="OthercostItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_othercost_item.ascx" %>
<%@ Register TagName="SingleItem" TagPrefix="UC" Src="~/usercontrol/Orders/order_summary_action.ascx" %>
<%@ Register TagName="PrinorEmailAllandSeletedItems" TagPrefix="UC" Src="~/usercontrol/Item/Item_Summary_PrintEmail_AllandSeletedItems.ascx" %>
<%@ Register TagName="quicklinksItem" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_quicklinks.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%=strSitepath %>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
    var Order_Item_status_updated_successfully = '<%=objLanguage.GetLanguageConversion("Order_Item_status_updated_successfully")%>';
    var Job_order_Item_status_updated_successfully = '<%=objLanguage.GetLanguageConversion("Job_order_Item_status_updated_successfully")%>';
    var Invoice_order_Item_status_updated_successfully = '<%=objLanguage.GetLanguageConversion("Invoice_order_Item_status_updated_successfully")%>';

    var DateFormat = "<%=DateFormat%>";
    var Pgtype = "<%=pg %>";
    var OrderID = "<%=OrderID %>"
    var AccountID = '<%=AccountID %>';
    var CompanyID = '<%=CompanyID %>';
    var EstimateID = '<%=EstimateID %>';
    var module = '<%=Module %>';
    var DateFormat_stage = "<%=DateFormat%>";
    var div_Load = document.getElementById("div_Load");
    var ConvertedToJob = '<%=ConvertedToJob %>';

    setLoadingPositionOfDivMove(div_Load);
</script>
<script type="text/javascript">
    $(function () {
        // Tabs

        $('#tabs').tabs();
        $('#tabs').tabs('select', '#tabs-2');

        var url = window.location.href;
        if (url.indexOf("orders/order_summary.aspx") != -1) {
            $("#accordion").accordion({
                header: "h3", collapsible: true, autoHeight: false, active: "h3:last"
            });

            $("#accordion #spnStatus").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });

            $("#accordion #spnStatusItems").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
        }
        else {
            $("#accordion").accordion({
                header: "h3", collapsible: true, autoHeight: false
            });

            $("#accordion #spnStatus").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
            $("#accordion #spnStatusItems").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
        }
        document.getElementById("tabs").style.visibility = 'visible';

    });
</script>
<div align="left" style="width: 100%;">
    <div align="center" style="float: left; margin-left: 40%;">
        <asp:Label ID="lblStatusUpdateMsg" runat="server" CssClass="msg-success" Text="Status updated successfully"
            Style="display: none; text-align: left;"></asp:Label>
    </div>
    <div style="clear: both;">
    </div>
    <div align="left">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <div style="padding: 5px; width: 99%">
                        <div id="tabs" class="ui-tabs" style="width: 100%; border: solid 0px red; visibility: hidden">
                            <ul style="margin: 0; padding: 0 0 0 0px; list-style: none; height: auto; width: 99.5%">
                                <li><a href="#tabs-1"><b>
                                    <%=objLanguage.GetLanguageConversion("Customer_Details")%></b></a></li>
                                <li><a href="#tabs-2"><b></b>
                                    <%=objLanguage.GetLanguageConversion("Order_Summary_Details")%></b></a></li>
                                <li style="width: 40%"></li>
                                <li style="width: 30%"></li>
                            </ul>
                            <div id="tabs-1" class="ui-tabs-hide" style="width: 99%; padding: 8px 4px 0px 3px;
                                margin: 0px">
                                <div style="border: solid 1px #BDBDBD; width: 99%; padding: 5px 3px 5px 5px">
                                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                        <ContentTemplate>
                                            <table align="center" width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div id="tabs-2" style="width: 100%; padding: 4px 0px 0px 3px; margin: 0px;">
                                <div id='accordion' style='width: 100%; padding: 0px; margin: 0px'>
                                    <div style="width: 100%; margin-top: 5px;">
                                        <h3>
                                            <a style="border-bottom-width: 0px;" href='#'>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="padding-left: 16px;">
                                                            <asp:Label ID="lblText" Text="Customer Details" runat="server" CssClass="HeaderText"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; text-align: left;">
                                                                <asp:Label ID="LblCompanytxt" runat="server" Font-Bold="true"><%=objLanguage.GetLanguageConversion("Company")%>: </asp:Label>
                                                                <asp:Label ID="LblCompanyName" runat="server" Font-Bold="false"></asp:Label>
                                                                <asp:Label ID="lblOrderNOText" runat="server" Font-Bold="true" Style="padding-left: 30px;"
                                                                    Text="Order Number: "></asp:Label>
                                                                <asp:Label ID="lblOrderNo" runat="server" Font-Bold="false"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td align="left" width="38%">
                                                            <div style="float: left; padding-left: 13%">
                                                                <asp:Label ID="lbl_StatusText" runat="server" Font-Bold="true" Text="Order Status"></asp:Label></div>
                                                            <div style="float: left; padding-left: 5px; margin-top: -1px;">
                                                                <span id="spnStatus">
                                                                    <asp:DropDownList ID="ddlStatus" CssClass="normaltext" runat="server" Width="165px"
                                                                        Height="18px" onchange="javascript:SaveOrderStatus(this.value);return false;">
                                                                    </asp:DropDownList>
                                                                </span>
                                                                <asp:Label runat="server" ID="lblInvoicestatus" Visible="false"></asp:Label>
                                                                <asp:HiddenField ID="hdn_OrderStatusID" runat="server" Value="0" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </a>
                                        </h3>
                                        <div style="padding: 5px; margin: 0px;">
                                            <table style="width: 100%;" cellspacing="0" border="0">
                                                <tr>
                                                    <td valign="top" style="width: 12%;">
                                                    <asp:PlaceHolder ID="plhdetailsqicklinks" runat="server"></asp:PlaceHolder>
                                                        <div id="divJobCust" runat="server" style="display: none;">
                                                            <div id="activity">
                                                                <div id="activity-header">
                                                                    <%=objLanguage.GetLanguageConversion("Quick_Links")%></div>
                                                                <asp:PlaceHolder ID="plhjobLeftPanel" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td valign="top">
                                                        <div id="Div2" style="border: 0px solid red;">
                                                            <div style="padding: 5px; margin: 0px;">
                                                                <table style="width: 100%;" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div id="Div_CustomerDetails" style="border: 0px solid red;">
                                                                                <table style="width: 99%;" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <div id="Div1" style="border: 0px solid red;">
                                                                                                <div style="float: left; width: 49%;">
                                                                                                    <div align="left" style="padding: 2px 0px 2px 2px; width: 49%; float: left">
                                                                                                        <span id="spnEstInfoHeader" class="HeaderText" style='color: #751717'>
                                                                                                            <%=objLanguage.GetLanguageConversion("Ordered_Customer_Detail") %>
                                                                                                        </span>
                                                                                                    </div>
                                                                                                    <div class="bglabel">
                                                                                                        <span class="normalText">
                                                                                                            <%=objLanguage.GetLanguageConversion("Customer")%></span>
                                                                                                    </div>
                                                                                                    <div class="box" style="margin-left: 20px;">
                                                                                                        <asp:Label ID="lblCustomerName" CssClass="normalText" runat="server"></asp:Label>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Ordered_For")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblAttention" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span9">
                                                                                                                <%=objLanguage.GetLanguageConversion("Ordered_By")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblorderedby" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Department")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblCompany" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="div_costcentre" runat="server" style="display: none" align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Cost_Centre")%>
                                                                                                            </span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblcostcentre" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Company_Email")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblCompanyEmail" runat="server" CssClass="normalText"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" runat="server" id="Span4">
                                                                                                                <%=objLanguage.GetLanguageConversion("Contact_Phone")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblContactPhone" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span5">
                                                                                                                <%=objLanguage.GetLanguageConversion("Contact_Email")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblContactEmail" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Greeting")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblGreeting" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Sales_Person")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblSalePerson" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Contact_Address")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblAddress" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_DeliveryAddress" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Delivery_Address")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblDeliveryAddress" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_InvoiceAddress" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Invoice_Address")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblInvoiceAddress" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" style="display: none;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">Estimator</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblEstimator" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_InvoiceDate" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span6">Invoice Date</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblInvoiceDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div style="float: right; width: 49%; border: 0px solid red;">
                                                                                                    <div id="divOrderTitle" align="left" style="display: block;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" runat="server" id="spntitle">Order Title</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblEstimateTitle" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="div_eStore" runat="server" align="left" style="display: block;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" runat="server" id="spnNo">Order Number</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblEstimateNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="Div_CustomerOrdrNo" runat="server" align="left" style="display: block;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" runat="server" id="Spn_CustomerOrderNo">
                                                                                                                <%=objLanguage.GetLanguageConversion("Customer_Order_Number")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lbl_CustomerOrderNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="divPaymentType" align="left" style="display: none;">
                                                                                                        <div class="bglabel">
                                                                                                            <asp:Label ID="Label2" runat="server" Text="Payment Type" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Payment_Type")%></asp:Label>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblPaymentType1" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="IddivIspaid" runat="server" align="left" visible="false">
                                                                                                        <div class="bglabel">
                                                                                                            <div style="float: left;">
                                                                                                                <asp:Label ID="Label20" runat="server" Text="Invoice Paid" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Invoice_Paid")%></asp:Label>
                                                                                                            </div>
                                                                                                            <div style="float: right">
                                                                                                                <asp:ImageButton Style="vertical-align: middle" ID="Hyperlink_PaymentDetails" runat="server"
                                                                                                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Yes" Visible="false">
                                                                                                                </asp:ImageButton>
                                                                                                                <asp:ImageButton Style="vertical-align: middle" ID="ChengePaymentMode" runat="server"
                                                                                                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="No" Visible="false">
                                                                                                                </asp:ImageButton>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px">
                                                                                                            <asp:Label ID="lblIspaid" runat="server" CssClass="normalText"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="divOrderIspaid" runat="server" align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <div style="float: left">
                                                                                                                <asp:Label ID="lblpaymenttypenew" runat="server" Text="Payment Type" CssClass="normalText"></asp:Label>
                                                                                                            </div>
                                                                                                            <div style="float: right; cursor: pointer;">
                                                                                                                <img id="imgBtn_PaymentDetails" runat="server" src="~/images/plus.gif" style="display: none"
                                                                                                                    onclick="javascript:return OpenPaidInvoice('webstore');" /><%--onclick="javascript:return PaymentDetails('order');" --%>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px">
                                                                                                            <asp:Label ID="lblPaymentType" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_InvNumber" runat="server" style="display: none;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span8">
                                                                                                                <%=objLanguage.GetLanguageConversion("Invoice_Number") %></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <span id="lnkProformaInvoice" runat="server"><a target="_blank" href="<%=strSitepath %>invoice/invoice_order_summary.aspx?frm=view&estid=<%=EstimateID %>&ordid=<%=EstimateID %>">
                                                                                                                <span id="spnProInvNo" runat="server"></span></a></span><a id="lnkProformaInvoiceInvDel"
                                                                                                                    runat="server" onclick="alert('This Invoice is deleted hence you cannot view this Invoice');">
                                                                                                                    <span id="spnProInvNoInvDele" runat="server"></span></a>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="div_JobNo" runat="server" align="left" style="display: none">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" runat="server" id="spnOrdJob">Job No.</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblJobNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="divHeader" runat="server">
                                                                                                        <div align="left">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText">Header</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblHeader" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div align="left">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText">Footer</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblFooter" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_orderDateNew">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="spnDate">Ordered Date</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblEstimateDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_InvoiceDueDate" style="display: none" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span7">
                                                                                                                <%=objLanguage.GetLanguageConversion("Invoice_DueDate")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblInvoiceDueDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_DeliveryDate" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span3">Delivery Date</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblDeliveryDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_estimatedartwork" runat="server" style="display: none;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">Order Artwork</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblestimatedartwork" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_estimateddelivery" runat="server" style="display: none;">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">Order Delivery</span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblestimateddelivery" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="div_account" align="left">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText">
                                                                                                                <%=objLanguage.GetLanguageConversion("Account_Number")%></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblAccountNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div align="left" id="div_Comments" runat="server">
                                                                                                        <div class="bglabel">
                                                                                                            <span class="normalText" id="Span1">
                                                                                                                <%=objLanguage.GetLanguageConversion("Comments") %></span>
                                                                                                        </div>
                                                                                                        <div class="box" style="margin-left: 20px;">
                                                                                                            <asp:Label ID="lblComments" CssClass="normalText" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="divEstInfoDetail" align="right" style="width: 100%; padding: 0px 5px 5px 0px;
                                                                                                    display: block;">
                                                                                                    <div align="left" style="float: right; width: 50.7%;">
                                                                                                        <div id="CompletionDate" style="display: none">
                                                                                                            <div align="left">
                                                                                                                <div class="bglabel">
                                                                                                                    <span class="normalText">Job Progressed On</span>
                                                                                                                </div>
                                                                                                                <div class="box" style="margin-left: 20px;">
                                                                                                                    <asp:Label ID="lblProgressedOn" CssClass="normalText" runat="server"></asp:Label>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <div align="left">
                                                                                                                <div class="bglabel">
                                                                                                                    <span class="normalText" id="Span2">Completion Date</span>
                                                                                                                </div>
                                                                                                                <div class="box" style="margin-left: 20px;">
                                                                                                                    <asp:Label ID="lblCompletionDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div style="float: right; width: 49%">
                                                                                                        <div id="divinv_job" runat="server" align="left" style="display: none; border: 0px solid red;">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText" runat="server" id="snninv_job">Job No.</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblinv_job" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div style="clear: both;">
                                                                                                        </div>
                                                                                                        <div id="div_InvNo" runat="server" align="left" style="display: none;">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText" runat="server" id="spnInvoice">Invoice No.</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblInvoiceNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div id="div_ordAccountNo" align="left" style="display: none; border: 1px solid green;">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText">Account Number</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblordAccountNo" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div align="left" id="div_JobDeliveryDate" runat="server" style="padding-left: 22px;"
                                                                                                            visible="false">
                                                                                                            <div class="bglabel">
                                                                                                                <span class="normalText">Delivery Date</span>
                                                                                                            </div>
                                                                                                            <div class="box" style="margin-left: 20px;">
                                                                                                                <asp:Label ID="lblJobDeliveryDate" CssClass="normalText" runat="server"></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="only5px">
                                                                                                </div>
                                                                                                <div align="left" style="width: 100%; padding: 5px; border: 0px solid red">
                                                                                                    <table width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td width="49%">
                                                                                                            </td>
                                                                                                            <td valign="top">
                                                                                                                <div style="float: left; padding-top: 1px;">
                                                                                                                    <asp:PlaceHolder ID="plhcrmbuttons" runat="server"></asp:PlaceHolder>
                                                                                                                </div>
                                                                                                                <div style="float: left;">
                                                                                                                    <asp:PlaceHolder ID="plhcrmbuttons1" runat="server"></asp:PlaceHolder>
                                                                                                                </div>
                                                                                                                <div style="float: left;">
                                                                                                                    <asp:Button ID="btnEstSummary" Visible="false" CssClass="button" runat="server" Text="Summary"
                                                                                                                        OnClientClick="javascript:showSummaryDetail('summary','estinfo');return false;"
                                                                                                                        Style="display: none" />
                                                                                                                </div>
                                                                                                                <div style="float: left;">
                                                                                                                    <asp:Button ID="btnEstDetail" Visible="false" CssClass="button" runat="server" Text="Detail"
                                                                                                                        OnClientClick="javascript:showSummaryDetail('detail','estinfo'); return false;" />
                                                                                                                </div>
                                                                                                                <div style="float: left; width: 5px">
                                                                                                                    &nbsp;
                                                                                                                </div>
                                                                                                                <%--added by rakshith --%>
                                                                                                                <div style="float: left; margin-left: 18px; display: block;">
                                                                                                                    <div id="div_orderrerun" style="display: block">
                                                                                                                        <asp:Button ID="btnorderrerun" runat="server" CssClass="button" OnClick="btnorderrerun_onclick"
                                                                                                                            OnClientClick="javascript:loadingimage(this.id,'div_orderrerunprocess');" Text="Re-run Order Info" />
                                                                                                                    </div>
                                                                                                                    <div id="div_orderrerunprocess" style="display: none">
                                                                                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div style="float: left; display: none">
                                                                                                                    <asp:Button ID="btn_estimate" runat="server" Text="Re-run Estimate Info" CssClass="button" /><%--OnClick="OnClick_ReRunEstimateInfo"--%>
                                                                                                                </div>
                                                                                                                <div style="float: left; width: 5px" id="div_rerun_status" runat="server">
                                                                                                                    &nbsp;
                                                                                                                </div>
                                                                                                                <div style="float: left; display: block;" id="divStatusChange">
                                                                                                                </div>
                                                                                                                <div style="float: left; width: 5px">
                                                                                                                    &nbsp;
                                                                                                                </div>
                                                                                                                <div style="float: left;" id="divPostInvoice">
                                                                                                                    <asp:Button runat="server" ID="btn_postinvoice" Visible="false" Text="Lock Invoice"
                                                                                                                        CssClass="button" />
                                                                                                                </div>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <asp:PlaceHolder ID="plhOrderItems" runat="server"></asp:PlaceHolder>
                                    <asp:HiddenField ID="hdnItems" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnPCPath" runat="server" Value="" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both; padding-top: 10px">
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="div_ProgressToJobs" align="left" style="width: 400px; display: none; position: absolute;
    height: auto; z-index: 3000;">
</div>
<telerik:RadWindowManager ID="RadWindowManager3" runat="server">
    <Windows>
        <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" VisibleTitlebar="true"
            VisibleStatusbar="false" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move">
            <ContentTemplate>
                <div style="margin-top: 5px; margin-left: 20px;">
                    <table cellpadding="0" cellspacing="0" width="100%;height:175px">
                        <tr>
                            <td align="center">
                                <div id="divEstItemsList" align="left" style="<%=divEstItemsList_Style%>">
                                    <asp:PlaceHolder ID="plhEstItemsList" runat="server"></asp:PlaceHolder>
                                    <asp:LinkButton ID="lnkNext_SlctedItems" runat="server"></asp:LinkButton>
                                </div>
                                <div id="divPO" align="left" style="<%=divPO_Style%> width: 100%;">
                                    <div style="float: left; padding-top: 6px; margin-left: 15px; margin-bottom: 6px;
                                        width: 90%; display: none;">
                                        <div align="center" style="float: left; padding-top: 6px; margin-bottom: 6px" visible="false">
                                            <asp:Label ID="lbl" runat="server" Text="" Style="font-size: 11px"><b>Select the Order item(s), you want to progress to job</b></asp:Label>
                                        </div>
                                        <div id="div_chkOrderlist" style="display: none;" align="center">
                                            <span id="spn_chkOrderlist" class="spanerrorMsg" style="width: 100%;">Please select
                                                At least 1 Order Item to Progress </span>
                                        </div>
                                        <div class="onlyEmpty">
                                            &nbsp;
                                        </div>
                                        <div align="left" style="width: 100%; border: solid 0px red;">
                                            <div class="bglabel" style="width: 40%; float: left">
                                                <span class="normalText">Order Name</span>
                                            </div>
                                            <div class="box" style="width: 50%;">
                                                <asp:Label ID="lblOrderName" CssClass="normalText" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:PlaceHolder ID="plhProgrssChk_list" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div align="left" id="div_RaiseDelivery" runat="server">
                                        <div class="bglabel" style="border: 0px solid green; width: 40%;">
                                            <asp:Label ID="Label69" runat="server" Text="Raise Delivery Note" CssClass="normaltext"></asp:Label></div>
                                        <div class="box">
                                            <asp:CheckBox ID="chkDeliveryNote" runat="server" />
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlPORaise" runat="server">
                                        <div align="left">
                                            <asp:PlaceHolder ID="plhRaisePO" runat="server"></asp:PlaceHolder>
                                        </div>
                                    </asp:Panel>
                                    <div style="width: 100%; height: 20%">
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div align="left" style="width: 100%; height: auto;">
                                        <div style="float: left; width: 42%">
                                            &nbsp;</div>
                                        <div align="center" style="float: left; margin-left: 4px;">
                                            <div id="div_progresstojob" style="display: block">
                                                <asp:Button ID="btnProgrssToJob" runat="server" Text="OK" CssClass="button" OnClick="btnProgrssToJob_OnClick"
                                                    OnClientClick="javascript:var a=Validate_btnProgrssToJob();if(a)loadingimg('div_progresstojob','div_progresstojobprocess');return a;" />
                                                <asp:LinkButton ID="lnkProgrssToJob" runat="server" OnClick="btnProgrssToJob_OnClick"
                                                    Style="display: none;"></asp:LinkButton>
                                            </div>
                                            <div id="div_progresstojobprocess" class="button" align="center" style="width: 27px;
                                                display: none;">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                            &nbsp;
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<div id="Div_Print_Email" style="display: none; position: absolute; vertical-align: middle;
    z-index: 100; width: 30%; height: 40%" align="center">
    <asp:PlaceHolder ID="Plh_PrintandEmail" runat="server"></asp:PlaceHolder>
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="div_CreatePurchase" align="left" style="width: 450px; display: none; position: absolute;
    z-index: 100; height: 210px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <div>
                        <span><b>Create Purchase For Items</b></span>
                    </div>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton6" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideDiv1('close');return false;" />
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
            <td class="popup-middlebg" align="center">
                <asp:Panel ID="pnlcreatePo" runat="server" Height="240">
                    <div align="left" style="width: 100%">
                        <div align="left">
                            <div align="left">
                                <div align="left" style="width: 100%">
                                    <div align="left" style="width: 100%">
                                        <div>
                                            <span id="spn_checkPO" style="display: none; color: Red">Please Select at least 1 Item
                                                to create Purchase Order</span>
                                        </div>
                                        <div style="clear: both">
                                            &nbsp;
                                        </div>
                                        <span id="spnPOCreate" runat="server" style="display: none;">Select the item(s) to create
                                            Purchase Order. If PO is already raised for the supplier, new PO will update for
                                            the existing PO.</span><span runat="server" id="spnNoItemsTocreatePO" style="display: none;">
                                                There are no items remaining for which you haven't already created a Purchase Order.</span>
                                        <div style="float: left; width: 5px">
                                            &nbsp;</div>
                                        <div style="float: left">
                                            <asp:Panel ID="pnlpurchase" runat="server" ScrollBars="Vertical">
                                                <div style="float: left; margin-top: 3px; width: 370px; height: 150px">
                                                    <asp:PlaceHolder ID="plhpurchase" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 100%; height: 30%">
                                <div style="clear: both">
                                    &nbsp;
                                </div>
                            </div>
                            <div style="clear: both">
                                &nbsp;
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; width: 38%">
                                    &nbsp;</div>
                                <div id="div17" style="float: left; margin-left: 4px;">
                                    <asp:Button ID="btnCreatePo" runat="server" Text="Create PO" CssClass="button" OnClientClick="javascript:return ValidateCreateMultiplePo();"
                                        OnClick="Onclick_btnCreatePo" /><%--OnClientClick="javascript:return CreateMultiplePo();"--%>
                                    <asp:HiddenField ID="hidPoCount" runat="server" />
                                    <asp:HiddenField ID="hidPoEnable" runat="server" />
                                    <asp:LinkButton ID="lnkCreatePo" runat="server" OnClick="Onclick_btnCreatePo"></asp:LinkButton>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                </asp:Panel>
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
<div id="divrad" style="display: none; position: absolute; vertical-align: middle;
    border: 0px solid; z-index: 100; width: 50%" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1100" Style="z-index: 31000" Height="600"
        AutoSizeBehaviors="Default" OnClientClose="RadWinClose" Behaviors="Close, Move, Resize,Reload"
        ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<%-- By Natraj, For AccountingCode --%>
<div id="div_Accountcode" style="display: none; position: absolute; vertical-align: middle;
    border: 0px solid; z-index: 100;" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_AccountCode" DestroyOnClose="true"
        Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
        Behaviors="Close" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<div id="Div_Attachment" style="display: none; position: absolute; vertical-align: bottom;
    z-index: 100;" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_Attachment" DestroyOnClose="true"
        Opacity="100" runat="server" Style="z-index: 31000;" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize" ReloadOnShow="true">
    </telerik:RadWindowManager>
</div>
<div id="div_PaidPopup" style="display: none; position: absolute; vertical-align: middle;
    border: 0px solid; z-index: 100; width: 50%" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_PaidPopup" DestroyOnClose="true"
        Opacity="100" runat="server" Width="360" Style="z-index: 31000" Height="380"
        OnClientClose="RadWinClose" Behaviors="Close, Move, Resize,Reload" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<asp:LinkButton ID="lnk_SaveAndStay" runat="server" OnClick="btnStay_Click" Style="display: none;"></asp:LinkButton>
<asp:HiddenField ID="hid_NoofOrdersToProgress" runat="server" Value="" />
<asp:HiddenField ID="hid_NoofOrdersProgressedToJob" runat="server" Value="" />
<asp:HiddenField ID="hid_orderItemIDs" runat="server" Value="" />
<asp:HiddenField ID="hid_EstimateItemIDs" runat="server" Value="" />
<asp:HiddenField ID="hid_delEstimateItemID" runat="server" Value="0" />
<asp:HiddenField ID="hid_delOrderItemID" runat="server" Value="0" />
<asp:HiddenField ID="hid_Po1Count" runat="server" Value="no" />
<asp:HiddenField ID="hdn_stockBackwarehoue" runat="server" Value="no" />
<asp:LinkButton ID="lnkOrdItemDelete" runat="server" OnClick="OnClick_lnkOrdItemDelete"></asp:LinkButton>
<asp:HiddenField ID="hid_OCestItemIDs" runat="server" Value="" />
<asp:HiddenField ID="hid_OtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hdnEstItems" runat="server" />
<asp:HiddenField ID="hdnEstItems_All" runat="server" />
<asp:HiddenField ID="hdnEstItemsSelected" runat="server" />
<asp:HiddenField ID="hdnEstItemsNotSelected" runat="server" />
<script type="text/javascript" language="javascript">
    var lblStatusUpdateMsg = document.getElementById("<%=lblStatusUpdateMsg.ClientID %>");
    var hid_NoofOrdersToProgress = document.getElementById("<%=hid_NoofOrdersToProgress.ClientID %>");
    var hid_orderItemIDs = document.getElementById("<%=hid_orderItemIDs.ClientID %>");
    var hid_NoofOrdersProgressedToJob = document.getElementById("<%=hid_NoofOrdersProgressedToJob.ClientID %>");
    var hid_EstimateItemIDs = document.getElementById("<%=hid_EstimateItemIDs.ClientID %>");
    var hid_OtherCostValues = document.getElementById("<%=hid_OtherCostValues.ClientID %>");
    var lblPaymentType = document.getElementById("<%=lblPaymentType.ClientID %>");
    var spnInvoice = document.getElementById("<%=spnInvoice.ClientID %>");

    var lblInvoiceNo = document.getElementById("<%=lblInvoiceNo.ClientID %>");
    var spnNo = document.getElementById("<%=spnNo.ClientID %>");
    var lblEstimateNo = document.getElementById("<%=lblEstimateNo.ClientID %>");
    var spnOrdJob = document.getElementById("<%=spnOrdJob.ClientID %>");
    var lblJobNo = document.getElementById("<%=lblJobNo.ClientID %>");
    var snninv_job = document.getElementById("<%=snninv_job.ClientID %>");
    var lblinv_job = document.getElementById("<%=lblinv_job.ClientID %>");
    var hid_Po1Count = document.getElementById("<%=hid_Po1Count.ClientID %>");

    var Module = '<%=Module %>';
    var Ispaidenable = '<%=Ispaidenable %>';
    var strSitepath = '<%=strSitepath %>';
    var strSecuresitepath = '<%=strSecuresitepath %>';
    var ServerName = '<%=ServerName %>';

    var OrderPayment = '<%=OrderPayment %>';

    var OrderNo = '<%=OrderNo %>';
    var JobNo = '<%=JobNo %>';
    var InvoiceNo = '<%=InvoiceNo %>';
    var FromeStore = '<%=FromeStore %>';
    var activityhist = '<%=activityhist %>';
    var pagename = '<%=pagename %>';

    //Create PO from job Summary page
    var hidPoEnable = document.getElementById("<%=hidPoEnable.ClientID %>");
    var hidPoCount = document.getElementById("<%=hidPoCount.ClientID %>");
    var btnCreatePo = document.getElementById("<%=btnCreatePo.ClientID %>");

    var hid_delEstimateItemID = document.getElementById("<%=hid_delEstimateItemID.ClientID %>");
    var hid_delOrderItemID = document.getElementById("<%=hid_delOrderItemID.ClientID %>");
    var hdn_stockBackwarehoue = document.getElementById("<%=hdn_stockBackwarehoue.ClientID %>");

    function showSummaryDetail(type, item) {

        if (item == 'estinfo') {
            document.getElementById("divEstInfoSummary").style.display = "block";
            document.getElementById("divEstInfoDetail").style.display = "none";

            if (type == 'summary') {
                document.getElementById("divEstInfoSummary").style.display = "block";
                if (Module == "job") {
                    document.getElementById("spnEstInfoHeader").innerHTML = "Job Information Summary";
                    document.getElementById("<%=IddivIspaid.ClientID %>").style.display = "none";
                }
                else if (Module == "invoice") {
                    document.getElementById("spnEstInfoHeader").innerHTML = "Invoice Information Summary";
                    if (OrderPayment == "yes") {
                        document.getElementById("div_orderDateNew").style.display = "block";
                        document.getElementById("div_InvoiceDate").style.display = "none";
                        document.getElementById("divPaymentType").style.display = "none";
                        document.getElementById("divOrderIspaid").style.display = "block";
                    }
                    else {
                        document.getElementById("div_orderDateNew").style.display = "none";
                        document.getElementById("div_InvoiceDate").style.display = "block";
                        document.getElementById("divPaymentType").style.display = "block";
                        document.getElementById("divOrderIspaid").style.display = "none";
                    }
                }
                else {
                    document.getElementById("<%=IddivIspaid.ClientID %>").style.display = "none";
                    document.getElementById("spnEstInfoHeader").innerHTML = "Order Information Summary";
                    document.getElementById("div_ordAccountNo").style.display = "block";
                    document.getElementById("div_account").style.display = "none";
                }
            document.getElementById("spnEstInfoHeader").style.color = "#000000";
            document.getElementById("divStatusChange").style.display = "block";
                //                if (activityhist == '' && activityhist != "yes") {
            document.getElementById("<%=btnEstDetail.ClientID %>").style.display = "block";
                document.getElementById("<%=btnEstSummary.ClientID %>").style.display = "none";
                //                }

                if (activityhist == 'yes' && FromeStore == 'yes') {
                    document.getElementById("spnEstInfoHeader").innerHTML = "eStore Order Summary";
                }
            }
            else if (type == 'detail') {
                document.getElementById("divEstInfoDetail").style.display = "block";

                if (pagename == "job") {
                    document.getElementById("<%=IddivIspaid.ClientID %>").style.display = "none";
                    document.getElementById("div_orderDateNew").style.display = "block";
                    document.getElementById("div_InvoiceDate").style.display = "none";
                    document.getElementById("spnEstInfoHeader").innerHTML = "Job Information Detail";
                }
                else if (Module == "invoice" || pagename == "inv") {
                    document.getElementById("spnEstInfoHeader").innerHTML = "Invoice Information Detail";
                    if (OrderPayment == "yes") {
                        document.getElementById("div_orderDateNew").style.display = "block";
                        document.getElementById("div_InvoiceDate").style.display = "none";
                        document.getElementById("divPaymentType").style.display = "none";
                        document.getElementById("divOrderIspaid").style.display = "block";
                    }
                    else {
                        document.getElementById("div_orderDateNew").style.display = "none";
                        document.getElementById("div_InvoiceDate").style.display = "block";
                        document.getElementById("divPaymentType").style.display = "block";
                        document.getElementById("divOrderIspaid").style.display = "none";
                    }
                }
                else {
                    document.getElementById("spnEstInfoHeader").innerHTML = "Order Information Detail";
                    document.getElementById("<%=IddivIspaid.ClientID %>").style.display = "none";
                    document.getElementById("div_orderDateNew").style.display = "block";
                    document.getElementById("div_InvoiceDate").style.display = "none";
                    document.getElementById("div_ordAccountNo").style.display = "block";
                    document.getElementById("div_account").style.display = "none";
                }

            document.getElementById("spnEstInfoHeader").style.color = "#751717";
            document.getElementById("divStatusChange").style.display = "block";
                //                if (activityhist == '' && activityhist != "yes") {
            document.getElementById("<%=btnEstSummary.ClientID %>").style.display = "block";
                document.getElementById("<%=btnEstDetail.ClientID %>").style.display = "none";
                //                }

                if (activityhist == 'yes' && FromeStore == 'yes') {
                    document.getElementById("spnEstInfoHeader").innerHTML = "eStore Order Details";
                }
            }
    }
}

// showSummaryDetail("summary", "estinfo"); // to view Detail & Summary Mode.

function Todisplay_JobInfo() {
    if (Module == "job") {
        document.getElementById("spnDate").innerHTML = "Job Date";
        spnNo.innerHTML = '<%=objLanguage.GetLanguageConversion("Job_Number")%>';
            spnOrdJob.innerHTML = '<%=objLanguage.GetLanguageConversion("Order_Number")%>';
            lblEstimateNo.innerHTML = JobNo;
            lblJobNo.innerHTML = OrderNo;
        }
        else if (Module == "invoice") {
            document.getElementById("spnDate").innerHTML = '<%=objLanguage.GetLanguageConversion("Invoice_Date")%>'
            spnNo.innerHTML = '<%=objLanguage.GetLanguageConversion("Invoice_Number")%>'
            spnOrdJob.innerHTML = '<%=objLanguage.GetLanguageConversion("Job_Number")%>';
            spnInvoice.innerHTML = "Order Number";
            lblEstimateNo.innerHTML = InvoiceNo;
            lblJobNo.innerHTML = JobNo;
            lblInvoiceNo.innerHTML = OrderNo;
            snninv_job.innerHTML = "Job Number";
            lblinv_job.innerHTML = JobNo;
        }
        else if (Module == "webstoreorder") {
            document.getElementById("spnDate").innerHTML = "Ordered Date";
            spnNo.innerHTML = "Order Number";
        }
}
Todisplay_JobInfo();

function OpenMultiDeliveryNote() {
    window.radopen("multiple_delivery_note_new.aspx?page=<%=Module %>&Estid=<%=EstimateID %>&ordid=<%=EstimateID %>", 1100, 500);
        SetRadWindow('divrad', 'divBackGroundNew', '200');

    }

    function ValidateCreateMultiplePo() {
        var POCheckedCount = 0;
        var AddEstimateItemIDs = '';

        if (hidPoCount.value != "0" && hidPoCount.value != "") {
            var MainPoCount = Number(hidPoCount.value) - 1;

            for (var i = 0; i <= Number(MainPoCount) ; i++) {
                var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_PoEstType_" + i + "").innerHTML;
                var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_PoEstItemID_" + i + "").innerHTML;

                var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_chkPo_" + PoEstItemID + "_" + i + "");
                if (chkPo.checked) {
                    POCheckedCount++;
                }
            }

            if (Number(POCheckedCount) == 0) {
                document.getElementById("spn_checkPO").style.display = "block";
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }

    function CreatePurchase() {
        if (hidPoCount.value != "0" && hidPoCount.value != "") {
            if (hidPoCount.value == 1 && !(btnCreatePo.disabled)) {
                var MainPoCount = Number(hidPoCount.value) - 1;
                for (var i = 0; i <= Number(MainPoCount) ; i++) {
                    var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_PoEstType_" + i + "").innerHTML;
                    var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_PoEstItemID_" + i + "").innerHTML;

                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_chkPo_" + PoEstItemID + "_" + i + "");
                    chkPo.checked = true;

                }
                hid_Po1Count.value = "yes";
                __doPostBack('ctl00$ContentPlaceHolder1$UCOrderSummary$lnkCreatePo', '');
            }
            else {
                hid_Po1Count.value = "no";
                var div_CreatePurchase = document.getElementById("div_CreatePurchase");
                showDivPopupCenter('div_CreatePurchase', '210');
            }
        }
    }

    function DeleteOrderItem(EstimateItemID, OrderItemID) {
        if (window.confirm(' Are you sure, you want to delete this Item ?')) {
            hid_delEstimateItemID.value = EstimateItemID;
            hid_delOrderItemID.value = OrderItemID;
            __doPostBack('ctl00$ContentPlaceHolder1$UCOrderSummary$lnkOrdItemDelete', '');
        }
        else {
            hid_delEstimateItemID.value = '';
            hid_delOrderItemID.value = '';
        }
    }
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/order_item_Summary.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">

    document.getElementById("div_Load").style.display = "none";
    document.getElementById("ds00").style.display = "none";

    function ShowAttachments() {
        var Pgtype = "<%=pg %>";
        var OrderID = "<%=OrderID %>"
        if (OrderID != '') {
            var FrmAttachment = "eStore";
        }
        var pagetype = 'general';
        var EstimateID = "<%=EstimateID %>";
        var Rad_Attachment = window.radopen("<%=strSitepath %>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&ordID=" + EstimateID + "&estid=" + EstimateID + "&pg=" + Pgtype + "");
        SetRadWindow_Ver2('Div_Attachment', 'divBackGroundNew');
        if (window.window.screen.width > 1100) {
            if (window.window.screen.height > 450) {
                Rad_Attachment.setSize(1100, 555);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
                else {
                    Rad_Attachment.Center();
                }
            }
        }
        else {
            var screenwidth = window.window.screen.width;
            var screenheight = window.window.screen.height;
            if (window.window.screen.width > 1100 && screenheight > 450) {
                Rad_Attachment.setSize(screenwidth - 200, 550);
                Rad_Attachment.center();
            }
            else if (window.window.screen.width > 800) {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
            }
            else {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                Rad_Attachment.center();
            }
        }
    }

    function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
        var div_Accountcode = document.getElementById(divMaskID);
        var divBackGroundNew = document.getElementById(divBackgroundID);
        if (document.getElementById(divMaskID).style.display == "none") {

            if (navigator.appName != "Microsoft Internet Explorer") {
                setLoadingPositionOfDivCenter_Ver2(Div_Attachment);
            }
            showDivPopupCenter_Ver2(divMaskID);
        }
        else {
            showDivPopupCenter_Ver2(divMaskID);
        }
    }
    var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>");

    function changeButtonStyle() {
        if ((ddlStatus.options[ddlStatus.selectedIndex].text) != "") {
            btnSaveStatus.className = "changeButtonStyle";
        }
    }

    //Accounting Code Selection Popup, 
    function ShowAccountingCode(EstItemID, EstType, EstID) {
        var EstItemID = EstItemID;
        var EstID = '<%=EstimateID %>';
        var RadWindow_AC = window.radopen("<%=nmsCommon.global.sitePath()%>common/AccountingCode.aspx?EstimateID=" + EstID + "&estitemid=" + EstItemID + "&esttype=" + EstType + "");
        SetRadWindow_Ver2('div_Accountcode', 'divBackGroundNew');
        RadWindow_AC.setSize(780, 400);
        RadWindow_AC.center();
    }
    function Send_AccountCode_Value(id, Code, Desc, EstItemID, EstType) {
        var lbl_AccountingCode = document.getElementById("lbl_AccountingCode_" + EstItemID + "");
        var lbl_AccountingCode_desc = document.getElementById("lbl_AccountingCode_desc_" + EstItemID + "");
        var lblaccounthypen = document.getElementById("lblaccounthypen_" + EstItemID + "");
        lbl_AccountingCode.innerHTML = Code;
        lbl_AccountingCode.title = Code;
        lbl_AccountingCode_desc.innerHTML = Desc;
        lbl_AccountingCode_desc.title = Desc;
        lblaccounthypen.innerHTML = "-";
    }

    // Version-2 Popup for Accounting Code, by Natraj on 12.12.2011.
    function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
        var div_Accountcode = document.getElementById(divMaskID);
        var divBackGroundNew = document.getElementById(divBackgroundID);
        if (document.getElementById(divMaskID).style.display == "none") {

            if (navigator.appName != "Microsoft Internet Explorer") {
                setLoadingPositionOfDivCenter_Ver2(div_Accountcode);
            }
            showDivPopupCenter_Ver2(divMaskID);
        }
        else {
            showDivPopupCenter_Ver2(divMaskID);
        }
    }

    function ShowCartAdditional() {
        var pg = '<%=pg %>';
        var EstID = '<%=EstimateID %>';
        var OrderID = "<%=OrderID %>";
        var OrderItemID = '<%=CartOrdrItemID %>';
        //        window.radopen("<%=nmsCommon.global.sitePath()%>common/CartAdditionalOption.aspx?pg=client" + pg + "&estid=" + EstID + "&Ordid=" + OrderID + "", '500', '400');
        window.radopen("<%=nmsCommon.global.sitePath()%>common/CartAdditionalOption.aspx?pg=" + pg + "&estid=" + EstID + "&Ordid=" + EstID + "&OrderItemID=" + OrderItemID + "", null, '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return false;
    }

    function ShowEstItemDescription(EstItemID, EstType, Pagetype) {
        var EstID = '<%=EstimateID %>';
        var Pgtype = "<%=Pgtype %>";
        var From = "Order";
        window.radopen("<%=nmsCommon.global.sitePath()%>estimates/estimate_item_description_on_popup.aspx?type=edit&estid=" + EstID + "&estitemid=" + EstItemID + "&esttype=" + EstType + "&Frmitemdescription=yes" + "&Pagetype=" + Pgtype + "", null, '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return false;
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
    var Module = "<%=Module %>";
    var ManageStockPermission = '<%=ManageStockPermission  %>';
    var StockCancellationType = '<%=StockCancellationType  %>';
    function LoadPageInformation() {
        if (Module == "job") {
            if (pagename == "estore") {
                document.getElementById("<%=spntitle.ClientID%>").innerHTML = "Order Title";
            }
            else {
                document.getElementById("<%=spntitle.ClientID%>").innerHTML = "Job Title";
            }
        }
        else if (Module == "invoice") {
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLanguage.GetLanguageConversion("Invoice_Title")%>'
        }
}
LoadPageInformation();
</script>
<asp:HiddenField ID="hdnDDLMultiple" runat="server" />
<asp:HiddenField ID="hid_MultipleLenght" runat="server" Value='0' />
<asp:HiddenField ID="hid_TotalExTax" runat="server" />
<asp:HiddenField ID="hid_TotalIncTax" runat="server" />
<asp:HiddenField ID="hid_TotalQty" runat="server" />
<asp:HiddenField ID="hdn_lblMultiplePrice" runat="server" />
<asp:HiddenField ID="hdn_TotalPricelbl" runat="server" />
<asp:HiddenField ID="hdn_SelFormulaID" runat="server" />
<asp:HiddenField ID="HdnTab_SellingPrice" runat="server" />
<asp:HiddenField ID="hdnIsPaid" runat="server" />
<asp:HiddenField ID="hdnEstId" runat="server" />
<asp:HiddenField ID="hdnOrderID" runat="server" />
<asp:HiddenField ID="hdnJIcreated" runat="server" />
<div>
    <asp:PlaceHolder ID="plhInvoicePaid" runat="server"></asp:PlaceHolder>
</div>
<script type="text/javascript">
    var hdnDDLMultiple = document.getElementById("<%=hdnDDLMultiple.ClientID %>");
    var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
    var hid_TotalExTax = document.getElementById("<%=hid_TotalExTax.ClientID %>");
    var hid_TotalIncTax = document.getElementById("<%=hid_TotalIncTax.ClientID %>");
    var hid_TotalQty = document.getElementById("<%=hid_TotalQty.ClientID %>");
    var hdn_lblMultiplePrice = document.getElementById("<%=hdn_lblMultiplePrice.ClientID %>");
    var hdnEstItems_All = document.getElementById("<%=hdnEstItems_All.ClientID %>");

    var RdoBtn_All = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_RadWindow1_C_RdoBtn_All");
    var RdoBtn_Selected = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_RadWindow1_C_RdoBtn_Selected");
    var hdnEstItems = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_hdnEstItems");
    var hdnEstItemsSelected = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_hdnEstItemsSelected");
    var hdnEstItemsNotSelected = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_hdnEstItemsNotSelected");

    // Summary Tabs...
    function ShowOrderSummaryDetail(Obj) {
        if (Obj == "ItemSummaryDetail") {
            document.getElementById("ItemSumry").style.color = "red";
            document.getElementById("ItemDetail").style.color = "black";
            document.getElementById("Div_OrderSumryCustInfo").style.display = "none";
            document.getElementById("Div_OrderSumaryDetail").style.display = "block";
        }
        if (Obj == "CustomerDetail") {
            document.getElementById("ItemDetail").style.color = "red";
            document.getElementById("ItemSumry").style.color = "black";
            document.getElementById("Div_OrderSumaryDetail").style.display = "none";
            document.getElementById("Div_OrderSumryCustInfo").style.display = "block";
        }
    }

    function ShowOrderSummaryContent(OrdrItemID, DivContent, ShowDiv, HideDiv) {
        ShowDiv.style.display = "none";
        HideDiv.style.display = "block";
        DivContent.style.display = "block";
    }

    function HideOrderSummaryContent(OrdrItemID, DivContent, ShowDiv, HideDiv) {
        DivContent.style.display = "none";
        ShowDiv.style.display = "block";
        HideDiv.style.display = "none";
    }

    function ShowCartContent(DivContent, ShowDiv, HideDiv) {
        ShowDiv.style.display = "none";
        HideDiv.style.display = "block";
        DivContent.style.display = "block";
    }

    function HideCartContent(DivContent, ShowDiv, HideDiv) {
        DivContent.style.display = "none";
        ShowDiv.style.display = "block";
        HideDiv.style.display = "none";
    }

    // Options view in Summary page.
    function OnClientClicked_RadOption(sender, args) {
        var CtrlID = sender.get_id().replace('Radbtn_Options', 'RCM_Options');
        if (args.IsSplitButtonClick() || !sender.get_commandName()) {
            var currentLocation = $telerik.getLocation(sender.get_element());
            var contextMenu = $find(CtrlID);
            contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
        }
    }

    function ShowTabValue() {
        var HdnTab_SellingPrice = document.getElementById("<%=HdnTab_SellingPrice.ClientID %>");
        document.getElementById("TabSellingPrice").innerHTML = HdnTab_SellingPrice.value;
    }
    ShowTabValue();

    function SeletedOrderStatusID(ObjID) {
        document.getElementById("<%=hdn_OrderStatusID.ClientID%>").value = ObjID;
    }

    function OnClientClicked(sender, args) {
        var cntrlID = sender.get_id().replace('rbtn_Action', 'rcm_ItemOrder');
        if (args.IsSplitButtonClick() || !sender.get_commandName()) {
            var currentLocation = $telerik.getLocation(sender.get_element());
            var contextMenu = $find(cntrlID);
            contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
        }
    }

    var divWidth = document.getElementById("tabs").offsetWidth;
    if (divWidth < 1200) {
        document.getElementById("orderStatus").style.padding = "0 0 0 10px";
        document.getElementById("spn_Quantity").style.padding = "0 0 0 0px";
    }
    else {
        document.getElementById("orderStatus").style.padding = "0 0 0 40px";
    }

    function OpenPaidInvoice(type) {

        var hdnIsPaid = document.getElementById("<%=hdnIsPaid.ClientID %>");
        var hdnEstId = document.getElementById("<%=hdnEstId.ClientID %>");
        var hdnOrderID = document.getElementById("<%=hdnOrderID.ClientID %>");
        var hdnJIcreated = document.getElementById("<%=hdnJIcreated.ClientID %>");

        var url = window.location.href;
        var module;

        if (url.indexOf("invoice_order_summary") != -1) {
            module = "OrderInvoiceSummary";
        }
        if (type != "websotre" && module == "OrderInvoiceSummary") {
            if (hdnIsPaid.value == "0") {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID.value, '500', '400');
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID.value, '500', '400');
            }
        }
        else if (type == 'ijcreated') {
            module = "ojSummary";
            if (hdnIsPaid.value != "") {
                if (hdnIsPaid.value == "0") {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID.value + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, '500', '400');
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID.value + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, '500', '400');
                }
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID.value + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, '500', '400');
            }
        }
        else {
            module = "OrderSummary";
            if (hdnIsPaid.value != "") {
                if (hdnIsPaid.value == "0") {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID.value + "&IsWebStore=1", '500', '400');
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID.value + "&IsWebStore=1", '500', '400');
                }
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId.value + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID.value + "&IsWebStore=1", '500', '400');
            }
        }

    SetRadWindow_Ver2('div_PaidPopup', 'divBackGroundNew');
    RadWindow_Paid.setSize(680, 500);
    RadWindow_Paid.center();
    return false;
}

function loadradwindow() {
    var RadPopupwin;
    RadPopupwin = $find("<%= RadWindow1.ClientID %>");
        RadPopupwin.setSize(530, 260);
        RadPopupwin.show();
    }

    function closeredwindow() {
        RadPopupwin = $find("<%= RadWindow1.ClientID %>");
        RadPopupwin.close();
    }

    function ShowEstItemsList(type) {
        var divEstItemsList_Inner = document.getElementById("divEstItemsList_Inner");

        if (type == 'all') {
            divEstItemsList_Inner.style.display = "none";
            RdoBtn_All.checked = true;
            RdoBtn_Selected.checked = false;
        }
        else {
            divEstItemsList_Inner.style.display = "block";
            RdoBtn_All.checked = false;
            RdoBtn_Selected.checked = true;
        }
    }

    function EstItemListNext() {

        var IDs = hdnEstItems.value.split('»');
        var IDs_all = hdnEstItems_All.value.split('§');

        if (RdoBtn_Selected.checked) {
            var SelectItemsList = "";
            var NotSelectItemsList = "";

            if (hdnEstItems.value != "") {
                var Cnt = 0;
                for (var i = 0; i < IDs.length - 1; i++) {
                    var chk = document.getElementById("chkEstItems_" + IDs[i]);
                    if (chk.checked) {
                        SelectItemsList += IDs[i] + "±";
                        Cnt++;
                    }
                    else {
                        NotSelectItemsList += IDs[i] + "±";
                    }
                }

                if (Cnt == 0) {
                    alert("Please check at least one item");
                    return false;
                }

                for (var j = 0; j < IDs_all.length - 1; j++) {
                    if (SelectItemsList.indexOf(IDs_all[j]) == -1) {
                        document.getElementById("div_PO_" + IDs_all[j]).remove();
                    }
                }

                hdnEstItemsSelected.value = SelectItemsList;
                hdnEstItemsNotSelected.value = NotSelectItemsList;
            }
        }
        else {
            var SelectItemsList = hdnEstItems.value;
            for (var j = 0; j < IDs_all.length - 1; j++) {
                if (SelectItemsList.indexOf(IDs_all[j]) == -1) {
                    document.getElementById("div_PO_" + IDs_all[j]).remove();
                }
            }
            hdnEstItemsSelected.value = SelectItemsList;
        }
        document.getElementById("divEstItemsList").style.display = "none";
        document.getElementById("divPO").style.display = "block";
        //__doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcProgressToJob$lnkNext_SlctedItems', '');
    }

</script>

