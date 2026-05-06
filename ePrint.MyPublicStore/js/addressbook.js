

function onclick_address(ID, type) {
    if (Rewritemodule.toLowerCase() == "on") {
        if (type.toLowerCase() == "billing") {
            window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultBillingID + KeySeparator + "add" + FileExtension;
        }
        else if (type.toLowerCase() == "shipping") {
            window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultShippingID + KeySeparator + "add" + FileExtension;
        }
        else if (type.toLowerCase() == "additional") {
            window.location = strSitepath + 'account/addressbooknew' + KeySeparator + ID + KeySeparator + "add" + FileExtension;
        }
    }
    else {
        if (type.toLowerCase() == "billing") {
            window.location = strSitepath + "account/addressbooknew" + FileExtension + "?ID=" + DefaultBillingID + "&type=add";
        }
        else if (type.toLowerCase() == "shipping") {
            window.location = strSitepath + "account/addressbooknew" + FileExtension + "?ID=" + DefaultShippingID + "&type=add";
        }
        else if (type.toLowerCase() == "additional") {
            window.location = strSitepath + "account/addressbooknew" + FileExtension + "?ID=" + ID + "&type=add";
        }
    }
}

function delete_address(ID) {
    AutoFill.Delete_Address(StoreUserID, ID, GetResult, onTimeout, onError);
}

function GetResult(result) {
    if (result == 1) {
        if (Rewritemodule.toLowerCase() == "on") {
            window.location = strSitepath + "account/addressbook" + FileExtension;
        }
        else {
            window.location = strSitepath + "account/addressbook.aspx";
        }
    }
}

function onTimeout(request, context) {
    //            alert(request + " request");
    //            alert(context + " context");
}
function onError(objError) {
    //            alert(objError + " objError");

}