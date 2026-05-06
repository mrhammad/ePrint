

function PageLoad() {
    // alert(chkEstimateArtwork);

    if (chkEstimateArtwork.checked == true) {
        txtDefaultEstimated.style.backgroundColor = "#FFFFFF";
        txtDefaultEstimated.readOnly = false;
        // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
    }
    else {
        txtDefaultEstimated.style.backgroundColor = "#F0F0F0";
        txtDefaultEstimated.style.cursor = "default";
        txtDefaultEstimated.readOnly = true;
    }

    if (chkEstimateProof.checked == true) {
        txtEstimateProof.style.backgroundColor = "#FFFFFF";
        txtEstimateProof.readOnly = false;
    }
    else {
        txtEstimateProof.style.backgroundColor = "#F0F0F0";
        txtEstimateProof.style.cursor = "default";
        txtEstimateProof.readOnly = true;
    }

    if (chkEstimateApproval.checked == true) {
        TxtEstimateApproval.style.backgroundColor = "#FFFFFF";
        TxtEstimateApproval.readOnly = false;
    }
    else {
        TxtEstimateApproval.style.backgroundColor = "#F0F0F0";
        TxtEstimateApproval.style.cursor = "default";
        TxtEstimateApproval.readOnly = true;
    }

    if (chkEstimateProduction.checked == true) {
        txtEstimateProduction.style.backgroundColor = "#FFFFFF";
        txtEstimateProduction.readOnly = false;
    }
    else {
        txtEstimateProduction.style.backgroundColor = "#F0F0F0";
        txtEstimateProduction.style.cursor = "default";
        txtEstimateProduction.readOnly = true;
    }

    if (chkEstimateCompletion.checked == true) {
        txtEstimatedCompletion.style.backgroundColor = "#FFFFFF";
        txtEstimatedCompletion.readOnly = false;
    }
    else {
        txtEstimatedCompletion.style.backgroundColor = "#F0F0F0";
        txtEstimatedCompletion.style.cursor = "default";
        txtEstimatedCompletion.readOnly = true;
    }

    if (chkEstimateDelivery.checked == true) {
        txtEstimateDelivery.style.backgroundColor = "#FFFFFF";
        txtEstimateDelivery.readOnly = false;
    }
    else {
        txtEstimateDelivery.style.backgroundColor = "#F0F0F0";
        txtEstimateDelivery.style.cursor = "default";
        txtEstimateDelivery.readOnly = true;
    }
    ddlSelection();
}

function enableDisable(bEnable, textBoxID) {
    var textboxclientid = document.getElementById(textBoxID);
    if (bEnable == true) {
        textboxclientid.style.backgroundColor = "#FFFFFF";
        //$(textboxclientid).attr("readonly", false);
        textboxclientid.readOnly = false;
    }
    else {
        textboxclientid.style.backgroundColor = "#F0F0F0";
        textboxclientid.style.cursor = "default";
        textboxclientid.readOnly = true;
    }
}

function ddlSelection() {
    var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlRoundoffnearest").value;
    var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_chkRoundLock");
    if (ddl == 0) {
        chkbox.disabled = true;
        chkbox.checked = false;
    }
    else {
        chkbox.disabled = false;
    }
}

//window.onload = PageLoad();
