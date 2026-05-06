	var imageId;
	
	// Request object
	function Request() {};

	Request.prototype = { 
		xmlRequest: null,
		
		callback: function(self)
		{
			if (self.xmlRequest != null)
			{
				if(self.xmlRequest.readyState == 4)
				{
					processResponse(self.xmlRequest.responseText);				
				}
			}
		},

		execute: function (url, ratingValue, controlId, args)
		{
				
				if(window.ActiveXObject)
				{
					try
					{
						this.xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
					}catch (e)
					{}
				}
				else
				if(typeof(XMLHttpRequest) != 'undefined')
				{
					try
					{
						this.xmlRequest = new XMLHttpRequest();
					}catch(e)
					{}
				}
				
								
				// need to stick this into variable to work
				if(this.xmlRequest != null)
				{
					var self = this;
					this.xmlRequest.onreadystatechange = function()
					{
						self.callback(self);
					}
					this.xmlRequest.open("POST", url ,true);
					this.xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
						
					//Send flags indicaing its a callBack
					if(ratingValue != "")
					{
						var formData = "rrcallBack=true&rrcontrolId="+ controlId  +"&rrurt=" + ratingValue;
						if(args != null)
							formData = formData + "&" + args;
							
						this.xmlRequest.send(formData);
					
					}
				}
		}
	}

	function MSXMLVer()
	{
		var msXML = null;
		
		try
		{
			msXML = new ActiveXObject("Msxml2.DOMDocument.4.0");
			//This line actually throws an Automation error
			msXML.async=false;
			//clear out the COM Object			
			msXML = null;
			return "Msxml2.DOMDocument.4.0";
		}catch (e)
		{
			try
			{
				msXML = new ActiveXObject("Msxml2.DOMDocument.3.0");
				msXML.async=false;
				msXML = null;
				return "Msxml2.DOMDocument.3.0";
			}catch(e)
			{
				msXML = null;
				return null;
			}			
		}		
		return null;
	
	}
	
	function CheckDOM()
	{
		//If IE Browser
		if(window.ActiveXObject)
		{	
			return MSXMLVer();
		}else
		if(document.implementation && document.implementation.createDocument)
		{
			//if Mozzilla/Netscape return a string indicating borwser supports DOM
			return "DOMParser";
		}else
		{
			//No DOM Support real old browser or OS
			return null;
		}
	}
	
	function GetImage(section)
	{
			
			var ratingImg
			var useQueryStrings=false;
			
			if(CheckDOM() == null)
				useQueryStrings = true;
				
			for(var i = 0;i<section.attributes.length; i++)
			{
				if (section.attributes[i].nodeName.toLowerCase() == "image")
				{
					ratingImg = section.attributes[i].nodeValue;			
				}
				
				//remove href only if correct version of MSXML is found on client
				//If client does not have MSXML Version 3.0 remove onclick and keep href		
				if(section.attributes[i].nodeName.toLowerCase() == "href" && !useQueryStrings)
				{
					section.attributes.removeNamedItem("href");
				}else
				if(section.attributes[i].nodeName.toLowerCase() == "onclick" && useQueryStrings)
				{
					
					var onClickItem = document.createAttribute("onclick");
					
					if(onClickItem != null)
					{
						onClickItem.value="";												
						section.attributes.setNamedItem(onClickItem);						
					}					
				}
			}						
			return ratingImg;
	}
	
	
	function ChangeImg(section, imgId)
	{
		var elmImg;
		elmImg = document.getElementById(imgId);			
		elmImg.src=GetImage(section);
	}
	
	function RestoreImg(imgId)
	{
		var originalImg;
		var elmImg;
		elmImg = document.getElementById(imgId);
		originalImg = elmImg.attributes.getNamedItem("originalImg").value;
		elmImg.src = originalImg;
	}		
			
	function processResponse(xmlText)
	{
				var msg;
				var cssClass;
				
				//Load the xml into DOM for futher processing
				var xmlResponse;
				var isMoz=false;
				
				var OpsNode;
				var statusNode;
				var controlNode;				
				var valueNode;
				var ratingNode;
				
				if(window.ActiveXObject)
				{
					
					//First see if Version 4.0 is available
					xmlResponse =  new ActiveXObject(MSXMLVer());
										
					xmlResponse.async=false;	
					xmlResponse.loadXML(xmlText);								
					
					OpsNode = xmlResponse.selectSingleNode("/MSNRR/Ops");
					statusNode = xmlResponse.selectSingleNode("/MSNRR/Status");
					controlNode = xmlResponse.selectSingleNode("/MSNRR/Control");
					valueNode = xmlResponse.selectSingleNode("/MSNRR/Value");
					ratingNode = xmlResponse.selectSingleNode("/MSNRR/Rating");
											
				}
				else
				if(document.implementation && document.implementation.createDocument)
				{
					
					var objDOMParser = new DOMParser();        
					//create new document from string
					xmlResponse = objDOMParser.parseFromString(xmlText, "text/xml");
					
					OpsNode = xmlResponse.getElementsByTagName("Ops").item(0);
					statusNode = xmlResponse.getElementsByTagName("Status").item(0);
					controlNode = xmlResponse.getElementsByTagName("Control").item(0);
					valueNode = xmlResponse.getElementsByTagName("Value").item(0);
					ratingNode = xmlResponse.getElementsByTagName("Rating").item(0);
				}				
				
				
				if(OpsNode != null)
				{
					
					if(OpsNode.firstChild.nodeValue == "POST")
					{
							
						if(statusNode != null)
						{	
							var controlId = controlNode.firstChild.nodeValue;
							var elmImg;
							if(statusNode.firstChild.nodeValue == 0)
							{
								if(valueNode.firstChild.nodeValue.length > 0)
									window.location = valueNode.firstChild.nodeValue;
								
								return;
							}
							else 
							if (statusNode.firstChild.nodeValue == 1)
							{
								//Success
								elmImg = document.getElementById(controlId);
							
								var msgItem = elmImg.attributes.getNamedItem("tMsg");
								if(msgItem != null)
									msg = msgItem.value;
									
								var cssItem = elmImg.attributes.getNamedItem("tMsgCss");
								if(cssItem !=null)
									cssClass = cssItem.value;
								
								
							}else 
							{
								//Fail case
								elmImg = document.getElementById(controlId);
							
								var msgItem = elmImg.attributes.getNamedItem("eMsg");
								if(msgItem != null)
									msg = msgItem.value;
									
								var cssItem = elmImg.attributes.getNamedItem("eMsgCss");
								if(cssItem !=null)
									cssClass = cssItem.value;
							}				
							
							var divMsg = document.getElementById("divMsg" + controlNode.firstChild.nodeValue);
							divMsg.innerHTML = msg;	
							if(cssClass != null)
								divMsg.className = cssClass;
								
							imageId = null;		
							
							//Hide the user count msg
							HideControl("divUCnt" + controlId);												
								
						}						
						
					 }					 	
		
				}//Ops !=null	
	
	}
	function SetRating(section, imgId, isPost, value)
	{
			var originalImg;
			var elmImg;
			var rateForm;
			var hiddenValue;
			var hiddenPosition;
			var msg;
			
			imageId = 	imgId;		
			elmImg = document.getElementById(imgId);			
			if(typeof(section) == "object")
				elmImg.setAttribute("originalImg",GetImage(section));
			else
				elmImg.setAttribute("originalImg",section);
				
			originalImg = elmImg.attributes.getNamedItem("originalImg").value;
			elmImg.src = originalImg;
				
			if(isPost == "true")
			{
				var req = new Request();
				var url;
				var args;
				if (elmImg.attributes.getNamedItem("url") != null)
				{
					url = elmImg.attributes.getNamedItem("url").value;
				}
				
				if(elmImg.attributes.getNamedItem("args") != null)
					args = elmImg.attributes.getNamedItem("args").value;
					
				if(url == null)
					url = window.location;
								
				req.execute(url, value, imgId,args);
				
			}else
			{
				var MSNRRhidden = document.getElementById("rrhid" + imgId);
				MSNRRhidden.value = value;
			}
			return false;
	}
	
	
	function HideControl(controlId)
	{
	
		var control = document.getElementById(controlId);
	
		if(control != null)
			control.style.display = "none";
	}
	
	function ShowControl(controlId)
	{
		var control = document.getElementById(controlId);
		if(control != null)
			control.style.display = "block";
	}
	
	