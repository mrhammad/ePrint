var pagecount = 1;

$(function () {
    //alert("pageload preview")
})

function imgLoaded(e) {  
    var ImgHeight = e.naturalHeight, ImgWidth = e.naturalWidth;
    var ratio = 1;
    if (ImgHeight > ImgWidth)
        ratio = ImgHeight / ImgWidth;
    else
        ratio = ImgWidth / ImgHeight;

    //e.height = ImgHeight;
    e.width = $(e).parent().width() / ratio;
}


function btnPrevoius_clicked() {
    li = $(".slider li.selected");
    var prev, selected = li;
    if (selected.prev('li').length) {
        pagecount = pagecount - 1;
        prev = selected.prev('li');
        selected.removeClass("selected").fadeOut('slow');
        selected.removeClass("selected").hide();
        prev.addClass('selected').fadeIn('fast');
        $(".pageNo").html(pagecount);
    }
}


function btnNext_clciked() {
    li = $(".slider li.selected");
    var next, selected = li;
    if (selected.next('li').length) {
        pagecount = pagecount + 1;
        next = selected.next('li');
        selected.removeClass("selected").fadeOut('slow');
        selected.removeClass("selected").hide();
        next.addClass('selected').fadeIn('fast');
        $(".pageNo").html(pagecount);
    }
}


function downloadImage_click() {
    window.open(strSitepath + "imagehandler.ashx?type=previewimage&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + $("li.selected input")[0].value, '_blank');
}


function previewpdf_Changed(e) {
    if (e.checked) {
        $(".pdfframe").css('visibility', 'visible');
        $(".pdfframe").css('display', 'block');
        $(".imageframe").css('visibility', 'collapsed');
        $(".imageframe").css('display', 'none');
    }
}


function previewimage_Changed(e) {
    if (e.checked) {
        $(".imageframe").css('visibility', 'visible');
        $(".imageframe").css('display', 'block');
        $(".pdfframe").css('visibility', 'collapsed');
        $(".pdfframe").css('display', 'none');
    }
}

function ApproveOrReject() {
    var OrderID = decodeURIComponent(window.location.href.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent("OrderId").replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
    var UserID = decodeURIComponent(window.location.href.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent("UserId").replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));



    window.top.location.href = "https://" + document.location.hostname + "/store/accounts/order.aspx?OrderID=" + OrderID + "&UserID=" + UserID;
}