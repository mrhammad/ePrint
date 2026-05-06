
// JavaScript used for showing Loading Image wrt Blue tranparent screen
addFunction(window, 'load', setLoadingPosition);
addFunction(window, 'scroll', setLoadingPosition);


function addFunction(eventObject, eventFiresOn, eventFunction) {
    if (eventObject.addEventListener) eventObject.addEventListener(eventFiresOn, eventFunction, false); else if (eventObject.attachEvent) eventObject.attachEvent('on' + eventFiresOn, eventFunction);
}

function setLoadingPosition() {

    try {
        var DivLoading = document.getElementById("divLoading");

        var centerWidth = window.screen.width / 2;

        var DivLoading = document.getElementById("divLoading");
        var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
        DivLoading.style.left = (centerWidth - 70) + "px";
        DivLoading.style.zIndex = 102;
        var centerHeight = window.screen.height / 2;
        DivLoading.style.top = centerHeight - 165 + "px";

        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes

        var docheightcomplete = standardbody.offsetHeight;
        var docwidthcomplete = standardbody.scrollWidth;

        var DivBack = document.getElementById("divBackGround1");
        DivBack.style.left = "0px"
        DivBack.style.width = docwidthcomplete + "px";
        DivBack.style.height = docheightcomplete + "px";
        DivBack.style.top = top + "px";
    }
    catch (error) {

    }
}



//////////////////Multi select with shift key in check box functions
function CheckChanged(evt, obj, GridID) {
    //find the grid view id
    var mainControl = document.getElementById(GridID);
    //find the grid view id
    var frm = mainControl.getElementsByTagName("input");
    var boolAllChecked;
    boolAllChecked = true;

    var SelectedRowColor = '';

    for (i = 0; i < frm.length; i++) {
        e = frm[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
            if (e.checked == false) {
                boolAllChecked = false;
                break;
            }
        }
    }

    for (i = 0; i < frm.length; i++) {
        e = frm[i];
        if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
            if (boolAllChecked == false) {
                e.checked = false;
                break;
            }
            else {
                e.checked = true;
                break;
            }
        }
        else {
            e.checked = true;
            break;
        }
    }
    clickage(evt, obj, SelectedRowColor, GridID)
}

var oldInp = 0;
function clickage(evt, obj, SelectedRowColor, GridID) {
    var newInp = 0;
    evt = (evt) ? evt : event;
    var target = (evt.target) ? evt.target : evt.srcElement;
    var currentChkID = document.getElementById(obj.id);

    //find the grid view id
    var mainControl = document.getElementById(GridID);
    //find the grid view id
    var totalCheckBox = document.getElementsByTagName('input');

    //            if (currentChkID.checked) {
    //                obj.parentNode.parentNode.style.backgroundColor = SelectedRowColor;
    //            }
    //            else {
    //                obj.parentNode.parentNode.style.backgroundColor = '';
    //            }

    if (!evt.shiftKey) {
        for (n = 0; n < totalCheckBox.length; n++) {
            if (totalCheckBox[n].type == 'checkbox' && totalCheckBox[n].id.indexOf('Id')) {
                if (totalCheckBox[n].id == currentChkID.id) {
                    oldInp = n;
                }
            }
        }
        return false;
    }

    var flag = true;
    if (currentChkID.checked) {
        flag = false;
    }

    for (i = 0; i < totalCheckBox.length; i++) {
        if (totalCheckBox[i].type == 'checkbox' && totalCheckBox[i].id.indexOf('Id')) {
            if (totalCheckBox[i].id == currentChkID.id) {
                newInp = i;
            }
        }
    }

    for (j = 0; j < totalCheckBox.length; j++) {
        if (totalCheckBox[j].type == 'checkbox' && totalCheckBox[j].id.indexOf('Id')) {
            if ((j <= oldInp && j >= newInp) || (j <= newInp && j >= oldInp)) {
                if (flag) {
                    totalCheckBox[j].checked = false;
                    //  totalCheckBox[j].parentNode.parentNode.style.backgroundColor = '';
                }
                else {
                    totalCheckBox[j].checked = true;
                    //totalCheckBox[j].parentNode.parentNode.style.backgroundColor = SelectedRowColor;
                }
            }
        }
    }
    oldInp = newInp;
    return true;
}


var checktrue = false;
function checkall(tblid) {
    var tbl = document.getElementById(tblid);
    var tagcount = tbl.getElementsByTagName("input");
    for (var i = 0; i < tagcount.length; i++) {
        if (tagcount[i].type == 'checkbox') {
            if (tagcount[0].checked) {
                tagcount[i].checked = true;
                checktrue = true;
                document.getElementById("lnkpo").className = "normalText";
            }
            else {
                tagcount[i].checked = false;
                checktrue = false;
                document.getElementById("lnkpo").className = "disable";
                //document.getElementById("tblpo").style.display="none";
                document.getElementById("divmessage").style.display = "none";
            }
        }
    }
}