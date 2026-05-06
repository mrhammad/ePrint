// JScript File
//
var isMozilla2;
var objDiv2 = null;
var originalDivHTML2 = "";
var DivID2 = "";
var over2 = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDiv2(divId2, title2, width2, height2, left2, top2) 
{
//   init2();
   DivID2 = divId2;
     
    document.getElementById(divId2).style.width = width2 + 'px';
    document.getElementById(divId2).style.height = height2 + 'px';
//    document.getElementById(divId1).style.left = left1 + 'px';
//    document.getElementById(divId1).style.top = top1 + 'px';
	
	var addHeader2;
	
	if (originalDivHTML2 == "")
	    originalDivHTML2 = document.getElementById(divId2).innerHTML;

	addHeader2 = '<table class="border1px" style="width:' + width2 + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="over2=true;" onmouseout="over2=false;" style="cursor:move;height:10px;">' + title2 + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDiv2(\'' + divId2 + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divId2).innerHTML = addHeader2 + originalDivHTML2;
	
	
	document.getElementById(divId2).className = 'Subject';
	document.getElementById(divId2).style.visibility = "visible";


}


//
//
//
function hiddenFloatingDiv2(divId2) 
{
       
	document.getElementById(divId2).innerHTML2 = originalDivHTML2;
	document.getElementById(divId2).style.visibility="hidden";

	
	DivID2 = "";
}





function MouseDown2(e) 
{
    if (over2)
    {
        if (isMozilla2) {
            objDiv2 = document.getElementById(DivID2);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDiv2 = document.getElementById(DivID2);
            objDiv2 = objDiv2.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


//
//
//
function MouseMove2(e) 
{
    if (objDiv2) {
        if (isMozilla2) {
            objDiv2.style.top = (e.pageY-Y) + 'px';
            objDiv2.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDiv2.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDiv2.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}

//
//
//
function MouseUp2() 
{
    objDiv2 = null;
}


//
//
//
function init2()
{
    // check browser
    isMozilla2 = (document.all) ? 0 : 1;


    if (isMozilla2) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDown2;
    document.onmousemove = MouseMove2;
    document.onmouseup = MouseUp2;

    // add the div
    // used to dim the page
	

}

// call init



