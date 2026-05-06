function setLoadingPositionOfDivCenter() {
    if (objdivision) {
        var divisionloading = document.getElementById(objdivision);
        divisionloading.style.left = ((document.body.clientWidth - divisionloading.offsetWidth) / 2) + "px";
        var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
        divisionloading.style.top = (top + divFromTopPos) + "px";
        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
        var docheightcomplete = standardbody.clientHeight;
        var docwidthcomplete = standardbody.clientWidth;
        var DivBack = document.getElementById("divBackGroundNew");
        DivBack.style.left = "0px"
        DivBack.style.width = docwidthcomplete + "px";
        DivBack.style.height = docheightcomplete + "px";
        DivBack.style.top = "0px";
    }
}

function showDivPopupCenter(divId, divHeight) {
    var centerHeight = window.screen.height / 2;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    document.getElementById("divBackGroundNew").style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter);
    setLoadingPositionOfDivCenter();


}

function addFunction(eventObject, eventFiresOn, eventFunction) {
    if (eventObject.addEventListener) eventObject.addEventListener(eventFiresOn, eventFunction, false); else if (eventObject.attachEvent) eventObject.attachEvent('on' + eventFiresOn, eventFunction);
}


function ClostPricecataloguewindow() {
    div_pricecataloguefeatureID.style.display = "none";
}


var row;
var tabel;
function addmore() {
    tabel = document.getElementById('tbladdmore');
    row = document.getElementById('ctl00_ContentPlaceHolder1_hid_norow');
    row.value = Number(row.value) + 1;
    var newrow = Number(row.value);

    //   var ddlsource=document.getElementById('ctl00_ContentPlaceHolder1_ddl1');

    if (tabel != null) {

        var tr1 = tabel.insertRow(tabel.rows.length);

        if (tr1 != null) {
            var td1 = tr1.insertCell(0);
            td1.innerHTML = "<input type='text' class='textboxnew'   id='txtoptionsname" + newrow + "' />";

            var td2 = tr1.insertCell(1);
            td2.innerHTML = "<select class='textboxnew'  id='ddlcosttype" + newrow + "' style='width:100px'></select>";

            var td3 = tr1.insertCell(2);
            td3.innerHTML = "<input type='text' id='txtcost" + newrow + "' MaxLength='200' class='textboxnew' style='width:100px'/>";

            var td4 = tr1.insertCell(3);
            td4.innerHTML = "<input type='text' id='txtcostper" + newrow + "' MaxLength='200' class='textboxnew'   style='width:100px' />";

            var td5 = tr1.insertCell(4);
            td5.innerHTML = "<input type='text' id='txtmarkup" + newrow + "' MaxLength='200' class='textboxnew' style='width:100px' />";

            var td6 = tr1.insertCell(5);
            td6.innerHTML = "<input type='text' id='txtsellingprice" + newrow + "' MaxLength='200' class='textboxnew'   style='width:100px' />";

            var td7 = tr1.insertCell(6);
            td7.innerHTML = "<input type='text' id='txtminimumcost" + newrow + "' MaxLength='100' class='textboxnew'   style='width:100px' />";

            var td8 = tr1.insertCell(7);
            td8.innerHTML = "<input type='checkbox' id='chkdefaultselection" + newrow + "'  />";

        }
    }
}


function ClosePriceCatalogueFeatureoption() {
    div_featuredoptions.style.display = "none";
    div_featuredoptionsadd.style.display = "none";
    document.getElementById("divBackGround").style.display = "none";
}

function Clear_Textbox() {
    //    var txtUserNotes = document.getElementById("<%=txtUserNotes.ClientID %>");
    //    alert(txtUserNotes.value);
    //    txtUserNotes.value = "";
    //    alert(txtUserNotes.value);
}


// START -----------------------------  Common_ReplenishmentAllocation.aspx functions ----------------------------------------------- START //

function ClosePopup_location() {
    document.getElementById("divBackGroundNew").style.display = "none";
}

function addingrowself(tableID, hdnfldid, ProductCatalogueID, ActualOrderedQty, EstimateItemID, purchaseItemID) {
    debugger
    var hdndefaultStockLocation = document.getElementById("hdnDefaultStockLocation").value;
    var hdndefaultlocationid = document.getElementById("hdnDefaultLocationValue").value;
    var hdnlocID = document.getElementById("hdnloc_BackOrder_Allocation").value;
    // get default location and date
    var hdnDateFormat = document.getElementById("hdnDateFormat").value;
    var hdnTodate = document.getElementById("hdnTodate").value;
    var clsName = "";
    var count = document.getElementById(hdnfldid).value.split(',').length;

    if (count == 1) { count = 2; }

    var table = document.getElementById(tableID);
    rowCount = table.rows.length;
    var id;
    if (document.getElementById("hdnselfrowcount").value == 0) {
        id = rowCount;
    }
    else {
        id = document.getElementById("hdnselfrowcount").value;
    }

    var row = table.insertRow(rowCount - 2);

    // var id = rowCount;
    if (rowCount % 2 == 0) {
        clsName = "#EFEFEF";
    }
    else {
        clsName = "";

    }
    //
    var txtlocationwidth = 0;
    if (count == 1) {
        txtlocationwidth = 320 + 'px';
    }
    if (count == 2) {
        txtlocationwidth = 300 + 'px';
    }
    if (count == 3) {
        txtlocationwidth = 225 + 'px';
    }
    if (count == 4) {
        txtlocationwidth = 185 + 'px';
    }
    if (count == 5) {
        txtlocationwidth = 140 + 'px';
    }
    if (count == 6) {
        txtlocationwidth = 120 + 'px';
    }
    //
    var widthunitcosttxt = 70 + 'px';
    if (count == 6) {
        widthunitcosttxt = 54 + 'px'
    }
    var marginleftcaluculate = 0 + 'px';
    row.id = id;
    row.style.backgroundColor = clsName;
    row.style.height = "25px";

    var cell0 = row.insertCell(0);
    cell0.align = "left";
    cell0.innerHTML = "<div align='left'><label id='lblorderedqty" + id + "'>" + ActualOrderedQty + "</label></div>";
    var cell1 = row.insertCell(1);
    cell1.align = "left";
    cell1.innerHTML = "<div align='left'><label id='lblbalanceqty" + id + "'>0</label></div>";

    var cell2 = row.insertCell(2);
    cell2.align = "left";
    cell2.innerHTML = "<input type='text' style='width:80px;text-align:right' onblur='javascript: checkforInteger(this.id,this.value);'  class='textboxnew' id='txtadjustqty" + id + "' value='0'/><input type='hidden' id='hdn_stockselfID" + id + "' value='0' /><input type='hidden' id='hdn_totalqty" + id + "' value='0' /><input type='hidden' id='hdnActualOrderedQty" + ProductCatalogueID + "' value='" + ActualOrderedQty + "' /><input type='hidden' id='hdn_Selected_EstimateItemID" + ProductCatalogueID + "' value='" + EstimateItemID + "' /><input type='hidden' id='hdn_Selected_PurchaseItemID" + ProductCatalogueID + "' value='" + purchaseItemID + "' />";
    var cell3 = row.insertCell(3);
    cell3.align = "left";
    cell3.innerHTML = "<div align='right'><label id='lblopningstock" + id + "'>0</label></div>";

    var cell4 = row.insertCell(4);
    cell4.align = "left";
    cell4.innerHTML = "<div align='right'>0</div>";

    var cell5 = row.insertCell(5);
    cell5.align = "left";
    cell5.innerHTML = "<div align='right'>0</div><input type='hidden' id='hdn_availQty" + id + "' value='0' />";

    var cell6 = row.insertCell(6);
    cell6.align = "right";
    cell6.style.paddingRight = "20px";
    cell6.innerHTML = "<input type='text' style='width:" + widthunitcosttxt + "; text-align:right; margin-left:" + marginleftcaluculate + ";' value='0'  onblur='javascript: pricetodecimal(this," + id + ");CopytxtPricetohdnPrice(this,hdnPrice" + id + ");' class='textboxnew' id='txtprice" + id + "'/><input type='hidden' id='hdnPrice" + id + "' value='0' />";

    // date selector
    debugger    
    //var DateFormat = "dd/mm/yyyy";
    //var dateFormat = '<%= this.DateFormat %>';
    //alert(dateFormat);
    var cell7 = row.insertCell(7);
    cell7.align = "left";
    cell7.innerHTML = "<input id='txtstkdate" + id + "'type='text' style='width:100px;text-align:left' value='" + hdnTodate + "' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'" + hdnDateFormat + "');  class='textboxnew'  />";

    //cell7.innerHTML = '<input id="txtstkdate1" type="text" style="width:100px;text-align:left" value="10/05/2020" onclick="javascript:event.cancelBubble=true;this.select();lcs(this, "dd/mm/yyyy");" class="textboxnew">';
    //cell7.innerHTML = '<input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>';
    //cell7.innerHTML = "<input id='txtstkdate" + id + "'type='text' style='width:100px;text-align:left' value='<%=_commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true) %>' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormat + "');  class='textboxnew'  />";
    //cell7.innerHTML = "<input id='txtstkdate" + id + "'type='text' style='width:100px;text-align:left' value='<%=comm.Eprint_return_Date_Before_View(DateTime.Now.ToString(), CompanyID, UserID, false) %>' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'mm/dd/yyyy');  class='textboxnew'  />";


    var inc = 7;
    // if (Number(hdndefaultStockLocation) != 0) {
    if (hdnlocID == "yes") {
        var cell8 = row.insertCell(8);
        cell8.width = "5%"
        cell8.align = "left";
        cell8.innerHTML = "<span><img style='cursor:pointer;height:12px;width:12px; margin-left: -14px;padding-right: 2px;' title='Add Location' src='" + strImagepath + "plus.gif' onclick=javascript:addstocklocation(" + id + ",'s'); /></span><input id='txtLocation" + id + "' type='text' text='' style='width:" + txtlocationwidth + ";text-align:left;' autocomplete='off' onkeyup=javascript:GetLocationDetails(this,'hdnlocationid" + id + "','Warehouse','" + CompanyID + "','1',event);  onclick=javascript:GetLocationDetails(this,'hdnlocationid" + id + "','Warehouse','" + CompanyID + "','1',event);  value='" + hdndefaultStockLocation + "' onblur='javascript:chkloc(this.value,hdnlocationid" + id + ");'  class='textboxnew'/><input type='hidden' id='hdnlocationid" + id + "' value='" + hdndefaultlocationid + "' />";
        //inc = 8;
        inc = 9;
        count = count - 1;
    }
    //var inc = 2;
    //var p = 0;
    //for (var i = 0; i < count; i++) {
    //    p = p + 1;
    //    var cell9 = row.insertCell(inc);
    //    cell9.align = "left";
    //    if (document.getElementById(hdnfldid).value.split(',')[p] != undefined) {
    //        cell9.innerHTML = "<input type='text' style='width:" + txtlocationwidth + ";text-align:left'  class='textboxnew' id='txtcustomfield" + document.getElementById(hdnfldid).value.split(',')[p] + "_" + id + "'/>";
    //    } else {
    //        cell9.innerHTML = "<input type='text' style='width:" + txtlocationwidth + ";text-align:left'  class='textboxnew' id='txtcustomfield" + 20 + "_" + id + "'/>";
    //    }
    //    inc = inc + 1;
    //}
    // incorrect po no issue
    var p = 1;
    for (var i = 0; i < count; i++) {
        p = p + 1;
        var cell9 = row.insertCell(inc);
        cell9.align = "left";
        if (document.getElementById(hdnfldid).value.split(',')[p] != undefined) {
            cell9.innerHTML = "<input type='text' style='width:" + txtlocationwidth + ";text-align:left'  class='textboxnew' id='txtcustomfield" + p + "'/>";
        } else {
            cell9.innerHTML = "<input type='text' style='width:" + txtlocationwidth + ";text-align:left'  class='textboxnew' id='txtcustomfield" + p + "'/>";
        }
        inc = inc + 1;
    }

    var cell10 = row.insertCell(inc);
    cell10.align = "right";
    cell10.style.paddingRight = "10px";
    cell10.innerHTML = "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0'   title='Remove' onclick=javascript:Remove_Row(" + id + ",'" + tableID + "'); />";

    document.getElementById("hdnselfrowcount").value = parseInt(id) + 1;
    loadtextbox(id);
    return false;
}
//function AllocationPopUp(id) {
//    var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1330', '520');
//    SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
//    //SetRadWindow('divrad', 'divBackGroundNew', '200');
//    Rad1Customer.setSize(1330, 520);
//    Rad1Customer.center();
//    Rad1Customer.id = "Radwindowstock";
//}

function loadtextbox(value) {
    if (value > 2) {
        var txtLocation = document.getElementById("txtLocation" + value);
        if (txtLocation != null && txtLocation != undefined) {
            txtLocation.value = SpecialDecode(txtLocation.value);
        }
    }
    else {
        for (var i = 1; i <= value; i++) {
            var txtLocation = document.getElementById("txtLocation" + i);
            if (txtLocation != null && txtLocation != undefined) {
                txtLocation.value = SpecialDecode(txtLocation.value);
            }
        }
    }
}

function Remove_Row(index, tableID) {
    var NoOfRows = 0;
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    if (rowCount <= 2) {
        alert('All rows cannot be deleted.');
        return false;
    }
    var row = document.getElementById(index);
    row.parentNode.removeChild(row);
}

function chkloc(locvalue, hdnid) {
    if (locvalue == '') {
        (hdnid).value = '';
    }
}

function GetTopLocation(LocationID, LocationName) {
    document.getElementById("hdnlocationid" + indexvalue).value = LocationID;
    document.getElementById("txtLocation" + indexvalue).value = LocationName;
}

function SetRadWindow(divMaskID, divBackgroundID) {
    var Div_Customer = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);

    if (document.getElementById(divMaskID).style.display == "none") {

        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(Div_Customer);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
    else {
        showDivPopupCenter_Ver2(divMaskID);
    }
}

var IsNegativeQtyExistSave = false;
var lblItemStatus = '';
var PW = parent.window;
function getSelfStockDetails(TableID, ProductCatalogueID, SaveType, rcount, ActualOrderdQty, ReceivedQty) {
    debugger;
    //var ActualOrderdQty = document.getElementById('hdnActualOrderedQty'+ProductCatalogueID).value;
    var EstimateItemID = 0;
    var PurchaseItemID = 0;
    //var hdnstockselfdetails = document.getElementById("<%=hdnstockselfdetails.ClientID %>")
    var totalstockqty = 0;
    var rqty = 0;
    var stockdata = '';
    var tblid = document.getElementById(TableID);
    var rowid = document.getElementById(TableID.id).getElementsByTagName('tr');


    var IsNegativeQtyExist = false;
    var IsNegativeAlert = false;

    for (j = 1; j < (rowid.length) ; j++) {
        if (typeof rowid[j].id != 'undefined' && rowid[j].id != undefined && rowid[j].id != null && rowid[j].id != '') {
            var inputs = rowid[j].getElementsByTagName('input');
            for (var n = 0; n < inputs.length; n++) {
                if ((inputs[n].id).indexOf('hdn_availQty') > -1) {
                    if (Number(inputs[n].value) < 0) {
                        IsNegativeQtyExist = true;
                    }
                }
            }
        }
    }

    var PositiveRowCount = 0;
    for (j = 1; j < (rowid.length) ; j++) {
        if (typeof rowid[j].id != 'undefined' && rowid[j].id != undefined && rowid[j].id != null && rowid[j].id != '') {
            var inputs = rowid[j].getElementsByTagName('input');
            var availQty = 0;
            var QtyAdjustment = 0;
            for (var n = 0; n < inputs.length; n++) {
                if ((inputs[n].id).indexOf('txtadjustqty') > -1) {                                          //(inputs[n].id == 'txtopnstock') {
                    stockdata += 'openstock»' + inputs[n].value + '±';
                    QtyAdjustment = inputs[n].value;
                    totalstockqty = parseInt(totalstockqty) + parseInt(inputs[n].value);
                }
                if ((inputs[n].id).indexOf('hdn_availQty') > -1) {
                    availQty = inputs[n].value;
                    if (Number(inputs[n].value) >= 0) {
                        PositiveRowCount = 1;
                    }
                }
                if ((inputs[n].id).indexOf('hdnlocationid') > -1) {                                     //inputs[n].id =='hdnlocationid') {
                    stockdata += 'customfield1»' + inputs[n].value + '±';
                    if ((typeof inputs[n].value == 'undefined' || inputs[n].value == undefined || inputs[n].value == null || inputs[n].value == '' || Number(inputs[n].value) == 0) && Number(QtyAdjustment) > 0) {
                        alert("Please select location");
                        inputs[n].focus();
                        stockdata = '';
                        hdnstockselfdetails.value = '';
                        return false;
                    }
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
                    stockdata += 'EstimateItemID»' + inputs[n].value + '±';
                    EstimateItemID = inputs[n].value;
                }
                if ((inputs[n].id).indexOf('hdn_Selected_PurchaseItemID') > -1 && IsFrom == 'purchase') {
                    stockdata += 'PurchaseItemID»' + inputs[n].value + '±';
                    PurchaseItemID = inputs[n].value;
                }
            }
            stockdata += 'ProductCatalogueID»' + ProductCatalogueID + '±µ';

            if (IsNegativeQtyExist && Number(availQty) < 0 && Number(QtyAdjustment) >= Math.abs(Number(availQty))) {
                IsNegativeAlert = false;
            } else if (IsNegativeQtyExist && Number(availQty) < Number(0) && PositiveRowCount > 0) {
                IsNegativeAlert = true;
            }
        }
    }
    //hdntotalstockqty.value = totalstockqty;
    //if (Number(totalstockqty) + ReceivedQty > Number(ActualOrderdQty)) { modification by bilal
    // var AlrtTxt = Total_Qty_should_always_be_equal_to_the_Original_Qty;
    //alert(AlrtTxt);
    //return false;
    //} else {

    if (IsNegativeAlert && !IsNegativeQtyExistSave) {
        $("#dialog-confirm").dialog({
            resizable: false,
            width: '440px',
            modal: true,
            buttons: {
                Cancel: function () {
                    $(this).dialog("close");
                },
                "Save": function () {
                    $(this).dialog("close");
                    IsNegativeQtyExistSave = true;
                    getSelfStockDetails(TableID, ProductCatalogueID, SaveType, rcount, ActualOrderdQty);
                }
            }
        });
        $("#dialog-confirm").dialog('open');
        return false;
    }
    hdnstockselfdetails.value = stockdata;
    //if (stockdata == null) {
    //    hdnstockselfdetails.value = '';
    //}
    //else {
    //    hdnstockselfdetails.value = stockdata;
    //}
    
    if (SaveType.indexOf('btn_SaveandStayReplenishAllocation') > -1) {

        document.getElementById('div_btn_SaveandStayReplenishAllocation' + rcount).style.display = 'none';
        document.getElementById('div_stayprocess' + rcount).style.display = 'block';
        tblid_ProductCatalogueID = ProductCatalogueID;
        hdnaccordionIndex.value = rcount;
        if (IsFrom != 'purchase') {
            lblItemStatus = PW.document.getElementById("lblItemStatus_" + EstimateItemID);
            if (QtyAdjustment != 0) {
                item_summary.EstJobInvIduvidualItemStatuS_Update(CompanyID, EstimateItemID, 0, ReplenishStatusID, 'job', Replenish_ItemResult, onTimeout, onError);
            }
        }
        __doPostBack("lnkbtn_Replenish_SaveandStay", '');
        return true;
    } else {
        document.getElementById('div_btn_SaveReplenishAllocation' + rcount).style.display = 'none';
        document.getElementById('div_saveprocess' + rcount).style.display = 'block';
        if (IsFrom != 'purchase') {
            lblItemStatus = PW.document.getElementById("lblItemStatus_" + EstimateItemID);
            if (QtyAdjustment != 0) {
                item_summary.EstJobInvIduvidualItemStatuS_Update(CompanyID, EstimateItemID, 0, ReplenishStatusID, 'job', Replenish_ItemResult, onTimeout, onError);
            }           
        }

        __doPostBack("lnkbtn_Replenish_Save", '');
        return false;
        window.close();
    }
}
//}

function Replenish_ItemResult(ISReplinished) {
    if (Number(ISReplinished.split(',')[0].trim())) {
        var lblUpdateMsg = PW.document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblUpdateMsg");
        var lblMainStatus = PW.document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblStatusTitle");
        if (typeof lblItemStatus != 'undefined' && lblItemStatus != undefined && lblItemStatus != null) {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = ReplenishStatusTitle;
            lblUpdateMsg.innerHTML = Job_Item_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        }

        if (Number(ISReplinished.split(',')[1].trim()) != 0) {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = Job_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            lblMainStatus.textContent = ReplenishStatusTitle;
            setTimeout("TakeOut()", 2000);
        }
    }
}

function checkforIntegerSelf(txtadjust, s, totqty, backorder) {
    var i;
    s = s.toString();
    if (s == '') {
        document.getElementById(txtadjust).value = 0;
    }
    //else if (sv == '-' && Number(s) > Number(totqty.value)) {
    //    document.getElementById(txtadjust).value = 0;
    //}
    //else if (sv == 'Move' && Number(s) > Number(totqty.value)) {
    //    document.getElementById(txtadjust).value = 0;
    //}
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            document.getElementById(txtadjust).value = 0;
            return false;
        }
    }
}

function ReplenishWindow_Close() {
    if (IsFrom == 'purchase') {
        var pw = window.parent;

        if (SaveType == "save") {
            pw.document.getElementById("ctl00_ContentPlaceHolder1_btnSavegoodsrcvd").click();
        }
        else if (SaveType == "stay") {
            pw.document.getElementById("ctl00_ContentPlaceHolder1_btnSaveandStaygoodsrcvd").click();
        }
    } else {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        window.parent.location.reload();
        oWindow.close();
    }
}

function CopytxtPricetohdnPrice(thistxtprice, thishdnprice) {
    thishdnprice.value = thistxtprice.value;
}


// END -----------------------------  Common_ReplenishmentAllocation.aspx functions ----------------------------------------------- END //

// START -----------------------------  productcatalogueitem_stock.aspx functions ----------------------------------------------- START //

function addOtherproductrow(tableID) {
    var clsName = "";
    var table = document.getElementById(tableID);

    var rowCount = table.rows.length;
    var id;
    if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnotherproductsrowcount").value == 0) {
        id = rowCount + 1;
    }
    else {
        id = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnotherproductsrowcount").value;
    }

    var row = table.insertRow(rowCount);

    //var id = rowCount;
    if (rowCount % 2 == 0) {
        clsName = "#EFEFEF";
    }
    else {
        clsName = "";

    }
    row.id = id;
    row.style.backgroundColor = clsName;
    row.style.height = "25px";
    var cell1 = row.insertCell(0);
    cell1.align = "left";
    cell1.innerHTML = "<input type='text' style='width:165px;text-align:left' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherKitItemID" + id + "','txtitemtitle" + id + "','Products','" + CompanyID + "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherKitItemID" + id + "','txtitemtitle" + id + "','Products','" + CompanyID + "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitle" + id + "');  class='textboxnew' id='txtitemcode" + id + "'/><input type='hidden' id='hdnOtherKitItemID" + id + "' value='0' />";
    var cell2 = row.insertCell(1);
    cell2.align = "left";
    cell2.innerHTML = "<input type='text' style='width:365px;text-align:left' disabled='true'   class='textboxnew' id='txtitemtitle" + id + "'/>";
    var cell3 = row.insertCell(2);
    cell3.align = "left";
    cell3.innerHTML = "<input type='text' style='width:75px;text-align:right' value='1'  onkeyup='javascript:checkforIntegerone(this.id,this.value);' onblur='javascript:checkforIntegerone(this.id,this.value);'   class='textboxnew' id='txtunit" + id + "'/>";
    var cell4 = row.insertCell(3);
    cell4.align = "center";
    cell4.innerHTML = "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(" + id + ",'tblother'); />";

    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnotherproductsrowcount").value = parseInt(id) + 1;
    return false;
}

function Remove_Row(index, tableID) {

    var NoOfRows = 0;
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    if (rowCount <= 2) {
        alert('All rows cannot be deleted.');
        return false;
    }
    var row = document.getElementById(index);
    row.parentNode.removeChild(row);
    //var row = document.getElementById("td_" + index + "");

    //var Child_Obj = document.getElementById("td_" + index + "");
    //table.removeChild(Child_Obj);
    //Child_Obj.parentNode.removeChild(Child_Obj);
}

function Remove_RowEdit(index, tableID) {

    var NoOfRows = 0;
    var table = document.getElementById(tableID);
    var rowCount = table.rows.length;
    if (rowCount <= 2) {
        alert('All rows cannot be deleted.');
        return false;
    }
    var row = document.getElementById(index);
    row.parentNode.removeChild(row);

}

function pricetodecimal(obj, index) {

    if (!isNaN(obj.value)) {
        obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);
    }
    else {
        obj.value = "0.00";
    }
}

function addstocklocation(index, DrawType) {

    RadLocation = window.radopen(strSitePath + "common/common_addstocklocation.aspx", '0', '0');
    document.getElementById("div_stockmanagement").style.position = "static";
    SetRadWindow_Ver2('div_radlocation', 'divBackGroundNew');
    RadLocation.setSize(630, 320);
    RadLocation.center();
    //RadLocation.moveTo("250px", "100px");
    indexvalue = index;
    type = DrawType;
}

function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
    var Div_Customer = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);

    if (document.getElementById(divMaskID).style.display == "none") {

        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(Div_Customer);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
    else {
        showDivPopupCenter_Ver2(divMaskID);
    }
}

function OnClientClose() {
    var rad = document.getElementById("divBackGroundNew");
    rad.style.display = "none";
    document.getElementById("div_stockmanagement").style.position = "absolute";

}

function GetTopLocation(LocationID, LocationName) {
    if (type == 's') {
        document.getElementById("hdnlocationid" + indexvalue).value = LocationID;
        document.getElementById("txtLocation" + indexvalue).value = SpecialDecode(LocationName);
    }
    else if (type == 'w') {
        document.getElementById("txtWhLocation" + indexvalue).value = SpecialDecode(LocationName);
        document.getElementById("hdnWhlocationid" + indexvalue).value = LocationID;
    }
}

function slideIt(id) {

    // document.getElementById("div_Load").style.display = "block";
    var slidingDiv = document.getElementById(id);
    var stopPosition = 1500;

    if (parseInt(slidingDiv.style.left) < stopPosition) {

        slidingDiv.style.left = parseInt(slidingDiv.style.left) + 70 + "px";
        setTimeout("slideIt('div_stockmanagement')", 15);

    }
    //setTimeout("LoadImgStarts()", 0);
    setTimeout("divdisp()", 600);


}

function divdisp() {

    document.getElementById('div_stockmanagement').style.display = 'none';
    var stockdiv = document.getElementById('div_StockHistory');
    stockdiv.style.right = 0 + "px";
    document.getElementById('div_StockHistory').style.display = 'block';
    //setTimeout("loadends()", 1000);
    //__doPostBack('ctl00$ContentPlaceHolder1$ctl00$btninvenntory', '');
}

function slidehistory(id) {

    var slidingDiv = document.getElementById(id);
    var stopPosition = 1500;

    if (parseInt(slidingDiv.style.right) < stopPosition) {

        slidingDiv.style.right = parseInt(slidingDiv.style.right) + 70 + "px";
        setTimeout("slidehistory('div_StockHistory')", 15);

    }

    setTimeout("divdispstock()", 400);

}

function divdispstock() {

    document.getElementById('div_StockHistory').style.display = 'none';
    var stockdiv = document.getElementById('div_stockmanagement');
    stockdiv.style.left = 0 + "px";
    document.getElementById('div_stockmanagement').style.display = 'block';
}

function getrecord() {
    __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkdownload', '');
}

function IsIntegerParameter(s, spanid) {
    var i;
    s = s.toString();
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            if (spanid != '') {
                document.getElementById(spanid).style.display = "block";
            }
            return false;
        }
    }
    if (spanid != '') {
        document.getElementById(spanid).style.display = "none";
    }
    return true;
}

function RemoveZeros(sender, args) {
    var tbValue = sender._textBoxElement.value;
    if (tbValue.indexOf(".00") != -1)
        sender._textBoxElement.value = tbValue.substr(0, tbValue.indexOf(".00"));
}

function LoadImgStarts() {
    //document.getElementById("ds00").style.display = "block";
    document.getElementById("div_Load").style.display = "block";
}

function loadends() {
    document.getElementById("div_Load").style.display = "none";
}

function CheckStringMandatory(val, spanid) {
    if (trim12(val) != '') {
        document.getElementById(spanid).style.display = "none";
        return true;
    }
    else {
        document.getElementById(spanid).style.display = "block";
        return false;

    }
}

function checkforInteger(txtadjust, s) {
    var i;
    s = s.toString();
    if (s == '') {
        document.getElementById(txtadjust).value = 0;
    }
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            document.getElementById(txtadjust).value = 0;
            return false;
        }
    }
}

function checkforIntegerone(txtadjust, s) {
    var i;
    s = s.toString();
    if (s == '') {
        document.getElementById(txtadjust).value = 1;
    }
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            document.getElementById(txtadjust).value = 1;
            return false;
        }
    }
}

//to save additional options adjustments

function GetAdditionalEditDetails() {
    var hdnAdditionalStockAdjustment = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnAdditionalStockAdjustment");
    var AdditionalStockDetails = '';
    var adjval;
    var tblid = document.getElementById("tbladditionaladjustment");
    var rowid = document.getElementById('tbladditionaladjustment').rows.length;

    for (p = 0; p < (rowid - 1) ; p++) {
        adjval = document.getElementById("txtadjustqty" + p + "").value;
        var e = document.getElementById("ddlplusminus" + p + "");
        var action = e.options[e.selectedIndex].value;
        var hdnselfid = document.getElementById("hdn_stockadditionalID" + p + "");
        var hdnchoiceid = document.getElementById("hdnadjchoiceid" + p + "");

        if (action == 'Move') {
            var rows = document.getElementById('tbladditionaladjustment').getElementsByTagName('tr');
            var inputs = rows[(p + 1)].getElementsByTagName('input');
            AdditionalStockDetails += 'additionalstockID»' + hdnselfid.value + '±';
            AdditionalStockDetails += 'adjustqty»M~' + adjval + '±';
            AdditionalStockDetails += 'choiceid»' + hdnchoiceid.value + '±';
            for (n = 0; n < inputs.length; n++) {
                if ((inputs[n].id).indexOf('hdn_Adjustment_locationid_' + (p + 1)) > -1) {
                    AdditionalStockDetails += 'customfield1»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_2') {
                    AdditionalStockDetails += 'customfield2»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_3') {
                    AdditionalStockDetails += 'customfield3»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_4') {
                    AdditionalStockDetails += 'customfield4»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_5') {
                    AdditionalStockDetails += 'customfield5»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_6') {
                    AdditionalStockDetails += 'customfield6»' + inputs[n].value + '±';
                }
            }
            AdditionalStockDetails += 'µ';
        }
        else if (adjval != Number(0)) {
            AdditionalStockDetails += 'additionalstockID»' + hdnselfid.value + '±';
            AdditionalStockDetails += 'adjustqty»' + action + "~" + adjval + '±';
            AdditionalStockDetails += 'choiceid»' + hdnchoiceid.value + 'µ';
        }
    }

    hdnAdditionalStockAdjustment.value = AdditionalStockDetails;
    return true;
}

function chkloc(locvalue, hdnid) {
    if (locvalue == '') {
        (hdnid).value = '';
    }
}

function loadtextbox(value) {
    if (value > 2) {
        var txtLocation = document.getElementById("txtLocation" + value);
        if (txtLocation != null && txtLocation != undefined) {
            txtLocation.value = SpecialDecode(txtLocation.value);
        }

    }
    else {
        for (var i = 1; i <= value; i++) {
            var txtLocation = document.getElementById("txtLocation" + i);
            if (txtLocation != null && txtLocation != undefined) {
                txtLocation.value = SpecialDecode(txtLocation.value);
            }
        }
    }

}

function rdoNone_checked(rdonone) {
    if (document.getElementById(rdonone).checked) {
        document.getElementById("spn_To").style.display = "none";
    }
}

function View_detailed_stock_details() {
    var div_popupAction = document.getElementById("div_popupAction");
    if (div_popupAction.style.display == 'none') {
        div_popupAction.style.display = 'block';
        return false;
    }
    else if (div_popupAction.style.display == 'block') {
        div_popupAction.style.display = 'none';
        return false;
    }
}

function EnableLocationFields(ddlId, Num, tableid, Totalqty, Availqty) {
    var ddlplusminus = document.getElementById(ddlId);
    var Adjustment_Location = document.getElementById(tableid.id);
    var txt_Adjustment_Location_Count = Adjustment_Location.getElementsByTagName('tr');
    if (ddlplusminus.value == 'Move') {
        for (var i = 1; i < txt_Adjustment_Location_Count.length; i++) {
            var inputs = txt_Adjustment_Location_Count[i].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                var txtadjustqty = document.getElementById("txtadjustqty" + (Num - 1));
                var Location = document.getElementById("txt_Adjustment_Location_" + Num);
                var CustomField2 = document.getElementById("txt_Adjustment_customfield_" + Num + "_2");
                var CustomField3 = document.getElementById("txt_Adjustment_customfield_" + Num + "_3");
                var CustomField4 = document.getElementById("txt_Adjustment_customfield_" + Num + "_4");
                var CustomField5 = document.getElementById("txt_Adjustment_customfield_" + Num + "_5");
                var CustomField6 = document.getElementById("txt_Adjustment_customfield_" + Num + "_6");
                if (Number(txtadjustqty.value) > Number(Totalqty.value)) {
                    txtadjustqty.value = 0;
                }
                $(txtadjustqty).removeAttr('disabled');
                $(Location).removeAttr('disabled');
                $(CustomField2).removeAttr('disabled');
                $(CustomField3).removeAttr('disabled');
                $(CustomField4).removeAttr('disabled');
                $(CustomField5).removeAttr('disabled');
                $(CustomField6).removeAttr('disabled');
            }
        }
    } else {
        for (var i = 1; i < txt_Adjustment_Location_Count.length; i++) {
            var inputs = txt_Adjustment_Location_Count[i].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                var txtadjustqty = document.getElementById("txtadjustqty" + (Num - 1));
                var Location = document.getElementById("txt_Adjustment_Location_" + Num);
                var CustomField2 = document.getElementById("txt_Adjustment_customfield_" + Num + "_2");
                var CustomField3 = document.getElementById("txt_Adjustment_customfield_" + Num + "_3");
                var CustomField4 = document.getElementById("txt_Adjustment_customfield_" + Num + "_4");
                var CustomField5 = document.getElementById("txt_Adjustment_customfield_" + Num + "_5");
                var CustomField6 = document.getElementById("txt_Adjustment_customfield_" + Num + "_6");
                if (ddlplusminus.value == '-') {
                    if (Number(txtadjustqty.value) > Number(Totalqty.value) || Number(Availqty.value) < Number(0)) {
                        txtadjustqty.value = 0;
                    }
                } else if (ddlplusminus.value.toLowerCase() == 'select') {
                    txtadjustqty.value = 0;
                }
                $(Location).attr('disabled', true);
                $(CustomField2).attr('disabled', true);
                $(CustomField3).attr('disabled', true);
                $(CustomField4).attr('disabled', true);
                $(CustomField5).attr('disabled', true);
                $(CustomField6).attr('disabled', true);
            }
        }
    }
}


// END -----------------------------  productcatalogueitem_stock.aspx functions ----------------------------------------------- END //