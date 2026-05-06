<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_summary_ProgressTo_Invoice.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_summary_ProgressTo_Invoice" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div style="float: left; width: 100%; clear: both;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <%--<tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <div id="DivProgressJobtoInvoice_reeng">
                        <span><b>Progress To Invoice</b></span>
                    </div>
                    <div id="DivInvoicePayment_reeng">
                        <span><b>Invoice Payment</b></span>
                    </div>
                    <div id="DivPaymentDetails_reeng">
                        <span><b>Payment Details</b></span>
                    </div>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideDiv1('close');return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td align="center">
                <div align="left" style="width: 100%">
                    <div align="left">
                        <div id="div_ProformaInvoice">
                            <%--<div style="float: left; padding-top: 6px; margin-left: 2px; margin-bottom: 6px"
                                visible="false">
                                <asp:Label ID="Label1" runat="server" Text="" Style="font-size: 11px"><b>Options</b></asp:Label>
                            </div>--%>
                            <div class="box" style="margin-left: 5px; margin-bottom: 6px; width: 100%" visible="false">
                                <asp:RadioButton ID="rdnProformaInvYes" runat="server" Text="Generate Invoice and keep the job live"
                                    Checked="false" GroupName="ProformaInvoice" /><br />
                                <asp:RadioButton ID="rdnProformaInvNo" runat="server" Text="Generate Invoice and archive the job"
                                    Checked="true" GroupName="ProformaInvoice" /><br />
                            </div>
                            <div style="clear: both">
                            </div>
                        </div>
                        <div align="left">
                            <div id="IspaidQuestion" runat="server">
                                <div style="float: left; padding-top: 6px; margin-left: 4px; margin-bottom: 6px"
                                    visible="false">
                                    <asp:Label ID="lbl" runat="server" Text="" Style="font-size: 11px"><b>Is this Invoice Paid?</b></asp:Label>
                                </div>
                                <div class="box" style="margin-left: 5px; margin-bottom: 6px; width: 100%;" visible="false">
                                    <asp:RadioButton ID="rdnYes" runat="server" Text="Yes" Checked="false" GroupName="Paid"
                                        onclick="javascript:paidyes1();return true;" />
                                    <asp:RadioButton ID="RdnNo" runat="server" Text="No" Checked="true" GroupName="Paid"
                                        onclick="javasrcipt:paidNo1();return true;" />
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div style="width: 100%;">
                                <div style="clear: both">
                                </div>
                            </div>
                            <div id="PaidYesNo_reeng" style="width: 90%;">
                                <asp:LinkButton ID="lnkNotPaid" runat="server" Visible="false" Text="Click here to make the payment not paid"></asp:LinkButton>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblPaymentmode" runat="server" Text="Payment Mode"></asp:Label>
                                    </div>
                                    <div id="DivPayment_Dropdown" class="box">
                                        <asp:DropDownList ID="ddl_Paymentmode" runat="server" SkinID="onlyDDL" Enabled="false">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="DivPayment_Value" class="box">
                                        <asp:Label ID="lblPaymentvalue" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblDate" runat="server" Text="Date" SkinID="textPad"></asp:Label>
                                    </div>
                                    <div id="DivDate_Text" class="box">
                                        <asp:TextBox ID="txtInvoicePaymentDate" runat="server" SkinID="textPad" Enabled ="false"></asp:TextBox>
                                        <span id="spn_InvoicePaymentDaterfq" style="width: 170px; display: none" class="spanerrorMsg">
                                            Please enter the valid date</span>
                                    </div>
                                    <div id="DivDate_Value" class="box">
                                        <asp:Label ID="lblDatevalue" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left">
                                        <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                                    </div>
                                    <div id="DivNotes_Text" class="MultileText" style="float: left; margin-top: -3px">
                                        <asp:TextBox ID="txt_PaymentDetailNotes" runat="server" TextMode="MultiLine" SkinID="textPad_est" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div id="DivNotes_Value" class="box" style="float: left; margin-top: -3px; width: 190px;
                                        overflow: hidden">
                                        <asp:Panel ID="pnlNotes" runat="server" ScrollBars="Auto">
                                            <div style="float: left; margin-top: 3px; width: 180px;">
                                                <asp:Label ID="lblNotesValue" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; width: 30%">
                                    &nbsp;</div>
                                <div style="float: left; display: none">
                                    <input type="button" value="Cancel" class="button" style="width: 65px" onclick="javascript:hideDiv1('hide')" />
                                </div>
                                <div style="float: left; width: 5px">
                                    &nbsp;
                                </div>
                                <div id="DivPaddingTop" style="float: left; margin-left: -5px">
                                    <div id="div_btncontinue" style="display: block">
                                        <asp:Button ID="BtnContinue" runat="server" Text="Continue" CssClass="button" OnClick="BtnContinue_onclick"
                                            OnClientClick="javascript:loadingimg('div_btncontinue','div_btncontprocess'); return validate_date();" />
                                    </div>
                                    <div id="div_btncontprocess" class="button" align="center" style="width: 56px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div id="DivBtnPay_reeng" style="float: left; margin-left: -5px; display: none">
                                    <asp:Button ID="BtnPay" runat="server" Text="Record Payment" CssClass="button" OnClick="BtnPay_onclick"
                                        OnClientClick="javascript:return validate_date();" />
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
            <td style="width: 10px;">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;
            </td>
        </tr>
        <%--<tr>
            <td colspan="2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>--%>
        <asp:HiddenField ID="hdnEstimatIds" runat = "server" Value="" />
    </table>
    <script>
        function paidyes1() {
            var paid_reeng = document.getElementById("PaidYesNo_reeng");
            var ddl_Paymentmode = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            var txtInvoicePaymentDate = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>");
            var txt_PaymentDetailNotes = document.getElementById("<%=txt_PaymentDetailNotes.ClientID%>");
            
            ddl_Paymentmode.disabled = false;
            txt_PaymentDetailNotes.disabled = false;
            txtInvoicePaymentDate.disabled = false;
            
            //paid_reeng.style.display = "block";
        }

        function paidNo1() {
            var paid_reeng = document.getElementById("PaidYesNo_reeng");
            var ddl_Paymentmode = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            var txtInvoicePaymentDate = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>");
            var txt_PaymentDetailNotes = document.getElementById("<%=txt_PaymentDetailNotes.ClientID%>");
            ddl_Paymentmode.disabled = true;
            txt_PaymentDetailNotes.disabled = true;
            txtInvoicePaymentDate.disabled = true;
            //paid_reeng.style.display = "none";
        }

        //        function disableBtnContinue() {
        //            alert('Disable');            
        //            parent.document.getElementById("div_Load").style.display = "block";
        //            parent.document.getElementById("div_ProgressToInvoice").style.display = "none";
        //        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function Close() {
            //alert("close");
            var oWindow = GetRadWindow();
            var url = "<%=strSitepath%>invoice/invoice_summary_reeng.aspx?estid=<%=EstimateID%>";
            oWindow.BrowserWindow.location.href = '<%=strSitepath%>invoice/invoice_summary_reeng.aspx?estid=<%=EstimateID%>';
            oWindow.close();
            return false;
        }

        function FetchEstimateIDs() {
            var hdnEstimatIds = document.getElementById("<%=hdnEstimatIds.ClientID%>");
            var hdn = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_hdnInvoiceEstimateIds');
            hdnEstimatIds.value = hdn.value;
        }
    
    </script>
</div>
