// JScript File


var httpsendmail;
function createRequestObjectsenedmail()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function ByAjaxSendmail(leadid)
 {
 var url="../common/Senedmailbyajax.aspx?leadid="+leadid;
 
  var params = '&' + (new Date()).getTime();
	httpsendmail=createRequestObjectsenedmail();
	httpsendmail.onreadystatechange=Result_Ajaxsendmail; 

	httpsendmail.open("GET",url  + params, true);
    httpsendmail.send(null);
    
 }
 
function  Result_Ajaxsendmail(){
 if(httpsendmail.readyState==4)
  {
    var r='';
    r=httpsendmail.responseText;
    
   document.getElementById("divsend").innerHTML =r;
    
  
  }
  else
  {
    var hdnimagepath=document.getElementById("ctl00_ContentPlaceHolder1_hdnimagepath");
    var imageee=hdnimagepath.value+"indicator.gif";
    document.getElementById("divsend").innerHTML="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img class=normalText style=background-color:white; align=middle src='"+ imageee +"' border=0><span style=color:red class=normalText align=center >Uploading...</span>";
  }
 }




//for dellete
var httpsendmaildelete;
function createRequestObjectsenedmaildelete()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function ByAjaxSendmaildelete(url)
 {
 var url=url;
  
  var params = '&' + (new Date()).getTime();
	httpsendmaildelete=createRequestObjectsenedmail();
	httpsendmaildelete.onreadystatechange=Result_Ajaxsendmaildelete; 

	httpsendmaildelete.open("GET",url  + params, true);
    httpsendmaildelete.send(null);
    
 }
 
function  Result_Ajaxsendmaildelete(){
 if(httpsendmaildelete.readyState==4)
  {
    var r='';
    r=httpsendmaildelete.responseText;
     var leadid=document.getElementById("ctl00_ContentPlaceHolder1_hdnleadid");
   
    ByAjaxSendmail(leadid.value);
   

   
  }
 
 }