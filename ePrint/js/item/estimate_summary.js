// JScript File
function roundNumber(rnum, rlength) 
{

    return rnum;
  /*
  var newnumber = Math.round(rnum*Math.pow(10,rlength))/Math.pow(10,rlength);
  newnumber = parseFloat(newnumber).toFixed(2);
  return newnumber; */
}

function GrossProfit_Value(CostPriceExMark, SubToal)
{
    var GrossValue = Number(SubToal) - Number(CostPriceExMark);
    GrossValue = roundNumber(GrossValue,2);
    
    return GrossValue;
}
function GrossProfit_Percentage(SubToal, GrossValue)
{
    var GrossPercentage = (Number(GrossValue) / Number(SubToal)) * 100;
    GrossPercentage = roundNumber(GrossPercentage,2);
    
    return GrossPercentage;
}

function ProfitMarginShow_SinglePadLarge(priftValue,EstimateItemID,QtyCount)
{
    for(var j=0;j<QtyCount;j++)
    {
        var MarkUp = document.getElementById("span_Markup_"+EstimateItemID+"_"+j+"");
        var SellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateItemID+"_"+j+"");
        var ProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+j+"");
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"");
        var Tax = document.getElementById("span_Tax_"+EstimateItemID+"_"+j+"");
        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"_0");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"");
        var GrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+j+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+j+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+j+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+j+"");

        var MarkUpValue = RemoveDollorAndComma(MarkUp.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(ProfitMargin.innerHTML);
        var TaxValue = RemoveDollorAndComma(Tax.innerHTML);
        var TotalSellingPriceValue = RemoveDollorAndComma(TotalSellingPrice.innerHTML);
        var GrossProfitValue = RemoveDollorAndComma(GrossProfit.innerHTML);
        
        txtSubTotal.value = SellingPriceInMarkupValue;
        
        var Profit = (Number(SellingPriceInMarkupValue) * Number(priftValue))/100;
        Profit = roundNumber(Profit,2);
        ProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Profit;
        
        txtSubTotal.value = roundNumber(Number(Profit) + Number(txtSubTotal.value),2);
        TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(ddlTax.value)))/100;
        Tax.innerHTML = "" + commclass.GetCurrencyinRequiredFormate("", true) + "" + roundNumber(TaxValue, 2);
        var SellingPrice = roundNumber(Number(TaxValue)+ Number(txtSubTotal.value),2);
        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        
        var GrossValue = roundNumber(Number(MarkUpValue)+Number(Profit) , 2);
        if(Number(txtSubTotal.value)=="0")
        {
            GrossProfit.innerHTML = "(0.00%)" + GetCurrencyinRequiredFormate("", true) + ""+ GrossValue;
        }
        else
        {
          var GrossPercentage = roundNumber(((Number(MarkUpValue) + Number(Profit))/ Number(txtSubTotal.value) * 100),2);
          GrossPercentage = roundNumber(GrossPercentage, 2);
          GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue;
        }
        Taxsummary.innerHTML = Tax.innerHTML;
        TotalSellingPricesummary.innerHTML = TotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = GrossProfit.innerHTML;
    }
}
function SinglePadLarge_TaxOnChange(TaxPercent,EstimateItemID,QtyCount)
{
    for(var j=0;j<QtyCount;j++)
    {
        var span_ProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+j+"");
        var span_Markup = document.getElementById("span_Markup_"+EstimateItemID+"_"+j+"");
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"");
        var Tax = document.getElementById("span_Tax_"+EstimateItemID+"_"+j+"");        
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"");
        var GrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+j+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+j+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+j+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+j+"");

        var Profit = RemoveDollorAndComma(span_ProfitMargin.innerHTML);
        var MarkUpValue = RemoveDollorAndComma(span_Markup.innerHTML);
        var TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxPercent)))/100;

        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + roundNumber(TaxValue, 2);
        
        var SellingPrice = Number(txtSubTotal.value) + Number(TaxValue);
        SellingPrice = roundNumber(SellingPrice,2);

        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        
        Taxsummary.innerHTML = Tax.innerHTML;
        TotalSellingPricesummary.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        
        var GrossValue = roundNumber(Number(MarkUpValue)+Number(Profit) , 2);
        if(SellingPrice=="0")
        {
            GrossProfit.innerHTML = "(0.00%)" + GetCurrencyinRequiredFormate("", true) + ""+ GrossValue;
            GrossProfitsummary.innerHTML = GrossProfit.innerHTML;
        }
        else
        {
            var GrossPercentage = roundNumber(((Number(MarkUpValue) + Number(Profit))/ Number(txtSubTotal.value) * 100),2);
            GrossPercentage = roundNumber(GrossPercentage, 2);
            GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue;
            GrossProfitsummary.innerHTML = GrossProfit.innerHTML;            
        }
    }
}
function OnBlur_SinglePadLarge_SubTotal(subTotal,EstimateItemID,i)
{    
    var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_"+EstimateItemID+"_"+i+"");
    var SpnProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+i+"");
    var SpnMarkup = document.getElementById("span_Markup_"+EstimateItemID+"_"+i+"");
    var SpnTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
    var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"_0");
    var ddlProfit  = document.getElementById("ddlProfit_"+EstimateItemID+"_0");
    var SpnSellingPriceInTax = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+i+"");
    var SpnGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+i+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");
    
    if(!isNaN(subTotal))
    {
        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var ProfitValue = RemoveDollorAndComma(SpnProfitMargin.innerHTML);
        var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
        var GrossProfitValue = 0;
        var GrossPercentage = 0;
        
        var TaxValue = roundNumber((Number(subTotal) * Number(Get_Tax_Value(ddlTax.value))/100), 2);
        var SellInTax = roundNumber(Number(Number(subTotal)+Number(TaxValue)), 2);

        SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
        
        GrossProfitValue = GrossProfit_Value(Number(CostPriceExMarkup),Number(subTotal));//roundNumber((Number(MarkupValue) + Number(ProfitValue)), 2);
        if(Number(subTotal)==0)
        {
            GrossPercentage="0.00";
        }
        else
        {
            var topvalue  = GrossProfit_Percentage(Number(subTotal),Number(GrossProfitValue));//(Number(MarkupValue) + Number(ProfitValue))/Number(subTotal);
            GrossPercentage = topvalue;//roundNumber((Number(topvalue)*100), 2);
        }
        SpnGrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossProfitValue;
        Taxsummary.innerHTML = SpnTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpnSellingPriceInTax.innerHTML;
        GrossProfitsummary.innerHTML = SpnGrossProfit.innerHTML;
    }
    else
    {
        document.getElementById("txtSubTotal_"+EstimateItemID+"_"+i+"").value=0;
    }
}

//Booklet function strats from here ------------------------------------
////The Below function is used in Booklet Section (Section 1, Section 2) 
//// But the functionality is DISABLED = TRUE
function TaxOnChange(TaxPercent,EstimateItemID,EstBookletSectionID,QtyCount)
{
    //para  ==> 320,64,2
   /* var arr = para.split(',');
    var EstimateItemID = arr[0];
    var EstBookletSectionID = arr[1];
    var QtyCount = arr[2];*/
    
    for(var j=0;j<QtyCount;j++)
    {
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
        var Tax = document.getElementById("span_Tax_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
        
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
        var GrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
        
        var TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxPercent)))/100;
        if(j==0)
        {
           //var spanTaxPercentage = document.getElementById("span_Tax_Percentage_"+Start_i+"_"+j+""); 
           //spanTaxPercentage.innerHTML ="("+TaxPercent+"%)";
        }

        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + parseFloat(TaxValue).toFixed(2);
        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + parseFloat(Number(txtSubTotal.value) + Number(TaxValue)).toFixed(2);
        
    }
}
function ShowSection(obj,EstBookletItemID,para2,para3)
{
    //Para3 is Quantity Count and para2 is showtype
    var btnID = defaultButton.replace("T1E2S3T","");
    obj.style.backgroundColor="orange";
    if(para2=='all')
    {
        
        document.getElementById("div_AllSection_"+EstBookletItemID+"").style.display="block";
        for(var i=0;i<para3;i++)
        {   
            document.getElementById("div_Section_"+EstBookletItemID+"_"+i+"").style.display="none";
            document.getElementById(""+btnID+EstBookletItemID+"_"+i+"").style.backgroundColor="";
        }
    }
    else
    {
        document.getElementById("div_AllSection_"+EstBookletItemID).style.display="none";
        for(var i=0;i<para3;i++)
        {   
            document.getElementById("div_Section_"+EstBookletItemID+"_"+i+"").style.display="none";
            document.getElementById(""+btnID+EstBookletItemID+"_"+i+"").style.backgroundColor="";
        }
        document.getElementById(""+btnID+EstBookletItemID+"").style.backgroundColor="";
        document.getElementById("div_Section_"+EstBookletItemID+"_"+para2+"").style.display="block";
        document.getElementById(""+btnID+EstBookletItemID+"_"+para2+"").style.backgroundColor="orange";
    }
}
function Summary_Detail_Section(EstBookletItemID,qtyCount,para,para1,EstimateItemID)
{
     var val="0";
     document.cookie = "TabViewCookies="+val+"";
    if(document.getElementById("div_AllSection_"+EstBookletItemID).style.display=="block")
    {
        for(var i=0;i<qtyCount;i++)
        {   
            document.getElementById("div_Section_"+EstBookletItemID+"_"+i+"").style.display="none";
        }
        if(para=='detail')
        {
            document.getElementById("div_alldetail_"+EstBookletItemID+"").style.display="block";
            document.getElementById("div_allsummary_"+EstBookletItemID+"").style.display="none";
            var itemNu =  Number(para1)+1;
            document.getElementById("spnItem_"+para1+"").innerHTML = "Item "+itemNu +" Detail";
            document.getElementById("spnItem_"+para1+"").style.color = "#751717";                   
        }
        else
        {
            document.getElementById("div_alldetail_"+EstBookletItemID+"").style.display="none";
            document.getElementById("div_allsummary_"+EstBookletItemID+"").style.display="block"; 
            var itemNu =  Number(para1)+1;
            document.getElementById("spnItem_"+para1+"").innerHTML = "Item "+itemNu +" Summary";
            document.getElementById("spnItem_"+para1+"").style.color = "#000000";                    
        }
        var cookValue = para+"µbookletµallµ"+EstBookletItemID+"µ0µ"+qtyCount+"";
        createCookie_Summary(EstimateItemID,cookValue,1); 
    }
    else 
    {
        for(var i=0;i<qtyCount;i++)
        {   
            if(document.getElementById("div_Section_"+EstBookletItemID+"_"+i+"").style.display=="block")
            {
                if(para=='detail')
                {
                    document.getElementById("div_detail_"+EstBookletItemID+"_"+i+"").style.display="block";
                    document.getElementById("div_summary_"+EstBookletItemID+"_"+i+"").style.display="none"; 
                    var itemNu =  Number(para1)+1;
                    document.getElementById("spnItem_"+para1+"").innerHTML = "Item "+itemNu +" Detail";
                    document.getElementById("spnItem_"+para1+"").style.color = "#751717";                   
                }
                else if(para=='summary')
                {
                   document.getElementById("div_detail_"+EstBookletItemID+"_"+i+"").style.display="none";
                   document.getElementById("div_summary_"+EstBookletItemID+"_"+i+"").style.display="block";
                    var itemNu =  Number(para1)+1;
                    document.getElementById("spnItem_"+para1+"").innerHTML = "Item "+itemNu +" Summary";
                    document.getElementById("spnItem_"+para1+"").style.color = "#000000";                    
                }
                var idFormat = EstBookletItemID+"_"+i+"";
                var cookValue = para+"µbookletµsectionµ"+EstBookletItemID+"µ"+i+"µ"+qtyCount+"";
                createCookie_Summary(EstimateItemID,cookValue,1); 
            }
        }             
    }
    }
    //The Following function is for Booklet only
    function Booklet_TaxandProfitMargin(Profit,EstimateItemID,QtyCount,caltype)
    {
        for(var i=0;i<QtyCount;i++)
        {        
            var SpnCostExMarkup = document.getElementById("span_CostExMarkup_"+EstimateItemID+"_"+i+"");
            var SpnMarkup = document.getElementById("span_Markup_"+EstimateItemID+"_"+i+"");
            var SpnProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+i+"");
            var txtSubTotal = document.getElementById("txt_SubTotal_"+EstimateItemID+"_"+i+"");
            var SpnTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
            var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
            var SpnSellingPriceInTax = document.getElementById("span_SellingPriceInTax_"+EstimateItemID+"_"+i+"");
            var SpnGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
            var SpnTaxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
            var SpnSellingPriceInTaxsummary = document.getElementById("span_SellingPriceInTax_summary_"+EstimateItemID+"_"+i+"");
            var SpnGrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");

            var CostExMarkupValue = RemoveDollorAndComma(SpnCostExMarkup.innerHTML);
            var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
            var CostInMarkup = Number(CostExMarkupValue) + Number(MarkupValue);
            var TaxPercentage = Get_Tax_Value(ddlTax.value);

            var ProfitValue =0;
            var GrossProfitValue = 0;
            var GrossPercentage = 0;
            var subTotal = 0;
            if(caltype=="profit")
            {
                ProfitValue = (Number(CostInMarkup)*Number(Profit))/100; 
                ProfitValue = roundNumber(ProfitValue,2);
                
                subTotal = Number(CostInMarkup)+Number(ProfitValue);
                subTotal = roundNumber(subTotal,2);

                var TaxValue = (Number(subTotal) * Number(TaxPercentage)) / 100;
                TaxValue = roundNumber(TaxValue,2);
                
                var SellInTax = Number(subTotal)+Number(TaxValue);
                SellInTax = roundNumber(SellInTax,2);
                
                GrossProfitValue = Number(MarkupValue) + Number(ProfitValue);
                GrossProfitValue = roundNumber(GrossProfitValue,2);
                if(Number(subTotal)!=0)
                {
                    GrossPercentage = (Number(MarkupValue) + Number(ProfitValue))/ Number(subTotal) * 100;                
                }
                else
                {
                    GrossPercentage=0;
                }
                GrossPercentage = roundNumber(GrossPercentage,2);

                SpnProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitValue;            
                txtSubTotal.value = subTotal;
                SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
                SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
                //summary
                SpnTaxsummary.innerHTML = SpnTax.innerHTML;
                SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
            }
            else if(caltype=="tax")
            {
                var taxPercentage = Get_Tax_Value(ddlTax.value);
                subTotal = RemoveDollorAndComma(txtSubTotal.value);
                subTotal = roundNumber(subTotal,2);

                var TaxValue = (Number(subTotal) * Number(TaxPercentage)) / 100;
                TaxValue = roundNumber(TaxValue,2);
                
                var SellInTax = Number(subTotal) + Number(TaxValue);
                SellInTax = roundNumber(SellInTax,2);
                
                GrossProfitValue = Number(MarkupValue) + Number(ProfitValue);
                GrossProfitValue = roundNumber(GrossProfitValue,2);

                SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
                SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
                //summary
                SpnTaxsummary.innerHTML = SpnTax.innerHTML;
                SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
            }
            if(Number(subTotal)==0)
            {
                GrossPercentage="0.00";
            }
            else
            {
                GrossPercentage = ((Number(MarkupValue) + Number(ProfitValue))/Number(subTotal)) * 100;
                GrossPercentage = roundNumber(GrossPercentage,2);
            }
            SpnGrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossProfitValue;
            //summary
            SpnGrossProfitsummary.innerHTML = SpnGrossProfit.innerHTML;
        }    
    }
    function Booklet_SubTotal(subTotal,EstimateItemID,i)
    {
        var span_CostExMarkup = document.getElementById("span_CostExMarkup_"+EstimateItemID+"_"+i+"");
        var SpnProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+i+"");
        var SpnMarkup = document.getElementById("span_Markup_"+EstimateItemID+"_"+i+"");
        var SpnTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
        var ddlProfit  = document.getElementById("ddlProfit_"+EstimateItemID+"");
        var SpnSellingPriceInTax = document.getElementById("span_SellingPriceInTax_"+EstimateItemID+"_"+i+"");
        var SpnGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
        var SpnTaxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
        var SpnSellingPriceInTaxsummary = document.getElementById("span_SellingPriceInTax_summary_"+EstimateItemID+"_"+i+"");
        var SpnGrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");
        if(!isNaN(subTotal))
        {
            var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
            var ProfitValue = RemoveDollorAndComma(SpnProfitMargin.innerHTML);
            var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
            var GrossProfitValue = 0;
            var GrossPercentage = 0;
            
            var TaxValue = (Number(subTotal)*Number(Get_Tax_Value(ddlTax.value)))/100;
            TaxValue = roundNumber(TaxValue,2);
            
            var SellInTax = Number(subTotal) + Number(TaxValue);
            SellInTax = roundNumber(SellInTax,2);

            SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
            SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
            
            GrossProfitValue = GrossProfit_Value(Number(CostExMarkup),Number(subTotal)); //Number(MarkupValue) + Number(ProfitValue);
            GrossProfitValue = roundNumber(GrossProfitValue,2);
                        
            if(Number(subTotal)==0)
            {
                GrossPercentage="0.00";
            }
            else
            {
                GrossPercentage = GrossProfit_Percentage(Number(subTotal),Number(GrossProfitValue));//(Number(MarkupValue) + Number(ProfitValue))/ Number(subTotal) * 100;
                GrossPercentage = roundNumber(GrossPercentage,2);   
            }
            SpnGrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossProfitValue;
            SpnTaxsummary.innerHTML = SpnTax.innerHTML;
            SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
            SpnGrossProfitsummary.innerHTML = SpnGrossProfit.innerHTML;           
        }
        else
        {
            document.getElementById("txt_SubTotal_"+EstimateItemID+"_"+i+"").value=0;
        }
    }   
    
//Booklet function ends here -------------------------------------------------------------------------------------------------

function Outwork_TaxOnChange(TaxID,EstimateItemID,QtyCount)
{
    for(var i=1;i<=QtyCount;i++)
    {
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+i+"");//TextBox
        var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+i+"");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+i+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");
        
        var TaxValue = Number(Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxID)))/100;

        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + roundNumber(Number(txtSubTotal.value) + Number(TaxValue), 2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + roundNumber(Number(TaxValue), 2);
        
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
}

function ProfitMarginShow_PrintBroker(Proift,EstimateItemID,QtyCount)
{
    /*
    var Arr = List.split(',');
    var EstimateItemID = Arr[0];
    var QtyCount  = Arr[1];
    */    
    for(var i=1;i<=QtyCount;i++)
    {
        var SpanMarkup = document.getElementById("span_Markup_"+EstimateItemID+"_"+i+"");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+i+"");
        var SpanTotalPrice = document.getElementById("span_TotalPrice_"+EstimateItemID+"_"+i+"");//Reference
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+i+"");//TextBox
        var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+i+"");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+i+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");

        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var TotalPriceValue  = RemoveDollorAndComma(SpanTotalPrice.innerHTML);
        var TaxValue;
                 
        ProfitMarginValue = (Number(TotalPriceValue) * Number(Proift))/100; 
        ProfitMarginValue = roundNumber(ProfitMarginValue,2);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;   
                    
        var subValue =  Number(ProfitMarginValue) + Number(TotalPriceValue);
        txtSubTotal.value = roundNumber(subValue,2);
        
        TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(ddlTax.value)))/100;
        TaxValue = roundNumber(TaxValue,2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
       
        var TotalSell = Number(txtSubTotal.value) + Number(TaxValue)
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + roundNumber(TotalSell, 2);
        
        var GrossValue =Number(Markup)+ Number(ProfitMarginValue);
        GrossValue = roundNumber(GrossValue,2);
        if(Number(txtSubTotal.value)==0)
        {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else
        {
            var GrossPercent =  ((Number(Markup)+ Number(ProfitMarginValue))/Number(txtSubTotal.value)) * 100 ;
            GrossPercent = roundNumber(GrossPercent,2);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
}
//SubTotal Text Box OnBlur
function Outwork_SubTotalCal(subValue,EstimateItemID,i)
{
    /*var arr = para.split(',');       
    */    
    var span_CostExMarkup = document.getElementById("span_CostExMarkup_"+EstimateItemID+"_"+i+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+i+"");
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateItemID+"_"+i+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+i+"");   
    var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"_"+i+"");
    var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+i+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+i+"");
    
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"_"+i+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"_"+i+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"_"+i+"");
    
    if(!isNaN(subValue))
    {
        var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var TaxValue = 0;
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        
        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
        TaxValue = roundNumber(TaxValue,2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        
        var TotalSell = Number(subValue) + Number(TaxValue);
        TotalSell = roundNumber(TotalSell,2);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalSell;
        
        var GrossValue = GrossProfit_Value(Number(CostExMarkup),Number(subValue));//Number(Markup)+ Number(ProfitMarginValue);
        GrossValue = roundNumber(GrossValue,2);
        if( Number(subValue)==0)
        {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else
        {
            var GrossPercent = GrossProfit_Percentage(Number(subValue),Number(GrossValue));//((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
            GrossPercent = roundNumber(GrossPercent,2);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else
    {
        txtSubTotal.value = 0;
    }        
}
//Outwork Detial and Summary
function OutWork_Summary_Detail_Show(EstimateItemID,i,type)
{
     var val="0";
     document.cookie = "TabViewCookies="+val+"";
     var itemNu =  Number(i)+1;
    ////var arr = para.split(',');
    if(type=="summary")
    {
        //Show Summary
        document.getElementById("div_summary_"+EstimateItemID+"").style.display="block";
        document.getElementById("div_detail_"+EstimateItemID+"").style.display="none";
        try
        {
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu +" Summary";
            document.getElementById("spnItem_"+i+"").style.color = "#000000";
            
        }catch(err)
        {
        }       
    }
    else if(type=="detail")
    {
        //Show detail
        document.getElementById("div_summary_"+EstimateItemID+"").style.display="none";
        document.getElementById("div_detail_"+EstimateItemID+"").style.display="block";
        try
        {
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu +" Detail";
            document.getElementById("spnItem_"+i+"").style.color = "#751717";
        }catch(err)
        {
        }      
    }
    var cookValue = type+"µPrintBrokerµ"+EstimateItemID+"µ"+i+"";
    createCookie_Summary(EstimateItemID,cookValue,1);
   
}
//Other Cost Starts from here
function OtherCostProfitMargin(profit,EstimateitemID)
{
    var profit = document.getElementById("ddlProfit_"+EstimateitemID+"").value;
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateitemID+"");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateitemID+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateitemID+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateitemID+"");//TextBox
    var SpanTax = document.getElementById("span_Tax_"+EstimateitemID+"");
    var ddlTax = document.getElementById("ddlTax_"+EstimateitemID+"");
    
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateitemID+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateitemID+"");
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateitemID+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateitemID+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateitemID+"");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue  = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = 0;// SpanTax.innerHTML.replace('$','').replace(/,/,'');

    ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit))/100;
    ProfitMarginValue = roundNumber(ProfitMarginValue,2);
    SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;
    
    var subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
    subValue = roundNumber(subValue,2);
    txtSubTotal.value = subValue; 
    
    TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) /100;
    TaxValue = roundNumber(TaxValue,2);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
    
    var sellInTax = Number(TaxValue)+ Number(txtSubTotal.value);
    sellInTax = roundNumber(sellInTax,2);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + sellInTax;
    
    var GrossPercent = 0;
    var GrossValue = Number(Markup)+ Number(ProfitMarginValue);
    GrossValue = roundNumber(GrossValue,2); 
    
    if(subValue=="0.00")
    {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else
    {
        GrossPercent =  ((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100 ;
        GrossPercent = roundNumber(GrossPercent,2);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
    }   
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function OtherCostTaxOnChange(taxID,EstimateitemID)
{
    var tax = Get_Tax_Value(taxID);
    
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateitemID+"");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateitemID+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateitemID+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateitemID+"");//TextBox
    var SpanTax = document.getElementById("span_Tax_"+EstimateitemID+"");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateitemID+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateitemID+"");
    
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateitemID+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateitemID+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateitemID+"");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);
    
    var newTaxValue =  (Number(SubTotalValue) * Number(tax))/100;
    newTaxValue = roundNumber(newTaxValue,2);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + newTaxValue;
    
    var sellInTax = Number(newTaxValue)+ Number(SubTotalValue);
    sellInTax = roundNumber(sellInTax,2);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + sellInTax;
    
    var subValue = SubTotalValue;
    
    var GrossPercent =0;
    var GrossValue = Number(Markup)+ Number(ProfitMarginValue);
        GrossValue = roundNumber(GrossValue,2);
    if(subValue=="0.00")
    {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else
    {
        GrossPercent = ((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
        GrossPercent = roundNumber(GrossPercent,2);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function OtherCostSubTotalOnBlur(txtValue,EstimateitemID)
{
    var span_CostExMarkup = document.getElementById("span_CostExMarkup_"+EstimateitemID+"");
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateitemID+"");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateitemID+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateitemID+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateitemID+"");//TextBox
    var ddlTax = document.getElementById("ddlTax_"+EstimateitemID+"");//ddl
    var SpanTax = document.getElementById("span_Tax_"+EstimateitemID+"");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateitemID+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateitemID+"");  
    
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateitemID+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateitemID+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateitemID+""); 
    
    var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);

    if(!isNaN(txtValue) && txtValue!='')
    {
        var TaxValue = (Number(txtValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
        TaxValue = roundNumber(TaxValue,2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

        var SellInTax = Number(txtValue) + Number(TaxValue);
        SellInTax = roundNumber(SellInTax,2);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
        
        var subValue = SubTotalValue;
    
        var GrossPercent =0;
        var GrossValue = GrossProfit_Value(Number(CostExMarkup),Number(subValue));  //Number(Markup)+ Number(ProfitMarginValue);
            GrossValue = roundNumber(GrossValue,2);
            
        if(Number(subValue)==0)
        {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else
        {
            GrossPercent = GrossProfit_Percentage(Number(subValue),Number(GrossValue));//((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
            GrossPercent = roundNumber(GrossPercent,2);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else
    {
        txtSubTotal.value = 0;
    }
}

//END OF OTHER COST Js


//This function is called from .CS page
function Summary_Detail_Show(i,type,EstimateItemID)
{
    /*var arr = para.split(',');*/
    var val="0";
     document.cookie = "TabViewCookies="+val+"";
    if(type=="summary")
    {
        //Show Summary
        document.getElementById("div_summary_"+i+"").style.display="block";
        document.getElementById("div_detail_"+i+"").style.display="none";
        try
        {
        var itemNu =  Number(i)+1;
        document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu +" Summary";
        document.getElementById("spnItem_"+i+"").style.color = "#000000";
        }catch(err)
        {
        }
    }
    else
    {
        //Show Detail
        document.getElementById("div_detail_"+i+"").style.display="block";
        document.getElementById("div_summary_"+i+"").style.display="none";
        try
        {
        var itemNu =  Number(i)+1;
        document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu+" Detail";
        document.getElementById("spnItem_"+i+"").style.color = "#751717";
        }catch(err)
        {
        }
    }
    var cookValue = type+"µSPLOµ"+i+"µ"+EstimateItemID+"";
    createCookie_Summary(EstimateItemID,cookValue,1);
}


// Main Warehouse Js Starts
function WarehouseOnBlur(subValue,EstimateItemID)
{
    if(!isNaN(subValue) && subValue!='')
    {
        var span_CostExMarkup = document.getElementById("span_CostExMarkup_"+EstimateItemID+"");
        var profit = document.getElementById("ddlProfit_"+EstimateItemID+"").value;
        var SpanMarkup = document.getElementById("span_Markup_"+EstimateItemID+"");
        var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateItemID+"");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"");
        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"");//TextBox
        var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"");
        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");        
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"");
       
        var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var SubTotalValue  = RemoveDollorAndComma(txtSubTotal.value);
        var TaxValue = 0;//SpanTax.innerHTML.replace('$','').replace(/,/,'');
        var SellInTax =0;

        ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit))/100;
        ProfitMarginValue = roundNumber(ProfitMarginValue,2);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;        
        
        subValue = RemoveDollorAndComma(subValue);
        
        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
        TaxValue = roundNumber(TaxValue,2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        
        SellInTax = Number(TaxValue)+ Number(subValue);
        SellInTax = roundNumber(SellInTax,2);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
        
        var GrossPercent = 0;
        var GrossValue = GrossProfit_Value(Number(CostExMarkup),Number(subValue));//Number(Markup)+ Number(ProfitMarginValue);
            GrossValue = roundNumber(GrossValue,2);        
            
        if(subValue==0)
        {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else
        {
            GrossPercent = GrossProfit_Percentage(Number(subValue),Number(GrossValue));//((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
            GrossPercent = roundNumber(GrossPercent,2);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else
    {
        document.getElementById("txtSubTotal_"+EstimateItemID+"").value="0";
    }
}
function WarehouseTaxOnChange(TaxID,EstimateItemID)
{
    var tax = Get_Tax_Value(TaxID);
    
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateItemID+"");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateItemID+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"");//TextBox
    var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"");
    
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);
    var SellInTax = 0;

    var newTaxValue =  (Number(SubTotalValue) * Number(tax))/100;
    newTaxValue = roundNumber(newTaxValue,2);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + newTaxValue;
    
    SellInTax = Number(newTaxValue)+ Number(SubTotalValue);
    SellInTax = roundNumber(SellInTax,2);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
    
    var subValue = SubTotalValue;
    subValue = roundNumber(subValue,2);
    
    var GrossPercent =  0;
    var GrossValue = Number(Markup)+ Number(ProfitMarginValue);
    GrossValue = roundNumber(GrossValue,2);
    
    if(Number(subValue)==0)
    {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else
    {
        GrossPercent = ((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
        GrossPercent = roundNumber(GrossPercent,2);

        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function WarehouseProfitOnChange(profit,EstimateItemID)
{
    WareForBoth(profit,EstimateItemID);
}
function WareForBoth(profit,EstimateItemID)
{
    var SpanMarkup = document.getElementById("span_Markup_"+EstimateItemID+"");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateItemID+"");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"");
    var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"");//TextBox
    var SpanTax = document.getElementById("span_Tax_"+EstimateItemID+"");
    var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
    
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"");
    
    var Taxsummary = document.getElementById("span_Tax_summary_"+EstimateItemID+"");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_"+EstimateItemID+"");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_"+EstimateItemID+"");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue  = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = 0;//SpanTax.innerHTML.replace('$','').replace(/,/,'');
    var SellInTax = 0;

    ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit))/100;
    ProfitMarginValue = roundNumber(ProfitMarginValue,2);
    SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;
    
    var subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
    subValue = roundNumber(subValue,2);
    txtSubTotal.value = subValue; 
    
    TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
    TaxValue = roundNumber(TaxValue,2);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
    
    SellInTax = Number(TaxValue)+ Number(subValue);
    SellInTax = roundNumber(SellInTax,2);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
    
    var GrossPercent = 0;
    var GrossValue = Number(Markup)+ Number(ProfitMarginValue);
    GrossValue = roundNumber(GrossValue,2);
    if(Number(subValue)==0)
    {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else
    {
        GrossPercent = (Number(Markup)+ Number(ProfitMarginValue))/Number(subValue);
        GrossPercent = GrossPercent * 100;
        GrossPercent = roundNumber(GrossPercent,2);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}


function WarehouseSummaryDetails(EstimateItemID,i,type)
{
     var val="0";
     document.cookie = "TabViewCookies="+val+"";
    /* var arr = para.split(','); */
    if(type=='detail')
    {
        //div_detail_
        document.getElementById("div_Warehouse_Details_"+EstimateItemID+"").style.display="block";
        document.getElementById("div_Warehouse_Summary_"+EstimateItemID+"").style.display="none";
        try
        {
            var itemNu =  Number(i)+1;
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu+" Detail";
            document.getElementById("spnItem_"+i+"").style.color = "#751717";
        }catch(err)
        {
        }
    }
    else if(type=='summary')
    {
        //div_summary_
        document.getElementById("div_Warehouse_Details_"+EstimateItemID+"").style.display="none";
        document.getElementById("div_Warehouse_Summary_"+EstimateItemID+"").style.display="block";
        try
        {
            var itemNu =  Number(i)+1;
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu+" Summary";
            document.getElementById("spnItem_"+i+"").style.color = "#000000";
        }catch(err)
        {
        }
    }
    var cookValue = type+"µWarehouseµ"+EstimateItemID+"µ"+i+"";
    createCookie_Summary(EstimateItemID,cookValue,1);    
}
// Main Warehouse ENDS Here

//CATALOGUE STARTS FROM HERE
function Catalogue_Summary_Details(EstimateItemID,i,type)
{
     var val="0";
     document.cookie = "TabViewCookies="+val+"";
    /* var arr = para.split(','); */
    if(type=='detail')
    {
        //div_detail_
        document.getElementById("div_Catalogue_Details_"+EstimateItemID+"").style.display="block";
        document.getElementById("div_Catalogue_Summary_"+EstimateItemID+"").style.display="none";
        try
        {
            var itemNu =  Number(i)+1;
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu+" Detail";
            document.getElementById("spnItem_"+i+"").style.color = "#751717";
        }catch(err)
        {
        }
    }
    else if(type=='summary')
    {
        //div_summary_
        document.getElementById("div_Catalogue_Details_"+EstimateItemID+"").style.display="none";
        document.getElementById("div_Catalogue_Summary_"+EstimateItemID+"").style.display="block";
        try
        {
            var itemNu =  Number(i)+1;
            document.getElementById("spnItem_"+i+"").innerHTML = "Item "+itemNu+" Summary";
            document.getElementById("spnItem_"+i+"").style.color = "#000000";
        }catch(err)
        {
        }
    }
    var cookValue = type+"µWarehouseµ"+EstimateItemID+"µ"+i+"";
    createCookie_Summary(EstimateItemID,cookValue,1);    
}
//CATALOGUE ENDS HERE

function createCookie_Summary(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie_Summary(name) 
{
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) 
	{
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) 
		{
		    c.substring(nameEQ.length,c.length);
		}
	}
	return null;
}

function eraseCookie_Summary(name) {
	createCookie(name,"",-1);
}

function ShowOnCookie(name) 
{   
    if(readCookie_Summary(name)!=null)
    {
        var cookvalue ='';
	    var nameEQ = name + "=";
	    var ca = document.cookie.split(';');
	    for(var i=0;i < ca.length;i++) 
	    {
		    var c = ca[i];
		    while (c.charAt(0)==' ') c = c.substring(1,c.length);
		    if (c.indexOf(nameEQ) == 0) 
		    {
		      cookvalue =  c.substring(nameEQ.length,c.length);
		      if(cookvalue!='')
		      {
		        
		      }
		    }
	    }
	}
}

function CallAfterLoad()
{
    
    try
    {
        var ListOfId = EstimateItemIDList.split('±');
        for(var i=0;i<ListOfId.length-1;i++)
        {
            var spnName = trim12("spnItem_" + i + "");
            var EID = ListOfId[i];
            
            if(document.getElementById(spnName)!=null)
            {
                var Array1 = document.cookie.split(';');
                for(var k=0;k<Array1.length;k++)
                {                    
                    var Array2 = Array1[k].split('=');  
                    
                    if( trim12(Array2[0])==EID)
                    {
                        var itemNu = Number(i)+1;
                        var ArrayOne = Array2[1].split('µ');
                        ////para+"  µ   booklet µ   section µ   EstBookletItemID  µ " i;
                        if(ArrayOne[1]=='booklet')
                        {
                            var showtype = ArrayOne[0];
                            var sectionType = ArrayOne[2];
                            var EstBookletItemID = ArrayOne[3];
                            var index = ArrayOne[4];
                            var qtyCount = ArrayOne[5];
                            //para µ  booklet µ section  µ  EstBookletItemID µ i µ qtyCount
                            //para µ  booklet µ all      µ  EstBookletItemID  µ 0 µ qtyCount
                            
                            if(sectionType=="all")
                            {
                                document.getElementById("div_AllSection_"+EstBookletItemID).style.display="block";
                                var btnID = defaultButton.replace("T1E2S3T","");
                                var btnObj = document.getElementById(""+btnID+EstBookletItemID+"_"+index+"");                            
                                ShowSection(btnObj,EstBookletItemID,sectionType,qtyCount);
                            }
                            else
                            {
                                document.getElementById("div_AllSection_"+EstBookletItemID).style.display="none";
                                document.getElementById("div_Section_"+EstBookletItemID+"_"+index+"").style.display="block";
                                
                                var btnID = defaultButton.replace("T1E2S3T","");
                                var btnObj = document.getElementById(""+btnID+EstBookletItemID+"_"+index+"");                            
                                ShowSection(btnObj,EstBookletItemID,index,qtyCount);
                            }
                            Summary_Detail_Section(EstBookletItemID,qtyCount,showtype,index);
                            
                        }
                        else if(ArrayOne[1]=='SPLO')
                        {
                            //var cookValue = type µ single µ i µ EstimateItemID;
                            var showtype = ArrayOne[0];
                            Summary_Detail_Show(i,showtype);
                        }
                        else if(ArrayOne[1]=='PrintBroker')
                        {
                            //var cookValue = showtype µ PrintBroker µ  EstimateItemID µ i 
                            var showtype = ArrayOne[0];
                            var EstimateItemID = ArrayOne[2];
                            var index = ArrayOne[3];
                            OutWork_Summary_Detail_Show(EstimateItemID,index,showtype);
                        }
                        else if(ArrayOne[1]=='Warehouse') 
                        {
                            var showtype = ArrayOne[0];
                            var EstimateItemID = ArrayOne[2];
                            var index = ArrayOne[3];
                            WarehouseSummaryDetails(EstimateItemID,index,showtype);
                        }
                    }                  
                }
            }
        }
    }
    catch(err)
    {
    }    
}
    function ProfitMarginShow_2(priftValue,para)
    {
        //para  ==> 320,64,2
        var arr = para.split(',');
        var EstimateItemID = arr[0];
        var EstBookletSectionID = arr[1];
        var QtyCount = arr[2];
        
        for(var j=0;j<QtyCount;j++)
        {
            var MarkUp = document.getElementById("span_Markup_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var SellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var ProfitMargin = document.getElementById("span_ProfitMargin_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var Tax = document.getElementById("span_Tax_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");
            var GrossProfit = document.getElementById("span_GrossProfit_"+EstimateItemID+"_"+j+"_"+EstBookletSectionID+"");

            var MarkUpValue = RemoveDollorAndComma(MarkUp.innerHTML);
            var SellingPriceInMarkupValue = RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
            var ProfitMarginValue = RemoveDollorAndComma(ProfitMargin.innerHTML);
            var TaxValue= RemoveDollorAndComma(Tax.innerHTML);
            var TotalSellingPriceValue = RemoveDollorAndComma(TotalSellingPrice.innerHTML);
            var GrossProfitValue = RemoveDollorAndComma(GrossProfit.innerHTML);
            
            txtSubTotal.value = SellingPriceInMarkupValue;
            
            var Profit = parseFloat((Number(SellingPriceInMarkupValue) * Number(priftValue))/100).toFixed(2);

            ProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Profit;
            
            txtSubTotal.value = parseFloat(Number(Profit) + Number(txtSubTotal.value)).toFixed(2);

            TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + parseFloat(Number(TaxValue) + Number(txtSubTotal.value)).toFixed(2);
            if(txtSubTotal.value=="0.00")
            {
                GrossProfit.innerHTML = "(0.00%)" + GetCurrencyinRequiredFormate("", true) + ""+ parseFloat((Number(MarkUpValue) + Number(Profit))).toFixed(2);
            }
            else
            {
              var GrossPercentage = parseFloat((Number(MarkUpValue) + Number(Profit))/ Number(txtSubTotal.value) * 100).toFixed(2);
              GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + parseFloat((Number(MarkUpValue) + Number(Profit))).toFixed(2);
            }
        }
    }


//FINAL SAVE CLICK
    function Estimate_Cal_Save()
    {
       //S»634»4    µ   B»635»3»258 µ   P»636»3 µ   L»637»4 µ   W»638   µ   O»639»206±   µ  U»640   µ
       var EstValues = 0;
       var AllData='';
       var StoreComplete ='';
       var ItmArr1 = OverallList.split('µ');
       for(var i=0;i<ItmArr1.length;i++)
       {
          if(ItmArr1[i]!='')
          {
             //S»26»3   µ   B»27»2  µ   U»28 
             //EstType»EstimateItem»QtyCount µ EstType»EstimateItem»QtyCount µ EstType»EstimateItem
             var ItmArr2 = ItmArr1[i].split('»');
             var EstimateItemID='';
             var QtyCount='';
             
             if(ItmArr2[0]=="U")
             {
                var otherData='U±'
                EstimateItemID = ItmArr2[1];
                var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"");//TextBox
                txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value)
                var ddlProfit = document.getElementById("ddlProfit_"+EstimateItemID+"");//ddl
                var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");//ddl
                
                var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");//TextBox
                
                otherData += "EstimateItemID»"+EstimateItemID+"±SubTotal»"+txtSubTotal.value+"±";
                otherData += "ProfitMargin»"+ddlProfit.value+"±Tax»"+Get_Tax_Value(ddlTax.value)+"±TaxID»"+ddlTax.value+"±ItemTitle»"+txtItemTitle.value;
                
                AllData += otherData + "µ";
                
                //----- Estimate Values ------
                var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"");//span
                var OtherSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                OtherSellPrice = roundNumber(OtherSellPrice,2);
                
                EstValues =  Number(EstValues) + Number(OtherSellPrice);
                EstValues = roundNumber(EstValues,2);
             }
             else if(ItmArr2[0]=="S")
             {
                var spanTotalSellingPrice='';
                
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);
                
                var SingleData='S±';
                for(var j=0; j<QtyCount; j++)
                {                  
                   if(j==0)
                   {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");
                        var ProfitMargin = document.getElementById("ddlProfit_"+EstimateItemID+"_"+j+"");
                        var Tax = document.getElementById("ddlTax_"+EstimateItemID+"_"+j+"");
                        SingleData += "EstimateItemID»"+ EstimateItemID +"±";
                        SingleData +="ItemTitle»"+ txtItemTitle.value +"±";
                        //SingleData +="SectionRef»"+ txtSectionRef.value +"±";
                        SingleData += "ProfitMargin»"+ ProfitMargin.value +"±";
                        SingleData += "Tax»"+Get_Tax_Value(Tax.value)+"±";
                        SingleData += "TaxID»"+Tax.value+"±";
                        
                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"");
                   }
                   
                   var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"");
                   var spanQtyID = document.getElementById("spanQty_"+EstimateItemID+"_"+j+"");
                   if(QtyCount-1 ==j)
                   {      
                     SingleData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML;
                     AllData += SingleData + "µ";                     
                   }
                   else
                   {
                     SingleData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML +"§";
                   }
                 }
                 //----- Estimate Values ------
                var SingleSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                SingleSellPrice = roundNumber(SingleSellPrice,2);
                 
                EstValues =  Number(EstValues) + Number(SingleSellPrice);
                EstValues = roundNumber(EstValues,2);                 
             }
             else if(ItmArr2[0]=="P")
             {
                var spanTotalSellingPrice='';               

                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);
                
                var PadData='P±';
                for(var j=0; j<QtyCount; j++)
                {                  
                   if(j==0)
                   {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");
                        var ProfitMargin = document.getElementById("ddlProfit_"+EstimateItemID+"_"+j+"");
                        var Tax = document.getElementById("ddlTax_"+EstimateItemID+"_"+j+"");
                        PadData += "EstimateItemID»"+ EstimateItemID +"±";
                        PadData +="ItemTitle»"+ txtItemTitle.value +"±";
                        //SingleData +="SectionRef»"+ txtSectionRef.value +"±";
                        PadData += "ProfitMargin»"+ ProfitMargin.value +"±";
                        PadData += "Tax»"+Get_Tax_Value(Tax.value)+"±";
                        PadData += "TaxID»"+Tax.value+"±";
                        
                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"");
                   }
                   
                   var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"");
                   var spanQtyID = document.getElementById("spanQty_"+EstimateItemID+"_"+j+"");
                   if(QtyCount-1 ==j)
                   {      
                     PadData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML;
                     AllData += PadData + "µ";
                   }
                   else
                   {
                     PadData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML +"§";
                   }
                 }
                 //----- Estimate Values ------
                var PadSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                PadSellPrice = roundNumber(PadSellPrice,2);        
                 
                EstValues =  Number(EstValues) + Number(PadSellPrice);
                EstValues = roundNumber(EstValues,2);                 
             }
             else if(ItmArr2[0]=="L")
             {
                var spanTotalSellingPrice='';

                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);
                
                var LargeData='L±';
                for(var j=0; j<QtyCount; j++)
                {                  
                   if(j==0)
                   {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");
                        var ProfitMargin = document.getElementById("ddlProfit_"+EstimateItemID+"_"+j+"");
                        var Tax = document.getElementById("ddlTax_"+EstimateItemID+"_"+j+"");
                        LargeData += "EstimateItemID»"+ EstimateItemID +"±";
                        LargeData +="ItemTitle»"+ txtItemTitle.value +"±";
                        //LargeData +="SectionRef»"+ txtSectionRef.value +"±";
                        LargeData += "ProfitMargin»"+ ProfitMargin.value +"±";
                        LargeData += "Tax»"+ Get_Tax_Value(Tax.value) +"±";
                        LargeData += "TaxID»"+ Tax.value +"±";
                        
                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+j+"");
                   }                   
                   var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+j+"");
                   var spanQtyID = document.getElementById("spanQty_"+EstimateItemID+"_"+j+"");
                   if(QtyCount-1 ==j)
                   {      
                     LargeData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML;
                     AllData += LargeData + "µ";
                   }
                   else
                   {
                     LargeData += "SubTotal»"+ RemoveDollorAndComma(txtSubTotal.value) +"»"+ spanQtyID.innerHTML +"§";
                   }
                 }
                 //----- Estimate Values ------
                var LargeSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                LargeSellPrice = roundNumber(LargeSellPrice,2);
                  
                EstValues =  Number(EstValues) + Number(LargeSellPrice);
                EstValues = roundNumber(EstValues,2);
             }
             else if(ItmArr2[0]=="W")
             {
                var WareData ='W±';
                EstimateItemID = ItmArr2[1];
                var ddlProfit = document.getElementById("ddlProfit_"+EstimateItemID+"");//ddl
                var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"");//TextBox
                var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");//ddl
                
                txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value);
                
                var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");//TextBox
                WareData +="EstimateItemID»"+EstimateItemID+"±";
                WareData +="ProfitMargin»"+ddlProfit.value+"±";
                WareData +="SubTotal»"+txtSubTotal.value+"±";
                WareData +="Tax»"+Get_Tax_Value(ddlTax.value)+"±";
                WareData +="TaxID»"+ddlTax.value+"±";
                WareData +="ItemTitle»"+txtItemTitle.value;
                AllData += WareData + "µ";
                //----- Estimate Values ------
                var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"");//span
                var WarehouseSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                WarehouseSellPrice = roundNumber(WarehouseSellPrice,2);      
                
                EstValues =  Number(EstValues) + Number(WarehouseSellPrice);
                EstValues = roundNumber(EstValues,2);                
             }
             else if(ItmArr2[0]=="O")
             {
                var OutData ='O±';
                EstimateItemID = ItmArr2[1];
                var ArrSup = ItmArr2[2].split('±');
                var OutFirstValue;
                for(var j=0;j<ArrSup.length;j++)
                {
                    if(ArrSup[j]!='')
                    {
                        var EstOutworkSupplierID = ArrSup[j];
                        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");
                        var ddlProfit = document.getElementById("ddlProfit_"+EstimateItemID+"");
                        var txtSubTotal = document.getElementById("txtSubTotal_"+EstimateItemID+"_"+Number(j+1)+"");//TextBox
                        if(j==0)
                        {
                            OutFirstValue = document.getElementById("span_TotalSellingPrice_"+EstimateItemID+"_"+Number(j+1)+"").innerHTML;//Span
                            OutFirstValue = RemoveDollorAndComma(OutFirstValue);
                        }    
                        var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");
                        
                        OutData +="EstimateItemID»"+EstimateItemID+"±";
                        OutData += "ItemTitle»"+txtItemTitle.value+"±";
                        OutData += "ProfitMargin»"+ddlProfit.value +'±';
                        OutData += "Tax»"+Get_Tax_Value(ddlTax.value)+"±";
                        OutData += "TaxID»"+ddlTax.value+"±";
                        OutData += "SubTotal»"+RemoveDollorAndComma(txtSubTotal.value) +'±';
                        OutData += "EstOutworkSupplierID»"+EstOutworkSupplierID+"§";
                    }
                }
                AllData += OutData + "µ";
                //----- Estimate Values ------       
                var OutValue = roundNumber(OutFirstValue,2);
                
                EstValues =  Number(EstValues) + Number(OutValue);
                EstValues = roundNumber(EstValues,2);                 
             }
             else if(ItmArr2[0]=="B")
             {
                //----Estimate Values
                var spanTotalSellingPrice ='';
                EstimateItemID = ItmArr2[1];
                var QtyCount = ItmArr2[2]; 
                var SectionList = ItmArr2[3].split('§');

                var BookData1='B±';

                for(var j=0;j<QtyCount;j++)
                {
                    if(j==0)
                    {
                        var txtItemTitle = document.getElementById("txtItemTitle_"+EstimateItemID+"");
                        var ProfitMargin = document.getElementById("ddlProfit_"+EstimateItemID+"");
                        var Tax = document.getElementById("ddlTax_"+EstimateItemID+"");
                        BookData1 += "EstimateItemID»"+ EstimateItemID +"±";
                        BookData1 += "ItemTitle»"+ txtItemTitle.value +"±";
                        BookData1 += "ProfitMargin»"+ ProfitMargin.value +"±";
                        BookData1 += "Tax»"+ Get_Tax_Value(Tax.value)+"±";
                        BookData1 += "TaxID»"+ Tax.value +"±";

                        spanTotalSellingPrice = document.getElementById("span_SellingPriceInTax_" + EstimateItemID + "_" + j + ""); //span
                        
                    }
                   
                    var spanQtyID = document.getElementById("spanQty_"+EstimateItemID+"_"+j+"");
                    var txtSubTotal = document.getElementById("txt_SubTotal_"+EstimateItemID+"_"+j+"");
                    var total = RemoveDollorAndComma(txtSubTotal.value);//.replace(/,/,'').replace('$','');
                    if(QtyCount-1 ==j)
                    {      
                         BookData1 += "SubTotal»"+ total +"»"+ spanQtyID.innerHTML;
                         BookData1 += "µ";
                    }
                    else
                    {
                         BookData1 += "SubTotal»"+ total +"»"+ spanQtyID.innerHTML +"§";
                    }
                }
                AllData += BookData1 +"µ";
                //-------- Estimate Values -------
                var BookSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);//.replace('$','').replace(/,/,'');
                BookSellPrice = roundNumber(BookSellPrice,2);
                
                EstValues =  Number(EstValues) + Number(BookSellPrice);
                EstValues = roundNumber(EstValues,2);
             }
             else if(ItmArr2[0]=="C")
             {
                var CatalogueData ='C±';
                EstimateItemID = ItmArr2[1];
                var CataPrice = 0;
                for(var q=0;q<4;q++)
                {
                    var ddlProfit = document.getElementById("ddlProfit_"+EstimateItemID+"");//ddl
                    if(document.getElementById("txtSubTotal_"+ q +"_"+EstimateItemID+"")!=null)
                    {
                        var txtSubTotal = document.getElementById("txtSubTotal_"+ q +"_"+EstimateItemID+"");//TextBox
                        var EstPriceCatalogueID = document.getElementById("span_EstPriceCatalogueID_"+ q +"_"+EstimateItemID+"");//SPAN
                        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");//ddl

                        txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value);//.replace(/,/, '');
                        
                        var txtItemTitle = document.getElementById("txtItemTitle_"+ EstimateItemID+"");//TextBox
                        CatalogueData +="EstimateItemID»"+EstimateItemID+"±";
                        CatalogueData +="ProfitMargin»"+ddlProfit.value+"±";
                        CatalogueData +="SubTotal»"+txtSubTotal.value+"±";
                        CatalogueData +="Tax»"+Get_Tax_Value(ddlTax.value)+"±";
                        CatalogueData +="TaxID»"+ddlTax.value+"±";
                        CatalogueData +="ItemTitle»"+txtItemTitle.value+"±";
                        CatalogueData +="EstPriceCatalogueID»"+EstPriceCatalogueID.innerHTML+"§";
                        //----- Estimate Values ------
                        if(q==0)
                        {
                            var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_"+ q +"_"+ EstimateItemID+"");//span
                            CataPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML); //.replace('$', '').replace(/,/, '');
                            CataPrice = roundNumber(CataPrice,2);
                        }
                    }    
                }
                
                AllData += CatalogueData + "µ";
                if(txtItemTitle.value=='')
                {
                    alert('Item Title cannot be Empty ');
                    return false;
                }
                EstValues =  Number(EstValues) + Number(CataPrice);
                EstValues = roundNumber(EstValues,2);
             }
          }
       }       
       
       hidOverallList.value = AllData;
       //--- Estimate Values
       hidEstimateValue.value = EstValues;

       return true;
       
   }

//PRICE CATALOGUE
function CatalogueTaxandProfitOnChange(Percentage, EstimateItemID,type)
{
    for(var q=0;q<4;q++)
    {
        var SpanMarkup = document.getElementById("span_Markup_" + q + "_" +EstimateItemID+"");
        if(SpanMarkup!=null)
        {
            var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + q + "_" + EstimateItemID+"");
            var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + q + "_" + EstimateItemID+"");
            var txtSubTotal = document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID+"");//TextBox
            var SpanTax = document.getElementById("span_Tax_" + q + "_" + EstimateItemID+"");
            var ddlTax = document.getElementById("ddlTax_" + EstimateItemID+"");
            
            var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + q + "_" + EstimateItemID+"");
            var SpanGrossProfit = document.getElementById("span_GrossProfit_" + q + "_" + EstimateItemID+"");
            
            var Taxsummary = document.getElementById("span_Tax_summary_" + q + "_" + EstimateItemID+"");
            var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + q + "_" + EstimateItemID+"");
            var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + q + "_" + EstimateItemID+"");

            var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
            var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
            var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
            var SubTotalValue  = RemoveDollorAndComma(txtSubTotal.value);
            var TaxValue = 0;
            var SellInTax = 0;
            var subValue = 0;
            
            if(type=="profit")
            {
                var profit = Percentage;
                ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit))/100;
                ProfitMarginValue = roundNumber(ProfitMarginValue,2);
                SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;
            
                subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
                subValue = roundNumber(subValue,2);
                txtSubTotal.value = subValue; 
            } 
            else
            {
                subValue = SubTotalValue;
            }
            
            TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
            TaxValue = roundNumber(TaxValue,2);
            SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
            
            SellInTax = Number(TaxValue)+ Number(subValue);
            SellInTax = roundNumber(SellInTax,2);
            SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
            
            var GrossPercent = 0;
            var GrossValue = Number(Markup)+ Number(ProfitMarginValue);
            GrossValue = roundNumber(GrossValue,2);
            
            if(Number(SellInTax)==0)
            {
                SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
            }
            else
            {
                GrossPercent = (Number(Markup)+ Number(ProfitMarginValue))/Number(subValue);
                GrossPercent = roundNumber( (GrossPercent * 100),2);
                SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
            }
            Taxsummary.innerHTML = SpanTax.innerHTML;
            TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
            GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML; 
        }
    }   
}

function CatalogueOnBlur(subValue,EstimateItemID,q)
{
    if(!isNaN(subValue) && subValue!='')
    {
        var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + q + "_" + EstimateItemID+"");
        var profit = document.getElementById("ddlProfit_"+EstimateItemID+"").value;
        var SpanMarkup = document.getElementById("span_Markup_" + q + "_" + EstimateItemID+"");
        var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + q + "_" + EstimateItemID+"");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + q + "_" + EstimateItemID+"");
        var txtSubTotal = document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID+"");//TextBox
        var SpanTax = document.getElementById("span_Tax_" + q + "_" + EstimateItemID+"");
        var ddlTax = document.getElementById("ddlTax_"+EstimateItemID+"");        
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + q + "_" + EstimateItemID+"");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_" + q + "_" + EstimateItemID+"");
        
        var Taxsummary = document.getElementById("span_Tax_summary_" + q + "_" + EstimateItemID+"");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + q + "_" + EstimateItemID+"");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + q + "_" + EstimateItemID+"");
       
        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var SubTotalValue  = RemoveDollorAndComma(txtSubTotal.value);
        var TaxValue = 0;//SpanTax.innerHTML.replace('$','').replace(/,/,'');
        var SellInTax =0;

        ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit))/100;
        ProfitMarginValue = roundNumber(ProfitMarginValue,2);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;        
        
        subValue = RemoveDollorAndComma(subValue);
        
        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value)))/100;
        TaxValue = roundNumber(TaxValue,2);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        
        SellInTax = Number(TaxValue)+ Number(subValue);
        SellInTax = roundNumber(SellInTax,2);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
        
        var GrossPercent = 0;
        var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup),Number(subValue));//Number(Markup)+ Number(ProfitMarginValue);
        if(Number(subValue)==0)
        {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else
        {
            GrossPercent = GrossProfit_Percentage(Number(subValue),Number(GrossValue));//((Number(Markup)+ Number(ProfitMarginValue))/Number(subValue)) * 100;
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";    
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else
    {
        document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID+"").value="0";
    }
}


function Get_Tax_Value(TaxID)
{
    var Array_0 = hid_tax_values.value.split('±'); 
    
    for(var i=0;i<Array_0.length;i++)
    {
        if(Array_0[i]!='')
        {
            var Array_1 = Array_0[i].split('»');
            if(Array_1[0]==TaxID)
            {
                return Array_1[2];
            }
        }
    }
    return 0;
}

function RemoveDollorAndComma(Values_data) 
{
    //var val = Values_data.replace('$', '');

    var val1 = GetCurrencyinRequiredFormate("", true);
    var val = Values_data.replace(val1, '');
    val = val.replace(/,/, '').replace(/,/, '');
    val = val.replace(/,/, '').replace(/,/, '');

    return val;
}