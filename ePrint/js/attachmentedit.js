// JScript File

// JScript File
//
var isMozillaattachmentedit;
var objDivattachmentedit = null;
var originalDivHTMLattachmentedit = "";
var DivIDattachmentedit = "";
var overattachmentedit = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivattachmentedit(divIdattachmentedit, titlattachmentedit, widthattachmentedit, heightattachmentedit, leftattachmentedit, topattachmentedit,color) 
{
   initattachmentedit();
   DivIDattachmentedit = divIdattachmentedit;
     
    document.getElementById(divIdattachmentedit).style.width = widthattachmentedit + 'px';
    document.getElementById(divIdattachmentedit).style.height = heightattachmentedit + 'px';

    var leftattachmentedit = (window.screen.width - leftattachmentedit) / 1.75;
    var topattachmentedit = (window.screen.height - topattachmentedit) / 2.4;
    
    if (navigator.appName == "Microsoft Internet Explorer")
	{
	document.getElementById(divIdattachmentedit).style.top = parseInt(document.body.scrollTop + ((screen.height/2)-(heightattachmentedit))) + 'px';
	document.getElementById(divIdattachmentedit).style.left =parseInt(document.body.scrollLeft + ((screen.width/2)-(widthattachmentedit/2)))  + 'px';
	}
	else
	{
	    document.getElementById(divIdattachmentedit).style.top = topattachmentedit + 'px';
	document.getElementById(divIdattachmentedit).style.left =parseInt(window.pageXOffset + ((screen.width/2)-(widthattachmentedit/2)))  + 'px';
	}


	var addHeaderattachmentadd;
	
	if (originalDivHTMLattachmentedit== "")
	    originalDivHTMLattachmentedit = document.getElementById(divIdattachmentedit).innerHTML;

	addHeaderattachmentedit = '<table class="CenterDiv_new"  style="width:' + widthattachmentedit + 'px;background-color:' + color + '">' +
	            '<tr  style=height:5px><td ondblclick="void(0);" Class="navigatorpanel" onmouseover="overattachmentedit=true;" onmouseout="overattachmentedit=false;" style="cursor:move;height:10px;">' + titlattachmentedit + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivattachmentedit(\'' + divIdattachmentedit + '\');void(0);">' +
	            '<img border="0" width="11px" height="11px"  title="Close" src="../images/close1.jpg" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdattachmentedit).innerHTML = addHeaderattachmentedit + originalDivHTMLattachmentedit;
	
	
	document.getElementById(divIdattachmentedit).className = 'Subject';
	document.getElementById(divIdattachmentedit).style.visibility = "visible";


}



function hiddenFloatingDivattachmentedit(divIdattachmentedit) 
{
       
	document.getElementById(divIdattachmentedit).innerHTML = originalDivHTMLattachmentadd;
	document.getElementById(divIdattachmentedit).style.visibility="hidden";

	
	DivIDattachmentadd = "";
}





function MouseDownattachmentedit(e) 
{
    if (overattachmentedit)
    {
        if (isMozillaattachmentedit) {
            objDivattachmentedit = document.getElementById(DivIDattachmentedit);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivattachmentedit = document.getElementById(DivIDattachmentedit);
            objDivattachmentedit = objDivattachmentedit.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMoveattachmentedit(e) 
{
    if (objDivattachmentedit) {
        if (isMozillaattachmentedit) {
            objDivattachmentedit.style.top = (e.pageY-Y) + 'px';
            objDivattachmentedit.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivattachmentedit.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivattachmentedit.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpattachmentedit() 
{
    objDivattachmentedit = null;
}



function initattachmentedit()
{
    // check browser
    isMozillaattachmentedit = (document.all) ? 0 : 1;


    if (isMozillaattachmentedit) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownattachmentedit;
    document.onmousemove = MouseMoveattachmentedit;
    document.onmouseup = MouseUpattachmentedit;

    // add the div
    // used to dim the page
	

}


// JScript File

// JScript File

