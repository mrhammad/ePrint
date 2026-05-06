// JScript File
var Pricecompflag = true;
var IsSuptblEmpty = "no";
function SendPhraseBookToPB(id, values, phrasetype, tooltip) {
    values = trim12(values);
    if (phrasetype == 'PrintBroker Title') {
        txtTitleDescription.value = values;
        txtPBItemTitle.value = values;
    }
    if (phrasetype == 'PrintBroker Artwork') {
        txtArtworkDescription.value = values;
        txtPBArtwork.value = values;
    }
    if (phrasetype == 'PrintBroker Description') {
        txtOriginationDescription.value = values;
        txtPBDesign.value = values;
    }
    if (phrasetype == 'PrintBroker Colours') {
        txtColorDescription.value = values;
        txtPBColour.value = values;
    }
    if (phrasetype == 'PrintBroker Size') {
        txtSizeDescription.value = values;
        txtPBSize.value = values;
    }
    if (phrasetype == 'PrintBroker Material') {
        txtMaterialDescription.value = values;
        txtPBMaterials.value = values;
    }
    if (phrasetype == 'PrintBroker Delivery') {
        txtDeliveryDescription.value = values;
        txtPBDelivery.value = values;
    }
    if (phrasetype == 'PrintBroker Finishing') {
        txtFinishingDescription.value = values;
        txtPBFinishing.value = values;
    }
    if (phrasetype == 'PrintBroker Proofs') {
        txtProofsDescription.value = values;
        txtPBFinishing.value = values;
    }
    if (phrasetype == 'PrintBroker Packing') {
        txtPackingDescription.value = values;
        txtPBFinishing.value = values;
    }
    if (phrasetype == 'PrintBroker Notes') {
        txtNotesDescription.value = values;
        txtPBNotes.value = values;
    }
    if (phrasetype == 'PrintBroker Terms') {
        txtTermsDescription.value = values;
        txtPBInstructions.value = values;
    }
    // For New Fields get from Phrase popup
    if (phrasetype == 'PrintBroker CustomDescription1') {
        txt_SuplierValue1.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription2') {
        txt_SuplierValue2.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription3') {
        txt_SuplierValue3.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription4') {
        txt_SuplierValue4.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription5') {
        txt_SuplierValue5.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription6') {
        txt_SuplierValue6.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription7') {
        txt_SuplierValue7.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription8') {
        txt_SuplierValue8.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription9') {
        txt_SuplierValue9.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription10') {
        txt_SuplierValue10.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription11') {
        txt_SuplierValue11.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription12') {
        txt_SuplierValue12.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription13') {
        txt_SuplierValue13.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription14') {
        txt_SuplierValue14.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription15') {
        txt_SuplierValue15.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription16') {
        txt_SuplierValue16.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription17') {
        txt_SuplierValue17.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription18') {
        txt_SuplierValue18.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription19') {
        txt_SuplierValue19.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription20') {
        txt_SuplierValue20.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription21') {
        txt_SuplierValue21.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription22') {
        txt_SuplierValue22.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription23') {
        txt_SuplierValue23.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription24') {
        txt_SuplierValue24.value = values;
    }
    if (phrasetype == 'PrintBroker CustomDescription25') {
        txt_SuplierValue25.value = values;
    }
    // End
}

function GetPBPhraseBook(para, type) {
    if (para == "header") {
        //PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
        window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
    else if (para == "footer") {
        // PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
        window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
}
function Send_PrintBroker_Phrases(id, values, phrasetype, tooltip) {
    if (phrasetype == "PrintBroker Header") {
        spn_PrintBroker_Header.innerHTML = values;
        spn_PrintBroker_Header.title = values;
    }
    else if (phrasetype == "PrintBroker Footer") {
        spn_PrintBroker_Footer.innerHTML = values;
        spn_PrintBroker_Footer.title = values;
    }
}
function GetSupplierCount(supcount) {
    hdn_SupCount.value = supcount;
}

var IsEntered = false;
var roundTrip = 0;
var cnt = 1;
function CreatePriceComparison(supObj) {
    var supValue = supObj.options[supObj.selectedIndex].value;
    //alert(qtyType);    
    if (hdn_SupCount.value == "1" && IsSuptblEmpty == "no")//&& qtyType != "single" 
    {
        var PriceTable = document.getElementById("PriceTable");
        if (document.getElementById("Price_tr_" + supObj.id + "") != null) {
            var chil = document.getElementById("Price_tr_" + supObj.id + "");
            PriceTable.removeChild(chil);
        }
    }
    IsSuptblEmpty = "no";

    for (var i = 1; i <= labelCount; i++) {
        var supObj_2 = document.getElementById("ddlSupplier_" + i);
        if (supObj_2 != null) {
            //alert(supObj_2.id + "===" + supObj.id);       
            if (supObj_2.id != supObj.id) {
                if (supObj_2.value == supValue) {
                    supObj.selectedIndex = 0;
                    var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                    if (divPriceObj != null) {
                        var PriceTable = document.getElementById("PriceTable");
                        var chil = document.getElementById("Price_tr_" + supObj.id + "");
                        PriceTable.removeChild(chil);
                    }
                    return false;
                }
                else {
                    var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                    if (divPriceObj != null) {
                        var PriceTable = document.getElementById("PriceTable");
                        var chil = document.getElementById("Price_tr_" + supObj.id + "");
                        PriceTable.removeChild(chil);
                    }
                }
            }
        }
    }

    var txtSingleQty = '';
    var txtRunQty1 = ''; var txtRunQty2 = '';
    var txtMultiQty1 = ''; var txtMultiQty2 = ''; var txtMultiQty3 = ''; var txtMultiQty4 = '';

    var uniData = '';
    var MarkupOptions = GetMarkuptype();

    if (supValue != "0" && supValue != '') {
        //TotalSup +=supObj.options[supObj.selectedIndex].value+"±"+supObj.options[supObj.selectedIndex].text+"µ";
        if (qtyType == "single") {
            qtyCount = 1;
            txtSingleQty = txtSingleQty1.value;
        }
        else if (qtyType == "multiple") {
            qtyCount = 4;
            txtMultiQty1 = txtMultiQty11.value;
            txtMultiQty2 = txtMultiQty22.value;
            txtMultiQty3 = txtMultiQty33.value;
            txtMultiQty4 = txtMultiQty44.value;
        }
        else if (qtyType == "runon") {
            qtyCount = 2;
            txtRunQty1 = txtRunQty11.value;
            txtRunQty2 = txtRunQty22.value;
        }
        uniData += "<div id=divPriceComparision_" + supObj.id + ">";

        for (var j = 1; j <= qtyCount; j++) {
            var name = supObj.options[supObj.selectedIndex].text;

            if (j != 1) {
                name = '&nbsp;';
            }
            var QtyValue = '';
            if (qtyType == "single") {
                QtyValue = txtSingleQty;
            }
            else if (qtyType == "runon") {
                if (j == 1) {
                    QtyValue = txtRunQty1;
                }
                else if (j == 2) {
                    QtyValue = txtRunQty2;
                }
            }
            else if (qtyType == "multiple") {
                if (j == 1) {
                    QtyValue = txtMultiQty1;
                }
                else if (j == 2) {
                    QtyValue = txtMultiQty2;
                }
                else if (j == 3) {
                    QtyValue = txtMultiQty3;
                }
                else if (j == 4) {
                    QtyValue = txtMultiQty4;
                }

                if (QtyNumber == 1) {
                    txtMultiQty22.style.display = 'none';
                    txtMultiQty33.style.display = 'none';
                    txtMultiQty44.style.display = 'none';
                }
                else if (QtyNumber == 2) {
                    txtMultiQty11.style.display = 'none';
                    txtMultiQty33.style.display = 'none';
                    txtMultiQty44.style.display = 'none';
                }
                else if (QtyNumber == 3) {
                    txtMultiQty11.style.display = 'none';
                    txtMultiQty22.style.display = 'none';
                    txtMultiQty44.style.display = 'none';
                }
                else if (QtyNumber == 4) {
                    txtMultiQty11.style.display = 'none';
                    txtMultiQty22.style.display = 'none';
                    txtMultiQty33.style.display = 'none';
                }

            }



            var comnID = supValue + '_' + j;
            uniData += "<div id='Div_" + comnID + "' class='onlyEmpty'></div>";
            uniData += "<div align='left'>";
            if (j == 1) {
                uniData += "<div style='float: left; width: 9%'><input id='txtRefNo_" + comnID + "' type='text' class='textboxnew' style='Width:90%;text-align:right;' /></div>";
            }
            else {
                uniData += "<div style='float: left; width: 9%'>&nbsp;</div>";
            }
            uniData += "<div style='float: left; width: 14%'>" + name + "</div>";
            uniData += "<div style='float: left; width: 6%;padding-right:5px'><input id='txtQty_" + comnID + "' type='text'  value='" + QtyValue + "' class='textboxnew' style='Width:95%;text-align:right' disabled='true' /></div>";
            uniData += "<div style='float: left; width: 9%'><input id='txtCost_" + comnID + "' type='text' onchange=\"javascript:SelectChkQty('" + comnID + "');\" onclick='this.select();' onfocus='this.select();'  onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";

            var SelectedValue = "";
            var disabledvalue = "disabled='true'";
            if (SysName == "occy") {
                SelectedValue = "selected='selected'";
                disabledvalue = "";
            }

            uniData += "<div style='float: left; width: 7%'><select id='ddlDeliveryIncluded_" + comnID + "' onchange=DropdownChange(this,'txtDeliveryCost_" + comnID + "'); style='Width:85%' class='normaltext'><option value='yes'>yes</option><option value='no' " + SelectedValue + ">No</option></select></div>";
            if (j == 1) {
                uniData += "<div style='float: left; width: 9%'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" onblur=\"javascript:CopyDate(" + supValue + "," + qtyCount + ",this.value);\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
            }
            else {
                uniData += "<div style='float: left; width: 9%'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
            }
            uniData += "<div style='float: left; width: 10%'><input id='txtDeliveryCost_" + comnID + "' " + disabledvalue + "  onblur=\"javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";
            if (j == 1) {
                uniData += "<div style='float: left; width: 9%'><select id='ddlMarkup_" + comnID + "' style='Width:85%' onchange=javascript:CopyMarkup(this.value," + supValue + "," + qtyCount + ");  class='normaltext'>" + MarkupOptions + "</select></div>";
                uniData += "<div style='float: left; width: 9%'><input id='txtMarkup_" + comnID + "'  value='" + pb_markup + "'   onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);CopyMarkupValue(this.value," + supValue + "," + qtyCount + ");\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
            }
            else {
                uniData += "<div style='float: left; width: 9%'><select id='ddlMarkup_" + comnID + "' style='Width:85%' onchange=javascript:CopyMarkup(this.value," + supValue + "," + qtyCount + ");   class='normaltext'>" + MarkupOptions + "</select></div>";  //onchange=javascript:CalculatePrice('" + comnID + "','c');
                uniData += "<div style='float: left; width: 9%'><input id='txtMarkup_" + comnID + "' value='" + pb_markup + "'  onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
            }

            uniData += "<div style='float: left; width: 8%'><input id='txtTotalPrice_" + comnID + "' onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "','price');\" type='text' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";

            uniData += "<div style='float: left; width: 9%;'><input style='float: left;margin-left: 40px' id='chk_" + comnID + "' name='chk_ow'  type='checkbox' onclick=\"javascript:SelectOneSuppler('" + comnID + "');\" /></div>";
            uniData += "</div>";
            uniData += "<div id='Div1_" + comnID + "' class='onlyEmpty'></div>";

        } // last for
        uniData += "<div style='padding:2px 0px 4px 0px;'><div class='onlyEmpty' style='border:1px solid #ccc;'></div></div>";
        uniData += "</div>";
    } // end of if

    var row = document.createElement("tr");
    row.id = "Price_tr_" + supObj.id + "";
    var cell = document.createElement("td");
    cell.innerHTML = uniData;
    row.appendChild(cell);
    document.getElementById("PriceTable").appendChild(row);

    for (var k = 1; k <= qtyCount; k++) {

        if (k != QtyNumber && QtyNumber != 0 && qtyType != "single") {
            var CountNew = supValue + '_' + k;
            document.getElementById("Div_" + CountNew + "").style.display = "none";
            document.getElementById("Div1_" + CountNew + "").style.display = "none";
            document.getElementById("txtQty_" + CountNew + "").style.display = "none";
            document.getElementById("txtQty_" + CountNew + "").style.display = "none";
            document.getElementById("txtCost_" + CountNew + "").style.display = 'none';
            document.getElementById("ddlDeliveryIncluded_" + CountNew + "").style.display = 'none';
            document.getElementById("txtDeliveryDate_" + CountNew + "").style.display = 'none';
            document.getElementById("txtDeliveryCost_" + CountNew + "").style.display = 'none';
            document.getElementById("ddlMarkup_" + CountNew + "").style.display = 'none';
            document.getElementById("txtMarkup_" + CountNew + "").style.display = 'none';
            document.getElementById("txtTotalPrice_" + CountNew + "").style.display = 'none';
            document.getElementById("chk_" + CountNew + "").style.display = 'none';
        }
    }

    priceNo++;
    roundTrip++;


    if (funreqtype() != "edit") {
        //alert("hi");
        var input_cc = new Array();
        input_cc = document.getElementsByName("chk_ow");
        for (var i = 0; i < input_cc.length; i++) {
            var ch_arr = input_cc[i].id.split('_');
            if (i == 0) {
                //input_cc[i].checked = true;
            }
            else {
                if (ch_arr[2] == 1) {
                    // input_cc[i].disabled = true;
                }
            }
        }
    }
}

function GetCurSym(Amount, IsExist) {

    return GetCurrencyinRequiredFormate("", true);
}
function GetMarkuptype() {
    var SelectedOption;
    var DefaultMarkupType = GetCurrencyinRequiredFormate("", true);
    if (hid_DefaultMarkupType.value == '1') {
        SelectedOption = "<option value='percentage' selected=selected>%</option><option value='fixedvalue' >" + GetCurrencyinRequiredFormate("", true) + "</option>";
    }
    else if (hid_DefaultMarkupType.value == '2') {
        SelectedOption = "<option value='percentage'>%</option><option value='fixedvalue' selected=selected >" + GetCurrencyinRequiredFormate("", true) + "</option>";
    }
    else if (hid_DefaultMarkupType.value == 'per1000') {
        SelectedOption = "<option value=\"per1000\">Per 1000 Costing&nbsp;&nbsp;</option>";
    }
    else {
        SelectedOption = "<option value='percentage' selected=selected>%</option><option value='fixedvalue' >" + GetCurrencyinRequiredFormate("", true) + "</option>";

    }

    return SelectedOption;
}
//***** To Bind Default RFQ Data of PrintBroker BY SWETHA******///
function BindDefaultRFQData() {
    var txtPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBItemTitle");
    var txtPBDesign = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBDesign");
    var txtPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBArtwork");
    var txtPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBColour");
    var txtPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBSize");
    var txtPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBMaterials");
    var txtPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBFinishing");
    var txtPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBDelivery");
    var txtPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBNotes");
    var txtPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBInstructions");

    var txt_lblPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBItemTitle");
    var txt_lblPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBDescription");
    var txt_lblPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBArtwork");
    var txt_lblPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBColour");
    var txt_lblPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBSize");
    var txt_lblPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBMaterials");
    var txt_lblPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBFinishing");
    var txt_lblPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBDelivery");
    var txt_lblPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBNotes");
    var txt_lblPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBInstructions");

    var chkPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBItemTitle");
    var chkPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBDescription");
    var chkPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBArtwork");
    var chkPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBColour");
    var chkPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBSize");
    var chkPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBMaterials");
    var chkPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBDelivery");
    var chkPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBFinishing");
    var chkPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBNotes");
    var chkPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBInstructions");

    var hdn_lblPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBItemTitle");
    var hdn_lblPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBDescription");
    var hdn_lblPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBArtwork");
    var hdn_lblPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBColour");
    var hdn_lblPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBSize");
    var hdn_lblPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBMaterials");
    var hdn_lblPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBDelivery");
    var hdn_lblPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBFinishing");
    var hdn_lblPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBNotes");
    var hdn_lblPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBInstructions");

    //Values//
    txtPBItemTitle.value = txtTitleDescription.value;
    txtPBDesign.value = txtOriginationDescription.value;
    txtPBArtwork.value = txtArtworkDescription.value;
    txtPBColour.value = txtColorDescription.value;
    txtPBSize.value = txtSizeDescription.value;
    txtPBMaterials.value = txtMaterialDescription.value;
    txtPBFinishing.value = txtFinishingDescription.value;

    txtPBDelivery.value = txtDeliveryDescription.value;
    txtPBNotes.value = txtNotesDescription.value;
    txtPBInstructions.value = txtTermsDescription.value;

    //Label//
    txt_lblPBItemTitle.value = txtTitle.value;
    hdn_lblPBDescription.value = txtOrigination.value;
    hdn_lblPBArtwork.value = txtArtwork.value;
    hdn_lblPBColour.value = txtColor.value;
    hdn_lblPBSize.value = txtSize.value;
    hdn_lblPBMaterials.value = txtMaterial.value;
    hdn_lblPBFinishing.value = txtFinishing.value;
    hdn_lblPBDelivery.value = txtDelivery.value;
    hdn_lblPBNotes.value = txtNotes.value;
    hdn_lblPBInstructions.value = txtTerms.value;

    hdn_lblPBItemTitle.value = txtTitle.value;
    txt_lblPBDescription.value = txtOrigination.value;
    txt_lblPBArtwork.value = txtArtwork.value;
    txt_lblPBColour.value = txtColor.value;
    txt_lblPBSize.value = txtSize.value;
    txt_lblPBMaterials.value = txtMaterial.value;
    txt_lblPBFinishing.value = txtFinishing.value;
    txt_lblPBDelivery.value = txtDelivery.value;
    txt_lblPBNotes.value = txtNotes.value;
    txt_lblPBInstructions.value = txtTerms.value;


    //Chk Boxes//
    chkPBItemTitle.checked = chkOutItemTitle.checked;
    chkPBDescription.checked = chkOutDescription.checked;
    chkPBArtwork.checked = chkOutArtwork.checked;
    chkPBColour.checked = chkOutColour.checked;
    chkPBSize.checked = chkOutSize.checked;
    chkPBMaterials.checked = chkOutMaterial.checked;
    chkPBDelivery.checked = chkOutDelivery.checked;
    chkPBFinishing.checked = chkOutFinishing.checked;
    chkPBNotes.checked = chkOutNotes.checked;
    chkPBInstructions.checked = chkOutInstructions.checked;
}

function OpenUpload() {
    var PageMode = '<%=MainType%>';

    //PopupCenter(strSitepath + "estimates/artwork_files_upload_0.aspx?pg=" + UcPage, '800', '400');
    // Natraj, Popup Size Changed.
    var Rad_FileUpload = window.radopen(strSitepath + "estimates/artwork_files_upload_0.aspx?pg=" + UcPage + "&PageType= " + QueryType);
    SetRadWindow_Ver2('div_FileUpload', 'divBackGroundNew');
    Rad_FileUpload.setSize(700, 420);
    Rad_FileUpload.center();
}
// Natraj...
function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
    var div_Accountcode = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);
    if (document.getElementById(divMaskID).style.display == "none") {

        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(div_FileUpload);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
    else {
        showDivPopupCenter_Ver2(divMaskID);
        // document.getElementById(divMaskID).style.display = "none";
        //divBackGroundNew.style.display = "none";
    }
}



function getPBItemTitle(txtVal) {
    //To make Item desc values null in case of Sub Item //
    if (IsMain == 'no') {
        txtTitleDescription.value = txtVal;
        txtOriginationDescription.value = "";
        txtArtworkDescription.value = "";
        txtColorDescription.value = "";
        txtSizeDescription.value = "";
        txtMaterialDescription.value = "";
        txtDeliveryDescription.value = "";
        txtFinishingDescription.value = "";
        txtNotesDescription.value = "";
        txtTermsDescription.value = "";
    }
    //Only In Add Case//
    if (hdn_OutworkDesc.value != '') {
        txtTitleDescription.value = txtVal;
    }
}



var si = 0;
function ArtWorkMore() {
    if (si <= 1) {
        var ArtWork_Content = document.getElementById("div_ArtWork_Content");
        var ArtWork_More = document.getElementById("div_ArtWork_More");
        var str = "<div align='left' id='div_art_" + si + "' ><div class='bglabel'><span class='normaltext'>Art Work<span> </div>";
        str += "<div class='box' style='padding-top:5px;'> <input id='txt_Art_work_" + si + "' type='file'  class='UploadClass' /></div></div>"
        ArtWork_More.innerHTML = ArtWork_More.innerHTML + str;
        si++;
    }
}

function ArtWorkMoreRemove(para1) {
    if (si > 0) {
        si = si - 1;
        var ctrl;
        ctrl = document.getElementById('div_ArtWork_More');
        var chil = document.getElementById("div_art_" + si + "");
        ctrl.removeChild(chil);
    }
}

function GenrateSupplierList() {
    if (OptionData == '') {
        var supData = ''; //strSupList.value;
        //supData = supData.replace(/'/gi, "`");

        PageMethods.GetSuppliers_List(CompanyID, function SList(retnValue) {
            OptionData = "<option selected='selected' value=0>--- Select ---</option>";
            if (retnValue != "") {
                var strSupArray = retnValue.split('±');
                for (var i = 0; i < strSupArray.length; i++) {
                    var arr1 = strSupArray[i].split('»');
                    //ddl1.options.add(new Option(arr1[1],arr1[0],i+1));
                    if (arr1[1] != '' && arr1[1] != 'undefined') {
                        if (arr1[1] == "undefined") {
                        }
                        else {
                            OptionData += "<option value='" + arr1[0] + "'>" + arr1[1] + "</option>";
                        }
                    }
                    if (strSupArray.length - 1 == i) {
                        if (ReqType == "edit") {
                            LoadToPBbox('0');
                            BindOutworkDesc();
                        }
                        else {
                            Use_add_more();
                        }
                    }
                }
            }
            else {
                for (var k = 1; k < 2; k++) {
                    if (ReqType == "edit") {
                        LoadToPBbox('0');
                        BindOutworkDesc();
                    }
                    else {
                        Use_add_more();
                    }
                }
            }
        }, SList_error);
    }

}
function SList_error(err) {
}

//Code for language conversion for function add_more
var Supplier;
var Name;
var Contact;

AutoFill.GetLanguageConversionJS("Supplier", GetLCForSupplier, onTimeout, onError);
AutoFill.GetLanguageConversionJS("Name", GetLCForName, onTimeout, onError);
AutoFill.GetLanguageConversionJS("Contact", GetLCForContact, onTimeout, onError);

function GetLCForSupplier(result) {
    Supplier = result;
    //alert('Inside ' + Supplier);
}
function GetLCForName(result) {
    Name = result;
    //alert('Inside '+Name);
}
function GetLCForContact(result) {
    Contact = result;
    //alert('Inside' +Contact);
}

function onTimeout(request, context) {
    //            alert(request + " request");
    //            alert(context + " context");
}
function onError(objError) {
    //            alert(objError + " objError");

}
///Code Ends for language conversion

function add_more() {

    var Suppliers = OptionData;
    document.getElementById("div_scroll").style.overflow = "auto";
    var div_content = document.getElementById("divtest");
    var div_add = document.getElementById("div_added");
    var tcount = document.getElementById("hdn_count");
    var finalcontent = "";
    if (supCount <= 12) {

        var LinktoGo;
        var SupData = "<div id='div_supplier" + labelCount + "'>";
        SupData += "<div align='left' style='width:100%;'>";
        SupData += "<div align='left' ><span class='HeaderText' id='spn_supheader_" + labelCount + "' >" + Supplier + labelCount + "</span></div>";
        SupData += "<div align='left'>";
        SupData += "<div class='bglabel' style='float:left;'>" + Name + "</div>";

        var labelnew = '';
        if (IsEdit) {
            labelnew = "GetSupplierCount('" + supCount + "');CreatePriceComparison(this);";
        }
        else {
            labelnew = "ClearSpplierIfExsits(this);"; //this used only in add case
        }

        SupData += "<div class='box' style='float:left'><select id='ddlSupplier_" + labelCount + "' onchange=\"javascript:loadContacts(this.value," + labelCount + ");" + labelnew + "\"  class='normaltext' tabindex='26' style='width:200px;'>" + Suppliers + "</select></div>"; //CreatePriceComparison(this);
        SupData += "</div>";
        //////*******//////
        SupData += "<div align='left'>";
        SupData += "<div class='bglabel'>" + Contact + "</div>";
        SupData += "<div class='box'><select id='ddlSupplierContact_" + labelCount + "' class='normaltext' style='width:200px;'><option value='0' >--- Select ---</option></select>";

        SupData += "<div style='float:right;padding-right:65px;padding-top:2px'>";
        //SupData += "&nbsp;<a href='#' onclick=javascript:RemoveThisSupplier('" + labelCount + "');RemoveTableRow('" + rowno + "'); >Rem</a>";
        SupData += "<img style='cursor:pointer;float:right;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:RemoveThisSupplier('" + labelCount + "');RemoveTableRow('" + rowno + "'); />";

        SupData += "</div>";

        SupData += "</div>";
        SupData += "</div>";
        SupData += "</div>";
        SupData += "<div class='onlyEmpty' style='border-bottom: 1px solid silver;width:99%;'></div>";
        SupData += "</div>";
        //div_add.innerHTML = div_add.innerHTML + SupData;                                    

        var row = document.createElement("tr");
        row.id = "tr_" + rowno + "";
        var cell = document.createElement("td");
        cell.innerHTML = SupData;
        row.appendChild(cell);
        tableSup.appendChild(row);

        rowno++;
        labelCount++;
        supCount++;
        var nu = 1;
        for (var i = 1; i < labelCount; i++) {
            if (document.getElementById("spn_supheader_" + i + "") != null) {
                document.getElementById("spn_supheader_" + i + "").innerHTML = "Supplier " + nu + "";
                nu++;
            }
        }
    }
    document.getElementById("div_scroll").scrollTop = 0;
}

function openpopup(spnid) {
    //    PopupCenter(strSitepath + "common/common_popup.aspx?type=Supplier&pg=" + modulename + "&item=Outwork&id=" + spnid + "", '950', '450');
    if (QueryType == "add") {
        if (ParentEstimateItemID == 0) {
            // PopupCenter(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "", '950', '450');
            //window.location = "" + strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "";
            window.radopen(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "", '950', '450');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }
        else {
            // PopupCenter(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&maintype=" + MainType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "", '950', '450');
            //window.location = "" + strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&maintype=" + MainType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "";
            window.radopen(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&maintype=" + MainType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "", '950', '450');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
    }
    else if (QueryType == "edit") {
        if (ParentEstimateItemID == 0) {
            //  PopupCenter(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "", '950', '450');
            //window.location = "" + strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "";
            window.radopen(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "", '950', '450');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            // PopupCenter(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "", '950', '450');
            //window.location = "" + strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "";
            window.radopen(strSitepath + "common/Client_add_new.aspx?type=Supplier&post=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "", '950', '450');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
    }
}

function openpopup_contact(spnid) {

    var supObj_1 = document.getElementById("ddlSupplier_" + spnid);

    var sup = new SupplierInfo();
    if (supObj_1 != null) {
        if (supObj_1.options[supObj_1.selectedIndex].value != '0') {
            //supplier Save
            var sup = new SupplierInfo();
            sup.SupplierID = supObj_1.options[supObj_1.selectedIndex].value;
        }
    }
    if (sup.SupplierID == 0 || sup.SupplierID == null) {
        alert("Please select the supplier to proceed");
    }

    else {

        if (QueryType == "add") {
            if (ParentEstimateItemID == 0) {
                // PopupCenter(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "", '950', '450');
                //window.location = "" + strSitepath + "contact/contact_add_main.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "";
                window.radopen(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "", '950', '450');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else {
                // PopupCenter(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&maintype=" + MainType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "", '950', '450');
                //window.location = "" + strSitepath + "contact/contact_add_main.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&maintype=" + MainType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "";
                window.radopen(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "", '950', '450');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
        }
        else if (QueryType == "edit") {
            if (ParentEstimateItemID == 0) {
                //  PopupCenter(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "", '950', '450');
                //window.location = "" + strSitepath + "contact/contact_add_main.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "";
                window.radopen(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&maintype=" + MainType + "", '950', '450');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else {
                // PopupCenter(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "", '950', '450');
                //window.location = "" + strSitepath + "contact/contact_add_main.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "";
                window.radopen(strSitepath + "contact/contact_add.aspx?type=Supplier&clientid=" + sup.SupplierID + "&pg=" + modulename + "&item=Outwork&id=" + spnid + "&mode=" + QueryType + "&estid=" + EstimateID + "&EstItemID=" + EstimateItemID + "&esttype=" + EstType + "&parentestitemid=" + ParentEstimateItemID + "&parentesttype=" + ParentEstimateType + "&subedit=y&sectionid=" + EstimateBookletItemID + "&maintype=" + MainType + "", '950', '450');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
    }
}


function loadContacts(val, num, conID) {

    var ddl = document.getElementById("ddlSupplierContact_" + num);
    var ddlsupp = document.getElementById("ddlSupplier_" + num);
    ddl.length = 0;
    ddl.options.add(new Option('--- Select ---', '0', 0));

    var k = 0;
    ///var strContArray = strContList.value.split('±');
    if (val == 0) {
        return false;
    }
    var defaultIndex = 0;

    PageMethods.GetContacts(CompanyID, val, function Clist(retnValue) {
        retnValue = retnValue.replace(/'/gi, "`");
        var strContArray = retnValue.split('±');
        var OptionDataContact = '';
        for (var j = 0; j < strContArray.length; j++) {
            var arr2 = strContArray[j].split('»');

            if (arr2[1] != '' && arr2[1] != null) {
                ddl.options.add(new Option(arr2[1], arr2[0], j));
                if (conID != null)//WHEN EDIT
                {
                    if (arr2[0] == conID) {
                        defaultIndex = Number(j) + 1;
                    }
                }
                else {
                    if (arr2[2] == 1) {
                        defaultIndex = Number(j) + 1;
                    }
                }
            }
            k++;
        }
        ddl.selectedIndex = defaultIndex;
    }, Clist_error);

}
function Clist_error(err) { }

function remove_supplier() {
    if (supCount != 2) {
        supCount = supCount - 1;
        var nu = Number(supCount);
        var ctrl;
        ctrl = document.getElementById('div_added');
        var chil = document.getElementById("div_supplier" + supCount + "");
        ctrl.removeChild(chil);
    }
}

function RemoveTableRow(nu) {
    var chil = document.getElementById("tr_" + nu + "");
    tableSup.removeChild(chil);

    var nu = 1;
    for (var i = 1; i < labelCount; i++) {
        if (document.getElementById("spn_supheader_" + i + "") != null) {
            document.getElementById("spn_supheader_" + i + "").innerHTML = "Supplier " + nu + "";
            nu++;
        }
    }

    IsSuptblEmpty = tableSup.rows.length == 0 ? "yes" : "no";
}

function RemoveThisSupplier(supCNT) {

    var supObj = document.getElementById("ddlSupplier_" + supCNT);
    if (supObj != null) {
        var PriceTable = document.getElementById("PriceTable");
        var chil = document.getElementById("Price_tr_" + supObj.id + "");
        if (chil != null) {
            PriceTable.removeChild(chil);
        }
        supCount--;
    }
}

function CheckQuoteReceived(chkid, divChk) {
    var chk = document.getElementById(chkid);
    if (chk.checked == true) {
        document.getElementById(divChk).style.display = "block";
    }
    else {
        document.getElementById(divChk).style.display = "none";
    }
}
function ChangeLabel() {
    // document.getElementById("lblheader").innerHTML=Stage4Name;
}

var qtyCount = 0;
var priceNo = 0;
function PbNextBtn(next, prev) {
    document.getElementById("div_qty").style.display = "none";
    document.getElementById("div_print_broker_step_1").style.display = "none";
    document.getElementById("div_print_broker_step_2").style.display = "none";
    document.getElementById("div_print_broker_step_3").style.display = "none";
    //summary                        
    document.getElementById(div_PrintBrokerSummary).style.display = "none";
    btn_Outwork_PrintEmail.style.display = "block";
    //document.getElementById("li_print_email").style.display="none";                        
    if (next == "1") {
        document.getElementById("div_print_broker_step_1").style.display = "block";
        document.getElementById("div_print_broker_step_2").style.display = "block";
        btn_Outwork_PrintEmail.style.display = "block";
        document.getElementById("lblheader").innerHTML = "RFQ Description and Supplier Selection";

        if ((modulename != "estimates")) {
            btn_Outwork_PrintEmail.style.display = "none";
        }
    }
    else if (next == "2") {
        CheckQtyType();
        document.getElementById("diverrorMessage").style.display = "none";
        if (Stpe1Vaild()) {
            document.getElementById("div_print_broker_step_2").style.display = "block";
            document.getElementById("lblheader").innerHTML = "Supplier selection";
            btn_Outwork_PrintEmail.style.display = "block";

            //document.getElementById("li_print_email").style.display="block";
        }
        else {
            document.getElementById("div_print_broker_step_1").style.display = "block";
            document.getElementById("lblheader").innerHTML = "RFQ description and supplier selection";
        }
    }
    else if (next == "3") {
        //to check the qty
        CheckQtyType();
        var supplierCount = labelCount - 1;
        if (Stpe1Vaild() && SupplierSelectionCheck()) {
            document.getElementById("div_print_broker_step_3").style.display = "block";
            document.getElementById("lblheader").innerHTML = "Price Comparison";

            if (ddlCostingType.selectedIndex == 0) {
                document.getElementById("div_simplecosting").style.display = "none";
                document.getElementById("div_unitcosting").style.display = "block";
                document.getElementById("div_per1000costing").style.display = "none";
            }
            if (ddlCostingType.selectedIndex == 1) {
                document.getElementById("div_simplecosting").style.display = "block";
                document.getElementById("div_unitcosting").style.display = "none";
                document.getElementById("div_per1000costing").style.display = "none";
            }
            if (ddlCostingType.selectedIndex == 2) {
                document.getElementById("div_simplecosting").style.display = "none";
                document.getElementById("div_unitcosting").style.display = "none";
                document.getElementById("div_per1000costing").style.display = "block";
            }

            //to create price comparision screen on click next button deone by smitha on 12/05/2011
            if (!IsEdit) {
                //document.getElementById("PriceTable").innerHTML = "";

                for (var s = 1; s <= supplierCount; s++) {
                    var supObj_12 = document.getElementById("ddlSupplier_" + s);
                    if (supObj_12 != null) {
                        if (supObj_12.options[supObj_12.selectedIndex].value != '0') {
                            if (Pricecompflag) {
                                CreatePriceComparison(supObj_12, ddlCostingType.selectedIndex);
                            }
                            if (s == supplierCount) {
                                Pricecompflag = false;
                            }
                        }
                    }
                }
            }


            //to get cursor for SupplierRefNo text box --  on 13/04/2011
            for (var i = 1; i <= supplierCount; i++) {

                var supObj = document.getElementById("ddlSupplier_" + 1);
                var ddlsupObj = document.getElementById("ddlSupplier_" + i); //by swetha

                if (supObj != null) {
                    if (supObj.options[supObj.selectedIndex].value != '0') {
                        var sup = new SupplierInfo();
                        sup.SupplierID = supObj.options[supObj.selectedIndex].value;
                        document.getElementById("txtRefNo_" + sup.SupplierID + "_" + 1 + "").focus();
                    }
                }

                ////new when changed qty after selecting the supplier -- on 6/1/2012
                if (ddlsupObj != null) {
                    if (ddlsupObj.options[ddlsupObj.selectedIndex].value != '0') {
                        var txtMultiQty1_new = txtMultiQty11.value;
                        var txtMultiQty2_new = txtMultiQty22.value;
                        var txtMultiQty3_new = txtMultiQty33.value;
                        var txtMultiQty4_new = txtMultiQty44.value;

                        var QtyValue_new = 0;

                        for (var k = 1; k <= qtyCount; k++) {
                            if (k == 1) {
                                QtyValue_new = txtMultiQty1_new;
                            }
                            else if (k == 2) {
                                QtyValue_new = txtMultiQty2_new;
                            }
                            else if (k == 3) {
                                QtyValue_new = txtMultiQty3_new;
                            }
                            else if (k == 4) {
                                QtyValue_new = txtMultiQty4_new;
                            }
                            var CountNew = ddlsupObj.options[ddlsupObj.selectedIndex].value + '_' + k;
                            document.getElementById("txtQty_" + CountNew + "").value = QtyValue_new;
                        }
                    }
                }
                ////END OF new when changed qty after selecting the supplier -- on 6/1/2012
            }
        }
        else {
            document.getElementById("div_print_broker_step_1").style.display = "block";
            document.getElementById("div_print_broker_step_2").style.display = "block";
            btn_Outwork_PrintEmail.style.display = "block";
            document.getElementById("lblheader").innerHTML = "RFQ Description and Supplier Selection";
        }
    }
    else if (next == "4") {

        if (Step4Validation()) {
            if (IsPrintBrokerDirect) {
                document.getElementById("div_stage_4").style.display = "block";
                document.getElementById(div_PrintBrokerSummary).style.display = "block";
                document.getElementById("lblheader").innerHTML = "Item Description";
                BindDefaultRFQData();
                //BindOutworkDesc();//To bind Outwork/Print Broker item description
                beforeChange = document.getElementById("div_load").innerHTML;
            }
            else {
                SaveOutWork();
                ShowOutworkList();
                document.getElementById("div_print_broker_step_1").style.display = "block";
                PrintBrokerPrevious('CreateItem');
                tempEstimateType = '';
            }
        }
        else {
            document.getElementById("div_print_broker_step_3").style.display = "block";
        }
    }
}

function DivPriceCompClear() {
    var doChnage = true;
    if (IsEdit && document.getElementById("div_load").innerHTML != '') {
        doChnage = window.confirm('If you change the Costing Type this will erase the Previous Data. Do want to go ? ');
    }
    if (doChnage) {
        DivPriceCompClear_part_2();
    }
    else {
        //When changes 
        ddlCostingType.value = ddlCostingType.value == "unit" ? "simple" : "unit";
    }
}

function DivPriceCompClear_part_2() {

    document.getElementById("div_load").innerHTML = '';
    for (var i = 1; i < labelCount; i++) {
        var supObj = document.getElementById("ddlSupplier_" + i);
        if (supObj != null) {
            var PriceTable = document.getElementById("PriceTable");
            var chil = document.getElementById("Price_tr_" + supObj.id + "");
            if (chil != null) {
                PriceTable.removeChild(chil);
            }
            supCount--;

            var contObj = document.getElementById("ddlSupplierContact_" + i);
            supObj.selectedIndex = 0;
            contObj.selectedIndex = 0;
        }
    }
}



function CopyDate(supplierID, RowCount, txtValue) {
    var tableObj = document.getElementById("PriceTable");
    var collection = tableObj.getElementsByTagName('INPUT');
    for (var x = 0; x < collection.length; x++) {
        var txtID = collection[x].id;
        if (collection[x].type.toUpperCase() == 'TEXT' && txtID.search("txtDeliveryDate_") > -1 && txtID.indexOf(supplierID) != -1) {
            if (collection[x].value == "") {
                collection[x].value = txtValue;
            }
        }
    }

    /*
    for(var i=1;i<=RowCount;i++)
    {
    if(document.getElementById("txtQty_"+supplierID+"_"+i+"").value!='')
    {
    if(txtValue!='')
    {
    document.getElementById("txtDeliveryDate_"+supplierID+"_"+i+"").value=txtValue;
    }
    }
    }
    */
}

function CopyMarkup(ddlvalue, supplierID, RowCount) {

    //    if (labelCount == 0) {
    var tableObj = document.getElementById("PriceTable");
    var collection = tableObj.getElementsByTagName('SELECT');
    for (var x = 0; x < collection.length; x++) {
        var ddlID = collection[x].id;
        if (ddlID.search("ddlMarkup_") > -1) {
            if (ddlvalue == 'fixedvalue') {
                collection[x].selectedIndex = 1;
            }
            else {
                collection[x].selectedIndex = 0;
            }
        }
    }

    for (var j = 1; j < labelCount; j++) {
        var supObj = document.getElementById("ddlSupplier_" + j);
        if (supObj != null) {
            var supValue = supObj.options[supObj.selectedIndex].value;
            if (supValue != '0') {
                for (var i = 1; i <= RowCount; i++) {
                    if (document.getElementById("txtQty_" + supValue + "_" + i + "").value != '') {
                        if (ddlvalue != '') {
                            var comnID = supValue + '_' + i;
                            CalculatePrice(comnID, 'c');
                        }
                    }
                }
            }
        }
    }
    //}

    /*for(var i=1;i<=RowCount;i++)
    {
    if(document.getElementById("txtQty_"+supplierID+"_"+i+"").value!='')
    {
    if(ddlvalue=='fixedvalue')
    {  
    document.getElementById("ddlMarkup_"+supplierID+"_"+i+"").selectedIndex=1;
    }
    else
    {
    document.getElementById("ddlMarkup_"+supplierID+"_"+i+"").selectedIndex=0;
    }
    }
    }
    */
}

function CopyMarkupValue(txtvalue, supplierID, RowCount) {
    var tableObj = document.getElementById("PriceTable");
    var collection = tableObj.getElementsByTagName('INPUT');
    for (var x = 0; x < collection.length; x++) {
        var txtID = collection[x].id;
        if (collection[x].type.toUpperCase() == 'TEXT' && txtID.search("txtMarkup_" + supplierID + "") > -1) {
            if (collection[x].value == "0.00") {
                collection[x].value = txtvalue;
            }
        }
    }

    //uncommented 
    for (var i = 1; i <= RowCount; i++) {
        if (document.getElementById("txtQty_" + supplierID + "_" + i + "").value != '') {
            if (txtvalue != '') {
                // document.getElementById("txtMarkup_" + supplierID + "_" + i + "").value = txtvalue;
                var comnID = supplierID + '_' + i;
                CalculatePrice(comnID, 'c');
            }
        }
    }

}

var beforechange = '';
function printbrokerprevious4() {
    document.getElementById("div_print_broker_step_3").style.display = "block";
    document.getElementById("lblheader").innerhtml = "price comparison";
    document.getElementById("div_stage_4").style.display = "none";
}

function CalculatePrice(ext, type) {
    var txtQty = document.getElementById("txtQty_" + ext).value;
    var txtCost = document.getElementById("txtCost_" + ext).value;
    var ddlDeliveryIncluded = document.getElementById("ddlDeliveryIncluded_" + ext).value;
    var txtDeliveryCost = document.getElementById("txtDeliveryCost_" + ext).value;
    var ddlMarkup = document.getElementById("ddlMarkup_" + ext).value;
    var txtMarkup = document.getElementById("txtMarkup_" + ext).value;
    var txtTotalPrice = document.getElementById("txtTotalPrice_" + ext);

    var costvalue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
    var Delivery = 0;
    var Markup = 0;
    var total = 0;
    var cost = 0;
    if (type == 'c') {
        if (trim12(txtCost) != '' && txtCost != costvalue) {
            if (ddlDeliveryIncluded == "no") {
                if (trim12(txtDeliveryCost) != '') {
                    Delivery = Number(txtDeliveryCost);
                }
            }

            //            if (ddlMarkup == "percentage") {
            //                Markup = Number((Number(txtCost) + Number(Delivery)) * Number(txtMarkup) / Number(100));
            //            }

            //            else if (ddlMarkup == "fixedvalue") {
            //                Markup = Number(txtMarkup);
            //            }
            //            if (ddlCostingType.value == 'unit') {
            //                Markup = Number(((Number(txtCost) * Number(txtQty)) + Number(Delivery)) * Number(txtMarkup) / Number(100));
            //                total = (Number(txtQty) * Number(txtCost)) + Number(Delivery) + Markup;
            //            }
            //            else {
            //                total = Number(txtCost) + Number(Delivery) + Number(Markup);
            //            }

            if (ddlCostingType.value == 'unit') {
                if (ddlMarkup == "percentage") {
                    Markup = Number(((Number(txtCost) * Number(txtQty)) + Number(Delivery)) * Number(txtMarkup) / Number(100));
                }
                else if (ddlMarkup == "fixedvalue") {
                    Markup = Number(txtMarkup);
                }
                total = (Number(txtQty) * Number(txtCost)) + Number(Delivery) + Markup;
            }
            else if (ddlCostingType.value == 'per1000') {
                if (ddlMarkup == "percentage") {
                    Markup = Number(((Number(txtCost) * Number(txtQty)) + Number(Delivery)) * Number(txtMarkup) / Number(100));
                }
                else if (ddlMarkup == "fixedvalue") {
                    Markup = Number(txtMarkup);
                }
                total = (Number(txtQty) * Number(txtCost)) + Number(Delivery) + Markup;
            }
            else {
                if (ddlMarkup == "percentage") {
                    Markup = Number((Number(txtCost) + Number(Delivery)) * Number(txtMarkup) / Number(100));
                }
                else if (ddlMarkup == "fixedvalue") {
                    Markup = Number(txtMarkup);
                }
                total = Number(txtCost) + Number(Delivery) + Number(Markup);
            }
            txtTotalPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total, 0, '', false, false, true);
            NumberToDecimal(txtTotalPrice.id, txtTotalPrice.value);
            txtMarkup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtMarkup, 0, '', false, false, true);
            txtMarkup = txtMarkup;
        }
        else {
            total = 0.00;
            txtTotalPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total, 0, '', false, false, true);
        }
    }
    else if (type == 'price') {
        if (trim12(txtCost) != '' && txtCost != costvalue) {
            if (ddlDeliveryIncluded == "no") {
                if (trim12(txtDeliveryCost) != '') {
                    Delivery = Number(txtDeliveryCost);
                }
            }
            if (ddlCostingType.value == 'unit') {
                cost = Number(((Number(txtCost) * Number(txtQty)) + Number(Delivery)));
            }
            else if (ddlCostingType.value == 'per1000') {
                cost = Number(((Number(txtCost) * Number(txtQty)) + Number(Delivery)));
            }
            else {
                cost = Number(txtCost) + Number(Delivery);
            }
            if (ddlMarkup == "percentage") {
                Markup = Number(((Number(txtTotalPrice.value) - cost)) / cost);
                Markup = (Markup * 100);
            }
            else if (ddlMarkup == "fixedvalue") {
                Markup = (Number(txtTotalPrice.value) - cost);
            }
            document.getElementById("txtMarkup_" + ext).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
            txtTotalPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtTotalPrice.value, 0, '', false, false, true);
            NumberToDecimal(txtTotalPrice.id, txtTotalPrice.value);
        }
    }
}


function SupplierSelectionCheck() {

    var IsValidToGo = false;
    var checkcnt = labelCount - 1;
    //duplicacy check
    var arr1 = new Array();
    var arr2 = new Array();
    for (var i = 1; i <= checkcnt; i++) {
        var supObj = document.getElementById("ddlSupplier_" + i);
        if (supObj != null) {
            var contObj = document.getElementById("ddlSupplierContact_" + i);
            var supValue = supObj.options[supObj.selectedIndex].value;
            if (supValue != "0") {
                IsValidToGo = true;
                arr1.push(supValue);
                arr2.push(supValue);
            }
        }
    }
    if (IsValidToGo == false) {
        document.getElementById("diverrorMessage").style.display = "block";
        document.getElementById("span_none").innerHTML = "Please select at least one supplier";
    }
    else {
        document.getElementById("diverrorMessage").style.display = "none";
    }
    /*
    for(var i=0;i<arr1.length;i++)
    {
    for(var j=0;j<arr2.length;j++)
    {
    if(i!=j)
    {
    if(arr1[i]==arr1[j])
    {
    IsValidToGo=false;
    document.getElementById("div_none").style.display="block";
    document.getElementById("span_none").innerHTML="Spplier Name is selected twice, please check once again !";
    }
    }
    }    
    }
    */
    return IsValidToGo;
}

function SelectOneSuppler(num) {

    var ComnIDArray = num.split('_');
    var RowIndex = ComnIDArray[1]; // by  VINAY
    var checkcnt = labelCount - 1;
    for (var i = 1; i <= checkcnt; i++) {
        var supObj = document.getElementById("ddlSupplier_" + i);
        if (supObj != null) {
            var supValue = supObj.options[supObj.selectedIndex].value;

            if (supValue != '0') {
                for (var j = 1; j <= qtyCount; j++) {
                    var comnID = supValue + '_' + j;
                    if (ComnIDArray[0] != supValue) {
                        if (j == RowIndex) {
                            if (document.getElementById("chk_" + num).checked) {
                                document.getElementById("chk_" + comnID).checked = false;
                            }
                            else {
                                //document.getElementById("chk_"+comnID).disabled = false;
                                //document.getElementById("chk_"+comnID).checked = true;
                            }
                        }
                    }


                }
                /*for(var j=1;j<=qtyCount;j++)
                {                            
                var comnID=supValue+'_'+j; 
                if(ComnIDArray[0]!=supValue)
                {
                document.getElementById("chk_"+comnID).checked=false;
                }
                }*/
            }
        }
    }
}

function SelectChkQty(num) {

    var ComnIDArray = num.split('_');
    var RowIndex = ComnIDArray[1]; // by  VINAY
    var checkcnt = labelCount - 1;
    document.getElementById("chk_" + num).checked = true;
    for (var i = 1; i <= checkcnt; i++) {
        var supObj = document.getElementById("ddlSupplier_" + i);
        if (supObj != null) {
            var supValue = supObj.options[supObj.selectedIndex].value;

            if (supValue != '0') {
                for (var j = 1; j <= qtyCount; j++) {
                    var comnID = supValue + '_' + j;
                    if (ComnIDArray[0] != supValue) {
                        if (j == RowIndex) {
                            if (document.getElementById("chk_" + num).checked) {
                                document.getElementById("chk_" + comnID).checked = false;
                            }
                            else {
                                //document.getElementById("chk_"+comnID).disabled = false;
                                //document.getElementById("chk_"+comnID).checked = true;
                            }
                        }
                    }


                }
                /*for(var j=1;j<=qtyCount;j++)
                {                            
                var comnID=supValue+'_'+j; 
                if(ComnIDArray[0]!=supValue)
                {
                document.getElementById("chk_"+comnID).checked=false;
                }
                }*/
            }
        }
    }
}


function Step4Validation() {

    var Chk_Count = 0;
    var EmptyCheck = true;
    var SupSelected = false;
    var checkcnt = labelCount - 1;
    for (var i = 1; i <= checkcnt; i++) {
        var supObj = document.getElementById("ddlSupplier_" + i);
        if (supObj != null) {
            var supValue = supObj.options[supObj.selectedIndex].value;
            if (supValue != '0') {
                for (var j = 1; j <= qtyCount; j++) {
                    var comnID = supValue + '_' + j;
                    if (trim12(document.getElementById("txtCost_" + comnID).value) == '' ||
                                trim12(document.getElementById("txtTotalPrice_" + comnID).value) == '') {
                        //EmptyCheck=false;
                    }
                    if (document.getElementById("txtQty_" + comnID).value != '' && Number(document.getElementById("txtQty_" + comnID).value) != 0) {
                        if (document.getElementById("chk_" + comnID).checked) {
                            SupSelected = true;
                            Chk_Count++;
                        }
                    }
                }
            }
        }
    }

    if (Chk_Count > 4) {
        //document.getElementById("div_none").style.display="block";
        document.getElementById("span_none").innerHTML = "Please select maximum of 4 quantities";
        return false;
    }
    if (EmptyCheck == false) {
        //document.getElementById("div_none").style.display="block";
        document.getElementById("span_none").innerHTML = "One of the information is missing, please enter";
        return false;
    }
    if (SupSelected == false) {
        // document.getElementById("div_none").style.display="block";
        document.getElementById("span_none").innerHTML = "Please select either 1 quantity or 4 quantities";
        return false;
    }
    return true;
}


function Stpe1Vaild() {
    var CheckStep1 = true;
    var CheckDate = true;

    //Commented the madatory feild validation for RFQ,By Rajeev on 14/10/2010
    //            if(txtRFQReturnDate.value=='')
    //            {
    //                CheckDate=false;
    //                document.getElementById("spn_txtRFQReturnDate").style.display="block";
    //            }
    //            else
    //            {
    //                document.getElementById("spn_txtRFQReturnDate").style.display="none";
    //            }
    var QtyValid = true;

    if (trim12(txtTitle.value) == '' || trim12(txtTitleDescription.value) == '') {
        CheckStep1 = false;
        document.getElementById("span_none").innerHTML = "Please enter Title";
    }
    else {
        if (qtyType == "single") {
            if (trim12(txtSingleQty.value) == '') {
                CheckStep1 = false;
                QtyValid = false;
            }
            else {
                var Test = Allow_Integer_Only(txtSingleQty, false);
                if (Test == false) {
                    document.getElementById("div_qty").style.display = "block";
                    document.getElementById("span_qty").innerHTML = "Please enter numeric value";
                    return false;
                }
            }
        }
        else if (qtyType == "runon") {
            if (trim12(txtRunQty1.value) == '' && trim12(txtRunQty2.value) == '') {
                CheckStep1 = false;
            }
        }
        else if (qtyType == "multiple") {
            if (trim12(txtMultiQty1.value) == '' && trim12(txtMultiQty2.value) == '' && trim12(txtMultiQty3.value) == ''
                        && trim12(txtMultiQty4.value) == '') {
                QtyValid = false;
                CheckStep1 = false;
            }
            else {
                var Test = true;
                if (txtMultiQty1.value != '') {
                    Test = Allow_Integer_Only(txtMultiQty1, false);
                    if (Test == false) {
                        document.getElementById("div_qty").style.display = "block";
                        document.getElementById("span_qty").innerHTML = "Please enter numeric value";
                        return false;
                    }
                }
                if (txtMultiQty2.value != '') {
                    Test = Allow_Integer_Only(txtMultiQty2, false);
                    if (Test == false) {
                        document.getElementById("div_qty").style.display = "block";
                        document.getElementById("span_qty").innerHTML = "Please enter numeric value";
                        return false;
                    }
                }
                if (txtMultiQty3.value != '') {
                    Test = Allow_Integer_Only(txtMultiQty3, false);
                    if (Test == false) {
                        document.getElementById("div_qty").style.display = "block";
                        document.getElementById("span_qty").innerHTML = "Please enter numeric value";
                        return false;
                    }
                }
                if (txtMultiQty4.value != '') {
                    Test = Allow_Integer_Only(txtMultiQty4, false);
                    if (Test == false) {
                        document.getElementById("div_qty").style.display = "block";
                        document.getElementById("span_qty").innerHTML = "Please enter numeric value";
                        return false;
                    }
                }
            }
        }
    }

    if (CheckDate == false) {
        return false;
    }

    if (CheckStep1 == false) {
        if (QtyValid == false) {
            document.getElementById("div_qty").style.display = "block";
            document.getElementById("span_qty").innerHTML = "Please enter at least one Quantity";
        }
        else {
            document.getElementById("diverrorMessage").style.display = "block";
            document.getElementById("span_none").style.display = "block";
            document.getElementById("span_none").innerHTML = "Please enter title";
        }

        return false;
    }
    return true;
}

function cleanForm(val) {
    Decrease(val);
    grow(val);
}
function grow(val) {
    var textareaa = document.getElementById(val);
    while (textareaa.scrollHeight > textareaa.clientHeight && !window.opera) {
        //textareaa.style.height='100%';  
        textareaa.rows += 1;
    }
}
function Decrease(val) {
    var textareaa = document.getElementById(val);
    while (textareaa.rows > 2) {
        textareaa.rows -= 1;
    }
    if (textareaa.rows == 1) {
        //textareaa.style.height='15px';
    }
}
function getName(RdID) {
    var Rdl = document.getElementById(RdID);
    var RdlName = Rdl.getElementsByTagName("input");
    return RdlName;
}

var qtyType;
var costType;
function CostSelected() {
    for (var k = 0; k < CostTypeArray.length; k++) {
        if (CostTypeArray[k].checked) {
            costType = CostTypeArray[k].value;
        }
    }
}
function QtySelected() {
    for (var i = 0; i < QtyTypeArray.length; i++) {
        if (QtyTypeArray[i].checked) {
            qtyType = QtyTypeArray[i].value;

        }
    }
}

var singlerun = false;
var PreviousVal = '';
function CheckQtyType(fromClick) {

    var winCon = true;
    if (fromClick == "yes") {
        /*
        winCon = window.confirm('Are you sure, it will Erase all data ?');
        if(winCon)
        {
        DivPriceCompClear_part_2();
        }
        */
    }
    if (winCon) {
        QtySelected();

        document.getElementById("div_singleQty").style.display = "none";
        document.getElementById("div_runQty").style.display = "none";
        document.getElementById("div_MultyQty").style.display = "none";

        if (qtyType == "single") {
            document.getElementById("div_singleQty").style.display = "block";
        }
        else if (qtyType == "multiple") {
            document.getElementById("div_MultyQty").style.display = "block";
        }
        else if (qtyType == "runon") {
            document.getElementById("div_runQty").style.display = "none";
        }
    }

    for (var i = 0; i < QtyTypeArray.length; i++) {
        if (QtyTypeArray[i].value == qtyType) {
            QtyTypeArray[i].checked = true;
        }
    }
}

function DropdownChange(obj, txtid) {
    var txt = document.getElementById(txtid);
    if (obj.value == 'no') {
        txt.disabled = false;
        txt.focus();
    }
    else {
        txt.value = "";
        txt.disabled = true;
    }
}

var ArrayBroker = new Array(); //This is for saving the Item Title in Print Broker for the case of Both main and  sub Item
function BrokerData() {
    this.Title = '';
    this.TitleDescription = '';
    this.Origination = '';
    this.OriginationDescription = '';
    this.Artwork = '';
    this.ArtworkDescription = '';
    this.Color = '';
    this.ColorDescription = '';
    this.Size = '';
    this.SizeDescription = '';
    this.Material = '';
    this.MaterialDescription = '';
    this.Finishing = '';
    this.FinishingDescription = '';
    this.Proofs = '';
    this.ProofsDescription = '';
    this.Packing = '';
    this.PackingDescription = '';
    this.Delivery = '';
    this.DeliveryDescription = '';
    this.Notes = '';
    this.NotesDescription = '';
    this.Terms = '';
    this.TermsDescription = '';

    // For New Fields
    this.CustomDescnLabel1 = '';
    this.CustomDescnPhraseValue1 = '';
    this.CustomDescnLabel2 = '';
    this.CustomDescnPhraseValue2 = '';
    this.CustomDescnLabel3 = '';
    this.CustomDescnPhraseValue3 = '';
    this.CustomDescnLabel4 = '';
    this.CustomDescnPhraseValue4 = '';
    this.CustomDescnLabel5 = '';
    this.CustomDescnPhraseValue5 = '';
    this.CustomDescnLabel6 = '';
    this.CustomDescnPhraseValue6 = '';
    this.CustomDescnLabel7 = '';
    this.CustomDescnPhraseValue7 = '';
    this.CustomDescnLabel8 = '';
    this.CustomDescnPhraseValue8 = '';
    this.CustomDescnLabel9 = '';
    this.CustomDescnPhraseValue9 = '';
    this.CustomDescnLabel10 = '';
    this.CustomDescnPhraseValue10 = '';
    this.CustomDescnLabel11 = '';
    this.CustomDescnPhraseValue11 = '';
    this.CustomDescnLabel12 = '';
    this.CustomDescnPhraseValue12 = '';
    this.CustomDescnLabel13 = '';
    this.CustomDescnPhraseValue13 = '';
    this.CustomDescnLabel14 = '';
    this.CustomDescnPhraseValue14 = '';
    this.CustomDescnLabel15 = '';
    this.CustomDescnPhraseValue15 = '';
    this.CustomDescnLabel16 = '';
    this.CustomDescnPhraseValue16 = '';
    this.CustomDescnLabel17 = '';
    this.CustomDescnPhraseValue17 = '';
    this.CustomDescnLabel18 = '';
    this.CustomDescnPhraseValue18 = '';
    this.CustomDescnLabel19 = '';
    this.CustomDescnPhraseValue19 = '';
    this.CustomDescnLabel20 = '';
    this.CustomDescnPhraseValue20 = '';
    this.CustomDescnLabel21 = '';
    this.CustomDescnPhraseValue21 = '';
    this.CustomDescnLabel22 = '';
    this.CustomDescnPhraseValue22 = '';
    this.CustomDescnLabel23 = '';
    this.CustomDescnPhraseValue23 = '';
    this.CustomDescnLabel24 = '';
    this.CustomDescnPhraseValue24 = '';
    this.CustomDescnLabel25 = '';
    this.CustomDescnPhraseValue25 = '';
    //End
}
var ArrayPrint = new Array();
function RFQData() {
    this.EstOutworkID = ''; //// For both EstItemOutworkID and EstOutworkID
    this.CostingType = '';
    this.RFQReturnDate = '';
    this.JobCompletionDate = '';
    this.ArtWork = '';
    this.Quantity = '';
    this.QtyType = '';
    this.Header = '';
    this.Footer = '';

    this.Title = '';
    this.TitleDescription = '';
    this.TitleIsChecked = '';
    this.Origination = '';
    this.OriginationDescription = '';
    this.OriginationIsChecked = '';
    this.Artwork = '';
    this.ArtworkDescription = '';
    this.ArtworkIsChecked = '';
    this.Color = '';
    this.ColorDescription = '';
    this.ColorIsChecked = '';
    this.Size = '';
    this.SizeDescription = '';
    this.SizeIsChecked = '';
    this.Material = '';
    this.MaterialDescription = '';
    this.MaterialIsChecked = '';
    this.Finishing = '';
    this.FinishingDescription = '';
    this.FinishingIsChecked = '';
    this.Proofs = '';
    this.ProofsDescription = '';
    this.ProofsIsChecked = '';
    this.Packing = '';
    this.PackingDescription = '';
    this.PackingIsChecked = '';
    this.Delivery = '';
    this.DeliveryDescription = '';
    this.DeliveryIsChecked = '';
    this.Notes = '';
    this.NotesDescription = '';
    this.NotesIsChecked = '';
    this.Terms = '';
    this.TermsDescription = '';
    this.TermsIsChecked = '';

    // For New Fields
    this.CustomDescnLabel1 = '';
    this.CustomDescnPhraseValue1 = '';
    this.CustomDescnIsChecked1 = '';

    this.CustomDescnLabel2 = '';
    this.CustomDescnPhraseValue2 = '';
    this.CustomDescnIsChecked2 = '';

    this.CustomDescnLabel3 = '';
    this.CustomDescnPhraseValue3 = '';
    this.CustomDescnIsChecked3 = '';

    this.CustomDescnLabel4 = '';
    this.CustomDescnPhraseValue4 = '';
    this.CustomDescnIsChecked4 = '';

    this.CustomDescnLabel5 = '';
    this.CustomDescnPhraseValue5 = '';
    this.CustomDescnIsChecked5 = '';

    this.CustomDescnLabel6 = '';
    this.CustomDescnPhraseValue6 = '';
    this.CustomDescnIsChecked6 = '';

    this.CustomDescnLabel7 = '';
    this.CustomDescnPhraseValue7 = '';
    this.CustomDescnIsChecked7 = '';

    this.CustomDescnLabel8 = '';
    this.CustomDescnPhraseValue8 = '';
    this.CustomDescnIsChecked8 = '';

    this.CustomDescnLabel9 = '';
    this.CustomDescnPhraseValue9 = '';
    this.CustomDescnIsChecked9 = '';

    this.CustomDescnLabel10 = '';
    this.CustomDescnPhraseValue10 = '';
    this.CustomDescnIsChecked10 = '';

    this.CustomDescnLabel11 = '';
    this.CustomDescnPhraseValue11 = '';
    this.CustomDescnIsChecked11 = '';

    this.CustomDescnLabel12 = '';
    this.CustomDescnPhraseValue12 = '';
    this.CustomDescnIsChecked12 = '';

    this.CustomDescnLabel13 = '';
    this.CustomDescnPhraseValue13 = '';
    this.CustomDescnIsChecked13 = '';

    this.CustomDescnLabel14 = '';
    this.CustomDescnPhraseValue14 = '';
    this.CustomDescnIsChecked14 = '';

    this.CustomDescnLabel15 = '';
    this.CustomDescnPhraseValue15 = '';
    this.CustomDescnIsChecked15 = '';

    this.CustomDescnLabel16 = '';
    this.CustomDescnPhraseValue16 = '';
    this.CustomDescnIsChecked16 = '';

    this.CustomDescnLabel17 = '';
    this.CustomDescnPhraseValue17 = '';
    this.CustomDescnIsChecked17 = '';

    this.CustomDescnLabel18 = '';
    this.CustomDescnPhraseValue18 = '';
    this.CustomDescnIsChecked18 = '';

    this.CustomDescnLabel19 = '';
    this.CustomDescnPhraseValue19 = '';
    this.CustomDescnIsChecked19 = '';

    this.CustomDescnLabel20 = '';
    this.CustomDescnPhraseValue20 = '';
    this.CustomDescnIsChecked20 = '';

    this.CustomDescnLabel21 = '';
    this.CustomDescnPhraseValue21 = '';
    this.CustomDescnIsChecked21 = '';

    this.CustomDescnLabel22 = '';
    this.CustomDescnPhraseValue22 = '';
    this.CustomDescnIsChecked22 = '';

    this.CustomDescnLabel23 = '';
    this.CustomDescnPhraseValue23 = '';
    this.CustomDescnIsChecked23 = '';

    this.CustomDescnLabel24 = '';
    this.CustomDescnPhraseValue24 = '';
    this.CustomDescnIsChecked24 = '';

    this.CustomDescnLabel25 = '';
    this.CustomDescnPhraseValue25 = '';
    this.CustomDescnIsChecked25 = '';
    //End

    this.SupplierList = [];
    this.PriceList = [];
}
function SupplierInfo() {
    this.SupplierID;
    this.SupplierName;
    this.ContactID;
}
function PriceComparison() {
    this.SupplierID;
    this.SupplierContactID;
    this.Quantity;
    this.Cost;
    this.DeliveryIncluded;
    this.DeliveryCost;
    this.DeliveryDate;
    this.MarkupType;
    this.MarkupValue;
    this.TotalPrice;
    this.IsSelected;
    this.IsMailSent;
    this.QuantityNumber;
    this.SupplierRefNo;
}

function SaveOutWork(para) {


    document.getElementById("div_print_broker_step_3").style.display = "none";
    var rfq = new RFQData();
    rfq.CostingType = ddlCostingType.value;
    rfq.RFQReturnDate = txtRFQReturnDate.value;
    rfq.JobCompletionDate = txtJobCompletionDate.value;
    rfq.ArtWork = UploadedFiles;                          //Files which are uploaded and there name    
    rfq.Header = spn_PrintBroker_Header.innerHTML;
    rfq.Footer = spn_PrintBroker_Footer.innerHTML;

    QtySelected();

    rfq.QtyType = qtyType;
    if (qtyType == "single") {
        rfq.Quantity = txtSingleQty1.value;
    }
    else if (qtyType == "multiple") {
        rfq.Quantity = txtMultiQty11.value + '|' + txtMultiQty22.value + '|' + txtMultiQty33.value + '|' + txtMultiQty44.value;
    }
    else if (qtyType == "runon") {
        rfq.Quantity = txtRunQty11.value + '|' + txtRunQty22.value;
    }

    //FOR PRINT EMAIL
    var QuantityList = rfq.Quantity;

    rfq.Title = txtTitle.value;
    rfq.TitleDescription = txtTitleDescription.value;
    rfq.TitleIsChecked = chkOutItemTitle.checked;

    rfq.Origination = txtOrigination.value;
    rfq.OriginationDescription = txtOriginationDescription.value;
    rfq.OriginationIsChecked = chkOutDescription.checked;

    rfq.Artwork = txtArtwork.value;
    rfq.ArtworkDescription = txtArtworkDescription.value;
    rfq.ArtworkIsChecked = chkOutArtwork.checked;

    rfq.Color = txtColor.value;
    rfq.ColorDescription = txtColorDescription.value;
    rfq.ColorIsChecked = chkOutColour.checked;

    rfq.Size = txtSize.value;
    rfq.SizeDescription = txtSizeDescription.value;
    rfq.SizeIsChecked = chkOutSize.checked;

    rfq.Material = txtMaterial.value;
    rfq.MaterialDescription = txtMaterialDescription.value;
    rfq.MaterialIsChecked = chkOutMaterial.checked;

    rfq.Finishing = txtFinishing.value;
    rfq.FinishingDescription = txtFinishingDescription.value;
    rfq.FinishingIsChecked = chkOutFinishing.checked;

    rfq.Delivery = txtDelivery.value;
    rfq.DeliveryDescription = txtDeliveryDescription.value;
    rfq.DeliveryIsChecked = chkOutDelivery.checked;

    rfq.Proofs = txtProofs.value;
    rfq.ProofsDescription = txtProofsDescription.value;
    rfq.ProofsIsChecked = chkOutProofs.checked;

    rfq.Packing = txtPacking.value;
    rfq.PackingDescription = txtPackingDescription.value;
    rfq.PackingIsChecked = chkOutPacking.checked;

    rfq.Notes = txtNotes.value;
    rfq.NotesDescription = txtNotesDescription.value;
    rfq.NotesIsChecked = chkOutNotes.checked;

    rfq.Terms = txtTerms.value;
    rfq.TermsDescription = txtTermsDescription.value;
    rfq.TermsIsChecked = chkOutInstructions.checked;

    // New Custom Fields
    rfq.CustomDescnLabel1 = txt_SuplierLabel1.value;
    rfq.CustomDescnPhraseValue1 = txt_SuplierValue1.value;
    rfq.CustomDescnIsChecked1 = Chk_SuplierDescn1.checked;

    rfq.CustomDescnLabel2 = txt_SuplierLabel2.value;
    rfq.CustomDescnPhraseValue2 = txt_SuplierValue2.value;
    rfq.CustomDescnIsChecked2 = Chk_SuplierDescn2.checked;

    rfq.CustomDescnLabel3 = txt_SuplierLabel3.value;
    rfq.CustomDescnPhraseValue3 = txt_SuplierValue3.value;
    rfq.CustomDescnIsChecked3 = Chk_SuplierDescn3.checked;

    rfq.CustomDescnLabel4 = txt_SuplierLabel4.value;
    rfq.CustomDescnPhraseValue4 = txt_SuplierValue4.value;
    rfq.CustomDescnIsChecked4 = Chk_SuplierDescn4.checked;

    rfq.CustomDescnLabel5 = txt_SuplierLabel5.value;
    rfq.CustomDescnPhraseValue5 = txt_SuplierValue5.value;
    rfq.CustomDescnIsChecked5 = Chk_SuplierDescn5.checked;

    rfq.CustomDescnLabel6 = txt_SuplierLabel6.value;
    rfq.CustomDescnPhraseValue6 = txt_SuplierValue6.value;
    rfq.CustomDescnIsChecked6 = Chk_SuplierDescn6.checked;

    rfq.CustomDescnLabel7 = txt_SuplierLabel7.value;
    rfq.CustomDescnPhraseValue7 = txt_SuplierValue7.value;
    rfq.CustomDescnIsChecked7 = Chk_SuplierDescn7.checked;

    rfq.CustomDescnLabel8 = txt_SuplierLabel8.value;
    rfq.CustomDescnPhraseValue8 = txt_SuplierValue8.value;
    rfq.CustomDescnIsChecked8 = Chk_SuplierDescn8.checked;

    rfq.CustomDescnLabel9 = txt_SuplierLabel9.value;
    rfq.CustomDescnPhraseValue9 = txt_SuplierValue9.value;
    rfq.CustomDescnIsChecked9 = Chk_SuplierDescn9.checked;

    rfq.CustomDescnLabel10 = txt_SuplierLabel10.value;
    rfq.CustomDescnPhraseValue10 = txt_SuplierValue10.value;
    rfq.CustomDescnIsChecked10 = Chk_SuplierDescn10.checked;

    rfq.CustomDescnLabel11 = txt_SuplierLabel1.value;
    rfq.CustomDescnPhraseValue11 = txt_SuplierValue11.value;
    rfq.CustomDescnIsChecked11 = Chk_SuplierDescn11.checked;

    rfq.CustomDescnLabel12 = txt_SuplierLabel12.value;
    rfq.CustomDescnPhraseValue12 = txt_SuplierValue12.value;
    rfq.CustomDescnIsChecked12 = Chk_SuplierDescn11.checked;

    rfq.CustomDescnLabel13 = txt_SuplierLabel13.value;
    rfq.CustomDescnPhraseValue13 = txt_SuplierValue13.value;
    rfq.CustomDescnIsChecked13 = Chk_SuplierDescn13.checked;

    rfq.CustomDescnLabel14 = txt_SuplierLabel14.value;
    rfq.CustomDescnPhraseValue14 = txt_SuplierValue14.value;
    rfq.CustomDescnIsChecked14 = Chk_SuplierDescn14.checked;

    rfq.CustomDescnLabel15 = txt_SuplierLabel15.value;
    rfq.CustomDescnPhraseValue15 = txt_SuplierValue15.value;
    rfq.CustomDescnIsChecked15 = Chk_SuplierDescn15.checked;

    rfq.CustomDescnLabel16 = txt_SuplierLabel16.value;
    rfq.CustomDescnPhraseValue16 = txt_SuplierValue16.value;
    rfq.CustomDescnIsChecked16 = Chk_SuplierDescn16.checked;

    rfq.CustomDescnLabel17 = txt_SuplierLabel17.value;
    rfq.CustomDescnPhraseValue17 = txt_SuplierValue17.value;
    rfq.CustomDescnIsChecked17 = Chk_SuplierDescn17.checked;

    rfq.CustomDescnLabel18 = txt_SuplierLabel18.value;
    rfq.CustomDescnPhraseValue18 = txt_SuplierValue18.value;
    rfq.CustomDescnIsChecked18 = Chk_SuplierDescn18.checked;

    rfq.CustomDescnLabel19 = txt_SuplierLabel19.value;
    rfq.CustomDescnPhraseValue19 = txt_SuplierValue19.value;
    rfq.CustomDescnIsChecked19 = Chk_SuplierDescn19.checked;

    rfq.CustomDescnLabel20 = txt_SuplierLabel20.value;
    rfq.CustomDescnPhraseValue20 = txt_SuplierValue20.value;
    rfq.CustomDescnIsChecked20 = Chk_SuplierDescn20.checked;

    rfq.CustomDescnLabel21 = txt_SuplierLabel21.value;
    rfq.CustomDescnPhraseValue21 = txt_SuplierValue21.value;
    rfq.CustomDescnIsChecked21 = Chk_SuplierDescn21.checked;

    rfq.CustomDescnLabel22 = txt_SuplierLabel22.value;
    rfq.CustomDescnPhraseValue22 = txt_SuplierValue22.value;
    rfq.CustomDescnIsChecked22 = Chk_SuplierDescn22.checked;

    rfq.CustomDescnLabel23 = txt_SuplierLabel23.value;
    rfq.CustomDescnPhraseValue23 = txt_SuplierValue23.value;
    rfq.CustomDescnIsChecked23 = Chk_SuplierDescn23.checked;

    rfq.CustomDescnLabel24 = txt_SuplierLabel24.value;
    rfq.CustomDescnPhraseValue24 = txt_SuplierValue24.value;
    rfq.CustomDescnIsChecked24 = Chk_SuplierDescn24.checked;

    rfq.CustomDescnLabel25 = txt_SuplierLabel25.value;
    rfq.CustomDescnPhraseValue25 = txt_SuplierValue25.value;
    rfq.CustomDescnIsChecked25 = Chk_SuplierDescn25.checked;
    //End


    //FOR PHRASE BOOK
    var rfq_data = new BrokerData();
    if (chk_broker_Phrase_Title.checked) {
        rfq_data.Title = txtTitle.value;
        rfq_data.TitleDescription = txtTitleDescription.value;
    }
    if (chk_broker_Phrase_Design.checked) {
        rfq_data.Origination = txtOrigination.value;
        rfq_data.OriginationDescription = txtOriginationDescription.value;
    }
    if (chk_broker_Phrase_Artwork.checked) {
        rfq_data.Artwork = txtArtwork.value;
        rfq_data.ArtworkDescription = txtArtworkDescription.value;
    }
    if (chk_broker_Phrase_Color.checked) {
        rfq_data.Color = txtColor.value;
        rfq_data.ColorDescription = txtColorDescription.value;
    }
    if (chk_broker_Phrase_Size.checked) {
        rfq_data.Size = txtSize.value;
        rfq_data.SizeDescription = txtSizeDescription.value;
    }
    if (chk_broker_Phrase_Material.checked) {
        rfq_data.Material = txtMaterial.value;
        rfq_data.MaterialDescription = txtMaterialDescription.value;
    }
    if (chk_broker_Phrase_Finishing.checked) {
        rfq_data.Finishing = txtFinishing.value;
        rfq_data.FinishingDescription = txtFinishingDescription.value;
    }
    if (chk_broker_Phrase_Delivery.checked) {
        rfq_data.Delivery = txtDelivery.value;
        rfq_data.DeliveryDescription = txtDeliveryDescription.value;
    }

    if (chk_broker_Phrase_Proofs.checked) {
        rfq_data.Proofs = txtProofs.value;
        rfq_data.ProofsDescription = txtProofsDescription.value;
    }
    if (chk_broker_Phrase_Packing.checked) {
        rfq_data.Packing = txtPacking.value;
        rfq_data.PackingDescription = txtPackingDescription.value;
    }
    if (chk_broker_Phrase_Notes.checked) {
        rfq_data.Notes = txtNotes.value;
        rfq_data.NotesDescription = txtNotesDescription.value;
    }
    if (chk_broker_Phrase_Terms.checked) {
        rfq_data.Terms = txtTerms.value;
        rfq_data.TermsDescription = txtTermsDescription.value;
    }
    // New Custom Fields
    if (Chk_DescnsToPhrase1.checked) {
        rfq_data.CustomDescnLabel1 = txt_SuplierLabel1.value;
        rfq_data.CustomDescnPhraseValue1 = txt_SuplierValue1.value;
    }
    if (Chk_DescnsToPhrase2.checked) {
        rfq_data.CustomDescnLabel2 = txt_SuplierLabel2.value;
        rfq_data.CustomDescnPhraseValue2 = txt_SuplierValue2.value;
    }
    if (Chk_DescnsToPhrase3.checked) {
        rfq_data.CustomDescnLabel3 = txt_SuplierLabel3.value;
        rfq_data.CustomDescnPhraseValue3 = txt_SuplierValue3.value;
    }
    if (Chk_DescnsToPhrase4.checked) {
        rfq_data.CustomDescnLabel4 = txt_SuplierLabel4.value;
        rfq_data.CustomDescnPhraseValue4 = txt_SuplierValue4.value;
    }
    if (Chk_DescnsToPhrase5.checked) {
        rfq_data.CustomDescnLabel5 = txt_SuplierLabel5.value;
        rfq_data.CustomDescnPhraseValue5 = txt_SuplierValue5.value;
    }
    if (Chk_DescnsToPhrase6.checked) {
        rfq_data.CustomDescnLabel6 = txt_SuplierLabel6.value;
        rfq_data.CustomDescnPhraseValue6 = txt_SuplierValue6.value;
    }
    if (Chk_DescnsToPhrase7.checked) {
        rfq_data.CustomDescnLabel7 = txt_SuplierLabel7.value;
        rfq_data.CustomDescnPhraseValue7 = txt_SuplierValue7.value;
    }
    if (Chk_DescnsToPhrase8.checked) {
        rfq_data.CustomDescnLabel8 = txt_SuplierLabel8.value;
        rfq_data.CustomDescnPhraseValue8 = txt_SuplierValue8.value;
    }
    if (Chk_DescnsToPhrase9.checked) {
        rfq_data.CustomDescnLabel9 = txt_SuplierLabel9.value;
        rfq_data.CustomDescnPhraseValue9 = txt_SuplierValue9.value;
    }
    if (Chk_DescnsToPhrase10.checked) {
        rfq_data.CustomDescnLabel10 = txt_SuplierLabel10.value;
        rfq_data.CustomDescnPhraseValue10 = txt_SuplierValue10.value;
    }
    if (Chk_DescnsToPhrase11.checked) {
        rfq_data.CustomDescnLabel11 = txt_SuplierLabel1.value;
        rfq_data.CustomDescnPhraseValue11 = txt_SuplierValue11.value;
    }
    if (Chk_DescnsToPhrase12.checked) {
        rfq_data.CustomDescnLabel2 = txt_SuplierLabel12.value;
        rfq_data.CustomDescnPhraseValue12 = txt_SuplierValue12.value;
    }
    if (Chk_DescnsToPhrase13.checked) {
        rfq_data.CustomDescnLabel13 = txt_SuplierLabel13.value;
        rfq_data.CustomDescnPhraseValue13 = txt_SuplierValue13.value;
    }
    if (Chk_DescnsToPhrase14.checked) {
        rfq_data.CustomDescnLabel14 = txt_SuplierLabel14.value;
        rfq_data.CustomDescnPhraseValue14 = txt_SuplierValue14.value;
    }
    if (Chk_DescnsToPhrase15.checked) {
        rfq_data.CustomDescnLabel15 = txt_SuplierLabel15.value;
        rfq_data.CustomDescnPhraseValue15 = txt_SuplierValue15.value;
    }
    if (Chk_DescnsToPhrase16.checked) {
        rfq_data.CustomDescnLabel16 = txt_SuplierLabel16.value;
        rfq_data.CustomDescnPhraseValue16 = txt_SuplierValue16.value;
    }
    if (Chk_DescnsToPhrase17.checked) {
        rfq_data.CustomDescnLabel17 = txt_SuplierLabel17.value;
        rfq_data.CustomDescnPhraseValue17 = txt_SuplierValue17.value;
    }
    if (Chk_DescnsToPhrase18.checked) {
        rfq_data.CustomDescnLabel18 = txt_SuplierLabel18.value;
        rfq_data.CustomDescnPhraseValue18 = txt_SuplierValue18.value;
    }
    if (Chk_DescnsToPhrase19.checked) {
        rfq_data.CustomDescnLabel19 = txt_SuplierLabel19.value;
        rfq_data.CustomDescnPhraseValue19 = txt_SuplierValue19.value;
    }
    if (Chk_DescnsToPhrase20.checked) {
        rfq_data.CustomDescnLabel20 = txt_SuplierLabel20.value;
        rfq_data.CustomDescnPhraseValue20 = txt_SuplierValue20.value;
    }
    if (Chk_DescnsToPhrase21.checked) {
        rfq_data.CustomDescnLabel21 = txt_SuplierLabel21.value;
        rfq_data.CustomDescnPhraseValue21 = txt_SuplierValue21.value;
    }
    if (Chk_DescnsToPhrase22.checked) {
        rfq_data.CustomDescnLabel22 = txt_SuplierLabel22.value;
        rfq_data.CustomDescnPhraseValue22 = txt_SuplierValue22.value;
    }
    if (Chk_DescnsToPhrase23.checked) {
        rfq_data.CustomDescnLabel23 = txt_SuplierLabel23.value;
        rfq_data.CustomDescnPhraseValue23 = txt_SuplierValue23.value;
    }
    if (Chk_DescnsToPhrase24.checked) {
        rfq_data.CustomDescnLabel24 = txt_SuplierLabel24.value;
        rfq_data.CustomDescnPhraseValue24 = txt_SuplierValue24.value;
    }
    if (Chk_DescnsToPhrase25.checked) {
        rfq_data.CustomDescnLabel25 = txt_SuplierLabel25.value;
        rfq_data.CustomDescnPhraseValue25 = txt_SuplierValue25.value;
    }
    //End

    var PCount = 0;
    var supplierCount = labelCount - 1;

    if (para == 'printemail') {

        if (!IsEdit) {
            var JustCount = 0;
            for (var i = 1; i <= supplierCount; i++) {
                var supObj = document.getElementById("ddlSupplier_" + i);
                var contObj = document.getElementById("ddlSupplierContact_" + i);
                if (supObj != null) {
                    if (supObj.options[supObj.selectedIndex].value != '0') {
                        //supplier Save
                        var sup = new SupplierInfo();
                        sup.SupplierID = supObj.options[supObj.selectedIndex].value;
                        sup.SupplierName = supObj.options[supObj.selectedIndex].text;
                        if (contObj.options[contObj.selectedIndex].value != '0') {
                            sup.ContactID = contObj.options[contObj.selectedIndex].value;
                        }
                        else {
                            sup.ContactID = '0';
                        }
                        rfq.SupplierList[i - 1] = sup;        ////i=1                               

                        var priceCount = 0;
                        var QtyArray = QuantityList.split('|');
                        for (var j = 0; j <= QtyArray.length; j++) {
                            if (QtyArray[j] != '') {
                                var PriceComp = new PriceComparison();
                                PriceComp.SupplierRefNo = "";
                                PriceComp.SupplierID = sup.SupplierID;
                                PriceComp.SupplierContactID = sup.ContactID;
                                PriceComp.Quantity = QtyArray[j];
                                PriceComp.Cost = "0";
                                PriceComp.DeliveryIncluded = "no";
                                PriceComp.DeliveryDate = "";
                                PriceComp.DeliveryCost = "0";
                                PriceComp.MarkupType = "percentage";
                                PriceComp.MarkupValue = "0";
                                PriceComp.TotalPrice = "0";
                                //PriceComp.IsSelected = JustCount == "0" ? "true" : "false";
                                PriceComp.IsSelected = "false";
                                PriceComp.QuantityNumber = Number(Number(j) + Number(1));
                                PriceComp.SupplierRefNo = "";
                                rfq.PriceList[PCount] = PriceComp; //j=1
                                priceCount++;
                                PCount++;
                                JustCount++;
                            }
                        }
                    }
                }
            }
        }
        else {

            var chkSupCount = 0;
            var chkSupQtyCount = 0;
            var chkQtyNotChecked = 0;
            //chkQtyNotChecked = (supplierCount * qtyCount);
            for (var i = 1; i <= supplierCount; i++) {
                var supObj = document.getElementById("ddlSupplier_" + i);
                var contObj = document.getElementById("ddlSupplierContact_" + i);
                if (supObj != null) {
                    if (supObj.options[supObj.selectedIndex].value != '0') {
                        //supplier Save
                        var sup = new SupplierInfo();
                        sup.SupplierID = supObj.options[supObj.selectedIndex].value;
                        sup.SupplierName = supObj.options[supObj.selectedIndex].text;
                        if (contObj.options[contObj.selectedIndex].value != '0') {
                            sup.ContactID = contObj.options[contObj.selectedIndex].value;
                        }
                        else {
                            sup.ContactID = '0';
                        }
                        var SupRefNO = document.getElementById("txtRefNo_" + sup.SupplierID + "_1") == null ? "" : document.getElementById("txtRefNo_" + sup.SupplierID + "_1").value;
                        rfq.SupplierList[i - 1] = sup;        ////i=1
                        //PriceList Save
                        //txtQty_  txtCost_    ddlDeliveryIncluded_    txtDeliveryDate_
                        var priceCount = 0;

                        for (var j = 1; j <= qtyCount; j++) {
                            var comnId = sup.SupplierID + '_' + j;
                            //if(document.getElementById("txtQty_"+comnId).value!="0" && document.getElementById("txtQty_"+comnId).value!='')
                            //{
                            var PriceComp = new PriceComparison();
                            PriceComp.SupplierID = sup.SupplierID;
                            PriceComp.SupplierContactID = sup.ContactID;
                            PriceComp.Quantity = document.getElementById("txtQty_" + comnId).value;
                            PriceComp.Cost = document.getElementById("txtCost_" + comnId).value;
                            PriceComp.DeliveryIncluded = document.getElementById("ddlDeliveryIncluded_" + comnId).value;
                            PriceComp.DeliveryDate = document.getElementById("txtDeliveryDate_" + comnId).value;
                            PriceComp.DeliveryCost = document.getElementById("txtDeliveryCost_" + comnId).value;
                            PriceComp.MarkupType = document.getElementById("ddlMarkup_" + comnId).value;
                            PriceComp.MarkupValue = document.getElementById("txtMarkup_" + comnId).value;
                            PriceComp.TotalPrice = document.getElementById("txtTotalPrice_" + comnId).value;
                            PriceComp.IsSelected = document.getElementById("chk_" + comnId).checked;
                            PriceComp.QuantityNumber = j;
                            PriceComp.SupplierRefNo = SupRefNO;
                            rfq.PriceList[PCount] = PriceComp; ////j=1                                
                            priceCount++;


                            //To validate for at least one Supplier check in Estimates                          
                            if (document.getElementById("chk_" + comnId).checked) {
                                if (document.getElementById("txtQty_" + comnId).value != "") {
                                    chkSupQtyCount++;
                                }
                                chkSupCount++;
                            }

                            //To validate for Qty check in Job & Invoice
                            if ((modulename != "estimates")) {
                                if (document.getElementById("chk_" + comnId).checked) {
                                    if (qtyType == "single") {
                                        chkQtyNotChecked++;
                                    }
                                    else if (j == QtyNumber) {
                                        chkQtyNotChecked++;
                                    }
                                }
                            }
                            PCount++;
                        }
                    }
                }
            }

            if (chkSupCount <= 0) {
                //defaultly setting the values in print/email case

                chkSupQtyCount++;
                chkSupCount++
                rfq.PriceList[0].IsSelected = "true";
            }
        }
    }
    else {

        var chkSupCount = 0;
        var chkSupQtyCount = 0;
        var chkQtyNotChecked = 0;
        //chkQtyNotChecked = (supplierCount * qtyCount);
        for (var i = 1; i <= supplierCount; i++) {
            var supObj = document.getElementById("ddlSupplier_" + i);
            var contObj = document.getElementById("ddlSupplierContact_" + i);
            if (supObj != null) {
                if (supObj.options[supObj.selectedIndex].value != '0') {
                    //supplier Save
                    var sup = new SupplierInfo();
                    sup.SupplierID = supObj.options[supObj.selectedIndex].value;
                    sup.SupplierName = supObj.options[supObj.selectedIndex].text;
                    if (contObj.options[contObj.selectedIndex].value != '0') {
                        sup.ContactID = contObj.options[contObj.selectedIndex].value;
                    }
                    else {
                        sup.ContactID = '0';
                    }
                    var SupRefNO = document.getElementById("txtRefNo_" + sup.SupplierID + "_1").value;
                    rfq.SupplierList[i - 1] = sup;        ////i=1
                    //PriceList Save
                    //txtQty_  txtCost_    ddlDeliveryIncluded_    txtDeliveryDate_
                    var priceCount = 0;
                    for (var j = 1; j <= qtyCount; j++) {
                        var comnId = sup.SupplierID + '_' + j;
                        //if(document.getElementById("txtQty_"+comnId).value!="0" && document.getElementById("txtQty_"+comnId).value!='')
                        //{

                        var PriceComp = new PriceComparison();
                        PriceComp.SupplierID = sup.SupplierID;
                        PriceComp.SupplierContactID = sup.ContactID;
                        PriceComp.Quantity = document.getElementById("txtQty_" + comnId).value;
                        PriceComp.Cost = document.getElementById("txtCost_" + comnId).value;
                        PriceComp.DeliveryIncluded = document.getElementById("ddlDeliveryIncluded_" + comnId).value;
                        PriceComp.DeliveryDate = document.getElementById("txtDeliveryDate_" + comnId).value;
                        PriceComp.DeliveryCost = document.getElementById("txtDeliveryCost_" + comnId).value;
                        PriceComp.MarkupType = document.getElementById("ddlMarkup_" + comnId).value;
                        PriceComp.MarkupValue = document.getElementById("txtMarkup_" + comnId).value;
                        PriceComp.TotalPrice = document.getElementById("txtTotalPrice_" + comnId).value;
                        PriceComp.IsSelected = document.getElementById("chk_" + comnId).checked;
                        PriceComp.QuantityNumber = j;
                        PriceComp.SupplierRefNo = SupRefNO;
                        rfq.PriceList[PCount] = PriceComp; ////j=1                                
                        priceCount++;

                        //To validate for at least one Supplier check in Estimates
                        if (document.getElementById("chk_" + comnId).checked) {
                            if (document.getElementById("txtQty_" + comnId).value != "") {
                                chkSupQtyCount++;
                            }
                            chkSupCount++;
                        }

                        //To validate for Qty check in Job & Invoice
                        if ((modulename != "estimates")) {
                            if (document.getElementById("chk_" + comnId).checked) {
                                if (qtyType == "single") {
                                    chkQtyNotChecked++;
                                }
                                else if (j == QtyNumber) {
                                    chkQtyNotChecked++;
                                }
                            }
                        }


                        //To validate for at least one Supplier check 
                        //}    
                        PCount++;
                    }
                }
            }
        }
    }
    //To validate for at least one Supplier check (supplierCount * qtyCount)
    if (chkSupCount <= 0 || (chkQtyNotChecked == 0 && (modulename != "estimates"))) {
        getcheck = true;
    }
    else {
        getcheck = false;
    }

    getqtycheck = chkSupQtyCount <= 0 ? true : false;

    //To validate for at least one Supplier check

    //if (getcheck == false && getqtycheck == false) {
    if (IsEdit) {
        rfq.EstOutworkID = ArrayPrint[EditNo].EstOutworkID;
        ArrayPrint.splice(EditNo, 1);

        ArrayPrint.push(rfq);
        ArrayBroker.push(rfq_data);
    }
    else //when add
    {
        ArrayPrint.push(rfq);
        ArrayBroker.push(rfq_data);
    }

    document.getElementById("span_none").style.display = "none";
    ClearAllPrintProker();
    //}
}

function RemoveOutWork(ids) {
    ArrayPrint.splice(ids, 1);
    ArrayBroker.splice(ids, 1);
    ShowOutworkList();
}

function ShowOutworkList() {
    var completeData = '';
    var dd = '';

    if (ArrayPrint.length > 0) {
        document.getElementById("href_ShowOutwork").style.display = "block";
    }
    else {
        document.getElementById("href_ShowOutwork").style.display = "none";
    }
    for (var i = 0; i < ArrayPrint.length; i++) {
        dd += "<div align='left' style='height:20px;'>";
        if (ArrayPrint[i].EstOutworkID == '') {
            dd += "<div style='float:left;width:220px;overflow:hidden;'>" + ArrayPrint[i].Title + "</div>";
        }
        else {
            dd += "<div style='float:left;width:220px;overflow:hidden;'><a href='#' onclick='ShowPrintBroker();LoadToPBbox(" + i + ")'>" + ArrayPrint[i].Title + "</a></div>";
        }
        dd += "<div style='float:left;'><a href='#' onclick=javascript:RemoveOutWork(" + i + "); class='normaltext'>Remove</a></div>";
        dd += "</div>";
        /*
        WORKING CODE
        var supArr=ArrayPrint[i].SupplierList;
        for(j=0;j<supArr.length;j++)
        {
        }    
        var pirArr=ArrayPrint[i].PriceList;
        for(k=0;k<pirArr.length;k++)
        {
        }      
        */
    }
    document.getElementById("div_OutworkItems_Add").innerHTML = dd;
}

function ClearAllPrintProker() {
    //BindOutworkDesc();//To Bind RFQ DATA on Sub Item ADD case//
    ddlCostingType.selectedIndex = 0;
    txtRFQReturnDate.value = '';
    txtJobCompletionDate.value = '';
    UploadedFiles = '';

    txtSingleQty.value = '';
    txtRunQty1.value = '';
    txtRunQty2.value = '';
    txtMultiQty1.value = '';
    txtMultiQty2.value = '';
    txtMultiQty3.value = '';
    txtMultiQty4.value = '';

    document.getElementById("div_added").innerHTML = "";
    for (var i = tableSup.rows.length; i > 0; i--) {
        tableSup.deleteRow(i - 1);
    }
    var PriceTable = document.getElementById("PriceTable");
    for (var i = PriceTable.rows.length; i > 0; i--) {
        PriceTable.deleteRow(i - 1);
    }
    supCount = 1;
    labelCount = 1;
    IsEdit = false;
    for (var i = 0; i < QtyTypeArray.length; i++) {
        QtyTypeArray[i].disabled = false;
    }
    chk_broker_Phrase_Title.checked = false;
    chk_broker_Phrase_Design.checked = false;
    chk_broker_Phrase_Artwork.checked = false;
    chk_broker_Phrase_Color.checked = false;
    chk_broker_Phrase_Size.checked = false;
    chk_broker_Phrase_Material.checked = false;
    chk_broker_Phrase_Finishing.checked = false;
    chk_broker_Phrase_Delivery.checked = false;
    chk_broker_Phrase_Notes.checked = false;
    chk_broker_Phrase_Terms.checked = false;
    IsEntered = false;
    roundTrip = 0;
}

function Use_add_more() {
    QtySelected();
    add_more(); //supplier 1
    add_more(); //supplier 2
    add_more(); //supplier 3
    //add_more(); //supplier 4
    //add_more(); //supplier 5
}


function LoadToPBbox(s) {
    var DateFormatNEW = dateformatnew();
    IsEdit = true;
    EditNo = s;
    //var MarkupOpns = GetMarkuptype();

    // *** Check Box's Check & Uncheck Condition, on 17.08.2011 ***//

    if (ArrayPrint[s].TitleIsChecked == "False") {
        chkOutItemTitle.checked = false;
    }
    else {
        chkOutItemTitle.checked = true;
    }

    if (ArrayPrint[s].OriginationIsChecked == "False") {
        chkOutDescription.checked = false;
    }
    else {
        chkOutDescription.checked = true;
    }

    if (ArrayPrint[s].ArtworkIsChecked == "False") {
        chkOutArtwork.checked = false;
    }
    else {
        chkOutArtwork.checked = true;
    }

    if (ArrayPrint[s].ColorIsChecked == "False") {
        chkOutColour.checked = false;
    }
    else {
        chkOutColour.checked = true;
    }

    if (ArrayPrint[s].SizeIsChecked == "False") {
        chkOutSize.checked = false;
    }
    else {
        chkOutSize.checked = true;
    }

    if (ArrayPrint[s].MaterialIsChecked == "False") {
        chkOutMaterial.checked = false;
    }
    else {
        chkOutMaterial.checked = true;
    }

    if (ArrayPrint[s].FinishingIsChecked == "False") {
        chkOutFinishing.checked = false;
    }
    else {
        chkOutFinishing.checked = true;
    }

    if (ArrayPrint[s].DeliveryIsChecked == "False") {
        chkOutDelivery.checked = false;
    }
    else {
        chkOutDelivery.checked = true;
    }

    if (ArrayPrint[s].NotesIsChecked == "False") {
        chkOutNotes.checked = false;
    }
    else {
        chkOutNotes.checked = true;
    }
    if (ArrayPrint[s].ProofsIsChecked == "False") {
        chkOutProofs.checked = false;
    }
    else {
        chkOutProofs.checked = true;
    }
    if (ArrayPrint[s].TermsIsChecked == "False") {
        chkOutInstructions.checked = false;
    }
    else {
        chkOutInstructions.checked = true;
    }
    if (ArrayPrint[s].PackingIsChecked == "False") {
        chkOutPacking.checked = false;
    }
    else {
        chkOutPacking.checked = true;
    }
    txtTitle.value = ArrayPrint[s].Title;
    txtTitleDescription.value = ArrayPrint[s].TitleDescription;
    txtOrigination.value = ArrayPrint[s].Origination;
    txtOriginationDescription.value = ArrayPrint[s].OriginationDescription;
    txtArtwork.value = ArrayPrint[s].Artwork;
    txtArtworkDescription.value = ArrayPrint[s].ArtworkDescription;
    txtColor.value = ArrayPrint[s].Color;
    txtColorDescription.value = ArrayPrint[s].ColorDescription;
    txtSize.value = ArrayPrint[s].Size;
    txtSizeDescription.value = ArrayPrint[s].SizeDescription;
    txtMaterial.value = ArrayPrint[s].Material;
    txtMaterialDescription.value = ArrayPrint[s].MaterialDescription;
    txtFinishing.value = ArrayPrint[s].Finishing;
    txtFinishingDescription.value = ArrayPrint[s].FinishingDescription;
    txtDelivery.value = ArrayPrint[s].Delivery;
    txtDeliveryDescription.value = ArrayPrint[s].DeliveryDescription;
    txtProofs.value = ArrayPrint[s].Proofs;
    txtProofsDescription.value = ArrayPrint[s].ProofsDescription;
    txtPacking.value = ArrayPrint[s].Packing;
    txtPackingDescription.value = ArrayPrint[s].PackingDescription;
    txtNotes.value = ArrayPrint[s].Notes;
    txtNotesDescription.value = ArrayPrint[s].NotesDescription;
    txtTerms.value = ArrayPrint[s].Terms;
    txtTermsDescription.value = ArrayPrint[s].TermsDescription;

    // New Fields
    txt_SuplierLabel1.value = ArrayPrint[s].CustomDescnLabel1;
    txt_SuplierValue1.value = ArrayPrint[s].CustomDescnPhraseValue1;

    txt_SuplierLabel2.value = ArrayPrint[s].CustomDescnLabel2;
    txt_SuplierValue2.value = ArrayPrint[s].CustomDescnPhraseValue2;

    txt_SuplierLabel3.value = ArrayPrint[s].CustomDescnLabel3;
    txt_SuplierValue3.value = ArrayPrint[s].CustomDescnPhraseValue3;

    txt_SuplierLabel4.value = ArrayPrint[s].CustomDescnLabel4;
    txt_SuplierValue4.value = ArrayPrint[s].CustomDescnPhraseValue4;

    txt_SuplierLabel5.value = ArrayPrint[s].CustomDescnLabel5;
    txt_SuplierValue5.value = ArrayPrint[s].CustomDescnPhraseValue5;

    txt_SuplierLabel6.value = ArrayPrint[s].CustomDescnLabel6;
    txt_SuplierValue6.value = ArrayPrint[s].CustomDescnPhraseValue6;

    txt_SuplierLabel7.value = ArrayPrint[s].CustomDescnLabel7;
    txt_SuplierValue7.value = ArrayPrint[s].CustomDescnPhraseValue7;

    txt_SuplierLabel8.value = ArrayPrint[s].CustomDescnLabel8;
    txt_SuplierValue8.value = ArrayPrint[s].CustomDescnPhraseValue8;

    txt_SuplierLabel9.value = ArrayPrint[s].CustomDescnLabel9;
    txt_SuplierValue9.value = ArrayPrint[s].CustomDescnPhraseValue9;

    txt_SuplierLabel1.value = ArrayPrint[s].CustomDescnLabel1;
    txt_SuplierValue1.value = ArrayPrint[s].CustomDescnPhraseValue1;

    txt_SuplierLabel10.value = ArrayPrint[s].CustomDescnLabel10;
    txt_SuplierValue10.value = ArrayPrint[s].CustomDescnPhraseValue10;

    txt_SuplierLabel11.value = ArrayPrint[s].CustomDescnLabel11;
    txt_SuplierValue11.value = ArrayPrint[s].CustomDescnPhraseValue11;

    txt_SuplierLabel12.value = ArrayPrint[s].CustomDescnLabel12;
    txt_SuplierValue12.value = ArrayPrint[s].CustomDescnPhraseValue12;

    txt_SuplierLabel13.value = ArrayPrint[s].CustomDescnLabel13;
    txt_SuplierValue13.value = ArrayPrint[s].CustomDescnPhraseValue13;

    txt_SuplierLabel14.value = ArrayPrint[s].CustomDescnLabel14;
    txt_SuplierValue14.value = ArrayPrint[s].CustomDescnPhraseValue14;

    txt_SuplierLabel15.value = ArrayPrint[s].CustomDescnLabel15;
    txt_SuplierValue15.value = ArrayPrint[s].CustomDescnPhraseValue15;

    txt_SuplierLabel16.value = ArrayPrint[s].CustomDescnLabel16;
    txt_SuplierValue16.value = ArrayPrint[s].CustomDescnPhraseValue16;

    txt_SuplierLabel17.value = ArrayPrint[s].CustomDescnLabel17;
    txt_SuplierValue17.value = ArrayPrint[s].CustomDescnPhraseValue17;

    txt_SuplierLabel18.value = ArrayPrint[s].CustomDescnLabel18;
    txt_SuplierValue18.value = ArrayPrint[s].CustomDescnPhraseValue18;

    txt_SuplierLabel19.value = ArrayPrint[s].CustomDescnLabel19;
    txt_SuplierValue19.value = ArrayPrint[s].CustomDescnPhraseValue19;

    txt_SuplierLabel20.value = ArrayPrint[s].CustomDescnLabel20;
    txt_SuplierValue20.value = ArrayPrint[s].CustomDescnPhraseValue20;

    txt_SuplierLabel21.value = ArrayPrint[s].CustomDescnLabel21;
    txt_SuplierValue21.value = ArrayPrint[s].CustomDescnPhraseValue21;

    txt_SuplierLabel22.value = ArrayPrint[s].CustomDescnLabel22;
    txt_SuplierValue22.value = ArrayPrint[s].CustomDescnPhraseValue22;

    txt_SuplierLabel23.value = ArrayPrint[s].CustomDescnLabel23;
    txt_SuplierValue23.value = ArrayPrint[s].CustomDescnPhraseValue23;

    txt_SuplierLabel24.value = ArrayPrint[s].CustomDescnLabel24;
    txt_SuplierValue24.value = ArrayPrint[s].CustomDescnPhraseValue24;

    txt_SuplierLabel25.value = ArrayPrint[s].CustomDescnLabel25;
    txt_SuplierValue25.value = ArrayPrint[s].CustomDescnPhraseValue25;

    // End

    txtRFQReturnDate.value = ArrayPrint[s].RFQReturnDate == "01/01/1900" ? '' : ArrayPrint[s].RFQReturnDate;
    txtJobCompletionDate.value = ArrayPrint[s].JobCompletionDate == "01/01/1900" ? '' : ArrayPrint[s].JobCompletionDate;
    spn_PrintBroker_Header.innerHTML = ArrayPrint[s].Header;
    spn_PrintBroker_Footer.innerHTML = ArrayPrint[s].Footer;

    UploadedFiles = ArrayPrint[s].ArtWork;

    //ddlCostingType.value = ArrayPrint[s].CostingType == "U" ? 'unit' : 'simple';
    if (ArrayPrint[s].CostingType == "U") {
        ddlCostingType.value = 'unit';
    } else if (ArrayPrint[s].CostingType == "S") {
        ddlCostingType.value = 'simple';
    } else if (ArrayPrint[s].CostingType == "P") {
        ddlCostingType.value = 'per1000';
    }

    txtSingleQty1.value = '';
    txtRunQty11.value = '';
    txtRunQty22.value = '';
    txtMultiQty11.value = '';
    txtMultiQty22.value = '';
    txtMultiQty33.value = '';
    txtMultiQty44.value = '';


    var qt = trim12(ArrayPrint[s].QtyType);


    if (qt == "S" || qt == "single") {
        var Qarr1 = ArrayPrint[s].Quantity.split('|');
        txtSingleQty1.value = Qarr1[0] == null ? '' : Qarr1[0];
        for (var i = 0; i < QtyTypeArray.length; i++) {
            if (QtyTypeArray[i].value == "single") {
                QtyTypeArray[i].checked = true;
                CheckQtyType(QtyTypeArray[i].value);
            }
            else {
                QtyTypeArray[i].disabled = true;
            }

        }
    }
    else if (qt == "R" || qt == "runon") {
        var Qarr1 = ArrayPrint[s].Quantity.split('|');

        txtRunQty11.value = Qarr1[0] == null ? '' : Qarr1[0];
        txtRunQty22.value = Qarr1[1] == null ? '' : Qarr1[1];
        for (var i = 0; i < QtyTypeArray.length; i++) {
            if (QtyTypeArray[i].value == "runon") {
                QtyTypeArray[i].checked = true;
                CheckQtyType(QtyTypeArray[i].value);
            }
            else {
                QtyTypeArray[i].disabled = true;
            }
        }
    }
    else if (qt == "M" || qt == "multiple") {

        var Qarr1 = ArrayPrint[s].Quantity.split('|');
        txtMultiQty11.value = Qarr1[0] == null ? '' : Qarr1[0];
        txtMultiQty22.value = Qarr1[1] == null ? '' : Qarr1[1];
        txtMultiQty33.value = Qarr1[2] == null ? '' : Qarr1[2];
        txtMultiQty44.value = Qarr1[3] == null ? '' : Qarr1[3];
        //in job and invoice need to show only progressed quantity

        if (QtyNumber == 1) {
            txtMultiQty22.style.display = 'none';
            txtMultiQty33.style.display = 'none';
            txtMultiQty44.style.display = 'none';
            //            if (modulename != 'estimates' && Qarr1.length <= 2) {
            //                txtMultiQty11.value = Qarr1[0] == null ? '' : Qarr1[0];
            //            }
        }
        else if (QtyNumber == 2) {
            txtMultiQty11.style.display = 'none';
            txtMultiQty33.style.display = 'none';
            txtMultiQty44.style.display = 'none';
            //            if (modulename != 'estimates' && Qarr1.length <= 2) {
            //                txtMultiQty22.value = Qarr1[0] == null ? '' : Qarr1[0];
            //            }
        }
        else if (QtyNumber == 3) {
            txtMultiQty11.style.display = 'none';
            txtMultiQty22.style.display = 'none';
            txtMultiQty44.style.display = 'none';
            //            if (modulename != 'estimates' && Qarr1.length <= 2) {
            //                txtMultiQty33.value = Qarr1[0] == null ? '' : Qarr1[0];
            //            }
        }
        else if (QtyNumber == 4) {
            txtMultiQty11.style.display = 'none';
            txtMultiQty22.style.display = 'none';
            txtMultiQty33.style.display = 'none';
            //            if (modulename != 'estimates' && (QueryType == 'add' || QueryType == 'edit')) {
            //                txtMultiQty44.value = Qarr1[0] == null ? '' : Qarr1[0];
            //            }
        }


        for (var i = 0; i < QtyTypeArray.length; i++) {
            if (QtyTypeArray[i].value == "multiple") {
                QtyTypeArray[i].checked = true;
                CheckQtyType(QtyTypeArray[i].value);
            }
            else {
                QtyTypeArray[i].disabled = true;
            }
        }
    }

    supCount = 1;
    labelCount = 1;
    qtyCount = 0;
    document.getElementById("div_added").innerHTML = '';
    document.getElementById("div_load").innerHTML = '';

    for (var p = 0; p < ArrayPrint[s].SupplierList.length; p++) {
        add_more();

        var supnum = Number(p + 1);
        var supObj = document.getElementById("ddlSupplier_" + supnum + "");
        supObj.disabled = true; //Given by anil to diable ddl supplier
        for (var i = 0; i < supObj.length; i++) {
            if (supObj.options[i].value == ArrayPrint[s].SupplierList[p].SupplierID) {
                supObj.selectedIndex = i;
                loadContacts(supObj.value, supnum, ArrayPrint[s].SupplierList[p].ContactID);
                var ContObj = document.getElementById("ddlSupplierContact_" + supnum);
                ContObj.disabled = true; //Given by anil to diable ddl suppliercontact
                for (var j = 0; j < ContObj.length; j++) {
                    if (ContObj.options[j].value == ArrayPrint[s].SupplierList[p].ContactID) {
                        ContObj.selectedIndex = j;
                    }
                }
                var uniData = '';

                if (qtyType == "single") {
                    qtyCount = 1;
                }
                else if (qtyType == "multiple") {
                    qtyCount = 4;

                }
                else if (qtyType == "runon") {
                    qtyCount = 2;
                }
                uniData += "<div id=divPriceComparision_" + supObj.id + ">";

                for (var j = 1; j <= qtyCount; j++) {
                    var name = supObj.options[supObj.selectedIndex].text;
                    var supValue = supObj.options[supObj.selectedIndex].value;

                    if (j != 1) {
                        name = '&nbsp;';
                    }
                    var QtyValue = '';
                    if (qtyType == "single") {
                        QtyValue = txtSingleQty1.value;
                    }
                    else if (qtyType == "runon") {
                        if (j == 1) {
                            QtyValue = txtRunQty11.value;
                        }
                        else if (j == 2) {
                            QtyValue = txtRunQty22.value;
                        }
                    }
                    else if (qtyType == "multiple") {
                        if (j == 1) {
                            QtyValue = txtMultiQty11.value;

                        }
                        else if (j == 2) {
                            QtyValue = txtMultiQty22.value;
                        }
                        else if (j == 3) {
                            QtyValue = txtMultiQty33.value;
                        }
                        else if (j == 4) {
                            QtyValue = txtMultiQty44.value;
                        }
                    }
                    var comnID = supValue + '_' + j;

                    uniData += "<div id='Div_" + comnID + "' class='onlyEmpty'></div>";


                    uniData += "<div align='left' >";

                    if (j == 1) {
                        uniData += "<div style='float: left; width: 9%'><input id='txtRefNo_" + comnID + "' type='text' class='textboxnew' style='Width:90%;text-align:right;' /></div>";
                    }
                    else {
                        uniData += "<div style='float: left; width: 9%'>&nbsp;</div>";
                    }

                    uniData += "<div style='float: left; width: 14%;'>" + name + "</div>";
                    uniData += "<div style='float: left; width: 6%;padding-right:5px'><input id='txtQty_" + comnID + "' type='text' value='" + QtyValue + "'  class='textboxnew' style='Width:95%;text-align:right;' disabled='true' /></div>";
                    uniData += "<div style='float: left; width: 9%'><input id='txtCost_" + comnID + "' type='text' onchange=\"javascript:SelectChkQty('" + comnID + "');\"  onclick='this.select();' onfocus='this.select();'  onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";
                    uniData += "<div style='float: left; width: 7%;'><select id='ddlDeliveryIncluded_" + comnID + "' onchange=DropdownChange(this,'txtDeliveryCost_" + comnID + "'); style='Width:85%' class='normaltext'><option value='yes'>yes</option><option value='no'>No</option></select></div>";
                    if (j == 1) {
                        uniData += "<div style='float: left; width: 9%;'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" onblur=\"javascript:CopyDate(" + supValue + "," + qtyCount + ",this.value);\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                    }
                    else {
                        uniData += "<div style='float: left; width: 9%;'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                    }
                    uniData += "<div style='float: left; width: 10%;'><input id='txtDeliveryCost_" + comnID + "' disabled='true'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";
                    if (j == 1) {
                        uniData += "<div style='float: left; width: 9%;'><select id='ddlMarkup_" + comnID + "' style='Width:85%'  onchange=javascript:CopyMarkup(this.value," + supValue + "," + qtyCount + ");   class='normaltext'><option value='percentage'>%</option><option value='fixedvalue' >" + GetCurrencyinRequiredFormate("", true) + "</option></select></div>";
                        if (ProfitTaxKey == 'database') {
                            uniData += "<div style='float: left; width: 9%;'><input id='txtMarkup_" + comnID + "' value='" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].MarkupValue, 0, '', false, false, false) + "' onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);CopyMarkupValue(this.value," + supValue + "," + qtyCount + ");\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
                        }
                        else {
                            uniData += "<div style='float: left; width: 9%;'><input id='txtMarkup_" + comnID + "' value='" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pb_markup, 0, '', false, false, false) + "' onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);CopyMarkupValue(this.value," + supValue + "," + qtyCount + ");\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
                        }
                    }
                    else {
                        uniData += "<div style='float: left; width: 9%; '><select id='ddlMarkup_" + comnID + "' style='Width:85%' onchange=javascript:CopyMarkup(this.value," + supValue + "," + qtyCount + ");   class='normaltext'><option value='percentage'>%</option><option value='fixedvalue' >" + GetCurrencyinRequiredFormate("", true) + "</option></select></div>"; //onchange=javascript:CalculatePrice('" + comnID + "','c'); 
                        if (ProfitTaxKey == 'database') {
                            uniData += "<div style='float: left; width: 9%;'><input id='txtMarkup_" + comnID + "' value='" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].MarkupValue, 0, '', false, false, false) + "' onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
                        }
                        else {
                            uniData += "<div style='float: left; width: 9%;'><input id='txtMarkup_" + comnID + "' value='" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pb_markup, 0, '', false, false, false) + "' onblur=\"javascript:todecimal_function(this,this.value);AllowNumber(this,this.value);CalculatePrice('" + comnID + "','c');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%;text-align:right' value='' maxlength='20'  /></div>";
                        }
                    }
                    uniData += "<div style='float: left; width: 8%;'><input id='txtTotalPrice_" + comnID + "' onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "','price');\" type='text' class='textboxnew' style='Width:95%;text-align:right' maxlength='20' /></div>";
                    uniData += "<div style='float: left; width: 9%;'><input style='float: left;margin-left: 40px' id='chk_" + comnID + "' type='checkbox' onclick=\"javascript:SelectOneSuppler('" + comnID + "');\" /></div>";
                    uniData += "</div>";

                    uniData += "<div id='Div1_" + comnID + "' class='onlyEmpty'></div>";



                }  // last for                  
                uniData += "<div style='padding:2px 0px 4px 0px;'><div class='onlyEmpty' style='border:1px solid #ccc;'></div></div>";
                uniData += "</div>";
                ////document.getElementById("div_load").innerHTML +=uniData;

                var row = document.createElement("tr");
                row.id = "Price_tr_" + supObj.id + "";
                var cell = document.createElement("td");
                cell.innerHTML = uniData;
                row.appendChild(cell);
                document.getElementById("PriceTable").appendChild(row);

                //in job and invoice need to show only progressed quantity
                for (var k = 1; k <= qtyCount; k++) {

                    if (k != QtyNumber && QtyNumber != 0 && qtyType != "single") {
                        var CountNew = supValue + '_' + k;
                        document.getElementById("Div_" + CountNew + "").style.display = "none";
                        document.getElementById("Div1_" + CountNew + "").style.display = "none";
                        document.getElementById("txtQty_" + CountNew + "").style.display = "none";
                        document.getElementById("txtQty_" + CountNew + "").style.display = "none";
                        document.getElementById("txtCost_" + CountNew + "").style.display = 'none';
                        document.getElementById("ddlDeliveryIncluded_" + CountNew + "").style.display = 'none';
                        document.getElementById("txtDeliveryDate_" + CountNew + "").style.display = 'none';
                        document.getElementById("txtDeliveryCost_" + CountNew + "").style.display = 'none';
                        document.getElementById("ddlMarkup_" + CountNew + "").style.display = 'none';
                        document.getElementById("txtMarkup_" + CountNew + "").style.display = 'none';
                        document.getElementById("txtTotalPrice_" + CountNew + "").style.display = 'none';
                        document.getElementById("chk_" + CountNew + "").style.display = 'none';
                    }
                }

                priceNo++;

            }

        }
    }

    for (var p = 0; p < ArrayPrint[s].PriceList.length; p++) {
        for (var q = 1; q <= qtyCount; q++) {
            supValue = ArrayPrint[s].PriceList[p].SupplierID;
            var SupplierRefNo_Value = ArrayPrint[s].PriceList[p].SupplierRefNo;
            var comnID = supValue + '_' + Number(q);
            if (q == 1) {
                document.getElementById("txtRefNo_" + comnID + "").value = SupplierRefNo_Value;
            }

            //            if (p == q - 1) {
            //                if (ProfitTaxKey == 'database') {
            //                    document.getElementById("txtMarkup_" + comnID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].MarkupValue, 0, '', false, false, false);
            //                }
            //                else {
            //                    document.getElementById("txtMarkup_" + comnID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pb_markup, 0, '', false, false, false);
            //                }
            //            }

            if (supValue != '' && document.getElementById("txtQty_" + comnID + "") != null) {
                if (document.getElementById("txtQty_" + comnID + "").value == ArrayPrint[s].PriceList[p].Quantity) {
                    document.getElementById("txtQty_" + comnID + "").value = ArrayPrint[s].PriceList[p].Quantity;
                    document.getElementById("txtCost_" + comnID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].Cost, 0, '', false, false, false);
                    document.getElementById("ddlDeliveryIncluded_" + comnID + "").value = ArrayPrint[s].PriceList[p].DeliveryIncluded == "yes" ? "yes" : "no";
                    document.getElementById("txtDeliveryDate_" + comnID + "").value = ArrayPrint[s].PriceList[p].DeliveryDate == "01/01/1900" ? '' : ArrayPrint[s].PriceList[p].DeliveryDate;
                    document.getElementById("txtDeliveryCost_" + comnID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].DeliveryCost, 0, '', false, false, false);
                    document.getElementById("txtDeliveryCost_" + comnID + "").disabled = ArrayPrint[s].PriceList[p].DeliveryIncluded == "yes" ? true : false;
                    var MarType = "fixedvalue";
                    if (ArrayPrint[s].PriceList[p].MarkupType == "percentage" || ArrayPrint[s].PriceList[p].MarkupType == "P") {
                        MarType = "percentage";
                    }
                    document.getElementById("ddlMarkup_" + comnID + "").value = MarType;

                    //if (modulename != 'estimates') {
                    if (ProfitTaxKey == 'database') {
                        document.getElementById("txtMarkup_" + comnID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].MarkupValue, 0, '', false, false, false);
                        pb_markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ArrayPrint[s].PriceList[p].MarkupValue, 0, '', false, false, false); //ArrayPrint[s].PriceList[p].MarkupValue;
                    }
                    else {
                        document.getElementById("txtMarkup_" + comnID + "").value = pb_markup;
                    }
                    // }
                    //else {
                    //     document.getElementById("txtMarkup_" + comnID + "").value = pb_markup;
                    // }

                    //added by kumar,to print markup and cost values correctly on edit case
                    var Markup = 0;
                    var Delivery = 0;
                    var total = 0.00;
                    if (MarType == "percentage") {
                        Markup = (Number((Number(ArrayPrint[s].PriceList[p].Cost) + Number(ArrayPrint[s].PriceList[p].DeliveryCost)) * Number(pb_markup)) / Number(100));
                        Markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, false);
                    }

                    else if (MarType == "fixedvalue") {
                        if (ProfitTaxKey == 'database') {
                            Markup = Number(ArrayPrint[s].PriceList[p].MarkupValue); //Cost
                        }
                        else {
                            Markup = Number(ArrayPrint[s].PriceList[p].Cost);
                        }
                        Markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, false);
                    }
                    if (ArrayPrint[s].PriceList[p].DeliveryIncluded == "no") {
                        if (trim12(ArrayPrint[s].PriceList[p].DeliveryCost) != '') {
                            Delivery = Number(ArrayPrint[s].PriceList[p].DeliveryCost);
                            Delivery = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Delivery, 0, '', false, false, false);
                        }
                    }
                    if (ddlCostingType.value == 'unit') {
                        Markup = (Number(((Number(ArrayPrint[s].PriceList[p].Cost) * Number(ArrayPrint[s].PriceList[p].Quantity)) + Number(ArrayPrint[s].PriceList[p].DeliveryCost)) * pb_markup) / Number(100));
                        total = (Number(ArrayPrint[s].PriceList[p].Quantity) * Number(ArrayPrint[s].PriceList[p].Cost)) + Number(ArrayPrint[s].PriceList[p].DeliveryCost) + Markup;
                        total = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total, 0, '', false, false, false);
                        Markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, false);
                    }
                    else if (ddlCostingType.value == 'per1000') {
                        Markup = (Number(((Number(ArrayPrint[s].PriceList[p].Cost) * Number(ArrayPrint[s].PriceList[p].Quantity)) + Number(ArrayPrint[s].PriceList[p].DeliveryCost)) * pb_markup) / Number(100));
                        total = (Number(ArrayPrint[s].PriceList[p].Quantity) * Number(ArrayPrint[s].PriceList[p].Cost)) + Number(ArrayPrint[s].PriceList[p].DeliveryCost) + Markup;
                        total = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total, 0, '', false, false, false);
                        Markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, false);
                    }
                    else {
                        if (document.getElementById("txtCost_" + comnID + "").value != "0.00") {
                            total = Number(ArrayPrint[s].PriceList[p].Cost) + Number(Delivery) + Number(Markup);
                        }

                        total = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, total, 0, '', false, false, false);
                    }

                    //added by kumar,to print markup and cost values correctly on edit case                                       
                    document.getElementById("txtTotalPrice_" + comnID + "").value = total; // ArrayPrint[s].PriceList[p].TotalPrice; 
                    NumberToDecimal(document.getElementById("txtTotalPrice_" + comnID + "").id, document.getElementById("txtTotalPrice_" + comnID + "").value);

                    document.getElementById("chk_" + comnID + "").checked = ArrayPrint[s].PriceList[p].IsSelected == "1" ? true : false;
                }
            }
        }
    }
}


function ChangeOfQty(qtyNo, QtyVal) {
    if (IsEdit) {
        var s = EditNo;
        for (var p = 0; p < ArrayPrint[s].PriceList.length; p++) {

            var q = qtyNo;
            supValue = ArrayPrint[s].PriceList[p].SupplierID;
            var comnID = supValue + '_' + Number(q);

            if (supValue != '' && document.getElementById("txtQty_" + comnID + "") != null) {
                document.getElementById("txtQty_" + comnID + "").value = QtyVal;
            }
        }
    }
}

function Only_Single_Qty() {
    for (var i = 0; i < qtyarray.length; i++) {
        if (qtyarray[i].value == 'single') {
            qtyarray[i].checked = true;
        }
        else {
            qtyarray[i].checked = false;
            qtyarray[i].disabled = true;
        }
    }
}


function CallPrintEmail() {

    CheckQtyType();
    if (Stpe1Vaild() && SupplierSelectionCheck()) {
        try {
            document.getElementById("ds00").style.width = document.getElementById("Table1").offsetWidth + "px";
            document.getElementById("ds00").style.height = Number(Number(window.screen.availHeight) + 50) + "px";
            document.getElementById("ds00").style.display = "block";
            document.getElementById("abs").style.display = "block";
            document.getElementById("div_00").focus();
        } catch (e) { }

        document.getElementById("div_print_broker_step_1").style.display = "none";
        document.getElementById("div_print_broker_step_2").style.display = "none";
        document.getElementById("div_blank_OW").style.display = "block";

        hid_Pub_ClientID.value = ClientID;
        // BindDefaultRFQData();

        SaveOutWork("printemail");

        //Pls uncomment for sub items print/email case.. but not completed
        //if ('<%=IsPrintBrokerDirect%>') {            
        SaveData();
        __doPostBack('ctl00$ContentPlaceHolder1$divprintbroker$lnkPrintEmail', '');
        //}
        //else {
        //SubItem_CallPrintEmail();
        //}
        //Pls uncomment for sub items print/email case.. but not completed
    }
    else {
        return false;
    }
}
//This function is used in the ItemAdd
function ArrangePrintBroker(para) {
    var QtyTypeArray = qtyarray;
    for (var i = 0; i < QtyTypeArray.length; i++) {
        if (para == 'S' && QtyTypeArray[i].value == 'single') {
            QtyTypeArray[i].checked = true;
            qtyType = QtyTypeArray[i].value;
            //------
            txtSingleQty1.value = txtQuantity.value;
            //------
            div_singleQty.style.display = 'block';
            div_runQty.style.display = 'none';
            div_MultyQty.style.display = 'none';
        }
        else if (para == 'R' && QtyTypeArray[i].value == 'runon') {
            QtyTypeArray[i].checked = true;
            QtyTypeArray[i].disabled = false;
            //------
            txtRunQty11.value = txtQuantity.value;
            txtRunQty22.value = txtRunOnQty.value;
            //------
            div_singleQty.style.display = 'none';
            div_runQty.style.display = 'block';
            div_MultyQty.style.display = 'none';
        }
        else if (para == 'M' && QtyTypeArray[i].value == 'multiple') {
            QtyTypeArray[i].checked = true;
            qtyType = QtyTypeArray[i].value;
            QtyTypeArray[i].disabled = false;
            //------
            txtMultiQty11.value = txtQuantity.value;
            txtMultiQty22.value = txtQuantity_2.value;
            txtMultiQty33.value = txtQuantity_3.value;
            txtMultiQty44.value = txtQuantity_4.value;
            //------
            div_singleQty.style.display = 'none';
            div_runQty.style.display = 'none';
            div_MultyQty.style.display = 'block';
        }
        QtyTypeArray[i].disabled = true;
    }
}

function todecimal_function(txtobj) {
    var value = txtobj.value;
    txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtobj.value, 0, '', false, false, false);
}

function ReloadSupplier(SupplerID, SupplerDDlSupName, SupplerDDlSupID, SupplerContactID) {
    //alert(SupplerID + ", " + SupplerDDlSupName + ", " + SupplerDDlSupID + ", " + SupplerContactID);
    var sup = new SupplierInfo();
    if (SupplerID != '') {
        //By Gaj

        try {
            var PriceTable = document.getElementById("PriceTable");
            var chil = document.getElementById("Price_tr_ddlSupplier_" + SupplerDDlSupID + "");
            PriceTable.removeChild(chil);
        }
        catch (Error) {
        }

        //By Gaj
        var ddlNewSupplierid = document.getElementById("ddlSupplier_" + SupplerDDlSupID);
        var Sellength;
        for (var i = 1; i < labelCount; i++) {
            var ddlSuppid = document.getElementById("ddlSupplier_" + i);
            ddlSuppid.options.add(new Option(SupplerDDlSupName, SupplerID));
            Sellength = ddlSuppid.length - 1;
        }
        ddlNewSupplierid.selectedIndex = Sellength;
        sup.SupplierID = ddlNewSupplierid.options[ddlNewSupplierid.selectedIndex].value;
        sup.SupplierName = ddlNewSupplierid.options[ddlNewSupplierid.selectedIndex].text;
    }

    if (SupplerContactID != 0) {
        ReloadContact_new(SupplerContactID, SupplerDDlSupName, SupplerDDlSupID);
    }

    if (IsEdit) {
        CreatePriceComparison(ddlNewSupplierid);
    }
}

function ReloadContact_new(ContactID, ContactDDlConName, ContactDDlConID) {
    //alert(ContactID + ", " + ContactDDlConName + ", " + ContactDDlConID);
    var sup = new SupplierInfo();
    if (ContactID != '') {
        var ddlNewSupContactid = document.getElementById("ddlSupplierContact_" + ContactDDlConID);

        ddlNewSupContactid.options.add(new Option(ContactDDlConName, ContactID));
        var Sellength = ddlNewSupContactid.length - 1;

        ddlNewSupContactid.selectedIndex = Sellength;
        sup.ContactID = ddlNewSupContactid.options[ddlNewSupContactid.selectedIndex].value;
    }
}

function qty_showForAdditional() {

    if (modulename != 'estimates' && ISFromAddAnItem == 'y' && QueryType == 'add') {
        QtyNumber = 1;
    }


    if (QtyNumber == 1) {
        txtMultiQty22.style.display = 'none';
        txtMultiQty33.style.display = 'none';
        txtMultiQty44.style.display = 'none';
    }
    else if (QtyNumber == 2) {
        txtMultiQty11.style.display = 'none';
        txtMultiQty33.style.display = 'none';
        txtMultiQty44.style.display = 'none';
    }
    else if (QtyNumber == 3) {
        txtMultiQty11.style.display = 'none';
        txtMultiQty22.style.display = 'none';
        txtMultiQty44.style.display = 'none';
    }
    else if (QtyNumber == 4) {
        txtMultiQty11.style.display = 'none';
        txtMultiQty22.style.display = 'none';
        txtMultiQty33.style.display = 'none';
    }
}


function ClearSpplierIfExsits(supObj) {

    var supValue = supObj.options[supObj.selectedIndex].value;
    for (var i = 1; i < labelCount; i++) {
        var supObj_2 = document.getElementById("ddlSupplier_" + i);
        if (supObj_2 != null) {
            if (supObj_2.id != supObj.id) {
                if (supObj_2.value == supValue) {
                    supObj.selectedIndex = 0;
                    var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                    if (divPriceObj != null) {
                        var PriceTable = document.getElementById("PriceTable");
                        var chil = document.getElementById("Price_tr_" + supObj.id + "");
                        PriceTable.removeChild(chil);
                    }
                    return false; j
                }
                else {
                    var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                    if (divPriceObj != null) {
                        var PriceTable = document.getElementById("PriceTable");
                        var chil = document.getElementById("Price_tr_" + supObj.id + "");
                        PriceTable.removeChild(chil);
                    }
                    Pricecompflag = true;
                }
            }
        }
    }
}


function BindOutworkDesc() {

    if (hdn_OutworkDesc.value != '') {

        var str = hdn_OutworkDesc.value.split('µ');
        var str2 = '';
        div_OutItemTitle.style.display = "none";
        div_OutDescription.style.display = "none";
        div_OutArtwork.style.display = "none";
        div_OutColour.style.display = "none";
        div_OutSize.style.display = "none";
        div_OutMaterial.style.display = "none";
        div_OutDelivery.style.display = "none";
        div_OutFinishing.style.display = "none";
        div_OutProofs.style.display = "none";
        div_OutPacking.style.display = "none";
        div_OutNotes.style.display = "none";
        div_OutInstructions.style.display = "none";

        div_SupplierDescrn1.style.display = "none";
        div_SupplierDescrn2.style.display = "none";
        div_SupplierDescrn3.style.display = "none";
        div_SupplierDescrn4.style.display = "none";
        div_SupplierDescrn5.style.display = "none";
        div_SupplierDescrn6.style.display = "none";
        div_SupplierDescrn7.style.display = "none";
        div_SupplierDescrn8.style.display = "none";
        div_SupplierDescrn9.style.display = "none";
        div_SupplierDescrn10.style.display = "none";
        div_SupplierDescrn11.style.display = "none";
        div_SupplierDescrn12.style.display = "none";
        div_SupplierDescrn13.style.display = "none";
        div_SupplierDescrn14.style.display = "none";
        div_SupplierDescrn15.style.display = "none";
        div_SupplierDescrn16.style.display = "none";
        div_SupplierDescrn17.style.display = "none";
        div_SupplierDescrn18.style.display = "none";
        div_SupplierDescrn19.style.display = "none";
        div_SupplierDescrn20.style.display = "none";
        div_SupplierDescrn21.style.display = "none";
        div_SupplierDescrn22.style.display = "none";
        div_SupplierDescrn23.style.display = "none";
        div_SupplierDescrn24.style.display = "none";
        div_SupplierDescrn25.style.display = "none";


        chkOutItemTitle.checked = false;
        chkOutDescription.checked = false;
        chkOutArtwork.checked = false;
        chkOutColour.checked = false;
        chkOutSize.checked = false;
        chkOutMaterial.checked = false;
        chkOutFinishing.checked = false;
        chkOutDelivery.checked = false;
        chkOutProofs.checked = false;
        chkOutPacking.checked = false;
        chkOutNotes.checked = false;
        chkOutInstructions.checked = false;

        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                div_OutItemTitle.style.display = "block";
                txtTitle.value = str2[2];
                chkOutItemTitle.checked = true;
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                div_OutDescription.style.display = "block";
                txtOrigination.value = str2[2];
                chkOutDescription.checked = true;
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                div_OutArtwork.style.display = "block";
                txtArtwork.value = str2[2];
                chkOutArtwork.checked = true;
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                div_OutColour.style.display = "block";
                txtColor.value = str2[2];
                chkOutColour.checked = true;
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                div_OutSize.style.display = "block";
                txtSize.value = str2[2];
                chkOutSize.checked = true;
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                div_OutMaterial.style.display = "block";
                txtMaterial.value = str2[2];
                chkOutMaterial.checked = true;
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                div_OutDelivery.style.display = "block";
                txtDelivery.value = str2[2];
                chkOutDelivery.checked = true;
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                div_OutFinishing.style.display = "block";
                txtFinishing.value = str2[2];
                chkOutFinishing.checked = true;
            }
            if (str2[1] == "Proofs" && str2[3] == "1") {
                div_OutProofs.style.display = "block";
                txtProofs.value = str2[2];
                chkOutProofs.checked = true;
            }
            if (str2[1] == "Packing" && str2[3] == "1") {
                div_OutPacking.style.display = "block";
                txtPacking.value = str2[2];
                chkOutPacking.checked = true;
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                div_OutNotes.style.display = "block";
                txtNotes.value = str2[2];
                chkOutNotes.checked = true;
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                div_OutInstructions.style.display = "block";
                txtTerms.value = str2[2];
                chkOutInstructions.checked = true;
            }
            //µ15983»Instructions»Terms/Instructions»1µ   17696»Custom Description 1»Custom Description 1»1µ

            // New Supplier Descn Filds //

            if (str2[1] == "Custom Description 1" && str2[3] == "1") {
                div_SupplierDescrn1.style.display = "block";
                txt_SuplierLabel1.value = str2[2];
                Chk_SuplierDescn1.checked = true;
            }
            if (str2[1] == "Custom Description 2" && str2[3] == "1") {
                div_SupplierDescrn2.style.display = "block";
                txt_SuplierLabel2.value = str2[2];
                Chk_SuplierDescn2.checked = true;
            }
            if (str2[1] == "Custom Description 3" && str2[3] == "1") {
                div_SupplierDescrn3.style.display = "block";
                txt_SuplierLabel3.value = str2[2];
                Chk_SuplierDescn3.checked = true;
            }
            if (str2[1] == "Custom Description 4" && str2[3] == "1") {
                div_SupplierDescrn4.style.display = "block";
                txt_SuplierLabel4.value = str2[2];
                Chk_SuplierDescn4.checked = true;
            }
            if (str2[1] == "Custom Description 5" && str2[3] == "1") {
                div_SupplierDescrn5.style.display = "block";
                txt_SuplierLabel5.value = str2[2];
                Chk_SuplierDescn5.checked = true;
            }
            if (str2[1] == "Custom Description 6" && str2[3] == "1") {
                div_SupplierDescrn6.style.display = "block";
                txt_SuplierLabel6.value = str2[2];
                Chk_SuplierDescn6.checked = true;
            }
            if (str2[1] == "Custom Description 7" && str2[3] == "1") {
                div_SupplierDescrn7.style.display = "block";
                txt_SuplierLabel7.value = str2[2];
                Chk_SuplierDescn7.checked = true;

            }
            if (str2[1] == "Custom Description 8" && str2[3] == "1") {
                div_SupplierDescrn8.style.display = "block";
                txt_SuplierLabel8.value = str2[2];
                Chk_SuplierDescn8.checked = true;
            }
            if (str2[1] == "Custom Description 9" && str2[3] == "1") {
                div_SupplierDescrn9.style.display = "block";
                txt_SuplierLabel9.value = str2[2];
                Chk_SuplierDescn9.checked = true;
            }
            if (str2[1] == "Custom Description 10" && str2[3] == "1") {
                div_SupplierDescrn10.style.display = "block";
                txt_SuplierLabel10.value = str2[2];
                Chk_SuplierDescn10.checked = true;
            }
            if (str2[1] == "Custom Description 11" && str2[3] == "1") {
                div_SupplierDescrn11.style.display = "block";
                txt_SuplierLabel11.value = str2[2];
                Chk_SuplierDescn11.checked = true;
            }
            if (str2[1] == "Custom Description 12" && str2[3] == "1") {
                div_SupplierDescrn12.style.display = "block";
                txt_SuplierLabel12.value = str2[2];
                Chk_SuplierDescn12.checked = true;
            }
            if (str2[1] == "Custom Description 13" && str2[3] == "1") {
                div_SupplierDescrn13.style.display = "block";
                txt_SuplierLabel13.value = str2[2];
                Chk_SuplierDescn13.checked = true;
            }
            if (str2[1] == "Custom Description 14" && str2[3] == "1") {
                div_SupplierDescrn14.style.display = "block";
                txt_SuplierLabel14.value = str2[2];
                Chk_SuplierDescn14.checked = true;
            }
            if (str2[1] == "Custom Description 15" && str2[3] == "1") {
                div_SupplierDescrn15.style.display = "block";
                txt_SuplierLabel15.value = str2[2];
                Chk_SuplierDescn15.checked = true;
            }
            if (str2[1] == "Custom Description 16" && str2[3] == "1") {
                div_SupplierDescrn16.style.display = "block";
                txt_SuplierLabel16.value = str2[2];
                Chk_SuplierDescn16.checked = true;
            }
            if (str2[1] == "Custom Description 17" && str2[3] == "1") {
                div_SupplierDescrn17.style.display = "block";
                txt_SuplierLabel17.value = str2[2];
                Chk_SuplierDescn17.checked = true;
            }
            if (str2[1] == "Custom Description 18" && str2[3] == "1") {
                div_SupplierDescrn18.style.display = "block";
                txt_SuplierLabel18.value = str2[2];
                Chk_SuplierDescn18.checked = true;
            }
            if (str2[1] == "Custom Description 19" && str2[3] == "1") {
                div_SupplierDescrn19.style.display = "block";
                txt_SuplierLabel19.value = str2[2];
                Chk_SuplierDescn19.checked = true;
            }
            if (str2[1] == "Custom Description 20" && str2[3] == "1") {
                div_SupplierDescrn20.style.display = "block";
                txt_SuplierLabel20.value = str2[2];
                Chk_SuplierDescn20.checked = true;
            }
            if (str2[1] == "Custom Description 21" && str2[3] == "1") {
                div_SupplierDescrn21.style.display = "block";
                txt_SuplierLabel21.value = str2[2];
                Chk_SuplierDescn21.checked = true;
            }
            if (str2[1] == "Custom Description 22" && str2[3] == "1") {
                div_SupplierDescrn22.style.display = "block";
                txt_SuplierLabel22.value = str2[2];
                Chk_SuplierDescn22.checked = true;
            }
            if (str2[1] == "Custom Description 23" && str2[3] == "1") {
                div_SupplierDescrn23.style.display = "block";
                txt_SuplierLabel23.value = str2[2];
                Chk_SuplierDescn23.checked = true;
            }
            if (str2[1] == "Custom Description 24" && str2[3] == "1") {
                div_SupplierDescrn24.style.display = "block";
                txt_SuplierLabel24.value = str2[2];
                Chk_SuplierDescn24.checked = true;
            }
            if (str2[1] == "Custom Description 25" && str2[3] == "1") {
                div_SupplierDescrn25.style.display = "block";
                txt_SuplierLabel25.value = str2[2];
                Chk_SuplierDescn25.checked = true;
            }
            //end

        }
    }
    else {
        if (IsMain == "yes") {
            txtOrigination.value != '' ? div_OutDescription.style.display = "block" : div_OutDescription.style.display = "none";
            txtArtwork.value != '' ? div_OutArtwork.style.display = "block" : div_OutArtwork.style.display = "none";
            txtColor.value != '' ? div_OutColour.style.display = "block" : div_OutColour.style.display = "none";
            txtSize.value != '' ? div_OutSize.style.display = "block" : div_OutSize.style.display = "none";
            txtMaterial.value != '' ? div_OutMaterial.style.display = "block" : div_OutMaterial.style.display = "none";
            txtDelivery.value != '' ? div_OutDelivery.style.display = "block" : div_OutDelivery.style.display = "none";
            txtFinishing.value != '' ? div_OutFinishing.style.display = "block" : div_OutFinishing.style.display = "none";
            txtProofs.value != '' ? div_OutProofs.style.display = "block" : div_OutProofs.style.display = "none";
            txtPacking.value != '' ? div_OutPacking.style.display = "block" : div_OutPacking.style.display = "none";
            txtNotes.value != '' ? div_OutNotes.style.display = "block" : div_OutNotes.style.display = "none";
            txtTerms.value != '' ? div_OutInstructions.style.display = "block" : div_OutInstructions.style.display = "none";

            txt_SuplierLabel1.value != '' ? div_SupplierDescrn1.style.display = "block" : div_SupplierDescrn1.style.display = "none"
            txt_SuplierLabel2.value != '' ? div_SupplierDescrn2.style.display = "block" : div_SupplierDescrn2.style.display = "none"
            txt_SuplierLabel3.value != '' ? div_SupplierDescrn3.style.display = "block" : div_SupplierDescrn3.style.display = "none"
            txt_SuplierLabel4.value != '' ? div_SupplierDescrn4.style.display = "block" : div_SupplierDescrn4.style.display = "none"
            txt_SuplierLabel5.value != '' ? div_SupplierDescrn5.style.display = "block" : div_SupplierDescrn5.style.display = "none"
            txt_SuplierLabel6.value != '' ? div_SupplierDescrn6.style.display = "block" : div_SupplierDescrn6.style.display = "none"
            txt_SuplierLabel7.value != '' ? div_SupplierDescrn7.style.display = "block" : div_SupplierDescrn7.style.display = "none"
            txt_SuplierLabel8.value != '' ? div_SupplierDescrn8.style.display = "block" : div_SupplierDescrn8.style.display = "none"
            txt_SuplierLabel9.value != '' ? div_SupplierDescrn9.style.display = "block" : div_SupplierDescrn9.style.display = "none"
            txt_SuplierLabel10.value != '' ? div_SupplierDescrn10.style.display = "block" : div_SupplierDescrn10.style.display = "none"
            txt_SuplierLabel11.value != '' ? div_SupplierDescrn11.style.display = "block" : div_SupplierDescrn11.style.display = "none"
            txt_SuplierLabel12.value != '' ? div_SupplierDescrn12.style.display = "block" : div_SupplierDescrn12.style.display = "none"
            txt_SuplierLabel13.value != '' ? div_SupplierDescrn13.style.display = "block" : div_SupplierDescrn13.style.display = "none"
            txt_SuplierLabel14.value != '' ? div_SupplierDescrn14.style.display = "block" : div_SupplierDescrn14.style.display = "none"
            txt_SuplierLabel15.value != '' ? div_SupplierDescrn15.style.display = "block" : div_SupplierDescrn15.style.display = "none"
            txt_SuplierLabel16.value != '' ? div_SupplierDescrn16.style.display = "block" : div_SupplierDescrn16.style.display = "none"
            txt_SuplierLabel17.value != '' ? div_SupplierDescrn17.style.display = "block" : div_SupplierDescrn17.style.display = "none"
            txt_SuplierLabel18.value != '' ? div_SupplierDescrn18.style.display = "block" : div_SupplierDescrn18.style.display = "none"
            txt_SuplierLabel19.value != '' ? div_SupplierDescrn19.style.display = "block" : div_SupplierDescrn19.style.display = "none"
            txt_SuplierLabel20.value != '' ? div_SupplierDescrn20.style.display = "block" : div_SupplierDescrn20.style.display = "none"
            txt_SuplierLabel21.value != '' ? div_SupplierDescrn21.style.display = "block" : div_SupplierDescrn21.style.display = "none"
            txt_SuplierLabel22.value != '' ? div_SupplierDescrn22.style.display = "block" : div_SupplierDescrn22.style.display = "none"
            txt_SuplierLabel23.value != '' ? div_SupplierDescrn23.style.display = "block" : div_SupplierDescrn23.style.display = "none"
            txt_SuplierLabel24.value != '' ? div_SupplierDescrn24.style.display = "block" : div_SupplierDescrn24.style.display = "none"
            txt_SuplierLabel25.value != '' ? div_SupplierDescrn25.style.display = "block" : div_SupplierDescrn25.style.display = "none"

            //            txtOrigination.value != '' ?  chkOutDescription.checked = true : chkOutDescription.checked = false;
            //            txtArtwork.value != '' ? chkOutArtwork.checked = true : chkOutArtwork.checked = false;
            //            txtColor.value != '' ? chkOutColour.checked = true : chkOutColour.checked = false;
            //            txtSize.value != '' ? chkOutSize.checked = true : chkOutSize.checked = false;
            //            txtMaterial.value != '' ? chkOutMaterial.checked = true : chkOutMaterial.checked = false;
            //            txtDelivery.value != '' ? chkOutDelivery.checked = true : chkOutDelivery.checked = false;
            //            txtFinishing.value != '' ? chkOutFinishing.checked = true : chkOutFinishing.checked = false;
            //            txtProofs.value != '' ? chkOutProofs.checked = true : chkOutProofs.checked = false;
            //            txtPacking.value != '' ? chkOutPacking.checked = true : chkOutPacking.checked = false;
            //            txtNotes.value != '' ? chkOutNotes.checked = true : chkOutNotes.checked = false;
            //            txtTerms.value != '' ? chkOutInstructions.checked = true : chkOutInstructions.checked = false;
        }
        else {
            alert("More");
            div_OutDescription.style.display = "block";
            div_OutArtwork.style.display = "block";
            div_OutColour.style.display = "block";
            div_OutSize.style.display = "block";
            div_OutMaterial.style.display = "block";
            div_OutDelivery.style.display = "block";
            div_OutFinishing.style.display = "block";
            div_OutProofs.style.display = "block";
            div_OutPacking.style.display = "block";
            div_OutNotes.style.display = "block";
            div_OutInstructions.style.display = "block";
            div_SupplierDescrn1.style.display = "block";
            div_SupplierDescrn2.style.display = "block";
            div_SupplierDescrn3.style.display = "block";
            div_SupplierDescrn4.style.display = "block";
            div_SupplierDescrn5.style.display = "block";
            div_SupplierDescrn6.style.display = "block";
            div_SupplierDescrn7.style.display = "block";
            div_SupplierDescrn8.style.display = "block";
            div_SupplierDescrn9.style.display = "block";
            div_SupplierDescrn10.style.display = "block";
            div_SupplierDescrn11.style.display = "block";
            div_SupplierDescrn12.style.display = "block";
            div_SupplierDescrn13.style.display = "block";
            div_SupplierDescrn14.style.display = "block";
            div_SupplierDescrn15.style.display = "block";
            div_SupplierDescrn16.style.display = "block";
            div_SupplierDescrn17.style.display = "block";
            div_SupplierDescrn18.style.display = "block";
            div_SupplierDescrn19.style.display = "block";
            div_SupplierDescrn20.style.display = "block";
            div_SupplierDescrn21.style.display = "block";
            div_SupplierDescrn22.style.display = "block";
            div_SupplierDescrn23.style.display = "block";
            div_SupplierDescrn24.style.display = "block";
            div_SupplierDescrn25.style.display = "block";
        }
    }
}