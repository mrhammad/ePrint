
function take_error(err) {
}
function OpenPaperPopUp(Type) {
    if (Type == 'paper') {
        var papertype = document.getElementById("spnPaperType").innerHTML;
        if (trim12(papertype) == "sheet(s)" || trim12(papertype) == "Sheet(s)") {
            papertype = "sheet";
        }
        else {
            papertype = "roll";
        }
        PopupCenter(strSitepath + "common/common_popup.aspx?type=invselector&pg=estimate&item=paper&papertype=" + papertype + "", '950', '400')
    }

    return false;
}
////This Function name is used in the warehouse/inventory_item_selector.ascx
function SendPaperIDandName(id, values, papertype) {
    lblDefaultPaper.title = values;
    lblDefaultPaper.innerHTML = trim12(values);
    lblDefaultPaper.style.cursor = "pointer";
    hdnpaperID.value = id;

    Paper_AssignToSummary();

    //if(papertype=="web printing")
    //ForWebPrinting("no");

    //To get Paper Height and Width on PaperID //
    PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
}

function GetPaperValue(result) {
    hdn_PaperProperties.value = result;
    var papertype = document.getElementById("spnPaperType").innerHTML;
    if (trim12(papertype) == "sheet(s)") {

    }
    else {
        var str2 = result.split('µ');
        var PaperSizeID = str2[0];
        var Height = str2[1];
        var Width = str2[2];
        txtsectionheight.value = Height;
        txtsectionwidth.value = Width;
        Calculations(); //1
    }
}

var Previous = '';
function QtyFromStage1() {
    tempEstimateType = 'printbroker';
    ShowPrintBroker();
    ArrangePrintBroker(hid_QtyType.value);
    Use_add_more();
}
function Validate_Before_Outwork() {
    if (productType == "singleitem" || productType == "booklet" || productType == "pads") {
        if (CreateItemValidation()) {
            if (ValidatePaper_HeightWidth()) {
                QtyFromStage1();
            }
        }
    }
    else if (estimateType == 'largeformat') {
        if (CreateItemValidation()) {
            if (ValidatePaper_HeightWidth()) {
                QtyFromStage1();
            }
        }
    }
}

function GuillotineSelect() {
    PopupCenter(strSitepath + "common/common_popup.aspx?type=moreplant&pg=estimate", '800', '400')
}

function LoadToItemTitle(txtValue) {
    var txt1 = txtSummaryItemTitle;
    var txt2 = txtItemTitle;
    var txt3 = txtPadItemTitle;
    var txt4 = txtLargeItemTitle;

    txt1.value = txtValue;
    txt2.value = txtValue;
    txt3.value = txtValue;
    txt4.value = txtValue;
}

var tempEstimateType = '';
function popup_phrasebook(type) {
    PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
}

//************************** PRINT BROKER *****************************
function PrintBrokerPrevious(PBtype) {
    if (PBtype == "show") {
        //document.getElementById("div_stage_2").style.display = "none";
        document.getElementById(print_broker).style.display = "block";
        ClearAllPrintProker();
        getPBItemTitle(txtItemTitle.value);
    }
    else {
        var PriceTable = document.getElementById("PriceTable");
        if (PriceTable.rows.length > 0) {
            if (window.confirm('You want to cancel this Print Broker ?')) {
                document.getElementById("div_stage_2").style.display = "block";
                document.getElementById(print_broker).style.display = "none";
                document.getElementById("lblheader").innerHTML = "Create Item";
                ClearAllPrintProker();
                getPBItemTitle(txtItemTitle.value);
            }
        }
        else {
            document.getElementById("div_stage_2").style.display = "block";
            document.getElementById(print_broker).style.display = "none";
            document.getElementById("div_none").style.display = "none";
            document.getElementById("lblheader").innerHTML = "Create Item";
            ClearAllPrintProker();
            getPBItemTitle(txtItemTitle.value);
        }
        tempEstimateType = '';
    }
}
function ShowPrintBroker() {
    IsPrintBrokerDirect = false;
    PrintBrokerPrevious('show');
}
function PrintBrokerFinalStage() {
    PrintBrokerPrevious('show');
}

//************************** PRINT BROKER END *************************
//************************* OTHER COST ********************************

function BindOtherCost(id, itemtype) {
    var catid = '';
    var othercosts = ""; //hid_OtherCostValues_Load.value;//'OtherCostValues';    

    var divContent = document.getElementById("divContent");
    divContent.innerHTML = '';
    var spncatid = id.replace('spncost', 'spncostcatid'); //"spncostcatid_"+i; 
    catid = document.getElementById(spncatid).innerHTML;

    //BY VINAY
    PageMethods.GetOtherCost_List(CompanyID, catid, function Create_Other(retnValue) {
        divContent.innerHTML = "";
        othercosts = retnValue;
        var GuillotineID = 0;
        var PaperID = 0;
        var PressID = 0;
        var EstOtherCostID = 0;
        if (itemtype == "s") {
            GuillotineID = hid_GuillotineID.value;
            PaperID = hdnpaperID.value;
            PressID = ddlPress.value;
        }

        // *** To Bind OtherCosts ***//
        var str = othercosts.split('±');

        var count = 0;
        for (var j = 0; j < str.length; j++) {
            document.getElementById("divsubheader").style.display = 'block';
            document.getElementById("divHeader").style.border = '1px solid silver';
            var str2 = str[j].split('»');

            if (catid == str2[0]) {
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
                var Mode = 'add';

                var div22 = "<div style='height:20px;padding:2px;background-color:" + color1 + "'>"
                div22 += "<div style='float:left;width:49%;'><a href='#' onclick=javascript:OpenPopup('" + CostID + "','" + CostTimeBasedID + "','" + CostCalType + "','" + itemtype + "','" + Mode + "','','" + GuillotineID + "','" + PaperID + "','" + PressID + "','" + EstOtherCostID + "');return false;>" + CostName + "</a></div>";
                div22 += "<div style='float:left;width:49%'>" + CostDesc + "</div>";
                div22 += "<div class='onlyEmpty'></div>";
                div22 += "</div>"
                divContent.innerHTML = divContent.innerHTML + div22;
                divContent.style.width = "100%";
                divContent.style.height = "300px";
                divContent.style.overflowX = "hidden";
                divContent.style.overflowY = "scroll";
            }
            else {
            }
        }
        if (count == 0) {
            document.getElementById("divsubheader").style.display = 'none';
            document.getElementById("divHeader").style.border = '0px solid silver';
            var div22 = "<div style='height:20px;padding:2px;background-color:" + color1 + "'>"
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
    //alert(error);
}
function OpenPopup(costid, costtypeid, caltype, itemtype, mode, otherinx, guillotineid, paperid, pressid, estothercostid) {
    OtherIndex = '';
    OtherIndex = otherinx;
    if (otherinx != '') {
        EditOtherPopupValues = '';
        //EditOtherPopupValues += "Description" +"»"+ ArrayOtherCost[OtherIndex].Description;

        //alert(ArrayOtherCost[OtherIndex].HoursOrQty);
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
            EditOtherPopupValues += "Quantity" + "»" + OtherQty.Quantity + "±";
            EditOtherPopupValues += "Markup" + "»" + OtherQty.Markup + "±";
            EditOtherPopupValues += "SetUpTime" + "»" + OtherQty.SetUpTime + "±";
            EditOtherPopupValues += "HourlyRate" + "»" + OtherQty.HourlyRate + "±";
            EditOtherPopupValues += "Cost" + "»" + OtherQty.Cost;
            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherQty.SellingPrice;                                      
        }
    }
    PopupCenter(strSitepath + "common/common_popup.aspx?type=othercost&costid=" + costid + "&costtypeid=" + costtypeid + "&caltype=" + caltype + "&itemtype=" + itemtype + "&mode=" + mode + "&otherinx=" + OtherIndex + "&pg=estimate&glid=" + guillotineid + "&invid=" + paperid + "&prid=" + pressid + "&estcostid=" + estothercostid + "", '800', '500');
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
    if (estimateType == "othercost") {
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
    //document.getElementById("div_stage_2").style.display = "none";
    document.getElementById(divOtherCost).style.display = "block";
    document.getElementById(divOtherCostbtnNext).style.display = "none";
    Create_Other_Cost_Tab('s'); //BY VINAY
}

function SaveQuestionInfo(strData) {
    var old = hid_OtherCost_Question.value;
    hid_OtherCost_Question.value = old + strData;
}

//************************ OTHER COST ENDS ****************************
function more_plant(section) {
    window.open(strSitepath + "common/common_popup.aspx?type=moreplant&pg=" + section + "", '', 'width=900px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
}
function more_paper(section) {
    window.open(strSitepath + "common/common_popup.aspx?type=morepaper&pg=" + section + "", '', 'width=900px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
}

function SectionsData(JCount, SCount) {
    var data = ''
    data += " <div id='div_Sec_" + TakeCount + "' align='left'> ";
    data += " <div style='float: left;'>";
    data += " <input id='btn_" + SCount + "' type='button' class='button' onclick=LoadSectionValues(" + TakeCount + ") value='" + SCount + "' style='width:20px;' />";
    data += " </div>";
    data += " <div style='float:left;width:10px'>&nbsp;</div>";
    data += " </div>";
    document.getElementById("div_btn_booklet_sections").innerHTML += data;
    ClaerSectionData();
}

//This function is for Testing booklet in Estimate Summary
function CheckBooklet() {
    var pa = strSitepath + "jobs/jobs_edit.aspx";
    var ur = location.href;

    if (productType == "booklet") {
        location.href = strSitepath + "estimates/estimate_item_form.aspx?item=bk";
        return false;
    }
    else if (location.href.toLowerCase() == pa.toLowerCase()) {
        location.href = strSitepath + "estimates/estimate_item_form.aspx?pg=job";
        return false;
    }
    else {
        location.href = strSitepath + "estimates/estimate_item_form.aspx";
        return false;
    }
}

//Main Warehouse
function Delete_Ware_MainItem_WebMethod(nos) {
    var EstWareID = warearray[nos].WareItemID;
    var firstConfirm = window.confirm('Are you sure, you want to remove ? ');
    if (firstConfirm) {
        PageMethods.RemoveWarehouseItem(CompanyID, EstWareID);
        warearray.splice(nos, 1);
        LoadWareMainItemListOnEdit();
    }
}

var IsAnyOutWork = false;
var IsAnyWarehouse = false;
var IsAnyOtherCost = false;


function handler() {
    for (var i = 0; i < QtyTypeArray.length; i++) {
        if (QtyTypeArray[i].checked) {
            if (QtyTypeArray[i].value != firstQtyValue && firstSay == false) {
                var doChnage = false;
                doChnage = window.confirm('If you change the Quantity Type this will erase the Previous Data. Do you want to continue ? ');
                if (doChnage) {
                    DivPriceCompClear_part_2();
                    firstSay = true;
                }
                else {
                    QtyTypeArray[i].checked = false;
                }
            }
        }
    }
}



function LoadMainWarehouseItems() {   //To Push WareData into Array//
    BindWareMainItemOnEdit();
}

function validatethis(val) {
    if (val != '') {
        document.getElementById("spn_txtQuantity").style.display = "none";
    }
}


function LoadToSheetCustom(ddlValue) {
    if (ddlValue == "0") {
        txtsectionheight.value = '';
        txtsectionwidth.value = '';
        chkPrintSheet.checked = false;
        PrintSheetCustom(chkPrintSheet.id);
    }
    else {
        var arr1 = hid_ddlPrintSheetSize.value.split('µ');

        for (var i = 0; i < arr1.length; i++) {
            var arr2 = arr1[i].split('±');
            if (ddlValue == arr2[0]) {
                txtsectionheight.value = arr2[2];
                txtsectionwidth.value = arr2[3];
            }
        }
    }
}


function LoadToItemCustom(ddlValue) {
    if (ddlValue == "0") {
        txtitemheight.value = '';
        txtitemwidth.value = '';

        ChkJobFlatCustom.checked = false;
        JobItemCustom(ChkJobFlatCustom.id);
    }
    else {
        var arr1 = hid_ddlPrintSheetSize.value.split('µ');
        for (var i = 0; i < arr1.length; i++) {
            var arr2 = arr1[i].split('±');
            if (ddlValue == arr2[0]) {
                txtitemheight.value = arr2[2];
                txtitemwidth.value = arr2[3];
            }
        }
    }
}

function PrintSheetCustom(chID) {
    document.getElementById("div_ddlPrintSheetSize").style.display = "none";
    document.getElementById("div_PrintSheetCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_PrintSheetCustomSize").style.display = "block";
        //txtsectionheight.focus();
    }
    else {
        document.getElementById("div_ddlPrintSheetSize").style.display = "block";
    }
}

function JobItemCustom(chID) {
    document.getElementById("div_ddlJobItemSize").style.display = "none";
    document.getElementById("div_JobItemCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_JobItemCustomSize").style.display = "block";
        //txtitemheight.focus();
    }
    else {
        document.getElementById("div_ddlJobItemSize").style.display = "block";
    }
}



function PrintLayout(chkLayout, chkLayoutID) {
    if (chkLayout == "landscape") {
        chkPortrait.checked = false;
    }
    else {
        chkLandscape.checked = false;
    }
    var chCheck = document.getElementById(chkLayoutID).checked;
    if (!chCheck) {
        document.getElementById(chkLayoutID).checked = true;
    }
}

function ItemTitleLoad(txtValue) {
    txtSummaryItemTitle.value = txtValue;
    txtItemTitle.value = txtValue;

    txtPadItemTitle.value = txtValue;
    txtLargeItemTitle.value = txtValue;
}

function validateName(val) {
    if (val != '') {
        document.getElementById("spn_txtItemTitle").style.display = "none";
    }
}

function BindSingleItemDesc() {
    if (hdn_SingleItemDesc.value != '') {
        var str = hdn_SingleItemDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                txt_lblSingleItemTitle.value = str2[2];
                hdn_lblSingleItemTitle.value = str2[2];
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_SingleDescription").style.display = "block";
                txt_lblSingleDesign.value = str2[2];
                hdn_lblSingleDesign.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_SingleArtwork").style.display = "block";
                txt_lblSingleArtwork.value = str2[2];
                hdn_lblSingleArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_SingleColour").style.display = "block";
                txt_lblSingleColour.value = str2[2];
                hdn_lblSingleColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_SingleSize").style.display = "block";
                txt_lblSummarySize.value = str2[2];
                hdn_lblSummarySize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_SingleMaterial").style.display = "block";
                txt_lblSingleMaterial.value = str2[2];
                hdn_lblSingleMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_SingleDelivery").style.display = "block";
                txt_lblSingleDelivery.value = str2[2];
                hdn_lblSingleDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_SingleFinishing").style.display = "block";
                txt_lblSingleFinishing.value = str2[2];
                hdn_lblSingleFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_SingleNotes").style.display = "block";
                txt_lblSingleNotes.value = str2[2];
                hdn_lblSingleNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_SingleInstructions").style.display = "block";
                txt_lblSingleInstructions.value = str2[2];
                hdn_lblSingleInstructions.value = str2[2];
            }
        }
    }
    else {
        //document.getElementById("div_CostItemTitle").style.display = "block";
        //txtCostItemTitleID.value = txtItemTitle.value;
        hdn_lblSingleDesign.value != '' ? document.getElementById("div_SingleDescription").style.display = "block" : document.getElementById("div_SingleDescription").style.display = "none";
        hdn_lblSingleArtwork.value != '' ? document.getElementById("div_SingleArtwork").style.display = "block" : document.getElementById("div_SingleArtwork").style.display = "none";
        hdn_lblSingleColour.value != '' ? document.getElementById("div_SingleColour").style.display = "block" : document.getElementById("div_SingleColour").style.display = "none";
        hdn_lblSummarySize.value != '' ? document.getElementById("div_SingleSize").style.display = "block" : document.getElementById("div_SingleSize").style.display = "none";
        hdn_lblSingleMaterial.value != '' ? document.getElementById("div_SingleMaterial").style.display = "block" : document.getElementById("div_SingleMaterial").style.display = "none";
        hdn_lblSingleDelivery.value != '' ? document.getElementById("div_SingleDelivery").style.display = "block" : document.getElementById("div_SingleDelivery").style.display = "none";
        hdn_lblSingleFinishing.value != '' ? document.getElementById("div_SingleFinishing").style.display = "block" : document.getElementById("div_SingleFinishing").style.display = "none";
        hdn_lblSingleNotes.value != '' ? document.getElementById("div_SingleNotes").style.display = "block" : document.getElementById("div_SingleNotes").style.display = "none";
        hdn_lblSingleInstructions.value != '' ? document.getElementById("div_SingleInstructions").style.display = "block" : document.getElementById("div_SingleInstructions").style.display = "none";

    }
}


function BindBookletDesc() {
    if (hdn_BookletDesc.value != '') {
        var str = hdn_BookletDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                txt_lblBookletItemTitle.value = str2[2];
                hdn_lblBookletItemTitle.value = str2[2];
                txtbookletItemTitleID.value = txtItemTitle.value;
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_BookletDescription").style.display = "block";
                txt_lblBookletDescription.value = str2[2];
                hdn_lblBookletDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_BookletArtwork").style.display = "block";
                txt_lblBookletArtwork.value = str2[2];
                hdn_lblBookletArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_BookletColours").style.display = "block";
                txt_lblBookletColours.value = str2[2];
                hdn_lblBookletColours.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_BookletSize").style.display = "block";
                txt_lblBookletSize.value = str2[2];
                hdn_lblBookletSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_BookletMaterial").style.display = "block";
                txt_lblBookletMaterial.value = str2[2];
                hdn_lblBookletMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_BookletDelivery").style.display = "block";
                txt_lblBookletDelivery.value = str2[2];
                hdn_lblBookletDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_BookletFinishing").style.display = "block";
                txt_lblBookletFinishing.value = str2[2];
                hdn_lblBookletFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_BookletNotes").style.display = "block";
                txt_lblBookletNotes.value = str2[2];
                hdn_lblBookletNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_BookletInstructions").style.display = "block";
                txt_lblBookletInstructions.value = str2[2];
                hdn_lblBookletInstructions.value = str2[2];
            }
        }
    }
    else {
        //document.getElementById("div_CostItemTitle").style.display = "block";
        txtbookletItemTitleID.value = txtItemTitle.value;
        hdn_lblBookletDescription.value != '' ? document.getElementById("div_BookletDescription").style.display = "block" : document.getElementById("div_BookletDescription").style.display = "none";
        hdn_lblBookletArtwork.value != '' ? document.getElementById("div_BookletArtwork").style.display = "block" : document.getElementById("div_BookletArtwork").style.display = "none";
        hdn_lblBookletColours.value != '' ? document.getElementById("div_BookletColours").style.display = "block" : document.getElementById("div_BookletColours").style.display = "none";
        hdn_lblBookletSize.value != '' ? document.getElementById("div_BookletSize").style.display = "block" : document.getElementById("div_BookletSize").style.display = "none";
        hdn_lblBookletMaterial.value != '' ? document.getElementById("div_BookletMaterial").style.display = "block" : document.getElementById("div_BookletMaterial").style.display = "none";
        hdn_lblBookletDelivery.value != '' ? document.getElementById("div_BookletDelivery").style.display = "block" : document.getElementById("div_BookletDelivery").style.display = "none";
        hdn_lblBookletFinishing.value != '' ? document.getElementById("div_BookletFinishing").style.display = "block" : document.getElementById("div_BookletFinishing").style.display = "none";
        hdn_lblBookletNotes.value != '' ? document.getElementById("div_BookletNotes").style.display = "block" : document.getElementById("div_BookletNotes").style.display = "none";
        hdn_lblBookletInstructions.value != '' ? document.getElementById("div_BookletInstructions").style.display = "block" : document.getElementById("div_BookletInstructions").style.display = "none";
    }
}

function BindPadsDesc() {
    if (hdn_PadsDesc.value != '') {
        var str = hdn_PadsDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                txt_lblPadItemTitle.value = str2[2];
                hdn_lblPadItemTitle.value = str2[2];
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_PadDescription").style.display = "block";
                txt_lblPadDescription.value = str2[2];
                hdn_lblPadDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_PadArtwork").style.display = "block";
                txt_lblPadArtwork.value = str2[2];
                hdn_lblPadArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_PadColour").style.display = "block";
                txt_lblPadColour.value = str2[2];
                hdn_lblPadColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_PadSize").style.display = "block";
                txt_lblPadSize.value = str2[2];
                hdn_lblPadSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_PadMaterial").style.display = "block";
                txt_lblPadMaterial.value = str2[2];
                hdn_lblPadMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_PadDelivery").style.display = "block";
                txt_lblPadDelivery.value = str2[2];
                hdn_lblPadDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_PadFinishing").style.display = "block";
                txt_lblPadFinishing.value = str2[2];
                hdn_lblPadFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_PadNotes").style.display = "block";
                txt_lblPadNotes.value = str2[2];
                hdn_lblPadNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_PadInstructions").style.display = "block";
                txt_lblPadInstructions.value = str2[2];
                hdn_lblPadInstructions.value = str2[2];
            }
        }
    }
    else {
        //document.getElementById("div_CostItemTitle").style.display = "block";
        //txtCostItemTitleID.value = txtItemTitle.value;
        hdn_lblPadDescription.value != '' ? document.getElementById("div_PadDescription").style.display = "block" : document.getElementById("div_PadDescription").style.display = "none";
        hdn_lblPadArtwork.value != '' ? document.getElementById("div_PadArtwork").style.display = "block" : document.getElementById("div_PadArtwork").style.display = "none";
        hdn_lblPadColour.value != '' ? document.getElementById("div_PadColour").style.display = "block" : document.getElementById("div_PadColour").style.display = "none";
        hdn_lblPadSize.value != '' ? document.getElementById("div_PadSize").style.display = "block" : document.getElementById("div_PadSize").style.display = "none";
        hdn_lblPadMaterial.value != '' ? document.getElementById("div_PadMaterial").style.display = "block" : document.getElementById("div_PadMaterial").style.display = "none";
        hdn_lblPadDelivery.value != '' ? document.getElementById("div_PadDelivery").style.display = "block" : document.getElementById("div_PadDelivery").style.display = "none";
        hdn_lblPadFinishing.value != '' ? document.getElementById("div_PadFinishing").style.display = "block" : document.getElementById("div_PadFinishing").style.display = "none";
        hdn_lblPadNotes.value != '' ? document.getElementById("div_PadNotes").style.display = "block" : document.getElementById("div_PadNotes").style.display = "none";
        hdn_lblPadInstructions.value != '' ? document.getElementById("div_PadInstructions").style.display = "block" : document.getElementById("div_PadInstructions").style.display = "none";
    }
}


function BindLargeFormatDesc() {
    if (hdn_LargeDesc.value != '') {
        var str = hdn_LargeDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                txt_lblLargeItemTitle.value = str2[2];
                hdn_lblLargeItemTitle.value = str2[2];
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_LargeDescription").style.display = "block";
                txt_lblLargeDescription.value = str2[2];
                hdn_lblLargeDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_LargeArtwork").style.display = "block";
                txt_lblLargeArtwork.value = str2[2];
                hdn_lblLargeArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_LargeColour").style.display = "block";
                txt_lblLargeColour.value = str2[2];
                hdn_lblLargeColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_LargeSize").style.display = "block";
                txt_lblLargeSize.value = str2[2];
                hdn_lblLargeSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_LargeMaterial").style.display = "block";
                txt_lblLargeMaterial.value = str2[2];
                hdn_lblLargeMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_LargeDelivery").style.display = "block";
                txt_lblLargeDelivery.value = str2[2];
                hdn_lblLargeDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_LargeFinishing").style.display = "block";
                txt_lblLargeFinishing.value = str2[2];
                hdn_lblLargeFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_LargeNotes").style.display = "block";
                txt_lblLargeNotes.value = str2[2];
                hdn_lblLargeNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_LargeInstructions").style.display = "block";
                txt_lblLargeInstructions.value = str2[2];
                hdn_lblLargeInstructions.value = str2[2];
            }
        }
    }
    else {
        //document.getElementById("div_CostItemTitle").style.display = "block";
        //txtCostItemTitleID.value = txtItemTitle.value;
        hdn_lblLargeDescription.value != '' ? document.getElementById("div_LargeDescription").style.display = "block" : document.getElementById("div_LargeDescription").style.display = "none";
        hdn_lblLargeArtwork.value != '' ? document.getElementById("div_LargeArtwork").style.display = "block" : document.getElementById("div_LargeArtwork").style.display = "none";
        hdn_lblLargeColour.value != '' ? document.getElementById("div_LargeColour").style.display = "block" : document.getElementById("div_LargeColour").style.display = "none";
        hdn_lblLargeSize.value != '' ? document.getElementById("div_LargeSize").style.display = "block" : document.getElementById("div_LargeSize").style.display = "none";
        hdn_lblLargeMaterial.value != '' ? document.getElementById("div_LargeMaterial").style.display = "block" : document.getElementById("div_LargeMaterial").style.display = "none";
        hdn_lblLargeDelivery.value != '' ? document.getElementById("div_LargeDelivery").style.display = "block" : document.getElementById("div_LargeDelivery").style.display = "none";
        hdn_lblLargeFinishing.value != '' ? document.getElementById("div_LargeFinishing").style.display = "block" : document.getElementById("div_LargeFinishing").style.display = "none";
        hdn_lblLargeNotes.value != '' ? document.getElementById("div_LargeNotes").style.display = "block" : document.getElementById("div_LargeNotes").style.display = "none";
        hdn_lblLargeInstructions.value != '' ? document.getElementById("div_LargeInstructions").style.display = "block" : document.getElementById("div_LargeInstructions").style.display = "none";
    }
}

function BindOutworkDesc() {
    if (hdn_OutworkDesc.value != '') {
        var str = hdn_OutworkDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                txt_lblPBItemTitle.value = str2[2];
                hdn_lblPBItemTitle.value = str2[2];
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_PBDescription").style.display = "block";
                txt_lblPBDescription.value = str2[2];
                hdn_lblPBDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_PBArtwork").style.display = "block";
                txt_lblPBArtwork.value = str2[2];
                hdn_lblPBArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_PBColour").style.display = "block";
                txt_lblPBColour.value = str2[2];
                hdn_lblPBColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_PBSize").style.display = "block";
                txt_lblPBSize.value = str2[2];
                hdn_lblPBSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_PBMaterial").style.display = "block";
                txt_lblPBMaterials.value = str2[2];
                hdn_lblPBMaterials.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_PBDelivery").style.display = "block";
                txt_lblPBDelivery.value = str2[2];
                hdn_lblPBDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_PBFinishing").style.display = "block";
                txt_lblPBFinishing.value = str2[2];
                hdn_lblPBFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_PBNotes").style.display = "block";
                txt_lblPBNotes.value = str2[2];
                hdn_lblPBNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_PBInstructions").style.display = "block";
                txt_lblPBInstructions.value = str2[2];
                hdn_lblPBInstructions.value = str2[2];
            }
        }
    }
    else {
        //document.getElementById("div_CostItemTitle").style.display = "block";
        //txtPBItemTitleID.value = txtItemTitle.value;
        hdn_lblPBDescription.value != '' ? document.getElementById("div_PBDescription").style.display = "block" : document.getElementById("div_PBDescription").style.display = "none";
        hdn_lblPBArtwork.value != '' ? document.getElementById("div_PBArtwork").style.display = "block" : document.getElementById("div_PBArtwork").style.display = "none";
        hdn_lblPBColour.value != '' ? document.getElementById("div_PBColour").style.display = "block" : document.getElementById("div_PBColour").style.display = "none";
        hdn_lblPBSize.value != '' ? document.getElementById("div_PBSize").style.display = "block" : document.getElementById("div_PBSize").style.display = "none";
        hdn_lblPBMaterials.value != '' ? document.getElementById("div_PBMaterial").style.display = "block" : document.getElementById("div_PBMaterial").style.display = "none";
        hdn_lblPBDelivery.value != '' ? document.getElementById("div_PBDelivery").style.display = "block" : document.getElementById("div_PBDelivery").style.display = "none";
        hdn_lblPBFinishing.value != '' ? document.getElementById("div_PBFinishing").style.display = "block" : document.getElementById("div_PBFinishing").style.display = "none";
        hdn_lblPBNotes.value != '' ? document.getElementById("div_PBNotes").style.display = "block" : document.getElementById("div_PBNotes").style.display = "none";
        hdn_lblPBInstructions.value != '' ? document.getElementById("div_PBInstructions").style.display = "block" : document.getElementById("div_PBInstructions").style.display = "none";
    }
}


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

function BindWarehouseDesc() {

    if (hdn_WarehouseDesc.value != '') {
        var str = hdn_WarehouseDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                document.getElementById("div_WareItemTitle").style.display = "block";
                txt_lblWareItemtitle.value = str2[2];
                hdn_lblWareItemtitle.value = str2[2];

                //                if (txtWareItemTitleID.value == '') {
                //                    txtWareItemTitleID.value = txtItemTitle.value;
                //                }
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_WareDescription").style.display = "block";

                txt_lblWareDescription.value = str2[2];
                hdn_lblWareDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_WareArtwork").style.display = "block";
                txt_lblWareArtwork.value = str2[2];
                hdn_lblWareArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_WareColour").style.display = "block";
                txt_lblWareColour.value = str2[2];
                hdn_lblWareColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_WareSize").style.display = "block";
                txt_lblWareSize.value = str2[2];
                hdn_lblWareSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_WareMaterial").style.display = "block";
                txt_lblWareMaterial.value = str2[2];
                hdn_lblWareMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_WareDelivery").style.display = "block";
                txt_lblWareDelivery.value = str2[2];
                hdn_lblWareDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_WareFinishing").style.display = "block";
                txt_lblWareFinishing.value = str2[2];
                hdn_lblWareFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_WareNotes").style.display = "block";
                txt_lblWareNotes.value = str2[2];
                hdn_lblWareNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_WareInstructions").style.display = "block";
                txt_lblWareInstructions.value = str2[2];
                hdn_lblWareInstructions.value = str2[2];
            }
        }
    }
    else {
        document.getElementById("div_WareItemTitle").style.display = "block";
        hdn_lblWareDescription.value != '' ? document.getElementById("div_WareDescription").style.display = "block" : document.getElementById("div_WareDescription").style.display = "none";
        hdn_lblWareArtwork.value != '' ? document.getElementById("div_WareArtwork").style.display = "block" : document.getElementById("div_WareArtwork").style.display = "none";
        hdn_lblWareColour.value != '' ? document.getElementById("div_WareColour").style.display = "block" : document.getElementById("div_WareColour").style.display = "none";
        hdn_lblWareSize.value != '' ? document.getElementById("div_WareSize").style.display = "block" : document.getElementById("div_WareSize").style.display = "none";
        hdn_lblWareMaterial.value != '' ? document.getElementById("div_WareMaterial").style.display = "block" : document.getElementById("div_WareMaterial").style.display = "none";
        hdn_lblWareDelivery.value != '' ? document.getElementById("div_WareDelivery").style.display = "block" : document.getElementById("div_WareDelivery").style.display = "none";
        hdn_lblWareFinishing.value != '' ? document.getElementById("div_WareFinishing").style.display = "block" : document.getElementById("div_WareFinishing").style.display = "none";
        hdn_lblWareNotes.value != '' ? document.getElementById("div_WareNotes").style.display = "block" : document.getElementById("div_WareNotes").style.display = "none";
        hdn_lblWareInstructions.value != '' ? document.getElementById("div_WareInstructions").style.display = "block" : document.getElementById("div_WareInstructions").style.display = "none";
    }
}

function CollectQuantity() {
    QType = hid_QtyType.value;
    if (QType == "S") {
        hid_Q1.value = txtQuantity.value;
    }
    else if (QType == "R") {
        hid_Q1.value = txtQuantity.value;
        hid_Q2.value = txtRunOnQty.value;
    }
    else if (QType == "M") {
        hid_Q1.value = txtQuantity.value;
        hid_Q2.value = txtQuantity_2.value;
        hid_Q3.value = txtQuantity_3.value;
        hid_Q4.value = txtQuantity_4.value;
    }
}

function StoreStage1_Data() {
    hid_Stage1_values.value = stage1_values;
}

function TakeQtyValues(ObjArray) {
    var ListOfQuantity = '';
    for (var q = 0; q < ObjArray.length; q++) {
        var Qtype = ObjArray[0].QtyType;
        if (Qtype == "S") {
            ListOfQuantity = "S«" + ObjArray[0].Quantity1;

            hid_Q1.value = ObjArray[0].Quantity1;
        }
        else if (Qtype == "R") {
            ListOfQuantity = "R«" + ObjArray[0].Quantity1 + "«" + ObjArray[0].Quantity2;
            hid_Q1.value = ObjArray[0].Quantity1;
            hid_Q2.value = ObjArray[0].Quantity2;
        }
        else if (Qtype == "M") {
            ListOfQuantity = "M«" + ObjArray[0].Quantity1 + "«" + ObjArray[0].Quantity2 + "«" + ObjArray[0].Quantity3 + "«" + ObjArray[0].Quantity4;
            hid_Q1.value = ObjArray[0].Quantity1;
            hid_Q2.value = ObjArray[0].Quantity2;
            hid_Q3.value = ObjArray[0].Quantity3;
            hid_Q4.value = ObjArray[0].Quantity4;
        }
    }

    return ListOfQuantity;
}

function SaveData() {

    MakeDisable("no");
    //By Vinay
    if (Is_Maximum_Booklet_Section()) {
        return false;
    }
    StoreStage1_Data(); //Stage 1 Data
    CollectQuantity(); //FOR BOOKLET see TakeQtyValues(bookArr[0].QuantityList);

    if (productType == '') {
        hid_Estimate_Type.value = estimateType;
    }
    else {
        hid_Estimate_Type.value = productType;
    }

    ////+++++++++++++++++++++++++++++++++ Booklet Sections ++++++++++++++++++++++++++++++++ 
    var StoreBooklet = '';
    for (var i = 0; i < bookArr.length; i++) {
        StoreBooklet += "Title»" + bookArr[i].Title + '±';
        StoreBooklet += "EstimateTyp»" + bookArr[i].EstimateTyp + '±';
        StoreBooklet += "SectionRef»" + bookArr[i].SectionRef + '±';
        StoreBooklet += "Quantity»" + bookArr[i].Quantity + '±';
        StoreBooklet += "PressID»" + bookArr[i].PressID + '±';
        StoreBooklet += "PressType»" + bookArr[i].PressType + '±';
        StoreBooklet += "PaperID»" + bookArr[i].PaperID + '±';
        StoreBooklet += "PriceForWhaolePack»" + bookArr[i].PriceForWhaolePack + '±';
        StoreBooklet += "PaperSupplied»" + bookArr[i].PaperSupplied + '±';
        StoreBooklet += "SetupSpoilage»" + bookArr[i].SetupSpoilage + '±';
        StoreBooklet += "RunningSpoilage»" + bookArr[i].RunningSpoilage + '±';

        //StoreBooklet += "NoOfPagesRequired»" + bookArr[i].NoOfPagesRequired +'±';
        //StoreBooklet += "PagesPerSection»" + bookArr[i].PagesPerSection +'±';
        StoreBooklet += "NoOfPagesInSection»" + bookArr[i].NoOfPagesInSection + '±';
        StoreBooklet += "PagesPerSignature»" + bookArr[i].PagesPerSignature + '±';
        StoreBooklet += "NoOfSignatures»" + bookArr[i].NoOfSignatures + '±';

        StoreBooklet += "Colour »" + bookArr[i].Color + '±';
        StoreBooklet += "IsDoubleSided »" + bookArr[i].IsDoubleSided + '±';
        StoreBooklet += "SideColor »" + bookArr[i].SideColor + '±';

        StoreBooklet += "PrintSheetSizeID »" + bookArr[i].PrintSheetSizeID + '±';
        StoreBooklet += "IsPrintCustom »" + bookArr[i].IsPrintCustom + '±';
        StoreBooklet += "PrintSheetHeight »" + bookArr[i].PrintSheetHeight + '±';
        StoreBooklet += "PrintSheetWidth »" + bookArr[i].PrintSheetWidth + '±';

        StoreBooklet += "JobFlatSizeID »" + bookArr[i].JobFlatSizeID + '±';
        StoreBooklet += "IsJobCustom »" + bookArr[i].IsJobCustom + '±';
        StoreBooklet += "JobFlatSizeHeight »" + bookArr[i].JobFlatSizeHeight + '±';
        StoreBooklet += "JobFlatSizeWidth »" + bookArr[i].JobFlatSizeWidth + '±';

        StoreBooklet += "IsIncludeGutters »" + bookArr[i].IsIncludeGutters + '±';
        StoreBooklet += "GutterHorizontal »" + bookArr[i].GutterHorizontal + '±';
        StoreBooklet += "GutterVertical »" + bookArr[i].GutterVertical + '±';
        StoreBooklet += "IsPressRestrictions »" + bookArr[i].IsPressRestrictions + '±';

        StoreBooklet += "PrintLayout»" + bookArr[i].PrintLayout + '±';
        StoreBooklet += "PortraitValue»" + bookArr[i].PortraitValue + '±';
        StoreBooklet += "LandscapeValue»" + bookArr[i].LandscapeValue + '±';

        StoreBooklet += "GuilotineID »" + bookArr[i].GuilotineID + '±';
        StoreBooklet += "IsFirstTrim »" + bookArr[i].IsFirstTrim + '±';
        StoreBooklet += "IsSecondTrim »" + bookArr[i].IsSecondTrim + '±';

        StoreBooklet += "BookletFormat »" + bookArr[i].BookletFormat + '±';

        StoreBooklet += "QtyList» "; //// TakeQtyValues(bookArr[i].QuantityList) Move to the another function
        StoreBooklet += "µ";
    }

    if (productType == "booklet") {
        /////TakeQtyValues(bookArr[0].QuantityList);
    }

    hid_booklet_save.value = StoreBooklet;

    //+++++++++++++++++++++++++++++++++ PRINT BROKER ++++++++++++++++++++++++++++++++

    var StoreData = '';

    for (var i = 0; i < ArrayPrint.length; i++) {
        StoreData += "QtyType » " + ArrayPrint[i].QtyType + '±';
        StoreData += "Quantity » " + ArrayPrint[i].Quantity + '±';

        StoreData += "CostingType » " + ArrayPrint[i].CostingType + '±';
        StoreData += "RFQReturnDate » " + ArrayPrint[i].RFQReturnDate + '±';
        StoreData += "JobCompletionDate » " + ArrayPrint[i].JobCompletionDate + '±';
        StoreData += "Header»" + ArrayPrint[i].Header + '±';
        StoreData += "Footer»" + ArrayPrint[i].Footer + '±';
        StoreData += "ArtWork » " + ArrayPrint[i].ArtWork + '±';
        StoreData += "EstItemOutworkID » " + ArrayPrint[i].EstOutworkID + '±';

        ////------------------------------------------------------------------------------------
        StoreData += "§";
        StoreData += "ItemTitle » " + ArrayPrint[i].Title + '»' + ArrayPrint[i].TitleDescription + '»' + ArrayPrint[i].TitleIsChecked + '±';
        StoreData += "Description » " + ArrayPrint[i].Origination + '»' + ArrayPrint[i].OriginationDescription + '»' + ArrayPrint[i].OriginationIsChecked + '±';
        StoreData += "Artwork » " + ArrayPrint[i].Artwork + '»' + ArrayPrint[i].ArtworkDescription + '»' + ArrayPrint[i].ArtworkIsChecked + '±';
        StoreData += "Colour » " + ArrayPrint[i].Color + '»' + ArrayPrint[i].ColorDescription + '»' + ArrayPrint[i].ColorIsChecked + '±';
        StoreData += "Size » " + ArrayPrint[i].Size + '»' + ArrayPrint[i].SizeDescription + '»' + ArrayPrint[i].SizeIsChecked + '±';
        StoreData += "Material » " + ArrayPrint[i].Material + '»' + ArrayPrint[i].MaterialDescription + '»' + ArrayPrint[i].MaterialIsChecked + '±';
        StoreData += "Finishing » " + ArrayPrint[i].Finishing + '»' + ArrayPrint[i].FinishingDescription + '»' + ArrayPrint[i].FinishingIsChecked + '±';
        StoreData += "Delivery » " + ArrayPrint[i].Delivery + '»' + ArrayPrint[i].DeliveryDescription + '»' + ArrayPrint[i].DeliveryIsChecked + '±';
        StoreData += "Notes » " + ArrayPrint[i].Notes + '»' + ArrayPrint[i].NotesDescription + '»' + ArrayPrint[i].NotesIsChecked + '±';
        StoreData += "Instructions » " + ArrayPrint[i].Terms + '»' + ArrayPrint[i].TermsDescription + '»' + ArrayPrint[i].TermsIsChecked;

        StoreData += "§";

        var pirArr = ArrayPrint[i].PriceList;

        for (k = 0; k < pirArr.length; k++) {
            if (pirArr[k].Quantity != null && pirArr[k].Quantity != '') {
                StoreData += "SupplierID »" + pirArr[k].SupplierID + '±';
                StoreData += "SupplierContactID »" + pirArr[k].SupplierContactID + '±';
                StoreData += "Quantity »" + pirArr[k].Quantity + '±';
                StoreData += "Cost »" + pirArr[k].Cost + '±';
                StoreData += "DeliveryIncluded »" + pirArr[k].DeliveryIncluded + '±';
                StoreData += "DeliveryCost »" + pirArr[k].DeliveryCost + '±';
                StoreData += "DeliveryDate »" + pirArr[k].DeliveryDate + '±';
                StoreData += "MarkupType »" + pirArr[k].MarkupType + '±';
                StoreData += "MarkupValue »" + pirArr[k].MarkupValue + '±';
                StoreData += "TotalPrice »" + pirArr[k].TotalPrice + '±';
                StoreData += "IsSelected »" + pirArr[k].IsSelected + '±';
                StoreData += "QuantityNumber »" + pirArr[k].QuantityNumber + 'Ç';
            }
        }
        StoreData += "µ";
    }
    hid_outwork_save.value = StoreData;

    //For Phrase Book
    var Phrase_BrokerData = '';
    for (var i = 0; i < ArrayBroker.length; i++) {
        if (ArrayBroker[i].TitleDescription != '') {
            Phrase_BrokerData += "PrintBroker Title »" + ArrayBroker[i].TitleDescription + '±';
        }
        if (ArrayBroker[i].OriginationDescription != '') {
            Phrase_BrokerData += "PrintBroker Description » " + ArrayBroker[i].OriginationDescription + '±';
        }
        if (ArrayBroker[i].ArtworkDescription != '') {
            Phrase_BrokerData += "PrintBroker Artwork » " + ArrayBroker[i].ArtworkDescription + '±';
        }
        if (ArrayBroker[i].ColorDescription != '') {
            Phrase_BrokerData += "PrintBroker Colours » " + ArrayBroker[i].ColorDescription + '±';
        }
        if (ArrayBroker[i].SizeDescription != '') {
            Phrase_BrokerData += "PrintBroker Size » " + ArrayBroker[i].SizeDescription + '±';
        }
        if (ArrayBroker[i].MaterialDescription != '') {
            Phrase_BrokerData += "PrintBroker Material » " + ArrayBroker[i].MaterialDescription + '±';
        }
        if (ArrayBroker[i].FinishingDescription != '') {
            Phrase_BrokerData += "PrintBroker Finishing » " + ArrayBroker[i].FinishingDescription + '±';
        }
        if (ArrayBroker[i].DeliveryDescription != '') {
            Phrase_BrokerData += "PrintBroker Delivery » " + ArrayBroker[i].DeliveryDescription + '±';
        }
        if (ArrayBroker[i].NotesDescription != '') {
            Phrase_BrokerData += "PrintBroker Notes » " + ArrayBroker[i].NotesDescription + '±';
        }
        if (ArrayBroker[i].TermsDescription != '') {
            Phrase_BrokerData += "PrintBroker Terms » " + ArrayBroker[i].TermsDescription + 'µ';
        }
    }
    hid_outwork_phrase_data.value = Phrase_BrokerData;

    ////++++++++++++++++++++++++++ Warehouse +++++++++++++++++++++++++++++++++++++++++++

    var wareData = '';

    for (var p = 0; p < warearray.length; p++) {
        wareData += "WarehouseType »" + warearray[p].WareType + '±';
        wareData += "WarehouseID »" + warearray[p].ItemID + '±';
        wareData += "Quantity »" + warearray[p].Quantity + '±';
        wareData += "WarehouseName »" + warearray[p].ItemName + '±';
        wareData += "UnitPrice »" + warearray[p].WareValue + '±';
        wareData += "PackedInQty »" + warearray[p].PackedInQty + '±';
        wareData += "IsDeleted »" + warearray[p].IsDeleted + '±';

        var WareItemID = 0;
        if (warearray[p].WareItemID != '') {
            WareItemID = warearray[p].WareItemID;
        }
        else {
            WareItemID = 0;
        }
        wareData += "WarehouseItemID »" + WareItemID + 'µ';
    }
    if (wareData != '') {
        hid_warehouse_save.value = wareData;
    }
    ////++++++++++++++++++++++++++ Othercost +++++++++++++++++++++++++++++++++++++++++++
    ReCalculateVariableQty(); //to recalculate othercost variable hrsorqty [for time and qty based]
    getOtherCostval(); //to get othercost values
    return true;
}



function BindCatalogueDesc() {
    if (hdn_CatalogueDesc.value != '') {
        var str = hdn_CatalogueDesc.value.split('µ');
        var str2 = '';
        for (var i = 0; i < str.length; i++) {
            str2 = str[i].split('»');
            if (str2[1] == "ItemTitle" && str2[3] == "1") {
                document.getElementById("div_CatalogueItemTitle").style.display = "block";
                txt_lblCatalogueItemtitle.value = str2[2];
                hdn_lblCatalogueItemtitle.value = str2[2];
            }
            if (str2[1] == "Description" && str2[3] == "1") {
                document.getElementById("div_CatalogueDescription").style.display = "block";
                txt_lblCatalogueDescription.value = str2[2];
                hdn_lblCatalogueDescription.value = str2[2];
            }
            if (str2[1] == "Artwork" && str2[3] == "1") {
                document.getElementById("div_CatalogueArtwork").style.display = "block";
                txt_lblCatalogueArtwork.value = str2[2];
                hdn_lblCatalogueArtwork.value = str2[2];
            }
            if (str2[1] == "Colour" && str2[3] == "1") {
                document.getElementById("div_CatalogueColour").style.display = "block";
                txt_lblCatalogueColour.value = str2[2];
                hdn_lblCatalogueColour.value = str2[2];
            }
            if (str2[1] == "Size" && str2[3] == "1") {
                document.getElementById("div_CatalogueSize").style.display = "block";
                txt_lblCatalogueSize.value = str2[2];
                hdn_lblCatalogueSize.value = str2[2];
            }
            if (str2[1] == "Material" && str2[3] == "1") {
                document.getElementById("div_CatalogueMaterial").style.display = "block";
                txt_lblCatalogueMaterial.value = str2[2];
                hdn_lblCatalogueMaterial.value = str2[2];
            }
            if (str2[1] == "Delivery" && str2[3] == "1") {
                document.getElementById("div_CatalogueDelivery").style.display = "block";
                txt_lblCatalogueDelivery.value = str2[2];
                hdn_lblCatalogueDelivery.value = str2[2];
            }
            if (str2[1] == "Finishing" && str2[3] == "1") {
                document.getElementById("div_CatalogueFinishing").style.display = "block";
                txt_lblCatalogueFinishing.value = str2[2];
                hdn_lblCatalogueFinishing.value = str2[2];
            }
            if (str2[1] == "Notes" && str2[3] == "1") {
                document.getElementById("div_CatalogueNotes").style.display = "block";
                txt_lblCatalogueNotes.value = str2[2];
                hdn_lblCatalogueNotes.value = str2[2];
            }
            if (str2[1] == "Instructions" && str2[3] == "1") {
                document.getElementById("div_CatalogueInstructions").style.display = "block";
                txt_lblCatalogueInstructions.value = str2[2];
                hdn_lblCatalogueInstructions.value = str2[2];
            }
        }
    }
    else {
        document.getElementById("div_CatalogueItemTitle").style.display = "block";
        ////BY VINAY txtCatalogueItemTitleID.value = txtItemTitle.value;
        hdn_lblCatalogueDescription.value != '' ? document.getElementById("div_CatalogueDescription").style.display = "block" : document.getElementById("div_CatalogueDescription").style.display = "none";
        hdn_lblCatalogueArtwork.value != '' ? document.getElementById("div_CatalogueArtwork").style.display = "block" : document.getElementById("div_CatalogueArtwork").style.display = "none";
        hdn_lblCatalogueColour.value != '' ? document.getElementById("div_CatalogueColour").style.display = "block" : document.getElementById("div_CatalogueColour").style.display = "none";
        hdn_lblCatalogueSize.value != '' ? document.getElementById("div_CatalogueSize").style.display = "block" : document.getElementById("div_CatalogueSize").style.display = "none";
        hdn_lblCatalogueMaterial.value != '' ? document.getElementById("div_CatalogueMaterial").style.display = "block" : document.getElementById("div_CatalogueMaterial").style.display = "none";
        hdn_lblCatalogueDelivery.value != '' ? document.getElementById("div_CatalogueDelivery").style.display = "block" : document.getElementById("div_CatalogueDelivery").style.display = "none";
        hdn_lblCatalogueFinishing.value != '' ? document.getElementById("div_CatalogueFinishing").style.display = "block" : document.getElementById("div_CatalogueFinishing").style.display = "none";
        hdn_lblCatalogueNotes.value != '' ? document.getElementById("div_CatalogueNotes").style.display = "block" : document.getElementById("div_CatalogueNotes").style.display = "none";
        hdn_lblCatalogueInstructions.value != '' ? document.getElementById("div_CatalogueInstructions").style.display = "block" : document.getElementById("div_CatalogueInstructions").style.display = "none";
    }
}


function MadeDefault() {
    document.getElementById(div_Product_Type).style.display = "none";
    ////Digital
    document.getElementById(div_only_digitalsleft).style.display = "none";
    document.getElementById(div_only_digitalsright).style.display = "none";

    ////Booklet
    document.getElementById(div_BtnNextSection).style.display = "none";
    document.getElementById(div_Booklet_Delete).style.display = "none";
    //document.getElementById("<%=btnStage2_Next.ClientID %>").innerText="Next";////problem in safari

    ////booklet
    document.getElementById(div_BookletNoOfPagesInSection).style.display = "none";
    document.getElementById(div_BookletNoOfSignatures).style.display = "none";
    document.getElementById(div_BookletFormat).style.display = "none";

    ////Large Format
    document.getElementById(div_chk_Run_OnQty).style.display = "block";
    document.getElementById(div_Print_Quality_Sector).style.display = "none";
    document.getElementById(div_Ink_Coverage).style.display = "none";

    div_price_catalogue.style.display = "none";

    document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "none";
    ////summary
    AllSummaryNone();

    //PRINT BROKER
    document.getElementById(print_broker).style.display = "none";
    //WAREHOUSE
    IsWareDirect = false;
    document.getElementById(div_StockOnly).style.display = "none";
    document.getElementById(div_Ware_Next_Button).style.display = "none";
    document.getElementById(div_WarehouseSummary).style.display = "none";

    ///PRINT BROKER
    IsPrintBrokerDirect = false;
    document.getElementById(print_broker).style.display = "none";

    //OTHER COSTS
    IsOtherCost = false;
    document.getElementById(divOtherCost).style.display = "none";
    document.getElementById(divOtherCostbtnNext).style.display = "none";
}

function ShowOutworkItems(obj) {
    //// BY VINAY PaceInCenter("div_OutworkItems",300,175);
    document.getElementById("div_OutworkItems").style.display = "block";
    tempEstimateType = 'printbroker';
    document.getElementById("div_OutworkItems").focus();
}

function CloseOutworkItems() {
    document.getElementById("div_OutworkItems").style.display = "none";
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



function OtherCostSummaryPrevious() {
    document.getElementById(divOtherCost).style.display = "block";
    document.getElementById("div_stage_4").style.display = "none";
    document.getElementById(div_OtherCostSummary).style.display = "none";
    document.getElementById("lblheader").innerHTML = "Create Item";
}

function SiBoPaLaPrevious() {
    document.getElementById("div_stage_2").style.display = "block";
    document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "none";
    document.getElementById("div_stage_4").style.display = "none";
    document.getElementById("lblheader").innerHTML = "Create Item";
}


function CalculateBookletSection() {

    if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
        if (txtNoOfPagesInSection.value != '') {
            document.getElementById("spn_txtNoOfPagesInSection_divide").style.width = "185px";
            document.getElementById("spn_txtNoOfPagesInSection_divide").innerHTML = "Section must be divisible by 4. e.g 4, 8, 12 etc";
            document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "block";

            document.getElementById("spn_txtNoOfPagesInSection").style.display = "none";
        }

        return false;
    }
    else {
        document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
        var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
        if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
            txtNoOfSignatures.value = "0";
        }
        else {
            if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                txtNoOfSignatures.value = "1"
            }
            else {
                txtNoOfSignatures.value = parseInt(NoOfSignature, 0);
            }
        }
        return true;
    }

}


function CalculateBookletPages() {
    if (IsIntegerParameter(txtPagesPerSignature.value, 'spn_txtPagesPerSignatureNumber')) {
        if (Number(txtPagesPerSignature.value) % 2 != 0 || Number(txtPagesPerSignature.value) == 2 || Number(txtPagesPerSignature.value) == 0) {
            if (window.confirm('Selected layout is not valid for booklet\n Do you want to continue?')) {
                alert('Pages per print sheet must be divisible by 4.\n e.g 4,8,12 etc');
                txtPagesPerSignature.value = "4";
                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value)
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                    txtNoOfSignatures.value = "0";
                }
                else {
                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                        txtNoOfSignatures.value = "1"
                    }
                    else {
                        txtNoOfSignatures.value = parseInt(NoOfSignature, 0);
                    }
                }
            }
            return false;
        }
        else {
            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value)
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                txtNoOfSignatures.value = "0";
            }
            else {
                if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                    txtNoOfSignatures.value = "1"
                }
                else {
                    txtNoOfSignatures.value = parseInt(NoOfSignature, 0);
                }
            }
            return true;
        }
    }
}


function PricePrevious() {
    document.getElementById("div_stage_2").style.display = "block";
    div_price_catalogue.style.display = "none";
}
function PriceNext() {
    if (Price_Array.length > 0) {
        // temp document.getElementById("div_price_valid").style.display = "none";
        div_price_catalogue.style.display = "none";
        div_pricecatalogue_summary.style.display = "block";
        document.getElementById("div_stage_4").style.display = "block";
        BindCatalogueDesc();
    }
    else {
        //temp  document.getElementById("div_price_valid").style.display = "block";
    }

}
function PricePreviousStage4() {
    div_pricecatalogue_summary.style.display = "none";
    document.getElementById("div_stage_4").style.display = "none";
    div_price_catalogue.style.display = "block";
}

function CreateItemNext() {
    document.getElementById("div_none").style.display = "none";
    document.getElementById("spn_Label3").style.display = "none";
    document.getElementById("spn_Label4").style.display = "none";

    var spn_txtItemTitle = document.getElementById("spn_txtItemTitle");
    var spn_Label3 = document.getElementById("spn_Label3");

    if (txtItemTitle.value == '') {
        spn_txtItemTitle.style.display = "block";
    }
    if (ddlEstimateType.selectedIndex == 0) {
        spn_Label3.style.display = "block";
    }

    if (estimateType != '' && estimateType != null) {
        if (estimateType == 'digital' && productType != '') {
            if (productType == "singleitem") {
                if (CreateItemValidation()) {
                    if (ValidatePaper_HeightWidth()) {
                        StoreSections();
                        Load_Data_From_Stage1_To_Stage4("S"); ////Information to Next Step
                        //getOtherCostval();//to get othercost values
                        //document.getElementById("div_stage_2").style.display = "none";
                        document.getElementById("div_stage_4").style.display = "block";
                        document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "block";
                        document.getElementById("lblheader").innerHTML = "Customer Item Description";
                        document.getElementById(div_SingleItemSummary).style.display = "block";
                        BindSingleItemDesc(); //to bind Singleitem descripton  

                        //ReCalculateVariableQty();//for test remove after testing
                    }
                }
            }
            else if (productType == "booklet") {
                var IsItOk = true;
                IsItOk = CreateItemValidation();
                var IsBookletValid = true;
                if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                    IsBookletValid = false;
                    CalculateBookletSection();
                }
                if (IsItOk && IsBookletValid) {
                    if (ValidatePaper_HeightWidth()) {
                        var SectionRef = txtSectionRef.value;
                        var NoS = bookArr.length;
                        StoreSections();
                        GenerateSection();
                        for (var i = 0; i < bookArr.length; i++) {
                            if (SectionRef == bookArr[i].SectionRef) {
                                if (document.getElementById("btn_" + i + "") != null) {
                                    document.getElementById("btn_" + i + "").style.backgroundColor = "Orange";
                                    PresentSectionID = i;
                                }
                            }
                        }
                        //document.getElementById("div_stage_2").style.display = "none";
                        document.getElementById("div_stage_4").style.display = "block";
                        document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "block";
                        document.getElementById("lblheader").innerHTML = "Customer Item Description";
                        document.getElementById(div_BookletSummary).style.display = "block";
                        Load_Data_From_Stage1_To_Stage4("B");
                        BindBookletDesc(); //To Bind Booklet Item Description
                        if (RequestType == "add" || RequestType == "more") {
                            var desin = '';
                            for (var i = 0; i < bookArr.length; i++) {
                                if (i == bookArr.length - 1) {
                                    desin += bookArr[i].SectionRef;
                                }
                                else {
                                    desin += bookArr[i].SectionRef + ", ";
                                }
                            }
                            txtbookletDesign.value = desin;
                        }
                        document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
                    }
                }
            }
            else if (productType == "pads") {
                if (CreateItemValidation()) {
                    if (ValidatePaper_HeightWidth()) {
                        StoreSections(); //Store the values in Book Array
                        //document.getElementById("div_stage_2").style.display = "none";
                        document.getElementById("div_stage_4").style.display = "block";

                        Load_Data_From_Stage1_To_Stage4("P"); ////Information to Next Step
                        document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "block";
                        document.getElementById("lblheader").innerHTML = "Customer Item Description";
                        document.getElementById(div_PadSummary).style.display = "block";
                        BindPadsDesc(); //to bind Pad Item description
                    }
                }
            }

        }
        else if (estimateType == 'largeformat') {
            if (CreateItemValidation()) {
                if (ValidatePaper_HeightWidth()) {
                    StoreSections(); //Store the values in Book Array

                    Load_Data_From_Stage1_To_Stage4("L"); ////Information to Next Step

                    //document.getElementById("div_stage_2").style.display = "none";
                    document.getElementById("div_stage_4").style.display = "block";
                    document.getElementById(div_LargeFormatSummary).style.display = "block";
                    document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "block";

                    BindLargeFormatDesc(); //To bind Large Format item description
                }
            }
        }
        else if (estimateType == 'printbroker') {
            //BY VINAY 14/04/2010 ShowEstimate(estimateType);
        }
        else if (estimateType == 'warehouse') {
            ShowEstimate(estimateType);
        }
        else if (estimateType == 'othercost') {
            ShowEstimate(estimateType);
        }
        else if (estimateType == 'pricecatalogue') {
            ShowEstimate(estimateType);
            CallPriceCatalogueDiv();
        }
        else {
            //document.getElementById("div_none").innerHTML="Please select Product Type";
            document.getElementById("spn_Label3").style.display = "block";
        }
    }
}

function CallPriceCatalogueDiv() {

    div_price_catalogue.style.display = "block";

    if (hid_Price_CustomerID.value == '' || hid_Price_CustomerID.value != ClientID)//if(IsPriceLoaded==false)
    {

        IsPriceLoaded = true;
        if (RequestType == "add" || RequestType == "more") {
            //txtCatalogueItemTitleID.value = txtItemTitle.value;
        }

        hid_Price_CustomerID.value = ClientID;
        hid_Customer_Name.value = ClienName;


        document.getElementById("div_CatalogueHeader").style.display = "none";
        __doPostBack('ctl00$ContentPlaceHolder1$PriceCatalog$lnkLoadPriceCatalogue', '');

        takeIDofInterval = setInterval("CallAfter2sec()", 200);

    }
    //document.getElementById("div_stage_2").style.display = "none";
}

var IsPriceLoaded = false;
function ForSummary(obj) {

}
function ddlColors_Change(objValue) {
    var ColorValue = '';
    if (objValue == "color") {
        ColorValue = "Colour";
    }
    else {
        ColorValue = "Black & White";
    }
    if (estimateType == 'digital') {
        if (productType == 'singleitem') {
            txtSummaryColor.value = ColorValue;
        }
        else if (productType == 'booklet') {
            txtbookletColor.value = ColorValue;
        }
        else if (productType == 'pads') {
            txtPadColor.value = ColorValue;
        }
    }
    else if (estimateType == 'largeformat') {
        txtLargeColor.value = ColorValue;
    }
}
////BY VINAY On 23 / 02 / 2010
function Side2_block() {
    document.getElementById("spnSide1").style.display = "block";
    document.getElementById("div_side2").style.display = "block";
    ddlColors.style.width = "120px";
}
function Side2_none() {
    document.getElementById("spnSide1").style.display = "none";
    document.getElementById("div_side2").style.display = "none";
    ddlColors.style.width = "175px";
}
function showSides(IsChecked) {
    if (IsChecked) {
        Side2_block();
    }
    else {
        Side2_none();
    }
}

function Color_AssignToSummary() {
    var color = '';
    if (chkDoubleSided.checked) {
        color = "Side1: " + CheckDDLValues(ddlColors.value) + ", Side2: " + CheckDDLValues(ddlColors_2.value) + "";
    }
    else {
        color = "Single Sided Print: " + CheckDDLValues(ddlColors.value);
    }
    txtSummaryColor.value = color;
    txtbookletColor.value = color;
    txtPadColor.value = color;
    txtLargeColor.value = color;
}
function CheckDDLValues(values) {
    if (values == "color") {
        return "Colour";
    }
    else {
        return "Black & White";
    }
}
function ItemSize_AssignToSummary(Parameter) {
    var JobSizeText = '';
    if (ChkJobFlatCustom.checked && Parameter == null) {
        JobSizeText = "Height:" + txtitemheight.value + "mm; ";
        JobSizeText = JobSizeText + " Width:" + txtitemwidth.value + "mm;";
    }
    else if (ChkJobFlatCustom.checked && Parameter == "onblur") {
        JobSizeText = "Height:" + txtitemheight.value + "mm; ";
        JobSizeText = JobSizeText + " Width:" + txtitemwidth.value + "mm;";
    }
    else {
        JobSizeText = ddlJobItemSize.options[ddlJobItemSize.selectedIndex].text;
    }
    if (JobSizeText == "--- Select ---") {
        JobSizeText = "";
    }

    txtSummaryItemSize.value = JobSizeText;
    txtPadItemSize.value = JobSizeText;
    txtbookletSize.value = JobSizeText;
    txtLargeSize.value = JobSizeText;

}
function Paper_AssignToSummary() {
    var paperData = lblDefaultPaper.innerHTML;
    txtSingleMaterial.value = paperData;
    txtbookletMaterial.value = paperData;
    txtPadMaterial.value = paperData;
    txtLargeMaterial.value = paperData;
}

function Load_Data_From_Stage1_To_Stage4(Etype) {
    //=============== SUMMARY DATA UPDATE ===============================
    var qtycheck = "";
    if (QtyType.value == "S") {
        qtycheck = txtQuantity.value;
    }
    else if (QtyType.value == "R") {

        if (txtQuantity.value != "0" && txtQuantity.value != "") {
            qtycheck += txtQuantity.value + ", ";
        }
        if (txtRunOnQty.value != "0" && txtRunOnQty.value != "") {
            qtycheck += txtRunOnQty.value + " ";
        }
    }
    else if (QtyType.value == "M") {

        if (txtQuantity.value != "0" && txtQuantity.value != "") {
            qtycheck += txtQuantity.value + ", ";
        }
        if (txtQuantity_2.value != "0" && txtQuantity_2.value != "") {
            qtycheck += txtQuantity_2.value + ", ";
        }
        if (txtQuantity_3.value != "0" && txtQuantity_3.value != "") {
            qtycheck += txtQuantity_3.value + ", ";
        }
        if (txtQuantity_4.value != "0" && txtQuantity_4.value != "") {
            qtycheck += txtQuantity_4.value + " ";
        }
    }

    if (Etype == "S") {

    }
    else if (Etype == "B") {

    }
    else if (Etype == "P") {

    }
    else if (Etype == "L") {
        var quality = ddlQualitySector.options[ddlQualitySector.selectedIndex].text;
        var coverage = '';
        if (txtInkCoverageSide1.value != '') {
            coverage += "Side1: " + txtInkCoverageSide1.value + "% ";
        }
        if (txtInkCoverageSide2.value != '') {
            coverage += "Side2: " + txtInkCoverageSide2.value + "% ";
        }
    }

    //========================================================
}



function CreateItemPrevious(check) {
    if (check == "stage2") {
        document.getElementById("divStage1").style.display = "none";
        document.getElementById("divStage2").style.display = "block";
        document.getElementById("div_stage_2").style.display = "block";
        document.getElementById("lblheader").innerHTML = "Create Item";
    }
    else {
        document.getElementById("divStage1").style.display = "block";
        document.getElementById("divStage2").style.display = "none";
        document.getElementById("lblheader").innerHTML = "Create Estimate";
    }
}




function ShowEstimate(ddlValue, isany) {
    tempEstimateType = '';

    if (ddlEstimateType.selectedIndex == 0) {
        document.getElementById("spn_Label3").style.display = "block";
    }
    else {
        document.getElementById("spn_Label3").style.display = "none";
    }

    MadeDefault();         //make default as NONE
    MadeProductDefault();  //make default as NONE

    //ArrayOtherCost.length = 0;//Clear Othercost Array
    var reqtype = funreqtype();
    if (ddlValue == 'digital') {
        document.getElementById("lblheader").innerHTML = "Create Item: Digital Sheetfed ";
        if (isany == null) {
            document.getElementById(div_Product_Type).style.display = "block";
            //========= Loading of Digital Press ==============================================
            ddlPress.length = 0;
            var arr1 = hid_DigitalPress.value.split('µ');
            ddlPress.options.add(new Option("--- Select ---", "0", 0));
            for (var i = 0; i < arr1.length; i++) {
                if (arr1[i] != '') {
                    var arr2 = arr1[i].split('±');
                    ddlPress.options.add(new Option(arr2[1], arr2[0], i));
                }
            }
            ClaerSectionData(); //CLEAR DATA
            //To make defualt digi press selected//                                 
            if (reqtype == 'add' || reqtype == 'more') {
                if (hid_DefaultDigitalPress.value != '-1') {
                    for (var k = 0; k < ddlPress.length; k++) {
                        if (ddlPress.options[k].value == hid_DefaultDigitalPress.value) {
                            ddlPress.selectedIndex = k;
                        }
                    }
                    estimateType = ddlValue;
                    PressOnChange(ddlPress);
                    LoadCalculations(ddlPress.id);
                }
            }
            //========= Loading of Digital Press ENDS ==============================================

            var QueryType = funreqtype();
            if (QueryType == "add") {
                ProductTypeShow("singleitem");
                DdlProductType.selectedIndex = 0;
            }
            if (QueryType == "more") {
                ProductTypeShow("singleitem");
                DdlProductType.selectedIndex = 0;
            }
        }
    }
    else if (ddlValue == 'largeformat') {
        document.getElementById("lblheader").innerHTML = "Create Item: Large Format";
        if (isany == null) {
            //========= Loading of Large Format Press ==============================================
            ddlPress.length = 0;
            var arr1 = hid_LargeFormatPress.value.split('µ');
            ddlPress.options.add(new Option("--- Select ---", "0", 0));
            for (var i = 0; i < arr1.length; i++) {
                if (arr1[i] != '') {
                    var arr2 = arr1[i].split('±');
                    var Arr3 = arr2[0].split('»');
                    var Arr4 = arr2[1].split('»');
                    var PressName = '';
                    var PressID = '';
                    if (Arr3[0] == "PressID") {
                        PressID = Arr3[1];
                    }
                    if (Arr4[0] == "PressName") {
                        PressName = Arr4[1];
                    }
                    ddlPress.options.add(new Option(PressName, PressID, i));
                }
            }
            //========= Loading of Large Format Press ENDS ==============================================
            ClaerSectionData(); //CLEAR DATA
            //To make defualt large press selected//                 
            if (reqtype == 'add' || reqtype == 'more') {
                if (hid_DefaultLargePress.value != '-1') {
                    for (var k = 0; k < ddlPress.length; k++) {
                        if (ddlPress.options[k].value == hid_DefaultLargePress.value) {
                            ddlPress.selectedIndex = k;
                        }
                    }
                    estimateType = ddlValue;
                    PressOnChange(ddlPress);
                    LoadCalculations(ddlPress.id);
                }
            }
        }

        document.getElementById(div_chk_Run_OnQty).style.display = "none";
        document.getElementById(div_Finished_Qty).style.display = "block";
        document.getElementById(div_only_digitalsleft).style.display = "block";
        document.getElementById(div_only_digitalsright).style.display = "block";
        ////Print Quality Selector
        document.getElementById(div_Print_Quality_Sector).style.display = "block";
        document.getElementById(div_Ink_Coverage).style.display = "block";

        ddlProd.selectedIndex = '0';
        productType = '';
    }
    else if (ddlValue == 'printbroker') {
        IsPrintBrokerDirect = true;
        //document.getElementById("div_stage_2").style.display = "none";
        document.getElementById(print_broker).style.display = "block";
        document.getElementById("lblheader").innerHTML = "Supplier Request For Quote Item Description";
        ddlProd.selectedIndex = '0';
        productType = '';
        getPBItemTitle(txtItemTitle.value);

        if (RequestType == "add" || RequestType == "more") {
            Use_add_more();
        }
    }
    else if (ddlValue == 'warehouse') {
        document.getElementById("lblheader").innerHTML = "Create Item: Warehouse Item";
        IsWareDirect = true;
        //document.getElementById("div_stage_2").style.display = "none";
        document.getElementById(div_StockOnly).style.display = "block";
        document.getElementById(div_Ware_Next_Button).style.display = "block";
        ddlProd.selectedIndex = '0';
        productType = '';
        Call_Warehouse_Ind_fun("ware_1");
    }
    else if (ddlValue == 'othercost') {
        document.getElementById("lblheader").innerHTML = "Create Item: Other Cost";
        //ArrayOtherCost.length = 0;
        IsOtherCost = true;
        //document.getElementById("div_stage_2").style.display = "none";
        document.getElementById(divOtherCost).style.display = "block";
        document.getElementById(divOtherCostbtnNext).style.display = "block";
        btncostcentrePrevious.value = "Previous";
        ddlProd.selectedIndex = '0';
        productType = '';
        Create_Other_Cost_Tab('m'); //BY VINAY
    }
    else if (ddlValue == 'pricecatalogue') {
        document.getElementById("lblheader").innerHTML = "Create Item: Price Catalogue";
        ddlProd.selectedIndex = '0';
        CallPriceCatalogueDiv();
    }

    ////selected types       
    estimateType = ddlValue;
    if (ddlValue == '') {
        productType = '';
        estimateType = '';
    }
}


function MadeProductDefault() {
    document.getElementById(div_Finished_Qty).style.display = "none";
    document.getElementById(div_Booklet_Qty).style.display = "none";
    document.getElementById(div_Pads_Qty).style.display = "none";
    document.getElementById(div_Booklet_One).style.display = "none"; //booklet
    document.getElementById(div_Pads_One).style.display = "none"; //Pads
    document.getElementById(div_Print_Layout).style.display = "block"; //Print_Layout

    document.getElementById(div_BookletNoOfPagesInSection).style.display = "none"; //booklet
    document.getElementById(div_BookletNoOfSignatures).style.display = "none"; //booklet      
    document.getElementById(div_BookletFormat).style.display = "none"; //booklet  

    document.getElementById(div_Section_Ref).style.display = "none";
    document.getElementById(div_BtnNextSection).style.display = "none";
    document.getElementById(div_Booklet_Delete).style.display = "none";
    //MAKE ALL SUMMARY TO NONE
    AllSummaryNone();
}


function ProductTypeShow(ddlValue) {

    MadeProductDefault();
    ////Digital////
    document.getElementById(div_only_digitalsleft).style.display = "block";
    document.getElementById(div_only_digitalsright).style.display = "block";

    if (ddlValue == "singleitem") {
        document.getElementById(div_Finished_Qty).style.display = "block";
    }
    else if (ddlValue == "booklet") {
        document.getElementById(div_Section_Ref).style.display = "block";
        document.getElementById(div_Booklet_Qty).style.display = "block";
        document.getElementById(div_Booklet_One).style.display = "block";
        document.getElementById(div_Print_Layout).style.display = "none";

        document.getElementById(div_BookletNoOfPagesInSection).style.display = "block";
        document.getElementById(div_BookletNoOfSignatures).style.display = "block";
        document.getElementById(div_BookletFormat).style.display = "block";

        document.getElementById(div_BtnNextSection).style.display = "block";
        document.getElementById(div_Booklet_Delete).style.display = "block";

    }
    else if (ddlValue == "pads") {
        document.getElementById(div_Pads_Qty).style.display = "block";
        document.getElementById(div_Pads_One).style.display = "block";
    }
    else {
        document.getElementById(div_only_digitalsleft).style.display = "none";
        document.getElementById(div_only_digitalsright).style.display = "none";
    }

    productType = ddlValue;
    if (ddlValue == '') {
        productType = '';
    }
    //Please select Estimate Type
    document.getElementById("div_none").style.display = "none";
}


function moreQty(para1) {
    try {
        txtQuantity.focus();
        if (navigator.appName == "Microsoft Internet Explorer") {
            if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                var ieversion = new Number(RegExp.$1)
                if (ieversion >= 6) {
                    document.getElementById("div_RunOnQty").className = "absolutepos";
                    //document.getElementById("div_Addmore").className="absolutepos";
                }
                if (ieversion >= 7) {
                    document.getElementById("div_RunOnQty").className = "absolutepos7";
                    //document.getElementById("div_Addmore").className="absolutepos7";
                }
            }
        }
        else {
            if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                var ffversion = new Number(RegExp.$1);

                if (ffversion == 3) {
                    document.getElementById("div_RunOnQty").className = "absolutepos1ff";
                    //document.getElementById("div_Addmore").className="absolutepos1ff";
                }
                if (ffversion >= 3.5) {
                    document.getElementById("div_RunOnQty").className = "absolutepos1";
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

                document.getElementById("div_RunOnQty").style.display = "none";
                chkRunOnQty.checked = false;
            }
            else if (para1 == "runonqty") {
                document.getElementById(div_Qty2to4).style.display = "none"
                document.getElementById("div_Addmore").style.display = "none";
                if (chkRunOnQty.checked) {
                    document.getElementById("div_RunOnQty").style.display = "block";
                    hid_QtyType.value = "R";
                }
                else {
                    document.getElementById("div_RunOnQty").style.display = "none";
                    hid_QtyType.value = "S";
                }
            }
        }
        else {
            if (chkRunOnQty.checked) {
                chkRunOnQty.checked = false;
            }
        }
    }
    catch (err) {
    }
}


function AllSummaryNone() {
    document.getElementById(div_SingleItemSummary).style.display = "none";
    document.getElementById(div_BookletSummary).style.display = "none";
    document.getElementById(div_PadSummary).style.display = "none";
    document.getElementById(div_PrintBrokerSummary).style.display = "none";
    document.getElementById(div_OtherCostSummary).style.display = "none";
    document.getElementById(div_WarehouseSummary).style.display = "none";
    document.getElementById(div_LargeFormatSummary).style.display = "none";
    document.getElementById(div_PriceCatalogueSummary).style.display = "none";
}

function whenPageLoad() {
    //When Page Loads
    document.getElementById(div_Product_Type).style.display = "none";
    document.getElementById(div_only_digitalsleft).style.display = "none";
    document.getElementById(div_only_digitalsright).style.display = "none";

}

function WhenProductTypeEmpty() {
    ////Please select Estimate Type
    document.getElementById("div_none").style.display = "block";
    document.getElementById("span_none").innerHTML = "Please select Product Type";
}

function Is_Maximum_Booklet_Section() {
    //BY VINAY
    if (bookArr.length > 10) {
        alert('Maximum section in booklet is 10 only');
        return true;
    }
    else {
        return false;
    }
}

var bookArr = new Array();
var TakeCount = 0;
var CountSection = 1;
function MoveNextSection() {
    var IsItOk = true;
    IsItOk = CreateItemValidation();
    var IsBookletValid = true;

    if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
        IsBookletValid = false;
        CalculateBookletSection();
    }
    if (IsItOk && IsBookletValid) {
        if (ValidatePaper_HeightWidth()) {
            document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
            var NoS = bookArr.length;
            StoreSections();
            txtSectionRef.value = "New Section ";
            GenerateSection();
            ClaerSectionData();
            txtSectionRef.focus();
        }
    }
}

//Booklet Only
function CallRecalculateFun() {
    if (bookArr.length == 0) {
        hdn_PortraitValue.value = txtNoOfSignatures.value;
        ReCalculateVariableQty(); //to recalculate othercost variable hrsorqty
        //getOtherCostval();//to get othercost values
    }
}

function NewSection() {
    txtSectionRef.value = "New Section ";

    txtSectionRef.focus();
    if (bookArr.length == 0) {
        MakeDisable('no');
    }
}

function GenerateSection() {
    var data = '';
    for (var i = 0; i < bookArr.length; i++) {
        //data += " <div align='left'> ";
        data += " <div style='float: left;'>";
        data += " <input id='btn_" + i + "' onclick=LoadSectionValues(" + i + "); value='" + Number(i + 1) + "' type='button' class='button' style='width:20px;'  />";
        data += " </div>";
        data += " <div style='float:left;width:10px'>&nbsp;</div>";
        //data += " </div>";
        if (Number(i + 1) % 5 == 0) {
            data += "<div class='only5px'></div>";
        }
    }
    document.getElementById("div_btn_booklet_sections").innerHTML = data;
    MakeDisable('yes');
}

//Delete Sections one by one
var PresentSectionID;
function SectionDelete() {
    if (bookArr.length > 0) {
        bookArr.splice(PresentSectionID, 1);
        ClaerSectionData();
        GenerateSection();
        if (bookArr.length == 0) {
            MakeDisable('no');
        }
        PresentSectionID = null;
    }
    else {
        alert('Please select one section');
    }
}


var IsQtyDisabled = false;
function MakeDisable(type) {
    if (type == 'yes') {
        txtItemTitle.disabled = true;
        ddlEsti.disabled = true;
        ddlProd.disabled = true;
        txtQuantity.disabled = true;
        txtRunOnQty.disabled = true;
        txtQuantity_2.disabled = true;
        txtQuantity_3.disabled = true;
        txtQuantity_4.disabled = true;
        IsQtyDisabled = false; //// IsQtyDisabled=true;
    }
    else {
        txtItemTitle.disabled = false;
        ddlEsti.disabled = false;
        ddlProd.disabled = false;
        txtQuantity.disabled = false;
        txtRunOnQty.disabled = false;
        txtQuantity_2.disabled = false;
        txtQuantity_3.disabled = false;
        txtQuantity_4.disabled = false;
        IsQtyDisabled = false;
    }
}

function LoadSectionValues(nos) {
    for (var i = 0; i < bookArr.length; i++) {
        if (document.getElementById("btn_" + i + "") != null) {

            if (nos == i) {
                document.getElementById("btn_" + i + "").style.backgroundColor = "Orange";
            }
            else {
                document.getElementById("btn_" + i + "").style.backgroundColor = "";
                document.getElementById("btn_" + i + "").className = "button";
            }
        }
    }

    PresentSectionID = nos;
    if (nos == 0) {
        MakeDisable('no');
    }
    else {
        MakeDisable('yes');
    }

    //BY VINAY For Booklet Separate Qty
    //LoadBackQty(bookArr[nos].QuantityList);

    txtItemTitle.value = bookArr[nos].Title;
    //bookArr[nos].EstimateTyp = productType;
    txtSectionRef.value = bookArr[nos].SectionRef;
    txtQuantity.value = bookArr[nos].Quantity;


    for (var i = 0; i < ddlPress.length; i++) {
        if (bookArr[nos].PressID == ddlPress[i].value) {
            ddlPress.selectedIndex = i;
            //PressOnChange(ddlPress);
        }
    }

    hdnpaperID.value = bookArr[nos].PaperID;
    lblDefaultPaper.innerHTML = bookArr[nos].PaperName;
    ChkPriceForWholePack.checked = bookArr[nos].PriceForWhaolePack;
    ChkPaperSupplied.checked = bookArr[nos].PaperSupplied;
    txtSetupSpoilage.value = bookArr[nos].SetupSpoilage;
    txtRunningSpoilage.value = bookArr[nos].RunningSpoilage;
    txtNoOfPagesRequired.value = bookArr[nos].NoOfPagesRequired;
    txtPagesPerSection.value = bookArr[nos].PagesPerSection;
    ///var ddlColor = document.getElementById("<%=ddlColors.ClientID %>");//.value = bookArr[nos].Color;//DDL

    for (var i = 0; i < ddlColors.length; i++) {
        if (bookArr[nos].Color == ddlColors[i].value) {
            ddlColors.selectedIndex = i;
        }
    }

    chkDoubleSided.checked = bookArr[nos].IsDoubleSided;

    if (chkDoubleSided.checked) {
        for (var i = 0; i < ddlColors_2.length; i++) {
            if (bookArr[nos].SideColor == ddlColors_2[i].value) {
                ddlColors_2.selectedIndex = i;
            }
        }
        Side2_block();
    }
    else {
        Side2_none();
    }

    //var ddlPrintSheetSize = document.getElementById("<%=ddlPrintSheetSize.ClientID %>");//.value = bookArr[nos].PrintSheetSizeID;

    for (var i = 0; i < ddlPrintSheetSize.length; i++) {
        if (bookArr[nos].PrintSheetSizeID == ddlPrintSheetSize[i].value) {
            ddlPrintSheetSize.selectedIndex = i;
        }
    }
    chkPrintSheet.checked = bookArr[nos].IsPrintCustom;
    PrintSheetCustom(chkPrintSheet.id); //FUNCTION
    txtsectionheight.value = bookArr[nos].PrintSheetHeight;
    txtsectionwidth.value = bookArr[nos].PrintSheetWidth;

    ////var ddlJobItemSize = document.getElementById("<%=ddlJobItemSize.ClientID %>");//.value = bookArr[nos].JobFlatSizeID; ///DDL

    for (var i = 0; i < ddlJobItemSize.length; i++) {
        if (ddlJobItemSize[i].value == bookArr[nos].JobFlatSizeID) {
            ddlJobItemSize.selectedIndex = i;
        }
    }

    ChkJobFlatCustom.checked = bookArr[nos].IsJobCustom;
    JobItemCustom(ChkJobFlatCustom.id); //FUNCTION 
    txtitemheight.value = bookArr[nos].JobFlatSizeHeight;
    txtitemwidth.value = bookArr[nos].JobFlatSizeWidth;

    chkGutters.checked = bookArr[nos].IsIncludeGutters;
    GuttersCustom(chkGutters.id); //FUNCTION 
    txtGutterHorizontal.value = bookArr[nos].GutterHorizontal;
    txtGutterVertical.value = bookArr[nos].GutterVertical;
    ChkPressRestrictions.checked = bookArr[nos].IsPressRestrictions;
    hid_GuillotineID.value = bookArr[nos].GuilotineID;
    lblGuillotine.innerHTML = bookArr[nos].GuilotineName;
    ////new Development
    chkFirstTrim.checked = bookArr[nos].IsFirstTrim;
    chkSecondTrim.checked = bookArr[nos].IsSecondTrim;
    //booklet changes
    txtNoOfPagesInSection.value = bookArr[nos].NoOfPagesInSection;
    txtPagesPerSignature.value = bookArr[nos].PagesPerSignature;
    txtNoOfSignatures.value = bookArr[nos].NoOfSignatures;

    for (var i = 0; i < ddlBookletFormat.length; i++) {
        if (ddlBookletFormat[i].value == bookArr[nos].BookletFormat) {
            ddlBookletFormat.selectedIndex = i;
        }
    }

    CreateItemValidation(); //BY VINAY
    document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
}


function QuantityClass() {
    this.Quantity1 = '';
    this.Quantity2 = '';
    this.Quantity3 = '';
    this.Quantity4 = '';
    this.QtyType;
    this.EstBookletQty;
    this.EstBookletSectionID;
}

function ItemClass() {
    this.Title; this.EstimateTyp;
    this.SectionRef; this.Quantity;
    this.PressID; this.PaperName;
    this.PressType;
    this.PaperID;
    this.PaperName; this.PriceForWhaolePack;
    this.PaperSupplied; this.SetupSpoilage;
    this.RunningSpoilage; this.NoOfPagesRequired;
    this.PagesPerSection; this.Color;
    this.IsDoubleSided; this.PrintSheetSizeID;
    this.IsPrintCustom; this.PrintSheetHeight;
    this.PrintSheetWidth; this.JobFlatSizeID;
    this.IsJobCustom; this.JobFlatSizeHeight;
    this.JobFlatSizeWidth; this.IsIncludeGutters;
    this.GutterHorizontal; this.GutterVertical;
    this.IsPressRestrictions; this.GuilotineID;
    this.GuilotineName; this.IsFirstTrim;
    this.IsSecondTrim;
    //booklet new changes
    this.NoOfPagesInSection; this.PagesPerSignature;
    this.NoOfSignatures; this.BookletFormat;
    //Print Layout          
    this.PrintLayout;
    this.LandscapeValue; this.PortraitValue;
    this.QtyList;
    this.Qty1; this.Qty2;
    this.Qty3; this.Qty4;
    this.QuantityType;
    this.SideColor;
    this.QuantityList = [];
}

function LoadBackQty(obj) {
    var ObjArray = obj;
    for (var i = 0; i < ObjArray.length; i++) {
        var Qtype = hid_QtyType.value = ObjArray[0].QtyType;
        if (Qtype == "S") {
            txtQuantity.value = ObjArray[0].Quantity1;
            moreQty('single');
        }
        else if (Qtype == "R") {
            txtQuantity.value = ObjArray[0].Quantity1;
            txtRunOnQty.value = ObjArray[0].Quantity2;
            moreQty('runonqty');
        }
        else if (Qtype == "M") {
            txtQuantity.value = ObjArray[0].Quantity1;
            txtQuantity_2.value = ObjArray[0].Quantity2;
            txtQuantity_3.value = ObjArray[0].Quantity3 == null ? "" : ObjArray[0].Quantity3;
            txtQuantity_4.value = ObjArray[0].Quantity4 == null ? "" : ObjArray[0].Quantity4;
            document.getElementById(div_Qty2to4).style.display == "none";
            moreQty('more');
        }
    }
}

function SaveQtyToArray() {
    var qtyItem = new QuantityClass();
    var QType = qtyItem.QtyType = hid_QtyType.value;
    if (QType == "S") {
        qtyItem.Quantity1 = txtQuantity.value;
    }
    else if (QType == "R") {
        qtyItem.Quantity1 = txtQuantity.value;
        qtyItem.Quantity2 = txtRunOnQty.value;
    }
    else if (QType == "M") {
        qtyItem.Quantity1 = txtQuantity.value == "undefined" ? "" : txtQuantity.value;
        qtyItem.Quantity2 = txtQuantity_2.value == "undefined" ? "" : txtQuantity_2.value;
        qtyItem.Quantity3 = txtQuantity_3.value == "undefined" ? "" : txtQuantity_3.value;
        qtyItem.Quantity4 = txtQuantity_4.value == "undefined" ? "" : txtQuantity_4.value;
    }
    return qtyItem;
}

function StoreSections() {
    var bklItem = new ItemClass();

    //By VINAY Booklet Separate Qty
    ////bklItem.QuantityList[0] = SaveQtyToArray();

    bklItem.Title = txtItemTitle.value;
    bklItem.EstimateTyp = productType;
    bklItem.SectionRef = txtSectionRef.value;
    bklItem.Quantity = txtQuantity.value;
    bklItem.PressID = ddlPress.value;

    if (estimateType == "digital") {
        bklItem.PressType = "D";
    }
    else if (estimateType == "largeformat") {
        bklItem.PressType = "L";
    }

    bklItem.PaperID = hdnpaperID.value;
    bklItem.PaperName = lblDefaultPaper.innerHTML;
    bklItem.PriceForWhaolePack = ChkPriceForWholePack.checked;
    bklItem.PaperSupplied = ChkPaperSupplied.checked;
    bklItem.SetupSpoilage = txtSetupSpoilage.value;
    bklItem.RunningSpoilage = txtRunningSpoilage.value;
    bklItem.NoOfPagesRequired = txtNoOfPagesRequired.value;
    bklItem.PagesPerSection = txtPagesPerSection.value;
    bklItem.Color = ddlColors.value;
    bklItem.IsDoubleSided = chkDoubleSided.checked;
    bklItem.SideColor = chkDoubleSided.checked == true ? ddlColors_2.value : "";

    bklItem.PrintSheetSizeID = ddlPrintSheetSize.value;
    bklItem.IsPrintCustom = chkPrintSheet.checked;
    bklItem.PrintSheetHeight = txtsectionheight.value;
    bklItem.PrintSheetWidth = txtsectionwidth.value;

    bklItem.JobFlatSizeID = ddlJobItemSize.value;
    bklItem.IsJobCustom = ChkJobFlatCustom.checked;
    bklItem.JobFlatSizeHeight = txtitemheight.value;
    bklItem.JobFlatSizeWidth = txtitemwidth.value;

    bklItem.IsIncludeGutters = chkGutters.checked;
    bklItem.GutterHorizontal = txtGutterHorizontal.value;
    bklItem.GutterVertical = txtGutterVertical.value;

    bklItem.IsPressRestrictions = ChkPressRestrictions.checked;
    bklItem.GuilotineID = hid_GuillotineID.value;
    bklItem.GuilotineName = lblGuillotine.innerHTML;
    //new development
    bklItem.IsFirstTrim = chkFirstTrim.checked;
    bklItem.IsSecondTrim = chkSecondTrim.checked;

    //booklet changes
    bklItem.NoOfPagesInSection = txtNoOfPagesInSection.value;
    bklItem.PagesPerSignature = txtPagesPerSignature.value;
    bklItem.NoOfSignatures = txtNoOfSignatures.value;
    bklItem.BookletFormat = ddlBookletFormat.value;

    //hdn_LandscapeValue.value = bklItem.NoOfSignatures;            

    //Print layout
    if (chkPortrait.checked) {
        bklItem.PrintLayout = "P";
    }
    else {
        bklItem.PrintLayout = "L";
    }
    bklItem.LandscapeValue = txtlandscape.value;
    bklItem.PortraitValue = txtportrait.value;
    hdn_LandscapeValue.value = bklItem.LandscapeValue;
    hdn_PortraitValue.value = bklItem.PortraitValue;

    //by vinay new deveolpment                        
    if (PresentSectionID != null) {
        bookArr.splice(PresentSectionID, 1, bklItem);
        PresentSectionID = null;
    }
    else {
        bookArr.push(bklItem);
    }
}


function ClaerSectionData() {

    ddlPress.selectedIndex = 0;
    PressOnChange(ddlPress);

    ChkPriceForWholePack.checked = false;
    ChkPaperSupplied.checked = false;
    txtSetupSpoilage.value = '';
    txtRunningSpoilage.value = '';
    txtNoOfPagesRequired.value = '';
    txtPagesPerSection.value = '';
    ddlColors.selectedIndex = 0;
    chkDoubleSided.checked = false;
    Side2_none();

    chkGutters.checked = false;
    GuttersCustom(chkGutters.id);
    txtGutterHorizontal.value = '';
    txtGutterVertical.value = '';
    ChkPressRestrictions.checked = true;
    hid_GuillotineID.value = '';
    lblGuillotine.value = '';
    chkFirstTrim.checked = true;
    chkSecondTrim.checked = true;
    //booklet changes
    txtNoOfPagesInSection.value = '';
    txtPagesPerSignature.value = '';
    txtNoOfSignatures.value = '';
    ddlBookletFormat.selectedIndex = 0;
    chkPortrait.checked = false;
    chkLandscape.checked = false;
    txtportrait.value = '';
    txtlandscape.value = '';

}


function CreateItemValidation() {
    var IsCorrect = true;
    if (CheckStringMandatory(txtItemTitle.value, 'spn_txtItemTitle')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtSectionRef.value, 'spn_txtSectionRef')) {
        IsCorrect = false;
    }
    if (CheckReqCompare(txtQuantity.value, 'spn_txtQuantity', 'spn_txtQuantity_number')) {
        IsCorrect = false;
    }
    if (CallonChange(ddlPress.value, 'spn_ddlPress')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblDefaultPaper.innerHTML, 'spn_lblDefaultPaper')) {
        IsCorrect = false;
    }
    if (ddlEsti.value == "largeformat") {
        if (!CheckReqDecimal(txtSetupSpoilage.value, 'spn_txtSetupSpoilage', 'spn_txtSetupSpoilage_number')) {
            IsCorrect = false;
        }
    }
    else {
        if (CheckReqCompare(txtSetupSpoilage.value, 'spn_txtSetupSpoilage', 'spn_txtSetupSpoilage_number')) {
            IsCorrect = false;
        }
    }
    if (CheckReqCompare(txtRunningSpoilage.value, 'spn_txtRunningSpoilage', 'spn_txtRunningSpoilage_number')) {
        IsCorrect = false;
    }
    if (productType == 'booklet') {
        if (CheckReqCompare(txtNoOfPagesInSection.value, 'spn_txtNoOfPagesInSection', 'spn_txtNoOfPagesInSection_number')) {
            IsCorrect = false;
        }
        /*if(CheckReqCompare(txtPagesPerSection.value,'spn_txtPagesPerSection','spn_txtPagesPerSection_number'))
        {
        IsCorrect = false;
        }
        */
    }
    else if (productType == 'pads') {
        if (CheckReqCompare(txtNoOfLeavesPerPad.value, 'spn_txtNoOfLeavesPerPad', 'spn_txtNoOfLeavesPerPad_number')) {
            IsCorrect = false;
        }
    }
    else if (estimateType == "largeformat") {
        if (CallonChange(ddlQualitySector.value, 'spn_ddlQualitySector')) {
            IsCorrect = false;
        }
        if (CheckReqCompare(txtInkCoverageSide1.value, 'spn_txtInkCoverageSide1_number', 'spn_txtInkCoverageSide1_number')) {
            IsCorrect = false;
        }
        else if (CheckReqCompare(txtInkCoverageSide2.value, 'spn_txtInkCoverageSide1_number', 'spn_txtInkCoverageSide1_number')) {
            IsCorrect = false;
        }
    }
    if (CallonChange(ddlColors.value, 'spn_ddlColors')) {
        IsCorrect = false;
    }
    if (CallonChange(ddlPrintSheetSize.value, 'spn_ddlPrintSheetSize')) {
        IsCorrect = false;
    }
    if (CallonChange(ddlJobItemSize.value, 'spn_ddlJobItemSize')) {
        IsCorrect = false;
    }
    if (CheckReqCompare(txtGutterHorizontal.value, 'spn_txtGutterHorizontal_number', 'spn_txtGutterHorizontal_number')) {
        IsCorrect = false;
    }
    if (CheckReqCompare(txtGutterVertical.value, 'spn_txtGutterHorizontal_number', 'spn_txtGutterHorizontal_number')) {
        IsCorrect = false;
    }

    if (IsCorrect) {
        return true;
    }
    else {
        return false;
    }
}

function Calculations() {
    CalculateLandscape();
    CalculatePortrait();

    lblPortraitLength.innerHTML = "";
    lblLandscapeLength.innerHTML = "";

    if (result_port.value > result_land.value) {
        chkPortrait.checked = true;
        chkLandscape.checked = false;

        if (spnPaperType.innerHTML == "meter(s)") {
            if (PortraitLength != "Infinity") {
                lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " mm";
            }
        }
        else {
            lblPortraitLength.innerHTML = "";
        }
    }
    else {
        chkPortrait.checked = false;
        chkLandscape.checked = true;
        if (spnPaperType.innerHTML == "meter(s)") {
            if (LandscapeLength != "Infinity") {
                lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " mm";
            }
        }
        else {
            lblLandscapeLength.innerHTML = "";
        }
    }
}

function LoadCalculations(ddlid) {
    var DDl = document.getElementById(ddlid);
    if (DDl.selectedIndex != 0) {

        CalculateLandscape();
        CalculatePortrait();
        lblPortraitLength.innerHTML = "";
        lblLandscapeLength.innerHTML = "";
        if (Number(result_port.value) > Number(result_land.value)) {
            chkPortrait.checked = true;
            chkLandscape.checked = false;

            if (spnPaperType.innerHTML == "meter(s)") {
                if (PortraitLength != "Infinity") {
                    lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " mm";
                }
            }
            else {
                lblPortraitLength.innerHTML = "";
            }
        }
        else {
            chkPortrait.checked = false;
            chkLandscape.checked = true;
            if (spnPaperType.innerHTML == "meter(s)") {
                if (LandscapeLength != "Infinity") {
                    lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " mm";
                }
            }
            else {
                lblLandscapeLength.innerHTML = "";
            }


        }
    }
}

// BY M.S.VINAY FOR ROLL CALCULATION IN    
function RollCalculation(SheetWidth, SheetHeight, ItemWidth, ItemHeight, VGutter, HGutter, NonWidth, NonHeight, IsGutter, IsNonImage, IsFrom) {
    if (IsNonImage == false) {
        NonWidth = 0;
        NonHeight = 0;
    }
    if (IsGutter == false) {
        VGutter = 0;
        HGutter = 0;
    }
    var NewWidth = Number(NonWidth);
    var CountItems = 0;
    if (IsFrom == "landscape") {
        while (NewWidth < SheetWidth) {
            var TestWidth = Number(NewWidth) + Number(VGutter) + Number(ItemWidth);
            if (TestWidth < SheetWidth) {
                NewWidth = Number(TestWidth);
                CountItems++;
            }
            else {
                break;
            }
        }
        var NumberOfRow = Math.ceil(Number(txtQuantity.value) / Number(CountItems));
        var LengthOfOneItem = Number(HGutter) + Number(ItemHeight);
        RequiredLength = NumberOfRow * Number(LengthOfOneItem);
        if (isNaN(RequiredLength)) {

        }
        else {
            LandscapeLength = RequiredLength;
        }
    }
    else if (IsFrom == "portrait") {
        while (NewWidth < SheetWidth) {
            var TestWidth = Number(NewWidth) + Number(VGutter) + Number(ItemHeight);
            if (TestWidth < SheetWidth) {
                NewWidth = Number(TestWidth);
                CountItems++;
            }
            else {
                break;
            }
        }
        var NumberOfRow = Math.ceil(Number(txtQuantity.value) / Number(CountItems));
        var LengthOfOneItem = Number(HGutter) + Number(ItemWidth);
        RequiredLength = NumberOfRow * Number(LengthOfOneItem);
        if (isNaN(RequiredLength)) {

        }
        else {
            PortraitLength = RequiredLength;
        }
    }
}

function CalculateLandscape() {
    var Index = DdlProductType.selectedIndex;
    var FormatIndex = ddlFormat.selectedIndex;
    if ((chkGutters.checked) && (chkRestrictions.checked)) {
        hdnselected.value = "both";
        ASH = Number(SH.value) - (Number(NonHeight) * 2);
        ASW = Number(SW.value) - Number(NonWeight) * 2;

        A = Number(ASH) - Number(HrzGutter.value);
        B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));
        C = parseInt(B);

        if (DdlProductType.value == "booklet") {
            A = Number(ASH) + Number(HrzGutter.value);
            B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));

            A = parseInt(A);
            B = parseInt(B);
        }

        row = C;

        D = Number(ASW) - Number(VtGutter.value);
        E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));


        if (DdlProductType.value == "booklet") {
            D = Number(ASW) + Number(VtGutter.value);
            E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));

            D = parseInt(D);
            E = parseInt(E);
        }

        F = parseInt(E);
        col = F;

        Result = C * F;

        if (DdlProductType.value == "booklet") {
            Result = (C * F) * 2;
        }
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, true, "landscape");
    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";
        A = Number(SH.value) - Number(HrzGutter.value);
        B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));
        C = parseInt(B);
        row = C;
        var Z;
        if (DdlProductType.value == "booklet") {
            C = Number(Number(SH.value) + Number(HrzGutter.value)) / Number(Number(IH.value) + Number(HrzGutter.value));
            E = Number(Number(SW.value) + Number(VtGutter.value)) / Number(Number(IW.value) + Number(VtGutter.value));
            C = parseInt(C);
            E = parseInt(E);
            Z = E;
        }
        D = Number(SW.value) - Number(VtGutter.value);
        E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));
        F = parseInt(E);
        col = F;
        Result = C * F;
        if (DdlProductType.value == "booklet") {
            Result = (C * Z) * 2;
        }
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, false, "landscape");
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";

        ASH = Number(SH.value) - Number(NonHeight);
        ASW = Number(SW.value) - Number(NonWeight);
        A = Number(ASH) / Number(IH.value);
        B = Number(ASW) / Number(IW.value);
        row = parseInt(A);
        col = parseInt(B);
        Result = col * row;
        if (DdlProductType.value == "booklet") {
            Result = col * row * 2;
        }
        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, true, "landscape");

    }
    else {
        hdnselected.value = "none";
        A = Number(SH.value) / Number(IH.value);
        B = Number(SW.value) / Number(IW.value);

        if (DdlProductType.value == "booklet") {
            A = Number(SH.value) / Number(IH.value);
            B = Number(SW.value) / Number(IW.value); //*2);
            A = parseInt(A);
            B = parseInt(B);
        }

        C = parseInt(A); //Math.round(col_land)
        D = parseInt(B); //Math.round(row_land)

        row = C;
        col = D;
        if (DdlProductType.value == "booklet") {
            Result = (col * row) * 2;
        }
        else {
            Result = col * row;
        }

        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, false, "landscape");
    }

    row_land.value = row;

    col_land.value = col;

    if (DdlProductType.value == "booklet") {
        if (ddlFormat.value == "Landscape") {
            if (isNaN(Result)) {
                txtPagesPerSignature.value = "0";
                result_land.value = "0";
                txtNoOfSignatures.value = "0";
            }
            else {
                txtPagesPerSignature.value = parseInt(Result);
                result_land.value = Result;
                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(Result);
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                    txtNoOfSignatures.value = "0";
                }
                else {
                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                        txtNoOfSignatures.value = "1"
                    }
                    else {
                        txtNoOfSignatures.value = parseInt(NoOfSignature, 0);
                    }
                }
            }
        }
    }
    else {
        if (isNaN(Result)) {
            result_land.value = "0";
        }
        else {
            result_land.value = Result;
        }
    }
}


function CalculatePortrait() {
    var Index = DdlProductType.selectedIndex;
    var FormatIndex = ddlFormat.selectedIndex;
    if ((chkGutters.checked) && (chkRestrictions.checked)) {
        hdnselected.value = "both";

        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        Row_A1 = Number(Row_A1) - Number(HrzGutter.value);
        var Row_A2 = Number(IW.value) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        Col_B1 = Number(Col_B1) - Number(VtGutter.value);
        var Col_B2 = Number(IH.value) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;

        if (DdlProductType.value == "booklet") {
            Result = Number(Row_A) * Number(Col_B);
            Result = Number(Result) * 2;
        }

        row = Row_A;
        col = Col_B;

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, true, "portrait");
    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(HrzGutter.value);
        var Row_A2 = Number(IW.value) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(VtGutter.value);
        var Col_B2 = Number(IH.value) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;

        if (DdlProductType.value == "booklet") {
            Result = Number(Row_A) * Number(Col_B);
            Result = Number(Result) * 2;
        }

        row = Row_A;
        col = Col_B;

        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, false, "portrait");
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        var Row_A2 = Number(IW.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        var Col_B2 = Number(IH.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;

        if (DdlProductType.value == "booklet") {
            Result = Number(Row_A) * Number(Col_B);
            Result = Number(Result) * 2;
        }
        row = Row_A;
        col = Col_B;

        hdnhorizontal.value = "0";
        hdnvertical.value = "0";

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, true, "portrait");

    }
    else {
        hdnselected.value = "none";

        A = Number(SH.value) / Number(IW.value);
        B = Number(SW.value) / Number(IH.value);

        if (DdlProductType.value == "booklet") {
            A = Number(SH.value) / Number(IW.value);
            B = Number(SW.value) / Number(IH.value);
        }

        C = parseInt(A); //Math.round(col_port)
        D = parseInt(B); //Math.round(row_port)
        row = C;
        col = D;
        if (DdlProductType.value == "booklet") {
            Result = (row * col) * 2;
        }
        else {
            Result = row * col;
        }

        hdnhorizontal.value = "0";
        hdnvertical.value = "0";

        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, false, "portrait");
    }
    row_port.value = row;
    col_port.value = col;


    if (DdlProductType.value == "booklet") {
        if (ddlFormat.value == "Portrait") {
            if (isNaN(Result)) {
                txtPagesPerSignature.value = "0";
                result_port.value = "0";
                txtNoOfSignatures.value = "0";
            }
            else {
                txtPagesPerSignature.value = parseInt(Result);
                result_port.value = Result;

                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Result;
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                    txtNoOfSignatures.value = "0";
                }
                else {
                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                        txtNoOfSignatures.value = "1"
                    }
                    else {
                        txtNoOfSignatures.value = parseInt(NoOfSignature);
                    }
                }
            }
        }
    }
    else {
        if (isNaN(Result)) {
            result_port.value = "0";
        }
        else {
            result_port.value = Result;
            hdn_Protrait = Result;
        }
    }
}

function ShowCreateItemStage() {
    document.getElementById("divStage1").style.display = "none";
    document.getElementById("divStage2").style.display = "block";
    document.getElementById("div_stage_2").style.display = "block";
    document.getElementById("lblheader").innerHTML = "Create Item";
}

function EditOutwork() {
    var arr0 = hid_single_outworkData.value.split('µ'); //EstItemOutworkID µ EstItemOutworkID µ EstItemOutworkID

    for (var t = 0; t < arr0.length - 1; t++) {
        var arr1 = arr0[t].split('¤');
        //tb_EstItemOutwork ¤ tb_EstQuantity ¤ tb_EstItemOutworkRFQlabel ¤ tb_EstItemOutworkSupplier ¤ tb_EstItemOutworkSupplier
        var rfq = new RFQData(); //Class

        for (var i = 0; i < arr1.length; i++) {
            if (i == 0)//tb_EstItemOutwork
            {
                var arr2 = arr1[i].split('»');

                for (var j = 0; j < arr2.length; j++) {
                    var arr3 = arr2[j].split('=');
                    if (arr3[0] == "EstItemOutworkID" || arr3[0] == "EstOutworkID") {
                        rfq.EstOutworkID = arr3[1];
                    }
                    else if (arr3[0] == "EstimateType") {

                    }
                    else if (arr3[0] == "CostingType") {
                        rfq.CostingType = arr3[1];
                    }
                    else if (arr3[0] == "RFQReturnDate") {
                        rfq.RFQReturnDate = arr3[1];
                    }
                    else if (arr3[0] == "JobCompletionDate") {
                        rfq.JobCompletionDate = arr3[1];
                    }
                    else if (arr3[0] == "Header") {
                        rfq.Header = arr3[1];
                    }
                    else if (arr3[0] == "Footer") {
                        rfq.Footer = arr3[1];
                    }
                    else if (arr3[0] == "Artwork") {
                        rfq.ArtWork = arr3[1];
                    }
                }
            }
            else if (i == 1)//tb_EstQuantity
            {
                //M»56»1»200  ±  M»57»3»400
                var QtyType = '';
                var Qtys = '';
                var arr2 = arr1[i].split('±');
                for (var j = 0; j < arr2.length; j++) {
                    var arr3 = arr2[j].split('»');
                    QtyType = arr3[0];
                    Qtys += trim12(arr3[3]) + '|';
                }
                rfq.Quantity = Qtys;
                rfq.QtyType = QtyType;
            }
            else if (i == 2)//tb_EstItemOutworkRFQlabel
            {
                var arr2 = arr1[i].split('±');
                for (var j = 0; j < arr2.length; j++) {
                    var arr3 = arr2[j].split('»');

                    if (j == 0)     //Title
                    {
                        rfq.Title = arr3[0];
                        rfq.TitleDescription = arr3[1];
                        rfq.TitleIsChecked = arr3[2];
                    }
                    else if (j == 1)//Design
                    {
                        rfq.Origination = arr3[0];
                        rfq.OriginationDescription = arr3[1];
                        rfq.OriginationIsChecked = arr3[2];
                    }
                    else if (j == 2)//Artwork
                    {
                        rfq.Artwork = arr3[0];
                        rfq.ArtworkDescription = arr3[1];
                        rfq.ArtworkIsChecked = arr3[2];
                    }
                    else if (j == 3)//Color
                    {
                        rfq.Color = arr3[0];
                        rfq.ColorDescription = arr3[1];
                        rfq.ColorIsChecked = arr3[2];
                    }
                    else if (j == 4)//Size
                    {
                        rfq.Size = arr3[0];
                        rfq.SizeDescription = arr3[1];
                        rfq.SizeIsChecked = arr3[2];
                    }
                    else if (j == 5)//Material
                    {
                        rfq.Material = arr3[0];
                        rfq.MaterialDescription = arr3[1];
                        rfq.MaterialIsChecked = arr3[2];
                    }
                    else if (j == 6)//Finishing
                    {
                        rfq.Finishing = arr3[0];
                        rfq.FinishingDescription = arr3[1];
                        rfq.FinishingIsChecked = arr3[2];
                    }
                    else if (j == 7)//Delivery
                    {
                        rfq.Delivery = arr3[0];
                        rfq.DeliveryDescription = arr3[1];
                        rfq.DeliveryIsChecked = arr3[2];
                    }
                    else if (j == 8)//Notes
                    {
                        rfq.Notes = arr3[0];
                        rfq.NotesDescription = arr3[1];
                        rfq.NotesIsChecked = arr3[2];
                    }
                    else if (j == 9)//Terms
                    {
                        rfq.Terms = arr3[0];
                        rfq.TermsDescription = arr3[1];
                        rfq.TermsIsChecked = arr3[2];
                    }
                }
            }
            else if (i == 3)//tb_EstItemOutworkSupplier
            {
                var arr2 = arr1[i].split('±');
                for (var j = 0; j < arr2.length; j++) {
                    var arr3 = arr2[j].split('»');
                    var PriceComp = new PriceComparison(); //Class
                    for (var h = 0; h < arr3.length; h++) {
                        var arr4 = arr3[h].split('=');
                        if ("SupplierID" == arr4[0]) {
                            PriceComp.SupplierID = arr4[1];
                        }
                        else if ("SupplierContactID" == arr4[0]) {
                            PriceComp.SupplierContactID = arr4[1];
                        }
                        else if ("Quantity" == arr4[0]) {
                            PriceComp.Quantity = arr4[1];
                        }
                        else if ("Cost" == arr4[0]) {
                            PriceComp.Cost = arr4[1] == "" ? "" : parseFloat(arr4[1]).toFixed(2);
                        }
                        else if ("IsDeliveryIncluded" == arr4[0]) {
                            PriceComp.DeliveryIncluded = arr4[1];
                        }
                        else if ("DeliveryDate" == arr4[0]) {
                            PriceComp.DeliveryDate = arr4[1];
                        }
                        else if ("DeliveryCost" == arr4[0]) {
                            PriceComp.DeliveryCost = arr4[1] == "" ? "" : parseFloat(arr4[1]).toFixed(2);
                        }
                        else if ("MarkupType" == arr4[0]) {
                            PriceComp.MarkupType = arr4[1];
                        }
                        else if ("MarkupValue" == arr4[0]) {
                            PriceComp.MarkupValue = arr4[1];
                        }
                        else if ("TotalPrice" == arr4[0]) {
                            PriceComp.TotalPrice = arr4[1] == "" ? "" : parseFloat(arr4[1]).toFixed(2);
                        }
                        else if ("IsSelected" == arr4[0]) {
                            PriceComp.IsSelected = arr4[1];
                        }
                        else if ("IsEmailSent" == arr4[0]) {
                            PriceComp.IsMailSent = arr4[1];
                        }
                    }
                    rfq.PriceList[j] = PriceComp;
                }

            }
            else if (i == 4)//tb_EstItemOutworkSupplier for SUPPLIERID
            {

                var arr2 = arr1[i].split('±');
                for (var s = 0; s < arr2.length; s++) {
                    var arr3 = arr2[s].split('»');
                    var SupID = '';
                    var SupContactID = '';
                    for (var c = 0; c < arr3.length; c++) {
                        var arr4 = arr3[c].split('=');
                        if ("SupplierID" == trim12(arr4[0])) {
                            SupID = arr4[1];
                        }
                        else if ("SupplierContactID" == trim12(arr4[0])) {
                            SupContactID = arr4[1];
                        }
                    }
                    var supInfo = new SupplierInfo();
                    supInfo.SupplierID = SupID;
                    supInfo.ContactID = SupContactID;
                    rfq.SupplierList[s] = supInfo;
                }
            }
        }
        ArrayPrint.push(rfq);
    }
}


function EditWarehouse() {
    var arr0 = hid_ware_data.value.split('µ');
    for (var i = 0; i < arr0.length; i++) {
        var objWare = new wareClass();
        var arr1 = arr0[i].split('±');
        for (var j = 0; j < arr1.length; j++) {
            var arr2 = arr1[j].split('»');
            if ("WarehouseType" == arr2[0]) {
                objWare.WareType = arr2[1];
            }
            else if ("WarehouseTypeID" == arr2[0]) {
                objWare.ItemID = arr2[1];
            }
            else if ("Quantity" == arr2[0]) {
                objWare.Quantity = arr2[1];
            }
            else if ("WarehouseName" == arr2[0]) {
                objWare.ItemName = arr2[1];
            }
            else if ("UnitPrice" == arr2[0]) {
                objWare.WareValue = arr2[1]; //Unit Price
            }
            else if ("PackedInQty" == arr2[0]) {
                objWare.PackedInQty = arr2[1];
                objWare.IsDeleted = "0";
            }
        }
        warearray.push(objWare);
    }
    LoadEditedWare();
}

function OnlyForBooklet() {
    var GotoNextSection = false;
    var arr_0 = hid_bookletData.value.split('µ');
    for (var b = 0; b < arr_0.length; b++) {
        if (arr_0[b] != '') {
            var arr_1 = arr_0[b].split('±');
            for (var i = 0; i < arr_1.length; i++) {
                var arr_2 = arr_1[i].split('»');
                if (arr_2[0] == "EstimateType") {
                    for (j = 0; j < ddlEsti.length; j++) {
                        if (ddlEsti.options[j].value == arr_2[1]) {
                            ddlEsti.selectedIndex = j;
                            ShowEstimate(arr_2[1]);
                            ddlEsti.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "ProductType") {
                    for (j = 0; j < ddlProd.length; j++) {
                        if (ddlProd.options[j].value == arr_2[1]) {
                            ddlProd.selectedIndex = j;
                            ProductTypeShow(arr_2[1])
                            ddlProd.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "Qty") {
                    var qty_1 = arr_2[1].split('#');

                    for (var j = 0; j < qty_1.length; j++) {
                        var qty_2 = qty_1[j].split('$');
                        if (qty_2[0] == "M") {
                            div_Qty_2to4.style.display = "block";
                            div_Addmore.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty";
                            }
                            else {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty1";
                            }
                            hid_QtyType.value = "M";

                            if (qty_2[1] == "2") {
                                txtQuantity_2.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "R") {
                            div_RunOnQty.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                                    var ieversion = new Number(RegExp.$1)
                                    if (ieversion >= 6) {
                                        div_RunOnQty.className = "absolutepos";
                                    }
                                    if (ieversion >= 7) {
                                        div_RunOnQty.className = "absolutepos7";
                                    }
                                }
                            }
                            else {
                                if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                                    var ffversion = new Number(RegExp.$1);
                                    if (ffversion == 3) {
                                        div_RunOnQty.className = "absolutepos1ff";
                                    }
                                    if (ffversion >= 3.5) {
                                        div_RunOnQty.className = "absolutepos1";
                                    }
                                }
                            }
                            chkRunOnQty.checked = true;
                            hid_QtyType.value = "R";

                            if (qty_2[1] == "2") {
                                txtRunOnQty.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "S") {
                            hid_QtyType.value = "S";
                        }


                        if (qty_2[1] == "1") {
                            txtQuantity.value = qty_2[2];
                        }
                        if (qty_2[1] == "3") {
                            txtQuantity_3.value = qty_2[2];
                        }
                        if (qty_2[1] == "4") {
                            txtQuantity_4.value = qty_2[2];
                        }
                    }
                    //div_RunOnQty  
                }
                else if (arr_2[0] == "Press") {
                    for (j = 0; j < ddlPress.length; j++) {
                        if (ddlPress.options[j].value == arr_2[1]) {
                            ddlPress.selectedIndex = j;
                        }
                    }
                }
                else if (arr_2[0] == "Paper") {
                    hdnpaperID.value = arr_2[1];
                    lblDefaultPaper.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                    ChkPriceForWholePack.checked = arr_2[3] == "True" ? true : false;
                    ChkPaperSupplied.checked = arr_2[4] == "True" ? true : false;
                }
                else if (arr_2[0] == "SetupSpoilage") {
                    txtSetupSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "RunningSpoilage") {
                    txtRunningSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "Colour") {
                    for (j = 0; j < ddlColors.length; j++) {
                        if (ddlColors.options[j].value == arr_2[1]) {
                            ddlColors.selectedIndex = j;
                        }
                    }
                    chkDoubleSided.checked = arr_2[2] == "True" ? true : false;
                }
                else if (arr_2[0] == "SideColor") {
                    for (j = 0; j < ddlColors_2.length; j++) {
                        if (ddlColors_2.options[j].value == arr_2[1]) {
                            ddlColors_2.selectedIndex = j;
                            Side2_block();
                        }
                    }
                }
                else if (arr_2[0] == "QuantityList") {
                    var StrQtyData = arr_2[1].split('«');
                    hid_QtyType.value = StrQtyData[0];

                    if (StrQtyData[0] == "S") {
                        txtQuantity.value = StrQtyData[1];
                    }
                    else if (StrQtyData[0] == "R") {
                        txtQuantity.value = StrQtyData[1];
                        txtRunOnQty.value = StrQtyData[2];
                    }
                    else if (StrQtyData[0] == "M") {
                        txtQuantity.value = StrQtyData[1];
                        txtQuantity_2.value = StrQtyData[2];
                        txtQuantity_3.value = StrQtyData[3];
                        txtQuantity_4.value = StrQtyData[4];
                    }
                    if (txtQuantity.value == "undefined") {
                        txtQuantity.value = "";
                    }
                    if (txtQuantity_2.value == "undefined") {
                        txtQuantity_2.value = "";
                    }
                    if (txtQuantity_3.value == "undefined") {
                        txtQuantity_3.value = "";
                    }
                    if (txtQuantity_4.value == "undefined") {
                        txtQuantity_4.value = "";
                    }
                }
                else if (arr_2[0] == "SheetSize") {
                    for (j = 0; j < ddlPrintSheetSize.length; j++) {
                        if (ddlPrintSheetSize.options[j].value == arr_2[1]) {
                            ddlPrintSheetSize.selectedIndex = j;
                        }
                    }
                    LoadToSheetCustom(arr_2[1]);
                    chkPrintSheet.checked = arr_2[2] == "True" ? true : false;
                    txtsectionheight.value = arr_2[3];
                    txtsectionwidth.value = arr_2[4];
                }
                else if (arr_2[0] == "ItemSize") {
                    for (j = 0; j < ddlJobItemSize.length; j++) {
                        if (ddlJobItemSize.options[j].value == arr_2[1]) {
                            ddlJobItemSize.selectedIndex = j;
                        }
                    }
                    LoadToItemCustom(arr_2[1]);
                    ChkJobFlatCustom.checked = arr_2[2] == "True" ? true : false;
                    txtitemheight.value = arr_2[3];
                    txtitemwidth.value = arr_2[4];
                }
                else if (arr_2[0] == "Gutters") {
                    chkGutters.checked = arr_2[1] == "True" ? true : false;
                    txtGutterHorizontal.value = arr_2[2];
                    txtGutterVertical.value = arr_2[3];
                }
                else if (arr_2[0] == "PressRestrictions") {
                    ChkPressRestrictions.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "PrintLayout") {
                    chkPortrait.checked = arr_2[1] == "P" ? true : false;
                    chkLandscape.checked = arr_2[1] == "L" ? true : false;
                    txtportrait.value = arr_2[2];
                    txtlandscape.value = arr_2[3];
                    hdn_PortraitValue.value = arr_2[2];
                    hdn_LandscapeValue.value = arr_2[3];
                }
                else if (arr_2[0] == "Guillotine") {
                    hid_GuillotineID.value = arr_2[1];
                    lblGuillotine.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                }
                else if (arr_2[0] == "IsFirstTrim") {
                    chkFirstTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsSecondTrim") {
                    chkSecondTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsAnyWarehouse") {
                    if (arr_2[1] == "Y") {
                        //href_ShowOutwork.style.display="block";
                        IsAnyWarehouse = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOutwork") {
                    if (arr_2[1] == "Y") {
                        href_ShowOutwork.style.display = "block";
                        IsAnyOutWork = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOtherCost") {
                    if (arr_2[1] == "Y") {
                        IsAnyOtherCost = true;
                    }
                }
                else if (arr_2[0] == "NoOfPagesInSection") {
                    txtNoOfPagesInSection.value = arr_2[1];
                }
                else if (arr_2[0] == "PagesPerSignature") {
                    txtPagesPerSignature.value = arr_2[1];
                }
                else if (arr_2[0] == "NoOfSignatures") {
                    txtNoOfSignatures.value = arr_2[1];
                    hdn_PortraitValue.value = arr_2[1];
                }
                else if (arr_2[0] == "SectionReference") {
                    txtSectionRef.value = arr_2[1];
                }
                else if (arr_2[0] == "BookletFormat") {
                    ddlBookletFormat.value = arr_2[1] == "Portrait" ? "Portrait" : "Landscape";
                }
                else if (arr_2[0] == "RowCount") {
                    GotoNextSection = arr_2[1] > 1 ? true : false;
                }
            }

            MoveNextSection();
        }
    }
    LoadSectionValues("0");
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
}

function OtherCostFormula() {
    this.Formula = '';
    this.FormulaTag = '';
    this.Cost = '';
    this.Markup = '';
    this.SellingPrice = '';
    this.SectionNo = ''
}

function Create_Other_Cost_Tab(para) {
    var div_other_tab = document.getElementById("div_other_tab");

    if (div_other_tab.innerHTML != '') {
        HighlightTab('spncost_0');
        BindOtherCost(document.getElementById('spncost_0').id, para);
        return false;
    }
    PageMethods.GetOtherCost_Tab_List(CompanyID, function SuccessReturn(returnValue) {
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
            finalString += "<div align='left' style='white-space:normal;overflow:visible'>";
            finalString += "<li style='cursor: pointer; margin-right: 2px; float: left; clear: right;'>";
            finalString += "<div id='div13' nowrap='nowrap' style='height: 20px; padding: 0px 10px 0px 10px;float: left; line-height: 20px;'>";
            finalString += "<b><span id='spncost_" + i + "' class='lnkTabSelected' title='" + CostName + "' onclick='HighlightTab(this.id);'>" + LimitCostName + "</span><span id='spncostcatid_" + i + "' style='display:none'>" + str3[0] + "</span></b>";
            finalString += "</div>";
            finalString += "</li>";
            finalString += "</div>";
        }
        div_other_tab.innerHTML = finalString;
        HighlightTab('spncost_0');
        BindOtherCost(document.getElementById('spncost_0').id, para);
    }, other_error);

}
function other_error(error) { }

function BindOtherCostItems(OtherCostVal, CalculationType, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal) {
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
            if (trim12(propqty) == "Quantity") {
                itemqty.Quantity = valueqty;
            }
            if (trim12(propqty) == "Markup") {
                itemqty.Markup = valueqty;
            }
            if (trim12(propqty) == "SellingPrice") {
                itemqty.SellingPrice = valueqty;
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
            if (trim12(propform) == "SectionNo") {
                itemForm.SectionNo = valueform;
            }
        }
        item.OtherCostFormula = itemForm;
    }

    ArrayOtherCost.push(item);
    BindDivOtherCostStyle(ItemType, Mode);
}


function BindOtherCostOnEdit(OtherCostVal, CalculationType, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal) {
    var Other = ArrayOtherCost[OtherIndex].OtherCost;
    var checkhourqty = CheckHourQtyVal.split('±');


    var OtherCostValsplit = OtherCostVal.split('±');
    for (var L = 0; L < OtherCostValsplit.length; L++) {
        fff = OtherCostValsplit[L].split('»');
        if (trim12(fff[0]) == "Description") {
            ArrayOtherCost[OtherIndex].Description = trim12(fff[1]);
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
            if (trim12(propqty) == "Quantity") {
                OtherQty.Quantity = valueqty;
            }
            if (trim12(propqty) == "Markup") {
                OtherQty.Markup = valueqty;
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
        }
    }
    EditOtherPopupValues = '';
}


function ShowOtherCostItems(itemtype) {
    if (itemtype == 's') {
        document.getElementById("div_OtherCostSubItems").style.display = "block";
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
        document.getElementById("div_OtherCostSubItems").style.display = "none";
    }
    else if (itemtype == 'm') {
        document.getElementById("div_OtherCostItems").style.display = "none";
    }
    else if (itemtype == 'u') {
        document.getElementById("div_OtherCostMainItems").style.display = "none";
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


//****** END To Check Re-calculate Othercost VariableQty On Qty,Spoilage Change ****//
//***** To Recalculate Othercost Sellingprice *******//
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
//***** To Recalculate Othercost Sellingprice *******//


//============= Warehouse Starts =====================////
function ShowWarehouseItems() {
    if (document.getElementById('div_warehouseItems').style.display == "none") {
        document.getElementById('div_warehouseItems').style.display = "block";
    }
    else {
        document.getElementById('div_warehouseItems').style.display = "none";
    }
}
function WarehouseSummaryBack(sumType) {

    if (sumType == 'back') {
        document.getElementById(div_StockOnly).style.display = "block";
        document.getElementById("div_stage_4").style.display = "none";
        document.getElementById(div_WarehouseSummary).style.display = "none";
        document.getElementById("lblheader").innerHTML = "Create Item";
        document.getElementById("div_none").style.display = "none";
    }
    else {

        //        var wareCount = 0;
        //        for(var i=0;i<warearray.length;i++)
        //        {
        //            if(warearray[i].IsDeleted == 0)
        //            {
        //                wareCount++;
        //            }
        //        }
        //        alert(wareCount);  
        //        if (wareCount > 0) 
        //        {
        BindWarehouseDesc();
        document.getElementById("div_none").style.display = "none";
        document.getElementById(div_StockOnly).style.display = "none";
        document.getElementById("div_stage_4").style.display = "block";
        document.getElementById(div_WarehouseSummary).style.display = "block";
        document.getElementById("lblheader").innerHTML = "Customer Item Description";
        //To bind Item description Labels
        //        }
        //        else 
        //        {
        //            document.getElementById("div_none").style.display = "block";
        //            document.getElementById("span_none").innerHTML = "Please select at least one Warehouse Item";
        //        }
    }
}


function WarehousePrevious() {
    document.getElementById("div_none").style.display = "none";

    if (IsWareDirect) {
        document.getElementById("div_stage_2").style.display = "block";
        document.getElementById(div_StockOnly).style.display = "none";
    }
    else {
        document.getElementById("div_stage_2").style.display = "block";
        ShowEstimate(estimateType, 'ware');
        if (estimateType == "digital") {
            document.getElementById(div_Product_Type).style.display = "block";
            ProductTypeShow(productType);
        }
    }
}

var WareNu = '';
function ShowWarehouseEdit(type, nu, txtVal) {
    if (type == "open") {
        document.getElementById("div_ware_edit").style.display = "block";
        document.getElementById("txtWareQty").value = txtVal;
        WareNu = nu;
    }
    else if (type == "close") {
        document.getElementById("div_ware_edit").style.display = "none";
        WareNu = '';
    }
    else if (type == "update") {
        warearray[WareNu].Quantity = document.getElementById("txtWareQty").value;
        document.getElementById("div_ware_edit").style.display = "none";
        document.getElementById("txtWareQty").value = '';
        WareNu = '';
        if (estimateType == "warehouse") {
            LoadWareMainItemListOnEdit();
        }
        else {
            LoadEditedWare();
        }
    }
}

function LoadEditedWare() {
    var dd = '';
    for (var p = 0; p < warearray.length; p++) {
        var color1 = "#DADADA";
        if (p % 2 == 0) {
            color1 = "#FFFFFF";
        }
        dd += "<div id='" + warearray[p].ItemID + "' align='left' style='height:20px;background-color:" + color1 + "'>";
        var Wname = warearray[p].ItemName;
        var SWname = Wname.substring(0, 20) + '...';
        dd += "<div style='float:left;width:175px;overflow:hidden;'><span class='normaltext' title='" + warearray[p].ItemName + "'>" + SWname + "</span></div>";
        dd += "<div style='float:left;width:50px;'><a href='#' onclick=\"ShowWarehouseEdit('open'," + p + "," + warearray[p].Quantity + ");\">" + warearray[p].Quantity + "</a></div><div style='float:left;'>";
        dd += "<a href='#' onclick='RemoveWare(" + p + ");' class='normaltext'>Remove</a></div></div>";
    }
    document.getElementById("div_ware_add").innerHTML = dd;
    document.getElementById("href_showware").style.display = "block";
}

function BindWareMainItemOnEdit() {
    var arr0 = hid_ware_data.value.split('µ');

    for (var i = 0; i < arr0.length - 1; i++) {
        var objWare = new wareClass();
        var arr1 = arr0[i].split('±');
        for (var j = 0; j < arr1.length; j++) {
            var arr2 = arr1[j].split('»');
            if ("WarehouseType" == arr2[0]) {
                objWare.WareType = arr2[1];
            }
            else if ("WarehouseTypeID" == arr2[0]) {
                objWare.ItemID = arr2[1];
            }
            else if ("Quantity" == arr2[0]) {
                objWare.Quantity = arr2[1];
            }
            else if ("WarehouseName" == arr2[0]) {
                objWare.ItemName = arr2[1];
            }
            else if ("UnitPrice" == arr2[0]) {
                objWare.WareValue = arr2[1]; //Unit Price
            }
            else if ("WarehouseItemID" == arr2[0]) {
                objWare.WareItemID = arr2[1]; //Unit Price
            }
            else if ("PackedInQty" == arr2[0]) {
                objWare.PackedInQty = arr2[1]; //Unit Price
                objWare.IsDeleted = "0";
            }
        }

        warearray.push(objWare);
    }
    //To Show the Warehouse List //
    LoadWareMainItemListOnEdit();
}

function LoadWareMainItemListOnEdit() {
    var dd = '';
    for (var p = 0; p < warearray.length; p++) {
        if (warearray[p].IsDeleted == 0) {
            var color1 = "#DADADA";
            if (p % 2 == 0) {
                color1 = "#EFEFEF";
            }
            dd += "<div id='" + warearray[p].ItemID + "' align='left' style='height:20px;background-color:" + color1 + "'>";
            var Wname = warearray[p].ItemName;
            dd += "<div style='float:left;width:175px;overflow:hidden;'>" + Wname + "</div>";
            dd += "<div style='float:left;width:50px;'><a href='#' onclick=\"ShowWarehouseEdit('open'," + p + "," + warearray[p].Quantity + ");\">" + warearray[p].Quantity + "</a></div><div style='float:left;'>";
            dd += "<a href='#' onclick='RemoveWare(" + p + ");' class='normaltext'>Remove</a></div></div>";
        }
    }
    document.getElementById("div_ware_MainItemadd").innerHTML = dd;
    document.getElementById("href_showware_MainItem").style.display = "block";
}

function TakeValuesFromDB() {
    var arr_0 = hid_singleData.value.split('µ');
    for (var b = 0; b < arr_0.length; b++) {
        if (arr_0[b] != '') {
            var arr_1 = arr_0[b].split('±');
            for (var i = 0; i < arr_1.length; i++) {
                var arr_2 = arr_1[i].split('»');
                if (arr_2[0] == "EstimateType") {
                    for (j = 0; j < ddlEsti.length; j++) {
                        if (ddlEsti.options[j].value == arr_2[1]) {
                            ddlEsti.selectedIndex = j;
                            ShowEstimate(arr_2[1]);
                            ddlEsti.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "ProductType") {
                    for (j = 0; j < ddlProd.length; j++) {
                        if (ddlProd.options[j].value == arr_2[1]) {
                            ddlProd.selectedIndex = j;
                            ProductTypeShow(arr_2[1])
                            ddlProd.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "Qty") {
                    var qty_1 = arr_2[1].split('#');
                    for (var j = 0; j < qty_1.length; j++) {
                        var qty_2 = qty_1[j].split('$');
                        if (qty_2[0] == "M") {
                            div_Qty_2to4.style.display = "block";
                            div_Addmore.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty";
                                //                                    if (/MSIE (\d+\.\d+);/.test(navigator.userAgent))
                                //                                   {
                                //                                     var ieversion=new Number(RegExp.$1)
                                //                                     if(ieversion >= 6)
                                //                                     {
                                //                                      div_Addmore.className="absolutepos";
                                //                                     }
                                //                                     if(ieversion >= 7)
                                //                                     {
                                //                                      div_Addmore.className="absolutepos7";
                                //                                     }
                                //                                   }
                            }
                            else {
                                //                                 if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent))
                                //                                  {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty1";
                                //                                     var ffversion=new Number(RegExp.$1);
                                //                                     if(ffversion ==3)
                                //                                     {
                                //                                      div_Addmore.className="absolutepos1ff";
                                //                                     }
                                //                                     if(ffversion >= 3.5)
                                //                                     {
                                //                                      div_Addmore.className="absolutepos1";
                                //                                     }
                                //                                  }
                            }
                            hid_QtyType.value = "M";

                            if (qty_2[1] == "2") {
                                txtQuantity_2.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "R") {
                            div_RunOnQty.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                                    var ieversion = new Number(RegExp.$1)
                                    if (ieversion >= 6) {
                                        div_RunOnQty.className = "absolutepos";
                                    }
                                    if (ieversion >= 7) {
                                        div_RunOnQty.className = "absolutepos7";
                                    }
                                }
                            }
                            else {
                                if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                                    var ffversion = new Number(RegExp.$1);
                                    if (ffversion == 3) {
                                        div_RunOnQty.className = "absolutepos1ff";
                                    }
                                    if (ffversion >= 3.5) {
                                        div_RunOnQty.className = "absolutepos1";
                                    }
                                }
                            }
                            chkRunOnQty.checked = true;
                            hid_QtyType.value = "R";

                            if (qty_2[1] == "2") {
                                txtRunOnQty.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "S") {
                            hid_QtyType.value = "S";
                        }
                        if (qty_2[1] == "1") {
                            txtQuantity.value = qty_2[2];
                        }
                        if (qty_2[1] == "3") {
                            txtQuantity_3.value = qty_2[2];
                        }
                        if (qty_2[1] == "4") {
                            txtQuantity_4.value = qty_2[2];
                        }

                    }
                    //div_RunOnQty  
                }
                else if (arr_2[0] == "Press") {
                    for (j = 0; j < ddlPress.length; j++) {
                        if (ddlPress.options[j].value == arr_2[1]) {
                            ddlPress.selectedIndex = j;
                        }
                    }
                }
                else if (arr_2[0] == "Paper") {
                    hdnpaperID.value = arr_2[1];
                    ////lblDefaultPaper.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0,23)+"..." : arr_2[2];                
                    lblDefaultPaper.innerHTML = arr_2[2];
                    lblDefaultPaper.title = arr_2[2];
                    ChkPriceForWholePack.checked = arr_2[3] == "True" ? true : false;
                    ChkPaperSupplied.checked = arr_2[4] == "True" ? true : false;
                }
                else if (arr_2[0] == "SetupSpoilage") {
                    txtSetupSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "RunningSpoilage") {
                    txtRunningSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "Colour") {
                    for (j = 0; j < ddlColors.length; j++) {
                        if (ddlColors.options[j].value == arr_2[1]) {
                            ddlColors.selectedIndex = j;
                        }
                    }
                    chkDoubleSided.checked = arr_2[2] == "True" ? true : false;
                }
                else if (arr_2[0] == "SheetSize") {
                    for (j = 0; j < ddlPrintSheetSize.length; j++) {
                        if (ddlPrintSheetSize.options[j].value == arr_2[1]) {
                            ddlPrintSheetSize.selectedIndex = j;
                        }
                    }
                    LoadToSheetCustom(arr_2[1]);
                    chkPrintSheet.checked = arr_2[2] == "True" ? true : false;
                    txtsectionheight.value = arr_2[3];
                    txtsectionwidth.value = arr_2[4];
                    PrintSheetCustom(chkPrintSheet.id);
                }
                else if (arr_2[0] == "ItemSize") {
                    for (j = 0; j < ddlJobItemSize.length; j++) {
                        if (ddlJobItemSize.options[j].value == arr_2[1]) {
                            ddlJobItemSize.selectedIndex = j;
                        }
                    }
                    LoadToItemCustom(arr_2[1]);
                    ChkJobFlatCustom.checked = arr_2[2] == "True" ? true : false;
                    txtitemheight.value = arr_2[3];
                    txtitemwidth.value = arr_2[4];
                    JobItemCustom(ChkJobFlatCustom.id);
                }
                else if (arr_2[0] == "Gutters") {
                    chkGutters.checked = arr_2[1] == "True" ? true : false;
                    txtGutterHorizontal.value = arr_2[2];
                    txtGutterVertical.value = arr_2[3];
                    GuttersCustom(chkGutters.id);
                }
                else if (arr_2[0] == "PressRestrictions") {
                    ChkPressRestrictions.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "PrintLayout") {
                    chkPortrait.checked = arr_2[1] == "P" ? true : false;
                    chkLandscape.checked = arr_2[1] == "L" ? true : false;
                    txtportrait.value = arr_2[2];
                    txtlandscape.value = arr_2[3];
                    hdn_PortraitValue.value = arr_2[2];
                    hdn_LandscapeValue.value = arr_2[3];
                }
                else if (arr_2[0] == "Guillotine") {
                    hid_GuillotineID.value = arr_2[1];
                    lblGuillotine.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                }
                else if (arr_2[0] == "IsFirstTrim") {
                    chkFirstTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsSecondTrim") {
                    chkSecondTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "SideColor") {
                    for (j = 0; j < ddlColors_2.length; j++) {
                        if (ddlColors_2.options[j].value == arr_2[1]) {
                            ddlColors_2.selectedIndex = j;
                            Side2_block();
                        }
                    }
                }
                else if (arr_2[0] == "IsAnyWarehouse") {
                    if (arr_2[1] == "Y") {
                        //href_ShowOutwork.style.display="block";
                        IsAnyWarehouse = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOutwork") {
                    if (arr_2[1] == "Y") {
                        href_ShowOutwork.style.display = "block";
                        IsAnyOutWork = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOtherCost") {
                    if (arr_2[1] == "Y") {
                        href_ShowOtherCostSubItem.style.display = "block";
                        IsAnyOtherCost = true;
                    }
                }
                else if (arr_2[0] == "NoOfPagesInSection") {
                    txtNoOfPagesInSection.value = arr_2[1];
                }
                else if (arr_2[0] == "PagesPerSignature") {
                    txtPagesPerSignature.value = arr_2[1];
                }
                else if (arr_2[0] == "NoOfSignatures") {
                    txtNoOfSignatures.value = arr_2[1];
                    hdn_PortraitValue.value = arr_2[1];
                }
                else if (arr_2[0] == "SectionReference") {
                    txtSectionRef.value = arr_2[1];
                }
                else if (arr_2[0] == "PaperType") {
                    if (arr_2[1] == "web printing") {
                        ForWebPrinting("yes");
                    }
                }
                else if (arr_2[0] == "PressPaperType") {
                    if (arr_2[1] == "meters") {
                        spnPaperType.innerHTML = "meter(s)";
                    }
                    else {
                        spnPaperType.innerHTML = "sheet(s)";
                    }
                }

            }
        }
    }

}
function ForWebPrinting(type) {
    if (type == "yes") {
        document.getElementById("div_ddlPrintSheetSize").style.display = "none";
        document.getElementById("div_PrintSheetCustomSize").style.display = "block";
        document.getElementById("div_chkPrintSheet").style.display = "none";
        document.getElementById("spn_sheet_height").innerHTML = "Length";
        txtsectionheight.maxLength = 9;
        txtsectionwidth.maxLength = 9;
        txtitemheight.maxLength = 9;
        txtitemwidth.maxLength = 9;
        txtGutterHorizontal.maxLength = 9;
        txtGutterVertical.maxLength = 9;
        //------------------------------
        txtsectionheight.style.width = "55px";
        txtsectionwidth.style.width = "55px";
        txtitemheight.style.width = "55px";
        txtitemwidth.style.width = "55px";
        txtGutterHorizontal.style.width = "55px";
        txtGutterVertical.style.width = "55px";
    }
    else {
        document.getElementById("div_ddlPrintSheetSize").style.display = "block";
        document.getElementById("div_PrintSheetCustomSize").style.display = "none";
        document.getElementById("div_chkPrintSheet").style.display = "block";
        document.getElementById("spn_sheet_height").innerHTML = "Height";
        txtsectionheight.maxLength = 3;
        txtsectionwidth.maxLength = 3;
        txtitemheight.maxLength = 3;
        txtitemwidth.maxLength = 3;
        txtGutterHorizontal.maxLength = 3;
        txtGutterVertical.maxLength = 3;
        //------------------------------
        txtsectionheight.style.width = "55px";
        txtsectionwidth.style.width = "55px";
        txtitemheight.style.width = "55px";
        txtitemwidth.style.width = "55px";
        txtGutterHorizontal.style.width = "55px";
        txtGutterVertical.style.width = "55px";
    }
}

//********* FOR MAIN PRINT BROKER **********************
function PBItemTitleData(ObjValue) {
    txtTitleDescription.value = ObjValue;
    txtPBItemTitle.value = ObjValue;
}
function PBDesignData(ObjValue) {
    txtOriginationDescription.value = ObjValue;
    txtPBDesign.value = ObjValue;
}
function PBArtworkData(ObjValue) {
    txtArtworkDescription.value = ObjValue;
    txtPBArtwork.value = ObjValue;
}
function PBColourData(ObjValue) {
    txtColorDescription.value = ObjValue;
    txtPBColour.value = ObjValue;
}
function PBSizeData(ObjValue) {
    txtSizeDescription.value = ObjValue;
    txtPBSize.value = ObjValue;
}
function PBMaterialsData(ObjValue) {
    txtMaterialDescription.value = ObjValue;
    txtPBMaterials.value = ObjValue;
}
function PBDeliveryData(ObjValue) {
    txtDeliveryDescription.value = ObjValue;
    txtPBDelivery.value = ObjValue;
}
function PBFinishingData(ObjValue) {
    txtFinishingDescription.value = ObjValue;
    txtPBFinishing.value = ObjValue;
}
function PBNotesData(ObjValue) {
    txtNotesDescription.value = ObjValue;
    txtPBNotes.value = ObjValue;
}
function PBInstructionsData(ObjValue) {
    txtTermsDescription.value = ObjValue;
    txtPBInstructions.value = ObjValue;
}
//LABEL CROSS FLOW

function lblPBItemTitleData(ObjValue) {
    txtTitle.value = ObjValue;
    txt_lblPBItemTitle.value = ObjValue;
}
function lblPBDescriptionData(ObjValue) {
    txtOrigination.value = ObjValue;
    txt_lblPBDescription.value = ObjValue;
}
function lblPBArtworkData(ObjValue) {
    txtArtwork.value = ObjValue;
    txt_lblPBArtwork.value = ObjValue;
}
function lblPBColourData(ObjValue) {
    txtColor.value = ObjValue;
    txt_lblPBColour.value = ObjValue;
}
function lblPBSizeData(ObjValue) {
    txtSize.value = ObjValue;
    txt_lblPBSize.value = ObjValue;
}
function lblPBMaterialsData(ObjValue) {
    txtMaterial.value = ObjValue;
    txt_lblPBMaterials.value = ObjValue;
}
function lblPBDeliveryData(ObjValue) {
    txtDelivery.value = ObjValue;
    txt_lblPBDelivery.value = ObjValue;
}
function lblPBFinishingData(ObjValue) {
    txtFinishing.value = ObjValue;
    txt_lblPBFinishing.value = ObjValue;
}
function lblPBNotesData(ObjValue) {
    txtNotes.value = ObjValue;
    txt_lblPBNotes.value = ObjValue;
}
function lblPBInstructionsData(ObjValue) {
    txtTerms.value = ObjValue;
    txt_lblPBInstructions.value = ObjValue;
}
//OUT WORK MAIN CHECK BOX
function chkPBItemTitleChecked(Obj) {
    chkOutItemTitle.checked = Obj.checked;
    chkPBItemTitle.checked = Obj.checked;
}
function chkPBDescriptionChecked(Obj) {
    chkOutDescription.checked = Obj.checked;
    chkPBDescription.checked = Obj.checked;
}
function chkPBArtworkChecked(Obj) {
    chkOutArtwork.checked = Obj.checked;
    chkPBArtwork.checked = Obj.checked;
}
function chkPBColourChecked(Obj) {
    chkOutColour.checked = Obj.checked;
    chkPBColour.checked = Obj.checked;
}
function chkPBSizeChecked(Obj) {
    chkOutSize.checked = Obj.checked;
    chkPBSize.checked = Obj.checked;
}
function chkPBMaterialsChecked(Obj) {
    chkOutMaterial.checked = Obj.checked;
    chkPBMaterials.checked = Obj.checked;
}
function chkPBDeliveryChecked(Obj) {
    chkOutDelivery.checked = Obj.checked;
    chkPBDelivery.checked = Obj.checked;
}
function chkPBFinishingChecked(Obj) {
    chkOutFinishing.checked = Obj.checked;
    chkPBFinishing.checked = Obj.checked;
}
function chkPBNotesChecked(Obj) {
    chkOutNotes.checked = Obj.checked;
    chkPBNotes.checked = Obj.checked;
}
function chkPBInstructionsChecked(Obj) {
    chkOutInstructions.checked = Obj.checked;
    chkPBInstructions.checked = Obj.checked;
}
//********* MAIN PRINT BROKER ENDS *********************

//PRICE CATALOGUE
var Price_Array = new Array();
function PriceProperties() {
    this.PriceCatalogueID;
    this.CatalogueName;
    this.Quantity;
    this.QtyusedforCalculation;
    this.Price;
    this.Markup;
    this.Cost;
    this.MultipleOf;
    this.Height;
    this.Width;
    this.ReplenishProduct
}

function CatalogueOnEdit() {

    var CataArr_1 = hidCatalogueDataOnEdit.value.split('µ');

    for (var i = 0; i < CataArr_1.length; i++) {
        if (CataArr_1[i] != '') {
            var CataArr_2 = CataArr_1[i].split('±');
            var PriceCatalogueID;
            var CatalogueName;
            var Quantity;
            var Price;
            var Markup;
            var Cost;
            var MultipleOf;

            for (var j = 0; j < CataArr_2.length; j++) {
                var CataArr_3 = CataArr_2[j].split('»');
                if (CataArr_3[0] == "PriceCatalogueID") {
                    PriceCatalogueID = CataArr_3[1];
                    hid_OldPriceCatalogueID.value = PriceCatalogueID;
                }
                else if (CataArr_3[0] == "CatalogueName") {
                    CatalogueName = CataArr_3[1];
                }
                else if (CataArr_3[0] == "Quantity") {
                    Quantity = CataArr_3[1];
                }
                else if (CataArr_3[0] == "Price") {
                    Price = CataArr_3[1];
                }
                else if (CataArr_3[0] == "Markup") {
                    Markup = CataArr_3[1];
                }
                else if (CataArr_3[0] == "Cost") {
                    Cost = CataArr_3[1];
                }
                else if (CataArr_3[0] == "MultipleOf") {
                    MultipleOf = CataArr_3[1];
                }
            }
            var ObjPrice = new PriceProperties();
            ObjPrice.PriceCatalogueID = PriceCatalogueID;
            ObjPrice.CatalogueName = CatalogueName;
            ObjPrice.Quantity = Quantity;
            ObjPrice.Price = Price;
            ObjPrice.Markup = Markup;
            ObjPrice.Cost = Cost;
            ObjPrice.MultipleOf = MultipleOf;
            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE
            //alert(ObjPrice);         
        }
    }
    CatalogueLoad();
}

function ClearFilters() {
    document.getElementById(txtPriceCatalogueSerach_id).value = "";
    document.getElementById(ddlCategory_id).value = 0;
    document.getElementById(chkAllItems_id).checked = false;
}
function CheckOnluOneChk(para) {
    document.getElementById(chkAllItems_id).checked = false;
    document.getElementById(chkThisCustomer_id).checked = false;
    document.getElementById(chkUnallocated_id).checked = false;
    if (para == "U") {
        document.getElementById(chkUnallocated_id).checked = true;
    }
    else if (para == "A") {
        document.getElementById(chkAllItems_id).checked = true;
    }
    else if (para == "T") {
        document.getElementById(chkThisCustomer_id).checked = true;
    }
}

//==============> PRICE CATALOGUE <==============================================
function ShowCatalogueList() {
    if (document.getElementById("div_selected_catalogue").style.display == "block") {
        document.getElementById("div_selected_catalogue").style.display = "none";
        window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
    }
    else {
        window.parent.document.getElementById("hrefShowCatalogue").style.display = "none";
        document.getElementById("div_selected_catalogue").style.display = "block";
    }
}
function HideCatalogueList() {
    if (document.getElementById("div_selected_catalogue").style.display == "block") {
        window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
        document.getElementById("div_selected_catalogue").style.display = "none";
    }
}

var EstimatePossible = '';
var PriceCatalogueIDNew = '';
var CatalogueNameNew = '';
var MatrixTypeNew = '';

function GetEstimatePossible(result) {
    var hdn_SoldInPacksof = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_SoldInPacksof").value;
    document.getElementById("divsave").style.display = "block";
    document.getElementById("div_btnsaveloading").style.display = "none";


    if (result === "false") {
        if (modulename.toLowerCase() == "jobs") {
            if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
                var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                    document.getElementById("chk_Replenish_Product") != null && document.getElementById("chk_Replenish_Product").checked) {
                    GetEstimatePossible(true);
                }
                else if (ddlMandatory) {
                    var ddlValue = ddlMandatory.value.trim().toLowerCase();

                    if (ddlValue === "true" || ddlValue === "1") {
                        GetEstimatePossible(true);
                    } else {
                        alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
                    }
                }
                else {
                    alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
                }
            } else {
                alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
            }
        }
        else if (modulename.toLowerCase() == "invoice") {
            alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
        }

        window.parent.document.getElementById('ctl00_ContentPlaceHolder1_PriceCatalog_Button15').disabled = true;
        document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
        return false;
    }
    else {
        var quantity = 0;
        var hdn_kitavail = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_kitavailibility");
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            if (MatrixTypeNew == "P" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);

                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixTypeNew == "G" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);

                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixTypeNew == "S" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (hdn_IsCumulative.value == "true") {
                        ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                        if (ddlObj.value != '' && ddlObj.value != '0') {
                            quantity = Number(quantity) + Number(ddlObj.value);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    } else {
                        ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                        if (ddlObj.options[ddlObj.selectedIndex].text != 'select') {
                            quantity = Number(quantity) + Number(ddlObj.options[ddlObj.selectedIndex].text);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    }
                }
                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }
        }
        var Qty_used_for_Calculation = 0;
        var CheckEmpty = false;
        var CheckIsZero = false;
        var CumulativeMaxQuantitycheck = true;

        if (MatrixTypeNew == "P") {
            for (var i = 1; i < 5; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + i + "").value == '0') {
                    CheckIsZero = true;
                }
            }

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else {

                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                    document.getElementById("div_price_qty_valid").style.display = 'block';
                                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                    return false;
                                } else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                                }
                                var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                    Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                }
                                var ObjPrice = new PriceProperties();
                                ObjPrice.PriceCatalogueID = PriceCatalogueIDNew;
                                ObjPrice.CatalogueName = CatalogueNameNew;
                                ObjPrice.Quantity = Quantity;
                                ObjPrice.Price = SellingPrice;
                                ObjPrice.Markup = Markup;
                                var Quantity_Cost = Number(Quantity) * Number(Cost);
                                ObjPrice.Cost = Quantity_Cost;
                                ObjPrice.MultipleOf = MultipleOf;
                                //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                                //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                                //    ObjPrice.ReplenishProduct = chk_Replenish;
                                //}
                                var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                                if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                    document.getElementById("chk_Replenish_Product") != null) {
                                    ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                                } else if (ddlMandatory) {
                                    var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                    if (ddlValue === "true" || ddlValue === "1") {
                                        ObjPrice.ReplenishProduct = true;
                                    }
                                    if (ddlValue === "false" || ddlValue === "0") {
                                        ObjPrice.ReplenishProduct = false;
                                    }
                                }
                                ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixTypeNew == "G") {

            for (var i = 1; i < 5; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
            }

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                return false;
            }
            else {
                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;
                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                var txtHeight = document.getElementById("txt_Height_" + i + "");
                                var txtWidth = document.getElementById("txt_Width_" + i + "");

                                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                    if (txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                        document.getElementById("span_price_qty_valid").innerHTML = Please_enter_width;
                                        txtWidth.focus();
                                    }
                                    else {
                                        document.getElementById("span_price_qty_valid").innerHTML = Please_enter_height;
                                        txtHeight.focus();
                                    }
                                    document.getElementById("div_price_qty_valid").style.display = "block";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    return false;
                                }
                                else {
                                    var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                    var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                    var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                    var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                    if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                        Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                    }
                                    var ObjPrice = new PriceProperties();
                                    ObjPrice.PriceCatalogueID = PriceCatalogueIDNew;
                                    ObjPrice.CatalogueName = CatalogueNameNew;
                                    ObjPrice.Quantity = Quantity;
                                    ObjPrice.Price = SellingPrice;
                                    ObjPrice.Markup = Markup;
                                    var Quantity_Cost = 0;
                                    if (Measurementvalue == 'In.') {
                                        Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                                    }
                                    else {
                                        Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                                    }
                                    ObjPrice.Cost = Quantity_Cost;
                                    ObjPrice.MultipleOf = MultipleOf;
                                    ObjPrice.Height = txtHeight.value;
                                    ObjPrice.Width = txtWidth.value;
                                    //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                                    //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                                    //    ObjPrice.ReplenishProduct = chk_Replenish;
                                    //}
                                    var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                                    if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                        document.getElementById("chk_Replenish_Product") != null) {
                                        ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                                    } else if (ddlMandatory) {
                                        var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                        if (ddlValue === "true" || ddlValue === "1") {
                                            ObjPrice.ReplenishProduct = true;
                                        }
                                        if (ddlValue === "false" || ddlValue === "0") {
                                            ObjPrice.ReplenishProduct = false;
                                        }
                                    }
                                    ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                    Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE
                                }
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixTypeNew == "S") {
            var txt_Cumulative_PriceQty = "";
            if (SimpleMatBrowserHandy == "yes") {
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value != '') {
                        CheckEmpty = true;
                    }
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value == '0') {
                        CheckIsZero = true;
                    }
                }
            }
            else {
                for (var i = 1; i < 5; i++) {
                    if (hdn_IsCumulative.value == "true") {
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value == '0') {
                            CheckIsZero = true;
                        }
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                        if (Number(document.getElementById("txt_Cumulative_PriceQty_" + i + "").value) > Number(MaxQuantity)) {
                            txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                            CumulativeMaxQuantitycheck = false;
                        }
                    } else {
                        if (document.getElementById("ddl_req_qty_" + i + "").value != 'select' && document.getElementById("ddl_req_qty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                    }
                }
            }
            if (CheckEmpty == false) {
                if (hdn_IsCumulative.value == "true") {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                } else {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please select at least one Quantity";
                }
                document.getElementById("div_price_qty_valid").style.display = "block";
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CumulativeMaxQuantitycheck == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Maximum quantity is " + MaxQuantity + " ";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                txt_Cumulative_PriceQty.focus();
                return false;
            }
            else {
                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;
                for (var i = 1; i < 5; i++) {
                    var ddlObj = '';
                    var Quantity = '';
                    if (SimpleMatBrowserHandy == "yes") {
                        if (document.getElementById("ddltxt_req_qty_" + i + "").style.display == "block") {
                            var Quantity = document.getElementById("ddltxt_req_qty_" + i + "").value;
                        }
                    }
                    else {
                        if (hdn_IsCumulative.value == "true") {
                            if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                                Quantity = ddlObj.value;
                            }
                        } else {
                            if (document.getElementById("ddl_req_qty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                                Quantity = ddlObj.options[ddlObj.selectedIndex].text;
                            }
                        }
                    }

                    if (Quantity != 'select' && Quantity != '') {
                        if (!isNaN(Quantity)) {
                            if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                document.getElementById("div_price_qty_valid").style.display = 'block';
                                document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                return false;
                            } else {
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                            }
                            var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                            var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                            var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                            if (document.getElementById("ddltxt_req_qty_temp_" + i + "").value != '') {
                                Qty_used_for_Calculation = Number(document.getElementById("ddltxt_req_qty_temp_" + i + "").value);
                            }
                            var ObjPrice = new PriceProperties();
                            ObjPrice.PriceCatalogueID = PriceCatalogueIDNew;
                            ObjPrice.CatalogueName = CatalogueNameNew;
                            ObjPrice.Quantity = Quantity;
                            ObjPrice.Price = SellingPrice;
                            ObjPrice.Markup = Markup;
                            ObjPrice.Cost = Cost;
                            ObjPrice.MultipleOf = MultipleOf;
                            //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                            //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                            //    ObjPrice.ReplenishProduct = chk_Replenish;
                            //}
                            var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                            if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                document.getElementById("chk_Replenish_Product") != null) {
                                ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                            } else if (ddlMandatory) {
                                var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                if (ddlValue === "true" || ddlValue === "1") {
                                    ObjPrice.ReplenishProduct = true;
                                }
                                if (ddlValue === "false" || ddlValue === "0") {
                                    ObjPrice.ReplenishProduct = false;
                                }
                            }
                            ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                                                
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        Getitemdescription();
        loadingimg('divsave', 'div_btnsaveloading');
        SvaeCatalogue();
        return true;
    }
}

var hdn_txttotalqty = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_txttotalquantity");
function GetMaxAvail(PricecatId, txtid, type) {
    if (type == 'p') {
        var qty = document.getElementById(txtid).value;
    }
    else if (type == 'g') {
        var qty = document.getElementById(txtid).value;
    }
    else if (type == 's') {
        e = document.getElementById(txtid);
        var qty = e.options[e.selectedIndex].text

    }
    if (qty == '' || qty == 'select') {
        alert("Please Enter Quantity");
        return false;
    }
    getmaxkit(PricecatId, qty);
}

function getmaxkit(PricecatId, qty) {
    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_txttotalquantity").value = qty;
    AutoFill.GetMaxKitAvail(PricecatId, qty, Chkresult, onTimeout, onError);
}

function Chkresult(Result) {
    //hdn_kitavail.value = Result;
    var backordermsg = 'No'; //'Not Available';
    if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 1) {
        backordermsg = 'Yes'; //'Available'
    }
    // if (parseInt(hdn_txttotalqty.value) > parseInt(Result) && document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdn_drawstockfrom").value=='O') {   //&& document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_hdn_isbackorder").value == 0
    alert("Maximum kits available: " + Result + "\n" + "Back order allowed: " + backordermsg);
    return false;
    // }
}

function ReplaceAll_ForDecimals(CompleteString, ReplaceThis, RepolaceWith) {
    return CompleteString = CompleteString.split(ReplaceThis).join(RepolaceWith);
}

function storeToArray(PriceCatalogueID, CatalogueName, MatrixType, isAddOrContinue) {
    debugger;
    if (isAddOrContinue) {
        if (isAddOrContinue == "addmore") {
            $("#ctl00_ContentPlaceHolder1_ctl00_hdn_isAddMore").val("1")
        } else {
            $("#ctl00_ContentPlaceHolder1_ctl00_hdn_isAddMore").val("0")
        }
    }

    if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 &&
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 &&
        (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {

        var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");

        if (ddlMandatory) {
            var ddlValue = ddlMandatory.value.trim();

            if (ddlValue === "") {
                alert("Please select True or False for Mandatory Replenishment before saving.");
                ddlMandatory.focus();
                return false; // stop storeToArray execution here
            }
        }
    }



    //loadingimg('divsave', 'div_btnsaveloading');
    var hdn_SoldInPacksof = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_SoldInPacksof").value;
    //added by rakshith
    PriceCatalogueIDNew = PriceCatalogueID;
    CatalogueNameNew = CatalogueName;
    MatrixTypeNew = MatrixType;
    var Qty_used_for_Calculation = 0;
    if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple") != null && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple") != undefined) {
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlOtherMultiple").value == "--Select--") {
            document.getElementById("div_ProductSelect_valid").style.display = "block";
            return false;
        }
    }

    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'true';
    if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
        var QtyNumber = 1;
        if (document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != '' && document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != 0) {
            QtyNumber = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value;
        }

        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            var EnterdQty = 0;

            var StatusID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnJobStatusID").value;

            if (MatrixType == "P") {
                var msg = '';
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '' && document.getElementById("txt_req_qty_" + QtyNumber + "").value != '0') {

                    var MultipleOfQty = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                    EnterdQty = Number(document.getElementById("txt_req_qty_" + QtyNumber + "").value);

                    var TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);

                    AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible, onTimeout, onError);
                }
            }

            if (MatrixType == "G") {
                var msg = '';
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '') {

                    var MultipleOfQty = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                    EnterdQty = Number(document.getElementById("txt_req_qty_" + QtyNumber + "").value);

                    var TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);

                    AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible, onTimeout, onError);
                }
            }

            if (MatrixType == "S") {
                var msg = '';
                var MultipleOfQty = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;

                var TotalQuantity = 0;
                if (hdn_IsCumulative.value == "true") {
                    ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "");
                    if (ddlObj.value != '' && ddlObj.value != '0') {
                        EnterdQty = Number(ddlObj.value);
                        TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);
                        AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible, onTimeout, onError);
                    }
                } else {
                    ddlObj = document.getElementById("ddl_req_qty_" + QtyNumber + "");
                    if (ddlObj.options[ddlObj.selectedIndex].text != 'select') {
                        EnterdQty = Number(ddlObj.options[ddlObj.selectedIndex].text);
                        TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);
                        AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible, onTimeout, onError);
                    }
                }

                if (SimpleMatBrowserHandy == "yes") {
                    if (document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value != '') {
                        EnterdQty = Number(document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value);
                        var TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);
                        AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible, onTimeout, onError);
                    }
                }
            }
        }

        var quantity = 0;
        var hdn_kitavail = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_kitavailibility");
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            if (MatrixType == "P" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);

                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixType == "G" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);

                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixType == "S" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {

                    if (hdn_IsCumulative.value == "true") {
                        ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                        if (ddlObj.value != '' && ddlObj.value != '0') {
                            quantity = Number(quantity) + Number(ddlObj.value);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    } else {
                        ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                        if (ddlObj.options[ddlObj.selectedIndex].text != 'select') {
                            quantity = Number(quantity) + Number(ddlObj.options[ddlObj.selectedIndex].text);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    }
                }
                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }
        }

        var CheckEmpty = false;
        var CheckIsZero = false;
        var CumulativeMaxQuantitycheck = true;

        if (MatrixType == "P") {
            //for (var i = 1; i < 5; i++) {
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '') {
                CheckEmpty = true;
            }
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '0') {
                CheckIsZero = true;
            }
            //}

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else {

                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                    document.getElementById("div_price_qty_valid").style.display = 'block';
                                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                    return false;
                                } else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                                }
                                var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                    Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                }
                                var ObjPrice = new PriceProperties();
                                ObjPrice.PriceCatalogueID = PriceCatalogueID;
                                ObjPrice.CatalogueName = CatalogueName;
                                ObjPrice.Quantity = Quantity;
                                ObjPrice.Price = SellingPrice;
                                ObjPrice.Markup = Markup;
                                var Quantity_Cost = Number(Quantity) * Number(Cost);
                                ObjPrice.Cost = Quantity_Cost;
                                ObjPrice.MultipleOf = MultipleOf;
                                if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                                    if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                        document.getElementById("chk_Replenish_Product") != null) {
                                        var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                                        ObjPrice.ReplenishProduct = chk_Replenish;
                                    } else {
                                        if (ddlMandatory) {
                                            var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                            if (ddlValue === "true" || ddlValue === "1") {
                                                ObjPrice.ReplenishProduct = true;
                                            } else {
                                                ObjPrice.ReplenishProduct = false;
                                            }
                                        } else {
                                            ObjPrice.ReplenishProduct = false;
                                        }
                                    }
                                }
                                ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                        
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixType == "G") {

            for (var i = 1; i < 5; i++) {
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '0') {
                    CheckIsZero = true;
                }
            }

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else {

                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                var txtHeight = document.getElementById("txt_Height_" + i + "");
                                var txtWidth = document.getElementById("txt_Width_" + i + "");
                                var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                    Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                }
                                var ObjPrice = new PriceProperties();
                                ObjPrice.PriceCatalogueID = PriceCatalogueID;
                                ObjPrice.CatalogueName = CatalogueName;
                                ObjPrice.Quantity = Quantity;
                                ObjPrice.Price = SellingPrice;
                                ObjPrice.Markup = Markup;
                                var Quantity_Cost = 0;
                                if (Measurementvalue == 'In.') {
                                    Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                                }
                                else {
                                    Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                                }
                                ObjPrice.Cost = Quantity_Cost;
                                ObjPrice.MultipleOf = MultipleOf;
                                ObjPrice.Height = txtHeight.value;
                                ObjPrice.Width = txtWidth.value;
                                //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                                //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                                //    ObjPrice.ReplenishProduct = chk_Replenish;
                                //}
                                var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                                if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                    document.getElementById("chk_Replenish_Product") != null) {
                                    ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                                } else if (ddlMandatory) {
                                    var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                    if (ddlValue === "true" || ddlValue === "1") {
                                        ObjPrice.ReplenishProduct = true;
                                    }
                                    if (ddlValue === "false" || ddlValue === "0") {
                                        ObjPrice.ReplenishProduct = false;
                                    }
                                }
                                ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                        
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixType == "S") {
            var txt_Cumulative_PriceQty = '';
            if (SimpleMatBrowserHandy == "yes") {
                if (document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value == '0') {
                    CheckIsZero = true;
                }
            }
            else {
                if (hdn_IsCumulative.value == "true") {
                    if (document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value == '0') {
                        CheckIsZero = true;
                    }
                    if (document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value != '') {
                        CheckEmpty = true;
                    }
                    if (Number(document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value) > Number(MaxQuantity)) {
                        txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "");
                        CumulativeMaxQuantitycheck = false;
                    }
                } else {
                    if (document.getElementById("ddl_req_qty_" + QtyNumber + "").value != 'select' && document.getElementById("ddl_req_qty_" + QtyNumber + "").value != '') {
                        CheckEmpty = true;
                    }
                }
            }

            if (CheckEmpty == false) {
                if (hdn_IsCumulative.value == "true") {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                } else {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please select at least one Quantity";
                }
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CumulativeMaxQuantitycheck == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Maximum quantity is " + MaxQuantity + " ";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                txt_Cumulative_PriceQty.focus();
                return false;
            }
            else {
                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;
                for (var i = 1; i < 5; i++) {
                    var ddlObj = '';
                    var Quantity = '';
                    if (SimpleMatBrowserHandy == "yes") {
                        if (document.getElementById("ddltxt_req_qty_" + i + "").style.display == "block") {
                            var Quantity = document.getElementById("ddltxt_req_qty_" + i + "").value;
                        }
                    }
                    else {
                        if (hdn_IsCumulative.value == "true") {
                            if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                                Quantity = ddlObj.value;
                            }
                        } else {
                            if (document.getElementById("ddl_req_qty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                                Quantity = ddlObj.options[ddlObj.selectedIndex].text;
                            }
                        }
                    }

                    if (Quantity != 'select' && Quantity != '') {

                        if (!isNaN(Quantity)) {
                            if (hdn_IsCumulative.value == "true") {
                                if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                    document.getElementById("div_price_qty_valid").style.display = 'block';
                                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                    return false;
                                } else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                                }
                            }
                            var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                            var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                            var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                            if (document.getElementById("ddltxt_req_qty_temp_" + i + "").value != '') {
                                Qty_used_for_Calculation = Number(document.getElementById("ddltxt_req_qty_temp_" + i + "").value);
                            }
                            var ObjPrice = new PriceProperties();
                            ObjPrice.PriceCatalogueID = PriceCatalogueID;
                            ObjPrice.CatalogueName = CatalogueName;
                            ObjPrice.Quantity = Quantity;
                            ObjPrice.Price = SellingPrice;
                            ObjPrice.Markup = Markup;
                            ObjPrice.Cost = Cost;
                            ObjPrice.MultipleOf = MultipleOf;
                            //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                            //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                            //    ObjPrice.ReplenishProduct = chk_Replenish;
                            //}
                            var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                            if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                document.getElementById("chk_Replenish_Product") != null) {
                                ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                            } else if (ddlMandatory) {
                                var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                if (ddlValue === "true" || ddlValue === "1") {
                                    ObjPrice.ReplenishProduct = true;
                                }
                                if (ddlValue === "false" || ddlValue === "0") {
                                    ObjPrice.ReplenishProduct = false;
                                }
                            }
                            ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                                                
                        }
                    }

                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }

        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            if (MatrixType == "P") {
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '') {

                }
            }

            if (MatrixType == "G") {
                if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '') {

                }
            }

            if (MatrixType == "S") {
                if (hdn_IsCumulative.value == "true") {
                    ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                    if (ddlObj == '' && ddlObj.value == 0) {

                    }
                } else {
                    ddlObj = document.getElementById("ddl_req_qty_" + QtyNumber + "");
                    if (ddlObj.options[ddlObj.selectedIndex].text == 'select') {

                    }
                }
            }

        }
        else if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 0) {
            Getitemdescription();
            loadingimg('divsave', 'div_btnsaveloading');
            SvaeCatalogue();
        }
    }
    else {

        var quantity = 0;
        var hdn_kitavail = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_kitavailibility");
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            if (MatrixType == "P" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);

                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixType == "G" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                        quantity = Number(quantity) + Number(document.getElementById("txt_req_qty_" + i + "").value);
                        if (quantity > hdn_kitavail.value) {
                            msg += i + ",";
                        }
                    }
                }

                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }

            if (MatrixType == "S" && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_isbackorder").value == 0 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_drawstockfrom").value == 'O') {
                var msg = '';
                for (var i = 1; i < 5; i++) {

                    if (hdn_IsCumulative.value == "true") {
                        ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                        if (ddlObj.value != '' && ddlObj.value != '0') {
                            quantity = Number(quantity) + Number(ddlObj.value);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    } else {
                        ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                        if (ddlObj.options[ddlObj.selectedIndex].text != 'select') {
                            quantity = Number(quantity) + Number(ddlObj.options[ddlObj.selectedIndex].text);
                            if (quantity > hdn_kitavail.value) {
                                msg += i + ",";
                            }
                        }
                    }
                }
                if (msg != '') {
                    alert("Quantity " + msg + "have more than Maximum available Kit of " + hdn_kitavail.value);
                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                    return false;
                }
            }
        }
        var CheckEmpty = false;
        var CheckIsZero = false;
        if (MatrixType == "P") {
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            for (var i = 1; i < TotalN0; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + i + "").value == '0') {
                    CheckIsZero = true;
                }
            }

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else {

                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {
                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;
                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                    document.getElementById("div_price_qty_valid").style.display = 'block';
                                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                    return false;
                                } else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                                }
                                var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                    Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                }
                                var ObjPrice = new PriceProperties();
                                ObjPrice.PriceCatalogueID = PriceCatalogueID;
                                ObjPrice.CatalogueName = CatalogueName;
                                ObjPrice.Quantity = Quantity;
                                ObjPrice.Price = SellingPrice;
                                ObjPrice.Markup = Markup;
                                var Quantity_Cost = Number(Quantity) * Number(Cost);
                                ObjPrice.Cost = Quantity_Cost;
                                ObjPrice.MultipleOf = MultipleOf;
                                ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                        
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixType == "G") {
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            for (var i = 1; i < TotalN0; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + i + "").value == '0') {
                    CheckIsZero = true;
                }
            }

            if (CheckEmpty == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else {
                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;

                for (var i = 1; i < 5; i++) {

                    if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                        if (Quantity != '') {
                            if (!isNaN(Quantity)) {
                                var txtHeight = document.getElementById("txt_Height_" + i + "");
                                var txtWidth = document.getElementById("txt_Width_" + i + "");

                                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                    if (txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                        document.getElementById("span_price_qty_valid").innerHTML = Please_enter_width;
                                        txtWidth.focus();
                                    }
                                    else {
                                        document.getElementById("span_price_qty_valid").innerHTML = Please_enter_height;
                                        txtHeight.focus();
                                    }
                                    document.getElementById("div_price_qty_valid").style.display = "block";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    isProceedable = false;
                                    IsEmptyorZero = false;
                                    return false;
                                }
                                else {
                                    var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                    var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                    var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                    var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                    if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                        Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                    }
                                    var ObjPrice = new PriceProperties();
                                    ObjPrice.PriceCatalogueID = PriceCatalogueID;
                                    ObjPrice.CatalogueName = CatalogueName;
                                    ObjPrice.Quantity = Quantity;
                                    ObjPrice.Price = SellingPrice;
                                    ObjPrice.Markup = Markup;
                                    var Quantity_Cost = 0;
                                    if (Measurementvalue == 'In.') {
                                        Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                                    }
                                    else {
                                        Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                                    }
                                    ObjPrice.Cost = Quantity_Cost;
                                    ObjPrice.MultipleOf = MultipleOf;
                                    ObjPrice.Height = txtHeight.value;
                                    ObjPrice.Width = txtWidth.value;
                                    ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;

                                    Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE       
                                }
                            }
                        }
                    }
                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        else if (MatrixType == "S") {
            var txt_Cumulative_PriceQty = '';
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            if (SimpleMatBrowserHandy == "yes") {
                for (var i = 1; i < TotalN0; i++) {
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value != '') {
                        CheckEmpty = true;
                    }
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value == '0') {
                        CheckIsZero = true;
                    }
                }
            }
            else {
                for (var i = 1; i < TotalN0; i++) {
                    if (hdn_IsCumulative.value == "true") {
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value == '0') {
                            CheckIsZero = true;
                        }
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                        if (Number(document.getElementById("txt_Cumulative_PriceQty_" + i + "").value) > Number(MaxQuantity)) {
                            txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                            CumulativeMaxQuantitycheck = false;
                        }
                    } else {
                        if (document.getElementById("ddl_req_qty_" + i + "").value != 'select' && document.getElementById("ddl_req_qty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                    }
                }
            }

            if (CheckEmpty == false) {
                if (hdn_IsCumulative.value == "true") {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
                } else {
                    document.getElementById("span_price_qty_valid").innerHTML = "Please select at least one Quantity";
                }
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CheckIsZero == true) {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                return false;
            }
            else if (CumulativeMaxQuantitycheck == false) {
                document.getElementById("span_price_qty_valid").innerHTML = "Maximum quantity is " + MaxQuantity + " ";
                document.getElementById("div_price_qty_valid").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                isProceedable = false;
                IsEmptyorZero = false;
                txt_Cumulative_PriceQty.focus();
                return false;
            }
            else {
                document.getElementById("div_price_qty_valid").style.display = "none";
                Price_Array.length = 0;
                for (var i = 1; i < 5; i++) {
                    var ddlObj = '';
                    var Quantity = '';
                    if (SimpleMatBrowserHandy == "yes") {
                        if (document.getElementById("ddltxt_req_qty_" + i + "").style.display == "block") {
                            var Quantity = document.getElementById("ddltxt_req_qty_" + i + "").value;
                        }
                    }
                    else {
                        if (hdn_IsCumulative.value == "true") {
                            if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                                Quantity = ddlObj.value;
                            }
                        } else {
                            if (document.getElementById("ddl_req_qty_" + i + "").style.display == "block") {
                                ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                                Quantity = ddlObj.options[ddlObj.selectedIndex].text;
                            }
                        }
                    }

                    if (Quantity != 'select' && Quantity != '') {

                        if (!isNaN(Quantity)) {
                            if (hdn_IsCumulative.value == "true") {
                                if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                    document.getElementById("div_price_qty_valid").style.display = 'block';
                                    document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                    document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                    return false;
                                } else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                                }
                            }
                            var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                            var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                            var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                            if (document.getElementById("ddltxt_req_qty_temp_" + i + "").value != '') {
                                Qty_used_for_Calculation = Number(document.getElementById("ddltxt_req_qty_temp_" + i + "").value);
                            }
                            var ObjPrice = new PriceProperties();
                            ObjPrice.PriceCatalogueID = PriceCatalogueID;
                            ObjPrice.CatalogueName = CatalogueName;
                            ObjPrice.Quantity = Quantity;
                            ObjPrice.Price = SellingPrice;
                            ObjPrice.Markup = Markup;
                            ObjPrice.Cost = Cost;
                            ObjPrice.MultipleOf = MultipleOf;
                            ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                                                
                        }
                    }

                }
                CatalogueLoad();
                window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
            }
        }
        Getitemdescription();
        loadingimg('divsave', 'div_btnsaveloading');
        SvaeCatalogue();
    }
}

function storeToArrayAO(PriceCatalogueID, CatalogueName, MatrixType) {
    var hdn_SoldInPacksof = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_SoldInPacksof").value;
    var quantity = 0;
    //---
    var Qty_used_for_Calculation = 0;
    var CheckEmpty = false;
    var CheckIsZero = false;
    var CumulativeMaxQuantitycheck = true;
    var QtyNumber = 1;
    if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
        if (document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != '' && document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != 0) {
            QtyNumber = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value;
        }
    }

    if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 &&
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 &&
        (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {

        var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");

        if (ddlMandatory) {
            var ddlValue = ddlMandatory.value.trim();

            if (ddlValue === "") {
                alert("Please select True or False for Mandatory Replenishment before saving.");
                ddlMandatory.focus();
                return false; // stop storeToArray execution here
            }
        }
    }

    if (MatrixType == "P") {
        if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
            //for (var i = 1; i < 5; i++) {
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '') {
                CheckEmpty = true;
            }
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '0') {
                CheckIsZero = true;
            }
            //}
        } else {
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            for (var i = 1; i < TotalN0; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + i + "").value == '0') {
                    CheckIsZero = true;
                }
            }
        }
        if (CheckEmpty == false) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else if (CheckIsZero == true) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else {
            document.getElementById("div_price_qty_valid").style.display = "none";
            Price_Array.length = 0;

            for (var i = 1; i < 5; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                    var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                    if (Quantity != '') {
                        if (!isNaN(Quantity)) {
                            if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                document.getElementById("div_price_qty_valid").style.display = 'block';
                                document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                return false;
                            } else {
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                            }
                            var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');

                            var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                            var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                            if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                            }
                            var ObjPrice = new PriceProperties();
                            ObjPrice.PriceCatalogueID = PriceCatalogueID;
                            ObjPrice.CatalogueName = CatalogueName;
                            ObjPrice.Quantity = Quantity;
                            ObjPrice.Price = SellingPrice;
                            ObjPrice.Markup = Markup;
                            var Quantity_Cost = Number(Quantity) * Number(Cost);
                            ObjPrice.Cost = Quantity_Cost;
                            ObjPrice.MultipleOf = MultipleOf;
                            //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                            //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                            //    ObjPrice.ReplenishProduct = chk_Replenish;
                            //}
                            var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                            if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                document.getElementById("chk_Replenish_Product") != null) {
                                ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                            } else if (ddlMandatory) {
                                var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                if (ddlValue === "true" || ddlValue === "1") {
                                    ObjPrice.ReplenishProduct = true;
                                }
                                if (ddlValue === "false" || ddlValue === "0") {
                                    ObjPrice.ReplenishProduct = false;
                                }
                            }
                            ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE    
                        }
                    }
                }

            }
            CatalogueLoad();
            window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
        }
    }
    else if (MatrixType == "G") {
        if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job" || modulename.toLowerCase() == "invoice") {
            //var QtyNumber = 1;
            //if (document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != '' && document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value != 0) {
            //    QtyNumber = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdnQtyNumber').value;
            //}
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value != '') {
                CheckEmpty = true;
            }
            if (document.getElementById("txt_req_qty_" + QtyNumber + "").value == '0') {
                CheckIsZero = true;
            }
        } else {
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            for (var i = 1; i < TotalN0; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("txt_req_qty_" + i + "").value == '0') {
                    CheckIsZero = true;
                }
            }
        }
        if (CheckEmpty == false) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else if (CheckIsZero == true) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else {
            document.getElementById("div_price_qty_valid").style.display = "none";
            Price_Array.length = 0;

            for (var i = 1; i < 5; i++) {
                if (document.getElementById("txt_req_qty_" + i + "").style.display == "block") {
                    var Quantity = document.getElementById("txt_req_qty_" + i + "").value;

                    if (Quantity != '') {
                        if (!isNaN(Quantity)) {
                            var txtHeight = document.getElementById("txt_Height_" + i + "");
                            var txtWidth = document.getElementById("txt_Width_" + i + "");

                            if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                if (txtWidth.value == "" || Number(txtWidth.value) == 0) {
                                    document.getElementById("span_price_qty_valid").innerHTML = Please_enter_width;
                                    txtWidth.focus();
                                }
                                else {
                                    document.getElementById("span_price_qty_valid").innerHTML = Please_enter_height;
                                    txtHeight.focus();
                                }
                                document.getElementById("div_price_qty_valid").style.display = "block";
                                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                isProceedable = false;
                                IsEmptyorZero = false;
                                return false;
                            }
                            else {
                                var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                var Cost = ReplaceAll_ForDecimals(document.getElementById("spn_QtyCost_" + i + "").innerHTML, ',', '');
                                var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                                var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                                if (document.getElementById("txt_req_qty_temp_" + i + "").value != '' && document.getElementById("txt_req_qty_temp_" + i + "").value != '0') {
                                    Qty_used_for_Calculation = Number(document.getElementById("txt_req_qty_temp_" + i + "").value);
                                }
                                var ObjPrice = new PriceProperties();
                                ObjPrice.PriceCatalogueID = PriceCatalogueID;
                                ObjPrice.CatalogueName = CatalogueName;
                                ObjPrice.Quantity = Quantity;
                                ObjPrice.Price = SellingPrice;
                                ObjPrice.Markup = Markup;
                                var Quantity_Cost = 0;
                                if (Measurementvalue == 'In.') {
                                    Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                                }
                                else {
                                    Quantity_Cost = Number(Quantity) * Number(Cost) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                                }
                                ObjPrice.Cost = Quantity_Cost;
                                ObjPrice.MultipleOf = MultipleOf;
                                ObjPrice.Height = txtHeight.value;
                                ObjPrice.Width = txtWidth.value;
                                //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                                //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                                //    ObjPrice.ReplenishProduct = chk_Replenish;
                                //}
                                var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                                if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                                    document.getElementById("chk_Replenish_Product") != null) {
                                    ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                                } else if (ddlMandatory) {
                                    var ddlValue = ddlMandatory.value.trim().toLowerCase();

                                    if (ddlValue === "true" || ddlValue === "1") {
                                        ObjPrice.ReplenishProduct = true;
                                    }
                                    if (ddlValue === "false" || ddlValue === "0") {
                                        ObjPrice.ReplenishProduct = false;
                                    }
                                }
                                ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                                Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE 
                            }
                        }
                    }
                }

            }
            CatalogueLoad();
            window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
        }
    }
    else if (MatrixType == "S") {
        var txt_Cumulative_PriceQty = '';
        if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job" || modulename.toLowerCase() == "invoice") {
            if (SimpleMatBrowserHandy == "yes") {
                if (document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value != '') {
                    CheckEmpty = true;
                }
                if (document.getElementById("ddltxt_req_qty_" + QtyNumber + "").value == '0') {
                    CheckIsZero = true;
                }
            }
            else {
                if (hdn_IsCumulative.value == "true") {
                    if (document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value == '0') {
                        CheckIsZero = true;
                    }
                    if (document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value != '') {
                        CheckEmpty = true;
                    }
                    if (Number(document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "").value) > Number(MaxQuantity)) {
                        txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty_" + QtyNumber + "");
                        CumulativeMaxQuantitycheck = false;
                    }
                } else {
                    if (document.getElementById("ddl_req_qty_" + QtyNumber + "").value != 'select' && document.getElementById("ddl_req_qty_" + QtyNumber + "").value != '') {
                        CheckEmpty = true;
                    }
                }
            }
        } else {
            var TotalN0 = 5;
            if (modulename.toLowerCase() == "orders" || modulename.toLowerCase() == "order") {
                TotalN0 = 2;
            }
            if (SimpleMatBrowserHandy == "yes") {
                for (var i = 1; i < TotalN0; i++) {
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value != '') {
                        CheckEmpty = true;
                    }
                    if (document.getElementById("ddltxt_req_qty_" + i + "").value == '0') {
                        CheckIsZero = true;
                    }
                }
            }
            else {
                for (var i = 1; i < TotalN0; i++) {
                    if (hdn_IsCumulative.value == "true") {
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value == '0') {
                            CheckIsZero = true;
                        }
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                        if (Number(document.getElementById("txt_Cumulative_PriceQty_" + i + "").value) > Number(MaxQuantity)) {
                            txt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                            CumulativeMaxQuantitycheck = false;
                        }
                    } else {
                        if (document.getElementById("ddl_req_qty_" + i + "").value != 'select' && document.getElementById("ddl_req_qty_" + i + "").value != '') {
                            CheckEmpty = true;
                        }
                    }
                }
            }
        }

        if (CheckEmpty == false) {
            if (hdn_IsCumulative.value == "true") {
                document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
            } else {
                document.getElementById("span_price_qty_valid").innerHTML = "Please select at least one Quantity";
            }
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else if (CheckIsZero == true) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter valid Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            return false;
        }
        else if (CumulativeMaxQuantitycheck == false) {
            document.getElementById("span_price_qty_valid").innerHTML = "Maximum quantity is " + MaxQuantity + " ";
            document.getElementById("div_price_qty_valid").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
            isProceedable = false;
            IsEmptyorZero = false;
            txt_Cumulative_PriceQty.focus();
            return false;
        }
        else {
            document.getElementById("div_price_qty_valid").style.display = "none";
            Price_Array.length = 0;
            for (var i = 1; i < 5; i++) {
                var ddlObj = '';
                var Quantity = '';
                if (SimpleMatBrowserHandy == "yes") {
                    if (document.getElementById("ddltxt_req_qty_" + i + "").style.display == "block") {
                        var Quantity = document.getElementById("ddltxt_req_qty_" + i + "").value;
                    }
                }
                else {
                    if (hdn_IsCumulative.value == "true") {
                        if (document.getElementById("txt_Cumulative_PriceQty_" + i + "").style.display == "block") {
                            ddlObj = document.getElementById("txt_Cumulative_PriceQty_" + i + "");
                            Quantity = ddlObj.value;
                        }
                    } else {
                        if (document.getElementById("ddl_req_qty_" + i + "").style.display == "block") {
                            ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                            Quantity = ddlObj.options[ddlObj.selectedIndex].text;
                        }
                    }
                }

                if (Quantity != 'select' && Quantity != '') {

                    if (!isNaN(Quantity)) {

                        if (hdn_IsCumulative.value == "true") {
                            if (!(Quantity % hdn_SoldInPacksof == 0)) {
                                document.getElementById("div_price_qty_valid").style.display = 'block';
                                document.getElementById("span_price_qty_valid").innerHTML = "Please enter quantity in the multiples of " + hdn_SoldInPacksof + "";
                                document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value = 'false';
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'false';
                                return false;
                            } else {
                                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_ReturnSoldInPacksof").value = 'true';
                            }
                        }

                        var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                        var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                        var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;
                        var MultipleOf = document.getElementById("ddlMultiple").options[document.getElementById("ddlMultiple").selectedIndex].value;
                        if (document.getElementById("ddltxt_req_qty_temp_" + i + "").value != '') {
                            Qty_used_for_Calculation = Number(document.getElementById("ddltxt_req_qty_temp_" + i + "").value);
                        }
                        var ObjPrice = new PriceProperties();
                        ObjPrice.PriceCatalogueID = PriceCatalogueID;
                        ObjPrice.CatalogueName = CatalogueName;
                        ObjPrice.Quantity = Quantity;
                        ObjPrice.Price = SellingPrice;
                        ObjPrice.Markup = Markup;
                        ObjPrice.Cost = Cost;
                        ObjPrice.MultipleOf = MultipleOf;
                        //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
                        //    var chk_Replenish = document.getElementById("chk_Replenish_Product").checked;
                        //    ObjPrice.ReplenishProduct = chk_Replenish;
                        //}
                        var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                        if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                            document.getElementById("chk_Replenish_Product") != null) {
                            ObjPrice.ReplenishProduct = document.getElementById("chk_Replenish_Product").checked;
                        } else if (ddlMandatory) {
                            var ddlValue = ddlMandatory.value.trim().toLowerCase();

                            if (ddlValue === "true" || ddlValue === "1") {
                                ObjPrice.ReplenishProduct = true;
                            }
                            if (ddlValue === "false" || ddlValue === "0") {
                                ObjPrice.ReplenishProduct = false;
                            }
                        }
                        ObjPrice.QtyusedforCalculation = Qty_used_for_Calculation;
                        Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                                                

                    }
                }
            }
            CatalogueLoad();
            window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
        }
    }
}

function RemoveCatalogueName(ind) {
    Price_Array.splice(ind, 1);
    CatalogueLoad();
    if (Price_Array.length == 0) {
        window.parent.document.getElementById("hrefShowCatalogue").style.display = "none";
    }
}

function CatalogueLoad() {
    var HTMLData = '';
    HTMLData += " <div align='left' class='bgcustomize' style='height:20px;vertical-align:middle;'>";
    HTMLData += " <div style='float:left;width:310px;vertical-align:middle;' class='navigatorpanel'>" + ItemName + "</div>";
    HTMLData += " <div style='float:left;width:85px;vertical-align:middle;' class='navigatorpanel'>" + Quantity + "</div>";
    HTMLData += " <div style='float:left;width:75px;vertical-align:middle;' class='navigatorpanel'>" + Price + "(" + GetCurrencyinRequiredFormate("", true) + ")</div>";
    HTMLData += " <div style='float:right;vertical-align:middle;' ><a href='#' onclick='javascript:ShowCatalogueList();return false;'>";
    HTMLData += " <img src='" + strImagepath + "close1.jpg' title='Close' border='0' width='10px' height='10px' /></a></div>";
    HTMLData += " </div>";
    if (window.parent.div_catalogue_items_header != null) {
        window.parent.document.getElementById("div_catalogue_items_header").innerHTML = HTMLData;
    }

    HTMLData = '';
    for (var i = 0; i < Price_Array.length; i++) {
        var color1 = "#DADADA";
        if (i % 2 == 0) {
            color1 = "#EFEFEF";
        }
        var objArr = Price_Array[i];

        HTMLData += " <div align='left' class='onlyEmpty' style='height:20px;padding:2px;background-color:" + color1 + "'>";
        HTMLData += " <div style='float:left;width:310px;'>" + objArr.CatalogueName + "</div>";
        HTMLData += " <div style='float:left;width:85px;'><div align='right' style='width:49px;border:solid 0px red'>" + objArr.Quantity + "</div></div>";
        HTMLData += " <div style='float:left;width:75px;'>" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objArr.Price, 0, '', false, false, true) + "</div>"; //roundNumber(objArr.Price, 2)
        HTMLData += " <div style='float:left;'><a href='#' onclick='RemoveCatalogueName(" + i + ");'>Remove</a></div>";
        HTMLData += " </div>";
    }
    if (window.parent.div_catalogue_items != null) {
        window.parent.document.getElementById("div_catalogue_items").innerHTML = HTMLData;
    }
    if (window.parent.hrefShowCatalogue != null) {
        window.parent.document.getElementById("hrefShowCatalogue").style.display = "block";
    }
}

function CalculateQtyPrice(MainObjTextBox, val, index, Max) {
    debugger;
    if (hid_matixType.value == 'P') {
        var txtObj = document.getElementById("txt_req_qty_" + index + "");

        if (SimpleMatBrowserHandy == 'yes') {
            if (document.getElementById("txt_req_qty_temp_" + index + "").value != '' && document.getElementById("txt_req_qty_temp_" + index + "").value != '0') {
                val = parseFloat(document.getElementById("txt_req_qty_temp_" + index + "").value);
            }
        }

        var objno = 0;
        var objindex = 0;

        if (Allow_Integer_Only(MainObjTextBox, false)) {
            for (var i = 0; i < 50; i++) {
                if (document.getElementById("spn_FromQty_" + i + "") != null) {
                    var FromQty = document.getElementById("spn_FromQty_" + i + "").innerHTML;
                    var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                    var FromNext = '';
                    if (i < Max - 1) {
                        FromNext = document.getElementById("spn_FromQty_" + (i + 1) + "").innerHTML;
                    }
                    if ((parseFloat(val) >= parseFloat(FromQty)) && (parseFloat(val) <= parseFloat(ToQty))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else if ((parseFloat(val) > parseFloat(ToQty)) && (parseFloat(val) < parseFloat(FromNext))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else if ((parseFloat(val) < parseFloat(FromQty))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else {
                        if (i == parseFloat(Max) - parseFloat(1)) {
                            objno = i;
                            objindex = index;
                        }
                        else {
                            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
            }
            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');
            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = parseFloat(Cost) + (parseFloat(Cost) * parseFloat(Markup) / 100); //document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;
            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }

            //  if (MainObjTextBox.id.indexOf('_temp_') != -1) {  // It should always take value of main qty only for multiply
            val = document.getElementById("txt_req_qty_" + index + "").value;
            //}

            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(Price) * parseFloat(val)), 0, '', false, false, true); //roundparseFloat(parseFloat(Price) * parseFloat(val), 2);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * parseFloat(NoOFMultiple)), 0, '', false, false, true);

            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
        }
        else {
            MainObjTextBox.value = "";
        }
        if (document.getElementById("spn_QtyPrice_" + index + "").innerHTML == "" + GetCurrencyinRequiredFormate("", true) + "NaN") {
            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
        }
    }
    else if (hid_matixType.value == 'G') {
        var txtObj = document.getElementById("txt_req_qty_" + index + "");
        var txtHeight = document.getElementById("txt_Height_" + index + "");
        var txtWidth = document.getElementById("txt_Width_" + index + "");

        if (SimpleMatBrowserHandy == 'yes') {
            if (document.getElementById("txt_req_qty_temp_" + index + "").value != '' && document.getElementById("txt_req_qty_temp_" + index + "").value != '0') {
                val = parseFloat(document.getElementById("txt_req_qty_temp_" + index + "").value);
            }
        }

        var objno = 0;
        var objindex = 0;


        if (Allow_Integer_Only(txtObj, false)) {
            for (var i = 0; i < 50; i++) {
                if (txtHeight.value == "" || parseFloat(txtHeight.value) == 0 || txtWidth.value == "" || parseFloat(txtWidth.value) == 0) {
                    return false;
                }
                else {
                    if (document.getElementById("spn_FromQty_" + i + "") != null) {
                        var FromQty = document.getElementById("spn_FromQty_" + i + "").innerHTML;
                        var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                        var FromNext = '';

                        if (i < Max - 1) {
                            FromNext = document.getElementById("spn_FromQty_" + (i + 1) + "").innerHTML;
                        }

                        var Dimensn = 0;
                        if (Measurementvalue == 'In.') {
                            Dimensn = (parseFloat(txtObj.value)) * ((parseFloat(txtHeight.value) * parseFloat(txtWidth.value)) / 144);
                        }
                        else {
                            Dimensn = (parseFloat(txtObj.value)) * ((parseFloat(txtHeight.value) * parseFloat(txtWidth.value)) / 1000000);
                        }

                        if ((parseFloat(Dimensn) >= parseFloat(FromQty)) && (parseFloat(Dimensn) <= parseFloat(ToQty))) {
                            objno = i;
                            objindex = index;
                            break;
                        }
                        else if ((parseFloat(Dimensn) > parseFloat(ToQty)) && (parseFloat(Dimensn) < parseFloat(FromNext))) {
                            objno = i;
                            objindex = index;
                            break;
                        }
                        else if ((parseFloat(Dimensn) < parseFloat(FromQty))) {
                            objno = i;
                            objindex = index;
                            break;
                        }
                        else {
                            if (i == parseFloat(Max) - parseFloat(1)) {
                                objno = i;
                                objindex = index;
                            }
                            else {
                                document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                                document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                }
            }

            var Dimensn1 = 0;
            if (Measurementvalue == 'In.') {
                Dimensn1 = (parseFloat(txtHeight.value) * parseFloat(txtWidth.value)) / 144;
            }
            else {
                Dimensn1 = (parseFloat(txtHeight.value) * parseFloat(txtWidth.value)) / 1000000;
            }

            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');
            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            //var TotalPrice = document.getElementById("spn_Total_QtyPrice" + i + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;
            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }

            //  if (MainObjTextBox.id.indexOf('_temp_') != -1) {  // It should always take value of main qty only for multiply
            val = document.getElementById("txt_req_qty_" + index + "").value;
            //}
            var Chk = (parseFloat(Cost) * parseFloat(val) * parseFloat(Dimensn1));
            var ActualPrice = parseFloat(Chk) + ((parseFloat(Chk) / 100) * parseFloat(Markup));

            //var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(Price) * parseFloat(val) * parseFloat(Dimensn1)), 0, '', false, false, true); //roundparseFloat(parseFloat(Price) * parseFloat(val), 2);
            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, parseFloat(ActualPrice), 0, '', false, false, true);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * parseFloat(NoOFMultiple)), 0, '', false, false, true);

            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
        }
        else {
            MainObjTextBox.value = "";
        }
        if (document.getElementById("spn_QtyPrice_" + index + "").innerHTML == "" + GetCurrencyinRequiredFormate("", true) + "NaN") {
            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
        }
    }
    else if (hid_matixType.value == 'S' && hdn_IsCumulative.value == "true") {
        var txtObj = document.getElementById("txt_Cumulative_PriceQty_" + index + "");

        var objno = 0;
        var objindex = 0;

        if (Allow_Integer_Only(MainObjTextBox, false)) {
            for (var i = 0; i < 50; i++) {
                if (document.getElementById("spn_FromQty_" + i + "") != null) {
                    var FromQty = document.getElementById("spn_FromQty_" + i + "").innerHTML;
                    var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                    var FromNext = '';
                    if (i < Max - 1) {
                        FromNext = document.getElementById("spn_FromQty_" + (i + 1) + "").innerHTML;
                    }
                    if ((parseFloat(val) >= parseFloat(FromQty)) && (parseFloat(val) <= parseFloat(ToQty))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else if ((parseFloat(val) > parseFloat(ToQty)) && (parseFloat(val) < parseFloat(FromNext))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else if ((parseFloat(val) < parseFloat(FromQty))) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else {
                        if (i == parseFloat(Max) - parseFloat(1)) {
                            objno = i;
                            objindex = index;
                        }
                        else {
                            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
            }

            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');
            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = parseFloat(Cost) + (parseFloat(Cost) * parseFloat(Markup) / 100);

            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;
            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }

            if (hdn_IsCumulative.value == "true") {
                val = document.getElementById("txt_Cumulative_PriceQty_" + index + "").value;
            } else {
                val = document.getElementById("txt_req_qty_" + index + "").value;
            }

            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(Price)), 0, '', false, false, true); //roundparseFloat(parseFloat(Price) * parseFloat(val), 2);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * parseFloat(NoOFMultiple)), 0, '', false, false, true);

            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
        }
        else {
            MainObjTextBox.value = "";
        }
        if (document.getElementById("spn_QtyPrice_" + index + "").innerHTML == "" + GetCurrencyinRequiredFormate("", true) + "NaN") {
            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
        }
    }

}

function TakeSellPrice(ddlObj, index) {

    var val = ddlObj.options[ddlObj.selectedIndex].text;

    for (var i = 0; i < 50; i++) {
        if (document.getElementById("spn_ToQty_" + i + "") != null) {
            var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
            if (Number(val) == Number(ToQty)) {
                var Cost = document.getElementById("spn_price_" + i + "").innerHTML.replace(/,/, '');

                var Markup = document.getElementById("spn_markup_" + i + "").innerHTML.replace(/,/, '');
                var Price = document.getElementById("spn_SellingPrice_" + i + "").innerHTML.replace(/,/, '');
                var Multiple = document.getElementById("ddlMultiple");
                var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;

                var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Price), 6, '', false, false, true);
                var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * Number(NoOFMultiple)), 6, '', false, false, true);
                TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPrice, 0, '', false, false, true); //roundNumber(Number(SellingPrice), 2);

                document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
                document.getElementById("spn_QtyCost_" + index + "").innerHTML = Cost;
                document.getElementById("spn_QtyMarkup_" + index + "").innerHTML = Markup;
                document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;

                break;
            }
            else {
                document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + "0.00";
            }
        }
        else {
            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
            document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + "0.00";
        }
    }
}

function TakeSellPrice_ForHandy(MainObjTextBox, val, index, Max) {
    var txtObj = document.getElementById("ddltxt_req_qty_" + index + "");

    if (document.getElementById("ddltxt_req_qty_temp_" + index + "").value.length > 0) {
        val = Number(document.getElementById("ddltxt_req_qty_temp_" + index + "").value);
    }

    var objno = 0;
    var objindex = 0;
    var ToQty = '';
    var IsQtyLess = 'no';
    if (Allow_Integer_Only(MainObjTextBox, false)) {
        for (var i = 0; i < 50; i++) {
            if (document.getElementById("spn_ToQty_" + i + "") != null) {
                ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                var maxQty = document.getElementById("spn_ToQty_" + (Max - 1) + "").innerHTML;
                var ToNextQty = '';
                if (i < Max - 1) {
                    ToNextQty = document.getElementById("spn_ToQty_" + (i + 1) + "").innerHTML;
                }
                if (Number(val) == Number(ToQty)) {
                    objno = i;
                    objindex = index;

                    break;
                }
                else if ((Number(val) < Number(ToQty)) && Number(val) != Number(ToQty)) {
                    objno = i;
                    objindex = index;
                    IsQtyLess = 'yes';
                    break;
                }
                else if (Number(val) > Number(ToQty) && Number(val) < Number(ToNextQty)) {
                    objno = i;
                    objindex = index;
                    break;
                }
                else if ((Number(val) > Number(maxQty))) {
                    if (i == Number(Max) - Number(1)) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else {
                        document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "$0.00";
                        document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "$0.00";
                    }
                }
            }
        }

        var hdnUnitOfMeasure = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnUnitOfMeasure");
        if (Number(hdnUnitOfMeasure.value) <= 0) {

            hdnUnitOfMeasure.value = 1;
        }

        if (Number(MainObjTextBox.value) < Number(hdnUnitOfMeasure.value)) {
            IsQtyLess = "yes";
        }
        else {
            IsQtyLess = "no";
        }



        //  if (MainObjTextBox.id.indexOf('_temp_') != -1) {
        val = document.getElementById("ddltxt_req_qty_" + index + "").value;
        document.getElementById("Labelqty" + index + "").innerHTML = val;

        //}

        if (IsQtyLess == 'yes') {
            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');

            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;

            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }
            Cost = (Number(Cost) / Number(ToQty)) * Number(val);
            Price = (Number(Price) / Number(ToQty)) * Number(val);

            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Price), 0, '', false, false, true);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * Number(NoOFMultiple)), 0, '', false, false, true);

            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
            IsQtyLess = 'no';
        }
        else {

            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');

            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;

            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }
            Cost = (Number(Cost) / Number(hdnUnitOfMeasure.value)) * Number(val);
            Price = (Number(Price) / Number(hdnUnitOfMeasure.value)) * Number(val);
            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Price), 0, '', false, false, true);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * Number(NoOFMultiple)), 0, '', false, false, true);
            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
        }
    }
    else {
        MainObjTextBox.value = "";
    }
}

function TakeSellPrice_Handy(MainObjTextBox, val, index, Max) {
    var txtObj = document.getElementById("ddltxt_req_qty_" + index + "");

    if (document.getElementById("ddltxt_req_qty_temp_" + index + "").value.length > 0) {
        val = Number(document.getElementById("ddltxt_req_qty_temp_" + index + "").value);
    }

    var objno = 0;
    var objindex = 0;
    var ToQty = '';
    var IsQtyLess = 'no';
    if (Allow_Integer_Only(MainObjTextBox, false)) {
        for (var i = 0; i < 50; i++) {
            if (document.getElementById("spn_ToQty_" + i + "") != null) {
                ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                var maxQty = document.getElementById("spn_ToQty_" + (Max - 1) + "").innerHTML;
                var ToNextQty = '';
                if (i < Max - 1) {
                    ToNextQty = document.getElementById("spn_ToQty_" + (i + 1) + "").innerHTML;
                }
                if (Number(val) == Number(ToQty)) {
                    objno = i;
                    objindex = index;

                    break;
                }
                else if ((Number(val) < Number(ToQty)) && Number(val) != Number(ToQty)) {
                    objno = i;
                    objindex = index;
                    IsQtyLess = 'yes';
                    break;
                }
                else if (Number(val) > Number(ToQty) && Number(val) < Number(ToNextQty)) {
                    objno = i;
                    objindex = index;
                    break;
                }
                else if ((Number(val) > Number(maxQty))) {
                    if (i == Number(Max) - Number(1)) {
                        objno = i;
                        objindex = index;
                        break;
                    }
                    else {
                        document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "$0.00";
                        document.getElementById("spn_Total_QtyPrice_" + index + "").innerHTML = "$0.00";
                    }
                }
            }
        }

        var hdnUnitOfMeasure = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnUnitOfMeasure");
        if (Number(hdnUnitOfMeasure.value) <= 0) {

            hdnUnitOfMeasure.value = 1;
        }

        if (Number(MainObjTextBox.value) < Number(hdnUnitOfMeasure.value)) {
            IsQtyLess = "yes";
        }
        else {
            IsQtyLess = "no";
        }



        //  if (MainObjTextBox.id.indexOf('_temp_') != -1) {
        val = document.getElementById("ddltxt_req_qty_" + index + "").value;
        document.getElementById("Labelqty" + index + "").innerHTML = val;

        //}

        if (IsQtyLess == 'yes') {
            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');

            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;

            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }
            Cost = (Number(Cost) / Number(ToQty)) * Number(val);
            Price = (Number(Price) / Number(ToQty)) * Number(val);

            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Price), 0, '', false, false, true);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * Number(NoOFMultiple)), 0, '', false, false, true);

            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
            IsQtyLess = 'no';
        }
        else {

            var Cost = document.getElementById("spn_price_" + objno + "").innerHTML.replace(/,/, '');

            var Markup = document.getElementById("spn_markup_" + objno + "").innerHTML.replace(/,/, '');
            var Price = document.getElementById("spn_SellingPrice_" + objno + "").innerHTML.replace(/,/, '');
            var Multiple = document.getElementById("ddlMultiple");
            var NoOFMultiple = Multiple.options[Multiple.selectedIndex].value;

            if (SimpleMatBrowserHandy == "yes" && NoOFMultiple == '2') {
                NoOFMultiple = '1.5';
            }
            Cost = (Number(Cost) / Number(hdnUnitOfMeasure.value)) * Number(val);
            Price = (Number(Price) / Number(hdnUnitOfMeasure.value)) * Number(val);
            var SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Price), 0, '', false, false, true);
            var TotalPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (SellPrice * Number(NoOFMultiple)), 0, '', false, false, true);
            document.getElementById("spn_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + objindex + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + objindex + "").innerHTML = Markup;
            document.getElementById("spn_Total_QtyPrice_" + objindex + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalPrice;
        }
    }
    else {
        MainObjTextBox.value = "";
    }
}

function Copy_ItemTitle_Price(values) {
    //txtCatalogueItemTitleID.value = values;
}
function Copy_Description_Price(values) {
    //txtCatalogueDesign.value = values;
}
function Copy_Artwork_Price(values) {
    //txtCatalogueArtwork.value = values;
}
function Copy_Color_Price(values) {
    // txtCatalogueColour.value = values;
}
function Copy_Size_Price(values) {
    //txtCatalogueSize.value = values;
}
function Copy_Material_Price(values) {
    //txtCatalogueMaterial.value = values;
}
function Copy_Delivery_Price(values) {
    //txtCatalogueDelivery.value = values;
}
function Copy_Finishing_Price(values) {
    //txtCatalogueFinishing.value = values;
}
function Copy_Notes_Price(values) {
    //txtCatalogueNotes.value = values;
}
function Copy_Instructions_Price(values) {
    //txtCatalogueInstructions.value = values;
}
function CopyToItemDescription() {

}

function showTotalCostPrice() {
    var MultipleOf = document.getElementById("ddlMultiple").value;
    if (SimpleMatBrowserHandy == "yes" && MultipleOf == '2') {
        MultipleOf = '1.5';
    }
    //    if(Number(MultipleOf)!=0)
    //    {        
    for (var i = 1; i < 5; i++) {
        var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
        if (Number(SellingPrice) != 0) {
            SellingPrice = Number(SellingPrice) * Number(MultipleOf);
            SellingPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true); //roundNumber(Number(SellingPrice), 2);
            document.getElementById("spn_Total_QtyPrice_" + i + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        }
    }
    //    }
}



//======================================> PRICE CATALOGUE ENDS HERE <==============================================

//Price for Whole Pack and  Paper Supplied 
function checkchanged() {
    if (ChkPriceForWholePack.checked) {
        ChkPaperSupplied.checked = false;
    }
    else {
        ChkPriceForWholePack.checked = false;
    }
}
function checkchanged1() {
    if (ChkPaperSupplied.checked) {
        ChkPriceForWholePack.checked = false;
    }
    else {
        ChkPaperSupplied.checked = false;
    }
}
function SendGuillotineIDandName(id, values) {
    lblGuillotine.title = values;
    lblGuillotine.innerHTML = values;
    lblGuillotine.style.cursor = "default";
    if (lblGuillotine.innerHTML.length > 25) {
        lblGuillotine.innerHTML = lblGuillotine.innerHTML.substring(0, 25) + "...";
    }
    hid_GuillotineID.value = id;
    div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";
}

//// ================= TASK ADD ============================
var TaskAddData = '';
function OpenTaskPage(OnorOff) {

    if (OnorOff) {
        if (document.getElementById("div_task_add").style.display == "block") {
            document.getElementById("div_task_add").style.display = "none";
        }
        else {
            document.getElementById("div_task_add").style.display = "block";
            if (TaskAddData == '') {
                document.getElementById("hrefEditTask").style.display = "none";
            }
            else {
                document.getElementById("hrefEditTask").style.display = "block";
            }
        }
    }
    else {
        document.getElementById("div_task_add").style.display = "none";
        document.getElementById("hrefEditTask").style.display = "none";
    }
}
function CloseTaskPage() {
    if (TaskAddData == '') {
        chk_FollowupTask.checked = false;
        document.getElementById("div_task_add").style.display = "none";
    }
    else {
        document.getElementById("div_task_add").style.display = "none";
    }
}

////=================================================================
function SendPhraseBook(id, values, phrasetype, tooltip) {
    if (tempEstimateType == '') {
        tempEstimateType = estimateType;
    }
    values = trim12(values);
    if (tempEstimateType == 'digital' && productType == 'singleitem') {
        if (phrasetype == 'Estimate Title') {
            txtSummaryItemTitle.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtSummaryArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtSummaryDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtSummaryColor.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtSummaryItemSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtSingleMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtSummaryDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtSummaryFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtSummaryNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtSummaryInstructions.value = values;
        }
    }
    else if (tempEstimateType == 'digital' && productType == 'booklet') {
        if (phrasetype == 'Estimate Title') {
            txtbookletItemTitleID.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtbookletArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtbookletDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtbookletColor.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtbookletSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtbookletMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtbookletDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtbookletFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtbookletNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtbookletInstructions.value = values;
        }
    }
    else if (tempEstimateType == 'digital' && productType == 'pads') {
        if (phrasetype == 'Estimate Title') {
            txtPadItemTitle.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtPadArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtPadDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtPadColor.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtPadItemSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtPadMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtPadDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtPadFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtPadNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtPadInstructions.value = values;
        }
    }
    if (tempEstimateType == 'largeformat') {
        if (phrasetype == 'Estimate Title') {
            txtLargeItemTitle.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtLargeArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtLargeDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtLargeColor.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtLargeSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtLargeMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtLargeDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtLargeFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtLargeNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtLargeInstructions.value = values;
        }
    }

    if (tempEstimateType == 'printbroker') {
        SendPhraseBookToPB(id, values, phrasetype, tooltip);
    }
    if (tempEstimateType == 'warehouse') {
        if (phrasetype == 'Estimate Title') {
            txtWareItemTitleID.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtWareArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtWareDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtWareColour.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtWareSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtWareMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtWareDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtWareFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtWareNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtWareInstructions.value = values;
        }
    }
    if (tempEstimateType == 'othercost') {
        if (phrasetype == 'Estimate Title') {
            txtCostItemTitleID.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtCostArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtCostDescription.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtCostColour.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtCostSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtCostMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtCostDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtCostFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtCostNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtCostInstructions.value = values;
        }
    }
    if (tempEstimateType == 'pricecatalogue') {
        if (phrasetype == 'Estimate Title') {
            txtCatalogueItemTitleID.value = values;
        }
        if (phrasetype == 'Estimate Artwork') {
            txtCatalogueArtwork.value = values;
        }
        if (phrasetype == 'Estimate Description') {
            txtCatalogueDesign.value = values;
        }
        if (phrasetype == 'Estimate Colours') {
            txtCatalogueColour.value = values;
        }
        if (phrasetype == 'Estimate Size') {
            txtCatalogueSize.value = values;
        }
        if (phrasetype == 'Estimate Material') {
            txtCatalogueMaterial.value = values;
        }
        if (phrasetype == 'Estimate Delivery') {
            txtCatalogueDelivery.value = values;
        }
        if (phrasetype == 'Estimate Finishing') {
            txtCatalogueFinishing.value = values;
        }
        if (phrasetype == 'Estimate Notes') {
            txtCatalogueNotes.value = values;
        }
        if (phrasetype == 'Estimate Terms') {
            txtCatalogueInstructions.value = values;
        }
    }
}


//// ===========================   Warehouse Details js     ===========================
var warearray = new Array();

function ShowWarehouse() {
    //document.getElementById("div_stage_2").style.display = "none";
    document.getElementById(div_StockOnly).style.display = "block";

    Call_Warehouse_Ind_fun("ware_1");
}
function WarehouseAddButton(AddType) {
    if (CheckReqCompare(txtWarehouseQuantity.value, 'spn_txtWarehouseQuantity', 'spn_txtWarehouseQuantity_number')) {
        return false;
    }
    else {
        if (AddType == "add") {
            WarehouseSelectedItem(WareID1, WareName1, WareType1, UnitPrice1, WareItemID1, PackedInQty1);
            WareID = ''; WareName = ''; WareType = ''; UnitPrice1 = '', WareItemID1 = 0, PackedInQty1 = 0;
            document.getElementById("div_inventory_select").style.display = "none";
            //SAVE ITEMS

            //            if (IsWareDirect) {
            //                document.getElementById(div_StockOnly).style.display = "none";
            //                document.getElementById("div_stage_4").style.display = "block";
            //                document.getElementById(div_WarehouseSummary).style.display = "block";
            //                document.getElementById("lblheader").innerHTML = "Customer Item Description";

            //                BindWarehouseDesc(); //To bind item desc from settings//
            //            }
            //            else {
            //                WarehousePrevious();
            //            }

        }
        else if (AddType == "more") {
            WarehouseSelectedItem(WareID1, WareName1, WareType1, UnitPrice1, WareItemID1, PackedInQty1);
            WareID = ''; WareName = ''; WareType = ''; UnitPrice1 = '', WareItemID1 = 0, PackedInQty1 = 0;
            document.getElementById("div_inventory_select").style.display = "none";
        }
    }
}

function ShowAddPanel_Estimate(WID, WName, WType, UPrice, packedin, PackedInQty) {
    var div_inventory_select = document.getElementById("div_inventory_select");
    MakeDivMiddle(div_inventory_select);
    div_inventory_select.style.display = "block";
    WareID1 = WID;
    WareName1 = WName;
    WareType1 = WType;
    UnitPrice1 = UPrice;
    PackedInQty1 = PackedInQty;
    txtWarehouseQuantity.value = packedin;
    txtWarehouseQuantity.focus();
}

function CloseAddPanel_Estimate() {
    document.getElementById("div_inventory_select").style.display = "none";
    WareID = ''; WareName = ''; WareType = '';
    document.getElementById("div_none").style.display = "none";
    txtWarehouseQuantity.value == '';
}

//// WAREHOUSE ARRAY
function wareClass() {
    this.ItemName;
    this.ItemID;
    this.Quantity;
    this.WareType;
    this.WareValue;
    this.WareItemID;
    this.PackedInQty;
    this.IsDeleted = 0;
}

//The Following Function is Called in "inventory_store_customer_view.ascx"
function WarehouseSelectedItem(WareID, WareName, WareType, Warevalue, WareItemID, PackedInQty) {
    //Collect the Data
    //============================================================================        
    var objWare = new wareClass();
    objWare.ItemName = WareName;

    objWare.ItemID = WareID;
    objWare.Quantity = txtWarehouseQuantity.value;
    objWare.WareType = WareType;
    objWare.WareValue = Warevalue; //Unit Price
    objWare.WareItemID = WareItemID; //EstWareItemID
    objWare.PackedInQty = PackedInQty;
    objWare.IsDeleted = 0;
    warearray.push(objWare);


    if (estimateType == "warehouse") {
        LoadWareMainItemListOnEdit();
    }
    else {
        LoadEditedWare(); //GenHTML();
        document.getElementById("href_showware").style.display = "block";
    }
    txtWarehouseQuantity.value = '';
    //============================================================================   

}

function RemoveWare(nos) {
    if (estimateType == "warehouse") {
        if (warearray[nos].WareItemID != "0") {
            //Delete_Ware_MainItem_WebMethod(nos);
            warearray[nos].IsDeleted = "1";
            LoadWareMainItemListOnEdit(nos);
        }
        else {
            warearray.splice(nos, 1);
            LoadWareMainItemListOnEdit();
        }
        if (warearray.length == "0") {
            document.getElementById("href_showware_MainItem").style.display = "none";
        }
    }
    else {
        warearray.splice(nos, 1);
        LoadEditedWare(); //GenHTML();
        if (warearray.length == "0") {
            document.getElementById("href_showware").style.display = "none";
        }
    }
}

//=========== DEFAULT SELECTION OF ESTIMATE TYPE FROM SETTINGS ==============

function DefaultSettings() {
    productType = "";
    var strArr_1 = hid_DefaultSettings.value.split('µ');
    for (var i = 0; i < strArr_1.length; i++) {
        var strArr_2 = strArr_1[i].split('»');
        if (strArr_2[0] == "DefaultPriceForWholePack") {
            ChkPriceForWholePack.checked = strArr_2[1] == "1" ? true : false;
        }
        else if (strArr_2[0] == "DefaultEstimateType") {
            var strtype = strArr_2[1];
            if (strtype == "S" || strtype == "P" || strtype == "B") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "digital") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "digital";
                        ShowEstimate("digital");
                    }
                }

                if (strtype == "S") {
                    productType = "singleitem";
                    ProductTypeShow(productType);
                    for (var k = 0; k < DdlProductType.length; k++) {
                        if (DdlProductType.options[k].value == productType) {
                            DdlProductType.selectedIndex = k;
                        }
                    }

                }
                else if (strtype == "P") {
                    productType = "pads";
                    ProductTypeShow(productType);
                    for (var k = 0; k < DdlProductType.length; k++) {
                        if (DdlProductType.options[k].value == productType) {
                            DdlProductType.selectedIndex = k;
                        }
                    }
                }
                else if (strtype == "B") {
                    productType = "booklet";
                    ProductTypeShow(productType);
                    for (var k = 0; k < DdlProductType.length; k++) {
                        if (DdlProductType.options[k].value == productType) {
                            DdlProductType.selectedIndex = k;
                        }
                    }
                }
            }
            else if (strtype == "L") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "largeformat") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "largeformat";
                        ShowEstimate("largeformat");
                    }
                }
            }
            else if (strtype == "O") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "printbroker") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "printbroker";
                        ShowEstimate("printbroker");
                        CreateItemNext();
                    }
                }
            }
            else if (strtype == "U") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "othercost") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "othercost";
                        ShowEstimate("othercost");
                        CreateItemNext();
                    }
                }
            }
            else if (strtype == "W") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "warehouse") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "warehouse";
                        ShowEstimate("warehouse");
                        CreateItemNext();
                    }
                }
            }
            else if (strtype == "C") {
                for (var k = 0; k < ddlEstimateType.length; k++) {
                    if (ddlEstimateType.options[k].value == "pricecatalogue") {
                        ddlEstimateType.selectedIndex = k;
                        estimateType = "pricecatalogue";
                        ShowEstimate("pricecatalogue");
                        CreateItemNext();
                    }
                }
            }
        }
    }
    //FOR SUMMARY USE BY VINAY ON 24 / 02 / 2010s
    ItemSize_AssignToSummary();
    Color_AssignToSummary();
    Paper_AssignToSummary();
}

////======================= PRICE CATALOGUE =================================

function SvaeCatalogue() {

    var priceCatID = 0;
    if (document.getElementById('ctl00_ContentPlaceHolder1_ctl00_hdn_returnboolvalue').value == 'false') {
        return false;
    }
    else {
        var Data = '';

        for (var i = 0; i < Price_Array.length; i++) {
            var objArr = Price_Array[i];
            priceCatID = objArr.PriceCatalogueID;
            Data += "PriceCatalogueID»" + objArr.PriceCatalogueID + "±";
            Data += "Quantity»" + objArr.Quantity + "±";
            Data += "Price»" + roundNumber(objArr.Price, 2) + "±";
            Data += "Cost»" + objArr.Cost + "±";
            Data += "CatalogueName»" + objArr.CatalogueName + "±";
            Data += "MultipleOf»" + objArr.MultipleOf + "±";
            Data += "Markup»" + objArr.Markup + "±";
            Data += "Height»" + objArr.Height + "±";
            Data += "Width»" + objArr.Width + "±";
            //if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1 && (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "job")) {
            //    Data += "ReplenishProduct»" + objArr.ReplenishProduct + "±";
            //} else {
            //    Data += "ReplenishProduct»false±";
            //}
            Data += "ReplenishProduct»" + objArr.ReplenishProduct + "±";
            Data += "QtyusedforCalculation»" + objArr.QtyusedforCalculation + "µ";
        }

        if (Data == '') {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity.";
            document.getElementById("div_price_qty_valid").style.display = "block";
            loadingimg('div_btnsaveloading', 'divsave');
            return false;
        }
        else {
            hidCatalogueData.value = Data;

            //To give loading button on save click in popup
            if (document.getElementById("ds00") != null) {
                document.getElementById("ds00").style.width = (window.screen.availWidth) * 2 + "px";
                document.getElementById("ds00").style.height = (window.screen.availHeight) * 2 + "px";
                document.getElementById("ds00").style.display = "block";
            }
            if (document.getElementById("div_Load") != null) {
                document.getElementById("div_Load").style.display = "block";
            }
            //alert(RequestType + '-' + modulename + '-' + ManageStockPermission + '-' + StockCancellationType + '-' + priceCatID + '-' + hid_OldPriceCatalogueID.value);

            //            if (RequestType == 'edit') {
            //                if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
            //                    if (ManageStockPermission == 1) {
            //                        if (StockCancellationType.toString().toLowerCase() == "p" && priceCatID != hid_OldPriceCatalogueID.value) {
            //                            if (window.confirm('Do you want the quantity to be added back to the Stock?')) {
            //                                hdn_stockBackwarehoue.value = "yes";
            //                            }
            //                            else {
            //                                hdn_stockBackwarehoue.value = "no";
            //                            }
            //                        }
            //                    }
            //                }
            //            }

            // __doPostBack('ctl00$ContentPlaceHolder1$PriceCatalog$lnkCatalogueFinish', '');
            if (window.parent.document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_Chk_ItemDescn") != null) {
                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_chkitemdescription").value = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_PriceCatalog_Chk_ItemDescn").checked;
            }
            if (document.getElementById("chk_Update_Item_Descriptions") != null) {
                document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_Update_Item_Descriptions").value = document.getElementById("chk_Update_Item_Descriptions").checked;
            }
            __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkCatalogueFinish', '');
            return true;
        }
    }
}
//// ==================== PRICE CATALOGUE ENDS ===============================
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

//// ==================== TASK STARTS ===============================
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

        var subject = ddlsubject.value == "" ? "0" : ddlsubject.options[ddlsubject.selectedIndex].text;
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
        document.getElementById("div_task_add").style.display = "none";
        document.getElementById("hrefEditTask").style.display = "block";
    }
    return false;
}
function show_hide_subject(distype) {
    var div_subject = document.getElementById("div_SubjectTable");
    div_subject.style.display = "none";
    if (distype == "show") {
        txtSubject.value = "";
        div_subject.style.display = "block";
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
//// ==================== TASK ENDS ===============================

////sperate for ware house by kumar

function SaveDataForWarehouse() {
    var wareData = '';

    for (var p = 0; p < warearray.length; p++) {
        wareData += "WarehouseType »" + warearray[p].WareType + '±';
        wareData += "WarehouseID »" + warearray[p].ItemID + '±';
        wareData += "Quantity »" + warearray[p].Quantity + '±';
        wareData += "WarehouseName »" + warearray[p].ItemName + '±';
        wareData += "UnitPrice »" + warearray[p].WareValue + '±';
        wareData += "PackedInQty »" + warearray[p].PackedInQty + '±';
        wareData += "IsDeleted »" + warearray[p].IsDeleted + '±';

        var WareItemID = 0;
        if (warearray[p].WareItemID != '') {
            WareItemID = warearray[p].WareItemID;
        }
        else {
            WareItemID = 0;
        }
        wareData += "WarehouseItemID »" + WareItemID + 'µ';
    }
    if (wareData != '') {
        hid_warehouse_save.value = wareData;
    }
    return true;
}

function TogetMainItemQuatity_forAdditional(MainItemQty, MatrixType, PriceListRows) {
    var Quantity1 = "";
    var Quantity2 = "";
    var Quantity3 = "";
    var Quantity4 = "";
    var TotalQuantity = 0;

    if (MainItemQty != "") {
        var str1 = MainItemQty.split('µ');
        for (var i = 0; i <= str1.length - 1; i++) {
            TotalQuantity = str1.length - 1;

            if (str1[i] != "") {
                var str2 = str1[i].split('~');

                if (i == 0) {
                    Quantity1 = str2[0];
                }
                if (i == 1) {
                    Quantity2 = str2[0];
                }
                if (i == 2) {
                    Quantity3 = str2[0];
                }
                if (i == 3) {
                    Quantity4 = str2[0];
                }

            }
        }

        for (var j = 1; j <= Number(TotalQuantity); j++) {
            if (MatrixType == "P") {
                var txt_req_qty = document.getElementById("txt_req_qty_" + j + "");
                if (j == 1) {

                    txt_req_qty.value = Quantity1;
                    CalculateQtyPrice(Quantity1, '1', PriceListRows);
                }
                if (j == 2) {

                    txt_req_qty.value = Quantity2;
                    CalculateQtyPrice(Quantity2, '2', PriceListRows);
                }
                if (j == 3) {

                    txt_req_qty.value = Quantity3;
                    CalculateQtyPrice(Quantity3, '3', PriceListRows);
                }
                if (j == 4) {

                    txt_req_qty.value = Quantity4;
                    CalculateQtyPrice(Quantity4, '4', PriceListRows);
                }
            }
            else if (MatrixType == "G") {
                var txt_req_qty = document.getElementById("txt_req_qty_" + j + "");
                if (j == 1) {

                    txt_req_qty.value = Quantity1;
                    CalculateQtyPrice(Quantity1, '1', PriceListRows);
                }
                if (j == 2) {

                    txt_req_qty.value = Quantity2;
                    CalculateQtyPrice(Quantity2, '2', PriceListRows);
                }
                if (j == 3) {

                    txt_req_qty.value = Quantity3;
                    CalculateQtyPrice(Quantity3, '3', PriceListRows);
                }
                if (j == 4) {

                    txt_req_qty.value = Quantity4;
                    CalculateQtyPrice(Quantity4, '4', PriceListRows);
                }
            }
            else {
                if (SimpleMatBrowserHandy == "yes") {
                    var ddltxt_req_qty = document.getElementById("ddltxt_req_qty_" + j + "");
                    if (j == 1) {
                        ddltxt_req_qty.value = Quantity1;
                        TakeSellPrice_ForHandy(Quantity1, '1', PriceListRows);
                    }
                    if (j == 2) {
                        ddltxt_req_qty.value = Quantity2;
                        TakeSellPrice_ForHandy(Quantity2, '2', PriceListRows);
                    }
                    if (j == 3) {
                        ddltxt_req_qty.value = Quantity3;
                        TakeSellPrice_ForHandy(Quantity3, '3', PriceListRows);
                    }
                    if (j == 4) {
                        ddltxt_req_qty.value = Quantity4;
                        TakeSellPrice_ForHandy(Quantity4, '4', PriceListRows);
                    }
                }
                else {
                    var ddl_req_qty = document.getElementById("ddl_req_qty_" + j + "");
                    if (j == 1) {
                        ddl_req_qty.selectedIndex = 0;
                        for (var ddl = 0; ddl <= ddl_req_qty.length - 1; ddl++) {
                            if (Number(Quantity1) == Number(ddl_req_qty[ddl].text)) {
                                ddl_req_qty.selectedIndex = ddl;
                            }
                        }
                        TakeSellPrice(ddl_req_qty, '1');
                    }
                    if (j == 2) {
                        ddl_req_qty.selectedIndex = 0;
                        for (var ddl = 0; ddl <= ddl_req_qty.length - 1; ddl++) {
                            if (Number(Quantity2) == Number(ddl_req_qty[ddl].text)) {
                                ddl_req_qty.selectedIndex = ddl;
                            }
                        }
                        TakeSellPrice(ddl_req_qty, '2');
                    }
                    if (j == 3) {
                        ddl_req_qty.selectedIndex = 0;
                        for (var ddl = 0; ddl <= ddl_req_qty.length - 1; ddl++) {
                            if (Number(Quantity3) == Number(ddl_req_qty[ddl].text)) {
                                ddl_req_qty.selectedIndex = ddl;
                            }
                        }
                        TakeSellPrice(ddl_req_qty, '3');
                    }
                    if (j == 4) {
                        ddl_req_qty.selectedIndex = 0;
                        for (var ddl = 0; ddl <= ddl_req_qty.length - 1; ddl++) {
                            if (Number(Quantity4) == Number(ddl_req_qty[ddl].text)) {
                                ddl_req_qty.selectedIndex = ddl;
                            }
                        }
                        TakeSellPrice(ddl_req_qty, '4');
                    }
                }
            }
        }
        //final calculation
        showTotalCostPrice();
    }
}

//==================================For Addtional Option Group Calculation=======================================================================
function ForAdditional_Grouping(GroupID, OtherCostID) {

    if (Number(GroupID) != 0) {

        //For Matrix Type
        if (Number(hid_MatrixLenght.value) != 0) {
            for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
                var MultipleGroupID = document.getElementById("lblMatrixGroupID_" + k + "").innerHTML;
                var MatrixOthercostID = document.getElementById("lblMatrixID_" + k).innerHTML;
                if (Number(MatrixOthercostID) == Number(OtherCostID)) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MatrixOthercostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.checked = false;
                    MatrixCheck.setAttribute("grpvalue", "0");
                    document.getElementById("lblMatrixPrice1_" + k + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Multiple Choice Type
        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var MultipleGroupID = document.getElementById("lblMultipleGroupID_" + j + "").innerHTML;
                var MultipleOtherCostID = document.getElementById("lblMultipleID_" + j + "").innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
                if (Number(MultipleOtherCostID) == Number(OtherCostID)) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    ddlMultiple.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MultipleOtherCostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
                    chkMultiple.checked = false;
                    ddlMultiple.selectedIndex = 0;
                    ddlMultiple.setAttribute("grpvalue", "0");
                    document.getElementById("lblMultiplePrice1_" + j + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Question Type
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionGroupID = document.getElementById("lblQuestionGroupID_" + i + "").innerHTML;
                var QuestionOtherCostID = document.getElementById("lblQuestionID_" + i + "").innerHTML;

                var txtQuestion = document.getElementById("txtQuestion_" + i + "");
                if (Number(QuestionOtherCostID) == Number(OtherCostID)) {
                    txtQuestion.setAttribute("grpvalue", "1");
                }

                if (Number(QuestionGroupID) == Number(GroupID) && Number(QuestionOtherCostID) != Number(OtherCostID) && Number(QuestionGroupID) != 0) {
                    document.getElementById("txtQuestion_" + i + "").value = "";
                    document.getElementById("lblPrice1_" + i + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    txtQuestion.setAttribute("grpvalue", "0");
                }
            }
        }
    }
}


//=========================================================================================================
//To Fetch Additional option from Product Catalog for a single customer ----------By Shashidhar.M.G--------

var TempSubTotal1 = 0;
var QtyStartsfrom = 0;

function Tocall_mainFunc() {


    var MainQuantity = 0;

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");

    if (hid_matixType.value == "S") {

        if (hdn_IsCumulative.value == "true") {
            var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
            MainQuantity = ddl_req_qty_1.value;
        } else {
            var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
            MainQuantity = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
        }

        var ddl_req_qty_1 = '';
        var ddl_req_qty_2 = '';
        var ddl_req_qty_3 = '';
        var ddl_req_qty_4 = '';

        if (SimpleMatBrowserHandy != 'yes') {

            if (hdn_IsCumulative.value == "true") {
                ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                ddl_req_qty_1 = ddl_req_qty_1.value;
                ddl_req_qty_2 = ddl_req_qty_2.value;
                ddl_req_qty_3 = ddl_req_qty_3.value;
                ddl_req_qty_4 = ddl_req_qty_4.value;
            } else {
                ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                ddl_req_qty_1 = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
                ddl_req_qty_2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
                ddl_req_qty_3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
                ddl_req_qty_4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
            }
        }
        else {
            ddl_req_qty_1 = document.getElementById("ddltxt_req_qty_1");
            ddl_req_qty_2 = document.getElementById("ddltxt_req_qty_2");
            ddl_req_qty_3 = document.getElementById("ddltxt_req_qty_3");
            ddl_req_qty_4 = document.getElementById("ddltxt_req_qty_4");

            ddl_req_qty_1 = ddl_req_qty_1.value;
            ddl_req_qty_2 = ddl_req_qty_2.value;
            ddl_req_qty_3 = ddl_req_qty_3.value;
            ddl_req_qty_4 = ddl_req_qty_4.value;
        }

        if (hid_QuestionLenght.value != "0") {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var ddl_req_qty = ddl_req_qty_1 + '~' + ddl_req_qty_2 + '~' + ddl_req_qty_3 + '~' + ddl_req_qty_4;
                    ddl_req_qty = ddl_req_qty.split('~');
                    if (ddl_req_qty[k] == 'select' || ddl_req_qty[k] == '') {
                        document.getElementById("lblPrice" + j + "_" + i + "").style.display = "none";
                        document.getElementById("lbltotal" + j + "").style.display = "none";
                    }
                    else {
                        document.getElementById("lblPrice" + j + "_" + i + "").style.display = "block";
                        document.getElementById("lbltotal" + j + "").style.display = "block";
                    }
                }
            }
        }
        if (hid_MatrixLenght.value != "0") {
            for (var i = 0; i <= Number(hid_MatrixLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var ddl_req_qty = ddl_req_qty_1 + '~' + ddl_req_qty_2 + '~' + ddl_req_qty_3 + '~' + ddl_req_qty_4;
                    ddl_req_qty = ddl_req_qty.split('~');
                    if (ddl_req_qty[k] == 'select' || ddl_req_qty[k] == '') {
                        document.getElementById("lblMatrixPrice" + j + "_" + i + "").style.display = "none";
                        document.getElementById("lbltotal" + j + "").style.display = "none";
                    }
                    else {
                        document.getElementById("lblMatrixPrice" + j + "_" + i + "").style.display = "block";
                        document.getElementById("lbltotal" + j + "").style.display = "block";
                    }
                }
            }
        }

        if (Number(hid_MultipleLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var ddl_req_qty = ddl_req_qty_1 + '~' + ddl_req_qty_2 + '~' + ddl_req_qty_3 + '~' + ddl_req_qty_4;
                    ddl_req_qty = ddl_req_qty.split('~');

                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                        if (ddl_req_qty[k] == 'select' || ddl_req_qty[k] == '') {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '' &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                        document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "none";
                                    }
                                }
                                else {
                                    document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = "none";
                                }
                            }
                            document.getElementById("lbltotal" + j + "").style.display = "none";
                        }
                        else {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '' &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                        document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";
                                    }
                                }
                                else {
                                    document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = "block";
                                }
                            }
                            document.getElementById("lbltotal" + j + "").style.display = "block";
                        }
                    }
                    else {
                        if (ddl_req_qty[k] == 'select' || ddl_req_qty[k] == '') {
                            document.getElementById("lblMultiplePrice" + j + "_" + i + "").style.display = "none";
                            document.getElementById("lbltotal" + j + "").style.display = "none";
                        }
                        else {
                            document.getElementById("lblMultiplePrice" + j + "_" + i + "").style.display = "block";
                            document.getElementById("lbltotal" + j + "").style.display = "block";
                        }
                    }
                }
            }
        }
    }
    else {

        MainQuantity = document.getElementById("txt_req_qty_1").value;

        var LabelqtyPricetxt1 = document.getElementById("LabelqtyPricetxt1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
        var LabelqtyPricetxt2 = document.getElementById("LabelqtyPricetxt2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
        var LabelqtyPricetxt3 = document.getElementById("LabelqtyPricetxt3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
        var LabelqtyPricetxt4 = document.getElementById("LabelqtyPricetxt4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

        if (hid_QuestionLenght.value != "0") {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var LabelqtyPricetxt = LabelqtyPricetxt1 + '~' + LabelqtyPricetxt2 + '~' + LabelqtyPricetxt3 + '~' + LabelqtyPricetxt4;
                    LabelqtyPricetxt = LabelqtyPricetxt.split('~');
                    if (LabelqtyPricetxt[k] == '') {
                        document.getElementById("lblPrice" + j + "_" + i + "").style.display = "none";
                        document.getElementById("lbltotal" + j + "").style.display = "none";
                    }
                    else {
                        document.getElementById("lblPrice" + j + "_" + i + "").style.display = "block";
                        document.getElementById("lbltotal" + j + "").style.display = "block";
                    }
                }
            }
        }
        if (hid_MatrixLenght.value != "0") {
            for (var i = 0; i <= Number(hid_MatrixLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var LabelqtyPricetxt = LabelqtyPricetxt1 + '~' + LabelqtyPricetxt2 + '~' + LabelqtyPricetxt3 + '~' + LabelqtyPricetxt4;
                    LabelqtyPricetxt = LabelqtyPricetxt.split('~');
                    if (LabelqtyPricetxt[k] == '') {
                        document.getElementById("lblMatrixPrice" + j + "_" + i + "").style.display = "none";
                        document.getElementById("lbltotal" + j + "").style.display = "none";
                    }
                    else {
                        document.getElementById("lblMatrixPrice" + j + "_" + i + "").style.display = "block";
                        document.getElementById("lbltotal" + j + "").style.display = "block";
                    }
                }
            }
        }

        if (hid_MultipleLenght.value != "0") {
            for (var i = 0; i <= Number(hid_MultipleLenght.value) - 1; i++) {
                for (var j = 1; j <= 4; j++) {
                    var k = j - 1;
                    var LabelqtyPricetxt = LabelqtyPricetxt1 + '~' + LabelqtyPricetxt2 + '~' + LabelqtyPricetxt3 + '~' + LabelqtyPricetxt4;
                    LabelqtyPricetxt = LabelqtyPricetxt.split('~');
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                        if (LabelqtyPricetxt[k] == '') {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '' &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                        document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "none";
                                    }
                                } else {
                                    document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = "none";
                                }
                            }
                            document.getElementById("lbltotal" + j + "").style.display = "none";
                        }
                        else {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i);
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].value != undefined &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value != null &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].value.trim() != '' &&
                                ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != '---select---') {
                                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                        document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).style.display = "block";
                                    }
                                } else {
                                    document.getElementById("lblMultiplePrice" + j + "_" + i + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = "block";
                                }
                            }
                            document.getElementById("lbltotal" + j + "").style.display = "block";
                        }
                    } else {
                        if (LabelqtyPricetxt[k] == '') {
                            document.getElementById("lblMultiplePrice" + j + "_" + i + "").style.display = "none";
                            document.getElementById("lbltotal" + j + "").style.display = "none";
                        }
                        else {
                            document.getElementById("lblMultiplePrice" + j + "_" + i + "").style.display = "block";
                            document.getElementById("lbltotal" + j + "").style.display = "block";
                        }
                    }
                }
            }
        }
    }

    Tocalculate_totalPrice(MainQuantity);
}

function Tocalculate_totalPrice(Qty) {

    var hid_qtyFromList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_qtyFromList");
    var hid_qtyToList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_qtyToList");
    var hid_priceList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_priceList");
    var hid_CostExcMarkupList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_CostExcMarkupList");
    var hid_MarkupList = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MarkupList");
    var hid_Markup = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_Markup");

    var arrQtyFrom = hid_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var arrCost = hid_CostExcMarkupList.value.split('µ');
    var arrPrice = hid_priceList.value.split('µ');
    var arrMarkup = hid_MarkupList.value.split('µ');

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup");
    var hid_QuantityPriceExcMarkup2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup2");
    var hid_QuantityPriceExcMarkup3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup3");
    var hid_QuantityPriceExcMarkup4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup4");

    var hid_QuantityPrice1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice1");
    var hid_QuantityPrice2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice2");
    var hid_QuantityPrice3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice3");
    var hid_QuantityPrice4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice4");

    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");

    for (var i = 0; i < arrQtyFrom.length - 1; i++) {
        if (hid_matixType.value == "P") {
            //            alert("Number(arrQtyFrom[i])=" + arrQtyFrom);
            if (Qty != '' && Number(Qty)) {
                if (i == 0) {
                    QtyStartsfrom = Number(arrQtyFrom[i]);

                }
                if (Number(Qty) <= Number(arrQtyFrom[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else {
                    if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice1.value = ActualPrice;
                        break;
                    }
                    else {
                        hid_QuantityPrice1.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                        hid_Markup.value = "0";
                    }
                }
            }
            else {

                if (!Number(Qty)) {

                    document.getElementById("txt_req_qty_1").value = "";
                }
                hid_QuantityPrice1.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";
            }
        }
        else if (hid_matixType.value == "G") {
            //            alert("Number(arrQtyFrom[i])=" + arrQtyFrom);
            if (Qty != '' && Number(Qty)) {
                if (i == 0) {
                    QtyStartsfrom = Number(arrQtyFrom[i]);

                }
                if (Number(Qty) <= Number(arrQtyFrom[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice1.value = ActualPrice;
                    break;
                }
                else {
                    if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice1.value = ActualPrice;
                        break;
                    }
                    else {
                        hid_QuantityPrice1.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                        hid_Markup.value = "0";
                    }
                }
            }
            else {

                if (!Number(Qty)) {

                    document.getElementById("txt_req_qty_1").value = "";
                }
                hid_QuantityPrice1.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";
                hid_Markup.value = "0";
            }
        }
        else {
            if (hdn_IsCumulative.value == "true") {
                if (Qty != '' && Number(Qty)) {
                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }

                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice1.value = ActualPrice;
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice1.value = ActualPrice;
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice1.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            //hid_QuantityPrice1.value = Number(Qty) * Number(arrPrice[i]);
                            hid_QuantityPrice1.value = ActualPrice;
                            break;
                        }
                        else {
                            hid_QuantityPrice1.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            hid_Markup.value = "0";
                        }
                    }
                }
                else {
                    hid_QuantityPrice1.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    hid_Markup.value = "0";
                }
            } else {
                var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var sellingPrice = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].value.split('~');
                hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                hid_QuantityPrice1.value = sellingPrice[1];
                QtyStartsfrom = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var l = 0; l <= hid_MatrixLenght.value - 1; l++) {
            var lblMatrixID = document.getElementById("lblMatrixID_" + l + "").innerHTML;
            var lblMatrixType = document.getElementById("lblMatrixType_" + l + "").innerHTML;
            MatrixCheck_value(lblMatrixID, l, lblMatrixType);
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= Number(hid_MultipleLenght.value) - 1; c++) {
            Onchange_MultipleChoice_SubTotal(c); //For <Subtotal> Calculation
            Onchange_MultipleChoice(c, TempSubTotal1);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;
            var FormulaTag = Formula;
            //   for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replaceAll(' ', '').replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</quantity>', '').replaceAll('</input>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</productbaseprice>', '').replaceAll('</SubTotal>', '').replaceAll(' ', '');
            //  }
            CalculatePrice_Question_SubTotal(FormulaTag, q); //For <Subtotal> Calculation
            CalculatePrice_Question(Formula, q, TempSubTotal1);
        }
    }

    //    setInterval("TakeOut()", 10000);
    if (decname1 != null || decname2 != null || decname3 != null || decname4 != null || decname5 != null || decname6 != null) {
        if (decname1 != "" || decname2 != "" || decname3 != "" || decname4 != "" || decname5 != "" || decname6 != "") {
            calculateDecoration(1);
        }
    }
    Final_SellingPrice_SubTotal();
    Final_SellingPrice();
}

function GetResultMatrix1(result) {
    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {

        NewResult = result.split(',');
    }




    // alert(NewResult[1]);

    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice1_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false);
        document.getElementById("lblMatrixCostMarkup1_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}
function GetResultMatrix2(result) {
    var NewResult;

    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }


    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice2_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false);
        document.getElementById("lblMatrixCostMarkup2_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}
function GetResultMatrix3(result) {
    // var NewResult = result.split('~');
    var NewResult;

    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }



    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice3_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false);
        document.getElementById("lblMatrixCostMarkup3_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}
function GetResultMatrix4(result) {
    // var NewResult = result.split('~');
    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }


    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice4_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false);
        document.getElementById("lblMatrixCostMarkup4_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}

function MatrixCheck_value(OthercostID, ID, MatrixType) {
    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    var quantity1 = '';
    var quantity2 = '';
    var quantity3 = '';
    var quantity4 = '';

    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;

    if (hid_matixType.value == "P") {
        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;
    }
    else if (hid_matixType.value == "G") {
        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;
    }
    else {

        if (SimpleMatBrowserHandy == "yes") {
            var ddltxt_req_qty_1 = document.getElementById("ddltxt_req_qty_1");
            var ddltxt_req_qty_2 = document.getElementById("ddltxt_req_qty_2");
            var ddltxt_req_qty_3 = document.getElementById("ddltxt_req_qty_3");
            var ddltxt_req_qty_4 = document.getElementById("ddltxt_req_qty_4");

            quantity1 = ddltxt_req_qty_1.value;
            quantity2 = ddltxt_req_qty_2.value;
            quantity3 = ddltxt_req_qty_3.value;
            quantity4 = ddltxt_req_qty_4.value;
        } else {
            if (hdn_IsCumulative.value == "true") {
                var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                quantity1 = ddl_req_qty_1.value;
                quantity2 = ddl_req_qty_2.value;
                quantity3 = ddl_req_qty_3.value;
                quantity4 = ddl_req_qty_4.value;
            } else {
                var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                quantity1 = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
                quantity2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
                quantity3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
                quantity4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
            }
        }
    }

    var chkbox = document.getElementById("chkMatrix_" + ID + "");

    if ((quantity1 != "" && quantity1 != "0") || (quantity2 != "" && quantity2 != "0") || (quantity3 != "" && quantity3 != "0") || (quantity4 != "" && quantity4 != "0")) {
        if (MatrixType != "pricebands") {
            //chkbox.checked = true;
        }
    }

    if (chkbox.checked && chkbox.getAttribute("grpvalue") == "1") {

        for (var i = 0; i < 4; i++) {
            var j = i + 1;
            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
            var qty = quantity.split('~');

            if (MatrixType == "pricebands") {
                if ((qty[i] != '' && qty[i] != '0' && qty[i] != 'select')) {
                    if (OthercostID != '0') {
                        if (i == 0) {
                            AutoFill.GetMatrixValue(Number(OthercostID), Number(qty[i]), ID, GetResultMatrix1, onTimeout, onError);
                        }
                        else if (i == 1) {
                            AutoFill.GetMatrixValue(Number(OthercostID), Number(qty[i]), ID, GetResultMatrix2, onTimeout, onError);
                        }
                        else if (i == 2) {
                            AutoFill.GetMatrixValue(Number(OthercostID), Number(qty[i]), ID, GetResultMatrix3, onTimeout, onError);
                        }
                        else if (i == 3) {
                            AutoFill.GetMatrixValue(Number(OthercostID), Number(qty[i]), ID, GetResultMatrix4, onTimeout, onError);
                        }


                        spn_qty.style.display = "none";
                    }
                }
                else {
                    document.getElementById("lblMatrixPrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
                    document.getElementById("lblMatrixPrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
                    document.getElementById("lblMatrixPrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
                    document.getElementById("lblMatrixPrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
                    Final_SellingPrice();
                }
            }
            else {
                //-------  For product additional option to select lessthan nearest value for price band -- Done by thejesh
                if ((qty[i] != '' && qty[i] != '0' && qty[i] != 'select')) {

                    var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMatrix_" + ID);
                    //var QtyMatched = false;
                    for (j = 0; j < 4; j++) {
                        var l = j + 1;
                        for (ddl = 0; ddl <= ddlMatrix.length - 1; ddl++) {
                            var MatrixSellingPrice = '';
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qtycount = quantity.split('~');
                            if (qtycount[j] <= Number(ddlMatrix[ddl].text)) {
                                ddlMatrix.selectedIndex = ddl;
                                //    QtyMatched = true;
                                var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                                var ddlMatrixValue1 = ddlMatrixValue.split('~');
                                //                                    if (l <= 5) {
                                MatrixSellingPrice = "MatrixSellingPrice" + l;
                                var lblMatrixPrice = document.getElementById("lblMatrixPrice" + l + "_" + ID + "");
                                MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                                lblMatrixPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false);
                                //                                    }
                                break;
                            }
                            else {

                                ddlMatrix.selectedIndex = ddl;
                                //    QtyMatched = true;
                                var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                                var ddlMatrixValue1 = ddlMatrixValue.split('~');
                                //                                    if (l <= 5) {
                                MatrixSellingPrice = "MatrixSellingPrice" + l;
                                var lblMatrixPrice = document.getElementById("lblMatrixPrice" + l + "_" + ID + "");
                                MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                                lblMatrixPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false);
                                //                                
                            }
                        }
                    }
                    Final_SellingPrice();
                    spn_qty.style.display = "none";
                }
            }
        }
    }
    else {
        document.getElementById("lblMatrixPrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
        document.getElementById("lblMatrixPrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
        document.getElementById("lblMatrixPrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
        document.getElementById("lblMatrixPrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);

        Final_SellingPrice();

    }
}

function CalculatePrice_Question_SubTotal(formula, ID) {

    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    if (txtQuestion.value != '' && Number(txtQuestion.value) != '0' && Number(txtQuestion.value)) {
        var IsSubTotal = false;
        if (formula.indexOf("[$SubTotal$]") != -1 || formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }

        if (IsSubTotal) {
            document.getElementById("lblPrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblPrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblPrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblPrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        }
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblPrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        document.getElementById("lblPrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        document.getElementById("lblPrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
    }
}

function GetResult1(result) {
    // var NewResult = result.split('~');

    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }

    if (!isNaN(NewResult[0])) {

        document.getElementById("lblPrice1_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        //        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}
function GetResult2(result) {
    // var NewResult = result.split('~');

    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }


    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice2_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        //        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}
function GetResult3(result) {
    //var NewResult = result.split('~');

    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }

    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice3_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        //        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}
function GetResult4(result) {
    //var NewResult = result.split('~');


    var NewResult;
    if (result.indexOf('~') != -1) {
        NewResult = result.split('~');
    }
    else {
        NewResult = result.split(',');
    }

    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice4_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        //        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function CalculatePrice_Question(Formula, ID, TempSubTotal1) {

    var TempSubTotal1 = '0';
    var TempSubTotal2 = '0';
    var TempSubTotal3 = '0';
    var TempSubTotal4 = '0';

    TempSubTotal1 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield1").value);
    TempSubTotal2 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield2").value);
    TempSubTotal3 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield3").value);
    TempSubTotal4 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield4").value);

    var sellingPrice = '';
    var sellingPrice2 = '';
    var sellingPrice3 = '';
    var sellingPrice4 = '';

    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    var GroupID = document.getElementById("lblQuestionGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblQuestionID_" + ID + "").innerHTML;
    var ddlMultipleSelectedvalue = document.getElementById("ddlMultiple");
    //-------------------------------

    lbltxt1 = document.getElementById("spn_Total_QtyPrice_1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    lbltxt2 = document.getElementById("spn_Total_QtyPrice_2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    lbltxt3 = document.getElementById("spn_Total_QtyPrice_3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    lbltxt4 = document.getElementById("spn_Total_QtyPrice_4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

    hid_QuantityPrice1.value = Number(lbltxt1);
    hid_QuantityPrice2.value = Number(lbltxt2);
    hid_QuantityPrice3.value = Number(lbltxt3);
    hid_QuantityPrice4.value = Number(lbltxt4);
    //-------------------------------

    hid_QuantityPrice1.value = hid_QuantityPrice1.value != 'NaN' ? hid_QuantityPrice1.value : '0';
    hid_QuantityPrice2.value = hid_QuantityPrice2.value != 'NaN' ? hid_QuantityPrice2.value : '0';
    hid_QuantityPrice3.value = hid_QuantityPrice3.value != 'NaN' ? hid_QuantityPrice3.value : '0';
    hid_QuantityPrice4.value = hid_QuantityPrice4.value != 'NaN' ? hid_QuantityPrice4.value : '0';

    if (hid_matixType.value == "G") {
        var txtwidth1 = document.getElementById("txt_Width_1").value;
        var txtwidth2 = document.getElementById("txt_Width_2").value;
        var txtwidth3 = document.getElementById("txt_Width_3").value;
        var txtwidth4 = document.getElementById("txt_Width_4").value;

        var txtHeight1 = document.getElementById("txt_Height_1").value;
        var txtHeight2 = document.getElementById("txt_Height_2").value;
        var txtHeight3 = document.getElementById("txt_Height_3").value;
        var txtHeight4 = document.getElementById("txt_Height_4").value;


        hdnOrderedwidth1.value = (txtwidth1 != 'NaN' ? txtwidth1 : '0');
        hdnOrderedwidth2.value = (txtwidth2 != 'NaN' ? txtwidth2 : '0');
        hdnOrderedwidth3.value = (txtwidth3 != 'NaN' ? txtwidth3 : '0');
        hdnOrderedwidth4.value = (txtwidth4 != 'NaN' ? txtwidth4 : '0');

        hdnOrderedHeight1.value = (txtHeight1 != 'NaN' ? txtHeight1 : '0');
        hdnOrderedHeight2.value = (txtHeight2 != 'NaN' ? txtHeight2 : '0');
        hdnOrderedHeight3.value = (txtHeight3 != 'NaN' ? txtHeight3 : '0');
        hdnOrderedHeight4.value = (txtHeight4 != 'NaN' ? txtHeight4 : '0');


        hdnOrderedarea1.value = hdnOrderedwidth1.value * hdnOrderedHeight1.value;
        hdnOrderedarea2.value = hdnOrderedwidth2.value * hdnOrderedHeight2.value;
        hdnOrderedarea3.value = hdnOrderedwidth3.value * hdnOrderedHeight3.value;
        hdnOrderedarea4.value = hdnOrderedwidth4.value * hdnOrderedHeight4.value;

    }
    else {
        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';
    }

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value) && txtQuestion.getAttribute("grpvalue") == "1") {
        var IsSubTotal = false;
        if (Formula.indexOf("[$SubTotal$]") != -1 || Formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }
        if (hid_matixType.value == "S") {

            if (hdn_IsCumulative.value == "true") {
                var ddll_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                var ddll_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                var ddll_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                var ddll_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                hdn_orderedquantity1.value = ddll_req_qty_1.value;
                hdn_orderedquantity2.value = ddll_req_qty_2.value;
                hdn_orderedquantity3.value = ddll_req_qty_3.value;
                hdn_orderedquantity4.value = ddll_req_qty_4.value;
            } else {
                var ddll_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var ddll_req_qty_2 = document.getElementById("ddl_req_qty_2");
                var ddll_req_qty_3 = document.getElementById("ddl_req_qty_3");
                var ddll_req_qty_4 = document.getElementById("ddl_req_qty_4");

                hdn_orderedquantity1.value = ddll_req_qty_1.options[ddll_req_qty_1.selectedIndex].text;
                hdn_orderedquantity2.value = ddll_req_qty_2.options[ddll_req_qty_2.selectedIndex].text;
                hdn_orderedquantity3.value = ddll_req_qty_3.options[ddll_req_qty_3.selectedIndex].text;
                hdn_orderedquantity4.value = ddll_req_qty_4.options[ddll_req_qty_4.selectedIndex].text;
            }

        }
        else {
            var quantity1 = document.getElementById("txt_req_qty_1").value;
            var quantity2 = document.getElementById("txt_req_qty_2").value;
            var quantity3 = document.getElementById("txt_req_qty_3").value;
            var quantity4 = document.getElementById("txt_req_qty_4").value;

            hdn_orderedquantity1.value = quantity1;
            hdn_orderedquantity2.value = quantity2;
            hdn_orderedquantity3.value = quantity3;
            hdn_orderedquantity4.value = quantity4;
        }

        var FormulaTag1 = '';
        var FormulaTag2 = '';
        var FormulaTag3 = '';
        var FormulaTag4 = '';

        FormulaTag1 = Formula;
        FormulaTag2 = Formula;
        FormulaTag3 = Formula;
        FormulaTag4 = Formula;

        FormulaTag1 = FormulaTag1.replaceAll('<QUESTION>', txtQuestion.value).replaceAll('<question>', txtQuestion.value).replaceAll('<quantity>', txtQuestion.value).replaceAll('<input>', txtQuestion.value).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</productbaseprice>', '').replaceAll('</subtotal>', '').replaceAll('#', '%').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea1.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
        FormulaTag2 = FormulaTag2.replaceAll('<QUESTION>', txtQuestion.value).replaceAll('<question>', txtQuestion.value).replaceAll('<quantity>', txtQuestion.value).replaceAll('<input>', txtQuestion.value).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</productbaseprice>', '').replaceAll('</subtotal>', '').replaceAll('#', '%').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea2.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea2.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
        FormulaTag3 = FormulaTag3.replaceAll('<QUESTION>', txtQuestion.value).replaceAll('<question>', txtQuestion.value).replaceAll('<quantity>', txtQuestion.value).replaceAll('<input>', txtQuestion.value).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</productbaseprice>', '').replaceAll('</subtotal>', '').replaceAll('#', '%').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea3.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea3.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
        FormulaTag4 = FormulaTag4.replaceAll('<QUESTION>', txtQuestion.value).replaceAll('<question>', txtQuestion.value).replaceAll('<quantity>', txtQuestion.value).replaceAll('<input>', txtQuestion.value).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</productbaseprice>', '').replaceAll('</subtotal>', '').replaceAll('#', '%').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea4.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea4.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

        //----------1------------
        for (var i = 1; i <= 4; i++) {
            var j = i - 1;
            var TempSubT = TempSubTotal1 + '~' + TempSubTotal2 + '~' + TempSubTotal3 + '~' + TempSubTotal4;
            var TempSubTotal = TempSubT.split('~');

            var FormulaT = FormulaTag1 + '~' + FormulaTag2 + '~' + FormulaTag3 + '~' + FormulaTag4;
            var FormulaTag = FormulaT.split('~');

            if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal[j]) != 0)) {
                try {
                    var dd = eval(FormulaTag[j]);
                    if (!isNaN(dd)) {
                        if (i == 1) {
                            AutoFill.CalculateFormulaCost(dd, ID, GetResult1, onTimeout, onError);
                        }
                        if (i == 2) {
                            AutoFill.CalculateFormulaCost(dd, ID, GetResult2, onTimeout, onError);
                        }
                        if (i == 3) {
                            AutoFill.CalculateFormulaCost(dd, ID, GetResult3, onTimeout, onError);
                        }
                        if (i == 4) {
                            AutoFill.CalculateFormulaCost(dd, ID, GetResult4, onTimeout, onError);
                        }

                    }
                    else {
                        document.getElementById("lblPrice" + i + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
                    Final_SellingPrice();
                }
                catch (Error) {
                    //                    alert("Please enter valid expression.");
                    document.getElementById("lblPrice" + i + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                }
            }
            else {
                document.getElementById("lblPrice" + i + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            }
            Final_SellingPrice();
        }
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        document.getElementById("lblPrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        document.getElementById("lblPrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        document.getElementById("lblPrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        Final_SellingPrice();
    }
}

function Onchange_MultipleChoice_SubTotal(ID) {

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    var quantity1 = '';
    var quantity2 = '';
    var quantity3 = '';
    var quantity4 = '';

    if (hid_matixType.value == "P") {

        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;

        hid_QuantityPrice1.value = Number(document.getElementById("LabelqtyPricetxt1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice2.value = Number(document.getElementById("LabelqtyPricetxt2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice3.value = Number(document.getElementById("LabelqtyPricetxt3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice4.value = Number(document.getElementById("LabelqtyPricetxt4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';
    }
    else if (hid_matixType.value == "G") {

        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;

        hid_QuantityPrice1.value = Number(document.getElementById("LabelqtyPricetxt1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice2.value = Number(document.getElementById("LabelqtyPricetxt2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice3.value = Number(document.getElementById("LabelqtyPricetxt3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice4.value = Number(document.getElementById("LabelqtyPricetxt4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

        var txtwidth1 = document.getElementById("txt_Width_1").value;
        var txtwidth2 = document.getElementById("txt_Width_2").value;
        var txtwidth3 = document.getElementById("txt_Width_3").value;
        var txtwidth4 = document.getElementById("txt_Width_4").value;

        var txtHeight1 = document.getElementById("txt_Height_1").value;
        var txtHeight2 = document.getElementById("txt_Height_2").value;
        var txtHeight3 = document.getElementById("txt_Height_3").value;
        var txtHeight4 = document.getElementById("txt_Height_4").value;


        hdnOrderedwidth1.value = (txtwidth1 != 'NaN' ? txtwidth1 : '0');
        hdnOrderedwidth2.value = (txtwidth2 != 'NaN' ? txtwidth2 : '0');
        hdnOrderedwidth3.value = (txtwidth3 != 'NaN' ? txtwidth3 : '0');
        hdnOrderedwidth4.value = (txtwidth4 != 'NaN' ? txtwidth4 : '0');

        hdnOrderedHeight1.value = (txtHeight1 != 'NaN' ? txtHeight1 : '0');
        hdnOrderedHeight2.value = (txtHeight2 != 'NaN' ? txtHeight2 : '0');
        hdnOrderedHeight3.value = (txtHeight3 != 'NaN' ? txtHeight3 : '0');
        hdnOrderedHeight4.value = (txtHeight4 != 'NaN' ? txtHeight4 : '0');

        hdnOrderedarea1.value = hdnOrderedwidth1.value * hdnOrderedHeight1.value;
        hdnOrderedarea2.value = hdnOrderedwidth2.value * hdnOrderedHeight2.value;
        hdnOrderedarea3.value = hdnOrderedwidth3.value * hdnOrderedHeight3.value;
        hdnOrderedarea4.value = hdnOrderedwidth4.value * hdnOrderedHeight4.value;
    }
    else {

        if (hdn_IsCumulative.value == "true") {
            var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
            var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
            var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
            var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

            quantity1 = ddl_req_qty_1.value;
            quantity2 = ddl_req_qty_2.value;
            quantity3 = ddl_req_qty_3.value;
            quantity4 = ddl_req_qty_4.value;
        } else {
            var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
            var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
            var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
            var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

            quantity1 = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
            quantity2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
            quantity3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
            quantity4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
        }

        hid_QuantityPrice1.value = Number(document.getElementById("LabelqtyPrice1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice2.value = Number(document.getElementById("LabelqtyPrice2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice3.value = Number(document.getElementById("LabelqtyPrice3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        hid_QuantityPrice4.value = Number(document.getElementById("LabelqtyPrice4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';
    }


    hid_QuantityPrice1.value = hid_QuantityPrice1.value != 'NaN' ? hid_QuantityPrice1.value : '0';
    hid_QuantityPrice2.value = hid_QuantityPrice2.value != 'NaN' ? hid_QuantityPrice2.value : '0';
    hid_QuantityPrice3.value = hid_QuantityPrice3.value != 'NaN' ? hid_QuantityPrice3.value : '0';
    hid_QuantityPrice4.value = hid_QuantityPrice4.value != 'NaN' ? hid_QuantityPrice4.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID);

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {

        if (chkMultiple.checked || ddlMultiple.options[ddlMultiple.selectedIndex].value != "0") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                    chkMultiple.checked = false;
                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                            for (var i = 0; i < 4; i++) {
                                var j = i + 1;
                                var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                                var qty = quantity.split('~');

                                if (qty[i] != '' && qty[i] != 'select') {
                                    document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                }
                            }
                        }
                    } else {
                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qty = quantity.split('~');

                            if (qty[i] != '' && qty[i] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                        }
                    }
                }
                else {

                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                            if (SubGroupddlMultiple != null) {
                                var ddlMultipleValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value;
                                var MultipleValue = ddlMultipleValue.split('~');

                                for (var i = 0; i < 4; i++) {
                                    var j = i + 1;
                                    var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                                    var qty = quantity.split('~');

                                    if (qty[i] != '' && qty[i] != 'select') {
                                        var IsSubTotal = false;
                                        var FormulaTagMul = MultipleValue[0];
                                        if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal1 != 0 &&
                                        {
                                            IsSubTotal = true;
                                        }
                                        if (IsSubTotal) {
                                            document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                        }
                                        chkMultiple.checked = true;
                                        spn_qty.style.display = "none";
                                    }
                                }
                            }
                           
                        }
                    } else {
                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qty = quantity.split('~');

                            if (qty[i] != '' && qty[i] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                chkMultiple.checked = true;
                                spn_qty.style.display = "none";
                            }
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;

                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qty = quantity.split('~');

                            if (qty[i] != '' && qty[i] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                        }
                    }
                } else {
                    for (var i = 0; i < 4; i++) {
                        var j = i + 1;
                        var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                        var qty = quantity.split('~');

                        if (qty[i] != '' && qty[i] != 'select') {
                            document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        }
                    }
                }
            }
        }
        else {
            chkMultiple.checked = false;

            if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                    var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                    for (var i = 0; i < 4; i++) {
                        var j = i + 1;
                        var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                        var qty = quantity.split('~');

                        if (qty[i] != '' && qty[i] != 'select') {
                            document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        }
                    }
                }
            } else {
                for (var i = 0; i < 4; i++) {
                    var j = i + 1;
                    var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                    var qty = quantity.split('~');

                    if (qty[i] != '' && qty[i] != 'select') {
                        document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
                }
            }
        }
    } else {

        if (chkMultiple.checked || ddlMultiple.options[ddlMultiple.selectedIndex].value != "0") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                }
                else {
                    var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                    var MultipleValue = ddlMultipleValue.split('~');

                    for (var i = 0; i < 4; i++) {
                        var j = i + 1;
                        var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                        var qty = quantity.split('~');

                        if (qty[i] != '' && qty[i] != 'select') {

                            var IsSubTotal = false;
                            var FormulaTagMul = MultipleValue[0];
                            if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal1 != 0 &&
                            {
                                IsSubTotal = true;
                            }
                            if (IsSubTotal) {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                            chkMultiple.checked = true;
                            spn_qty.style.display = "none";
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
        }
    }
}

function GetResultMultiple1(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice1_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}
function GetResultMultiple2(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice2_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        Final_SellingPrice();
    }
}
function GetResultMultiple3(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice3_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}
function GetResultMultiple4(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice4_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}

function GetResultSubMultiple1(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {

        document.getElementById("lblMultiplePrice1_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}
function GetResultSubMultiple2(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {

        document.getElementById("lblMultiplePrice2_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}
function GetResultSubMultiple3(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {

        document.getElementById("lblMultiplePrice3_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}
function GetResultSubMultiple4(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {

        document.getElementById("lblMultiplePrice4_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        Final_SellingPrice();
    }
}

String.prototype.replaceAll = function (str1, str2, ignore) {
    return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g, "\\$&"), (ignore ? "gi" : "g")), (typeof (str2) == "string") ? str2.replace(/\$/g, "$$$$") : str2);
};

function Onchange_MultipleChoice(ID, TempSubTotal1) {
    var TempSubTotal1 = '';
    var TempSubTotal2 = '';
    var TempSubTotal3 = '';
    var TempSubTotal4 = '';

    TempSubTotal1 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield1").value);
    TempSubTotal2 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield2").value);
    TempSubTotal3 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield3").value);
    TempSubTotal4 = Number(document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield4").value);

    var quantity1 = '';
    var quantity2 = '';
    var quantity3 = '';
    var quantity4 = '';

    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    if (hid_matixType.value == "P") {
        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';

    }
    else if (hid_matixType.value == "G") {
        quantity1 = document.getElementById("txt_req_qty_1").value;
        quantity2 = document.getElementById("txt_req_qty_2").value;
        quantity3 = document.getElementById("txt_req_qty_3").value;
        quantity4 = document.getElementById("txt_req_qty_4").value;

        var txtwidth1 = document.getElementById("txt_Width_1").value;
        var txtwidth2 = document.getElementById("txt_Width_2").value;
        var txtwidth3 = document.getElementById("txt_Width_3").value;
        var txtwidth4 = document.getElementById("txt_Width_4").value;

        var txtHeight1 = document.getElementById("txt_Height_1").value;
        var txtHeight2 = document.getElementById("txt_Height_2").value;
        var txtHeight3 = document.getElementById("txt_Height_3").value;
        var txtHeight4 = document.getElementById("txt_Height_4").value;


        hdnOrderedwidth1.value = (txtwidth1 != 'NaN' ? txtwidth1 : '0');
        hdnOrderedwidth2.value = (txtwidth2 != 'NaN' ? txtwidth2 : '0');
        hdnOrderedwidth3.value = (txtwidth3 != 'NaN' ? txtwidth3 : '0');
        hdnOrderedwidth4.value = (txtwidth4 != 'NaN' ? txtwidth4 : '0');

        hdnOrderedHeight1.value = (txtHeight1 != 'NaN' ? txtHeight1 : '0');
        hdnOrderedHeight2.value = (txtHeight2 != 'NaN' ? txtHeight2 : '0');
        hdnOrderedHeight3.value = (txtHeight3 != 'NaN' ? txtHeight3 : '0');
        hdnOrderedHeight4.value = (txtHeight4 != 'NaN' ? txtHeight4 : '0');

        hdnOrderedarea1.value = hdnOrderedwidth1.value * hdnOrderedHeight1.value;
        hdnOrderedarea2.value = hdnOrderedwidth2.value * hdnOrderedHeight2.value;
        hdnOrderedarea3.value = hdnOrderedwidth3.value * hdnOrderedHeight3.value;
        hdnOrderedarea4.value = hdnOrderedwidth4.value * hdnOrderedHeight4.value;
    }
    else {
        if (SimpleMatBrowserHandy == 'yes') {
            var ddl_req_qty_1 = document.getElementById("ddltxt_req_qty_1");
            var ddl_req_qty_2 = document.getElementById("ddltxt_req_qty_2");
            var ddl_req_qty_3 = document.getElementById("ddltxt_req_qty_3");
            var ddl_req_qty_4 = document.getElementById("ddltxt_req_qty_4");

            quantity1 = ddl_req_qty_1.value;
            quantity2 = ddl_req_qty_2.value;
            quantity3 = ddl_req_qty_3.value;
            quantity4 = ddl_req_qty_4.value;

        } else {

            if (hdn_IsCumulative.value == "true") {
                var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                quantity1 = ddl_req_qty_1.value;
                quantity2 = ddl_req_qty_2.value;
                quantity3 = ddl_req_qty_3.value;
                quantity4 = ddl_req_qty_4.value;
            } else {
                var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                quantity1 = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
                quantity2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
                quantity3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
                quantity4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
            }
        }

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';

    }

    hid_QuantityPrice1.value = hid_QuantityPrice1.value != 'NaN' ? hid_QuantityPrice1.value : '0';
    hid_QuantityPrice2.value = hid_QuantityPrice2.value != 'NaN' ? hid_QuantityPrice2.value : '0';
    hid_QuantityPrice3.value = hid_QuantityPrice3.value != 'NaN' ? hid_QuantityPrice3.value : '0';
    hid_QuantityPrice4.value = hid_QuantityPrice4.value != 'NaN' ? hid_QuantityPrice4.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID);
    var ddlMultipleSelectedvalue = document.getElementById("ddlMultiple");

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {

        if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                    chkMultiple.checked = false;
                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);

                            for (var i = 0; i < 4; i++) {
                                var j = i + 1;
                                var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                                var qty = quantity.split('~');

                                if (qty[i] != '' && qty[i] != 'select') {
                                    document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                }
                            }
                        }
                    } else {
                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qty = quantity.split('~');

                            if (qty[i] != '' && qty[i] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                        }
                    }
                }
                else {
                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                            if (SubGroupddlMultiple != null) {
                                if (SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                                    var ddlMultipleValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value;
                                    var MultipleValue = ddlMultipleValue.split('~');
                                    for (var j = 1; j <= 4; j++) {
                                        var k = j - 1;
                                        var quantity = quantity1 + '~' + quantity2 + '~' + quantity3 + '~' + quantity4;
                                        quantity = quantity.split('~');

                                        var TempSubTotal = TempSubTotal1 + '~' + TempSubTotal2 + '~' + TempSubTotal3 + '~' + TempSubTotal4;
                                        TempSubTotal = TempSubTotal.split('~');
                                        if (quantity[k] != '' && quantity[k] != 'select') {
                                            var IsSubTotal = false;
                                            if (MultipleValue[0].indexOf("[$SubTotal$]") != -1 || MultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                                IsSubTotal = true;
                                            }

                                            if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal[k]) != 0)) {
                                                var FormulaTagMul1 = '';
                                                FormulaTagMul1 = MultipleValue[0];

                                                for (var l = 0; l <= FormulaTagMul1.length; l++) {
                                                    if (k == 0) {
                                                        var FormulaTagMul01 = FormulaTagMul1.replaceAll('<quantity>', quantity1).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice1.value).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', hdnOrderedHeight1.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth1.value).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', hdnOrderedarea1.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                                    }
                                                    if (k == 1) {
                                                        var FormulaTagMul02 = FormulaTagMul1.replaceAll('<quantity>', quantity2).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice2.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice2.value).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight2.value).replaceAll('[$orderedheight$]', hdnOrderedHeight2.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth2.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth2.value).replaceAll('[$OrderedArea$]', hdnOrderedarea2.value).replaceAll('[$orderedarea$]', hdnOrderedarea2.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                                    }
                                                    if (k == 2) {
                                                        var FormulaTagMul03 = FormulaTagMul1.replaceAll('<quantity>', quantity3).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice3.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice3.value).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight3.value).replaceAll('[$orderedheight$]', hdnOrderedHeight3.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth3.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth3.value).replaceAll('[$OrderedArea$]', hdnOrderedarea3.value).replaceAll('[$orderedarea$]', hdnOrderedarea3.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                                    }
                                                    if (k == 3) {
                                                        var FormulaTagMul04 = FormulaTagMul1.replaceAll('<quantity>', quantity4).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice4.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice4.value).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight4.value).replaceAll('[$orderedheight$]', hdnOrderedHeight4.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth4.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth4.value).replaceAll('[$OrderedArea$]', hdnOrderedarea4.value).replaceAll('[$orderedarea$]', hdnOrderedarea4.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                                    }
                                                }
                                                var dd1 = eval(FormulaTagMul01);
                                                var dd2 = eval(FormulaTagMul02);
                                                var dd3 = eval(FormulaTagMul03);
                                                var dd4 = eval(FormulaTagMul04);

                                                var dd = dd1 + '~' + dd2 + '~' + dd3 + '~' + dd4;
                                                dd = dd.split('~');
                                                if (!isNaN(dd[k])) {
                                                    asyncState = false;
                                                    if (k == 0) {
                                                        AutoFill.CalculateFormulaCost_ForSUBMultipleChoice(dd1, Number(MultipleValue[1]), ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC, GetResultSubMultiple1, onTimeout, onError);
                                                    }
                                                    if (k == 1) {
                                                        AutoFill.CalculateFormulaCost_ForSUBMultipleChoice(dd2, Number(MultipleValue[1]), ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC, GetResultSubMultiple2, onTimeout, onError);
                                                    }
                                                    if (k == 2) {
                                                        AutoFill.CalculateFormulaCost_ForSUBMultipleChoice(dd3, Number(MultipleValue[1]), ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC, GetResultSubMultiple3, onTimeout, onError);
                                                    }
                                                    if (k == 3) {
                                                        AutoFill.CalculateFormulaCost_ForSUBMultipleChoice(dd4, Number(MultipleValue[1]), ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC, GetResultSubMultiple4, onTimeout, onError);
                                                    }
                                                }
                                                else {
                                                    document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                                    Final_SellingPrice();
                                                }
                                            }
                                            else {
                                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                            }
                                            chkMultiple.checked = true;
                                            spn_qty.style.display = "none";
                                        }
                                    }
                                }
                                else {
                                    for (var p = 1; p <= 4; p++) {
                                        document.getElementById("lblMultiplePrice" + p + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                    }
                                    Final_SellingPrice();
                                }
                            }
                        
                        }
                    } else {
                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + '~' + quantity2 + '~' + quantity3 + '~' + quantity4;
                            quantity = quantity.split('~');

                            var TempSubTotal = TempSubTotal1 + '~' + TempSubTotal2 + '~' + TempSubTotal3 + '~' + TempSubTotal4;
                            TempSubTotal = TempSubTotal.split('~');
                            if (quantity[k] != '' && quantity[k] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00"
                                chkMultiple.checked = true;
                                spn_qty.style.display = "none";
                            }
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);

                        for (var i = 0; i < 4; i++) {
                            var j = i + 1;
                            var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                            var qty = quantity.split('~');

                            if (qty[i] != '' && qty[i] != 'select') {
                                document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                        }
                    }
                } else {

                    for (var i = 0; i < 4; i++) {
                        var j = i + 1;
                        var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                        var qty = quantity.split('~');

                        if (qty[i] != '' && qty[i] != 'select') {
                            document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        }
                    }
                }
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                    var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);

                    for (var i = 0; i < 4; i++) {
                        var j = i + 1;
                        var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                        var qty = quantity.split('~');

                        if (qty[i] != '' && qty[i] != 'select') {
                            document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        }
                    }
                }
            } else {

                for (var i = 0; i < 4; i++) {
                    var j = i + 1;
                    var quantity = quantity1 + "~" + quantity2 + "~" + quantity3 + "~" + quantity4;
                    var qty = quantity.split('~');

                    if (qty[i] != '' && qty[i] != 'select') {
                        document.getElementById("lblMultiplePrice" + j + "_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
                }
            }
            Final_SellingPrice();
        }
    } else {

        if (ddlMultiple.getAttribute("grpvalue") == "1") {
            if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                    if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                        chkMultiple.checked = false;
                        document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                        document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
                    else {
                        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                        var MultipleValue = ddlMultipleValue.split('~');
                        for (var j = 1; j <= 4; j++) {
                            var k = j - 1;

                            var quantity = quantity1 + '~' + quantity2 + '~' + quantity3 + '~' + quantity4;
                            quantity = quantity.split('~');

                            var TempSubTotal = TempSubTotal1 + '~' + TempSubTotal2 + '~' + TempSubTotal3 + '~' + TempSubTotal4;
                            TempSubTotal = TempSubTotal.split('~');
                            if (quantity[k] != '' && quantity[k] != 'select') {
                                var IsSubTotal = false;
                                if (MultipleValue[0].indexOf("[$SubTotal$]") != -1 || MultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                    IsSubTotal = true;
                                }

                                if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal[k]) != 0)) {
                                    var FormulaTagMul1 = '';
                                    FormulaTagMul1 = MultipleValue[0];

                                    for (var l = 0; l <= FormulaTagMul1.length; l++) {
                                        if (k == 0) {
                                            var FormulaTagMul01 = FormulaTagMul1.replaceAll('<quantity>', quantity1).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice1.value).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', hdnOrderedHeight1.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth1.value).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', hdnOrderedarea1.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                        }
                                        if (k == 1) {
                                            var FormulaTagMul02 = FormulaTagMul1.replaceAll('<quantity>', quantity2).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice2.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice2.value).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight2.value).replaceAll('[$orderedheight$]', hdnOrderedHeight2.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth2.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth2.value).replaceAll('[$OrderedArea$]', hdnOrderedarea2.value).replaceAll('[$orderedarea$]', hdnOrderedarea2.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                        }
                                        if (k == 2) {
                                            var FormulaTagMul03 = FormulaTagMul1.replaceAll('<quantity>', quantity3).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice3.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice3.value).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight3.value).replaceAll('[$orderedheight$]', hdnOrderedHeight3.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth3.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth3.value).replaceAll('[$OrderedArea$]', hdnOrderedarea3.value).replaceAll('[$orderedarea$]', hdnOrderedarea3.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                        }
                                        if (k == 3) {
                                            var FormulaTagMul04 = FormulaTagMul1.replaceAll('<quantity>', quantity4).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice4.value).replaceAll('[$productbaseprice$]', hid_QuantityPrice4.value).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight4.value).replaceAll('[$orderedheight$]', hdnOrderedHeight4.value).replaceAll('[$OrderedWidth$]', hdnOrderedwidth4.value).replaceAll('[$orderedwidth$]', hdnOrderedwidth4.value).replaceAll('[$OrderedArea$]', hdnOrderedarea4.value).replaceAll('[$orderedarea$]', hdnOrderedarea4.value).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                                        }
                                    }
                                    var dd1 = eval(FormulaTagMul01);
                                    var dd2 = eval(FormulaTagMul02);
                                    var dd3 = eval(FormulaTagMul03);
                                    var dd4 = eval(FormulaTagMul04);

                                    var dd = dd1 + '~' + dd2 + '~' + dd3 + '~' + dd4;
                                    dd = dd.split('~');
                                    if (!isNaN(dd[k])) {
                                        if (k == 0) {
                                            AutoFill.CalculateFormulaCost_ForMultipleChoice(dd1, Number(MultipleValue[1]), ID, GetResultMultiple1, onTimeout, onError);
                                        }
                                        if (k == 1) {
                                            AutoFill.CalculateFormulaCost_ForMultipleChoice(dd2, Number(MultipleValue[1]), ID, GetResultMultiple2, onTimeout, onError);
                                        }
                                        if (k == 2) {
                                            AutoFill.CalculateFormulaCost_ForMultipleChoice(dd3, Number(MultipleValue[1]), ID, GetResultMultiple3, onTimeout, onError);
                                        }
                                        if (k == 3) {
                                            AutoFill.CalculateFormulaCost_ForMultipleChoice(dd4, Number(MultipleValue[1]), ID, GetResultMultiple4, onTimeout, onError);
                                        }
                                    }
                                    else {
                                        document.getElementById("lblMultiplePrice" + j + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                        Final_SellingPrice();
                                    }
                                }
                                else {
                                    document.getElementById("lblMultiplePrice" + j + "_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                }
                                chkMultiple.checked = true;
                                spn_qty.style.display = "none";
                            }
                        }
                    }
                }
                else {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    Final_SellingPrice();
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice1_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice2_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice3_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            document.getElementById("lblMultiplePrice4_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
            Final_SellingPrice();
        }
    }
}

function TakeOut() {
    //    var i = 0;
    //    for (var l = 0; l < 200; l++) {
    //        i++;
    //    }
}

function Final_SellingPrice_SubTotal() {
    var TempSubTotal1 = '0';
    var TempSubTotal2 = '0';
    var TempSubTotal3 = '0';
    var TempSubTotal4 = '0';

    var QuestionPrice1 = '0';
    var QuestionPrice2 = '0';
    var QuestionPrice3 = '0';
    var QuestionPrice4 = '0';

    var MultiplePrice1 = '0';
    var MultiplePrice2 = '0';
    var MultiplePrice3 = '0';
    var MultiplePrice4 = '0';

    var MatrixPrice1 = '0';
    var MatrixPrice2 = '0';
    var MatrixPrice3 = '0';
    var MatrixPrice4 = '0';

    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");

    //    setInterval("TakeOut()", 100000);

    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {

            QuestionPrice1 = Number(QuestionPrice1) + Number(document.getElementById("lblPrice1_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice2 = Number(QuestionPrice2) + Number(document.getElementById("lblPrice2_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice3 = Number(QuestionPrice3) + Number(document.getElementById("lblPrice3_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice4 = Number(QuestionPrice4) + Number(document.getElementById("lblPrice4_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

            var lbltxt1 = document.getElementById("spn_Total_QtyPrice_1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var lbltxt2 = document.getElementById("spn_Total_QtyPrice_2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var lbltxt3 = document.getElementById("spn_Total_QtyPrice_3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var lbltxt4 = document.getElementById("spn_Total_QtyPrice_4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

            hid_QuantityPrice1.value = Number(lbltxt1);
            hid_QuantityPrice2.value = Number(lbltxt2);
            hid_QuantityPrice3.value = Number(lbltxt3);
            hid_QuantityPrice4.value = Number(lbltxt4);

        }
    }
    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                        MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    }
                } else {
                    MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {
                MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice1 = Number(MatrixPrice1) + Number(document.getElementById("lblMatrixPrice1_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice2 = Number(MatrixPrice2) + Number(document.getElementById("lblMatrixPrice2_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice3 = Number(MatrixPrice3) + Number(document.getElementById("lblMatrixPrice3_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice4 = Number(MatrixPrice4) + Number(document.getElementById("lblMatrixPrice4_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

        }
    }

    //    setInterval("TakeOut()", 100000);

    hid_QuantityPrice1.value = hid_QuantityPrice1.value != 'NaN' ? hid_QuantityPrice1.value : '0';
    hid_QuantityPrice2.value = hid_QuantityPrice2.value != 'NaN' ? hid_QuantityPrice2.value : '0';
    hid_QuantityPrice3.value = hid_QuantityPrice3.value != 'NaN' ? hid_QuantityPrice3.value : '0';
    hid_QuantityPrice4.value = hid_QuantityPrice4.value != 'NaN' ? hid_QuantityPrice4.value : '0';


    QuestionPrice1 = QuestionPrice1 != 'NaN' ? QuestionPrice1 : '0';
    QuestionPrice2 = QuestionPrice2 != 'NaN' ? QuestionPrice2 : '0';
    QuestionPrice3 = QuestionPrice3 != 'NaN' ? QuestionPrice3 : '0';
    QuestionPrice4 = QuestionPrice4 != 'NaN' ? QuestionPrice4 : '0';

    MultiplePrice1 = MultiplePrice1 != 'NaN' ? MultiplePrice1 : '0';
    MultiplePrice2 = MultiplePrice2 != 'NaN' ? MultiplePrice2 : '0';
    MultiplePrice3 = MultiplePrice3 != 'NaN' ? MultiplePrice3 : '0';
    MultiplePrice4 = MultiplePrice4 != 'NaN' ? MultiplePrice4 : '0';

    MatrixPrice1 = MatrixPrice1 != 'NaN' ? MatrixPrice1 : '0';
    MatrixPrice2 = MatrixPrice2 != 'NaN' ? MatrixPrice2 : '0';
    MatrixPrice3 = MatrixPrice3 != 'NaN' ? MatrixPrice3 : '0';
    MatrixPrice4 = MatrixPrice4 != 'NaN' ? MatrixPrice4 : '0';

    var sellingPrice1 = Number(hid_QuantityPrice1.value) + Number(QuestionPrice1) + Number(MultiplePrice1) + Number(MatrixPrice1);
    var sellingPrice2 = Number(hid_QuantityPrice2.value) + Number(QuestionPrice2) + Number(MultiplePrice2) + Number(MatrixPrice2);
    var sellingPrice3 = Number(hid_QuantityPrice3.value) + Number(QuestionPrice3) + Number(MultiplePrice3) + Number(MatrixPrice3);
    var sellingPrice4 = Number(hid_QuantityPrice4.value) + Number(QuestionPrice4) + Number(MultiplePrice4) + Number(MatrixPrice4);



    TempSubTotal1 = sellingPrice1;
    TempSubTotal2 = sellingPrice2;
    TempSubTotal3 = sellingPrice3;
    TempSubTotal4 = sellingPrice4;

    var allTempSubtotal = TempSubTotal1 + '~' + TempSubTotal2 + '~' + TempSubTotal3 + '~' + TempSubTotal4;
    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allTempSubTotal").value = allTempSubtotal;

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= Number(hid_MultipleLenght.value) - 1; c++) {

            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield1").value = TempSubTotal1;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield2").value = TempSubTotal2;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield3").value = TempSubTotal3;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield4").value = TempSubTotal4;

            Onchange_MultipleChoice(c, TempSubTotal1);
        }
    }
    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;
            var FormulaTag = Formula;
            // for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replaceAll(' ', '').replaceAll(' ', '').replaceAll('</question>', '').replaceAll('</quantity>', '').replaceAll('</input>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</productbaseprice>', '').replaceAll('</SubTotal>', '').replaceAll(' ', '');
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield1").value = TempSubTotal1;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield2").value = TempSubTotal2;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield3").value = TempSubTotal3;
            document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnTempfield4").value = TempSubTotal4;
            //  }
            CalculatePrice_Question(FormulaTag, q, TempSubTotal1);
        }
    }
}

//Total
function Final_SellingPrice() {
    var QuestionPrice1 = '0';
    var QuestionPrice2 = '0';
    var QuestionPrice3 = '0';
    var QuestionPrice4 = '0';

    var MultiplePrice1 = '0';
    var MultiplePrice2 = '0';
    var MultiplePrice3 = '0';
    var MultiplePrice4 = '0';

    var MatrixPrice1 = '0';
    var MatrixPrice2 = '0';
    var MatrixPrice3 = '0';
    var MatrixPrice4 = '0';

    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");

    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");


    if (hid_QuestionLenght.value != "0") {

        for (var j = 0; j <= Number(hid_QuestionLenght.value) - 1; j++) {

            QuestionPrice1 = Number(QuestionPrice1) + Number(document.getElementById("lblPrice1_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice2 = Number(QuestionPrice2) + Number(document.getElementById("lblPrice2_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice3 = Number(QuestionPrice3) + Number(document.getElementById("lblPrice3_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            QuestionPrice4 = Number(QuestionPrice4) + Number(document.getElementById("lblPrice4_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }
    if (hid_MultipleLenght.value != "0") {

        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                        if (SubGroupddlMultiple != null) {
                            MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                            MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                            MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                            MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        }
                      
                    }
                } else {
                    MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {

                MultiplePrice1 = Number(MultiplePrice1) + Number(document.getElementById("lblMultiplePrice1_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice2 = Number(MultiplePrice2) + Number(document.getElementById("lblMultiplePrice2_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice3 = Number(MultiplePrice3) + Number(document.getElementById("lblMultiplePrice3_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                MultiplePrice4 = Number(MultiplePrice4) + Number(document.getElementById("lblMultiplePrice4_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {

        for (var j = 0; j <= Number(hid_MatrixLenght.value) - 1; j++) {

            MatrixPrice1 = Number(MatrixPrice1) + Number(document.getElementById("lblMatrixPrice1_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice2 = Number(MatrixPrice2) + Number(document.getElementById("lblMatrixPrice2_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice3 = Number(MatrixPrice3) + Number(document.getElementById("lblMatrixPrice3_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            MatrixPrice4 = Number(MatrixPrice4) + Number(document.getElementById("lblMatrixPrice4_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));

            var spn_Total_QtyPrice_1 = document.getElementById("spn_Total_QtyPrice_1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var spn_Total_QtyPrice_2 = document.getElementById("spn_Total_QtyPrice_2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var spn_Total_QtyPrice_3 = document.getElementById("spn_Total_QtyPrice_3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
            var spn_Total_QtyPrice_4 = document.getElementById("spn_Total_QtyPrice_4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

            hid_QuantityPrice1.value = Number(spn_Total_QtyPrice_1);
            hid_QuantityPrice2.value = Number(spn_Total_QtyPrice_2);
            hid_QuantityPrice3.value = Number(spn_Total_QtyPrice_3);
            hid_QuantityPrice4.value = Number(spn_Total_QtyPrice_4);
        }

    }

    hid_QuantityPrice1.value = hid_QuantityPrice1.value != 'NaN' ? hid_QuantityPrice1.value : '0';
    hid_QuantityPrice2.value = hid_QuantityPrice2.value != 'NaN' ? hid_QuantityPrice2.value : '0';
    hid_QuantityPrice3.value = hid_QuantityPrice3.value != 'NaN' ? hid_QuantityPrice3.value : '0';
    hid_QuantityPrice4.value = hid_QuantityPrice4.value != 'NaN' ? hid_QuantityPrice4.value : '0';


    QuestionPrice1 = QuestionPrice1 != 'NaN' ? QuestionPrice1 : '0';
    QuestionPrice2 = QuestionPrice2 != 'NaN' ? QuestionPrice2 : '0';
    QuestionPrice3 = QuestionPrice3 != 'NaN' ? QuestionPrice3 : '0';
    QuestionPrice4 = QuestionPrice4 != 'NaN' ? QuestionPrice4 : '0';

    MultiplePrice1 = MultiplePrice1 != 'NaN' ? MultiplePrice1 : '0';
    MultiplePrice2 = MultiplePrice2 != 'NaN' ? MultiplePrice2 : '0';
    MultiplePrice3 = MultiplePrice3 != 'NaN' ? MultiplePrice3 : '0';
    MultiplePrice4 = MultiplePrice4 != 'NaN' ? MultiplePrice4 : '0';

    MatrixPrice1 = MatrixPrice1 != 'NaN' ? MatrixPrice1 : '0';
    MatrixPrice2 = MatrixPrice2 != 'NaN' ? MatrixPrice2 : '0';
    MatrixPrice3 = MatrixPrice3 != 'NaN' ? MatrixPrice3 : '0';
    MatrixPrice4 = MatrixPrice4 != 'NaN' ? MatrixPrice4 : '0';


    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? "0~0~0~0" : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? "0~0~0~0" : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? "0~0~0~0" : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? "0~0~0~0" : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? "0~0~0~0" : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? "0~0~0~0" : hdn_DecorationCost6.value
    var decorationArray1 = hdn_DecorationCost1.value.split('~');
    var decorationArray2 = hdn_DecorationCost2.value.split('~');
    var decorationArray3 = hdn_DecorationCost3.value.split('~');
    var decorationArray4 = hdn_DecorationCost4.value.split('~');
    var decorationArray5 = hdn_DecorationCost5.value.split('~');
    var decorationArray6 = hdn_DecorationCost6.value.split('~');

    var decorationCost1 = parseFloat(decorationArray1[0]) + parseFloat(decorationArray2[0]) + parseFloat(decorationArray3[0]) + parseFloat(decorationArray4[0]) + parseFloat(decorationArray5[0]) + parseFloat(decorationArray6[0]);
    var decorationCost2 = parseFloat(decorationArray1[1]) + parseFloat(decorationArray2[1]) + parseFloat(decorationArray3[1]) + parseFloat(decorationArray4[1]) + parseFloat(decorationArray5[1]) + parseFloat(decorationArray6[1]);
    var decorationCost3 = parseFloat(decorationArray1[2]) + parseFloat(decorationArray2[2]) + parseFloat(decorationArray3[2]) + parseFloat(decorationArray4[2]) + parseFloat(decorationArray5[2]) + parseFloat(decorationArray6[2]);
    var decorationCost4 = parseFloat(decorationArray1[3]) + parseFloat(decorationArray2[3]) + parseFloat(decorationArray3[3]) + parseFloat(decorationArray4[3]) + parseFloat(decorationArray5[3]) + parseFloat(decorationArray6[3]);

   
    if (hid_QuantityPrice1.value == 'undefined') {
        hid_QuantityPrice1.value = 0;
    }
    var sellingPrice1 = Number(hid_QuantityPrice1.value) + Number(QuestionPrice1) + Number(MultiplePrice1) + Number(MatrixPrice1) + decorationCost1;
    var sellingPrice2 = Number(hid_QuantityPrice2.value) + Number(QuestionPrice2) + Number(MultiplePrice2) + Number(MatrixPrice2) + decorationCost2;
    var sellingPrice3 = Number(hid_QuantityPrice3.value) + Number(QuestionPrice3) + Number(MultiplePrice3) + Number(MatrixPrice3) + decorationCost3;
    var sellingPrice4 = Number(hid_QuantityPrice4.value) + Number(QuestionPrice4) + Number(MultiplePrice4) + Number(MatrixPrice4) + decorationCost4;

    var lbltotal1 = document.getElementById("lbltotal1");
    var lbltotal2 = document.getElementById("lbltotal2");
    var lbltotal3 = document.getElementById("lbltotal3");
    var lbltotal4 = document.getElementById("lbltotal4");

    var allTypesAOTotal = Number(sellingPrice1) + '~' + Number(sellingPrice2) + '~' + Number(sellingPrice3) + '~' + Number(sellingPrice4);
    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allTypesAOTotal").value = allTypesAOTotal;

    lbltotal1.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice1), 2, '', false, false, false);
    lbltotal2.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice2), 2, '', false, false, false);
    lbltotal3.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice3), 2, '', false, false, false);
    lbltotal4.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice4), 2, '', false, false, false);
}

function onTimeout(request, context) {
    //            alert(request + " request");
    //            alert(context + " context");
}

function onError(objError) {
    //            alert(objError + " objError");

}

function Save_OrderItems(isAddOrContinue) {

    debugger;
    if (isAddOrContinue) {
        if (isAddOrContinue == "addmore") {
            $("#ctl00_ContentPlaceHolder1_ctl00_hdn_isAddMore").val("1")
        } else {
            $("#ctl00_ContentPlaceHolder1_ctl00_hdn_isAddMore").val("0")
        }
    }

    /////////////Decoration
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration1");

    if (decoration1_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration2");
    if (decoration2_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration3");
    if (decoration3_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration4");
    if (decoration4_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration5");
    if (decoration5_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration6");
    if (decoration6_Mandadory.toLowerCase() == "true" && ddlDecoration.options[ddlDecoration.selectedIndex].value == "--select--") {
        alert("Decoration mark with * is mandatory ");
        return false;
    }
    ///////////////////////

    var FinalCheck = false;

    var Temp = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allTempSubTotal").value.split('~');

    var TempSubTotal1 = Temp[0];
    var TempSubTotal2 = Temp[1];
    var TempSubTotal3 = Temp[2];
    var TempSubTotal4 = Temp[3];

    var SaveToAdditionalItemsQuestion = '';
    var SaveToAdditionalItemsMultiple = '';
    var SaveToAdditionalItemsMatrix = '';
    var hid_QuantityPrice1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice1");
    var hid_QuantityPrice2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice2");
    var hid_QuantityPrice3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice3");
    var hid_QuantityPrice4 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPrice4");

    var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuantityPriceExcMarkup");
    var hid_matixType = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_matixType");

    var hid_QuestionLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_QuestionLenght");
    var hid_MultipleLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MultipleLenght");
    var hid_MatrixLenght = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_MatrixLenght");


    var hid_SaveToAdditionalItems = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_SaveToAdditionalItems");
    var hid_UpdateToOrderItems = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hid_UpdateToOrderItems");

    var lbltotal1 = document.getElementById("lbltotal1");

    var lbltxt1 = document.getElementById("spn_Total_QtyPrice_1").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    var lbltxt2 = document.getElementById("spn_Total_QtyPrice_2").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    var lbltxt3 = document.getElementById("spn_Total_QtyPrice_3").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    var lbltxt4 = document.getElementById("spn_Total_QtyPrice_4").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

    hid_QuantityPrice1.value = Number(lbltxt1);
    hid_QuantityPrice2.value = Number(lbltxt2);
    hid_QuantityPrice3.value = Number(lbltxt3);
    hid_QuantityPrice4.value = Number(lbltxt4);


    if (hid_matixType.value == "P") {
        Qty = document.getElementById("txt_req_qty_1").value;
        Qty2 = document.getElementById("txt_req_qty_2").value;
        Qty3 = document.getElementById("txt_req_qty_3").value;
        Qty4 = document.getElementById("txt_req_qty_4").value;

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';

    }
    else if (hid_matixType.value == "G") {
        Qty = document.getElementById("txt_req_qty_1").value;
        Qty2 = document.getElementById("txt_req_qty_2").value;
        Qty3 = document.getElementById("txt_req_qty_3").value;
        Qty4 = document.getElementById("txt_req_qty_4").value;

        var txtwidth1 = document.getElementById("txt_Width_1").value;
        var txtwidth2 = document.getElementById("txt_Width_2").value;
        var txtwidth3 = document.getElementById("txt_Width_3").value;
        var txtwidth4 = document.getElementById("txt_Width_4").value;

        var txtHeight1 = document.getElementById("txt_Height_1").value;
        var txtHeight2 = document.getElementById("txt_Height_2").value;
        var txtHeight3 = document.getElementById("txt_Height_3").value;
        var txtHeight4 = document.getElementById("txt_Height_4").value;


        hdnOrderedwidth1.value = (txtwidth1 != 'NaN' ? txtwidth1 : '0');
        hdnOrderedwidth2.value = (txtwidth2 != 'NaN' ? txtwidth2 : '0');
        hdnOrderedwidth3.value = (txtwidth3 != 'NaN' ? txtwidth3 : '0');
        hdnOrderedwidth4.value = (txtwidth4 != 'NaN' ? txtwidth4 : '0');

        hdnOrderedHeight1.value = (txtHeight1 != 'NaN' ? txtHeight1 : '0');
        hdnOrderedHeight2.value = (txtHeight2 != 'NaN' ? txtHeight2 : '0');
        hdnOrderedHeight3.value = (txtHeight3 != 'NaN' ? txtHeight3 : '0');
        hdnOrderedHeight4.value = (txtHeight4 != 'NaN' ? txtHeight4 : '0');

        hdnOrderedarea1.value = hdnOrderedwidth1.value * hdnOrderedHeight1.value;
        hdnOrderedarea2.value = hdnOrderedwidth2.value * hdnOrderedHeight2.value;
        hdnOrderedarea3.value = hdnOrderedwidth3.value * hdnOrderedHeight3.value;
        hdnOrderedarea4.value = hdnOrderedwidth4.value * hdnOrderedHeight4.value;

    }
    else {
        if (SimpleMatBrowserHandy != 'yes') {

            if (hdn_IsCumulative.value == "true") {
                var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                Qty = ddl_req_qty_1.value;
                Qty2 = ddl_req_qty_2.value;
                Qty3 = ddl_req_qty_3.value;
                Qty4 = ddl_req_qty_4.value;
            } else {
                var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                Qty = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
                Qty2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
                Qty3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
                Qty4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
            }

        }
        else {
            Qty = document.getElementById("ddltxt_req_qty_1").value;
            Qty2 = document.getElementById("ddltxt_req_qty_2").value;
            Qty3 = document.getElementById("ddltxt_req_qty_3").value;
            Qty4 = document.getElementById("ddltxt_req_qty_4").value;
        }

        hdnOrderedwidth1.value = '0';
        hdnOrderedwidth2.value = '0';
        hdnOrderedwidth3.value = '0';
        hdnOrderedwidth4.value = '0';

        hdnOrderedHeight1.value = '0';
        hdnOrderedHeight2.value = '0';
        hdnOrderedHeight3.value = '0';
        hdnOrderedHeight4.value = '0';

        hdnOrderedarea1.value = '0';
        hdnOrderedarea2.value = '0';
        hdnOrderedarea3.value = '0';
        hdnOrderedarea4.value = '0';
    }

    var Qtys = Qty + '~' + Qty2 + '~' + Qty3 + '~' + Qty4;
    var MainQty = Qtys.split('~');
    document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_allselectedqty").value = Qtys;
    if (modulename.toLowerCase() == "estimate" || modulename.toLowerCase() == "order" || modulename.toLowerCase() == "webstoreorder") {
        if (Qty == '' || Qty == '0') {
            spn_qty.style.display = "block";
            FinalCheck = true;

        }
        else if (Qty < QtyStartsfrom) {
            spn_qty.innerHTML = "Minimum Quantity is " + QtyStartsfrom + "";
        }
        else if (!Number(Qty)) {
            if (hid_matixType == "P") {
                spn_qty.style.display = "block";
                spn_qty.innerHTML = "please Enter Only Number";
            }
            else if (hid_matixType == "G") {
                spn_qty.style.display = "block";
                spn_qty.innerHTML = "please Enter Only Number";
            }
            FinalCheck = true;
        }
        else {
            spn_qty.style.display = "none";
        }
    }

    var QuestionTotalMarkupValue = 0;
    var MultipleTotalMarkupValue = 0;
    var MatrixTotalMarkupValue = 0;
    var ddlMultipleSelectedvalue = document.getElementById("ddlMultiple");

    if (Number(hid_QuestionLenght.value) != 0) {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {

            var QuestionQty = document.getElementById("txtQuestion_" + i + "").value;
            var SortOrderNo = document.getElementById("lblQuestionSortOrderNo_" + i + "").innerHTML;

            if (Qty > 0) {
                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice1_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replaceAll('</quantity>', '').replaceAll('</question>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replaceAll('<QUESTION>', QuestionQty).replaceAll('<question>', QuestionQty).replaceAll('<quantity>', QuestionQty).replaceAll('<input>', QuestionQty).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll(' ', '').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea1.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';
                    QuestionTotalMarkupValue = Number(QuestionTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "QtyNo»1" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo; // + "µ";
                }
            }

            if (Qty2 > 0) {
                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice2_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replaceAll('</quantity>', '').replaceAll('</question>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replaceAll('<QUESTION>', QuestionQty).replaceAll('<question>', QuestionQty).replaceAll('<quantity>', QuestionQty).replaceAll('<input>', QuestionQty).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll(' ', '').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea2.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea2.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';
                    QuestionTotalMarkupValue = Number(QuestionTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "~QtyNo»2" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo; // + "µ";
                }
            }

            if (Qty3 > 0) {
                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice3_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replaceAll('</quantity>', '').replaceAll('</question>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replaceAll('<QUESTION>', QuestionQty).replaceAll('<question>', QuestionQty).replaceAll('<quantity>', QuestionQty).replaceAll('<input>', QuestionQty).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll(' ', '').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea3.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea3.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';
                    QuestionTotalMarkupValue = Number(QuestionTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "~QtyNo»3" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo; // + "µ";
                }
            }

            if (Qty4 > 0) {
                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice4_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replaceAll('</quantity>', '').replaceAll('</question>', '').replaceAll('</ProductBasePrice>', '').replaceAll('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replaceAll('<QUESTION>', QuestionQty).replaceAll('<question>', QuestionQty).replaceAll('<quantity>', QuestionQty).replaceAll('<input>', QuestionQty).replaceAll('[$ProductBasePrice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll(' ', '').replaceAll('[$OrderedHeight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$OrderedWidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$OrderedArea$]', Number(hdnOrderedarea4.value)).replaceAll('[$orderedarea$]', Number(hdnOrderedarea4.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';
                    QuestionTotalMarkupValue = Number(QuestionTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo; // + "µ";
                }
            }

            if (QuestionQty != '' && QuestionQty != 0) {
                SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "µ";
            }
        }
    }

    if (Number(hid_QuestionTextFreeLenght.value) != 0) {
        debugger;
        for (var i = 0; i <= Number(hid_QuestionTextFreeLenght.value) - 1; i++) {
            var QuestionQty = document.getElementById("txtFreeTextQuestion_" + i + "").value;
            //var SortOrderNo = document.getElementById("lblTextQuestionSortOrderNo_" + i + "").innerHTML;
            var Calculation_Type = document.getElementById("hdn_FreeTextQuestion_CalculationType_" + i + "").value;
            if (QuestionQty != '' && QuestionQty != 0) {

                var OthercostID = document.getElementById("lblFreeTextQuestionID_" + i).innerHTML; var TotalPrice = 0;
                var Formula = 0;

                var MarkUp = 0;
                var MarkupValue = 0;
                var SelectedValue = '';

                SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±CalculationType»" + Calculation_Type + "µ";
            }
        }
    }

    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
            var Check = document.getElementById("chkMultiple_" + j);

            if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1' && ddlMultiple.getAttribute("IsMandatory") == "1") {
                alert("Additional options marked with a * are mandatory");
                return false;
            }
            if (Check.checked) {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {

                    if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {
                        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                        var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                        ddlMultipleValue = ddlMultipleValue.split('~');

                        var OthercostID = ddlMultiple.getAttribute('WeotherCostID');
                        var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML;

                        if (Qty > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = '';// FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = 0; //ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = Number(0); //eval(FormulaTagMul);

                            var MarkupValue = 0; //(Number(SelectedPrice) * Number(MarkUp) / 100);
                            var TotalPrice = 0; //document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "QtyNo»1" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup"; //  + "µ";
                            }
                        }

                        if (Qty2 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = '';// FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = 0; //ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = Number(0); //eval(FormulaTagMul);

                            var MarkupValue = 0; //(Number(SelectedPrice) * Number(MarkUp) / 100);
                            var TotalPrice = 0; // document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup"; //  + "µ";
                            }
                        }

                        if (Qty3 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = '';// FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = 0; //ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = Number(0); //eval(FormulaTagMul);

                            var MarkupValue = 0; //(Number(SelectedPrice) * Number(MarkUp) / 100);
                            var TotalPrice = 0; //document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup"; // + "µ";
                            }
                        }

                        if (Qty4 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = '';// FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = 0; //ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = Number(0); //eval(FormulaTagMul);

                            var MarkupValue = 0; //(Number(SelectedPrice) * Number(MarkUp) / 100);
                            var TotalPrice = 0; //document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup"; //+ "µ";
                            }
                        }
                        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                            if (SubGroupddlMultiple != null) {
                                if (SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value.split('~')[6] == '1' && SubGroupddlMultiple.getAttribute("IsMandatory") == "1") {
                                    alert("Additional options marked with a * are mandatory");
                                    return false;
                                }
                                var ddlMultipleValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value;
                                var SelectedValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text;
                                ddlMultipleValue = ddlMultipleValue.split('~');

                                if (SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                    var SubOthercostID = document.getElementById("lblMultipleID_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML;
                                    var SubSortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML;

                                    if (Qty > 0) {
                                        var FormulaTagMul = ddlMultipleValue[0];
                                        var Formula = '';

                                        FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                                        var MarkUp = ddlMultipleValue[1];
                                        var SelectedID = ddlMultipleValue[2];
                                        var SelectedPrice = eval(FormulaTagMul);

                                        var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                                        if (isNaN(MarkupValue)) {
                                            MarkupValue = 0;
                                        }

                                        Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                        var TotalPrice = document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---" &&
                                            SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                            MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "QtyNo»1" + "±OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup"; //  + "µ";
                                        }
                                    }

                                    if (Qty2 > 0) {
                                        var FormulaTagMul = ddlMultipleValue[0];
                                        var Formula = '';

                                        FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty2).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice2.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight2.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth2.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea2.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea2.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                                        var MarkUp = ddlMultipleValue[1];
                                        var SelectedID = ddlMultipleValue[2];
                                        var SelectedPrice = eval(FormulaTagMul);

                                        var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                                        if (isNaN(MarkupValue)) {
                                            MarkupValue = 0;
                                        }
                                        Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                        var TotalPrice = document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---" &&
                                            SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                            MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup"; //  + "µ";
                                        }
                                    }

                                    if (Qty3 > 0) {
                                        var FormulaTagMul = ddlMultipleValue[0];
                                        var Formula = '';

                                        FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty3).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice3.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight3.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth3.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea3.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea3.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                                        var MarkUp = ddlMultipleValue[1];
                                        var SelectedID = ddlMultipleValue[2];
                                        var SelectedPrice = eval(FormulaTagMul);

                                        var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                                        if (isNaN(MarkupValue)) {
                                            MarkupValue = 0;
                                        }
                                        Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                        var TotalPrice = document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---" &&
                                            SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                            MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup"; // + "µ";
                                        }
                                    }

                                    if (Qty4 > 0) {
                                        var FormulaTagMul = ddlMultipleValue[0];
                                        var Formula = '';

                                        FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty4).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice4.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight4.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth4.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea4.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea4.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                                        var MarkUp = ddlMultipleValue[1];
                                        var SelectedID = ddlMultipleValue[2];
                                        var SelectedPrice = eval(FormulaTagMul);

                                        var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                                        if (isNaN(MarkupValue)) {
                                            MarkupValue = 0;
                                        }

                                        Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                        var TotalPrice = document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---" &&
                                            SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                            MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup"; //+ "µ";
                                        }
                                    }
                                }
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";
                            }
                          
                        }
                    } else {
                        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                        var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                        ddlMultipleValue = ddlMultipleValue.split('~');

                        var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;
                        var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;

                        if (Qty > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice1.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice1.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal1)).replaceAll('[$subtotal$]', Number(TempSubTotal1)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight1.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight1.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth1.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth1.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea1.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea1.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$orderedQuantity$]', Number(hdn_orderedquantity1.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice1_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "QtyNo»1" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //  + "µ";
                            }
                        }

                        if (Qty2 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty2).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice2.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice2.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal2)).replaceAll('[$subtotal$]', Number(TempSubTotal2)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight2.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight2.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth2.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth2.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea2.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea2.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity2.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice2_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //  + "µ";
                            }
                        }

                        if (Qty3 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty3).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice3.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice3.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal3)).replaceAll('[$subtotal$]', Number(TempSubTotal3)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight3.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight3.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth3.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth3.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea3.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea3.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity3.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice3_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; // + "µ";
                            }
                        }

                        if (Qty4 > 0) {
                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            FormulaTagMul = FormulaTagMul.replaceAll('<quantity>', Qty4).replaceAll('[$ProductBasePrice$]', hid_QuantityPrice4.value).replaceAll('[$productbaseprice$]', Number(hid_QuantityPrice4.value)).replaceAll('[$SubTotal$]', Number(TempSubTotal4)).replaceAll('[$subtotal$]', Number(TempSubTotal4)).replaceAll('[$OrderedHeight$]', hdnOrderedHeight4.value).replaceAll('[$orderedheight$]', Number(hdnOrderedHeight4.value)).replaceAll('[$OrderedWidth$]', hdnOrderedwidth4.value).replaceAll('[$orderedwidth$]', Number(hdnOrderedwidth4.value)).replaceAll('[$OrderedArea$]', hdnOrderedarea4.value).replaceAll('[$orderedarea$]', Number(hdnOrderedarea4.value)).replaceAll('[$OrderedQuantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$orderedquantity$]', Number(hdn_orderedquantity4.value)).replaceAll('[$MultipleOf$]', Number(ddlMultipleSelectedvalue.options[ddlMultipleSelectedvalue.selectedIndex].value));

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);
                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice4_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
                            }
                        }
                    }
                }

                if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                    SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";
                }
            }
        }
    }

    if (Number(hid_MatrixLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MatrixLenght.value) - 1; j++) {
            var Check = document.getElementById("chkMatrix_" + j);
            if (Check.checked) {
                var OthercostID = document.getElementById("lblMatrixID_" + j).innerHTML;
                var SortOrderNo = document.getElementById("lblMatrixSortOrderNo_" + j + "").innerHTML;

                var AdditionalMatrixType = document.getElementById("lblMatrixType_" + j).innerHTML;

                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMatrix_" + j);
                if (Qty > 0) {
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        //for (var k = 0; k < 4; k++) {
                        for (var l = 0; l < Number(ddlMatrix.length); l++) {
                            if (Number(Qty) <= Number(ddlMatrix[l].text)) {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                                break;
                            }
                            else {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                            }
                            //}
                            // break;
                        }
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup1_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice1_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    MatrixTotalMarkupValue = Number(MatrixTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»1" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";

                }




                if (Qty2 > 0) {
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        //for (var k = 0; k < 4; k++) {
                        for (var l = 0; l < Number(ddlMatrix.length); l++) {
                            if (Number(Qty2) <= Number(ddlMatrix[l].text)) {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                                break;
                            }
                            else {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                            }
                            //}
                            //break;
                        }
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup2_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice2_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    MatrixTotalMarkupValue = Number(MatrixTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»2" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";

                }


                if (Qty3 > 0) {
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        //for (var k = 0; k < 4; k++) {
                        for (var l = 0; l < Number(ddlMatrix.length); l++) {
                            if (Number(Qty3) <= Number(ddlMatrix[l].text)) {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                                break;
                            }
                            else {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                            }
                            //}
                            // break;
                        }
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup3_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice3_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    MatrixTotalMarkupValue = Number(MatrixTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»3" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";

                }


                if (Qty4 > 0) {
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        //for (var k = 0; k < 4; k++) {
                        for (var l = 0; l < Number(ddlMatrix.length); l++) {
                            if (Number(Qty4) <= Number(ddlMatrix[l].text)) {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                                break;
                            }
                            else {
                                var ddlMatrixValue = ddlMatrix.options[l].value;
                                SelectedValue = ddlMatrix.options[l].text;
                                ddlMatrixValue = ddlMatrixValue.split('~');
                                SelectedPrice = ddlMatrixValue[0];
                                Formula = ddlMatrixValue[0];
                                SelectedPrice = ddlMatrixValue[0];
                                MarkUp = ddlMatrixValue[1];
                                SelectedID = ddlMatrixValue[2];
                                MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                                Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                            }
                            //}
                            // break;
                        }
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup4_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice4_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    MatrixTotalMarkupValue = Number(MatrixTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
                }
                SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "µ";
            }
        }
    }
    
    //////////////////////////Decoration Added by Amin////////////////////////////////
    if (hdn_DecorationCost1.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost1.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration1");
        var SelectedValue = decname1 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + 0 + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 101; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + 0 + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 101; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 101; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 101; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }

    if (hdn_DecorationCost2.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost2.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration2");
        var SelectedValue = decname2 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 102; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 102; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 102; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 102; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }
    if (hdn_DecorationCost3.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost3.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration3");
        var SelectedValue = decname3 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 103; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 103; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 103; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 103; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }
    if (hdn_DecorationCost4.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost4.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration4");
        var SelectedValue = decname4 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 104; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 104; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 104; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 104; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }
    if (hdn_DecorationCost5.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost5.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration5");
        var SelectedValue = decname5 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 105; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 105; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 105; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 105; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }
    if (hdn_DecorationCost6.value != "0~0~0~0") {
        var MarkupValue = "0";
        var decorationArray1 = hdn_DecorationCost6.value.split('~');
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration5");
        var SelectedValue = decname6 + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value

        if (Qty > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»1" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[0] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[0] + "±SortOrderNo»" + 106; //+ "µ";
        }
        if (Qty2 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»2" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[1] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[1] + "±SortOrderNo»" + 106; //+ "µ";
        }
        if (Qty3 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»3" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[2] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 1 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[2] + "±SortOrderNo»" + 106; //+ "µ";
        }
        if (Qty4 > 0) {

            //SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "~QtyNo»4" + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo; //+ "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "~QtyNo»4" + "±OthercostID»" + "0" + "±Formula»" + "" + "±MarkUp»" + "0" + "±TotalPrice»" + decorationArray1[3] + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + decorationArray1[3] + "±SortOrderNo»" + 106; //+ "µ";
        }
        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "µ";

    }


    //////////////////////////End Decoration Added by Amin////////////////////////////////

    var AllAdditionalItemsDetails = '';
    if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
    }
    else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
    }
    else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMatrix;
    }
    else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple;
    }
    else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsMatrix;
    }
    else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple;
    }
    else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix == '') {
        AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion;
    }






    hid_SaveToAdditionalItems.value = AllAdditionalItemsDetails;

    if (document.getElementById("chk_Update_Item_Descriptions") != null) {
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_Update_Item_Descriptions").value = document.getElementById("chk_Update_Item_Descriptions").checked;
    }

    if (!FinalCheck) {
        CheckBackOrder();
        //return true;
    }
    else {
        CheckBackOrder2();
        //return false;
    }
}

function CheckBackOrder() {
    //PriceCatalogueID»3346±Quantity»10±Price»0.00±Cost»0±CatalogueName»Pro-Zero±MultipleOf»1±Markup»0.00µ

    if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {

        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            var ProductDetails = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hidCatalogueData").value;
            var ProductMainArray = ProductDetails.split('±');

            var ProductSubArray1 = ProductMainArray[0].split('»');
            var PriceCatalogueID = ProductSubArray1[1];

            var ProductSubArray2 = ProductMainArray[1].split('»');
            var EnterdQty = ProductSubArray2[1];


            var ProductSubArray6 = ProductMainArray[5].split('»');
            var MultipleOfQty = ProductSubArray6[1];

            var TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);

            var StatusID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnJobStatusID").value;
            //AutoFill.CheckEstimatePossible(PriceCatalogueID, EnterdQty, GetEstimatePossible2, onTimeout, onError);
            AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible2, onTimeout, onError);
        }
        else {
            loadingimg('ctl00_ContentPlaceHolder1_ctl00_btnSave', 'div_btnsaveprocess');
            __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkbtnSave', '');
            return true;
        }
    }
    else {
        loadingimg('ctl00_ContentPlaceHolder1_ctl00_btnSave', 'div_btnsaveprocess');
        __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkbtnSave', '');
        return true;
    }
}

function GetEstimatePossible2(result) {
    if (result == "false") {

        //temp document.getElementById("divBackGroundNew").style.display = "none";

        if (modulename.toLowerCase() == "jobs") {
            if (MainType == 'add' && IsDirectJob == 1 && IsStockItem == 1 && document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
                var ddlMandatory = document.getElementById("ddl_MandatoryReplenish");
                if (typeof document.getElementById("chk_Replenish_Product") != 'undefined' && document.getElementById("chk_Replenish_Product") != undefined &&
                    document.getElementById("chk_Replenish_Product") != null && document.getElementById("chk_Replenish_Product").checked) {
                    GetEstimatePossible(true);
                }
                else if (ddlMandatory) {
                    var ddlValue = ddlMandatory.value.trim().toLowerCase();

                    if (ddlValue === "true" || ddlValue === "1") {
                        GetEstimatePossible(true);
                    } else {
                        alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
                    }
                }
                else {
                    alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
                }
            } else {
                alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
            }
        }
        else if (modulename.toLowerCase() == "invoice") {
            alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
        }

        return false;
    }
    else {
        loadingimg('ctl00_ContentPlaceHolder1_ctl00_btnSave', 'div_btnsaveprocess');
        __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkbtnSave', '');
        return true;
    }
}

function CheckBackOrder2() {
    //PriceCatalogueID»3346±Quantity»10±Price»0.00±Cost»0±CatalogueName»Pro-Zero±MultipleOf»1±Markup»0.00µ

    if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {

        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdn_StockManagement").value == 1) {
            var ProductDetails = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hidCatalogueData").value;
            var ProductMainArray = ProductDetails.split('±');

            var ProductSubArray1 = ProductMainArray[0].split('»');
            var PriceCatalogueID = ProductSubArray1[1];

            var ProductSubArray2 = ProductMainArray[1].split('»');
            var EnterdQty = ProductSubArray2[1];

            var ProductSubArray6 = ProductMainArray[5].split('»');
            var MultipleOfQty = ProductSubArray6[1];

            var TotalQuantity = parseInt(EnterdQty) * parseInt(MultipleOfQty);

            var StatusID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnJobStatusID").value;
            // AutoFill.CheckEstimatePossible(PriceCatalogueID, EnterdQty, GetEstimatePossible3, onTimeout, onError);
            AutoFill.Check_Direct_Job_Invoice_Possible(PriceCatalogueID, TotalQuantity, modulename.toLowerCase(), GetEstimatePossible3, onTimeout, onError);
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

function GetEstimatePossible3(result) {
    if (result == "false") {
        //temp  document.getElementById("divBackGroundNew").style.display = "none";
        if (modulename.toLowerCase() == "jobs") {
            alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
        }
        else if (modulename.toLowerCase() == "invoice") {
            alert("You can't select this item as it has no stock quantity and back orders have not been allowed for it.");
        }

        //window.parent.document.getElementById('ctl00_ContentPlaceHolder1_PriceCatalog_Button15').disabled = true;
        return false;
    }
    else {
        //window.parent.document.getElementById('ctl00_ContentPlaceHolder1_PriceCatalog_Button15').disabled = true;
        return false;
    }
}

function Dimension_Prefill(type) {
    //for width
    var txt_qty1 = document.getElementById('txt_req_qty_1').value;
    var txt_qty2 = document.getElementById('txt_req_qty_2').value;
    var txt_qty3 = document.getElementById('txt_req_qty_3').value;
    var txt_qty4 = document.getElementById('txt_req_qty_4').value;
    //for width
    if (type == 'width') {
        var txtwidth1 = document.getElementById('txt_Width_1').value;
        var txtwidth2 = document.getElementById('txt_Width_2').value;
        var txtwidth3 = document.getElementById('txt_Width_3').value;
        var txtwidth4 = document.getElementById('txt_Width_4').value;

        var chk = true;
        if (txtwidth2 != '' && txtwidth3 != '' && txtwidth4 != '') {
            chk = false;
        }

        if (txtwidth2 == '' && txt_qty2 != '') {
            document.getElementById('txt_Width_2').value = txtwidth1;
            //document.getElementById('txt_Width_2').focus();
        }
        if (txtwidth3 == '' && txt_qty3 != '') {
            document.getElementById('txt_Width_3').value = txtwidth1;
            //document.getElementById('txt_Width_3').focus();
        }
        if (txtwidth4 == '' && txt_qty4 != '') {
            document.getElementById('txt_Width_4').value = txtwidth1;
            //document.getElementById('txt_Width_4').focus();
        }
        //document.getElementById('ctl00_ContentPlaceHolder1_ctl00_btnidnext').focus();

        if (chk) {
            document.getElementById('txt_Height_1').focus();
        }
    }
    //for height
    else {

        var txtHeight1 = document.getElementById('txt_Height_1').value;
        var txtHeight2 = document.getElementById('txt_Height_2').value;
        var txtHeight3 = document.getElementById('txt_Height_3').value;
        var txtHeight4 = document.getElementById('txt_Height_4').value;

        if (txtHeight2 == '' && txt_qty2 != '') {
            document.getElementById('txt_Height_2').value = txtHeight1;
            document.getElementById('txt_Height_2').focus();
        }
        if (txtHeight3 == '' && txt_qty3 != '') {
            document.getElementById('txt_Height_3').value = txtHeight1;
            document.getElementById('txt_Height_3').focus();
        }
        if (txtHeight4 == '' && txt_qty4 != '') {
            document.getElementById('txt_Height_4').value = txtHeight1;
            document.getElementById('txt_Height_4').focus();
        }
        document.getElementById('ctl00_ContentPlaceHolder1_ctl00_btnidnext').focus();
    }
}

function VisibleAdditionaloption(WebotherCostID) {

    if (Number(hid_MultipleLenght.value) != 0) {
        var quantity1 = '';
        var quantity2 = '';
        var quantity3 = '';
        var quantity4 = '';

        if (hid_matixType.value == "P" || hid_matixType.value == "G") {
            quantity1 = document.getElementById("txt_req_qty_1").value;
            quantity2 = document.getElementById("txt_req_qty_2").value;
            quantity3 = document.getElementById("txt_req_qty_3").value;
            quantity4 = document.getElementById("txt_req_qty_4").value;
        }
        else {
            if (SimpleMatBrowserHandy == "yes") {
                var ddltxt_req_qty_1 = document.getElementById("ddltxt_req_qty_1");
                var ddltxt_req_qty_2 = document.getElementById("ddltxt_req_qty_2");
                var ddltxt_req_qty_3 = document.getElementById("ddltxt_req_qty_3");
                var ddltxt_req_qty_4 = document.getElementById("ddltxt_req_qty_4");

                quantity1 = ddltxt_req_qty_1.value;
                quantity2 = ddltxt_req_qty_2.value;
                quantity3 = ddltxt_req_qty_3.value;
                quantity4 = ddltxt_req_qty_4.value;
            } else {
                if (hdn_IsCumulative.value == "true") {
                    var ddl_req_qty_1 = document.getElementById("txt_Cumulative_PriceQty_1");
                    var ddl_req_qty_2 = document.getElementById("txt_Cumulative_PriceQty_2");
                    var ddl_req_qty_3 = document.getElementById("txt_Cumulative_PriceQty_3");
                    var ddl_req_qty_4 = document.getElementById("txt_Cumulative_PriceQty_4");

                    quantity1 = ddl_req_qty_1.value;
                    quantity2 = ddl_req_qty_2.value;
                    quantity3 = ddl_req_qty_3.value;
                    quantity4 = ddl_req_qty_4.value;
                } else {
                    var ddl_req_qty_1 = document.getElementById("ddl_req_qty_1");
                    var ddl_req_qty_2 = document.getElementById("ddl_req_qty_2");
                    var ddl_req_qty_3 = document.getElementById("ddl_req_qty_3");
                    var ddl_req_qty_4 = document.getElementById("ddl_req_qty_4");

                    quantity1 = ddl_req_qty_1.options[ddl_req_qty_1.selectedIndex].text;
                    quantity2 = ddl_req_qty_2.options[ddl_req_qty_2.selectedIndex].text;
                    quantity3 = ddl_req_qty_3.options[ddl_req_qty_3.selectedIndex].text;
                    quantity4 = ddl_req_qty_4.options[ddl_req_qty_4.selectedIndex].text;
                }
            }
        }

        var Qtys = quantity1 + '~' + quantity2 + '~' + quantity3 + '~' + quantity4;
        var styleNone1 = 'none';
        var styleNone2 = 'none';
        var styleNone3 = 'none';
        var styleNone4 = 'none';
        if (quantity1 > 0) { styleNone1 = 'block'; }
        if (quantity2 > 0) { styleNone2 = 'block'; }
        if (quantity3 > 0) { styleNone3 = 'block'; }
        if (quantity4 > 0) { styleNone4 = 'block'; }

        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {
                for (var c = 0; c < ddlMultiple.options.length; c++) {
                    if (ddlMultiple.options[c].text.toLowerCase().trim() != '---select---' &&
                        ddlMultiple.options[c].value.split('~')[2] == ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'block';

                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_1").style.display = styleNone1;
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_2").style.display = styleNone2;
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_3").style.display = styleNone3;
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_4").style.display = styleNone4;

                        if (Number(ddlMultiple.options[c].value.split('~')[4]) != 0) {
                            for (var SC = 0; SC < ddlMultiple.options[c].value.split('~')[4]; SC++) {
                                document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                                document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = styleNone1;
                                document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = styleNone2;
                                document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = styleNone3;
                                document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = styleNone4;
                            }
                        } else {
                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = styleNone1;
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = styleNone2;
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = styleNone3;
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = styleNone4;
                        }
                    } else if (ddlMultiple.options[c].value.split('~')[2] != ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'none';

                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_1").style.display = 'none';
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_2").style.display = 'none';
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_3").style.display = 'none';
                        document.getElementById("div_" + ddlMultiple.options[c].value.split('~')[2] + "_4").style.display = 'none';

                        if (Number(ddlMultiple.options[c].value.split('~')[4]) != 0) {
                            for (var SC = 0; SC < ddlMultiple.options[c].value.split('~')[4]; SC++) {
                                document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                                document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = 'none';
                                document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = 'none';
                                document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = 'none';
                                document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_" + SC).style.display = 'none';
                            }
                        } else {
                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = 'none';
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = 'none';
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = 'none';
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[c].value.split('~')[2] + "_0").style.display = 'none';
                        }

                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() == '---select---') {
                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                            document.getElementById("lblMultiplePrice1_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = styleNone1;
                            document.getElementById("lblMultiplePrice2_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = styleNone2;
                            document.getElementById("lblMultiplePrice3_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = styleNone3;
                            document.getElementById("lblMultiplePrice4_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_0").style.display = styleNone4;

                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_1").style.display = styleNone1;
                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_2").style.display = styleNone2;
                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_3").style.display = styleNone3;
                            document.getElementById("div_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_4").style.display = styleNone4;

                        }
                    }
                }
            }
        }
        Final_SellingPrice();
    }
}


function calculateDecoration(decoration) {

    debugger;
    var Qty;
    var Qty2;
    var Qty3;
    var Qty4;
    try {

         Qty = parseInt(document.getElementById("Labelqty" + 1 + "").innerText == "" ? 0 : document.getElementById("Labelqty" + 1 + "").innerText);
         Qty2 = parseInt(document.getElementById("Labelqty" + 2 + "").innerText == "" ? 0 : document.getElementById("Labelqty" + 2 + "").innerText);
         Qty3 = parseInt(document.getElementById("Labelqty" + 3 + "").innerText == "" ? 0 : document.getElementById("Labelqty" + 3 + "").innerText);
         Qty4 = parseInt(document.getElementById("Labelqty" + 4 + "").innerText == "" ? 0 : document.getElementById("Labelqty" + 4 + "").innerText);

    }
    catch (err) {
         Qty = parseInt(document.getElementById("Labelqtytxt" + 1 + "").innerText == "" ? 0 : document.getElementById("Labelqtytxt" + 1 + "").innerText);
         Qty2 = parseInt(document.getElementById("Labelqtytxt" + 2 + "").innerText == "" ? 0 : document.getElementById("Labelqtytxt" + 2 + "").innerText);
         Qty3 = parseInt(document.getElementById("Labelqtytxt" + 3 + "").innerText == "" ? 0 : document.getElementById("Labelqtytxt" + 3 + "").innerText);
         Qty4 = parseInt(document.getElementById("Labelqtytxt" + 4 + "").innerText == "" ? 0 : document.getElementById("Labelqtytxt" + 4 + "").innerText);
    }

    hdn_DecorationCost1.value = "0~0~0~0";
    hdn_DecorationCost2.value = "0~0~0~0";
    hdn_DecorationCost3.value = "0~0~0~0";
    hdn_DecorationCost4.value = "0~0~0~0";
    hdn_DecorationCost5.value = "0~0~0~0";
    hdn_DecorationCost6.value = "0~0~0~0";

    if (decname1) {
        document.getElementById("lblDecoration1_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration2_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration3_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration4_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);

        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration1");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {

            var total = returnDecorationValue(hdn_Decoration1, Qty);
            document.getElementById("lblDecoration1_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost1.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration1, Qty2);

                document.getElementById("lblDecoration2_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost1.value = hdn_DecorationCost1.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration1, Qty3);

                document.getElementById("lblDecoration3_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost1.value = hdn_DecorationCost1.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration1, Qty4);

                document.getElementById("lblDecoration4_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost1.value = hdn_DecorationCost1.value + "~" + total;

        }

    }

    if (decname2) {
        document.getElementById("lblDecoration1_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration2_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration3_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration4_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration2");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {

            var total = returnDecorationValue(hdn_Decoration2, Qty);
            document.getElementById("lblDecoration1_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost2.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration2, Qty2);

                document.getElementById("lblDecoration2_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost2.value = hdn_DecorationCost2.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration2, Qty3);

                document.getElementById("lblDecoration3_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost2.value = hdn_DecorationCost2.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration2, Qty4);

                document.getElementById("lblDecoration4_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
        }
        else {
            total = 0;
        }
        hdn_DecorationCost2.value = hdn_DecorationCost2.value + "~" + total;

    }


    //}

    if (decname3) {
        document.getElementById("lblDecoration1_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration2_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration3_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration4_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);

        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration3");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var total = returnDecorationValue(hdn_Decoration3, Qty);
            document.getElementById("lblDecoration1_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost3.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration3, Qty2);

                document.getElementById("lblDecoration2_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost3.value = hdn_DecorationCost3.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration3, Qty3);

                document.getElementById("lblDecoration3_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost3.value = hdn_DecorationCost3.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration3, Qty4);

                document.getElementById("lblDecoration4_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost3.value = hdn_DecorationCost3.value + "~" + total;

        }
    }



    //if (decoration == 4) {
    if (decname4) {
        document.getElementById("lblDecoration1_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration2_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration3_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration4_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);

        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration4");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var total = returnDecorationValue(hdn_Decoration4, Qty);
            document.getElementById("lblDecoration1_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost4.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration4, Qty2);

                document.getElementById("lblDecoration2_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost4.value = hdn_DecorationCost4.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration3, Qty3);

                document.getElementById("lblDecoration3_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost4.value = hdn_DecorationCost4.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration4, Qty4);

                document.getElementById("lblDecoration4_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost4.value = hdn_DecorationCost4.value + "~" + total;
        }
    }

    //}
    //if (decoration == 5) {
    if (decname5) {
        document.getElementById("lblDecoration1_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        document.getElementById("lblDecoration2_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        document.getElementById("lblDecoration3_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        document.getElementById("lblDecoration4_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);

        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration5");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var total = returnDecorationValue(hdn_Decoration5, Qty);
            document.getElementById("lblDecoration1_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost5.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration5, Qty2);

                document.getElementById("lblDecoration2_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost5.value = hdn_DecorationCost5.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration5, Qty3);

                document.getElementById("lblDecoration3_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost5.value = hdn_DecorationCost5.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration5, Qty4);

                document.getElementById("lblDecoration4_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost5.value = hdn_DecorationCost5.value + "~" + total;
        }
    }

    //}
    //if (decoration == 6) {
    if (decname6) {
        document.getElementById("lblDecoration1_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration2_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration3_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);
        document.getElementById("lblDecoration4_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(0).toFixed(2);

        var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_ddldecoration6");
        var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
        if (ddlValue == 'Yes') {
            var total = returnDecorationValue(hdn_Decoration6, Qty);
            document.getElementById("lblDecoration1_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            hdn_DecorationCost6.value = total;
            if (Qty2 > 0) {
                total = returnDecorationValue(hdn_Decoration6, Qty2);

                document.getElementById("lblDecoration2_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost6.value = hdn_DecorationCost6.value + "~" + total;
            if (Qty3 > 0) {
                total = returnDecorationValue(hdn_Decoration6, Qty3);

                document.getElementById("lblDecoration3_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost6.value = hdn_DecorationCost6.value + "~" + total;
            if (Qty4 > 0) {
                total = returnDecorationValue(hdn_Decoration6, Qty4);

                document.getElementById("lblDecoration4_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
            }
            else {
                total = 0;
            }
            hdn_DecorationCost6.value = hdn_DecorationCost6.value + "~" + total;
        }

    }

}
function returnDecorationValue(hdn_Decoration1, qty) {

    var decorationArray = hdn_Decoration1.value.split('~');

    var cost = parseFloat(decorationArray[0]) + (qty * parseFloat(decorationArray[1]))
    var minimumCost = parseFloat(decorationArray[2])
    var total = cost > minimumCost ? cost : minimumCost

    return total;
}
    //}


    //Tocall_mainFunc();

