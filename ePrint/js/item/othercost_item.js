// JScript File
//************************* OTHER COST ********************************
function BindOtherCost(id, itemtype) {

    var catid = '';
    var othercosts = ""; //hid_OtherCostValues_Load.value;//'OtherCostValues';    

    var divContent = document.getElementById("divContent");
    divContent.innerHTML = '';
    var spncatid = id.replace('spncost', 'spncostcatid'); //"spncostcatid_"+i; 
    catid = document.getElementById(spncatid).innerHTML;

    //BY VINAY
    PageMethods.GetOtherCost_List(CompanyID, catid, hid_EstimateType.value, function Create_Other(retnValue) {

        divContent.innerHTML = "";
        othercosts = retnValue;


        var GuillotineID = 0;
        var PaperID = 0;
        var PressID = 0;
        var EstOtherCostID = 0;
        if (itemtype == "s") {
            PressID = hid_PressID.value;
            PaperID = hid_PaperID.value;
            GuillotineID = hid_GuillotineID.value;
        }

        // *** To Bind OtherCosts ***//
        var str = othercosts.split('±');
        var count = 0;
        if (str != "") {

            for (var j = 0; j < str.length; j++) {
                document.getElementById("divsubheader").style.display = 'block';
                document.getElementById("divHeader").style.border = '1px solid silver';
                var str2 = str[j].split('»');



                if (catid == str2[0] || catid == 0 || catid == -1) {
                    count++;
                    var color1 = "#DADADA";
                    if (count % 2 == 0) {
                        color1 = "#EFEFEF";
                    }


                    var CostCatID = str2[0];
                    var CostID = str2[1];
                    var CostName = str2[2];
                    var CostDesc = str2[3];
                    var CostTimeBasedID = str2[4];
                    var CostCalType = str2[5];
                    var isMandatory = false;
                    // to show the mandatory othercost
                    var ArrayOtherCostSequenceIDs = hdnOtherCostSequenceIDs.value.split(',');
                    for (var d = 0; d < ArrayOtherCostSequenceIDs.length; d++) {
                        if (ArrayOtherCostSequenceIDs[d] == CostID) {
                            isMandatory = true;
                        }
                    }
                    // to show the mandatory othercost


                    var Mode = 'add';
                    var div22 = "<div style='height:auto; line-height:18px;margin:0; padding:2px;background-color:" + color1 + "'>"

                    if (isMandatory) {

                        div22 += "<div id='div_nameid' style='float:left;width:49%;height:auto;overflow-x: hidden'><a href='#' onclick=javascript:OpenPopup('" + CostID + "','" + CostTimeBasedID + "','" + CostCalType + "','" + itemtype + "','" + Mode + "','','" + GuillotineID + "','" + PaperID + "','" + PressID + "','" + EstOtherCostID + "');return false;>" + SpecialDecode(CostName) + " <span style='color: Red;'>*</span></a></div>";
                    }
                    else {
                        div22 += "<div id='div_nameid' style='float:left;width:49%;height:auto;overflow-x: hidden'><a href='#' onclick=javascript:OpenPopup('" + CostID + "','" + CostTimeBasedID + "','" + CostCalType + "','" + itemtype + "','" + Mode + "','','" + GuillotineID + "','" + PaperID + "','" + PressID + "','" + EstOtherCostID + "');return false;>" + SpecialDecode(CostName) + "</a></div>";
                    }
                    div22 += "<div id='div_descriptionid' style='float:left;width:49%;height:auto;overflow-x: hidden;'>" + SpecialDecode(CostDesc) + "</div>";
                    div22 += "<div class='onlyEmpty'></div>";
                    div22 += "</div>"
                    divContent.innerHTML = divContent.innerHTML + div22;
                    divContent.style.width = "100%";
                    divContent.style.height = "300px";
                    divContent.style.overflowX = "hidden";
                    divContent.style.overflowY = "scroll";

                    div_nameid.innerHTML = div_nameid.innerHTML;
                    try {
                        div_nameid.style.width = "49%";
                        div_nameid.style.height = "auto";
                        div_nameid.style.overflowX = "hidden";
                        div_nameid.style.overflowY = "hidden";

                        div_descriptionid.innerHTML = div_descriptionid.innerHTML;
                        div_descriptionid.style.width = "49%";
                        div_descriptionid.style.height = "auto";
                        div_descriptionid.style.overflowX = "hidden";
                        div_descriptionid.style.overflowY = "hidden";
                    } catch (err) { }
                }
                else {
                }
            }
            if (count == 0) {
                document.getElementById("divsubheader").style.display = 'none';
                document.getElementById("divHeader").style.border = '0px solid silver';
                var div22 = "<div style='height:auto;padding:2px;background-color:" + color1 + "'>"
                div22 += "<div class='emptyrecords' style='width:100%' align='center'><span class='HeaderText' style='text-align: center'>No record(s) found</span></div>";
                div22 += "<div class='onlyEmpty'></div>";
                div22 += "</div>"
                divContent.innerHTML = divContent.innerHTML + div22;
                divContent.removeAttribute("style");
                divContent.style.width = "100%";
            }
        }
        else {
            document.getElementById("divsubheader").style.display = 'none';
            document.getElementById("divHeader").style.border = '0px solid silver';
            var div22 = "<div style='height:auto;padding:2px;background-color:" + color1 + "'>"
            div22 += "<div class='emptyrecords' style='width:100%' align='center'><span class='HeaderText' style='text-align: center'>No record(s) found</span></div>";
            div22 += "<div class='onlyEmpty'></div>";
            div22 += "</div>"
            divContent.innerHTML = divContent.innerHTML + div22;
            divContent.removeAttribute("style");
            divContent.style.width = "100%";
        }
        // *** To Bind OtherCosts ***//
    }
    , other_error);
}
function other_error(error) {

}
function OpenPopup(costid, costtypeid, caltype, itemtype, mode, otherinx, guillotineid, paperid, pressid, estothercostid) {

    OtherIndex = '';
    OtherIndex = otherinx;
    if (mode == 'add' || mode == 'editonload') {
        onblur_estQtyLists();
    }
    if (otherinx != '') {


        EditOtherPopupValues = '';
        //EditOtherPopupValues += "Description" +"»"+ ArrayOtherCost[OtherIndex].Description;


        if (ArrayOtherCost[OtherIndex].CalculationType == 't') {
            var OtherTime = ArrayOtherCost[OtherIndex].OtherCostTime;
            EditOtherPopupValues += "HourlyRate" + "»" + OtherTime.HourlyRate + "±";
            EditOtherPopupValues += "SetUpTime" + "»" + OtherTime.SetUpTime + "±";
            EditOtherPopupValues += "Hours" + "»" + OtherTime.Hours + "±";
            EditOtherPopupValues += "Passes" + "»" + OtherTime.Passes + "±";
            EditOtherPopupValues += "Cost" + "»" + OtherTime.Cost + "±";
            EditOtherPopupValues += "Markup" + "»" + OtherTime.Markup + "±";
            EditOtherPopupValues += "HourlyRunSpeed" + "»" + OtherTime.HourlyRunSpeed;
            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherTime.SellingPrice;                
        }
        else if (ArrayOtherCost[OtherIndex].CalculationType == 'q') {
            var OtherQty = ArrayOtherCost[OtherIndex].OtherCostQuantity;
            EditOtherPopupValues += "UnitRate" + "»" + OtherQty.UnitRate + "±";
            EditOtherPopupValues += "UnitRate1" + "»" + OtherQty.UnitRate1 + "±";
            EditOtherPopupValues += "UnitRate2" + "»" + OtherQty.UnitRate2 + "±";
            EditOtherPopupValues += "UnitRate3" + "»" + OtherQty.UnitRate3 + "±";

            EditOtherPopupValues += "Quantity" + "»" + OtherQty.Quantity + "±";
            EditOtherPopupValues += "Quantity1" + "»" + OtherQty.Quantity1 + "±";
            EditOtherPopupValues += "Quantity2" + "»" + OtherQty.Quantity2 + "±";
            EditOtherPopupValues += "Quantity3" + "»" + OtherQty.Quantity3 + "±";

            EditOtherPopupValues += "Markup" + "»" + OtherQty.Markup + "±";
            EditOtherPopupValues += "Markup1" + "»" + OtherQty.Markup1 + "±";
            EditOtherPopupValues += "Markup2" + "»" + OtherQty.Markup2 + "±";
            EditOtherPopupValues += "Markup3" + "»" + OtherQty.Markup3 + "±";

            EditOtherPopupValues += "SetUpTime" + "»" + OtherQty.SetUpTime + "±";
            EditOtherPopupValues += "HourlyRate" + "»" + OtherQty.HourlyRate + "±";
            EditOtherPopupValues += "Cost" + "»" + OtherQty.Cost + "±";
            EditOtherPopupValues += "Cost1" + "»" + OtherQty.Cost1 + "±";
            EditOtherPopupValues += "Cost2" + "»" + OtherQty.Cost2 + "±";
            EditOtherPopupValues += "Cost3" + "»" + OtherQty.Cost3;

            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherQty.SellingPrice;                                      
        }
    }
    var estitemid = hid_EstimateItemID.value;
    var mainestitemtype = hid_EstimateType.value;
    var booksecid = hid_BookletSectionID.value;
    var pg = pgtype;
    //PopupCenter(strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "", '950', '500');
    // window.radopen(strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "", '950', '600');
    // SetRadWindow('divrad', 'divBackGroundNew', '200');
    if (mode == 'add' || mode == 'editonload') {
        var MainOtheCostQty = hdn_EstQtyList.value;
    }
    //    if (isfrom_eStore != "yes") {
    if (mode == 'add') {
        if (estimateType == 'm') {
            //MainOtheCostQty = hdn_EstQtyList.value;
            if (jobQtyCheck == 0) {
                document.getElementById("spn_txtQuantity").style.display = "Block";
                return false;
            }
        }
    }
    // }
    var RadWindow_open = window.radopen(strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "&EstQtyList=" + MainOtheCostQty + "");
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindow_open.setSize(1225, 550);
    RadWindow_open.center();
}

function GetPopupPath(costid, costtypeid, caltype, itemtype, mode, otherinx, guillotineid, paperid, pressid, estothercostid) {

    OtherIndex = '';
    OtherIndex = otherinx;
    if (mode == 'add' || mode == 'editonload') {
        onblur_estQtyLists();
    }
    if (otherinx != '') {


        EditOtherPopupValues = '';
        //EditOtherPopupValues += "Description" +"»"+ ArrayOtherCost[OtherIndex].Description;


        if (ArrayOtherCost[OtherIndex].CalculationType == 't') {
            var OtherTime = ArrayOtherCost[OtherIndex].OtherCostTime;
            EditOtherPopupValues += "HourlyRate" + "»" + OtherTime.HourlyRate + "±";
            EditOtherPopupValues += "SetUpTime" + "»" + OtherTime.SetUpTime + "±";
            EditOtherPopupValues += "Hours" + "»" + OtherTime.Hours + "±";
            EditOtherPopupValues += "Passes" + "»" + OtherTime.Passes + "±";
            EditOtherPopupValues += "Cost" + "»" + OtherTime.Cost + "±";
            EditOtherPopupValues += "Markup" + "»" + OtherTime.Markup + "±";
            EditOtherPopupValues += "HourlyRunSpeed" + "»" + OtherTime.HourlyRunSpeed;
            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherTime.SellingPrice;                
        }
        else if (ArrayOtherCost[OtherIndex].CalculationType == 'q') {
            var OtherQty = ArrayOtherCost[OtherIndex].OtherCostQuantity;
            EditOtherPopupValues += "UnitRate" + "»" + OtherQty.UnitRate + "±";
            EditOtherPopupValues += "UnitRate1" + "»" + OtherQty.UnitRate1 + "±";
            EditOtherPopupValues += "UnitRate2" + "»" + OtherQty.UnitRate2 + "±";
            EditOtherPopupValues += "UnitRate3" + "»" + OtherQty.UnitRate3 + "±";

            EditOtherPopupValues += "Quantity" + "»" + OtherQty.Quantity + "±";
            EditOtherPopupValues += "Quantity1" + "»" + OtherQty.Quantity1 + "±";
            EditOtherPopupValues += "Quantity2" + "»" + OtherQty.Quantity2 + "±";
            EditOtherPopupValues += "Quantity3" + "»" + OtherQty.Quantity3 + "±";

            EditOtherPopupValues += "Markup" + "»" + OtherQty.Markup + "±";
            EditOtherPopupValues += "Markup1" + "»" + OtherQty.Markup1 + "±";
            EditOtherPopupValues += "Markup2" + "»" + OtherQty.Markup2 + "±";
            EditOtherPopupValues += "Markup3" + "»" + OtherQty.Markup3 + "±";

            EditOtherPopupValues += "SetUpTime" + "»" + OtherQty.SetUpTime + "±";
            EditOtherPopupValues += "HourlyRate" + "»" + OtherQty.HourlyRate + "±";
            EditOtherPopupValues += "Cost" + "»" + OtherQty.Cost + "±";
            EditOtherPopupValues += "Cost1" + "»" + OtherQty.Cost1 + "±";
            EditOtherPopupValues += "Cost2" + "»" + OtherQty.Cost2 + "±";
            EditOtherPopupValues += "Cost3" + "»" + OtherQty.Cost3;

            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherQty.SellingPrice;                                      
        }
    }
    var estitemid = hid_EstimateItemID.value;
    var mainestitemtype = hid_EstimateType.value;
    var booksecid = hid_BookletSectionID.value;
    var pg = pgtype;
    //PopupCenter(strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "", '950', '500');
    // window.radopen(strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "", '950', '600');
    // SetRadWindow('divrad', 'divBackGroundNew', '200');
    if (mode == 'add' || mode == 'editonload') {
        var MainOtheCostQty = hdn_EstQtyList.value;
    }
    //    if (isfrom_eStore != "yes") {
    if (mode == 'add') {
        if (estimateType == 'm') {
            //MainOtheCostQty = hdn_EstQtyList.value;
            if (jobQtyCheck == 0) {
                document.getElementById("spn_txtQuantity").style.display = "Block";
                return false;
            }
        }
    }
    // }
    var popupPath = strSitepath + "common/common_popup_othercost.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=" + pg + "&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "&estitemid=" + estitemid + "&mainestitemtype=" + mainestitemtype + "&booksecid=" + booksecid + "&EstQtyList=" + MainOtheCostQty + "";
    return popupPath;
}


function HighlightTab(isscost) {
    document.getElementById(isscost).style.color = "orange";
    for (var i = 0; i < rowcount; i++) {
        var dd = "spncost_" + i;
        if (dd != '') {
            if (dd != isscost) {
                if (document.getElementById("spncost_" + i) != null) {
                    document.getElementById("spncost_" + i).style.color = "black";
                }
            }
        }
    }
    var type = '';
    if (estimateType == "m") {
        type = 'm'; //other cost as main item from add page
    }
    else if (estimateType == "othercosttab") {
        type = 'u'; //other cost as main item from summary page
    }
    else {
        type = 's'; //other cost as sub item from add page
    }
    BindOtherCost(document.getElementById(isscost).id, type);
}

function ShowOtherCostQtyDiv(type) {

    if (type == "show") {
        document.getElementById("div_OtherCost_List").style.display = "block";
        Create_Other_Cost_Tab('u'); //BY VINAY
    }
    else {
        document.getElementById("div_OtherCost_List").style.display = "none";
    }
}
function AddThisOtherCostItem() {
    var txtOtherCostQtyID = txtOtherCostQty;
    var txtOtherCostQty = trim12(txtOtherCostQtyID.value);
    if (txtOtherCostQty == '') {
        document.getElementById("spn_txtOtherCostQty").style.display = "block";
        return false;
    }
    else if (IsIntegerParameter(txtWarehouseQty, 'spn_txtOtherCostQty_number') == false) {
        return false;
    }
    else {
        window.close();
    }
}
function ShowOtherCost() {
    OtherIndex = '';
    IsOtherCost = false;
    document.getElementById("div_stage_2").style.display = "none";
    document.getElementById(divOtherCost).style.display = "block";
    document.getElementById(divOtherCostbtnNext).style.display = "none";
    Create_Other_Cost_Tab('s'); //BY VINAY
}

function SaveQuestionInfo(strData) {
    var old = hid_OtherCost_Question.value;
    hid_OtherCost_Question.value = old + strData;
}

//************************ OTHER COST ENDS ****************************

var IsAnyOutWork = false;
var IsAnyWarehouse = false;
var IsAnyOtherCost = false;

function ValidateCost() {
    if (ArrayOtherCost.length > 0) {
        return true;
    }
    else {
        document.getElementById("div_none").style.display = "block";
        document.getElementById("span_none").innerHTML = "Please select at least one item to save";
        return false;
    }
}

function OtherCostPrevious() {
    if (IsOtherCost) {
        document.getElementById("div_stage_2").style.display = "block";
        document.getElementById(divOtherCost).style.display = "none";
        document.getElementById("lblheader").innerHTML = "Create Item";
    }
    else {
        document.getElementById("div_stage_2").style.display = "block";
        document.getElementById(divOtherCost).style.display = "none";
        document.getElementById("lblheader").innerHTML = "Create Item";
    }
}




function ValidateMandatoryOtherCost() {
    var ArrayOtherCostSequenceIDs = hdnOtherCostSequenceIDs.value.split(',');
    for (var k = 0; k < ArrayOtherCostSequenceIDs.length; k++) {

        if (ArrayOtherCostSequenceIDs[k] != '') {
            var OtherCostSequenceIDsFlag = false;
            for (var y = 0; y < ArrayOtherCost.length; y++) {

                if (ArrayOtherCostSequenceIDs[k] == ArrayOtherCost[y].OtherCostID) {
                    OtherCostSequenceIDsFlag = true;
                }
            }
            if (OtherCostSequenceIDsFlag == false) {

                document.getElementById("div_none").style.display = "block";
                document.getElementById("span_none").style.width = '500px';
                document.getElementById("span_none").innerHTML = "Please select mandatory other cost sequence items";
                return false;
            }
        }
    }
    return true;
}


function OtherCostNext() {

    if (ArrayOtherCost.length > 0) {
        var ArrayOtherCostSequenceIDs = hdnOtherCostSequenceIDs.value.split(',');

        for (var k = 0; k < ArrayOtherCostSequenceIDs.length; k++) {
            if (ArrayOtherCostSequenceIDs[k] != '') {
                var OtherCostSequenceIDsFlag = false;

                for (var y = 0; y < ArrayOtherCost.length; y++) {

                    if (ArrayOtherCostSequenceIDs[k] == ArrayOtherCost[y].OtherCostID) {
                        OtherCostSequenceIDsFlag = true;
                    }
                }
                if (OtherCostSequenceIDsFlag == false) {

                    document.getElementById("div_none").style.display = "block";
                    document.getElementById("span_none").style.width = '500px';
                    document.getElementById("span_none").innerHTML = "Please select mandatory other cost sequence items";
                    return false;
                }
            }
        }
        //        if (isfrom_eStore != "yes") {
        if (estimateType == 'm') {
            if (jobQtyCheck == '' || jobQtyCheck == 0) {
                document.getElementById("spn_txtQuantity").style.display = "Block";
                return false;
            }
            else if (txt_ItemTitle.value == '') {
                document.getElementById("spn_txtItemTitle").style.display = "Block";
                return false;
            }
            else {
                hdn_EstQtyList.value = EsttxtQuantity1.value + '~' + EsttxtQuantity2.value + '~' + EsttxtQuantity3.value + '~' + EsttxtQuantity4.value + '~';
                hdn_ItemTitle.value = txt_ItemTitle.value;
            }
        }
        //}
        getOtherCostval();
        //BindOtherCostDesc();
        document.getElementById(divOtherCost).style.display = "none";
        document.getElementById("div_OtherCostSummary").style.display = "block";
        document.getElementById("lblheader").innerHTML = "Customer Item Description";

        return true;
    }
    else {
        //        if (OthMode != 'edit' && estimateType == 'm') {
        document.getElementById("div_none").style.display = "block";
        document.getElementById("span_none").innerHTML = "Please select at least one other cost";
        return false;
        //        }
        //        else {
        //            return true;
        //        }
    }
}

function OtherCostSummaryPrevious() {
    document.getElementById(divOtherCost).style.display = "block";
    document.getElementById("div_stage_4").style.display = "none";
    document.getElementById("div_OtherCostSummary").style.display = "none";
    document.getElementById("lblheader").innerHTML = "Create Item";
}

//******* OTHERCOST SECTION *********//
var OtherIndex = '';
var EditOtherPopupValues = '';
function MakeArrayNull() {
    ArrayOtherCost.length = 0;
    //bind
    document.getElementById("href_ShowOtherCostSubItem").style.display = "none";
    document.getElementById("div_OtherCostSubItems").style.display = "none";

    //By Vinay 30/12/2009
    bookArr.length = 0;
    document.getElementById("div_btn_booklet_sections").innerHTML = '';

    //FOR WAREHOUSE ITEMS ALSO
    warearray.length = 0;

}

//*** Functions to be included in ItemAdd PAge ***//
function OtherCost() {
    this.OtherCostID = '';
    this.OtherCostName = '';
    this.CalculationType = '';
    this.CostTimeBasedID = '';
    this.Minimum = '';
    this.EstOtherCostID = 0;
    this.OtherCostTime;
    this.OtherCostQuantity;
    this.DefaultQtyType = '';
    this.FixedQty = '';
    this.VariableQty = '';
    this.HoursOrQty = '';
    this.Description = '';
}

function OtherCostTime() {
    this.HourlyRate = '';
    this.SetUpTime = '';
    this.SetUpCost = '';
    this.Hours = '';
    this.Passes = '';
    this.Markup = '';
    this.SellingPrice = '';
    this.RunsRequired = '';
    this.Speed = '';
    this.TotalTime = '';
    this.Cost = '';
    this.HourlyRunSpeed = '';
    this.SectionNo = ''
}

function OtherCostQuantity() {
    this.UnitRate = '';
    this.Quantity = '';
    this.Markup = '';
    this.SellingPrice = '';
    this.SetUpTime = '';
    this.SetUpCost = '';
    this.HourlyRate = '';
    this.TotalTime = '';
    this.Cost = '';
    this.SectionNo = ''

    this.Cost1 = '';
    this.Cost2 = '';
    this.Cost3 = '';

    this.UnitRate1 = '';
    this.UnitRate2 = '';
    this.UnitRate3 = '';

    this.Quantity1 = '';
    this.Quantity2 = '';
    this.Quantity3 = '';

    this.Markup1 = '';
    this.Markup2 = '';
    this.Markup3 = '';

    this.SellingPrice1 = '';
    this.SellingPrice2 = '';
    this.SellingPrice3 = '';
}

function OtherCostFormula() {
    this.Formula = '';

    this.FormulaTag = '';
    this.Cost = '';
    this.Markup = '';
    this.SellingPrice = '';


    this.FormulaTag1 = '';
    this.Cost1 = '';
    this.Markup1 = '';
    this.SellingPrice1 = '';


    this.FormulaTag2 = '';
    this.Cost2 = '';
    this.Markup2 = '';
    this.SellingPrice2 = '';


    this.FormulaTag3 = '';
    this.Cost3 = '';
    this.Markup3 = '';
    this.SellingPrice3 = '';

    this.SectionNo = ''
}

function Create_Other_Cost_Tab(para) {



    var div_other_tab = document.getElementById("div_other_tab");
    //    if (div_other_tab.innerHTML != '') 
    //    {
    //        //Test // HighlightTab('spncost_0');
    //        //Test // BindOtherCost(document.getElementById('spncost_0').id, para);
    //        return false;
    //    }

    PageMethods.GetOtherCost_Tab_List(CompanyID, hid_EstimateType.value, IsOtherCostSequence, function SuccessReturn(returnValue) {
        var finalString = '';
        var str2 = returnValue.split('±');

        rowcount = str2.length;
        for (var i = 0; i < str2.length; i++) {
            var str3 = str2[i].split('»');
            var CostName = trim12(str3[1]);
            var LimitCostName = '';
            if (CostName.length > 13) {
                LimitCostName = CostName.substring(0, 13) + "...";
            }
            else {
                LimitCostName = CostName;
            }
            finalString += "<div align='left' style='white-space:normal;overflow:visible' >";
            finalString += "<li style='cursor: pointer; margin-right: 2px; float: left; clear: right;'>";
            finalString += "<div id='div13' nowrap='nowrap' style='height: 20px; padding: 0px 10px 0px 10px;float: left; line-height: 20px;'>";
            finalString += "<b><span id='spncost_" + i + "' class='lnkTabSelected' title='" + SpecialDecode(CostName) + "' onclick='HighlightTab(this.id);'>" + SpecialDecode(LimitCostName) + "</span><span id='spncostcatid_" + i + "' style='display:none'>" + str3[0] + "</span></b>";
            finalString += "</div>";
            finalString += "</li>";
            finalString += "</div>";
        }
        div_other_tab.innerHTML = finalString;
        HighlightTab('spncost_0');
        BindOtherCost(document.getElementById('spncost_0').id, para);
    }, other_error);

}
function other_error(error) {


}


function BindOtherCostItems(OtherCostVal, CalculationType, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal) {
    debugger;
    //if (Mode == 'editonload') {
    //    ArrayOtherCost.splice(0, ArrayOtherCost.length);
    //}
    var item = new OtherCost();
    var str = OtherCostVal.split('±');
    var str2 = '';
    var prop = '';
    var value = '';
    for (var i = 0; i < str.length; i++) {
        str2 = str[i].split('»');
        prop = str2[0];
        value = str2[1];
        if (trim12(prop) == "EstOtherCostID") {
            item.EstOtherCostID = value;
        }
        if (trim12(prop) == "OtherCostID") {
            item.OtherCostID = value;
        }
        if (trim12(prop) == "OtherCostName") {
            item.OtherCostName = value;
        }
        if (trim12(prop) == "CalculationType") {
            item.CalculationType = value;
        }
        if (trim12(prop) == "CostTimeBasedID") {
            item.CostTimeBasedID = value;
        }
        if (trim12(prop) == "Minimum") {
            item.Minimum = value;
        }
        if (trim12(prop) == "Description") {
            item.Description = value;
        }
    }
    if (checkhourqty != '') {
        var checkhourqty = CheckHourQtyVal.split('±');
        for (var z = 0; z < checkhourqty.length; z++) {
            checkhourqty2 = checkhourqty[z].split('»');
            propqtycheck = checkhourqty2[0];
            valueqtycheck = checkhourqty2[1];
            if (trim12(propqtycheck) == "DefaultQtyType") {
                item.DefaultQtyType = valueqtycheck;
            }
            if (trim12(propqtycheck) == "FixedQty") {
                item.FixedQty = valueqtycheck;
            }
            if (trim12(propqtycheck) == "VariableQty") {
                item.VariableQty = valueqtycheck;
            }
            if (trim12(propqtycheck) == "HoursOrQty") {
                item.HoursOrQty = valueqtycheck;
            }
        }
    }

    if (CalculationType == 't') {
        var timeval = OtherCostTypeVal.split('±');
        var timeval2 = '';
        var proptime = '';
        var valuetime = '';
        var itemTime = new OtherCostTime();
        for (var x = 0; x < timeval.length; x++) {
            timeval2 = timeval[x].split('»');
            proptime = timeval2[0];
            valuetime = timeval2[1];
            if (trim12(proptime) == "HourlyRate") {
                itemTime.HourlyRate = valuetime;
            }
            if (trim12(proptime) == "SetUpTime") {
                itemTime.SetUpTime = valuetime;
            }
            if (trim12(proptime) == "SetUpCost") {
                itemTime.SetUpCost = valuetime;
            }
            if (trim12(proptime) == "Hours") {
                itemTime.Hours = valuetime;
            }
            if (trim12(proptime) == "Passes") {
                itemTime.Passes = valuetime;
            }
            if (trim12(proptime) == "Markup") {
                itemTime.Markup = valuetime;
            }
            if (trim12(proptime) == "SellingPrice") {
                itemTime.SellingPrice = valuetime;
            }
            if (trim12(proptime) == "RunsRequired") {
                itemTime.RunsRequired = valuetime;
            }
            if (trim12(proptime) == "Speed") {
                itemTime.Speed = valuetime;
            }
            if (trim12(proptime) == "TotalTime") {
                itemTime.TotalTime = valuetime;
            }
            if (trim12(proptime) == "Cost") {
                itemTime.Cost = valuetime;
            }
            if (trim12(proptime) == "HourlyRunSpeed") {
                itemTime.HourlyRunSpeed = valuetime;
            }
            if (trim12(proptime) == "SectionNo") {
                itemTime.SectionNo = valuetime;
            }

        }
        item.OtherCostTime = itemTime;
    }
    if (CalculationType == 'q') {
        var qtyval = OtherCostTypeVal.split('±');
        var qtyval2 = '';
        var propqty = '';
        var valueqty = '';
        var itemqty = new OtherCostQuantity();
        for (var y = 0; y < qtyval.length; y++) {
            qtyval2 = qtyval[y].split('»');
            propqty = qtyval2[0];
            valueqty = qtyval2[1];
            if (trim12(propqty) == "UnitRate") {
                itemqty.UnitRate = valueqty;
            }
            if (trim12(propqty) == "UnitRate1") {
                itemqty.UnitRate1 = valueqty;
            }
            if (trim12(propqty) == "UnitRate2") {
                itemqty.UnitRate2 = valueqty;
            }
            if (trim12(propqty) == "UnitRate3") {
                itemqty.UnitRate3 = valueqty;
            }

            if (trim12(propqty) == "Quantity") {
                itemqty.Quantity = valueqty;
            }
            if (trim12(propqty) == "Quantity1") {
                itemqty.Quantity1 = valueqty;
            }
            if (trim12(propqty) == "Quantity2") {
                itemqty.Quantity2 = valueqty;
            }
            if (trim12(propqty) == "Quantity3") {
                itemqty.Quantity3 = valueqty;
            }

            if (trim12(propqty) == "Markup") {
                itemqty.Markup = valueqty;
            }
            if (trim12(propqty) == "Markup1") {
                itemqty.Markup1 = valueqty;
            }
            if (trim12(propqty) == "Markup2") {
                itemqty.Markup2 = valueqty;
            }
            if (trim12(propqty) == "Markup3") {
                itemqty.Markup3 = valueqty;
            }


            if (trim12(propqty) == "SellingPrice") {
                itemqty.SellingPrice = valueqty;
            }
            if (trim12(propqty) == "SellingPrice1") {
                itemqty.SellingPrice1 = valueqty;
            }
            if (trim12(propqty) == "SellingPrice2") {
                itemqty.SellingPrice2 = valueqty;
            }
            if (trim12(propqty) == "SellingPrice3") {
                itemqty.SellingPrice3 = valueqty;
            }


            if (trim12(propqty) == "SetUpTime") {
                itemqty.SetUpTime = valueqty;
            }
            if (trim12(propqty) == "SetUpCost") {
                itemqty.SetUpCost = valueqty;
            }
            if (trim12(propqty) == "HourlyRate") {
                itemqty.HourlyRate = valueqty;
            }
            if (trim12(propqty) == "TotalTime") {
                itemqty.TotalTime = valueqty;
            }

            if (trim12(propqty) == "Cost") {
                itemqty.Cost = valueqty;
            }
            if (trim12(propqty) == "Cost1") {
                itemqty.Cost1 = valueqty;
            }
            if (trim12(propqty) == "Cost2") {
                itemqty.Cost2 = valueqty;
            }
            if (trim12(propqty) == "Cost3") {
                itemqty.Cost3 = valueqty;
            }

            if (trim12(propqty) == "SectionNo") {
                itemqty.SectionNo = valueqty;
            }
        }
        item.OtherCostQuantity = itemqty;
    }
    if (CalculationType == 'f' || CalculationType == 'm') {
        var formval = OtherCostTypeVal.split('±');
        var formval2 = '';
        var propform = '';
        var valueform = '';
        var itemForm = new OtherCostFormula();
        for (var x = 0; x < formval.length; x++) {
            formval2 = formval[x].split('»');
            propform = formval2[0];
            valueform = formval2[1];
            if (trim12(propform) == "Formula") {
                itemForm.Formula = valueform;
            }
            if (trim12(propform) == "FormulaTag") {
                itemForm.FormulaTag = valueform;
            }
            if (trim12(propform) == "Cost") {
                itemForm.Cost = valueform;
            }
            if (trim12(propform) == "Markup") {
                itemForm.Markup = valueform;
            }
            if (trim12(propform) == "SellingPrice") {
                itemForm.SellingPrice = valueform;
            }

            if (trim12(propform) == "FormulaTag1") {
                itemForm.FormulaTag1 = valueform;
            }
            if (trim12(propform) == "Cost1") {
                itemForm.Cost1 = valueform;
            }
            if (trim12(propform) == "Markup1") {
                itemForm.Markup1 = valueform;
            }
            if (trim12(propform) == "SellingPrice1") {
                itemForm.SellingPrice1 = valueform;
            }

            if (trim12(propform) == "FormulaTag2") {
                itemForm.FormulaTag2 = valueform;
            }
            if (trim12(propform) == "Cost2") {
                itemForm.Cost2 = valueform;
            }
            if (trim12(propform) == "Markup2") {
                itemForm.Markup2 = valueform;
            }
            if (trim12(propform) == "SellingPrice2") {
                itemForm.SellingPrice2 = valueform;
            }

            if (trim12(propform) == "FormulaTag3") {
                itemForm.FormulaTag3 = valueform;
            }
            if (trim12(propform) == "Cost3") {
                itemForm.Cost3 = valueform;
            }
            if (trim12(propform) == "Markup3") {
                itemForm.Markup3 = valueform;
            }
            if (trim12(propform) == "SellingPrice3") {
                itemForm.SellingPrice3 = valueform;
            }

            if (trim12(propform) == "SectionNo") {
                itemForm.SectionNo = valueform;
            }
        }
        item.OtherCostFormula = itemForm;
    }
    ArrayOtherCost.push(item);
    try {
        BindDivOtherCostStyle(ItemType, Mode);
    }
    catch (err) {
    }
}

function BindDivOtherCostStyle(ItemType, Mode) {
    var divid = '';
    var hrefid = '';
    var divcontent = '';

    if (ItemType == 'm') {
        divid = "div_OtherCostItems";
        hrefid = href_ShowOtherCostID;
        divcontent = "div_OtherCostItems_Add";
    }
    else if (ItemType == 's') {
        if (Mode == "add") {

            //these 3 lines are added to stop the redirection on addtional items
            divid = "div_OtherCostItems";
            hrefid = href_ShowOtherCostID;
            divcontent = "div_OtherCostItems_Add";
            //these 3 lines are added to stop the redirection on addtional items

            getOtherCostval();

            //__doPostBack('ctl00$ContentPlaceHolder1$lnkSaveSubOthercost', ''); //by kumar on feb 18 2011,bec for addtional items it should not redirect
            //window.location = "../estimates/estimate_item_description.aspx?type=sub&estid=2519&estitemid=2626&esttype=s";
        }
        else {

            divid = "div_OtherCostSubItems";
            hrefid = href_ShowOtherCostSubItemID;
            divcontent = "div_OtherCostSubItems_Add";
        }
    }

    if (ArrayOtherCost.length > 0) {
        if (hrefid != "") {

            //document.getElementById("div_OtherCostItems").style.display = "block";
            if (ItemType == 'm') {
                document.getElementById(divid).style.display = "none";
                hrefid.style.display = "block";
            }
            else {
                document.getElementById(divid).style.display = "none";
                hrefid.style.display = "block";
                //previously it was none now I made it as block because
            }
        }
    }
    else {
        if (hrefid != "") {
            hrefid.style.display = "none";
            document.getElementById(divid).style.display = "none";
        }
    }

    var dd = '';
    for (var j = 0; j < ArrayOtherCost.length; j++) {
        var color1 = "#DADADA";
        if (j % 2 == 0) {
            color1 = "#EFEFEF";
        }

        if (ItemType == 'm') {
            dd += "<div align='left' style='height:20px;padding:2px;background-color:" + color1 + "'>";
        }
        else if (ItemType == 's') {
            dd += "<div align='left' style='height:20px;'>";
        }
        if (ArrayOtherCost[j].EstOtherCostID == '0' || ArrayOtherCost[j].EstOtherCostID == 'undefined') {
            dd += "<div style='float:left;width:220px;overflow:hidden;color: #10357F'>" + ArrayOtherCost[j].OtherCostName + "</div>"; //add case
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOtherCosts_txt_ItemTitle').value == '') {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOtherCosts_txt_ItemTitle').value = ArrayOtherCost[0].OtherCostName;
                CallonBlur(ArrayOtherCost[0].OtherCostName, 'spn_txtItemTitle');
            }
        }
        else {
            var othercosts = hid_OtherCostValuesFromTB.value; //document.getElementById("<%=hid_OtherCostValuesFromTB.ClientID %>").value; // 'OtherCostValuesFromTB';
            var str = othercosts.split('±');
            for (var k = 0; k < str.length; k++) {
                var str2 = str[k].split('»');
                if (ArrayOtherCost[j].OtherCostID == str2[1]) {
                    var CostCatID = str2[0];
                    var CostID = str2[1];
                    var CostName = str2[2];
                    var CostDesc = str2[3];
                    var CostTimeBasedID = str2[4];
                    var CostCalType = str2[5];
                }
            }
            var GuillotineID = 0;
            var PaperID = 0;
            var PressID = 0;
            var EstOtherCostID = 0;
            EstOtherCostID = ArrayOtherCost[j].EstOtherCostID;
            if (ItemType == "s") {
                GuillotineID = hid_GuillotineID.value;
                PaperID = hid_PaperID.value;
                PressID = 0;
            }
            var Itemwidth = '';
            if (ItemType == 'm') {
                Itemwidth = "200px";
            }
            else if (ItemType == 's') {
                Itemwidth = "200px";
            }
            dd += "<div style='float:left;width: " + Itemwidth + ";overflow: hidden;'><a href='#' onclick=javascript:OpenPopup('" + CostID + "','" + CostTimeBasedID + "','" + CostCalType + "','" + ItemType + "','" + Mode + "','" + j + "','" + GuillotineID + "','" + PaperID + "','" + PressID + "','" + EstOtherCostID + "');return false;>" + ArrayOtherCost[j].OtherCostName + "</a></div>";
        }
        if (ItemType == 'm') {
            dd += "<div style='float: right;padding-right: 2px'><a href='#' onclick=javascript:RemoveOtherCostItems(" + j + ",'" + ItemType + "'); class='normaltext'><img src='../images/delete.gif' height='10px' width='10px' border='0' /></a></div>";
        }
        else if (ItemType == 's') {
            dd += "<div style='float: right;padding-right: 2px'><a href='#' onclick=javascript:RemoveOtherCostItems(" + j + ",'" + ItemType + "');ShowOtherCostItems('s'); class='normaltext'><img src='../images/delete.gif' height='10px' width='10px' border='0' /></a></div>";
        }
        dd += "</div>";
        if (divcontent != null) {
            debugger;
            document.getElementById(divcontent).innerHTML = dd;
            if (Mode != 'add') {
                var popupPath = GetPopupPath(CostID, CostTimeBasedID, CostCalType, ItemType, Mode, j, GuillotineID, PaperID, PressID, EstOtherCostID);
                hdn_CostEditPath.value = popupPath;
            }
           
        }
    }
    if (ItemType == 'm') {
        ShowOtherCost_InStage2_OnEdit(ItemType, Mode); //To Bind OtherCost MainItem on edit case  
    }
}

//To Show OtherCost Main item in stage 2//
function ShowOtherCost_InStage2_OnEdit(estitemtype, Mode) {
    var estitemtype = estitemtype;
    var EstType = '<%=EstType %>';
    if (EstType == 'u' && ArrayOtherCost.length > 0) {

    }
    else {
    }
    var dd = '';
    for (var j = 0; j < ArrayOtherCost.length; j++) {
        var color1 = "#DADADA";
        if (j % 2 == 0) {
            color1 = "#EFEFEF";
        }

        dd += "<div align='left' style='height:20px;padding:2px;background-color:" + color1 + "'>";
        if (ArrayOtherCost[j].EstOtherCostID == '0' || ArrayOtherCost[j].EstOtherCostID == 'undefined') {
            dd += "<div style='float:left;width:220px;overflow:hidden;'>" + ArrayOtherCost[j].OtherCostName + "</div>";
        }
        else {
            var othercosts = '<%=OtherCostValuesFromTB %>';
            var str = othercosts.split('±');
            for (var k = 0; k < str.length; k++) {
                var str2 = str[k].split('»');
                if (ArrayOtherCost[j].OtherCostID == str2[1]) {
                    var CostCatID = str2[0];
                    var CostID = str2[1];
                    var CostName = str2[2];
                    var CostDesc = str2[3];
                    var CostTimeBasedID = str2[4];
                    var CostCalType = str2[5];
                }
            }
            dd += "<div style='float:left;width:220px;overflow:hidden;'><a href='#' onclick=javascript:OpenPopup('" + CostID + "','" + CostTimeBasedID + "','" + CostCalType + "','" + estitemtype + "','" + Mode + "','" + j + "');return false;>" + ArrayOtherCost[j].OtherCostName + "</a></div>";
        }
        dd += "<div style='float:left;'><a href='#' onclick=javascript:RemoveOtherCostItems(" + j + ",'" + estitemtype + "'); class='normaltext'>Remove</a></div>";
        dd += "</div>";
    }
    //document.getElementById("div_OtherCostMainItems_Add").innerHTML = dd;
}
///MadeDefault()


function BindOtherCostOnEdit(OtherCostVal, CalculationType, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal) {
    var Other = ArrayOtherCost[OtherIndex].OtherCost;
    var checkhourqty = CheckHourQtyVal.split('±');

    var OtherCostValsplit = OtherCostVal.split('±');
    for (var L = 0; L < OtherCostValsplit.length; L++) {
        fff = OtherCostValsplit[L].split('»');

        if (trim12(fff[0]) == "Description") {
            ArrayOtherCost[OtherIndex].Description = trim12(fff[1]);
        }
        if (trim12(fff[0]) == "Minimum") {
            ArrayOtherCost[OtherIndex].Minimum = trim12(fff[1]);
        }
    }
    for (var z = 0; z < checkhourqty.length; z++) {
        checkhourqty2 = checkhourqty[z].split('»');
        propqtycheck = checkhourqty2[0];
        valueqtycheck = checkhourqty2[1];
        if (trim12(propqtycheck) == "DefaultQtyType") {
            ArrayOtherCost[OtherIndex].DefaultQtyType = valueqtycheck;
        }
        if (trim12(propqtycheck) == "FixedQty") {
            ArrayOtherCost[OtherIndex].FixedQty = valueqtycheck;
        }
        if (trim12(propqtycheck) == "VariableQty") {
            ArrayOtherCost[OtherIndex].VariableQty = valueqtycheck;
        }
        if (trim12(propqtycheck) == "HoursOrQty") {
            ArrayOtherCost[OtherIndex].HoursOrQty = valueqtycheck;
        }
    }


    if (CalculationType == 't') {
        var timeval = OtherCostTypeVal.split('±');
        var timeval2 = '';
        var proptime = '';
        var valuetime = '';
        var OtherTime = ArrayOtherCost[OtherIndex].OtherCostTime;
        for (var x = 0; x < timeval.length; x++) {
            timeval2 = timeval[x].split('»');
            proptime = timeval2[0];
            valuetime = timeval2[1];

            if (trim12(proptime) == "HourlyRate") {
                OtherTime.HourlyRate = valuetime;
            }
            if (trim12(proptime) == "SetUpTime") {
                OtherTime.SetUpTime = valuetime;
            }
            if (trim12(proptime) == "Hours") {
                OtherTime.Hours = valuetime;
            }
            if (trim12(proptime) == "Passes") {
                OtherTime.Passes = valuetime;
            }
            if (trim12(proptime) == "Markup") {
                OtherTime.Markup = valuetime;
            }
            if (trim12(proptime) == "Cost") {
                OtherTime.Cost = valuetime;
            }
            if (trim12(proptime) == "HourlyRunSpeed") {
                OtherTime.HourlyRunSpeed = valuetime;
            }
            if (trim12(proptime) == "SellingPrice") {
                OtherTime.SellingPrice = valuetime;
            }
        }
    }
    else if (CalculationType == 'q') {
        var qtyval = OtherCostTypeVal.split('±');
        var qtyval2 = '';
        var propqty = '';
        var valueqty = '';
        var OtherQty = ArrayOtherCost[OtherIndex].OtherCostQuantity;

        for (var y = 0; y < qtyval.length; y++) {
            qtyval2 = qtyval[y].split('»');
            propqty = qtyval2[0];
            valueqty = qtyval2[1];
            if (trim12(propqty) == "UnitRate") {
                OtherQty.UnitRate = valueqty;
            }
            if (trim12(propqty) == "UnitRate1") {
                OtherQty.UnitRate1 = valueqty;
            }
            if (trim12(propqty) == "UnitRate2") {
                OtherQty.UnitRate2 = valueqty;
            }
            if (trim12(propqty) == "UnitRate3") {
                OtherQty.UnitRate3 = valueqty;
            }
            if (trim12(propqty) == "Quantity") {
                OtherQty.Quantity = valueqty;
            }
            if (trim12(propqty) == "Quantity1") {
                OtherQty.Quantity1 = valueqty;
            }
            if (trim12(propqty) == "Quantity2") {
                OtherQty.Quantity2 = valueqty;
            }
            if (trim12(propqty) == "Quantity3") {
                OtherQty.Quantity3 = valueqty;
            }
            if (trim12(propqty) == "Markup") {
                OtherQty.Markup = valueqty;
            }
            if (trim12(propqty) == "Markup1") {
                OtherQty.Markup1 = valueqty;
            }
            if (trim12(propqty) == "Markup2") {
                OtherQty.Markup2 = valueqty;
            }
            if (trim12(propqty) == "Markup3") {
                OtherQty.Markup3 = valueqty;
            }

            if (trim12(propqty) == "SetUpTime") {
                OtherQty.SetUpTime = valueqty;
            }
            if (trim12(propqty) == "HourlyRate") {
                OtherQty.HourlyRate = valueqty;
            }
            if (trim12(propqty) == "SellingPrice") {
                OtherQty.SellingPrice = valueqty;
            }
            if (trim12(propqty) == "Cost") {
                OtherQty.Cost = valueqty;
            }
            if (trim12(propqty) == "Cost1") {
                OtherQty.Cost1 = valueqty;
            }
            if (trim12(propqty) == "Cost2") {
                OtherQty.Cost2 = valueqty;
            }
            if (trim12(propqty) == "Cost3") {
                OtherQty.Cost3 = valueqty;
            }
        }
    }
    else if (CalculationType == 'f' || CalculationType == 'm') {

        var formval = OtherCostTypeVal.split('±');
        var formval2 = '';
        var propform = '';
        var valueform = '';
        var OtherForm = ArrayOtherCost[OtherIndex].OtherCostFormula;

        for (var y = 0; y < formval.length; y++) {
            formval2 = formval[y].split('»');
            propform = formval2[0];
            valueform = formval2[1];
            if (trim12(propform) == "Formula") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Formula = valueform;
            }
            if (trim12(propform) == "FormulaTag") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.FormulaTag = valueform;
            }
            if (trim12(propform) == "Cost") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Cost = valueform;
            }
            if (trim12(propform) == "Markup") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Markup = valueform;
            }
            if (trim12(propform) == "SellingPrice") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.SellingPrice = valueform;
            }
            if (trim12(propform) == "FormulaTag1") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.FormulaTag1 = valueform;
            }
            if (trim12(propform) == "Cost1") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Cost1 = valueform;
            }
            if (trim12(propform) == "Markup1") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Markup1 = valueform;
            }
            if (trim12(propform) == "SellingPrice1") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.SellingPrice1 = valueform;
            }


            if (trim12(propform) == "FormulaTag2") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.FormulaTag2 = valueform;
            }
            if (trim12(propform) == "Cost2") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Cost2 = valueform;
            }
            if (trim12(propform) == "Markup2") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Markup2 = valueform;
            }
            if (trim12(propform) == "SellingPrice2") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.SellingPrice2 = valueform;
            }



            if (trim12(propform) == "FormulaTag3") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.FormulaTag3 = valueform;
            }
            if (trim12(propform) == "Cost3") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Cost3 = valueform;
            }
            if (trim12(propform) == "Markup3") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.Markup3 = valueform;
            }
            if (trim12(propform) == "SellingPrice3") {
                //ArrayOtherCost[OtherIndex].OtherCostQuantity[z].UnitRate = valueqty;
                OtherForm.SellingPrice3 = valueform;
            }

        }
    }
    EditOtherPopupValues = '';
}


function ShowOtherCostItems(itemtype) {
    if (itemtype == 's') {
        if (ArrayOtherCost.length > 0) {
            document.getElementById("div_OtherCostSubItems").style.display = "block";
        }
        else {
            CloseOtherCostItems('s');
        }
    }
    else if (itemtype == 'm') {
        document.getElementById("div_OtherCostItems").style.display = "block";
    }
    else if (itemtype == 'u') {
        document.getElementById("div_OtherCostMainItems").style.display = "block";
    }
}

function CloseOtherCostItems(itemtype) {
    if (itemtype == 's') {
        if (document.getElementById("div_OtherCostSubItems") != null) {
            document.getElementById("div_OtherCostSubItems").style.display = "none";
        }
    }
    else if (itemtype == 'm') {
        if (document.getElementById("div_OtherCostItems") != null) {
            document.getElementById("div_OtherCostItems").style.display = "none";
        }
    }
    else if (itemtype == 'u') {
        if (document.getElementById("div_OtherCostMainItems") != null) {   // IE Condition to check null values, on 23.09.2011
            document.getElementById("div_OtherCostMainItems").style.display = "none";
        }
    }
}


function RemoveOtherCostItems(ids, ItemType) {
    if (ArrayOtherCost[ids].EstOtherCostID != "0")//ItemType == 's' && 
    {
        CallOtherDeleteWebMethod(ids, ItemType);
    }
    else {
        ArrayOtherCost.splice(ids, 1);
        BindDivOtherCostStyle(ItemType, 'add');
        //ShowOtherCost_InStage2_OnEdit('m', 'editonload');
        getOtherCostval();
    }
}

function CallOtherDeleteWebMethod(ids, ItemType) {
    var EstOtherCostID = ArrayOtherCost[ids].EstOtherCostID;
    var firstConfirm = window.confirm('Are you sure, you want to remove ? ');
    if (firstConfirm) {
        try {
            PageMethods.RemoveOtherCostItem(CompanyID, EstOtherCostID);
        } catch (err) { }
        ArrayOtherCost.splice(ids, 1);
        BindDivOtherCostStyle(ItemType);
        //ShowOtherCost_InStage2_OnEdit('m', 'editonload');
        getOtherCostval();
    }
}


function getOtherCostval() {
    debugger;
    var strData = '';
    for (var y = 0; y < ArrayOtherCost.length; y++) {
        strData += "OtherCostID" + "»" + ArrayOtherCost[y].OtherCostID + "±";
        strData += "OtherCostName" + "»" + ArrayOtherCost[y].OtherCostName + "±";
        strData += "CalculationType" + "»" + ArrayOtherCost[y].CalculationType + "±";
        strData += "Minimum" + "»" + ArrayOtherCost[y].Minimum + "±";
        strData += "DefaultQtyType" + "»" + ArrayOtherCost[y].DefaultQtyType + "±";
        strData += "FixedQty" + "»" + ArrayOtherCost[y].FixedQty + "±";
        strData += "VariableQty" + "»" + ArrayOtherCost[y].VariableQty + "±";
        strData += "HoursOrQty" + "»" + ArrayOtherCost[y].HoursOrQty + "±";

        strData += "Description" + "»" + ArrayOtherCost[y].Description + "±";

        if (ArrayOtherCost[y].EstOtherCostID == null) {
            strData += "EstOtherCostID" + "»0±";
        }
        else {
            strData += "EstOtherCostID" + "»" + ArrayOtherCost[y].EstOtherCostID + "±";
        }

        if (ArrayOtherCost[y].CalculationType == 't') {
            var objOtherCostTime = ArrayOtherCost[y].OtherCostTime;
            strData += "HourlyRate" + "»" + objOtherCostTime.HourlyRate + "±";
            strData += "SetUpTime" + "»" + objOtherCostTime.SetUpTime + "±";
            strData += "Hours" + "»" + objOtherCostTime.Hours + "±";
            strData += "Passes" + "»" + objOtherCostTime.Passes + "±";
            strData += "Cost" + "»" + objOtherCostTime.Cost + "±";
            strData += "Markup" + "»" + objOtherCostTime.Markup + "±";
            strData += "HourlyRunSpeed" + "»" + objOtherCostTime.HourlyRunSpeed + "±";
            strData += "SellingPrice" + "»" + objOtherCostTime.SellingPrice + "±";
            strData += "SectionNo" + "»" + objOtherCostTime.SectionNo;
        }
        else if (ArrayOtherCost[y].CalculationType == 'q') {
            var objOtherCostQty = ArrayOtherCost[y].OtherCostQuantity;

            strData += "UnitRate" + "»" + objOtherCostQty.UnitRate + "±";
            strData += "UnitRate1" + "»" + objOtherCostQty.UnitRate1 + "±";
            strData += "UnitRate2" + "»" + objOtherCostQty.UnitRate2 + "±";
            strData += "UnitRate3" + "»" + objOtherCostQty.UnitRate3 + "±";

            strData += "Quantity" + "»" + objOtherCostQty.Quantity + "±";
            strData += "Quantity1" + "»" + objOtherCostQty.Quantity1 + "±";
            strData += "Quantity2" + "»" + objOtherCostQty.Quantity2 + "±";
            strData += "Quantity3" + "»" + objOtherCostQty.Quantity3 + "±";

            strData += "Markup" + "»" + objOtherCostQty.Markup + "±";
            strData += "Markup1" + "»" + objOtherCostQty.Markup1 + "±";
            strData += "Markup2" + "»" + objOtherCostQty.Markup2 + "±";
            strData += "Markup3" + "»" + objOtherCostQty.Markup3 + "±";

            strData += "SetUpTime" + "»" + objOtherCostQty.SetUpTime + "±";
            strData += "HourlyRate" + "»" + objOtherCostQty.HourlyRate + "±";

            strData += "SellingPrice" + "»" + objOtherCostQty.SellingPrice + "±";
            strData += "SellingPrice1" + "»" + objOtherCostQty.SellingPrice1 + "±";
            strData += "SellingPrice2" + "»" + objOtherCostQty.SellingPrice2 + "±";
            strData += "SellingPrice3" + "»" + objOtherCostQty.SellingPrice3 + "±";

            strData += "Cost" + "»" + objOtherCostQty.Cost + "±";
            strData += "Cost1" + "»" + objOtherCostQty.Cost1 + "±";
            strData += "Cost2" + "»" + objOtherCostQty.Cost2 + "±";
            strData += "Cost3" + "»" + objOtherCostQty.Cost3 + "±";

            strData += "SectionNo" + "»" + objOtherCostQty.SectionNo;
        }
        else if (ArrayOtherCost[y].CalculationType == 'f' || ArrayOtherCost[y].CalculationType == 'm') {
            var objOtherCostForm = ArrayOtherCost[y].OtherCostFormula;
            strData += "Formula" + "»" + objOtherCostForm.Formula + "±";
            strData += "FormulaTag" + "»" + objOtherCostForm.FormulaTag + "±";
            strData += "Markup" + "»" + objOtherCostForm.Markup + "±";
            strData += "SellingPrice" + "»" + objOtherCostForm.SellingPrice + "±";
            strData += "Cost" + "»" + objOtherCostForm.Cost + "±";

            strData += "FormulaTag1" + "»" + objOtherCostForm.FormulaTag1 + "±";
            strData += "Markup1" + "»" + objOtherCostForm.Markup1 + "±";
            strData += "SellingPrice1" + "»" + objOtherCostForm.SellingPrice1 + "±";
            strData += "Cost1" + "»" + objOtherCostForm.Cost1 + "±";

            strData += "FormulaTag2" + "»" + objOtherCostForm.FormulaTag2 + "±";
            strData += "Markup2" + "»" + objOtherCostForm.Markup2 + "±";
            strData += "SellingPrice2" + "»" + objOtherCostForm.SellingPrice2 + "±";
            strData += "Cost2" + "»" + objOtherCostForm.Cost2 + "±";

            strData += "FormulaTag3" + "»" + objOtherCostForm.FormulaTag3 + "±";
            strData += "Markup3" + "»" + objOtherCostForm.Markup3 + "±";
            strData += "SellingPrice3" + "»" + objOtherCostForm.SellingPrice3 + "±";
            strData += "Cost3" + "»" + objOtherCostForm.Cost3 + "±";

            strData += "SectionNo" + "»" + objOtherCostForm.SectionNo;
        }
        strData += 'µ';

    }
    debugger;
    if (hdnOtherCostValues != null) {
        hdnOtherCostValues.value = strData;
        hdnEditOtherCostValues.value = strData;
    }

    var url_parent_new = document.URL;
    if (url_parent_new.indexOf('type') > -1 && url_parent_new.indexOf('FromAddAnItem') > -1) {
        document.getElementById('ctl00_ContentPlaceHolder1_UCOtherCosts_txt_ItemTitle').value = '';
        if (ArrayOtherCost.length > 0) {
            document.getElementById('ctl00_ContentPlaceHolder1_UCOtherCosts_txt_ItemTitle').value = ArrayOtherCost[0].OtherCostName;
        }
    }
    //

    if (ArrayOtherCost.length == 0) {
        CallonBlur(document.getElementById('ctl00_ContentPlaceHolder1_UCOtherCosts_txt_ItemTitle').value, 'spn_txtItemTitle');
    }
}

function ReCalculateVariableQty() {

    var PrintLayoutQty;
    if (productType != "booklet") {
        var RunSpoilSheets = (Number(txtQty.value) * Number(txtRunningSpoilage.value)) / 100;
        var FinishedQty_Excl_Spoilage = Number(txtQty.value);
        var FinishedQty_Incl_Spoilage = Number(txtQty.value) + Number(txtSetupSpoilage.value) + Number(RunSpoilSheets);

        if (chkPortrait.checked) {
            PrintLayoutQty = Number(txtportrait.value);
        }
        else {
            PrintLayoutQty = Number(txtlandscape.value);
        }
    }
    else {
        var StrBook = hid_booklet_save.value.split('µ');
        for (var j = 0; j < StrBook.length; j++) {
            var strSingle = StrBook[j].split('±');
            for (var i = 0; i < strSingle.length; i++) {
                var str2 = strSingle[i].split('»');
                if (trim12(str2[0]) == "SetupSpoilage") {
                    txtSetupSpoilage.value = str2[1];
                }
                else if (trim12(str2[0]) == "RunningSpoilage") {
                    txtRunningSpoilage.value = str2[1];
                }
                else if (trim12(str2[0]) == "NoOfPagesInSection" && str2[1] != '') {
                }
                else if (trim12(str2[0]) == "PagesPerSignature" && str2[1] != '') {
                }
                else if (trim12(str2[0]) == "NoOfSignatures" && str2[1] != '') {
                    PrintLayoutQty = str2[1];
                }
            }
        }
        var RunSpoilSheets = (Number(txtQty.value) * Number(txtRunningSpoilage.value)) / 100;
        var FinishedQty_Excl_Spoilage = Number(txtQty.value);
        var FinishedQty_Incl_Spoilage = Number(txtQty.value) + Number(txtSetupSpoilage.value) + Number(RunSpoilSheets);
    }

    var PrintSheets = Number(txtQty.value) / Number(PrintLayoutQty);
    var PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
    var PrintRunSpoilSheets = (Number(PrintSheets) * Number(txtRunningSpoilage.value)) / 100;
    var PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(txtSetupSpoilage.value) + Number(PrintRunSpoilSheets);

    if (productType != "booklet") {
        PrintSheets = Number(txtQty.value) / Number(PrintLayoutQty);
        PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
        PrintRunSpoilSheets = (Number(PrintSheets) * Number(txtRunningSpoilage.value)) / 100;
        PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(txtSetupSpoilage.value) + Number(PrintRunSpoilSheets);
    }
    else {
        ////PrintLayoutQty This is used as No Of Signature
        PrintSheets = Number(txtQty.value) * Number(PrintLayoutQty);
        PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
        PrintRunSpoilSheets = (Number(PrintSheets) * Number(txtRunningSpoilage.value)) / 100;
        PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(txtSetupSpoilage.value) + Number(PrintRunSpoilSheets);
    }

    //compare hoursorqty//
    var ret;
    var TestVar = '';
    for (var i = 0; i < ArrayOtherCost.length; i++) {

        if (ArrayOtherCost[i].CalculationType == "q") {
            if (ArrayOtherCost[i].DefaultQtyType == "v") {

                var CalType = ArrayOtherCost[i].CalculationType;
                var HourlyRate = ArrayOtherCost[i].OtherCostQuantity.HourlyRate;
                var SetupTime = ArrayOtherCost[i].OtherCostQuantity.SetUpTime;
                var UnitRate = ArrayOtherCost[i].OtherCostQuantity.UnitRate;
                var Markup = ArrayOtherCost[i].OtherCostQuantity.Markup;
                var HourlyRunSpeed = '';
                var Passes = '';
                var CostVal = '';
                //GetHourOrQtyOn_VaraibleFormula(ArrayOtherCost[i].CalculationType,ArrayOtherCost[i].VariableQty,HourlyRate,SetupTime,UnitRate,HoursOrQuantity,Markup,HourlyRunSpeed,Passes);              
                if (ArrayOtherCost[i].VariableQty == "1")//Print Sheet Qty Excl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Math.round(PrintSheetQty_Excl_Spoilage)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;

                    }
                    else {

                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostQuantity.Quantity = Math.round(PrintSheetQty_Excl_Spoilage); //
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostQuantity.Quantity;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostQuantity.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "2")//Print Sheet Qty Incl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Math.round(PrintSheetQty_Incl_Spoilage)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostQuantity.Quantity = Math.round(PrintSheetQty_Incl_Spoilage);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostQuantity.Quantity;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostQuantity.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "3")//Finished Item Qty
                {
                    if (ArrayOtherCost[i].HoursOrQty == Math.round(FinishedQty_Excl_Spoilage)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostQuantity.Quantity = Math.round(FinishedQty_Excl_Spoilage);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostQuantity.Quantity;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostQuantity.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "4")//Finished Item Qty Incl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Math.round(FinishedQty_Incl_Spoilage)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostQuantity.Quantity = Math.round(FinishedQty_Incl_Spoilage);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostQuantity.Quantity;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostQuantity.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostQuantity.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }

            }
        }
        else if (ArrayOtherCost[i].CalculationType == "t") {
            if (ArrayOtherCost[i].DefaultQtyType == "v") {
                var CalType = ArrayOtherCost[i].CalculationType;
                var HourlyRate = ArrayOtherCost[i].OtherCostTime.HourlyRate;
                var SetupTime = ArrayOtherCost[i].OtherCostTime.SetUpTime;
                var UnitRate = ''; //ArrayOtherCost[i].OtherCostQuantity.UnitRate;                
                var Markup = ArrayOtherCost[i].OtherCostTime.Markup;
                var HourlyRunSpeed = ArrayOtherCost[i].OtherCostTime.HourlyRunSpeed;
                var Passes = ArrayOtherCost[i].OtherCostTime.Passes;
                var CostVal = '';
                if (ArrayOtherCost[i].VariableQty == "1")//Print Sheet Qty Excl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Number(PrintSheetQty_Excl_Spoilage / HourlyRunSpeed).toFixed(2)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostTime.Hours = Number(PrintSheetQty_Excl_Spoilage / HourlyRunSpeed).toFixed(2); //
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostTime.Hours;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostTime.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "2")//Print Sheet Qty Incl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Number(PrintSheetQty_Incl_Spoilage / HourlyRunSpeed).toFixed(2)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostTime.Hours = Number(PrintSheetQty_Incl_Spoilage / HourlyRunSpeed).toFixed(2);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostTime.Hours;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostTime.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "3")//Finished Item Qty
                {
                    if (ArrayOtherCost[i].HoursOrQty == Number(FinishedQty_Excl_Spoilage / HourlyRunSpeed).toFixed(2)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostTime.Hours = Number(FinishedQty_Excl_Spoilage / HourlyRunSpeed).toFixed(2);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostTime.Hours;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostTime.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }
                else if (ArrayOtherCost[i].VariableQty == "4")//Finished Item Qty Incl Spoilage
                {
                    if (ArrayOtherCost[i].HoursOrQty == Number(FinishedQty_Incl_Spoilage / HourlyRunSpeed).toFixed(2)) {
                        ArrayOtherCost[i].HoursOrQty = ArrayOtherCost[i].HoursOrQty;
                    }
                    else {
                        if (TestVar == '') {
                            ret = window.confirm("Do you wish to alter '" + ArrayOtherCost[i].OtherCostName + "' values?");
                            TestVar = 'Test';
                        }
                        if (ret) {
                            ArrayOtherCost[i].OtherCostTime.Hours = Number(FinishedQty_Incl_Spoilage / HourlyRunSpeed).toFixed(2);
                            var HoursOrQuantity = ArrayOtherCost[i].OtherCostTime.Hours;
                            CostVal = ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes);
                            ArrayOtherCost[i].OtherCostTime.Cost = CostVal; //
                            var profit1 = Number((CostVal * Markup) / 100);
                            var Sellprice = (Number(CostVal) + Number(profit1)).toFixed(2);
                            if (!isNaN(Sellprice) || !isFinite(Sellprice)) {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = Sellprice; //
                            }
                            else {
                                ArrayOtherCost[i].OtherCostTime.SellingPrice = "0.00"; //
                            }
                        }
                    }
                }

            }
        }
    }
}


//==****** END To Check Re-calculate Othercost VariableQty On Qty,Spoilage Change ****==//
//==***** To Recalculate Othercost Sellingprice *******==//
function ReCalculateCostPrice(CalType, HourlyRate, SetupTime, UnitRate, HoursOrQuantity, Markup, HourlyRunSpeed, Passes) {

    var cost = '0.00';
    var SellingPrice_Result = '0.00';
    if (CalType == 'q') {
        var setupcost = (HourlyRate * SetupTime) / 60;
        cost = ((UnitRate * HoursOrQuantity) + setupcost).toFixed(2);

        var profit = Number((cost * Markup) / 100);
        SellingPrice_Result = Number(cost + profit).toFixed(2);
    }
    else if (CalType == 't') {

        var runsrequired = HoursOrQuantity * HourlyRunSpeed;

        var totaltime = (HoursOrQuantity * 60) + Number(SetupTime);

        var setupcost = (HourlyRate * SetupTime) / 60;

        var sellingprice = (HourlyRate * HoursOrQuantity) + setupcost;
        cost = Number(sellingprice * Passes).toFixed(2);

        var profit = Number((sellingprice * Markup) / 100);
        var finalsellingprice = Number((sellingprice + profit) * Passes);

        SellingPrice_Result = Number(finalsellingprice).toFixed(2);
    }
    return cost;
}
//==***** To Recalculate Othercost Sellingprice *******==//

function BindOtherCostDesc() {
    if (hdn_OtherCostDesc.value != '') {
        var str = hdn_OtherCostDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                document.getElementById("div_CostItemTitle").style.display = "block";
                txt_lblCostItemTitle.value = str2[2];
                hdn_lblCostItemTitle.value = str2[2];
                if (txtCostItemTitleID.value == "") {
                    txtCostItemTitleID.value = txtItemTitle.value;
                }

            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_CostDescription").style.display = "block";
                txt_lblCostDescription.value = str2[2];
                hdn_lblCostDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_CostArtwork").style.display = "block";
                txt_lblCostArtwork.value = str2[2];
                hdn_lblCostArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_CostColour").style.display = "block";
                txt_lblCostColour.value = str2[2];
                hdn_lblCostColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_CostSize").style.display = "block";
                txt_lblCostSize.value = str2[2];
                hdn_lblCostSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_CostMaterial").style.display = "block";
                txt_lblCostMaterial.value = str2[2];
                hdn_lblCostMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_CostDelivery").style.display = "block";
                txt_lblCostDelivery.value = str2[2];
                hdn_lblCostDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_CostFinishing").style.display = "block";
                txt_lblCostFinishing.value = str2[2];
                hdn_lblCostFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_CostNotes").style.display = "block";
                txt_lblCostNotes.value = str2[2];
                hdn_lblCostNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_CostInstructions").style.display = "block";
                txt_lblCostInstructions.value = str2[2];
                hdn_lblCostInstructions.value = str2[2];
            }
        }
    }
    else {
        document.getElementById("div_CostItemTitle").style.display = "block";
        ////txtCostItemTitleID.value = txtItemTitle.value;
        hdn_lblCostDescription.value != '' ? document.getElementById("div_CostDescription").style.display = "block" : document.getElementById("div_CostDescription").style.display = "none";
        hdn_lblCostArtwork.value != '' ? document.getElementById("div_CostArtwork").style.display = "block" : document.getElementById("div_CostArtwork").style.display = "none";
        hdn_lblCostColour.value != '' ? document.getElementById("div_CostColour").style.display = "block" : document.getElementById("div_CostColour").style.display = "none";
        hdn_lblCostSize.value != '' ? document.getElementById("div_CostSize").style.display = "block" : document.getElementById("div_CostSize").style.display = "none";
        hdn_lblCostMaterial.value != '' ? document.getElementById("div_CostMaterial").style.display = "block" : document.getElementById("div_CostMaterial").style.display = "none";
        hdn_lblCostDelivery.value != '' ? document.getElementById("div_CostDelivery").style.display = "block" : document.getElementById("div_CostDelivery").style.display = "none";
        hdn_lblCostFinishing.value != '' ? document.getElementById("div_CostFinishing").style.display = "block" : document.getElementById("div_CostFinishing").style.display = "none";
        hdn_lblCostNotes.value != '' ? document.getElementById("div_CostNotes").style.display = "block" : document.getElementById("div_CostNotes").style.display = "none";
        hdn_lblCostInstructions.value != '' ? document.getElementById("div_CostInstructions").style.display = "block" : document.getElementById("div_CostInstructions").style.display = "none";
    }
}

function onblur_estQtyLists() {
    if (estimateType == 'm') {
        hdn_EstQtyList.value = EsttxtQuantity1.value + '~' + EsttxtQuantity2.value + '~' + EsttxtQuantity3.value + '~' + EsttxtQuantity4.value + '~';
        hdn_ItemTitle.value = txt_ItemTitle.value;
    }

    if (QtyNo == "1") {
        jobQtyCheck = EsttxtQuantity1.value;
    }
    else if (QtyNo == "2") {
        jobQtyCheck = EsttxtQuantity2.value;
    }
    else if (QtyNo == "3") {

        jobQtyCheck = EsttxtQuantity3.value;
    }
    else if (QtyNo == "4") {

        jobQtyCheck = EsttxtQuantity4.value;
    }
    if (jobQtyCheck == 0 || jobQtyCheck == '') {
        document.getElementById("spn_txtQuantity").style.display = "block";
    }
    else {
        document.getElementById("spn_txtQuantity").style.display = "none";
    }
}

