<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ePrint.MyPublicStore.ShoppingCart" MasterPageFile="~/Templates/MasterPageDefault.Master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="<%=strSitepath%>js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/pdf_preview.js?VN='<%=VersionNumber%>'" type="text/javascript""></script>
    <script type="text/javascript" src="js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        var Order_Deltd_Prod_Msg1 = "<%=Order_Deltd_Prod_Msg1 %>"
        var Order_Deltd_Prod_Msg2 = "<%=Order_Deltd_Prod_Msg2 %>"
        var Order_Deltd_Prod_Msg3 = "<%=Order_Deltd_Prod_Msg3 %>"
        var Order_Deltd_Prod_Msg4 = "<%=Order_Deltd_Prod_Msg4 %>"
        var AccountID = "<%=AccountID %>";        
        var productImagePath = "<%=productImagePath%>";
        var ProductStockManagement = "<%=ProductStockManagement %>";
        var StatusTitle = "<%=StatusTitle %>";
        var Accountsonhold = <%=objLanguage.GetLanguageConversion("Accoutns_On_Hold") %>;
        var jobScreenNameForAlert = "<%=CartJobScreenNameForAlert %>";
        var CartJobNameIsMandatory = "<%=CartJobNameIsMandatory %>";
        var CartJobScreenNameShow = "<%=CartJobScreenNameShow %>";
    </script>
<script type="text/javascript" language="javascript">
    var asyncState = true;
    XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
    XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
        async = asyncState;
        var eventArgs = Array.prototype.slice.call(arguments);
        return this.original_open.apply(this, eventArgs);
    }
</script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="ShoppingcardMain_div" class="contentArea_Background">
        <div id="div_NavigationID" runat="server" class="navigation_div">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <%=objLanguage.GetLanguageConversion("Cart") %>
        </div>
        <asp:HiddenField ID="hdnChecked" runat="server" Value="" />
        <div id="Shoppingcard_background">
            <div id="ShoppingcardContent_div">
                <div id="Shoppingcard_div" runat="server">
                    <div id="top_div">
                        <div id="heading" class="Header_Background">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Shopping_Cart") %>
                            </strong>
                        </div>
                    </div>
                    <div class="clearBoth">
                    </div>
                    <div id="middle_div">
                        <div id="productAdded" class="productAdded displayNone" runat="server">
                            <div id="productAdded_image">
                                <img id="imgSucess" runat="server" alt=" " />
                            </div>
                            <div id="productAdded_sucessMsg">
                                <asp:Label ID="lblSucess" runat="server" Text="No items in cart"></asp:Label>
                            </div>
                        </div>
                        <asp:Label runat="server" ID="lblNotifyGprunDiscount"></asp:Label>
                        <div id="div_ShoppingItems" runat="server">
                            <asp:PlaceHolder ID="plh_CartItems" runat="server"></asp:PlaceHolder>
                        </div>
                        <div id="grandTotal_div" runat="server">
                            <div id="grandTotal" class="grandTotal_Color">
                                <div id="div_grandTotal" runat="server" class="div_grandTotal">
                                    <div class="grandTotal_TopnBotm_Div horizontal_line_B2C">
                                    </div>
                                    <div class="grandTotal_Txt_Div">
                                        <asp:Label ID="lblgrandTotal" runat="server" Text="Grand Total:"><%=objLanguage.GetLanguageConversion("Grand_Total") %>:</asp:Label>
                                    </div>
                                    <div class="grandTotal_Value_Div">
                                        <asp:Label ID="lbl_grandTotal" runat="server" Text="$ 0.00"></asp:Label>
                                    </div>
                                    <div class="grandTotal_TopnBotm_Div horizontal_line_B2C">
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div class="PrceedToChkOutBTN_Div">
                                    <div id="div_CheckOut">
                                        <asp:Button ID="btn_proceedCheckout" runat="server" Text="Proceed to Checkout" CssClass="WS_Buttons_Style"
                                            OnClientClick="javascript:var a=onclick_Checkout();return a;" />
                                    </div>
                                    <div id="div_CheckOutProcess" class="displayNone WS_Buttons_Style">
                                        <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_ItemsLength" runat="server" Value="" />
    <asp:HiddenField ID="hid_finalSave" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalExTax" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalIncTax" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalQty" runat="server" Value="" />
    <asp:HiddenField ID="hid_QuestionLenght" runat="server" />
    <asp:HiddenField ID="hid_MultipleLenght" runat="server" />
    <asp:HiddenField ID="hid_MatrixLenght" runat="server" />
    <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
    <asp:HiddenField ID="hdnCartItemCount" runat="server" Value="0" />
    <asp:HiddenField ID="hdnJobScreenNAmeForAlert" runat="server" Value = "" />
    <asp:HiddenField ID="hid_MultiplePrice" runat="server" Value="0" />
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">

        var CompanyID = '<%=CompanyID %>';
        var productid_new = '<%=productid_new %>';
        var CatalogueName = '<%=CatalogueName %>';
        var NewSessionID = '<%=NewSessionID %>';
        var StoreUserID = '<%=StoreUserID %>';
        var PDFToURLPath='<%=PDFToURLPath%>'
        var OrderKey = '<%=OrderKey %>';
        var isCheckOrderInfoPublic = '<%=isCheckOrderInfoPublic %>';
        var isCheckAddressInfo = '<%=isCheckAddressInfo %>';

        var cntDown = document.getElementById("<%=lblSucess.ClientID %>");
        var hid_ItemsLength = document.getElementById("<%=hid_ItemsLength.ClientID %>");
        var hid_finalSave = document.getElementById("<%=hid_finalSave.ClientID %>");
        var lbl_grandTotal = document.getElementById("<%=lbl_grandTotal.ClientID %>");
        var hid_TotalExTax = document.getElementById("<%=hid_TotalExTax.ClientID %>");
        var hid_TotalIncTax = document.getElementById("<%=hid_TotalIncTax.ClientID %>");
        var hid_TotalQty = document.getElementById("<%=hid_TotalQty.ClientID %>");

        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");
        var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
        var hid_MatrixLenght = document.getElementById("<%=hid_MatrixLenght.ClientID %>");
        var hid_SaveToAdditionalItems = document.getElementById("<%=hid_SaveToAdditionalItems.ClientID %>");
        var productAdded = document.getElementById("<%=productAdded.ClientID %>");
        var hdnCartItemCount = document.getElementById("<%=hdnCartItemCount.ClientID %>");
        var lblNotifyGprunDiscount = document.getElementById("<%=lblNotifyGprunDiscount.ClientID %>");
        var btn_proceedCheckout = document.getElementById("<%=btn_proceedCheckout.ClientID %>");
        var div_ClearCouponCode = document.getElementById("div_ClearCouponCode");
        var div_InvalidCouponCode = document.getElementById("div_InvalidCouponCode");
        var txt_CouponCode = document.getElementById("ctl00_ContentPlaceHolder1_txt_CouponCode");
        var btn_CouponCodeApplay = document.getElementById("ctl00_ContentPlaceHolder1_btn_CouponCodeApply");
        var span_InvalidCouponCode = document.getElementById("ctl00_ContentPlaceHolder1_lblInvalidCouponCode");
        var div_CouponCodeDiscount = document.getElementById("div_CouponCodeDiscount");
        var div_CouponCodeDiscountedAmount = document.getElementById("div_CouponCodeDiscountedAmount");
        var hdnJobScreenNameForAlert = document.getElementById("<%= hdnJobScreenNAmeForAlert.ClientID %>")
        var hid_MultiplePrice = document.getElementById("<%=hid_MultiplePrice.ClientID %>");
        window.onload = function () {
            allowgrouprun_calculations();
        };
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
    <script type="text/javascript" src="<%=strSitepath %>js/cart.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/popup.js?VN='<%=VersionNumber%>'"></script>

    <script type="text/javascript" language="javascript">
        function GetRadWindow()
        {
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


