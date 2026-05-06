function changeStyle(xobj, xStyle) {
    xobj.className = xStyle;
}

function RowMouseOver(sender, eventArgs) {
    $get(eventArgs.get_id()).className += " RowMouseOver";
}

function RowMouseOut(sender, eventArgs) {
    var row = $get(eventArgs.get_id());
    row.className = row.className.replace("RowMouseOver", "RowMouseOut");
}

// User Poll_Survey JScript
var oldCtrl = '0';
function pollControlSelect(ctrl) {
    displayNone();
    oldCtrl = ctrl;
    var objdiv = document.getElementById('div' + ctrl);
    $(objdiv).css('background-color', '#DFEFFF');

    var objdivHelp = document.getElementById('divHelpdesc' + ctrl);
    if (objdivHelp != null) {
        objdivHelp.style.display = 'block';
    }
}

function displayNone() {
    var objdiv = document.getElementById('div' + oldCtrl);
    $(objdiv).css('background-color', '#FFF');

    var objdivHelp = document.getElementById('divHelpdesc' + oldCtrl);
    if (objdivHelp != null) {
        objdivHelp.style.display = 'none';
    }
}
// End

// For Show/Hide Default Contain
function clearDefault(el) {
    if (el.defaultValue == el.value) {
        //el.value = "";
        el.select();
    }
}

function fillDefault(el, value) {
    if (el.value == "") {
        el.value = value;
    }
}
// End

// For Tab Menu Active
function tab_navigation(tabno) {
    switch (tabno) {
        case 1:
            {
                // alert(1);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = 'active';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 2:
            {
                //alert(2);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = 'active';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 3:
            {
                //alert(3);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 4:
            {
                //alert(4);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 5:
            {
                //alert(5);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 6:
            {
                //alert(6);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }

        case 7:
            {
                //alert(7);                
                parent.window.document.getElementById("ctl00_lihome").className = 'active';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }

        case 8:
            {
                //alert(8);
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }

        case 9:
            {
                //alert(9);                
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = 'active';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
        case 10:
            {
                //alert(10);                                                
                parent.window.document.getElementById("ctl00_lihome").className = '';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = 'active';
                }
                break;
            }

        default:
            {
                //alert(7);                
                parent.window.document.getElementById("ctl00_lihome").className = 'active';
                parent.window.document.getElementById("ctl00_liFrm").className = '';
                parent.window.document.getElementById("ctl00_liRpt").className = '';
                if (parent.window.document.getElementById("ctl00_liMeb") != null) {
                    parent.window.document.getElementById("ctl00_liMeb").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liUsr") != null) {
                    parent.window.document.getElementById("ctl00_liUsr").className = '';
                }
                if (parent.window.document.getElementById("ctl00_liSet") != null) {
                    parent.window.document.getElementById("ctl00_liSet").className = '';
                }
                if (parent.window.document.getElementById("ctl00_limap") != null) {
                    parent.window.document.getElementById("ctl00_limap").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lirolrs") != null) {
                    parent.window.document.getElementById("ctl00_lirolrs").className = '';
                }
                if (parent.window.document.getElementById("ctl00_licat") != null) {
                    parent.window.document.getElementById("ctl00_licat").className = '';
                }
                if (parent.window.document.getElementById("ctl00_lidashsett") != null) {
                    parent.window.document.getElementById("ctl00_lidashsett").className = '';
                }
                break;
            }
    }
    return false;
}
// End

// Heightlight Setting Tabs
function tab_highlight_settings(tabno, innertab) {
    if (tabno == 5 && innertab == 1) {
        parent.window.document.getElementById("ctl00_lihome").className = '';
        parent.window.document.getElementById("ctl00_liFrm").className = '';
        parent.window.document.getElementById("ctl00_liRpt").className = '';
        parent.window.document.getElementById("ctl00_liMeb").className = '';
        parent.window.document.getElementById("ctl00_liUsr").className = 'activeSubmenu';
        parent.window.document.getElementById("ctl00_liSet").className = 'active';
        parent.window.document.getElementById("ctl00_limap").className = '';
        parent.window.document.getElementById("ctl00_lirolrs").className = '';
        parent.window.document.getElementById("ctl00_licat").className = '';
        parent.window.document.getElementById("ctl00_lidashsett").className = '';
    }
    else if (tabno == 5 && innertab == 2) {
        parent.window.document.getElementById("ctl00_lihome").className = '';
        parent.window.document.getElementById("ctl00_liFrm").className = '';
        parent.window.document.getElementById("ctl00_liRpt").className = '';
        parent.window.document.getElementById("ctl00_liMeb").className = '';
        parent.window.document.getElementById("ctl00_liUsr").className = '';
        parent.window.document.getElementById("ctl00_liSet").className = 'active';
        parent.window.document.getElementById("ctl00_limap").className = '';
        parent.window.document.getElementById("ctl00_lirolrs").className = 'activeSubmenu';
        parent.window.document.getElementById("ctl00_licat").className = '';
        parent.window.document.getElementById("ctl00_lidashsett").className = '';
    }
    else if (tabno == 5 && innertab == 3) {
        parent.window.document.getElementById("ctl00_lihome").className = '';
        parent.window.document.getElementById("ctl00_liFrm").className = '';
        parent.window.document.getElementById("ctl00_liRpt").className = '';
        parent.window.document.getElementById("ctl00_liMeb").className = '';
        parent.window.document.getElementById("ctl00_liUsr").className = '';
        parent.window.document.getElementById("ctl00_liSet").className = 'active';
        parent.window.document.getElementById("ctl00_limap").className = 'activeSubmenu';
        parent.window.document.getElementById("ctl00_lirolrs").className = '';
        parent.window.document.getElementById("ctl00_licat").className = '';
        parent.window.document.getElementById("ctl00_lidashsett").className = '';
    }
    else if (tabno == 5 && innertab == 4) {
        parent.window.document.getElementById("ctl00_lihome").className = '';
        parent.window.document.getElementById("ctl00_liFrm").className = '';
        parent.window.document.getElementById("ctl00_liRpt").className = '';
        parent.window.document.getElementById("ctl00_liMeb").className = '';
        parent.window.document.getElementById("ctl00_liUsr").className = '';
        parent.window.document.getElementById("ctl00_liSet").className = 'active';
        parent.window.document.getElementById("ctl00_limap").className = '';
        parent.window.document.getElementById("ctl00_lirolrs").className = '';
        parent.window.document.getElementById("ctl00_licat").className = 'activeSubmenu';
        parent.window.document.getElementById("ctl00_lidashsett").className = '';
    }
    else if (tabno == 5 && innertab == 5) {
        parent.window.document.getElementById("ctl00_lihome").className = '';
        parent.window.document.getElementById("ctl00_liFrm").className = '';
        parent.window.document.getElementById("ctl00_liRpt").className = '';
        parent.window.document.getElementById("ctl00_liMeb").className = '';
        parent.window.document.getElementById("ctl00_liUsr").className = '';
        parent.window.document.getElementById("ctl00_liSet").className = 'active';
        parent.window.document.getElementById("ctl00_limap").className = '';
        parent.window.document.getElementById("ctl00_lirolrs").className = '';
        parent.window.document.getElementById("ctl00_licat").className = '';
        parent.window.document.getElementById("ctl00_lidashsett").className = 'activeSubmenu';
    }
    return false;
}
// End

// For Store Likert Control Values in DB
var oldRow = '0';
var rowValue = '';
var resultValue = '';
var statement = '';
var oldCustomizeID = '';
function storeLikertValue(ctrl, customizeId, rowid, lblStat) {
    if (oldCustomizeID != customizeId) {
        oldCustomizeID = customizeId;
        rowValue = '';
        resultValue = '';
        statement = '';
        oldRow = '0';
    }

    var likertValues = document.getElementById('likert_' + customizeId);
    var txtValidateValues = document.getElementById('txtValidateLikert_' + customizeId);

    var hdnLikert = document.getElementById('hdnLikert' + customizeId);
    var tblLikert = document.getElementById('tblLikert' + customizeId);
    var value = ctrl.getAttribute('value');
    var rdname = ctrl.getAttribute('name');
    var count = rdname.substring(5, rdname.length);

    if (oldRow == '0') {
        oldRow = rowid;
    }
    //alert(oldRow + '~~~' + count);
    if (oldRow == count) {
        hdnLikert.setAttribute('value', value);
        statement = lblStat.innerHTML;
    }
    else {
        if (rowid > oldRow) {
            resultValue += statement + '^' + hdnLikert.value + 'µ';
            hdnLikert.setAttribute('value', value);
            statement = lblStat.innerHTML;
            oldRow = rowid;
        }
        else {
            hdnLikert.setAttribute('value', value);
            statement = lblStat.innerHTML;
            var str1 = resultValue.split('µ');
            for (var i = 0; i < str1.length; i++) {
                var str2 = str1[i].split('^');
                for (var j = 0; j < str2.length; j++) {
                    if (str2[j] == statement) {
                        resultValue = resultValue.replace(str1[i], statement + '^' + hdnLikert.value);
                    }
                }
            }
        }
    }
    if (rowid == tblLikert.rows.length - 1) {
        rowValue = lblStat.innerHTML + '^' + hdnLikert.value;
    }
    //alert(resultValue + rowValue);
    var finalValue = resultValue + rowValue;
    if (rowValue != '') {
        likertValues.setAttribute('value', finalValue.split("'").join("`"));
        //alert(finalValue.split("'").join("`"));
        txtValidateValues.value = finalValue.split("'").join("`");
    }
}
// End