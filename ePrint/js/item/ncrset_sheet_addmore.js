    var divIdName;
    var topsheet="top";
    var middlesheet="middle";
    var bottomsheet="bottom";
    var txtdata="ctl00_ContentPlaceHolder1_UCItemAdd_txtparts";
    var lbldata="ctl00_ContentPlaceHolder1_UCItemAdd_lblparts";
   
    function addElement() 
    { 
      //alert((document.getElementById(txtdata).value));
      var parentdiv = document.getElementById(middlesheet);
      parentdiv.style.width='100%';
      parentdiv.className='rowdiv';
     
      if((document.getElementById(txtdata).value)==1)
      {
        document.getElementById(topsheet).style.display="none";
        document.getElementById(middlesheet).style.display="none";
        document.getElementById(bottomsheet).style.display="block";
      }
      else if((document.getElementById(txtdata).value)==2)
      {
        document.getElementById(topsheet).style.display="block";
        document.getElementById(middlesheet).style.display="none";
        document.getElementById(bottomsheet).style.display="block";
      } 
      else if((document.getElementById(txtdata).value)<=7)
      {
          document.getElementById(topsheet).style.display="block";
          document.getElementById(middlesheet).style.display="block"; 
          document.getElementById(bottomsheet).style.display="block";         
           
          var num= (document.getElementById(txtdata).value) - 2; 
          
          for(i=1; i <= num ;i++)
          {             
              //First Child of parentdiv with TextBox
              var childiv_txtbox=document.createElement('div');
              childiv_txtbox.id='divmidtxtbox_'+i;
              childiv_txtbox.className='celldiv';
              childiv_txtbox.align='center';
              childiv_txtbox.style.width='20%';
              childiv_txtbox.innerHTML="<input type='text' id='middle sheet"+i+"' value='Middle Sheet "+i+"' class='txtbox'/>";// onclick='javascript:alert(this.value);'
              parentdiv.appendChild(childiv_txtbox);
              
              //Second Child of parentdiv with RadioButtons
              var childiv_radio=document.createElement('div');
              childiv_radio.id='divmidradio_'+i;
              childiv_radio.className='celldiv';
              childiv_radio.align='center';
              childiv_radio.style.width='30%';
              childiv_radio.innerHTML="<input type='radio' id='uncommon_mid_"+i+"' value='uncommon_mid_"+i+"' name='cm"+i+"'/>Uncommon Image <input type='radio' id='common_mid_"+i+"' value='common_mid_"+i+"' name='cm"+i+"'/>Common Image";//onclick='javascript:alert(this.value);'
              parentdiv.appendChild(childiv_radio);
              
              //Third Child of parentdiv with text
              var childiv_txt=document.createElement('div');
              childiv_txt.id='divmidtxt_'+i;
              childiv_txt.className='celldiv';
              childiv_txt.align='center';
              childiv_txt.style.width='30%';
              childiv_txt.innerHTML="NCR Middle Sheet Pink SRA3 CFB";
              parentdiv.appendChild(childiv_txt);
              
              //Fourth Child of parentdiv with Button
              var childiv_btn=document.createElement('div');
              childiv_btn.id='divmidbtn_'+i;
              childiv_btn.className='celldiv';
              childiv_btn.align='center';
              childiv_btn.innerHTML="<input type='button' id='btn'"+i+"' class='button' value='Select' style='width:65px;' />";// onclick='javascript:alert(this.id);'
              parentdiv.appendChild(childiv_btn);
              
              //Secon Child of parentdiv under div id='middle'
              var divclr=document.createElement('div');
              divclr.id='divmidclr_'+i;
              divclr.style.borderBottom='1px';
              divclr.style.borderBottomColor='silver';
              divclr.style.borderBottomStyle='solid';
              divclr.style.clear='both';
              parentdiv.appendChild(divclr);
          }
       }
    }

    function removeElement() 
    {
      var num= (document.getElementById(txtdata).value) - 2;
      
      for(j=1; j <= num ; j++)
      {
        var elem = document.getElementById(middlesheet);
        elem.removeChild(document.getElementById('divmidtxtbox_'+j));
        elem.removeChild(document.getElementById('divmidradio_'+j));
        elem.removeChild(document.getElementById('divmidtxt_'+j));
        elem.removeChild(document.getElementById('divmidbtn_'+j));
        elem.removeChild(document.getElementById('divmidclr_'+j));
      }
    }
