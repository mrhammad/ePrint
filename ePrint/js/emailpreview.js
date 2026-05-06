// JScript File

// JScript File
//
var isMozillaemailpreview;
var objDivemailpreview = null;
var originalDivHTMLemailpreview = "";
var DivIDselectemailpreview = "";
var overselectemailpreview = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivemailpreview(divIdemailpreview, titleemailpreview, widthemailpreview, heightemailpreview, leftemailpreview, topemailpreview) 
{
  // initselectemail();
   DivIDemailpreview = divIdemailpreview;
     
    document.getElementById(divIdemailpreview).style.width = widthemailpreview + 'px';
    document.getElementById(divIdemailpreview).style.height = heightemailpreview + 'px';
	
	var addHeaderemailpreview;
	
	if (originalDivHTMLemailpreview == "")
	    originalDivHTMLemailpreview = document.getElementById(divIdemailpreview).innerHTML;

	addHeaderemailpreview = '<table class="border1px" style="width:' + widthemailpreview + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="overemailpreview=true;" onmouseout="overemailpreview=false;" style="cursor:move;height:10px;">' + titleemailpreview + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivemailpreview(\'' + divIdemailpreview + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdemailpreview).innerHTML = addHeaderemailpreview + originalDivHTMLemailpreview;
	
	
	document.getElementById(divIdemailpreview).className = 'Subject';
	document.getElementById(divIdemailpreview).style.visibility = "visible";


}



function hiddenFloatingDivemailpreview(divIdemailpreview) 
{
       
	document.getElementById(divIdemailpreview).innerHTML = originalDivHTMLemailpreview;
	document.getElementById(divIdemailpreview).style.visibility="hidden";

	
	DivIDemailpreview= "";
}





function MouseDownemailpreview(e) 
{
    if (overemailpreview)
    {
        if (isMozillaemailpreview) {
            objDivemailpreview = document.getElementById(DivIDemailpreview);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivemailpreview = document.getElementById(DivIDemailpreview);
            objDivemailpreview = objDivemailpreview.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMoveemailpreview(e) 
{
    if (objDivemailpreview) {
        if (isMozillaemailpreview) {
            objDivemailpreview.style.top = (e.pageY-Y) + 'px';
            objDivemailpreview.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivemailpreview.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivemailpreview.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpemailpreview() 
{
    objDivemailpreview = null;
}



function initemailpreview()
{
    // check browser
    isMozillaemailpreview = (document.all) ? 0 : 1;


    if (isMozillaemailpreview) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownemailpreview;
    document.onmousemove = MouseMoveemailpreview;
    document.onmouseup = MouseUpemailpreview;

    // add the div
    // used to dim the page
	

}


// JScript File

// JScript File

