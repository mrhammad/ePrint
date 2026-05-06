// JScript File
//
var isMozilla4;
var objDiv4 = null;
var originalDivHTML4 = "";
var DivID4 = "";
var over4 = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDiv4(divId4, title4, width4, height4, left4, top4) 
{
  // init4();
   DivID4 = divId4;
     
    document.getElementById(divId4).style.width = width4 + 'px';
    document.getElementById(divId4).style.height = height4 + 'px';
	
	var addHeader4;
	
	if (originalDivHTML4 == "")
	    originalDivHTML4 = document.getElementById(divId4).innerHTML;

	addHeader4 = '<table class="border1px" style="width:' + width4 + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="over4=true;" onmouseout="over4=false;" style="cursor:move;height:10px;">' + title4 + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDiv4(\'' + divId4 + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divId4).innerHTML = addHeader4 + originalDivHTML4;
	
	
	document.getElementById(divId4).className = 'Subject';
	document.getElementById(divId4).style.visibility = "visible";


}



function hiddenFloatingDiv4(divId4) 
{
       
	document.getElementById(divId4).innerHTML = originalDivHTML4;
	document.getElementById(divId4).style.visibility="hidden";

	
	DivID4 = "";
}





function MouseDown4(e) 
{
    if (over4)
    {
        if (isMozilla4) {
            objDiv4 = document.getElementById(DivID4);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDiv4 = document.getElementById(DivID4);
            objDiv4 = objDiv4.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMove4(e) 
{
    if (objDiv4) {
        if (isMozilla4) {
            objDiv4.style.top = (e.pageY-Y) + 'px';
            objDiv4.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDiv4.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDiv4.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUp4() 
{
    objDiv4 = null;
}



function init4()
{
    // check browser
    isMozilla4 = (document.all) ? 0 : 1;


    if (isMozilla4) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDown4;
    document.onmousemove = MouseMove4;
    document.onmouseup = MouseUp4;

    // add the div
    // used to dim the page
	

}


