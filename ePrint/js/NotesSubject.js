
//
var isMozilla1;
var objDiv1 = null;
var originalDivHTML1 = "";
var DivID1 = "";
var over1 = false;



// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------
var http;
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


function  ByAjaxsubject(url)
 {
 
  var params = url + '&' + (new Date()).getTime();
   
	http=createRequestObjectsubject();
	http.onreadystatechange=Result_Ajaxsubject; 
    
	http.open("GET",params, true);
    http.send(null);
    
    
 }
// 
function  Result_Ajaxsubject(){
 
 if(http.readyState==4)
  {
 
  var r='';
  r=http.responseText;
  document.getElementById('showsubject').innerHTML+=r;
  }
 }




function displayFloatingDiv1(divId1, title1, width1, height1, left1, top1,color) 
{
   init1();
   DivID1 = divId1;
     document.getElementById('showsubject').innerHTML='';
    document.getElementById(divId1).style.width = width1 + 'px';
    document.getElementById(divId1).style.height = height1 + 'px';
//    document.getElementById(divId1).style.left = left1 + 'px';
//    document.getElementById(divId1).style.top = top1 + 'px';
	
	var addHeader1;
	
	if (originalDivHTML1 == "")
	    originalDivHTML1 = document.getElementById(divId1).innerHTML;

	addHeader1 = '<table class=headertext style="width:' + width1 + 'px;background-color:' + color + ';">' +
	            '<tr style=height:5px><td ondblclick="void(0);" onmouseover="over1=true;" onmouseout="over1=false;" style="cursor:move;height:10px;">' + title1 + '</td>' + 
	            '<td style="width:10px;" align="right"><a href="javascript:hiddenFloatingDiv1(\'' + divId1 + '\');void(0);">' + 
	            '<img alt="Close..." title="Close..." src="../images/closeSUB.gif" border="0"></a></td></tr></table>';
	

    // add to your div an header	
	document.getElementById(divId1).innerHTML = addHeader1 + originalDivHTML1;
	
	
	document.getElementById(divId1).className = 'Subject';
	document.getElementById(divId1).style.visibility = "visible";


}


//
//
//
function hiddenFloatingDiv1(divId1) 
{
       
	document.getElementById(divId1).innerHTML1 = originalDivHTML1;
	document.getElementById(divId1).style.visibility="hidden";

	
	DivID1 = "";
}





function MouseDown1(e) 
{
    if (over1)
    {
        if (isMozilla1) {
            objDiv1 = document.getElementById(DivID1);
            X = e.layerX;
            Y = e.layerY;
            return false;
        }
        else {
            objDiv1 = document.getElementById(DivID1);
            objDiv1 = objDiv1.style;
            X = event.offsetX;
            Y = event.offsetY;
        }
    }
}


//
//
//
function MouseMove1(e) 
{
    if (objDiv1) {
        if (isMozilla1) {
            objDiv1.style.top = (e.pageY-Y) + 'px';
            objDiv1.style.left = (e.pageX-X) + 'px';
            return false;
        }
        else 
        {
            objDiv1.pixelLeft = event.clientX-X + document.body.scrollLeft;
            objDiv1.pixelTop = event.clientY-Y + document.body.scrollTop;
            return false;
        }
    }
}

//
//
//
function MouseUp1() 
{
    objDiv1 = null;
}


//
//
//
function init1()
{
    // check browser
    isMozilla1 = (document.all) ? 0 : 1;


    if (isMozilla1) 
    {
        document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);
    }

    document.onmousedown = MouseDown1;
    document.onmousemove = MouseMove1;
    document.onmouseup = MouseUp1;

    // add the div
    // used to dim the page
	

}

// call init

