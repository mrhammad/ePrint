
function showhideDDL(type) {
    
    if (type == 'hide') {
        document.getElementById("div_blank").style.display = "block";
        document.getElementById("div_ddl").style.display = "none";
    }
    else if (type == 'show') {
        document.getElementById("div_blank").style.display = "none";
        document.getElementById("div_ddl").style.display = "block";
    }
}
function more_address(addtype) {
    if (hid_ClientID.value != "" && Number(hid_ClientID.value) != 0) {
        if (addtype == "default") {
            PopupCenter(strSitepath + "common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
        }
        else if (addtype == "delivery") {
            PopupCenter(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
        }
        return true;
    }
    else {
        alert("Please select Customer to proceed...");
        return false;
    }
}
function new_contact() {
    PopupCenter(strSitepath + "common/common_popup.aspx?type=newcontact&mode=add&pg=" + pg, '800', '400')
}
function popup_phrasebook(type) {
    PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
}

function LoadHeader() {
    if (Pgtype == "job") {
        document.getElementById("lblheader_page").innerHTML = "Create Job";
    }
    if (Pgtype == "invoice") {
        document.getElementById("lblheader_page").innerHTML = "Create Invoice";
    }
}
LoadHeader();


function showddl(divid) {
    
    document.getElementById(divid).style.display = "block";
    document.getElementById("spn_txtGreeting").style.display = "none";
    ddlcontact.style.display = "none";
}
function ShowOff(divid) {
    document.getElementById(divid).style.display = "none";
    ddlcontact.style.display = "block";
}
function addTotxt(divid, divValue) {
    txtName.value = leftTrim(document.getElementById(divid).innerHTML);
    ShowOff('div_list')
}
function leftTrim(str) {
    var str = str.replace(/^\s\s*/, ''),
              ws = /\s/,
              i = str.length;
    while (ws.test(str.charAt(--i)));
    return str.slice(0, i + 1);

}

function ShowMsg_Failure(error) { }
function FindSuccCName(result) {
    alert(result);
    if (trim12(result) != '') {
        showddl('divCheck');
        document.getElementById('spn_txtName').style.display = "none";
        var divCheck = document.getElementById("divCheck");

        var str_prop1 = result.split('µ');
        var store_Name = '';
        var store_ID = '';
        var store_contacts = '';
        var store_accountno = '';
        var store_address = '';

        var finalval = '';
        for (var i = 0; i < str_prop1.length - 1; i++) {
            var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^  
            store_ID = str_prop2[0];
            store_Name = str_prop2[1];
            store_contacts = str_prop2[2];
            store_accountno = str_prop2[3];
            store_address = str_prop2[4];

            var color1 = "#DADADA";
            if (i % 2 == 0) {
                color1 = "#EFEFEF";
            }
            finalval += "<div class='divpad' style='height:20px;z-index:1000;'>";

            finalval += " <a href='#' onclick=\"javaScript:GetClientName11('" + store_ID + "','" + store_Name + "','" + store_contacts + "','" + store_accountno + "','" + store_address + "','" + DepartmentName + "')\">" + store_Name + "</a>";
            finalval += "</div>";
        }
        divCheck.innerHTML = finalval;
    }
    else {
        ShowOff('divCheck');
    }
}

function GetPhrase(type) {
    if (type == 'Header') {
        if (Pgtype == 'invoice') {
            popup_phrasebook('Invoice Header');
        }
        else if (Pgtype == 'job') {
            popup_phrasebook('Job Header');
        }
        else {
            popup_phrasebook('Estimate Header');
        }
    }
    else if (type == 'Footer') {
        if (Pgtype == 'invoice') {
            popup_phrasebook('Invoice Footer');
        }
        else if (Pgtype == 'job') {
            popup_phrasebook('Job Footer');
        }
        else {
            popup_phrasebook('Estimate Footer');
        }
    }
}

this.pointer = 0;
//********** web service to autocomplete clientname *********//
function BindClientName(txtval, e, objectname) {   
    var ac = this;
    this.textbox = document.getElementById(objectname.id);
    this.div = document.getElementById('divCheck');
    this.list = this.div.getElementsByTagName('div');
    var innertextbox = document.getElementById(objectname.id);
    if (e != undefined) {
        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up
                ac.selectDiv(-1);
                break;
            case 40: //down
                ac.selectDiv(1);
                break;
            case 13: //hide div
                ShowOff("divCheck");
                break;

            default:
                {
                    this.pointer = 0;
                    var val = CompID + "±" + txtval;
                    document.getElementById("spn_ddlcontact").style.display = "none";
                    document.getElementById("spn_txtCompany").style.display = "none";
                    ddlcontact.length = 0;
                    PageMethods.GetClientName(val, FindSuccCName, ShowMsg_Failure);
                    break;
                }
        }
    }

    this.selectDiv = function(inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function(e)// 
            {
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
    //gajendra                                        
}

function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName) {
    debugger;
    hid_CustName.value = ClientName;
    txtName.value = ClientName;
    txtCompany.value = DepartmentName;  //ClientName;
    hid_ClientID.value = ClientID;
    txtGreeting.value = "Dear";

    //*** to bind attention from clientID *****//
    var ContactName = '';
    var ContactID = '';
    ddlcontact.length = 0;
    ddlinvoicecontact.length = 0;
    var str_con1 = Contacts.split('^');
    //ddlcontact.options.add(new Option('--- Select ---',0,0));                                          
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = trim12(ContactIDName[1]);
            ddlcontact.options.add(new Option(ContactName, ContactID, k));
            ddlinvoicecontact.options.add(new Option(ContactName, ContactID, k));

        }
    }
    ddlcontact.selectedIndex = 0;
    ddlinvoicecontact.selectedIndex = 0;

    //to bind greeting//   
    if (str_con1 != '') {
        var firstname = ddlcontact.options[ddlcontact.selectedIndex].text.split(' ');
        txtGreeting.value = txtGreeting.value + ' ' + firstname[0];
        GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected                                                                              
    }
    //  end   
    // to bind salesperson

    GetSalesperson(hid_ClientID.value);
    GetInvoiceContact(hid_ClientID.value);
    //to bind Account No//
    lblAccountNumber.innerHTML = AccountNo;
    //  end

    ShowOff("divCheck");
    //*** End of to bind attention from clientID *****//

    //*** to bind address from clientID *****//  
    hid_DeliveryAddressID.value = 0;
    lblDeliveryAddress.innerHTML = '';
    if (Address != '') {
        var str_add1 = Address.split('»');            //Plain1^Silk^Graphic^gfdsgbfs^test^Plain
        for (var i = 0; i < str_add1.length; i++) {
            if (str_add1[i] != '') {
                var AddressID = str_add1[0];
                var Address1 = str_add1[1];
                var LimitAddress = str_add1[2];
                var IsDelivery = str_add1[3];
                var AddressType = str_add1[4];
                var Address_Limit;

                Address_Limit = Address1;

                hdnAddressID.value = DepartmentName; //AddressID;

                lblAddress.title = Address1;
                hid_IsDelivery.value = IsDelivery;
                hid_DeliveryAddressID.value = AddressID;
                lblDeliveryAddress.innerHTML = Address_Limit;
                lblDeliveryAddress.title = Address1;
                hid_DelAddressType.value = AddressType;
            }
        }
    }
    txtName.focus()

    // *** End of address *****//                                                    
}

function GetSalesperson(clientid) {
    PageMethods.GetSalesPerson(CompID, clientid, Findsucc);
}

function GetInvoiceContact(clientid) {
    PageMethods.GetInvoiceContact(CompID, clientid, FindsuccIC);
}

function FindsuccIC(result) {
    debugger;
    if (result == 0 || result == null) {
        var selectedIndex = ddlcontact.selectedIndex;
       result = ddlcontact.options[selectedIndex].text;
    }

    for (var i = 0; i < ddlinvoicecontact.length; i++) {
        if (ddlinvoicecontact.options[i].value == result) {
            ddlinvoicecontact.selectedIndex = i;
        }
    }
}






function Findsucc(result) {
    if (result == '0') {
        result = UserID;
    }
    for (var i = 0; i < ddlSalesPerson.length; i++) {
        if (ddlSalesPerson.options[i].value == result) {
            ddlSalesPerson.selectedIndex = i;
        }
    }
}

function GetContactID(ddlval) {
    debugger;
    hid_ContactID.value = ddlval;
    txtGreeting.value = "Dear";

    //To get Contact Address//
    PageMethods.GetContactAddress(CompID, ddlval, GetAddress);

    //to bind greeting// 
    for (var i = 0; i < ddlcontact.length; i++) {
        if (ddlcontact.options[i].value == ddlval) {
            var firstname = ddlcontact.options[i].text.split(' ');
            txtGreeting.value = txtGreeting.value + ' ' + firstname[0];
        }
    }
}

function GetAddress(result) {
    hid_AddressType.value = 'C'; //'C' -- contact Address, 'A'-- Mian Address
    //                      hid_DelAddressType.value = 'M';//'C' -- contact Address, 'A'-- Mian Address
    hdnAddressID.value = 0;
    lblAddress.innerHTML = '';

    var Address = '';
    var add = result.split('±');
    for (var j = 0; j < add.length; j++) {
        var str = add[j].split('»');
        if (trim12(str[0]) == "ContactID") {
            hdnAddressID.value = str[1];

        }
        if (trim12(str[0]) == "BusinessAddress") {
            Address += str[1] + " ";
        }
        if (trim12(str[0]) == "BusinessCity") {
            Address += str[1] + " ";
        }
        if (trim12(str[0]) == "BusinessState") {
            Address += str[1] + " ";
        }
        if (trim12(str[0]) == "BusinessCountry") {
            Address += str[1] + " ";
        }
    }

    lblAddress.innerHTML = Address;
    lblAddress.title = Address;
}
//********** End of web service to autocomplete clientname *********//

function add_contact() {
    var EstimateID = hid_EstimateID.value; ;

    if (txtName.value == "") {
        ddlcontact.length = 0;
        alert("Please select the customer to proceed...");
        return false;
    }
    else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
        alert("Please select the customer to proceed...");
        return false;
    }
    else if (hid_CustName.value != txtCustomerName.value) {
        alert("Please select the customer to proceed...");
        return false;
    }
    else {
        if (req_type == "edit") {
            PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + EstimateID, '900', '400')
        }
        else {
            PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type, '900', '400')
        }
        return true;
    }
}

function SendAddressIDandName(id, values, isdelivery, tooltip, addresstype) {
    hid_AddressType.value = addresstype; //"C"-- Contact Address, "A"-- Main Address
    lblAddress.title = tooltip;
    lblAddress.innerHTML = values;
    lblAddress.style.cursor = "pointer";

    hdnAddressID.value = id;

    if (isdelivery.toLowerCase() == "true") {
        lblDeliveryAddress.title = tooltip;
        lblDeliveryAddress.innerHTML = values;

        lblDeliveryAddress.style.cursor = "pointer";
        hid_DeliveryAddressID.value = id;
        document.getElementById("spn_lblDeliveryAddress").style.display = "none";
    }
    document.getElementById("spn_lblAddress").style.display = "none";

}
function validateblank(val, spn) {
    if (val != '') {
        document.getElementById(spn).style.display = "none";
    }
}

function SendPhraseIDandName(id, values, phrasetype, tooltip) {
    var lblPhraseText = '';
    if (phrasetype == 'Estimate Header' || phrasetype == 'Invoice Header') {
        lblPhraseText = lblHeader;
        hid_HeaderText.value = trim12(values);
        hid_HeaderID.value = id;
    }
    else if (phrasetype == 'Estimate Footer' || phrasetype == 'Invoice Footer') {
        lblPhraseText = lblFooter;
        hid_FooterText.value = trim12(values);
        hid_FooterID.value = id;
    }
    lblPhraseText.title = tooltip;
    lblPhraseText.innerHTML = trim12(values);
    lblPhraseText.style.cursor = "pointer";
    document.getElementById("spn_lblHeader").style.display = "none";
    document.getElementById("spn_lblFooter").style.display = "none";
}



function CheckPage() {
    if (Pgtype == "job") {
        document.getElementById("divJobNumInfo").style.display = "block";
        document.getElementById("divEstiDateInfo").style.display = "none";
        document.getElementById("divProgressdOn").style.display = "block";
        document.getElementById("divSalesPerson").style.display = "none";
    }
}
CheckPage();


function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype) {
    hid_DelAddressType.value = addresstype;
    lblDeliveryAddress.title = tooltip;
    lblDeliveryAddress.innerHTML = trim12(values);

    lblDeliveryAddress.style.cursor = "pointer";
    hid_DeliveryAddressID.value = id;
    document.getElementById("spn_lblDeliveryAddress").style.display = "none";
}

var stage1_values = '';
function Stage1ToStage2() {
//    alert('ghfg');
    var ShallIGo = true;
    stage1_values = '';
    ShallIGo = Stage1Validation(); ////VALIDATION CHECKING                                                           
    if (ShallIGo) {
        alert('Valid');
        StoreTheEstimateStage1();
        document.getElementById("divStage1").style.display = "none";
        document.getElementById("divStage2").style.display = "block";
        document.getElementById("lblheader_page").innerHTML = "Item Selection";
      

        /*
        DefaultSettings();
        CustomerName_CallByStage1();
        */
    }

}
function ShowStage1() {
    document.getElementById("divStage1").style.display = "block";
    document.getElementById("divStage2").style.display = "none";
    document.getElementById("lblheader_page").innerHTML = "Create Estimate";
}
function ShowProduct_ddl(val) {
    if ("digital" == val) {
        document.getElementById("div_ProductType").style.display = "block";
    }
    else {
        document.getElementById("div_ProductType").style.display = "none";
    }
}

function StoreTheEstimateStage1() {
    var StoreSatge1 = '';
    StoreSatge1 += "CustomerID»" + hid_ClientID.value + '±';
    StoreSatge1 += "ContactID»" + ddlcontact.value + '±' + "Greeting»" + txtGreeting.value + '±';
    StoreSatge1 += "Company»" + txtCompany.value + '±' + "AddressID»" + hdnAddressID.value + '±';
    StoreSatge1 += "Header»" + hid_HeaderText.value + '±' + "Footer»" + hid_FooterText.value + '±';
    StoreSatge1 += "EstimateTitle»" + txtEstimateTitle.value + '±' + "EstimateNumber»" + lblEstimateNumber.innerHTML + '±';
    StoreSatge1 += "OrderNumber»" + txtOrderNumber.value + '±' + "StatusID»" + ddlStatus.value + '±';
    StoreSatge1 += "EstimateDate»" + txtEstimateDate.value + '±' + "ValidFor»" + txtValidFor.value + '±';
    StoreSatge1 += "DeliveryAddress»" + hid_DeliveryAddressID.value + '±' + "SalesPerson»" + ddlSalesPerson.value + '±';
    StoreSatge1 += "AddressType»" + hid_AddressType.value + '±' + "DeliveryAddressType»" + hid_DelAddressType.value + '±';
    stage1_values = StoreSatge1; //stored

    ClientID = hid_ClientID.value;

    hid_Stage1_values.value = stage1_values;


}

function Estimate_Edit_Save() {
    if (Stage1Validation()) {
        StoreTheEstimateStage1();
        hid_Stage1_values.value = stage1_values;
        return true;
    }
    else {
        return false;
    }
}

function Stage1Validation() {

    var IsCorrect = true;
    if (CheckStringMandatory(txtCustomerName.value, 'spn_txtName')) {
        IsCorrect = false;
        document.getElementById("spn_txtName").innerHTML = 'Please select Customer';
    }
    else {
        if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            IsCorrect = false;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
        }
        else if (hid_CustName.value != txtCustomerName.value) {
            IsCorrect = false;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
        }
    }
    if (CheckStringMandatory(ddlcontact.value, 'spn_ddlcontact')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblAddress.innerHTML, 'spn_lblAddress')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtGreeting.value, 'spn_txtGreeting')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtCompany.value, 'spn_txtCompany')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblHeader.innerHTML, 'spn_lblHeader')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblFooter.innerHTML, 'spn_lblFooter')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtEstimateTitle.value, 'spn_txtEstimateTitle')) {
        IsCorrect = false;
    }
    if (CallonChange(ddlStatus.value, 'spn_ddlStatus')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtEstimateDate.value, 'spn_txtEstimateDate')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(txtValidFor.value, 'spn_txtValidFor')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblDeliveryAddress.innerHTML, 'spn_lblDeliveryAddress')) {
        IsCorrect = false;
    }
    if (ValidateForm(txtEstimateDate, 'spn_txtEstimateDate', User_DateFormat) == false) {
        IsCorrect = false;
    }

    //        alert(ddlProductType.options[ddlProductType.selectedIndex].value);
    //        if (ddlProductType.options[ddlProductType.selectedIndex].value == "N") {
    //            if (CheckStringMandatory(txtPartPerSet.value, 'spn_txtPartPerSet')) {
    //                IsCorrect = false;
    //            }
    //        }
    return IsCorrect;
}