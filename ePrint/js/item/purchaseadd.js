// JScript File

//To add new contact for that particular supplier
function add_contact() {
    if (txtName.value == "") {
        ddlContactID.length = 0;
        alert("Please select the supplier to proceed...");
        //return false;
    }
    //    else if(hid_ClientID.value =='' || hid_ClientID.value ==0)
    //    {
    //        alert("Please select the supplier to proceed...");
    //        //return false;
    //    }
    else {
        //        if (hid_Suppname.value != txtName.value) {
        //            alert("Please select the supplier to proceed...");
        //            //return false;
        //        }
        //        else {
        if (pgmode == "edit") {
            //PopupCenter(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + PurchaseID.value, '1000', '500');
            window.radopen(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + PurchaseID, null, '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            // PopupCenter(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode, '1000', '500');
            window.radopen(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + PurchaseID + "&IsAddMode=yes", null, '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        //return true;
        // }
    }
}


function Check_contact() {
    debugger
    var ddlContact = ddlContactID.length;
    if (ddlContact == '') {
        return true;
    } else if (ddlContactID.options[ddlContactID.selectedIndex].value == 0) {
        return true;
    }
    return false;
}


//To select address
function more_address() {

    if (txtName.value == "") {
        alert("Please select the supplier to proceed...");
        return false;
    }
    else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
        alert("Please select the supplier to proceed...");
        return false;
    }
    else if (hid_Suppname.value != txtName.value) {
        alert("Please select the supplier to proceed...");
        return false;
    }
    else {
        // PopupCenter(commonpath + "common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400');
        window.radopen(commonpath + "common/common_popup.aspx?type=moreaddress&addresstype=Contact&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes", null, '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return true;
    }
}


function popup_phrasebook(type) {
    //  PopupCenter(commonpath + "common/phrase_book.aspx?type=" + type, '800', '400');
    window.radopen(commonpath + "common/phrase_book.aspx?type=" + type, null, '1000', '500');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function AddMoreItem(ItemID, ItemCode, ItemName, Qty, PackedIn, Price, ItemType, IsDisplay, PerQty, PerPrice, PackedPrice, StockType, SalesTaxRate, ReceivedQty, PurchaseACcodeID) {
    var isother = isOther;
    // alert(isOther);
    //*** new code to generate row from 1st row ***//
    //add a row to the rows collection and get a reference to the newly added row
    // alert(ItemName);
    spn_tblHeader.style.display = "none";
    var newRow = document.all("tblHeader").insertRow(rowNo);

    //add cells (<td>) to the new row and set the innerHTML to contain text boxes                            
    var oCell = newRow.insertCell(0);
    oCell.style.verticalAlign = "top";
    oCell.innerHTML = "<input type='checkbox' name='chk" + rowNo + "' id='chk" + rowNo + "' value='0' /><label name='lblItemType" + rowNo + "' id='lblItemType" + rowNo + "' class='normalText' style='display:none'>" + ItemType + "</label><label name='lblItemID" + rowNo + "' id='lblItemID" + rowNo + "' class='normalText' style='display:none'>" + ItemID + "</label><label name='lblpackedprice" + rowNo + "' id='lblpackedprice" + rowNo + "' class='normalText' style='display:none'>" + PackedPrice + "</label><label name='lblstocktype" + rowNo + "' id='lblstocktype" + rowNo + "' class='normalText' style='display:none'>" + StockType + "</label>";

    oCell = newRow.insertCell(1);
    //oCell.innerHTML = "<input type='text' name='txtItemCode"+rowNo+"' id='txtItemCode"+rowNo+"' class='textboxnew' rows='3' style='width:100%' value='"+ItemCode+"'>";
    oCell.innerHTML = "<textarea name='txtItemCode" + rowNo + "' id='txtItemCode" + rowNo + "' class='textboxnew' maxlength='25' onkeydown='limitText(this,20);' onkeyup='limitText(this,20);' rows='6' style='width:100%'>" + ItemCode + "</textarea>";

    oCell = newRow.insertCell(2);
    oCell.innerHTML = "<textarea name='txtDescription" + rowNo + "' id='txtDescription" + rowNo + "' class='textboxnew' rows='6' style='width:100%'>" + ItemName + "</textarea>";

    oCell = newRow.insertCell(3);
    //oCell.innerHTML = "<input type='text' name='txtQty"+rowNo+"' id='txtQty"+rowNo+"' onblur='javascript:SetNumber(this,this.value)' maxlength='8' class='textboxnew' style='width:100%' value='"+Qty+"'>";CalculatePackedPrice(" + rowNo + "," + PackedIn + "," + Price + ");
    oCell.innerHTML = "<textarea name='txtQty" + rowNo + "' id='txtQty" + rowNo + "'MakePrice2Decimal(this,this.value);' maxlength='8' onchange='GetNewCalcValues(this.value," + rowNo + ");'  onkeydown='limitText(this,8);' onkeyup='limitText(this,8);'  onkeypress='javascript:return IntergerValidation(event);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Qty + "</textarea><label name='lblperqty" + rowNo + "' id='lblperqty" + rowNo + "' class='normalText' style='display:none'>" + PerQty + "</label><label name='lblperprice" + rowNo + "' id='lblperprice" + rowNo + "' class='normalText' style='display:none'>" + PerPrice + "</label>";
    //alert("hi");

    if (document.getElementById("txtQty" + rowNo).value == "0") {
        document.getElementById("txtQty" + rowNo).value = "";
    }
    oCell = newRow.insertCell(4);
    //oCell.innerHTML = "<input type='text' name='txtPackedIn"+rowNo+"' id='txtPackedIn"+rowNo+"' onblur='javascript:SetNumber(this,this.value)' maxlength='8' class='textboxnew' style='width:100%' value='"+PackedIn+"'>";CalculatePackedPrice(" + rowNo + ");
    oCell.innerHTML = "<textarea name='txtPackedIn" + rowNo + "' id='txtPackedIn" + rowNo + "'MakePrice2Decimal(this,this.value);'  maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);'  onkeypress='javascript:return IntergerValidation(event);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PackedIn, 0, '', false, false, true) + "</textarea>";

    if (Number(document.getElementById("txtPackedIn" + rowNo).value) == 0) {
        document.getElementById("txtPackedIn" + rowNo).value = "";
    }

    oCell = newRow.insertCell(5);
    //oCell.innerHTML = "<input type='text' name='txtPackPrice"+rowNo+"' id='txtPackPrice"+rowNo+"' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='12' class='textboxnew' style='width:100%' value='"+Price+"'>";CalculatePackedPrice(" + rowNo + ");
    oCell.innerHTML = "<textarea name='txtPackPrice" + rowNo + "' id='txtPackPrice" + rowNo + "' onblur='javascript:SetNumberWithMinus(this,this.value);MakePrice2Decimal(this,this.value);CalculateTotalTax();' maxlength='10' onkeydown='limitText(this,10);' onkeyup='limitText(this,10);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Price, 0, '', false, false, true) + "</textarea>";

    oCell = newRow.insertCell(6);
    oCell.style.verticalAlign = "top";
    oCell.innerHTML = "<select name='ddlTax" + rowNo + "' id='ddlTax" + rowNo + "' onchange='javascript:gettaxPercentage(this.value,this.id);CalculateTotalTax();' class='normalText' style='width:100%;'></select>";

    oCell = newRow.insertCell(7);
    //oCell.innerHTML = "<input type='text' name='txtTaxValue"+rowNo+"' id='txtTaxValue"+rowNo+"' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='12'  class='textboxnew' style='width:100%' value='0.00'>";
    //    var qs = getQueryStrings();
    //    var mode = qs["type"];
    //    if (mode == "edit") {
    oCell.innerHTML = "<textarea name='txtTaxValue" + rowNo + "' id='txtTaxValue" + rowNo + "' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);'  class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>0.00</textarea>";
    //    }
    //    else {
    //        oCell.innerHTML = "<textarea name='txtTaxValue" + rowNo + "' id='txtTaxValue" + rowNo + "' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);'  class='textboxnew' rows='6' style='width:100%;text-align: right'>0.00</textarea>";
    //    }
    //added by natraj
    if (AccountingCode == "e") {
        oCell = newRow.insertCell(8);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<select name='ddlACcode" + rowNo + "' id='ddlACcode" + rowNo + "' onchange='javascript:getACcode(this.value,this.id);' class='normalText' style='width:100%;'></select>";

        oCell = newRow.insertCell(9);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='6'  style='width:100%'></textarea>";

        oCell = newRow.insertCell(10);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='checkbox' name='chkIsPOCompleted" + rowNo + "' id='chkIsPOCompleted" + rowNo + "' value='0' />";
        if ((IsDisplay == '0') || (IsDisplay == '2')) {
            //do nothing
        }
        else {
            oCell = newRow.insertCell(11);
            oCell.style.verticalAlign = "top";
            //oCell.style.textAlign = "center";
            if (ItemType == "W") {
                oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />" + "<input style='display:none;' type='text' name='txt_ProductType" + rowNo + "' id='txt_ProductType" + rowNo + "' value='" + hdnDrawStockFrom.value + "' />" + "<input style='display:none;' type='text' name='txt_AdditionalID" + rowNo + "' id='txt_AdditionalID" + rowNo + "' value='" + hdnAdditionalID.value + "' />" + "<input style='display:none;' type='text' name='txt_OnlyItemTitle" + rowNo + "' id='txt_OnlyItemTitle" + rowNo + "' value='" + hdnOnlyItemTitle.value + "' />";
            }
            else {
                oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />";
            }
        }
        if ((IsDisplay == '0') || (IsDisplay == '2')) {
            //do nothing
            oCell = newRow.insertCell(11);
            oCell.innerHTML = "<textarea name='txtReceivedQty" + rowNo + "' id='txtReceivedQty" + rowNo + "' class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>" + ReceivedQty + "</textarea>";

        }
        else {
            oCell = newRow.insertCell(12);
            oCell.innerHTML = "<textarea name='txtReceivedQty" + rowNo + "' id='txtReceivedQty" + rowNo + "' class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>" + ReceivedQty + "</textarea>";
        }
    }
    else {
        oCell = newRow.insertCell(8);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='6'  style='width:100%'></textarea>";

        oCell = newRow.insertCell(9);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='checkbox' name='chkIsPOCompleted" + rowNo + "' id='chkIsPOCompleted" + rowNo + "' value='0' />";
        if (isOther == 1) {

            if ((IsDisplay == '0') || (IsDisplay == '2')) {
                //do nothing
            }
            else {
                oCell = newRow.insertCell(10);
                oCell.style.verticalAlign = "top";
                //oCell.style.textAlign = "center";
                if (ItemType == "W") {
                    oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />" + "<input style='display:none;' type='text' name='txt_ProductType" + rowNo + "' id='txt_ProductType" + rowNo + "' value='" + hdnDrawStockFrom.value + "' />" + "<input style='display:none;' type='text' name='txt_AdditionalID" + rowNo + "' id='txt_AdditionalID" + rowNo + "' value='" + hdnAdditionalID.value + "' />" + "<input style='display:none;' type='text' name='txt_OnlyItemTitle" + rowNo + "' id='txt_OnlyItemTitle" + rowNo + "' value='" + hdnOnlyItemTitle.value + "' />";
                }
                else {
                    oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />";
                }
            }
        }
        if ((IsDisplay == '0') || (IsDisplay == '2')) {
            oCell = newRow.insertCell(10);
            oCell.innerHTML = "<textarea name='txtReceivedQty" + rowNo + "' id='txtReceivedQty" + rowNo + "' class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>" + ReceivedQty + "</textarea>";

        }
        else {
            oCell = newRow.insertCell(11);
            oCell.innerHTML = "<textarea name='txtReceivedQty" + rowNo + "' id='txtReceivedQty" + rowNo + "' class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>" + ReceivedQty + "</textarea>";
        }
    }
    //modification by Bilal stage 3
    // oCell = newRow.insertCell(11);
    //oCell.innerHTML = "<textarea name='txtReceivedQty" + rowNo + "' id='txtReceivedQty" + rowNo + "' class='textboxnew' rows='6' style='width:100%;text-align: right' disabled>" + ReceivedQty + "</textarea>";
    rowNo = rowNo + 1;
    //** End **//

    //*** To Bind Accounting Code to ddlAC Code****//
    var ddlACcode;
    debugger
    for (var i = 1; i < table.rows.length; i++) {
        if (AccountingCode == "e") {
            ddlACcode = document.getElementById("ddlACcode" + i);
        }
    }
    var str_ac = hid_ACcode.value.split('µ');
    var DefaultACcodeID = 0;
    for (var i = 0; i < str_ac.length; i++) {
        if (trim12(str_ac[i]) != '') {
            var str_ac1 = str_ac[i].split('¶'); //ALT+0182 
            var AccountingCodeID = str_ac1[0];
            var CodeName = str_ac1[1];
            var IsDefaultCode = str_ac1[2];
            if (str_ac1[i] != '') {
                if (AccountingCode == "e") {
                    ddlACcode.options.add(new Option(CodeName, AccountingCodeID, i));

                    if (IsDefaultCode == "True") {
                        DefaultACcodeID = AccountingCodeID;

                    }
                }
            }
        }
    }
    if (PurchaseACcodeID != 0 && PurchaseACcodeID != 'undefined' && PurchaseACcodeID != undefined) {
        var SelectedIndex = 0;
        if (ddlACcode.value = PurchaseACcodeID) {
            SelectedIndex = ddlACcode.selectedIndex;
        }
        ddlACcode.selectedIndex = SelectedIndex;
    }

    else if (DefaultACcodeID != 0) {
        var SelectedIndex = 0;
        if (ddlACcode.value = DefaultACcodeID) {
            SelectedIndex = ddlACcode.selectedIndex;
        }
        ddlACcode.selectedIndex = SelectedIndex;
    }
    //----- AC End ------//

    //***** To Bind Tax Rates to ddlTax ****//


    //var table = document.getElementById("tblHeader");  
    var ddlTax;
    for (var i = 1; i < table.rows.length; i++) {
        ddlTax = document.getElementById("ddlTax" + i);
    }
    var str_sp1 = (strTax.value).split('µ');
    var store_subcat = '';
    for (var i = 0; i < str_sp1.length; i++) {
        if (trim12(str_sp1[i]) != '') {
            var str_sp2 = str_sp1[i].split('¶');
            var TaxID = str_sp2[0];
            var TaxName = str_sp2[1];
            var TaxRate = str_sp2[2];
            if (str_sp2[i] != '') {
                ddlTax.options.add(new Option(SpecialDecode(TaxName), TaxID, i));
                ddlTax.selectedIndex = 0;
            }
        }
    }
    if (typeof SalesTaxRate != 'undefined' && SalesTaxRate != undefined && SalesTaxRate != null) {
        ddlTax.value = SalesTaxRate;
    } else {
        if (hid_DefaultTax != null) {
            if (hid_DefaultTax.value != 0) {
                var SelectedIndex = 0;
                if (ddlTax.value = hid_DefaultTax.value) {
                    SelectedIndex = ddlTax.selectedIndex;
                }
                ddlTax.selectedIndex = SelectedIndex;

            }
        }
    }
    JustCheck++;
    //**** End ****//
    CalculateTotalTax();
}

function CalculatePackedPrice(rowno, PackedInQty, PackPrice) {
    debugger;
    //alert(rowno);
    //alert(document.getElementById("lblItemID" + rowno).innerHTML);
    var itemid = document.getElementById("lblItemID" + rowno).innerHTML;
    if (itemid != "0") {
        var PerQty = document.getElementById("txtQty" + rowno + "").value;
        //var PackQty = document.getElementById("txtPackedIn" + rowno + "").value;
        // var PerPrice = document.getElementById("txtPackPrice" + rowno + "").value;

        var vaQty = (PerQty / PackedInQty);
        var totprice = Number(vaQty * PackPrice).toFixed(2);
        //if (!isNaN && isFinite) {
        document.getElementById("txtPackPrice" + rowno + "").value = totprice;
        //}
    }
}

function MakePrice2Decimal(txtObj, txtValue) {
    txtObj.value = roundNumber(txtValue, 2);
}

function gettaxPercentage(ddlValue, txtID) {
    decallowed = 2; //alert("ddlValue="+ddlValue+"txtID="+txtID);   
    txtPriceID = txtID.replace('ddlTax', 'txtPackPrice');
    txtTaxValueID = txtID.replace('ddlTax', 'txtTaxValue');

    //var strTax = document.getElementById('<%=hid_TaxValues.ClientID %>');
    var str_sp1 = strTax.value.split('µ');
    var store_subcat = '';
    for (var i = 0; i < str_sp1.length; i++) {
        var str_sp2 = str_sp1[i].split('¶');
        var TaxID = str_sp2[0];
        var TaxName = str_sp2[1];
        var TaxRate = str_sp2[2];
        if (str_sp2[i] != '') {
            //ddlTax.options.add(new Option(TaxName,TaxID,i));
            if (ddlValue == TaxID) {
                var txtTaxValueID = document.getElementById(txtTaxValueID);
                txtTaxValueID.value = (document.getElementById(txtPriceID).value * TaxRate) / 100;
                txtTaxValueID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtTaxValueID.value, 0, '', false, false, true); //roundNumber(txtTaxValueID.value, 2);

                //alert(txtTaxValueID.value);
                // var TaxValue = txtTaxValueID.value;

                //                if (TaxValue.indexOf('.') == -1) TaxValue += ".";
                //                dectext = TaxValue.substring(TaxValue.indexOf('.') + 1, TaxValue.length);
                //                if (dectext.length > decallowed) {
                //                    txtTaxValueID.value = TaxValue.substring(0, TaxValue.indexOf('.') + 3);
                //                    
                //                }
            }
        }
    }
}

//*** Func to DELETE ROWS *****//
function deleteRow(tableID) {
    try {
        //var hid_DeletedItemID = document.getElementById("<%=hid_DeletedItemID.ClientID %>");                             
        var table = document.getElementById(tableID);
        //alert(table);
        var count = 0;
        var rowCount = table.rows.length;
        //alert("before delete="+table.rows.length);
        if (tblHeaderID.rows.length == 2) {
            alert(Please_Add_Atleast_One_Item_To_Save_Purchase);
        }
        else {
            if (takeCount == 0) {
                takeCount = rowCount;
            }
            var chkchecked = '';
            for (var i = 1; i < rowCount; i++) {
                var row = table.rows[i];
                var chkbox = row.cells[0].childNodes[0];
                if (chkbox.checked) {
                    chkchecked = 'yes';
                    count++;
                }
                else {
                    chkchecked = 'no';
                }
            }

            if (count == rowCount - 1) {
                alert(Please_Add_Atleast_One_Item_To_Save_Purchase);
                takeCount = 0;
                return false;
            }

            else if (count == 0) {
                alert('Please check at least one row to delete');
            }

            else {
                if (window.confirm(Delete_Confirmation_Alert)) {
                    for (var i = 1; i < rowCount; i++) {
                        var row = table.rows[i];
                        var chkbox = row.cells[0].childNodes[0];
                        if (null != chkbox && true == chkbox.checked) {
                            hid_DeletedItemID.value += chkbox.value + "µ";
                            table.deleteRow(i);
                            rowCount--;
                            i--;
                            rowNo--;
                            chkchecked = 'yes';
                        }
                    }
                }
                else {
                    return false;
                }
            }




        }
        CalculateTotalTax();
    } catch (e) {
        alert(e);
    }
}

//*** END of Func to DELETE ROWS *****//
function CalculateTotalTax() {
    var total_exctax = 0.00;
    var total_inctax = 0.00;

    //var table    = document.getElementById("tblHeader");  
    var totrows = table.rows.length;

    if (totrows == 0) {
        lblTotalExcTax.innerHTML = "0.00";
        lblTotalIncTax.innerHTML = "0.00";
    }
    else {
        for (var i = 0; i < JustCheck; i++) {

            if (document.getElementById("txtPackPrice" + i) != null) {
                var tblPrice = document.getElementById("txtPackPrice" + i).value;
                var tblTax = document.getElementById("ddlTax" + i);
                var tblTaxID = '0';
                if (tblTax.options[tblTax.selectedIndex] != undefined && tblTax.options[tblTax.selectedIndex] != null) {
                    tblTaxID = tblTax.options[tblTax.options.selectedIndex].value;
                }
                decallowed = 2;
                //to calculate total tax//  
                //alert(tblTax.id);                                       

                gettaxPercentage(tblTaxID, tblTax.id);
                var tblTaxValue = document.getElementById("txtTaxValue" + i).value;

                //total exc TAX //                                                                             
                total_exctax = Number(total_exctax) + Number(tblPrice);
                //total_exctax = roundNumber(total_exctax, 2);
                total_exctax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total_exctax, 0, '', false, false, true);
                if (!isNaN(total_exctax)) {
                    lblTotalExcTax.innerHTML = total_exctax;

                    var exctaxvalue = lblTotalExcTax.innerHTML;
                    exctaxvalue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, exctaxvalue, 0, '', false, false, true);
                    //alert('exctaxvalue' + exctaxvalue);
                    //                    if (exctaxvalue.indexOf('.') == -1) exctaxvalue += ".";
                    //                    dectext = exctaxvalue.substring(exctaxvalue.indexOf('.') + 1, exctaxvalue.length);
                    //                    if (dectext.length > decallowed) {
                    //                        lblTotalExcTax.innerHTML = exctaxvalue.substring(0, exctaxvalue.indexOf('.') + 3);
                    //                    }
                }
                //Total inc TAX //
                //gettaxPercentage(tblTaxID,tblTax.id);
                if (Number(tblPrice) == 0) {
                    tblTaxValue = "0.00";
                }
                //tblTaxValue = roundNumber(tblTaxValue, 2);
                tblTaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, tblTaxValue, 0, '', false, false, true);
                total_inctax = Number(total_inctax) + Number(tblTaxValue);
                //total_inctax = roundNumber(total_inctax, 2);
                total_inctax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total_inctax, 0, '', false, false, true);

                if (!isNaN(total_inctax)) {
                    finaltotal_inctax = Number(total_inctax) + Number(total_exctax);
                    //finaltotal_inctax = roundNumber(finaltotal_inctax, 2);
                    finaltotal_inctax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finaltotal_inctax, 0, '', false, false, true);
                }
                if (!isNaN(finaltotal_inctax)) {
                    lblTotalIncTax.innerHTML = finaltotal_inctax;

                    var incltaxvalue = lblTotalIncTax.innerHTML;
                    //alert(incltaxvalue);
                    incltaxvalue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, incltaxvalue, 0, '', false, false, true);
                    //                    if (incltaxvalue.indexOf('.') == -1) incltaxvalue += ".";
                    //                    dectext = incltaxvalue.substring(incltaxvalue.indexOf('.') + 1, incltaxvalue.length);
                    //                    if (dectext.length > decallowed) {
                    //                        lblTotalIncTax.innerHTML = incltaxvalue.substring(0, incltaxvalue.indexOf('.') + 3);
                    //                    }
                }
            }
        }
    }
}
//        //*** END OF Func to CALCULATE TOTAL TAX *****//


var chkcount = 0;
var takeCount = 0;
var SuccretPID = 0;
var SuccretPItemID = 0;
var ISReplenishmnetItemExists = 0;

function getItemValues(tableID, clk, val, path)//(ItemID,ItemCode,ItemName,Qty,PackedIn,Price,ItemType)
{
    debugger
    var isWH_ProductIncluded = false;
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    var ItemValuesConcat = "";
    var StockDetails = "";
    var IDs = "";
    var PurchaseItemIDs = "";
    //  if (chkcount == 0)
    //  {
    if (takeCount != 0) {
        rowCount = takeCount;
    }


    var DeliveryAddressID = 0;
    var DeliveryAddressType = '';
    if (document.getElementById('ctl00_ContentPlaceHolder1_hdn_deliveryAddressType').value == "" && document.getElementById('ctl00_ContentPlaceHolder1_hdn_deliveryAddressType').values == "0") {
        DeliveryAddressID = 0;

        DeliveryAddressType = "R";
    }
    else {
        if (document.getElementById('ctl00_ContentPlaceHolder1_hdn_deliveryAddressID').value != "") {
            DeliveryAddressID = document.getElementById('ctl00_ContentPlaceHolder1_hdn_deliveryAddressID').value;
            DeliveryAddressType = document.getElementById('ctl00_ContentPlaceHolder1_hdn_deliveryAddressType').value;
            if (DeliveryAddressType == "delivery") {
                DeliveryAddressType = "c";
            }
        }
        else {
            DeliveryAddressID = 0;

            DeliveryAddressType = "R";
        }
    }

    var hid_ClientID = document.getElementById('ctl00_ContentPlaceHolder1_hid_ClientID');
    if (typeof hid_ClientID != 'undefined' && hid_ClientID != undefined && hid_ClientID != null) {
        hid_ClientID = hid_ClientID.value;
    } else {
        hid_ClientID = '0';
    }
    var hid_ContactID = document.getElementById('ctl00_ContentPlaceHolder1_hid_ContactID');
    if (typeof hid_ContactID != 'undefined' && hid_ContactID != undefined && hid_ContactID != null) {
        hid_ContactID = hid_ContactID.value;
    } else {
        hid_ContactID = '0';
    }
    var hdnAddressID = document.getElementById('ctl00_ContentPlaceHolder1_hdnAddressID');
    if (typeof hdnAddressID != 'undefined' && hdnAddressID != undefined && hdnAddressID != null) {
        hdnAddressID = hdnAddressID.value;
    } else {
        hdnAddressID = '0';
    }
    var txtComments = document.getElementById('ctl00_ContentPlaceHolder1_txtComments');
    if (typeof txtComments != 'undefined' && txtComments != undefined && txtComments != null) {
        txtComments = txtComments.value;
    } else {
        txtComments = '';
    }
    var hid_FootNote = document.getElementById('ctl00_ContentPlaceHolder1_hid_FootNote');
    if (typeof hid_FootNote != 'undefined' && hid_FootNote != undefined && hid_FootNote != null) {
        hid_FootNote = hid_FootNote.value;
    } else {
        hid_FootNote = '';
    }
    var lblPONo = document.getElementById('ctl00_ContentPlaceHolder1_lblPONo');
    if (typeof lblPONo != 'undefined' && lblPONo != undefined && lblPONo != null) {
        lblPONo = lblPONo.innerText;
    } else {
        lblPONo = '';
    }
    var txtDate = document.getElementById('ctl00_ContentPlaceHolder1_txtDate');
    if (typeof txtDate != 'undefined' && txtDate != undefined && txtDate != null) {
        txtDate = txtDate.value;
    } else {
        txtDate = '0';
    }
    var txtRefNo = document.getElementById('ctl00_ContentPlaceHolder1_txtRefNo');
    if (typeof txtRefNo != 'undefined' && txtRefNo != undefined && txtRefNo != null) {
        txtRefNo = txtRefNo.value;
    } else {
        txtRefNo = '';
    }
    var txtSuppQuote = document.getElementById('ctl00_ContentPlaceHolder1_txtSuppQuote');
    if (typeof txtSuppQuote != 'undefined' && txtSuppQuote != undefined && txtSuppQuote != null) {
        txtSuppQuote = txtSuppQuote.value;
    } else {
        txtSuppQuote = '';
    }
    var txtSuppInv = document.getElementById('ctl00_ContentPlaceHolder1_txtSuppInv');
    if (typeof txtSuppInv != 'undefined' && txtSuppInv != undefined && txtSuppInv != null) {
        txtSuppInv = txtSuppInv.value;
    } else {
        txtSuppInv = '';
    }
    var ddlRaisedBy = document.getElementById('ctl00_ContentPlaceHolder1_ddlRaisedBy');
    if (typeof ddlRaisedBy != 'undefined' && ddlRaisedBy != undefined && ddlRaisedBy != null) {
        ddlRaisedBy = ddlRaisedBy.value;
    } else {
        ddlRaisedBy = '0';
    }
    var txtReqDate = document.getElementById('ctl00_ContentPlaceHolder1_txtReqDate');
    if (typeof txtReqDate != 'undefined' && txtReqDate != undefined && txtReqDate != null) {
        txtReqDate = txtReqDate.value;
    } else {
        txtReqDate = '';
    }
    var ddlStatus = document.getElementById('ctl00_ContentPlaceHolder1_ddlStatus');
    if (typeof ddlStatus != 'undefined' && ddlStatus != undefined && ddlStatus != null) {
        ddlStatus = ddlStatus.value;
    } else {
        ddlStatus = '0';
    }
    var chkGoodsReceived = document.getElementById('ctl00_ContentPlaceHolder1_chkGoodsReceived');
    if (typeof chkGoodsReceived != 'undefined' && chkGoodsReceived != undefined && chkGoodsReceived != null) {
        chkGoodsReceived = chkGoodsReceived.checked;
    } else {
        chkGoodsReceived = false;
    }
    var chkInvoiceReceived = document.getElementById('ctl00_ContentPlaceHolder1_chkInvoiceReceived');
    if (typeof chkInvoiceReceived != 'undefined' && chkInvoiceReceived != undefined && chkInvoiceReceived != null) {
        chkInvoiceReceived = chkInvoiceReceived.checked;
    } else {
        chkInvoiceReceived = false;
    }
    var hid_AddressType = document.getElementById('ctl00_ContentPlaceHolder1_hid_AddressType');
    if (typeof hid_AddressType != 'undefined' && hid_AddressType != undefined && hid_AddressType != null) {
        hid_AddressType = hid_AddressType.value;
    } else {
        hid_AddressType = '';
    }
    var hid_HeaderText = document.getElementById('ctl00_ContentPlaceHolder1_hid_HeaderText');
    if (typeof hid_HeaderText != 'undefined' && hid_HeaderText != undefined && hid_HeaderText != null) {
        hid_HeaderText = hid_HeaderText.value;
    } else {
        hid_HeaderText = '';
    }
    var hdn_supplierID = document.getElementById('ctl00_ContentPlaceHolder1_hdn_supplierID');
    if (typeof hdn_supplierID != 'undefined' && hdn_supplierID != undefined && hdn_supplierID != null) {
        hdn_supplierID = hdn_supplierID.value;
    } else {
        hdn_supplierID = '0';
    }
    var txtSuppInvDate = document.getElementById('ctl00_ContentPlaceHolder1_txtSuppInvDate');
    if (typeof txtSuppInvDate != 'undefined' && txtSuppInvDate != undefined && txtSuppInvDate != null) {
        txtSuppInvDate = txtSuppInvDate.value;
    } else {
        txtSuppInvDate = '';
    }
    var hdnTaskID = document.getElementById("ctl00_header1_hdnTaskID");
    if (typeof hdnTaskID != 'undefined' && hdnTaskID != undefined && hdnTaskID != null) {
        hdnTaskID = hdnTaskID.value;
    } else {
        hdnTaskID = '0';
    }
    var chk_FollowupTask = document.getElementById("ctl00_ContentPlaceHolder1_chk_FollowupTask");
    if (typeof chk_FollowupTask != 'undefined' && chk_FollowupTask != undefined && chk_FollowupTask != null) {
        chk_FollowupTask = chk_FollowupTask.value;
    } else {
        chk_FollowupTask = false;
    }
    var hidFollowupTask = document.getElementById("ctl00_ContentPlaceHolder1_hidFollowupTask");
    if (typeof hidFollowupTask != 'undefined' && hidFollowupTask != undefined && hidFollowupTask != null) {
        hidFollowupTask = hidFollowupTask.value;
    } else {
        hidFollowupTask = '';
    }

    if (Date_Format == "dd/mm/yyyy") {
        var strdate = txtDate.split('/');
        txtDate = strdate[1] + "/" + strdate[0] + "/" + strdate[2];
        var strreqdate = txtReqDate.split('/');
        txtReqDate = strreqdate[1] + "/" + strreqdate[0] + "/" + strreqdate[2];

        if (txtSuppInvDate.length == 0) {
            txtSuppInvDate = "1/1/1900";
        }

        var strSuppInvDate = txtSuppInvDate.split('/');
        txtSuppInvDate = strSuppInvDate[1] + "/" + strSuppInvDate[0] + "/" + strSuppInvDate[2];
    }
    if (Date_Format == "mm/dd/yyyy") {
        var date = txtDate.split(' ');
        txtDate = date[0];

        var reqdate = txtReqDate.split(' ');
        txtReqDate = reqdate[0];

        if (txtSuppInvDate.length == 0) {
            txtSuppInvDate = "1/1/1900";
        }

        var SuppInvDate = txtSuppInvDate.split(' ');
        txtSuppInvDate = SuppInvDate[0];
    }
    asyncState = false;
    AutoFill.purchase_insert(ReplenishPurchaseID, CompanyID, hid_ClientID, hid_ContactID, hdnAddressID, txtComments, hid_FootNote, lblPONo,
        txtDate, txtRefNo, txtSuppQuote, txtSuppInv, ddlRaisedBy, txtReqDate, chkGoodsReceived, chkInvoiceReceived, ddlStatus, UserID,
        POCODE, hid_AddressType, PurEstimateID, hid_HeaderText, DeliveryAddressID, DeliveryAddressType, hdn_supplierID, txtSuppInvDate,
        chk_FollowupTask, hidFollowupTask, Date_Format, pgmode, EstimateID, hdnTaskID, PurchaseInsertSuccess);


    if (SuccretPID != 0) {
        if (typeof hid_DeletedItemID.value != 'undefined' && hid_DeletedItemID.value != undefined && hid_DeletedItemID.value != null && hid_DeletedItemID.value != '') {
            var DelItemID = hid_DeletedItemID.value.split('µ');
            for (var k = 0; k < DelItemID.length - 1; k++) {
                AutoFill.purchaseitem_delete(CompanyID, DelItemID[k], SuccretPID);
            }
        }
    }

    for (var i = 1; i < rowCount; i++) {
        if (document.getElementById("chk" + i) != null) {
            var tblPurchaseItemID = document.getElementById("chk" + i).value;
            var tblItemID = document.getElementById("lblItemID" + i).innerHTML;
            var tblItemType = document.getElementById("lblItemType" + i).innerHTML;
            var tblItemCode = document.getElementById("txtItemCode" + i).value;
            var tblItemDesc = document.getElementById("txtDescription" + i).value;
            // alert(tblItemDesc);
            var tblQty = document.getElementById("txtQty" + i).value;
            if (typeof tblQty != undefined && tblQty != undefined && tblQty != null) {
                if (tblQty == '') {
                    tblQty = '0';
                }
            }
            var tblPackedIn = document.getElementById("txtPackedIn" + i).value;
            if (typeof tblPackedIn != undefined && tblPackedIn != undefined && tblPackedIn != null) {
                if (tblPackedIn == '') {
                    tblPackedIn = '0';
                }
            }
            var tblPrice = document.getElementById("txtPackPrice" + i).value;
            if (typeof tblPrice != undefined && tblPrice != undefined && tblPrice != null) {
                if (tblPrice == '') {
                    tblPrice = '0';
                }
            }
            var tblTax = document.getElementById("ddlTax" + i);
            var tblTaxID = '0';
            if (tblTax.options[tblTax.selectedIndex] != undefined && tblTax.options[tblTax.selectedIndex] != null) {
                tblTaxID = tblTax.options[tblTax.selectedIndex].value;
            }
            var tblTaxValue = document.getElementById("txtTaxValue" + i).value;
            if (AccountingCode == "e") {
                var tblACcode = document.getElementById("ddlACcode" + i);
                if (tblACcode.value != '') {
                    var tblACcodeID = tblACcode.options[tblACcode.selectedIndex].value
                }
                else {
                    var tblACcodeID = "0";
                }
            }
            else {
                var tblACcodeID = "0";
            }

            var tblNotes = document.getElementById("txtNotes" + i).value;
            var tblGoodsReceived;
            var IsCompleted = document.getElementById("chkIsPOCompleted" + i).checked;
            if (val == "0" || val == "2") {
                tblGoodsReceived = false;
            }
            else {
                tblGoodsReceived = document.getElementById("chkIsGoodsReceived" + i).checked;
            }
            //var tblGoodsReceived = false; 

            if (tblItemType == '') {
                tblItemType = "A";
            }

            ItemValuesConcat += "PurchaseItemID" + "»" + tblPurchaseItemID + "±" + "ItemID" + "»" + tblItemID + "±" +
                "ItemType" + "»" + tblItemType + "±" + "ItemCode" + "»" + tblItemCode + "±" +
                "ItemDesc" + "»" + tblItemDesc + "±" + "ItemQty" + "»" + tblQty + "±" +
                "PackedIn" + "»" + tblPackedIn + "±" + "PackedPrice" + "»" + tblPrice + "±" +
                "Tax" + "»" + tblTaxID + "±" + "TaxValue" + "»" + tblTaxValue + "±" + "AccountCodeID" + "»" + tblACcodeID + "±" +
                "Notes" + "»" + tblNotes + "±" + "GoodsReceived" + "»" + tblGoodsReceived + "µ";



            var txt_ProductType = document.getElementById("txt_ProductType" + i);
            if (typeof txt_ProductType != 'undefined' && txt_ProductType != undefined && txt_ProductType != null) {
                txt_ProductType = txt_ProductType.value;
            } else {
                txt_ProductType = '';
            }
            var txt_AdditionalID = document.getElementById("txt_AdditionalID" + i);
            if (typeof txt_AdditionalID != 'undefined' && txt_AdditionalID != undefined && txt_AdditionalID != null) {
                txt_AdditionalID = txt_AdditionalID.value;
            } else {
                txt_AdditionalID = '';
            }
            var txt_OnlyItemTitle = document.getElementById("txt_OnlyItemTitle" + i);
            if (typeof txt_OnlyItemTitle != 'undefined' && txt_OnlyItemTitle != undefined && txt_OnlyItemTitle != null) {
                txt_OnlyItemTitle = txt_OnlyItemTitle.value;
            } else {
                txt_OnlyItemTitle = '';
            }

            if (tblItemType == "W") {
                ItemValuesConcat = ItemValuesConcat.substring(0, ItemValuesConcat.length - 1);
                ItemValuesConcat = ItemValuesConcat + "±" + "DrawStockFrom" + "»" + txt_ProductType + "±" + "AdditionalOptionDetails" + "»" + txt_AdditionalID + "µ";

                if ((txt_ProductType == "S") && tblGoodsReceived == true) {
                    //if (txt_ProductType == "S") {
                    isWH_ProductIncluded = true;

                    StockDetails += "PurchaseItemID" + "»" + tblPurchaseItemID + "±" + "ItemID" + "»" + tblItemID + "±" +
                        "ItemType" + "»" + tblItemType + "±" + "ItemCode" + "»" + tblItemCode + "±" +
                        "ItemDesc" + "»" + tblItemDesc + "±" + "ItemQty" + "»" + tblQty + "±" +
                        "PackedIn" + "»" + tblPackedIn + "±" + "PackedPrice" + "»" + tblPrice + "±" +
                        "Tax" + "»" + tblTaxID + "±" + "TaxValue" + "»" + tblTaxValue + "±" + "AccountCodeID" + "»" + tblACcodeID + "±" +
                        "Notes" + "»" + tblNotes + "±" + "GoodsReceived" + "»" + tblGoodsReceived + "±" + "DrawStockFrom" + "»" + txt_ProductType +
                        "±" + "AdditionalID" + "»" + txt_AdditionalID + "±" + "OnlyItemTitle" + "»" + txt_OnlyItemTitle + "µ";

                    IDs += tblItemID + "■";
                    PurchaseItemIDs += tblPurchaseItemID + "■";
                }
            }

            AutoFill.purchaseitem_insert_new(CompanyID, tblPurchaseItemID, SuccretPID, tblItemID, tblItemType, tblItemCode,
                tblItemDesc, tblQty, tblPackedIn, tblPrice, tblTaxID, tblTaxValue, tblACcodeID, tblNotes, tblGoodsReceived, '0',
                txt_AdditionalID, IsCompleted, PurchaseItemInsertSuccess);
            document.getElementById("chk" + i).value = SuccretPItemID;
        }
    }
    IDs = IDs.substring(0, IDs.length - 1);
    PurchaseItemIDs = PurchaseItemIDs.substring(0, PurchaseItemIDs.length - 1);
    hid_ItemValues.value = ItemValuesConcat;
    hdn_StockDetails.value = StockDetails;
    hdn_IDs.value = IDs;
    hdn_PurchaseItemIDs.value = PurchaseItemIDs;
    //  }                            
    chkcount = 1;

    if (isWH_ProductIncluded) {
        AutoFill.ISReplenishmnetItemExists(CompanyID, SuccretPID, 0, 'purchase', ISReplenishmnetPossible);
        if (ISReplenishmnetItemExists) {
            if (parseInt(SuccretPID) != 0) {
                var hdnjobId = $("[id$='hdn_JobId']").val();
                var qryStringJobId = "&jID=" + hdnjobId;
                var Invntry_popup = window.radopen(commonpath + "common/Common_ReplenishItemAllocation.aspx?IsFrom=purchase&ReplenishPurchaseID=" + SuccretPID + "&SaveType=" + clk + qryStringJobId);
                Invntry_popup.setSize(1300, 535);
                SetRadWindow_Ver2('Div_Invntry', 'divBackGroundNew');
                //Invntry_popup.set_behaviors(76); --> It will disable the moveing functionality of the window
                //$('.rwControlButtons').hide(); --> hides the ControlButtons
                Invntry_popup.center();

                $(".rwCloseButton").click(function () {
                    alert("You have not replenished the stock.");
                    document.getElementById("divBackGroundNew").style.display = "block";
                    document.getElementById("div_Load_Purchase").style.display = "block";
                    window.location.href = path + 'purchase/purchase_add.aspx?type=edit&id=' + SuccretPID;
                });
            }
            return false;
        } else {
            return true;
        }
    }
    else {
        return true;
    }
}

function PurchaseInsertSuccess(SuccResultretPID) {
    SuccretPID = SuccResultretPID;
    hid_PurchaseID.value = SuccResultretPID;
}

function PurchaseItemInsertSuccess(SuccresultretPItemID) {
    SuccretPItemID = SuccresultretPItemID;
}

function ISReplenishmnetPossible(ISReplenish) {
    ISReplenishmnetItemExists = ISReplenish;
}

function getItemValues2(tableID)//(ItemID,ItemCode,ItemName,Qty,PackedIn,Price,ItemType)
{
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    var ItemValuesConcat = "";

    if (takeCount != 0) {
        rowCount = takeCount;
    }
    for (var i = 1; i < rowCount; i++) {
        if (document.getElementById("chk" + i) != null) {
            var tblPurchaseItemID = document.getElementById("chk" + i).value;
            var tblItemID = document.getElementById("lblItemID" + i).innerHTML;
            var tblItemType = document.getElementById("lblItemType" + i).innerHTML;
            var tblItemCode = document.getElementById("txtItemCode" + i).value;
            var tblItemDesc = document.getElementById("txtDescription" + i).value;
            var tblQty = document.getElementById("txtQty" + i).value;
            var tblPackedIn = document.getElementById("txtPackedIn" + i).value;
            var tblPrice = document.getElementById("txtPackPrice" + i).value;
            var tblTax = document.getElementById("ddlTax" + i);
            var tblTaxID = tblTax.options[tblTax.selectedIndex].value;
            var tblTaxValue = document.getElementById("txtTaxValue" + i).value;
            if (AccountingCode == "e") {
                var tblACcode = document.getElementById("ddlACcode" + i);
                if (tblACcode.value != '') {
                    var tblACcodeID = tblACcode.options[tblACcode.selectedIndex].value
                }
                else {
                    var tblACcodeID = "0";
                }
            }
            else {
                var tblACcodeID = "0";
            }

            var tblNotes = document.getElementById("txtNotes" + i).value;
            var tblGoodsReceived = document.getElementById("chkIsGoodsReceived" + i).checked;

            if (tblItemType == '') {
                tblItemType = "A";
            }
            ItemValuesConcat += "PurchaseItemID" + "»" + tblPurchaseItemID + "±" + "ItemID" + "»" + tblItemID + "±" +
                "ItemType" + "»" + tblItemType + "±" + "ItemCode" + "»" + tblItemCode + "±" +
                "ItemDesc" + "»" + tblItemDesc + "±" + "ItemQty" + "»" + tblQty + "±" +
                "PackedIn" + "»" + tblPackedIn + "±" + "PackedPrice" + "»" + tblPrice + "±" +
                "Tax" + "»" + tblTaxID + "±" + "TaxValue" + "»" + tblTaxValue + "±" + "AccountCodeID" + "»" + tblACcodeID + "±" +
                "Notes" + "»" + tblNotes + "±" + "GoodsReceived" + "»" + tblGoodsReceived + "µ";
            if (tblItemType == "W") {
                var txt_ProductType = document.getElementById("txt_ProductType" + i).value;
                var txt_AdditionalID = document.getElementById("txt_AdditionalID" + i).value;

                //if ((txt_ProductType == "S" || txt_ProductType == "A") && tblGoodsReceived == true) {
                ItemValuesConcat = ItemValuesConcat.substring(0, ItemValuesConcat.length - 1);
                ItemValuesConcat = ItemValuesConcat + "±" + "DrawStockFrom" + "»" + txt_ProductType + "±" + "AdditionalOptionDetails" + "»" + txt_AdditionalID + "µ";
                //}
            }
        }
    }
    hid_ItemValues.value = ItemValuesConcat;

    chkcount = 1;
    return true;
}

function MakeMask_Show_StockOnly(stocktype) {
    var w = 800; var h = 400;
    displayCommon_first('dstock_only', w, h);
    divbtn.style.display = "block";

    if (stocktype == "paper") {
        tblpaper.style.display = "block";
        tblink.style.display = "none";
        tblfilm.style.display = "none";
        tblplate.style.display = "none";
        tblsearch.style.display = "block";
        tblnote.style.display = "block";
        tdaddnew.style.display = "block";
        tdpaper.style.display = "block";
        tdfilm.style.display = "none";
        tdpaperheader.style.display = "block";
        tdinkheader.style.display = "none";
        tdfilmheader.style.display = "none";
        tdplateheader.style.display = "none";
        tdbtnSupplier.style.display = "block";
    }
    else if (stocktype == "ink") {
        tblpaper.style.display = "none";
        tblink.style.display = "block";
        tblfilm.style.display = "none";
        tblplate.style.display = "none";
        tblsearch.style.display = "none";
        tblnote.style.display = "none";
        tdpaperheader.style.display = "none";
        tdinkheader.style.display = "block";
        tdfilmheader.style.display = "none";
        tdplateheader.style.display = "none";
        tdbtnSupplier.style.display = "none";
    }
    else if (stocktype == "film") {
        tblpaper.style.display = "none";
        tblink.style.display = "none";
        tblfilm.style.display = "block";
        tblplate.style.display = "none";
        tblsearch.style.display = "block";
        tblnote.style.display = "block";
        tdaddnew.style.display = "none";
        tdpaper.style.display = "none";
        tdfilm.style.display = "block";
        tdpaperheader.style.display = "none";
        tdinkheader.style.display = "none";
        tdfilmheader.style.display = "block";
        tdplateheader.style.display = "none";
        tdbtnSupplier.style.display = "block";
    }
    else if (stocktype == "plate") {
        tblpaper.style.display = "none";
        tblink.style.display = "none";
        tblfilm.style.display = "none";
        tblplate.style.display = "block";
        tblsearch.style.display = "block";
        tblnote.style.display = "block";
        tdaddnew.style.display = "none";
        tdpaper.style.display = "none";
        tdfilm.style.display = "block";
        tdpaperheader.style.display = "none";
        tdinkheader.style.display = "none";
        tdfilmheader.style.display = "none";
        tdplateheader.style.display = "block";
        tdbtnSupplier.style.display = "block";
    }
}

function load(val) {
    debugger;

    decallowed = 2;
    var strArr1 = str.value.split('µ');
    for (var i = 0; i <= strArr1.length - 1; i++) {
        var strArr2 = strArr1[i].split('±');
        if (strArr1[i] != '') {
            var PurchaseItemID = '';
            var ItemID = '>';
            var ItemCode = '';
            var ItemName = '';
            var Qty = '';
            var PackedIn = '';
            var Price = '';
            var ItemType = '';
            var Tax = '';
            var TaxValue = '';
            var AccountCodeID = '';
            var Notes = '';
            var GoodsReceived = '';
            var ReceivedQty = '';
            var PerQuantity = '';
            var MainCost = '';
            var MainPackedPrice = '';
            var StockType = '';
            var SalesTaxRate = '';
            var isCompleted = '';
            hdnDrawStockFrom.value = '';
            hdnOnlyItemTitle.value = '';
            hdnAdditionalID.value = '';

            for (var j = 0; j <= strArr2.length - 1; j++) {
                var strArr3 = strArr2[j].split('»');
                if (strArr3[0] == "PurchaseItemID") {
                    PurchaseItemID = strArr3[1];
                }
                else if (strArr3[0] == "ItemID") {
                    ItemID = strArr3[1];
                }
                else if (strArr3[0] == "ItemType") {
                    ItemType = strArr3[1];
                }
                else if (strArr3[0] == "ItemCode") {
                    ItemCode = strArr3[1];
                }
                else if (strArr3[0] == "ItemDesc") {
                    ItemName = strArr3[1];
                }
                else if (strArr3[0] == "ItemQty") {
                    ItemQty = strArr3[1];
                }
                else if (strArr3[0] == "PackedIn") {
                    PackedIn = strArr3[1];
                }
                else if (strArr3[0] == "PackedPrice") {
                    Price = strArr3[1];
                }
                else if (strArr3[0] == "Tax") {
                    Tax = strArr3[1];
                }
                else if (strArr3[0] == "TaxValue") {
                    TaxValue = strArr3[1];
                }
                else if (strArr3[0] == "AccountCodeID") {
                    AccountCodeID = strArr3[1];

                }
                else if (strArr3[0] == "Notes") {
                    Notes = strArr3[1];
                }
                else if (strArr3[0] == "GoodsReceived") {
                    GoodsReceived = strArr3[1];
                }
                else if (strArr3[0] == "ReceivedQty") {
                    ReceivedQty = strArr3[1];
                }
                else if (strArr3[0] == "IsCompleted") {
                    isCompleted = strArr3[1];
                }
                else if (strArr3[0] == "PriceCatalogueType") {
                    hdnDrawStockFrom.value = strArr3[1];
                }
                else if (strArr3[0] == "OnlyItemTitle") {
                    hdnOnlyItemTitle.value = strArr3[1];
                }
                else if (strArr3[0] == "AdditionalOptionDetails") {
                    hdnAdditionalID.value = strArr3[1];
                }
                else if (strArr3[0] == "PerQuantity") {
                    PerQuantity = strArr3[1];
                }
                else if (strArr3[0] == "MainCost") {
                    MainCost = strArr3[1];
                }
                else if (strArr3[0] == "MainPackedPrice") {
                    MainPackedPrice = strArr3[1];
                }
                else if (strArr3[0] == "StockType") {
                    StockType = strArr3[1];
                }
                else if (strArr3[0] == "SalesTaxRate") {
                    SalesTaxRate = strArr3[1];
                }
            }
            AddMoreItem(ItemID, ItemCode, ItemName, ItemQty, PackedIn, Price, ItemType, val, PerQuantity, MainCost, MainPackedPrice, StockType, SalesTaxRate, ReceivedQty);
            var table = document.getElementById("tblHeader");
            document.getElementById("lblItemID" + (i + 1)).innerHTML = ItemID;
            document.getElementById("chk" + (i + 1)).value = PurchaseItemID;
            document.getElementById("lblItemType" + (i + 1)).innerHTML = ItemType;

            document.getElementById("txtTaxValue" + (i + 1)).value = TaxValue;
            var txtTaxValue = document.getElementById("txtTaxValue" + (i + 1)).value;

            if (txtTaxValue.indexOf('.') == -1) txtTaxValue += ".";
            dectext = txtTaxValue.substring(TaxValue.indexOf('.') + 1, txtTaxValue.length);
            if (dectext.length > decallowed) {
                document.getElementById("txtTaxValue" + (i + 1)).value = txtTaxValue.substring(0, txtTaxValue.indexOf('.') + 3);
            }

            document.getElementById("txtNotes" + (i + 1)).value = Notes;

            if (val == "0" || val == "2") {
            }
            else {

                if (isCompleted == "False" || isCompleted == "false") {
                    document.getElementById("chkIsPOCompleted" + (i + 1)).checked = false;
                }
                else if (isCompleted == "True" || isCompleted == "true") {
                    document.getElementById("chkIsPOCompleted" + (i + 1)).checked = true;
                    document.getElementById("chkIsPOCompleted" + (i + 1)).disabled = true;
                }

                if (document.getElementById("chkIsPOCompleted" + (i + 1)).checked == true) {
                    GoodsReceived = true;
                }
                if (GoodsReceived == "False") {
                    document.getElementById("chkIsGoodsReceived" + (i + 1)).checked = false;
                }
                else { //modification by bilal (true converted to false)
                    document.getElementById("chkIsGoodsReceived" + (i + 1)).checked = true;
                    document.getElementById("chkIsGoodsReceived" + (i + 1)).disabled = true;
                }
            }

            // AC done for Purchase Edit case, by natraj...
            if (AccountingCode == "e") {
                var ddlACcode = document.getElementById("ddlACcode" + (i + 1));
                for (var k = 0; k < ddlACcode.length; k++) {
                    if (ddlACcode.options[k].value == AccountCodeID) {
                        ddlACcode.selectedIndex = k;
                    }
                }
            }

            var tblTax = document.getElementById("ddlTax" + (i + 1));

            for (var k = 0; k < tblTax.length; k++) {
                if (tblTax.options[k].value == Tax) {
                    tblTax.selectedIndex = k;
                }
            }
            CalculateTotalTax();
        }
    }
}

// To Validate Task page subject
var TaskAddData = '';
function Store_Task_Data() {

    if (testdate() == false) {
        return false;
    }
    else {

        TaskAddData = '';
        var assigneto = ddlassigneto.value == "" ? "0" : ddlassigneto.value;
        TaskAddData += "assignedto»" + assigneto + "±";

        var status = ddlstatus.value == "" ? "0" : ddlstatus.options[ddlstatus.selectedIndex].text;
        TaskAddData += "status»" + status + "±";


        var subject = hdn_Subject.value == "" ? "" : hdn_Subject.value;
        TaskAddData += "subject»" + subject + "±";

        var priority = ddlpriority.value == "" ? "0" : ddlpriority.options[ddlpriority.selectedIndex].text;
        TaskAddData += "priority»" + priority + "±";

        var contactid = contactid_hidden.value == "" ? "0" : contactid_hidden.value;
        TaskAddData += "contactid»" + contactid + "±";

        TaskAddData += "txtduedate»" + txtduedate.value + "±";
        TaskAddData += "ddlhour»" + ddlhour.value + "±";
        TaskAddData += "ddlminute»" + ddlminute.value + "±";
        TaskAddData += "description»" + txtcomment.value + " ";

        hidFollowupTask.value = TaskAddData;

        //        document.getElementById("div_task_add").style.display = "none";
        //        document.getElementById("hrefEditTask").style.display = "block";
    }
    hideTaskDiv();
    return false;
}

function show_hide_subject(distype) {
    var div_subject = document.getElementById("div_SubjectTable");
    div_subject.style.display = "none";
    hdn_Subject.value = txtSubject.value;

    if (distype == "show") {
        //setPopUpDivCenter(div_subject);
        txtSubject.value = "";
        // div_subject.style.display = "block";
        showDivPopupCenter('div_SubjectTable', '200');
        txtSubject.focus();
    }

}

function validate() {

    var isValid = true;
    var spn_txtSubject = document.getElementById("spn_txtSubject");
    spn_txtSubject.style.display = "none"
    if (txtSubject.value == "") {
        spn_txtSubject.style.display = "block"
        isValid = false;
    }
    if (isValid) {
        show_hide_subject('hide')
        return true;
    }
    else {
        show_hide_subject('show')
        return false;
    }
}

function Make_DDL_Show_Hide(para) {

    var div_ddlRaisedBy = document.getElementById("div_ddlRaisedBy");
    var div_ddlStatus = document.getElementById("div_ddlStatus");
    var div_ddlcontact = document.getElementById("div_ddlcontact");

    if (para == 'show') {
        div_ddlRaisedBy.style.display = "block";
        div_ddlStatus.style.display = "block";
        div_ddlcontact.style.display = "block";
    }
    else {
        div_ddlRaisedBy.style.display = "none";
        div_ddlStatus.style.display = "none";
        div_ddlcontact.style.display = "none";
    }
}


function CloseTaskPage() {

    Make_DDL_Show_Hide('show'); //BLOCK

    if (TaskAddData == '') {
        chk_FollowupTask.checked = false;
        document.getElementById("div_task_add").style.display = "none";
    }
    else {
        document.getElementById("div_task_add").style.display = "none";
    }
}


function OpenTaskPage(val) {
    if (val) {
        // setTaskPopUpCenter(document.getElementById("div_task_add"));
        document.getElementById("div_Task").style.display = "block";
        showDivPopupCenter('div_task_add', '300');
        Make_DDL_Show_Hide('none'); //NONE
    }
    else {
        document.getElementById("div_Task").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
        Make_DDL_Show_Hide('show'); //NONE
    }
}
function OpenTaskPage_New(val) {
    if (val) {
        // setTaskPopUpCenter(document.getElementById("div_task_add"));
        document.getElementById("div_Task").style.display = "block";
        showDivPopupCenter('div_task_add', '300');
    }
    else {
        document.getElementById("div_Task").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
}

function hideTaskDiv() {
    document.getElementById("div_Task").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
    Make_DDL_Show_Hide('show'); //NONE
}

function SendContactAddressIDandName(id, values, isdelivery, tooltip, addresstype, vartype, DeliveryCompanyName, DeliveryCompanyID) {
    //alert(id + ",<br/> " + values + ",<br/> " + isdelivery + ", " + tooltip + ",<br/> " + addresstype + ",<br/> " + vartype);

    //    if (values.length != 0) {
    //        for (var i = 0; i < values.length; i++) {
    //            values = values.replace('<br/>', '');
    //            i++;
    //        }
    //    }
    if (vartype == 'Delivery') {
        hdn_deliveryAddressType.value = addresstype;
        lbl_deliveryAddress_Value.title = SpecialDecode(trim12(values));
        lbl_deliveryAddress_Value.innerHTML = SpecialDecode(trim12(values));
        lbl_deliveryAddress_Value.cursor = "pointer";
        hdn_deliveryAddress.value = trim12(values);
        hdn_deliveryAddressID.value = id;

        lbl_CompanyName.innerHTML = SpecialDecode(trim12(DeliveryCompanyName));
        lbl_CompanyName.title = SpecialDecode(trim12(DeliveryCompanyName));
        hdn_CompanyName.value = DeliveryCompanyName;
        hdn_CompanyID.value = DeliveryCompanyID;
    }
    else if (vartype == 'Contact') {
        lblAddress.innerHTML = SpecialDecode(trim12(values));
        hdnAddressID.value = id;

        lblAddress.title = SpecialDecode(tooltip);
        lblAddress.style.cursor = "pointer";
    }
}

//added by rk to get the querystring
function getQueryStrings() {
    var assoc = {};
    var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
    var queryString = location.search.substring(1);
    var keyValues = queryString.split('&');

    for (var i in keyValues) {
        var key = keyValues[i].split('=');
        if (key.length > 1) {
            assoc[decode(key[0])] = decode(key[1]);
        }
    }

    return assoc;
}

//added by rakshith to calc inventory values on change qty
function GetNewCalcValues(qty, rowno) {
    var vaQty = 0;
    var TempPerprice = 0;
    var FinalPrice = 0;
    var tblItemType = document.getElementById("lblItemType" + rowno).innerHTML;
    var Qty = qty;
    if (tblItemType.toLowerCase() == 'i') {
        var tblPrice = document.getElementById("txtPackPrice" + rowno);
        var tblTax = document.getElementById("ddlTax" + rowno);
        var tblTaxID = tblTax.options[tblTax.selectedIndex].value;
        var tblTaxValue = document.getElementById("txtTaxValue" + rowno).value;
        var lblPerQty = document.getElementById("lblperqty" + rowno).innerHTML;
        var lblPerPrice = document.getElementById("lblperprice" + rowno).innerHTML;
        var lblpackedprice = document.getElementById("lblpackedprice" + rowno).innerHTML;
        var lblstocktype = document.getElementById("lblstocktype" + rowno).innerHTML;
        if (lblstocktype.toLowerCase() == "ink" || lblstocktype.toLowerCase() == "inks") {
            FinalPrice = (Qty * lblpackedprice);
            tblPrice.value = FinalPrice.toFixed(2);
        }
        else {
            if (lblPerQty > 0) {
                vaQty = Qty / lblPerQty;
                TempPerprice = RemoveDollorAndComma(lblPerPrice) * vaQty;
                FinalPrice = TempPerprice.toFixed(2);
                tblPrice.value = FinalPrice;
            }
        }
        gettaxPercentage(tblTaxID, tblTax.id)
        CalculateTotalTax();
    }


}

function PurchaseItemReplenishStockDetails(TableID, thisid) {
    var ActualOrderdQty = document.getElementById('hdnActualOrderedQty' + ProductCatalogueID).value;
    var EstimateItemID = document.getElementById('hdn_Selected_EstimateItemID' + ProductCatalogueID).value;
    var hdnstockselfdetails = document.getElementById("<%=hdnstockselfdetails.ClientID %>")
    var totalstockqty = 0;
    var stockdata = '';
    var tblid = document.getElementById(TableID);
    var rowid = document.getElementById(TableID.id).getElementsByTagName('tr');
    for (j = 1; j < (rowid.length); j++) {
        if (typeof rowid[j].id != 'undefined' && rowid[j].id != undefined && rowid[j].id != null && rowid[j].id != '') {
            var inputs = rowid[j].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                if ((inputs[n].id).indexOf('txtadjustqty') > -1) {                                          //(inputs[n].id == 'txtopnstock') {
                    stockdata += 'openstock»' + inputs[n].value + '±';
                    totalstockqty = parseInt(totalstockqty) + parseInt(inputs[n].value);
                }
                if ((inputs[n].id).indexOf('hdnlocationid') > -1) {                                     //inputs[n].id =='hdnlocationid') {
                    stockdata += 'customfield1»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtcustomfield2') > -1) {
                    stockdata += 'customfield2»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtcustomfield3') > -1) {
                    stockdata += 'customfield3»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtcustomfield4') > -1) {
                    stockdata += 'customfield4»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtcustomfield5') > -1) {
                    stockdata += 'customfield5»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtcustomfield6') > -1) {
                    stockdata += 'customfield6»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('hdnPrice') > -1) {
                    stockdata += 'price»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtstkdate') > -1) {
                    stockdata += 'date»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('hdn_Selected_EstimateItemID') > -1) {
                    stockdata += 'EstimateItemID»' + EstimateItemID + '±';
                }
            }
            stockdata += 'ProductCatalogueID»' + ProductCatalogueID + '±µ';
        }
    }
    //hdntotalstockqty.value = totalstockqty;
    if (Number(totalstockqty) != Number(ActualOrderdQty)) {
        var AlrtTxt = '<%=objLanguage.GetLanguageConversion("Total_Qty_should_always_be_equal_to_the_Original_Qty")%>';
        alert(AlrtTxt);
        return false;
    } else {
        hdnstockselfdetails.value = stockdata;
        if (SaveType.indexOf('btn_SaveandStayReplenishAllocation') > -1) {
            document.getElementById('div_btn_SaveandStayReplenishAllocation' + rcount).style.display = 'none';
            document.getElementById('div_stayprocess' + rcount).style.display = 'block';
            tblid_ProductCatalogueID = ProductCatalogueID;
            hdnaccordionIndex.value = rcount;

            __doPostBack("lnkbtn_Replenish_SaveandStay", '');
            return true;
        } else {

            document.getElementById('div_btn_SaveReplenishAllocation' + rcount).style.display = 'none';
            document.getElementById('div_saveprocess' + rcount).style.display = 'block';

            __doPostBack("lnkbtn_Replenish_Save", '');
            return true;
            window.close();
        }
    }
}

var CheckFinal = false;
function Validate(clk) {
    debugger
    CheckFinal = false;
    //leftcol//
    if (tblHeaderID.rows.length == 1) {
        document.getElementById("spn_tblHeader").style.display = "block";
        CheckFinal = true;
    }
    var txtSupplier = trim12(txtSupplierID.value);
    if (txtSupplier == '') {
        document.getElementById("spn_txtSupplier").style.display = "block";
        CheckFinal = true;
    }
    var ddlContact = ddlContactID.length;
    if (ddlContact == '') {
        document.getElementById("spn_ddlcontact").style.display = "block";
        CheckFinal = true;
    } else if (ddlContactID.options[ddlContactID.selectedIndex].value == 0) {
        document.getElementById("spn_ddlcontact").style.display = "block";
        CheckFinal = true;
    }

    var lblAddress = trim12(lblAddressID.innerHTML);
    if (lblAddress == '') {
        document.getElementById("spn_lblAddress").style.display = "block";
        CheckFinal = true;
    }

    //rightcol//
    var ddlRaisedBy = ddlRaisedByID.value;
    if (ddlRaisedBy == '0') {
        document.getElementById("spn_ddlRaisedBy").style.display = "block";
        CheckFinal = true;
    }
    var txtDate = trim12(txtDateID.value);
    if (txtDate == '') {
        document.getElementById("spn_txtDate").style.display = "block";
        CheckFinal = true;
    }
    else {
        if (ValidateForm(txtDateID, 'spn_txtDate', Date_Format) == false) {
            CheckFinal = true;
        }
    }
    var txtReqDateID1 = trim12(txtReqDateID.value);
    if (txtReqDateID1 == '') {
        document.getElementById("spn_txtReqDate").style.display = "block";
        CheckFinal = true;
    }
    else {
        if (ValidateForm(txtReqDateID, 'spn_txtReqDate', Date_Format) == false) {
            CheckFinal = true;
        }
    }
    var txtSuppDate = trim12(txtSuppInvDate.value);

    document.getElementById("spanddlStatus").style.display = "none";
    if (ddlStatus.selectedIndex == 0) {
        document.getElementById("spanddlStatus").style.display = "block";
        CheckFinal = true;
    }

    if (ServerName.toLowerCase() == "dmc" || ServerName.toLowerCase() == "dmc2") {
        if (ddlCourierInfo.selectedIndex == 0) {
            document.getElementById("spn_Carrier").style.display = "block";
            CheckFinal = true;
        }
        else {
            document.getElementById("spn_Carrier").style.display = "none";
        }
    }

    if (CheckFinal) {
        return false;
    }
    else {
        var Check = getItemValues('tblHeader', clk, Goods_Received_Display, path);
        if (Check) {
            return true;
        }
        else {
            return false;
        }
    }
}

//For the Case of goods recieved of Warehouse items. Creating a duplicate so that it wont effect the existing flow
function Validate2() {
    CheckFinal = false;
    //leftcol//
    if (tblHeaderID.rows.length == 1) {
        document.getElementById("spn_tblHeader").style.display = "block";
        CheckFinal = true;
    }
    var txtSupplier = trim12(txtSupplierID.value);
    if (txtSupplier == '') {
        document.getElementById("spn_txtSupplier").style.display = "block";
        CheckFinal = true;
    }
    var ddlContact = ddlContactID.length;
    if (ddlContact == '') {
        document.getElementById("spn_ddlcontact").style.display = "block";
        CheckFinal = true;
    } else if (ddlContactID.options[ddlContactID.selectedIndex].value == 0) {
        document.getElementById("spn_ddlcontact").style.display = "block";
        CheckFinal = true;
    }

    var lblAddress = trim12(lblAddressID.innerHTML);
    if (lblAddress == '') {
        document.getElementById("spn_lblAddress").style.display = "block";
        CheckFinal = true;
    }

    //rightcol//
    var ddlRaisedBy = ddlRaisedByID.value;
    if (ddlRaisedBy == '0') {
        document.getElementById("spn_ddlRaisedBy").style.display = "block";
        CheckFinal = true;
    }
    var txtDate = trim12(txtDateID.value);
    if (txtDate == '') {
        document.getElementById("spn_txtDate").style.display = "block";
        CheckFinal = true;
    }
    else {
        if (ValidateForm(txtDateID, 'spn_txtDate', Date_Format) == false) {
            CheckFinal = true;
        }
    }
    var txtReqDateID1 = trim12(txtReqDateID.value);
    if (txtReqDateID1 == '') {
        document.getElementById("spn_txtReqDate").style.display = "block";
        CheckFinal = true;
    }
    else {
        if (ValidateForm(txtReqDateID, 'spn_txtReqDate', Date_Format) == false) {
            CheckFinal = true;
        }
    }
    var txtSuppDate = trim12(txtSuppInvDate.value);

    document.getElementById("spanddlStatus").style.display = "none";
    if (ddlStatus.selectedIndex == 0) {
        document.getElementById("spanddlStatus").style.display = "block";
        CheckFinal = true;
    }
    if (CheckFinal) {
        return false;
    }
    else {
        var Check = getItemValues2('tblHeader');
        if (Check) {
            return true;
        }
        else {
            return false;
        }
    }
}