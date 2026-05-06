
var Customer_offsetTop = 0; 	// Offset - Customer placement - You probably have to modify this value if you're not using a strict doctype
var Customer_offsetLeft = 0; // Offset - Customer placement - You probably have to modify this value if you're not using a strict doctype
var CustomerDiv = false;
var ClickEvent = false;
var oldDiv = false;
var textboxid;  //added by rakshith
var titletextboxid; // aded by rakshith
var hdnlocation;
var otherkititemid;
function initCustomer(ID, Width, type) {
    try {

        CustomerDiv.style.display = 'none';
    }
    catch (err) {
    }
    var randomnumber = Math.floor(Math.random() * 10000000)
    CustomerDiv = document.createElement('DIV');
    CustomerDiv.id = randomnumber + 'Div' + ID;
    oldDiv = CustomerDiv.id;
    CustomerDiv.style.position = 'absolute';
    CustomerDiv.style.zIndex = 100000000;
    CustomerDiv.style.backgroundcolor = 'Gray';
    CustomerDiv.style.width = '200px';
    CustomerDiv.style.padding = '0px';

    if (Pgtype == "estimate") {
        try {
            if (IsOld != null) {
                CustomerDiv.style.display = 'block';
            }
            else {
                CustomerDiv.style.display = 'none';
            }
        }
        catch (e) {
            CustomerDiv.style.display = 'none';
        }
    }
    else {
        CustomerDiv.style.display = 'none';
    }

    document.body.appendChild(CustomerDiv);
}

window.onload = function () {
    document.onclick = function (e) {
        var evt = (e) ? e : event;

        var theElem = (evt.srcElement) ? evt.srcElement : evt.target;
        while (theElem != null) {
            try {

                if ((theElem.id == CustomerDiv.id || theElem.id == ClickEvent) && document.getElementById(CustomerDiv.id).style.display == 'none') {
                    document.getElementById(CustomerDiv.id).style.display = 'block';
                    return true;
                }
            }
            catch (err) {
            }
            theElem = theElem.offsetParent;
        }

        try {
            document.getElementById(CustomerDiv.id).style.display = 'none';
        }
        catch (err) {
        }
    }

    document.onkeyup = function (e) {

        var evt = (e) ? e : event;

        var theElem = (evt.srcElement) ? evt.srcElement : evt.target;
        while (theElem != null) {
            try {


                if ((theElem.id == CustomerDiv.id || theElem.id == ClickEvent) && document.getElementById(CustomerDiv.id).style.display == 'none') {
                    document.getElementById(CustomerDiv.id).style.display = 'block';
                    return true;
                }
            }
            catch (err) {
            }

            theElem = theElem.offsetParent;
        }
        try {

            //for keyboard
            // alert(evt.keyCode);
            if (evt != undefined) {
                evt = evt || window.event;

                if (evt.keyCode != 38 && evt.keyCode != 40)
                    document.getElementById(CustomerDiv.id).style.display = 'none';
            }
            else {
                document.getElementById(CustomerDiv.id).style.display = 'none';
            }
            //for keyboard

        }
        catch (err) {
        }
    }
}
function getTopPosCustomer(inputObj) {

    var returnValue = inputObj.offsetTop + inputObj.offsetHeight;
    while ((inputObj = inputObj.offsetParent) != null) returnValue += inputObj.offsetTop;
    return returnValue + Customer_offsetTop;
}
function getleftPosCustomer(inputObj) {
    var returnValue = inputObj.offsetLeft;
    while ((inputObj = inputObj.offsetParent) != null) returnValue += inputObj.offsetLeft;
    return returnValue + Customer_offsetLeft;
}
function positionCustomer(inputObj) {
    CustomerDiv.style.left = getleftPosCustomer(inputObj) + 'px';
    CustomerDiv.style.top = getTopPosCustomer(inputObj) + 'px';
}
function writeCustomerContent(CompanyID, CompanyType, SearchParameter, isDisplaySupplier) {
    debugger;
    if (isDisplaySupplier == undefined) {
        isDisplaySupplier = "no";
    }
    if (CompanyType == "customer") {
        //added by sharan
        if (Pgtype != "Report" && Pgtype != "productcatalogue") {
            AutoFill.GetCustomer(CompanyID, SearchParameter, isDisplaySupplier, onResponse, onTimeout, onError);
        }
        else {
            AutoFill.GetCustomer_Report(CompanyID, SearchParameter, isDisplaySupplier, onResponse, onTimeout, onError);
        }
        //end
    }
    else if (CompanyType == "supplier") {

        AutoFill.GetSupplier(CompanyID, SearchParameter, onResponse, onTimeout, onError);

    }
    else if (CompanyType == "all") {
        AutoFill.GetClientAll(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }
        //added by rakshith
    else if (CompanyType == "Warehouse") {
        AutoFill.GetWarehouseLocation(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }
    else if (CompanyType == "Products") {
        AutoFill.GetItemCodeTitle(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }
    else if (CompanyType == "JobList") {
        AutoFill.ProductJobList_Select(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }
        //added by kruti for estimate/job/invoice title
    else if (CompanyType == "estimate" || CompanyType == "job" || CompanyType == "invoice") {
        AutoFill.GetEstimateTitle(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }
    else if (CompanyType == "supplierproduct") {
        AutoFill.GetSupplierProductDetails(CompanyID, SearchParameter, onResponse, onTimeout, onError);
    }

}
function onTimeout(request, context) {
    CustomerDiv.style.visibility = 'hidden';
}
function onError(objError) {
    CustomerDiv.style.visibility = 'hidden';

}

function writeCustomerContentAnyParam(CompanyID, CompanyType, SearchParameter, UserDefinedType, UserDefinedText, isDisplaySupplier) {
    if (CompanyType = "CustomField") {
        AutoFill.GetCustomFieldAutoFill(CompanyID, SearchParameter, UserDefinedType, UserDefinedText, onResponse, onTimeout, onError);
    }
}
//for web service

function onResponse(response) {
    CustomerDiv.innerHTML = '';
    CustomerDiv.innerHTML = response;
}

//for web service

//for keyboard
this.pointer = 0;
//for keyboard

function displayClient(buttonObj, companytype, CompanyID, Width, e, isDisplaySupplier) {
    
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    setTimeout(function () { writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier); }, 1500);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                    //}
                    //                    else {
                    //                        try {
                    //                            CustomerDiv.style.visibility = 'hidden';
                    //                        }
                    //                        catch (err) {
                    //                        }
                    //                    }
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        setTimeout(function () { writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier); }, 10000);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
        //        }
        //        else {
        //            try {
        //                CustomerDiv.style.visibility = 'hidden';
        //            }
        //            catch (err) {
        //            }
        //        }
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}


// to get location autofill
function GetLocationDetails(buttonObj, hdnlocationid, companytype, CompanyID, Width, e, isDisplaySupplier) {
    debugger;
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;

    textboxid = document.getElementById(buttonObj.id);  //added by rakshith
    hdnlocation = document.getElementById(hdnlocationid);
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                    //}
                    //                    else {
                    //                        try {
                    //                            CustomerDiv.style.visibility = 'hidden';
                    //                        }
                    //                        catch (err) {
                    //                        }
                    //                    }
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
        //        }
        //        else {
        //            try {
        //                CustomerDiv.style.visibility = 'hidden';
        //            }
        //            catch (err) {
        //            }
        //        }
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}




function displayProductTitle(buttonObj, hdnkititemid, buttonobjTitle, companytype, CompanyID, Width, e, isDisplaySupplier) {

    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    textboxid = document.getElementById(buttonObj.id);  //added by rakshith
    titletextboxid = document.getElementById(buttonobjTitle); // added by rakshith
    this.textbox = document.getElementById(buttonObj.id);
    otherkititemid = document.getElementById(hdnkititemid);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName("li");

    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                    //}
                    //                    else {
                    //                        try {
                    //                            CustomerDiv.style.visibility = 'hidden';
                    //                        }
                    //                        catch (err) {
                    //                        }
                    //                    }
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
        //        }
        //        else {
        //            try {
        //                CustomerDiv.style.visibility = 'hidden';
        //            }
        //            catch (err) {
        //            }
        //        }
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}

// to get Estimate title autofill
function GetEstimateTitleDetails(buttonObj, companytype, CompanyID, Width, e, isDisplaySupplier) {

    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;

    textboxid = document.getElementById(buttonObj.id);  //added by kruti
    //hdnlocation = document.getElementById(hdnlocationid);
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                    //}
                    //                    else {
                    //                        try {
                    //                            CustomerDiv.style.visibility = 'hidden';
                    //                        }
                    //                        catch (err) {
                    //                        }
                    //                    }
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
        //        }
        //        else {
        //            try {
        //                CustomerDiv.style.visibility = 'hidden';
        //            }
        //            catch (err) {
        //            }
        //        }
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}

// To get Product Job List for release  by Rakshith
function GetProductJobList(buttonObj, companytype, ProductCatalogueID, Width, e, isDisplaySupplier) {

    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    textboxid = document.getElementById(buttonObj.id);
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContent(ProductCatalogueID, companytype, buttonObj.value, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                    //}
                    //                    else {
                    //                        try {
                    //                            CustomerDiv.style.visibility = 'hidden';
                    //                        }
                    //                        catch (err) {
                    //                        }
                    //                    }
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContent(ProductCatalogueID, companytype, buttonObj.value, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
        //        }
        //        else {
        //            try {
        //                CustomerDiv.style.visibility = 'hidden';
        //            }
        //            catch (err) {
        //            }
        //        }
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}

//to get product details for outwork(supplier) fill GetCustomFieldAutofill
function GetSupplierProductDetailsAutofill(buttonObj, companytype, CompanyID, Width, e, isDisplaySupplier) {
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    textboxid = document.getElementById(buttonObj.id);
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');

    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;
                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';


                }
        }
    }
    else {
        this.pointer = 0;

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContent(CompanyID, companytype, buttonObj.value, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                switch (e.keyCode) {
                    case 38:
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40:
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
}


//get customfields autofill
function GetCustomFieldAutofill(buttonObj, hdnstocktype, companytype, CompanyID, Width, e, isDisplaySupplier) {
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    var CustomFieldType = '';
    var StockType = '';
    StockType = document.getElementById(hdnstocktype).value;
    textboxid = (buttonObj.id);
    this.textbox = document.getElementById(buttonObj);
    if ((textboxid).indexOf('CF1') > -1) {
        CustomFieldType = 'customfield2'; //since customfield1 represents location in table
    }
    if ((textboxid).indexOf('CF2') > -1) {
        CustomFieldType = 'customfield3';
    }
    if ((textboxid).indexOf('CF3') > -1) {
        CustomFieldType = 'customfield4';
    }
    if ((textboxid).indexOf('CF4') > -1) {
        CustomFieldType = 'customfield5';
    }
    if ((textboxid).indexOf('CF5') > -1) {
        CustomFieldType = 'customfield6';
    }
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');

    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;
                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeCustomerContentAnyParam(CompanyID, companytype, buttonObj.value, StockType, CustomFieldType, isDisplaySupplier);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';


                }
        }
    }
    else {
        this.pointer = 0;

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeCustomerContentAnyParam(CompanyID, companytype, buttonObj.value, StockType, CustomFieldType, isDisplaySupplier);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
    }
    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {

            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                switch (e.keyCode) {
                    case 38:
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40:
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
}


// Here You Can write your own functions
function BindResultCustomer(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID, StatusTitle)// ClientAlias
{
    //alert(ClientID + "==" + ClientName + "==" + Contacts + "==" + AccountNo + "==" + Address + "==" + ClientAlias);
    if (Pgtype == "client") {
        GetClientNameNew(ClientID, ClientName, Contacts, AccountNo, Address);

    }
    else {
        GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID, StatusTitle);

    }

    if (Pgtype == "estimate" || Pgtype == "deliverynote") {
        //  alert("Page=" + Pgtype);
        CustomerDiv.style.display = "none";
        CustomerDiv.style.visibility = 'hidden';
        //GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address);
        GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, undefined, undefined, undefined, undefined, undefined, undefined, StatusTitle);
    }
}
function BindResultSupplier(ClientID, ClientName, Contacts, AccountNo, Address) {
    // alert(ClientID + "==" + ClientName + "==" + Contacts + "==" + AccountNo + "==" + Address);

    GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address);
    CustomerDiv.style.visibility = 'hidden';
}

function BindResultClientAll(ClientID, ClientName, CompanyType, Address, Department) {
    //alert(ClientID + "==" + ClientName + "==" + CompanyType);
    GetValues(ClientID, ClientName, CompanyType, Address);
    GetDepartmentDetails(Department);
    CustomerDiv.style.visibility = 'hidden';
}

//===================added by rakshith================//
function BindResultWarehouseLocation(LocationID, LocationName) {

    textboxid.value = SpecialDecode(LocationName);
    hdnlocation.value = LocationID;
    CustomerDiv.style.visibility = 'hidden';
}
function BindResultItemCodeTitle(PriceCatalogueID, ItemCode, ItemTitle) {

    textboxid.value = ItemCode;
    titletextboxid.value = SpecialDecode(ItemTitle);
    otherkititemid.value = PriceCatalogueID;
    duplicatecodevalidate(textboxid, titletextboxid, otherkititemid, ItemCode);
    CustomerDiv.style.visibility = 'hidden';

}
function BindResultProductJobList(JobId, estimateid, JobNumber, Quantity) {
    textboxid.value = JobNumber;
    GetJobDetails(estimateid, Quantity);
    CustomerDiv.style.visibility = 'hidden';
}

function BindSuplierProductDetails(PricecatalogueID, ItemTitle, Description, Artwork, Color, Size, Material, Delivery, Finishing, Proofs,
Packing, Notes, Instructions, CustomDescription1, CustomDescription2, CustomDescription3, CustomDescription4, CustomDescription5, CustomDescription6, CustomDescription7,
CustomDescription8, CustomDescription9, CustomDescription10, CustomDescription11, CustomDescription12, CustomDescription13, CustomDescription14, CustomDescription15, CustomDescription16
, CustomDescription17, CustomDescription18, CustomDescription19, CustomDescription20, CustomDescription21, CustomDescription22, CustomDescription23, CustomDescription24, CustomDescription25) {

    BindSelectedProductOutworkDetails(PricecatalogueID, ItemTitle, Description, Artwork, Color, Size, Material, Delivery, Finishing, Proofs,
Packing, Notes, Instructions, CustomDescription1, CustomDescription2, CustomDescription3, CustomDescription4, CustomDescription5, CustomDescription6, CustomDescription7,
CustomDescription8, CustomDescription9, CustomDescription10, CustomDescription11, CustomDescription12, CustomDescription13, CustomDescription14, CustomDescription15, CustomDescription16
, CustomDescription17, CustomDescription18, CustomDescription19, CustomDescription20, CustomDescription21, CustomDescription22, CustomDescription23, CustomDescription24, CustomDescription25)
}

function BindResultProductCustomField(CustomFieldText) {
    document.getElementById(textboxid).value = CustomFieldText;
    CustomerDiv.style.visibility = 'hidden';
}
//=================added by rakshith==========================//


//===================to get Estimate/Job/Invoice title added by kruti================//
function BindResultEstimateTitle(PhraseBookID, PhraseText) {

    textboxid.value = SpecialDecode(PhraseText);
    //    otherkititemid.value = PhraseBookID;
    CustomerDiv.style.visibility = 'hidden';

}
//=================added by kruti==========================//

//===========  Toget ink in inkseletcor popup page =================///
function writeInkSelectorContent(CompanyID, ItemType, InkType, SearchParameter, cnt) {
    AutoFill.GetInks(CompanyID, ItemType, InkType, SearchParameter, onResponse, onTimeout, onError);
}

function displayInks(buttonObj, ItemType, InkType, CompanyID, cnt, Width, e) {
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;

    //for keyboard
    var ac = this;
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {
        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {
                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }
                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeInkSelectorContent(CompanyID, ItemType, InkType, buttonObj.value, cnt);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                }
        }
    }
    else {
        this.pointer = 0;

        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeInkSelectorContent(CompanyID, companytype, buttonObj.value, cnt);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
    }
    this.selectDiv = function (inc) {
        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                switch (e.keyCode) {
                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }

        }
    }
    //for keyboard
}

function BindResultInks(InventoryID, InventoryCode, InventoryName, InkInventoryName) {
    GetInksName(InventoryID, InventoryCode, InventoryName, InkInventoryName);
    //CustomerDiv.style.visibility = 'hidden';
}

//=========== END Toget ink in inkseletcor popup page ==============//

function displayContact(buttonObj, companytype, CompanyID, Width, e, clientid) {
    Customer_offsetTop = 1;
    Customer_offsetLeft = 1;
    var ac = this;
    this.textbox = document.getElementById(buttonObj.id);
    var innertextbox = document.getElementById(buttonObj.id);
    if (CustomerDiv != false) {
        this.div = document.getElementById(CustomerDiv.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {
        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {
                    CustomerDiv.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;
                    ClickEvent = buttonObj.id;
                    if (oldDiv) {
                        document.getElementById(oldDiv).style.display = 'none';
                    }

                    initCustomer(buttonObj.id, Width, 'l');
                    CustomerDiv.innerHTML = '';
                    writeContactName(CompanyID, companytype, clientid, buttonObj.value);
                    positionCustomer(buttonObj);
                    CustomerDiv.style.visibility = 'visible';
                }
        }
    }
    else {
        this.pointer = 0;
        ClickEvent = buttonObj.id;
        if (oldDiv) {
            document.getElementById(oldDiv).style.display = 'none';
        }
        initCustomer(buttonObj.id, Width, 'l');
        CustomerDiv.innerHTML = '';
        writeContactName(CompanyID, companytype, clientid, buttonObj.value);
        positionCustomer(buttonObj);
        CustomerDiv.style.visibility = 'visible';
    }
    this.selectDiv = function (inc) {
        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e) {
                e = e || window.event;
                //alert(e.keyCode);
                switch (e.keyCode) {

                    case 38: //up
                        {
                            innertextbox.focus();
                            break;
                        }
                    case 40: //down
                        {
                            innertextbox.focus();
                            break;
                        }
                }
            }
        }
    }
    //for keyboard
}


function writeContactName(CompanyID, CompanyType, clientid, searchParameter) {
    if (CompanyType == "customer") {
        AutoFill.GetContactName(CompanyID, clientid, searchParameter, onResponse, onTimeout, onError);

    }
}

function BindResultContact(ContactID, ContactName) {
    GetContactName(ContactID, ContactName)
}

function getdatafrmsp(companyid, ddlvalue) {

    AutoFill.crm_common_select_accessrightOfUserType(companyid, ddlvalue, Onsuccuss);
    // item_summary.UpdateItemDescriptionInSummary(companyid, ddlvalue);

}


function bindUploadimgname() {
    var imagenameCookie = readCookie("UploadedUserImage");
    cookiearray = imagenameCookie.split('&');
    ckiename = cookiearray[0].split('=')[0];
    upimagename = cookiearray[0].split('=')[1];

    displyUpimageName(upimagename);
    //to delete the cookie
    clearCookie(imagenameCookie);
}

function clearCookie(name) {
    var date = new Date();
    date.setDate(date.getDate() - 1);
    document.cookie = name + "=''; expires=" + date + "; path=/";
}

function readCookie(name) {
    return (name = new RegExp('(?:^|;\\s*)' + ('' + name).replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&') + '=([^;]*)').exec(document.cookie)) && name[1];
}

function displyUpimageName(upimagename) {
    document.getElementById("div_uploadedimagename").style.display = "block";

    lbluserimg.style.display = "block";
    ancUploadimage.style.display = "none";
    lnkUpimagepath.innerHTML = upimagename;
    hid_UserImage.value = upimagename;
    lnkUpimagepath.target = "_blank";
    lnkUpimagepath.href = strSitePath + "DocManager.ashx?doctype=imgcpuser&filename=" + upimagename;
}

function RemoveImage(type) {
    if (type == "image") {
        lbluserimg.innerHTML = "";
        hid_UserImage.value = "";
        lbluserimg.style.display = "none";
        ancUploadimage.style.display = "block";
    }
}
function BindResultGroup(GroupID, GroupName) {
   
    GetGroupName_Textbox(GroupID, GroupName);
}