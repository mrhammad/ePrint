var AllowtoSaveZerostock = false;
//var AllowtoSaveZerostock = true;

function AddCategory(type) {
    if (type == "add") {
        setLoadingPositionOfDivMove(div_Obj);
        document.getElementById("div_PriceCata_Category_add_item").style.display = "block";
        txtPriceCatalogueCategoryName.focus();
    }
    else if (type == "edit") {
    }
    else {
        document.getElementById("div_PriceCata_Category_add_item").style.display = "none";
    }
}

function CategoryVaidate() {
    if (CheckStringMandatory(txtPriceCatalogueCategoryName.value, 'spn_txtPriceCatalogueCategoryName')) {
        return false;
    }
    else {
        return true;
    }
}

function CreateHeader() {
    debugger;
    var Matrixtext = document.getElementById("ctl00_ContentPlaceHolder1_hdn_Matrixtypetext").value;
    if (ddlMatrixType.value == "pricebands") {
        document.getElementById("spn_help_pricebands").innerHTML = Matrixtext;
    }
    else {
        document.getElementById("spn_help_pricebands").innerHTML = Matrixtext;
    }

    var wtunit = document.getElementById("ctl00_ContentPlaceHolder1_hidweightunit");   // by rakshith
    var uniData = "";
    uniData += "<div nowarp='nowrap' style='width:100%;border:solid 0px red;' align='center'>";

    uniData += "<table style='width:100%;background-color: #DDDDDD;color:#000000;table-layout: fixed' cellpadding='0px' cellspacing='0px' border='0px' >";
    uniData += "<tr height='25px'>";
    if (ddlMatrixType.value == "simplematrix" || ddlMatrixType.value == "pricebands") {
        if (ddlMatrixType.value == "simplematrix") {
            uniData += "<td style='width: 5%;' align='center' id='td_eStoreHideChk'>";
        }
        else {
            uniData += "<td style='width: 6%;' align='center' id='td_eStoreHideChk'>";
        }
        uniData += "<span id='spn_eStoreHideChk' >" + eStoreHide + "</span>";
        uniData += "</td>";
    }
    uniData += "<td style='width: 0px;' align='right' id='td_frmqty'>";
    uniData += "<span id='spn_Qtyfrm' >" + Qty_Display + "</span>";
    uniData += "</td>";
    uniData += "<td style='width: 0px;padding-left: 1%' align='center' id='spn_Qty_td'>";
    uniData += "<span id='spn_Qty' >" + Qty_Display + "</span>";
    uniData += "</td>";
    uniData += "<td style='width: 7%;' align='right' id='td_toqty'>";
    uniData += "<span id='div_td_toqty'></span>";
    uniData += "</td>";

    uniData += "<td style='width: 10%;' align='right' id='spn_cost_td'>";
    uniData += "<span id='spn_cost'>" + Cost_For1 + " (" + GetCurrencyinRequiredFormate("", true) + ")</span>";
    uniData += "</td>";

    uniData += "<td style='width: 10%;' align='right' ' id='spn_Markup_td'>";
    uniData += Markup_display + "     (%)";
    uniData += "</td>";


    uniData += "<td style='width: 13%;' align='right' id='spn_header_sellingprice_td'>";
    uniData += "<span id='spn_header_sellingprice'>" + sell_Price_For1 + " (" + GetCurrencyinRequiredFormate("", true) + ")</span>";
    uniData += "</td>";

    //added by rakshith
    uniData += "<td style='width:10%;' align='right' id='spn_weight_td' >";
    uniData += "<span id='spn_weight'  >Weight (" + wtunit.value + ")</span>";
    uniData += "</td>"
    //---------


    uniData += "<td id='spn_width_td' runat='server' style='width:10%;' align='right'>";
    uniData += "<span id='spn_width'  >Width (" + Measurementvalue2 + ")</span>";
    uniData += "</td>"

    uniData += "<td id='spn_height_td' runat='server' style='width:10%;' align='right'>";
    uniData += "<span id='spn_height' >Height (" + Measurementvalue2 + ")</span>";
    uniData += "</td>"

    uniData += "<td  id='spn_length_td' runat='server' style='width:10%;' align='right'>";
    uniData += "<span id='spn_length' >Length (" + PaperMeasure + ")</span>";
    uniData += "</td>"


    uniData += "<td style='width:7%; ' align='center' id='spn_Action_Display_td' >";
    uniData += Action_Display;
    uniData += "</td>";



    uniData += "</tr>";
    uniData += "</table>";
    uniData += "</div>";

    return uniData;
}

function CreateTable() {
    var uniData = "";
    uniData += CreateHeader();
    uniData += "<div style='clear:both'></div>";

    var TempData = '';
    if ("<%=action %>" != "edit") {
        for (var i = 0; i < 10; i++) {
            var txtValue = '';
            var spnValue = '';

            if (i == 1) {
                txtValue = Number(i * 2) * 50;
                spnValue = 51;
            }
            else if (i != 0) {
                txtValue = Number(i * 2) * 50;
                spnValue = Number(txtValue - 100) + 1;
            }
            else {
                spnValue = 1;
                txtValue = 50;
            }
            var clsName = "";
            if (i != 0) {
                if (i % 2 == 0) {
                    clsName = "";
                }
                else {
                    clsName = "#EFEFEF";

                }
            }
            var daa = ''
            TempData = CreateRow(i, clsName, spnValue, txtValue, daa, "");

            if (i == 0) {
                var row_1 = document.createElement("tr");
                var cell_1 = document.createElement("td");
                cell_1.id = "td_header";
                cell_1.innerHTML = uniData;
                row_1.appendChild(cell_1);

                var row_2 = document.createElement("tr");
                var cell_2 = document.createElement("td");

                cell_2.id = "td_" + i + "";
                cell_2.innerHTML = TempData;
                row_2.appendChild(cell_2);

                document.getElementById("PriceTable").appendChild(row_1);
                document.getElementById("PriceTable").appendChild(row_2);
            }
            else {
                var row = document.createElement("tr");
                var cell = document.createElement("td");

                cell.id = "td_" + i + "";
                cell.innerHTML = TempData;
                row.appendChild(cell);
                document.getElementById("PriceTable").appendChild(row);
            }
            lastRow = i;
            if (i < 150) {
                document.getElementById("href_add_more").style.display = "block";
            }
            else {
                document.getElementById("href_add_more").style.display = "none";
            }
        }
    }
    else {
        //FROM DB On EDIT CASE
    }
}

function CreateRow(i, clsName, spnValue, txtValue, uniData, MatrixType) {

    var dis_able = "";
    var isMatrixCalculation = document.getElementById("ctl00_ContentPlaceHolder1_hdn_isMatrixCalculation").value;
    

    if (i % 2 == 0) {
        clsName = "";
    }
    else {
        clsName = "#EFEFEF";
    }


    var IsDisplay = '';
    var IsWidth1 = '';
    var IsWidth2 = '';
    var ChangeDivWidth = '50%';
    var height = "";
    var height1 = "";
    var tdwidth = '';
    var imgwidth = '';
    var QTYWidth = '';
    var chkHideWidth = '';
    var chkHideDisplay = '';

    if (MatrixType == "simplematrix") {
        IsDisplay = 'display:none;';
        ChangeDivWidth = '80%';
        height1 = "10%";
        height = "13%";
        IsWidth1 = 'width:10%;';
        tdwidth = '10%';
        imgwidth = '5%';
        QTYWidth = '0px';
        chkHideDisplay = 'display:block;';
        chkHideWidth = 'width:5%;';
    }

    if (MatrixType == "signagematrix") {
        IsWidth1 = 'width:0%;';
        IsWidth2 = 'display:none;';
        height = "20%";
        height1 = "22%";
        tdwidth = '15%';
        imgwidth = '10%';
        QTYWidth = '7%';
        chkHideDisplay = 'display:none;';
        chkHideWidth = 'width:0%;';
    }
    if (MatrixType == "pricebands") {
        height1 = "10%";
        height = "13%";
        IsWidth1 = 'width:10%;';
        tdwidth = '10%';
        imgwidth = '5%';
        QTYWidth = '7%';
        chkHideDisplay = 'display:block;';
        chkHideWidth = 'width:5%;';
    }


    uniData = "<div id='div_row_" + i + "' style='background-color:" + clsName + ";height:25px;vertical-align:middle;' >";

    uniData += "<div class='only5px' style='width: 100%;'>";
    uniData += "<table style='width:100%; table-layout: fixed' cellpadding='0px' cellspacing='0px' border='0px' >";
    uniData += "<tr>";

    uniData += "<td style='width:" + chkHideWidth + "' align= 'center' id='td_HideOnEStore_" + i + "'>"
        + "<input type='checkbox' class='chkHideOnEStore' style='" + chkHideDisplay + "' id='chkHideOnEStore_" + i + "' />"
        + "</td>";

    uniData += "<td style='width:" + QTYWidth + "' align='right' id='td_txtfrmqty_" + i + "'>";
    uniData += "<div nowrap=nowarp>";
    uniData += "<input type='text' id='txtQty_from_" + i + "' style='width:50px;text-align:right;" + IsDisplay + "' maxlength=20 type='text'  value='" + parseFloat(spnValue).toFixed(2) + "'  class='textboxnew'>";
    uniData += "</div></td>";
    uniData += "<td style='width: " + QTYWidth + ";' align='center' id='td_txtcenterqty_" + i + "'>";
    uniData += "<div>";
    uniData += "<span id='spn_qty_sep_" + i + "' style='" + IsDisplay + "'>-</span>";
    uniData += "</div></td>";
    uniData += "<td style='width: 7%;' align='right' id='td_txttoqty'>";
    uniData += "<div id='div_txtQty_" + i + "' >";
    uniData += "<input id='txtQty_" + i + "'   style='width:80px;text-align:right;'  maxlength=20 type='text' value='" + parseFloat(txtValue).toFixed(2) + "'  class='textboxnew' />";
    uniData += "</div>";
    uniData += "</td>";

    uniData += "<td style='width:" + tdwidth + ";border:0px solid red;' align='right' id='txtCost_td" + i + "'>";
    if (isMatrixCalculation.toLowerCase() == "true") {
        uniData += "<input id='txtCost_" + i + "' type='text' onblur=calculateNewMarkup(this," + i + ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "'/>";
    } else {
        uniData += "<input id='txtCost_" + i + "' type='text' onblur=CalculateSellPrice(this," + i + ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "'/>";
    }
    //uniData += "<input id='txtCost_" + i + "' type='text' onblur=CalculateSellPrice(this," + i + ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "'/>";
    uniData += "</td>";
    uniData += "<td style='width: " + tdwidth + ";' align='right' id='txtMarkup_td" + i + "'>";

    var AssignOnBlur = "";
    if (i == 0) {
        AssignOnBlur = "onblur=CalculateSellPrice(this," + i + ",'markup');SetMarkupToAll(this,'" + i + "');";
    }
    else {
        AssignOnBlur = "onblur=CalculateSellPrice(this," + i + ",'markup');";
    }

    if (isMatrixCalculation.toLowerCase() == "true") {
        uniData += "<input id='txtMarkup_" + i + "' type='text' disabled maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
    } else {
        uniData += "<input id='txtMarkup_" + i + "' type='text' " + AssignOnBlur + "  maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
    }

    uniData += "</td>";
    uniData += "<td style='width: " + height + ";' align='right' id='txtSellingPrice_td" + i + "'>";
    uniData += "<input id='txtSellingPrice_" + i + "' onblur=Calculate_Markup(this," + i + "); type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
    uniData += "</td>";


    //added by rakshith
    uniData += "<td style='width:" + tdwidth + ";border:0px solid red;' align='right' id='txtWeight_td" + i + "' >";
    uniData += "<div>";
    uniData += "<input id='txtWeight_" + i + "' maxlength='20' onblur='Weighttodecimal(this," + i + ");' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "'/>";
    uniData += "</div>";
    uniData += " </td>";
    //------------


    uniData += "<td   id='txtWidth_td" + i + "' runat='server' style='border:0px solid red;" + IsWidth1 + "' align='right' >";
    uniData += "<div  >";
    uniData += "<input id='txtWidth_" + i + "' maxlength='20' onblur='Weighttodecimal(this," + i + ");' style='width:80px;text-align:right;" + IsWidth2 + "' class='textboxnew' value='" + DecimalValue + "'/>";
    uniData += "</div>";
    uniData += " </td>";


    uniData += "<td id='txtHeight_td" + i + "' runat='server' style='border:0px solid red;" + IsWidth1 + "' align='right' >";
    uniData += "<div>";
    uniData += "<input id='txtHeight_" + i + "' maxlength='20' onblur='Weighttodecimal(this," + i + ");' style='width:80px;text-align:right;" + IsWidth2 + "' class='textboxnew' value='" + DecimalValue + "'/>";
    uniData += "</div>";
    uniData += " </td>";

    uniData += "<td  id='txtLength_td" + i + "' runat='server' style='border:0px solid red;" + IsWidth1 + "' align='right' >";
    uniData += "<div>";
    uniData += "<input id='txtLength_" + i + "' maxlength='20' onblur='Weighttodecimal(this," + i + ");' style='width:80px;text-align:right; " + IsWidth2 + "' class='textboxnew' value='" + DecimalValue + "'/>";
    uniData += "</div>";
    uniData += " </td>";

    uniData += "<td style='width:7%;' id='tdactn" + i + "' >";
    uniData += "<div align='center'>";
    uniData += "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(" + i + "); />";
    uniData += "</div>";
    //uniData += "<a href='#addmore' onclick='Remove_Row(" + i + ")' >Remove</a>";
    uniData += "</td>";

    uniData += "</tr>";
    uniData += "</table>";

    uniData += "</div>";
    uniData += "</div>";

    return uniData;
}

function ToInteger(obj, val) {
    if (val.substring(val.length - 1, val.length) == ".") {
        obj.value = val.toString().replace('.', '');
    }
    else {
        obj.value = val;
    }
}

function Take_Data_DB() {

    var arr = hid_data.value.split('µ');
    for (var j = 0; j < arr.length; j++) {
        //if (arr[j] != '') {
        if (j == 0) {
            var row_1 = document.createElement("tr");
            var cell_1 = document.createElement("td");
            cell_1.id = "td_header";
            cell_1.innerHTML = CreateHeader();
            row_1.appendChild(cell_1);
            document.getElementById("PriceTable").appendChild(row_1);
        }
        var row = document.createElement("tr");
        var cell = document.createElement("td");

        cell.id = "td_" + j + "";
        cell.innerHTML = arr[j];
        row.appendChild(cell);
        document.getElementById("PriceTable").appendChild(row);
        //}
    }
    TotalRow = hid_Rows_On_Edit.value;

    if (ddlMatrixType.value == "pricebands") {


        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurrencyinRequiredFormate("", true) + ")";

        document.getElementById("spn_header_sellingprice").innerHTML = sell_Price_For1 + " (" + GetCurrencyinRequiredFormate("", true) + ")";
    }




    else if (ddlMatrixType.value == "simplematrix") {
        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurrencyinRequiredFormate("", true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_Display + " (" + GetCurrencyinRequiredFormate("", true) + ")";
    }
    MatrixTypeChange(ddlMatrixType.value);

}

function Remove_Row(index) {
    var NoOfRows = 0;
    for (var i = 0; i < TotalRow; i++) {
        if (document.getElementById("div_row_" + i + "") != null) {
            NoOfRows++;
        }
    }

    if (NoOfRows < 2) {
        alert('Price Matrix should have at least one row !');
        return false;
    }
    NoOfRows = NoOfRows - 1;
    if (NoOfRows < 150) {
        document.getElementById("href_add_more").style.display = "block";
    }
    else {
        document.getElementById("href_add_more").style.display = "none";
    }
    var obj = document.getElementById("PriceTable");

    var Child_Obj = document.getElementById("td_" + index + "");
    Child_Obj.innerHTML = "";
    //obj.removeChild(Child_Obj);
}

function Click_Add_More() {
   
    var Data = '';
    Data = CreateRow(TotalRow, "", "0", "0", Data, ddlMatrixType.value);
    var row = document.createElement("tr");
    var cell = document.createElement("td");
    cell.id = "td_" + TotalRow + "";
    cell.innerHTML = Data;
    row.appendChild(cell);
    document.getElementById("PriceTable").appendChild(row);

    //document.getElementById("div_Main").innerHTML = document.getElementById("div_Main").innerHTML + Data;

    var prevtxt;
    var Newtxt = document.getElementById("txtQty_" + TotalRow);;

    for (var i = 0; i < TotalRow; i++) {
        var CheckTxt = document.getElementById("txtQty_" + i);
        if (typeof CheckTxt != 'undefined' && CheckTxt != undefined && CheckTxt != null) {
            prevtxt = document.getElementById("txtQty_" + i);
        }
    }

    TotalRow++;
    var CheckMax = 0;
    for (var i = 0; i < TotalRow; i++) {
        if (document.getElementById("div_row_" + i + "") != null) {
            CheckMax++;
        }
    }
    if (CheckMax < Max) {
        document.getElementById("href_add_more").style.display = "block";
    }
    else {
        document.getElementById("href_add_more").style.display = "none";
    }

    if (typeof prevtxt != "undefined" || prevtxt != null)
        prevtxt.focus();
    if (typeof Newtxt != "undefined" || Newtxt != null)
        Newtxt.focus();
    MatrixTypeChange(ddlMatrixType.value);
}
//=======================   This will creates the Price Matrix   =============================
if (queryString == "add") {
    CreateTable();
}

function Weighttodecimal(obj, index) {

    if (!isNaN(obj.value)) {
        obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 3, '', false, false, false);
    }
    else {
        obj.value = "0.00";
    }
}

function CalculateSellPrice(obj, index, type) {
    debugger;
    if (type == 'cost') {
        var txtMarkup = document.getElementById("txtMarkup_" + index + "");
        var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");

        if (!isNaN(obj.value)) {
            if (!isNaN(txtMarkup.value)) {
                var MarkupValue = (txtMarkup.value * obj.value) / 100;
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(obj.value), 6, '', false, false, false);
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 6, '', false, false, false);

                
                obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);

            }
        }
        else {
            obj.value = "0.00";
            txtSellingPrice.value = "0.00";
        }
    }
    else {
        var txtCost = document.getElementById("txtCost_" + index + "");
        var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");
        if (!isNaN(obj.value)) {
            if (!isNaN(txtCost.value)) {
                var MarkupValue = (obj.value * txtCost.value) / 100;
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 6, '', false, false, false);
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 6, '', false, false, false);
                obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);

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

var Max = 150;
var CheckAnyBug = false;
function QuantityCheck(val, index) {
   
    var queryString = '<%=Request.Params["action"] %>';
    if (queryString == "edit") {
        var p = Number(index) + 1;
        for (var i = 0; i < index; i++) {
            if (document.getElementById("txtQty_" + i + "") != null) {
                var preValue = document.getElementById("txtQty_" + i + "").value;
            }
        }
    }
    else {
        if (!isNaN(val) && val != '') {
            var p = Number(index) + 1;
            for (var i = 0; i < index; i++) {
                if (document.getElementById("div_row_" + i + "") != null) {
                    var preValue = document.getElementById("txtQty_" + i + "").value;
                }
            }
            for (var i = p; i < TotalRow; i++) {
                try {
                    if (document.getElementById("txtQty_" + i + "") != null) {

                        for (var k = 1; k <= i; k++) {

                            var Pre_index = Number(i) - k;
                            var PreChk = document.getElementById("txtQty_" + Pre_index + "");

                            if (typeof PreChk != 'undefined' && PreChk != undefined && PreChk != null) {
                                var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                if (txt_SoldinPack.value != 0) {
                                    txt_Previous_value = parseFloat((Number(txt_Previous_value) + Number(txt_SoldinPack.value))).toFixed(2);
                                }
                                else {
                                    txt_Previous_value = parseFloat(Number(txt_Previous_value) + 100).toFixed(2);;
                                }
                                document.getElementById("txtQty_" + i + "").value = txt_Previous_value;

                                if (txt_SoldinPack.value == 0) {
                                    var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                    txt_Previous_value = Number(txt_Previous_value) + 100;
                                    document.getElementById("txtQty_from_" + i + "").value = parseFloat(Number(txt_Previous_value) - 100 + 1).toFixed(2);
                                }
                                else {
                                    var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                    //txt_Previous_value = Number(txt_Previous_value) + 100;
                                    document.getElementById("txtQty_from_" + i + "").value = parseFloat(Number(txt_Previous_value) + 1).toFixed(2);;
                                }
                                break;
                            }
                        }
                    }
                }
                catch (err) { }
            }
        }
        else {
            document.getElementById("txtQty_" + index + "").value = "0";
        }
    }
}

function Check_Qty_From(index, val) {
    
    if (!isNaN(val) && val != 0) {
        for (var i = 0; i < index; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                var preValue = document.getElementById("txtQty_from_" + i + "").value;
                if (Number(val) < Number(preValue)) {
                    alert('Please re-check the Quantity');
                    var OldNum = Number(Number(index) - Number(1));
                    if (document.getElementById("txtQty_" + OldNum + "") != null) {
                        var BelowValue = document.getElementById("txtQty_" + OldNum + "").value;
                      
                        document.getElementById("txtQty_from_" + index + "").value = Number(Number(BelowValue) + Number(1));
                    }
                    return false;
                }
            }
        }
    }
    else {
        document.getElementById("txtQty_from_" + index + "").value = 0;
    }
}

var table = document.getElementById("tblHeader");

var rowNo = 1;
var rowCount;

function AddMoreItem(Qty, Price) {

    //*** new code to generate row from 1st row ***//
    //add a row to the rows collection and get a reference to the newly added row
    var newRow = table.insertRow(rowNo);
    newRow.id = rowNo;
    //add cells (<td>) to the new row and set the innerHTML to contain text boxes                            
    var oCell = newRow.insertCell(0);
    oCell.innerHTML = "<input type='text' name='txtQty_" + rowNo + "' id='txtQty_" + rowNo + "' onblur='javascript:SetBlank(this,this.value);'  maxlength='8' class='textboxnew' style='width:75%' value='" + Qty + "'>"; //

    oCell = newRow.insertCell(1);
    oCell.innerHTML = "<input type='text' name='txtPrice_" + rowNo + "' id='txtPrice_" + rowNo + "' onblur='javascript:PriceOnBlur(this,this.value)' maxlength='8' class='textboxnew' style='width:75%' value='" + Price + "'>";

    oCell = newRow.insertCell(2);
    var txtqty = "txtQty_" + rowNo + "";
    var txtprice = "txtPrice_" + rowNo + "";
    oCell.innerHTML = "<img id='img" + rowNo + "' style='cursor:pointer' alt='Clear this ink' src='" + strImagepath + "close.gif' onclick=\"javascript:clear_ink(this.id,'" + txtqty + "','" + txtprice + "'," + rowNo + ");\" />";

    rowNo = rowNo + 1;
    rowCount++;
    //** End **//
}

function clear_ink(imgobj, txtqty, txtprice, trNo) {
    if (trNo > 1) {
        document.getElementById(trNo).style.display = 'none';
    }
}

function CallScroll() {
    OuterDivID = document.getElementById("div_test_1");
    InnerDivID = document.getElementById("div_test_2");
    DivTotalRecID = document.getElementById("div_TotalRec");
    startset(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
}

function load() {
    var strArr1 = str.value.split('µ');

    for (var i = 0; i <= strArr1.length - 1; i++) {
        var strArr2 = strArr1[i].split('±');
        if (strArr1[i] != '') {
            var ItemID = '>';
            var Qty = '';
            var Price = '';

            for (var j = 0; j <= strArr2.length - 1; j++) {
                var strArr3 = strArr2[j].split('»');
                if (strArr3[0] == "Quantity") {
                    Quantity = strArr3[1];
                }
                else if (strArr3[0] == "Price") {
                    Price = strArr3[1];
                }
            }
            AddMoreItem(Quantity, Price);
            var table = document.getElementById("tblHeader");
        }
    }
    for (var i = strArr1.length - 1; i < 10; i++) {
        AddMoreItem('', '');
    }
}

function OnChange_ddlPriceCatalogueCategory(objValue) {
    if (Number(objValue) != 0) {
        document.getElementById("div_DeleteCategory").style.display = "block";
    }
    else {
        document.getElementById("div_DeleteCategory").style.display = "none";
    }
}

function PriceOnBlur(obj, val) {
    SetBlank(obj, val);
    obj.value = roundNumber(val, 2);

}

function SetBlank(obj, val) {
    if (trim12(val) != '') {
        if (val.substring(1, 0) != "-")//for NEGATIVE Values
        {
            if (!isNaN(val)) {
                obj.value = val;
                document.getElementById("spn_txtQuantity_Number").style.display = "none";
                return true;
            }
            else {
                obj.value = '';
                obj.focus();
                document.getElementById("spn_txtQuantity_Number").style.display = "block";
                return true;
            }
        }
    }
}

function setLoadingPositionOfDivMove(divisionloading) {

    var width = divisionloading.style.width;
    var height = divisionloading.style.height;

    width = width.replace('px', '');
    height = height.replace('px', '');

    divisionloading.style.left = ((document.documentElement.clientWidth - width) / 2) + "px";

    var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
    divisionloading.style.top = (top + (document.documentElement.clientHeight - height) / 2) + "px";

    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth
}

function gettabs(value) {
    debugger;
    var ftpItem = document.getElementById("item_7");
    if (value == 'g') {
        document.getElementById("tdaddnew").style.display = "block";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("item_1").style.color = "red";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("item_decoration").style.color = "black";
        //document.getElementById("item_7").style.color = "black";
        document.getElementById("Div_EditableProduct").style.display = "none";
        //document.getElementById("Div_CustomDescription").style.display = "none";
        //document.getElementById("Div_StockSettings").style.display = "none";
        // document.getElementById("ctl00_ContentPlaceHolder1_div_SetupTemplate").style.display = "none";
        //document.getElementById("item_8").style.color = "black";
        document.getElementById("div_CouponCode").style.display = "none";

        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("div_FTP").style.display = "none";
    }

    else if (value == 'c') {
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "none";
    }

        //Added by Amin for decoration work
      
    else if (value == 'd') {
        document.getElementById("div_PricDecoration").style.display = "block";
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        //document.getElementById("item_7").style.color = "black";
        document.getElementById("item_decoration").style.color = "red";
        document.getElementById("Div_EditableProduct").style.display = "none";
        //document.getElementById("Div_CustomDescription").style.display = "none";
        //document.getElementById("Div_StockSettings").style.display = "none";
        // document.getElementById("ctl00_ContentPlaceHolder1_div_SetupTemplate").style.display = "none";
        //document.getElementById("item_8").style.color = "black";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_FTP").style.display = "none";
    }

        // added by rakshith for stock settings tab




    else if (value == 'ac') {
        if (IsWebstore.toLowerCase() == "yes") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "block";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("div_CouponCode").style.display = "none";
            document.getElementById("item_2").style.color = "red";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            document.getElementById("item_6").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("item_decoration").style.color = "black";
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("div_FTP").style.display = "none";
        }
        else if (Editable == "true") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_2").style.display = "none";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "red";
            document.getElementById("item_6").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("li_artworkCanvas").style.display = "none";
            document.getElementById("div_CouponCode").style.display = "none";
            document.getElementById("Div_EditableProduct").style.display = "block";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
            document.getElementById("div_FTP").style.display = "none";
        }
        else {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_CouponCode").style.display = "none";
            document.getElementById("div_additional").style.display = "block";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_4").style.color = "red";
            document.getElementById("item_5").style.color = "black";
            document.getElementById("item_6").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
            document.getElementById("div_FTP").style.display = "none";


        }
    }

    else if (value == 'acp') {
        if (Editable == "true") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            //document.getElementById("item_2").style.display = "none";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "red";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
            if (IsWebstore.toLowerCase() == "yes") {
                document.getElementById("li_artworkCanvas").style.display = "block";
            }
            else {
                document.getElementById("li_artworkCanvas").style.display = "none";
            }
            document.getElementById("Div_EditableProduct").style.display = "block";
        }
        else if (IsWebstore.toLowerCase() == "yes") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "block";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("item_2").style.color = "red";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
        }
        else {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "block";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "red";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
        }
    }

    else if (value == 'es') {

        if (IsWebstore.toLowerCase() == "yes") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "block";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("item_2").style.color = "red";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
        }
        else {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "block";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "red";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            if (ftpItem != null) {
                document.getElementById("item_7").style.color = "black";
            }
            document.getElementById("Div_EditableProduct").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
        }
    }

    else if (value == 'p') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "red";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "block";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "none";
        PriceFocus();
    }
    else if (value == 'ao') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "red";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "block";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "none";
    }
    else if (value == 'si') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
    }
    else if (value == 'ep') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "red";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "block";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "none";
    }
    else if (value == 'st') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
    }
    else if (value == 'cc') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "red";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "black";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "block";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "none";
    }
    else if (value == 'ft') {
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        document.getElementById("item_5").style.color = "black";
        document.getElementById("item_6").style.color = "black";
        if (ftpItem != null) {
            document.getElementById("item_7").style.color = "red";
        }
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditableProduct").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("div_PricDecoration").style.display = "none";
        document.getElementById("item_decoration").style.color = "black";
        document.getElementById("div_FTP").style.display = "block";


    }
}

gettabs(PageType);

function CheckAll(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) e.checked = ChkState;
    }
}

function CheckAll_New(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('checkAll_2') != -1) e.checked = ChkState;
    }
}

function CheckChanged(value) {
    var frm = '';

    frm = document.forms[0];
    if (value == "move") {
        var boolAllChecked; boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }
    else if (value == "remove") {
        var boolAllChecked; boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_2') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }

}

function showListbox(para) {
    if (para == "s") {
        lstCustomer.disabled = false;
        var list = '';
        for (i = 0; i < lstCustomer.length; i++) {
            list = list + lstCustomer.options[i].selected;
        }

    }
    else if (para == "a") {
        for (i = 0; i < lstCustomer.length; i++) {
            lstCustomer.options[i].selected = false;
        }
        lstCustomer.disabled = true;

        href_selectAll_Private.style.display = "block";
        href_selectNone_Private.style.display = "none";
    }
}

function CheckOne(value) {
    var Counter = 0;
    var frm = '';

    var frm = document.forms[0];
    if (value == "move") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_1') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }
    else if (value == "remove") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    if (Number(Counter) == 0) {
        if (value == "move") {
            alert("Please check atleast one 'row' to Move");
        }
        else if (value == "remove") {
            alert("Please check atleast one 'row' to Remove");
        }
        return false;
    }
    else {
        return true;
    }
}

function btnNext_Page(prev, next) {
    debugger;
     //alert("prev = " + prev + " & Next = " + next);
    //  var ImageUpload = true;
    var PdfUpload = true;
    var checknew = true;
    if (next == '5') {
        //        checknew = Validate_btnNext1();
        //        if (checknew) {
        //document.getElementById("Div_CustomDescription").style.display = "block";
        document.getElementById("item_1").style.color = "black";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";
        //document.getElementById("item_6").style.color = "red";
        document.getElementById("tdaddnew").style.display = "none";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("Div_EditProduct").style.display = "block"
        document.getElementById("item_5").style.color = "red";
        //        }
        //        else {
        //            return false;
        //        }
    }

    if (next == '2') {
        checknew = Validate_btnNext1();
        if (checknew) {
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_3").style.color = "red";
            document.getElementById("item_4").style.color = "black";
            //document.getElementById("item_6").style.color = "black";
            // document.getElementById("item_8").style.color = "black";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "block";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("div_PricDecoration").style.display = "none";
            document.getElementById("item_decoration").style.color = "black";
            //document.getElementById("ctl00_ContentPlaceHolder1_Labeldecoration").style.color = "black";
            
            //document.getElementById("Div_CustomDescription").style.display = "none";
            //document.getElementById("Div_StockSettings").style.display = "none";
            PriceFocus();


        }
        else {
            return false;
        }
    }
    else if (next == '3' && prev == '4') {
        if (IsWebstore.toLowerCase() == "no") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("item_3").style.color = "red";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_4").style.color = "black";
            document.getElementById("item_5").style.color = "black";
            document.getElementById("div_Pricemain").style.display = "block";
            document.getElementById("div_additional").style.display = "none";
        }
        else {
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "block";
            document.getElementById("div_additional").style.display = "none";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_3").style.color = "red";
            document.getElementById("item_4").style.color = "black";
        }
    }
    else if (next == '3' && prev == '2') {
        if (IsWebstore.toLowerCase() == "no") {
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_4").style.color = "red";
            document.getElementById("item_5").style.color = "black";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_additional").style.display = "block";
            
            
        }
    }
    else if (next == '4') {
        //  ImageUpload = isValidFile();
        PdfUpload = ValidatePdfFile();
        if (PdfUpload == true) {
            document.getElementById("item_1").style.color = "black";
            document.getElementById("item_2").style.color = "black";
            document.getElementById("item_3").style.color = "black";
            document.getElementById("item_4").style.color = "red";
            document.getElementById("tdaddnew").style.display = "none";
            document.getElementById("div_ArtworkcanvasMain").style.display = "none";
            document.getElementById("div_Pricemain").style.display = "none";
            document.getElementById("div_additional").style.display = "block";


        }
        else {
            btnNext_Page('4', '3');
            return false;
        }
    }
    else if (next == '1') {
        document.getElementById("tdaddnew").style.display = "block";
        document.getElementById("div_ArtworkcanvasMain").style.display = "none";
        document.getElementById("div_Pricemain").style.display = "none";
        document.getElementById("div_additional").style.display = "none";
        document.getElementById("div_CouponCode").style.display = "none";
        document.getElementById("item_1").style.color = "red";
        document.getElementById("item_2").style.color = "black";
        document.getElementById("item_3").style.color = "black";
        document.getElementById("item_4").style.color = "black";

    }
}

// Added Validate PDF file by Shivappa on 03/02/12
function ValidatePdfFile() {
    debugger;
    upPrintReadyFile = document.getElementById("ctl00_ContentPlaceHolder1_upPrintReadyFile");
    var pathLength = upPrintReadyFile.value.length;
    if (pathLength > 0) {
        var lastDot = upPrintReadyFile.value.lastIndexOf(".");
        var ext = upPrintReadyFile.value.substring(lastDot, pathLength);
        if (ext.toLowerCase() == ".pdf" || ext.toLowerCase() == ".jpg" || ext.toLowerCase() == ".png") {
            return true;
        }
        else {
            var divext = document.getElementById("Spn_upPrintReadyFile");
            divext.style.display = 'block';
            return false;
        }
    }
    else {
        return true;
    }
}

function Validate(type, IsStockExist) {
    debugger;
    //var ImageUpload = true;
    var PdfUpload = true;
    var CheckVal = true;

    CheckVal = Validate_btnNext1();
    // ImageUpload = isValidFile(); //to validate image upload file
    PdfUpload = ValidatePdfFile(); // to validate pdf upload file

    if (CheckVal) {
        if (PdfUpload == true) {

            var IsStockProduct = document.getElementById('ctl00_ContentPlaceHolder1_chkstockitem');
            var IsselfProduct = document.getElementById('ctl00_ContentPlaceHolder1_ddldrawstockfrom');
            if (type != "managestock" && type != "managestockcc" && !AllowtoSaveZerostock) {
                if (typeof IsStockProduct != 'undefined' && IsStockProduct != undefined && IsStockProduct != null) {
                    if (IsStockProduct.checked && IsStockExist.toLowerCase() == 'false') {

                        if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.';
                        } else if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'otherproducts' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'othermultiple' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'additionaloptions') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You need to save and manage stock and complete the stock settings before you can save this product.';
                        }

                        $("#dialog-confirm").dialog({
                            resizable: false,
                            width: '440px',
                            modal: true,
                            buttons: {
                                Cancel: function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = false;
                                },
                                "Save": function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = true;
                                    if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                                        document.getElementById('ctl00_ContentPlaceHolder1_hdn_AddZeroOpeningStock').value = true;
                                    }
                                    Validate(type, IsStockExist);
                                }
                            }
                        });
                        $("#dialog-confirm").dialog('open');
                        return false;
                    }
                }
            }

            getItemValues(); //to get price band values
            getAdditionalValues(); //to get webstore additinal item id's
            if (type == "save") {
                loadingimage('ctl00_ContentPlaceHolder1_btnFinalSave', 'div_finalsaveprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkFinalSave', '');
            }
            else if (type == "saveandstay") {
                loadingimage('ctl00_ContentPlaceHolder1_btnAdditionalSaveandStay', 'div_btnaddsavestayprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkAdditionalSaveandStay', '');
            }
            else if (type == "savegroupandstay") {
                __doPostBack('ctl00$ContentPlaceHolder1$lnkSaveGroupandFinal', '');
            }
            else if (type == "managestock") {
                loadingimage('ctl00_ContentPlaceHolder1_btnadditionalstocksave', 'div_additionalstockprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkprice_managestock', '');
            }
            else if (type == "savecc") {
                loadingimage('ctl00_ContentPlaceHolder1_btn_CouponCode_Save', 'div_CouponCode_finalsaveprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnk_CouponCode_Save', '');
            }
            else if (type == "saveandstaycc") {
                loadingimage('ctl00_ContentPlaceHolder1_btn_CouponCode_SaveStay', 'div_CouponCode_btnaddsavestayprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnk_CouponCode_SaveStay', '');
            }
            else if (type == "managestockcc") {
                loadingimage('ctl00_ContentPlaceHolder1_btn_CouponCode_SaveMangeStock', 'div_CouponCode_Stockprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnk_CouponCode_SaveMangeStock', '');
            }
            return false;  //false
        }
        else {
            btnNext_Page('4', '3');
            return false;
        }
    }
    else {
        btnNext_Page('4', '1');
        return false;
    }
}

function Validate_btnNext1() {
    asyncState = false;
    var CheckVal = true;
    if (CallonChange(ddlPriceCatalogueCategory.value, 'spn_ddlPriceCatalogueCategory')) {
        CheckVal = false;
    }
    if (CheckStringMandatory(txtCatalogueName.value, 'spn_txtCatalogueName')) {
        CheckVal = false;
    }
    if (queryString == 'edit') {
        if (CheckStringMandatory(txtitemcode.value, 'spn_txtitemcode')) {
            CheckVal = false;
        }
    } else {
        var txtItemCode_Checkduplicacy = $('#ctl00_ContentPlaceHolder1_txtitemcode').val();

        if (CheckPricecatalogue(txtItemCode_Checkduplicacy)) {
            CheckVal = false;
        }
    }

    var chkstockitem = document.getElementById("ctl00_ContentPlaceHolder1_chkstockitem");

    if (ddldrawstockfrom.selectedIndex == 0 && chkstockitem.checked) {
        document.getElementById("spn_DrawStockFromError").style.display = "block";
        CheckVal = false;
    }
    else {
        document.getElementById("spn_DrawStockFromError").style.display = "none";
    }

    if (ddl_SaleTaxRate.selectedIndex == 0) {
        document.getElementById("spn_Salestaxrate").style.display = "none";
        //CheckVal = false;
    }
    else {
        document.getElementById("spn_Salestaxrate").style.display = "none";
    }

    if (CheckVal) {
        if (IsDuplicate) {
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return false;
    }
}

function getItemValues() {
    debugger;
    var PriceData = '';
    var isFirstChk = false;

    for (var i = 0; i < TotalRow; i++) {
        if (document.getElementById("txtQty_" + i + "") != null) {
            var QtyValue = document.getElementById("txtQty_" + i + "").value;

            if (isFirstChk == false) {
                if (ddlMatrixType.value == "simplematrix") {
                    if (document.getElementById("txtQty_from_" + i + "") != null) {

                        document.getElementById("txtQty_from_" + i + "").value = 1;
                        isFirstChk = true;
                    }
                }
            }
            if (Number(QtyValue) != 0) {
                var txtQty_From = document.getElementById("txtQty_from_" + i + "");

                var txtQty = document.getElementById("txtQty_" + i + "");
                var txtCost = document.getElementById("txtCost_" + i + "");
                var txtMarkup = document.getElementById("txtMarkup_" + i + "");
                var txtSellingPrice = document.getElementById("txtSellingPrice_" + i + "");
                var txtWeight = document.getElementById("txtWeight_" + i + "");
                var txtWidth = document.getElementById("txtWidth_" + i + "");
                var txtHeight = document.getElementById("txtHeight_" + i + "");
                var txtLength = document.getElementById("txtLength_" + i + "");
                
                if (ddlMatrixType.value == "simplematrix" || ddlMatrixType.value == "pricebands") {
                    var hideOnEStore = document.getElementById("chkHideOnEStore_" + i + "");
                    PriceData += "HideOnEStore»" + (hideOnEStore.checked ? 1 : 0) + "±";
                }
       
                PriceData += "FromQty»" + txtQty_From.value + "±";
                PriceData += "ToQty»" + txtQty.value + "±";
                PriceData += "Cost»" + txtCost.value + "±";
                PriceData += "Markup»" + txtMarkup.value + "±";
                PriceData += "SellingPrice»" + txtSellingPrice.value + "±";

                if (ddlMatrixType.value == "signagematrix") {


                    PriceData += "Weight»" + txtWeight.value + "µ";
                    //                    PriceData += "Width»" + txtWidth.value + "±";
                    //                    PriceData += "Height»" + txtHeight.value + "±";
                    //                    PriceData += "Length»" + txtLength.value + "µ";
                }

                else {
                    PriceData += "Weight»" + txtWeight.value + "±";
                    PriceData += "Width»" + txtWidth.value + "±";
                    PriceData += "Height»" + txtHeight.value + "±";
                    PriceData += "Length»" + txtLength.value + "µ";
                }
            }
        }
        hidQtyPrice.value = PriceData;
    }
    hidQtyPrice.value = PriceData;
}

function RemoveImage(type) {
    if (type == "image") {
        lblProductImage.innerHTML = "";
        hid_ProductImage.value = "";
        lblProductImage.style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ancUploadimage").style.display = "block";
        //  uplImage.style.display = "block";
    }
    else if (type == "pdf") {
        lblPrintReadyFile.innerHTML = "";
        hid_PrintReadyFile.value = "";
        hid_ReportFile.value = "";
        lblPrintReadyFile.style.display = "none";
        upPrintReadyFile.style.display = "block";
        divPreFlight.style.display = "block";
        var pdf_delete = document.getElementById("pdf_delete");
        if (typeof pdf_delete != 'undefined' && pdf_delete != undefined && pdf_delete != null) {
            pdf_delete.style.display = "none";
        }
    }
}

function ChkArtworkFile_onclick(val) {
    if (ChkArtworkFile.checked) {
        hid_ArtworkFileValue.value = val;
        ChkMandatoryArtworkFile.disabled = false;
        ddlArtCount.disabled = false;
        if (ChkMandatoryArtworkFile.checked) {
            hid_ArtworkFileValue.value = 'M'; //both artwork file and mandatory fields are checked
        }
        else {
            hid_ArtworkFileValue.value = 'Y';
        }
    }
    else {
        ChkMandatoryArtworkFile.disabled = true;
        ChkMandatoryArtworkFile.checked = false;
        ddlArtCount.disabled = true;
        hid_ArtworkFileValue.value = 'N';
    }
}

function PriceSave_andStay(type, IsStockExist) {
    var CheckPriceVal = true;

    CheckPriceVal = Validate_btnNext1();

    if (CheckPriceVal) {

        var IsStockProduct = document.getElementById('ctl00_ContentPlaceHolder1_chkstockitem');
        var IsselfProduct = document.getElementById('ctl00_ContentPlaceHolder1_ddldrawstockfrom');
        if (type != "managestock" && !AllowtoSaveZerostock) {
            if (typeof IsStockProduct != 'undefined' && IsStockProduct != undefined && IsStockProduct != null) {
                if (IsStockProduct.checked && IsStockExist.toLowerCase() == 'false') {

                    if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                        document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.';
                    } else if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'otherproducts' ||
                        IsselfProduct.options[IsselfProduct.selectedIndex].value == 'othermultiple' ||
                        IsselfProduct.options[IsselfProduct.selectedIndex].value == 'additionaloptions') {
                        document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You need to save and manage stock and complete the stock settings before you can save this product.';
                    }

                    $("#dialog-confirm").dialog({
                        resizable: false,
                        width: '440px',
                        modal: true,
                        buttons: {
                            Cancel: function () {
                                $(this).dialog("close");
                                AllowtoSaveZerostock = false;
                            },
                            "Save": function () {
                                $(this).dialog("close");
                                AllowtoSaveZerostock = true;
                                if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                                    document.getElementById('ctl00_ContentPlaceHolder1_hdn_AddZeroOpeningStock').value = true;
                                }
                                PriceSave_andStay(type, IsStockExist);
                            }
                        }
                    });
                    $("#dialog-confirm").dialog('open');
                    return false;
                }
            }
        }

        
        var PdfUpload = true;
        PdfUpload = ValidatePdfFile();
        if (PdfUpload) {
            getItemValues(); //to get price band values
            if (queryString == "edit") {
                getAdditionalValues();
            }
        }
        else {
            gettabs('ac');
            return false;
        }
        if (type == "saveandstay") {
            loadingimage('ctl00_ContentPlaceHolder1_btnPriceSaveandStay', 'div_pricesavestayprocess');
            __doPostBack('ctl00$ContentPlaceHolder1$lnkPriceSaveandStay', '');
        }
        else if (type == "save") {
            loadingimage('ctl00_ContentPlaceHolder1_btnPriceSave', 'div_btnpricesaveprocess');
            __doPostBack('ctl00$ContentPlaceHolder1$lnkPriceSave', '');
        }
        else if (type == "managestock") {
            loadingimage('ctl00_ContentPlaceHolder1_btnprice_managestock', 'div_pricemanagestock');
            __doPostBack('ctl00$ContentPlaceHolder1$lnkprice_managestock', '');
        }
        return false;
    }
    else {
        btnNext_Page('2', '1');
        return false;
    }
}

//***
function GeneralSave_Stay(type, IsStockExist) {

    var PdfUpload = true;
    var CheckVal = true;

    CheckVal = Validate_btnNext1();
    //PdfUpload = ValidatePdfFile(); // to validate pdf upload file
    if (CheckVal) {
        if (PdfUpload == true) {

            var IsStockProduct = document.getElementById('ctl00_ContentPlaceHolder1_chkstockitem');
            var IsselfProduct = document.getElementById('ctl00_ContentPlaceHolder1_ddldrawstockfrom');
            if (type != "managestock" && !AllowtoSaveZerostock) {
                if (typeof IsStockProduct != 'undefined' && IsStockProduct != undefined && IsStockProduct != null) {
                    if (IsStockProduct.checked && IsStockExist.toLowerCase() == 'false') {

                        if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.';
                        } else if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'otherproducts' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'othermultiple' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'additionaloptions') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You need to save and manage stock and complete the stock settings before you can save this product.';
                        }

                        $("#dialog-confirm").dialog({
                            resizable: false,
                            width: '440px',
                            modal: true,
                            buttons: {
                                Cancel: function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = false;
                                },
                                "Save": function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = true;
                                    if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                                        document.getElementById('ctl00_ContentPlaceHolder1_hdn_AddZeroOpeningStock').value = true;
                                    }
                                    GeneralSave_Stay(type, IsStockExist);
                                }
                            }
                        });
                        $("#dialog-confirm").dialog('open');
                        return false;
                    }
                }
            }

            getItemValues(); //to get price band values
            getAdditionalValues(); //to get webstore additinal item id's
            if (type == "save") {
                loadingimage('ctl00_ContentPlaceHolder1_btngensave', 'div_btngensaveprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkgensave', '');
            }
            else if (type == "saveandstay") {
                loadingimage('ctl00_ContentPlaceHolder1_btngenstay', 'div_gensavestayprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkgensavestay', '');
            }
            else if (type == "managestock") {
                loadingimage('ctl00_ContentPlaceHolder1_btngenmanagestock', 'div_gensavestockprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkprice_managestock', '');
            }
            return false;  //false
        }
        else {

            return false;
        }
    }
    else {
        return false;
    }
}
//***
function ArtworkSave_andStay(type, IsStockExist) {
    var ArtworkImageUpload = true;
    var CheckArtworkVal = true;
    var PdfFileUpload = true;

    if (hdn_IsPreFlight.value == "1") {
        if (chkPreFlightFiles.checked && ddlPreflightFiles.selectedIndex == 0) {
            alert("Please select profile");
            ddlPreflightFiles.focus();
            return false;
        }
    }

    CheckArtworkVal = Validate_btnNext1();
    //ArtworkImageUpload = isValidFile(); //to validate image upload file
    PdfFileUpload = ValidatePdfFile(); // to validate pdf upload file

    if (CheckArtworkVal) {
        if (ArtworkImageUpload == true && PdfFileUpload == true) {

            var IsStockProduct = document.getElementById('ctl00_ContentPlaceHolder1_chkstockitem');
            var IsselfProduct = document.getElementById('ctl00_ContentPlaceHolder1_ddldrawstockfrom');
            if (type != "managestock" && !AllowtoSaveZerostock) {
                if (typeof IsStockProduct != 'undefined' && IsStockProduct != undefined && IsStockProduct != null) {
                    if (IsStockProduct.checked && IsStockExist.toLowerCase() == 'false') {

                        if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.';
                        } else if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'otherproducts' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'othermultiple' ||
                            IsselfProduct.options[IsselfProduct.selectedIndex].value == 'additionaloptions') {
                            document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You need to save and manage stock and complete the stock settings before you can save this product.';
                        }

                        $("#dialog-confirm").dialog({
                            resizable: false,
                            width: '440px',
                            modal: true,
                            buttons: {
                                Cancel: function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = false;
                                },
                                "Save": function () {
                                    $(this).dialog("close");
                                    AllowtoSaveZerostock = true;
                                    if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                                        document.getElementById('ctl00_ContentPlaceHolder1_hdn_AddZeroOpeningStock').value = true;
                                    }
                                    ArtworkSave_andStay(type, IsStockExist);
                                }
                            }
                        });
                        $("#dialog-confirm").dialog('open');
                        return false;
                    }
                }
            }

            getItemValues(); //to get price band values
            if (queryString == "edit") {
                getAdditionalValues();
            }
            if (type == "saveandstay") {
                loadingimage('ctl00_ContentPlaceHolder1_btnArtworkSaveandStay', 'div_btnartsavestayprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkArtworkSaveandStay', '');
            }
            else if (type == "save") {
                loadingimage('ctl00_ContentPlaceHolder1_btnArtworkSave', 'div_btnartworksaveprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkArtworkSave', '');
            }
            else if (type == "managestock") {
                loadingimage('ctl00_ContentPlaceHolder1_btnestoresavestock', 'div_estorestocksaveprocess');
                __doPostBack('ctl00$ContentPlaceHolder1$lnkprice_managestock', '');
            }
            return false;
        }
        else {
            btnNext_Page('3', '3');
            return false;
        }
    }
    else {
        btnNext_Page('3', '1');
        return false;
    }
}

function FTPSave_Stay() {
    debugger;

    var errorSpan = document.getElementById("spn_FTP");
    var folder = document.getElementById(ftpFolderDropdownId).value;
    var PdfUpload = true;
    PdfUpload = ValidatePdfFile();

    if (folder === "0" || folder === "") {
        errorSpan.style.display = "inline";
        return false;
    } else {
        if (PdfUpload == true) {
            getItemValues(); //to get price band values
            getAdditionalValues(); //to get webstore additinal item id's
            errorSpan.style.display = "none";
            return true;
        }
        else {
            gettabs('ac');
            return false;
        }
       
    }
}

//******* funcn to check for ItemCode duplicacy *********////
var IsDuplicate = false;
function CheckPricecatalogue(val1) {
    if (val1 != '') {
        var val = CompanyID + "±" + val1 + "±" + ProductCatalogueID;
        PageMethods.GetPricecatalogue(val, ShowMsgDigital, ShowMsg_Failure);
    }
}

function ShowMsgDigital(result) {

    $get('spn_txtitemcodeCheck').style.display = "none";
    if (result == -1) {
        $get('spn_txtitemcodeCheck').style.display = "block";
        IsDuplicate = true;
    }
    else {
        IsDuplicate = false;
    }
}

// Failure callback method     
function ShowMsg_Failure(error) {
}
//*******End of funcn to ckech for ItemCode duplicacy*********////

//******* funcns for Adding groups for additional items*********////
function show() {
    img_actionsHide.style.display = "block";
    img_actionsShow.style.display = "none";

    div_chk.style.border = "inset 1px";
    div_chk.style.background = "gray";

    div_popupAction.style.display = "block";
}

function hide() {
    img_actionsHide.style.display = "none";
    img_actionsShow.style.display = "block";

    div_chk.style.border = "outset 1px";
    div_chk.style.background = "";

    div_popupAction.style.display = "none";
}

function CheckOne_new(val) {
    var chkTrue = false;
    var Counter = 0;
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id_2') != -1) {
            if (!e.disabled) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    hide();

    if (Number(Counter) < 2 && val == "add") {
        alert("Please check atleast two 'rows' to add to Group");
        return false;
        chkTrue = true;
    }
    else if (Number(Counter) == 0 && val == "remove") {
        alert("Please check atleast one 'row' to Remove from Group");
        return false;
        chkTrue = true;
    }

    if (!chkTrue) {
        if (val == "add") {
            ShowHideGroup('show');
        }
    }
}

function ShowHideGroup(type) {
    var ddlGroup = document.getElementById("ctl00_ContentPlaceHolder1_ddlGroup");
    if (type == "show") {
        document.getElementById("divBackGroundNew").style.display = "block";
        txtGroupName.value = "";
        showDivPopupCenter('div_Group', '200');
        if (ddlGroup.length > 2) {
            div_grpEdit.style.display = "block";
            div_grpAdd.style.display = "none";
            div_grpCancel.style.display = "none";
            ddlGroup.selectedIndex = 0;
        }
        else {
            div_grpEdit.style.display = "none";
            div_grpAdd.style.display = "block";
            ddlGroup.selectedIndex = 1;
        }
    }
    else {
        document.getElementById("divBackGroundNew").style.display = "none";
        div_Group.style.display = "none";
        document.getElementById("spnerrGroupName").style.display = "none";
    }
}

function ValidateGroup() {
    var ddlGroup = document.getElementById("ctl00_ContentPlaceHolder1_ddlGroup");
    if (ddlGroup.options[ddlGroup.selectedIndex].value == "-2") {
        if (trim12(txtGroupName.value) == "") {
            document.getElementById("spnerrGroupName").style.display = "block";
            return false;
        }
        else {
            GetAdditionalValuesForGroup();
            ShowHideGroup('hide');
            //            __doPostBack('ctl00$ContentPlaceHolder1$lnkSaveGroup', '');
            //            div_grpEdit.style.display = "block";
            //            div_grpAdd.style.display = "none";
            //            div_grpCancel.style.display = "none";
            //            ddlGroup.selectedIndex = 0;
            Validate('savegroupandstay'); //Bug ID: 878 -- Saving Groups for Additional Items in estore
            return false;
        }
    }
    else {
        if (ddlGroup.options[ddlGroup.selectedIndex].value != "-2" && ddlGroup.options[ddlGroup.selectedIndex].value != "-1") {
            GetAdditionalValuesForGroup();
            ShowHideGroup('hide');
            //__doPostBack('ctl00$ContentPlaceHolder1$lnkSaveGroup', '');
            Validate('savegroupandstay'); //Bug ID: 878 -- Saving Groups for Additional Items in estore
            return false;
        }
        else {
            document.getElementById("spnerrGroupName").style.display = "block";
            document.getElementById("spnerrGroupName").innerHTML = "Please select valid Group";
            return false;
        }
    }
}

function onchange_ddlGroup(val) {
    var ddlGroup = document.getElementById("ctl00_ContentPlaceHolder1_ddlGroup");
    val = ddlGroup.options[ddlGroup.selectedIndex].value;
    if (val == "-2") {
        div_grpEdit.style.display = "none";
        div_grpAdd.style.display = "block";
        div_grpCancel.style.display = "block";
    }
    else {
        if (val == "-1") {
            document.getElementById("div_DeleteGroup").style.display = "none";
        }
        else {
            document.getElementById("div_DeleteGroup").style.display = "block";
        }
        div_grpEdit.style.display = "block";
        div_grpAdd.style.display = "none";
        div_grpCancel.style.display = "none";
    }
}

function btnGroup_Cancel() {
    var ddlGroup = document.getElementById("ctl00_ContentPlaceHolder1_ddlGroup");
    var val = ddlGroup.options[ddlGroup.selectedIndex].value;
    div_grpEdit.style.display = "block";
    div_grpAdd.style.display = "none";
    div_grpCancel.style.display = "none";
    ddlGroup.selectedIndex = 0;
    document.getElementById("div_DeleteGroup").style.display = "block";
}

function Onclick_Remove() {
    var len = GetAdditionalValuesForGroup();
    if (len) {
        __doPostBack('ctl00$ContentPlaceHolder1$lnkRemove', '');
    }
}

function Delete_Group() {
    GetAdditionalValuesForGroup();
    var hid_AddValues_onDelete = document.getElementById("ctl00_ContentPlaceHolder1_hid_AddValues_onDelete");

    var firstConfirm = window.confirm('Are you sure you want to Delete the Group?');
    if (firstConfirm) {
        __doPostBack('ctl00$ContentPlaceHolder1$lnkDeleteGroup', '');
        var ddlGroup = document.getElementById("ctl00_ContentPlaceHolder1_ddlGroup");
        if (ddlGroup.length == 3) {
            div_grpEdit.style.display = "none";
            div_grpAdd.style.display = "block";
            ddlGroup.selectedIndex = 1;
        }

        var strValues = hid_AddValues_onDelete.value.split(',');
        for (var i = 0; i <= Number(strValues.length) ; i++) {
            if (strValues[i] != "" && strValues[i] != null) {
                SetAddlValForGroup_onDelete(strValues[i]);
            }
        }
    }
    ShowHideGroup('hide');
}

function testing(customerList) {
    alert(customerList);
}

//*******End of funcn for Adding groups for additional items*********////

//***** Custom description row generator  by rakshith*******************//
function AddCustomDescriptionrow() {

    if (div2.style.display != "block") {
        incrval.value = 2;
    }
    else if (div3.style.display != "block") {
        incrval.value = 3;
    }
    else if (div4.style.display != "block") {
        incrval.value = 4;
    }
    else if (div5.style.display != "block") {
        incrval.value = 5;
    }
    else if (div6.style.display != "block") {
        incrval.value = 6;
    }
    else if (div7.style.display != "block") {
        incrval.value = 7;
    }
    else if (div8.style.display != "block") {
        incrval.value = 8;
    }
    else if (div9.style.display != "block") {
        incrval.value = 9;
    }
    else if (div10.style.display != "block") {
        incrval.value = 10;
    }
    else if (div11.style.display != "block") {
        incrval.value = 11;
    }
    else if (div12.style.display != "block") {
        incrval.value = 12;
    }
    else if (div13.style.display != "block") {
        incrval.value = 13;
    }
    else {
        incrval.value = 0;
    }
    var increment = 0;
    if (div1.style.display != "block") {
        increment = 1;
    } else {
        increment = incrval.value;
    }
    if (increment == 1) {
        div1.style.display = "block";
        return false;
    }
    if (increment == 2) {
        div2.style.display = "block";
        return false;
    }
    if (increment == 3) {
        div3.style.display = "block";
        return false;
    }
    if (increment == 4) {
        div4.style.display = "block";
        return false;
    }
    if (increment == 5) {
        div5.style.display = "block";
        return false;
    }
    if (increment == 6) {
        div6.style.display = "block";
        return false;
    }
    if (increment == 7) {
        div7.style.display = "block";
        return false;
    }
    if (increment == 8) {
        div8.style.display = "block";
        return false;
    }
    if (increment == 9) {
        div9.style.display = "block";
        return false;
    }
    if (increment == 10) {
        div10.style.display = "block";
        return false;
    }
    if (increment == 11) {
        div11.style.display = "block";
        return false;
    }
    if (increment == 12) {
        div12.style.display = "block";
        return false;
    }
    if (increment == 13) {
        div13.style.display = "block";
        textaddcustom.style.display = "none";
        return false;
    }
    if (increment == 0) {
        textaddcustom.style.display = "none";
        return false;
    }


}
//****** end of custom descr******//

function EditSavevalidate(IsStockExist_FromEditable) {
    debugger

    var CheckPriceVal = true;

    CheckPriceVal = Validate_btnNext1();

    if (CheckPriceVal) {

        var IsStockProduct = document.getElementById('ctl00_ContentPlaceHolder1_chkstockitem');
        var IsselfProduct = document.getElementById('ctl00_ContentPlaceHolder1_ddldrawstockfrom');
        if (!AllowtoSaveZerostock) {
            if (typeof IsStockProduct != 'undefined' && IsStockProduct != undefined && IsStockProduct != null) {
                if (IsStockProduct.checked && IsStockExist_FromEditable.toLowerCase() == 'false') {

                    if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                        document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.';
                    } else if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'otherproducts' ||
                        IsselfProduct.options[IsselfProduct.selectedIndex].value == 'othermultiple' ||
                        IsselfProduct.options[IsselfProduct.selectedIndex].value == 'additionaloptions') {
                        document.getElementById('spn_dialog-confirm-msg').innerHTML = 'You need to save and manage stock and complete the stock settings before you can save this product.';
                    }

                    $("#dialog-confirm").dialog({
                        resizable: false,
                        width: '440px',
                        modal: true,
                        buttons: {
                            Cancel: function () {
                                $(this).dialog("close");
                                AllowtoSaveZerostock = false;
                            },
                            "Save": function () {
                                $(this).dialog("close");
                                AllowtoSaveZerostock = true;
                                if (IsselfProduct.options[IsselfProduct.selectedIndex].value == 'self') {
                                    document.getElementById('ctl00_ContentPlaceHolder1_hdn_AddZeroOpeningStock').value = true;
                                }
                                ArtworkSave_andStay(type, IsStockExist_FromEditable);
                            }
                        }
                    });
                    $("#dialog-confirm").dialog('open');
                    return false;
                }
            }
        }

        getItemValues(); //to get price band values
        return true;
    }
    else {

        gettabs('g');
        return false;

    }
}

function PriceFocus() {
    try//without try catch it will gives error when press next from general tab
    {
        var textField = document.getElementById('txtCost_0');
        textField.focus();
        textField.select();
    }
    catch (e) {
    }
}

// added by rakshith

function chkselectdept() {

    var cookieval = hdn_movecookievalue.value;
    rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    var mainval = cookieval.split('^');
    for (var d = 0; d < rowinputs.length; d++) {
        if (rowinputs[d].type == "checkbox") {
            if ((rowinputs[d].id).indexOf("chkdept_1") > -1) {
                for (var i = 0; i < mainval.length; i++) {

                    if (mainval[i] == rowinputs[d].value) {

                        rowinputs[d].checked = true;
                    }
                }
            }
        }
    }

}

function deptcheckmoved() {
    var custidsplit = '';
    var custid = '';
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    custidsplit = hid_MoveCustomers.value.split(',');
    for (var i = 0; i < custidsplit.length; i++) {
        custid = custidsplit[i];

        for (var d = 0; d < rowinputs.length; d++) {

            if (rowinputs[d].type == "checkbox" && (rowinputs[d].id).indexOf("chkdept_1") > -1) {

                var result = (rowinputs[d]).value.split("*~");
                var CID = result[0];
                var DeptID = result[1];
                if (CID == custid) {
                    rowinputs[d].checked = true;
                }
            }
            //            if (rowinputs[d].type == "checkbox" && (rowinputs[d].id).indexOf("Id_2") > -1) {

            //                if ((document.getElementById(rowinputs[d].id).value == custid)) {
            //                    document.getElementById(rowinputs[d].id).checked = true;
            //                }
            //            }


        }
    }
}

function storeselectedvalues() {
    var IDs_DeptIDs = '';
    var custid = '';
    hdn_gridbuffer.value = '';
    var frm = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    for (var l = 0; l < frm.length; l++) {
        if (frm[l].id.indexOf('Id') != -1) {
            if (frm[l].type == "checkbox") {
                if ((frm[l].id).indexOf("Id_2") > -1) {
                    var rowinputs = frm;
                    custid = frm[l].value;
                    for (var d = 0; d < rowinputs.length; d++) {
                        if (rowinputs[d].type == "checkbox" && (rowinputs[d].id).indexOf("chkdept_1") > -1) {
                            if (rowinputs[d].checked) {
                                var result = (rowinputs[d]).value.split("*~");
                                var CID = result[0];
                                var DeptID = result[1];
                                if (CID == custid) {
                                    IDs_DeptIDs = IDs_DeptIDs + (rowinputs[d]).value + "^";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    storeselectedradio();
    hdn_gridbuffer.value = IDs_DeptIDs;
}

//to buffer radio selected values
function storeselectedradio() {
    var AllocationType = 'A';
    var radioselctedvalue = '';
    document.getElementById("AllocationID_hdn_deptallocationtype").value = '';
    var frm = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    for (var l = 0; l < frm.length; l++) {
        if (frm[l].type == "radio") {
            if ((frm[l].id).indexOf("rdbselectall") > -1) {
                var rowinputs = frm;
                var custid = frm[l].value;
                if (document.getElementById(frm[l].id).checked) {
                    AllocationType = 'A';
                }
                else {
                    AllocationType = 'S';
                }

                radioselctedvalue = radioselctedvalue + custid + '~*' + AllocationType + "^";
            }
        }
    }

    document.getElementById("AllocationID_hdn_deptallocationtype").value = radioselctedvalue;

}

function chkselectbuffervalues() {
    var cookieval = hdn_gridbuffer.value;
    rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    var mainval = cookieval.split('^');
    for (var d = 0; d < rowinputs.length; d++) {
        if (rowinputs[d].type == "checkbox") {
            if ((rowinputs[d].id).indexOf("chkdept_1") > -1) {
                for (var i = 0; i < mainval.length; i++) {

                    if (mainval[i] == rowinputs[d].value) {

                        rowinputs[d].checked = true;

                    }
                }
            }
        }
    }
    checkheaderradio();
}

function HierarchyExpanding(sender, args) {
    var firstClientDataKeyName = args.get_tableView().get_clientDataKeyNames()[0];
}

function getFinalVaules(AllocationType) {
    var frm = '';
    frm = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    var i = 1;
    var ClientDeptID = '';
    var DeptIDs = '';
    var AllocationType = '';
    for (l = 0; l < frm.length; l++) {
        // if (frm[l].id.indexOf('Id') != -1) 
        {

            if (frm[l].type == "checkbox") {

                // rdbselectall
                if ((frm[l].id).indexOf("Id_2") > -1) {
                    var rowinputs = frm;
                    custid = frm[l].value;
                    for (c = 0; c < frm.length; c++) {
                        if (frm[c].type == "radio") {

                            if ((frm[c].id).indexOf("rdbselectall") > -1 && (document.getElementById(frm[c].id).value == custid)) {

                                if (document.getElementById(frm[c].id).checked) {
                                    AllocationType = 'A';

                                }
                                else {
                                    AllocationType = 'S';
                                }
                                for (var d = 0; d < rowinputs.length; d++) {
                                    if (rowinputs[d].type == "checkbox") {
                                        if (rowinputs[d].checked && (rowinputs[d].id).indexOf("chkdept_1") > -1) {
                                            var result = (rowinputs[d]).value.split("*~");
                                            var CID = result[0];
                                            var DeptID = result[1];
                                            if (CID == custid) {
                                                DeptIDs = DeptIDs + DeptID + ",";

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ClientDeptID = ClientDeptID + +custid + "¶" + AllocationType + "¶" + DeptIDs + "^";
                    DeptIDs = '';
                }
            }
        }
    }
    hdn_finalvalues.value = ClientDeptID;
}

//public allocation
function CallSelectPublic(value) {


    //var hid_MoveCustomers = hid_MoveCustomers;
    //var hid_RemoveCustomers = hid_RemoveCustomers;
    var ret = CheckOne(value);
    if (ret) {

        //CheckGrid();
        var custid = '';
        var DeptIDs = '';
        var IDs_DeptIDs = '';
        var IDs = '';
        var frm = '';
        var count = 0;
        if (From.toLowerCase() == 'category') {
            if (value == 'move') {
                frm = document.getElementById("PublicAllocation_GridAvailableCustomers").getElementsByTagName("input");
            }
            else if (value == 'remove') {
                frm = document.getElementById("PublicAllocation_GridSelectedCustomer").getElementsByTagName("input");
            }
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id') != -1) {
                    if (frm[l].type == "checkbox") {
                        if (frm[l].checked && ((frm[l].id).indexOf("Id_1") > -1 || (frm[l].id).indexOf("Id_2") > -1)) {
                            var rowinputs = frm;
                            custid = frm[l].value;
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }

            }
        }


        if (value == 'move') {
            hid_MoveCustomers.value = IDs;
            document.cookie = "MoveCustomers=" + IDs;
        }
        else {
            hid_RemoveCustomers.value = IDs;
            document.cookie = "RemoveCustomers=" + IDs;
        }
    }
    else {
        if (value == 'move') {
            document.cookie = "MoveCustomers=" + "";
            hid_MoveCustomers.value = '';

        }
        else {
            hid_RemoveCustomers.value = '';
            document.cookie = "RemoveCustomers=" + "";
        }
    }
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

function Allocate() {
    var pw = window.parent;
    var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
    hdn_Customers.value = hdn_CustomerList.value;
    pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_finalvalues").value = hdn_CustomerList.value;
    pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_iscopychecked").value = iscopychecked.value;
    pw.document.getElementById("ctl00_ContentPlaceHolder1_lnkallocatepublic").click();
    GetRadWindow().close();
}

function deptcheckall(value) {
    var custidsplit = '';
    var custid = '';
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    for (var d = 0; d < rowinputs.length; d++) {

        if (rowinputs[d].type == "radio" && (rowinputs[d].id).indexOf("rdbselectall") > -1) {
            if ((document.getElementById(rowinputs[d].id).value == value) && (document.getElementById(rowinputs[d].id).checked)) {
                for (var c = 0; c < rowinputs.length; c++) {

                    if (rowinputs[c].type == "checkbox" && (rowinputs[c].id).indexOf("chkdept_1") > -1) {
                        var result = (rowinputs[c]).value.split("*~");
                        var CID = result[0];
                        var DeptID = result[1];
                        if (CID == value) {
                            rowinputs[c].checked = true;
                        }
                    }
                }
            }

            // Commented for TicketID:13648

            //else if ((document.getElementById(rowinputs[d].id).value == value) && (document.getElementById(rowinputs[d].id).checked == false)) {
            //    for (var u = 0; u < rowinputs.length; u++) {
            //        if (rowinputs[u].type == "checkbox" && (rowinputs[u].id).indexOf("chkdept_1") > -1) {

            //            var result = (rowinputs[u]).value.split("*~");
            //            var CID = result[0];
            //            var DeptID = result[1];
            //            if (CID == value) {
            //                rowinputs[u].checked = false;
            //            }
            //        }
            //    }
            //}
        }
    }
}

function deptcheckallUncheck(value) {
    var custidsplit = '';
    var custid = '';
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    for (var d = 0; d < rowinputs.length; d++) {

        if (rowinputs[d].type == "radio") {
            if ((document.getElementById(rowinputs[d].id).value == value) && (document.getElementById(rowinputs[d].id).checked)) {
                for (var c = 0; c < rowinputs.length; c++) {

                    if (rowinputs[c].type == "checkbox" && (rowinputs[c].id).indexOf("chkdept_1") > -1) {
                        var result = (rowinputs[c]).value.split("*~");
                        var CID = result[0];
                        var DeptID = result[1];
                        if (CID == value) {
                            rowinputs[c].checked = false;
                        }
                    }
                }
            }

        }
    }
}

function deptuncheckone(boolval, value) {
    value = value.trim();
    var custidsplit = '';
    var custid = '';
    var count = 0;
    var checkedcount = 0;
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    if (boolval == false) {
        for (var d = 0; d < rowinputs.length; d++) {
            if (rowinputs[d].type == "radio" && (rowinputs[d].id).indexOf("rdbselectall") > -1) {

                if ((document.getElementById(rowinputs[d].id).value == value) && (document.getElementById(rowinputs[d].id).checked)) {
                    document.getElementById(rowinputs[d].id).checked = false;
                    for (var m = 0; m < rowinputs.length; m++) {
                        if (rowinputs[m].type == "radio" && (rowinputs[m].id).indexOf("rdbselect") > -1 && (document.getElementById(rowinputs[m].id).value == value)) {
                            document.getElementById(rowinputs[m].id).checked = true;
                        }

                    }
                }

            }
        }
    }
    else {
        for (var c = 0; c < rowinputs.length; c++) {
            if (rowinputs[c].type == "checkbox" && (rowinputs[c].id).indexOf("chkdept_1") > -1) {
                var result = (rowinputs[c]).value.split("*~");
                var CID = result[0];
                var DeptID = result[1];
                if (CID == value) {
                    count = Number(count) + Number(1);
                    if (rowinputs[c].checked == true) {
                        checkedcount = Number(checkedcount) + Number(1);
                    }
                }
            }
        }
        if (Number(count) == Number(checkedcount)) {

            for (var d = 0; d < rowinputs.length; d++) {
                if (rowinputs[d].type == "radio" && (rowinputs[d].id).indexOf("rdbselectall") > -1) {
                    if ((document.getElementById(rowinputs[d].id).value == value) && (document.getElementById(rowinputs[d].id).checked == false)) {
                        document.getElementById(rowinputs[d].id).checked = true;
                    }
                }
            }

        }
    }

}

function Checkheadertick() {
    var maincustid = 0;
    var count = 0;
    var checkedcount = 0;
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    for (var c = 0; c < rowinputs.length; c++) {
        if (rowinputs[c].type == "radio" && (rowinputs[c].id).indexOf("rdbselectall") > -1) {
            maincustid = document.getElementById(rowinputs[c].id).value;
            checkedcount = 0;
            count = 0;
            for (var d = 0; d < rowinputs.length; d++) {
                if (rowinputs[d].type == "checkbox" && (rowinputs[d].id).indexOf("chkdept_1") > -1) {
                    var result = (rowinputs[d]).value.split("*~");
                    var CID = result[0];
                    var DeptID = result[1];
                    if (CID == maincustid) {
                        count = Number(count) + Number(1);
                        if (rowinputs[d].checked == true) {
                            checkedcount = Number(checkedcount) + Number(1);
                        }
                    }
                }
            }
            if (Number(count) == Number(checkedcount)) {
                document.getElementById(rowinputs[c].id).checked = true;

            }
        }

    }
}

function checkheaderradio() {
    var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
    var allocationsplit = document.getElementById("AllocationID_hdn_deptallocationtype").value.split('^');
    var CustID = 0;
    var Allocationtype = '';
    for (var k = 0; k < allocationsplit.length; k++) {
        var maintypesplit = allocationsplit[k].split('~*');
        CustID = maintypesplit[0];
        Allocationtype = maintypesplit[1];

        if (CustID != null && Allocationtype != null) {
            if (Allocationtype.toLowerCase() == 's') {

                for (var d = 0; d < rowinputs.length; d++) {
                    if (rowinputs[d].type == "radio" && (rowinputs[d].id).indexOf("rdbselect") > -1) {

                        if ((document.getElementById(rowinputs[d].id).value == CustID)) {
                            document.getElementById(rowinputs[d].id).checked = true;
                            for (var m = 0; m < rowinputs.length; m++) {
                                if (rowinputs[m].type == "radio" && (rowinputs[m].id).indexOf("rdbselectall") > -1 && (document.getElementById(rowinputs[m].id).value == CustID)) {
                                    document.getElementById(rowinputs[m].id).checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

function ParentCategoryAlloction() {
    var mode = document.getElementById("ctl00_ContentPlaceHolder1_hidmode").value;
    var div = document.getElementById("ctl00_ContentPlaceHolder1_divParentCategoryAlloc");
    var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlCategoryList").value;
    var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_chkParentCategoryAlloc");
    if (ddl == 0) {
        chkbox.checked = false;
        div.style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_rdCustomerNone").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedCustomer").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedAll").disabled = false;
        $find("ctl00_ContentPlaceHolder1_lstStatus").set_enabled(true);
    }
    else {
        if (mode == "add") {
            div.style.display = "block";
            chkbox.checked = true;
            CheckboxParentCategory();
        }
        else {
            div.style.display = "none";
            chkbox.checked = false;
        }
    }
}

function CheckboxParentCategory() {
    var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_chkParentCategoryAlloc");
    var listbox = $find("ctl00_ContentPlaceHolder1_lstStatus");
    if (chkbox.checked) {
        document.getElementById("ctl00_ContentPlaceHolder1_rdCustomerNone").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedCustomer").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedAll").disabled = true;
        listbox.set_enabled(false);
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_rdCustomerNone").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedCustomer").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_rdSelectedAll").disabled = false;
        listbox.set_enabled(true);
    }
}

function CheckAll_ACC(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('chkACC_1') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('chkAll_ACC_1') != -1) e.checked = ChkState;
    }
}

function CheckAll_SCC(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('chkSCC_2') != -1) e.checked = ChkState;
        if (e.type == 'checkbox' && e.name.indexOf('chkAll_SCC_2') != -1) e.checked = ChkState;
    }
}

function CheckOne_CouponCode(value) {
    var Counter = 0;
    var frm = '';

    var frm = document.forms[0];
    if (value == "move") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkACC_1') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }
    else if (value == "remove") {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkSCC_2') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    if (Number(Counter) == 0) {
        if (value == "move") {
            alert("Please check atleast one 'row' to Move");
        }
        else if (value == "remove") {
            alert("Please check atleast one 'row' to Remove");
        }
        return false;
    }
    else {
        return true;
    }
}

function CheckChanged_CouponCode(value) {
    var frm = '';

    frm = document.forms[0];
    if (value == "move") {
        var boolAllChecked; boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkACC_1') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkAll_ACC_1') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }
    else if (value == "remove") {
        var boolAllChecked; boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkSCC_2') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkAll_SCC_2') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }

}

function getFinalVaules_SubAdditionOptions() {
    var frm = '';
    frm = document.getElementById("AllocationID_GridAllocatedSubAdditionalOptions").getElementsByTagName("input");
    var i = 1;
    var WebOtherCostID = '';
    var IDs = '';
    for (l = 0; l < frm.length; l++) {
        if (frm[l].id.indexOf('Id') != -1) {
            if (frm[l].type == "checkbox") {
                if ((frm[l].id).indexOf("Id_2") > -1) {
                    var rowinputs = frm;
                    WebOtherCostID = frm[l].value;
                    IDs = IDs + frm[l].value + ",";
                }
            }
        }
    }
    document.getElementById("AllocationID_hdn_WebOtherCostIDs").value = IDs;
}

var ret = 0;
var IsStockExist = true;
function addstockonsave(id, drawStockFrom) {
    Sys.Application.add_load(function () {
        if (parseInt(id) != 0) {
            ret = id;
            var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&managestock=yes&id=" + id, 1000, 500);
            SetRadWindow_Ver2('div_stockpopupnew', 'divBackGroundNew');
            Rad1Customer.setSize(1330, 520);
            Rad1Customer.center();
            Rad1Customer.add_close(redirectpage);
            var PID = id;
            $(".rwCloseButton").click(function () {
                asyncState = false;
                AutoFill.Check_ProductCatalogue_ISStockExist(CompanyID, PID, IsStockExistForProduct);
                if (IsStockExist == false) {
                    if (drawStockFrom == 's') {
                        alert("You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.");
                        AutoFill.DefaultProductStock_Self_Insert(CompanyID, PID, sucsucsuc);
                    }
                    else {
                        alert("You need to save and manage stock and complete the stock settings before you can save this product.");
                    }
                }
                PID = 0;
            });
            id = '0';
        }
    });
}

function sucsucsuc() {

}

function IsStockExistForProduct(Result_IsStockExist) {
    IsStockExist = Result_IsStockExist;
}


function calculateNewMarkup(obj, index, type) {

    var txtCost = document.getElementById("txtCost_" + index + "");
    var txtMarkup = document.getElementById("txtMarkup_" + index + "");
    var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");

    if (Number(txtCost.value) != 0 && Number(txtSellingPrice.value) == 0) {
        txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, -100, 6, '', false, false, false);
    } else if (Number(txtCost.value) != 0 && Number(txtSellingPrice.value) != 0) {
        var MarkupValue = Number(Number(txtSellingPrice.value) - Number(txtCost.value)) / Number(txtCost.value);
        MarkupValue = Number(MarkupValue) * 100;

        //calculating the sell Price using New Mark up:
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 6))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(txtSellingPrice.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
    } else if (Number(txtCost.value) == 0) {
        txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 6, '', false, false, false);
    } 

}