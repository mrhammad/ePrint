// JScript File

function ValidateCostPer()
{
    spn_CostPer.style.display = "none";
    spn_Cost.style.display = "none";                        
    if (trim12(txtCostID.value) == "" || trim12(txtPerID.value) == "")
    {
        spn_CostPer.style.display = "block";
        spn_CostPer.innerHTML = "Please enter cost & quantity";
        //CheckFinal=true;
    }
    else if (trim12(txtCostID.value) !="" || trim12(txtPerID.value) !="")
    {
        if (checkDecimals('spn_Cost',txtCostID.id, txtCostID.value) && IsIntegerParameter(txtPerID.value,'spn_Cost'))  
        {
            spn_Cost.innerHTML = "Please enter numeric value";  
            //CheckFinal=true;
        }                             
    }
    else
    {
        //CheckFinal=false;
    }                         
}
          
var CheckFinal=false;
function Validate()
{
//                   alert('hi');   
var hdnresult=document.getElementById("hdnresult");
CheckDuplicate();
    if(hdnresult.value=="-2")
    {
        var InCrementCode='<%=AlreadyExistCode %>';
        alert(InCrementCode);
        CheckDup=false;
        txtCodeID.value=InCrementCode;
    }
else if(hdnresult.value=="-1")
    {
        CheckDup=true;
    }
else if(hdnresult.value=="-3")
    {
        CheckDup=true;
    }

CheckFinal=false;                    
//left side//
var txtProductName=trim12(txtProductNameID.value);
    if(txtProductName =='')
        {
            document.getElementById("spn_txtProductName").style.display="block";
            CheckFinal=true;
        }
var txtCode=trim12(txtCodeID.value);
    if(txtCode =='')
        {
            document.getElementById("spn_txtCode").style.display="block";
            CheckFinal=true;
        }                                   
var ddlSupplier=ddlSupplierID.value;
//    if(ddlSupplier=='0')
//        {
//            document.getElementById("spn_ddlSupplier").style.display="block";
//            CheckFinal=true;
//        }
var ddlTax=ddlTaxID.value;
//    if(ddlTax=='0')
//    {
//        document.getElementById("spn_ddlTax").style.display="block";
//        CheckFinal=true;
//    }
//right side//
var txtCost = trim12(txtCostID.value);
var txtPer  = trim12(txtPerID.value);
    if (txtCost == "" || txtPer == "")
    {
        document.getElementById("spn_CostPer").style.display = "block";
        CheckFinal=true;
    }
else
{      
    if(!CheckDecimalPlus(txtCost,'spn_cost','spn_cost','yes')
    || CheckReqCompare(txtPer,'spn_cost','spn_cost'))
    {
        CheckFinal=true;
    }
}
var txtPackedIn=trim12(txtPackedInID.value);
    if(txtPackedIn=='')
    {
        document.getElementById("spn_packedinreq").style.display="block";
        CheckFinal=true;
    }
else
{
    if(IsIntegerParameter(txtPackedIn,'spn_packedin')==false)
    {
        CheckFinal=true;
    }
}
var txtPackQuantity=trim12(txtPackQuantityID.value);
    if(txtPackQuantity=='')
    {
        document.getElementById("spn_txtPackQuantity").style.display="block";
        CheckFinal=true;
    }
else
{
    if(!CheckDecimalPlus(txtPackQuantity,'spn_txtPackQuantity','spn_txtPackQuantityNumber','yes'))
    {
        CheckFinal=true;
    } 
}
var txtPackCostPrice=trim12(txtPackCostPriceID.value);
    if(txtPackCostPrice=='')
    {
        document.getElementById("spn_txtPackCostPrice").style.display="block";
        CheckFinal=true;
    }
else
{
    if(!CheckDecimalPlus(txtPackCostPrice,'spn_txtPackCostPrice','spn_txtPackCostPriceNumber','yes'))
    {
    CheckFinal=true;
    }
}
//                    var ddlMarkup=ddlMarkupID.value;
//                    if(ddlMarkup=='0')
//                    {
//                        document.getElementById("spn_ddlMarkup").style.display="block";
//                        CheckFinal=true;
//                    }
var txtPackSalePrice=trim12(txtPackSalePriceID.value);
    if(txtPackSalePrice=='')
    {
        document.getElementById("spn_txtPackSalePrice").style.display="block";
        CheckFinal=true;
    }
else
{
    if(!CheckDecimalPlus(txtPackSalePrice,'spn_txtPackSalePrice','spn_txtPackSalePriceNumber','yes'))
    {
        CheckFinal=true;
    }
}
var txtInStock=trim12(txtInStockID.value);
    if(txtInStock=='')
    {
        document.getElementById("spn_txtInStock").style.display="block";
        CheckFinal=true;
    }
else
{
    if(CheckReqCompare(txtInStock,'spn_txtInStock','spn_txtInStockNumber'))
    {
        CheckFinal=true;
    }
}
var txtReOrderLevel=trim12(txtReOrderLevelID.value);
    if(txtReOrderLevel=='')
    {
        document.getElementById("spn_txtReOrderLevel").style.display="block";
        CheckFinal=true;
    }
else
{
    if(CheckReqCompare(txtReOrderLevel,'spn_txtReOrderLevel','spn_txtReOrderLevelNumber'))
    {
        CheckFinal=true;
    }
}
var txtReOrderQuantity=trim12(txtReOrderQuantityID.value);
    if(txtReOrderQuantity=='')
    {
        document.getElementById("spn_txtReOrderQuantity").style.display="block";
        CheckFinal=true;
    }
else
{
    if(CheckReqCompare(txtReOrderQuantity,'spn_txtReOrderQuantity','spn_txtReOrderQuantityNumber'))
    {
        CheckFinal=true;
    }
}     
var CheckCust = false;
    if ('<%=strCustomer %>' == "block")
    {
        var ddlCustomer=ddlCustomerID.value;
        if(ddlCustomer=='0')
        {
            document.getElementById("spn_ddlCustomer").style.display="block";
            CheckCust=true;
        } 
}  

    if(CheckFinal)                       
    {   
        return false;
    }
else
{ 
    if(CheckCust)
    {
        return false;
    }                        
else
{
CheckDuplicate();
    if(hdn_Duplicate.value == "true")
    {                          
        return false;                          
    }
else                          
{                          
    return true;                          
}
}
}                        
    return false; 
}

function CalculatePackPrice()
{
//    var hid_packprice = document.getElementById("<%=hid_packprice.ClientID %>");
//    var hid_MarkRate = document.getElementById("<%=hid_MarkRate.ClientID %>");

    decallowed = 4;
    var PackSalePrice = eval(txtPackCostPriceID.value );/*/ txtPackQuantityID.value);*/
    var MarkupValue = (PackSalePrice * hid_MarkRate.value)/100;
    var PriceWithMarkup = PackSalePrice + MarkupValue;

    txtPackSalePriceID.value = PriceWithMarkup;

//to enable/disable txtsaleprice on ddlMarkup//   
if (ddlMarkupID.selectedIndex == 0)
{
    txtPackSalePriceID.disabled = false;
    txtPackSalePriceID.value="0";
}
else 
{
    txtPackSalePriceID.disabled = true;
//txtPackSalePriceID.value=PriceWithMarkup;
}

hid_packprice.value = PriceWithMarkup; 

var txtPackSalePrice = txtPackSalePriceID.value;

if(txtPackSalePriceID.value=="Infinity" || txtPackSalePriceID.value=="NaN")
{
    txtPackSalePriceID.value="0";
}

if (txtPackSalePrice.indexOf('.') == -1) txtPackSalePrice += ".";
dectext = txtPackSalePrice.substring(txtPackSalePrice.indexOf('.')+1, txtPackSalePrice.length); 
if (dectext.length > decallowed)
{
    txtPackSalePriceID.value = txtPackSalePrice.substring(0, txtPackSalePrice.indexOf('.')+5);                  
}  
}
// function BindMarkupRate(ddlval)
//    {
//        //alert(ddlval);
////        var hid_MarkRate = document.getElementById("<%=hid_MarkRate.ClientID %>");
////        var lblMarkupRate = document.getElementById("<%=lblMarkupRate.ClientID %>");
//        
//        if (ddlval !=0)
//        {
//            var MarkupValues = '<%=MarkupValues %>';
//            var str_sp1 = MarkupValues.split('µ');                   
//            //alert(str_sp1);
//            var store_markupname='';
//            var store_markuprate='';
//            for(var i=0;i<str_sp1.length;i++)
//            {
//                var str_sp2=str_sp1[i].split('±');
//                if(ddlval==str_sp2[0])
//                {
//                    store_markupname=str_sp2[1];
//                    store_markuprate=str_sp2[2];
//                    hid_MarkRate.value = store_markuprate;
//                    lblMarkupRate.innerHTML = hid_MarkRate.value+"%";
//                }  
//            } 
//        }
//        else
//        {
//            hid_MarkRate.value = "0";
//            lblMarkupRate.innerHTML = hid_MarkRate.value+"%";
//        }
//    }
