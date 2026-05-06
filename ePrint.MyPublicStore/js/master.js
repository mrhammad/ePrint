function ShowDeshboard() {

    $("#ctl00_divNotifications").slideToggle("slow");
    document.getElementById("ctl00_divNotifications").style.display = "block";
}

function CloseDeshboard() {

    $("#ctl00_divNotifications").slideToggle("slow");
    document.getElementById("ctl00_divNotifications").style.display = "block";
}


function defaultText() {
    txt_search.className = "txtWidthSearch";
    divSearchBox.className = "divSearchBox";
    if (txt_search.value == "") {
        document.getElementById("ctl00_txt_search").style.fontStyle = "italic";
        document.getElementById("ctl00_txt_search").style.color = "rgb(169, 164, 164)";
        txt_search.value = "Free Text Search";
    }
}


function vaidate_Search() {
    txt_search.value = "";
    txt_search.className = "txtWidthSearchColor";
    document.getElementById("ctl00_txt_search").style.fontStyle = "normal";
    document.getElementById("ctl00_txt_search").style.color = "black";
    document.getElementById("ctl00_txt_search").style.fontFamily = "Helvetica, sans - serif";
    divSearchBox.className = "divSearchBoxColor";
}

function vaidate_SearchImg() {
    if (txt_search.value == "" || txt_search.value == "Free Text Search") {
        alert("Please enter search text");
        return false;
    }
    else {
        return true;
    }
}

function Onclick_Search() {
    var search = true;
    search = vaidate_SearchImg();

    if (search) {

        var str = txt_search.value;
        var newSearchStr = str; //.replace(/[^a-z0-9\s]/gi, ''); //.replace(/[_\s]/g, '-');
        document.cookie = "spcookie=" + newSearchStr;
        window.location = strSitepath + "products/searchproducts.aspx?sp=" + newSearchStr;
    }
    else

        return false;
}

function Onclick_Productnew() {

    window.location = strSitepath + "products/product.aspx?ID=0";

}

function Onclick_Sitemap() {

    window.location = strSitepath + "sitemap.aspx";
}

function OpenMyAccount(val) {

    if (Rewritemodule.toLowerCase() == 'on') {
        if (val == 'cart')
            window.location = strSitepath + "shoppingcart" + KeySeparator + 0 + KeySeparator + 0 + FileExtension;
        else if (val == 'order')
            window.location = strSitepath + "account/myorder" + FileExtension;
        else if (val == 'checkout')
            window.location = strSitepath + "checkout" + FileExtension;
        else if (val == 'mydesign')
            window.location = strSitepath + "mydesign" + FileExtension;
        else if (val == 'account')
            window.location = strSitepath + "account/account" + FileExtension;
    }
    else {
        if (val == 'cart')
            window.location = strSitepath + "shoppingcart.aspx?ID=0&amp;PID=0";
        else if (val == 'order')
            window.location = strSitepath + "account/myorder.aspx";
        else if (val == 'checkout')
            window.location = strSitepath + "checkout.aspx";
        else if (val == 'mydesign')
            window.location = strSitepath + "my_design.aspx";
        else if (val == 'account')
            window.location = strSitepath + "account/account.aspx";
    }
}

function capturekey(e) {

    var evt = e ? e : window.event;
    var bt = document.getElementById('ctl00_img_search');
    if (bt) {
        if (evt.keyCode == 13) {
            Onclick_Search();
            return false;
        }
    }
}