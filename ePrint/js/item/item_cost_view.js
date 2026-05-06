// JScript File
function roundNumber(rnum, rlength) {

    return rnum;
}
function MarkupOnBlur(Obj, Markup) {
    if (!isNaN(Markup)) {
        var idlist = MarkupIdList.split('±');
        for (var i = 0; i < idlist.length; i++) {
            if (idlist[i] != '') {
                var spn = "spnSellingPrice_" + idlist[i] + "";
                var mar = "txtMarkUp_" + idlist[i] + "";
                var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "";

                document.getElementById(mar).value = roundNumber(Markup, 2);
                hdn_Markup.value = Markup;

                var SellValue = document.getElementById(spnSellExMark).innerHTML;
                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;
                MarkupValue = roundNumber(MarkupValue, 2);
                var finalValue = Number(SellValue) + Number(MarkupValue);
                finalValue = roundNumber(finalValue, 2);
                document.getElementById(spn).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + finalValue;
            }
        }
    }
    else {
        Obj.value = 0;
    }
    Obj.value = roundNumber(Obj.value, 2);
}
function ItemMarkupOnBlur(Markup, ID) {
    if (ID != "" && !isNaN(Markup)) {
        var spnSellInMark = "spnSellingPrice_" + ID + "";
        var mar = "txtMarkUp_" + ID + "";
        var spnSellExMark = "spnPriceExMarkup_" + ID + "";

        var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
        var SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
        SellInMarkValue = roundNumber(SellInMarkValue, 2);
        document.getElementById(spnSellInMark).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInMarkValue;
    }
}
/* The following function is not used because Sub Item Other Cost is changed */
//For SubItem of Other Costs
function SubItemOtherCostBlur(MarkupObj, Markup, Ids) {
    var TotalID = Ids.split(',');
    var EstOtherCostID = TotalID[0];
    var EstQtyID = TotalID[1];
    var QtyIDList = EstQtyID.split('±');
    for (var i = 0; i < QtyIDList.length - 1; i++) {
        if (QtyIDList[i] != "" && !isNaN(Markup) && Markup != '') {
            var spnSellInMark = "spnSellingPrice_" + EstOtherCostID + "_" + QtyIDList[i] + "";
            var mar = "txtMarkUp_" + EstOtherCostID + "";
            var spnSellExMark = "spnPriceExMarkup_" + EstOtherCostID + "_" + QtyIDList[i] + "";

            var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
            var SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
            SellInMarkValue = roundNumber(SellInMarkValue, 2);
            document.getElementById(spnSellInMark).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInMarkValue;
        }
        else {
            MarkupObj.value = "0";
        }
    }
}
//FOR INK MARKUP
function InkMarkupOnBlur(obj, Markup, List) {
    var List1 = List.split(',')
    var InkIDList = List1[0].split('±');
    var QtyIDList = List1[1].split('±');
    for (var i = 0; i < InkIDList.length; i++) {
        var InkID = InkIDList[i];
        for (var j = 0; j < QtyIDList.length; j++) {
            if (!isNaN(Markup) && Markup != '') {
                var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + InkID + "_" + QtyIDList[j] + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(/,/, '');
                var InkCostInMark = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
                InkCostInMark = roundNumber(InkCostInMark, 2);
                document.getElementById("spnSellingPrice_" + InkID + "_" + QtyIDList[j] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + InkCostInMark;
                document.getElementById("txtMarkUp_" + InkID + "").value = Markup;
                hdn_Markup.value = Markup;
            }
            else {
                obj.value = "0";
            }
        }

    }
}
//ONLY FOR MAIN WAREHOUSE ITEMs
function WarehouseMarkupOnBlur(obj, Markup, WareIDList) {
    var WareArr = WareIDList.split('±');
    for (var i = 0; i < WareArr.length; i++) {
        if (!isNaN(Markup) && Markup != '') {
            var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + WareArr[i] + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(/,/, '');
            var SellInMarkup = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
            SellInMarkup = roundNumber(SellInMarkup, 2);
            document.getElementById("spnSellingInMarkup_" + WareArr[i] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInMarkup;
            document.getElementById("txtMarkUp_" + WareArr[i] + "").value = Markup;
        }
        else {
            obj.value = "0";
        }
    }
}
function ItemOutworkMarkupOnBlur(Markup, Param) {
    var Arr1 = Param.split(',');
    var ID = Arr1[0];
    var MarkupType = Arr1[1];

    if (ID != "" && !isNaN(Markup)) {
        var spnSellInMark = "spnSellingPrice_" + ID + "";
        var mar = "txtMarkUp_" + ID + "";
        var spnSellExMark = "spnPriceExMarkup_" + ID + "";

        var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
        var SellInMarkValue = 0;
        if (MarkupType == "Percentage") {
            SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
        }
        else {
            SellInMarkValue = Number(SellExMarkupValue) + Number(Markup);
        }
        SellInMarkValue = roundNumber(SellInMarkValue, 2);
        document.getElementById(spnSellInMark).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInMarkValue;
    }
}
//FOR PRICE CATALOGUE   
function CatalogueMarkupOnBlur(txtobj, index) {
    var MarkupPercentage = txtobj.value;
    MarkupPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPercentage, 0, '', false, false, true); //roundNumber(Number(MarkupPercentage), 2)
    //alert("MarkupPercentage =" + MarkupPercentage);
    for (var i = 0; i < 4; i++) {
        var spnPriceId = "spnPriceExMarkup_" + i + "";
        var txtmarkupId = "txtMarkUp_" + i + "";
        var spnSellInMarkId = "spnSellingInMarkup_" + i + "";

        if (MarkupPercentage != "" && !isNaN(MarkupPercentage)) {
            if (document.getElementById(spnPriceId) != null) {
                document.getElementById(txtmarkupId).value = MarkupPercentage;
                var markup = MarkupPercentage;

                var price = document.getElementById(spnPriceId).innerHTML.replace(/,/, '');
                //alert("price =" + price);
                var MarkupValue = (price * markup) / 100;
                //var MarkupValue = (Number(price) * Number(markup)) ;
                //alert("MarkupValue =" + MarkupValue);
                var SellPrice = Number(MarkupValue) + Number(price);
                SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true); //roundNumber(SellPrice, 2);

                document.getElementById(spnSellInMarkId).innerHTML = SellPrice;
            }
        }
        else {
            txtobj.value = "0.00";
            return false;
        }
    }
}