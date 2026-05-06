// JScript File

    function changeStyle(xobj,xStyle,xbgColor,xColor) 
	    {
		    xobj.className = xStyle;
		    xobj.style.backgroundColor = xbgColor;
		    xobj.style.color = xColor;		    
	    }
	    
	    

function FillAliasBox(aliasId,pg)
    {
        if(pg=="lead")
        {
            var firstName = document.getElementById("ctl00_ContentPlaceHolder1_firstName")
            var lastName = document.getElementById("ctl00_ContentPlaceHolder1_lastName")
//            if(aliasId.value=="")
//            {
                if(firstName.value!="" && lastName.value!="")
                {
                    aliasId.value =firstName.value+"_"+ lastName.value;        
                }
                else if(firstName.value!="" && lastName.value=="")    
                {
                    aliasId.value =firstName.value;        
                }
                else if(firstName.value=="" && lastName.value!="")    
                {
                    aliasId.value =lastName.value;        
                }
//            }
        }
        else if(pg=="client")
        {
            var ClientName = document.getElementById("ctl00_ContentPlaceHolder1_clientname")
            aliasId.value =ClientName.value.replace(' ','');
            
            
        }
        else if(pg=="contact")
        {
            var firstName = document.getElementById("ctl00_ContentPlaceHolder1_firstName")
            var lastName = document.getElementById("ctl00_ContentPlaceHolder1_lastName")
//            if(aliasId.value=="")
//            {
                if(firstName.value!="" && lastName.value!="")
                {
                    aliasId.value =firstName.value+"_"+ lastName.value;        
                }
                else if(firstName.value!="" && lastName.value=="")    
                {
                    aliasId.value =firstName.value;        
                }
                else if(firstName.value=="" && lastName.value!="")    
                {
                    aliasId.value =lastName.value;        
                }
//            }
            
            
        }
        else if(pg=="opportunity")
        {
            var ClientName = document.getElementById("ctl00_ContentPlaceHolder1_opportunityName")
             aliasId.value =ClientName.value.replace(' ','_');
            
        }
        else if(pg=="campaign")
        {
            var ClientName = document.getElementById("ctl00_ContentPlaceHolder1_campaignname")
            aliasId.value =ClientName.value.replace(' ','_');
            
            
        }
        else if(pg=="product")
        {
            var ClientName = document.getElementById("ctl00_ContentPlaceHolder1_productname")
             aliasId.value =ClientName.value.replace(' ','_');
            
            
        }
        else if(pg=="asset")
        {
            var ClientName = document.getElementById("ctl00_ContentPlaceHolder1_assetname")
             aliasId.value =ClientName.value.replace(' ','_');
        }
    }
    function CopyAdress(SectionName)
        {
            if(SectionName=='client')
            {
                //for billing street
                try
                {
                    var billingstreet=document.getElementById("ctl00_ContentPlaceHolder1_billingstreet");
                    var shippingstreet=document.getElementById("ctl00_ContentPlaceHolder1_shippingstreet");
                    shippingstreet.value=billingstreet.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcity=document.getElementById("ctl00_ContentPlaceHolder1_billingcity");
                    var shippingcity=document.getElementById("ctl00_ContentPlaceHolder1_shippingcity");
                    shippingcity.value=billingcity.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingstate=document.getElementById("ctl00_ContentPlaceHolder1_billingstate");
                    var shippingstate=document.getElementById("ctl00_ContentPlaceHolder1_shippingstate");
                    shippingstate.value=billingstate.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingzip=document.getElementById("ctl00_ContentPlaceHolder1_billingzip");
                    var shippingzip=document.getElementById("ctl00_ContentPlaceHolder1_shippingzip");
                    shippingzip.value=billingzip.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcountry=document.getElementById("ctl00_ContentPlaceHolder1_billingcountry");
                    var shippingcountry=document.getElementById("ctl00_ContentPlaceHolder1_shippingcountry");
                    shippingcountry.selectedIndex=billingcountry.selectedIndex;
                }
                catch(err)
                {
                }             
            }
            else if(SectionName=='contract')
            {
                //for billing street
                try
                {
                    var billingstreet=document.getElementById("ctl00_ContentPlaceHolder1_billingStreet");
                    var shippingstreet=document.getElementById("ctl00_ContentPlaceHolder1_shippingStreet");
                    shippingstreet.value=billingstreet.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcity=document.getElementById("ctl00_ContentPlaceHolder1_billingCity");
                    var shippingcity=document.getElementById("ctl00_ContentPlaceHolder1_shippingCity");
                    shippingcity.value=billingcity.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingstate=document.getElementById("ctl00_ContentPlaceHolder1_billingState");
                    var shippingstate=document.getElementById("ctl00_ContentPlaceHolder1_shippingState");
                    shippingstate.value=billingstate.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingzip=document.getElementById("ctl00_ContentPlaceHolder1_billingZip");
                    var shippingzip=document.getElementById("ctl00_ContentPlaceHolder1_shippingZip");
                    shippingzip.value=billingzip.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcountry=document.getElementById("ctl00_ContentPlaceHolder1_billingCountry");
                    var shippingcountry=document.getElementById("ctl00_ContentPlaceHolder1_shippingCountry");
                    shippingcountry.selectedIndex=billingcountry.selectedIndex;
                }
                catch(err)
                {
                }             
            }
            else if(SectionName=='contact')
            {
                //for billing street
                try
                {
                    var billingstreet=document.getElementById("ctl00_ContentPlaceHolder1_mailingStreet");
                    var shippingstreet=document.getElementById("ctl00_ContentPlaceHolder1_otherStreet");
                    shippingstreet.value=billingstreet.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcity=document.getElementById("ctl00_ContentPlaceHolder1_mailingCity");
                    var shippingcity=document.getElementById("ctl00_ContentPlaceHolder1_otherCity");
                    shippingcity.value=billingcity.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingstate=document.getElementById("ctl00_ContentPlaceHolder1_mailingState");
                    var shippingstate=document.getElementById("ctl00_ContentPlaceHolder1_otherState");
                    shippingstate.value=billingstate.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingzip=document.getElementById("ctl00_ContentPlaceHolder1_mailingZip");
                    var shippingzip=document.getElementById("ctl00_ContentPlaceHolder1_otherZip");
                    shippingzip.value=billingzip.value;
                }
                catch(err)
                {
                }
                try
                { 
                    var billingcountry=document.getElementById("ctl00_ContentPlaceHolder1_mailingCountry");
                    var shippingcountry=document.getElementById("ctl00_ContentPlaceHolder1_otherCountry");
                    shippingcountry.selectedIndex=billingcountry.selectedIndex;
                }
                catch(err)
                {
                }             
            }
        }