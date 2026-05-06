function ShowCategoryWise(ddlID) {
    debugger
    //paper type

    document.getElementById(div_Paper_Type).style.display = "none";

    //ink type
    document.getElementById(div_Ink_Type).style.display = "none";

    //
    //document.getElementById(div_PackedInPrice).style.display = "none";
    //minimumcost for ink
    document.getElementById(div_minimum_ink_cost).style.display = "none";
    //Size Weight Coated
    document.getElementById(div_SizeWeightCoated).style.display = "none";
    //Ink Absorption
    document.getElementById(div_Ink_Absorption).style.display = "none";
    //IMpressions
    document.getElementById(div_Max_Impressions).style.display = "none";
    //div_ProcSellExpo
    document.getElementById(div_ProcSellExpo).style.display = "none";
    //Colour
    document.getElementById(divColour).style.display = "none";
    //Ink Properties
    document.getElementById(div_Ink_Properties).style.display = "none";
    //Basis Weight
    document.getElementById(div_Weight).style.display = "none";
    document.getElementById(div_Caliper).style.display = "none";

    //Coated
    document.getElementById(div_Coated).style.display = "none";

    ddlText = ddlID.options[ddlID.selectedIndex].text.toLowerCase();
    ddlValue = ddlID.options[ddlID.selectedIndex].value.toLowerCase();
    document.getElementById(hid_CategoryID).value = ddlValue;
    //document.getElementById("ddlPaperType").selectedIndex=0;
    document.getElementById(txtPacked).style.display = "block";
    document.getElementById(ddlPacked).style.display = "none";

    if (ddlValue != 0) {
        /*bind_subcategory(ddlValue); //to bind Subcategory to the ddl*/

        //to get the property names
        var str_property = document.getElementById(hid_Properties).value;
        var str_prop1 = str_property.split('µ');
        //1$Weight^Color^^^^^µ2$^^^^Coated^^µ3$^^^^^Exposure^ProcessingChargeµ4$Weight^Color^^^^Exposure^µ44$Weight^Color^^PaperSize^Coated^^ProcessingChargeµ     

        var store_property = '';
        for (var i = 0; i < str_prop1.length; i++) {
            var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^   
            if (ddlValue == str_prop2[0]) {
                store_property = str_prop2[1];
            }
        }
        //to get individual propertyname
        str_prop3 = store_property.split('^'); //Weight^Color^^^^^
        document.getElementById(txtPacked).style.width = "175px";
        if (ddlText == 'paper') {
            document.getElementById(div_Paper_Type).style.display = "block";
            document.getElementById(div_SizeWeightCoated).style.display = "block";
            document.getElementById(div_Weight).style.display = "block";
            document.getElementById(div_Caliper).style.display = "block";

            if (LargeFormat != "") {
                document.getElementById(div_CostPerMtr).style.display = "block";
                document.getElementById(divLargeFormatMaterial).style.display = "block";
            }
            document.getElementById(div_Ink_Absorption).style.display = "none";
            document.getElementById(div_Ink_Properties).style.display = "none";
            document.getElementById(div_Ink_Type).style.display = "none";
            document.getElementById(div_minimum_ink_cost).style.display = "none";
            document.getElementById("spn_permtr").innerHTML = ddlPaperType.options[ddlPaperType.selectedIndex].text;

        }
        else if (ddlText == 'inks' || ddlText == 'ink') {
            document.getElementById(div_Ink_Properties).style.display = "block";
            document.getElementById(div_Ink_Type).style.display = "block";
            document.getElementById(divLargeFormatMaterial).style.display = "none";
            document.getElementById(divColour).style.display = "none";
            document.getElementById(txtPacked).style.width = "100px";
            document.getElementById(ddlPacked).style.display = "block";
            document.getElementById("spn_packedinreq").style.display = "none"
            document.getElementById(div_minimum_ink_cost).style.display = "block";
            document.getElementById(div_CostPerMtr).style.display = "none";
            document.getElementById("spn_permtr").innerHTML = "";
        }
        else {
            document.getElementById(divLargeFormatMaterial).style.display = "none";
            document.getElementById(div_CostPerMtr).style.display = "none";
            document.getElementById("divPackedInPackPrice").style.display = "block";
            document.getElementById("spn_permtr").innerHTML = "";

        }
        for (var k = 0; k < str_prop3.length; k++) {
            if (str_prop3[k] != '') {
                if (str_prop3[k] == "Weight") {
                    if (ddlText != 'plate' || ddlText != 'plates') {
                        document.getElementById(div_Weight).style.display = "block";
                        document.getElementById(div_Caliper).style.display = "block";
                    }
                }
                if (str_prop3[k] == "Coated") {
                    if (ddlText != 'inks' || ddlText != 'ink' || ddlText != 'plate' || ddlText != 'plates') {
                        document.getElementById(div_Coated).style.display = "block";
                    }
                }
                if (str_prop3[k] == "Color") {
                    if (ddlText != 'plate' || ddlText != 'plates') {
                        document.getElementById(divColour).style.display = "block";
                    }
                }
                if (str_prop3[k] == "ProcessingCharge") {
                    document.getElementById(div_ProcSellExpo).style.display = "block";
                }
                if (str_prop3[k] == "Print") {
                    document.getElementById(div_Paper_Type).style.display = "block";
                    document.getElementById(div_CostPerMtr).style.display = "block";
                    document.getElementById(divLargeFormatMaterial).style.display = "block";
                }
                if (str_prop3[k] == "ItemCustomPaperSize") {
                    document.getElementById(div_SizeWeightCoated).style.display = "block";
                    document.getElementById("div_chkCustom").style.display = "block";
                    InventoryShowCustom();
                }
                else if (str_prop3[k] == "PaperSize") {
                    if (ddlText != 'inks' || ddlText != 'ink' || ddlText != 'plate' || ddlText != 'plates') {
                        document.getElementById(div_SizeWeightCoated).style.display = "block";
                        document.getElementById("div_Inventory_Custom_Size").style.display = "none";
                        document.getElementById("div_chkCustom").style.display = "none";
                    }
                }
                else if (str_prop3[k] == "ItemCustomSize") {
                    if (ddlText != 'inks' || ddlText != 'ink' || ddlText != 'plate' || ddlText != 'plates') {
                        document.getElementById(div_SizeWeightCoated).style.display = "block";
                        document.getElementById("div_Inventory_ddl_Size").style.display = "none";
                        document.getElementById("div_Inventory_Custom_Size").style.display = "block";
                        document.getElementById("div_chkCustom").style.display = "none";
                    }
                }
            }
        }
    }
}
//Not Used Now//
function bind_subcategory(ddlValue) {
    var ddl_subcategory = document.getElementById(""); //ddlInvSubCategory.ClientID
    var str_subcat = document.getElementById(hid_SubCategoryName).value;
    if (ddlValue != 0) {
        ddl_subcategory.length = 0;
        var str_sp1 = str_subcat.split('~');
        //1$Plain1^Silk^Graphic^gfdsgbfs^test^Plain~2$Flourescent^Metallic^Process^111~3$Positive^Negative~4$Positive^Negative~                

        var store_subcat = '';
        for (var i = 0; i < str_sp1.length; i++) {
            var str_sp2 = str_sp1[i].split('$');
            //1$Plain1^Silk^Graphic^gfdsgbfs^test^Plain
            if (ddlValue == str_sp2[0]) {
                store_subcat = str_sp2[1];
            }
        }

        var str_sp3 = store_subcat.split('^'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain

        ddl_subcategory.options.add(new Option('--- Select ---', 0, 0));
        for (var k = 0; k < str_sp3.length; k++) {
            if (str_sp3[k] != '') {
                var SubCatID = str_sp3[k].split('±');
                ddl_subcategory.options.add(new Option(SubCatID[1], SubCatID[0], k));
            }
        }
        //ddl_subcategory.value=0;

    }
    else {
        ddl_subcategory.length = 0;
        ddl_subcategory.options.add(new Option(str_subcat, 0, 0));
        document.getElementById(hid_SubCategoryName).value = '';
    }
}

function ShowddlPaperType() {

    var val = ddlPaperTypeID.value;


    if (val.toLowerCase() == "web printing" || val.toLowerCase() == "roll") {
        ddlPaperTypeID.selectedIndex = 1;

        //        if (LargeFormatCalculation.indexOf('square') == -1) {
        //            document.getElementById("spn_permtr").innerHTML = "roll";
        //        }
        //        else {
        //            document.getElementById("spn_permtr").innerHTML = SquareMeater;
        //        }
        document.getElementById("spn_permtr").innerHTML = ddlPaperType.options[ddlPaperType.selectedIndex].text;

        document.getElementById("div_size").style.display = "none";
        document.getElementById("div_WebPrinting").style.display = "block";
        document.getElementById("divPackedInPackPrice").style.display = "none";
        document.getElementById("divSetUpCost").style.display = "none";
        document.getElementById("divMatrix").style.display = "none";


        //      document.getElementById("spn_permtr").style.width="10px";
        //      document.getElementById("spn_permtr").style.border="1px solid";
        //txtPerID.disabled = true;
        //txtPerID.value = "";//sq meter
        //txtPerID.style.width = "85px";
    }
    else {
        //txtPerID.onkeypress=ReturnTrue;  
        document.getElementById("div_size").style.display = "block";
        document.getElementById("div_WebPrinting").style.display = "none";
        document.getElementById("divPackedInPackPrice").style.display = "block";

        document.getElementById("spn_permtr").innerHTML = ddlPaperType.options[ddlPaperType.selectedIndex].text;
        //txtPerID.disabled = false;
        //txtPerID.value = document.getElementById("<%=hid_perqty.ClientID %>").value;
        //txtPerID.style.width = "74px";
    }
    CalculatePackPrice();
}

function ShowddlPaperType_edit() {
    var val = ddlPaperTypeID.value;
    if (val.toLowerCase() == "web printing" || val.toLowerCase() == "roll") {
        ddlPaperTypeID.selectedIndex = 1;
        document.getElementById("spn_permtr").innerHTML = ddlPaperType.options[ddlPaperType.selectedIndex].text;
        document.getElementById("div_size").style.display = "none";
        document.getElementById("div_WebPrinting").style.display = "block";
        document.getElementById("divPackedInPackPrice").style.display = "none";
        document.getElementById("divSetUpCost").style.display = "none";
        document.getElementById("divMatrix").style.display = "none";
    }
    else {
        document.getElementById("div_size").style.display = "block";
        document.getElementById("div_WebPrinting").style.display = "none";
        document.getElementById("divPackedInPackPrice").style.display = "block";
        document.getElementById("spn_permtr").innerHTML = ddlPaperType.options[ddlPaperType.selectedIndex].text;
    }

    CalculatePackPrice_edit();
}

//by smitha
function ShowddlInkType() {
    var val = ddlInkTypeID.value;
    if (val == 'Y') {
        //ddlInkTypeID.selectedIndex = 1;
        document.getElementById("div_InkType").style.display = "block";
        document.getElementById("div_coated").style.display = "none";
        document.getElementById("div_inkproperties").style.display = "block";
        document.getElementById("divPackedInPackPrice").style.display = "block";
        document.getElementById("div_cost").style.display = "block";
        document.getElementById("divMinimumCost").style.display = "block";
        document.getElementById("div_colour").style.display = "block";
        document.getElementById("divSetUpCost").style.display = "none";
        document.getElementById("divMatrix").style.display = "none";
        document.getElementById("divPackPrice").style.display = "block";
        document.getElementById("divPackedIn").style.display = "block";
        document.getElementById("div_Yield").style.display = "block";


    }
    else {
        ddlInkTypeID.selectedIndex = 1;
        document.getElementById("div_InkType").style.display = "block";
        document.getElementById("div_inkproperties").style.display = "none";
        document.getElementById("divPackedInPackPrice").style.display = "none";
        document.getElementById("div_cost").style.display = "none";
        document.getElementById("divSetUpCost").style.display = "block";
        document.getElementById("divMatrix").style.display = "block";
        document.getElementById("div_colour").style.display = "none";
        document.getElementById("divMinimumCost").style.display = "block";
        document.getElementById("div_Yield").style.display = "none";
        document.getElementById("div_coated").style.display = "none";
        document.getElementById("divPackPrice").style.display = "none";
        document.getElementById("divPackedIn").style.display = "none";
    }
    var ddlid = document.getElementById("ctl00_ContentPlaceHolder1_inventoryadd_ddlInvCategory");
    ShowCategoryWise(ddlid);

}
//by smitha

function ValidateCostPer() {
    document.getElementById("spn_CostPer").style.display = "none";
    document.getElementById("spn_cost").style.display = "none";
    if (trim12(txtCostID.value) == "" || trim12(txtPerID.value) == "") {
        document.getElementById("spn_CostPer").style.display = "block";
        document.getElementById("spn_CostPer").innerHTML = "Please enter Cost & Quantity";
        //CheckFinal=true;
    }
    else if (trim12(txtCostID.value) != "" || trim12(txtPerID.value) != "") {
        if (checkDecimals('spn_cost', txtCostID.id, txtCostID.value) && checkDecimals('spn_cost', txtPerID.id, txtPerID.value)) {
            document.getElementById("spn_cost").innerHTML = "Please enter numeric value";
            //CheckFinal=true;
        }
    }
    else {
        //CheckFinal=false;
    }

}

function populatePackedIn(val) {
       
        if (val.trim().toLowerCase() == "lbs")
        {
            lblPackedIn.innerHTML = "Sq.In/" + val;
        }
        else
        {
            lblPackedIn.innerHTML = "Sq.CM/" + val;
        }
    
    hdnPackedIn.value = lblPackedIn.innerHTML;
}

function CalSellingPrice() {
    if (CheckDecimalPlus(txtProcessChargeID.value, 'spn_processchargereq', 'spn_processcharge', 'yes')) {
        var sellingprice = eval(txtCostID.value / txtPerID.value);
        var processcharge = eval(txtProcessChargeID.value);
        txtSellingPriceID.value = eval(sellingprice + processcharge);
        hid_sellingprice.value = txtSellingPriceID.value;
    }
}

function ValidateHeightWidth() {
    document.getElementById("spn_heightwidthcheck").style.display = "none";
    document.getElementById("spn_height").style.display = "none";
    if (trim12(txtPaperHeightID.value) == "" || trim12(txtPaperWidthID.value) == "") {
        document.getElementById("spn_heightwidthcheck").style.display = "block";
        //CheckFinal=true;
    }
    else if (trim12(txtPaperHeightID.value) != "" || trim12(txtPaperWidthID.value) != "") {
        if (IsIntegerParameter(txtPaperHeightID.value, 'spn_height') && IsIntegerParameter(txtPaperWidthID.value, 'spn_height')) {
            document.getElementById("spn_height").innerHTML = "Please enter numeric value";
            //CheckFinal=true;
        }
    }
    else {
        //CheckFinal=false;
    }
}
function InventoryShowCustom() {
    document.getElementById("div_Inventory_ddl_Size").style.display = "none";
    document.getElementById("div_Inventory_Custom_Size").style.display = "none";
    //var chCheck = document.getElementById(chidd).checked;
    if (chidd.checked == true) {
        ddlPaperSize.options[ddlPaperSize.selectedIndex].value = 0;
        document.getElementById("div_Inventory_Custom_Size").style.display = "block";
        document.getElementById("div_Inventory_ddl_Size").style.display = "none";
    }
    else {
        ddlPaperSize.options[ddlPaperSize.selectedIndex].value = ddlPaperSize.options[ddlPaperSize.selectedIndex].value;
        document.getElementById("div_Inventory_ddl_Size").style.display = "block";
        document.getElementById("div_Inventory_Custom_Size").style.display = "none";
    }
}
function spnchkbox_CustomClick() {
    if (customclick.checked) {
        customclick.checked = false;
        InventoryShowCustom();
    }
    else {
        customclick.checked = true;
        InventoryShowCustom();
    }
}

var CheckFinal = false;
//To validate the page before saving//
function CallValidation() {
    debugger;
    TakeALookNew();
    CheckFinal = false;
    // document.getElementById(hid_SubCategoryID).value = document.getElementById("").value;//ddlInvSubCategory.ClientID
    var txtInvNam = trim12(txtInvNameID.value);
    if (txtInvNam == '') {
        document.getElementById("spn_txtInvName").style.display = "block";
        document.getElementById("spn_InvNameCheck").style.display = "none";
        CheckFinal = true;
        return false;
    }
    var txtInvCode = trim12(txtInvCodeID.value);
    if (txtInvCode == '') {
        document.getElementById("spn_txtInvCode").style.display = "block";
        CheckFinal = true;
        return false;
    }
    var ddlInvCategory = ddlInvCategoryID.value;
    if (ddlInvCategory == '0') {
        document.getElementById("spn_ddlInvCategory").style.display = "block";
        CheckFinal = true;
        return false;
    }
    //        var ddlInvSubCategory=ddlInvSubCategoryID.value;
    //        if(ddlInvSubCategory=='0')
    //        {
    //          document.getElementById("spn_ddlInvSubCategory").style.display="block";
    //          CheckFinal=true;
    //        }

    //        var txtInvLocation=trim12(txtInvLocationID.value);
    //        if(txtInvLocation=='')
    //        {
    //          document.getElementById("spn_txtInvLocation").style.display="block";
    //          CheckFinal=true;
    //        }
    var txtInStock = trim12(txtInStockID.value);

    if (action != "edit") {
        if (txtInStock == '') {
            document.getElementById("spn_txtInStock").style.display = "block";
            return false;
        }

        else {
            if (ddlText == 'inks' || ddlText == 'ink' || ddlText == 'Inks' || ddlText == 'Ink') {
                if (!CheckDecimalPlus(txtInStock, 'spn_txtInStock_number', 'spn_txtInStock_number', 'yes')) {
                    CheckFinal = false;
                    //                if (IsIntegerParameter(txtInStock, 'spn_txtInStock_number') == false) {
                    //                CheckFinal = true;
                }
            }
            else {
                if (IsIntegerParameter(txtInStock, 'spn_txtInStock_number') == false) {
                    CheckFinal = true;
                    return false;
                }
            }
        }
    }
    var txtReorderLevel = trim12(txtReorderLevelID.value);
    if (txtReorderLevel == '') {
        document.getElementById("spnReorderLevel_req").style.display = "block";
        CheckFinal = true;
        return false;
    }
    var txtReorderQty = trim12(txtReorderQtyID.value);
    if (txtReorderQty == '') {
        document.getElementById("spn_txtReorderQty_value").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (ddlText == 'inks' || ddlText == 'ink' || ddlText == 'Inks' || ddlText == 'Ink') {
            if (!CheckDecimalPlus(txtReorderLevel, 'spnReorderLevel_int', 'spnReorderLevel_int', 'yes')) {
                document.getElementById("spnReorderLevel_req").style.display = "none";
                CheckFinal = false;
                //                if (IsIntegerParameter(txtInStock, 'spn_txtInStock_number') == false) {
                //                CheckFinal = true;
            }
        }
        else {
            if (IsIntegerParameter(txtReorderLevel, 'spnReorderLevel_int') == false) {
                document.getElementById("spnReorderLevel_req").style.display = "none";
                CheckFinal = true;
                return false;
            }
        }
    }

    //        var ddlSupplier=ddlSupplierID.value;
    //        if(ddlSupplier=='0')
    //        {
    //          document.getElementById("spn_ddlSupplier").style.display="block";
    //          CheckFinal=true;
    //        }

    //right side
    //Cost and Quantity 

    var txtCost = trim12(txtCostID.value);
    var txtPer = trim12(txtPerID.value);
    if (txtCost == "" || txtPer == "") {
        document.getElementById("spn_CostPer").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else if (txtPer == 0 || txtCost == 0) {
        var val = ddlInkTypeID.value;
        if (!ddlInkTypeID.value == 'M') {
            document.getElementById("spn_CostPerZero").style.display = "block";
            CheckFinal = true;
            return false;
        }
    }
    else {

        if (!CheckDecimalPlus(txtCost, 'spn_cost', 'spn_cost', 'yes')
            || !CheckDecimalPlus(txtPer, 'spn_cost', 'spn_cost', 'yes')) {
            CheckFinal = false;
        }
    }
    if (document.getElementById("spn_txtReorderQty_number").style.display == "block") {
        return false;
    }

    var txtPackedIn = trim12(txtPackedInID.value);
    if (txtPackedIn == '') {
        document.getElementById("spn_packedinreq").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (ddlText == 'inks' || ddlText == 'ink' || ddlText == 'Inks' || ddlText == 'Ink') {
            if (!CheckDecimalPlus(txtPackedIn, 'spn_packedin', 'spn_packedin', 'yes')) {
                document.getElementById("spn_packedinreq").style.display = "none";
                CheckFinal = false;
                //                if (IsIntegerParameter(txtInStock, 'spn_txtInStock_number') == false) {
                //                CheckFinal = true;
            }
        }
        else {
            if (IsIntegerParameter(txtPackedIn, 'spn_packedin') == false) {
                document.getElementById("spn_packedinreq").style.display = "none";
                CheckFinal = true;
                return false;
            }
        }
    }
    //        var txtPackedPrice=txtPackedPriceID.value;
    //        if(txtPackedPrice=='')
    //        {
    //          document.getElementById("spn_packedprice").style.display="block";
    //          CheckFinal=true;
    //        }
    //        else
    //        {
    //            if(checkDecimals('spn_packedprice',txtPackedPriceID,txtPackedPrice)==false)
    //            {
    //              CheckFinal=true;
    //            }
    //        }
    //Paper Type >Sheet -- height and width
    var txtPaperHeight = trim12(txtPaperHeightID.value);
    var txtPaperWidth = trim12(txtPaperWidthID.value);
    var val = ddlPaperTypeID.value;
    if (val.toLowerCase() == "sheet") {

        //        if (ddlText == 'paper' || ddlText == 'plates' || ddlText == 'ink' || ddlText == 'inks') {
        if (ddlText == 'paper') {
            if (txtPaperHeight == "" || txtPaperWidth == "") {
                document.getElementById("spn_height").style.display = "none";
                document.getElementById("spn_heightwidthcheck").style.display = "block";
                CheckFinal = true;
                return false;
            }
            else if (txtPaperHeightID.value == 0 || txtPaperWidthID.value == 0) {
                document.getElementById("spn_height").style.display = "none";
                document.getElementById("spn_heightwidthcheck").style.display = "none";
                document.getElementById("spn_heightwidthcheck_2").style.display = "block";
                CheckFinal = true;
                return false;

                //        alert(document.getElementById("spn_height").style.display);
                //        alert(document.getElementById("spn_heightwidthcheck").style.display);
                //        alert(document.getElementById("spn_heightwidthcheck_2").style.display);
            }

            else {

                document.getElementById("spn_heightwidthcheck").style.display = "none";
                document.getElementById("spn_heightwidthcheck_2").style.display = "none";
                if (!CheckDecimalPlus(txtPaperHeightID.value, 'spn_height', 'spn_height', 'yes')
               || !CheckDecimalPlus(txtPaperWidthID.value, 'spn_height', 'spn_height', 'yes')) {
                    CheckFinal = false;
                }
            }
        }
    }

    var txtWebWidth = trim12(txtWebWidthID.value);
    if (txtWebWidth == '') {

        document.getElementById("spn_webwidth").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtWebWidth, 'spn_webwidth', 'spn_webwidth', 'yes')) {
            CheckFinal = false;
        }
    }

    var txtWebLength = trim12(txtWebLengthID.value);
    if (txtWebLength == '') {

        document.getElementById("spn_length").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtWebLength, 'spn_length', 'spn_length', 'yes')) {
            CheckFinal = false;
        }
    }

    var txtBasisWeight = trim12(txtBasisWeightID.value);
    if (txtBasisWeight == '') {
        document.getElementById("spn_basisweightreq").style.display = "block";
        document.getElementById("spn_basisweight_2").style.display = "none";
        CheckFinal = true;
        return false;
    }
    else if (txtBasisWeight == 0) {
        if (ddlText == 'paper') {
            document.getElementById("spn_basisweightreq").style.display = "none";
            document.getElementById("spn_basisweight_2").style.display = "block";
            CheckFinal = true;
            return false;
        }
    }
    else {
        document.getElementById("spn_basisweightreq").style.display = "none";
        document.getElementById("spn_basisweight_2").style.display = "none";
        if (!CheckDecimalPlus(txtBasisWeight, 'spn_basisweight', 'spn_basisweight', 'yes')) {
            CheckFinal = false;
        }
    }

    var txtInkAbsorption = trim12(txtInkAbsorptionID.value);
    if (txtInkAbsorption == '') {

        document.getElementById("spn_inkabsorptionreq").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtInkAbsorption, 'spn_inkabsorption', 'spn_inkabsorption', 'yes')) {
            CheckFinal = false;
        }
    }
    if (txtReasonadjustment.value == "" || txtReasonadjustment.value == null) {
        document.getElementById("divReason").style.display = "block";
        return false;
    }
    else {
        document.getElementById("divReason").style.display = "none";

    }

    //by smitha
    var txtYield = trim12(txtYieldID.value);
    if (txtYield == '') {

        document.getElementById("spn_yieldreq").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtYield, 'spn_yield', 'spn_yield', 'yes')) {
            CheckFinal = false;
        }
    }


    var txtminimum = trim12(txtminimumID.value);
    if (txtminimum == '') {

        document.getElementById("Spn_MinimumCostreq").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtminimum, 'Spn_MinimumCost', 'Spn_MinimumCost', 'yes')) {
            CheckFinal = false;
        }
    }



    var txtSetupCost = trim12(txtSetupCostID.value);
    if (txtSetupCost == '') {

        document.getElementById("Spn_Setupcostreq").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (!CheckDecimalPlus(txtSetupCost, 'Spn_Setupcost', 'Spn_Setupcost', 'yes')) {
            CheckFinal = false;
        }
    }


    //for matrix ink to check print sheets and per sheets for intiger
    //by smitha

    var txtSheetsTo1 = trim12(txtSheetsTo1ID.value);
    if (txtSheetsTo1 == '') {

        document.getElementById("spn_InkValue_1").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtSheetsTo1, 'spn_InkValue_1') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtSheetsTo2 = trim12(txtSheetsTo2ID.value);
    if (txtSheetsTo2 == '') {

        document.getElementById("spn_InkValue_2").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtSheetsTo2, 'spn_InkValue_2') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtSheetsTo3 = trim12(txtSheetsTo3ID.value);
    if (txtSheetsTo3 == '') {

        document.getElementById("spn_InkValue_3").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtSheetsTo3, 'spn_InkValue_3') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtSheetsTo4 = trim12(txtSheetsTo4ID.value);
    if (txtSheetsTo4 == '') {

        document.getElementById("spn_InkValue_4").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtSheetsTo4, 'spn_InkValue_4') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkCostPer1 = trim12(txtInkCostPer1ID.value);
    if (txtInkCostPer1 == '') {

        document.getElementById("spn_InkValue_1").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtInkCostPer1, 'spn_InkValue_1') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkCostPer2 = trim12(txtInkCostPer2ID.value);
    if (txtInkCostPer2 == '') {

        document.getElementById("spn_InkValue_2").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtInkCostPer2, 'spn_InkValue_2') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkCostPer3 = trim12(txtInkCostPer3ID.value);
    if (txtInkCostPer3 == '') {

        document.getElementById("spn_InkValue_3").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtInkCostPer3, 'spn_InkValue_3') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkCostPer4 = trim12(txtInkCostPer4ID.value);
    if (txtInkCostPer4 == '') {

        document.getElementById("spn_InkValue_4").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtInkCostPer4, 'spn_InkValue_4') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkCostPer5 = trim12(txtInkCostPer5ID.value);
    if (txtInkCostPer5 == '') {

        document.getElementById("spn_InkValue_5").style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        if (IsIntegerParameter(txtInkCostPer5, 'spn_InkValue_5') == false) {
            CheckFinal = true;
            return false;
        }
    }

    var txtInkChargableCost1 = trim12(txtInkChargableCost1ID.value);
    if (txtInkChargableCost1 == '') {

        document.getElementById("spn_InkValue_1").style.display = "block";
        CheckFinal = true;
        return false;
    }

    var txtInkChargableCost2 = trim12(txtInkChargableCost2ID.value);
    if (txtInkChargableCost2 == '') {

        document.getElementById("spn_InkValue_2").style.display = "block";
        CheckFinal = true;
        return false;
    }

    var txtInkChargableCost3 = trim12(txtInkChargableCost3ID.value);
    if (txtInkChargableCost3 == '') {

        document.getElementById("spn_InkValue_3").style.display = "block";
        CheckFinal = true;
        return false;
    }

    var txtInkChargableCost4 = trim12(txtInkChargableCost4ID.value);
    if (txtInkChargableCost4 == '') {

        document.getElementById("spn_InkValue_4").style.display = "block";
        CheckFinal = true;
        return false;
    }

    var txtInkChargableCost5 = trim12(txtInkChargableCost5ID.value);
    if (txtInkChargableCost5 == '') {

        document.getElementById("spn_InkValue_5").style.display = "block";
        CheckFinal = true;
        return false;
    }


    //check for ddlPaperSize
    var ddlIndex = ddlPaperSizeID.selectedIndex;
    var CheckError = false;
    if (ddlText == 'paper') {
        if (ddlPaperTypeID.value.toLowerCase() != "web printing") {
            if (!chkCustomID.checked) {
                if (ddlIndex == 0) {

                    document.getElementById("spn_papersize").style.display = "block";
                    CheckError = true;
                }
                else {
                    document.getElementById("spn_papersize").style.display = "none";
                }
            }
        }
    }



    for (var k = 0; k < str_prop3.length; k++) {
        if (str_prop3[k] != '') {
            if (str_prop3[k] == "ItemCustomPaperSize" || str_prop3[k] == "PaperSize") {
                if (ddlPaperTypeID.value.toLowerCase() != "web printing") {
                    if (!chkCustomID.checked) {
                        if (ddlIndex == 0) {

                            document.getElementById("spn_papersize").style.display = "block";
                            CheckError = true;
                        }
                        else {
                            document.getElementById("spn_papersize").style.display = "none";
                        }
                    }
                }
            }
        }
    }



    //return false;
    if (CheckError) {
        return false;
    }
    //end of check for ddlPaperSize
    if (tabSelection == "True") {
        if (validateMultipleEmailsCommaSeparated(txtemail.value, 'spn_To') == true)
            CheckFinal = false;

        else
            CheckFinal = true;

    }

    if (CheckFinal) {
        return false;
    }

    else {
        if (CheckDuplicate) {
            //yes Its duplicate
            return false;
        }
        //no duplicate        
        return true;
    }




    //return false;       
}
////***************** End of Validation on btnSave Onclick *************///

function CalculatePackPrice() {
    debugger;
    var PaperType = ddlPaperType.options[ddlPaperType.selectedIndex].value;
    decallowed = 2;
    var Denominator = 0;

    //by Pradeep
    if (PaperMeasure == 'mm') {
        //meter
        Denominator = 1000;
    }
    else {
        //inches
        Denominator = 12;
    }
    if (PaperType.toLowerCase() == "web printing" || PaperType.toLowerCase() == "roll") {

        var width = RemoveDollorAndComma(txtWebWidthID.value) / Denominator;
        var length = RemoveDollorAndComma(txtWebLengthID.value);
        var cost = RemoveDollorAndComma(txtCostID.value);
        var Per = RemoveDollorAndComma(txtPerID.value);
        var Costcalc = 0;
        var CostSqMtrcalc = 0;
        //Linear
        Costcalc = eval((cost / Per) / length);
        //Square
        var upperVar = eval(cost / Per);
        var lowerVar = eval(width * length);
        CostSqMtrcalc = eval(upperVar / lowerVar);

        if (isNaN(CostSqMtrcalc) || !isFinite(CostSqMtrcalc)) {
            lblCostPerReel.innerHTML = "0";
        }
        else {
            lblCostPerReel.innerHTML = CostSqMtrcalc;
        }
        if (isNaN(Costcalc) || !isFinite(Costcalc)) {
            lblCostperMtrvalue.innerHTML = "0";
        }
        else {
            lblCostperMtrvalue.innerHTML = Costcalc;
        }

        var CostPerSqMtr = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostPerReel.innerHTML, 4, '', false, false, true); //Square
        var CostPerMtr = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostperMtrvalue.innerHTML, 4, '', false, false, true); //Linear
        hid_costperMtr.value = lblCostperMtrvalue.innerHTML;
        hid_costperreel.value = lblCostPerReel.innerHTML;
        lblCostPerReel.innerHTML = CostPerSqMtr;
        lblCostperMtrvalue.innerHTML = CostPerMtr;

    }
    else if (PaperType.toLowerCase().trim() == "sheet") {

        var cost = txtCostID.value;
        var Per = txtPerID.value;
        var Costcalc = 0;
        var CostSqMtrcalc = 0;

        //Linear
        var LinearUpper = eval(cost / Per);
        var LinearLower = eval(RemoveDollorAndComma(txtPaperHeightID.value) / Denominator);
        Costcalc = eval(LinearUpper / LinearLower);

        //Square
        var SquareUpper = eval(cost / Per);
        var SqrSubUpper = eval(RemoveDollorAndComma(txtPaperWidthID.value) / Denominator);
        var SqrSubLower = eval(RemoveDollorAndComma(txtPaperHeightID.value) / Denominator);
        var SqrSubEval = eval(SqrSubUpper * SqrSubLower);

        CostSqMtrcalc = eval(SquareUpper / SqrSubEval);

        if (isNaN(CostSqMtrcalc) || !isFinite(CostSqMtrcalc)) {
            lblCostPerReel.innerHTML = "0";
        }
        else {
            lblCostPerReel.innerHTML = CostSqMtrcalc;
        }

        if (isNaN(Costcalc) || !isFinite(Costcalc)) {
            lblCostperMtrvalue.innerHTML = "0";
        }
        else {
            lblCostperMtrvalue.innerHTML = Costcalc;
        }

        hid_costperMtr.value = lblCostperMtrvalue.innerHTML;
        hid_costperreel.value = lblCostPerReel.innerHTML;

        lblCostPerReel.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostPerReel.innerHTML, 4, '', false, false, true); //square Type
        lblCostperMtrvalue.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostperMtrvalue.innerHTML, 4, '', false, false, true); // Linear Type


        txtPackedPriceID.value = eval((txtCostID.value * txtPackedInID.value) / txtPerID.value);
        if (isNaN(txtPackedPriceID.value) || !isFinite(txtPackedPriceID.value)) {
            txtPackedPriceID.value = "0";
        }


        var txtPackedPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtPackedPriceID.value, 0, '', false, false, true);
        txtPackedPriceID.value = txtPackedPrice;

        hid_packprice.value = txtPackedPriceID.value;
    }
    // end
}


function CalculatePackPrice_edit() {
    var PaperType = ddlPaperType.options[ddlPaperType.selectedIndex].value;
    decallowed = 2;
    var Denominator = 0;

    //by Pradeep
    if (PaperMeasure == 'mm') {
        //meter
        Denominator = 1000;
    }
    else {
        //inches
        Denominator = 12;
    }
    if (PaperType.toLowerCase() == "web printing" || PaperType.toLowerCase() == "roll") {

        var width = RemoveDollorAndComma(txtWebWidthID.value) / Denominator;
        var length = RemoveDollorAndComma(txtWebLengthID.value);
        var cost = RemoveDollorAndComma(txtCostID.value);
        var Per = RemoveDollorAndComma(txtPerID.value);
        var Costcalc = 0;
        var CostSqMtrcalc = 0;
        //Linear
        Costcalc = eval((cost / Per) / length);
        //Square
        var upperVar = eval(cost / Per);
        var lowerVar = eval(width * length);
        CostSqMtrcalc = eval(upperVar / lowerVar);

        if (isNaN(CostSqMtrcalc) || !isFinite(CostSqMtrcalc)) {
            lblCostPerReel.innerHTML = "0";
        }
        else {
            lblCostPerReel.innerHTML = CostSqMtrcalc;
        }
        if (isNaN(Costcalc) || !isFinite(Costcalc)) {
            lblCostperMtrvalue.innerHTML = "0";
        }
        else {
            lblCostperMtrvalue.innerHTML = Costcalc;
        }

        var CostPerSqMtr = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostPerReel.innerHTML, 4, '', false, false, true); //Square
        var CostPerMtr = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostperMtrvalue.innerHTML, 4, '', false, false, true); //Linear
        hid_costperMtr.value = lblCostperMtrvalue.innerHTML;
        hid_costperreel.value = lblCostPerReel.innerHTML;
        lblCostPerReel.innerHTML = CostPerSqMtr;
        lblCostperMtrvalue.innerHTML = CostPerMtr;

    }
    else if (PaperType.toLowerCase().trim() == "sheet") {

        var cost = txtCostID.value;
        var Per = txtPerID.value;
        var Costcalc = 0;
        var CostSqMtrcalc = 0;

        //Linear
        var LinearUpper = eval(cost / Per);
        var LinearLower = eval(RemoveDollorAndComma(txtPaperHeightID.value) / Denominator);
        Costcalc = eval(LinearUpper / LinearLower);

        //Square
        var SquareUpper = eval(cost / Per);
        var SqrSubUpper = eval(RemoveDollorAndComma(txtPaperWidthID.value) / Denominator);
        var SqrSubLower = eval(RemoveDollorAndComma(txtPaperHeightID.value) / Denominator);
        var SqrSubEval = eval(SqrSubUpper * SqrSubLower);

        CostSqMtrcalc = eval(SquareUpper / SqrSubEval);

        if (isNaN(CostSqMtrcalc) || !isFinite(CostSqMtrcalc)) {
            lblCostPerReel.innerHTML = "0";
        }
        else {
            lblCostPerReel.innerHTML = CostSqMtrcalc;
        }

        if (isNaN(Costcalc) || !isFinite(Costcalc)) {
            lblCostperMtrvalue.innerHTML = "0";
        }
        else {
            lblCostperMtrvalue.innerHTML = Costcalc;
        }

        hid_costperMtr.value = lblCostperMtrvalue.innerHTML;
        hid_costperreel.value = lblCostPerReel.innerHTML;

        lblCostPerReel.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostPerReel.innerHTML, 4, '', false, false, true); //square Type
        lblCostperMtrvalue.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, lblCostperMtrvalue.innerHTML, 4, '', false, false, true); // Linear Type
    }

}