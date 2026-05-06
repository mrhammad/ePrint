// JScript File
function quickTak(val) {
    //ctl00_divquickcreate.style.display=val;
    if (val == 'none') {
        //quicktask.slideup();divquicktask divquicktask
        //document.cookie = "QuickSetting="+val+"";
        slideup('divquicktask');
        showquickcreate.style.display = 'block';
        quickcreate.style.display = 'none';
        WriteCookie('NO2');
        // alert('no');
    }
    else {
        //quicktask.slidedown();
        slidedown('divquicktask');

        divquicktask1.style.display = val;
        showquickcreate.style.display = 'none';
        quickcreate.style.display = 'block';
        WriteCookie('YES2');
        // alert('yes');
    }
}


//Tooltip.offX =0;  
//Tooltip.offY = -80;
//function doTooltip(e, msg) 
//{
//    if ( typeof Tooltip == "undefined" || !Tooltip.ready ) return;
//    Tooltip.show(e, msg);
//}

//function hideTip() 
//{
//    if ( typeof Tooltip == "undefined" || !Tooltip.ready ) return;
//    Tooltip.hide();
//}
//  var tipTerms = "You can use multiple data in condition box to search various records, e.g., John,Jame, Mary will search 'John' or 'Jame' or 'Mary'. For fields that has on or off , you can use 0 for 'off' and 1 for 'on'."; 
//  var tipTerms1="Alias helps you to identify to similers records in the same section. For example id you have three contacts with the name James parker than you can give a different alias to identify different James parker.";
//  var tipPress="A low value will have higher priority on the Job Ticket";
//  var tipclose="Close";



function searchLink(val) {
    if (val == 'none') {
        slideup('ctl00_divsearch');
        ctl00_showsearch.style.display = 'block';
        ctl00_search.style.display = 'none';
        WriteCookie('NO1');
    }
    else {
        ctl00_divsearch1.style.display = val;
        slidedown('ctl00_divsearch');
        ctl00_showsearch.style.display = 'none';
        ctl00_search.style.display = 'block';
        WriteCookie('YES1');
    }
}

function WriteCookie(val) {
    UseCallback(val, "");
}

function RecentItems(val) {
    //ctl00_divrecentitem1.style.display=val;
    if (val == 'none') {
        //recentitems.slideup();divrecentitem
        slideup('divrecentitem');
        ctl00_showrecentitem.style.display = 'block';
        ctl00_recentitem.style.display = 'none';
        WriteCookie('NO3');
    }
    else {
        ctl00_divrecentitem1.style.display = val;
        //recentitems.slidedown();
        slidedown('divrecentitem');
        ctl00_showrecentitem.style.display = 'none';
        ctl00_recentitem.style.display = 'block';
        WriteCookie('YES3');
    }
}

function RemoveMsg() {
    var lblerror = document.getElementById("ctl00_lblerror");
    lblerror.innerHTML = '';
    lblerror.className = '';
}
function vaidate_Search() {
    var keywordsearch = document.getElementById("ctl00_keywordsearch");
    var lblerror = document.getElementById("ctl00_lblerror");
    var trlbl = document.getElementById("ctl00_trlbl");
    var divsearch = document.getElementById("ctl00_divsearch");
    if (keywordsearch.value == 'Freetext Search') {
        trlbl.style.display = 'block';
        divsearch.style.height = '100px';
        lblerror.innerHTML = 'Please enter freetext';
        lblerror.className = 'error';
        return false;
    }
    else if (keywordsearch.value == '') {
        trlbl.style.display = 'block';
        divsearch.style.height = '100px';
        lblerror.innerHTML = 'Please enter freetext';
        lblerror.className = 'error';
    }
    else {
        trlbl.style.display = 'none';
        lblerror.innerHTML = '';
        lblerror.className = '';
        return true;
    }
}
function updated() {
    document.getElementById("trprivacy").style.display = 'block';
}

function bar(evt) {
    var k = evt.keyCode || evt.which;
    return k != 13;
}

function ChecktimeMsg() {
    try {
        self.setTimeout('winCheckClose()', 10000)
    }
    catch (err) {
    }
}
function winCheckClose() {
    try {
        //       var lbl= document.getElementById("ctl00_ContentPlaceHolder1_lblsuccessfull");
        lbl.style.display = "none";
    }
    catch (err) {
    }
    try {
        //var lbl= document.getElementById("ctl00_ContentPlaceHolder1_sectionView_lblsuccessfull");
        lbl1.style.display = "none";
    }
    catch (err) {
    }
    try {
        //var lbl= document.getElementById("ctl00_ContentPlaceHolder1_sectionView_lblNoInUseField");
        lbl2.style.display = "none";
    }
    catch (err) {
    }
    try {
        //var lbl= document.getElementById("trprivacy");
        lbl3.style.display = "none";
    }
    catch (err) {
    }
}

function GoAdvanceSearch() {
    var lnkAdvanceSearch = document.getElementById("lnkAdvanceSearch");
    if (pgName.toLowerCase() == "estimate") {
        lnkAdvanceSearch.href = "../estimates/estimate_search.aspx";
    }
    else if (pgName.toLowerCase() == "purchase") {
        lnkAdvanceSearch.href = "../purchase/purchase_search.aspx";
    }
    else if (pgName.toLowerCase() == "job") {
        lnkAdvanceSearch.href = "../jobs/job_search.aspx";
    }
    else if (pgName.toLowerCase() == "invoice") {
        lnkAdvanceSearch.href = "../invoice/invoice_search.aspx";
    }
    else if (pgName.toLowerCase() == "deliverynote") {
        lnkAdvanceSearch.href = "../delivery/delivery_search.aspx";
    }
    else if (pgName.toLowerCase() == "warehouse") {
        if (pgtype.toLowerCase() == "inventory") {
            lnkAdvanceSearch.href = "../warehouse/warehouse_inventory_search.aspx";
        }
        else if (pgtype.toLowerCase() == "store") {
            lnkAdvanceSearch.href = "../warehouse/warehouse_search.aspx?type=store";
        }
        else if (pgtype.toLowerCase() == "item") {
            lnkAdvanceSearch.href = "../warehouse/warehouse_search.aspx?type=item";
        }
    }
    else {
        lnkAdvanceSearch.href = "../common/advance_search.aspx";
    }
}

function InsertSearchtext(val, txtbox) {
    var txtSearch = document.getElementById(txtbox);
    if (val == 'f') {
        if (txtSearch.value == 'Freetext Search' || txtSearch.value == 'Supplier' || txtSearch.value == 'Category') {
            txtSearch.value = '';
            txtSearch.className = 'TabStrip_SearchBox1';
        }
    }
    else {
        if (txtSearch.value == '') {
            if (txtbox == 'ctl00_txtsupplier') {
                txtSearch.value = 'Supplier';
                txtSearch.className = 'TabStrip_SearchBox';
            }
            else if (txtbox == 'ctl00_txtcategory') {
                txtSearch.value = 'Category';
                txtSearch.className = 'TabStrip_SearchBox';
            }
            else {
                txtSearch.value = 'Freetext Search';
                txtSearch.className = 'TabStrip_SearchBox';
            }
        }
    }
}
function showrecords(val) {
    var trshow = document.getElementById("trshowrecords");
    var trhide = document.getElementById("trhiderecords");
    var trrecords = document.getElementById("trrecords");
    if (val == 's') {
        trshow.style.display = 'none';
        trhide.style.display = 'block';
        trrecords.style.display = 'block';
    }
    else {
        trshow.style.display = 'block';
        trhide.style.display = 'none';
        trrecords.style.display = 'none';
    }
}
var DateFormat = "<%=DateFormat %>";









//function InsertSearchtext(val,txtbox)
//    {
//     var txtSearch=document.getElementById(txtbox);
//        if(val=='f')
//        {
//           if(txtSearch.value=='Freetext Search'||txtSearch.value=='Supplier'||txtSearch.value=='Category')
//           {
//            txtSearch.value='';
//            txtSearch.className='TabStrip_SearchBox1';
//           }
//        }
//        else
//        {
//            if(txtSearch.value=='')
//            {
//                 if(txtbox=='ctl00_txtsupplier')
//                 {
//                 txtSearch.value='Supplier';
//                 txtSearch.className='TabStrip_SearchBox';
//                 }
//                 else if(txtbox=='ctl00_txtcategory')
//                 {
//                  txtSearch.value='Category';
//                  txtSearch.className='TabStrip_SearchBox';
//                 }
//                 else
//                 {
//                  txtSearch.value='Freetext Search';
//                  txtSearch.className='TabStrip_SearchBox';
//                 }
//            }
//        }
//    }
//    function showrecords(val)
//    {
//      var trshow=document.getElementById("trshowrecords");
//      var trhide=document.getElementById("trhiderecords");
//      var trrecords=document.getElementById("trrecords");
//      if(val=='s')
//      {
//      trshow.style.display='none';
//      trhide.style.display='block';
//      trrecords.style.display='block';
//      }
//      else
//      {
//       trshow.style.display='block';
//       trhide.style.display='none';
//       trrecords.style.display='none';
//      }
//    }
//    var DateFormat= "<%=DateFormat %>";  

//        function ChecktimeMsg()
//         { 
//               try
//               {      
//                self.setTimeout('winCheckClose()', 10000)
//               }
//               catch(err)
//               {
//               }
//         }
//       function winCheckClose()
//         {
//          try
//          {
//           var lbl= document.getElementById("ctl00_ContentPlaceHolder1_lblsuccessfull");
//           lbl.style.display ="none";
//          }
//          catch(err)
//          {
//          }
//          try
//          {
//           var lbl= document.getElementById("ctl00_ContentPlaceHolder1_sectionView_lblsuccessfull");
//           lbl.style.display ="none";
//          }
//          catch(err)
//          {
//          }
//           try
//          {
//           var lbl= document.getElementById("ctl00_ContentPlaceHolder1_sectionView_lblNoInUseField");
//           lbl.style.display ="none";
//          }
//          catch(err)
//          {
//          }
//            try
//          {
//           var lbl= document.getElementById("trprivacy");
//           lbl.style.display ="none";
//          }
//          catch(err)
//          {
//          }
//       }
//     ChecktimeMsg();









//   Tooltip.offX =0;  
//   Tooltip.offY = -80;
//  function doTooltip(e, msg) 
//  {
//      if ( typeof Tooltip == "undefined" || !Tooltip.ready ) return;
//      Tooltip.show(e, msg);
//  }

//function hideTip() 
// {
//      if ( typeof Tooltip == "undefined" || !Tooltip.ready ) return;
//      Tooltip.hide();
// }
//  var tipTerms = "You can use multiple data in condition box to search various records, e.g., John,Jame, Mary will search 'John' or 'Jame' or 'Mary'. For fields that has on or off , you can use 0 for 'off' and 1 for 'on'."; 
//  var tipTerms1="Alias helps you to identify to similers records in the same section. For example id you have three contacts with the name James parker than you can give a different alias to identify different James parker.";
//  var tipPress="A low value will have higher priority on the Job Ticket";
//  var tipclose="Close";







//    function WriteCookie(val){     
//        
//        UseCallback(val, "");
//    }



//    function searchLink(val)
//    {       
//       if(val=='none')
//        {
//            slideup('ctl00_divsearch');
//            ctl00_showsearch.style.display='block';
//            ctl00_search.style.display='none';
//            WriteCookie('NO1'); 
//        }
//        else
//        {
//            ctl00_divsearch1.style.display=val;
//            slidedown('ctl00_divsearch');
//            ctl00_showsearch.style.display='none';
//            ctl00_search.style.display='block';
//            WriteCookie('YES1');
//        }
//    }

//   function quickTak(val)
//    {       
//        //ctl00_divquickcreate.style.display=val;
//       
//        if(val=='none')
//        {   
//            
//            //quicktask.slideup();divquicktask divquicktask
//           //document.cookie = "QuickSetting="+val+"";
//            slideup('divquicktask');
//            ctl00_showquickcreate.style.display='block';
//            ctl00_quickcreate.style.display='none';
//             WriteCookie('NO2');
//           // alert('no');
//            
//        }
//        else
//        {
//           
//            //quicktask.slidedown();
//             slidedown('divquicktask');
//             
//             ctl00_divquicktask1.style.display=val;
//            ctl00_showquickcreate.style.display='none';
//            ctl00_quickcreate.style.display='block';
//             WriteCookie('YES2');
//           // alert('yes');
//        }
//        
//    }
//    
//    function RecentItems(val)
//    {       
//       //ctl00_divrecentitem1.style.display=val;
//        if(val=='none')
//        {
//            //recentitems.slideup();divrecentitem
//            slideup('divrecentitem');
//            ctl00_showrecentitem.style.display='block';
//            ctl00_recentitem.style.display='none';
//            WriteCookie('NO3');
//        }
//        else
//        {
//            ctl00_divrecentitem1.style.display=val;
//            //recentitems.slidedown();
//            slidedown('divrecentitem');
//            ctl00_showrecentitem.style.display='none';
//            ctl00_recentitem.style.display='block';
//            WriteCookie('YES3');
//        }
//    }
//    function Items(val)
//    {       
//        //ctl00_divrecentitem1.style.display=val;
//        if(val=='none')
//        {
//           //recentitems.slideup();divrecentitem
//           //alert(document.getElementsByName("divAddItem"));
//            slideup('ctl00_printcenter_leftpanel_divAddItem');
//            ctl00_printcenter_leftpanel_divitemshow.style.display='block';
//            ctl00_printcenter_leftpanel_divitemclose.style.display='none';
//           
//        }
//        else
//        {
//            //ctl00_divrecentitem1.style.display=val;
//            //recentitems.slidedown();
//            slidedown('ctl00_printcenter_leftpanel_divAddItem');
//            ctl00_printcenter_leftpanel_divitemshow.style.display='none';
//            ctl00_printcenter_leftpanel_divitemclose.style.display='block';
//        }
//    }
//    function Stock(val)
//    {       
//        
//        //ctl00_divrecentitem1.style.display=val;
//        if(val=='none')
//        {
//            //recentitems.slideup();divrecentitem
//            slideup('divAddStock');
//            ctl00_printcenter_leftpanel_divstockshow.style.display='block';
//            ctl00_printcenter_leftpanel_divstockclose.style.display='none';
//           
//        }
//        else
//        {
//            //ctl00_divrecentitem1.style.display=val;
//            //recentitems.slidedown();
//            slidedown('divAddStock');
//            ctl00_printcenter_leftpanel_divstockshow.style.display='none';
//            ctl00_printcenter_leftpanel_divstockclose.style.display='block';
//           
//        }
//        
//    }
//    function Inventory(val)
//    {       
//        //alert(val)
//        //ctl00_divrecentitem1.style.display=val;
//        if(val=='none')
//        {
//            //recentitems.slideup();divrecentitem
//            slideup('divAddInventory');
//            //ctl00_tint_divinventoryshow.style.display='block';
//            //ctl00_tint_divinventoryclose.style.display='none';
//            document.getElementById("ctl00_tint_divinventoryshow").style.display='block';
//            document.getElementById("ctl00_tint_divinventoryclose").style.display='none';
//        }
//        else
//        {
//            //ctl00_divrecentitem1.style.display=val;
//            //recentitems.slidedown();
//            slidedown('divAddInventory');
//            //ctl00_tint_divprintclose.style.display='block';
//            //ctl00_tint_divprintshow.style.display='none';
//            document.getElementById("ctl00_tint_divinventoryshow").style.display='none';
//            document.getElementById("ctl00_tint_divinventoryclose").style.display='block';
//           
//        }
//        
//    }
//    function Print(val)
//    {       
//       
//        //ctl00_divrecentitem1.style.display=val;
//        if(val=='none')
//        {
//            //recentitems.slideup();divrecentitem  ctl00_tint_div_estimate_edit
//            //slideup('ctl00_printcenter_leftpanel_divPrint');
//            //slideup('ctl00_tint_div_estimate_edit');
//            document.getElementById("div_estimate_edit1").style.display='none';
//            document.getElementById("ctl00_tint_divprintclose").style.display='none';
//            document.getElementById("ctl00_tint_divprintshow").style.display='block';
//           
//        }
//        else
//        {
//            //ctl00_divrecentitem1.style.display=val;
//            //recentitems.slidedown();
//            //slidedown('ctl00_tint_div_estimate_edit');
//            document.getElementById("div_estimate_edit1").style.display='block';
//            document.getElementById("ctl00_tint_divprintclose").style.display='block';
//            document.getElementById("ctl00_tint_divprintshow").style.display='none';
//           
//        }
//        
//    }
//    
//    function RemoveMsg()
//    {
//    var lblerror=document.getElementById("ctl00_lblerror");
//    lblerror.innerHTML='';
//     lblerror.className='';
//    }
//    function vaidate_Search()
//    {
//        
//        var keywordsearch=document.getElementById("ctl00_keywordsearch");
//        var lblerror=document.getElementById("ctl00_lblerror");
//        var trlbl=document.getElementById("ctl00_trlbl");
//        var divsearch=document.getElementById("ctl00_divsearch");
//        if(keywordsearch.value=='Freetext Search')
//        {
//        
//        trlbl.style.display='block';
//        divsearch.style.height='100px';
//        lblerror.innerHTML='Please enter freetext';
//        lblerror.className='error';
//       
//        return false;
//        }
//        else if(keywordsearch.value=='')
//        {
//        trlbl.style.display='block';
//        divsearch.style.height='100px';
//        lblerror.innerHTML='Please enter freetext';
//        lblerror.className='error';
//        }
//        else
//        {
//        trlbl.style.display='none';
//        lblerror.innerHTML='';
//        lblerror.className='';
//        return true;
//        }
//    }
//    function updated()
//    {
//     
//     document.getElementById("trprivacy").style.display='block';
//     
//     
//    }
//    function bar(evt){
//var k=evt.keyCode||evt.which;
//return k!=13;
//}
//  