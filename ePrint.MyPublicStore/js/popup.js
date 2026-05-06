

$(document).ready(function() {

    //When you click on a link with class of poplight and the href starts with a # 
    $('a.poplight[href^=#]').click(function() {
        var popID = $(this).attr('rel'); //Get Popup Name
        var popURL = $(this).attr('href'); //Get Popup href to define size

        //Pull Query & Variables from href URL
        var query = popURL.split('?');
        var dim = query[1].split('&');
        var popWidth = dim[0].split('=')[1]; //Gets the first query string value

        //Fade in the Popup and add close button
        $('#' + popID).fadeIn().css({ 'width': Number(popWidth) }).prepend('<a href="#" class="close"><img src="../images/close.png" class="btn_close" title="Close Window" alt="Close" /></a>');

        //Define margin for center alignment (vertical + horizontal) - we add 80 to the height/width to accomodate for the padding + border width defined in the css
        var popMargTop = ($('#' + popID).height() + 80) / 2;
        var popMargLeft = ($('#' + popID).width() + 80) / 2;

        //Apply Margin to Popup
        $('#' + popID).css({
            'margin-top': -popMargTop,
            'margin-left': -popMargLeft
        });

        //Fade in Background
        $('body').append('<div id="fade"></div>'); //Add the fade layer to bottom of the body tag.
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn(); //Fade in the fade layer 

        return false;
    });


    //Close Popups and Fade Layer
    $('a.close, #fade').live('click', function() { //When clicking on the close or fade layer...
        $('#fade , .popup_block').fadeOut(function() {
            $('#fade, a.close').remove();
        }); //fade them both out

        return false;
    });
});



/* Help test popup (Start) */
this.tooltip = function() {
    /* CONFIG */
    xOffset = 10;
    yOffset = 20;
    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result		
    /* END CONFIG */
    $("a.tooltip").hover(function(e) {
        this.t = this.title;
        this.title = "";
        $("body").append("<p id='tooltip'>" + this.t + "</p>");
        $("#tooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
    },
	function() {
	    this.title = this.t;
	    $("#tooltip").remove();
	});
    $("a.tooltip").mousemove(function(e) {
        $("#tooltip")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
};

// starting the script on page load
$(document).ready(function() {
    tooltip();
});
/* Help test popup (End) */
        
