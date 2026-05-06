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
            window.radopen(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + PurchaseID.value, '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            // PopupCenter(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode, '1000', '500');
            window.radopen(commonpath + "contact/contact_add.aspx?type=Supplier&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + PurchaseID.value + "&IsAddMode=yes", '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        //return true;
        // }
    }
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
        window.radopen(commonpath + "common/common_popup.aspx?type=moreaddress&addresstype=Contact&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes", '700', '400');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return true;
    }
}


function popup_phrasebook(type) {
    //  PopupCenter(commonpath + "common/phrase_book.aspx?type=" + type, '800', '400');
    window.radopen(commonpath + "common/phrase_book.aspx?type=" + type, '800', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function AddMoreItem(ItemID, ItemCode, ItemName, Qty, PackedIn, Price, ItemType) {
    //*** new code to generate row from 1st row ***//
    //add a row to the rows collection and get a reference to the newly added row  

    spn_tblHeader.style.display = "none";
    var newRow = document.all("tblHeader").insertRow(rowNo);

    //add cells (<td>) to the new row and set the innerHTML to contain text boxes                            
    var oCell = newRow.insertCell(0);
    oCell.style.verticalAlign = "top";
    oCell.innerHTML = "<input type='checkbox' name='chk" + rowNo + "' id='chk" + rowNo + "' value='0' /><label name='lblItemType" + rowNo + "' id='lblItemType" + rowNo + "' class='normalText' style='display:none'>" + ItemType + "</label><label name='lblItemID" + rowNo + "' id='lblItemID" + rowNo + "' class='normalText' style='display:none'>" + ItemID + "</label>";

    oCell = newRow.insertCell(1);
    //oCell.innerHTML = "<input type='text' name='txtItemCode"+rowNo+"' id='txtItemCode"+rowNo+"' class='textboxnew' rows='3' style='width:100%' value='"+ItemCode+"'>";
    oCell.innerHTML = "<textarea name='txtItemCode" + rowNo + "' id='txtItemCode" + rowNo + "' class='textboxnew' maxlength='25' onkeydown='limitText(this,20);' onkeyup='limitText(this,20);' rows='6' style='width:100%'>" + ItemCode + "</textarea>";

    oCell = newRow.insertCell(2);
    oCell.innerHTML = "<textarea name='txtDescription" + rowNo + "' id='txtDescription" + rowNo + "' class='textboxnew' rows='6' style='width:100%'>" + ItemName + "</textarea>";

    oCell = newRow.insertCell(3);
    //oCell.innerHTML = "<input type='text' name='txtQty"+rowNo+"' id='txtQty"+rowNo+"' onblur='javascript:SetNumber(this,this.value)' maxlength='8' class='textboxnew' style='width:100%' value='"+Qty+"'>";CalculatePackedPrice(" + rowNo + "," + PackedIn + "," + Price + ");
    oCell.innerHTML = "<textarea name='txtQty" + rowNo + "' id='txtQty" + rowNo + "'MakePrice2Decimal(this,this.value);' maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Qty, 0, '', true, false, true) + "</textarea>";
    //alert("hi");

    if (document.getElementById("txtQty" + rowNo).value == "0") {
        document.getElementById("txtQty" + rowNo).value = "";
    }
    oCell = newRow.insertCell(4);
    //oCell.innerHTML = "<input type='text' name='txtPackedIn"+rowNo+"' id='txtPackedIn"+rowNo+"' onblur='javascript:SetNumber(this,this.value)' maxlength='8' class='textboxnew' style='width:100%' value='"+PackedIn+"'>";CalculatePackedPrice(" + rowNo + ");
    oCell.innerHTML = "<textarea name='txtPackedIn" + rowNo + "' id='txtPackedIn" + rowNo + "'MakePrice2Decimal(this,this.value);'  maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PackedIn, 0, '', false, false, true) + "</textarea>";

    if (Number(document.getElementById("txtPackedIn" + rowNo).value) == 0) {
        document.getElementById("txtPackedIn" + rowNo).value = "";
    }

    oCell = newRow.insertCell(5);
    //oCell.innerHTML = "<input type='text' name='txtPackPrice"+rowNo+"' id='txtPackPrice"+rowNo+"' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='12' class='textboxnew' style='width:100%' value='"+Price+"'>";CalculatePackedPrice(" + rowNo + ");
    oCell.innerHTML = "<textarea name='txtPackPrice" + rowNo + "' id='txtPackPrice" + rowNo + "' onblur='javascript:SetNumber(this,this.value);MakePrice2Decimal(this,this.value);CalculateTotalTax();' maxlength='10' onkeydown='limitText(this,10);' onkeyup='limitText(this,10);' class='textboxnew' rows='6' style='width:100%;text-align: right'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Price, 0, '', false, false, true) + "</textarea>";

    oCell = newRow.insertCell(6);
    oCell.style.verticalAlign = "top";
    oCell.innerHTML = "<select name='ddlTax" + rowNo + "' id='ddlTax" + rowNo + "' onchange='javascript:gettaxPercentage(this.value,this.id);CalculateTotalTax();' class='normalText' style='width:100%;'></select>";

    oCell = newRow.insertCell(7);
    //oCell.innerHTML = "<input type='text' name='txtTaxValue"+rowNo+"' id='txtTaxValue"+rowNo+"' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='12'  class='textboxnew' style='width:100%' value='0.00'>";
    oCell.innerHTML = "<textarea name='txtTaxValue" + rowNo + "' id='txtTaxValue" + rowNo + "' onblur='javascript:SetNumber(this,this.value);CalculateTotalTax();' maxlength='8' onkeydown='limitText(this,8);' onkeyup='limitText(this,8);'  class='textboxnew' rows='6' style='width:100%;text-align: right'>0.00</textarea>";

    //added by natraj
    if (AccountingCode == "e") {
        oCell = newRow.insertCell(8);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<select name='ddlACcode" + rowNo + "' id='ddlACcode" + rowNo + "' onchange='javascript:getACcode(this.value,this.id);' class='normalText' style='width:100%;'></select>";

        oCell = newRow.insertCell(9);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='6'  style='width:100%'></textarea>";

        oCell = newRow.insertCell(10);
        oCell.style.verticalAlign = "top";
        //oCell.style.textAlign = "center";
        oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />";
    }
    else {
        oCell = newRow.insertCell(8);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='6'  style='width:100%'></textarea>";

        oCell = newRow.insertCell(9);
        oCell.style.verticalAlign = "top";
        //oCell.style.textAlign = "center";
        oCell.innerHTML = "<input type='checkbox' name='chkIsGoodsReceived" + rowNo + "' id='chkIsGoodsReceived" + rowNo + "' value='0' />";
    }
    rowNo = rowNo + 1;
    //** End **//

    //*** To Bind Accounting Code to ddlAC Code****//
    var ddlACcode;
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
    if (DefaultACcodeID != 0) {
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
                ddlTax.options.add(new Option(TaxName, TaxID, i));
                ddlTax.selectedIndex = 0;
            }
        }
    }
    if (hid_DefaultTax != null) {
        if (hid_DefaultTax.value != 0) {
            var SelectedIndex = 0;
            if (ddlTax.value = hid_DefaultTax.value) {
                SelectedIndex = ddlTax.selectedIndex;
            }
            ddlTax.selectedIndex = SelectedIndex;

        }
    }
    JustCheck++;
    //**** End ****//
    CalculateTotalTax();
}

function CalculatePackedPrice(rowno, PackedInQty, PackPrice) {
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
        var rowCount = table.rows.length;
        //alert("before delete="+table.rows.length);                             
        if (takeCount == 0) {
            takeCount = rowCount;
        }
        var chkchecked = '';
        for (var i = 1; i < rowCount; i++) {
            var row = table.rows[i];
            var chkbox = row.cells[0].childNodes[0];
            if (chkbox.checked) {
                chkchecked = 'yes';
            }
            else {
                chkchecked = 'no';
            }
        }
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
        if (chkchecked == 'no') {
            alert('Please check atleast one row to delete');
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
                var tblTaxID = tblTax.options[tblTax.options.selectedIndex].value;
                if (tblTax != null) {
                    var tblTaxID = tblTax.options[tblTax.selectedIndex].value;
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
function getItemValues(tableID)//(ItemID,ItemCode,ItemName,Qty,PackedIn,Price,ItemType)
{
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    var ItemValuesConcat = "";
    //  if (chkcount == 0)
    //  {
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
            // alert(tblItemDesc);
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
        }
    }
    hid_ItemValues.value = ItemValuesConcat;

    //  }                            
    chkcount = 1;
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

function load() {
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
            }
            AddMoreItem(ItemID, ItemCode, ItemName, ItemQty, PackedIn, Price, ItemType);
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

            if (GoodsReceived == "False") {
                document.getElementById("chkIsGoodsReceived" + (i + 1)).checked = false;
            }
            else {
                document.getElementById("chkIsGoodsReceived" + (i + 1)).checked = true;
            }

            // AC done for Purchase Edit case, by natraj...
            if (AccountingCode == "e") {
                var ddlACcode = document.getElementById("ddlACcode" + (i + 1));
                for (var k = 0; k < ddlACcode.length - 1; k++) {
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
        lbl_deliveryAddress_Value.title = trim12(values);
        lbl_deliveryAddress_Value.innerHTML = trim12(values);
        lbl_deliveryAddress_Value.cursor = "pointer";
        hdn_deliveryAddress.value = trim12(values);
        hdn_deliveryAddressID.value = id;

        lbl_CompanyName.innerHTML = trim12(DeliveryCompanyName);
        hdn_CompanyName.value = DeliveryCompanyName;
        hdn_CompanyID.value = DeliveryCompanyID;



    }
    else if (vartype == 'Contact') {
        lblAddress.innerHTML = trim12(values);
        hdnAddressID.value = id;

        lblAddress.title = tooltip;
        lblAddress.style.cursor = "pointer";
    }
}