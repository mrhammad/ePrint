   
    function checkSearchCondition()
    {
        
    }
    
    function initializeHiddenField()
    {
        //add value to the text box
        var txtvalue = "";
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');                   
        var txt = document.getElementById('ctl00_ContentPlaceHolder1_txttest');                                
        for(var i = 0;i < eval("x.length"); i ++)
        {                                                    
            txtvalue = txtvalue + "$" + x.options[i].text + "^" + x.options[i].value;   
        }
        eval("txt.value='"+txtvalue+"'");        
    }
    
    function imgTop_Click()
    {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');            
        var selected
        var selectedindex
        for(var i = 0;i < eval("x.length"); i ++)
        {             
            if(x.options[i].selected)
            {          
                selected = "yes";                
                selectedindex = i;
            }            
        }
        if(selectedindex == "0")
        {
            alert('Selected field is already at the top.');
        }
        else
        {
        if(selected == "yes")
        {
            //alert('selected ' + selectedindex);
            var tempval;
            var temptext;
            
            tempval = eval("x.options[selectedindex].value");
            temptext = eval("x.options[selectedindex].text");
                        
            x.options[selectedindex].text = eval("x.options[0].text");
            x.options[selectedindex].value = eval("x.options[0].value");             
            x.options[0].text = temptext;
            x.options[0].value = tempval;  
            eval("x.options[0].selected=true");                                   
            
            initializeHiddenField();
        }
        else
        {
            alert('Please select a field to move at the Top');
        }
        }
    }
    
    function imgUp_Click()
    {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');            
        var selected
        var selectedindex
        for(var i = 0;i < eval("x.length"); i ++)
        {             
            if(x.options[i].selected)
            {          
                selected = "yes";                
                selectedindex = i;
            }            
        }
        if(selectedindex == "0")
        {
            alert('Selected field is already at the top.');
        }
        else
        {
        if(selected == "yes")
        {
            //alert('selected ' + selectedindex);
            var tempval;
            var temptext;
            
            tempval = eval("x.options[selectedindex].value");
            temptext = eval("x.options[selectedindex].text");
                        
            x.options[selectedindex].text = eval("x.options[selectedindex-1].text");
            x.options[selectedindex].value = eval("x.options[selectedindex-1].value");             
            x.options[selectedindex-1].text = temptext;
            x.options[selectedindex-1].value = tempval;   
            
            eval("x.options[selectedindex-1].selected=true");                                 
            
            initializeHiddenField();
        }
        else
        {
            alert('Please select a field to move up');
        }
        }
    }
    function imgDown_Click()
    {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');            
        var selected
        var selectedindex
         var bottomindex = eval("x.length")-1;
        for(var i = 0;i < eval("x.length"); i ++)
        {             
            if(x.options[i].selected)
            {          
                selected = "yes";                
                selectedindex = i;
            }            
        }
        if(selectedindex == bottomindex)
        {
            alert('Selected field is already at the bottom.');
        }
        else
        {
        if(selected == "yes")
        {
            //alert('selected ' + selectedindex);
            var tempval;
            var temptext;
            
            tempval = eval("x.options[selectedindex].value");
            temptext = eval("x.options[selectedindex].text");
                        
            x.options[selectedindex].text = eval("x.options[selectedindex+1].text");
            x.options[selectedindex].value = eval("x.options[selectedindex+1].value");             
            x.options[selectedindex+1].text = temptext;
            x.options[selectedindex+1].value = tempval;   
            
            eval("x.options[selectedindex+1].selected=true");                                 
            
            initializeHiddenField();
        }
        else
        {
            alert('Please select a field to move down');
        }
        }
    }
    function imgBottom_Click()
    {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');            
        var selected
        var selectedindex
        var bottomindex = eval("x.length")-1;
        for(var i = 0;i < eval("x.length"); i ++)
        {             
            if(x.options[i].selected)
            {          
                selected = "yes";                
                selectedindex = i;
            }            
        }
        if(selectedindex == bottomindex)
        {
            alert('Selected field is already at the bottom.');
        }
        else
        {
        if(selected == "yes")
        {
            //alert('selected ' + selectedindex);
            var tempval;
            var temptext;
            
            tempval = eval("x.options[selectedindex].value");
            temptext = eval("x.options[selectedindex].text");
                        
            x.options[selectedindex].text = eval("x.options[bottomindex].text");
            x.options[selectedindex].value = eval("x.options[bottomindex].value");             
            x.options[bottomindex].text = temptext;
            x.options[bottomindex].value = tempval;  
            eval("x.options[bottomindex].selected=true");                                   
            
            initializeHiddenField();
        }
        else
        {
            alert('Please select a field to move at the bottom');
        }
        }
    }
    function click_chkselectallfixedfield()
    {

    }
    function selectThisField(val, label, chkname)
    {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_ListBox1');            
        var y = 'notexist';
        var len1;
        for(var i = 0;i < eval("x.length"); i ++)
        { 
            if(x.options[i].value == val)
            {
                y  = 'exist';    
                len1 = i;            
            }
        }
        if(y == 'notexist')
        {
            var len = eval("x.length");
            x.options[len] = new Option();
            x.options[len].text=label;
            x.options[len].value=val;                                         
        }     
        else
        {
           x.options[len1]=null;        
        }
        
        initializeHiddenField();
        var img1 = document.getElementById('ctl00_ContentPlaceHolder1_imgTop');            
        var img2 = document.getElementById('ctl00_ContentPlaceHolder1_imgUp');            
        var img3 = document.getElementById('ctl00_ContentPlaceHolder1_imgDown');            
        var img4 = document.getElementById('ctl00_ContentPlaceHolder1_imgBottom');            
                 
        if(eval("x.length") < 2)   
        {
            eval("img1.style.display='none'") 
            eval("img2.style.display='none'") 
            eval("img3.style.display='none'") 
            eval("img4.style.display='none'") 
        }
        else
        {
            eval("img1.style.display='block'") 
            eval("img2.style.display='block'") 
            eval("img3.style.display='block'") 
            eval("img4.style.display='block'")         
        }                       
    }
    
    function changecolDt(val)
    {
        var arrdatenewval = val.split("@@");
		var sdate = arrdatenewval[0];
		var edate = arrdatenewval[1];	
		var x = document.getElementById('ctl00_ContentPlaceHolder1_startdate');            
        eval("x.value=sdate") 
        var x = document.getElementById('ctl00_ContentPlaceHolder1_enddate');            
        eval("x.value=edate") 
    }
         
    function rdtabular_onclick()
    {        
//         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');            
//         eval("x.style.display='none'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');            
         eval("x.style.display='none'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_rdtabular');            
         eval("x.checked='true'") 
        
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSelectedColumns');            
         eval("x.innerHTML='Step 3:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblOrder');            
         eval("x.innerHTML='Step 4:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSearchCriteria');            
         eval("x.innerHTML='Step 5:'") 
            
    }
    function rdsummary_onclick()
    {
//         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');            
//         eval("x.style.display='none'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');            
         eval("x.style.display='block'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_rdsummary');            
         eval("x.checked='true'") 
         
         //change label
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSummary');            
         eval("x.innerHTML='Step 3:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSelectedColumns');            
         eval("x.innerHTML='Step 4:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblOrder');            
         eval("x.innerHTML='Step 5:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSearchCriteria');            
         eval("x.innerHTML='Step 6:'") 
    }
    function rdmixed_onclick()
    {
//         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlMatrix');            
//         eval("x.style.display='block'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_pnlSummary');            
         eval("x.style.display='none'") 
         
         var x = document.getElementById('ctl00_ContentPlaceHolder1_rdmixed');            
         eval("x.checked='true'") 
         
          //change label
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblMatrix');            
         eval("x.innerHTML='Step 3:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSelectedColumns');            
         eval("x.innerHTML='Step 4:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblOrder');            
         eval("x.innerHTML='Step 5:'") 
         var x = document.getElementById('ctl00_ContentPlaceHolder1_lblSearchCriteria');            
         eval("x.innerHTML='Step 6:'") 
    }

function CheckAndUnCheckReportCheckBox(tableid,uniquestring,controlid)
{
   var table=document.getElementById(tableid);
   var inputTypeCount=table.getElementsByTagName('input');
   var inputControl=document.getElementById(controlid);
   for(var i=0;i<inputTypeCount.length;i++)
    {
       if(uniquestring!='__All__')
        {
            if(inputTypeCount[i].type=='checkbox' && inputTypeCount[i].id.indexOf(uniquestring)!=-1)
            {
                if(inputControl.innerHTML=='Check All')
                  {
                    inputTypeCount[i].checked=true;
                  }
                  else
                  {
                  inputTypeCount[i].checked=false;
                  }
            }
        }    
        else
        {
            if(inputTypeCount[i].type=='checkbox')
            {
                if(inputControl.innerHTML=='Check All')
                  {
                    inputTypeCount[i].checked=true;
                   
                  }
                  else
                  {
                  inputTypeCount[i].checked=false;
                  
                  }
            }
            
        }
    }
  if(inputControl.innerHTML=='Check All')
      {
        inputControl.innerHTML='UnCheck All'
      }
      else
      {
      inputControl.innerHTML='Check All'
      }
   
}


