// JScript File
var isMozilla;
var objDiv = null;
var originalDivHTML = "";
var DivID = "";
var over = false;

function buildDimmerDiv()
{
   
	var standardbody=(document.compatMode=="CSS1Compat")? document.documentElement : document.body //create reference to common "body" across doctypes
	//var docheightcomplete=(standardbody.offsetHeight>standardbody.scrollHeight)? standardbody.offsetHeight : standardbody.scrollHeight
	//var docwidthcomplete=(standardbody.offsetWidth>standardbody.scrollWidth)? standardbody.offsetWidth : standardbody.scrollWidth
	
    document.write('<div id="dimmer"  class="dimmer" style="width:10px; height:10px;visibility:hidden;display:none"></div>');
	
}


 function displayCommon(divid)
	    {
		  
		    
	        var w, h, l, t;
	        w = 400;
	        h = 300;
	        l = screen.width/4;
	        t = screen.height/2;
	        displayFloatingDiv(divid, 'Payment', w, h, l, t);
        	
	    }

function displayFloatingDiv(divId, title, width, height, left, top) 
{
  
    originalDivHTML='';
	DivID = divId;
	
	document.getElementById(divId).style.visibility = "visible";
	document.getElementById(divId).style.display = "block";
	document.getElementById(divId).focus();
    document.getElementById(divId).style.width = width + 'px';
	 
    if (navigator.appName == "Microsoft Internet Explorer")
	{
    document.getElementById(divId).style.top = parseInt(document.body.scrollTop + screen.height/15) + 'px';/*3,4,6,4*/
	document.getElementById(divId).style.left =parseInt(document.body.scrollLeft + (screen.width/5))  + 'px';
	}
	else
	{
	document.getElementById(divId).style.top = parseInt(window.pageYOffset + screen.height/6) + 'px';
	document.getElementById(divId).style.left =parseInt(window.pageXOffset + (screen.width/4))  + 'px';
	}
	var addHeader;
	if (originalDivHTML == "")
	    originalDivHTML = document.getElementById(divId).innerHTML;
		
	addHeader = '<table style="width:' + width + 'px" class="floatingHeader">' +
	            '<tr><td ondblclick="void(0);" onmouseover="over=true;" onmouseout="over=false;" style="cursor:move;height:18px">' + title + '</td>' + 
	            '<td style="width:18px" align="right"></td></tr></table>';
			
    // add to your div an header	
	document.getElementById(divId).innerHTML = originalDivHTML;
	document.getElementById(divId).className = 'dimming';
	var standardbody=(document.compatMode=="CSS1Compat")? document.documentElement : document.body //create reference to common "body" across doctypes
	var docheightcomplete=(standardbody.offsetHeight>standardbody.scrollHeight)? standardbody.offsetHeight : standardbody.scrollHeight
	var docwidthcomplete=(standardbody.offsetWidth>standardbody.scrollWidth)? standardbody.offsetWidth : standardbody.scrollWidth
	document.getElementById('dimmer').style.visibility = "visible";
	document.getElementById('dimmer').style.display = "block";
	document.getElementById('dimmer').style.width = docwidthcomplete + 'px';
    document.getElementById('dimmer').style.height = docheightcomplete + 'px';
	
     //dropdown
	//selects = document.getElementsByTagName("select");
	//for (i = 0; i != selects.length; i++) {
		//selects[i].disabled='disabled';
	//}
	

}
function hiddenFloatingDiv(divId) 
{
   
  
	document.getElementById(divId).innerHTML = originalDivHTML;
	document.getElementById(divId).style.visibility='hidden';
	document.getElementById(divId).style.display='none';
	document.getElementById('dimmer').style.visibility = 'hidden';
	document.getElementById('dimmer').style.display = 'none';
	
	DivID = "";
	
	 //dropdown
	selects = document.getElementsByTagName("select");
	for (i = 0; i != selects.length; i++) {
		selects[i].disabled=false;
	}
}

//
//
//
function MouseDown(e) 
{
    if (over)
    {
        if (isMozilla) {
            objDiv = document.getElementById(DivID);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDiv = document.getElementById(DivID);
            objDiv = objDiv.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


//
//
//
function MouseMove(e) 
{
    if (objDiv) {
        if (isMozilla) {
            objDiv.style.top = (e.pageY-Y) + 'px';
            objDiv.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDiv.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDiv.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}
function MouseUp() 
{
    objDiv = null;
}

function init()
{
    // check browser
    isMozilla = (document.all) ? 0 : 1;


    if (isMozilla) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDown;
    document.onmousemove = MouseMove;
    document.onmouseup = MouseUp;

    // add the div
    // used to dim the page
    
	
 buildDimmerDiv();
  
}


// call init
init();
