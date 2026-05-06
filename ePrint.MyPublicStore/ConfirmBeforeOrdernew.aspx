<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmBeforeOrdernew.aspx.cs" Inherits="ePrint.MyPublicStore.ConfirmBeforeOrdernew" MasterPageFile="~/Templates/MasterPageDefault.Master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <style type="text/css">
        ul, menu, dir
        {
            padding-left: 15px;
        }
        li
        {
            display: list-item;
            text-align: left;
        }
        .b_productDiscount_td
        {
            width: 115px;
            text-align: right;
            padding: 0px 5px 0px 0px;
        }
      </style>
    <script src="/js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="/js/pdf_preview.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        var PaymentStep = '<%=PaymentStep %>';
        var CompanyID = '<%=CompanyID %>';

        var isCheckOrderInfoPublic = '<%=isCheckOrderInfoPublic %>';
        var isCheckAddressInfo = '<%=isCheckAddressInfo %>';
        var isCheckPaymentInfo = '<%=isCheckPaymentInfo %>'
        $(document).ready(function () {
            $("#btnClose_bill").click(function (e) {
                HideDialog();
                e.preventDefault();
            });
        });

        function FourthStep() {
            if (PaymentStep == "true") {
                document.getElementById('FourthStep').className = 'done';
            }
            else {
                document.getElementById('FourthStep').className = 'disabled';
            }
        }

        function ShowDialog() {
            $("#overlay").show();
            $("#dialog").fadeIn(300);
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(300);
        }
    </script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript" src="<%=strSitepath %>js/cart.js?VN='<%=VersionNumber%>'"></script>
    <div id="confirmBfrOrdrnew_MainDiv">
        <div>
            <div id="output">
            </div>
            <div id="overlay" class="web_dialog_overlay_Address">
            </div>
            <div id="dialog" class="web_dialog_Address">
                <table align="center" class="popuptable_Address">
                    <tr>
                        <td class="web_dialog_title_Address">
                            <div id="div_NewAddress">
                                <b>
                                    <%=objLanguage.GetLanguageConversion("Approver_Email")%></b>
                            </div>
                        </td>
                        <td class="align_right" align="right">
                            <a href="#" id="btnClose_bill" title="Close">
                                <img alt="" class="imageclose" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="leftCellNewAdd_table textalignRight">
                            <%=objLanguage.GetLanguageConversion("Approver_Email")%><label id="Label1" class="mandatoryField">
                                *</label>
                        </td>
                        <td class="rightCellNewAdd_table">
                            <asp:TextBox ID="txtaddressLabelBilling" runat="server" CssClass="width-180px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator ID="reqemail" runat="server" ControlToValidate="txtaddressLabelBilling"
                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="CreateAccount"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtaddressLabelBilling"
                                Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"
                                ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnApprEmail_Save" runat="server" Text="Save" class="ApproverEmailBtn x-btnpro Grey main"
                                ValidationGroup="CreateAccount" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="ConfirmBeforeOrder_Page">
            <div id="OrderMain_div" class="contentArea_Background">
                <div class="navigation_div">
                    <a href="<%=strSitepath%>">
                        <asp:Label ID="lbl_home" runat="server"></asp:Label></a>
                    <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
                    <a href="javascript:void(0);">
                        <asp:Label ID="lbl_checkout" runat="server" Text="Check Out" onclick="redirectTo();"> <%=objLanguage.GetLanguageConversion("Checkout")%></asp:Label></a>
                    <asp:Label ID="lblCheckout" Visible="false" runat="server" Text="Check Out"> </asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=">"></asp:Label>
                    Confirm Order
                </div>
                <div id="Order_background">
                    <div id="OrderContent_div">
                        <div class="clearBoth">
                        </div>
                        <div id="wizard" class="swMain">
                            <ul class="anchor">
                                <li id="li_Order" runat="server"><a href="#" class="done">
                                    <%-- <label class="stepNumber">
                                        1</label>--%>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Order_Information")%></small> </span></a>
                                </li>
                                <li id="li_Address" runat="server"><a href="#" class="done">
                                    <%-- <label class="stepNumber">
                                        2</label>--%>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Address_Information")%></small> </span>
                                </a></li>
                                <li id="li_Confirmation" runat="server"><a href="#" class="selected">
                                    <%-- <label class="stepNumber">
                                        3</label>--%>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Order_Confirmation")%></small> </span>
                                </a></li>
                                <li id="li_payment" class="HideArrow" runat="server"><a id="FourthStep" href="#"
                                    class="disabled">
                                    <%-- <label class="stepNumber">
                                        4</label>--%>
                                    <span class="stepDesc"><small>
                                        <%=objLanguage.GetLanguageConversion("Payment_Information")%></small> </span>
                                </a></li>
                            </ul>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="Order_area" runat="server">
                            <div id="div_orderConfirm">
                                <div class="orderDetails_div">
                                    <div class="orderDetails">
                                        <div>
                                            <div class="CheckOutCBOHeader">
                                                <asp:Label ID="lblOrderConfoHeader" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div>
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblname" runat="server"><%=objLanguage.GetLanguageConversion("Name")%>: </asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div>
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblemail" runat="server"><%=objLanguage.GetLanguageConversion("Email")%>:</asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_OrderNo" runat="server">
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblUserRefOrderNo" runat="server"></asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_UserRefOrderNo" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_OrderTitle" runat="server">
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblOrderTitle" runat="server"></asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_OrderTitle" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_PaymentType" runat="server" class="displayNone">
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblPayment" runat="server"><%=objLanguage.GetLanguageConversion("Payment_Type")%>:</asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_Payment" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div>
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblOrderDate" runat="server"><%=objLanguage.GetLanguageConversion("Order_Date")%>:</asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_OrderDate" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_DeliveryRequiredby" runat="server">
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblDeliverydate" runat="server"></asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lbl_DeliveryDate" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                         <div class="clearBoth">
                                        </div>
                                        <div id="DivCouponCode" runat="server" style="display:none;">
                                            <div class="orderDetails_left">
                                                <asp:Label ID="lblCouponCode" runat="server"><%=objLanguage.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width:295px">
                                                <asp:Label ID="lblCoupon_Code" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="paddingTop10">
                                        <div id="shipping_billingaddress" runat="server" class="order_shippingAddress">
                                            <div class="order_Address_header">
                                                <strong>
                                                    <asp:Label ID="lbl_ShippingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label></strong><br />
                                            </div>
                                            <div class="order_Address_content">
                                                <asp:Label ID="lbl_ShippingAddress" runat="server">Delivery Address</asp:Label>
                                            </div>
                                        </div>
                                        <div id="order_billingAddress" runat="server" class="order_billingAddress">
                                            <div class="order_Address_header">
                                                <strong>
                                                    <asp:Label ID="lbl_BliingAddressID" runat="server"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label></strong><br />
                                            </div>
                                            <div class="order_Address_content">
                                                <asp:Label ID="lbl_BliingAddress" runat="server">Invoice Address</asp:Label><br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="orderConfirm_header">
                                    <asp:PlaceHolder ID="plhorder_Header" runat="server"></asp:PlaceHolder>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="orderConfirm_body" style="width:97%">
                                    <asp:PlaceHolder ID="plhorder" runat="server"></asp:PlaceHolder>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="orderConfirm_footer">
                                    <div id="orderConfirm_footer_left">
                                        <asp:Label ID="lbl_subTotal" runat="server" Text="Sub total"><%=objLanguage.GetLanguageConversion("Price_ex_Tax_New")%></asp:Label><br />
                                        <asp:PlaceHolder ID="plhOrdAddOptions" runat="server"></asp:PlaceHolder>
                                        <asp:Label ID="lbl_tax" runat="server" Text="Total Tax"></asp:Label>
                                        <p>
                                            <asp:Label ID="lbl_grandTotal" runat="server" Text="Grand Total"><%=objLanguage.GetLanguageConversion("Grand_Total")%></asp:Label></p>
                                    </div>
                                    <div id="orderConfirm_footer_right">
                                        <asp:Label ID="lbl_subTotal_cost" runat="server" Text="0.00"></asp:Label><br />
                                        <asp:PlaceHolder ID="plhOrdAddOptionsPrice" runat="server"></asp:PlaceHolder>
                                        <asp:Label ID="lbl_TaxValue" runat="server" Text="0.00"></asp:Label>
                                        <p>
                                            <asp:Label ID="lbl_grandTotal_cost" runat="server" Text="0.00"></asp:Label></p>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                            </div>
                            <div>
                                <div align="center">
                                    <div class="clearBoth">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="div_confirmOrder" runat="server" class="displayNone">
                            <div class="orderDetails_div">
                                <div class="confirmBfrOdr_Trms_N_Condn_MainDiv">
                                    <div class="confirmBfrOdr_chk_Trms_N_Condn_Div">
                                        <asp:CheckBox ID="chk_terms_conditions" runat="server" Checked="false" />
                                    </div>
                                    <div class="confirmBfrOdr_lbl_Trms_N_Condn_Div">
                                        <asp:Label ID="lbl_terms_conditions" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div>
                            <div id="div_confirm" runat="server">
                                <div class="div_Confirm_innerdiv">
                                    <div id="div_btnsave11" class="floatLeft paddingTop5">
                                        <asp:Button ID="Button1" runat="server" Text="Back" class="x-btnpro Grey main" OnClientClick="javascript:BackToCheckOut();return false;" />
                                    </div>
                                    <div id="div_btnsaveprocess11" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                    <div id="div_btnsave">
                                        <asp:Button ID="btn_confirm" runat="server" Text="Confirm Order" class="x-btnpro Grey main"
                                            OnClientClick="javascript:return check_terms_conditions();" OnClick="btn_confirm_OnClick" />
                                    </div>
                                    <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                    <%--<div id='div_loadingShipping' style="display: none;">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&aid='<%=AccountID %>'&cid='<%=CompanyID %>'"
                                        AlternateText="Loading" />
                                </div>--%>
                                </div>
                            </div>
                            <div id="div_Payment" runat="server">
                                <div id="div_btnsave4" class="displayBlock floatLeft">
                                    <asp:Button ID="Button2" runat="server" Text="Back" class="x-btnpro Grey main" OnClientClick="javascript:BackToCheckOut();return false;" />
                                </div>
                                <div id="div_btnsaveprocess4" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                                <div id="div_btnsave5" style="margin-left: 4px;" class="displayBlock floatLeft">
                                    <asp:Button ID="btn_PaymentInfo" runat="server" Style="min-width: 90px;" Text="Continue"
                                        class="x-btnpro Grey main" OnClientClick="javascript:return check_terms_conditions();"
                                        OnClick="btn_PaymentInfo_OnClick" />
                                </div>
                                <div id="div_btnsaveprocess5" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                                <div id='div2' class="displayNone">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&aid='<%=AccountID %>'&cid='<%=CompanyID %>'"
                                        AlternateText="Loading" />
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_OrderID" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">

        var IsTerms = '<%=IsTerms %>';
        var IsPPW_SystemName = '<%=IsPPW_SystemName %>';

        var btn_confirm = document.getElementById("<%=btn_confirm.ClientID %>");
        var div_loadingShipping = document.getElementById("div_loadingShipping");
        var chk_terms_conditions = document.getElementById("<%=chk_terms_conditions.ClientID %>");
        var order_billingAddress = document.getElementById("ctl00_ContentPlaceHolder1_order_billingAddress");

        function check_terms_conditions() {

            if (IsTerms == 'true') {
                if (chk_terms_conditions.checked) {
                    btn_confirm.style.display = "none";
                    div_btnsave11.style.display = "none";
                    loadingimg('div_btnsave5', 'div_btnsaveprocess5');
                    return true;
                }
                else {
                    alert('Please tick the box to confirm the order can be placed');
                    return false;
                }
            }
            else if (isCheckPaymentInfo.toLowerCase() == 'true') {
                loadingimg('div_btnsave5', 'div_btnsaveprocess5');
                return true;
            }
            else {
                loadingimg('div_btnsave', 'div_btnsaveprocess');
            }
        }

        function redirectTo() {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = "<%=strSitepath %>" + "checkoutnew" + FileExtension;
            }
            else {
                window.location = "<%=strSitepath%>" + "checkoutnew.aspx";
            }
        }

        function BackToCheckOut() {
            if (isCheckOrderInfoPublic == "false" && isCheckAddressInfo == "false") {
                if (isCheckPaymentInfo.toLowerCase() == 'true') {
                    if (Rewritemodule.toLowerCase() == 'on') {
                        loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                        window.location = "<%=strSitepath %>" + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
                    }
                    else {
                        loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                        window.location = "<%=strSitepath%>" + "shoppingcart.aspx?ID=0&amp;PID=0";
                    }
                }
                else {
                    if (Rewritemodule.toLowerCase() == 'on') {
                        loadingimg('div_btnsave11', 'div_btnsaveprocess11');
                        window.location = "<%=strSitepath %>" + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
                    }
                    else {
                        loadingimg('div_btnsave11', 'div_btnsaveprocess11');
                        window.location = "<%=strSitepath%>" + "shoppingcart.aspx?ID=0&amp;PID=0";
                    }
                }
            }
            else if (isCheckPaymentInfo.toLowerCase() == 'false') {
                if (Rewritemodule.toLowerCase() == 'on') {
                    loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                    window.location = "<%=strSitepath %>" + "checkoutnew" + FileExtension + "?frm=ordrconfrm";
                }
                else {
                    loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                    window.location = "<%=strSitepath%>" + "checkoutnew.aspx?" + "frm=ordrconfrm";
                }
            }
            else {
                if (Rewritemodule.toLowerCase() == 'on') {
                    loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                    window.location = "<%=strSitepath %>" + "checkoutnew" + FileExtension + "?frm=ordrconfrm";
                }
                else {
                    loadingimg('div_btnsave4', 'div_btnsaveprocess4');
                    window.location = "<%=strSitepath%>" + "checkoutnew.aspx?" + "frm=ordrconfrm";
                }
            }
        }
        document.getElementById("wizard").style.visibility = "visible";

        function ShowAlert() {
            alert("Email address missing valid Domain name");
            return false;
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
            var PDFToURLPath = '<%=PDFToURLPath%>';
            var AccountID = '<%=AccountID %>';
            var CompanyID = '<%=CompanyID %>';
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


