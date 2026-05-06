var http;

// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function createRequestObjectattachment()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function ByAjaxattachmentdelete(url)
 {
 var url=url;

  var params = '&' + (new Date()).getTime();
	http=createRequestObjectattachment();
	http.onreadystatechange=Result_Ajaxattachmentdelete; 

	http.open("GET",url  + params, true);
	http.send(null);
	//return true;
    
 }
 
function  Result_Ajaxattachmentdelete(){

    
 if(http.readyState==4)
  {
    var r='';
    r = http.responseText;
      var leadid;
    if( document.getElementById("ctl00_ContentPlaceHolder1_hid_ClientID")!=null)
        leadid = document.getElementById("ctl00_ContentPlaceHolder1_hid_ClientID");
    else
        leadid = document.getElementById("ctl00_ContentPlaceHolder1_hdnleadid");
 
   
    ByAjaxattachmentadd(leadid.value,r);
    
  }
  
 }
 // JScript File

  var httpadd;
 
// ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------

function createRequestObjectattachmentadd()
 { 
	var objXMLHttp=null;
	if (window.XMLHttpRequest)
	    objXMLHttp=new XMLHttpRequest();
	else if (window.ActiveXObject)
	    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
	return objXMLHttp;
 }
 // ---------------------------------HTTP REQUEST OBJECT---------------------------------------------------------------


function ByAjaxattachmentadd(leadid,r)
 {
 
 var url="../common/addattachmentbyajax.aspx?leadid="+leadid+"&sectionName="+r;
 
  var params = '&' + (new Date()).getTime();
	httpadd=createRequestObjectattachmentadd();
	httpadd.onreadystatechange=Result_Ajaxattachment; 

	httpadd.open("GET",url  + params, true);
    httpadd.send(null);
    
 }
 
function  Result_Ajaxattachment(){
 if(httpadd.readyState==4)
  {
    var r='';
    r=httpadd.responseText;
   
    document.getElementById("dddddd").innerHTML =r;

  
    }
    else
    {
    var hdnimagepath=document.getElementById("ctl00_ContentPlaceHolder1_hdnimagepath");
    
      var imageee=hdnimagepath.value+"indicator.gif";
    document.getElementById("dddddd").innerHTML="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img class=normalText style=background-color:white; align=middle src='"+ imageee +"' border=0><span style=color:black class=normalText align=center >Uploading...</span>";
  }
 }