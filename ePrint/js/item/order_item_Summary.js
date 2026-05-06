function Summary_Detail_Show(i, Type, OrderItemID) {
    var itemNu = Number(i) + 1;
    if (Type == "summary") {
        document.getElementById("divbtnSummary_" + i + "").style.display = "none";
        document.getElementById("divbtnDetail_" + i + "").style.display = "block";
        document.getElementById("div_detail_" + i + "").style.display = "none";
        document.getElementById("div_Summary_" + i + "").style.display = "block";
        try {
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + i + "").style.color = "#000000";

        } catch (err) {
        }

    }
    else if (Type == "detail") {
        document.getElementById("divbtnSummary_" + i + "").style.display = "block";
        document.getElementById("divbtnDetail_" + i + "").style.display = "none";
        document.getElementById("div_detail_" + i + "").style.display = "block";
        document.getElementById("div_Summary_" + i + "").style.display = "none";
        try {
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + i + "").style.color = "#751717";
        } catch (err) {
        }

    }
    return false;
}
function hideDiv1(val) {
    if (val = "close") {
        document.getElementById("divBackGroundNew").style.display = "none";
        document.getElementById("div_ProgressToJobs").style.display = "none";
        document.getElementById("div_CreatePurchase").style.display = "none";
    }
}

function ShowProgressToJobFromOrders() {
    if (document.getElementById("div_ProgressToJobs").style.display == "none") {
        if (ConvertedToJob == "True") {
            alert('This order is already progressed to job and hence cannot be progressed again.');
        }
        else {
            loadradwindow();
        }
    }
    else {
        document.getElementById("div_ProgressToJobs").style.display = "none";
        if (ConvertedToJob == "True") {
            alert('This order is already progressed to job and hence cannot be progressed again.');
        }
    }
}

function Validate_btnProgrssToJob() {
    var CheckOrderList = false;
    if (hid_NoofOrdersToProgress.value != "") {
        var chkCount = 0;
        hid_orderItemIDs.value = "";
        hid_EstimateItemIDs.value = "";
        for (var i = 0; i <= hid_NoofOrdersToProgress.value - 1; i++) {

            var chkOrderList = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_RadWindow1_C_chkOrderList_" + i + "");
            var spn_OrderItemID = document.getElementById("spn_OrderItemID_" + i + "");
            var spn_EstimateItemID = document.getElementById("spn_EstimateItemID_" + i + "");
            if (chkOrderList.checked == true) {
                if (hdnEstItemsSelected.value != "") {
                    var ItemsSelected = (hdnEstItemsSelected.value);
                    if (ItemsSelected.indexOf(spn_EstimateItemID.innerHTML) > -1) {
                        chkCount++;
                        hid_orderItemIDs.value = hid_orderItemIDs.value + spn_OrderItemID.innerHTML + "»";
                        hid_EstimateItemIDs.value = hid_EstimateItemIDs.value + spn_EstimateItemID.innerHTML + "»";
                    }
                }
            }
        }
        hid_NoofOrdersProgressedToJob.value = chkCount;

        if (chkCount == 0) {
            CheckOrderList = true;
        }
        if (CheckOrderList) {
            document.getElementById("div_chkOrderlist").style.display = "block";
            return false;
        }
        else {
            document.getElementById("div_Load").style.display = "block";
            document.getElementById("div_ProgressToJobs").style.display = "none";
            return true;
        }
    }
}


function ShowAttachments(count) {
    var div_Detail_Attachments = document.getElementById("div_Detail_Attachments_" + count + "");
    var div_Summary_Attachments = document.getElementById("div_Summary_Attachments_" + count + "");
    if (div_Detail_Attachments.style.display == "none") {
        div_Detail_Attachments.style.display = "block";
        div_Summary_Attachments.style.display = "none";
    }
    else {
        div_Detail_Attachments.style.display = "none";
        div_Summary_Attachments.style.display = "block";
    }
}

function OpenAttach(FileName, ServerName, CompanyID, DocPath) {
    window.open(DocPath + ServerName + "/" + CompanyID + "/attachments/" + FileName, '_blank');
}

//to validate date while progress to invoice
function validate_date() {
    CheckFinal = false;

    var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
    if (txtInvoicePaymentDate == '') {
        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block";
        CheckFinal = true;
    }
    else {
        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
    }

    if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDaterfq', DateFormat_stage) == false) {
        CheckFinal = true;
    }

    if (CheckFinal) {
        return false;
    }
    else {
        document.getElementById("div_Load").style.display = "block";
        document.getElementById("div_ProgressToInvoice").style.display = "none";
        return true;
    }
}

function paidyes() {
    var paid = document.getElementById("PaidYesNo");
    paid.style.display = "block";
}
function paidNo() {
    var paid = document.getElementById("PaidYesNo");
    paid.style.display = "none";
}


function ProgressJob_reeng_Order() {
    var ret = 0;
    //if IsPaymentEnable in web confg value is 1 then the Popup "Is This Invoice Paid?" opens on click Progress to invoice else the alert message box opens.
    if (Ispaidenable == '1') {

        if (ret == 1) {
            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

                var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
                var DivBtnPay = document.getElementById("DivBtnPay");
                var DivPayment_Value = document.getElementById("DivPayment_Value");
                var DivDate_Value = document.getElementById("DivDate_Value");
                var DivNotes_Value = document.getElementById("DivNotes_Value");
                DivProgressJobtoInvoice.style.display = "block";
                hdnHeader.value = "Progress To Invoice";
                DivBtnPay.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                DivNotes_Value.style.display = "none";
                return false;
            }
            else {
                document.getElementById("div_ProgressToJob").style.display = "none";
            }
        }
        else {
            var DivBtnPay = document.getElementById("DivBtnPay");
            var DivPayment_Value = document.getElementById("DivPayment_Value");
            var DivDate_Value = document.getElementById("DivDate_Value");
            var IspaidQuestion = document.getElementById("IspaidQuestion");
            var div_OdrPaymentDetails = document.getElementById("div_OdrPaymentDetails");
            var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
            var DivPaddingTop = document.getElementById("DivPaddingTop");
            var PaidYesNo = document.getElementById("PaidYesNo");
            if (hdnPaymentMode.value == "Credit Card" || hdnPaymentMode.value == "PayPal") {
                hdnHeader.value = "Progress To Invoice";
                DivBtnPay.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                IspaidQuestion.style.display = "none";
                div_OdrPaymentDetails.style.display = "none";
                div_ProformaInvoice.style.display = "block";
                DivPaddingTop.style.display = "block";
                PaidYesNo.style.display = "none";
                return false;
            }
            else {
                hdnHeader.value = "Progress To Invoice";
                DivBtnPay.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                div_ProformaInvoice.style.display = "block";
                DivPaddingTop.style.display = "block";
                IspaidQuestion.style.display = "block";
                PaidYesNo.style.display = "block";
                return false;
            }
        }
    }
    else {
        if (ret == 1) {
            return window.confirm("Are you sure you want to progress this Job to become an Invoice ?  Invoices can not be reverted back to become Jobs in the future.");
        }
        else {
            return false;
        }
    }

}

function ShowJobCard(EstID, EstItemID) {
    window.radopen(strSitepath + "jobs/job_card_new.aspx?EstimateID=" + EstID + "&EstItemID=" + EstItemID + "", '1000', '500');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}

function PaymentDetails_Orders(Type) {
    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
        document.getElementById("div_ProgressToInvoice").style.width = 300 + "px";
        var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
        var IspaidQuestion = document.getElementById("IspaidQuestion");
        var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
        var PaidYesNo = document.getElementById("PaidYesNo");
        var DivPaddingTop = document.getElementById("DivPaddingTop");
        var DivBtnPay = document.getElementById("DivBtnPay");
        var DivPayment_Dropdown = document.getElementById("DivPayment_Dropdown");
        var DivDate_Text = document.getElementById("DivDate_Text");
        var DivNotes_Text = document.getElementById("DivNotes_Text");
        var div_OdrPaymentDetails = document.getElementById("div_OdrPaymentDetails");
        if (Type == "invoice") {
            PaidYesNo.style.display = "block";
            hdnHeader.value = "Payment Details";
            DivBtnPay.style.display = "none";
            IspaidQuestion.style.display = "none";
            div_ProformaInvoice.style.display = "none";
            DivPaddingTop.style.display = "none";
            DivPayment_Dropdown.style.display = "none";
            DivDate_Text.style.display = "none";
            DivNotes_Text.style.display = "none";
        }
        else {
            div_OdrPaymentDetails.style.display = "block";
            hdnHeader.value = "Payment Details";
            DivBtnPay.style.display = "none";
            IspaidQuestion.style.display = "none";
            div_ProformaInvoice.style.display = "none";
            DivPaddingTop.style.display = "none";
            DivPayment_Dropdown.style.display = "none";
            DivDate_Text.style.display = "none";
            DivNotes_Text.style.display = "none";
            PaidYesNo.style.display = "none";
        }
        return false;
    }
    else {
        return false;
    }
}

function PaymentDetails_InvoiceSummary(type) {
    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
        var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
        var PaidYesNo = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
        var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
        var div_CreditCardDetails = document.getElementById("ctl00_ContentPlaceHolder1_div_CreditCardDetails");
        var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
        var DivBtnPay = document.getElementById("DivBtnPay");
        var DivPayment_Dropdown = document.getElementById("DivPayment_Dropdown");
        var DivDate_Text = document.getElementById("DivDate_Text");
        var DivNotes_Text = document.getElementById("DivNotes_Text");
        var div_lnkNotPaid = document.getElementById("ctl00_ContentPlaceHolder1_div_lnkNotPaid");

        var div_HolderName = document.getElementById("div_HolderName");
        var divamountpaid = document.getElementById("divamountpaid");
        var div_CardType = document.getElementById("div_CardType");
        var div_CardNumber = document.getElementById("div_CardNumber");
        var div_MonthYear = document.getElementById("div_MonthYear");
        var div_VarificationNumber = document.getElementById("div_VarificationNumber");
        var div_VarificationText = document.getElementById("div_VarificationText");
        var div_MonthYearValue = document.getElementById("div_MonthYearValue");
        var div_CardNumberText = document.getElementById("div_CardNumberText");
        var div_CardTypeImg = document.getElementById("div_CardTypeImg");
        var div_holderNameText = document.getElementById("div_holderNameText");
        div_CreditCardDetails.style.display = "none";
        PaidYesNo.style.display = "none";
        hdnHeader.value = "Payment Details";
        div_ProformaInvoice.style.display = "block";
        divamountpaid.style.display = "none";
        DivBtnPay.style.display = "none";
        DivPaddingTop.style.display = "block";
        DivPayment_Dropdown.style.display = "none";
        DivDate_Text.style.display = "none";
        DivNotes_Text.style.display = "none";
        div_lnkNotPaid.style.display = "none";
        DivNotes_Value.style.display = "block";

        if (hdnPaymentMode.value == "Credit Card") {
            div_CreditCardDetails.style.display = "none";
            div_HolderName.style.display = "none";
            div_CardType.style.display = "none";
            div_CardNumber.style.display = "none";
            div_MonthYear.style.display = "none";
            div_VarificationNumber.style.display = "none";
            div_VarificationText.style.display = "none";
            div_MonthYearValue.style.display = "none";
            div_CardNumberText.style.display = "none";
            div_CardTypeImg.style.display = "none";
            div_holderNameText.style.display = "none";
        }

        if (type == "order") {
            var div_OdrPaymentDetails = document.getElementById("div_OdrPaymentDetails");
            div_OdrPaymentDetails.style.display = "block";
            div_lnkNotPaid.style.display = "none";
            div_CreditCardDetails.style.display = "none";
        }
        return false;
    }
    else {
        document.getElementById("div_ProgressToInvoice").style.display = "none";
        return false;
    }
}

function PaymentTypeOnChange() {
    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
        var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
        var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
        var IspaidQuestion = document.getElementById("IspaidQuestion");
        var PaidYesNo = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
        var DivPaddingTop = document.getElementById("DivPaddingTop");
        var DivBtnPay = document.getElementById("DivBtnPay");
        var divMessage = document.getElementById("ctl00_ContentPlaceHolder1_divMessage");
        var DivPayment_Value = document.getElementById("DivPayment_Value");
        var DivDate_Value = document.getElementById("DivDate_Value");
        var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");

        divMessage.style.display = "none";
        PaidYesNo.style.display = "none";
        DivBtnPay.style.display = "none";
        hdnHeader.value = "Invoice Payment";
        div_ProformaInvoice.style.display = "none";
        div_JobStatus.style.display = "none";
        DivPaddingTop.style.display = "none";
        DivPayment_Value.style.display = "none";
        DivDate_Value.style.display = "none";
        DivNotes_Value.style.display = "none";
        return false;
    }
    else {
    }
}

function SaveOrderStatus(OrdStatusID) {
    var ddlSeletedStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_ddlStatus");

    if (ManageStockPermission == 1) {
        if (Pgtype.toLowerCase() == "job" || Pgtype.toLowerCase() == "invoice") {
            if (ddlSeletedStatus.options[ddlSeletedStatus.selectedIndex].text.toString().toLowerCase() == "cancelled") {
                if (StockCancellationType.toString().toLowerCase() == "a") {
                    item_summary.WarehouseStockBackOn_StatusUpdate(CompanyID, EstimateID, 0);
                }
            }
        }
    }

    item_summary.Update_eStoreOrderStatus(CompanyID, EstimateID, OrdStatusID, Pgtype, OrderID, AccountID, Succuss);

    ddlSeletedStatus.options[ddlSeletedStatus.selectedIndex].value = OrdStatusID; //hdn_OrderStatusID.value;
    var lblStatusUpdateMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_lblStatusUpdateMsg");
    var hdnItems = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_hdnItems");
    var Items = hdnItems.value.split('@');

    if (Pgtype == 'webstoreorder') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = "Order status updated successfully";
        lblStatusUpdateMsg.className = "msg-success";
        for (i = 0; i < Items.length - 1; i++) {
            var ddlItem = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_ddlInduvidualStatus_" + Items[i] + "");
            ddlItem.value = OrdStatusID;
        }
        setTimeout("TakeOut()", 2000);
    }
    else if (Pgtype == 'job') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = "Job order status updated successfully";
        lblStatusUpdateMsg.className = "msg-success";
        for (i = 0; i < Items.length - 1; i++) {
            var ddlItem = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_ddlInduvidualStatus_" + Items[i] + "");
            ddlItem.value = OrdStatusID;
        }
        setTimeout("TakeOut()", 2000);
    }
    else if (Pgtype == 'invoice') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = "Invoice order status updated successfully";
        lblStatusUpdateMsg.className = "msg-success";
        for (i = 0; i < Items.length - 1; i++) {
            var ddlItem = document.getElementById("ctl00_ContentPlaceHolder1_UCOrderSummary_ddlInduvidualStatus_" + Items[i] + "");
            ddlItem.value = OrdStatusID;
        }
        setTimeout("TakeOut()", 2000);
    }
    return false;
}

function TakeOut() {
    lblStatusUpdateMsg.style.display = "none";
}
function Succuss() {
}

function CloseDiv() {
    document.getElementById("Div_Print_Email").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
}

function Tax_OnChange_forOtherCost(objVal, QtyCount, EstimateItemID, SectNo, UserID) {
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + SectNo + "");
    if (ddlTax != null && ddlTax != undefined) {

        var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty
        var strTax = objVal.split('~');
        hdn_TaxID.value = strTax[0];
        hdn_TaxPercentage.value = strTax[1]; //Binding as TaxID~TaxRate as value to the Tax ddl   

        for (var h = 0; h < ddlTax.length; h++) {
            var splValue = ddlTax[h].value.split('~');
            if (strTax[0] == splValue[0]) {
                ddlTax.selectedIndex = h;
            }
        }

        var hdn_costInMarkup = document.getElementById("hdn_costInMarkup_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice = document.getElementById("hdn_SellingPrice_" + EstimateItemID + "_" + SectNo + "");

        var hdn_TaxPrice = document.getElementById("hdn_TaxPrice_" + EstimateItemID + "_" + SectNo + "");
        var spnTaxPrice = document.getElementById("spnTaxPrice_" + EstimateItemID + "_" + SectNo + "");
        var spnSellingPrice = document.getElementById("spnSellingPrice_" + EstimateItemID + "_" + SectNo + "");


        var TaxValue = (Number(hdn_costInMarkup.value) * Number(hdn_TaxPercentage.value)) / 100;
        spnTaxPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);

        var SellingPrice = Number(TaxValue) + Number(hdn_costInMarkup.value);
        spnSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

        hdn_TaxPrice.value = TaxValue;
        hdn_SellingPrice.value = SellingPrice;
    }
}

function call_SaveAndStay(obj, estTotalID, EstimateItemID, SectNo) {

    var hdn_SellingPrice = document.getElementById("hdn_SellingPrice_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxPrice = document.getElementById("hdn_TaxPrice_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + "");
    hid_OtherCostValues.value = estTotalID + ',' + hdn_TaxPrice.value + ',' + hdn_SellingPrice.value + ',' + hdn_TaxID.value + ',' + hdn_TaxPercentage.value;
    __doPostBack('ctl00$ContentPlaceHolder1$UCOrderSummary$lnk_SaveAndStay', '');
}

//By Naveen for Induvidual Items
function SaveIndividualOrderStatus(sId, EstimateItemID) {
    var ItemStatusID = sId;
    var EstItemId = EstimateItemID;
    item_summary.EstJobInvIduvidualItemStatuS_Update(CompanyID, EstimateItemID, EstimateID, sId, Pgtype, NoResponse);
    if (Pgtype == 'webstoreorder') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = Order_Item_status_updated_successfully;
        lblStatusUpdateMsg.className = "msg-success";
        setTimeout("TakeOut()", 2000);
    }
    else if (Pgtype == 'job') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = Job_order_Item_status_updated_successfully;
        lblStatusUpdateMsg.className = "msg-success";
        setTimeout("TakeOut()", 2000);
    }
    else if (Pgtype == 'invoice') {
        lblStatusUpdateMsg.style.display = "block";
        lblStatusUpdateMsg.innerHTML = Invoice_order_Item_status_updated_successfully;
        lblStatusUpdateMsg.className = "msg-success";
        setTimeout("TakeOut()", 2000);
    }
}

function NoResponse() {
}