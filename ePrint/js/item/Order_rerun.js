var SelectedCostCentre = 0;
function ClearStage1Data() {
    hid_CustName.value = "";
    txtName.value = "";
    txtCompany.value = "";
    hid_ClientID.value = 0;
    txtGreeting.value = "";
    ddlcontact.length = 0;
    lblAccountNumber.innerHTML = "";
    hdn_InvoiceAddressID.value = "";
}



function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID) {
  debugger
    ClearStage1Data();

    hid_CustName.value = SpecialDecode(ClientName);
    txtName.value =SpecialDecode(ClientName);
    if (DepartmentName != undefined) {
        txtCompany.value =SpecialDecode(DepartmentName); //ClientName;
    }
    hid_ClientID.value = ClientID;
    txtGreeting.value = "Dear";
    if (ContactAddress != undefined) {
        lblAddress.innerHTML =SpecialDecode(ContactAddress);
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
    var str_con1 = Contacts.split('^');


    //ddlcontact.options.add(new Option('--- Select ---',0,0));
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName =SpecialDecode(trim12(ContactIDName[1]));
            ISDefaultContact = ContactIDName[2];

            if (ISDefaultContact == "1") {
                DefaultConInd = k;
            }

            ddlcontact.options.add(new Option(ContactName, ContactID, k));
        }
    }
    ddlcontact.selectedIndex = DefaultConInd;


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
    lblAccountNumber.innerHTML =SpecialDecode(AccountNo);
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
                    lblDeliveryAddress.innerHTML =SpecialDecode(Address_Limit);
                }

                if (Contacts == "") {
                    lblDeliveryAddress.title = '';
                    hid_DelAddressType.value = '';
                    lblDeliveryAddress.innerHTML = '';
                }
                else {
                    lblDeliveryAddress.title =SpecialDecode(Address1);
                    hid_DelAddressType.value = AddressType;
                    lblDeliveryAddress.innerHTML =SpecialDecode(Address_Limit);
                }
            }
        }
    }
    //AutoFill.GetIncoiceAddressDetails(CompID, ClientID, retInvAddrDetails)
    txtName.focus();

}
function GetContactID(ddlval) {
    hid_ContactID.value = ddlval;
    txtGreeting.value = "Dear";

    //PageMethods.GetContactAddress(CompID, ddlval, GetAddress); -- by 047
    AutoFill.GetContactAddress(CompID, ddlval, GetAddress);
    AutoFill.LoadDDLCostCentre(CompID, hid_ClientID.value, 0, ddlval, LoadCostCentre);
    SelectedCostCentre = 0;
    for (var i = 0; i < ddlcontact.length; i++) {
        if (ddlcontact.options[i].value == ddlval) {
            var firstname = ddlcontact.options[i].text.split(' ');
            txtGreeting.value = txtGreeting.value + ' ' +SpecialDecode(firstname[0]);
        }
    }

    function LoadCostCentre(CostCentreList) {
        ddlcostcentre.length = 0;
        var costsplit = CostCentreList.split('~');
        if (costsplit != '') {
            var DefaultCostCentreID = '';
            var DefaultCostCentreName = '';
            var Defaultcost = costsplit[0].split('±');
            DefaultCostCentreID = Defaultcost[0];
            DefaultCostCentreName =SpecialDecode(Defaultcost[1]);
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
            if (SelectedCostCentre != Number(0)) {
                var a = ddlcostcentre;
                for (i = 0; i < a.length; i++) {
                    if (a.options[i].value == SelectedCostCentre) {
                        a.selectedIndex = i;
                        //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = SelectedCostCentre;
                      
                    }
                }
            }
            else {
                ddlcostcentre.selectedIndex = 0;
               // document.getElementById("<%=hdn_costcentreid.ClientID %>").value = DefaultCostCentreID;  
                //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = document.getElementById("<%=ddlcostcentre.ClientID %>").options[document.getElementById("<%=ddlcostcentre.ClientID %>").selectedIndex].value;
            }
        }

    }
}
function GetAddress(result) {
    //alert(result);
    //hid_AddressType.value = 'C';
    //'C' -- contact Address, 'A'-- Mian Address
    //hid_DelAddressType.value = 'M';//'C' -- contact Address, 'A'-- Main Address
    hdnAddressID.value = 0;
    hdn_ContactAddressID.value = 0;
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
            //hdnAddressID.value = str[1];
            hdn_ContactAddressID.value = str[1];
        }
        else if (trim12(str[0]) == "ContactAddress") {
            lblAddress.innerHTML =SpecialDecode(str[1]);
            lblAddress.title = SpecialDecode(str[1]);
        }
        else if (trim12(str[0]) == "DeliveryAddressID") {
            hid_DeliveryAddressID.value = str[1];
        }
        else if (trim12(str[0]) == "DeliveryAddress") {
            lblDeliveryAddress.innerHTML =SpecialDecode(str[1]);
            lblDeliveryAddress.title =SpecialDecode(str[1]);
        }
//        else if (trim12(str[0]) == "InvoiceAddressID") {
//            hdn_InvoiceAddressID.value = str[1];
//        }
        else if (trim12(str[0]) == "InvoiceAddress") {
            lblInvoiceAddress.innerHTML =SpecialDecode(str[1]);
            lblInvoiceAddress.title = SpecialDecode(str[1]);
        }
        else if (trim12(str[0]) == "ContactEmail") {
        if (str[1] != 0) {
            txtcontactemail.value = SpecialDecode(str[1]);
        }
        else {
            txtcontactemail.value = '';
        }

        }
        else if (trim12(str[0]) == "ContactPhone") {
        if (str[1] != 0) {
            txtcontactphone.value =SpecialDecode(str[1]);
        }
        else {
            txtcontactphone.value ='';
        }
        }

    }
}

function LoadCostCentre(CostCentreList) {
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
                    CostCentreName =SpecialDecode(CostCentreConCat[1]);
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
                    //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = SelectedCostCentre;
                }
            }
        }
        else {
            ddlcostcentre.selectedIndex = 0;
            hdn_costcentreid.value = DefaultCostCentreID;
            //document.getElementById("<%=hdn_costcentreid.ClientID %>").value = document.getElementById("<%=ddlcostcentre.ClientID %>").options[document.getElementById("<%=ddlcostcentre.ClientID %>").selectedIndex].value;
        }
    }

}
//********** End of web service to autocomplete clientname *********//

function GetSalesperson(clientid) {
    PageMethods.GetSalesPerson(CompID, clientid, Findsucc);
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

function ShowOff(divid) {
    document.getElementById(divid).style.display = "none";
    ddlcontact.style.display = "block";
}
//-----------------------------------------------
var select_ClientID = 0;
var isInvoiceAdddressSelected = 'no';

function more_address(addtype) {
   
    if (txtName.value == "") {
        alert("Please select the customer to proceed...");
        return false;
    }
    else {
        if (addtype == "default") {
            // PopupCenter(strSitepath + "common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
            window.radopen(strSitepath + "common/common_popup.aspx?type=moreaddress&addresstype=contact&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes", '700', '400');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "dept") {
            window.radopen(strSitepath + "common/common_popup.aspx?from=estimate&type=deptselect&mode=view&companytype=customer&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "delivery") {
            //PopupCenter(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400')
            window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes", '700', '400');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
        }
        else if (addtype == "invoicenew") {
            window.radopen(strSitepath + "common/common_popup.aspx?type=moreaddress&addresstype=invoice&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes", '700', '400');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
        }


        else if (addtype == "invoice") {
            if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
                alert("Please select the supplier to proceed...");
                return false;
            }
            else {
                if (isInvoiceAdddressSelected == 'no') {
                    window.radopen(strSitepath + "common/DeliveryAddress.aspx?type=moreaddress&mode=view&CustomerID=" + hid_ClientID.value + "&pg=" + pg, '700', '440');
                    SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
                    return true;
                }
                else {
                    window.radopen(strSitepath + "common/DeliveryAddress.aspx?type=moreaddress&mode=view&CustomerID=" + select_ClientID + "&pg=" + pg, '700', '440');
                    SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
                    return true;
                }
            }
            return true;
        }
    }
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
//---------------------------------------------------------
function SendDeliveryAddressIDandName1(CompanyName, AddressID, Address, AddressType, ClientID) {
    isInvoiceAdddressSelected = 'yes';
    select_ClientID = ClientID;
    hid_InvoiceAddressID.value = AddressID;
    hid_InvoiceAddressType.value = AddressType;
    lblInvoiceAddress.innerHTML =SpecialDecode(trim12(Address));
    hid_InvoiceAddressClientID.value = ClientID;
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
        lblDeliveryAddress.title = SpecialDecode(tooltip);
        lblDeliveryAddress.innerHTML =SpecialDecode(trim12(values));
        lblDeliveryAddress.style.cursor = "pointer";
        hid_DeliveryAddressID.value = id;
        document.getElementById("spn_lblDeliveryAddress").style.display = "none";
    }
    else if (typeOfAddress == 'contactAddress') {
        lblAddress.innerHTML =SpecialDecode(trim12(values));
        lblAddress.style.cursor = "pointer";
        hdnAddressID.value = id;
        hdn_ContactAddressID.value = id;
        lblAddress.title =SpecialDecode(tooltip);
        // document.getElementById("spn_lblAddress").style.display = "none";
    }

    else if (typeOfAddress == 'invoiceAddress') {
        lblInvoiceAddress.innerHTML =SpecialDecode(trim12(values));
        lblInvoiceAddress.style.cursor = "pointer";
        hdn_InvoiceAddressID.value = id;
        lblInvoiceAddress.title = SpecialDecode(tooltip);
        document.getElementById("spn_lblInvoiceAddress").style.display = "none";
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

function popup_phrasebook(type) {
    // PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
    window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');

}

function SendPhraseIDandName(id, values, phrasetype, tooltip) {
    var lblPhraseText = '';
    if (phrasetype == 'Estimate Header' || phrasetype == 'Invoice Header' || phrasetype == 'Job Header') {
        lblPhraseText =SpecialDecode(lblHeader);
        hid_HeaderText.value =SpecialDecode(trim12(values));
        hid_HeaderID.value = id;
    }
    else if (phrasetype == 'Estimate Footer' || phrasetype == 'Invoice Footer' || phrasetype == 'Job Footer') {
        lblPhraseText =SpecialDecode(lblFooter);
        hid_FooterText.value =SpecialDecode(trim12(values));
        hid_FooterID.value = id;
    }
    lblPhraseText.title = SpecialDecode(tooltip);
    lblPhraseText.innerHTML =SpecialDecode(trim12(values));
    lblPhraseText.style.cursor = "pointer";
 
    document.getElementById("spn_lblHeader").style.display = "none";
    document.getElementById("spn_lblFooter").style.display = "none";
}

function CallLoadCostCentre(CompID, ClientID, DepartmentID, selectedcentre) {
    if (selectedcentre != 0) {
        SelectedCostCentre = selectedcentre;
        hdn_costcentreid.value = selectedcentre;
    }
    AutoFill.LoadDDLCostCentre(CompID, ClientID, DepartmentID, 0, LoadCostCentre);
}


function SendDeptIDName(DeptID, DeptName, invAddressId, DelAddressID, InVAddress, DelAddress) {
    txtCompany.value =SpecialDecode(DeptName);
    hdn_DepartmentID.value = DeptID;

    lblDeliveryAddress.innerHTML =SpecialDecode(DelAddress);
    lblDeliveryAddress.title =SpecialDecode(DelAddress);
    lblDeliveryAddress.style.cursor = "pointer";
    hid_DeliveryAddressID.value = DelAddressID;

    lblInvoiceAddress.innerHTML =SpecialDecode(InVAddress);
    lblInvoiceAddress.style.cursor = "pointer";
    hdn_InvoiceAddressID.value = invAddressId;
    lblInvoiceAddress.title =SpecialDecode(InVAddress);
    AutoFill.LoadDDLCostCentre(CompID, hid_ClientID.value, DeptID, 0, LoadCostCentre);  //added by rakshith
}


function add_contact() {
    if (txtName.value == "") {
        ddlcontact.length = 0;
        alert("Please select the customer to proceed...");
        return false;
    }
    else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
        alert("Please select the customer to proceed...");
        return false;
    }
 
    else {
        if (req_type == "edit") {
            window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value, '980', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + req_type + "&id=" + hid_EstimateID.value + "&IsAddMode=yes", '980', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        return true;
    }
}
function ReloadContact(FinalContact, deptID, DeptName, ContactAddressID, Address1, DeliveriAddressID, Address2, InvoiceAddressID, Address3, retContactID) {

    var ContactName = '';
    var ContactID = '';
    ddlcontact.length = 0;
    var str_con1 = FinalContact.split('µ');
    
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = SpecialDecode(ContactIDName[1]);
            ddlcontact.options.add(new Option(ContactName, ContactID, k));

        }
    }
    for (var j = 0; j < ddlcontact.length; j++) {
        if (retContactID == ddlcontact.options[j].value) {
            ddlcontact.selectedIndex = j;
        }

    }

    hid_ContactID.value = retContactID;
    hdn_DepartmentID.value = deptID;
    txtCompany.value =SpecialDecode(DeptName);
    txtGreeting.value = "Dear";
    var firstname = ddlcontact.options[ddlcontact.selectedIndex].text;

    var Name = firstname.split(' ');
    txtGreeting.value = txtGreeting.value + ' ' + SpecialDecode(Name[0]);

    hdnAddressID.value = ContactAddressID;
    lblAddress.innerHTML =SpecialDecode(Address1);
    lblAddress.title =SpecialDecode(Address1);

    hid_DeliveryAddressID.value = DeliveriAddressID
    lblDeliveryAddress.innerHTML =SpecialDecode(Address2);
    lblDeliveryAddress.title =SpecialDecode(Address2);

    hdn_InvoiceAddressID.value = InvoiceAddressID;
    lblInvoiceAddress.innerHTML =SpecialDecode(Address3);
    lblInvoiceAddress.title =SpecialDecode(Address3);

    AutoFill.GetContactAddress(CompID, retContactID, GetEmailPhone);
    //GetContactID(ddlcontact.value);
}
function GetEmailPhone(details) {
    
          var add = details.split('±');
    for (var j = 0; j < add.length; j++) {

        var str = add[j].split('»');
      
         if (trim12(str[0]) == "ContactEmail") {
            if (str[1] != 0) {
                txtcontactemail.value =SpecialDecode(str[1]);
            }
            else {
                txtcontactemail.value = '';
            }

        }
        else if (trim12(str[0]) == "ContactPhone") {
            if (str[1] != 0) {
                txtcontactphone.value =SpecialDecode(str[1]);
            }
            else {
                txtcontactphone.value = '';
            }
        }

    }
}