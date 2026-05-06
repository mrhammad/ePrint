var iHeight = 100 ;
var collapseStep = 10 ;
var aniSpeed = 2;

function minimisepanel(objDiv)
{
	var t = parseInt( YAHOO.util.Dom.getStyle(objDiv, 'height'));
	YAHOO.util.Dom.setStyle(objDiv, 'opacity',t/iHeight );
	if(t>0)
	{	t=t-collapseStep ;
		if(t<=0){YAHOO.util.Dom.setStyle(objDiv, 'display','none');}
		YAHOO.util.Dom.setStyle(objDiv, 'height',t);
		setTimeout( "minimisepanel('"+objDiv+"');",aniSpeed);
	}
}

function maximisepanel(objDiv)
{
	YAHOO.util.Dom.setStyle(objDiv, 'display','block')
	var t = parseInt( YAHOO.util.Dom.getStyle(objDiv, 'height'));
	YAHOO.util.Dom.setStyle(objDiv, 'opacity',t/iHeight );
	if(t<=(iHeight-collapseStep))
	{	t=t+collapseStep ;
		YAHOO.util.Dom.setStyle(objDiv, 'height',t);
		setTimeout( "maximisepanel('"+objDiv+"');",aniSpeed);
	}
}


function ShowHide(objID,imgref)
{
	if (YAHOO.util.Dom.getStyle(objID, 'display')=='block')
	{
	minimisepanel(objID);
	imgref.src="../images/opentriangle.gif";
	return
	}
	
	maximisepanel(objID);
	imgref.src="../images/triangle.gif";
}
function ShowDiv(objID)
{
	if (YAHOO.util.Dom.getStyle(objID, 'display')=='block')
	{
	minimisepanel(objID);
	//imgref.src="../images/opentriangle.gif";
	return
	}
	
	maximisepanel(objID);
	//imgref.src="../images/triangle.gif";
}
