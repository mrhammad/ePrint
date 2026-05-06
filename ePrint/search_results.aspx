<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="search_results.aspx.cs" Inherits="ePrint.search_results" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/jobs/Job_Search.ascx" TagName="JobSearch" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Estimate/Estimate_Search.ascx" TagName="EstimateSearch"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Orders/Order_Search.ascx" TagName="OrderSearch" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/crm/CRM_Search.ascx" TagName="CRMSearch" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/purchase/PurchaseSearch_General.ascx" TagName="PurchaseSearch"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Delivery/DeliverySearch_General.ascx" TagName="DeliverySearch"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/warehouse/WerhouseSearch_General.ascx" TagName="WareHouseSearch"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Invoice/Invoice_Search.ascx" TagName="InvoiceSearch"
    TagPrefix="UC" %>
<%@ Register Src="~/Proofs/Proof_Search.ascx" TagName="ProofSearch"
    TagPrefix="UC" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="css/RadComboBox_eprintSkin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript" src="<%#strSitepath %>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>--%>
    <script src="js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <link href="css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div id="loadingScreen">
    </div>
    <div>
        <div id="div_searchMain" style="width: 100%; height: auto; border: 0px solid #BDBDBD; margin-left: -11px; margin-top: -16px; padding-bottom: 10px;">
            <div id="div_searchHeader">
                <h3 style="margin-top: 0px; margin-bottom: 0px; color: #000000;">
                    <asp:Label ID="lblSearchResults" runat="server"></asp:Label>
                    <asp:Label ID="lblmodulename" runat="server"></asp:Label></h3>
            </div>
            <div style="padding-left: 22px; color: Gray; padding-top: 4px; padding-bottom: 4px;">
                <asp:Label ID="lblResultsFor" runat="server"></asp:Label><b>
                    <asp:Label ID="lblSearchstring" runat="server"></asp:Label></b>:
            </div>
        </div>
        <div id="accordion">
            <asp:Panel ID="pnlCRM" runat="server" Visible="false">
                <div id="div_CRM" runat="server" class="divGridstyle">
                    <div>
                        <h3 class='HeaderText' style="font-weight: bold">
                            <a href="#">
                                <asp:Label ID="lblCRM" runat="server"></asp:Label>
                                <asp:Label ID="lblCrmrecordfound" runat="server" CssClass="searchrecfoundtext"></asp:Label></a>
                        </h3>
                        <div style="min-height: 250px; height: auto; padding-bottom: 5px; overflow: auto; border-top: 1px solid #AAAAAA;">
                            <div id="tabs" class="ui-tabs" style="width: 100%; border: solid 0px black; margin-left: -12px;">
                                <ul>
                                    <li><a class='HeaderText' href="#tabs-1">
                                        <asp:Label ID="lblCustomer" runat="server"></asp:Label></a></li>
                                    <li><a class='HeaderText' href="#tabs-2">
                                        <asp:Label ID="lblSupplier" runat="server"></asp:Label></a></li>
                                    <li><a class='HeaderText' href="#tabs-3">
                                        <asp:Label ID="lblProspect" runat="server"></asp:Label></a></li>
                                </ul>
                                <div id="tabs-1" class="ui-tabs-hide" style="min-height: 200px; overflow: auto;">
                                    <asp:PlaceHolder ID="plhCRMSearchCustomer" runat="server"></asp:PlaceHolder>
                                </div>
                                <div id="tabs-2" class="ui-tabs-hide" style="min-height: 200px; overflow: auto;">
                                    <asp:PlaceHolder ID="plhCRMSearchSupplier" runat="server"></asp:PlaceHolder>
                                </div>
                                <div id="tabs-3" class="ui-tabs-hide" style="min-height: 200px; overflow: auto;">
                                    <asp:PlaceHolder ID="plhCRMSearchProspect" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlEstimates" runat="server" Visible="false">
                <div id="div_Estimates" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblEstimates" runat="server"></asp:Label>
                            <asp:Label ID="lblEstimateRecfound" runat="server" CssClass="searchrecfoundtext"> </asp:Label></a></h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhEstimateSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlOrders" runat="server" Visible="false">
                <div id="div_Orders" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lbleStoreOrders" runat="server"></asp:Label>
                            <asp:Label ID="lblOrderRecCount" runat="server" CssClass="searchrecfoundtext"></asp:Label></a></h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhOrderSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlJob" runat="server" Visible="false">
                <div id="div_Job" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblJobs" runat="server"></asp:Label>
                            <asp:Label ID="lblJobRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label></a></h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhJobSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlPurchaseorder" runat="server" Visible="false">
                <div id="div_Purchaseorder" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblPurchase" runat="server"></asp:Label>
                            <asp:Label ID="lblPurchaseRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label></a></h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhPurchaseSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlDeliverynote" runat="server" Visible="false">
                <div id="div_Deliverynote" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblDelivery" runat="server"></asp:Label>
                            <asp:Label ID="lblDeliveryRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label></a></h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhDiliverySearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlInvoice" runat="server" Visible="false">
                <div id="div_invoice" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                            <asp:Label ID="lblInvoiceRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label>
                        </a>
                    </h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhInvoiceSearch" runat="server"></asp:PlaceHolder>
                        <%--<UC:InvoiceSearch ID="UCInvoiceSearch" runat="server" />--%>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlWarehouse" runat="server" Visible="false">
                <div id="div_Warehouse" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblWareHouse" runat="server"></asp:Label>
                            <asp:Label ID="lblWarehouseRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label>
                        </a>
                    </h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <%--<UC:WareHouseSearch ID="UCWareHouseSearch" runat="server" />--%>
                        <asp:PlaceHolder ID="plhWareHouseSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlProof" runat="server" Visible="false">
                <div id="div_proof" runat="server" class="divGridstyle">
                    <h3 class='HeaderText' style="font-weight: bold">
                        <a href="#">
                            <asp:Label ID="lblProof" runat="server"></asp:Label>
                            <asp:Label ID="lblProofRecfound" runat="server" CssClass="searchrecfoundtext"></asp:Label>
                        </a>
                    </h3>
                    <div style="min-height: 205px; overflow: auto; border-top: 1px solid #AAAAAA;">
                        <asp:PlaceHolder ID="plhProofSearch" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <style type="text/css">
        #div_searchMain #div_searchHeader {
            height: 25px;
            width: auto;
            padding-left: 2%;
            padding-top: 7px;
            overflow: hidden;
            color: #212121;
            text-decoration: none;
            background: -moz-linear-gradient(top, rgba(224,224,224,1) 0%, rgba(241,241,241,0.6) 50%, rgba(225,225,225,0.59) 51%, rgba(246,246,246,0.2) 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(224,224,224,1)), color-stop(50%,rgba(241,241,241,0.6)), color-stop(51%,rgba(225,225,225,0.59)), color-stop(100%,rgba(246,246,246,0.2))); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, rgba(224,224,224,1) 0%,rgba(241,241,241,0.6) 50%,rgba(225,225,225,0.59) 51%,rgba(246,246,246,0.2) 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, rgba(224,224,224,1) 0%,rgba(241,241,241,0.6) 50%,rgba(225,225,225,0.59) 51%,rgba(246,246,246,0.2) 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, rgba(224,224,224,1) 0%,rgba(241,241,241,0.6) 50%,rgba(225,225,225,0.59) 51%,rgba(246,246,246,0.2) 100%); /* IE10+ */
            background: linear-gradient(to bottom, rgba(224,224,224,1) 0%,rgba(241,241,241,0.6) 50%,rgba(225,225,225,0.59) 51%,rgba(246,246,246,0.2) 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e0e0e0', endColorstr='#33f6f6f6',GradientType=0 ); /* IE6-9 */
        }

        .showdivModule {
            display: block;
        }

        .divGridstyle {
            margin: 0px 10px 0px 10px;
        }

        .searchrecfoundtext {
            font-family: "Verdana",Verdana,Arial,Helvetica;
            font-size: 11px;
            color: grey;
            font-weight: normal;
        }
        /* for loading screen below css must stay in this page  */
        #loadingScreen {
            background-image: url(images/loading_new.gif);
            background-repeat: no-repeat;
            margin-left: 20px;
        }
        /* hide the close x on the loading screen */
        .loadingScreenWindow .ui-dialog-titlebar-close {
            display: none;
        }

        .ui-dialog .ui-dialog-titlebar {
            display: none;
        }
    </style>
    <asp:HiddenField ID="hdnCrmCustRecfound" runat="server" Value="0" />
    <asp:HiddenField ID="hdnCrmSupplierRecfound" runat="server" Value="0" />
    <asp:HiddenField ID="hdnCrmProspectRecfound" runat="server" Value="0" />
    <asp:HiddenField ID="hdnEstimateRecfound" runat="server" Value="0" />
    <script type="text/javascript">
        //**************************************************************************************************************************
        var accIndex = 0;
        var module = "<%= module%>";
        var OrderRecCount = '<%=OrderRecCount %>';
        var JobRecCount = '<%=JobRecCount %>';
        var PurchaseRecCount = '<%=PurchaseRecCount %>';
        var DeliveryRecCount = '<%=DeliveryRecCount %>';
        var InvoiceRecCount = '<%=InvoiceRecCount %>';
        var WarehouseRecCount = '<%=WarehouseRecCount %>';
        var hdnCrmCustRecordfound = document.getElementById("<%=hdnCrmCustRecfound.ClientID %>");
        var hdnCrmSupplierRecfound = document.getElementById("<%=hdnCrmSupplierRecfound.ClientID %>");
        var hdnCrmProspectRecfound = document.getElementById("<%=hdnCrmProspectRecfound.ClientID %>");
        var lblCrmrecordfound = document.getElementById("<%= lblCrmrecordfound.ClientID %>");
        var hdnEstimateRecfound = document.getElementById("<%=hdnEstimateRecfound.ClientID %>");
        var lblEstimateRecfound = document.getElementById("<%=lblEstimateRecfound.ClientID %>");
        var lblOrderRecCount = document.getElementById("<%=lblOrderRecCount.ClientID %>");
        var lblJobRecfound = document.getElementById("<%=lblJobRecfound.ClientID %>");
        var lblPurchaseRecfound = document.getElementById("<%=lblPurchaseRecfound.ClientID %>");
        var lblDeliveryRecfound = document.getElementById("<%=lblDeliveryRecfound.ClientID %>");
        var lblInvoiceRecfound = document.getElementById("<%=lblInvoiceRecfound.ClientID %>");
        var lblWarehouseRecfound = document.getElementById("<%=lblWarehouseRecfound.ClientID %>");
        var lblProofRecfound = document.getElementById("<%=lblProofRecfound.ClientID %>");
        var CrmStatus = "<%=CrmStatus %>";
        var EstimateStatus = "<%=EstimateStatus %>";
        var OrderStatus = "<%=OrderStatus %>";
        var JobStatus = "<%=JobStatus %>";
        var PurchaseStatus = "<%=PurchaseStatus %>";
        var DeliveryStatus = "<%=DeliveryStatus %>";
        var InvoiceStatus = "<%=InvoiceStatus %>";
        var WarehouseStatus = "<%=WarehouseStatus%>";
        var ProofStatus = "<%=ProofStatus%>";
        //**************************************************************************************************************************
        function ShowreturnRecords() {
            if (CrmStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "crm" || module.toLowerCase() == "all") {
                    var CRMtotal = parseInt(hdnCrmCustRecordfound.value) + parseInt(hdnCrmSupplierRecfound.value) + parseInt(hdnCrmProspectRecfound.value);
                    lblCrmrecordfound.innerHTML = "(" + CRMtotal + ")";
                    var div_CRM = document.getElementById("ctl00_ContentPlaceHolder1_div_CRM");
                    if (Number(CRMtotal) == 0) {
                        div_CRM.style.display = "none";
                    }
                }
            }
            if (EstimateStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "estimates" || module.toLowerCase() == "all") {
                    lblEstimateRecfound.innerHTML = "(" + hdnEstimateRecfound.value + ")";
                    var div_Estimates = document.getElementById("ctl00_ContentPlaceHolder1_div_Estimates");
                    if (Number(hdnEstimateRecfound.value) == 0) {
                        div_Estimates.style.display = "none";
                    }
                }
            }
            if (OrderStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "order" || module.toLowerCase() == "all") {
                    lblOrderRecCount.innerHTML = "(" + <%=OrderRecCount %> + ")";
                    var div_Orders = document.getElementById("ctl00_ContentPlaceHolder1_div_Orders");
                    if (Number(<%=OrderRecCount %>) == 0) {
                        div_Orders.style.display = "none";
                    }
                }
            }
            if (JobStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "job" || module.toLowerCase() == "all") {
                    lblJobRecfound.innerHTML = "(" + <%=JobRecCount %> + ")";
                  var div_Job = document.getElementById("ctl00_ContentPlaceHolder1_div_Job");
                  if (Number( <%=JobRecCount %>) == 0) {
                        div_Job.style.display = "none";
                    }
                }
            }
            if (PurchaseStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "purchase order" || module.toLowerCase() == "all") {
                    lblPurchaseRecfound.innerHTML = "(" + <%=PurchaseRecCount %> + ")";
                 var div_Purchaseorder = document.getElementById("ctl00_ContentPlaceHolder1_div_Purchaseorder");
                 if (Number(<%=PurchaseRecCount %>) == 0) {
                        div_Purchaseorder.style.display = "none";
                    }
                }
            }
            if (DeliveryStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "delivery notes" || module.toLowerCase() == "all") {
                    lblDeliveryRecfound.innerHTML = "(" + <%=DeliveryRecCount %> + ")";
                 var div_Deliverynote = document.getElementById("ctl00_ContentPlaceHolder1_div_Deliverynote");
                 if (Number(<%=DeliveryRecCount %>) == 0) {
                        div_Deliverynote.style.display = "none";
                    }
                }
            }
            if (InvoiceStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "invoice" || module.toLowerCase() == "all") {
                    lblInvoiceRecfound.innerHTML = "(" + <%=InvoiceRecCount %> + ")";
                var div_invoice = document.getElementById("ctl00_ContentPlaceHolder1_div_invoice");
                if (Number(<%=InvoiceRecCount %>) == 0) {
                        div_invoice.style.display = "none";
                    }
                }
            }
            if (WarehouseStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "warehouse" || module.toLowerCase() == "all") {
                    lblWarehouseRecfound.innerHTML = "(" + <%=WarehouseRecCount %> + ")";
                var div_Warehouse = document.getElementById("ctl00_ContentPlaceHolder1_div_Warehouse");
                if (Number(<%=WarehouseRecCount %>) == 0) {
                        div_Warehouse.style.display = "none";
                    }
                }
            }
            if (ProofStatus.toLowerCase() == "true") {
                if (module.toLowerCase() == "proof" || module.toLowerCase() == "all") {
                    lblProofRecfound.innerHTML = "(" + <%=ProofRecCount %> + ")";
                var div_proof = document.getElementById("ctl00_ContentPlaceHolder1_div_proof");
                if (Number(<%=ProofRecCount %>) == 0) {
                        div_proof.style.display = "none";
                    }
                }
            }
            if (module.toLowerCase() == "all") {
                var maxvalue = Math.max(CRMtotal, parseInt(hdnEstimateRecfound.value), parseInt(OrderRecCount), parseInt(JobRecCount), parseInt(PurchaseRecCount), parseInt(DeliveryRecCount), parseInt(InvoiceRecCount), parseInt(WarehouseRecCount), parseInt(ProofRecCount));
                if (CRMtotal == maxvalue) {
                    accIndex = 0;
                    accordinwithindex(accIndex);
                }
                else if (hdnEstimateRecfound.value == maxvalue) {
                    accIndex = 1;
                }
                else if (OrderRecCount == maxvalue) {
                    accIndex = 2;
                }
                else if (JobRecCount == maxvalue) {
                    accIndex = 3;
                }
                else if (PurchaseRecCount == maxvalue) {
                    accIndex = 4;
                }
                else if (DeliveryRecCount == maxvalue) {
                    accIndex = 5;
                }
                else if (InvoiceRecCount == maxvalue) {
                    accIndex = 6;
                }
                else if (WarehouseRecCount == maxvalue) {
                    accIndex = 7;
                }
                  else if (ProofRecCount == maxvalue) {
                    accIndex = 8;
                }
            }

            if (accIndex != 0) {
                accordinwithindex(accIndex);
            }
            else {
                accordinwithoutindex();
            }
        }
        ShowreturnRecords();
        //********************************************************************************
        function accordinwithindex(index) {
            $(document).ready(function () {
                $("#accordion").accordion({ header: "h3", collapsible: true, autoHeight: false, animated: 'easeslide', active: index });
            });
        }

        function accordinwithoutindex() {
            $(document).ready(function () {
                $("#accordion").accordion({ header: "h3", collapsible: true, autoHeight: false, animated: 'easeslide' });
            });
        }
        $(function () {
            $("#tabs").tabs();
        });

        // to end loading after page load
        $(window).load(function () {
            closeWaitingDialog();
        });

    </script>
</asp:Content>
