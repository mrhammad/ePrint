var isMozillaselecttemplate;
var objDivselecttemplate = null;
var originalDivHTMLselecttemplate = "";
var DivIDselecttemplate = "";
var overselecttemplate = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivselecttemplate(divIdselecttemplate, titleselecttemplate, widthselecttemplate, heightselecttemplate, leftselecttemplate, topselecttemplate) 
{
//   initselectemail();
   DivIDselecttemplate = divIdselecttemplate;
     
    document.getElementById(divIdselecttemplate).style.width = widthselecttemplate + 'px';
    document.getElementById(divIdselecttemplate).style.height = heightselecttemplate + 'px';
	
	var addHeaderselecttemplate;
	
	if (originalDivHTMLselecttemplate== "")
	    originalDivHTMLselecttemplate = document.getElementById(divIdselecttemplate).innerHTML;

	addHeaderselecttemplate = '<table class="border1px" style="width:' + widthselecttemplate + 'px;">' +
	            '<tr class="actionpanel" style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="overselecttemplate=true;" onmouseout="overselectetemplate=false;" style="cursor:move;height:10px;">' + titleselecttemplate + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivselecttemplate(\'' + divIdselecttemplate + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdselecttemplate).innerHTML = addHeaderselecttemplate + originalDivHTMLselecttemplate;
	
	
	document.getElementById(divIdselecttemplate).className = 'Subject';
	document.getElementById(divIdselecttemplate).style.visibility = "visible";


}



function hiddenFloatingDivselecttemplate(divIdselecttemplate) 
{
       
	document.getElementById(divIdselecttemplate).innerHTML = originalDivHTMLselecttemplate;
	document.getElementById(divIdselecttemplate).style.visibility="hidden";

	
	DivIDselecttemplate = "";
}





function MouseDownselecttemplate(e) 
{
    if (overselecttemplate)
    {
        if (isMozillaselecttemplate) {
            objDivselecttemplate = document.getElementById(DivIDselecttemplate);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivselecttemplate = document.getElementById(DivIDselecttemplate);
            objDivselecttemplate = objDivselecttemplate.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMoveselecttemplate(e) 
{
    if (objDivselecttemplate) {
        if (isMozillaselecttemplate) {
            objDivselecttemplate.style.top = (e.pageY-Y) + 'px';
            objDivselecttemplate.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivselecttemplate.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivselecttemplate.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpselecttemplate() 
{
    objDivselecttemplate = null;
}



function initselecttemplate()
{
    // check browser
    isMozillaselecttemplate = (document.all) ? 0 : 1;


    if (isMozillaselecttemplate) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownselecttemplate;
    document.onmousemove = MouseMoveselecttemplate;
    document.onmouseup = MouseUpselecttemplate;

    // add the div
    // used to dim the page
	

}




