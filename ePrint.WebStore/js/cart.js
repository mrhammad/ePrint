var IsOrderedMultiple = false;
var Order_BehalfType = 'N';
var hdnCampaginManageID = 0;
var IsApplyed = false;
var MainArray = new Array();
function Calculate_GrandTotal() {
    //    var ShoppingLength = hid_ItemsLength.value;

   
    var Id;
    var hdnCount;
    var TotalNoOfCartItems = 0;
    if (document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked") != undefined && document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked") != null) {
        var hdnID = document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked");
        hdnID.value = "";
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                if (!e.disabled) {
                    if (e.checked) {
                        Id = e.id.split("chkEachLine").pop();
                        hdnID.value += Id + ',';
                        TotalNoOfCartItems = Number(TotalNoOfCartItems) + 1;
                    }
                }
            }
        }
    }
    else {
        var hdnID = '';
    }
    if (typeof hid_TotalNoOfCartItems != "undefined") {
        hid_TotalNoOfCartItems.value = TotalNoOfCartItems;
    }
    if (typeof hdnID.value != "undefined") {
        if (hdnID.value != undefined && hdnID.value != null && hdnID.value != "") {
            hdnID.value = hdnID.value.substring(0, hdnID.value.length - 1);
            hdnCount = hdnID.value.split(",");
        }
        else {
            hdnCount = 0;
        }
    }
    else {
        hdnCount = 0;
    }
    var ShoppingLength = hdnCount.length;
    var grandTotal = '0';
    var totalTax = '0';
    var hdnlbl_tax_perCartItem = '0';
    var hdnlbl_subTotal_perCart = '0';

    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    var hdnlblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlblTotalPriceID");

    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    if (ShoppingLength != "0") {
        for (var j = 0; j <= ShoppingLength - 1; j++) {
            totalTax = Number(totalTax) + Number(document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + hdnCount[j]).innerHTML.replace(',', '').replace(',', '').replace(',', ''));
            grandTotal = Number(grandTotal) + Number(document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_" + hdnCount[j]).innerHTML.replace(',', '').replace(',', '').replace(',', ''));

            hdnlbl_tax_perCartItem = Number(hdnlbl_tax_perCartItem) + Number(document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_tax_" + hdnCount[j]).value.replace(',', '').replace(',', '').replace(',', ''));
            hdnlbl_subTotal_perCart = Number(hdnlbl_subTotal_perCart) + Number(document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_subTotal_" + hdnCount[j]).value.replace(',', '').replace(',', '').replace(',', ''));
        }

        if (typeof lblTotalPriceID != "undefined") {
            if (lblTotalPriceID != undefined && lblTotalPriceID != null) {
                lblTotalPriceID.innerHTML = formatCurrency(grandTotal);
                hdnlblTotalPriceID.value = parseFloat(hdnlbl_subTotal_perCart);
            }
        }
        //lbl_grandTotal.innerHTML = ' $ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(totalTax + grandTotal), 2, '', false, false, false);

        if (typeof lbl_grandTotal != "undefined") {
            if (lbl_grandTotal != undefined && lbl_grandTotal != null) {
                lbl_grandTotal.innerHTML = CurrencySymbol + Number(hdnlbl_tax_perCartItem + hdnlbl_subTotal_perCart);
            }
        }
    }
    else {
        //lbl_grandTotal.innerHTML = ' $ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(0), 2, '', false, false, false);

        if (typeof lbl_grandTotal != "undefined") {
            if (lbl_grandTotal != undefined && lbl_grandTotal != null) {
                lbl_grandTotal.innerHTML = CurrencySymbol + formatCurrency(Number(0));
            }
        }
    }
    Final_Cart_TotalPrice();
}
Calculate_GrandTotal();

function delete_cartitems(SessionID, ID, CartID, imageID) {
    if (confirm("Are you sure you want to delete this item from the cart?") == true) {
        AutoFill.Delete_CartItem(SessionID, StoreUserID, ID, CartID, GetResult, onTimeout, onError);
        return true;
    }
    else {
        return false;
    }
}

function Pdf_Open(FileName, AccountID, Mode) {
    if (Mode == "pdf") {
        // window.open(StyleSheetPath + "/Pdf/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pdf&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
    else if (Mode == "printready") {
        //   window.open(imagePath + AccountID + "/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pr&cid=" + AccountID + "&ImageName=" + FileName, '_blank');
    }
}

function Pdf_OpenShopping(FileName, AccountID, Mode) {
    if (Mode == "pdf") {
        // window.open(StyleSheetPath + "/Pdf/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pdf&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
    else if (Mode == "printready") {
        // window.open(productImagePath + "PrintReady/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pr&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
}

function EditItem(ProductName, CartID, ProductID) {
    window.location = strSitePath + "products/" + ProductName + KeySeparator + ProductID + KeySeparator + "0" + FileExtension + "?type=edit&CartID=" + CartID + "&ProductID=" + ProductID;
}

// by natu,SetCartAdditionalddl(imageID),
function SetCartAdditionalddl(id) {
    if (id == "img_trash_0") {
        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_0");
        ddlMultiple.options[ddlMultiple.selectedIndex].selectedIndex = 0;
        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
        var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].innerText;

    }
}

function GetResult(result) {
    if (result == 1) {
        if (Rewritemodule.toLowerCase() == 'on') {
            window.location = strSitepath + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
        }
        else {
            window.location = strSitepath + "shoppingcart.aspx?ID=0&PID=0";
        }
    }
}

function onTimeout(request, context) { }
function onError(objError) { }

function Onclick_Product() {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + 'products/' + CatalogueName + KeySeparator + productid_new + FileExtension;
    }
    else {
        window.location = strSitepath + "products/productdetails.aspx?ID=" + productid_new + "&type=" + CatalogueName;
    }
}

function onclick_Checkout(page, hdnID, CID, Key, IsJobNameMandatory) {

    var replenishcount = 0;
    var orderitemcount = 0;
    var frm = document.forms[0];
    var cid;
    var IsProductsDeleted = false;
    var hdnSelfApprovalID = document.getElementById("ctl00_ContentPlaceHolder1_hdnSelfChecked");
    var CampaignName = '';

    if (validatebehalfof(page)) {

        if (page == 'checkout') {
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.name.indexOf('ddlMultiple') != -1) {
                    if (e.getAttribute("isRequired") == 'True' && (e.selectedIndex == 0 || e.selectedIndex == -1)) {
                        window.alert('Please select shopping cart option');
                        return false;
                    }
                }
            }
        }
        debugger;
        if (page == 'checkout') {
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                    if (!e.disabled) {
                        if (e.checked) {
                            cid = e.id.split("chkEachLine").pop();
                            if (IsJobNameMandatory.toLowerCase() == 'true') {
                                var IsJobNameEmpty = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + cid + "");
                                if (typeof IsJobNameEmpty != 'undefined' && IsJobNameEmpty != undefined && IsJobNameEmpty != null &&
                                    typeof IsJobNameEmpty.value != 'undefined' && IsJobNameEmpty.value != undefined && IsJobNameEmpty.value != null &&
                                    IsJobNameEmpty.value != '') {

                                } else {
                                    alert(SpecialDecode(jobScreenName) + ' are mandatory, Please enter ' + SpecialDecode(jobScreenName));
                                    IsJobNameEmpty.focus();
                                    return false;
                                }
                            }

                            if (document.getElementById("hdnisstockreplenishitem_" + cid + "").value.toLowerCase() == 'true') {
                                replenishcount = 1;
                            }
                            else {
                                orderitemcount = 1;
                            }

                            if (IsCampaignEnabled.toLowerCase() == "true") {
                                var lblcampaginname = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CampaignName_" + cid + "").innerHTML;
                                hdnCampaginManageID = document.getElementById("hdnCampaginManageID_" + cid + "").value;
                                var isManageCampaignDeleted = document.getElementById("isManageCampaignDeleted_" + cid + "").value.toLowerCase();
                                if (isManageCampaignDeleted == 0) {
                                    isManageCampaignDeleted = "true";
                                }

                                if (CampaignName == '') {
                                    CampaignName = lblcampaginname;
                                }
                                if (CampaignName.toLowerCase() != lblcampaginname.toLowerCase()) {
                                    window.alert(Campaign_Validator_Cart_Page_Key_During_Checkout);
                                    return false;
                                }
                                if (isManageCampaignDeleted != "true") {
                                    window.alert(Campaign_sdeleted_during_Checkout_validator);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
        }
        debugger;
        if (Number(replenishcount) != 1 || Number(orderitemcount) != 1) {
            var frm = document.forms[0];
            var hdnID = document.getElementById(hdnID);
            hdnID.value = "";
            var Id;
            var hdnCount = 0;
            var DeletedProductsName = '';
            var DeletedProductsCount = 0;
            var CategoryNotReqApp = 0;
            var CategoryReqApp = 0;
            var DeptNotReqApp = 0;
            var DeptReqApp = 0;
            var Self_ItemID;
            var SelectedItemCount = 0;
            var ApprovedItemCount = 0;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];

                if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                    if (!e.disabled) {
                        if (e.checked) {
                            SelectedItemCount++;

                            Id = e.id.split("chkEachLine").pop();
                            hdnID.value += Id + ',';

                            var hdnProdDeltd = document.getElementById("ctl00_ContentPlaceHolder1_hdnProdDeltd_" + Id).value;
                            if (hdnProdDeltd == 'true') {
                                IsProductsDeleted = true;
                                var hdnProdName = document.getElementById("ctl00_ContentPlaceHolder1_hdnProductName_" + Id).value;
                                DeletedProductsName += SpecialDecode(hdnProdName) + ', ';
                                DeletedProductsCount++;
                            }
                            if (ApprovalSystem == 'true') {
                                var hdnCtgryNotReqApproval = document.getElementById("ctl00_ContentPlaceHolder1_hdnCtgryNotReqApproval_" + Id).value;
                                if (hdnCtgryNotReqApproval == 'true') {
                                    CategoryNotReqApp++;
                                }
                                else {
                                    CategoryReqApp++;
                                }

                                var hdnDeptNotReqApproval = document.getElementById("ctl00_ContentPlaceHolder1_hdnDeptNotReqApproval_" + Id).value;
                                if (hdnDeptNotReqApproval == 'true') {
                                    DeptNotReqApp++;
                                }
                                else {
                                    DeptReqApp++;
                                }
                            }
                        }
                    }
                }
                if (ApprovalType.toLowerCase() == 's') {
                    if (e.type == 'checkbox' && e.name.indexOf('chkEachApprove') != -1) {
                        Self_ItemID = e.id.split("chkEachApprove").pop();
                        var Is_ItemSelected = document.getElementById("ctl00_ContentPlaceHolder1_chkEachLine" + Self_ItemID);

                        if (e.checked && Is_ItemSelected.checked) {
                            ApprovedItemCount++;
                            hdnSelfApprovalID.value += Self_ItemID + ',';
                        }
                    }
                }
            }
            debugger;
            if (ApprovalSystem == 'true') {



                if (UserType != 'm') {
                    if (CategoryNotReqApp > 0 && CategoryReqApp > 0) {
                        //alert(Category_ReqApproval_Msg);
                        //return false;     

                    }
                    if (DeptNotReqApp > 0 && DeptReqApp > 0) {
                        alert(Category_ReqApproval_Msg);
                        return false;
                    }
                }
                if (CategoryNotReqApp > 0) {
                    AutoFill.CatgoryNotReqApproval("true", onTimeout, onError);
                }
                if (CategoryReqApp > 0) {
                    AutoFill.CatgoryNotReqApproval("false", onTimeout, onError);
                }

                if (DeptNotReqApp > 0) {
                    AutoFill.DepartmentNotReqApproval("true", onTimeout, onError);
                }
                if (DeptReqApp > 0) {
                    AutoFill.DepartmentNotReqApproval("false", onTimeout, onError);
                }
            }

            if (IsProductsDeleted) {
                DeletedProductsName = DeletedProductsName.substring(0, DeletedProductsName.length - 2);
                if (DeletedProductsCount > 1) {
                    alert(Order_Deltd_Prod_Msg1 + DeletedProductsName + Order_Deltd_Prod_Msg2);
                }
                else {
                    alert(Order_Deltd_Prod_Msg4 + DeletedProductsName + Order_Deltd_Prod_Msg3);
                }
                return false;
            }
            else {
                if (hdnID.value != "") {
                    hdnID.value = hdnID.value.substring(0, hdnID.value.length - 1);
                    hdnCount = hdnID.value.split(",");
                }
                if (page == "checkout" && StatusTitle.toLowerCase() == "account on hold") {
                    alert(Accountsonhold);
                    //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
                    return false;
                }


                if (hdnCount != 0) {
                    for (var i = 0; i < hdnCount.length; i++) {
                        lbl_CatrItemId = hdnCount[i];
                        txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + hdnCount[i] + "");
                        var txt_jobName_value = '';
                        if (txt_jobName != null && txt_jobName != undefined) {
                            txt_jobName_value = txt_jobName.value;
                        }
                        hid_finalSave.value = hid_finalSave.value + "CartItemID±" + lbl_CatrItemId + "»JobName±" + SpecialDecode(txt_jobName_value) + "µ";
                    }
                }


                Save_Cart_AdditionalOptions();
                hid_SaveToAdditionalItems.value = document.getElementById("ctl00_ContentPlaceHolder1_hid_SaveToAdditionalItems").value;
                if (page == "checkout") {
                    if (hdnCount.length > 0) {
                        if (Number(replenishcount) != 1) {

                            if (IsSpendLimitEnable.toString().toLowerCase() == "true") {
                                if (page == 'checkout') {
                                    if (hdnCount != 0) {
                                        btn_proceedCheckout.style.display = "none";
                                        loadingimg('div_btnsave', 'div_btnsaveprocess');
                                    }
                                }
                                var AmountAlreadySpent;
                                var SpendLimitAmount;
                                var SelectedCartItemIDs;
                                var SelectedCartItemIDsWithData = '';
                                var SpendLimitData1 = new Array();
                                var SpendLimitDataFinal = new Array();
                                SelectedCartItemIDs = hdnID.value.split(',');
                                SpendLimitData1 = SpendLimitData.split('µ');
                                var Subtotal = 0;

                                for (k = 0; k < SelectedCartItemIDs.length; k++) {

                                    for (k1 = 0; k1 < SpendLimitData1.length - 1; k1++) {
                                        if (parseInt(SelectedCartItemIDs[k]) == parseInt(SpendLimitData1[k1].split('±')[0])) {

                                            SelectedCartItemIDsWithData = SelectedCartItemIDsWithData + SpendLimitData1[k1] + "µ";
                                            break;
                                        }
                                    }
                                }
                                SpendLimitDataFinal = SelectedCartItemIDsWithData.split('µ')[0];
                                SpendLimitAmount = SpendLimitDataFinal.split('±')[2];
                                AmountAlreadySpent = SpendLimitDataFinal.split('±')[3];
                                Subtotal = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID").innerHTML.replace(',', '');
                                if (Number(Subtotal) > (Number(SpendLimitAmount) - Number(AmountAlreadySpent))) {
                                   
                                    var spendlimit = formatCurrency(Number(SpendLimitAmount) - Number(AmountAlreadySpent));
                                    alert('You have exceeded your spend limit, you have ' + CurrencySymbol + spendlimit + ' of your spend limit left');
                                    div_btnsaveprocess.style.display = "none";
                                    div_btnsave.style.display = "block";
                                    btn_proceedCheckout.style.display = "block";
                                    return false;
                                }
                            }

                            if (Pdfvalues != "") {
                                var CopyPdfvalues = Pdfvalues;
                                var CartItemIds = new Array();
                                var Pdfvalues1 = new Array();
                                var FilterPDFvalues = new Array();
                                CartItemIds = hdnID.value.split(',');
                                Pdfvalues1 = Pdfvalues.split('>>');
                                var b = Pdfvalues.split('_')[2];
                                for (j = 0; j < CartItemIds.length; j++) {
                                    for (k = 0; k < Pdfvalues1.length; k++) {
                                        if (CartItemIds[j].indexOf(Pdfvalues1[k].split('_')[2]) > -1) {
                                            FilterPDFvalues[j] = Pdfvalues1[k];
                                        }
                                    }
                                }

                                for (i = 0; i < CartItemIds.length; i++) {
                                    if (CartItemIds[i].indexOf(FilterPDFvalues[i].split('_')[2]) > -1) {
                                        if (FilterPDFvalues[i].indexOf("true") > -1 && FilterPDFvalues[i].indexOf("false") > -1) {
                                            var result = confirm("The PDF file for your product is being created. This may take upto 10 minutes. you can navigate away from this screen, proceed to checkout, or refresh this screen in 10 minutes to see the PDF.");
                                            break;
                                        }
                                    }
                                }
                                if (result == false) {
                                    loadingimg('div_btnsaveprocess', 'div_btnsave');
                                    btn_proceedCheckout.style.display = "block";
                                    return false;
                                }
                            }
                            if (IsSpendLimitEnable.toString().toLowerCase() == "false") {
                                if (page == 'checkout') {
                                    if (hdnCount != 0) {
                                        btn_proceedCheckout.style.display = "none";
                                        loadingimg('div_btnsave', 'div_btnsaveprocess');
                                    }
                                }
                            }

                            if (ProductStockManagement == 'true') {
                                AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, hdnSelfApprovalID.value, IsOrderedMultiple, Order_BehalfType, 'BackOrder_Check', Resultcheck, onTimeout, onError);
                            }
                            else {
                                AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, hdnSelfApprovalID.value, IsOrderedMultiple, Order_BehalfType, 'No', Resultcheck, onTimeout, onError);
                            }
                        }
                        else {
                            AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, hdnSelfApprovalID.value, IsOrderedMultiple, Order_BehalfType, 'No', Resultcheck, onTimeout, onError);
                        }
                    }
                    else {
                        alert(Please_select_atlease_one_checkbox);
                        return false;
                    }
                }

                else {
                    loadingimg('div_btnsave2', 'div_btnsaveprocess2');
                    AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, hdnSelfApprovalID.value, IsOrderedMultiple, Order_BehalfType, 'No', ResultShopping(CID, Key), onTimeout, onError);
                }

                debugger;
                return false;
            }
        }
        else {
            alert(replenish_proceedtocheckout_validation_msg);
            return false;
        }
    }
    else {
        return false;
    }
}



function validatebehalfof(page) {
    debugger;
    var IsBehalfDept = 0;
    var DeptID = 0;
    var ContactID = 0;
    var IsDifferentID = 0;
    var IsDifferentDeptID = 0;
    var IsBehalfUser = 0;
    var IsBehalfNone = 0;
    var c = 0;
    var d = 0;
    var frm = document.forms[0];
    IsOrderedMultiple = false;

    var IsDepartmentOrder = 0;
    var IsUserOrder = 0;
    var IsSelfOrder = 0;

    if (page == 'checkout') {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                if (!e.disabled) {
                    if (e.checked) {
                        cid = e.id.split("chkEachLine").pop();
                        if (document.getElementById("hdnorderbehalfuser_" + cid + "").value != 0 && document.getElementById("hdnorderbehalfdept_" + cid + "").value != 0) {
                            IsBehalfDept = 1;
                            d = Number(d) + 1;
                            if (Number(d) == 1) {
                                DeptID = (document.getElementById("hdnorderbehalfdept_" + cid + "").value);
                            }
                            if (Number(DeptID) != Number(document.getElementById("hdnorderbehalfdept_" + cid + "").value)) {
                                IsDifferentDeptID = 1;
                            }
                            IsDepartmentOrder++;
                            //AutoFill.StoreBehalfTypeSession("D", onTimeout, onError);
                        }
                        else if (document.getElementById("hdnorderbehalfuser_" + cid + "").value != 0) {
                            IsBehalfUser = 1;
                            c = Number(c) + 1;
                            if (Number(c) == 1) {
                                ContactID = (document.getElementById("hdnorderbehalfuser_" + cid + "").value);
                            }
                            if (Number(ContactID) != Number(document.getElementById("hdnorderbehalfuser_" + cid + "").value)) {
                                IsDifferentID = 1;
                            }
                            IsUserOrder++;
                            //AutoFill.StoreBehalfTypeSession("U", onTimeout, onError);
                        }
                        else {
                            IsBehalfNone = 1;
                            IsSelfOrder++;
                            //AutoFill.StoreBehalfTypeSession("N", onTimeout, onError);
                        }
                    }
                }
            }
        }

        debugger;
        if (IsDepartmentOrder > 0 && IsUserOrder > 0) {
            Order_BehalfType = 'N';
        }
        else if (IsDepartmentOrder > 0) {
            if (IsSelfOrder > 0) {
                Order_BehalfType = 'N';
            }
            else if (IsDifferentDeptID == 1) {
                Order_BehalfType = 'N';
            }
            else {
                Order_BehalfType = 'D';
            }
        }
        else if (IsUserOrder > 0) {
            if (IsSelfOrder > 0) {
                Order_BehalfType = 'N';
            }
            else if (IsDifferentID == 1) {
                Order_BehalfType = 'N';
            }
            else {
                Order_BehalfType = 'U';
            }
        }
        else if (IsDepartmentOrder == 0 && IsUserOrder == 0 && IsSelfOrder > 0) {
            Order_BehalfType = 'N';
        }

        if (IsSpendLimitEnable.toString().toLowerCase() != "true") {
            if (IsBehalfUser == 1 && IsBehalfDept == 1) {
                //            alert("You cannot Proceed as there are items that contains both behalf of dept and users");
                //            return false;
                if (window.confirm(Warning_Msg_Multiple_Users_Order_during_Checkout)) {
                    IsOrderedMultiple = true;
                    //AutoFill.StoreBehalfTypeSession("N", onTimeout, onError);
                    return true;
                }
                else {
                    return false;
                }
            }
            else if ((IsBehalfUser == 1 && IsBehalfDept == 0 && IsDifferentID == 1) || (IsBehalfUser == 1 && IsBehalfDept == 0 && IsBehalfNone == 1)) {
                //            alert("You cannot Proceed as the items contains more than one behalf user");
                //            return false;
                if (window.confirm(Warning_Msg_Multiple_Users_Order_during_Checkout)) {
                    IsOrderedMultiple = true;
                    //AutoFill.StoreBehalfTypeSession("N", onTimeout, onError);
                    return true;
                }
                else {
                    return false;
                }
            }
            else if ((IsBehalfUser == 0 && IsBehalfDept == 1 && IsDifferentDeptID == 1) || (IsBehalfUser == 0 && IsBehalfDept == 1 && IsBehalfNone == 1)) {
                //            alert("You cannot Proceed as the items contains more than one behalf department");
                //            return false;
                if (window.confirm(Warning_Msg_Multiple_Users_Order_during_Checkout)) {
                    IsOrderedMultiple = true;
                    //AutoFill.StoreBehalfTypeSession("N", onTimeout, onError);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else if (IsSpendLimitEnable.toString().toLowerCase() == "true") {
            if (IsBehalfUser == 1 && IsBehalfDept == 1) {
                alert("You cannot Proceed as there are items that contains both behalf of dept and users");
                return false;
            }
            else if ((IsBehalfUser == 1 && IsBehalfDept == 0 && IsDifferentID == 1) || (IsBehalfUser == 1 && IsBehalfDept == 0 && IsBehalfNone == 1)) {
                alert("You cannot Proceed as the items contains more than one behalf user");
                return false;

            }
            else if ((IsBehalfUser == 0 && IsBehalfDept == 1 && IsDifferentDeptID == 1) || (IsBehalfUser == 0 && IsBehalfDept == 1 && IsBehalfNone == 1)) {
                alert("You cannot Proceed as the items contains more than one behalf department");
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    }
    else {
        return true;
    }
}

function Resultcheck(Result) {
    debugger;
    var _splititemtitle = Result.split('♠');
    var _isbackorder = _splititemtitle[0].toString().toLowerCase();
    if (_isbackorder == 'true') {
        if (Rewritemodule.toLowerCase() == 'on') {
            window.location = strSitepath + "checkout" + FileExtension;
        }
        else {
            if (IsCampaignEnabled.toLowerCase() == "true") {
                window.location = strSitepath + "checkout.aspx?CampID=" + hdnCampaginManageID + "";
            }
            else {
                window.location = strSitepath + "checkout.aspx";
            }
        }
    }
    else {
        btn_proceedCheckout.style.display = "block";
        loadingimg('div_btnsaveprocess', 'div_btnsave');
        var CheckCumulative = _splititemtitle[2].toString().toLowerCase();
        if (CheckCumulative == 'true') {
            if (_splititemtitle.length > 0) {
                var _productnames = _splititemtitle[1].split('♣');
                var titles = "";
                for (var i = 0; i < _productnames.length; i++) {

                    if (_productnames.length == 1) {
                        titles = _productnames[i];
                    }
                    else {

                        if (titles == "") {
                            titles = _productnames[i];
                        }
                        else {
                            titles = titles + "," + _productnames[i];
                        }
                    }
                }
            }
            alert("One or more of the products you are ordering has insufficient stock to proceed.\nPlease remove or amend the quantity for this product(s): " + titles);
        } else {
            alert("The total quantity of the item you are ordering exceeds the available quantity in stock. Please reduce the quantity and try again.");
        }
    }
}

function ResultShopping(CID, Key) {
    debugger
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
    }
    else {
        if (Key != '' && Key != 'HomePage') {
            window.location = strSitepath + "products/searchproducts.aspx?sp=" + Key;
        }
        else if (Key == 'HomePage') {
            window.location = strSitepath;
        }
        else {
            window.location = strSitepath + "products/product.aspx?ID=" + CID;
        }
    }
}

var time_left = 10;
var cinterval;

function time_dec() {
    time_left--;
    if (time_left == 0) {
        clearInterval(cinterval);
        if (typeof cntDown != 'undefined' && cntDown != null && cntDown != undefined && cntDown.innerHTML != "No items in cart") {
            productAdded.style.display = "none";
        }
    }
}
cinterval = setInterval('time_dec()', 1000);

function Onclick_img_plus(id) {

    $(document).ready(function () {
        $("#lbl_productDetails_div_" + id).show(200, function () { });
        //$("#lbl_productDetails_div").slideToggle("slow");
        $("#img_plus_" + id).hide();
        $("#img_minus_" + id).show();
    });
}

function Onclick_img_minus(id) {

    $(document).ready(function () {
        $("#lbl_productDetails_div_" + id).hide(200, function () { });
        $("#img_plus_" + id).show();
        $("#img_minus_" + id).hide();
    });
}

$(document).ready(function () {
    $(window).load(function () {
        $(".img_minus").hide();
        $(".lbl_productDetails_div").hide();
    });
});

function Cart_CalculatePrice_Question(Formula, ID) {
    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    var OtherCostID = document.getElementById("lblQuestionID_" + ID + "").innerHTML;

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value)) {

        var FormulaTag = Formula;
        for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value))
                .replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value))
                .replace('[$TotalNo.ofCartItems$]', Number(hid_TotalNoOfCartItems.value)).replace('[$totalno.ofcartitems$]', Number(hid_TotalNoOfCartItems.value));
        }

        var dd = eval(FormulaTag);
        if (!isNaN(dd)) {
            AutoFill.CalculateFormulaCost(dd, ID, GetResult1, onTimeout, onError);
        }
        else {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
        Final_Cart_TotalPrice();
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        Final_Cart_TotalPrice();
    }
}

function GetResult1(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        //document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = '$ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = formatCurrency(NewResult[0]);
        Final_Cart_TotalPrice();
    }
}

function Cart_Onchange_MultipleChoice(ID) {
    var OthercostID = document.getElementById("lblMultipleID_" + ID + "").innerHTML;
    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);
    var hdnID = document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked");
    hid_TotalExTax.value = "";
    hid_TotalIncTax.value = "0";
    hid_TotalQty.value = "";
    if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "0.00";
            }
            else {
                var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                var MultipleValue = ddlMultipleValue.split('~');
                var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
                hid_TotalExTax.value = lblTotalPriceID.innerHTML;
                hid_TotalExTax.value = hid_TotalExTax.value.replace(',', '');
                if (hdnID.value != "") {
                    hdnCount = hdnID.value.split(",");
                }
                else {
                    hdnCount = 0;
                }
                var ShoppingLength = hdnCount.length;
                if (ShoppingLength != "0") {
                    for (i = 0; i <= ShoppingLength - 1; i++) {
                        var lbl_tax = document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + hdnCount[i]);
                        var lbl_qty = document.getElementById("ctl00_ContentPlaceHolder1_lbl_qty_" + hdnCount[i]);
                        hid_TotalIncTax.value = Number(hid_TotalIncTax.value) + Number(lbl_tax.innerHTML);
                        hid_TotalQty.value = Number(hid_TotalQty.value) + Number(lbl_qty.innerHTML);
                    }
                }
                hid_TotalIncTax.value = Number(hid_TotalExTax.value) + Number(hid_TotalIncTax.value);
                var FormulaTagMul = '';
                FormulaTagMul = MultipleValue[0];
                for (var i = 0; i <= FormulaTagMul.length; i++) {
                    FormulaTagMul = FormulaTagMul.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value))
                        .replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value))
                        .replace('[$TotalNo.ofCartItems$]', Number(hid_TotalNoOfCartItems.value)).replace('[$totalno.ofcartitems$]', Number(hid_TotalNoOfCartItems.value));
                }
                var dd = eval(FormulaTagMul);
                if (!isNaN(dd)) {
                    //AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(MultipleValue[1]), ID, OthercostID, GetResultMultiple, onTimeout, onError);
                    AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(MultipleValue[1]), ID, GetResultMultiple, onTimeout, onError);
                }
                else {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "0.00";
                    Final_Cart_TotalPrice();
                }
                chkMultiple.checked = true;
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "0.00";
            Final_Cart_TotalPrice();
        }
    }
    else {
        chkMultiple.checked = false;
        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "0.00";
        Final_Cart_TotalPrice();
    }
}

function GetResultMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        //document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = '$ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);\
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = formatCurrency(NewResult[0]);
        Final_Cart_TotalPrice();
    }
}

//Tocalculate_totalPrice()
function Cart_Additional_Price() {
    if (typeof hid_QuestionLenght != 'undefined') {
        if (hid_QuestionLenght.value != "0") {
            for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
                var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;

                var FormulaTag = Formula1;
                for (var i = 0; i <= Formula1.length; i++) {
                    FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
                }
                Cart_CalculatePrice_Question(Formula1, q);
            }
        }

        if (typeof hid_QuestionLenght != 'undefined') {
            if (hid_QuestionLenght != undefined && hid_QuestionLenght != null) {
                if (hid_MultipleLenght.value != "0") {
                    for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
                        Cart_Onchange_MultipleChoice(c);
                    }
                }

                Final_Cart_TotalPrice();
            }
        }
    }
}
Cart_Additional_Price();

function Final_Cart_TotalPrice() {
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    var hdnlblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlblTotalPriceID");
    var lblTotaltaxID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");
    var hid_MultiplePrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_MultiplePrice");

    if (typeof hid_QuestionLenght != 'undefined') {
        if (hid_QuestionLenght != undefined && hid_QuestionLenght != null) {
            if (hid_MultipleLenght.value != "0") {
                for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(',', '').replace(',', '').replace(',', ''));
                }
            }
        }
    }
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    hid_MultiplePrice.value = MultiplePrice;

    if (typeof lblTotalPriceID != 'undefined') {
        if (lblTotalPriceID != null & lblTotalPriceID != undefined) {
            var CartTotalPrice = Number(hdnlblTotalPriceID.value.replace(',', '')) + Number(MultiplePrice);  //Number(QuestionPrice) + Number(MatrixPrice);
            TaxOnChange(CartTotalPrice);
        }
    }
}

function TaxOnChange(CartTotalPrice) {

    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");
    var hdnlblTotaltaxID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlblTotaltaxID");
    var TotalPrice = CartTotalPrice;
    var TotalTax = 0;

    var Id;
    var hdnCount;
    var TotalMultipleTax = 0;

    TotalMultipleTax = Number((Number(hid_MultiplePrice.value) * Number(TaxRate)) / 100);

    var hdnID = document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked");
    hdnID.value = "";
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
            if (!e.disabled) {
                if (e.checked) {
                    Id = e.id.split("chkEachLine").pop();
                    hdnID.value += Id + ',';
                }
            }
        }
    }
    if (typeof hdnID.value != "undefined") {
        if (hdnID.value != undefined && hdnID.value != null && hdnID.value != "") {
            hdnID.value = hdnID.value.substring(0, hdnID.value.length - 1);
            hdnCount = hdnID.value.split(",");
        }
        else {
            hdnCount = 0;
        }
    }
    else {
        hdnCount = 0;
    }
    var ShoppingLength = hdnCount.length;


    if (TotalPrice != '0.00') {
        for (var j = 0; j <= ShoppingLength - 1; j++) {
            TotalTax = Number(TotalTax) + Number(document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + hdnCount[j]).innerHTML.replace(',', '').replace(',', '').replace(',', ''));
        }
        lblTotalTax.innerHTML = formatCurrency(TotalTax + TotalMultipleTax);
        hdnlblTotaltaxID.value = parseFloat(TotalTax + TotalMultipleTax);
    }
    else {
        lblTotalTax.innerHTML = "0.00";
        hdnlblTotaltaxID.value = "0";
    }
    var TotalSellingPrice = Number(TotalPrice) + Number(hdnlblTotaltaxID.value);
    //lbl_grandTotal.innerHTML = ' $ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalSellingPrice), 2, '', false, false, false);
    if (typeof lbl_grandTotal != "undefined") {
        if (lbl_grandTotal != undefined && lbl_grandTotal != null) {
            lbl_grandTotal.innerHTML = CurrencySymbol + formatCurrency(TotalSellingPrice);
        }
    }

}

/* Return currency in $ 223,000.00 formate (thousands separator) */
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));

    return (((sign) ? '' : '-') + num + '.' + cents);
}
/* Return currency in $ 223,000.00 formate (thousands separator) */

function Save_Cart_AdditionalOptions() {
    var SaveToAdditionalItemsMultiple = '';

    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var Check = document.getElementById("chkMultiple_" + j);

            if (Check.checked) {

                var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;
                var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);

                //if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {

                var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].innerText;
                ddlMultipleValue = ddlMultipleValue.split('~');

                var FormulaTagMul = ddlMultipleValue[0];
                var Formula = '';

                for (var i = 0; i <= Formula.length; i++) {
                    FormulaTagMul = FormulaTagMul.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value))
                        .replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value))
                        .replace('[$TotalNo.ofCartItems$]', Number(hid_TotalNoOfCartItems.value)).replace('[$totalno.ofcartitems$]', Number(hid_TotalNoOfCartItems.value));
                }

                var MarkUp = ddlMultipleValue[1];
                var SelectedID = ddlMultipleValue[2];
                var SelectedPrice = eval(FormulaTagMul);

                var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                if (isNaN(MarkupValue)) {
                    MarkupValue = 0;
                }
                Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                var CartAdditionalTaxPercentage = document.getElementById("lblTaxRate").innerHTML;
                var CartAdditionalTaxID = document.getElementById("lblTaxID").innerHTML;
                var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(',', '').replace(',', '').replace(',', '');
                var CartAdditionalTaxValue = Number((TotalPrice * CartAdditionalTaxPercentage) / 100);

                //if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {
                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "StoreUserID»" + StoreUserID + "±SessionID»" + NewSessionID + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±CartAdditionalTaxID»" + CartAdditionalTaxID + "±CartAdditionalTaxPercentage»" + CartAdditionalTaxPercentage + "±CartAdditionalTaxValue»" + CartAdditionalTaxValue + "µ";
                //}
                //}
            }
        }
    }

    var AllAdditionalItemsDetails = '';
    if (SaveToAdditionalItemsMultiple != '') {
        hid_SaveToAdditionalItems.value = SaveToAdditionalItemsMultiple;
    }
}

function ValidateReject() {
    var txtReason = document.getElementById("ctl00_ContentPlaceHolder1_txtReason");
    var divReason = document.getElementById("divReason");
    if (txtReason.value != "") {
        loadingimg('DivReject', 'DivRejectloa');
        return true;
    }
    else {

        // loadingimg('DivReject', 'DivRejectloa');
        txtReason.style.display = "block";
        divReason.style.display = "block";
        return false;
    }
}

// added by rk on 29-03-2013 for allowgrouprun case.

function ProductIDandQuantity() {
    var ProductID = 0;
    var CartItemID = 0;
    var TotalQuantity = 0;
}



function allowgrouprun_calculations() {

    debugger;

    IsApplyed = false;
    var shippingCart_Table = document.getElementById('shippingCart_Table');

    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            if (shippingCart_TableCount[i].checked) {
                var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
                var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
                var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
                var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnMatrixType = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnMatrixType_'));
                var hdnDimension = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnDimension_'));

                var TotalQuantity = 0;
                var CartItemID = 0;
                var flag = 0;

                if (hdnGroupRun.value.toLowerCase() == 'true') {

                    for (var j = 0; j < MainArray.length; j++) {
                        if (hdnProductID.value == MainArray[j].ProductID) {
                            TotalQuantity = MainArray[j].TotalQuantity;
                            CartItemID = MainArray[j].CartItemID;
                            MainArray.splice(j, 1);
                            flag = 1;
                            break;
                        }
                        if (flag == 1) {
                            break;
                        }
                    }
                    var ClassObject = new ProductIDandQuantity();
                    ClassObject.ProductID = hdnProductID.value;
                    if (CartItemID == 0) {
                        ClassObject.CartItemID = hdnCartItemID.value;
                    }
                    else {
                        ClassObject.CartItemID = CartItemID + "±" + hdnCartItemID.value;
                    }
                    if (hdnMatrixType.value == 'G') {
                        ClassObject.TotalQuantity = parseFloat(TotalQuantity) + parseFloat(hdnDimension.value);
                    }
                    else {
                        ClassObject.TotalQuantity = parseInt(TotalQuantity) + parseInt(hdnQuantity.value);
                    }

                    MainArray.push(ClassObject);
                    TotalQuantity = 0;
                }
                else {// else is required for reorder the same products from myorder 
                    var ClassObject = new ProductIDandQuantity();
                    ClassObject.ProductID = hdnProductID.value;
                    ClassObject.CartItemID = hdnCartItemID.value;
                    if (hdnMatrixType.value == 'G') {
                        ClassObject.TotalQuantity = hdnDimension.value;
                    }
                    else {
                        ClassObject.TotalQuantity = hdnQuantity.value;
                    }

                    MainArray.push(ClassObject);
                    TotalQuantity = 0;
                }
            }
            else {// for unselected items with grourun enabled  
                var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
                var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));
                var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnbfrGPunitprice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnbfrGPunitprice_'));
                var QtyPerRow = document.getElementById("ctl00_ContentPlaceHolder1_lbl_qty_" + hdnCartItemID.value).innerHTML;
                var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
                var uncheckCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
                var hdnMatrixType = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnMatrixType_'));
                var hdnDimension = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnDimension_'));

                if (hdnMatrixType.value == 'G') {
                    QtyPerRow = hdnDimension.value;
                }

                if (hdnCartItemID.value == uncheckCartItemID.value && hdnGroupRun.value.toLowerCase() == 'true') {
                    var cartid = hdnCartItemID.value;
                    asyncState = false;
                    AutoFill.GetGroupRunUnitPrice(parseInt(hdnProductID.value), parseFloat(QtyPerRow), cartid, txt_CouponCode.value, AccountID, UpdateUnitPriceUnchecked, onTimeout, onError);
                    AutoFill.UpdateAdditionalValues(parseInt(hdnProductID.value), parseFloat(QtyPerRow), cartid, SetAdditionalOptions, onTimeout, onError);
                }
            }
        }
    }
    hid_StoreCredit.value = 0;
    for (var i = 0; i < MainArray.length; i++) {
        var ArrCartItemID = MainArray[i].CartItemID.split("±");
        if (ArrCartItemID.length > 1) {
            lblNotifyGprunDiscount.innerHTML = "Please note that by ordering the same product multiple times in your cart you are receiving a multi order discount";
        }
        for (var m = 0; m < ArrCartItemID.length; m++) {
            sleep(100);
            asyncState = false;
            AutoFill.GetGroupRunUnitPrice(parseInt(MainArray[i].ProductID), parseFloat(MainArray[i].TotalQuantity), ArrCartItemID[m], txt_CouponCode.value, AccountID, parseFloat(hid_StoreCredit.value), GetGPrunPrice, onTimeout, onError);
            AutoFill.UpdateAdditionalValues(parseInt(MainArray[i].ProductID), parseFloat(MainArray[i].TotalQuantity), ArrCartItemID[m], SetAdditionalOptions, onTimeout, onError);
        }
    }

    MainArray.splice(0, MainArray.length); // must empty the array so that new selected values will be stored on second time click of checkboxs in table grid
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    while ((new Date().getTime() - start) < milliseconds) {
        // Do nothing
    }
}

function UpdateUnitPriceUnchecked(UnitPrice) {
    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    var SplitUnitPrice;

    SplitUnitPrice = UnitPrice.split("»");
    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            if (shippingCart_TableCount[i].checked == false) {
                var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));
                var lbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_" + hdnCartItemID.value);
                var hdnlbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_subTotal_" + hdnCartItemID.value);
                var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
                var QtyPerRow = document.getElementById("ctl00_ContentPlaceHolder1_lbl_qty_" + hdnCartItemID.value).innerHTML;
                if (hdnCartItemID.value == SplitUnitPrice[2]) {
                    lbl_unitPrice.innerHTML = formatCurrency(SplitUnitPrice[0]);
                    // var subtotalPerCartItemID = parseFloat(SplitUnitPrice[0]) * parseFloat(QtyPerRow);
                    var subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]);
                    lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                    hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                }
            }
        }
    }
}

function GetGPrunPrice(UnitPriceData) {
    // alert(UnitPrice);

    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    var SplitUnitPrice;

    SplitUnitPrice = UnitPriceData.split("»");
    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            if (shippingCart_TableCount[i].checked) {
                var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
                var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
                var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
                var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));

                var lbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_" + hdnCartItemID.value);
                var hdnlbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_subTotal_" + hdnCartItemID.value);
                var lbl_tax_perCartItemID = document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + hdnCartItemID.value);
                var hdnlbl_tax_perCartItemID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_tax_" + hdnCartItemID.value);

                var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
                var QtyPerRow = document.getElementById("ctl00_ContentPlaceHolder1_lbl_qty_" + hdnCartItemID.value).innerHTML;
                var lbl_CouponCodeDiscount = document.getElementById("ctl00_ContentPlaceHolder1_lbl_Discount_" + hdnCartItemID.value);
                var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
                var lblStoreCredit = document.getElementById('ctl00_ContentPlaceHolder1_lblStoreCredit');
                
                if (hdnGroupRun.value.toLowerCase() == 'true') {

                    if (hdnProductID.value == SplitUnitPrice[1] && hdnCartItemID.value == SplitUnitPrice[2]) {
                        lbl_unitPrice.innerHTML = formatCurrency(SplitUnitPrice[0]);
                        // var subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]) + (parseFloat(SplitUnitPrice[0]) * parseFloat(QtyPerRow));
                        var subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]);
                        lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                        hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                        lbl_tax_perCartItemID.innerHTML = parseFloat(SplitUnitPrice[4]);
                        hdnlbl_tax_perCartItemID.value = parseFloat(SplitUnitPrice[4]);
                       
                        hid_StoreCredit.value = parseFloat(hid_StoreCredit.value) + parseFloat(SplitUnitPrice[6]);
                        lblStoreCredit.innerHTML = "Store credit used in cart: " + formatCurrency(hid_StoreCredit.value) + CurrencySymbol;
                        
                        Calculate_GrandTotal();
                        Cart_Additional_Price();
                        ReRuncalTotal();

                        if (SplitUnitPrice[5] == '') {
                            lbl_CouponCodeDiscount.innerHTML = '0.00';
                        }
                        else if (txt_CouponCode.value != '') {
                            IsApplyed = true;
                            lbl_CouponCodeDiscount.innerHTML = formatCurrency(SplitUnitPrice[5].split('~')[0]);
                        }
                    }
                }
                else {// else is required for reorder the same products from myorder
                    if (hdnCartItemID.value == SplitUnitPrice[2]) {
                        lbl_unitPrice.innerHTML = formatCurrency(SplitUnitPrice[0]);
                        // var subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]) + (parseFloat(SplitUnitPrice[0]) * parseFloat(QtyPerRow));
                        var subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]);
                        lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                        hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                        lbl_tax_perCartItemID.innerHTML = parseFloat(SplitUnitPrice[4]);
                        hdnlbl_tax_perCartItemID.value = parseFloat(SplitUnitPrice[4]);
                        hid_StoreCredit.value = parseFloat(hid_StoreCredit.value) + parseFloat(SplitUnitPrice[6]);
                        lblStoreCredit.innerHTML = "Store credit used in cart: " + formatCurrency(hid_StoreCredit.value) + CurrencySymbol;
                      
                        Calculate_GrandTotal();
                        Cart_Additional_Price();
                        ReRuncalTotal();

                        if (SplitUnitPrice[5] == '') {
                            lbl_CouponCodeDiscount.innerHTML = '0.00';
                        }
                        else if (txt_CouponCode.value != '') {
                            IsApplyed = true;
                            lbl_CouponCodeDiscount.innerHTML = formatCurrency(SplitUnitPrice[5].split('~')[0]);
                        }
                    }
                }
            }
        }
    }
}

function ReRuncalTotal() {

    var FinalTotalexcTax = 0;
    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    FinalTotalexcTax = lblTotalPriceID.innerHTML;
    var TotalPrice = Number(FinalTotalexcTax.replace(",", ""));
    hid_TotalExTax.value = TotalPrice;
    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");
    var TotalTax = 0;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
    }
    hid_TotalIncTax.value = parseFloat(TotalPrice) + parseFloat(TotalTax);
    TaxOnChange(TotalPrice);
    Calculate_GrandTotal();
    Cart_Additional_Price();
}

function SetAdditionalOptions(result) {


    var AdditionalOptionValues = result.split("∅");

    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            if (shippingCart_TableCount[i].checked) {
                var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
                var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
                var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
                var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
                var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));

                var lbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_" + hdnCartItemID.value);
                var hdnlbl_subTotal_perCartID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_subTotal_" + hdnCartItemID.value);
                var lbl_tax_perCartItemID = document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + hdnCartItemID.value);
                var hdnlbl_tax_perCartItemID = document.getElementById("ctl00_ContentPlaceHolder1_hdnlbl_tax_" + hdnCartItemID.value);

                var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
                var QtyPerRow = document.getElementById("ctl00_ContentPlaceHolder1_lbl_qty_" + hdnCartItemID.value).innerHTML;
                var lbl_CouponCodeDiscount = document.getElementById("ctl00_ContentPlaceHolder1_lbl_Discount_" + hdnCartItemID.value);
                if (hdnGroupRun.value.toLowerCase() == 'true') {
                    if (txt_CouponCode.value != '') {
                        for (var k = AdditionalOptionValues.length - 2; k < AdditionalOptionValues.length; k++) {
                            if (AdditionalOptionValues[k] != '') {
                                if (hdnProductID.value == AdditionalOptionValues[k].split("»")[5] && hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                                    lbl_unitPrice.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[4]);
                                    var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                                    lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                                    hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                                    lbl_tax_perCartItemID.innerHTML = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    hdnlbl_tax_perCartItemID.value = parseFloat(AdditionalOptionValues[k].split("»")[8]);

                                    if (AdditionalOptionValues[k].split("»")[9] == '') {
                                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                                    }
                                    else if (txt_CouponCode.value != '') {
                                        IsApplyed = true;
                                        lbl_CouponCodeDiscount.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[9].split('~')[0]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (var k = 0; k < AdditionalOptionValues.length; k++) {
                            if (AdditionalOptionValues[k] != '') {
                                if (hdnProductID.value == AdditionalOptionValues[k].split("»")[5] && hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                                    lbl_unitPrice.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[4]);
                                    var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                                    lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                                    hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                                    lbl_tax_perCartItemID.innerHTML = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    hdnlbl_tax_perCartItemID.value = parseFloat(AdditionalOptionValues[k].split("»")[8]);

                                    if (AdditionalOptionValues[k].split("»")[9] == '') {
                                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                                    }

                                }
                            }
                        }

                    }
                }
                else {// else is required for reorder the same products from myorder
                    if (txt_CouponCode.value != '') {
                        for (var k = AdditionalOptionValues.length - 2; k < AdditionalOptionValues.length; k++) {
                            if (AdditionalOptionValues[k] != '' && AdditionalOptionValues[k] != undefined) {
                                
                                if (hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                                    lbl_unitPrice.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[4]);
                                    var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                                    lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                                    hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                                    lbl_tax_perCartItemID.innerHTML = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    hdnlbl_tax_perCartItemID.value = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    if (AdditionalOptionValues[k].split("»")[9] == '') {
                                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                                    }
                                    else if (txt_CouponCode.value != '') {
                                        IsApplyed = true;
                                        lbl_CouponCodeDiscount.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[9].split('~')[0]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (var k = 0; k < AdditionalOptionValues.length; k++) {
                            if (AdditionalOptionValues[k] != '') {
                                if (hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                                    lbl_unitPrice.innerHTML = formatCurrency(AdditionalOptionValues[k].split("»")[4]);
                                    var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                                    lbl_subTotal_perCartID.innerHTML = formatCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                                    hdnlbl_subTotal_perCartID.value = subtotalPerCartItemID;
                                    lbl_tax_perCartItemID.innerHTML = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    hdnlbl_tax_perCartItemID.value = parseFloat(AdditionalOptionValues[k].split("»")[8]);
                                    if (AdditionalOptionValues[k].split("»")[9] == '') {
                                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                                    }

                                }
                            }
                        }

                    }
                }
            }
        }
    }

    for (var i = 0; i < AdditionalOptionValues.length; i++) {

        var EachAdditionalitem = AdditionalOptionValues[i].split("»");

        if (Number(EachAdditionalitem[2]) != 0) {
            var lblPrice = document.getElementById("ctl00_ContentPlaceHolder1_lblPrice_" + EachAdditionalitem[3]);
            if (lblPrice != null) {
                lblPrice.innerHTML = formatCurrency(EachAdditionalitem[2]);
            }
            Calculate_GrandTotal();
            Cart_Additional_Price();
        }
    }
}

var Path1;

function OnEditClick(Path, ID) {
    Path1 = Path;
    AutoFill.Product_Exists_Check(ID, GetExistsResult, onTimeout, onError);
}

function GetExistsResult(result) {
    if (result) {
        window.location = Path1;
    }
    else {
        alert(Prod_NoMoreExists_MSG);
    }
}

function Pdf_Open_Design(FileName) {
    //window.open(strSitepath + "preview.aspx?" + FileName, '_blank');
    if (PreviewPageName != undefined && PreviewPageName != null) {
        if (PreviewPageName == "") {
            window.location = strSitepath + "preview.aspx?" + FileName;
        }
        else {
            window.location = strSitepath + PreviewPageName + "?" + FileName;
        }
    }
    else {
        window.location = strSitepath + "preview.aspx?" + FileName;
    }
}

function ApplayCouponCode() {
    var ChkCount = 0;
    
    if (!txt_CouponCode.disabled) {
        for (i = 0; i < document.forms[0].length; i++) {
            e = document.forms[0].elements[i];

            if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                if (!e.disabled) {
                    if (e.checked) {
                        //SelectedItemCount++;
                        //Id = e.id.split("chkEachLine").pop();
                        ChkCount++;
                    }
                }
            }
        }
        if (txt_CouponCode != null && txt_CouponCode != undefined) {
            if (txt_CouponCode.value != '') {
                if (ChkCount > 0) {
                    asyncState = false;
                    allowgrouprun_calculations();
                    
                    if (IsApplyed) {
                        txt_CouponCode.disabled = true;
                        btn_CouponCodeApplay.style.display = 'none';
                        div_ClearCouponCode.style.display = 'block';
                        btn_CouponCodeApplay.style.cursor = 'not-allowed';
                        span_InvalidCouponCode.style.display = 'none';
                        txt_CouponCode.style.cursor = 'not-allowed';
                    } else {
                        span_InvalidCouponCode.innerHTML = "Invalid coupon code";
                        txt_CouponCode.focus();
                        span_InvalidCouponCode.style.display = 'block';
                        return false;
                    }
                } else {
                    alert(Please_select_atlease_one_checkbox);
                    return false;
                }
            } else {
                span_InvalidCouponCode.innerHTML = 'Please enter coupon code';
                span_InvalidCouponCode.style.display = 'block';
                txt_CouponCode.focus();
                return false;
            }
        } else {
            return false;
        }
        return false;
    }
    return false;
}

function ClearCouponCode() {
    IsApplyed = false;
    txt_CouponCode.value = '';
    allowgrouprun_calculations();
    txt_CouponCode.disabled = false;
    btn_CouponCodeApplay.style.display = 'block';
    div_ClearCouponCode.style.display = 'none';
    btn_CouponCodeApplay.style.cursor = 'pointer';
    span_InvalidCouponCode.style.display = 'none';
    txt_CouponCode.style.cursor = 'auto';
    return false;
}