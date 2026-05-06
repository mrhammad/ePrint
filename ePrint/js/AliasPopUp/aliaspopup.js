// JScript File

function fillalias(txtname,txtalias)
{
 
 document.getElementById("ctl00_ContentPlaceHolder1_"+txtalias).value=txtnamevalue=document.getElementById("ctl00_ContentPlaceHolder1_"+txtname).value;

}
function fillalias123(txtfirstname,txtname,txtalias)
{
 
 document.getElementById("ctl00_ContentPlaceHolder1_"+txtalias).value=document.getElementById("ctl00_ContentPlaceHolder1_"+txtfirstname).value+" "+document.getElementById("ctl00_ContentPlaceHolder1_"+txtname).value;
}
