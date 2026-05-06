// JScript File
//
var isMozillaemail;
var objDivmail = null;
var originalDivHTMLmail = "";
var DivIDmail = "";
var overmail = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivmail(divIdmail, titlemail, widthmail, heightmail, leftmail, topmail) 
{
    initmail();
   DivIDmail = divIdmail;
     
    document.getElementById(divIdmail).style.width = widthmail + 'px';
    document.getElementById(divIdmail).style.height = heightmail + 'px';
	
	var addHeadermail;
	
	if (originalDivHTMLmail == "")
	    originalDivHTMLmail = document.getElementById(divIdmail).innerHTML;

	addHeadermail = '<table class="border1px" style="width:' + widthmail + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="overmail=true;" onmouseout="overmail=false;" style="cursor:move;height:10px;">' + titlemail + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivmail(\'' + divIdmail + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdmail).innerHTML = addHeadermail + originalDivHTMLmail;
	
	
	document.getElementById(divIdmail).className = 'Subject';
	document.getElementById(divIdmail).style.visibility = "visible";


}



function hiddenFloatingDivmail(divIdmail) 
{
       
	document.getElementById(divIdmail).innerHTML = originalDivHTMLmail;
	document.getElementById(divIdmail).style.visibility="hidden";

	
	DivIDmail = "";
}





function MouseDownmail(e) 
{
    if (overmail)
    {
        if (isMozillamail) {
            objDivmail = document.getElementById(DivIDmail);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivmail = document.getElementById(DivIDmail);
            objDivmail = objDivmail.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMovemail(e) 
{
    if (objDivmail) {
        if (isMozillamail) {
            objDivmail.style.top = (e.pageY-Y) + 'px';
            objDivmail.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivmail.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivmail.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpmail() 
{
    objDivmail = null;
}



function initmail()
{
    // check browser
    isMozillaemail = (document.all) ? 0 : 1;


    if (isMozillaemail) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownmail;
    document.onmousemove = MouseMovemail;
    document.onmouseup = MouseUpmail;

    // add the div
    // used to dim the page
	

}


// JScript File

