// JScript File

///////////////////////////////////////////////////////////////////


//edit the below 5 steps

// 1) substitute 116 and 42 with the width and height of your logo image, respectively
var logowidth=10
var logoheight=10
var logoimage=new Image(logowidth,logoheight)

// 2) change the image path to reflect the path of your logo image
logoimage.src="../images/close_new.gif"

// 3) Change url below to the target URL of the logo
var logolink="http://dynamicdrive.com"

// 4) change the alttext variable to reflect the text used for the "alt" attribute of the image tag
var alttext="Close"

// 5) Finally, below variable determines the duration the logo should be visible after loading, in seconds. If you'd like the logo to appear for 20 seconds, for example, enter 20. Entering a value of 0 causes the logo to be perpectually visible. 
var visibleduration=12

// Optional parameters
var Hoffset=10 //Enter logo's offset from right edge of window (edit only if you don't like the default offset)
var Voffset=0 //Enter logo's offset from top edge of window (edit only if you don't like the default offset)


///////////////////////////Do not edit below this line/////////////////////////

var ie=document.all&&navigator.userAgent.indexOf("Opera")==-1

var watermark_obj=ie? document.all.watermarklogo : document.getElementById? document.getElementById("watermarklogo") : document.watermarklogo

function insertimage(){
if (ie||document.getElementById)
watermark_obj.innerHTML='<a href="#" style="color:black;text-decoration: none;font-size: 11px;" onclick="window.close()"><img src="'+logoimage.src+'" width="'+logowidth+'" height="'+logoheight+'" border=0 alt="'+alttext+'">&nbsp;<span style="color:black;text-decoration: none;font-size: 11px;">Close<span></a>'
else if (document.layers){
watermark_obj.document.write('<a href="#" style="color:black;text-decoration: none;font-size: 11px;" onclick="window.close()"><img src="'+logoimage.src+'" width="'+logowidth+'" height="'+logoheight+'" border=0 alt="'+alttext+'">&nbsp;<span style="color:black;text-decoration: none;font-size: 11px;">Close<span></a>')
watermark_obj.document.close()
}
}

function positionit(){
var dsocleft=ie? document.body.scrollLeft : pageXOffset
var dsoctop=ie? document.body.scrollTop : pageYOffset
var window_width=ie? document.body.clientWidth : window.innerWidth-20

if (ie||document.getElementById){
watermark_obj.style.left=parseInt(dsocleft)+parseInt(window_width)-logowidth-Hoffset-40
watermark_obj.style.top=parseInt(dsoctop)+5+Voffset-2
}
else if (document.layers){
watermark_obj.left=dsocleft+window_width-Hoffset-logowidth
watermark_obj.top=dsoctop+window_height+5+Voffset
}
}

function hidewatermark(){
if (document.layers)
watermark_obj.visibility="hide"
else
watermark_obj.style.visibility="hidden"
clearInterval(watermarkinterval)
}

function beingwatermark(){
watermarkinterval=setInterval("positionit()",50)
insertimage()
//if (visibleduration!=0)
//setTimeout("hidewatermark()",visibleduration*1000)
}

if (ie||document.getElementById||document.layers)
window.onload=beingwatermark

