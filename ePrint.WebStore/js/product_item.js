
function onNodeCollapsed(sender, args) {
    $find("ctl00_ContentPlaceHolder1_RadAjaxManager1").ajaxRequest();
}


function Onclick_ProductNew(CID, ID, Name) {
    var btnSave = 'div_btnsave' + ID;
    var btnProcesImg = 'div_btnsaveprocess' + ID;

    loadingimg(btnSave, btnProcesImg);
    window.location = strSitePath + "products/productdetails.aspx?ID=" + ID + "&type=0&CID=" + CID;
}
//doubt
function Onclick_My_product(PriceCatalogueCategoryID) {

    window.location = strSitepath + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
}

function getscreenresolution() {

    var screenwidth = screen.width;
    if (center_div.offsetWidth >= 500 && center_div.offsetWidth < 780) {
        var paddinglefttoremove = Math.round((center_div.offsetWidth - 520) / 2); // two category tile in row )
        var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
        setdivattributes(center_div, actualwidth, paddinglefttoremove);
    }
    // for custom category product's in productpage
    if (center_div.offsetWidth >= 780 && center_div.offsetWidth < 1040) {
        var paddinglefttoremove = Math.round((center_div.offsetWidth - 780) / 2); // three category tile in row )
        var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
        setdivattributes(center_div, actualwidth, paddinglefttoremove);

    }
    else if ((center_div.offsetWidth >= 1040) && (center_div.offsetWidth < 1300)) {
        var paddinglefttoremove = Math.round((center_div.offsetWidth - 1040) / 2); // four category tile in row )
        var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
        setdivattributes(center_div, actualwidth, paddinglefttoremove);

    }

    else if (center_div.offsetWidth >= 1300 && center_div.offsetWidth < 1560) {
        var paddinglefttoremove = Math.round((center_div.offsetWidth - 1300) / 2); // five category tile in row( 1 tile=lm12+w220+rm12=244 )
        var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
        setdivattributes(center_div, actualwidth, paddinglefttoremove);

    }

    else if (center_div.offsetWidth > 1560) {
        var paddinglefttoremove = Math.round((center_div.offsetWidth - 1560) / 2); // six category tile in row )
        var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
        setdivattributes(center_div, actualwidth, paddinglefttoremove);
    }
}

function setdivattributes(divid, actualwidth, paddinglefttoremove) {
    divid.style.width = actualwidth + "px";
    divid.style.paddingLeft = paddinglefttoremove + "px";
}

getscreenresolution();

function setHeight() {
    document.getElementById('ctl00_ContentPlaceHolder1_hdnMashDivHeight').value = document.getElementById("contents").offsetHeight + "px";
    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
}

function GetDetails_Edit() {
    var hdnCampaignSelectedValue = document.getElementById("ctl00_ContentPlaceHolder1_hdnCampaignSelectedValue");
    var ddlCamapign = document.getElementById("ctl00_ContentPlaceHolder1_ddlCampaign");

    for (var i = 1; i < ddlCamapign.length; i++) {
        if (ddlCamapign.options[i].value == hdnCampaignSelectedValue.value) {
            ddlCamapign.selectedIndex = i;
        }
    }

    if (IsCumulative == "true") {
        document.getElementById("ctl00_ContentPlaceHolder1_txt_Cumulative_PriceQty").value = hid_Quantity_Edit.value;
    } else {
        document.getElementById("txtqty").value = hid_Quantity_Edit.value;
    }
    if (hid_matixType.value == "G") {
        txtHeight.value = hdn_height.value;
        txtWidth.value = hdn_width.value;
        txtHeight.focus();
        txtWidth.focus();
        document.getElementById("txtqty").focus();
    }
    Tocalculate_totalPrice(hid_Quantity_Edit.value, '0');
    document.getElementById("lbltotal").value = hid_totalPrice_Edit.value;
}

function BackTo() {
    document.getElementById("ctl00_ContentPlaceHolder1_pnlNormalDetails").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_pnlConfirmPRFile").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_btn_ConfirmAdd1").style.display = "none";
}
//doubt
function Animate2id(id, ease) { //the id to animate, the easing type

    var animSpeed = 2000; //set animation speed
    var $container = $("#container"); //define the container to move
    if (ease) { //check if ease variable is set
        var easeType = ease;
    } else {
        var easeType = "easeOutQuart"; //set default easing type
    }
    //do the animation
    $container.stop().animate({ "left": -($(id).position().left) }, animSpeed, easeType);
    $('body,html').css('overflow-x', 'hidden');
    $(window).scrollTop();
    $('body,html').scrollTop(10);
}

function AnimateBack(id, ease) { //the id to animate, the easing type

    var animSpeed = 2000; //set animation speed
    var $container = $("#container"); //define the container to move
    if (ease) { //check if ease variable is set
        var easeType = ease;
    } else {
        var easeType = "easeOutQuart"; //set default easing type
    }
    //do the animation
    $container.stop().animate({ left: "0px" }, 2000, "easeOutQuart");
    $('body,html').css('overflow-x', 'hidden');
}
$('body,html').css('overflow-x', 'hidden');

function CallConfirmrEdit() {
    Save_toCart('no', 'div_btnsave2', 'div_btnsaveprocess');
    __doPostBack('ctl00$ContentPlaceHolder1$btn_ConfirmEditTemplate', '');
}

function CallNormalSave() {
    Save_toCart('no', 'div_btnsave', 'div_btnsaveprocess');
    __doPostBack('ctl00$ContentPlaceHolder1$btn_ConfirmAdd', '');
}


function Onclick_Product(ID, Name) {
    var btnSave = 'div_btnsave' + ID;
    var btnProcesImg = 'div_btnsaveprocess' + ID;

    loadingimg(btnSave, btnProcesImg);
    window.location = strSitepath + "products/productdetails.aspx?ID=" + ID + "&type=1";
}

function Onclick_My_product(PriceCatalogueCategoryID) {

    window.location = strSitepath + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
}



// for enhancement id : 2575
function dispCustCodeandItemcode() {
    if (isCustomerCode.toLowerCase() == 'true') {
        divCustCode.style.display = "block";
    }
    else {
        divCustCode.style.display = "none";
    }
    if (isItemCode.toLowerCase() == 'true') {
        divItemCode.style.display = "block";
    }
    else {
        divItemCode.style.display = "none";
    }

}



//********************************************************************for development id 3952  ************************************************************************


function mouseovershow(pid) {
    var divid = document.getElementById("divQuickAdd" + pid);
    if (divid != null && divid != undefined) {
        showThisDiv(divid);
    }
}


function mouseOutHidediv(pid) {
    var divid = document.getElementById("divQuickAdd" + pid);
    if (divid != null && divid != undefined) {
        HideThisDiv(divid);
    }

}

function showThisDiv(id) {
    id.style.display = "block";
}

function HideThisDiv(id) {
    id.style.display = "none";
}

var P_Type;
var Dimensn1;

function QuickAddItemCart(PriceCatelogueID, ProductType, ChangedProductID) {
    debugger;
    var btnQucikAddCart = document.getElementById("btnQucikAddCart" + PriceCatelogueID);
    btnQucikAddCart.style.display = 'none';

    var btnQucikAddCartLoading = document.getElementById("btnQucikAddCartLoading" + PriceCatelogueID);
    btnQucikAddCartLoading.style.display = "block";
    var hdnDrawStockFrom = document.getElementById("hdndrawstockfrom" + PriceCatelogueID);
    var hdnIsStockItem = document.getElementById("hdnisstockitem" + PriceCatelogueID);
    var hdnIsCumulative = document.getElementById("hdn_IsCumulative_" + PriceCatelogueID);
    var hdnSoldInPacks = document.getElementById("hdn_SoldInPacks_" + PriceCatelogueID);
    if (hdnSoldInPacks != null && hdnSoldInPacks != undefined && hdnSoldInPacks.value != 0) {
        SoldInPacksOf = hdnSoldInPacks.value;
    } else {
        SoldInPacksOf = 1;
    }

    if (hdnDrawStockFrom != null && hdnDrawStockFrom != undefined && hdnDrawStockFrom.value.toLowerCase().trim() == "x" &&
        hdnIsStockItem != null && hdnIsStockItem != undefined && hdnIsStockItem.value.toLowerCase().trim() == "true") {
        //alert(modulename.toLowerCase());
        btnQucikAddCartLoading.style.display = 'none';
        btnQucikAddCart.style.display = 'block';
        alert("This product can not currently be ordered. Please contact the system administrator and ask them to check the stock settings");
        return false;
    }
    else {
        btnQucikAddCart.style.display = 'none';
        btnQucikAddCartLoading.style.display = 'block';
        var QtySelectedProduct = 0;
        if (ProductType == "p") {
            var QtyPriceBand = document.getElementById("txtPriceBandQty" + PriceCatelogueID);
            var hdn_ProductStockManagement = document.getElementById("hdn_ProductStockManagement");
            if (QtyPriceBand != null && QtyPriceBand != undefined && QtyPriceBand.value != "" && QtyPriceBand.value != "Qty" && QtyPriceBand.value != "0") {
                var PBQty = QtyPriceBand.value;
                if (!(PBQty % SoldInPacksOf == 0)) {
                    alert("Please enter quantity in the multiples of " + SoldInPacksOf + "");
                    QtyPriceBand.value = "";
                    QtyPriceBand.focus();
                    hideLoading(PriceCatelogueID);
                    return false;
                } else {
                    // validate the input qty for price band type
                    var IsValid = IsNumeric(QtyPriceBand.value);
                    if (IsValid == true) {
                        QtySelectedProduct = parseInt(QtyPriceBand.value);
                        //if (hdn_ProductStockManagement.value == "true") {// check only if stockmanagement id enabled 
                        var returntype = stockvalidation(PriceCatelogueID, QtySelectedProduct); // stock validation for product type priceband
                        if (returntype == false) {
                            hideLoading(PriceCatelogueID);
                            return false;
                        }
                        //}
                    }
                }
            }
            else {
                alert(ValidQty);
                QtyPriceBand.value = "";
                QtyPriceBand.focus();
                hideLoading(PriceCatelogueID);
                return false;
            }
        }
        if (ProductType == "g") {
            var QtyPriceBand = document.getElementById("txtPriceBandQty" + PriceCatelogueID);

            var txtHeight = document.getElementById("txtHeight" + PriceCatelogueID);
            var txtWidth = document.getElementById("txtWidth" + PriceCatelogueID);

            var hdn_ProductStockManagement = document.getElementById("hdn_ProductStockManagement");
            if (QtyPriceBand != null && QtyPriceBand != undefined && QtyPriceBand.value != "" && QtyPriceBand.value != "Qty" && QtyPriceBand.value != "0") {
                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0 || txtHeight.value == HeightText || txtWidth.value == WidthText) {
                    alert(ValidWidthAndHeight);
                    hideLoading(PriceCatelogueID);
                    return false;
                }
                else {
                    // validate the input Dimension for Signage Matrix type
                    var IsValid = IsNumeric(QtyPriceBand.value);
                    if (IsValid == true) {
                        QtySelectedProduct = parseInt(QtyPriceBand.value);
                        //if (hdn_ProductStockManagement.value == "true") {
                        P_Type = ProductType;
                        if (MeasurementValue == 'In.') {
                            Dimensn1 = Number(QtyPriceBand.value) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                        }
                        else {
                            Dimensn1 = Number(QtyPriceBand.value) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                        }
                        var returntype = stockvalidation(PriceCatelogueID, QtySelectedProduct); // stock validation for product type Signage Matrix
                        if (returntype == false) {
                            hideLoading(PriceCatelogueID);
                            return false;
                        }
                        //}
                    }
                }
            }
            else {
                alert(ValidQty);
                QtyPriceBand.value = "";
                QtyPriceBand.focus();
                hideLoading(PriceCatelogueID);
                return false;
            }
        }
        if (ProductType == "s") {
            if (hdnIsCumulative != null && hdnIsCumulative != undefined && hdnIsCumulative.value.toLowerCase() == "true") {
                var SM_CumulativePrice_Qty = document.getElementById("txt_Cumulative_PriceQty" + PriceCatelogueID);
                var hdn_ProductStockManagement = document.getElementById("hdn_ProductStockManagement");
                if (SM_CumulativePrice_Qty != null && SM_CumulativePrice_Qty != undefined && SM_CumulativePrice_Qty.value != "" && SM_CumulativePrice_Qty.value != "Qty" && SM_CumulativePrice_Qty.value != "0") {
                    var CumulativeQty = SM_CumulativePrice_Qty.value;
                    if (!(CumulativeQty % SoldInPacksOf == 0)) {
                        alert("Please enter quantity in the multiples of " + SoldInPacksOf + "");
                        SM_CumulativePrice_Qty.value = "";
                        SM_CumulativePrice_Qty.focus();
                        hideLoading(PriceCatelogueID);
                        return false;
                    } else {
                        // validate the input qty for SimpleMatrix CumulativePrice type
                        var IsValid = IsNumeric(SM_CumulativePrice_Qty.value);
                        if (IsValid == true) {
                            QtySelectedProduct = parseInt(SM_CumulativePrice_Qty.value);
                            //if (hdn_ProductStockManagement.value == "true") {// check only if stockmanagement id enabled 
                            var returntype = stockvalidation(PriceCatelogueID, QtySelectedProduct); // stock validation for product type priceband
                            if (returntype == false) {
                                hideLoading(PriceCatelogueID);
                                return false;
                            }
                            //}
                        }
                    }
                }
                else {
                    alert(ValidQty);
                    SM_CumulativePrice_Qty.value = "";
                    SM_CumulativePrice_Qty.focus();
                    hideLoading(PriceCatelogueID);
                    return false;
                }
            } else {
                var ddlPriceQty = document.getElementById("ddlPriceQty" + PriceCatelogueID);
                if (ddlPriceQty != null && ddlPriceQty != undefined) {
                    QtySelectedProduct = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }
            }
        }

        var hid_CostExcMarkupList = document.getElementById("hid_CostExcMarkupList" + PriceCatelogueID);
        var hid_priceList = document.getElementById("hid_priceList" + PriceCatelogueID);
        var hdn_qtyFromList = document.getElementById("hdn_qtyFromList" + PriceCatelogueID);
        var hid_qtyToList = document.getElementById("hid_qtyToList" + PriceCatelogueID);
        var hid_MarkupList = document.getElementById("hid_MarkupList" + PriceCatelogueID);

        var arrCost = hid_CostExcMarkupList.value.split('µ');
        var arrPrice = hid_priceList.value.split('µ');
        var arrQtyFrom = hdn_qtyFromList.value.split('µ');
        var arrQtyTo = hid_qtyToList.value.split('µ');
        var arrMarkup = hid_MarkupList.value.split('µ');

        TempSubTotal = 0;

        var QuantityPriceExcMarkup = 0;
        var QuantityPrice = 0;

        var IsCumulativeQtyForUnitPrice = 0;

        for (var i = 0; i < arrQtyFrom.length - 1; i++) {
            if (ProductType == "p") {
                // for price band type price 
                if (QtySelectedProduct != '' && Number(QtySelectedProduct)) {
                    if (Number(QtySelectedProduct) <= Number(arrQtyFrom[i])) {
                        QuantityPriceExcMarkup = Number(QtySelectedProduct) * Number(arrCost[i]);
                        var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                        //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                        QuantityPrice = ActualPrice;
                        break;
                    }
                    else if (Number(QtySelectedProduct) >= Number(arrQtyFrom[i]) && Number(QtySelectedProduct) <= Number(arrQtyTo[i])) {
                        QuantityPriceExcMarkup = Number(QtySelectedProduct) * Number(arrCost[i]);
                        var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                        //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                        QuantityPrice = ActualPrice;
                        break;
                    }
                    else if (Number(QtySelectedProduct) > Number(arrQtyTo[i]) && Number(QtySelectedProduct) < Number(arrQtyFrom[i + 1])) {
                        QuantityPriceExcMarkup = Number(QtySelectedProduct) * Number(arrCost[i]);
                        var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                        //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                        QuantityPrice = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            QuantityPriceExcMarkup = Number(QtySelectedProduct) * Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                            QuantityPrice = ActualPrice;
                            break;
                        }
                        else {
                            QuantityPriceExcMarkup = "0";
                            QuantityPrice = "0";
                        }
                    }
                }
                else {

                    QuantityPrice = "0";
                    QuantityPriceExcMarkup = "0";
                }
            }
            else if (ProductType == "g") {// for signage matrix type price 
                if (QtySelectedProduct != '' && Number(QtySelectedProduct)) {

                    var txtHeight1 = document.getElementById("txtHeight" + PriceCatelogueID);
                    var txtWidth1 = document.getElementById("txtWidth" + PriceCatelogueID);

                    if (txtHeight1.value == "" || Number(txtHeight1.value) == 0 || txtWidth1.value == "" || Number(txtWidth1.value) == 0 || txtHeight1.value == HeightText || txtWidth1.value == WidthText) {
                        alert(ValidWidthAndHeight);
                        hideLoading(PriceCatelogueID);
                        return false;
                    }
                    else {
                        var Dimensn = 0;
                        if (MeasurementValue == 'In.') {
                            Dimensn = Number(QtySelectedProduct) * ((Number(txtHeight1.value) * Number(txtWidth1.value)) / 144);
                        }
                        else {
                            Dimensn = Number(QtySelectedProduct) * ((Number(txtHeight1.value) * Number(txtWidth1.value)) / 1000000);
                        }

                        if (Number(Dimensn) <= Number(arrQtyFrom[i])) {
                            QuantityPriceExcMarkup = Number(Dimensn) * Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                            QuantityPrice = ActualPrice;
                            break;
                        }
                        else if (Number(Dimensn) >= Number(arrQtyFrom[i]) && Number(Dimensn) <= Number(arrQtyTo[i])) {
                            QuantityPriceExcMarkup = Number(Dimensn) * Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                            QuantityPrice = ActualPrice;
                            break;
                        }
                        else if (Number(Dimensn) > Number(arrQtyTo[i]) && Number(Dimensn) < Number(arrQtyFrom[i + 1])) {
                            QuantityPriceExcMarkup = Number(Dimensn) * Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                            QuantityPrice = ActualPrice;
                            break;
                        }
                        else {
                            if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                                QuantityPriceExcMarkup = Number(Dimensn) * Number(arrCost[i]);
                                var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                                //QuantityPrice = Number(QtySelectedProduct) * Number(arrPrice[i]);
                                QuantityPrice = ActualPrice;
                                break;
                            }
                            else {
                                QuantityPriceExcMarkup = "0";
                                QuantityPrice = "0";
                            }
                        }
                    }
                }
                else {

                    QuantityPrice = "0";
                    QuantityPriceExcMarkup = "0";
                }
            }
            else {
                // for simplematrix type price 
                if (hdnIsCumulative.value.toLowerCase() == "true") {

                    if (QtySelectedProduct != '' && Number(QtySelectedProduct)) {
                        if (Number(QtySelectedProduct) <= Number(arrQtyFrom[i])) {
                            QuantityPriceExcMarkup = Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            QuantityPrice = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i]);
                            break;
                        }
                        else if (Number(QtySelectedProduct) >= Number(arrQtyFrom[i]) && Number(QtySelectedProduct) <= Number(arrQtyTo[i])) {
                            QuantityPriceExcMarkup = Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            QuantityPrice = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                            break;
                        }
                        else if (Number(QtySelectedProduct) > Number(arrQtyTo[i]) && Number(QtySelectedProduct) < Number(arrQtyFrom[i + 1])) {
                            QuantityPriceExcMarkup = Number(arrCost[i]);
                            var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                            QuantityPrice = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i + 1]);
                            break;
                        }
                        else {
                            if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                                QuantityPriceExcMarkup = Number(arrCost[i]);
                                var ActualPrice = Number(QuantityPriceExcMarkup) + ((Number(QuantityPriceExcMarkup) / 100) * Number(arrMarkup[i]));
                                QuantityPrice = ActualPrice;
                                IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i]);
                                break;
                            }
                            else {
                                QuantityPriceExcMarkup = "0";
                                QuantityPrice = "0";
                            }
                        }
                    }
                    else {

                        QuantityPrice = "0";
                        QuantityPriceExcMarkup = "0";
                    }

                } else {
                    var ddlPriceQty = document.getElementById("ddlPriceQty" + PriceCatelogueID);
                    var sellingPrice = ddlPriceQty.options[ddlPriceQty.selectedIndex].value.split('~');
                    QuantityPriceExcMarkup = sellingPrice[0];
                    QuantityPrice = sellingPrice[1];
                }
            }
        }


        var CartTax = 0;
        var TaxRate = document.getElementById("hid_TaxRate" + PriceCatelogueID).value;      
        var TaxID = document.getElementById("hid_TaxID" + PriceCatelogueID).value;
        if (Number(QuantityPrice) != 0) {
            CartTax = Number((Number(QuantityPrice) * Number(TaxRate)) / 100);
        }


        var UnitPrice = 0;
        if (ProductType.toLowerCase() == "s" && hdnIsCumulative.value.toLowerCase() == "true") {
            if (Number(IsCumulativeQtyForUnitPrice) != 0) {
                UnitPrice = Number(QuantityPrice) / Number(IsCumulativeQtyForUnitPrice);
            }
            else {
                UnitPrice = "0";
            }
        } else {
            if (Number(QtySelectedProduct) != 0) {
                UnitPrice = Number(QuantityPrice) / Number(QtySelectedProduct);
            }
            else {
                UnitPrice = "0";
            }
        }
        var mainPriceExcMarkup = Number(QuantityPrice) - Number(QuantityPriceExcMarkup);
        //    alert("Cart Tax :" + CartTax + "  ----- Price Without tax " + QuantityPrice);
        //    alert(QtySelectedProduct);
        //    alert("unitprice" + UnitPrice + "---MainPriceExcMarkUp" + mainPriceExcMarkup);

        var MainProductId = document.getElementById("hdn_MainProductID" + PriceCatelogueID);
        MainProductId = MainProductId.value;

        var hid_PriceCatelogueName = document.getElementById("hid_PriceCatelogueName" + PriceCatelogueID);
        var ProductName = "";
        if (hid_PriceCatelogueName != null && hid_PriceCatelogueName != undefined) {
            ProductName = hid_PriceCatelogueName.value;
        }

        var Height = 0;
        var Width = 0;

        if (ProductType == "g") {
            Height = document.getElementById("txtHeight" + PriceCatelogueID).value;
            Width = document.getElementById("txtWidth" + PriceCatelogueID).value;
        }
        if (TaxRate == "") {
            TaxRate = "0";
        }

        AutoFill.QuickItemAdd(PriceCatelogueID, QtySelectedProduct, QuantityPrice, CartTax, StoreUserID, TaxRate, TaxID, UnitPrice, mainPriceExcMarkup, ProductName, Height, Width, ChangedProductID, MainProductId, ReturnQuickCartAdded);
    }
}



// number validation
function IsNumeric(val) {
    var numeric = true;
    var chars = "0123456789,";
    var len = val.length;
    var char = "";
    for (i = 0; i < len; i++) { char = val.charAt(i); if (chars.indexOf(char) == -1) { numeric = false; } }
    return numeric;
}


function stockvalidation(PriceCatelogueID, Qty) {
    var hdn_qtyFromList = document.getElementById("hdn_qtyFromList" + PriceCatelogueID);
    var hid_qtyToList = document.getElementById("hid_qtyToList" + PriceCatelogueID);
    var hdn_AvailableQuantity = document.getElementById("hdn_AvailableQuantity" + PriceCatelogueID);

    var arrQtyFrom = hdn_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var AvailableQuantity = parseInt(hdn_AvailableQuantity.value);

    for (var i = 0; i < arrQtyFrom.length - 1; i++) {
        if (i == 0) {
            QtyStartsfrom = Number(arrQtyFrom[i]);
        }
    }


    for (var j = 0; j < arrQtyTo.length - 1; j++) {
        if (j == arrQtyTo.length - 2) {
            QtyEndsTo = Number(arrQtyTo[j]);
        }
    }
    if (P_Type == 'g') {
        if (QtyStartsfrom > Number(Dimensn1)) {
            alert("Minimum Dimension is " + QtyStartsfrom);
            hideLoading(PriceCatelogueID);
            return false;
        }
        else if (QtyEndsTo < Number(Dimensn1)) {
            alert("Maximum Dimension is " + QtyEndsTo);
            hideLoading(PriceCatelogueID);
            return false;
        }
    }
    else {
        if (QtyStartsfrom > Number(Qty)) {
            alert("Minimum Quantity is " + QtyStartsfrom);
            hideLoading(PriceCatelogueID);
            return false;
        }
        else if (QtyEndsTo < Number(Qty)) {
            alert("Maximum Quantity is " + QtyEndsTo);
            hideLoading(PriceCatelogueID);
            return false;
        }
    }

    return true;
}

function ReturnQuickCartAdded(ItemCountText) {
    var ProductIdCount = ItemCountText.split('µ');

    var Imgcart = document.getElementById("ctl00_Img_cart");
    Imgcart.title = ProductIdCount[0];

    var btnQucikAddCart = document.getElementById("btnQucikAddCart" + ProductIdCount[1]);
    btnQucikAddCart.style.display = 'block';

    var btnQucikAddCartLoading = document.getElementById("btnQucikAddCartLoading" + ProductIdCount[1]);
    btnQucikAddCartLoading.style.display = "none";

    var lblSucess = document.getElementById("ctl00_ContentPlaceHolder1_RadWindow1_C_lblSucess");
    lblSucess.innerHTML = "\"" + ProductIdCount[2] + "\"" + " successfully added to cart.";
    ShowDialog();
}


function ShowDialog() {
    //    $("#Overlay_ship_Choose").show();
    //    $("#dialog_ship_Choose").fadeIn(300);
    loadradwindow();
}

function HideDialog() {
    //    $("#Overlay_ship_Choose").hide();
    //    $("#dialog_ship_Choose").fadeOut(300);

    closeredwindow();
}



function hideLoading(PID) {

    var btnQucikAddCart = document.getElementById("btnQucikAddCart" + PID);
    btnQucikAddCart.style.display = 'block';
    var btnQucikAddCartLoading = document.getElementById("btnQucikAddCartLoading" + PID);
    btnQucikAddCartLoading.style.display = "none";
}


function displayloading() {
    document.getElementById("ctl00_ContentPlaceHolder1_RadWindow1_C_btnGotoCart").style.display = "none";
    document.getElementById("div_btnGotoCart").style.display = "block";
    window.location = strSitepath + "shoppingcart.aspx?ID=0&PID=0";
}
function quickaddvalidate(txtid, type) {

    var Pricecatalogueid = txtid;
    if (document.getElementById("ddlOtherMultiplrDrp" + txtid) != null && document.getElementById("ddlOtherMultiplrDrp" + txtid) != undefined) {
        if (document.getElementById("ddlOtherMultiplrDrp" + txtid).value == "--Select--") {
            alert('Please select product');
            return false;
        }
    }
    var hdnIsCumulative = document.getElementById("hdn_IsCumulative_" + Pricecatalogueid);
    if (type == 'p') {
        var txtqty = document.getElementById("txtPriceBandQty" + Pricecatalogueid).value;
    }
    else if (type == 'g') {
        var txtqty = document.getElementById("txtPriceBandQty" + Pricecatalogueid).value;
    }
    else if (type == 's') {

        if (hdnIsCumulative.value.toLowerCase() == "true") {
            var e = document.getElementById("txt_Cumulative_PriceQty" + Pricecatalogueid);
            var txtqty = e.value;
        } else {
            var e = document.getElementById("ddlPriceQty" + Pricecatalogueid);
            var txtqty = e.options[e.selectedIndex].text
        }
    }
    var StockManagementPermission, IsStockItem, DrawStockFrom, IsBackOrder, AvailableQty;
    StockManagementPermission = document.getElementById("hdnstockmanagement").value;
    IsStockItem = document.getElementById("hdnisstockitem" + Pricecatalogueid).value;
    IsBackOrder = document.getElementById("hdnisbackorder" + Pricecatalogueid).value;
    DrawStockFrom = document.getElementById("hdndrawstockfrom" + Pricecatalogueid).value;
    AvailableQty = document.getElementById("hdnavailableqty" + Pricecatalogueid).value;

    if (StockManagementPermission.toLowerCase() == "true") {
        if (IsStockItem.toLowerCase() == "true") {
            if (IsBackOrder.toLowerCase() == "false") {
                if (Number(txtqty) > Number(AvailableQty)) {
                    document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "none";
                    document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "block";
                    return false;

                }
                else {
                    document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "block";
                    document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "none";
                    return true;
                }

            }
            else {
                document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "block";
                document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "none";
                return true;
            }
        }
    }

}

function quickaddvalidateOnlySignage(txtid, type) {

    var Pricecatalogueid = txtid;
    var hdnIsCumulative = document.getElementById("hdn_IsCumulative_" + Pricecatalogueid);
    if (type == 'g') {
        var txtqty = document.getElementById("txtPriceBandQty" + Pricecatalogueid).value;
    }
    var StockManagementPermission, IsStockItem, DrawStockFrom, IsBackOrder, AvailableQty;
    StockManagementPermission = document.getElementById("hdnstockmanagement").value;
    IsStockItem = document.getElementById("hdnisstockitem" + Pricecatalogueid).value;
    IsBackOrder = document.getElementById("hdnisbackorder" + Pricecatalogueid).value;
    DrawStockFrom = document.getElementById("hdndrawstockfrom" + Pricecatalogueid).value;
    AvailableQty = document.getElementById("hdnavailableqty" + Pricecatalogueid).value;

    if (StockManagementPermission.toLowerCase() == "true") {
        if (IsStockItem.toLowerCase() == "true") {
            if (IsBackOrder.toLowerCase() == "false") {
                if (Number(txtqty) > Number(AvailableQty)) {
                    document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "none";
                    document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "block";
                    if (type == 'g') {
                        document.getElementById("divcartWidthHeight" + Pricecatalogueid).style.marginTop = "20px";
                    }
                    return false;

                }
                else {
                    document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "block";
                    document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "none";
                    if (type == 'g') {
                        document.getElementById("divcartWidthHeight" + Pricecatalogueid).style.marginTop = "0px";
                    }
                    return true;
                }

            }
            else {
                document.getElementById("btnQucikAddCart" + Pricecatalogueid).style.display = "block";
                document.getElementById("btnQucikAddCartoutofstock" + Pricecatalogueid).style.display = "none";
                if (type == 'g') {
                    document.getElementById("divcartWidthHeight" + Pricecatalogueid).style.marginTop = "0px";
                }
                return true;
            }
        }
    }

}
var ChangedPID_withMainPID;
var ChangedProductID;
var PID = new Array();
var SETPID;
var PriceCatalogueID;
function ChnageProduct(PriceCatalogueID) {

    var strSitePath1 = strSitePath;
    PID = PriceCatalogueID.split('_');
    PriceCatalogueID = PID[0] + PID[1];
    var ddl_MultipleDrp = document.getElementById("ddlOtherMultiplrDrp" + PriceCatalogueID);


    ChangedProductID = ddl_MultipleDrp.options[ddl_MultipleDrp.selectedIndex].value;  //Changed product id after change the dropdown
    if (ChangedProductID == "--Select--") {
        ChangedProductID = PID[1];
    }

    ChangedPID_withMainPID = ChangedProductID + PID[1];
    SETPID = ChangedProductID + '_' + PID[1]; //Changed product id with MainId after change the dropdown to pass value to javascript:ChnageProduct()


    $.ajax({
        type: "POST",
        url: strSitePath + "products/product.aspx/LoadQuantity",
        //url: strSitePath + "App_Code/BaseClass.cs/LoadQuantity",
        data: GetInputLoad_Contacts(ChangedProductID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindQuantity,
        error: ServiceFailed
    });


    function GetInputLoad_Contacts(ChangedProductID) {
        var FinalString = ' { "ChangedProductID" : "' + ChangedProductID + '"} '
        return FinalString;
    }
}

function BindQuantity(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    PriceCatalogueID = PID[0] + PID[1];
    var ProductID = ChangedPID_withMainPID;
    var ddl_MultipleDrp = document.getElementById("ddlOtherMultiplrDrp" + PID[0] + PID[1]);
    ddl_MultipleDrp.setAttribute("onchange", "javascript:ChnageProduct('" + SETPID + "');");

    var NewProductId = "ddlPriceQty" + ProductID;
    var MatrixType = dataRows[0].MatrixType;


    var hdnPriceCatalogueIds = document.getElementById("hdnPriceCatalogueIds" + PriceCatalogueID);


    var PricecatalogueIds = new Array();
    ProductcatalogueIds = hdnPriceCatalogueIds.value.split(',');

    for (i = 0; i < ProductcatalogueIds.length; i++) {
        var Newtextbox = document.getElementById("txtPriceBandQty" + parseInt(ProductcatalogueIds[i]));
        if (Newtextbox != null && Newtextbox != undefined) {
            Newtextbox.parentNode.removeChild(Newtextbox);
        }

        var NewDropdown = document.getElementById("ddlPriceQty" + parseInt(ProductcatalogueIds[i]));
        if (NewDropdown != null && NewDropdown != undefined) {
            NewDropdown.parentNode.removeChild(NewDropdown);
        }

        var NewtextboxHeight = document.getElementById("txtHeight" + parseInt(ProductcatalogueIds[i]));
        if (NewtextboxHeight != null && NewtextboxHeight != undefined) {
            NewtextboxHeight.parentNode.removeChild(NewtextboxHeight);
        }

        var Newtextboxwidth = document.getElementById("txtWidth" + parseInt(ProductcatalogueIds[i]));
        if (Newtextboxwidth != null && Newtextboxwidth != undefined) {
            Newtextboxwidth.parentNode.removeChild(Newtextboxwidth);
        }
        var Newtxt_Cumulative_PriceQty = document.getElementById("txt_Cumulative_PriceQty" + parseInt(ProductcatalogueIds[i]));
        if (Newtxt_Cumulative_PriceQty != null && Newtxt_Cumulative_PriceQty != undefined) {
            Newtxt_Cumulative_PriceQty.parentNode.removeChild(Newtxt_Cumulative_PriceQty);
        }

    }

    if (document.getElementById("btnQucikAddCartoutofstock" + PriceCatalogueID).style.display == "block") {
        document.getElementById("btnQucikAddCartoutofstock" + PriceCatalogueID).style.display = "none";
    }
    if (document.getElementById("btnQucikAddCart" + PriceCatalogueID).style.display == "none") {
        document.getElementById("btnQucikAddCart" + PriceCatalogueID).style.display = "block";
    }

    var Newddl_MultipleDrp = "ddlOtherMultiplrDrp" + ProductID;
    var ddl_MultipleDrp = document.getElementById("ddlOtherMultiplrDrp" + PID[0] + PID[1]).id = Newddl_MultipleDrp;

    var NewhdnPriceCatalogueIds = "hdnPriceCatalogueIds" + ProductID;
    var hdnPriceCatalogueIds = document.getElementById("hdnPriceCatalogueIds" + PriceCatalogueID).id = NewhdnPriceCatalogueIds;

    var Newhdn_IsCumulativeId = "hdn_IsCumulative_" + ProductID;
    var hdn_IsCumulative = document.getElementById("hdn_IsCumulative_" + PriceCatalogueID).id = Newhdn_IsCumulativeId;

    var Newhdn_SoldInPacks = "hdn_SoldInPacks_" + ProductID;
    var hdn_SoldInPacks = document.getElementById("hdn_SoldInPacks_" + PriceCatalogueID).id = Newhdn_SoldInPacks;

    var Newhid_CostExcMarkupList = "hid_CostExcMarkupList" + ProductID;
    var hid_CostExcMarkupList = document.getElementById("hid_CostExcMarkupList" + PriceCatalogueID).id = Newhid_CostExcMarkupList;

    var Newhid_priceList = "hid_priceList" + ProductID;
    var hid_priceList = document.getElementById("hid_priceList" + PriceCatalogueID).id = Newhid_priceList;

    var Newhid_MarkupList = "hid_MarkupList" + ProductID;
    var hid_MarkupList = document.getElementById("hid_MarkupList" + PriceCatalogueID).id = Newhid_MarkupList;

    var Newhdn_AvailableQuantity = "hdn_AvailableQuantity" + ProductID;
    var hdn_AvailableQuantity = document.getElementById("hdn_AvailableQuantity" + PriceCatalogueID).id = Newhdn_AvailableQuantity;

    var Newhdn_qtyFromList = "hdn_qtyFromList" + ProductID;
    var hdn_qtyFromList = document.getElementById("hdn_qtyFromList" + PriceCatalogueID).id = Newhdn_qtyFromList;

    var Newhid_qtyToList = "hid_qtyToList" + ProductID;
    var hid_qtyToList = document.getElementById("hid_qtyToList" + PriceCatalogueID).id = Newhid_qtyToList;

    var Newhdnisstockitem = "hdnisstockitem" + ProductID;
    var hdnisstockitem = document.getElementById("hdnisstockitem" + PriceCatalogueID).id = Newhdnisstockitem;

    var Newhdndrawstockfrom = "hdndrawstockfrom" + ProductID;
    var hdndrawstockfrom = document.getElementById("hdndrawstockfrom" + PriceCatalogueID).id = Newhdndrawstockfrom;

    var Newhdnisbackorder = "hdnisbackorder" + ProductID;
    var hdnisbackorder = document.getElementById("hdnisbackorder" + PriceCatalogueID).id = Newhdnisbackorder;

    var Newhdnavailableqty = "hdnavailableqty" + ProductID;
    var hdnavailableqty = document.getElementById("hdnavailableqty" + PriceCatalogueID).id = Newhdnavailableqty;

    var NewbtnQucikAddCartoutofstock = "btnQucikAddCartoutofstock" + ProductID;
    var btnQucikAddCartoutofstock = document.getElementById("btnQucikAddCartoutofstock" + PriceCatalogueID).id = NewbtnQucikAddCartoutofstock;

    var NewbtnQucikAddCartLoading = "btnQucikAddCartLoading" + ProductID;
    var btnQucikAddCartLoading = document.getElementById("btnQucikAddCartLoading" + PriceCatalogueID).id = NewbtnQucikAddCartLoading;

    //    var NewdivQuickAdd = "divQuickAdd" + ProductID;
    //    var divQuickAdd = document.getElementById("divQuickAdd" + PriceCatalogueID).id = NewdivQuickAdd;

    var Newdivcartqty = "divcartqty" + ProductID;
    var divcartqty = document.getElementById("divcartqty" + PriceCatalogueID).id = Newdivcartqty;

    var NewdivcartWidthHeight = "divcartWidthHeight" + ProductID;
    var divcartWidthHeight = document.getElementById("divcartWidthHeight" + PriceCatalogueID).id = NewdivcartWidthHeight;

    var Newhid_PriceCatelogueName = "hid_PriceCatelogueName" + ProductID;
    var hid_PriceCatelogueName = document.getElementById("hid_PriceCatelogueName" + PriceCatalogueID).id = Newhid_PriceCatelogueName;

    var Newhdn_MainProductID = "hdn_MainProductID" + ProductID;
    var hdn_MainProductID = document.getElementById("hdn_MainProductID" + PriceCatalogueID).id = Newhdn_MainProductID;


    var Newlbl_priceStartsFrom = "lbl_priceStartsFrom" + ProductID;
    var lbl_priceStartsFrom = document.getElementById("lbl_priceStartsFrom" + PriceCatalogueID).id = Newlbl_priceStartsFrom;

    var NewlblDesc = "lblDesc" + ProductID;
    var lblDesc = document.getElementById("lblDesc" + PriceCatalogueID).id = NewlblDesc;
    lblDesc = document.getElementById(NewlblDesc);


    var NewProductId = "ddlPriceQty" + ProductID;
    var NewButtonId = 'btnQucikAddCart' + ProductID;
    var btnQucikAddCart = document.getElementById("btnQucikAddCart" + PriceCatalogueID).id = NewButtonId;
    var ddlPriceQty = document.getElementById(NewProductId);
    var btnQucikAddCart = document.getElementById(NewButtonId);

    var Newhid_TaxID = "hid_TaxID" + ProductID;
    var hid_TaxID = document.getElementById("hid_TaxID" + PriceCatalogueID).id = Newhid_TaxID;
    hid_TaxID = document.getElementById(Newhid_TaxID);

    var Newhid_TaxName = "hid_TaxName" + ProductID;
    var hid_TaxName = document.getElementById("hid_TaxName" + PriceCatalogueID).id = Newhid_TaxName;
    hid_TaxName = document.getElementById(Newhid_TaxName);

    var Newhid_TaxRate = "hid_TaxRate" + ProductID;
    var hid_TaxRate = document.getElementById("hid_TaxRate" + PriceCatalogueID).id = Newhid_TaxRate;
    hid_TaxRate = document.getElementById(Newhid_TaxRate);

    document.getElementById(Newhid_CostExcMarkupList).value = "";
    document.getElementById(Newhid_priceList).value = "";
    document.getElementById(Newhid_MarkupList).value = "";
    document.getElementById(Newhdn_qtyFromList).value = "";
    document.getElementById(Newhid_qtyToList).value = "";
    for (var i = 0; i < dataRows.length; i++) {

        document.getElementById(Newhdn_IsCumulativeId).value = dataRows[i].IsCumulativePricing;
        document.getElementById(Newhdn_SoldInPacks).value = dataRows[i].SoldInPacksof;

        document.getElementById(Newhid_CostExcMarkupList).value = document.getElementById(Newhid_CostExcMarkupList).value + dataRows[i].Price + 'µ';
        document.getElementById(Newhid_priceList).value = document.getElementById(Newhid_priceList).value + dataRows[i].SellingPrice + 'µ';
        document.getElementById(Newhid_MarkupList).value = document.getElementById(Newhid_MarkupList).value + dataRows[i].Markup + 'µ';

        document.getElementById(hdn_qtyFromList).value = document.getElementById(hdn_qtyFromList).value + dataRows[i].FromQuantity + 'µ';
        document.getElementById(Newhid_qtyToList).value = document.getElementById(Newhid_qtyToList).value + dataRows[i].ToQuantity + 'µ';

    }

    document.getElementById(Newhdn_AvailableQuantity).value = dataRows[0].AvailableQuantity;
    document.getElementById(Newhdnisstockitem).value = dataRows[0].IsStockItem;
    document.getElementById(Newhdndrawstockfrom).value = dataRows[0].DrawStockFrom;
    document.getElementById(Newhdnisbackorder).value = dataRows[0].IsBackOrder;
    document.getElementById(Newhdnavailableqty).value = dataRows[0].AvailableQuantity;
    document.getElementById(Newhid_PriceCatelogueName).value = SpecialDecode(dataRows[0].CatalogueName);
    hid_TaxID.value = dataRows[0].TaxId;
    hid_TaxName.value = dataRows[0].TaxName;
    hid_TaxRate.value = dataRows[0].TaxRate;

    if (dataRows[0].IsShortDescription.toString().toLowerCase() == "true") {
        lblDesc.innerHTML = dataRows[0].Description;
    }
    else {
        lblDesc.innerHTML = "";
    }

    if (dataRows[0].IsPriceStartFrom.toString().toLowerCase() == "true") {
        document.getElementById(Newlbl_priceStartsFrom).style.display = "";
        document.getElementById(Newlbl_priceStartsFrom).setAttribute("class", "priceStartsFromInQuickAdd");

        document.getElementById(Newlbl_priceStartsFrom).innerHTML = "Price Starts From:" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(companyID, 0, parseFloat(dataRows[0].SellingPrice), 2, "", false, false, true);
    }
    else {
        document.getElementById(Newlbl_priceStartsFrom).style.display = "none";
    }


    var Extension = dataRows[0].ProductImage.substring(dataRows[0].ProductImage.lastIndexOf('.') + 1).toLowerCase();

    if (Extension != "gif") {
        if (dataRows[0].ProductImage != "") {
            document.getElementById("imgGetID1" + PID[1]).title = dataRows[0].CatalogueName;
            document.getElementById("imgGetID1" + PID[1]).src = strSitePath + "ImageHandler.ashx?ImageName=" + dataRows[0].ProductImage + " &type=p&aid=" + AccountID + "&cid=" + companyID + "";
        }
        else {
            document.getElementById("imgGetID1" + PID[1]).src = strSitePath + "ImageHandler.ashx?ImageName=t_no_image_available.png&type=r&aid=" + AccountID + "&cid=" + companyID + "";
            document.getElementById("imgGetID1" + PID[1]).title = dataRows[0].CatalogueName;
        }
    }

    if (Extension == "gif") {
        if (dataRows[0].ProductImage != "") {
            document.getElementById("imgGetID1" + PID[1]).src = strSitePath + "ImageHandler.ashx?ImageName=" + dataRows[0].ProductImage + " &type=p&aid=" + AccountID + "&cid=" + companyID + "";
            document.getElementById("imgGetID1" + PID[1]).title = dataRows[0].CatalogueName;
            document.getElementById("imgGetID1" + PID[1]).setAttribute("style", "height:150px; width:150px;");
        }
        else {
            document.getElementById("imgGetID1" + PID[1]).src = strSitePath + "ImageHandler.ashx?ImageName=t_no_image_available.png&type=r&aid=" + AccountID + "&cid=" + companyID + "";
            document.getElementById("imgGetID1" + PID[1]).title = dataRows[0].CatalogueName;
        }
    }




    if (MatrixType.toLowerCase() == "p") {

        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.name = "txtPriceBandQty" + ProductID;
        textbox.id = "txtPriceBandQty" + ProductID;
        textbox.value = "Qty";
        textbox.setAttribute("class", "txtStyleQuickAdd");
        textbox.title = "Please enter quantity";
        document.getElementById(Newdivcartqty).appendChild(textbox);

        textbox.setAttribute("onfocus", "javascript:if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
        textbox.setAttribute("onblur", "javascript:if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(" + ProductID + ",'p');");
        textbox.setAttribute("onclick", "javascript:this.style.color = '';");
        textbox.setAttribute("onkeypress", "javascript:if(validateNumberOnly(event)){}else{return false;}");

        btnQucikAddCart.setAttribute("onmouseout", "javascript:mouseOutHidediv(" + ProductID + ");");
        btnQucikAddCart.setAttribute("onclick", "javascript:if(quickaddvalidate(" + ProductID + ",'p')) {QuickAddItemCart(" + ProductID + ",'p'," + ChangedProductID + ")}");
    }

    if (MatrixType.toLowerCase() == "s") {
        hdn_IsCumulative = document.getElementById(Newhdn_IsCumulativeId);
        if (hdn_IsCumulative.value.toLowerCase() == "true") {
            var textbox = document.createElement("input");
            textbox.type = "text";
            textbox.name = "txt_Cumulative_PriceQty" + ProductID;
            textbox.id = "txt_Cumulative_PriceQty" + ProductID;
            textbox.value = "Qty";
            textbox.setAttribute("class", "txtStyleQuickAdd");
            textbox.title = "Please enter quantity";
            document.getElementById(Newdivcartqty).appendChild(textbox);
            textbox.setAttribute("style", "color:gray;");
            textbox.setAttribute("onfocus", "javascript:if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
            textbox.setAttribute("onblur", "javascript:if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(" + ProductID + ",'s');");
            textbox.setAttribute("onclick", "javascript:this.style.color = '';");
            textbox.setAttribute("onkeypress", "javascript:if(validateNumberOnly(event)){}else{return false;}");

            btnQucikAddCart.setAttribute("onmouseout", "javascript:mouseOutHidediv(" + ProductID + ");");
            btnQucikAddCart.setAttribute("onclick", "javascript:if(quickaddvalidate(" + ProductID + ",'s')) {QuickAddItemCart(" + ProductID + ",'s'," + ChangedProductID + ")}");

        }
        else {

            var dropdown = document.createElement("Select");
            dropdown.type = "dropdown";
            dropdown.name = "ddlPriceQty" + ProductID;
            dropdown.id = "ddlPriceQty" + ProductID;
            dropdown.setAttribute("class", "dropDownMultipleQuickAdd");
            dropdown.title = "Please select quantity";
            dropdown.setAttribute("style", "height:22px;");
            document.getElementById(Newdivcartqty).appendChild(dropdown);

            dropdown.setAttribute("onchange", "javascript:quickaddvalidate(" + ProductID + ",'s');");
            AddOption(dropdown, dataRows);
            btnQucikAddCart.setAttribute("onmouseout", "javascript:mouseOutHidediv(" + ProductID + ");");
            btnQucikAddCart.setAttribute("onclick", "javascript:if(quickaddvalidate(" + ProductID + ",'s')) {QuickAddItemCart(" + ProductID + ",'s'," + ChangedProductID + ")}");
        }
    }

    if (MatrixType.toLowerCase() == "g") {
        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.name = "txtPriceBandQty" + ProductID;
        textbox.id = "txtPriceBandQty" + ProductID;
        textbox.value = "Qty";
        textbox.title = "Please enter quantity";
        textbox.setAttribute("class", "txtStyleQuickAdd");
        textbox.setAttribute("onfocus", "javascript:if(this.value == 'Qty') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
        //textbox.setAttribute("onblur", "javascript:if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidate(" + ProductID + ",'g');");
        textbox.setAttribute("onclick", "javascript:this.style.color = '';");
        textbox.setAttribute("onkeypress", "javascript:if(validateNumberOnly(event)){}else{return false;}");
        textbox.setAttribute("onblur", "javascript:if (this.value == '') {this.value = 'Qty';this.style.color ='gray';}else{this.style.color = '';} quickaddvalidateOnlySignage(" + ProductID + ",'g');");
        document.getElementById(Newdivcartqty).appendChild(textbox);


        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.name = "txtWidth" + ProductID;
        textbox.id = "txtWidth" + ProductID;
        textbox.value = "Width";
        textbox.title = "Please enter width";
        textbox.setAttribute("class", "txtStyleQuickAdd");
        textbox.setAttribute("onfocus", "javascript:if(this.value == 'Width') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
        textbox.setAttribute("onblur", "javascript:roundUp(this.id,this.value,2); quickaddvalidate(" + ProductID + ",'g');");
        textbox.setAttribute("onclick", "javascript:this.style.color = '';");

        document.getElementById(NewdivcartWidthHeight).appendChild(textbox);


        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.name = "txtHeight" + ProductID;
        textbox.id = "txtHeight" + ProductID;
        textbox.value = "Height";
        textbox.title = "Please enter height";
        textbox.setAttribute("style", "margin-left:8px;");
        textbox.setAttribute("class", "txtStyleQuickAdd");
        textbox.setAttribute("onfocus", "javascript:if(this.value == 'Height') {this.value = '';this.style.color ='gray';}else{this.style.color = '';}");
        textbox.setAttribute("onblur", "javascript:roundUp(this.id,this.value,2); quickaddvalidate(" + ProductID + ",'g');");
        textbox.setAttribute("onclick", "javascript:this.style.color = '';");

        document.getElementById(NewdivcartWidthHeight).appendChild(textbox);
        btnQucikAddCart.setAttribute("onmouseout", "javascript:mouseOutHidediv(" + ProductID + ");");
        btnQucikAddCart.setAttribute("onclick", "javascript:if(quickaddvalidate(" + ProductID + ",'g')) {QuickAddItemCart(" + ProductID + ",'g'," + ChangedProductID + ")}");

        document.getElementById(NewdivcartWidthHeight).style.marginTop = "0px";
        //document.getElementById(NewbtnQucikAddCartLoading).style.height = "25px";

    }

    //PriceCatalogueID = ProductID;
}
function AddOption(ddl, dataRows) {

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].ToQuantity;
        optionvalues.value = dataRows[i].NewPrice;
        ddl.options.add(optionvalues);
    }
}
function ServiceFailed(result) {

    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}
function MarkupOnBlur_Ink(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));

    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));

    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var CostExMarkup = '';
    var Markup = '';
    //    alert(hdn_MinimumCharge.value);


    var CostExMarkup = hdn_CostExMarkup_Actual.value;
    var Markup = txt_Markup.value;
    //var SellingPrice = Eprint_GetminimumCost_ComparedtoCostwithMarkup(CostExMarkup - hdn_SetUpCost.value, Markup, hdn_MinimumCharge.value, '', '', hdn_SetUpCost.value);

    var MarkupPrice = (Number(CostExMarkup - hdn_SetUpCost.value) * Number(Markup)) / 100;
    var totalcost = 0;
    var SellingPrice = 0;
    totalcost = Number(CostExMarkup - hdn_SetUpCost.value) + MarkupPrice + Number(hdn_SetUpCost.value);
    if (Number(hdn_MinimumCharge.value) >= Number(totalcost)) {
        SellingPrice = Number(hdn_MinimumCharge.value);
        hdn_CostExMarkup.value = hdn_MinimumCharge.value;
        hdn_MarkupPrice.value = "0";
    }
    else {
        SellingPrice = Number(totalcost);
        hdn_CostExMarkup.value = Number(totalcost) - MarkupPrice;
        hdn_MarkupPrice.value = MarkupPrice;
    }

    hdn_CostExMarkup_Actual = Number(totalcost) - MarkupPrice;
    hdn_SellingPrice.value = SellingPrice;
    var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, SellingPrice, 0, '', false, false, true);
    lbl_SellingPrice.innerHTML = finalValue;
    lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MarkupPrice, 0, '', false, false, true);

}
function AllowNumber(obj, val) {
    if (val.substring(1, 0) != "-")//for NEGATIVE Values
    {

        if (!isNaN(val)) {
            //alert(val);
            return true;
        }
        else {
            obj.value = '';
            obj.focus();
            return false;
        }
    }
    else {
        obj.value = '';
        obj.focus();
        return false;
    }
}
/*******************************************************************************************************************************************************/