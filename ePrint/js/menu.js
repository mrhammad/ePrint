function AddMenuBehaviour()
{
var menuitems = document.getElementById("menutable").getElementsByTagName("div");
if (menuitems.length)
 {
	for(i=0;i<menuitems.length;i++)
	{ menuitems[i].onmouseover= onMouseOverHandler;
	  menuitems[i].onmouseout = onMouseOutHandler;    };
 }
}

function onMouseOverHandler()
{
this.style.backgroundColor = "#ffcccc";
}
function onMouseOutHandler()
{
this.style.backgroundColor = "";
}
window.onload= AddMenuBehaviour;