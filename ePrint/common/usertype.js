// JScript File

function CheckBoxDisable()
{    
    var counth = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;     
    for(var count=0; count < counth ;count++)
    {     
            var chkview = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
            var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
            var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
            var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
            var chksection = document.getElementById("ctl00_ContentPlaceHolder1_chk_" + count + "");          
            var chkTab = document.getElementById("ctl00_ContentPlaceHolder1_chktab_" + count + "");
            if(chkview.checked && chkadd.checked && chkedit.checked && chkdelete.checked || chkTab.checked )
            {
                chkview.disabled = false;
                chkadd.disabled = false;
                chkedit.disabled = false;
                chkdelete.disabled = false;
                chksection.disabled = false;
                if(chkview.checked && chkadd.checked && chkedit.checked && chkdelete.checked)
                {
                    chksection.checked = true;
                }
            }
            else
            {
                chksection.checked = false;
                chkview.disabled = true;
                chkadd.disabled = true;
                chkedit.disabled = true;
                chkdelete.disabled = true;
                chksection.disabled = true;
            }
    }  
     
    var chkview = document.getElementById("ctl00_ContentPlaceHolder1_chk_view");
    var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_chk_add");
    var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_chk_edit");
    var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_chk_delete");

    
    var flagecontinue1 = true;
    var flagecontinue2 = true;
    var flagecontinue3 = true;
    var flagecontinue4 = true;
    var flagecontinue5 = true;
    var flage1 = false;
    var flage2 = false;
    var flage3 = false;
    var flage4 = false;
    var flage5 = false;
    for(var count=0; count<counth; count++)
    { 
        var chktab = document.getElementById("ctl00_ContentPlaceHolder1_chktab_" + count + "");
        var chkv = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
        var chka = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
        var chke = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
        var chkd = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
        
        if(chktab.checked && flagecontinue5)
        {
            flage5 = true;                    
        }      
        else
        {
            flage5 = false;          
            flagecontinue5 = false;            
        }
        
        if(chkv.checked && flagecontinue1)
        {
            flage1 = true;                    
        }      
        else
        {
            flage1 = false;          
            flagecontinue1 = false;            
        }
           
        /***********************/
        if(chka.checked && flagecontinue2)
        {
            flage2 = true;                    
        }      
        else
        {
            flage2 = false;          
            flagecontinue2 = false;            
        }   
        /***********************/
        if(chke.checked && flagecontinue3)
        {
            flage3 = true;                    
        }      
        else
        {
            flage3 = false;          
            flagecontinue3 = false;            
        }
        /***********************/
        if(chkd.checked && flagecontinue4)
        {
            flage4 = true;                    
        }      
        else
        {
            flage4 = false;          
            flagecontinue4 = false;            
        }   
    }
    
    if(!flage1)
    {
        chkview.checked = false;                           
    }  
    else
    {
        chkview.checked = true;         
    }       
    /***********************/
    if(!flage2)
    {
        chkadd.checked = false;         
    }  
    else
    {
        chkadd.checked = true; 
    }       
    /*******************/
    if(!flage3)
    {
        chkedit.checked = false;      
    }  
    else
    {
        chkedit.checked = true;     
    }       
    /*******************/
    if(!flage4)
    {
        chkdelete.checked = false;  
    }  
    else
    {
        chkdelete.checked = true;   
    }  
    
    if(!flage5)
    {
        chkview.disabled = true;
        chkadd.disabled = true;
        chkedit.disabled = true;
        chkdelete.disabled = true;                        
    }  
    else
    {
        chkview.disabled = false;
        chkadd.disabled = false;
        chkedit.disabled = false;
        chkdelete.disabled = false;              
    }         
}   


function CheckFunctionalites(chkbox,rowno)
{
    var counth = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;  
    var chkview = document.getElementById("ctl00_ContentPlaceHolder1_chk_view");
    var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_chk_add");
    var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_chk_edit");
    var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_chk_delete");
         
    var flagecontinue1 = true;
    var flagecontinue2 = true;
    var flagecontinue3 = true;
    var flagecontinue4 = true;
    var flagecontinue5 = true;
    var flagecontinue6 = true;
    var flage1 = false;
    var flage2 = false;
    var flage3 = false;
    var flage4 = false;
    var flage5 = false;
    var flage6 = false;
    for(var count=0; count<counth; count++)
    {           
        var chktab = document.getElementById("ctl00_ContentPlaceHolder1_chktab_"+count+""); 
        var chkall = document.getElementById("ctl00_ContentPlaceHolder1_chk_"+count+""); 
        var chkv = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
        var chka = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
        var chke = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
        var chkd = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
        
        if(chktab.checked)
        {
//            chkall.checked = true;
//            chkv.checked = true;
//            chka.checked = true;
//            chke.checked = true;
//            chkd.checked = true;   
                    
            chkall.disabled = false;
            chkv.disabled = false;
            chka.disabled = false;
            chke.disabled = false;
            chkd.disabled = false;  
        }
        else
        {
            chkall.checked = false;
            chkv.checked = false;
            chka.checked = false;
            chke.checked = false;
            chkd.checked = false;
            chkall.disabled = true;
            chkv.disabled = true;
            chka.disabled = true;
            chke.disabled = true;
            chkd.disabled = true; 
        }
        
        if(chkall.checked && flagecontinue6)
        {
            flage6 = true;                    
        }      
        else
        {
            flage6 = false;          
            flagecontinue6 = false;            
        }

        
        if(chktab.checked && flagecontinue5)
        {
            flage5 = true;                    
        }      
        else
        {
            flage5 = false;          
            flagecontinue5 = false;            
        }
        
        if(chkv.checked && flagecontinue1)
        {
            flage1 = true;                    
        }      
        else
        {
            flage1 = false;          
            flagecontinue1 = false;            
        }
           
        /***********************/
        if(chka.checked && flagecontinue2)
        {
            flage2 = true;                    
        }      
        else
        {
            flage2 = false;          
            flagecontinue2 = false;            
        }   
        /***********************/
        if(chke.checked && flagecontinue3)
        {
            flage3 = true;                    
        }      
        else
        {
            flage3 = false;          
            flagecontinue3 = false;            
        }
        /***********************/
        if(chkd.checked && flagecontinue4)
        {
            flage4 = true;                    
        }      
        else
        {
            flage4 = false;          
            flagecontinue4 = false;            
        }   
    }
    
    
    if(flage1 && flage5 && flage6)
    {
        chkview.checked = true;   
        chkview.disabled= false;                               
    }  
    else
    {
        chkview.checked = false;  
        chkview.disabled= true;   
    }       
    /***********************/
    if(flage2 && flage5 && flage6)
    {
        chkadd.checked = true;  
        chkadd.disabled= false;       
    }  
    else
    {
        chkadd.checked = false; 
        chkadd.disabled= true;
    }       
    /*******************/
    if(flage3 && flage5 && flage6)
    {
        chkedit.checked = true;
        chkedit.disabled= false;      
    }  
    else
    {
        chkedit.checked = false;
        chkedit.disabled= true;     
    }       
    /*******************/
    if(flage4 && flage5 && flage6)
    {
        chkdelete.checked = true;
        chkdelete.disabled= false;  
    }  
    else
    {
        chkdelete.checked = false;
        chkdelete.disabled= true;   
    }  

    if(flage5)
    {
        chkview.disabled= false;   
        chkadd.disabled= false;
        chkedit.disabled= false;
        chkdelete.disabled= false;
    } 

}

function CheckAll(chkbox,type)
{
    var counth = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;               
    for(var count=0; count < counth ;count++)
    {     
       var chk = document.getElementById("ctl00_ContentPlaceHolder1_"+type+"_" + count + "");               
       if(chkbox.checked)
       {
           chk.checked = true;
       }
       else
       {
           chk.checked = false;                   
       }
       var chkview = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
       var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
       var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
       var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
       var chksection = document.getElementById("ctl00_ContentPlaceHolder1_chk_" + count + "");
       if(chkview.checked && chkadd.checked && chkedit.checked && chkdelete.checked)
       {
          chksection.checked = true;
       }
       else
       {
          chksection.checked = false;
       }
   }
}   

function CheckAllSection(chkbox,rowno)
{
    
    var counth = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;                 
    var chkview = document.getElementById("ctl00_ContentPlaceHolder1_chk_view");
    var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_chk_add");
    var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_chk_edit");
    var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_chk_delete");
    var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_view_"+rowno+"");
    var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_add_"+rowno+"");
    var chk3 = document.getElementById("ctl00_ContentPlaceHolder1_edit_"+rowno+"");
    var chk4 = document.getElementById("ctl00_ContentPlaceHolder1_delete_"+rowno+"");
    if(chkbox.checked)
    {
        chk1.checked = true;
        chk2.checked = true;
        chk3.checked = true;
        chk4.checked = true;           
    }
    else
    {
        chk1.checked = false;
        chk2.checked = false;
        chk3.checked = false;
        chk4.checked = false;
    }
    
    var flagecontinue1 = true;
    var flagecontinue2 = true;
    var flagecontinue3 = true;
    var flagecontinue4 = true;
    var flage1 = false;
    var flage2 = false;
    var flage3 = false;
    var flage4 = false;
    for(var count=0; count<counth; count++)
    { 
        var chkv = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
        var chka = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
        var chke = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
        var chkd = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
        if(chkv.checked && flagecontinue1)
        {
            flage1 = true;                    
        }      
        else
        {
            flage1 = false;          
            flagecontinue1 = false;            
        }
           
        /***********************/
        if(chka.checked && flagecontinue2)
        {
            flage2 = true;                    
        }      
        else
        {
            flage2 = false;          
            flagecontinue2 = false;            
        }   
        /***********************/
        if(chke.checked && flagecontinue3)
        {
            flage3 = true;                    
        }      
        else
        {
            flage3 = false;          
            flagecontinue3 = false;            
        }
        /***********************/
        if(chkd.checked && flagecontinue4)
        {
            flage4 = true;                    
        }      
        else
        {
            flage4 = false;          
            flagecontinue4 = false;            
        }   
    }
    
    if(!flage1)
    {
        chkview.checked = false;                    
    }  
    else
    {
        chkview.checked = true;               
    }       
    /***********************/
    if(!flage2)
    {
        chkadd.checked = false;                    
    }  
    else
    {
        chkadd.checked = true;               
    }       
    /*******************/
    if(!flage3)
    {
        chkedit.checked = false;                    
    }  
    else
    {
        chkedit.checked = true;               
    }       
    /*******************/
    if(!flage4)
    {
        chkdelete.checked = false;                    
    }  
    else
    {
        chkdelete.checked = true;               
    }         
}

function CheckChanged(chkbox)                                   
{    
 
    var counth = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;                 
    for(count=0; count < counth ;count++)
	{
        var FieldsArr = chkbox.split("_");
        var section = FieldsArr[0];
        var srow = FieldsArr[1];
	    var chkvalue = document.getElementById("ctl00_ContentPlaceHolder1_" + section + "_" + count + ""); 
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
    var chkRow = document.getElementById("ctl00_ContentPlaceHolder1_chk_" + section +"");
    var chkCol = document.getElementById("ctl00_ContentPlaceHolder1_chk_" + srow + "");         
    if(!flage)
    {
        chkRow.checked = false;  
        chkCol.checked = false;   
    }  
    else
    {
        chkRow.checked = true;  
        chkCol.checked = true;  
    }         
    for(var count=0; count<11; count++)
    {     
        var chkview = document.getElementById("ctl00_ContentPlaceHolder1_view_" + count + "");
        var chkadd = document.getElementById("ctl00_ContentPlaceHolder1_add_" + count + "");
        var chkedit = document.getElementById("ctl00_ContentPlaceHolder1_edit_" + count + "");
        var chkdelete = document.getElementById("ctl00_ContentPlaceHolder1_delete_" + count + "");
        var chksection = document.getElementById("ctl00_ContentPlaceHolder1_chk_" + count + "");
        if(chkview.checked && chkadd.checked && chkedit.checked && chkdelete.checked)
        {
            chksection.checked = true;
        }
        else
        {
            chksection.checked = false;
        }             
    }
}  

 function EnabledOnPageLoad()
      {
       var ddlselectdays=document.getElementById("ctl00_ContentPlaceHolder1_ddlselectdays");
        var chk=document.getElementById("ctl00_ContentPlaceHolder1_chkInforce");
        var hdnIsChecked=document.getElementById("hdnIsChecked");
       var isChecked=hdnIsChecked.value;
       var tdchk=document.getElementById("tdchk");
        var tdchk1=document.getElementById("tdchk1");
       if(isChecked=="none")
       {
       ddlselectdays.disabled=true;
       tdchk.className='labeltext_gray';
         tdchk1.className='labeltext_gray';
       }
       else if(isChecked=="administrator")
       {
       ddlselectdays.disabled=true;
       chk.disabled=true;
       }
      }
      function showhide(id)
      {
        var chk=document.getElementById(id);
        var ddlselectdays=document.getElementById("ctl00_ContentPlaceHolder1_ddlselectdays");
        var tdchk=document.getElementById("tdchk");
        var tdchk1=document.getElementById("tdchk1");
        
        if(chk.checked)
        {
        ddlselectdays.disabled=false;
        tdchk.className='normaltext';
        tdchk1.className='rtBody';
        }
        else
        {
        ddlselectdays.disabled=true;
        tdchk.className='rtBody';
         tdchk1.className='labeltext_gray';
        }
       
      }         
       function helpWindow_PR(tdque,tdans)
       
       {
         //alert(tdque+" "+tdans);
         document.getElementById(tdque).style.display='none';
         document.getElementById(tdans).style.display='block';
       } 
       function helpWindowclose(tdque,tdans)
         {
           
          document.getElementById(tdque).style.display='block';
          document.getElementById(tdans).style.display='none';
         }                   
              
       function helpWindow(par)
            {
                var tbl_help=document.getElementById("tbl_help");
                if(par=='c')
                {
                tbl_help.style.display='none';
                }
                else
                {
                tbl_help.style.display='block';
                }
            
            
            }    