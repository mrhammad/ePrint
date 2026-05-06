<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/masterPageDefault.master" AutoEventWireup="true" CodeBehind="ConfirmBeforeOrder.aspx.cs" Inherits="ePrint.WebStore.ConfirmBeforeOrder" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <style type="text/css">
        ul, menu, dir {
            padding-left: 15px;
        }

        li {
            display: list-item;
            text-align: left;
        }
    </style>
    <script src="js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="js/pdf_preview.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="js/default.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        var hid_MultiplePrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_MultiplePrice");
        var CompanyID = '<%=CompanyID %>';
        var PaymentStep = '<%=PaymentStep %>';
        var isCheckPaymentInfo = '<%=isCheckPaymentInfo %>';
        var Please_check_terms_and_conditions = '<%=objLanguage.GetLanguageConversion("Please_check_terms_and_conditions") %>';

        function FourthStep() {
            document.getElementById("ctl00_ContentPlaceHolder1_wizard").style.visibility = "visible";
            if (PaymentStep == "true") {
                document.getElementById('FourthStep').className = 'done';
            }
            else {
                document.getElementById('FourthStep').className = 'disabled';
            }
        }
        function DeliveryCost(StoreUserID) {
            debugger
            var value = document.getElementById("ctl00_ContentPlaceHolder1_ddlTest").value;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_DeliveryCost_Price").innerHTML = Number(value).toFixed(2);
            var stringValue = document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_cost").innerHTML;
            var floatValue = parseFloat(stringValue.replace(/,/g, ''));
            var value1 = floatValue + parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_lbl_TaxValue").innerHTML) + parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_lbl_DeliveryCost_Price").innerHTML);
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_grandTotal_cost").innerHTML = "$" + value1.toFixed(2);
            var selectElement = document.getElementById("ctl00_ContentPlaceHolder1_ddlTest");
            var selectedOption = selectElement.options[selectElement.selectedIndex];
            var selectedOptionText = selectedOption.textContent;
            UpdateDCFinal(value, StoreUserID, selectedOptionText);
        }

    </script>
    <asp:HiddenField ID="hid_MultiplePrice" runat="server" Value="0" />
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script src="js/cart.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <asp:HiddenField ID="hdnDeptID" runat="server" />
    <div id="ConfirmBeforeOrder">
        <div align="center" id="OrderMain_div">
            <div>
                <div align="center" id="Order_background">
                    <div id="OrderContent_div">
                        <div id="Order_heading" class="Header_Background">
                            <strong class="floatLeft">Checkout</strong><%--Confirm Order Details--%>
                        </div>
                        <div id="wizard" runat="server" class="swMain">
                            <ul class="anchor">
                                <li id ="li3" runat="server"><a href="#" class="done CheckOut_HeadingRoundedCorner">
                                    <label id="lblStep3" runat="server" class="stepNumber">
                                        1</label>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Order_Information") %></small> </span>
                                </a></li>
                                <li><a href="#" class="done CheckOut_HeadingRoundedCorner">
                                    <label id="lblStep4" runat="server" class="stepNumber">
                                        2</label>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Address_Information") %></small> </span>
                                </a></li>
                                <li><a href="#" class="selected CheckOut_HeadingRoundedCorner">
                                    <label id="lblStep5" runat="server" class="stepNumber">
                                        3</label>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Order_Confirmation") %></small> </span>
                                </a></li>
                                <li id="li_payment" runat="server"><a id="FourthStep" href="#" class="disabled CheckOut_HeadingRoundedCorner">
                                    <label id="lblStep6" runat="server" class="stepNumber">
                                        4</label>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Payment_Information") %></small> </span>
                                </a></li>
                            </ul>
                        </div>
                        <div id="Order_area" runat="server">
                            <div class="clearTop">
                                <div id="div_orderConfirm">
                                    <div class="orderDetails_div12">
                                        <div class="orderDetails width100p">
                                            <table class="width750px">
                                                <tr id="tr_OrderConfoHeader" runat="server">
                                                    <td colspan="4" class="CheckOutCBOHeader">
                                                        <asp:Label ID="lblOrderConfoHeader" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="orderDetails_left">
                                                            <asp:Label ID="lblOrderDate" runat="server"><%=objLanguage.GetLanguageConversion("Order_Date") %></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td class="lbl_OrderDate_td">
                                                        <div class="orderDetails_right" style="width: 295px">
                                                            <asp:Label ID="lbl_OrderDate" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="orderDetails_Orderfor_left">
                                                            <asp:Label ID="Label7" runat="server"><%=objLanguage.GetLanguageConversion("Ordered_For")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td class="lbl_name_td">
                                                        <div class="orderDetails_right" style="width: 295px">
                                                            <asp:Label ID="lblorderedforname" runat="server"></asp:Label>
                                                            <div id="div_attnfor" class="DisplayNone smallfont floatLeft" runat="server">
                                                                <%=objLanguage.GetLanguageConversion("For_the_attention_of")%><asp:Label ID="lblforattention"
                                                                    CssClass="smallfontgrey" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="paddingTop5">
                                                        <div id="div_OrderTitle" runat="server" class="width100p">
                                                            <div class="orderDetails_left">
                                                                <asp:Label ID="lblOrderTitle" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="paddingTop5">
                                                        <div id="div_OrderTitle1" runat="server" class="width100p">
                                                            <div class="orderDetails_right" style="width: 295px">
                                                                <asp:Label ID="lbl_OrderTitle" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="paddingTop5">
                                                        <div class="orderDetails_left" id="lblemail_div">
                                                            <asp:Label ID="lblemail" runat="server"><%=objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td class="paddingTop5">
                                                        <div class="orderDetails_right" style="width: 295px">
                                                            <asp:Label ID="lblorderedforemail" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="EmptyCell">
                                                    <td>
                                                        <%--please do not comment this empty row : bugid :2321 --%>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                            <div class="clearBoth EmptyCell">
                                            </div>
                                            <div class="floatLeft DisplayInlineBlock orderDetails_detailsdiv_width">
                                                <div id="div_OrderNo" runat="server">
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="lblUserRefOrderNo" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lbl_UserRefOrderNo" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth EmptyCell">
                                                </div>
                                                <div id="div_PaymentType" runat="server">
                                                    <div class="orderDetails_left DisplayNone">
                                                        <asp:Label ID="lblPayment" runat="server"><%=objLanguage.GetLanguageConversion("Payment_Type") %></asp:Label>
                                                    </div>
                                                    <div class="orderDetails_right DisplayNone" style="width: 295px">
                                                        <asp:Label ID="lbl_Payment" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth">
                                                </div>
                                                <div id="div_DeliveryRequiredby" runat="server">
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth EmptyCell">
                                                </div>
                                                <div id="DivCostCenter" runat="server">
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="Label1" runat="server">Cost Centre"</asp:Label>
                                                                                                                
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lblCostcenter" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth EmptyCell">
                                                </div>
                                                <div id="DivCouponCode" runat="server" style="display: none;">
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lblCouponCode" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth EmptyCell">
                                                </div>
                                            </div>
                                            <div id="div_orderedfor" runat="server" class="floatLeft">
                                                <div id="Div7" runat="server">
                                                    <div class="orderDetails_left" id="lblname_div">
                                                        <asp:Label ID="lblname" runat="server"><%=objLanguage.GetLanguageConversion("Ordered_By") %></asp:Label>
                                                        <%-- <%=objLanguage.GetLanguageConversion("Name") %>--%>
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearBoth EmptyCell">
                                                </div>
                                                <div id="Div9" runat="server">
                                                    <div class="orderDetails_Orderfor_left">
                                                        <asp:Label ID="Label9" runat="server"><%=objLanguage.GetLanguageConversion("Email")%></asp:Label>
                                                    </div>
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearBoth">
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <div id="order_billingAddress" runat="server" class="order_billingAddress" style="word-break: break-all">
                                                <div class="order_Address_header paddingBottom5">
                                                    <strong>
                                                        <asp:Label ID="lbl_BliingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Invoice_Address") %></asp:Label></strong><br />
                                                </div>
                                                <div class="order_Address_content paddingTop5">
                                                    <asp:Label ID="lbl_BliingAddress" runat="server">Invoice Address</asp:Label><br />
                                                </div>
                                            </div>
                                            <div id="shipping_billingaddress" runat="server" class="order_shippingAddress paddingTop5" style="word-break: break-all">
                                                <div class="order_Address_header paddingBottom5">
                                                    <strong>
                                                        <asp:Label ID="lbl_ShippingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address") %></asp:Label></strong><br />
                                                </div>
                                                <div class="order_Address_content paddingTop5">
                                                    <asp:Label ID="lbl_ShippingAddress" runat="server">Delivery Address</asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <br />

                                        <div>
                                            <div id="Div6" runat="server" class="order_billingAddress" style="word-break: break-all">
                                                <div class="order_Address_header paddingBottom5">
                                                    <strong><span id="spn_Comments" class="mandatoryField  paddingTop5">Comments</span></strong>
                                                </div>
                                                <div class="order_Address_content paddingTop5">
                                                    <asp:Label ID="lblComments" runat="server"></asp:Label><br />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                    <div id="orderConfirm_header" class="width100p">
                                        <asp:PlaceHolder ID="plhorder_Header" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                    <div id="orderConfirm_body" class="width100p">
                                        <asp:PlaceHolder ID="plhorder" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                    <div id="orderConfirm_footer">
                                        <div id="orderConfirm_footer_left">
                                            <div id="DeliveryCost" style="margin:0px 0px 0px 0px" runat="server">
                                                <asp:Label ID="lbl_Delivery_Method" runat="server" Text="Delivery Method" CssClass="fontBold">Delivery Method</asp:Label><br />
                                                <asp:PlaceHolder ID="PlhDeliveryCost" runat="server"></asp:PlaceHolder>
                                                <asp:dropdownlist runat="server" id="ddlTest"  Width="300">
                                                </asp:dropdownlist><br />
                                            </div>
                                            <asp:Label ID="lbl_subTotal" runat="server" Text="Sub Total" CssClass="fontBold">Total (ex. Tax)</asp:Label><br />
                                            <div id="divOrdAddOptions" runat="server">
                                                <table border="0" cellpadding="0" cellspacing="0" class="width100p">
                                                    <tr>
                                                        <td>
                                                            <asp:PlaceHolder ID="plhOrdAddOptions" runat="server"></asp:PlaceHolder>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="paddingTop5">
                                                <asp:Label ID="lbl_tax" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div id="div3" runat="server" class="horizontal_line_B2B2">
                                            </div>
                                            <div class="floatRight width100p">
                                                <asp:Label ID="lbl_grandTotal" runat="server" Text="Grand Total" CssClass="Grandtotal"><%=objLanguage.GetLanguageConversion("Grand_Total") %></asp:Label>
                                            </div>
                                            <div id="div5" runat="server" class="horizontal_line_B2B2">
                                            </div>
                                        </div>
                                    </div>
                                    <div id="orderConfirm_footer_right">
                                        <div id="DeliveryCostPrice" style="margin : 0px 0px 20px 0px;" runat="server">
                                            <asp:Label ID="lbl_DeliveryCost_Price" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                        <asp:Label ID="lbl_subTotal_cost" runat="server" Text="0.00"></asp:Label><br />
                                        <div>
                                            <asp:PlaceHolder ID="plhOrdAddOptionsPrice" runat="server"></asp:PlaceHolder>
                                        </div>
                                        <div class="paddingTop5">
                                            <asp:Label ID="lbl_TaxValue" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                        <div id="div1" runat="server" class="horizontal_line_B2B2">
                                        </div>
                                        <div>
                                            <asp:Label ID="lbl_grandTotal_cost" runat="server" Text="0.00" CssClass="Grandtotal"></asp:Label>
                                        </div>
                                        <div id="div4" runat="server" class="horizontal_line_B2B2">
                                        </div>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="Div_Back" class="DisplayNone">
                        </div>
                        <div id="div_confirmOrder" runat="server" class="DisplayNone">
                            <div class="orderDetails_div">
                                <div class="floatLeft width100p">
                                    <div id="div_chk_terms_conditions">
                                        <asp:CheckBox ID="chk_terms_conditions" runat="server" Checked="false" />
                                    </div>
                                    <div class="lbl_terms_conditionsDiv">
                                        <div class="floatLeft">
                                            <asp:Label ID="lbl_terms_conditions" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div id="div_confirm" runat="server" class="floatLeft width100p DisplayBlock">
                            <div class="floatLeft width100p clearBottom">
                                <div id="div_btnsave11" class="DisplayBlock floatLeft paddingTop5">
                                    <asp:Button ID="Button1" runat="server" Text="Back" class="x-btnpro Grey main" OnClientClick="javascript:BackToCheckOut();return false;" />
                                </div>
                                <div id="div_btnsaveprocess11" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                                <div id="div_btnsave">
                                    <asp:Button ID="btn_confirm" runat="server" Text="Confirm Order" class="x-btnpro Grey main"
                                        OnClientClick="javascript:return check_terms_conditions();" OnClick="btn_confirm_OnClick"
                                        CausesValidation="true" ValidationGroup="ApproverEmail" />
                                </div>
                                <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                        <div id="div_Payment" runat="server" class="floatLeft width100p DisplayNone marginTop">
                            <div id="div_btnsave4" class="DisplayBlock floatLeft">
                                <asp:Button ID="Button2" runat="server" Text="Back" class="x-btnpro Grey main" OnClientClick="javascript:BackToCheckOut();return false;" />
                            </div>
                            <div id="div_btnsaveprocess4" class="x-btnpro Grey main" align="center">
                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                            <div id="div_btnsave5" class="DisplayBlock floatLeft">
                                <asp:Button ID="btn_PaymentInfo" runat="server" Text="Continue" class="x-btnpro Grey main"
                                    OnClientClick="javascript:return check_terms_conditions();" OnClick="btn_PaymentInfo_OnClick" />
                            </div>
                            <div id="div_btnsaveprocess5" class="x-btnpro Grey main" align="center">
                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                            <div id='div2' class="DisplayNone">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&aid='<%=AccountID %>'&cid='<%=CompanyID %>'"
                                    AlternateText="Loading" />
                            </div>
                        </div>
                    </div>
                    <div class="clearBoth" runat="server" id="DivErr">
                        <p id="ErrParagraph" runat="server"></p>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdn_EstimateID" runat="server" Value="0" />

    </div>
    <script type="text/javascript" language="javascript">

        var IsTerms = '<%=IsTerms %>';
        var IsPPW_SystemName = '<%=IsPPW_SystemName %>';
        var btn_confirm = document.getElementById("<%=btn_confirm.ClientID %>");
        var div_loadingShipping = document.getElementById("div_loadingShipping");
        var chk_terms_conditions = document.getElementById("<%=chk_terms_conditions.ClientID %>");
        var order_billingAddress = document.getElementById("ctl00_ContentPlaceHolder1_order_billingAddress");
        var strSitepath = '<%=strSitepath %>';
        var PDFToURLPath = '<%=PDFToURLPath%>';
        var AccountID = '<%=AccountID%>';

        document.getElementById("ctl00_ContentPlaceHolder1_wizard").style.visibility = "visible";

        function ShowAlert() {
            alert("Email address missing valid Domain name");
            return false;
        }

        function UpdateDCFinal(DeliveryCost, StoreUserID, selectedOptionText) {
            debugger
            AutoFill.Update_deliveryCost(DeliveryCost, StoreUserID, selectedOptionText);
        }

    </script>

    <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Artwork View"
                KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true" Modal="true"
                ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
        <script type="text/javascript">
            function openArtworkPopup(CartItemID, CartID) {

                var oWnd = $find("<%= RadWindow1.ClientID %>");

                oWnd.setUrl('<%=strSitepath %>' + "common/artwork_common.aspx?CartItemID=" + CartItemID + "&CartID=" + CartID + "&from=shoppingcart");
                oWnd.setSize(600, 300);
                oWnd.center();
                oWnd.show();
            }
        </script>
    </telerik:RadScriptBlock>


    <script type="text/javascript" language="javascript">
        function GetRadWindow() {
            var oWindow = null;
            oWindow = $find("<%=ImagePopWindow.ClientID %>");
            return oWindow;
        }
    </script>
    <telerik:RadWindow RenderMode="Lightweight" ID="ImagePopWindow" Title="Image Preview" Height="420px" Width="835px" ResizeMode="NoResize" BackColor="Gray" runat="server" Modal="True" ReloadOnShow="true">
        <ContentTemplate>
            <div class="divTitle">
                <img style="float: right; cursor: pointer" title="Download" src="images/downloadImage.png" onclick="downloadImage_click();" />
            </div>

            <ul runat="server" class="slider div_imagePreview" id="div_imagePreview" style="overflow: hidden; background: #323639;"></ul>
            <div style="margin-top: 15px;">
                <input type="button" id="btn_previous" value="Previous" style="float: left" onclick="btnPrevoius_clicked();" />
                <input type="button" id="btn_next" value="Next" style="float: right" onclick="btnNext_clciked();" />
            </div>
        </ContentTemplate>
    </telerik:RadWindow>

</asp:Content>
