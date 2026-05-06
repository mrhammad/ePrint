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

function ClearStage1Data() {
    hid_CustName.value = "";
    txtName.value = "";
    txtCompany.value = "";
    hid_ClientID.value = 0;
    txtGreeting.value = "";
    ddlcontact.length = 0;
    ddlinvoicecontact.length = 0;
    lblAccountNumber.innerHTML = "";
    hdn_InvoiceAddressID.value = "";
    hdnStatusTitle.value = "";
}

this.pointer = 0;
//********** web service to autocomplete clientname *********//
function BindClientName(txtval, e, objectname) {
    if (txtval == '') {
        return false;
    }
    debugger;
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

    this.selectDiv = function (inc) {

        if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
            this.list[this.pointer].className = 'active1';
            this.pointer += inc;
            this.list[this.pointer].className = 'active';
            this.newList = this.list[this.pointer].getElementsByTagName('a')
            this.newList[0].focus();
            this.newList[0].onkeydown = function (e)// 
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

function ShowMsg_Failure(error) { }
function FindSuccCName(result) {
    debugger;   
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

function FindSuccDueDate(result) {
    var Days = result;
    //alert(days);
    var today = new Date();
    var TZdate = new Date(DateAccordingToTimeZone);

    //today.setDate(today.getDate() + Days);
    today.setDate(TZdate.getDate() + Days);

    var dd;
    var mm;
    if (today.getDate() < 10) {
        dd = '0' + today.getDate();
    }
    else {
        dd = today.getDate();
    }

    if ((today.getMonth() + 1) < 10) {
        mm = '0' + (today.getMonth() + 1);
    }
    else {
        mm = (today.getMonth() + 1);
    }
    var y = today.getFullYear();

    txtInvoiceDueDate.value = today;
    hdnInvoiceDueDate.value = result;
    //var someFormattedDate = comm.Eprint_return_Date_Before_View(today.value, 1660, 2552, false);
    if (DateFormat_stage == "dd/mm/yyyy") {
        txtInvoiceDueDate.value = dd + '/' + mm + '/' + y;
    }
    else {
        txtInvoiceDueDate.value = mm + '/' + dd + '/' + y;
    }
    //txtInvoiceDueDate.value = today;
}

function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID, StatusTitle) {
    // alert(ClientID + ", " + ClientName + ", " + Contacts + ", " + AccountNo + ", " + Address + ", " + DepartmentName + ", " + DepartmentID + ", " + InvoiceAddressID + "," + InvoiceAddress);

    debugger;
    ClearStage1Data();
    //alert(CostCentre.split('^'));  
    var url = window.location.href;
    if (url.indexOf("invoice/invoices_add") != -1) {
        PageMethods.GetInvoiceDueDate(ClientID, FindSuccDueDate, ShowMsg_Failure);
    }

    hid_CustName.value = SpecialDecode(ClientName);
    txtName.value = SpecialDecode(ClientName);
    if (DepartmentName != undefined) {
        txtCompany.value = SpecialDecode(DepartmentName); //ClientName;
    }
    hid_ClientID.value = ClientID;
    if (StatusTitle != undefined) {
        hdnStatusTitle.value = StatusTitle;
    }
    txtGreeting.value = "Dear";
    if (ContactAddress != undefined) {
        lblAddress.innerHTML = SpecialDecode(ContactAddress);
    }

    //hdn_ContactAddressID.value = ContactAddressID;
    hdnAddressID.value = ContactAddressID;


    if (InvoiceAddress != undefined) {
        lblInvoiceAddress.innerHTML = SpecialDecode(InvoiceAddress);
    }

    hdn_InvoiceAddressID.value = InvoiceAddressID;
    hdn_DepartmentID.value = DepartmentID;

    //*** to bind attention from clientID *****//
    var ContactName = '';
    var ContactID = '';
    var ISDefaultContact = '';
    var DefaultConInd = 0;

    ddlcontact.length = 0;
    ddlinvoicecontact.length = 0;
    var str_con1 = Contacts.split('^');


    //ddlcontact.options.add(new Option('--- Select ---',0,0));
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = SpecialDecode(trim12(ContactIDName[1]));
            ISDefaultContact = ContactIDName[2];

            if (ISDefaultContact == "1") {
                DefaultConInd = k;
            }

            ddlcontact.options.add(new Option(ContactName, ContactID, k));
            ddlinvoicecontact.options.add(new Option(ContactName, ContactID, k));
        }
    }
    ddlcontact.selectedIndex = DefaultConInd;
    ddlinvoicecontact.selectedIndex = DefaultConInd;
  


    //to bind greeting//   
    if (str_con1 != '') {
        var firstname = ddlcontact.options[ddlcontact.selectedIndex].text.split(' ');
        txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(firstname[0]);

        GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected                                                                              
    }
    //  end   
    // to bind salesperson

    GetSalesperson(hid_ClientID.value);
    GetInvoiceContact(hid_ClientID.value);
    //to bind Account No//
    lblAccountNumber.innerHTML = SpecialDecode(AccountNo);
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
                Address_Limit = Address1;

                //hdnAddressID.value = AddressID;
                //lblAddress.title = Address1;
                hid_IsDelivery.value = IsDelivery;
                hid_DeliveryAddressID.value = AddressID;

                if (Address_Limit != undefined) {
                    lblDeliveryAddress.innerHTML = SpecialDecode(Address_Limit);
                }

                if (Contacts == "") {
                    lblDeliveryAddress.title = '';
                    hid_DelAddressType.value = '';
                    lblDeliveryAddress.innerHTML = '';
                }
                else {
                    lblDeliveryAddress.title = SpecialDecode(Address1);
                    hid_DelAddressType.value = AddressType;
                    lblDeliveryAddress.innerHTML = SpecialDecode(Address_Limit);
                }
            }
        }
    }
    //AutoFill.GetIncoiceAddressDetails(CompID, ClientID, retInvAddrDetails)
    txtName.focus();

}

function retInvAddrDetails(val) {
    var InvAddrDetails = val.split('µ');

    hid_InvoiceAddressID.value = '0';
    hid_InvoiceAddressType.value = 'A';
    lblInvoiceAddress.innerHTML = '';
    hid_InvoiceAddressClientID.value = '0';

    if (val != '') {
        hid_InvoiceAddressID.value = InvAddrDetails[0].toString();
        hid_InvoiceAddressType.value = InvAddrDetails[1].toString();
        lblInvoiceAddress.innerHTML = SpecialDecode(InvAddrDetails[2].toString());
        hid_InvoiceAddressClientID.value = InvAddrDetails[3].toString();
    }
}

function GetSalesperson(clientid) {
    PageMethods.GetSalesPerson(CompID, clientid, Findsucc);
}

function GetInvoiceContact(clientid) {
    PageMethods.GetInvoiceContact(CompID, clientid, FindsuccIC);
}

function FindsuccIC(result) {
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
    if (result == 0) {
        result = UserID;
    }

    for (var i = 0; i < ddlSalesPerson.length; i++) {
        if (ddlSalesPerson.options[i].value == result) {
            ddlSalesPerson.selectedIndex = i;
        }
    }
}
function ReloadContact(FinalContact, deptID, DeptName, ContactAddressID, Address1, DeliveriAddressID, Address2, InvoiceAddressID, Address3, retContactID) {
    debugger;
    var ContactName = '';
    var ContactID = '';
    ddlcontact.length = 0;
    ddlinvoicecontact.length = 0;
    var str_con1 = FinalContact.split('µ');

    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = SpecialDecode(ContactIDName[1]);
            ddlcontact.options.add(new Option(ContactName, ContactID, k));
            ddlinvoicecontact.options.add(new Option(ContactName, ContactID, k));
            

        }
    }


    for (var j = 0; j < ddlcontact.length; j++) {
        if (retContactID == ddlcontact.options[j].value) {
            ddlcontact.selectedIndex = j;
        }

    }


    hdn_DepartmentID.value = deptID;
    txtCompany.value = SpecialEncode(DeptName);
    txtGreeting.value = "Dear";
    var firstname = ddlcontact.options[ddlcontact.selectedIndex].text;

    var Name = firstname.split(' ');
    txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(Name[0]);

    hdnAddressID.value = ContactAddressID;
    lblAddress.innerHTML = SpecialDecode(Address1);
    lblAddress.title = SpecialDecode(Address1);

    hid_DeliveryAddressID.value = DeliveriAddressID
    lblDeliveryAddress.innerHTML = SpecialDecode(Address2);
    lblDeliveryAddress.title = SpecialDecode(Address2);

    hdn_InvoiceAddressID.value = InvoiceAddressID;
    lblInvoiceAddress.innerHTML = SpecialDecode(Address3);
    lblInvoiceAddress.title = SpecialDecode(Address3);

    //GetContactID(ddlcontact.value);
}

function SendContactAddress(ContactAddressDetails, AddressID) {
    debugger;
    document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_lblAddress").innerHTML = ContactAddressDetails;
    hdnAddressID.value = AddressID;
    StoreTheEstimateStage1();
}
function GetContactID(ddlval) {
    debugger;
    hid_ContactID.value = ddlval;
    txtGreeting.value = "Dear";

    //PageMethods.GetContactAddress(CompID, ddlval, GetAddress); -- by 047
    AutoFill.GetContactAddress(CompID, ddlval, GetAddress);
    AutoFill.LoadDDLCostCentre(CompID, hid_ClientID.value, 0, ddlval, LoadCostCentre);
    AutoFill.GetInvoiceContact(CompID, ddlval, UpdateInvoiceContact);
    var first_iteration = true;
    for (var i = 0; i < ddlcontact.length; i++) {
        if (ddlcontact.options[i].value == ddlval) {
            debugger;
            //var firstname = ddlcontact.options[i].text.split(' ');
            //var firstname = ddlcontact.options[i].text;
            //txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(firstname[0]);
            //var firstname= GetContactFirstName(ddlval);
            //txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(firstname);
            if (first_iteration) {
                GetContactFirstName(ddlval);
                first_iteration = false;
            }
           

        }
    }


}
function UpdateInvoiceContact(result) {
    debugger
    if (result === true) {
        return;
    }

    ddlinvoicecontact.selectedIndex = ddlcontact.selectedIndex;
}

function GetContactFirstName(contactID) {
    debugger;
    var dataValue = { 'ContactID': contactID };
    var _url = "";
    if (Pgtype == "job") {
        _url = "job_add.aspx/GetContactFirstName";
    }
    else if (Pgtype == "invoice") {
        _url = "invoices_add.aspx/GetContactFirstName";
    }
    else {
        _url = "estimates_add.aspx/GetContactFirstName";
    }
    $.ajax({
        type: "POST",
        url: _url,
        data: JSON.stringify(dataValue),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            if (txtGreeting.value.includes(result.d)) {
                txtGreeting.value.replace(result.d, "");
            }
            if (!txtGreeting.value.includes(result.d)) {
                txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(result.d);
            }
            //firstname= result.d;
        }
    });
}





function GetAddress(result) {
    debugger;
    //alert(result);
    //hid_AddressType.value = 'C';
    //'C' -- contact Address, 'A'-- Mian Address
    //hid_DelAddressType.value = 'M';//'C' -- contact Address, 'A'-- Main Address
    hdnAddressID.value = 0;
    lblAddress.innerHTML = '';

    var Address = '';
    var add = result.split('±');
    for (var j = 0; j < add.length; j++) {

        var str = add[j].split('»');
        if (trim12(str[0]) == "DeptNo") {
            hdn_DepartmentID.value = str[1];
        }

        if (trim12(str[0]) == "DeptName") {
            txtCompany.value = SpecialDecode(str[1]);
        }
        else if (trim12(str[0]) == "ContactAddressID") {
            hdnAddressID.value = str[1];
        }
        else if (trim12(str[0]) == "ContactAddress") {
            lblAddress.innerHTML = SpecialDecode(str[1]);
            lblAddress.title = SpecialDecode(str[1]);
        }
        else if (trim12(str[0]) == "DeliveryAddressID") {
            hid_DeliveryAddressID.value = str[1];
        }
        else if (trim12(str[0]) == "DeliveryAddress") {
            lblDeliveryAddress.innerHTML = SpecialDecode(str[1]);
            lblDeliveryAddress.title = SpecialDecode(str[1]);
        }
        else if (trim12(str[0]) == "InvoiceAddressID") {
            hdn_InvoiceAddressID.value = str[1];
        }
        else if (trim12(str[0]) == "InvoiceAddress") {
            lblInvoiceAddress.innerHTML = SpecialDecode(str[1]);
            lblInvoiceAddress.title = SpecialDecode(str[1]);
        }
    }

}

function LoadCostCentre(CostCentreList) {
    debugger
    ddlcostcentre.length = 0;
    var costsplit = CostCentreList.split('~');
    if (costsplit != '') {
        var DefaultCostCentreID = '';
        var DefaultCostCentreName = '';
        var Defaultcost = costsplit[0].split('±');
        DefaultCostCentreID = Defaultcost[0];
        DefaultCostCentreName = SpecialDecode(Defaultcost[1]);
        var CostCentreID = '';
        var CostCentreName = '';
        ddlcostcentre.options.add(new Option(DefaultCostCentreName, DefaultCostCentreID, 0));

        ddlcostcentre.options.add(new Option('-----------------------------Other Cost Centre----------------------------------', 'Other Cost Centre', 1));
        ddlcostcentre.options[1].disabled = true;

        var strcost = costsplit[1].split('^');
        var count = 2;
        for (var c = 0; c < strcost.length; c++) {
            if (strcost[c] != '') {
                var CostCentreConCat = strcost[c].split('±');
                if (Number(CostCentreConCat[0]) != Number(DefaultCostCentreID)) {
                    CostCentreID = CostCentreConCat[0];
                    CostCentreName = SpecialDecode(CostCentreConCat[1]);
                    ddlcostcentre.options.add(new Option(CostCentreName, CostCentreID, count));
                    count = count + 1;
                }
            }
        }
        if (SelectedCostCentre != 0) {
            var a = ddlcostcentre;
            for (i = 0; i < a.length; i++) {
                if (a.options[i].value == SelectedCostCentre) {
                    a.selectedIndex = i;
                    break;
                    //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = SelectedCostCentre;
                }
                else {
                    ddlcostcentre.selectedIndex = 0;
                }
            }
        }
        else {
            ddlcostcentre.selectedIndex = 0;
            //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = document.getElementById("<%=ddlcostcentre.ClientID %>").options[document.getElementById("<%=ddlcostcentre.ClientID %>").selectedIndex].value;
        }
    }

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
    txtName.value = SpecialDecode(leftTrim(document.getElementById(divid).innerHTML));
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

function add_contact() {
    
    if (txtName.value == "") {
        ddlcontact.length = 0;
        ddlinvoicecontact.length = 0;
        //alert("Please select the customer to proceed...");
        alert(Customer_Select_Alert);
        return false;
    }
    else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
        //alert("Please select the customer to proceed...");
        alert(Customer_Select_Alert);
        return false;
    }
        //    else if (hid_CustName.value != txtCustomerName.value) {
        //        alert("Please select the customer to proceed...");
        //        return false;
        //    }
    else {
        if (req_type == "edit") {
            // PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value, '980', '500')
            window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value,null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            //PopupCenter(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type, '980', '500')
            window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value + "&IsAddMode=yes",null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
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
    lblAddress.title = SpecialDecode(tooltip);
    //lblAddress.innerHTML = trim12(values);
    lblAddress.style.cursor = "pointer";
    hdnAddressID.value = id;

    if (isdelivery.toLowerCase() == "true") {
        lblDeliveryAddress.title = SpecialDecode(tooltip);
        lblDeliveryAddress.innerHTML = SpecialDecode(trim12(values));
        lblDeliveryAddress.style.cursor = "pointer";
        hid_DeliveryAddressID.value = id;
        document.getElementById("spn_lblDeliveryAddress").style.display = "none";
    }
    //            if (lblAddress.innerHTML.length > substringsize) {
    //                lblAddress.innerHTML = trim12(lblAddress.innerHTML.substring(0, substringsize)) + "...";
    //            }
    // document.getElementById("spn_lblAddress").style.display = "none";
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
        hid_HeaderText.value = SpecialDecode(trim12(values));
        hid_HeaderID.value = id;
    }
    else if (phrasetype == 'Estimate Footer' || phrasetype == 'Invoice Footer' || phrasetype == 'Job Footer') {
        lblPhraseText = lblFooter;
        hid_FooterText.value = SpecialDecode(trim12(values));
        hid_FooterID.value = id;
    }
    lblPhraseText.title = SpecialDecode(tooltip);
    lblPhraseText.innerHTML = SpecialDecode(trim12(values));
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
        document.getElementById("divJobNumInfo").style.display = "none";
        document.getElementById("divEstiDateInfo").style.display = "block";
        document.getElementById("divProgressdOn").style.display = "none";
        document.getElementById("divSalesPerson").style.display = "block";
        document.getElementById("div_directjob").style.display = "block";
        div_artworkdelivery.style.display = "block";
    }
    else if (Pgtype == "invoice") {
        div_artworkdelivery.style.display = "none";
        document.getElementById("div_directjob").style.display = "none";
    }
    else {
        div_artworkdelivery.style.display = "block";
        // document.getElementById("div_directjob").style.display = "none";
    }

}
CheckPage();
function validateEstTitle(val) {
    if (val != '') {
        document.getElementById("spn_txtEstimateTitle").style.display = "none";
    }
}
function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype, typeOfAddress) {
    if (values.length != 0) {
        for (var i = 0; i < values.length; i++) {
            values = values.replace('<br/>', '');
            i++;
        }
    }

    if (typeOfAddress == 'deleveryaddress') {
        hid_DelAddressType.value = addresstype;
        lblDeliveryAddress.title = tooltip;
        lblDeliveryAddress.innerHTML = SpecialDecode(trim12(values));
        lblDeliveryAddress.style.cursor = "pointer";
        hid_DeliveryAddressID.value = id;
        document.getElementById("spn_lblDeliveryAddress").style.display = "none";
    }
    else if (typeOfAddress == 'contactAddress') {

        lblAddress.innerHTML = SpecialDecode(trim12(values));
        lblAddress.style.cursor = "pointer";
        hdnAddressID.value = id;
        hdn_ContactAddressID.value = id;
        lblAddress.title = SpecialDecode(tooltip);
        // document.getElementById("spn_lblAddress").style.display = "none";
    }

    else if (typeOfAddress == 'invoiceAddress') {
        lblInvoiceAddress.innerHTML = SpecialDecode(trim12(values));
        lblInvoiceAddress.style.cursor = "pointer";
        hdn_InvoiceAddressID.value = id;
        lblInvoiceAddress.title = SpecialDecode(tooltip);
        document.getElementById("spn_lblInvoiceAddress").style.display = "none";
    }

    //            if (lblDeliveryAddress.innerHTML.length > substringsize) 
    //            {
    //                lblDeliveryAddress.innerHTML = trim12(lblDeliveryAddress.innerHTML.substring(0, substringsize)) + "...";
    //            }

}
function SendDeptIDName(DeptID, DeptName, invAddressId, DelAddressID, InVAddress, DelAddress) {
    debugger;
    txtCompany.value = SpecialDecode(DeptName);
    hdn_DepartmentID.value = DeptID;

    lblDeliveryAddress.innerHTML = SpecialDecode(DelAddress);
    lblDeliveryAddress.title = SpecialDecode(DelAddress);
    lblDeliveryAddress.style.cursor = "pointer";
    hid_DeliveryAddressID.value = DelAddressID;

    lblInvoiceAddress.innerHTML = SpecialDecode(InVAddress);
    lblInvoiceAddress.style.cursor = "pointer";
    hdn_InvoiceAddressID.value = invAddressId;
    lblInvoiceAddress.title = SpecialDecode(InVAddress);
    AutoFill.LoadDDLCostCentre(CompID, hid_ClientID.value, DeptID, 0, LoadCostCentre);  //added by rakshith
}


var stage1_values = '';
function Stage1ToStage2() {
    var ShallIGo = true;
    stage1_values = '';
    ShallIGo = Stage1Validation(); ////VALIDATION CHECKING 
    if (dddesttype.selectedIndex == 0) {
        spn_Label3.style.display = "block";
        return false;
    }
    else {
        spn_Label3.style.display = "none";
    }
    if (ShallIGo) {
        StoreTheEstimateStage1();
        return true;
    }
    else {
        return false;
    }
}

function StoreTheEstimateStage1() {


    //  alert(hid_FooterText.value);

    var StoreSatge1 = '';
    StoreSatge1 += "CustomerID»" + hid_ClientID.value + '±';
    StoreSatge1 += "ContactID»" + ddlcontact.value + '±' + "Greeting»" + SpecialEncode(txtGreeting.value) + '±';

    StoreSatge1 += "Company»" + SpecialEncode(txtCompany.value) + '±' + "AddressID»" + hdnAddressID.value + '±'; // txtCompany.value= Department Name

    StoreSatge1 += "Header»" + SpecialDecode(hid_HeaderText.value) + '±' + "Footer»" + SpecialDecode(hid_FooterText.value) + '±';

    StoreSatge1 += "EstimateTitle»" + SpecialEncode(txtEstimateTitle.value) + '±' + "EstimateNumber»" + lblEstimateNumber.innerHTML + '±';
    StoreSatge1 += "OrderNumber»" + SpecialEncode(txtOrderNumber.value) + '±' + "StatusID»" + ddlStatus.value + '±';
    StoreSatge1 += "EstimateDate»" + txtEstimateDate.value + '±' + "ValidFor»" + txtValidFor.value + '±';
    StoreSatge1 += "DeliveryAddress»" + hid_DeliveryAddressID.value + '±' + "SalesPerson»" + ddlSalesPerson.value + '±';
    // estimator
    StoreSatge1 += "Estimator»" + ddlEstimator.value + '±';
    StoreSatge1 += "AddressType»" + hid_AddressType.value + '±' + "DeliveryAddressType»" + hid_DelAddressType.value + '±';
    StoreSatge1 += "ArtworkDate»" + txtEstimateartworkDate.value + '±' + "DeliveryDate»" + txtEstimatedeliveryDate.value + '±' + "CompletionDate»" + txtjobcompletiondate.value + '±';

    StoreSatge1 += "DepartmentID»" + hdn_DepartmentID.value + '±';
    StoreSatge1 += "InvoiceAddress»" + hdn_InvoiceAddressID.value + '±' + "InvoiceAddressID»" + hdn_InvoiceAddressID.value + '±';
    StoreSatge1 += "ContactAddress»" + SpecialEncode(lblAddress.innerHTML) + '±'; //+ "ContactAddressID»" + hdn_ContactAddressID.value + '±';
    if (ddlcostcentre.length != 0) {
        StoreSatge1 += "CostCentreID»" + ddlcostcentre.options[ddlcostcentre.selectedIndex].value + '±';  //added by rakshith
    }
    StoreSatge1 += "InvoiceContactId»" + ddlinvoicecontact.value + '±';
    StoreSatge1 += "CustomDate1»" + txtCustomDate1.value + '±';
    StoreSatge1 += "CustomDate2»" + txtCustomDate2.value + '±';
    StoreSatge1 += "CustomDate3»" + txtCustomDate3.value + '±';
    StoreSatge1 += "CustomDate4»" + txtCustomDate4.value + '±';
    StoreSatge1 += "CustomDate5»" + txtCustomDate5.value + '±';
    stage1_values = StoreSatge1; //stored

    ClientID = hid_ClientID.value;
    ClienName = customer_name.value;
    hid_Stage1_values.value = stage1_values;
}

function Stage1Validation() {
    
    var IsCorrect = true;
    if (CheckStringMandatory(txtCustomerName.value, 'spn_txtName')) {
        IsCorrect = false;
        //document.getElementById("spn_txtName").innerHTML = 'Please select Customer';
        document.getElementById("spn_txtName").innerHTML = Please_Select_Customer;
    }
    else {
        if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            IsCorrect = false;
            document.getElementById("spn_txtName").style.display = "block";
            //document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
            document.getElementById("spn_txtName").innerHTML = Please_select_valid_Customer;
        }
        //        else if (hid_CustName.value != txtCustomerName.value) {
        //            IsCorrect = false;
        //            document.getElementById("spn_txtName").style.display = "block";
        //            document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
        //        }
    }
    if (CheckStringMandatory(ddlcontact.value, 'spn_ddlcontact')) {
        IsCorrect = false;
    }
    //    if (CheckStringMandatory(lblAddress.innerHTML, 'spn_lblAddress')) {
    //        IsCorrect = false;
    //    }
    if (CheckStringMandatory(txtGreeting.value, 'spn_txtGreeting')) {
        IsCorrect = false;
    }
    //    if (CheckStringMandatory(txtCompany.value, 'spn_txtCompany')) {
    //        IsCorrect = false;
    //    }
    //            if (CheckStringMandatory(lblHeader.innerHTML, 'spn_lblHeader')) {
    //                IsCorrect = false;
    //            }
    //            if (CheckStringMandatory(lblFooter.innerHTML, 'spn_lblFooter')) {
    //                IsCorrect = false;
    //            }
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
    //            if (CheckStringMandatory(lblDeliveryAddress.innerHTML, 'spn_lblDeliveryAddress')) {
    //                IsCorrect = false;
    //            }
    if (ValidateForm(txtEstimateDate, 'spn_txtEstimateDate', DateFormat_stage) == false) {
        IsCorrect = false;
    }

    var url = window.location.href;
    
    if (url.indexOf("invoice/invoices_add") != -1) {
        if (txtInvoiceDueDate.value != "") {
            if (ValidateForm(txtInvoiceDueDate, 'spn_InvoiceDueDate', DateFormat_stage) == false) {
                IsCorrect = false;
            }
        }
        if (CheckStringMandatory(txtInvoiceDueDate.value, 'spn_InvoiceDueDateMandatory')) {
            IsCorrect = false;
        }
    }
    if (url.indexOf("invoice/invoices_add") == -1) {
        if (hdnStatusTitle.value.toLowerCase() == "account on hold" && url.indexOf("estimates/")>-1 ){
            //alert(AccoutnsOnHoldEstimate);
            alert(Accountsonhold);
            IsCorrect = false;
        }
        else if (hdnStatusTitle.value.toLowerCase() == "account on hold" && url.indexOf("jobs/")>-1)
        {
            //alert(AccoutnsOnHoldJob);
            alert(Accountsonhold);
            IsCorrect = false;
        }
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
function PopupAddress(val) {
    document.getElementById("divaddress").style.display = 'block';
    if (val == 'add') {
        document.getElementById("spnDelheader").innerHTML = "Address";
        document.getElementById("divCompany").style.display = "none";
        document.getElementById("divRef").style.display = "none";
        imgViewAddress.style.display = "block";
        staticbar('div_deladdress');
        showhideDDL('hide');
    }
    else if (val == 'deladd') {
        document.getElementById("spnDelheader").innerHTML = "Delivery Address";
        document.getElementById("divCompany").style.display = "block";
        document.getElementById("divRef").style.display = "block";
        imgViewAddress.style.display = "none";
        staticbar('div_deladdress');
        showhideDDL('hide');
    }
}

var select_ClientID = 0;
var isInvoiceAdddressSelected = 'no';

function more_address(addtype) {



    if (txtName.value == "") {
        //alert("Please select the customer to proceed...");
        alert(Customer_Select_Alert);
        return false;
    }
    else {
        if (addtype == "default") {
            // PopupCenter(strSitepath + "common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
            window.radopen(strSitepath + "common/common_popup.aspx?type=moreaddress&addresstype=contact&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes",null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "dept") {
            window.radopen(strSitepath + "common/common_popup.aspx?from=estimate&type=deptselect&mode=view&companytype=customer&clientid=" + hid_ClientID.value + "&pg=" + pg,null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "delivery") {
            //PopupCenter(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
            window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes",null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "invoicenew") {
            window.radopen(strSitepath + "common/common_popup.aspx?type=moreaddress&addresstype=invoice&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes",null, '1000', '530');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }


        else if (addtype == "invoice") {
            if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
                alert("Please select the supplier to proceed...");
                return false;
            }
            else {
                if (isInvoiceAdddressSelected == 'no') {
                    window.radopen(strSitepath + "common/DeliveryAddress.aspx?type=moreaddress&mode=view&CustomerID=" + hid_ClientID.value + "&pg=" + pg,null, '1000', '530');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                    return true;
                }
                else {
                    window.radopen(strSitepath + "common/DeliveryAddress.aspx?type=moreaddress&mode=view&CustomerID=" + select_ClientID + "&pg=" + pg,null, '1000', '530');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                    return true;
                }
            }
            return true;
        }
    }
}

function SendDeliveryAddressIDandName1(CompanyName, AddressID, Address, AddressType, ClientID) {
    isInvoiceAdddressSelected = 'yes';
    select_ClientID = ClientID;
    hid_InvoiceAddressID.value = AddressID;
    hid_InvoiceAddressType.value = AddressType;
    lblInvoiceAddress.innerHTML = SpecialDecode(trim12(Address));
    hid_InvoiceAddressClientID.value = ClientID;
}

function new_contact() {
    //PopupCenter(strSitepath + "common/common_popup.aspx?type=newcontact&mode=add&pg=" + pg, '800', '400')
    window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');

}
function popup_phrasebook(type) {
    // PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
    window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type,null, '1000', '530');
    SetRadWindow('divrad', 'divBackGroundNew', '200');

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
                document.getElementById("lblheader").innerHTML = SpecialDecode(stname);
            }
        }
    }
}
try {
    txtName.focus();
}
catch (err) {
}

function CallLoadCostCentre(CompID, ClientID, DepartmentID, selectedcentre) {
    debugger;
    if (selectedcentre != 0) {
        SelectedCostCentre = selectedcentre;
    }
    AutoFill.LoadDDLCostCentre(CompID, ClientID, DepartmentID, 0, LoadCostCentre);
}


