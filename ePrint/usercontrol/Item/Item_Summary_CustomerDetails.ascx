<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_Summary_CustomerDetails.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_Summary_CustomerDetails" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:HiddenField ID="hdn_Summurypage_ContactID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_Summurypage_ClientID" runat="server" Value="0" />

<table id="tbl_CutaomerDetails" cellpadding="0" cellspacing="0" border="0px" width="99%">
    <tr>
        <td>
            <div align="left" style="padding: 2px 2px 5px 8px; width: 48%; float: left;">
                <asp:Label ID="lbl_SummaryHeader" runat="server" CssClass="headerText" Text="Estimate Information Detail"></asp:Label>
            </div>
            <div id="Div_UpdateMsg" align="left" style="padding: 2px 2px 5px 2px; width: 48%; float: left; display: none">
                <asp:Label ID="lbl_UpdateMsg" runat="server" CssClass="msg-success"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <%--Left --%>
        <td align="left" width="48%" style="border: 0px solid red; padding-left: 10px;">
            <div style="clear: both; border: 0px solid green;">
                <div id="Div_Comapny">
                    <div class="bglabel">
                        <span class="normalText" id="spnCompany" runat="server">
                            <%=objLanguage.GetLanguageConversion("Company")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblCustomerName" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div1">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Company_Email")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblCompanyEmail" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_Contact">
                    <div class="bglabel">
                        <span class="normalText" id="spnContact" runat="server">
                            <%=objLanguage.GetLanguageConversion("Contact")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblAttention" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_OrderedBy" style="display: none;">
                    <div class="bglabel">
                        <span class="normalText" id="Span1" runat="server">
                            <%=objLanguage.GetLanguageConversion("Ordered_By")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblOrderedBy" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_Department">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Department")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblCompany" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div2">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Contact_Email")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblContactEmail" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div7">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Contact_Phone")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblContactPhone" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_Contact_Mobile">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Contact_Mobile")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblContactMobile" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_Estimator">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Estimator")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblEstimator" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_Greeting">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Greeting")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblGreeting" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_SalesPerson">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Sales_Person")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblSalePerson" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_ContactAdd">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Contact_Address")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblAddress" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_DeliveryAdd">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Delivery_Address")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_AddressLabel">
                    <div class="bglabel">
                        <span class="normalText">
                           <%-- <%=objLanguage.GetLanguageConversion("Delivery_Address_Label")%>--%>
                            Delivery Address Label
                        </span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblDeliveryAddressLabel" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div_InvoiceAddress">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Invoice_Address")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblInvoiceAddress" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div id="Div1_Header" runat="server" visible="true">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Header")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px;">
                        <asp:Label ID="lblHeader" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <div id="Div2_Footer" runat="server" visible="true">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Footer")%></span>
                    </div>
                    <div class="box" style="margin-left: 20px; padding-bottom: 35px;">
                        <asp:Label ID="lblFooter" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </td>
        <%--Right --%>
        <td align="right" width="99%" valign="top" style="float: left; border: 0px solid red;">
            <div style="clear: both; width: 99%; vertical-align: top; border: 0px solid green;">
                <div id="Div_title">
                    <div align="left" class="bglabel">
                        <span id="spntitle" runat="server" class="normalText">
                            <%=objLanguage.GetLanguageConversion("Estimate_Title")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblEstimateTitle" CssClass="normalText" runat="server" Width="360px" style="word-wrap:break-word;"></asp:Label>
                    </div>
                </div>
                <div id="Div_EstNo">
                    <div class="bglabel" align="left">
                        <span id="spnNo" runat="server" class="normalText">
                            <%=objLanguage.GetLanguageConversion("Estimate_Number")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblEstimateNo" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="Div_CON">
                    <div class="bglabel" align="left">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Customer_Order_Number")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblOrderNo" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <%--<div id="Div_OrderNumber" style="<%=OrderNumberStyle%>">
                    <div class="bglabel" align="left">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Order_Number")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblOrderNumber" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>--%>
                <div id="Div_InvoicePaid" runat="server" align="left" style="display: block; clear: both;">
                    <div class="bglabel" align="left">
                        <div style="float: left">
                            <span class="normalText">
                                <%=objLanguage.GetLanguageConversion("Invoice_Paid")%></span>
                        </div>
                        <div style="float: right;">
                            <asp:ImageButton Style="vertical-align: middle;" ID="Hyperlink_PaymentDetails" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Yes" OnClientClick="javascript:OpenNewInvoicePaid();return false;"
                                Visible="false"></asp:ImageButton>
                            <asp:ImageButton Style="vertical-align: middle" ID="ChengePaymentMode" runat="server"
                                CausesValidation="false" ImageUrl="~/images/plus.gif" OnClientClick="javascript:OpenNewInvoicePaid();return false;"></asp:ImageButton>
                            <asp:HiddenField ID="hdnEstimate" runat="server" />
                            <asp:HiddenField ID="hdnPaidValue" runat="server" />
                            <asp:HiddenField ID="hdnacthist" runat="server" />
                        </div>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblIspaid" runat="server" CssClass="normalText"></asp:Label>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <div id="Div_Status" style="display: none;">
                    <div class="bglabel" align="left">
                        <span class="normalText">Status</span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:DropDownList ID="ddlStatus" CssClass="normaltext" runat="server" Width="150px"
                            onchange="javascript:SeletedStatusID(this.value); return false;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdn_SelectedStatusID" runat="server" Value="0" />
                        <asp:Label runat="server" ID="lblInvoicestatus" Visible="false"></asp:Label>
                        <asp:Button ID="btnSaveStatus" runat="server" Text="Save Status" CssClass="button"
                            OnClientClick="javascript:return reduceStockTypeForCancelled();" />
                        <asp:HiddenField ID="hdnReduceStockTypeForCancelled" Value="false" runat="server" />
                        <asp:LinkButton ID="lnkSaveStatus" runat="server" OnClick="btnSaveStatus_OnClick"
                            Text=""></asp:LinkButton>
                        <asp:HiddenField ID="hidDeleteID" runat="server" />
                        <asp:LinkButton ID="lnkEstItemDelete" runat="server" OnClick="OnClick_Delete"></asp:LinkButton>
                    </div>
                </div>
                <div id="Div_ACNo">
                    <div class="bglabel" align="left">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Account_Number")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblAccountNo" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div> 
                 <div id="Div_ACN_STATUS">
                    <div class="bglabel" align="left">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Account_Status")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblAccStatus" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="Div_JobEstNo" style="display: block;">
                    <div class="bglabel" align="left">
                        <span class="normalText">
                            <%=objLang.GetLanguageConversion("Estimate_Number") %></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblJobNumber" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="Div_EstDate">
                    <div class="bglabel" align="left">
                        <span id="spnDate" class="normalText">
                            <%=objLanguage.GetLanguageConversion("Estimate Date")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblEstimateDate" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="div_InvoiceDueDate" style="display: none" runat="server">
                    <div class="bglabel" align="left">
                        <span id="spn_DueDate" class="normalText">
                            <%=objLanguage.GetLanguageConversion("Invoice_DueDate")%></span>
                    </div>
                    <div class="box" align="left" style="margin-left: 20px;">
                        <asp:Label ID="lblInvoiceDueDate" CssClass="normalText" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Job Summary Screen Dates--%>
                <div id="CompletionDate" style="display: block; clear: both;">
                    <div align="left">
                        <div class="bglabel">
                            <span class="normalText">
                                <%=objLang.GetLanguageConversion("Job_Progressed_On")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblProgressedOn" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div align="left" id="DivArtwork" runat="server">
                        <div class="bglabel">
                            <span class="normalText">
                                <%=objLang.GetLanguageConversion("Artwork_Date")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblArtworkDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div align="left" id="DivProof" runat="server">
                        <div class="bglabel">
                            <span class="normalText">
                                <%=objLang.GetLanguageConversion("Proof_Date")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblProofDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div align="left" id="DivApproval" runat="server">
                        <div class="bglabel">
                            <span class="normalText">
                                <%=objLang.GetLanguageConversion("Approval_Date")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblApprovalDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div align="left" id="DivProduction" runat="server">
                        <div class="bglabel">
                            <span class="normalText">
                                <%=objLang.GetLanguageConversion("Production_Dates")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblProductionDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div id="div_JobCompletionDate" runat="server" align="left">
                        <div class="bglabel">
                            <span class="normalText" id="Span2">
                                <%=objLang.GetLanguageConversion("Completion_Date")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCompletionDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div align="left" id="div_JobDeliveryDate" runat="server">
                        <div class="bglabel">
                            <span class="normalText" id="Span3">
                                <%=objLang.GetLanguageConversion("Delivery_Date")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblDeliveryDate" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                    <%--   <div align="left" id="div_CustomDate1" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate1">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate1" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                       <div align="left" id="div_CustomDate2" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate2">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate2" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate3" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate3">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate3" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate4" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate4">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate4" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate5" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate5">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate5" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>--%>

                    <div style="clear: both">
                    </div>
                </div>
                <%--End Job Dates--%>
                <%--Estimate Summary Screen Dates--%>
                <div class="hidejobdatecss">
                    <div id="Div_EstDates" style="display: none; clear: both;">
                        <div id="Div_EstArtwork" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Artwork")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lblestimatedartwork" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="Div_Estproof" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Proof")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lblestimatedProof" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="div_ApprovalNew" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Approval")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lbl_EstApproval" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="divProductionDate" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Production")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lbl_EstProduction" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="divJobCompletionDate" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Completion")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lbl_EstCompletion" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="div_deliverydate" runat="server">
                            <div class="bglabel" align="left">
                                <span class="normalText" id="spnDelivery" runat="server">
                                    <%=objLanguage.GetLanguageConversion("Estimated_Delivery")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lblestimateddelivery" CssClass="normalText" runat="server"></asp:Label>
                            </div>
                        </div>
                       
                        <%--End Estimate Dates--%>
                        <%--Invoice Fields--%>
                        <div align="left" id="divInvoice" style="display: block">
                            <div align="left">
                                <div class="bglabel" align="left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Estimate_Number")%></span>
                                </div>
                                <div class="box" align="left" style="margin-left: 20px;">
                                    <asp:Label ID="lblInvoiceEstimateWas" CssClass="normalText" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" align="left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Job_Number")%></span>
                                </div>
                                <div class="box" align="left" style="margin-left: 20px;">
                                    <asp:Label ID="lblInvoiceJobWas" CssClass="normalText" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                 

                        <%--End invoice--%>
                        <div id="Div_ValidFor" style="display: none; clear: both;">
                            <div class="bglabel" align="left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Valid_For")%></span>
                            </div>
                            <div class="box" align="left" style="margin-left: 20px;">
                                <asp:Label ID="lblVaidFor" CssClass="normalText" runat="server"></asp:Label>
                                <asp:Label ID="lbl_Days" runat="server" CssClass="normalText" Text="day(s)"></asp:Label>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                    </div>

                               <div align="left" id="div_CustomDate1" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate1">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate1" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                       <div align="left" id="div_CustomDate2" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate2">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate2" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate3" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate3">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate3" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate4" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate4">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate4" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div align="left" id="div_CustomDate5" runat="server">
                        <div class="bglabel">
                            <span class="normalText" runat="server" id="SpanCustomDate5">
                                </span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblCustomDate5" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                    </div>


                    <div id="div_costcentredisp" runat="server" style="display: none; clear: both;">
                        <div class="bglabel" align="left">
                            <span class="normalText">
                                <%=objLanguage.GetLanguageConversion("Cost_Centre") %></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblcostcentre" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div id="div_PaymentType" runat="server" style="display: none; clear: both;">
                        <div class="bglabel" align="left">
                            <div style="float: left">
                                <span class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Payment_Type")%></span>
                            </div>
                            <div style="float: right; cursor: pointer;">
                                <img id="imgBtn_PaymentDetails" runat="server" src="~/images/plus.gif" style="display: none"
                                    onclick="javascript:return OpenPaidInvoice('webstore');" />
                            </div>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblPaymentType" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div id="div_Comments" style="display: block; clear: both;">
                        <div class="bglabel" align="left">
                            <span class="normalText">
                                <%=objLanguage.GetLanguageConversion("Comments")%></span>
                        </div>
                        <div class="box" align="left" style="margin-left: 20px;">
                            <asp:Label ID="lblComments" CssClass="normalText" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div style="padding-left: 5px;">
                <div id="div_btnestimate" style="display: block">
                    <asp:Button ID="btn_estimate" runat="server" Text="Re-run Estimate Info" CssClass="button"
                        Style="display: none;" OnClientClick="javascript:loadingimage(this.id,'div_btnestimateprocess');"
                        OnClick="OnClick_ReRunEstimateInfo" />
                </div>
                <div id="div_btnestimateprocess" style="display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                </div>
            </div>
        </td>
    </tr>
</table>
<div id="div_mask">
</div>
<div id="div_StockAlert" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 35%"
    align="center">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b>Stock Alert </b>
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideDivNew();" />
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
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td valign="top">Do you want the quantity to be added back to the inventory?
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnYes" Text="Yes" CssClass="button" runat="server" OnClientClick="javascript:Save('Y');" />
                                    <asp:Button ID="btnNo" Text="No" CssClass="button" runat="server" OnClientClick="javascript:Save('N');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
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
<asp:HiddenField ID="hdnIsPaid" runat="server" />
<asp:HiddenField ID="hdnJIcreated" runat="server" />
<script>
    var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
    var ddlStatusID = document.getElementById("<%=ddlStatus.ClientID %>");
    var ISInventoryReduced = '<%=ISInventoryReduced %>';
    var PgtypeNew = '<%=Pgtype %>';
    var InventoryManagement = '<%=InventoryManagement %>';
    var EstimateID = '<%=EstimateID%>';
</script>
<script type="text/javascript">
    var Module = "<%=Module %>";
    function LoadPageInformation() {
        if (Module == "job") {
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Job_Date") %>';
            document.getElementById("<%=Div_InvoicePaid.ClientID%>").style.display = "none";
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Job_Number") %>';
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Job_Title") %>';
            document.getElementById("CompletionDate").style.display = "block";
            document.getElementById("Div_ValidFor").style.display = "none";
        }
        else if (Module == "invoice") {
            document.getElementById("Div_JobEstNo").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Date") %>';
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Number") %>';
            document.getElementById("CompletionDate").style.display = "none";
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Title") %>';
            document.getElementById("Div_ValidFor").style.display = "none";
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("<%=spnDelivery.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Delivery_Date") %>';
            document.getElementById("Div_EstDates").style.display = "block";
        }
        else if (Module == "estimate") {
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Estimate_Date") %>';
            document.getElementById("Div_JobEstNo").style.display = "none";
            document.getElementById("<%=Div_InvoicePaid.ClientID%>").style.display = "none";
            document.getElementById("Div_EstDates").style.display = "block";
            document.getElementById("CompletionDate").style.display = "none";
            document.getElementById("Div_ValidFor").style.display = "block";
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Estimate_Number") %>';
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Estimate_Title") %>';
        }
        else if (Module == "order") {
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Ordered_Date") %>';
            document.getElementById("Div_JobEstNo").style.display = "none";
            document.getElementById("<%=Div_InvoicePaid.ClientID%>").style.display = "none";
            document.getElementById("Div_EstDates").style.display = "block";
            document.getElementById("CompletionDate").style.display = "none";
            document.getElementById("Div_ValidFor").style.display = "none";
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Order_Number") %>';
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Order_Title") %>';
            document.getElementById("<%=spnCompany.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Customer") %>';
            document.getElementById("<%=spnContact.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Ordered_For") %>';
            document.getElementById("<%=spnDelivery.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Delivery_Date") %>';
            document.getElementById("Div_OrderedBy").style.display = "block";
            document.getElementById("<%=div_PaymentType.ClientID%>").style.display = "block";
            document.getElementById("div_Comments").style.display = "block";
            document.getElementById("Div_Estimator").style.display = "none";

        }

        else if (Module == "joborder") {
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Job_Date") %>';
            document.getElementById("Div_JobEstNo").style.display = "none";
            document.getElementById("<%=Div_InvoicePaid.ClientID%>").style.display = "none";
            document.getElementById("Div_EstDates").style.display = "block";
            document.getElementById("CompletionDate").style.display = "none";
            document.getElementById("Div_ValidFor").style.display = "none";
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Job_Number") %>';
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Job_Title") %>';
            document.getElementById("<%=spnCompany.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Customer") %>';
            document.getElementById("<%=spnContact.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Ordered_For") %>';
            document.getElementById("<%=spnDelivery.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Delivery_Date") %>';
            document.getElementById("Div_OrderedBy").style.display = "block";
            document.getElementById("<%=div_PaymentType.ClientID%>").style.display = "block";
            document.getElementById("div_Comments").style.display = "block";
            document.getElementById("Div_Estimator").style.display = "none";

        }

        else if (Module == "invoiceorder") {
            document.getElementById("divInvoice").style.display = "none";
            document.getElementById("spnDate").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Date") %>';
            document.getElementById("Div_JobEstNo").style.display = "none";
            //document.getElementById("<%=Div_InvoicePaid.ClientID%>").style.display = "none";
            document.getElementById("Div_EstDates").style.display = "block";
            document.getElementById("CompletionDate").style.display = "none";
            document.getElementById("Div_ValidFor").style.display = "none";
            document.getElementById("<%=spnNo.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Number") %>';
            document.getElementById("<%=spntitle.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Invoice_Title") %>';
            document.getElementById("<%=spnCompany.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Customer") %>';
            document.getElementById("<%=spnContact.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Ordered_For") %>';
            document.getElementById("<%=spnDelivery.ClientID%>").innerHTML = '<%=objLang.GetLanguageConversion("Delivery_Date") %>';
            document.getElementById("Div_OrderedBy").style.display = "block";
            document.getElementById("<%=div_PaymentType.ClientID%>").style.display = "block";
            document.getElementById("div_Comments").style.display = "block";
            document.getElementById("Div_Estimator").style.display = "none";

        }

}
LoadPageInformation();

function SeletedStatusID(ObjID) {
    document.getElementById("<%=hdn_SelectedStatusID.ClientID%>").value = ObjID;
    }

</script>
<script type="text/javascript">

    function OpenNewInvoicePaid() {
        var hdnEstimate = document.getElementById("<%=hdnEstimate.ClientID%>");
        var hdnPaidValue = document.getElementById("<%=hdnPaidValue.ClientID%>");
        var hdnacthist = document.getElementById("<%=hdnacthist.ClientID%>");
        var hdnOrderID = '<%=EstimateID %>';
        var InvoiceID = '<%=InvoiceID %>';
        var strtype = '<%=strtype %>';

        if (strtype == 'ijcreated') {
            var hdnIsPaid = document.getElementById("<%=hdnIsPaid.ClientID %>");
            var hdnEstId = '<%=EstimateID %>';
            var hdnJIcreated = document.getElementById("<%=hdnJIcreated.ClientID %>");
            module = "ojSummary";
            if (hdnIsPaid.value != "") {
                if (hdnIsPaid.value == "0") {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
                }
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
            }
        }
        else {

            if (hdnacthist.value != "") {
                var RadWindow_Paid = window.radopen("<%=nmsCommon.global.sitePath()%>common/Invoice_Paid.aspx?EstimateID=" + hdnOrderID + "&InvoiceID=" + InvoiceID + "&IsPaid=0&Module=InvoiceSummary", 100, 100);
            }
            else {
                if (hdnPaidValue.value != "") {
                    var RadWindow_Paid = window.radopen("<%=nmsCommon.global.sitePath()%>common/Invoice_Paid.aspx?EstimateID=" + hdnOrderID + "&InvoiceID=" + InvoiceID + "&OrderID=" + hdnOrderID + "&IsPaid=" + hdnPaidValue.value + "&Module=InvoiceSummary", 100, 100);
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=nmsCommon.global.sitePath()%>common/Invoice_Paid.aspx?EstimateID=" + hdnOrderID + "&InvoiceID=" + InvoiceID + "&IsPaid=0&Module=InvoiceSummary", 100, 100);
                }
            }
        }
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(680, 500);
        RadWindow_Paid.center();
    }

    function OpenMultiplePopup(id) {
        var RadWindow_Paid = window.radopen("<%=nmsCommon.global.sitePath()%>common/Invoice_summary_MultipleOption.aspx?InvoiceID=" + id, 100, 100);

        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(1080, 500);
        RadWindow_Paid.center();
    }

    function OpenPaidInvoice(type) {

        var hdnIsPaid = document.getElementById("<%=hdnIsPaid.ClientID %>");
        var hdnEstId = '<%=EstimateID %>';
        var hdnOrderID = '<%=EstimateID %>';
        var hdnJIcreated = document.getElementById("<%=hdnJIcreated.ClientID %>");

        var url = window.location.href;
        var module;

        if (url.indexOf("invoice_order_summary") != -1) {
            module = "OrderInvoiceSummary";
        }
        if (type != "websotre" && module == "OrderInvoiceSummary") {
            if (hdnIsPaid.value == "0") {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID, 100, 100);
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID.value, 100, 100);
            }
        }
        else if (type == 'ijcreated') {
            module = "ojSummary";
            if (hdnIsPaid.value != "") {
                if (hdnIsPaid.value == "0") {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
                }
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID + "&IsWebStore=1&IsInvoiceJobCreated=" + hdnJIcreated.value, 100, 100);
            }
        }
        else {
            module = "OrderSummary";
            if (hdnIsPaid.value != "") {
                if (hdnIsPaid.value == "0") {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1", 100, 100);
                }
                else {
                    var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=1&Module=" + module + "&OrderID=" + hdnOrderID + "&IsWebStore=1", 100, 100);
                }
            }
            else {
                var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + hdnEstId + "&IsPaid=0&Module=" + module + "&OrderID= " + hdnOrderID + "&IsWebStore=1", 100, 100);
            }
        }

    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_Paid.setSize(680, 500);
    RadWindow_Paid.center();
    return false;
}

</script>
