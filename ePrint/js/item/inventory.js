
   //******************** START Import/Export Goods *******************//
    
      function import_goods()
      {     
         var rdlimport_value=rdl_import.replace(/_/g,'$');
         var rdlimport_name=document.getElementsByName(rdlimport_value);
         
         var import_step1=document.getElementById("import_step_1");
         var import_step2=document.getElementById("import_step_2");
         
         var div_finished=document.getElementById("divfinished");
         var div_promotional=document.getElementById("divpromotional");
         var div_export=document.getElementById("divexport");
         
           for(ii=0; ii<rdlimport_name.length ;ii++)
           {
                 if(rdlimport_name[ii].checked)
                 {
                       import_step1.style.display="none";
                       import_step2.style.display="block";
                       if(rdlimport_name[ii].value == 'finished')
                       {
                         div_finished.style.display="block";
                         div_promotional.style.display="none";
                         div_export.style.display="none";
                       }
                       else if(rdlimport_name[ii].value == 'promotional')
                       {
                         div_promotional.style.display="block";
                         div_finished.style.display="none";
                         div_export.style.display="none";
                       }
                       else if(rdlimport_name[ii].value == 'export')
                       {
                         div_export.style.display="block";
                         div_finished.style.display="none";
                         div_promotional.style.display="none";
                       }
                 }       
           }
       }
       
       function import_back()
       {
         document.getElementById("import_step_1").style.display="block";
         document.getElementById("import_step_2").style.display="none";
       }
       
  //******************** END Import/Export Goods *******************//  
  
  
  //******************** START Category Goods *******************//
  
  
 
  function category_goods()
  {
   var div_category=document.getElementById("divcategory");
   div_category.style.display="block";
  }      
  
  //******************** END  Category Goods *******************//  
    
  
  //******************** START Color Goods *******************//
  
   function color_goods()
  {
   var div_color=document.getElementById("divcolor");
   div_color.style.display="block";
  }  
  //******************** END  Category Goods *******************//   
  
  
   //******************** START Color Edit Goods *******************//
   function color_edit_goods()
  {
   var div_color_edit=document.getElementById("divcoloredit");
   div_color_edit.style.display="block";
  }  
  
  //******************** END  Category Edit Goods *******************//   