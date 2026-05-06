// JScript File
//
var isMozillaselectemail;
var objDivselectemail = null;
var originalDivHTMLselectemail = "";
var DivIDselectemail = "";
var overselectemail = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivselectemail(divIdselectemail, titleselectemail, widthselectemail, heightselectemail, leftselectemail, topselectemail) 
{
//   initselectemail();
   DivIDselectemail = divIdselectemail;
     
    document.getElementById(divIdselectemail).style.width = widthselectemail + 'px';
    document.getElementById(divIdselectemail).style.height = heightselectemail + 'px';
	
	var addHeaderselectemail;
	
	if (originalDivHTMLselectemail == "")
	    originalDivHTMLselectemail = document.getElementById(divIdselectemail).innerHTML;

	addHeaderselectemail = '<table class="border1px" style="width:' + widthselectemail + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="overselectemail=true;" onmouseout="overselectemail=false;" style="cursor:move;height:10px;">' + titleselectemail + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivselectemail(\'' + divIdselectemail + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdselectemail).innerHTML = addHeaderselectemail + originalDivHTMLselectemail;
	
	
	document.getElementById(divIdselectemail).className = 'Subject';
	document.getElementById(divIdselectemail).style.visibility = "visible";


}



function hiddenFloatingDivselectemail(divIdselectemail) 
{
       
	document.getElementById(divIdselectemail).innerHTML = originalDivHTMLselectemail;
	document.getElementById(divIdselectemail).style.visibility="hidden";

	
	DivIDselectemail = "";
}





function MouseDownselectemail(e) 
{
    if (overselectemail)
    {
        if (isMozillaselectemail) {
            objDivselectemail = document.getElementById(DivIDselectemail);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivselectemail = document.getElementById(DivIDselectemail);
            objDivselectemail = objDivselectemail.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMoveselectemail(e) 
{
    if (objDivselectemail) {
        if (isMozillaselectemail) {
            objDivselectemail.style.top = (e.pageY-Y) + 'px';
            objDivselectemail.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivselectemail.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivselectemail.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpselectemail() 
{
    objDivselectemail = null;
}



function initselectemail()
{
    // check browser
    isMozillaselectemail = (document.all) ? 0 : 1;


    if (isMozillaselectemail) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownselectemail;
    document.onmousemove = MouseMoveselectemail;
    document.onmouseup = MouseUpselectemail;

    // add the div
    // used to dim the page
	

}


// JScript File

// JScript File

