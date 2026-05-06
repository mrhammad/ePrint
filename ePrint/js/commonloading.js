
function loadingimg(div1, div2) {
    document.getElementById(div1).style.display = "none";
    document.getElementById(div2).style.display = "block";
}


function loadingimage(divtohide, divload) {

    /*! Copyright 2012,  Custom plugin for get width and height of the html element according to respective browser. added by rk on 06-12-2012
    *
    * Version: 1.0.13
    *
    * Requires: jQuery 1.2.3 ~ 1.8.2
    */
    ; (function (a) { a.fn.extend({ actual: function (b, l) { if (!this[b]) { throw '$.actual => The jQuery method "' + b + '" you called does not exist'; } var f = { absolute: false, clone: false, includeMargin: false }; var i = a.extend(f, l); var e = this.eq(0); var h, j; if (i.clone === true) { h = function () { var m = "position: absolute !important; top: -1000 !important; "; e = e.clone().attr("style", m).appendTo("body"); }; j = function () { e.remove(); }; } else { var g = []; var d = ""; var c; h = function () { c = e.parents().andSelf().filter(":hidden"); d += "visibility: hidden !important; display: block !important; "; if (i.absolute === true) { d += "position: absolute !important; "; } c.each(function () { var m = a(this); g.push(m.attr("style")); m.attr("style", d); }); }; j = function () { c.each(function (m) { var o = a(this); var n = g[m]; if (n === undefined) { o.removeAttr("style"); } else { o.attr("style", n); } }); }; } h(); var k = /(outer)/g.test(b) ? e[b](i.includeMargin) : e[b](); j(); return k; } }); })(jQuery);

    // actual script starts here
    document.getElementById(divtohide).style.display = "none";
    var width = $('#' + divtohide).actual('width') + 'px';
    var height = $('#' + divtohide).actual('height') + 'px';
    var paddingleft = $('#' + divtohide).css("paddingLeft");
    var paddingright = $('#' + divtohide).css("paddingRight");
    var paddingtop = $('#' + divtohide).css("paddingTop");
    var paddingbottom = $('#' + divtohide).css("paddingBottom");
    var marginleft = $('#' + divtohide).css("marginLeft");
    var marginright = $('#' + divtohide).css("marginRight");
    var margintop = $('#' + divtohide).css("marginTop");
    var marginbottom = $('#' + divtohide).css("marginBottom");
    //  var width = document.getElementsByTagName("input")[divtohide].offsetWidth + 'px';
    //  var height = document.getElementsByTagName("input")[divtohide].offsetHeight + 'px';
    var Left = (getOffset(document.getElementById(divtohide)).left + 'px');
    var Top = (getOffset(document.getElementById(divtohide)).top + 'px');

    //set the attributes according to browser generated value
    document.getElementById(divload).setAttribute("class", "loadimgbtn");
    document.getElementById(divload).style.display = "block";
    document.getElementById(divload).style.width = width;
    document.getElementById(divload).style.height = height;
    document.getElementById(divload).style.left = Left;
    document.getElementById(divload).style.top = Top;
    document.getElementById(divload).style.paddingLeft = paddingleft;
    document.getElementById(divload).style.paddingRight = paddingright;
    document.getElementById(divload).style.paddingTop = paddingtop;
    document.getElementById(divload).style.paddingBottom = paddingbottom;
    document.getElementById(divload).style.marginLeft = marginleft;
    document.getElementById(divload).style.marginRight = marginright;
    document.getElementById(divload).style.marginTop = margintop;
    document.getElementById(divload).style.marginBottom = marginbottom;

}



function loadingimagelogin(divtohide, divload) {

    ; (function (a) { a.fn.extend({ actual: function (b, l) { if (!this[b]) { throw '$.actual => The jQuery method "' + b + '" you called does not exist'; } var f = { absolute: false, clone: false, includeMargin: false }; var i = a.extend(f, l); var e = this.eq(0); var h, j; if (i.clone === true) { h = function () { var m = "position: absolute !important; top: -1000 !important; "; e = e.clone().attr("style", m).appendTo("body"); }; j = function () { e.remove(); }; } else { var g = []; var d = ""; var c; h = function () { c = e.parents().andSelf().filter(":hidden"); d += "visibility: hidden !important; display: block !important; "; if (i.absolute === true) { d += "position: absolute !important; "; } c.each(function () { var m = a(this); g.push(m.attr("style")); m.attr("style", d); }); }; j = function () { c.each(function (m) { var o = a(this); var n = g[m]; if (n === undefined) { o.removeAttr("style"); } else { o.attr("style", n); } }); }; } h(); var k = /(outer)/g.test(b) ? e[b](i.includeMargin) : e[b](); j(); return k; } }); })(jQuery);

    // actual script starts here
    document.getElementById(divtohide).style.display = "none";
    var width = $('#' + divtohide).actual('width') + 'px';
    var height = $('#' + divtohide).actual('height') + 'px';
    var paddingleft = $('#' + divtohide).css("paddingLeft");
    var paddingright = $('#' + divtohide).css("paddingRight");
    var paddingtop = $('#' + divtohide).css("paddingTop");
    var paddingbottom = $('#' + divtohide).css("paddingBottom");
    var marginleft = $('#' + divtohide).css("marginLeft");
    var marginright = $('#' + divtohide).css("marginRight");
    var margintop = $('#' + divtohide).css("marginTop");
    var marginbottom = $('#' + divtohide).css("marginBottom");
    var Left = (getOffset(document.getElementById(divtohide)).left + 'px');
    var Top = (getOffset(document.getElementById(divtohide)).top + 'px');

    //set the attributes according to browser generated value
    document.getElementById(divload).setAttribute("class", "Loginbuttoscss");
    document.getElementById(divload).style.display = "block";
    document.getElementById(divload).style.width = width;
    document.getElementById(divload).style.height = height;
    document.getElementById(divload).style.left = Left;
    document.getElementById(divload).style.top = Top;
    document.getElementById(divload).style.paddingLeft = paddingleft;
    document.getElementById(divload).style.paddingRight = paddingright;
    document.getElementById(divload).style.paddingTop = paddingtop;
    document.getElementById(divload).style.paddingBottom = paddingbottom;
    document.getElementById(divload).style.marginLeft = marginleft;
    document.getElementById(divload).style.marginRight = marginright;
    document.getElementById(divload).style.marginTop = margintop;
    document.getElementById(divload).style.marginBottom = marginbottom;

}


function getOffset(el) {
    var _x = 0;
    var _y = 0;
    while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
        _x += el.offsetLeft;
        _y += el.offsetTop;
        el = el.offsetParent;
    }
    return { top: _y, left: _x };
}

function validate_Account_OrderingProcess() {
    if (Page_ClientValidate()) {
        if (AccountID == 0) {
            alert(Customer_Select_Alert);
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return false;
    }
}

function validate_Account() {
    if (AccountID == 0) {
        alert(Customer_Select_Alert);
        return false;
    }
    else {
        return true;
    }
}



