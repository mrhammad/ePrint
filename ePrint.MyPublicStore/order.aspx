<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="ePrint.MyPublicStore.order" MasterPageFile="~/Templates/MasterPageDefault.Master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #h_productCouponCodeDiscount
        {
            padding-right: 5px;
            text-align: right;
            background-color: #F8F7F5;
            border-right: solid 1px #CCC;
        }
    </style>
    <script src="js/cart.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/pdf_preview.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="OrderMain_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitepath%>">
                <asp:Label ID="lbl_home" runat="server" Text="Home"></asp:Label></a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="<%=strSitepath%>account/account<%=FileExtension %>">
                <%=objLanguage.GetLanguageConversion("My_Account") %></a> > <a href="<%=strSitepath%>account/myorder<%=FileExtension %>">
                    <%=objLanguage.GetLanguageConversion("My_order") %></a> >
            <%=objLanguage.GetLanguageConversion("Order_Details") %>
        </div>
        <div id="Order_background">
            <div id="OrderContent_div">
                <div id="Order_heading" class="Header_Background">
                    <strong>
                        <%=objLanguage.GetLanguageConversion("Order_Details") %>
                    </strong>
                </div>
                <div class="clearBoth">
                </div>
                <div id="Order_area" runat="server">
                    <div id="div_orderConfirm">
                        <div class="orderDetails_div">
                            <div class="orderDetails">
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblOrderNo" runat="server"><%=objLanguage.GetLanguageConversion("Order_Reference") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_OrderNo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblname" runat="server"><%=objLanguage.GetLanguageConversion("Name") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblemail" runat="server"><%=objLanguage.GetLanguageConversion("Email") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblUserRefOrderNo" runat="server"></asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_UserRefOrderNo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="divordertitle" class="displayBlock">
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblOrderTitle" runat="server"></asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_OrderTitle" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div id="div_Paymentmode" runat="server" class="orderDetails_left">
                                        <asp:Label ID="lblPayment" runat="server"><%=objLanguage.GetLanguageConversion("Payment_Type") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_Payment" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblOrderDate" runat="server"><%=objLanguage.GetLanguageConversion("Order_Date") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_OrderDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lbldeliverydate" runat="server"></asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_DeliveryDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblStatus" runat="server"><%=objLanguage.GetLanguageConversion("Status")%>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_Status" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div>
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblConsignmentNoteNumber" runat="server"><%=objLanguage.GetLanguageConversion("Consignment_Note_Number") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lbl_ConsignmentNoteNumber" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="Div_CouponCode" runat="server" style="display:none;">
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblCouponCode" runat="server"><%=objLanguage.GetLanguageConversion("Coupon_Code") %>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <asp:Label ID="lblCoupon_Code" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="div_consigneeurl" class="displayNone">
                                    <div class="orderDetails_left">
                                        <asp:Label ID="lblConsigneeurl" runat="server"><%=objLanguage.GetLanguageConversion("Consignee_Url")%>:</asp:Label>
                                    </div>
                                    <div class="orderDetails_right" style="width:295px">
                                        <a id="ancConsigneeurl" target="_blank"></a>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <br />
                            <div>
                                <div id="Order_ShippingAddress" runat="server" class="order_shippingAddress">
                                    <div id="divShippingAddress" runat="server" class="order_Address_header">
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
                        <div class="clearBoth">
                        </div>
                        <div id="orderConfirm_body">
                            <asp:PlaceHolder ID="plhorder" runat="server"></asp:PlaceHolder>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="orderConfirm_footer" style="width: 100%;">
                            <div id="orderConfirm_footer_left">
                                <asp:Label ID="lbl_subTotal" runat="server" Text="Sub total"><%=objLanguage.GetLanguageConversion("Price_ex_Tax_New")%></asp:Label><br />
                                <%--<asp:Label ID="lbl_flatRate" runat="server" Text="Shipping & handling(Flat Rate - Fixed)"></asp:Label><br />--%>
                                <asp:PlaceHolder ID="plhOrdAddOptions" runat="server"></asp:PlaceHolder>
                                <asp:Label ID="lbl_tax" runat="server" Text="Total Tax"><%=objLanguage.GetLanguageConversion("Total_tax")%></asp:Label>
                                <p>
                                    <asp:Label ID="lbl_grandTotal" runat="server" Text="Grand Total"><%=objLanguage.GetLanguageConversion("Grand_Total")%></asp:Label></p>
                            </div>
                            <div id="orderConfirm_footer_right">
                                <asp:Label ID="lbl_subTotal_cost" runat="server" Text="0.00"></asp:Label><br />
                                <%--<asp:Label ID="lbl_flatRate_cost" runat="server" Text="15.00"></asp:Label><br />--%>
                                <asp:PlaceHolder ID="plhOrdAddOptionsPrice" runat="server"></asp:PlaceHolder>
                                <asp:Label ID="lbl_TaxValue" runat="server" Text="0.00"></asp:Label>
                                <p>
                                    <asp:Label ID="lbl_grandTotal_cost" runat="server" Text="0.00"></asp:Label></p>
                            </div>
                            <%-- <div id="orderConfirm_footer_left">
                                <p>
                                    <asp:Label ID="lbl_grandTotal" runat="server" Text="Grand Total"></asp:Label></p>
                            </div>
                            <div id="orderConfirm_footer_right">
                                <p>
                                    <asp:Label ID="lbl_grandTotal_cost" runat="server" Text="0.00"></asp:Label></p>
                            </div>--%>
                        </div>
                        <div class="clearBoth">
                        </div>
                    </div>
                    <div>
                        <div align="center">
                            <div class="clearBoth">
                                &nbsp;
                            </div>
                            <%-- <asp:Button ID="confirmOrder" runat="server" Text="Confirm Order" CssClass="WS_Buttons_Style"
                                OnClick="btnConfirmOrder_onclick" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var CompanyID = '<%=CompanyID %>';
        var IsPPW_SystemName = '<%=IsPPW_SystemName %>';
        var order_billingAddress = document.getElementById("ctl00_ContentPlaceHolder1_order_billingAddress");
        var imagePath = '<%=imagePath %>';
        function IfB2B_System() {
            if (IsPPW_SystemName == "True")
                order_billingAddress.style.display = "none";
        }
        // IfB2B_System();

        function checkordertitledisplay() {
            var isCBOOrderTitle = "<%=isCBOOrderTitle%>";
            if (isCBOOrderTitle == "0") {
                document.getElementById("divordertitle").style.display = 'none';
            }

        }
        checkordertitledisplay();

        var consigneeurl = '<%=consigneeurl %>';
        function checkforconsigneeurl() {

            if (consigneeurl != '') {
                document.getElementById("div_consigneeurl").style.display = "block";
                document.getElementById("ancConsigneeurl").href = consigneeurl;
                document.getElementById("ancConsigneeurl").innerHTML = "Click here to track your Consignment";

            }
            else {
                document.getElementById("div_consigneeurl").style.display = "none";
            }
        }
        checkforconsigneeurl();
        function OrderCouponStyle() {
            var ISCouponCodeEnabled = '<%=ISCouponCodeEnabled %>';
            if (ISCouponCodeEnabled.trim().toLocaleLowerCase() == "true") {
                document.getElementById("orderConfirm_footer_left").style.width = "782px";
            }
        }
    </script>
    <asp:ScriptManager runat="server" ID="SM">
    </asp:ScriptManager>
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
            function openArtworkPopup(CartItemID, OrderItemID, OrderID) {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                oWnd.setUrl('<%=strSitepath %>' + "common/artwork_common.aspx?CartItemID=" + CartItemID + "&OrderItemId=" + OrderItemID + "&from=order&OrderID=" + OrderID);
                oWnd.setSize(600, 300);
                oWnd.center();
                oWnd.show();
            }
        </script>
    </telerik:RadScriptBlock>

    <script type="text/javascript" language="javascript">
        var PDFToURLPath = '<%=PDFToURLPath%>';
        var AccountID = '<%=AccountID %>';      
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
