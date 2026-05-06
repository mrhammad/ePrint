// JScript File
var valu_refresh = 0;
window.onbeforeunload = function (evt) {
if(valu_refresh==0)
{
    var message = 'You will lose all modifications to this document.';
    if (typeof evt == 'undefined') {
    evt = window.event;
    }
    if (evt) {
    evt.returnValue = message;
    }
    return message;
    }
}

/*
Form State v 1.2
copyright 2007 Thomas Frank

This program is free software under the terms of the 
GNU General Public License version 2 as published by the Free 
Software Foundation. It is distributed without any warranty.
*/
formState={
	eventsBeforeStore:true,
	onStateChange:false,
	init:function(){
		// add to onload
		if(!formState.onloadAdded){
			formState.onloadAdded=true;
			(function(){var ol=onload;onload=function(){if(ol){ol()};formState.init()}})();
			return
		};
		// modify/create event handlers on all form elements
		var f=document.forms
		for(var i=0;i<f.length;i++){
			if(!f[i].id || (f[i].id && f[i].id.indexOf("odsform")<0)){continue};
			var byKey=f[i].id.indexOf('_keystroke')>=0;
			f[i].id=f[i].id.replace(/_undoable/,'').replace(/_keystroke/,'');
			var e=f[i].elements;
			for(var j=0;j<e.length;j++){
				(function(){
					var eh='onchange';
					eh=e[j].type=="radio"?'onclick':eh;
					eh=e[j].type=="checkbox"?'onclick':eh;
					eh=e[j].type=="text" && byKey?'onkeyup':eh;
					eh=e[j].type=="textarea" && byKey?'onkeyup':eh;
					var oc=e[j][eh]
					var fo=f[i];
					e[j][eh]=function(){
						if(oc && formState.eventsBeforeStore){oc()};
						formState.store(fo);
						if(oc && !formState.eventsBeforeStore){oc()};
					};
				})();	
			};
			this.store(f[i]);
		}
	},
	store:function(f){
		// store changes in a form
		var a=f.cloneNode(true);
		if (a.elements.length==0){ 
			// in Safari we need to append a (our cloned form) to something
			// and keep it appended before we can read the elements correctly
			// fishy... but let's do a workaround
			this.Safari=true;
			a.style.display="none";	a.id="formStateSafFix";f.parentNode.appendChild(a);
		};
		a.formStatePrev=f.formStatePrev;
		this.readBack(f,a);
		if(!f.formStateMem){f.formStateMem=[];f.formStateCo=0};
		f.formStateCo++;
		while(f.formStateMem.length>f.formStateCo){f.formStateMem.pop()};
		f.formStateMem[f.formStateCo]=a;
		this.checkQueue(f)
	},
	readBack:function(f,a){
		// read back values to form and check if different
		var fe=f.elements, ae=a.elements, d=false;
		for(var i=0;i<fe.length;i++){
			d=d || ae[i].checked!=fe[i].checked;
			ae[i].checked=fe[i].checked;
			// Safari textarea.values can not be read if style.display="none"
			// let's do another workaround and use "valueHolder" instead
			var ap=a.id=="formStateSafFix"?"valueHolder":"value";
			var fp=f.id=="formStateSafFix"?"valueHolder":"value";
			d=d || ae[i][ap]!=fe[i][fp];
			ae[i][ap]=fe[i][fp];
		};
		return d
	},
	checkQueue:function(f){
		// check if we currently can undo/redo anything
		var undoable=f.formStateCo>1;
		var redoable=f.formStateMem.length-f.formStateCo>1;
		if(f.elements.Undo){f.elements.Undo.disabled=!undoable};
		if(f.elements.Redo){f.elements.Redo.disabled=!redoable};
		if(this.onStateChange){this.onStateChange(f,undoable,redoable)}
	},
	undo:function(a,r){
		if(!r){r=-1};
		var tN=a.tagName.toLowerCase()||"";
		if(a.parentNode && tN!="form"){a=a.parentNode;return this.undo(a,r)};
		if(!a.formStateMem){return false};
		var f=a.formStateMem[a.formStateCo+r];
		if(!f){return false};
		a.formStateCo+=r;
		if(!this.readBack(f,a)){return this.undo(a,r)};
		this.checkQueue(a);
		return true
	},
	redo:function(a){return this.undo(a,1)}
};
formState.init();

//var divsarray = new Array();
//var imgsarray = new Array();
//var divids='';
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadimage() { //v3.0
  var d=document; if(d.image){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadimage.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

//-----------------------------------ASSIGN VALUE TO FRAME-------------------
function createRequestObject()
{ 
 if (window.XMLHttpRequest)
    objXMLHttp=new XMLHttpRequest();
else if (window.ActiveXObject)
    objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
return objXMLHttp;
}

function create_image(value,font_name,font_size,id)
{
	var url="createimage.html?value="+value+"&font_name="+font_name+"&font_size="+font_size+"&id="+id; 
 	http1=createRequestObject();
    http1.onreadystatechange=create_image_Response; 
    http1.open("GET",url);
	http1.send(null);
}

function create_image_Response(id)
{
    if(http1.readyState==4)
    {
        var r=http1.responseText;
        //alert(r);
        //return false;
        var separate_strings = r.split('|||',2);
        var sub_f 			= 	frames['template'];
        var img 			= 	sub_f.document.getElementById("img"+trim(separate_strings[1]));
        img.src			=	'odsimages/'+trim(separate_strings[0]);
        var sub_f 			= 	frames['template'];
        sub_f.putcanvas("img"+trim(separate_strings[1]),false)
        //sub_f.document.getElementById("img"+separate_strings[1]).value	=	image_path;
    }
    else
    {
    }
}
function trim(str) 
{
    str = this != window? this : str;
    return str.replace(/^\s+/, '').replace(/\s+$/, '');
}
function showpanel()
{
    document.getElementById('ctl00_ContentPlaceHolder1_pnlToolBar').style.display = '';
}
function assignValue(xobj,id,val) 
{    
    for(var i=1;i<=5;i++)
    {
        var sub_f = frames['template'];
        var div = sub_f.document.getElementById("div"+i);
        if(i==id)
        {
            create_image(xobj.value,document.getElementById('fontName').value,document.getElementById('fontSize').value,id)
        }
        else
        {
        }
    }
}

//-----------------------------------------GET EXTENSION---------------------------------

function getExt(filename) 
{
    var dot_pos = filename.lastIndexOf(".");
    if(dot_pos == -1)
    return "";
    return filename.substr(dot_pos+1).toLowerCase();
}
	
//----------------------------------------UPDATE ARTWORK WITH NEW IMAGE------------------
function Clear()
{
window.location="index.php";
}
//----------------------------------------UPDATE ARTWORK WITH NEW IMAGE------------------

var theForm = document.forms['odsform'];
if (!theForm) {
    theForm = document.odsform;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}

function loadObjects()
{
    ////CreateCtrl(CtrlType,CtrlID,CtrlValue,CtrlName,CtrlMaxLen,CtrlSize,CtrlFont,CtrlFontSize,CtrlFontWeight,CtrlStyle,CtrlLeft,CtrlTop,CtrlWidth,CtrlHeight,CtrlColor,CtrlIsUnderline,CtrlLSpace,CtrlAlign,ConReq,CanEditText,CanMoveObject,ReqNumericValue,MaxChar,RotatAngle,CanChangeFont,CanChangeFontSize,CanChageFontColor)
//    CreateCtrl(3,'', 'images/copy_2_logo.jpg','images/copy_2_logo.jpg', '', '', '', '', '', '', '310', '25', '50','50','','','','','1','0','1','0','0','0','0','0','0');
//    CreateCtrl(1,'', 'Name','Name', '', '', 'Arial', '11pt', 'normal', 'normal', '22', '29', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'Designation','Designation', '', '', 'Arial', '10pt', 'normal', 'italic', '22', '48', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'COMPANY NAME','COMPANY NAME', '', '', 'Arial', '16pt', 'normal', 'normal', '136', '141', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'Address Line1, Address Line2','Address Line1, Address Line2', '', '', 'Arial', '9pt', 'normal', 'normal', '139', '166', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'City, State, Country, Zip','City, State, Country, Zip', '', '', 'Arial', '9pt', 'normal', 'normal', '139', '185', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'PH: ','PH: ', '', '', 'Arial', '9pt', 'bolder', 'normal', '58', '266', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'FAX: ','FAX: ', '', '', 'Arial', '9pt', 'bolder', 'normal', '172', '266', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'OFF: ','OFF: ', '', '', 'Arial', '9pt', 'bolder', 'normal', '292', '266', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'Email: ','Email: ', '', '', 'Arial', '9pt', 'bolder', 'normal', '75', '286', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
//    CreateCtrl(1,'', 'URL: ','URL: ', '', '', 'Arial', '9pt', 'bolder', 'normal', '220', '286', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    /////CreateCtrl(3,'', 'images/copy_2_logo.jpg','images/copy_2_logo.jpg', '', '', '', '', '', '', '50', '175', '32.25','30.75','','','','','1','0','1','0','0','0','0','0','0');
    
    //by swetha
    //CreateCtrl(7,'', '[CompanyName]','CompanyName', '', '', 'Arial', '9pt', 'bolder', 'normal', '200', '300', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );

if (report_page == 'Estimate')
    {
    CreateCtrl(3,'', '../document/1462/Eprint_logo1.jpg','../document/1462/Eprint_logo1.jpg', '', '', '', '', '', '', '30', '20', '193','50','','','','','1','0','1','0','0','0','0','0','0');
    CreateCtrl(9,'', '','', '', '', 'Arial', '9pt', '', 'normal', '30', '260', '400','20','2630A1','','0pt','1','1','0','1','0','0','0','1','1','1' );
    CreateCtrl(8,'', '','', '', '', 'Arial', '9pt', '', 'normal', '30', '420', '400','20','2630A1','','0pt','1','1','0','1','0','0','0','1','1','1' );
    
    CreateCtrl(7,'', '[CompanyName]','CompanyName', '', '', 'Arial', '9pt', '', 'normal', '300', '20', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress1]','Company Address 1', '', '', 'Arial', '9pt', '', 'normal', '300', '35', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress2]','Company Address 2', '', '', 'Arial', '9pt', '', 'normal', '300', '50', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress3]','Company Address 3', '', '', 'Arial', '9pt', '', 'normal', '300', '65', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyPhone]','Company Phone', '', '', 'Arial', '9pt', '', 'normal', '300', '80', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyZip]','Company Zip', '', '', 'Arial', '9pt', '', 'normal', '300', '95', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyEmail]','Company Email', '', '', 'Arial', '9pt', '', 'normal', '300', '110', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyCountry]','Company Country', '', '', 'Arial', '9pt', '', 'normal', '300', '125', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[EstimateCode]','Estimate Code', '', '', 'Arial', '9pt', '', 'normal', '30', '125', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[EstimateTitle]','Estimate Title', '', '', 'Arial', '9pt', '', 'normal', '30', '140', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[EstimatedDate]','Estimated Date', '', '', 'Arial', '9pt', '', 'normal', '30', '155', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[DeliveryAddress]','Delivery Address', '', '', 'Arial', '9pt', '', 'normal', '300', '180', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Greeting]','Greeting', '', '', 'Arial', '9pt', '', 'normal', '30', '210', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Header]','Header', '', '', 'Arial', '9pt', '', 'normal', '30', '225', '300','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[ItemTitle]','Item Title', '', '', 'Arial', '9pt', '', 'normal', '30', '275', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Colour: [Colour]','Colour', '', '', 'Arial', '9pt', '', 'normal', '30', '290', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Size: [Size]','Size', '', '', 'Arial', '9pt', '', 'normal', '300', '290', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Description: [Description]','Description', '', '', 'Arial', '9pt', '', 'normal', '30', '305', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Material: [Material]','Material', '', '', 'Arial', '9pt', '', 'normal', '300', '305', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Finishing: [Finishing]','Finishing', '', '', 'Arial', '9pt', '', 'normal', '30', '320', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Delivery: [Delivery]','Delivery', '', '', 'Arial', '9pt', '', 'normal', '300', '320', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Artwork: [Artwork]','Artwork', '', '', 'Arial', '9pt', '', 'normal', '30', '335', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Notes: [Notes]','Notes', '', '', 'Arial', '9pt', '', 'normal', '300', '335', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Quantity1: [Quantity1]','Quantity1', '', '', 'Arial', '9pt', '', 'normal', '30', '360', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Quantity2: [Quantity2]','Quantity2', '', '', 'Arial', '9pt', '', 'normal', '300', '360', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Price1(ex Tax): [Price1(exTax)]','Price1(ex Tax)', '', '', 'Arial', '9pt', '', 'normal', '30', '375', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Price2(ex Tax): [Price2(exTax)]','Price2(ex Tax)', '', '', 'Arial', '9pt', '', 'normal', '300', '375', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Price1(in Tax): [Price1(inTax)]','Price1(ex Tax)', '', '', 'Arial', '9pt', '', 'normal', '30', '390', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Price2(in Tax): [Price2(inTax)]','Price2(ex Tax)', '', '', 'Arial', '9pt', '', 'normal', '300', '390', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Sales Person: [SalesPerson]','Sales Person', '', '', 'Arial', '9pt', '', 'normal', '30', '490', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Footer]','Footer', '', '', 'Arial', '9pt', '', 'normal', '30', '510', '300','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Estimated By: [EstimatedBy]','Estimated By', '', '', 'Arial', '9pt', '', 'normal', '30', '560', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    }
    else if (report_page == 'Note')
    {
////CreateCtrl(CtrlType,CtrlID,CtrlValue,CtrlName,CtrlMaxLen,CtrlSize,CtrlFont,CtrlFontSize,CtrlFontWeight,CtrlStyle,CtrlLeft,CtrlTop,CtrlWidth,CtrlHeight,CtrlColor,CtrlIsUnderline,CtrlLSpace,CtrlAlign,ConReq,CanEditText,CanMoveObject,ReqNumericValue,MaxChar,RotatAngle,CanChangeFont,CanChangeFontSize,CanChageFontColor)
    CreateCtrl(3,'', '../document/1462/Eprint_logo1.jpg','../document/1462/Eprint_logo1.jpg', '', '', '', '', '', '', '30', '20', '155','58','','','','','1','0','1','0','0','0','0','0','0');
    CreateCtrl(7,'', '[CompanyName]','CompanyName', '', '', 'Arial', '9pt', '', 'normal', '300', '20', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress1]','Company Address 1', '', '', 'Arial', '9pt', '', 'normal', '300', '35', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress2]','Company Address 2', '', '', 'Arial', '9pt', '', 'normal', '300', '50', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyAddress3]','Company Address 3', '', '', 'Arial', '9pt', '', 'normal', '300', '65', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyZip]','Company Zip', '', '', 'Arial', '9pt', '', 'normal', '300', '80', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[CompanyCountry]','Company Country', '', '', 'Arial', '9pt', '', 'normal', '300', '95', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[DeliveryAddress]','Delivery Address', '', '', 'Arial', '9pt', '', 'normal', '30', '120', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[ContactName]','Contact Name', '', '', 'Arial', '9pt', '', 'normal', '30', '135', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'DeliveryNote','Delivery Note', '', '', 'Arial', '9pt', '', 'normal', '300', '150', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[DeliveryNumber]','Delivery No', '', '', 'Arial', '9pt', '', 'normal', '300', '165', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[DeliveryDate]','Delivery Date', '', '', 'Arial', '9pt', '', 'normal', '300', '180', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[OrderNo]','Order Ref', '', '', 'Arial', '9pt', '', 'normal', '300', '195', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Carrier]','Carrier', '', '', 'Arial', '9pt', '', 'normal', '30', '220', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Description Of goods','Description Of goods', '', '', 'Arial', '9pt', '', 'normal', '30', '235', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(8,'', '','', '', '', 'Arial', '9pt', '', 'normal', '30', '500', '400','20','2630A1','','0pt','1','1','0','1','0','0','0','1','1','1' );
    CreateCtrl(9,'', '','', '', '', 'Arial', '9pt', '', 'normal', '30', '250', '400','20','2630A1','','0pt','1','1','0','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Quantity]','Quantity', '', '', 'Arial', '9pt', '', 'normal', '30', '265', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '[Description]','Description', '', '', 'Arial', '9pt', '', 'normal', '30', '280', '150','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Goods received in satisfactory condition','Goods received in satisfactory condition', '', '', 'Arial', '9pt', '', 'normal', '250', '515', '200','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Signature','Signature', '', '', 'Arial', '9pt', '', 'normal', '250', '535', '90','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '_________________','Signature', '', '', 'Arial', '9pt', '', 'normal', '295', '535', '100','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', 'Date','Date', '', '', 'Arial', '9pt', '', 'normal', '250', '555', '50','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    CreateCtrl(7,'', '____/____/____','Date', '', '', 'Arial', '9pt', '', 'normal', '280', '555', '90','20','2630A1','','0pt','1','1','1','1','0','0','0','1','1','1' );
    }
}

//is_ie = ( /msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent) );
//is_ie5 = ( is_ie && /msie 5\.0/i.test(navigator.userAgent) );
//is_opera = /opera/i.test(navigator.userAgent);
//is_khtml = /Konqueror|Safari|KHTML/i.test(navigator.userAgent);

//var idnm=0;
//var selObj="";
//var selObjs=new Array();
//var chkCtrl=0;
//var typeObj="";
//var islock="false";
//var canMove = "0";
//var contPlNm="ctl00_ContentPlaceHolder1_";
//var actM=0;

function PointToPixel(val,dpi)
{
    rval=parseFloat(val) * parseFloat(dpi) / parseFloat("72");
    return parseInt(rval);
}
function setDivWH()
{
	tDivht=PointToPixel(document.getElementById(contPlNm + "CDivHPoint").value,document.getElementById(contPlNm + "sYDPI").value);
	tDivWd=PointToPixel(document.getElementById(contPlNm + "CDivWPoint").value,document.getElementById(contPlNm + "sXDPI").value);
	tDivht=842;
	tDivWd=595;
	document.getElementById(contPlNm + "CardDiv").style.width =tDivWd+"px";
	document.getElementById(contPlNm + "CardDiv").style.height =tDivht+"px";
	document.getElementById(contPlNm + "Div1").style.width =tDivWd+"px";
	document.getElementById(contPlNm + "Div1").style.height =tDivht+"px";
	document.getElementById(contPlNm + "bkImg").style.width =tDivWd+"px";
	document.getElementById(contPlNm + "bkImg").style.height =tDivht+"px";
}
function pageLoadEvents()
{
	if(screen.deviceXDPI)
	{   
	}
	setDivWH();
	document.getElementById("tmpImgPath").value="";
	document.getElementById(contPlNm + "chkBrows").value =isIE ? "0": "1";
	sr=document.getElementById("tdDesign");

	if(document.getElementById(contPlNm + "DMode").value=="1")
	{ 
		if (sr.attachEvent) { // IE
			sr.attachEvent("onclick" , selDiv);
		} else if (sr.addEventListener) { // Gecko / W3C
			sr.addEventListener("click", selDiv, true);
		} else {
			sr["onclick"] = selDiv;
		}
		 document.onkeydown = keyProcess;		
	}
}
function fillBkImgs(imgList)
{
    while (document.getElementById(contPlNm+"imgBk").options.length)
    {
        document.getElementById(contPlNm+"imgBk").remove(0);
    }
    opt = new Option("Backgrounds","");
    document.getElementById(contPlNm+"imgBk").add(opt);
    arrLst=imgList.split("&");
    for(var i=0; i<arrLst.length;i++)
    {
        if(arrLst[i]!="")
        {
            arrVal=arrLst[i].split(",");
            if(arrVal.length==2)
            {
                opt = new Option(arrVal[0],arrVal[1]);
                document.getElementById(contPlNm+"imgBk").add(opt);
            }
        }
    }
}
function OnCallback(Result,Context) 
{
    if(Result!="")
    {
        arr1=Result.split("#");
        arr=arr1[0].split("|");
        if(arr.length==2)
        {
            document.getElementById(contPlNm +"imgPath").value=arr[1];
            document.getElementById(contPlNm +"bkImg").src="Products/BackgroundImages/tmp/"+arr[0];
            document.getElementById(contPlNm +"bkImg").style.visibility="visible";
            document.getElementById(contPlNm +"bkImg").alt = ""
        }
        else
        {
            document.getElementById(contPlNm +"imgPath").value="";
            document.getElementById(contPlNm +"bkImg").src="";
            document.getElementById(contPlNm +"bkImg").style.visibility="hidden";
            document.getElementById(contPlNm +"bkImg").alt = ""
        }
        if(arr1.length>1)
        {
            fillBkImgs(arr1[1]);
        }
    }
    else
    {
        document.getElementById(contPlNm +"imgPath").value="";
        document.getElementById(contPlNm +"bkImg").src="";
        document.getElementById(contPlNm +"bkImg").style.visibility="hidden";
        document.getElementById(contPlNm +"bkImg").alt = ""
    }
}
function addBKImg()
{
    var vReturnValue="";
    if(document.getElementById(contPlNm+"PIDVal").value !="" && document.getElementById(contPlNm+"PIDVal").value!="0")
    {
        if(!isIE)
        {
            window.addEventListener("focus", addImg3, true);
        }
        pwin=window.open( 'productbackground.html?pid=' + document.getElementById(contPlNm+"PIDVal").value, "imgwin", "status = 1, height = 390px, width = 385px, resizable = 0" );
        pwin.focus();
    }
}
function picturebrowser()
{
    pwin=window.open( 'picture_browser.html?pid=' + document.getElementById(contPlNm+"PIDVal").value, "imgwin", "status = 1, height = 390px, width = 385px, resizable = 0" );
    pwin.focus();
}
function addBKImg2(imgName)
{
    if(imgName)
    {
        WebForm_DoCallback('__Page',imgName,OnCallback,this,OnCallback,true);
    }
}
function addImg()
{
    var vReturnValue="";
    if(!isIE)
    {
        window.addEventListener("focus", addImg3, true);
    }
    pwin=window.open( 'userimg.html', "imgwin", "scrollbars,resizable, height = 400px, width = 400px" )
    pwin.focus();
}
function addImg2(imgName)
{
    if(imgName)
    {
        CreateCtrl(3,"",imgName,imgName,"","","","","","","","","60","60","","","","","","","1","");
    }
}
function addImg3()
{
    imgNme=document.getElementById("tmpImgPath").value;
    if(imgNme!="")
    {
        CreateCtrl(3,"",imgNme,imgNme,"","","","","","","","","60","60","","","","","","","1","");
        document.getElementById("tmpImgPath").value="";
        window.removeEventListener("focus", addImg3, true);
    }
}
function chngObjLAlign()
{
    var lft=0;
    if(selObjs.length>0)
    {
        lft=parseInt(document.getElementById(selObjs[0]).style.left);
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                    if(parseInt(document.getElementById(selObjs[i]).style.left)<lft)
                    lft=parseInt(document.getElementById(selObjs[i]).style.left);
                }
            }
        }
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                    document.getElementById(selObjs[i]).style.left=lft + "px";
                }
            }
        }
    }
}
function chngObjRAlign()
{
    var lft=0;
    if(selObjs.length>0)
    {
        lft=parseInt(document.getElementById(selObjs[0]).style.left) +parseInt(document.getElementById(selObjs[0]).style.width);
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                if(parseInt(document.getElementById(selObjs[i]).style.left) +parseInt(document.getElementById(selObjs[i]).style.width)>lft)
                    lft=parseInt(document.getElementById(selObjs[i]).style.left) +parseInt(document.getElementById(selObjs[i]).style.width);
                }
            }
        }
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                    document.getElementById(selObjs[i]).style.left=lft-parseInt(document.getElementById(selObjs[i]).style.width) + "px";
                }       
            }
        }
    }
}
function chngObjCAlign()
{
    var md=parseInt(parseInt(document.getElementById(contPlNm +"CardDiv").style.width)/2);
    if(selObjs.length>0)
    {
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                    document.getElementById(selObjs[i]).style.left=parseInt(md-parseInt(document.getElementById(selObjs[i]).style.width)/2) + "px"
                }
            }
        }
    }
}
//---------------------------------------------------------
function chngSpace(sp)
{
    for( var i=selObjs.length-1; i >= 0; i--)
    {
        if(selObjs[i]!="")
        document.getElementById(selObjs[i]).style.letterSpacing=sp;
    }
}
function chngUnd()
{
    if(selObjs.length>0)
    {
        uchk=0;
        if(document.getElementById(selObjs[0]).style.textDecoration=="none") uchk=0; else    uchk=1;
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(uchk==0)
                document.getElementById(selObjs[i]).style.textDecoration="underline";
                else
                document.getElementById(selObjs[i]).style.textDecoration="none";
            }
        }
    }
}
function chngAlign(txtalign)
{
    if(txtalign!="")
    {   
        alignstr="";
        if(txtalign=="1")
        alignstr="left";
        else if(txtalign=="2")
        alignstr="center";
        else if(txtalign=="3")
        alignstr="right";
        else if(txtalign=="4")
        alignstr="justify";
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(document.getElementById("lockallobjects").value==0)
                {
                    document.getElementById(selObjs[i]).style.textAlign=alignstr;
                }    
            }
        }
    }
}
function disablToolBar()
{
//document.getElementById("imgBld").style.
}
function enableToolBar()
{
}
function ctrlSet()
{
    
    if(selObj!="" && typeObj=="divobj" && islock=="false")
    {
        if(document.getElementById(selObj).style.fontWeight=="normal")
          document.getElementById("imgBld").src="../ODSPrinting/bold.gif";
        else
         document.getElementById("imgBld").src="../ODSPrinting/bold_gray.gif";   

        if(document.getElementById(selObj).style.fontStyle=="normal")
            document.getElementById("imgIt").src="../ODSPrinting/italic.gif";
        else
            document.getElementById("imgIt").src="../ODSPrinting/italic_gray.gif";
        
        list=document.getElementById(contPlNm + "lstFont");
        idx=0;
        for( i=list.options.length-1; i>=0; i--)
        {
            if(list.options[i].value.toUpperCase() ==document.getElementById(selObj).style.fontFamily.toUpperCase())
            {
                idx=i;
            }  
        }
        list.selectedIndex=idx;	
        list=document.getElementById(contPlNm + "lstSize");
        idx=0;
        for( i=list.options.length-1; i>=0; i--)
        {
            if(list.options[i].value==document.getElementById(selObj).style.fontSize)
            {
                idx=i;
            }  
        }
        list.selectedIndex=idx;	
        list.selectedIndex=idx;
        if(document.getElementById(selObj).getAttribute("CanChangeFont") == "1")   	
            document.getElementById(contPlNm + "lstFont").disabled="";
        else
            document.getElementById(contPlNm + "lstFont").disabled="disabled";
            
        if(document.getElementById(selObj).getAttribute("CanChangeFontSize") == "1")   	
            document.getElementById(contPlNm + "lstSize").disabled="";
        else
            document.getElementById(contPlNm + "lstSize").disabled="disabled";            

        if(document.getElementById(selObj).getAttribute("CanChageFontColor") == "1")   	
            document.getElementById("imgtextcolor").disabled="";
        else
            document.getElementById("imgtextcolor").disabled="disabled";            
    }
    else
    {
        document.getElementById(contPlNm + "lstSize").disabled="disabled";
        document.getElementById(contPlNm + "lstFont").disabled="disabled";
    }
}
function chngFont(fontNm)
{
    for( var i=selObjs.length-1; i >= 0; i--)
    {
        if(selObjs[i]!="")
        document.getElementById(selObjs[i]).style.fontFamily=fontNm;
    }
}
function chngBld()
{
    if(selObjs.length>0)
    {
        bchk=0;
        if(document.getElementById(selObjs[0]).style.fontWeight=="normal") bchk=0; else    bchk=1;
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(bchk==0)
                    document.getElementById(selObjs[i]).style.fontWeight="bolder";
                else
                    document.getElementById(selObjs[i]).style.fontWeight="normal";
            }
        }
    }
}
function chngIt()
{
    if(selObjs.length>0)
    {
        ichk=0;
        if(document.getElementById(selObjs[0]).style.fontStyle=="normal") ichk=0; else    ichk=1;
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            {
                if(ichk==0)
                    document.getElementById(selObjs[i]).style.fontStyle="italic";
                else
                    document.getElementById(selObjs[i]).style.fontStyle="normal";
            }    
        }
    }
}
function appColor(clr)
{
    if(clr!="")
    {  
        for( var i=selObjs.length-1; i >= 0; i--)
        {
            if(selObjs[i]!="")
            document.getElementById(selObjs[i]).style.color= clr;
        }
    }    
}
function chngSize(fsize) 
{
    for( var i=selObjs.length-1; i >= 0; i--)
    {
        if(selObjs[i]!="")
        { 
            document.getElementById(selObjs[i]).style.fontSize=fsize;
            if(document.getElementById(selObjs[i]).getAttribute("objtype") == 1)
            {
                var txtht = document.getElementById(selObjs[i]).style.height.replace("px","");
                var fontsz = document.getElementById(selObjs[i]).style.fontSize.replace("pt","");
                if(txtht>(fontsz*1.8) ||txtht<(fontsz*1.8))
	            {
	            document.getElementById(selObjs[i]).style.height = (fontsz*1.8)+'px';
	            //alert(document.getElementById(selObjs[i]).style.height);
	            }
            }
        }
    }
}
function showHidDiv()
{
    unSelAll();
    if(document.getElementById( "crtlDiv").style.visibility=="hidden")
        document.getElementById("crtlDiv").style.visibility="visible";
    else
        document.getElementById( "crtlDiv").style.visibility="hidden";
        document.getElementById( "objName").value="";
}
function change_image(imgname, val,iw,ih)
{
//alert(imgname);
CreateCtrl(3,'', 'images/'+imgname,'images/'+imgname, '', '', '', '', '', '', '168.75', '14', iw,ih,'','','','','1','0','1','0','0','0','0','0','0');	
}
function change_image_library(imgname, val)
{
//alert(imgname);
CreateCtrl(3,'', imgname,imgname, '', '', '', '', '', '', '168.75', '14', '32.25','30.75','','','','','1','0','1','0','0','0','0','0','0');	
}
function change_image_background(imgname, val)
{
    document.getElementById("ctl00_ContentPlaceHolder1_bkImg").src='images/'+imgname;
	getvals(imgname);
}
function change_image_background_here(imgname)
{
	if(imgname!='')
    document.getElementById("ctl00_ContentPlaceHolder1_bkImg").src='images/'+imgname;
	//getvals(imgname);
}
function remove_background()
{
    document.getElementById("ctl00_ContentPlaceHolder1_bkImg").src='transparentpixel.gif';
	var selthis1=document.forms["odsform"].ctl00_ContentPlaceHolder1_imgBk;
	document.getElementById("ctl00_ContentPlaceHolder1_bkImg").src='transparentpixel.gif';
	var selthis=document.forms["odsform"].ctl00_ContentPlaceHolder1_imgBk;
	//var selthis = document.getElementById('ctl00_ContentPlaceHolder1_bkImg');
	for(var i=0; i<selthis.options.length; i++)
	{
	    if(selthis.options[i].value=='')
	    {
	        selthis.selectedindex=i;
	        if(!selthis.options[i].selected )
	        {
	            selthis.options[i].selected=true;
	        }
	        //return;
	    }
	} 
}

//==============================================create control================
function CreateCtrl(CtrlType,CtrlID,CtrlValue,CtrlName,CtrlMaxLen,CtrlSize,CtrlFont,CtrlFontSize,CtrlFontWeight,CtrlStyle,CtrlLeft,CtrlTop,CtrlWidth,CtrlHeight,CtrlColor,CtrlIsUnderline,CtrlLSpace,CtrlAlign,ConReq,CanEditText,CanMoveObject,ReqNumericValue,MaxChar,RotatAngle,CanChangeFont,CanChangeFontSize,CanChageFontColor)
{
divids = idnm;
if(CtrlName=="")
    CtrlName="object name";
if(CtrlFont=="")
   CtrlFont="Arial";
if(CtrlFontSize=="")
    CtrlFontSize="12pt";
if(CtrlFontWeight=="")
    CtrlFontWeight="normal";
if(CtrlStyle=="")
    CtrlStyle="normal";
if(CtrlLeft=="")
    CtrlLeft="0";
if(CtrlTop=="")
    CtrlTop="0";
if(CtrlWidth=="")
    CtrlWidth="50";
if(CtrlHeight=="")
    CtrlHeight="20";
if(CtrlLSpace=="")
    CtrlLSpace="0pt";
strAlign="left";
if(CtrlAlign=="2")
    strAlign="center";
else if(CtrlAlign=="3")
    strAlign="right";
else if(CtrlAlign=="4")
    strAlign="justify";
UnderlineStr="none";
if(CtrlColor=="")
    CtrlColor="000000";
if(CtrlIsUnderline=="1" )
   {
        UnderlineStr="underline";
   }
if(CanEditText == "")
    CanEditText = "0";
if(CanMoveObject == "")

    CanMoveObject = "0";
if(ReqNumericValue == "")
    ReqNumericValue = "0";
if(MaxChar == "")
    MaxChar = "0";
if(RotatAngle == "" )
    RotatAngle = "0";
if(CanChangeFont == "" )
    CanChangeFont = "0";
if(CanChangeFontSize == "")
    CanChangeFontSize = "0";
if(CanChageFontColor == "")
    CanChageFontColor = "0";
    
var zindx=10000;
//alert("Hello");

if(ConReq=="1")
{
CtrlLeft=PointToPixel(CtrlLeft,document.getElementById(contPlNm + "sXDPI").value);
CtrlWidth=PointToPixel(CtrlWidth,document.getElementById(contPlNm + "sXDPI").value);

CtrlTop=PointToPixel(CtrlTop,document.getElementById(contPlNm + "sYDPI").value);
CtrlHeight=PointToPixel(CtrlHeight,document.getElementById(contPlNm + "sYDPI").value);
}
//By Swetha changes for CtrlType=7

if(CtrlType==1 || CtrlType==2 || CtrlType==4 || CtrlType==5 || CtrlType==7)//by swetha 7
{

        if(is_ie)
            var ctrList=document.getElementById(contPlNm + "CtrlList").getElementsByTagName("tbody")[0];
        else
            var ctrList=document.getElementById(contPlNm + "CtrlList");

        var CardDiv=document.getElementById(contPlNm + "CardDiv");
        var row1 = document.createElement("tr");
        row1.setAttribute("id","row1_"+idnm);
        var td1 = document.createElement("td");
        td1.style.pixelHeight=18;
        td1.style.verticalAlign="bottom";
        td1.appendChild(document.createTextNode(CtrlName));
        td1.className="formlabel";
        row1.appendChild(td1);
        var row2 = document.createElement("tr");
        row2.setAttribute("id","row2_"+idnm);
        var td2 = document.createElement("td");
         td2.style.pixelWidth=255;
         td2.style.textAlign="left";
		 
		 
        if(CtrlType==2)
        {
            var txtbx= document.createElement("textarea");
            txtbx.setAttribute("cols","28");
            txtbx.style.height="60px";
        }
        else if(CtrlType==7)//by swetha
        {
            var txtbx= document.createElement("div");
            txtbx.setAttribute("id","div_"+idnm);
            txtbx.setAttribute("name","div_"+idnm);
            txtbx.setAttribute("class","button");
            txtbx.setAttribute("runat","server");
        }        
        else
        {  
            var txtbx= document.createElement("input");
            txtbx.setAttribute("type","text");
            txtbx.setAttribute("size","25");
            txtbx.style.height="18px";
        }
        //alert("Hello");
        if(CanEditText == "0")
            txtbx.setAttribute("readOnly","true")
        txtbx.style.pixelWidth=255;
        txtbx.setAttribute("id","txtbx_"+idnm);
        txtbx.setAttribute("name","txtbx_"+idnm);
        txtbx.setAttribute("class","emptythetextbox");
        txtbx.setAttribute("runat","server");
        if(MaxChar != "0")
            txtbx.setAttribute("maxLength",MaxChar);
       if(CtrlType==2)
       {
            txtbx.value=CtrlValue.replace(/<BR \/>/g,"\n").replace(/<br \/>/g,"\n").replace(/'/g,"&acute;");
       }
       else
       {
            txtbx.setAttribute("value",CtrlValue.replace(/<BR \/>/g,"\n").replace(/<br \/>/g,"\n").replace(/'/g,"&acute;"));
       }
       
        if (txtbx.attachEvent) //IE
        {
            if(ReqNumericValue == "1")
                txtbx.attachEvent("onkeydown", CheckKeyCodeInteger);
            txtbx.attachEvent("onkeyup" , chgTxt);
        } 
        else if (txtbx.addEventListener) 
        {
            if(ReqNumericValue == "1")
                txtbx.addEventListener("onkeydown", CheckKeyCodeInteger,true);
            txtbx.addEventListener("keyup", chgTxt, true);
        } 
        else 
        {
            if(ReqNumericValue == "1")
                txtbx["onkeyup"] = chgTxt;
            txtbx["onkeydown"] = CheckKeyCodeInteger;
        }
        td2.appendChild(txtbx);
        row2.appendChild(td2);
        if(document.getElementById(contPlNm + "DMode").value=="1")
        {
            var td3_gap = document.createElement("td");
            td3_gap.className="normaltxt";
            td3_gap.appendChild(document.createTextNode("\u00a0"));
            td3_gap.style.textAlign="center";
            td3_gap.style.pixelWidth=10;
            row2.appendChild(td3_gap);

            var td3 = document.createElement("td");
            td3.className="normaltxt";
            td3.appendChild(document.createTextNode("Show"));
            td3.style.textAlign="center";
            td3.style.pixelWidth=35;
           // row2.appendChild(td3);
			
            var td3_gap = document.createElement("td");
            td3_gap.className="normaltxt";
            td3_gap.appendChild(document.createTextNode("\u00a0"));
            td3_gap.style.textAlign="center";
            td3_gap.style.pixelWidth=5;
           // row2.appendChild(td3_gap);
			
            var td4 = document.createElement("td");
            td4.style.pixelWidth=27;
            var chkbxS= document.createElement("input");
            chkbxS.setAttribute("type","checkbox");
            chkbxS.setAttribute("id","chkbxS_"+idnm);
            chkbxS.setAttribute("name","chkbxS_"+idnm);
            chkbxS.setAttribute("runat","server");
            if (chkbxS.attachEvent) 
            { // IE
		        chkbxS.attachEvent("onclick" , showhidObj);
		    } 
		    else if (chkbxS.addEventListener) 
		    { // Gecko / W3C
		        chkbxS.addEventListener("click", showhidObj, true);
	        }
	        else 
	        {
		        chkbxS["onclick"] = showhidObj;
	        }
			
			var row_gap = document.createElement("tr");
			row_gap.setAttribute("id","row_gap_2_"+idnm);
			var td_gap = document.createElement("td");
			td_gap.style.pixelHeight=10;
			td_gap.setAttribute("height","10");
			td_gap.style.textAlign="left";
            row_gap.appendChild(td_gap);
			
            var td5 = document.createElement("td");
            td5.className="normaltxt";
            td5.appendChild(document.createTextNode("|"));
            td5.style.pixelWidth=5;
        
            var td6 = document.createElement("td");
            td6.className="normaltxt";
            td6.appendChild(document.createTextNode("Lock"));
            td6.style.textAlign="center";
            td6.style.pixelWidth=35;
               
            var td7 = document.createElement("td");
            td7.style.pixelWidth=27;
            var chkbxL= document.createElement("input");
            chkbxL.setAttribute("type","checkbox");
            chkbxL.setAttribute("id","chkbxL_"+idnm);
            chkbxL.setAttribute("name","chkbxL_"+idnm);
            chkbxL.setAttribute("runat","server");
            if (chkbxL.attachEvent) 
            { // IE
                chkbxL.attachEvent("onclick" , LockObj);
            } 
            else if (chkbxL.addEventListener) 
            { // Gecko / W3C
                chkbxL.addEventListener("click", LockObj, true);
            } 
            else 
            {
                chkbxL["onclick"] = LockObj;
            }
        }
        ctrList.appendChild(row1); 
        ctrList.appendChild(row2);
        ctrList.appendChild(row_gap);
        var txtdiv= document.createElement("DIV");
        txtdiv.setAttribute("id","'div'_" + idnm );
        txtdiv.setAttribute("type","divobj");
        txtdiv.setAttribute("title",CtrlName);
        txtdiv.setAttribute("objtype",CtrlType);
        txtdiv.setAttribute("objname",CtrlName);
        txtdiv.setAttribute("onMouseOver", "this.className='putpointer'");
		//txtdiv.onMouseOver = "this.className=putpointer";
        txtdiv.setAttribute("CanChangeFont",CanChangeFont);
        txtdiv.setAttribute("CanChangeFontSize",CanChangeFontSize);
        txtdiv.setAttribute("CanChageFontColor",CanChageFontColor);
        txtdiv.setAttribute("lock","false");
        if(CanMoveObject == "0")
            txtdiv.setAttribute("canmove","0"); 
        else
            txtdiv.setAttribute("canmove","1");
        txtdiv.setAttribute("runat","server");
        txtdiv.innerHTML=CtrlValue;
        txtdiv.style.position="absolute";
        txtdiv.style.backgroundColor="transparent";
        txtdiv.style.display="inline";
        txtdiv.style.zIndex=zindx + idnm;
        txtdiv.style.fontFamily=CtrlFont;
        txtdiv.style.fontSize=CtrlFontSize;
        txtdiv.style.fontWeight=CtrlFontWeight;
        txtdiv.style.fontStyle=CtrlStyle;
        txtdiv.style.color= "#" + CtrlColor;
        txtdiv.style.textDecoration=UnderlineStr;
        txtdiv.style.textAlign=strAlign;
        txtdiv.style.lineHeight="1";
        txtdiv.style.overflow="hidden";

        txtdiv.style.visibility="visible"

        txtdiv.style.pixelLeft=CtrlLeft; //.style.pixelLeft;
        txtdiv.style.pixelTop=CtrlTop; //.pixelTop;
        txtdiv.style.pixelWidth=CtrlWidth;
        txtdiv.style.pixelHeight=CtrlHeight;

        txtdiv.style.left=CtrlLeft + "px"; //.style.pixelLeft;
        txtdiv.style.top=CtrlTop + "px"; //.pixelTop;
        txtdiv.style.width=CtrlWidth + "px";
        txtdiv.style.height=CtrlHeight + "px";
      
        if(document.getElementById(contPlNm + "DMode").value=="1")
        {
        }
        CardDiv.appendChild(txtdiv);
       
        if(document.getElementById(contPlNm + "DMode").value=="1")
        {
        }
        idnm=idnm+1;
    }
    else if(CtrlType==3)
    {
            
            var CardDiv=document.getElementById(contPlNm + "CardDiv");
            var txtdiv= document.createElement("div");
            txtdiv.setAttribute("id","'div'_" + idnm );
            txtdiv.setAttribute("type","imgDiv");
            txtdiv.setAttribute("objtype",CtrlType);
            txtdiv.setAttribute("objname",CtrlName);
            txtdiv.setAttribute("canmove",CanMoveObject);
            
            
            if(CanMoveObject == "0")
                txtdiv.setAttribute("lock","true");
            else
                txtdiv.setAttribute("lock","false");
             //txtdiv.setAttribute("lock","false");
             
            txtdiv.setAttribute("runat","server");
            txtdiv.style.position="absolute";
            txtdiv.style.backgroundColor="transparent";
            txtdiv.style.display="inline";
            txtdiv.style.overflow="visible";
            txtdiv.style.zIndex=1;
            txtdiv.style.left=CtrlLeft + "px"; //.style.pixelLeft;
            txtdiv.style.top=CtrlTop + "px"; //.pixelTop;
            txtdiv.style.width=CtrlWidth + "px";
            txtdiv.style.height=CtrlHeight + "px" ;
            //txtdiv.attachEvent("onmousedown" ,ImgMove);
         
            if(document.getElementById(contPlNm + "DMode").value=="1")
            { 

            }

            var img= document.createElement("img");
            img.setAttribute("src",CtrlValue);
           
            img.setAttribute("id","'img'_" + idnm );
            img.setAttribute("type","imgObj");
            img.style.position="absolute";
            img.style.display="inline";
            img.style.left="0px"; //.style.pixelLeft;
            img.style.top="0px"; //.pixelTop;
            img.style.width="100%";//CtrlWidth;
            img.style.height="100%";//CtrlHeight;
            img.removeAttribute("width",1,"f");
            img.removeAttribute("height",1,"f");

            txtdiv.appendChild(img);
            
            CardDiv.appendChild(txtdiv);
		    var div_inter_img = imgsarray.splice(imgsarray.length,0,divids);
            idnm=idnm+1;
    }
    else if (CtrlType == 8 || CtrlType == 9)//by swetha  --- HorizontalRule
    {
        var CardDiv=document.getElementById(contPlNm + "CardDiv");
        var txtstart = '';
        if (CtrlType == 8)//<strat1> tag
        {
            txtstart= document.createElement("start1");
        }
        else if (CtrlType == 9)//<strat2> tag
        {
            txtstart= document.createElement("start2");
        }
        
        var txtdiv= document.createElement("div");
        txtdiv.setAttribute("id","'div'_" + idnm );
        txtdiv.setAttribute("type","hrDiv");
        txtdiv.setAttribute("objtype",CtrlType);
        txtdiv.setAttribute("objname",CtrlName);
        txtdiv.setAttribute("canmove",CanMoveObject);

        if(CanMoveObject == "0")
            txtdiv.setAttribute("lock","true");
        else
            txtdiv.setAttribute("lock","false");

        txtdiv.setAttribute("runat","server");
        txtdiv.style.position="absolute";
        //txtdiv.style.backgroundColor="transparent";
        //txtdiv.style.display="inline";
        txtdiv.style.overflow="hidden";
        txtdiv.style.zIndex=1;
        txtdiv.style.left=CtrlLeft + "px"; //.style.pixelLeft;
        txtdiv.style.top=CtrlTop + "px"; //.pixelTop;
        txtdiv.style.width=CtrlWidth + "px";
        txtdiv.style.height=CtrlHeight + "px" ;
        //txtdiv.attachEvent("onmousedown" ,ImgMove);
         
        if(document.getElementById(contPlNm + "DMode").value=="1")
        { 

        }
        var hr= document.createElement("hr");
        hr.setAttribute("src",CtrlValue);   
        hr.setAttribute("id","'hr'_" + idnm );
        hr.setAttribute("type","hrObj");
        //hr.style.position="absolute";
        //hr.style.display="inline";
        hr.style.left= CtrlLeft + "px"; //.style.pixelLeft;
        hr.style.top= CtrlTop + "px"; //.pixelTop;
        hr.style.width= "100%";//CtrlWidth;
        //hr.style.height="100%";//CtrlHeight;
        //hr.removeAttribute("width",1,"f");
        //hr.removeAttribute("height",1,"f");

        txtdiv.appendChild(hr);
        txtstart.appendChild(txtdiv);
        
        CardDiv.appendChild(txtstart);
        idnm=idnm+1;    
    }
    var div_inter = divsarray.splice(divsarray.length,0,divids);

}
//=============================================
function showhideHrRule()
{
    CreateCtrl(8,'', '','', '', '', 'Arial', '9pt', '', 'normal', '150', '100', '200','20','2630A1','','0pt','1','1','0','1','0','0','0','1','1','1' );
}
function addCtrl(CtrlType)
{
    if(CtrlType==1)
    {
        if(document.getElementById("objName").value=="")
        {
        alert("Enter Object Name");
        }
        else
        { 
            var objName= document.getElementById("objName").value;
            document.getElementById("objName").value="";
            showHidDiv();
            if(document.getElementById("chkBx").checked==true)
            {
            document.getElementById("chkBx").checked=false;
            CreateCtrl(2,"",objName,objName,"","10","","","","","","","200","20","","","","","","1","1","0","0","0","1","1","1");
            }
            else
            {  
            CreateCtrl(1,"",objName,objName,"","10","","","","","","","200","20","","","","","","1","1","0","0","0","1","1","1");
            }
        }
    }
}
function addtextbox(CtrlType)
{
    if(CtrlType==1)
    {
        var objName= "Enter your text";
        CreateCtrl(1,"",objName,objName,"","10","","","","","","","200","20","","","","","","1","1","0","0","0","1","1","1");
    }
}
function showhidObj(e)
{
    var src = DefaultButton_GetSrcElement(e);
    arr=src.id.split("_");
    if(arr.length>1)
    {
		if(document.getElementById("'div'_" + arr[1]))
		{
			if(document.getElementById("'div'_" + arr[1]).style.visibility=="hidden"){
			document.getElementById("'div'_" + arr[1]).style.visibility="visible";
				document.getElementById("txtbx_" + arr[1]).disabled=false;}
			else{
				document.getElementById("'div'_" + arr[1]).style.visibility="hidden";
				document.getElementById("txtbx_" + arr[1]).disabled=true;}
		}
	}
}
function LockObj(e)
{
   var src = DefaultButton_GetSrcElement(e);
   arr=src.id.split("_");
   if(arr.length>1)
   {
       if(document.getElementById("'div'_" + arr[1]).lock=="false")
           document.getElementById("'div'_" + arr[1]).lock="true";
       else
           document.getElementById("'div'_" + arr[1]).lock="false";
      islock=document.getElementById("'div'_" + arr[1]).lock;
            
    }
}
function creatTable()
{
    if(selObj!="")
    {
        var src =document.getElementById(selObj) ;
        arr=selObj.replace("'div'_","");
        if(src.getAttribute("objtype") == 1)
        {
            document.getElementById("txtbx_"+arr).className = "fillthetextbox" ;
            var txtht = src.style.height.replace("px","");
            var fontsz = src.style.fontSize.replace("pt","");
            if(txtht>(fontsz*1.8) || txtht<(fontsz*1.8))
            src.style.height = fontsz*1.8+'px';
        }
        var mdv = document.createElement("div");
	    mdv.className="div_wrap div_selArea" ;
        mdv.setAttribute("id","MovDiv" + src.id);
        mdv.setAttribute("type","MvDiv");

        var dv1 = document.createElement("div");
        dv1.className="div_marqueeHoriz div_marqueeNorth";
        dv1.setAttribute("type","MDivLN");
        mdv.appendChild(dv1);
     
        var dv2 = document.createElement("div");
        dv2.className="div_marqueeVert div_marqueeEast";
        dv2.setAttribute("type","MDivLE");
        mdv.appendChild(dv2);
     
        var dv3 = document.createElement("div");
        dv3.className="div_marqueeHoriz div_marqueeSouth";
        dv3.setAttribute("type","MDivLS");
        mdv.appendChild(dv3);
     
        var dv4 = document.createElement("div");
        dv4.className="div_marqueeVert div_marqueeWest";
        dv4.setAttribute("type","MDivLW");
        mdv.appendChild(dv4);
     
        var dv5 = document.createElement("div");
        dv5.className="div_handle div_handleN";
        dv5.setAttribute("type","MDivN");
        if (dv5.attachEvent) { dv5.attachEvent("onmousedown" , ImgMove);} 
        else if (dv5.addEventListener) { dv5.addEventListener("mousedown", ImgMove, true);} 
        else {dv5["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv5);
     
        var dv6 = document.createElement("div");
        dv6.className="div_handle div_handleNE";
        dv6.setAttribute("type","MDivNE");
        if (dv6.attachEvent) { dv6.attachEvent("onmousedown" , ImgMove);} 
        else if (dv6.addEventListener) { dv6.addEventListener("mousedown", ImgMove, true);} 
        else {dv6["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv6);

        var dv7 = document.createElement("div");
        dv7.className="div_handle div_handleE";
        dv7.setAttribute("type","MDivE");
        if (dv7.attachEvent) { dv7.attachEvent("onmousedown" , ImgMove);} 
        else if (dv7.addEventListener) { dv7.addEventListener("mousedown", ImgMove, true);} 
        else {dv7["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv7);
     
        var dv8 = document.createElement("div");
        dv8.className="div_handle div_handleSE";
        dv8.setAttribute("type","MDivSE");
        if (dv8.attachEvent) { dv8.attachEvent("onmousedown" , ImgMove);} 
        else if (dv8.addEventListener) { dv8.addEventListener("mousedown", ImgMove, true);} 
        else {dv8["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv8);
     
        var dv9 = document.createElement("div"); //b m
        dv9.className="div_handle div_handleS";
        dv9.setAttribute("type","MDivS");
        if (dv9.attachEvent) { dv9.attachEvent("onmousedown" , ImgMove);} 
        else if (dv9.addEventListener) { dv9.addEventListener("mousedown", ImgMove, true);} 
        else {dv9["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv9);

        var dv10 = document.createElement("div"); //b l
        dv10.className="div_handle div_handleSW";
        dv10.setAttribute("type","MDivSW");
        if (dv10.attachEvent) { dv10.attachEvent("onmousedown" , ImgMove);} 
        else if (dv10.addEventListener) { dv10.addEventListener("mousedown", ImgMove, true);} 
        else {dv10["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv10);


        var dv11 = document.createElement("div"); //m l
        dv11.className="div_handle div_handleW";
        dv11.setAttribute("type","MDivW");
        if (dv11.attachEvent) { dv11.attachEvent("onmousedown" , ImgMove);} 
        else if (dv11.addEventListener) { dv11.addEventListener("mousedown", ImgMove, true);} 
        else {dv11["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv11);

        var dv12 = document.createElement("div");
        dv12.className="div_handle div_handleNW";
        dv12.setAttribute("type","MDivNW");
        if (dv12.attachEvent) { dv12.attachEvent("onmousedown" , ImgMove);} 
        else if (dv12.addEventListener) { dv12.addEventListener("mousedown", ImgMove, true);} 
        else {dv12["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv12);

        var dv13 = document.createElement("div");
        dv13.className="div_clickArea";
        dv13.setAttribute("type","MDivC");
        if (dv13.attachEvent) { dv13.attachEvent("onmousedown" , ImgMove);} 
        else if (dv13.addEventListener) { dv13.addEventListener("mousedown", ImgMove, true);} 
        else {dv13["onmousedown"] = ImgMove;	}
        mdv.appendChild(dv13);
        src.appendChild(mdv);
    }
}
function changebackgroubd(val,id)
{
}
function unSelAll()
{
    for(var i=0; i<idnm; i++)
    {
        if(document.getElementById("'div'_" + i))
        {
            var obj=document.getElementById("'div'_" + i);
            var obj2=document.getElementById("MovDiv" + obj.id);
            //document.getElementById("txtbx_"+i).style.backgroundColor = "" ;
            if(obj.getAttribute("objtype") == 1)
            {
                document.getElementById("txtbx_"+i).className = "emptythetextbox" ;
            }
            if(obj2)
            {
                obj.removeChild(obj2);
            }
        }
    }
    selObj="";
    selObjs=new Array();
}
function selDiv(e)
{

    chkCrtlKey=false;
    if(document.getElementById(contPlNm + "DMode").value=="1")
    {
        var src = DefaultButton_GetSrcElement(e);

        if(src.getAttribute("type") )
        {    
            if(src.getAttribute("type")=="imgObj" ) src=src.parentNode;
            if ( e != null && typeof( e.ctrlKey ) != "undefined" ) { chkCrtlKey  = e.ctrlKey; } else {ctrlKey =event.ctrlKey;}

            if(chkCrtlKey==true)
            {
                //alert(selObjs.length);
                if(src.getAttribute("lock")=="false" )
                { 
                    typeObj=src.getAttribute("type");//src.type;
                    islock=src.getAttribute("lock");//src.lock;
                 //   canMove = src.getAttribute("canmove");//src.lock;
				 if(document.getElementById("lockallobjects").value==0)
				 canMove = src.getAttribute("canmove");
				 else
				 canMove = 0;
                    selObj=src.id;
                    creatTable();
                    ctrlSet();
                    selObjs[selObjs.length]=src.id;
                }
            }
            else
            {
                if(src.getAttribute("type")=="MDivN" || src.getAttribute("type")=="MDivNE" || src.getAttribute("type")=="MDivE" || src.getAttribute("type")=="MDivSE" || src.getAttribute("type")=="MDivS" || src.getAttribute("type")=="MDivSW" || src.getAttribute("type")=="MDivW" || src.getAttribute("type")=="MDivNW" || src.getAttribute("type")=="MDivC" || src.getAttribute("type")=="MDivLN" || src.getAttribute("type")=="MDivLE" || src.getAttribute("type")=="MDivLW" || src.getAttribute("type")=="MDivLS") 
                    src=src.parentNode.parentNode;
                unSelAll(); 
                if(src.getAttribute("lock")=="false" )
                {          
					typeObj=src.getAttribute("type");//src.type;
					islock=src.getAttribute("lock");//src.lock;
					canMove = src.getAttribute("canmove");
				 if(document.getElementById("lockallobjects").value==0)
				 canMove = src.getAttribute("canmove");
				 else
				 canMove = 0;
					selObj=src.id;
					selObjs[0]=src.id;
					creatTable();
					ctrlSet();
                }
            }
        }
        else
        { 
            unSelAll();
            ctrlSet();
        }
    }
}
function DefaultButton_GetSrcElement(e) 
{
    if ( typeof( window.event ) != "undefined" ) 
    {
        return window.event.srcElement;
    }
    if ( e != null && typeof( e.target ) != "undefined" ) 
    {
        return e.target;
    }
    return null;
}
function chgTxt(e)
{
    var src = DefaultButton_GetSrcElement(e);
    arr=src.id.split("_");
    if(arr.length>1)
    { 
        document.getElementById("'div'_" + arr[1] ).innerHTML=src.value.replace(/\n/g,"<br>");  
    }
}
function CheckKeyCodeInteger(e)
{
    var kcode = 0;
    kcode=isIE ? event.keyCode : e.which;
    //var kcode = (window.Event) ? e.which : e.keyCode;
    if((kcode >= 48 && kcode <= 57) || (kcode >= 96 && kcode <= 105) || (kcode >= 37 && kcode <= 40) || (kcode == 8 || kcode == 46 || kcode == 9)) 
        {return true;}
    else 
        {return false;}
        
}
//========================= Div move functions ============================

//isIE=document.all;
//isNN=!document.all&&document.getElementById;
//isN4=document.layers;
//isHot=false; nowX=0; nowY=0,nowW=0,nowH=0;
//movtype=0;
//var anowX=new Array();
//var anowY=new Array();
//var anowW=new Array();
//var anowH=new Array();

function ImgMove(e)
{
    if(canMove == "1" || canMove == null )
    {
        var src = DefaultButton_GetSrcElement(e);
        topObj=isIE ? "BODY" : "HTML";
        whichObj=src.parentNode.parentNode;  
        hotObj=src;  
        offsetx=isIE ? event.clientX : e.clientX;
        offsety=isIE ? event.clientY : e.clientY;
        nowX=parseInt(whichObj.style.left);
        nowY=parseInt(whichObj.style.top);
        nowW=parseInt(whichObj.style.width);
        nowH=parseInt(whichObj.style.height);
        ddEnabled=true;
        anowX=new Array();
        anowY =new Array();
        for( var i=0; i < selObjs.length; i++)
        {
            if(selObjs[i]!="")
            {  
             anowX[i]=parseInt(document.getElementById(selObjs[i]).style.left);
             anowY[i]=parseInt(document.getElementById(selObjs[i]).style.top);
             anowW[i]=parseInt(document.getElementById(selObjs[i]).style.width);
             anowH[i]=parseInt(document.getElementById(selObjs[i]).style.height);
            }
            document.onmousemove=dd;
        }
    }
}
function dd(e)
{
    if (!ddEnabled) 
    {
        if(whichObj.getAttribute("objtype") == 1)
        {
            var txtht = whichObj.style.height.replace("px","");
            var fontsz = whichObj.style.fontSize.replace("pt","");
            if(txtht>(fontsz*1.8) || txtht<(fontsz*1.8))
            whichObj.style.height = fontsz*1.8+'px';
        }
        return;
    }
    var chkBtn=0;
    chkBtn=isIE ? event.button : e.which;
    if(chkBtn==1)
    {
        var ctype="";
        ctype= hotObj.getAttribute("type");
        if(ctype=="MDivC")
        {
            var MWidth= document.getElementById(contPlNm +"Div1").style.pixelWidth;
            var MHeight= document.getElementById(contPlNm +"Div1").style.pixelHeight;
            if(isIE)
            {       
                if(nowX+event.clientX-offsetx<0) return false;
                if(nowX+event.clientX-offsetx +whichObj.style.pixelWidth>MWidth) return false;
                if(nowY+event.clientY-offsety<0)return false;
                if(nowY+event.clientY-offsety+ whichObj.style.pixelHeight>MHeight)return false;
             }
             else
             {
                if(nowX+e.clientX-offsetx<0) return false;
                if(nowX+e.clientX-offsetx +whichObj.style.pixelWidth>MWidth) return false;
                if(nowY+e.clientY-offsety<0)return false;
                if(nowY+e.clientY-offsety+ whichObj.style.pixelHeight>MHeight)return false;
              }   
            for( var i=selObjs.length-1; i >= 0; i--)
            {
                if(selObjs[i]!="" )
                {  
                document.getElementById(selObjs[i]).style.left=isIE ? anowX[i]+event.clientX-offsetx : anowX[i]+e.clientX-offsetx+ "px"; 
                document.getElementById(selObjs[i]).style.top=isIE ? anowY[i]+event.clientY-offsety : anowY[i]+e.clientY-offsety+ "px";
                }
            }
        }
        else if(ctype=="MDivS")
        {
            whichObj.style.height=isIE ? nowH+event.clientY-offsety : nowH+e.clientY-offsety + "px";
        }
        else if(ctype=="MDivE")
        {
            whichObj.style.width=isIE ? nowW+event.clientX-offsetx : nowW+e.clientX-offsetx + "px"; 
        }
        else if(ctype=="MDivSE")
        {
            whichObj.style.width=isIE ? nowW+event.clientX-offsetx : nowW+e.clientX-offsetx + "px"; 
            whichObj.style.height=isIE ? nowH+event.clientY-offsety : nowH+e.clientY-offsety + "px";
        }
        else if(ctype=="MDivW")
        {
            whichObj.style.width=isIE ? nowW+ offsetx - event.clientX : nowW+ offsetx- e.clientX + "px"; 
            whichObj.style.left=isIE ? nowX+event.clientX-offsetx : nowX+e.clientX-offsetx + "px"; 
        }
        else if(ctype=="MDivN")
        {
            whichObj.style.height=isIE ? nowH+ offsety - event.clientY : nowH+ offsety- e.clientY+ "px"; 
            whichObj.style.top=isIE ? nowY+event.clientY-offsety : nowY+e.clientY-offsety+ "px";
        }
        else if(ctype=="MDivNW")
        {
            whichObj.style.height=isIE ? nowH+ offsety - event.clientY : nowH+ offsety- e.clientY + "px"; 
            whichObj.style.top=isIE ? nowY+event.clientY-offsety : nowY+e.clientY-offsety + "px";
            whichObj.style.width=isIE ? nowW+ offsetx - event.clientX : nowW+ offsetx- e.clientX + "px"; 
            whichObj.style.left=isIE ? nowX+event.clientX-offsetx : nowX+e.clientX-offsetx + "px"; 
        }
         else if(ctype=="MDivSW")
        {
            whichObj.style.height=isIE ? nowH+event.clientY-offsety : nowH+e.clientY-offsety + "px";
            whichObj.style.width=isIE ? nowW+ offsetx - event.clientX : nowW+ offsetx- e.clientX + "px"; 
            whichObj.style.left=isIE ? nowX+event.clientX-offsetx : nowX+e.clientX-offsetx + "px"; 
        }
         else if(ctype=="MDivNE")
        {
            whichObj.style.height=isIE ? nowH+ offsety - event.clientY : nowH+ offsety- e.clientY + "px"; 
            whichObj.style.top=isIE ? nowY+event.clientY-offsety : nowY+e.clientY-offsety + "px";
            whichObj.style.width=isIE ? nowW+event.clientX-offsetx : nowW+e.clientX-offsetx + "px"; 
        }
    } 
    return false;  
}
document.onmouseup=Function("ddEnabled=false");
function keyProcess(e)
{
    try
    {
    //alert("sdgdsgdg");
    if((selObj!="") && (islock=="false") && (canMove == "1"))
    {

     var src = document.getElementById(selObj);

        if(src.getAttribute("lock")=="false")
        {
        
         kcode=0;
         kcode=isIE ? event.keyCode : e.which;
         chkCrtlKey=isIE ? event.ctrlKey : e.ctrlKey;
         chkShiftKey=isIE ? event.shiftKey : e.shiftKey;


         
        if(kcode==40||kcode==37||kcode==39||kcode==38||kcode==46) {
        var MWidth= parseInt(document.getElementById(contPlNm +"Div1").style.width);
        var MHeight= parseInt(document.getElementById(contPlNm +"Div1").style.height);
        if(chkCrtlKey==false && chkShiftKey==false)
        {
            if(kcode==40)    // Down
            {
                for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                        if(parseInt(document.getElementById(selObjs[i]).style.top)+parseInt(document.getElementById(selObjs[i]).style.height)+5<MHeight) document.getElementById(selObjs[i]).style.top=parseInt(document.getElementById(selObjs[i]).style.top)+5 + "px";  
                    }
                }
            }
            else if(kcode==38) // Up
            { 
                for( var i=selObjs.length-1; i >= 0; i--)
                    {
                        if(selObjs[i]!="")
                        {       
                            if(parseInt(document.getElementById(selObjs[i]).style.top)>=0) document.getElementById(selObjs[i]).style.top=parseInt(document.getElementById(selObjs[i]).style.top)-5 + "px";
                        }
                    }
            } 
            else if(kcode==37) // Left
            { 
                for( var i=selObjs.length-1; i >= 0; i--)
                    {
                        if(selObjs[i]!="")
                        {       
                            if(parseInt(document.getElementById(selObjs[i]).style.left)>=0) document.getElementById(selObjs[i]).style.left=parseInt(document.getElementById(selObjs[i]).style.left)-5 + "px";
                        }
                    }
            } 
            else if(kcode==39) // Right
            { 
                for( var i=selObjs.length-1; i >= 0; i--)
                    {
                        if(selObjs[i]!="")
                        {       
                            if(parseInt(document.getElementById(selObjs[i]).style.left)+parseInt(document.getElementById(selObjs[i]).style.width)+5<MWidth) document.getElementById(selObjs[i]).style.left=parseInt(document.getElementById(selObjs[i]).style.left)+5 + "px";
                        }
                    }
            
            
            } 
        }
        else if(chkCrtlKey==false && chkShiftKey==true)
        {
            if(kcode==40) 
            { 
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                      if(parseInt(document.getElementById(selObjs[i]).style.top)+parseInt(document.getElementById(selObjs[i]).style.height)<MHeight)     document.getElementById(selObjs[i]).style.top=parseInt(document.getElementById(selObjs[i]).style.top)+1 + "px";
                    }
                }
            }
            else if(kcode==38) 
            { 
               for( var i=selObjs.length-1; i >= 0; i--)
               {
                    if(selObjs[i]!="")
                    {       
                       if(parseInt(document.getElementById(selObjs[i]).style.top)>=0) document.getElementById(selObjs[i]).style.top=parseInt(document.getElementById(selObjs[i]).style.top)-1 + "px";
                    }
                }
            }
            else if(kcode==37) 
            { 
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                        
                        if(parseInt(document.getElementById(selObjs[i]).style.left)>=0) document.getElementById(selObjs[i]).style.left=parseInt(document.getElementById(selObjs[i]).style.left)-1 + "px" ;
                    }
                }
            }
            else if(kcode==39)
            { 
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                         if(parseInt(document.getElementById(selObjs[i]).style.left)+parseInt(document.getElementById(selObjs[i]).style.width)<MWidth) document.getElementById(selObjs[i]).style.left=parseInt(document.getElementById(selObjs[i]).style.left)+1 + "px";
                    }
                }
                
            }
        }
        else if(chkCrtlKey==true && chkShiftKey==false)
        {
            if(kcode==40)
            {
                for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                       document.getElementById(selObjs[i]).style.height=parseInt(document.getElementById(selObjs[i]).style.height)+5 + "px";  
                    }
                }
             
             }
            else if(kcode==38)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                            document.getElementById(selObjs[i]).style.height=parseInt(document.getElementById(selObjs[i]).style.height)-5 + "px";  
                    }
                }

            }
            else if(kcode==37)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                           document.getElementById(selObjs[i]).style.width=parseInt(document.getElementById(selObjs[i]).style.width)-5 + "px";   
                    }
                }

             }
            else if(kcode==39)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                         
                         document.getElementById(selObjs[i]).style.width=parseInt(document.getElementById(selObjs[i]).style.width)+5 + "px";  
                    }
                }

             }
        }
        else if(chkCrtlKey==true && chkShiftKey==true)
        {
            if(kcode==40)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                         document.getElementById(selObjs[i]).style.height=parseInt(document.getElementById(selObjs[i]).style.height)+1 + "px"; 
                    }
                }

             }
            else if(kcode==38)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                         document.getElementById(selObjs[i]).style.height=parseInt(document.getElementById(selObjs[i]).style.height)-1 + "px"; 
                    }
                }
             
             }
            else if(kcode==37)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                            document.getElementById(selObjs[i]).style.width=parseInt(document.getElementById(selObjs[i]).style.width)-1 + "px"; 
                    }
                }
             }
            else if(kcode==39)
            {
            for( var i=selObjs.length-1; i >= 0; i--)
                {
                    if(selObjs[i]!="")
                    {       
                         document.getElementById(selObjs[i]).style.Width=parseInt(document.getElementById(selObjs[i]).style.width)+1 + "px"; 
                    }
                }
             
             }
        }
        }
      }      
      return false;
      }
    }
    catch(err){return false};
}
///////////// TO DELETE SELECTED OBJECTS//////
function deleteselected()
{
    for(var i=0;i<divsarray.length;i++)
    {
        if(selObj == "'div'_"+i)
        {
            for(var j=0;j<imgsarray.length;j++)
            {
                if(i == j)
                {
                    var div_inter_img = imgsarray.splice(i,1);
                }
            }
            var div_inter = divsarray.splice(i,1);
        }
    }
    for( var i=selObjs.length-1; i >= 0; i--)
    {
        if(selObjs[i]!="")
        {
        var var_remove = document.getElementById(selObjs[i]).id.replace("'div'","");
        if(document.getElementById(selObjs[i]).getAttribute("objtype") == 1)
        document.getElementById("txtbx"+var_remove).disabled = true;
        document.getElementById(contPlNm + "CardDiv").removeChild(document.getElementById(selObjs[i]));
        }
    }
}
////////////// TO DELETE SELECTED OBJECTS
//============================================================================

function lockobjects()
{
	unSelAll();
	if(document.getElementById("lockallobjects").value==1)
	{
	document.getElementById("lockobjects").innerHTML = "Lock";
	document.getElementById("lockallobjects").value=0;
	}
	else
	{
	document.getElementById("lockobjects").innerHTML = "Unlock";
	document.getElementById("lockallobjects").value=1;
	}
}
function getDiv(val)
{
    valu_refresh = 1;
    unSelAll();
    var var_imgs = '';
    var del = '';
    var delt = '';
    var var_texts = '';
    var abc='';
    document.getElementById("ctl00_ContentPlaceHolder1_txtHtml").value=document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").innerHTML;
    //document.write(document.getElementById("ctl00_ContentPlaceHolder1_txtHtml").value);
    var f = document.forms['odsform'];
    //alert(f.ctl00_ContentPlaceHolder1_txtHtml.value);
    f.divcontent.value = f.ctl00_ContentPlaceHolder1_txtHtml.value;
    for(var i=0;i<divsarray.length;i++)
    {
    //alert(document.getElementById("'div'_"+divsarray[i]).style.visibility);
	    if(document.getElementById("'div'_"+divsarray[i]))
	    if(document.getElementById("'div'_"+divsarray[i]).style.visibility!='hidden'){
	    {
	    //alert(divsarray.length);
	    //alert(divsarray[i]);
		    for(var j=0;j<imgsarray.length;j++)
		    {
		    if(divsarray[i]==imgsarray[j])
		    {
		    var_imgs = var_imgs+del+document.getElementById("'div'_"+divsarray[i]).style.width+'||'+document.getElementById("'div'_"+divsarray[i]).style.height+'||'+document.getElementById("'div'_"+divsarray[i]).style.top+'||'+document.getElementById("'div'_"+divsarray[i]).style.left+'||'+document.getElementById("'img'_"+imgsarray[j]).src;/**/
		    //alert(var_imgs);
		    del = ',';
		    abc = 1;
		    break;
		    }
		    }
		    if(abc != 1)
		    {
		    var_texts = var_texts+delt+document.getElementById("'div'_"+divsarray[i]).innerHTML+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontFamily+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontSize+'||'+document.getElementById("'div'_"+divsarray[i]).style.top+'||'+document.getElementById("'div'_"+divsarray[i]).style.left+'||'+document.getElementById("'div'_"+divsarray[i]).style.width+'||'+document.getElementById("'div'_"+divsarray[i]).style.height+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontWeight+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontStyle+'||'+document.getElementById("'div'_"+divsarray[i]).style.textDecoration+'||'+document.getElementById("'div'_"+divsarray[i]).style.textAlign+'||'+document.getElementById("'div'_"+divsarray[i]).style.color;/**/
		    //alert(var_texts);
		    delt = ',,';
		    }
		    abc = 0;
	    }}
    }
    f.bgimg.value = document.getElementById('ctl00_ContentPlaceHolder1_bkImg').src;
    f.imagevalues.value = var_imgs;
    f.textvalues.value = var_texts;
    if(val == 'pdf')
    f.action = "view_preview_new.html?pdf=1";
		    f.ctl00_ContentPlaceHolder1_CtrlList_values.value = document.getElementById('ctl00_ContentPlaceHolder1_CtrlList').innerHTML;
		    f.ctl00_ContentPlaceHolder1_Div1_values.value = document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML;
		    //alert(f.ctl00_ContentPlaceHolder1_CtrlList_values.value);
		    //alert(f.ctl00_ContentPlaceHolder1_Div1_values.value);
    f.submit();
}
function chngBkImg(val)
{
    document.getElementById(contPlNm +"imgPath").value=val;
    if(val!="")
    {
    document.getElementById(contPlNm +"bkImg").src=val;
    document.getElementById(contPlNm +"bkImg").style.visibility="visible";
    }
    else
    {
    document.getElementById(contPlNm +"bkImg").src=val;
    document.getElementById(contPlNm +"bkImg").style.visibility="hidden";
    }
}
function mbtnOver(src)
{
    //alert("mbtnOver");
    //src.style.borderColor="#000000";
    //src.style.borderWidth="1px";
    //src.style.borderStyle="solid";
}
function mbtnOut(src)
{
    //alert("mbtnOut");
    src.style.borderWidth="0px";
    src.style.borderStyle="none";
}
var ttlGrid=0;
function showhideGridline()
{
    //document.getElementById(contPlNm + "Div1").style.height
    if(ttlGrid==0)
    {
        var glf=0;
        var gtp=0;
        var diff=15;
        var CDiv=document.getElementById(contPlNm + "Div1");
        var cnt=0;
        var zi=1000;
        for(glf=0; glf<=parseInt(CDiv.style.width); glf=glf+diff)
        {
            for(gtp=0; gtp<=parseInt(CDiv.style.height); gtp=gtp+diff)
            {
                // ridge outset  hidden groove double dotted dashed
                var griddiv= document.createElement("div");
                griddiv.setAttribute("id","griddiv_" + cnt );
                griddiv.setAttribute("type","gridline");
                griddiv.style.position="absolute";
                griddiv.style.backgroundColor="transparent";
                griddiv.style.display="inline";
                griddiv.style.overflow="visible";
                griddiv.style.zIndex="1";
                griddiv.style.overflow="hidden";
                griddiv.appendChild(document.createTextNode("."));
                griddiv.style.fontFamily="Arial";
                griddiv.style.fontSize="6pt";
                griddiv.style.fontWeight="normal";
                griddiv.style.color="#000000";
                griddiv.style.textAlign="center";

                griddiv.style.left=glf + "px"; 
                griddiv.style.top=gtp + "px"; 
                griddiv.style.width=diff + "px";
                griddiv.style.height=diff + "px";
                CDiv.appendChild(griddiv);
                cnt++;
            }
        }
        ttlGrid=cnt;
    }
    else
    {
        var dv=document.getElementById(contPlNm + "Div1");
        for(var i=0;i<ttlGrid;i++)
        {
            obj=document.getElementById("griddiv_"+i);
            if(obj)
            {
                if(obj.getAttribute("type")=="gridline")
                {
                    dv.removeChild(obj);
                }
            }
        }
        ttlGrid=0; 
    }
}
function zoomit(a)
{
    zvalue = document.getElementById("zoomvalue").value;
    if(a == 'i')
    {
        zvalue_f = eval(eval(zvalue)+10);
    }
    if(a == 'o')
    {
        if(zvalue != 100)
        {
            zvalue_f = eval(eval(zvalue)-10);
        }
    }
    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.zoom=zvalue_f+"%";
    document.getElementById("zoomvalue").value = zvalue_f;
}
function getvals(val)
{		
    var aa=document.forms["odsform"].ctl00_ContentPlaceHolder1_imgBk;
    var optn = document.createElement("OPTION");
    optn.text = val;
    optn.value = val;
    aa.options.add(optn);
}
var http_request = false;
function makePOSTRequest(url, parameters) {
  http_request = false;
  if (window.XMLHttpRequest) { // Mozilla, Safari,...
     http_request = new XMLHttpRequest();
     if (http_request.overrideMimeType) {
     	// set type accordingly to anticipated content type
        //http_request.overrideMimeType('text/xml');
        http_request.overrideMimeType('text/html');
     }
  } else if (window.ActiveXObject) { // IE
     try {
        http_request = new ActiveXObject("Msxml2.XMLHTTP");
     } catch (e) {
        try {
           http_request = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (e) {}
     }
  }
  if (!http_request) {
     alert('Cannot create XMLHTTP instance');
     return false;
  }
  
  http_request.onreadystatechange = alertContents;
  http_request.open('POST', url, true);
  http_request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
  http_request.setRequestHeader("Content-length", parameters.length);
  http_request.setRequestHeader("Connection", "close");
  http_request.send(parameters);
}

function alertContents() {
  if (http_request.readyState == 4) {
     if (http_request.status == 200) {
        //alert(http_request.responseText);
        result = http_request.responseText;
        document.getElementById('myspan').innerHTML = result;            
     } else {
        alert('There was a problem with the request.');
     }
  }
}
function get(obj) 
{
    unSelAll();
    var var_imgs = '';
    var del = '';
    var delt = '';
    var var_texts = '';
    var abc='';
    document.getElementById("ctl00_ContentPlaceHolder1_txtHtml").value=document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").innerHTML;
    //document.write(document.getElementById("ctl00_ContentPlaceHolder1_txtHtml").value);
    var f = document.forms['odsform'];
    //alert(f.ctl00_ContentPlaceHolder1_txtHtml.value);
    f.divcontent.value = f.ctl00_ContentPlaceHolder1_txtHtml.value;
    for(var i=0;i<divsarray.length;i++)
    {
        //alert(document.getElementById("'div'_"+divsarray[i]).style.visibility);
        if(document.getElementById("'div'_"+divsarray[i]))
        if(document.getElementById("'div'_"+divsarray[i]).style.visibility!='hidden'){
        {
                //alert(divsarray.length);
                //alert(divsarray[i]);
                for(var j=0;j<imgsarray.length;j++)
                {
                    if(divsarray[i]==imgsarray[j])
                    {
                        var_imgs = var_imgs+del+document.getElementById("'div'_"+divsarray[i]).style.width+'||'+document.getElementById("'div'_"+divsarray[i]).style.height+'||'+document.getElementById("'div'_"+divsarray[i]).style.top+'||'+document.getElementById("'div'_"+divsarray[i]).style.left+'||'+document.getElementById("'img'_"+imgsarray[j]).src;/**/
                        //alert(var_imgs);
                        del = ',';
                        abc = 1;
                        break;
                    }
                }
                if(abc != 1)
                {
                    var_texts = var_texts+delt+document.getElementById("'div'_"+divsarray[i]).innerHTML+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontFamily+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontSize+'||'+document.getElementById("'div'_"+divsarray[i]).style.top+'||'+document.getElementById("'div'_"+divsarray[i]).style.left+'||'+document.getElementById("'div'_"+divsarray[i]).style.width+'||'+document.getElementById("'div'_"+divsarray[i]).style.height+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontWeight+'||'+document.getElementById("'div'_"+divsarray[i]).style.fontStyle+'||'+document.getElementById("'div'_"+divsarray[i]).style.textDecoration+'||'+document.getElementById("'div'_"+divsarray[i]).style.textAlign+'||'+document.getElementById("'div'_"+divsarray[i]).style.color;/**/
                    //alert(var_texts);
                    delt = ',,';
                }
                abc = 0;
            }
        }
    }
    f.bgimg.value = document.getElementById('ctl00_ContentPlaceHolder1_bkImg').src;
    f.imagevalues.value = var_imgs;
    f.textvalues.value = var_texts;
    var poststr = "imagevalues=" + f.imagevalues.value+"&textvalues=" + f.textvalues.value+"&bgimg="+f.bgimg.value;
    //if(val == 'pdf')
    //f.action = "view_preview_new.php?pdf=1";
    //f.submit();
    //alert(poststr);
    makePOSTRequest('post.php', poststr);
}
function abc()
{
lightbox();
//alert('here');
}
/*
 *	Written by Jonathan Snook, http://www.snook.ca/jonathan
 *	Add-ons by Robert Nyman, http://www.robertnyman.com
 */
function getElementsByClassName(oElm, strTagName, oClassNames)
{
    var arrElements = (strTagName == "*" && oElm.all)? oElm.all : oElm.getElementsByTagName(strTagName);
    var arrReturnElements = new Array();
    var arrRegExpClassNames = new Array();
    if(typeof oClassNames == "object"){
	    for(var i=0; i<oClassNames.length; i++){
		    arrRegExpClassNames.push(new RegExp("(^|\s)" + oClassNames[i].replace(/-/g, "\-") + "(\s|$)"));
	    }
    }
    else{
	    arrRegExpClassNames.push(new RegExp("(^|\s)" + oClassNames.replace(/-/g, "\-") + "(\s|$)"));
    }
    var oElement;
    var bMatchesAll;
    for(var j=0; j<arrElements.length; j++){
	    oElement = arrElements[j];
	    bMatchesAll = true;
	    for(var k=0; k<arrRegExpClassNames.length; k++){
		    if(!arrRegExpClassNames[k].test(oElement.className)){
			    bMatchesAll = false;
			    break;
		    }
	    }
	    if(bMatchesAll){
		    arrReturnElements.push(oElement);
	    }
    }
    return (arrReturnElements)
}
/*
 * Written by Cadu de Castro Alves, http://www.cadudecastroalves.com
 * Based on Emanuele Feronato technique, http://www.emanueleferonato.com/2007/08/22/create-a-lightbox-effect-only-with-css-no-javascript-needed/
 */
function alignthis(val)
{
    if(val == 'left')chngObjLAlign();
    if(val == 'center')chngObjCAlign();
    if(val == 'right')chngObjRAlign();
}

   








