// JScript File

//******************** START Job Options  *******************//
  
  
 
  function joboptions_back()
  {
   var div_joboptions=document.getElementById("divjoboptions");
   div_joboptions.style.display="block";
  } 
  
  
  function washup()
  {      
       for(p=0;p<chk_printcount.length;p++)
       {
          if(chk_printcount[4].checked == true)
          {         
            for(w=0;w<chk_washupcount.length;w++)
            {                    
              chk_washupcount[w].checked = true; 
              chk_washupcount[w].disabled = false;                  
            }   
          }  
          else
          {    
            for(w=0;w<chk_washupcount.length;w++)
            {  
              chk_washupcount[w].checked = false;                  
              chk_washupcount[w].disabled = true;                   
            } 
          }
          
       }
     } 
     
     
     function stock()
     {
           if(chk_stock.checked == true)
           {         
                for(s=0;s<chklst_stockcount.length;s++)
                {                    
                  chklst_stockcount[s].checked = true; 
                  chklst_stockcount[s].disabled = false;                  
                }   
           }  
           else
           {    
                for(s=0;s<chklst_stockcount.length;s++)
                {  
                  chklst_stockcount[s].checked = false;                  
                  chklst_stockcount[s].disabled = true;                   
                } 
           }
     
     } 
     
     
     function guillotine()
     {
           if(chk_guillotine.checked == true)
           {         
                for(s=0;s<chklst_guillotinecount.length;s++)
                {                    
                  chklst_guillotinecount[s].checked = true; 
                  chklst_guillotinecount[s].disabled = false;                  
                }   
           }  
           else
           {    
                for(s=0;s<chklst_guillotinecount.length;s++)
                {  
                  chklst_guillotinecount[s].checked = false;                  
                  chklst_guillotinecount[s].disabled = true;                   
                } 
           }
     
     }      
  
  //******************** END Job Options *******************//  

 //******************** START Job Status  *******************//
  
  
 
  function jobstatus_back()
  {
   var div_jobstatus=document.getElementById("divjobstatus");
   div_jobstatus.style.display="block";
  }      
  
  //******************** END Job Status *******************//  