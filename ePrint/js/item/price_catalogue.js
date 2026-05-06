function GetCurSym(Amount, IsExist) {

    return GetCurrencyinRequiredFormate("", true);
}


function MatrixTypeChange(ddlValue) {

    if (ddlValue == "pricebands") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {

                document.getElementById("txtQty_" + i + "").style.width = "80px";
                document.getElementById("txtQty_from_" + i + "").style.display = "block";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";

                document.getElementById("txtWeight_" + i + "").style.display = "none";
                document.getElementById("txtWidth_" + i + "").style.display = "none";
                document.getElementById("txtHeight_" + i + "").style.display = "none";
                document.getElementById("txtLength_" + i + "").style.display = "none";
                document.getElementById("chkHideOnEStore_" + i + "").style.display = "block";
                document.getElementById("td_HideOnEStore_" + i + "").style.width = "5%";
                

                document.getElementById("txtWeight_td" + i + "").style.width = "0px";
                document.getElementById("txtWidth_td" + i + "").style.width = "0px";
                document.getElementById("txtHeight_td" + i + "").style.width = "0px";
                document.getElementById("txtLength_td" + i + "").style.width = "0px";

                document.getElementById("txtSellingPrice_td" + i + "").style.width = "23%"; //"13%";
                document.getElementById("txtCost_td" + i + "").style.width = "20%"; //"10%";
                document.getElementById("txtMarkup_td" + i + "").style.width = "20%"; //"10%";

                document.getElementById("td_txtfrmqty_" + i + "").style.width = "7%";
                document.getElementById("td_txtcenterqty_" + i + "").style.width = "7%";

            }
        }
        //txt_SoldinPack.value = 1;
        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("spn_help_pricebands").style.display = "block";
        document.getElementById("div_td_toqty").innerHTML = "";
        document.getElementById("spn_Qtyfrm").innerHTML = "";
        document.getElementById("spn_Qty").innerHTML = "Quantity";
        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = sell_Price_For1 + " (" + GetCurSym('', true) + ")";

        document.getElementById("spn_weight").style.display = "none";
        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_weight_td").style.width = "0px";
        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";

        document.getElementById("spn_header_sellingprice_td").style.width = "23%"; //"13%";
        document.getElementById("spn_cost_td").style.width = "20%"; //"10%";
        document.getElementById("spn_Markup_td").style.width = "20%"; //"10%";

        //document.getElementById("td_frmqty").style.width = "7%";
        document.getElementById("td_frmqty").style.width = "6%";

        document.getElementById("spn_Qty_td").style.width = "7%";

        document.getElementById("td_eStoreHideChk").style.width = "6%";
        document.getElementById("spn_eStoreHideChk").style.display = "block";


    }
    else if (ddlValue == "simplematrix") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("chkHideOnEStore_" + i + "").style.display = "block";
                document.getElementById("td_HideOnEStore_" + i + "").style.width = "5%";
                document.getElementById("txtWeight_" + i + "").style.display = "none";
                document.getElementById("txtWidth_" + i + "").style.display = "none";
                document.getElementById("txtHeight_" + i + "").style.display = "none";
                document.getElementById("txtLength_" + i + "").style.display = "none";

                document.getElementById("txtWidth_td" + i + "").style.width = "0px";
                document.getElementById("txtHeight_td" + i + "").style.width = "0px";
                document.getElementById("txtLength_td" + i + "").style.width = "0px";
                document.getElementById("txtWeight_td" + i + "").style.width = "0px";

                document.getElementById("txtSellingPrice_td" + i + "").style.width = "13%"; //"13%";
                document.getElementById("txtCost_td" + i + "").style.width = "10%"; //"10%";
                document.getElementById("txtMarkup_td" + i + "").style.width = "10%"; //"10%";

                document.getElementById("txtQty_from_" + i + "").style.display = "none";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "none";

                if (document.getElementById("td_txtfrmqty_" + i + "") != null) {
                    document.getElementById("td_txtfrmqty_" + i + "").style.width = "0px";
                }

                if (document.getElementById("td_txtcenterqty_" + i + "") != null) {
                    document.getElementById("td_txtcenterqty_" + i + "").style.width = "0px";
                }
            }
        }
        //txt_SoldinPack.value = 1;
        document.getElementById("spn_help_pricebands").style.display = "block";
        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("div_td_toqty").innerHTML = "Quantity";
        document.getElementById("spn_Qtyfrm").innerHTML = "";
        document.getElementById("spn_Qty").innerHTML = "";
        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + " (" + GetCurSym('', true) + ")";

        document.getElementById("spn_weight").style.display = "none";
        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_weight_td").style.width = "0px";
        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";

        document.getElementById("spn_header_sellingprice_td").style.width = "13%"; //"13%";
        document.getElementById("spn_cost_td").style.width = "10%"; //"10%";
        document.getElementById("spn_Markup_td").style.width = "10%"; //"10%";

        document.getElementById("td_frmqty").style.width = "0px";
        document.getElementById("spn_Qty_td").style.width = "0px";
        document.getElementById("spn_eStoreHideChk").style.display = "block";
        document.getElementById("td_eStoreHideChk").style.width = "5%";

    }
    else if (ddlValue == "signagematrix") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("chkHideOnEStore_" + i + "").style.display = "none";
                document.getElementById("td_HideOnEStore_" + i + "").style.width = "0%";
                document.getElementById("txtQty_from_" + i + "").style.display = "block";


                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";
                document.getElementById("txtQty_" + i + "").style.width = "80px";
                document.getElementById("txtQty_from_" + i + "").style.width = "80px";

                document.getElementById("txtWeight_" + i + "").style.display = "none";
                document.getElementById("txtWidth_" + i + "").style.display = "none";
                document.getElementById("txtHeight_" + i + "").style.display = "none";
                document.getElementById("txtLength_" + i + "").style.display = "none";

                document.getElementById("txtWeight_td" + i + "").style.width = "0px"; // "15%";
                document.getElementById("txtWidth_td" + i + "").style.width = "0px";
                document.getElementById("txtHeight_td" + i + "").style.width = "0px";
                document.getElementById("txtLength_td" + i + "").style.width = "0px";

                document.getElementById("txtCost_td" + i + "").style.width = "15%";
                document.getElementById("txtSellingPrice_td" + i + "").style.width = "20%"; // "20%";
                document.getElementById("txtMarkup_td" + i + "").style.width = "15%";

                document.getElementById("td_txtfrmqty_" + i + "").style.width = "7%";
                document.getElementById("td_txtcenterqty_" + i + "").style.width = "7%";

            }
        }
        txt_SoldinPack.value = 1;
        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("spn_help_pricebands").style.display = "block";

        document.getElementById("spn_weight").style.display = "none";
        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_weight_td").style.width = "0px"; // "15%";
        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";

        document.getElementById("spn_header_sellingprice_td").style.width = "20%"; // "20%";
        document.getElementById("spn_cost_td").style.width = "15%";

        document.getElementById("spn_Markup_td").style.width = "15%";
        document.getElementById("spn_Qty").innerHTML = "";
        document.getElementById("spn_Qtyfrm").innerHTML = "From" + " (" + Measurementvalue + ")";
        document.getElementById("div_td_toqty").innerHTML = "To" + " (" + Measurementvalue + ")";
        document.getElementById("spn_cost").innerHTML = Cost_Price + " (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + "  (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
        document.getElementById("td_frmqty").style.width = "7%";
        document.getElementById("spn_Qty_td").style.width = "7%";
        document.getElementById("spn_eStoreHideChk").style.display = "none";
        document.getElementById("td_eStoreHideChk").style.width = "0%";

    }
}

function DisplayRightMsg() {
    if (hid_ddlMatrixType.value == "P") {


        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("spn_help_pricebands").style.display = "block";
        document.getElementById("div_td_toqty").innerHTML = "";
        document.getElementById("spn_Qtyfrm").innerHTML = "";
        document.getElementById("spn_Qty").innerHTML = "Quantity";
        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = sell_Price_For1 + " (" + GetCurSym('', true) + ")";
        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_weight_td").style.width = "0px";
        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";

        document.getElementById("spn_cost_td").style.width = "20%";

        document.getElementById("spn_Markup_td").style.width = "20%";

        //document.getElementById("td_frmqty").style.width = "7%";
        document.getElementById("td_frmqty").style.width = "6%";
        document.getElementById("spn_Qty_td").style.width = "7%";


    }
    else if (hid_ddlMatrixType.value == "S") {

        document.getElementById("spn_help_pricebands").style.display = "block";
        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("div_td_toqty").innerHTML = "Quantity";
        document.getElementById("spn_Qtyfrm").innerHTML = "";
        document.getElementById("spn_Qty").innerHTML = "";
        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + " (" + GetCurSym('', true) + ")";

        document.getElementById("spn_weight").style.display = "none";
        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";
        document.getElementById("spn_weight_td").style.width = "0px";

        document.getElementById("spn_header_sellingprice_td").style.width = "13%";
        document.getElementById("spn_cost_td").style.width = "10%";

        document.getElementById("spn_Markup_td").style.width = "10%";

        for (var i = 0; i < TotalRow; i++) {
            document.getElementById("td_txtfrmqty_" + i + "").style.width = "0px";
            document.getElementById("td_txtcenterqty_" + i + "").style.width = "0px";
        }
    }
    else if (hid_ddlMatrixType.value == "G") {
        document.getElementById("spn_help_simplematrix").style.display = "none";
        document.getElementById("spn_help_pricebands").style.display = "block";

        document.getElementById("spn_width").style.display = "none";
        document.getElementById("spn_weight_td").style.display = "none";
        document.getElementById("spn_height").style.display = "none";
        document.getElementById("spn_length").style.display = "none";

        document.getElementById("spn_weight_td").style.width = "0px";
        document.getElementById("spn_width_td").style.width = "0px";
        document.getElementById("spn_height_td").style.width = "0px";
        document.getElementById("spn_length_td").style.width = "0px";

        document.getElementById("spn_header_sellingprice_td").style.width = "20%";
        document.getElementById("spn_cost_td").style.width = "15%";

        document.getElementById("spn_Markup_td").style.width = "15%";

        document.getElementById("spn_Qty").innerHTML = "";
        document.getElementById("spn_Qtyfrm").innerHTML = "From" + " (" + Measurementvalue + ")";
        document.getElementById("div_td_toqty").innerHTML = "To" + " (" + Measurementvalue + ")";
        document.getElementById("spn_cost").innerHTML = Cost_Price + " (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + "  (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
        document.getElementById("td_frmqty").style.width = "7%";
        document.getElementById("spn_Qty_td").style.width = "7%";


    }

}
//function MatrixTypeChange(ddlValue) {
//    if (ddlValue == "pricebands") {
//        for (var i = 0; i < TotalRow; i++) {
//            if (document.getElementById("txtQty_from_" + i + "") != null) {

//                document.getElementById("txtSellingPrice_td" + i + "").style.width = "13%";
//                document.getElementById("txtMarkup_td" + i + "").style.width = "10%";
//                document.getElementById("txtWeight_td" + i + "").style.width = "10%";
//                document.getElementById("spn_header_sellingprice_td").style.width = "13%";
//                document.getElementById("txtQty_from_" + i + "").style.display = "block";
//                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";
//                document.getElementById("txtCost_td" + i + "").style.width = "10%";
//                document.getElementById("txtQty_" + i + "").style.width = "80px";
//                document.getElementById("txtWidth_" + i + "").style.display = "block";
//                document.getElementById("txtHeight_" + i + "").style.display = "block";
//                document.getElementById("txtLength_" + i + "").style.display = "block";
//                document.getElementById("txtWidth_td" + i + "").style.width = "10%";
//                document.getElementById("txtHeight_td" + i + "").style.width = "10%";
//                document.getElementById("txtLength_td" + i + "").style.width = "10%";
//                document.getElementById("txtMarkup_td" + i + "").style.width = "10%";
//                document.getElementById("td_txtfrmqty_" + i + "").style.width = "7%";
//                document.getElementById("td_txtcenterqty_" + i + "").style.width = "7%";

//            }
//        }
//        txt_SoldinPack.value = 1;
//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("div_td_toqty").innerHTML = "";
//        document.getElementById("spn_Qtyfrm").innerHTML = "";
//        document.getElementById("spn_Qty").innerHTML = "Quantity";
//        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = sell_Price_For1 + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_width").style.display = "block";
//        document.getElementById("spn_height").style.display = "block";
//        document.getElementById("spn_length").style.display = "block";
//        document.getElementById("spn_cost_td").style.width = "10%";
//        document.getElementById("spn_weight_td").style.width = "10%";
//        document.getElementById("spn_Markup_td").style.width = "10%";
//        document.getElementById("spn_width_td").style.width = "10%";
//        document.getElementById("spn_height_td").style.width = "10%";
//        document.getElementById("spn_length_td").style.width = "10%";
//        document.getElementById("td_frmqty").style.width = "7%";
//        document.getElementById("spn_Qty_td").style.width = "7%";

//    }
//    else if (ddlValue == "simplematrix") {
//        for (var i = 0; i < TotalRow; i++) {
//            if (document.getElementById("txtQty_from_" + i + "") != null) {

//                document.getElementById("txtWidth_td" + i + "").style.width = "block";
//                document.getElementById("txtHeight_td" + i + "").style.width = "block";
//                document.getElementById("txtLength_td" + i + "").style.width = "block";
//                document.getElementById("txtWidth_" + i + "").style.display = "block";
//                document.getElementById("txtHeight_" + i + "").style.display = "block";
//                document.getElementById("txtLength_" + i + "").style.display = "block";
//                document.getElementById("txtWidth_td" + i + "").style.width = "10%";
//                document.getElementById("txtHeight_td" + i + "").style.width = "10%";
//                document.getElementById("txtLength_td" + i + "").style.width = "10%";
//                document.getElementById("txtCost_td" + i + "").style.width = "10%";
//                document.getElementById("txtSellingPrice_td" + i + "").style.width = "13%";
//                document.getElementById("txtMarkup_td" + i + "").style.width = "10%";
//                document.getElementById("txtWeight_td" + i + "").style.width = "10%";
//                document.getElementById("txtQty_from_" + i + "").style.display = "none";
//                document.getElementById("spn_qty_sep_" + i + "").style.display = "none";
//                //                document.getElementById("td_txtfrmqty_" + i + "").style.width = "0px";
//                //                document.getElementById("td_txtcenterqty_" + i + "").style.width = "0px";

//                if (document.getElementById("td_txtfrmqty_" + i + "") != null) {
//                    document.getElementById("td_txtfrmqty_" + i + "").style.width = "0px";
//                }

//                if (document.getElementById("td_txtcenterqty_" + i + "") != null) {
//                    document.getElementById("td_txtcenterqty_" + i + "").style.width = "0px";
//                }
//            }
//        }
//        txt_SoldinPack.value = 1;
//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("div_td_toqty").innerHTML = "Quantity";
//        document.getElementById("spn_Qtyfrm").innerHTML = "";
//        document.getElementById("spn_Qty").innerHTML = "";
//        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_width").style.display = "block";
//        document.getElementById("spn_height").style.display = "block";
//        document.getElementById("spn_length").style.display = "block";
//        document.getElementById("spn_header_sellingprice_td").style.width = "13%";
//        document.getElementById("spn_cost_td").style.width = "10%";
//        document.getElementById("spn_weight_td").style.width = "10%";
//        document.getElementById("spn_Markup_td").style.width = "10%";
//        document.getElementById("spn_width_td").style.width = "10%";
//        document.getElementById("spn_height_td").style.width = "10%";
//        document.getElementById("spn_length_td").style.width = "10%";
//        document.getElementById("td_frmqty").style.width = "0px";
//        document.getElementById("spn_Qty_td").style.width = "0px";

//    }
//    else if (ddlValue == "signagematrix") {
//        for (var i = 0; i < TotalRow; i++) {
//            if (document.getElementById("txtQty_from_" + i + "") != null) {
//                document.getElementById("txtQty_from_" + i + "").style.display = "block";
//                document.getElementById("txtWidth_" + i + "").style.display = "none";
//                document.getElementById("txtHeight_" + i + "").style.display = "none";
//                document.getElementById("txtLength_" + i + "").style.display = "none";
//                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";
//                document.getElementById("txtQty_" + i + "").style.width = "80px";
//                document.getElementById("txtWidth_td" + i + "").style.width = "none";
//                document.getElementById("txtHeight_td" + i + "").style.width = "none";
//                document.getElementById("txtLength_td" + i + "").style.width = "none";
//                document.getElementById("txtWidth_td" + i + "").style.width = "0px";
//                document.getElementById("txtHeight_td" + i + "").style.width = "0px";
//                document.getElementById("txtLength_td" + i + "").style.width = "0px";
//                document.getElementById("txtWidth_" + i + "").styledisplay = "none";
//                document.getElementById("txtHeight_" + i + "").style.display = "none";
//                document.getElementById("txtLength_" + i + "").style.display = "none";
//                document.getElementById("txtCost_td" + i + "").style.width = "15%";
//                document.getElementById("txtSellingPrice_td" + i + "").style.width = "20%";
//                document.getElementById("txtMarkup_td" + i + "").style.width = "15%";
//                document.getElementById("txtWeight_td" + i + "").style.width = "15%";
//                document.getElementById("td_txtfrmqty_" + i + "").style.width = "7%";
//                document.getElementById("td_txtcenterqty_" + i + "").style.width = "7%";

//            }
//        }
//        txt_SoldinPack.value = 1;
//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("spn_width").style.display = "none";
//        document.getElementById("spn_height").style.display = "none";
//        document.getElementById("spn_length").style.display = "none";
//        document.getElementById("spn_width_td").style.width = "0px";
//        document.getElementById("spn_height_td").style.width = "0px";
//        document.getElementById("spn_length_td").style.width = "0px";
//        document.getElementById("spn_header_sellingprice_td").style.width = "20%";
//        document.getElementById("spn_cost_td").style.width = "15%";
//        document.getElementById("spn_weight_td").style.width = "15%";
//        document.getElementById("spn_Markup_td").style.width = "15%";
//        document.getElementById("spn_Qty").innerHTML = "";
//        document.getElementById("spn_Qtyfrm").innerHTML = "From" + " (" + Measurementvalue + ")";
//        document.getElementById("div_td_toqty").innerHTML = "To" + " (" + Measurementvalue + ")";
//        document.getElementById("spn_cost").innerHTML = Cost_Price + " (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + "  (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
//        document.getElementById("td_frmqty").style.width = "7%";
//        document.getElementById("spn_Qty_td").style.width = "7%";

//    }
//}
//function DisplayRightMsg() {
//    if (hid_ddlMatrixType.value == "P") {

//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("div_td_toqty").innerHTML = "";
//        document.getElementById("spn_Qtyfrm").innerHTML = "";
//        document.getElementById("spn_Qty").innerHTML = "Quantity";
//        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = sell_Price_For1 + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_width").style.display = "block";
//        document.getElementById("spn_height").style.display = "block";
//        document.getElementById("spn_length").style.display = "block";
//        document.getElementById("spn_cost_td").style.width = "10%";
//        document.getElementById("spn_weight_td").style.width = "10%";
//        document.getElementById("spn_Markup_td").style.width = "10%";
//        document.getElementById("spn_width_td").style.width = "10%";
//        document.getElementById("spn_height_td").style.width = "10%";
//        document.getElementById("spn_length_td").style.width = "10%";
//        document.getElementById("td_frmqty").style.width = "7%";
//        document.getElementById("spn_Qty_td").style.width = "7%";

//    }
//    else if (hid_ddlMatrixType.value == "S") {

//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("div_td_toqty").innerHTML = "Quantity";
//        document.getElementById("spn_Qtyfrm").innerHTML = "";
//        document.getElementById("spn_Qty").innerHTML = "";
//        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + " (" + GetCurSym('', true) + ")";
//        document.getElementById("spn_width").style.display = "block";
//        document.getElementById("spn_height").style.display = "block";
//        document.getElementById("spn_length").style.display = "block";
//        document.getElementById("spn_header_sellingprice_td").style.width = "13%";
//        document.getElementById("spn_cost_td").style.width = "10%";
//        document.getElementById("spn_weight_td").style.width = "10%";
//        document.getElementById("spn_Markup_td").style.width = "10%";
//        document.getElementById("spn_width_td").style.width = "10%";
//        document.getElementById("spn_height_td").style.width = "10%";
//        document.getElementById("spn_length_td").style.width = "10%";
//        document.getElementById("td_txtfrmqty_" + i + "").style.width = "0px";
//        document.getElementById("td_txtcenterqty_" + i + "").style.width = "0px";

//    }
//    else if (hid_ddlMatrixType.value == "G") {
//        document.getElementById("spn_help_simplematrix").style.display = "none";
//        document.getElementById("spn_help_pricebands").style.display = "block";
//        document.getElementById("spn_width").style.display = "none";
//        document.getElementById("spn_height").style.display = "none";
//        document.getElementById("spn_length").style.display = "none";
//        document.getElementById("spn_width_td").style.width = "0px";
//        document.getElementById("spn_height_td").style.width = "0px";
//        document.getElementById("spn_length_td").style.width = "0px";
//        document.getElementById("spn_header_sellingprice_td").style.width = "20%";
//        document.getElementById("spn_cost_td").style.width = "15%";
//        document.getElementById("spn_weight_td").style.width = "15%";
//        document.getElementById("spn_Markup_td").style.width = "15%";
//        document.getElementById("spn_Qty").innerHTML = "";
//        document.getElementById("spn_Qtyfrm").innerHTML = "From" + " (" + Measurementvalue + ")";
//        document.getElementById("div_td_toqty").innerHTML = "To" + " (" + Measurementvalue + ")";
//        document.getElementById("spn_cost").innerHTML = Cost_Price + " (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
//        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + "  (" + GetCurSym('', true) + "/" + Measurementvalue + ")";
//        document.getElementById("td_frmqty").style.width = "7%";
//        document.getElementById("spn_Qty_td").style.width = "7%";
//    }

//}
function Calculate_Markup(sellObj, index) {
    var isMatrixCalculation = document.getElementById("ctl00_ContentPlaceHolder1_hdn_isMatrixCalculation").value;

    sellObj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 6, '', false, false, false);

    var txtCost = document.getElementById("txtCost_" + index + "");
    var txtMarkup = document.getElementById("txtMarkup_" + index + "");
    if (Number(sellObj.value) != 0 && Number(txtCost.value) != 0) {
        var MarkupValue = Number(Number(sellObj.value) - Number(txtCost.value)) / Number(txtCost.value);
        MarkupValue = Number(MarkupValue) * 100;

        //calculating the sell Price using New Mark up:
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 6))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(sellObj.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        //by natraj, While changing Selling Price, Cost should not get update, as per Vikash sir on 11.5.2012
        //txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, New_Sell, 2, '', false, false, false);
    }
    else if (Number(sellObj.value) != 0 || Number(txtCost.value) != 0) {

        if (Number(sellObj.value) == 0 && isMatrixCalculation.toLowerCase() == "true") {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, -100, 6, '', false, false, false);
        } else if (Number(txtCost.value) == 0 && Number(sellObj.value) != 0 && isMatrixCalculation.toLowerCase() == "true") {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 6, '', false, false, false);
            //txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 6, '', false, false, false);
        } else {
            txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 6, '', false, false, false);
        }
        
    }
}


function SetMarkupToAll(obj, index) {
    for (var i = 0; i < TotalRow; i++) {
        if ((document.getElementById("txtMarkup_" + i + "") != null && i == 0) || (document.getElementById("txtMarkup_" + i + "") != null && parseFloat(document.getElementById("txtMarkup_" + i + "").value) == 0 && i > 0)) {
            document.getElementById("txtMarkup_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);

            var txtCost = document.getElementById("txtCost_" + i + "");
            var txtSellingPrice = document.getElementById("txtSellingPrice_" + i + "");
            if (!isNaN(obj.value)) {
                if (!isNaN(txtCost.value)) {
                    var MarkupValue = (obj.value * txtCost.value) / 100;
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 6, '', false, false, false);
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 6, '', false, false, false);
                }
                else {
                    txtSellingPrice.value = "0.00";
                }
            }
            else {
                obj.value = "0.00";
            }
        }
    }
}

var EditableURL = '';
function FindSuccsss1(result) {
    var GetResult = result.split('µ');
    var GetResult1 = GetResult[0];
    var GetResult2 = GetResult[1];

    if (GetResult1 == '0' && GetResult2 == '1') {
        alert('Please note the PDF is being loaded and will be available for use in a few minutes.');
    }
    else if (GetResult1 == '2' && GetResult2 == '1') {
        alert("Sorry your file didn't load correctly. You can try again and if it still doesn't work please contact  support@hexicomsoftware.com for assistance.");
    }
    else {
        OpenEditableTemplate(EditableURL);
    }
}

function Onclick_editImage(url, pricecatlogueID, DbID) {
    EditableURL = url;
    AutoFill.GetIsConvertedCroped(pricecatlogueID, DbID, FindSuccsss1);
}