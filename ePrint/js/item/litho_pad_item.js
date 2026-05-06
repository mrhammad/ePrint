// JScript File
function PressOnChange(obj) 
{
    var ddlText = obj.options[obj.selectedIndex].text;
    var ddlValue = obj.options[obj.selectedIndex].value;
    var Digi = hid_DigitalPress.value;
    var Large = '';
    var arr1;
    if (estimateType == "digital") {
        arr1 = Digi.split('µ');
    }
    else {
        arr1 = Large.split('µ');
    }

    for (var i = 0; i < arr1.length; i++) {
        ////DigiID ±DigiName ±PaperID ±PaperName ±PrintSheetID ±JobSizeID ±GuillotineID ±GuillotineName ±PrintImageHeight ±PrintImageWidth ±GutterHorizontal ±GutterVertical ±
        ////SpoilageSheets ±  RunningSpoilage ± DefaultFirstTrim » DefaultFirstTrim ± DefaultSecondTrim » DefaultSecondTrim µ

        ////36 ± PressName ± 3 ± paperName ± 7  ± 10 ± 24 ± GuilName µ 
        ////37 ± press ± 22 ± yu ± 10 ± 6 ± 25 ± Maruthi µ 
        var arr2 = arr1[i].split('±');
        //if(arr2[0]==ddlValue)
        //{         

        if (estimateType == "digital") 
        {
            if (arr2[0] == ddlValue) {
                hdnpaperID.value = arr2[2];
                lblDefaultPaper.innerHTML = arr2[3];
                lblDefaultPaper.innerHTML = arr2[3];
                lblDefaultPaper.title = arr2[3];

                //To get Paper Height and Width on PaperID //
                PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue, take_error);                
                
                //Size
                for (j = 0; j < ddlPrintSheetSize.length; j++) {
                    if (ddlPrintSheetSize.options[j].value == arr2[4]) {
                        ddlPrintSheetSize.selectedIndex = j;
                        LoadToSheetCustom(arr2[4]);
                    }
                }
                for (j = 0; j < ddlJobItemSize.length; j++) {
                    if (ddlJobItemSize.options[j].value == arr2[5]) {
                        ddlJobItemSize.selectedIndex = j;
                        LoadToItemCustom(arr2[5]);
                    }
                }
                //guillotine
                hid_GuillotineID.value = arr2[6];
                lblGuillotine.innerHTML = arr2[7];
                lblGuillotine.title = arr2[7];
                if (lblGuillotine.innerHTML.length > 20) {
                    lblGuillotine.innerHTML = lblGuillotine.innerHTML.substring(0, 20) + "...";
                }

                var NonPrintHt = arr2[8].split('»');
                if ("PrintImageHeight" == NonPrintHt[0]) {
                    NonHeight = NonPrintHt[1];
                }
                var NonPrintWi = arr2[9].split('»');
                if ("PrintImageWidth" == NonPrintWi[0]) {
                    NonWeight = NonPrintWi[1];
                }

                if (arr2[10] != null) {
                    txtGutterHorizontal.value = arr2[10];
                    txtGutterVertical.value = arr2[11];

                    if (Number(arr2[11]) != 0 || Number(arr2[10]) != 0) {
                        document.getElementById("div_GuttersCustomSize").style.display = "block";
                        chkGutters.checked = true;
                    }
                    else {
                        document.getElementById("div_GuttersCustomSize").style.display = "none";
                        chkGutters.checked = false;
                    }
                }
                else {
                    txtGutterHorizontal.value = '';
                    txtGutterVertical.value = '';
                }
                //SpoilageSheets AND RunningSpoilage
                //In Case of Digital Press Procedure
                if (arr2[12] != null) {
                    var setupsploilage = arr2[12].split('»');
                    if (trim12(setupsploilage[0]) == "SpoilageSheets") {
                        txtSetupSpoilage.value = setupsploilage[1];
                        document.getElementById("spnPaperType").innerHTML = "sheet(s)";
                    }

                    var runningsploilage = arr2[13].split('»');
                    if (trim12(runningsploilage[0]) == "RunningSpoilage") {
                        txtRunningSpoilage.value = runningsploilage[1];
                    }
                }

                for (var k = 0; k < arr2.length; k++) {
                    var splitArr = arr2[k].split('»');
                    if (splitArr[0] == "DefaultFirstTrim") {
                        chkFirstTrim.checked = splitArr[1] == 1 ? true : false;
                    }
                    else if (splitArr[0] == "DefaultSecondTrim") {
                        chkSecondTrim.checked = splitArr[1] == 1 ? true : false;
                    }
                }

            } // if Condition 
        }
        if (estimateType == "largeformat") 
        {
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
            if (PressID == ddlValue) {
                //Size

                var PaperHeight = 0;
                var PaperWidth = 0;
                var PaperType = 0;
                var PaperLength = 0;

                for (var k = 0; k < arr2.length; k++) {
                    var arr3 = arr2[k].split('»');
                    if (arr3[0] == "PressID") {
                    }
                    if (arr3[0] == "PressName") {
                    }
                    if (arr3[0] == "PaperSizeID") {
                        hdnpaperID.value = arr3[1];
                    }
                    if (arr3[0] == "InventoryName") {
                        lblDefaultPaper.innerHTML = arr3[1];
                    }
                    if (arr3[0] == "SheetSizeID") {
                        for (j = 0; j < ddlPrintSheetSize.length; j++) {
                            if (ddlPrintSheetSize.options[j].value == arr3[1]) {
                                ddlPrintSheetSize.selectedIndex = j;
                                LoadToSheetCustom(arr3[1]);
                            }
                        }
                    }
                    if (arr3[0] == "JobSizeID") {
                        for (j = 0; j < ddlJobItemSize.length; j++) {
                            if (ddlJobItemSize.options[j].value == arr3[1]) {
                                ddlJobItemSize.selectedIndex = j;
                                LoadToItemCustom(arr3[1]);
                            }
                        }
                    }
                    if (arr3[0] == "GuillotineID") {
                        //guillotine
                        hid_GuillotineID.value = arr3[1];
                    }
                    if (arr3[0] == "GuillotineName") {
                        lblGuillotine.innerHTML = arr3[1];
                        lblGuillotine.title = arr3[1];
                        if (lblGuillotine.innerHTML.length > 20) {
                            lblGuillotine.innerHTML = lblGuillotine.innerHTML.substring(0, 20) + "...";
                        }
                    }
                    if (arr3[0] == "SetupSpoilage") {
                        txtSetupSpoilage.value = arr3[1];
                        document.getElementById("spnPaperType").innerHTML = arr3[2];
                        if (arr3[2] == "meter(s)") {
                            ForWebPrinting("yes");
                        }
                        else {
                            ForWebPrinting("no");
                        }
                    }
                    if (arr3[0] == "RunningSpoilage") {
                        txtRunningSpoilage.value = arr3[1];
                    }
                    if (arr3[0] == "CoverageSide1") {
                        txtInkCoverageSide1.value = arr3[1];
                    }
                    if (arr3[0] == "CoverageSide2") {
                        txtInkCoverageSide2.value = arr3[1];
                    }
                    if (arr3[0] == "PaperHeight") {
                        PaperHeight = arr3[1];
                    }
                    if (arr3[0] == "PaperWidth") {
                        PaperWidth = arr3[1];
                    }
                    if (arr3[0] == "PaperType") {
                        PaperType = arr3[1];
                        if (PaperType == "web printing") {
                            txtsectionheight.value = Number(PaperLength) * 1000;
                            txtsectionwidth.value = PaperWidth;
                        }
                    }
                    if (arr3[0] == "Length") {
                        PaperLength = arr3[1];
                    }
                    if (arr3[0] == "PrintImageHeight") {
                        NonHeight = arr3[1];
                    }
                    if (arr3[0] == "PrintImageWidth") {
                        NonWeight = arr3[1];
                    }
                    if (arr3[0] == "GutterHorizontal") {
                        txtGutterHorizontal.value = arr3[1];
                        if (Number(arr3[1]) != 0) {
                            document.getElementById("div_GuttersCustomSize").style.display = "block";
                            chkGutters.checked = true;
                        }
                        else {
                            document.getElementById("div_GuttersCustomSize").style.display = "none";
                            chkGutters.checked = false;
                        }
                    }
                    if (arr3[0] == "GutterVertical") {
                        txtGutterVertical.value = arr3[1];
                        if (Number(arr3[1]) != 0) {
                            document.getElementById("div_GuttersCustomSize").style.display = "block";
                            chkGutters.checked = true;
                        }
                        else {
                            document.getElementById("div_GuttersCustomSize").style.display = "none";
                            chkGutters.checked = false;
                        }
                    }
                }
                //To get Paper Height and Width on PaperID //
                PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue,take_error)
            }
        }
    }

    //}
    if (ddlValue == "0") 
    {
        lblDefaultPaper.innerHTML = "";
        hdnpaperID.value = '';

        lblGuillotine.innerHTML = "";
        hid_GuillotineID.value = '';
        
        ddlPrintSheetSize.selectedIndex = 0;
        LoadToSheetCustom(0);
        ddlJobItemSize.selectedIndex = 0;
        LoadToItemCustom(0);
    } //end of if


    if (obj.selectedIndex != 0) 
    {
        document.getElementById("spn_ddlPress").style.display = "none";
        if (lblDefaultPaper.innerHTML != '') {
            document.getElementById("spn_lblDefaultPaper").style.display = "none"
        }
        if (txtSetupSpoilage.value != '') {
            document.getElementById("spn_txtSetupSpoilage").style.display = "none";
        }
        if (txtRunningSpoilage.value != '') {
            document.getElementById("spn_txtRunningSpoilage").style.display = 'none';
        }
        if (ddlPrintSheetSize.selectedIndex != 0) {
            document.getElementById("spn_ddlPrintSheetSize").style.display = "none";
        }
        if (ddlJobItemSize.selectedIndex != 0) {
            document.getElementById("spn_ddlJobItemSize").style.display = 'none';
        }
    }
}
function take_error(err)
{
    
}
function OpenPaperPopUp(Type) 
{
    if (Type == 'paper') 
    {
        var papertype = document.getElementById("spnPaperType").innerHTML;
        if (trim12(papertype) == "sheet(s)" || trim12(papertype) == "Sheet(s)") 
        {
            papertype = "sheet";
        }
        else 
        {
            papertype = "roll";
        }
        PopupCenter(strSitepath+"common/common_popup.aspx?type=invselector&pg=estimate&item=paper&papertype=" + papertype + "", '950', '400')
    }

    return false;
}
////This Function name is used in the warehouse/inventory_item_selector.ascx
function SendPaperIDandName(id, values, papertype) 
{
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

function GetPaperValue(result) 
{
    hdn_PaperProperties.value = result;
    var papertype = document.getElementById("spnPaperType").innerHTML;
    if (trim12(papertype) == "sheet(s)") {

    }
    else 
    {
        var str2 = result.split('µ');
        var PaperSizeID = str2[0];
        var Height = str2[1];
        var Width = str2[2];
        txtsectionheight.value = Height;
        txtsectionwidth.value = Width;
        Calculations();//1
        
    }
}
function setwidth() 
{
    var is_ie = (/msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent));
    if (is_ie) 
    {
        document.getElementById("div_GuttersCustomSize").style.width = "206px";
    }
    else 
    {
        document.getElementById("div_GuttersCustomSize").style.width = "198px";
    }
}
setwidth();

var Previous = '';
function QtyFromStage1() 
{
    tempEstimateType = 'printbroker';
    ShowPrintBroker();
    ArrangePrintBroker(hid_QtyType.value);
    Use_add_more();
}
function Validate_Before_Outwork() 
{
    if (productType == "singleitem" || productType == "booklet" || productType == "pads") 
    {
        if (CreateItemValidation()) 
        {
            if (ValidatePaper_HeightWidth()) 
            {
                QtyFromStage1();
            }
        }
    }
    else if (estimateType == 'largeformat') 
    {
        if (CreateItemValidation()) 
        {
            if (ValidatePaper_HeightWidth()) 
            {
                QtyFromStage1();
            }
        }
    }
}

function GuillotineSelect() 
{
    PopupCenter(strSitepath+"common/common_popup.aspx?type=moreplant&pg=estimate", '800', '400')
}

function LoadToItemTitle(txtValue) 
{
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
function popup_phrasebook(type) 
{
    PopupCenter(strSitepath+"common/phrase_book.aspx?type=" + type, '800', '400')
}

//************************** PRINT BROKER *****************************
function PrintBrokerPrevious(PBtype) 
{
    if (PBtype == "show") {
        document.getElementById("div_stage_2").style.display = "none";
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
function ShowPrintBroker() 
{
    IsPrintBrokerDirect = false;
    PrintBrokerPrevious('show');
}
function PrintBrokerFinalStage() {
    PrintBrokerPrevious('show');
}

//************************** PRINT BROKER END *************************
//************************* OTHER COST ********************************

function BindOtherCost(id,itemtype)
{ 
    var catid = '';
    var othercosts = "";//hid_OtherCostValues_Load.value;//'OtherCostValues';    
    
    var divContent = document.getElementById("divContent");   
    divContent.innerHTML = '';            
    var spncatid = id.replace('spncost','spncostcatid');//"spncostcatid_"+i; 
    catid = document.getElementById(spncatid).innerHTML;
   
    //BY VINAY
    PageMethods.GetOtherCost_List(CompanyID, catid,function Create_Other(retnValue)
        {
                divContent.innerHTML ="";
                othercosts = retnValue;
                var GuillotineID= 0;
                var PaperID = 0;
                var PressID = 0;
                var EstOtherCostID = 0;
                if (itemtype == "s")
                {
                    GuillotineID = hid_GuillotineID.value;                            
                    PaperID = hdnpaperID.value;                            
                    PressID = ddlPress.value;
                }
                
                // *** To Bind OtherCosts ***//
                var str = othercosts.split('±');
                 
                var count = 0;
                for (var j=0;j< str.length;j++)
                { 
                    document.getElementById("divsubheader").style.display = 'block';
                    document.getElementById("divHeader").style.border = '1px solid silver';
                    var str2 = str[j].split('»'); 
                       
                    if (catid == str2[0])
                    {
                        count++;
                        var color1="#DADADA";
                        if(count%2==0)
                        {
                            color1="#EFEFEF";
                        }  
                        var CostCatID = str2[0];
                        var CostID = str2[1];
                        var CostName = str2[2];
                        var CostDesc = str2[3];
                        var CostTimeBasedID = str2[4];
                        var CostCalType = str2[5];
                        var Mode = 'add';
                       
                        var div22 = "<div style='height:20px;padding:2px;background-color:"+color1+"'>"
                            div22 += "<div style='float:left;width:49%;'><a href='#' onclick=javascript:OpenPopup('"+CostID+"','"+CostTimeBasedID+"','"+CostCalType+"','"+itemtype+"','"+Mode+"','','"+GuillotineID+"','"+PaperID+"','"+PressID+"','"+EstOtherCostID+"');return false;>"+CostName+"</a></div>";
                            div22 += "<div style='float:left;width:49%'>"+CostDesc+"</div>";
                            div22 += "<div class='onlyEmpty'></div>";
                            div22 += "</div>"
                        divContent.innerHTML = divContent.innerHTML + div22;
                        divContent.style.width = "100%";
                        divContent.style.height = "300px";
                        divContent.style.overflowX = "hidden";
                        divContent.style.overflowY = "scroll";
                    }
                    else
                    {
                    }
                }
                if(count == 0)
                {
                    document.getElementById("divsubheader").style.display = 'none';
                    document.getElementById("divHeader").style.border = '0px solid silver';
                    var div22 = "<div style='height:20px;padding:2px;background-color:"+color1+"'>"                                    
                        div22 += "<div class='emptyrecords' style='width:100%' align='center'><span class='HeaderText' style='text-align: center'>No record(s) found</span></div>";
                        div22 += "<div class='onlyEmpty'></div>";
                        div22 += "</div>"
                    divContent.innerHTML = divContent.innerHTML + div22;
                    divContent.removeAttribute("style");
                    divContent.style.width = "100%";
                    
                }                           
                // *** To Bind OtherCosts ***//              
        }
    ,other_error);
}
function other_error(error)
{
    
}
function OpenPopup(costid,costtypeid,caltype,itemtype,mode,otherinx,guillotineid,paperid,pressid,estothercostid)
{
    OtherIndex = '';
    OtherIndex = otherinx;     
    if (otherinx != '')
    {
        EditOtherPopupValues='';
        //EditOtherPopupValues += "Description" +"»"+ ArrayOtherCost[OtherIndex].Description;
        
        //alert(ArrayOtherCost[OtherIndex].HoursOrQty);
        if (ArrayOtherCost[OtherIndex].CalculationType == 't')
        {
            var OtherTime = ArrayOtherCost[OtherIndex].OtherCostTime;
            EditOtherPopupValues += "HourlyRate" +"»"+ OtherTime.HourlyRate +"±";                        
            EditOtherPopupValues += "SetUpTime" +"»"+ OtherTime.SetUpTime +"±";
            EditOtherPopupValues += "Hours" +"»"+ OtherTime.Hours +"±";
            EditOtherPopupValues += "Passes" +"»"+ OtherTime.Passes+"±";
            EditOtherPopupValues += "Cost" +"»"+ OtherTime.Cost+"±";
            EditOtherPopupValues += "Markup" +"»"+ OtherTime.Markup+"±";
            EditOtherPopupValues += "HourlyRunSpeed" +"»"+ OtherTime.HourlyRunSpeed;  
            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherTime.SellingPrice;                
        } 
        else if (ArrayOtherCost[OtherIndex].CalculationType == 'q')
        {
            var OtherQty = ArrayOtherCost[OtherIndex].OtherCostQuantity;
            EditOtherPopupValues += "UnitRate" +"»"+ OtherQty.UnitRate +"±";
            EditOtherPopupValues += "Quantity" +"»"+ OtherQty.Quantity +"±";
            EditOtherPopupValues += "Markup" +"»"+ OtherQty.Markup+"±";
            EditOtherPopupValues += "SetUpTime" +"»"+ OtherQty.SetUpTime +"±";
            EditOtherPopupValues += "HourlyRate" +"»"+ OtherQty.HourlyRate+"±";  
            EditOtherPopupValues += "Cost" +"»"+ OtherQty.Cost;
            //EditOtherPopupValues += "SellingPrice" +"»"+ OtherQty.SellingPrice;                                      
        } 
    }   
    PopupCenter(strSitepath+"common/common_popup.aspx?type=othercost&costid="+ costid +"&costtypeid=" +costtypeid+ "&caltype=" +caltype+ "&itemtype=" +itemtype+ "&mode=" +mode+ "&otherinx=" +OtherIndex+ "&pg=estimate&glid="+guillotineid+"&invid="+paperid+"&prid="+pressid+"&estcostid="+estothercostid+"",'800','500');               
}
function HighlightTab(isscost)
{
    document.getElementById(isscost).style.color="orange";
    for(var i=0;i<rowcount;i++)
    {
        var dd="spncost_"+i;  
        if (dd != '')
        {
            if(dd!=isscost)
            {                   
                if(document.getElementById("spncost_"+i)!=null)
                {                        
                    document.getElementById("spncost_"+i).style.color="black"; 
                }
            }                                                                         
        } 
    } 
    var type ='';
    if (estimateType == "othercost")                     
    {
        type = 'm';//other cost as main item from add page
    }
    else if (estimateType == "othercosttab")
    {
        type = 'u';//other cost as main item from summary page
    }
    else
    {
        type = 's';//other cost as sub item from add page
    }
    BindOtherCost(document.getElementById(isscost).id,type);                                    
}



function ShowOtherCostQtyDiv(type)
{
    if (type == "show")
    {
        document.getElementById("div_OtherCost_List").style.display = "block";
        Create_Other_Cost_Tab('u');//BY VINAY
    }
    else
    {
        document.getElementById("div_OtherCost_List").style.display = "none";
    }
}
function AddThisOtherCostItem()
{
    var txtOtherCostQtyID = txtOtherCostQty;
    var txtOtherCostQty = trim12(txtOtherCostQtyID.value);
    if (txtOtherCostQty == '')
    {
        document.getElementById("spn_txtOtherCostQty").style.display = "block";
        return false;
    }
    else if(IsIntegerParameter(txtWarehouseQty,'spn_txtOtherCostQty_number')== false)
    {
          return false;
    }        
    else
    {
        window.close();
    }       
}
function ShowOtherCost() 
{
    OtherIndex = '';
    IsOtherCost = false;
    document.getElementById("div_stage_2").style.display = "none";
    document.getElementById(divOtherCost).style.display = "block";
    document.getElementById(divOtherCostbtnNext).style.display = "none";
    Create_Other_Cost_Tab('s');//BY VINAY
}

function SaveQuestionInfo(strData) 
{
    var old = hid_OtherCost_Question.value;
    hid_OtherCost_Question.value = old + strData;
}

//************************ OTHER COST ENDS ****************************
function more_plant(section) 
{
    window.open(strSitepath +"common/common_popup.aspx?type=moreplant&pg=" + section + "", '', 'width=900px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
}
function more_paper(section) 
{
    window.open(strSitepath +"common/common_popup.aspx?type=morepaper&pg=" + section + "", '', 'width=900px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
}

function SectionsData(JCount, SCount) 
{
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
function CheckBooklet() 
{
    var pa = strSitepath+"jobs/jobs_edit.aspx";
    var ur = location.href;

    if (productType == "booklet") 
    {
        location.href = strSitepath+"estimates/estimate_item_form.aspx?item=bk";
        return false;
    }
    else if (location.href.toLowerCase() == pa.toLowerCase()) 
    {
        location.href = strSitepath+"estimates/estimate_item_form.aspx?pg=job";
        return false;
    }
    else 
    {
        location.href = strSitepath+"estimates/estimate_item_form.aspx";
        return false;
    }
}

//Main Warehouse
function Delete_Ware_MainItem_WebMethod(nos) 
{
    var EstWareID = warearray[nos].WareItemID;
    var firstConfirm = window.confirm('Are you sure, you want to remove ? ');
    if (firstConfirm) 
    {
        PageMethods.RemoveWarehouseItem(CompanyID, EstWareID);
        warearray.splice(nos, 1);
        LoadWareMainItemListOnEdit();
    }
}

var IsAnyOutWork = false;
var IsAnyWarehouse = false;
var IsAnyOtherCost = false;
    
    
function handler() 
{
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



function LoadMainWarehouseItems() 
{
    for (j = 0; j < ddlEsti.length; j++) 
    {
        if (ddlEsti.options[j].value == "warehouse") 
        {
            ddlEsti.selectedIndex = j;
            ShowEstimate("warehouse");
            ddlEsti.disabled = true;
        }
    }
    WarehousePrevious();

    //To Push WareData into Array//
    BindWareMainItemOnEdit();
}

function validatethis(val) 
{
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

function GuttersCustom(chID) {
    document.getElementById("div_GuttersCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_GuttersCustomSize").style.display = "block";
        txtGutterHorizontal.focus();
    }
    else {
        document.getElementById("div_GuttersCustomSize").style.display = "none";
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
                if (txtWareItemTitleID.value == '') {
                    txtWareItemTitleID.value = txtItemTitle.value;
                }
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

function SaveData() 
{
    
    //CollectQuantity(); //FOR BOOKLET see TakeQtyValues(bookArr[0].QuantityList);

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

    hid_booklet_save.value = StoreBooklet;

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


function MadeDefault() 
{
    document.getElementById(div_Product_Type).style.display = "none";
    ////Digital
    document.getElementById(div_only_digitalsleft).style.display = "none";
    document.getElementById(div_only_digitalsright).style.display = "none";

    IsWareDirect = false;

    ///PRINT BROKER
    IsPrintBrokerDirect = false;

    //OTHER COSTS
    IsOtherCost = false;
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


function CalculateBookletSection() 
{
    
    if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) 
    {
        if (txtNoOfPagesInSection.value != '') 
        {
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
        document.getElementById("div_price_valid").style.display = "none";
        div_price_catalogue.style.display = "none";
        div_pricecatalogue_summary.style.display = "block";
        document.getElementById("div_stage_4").style.display = "block";
        BindCatalogueDesc();
    }
    else {
        document.getElementById("div_price_valid").style.display = "block";
    }

}
function PricePreviousStage4() {
    div_pricecatalogue_summary.style.display = "none";
    document.getElementById("div_stage_4").style.display = "none";
    div_price_catalogue.style.display = "block";
}



function CreateItemNext() 
{
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
                        document.getElementById("div_stage_2").style.display = "none";
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
                        document.getElementById("div_stage_2").style.display = "none";
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
                if (CreateItemValidation()) 
                {
                    if (ValidatePaper_HeightWidth()) 
                    {
                        StoreSections(); //Store the values in Book Array
                        document.getElementById("div_stage_2").style.display = "none";
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

                    document.getElementById("div_stage_2").style.display = "none";
                    document.getElementById("div_stage_4").style.display = "block";
                    document.getElementById(div_LargeFormatSummary).style.display = "block";
                    document.getElementById(divSingleBookPadLargeFinalbtn).style.display = "block";

                    BindLargeFormatDesc(); //To bind Large Format item description
                }
            }
        }
        else if (estimateType == 'printbroker') 
        {
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

function CallPriceCatalogueDiv() 
{
    
    div_price_catalogue.style.display = "block";
    
    if (hid_Price_CustomerID.value == '' || hid_Price_CustomerID.value != ClientID)//if(IsPriceLoaded==false)
    {
        
        IsPriceLoaded = true;
        if (RequestType == "add" || RequestType == "more") 
        {
            txtCatalogueItemTitleID.value = txtItemTitle.value;
        }
        
        hid_Price_CustomerID.value = ClientID;
        hid_Customer_Name.value = ClienName;
        
        document.getElementById("ds00").style.display = "block";
        document.getElementById("abs").style.display = "block";
        document.getElementById("div_CatalogueHeader").style.display = "none";
        
        __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$UCItemAdd$UCPriceID$lnkLoadPriceCatalogue', '');

        takeIDofInterval = setInterval("CallAfter2sec()", 200);
        
    }
    document.getElementById("div_stage_2").style.display = "none";
}

var IsPriceLoaded = false;
function ForSummary(obj) 
{

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

function Color_AssignToSummary() 
{
////    var color = '';
////    if (chkDoubleSided.checked) 
////    {
////        color = "Side1: " + CheckDDLValues(ddlColors.value) + ", Side2: " + CheckDDLValues(ddlColors_2.value) + "";
////    }
////    else 
////    {
////        color = "Single Sided Print: "+CheckDDLValues(ddlColors.value);
////    }
////    txtSummaryColor.value = color;
////    txtbookletColor.value = color;
////    txtPadColor.value = color;
////    txtLargeColor.value = color;
}
function CheckDDLValues(values) 
{
    if (values == "color") 
    {
        return "Colour";
    }
    else 
    {
        return "Black & White";
    }
}
function ItemSize_AssignToSummary(Parameter) 
{
////    var JobSizeText = '';
////    if (ChkJobFlatCustom.checked && Parameter==null) 
////    {
////        JobSizeText = "Height:" + txtitemheight.value + "mm; ";
////        JobSizeText = JobSizeText + " Width:" + txtitemwidth.value + "mm;";
////    }
////    else if (ChkJobFlatCustom.checked && Parameter == "onblur") 
////    {
////        JobSizeText = "Height:" + txtitemheight.value + "mm; ";
////        JobSizeText = JobSizeText + " Width:" + txtitemwidth.value + "mm;";
////    }
////    else 
////    {
////        JobSizeText = ddlJobItemSize.options[ddlJobItemSize.selectedIndex].text;
////    }
////    if (JobSizeText == "--- Select ---") {
////        JobSizeText = "";
////    }

////    txtSummaryItemSize.value = JobSizeText;
////    txtPadItemSize.value = JobSizeText;
////    txtbookletSize.value = JobSizeText;
////    txtLargeSize.value = JobSizeText;

}
function Paper_AssignToSummary() 
{
////    var paperData = lblDefaultPaper.innerHTML;
////    txtSingleMaterial.value = paperData;
////    txtbookletMaterial.value = paperData;
////    txtPadMaterial.value = paperData;
////    txtLargeMaterial.value = paperData;
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

    if (Etype == "S") 
    {
    
    }
    else if (Etype == "B") 
    {
        
    }
    else if (Etype == "P") 
    {
        
    }
    else if (Etype == "L") 
    {
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




function ShowEstimate(ddlValue, isany) 
{
    tempEstimateType = '';

    if (ddlEstimateType.selectedIndex == 0) {
        document.getElementById("spn_Label3").style.display = "block";
    }
    else {
        document.getElementById("spn_Label3").style.display = "none";
    }

    ///MadeDefault();         //make default as NONE
    ///MadeProductDefault();  //make default as NONE

    //ArrayOtherCost.length = 0;//Clear Othercost Array
    var reqtype = funreqtype();
    if (ddlValue == 'litho') 
    {
////        document.getElementById("lblheader").innerHTML = "Create Item: Digital Sheetfed ";
        if (isany == null) 
        {
            document.getElementById(div_Product_Type).style.display = "block";
            //========= Loading of Digital Press ==============================================
            ddlPress.length = 0;           
            var arr1 = hid_DigitalPress.value.split('µ');
            ddlPress.options.add(new Option("--- Select ---", "0", 0));
            for (var i = 0; i < arr1.length; i++) 
            {
                if (arr1[i] != '') {
                    var arr2 = arr1[i].split('±');
                    ddlPress.options.add(new Option(arr2[1], arr2[0], i));
                }
            }
////            ClaerSectionData(); //CLEAR DATA
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
                ProductTypeShow("pads");
                DdlProductType.selectedIndex = 0;
            }
            if (QueryType == "more") {
                ProductTypeShow("pads");
                DdlProductType.selectedIndex = 0;
            }
        }
    }
////    else if (ddlValue == 'largeformat') 
////    {
////        document.getElementById("lblheader").innerHTML = "Create Item: Large Format";
////        if (isany == null) {
////            //========= Loading of Large Format Press ==============================================
////            ddlPress.length = 0;
////            var arr1 = hid_LargeFormatPress.value.split('µ');
////            ddlPress.options.add(new Option("--- Select ---", "0", 0));
////            for (var i = 0; i < arr1.length; i++) {
////                if (arr1[i] != '') {
////                    var arr2 = arr1[i].split('±');
////                    var Arr3 = arr2[0].split('»');
////                    var Arr4 = arr2[1].split('»');
////                    var PressName = '';
////                    var PressID = '';
////                    if (Arr3[0] == "PressID") {
////                        PressID = Arr3[1];
////                    }
////                    if (Arr4[0] == "PressName") {
////                        PressName = Arr4[1];
////                    }
////                    ddlPress.options.add(new Option(PressName, PressID, i));
////                }
////            }
////            //========= Loading of Large Format Press ENDS ==============================================
////            ClaerSectionData(); //CLEAR DATA
////            //To make defualt large press selected//                 
////            if (reqtype == 'add' || reqtype == 'more') {
////                if (hid_DefaultLargePress.value != '-1') {
////                    for (var k = 0; k < ddlPress.length; k++) {
////                        if (ddlPress.options[k].value == hid_DefaultLargePress.value) {
////                            ddlPress.selectedIndex = k;
////                        }
////                    }
////                    estimateType = ddlValue;
////                    PressOnChange(ddlPress);
////                    LoadCalculations(ddlPress.id);
////                }
////            }
////        }

////        document.getElementById(div_chk_Run_OnQty).style.display = "none";
////        document.getElementById(div_Finished_Qty).style.display = "block";
////        document.getElementById(div_only_digitalsleft).style.display = "block";
////        document.getElementById(div_only_digitalsright).style.display = "block";
////        ////Print Quality Selector
////        document.getElementById(div_Print_Quality_Sector).style.display = "block";
////        document.getElementById(div_Ink_Coverage).style.display = "block";

////        ddlProd.selectedIndex = '0';
////        productType = '';
////    }
////    else if (ddlValue == 'printbroker') 
////    {
////        IsPrintBrokerDirect = true;
////        document.getElementById("div_stage_2").style.display = "none";
////        document.getElementById(print_broker).style.display = "block";
////        document.getElementById("lblheader").innerHTML = "Supplier Request For Quote Item Description";
////        ddlProd.selectedIndex = '0';
////        productType = '';
////        getPBItemTitle(txtItemTitle.value);
////        
////        if (RequestType == "add" || RequestType == "more") 
////        {
////            Use_add_more();
////        }
////    }
////    else if (ddlValue == 'warehouse') 
////    {
////        document.getElementById("lblheader").innerHTML = "Create Item: Warehouse Item";
////        IsWareDirect = true;
////        document.getElementById("div_stage_2").style.display = "none";
////        document.getElementById(div_StockOnly).style.display = "block";
////        document.getElementById(div_Ware_Next_Button).style.display = "block";
////        ddlProd.selectedIndex = '0';
////        productType = '';
////        Call_Warehouse_Ind_fun("ware_1");
////    }
////    else if (ddlValue == 'othercost') 
////    {
////        document.getElementById("lblheader").innerHTML = "Create Item: Other Cost";
////        //ArrayOtherCost.length = 0;
////        IsOtherCost = true;
////        document.getElementById("div_stage_2").style.display = "none";
////        document.getElementById(divOtherCost).style.display = "block";
////        document.getElementById(divOtherCostbtnNext).style.display = "block";
////        btncostcentrePrevious.value = "Previous";
////        ddlProd.selectedIndex = '0';
////        productType = '';
////        Create_Other_Cost_Tab('m');//BY VINAY
////    }
////    else if (ddlValue == 'pricecatalogue') 
////    {
////        document.getElementById("lblheader").innerHTML = "Create Item: Price Catalogue";
////        ddlProd.selectedIndex = '0';
////        CallPriceCatalogueDiv();
////    }

////    ////selected types       
////    estimateType = ddlValue;
////    if (ddlValue == '') 
////    {
////        productType = '';
////        estimateType = '';
////    }
}
   

function MadeProductDefault() 
{
////    document.getElementById(div_Finished_Qty).style.display = "none";
////    document.getElementById(div_Booklet_Qty).style.display = "none";
////    document.getElementById(div_Pads_Qty).style.display = "none";
////    document.getElementById(div_Booklet_One).style.display = "none"; //booklet
////    document.getElementById(div_Pads_One).style.display = "none"; //Pads
////    document.getElementById(div_Print_Layout).style.display = "block"; //Print_Layout

////    document.getElementById(div_BookletNoOfPagesInSection).style.display = "none"; //booklet
////    document.getElementById(div_BookletNoOfSignatures).style.display = "none"; //booklet      
////    document.getElementById(div_BookletFormat).style.display = "none"; //booklet  

////    document.getElementById(div_Section_Ref).style.display = "none";
////    document.getElementById(div_BtnNextSection).style.display = "none";
////    document.getElementById(div_Booklet_Delete).style.display = "none";
////    //MAKE ALL SUMMARY TO NONE
////    AllSummaryNone();
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

////        document.getElementById(div_BtnNextSection).style.display = "block";
////        document.getElementById(div_Booklet_Delete).style.display = "block";

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


function QuantityClass() 
{
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

    if (estimateType == "digital") 
    {
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
    document.getElementById("spn_txtItemTitle").style.display = "none";

    if (trim12(txtItemTitle.value) == "") {
        document.getElementById("spn_txtItemTitle").style.display = "block";
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

    if (!CheckDecimalPlus(txtSetupSpoilage.value, 'spn_txtSetupSpoilage', 'spn_txtSetupSpoilage_number', 'yes')) {
        IsCorrect = false;
    }
    if (!CheckDecimalPlus(txtRunningSpoilage.value, 'spn_txtRunningSpoilage', 'spn_txtRunningSpoilage_number', 'yes')) {
        IsCorrect = false;
    }  
    
    if (CheckReqCompare(txtNoOfLeavesPerPad.value, 'spn_txtNoOfLeavesPerPad', 'spn_txtNoOfLeavesPerPad_number')) {
        IsCorrect = false;
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
//    if (CheckReqCompare(txtGutterHorizontal.value, 'spn_txtGutterHorizontal_number', 'spn_txtGutterHorizontal_number')) {
//        IsCorrect = false;
//    }
//    if (CheckReqCompare(txtGutterVertical.value, 'spn_txtGutterHorizontal_number', 'spn_txtGutterHorizontal_number')) {
//        IsCorrect = false;
    //    }
    //alert('End:' + IsCorrect);
        hdn_PortraitValue.value = txtportrait.value;
        hdn_LandscapeValue.value = txtlandscape.value;
    if (IsCorrect) 
    {
        return true;
    }
    else 
    {
        return false;
    }
}

function Calculations() 
{
//    CalculateLandscape();
//    CalculatePortrait();
    G_CalculateLandscape("d");
    G_CalculatePortrait("d"); // changed By Pradeep

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

//        CalculateLandscape();
        //        CalculatePortrait();
        G_CalculateLandscape("d");
        G_CalculatePortrait("d"); // changed By Pradeep
        
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

//function CalculateLandscape() {
//    var Index = DdlProductType.selectedIndex;
//    var FormatIndex = ddlFormat.selectedIndex;
//    if ((chkGutters.checked) && (chkRestrictions.checked)) {
//        hdnselected.value = "both";
//        ASH = Number(SH.value) - Number(NonHeight);
//        ASW = Number(SW.value) - Number(NonWeight);

//        A = Number(ASH) - Number(HrzGutter.value);
//        B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));
//        C = parseInt(B);

//        if (DdlProductType.value == "booklet") {
//            A = Number(ASH) + Number(HrzGutter.value);
//            B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));

//            A = parseInt(A);
//            B = parseInt(B);
//        }

//        row = C;

//        D = Number(ASW) - Number(VtGutter.value);
//        E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));


//        if (DdlProductType.value == "booklet") {
//            D = Number(ASW) + Number(VtGutter.value);
//            E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));

//            D = parseInt(D);
//            E = parseInt(E);
//        }

//        F = parseInt(E);
//        col = F;

//        Result = C * F;

//        if (DdlProductType.value == "booklet") {
//            Result = (C * F) * 2;
//        }
//        hdnvertical.value = VtGutter.value;
//        hdnhorizontal.value = HrzGutter.value;

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, true, "landscape");
//    }
//    else if (chkGutters.checked) {
//        hdnselected.value = "gutters";
//        A = Number(SH.value) - Number(HrzGutter.value);
//        B = Number(A) / Number(Number(IH.value) + Number(HrzGutter.value));
//        C = parseInt(B);
//        row = C;
//        var Z;
//        if (DdlProductType.value == "booklet") {
//            C = Number(Number(SH.value) + Number(HrzGutter.value)) / Number(Number(IH.value) + Number(HrzGutter.value));
//            E = Number(Number(SW.value) + Number(VtGutter.value)) / Number(Number(IW.value) + Number(VtGutter.value));
//            C = parseInt(C);
//            E = parseInt(E);
//            Z = E;
//        }
//        D = Number(SW.value) - Number(VtGutter.value);
//        E = Number(D) / Number(Number(IW.value) + Number(VtGutter.value));
//        F = parseInt(E);
//        col = F;
//        Result = C * F;
//        if (DdlProductType.value == "booklet") {
//            Result = (C * Z) * 2;
//        }
//        hdnvertical.value = VtGutter.value;
//        hdnhorizontal.value = HrzGutter.value;

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, false, "landscape");
//    }
//    else if (chkRestrictions.checked) {
//        hdnselected.value = "restriction";

//        ASH = Number(SH.value) - Number(NonHeight);
//        ASW = Number(SW.value) - Number(NonWeight);
//        A = Number(ASH) / Number(IH.value);
//        B = Number(ASW) / Number(IW.value);
//        row = parseInt(A);
//        col = parseInt(B);
//        Result = col * row;
//        if (DdlProductType.value == "booklet") {
//            Result = col * row * 2;
//        }
//        hdnhorizontal.value = "0";
//        hdnvertical.value = "0";
//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, true, "landscape");

//    }
//    else {
//        hdnselected.value = "none";
//        A = Number(SH.value) / Number(IH.value);
//        B = Number(SW.value) / Number(IW.value);

//        if (DdlProductType.value == "booklet") {
//            A = Number(SH.value) / Number(IH.value);
//            B = Number(SW.value) / Number(IW.value); //*2);
//            A = parseInt(A);
//            B = parseInt(B);
//        }

//        C = parseInt(A); //Math.round(col_land)
//        D = parseInt(B); //Math.round(row_land)

//        row = C;
//        col = D;
//        if (DdlProductType.value == "booklet") {
//            Result = (col * row) * 2;
//        }
//        else {
//            Result = col * row;
//        }

//        hdnhorizontal.value = "0";
//        hdnvertical.value = "0";
//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, false, "landscape");
//    }

//    row_land.value = row;

//    col_land.value = col;

//    if (DdlProductType.value == "booklet") {
//        if (ddlFormat.value == "Landscape") {
//            if (isNaN(Result)) {
//                txtPagesPerSignature.value = "0";
//                result_land.value = "0";
//                txtNoOfSignatures.value = "0";
//            }
//            else {
//                txtPagesPerSignature.value = parseInt(Result);
//                result_land.value = Result;
//                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(Result);
//                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
//                    txtNoOfSignatures.value = "0";
//                }
//                else {
//                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
//                        txtNoOfSignatures.value = "1"
//                    }
//                    else {
//                        txtNoOfSignatures.value = parseInt(NoOfSignature, 0);
//                    }
//                }
//            }
//        }
//    }
//    else {
//        if (isNaN(Result)) {
//            result_land.value = "0";
//        }
//        else {
//            result_land.value = Result;
//        }
//    }
//}


//function CalculatePortrait() {
//    var Index = DdlProductType.selectedIndex;
//    var FormatIndex = ddlFormat.selectedIndex;
//    if ((chkGutters.checked) && (chkRestrictions.checked)) {
//        hdnselected.value = "both";

//        // ROW Calculation
//        var Row_A1 = Number(SH.value) - Number(NonHeight);
//        Row_A1 = Number(Row_A1) - Number(HrzGutter.value);
//        var Row_A2 = Number(IW.value) + Number(HrzGutter.value);
//        var Row_A = Number(Row_A1) / Number(Row_A2);
//        Row_A = parseInt(Row_A);

//        //COLUMN Calculation
//        var Col_B1 = Number(SW.value) - Number(NonWeight);
//        Col_B1 = Number(Col_B1) - Number(VtGutter.value);
//        var Col_B2 = Number(IH.value) + Number(VtGutter.value);
//        var Col_B = Number(Col_B1) / Number(Col_B2);
//        Col_B = parseInt(Col_B);

//        Result = Row_A * Col_B;

//        if (DdlProductType.value == "booklet") {
//            Result = Number(Row_A) * Number(Col_B);
//            Result = Number(Result) * 2;
//        }

//        row = Row_A;
//        col = Col_B;

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, true, "portrait");
//    }
//    else if (chkGutters.checked) {
//        hdnselected.value = "gutters";

//        // ROW Calculation
//        var Row_A1 = Number(SH.value) - Number(HrzGutter.value);
//        var Row_A2 = Number(IW.value) + Number(HrzGutter.value);
//        var Row_A = Number(Row_A1) / Number(Row_A2);
//        Row_A = parseInt(Row_A);

//        //COLUMN Calculation
//        var Col_B1 = Number(SW.value) - Number(VtGutter.value);
//        var Col_B2 = Number(IH.value) + Number(VtGutter.value);
//        var Col_B = Number(Col_B1) / Number(Col_B2);
//        Col_B = parseInt(Col_B);

//        Result = Row_A * Col_B;

//        if (DdlProductType.value == "booklet") {
//            Result = Number(Row_A) * Number(Col_B);
//            Result = Number(Result) * 2;
//        }

//        row = Row_A;
//        col = Col_B;

//        hdnvertical.value = VtGutter.value;
//        hdnhorizontal.value = HrzGutter.value;

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), true, false, "portrait");
//    }
//    else if (chkRestrictions.checked) {
//        hdnselected.value = "restriction";
//        // ROW Calculation
//        var Row_A1 = Number(SH.value) - Number(NonHeight);
//        var Row_A2 = Number(IW.value);
//        var Row_A = Number(Row_A1) / Number(Row_A2);
//        Row_A = parseInt(Row_A);

//        //COLUMN Calculation
//        var Col_B1 = Number(SW.value) - Number(NonWeight);
//        var Col_B2 = Number(IH.value);
//        var Col_B = Number(Col_B1) / Number(Col_B2);
//        Col_B = parseInt(Col_B);

//        Result = Row_A * Col_B;

//        if (DdlProductType.value == "booklet") {
//            Result = Number(Row_A) * Number(Col_B);
//            Result = Number(Result) * 2;
//        }
//        row = Row_A;
//        col = Col_B;
//        
//        hdnhorizontal.value = "0";
//        hdnvertical.value = "0";

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, true, "portrait");

//    }
//    else {
//        hdnselected.value = "none";

//        A = Number(SH.value) / Number(IW.value);
//        B = Number(SW.value) / Number(IH.value);

//        if (DdlProductType.value == "booklet") {
//            A = Number(SH.value) / Number(IW.value);
//            B = Number(SW.value) / Number(IH.value);
//        }

//        C = parseInt(A); //Math.round(col_port)
//        D = parseInt(B); //Math.round(row_port)
//        row = C;
//        col = D;
//        if (DdlProductType.value == "booklet") {
//            Result = (row * col) * 2;
//        }
//        else {
//            Result = row * col;
//        }

//        hdnhorizontal.value = "0";
//        hdnvertical.value = "0";

//        RollCalculation(SW.value, SH.value, IW.value, IH.value, VtGutter.value, HrzGutter.value, Number(NonWeight), Number(NonHeight), false, false, "portrait");
//    }
//    row_port.value = row;
//    col_port.value = col;


//    if (DdlProductType.value == "booklet") {
//        if (ddlFormat.value == "Portrait") {
//            if (isNaN(Result)) {
//                txtPagesPerSignature.value = "0";
//                result_port.value = "0";
//                txtNoOfSignatures.value = "0";
//            }
//            else {
//                txtPagesPerSignature.value = parseInt(Result);
//                result_port.value = Result;

//                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Result;
//                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
//                    txtNoOfSignatures.value = "0";
//                }
//                else {
//                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
//                        txtNoOfSignatures.value = "1"
//                    }
//                    else {
//                        txtNoOfSignatures.value = parseInt(NoOfSignature);
//                    }
//                }
//            }
//        }
//    }
//    else {
//        if (isNaN(Result)) {
//            result_port.value = "0";
//        }
//        else {
//            result_port.value = Result;
//            hdn_Protrait = Result;
//        }
//    }
//}

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
            else if ("PackedInQty" == arr2[0]) 
            {
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
function MakeArrayNull() 
{
////    ArrayOtherCost.length = 0;
////    //bind
////    document.getElementById("href_ShowOtherCostSubItem").style.display = "none";
////    document.getElementById("div_OtherCostSubItems").style.display = "none";

////    //By Vinay 30/12/2009
////    bookArr.length = 0;
////    document.getElementById("div_btn_booklet_sections").innerHTML = '';

////    //FOR WAREHOUSE ITEMS ALSO
////    warearray.length = 0;

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

    function Create_Other_Cost_Tab(para)
    {
        var div_other_tab = document.getElementById("div_other_tab");
        if(div_other_tab.innerHTML!='')
        {
            HighlightTab('spncost_0');
            BindOtherCost(document.getElementById('spncost_0').id, para);
            return false;
        }
        
        PageMethods.GetOtherCost_Tab_List(CompanyID,function SuccessReturn(returnValue)
        {
            var finalString  = '';
            var str2 = returnValue.split('±');
            rowcount = str2.length;
            for (var i = 0; i < str2.length; i++)
            {
                var str3 = str2[i].split('»');
                var CostName = trim12(str3[1]);
                var LimitCostName = '';
                if (CostName.length > 13)
                {
                    LimitCostName = CostName.substring(0, 13) + "...";
                }
                else
                {
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
        },other_error);
        
    }
function other_error(error){}

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
            if (trim12(propqty) == "UnitRate") 
            {
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
function WarehouseSummaryBack(sumType) 
{
    if (sumType == 'back') {
        document.getElementById(div_StockOnly).style.display = "block";
        document.getElementById("div_stage_4").style.display = "none";
        document.getElementById(div_WarehouseSummary).style.display = "none";
        document.getElementById("lblheader").innerHTML = "Create Item";
        document.getElementById("div_none").style.display = "none";
    }
    else 
    {
        var wareCount = 0;
        for(var i=0;i<warearray.length;i++)
        {
            if(warearray[i].IsDeleted == 0)
            {
                wareCount++;
            }
        }
        if (wareCount > 0) 
        {
            document.getElementById("div_none").style.display = "none";
            document.getElementById(div_StockOnly).style.display = "none";
            document.getElementById("div_stage_4").style.display = "block";
            document.getElementById(div_WarehouseSummary).style.display = "block";
            document.getElementById("lblheader").innerHTML = "Customer Item Description";
            BindWarehouseDesc(); //To bind Item description Labels
        }
        else 
        {
            document.getElementById("div_none").style.display = "block";
            document.getElementById("span_none").innerHTML = "Please select at least one Warehouse Item";
        }
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
    for (var p = 0; p < warearray.length; p++) 
    {
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
                objWare.IsDeleted ="0";
            }
        }

        warearray.push(objWare);
    }
    //To Show the Warehouse List //
    LoadWareMainItemListOnEdit();
}

function LoadWareMainItemListOnEdit() {
    var dd = '';
    for (var p = 0; p < warearray.length; p++) 
    {
        if(warearray[p].IsDeleted==0)
        {
            var color1 = "#DADADA";
            if (p % 2 == 0) 
            {
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
                else if (arr_2[0] == "QtyType")
                {
                    if(arr_2[1]=="single")
                    {
                        moreQty("single");
                    }
                    else
                    {
                        moreQty("more");
                    }
                }
                else if (arr_2[0] == "Qty") 
                {
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
function PriceProperties() 
{
    this.PriceCatalogueID;
    this.CatalogueName;
    this.Quantity;
    this.Price;
    this.Markup;
    this.Cost;
}

function CatalogueOnEdit() 
{
    //To Make Estimatetype dropdown selected
    for (j = 0; j < ddlEsti.length; j++) 
    {
        if (ddlEsti.options[j].value == "pricecatalogue") 
        {
            ddlEsti.selectedIndex = j;
            ShowEstimate("pricecatalogue");
            ddlEsti.disabled = true;
        }
    }

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

            for (var j = 0; j < CataArr_2.length; j++) {
                var CataArr_3 = CataArr_2[j].split('»');
                if (CataArr_3[0] == "PriceCatalogueID") {
                    PriceCatalogueID = CataArr_3[1];
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
            }
            var ObjPrice = new PriceProperties();
            ObjPrice.PriceCatalogueID = PriceCatalogueID;
            ObjPrice.CatalogueName = CatalogueName;
            ObjPrice.Quantity = Quantity;
            ObjPrice.Price = Price;
            ObjPrice.Markup = Markup;
            ObjPrice.Cost = Cost;
            Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE
        }
    }
    CatalogueLoad();
}

    function ClearFilters() 
    {
        document.getElementById(txtPriceCatalogueSerach_id).value = "";
        document.getElementById(ddlCategory_id).value = 0;
        document.getElementById(chkAllItems_id).checked = false;                                    
    }
    function CheckOnluOneChk(para)
    {
        document.getElementById(chkAllItems_id).checked = false;
        document.getElementById(chkThisCustomer_id).checked = false;
        document.getElementById(chkUnallocated_id).checked = false;
        if(para=="U")
        {
            document.getElementById(chkUnallocated_id).checked = true;
        }
        else if(para=="A")
        {
            document.getElementById(chkAllItems_id).checked = true;
        }
        else if(para=="T")
        {
            document.getElementById(chkThisCustomer_id).checked = true;
        }
    }

//==============> PRICE CATALOGUE <==============================================
function ShowCatalogueList() {
    if (document.getElementById("div_selected_catalogue").style.display == "block") {
        document.getElementById("div_selected_catalogue").style.display = "none";
        document.getElementById("hrefShowCatalogue").style.display = "block";
    }
    else {
        document.getElementById("hrefShowCatalogue").style.display = "none";
        document.getElementById("div_selected_catalogue").style.display = "block";
    }
}
function storeToArray(PriceCatalogueID, CatalogueName, MatrixType) {
    var CheckEmpty = false;
    if (MatrixType == "P") {
        for (var i = 1; i < 5; i++) {
            if (document.getElementById("txt_req_qty_" + i + "").value != '') {
                CheckEmpty = true;
            }
        }
        if (CheckEmpty == false) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please enter at least one Quantity";
            document.getElementById("div_price_qty_valid").style.display = "block";
            return false;
        }
        else {
            document.getElementById("div_price_qty_valid").style.display = "none";
            document.getElementById("div_price_valid").style.display = "none";
            Price_Array.length = 0;
            for (var i = 1; i < 5; i++) {
                var Quantity = document.getElementById("txt_req_qty_" + i + "").value;
                if (Quantity != '') {
                    if (!isNaN(Quantity)) {
                        var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace(GetCurrencyinRequiredFormate("",true), '');
                        var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                        var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;

                        var ObjPrice = new PriceProperties();
                        ObjPrice.PriceCatalogueID = PriceCatalogueID;
                        ObjPrice.CatalogueName = CatalogueName;
                        ObjPrice.Quantity = Quantity;
                        ObjPrice.Price = SellingPrice;
                        ObjPrice.Markup = Markup;
                        var Quantity_Cost = Number(Quantity) * Number(Cost);
                        ObjPrice.Cost = Quantity_Cost;

                        Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                        
                    }
                }
            }

            CatalogueLoad();
            HidePanle();
            document.getElementById("hrefShowCatalogue").style.display = "block";
        }
    }
    else if (MatrixType == "S") {
        for (var i = 1; i < 5; i++) {
            if (document.getElementById("ddl_req_qty_" + i + "").value != 'select') {
                CheckEmpty = true;
            }
        }
        if (CheckEmpty == false) {
            document.getElementById("span_price_qty_valid").innerHTML = "Please select at least one Quantity";
            document.getElementById("div_price_qty_valid").style.display = "block";
            return false;
        }
        else {
            document.getElementById("div_price_qty_valid").style.display = "none";
            document.getElementById("div_price_valid").style.display = "none";
            Price_Array.length = 0;
            for (var i = 1; i < 5; i++) {
                var ddlObj = document.getElementById("ddl_req_qty_" + i + "");
                var Quantity = ddlObj.options[ddlObj.selectedIndex].text;
                if (Quantity != 'select') {
                    if (!isNaN(Quantity)) {
                        var SellingPrice = document.getElementById("spn_QtyPrice_" + i + "").innerHTML.replace(GetCurrencyinRequiredFormate("",true), '');
                        var Cost = document.getElementById("spn_QtyCost_" + i + "").innerHTML;
                        var Markup = document.getElementById("spn_QtyMarkup_" + i + "").innerHTML;

                        var ObjPrice = new PriceProperties();
                        ObjPrice.PriceCatalogueID = PriceCatalogueID;
                        ObjPrice.CatalogueName = CatalogueName;
                        ObjPrice.Quantity = Quantity;
                        ObjPrice.Price = SellingPrice;
                        ObjPrice.Markup = Markup;
                        ObjPrice.Cost = Cost;

                        Price_Array.push(ObjPrice); //INSERTING INTO THE ARRAY FOR DB PURPOSE                        
                    }
                }
            }

            CatalogueLoad();
            HidePanle();
            document.getElementById("hrefShowCatalogue").style.display = "block";
        }
    }
    CopyToItemDescription();
}
function RemoveCatalogueName(ind) {
    Price_Array.splice(ind, 1);
    CatalogueLoad();
    if (Price_Array.length == 0) {
        document.getElementById("hrefShowCatalogue").style.display = "none";
        HidePanle();
    }
}
function CatalogueLoad() 
{
    var HTMLData = '';
    HTMLData += " <div align='left' class='bgcustomize' style='height:20px;vertical-align:middle;'>";
    HTMLData += " <div style='float:left;width:175px;vertical-align:middle;' class='navigatorpanel'>Item Name</div>";
    HTMLData += " <div style='float:left;width:75px;vertical-align:middle;' class='navigatorpanel'>Quantity </div>";
    HTMLData += " <div style='float:left;width:75px;vertical-align:middle;' class='navigatorpanel'>Price (" + GetCurrencyinRequiredFormate("",true) + ")</div>";
    HTMLData += " <div style='float:right;vertical-align:middle;' ><a href='#' onclick='javascript:ShowCatalogueList();return false;'>";
    HTMLData += " <img src='" + strImagepath + "close1.jpg' title='Close' border='0' width='10px' height='10px' /></a></div>";
    HTMLData += " </div>";
    document.getElementById("div_catalogue_items_header").innerHTML = HTMLData;
    HTMLData = '';
    for (var i = 0; i < Price_Array.length; i++) {
        var color1 = "#DADADA";
        if (i % 2 == 0) {
            color1 = "#EFEFEF";
        }
        var objArr = Price_Array[i];

        HTMLData += " <div align='left' class='onlyEmpty' style='height:20px;padding:2px;background-color:" + color1 + "'>";
        HTMLData += " <div style='float:left;width:175px;'>" + objArr.CatalogueName + "</div>";
        HTMLData += " <div style='float:left;width:75px;'>" + objArr.Quantity + "</div>";
        HTMLData += " <div style='float:left;width:75px;'>" + GetCurrencyinRequiredFormate("",true) + "" + roundNumber(objArr.Price, 2) + "</div>";
        HTMLData += " <div style='float:left;'><a href='#' onclick='RemoveCatalogueName(" + i + ");'>Remove</a></div>";
        HTMLData += " </div>";
    }
    document.getElementById("div_catalogue_items").innerHTML = HTMLData;
    document.getElementById("hrefShowCatalogue").style.display = "block";
}
function CalculateQtyPrice(val, index, Max) {
    var txtObj = document.getElementById("txt_req_qty_" + index + "");
    if (Allow_Integer_Only(txtObj, false)) {
        for (var i = 0; i < 10; i++) {
            if (document.getElementById("spn_FromQty_" + i + "") != null) {
                var FromQty = document.getElementById("spn_FromQty_" + i + "").innerHTML;
                var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
                if ((Number(val) >= Number(FromQty)) && (Number(val) <= Number(ToQty))) {
                    var Cost = document.getElementById("spn_price_" + i + "").innerHTML;
                    var Markup = document.getElementById("spn_markup_" + i + "").innerHTML;
                    var Price = document.getElementById("spn_SellingPrice_" + i + "").innerHTML;

                    var SellPrice = roundNumber(Number(Price) * Number(val), 2);
                    document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("",true) + "" + SellPrice;
                    document.getElementById("spn_QtyCost_" + index + "").innerHTML = Cost;
                    document.getElementById("spn_QtyMarkup_" + index + "").innerHTML = Markup;

                    break;
                }
                else {
                    if (i == Number(Max) - Number(1)) {
                        var Cost = document.getElementById("spn_price_" + i + "").innerHTML;
                        var Markup = document.getElementById("spn_markup_" + i + "").innerHTML;
                        var Price = document.getElementById("spn_SellingPrice_" + i + "").innerHTML;

                        var SellPrice = roundNumber(Number(Price) * Number(val), 2);
                        document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("",true) + "" + SellPrice;
                        document.getElementById("spn_QtyCost_" + index + "").innerHTML = Cost;
                        document.getElementById("spn_QtyMarkup_" + index + "").innerHTML = Markup;
                    }
                    else {
                        document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("",true) + "0.00";
                    }
                }
            }
        }
    }
    else {
        txtObj.value = "";
    }
}
function TakeSellPrice(ddlObj, index) {
    var val = ddlObj.options[ddlObj.selectedIndex].text;

    for (var i = 0; i < 10; i++) {
        var ToQty = document.getElementById("spn_ToQty_" + i + "").innerHTML;
        if (Number(val) == Number(ToQty)) {
            var Cost = document.getElementById("spn_price_" + i + "").innerHTML;
            var Markup = document.getElementById("spn_markup_" + i + "").innerHTML;
            var Price = document.getElementById("spn_SellingPrice_" + i + "").innerHTML;

            var SellPrice = roundNumber(Number(Price), 2);

            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("",true) + "" + SellPrice;
            document.getElementById("spn_QtyCost_" + index + "").innerHTML = Cost;
            document.getElementById("spn_QtyMarkup_" + index + "").innerHTML = Markup;

            break;
        }
        else {
            document.getElementById("spn_QtyPrice_" + index + "").innerHTML = "" + GetCurrencyinRequiredFormate("",true) + "0.00";
        }
    }
}
function Copy_ItemTitle_Price(values) {
    txtCatalogueItemTitleID.value = values;
}
function Copy_Description_Price(values) {
    txtCatalogueDesign.value = values;
}
function Copy_Artwork_Price(values) {
    txtCatalogueArtwork.value = values;
}
function Copy_Color_Price(values) {
    txtCatalogueColour.value = values;
}
function Copy_Size_Price(values) {
    txtCatalogueSize.value = values;
}
function Copy_Material_Price(values) {
    txtCatalogueMaterial.value = values;
}
function Copy_Delivery_Price(values) {
    txtCatalogueDelivery.value = values;
}
function Copy_Finishing_Price(values) {
    txtCatalogueFinishing.value = values;
}
function Copy_Notes_Price(values) {
    txtCatalogueNotes.value = values;
}
function Copy_Instructions_Price(values) {
    txtCatalogueInstructions.value = values;
}
function CopyToItemDescription() {
    txtCatalogueItemTitleID.value = document.getElementById("txtcatalogue_item_title").value;
    txtCatalogueDesign.value = document.getElementById("txtcatalogue_design").value;
    txtCatalogueArtwork.value = document.getElementById("txtcatalogue_art").value;
    txtCatalogueColour.value = document.getElementById("txtcatalogue_color").value;
    txtCatalogueSize.value = document.getElementById("txtcatalogue_size").value;
    txtCatalogueMaterial.value = document.getElementById("txtcatalogue_material").value;
    txtCatalogueDelivery.value = document.getElementById("txtcatalogue_delivery").value;
    txtCatalogueFinishing.value = document.getElementById("txtcatalogue_finishing").value;
    txtCatalogueNotes.value = document.getElementById("txtcatalogue_notes").value;
    txtCatalogueInstructions.value = document.getElementById("txtcatalogue_terms").value;
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
//    if (lblGuillotine.innerHTML.length > 25) {
//        lblGuillotine.innerHTML = lblGuillotine.innerHTML.substring(0, 25) + "...";
//    }
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
function ShowWarehouse() {
    document.getElementById("div_stage_2").style.display = "none";
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
            if (IsWareDirect) {
                document.getElementById(div_StockOnly).style.display = "none";
                document.getElementById("div_stage_4").style.display = "block";
                document.getElementById(div_WarehouseSummary).style.display = "block";
                document.getElementById("lblheader").innerHTML = "Customer Item Description";

                BindWarehouseDesc(); //To bind item desc from settings//
            }
            else {
                WarehousePrevious();
            }
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

var warearray = new Array(); //// WAREHOUSE ARRAY
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
        if (warearray[nos].WareItemID != "0") 
        {
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
    StoreTheEstimateStage1();
    StoreStage1_Data();
    var Data = '';
    for (var i = 0; i < Price_Array.length; i++) {
        var objArr = Price_Array[i];
        Data += "PriceCatalogueID»" + objArr.PriceCatalogueID + "±";
        Data += "Quantity»" + objArr.Quantity + "±";
        Data += "Price»" + roundNumber(objArr.Price, 2) + "±";
        Data += "Cost»" + objArr.Cost + "±";
        Data += "Markup»" + objArr.Markup + "µ";
    }
    if (Data == '') {
        alert(' Please select at least one Catalogue Item ');
        return false;
    }
    else {
        hidCatalogueData.value = Data;
        return true;
    }
}
//// ==================== PRICE CATALOGUE ENDS ===============================


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