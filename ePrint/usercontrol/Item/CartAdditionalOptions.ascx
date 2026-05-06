<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartAdditionalOptions.ascx.cs" Inherits="ePrint.usercontrol.Item.CartAdditionalOptions" %>



<style type="text/css">
    
</style>
<div id="div_CartAddOptionID" runat="server" align="left" style="width: 99%; margin: 0px 0px 0px 5px;
    display: block;">
    <div class="only5px">
    </div>
    <asp:PlaceHolder ID="ph_CartAdditional" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="plh_CartItems" runat="server"></asp:PlaceHolder>
    <div style="padding: 5px 100px 5px 5px; text-align: right;">
        <asp:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Onclick"
            Width="65px" Text="Save" />
    </div>
    <div class="onlyempty">
    </div>
    <asp:HiddenField ID="hdn_ddlValue" runat="server" />
    <asp:HiddenField ID="hdn_lblValue" runat="server" />
    <asp:HiddenField ID="hdn_IsFormula" runat="server" />
    <asp:HiddenField ID="hdn_NoOfCartItems" runat="server" />
</div>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/order_item_Summary.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<%--
<script type="text/javascript" language="javascript">

    function Cart_Additional_Price(ID, Formula, IsFormula) {
        document.getElementById("<%=hdn_ddlValue.ClientID %>").value = Formula;
        document.getElementById("<%=hdn_IsFormula.ClientID %>").value = IsFormula;
        javascript: __doPostBack('ctl00$ContentPlaceHolder1$CartAdditionalOption$lnk_CartAdditionOption', '')
    }

</script>--%>
<script type="text/javascript" language="javascript">

    var cnt_CartAdditional = '<%=cnt_CartAdditional %>';
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var Quantity = '<%=OrderedQuantity %>';
    var PriceExcTax = '<%=TotalExGst %>';
    var TotalIncTax = '<%=TotalIncGst %>';
    var SelectedPrice = '<%=SelectedPrice %>';
    var OrderAdditionalTaxPercentage = '<%=OrderAdditionalTaxPercentage %>' // Pradeep
    var hdn_NoOfCartItems = document.getElementById('<%=hdn_NoOfCartItems.ClientID %>');

    for (var i = 0; i < cnt_CartAdditional; i++) {
        Cart_Additional_Price(i, '1');
    }

    //alert("Quantity=" + Quantity)
    //    alert("PriceExcTax=" + PriceExcTax)
    //    alert("TotalIncTax=" + TotalIncTax)

    function Cart_Additional_Price(ID, IsFormula) {
        
        var ddl_CartAdditional = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_ddl_CartAdditional_" + ID + "");
        var lbl_CartAdditional = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_lbl_CartAdditional_" + ID + "");
        var hdnSelectedPrice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnSelectedPrice_CartAdditional_" + ID + "");
        var hdnTotaldPrice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnTotaldPrice_CartAdditional_" + ID + "");
        var hdnAdditionalTaxValue = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnOrderAdditionalTaxValue_CartAdditional_" + ID + "");
        var txt_CartAdditionalmarkup = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_txt_CartAdditionalmarkup_" + ID + "");
        var hdnAdditionalMarkupPrice_CartAdditional = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnAdditionalMarkupPrice_CartAdditional_" + ID + "");
        var lbl_sellingprice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_lbl_sellingprice_" + ID + "");

        var Formula = ddl_CartAdditional.options[ddl_CartAdditional.selectedIndex].value.split('~');

        var Formula1 = Formula[0];

        Formula1 = Formula1.replace('[$TotalQty$]', Number(Quantity)).replace('[$totalqty$]', Number(Quantity)).replace('[$TotalEx.GST$]', Number(PriceExcTax)).replace('[$totalex.GST$]', Number(PriceExcTax)).replace('[$TotalInc.GST$]', Number(TotalIncTax)).replace('[$totalinc.GST$]', Number(TotalIncTax)).replace('[$TotalNo.ofCartItems$]', Number(hdn_NoOfCartItems.value)).replace('[$totalno.ofcartitems$]', Number(hdn_NoOfCartItems.value));

        var cost = 0;
        // by natraj, to get the cost, when asgned...
        var search = Formula1.search('=');
        if (search != -1) {
            Formula1 = Formula1.replace('(', "").replace(')', "");
            var ArrNew = Formula1.split('=');
            cost = eval(ArrNew[1]);
        }
        else {
            cost = eval(Formula1);
        }
        //  cost = eval(Formula1);
        var markup = Number(Formula[1]);
        // hdnSelectedPrice.value = SelectedPrice;
        var selling = 0;
        hdnAdditionalMarkupPrice_CartAdditional.value = markup;
        hdnSelectedPrice.value = cost;
        selling = ((Number(cost) * Number(markup)) / 100) + Number(cost);
        lbl_CartAdditional.value = Eprint_ReturnFinal_Formated_Amount1(CompanyID, UserID, cost, 2, '', false, false, false);
        txt_CartAdditionalmarkup.value = Eprint_ReturnFinal_Formated_Amount1(CompanyID, UserID, markup, 2, '', false, false, false);
        lbl_sellingprice.innerHTML = Eprint_ReturnFinal_Formated_Amount1(CompanyID, UserID, selling, 2, '', false, false, false);
        hdnTotaldPrice.value = selling;
        //By Pradeep
        hdnAdditionalTaxValue.value = (Number(hdnTotaldPrice.value) * Number(OrderAdditionalTaxPercentage) / 100)

    }

    function onPriceOrMarkupChange(number) {
       
        var priceCntrl = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOptions_lbl_CartAdditional_" + number);
        
        var price = Number(priceCntrl.value);
        var markupCntrl = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOptions_txt_CartAdditionalmarkup_" + number);
        var markup = Number(markupCntrl.value);

        var sellingPrice = ((price * markup) / 100) + price;
        var sellingPriceCntrl = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOptions_lbl_sellingprice_" + number);
        sellingPriceCntrl.innerText = sellingPrice;

    }

    function Cart_Additional_Price_onblur(ID, IsFormula) {
        var lbl_CartAdditional = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_lbl_CartAdditional_" + ID + "");
        var lbl_sellingprice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_lbl_sellingprice_" + ID + "");
        var txt_CartAdditionalmarkup = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_txt_CartAdditionalmarkup_" + ID + "");
        var hdnAdditionalMarkupPrice_CartAdditional = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnAdditionalMarkupPrice_CartAdditional_" + ID + "");
        var hdnSelectedPrice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnSelectedPrice_CartAdditional_" + ID + "");
        var hdnTotaldPrice = document.getElementById("ctl00_ContentPlaceHolder1_CartAdditionalOption_hdnTotaldPrice_CartAdditional_" + ID + "");

        var selling = ((Number(lbl_CartAdditional.value) * Number(txt_CartAdditionalmarkup.value)) / 100) + Number(lbl_CartAdditional.value);
        hdnSelectedPrice.value = lbl_CartAdditional.value;
        hdnAdditionalMarkupPrice_CartAdditional.value = txt_CartAdditionalmarkup.value;
        hdnTotaldPrice.value = selling;
        lbl_sellingprice.innerHTML = Eprint_ReturnFinal_Formated_Amount1(CompanyID, UserID, selling, 2, '', false, false, false);
    }
    function call() {
        for (var i = 0; i < cnt_CartAdditional; i++)
            Cart_Additional_Price(i);
    }

    call();

    function Eprint_ReturnFinal_Formated_Amount1(CompanyID, UserID, Amount, Scale, CalculationUnit, IsQuantity, isAddDecimalPlacesToQty, isView) {
        var settingScale;
        if (Scale > 0) {
            settingScale = Scale;
        }
        if (IsQuantity && !isAddDecimalPlacesToQty) {
            return roundNumber_new1(Amount, 0);
        }
        return roundNumber_new1(Amount, settingScale);
    }

    function roundNumber_new1(number, digits) {
        var multiple = Math.pow(10, digits);
        var rndedNum = Math.round(number * multiple) / multiple;
        return rndedNum.toFixed(digits);
    }
    function windowclose(RedirectPath) {
        window.close();
        window.parent.location = RedirectPath;
    }
   

</script>
