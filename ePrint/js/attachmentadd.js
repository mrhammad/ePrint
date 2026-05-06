// JScript File
//
var isMozillaattachmentadd;
var objDivattachmentadd = null;
var originalDivHTMLattachmentadd = "";
var DivIDattachmentadd = "";
var overattachmentadd = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivattachmentadd(divIdattachmentadd, titlattachmentadd, widthattachmentadd, heightattachmentadd, leftattachmentadd, topattachmentadd,color) 
{
   initattachmentadd();
   DivIDattachmentadd = divIdattachmentadd;
   
     
    document.getElementById(divIdattachmentadd).style.width = widthattachmentadd + 'px';
    document.getElementById(divIdattachmentadd).style.height = heightattachmentadd + 'px';

    var leftattachmentadd = (window.screen.width - leftattachmentadd) / 1.75;
    var topattachmentadd = (window.screen.height - topattachmentadd) / 2.4;
   
    if (navigator.appName == "Microsoft Internet Explorer")
	{
	document.getElementById(divIdattachmentadd).style.top = parseInt(document.body.scrollTop + ((screen.height/2)-(heightattachmentadd))) + 'px';
	document.getElementById(divIdattachmentadd).style.left =parseInt(document.body.scrollLeft + ((screen.width/2)-(widthattachmentadd/2)))  + 'px';
	}
	else
	{
	document.getElementById(divIdattachmentadd).style.top = topattachmentadd + 'px';
	document.getElementById(divIdattachmentadd).style.left =parseInt(window.pageXOffset + ((screen.width/2)-(widthattachmentadd/2)))  + 'px';
	}

    
	var addHeaderattachmentadd;	    
	    originalDivHTMLattachmentadd='';

	    if (originalDivHTMLattachmentadd == "")	        
	    originalDivHTMLattachmentadd = document.getElementById(divIdattachmentadd).innerHTML;


//	addHeaderattachmentadd = '<table id=1122334455 class="CenterDiv_new" style="width:' + widthattachmentadd + 'px;background-color:' + color + '">' +
//	            '<tr style=height:5px><td ondblclick="void(0);" Class="navigatorpanel" onmouseover="overattachmentadd=true;" onmouseout="overattachmentadd=false;" style="cursor:move;height:10px;">' + titlattachmentadd + '</td>' + 
//	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivattachmentadd(\'' + divIdattachmentadd + '\');void(0);">' +
//	            '<img border="0" width="11px" height="11px"  title="Close" src="../images/close1.jpg" border="0"></a></td></tr></table>';

//    addHeaderattachmentadd = '<table cellpadding="0" cellspacing="0" style="width:' + widthattachmentadd + 'px;">'+'<tr>'+'<td colspan="2" class="popup-top-leftcorner">&nbsp;</td>'+
//                         '<td class="popup-top-middlebg">'+'<div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px"><b>' + titlattachmentadd + '</b></div></td>'+
//                         '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivattachmentadd(\'' + divIdattachmentadd + '\');void(0);">'+
//                         '<div style="float: right; padding-top: 6px; padding-right: 10px">'+'<div class="CancelButtonDiv">'+
//                         '<img border="0" width="11px" height="11px"  title="Close" src="~/images/closebtn.png" CausesValidation="false" OnClientClick="javascript:hideDivNew();" />' + '</td>' +
//                         '<td colspan="2" class="popup-top-rightcorner"> &nbsp;</td></tr>'
//                           +'<tr><td class="popup-middle-leftcorner">&nbsp;</td>'+
//                         '<td style="width: 15px; background-color: #ffffff">&nbsp;</td>'+
//                         '<td class="popup-middlebg" align="center">'
                           

    // add to your div an header	   
	var patt1 = new RegExp("1122334455");
	//alert(patt1.test("" + originalDivHTMLattachmentadd + "") == false); 
    if(patt1.test(""+originalDivHTMLattachmentadd+"")==false)
    {
        document.getElementById(divIdattachmentadd).innerHTML =  originalDivHTMLattachmentadd; //addHeaderattachmentadd
	}
	
	//document.getElementById(divIdattachmentadd).className = 'Subject';
	document.getElementById(divIdattachmentadd).style.visibility = "visible";
}

function hideDivNew(divIdattachmentadd) {
    window.parent.document.getElementById(divIdattachmentadd).style.visibility = "hidden";
    document.getElementById("divBackGroundNew").style.display = "none";
}


function hiddenFloatingDivattachmentadd(divIdattachmentadd) 
{
    document.getElementById(divIdattachmentadd).innerHTML = originalDivHTMLattachmentadd;
	document.getElementById(divIdattachmentadd).style.visibility="hidden";
	
	DivIDattachmentadd = "";
}


function MouseDownattachmentadd(e) 
{
    if (overattachmentadd)
    {
        if (isMozillaattachmentadd) {
            objDivattachmentadd = document.getElementById(DivIDattachmentadd);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivattachmentadd = document.getElementById(DivIDattachmentadd);
            objDivattachmentadd = objDivattachmentadd.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMoveattachmentadd(e) 
{
    if (objDivattachmentadd) {
        if (isMozillaattachmentadd) {
            objDivattachmentadd.style.top = (e.pageY-Y) + 'px';
            objDivattachmentadd.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivattachmentadd.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivattachmentadd.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUpattachmentadd() 
{
    objDivattachmentadd = null;
}



function initattachmentadd()
{
    // check browser
    isMozillaattachmentadd = (document.all) ? 0 : 1;


    if (isMozillaattachmentadd) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownattachmentadd;
    document.onmousemove = MouseMoveattachmentadd;
    document.onmouseup = MouseUpattachmentadd;

    // add the div
    // used to dim the page
	

}


// JScript File

// JScript File

