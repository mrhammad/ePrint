
/* Help test popup (Start) */
this.tooltip = function () {
    /* CONFIG */
    xOffset = 10;
    yOffset = 20;
    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result		
    /* END CONFIG */
    $("a.tooltip").hover(function (e) {
        setTimeout(hover($(this)), 3000);
        if (this.title != undefined) {
            this.t = this.title;
            this.title = "";
            $("body").append("<p id='tooltip'>" + this.t + "</p>");
            $("#tooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
        }
        
    },
	function () {

	    if (this.title != undefined) {
	        this.title = this.t;
	    }
	    $("#tooltip").remove();
	});
    $("a.tooltip").mousemove(function (e) {
        $("#tooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
};
// starting the script on page load
$(document).ready(function () {
    tooltip();
});
/* Help test popup (End) */




//This is for CRM tooltip



/* Help test popup (Start) */
this.crmtooltip = function () {

    /* CONFIG */
    xOffset = 10;
    yOffset = 20;
    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result		
    /* END CONFIG */
    $("a.crmtooltip").hover(function (e) {
        
        if (this.title != undefined) {
            if (this.title != "") {
                this.t = this.title;
                this.title = "";
                $("body").append("<p id='crmtooltip'>" + SpecialDecode(this.t) + "</p>");
                $("#crmtooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
            }
        }
    },
	function () {
	   
	    if (this.title != undefined) {
	        this.title = this.t;
	    }
	    $("#crmtooltip").remove();
	});
    $("a.crmtooltip").mousemove(function (e) {
        $("#crmtooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
};
// starting the script on page load
$(document).ready(function () {
    crmtooltip();
});
/* Help test popup (End) */

