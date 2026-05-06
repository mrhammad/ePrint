// JScript File
function ConfirmUpdate() {
    {
        var el = document.getElementById("contentFRM").style;
        var el1 = document.getElementById("contentFRM");
        alert(el1);
        if (el.display == "none") {
            el.visibility = "visible";
            el.display = "block";
            //var x = "http://www.eclientes.net/removesession.aspx";//?urlname=" + window.location + "" ;
            //var x = "http://www.allourcustomers.com/removesession.aspx";//?urlname=" + window.location + "" ;
            var x = "http://192.168.1.15/Aoc/lightboxImages/image-1.jpg"; //?urlname=" + window.location + "" ;
            el1.src = x;
        }
    }
    //window.setInterval("ConfirmUpdate()",1000*60*10);
    window.setInterval("ConfirmUpdate()", 1000);
}

//===========To Enable Buttons============jnp============

//function desableAfterLoad() {
//    window.parent.document.getElementById("ds00").style.display = "none";
//    window.parent.document.getElementById("div_Load").style.display = "none";
//}

//function onloadChangeColor1() {

//    window.parent.document.getElementById("li_Preview").style.display = "block";
//    window.parent.document.getElementById("item_2").style.color = "blue";
//    window.parent.document.getElementById("item_1").style.color = "black";
//    window.parent.document.getElementById("li_EditTemplate").style.display = "block";
//    window.parent.document.getElementById("li_EmailTemplate").style.display = "block";
//    window.parent.document.getElementById("ds00").style.display = "none";
//    window.parent.document.getElementById("div_Load").style.display = "none";
//}

//function enablebtns(redirectPage) {
//    //alert("hi");
//    window.parent.document.getElementById("ds00").style.display = "block";
//    window.parent.document.getElementById("div_Load").style.display = "block";
//    window.parent.document.getElementById("ds00").style.width = window.parent.screen.availWidth + "px";
//    window.parent.document.getElementById("ds00").style.height = window.parent.screen.availHeight + "px";
//    setTimeout("onloadChangeColor()", 6500);
//    setTimeout("desableAfterLoad()", 9000);
//    window.location = redirectPage;
//}

