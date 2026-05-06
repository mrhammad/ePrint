
//for address and delivery address substring split
var substringsize = 27;

function LoadHeader() {
    if (Pgtype == "job") {
        document.getElementById("lblheader").innerHTML = "Create Job";
    }
    if (Pgtype == "invoice") {
        document.getElementById("lblheader").innerHTML = "Create Invoice";
    }
}
LoadHeader();

this.pointer = 0;
//********** web service to autocomplete clientname *********//
function BindClientName(txtval, e, objectname) {
    if (txtval == '') {
        return false;
    }
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

                    if (txtval.length > 2) {
                        var val = CompID + "±" + txtval;
                        document.getElementById("spn_ddlcontact").style.display = "none";
                        document.getElementById("spn_txtCompany").style.display = "none";
                        ddlcontact.length = 0;
                        PageMethods.GetClientName(val, FindSuccCName, ShowMsg_Failure);
                    }
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

function ShowMsg_Failure(error) {
}
function FindSuccCName(result) {
    result = result.replace(/'/gi, "`")
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
            finalval += " <a href='#' onclick=\"javaScript:GetClientName11('" + store_ID + "','" + store_Name + "','" + store_contacts + "','" + store_accountno + "','" + store_address + "')\">" + store_Name + "</a>";
            finalval += "</div>";
        }
        divCheck.innerHTML = finalval;
    }
    else {
        ShowOff('divCheck');
    }
}



function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
    hid_CustName.value = ClientName;
    txtName.value = ClientName;
    txtCompany.value = ClientName;
    hid_ClientID.value = ClientID;
    txtGreeting.value = "Dear";

    //*** to bind attention from clientID *****//
    var ContactName = '';
    var ContactID = '';
    ddlcontact.length = 0;
    var str_con1 = Contacts.split('^');
    //ddlcontact.options.add(new Option('--- Select ---',0,0));                                          
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = trim12(ContactIDName[1]);
            ddlcontact.options.add(new Option(ContactName, ContactID, k));
        }
    }
    ddlcontact.selectedIndex = 0;
    //to bind greeting//   
    if (str_con1 != '') {
        var firstname = ddlcontact.options[ddlcontact.selectedIndex].text.split(' ');
        txtGreeting.value = txtGreeting.value + ' ' + firstname[0];

        GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected                                                                              
    }
    //  end   
    // to bind salesperson

    GetSalesperson(hid_ClientID.value);
    //to bind Account No//
    lblAccountNumber.innerHTML = AccountNo;
    //  end

    ShowOff("divCheck");
    //*** End of to bind attention from clientID *****//


    //*** to bind address from clientID *****//  

    hid_DeliveryAddressID.value = 0;
    lblDeliveryAddress.innerHTML = '';

    if (Address != '') {
        var str_add1 = Address.split('»'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain

        for (var i = 0; i < str_add1.length; i++) {
            if (str_add1[i] != '') {
                var AddressID = str_add1[0];
                var Address1 = str_add1[1];
                var LimitAddress = str_add1[2];
                var IsDelivery = str_add1[3];
                var AddressType = str_add1[4];
                var Address_Limit;

                //                        if (Address1.length > substringsize) {
                //                            Address_Limit = trim12(Address1.substring(0, substringsize)) + '...';
                //                        }
                //                        else {
                Address_Limit = Address1;
                //                        }

                //                        hdnAddressID.value = AddressID;
                //                        lblAddress.title = Address1;
                //                        hid_IsDelivery.value = IsDelivery;


                hid_DeliveryAddressID.value = AddressID;
                lblDeliveryAddress.innerHTML = Address_Limit;
                lblDeliveryAddress.title = Address1;
                hid_DelAddressType.value = AddressType;
            }
        }
    }
    txtName.focus();
}

function GetSalesperson(clientid) {
    PageMethods.GetSalesPerson(CompID, clientid, Findsucc);
}

function Findsucc(result) {
    for (var i = 0; i < ddlSalesPerson.length; i++) {
        if (ddlSalesPerson.options[i].value == result) {
            ddlSalesPerson.selectedIndex = i;
        }
    }
}
function ReloadContact(FinalContact) {
    var ContactName = '';
    var ContactID = '';
    ddlcontact.length = 0;
    var str_con1 = FinalContact.split('µ');

    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = ContactIDName[1];
            ddlcontact.options.add(new Option(ContactName, ContactID, k));
            ddlcontact.selectedIndex = k;
        }
    }

    txtGreeting.value = "Dear";
    var firstname = ddlcontact.options[ddlcontact.selectedIndex].text.split(' ');
    txtGreeting.value = txtGreeting.value + ' ' + firstname[0];

    GetContactID(ddlcontact.value);
}
function GetContactID(ddlval) {
    hid_ContactID.value = ddlval;
    txtGreeting.value = "Dear";

    PageMethods.GetContactAddress(CompID, ddlval, GetAddress);

    for (var i = 0; i < ddlcontact.length; i++) {
        if (ddlcontact.options[i].value == ddlval) {
            var firstname = ddlcontact.options[i].text.split(' ');
            txtGreeting.value = txtGreeting.value + ' ' + firstname[0];
        }
    }
}
function GetAddress(result) {
    hid_AddressType.value = 'C';
    //'C' -- contact Address, 'A'-- Mian Address
    //hid_DelAddressType.value = 'M';//'C' -- contact Address, 'A'-- Mian Address
    hdnAddressID.value = 0;
    lblAddress.innerHTML = '';


    var Address = '';
    var add = result.split('±');
    for (var j = 0; j < add.length; j++) {
        var str = add[j].split('»');
        if (trim12(str[0]) == "ContactID") {
            hdnAddressID.value = str[1];
        }
//        if (trim12(str[0]) == "BusinessAddress") {
//            Address += str[1] + " ";
//        }
//        if (trim12(str[0]) == "BusinessCity") {
//            Address += str[1] + " ";
//        }
//        if (trim12(str[0]) == "BusinessState") {
//            Address += str[1] + " ";
//        }
//        if (trim12(str[0]) == "BusinessCountry") {
//            Address += str[1] + " ";
//        }

        //--New by Swetha
        if (trim12(str[0]) == "Address") {
            Address = str[1];
        }
    }

    lblAddress.innerHTML = Address;
    lblAddress.title = Address;
    //            if (lblAddress.innerHTML.length > substringsize) {
    //                lblAddress.innerHTML = lblAddress.innerHTML.substring(0, substringsize) + "...";
    //            }

}
//********** End of web service to autocomplete clientname *********//

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
function changeTheHeightOfText() {
    if (navigator.appName.toLowerCase() == "microsoft internet explorer") {
        txtName.style.height = "15px";
    }
    else if (navigator.appName.toLowerCase() == "netscape") {
        txtName.style.marginTop = "1px";
    }
}

function add_contact() 
{    
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
            PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value, '980', '500')
        }
        else {
            PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type, '980', '500')
        }
        return true;
    }
}

function SendAddressIDandName(id, values, isdelivery, tooltip, addresstype) {

    if (values.length != 0) {
        for (var i = 0; i < values.length; i++) {
            values = values.replace('<br/>', '');
            i++;
        }
    }

    hid_AddressType.value = addresstype;
    lblAddress.title = tooltip;
    lblAddress.innerHTML = trim12(values);
    lblAddress.style.cursor = "pointer";
    hdnAddressID.value = id;

    if (isdelivery.toLowerCase() == "true") {
        lblDeliveryAddress.title = tooltip;
        lblDeliveryAddress.innerHTML = trim12(values);
        lblDeliveryAddress.style.cursor = "pointer";
        hid_DeliveryAddressID.value = id;
        document.getElementById("spn_lblDeliveryAddress").style.display = "none";
    }
    //            if (lblAddress.innerHTML.length > substringsize) {
    //                lblAddress.innerHTML = trim12(lblAddress.innerHTML.substring(0, substringsize)) + "...";
    //            }
    document.getElementById("spn_lblAddress").style.display = "none";
}
function validateblank(val, spn) {
    if (val != '') {
        document.getElementById(spn).style.display = "none";
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

function SendPhraseIDandName(id, values, phrasetype, tooltip) {
    var lblPhraseText = '';
    if (phrasetype == 'Estimate Header' || phrasetype == 'Invoice Header' || phrasetype == 'Job Header') {
        lblPhraseText = lblHeader;
        hid_HeaderText.value = trim12(values);
        hid_HeaderID.value = id;
    }
    else if (phrasetype == 'Estimate Footer' || phrasetype == 'Invoice Footer' || phrasetype == 'Job Footer') {
        lblPhraseText = lblFooter;
        hid_FooterText.value = trim12(values);
        hid_FooterID.value = id;
    }
    lblPhraseText.title = tooltip;
    lblPhraseText.innerHTML = trim12(values);
    lblPhraseText.style.cursor = "pointer";
    //            if (lblPhraseText.innerHTML.length > substringsize) 
    //            {
    //                lblPhraseText.innerHTML = trim12(lblPhraseText.innerHTML.substring(0, substringsize)) + "...";
    //            }
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
function validateEstTitle(val) {
    if (val != '') {
        document.getElementById("spn_txtEstimateTitle").style.display = "none";
    }
}
function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype) {
    if (values.length != 0) {
        for (var i = 0; i < values.length; i++) {
            values = values.replace('<br/>', '');
            i++;
        }
    }
    hid_DelAddressType.value = addresstype;

    lblDeliveryAddress.title = tooltip;
    lblDeliveryAddress.innerHTML = trim12(values);
    lblDeliveryAddress.style.cursor = "pointer";
    //            if (lblDeliveryAddress.innerHTML.length > substringsize) 
    //            {
    //                lblDeliveryAddress.innerHTML = trim12(lblDeliveryAddress.innerHTML.substring(0, substringsize)) + "...";
    //            }
    hid_DeliveryAddressID.value = id;
    document.getElementById("spn_lblDeliveryAddress").style.display = "none";
}

var stage1_values = '';
function Stage1ToStage2() {
    var ShallIGo = true;
    stage1_values = '';
    ShallIGo = Stage1Validation(); ////VALIDATION CHECKING                                                           
    if (ShallIGo) {
        StoreTheEstimateStage1();

        document.getElementById("divStage1").style.display = "none";
        document.getElementById("divStage2").style.display = "block";
        document.getElementById("div_stage_2").style.display = "block";
        document.getElementById("lblheader").innerHTML = "Create Item";
        DefaultSettings();
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
    ClienName = customer_name.value;
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
    if (CheckReqCompare(txtValidFor.value, 'spn_txtValidFor', 'spn_txtValidFor')) {
        IsCorrect = false;
    }
    if (CheckStringMandatory(lblDeliveryAddress.innerHTML, 'spn_lblDeliveryAddress')) {
        IsCorrect = false;
    }
    if (ValidateForm(txtEstimateDate, 'spn_txtEstimateDate', DateFormat_stage) == false) {
        IsCorrect = false;
    }
    return IsCorrect;
}

//// this funcn is called in the table view btn
function ShowItemForm(val1) {
    if (val1 == "Form") {
        document.getElementById("divMainContent").style.display = "none";
        document.getElementById("div_Item_Form").style.display = "block";
    }
    else if (val1 != "Form") {
        document.getElementById("divMainContent").style.display = "block";
        document.getElementById("div_Item_Form").style.display = "none";

    }
    scrollTo(20, 20);
    return false;
}

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

    if (txtName.value == "") {
        alert("Please select the supplier to proceed...");
        return false;
    }
    else {
        if (addtype == "default") {
            PopupCenter(strSitepath + "common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '800', '400')
        }
        else if (addtype == "delivery") {
            PopupCenter(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '800', '400')
        }
        return true;
    }
}

function new_contact() {
    PopupCenter(strSitepath + "common/common_popup.aspx?type=newcontact&mode=add&pg=" + pg, '800', '400')
}
function popup_phrasebook(type) {
    PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
}

var Stage4Name = 'Item Description';

function changeTabColor(issitem) {
    document.getElementById(issitem).style.color = "orange";

    for (var i = 0; i < 5; i++) {
        var dd = "spnEst_" + i;
        if (dd != issitem) {
            if (document.getElementById("spnEst_" + i) != null) {
                document.getElementById("spnEst_" + i).style.color = "black";
            }
        }
        else {
            var stname = '';
            if (i == 1) {
                stname = "Create Estimate";
            }
            else if (i == 2) {
                stname = "Create Item";
            }
            else if (i == 3 || i == 4) {
                if (estimateType == 'printbroker') {
                    stname = "RFQ Description";
                }
                else {
                    stname = Stage4Name;
                }
            }
            if (document.getElementById("div_none").style.display != "block") {
                document.getElementById("lblheader").innerHTML = stname;
            }
        }
    }
}
try {
    txtName.focus();
}
catch (err) {
}