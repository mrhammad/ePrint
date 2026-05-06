
var TempSubTotal = 0;
var QtyStartsfrom = 0;
var QtyEndsTo = 0;
var SubWebOthercost = '';
var CalculationType = '';
var CalculationTypeID = '';
var SubItemCountebOthercost = '';
var SubItemCount = '';
var IsBind = '';
var isQuantityInvalid = false;
function PriceList_OpenPopup(type) {
    if (type == "viewmore") {
        div_PriceListMore.style.display = "block";
        div_PriceList.style.display = "none";
    }
    else {
        div_PriceListMore.style.display = "none";
        div_PriceList.style.display = "block";
    }
}

function CheckStockAvailability(Qty) {
    var IsStockManagement = document.getElementById("ctl00_ContentPlaceHolder1_hdnStockManagement").value;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if (IsStockManagement == "true") {
        if (rdbstkorder.checked) {
            var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
            var PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_hdnPriceCatalogueID").value;
            var IsBackOrder = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value;
            var hdnAvailableQty = document.getElementById("ctl00_ContentPlaceHolder1_hdnAvailableQty").value;
            if (Number(hdnAvailableQty) < 0) {
                hdnAvailableQty = 0;
            }
            if (DrawStockFrom == "s" || DrawStockFrom == "p") {
                if (hid_matixType.value == "P") {
                    GetSelfStockManagementDetails(Qty, hdnAvailableQty);
                }
                else if (hid_matixType.value == "G") {
                    GetSelfStockManagementDetails(Qty, hdnAvailableQty);
                }
                else if (hid_matixType.value == "S") {
                    if (IsCumulative == "true") {
                        GetSelfStockManagementDetails(txt_Cumulative_PriceQty.value, hdnAvailableQty);
                    } else {
                        GetSelfStockManagementDetails(ddlPriceQty.options[ddlPriceQty.selectedIndex].text, hdnAvailableQty);
                    }
                }
            }
            else if (DrawStockFrom == "o") {
                if (hid_matixType.value == "P") {
                    AutoFill.OtherProductDetails_Select(PriceCatalogueID, Qty, GetOtherStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "G") {
                    AutoFill.OtherProductDetails_Select(PriceCatalogueID, Qty, GetOtherStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "S") {
                    if (IsCumulative == "true") {
                        AutoFill.OtherProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, GetOtherStockManagementDetails, onTimeout, onError);
                    } else {
                        AutoFill.OtherProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, GetOtherStockManagementDetails, onTimeout, onError);
                    }
                }
            }
            else if (DrawStockFrom == "m") {
                if (hid_matixType.value == "P") {
                    AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "G") {
                    AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "S") {
                    if (IsCumulative == "true") {
                        AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                    } else {
                        AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                    }
                }
            }
            else if (DrawStockFrom == "a") {

                var WebOtherCostID = document.getElementById("ctl00_ContentPlaceHolder1_hdnWebOtherCostID").value;
                ddlLabels = document.getElementById("ctl00_ContentPlaceHolder1_" + document.getElementById("ctl00_ContentPlaceHolder1_hdnStockAddOption").value);
                if (ddlLabels != null || ddlLabels != undefined) {
                    var ChoiceID = ddlLabels.options[ddlLabels.selectedIndex].value;
                    var LabelArray = ChoiceID.split('~');

                    if (hid_matixType.value == "P") {
                        AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                    }
                    else if (hid_matixType.value == "G") {
                        AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                    }
                    else if (hid_matixType.value == "S") {
                        if (IsCumulative == "true") {
                            AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                        } else {
                            AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                        }
                    }
                }
            }
        }
    }
}

function CheckAddOptStockAvailability(id, WebOtherCostID) {


    var IsStockManagement = document.getElementById("ctl00_ContentPlaceHolder1_hdnStockManagement").value;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    ddlLabels = document.getElementById(id);
    var ChoiceID = ddlLabels.options[ddlLabels.selectedIndex].value;
    var LabelArray = ChoiceID.split('~');
    if (IsStockManagement == "true") {
        if (rdbstkorder.checked) {
            var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
            var PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_hdnPriceCatalogueID").value;
            var IsBackOrder = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value;


            if (DrawStockFrom == "a") {
                if (hid_matixType.value == "P") {
                    var Qty = parseInt(document.getElementById("txtqty").value);
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "G") {
                    var Qty = parseInt(document.getElementById("txtqty").value);
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                }
                else if (hid_matixType.value == "S") {
                    if (IsCumulative == "true") {
                        AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                    } else {
                        AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                    }
                }
            }
        }
    }
}

function GetSelfStockManagementDetails(Qty, ActualAvalQty) {
    var AvailableQty = Qty;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    debugger;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (ActualAvalQty == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
        }
        else {
            if (hid_matixType.value == "P") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    //document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    if (IsShowStock == 'true') {

                        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (ActualAvalQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "G") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (ActualAvalQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "S") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }

                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    if (document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay") != null || document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay") != undefined) {
                        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    }
                    if (document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1") != null || document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1") != undefined) {
                        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (ActualAvalQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
        }
    }
    else {
        if (ActualAvalQty == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            if (parseInt(ActualAvalQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
        }
    }
    if (IsShowStock == 'true') {

        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetOtherMultipleStockManagementDetails(result) {
    var NewResult = result.split('~');
    var OtherMultipleID = NewResult[0];
    var KitItemID = NewResult[1];
    var TotalQty = NewResult[2];
    var AllocatedQty = NewResult[3];
    var AvailableQty = NewResult[4];

    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple") != null || document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple") != undefined) {
                        var ddlOtherMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple");
                        var selectedText = ddlOtherMultiple.options[ddlOtherMultiple.selectedIndex].text;

                        if (selectedText.toLowerCase() == "--select--") {
                            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                        }
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    if (document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay") != null || document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay") != undefined) {
                        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    }
                    if (document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1") != null || document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1") != undefined) {
                        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (parseInt(AvailableQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {

        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetOtherStockManagementDetails(result) {

    var AvailableQty = result;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    if (IsShowStock == 'true') {
                        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (parseInt(AvailableQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {

        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetAdtOptionsStockManagementDetails(result) {

    var AvailableQty = result;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            //            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            //            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            //            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

            //            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            //            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            //            document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
            //            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = true;
                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = Stock_Availability;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (parseInt(AvailableQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {

        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function Tocalculate_totalPrice(Qty, Pcid) {
    debugger;
    isQuantityInvalid = false;
    if (Qty == "txtHeight" || Qty == "txtWidth") {
        Qty = document.getElementById("txtqty").value;
    }
    if (Pcid != 0) {
        // Make an AJAX request to the web service
        $.ajax({
            type: "POST",
            url: strSitePath + "AutoFill.asmx/CalculateQtyListCost",
            data: JSON.stringify({ PriceCatalogueId: Pcid }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var result = response.d;
                var parts = result.split("~");

                var qtyFromList = parts[0];
                var qtyToList = parts[1];
                var CostExcMarkupList = parts[2];
                var MarkupList = parts[3];
                var priceList = parts[4];

                //console.log(qtyFromList, qtyToList, CostExcMarkupList, MarkupList, priceList);
                hid_qtyFromList.value = qtyFromList;
                hid_qtyToList.value = qtyToList;
                hid_CostExcMarkupList.value = CostExcMarkupList;
                hid_priceList.value = priceList;
                hid_MarkupList.value = MarkupList;
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    //setInterval("TakeOut()", 10000);
    var arrQtyFrom = hid_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var arrCost = hid_CostExcMarkupList.value.split('µ');
    var arrPrice = hid_priceList.value.split('µ');
    var arrMarkup = hid_MarkupList.value.split('µ');
    var arrSPOV = hdnsoldPackOV.value;
    var Dimensn;
    TempSubTotal = 0;

    for (var j = 0; j < arrQtyTo.length - 1; j++) {
        if (j == arrQtyTo.length - 2) {
            QtyEndsTo = Number(arrQtyTo[j]);
        }
    }

    for (var i = 0; i < arrQtyFrom.length - 1; i++) {
        if (hid_matixType.value == "P") {
            if (Qty != '' && Number(Qty)) {

                if (i == 0) {
                    QtyStartsfrom = Number(arrQtyFrom[i]);
                }

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                hdn_orderedquantity.value = Number(Qty);

                if (Number(Qty) <= Number(arrQtyFrom[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }

                else if (Number(Qty) > Number(arrQtyFrom[i]) && Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPrice.value = "0";
                    hid_Markup.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    isQuantityInvalid = true;
                    break;
                }
                else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else {
                    if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        hid_QuantityPrice.value = "0";
                        hid_Markup.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
            }
        }
        else if (hid_matixType.value == "G") {
            if (Qty != '' && Number(Qty)) {
                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                    return false;
                }
                else {
                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                        hdn_orderedquantity.value = (Number(document.getElementById("txtqty").value));
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                        hdn_orderedquantity.value = (Number(document.getElementById("txtqty").value));
                    }

                    hdn_orderedarea.value = (Number(hdn_orderedheight.value) * Number(hdn_orderedwidth.value))

                    if (Number(Dimensn) + Number(AllDimentions) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) + Number(AllDimentions) >= Number(arrQtyFrom[i]) && Number(Dimensn) + Number(AllDimentions) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) + Number(AllDimentions) > Number(arrQtyTo[i]) && Number(Dimensn) + Number(AllDimentions) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            hid_Markup.value = "0";
                        }
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                //hdn_orderedquantity.value = "0";
            }
        }
        else {

            if (IsCumulative == "true") {
                Qty = txt_Cumulative_PriceQty.value;
                if (Qty != '' && Number(Qty)) {

                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }
                    hdn_orderedquantity.value = Number(Qty);

                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i]);
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i + 1]);
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_Markup.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            IsCumulativeQtyForUnitPrice = 0;
                        }
                    }
                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
                else {
                    if (!Number(Qty)) {
                        txt_Cumulative_PriceQty.value = "";
                    }
                    else {
                        hdn_orderedquantity.value = Number(Qty);
                    }
                    hid_QuantityPrice.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    hid_Markup.value = "0";

                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
            } else {
                var sellingPrice = ddlPriceQty.options[ddlPriceQty.selectedIndex].value.split('~');
                hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                hid_QuantityPrice.value = sellingPrice[1];
                QtyStartsfrom = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                QtyEndsTo = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;


                hdn_orderedquantity.value = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                //hdn_orderedquantity.value = "0";
            }
        }
    }

    if (hid_matixType.value == "P") {
        if (Qty != '' && Number(Qty)) {
            if (QtyStartsfrom > Number(Qty)) {
                document.getElementById("spn_qty").style.display = 'block';
                document.getElementById("spn_qty").innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Qty)) {
                document.getElementById("spn_qty").style.display = 'block';
                document.getElementById("spn_qty").innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (!(Qty % arrSPOV == 0)) {
                document.getElementById("spn_qty").style.display = 'block';
                document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                return false;
            }
            else {
                document.getElementById("spn_qty").style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "G") {
        if (Dimensn != '' && Number(Dimensn)) {
            if (QtyStartsfrom > Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Minimum_Dimension_Is + QtyStartsfrom + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Maximum_Dimension_Is + QtyEndsTo + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else {
                spn_Dimensn.style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            if (Qty != '' && Number(Qty)) {
                if (QtyStartsfrom > Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (QtyEndsTo < Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (!(Qty % arrSPOV == 0)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    return false;
                }
                else {
                    document.getElementById("spn_qty").style.display = 'none';
                }
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var l = 0; l <= hid_MatrixLenght.value - 1; l++) {
            var lblMatrixID = document.getElementById("lblMatrixID_" + l + "").innerHTML;
            var lblMatrixType = document.getElementById("lblMatrixType_" + l + "").innerHTML;
            MatrixCheck_value(lblMatrixID, l, lblMatrixType);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;

            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }

            CalculatePrice_Question_SubTotal(FormulaTag, q); //For <Subtotal> Calculation
            CalculatePrice_Question(Formula1, q, TempSubTotal);
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Onchange_MultipleChoice_SubTotal(c); //For <Subtotal> Calculation
            Onchange_MultipleChoice(c, TempSubTotal);
        }
    }

    setInterval("TakeOut()", 10000);

    calculateDecoration(1);
    Final_SellingPrice_SubTotal();
    Final_SellingPrice();
}

function TocalculateMatrix_totalPrice(Qty, Pcid, Obj, Matrixtype) {
    debugger;

    if (Qty == "txtHeight" || Qty == "txtWidth") {
        Qty = document.getElementById("txtqty").value;
    }
    hid_matixType.value = Matrixtype;
    if (Pcid != 0) {
        // Make an AJAX request to the web service
        $.ajax({
            type: "POST",
            url: strSitePath + "AutoFill.asmx/CalculateQtyListCost",
            data: JSON.stringify({ PriceCatalogueId: Pcid }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var result = response.d;
                var parts = result.split("~");

                var qtyFromList = parts[0];
                var qtyToList = parts[1];
                var CostExcMarkupList = parts[2];
                var MarkupList = parts[3];
                var priceList = parts[4];

                //console.log(qtyFromList, qtyToList, CostExcMarkupList, MarkupList, priceList);
                hid_qtyFromList.value = qtyFromList;
                hid_qtyToList.value = qtyToList;
                hid_CostExcMarkupList.value = CostExcMarkupList;
                hid_priceList.value = priceList;
                hid_MarkupList.value = MarkupList;
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    //setInterval("TakeOut()", 10000);
    var arrQtyFrom = hid_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var arrCost = hid_CostExcMarkupList.value.split('µ');
    var arrPrice = hid_priceList.value.split('µ');
    var arrMarkup = hid_MarkupList.value.split('µ');
    var arrSPOV = hdnsoldPackOV.value;
    var Dimensn;
    TempSubTotal = 0;

    for (var j = 0; j < arrQtyTo.length - 1; j++) {
        if (j == arrQtyTo.length - 2) {
            QtyEndsTo = Number(arrQtyTo[j]);
        }
    }

    for (var i = 0; i < arrQtyFrom.length - 1; i++) {
        if (hid_matixType.value == "P") {
            if (Qty != '' && Number(Qty)) {

                if (i == 0) {
                    QtyStartsfrom = Number(arrQtyFrom[i]);
                }

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                hdn_orderedquantity.value = Number(Qty);

                if (Number(Qty) <= Number(arrQtyFrom[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else {
                    if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        hid_QuantityPrice.value = "0";
                        hid_Markup.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
            }
        }
        else if (hid_matixType.value == "G") {
            if (Qty != '' && Number(Qty)) {
                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                    return false;
                }
                else {
                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                        hdn_orderedquantity.value = (Number(document.getElementById("txtqty").value));
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                        hdn_orderedquantity.value = (Number(document.getElementById("txtqty").value));
                    }

                    hdn_orderedarea.value = (Number(hdn_orderedheight.value) * Number(hdn_orderedwidth.value))

                    if (Number(Dimensn) + Number(AllDimentions) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) + Number(AllDimentions) >= Number(arrQtyFrom[i]) && Number(Dimensn) + Number(AllDimentions) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) + Number(AllDimentions) > Number(arrQtyTo[i]) && Number(Dimensn) + Number(AllDimentions) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            hid_Markup.value = "0";
                        }
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                //hdn_orderedquantity.value = "0";
            }
        }
        else {

            if (IsCumulative == "true") {
                Qty = txt_Cumulative_PriceQty.value;
                if (Qty != '' && Number(Qty)) {

                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }
                    hdn_orderedquantity.value = Number(Qty);

                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i]);
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i + 1]);
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_Markup.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            IsCumulativeQtyForUnitPrice = 0;
                        }
                    }
                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
                else {
                    if (!Number(Qty)) {
                        txt_Cumulative_PriceQty.value = "";
                    }
                    else {
                        hdn_orderedquantity.value = Number(Qty);
                    }
                    hid_QuantityPrice.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    hid_Markup.value = "0";

                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
            } else {
                if (document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixCheckMultipleProduct").value) {
                    var ddlMarkup = Obj;
                    var sellingPrice = ddlMarkup.options[ddlMarkup.selectedIndex].value.split('~');
                    hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                    hid_QuantityPrice.value = sellingPrice[1];
                    QtyStartsfrom = ddlMarkup.options[ddlMarkup.selectedIndex].text;
                    QtyEndsTo = ddlMarkup.options[ddlMarkup.selectedIndex].text;


                    hdn_orderedquantity.value = ddlMarkup.options[ddlMarkup.selectedIndex].text;
                } else {
                    var sellingPrice = ddlPriceQty.options[ddlPriceQty.selectedIndex].value.split('~');
                    hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                    hid_QuantityPrice.value = sellingPrice[1];
                    QtyStartsfrom = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    QtyEndsTo = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;


                    hdn_orderedquantity.value = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                //hdn_orderedquantity.value = "0";
            }
        }
    }

    if (hid_matixType.value == "P") {
        if (Qty != '' && Number(Qty)) {
            if (QtyStartsfrom > Number(Qty)) {
                document.getElementById("spn_qty").style.display = 'none';
                document.getElementById("spn_qty").innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Qty)) {
                document.getElementById("spn_qty").style.display = 'none';
                document.getElementById("spn_qty").innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (!(Qty % arrSPOV == 0)) {
                document.getElementById("spn_qty").style.display = 'block';
                document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                return false;
            }
            else {
                document.getElementById("spn_qty").style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "G") {
        if (Dimensn != '' && Number(Dimensn)) {
            if (QtyStartsfrom > Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Minimum_Dimension_Is + QtyStartsfrom + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Maximum_Dimension_Is + QtyEndsTo + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else {
                spn_Dimensn.style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            if (Qty != '' && Number(Qty)) {
                if (QtyStartsfrom > Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (QtyEndsTo < Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (!(Qty % arrSPOV == 0)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    return false;
                }
                else {
                    document.getElementById("spn_qty").style.display = 'none';
                }
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var l = 0; l <= hid_MatrixLenght.value - 1; l++) {
            var lblMatrixID = document.getElementById("lblMatrixID_" + l + "").innerHTML;
            var lblMatrixType = document.getElementById("lblMatrixType_" + l + "").innerHTML;
            MatrixCheck_value(lblMatrixID, l, lblMatrixType);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;

            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }

            CalculatePrice_Question_SubTotal(FormulaTag, q); //For <Subtotal> Calculation
            CalculatePrice_Question(Formula1, q, TempSubTotal);
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Onchange_MultipleChoice_SubTotal(c); //For <Subtotal> Calculation
            Onchange_MultipleChoice(c, TempSubTotal);
        }
    }

    setInterval("TakeOut()", 10000);

    //calculateDecoration(1);
    Final_SellingPrice_SubTotal();
    Final_SellingPrice();
    if (hid_matixType.value == "P") {
        PriceOnBlur_Matrix(Obj);
    }
    if (hid_matixType.value == "S") {
        PriceOnBlur_Total(Obj);
    }
}

function PriceOnBlur_Total(Obj) {
    debugger;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixString = '';
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");


    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    var decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;

    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    if (document.getElementById("ctl00_ContentPlaceHolder1_hdnShowPriceSubtotalTax").value != 'False') {
        document.getElementById(Obj.id.replace('ddl_Markup', 'lbl_SellingPrice')).innerHTML = sellingPrice;
    }

    var Markup = '';
    var FinalPrice = '';

    var MatrixQuantity = txt_Markup.value;
    var totalQuantity = 0;
    var quantityInputs = document.querySelectorAll('input[name^="ctl00$ContentPlaceHolder1$GridInkCostView$ctl00$ctl"][id$="_txt_Markup"]');
    var dropdowns = document.querySelectorAll('select[name^="ctl00$ContentPlaceHolder1$GridInkCostView$ctl00$ctl"][id$="_ddl_Markup"]');
    var priceElements = document.querySelectorAll('span[id^="ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl"][id$="_lbl_SellingPrice"]');
    for (var i = 0; i < quantityInputs.length; i++) {
        var quantity = parseFloat(quantityInputs[i].value) || 0; // Parse float or default to 0
        totalQuantity += quantity;
        MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity + "»CartShipping~0%";
    }
    var selectedQuantity = 0;
    for (var i = 0; i < dropdowns.length; i++) {
        var quantity1 = parseFloat(dropdowns[i].options[dropdowns[i].selectedIndex].text) || 0;
        selectedQuantity += quantity1;
        MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity1 + "»CartShipping~0%";
    }
    // Add the selected quantity to the total
    totalQuantity += selectedQuantity;
    //var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    //iRows = grd.getElementsByTagName('tr');
    //if (iRows.length > 0) {
    //  var i = 4;
    //for (var k = 1; k < iRows.length; k++) {
    //Markup = Number(Markup) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_txt_Markup").value);
    //  FinalPrice = Number(FinalPrice) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_lbl_SellingPrice").innerHTML);
    //i = i + 2;
    //}
    //}
    if (MatrixQuantity == '') {
        MatrixQuantity = 0;
    }
    var totalPrice = 0;
    var cartTotalPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
    //var priceElements = document.querySelectorAll('span[id^="ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl"][id$="_lbl_SellingPrice"]');
    for (var i = 0; i < priceElements.length; i++) {
        var price = parseFloat(priceElements[i].textContent) || 0; // Parse float or default to 0
        totalPrice += price;
        //MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + price + "»CartShipping~0%";
    }
    //var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    //var iRows = grd.getElementsByTagName('tr');
    //for (var k = 1; k < iRows.length; k++) {
    //  var quantity = Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + (k * 2 + 2) + "_txt_Markup").value);
    //MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity + "»CartShipping~0%";
    //}


    hid_MultipleMatrixValues.value = MatrixString;
    //document.getElementById("txtqty").value = Markup;
    document.getElementById("txtqty").value = totalQuantity;

    //document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);
    //document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);

    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, totalPrice, 2, '', false, false, false), true);
    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, totalPrice, 2, '', false, false, false), true);


    //Tocalculate_totalPrice(Markup,'0');
}



function TakeOut() {
    var i = 0;
    for (var l = 0; l < 200; l++) {
        i++;
    }
}

function CalculatePrice_Question(Formula, ID, TempSubTotal) {

    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    var GroupID = document.getElementById("lblQuestionGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblQuestionID_" + ID + "").innerHTML;
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value) && txtQuestion.getAttribute("grpvalue") == "1") {

        var IsSubTotal = false;
        if (Formula.indexOf("[$SubTotal$]") != -1 || Formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }

        var FormulaTag = Formula;
        for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replace('<question>', txtQuestion.value).replace('<quantity>', txtQuestion.value).replace('<input>', txtQuestion.value).replace('[$ProductBasePrice$]', Number(hid_QuantityPrice.value)).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace(' ', '').replace('</question>', '').replace('</productbaseprice>', '').replace('</subtotal>', '').replace('#', '%').replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
        }

        if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {
            var dd = eval(FormulaTag);
            if (!isNaN(dd)) {
                AutoFill.CalculateFormulaCost(dd, ID, GetResult, onTimeout, onError);
            }
            else {
                document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
            Final_SellingPrice();
        }
        else {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
        Final_SellingPrice();
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        Final_SellingPrice();
    }
}

function CalculatePrice_Question_SubTotal(Formula, ID) {
    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value)) {
        var IsSubTotal = false;
        if (Formula.indexOf("[$SubTotal$]") != -1 || Formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }

        if (IsSubTotal) {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
    }
}

function GetResult(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function MatrixCheck_value(OthercostID, ID, MatrixType) {
    var quantity = '';
    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;
    if (hid_matixType.value == "P") {
        quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    debugger;
    //var chkbox = document.getElementById("chkMatrix_" + ID + "");
    var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_chkMatrix_" + ID);
    var ddlMatrixSelectedValue = chkbox.options[chkbox.selectedIndex].value;
    if (quantity != "" && quantity != "0") {
        if (MatrixType != "pricebands") {
            //chkbox.checked = true;
        }
    }


    if (ddlMatrixSelectedValue == "1" && chkbox.getAttribute("grpvalue") == "1") {
        if (MatrixType == "pricebands") {
            if (quantity != '' && quantity != '0') {
                if (OthercostID != '0') {
                    AutoFill.GetMatrixValue(Number(OthercostID), Number(quantity), ID, GetResultMatrix, onTimeout, onError);
                    Final_SellingPrice();
                    document.getElementById("spn_qty").style.display = "none";
                }
            }
            else {
                document.getElementById("spn_qty").style.display = "block";
                chkbox.checked = false;
                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
                Final_SellingPrice();
                if (IsCumulative == "true") {
                    txt_Cumulative_PriceQty.focus();
                } else {
                    document.getElementById("txtqty").focus();
                }
            }
        }
        else {
            if (quantity != '' && quantity != '0') {

                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);

                var MatrixSellingPrice = '';
                for (var ddl = 0; ddl <= ddlMatrix.length - 1; ddl++) {
                    if (Number(quantity) <= Number(ddlMatrix[ddl].text)) {
                        ddlMatrix.selectedIndex = ddl;
                        // QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        //  MatrixSellingPrice = parseFloat(parseFloat(ddlMatrixValue1[0]) + Math.round(((parseFloat(ddlMatrixValue1[0]) * parseFloat(ddlMatrixValue1[1])) / 100)), 3);
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                        break;
                        // By 018 (Gaj instruction)
                        //MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);

                    }
                    else {

                        ddlMatrix.selectedIndex = ddl;
                        // QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        //  MatrixSellingPrice = parseFloat(parseFloat(ddlMatrixValue1[0]) + Math.round(((parseFloat(ddlMatrixValue1[0]) * parseFloat(ddlMatrixValue1[1])) / 100)), 3);
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);

                    }
                }

                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false), true);
                Final_SellingPrice();
                document.getElementById("spn_qty").style.display = "none";
            }
            else {
                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);
                ddlMatrix.selectedIndex = 0;
                chkbox.checked = false;
                document.getElementById("spn_qty").style.display = "block";
                Final_SellingPrice();
                if (IsCumulative == "true") {
                    txt_Cumulative_PriceQty.focus();
                } else {
                    document.getElementById("txtqty").focus();
                }
            }
        }
    }
    else {
        document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
        Final_SellingPrice();
    }
}

function GetResultMatrix(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false), true);
        document.getElementById("lblMatrixCostMarkup_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}

function Onchange_SimpleMatrix(ID) {
    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblMatrixID_" + ID + "").innerHTML;

    var chkbox = document.getElementById("chkMatrix_" + ID + "");
    var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);
    if (chkbox.checked || ddlMatrix.options[ddlMatrix.selectedIndex].value != "0") {
        if (ddlMatrix.options[ddlMatrix.selectedIndex].value != "0" && chkbox.getAttribute("grpvalue") == "1") {
            var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
            var ddlMatrixValue1 = ddlMatrixValue.split('~');
            var MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
            chkbox.checked = true;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false), true);
            Final_SellingPrice();
        }
        else {
            chkbox.checked = false;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
            Final_SellingPrice();
        }
    }
}

function SubAdditionCountCheck(OthercostID) {
    debugger
    AutoFill.Select_WebOtherCostID(OthercostID, SubAdditions_Count_Response, onTimeout, onError);
}
var SubCount = '';

function SubAdditions_Count_Response(result) {
    SubCount = result;
}

function Onchange_MultipleChoice(ID, TempSubTotal) {

    if (typeof document.getElementById("lblMultipleGroupID_" + ID + "") != 'undefined' && document.getElementById("lblMultipleGroupID_" + ID + "") != undefined && document.getElementById("lblMultipleGroupID_" + ID + "") != null) {
        var GroupID = document.getElementById("lblMultipleGroupID_" + ID + "").innerHTML;
    }
    var OthercostID = document.getElementById("lblMultipleID_" + ID + "").innerHTML;
    var quantity = '';
    if (hid_matixType.value == "P") {
        var quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        var quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);
    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                        if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                        }
                        if (IsDisplayAdditionalOptions == "true") {
                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                            }

                        }
                    }
                }
                else {
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                            var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC);
                            if (SubddlMultiple.options[SubddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                                var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                                var SubMultipleValue = SubddlMultipleValue.split('~');

                                if (quantity != '') {
                                    var IsSubTotal = false;
                                    if (SubMultipleValue[0].indexOf("[$SubTotal$]") != -1 || SubMultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                        IsSubTotal = true;
                                    }

                                    if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {
                                        var FormulaTagMul = '';
                                        FormulaTagMul = SubMultipleValue[0];


                                        for (var i = 0; i <= FormulaTagMul.length; i++) {
                                            FormulaTagMul = FormulaTagMul.replace('<quantity>', quantity).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', hid_QuantityPrice.value).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                        }

                                        var dd = eval(FormulaTagMul);
                                        if (!isNaN(dd)) {
                                            AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(SubMultipleValue[1]), document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).id, GetResultSubMultiple, onTimeout, onError);
                                        }
                                        else {
                                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                            }
                                            if (IsDisplayAdditionalOptions == "true") {
                                                if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                                                }
                                            }
                                            Final_SellingPrice();
                                        }
                                    }
                                    else {
                                        if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                        }
                                        if (IsDisplayAdditionalOptions == "true") {
                                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                                            }
                                        }
                                    }
                                    chkMultiple.checked = true;
                                    document.getElementById("spn_qty").style.display = "none";
                                }
                            }
                            else {
                                if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                }
                                if (IsDisplayAdditionalOptions == "true") {
                                    if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                                    }
                                }
                                Final_SellingPrice();
                            }
                        }
                       
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                if (IsDisplayAdditionalOptions == "true") {
                    document.getElementById("lblMultiplePrice_" + ID + "").style.display = "none";
                }
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            if (IsDisplayAdditionalOptions == "true") {
                document.getElementById("lblMultiplePrice_" + ID + "").style.display = "none";
            }
            Final_SellingPrice();
        }
    } else {

        if (ddlMultiple.getAttribute("grpvalue") == "1") {
            if (chkMultiple.checked || ddlMultiple.options.length != 0) {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                    if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                        chkMultiple.checked = false;
                        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    }
                    else {
                        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                        var MultipleValue = ddlMultipleValue.split('~');

                        if (quantity != '') {
                            var IsSubTotal = false;
                            if (MultipleValue[0].indexOf("[$SubTotal$]") != -1 || MultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                IsSubTotal = true;
                            }

                            if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {
                                var FormulaTagMul = '';
                                FormulaTagMul = MultipleValue[0];
                                for (var i = 0; i <= FormulaTagMul.length; i++) {
                                    FormulaTagMul = FormulaTagMul.replace('<quantity>', quantity).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', hid_QuantityPrice.value).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                }

                                var dd = eval(FormulaTagMul);
                                if (!isNaN(dd)) {
                                    AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(MultipleValue[1]), ID, GetResultMultiple, onTimeout, onError);
                                }
                                else {

                                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                    Final_SellingPrice();
                                }
                            }
                            else {
                                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                            }
                            chkMultiple.checked = true;
                            document.getElementById("spn_qty").style.display = "none";
                        }
                        else {
                            ddlMultiple.selectedIndex = 0;
                            document.getElementById("spn_qty").style.display = "block";
                            chkMultiple.checked = false;
                        }
                    }
                }
                else {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    Final_SellingPrice();
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            Final_SellingPrice();
        }
    }
}

function GetResultMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function GetResultSubMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById(NewResult[1]).innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        document.getElementById(NewResult[1]).style.display = "block";
        if (IsDisplayAdditionalOptions == "true") {
            if (NewResult[0] == "0" || NewResult[0] == "0.00") {
                document.getElementById(NewResult[1]).style.display = "none";
            }
        }
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}


function Onchange_MultipleChoice_SubTotal(ID) {

    var quantity = '';
    if (hid_matixType.value == "P") {
        var quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        var quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    var OthercostID = document.getElementById("lblMultipleID_" + ID + "").innerHTML;
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);
    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                        if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                        }
                        if (IsDisplayAdditionalOptions == "true") {
                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                            }

                        }
                    }
                }
                else {
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                            var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC);
                            if (SubddlMultiple.options[SubddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                                var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                                var SubMultipleValue = SubddlMultipleValue.split('~');

                                if (quantity != '') {

                                    var IsSubTotal = false;
                                    var FormulaTagMul = SubMultipleValue[0];

                                    if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal != 0 &&
                                    {
                                        IsSubTotal = true;
                                    }
                                    if (IsSubTotal) {
                                        if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                        }
                                        if (IsDisplayAdditionalOptions == "true") {
                                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                                            }
                                        }
                                    }
                                    chkMultiple.checked = true;
                                    document.getElementById("spn_qty").style.display = "none";
                                }
                                else {
                                    //ddlMultiple.selectedIndex = 0;
                                    document.getElementById("spn_qty").style.display = "block";
                                    chkMultiple.checked = true;
                                }
                            }
                            else {
                                if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                }
                                if (IsDisplayAdditionalOptions == "true") {
                                    if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).style.display = "none";
                                    }
                                }
                            }
                        }
                       
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                if (IsDisplayAdditionalOptions == "true") {
                    document.getElementById("lblMultiplePrice_" + ID + "").style.display = "none";
                }
            }
        }
        else {
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            if (IsDisplayAdditionalOptions == "true") {
                document.getElementById("lblMultiplePrice_" + ID + "").style.display = "none";
            }
        }
    } else {
        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
                else {
                    var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                    var MultipleValue = ddlMultipleValue.split('~');

                    if (quantity != '') {

                        var IsSubTotal = false;
                        var FormulaTagMul = MultipleValue[0];

                        if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal != 0 &&
                        {
                            IsSubTotal = true;
                        }
                        if (IsSubTotal) {
                            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                        }
                        chkMultiple.checked = true;
                        document.getElementById("spn_qty").style.display = "none";
                    }
                    else {
                        ddlMultiple.selectedIndex = 0;
                        document.getElementById("spn_qty").style.display = "block";
                        chkMultiple.checked = false;
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
    }
}

function Final_SellingPrice() {
    debugger;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var SubMultiplePrice = 0;
    var SubValue = 0;
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");

    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                    if (document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                        MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    }
                }
            } else {
                MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    var decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;
    lbltotal.innerHTML = '0';
    lbltotal.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice), 2, '', false, false, false), true);

    lblunitprice.innerHTML = '0';
    lblunitprice.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice / hdn_orderedquantity.value), 2, '', false, false, false), true);
    lblpackprice.innerHTML = '0';
    lblpackprice.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice / (hdn_orderedquantity.value / hdnsoldPackOV.value)), 2, '', false, false, false), true);

    hdnlbltotal.value = parseFloat(sellingPrice);
    TaxOnChange();
}

function Final_SellingPrice_SubTotal() {

    TempSubTotal = 0;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var decorationCost = 0;
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");

    setInterval("TakeOut()", 100000);

    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                    if (document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                        MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    }
                //    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {
                MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';
    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;
    TempSubTotal = sellingPrice;
    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Onchange_MultipleChoice(c, TempSubTotal);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;
            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }
            CalculatePrice_Question(FormulaTag, q, TempSubTotal);
        }
    }
}

var lbl_WithoutTax;
function TaxOnChange() {
    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("lblTotalTax");
    var TotalPrice = Number(hdnlbltotal.value); //lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    var TotalTax = 0;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
        lblTotalTax.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalTax), 2, '', false, false, false), true);
        hdnTotalTaxValue.value = parseFloat(TotalTax);
    }
    else {
        lblTotalTax.innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        hdnTotalTaxValue.value = Number(0);
    }
    var TotalSellingPrice = Number(TotalPrice) + Number(TotalTax);
    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalSellingPrice), 2, '', false, false, false), true);
    if (document.getElementById("lbl_WithoutTax") != null)
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalPrice), 2, '', false, false, false), true);
    lbl_WithoutTax = Number(TotalPrice);
}

function IsValidFile(filename) {
    var lastDot = filename.lastIndexOf(".");
    var pathLength = filename.length;
    var fileType = filename.substring(lastDot, pathLength);

    if ((fileType.toLowerCase() != ".exe") && (fileType.toLowerCase() != ".asp") && (fileType.toLowerCase() != ".html") && (fileType.toLowerCase() != ".php") && (fileType.toLowerCase() != ".dll") && (fileType.toLowerCase() != ".aspx") && (fileType.toLowerCase() != ".jar")) {
        return true;
    }
    else {
        return false;
    }

}

function Save_toCart(val, div, divProcess) {
    debugger;
    var textJob = document.getElementById("txtJobName").value;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnJobName").value = textJob;
    var JobNameIsMandatory = document.getElementById("ctl00_ContentPlaceHolder1_hdnCartJobNameIsMandatory").value;
    var ShowJobName = document.getElementById("ctl00_ContentPlaceHolder1_hdnShowJobName").value;
    var JobNameText = document.getElementById("lbl_job_name").textContent;

    var textareas = document.querySelectorAll("textarea[id^='txtFreeTextQuestion_']");
    var isValid = true;
    textareas.forEach((textarea) => {

        const parentDiv = textarea.closest("div[id^='div_SubAdditionalsddl_']");
        if (parentDiv != null) {
            if (parentDiv && parentDiv.style.display === "none") return;
        }

        const id = textarea.id.split('_')[1];  // Extract the unique identifier
        const hiddenInput = document.getElementById(`hdn_FreeTextQuestion_${id}`);

        // Check if the field is mandatory (hidden input value is 'true')
        const isMandatory = hiddenInput && hiddenInput.value === 'True';
        const value = textarea.value.trim();

        if (isMandatory && value === '') {
            isValid = false;
            textarea.style.border = "2px solid red";  // Highlight the field
        } else {
            textarea.style.border = "";  // Remove highlight if filled
        }
        
    });
    if (!isValid) {
        alert("Please fill in all mandatory questions before proceeding.");
        return false;
    }

    //Added by shahbaz for validating upload file
    var fileupload = $('input[type=file');
    for (var i = 0; i < fileupload.length; i++) {
        if (fileupload[i].files.length > 0) {
            var filename = fileupload[i].files[0].name;
            if (!IsValidFile(filename)) {
                alert("Do not upload exe, asp, aspx, dll, php, html, jar types of files")
                return false;
            }
        }
    }
    //End

    //Ticket Id : 13951
    if (IsSpendLimitEnable == "true") {

        if (parseInt(SpendAmount) + lbl_WithoutTax > parseInt(SpendLimitAmount)) {
            alert('Your order amount exceeds the Spend Limit amount');
            return false;
        }
    }

    if (JobNameIsMandatory == "1") {
        if (ShowJobName == "True") {
            if (textJob == "") {
                alert('Please fill out the ' + JobNameText + ' field');
                return false;
            }
        }
    }
    //Ticket Id : 13951
    var FinalCheck = false;
    var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
    var IsStockItem = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsStockItem").value;

    var ddl_behalfDepts = document.getElementById("ctl00_ContentPlaceHolder1_ddl_BehalfDepts");

    var hdnDepuUserID = document.getElementById("ctl00_ContentPlaceHolder1_hdnDepuUserID");

    var ddl_DeptUsers = document.getElementById("ctl00_ContentPlaceHolder1_ddl_DeptUsers");
    var div_ProdSelectErrorMSG = document.getElementById("ctl00_ContentPlaceHolder1_div_ProdSelectErrorMSG");
    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple") != null || document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple") != undefined) {
        var ddlOtherMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlOtherMultiple");
        var selectedText = ddlOtherMultiple.options[ddlOtherMultiple.selectedIndex].text;

        if (selectedText.toLowerCase() == "--select--") {
            div_ProdSelectErrorMSG.style.display = "block";
            return false;
        }
    }
    if (ddl_behalfDepts != null) {
        if (ddl_behalfDepts != undefined) {
            if (ddl_behalfDepts.selectedIndex > 0) {
                if (ddl_behalfDepts.options[ddl_behalfDepts.selectedIndex].value > 0) {
                    if (ddl_DeptUsers.options[ddl_DeptUsers.selectedIndex].value != Number(0)) {

                        if (ddl_DeptUsers.selectedIndex != undefined && ddl_DeptUsers.selectedIndex != null && ddl_DeptUsers.selectedIndex != -1) {
                            hdnDepuUserID.value = ddl_DeptUsers.options[ddl_DeptUsers.selectedIndex].value;
                        }
                        else {
                            hdnDepuUserID.value = 0;
                        }

                    }
                    else {
                        alert("Please select \"For the attention of\"");
                        return false;

                    }
                }
            }
        }
    }

    if (hid_matixType.value == "P" || (document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixCheckMultipleProduct").value.toLowerCase() == "true")) {
        Qty = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        Qty = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            Qty = txt_Cumulative_PriceQty.value;
        } else {
            Qty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }

    if (Qty == '' || Qty == '0') {
        document.getElementById("spn_qty").style.display = "block";
        FinalCheck = true;
        if (IsCumulative == "true") {
            txt_Cumulative_PriceQty.focus();
        } else {
            document.getElementById("txtqty").focus();
        }
        return false;
    }
    else if (Qty < QtyStartsfrom || Qty > QtyEndsTo) {
        if (hid_matixType.value != "G" && (document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixCheckMultipleProduct").value.toLowerCase() == "false")) {
            document.getElementById("spn_qty").style.display = "block";
            FinalCheck = true;
            if (IsCumulative == "true") {
                txt_Cumulative_PriceQty.focus();
            } else {
                document.getElementById("txtqty").focus();
            }
            if (Qty < QtyStartsfrom) {
                document.getElementById("spn_qty").innerHTML = "Minimum Quantity is " + QtyStartsfrom + "";
            }
            else if (Qty > QtyEndsTo) {
                document.getElementById("spn_qty").innerHTML = "Maximum Quantity is " + QtyEndsTo + "";
            }
            return false;
        }
    }
    else if (!Number(Qty)) {
        if (hid_matixType == "P") {
            document.getElementById("spn_qty").style.display = "block";
            document.getElementById("spn_qty").innerHTML = "Please Enter Only Number";
        }
        if (hid_matixType == "G") {
            document.getElementById("spn_qty").style.display = "block";
            document.getElementById("spn_qty").innerHTML = "Please Enter Only Number";
        } else {
            if (IsCumulative == "true") {
                txt_Cumulative_PriceQty.focus();
            } else {
                document.getElementById("txtqty").focus();
            }
        }
        FinalCheck = true;
        return false;
    }
    else {
        document.getElementById("spn_qty").style.display = "none";
    }

    var arrSPOV = hdnsoldPackOV.value;
    if (DrawStockFrom.toLowerCase() == "x" && IsStockItem.toLowerCase() == "true") {
        alert("This product can not currently be ordered. Please contact the system administrator and ask them to check the stock settings");
        return false;
    }

    if (isQuantityInvalid) {
        alert("Invalid quantity. This quantity does not fall in any available range.");
        return false;
    }

    /////////////Decoration
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration1");

    if (decoration1_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration2");
    if (decoration2_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration3");
    if (decoration3_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration4");
    if (decoration4_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder5_ddlDecoration3");
    if (decoration5_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration6");
    if (decoration6_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    ///////////////////////

    else if (!(Qty % arrSPOV == 0) && hid_matixType.value != "S") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("txtqty").focus();
        return false;
    }
    else if (!(Qty % arrSPOV == 0) && hid_matixType.value == "S" && IsCumulative == "true") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        if (IsCumulative == "true") {
            txt_Cumulative_PriceQty.focus();
        } else {
            document.getElementById("txtqty").focus();
        }
        return false;
    }
    else {

        var SaveToAdditionalItemsQuestion = '';
        var SaveToAdditionalItemsMultiple = '';
        var SaveToAdditionalItemsMatrix = '';
        var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
        var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPriceExcMarkup");

        var btnAddtoCart1 = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1");
        var btnAddtoCart = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart");
        var btnAddtoCartStay = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay");
        var btnAddtoCartStay1 = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1");
        var img_AddtoCart1 = document.getElementById("ctl00_ContentPlaceHolder1_img_AddtoCart1");
        var img_AddtoCart = document.getElementById("ctl00_ContentPlaceHolder1_img_AddtoCart");
        var lblfp_artwork_no_addoption1 = document.getElementById("ctl00_ContentPlaceHolder1_lblfp_artwork_no_addoption1").innerHTML;
        var lblfp_artwork = document.getElementById("ctl00_ContentPlaceHolder1_lblfp_artwork").innerHTML;

        var ddlCamapign = document.getElementById("ctl00_ContentPlaceHolder1_ddlCampaign");
        var div_Campaignerrmsg = document.getElementById("ctl00_ContentPlaceHolder1_div_CampaignErrorMsg");
        var ddlCamapignvalue = ddlCamapign.options[ddlCamapign.selectedIndex].value;
        var hdnCampaignValue = document.getElementById("ctl00_ContentPlaceHolder1_hdnCampaignValue");
        var hdnCampaignSelectedValue = document.getElementById("ctl00_ContentPlaceHolder1_hdnCampaignSelectedValue");
        if (ddlCamapign != "0") {
            hdnCampaignSelectedValue.value = ddlCamapignvalue;
        }

        if (hdnCampaignValue.value == "True") {
            if (ddlCamapignvalue == "0") {
                div_Campaignerrmsg.style.display = "block";
                FinalCheck = true;
            }
        }

        //For simple single question Type - added by rk for 2853
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {

                var QuestionOtherCostID = document.getElementById("lblQuestionID_" + i + "").innerHTML;
                var txtQuestion = document.getElementById("txtQuestion_" + i + "");
                if (Number(txtQuestion.value) != 0 && Number(QuestionOtherCostID) != 0 && txtQuestion != null) {
                    hdnSingleQuestionValues.value += QuestionOtherCostID + "»" + txtQuestion.value + "μ";
                }
            }
        }

        //if (Number(hid_QuestionTextFreeLenght.value) != 0) {
        //    for (var i = 0; i <= Number(hid_QuestionTextFreeLenght.value) - 1; i++) {

        //        var QuestionOtherCostID = document.getElementById("lblFreeTextQuestion_" + i + "").innerHTML;
        //        var txtQuestion = document.getElementById("txtFreeTextQuestion_" + i + "");
        //        if (Number(txtQuestion.value) != 0 && Number(QuestionOtherCostID) != 0 && txtQuestion != null) {
        //            hdnSingleQuestionValues.value += QuestionOtherCostID + "»" + txtQuestion.value + "μ";
        //        }
        //    }
        //}

        if (artworkFile == "M") {
            if (hid_QuestionLenght.value != "0" || hid_MultipleLenght.value != "0" || hid_MatrixLenght.value != "0") {
                if (fp_artwork.value == "") {
                    if (lblfp_artwork == "") {
                        spn_artworkFile.style.display = "block";
                        FinalCheck = true;
                        return false;
                    }
                }
            }
            else {
                if (fp_artwork_no_addoption1.value == "") {
                    if (lblfp_artwork_no_addoption1 == "") {
                        spn_artworkFile1.style.display = "block";
                        FinalCheck = true;
                        return false;
                    }
                }
            }
        }

        var Dimensn;
        hid_SaveToCart.value = "CookieID~0»UserID~0»CartTotalPrice~" + Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) + "»CartTax~" + Number(document.getElementById("lblTotalTax").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) + "»CartShipping~0";
        var UnitPrice = '';

        if (IsCumulative == "true") {
            var TempQty = Qty;
            Qty = IsCumulativeQtyForUnitPrice;
            if (Qty != '' || Qty != 0) {
                UnitPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) / Number(Qty);
                if (hid_matixType.value == "G") {
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                    }
                }
            }
            else {
                UnitPrice = "0";
            }
            Qty = TempQty;
        } else {
            if (Qty != '' || Qty != 0) {
                UnitPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) / Number(Qty);
                if (hid_matixType.value == "G") {
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                    }
                }
            }
            else {
                UnitPrice = "0";
            }
        }
        var TaxRate = document.getElementById("lblTaxRate").innerHTML;
        var TaxID = document.getElementById("lblTaxID").innerHTML;

        var Height = 0;
        var Width = 0;

        if (hid_matixType.value == "G") {
            Height = Number(txtHeight.value);
            Width = Number(txtWidth.value);

            if (Height == 0 && Width == 0) {
                spn_Dimensn.style.display = "block";
                if (!FinalCheck) {
                    txtWidth.focus();
                }
                FinalCheck = true;
                spnDimensn.innerHTML = Please_enter_dimension;
            }
            else if (Height == 0) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                txtHeight.focus();
                spnDimensn.innerHTML = Please_enter_height;
            }
            else if (Width == 0) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                txtWidth.focus();
                spnDimensn.innerHTML = Please_enter_width;
            }
            else {
                spn_Dimensn.style.display = "none";
                spnDimensn.innerHTML = '';
            }

            if (Dimensn < QtyStartsfrom || Dimensn > QtyEndsTo) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                if (Dimensn < QtyStartsfrom) {
                    spnDimensn.innerHTML = Minimum_Dimension_Is + QtyStartsfrom + " " + MeasurementValue_Sq + "";
                }
                else if (Dimensn > QtyEndsTo) {
                    spnDimensn.innerHTML = Maximum_Dimension_Is + QtyEndsTo + " " + MeasurementValue_Sq + "";
                }
            }
        }

        var mainPriceExcMarkup = Number(hid_QuantityPrice.value) - Number(hid_QuantityPriceExcMarkup.value);
        hid_SaveToCartItems.value = "" + Qty + "»" + Number(UnitPrice) + "»" + Number(hid_QuantityPrice.value) + "»" + mainPriceExcMarkup + "»" + TaxRate + "»" + TaxID + "»" + Height + "»" + Width;

        if (Number(hid_QuestionLenght.value) != 0) {

            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionQty = document.getElementById("txtQuestion_" + i + "").value;
                var SortOrderNo = document.getElementById("lblQuestionSortOrderNo_" + i + "").innerHTML;

                if (QuestionQty != '' && QuestionQty != 0) {

                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replace('</quantity>', '').replace('</question>', '').replace('</ProductBasePrice>', '').replace('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replace('<question>', QuestionQty).replace('<quantity>', QuestionQty).replace('<input>', QuestionQty).replace('[$ProductBasePrice$]', Number(hid_QuantityPrice.value)).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace(' ', '').replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';

                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo + "µ";
                }
            }
        }

        if (Number(hid_QuestionTextFreeLenght.value) != 0) {

            for (var i = 0; i <= Number(hid_QuestionTextFreeLenght.value) - 1; i++) {
                var QuestionQty = document.getElementById("txtFreeTextQuestion_" + i + "").value;
                var SortOrderNo = document.getElementById("lblTextQuestionSortOrderNo_" + i + "").innerHTML;
                var Calculation_Type = document.getElementById("hdn_FreeTextQuestion_CalculationType_" + i + "").value;
                if (QuestionQty != '' && QuestionQty != 0) {

                    var OthercostID = document.getElementById("lblFreeTextQuestionID_" + i).innerHTML;
                    //var TotalPrice = document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    //var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replace('</quantity>', '').replace('</question>', '').replace('</ProductBasePrice>', '').replace('</SubTotal>', '');
                    var TotalPrice = 0;
                    var Formula = 0;

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';

                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo + "±CalculationType»" + Calculation_Type + "µ";
                }
            }
        }

        if (Number(hid_MultipleLenght.value) != 0) {

            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                document.getElementById("chkMultiple_" + j).checked = true;
                var Check = document.getElementById("chkMultiple_" + j);
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1' && ddlMultiple.getAttribute("IsMandatory") == "1") {
                    alert("Additional options marked with a * are mandatory");
                    return false;
                }
                var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;
                var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;

                if (Check.checked) {
                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                        if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {

                            var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                            var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                            ddlMultipleValue = ddlMultipleValue.split('~');

                            var FormulaTagMul = '';
                            var Formula = '';

                            var MarkUp = 0;
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = 0;

                            var MarkupValue = 0;

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup" + "µ";
                            }

                            for (var SC = 0; SC <= Number(ddlMultipleValue[4]) - 1; SC++) {
                                if (document.getElementById("lblMultipleID_" + j + "_" + ddlMultipleValue[2] + "_" + SC) != null) {
                                    var SubSortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML;
                                    var SubOthercostID = document.getElementById("lblMultipleID_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML;

                                    var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j + "_" + ddlMultipleValue[2] + "_" + SC);
                                    if (SubddlMultiple.options[SubddlMultiple.selectedIndex].value.split('~')[6] == '1' && SubddlMultiple.getAttribute("IsMandatory") == "1") {
                                        alert("Additional options marked with a * are mandatory");
                                        return false;
                                    }
                                    var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                                    var SubSelectedValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].text;
                                    var SubMultipleValue = SubddlMultipleValue.split('~');

                                    if (SubSelectedValue.toLowerCase().trim() != "---select---") {
                                        var FormulaTagMul = SubMultipleValue[0];
                                        var Formula = '';

                                        for (var i = 0; i <= Formula.length; i++) {
                                            FormulaTagMul = FormulaTagMul.replace('<quantity>', Qty).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                        }

                                        var MarkUp = SubMultipleValue[1];
                                        var SelectedID = SubMultipleValue[2];
                                        var SelectedPrice = eval(FormulaTagMul);

                                        var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                                        if (isNaN(MarkupValue)) {
                                            MarkupValue = 0;
                                        }
                                        Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                        var TotalPrice = document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SubSelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup" + "µ";
                                        }
                                    }
                                }
                                
                            }
                        } else {

                            var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                            var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                            ddlMultipleValue = ddlMultipleValue.split('~');

                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            for (var i = 0; i <= Formula.length; i++) {
                                FormulaTagMul = FormulaTagMul.replace('<quantity>', Qty).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                            }

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "µ";

                            }
                        }
                    }
                }
            }
        }

        if (Number(hid_MatrixLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MatrixLenght.value) - 1; j++) {
                //var Check = document.getElementById("chkMatrix_" + j);
                var Check = document.getElementById("ctl00_ContentPlaceHolder1_chkMatrix_" + j + "");
                var ddlMatrixSelectedValue = Check.options[Check.selectedIndex].value;

                if (ddlMatrixSelectedValue == "0" && Check.getAttribute("IsMandatory") == "1") {
                    alert("Additional options marked with a * are mandatory");
                    return false;

                }
                if (ddlMatrixSelectedValue == "1") {
                    var OthercostID = document.getElementById("lblMatrixID_" + j).innerHTML;
                    var SortOrderNo = document.getElementById("lblMatrixSortOrderNo_" + j + "").innerHTML;

                    var AdditionalMatrixType = document.getElementById("lblMatrixType_" + j).innerHTML;
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + j);

                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        SelectedValue = ddlMatrix.options[ddlMatrix.selectedIndex].text;
                        ddlMatrixValue = ddlMatrixValue.split('~');

                        SelectedPrice = ddlMatrixValue[0];
                        Formula = ddlMatrixValue[0];
                        MarkUp = ddlMatrixValue[1];
                        SelectedID = ddlMatrixValue[2];
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "µ";
                }
            }
        }

        var AllAdditionalItemsDetails = '';
        if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion;
        }

        debugger;
        //////////////////////////Decoration Added by Amin////////////////////////////////
        if (parseFloat(hdn_DecorationCost1.value) > 0) {

            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration1");

            var decoration1 = decname1 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±SortOrderNo»" + 101 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost2.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration2");

            var decoration2 = decname2 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost2.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration2 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost2.value) + "±SortOrderNo»" + 102 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost3.value) > 0) {

            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration3");
            var decoration3 = decname3 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost3.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration3 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost3.value) + "±SortOrderNo»" + 103 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }

        if (parseFloat(hdn_DecorationCost4.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration4");
            var decoration4 = decname4 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost4.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration4 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost4.value) + "±SortOrderNo»" + 104 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost5.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration5");

            var decoration5 = decname5 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost5.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration5 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost5.value) + "±SortOrderNo»" + 105 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost6.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration6");
            var decoration6 = decname6 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;// 
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            AllAdditionalItemsDetails = AllAdditionalItemsDetails + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost6.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration6 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost6.value) + "±SortOrderNo»" + 106 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        //////////////////////////End Decoration Added by Amin////////////////////////////////

        hid_SaveToAdditionalItems.value = AllAdditionalItemsDetails;

        if (!FinalCheck) {
            var PrintReadyFileArray = hdnPrintReadyFile.value.split(',');
            if (PrintReadyFileArray[2] == "true") {
                if (RequestType == "1") {
                    if (PrintReadyFileArray[1] == "true") {
                        if (PrintReadyFileArray[0] == "1") {

                            document.getElementById("ctl00_ContentPlaceHolder1_pdfframe").src = document.getElementById("ctl00_ContentPlaceHolder1_hdnPdfPath").value;

                            document.getElementById("ctl00_ContentPlaceHolder1_pnlNormalDetails").style.display = "none";
                            document.getElementById("ctl00_ContentPlaceHolder1_pnlConfirmPRFile").style.display = "block";
                            document.getElementById("ctl00_ContentPlaceHolder1_btn_ConfirmAdd1").style.display = "block";

                            return false;
                        }
                    }
                }
            }
            loadingimg(div, divProcess);
            return true;
        }
        else {
            return false;
        }
    }
}

function onTimeout(request, context) { }
function onError(objError) { }
//for web service

function Checkout_Onclick(page) {
    if (Rewritemodule.toLowerCase() == 'on') {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + 'checkout' + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "";
        }
    }
    else {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + "checkout" + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "";
        }
    }
}

function Onclick_My_product(PriceCatalogueCategoryID) {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products" + KeySeparator + PriceCatalogueCategoryID + FileExtension;
    }
    else {
        window.location = strSitepath + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
    }
}

function Onclick_Searchproduct(searchCookie) {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products/searchproducts" + KeySeparator + searchCookie + FileExtension;
    }
    else {
        window.location = strSitepath + "products/searchproducts.aspx?type=" + searchCookie;
    }
}

function updateCharCount(textarea, maxChars) {
    var typed = textarea.value.length;
    var counterId = "charCount_" + textarea.id.replace("txtFreeTextQuestion_", "");
    var counter = document.getElementById(counterId);
    if (counter) {
        counter.textContent = typed;
    }
}

function ForAdditional_Grouping(GroupID, OtherCostID) {
    debugger;
    if (Number(GroupID) != 0) {

        //For Matrix Type
        if (Number(hid_MatrixLenght.value) != 0) {
            for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
                var MultipleGroupID = document.getElementById("lblMatrixGroupID_" + k + "").innerHTML;
                var MatrixOthercostID = document.getElementById("lblMatrixID_" + k).innerHTML;
                if (Number(MatrixOthercostID) == Number(OtherCostID)) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MatrixOthercostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.checked = false;
                    MatrixCheck.setAttribute("grpvalue", "0");
                    document.getElementById("lblMatrixPrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Multiple Choice Type
        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var MultipleGroupID = document.getElementById("lblMultipleGroupID_" + j + "").innerHTML;
                var MultipleOtherCostID = document.getElementById("lblMultipleID_" + j + "").innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                if (Number(MultipleOtherCostID) == Number(OtherCostID)) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    ddlMultiple.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MultipleOtherCostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                    chkMultiple.checked = false;
                    ddlMultiple.selectedIndex = 0;
                    ddlMultiple.setAttribute("grpvalue", "0");
                    document.getElementById("lblMultiplePrice_" + j + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Question Type
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionGroupID = document.getElementById("lblQuestionGroupID_" + i + "").innerHTML;
                var QuestionOtherCostID = document.getElementById("lblQuestionID_" + i + "").innerHTML;

                var txtQuestion = document.getElementById("txtQuestion_" + i + "");
                if (Number(QuestionOtherCostID) == Number(OtherCostID)) {
                    txtQuestion.setAttribute("grpvalue", "1");
                }

                if (Number(QuestionGroupID) == Number(GroupID) && Number(QuestionOtherCostID) != Number(OtherCostID) && Number(QuestionGroupID) != 0) {
                    document.getElementById("txtQuestion_" + i + "").value = "";
                    document.getElementById("lblPrice_" + i + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    txtQuestion.setAttribute("grpvalue", "0");
                }
            }
        }
    }
}
//.......................................Old function......................................................

function Tocall_mainFunc() {
    var MainQuantity = 0;
    if (hid_matixType.value == "S") {

        if (IsCumulative == "true") {
            MainQuantity = txt_Cumulative_PriceQty.value;
        } else {
            MainQuantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    else {
        MainQuantity = document.getElementById("txtqty").value;
    }

    Tocalculate_totalPrice(MainQuantity, '0');
}

function CheckIsDecimal(value) {
    reg = /^\-?([1-9]\d*|0)(\.\d?[1-9])?$/;
    if (!reg.test(value)) {
        document.getElementById("spn_qty").style.display = "block";
        document.getElementById("spn_qty").innerHTML = Please_enter_quantity_in_numbers;
        //spn_qty.innerHTML = "Please enter quantity in numbers";
        document.getElementById("txtqty").value = "";
        return false;
    }
    document.getElementById("spn_qty").style.display = "none";
    return reg.test(value);
}

function CheckIsDecimal_Textbox(id, value) {
    reg = /^\-?([1-9]\d*|0)(\.\d?[1-9])?$/;
    if (!reg.test(value)) {
        document.getElementById("spn_qty").style.display = "block";
        document.getElementById("spn_qty").innerHTML = Please_enter_quantity_in_numbers;
        //spn_qty.innerHTML = "Please enter quantity in numbers";
        id.value = "";
        return false;
    }
    document.getElementById("spn_qty").style.display = "none";
    return reg.test(value);
}

function NeedStockReplenish() {

    if (rdstkbreplenish.checked) {
        var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
        document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCartStay1").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_EditProduct1").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_EditProduct2").disabled = false;
        if (IsShowStock == 'true') {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";
        }
    }
    else {
        if (hid_matixType.value == "P") {
            var qnty = document.getElementById("txtqty").value;
            Tocalculate_totalPrice(qnty, '0');
            CheckStockAvailability(qnty);
        }
        else if (hid_matixType.value == "G") {
            var qnty = document.getElementById("txtqty").value;
            Tocalculate_totalPrice(qnty, '0');
            Tocalculate_totalPrice(qnty, '0');
        }
        else if (hid_matixType.value == "S") {
            Tocalculate_totalPrice('0', '0');
            CheckStockAvailability('0');
        }
    }
}

function PriceOnBlur_Matrix(Obj) {
    debugger;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixString = '';
    var SubMultiplePrice = 0;
    var SubValue = 0;
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");

    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                    if (document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC) != null) {
                        MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    }
                //    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {
                MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    var decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;






    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice')).innerHTML = sellingPrice;
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));

    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));

    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var Markup = '';
    var FinalPrice = '';

    var MatrixQuantity = txt_Markup.value;
    var totalQuantity = 0;
    var quantityInputs = document.querySelectorAll('input[name^="ctl00$ContentPlaceHolder1$GridInkCostView$ctl00$ctl"][id$="_txt_Markup"]');
    var dropdowns = document.querySelectorAll('select[name^="ctl00$ContentPlaceHolder1$GridInkCostView$ctl00$ctl"][id$="_ddl_Markup"]');
    var priceElements = document.querySelectorAll('span[id^="ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl"][id$="_lbl_SellingPrice"]');
    for (var i = 0; i < quantityInputs.length; i++) {
        var quantity = parseFloat(quantityInputs[i].value) || 0; // Parse float or default to 0
        totalQuantity += quantity;
        MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity + "»CartShipping~0%";
    }
    var selectedQuantity = 0;
    for (var i = 0; i < dropdowns.length; i++) {
        var quantity1 = parseFloat(dropdowns[i].options[dropdowns[i].selectedIndex].text) || 0;
        selectedQuantity += quantity1;
        MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity1 + "»CartShipping~0%";
    }
    // Add the selected quantity to the total
    totalQuantity += selectedQuantity;
    //var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    //iRows = grd.getElementsByTagName('tr');
    //if (iRows.length > 0) {
    //  var i = 4;
    //for (var k = 1; k < iRows.length; k++) {
    //  Markup = Number(Markup) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_txt_Markup").value);
    // FinalPrice = Number(FinalPrice) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_lbl_SellingPrice").innerHTML);
    //i = i + 2;
    //}
    //}
    if (MatrixQuantity == '') {
        MatrixQuantity = 0;
    }
    var totalPrice = 0;
    var cartTotalPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
    //var priceElements = document.querySelectorAll('span[id^="ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl"][id$="_lbl_SellingPrice"]');
    for (var i = 0; i < priceElements.length; i++) {
        var price = parseFloat(priceElements[i].textContent) || 0; // Parse float or default to 0
        totalPrice += price;
        //MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + price + "»CartShipping~0%";
    }
    //var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    //var iRows = grd.getElementsByTagName('tr');
    //for (var k = 1; k < iRows.length; k++) {
    //  var quantity = Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + (k * 2 + 2) + "_txt_Markup").value);
    // MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity + "»CartShipping~0%";
    //}
    hid_MultipleMatrixValues.value = MatrixString;
    //document.getElementById("txtqty").value = Markup;
    document.getElementById("txtqty").value = totalQuantity;

    //document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);
    //document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);


    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, totalPrice, 2, '', false, false, false), true);
    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, totalPrice, 2, '', false, false, false), true);

    //Tocalculate_totalPrice(Markup,'0'); 
    //}

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    var decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;






    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice')).innerHTML = sellingPrice;
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));

    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));

    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var Markup = '';
    var FinalPrice = '';

    var MatrixQuantity = txt_Markup.value;
    var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    iRows = grd.getElementsByTagName('tr');
    if (iRows.length > 0) {
        var i = 4;
        for (var k = 1; k < iRows.length; k++) {
            Markup = Number(Markup) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_txt_Markup").value);
            FinalPrice = Number(FinalPrice) + Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + i + "_lbl_SellingPrice").innerHTML);
            i = i + 2;
        }
    }
    if (MatrixQuantity == '') {
        MatrixQuantity = 0;
    }
    var cartTotalPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
    var grd = document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00");
    var iRows = grd.getElementsByTagName('tr');
    for (var k = 1; k < iRows.length; k++) {
        var quantity = Number(document.getElementById("ctl00_ContentPlaceHolder1_GridInkCostView_ctl00_ctl0" + (k * 2 + 2) + "_txt_Markup").value);
        MatrixString += "CookieID~" + cartTotalPrice + "»CartTotalPrice~" + quantity + "»CartShipping~0%";
    }
    hid_MultipleMatrixValues.value = MatrixString;
    document.getElementById("txtqty").value = Markup;

    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);
    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(FinalPrice), 2, '', false, false, false), true);

    //Tocalculate_totalPrice(Markup,'0'); 
}


function VisibleAdditionaloption(WebotherCostID) {
    debugger;




    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);

            if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {
                for (var c = 0; c < ddlMultiple.options.length; c++) {

                    if (ddlMultiple.options[c].text.toLowerCase().trim() != '---NA---' &&
                        ddlMultiple.options[c].value.split('~')[2] == ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'block';

                        document.getElementById("lblMultiplePrice_" + j + "").style.display = 'none';

                    } else if (ddlMultiple.options[c].value.split('~')[2] != ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'none';
                        if (IsDisplayAdditionalOptions == "false") {
                            document.getElementById("lblMultiplePrice_" + j + "").style.display = 'block';
                        }
                    }
                }
            }
        }
        Final_SellingPrice();
    }
}

function calculateDecoration(decoration) {
    var MainQuantity = 0;
    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            MainQuantity = txt_Cumulative_PriceQty.value;
        } else {
            MainQuantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    else {
        MainQuantity = document.getElementById("txtqty").value;
    }
    //if (decoration == 1) {
    var Qty = parseInt(MainQuantity);
    if (decname1) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration1");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {


            var decorationArray = hdn_Decoration1.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration1Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost1.value = total;
        }
        else {
            document.getElementById("lblDecoration1Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost1.value = 0;
        }
    }
    //  document.getElementById("lblDecoration1Cost").innerHTML == 'Hello';
    //}
    //if (decoration == 2) {
    if (decname2) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration2");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {

            var decorationArray = hdn_Decoration2.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration2Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost2.value = total;
        }
        else {
            document.getElementById("lblDecoration2Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost2.value = 0;;
        }
    }
    //}
    //if (decoration == 3) {
    if (decname3) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration3");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var decorationArray = hdn_Decoration3.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration3Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost3.value = total;
        }
        else {
            document.getElementById("lblDecoration3Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost3.value = 0;
        }
    }
    //}
    //if (decoration == 4) {
    if (decname4) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration4");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var decorationArray = hdn_Decoration4.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration4Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost4.value = total;
        }
        else {
            document.getElementById("lblDecoration4Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost4.value = 0;
        }
    }
    //}
    //if (decoration == 5) {
    if (decname5) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration5");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var decorationArray = hdn_Decoration5.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration5Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost5.value = total;
        }
        else {
            document.getElementById("lblDecoration5Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost5.value = 0;
        }
    }
    //}
    //if (decoration == 6) {
    if (decname6) {
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ddlDecoration6");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var decorationArray = hdn_Decoration6.value.split('~');

            var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
            var minimumCost = parseFloat(decorationArray[2])
            var total = cost > minimumCost ? cost : minimumCost
            document.getElementById("lblDecoration6Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost6.value = total;
        }
        else {
            document.getElementById("lblDecoration6Cost").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
            hdn_DecorationCost6.value = 0;
        }
    }
    //}

    //Tocall_mainFunc();

}
