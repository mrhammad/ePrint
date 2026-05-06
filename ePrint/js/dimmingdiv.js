var isMozilla;
var objDiv = null;
var originalDivHTML = "";
var DivID = "";
var over = false;


var http;
// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function createRequestObjectCALL()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function  ByAjaxCALL(url)
 {
 
  var params = url + '&' + (new Date()).getTime();

	http=createRequestObjectCALL();
	http.onreadystatechange=Result_AjaxCALL; 
    
	http.open("GET",params, true);
    http.send(null);
    
    
 }
 
function  Result_AjaxCALL()
{
  var r='';
  if(http.readyState==4)
  {
  r=http.responseText;
//   var hdnCheck=document.getElementById("hdnCheck");
//       if(hdnCheck.value=="0")
//       {
          if(r=='Login')
          {
          hdnCheck.value='';
          alert("Session has been resume sucessfully");
          hiddenFloatingDiv('windowcontent');
          }
          else
          {
          hdnCheck.value='';      
          alert("Please enter valid password");
          }
//      }
//      else
//      {
//      hdnCheck.value='';
//      }
 }
}


function buildDimmerDiv()
{
	var standardbody=(document.compatMode=="CSS1Compat")? document.documentElement : document.body //create reference to common "body" across doctypes
	var docheightcomplete=(standardbody.offsetHeight>standardbody.scrollHeight)? standardbody.offsetHeight : standardbody.scrollHeight
	var docwidthcomplete=(standardbody.offsetWidth>standardbody.scrollWidth)? standardbody.offsetWidth : standardbody.scrollWidth
    document.write('<div id="dimmer" class="dimmer" style="width:'+ docwidthcomplete + 'px; height:' + docheightcomplete +'px"></div>');
}
function displayFloatingDiv(divId, title, width, height, left, top) 
{
	DivID = divId;
	
	document.getElementById('dimmer').style.visibility = "visible";
	var table_ResumeSession=document.getElementById("table_ResumeSession");
	table_ResumeSession.style.display='block';
    document.getElementById(divId).style.width = width + 'px';
    document.getElementById(divId).style.height = height + 'px';
//    document.getElementById(divId).style.left = left + 'px';
//    document.getElementById(divId).style.top = top + 'px';

  if (navigator.appName == "Microsoft Internet Explorer")
	{
	document.getElementById(divId).style.top = parseInt(document.body.scrollTop + screen.height/3) + 'px';
	 document.getElementById(divId).style.left =parseInt(document.body.scrollLeft + (screen.width/3))  + 'px';
	
	}
	else
	{
	document.getElementById(divId).style.top = parseInt(window.pageYOffset + screen.height/3) + 'px';
	document.getElementById(divId).style.left =parseInt(window.pageXOffset + (screen.width/3))  + 'px';
	
	}
    


	var addHeader;
	if (originalDivHTML == "")
	    originalDivHTML = document.getElementById(divId).innerHTML;
//	addHeader = '<table style="width:' + width + 'px" class="floatingHeader">' +
//	            '<tr><td ondblclick="void(0);" onmouseover="over=true;" onmouseout="over=false;" style="cursor:move;height:18px" class=error_yello>' + title + '</td>' + 
//	            '<td style="width:18px" align="right"></td></tr></table>';
    // add to your div an header	
	document.getElementById(divId).innerHTML = originalDivHTML;
	document.getElementById(divId).className = 'dimming';
	document.getElementById(divId).style.visibility = "visible";
	var standardbody=(document.compatMode=="CSS1Compat")? document.documentElement : document.body //create reference to common "body" across doctypes
	var docheightcomplete=(standardbody.offsetHeight>standardbody.scrollHeight)? standardbody.offsetHeight : standardbody.scrollHeight
	var docwidthcomplete=(standardbody.offsetWidth>standardbody.scrollWidth)? standardbody.offsetWidth : standardbody.scrollWidth
	document.getElementById('dimmer').style.width = docwidthcomplete + 'px';
    document.getElementById('dimmer').style.height = docheightcomplete + 'px';
    
     //dropdown
	selects = document.getElementsByTagName("select");
	for (i = 0; i != selects.length; i++) {
		selects[i].disabled='disabled';
	}
}
//
//
//
function hiddenFloatingDiv(divId) 
{
    var table_ResumeSession=document.getElementById("table_ResumeSession");
	table_ResumeSession.style.display='none';
	document.getElementById(divId).innerHTML = originalDivHTML;
	document.getElementById(divId).style.visibility='hidden';
	document.getElementById('dimmer').style.visibility = 'hidden';
	
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
