function zxcWWHS(){
 if (document.all){
  zxcCur='hand';
  zxcWH=document.documentElement.clientHeight;
  zxcWW=document.documentElement.clientWidth;
  zxcWS=document.documentElement.scrollTop;
  if (zxcWH==0){
   zxcWS=document.body.scrollTop;
   zxcWH=document.body.clientHeight;
   zxcWW=document.body.clientWidth;
  }
 }
 else if (document.getElementById){
  zxcCur='pointer';
  zxcWH=window.innerHeight-15;
  zxcWW=window.innerWidth-15;
  zxcWS=window.pageYOffset;
 }
 zxcWC=Math.round(zxcWW/2);
 return [zxcWW,zxcWH,zxcWS];
}

window.onscroll=function(){
    var img = document.getElementById('fred');
    if (img != 'undefined' && img != undefined && img != null) {
        if (!document.all) { img.style.position = 'fixed'; window.onscroll = null; return; }
        if (!img.pos) { img.pos = img.offsetTop; }
        img.style.top = (zxcWWHS()[2] + img.pos) + 'px';
    }
}
// Set slideShowSpeed (milliseconds)

isIE=document.all;
isNN=!document.all&&document.getElementById;
isN4=document.layers;
isHot=false;

function ddInit(e){
  topDog=isIE ? "BODY" : "HTML";
  whichDog=isIE ? document.all.theLayer : document.getElementById("theLayer");  

  
  hotDog=isIE ? event.srcElement : e.target;  
  while (hotDog.id!="titleBar"&&hotDog.tagName!=topDog){
    hotDog=isIE ? hotDog.parentElement : hotDog.parentNode;
  }  
  if (hotDog.id=="titleBar"){
    offsetx=isIE ? event.clientX : e.clientX;
    offsety=isIE ? event.clientY : e.clientY;
    nowX=parseInt(whichDog.style.left);
    nowY=parseInt(whichDog.style.top);
    ddEnabled=true;
    document.onmousemove=dd;
  }
}

function dd(e){
  if (!ddEnabled) return;
  whichDog.style.left=isIE ? nowX+event.clientX-offsetx : nowX+e.clientX-offsetx; 
  whichDog.style.top=isIE ? nowY+event.clientY-offsety : nowY+e.clientY-offsety;
  return false;  
}

function ddN4(whatDog){
  if (!isN4) return;
  N4=eval(whatDog);
  N4.captureEvents(Event.MOUSEDOWN|Event.MOUSEUP);
  N4.onmousedown=function(e){
    N4.captureEvents(Event.MOUSEMOVE);
    N4x=e.x;
    N4y=e.y;
  }
  N4.onmousemove=function(e){
    if (isHot){
      N4.moveBy(e.x-N4x,e.y-N4y);
      return false;
    }
  }
  N4.onmouseup=function(){
    N4.releaseEvents(Event.MOUSEMOVE);
  }
}

function hideMe(){
  if (isIE||isNN) whichDog.style.visibility="hidden";
  else if (isN4) document.theLayer.visibility="hide";
}

function showMe(i,deleteid){
  if (isIE||isNN) whichDog.style.visibility="visible";
  else if (isN4) document.theLayer.visibility="show";
  var txtdis=document.getElementById("ctl00_ContentPlaceHolder1_txtdescription"); 
  txtdis.focus();
  txtdis.value='';
  var hdn=document.getElementById("ctl00_ContentPlaceHolder1_hdn");
  hdn.value='';
  var btn=document.getElementById("ctl00_ContentPlaceHolder1_btnSubmit");
  var hiddeleteid=document.getElementById("ctl00_ContentPlaceHolder1_hiddeleteid");
  hiddeleteid.value=deleteid;
  if(i=='1')
  {
    txtdis.style.display='none';
    var divby=document.getElementById("divby");
    var divdate =document.getElementById("divdate");
    divby.style.display='none';
    divdate.style.display='none';
    var dibdiscription=document.getElementById("dibdiscription");
    dibdiscription.style.display='none';
    btn.value='Delete';
    hdn.value='Delete';
    var divconfirm=document.getElementById("divconfirm");
    divconfirm.style.display='block';
  }
  else if(i=='2')
  {
    txtdis.style.display='block';
    var divby=document.getElementById("divby");
    var divdate =document.getElementById("divdate");
    divby.style.display='block';
    divdate.style.display='block';
    var dibdiscription=document.getElementById("dibdiscription");
    dibdiscription.style.display='block';
    btn.value='Update';
    hdn.value='Update';
    var divconfirm=document.getElementById("divconfirm");
    divconfirm.style.display='none';
  }
  else
  {
    txtdis.style.display='block';
    var divby=document.getElementById("divby");
    var divdate =document.getElementById("divdate");
    divby.style.display='block';
    divdate.style.display='block';
    var dibdiscription=document.getElementById("dibdiscription");
    dibdiscription.style.display='block';
    btn.value='Add Note';
    hdn.value='Submit';
    var divconfirm=document.getElementById("divconfirm");
    divconfirm.style.display='none';
  }
}
document.onmousedown=ddInit;
document.onmouseup=Function("ddEnabled=false");

function RefreshMyData()    
{     
    window.document.forms[0].submit();    
    
}

var http;
  
// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function createRequestObject()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function ByAjax(url,id)
 {
  var params = '&' + (new Date()).getTime();
	http=createRequestObject();
	http.onreadystatechange=Result_Ajax; 
//	alert('"<%=url%>"');
	http.open("GET",url  + params, true);
    http.send(null);
    
    var hidid=document.getElementById("ctl00_ContentPlaceHolder1_hidid");
    hidid.value=id;
//    alert(id);
 }
 
function  Result_Ajax(){
 if(http.readyState==4)
  {
    var r='';
    r=http.responseText;
    var btn=document.getElementById("ctl00_ContentPlaceHolder1_btnSubmit");
    btn.value='Update';
    var hdn=document.getElementById("ctl00_ContentPlaceHolder1_hdn");
    hdn.value='Update';
    var hdntxt=document.getElementById("ctl00_ContentPlaceHolder1_hidtext");
    hdntxt.value=r;
    var t=document.getElementById("ctl00_ContentPlaceHolder1_txtdescription");
    t.value=hdntxt.value;
  }
 }
 
  
 
// //for change color 
//var speed=500
//var Color;
//var i=0;
//function flashit()
//{
//    var changeColor=document.getElementById("divColorChange");
//    if(i==0)
//    {
//     Color=changeColor.style.background;
//    }
//    var crosstable=document.getElementById? document.getElementById("divColorChange") : document.all? document.all.subcontent : ""
//    if (crosstable)
//    {
//        if (crosstable.style.background.indexOf(Color)!=-1)
//        {
//        crosstable.style.background="#76a44e"
//        }
//        else
//        {
//        crosstable.style.background=Color;
//        }
//    }
//    i=i+1;
//}
//setInterval("flashit()", speed)
