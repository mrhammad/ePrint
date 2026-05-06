// JScript File

function CallScroll() {

    var GridID = "";
    var div_HeaderID = "";
    var div_BodyID = "";
    var OuterDivID = "";
    var InnerDivID = "";
    var DivTotalRecID = "";
    if (module == "warehouse") {
        if (Ware_itemtype == "inventory") {
            GridID = GridViewInv;
            div_HeaderID = document.getElementById("a");
            div_BodyID = document.getElementById("div_Grid");
            OuterDivID = document.getElementById("div_testinv_1");
            InnerDivID = document.getElementById("div_testinv_2");
            DivTotalRecID = document.getElementById("div_TotalRecInv");
        }
        else if (Ware_itemtype == "store") {
            GridID = GridStoreSupply;
            div_HeaderID = document.getElementById("a1");
            div_BodyID = document.getElementById("div_Grid1");
            OuterDivID = document.getElementById("div_testinv_1");
            InnerDivID = document.getElementById("div_testinv_2");
            DivTotalRecID = document.getElementById("div_TotalRecSto");
        }
        else if (Ware_itemtype == "item") {
            GridID = GridCustomerItem;
            div_HeaderID = document.getElementById("a2");
            div_BodyID = document.getElementById("div_Grid2");
            OuterDivID = document.getElementById("div_testinv_1");
            InnerDivID = document.getElementById("div_testinv_2");
            DivTotalRecID = document.getElementById("div_TotalRecCus");
        }
        start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
    }
    else {
        div_HeaderID = document.getElementById("a");
        div_BodyID = document.getElementById("div_Grid");
        OuterDivID = document.getElementById("div_testinv_1");
        InnerDivID = document.getElementById("div_testinv_2");
        DivTotalRecID = document.getElementById("div_TotalRecInv");
        start(GridCustomerItem, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);

        div_HeaderID1 = document.getElementById("a1");
        div_BodyID1 = document.getElementById("div_Grid1");
        OuterDivID1 = document.getElementById("div_testinv_1");
        InnerDivID1 = document.getElementById("div_testinv_2");
        DivTotalRecID1 = document.getElementById("div_TotalRecSto");
        start(GridStoreSupply, div_HeaderID1, div_BodyID1, OuterDivID1, InnerDivID1, DivTotalRecID1);

        div_HeaderID2 = document.getElementById("a2");
        div_BodyID2 = document.getElementById("div_Grid2");
        OuterDivID2 = document.getElementById("div_testinv_1");
        InnerDivID2 = document.getElementById("div_testinv_2");
        DivTotalRecID2 = document.getElementById("div_TotalRecCus");
        start(GridCustomerItem, div_HeaderID2, div_BodyID2, OuterDivID2, InnerDivID2, DivTotalRecID2);
    }
}
//    function CheckScrollGrid()
//    {
//         //start();
//        clsTimeID=setInterval("CheckFor1min()",1000);
//    }
//    function CheckFor1min()
//    {
//        
//        if(hidGridCount.value!='')
//        {
//            clearInterval(clsTimeID);
//            start();
//        }        
//        TakeTimaeCount++;
//        
//        if(TakeTimaeCount > 20)
//        {
//            clearInterval(clsTimeID);
//        }
//    }
//** Func to make grid scroll when In the Update Panel **//  

//*** Function to make gridview scrollable ***//
//    function start()
//    {
//        var Ware_itemtype='<%=type %>';
//        var t='';
//        var t2='';
//        //Inventory
//        //alert(navigator.userAgent);
//        if (Ware_itemtype == "inventory")
//        {
//        ti = GridInventory;
//        t2 = ti.cloneNode(true)
//        for(i = ti.rows.length -1;i > 0;i--)
//            t2.deleteRow(i);       
//        ti.deleteRow(0);
//       
//        document.getElementById("a").appendChild(t2);
//        /*
//        if(ti.rows.length == 0 || ti.rows.length < 10)
//        {
//            document.getElementById("div_Grid").style.overflowY="auto";
//        }
//        else 
//        {
//            document.getElementById("div_Grid").style.overflowY="scroll";
//            var divObj1 = document.getElementById("a");
//            SetWidth(divObj1);
//        }*/
//        
//        OuterDivID.style.display="none";
//        if (ti.rows.length < 19)
//        {
//            document.getElementById("div_Grid").style.overflowY="auto";
//            document.getElementById("div_TotalRecInv").style.paddingRight = "5px";
//        }
//        else
//        {
//            document.getElementById("div_TotalRecInv").style.paddingRight = "28px";
//            var divObj = document.getElementById("a");
//            var aWidth = divObj.offsetWidth;  
//            //SetWidth(divObj);
//            div = ti.parentNode;
//            if (div.tagName == "DIV")
//            {
//                div.className = "WrapperDiv";  
//                div.style.overflowY = "scroll"; 

//                OuterDivID.style.display = "block";
//                var OuterDivWidth = OuterDivID.offsetWidth;
//                var InnerDivWidth = InnerDivID.offsetWidth;
//                //alert("Number(OneDiv)"+document.getElementById("div_test_1").offsetHeight);
//                var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
//                
//                if (aWidth != '')
//                {
//                    document.getElementById("a").style.width = Number(aWidth) - Number(MinusThisWidth - 1) +"px";
//                    document.getElementById("div_Grid").style.width = Number(aWidth - 1) + "px";
//                }
//                OuterDivID.style.display = "none";            
//            }   
//         }
//        document.getElementById("div_Grid").style.display="block";
//        }
//        else if (Ware_itemtype == "store")
//        {
//        //Store Supply
//        ts = GridStoreSupply;
//        t2 = ts.cloneNode(true)
//        for(i = t2.rows.length-1;i > 0;i--)
//            t2.deleteRow(i)
//            ts.deleteRow(0)
//            document.getElementById("a1").appendChild(t2)
//        /*
//        if(ts.rows.length == 0 || ts.rows.length < 10)
//        {
//            document.getElementById("div_Grid1").style.overflowY="auto";
//        }
//        else 
//        {
//            document.getElementById("div_Grid1").style.overflowY="scroll";
//            var divObj2 = document.getElementById("a1");
//            SetWidth(divObj2);
//        }*/
//        OuterDivID.style.display="none";
//        if (ts.rows.length < 19)
//        {
//            document.getElementById("div_Grid1").style.overflowY="auto";
//            document.getElementById("div_TotalRecSto").style.paddingRight = "5px";
//        }
//        else
//        {
//            document.getElementById("div_TotalRecSto").style.paddingRight = "28px";
//            var divObj = document.getElementById("a1");
//            var aWidth = divObj.offsetWidth;  
//            //SetWidth(divObj);
//            div = ts.parentNode;
//            if (div.tagName == "DIV")
//            {
//                div.className = "WrapperDiv";  
//                div.style.overflowY = "scroll"; 

//                OuterDivID.style.display = "block";
//                var OuterDivWidth = OuterDivID.offsetWidth;
//                var InnerDivWidth = InnerDivID.offsetWidth;
//                //alert("Number(OneDiv)"+document.getElementById("div_test_1").offsetHeight);
//                var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
//                
//                if (aWidth != '')
//                {
//                    document.getElementById("a1").style.width = Number(aWidth) - Number(MinusThisWidth - 1) +"px";
//                    document.getElementById("div_Grid1").style.width = Number(aWidth - 1) + "px";
//                }
//                OuterDivID.style.display = "none";            
//            }   
//         }
//        document.getElementById("div_Grid1").style.display="block";
//        }
//        else
//        {
//        //Customer Item
//        tc = GridCustomerItem;
//        t2 = tc.cloneNode(true)
//        for(i = t2.rows.length -1;i > 0;i--)
//        t2.deleteRow(i)
//        tc.deleteRow(0)
//        document.getElementById("a2").appendChild(t2);
//        /*
//        if(tc.rows.length == 0 || tc.rows.length < 10)
//        {
//            document.getElementById("div_Grid2").style.overflowY="auto";
//        }
//        else 
//        {
//            document.getElementById("div_Grid2").style.overflowY="scroll";
//            var divObj3 = document.getElementById("a2");
//            SetWidth(divObj3);
//        }*/
//        OuterDivID.style.display="none";
//        if (tc.rows.length < 19)
//        {
//            document.getElementById("div_Grid2").style.overflowY="auto";
//            document.getElementById("div_TotalRecCus").style.paddingRight = "5px";
//        }
//        else
//        {
//            document.getElementById("div_TotalRecCus").style.paddingRight = "28px";
//            var divObj = document.getElementById("a2");
//            var aWidth = divObj.offsetWidth;  
//            //SetWidth(divObj);
//            div = tc.parentNode;
//            if (div.tagName == "DIV")
//            {
//                div.className = "WrapperDiv";  
//                div.style.overflowY = "scroll"; 

//                OuterDivID.style.display = "block";
//                var OuterDivWidth = OuterDivID.offsetWidth;
//                var InnerDivWidth = InnerDivID.offsetWidth;
//                //alert("Number(OneDiv)"+document.getElementById("div_test_1").offsetHeight);
//                var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
//                
//                if (aWidth != '')
//                {
//                    document.getElementById("a2").style.width = Number(aWidth) - Number(MinusThisWidth - 1) +"px";
//                    document.getElementById("div_Grid2").style.width = Number(aWidth - 1) + "px";
//                }
//                OuterDivID.style.display = "none";            
//            }   
//         }
//        
//        document.getElementById("div_Grid2").style.display="block";
//        }
//    }
//    
//   window.onload=start


function changebgColor(chkobj) {
    changeGridColor(chkobj, GridViewInv);
}
function changebgColor2(chkobj) {
    changeGridColor(chkobj, GridCustomerItem);
}
function changebgColor1(chkobj) {
    changeGridColor(chkobj, GridStoreSupply);
}
function DeleteInv() {
    if (Ware_itemtype == "inventory") {
        //CheckGrid();
        //   hdnInvDelIds.value = ctl00_tint_hdnIDs.value;
        hdnInvDelIds.value = ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkInvDelete', '');

    }
    else if (Ware_itemtype == "store") {
        //CheckGrid();
        hdnInvStoreDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkStoDelete', '');
    }
    else if (Ware_itemtype == "item") {
        //CheckGrid();
        hdnInvCustDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkCusDelete', '');
    }
}

function ArchiveInv() {
    if (Ware_itemtype == "inventory") {
        //CheckGrid();
        //  hdnInvDelIds.value = ctl00_tint_hdnIDs.value;
        hdnInvDelIds.value = ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkInvArchive', '');

    }
    else if (Ware_itemtype == "store") {
        //CheckGrid();
        hdnInvStoreDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkStoArchive', '');
    }
    else if (Ware_itemtype == "item") {
        //CheckGrid();
        hdnInvCustDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkCusArchive', '');
    }
}

function UnArchiveInv() {
    if (Ware_itemtype == "inventory") {
        //CheckGrid();
        //  hdnInvDelIds.value = ctl00_tint_hdnIDs.value;
        hdnInvDelIds.value = ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkInvUnArchive', '');
    }
    else if (Ware_itemtype == "store") {
        //CheckGrid();
        hdnInvStoreDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkStoUnArchive', '');
    }
    else if (Ware_itemtype == "item") {
        //CheckGrid();
        hdnInvCustDelIds.value = ctl00_tint_hdnIDs.value;
        __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkCusUnArchive', '');
    }
 }

function changeCssWare(iss) {

    document.getElementById(iss).style.color = "orange";
    for (var i = 1; i <= 3; i++) {
        var dd = "ware_" + i;
        if (dd != iss) {
            if (document.getElementById("ware_" + i) != null) {

                document.getElementById("ware_" + i).style.color = "black";
                var ff = "div_" + i;
                ff = ff + i;
                //document.getElementById(ff).style.height="18px";  
            }
        }
        else {
            var ff = "div_" + i;
            ff = ff + i;
            //document.getElementById(ff).style.height="20px";
        }
    }
    if (document.getElementById(iss).id == "ware_1") {
        // document.getElementById("<%=hdnTabType.ClientID %>").value = 'inventory';                
        document.getElementById("divinventory").style.display = "block";
        document.getElementById("divcustomer").style.display = "none";
        document.getElementById("divstore").style.display = "none";
        //document.getElementById("divWarehouseHeader").style.display="block";                
        //document.getElementById("divAddInventory").style.display="block";
        if (InventoryFlag == false && GridInventory != null) {
            var divObj = document.getElementById("a");
            if (divObj != null && GridInventory.rows.length > 10) {
                SetWidth(divObj);
                InventoryFlag = true;
            }
        }
    }
    else if (document.getElementById(iss).id == "ware_2") {
        //document.getElementById("<%=hdnTabType.ClientID %>").value = 'storesupply'; 
        document.getElementById("divinventory").style.display = "none";
        document.getElementById("divcustomer").style.display = "none";
        document.getElementById("divstore").style.display = "block";
        //document.getElementById("divWarehouseHeader").style.display="none";                
        //document.getElementById("divAddInventory").style.display="none";
        if (StoreFlag == false && GridStoreSupply != null) {
            var divObj = document.getElementById("a1");
            if (divObj != null && GridStoreSupply.rows.length > 10) {
                SetWidth(divObj);
                StoreFlag = true;
            }
        }
    }
    else if (document.getElementById(iss).id == "ware_3") {
        // document.getElementById("<%=hdnTabType.ClientID %>").value = 'customeritem'; 
        document.getElementById("divinventory").style.display = "none";
        document.getElementById("divcustomer").style.display = "block";
        document.getElementById("divstore").style.display = "none";

        var hid_custID = document.getElementById("<%=hid_custID.ClientID %>");
        //BindCustItem(hid_custID.value);

        if (CustomerFlag == false && GridCustomerItem != null) {
            var divObj = document.getElementById("a2");
            if (divObj != null && GridCustomerItem.rows.length > 10) {
                SetWidth(divObj);
                CustomerFlag = true;
            }
        }
    }
    return false;
}
function checkInk() {
    if (InvenotoryInk == "ink") {
        document.getElementById("li_StoreSupply").style.display = "none";
        document.getElementById("li_CustomerItem").style.display = "none";
    }
    else if (InvenotoryInk == "estimate") {
        document.getElementById("li_Inventory").style.display = "block";
        document.getElementById("li_StoreSupply").style.display = "block";
        document.getElementById("li_CustomerItem").style.display = "block";
        document.getElementById("div_warehouse_border").className = "divBorderItem";

    }
    else if (InvenotoryInk == 'warehouse') {
        document.getElementById("li_Inventory").style.display = "none";
        document.getElementById("li_StoreSupply").style.display = "none";
        document.getElementById("li_CustomerItem").style.display = "none";
    }
}

var checktrue = false;
function checkall(tblid) {
    var tbl = document.getElementById(tblid);
    var tagcount = tbl.getElementsByTagName("input");
    for (var i = 0; i < tagcount.length; i++) {
        if (tagcount[i].type == 'checkbox') {
            if (tagcount[0].checked) {
                tagcount[i].checked = true;
                checktrue = true;
                document.getElementById("lnkpo").className = "normalText";
            }
            else {
                tagcount[i].checked = false;
                checktrue = false;
                document.getElementById("lnkpo").className = "disable";
                //document.getElementById("tblpo").style.display="none"; 
                document.getElementById("divmessage").style.display = "none";
            }
        }
    }
}

function showmessage() {
    if (checktrue == true) {
        document.getElementById("divmessage").style.display = "block";
        self.setTimeout("hidemessage()", 10000);
    }
    else {
        alert('Please check at least one record');
    }
}
function hidemessage() {
    document.getElementById("divmessage").style.display = "none";
}

function showpo(tblid, index) {
    var tbl = document.getElementById(tblid);
    var count = 0;
    var tagcount = tbl.getElementsByTagName("input");
    if (tagcount[index].checked) {
        //document.getElementById("tblpo").style.display="block";
        checktrue = true;
        document.getElementById("lnkpo").className = "normalText";
    }
    else {
        for (var i = 0; i < tagcount.length; i++) {
            if (tagcount[i].type == 'checkbox') {
                if (tagcount[i].checked) {
                    count = eval(count + 1)
                    checktrue = true;
                    document.getElementById("lnkpo").className = "normalText";
                }
            }
        }
        // alert(count);
        if (count == 0) {
            //document.getElementById("tblpo").style.display="none";
            checktrue = false;
            document.getElementById("lnkpo").className = "disable";
        }
        else {
            if (count == 1) {
                if (tagcount[0].checked) {
                    tagcount[0].checked = false;
                    checktrue = false;
                    document.getElementById("lnkpo").className = "disable";
                    //document.getElementById("tblpo").style.display="none";
                }
            }
            else {
                //document.getElementById("tblpo").style.display="block";
                checktrue = true;
                document.getElementById("lnkpo").className = "normalText";
            }
        }
    }
}

function Call_Estimate_Func(WID, WName, WType, UPrice, packedin, packedInQty) 
{
    debugger;
    WareID = WID;
    WareName = WName;
    WareType = WType;
    UnitPrice = UPrice;
    PackedInQty = packedin;
    if (IamFrom == "AddEstimate") {
        //THIS FUNCTION IS USED IN ESTIMATE PAGE       
        ShowAddPanel_Estimate(WareID, WareName, WareType, UnitPrice, packedin, PackedInQty);       
        return false;
    }
    else if (IamFrom == "EstimateSummary") {
        ShowAddPanel_Estimate(WareID, WareName, WareType, UnitPrice, packedin, PackedInQty);
        return false;
    }
    else {
        //             if("<%=url %>"=="store")
        //             {
        //                //Store Supply
        //                window.location.href="<%=strSitepath %>"+"warehouse/item_finishedgoods_add.aspx?page=store&type=edit&id="+WareID+"";
        //             }
        //             else if("<%=url %>"=="item")
        //             {
        //                //Customer Item
        //                window.location.href="<%=strSitepath %>"+"warehouse/item_finishedgoods_add.aspx?page=item&type=edit&id="+WareID+"";
        //             }
        //             else
        //             {
        //                //Inventory
        //                window.location.href="<%=strSitepath %>"+"warehouse/inventory_add.aspx?type=edit&id="+WareID+"";
        //             }
        //document.getElementById("div_loading_inv").style.display = "none";
        return true;
    }
}

//       var ClrTimeID='';
//       var countTime=0;
//       function CheckGrid()
//       {
//          ClrTimeID = setInterval("CallAfter1min()",1000);
//       }
//       function CallAfter1min()
//       {
//            var type = '<%=type %>';    
//            if (type == "inventory")
//            {
//                var hidGridRecord = document.getElementById("<%=hidGridRecord.ClientID %>");
//                if(hidGridRecord.value!='')
//                {
//                    clearInterval(ClrTimeID);
//                    start();
//                }   
//            }
//            else if (type == "store")
//            {
//                var hidStoreCount = document.getElementById("<%=hidStoreCount.ClientID %>");
//                if(hidStoreCount.value!='')
//                {
//                    clearInterval(ClrTimeID);
//                    start();
//                }  
//            }
//            else if (type == "item")
//            {
//                var hidCustomCount = document.getElementById("<%=hidCustomCount.ClientID %>");
//                if(hidCustomCount.value!='')
//                {
//                    clearInterval(ClrTimeID);
//                    start();
//                } 
//            }
//            countTime++;
//            if(countTime > 15)
//            {
//                clearInterval(ClrTimeID);
//            }
//       }

    function CheckchkOne(type) {
        var PageType = '';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        var Ides = "";

        //hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                }
            }
        }
        hdnIDs.value = Ides;

        if (Number(Counter) == 0) {
            if (type == "delete") {
                // alert("Please check at least one 'row' to Delete");
                alert(Delete_Row_Selection_Alert);
            }
            else if (type == "archive") {
                //alert("Please check at least one 'row' to Archive");
                alert(Archive_Row_Selection_Alert);
            }
            else if (type == "unarchive") {
                //alert("Please check at least one 'row' to Un-Archive");
                alert(UnArchive_Row_Selection_Alert);
            }
            return false;
        }
        else {

            if (type == "delete") {                
                PageMethods.FetchDependancy(Companyid, hdnIDs.value, FunSucess, take_error);
                //check = window.confirm('Are you sure you want to delete this record(s)?');

            }
            else if (type == "archive") {
                //check = window.confirm('Are you sure you want to archive this record(s)?');
                check = window.confirm(Archive_Confirmation_Alert);
            }
            else if (type == "unarchive") {
                //check = window.confirm('Are you sure you want to un-archive this record(s)?');
                check = window.confirm(UnArchive_Confirmation_Alert);
            }
            if (check) {
                if (type == "delete") {
                    DeleteInv();
                }
                else if (type == "archive") {

                    ArchiveInv();

                }
                else if (type == "unarchive") {
                    UnArchiveInv();
                }
                return false;
            }
            else {
                return check;
            }
            //  return true;
        }
    }

    function FunSucess(result) {
        if (result == "Ink" || result == "Plate") {
            alert(Inventory_Mandatory_Delete_Note);
            check = false;
        }
        else if (result == "Paper") {
            check = window.confirm(Inventory_Plant_Presses_Delete_Confirmation);
        }
        else {
            check = window.confirm(Delete_Confirmation_Alert);
        }
        if (check) {
            hdnInvDelIds.value = ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_hdnIDs.value;
            __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkInvDelete', '');
        }
    }

    function take_error(error) { 
    }