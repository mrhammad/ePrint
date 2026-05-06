// JScript File


var http;
var txtID;
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


function ByAjax_CheckAlias(idd)
 {
 //var txtAlias=document.getElementById("ctl00_ContentPlaceHolder1_txtAlias");
 txtID=idd;
 
 var txtAlias=document.getElementById(idd);
 var url;
 if(txtAlias.id=='ctl00_ContentPlaceHolder1_txtAlias')
 {
 url="check_duplicate_Alias.aspx?AliasName="+txtAlias.value;
 }
 else
 {
 url="check_duplicate_Alias.aspx?Email_Address="+txtAlias.value;
 }
  var params = '&' + (new Date()).getTime();
	http=createRequestObject();
	http.onreadystatechange=Result_Ajax; 

	http.open("GET",url  + params, true);
    http.send(null);
    
 }
 
function  Result_Ajax(){
 if(http.readyState==4)
  {
    var r='';
    r=http.responseText;
     
    var txtAlias=document.getElementById(txtID);
    var url;
   
    var divid=document.getElementById("divAlias");
        if(r!='')
        {
        divid.style.display='block';
        divid.innerHTML=r;
        txtAlias.value='';
        txtAlias.focus();
        }
        else
        {
        divid.style.display='none';
        }
   
  }
 }
