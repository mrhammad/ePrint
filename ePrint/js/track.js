//var isclosetimeout = "";
//var isSessiontimeout = "";
//var runonce = "";

//$(document).ready(function () {
//    setInterval(function () {
//        checksession_in_regularintervel();
//    }, 25000);

//    setInterval(function () {
//        checkRemainingtime_in_regularintervel();
//    }, 30000);



//    function checkRemainingtime_in_regularintervel() {
//        var MultiTabTimeLeft = localStorage.getItem("timeleft"); //get
//        runonce = localStorage.getItem("runonce"); //get
//        if (MultiTabTimeLeft != null) {
//            sessionTimeout = parseFloat(MultiTabTimeLeft);
//            // alert("regular interval "+MultiTabTimeLeft);
//        }


//        // if session is remaining time is 2 min
//        if (sessionTimeout == 2) {
//            if (runonce == "") {
//                loadradwindow('timeout'); //call countdown timer popup
//                //To countdown 2 minutes and 00 seconds every time.
//                var TargetDate = new Date().valueOf() + parseInt(sessionTimeout) * 60000 + 00 * 1000;
//                StartCountDown(TargetDate);
//                localStorage.setItem("runonce", "true");  //set
//            }
//        }
//        else {// decrease the session time count
//            if (sessionTimeout > 2 && runonce == "") {
//                DisplaySessionTimeout();
//            }
//            closeredwindow2();
//            CheckSession();
//        }

//    }


//    function checksession_in_regularintervel() {
//        activityfound();
//        CheckSession(); // check session for null values every 30sec.
//    }
//});


//function CheckSession() {
//    var SessionStatus = {};
//    $.ajax({
//        url: sitepath + "post_session.ashx?callback=?",
//        async: false,
//        dataType: 'json',
//        success: function (data) {
//            SessionStatus = data.sessionstatus;
//        }
//    });
//    SessionStatus = $.trim(SessionStatus);
//    //alert(SessionStatus);
//    if (SessionStatus == 'false') {
//        closeredwindow2(); // close timercountdown popup
//        loadradwindow('relogin');
//        isSessiontimeout = true;
//    }
//    else {
//        closeradwindow1();
//    }
//    // this second method to access the data from handler
//    //    var SessionStatus = {};
//    //    $.getJSON(sitepath + "post_session.ashx?callback=?", function (myData) {
//    //        SessionStatus = myData.sessionstatus;
//    //       // alert(SessionStatus);

//    //    });

//}


//function ResetClientSideSessionTimers() { // this function called form headerpage
//    sessionTimeout = parseInt(hdnSessionCntr.value);
//    isclosetimeout = "true";
//    isSessiontimeout = "";
//    //  self.close(); // close radwindow
//    closeredwindow2();
//    settimeleft();
//    localStorage.setItem("runonce", "");  //set
//}

//function Close() {
//    var oWindow = GetRadWindow();
//    oWindow.close();
//    return false;
//}

//function GetRadWindow() {
//    var oWindow = null;
//    if (window.radWindow)
//        oWindow = window.radWindow;
//    else if (window.frameElement.radWindow)
//        oWindow = window.frameElement.radWindow;
//    return oWindow;
//}

//function DisplaySessionTimeout() {
//    sessionTimeout = parseFloat(sessionTimeout) - parseFloat(0.5); // 1 is set because seesion check will be done at every 30 sec.
//    localStorage.setItem("timeleft", sessionTimeout);  //set
//}



////var current = parseInt(120);
////countdown = function () {
////    //    alert("count down");
////    lblSessionWarning.innerHTML = "Your session will expire in" + current + "sec.";
////    //alert(current);
////    if (current > 0) {
////        setTimeout('countdown()', 1000); // run every second
////        current = current - 1;

////    }
////}


//// below code for countdown timer 

//function StartCountDown(myTargetDate) {
//    var dthen = new Date(myTargetDate);
//    var dnow = new Date();
//    ddiff = new Date(dthen - dnow);
//    gsecs = Math.floor(ddiff.valueOf() / 1000);
//    CountBack(gsecs);
//}

//function Calcage(secs, num1, num2) {
//    s = ((Math.floor(secs / num1)) % num2).toString();
//    if (s.length < 2) {
//        s = "0" + s;
//    }
//    return (s);
//}

//function CountBack(secs) {
//    var DisplayStr;
//    // var DisplayFormat = "%%D%% Days %%H%%:%%M%%:%%S%%";
//    var DisplayFormat = "%%M%%:%%S%%";
//    DisplayStr = DisplayFormat.replace(/%%D%%/g, Calcage(secs, 86400, 100000));
//    DisplayStr = DisplayStr.replace(/%%H%%/g, Calcage(secs, 3600, 24));
//    DisplayStr = DisplayStr.replace(/%%M%%/g, Calcage(secs, 60, 60));
//    DisplayStr = DisplayStr.replace(/%%S%%/g, Calcage(secs, 1, 60));

//    if (isclosetimeout.toLowerCase() == "true") {
//        closeredwindow2(); // close radwindow
//    }
//    else if (secs > 0) {
//        lblSessionWarning.innerHTML = "Your session will expire in " + DisplayStr + " min.";
//        setTimeout("CountBack(" + (secs - 1) + ");", 990);
//    }
//    else {
//        loadradwindow('relogin');
//        closeredwindow2(); // close radwindow
//    }
//}



//function activityfound() {
//    var remainingtime = localStorage.getItem("timeleft"); //get
//    if (remainingtime != null) {
//        if (parseFloat(remainingtime) > 2) {
//            closeredwindow2();
//        }
//    }
//}

//function settimeleft() {
//    // alert(sessionTimeout);
//    DisplaySessionTimeout();
//}


//window.onload = function () {
//    settimeleft();
//    localStorage.setItem("runonce", "");  //set
//};


