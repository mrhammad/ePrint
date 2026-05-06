// JScript File

  function getrowvalue()
  {
  
     var returnvalue=true;
     var finaltext = "";
     var hid_headername=document.getElementById("hid_headername");
     var lang = document.getElementById("ctl00_ContentPlaceHolder1_hid_language").value;
     var prevrow = document.getElementById("ctl00_ContentPlaceHolder1_hid_prevrow");		        	 
     var rowno = document.getElementById("ctl00_ContentPlaceHolder1_hid_norow");
     var txt = document.getElementById("ctl00_ContentPlaceHolder1_hid_fieldvalue"); 
     //gaj for check duplicacy
     var chkduplicate;
     //gaj
     
     for(var count=1; count <= Number(rowno.value) ;count++)
	 {
	    if(count<=Number(prevrow.value))
	    {            
            var txtvalue = document.getElementById("ctl00_ContentPlaceHolder1_txtbox"+count+"_"+lang+"");             
            //gaj
            if(txtvalue.value.length!='')
            {
            chkduplicate+=txtvalue.value.toUpperCase()+",";
            }
            //gaj
	    }
	    else
	    {
	       try
	       {
            var txtvalue = document.getElementById("txtbox"+count+"");   
              //gaj
              chkduplicate=chkduplicate.replace('undefined','');
              chkduplicate=chkduplicate.split(',');
             // alert(chkduplicate);
              for(i=0;i<chkduplicate.length;i++)
              {
                 if(txtvalue.value.length!='')
                 {
                  if(chkduplicate[i].toUpperCase()==(txtvalue.value.toUpperCase()))                
                    {
                    
                    alert('Record already exists, please enter any other record');
                    txtvalue.value = "";
                    txtvalue.focus();
                    returnvalue=false;
                    break;     
                    }
                }
              }
            }
            catch(err)
            {
            }
          
              //gaj
        }
        if(txtvalue.value !="")
        {
           //finaltext =  finaltext   + "#" + chkvalue.checked+ "^" + txtvalue.value;                        
           finaltext =  finaltext  + "^" + txtvalue.value;                        
	    }
     }  
     
     txt.value = finaltext; 
     return returnvalue;   
  }
  
  function checkbox_checked(chkbox)
  {
     var lang = document.getElementById("ctl00_ContentPlaceHolder1_hid_language").value;
     var prevrow = document.getElementById("ctl00_ContentPlaceHolder1_hid_prevrow");
     for(var count=1; count <= Number(prevrow.value) ;count++)
	 {
         var chkvalue = document.getElementById("ctl00_ContentPlaceHolder1_chkbox"+count+"_"+lang+"");                  
         if(chkbox.checked)
         {
           chkvalue.checked = true;           
         }
         else
         {
           chkvalue.checked = false;
         }
     }    
  } 
  function checkbox_uncheck(lang)
  {
     var flage = true;     
     var chkall = document.getElementById("ctl00_ContentPlaceHolder1_top_'"+ lang +"'");            
     var prevrow = document.getElementById("ctl00_ContentPlaceHolder1_hid_prevrow");          
     for(count=1; count <= Number(prevrow.value) ;count++)
	 {
	     var chkvalue = document.getElementById("ctl00_ContentPlaceHolder1_chkbox"+ count +"_'"+ lang +"'"); 
         if(chkvalue.checked)
         {
           flage = true;           
         }      
         else
         {
           flage = false;   
           break;                             
         }                    
     }            
     if(!flage)
     {
        chkall.checked = false;   
     }  
     else
     {
        chkall.checked = true;
     }
  }
  
  function checkall(parm)  
  {
     var lang = document.getElementById("ctl00_ContentPlaceHolder1_hid_language").value;
     var prevrow = document.getElementById("ctl00_ContentPlaceHolder1_hid_prevrow");
     var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_top_"+lang+""); 
     for(var count=1; count <= Number(prevrow.value) ;count++)
	 {
         var chkvalue = document.getElementById("ctl00_ContentPlaceHolder1_chkbox"+count+"_"+lang+"");                  
         if(parm=='all')
         {
            chkvalue.checked=true;
            chkbox.checked = true;
         }
         else
         {
            chkvalue.checked=false;
            chkbox.checked = false;
         }       
     }         
  } 
  
  function clickDelete(msg)
  {        
     var totaldelete = 0;
     var lang = document.getElementById("ctl00_ContentPlaceHolder1_hid_language").value;
     var prevrow = document.getElementById("ctl00_ContentPlaceHolder1_hid_prevrow");
     for(var count=1; count <= Number(prevrow.value) ;count++)
	 {
	     var chkvalue = document.getElementById("ctl00_ContentPlaceHolder1_chkbox"+count+"_"+lang+"");         
         if(chkvalue.checked)
         {           
           totaldelete = totaldelete + 1;
         }
     }    
     if(totaldelete>0)
     {
        return window.confirm('Are you sure, you want to delete?');
     }
     else
     {
        alert("Please select "+msg+" to delete");
     }
     return false;
  }  

