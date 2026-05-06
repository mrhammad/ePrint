$(function () {
    var note = $('#note'),
		ts = new Date(2012, 0, 1),
		newYear = true;
    if ((new Date()) > ts) {
        var timeActual = document.getElementById("ctl00_ContentPlaceHolder1_Timeleft").value; //From Database

        // The new year is here! Count towards something else.
        // Notice the *1000 at the end - time must be in milliseconds
        //ts = (new Date()).getTime() + 1000 * 24 * 60 * 60 * 1000;

        ts = (new Date()).getTime() + timeActual * 1000;
        newYear = false;

        if (timeActual < 0) {
            TimeOut();
        }
    }

    $('#countdown').countdown({
        timestamp: ts,
        callback: function (days, hours, minutes, seconds) {
            if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
                TimeOut();
            }

            var message = "";

            message += days + " day" + (days == 1 ? '' : 's') + ", ";
            message += hours + " hour" + (hours == 1 ? '' : 's') + ", ";
            message += minutes + " minute" + (minutes == 1 ? '' : 's') + " and ";
            message += seconds + " second" + (seconds == 1 ? '' : 's') + " <br />";

            if (newYear) {
                //message += "left until the new year!";
            }
            else {
                message += "left to Quote from now!";
            }

            note.html(message);
        }
    });

});
