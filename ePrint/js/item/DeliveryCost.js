


function OpenDeliveryCostPopUp(Type) {
    if (Type == 'DeliveryCost') {
        var papertype = "sheet";
        //papertype = "roll";
        //PopupCenter(strSitepath + "common/common_popup.aspx?type=DCselector&pg=estimate&item=paper&papertype=" + papertype + "", '1000', '500')
        var wnd = window.radopen(strSitepath + "common/common_popup.aspx?type=DCselector&pg=estimate&item=DeliveryCost&papertype=" + papertype + "");
        wnd.setSize(1275, 500);
        wnd.center();
        var x = wnd.getWindowBounds().x;
        var y = wnd.getWindowBounds().y;
        if (y < 0) {
            wnd.moveTo(x, 57);
        }
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

    return false;
}
function SendPaperIDandName(id, values, papertype, Formula, Papeweight) {
  
    cost.value = Papeweight;
    HdnFormula = Formula;

    //To get Paper Height and Width on PaperID //
    if (!isNaN(cost.value)) {
        cost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value), 0, '', false, false, false);
    }
    else {
        cost.value = "0.00";
    }

    var ddlprofitmarginvalue = Number(ddlprofitmargin.options[ddlprofitmargin.selectedIndex].text.split('%')[0]);

    txtproftimarge.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value) * Number(ddlprofitmarginvalue) / 100, 0, '', false, false, false);

    txtsubtotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value) + Number(txtproftimarge.value), 0, '', false, false, false);

    txtsellingprice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost.value) * ddlprofitmarginvalue) / 100 + Number(cost.value) + Number(lbltax.value), 0, '', false, false, false);

    gettaxvalue(Number(ddltax.options[ddltax.selectedIndex].value));

}
function moreQty(para1) {
    txtQuantity.focus()
    if (navigator.appName == "Microsoft Internet Explorer") {
        if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
            var ieversion = new Number(RegExp.$1)
            if (ieversion >= 6) {
                //document.getElementById("div_RunOnQty").className = "absolutepos";
                //document.getElementById("div_Addmore").className="absolutepos";
            }
            if (ieversion >= 7) {
                if (document.getElementById("div_RunOnQty") != null) {
                    document.getElementById("div_RunOnQty").className = "absolutepos7";
                }
                //document.getElementById("div_Addmore").className="absolutepos7";
            }
        }
    }
    else {
        if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
            var ffversion = new Number(RegExp.$1);

            if (ffversion == 3) {
                //document.getElementById("div_RunOnQty").className = "absolutepos1ff";
                //document.getElementById("div_Addmore").className="absolutepos1ff";
            }
            if (ffversion >= 3.5) {
                //document.getElementById("div_RunOnQty").className = "absolutepos1";
                //document.getElementById("div_Addmore").className="absolutepos1";
            }
        }
    }
    if (IsQtyDisabled == false) {
        if (para1 == "single") {
            document.getElementById(div_Qty2to4).style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            hid_QtyType.value = "S";

            document.getElementById("hrefQtyMore").style.display = "block";
            document.getElementById("hrefQtySingle").style.display = "none";
            document.getElementById("divcost").style.display = "none";
            document.getElementById("divprofitmargin").style.display = "none";
            document.getElementById("divsubtotal").style.display = "none";
            document.getElementById("divtax").style.display = "none";
            document.getElementById("divselling").style.display = "none";
        }
        else if (para1 == "more") {
            document.getElementById(div_Qty2to4).style.display = "block";
            if (navigator.appName == "Microsoft Internet Explorer") {
                document.getElementById("div_qty_3to4").className = "bglabelEmpty";
            }
            else {
                document.getElementById("div_qty_3to4").className = "bglabelEmpty1";
            }
            document.getElementById("div_Addmore").style.display = "block"

            hid_QtyType.value = "M";
            document.getElementById("hrefQtyMore").style.display = "none";
            document.getElementById("hrefQtySingle").style.display = "block";

            //document.getElementById("div_RunOnQty").style.display = "none";

            document.getElementById("divcost").style.display = "block";
            document.getElementById("divprofitmargin").style.display = "block";
            document.getElementById("divsubtotal").style.display = "block";
            document.getElementById("divtax").style.display = "block";
            document.getElementById("divselling").style.display = "block";

        }
        else if (para1 == "runonqty") {
            document.getElementById(div_Qty2to4).style.display = "none"
            document.getElementById("div_Addmore").style.display = "none";
        }
    }

}





function Get_Tax_Value(TaxID) {
    var Array_0 = hdntaxvalue.value.split('±');

    for (var i = 0; i < Array_0.length; i++) {
        if (Array_0[i] != '') {
            var Array_1 = Array_0[i].split('»');
            if (Array_1[0] == TaxID) {
                return Array_1[2];
            }
        }
    }
    return 0;
}



function gettaxvalue(taxID) {
    var tax = Get_Tax_Value(taxID);
    lbltax.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal.value) * Number(tax)) / 100, 0, '', false, false, false);

    var ddlprofitmarginvalue = Number(ddlprofitmargin.options[ddlprofitmargin.selectedIndex].text.split('%')[0]);


    txtsellingprice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost.value) * ddlprofitmarginvalue) / 100 + Number(cost.value) + Number(lbltax.value), 0, '', false, false, false);

}

var check = false;
function check_Validation() {
    check = true;
    document.getElementById("spn_txtItemTitle").style.display = "none";

    if (trim12(txtitemtitle.value) == "") {
        document.getElementById("spn_txtItemTitle").style.display = "block";
        check = false;
    }

    if (txtQuantity.value == '') {
        document.getElementById("spn_txtQuantity").style.display = "block";
        document.getElementById("spn_txtQuantity_number").style.display = "none";
        check = false;
    }

    if (txtQuantity.value == '0') {
        document.getElementById("spn_txtQuantity_number").style.display = "block";
        document.getElementById("spn_txtQuantity").style.display = "none";
        check = false;
    }

    if (cost.value == '') {
        document.getElementById("spn_itemcost").style.display = "block";
        check = false;
    }


    if (txtproftimarge.value == '') {
        document.getElementById("spn_profitmargin").style.display = "block";
        check = false;
    }


    if (txtsubtotal.value == '') {
        document.getElementById("spn_subtotal").style.display = "block";
        check = false;

    }


    if (lbltax.value == '') {
        document.getElementById("spn_tax").style.display = "block";
        check = false;

    }


    if (txtsellingprice.value == '') {
        document.getElementById("spn_sellingprice").style.display = "block";
        check = false;

    }

    if (txtitemtitle.value == '') {
        document.getElementById("spn_txtItemTitle").style.display = "block";
        check = false;

    }
    if (check) {
        return true;
    }
    else {
        return false;
    }

}


