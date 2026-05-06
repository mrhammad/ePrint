function AggignHiddenField() {

    var strTypeID = '';
    var strIDandSize = '';
    var dragableElementsParentBox = document.getElementById('dragableElementsParentBox');

    var inputs = dragableElementsParentBox.getElementsByTagName('input');
    var div = dragableElementsParentBox.getElementsByTagName('div');

    for (var i = 0; i < inputs.length; i++) {
        var TypeID = inputs[i].value;
        strTypeID = strTypeID + TypeID;
        strTypeID = strTypeID + 'μ';

    }
    for (var i = 0; i < div.length - 1; i++) {
        if (div[i].className == 'resizable') {
            strIDandSize += div[i].id + 'μ' + div[i].clientHeight + 'μ' + div[i].clientWidth + 'Ø';
        }
    }
    document.getElementById('ctl00_ContentPlaceHolder1_hdnIDs').value = strTypeID;
    document.getElementById('ctl00_ContentPlaceHolder1_hdnCustomHeigthWidth').value = strIDandSize;
}

//function SaveCustomizeOrder(CompanyID, IsRightBanner) {
//    var strTypeID = '';
//    var strIDandSize = '';
//    var dragableElementsParentBox = document.getElementById('dragableElementsParentBox');

//    var inputs = dragableElementsParentBox.getElementsByTagName('input');
//    var div = dragableElementsParentBox.getElementsByTagName('div');

//    for (var i = 0; i < inputs.length; i++) {
//        var TypeID = inputs[i].value;
//        strTypeID = strTypeID + TypeID;
//        strTypeID = strTypeID + 'μ';

//    }
//    for (var i = 0; i < div.length - 1; i++) {
//        if (div[i].className == 'resizable') {
//            strIDandSize += div[i].id + 'μ' + div[i].clientHeight + 'μ' + div[i].clientWidth + 'Ø';
//        }
//    }
//    document.getElementById('ctl00_ContentPlaceHolder1_hdnIDs').value = strTypeID;
//    document.getElementById('ctl00_ContentPlaceHolder1_hdnCustomHeigthWidth').value = strIDandSize;
//    //    if (strTypeID != "") {
//    //        CustomePage.ContentManagementWebService.UpdateCustomOrder(CompanyID, AccountID, IsRightBanner, strTypeID, strIDandSize);
//    //    }

//}


function SaveProductAndBannerList(CompanyID, AccountID, TypeID, Type, SelectedOrder) {
    CustomePage.ContentManagementWebService.SaveProductBannerListOrder(CompanyID, AccountID, TypeID, Type, SelectedOrder, CallBack, onTimeout, onError);
}

function CallBack(result, userContext, sender) {
    if (sender == 'SaveProductBannerListOrder') {
        var TypeID = result;
        if (TypeID > 0) {
            CustomePage.ContentManagementWebService.GetTemplateData(CompanyID, AccountID, Number(TypeID), CallBackGetTemplate);
        }
    }
}
function CallBackGetTemplate(CategoryDetails, userContext, sender) {

    if (sender == 'RemoveCategoryAndBanner') {

    }
    else {
        var count = Number($("#dragableElementsParentBox > div").size()) + Number(1);
        var content_Div = document.createElement("div");
        content_Div.id = 'dhtml_goodies_id' + count;
        content_Div.setAttribute("style", "width: auto;min-width:224; height:auto; padding-left: 1px;");
        content_Div.setAttribute("dragablebox", "true");
        content_Div.className = "dhtmlgoodies_window";
        content_Div.innerHTML = CategoryDetails;
        divMainPannel.appendChild(content_Div);
    }
}

function CallBackGetAllItems(strResult, userContext, sender) {
    var arrStringBuil = strResult.split('Ø');
    for (var j = 0; j < arrStringBuil.length - 1; j++) {
        var content_Div = document.createElement("div");
        content_Div.id = 'dhtml_goodies_id' + Number(j + 1);
        content_Div.setAttribute("style", "padding-left: 1px;");
        content_Div.setAttribute("dragablebox", "true");
        content_Div.className = "dhtmlgoodies_window";
        content_Div.innerHTML = arrStringBuil[j];
        divMainPannel.appendChild(content_Div);
    }
}

function onTimeout(request, context) {
    alert(request + " request");
    alert(context + " context");
}
function onError(objError) {
    alert(objError + " objError");
}

function GenerateImage(strCategoryArray) {

    var content_td = document.createElement("td");
    content_td.id = "content_td";
    content_td.innerHTML = strCategoryArray;
    divMainPannel.appendChild(content_td);
}



