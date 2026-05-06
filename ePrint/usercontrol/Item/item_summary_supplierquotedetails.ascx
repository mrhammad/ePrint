<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_supplierquotedetails.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_supplierquotedetails" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    .Header_Sup {
        background-color: #ccc;
        height: 26px;
        font-family: Verdana,Arial,Helvetica,sans-serif; /*font-size: 10px;*/
        font-weight: bold;
        color: #454545;
    }

    .Display_None {
        display: none;
    }

    .Display_Block {
        display: block;
    }

    .ShowHistory {
        background-image: url(../Images/navigate-down-icon24.png);
        background-repeat: no-repeat;
        height: 24px;
        width: 24px;
        cursor: pointer;
        display: block;
        border: 0px;
        background-color: transparent;
    }

    .HideHistory {
        background-image: url(../Images/navigate-up-icon24.png);
        background-repeat: no-repeat;
        height: 24px;
        width: 24px;
        cursor: pointer;
        display: block;
        border: 0px;
        background-color: transparent;
    }

    .AddmoreSup {
        background-image: url(../images/plus.gif);
        background-repeat: no-repeat;
        height: 15px;
        width: 15px;
        cursor: pointer;
        display: block;
        border: 0px;
        background-color: transparent;
    }

    .Header_new_style {
        width: 100%;
        border: 1px solid #aaaaaa;
        background: #cccccc url(../Images/QuoteTabBackGround.png) 50% 50% repeat-x;
        color: #222222;
        font-weight: bold;
        outline: 0;
        line-height: 1.3;
        text-decoration: none;
        font-size: 100%;
        border-radius: .5em;
        -webkit-border-radius: .5em; /*-moz-border-radius-bottomright: 4px;
        -webkit-border-bottom-right-radius: 4px;
        -khtml-border-bottom-right-radius: 4px;
        border-bottom-right-radius: 4px;
        -moz-border-radius-bottomleft: 4px;
        -webkit-border-bottom-left-radius: 4px;
        -khtml-border-bottom-left-radius: 4px;
        border-bottom-left-radius: 4px;
        -moz-border-radius-topright: 4px;
        -webkit-border-top-right-radius: 4px;
        -khtml-border-top-right-radius: 4px;
        border-top-right-radius: 4px;
        -moz-border-radius-topleft: 4px;
        -webkit-border-top-left-radius: 4px;
        -khtml-border-top-left-radius: 4px;
        border-top-left-radius: 4px;*/
    }

    .LeftCorner_rounded {
        -moz-border-radius-bottomleft: 4px;
        -webkit-border-bottom-left-radius: 4px;
        -khtml-border-bottom-left-radius: 4px;
        border-bottom-left-radius: 4px;
        -moz-border-radius-topleft: 4px;
        -webkit-border-top-left-radius: 4px;
        -khtml-border-top-left-radius: 4px;
        border-top-left-radius: 4px;
    }

    .RightCorner_rounded {
        -moz-border-radius-bottomright: 4px;
        -webkit-border-bottom-right-radius: 4px;
        -khtml-border-bottom-right-radius: 4px;
        border-bottom-right-radius: 4px;
        -moz-border-radius-topright: 4px;
        -webkit-border-top-right-radius: 4px;
        -khtml-border-top-right-radius: 4px;
        border-top-right-radius: 4px;
    }
</style>
<script type="text/javascript">
    var strSitepath = '<%=strSitepath %>';
    var Module = '<%=Module %>';
    var roundOff = '<%=roundoff %>';

    function Redirect_Q(id, ItemID) {
        if (Module.toLowerCase() == 'estimate') {
            window.location = strSitepath + "estimates/estimate_quotedetails_panel.aspx?estid=" + id + "&estitemID=" + ItemID + "&Module=" + Module + "";
        }
        else {
            window.location = strSitepath + "orders/order_quotedetails_panel.aspx?estid=" + id + "&ordid=" + id + "&estitemID=" + ItemID + "&Module=" + Module + "";
        }
    }
    function Redirect_Cancel(ItemID, id) {
        if (Module.toLowerCase() == 'estimate') {
            window.location = strSitepath + "estimates/estimate_summary_reeng.aspx?estid=" + id + "&estitemID=" + ItemID + "";
        }
        else {
            window.location = strSitepath + "orders/order_summary.aspx?estid=" + id + "&ordid=" + id + "&estitemID=" + ItemID + "";
        }
        document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_CancelBtn_" + ItemID).style.display = "none";
        document.getElementById("div_cancelprocess_" + ItemID).style.display = "block";
     }

    function RefreshButton() {
        $('#accordion2').append();
        $("#accordion2").trigger("create");
    }

    function Eprint_ReturnFinal_Formated_Amount1(Amount) {
        //var settingScale = '2';
        var settingScale = roundOff;
        return roundNumber_new(Amount, settingScale);
    }

    function todecimal_function1(txtobj) {

        var value = txtobj.value;
        if (!isNaN(txtobj.value) && Number(txtobj.value)) {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount1(txtobj.value);
        }
        else {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount1(0);
        }
    }

    function ddlMarkUpType(id, list, EID) {
        var e = document.getElementById(id);
        var MarkUpTypeValue = e.options[e.selectedIndex].value;

        var SupIDArray = list.split(',');

        for (var i = 0; i < SupIDArray.length; i++) {
            var SuppID = SupIDArray[i] + '_' + EID;
            var ddl1 = 'ddlMarkupType_' + SuppID + '_1';
            var ddl2 = 'ddlMarkupType_' + SuppID + '_2';
            var ddl3 = 'ddlMarkupType_' + SuppID + '_3';
            var ddl4 = 'ddlMarkupType_' + SuppID + '_4';
            if (MarkUpTypeValue == 'P') {
                document.getElementById(ddl1).selectedIndex = 0;
                Calculation(SuppID, '1', 'others');
                document.getElementById(ddl2).selectedIndex = 0;
                Calculation(SuppID, '2', 'others');
                document.getElementById(ddl3).selectedIndex = 0;
                Calculation(SuppID, '3', 'others');
                document.getElementById(ddl4).selectedIndex = 0;
                Calculation(SuppID, '4', 'others');
            }
            else if (MarkUpTypeValue == 'F') {
                document.getElementById(ddl1).selectedIndex = 1;
                Calculation(SuppID, '1', 'others');
                document.getElementById(ddl2).selectedIndex = 1;
                Calculation(SuppID, '2', 'others');
                document.getElementById(ddl3).selectedIndex = 1;
                Calculation(SuppID, '3', 'others');
                document.getElementById(ddl4).selectedIndex = 1;
                Calculation(SuppID, '4', 'others');
            }
        }
    }

    function ChkSelectSupplier(id, list, pos, SID, EID) {
     
        var chk = document.getElementById(id);
        var SupIDArray = list.split(',');
        if (chk.checked) {
            var qty = document.getElementById("txtQTY_" + SID + "_" + EID + '_' + pos).value;
            if (qty == '') {
                chk.checked = false;
                alert("This quantity cannot be selected");
            }
            else {
                for (var i = 0; i < SupIDArray.length; i++) {
                    var SuppID = SupIDArray[i];
                    var Chk1 = 'ChkSupplier_' + SuppID + "_" + EID + '_' + pos;
                    document.getElementById(Chk1).checked = false;
                }
                chk.checked = true;
            }
        }
    }

    function DelIncluded(id, SupID, pos) {
       
        var e = document.getElementById(id);
        var DelValue = e.options[e.selectedIndex].value;
        var txt = 'txtDelCost_' + SupID + '_' + pos;
        if (DelValue == 'yes') {
            document.getElementById(txt).disabled = true;
            document.getElementById(txt).value = '0.00';
        }
        else {
            document.getElementById(txt).disabled = false;
            document.getElementById(txt).focus();
        }
    }

    function total_Bind(list, id, ids) {
       
        var SupIDArray = list.split(',');
        for (var i = 0; i < SupIDArray.length; i++) {
            var SuppID = SupIDArray[i] + '_' + id;
            Calculation(SuppID, '1', 'others');
            Calculation(SuppID, '2', 'others');
            Calculation(SuppID, '3', 'others');
            Calculation(SuppID, '4', 'others');
        }
        highlighting(ids);
    }

    function highlighting(ids) {
        
        var EstIDArray = ids.split(',');
        for (var i = 0; i < EstIDArray.length; i++) {
            var id = EstIDArray[i];
            if (document.getElementById("SupplierCount_" + id) != null || document.getElementById("SupplierCount_" + id) != undefined) {
                var SupplierCount = document.getElementById("SupplierCount_" + id).value;

                //For Highlighting Lowest Cost and Earlier Date -START
                if (SupplierCount != '' && SupplierCount > 1) {
                    if (document.getElementById("QtySupID_" + id + "_1").value != '' || document.getElementById("DelDateSupID_" + id + "_1").value != '') {
                        var PriceID = document.getElementById("QtySupID_" + id + "_1").value;
                        var DelDateID = document.getElementById("DelDateSupID_" + id + "_1").value;

                        if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_1") != null || document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_1") != undefined) {
                            if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_1").value != "0.00") {
                                document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_1").style.background = "#DBDBDB";
                            }
                        }
                        if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_1") != null || document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_1") != undefined) {
                            if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_1").value != "") {
                                document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_1").style.background = "#DBDBDB";
                            }
                        }
                    }
                    if (document.getElementById("QtySupID_" + id + "_2").value != '' || document.getElementById("DelDateSupID_" + id + "_2").value != '') {
                        var PriceID = document.getElementById("QtySupID_" + id + "_2").value;
                        var DelDateID = document.getElementById("DelDateSupID_" + id + "_2").value;

                        if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_2") != null || document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_2") != undefined) {
                            if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_2").value != "0.00") {
                                document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_2").style.background = "#DBDBDB";
                            }
                        }
                        if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_2") != null || document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_2") != undefined) {
                            if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_2").value != "") {
                                document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_2").style.background = "#DBDBDB";
                            }
                        }
                    }
                    if (document.getElementById("QtySupID_" + id + "_3").value != '' || document.getElementById("DelDateSupID_" + id + "_3").value != '') {
                        var PriceID = document.getElementById("QtySupID_" + id + "_3").value;
                        var DelDateID = document.getElementById("DelDateSupID_" + id + "_3").value;

                        if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_3") != null || document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_3") != undefined) {
                            if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_3").value != "0.00") {
                                document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_3").style.background = "#DBDBDB";
                            }
                        }

                        if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_3") != null || document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_3") != undefined) {
                            if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_3").value != "") {
                                document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_3").style.background = "#DBDBDB";
                            }
                        }
                    }
                    if (document.getElementById("QtySupID_" + id + "_4").value != '' || document.getElementById("DelDateSupID_" + id + "_4").value != '') {
                        var PriceID = document.getElementById("QtySupID_" + id + "_4").value;
                        var DelDateID = document.getElementById("DelDateSupID_" + id + "_4").value;

                        if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_4") != null || document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_4") != undefined) {
                            if (document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_4").value != "0.00") {
                                document.getElementById("txtTotalPrice_" + PriceID + "_" + id + "_4").style.background = "#DBDBDB";
                            }
                        }

                        if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_4") != null || document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_4") != undefined) {
                            if (document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_4").value != "") {
                                document.getElementById("txtDelDate_" + DelDateID + "_" + id + "_4").style.background = "#DBDBDB";
                            }
                        }
                    }
                }
            }
            //For Highlighting Lowest Cost and Earlier Date - END

        }
    }

    function Calculation(SupID, pos, type) {
        debugger
        var txtQTYID = 'txtQTY_' + SupID + '_' + pos;
        var QTY = document.getElementById(txtQTYID).value;

        var DelCost; //Delivery Cost
        var txtPrice = 'txtPrice_' + SupID + '_' + pos;
        var Price; //Price of the Item
        if (document.getElementById(txtPrice).value == '') {
            Price = '0.00';
        }
        else {
            Price = document.getElementById(txtPrice).value;
        }
        var ddlid = 'ddlDel_' + SupID + '_' + pos;
        var e = document.getElementById(ddlid);
        var ddlValue = e.options[e.selectedIndex].value;

        if (ddlValue == 'yes') {
            DelCost = 0;
        }
        else {
            var txtDelCost = 'txtDelCost_' + SupID + '_' + pos;
            DelCost = document.getElementById(txtDelCost).value;
        }

        var ddlMarkupid = 'ddlMarkupType_' + SupID + '_' + pos;
        var ddlMarkup = document.getElementById(ddlMarkupid);
        var ddlMarkupValue = ddlMarkup.options[ddlMarkup.selectedIndex].value;

        var x = parseFloat(Price) + parseFloat(DelCost);
        var txtMarkupValueID = 'txtMarkupValue_' + SupID + '_' + pos;
        var txtTotalPriceID = 'txtTotalPrice_' + SupID + '_' + pos;
        var txtMarkupValue = document.getElementById(txtMarkupValueID).value;
        var txtTotalPrice = document.getElementById(txtTotalPriceID).value;
        //var x = parseFloat(txtTotalPrice);

        var total;

        if (ddlMarkupValue == 'P') {
            if (type == 'total') {
                if (x == '0') {
                    document.getElementById(txtMarkupValueID).value = '0.00';
                }
                else {
                    document.getElementById(txtMarkupValueID).value = parseFloat(((parseFloat(txtTotalPrice) - parseFloat(x)) * 100) / parseFloat(x)).toFixed(roundOff);
                }
            }
            else {
                if (QTY == '' || Price == '0.00') {
                    total = 0;
                }
                else {
                    if (txtMarkupValue == '') {
                        txtMarkupValue = '0.00';
                    }
                    total = parseFloat(x) + ((parseFloat(x) * parseFloat(txtMarkupValue)) / 100);
                }
                document.getElementById(txtTotalPriceID).value = parseFloat(total).toFixed(roundOff);
            }
        }
        else if (ddlMarkupValue == 'F') {
            if (type == 'total') {
                document.getElementById(txtMarkupValueID).value = parseFloat(parseFloat(txtTotalPrice) - parseFloat(x)).toFixed(roundOff);
            }
            else {
                if (QTY == '' || Price == '0.00') {
                    total = 0;
                }
                else {
                    if (txtMarkupValue == '') {
                        txtMarkupValue = '0.00';
                    }
                    total = parseFloat(x) + parseFloat(txtMarkupValue);
                }
                document.getElementById(txtTotalPriceID).value = parseFloat(total).toFixed(roundOff);
            }
        }
    }



    function Save_QuoteDetails(id, list, btnType) {
        
        var hdn_btnProcess = document.getElementById('ctl00_ContentPlaceHolder1_ucQuotedetails_hdn_btnProcess');
        document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave").value = '';
        document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave_Est").value = '';
        var SupIDArray = list.split(',');
        var ColumnDetails = "∑";
        var isChkBX_Checked = "no";

        for (var k = 0; k < SupIDArray.length; k++) {
            var Suplr_BxID = SupIDArray[k] + '_' + id;
            var chk_Bx;
            for (var l = 1; l < 5; l++) {
                chk_Bx = document.getElementById("ChkSupplier_" + Suplr_BxID + "_" + l);
                if (chk_Bx.checked == true) {
                    isChkBX_Checked = "yes";
                }
            }
        }

        //Checking for At least One CheckBox check
        if (isChkBX_Checked == "yes") {
           
            if (btnType == "btnSaveNAccept") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_btnSaveNAccept_" + id).style.display = "none";
                document.getElementById("div_saveprocess_" + id).style.display = "block";
                hdn_btnProcess.value = 'saveandclose';
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_btnSaveAndStay_" + id).style.display = "none";
                document.getElementById("div_saveAndStay_" + id).style.display = "block";
                hdn_btnProcess.value = 'saveandstay';
            }

            for (var i = 0; i < SupIDArray.length; i++) {
                var SuplrID = SupIDArray[i];
                var isChecked = "no";
                var chk;

                ColumnDetails = ColumnDetails + id + ";";
                ColumnDetails = ColumnDetails + SuplrID + ";";

                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_1");
                var ddlValue = e.options[e.selectedIndex].value;

                ColumnDetails = ColumnDetails + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails = ColumnDetails + ddlValue + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_1").value + ";";

                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_2");
                var ddlValue = e.options[e.selectedIndex].value;

                ColumnDetails = ColumnDetails + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails = ColumnDetails + ddlValue + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_2").value + ";";

                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_3");
                var ddlValue = e.options[e.selectedIndex].value;

                ColumnDetails = ColumnDetails + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails = ColumnDetails + ddlValue + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_3").value + ";";

                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_4");
                var ddlValue = e.options[e.selectedIndex].value;

                ColumnDetails = ColumnDetails + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails = ColumnDetails + ddlValue + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_4").value + ";";

                var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_1");
                var ddlMarkup = d.options[d.selectedIndex].value;

                ColumnDetails = ColumnDetails + ddlMarkup + ";";
                ColumnDetails = ColumnDetails + document.getElementById("txtComment_" + SuplrID + "_" + id).value + ";";
                ColumnDetails = ColumnDetails + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";∑";
                //}
            }

            document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave").value = ColumnDetails;
            document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnEstimateitemID").value = id;

            var ColumnDetails_Est = "»";
            for (var i = 0; i < SupIDArray.length; i++) {
                var SuplrID = SupIDArray[i];
                var isChecked = "no";
                var chk;

                if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_1").value != "") {

                    chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_1");
                    //if (chk.checked == true) {
                    var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_1");
                    var ddlValue = e.options[e.selectedIndex].value;
                    var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_1");
                    var ddlMarkup = d.options[d.selectedIndex].value;

                    ColumnDetails_Est = ColumnDetails_Est + id + ";";
                    ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";


                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_1").value + ";";


                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_1").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_1").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_1").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + '1;';
                    ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_1").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_1").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                    if (chk.checked == true) {
                        ColumnDetails_Est = ColumnDetails_Est + "1;";
                    }
                    else {
                        ColumnDetails_Est = ColumnDetails_Est + "0;";
                    }
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";

                }


                if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_2").value != "") {


                    chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_2" + "");
                    //if (chk.checked == true) {
                    var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_2");
                    var ddlValue = e.options[e.selectedIndex].value;
                    var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_2");
                    var ddlMarkup = d.options[d.selectedIndex].value;

                    ColumnDetails_Est = ColumnDetails_Est + id + ";";
                    ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_2").value + ";";


                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_2").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_2").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_2").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + '2;';
                    ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_2").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_2").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                    if (chk.checked == true) {
                        ColumnDetails_Est = ColumnDetails_Est + "1;";
                    }
                    else {
                        ColumnDetails_Est = ColumnDetails_Est + "0;";
                    }
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";

                }


                if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_3").value != "") {


                    chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_3" + "");

                    var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_3");
                    var ddlValue = e.options[e.selectedIndex].value;
                    var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_3");
                    var ddlMarkup = d.options[d.selectedIndex].value;

                    ColumnDetails_Est = ColumnDetails_Est + id + ";";
                    ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_3").value + ";";


                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_3").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_3").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_3").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + '3;';
                    ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_3").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_3").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                    if (chk.checked == true) {
                        ColumnDetails_Est = ColumnDetails_Est + "1;";
                    }
                    else {
                        ColumnDetails_Est = ColumnDetails_Est + "0;";
                    }
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";

                }


                if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_4").value != "") {


                    chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_4" + "");

                    var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_4");
                    var ddlValue = e.options[e.selectedIndex].value;
                    var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_4");
                    var ddlMarkup = d.options[d.selectedIndex].value;

                    ColumnDetails_Est = ColumnDetails_Est + id + ";";
                    ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_4").value + ";";


                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_4").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_4").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_4").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + '4;';
                    ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_4").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_4").value + ";";
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                    if (chk.checked == true) {
                        ColumnDetails_Est = ColumnDetails_Est + "1;";
                    }
                    else {
                        ColumnDetails_Est = ColumnDetails_Est + "0;";
                    }
                    ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";

                }
            }
            document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave_Est").value = ColumnDetails_Est;
        }
        else {
            alert("Please check at least one supplier");
            return false;
        }
    }


    function Save_EstDetails(id, list) {
        
        document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave_EstOnly").value = '';
        var SupIDArray = list.split(',');
        var ColumnDetails_Est = "»";

        for (var i = 0; i < SupIDArray.length; i++) {
            var SuplrID = SupIDArray[i];
            var isChecked = "no";
            var chk;

            if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_1").value != "") {

                chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_1");
                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_1");
                var ddlValue = e.options[e.selectedIndex].value;
                var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_1");
                var ddlMarkup = d.options[d.selectedIndex].value;

                ColumnDetails_Est = ColumnDetails_Est + id + ";";
                ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_1").value + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + '1;';
                ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_1").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                if (chk.checked == true) {
                    ColumnDetails_Est = ColumnDetails_Est + "1;";
                }
                else {
                    ColumnDetails_Est = ColumnDetails_Est + "0;";
                }
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";
            }

            if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_2").value != "") {

                chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_2" + "");
                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_2");
                var ddlValue = e.options[e.selectedIndex].value;
                var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_2");
                var ddlMarkup = d.options[d.selectedIndex].value;

                ColumnDetails_Est = ColumnDetails_Est + id + ";";
                ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_2").value + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + '2;';
                ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_2").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                if (chk.checked == true) {
                    ColumnDetails_Est = ColumnDetails_Est + "1;";
                }
                else {
                    ColumnDetails_Est = ColumnDetails_Est + "0;";
                }
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";
            }


            if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_3").value != "") {

                chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_3" + "");
                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_3");
                var ddlValue = e.options[e.selectedIndex].value;
                var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_3");
                var ddlMarkup = d.options[d.selectedIndex].value;

                ColumnDetails_Est = ColumnDetails_Est + id + ";";
                ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_3").value + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + '3;';
                ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_3").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                if (chk.checked == true) {
                    ColumnDetails_Est = ColumnDetails_Est + "1;";
                }
                else {
                    ColumnDetails_Est = ColumnDetails_Est + "0;";
                }
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";
            }


            if (document.getElementById("txtQTY_" + SuplrID + "_" + id + "_4").value != "") {

                chk = document.getElementById("ChkSupplier_" + SuplrID + "_" + id + "_4" + "");
                var e = document.getElementById("ddlDel_" + SuplrID + "_" + id + "_4");
                var ddlValue = e.options[e.selectedIndex].value;
                var d = document.getElementById("ddlMarkupType_" + SuplrID + "_" + id + "_4");
                var ddlMarkup = d.options[d.selectedIndex].value;

                ColumnDetails_Est = ColumnDetails_Est + id + ";";
                ColumnDetails_Est = ColumnDetails_Est + SuplrID + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtQTY_" + SuplrID + "_" + id + "_4").value + ";";

                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtPrice_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelDate_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + ddlValue + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtDelCost_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + '4;';
                ColumnDetails_Est = ColumnDetails_Est + ddlMarkup + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtMarkupValue_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtTotalPrice_" + SuplrID + "_" + id + "_4").value + ";";
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("txtSupplierNum_" + SuplrID + "_" + id).value + ";";
                if (chk.checked == true) {
                    ColumnDetails_Est = ColumnDetails_Est + "1;";
                }
                else {
                    ColumnDetails_Est = ColumnDetails_Est + "0;";
                }
                ColumnDetails_Est = ColumnDetails_Est + document.getElementById("lblKeyCode_" + SuplrID + "_" + id).value + ";»";
            }
        }
        document.getElementById("ctl00_ContentPlaceHolder1_ucQuotedetails_hdnQuoteSave_EstOnly").value = ColumnDetails_Est;
    }


    function IntergerValidation(evt) {
      
        var charCode = (evt.which) ? evt.which : window.event.keyCode;

        if (charCode <= 13) {
            return true;
        }
        else {
            var keyChar = String.fromCharCode(charCode);
            //var re = /[a-zA-Z0-9@#$%&*!~^_()?,.{}<>]/
            var re = /[0-9]/
            return re.test(keyChar);
        }
    }

    function HistoryDetails_Show(supid, id) {
        var tableid = "#history_" + supid + "_" + id;
        $(tableid).slideToggle("slow");
        document.getElementById("lblShow_" + supid + "_" + id).style.display = "none";
        document.getElementById("lblHide_" + supid + "_" + id).style.display = "block";
    }

    function HistoryDetails_Hide(supid, id) {
        var tableid = "#history_" + supid + "_" + id;
        $(tableid).slideToggle("slow");
        document.getElementById("lblShow_" + supid + "_" + id).style.display = "block";
        document.getElementById("lblHide_" + supid + "_" + id).style.display = "none";
    }

</script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>

<asp:UpdateProgress ID="upProgress" runat="server">
    <ProgressTemplate>
        <div id="divBackGround1">
            <div id="divLoading" class="divLoading">
                <div class="Graphic">
                    <div class="divLoadingPadding">
                        <img src="<%=strImagepath %>loading_new.gif" border="0" />
                    </div>
                    <div class="clearboth">
                    </div>
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<div style="width: 100%;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:PlaceHolder ID="plhQuoteDetails" runat="server"></asp:PlaceHolder>
            <asp:HiddenField ID="hdnQuoteSave" runat="server" />
            <asp:HiddenField ID="hdnEstimateitemID" runat="server" />
            <asp:HiddenField ID="hdnQuoteSave_Est" runat="server" />
            <asp:HiddenField ID="hdnQuoteSave_EstOnly" runat="server" />
            <asp:HiddenField ID="hdnSupplierAddMore" runat="server" />
            <asp:HiddenField ID="hdnSupplierAddMore_EstID" runat="server" />
            <asp:HiddenField ID="hdn_btnProcess" runat="server" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
