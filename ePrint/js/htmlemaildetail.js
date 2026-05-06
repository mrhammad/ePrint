// JScript File
//
var isMozillahtmlemaildetail;
var objDivhtmlemaildetail = null;
var originalDivHTMLhtmlemaildetail= "";
var DivIDhtmlemaildetail = "";
var overhtmlemaildetail = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function displayFloatingDivhtmlemaildetail(divIdhtmlemaildetail, titlehtmlemaildetail, widthhtmlemaildetail, heighthtmlemaildetail, lefthtmlemaildetail, tophtmlemaildetail,color) 
{
   inithtmlemaildetail();
   DivIDhtmlemaildetail = divIdhtmlemaildetail;
     
    document.getElementById(divIdhtmlemaildetail).style.width = widthhtmlemaildetail + 'px';
    document.getElementById(divIdhtmlemaildetail).style.height = heighthtmlemaildetail + 'px';
	
	var addHeaderhtmlemaildetail;
	
	if (originalDivHTMLhtmlemaildetail == "")
	    originalDivHTMLhtmlemaildetail = document.getElementById(divIdhtmlemaildetail).innerHTML;
//<table cellspacing=1 cellpadding=4 border=0 width=100% bgcolor=" + dtr["navigationcolor"].ToString() + " >
	addHeaderhtmlemaildetail = '<table class=headertext bgcolor='+ color +' border=0 style="width:' + widthhtmlemaildetail + 'px;">' +
	            '<tr  style=height:5px><td ondblclick="void(0);" Class="HeaderText" onmouseover="overhtmlemaildetail=true;" onmouseout="overhtmlemaildetail=false;" style="cursor:move;height:10px;">' + titlehtmlemaildetail + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDivhtmlemaildetail(\'' + divIdhtmlemaildetail + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divIdhtmlemaildetail).innerHTML = addHeaderhtmlemaildetail + originalDivHTMLhtmlemaildetail;
	
	
	document.getElementById(divIdhtmlemaildetail).className = 'Subject';
	document.getElementById(divIdhtmlemaildetail).style.visibility = "visible";


}



function hiddenFloatingDivhtmlemaildetail(divIdhtmlemaildetail) 
{
       
	document.getElementById(divIdhtmlemaildetail).innerHTML = originalDivHTMLhtmlemaildetail;
	document.getElementById(divIdhtmlemaildetail).style.visibility="hidden";

	
	DivIDhtmlemaildetail = "";
}





function MouseDownhtmlemaildetail(e) 
{
    if (overhtmlemaildetail)
    {
        if (isMozillahtmlemaildetail) {
            objDivhtmlemaildetail = document.getElementById(DivIDhtmlemaildetail);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDivhtmlemaildetail= document.getElementById(DivIDhtmlemaildetail);
            objDivhtmlemaildetail = objDivhtmlemaildetail.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


function MouseMovehtmlemaildetail(e) 
{
    if (objDivhtmlemaildetail) {
        if (isMozillahtmlemaildetail) {
            objDivhtmlemaildetail.style.top = (e.pageY-Y) + 'px';
            objDivhtmlemaildetail.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDivhtmlemaildetail.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDivhtmlemaildetail.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}


function MouseUphtmlemaildetail() 
{
    objDivhtmlemaildetail = null;
}



function inithtmlemaildetail()
{
    // check browser
    isMozillahtmlemaildetail = (document.all) ? 0 : 1;


    if (isMozillahtmlemaildetail) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDownhtmlemaildetail;
    document.onmousemove = MouseMovehtmlemaildetail;
    document.onmouseup = MouseUphtmlemaildetail;

    // add the div
    // used to dim the page
	

}


// JScript File

// JScript File

// JScript File




var httpemailhtmldeatil;
function createRequestObjectsubject()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
// // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function  ByAjaxemailhtmldeatil(url)
 {
  
    var params = url + '&' + (new Date()).getTime();
   
	httpemailhtmldeatil=createRequestObjectsubject();
	httpemailhtmldeatil.onreadystatechange=Result_Ajaxemailhtmldeatil; 
    
	httpemailhtmldeatil.open("GET",params, true);
    httpemailhtmldeatil.send(null);
    
    
 }

function  Result_Ajaxemailhtmldeatil(){
 
 if(httpemailhtmldeatil.readyState==4)
  {
 
  var r='';
  r=httpemailhtmldeatil.responseText;
  
  document.getElementById('divhtmalemaildetail').innerHTML+=r;
  }
 }
