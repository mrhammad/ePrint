<%@ page title="Shopping Cart" language="C#" masterpagefile="~/Templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="shoppingcart.aspx.cs" Inherits="ePrint.WebStore.shoppingcart" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="js/pdf_preview.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="js/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">    
        var CurrencySymbol = '<%=CurrencySymbol%>';
        var AccountID = '<%=AccountID %>';
        var ApprovalSystem = '<%=ApprovalSystem %>';
        var ApprovalType = '<%=ApprovalType %>';
        var CompanyID = '<%=CompanyID %>';
        var Rewritemodule = '<%=RewriteModule %>';
        var strSitepath = '<%=strSitepath %>';
        var UserType = '<%=UserType %>';
        
        var StatusTitle = '<%=StatusTitle %>';
        var IsCampaignEnabled = '<%=IsCampaignEnabled %>';
        var Pdfvalues='<%=Pdfvalues %>';
        var SpendLimitData='<%=SpendLimitData %>';
        var IsSpendLimitEnable = '<%=IsSpendLimitEnable %>';

        var replenish_proceedtocheckout_validation_msg = '<%=objLanguage.GetLanguageConversion("replenish_proceedtocheckout_validation_msg") %>';
        var Please_select_atlease_one_checkbox = '<%=objLanguage.GetLanguageConversion("Please_select_atlease_one_checkbox") %>';
        var You_can_only_order_50_items_at_one_time = '<%=objLanguage.GetLanguageConversion("You_can_only_order_50_items_at_one_time") %>';
        var Warning_Msg_Multiple_Users_Order_during_Checkout = '<%=objLanguage.GetLanguageConversion("Warning_Msg_Multiple_Users_Order_during_Checkout") %>';
        var Campaign_Validator_Cart_Page_Key_During_Checkout = '<%=objLanguage.GetLanguageConversion("Campaign_Validator_Cart_Page_Key_During_Checkout") %>';
        var Campaign_sdeleted_during_Checkout_validator = '<%=objLanguage.GetLanguageConversion("Campaign_sdeleted_during_Checkout_validator") %>';
        var ProductStockManagement = '<%=ProductStockManagement %>';
        var Accountsonhold = '<%#objLanguage.GetLanguageConversion("Accoutns_On_Hold").Replace("'","") %>';
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
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="ShoppingcardMain_div">
        <div id="Shoppingcard_background">
            <div id="ShoppingcardContent_div">
                <div id="Shoppingcard_div" runat="server">
                    <div id="top_div">
                        <table>
                            <tr>
                                <td>
                                    <div id="heading" class="Header_Background">
                                        <strong>
                                            <%#objLanguage.GetLanguageConversion("Shopping_Cart") %>
                                        </strong>
                                    </div>
                                </td>
                                <td>
                                    <div id="productAdded" class="DisplayBlock paddingTop5" runat="server">
                                        <div id="productAdded_image" class="floatLeft">
                                            <img id="imgSucess" runat="server" alt="" />
                                        </div>
                                        <div id="productAdded_sucessMsg">
                                            <asp:Label ID="lblSucess" runat="server" Visible="false" Text="No items in cart"></asp:Label>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:Label runat="server" ID="lblNotifyGprunDiscount"></asp:Label>
                    </div>
                    <div class="clearBoth">
                    </div>
                    <div id="middle_div">
                        <div id="div_popupAction" onmouseover="show();" onmouseout="hide();">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnbDeleteSelected" runat="server" class="divDropdownlist" Text="Delete Selected"
                                            OnClick="lnbDeleteSelected_Click" OnClientClick="javascript:return CheckOne_new('delete','ctl00_ContentPlaceHolder1_hdnChecked','ctl00_ContentPlaceHolder1_hdnCartID');"><%=objLanguage.GetLanguageConversion("Delete_Selected")%>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_ShoppingItems" runat="server">
                            <asp:HiddenField ID="hdnChecked" runat="server" Value="" />
                            <asp:HiddenField ID="hdnSelfChecked" runat="server" Value="" />
                            <asp:HiddenField ID="hdnCartID" runat="server" Value="" />
                            <asp:PlaceHolder ID="plh_CartItems" runat="server"></asp:PlaceHolder>

                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="grandTotal_div" runat="server" class="width100p">
                            <div id="div_grandTotal" runat="server">
                                <div id="div3" runat="server" class="horizontal_line_B2B2">
                                </div>
                                <div id="div_lblgrandTotal">
                                    <div id="innerdiv_lblgrandTotal">
                                        <asp:Label ID="lblgrandTotal" runat="server" CssClass="Grandtotal" Text="Grand Total:"><%#objLanguage.GetLanguageConversion("Grand_Total") %></asp:Label>
                                    </div>
                                </div>
                                <div id="div_GrandTotal_Value">
                                    <asp:Label ID="lbl_grandTotal" runat="server" CssClass="Grandtotal" Text="Grand Total: $ 0.00"></asp:Label>
                                </div>
                                <div id="div1" runat="server" class="horizontal_line_B2B2 floatRight">
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div align="right" id="divProceedBtn" class="clearTop">
                                <div id="div_btnsave" class="DisplayBlock">
                                    <asp:Button ID="btn_proceedCheckout" runat="server" Text="Proceed to Checkout" CssClass="x-btnpro Grey main" />
                                </div>
                                <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                    <img src="<%#strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                                <div id="div_SaveAndStay" style="float: right; padding-right: 5px;" class="DisplayBlock">
                                    <asp:Button ID="btn_SaveAndStay" runat="server" Text="Save & Stay" Style="min-width: 150px;"
                                        OnClientClick="javascript:var a=SaveJobName(); if(a)loadingimg('div_SaveAndStay', 'div_btnsaveprocess3');return a " CssClass="x-btnpro Grey main" />
                                </div>
                                <div id="div_btnsave2" class="DisplayBlock floatLeft">
                                    <asp:Button ID="btn_ContinueShopping" runat="server" Text="Back to Products" CssClass="x-btnpro Grey main" />
                                </div>
                                <div id="div_btnsaveprocess3" style="width: 130px; height: 16px; display: none; float: right;
                                    margin-right: 5px;" class="x-btnpro Grey main" align="center">
                                    <img src="<%#strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                                <div id="div_btnsaveprocess2" class="x-btnpro Grey main" align="center">
                                    <img src="<%#strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0"/>
                                </div>
                            </div>
                            <div class="Div_img_Above_Empty">
                            </div>
                            <div id="Div_img">
                                <asp:Image ID="img_AddtoCart" runat="server" CssClass="DisplayNone" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&aid='<%#AccountID %>'&cid='<%#CompanyID %>'"
                                    AlternateText="Loading" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
     <asp:HiddenField ID="hid_StoreCredit" runat="server" Value="0" />
    <asp:HiddenField ID="hid_ItemsLength" runat="server" Value="" />
    <asp:HiddenField ID="hid_finalSave" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalExTax" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalIncTax" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalQty" runat="server" Value="" />
    <asp:HiddenField ID="hid_QuestionLenght" runat="server" />
    <asp:HiddenField ID="hid_MultipleLenght" runat="server" />
    <asp:HiddenField ID="hid_MatrixLenght" runat="server" />
    <asp:HiddenField ID="hid_SaveToAdditionalItems" runat="server" />
    <asp:HiddenField ID="hdnAllowGroupRun" runat="server" />
    <asp:HiddenField ID="hdnCartItems" runat="server" Value="" />
    <asp:HiddenField ID="hid_TotalNoOfCartItems" runat="server" Value="" />
    <asp:HiddenField ID ="hid_MultiplePrice" runat="server" Value="0" />
    <script type="text/javascript" language="javascript" src="<%#strSitepath %>js/general.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">

      
        var Prod_NoMoreExists_MSG = '<%=Prod_NoMoreExists_MSG %>'
        var Order_Deltd_Prod_Msg1 = '<%=Order_Deltd_Prod_Msg1 %>'
        var Order_Deltd_Prod_Msg2 = '<%=Order_Deltd_Prod_Msg2 %>'
        var Order_Deltd_Prod_Msg3 = '<%=Order_Deltd_Prod_Msg3 %>'
        var Order_Deltd_Prod_Msg4 = '<%=Order_Deltd_Prod_Msg4 %>'
        var Category_ReqApproval_Msg = '<%=Category_ReqApproval_Msg %>';

        var CompanyID = '<%=CompanyID %>';
        var productid_new = '<%=productid_new %>';
        var CatalogueName = '<%=CatalogueName %>';
        var NewSessionID = '<%=NewSessionID %>';
        var StoreUserID = '<%=StoreUserID %>';
        var PDFToURLPath='<%=PDFToURLPath%>'

        var cntDown = document.getElementById("<%=lblSucess.ClientID %>");
        var hid_ItemsLength = document.getElementById("<%=hid_ItemsLength.ClientID %>");
        var hid_finalSave = document.getElementById("<%=hid_finalSave.ClientID %>");
        var lbl_grandTotal = document.getElementById("<%=lbl_grandTotal.ClientID %>");
        var hid_TotalExTax = document.getElementById("<%=hid_TotalExTax.ClientID %>");
        var hid_TotalIncTax = document.getElementById("<%=hid_TotalIncTax.ClientID %>");
        var hid_TotalQty = document.getElementById("<%=hid_TotalQty.ClientID %>");
        var hdnCartItems = document.getElementById("<%=hdnCartItems.ClientID %>");
        var hid_TotalNoOfCartItems = document.getElementById("<%=hid_TotalNoOfCartItems.ClientID %>");

        var hid_QuestionLenght = document.getElementById("<%=hid_QuestionLenght.ClientID %>");
        var hid_MultipleLenght = document.getElementById("<%=hid_MultipleLenght.ClientID %>");
        var hid_MatrixLenght = document.getElementById("<%=hid_MatrixLenght.ClientID %>");
        var hid_SaveToAdditionalItems = document.getElementById("<%=hid_SaveToAdditionalItems.ClientID %>");
        var productAdded = document.getElementById("<%=productAdded.ClientID %>");

        var btn_proceedCheckout = document.getElementById("<%=btn_proceedCheckout.ClientID %>");
        var btn_SaveAndStay = document.getElementById("<%=btn_SaveAndStay.ClientID %>");
        var img_AddtoCart = document.getElementById("<%=img_AddtoCart.ClientID %>");
        var productImagePath = '<%=productImagePath %>';
        var hdnAllowGroupRun = document.getElementById('<%=hdnAllowGroupRun.ClientID %>');
        var lblNotifyGprunDiscount = document.getElementById("<%=lblNotifyGprunDiscount.ClientID %>");
        var txt_CouponCode = document.getElementById("ctl00_ContentPlaceHolder1_txt_CouponCode");
        var btn_CouponCodeApplay = document.getElementById("ctl00_ContentPlaceHolder1_btn_CouponCodeApplay");
        var span_InvalidCouponCode = document.getElementById("ctl00_ContentPlaceHolder1_lblInvalidCouponCode");
        var div_CouponCodeDiscount = document.getElementById("div_CouponCodeDiscount");
        var div_CouponCodeDiscountedAmount = document.getElementById("div_CouponCodeDiscountedAmount");
        var div_ClearCouponCode = document.getElementById("div_ClearCouponCode");
        var jobScreenName = SpecialEncode('<%=CartJobScreenNameForAlert %>');
        var CartJobScreenNameShow = '<%=CartJobScreenNameShow %>';
        var CartJobNameIsMandatory = '<%=CartJobNameIsMandatory%>;'
        var hid_MultiplePrice = document.getElementById("<%=hid_MultiplePrice.ClientID%>");
        var hid_StoreCredit = document.getElementById("<%=hid_StoreCredit.ClientID %>");
        function ValidateOnbaseofAppSystem() {
            alert("You don't have permission to perform this action, Please contact your admin");
            return false;
        }
        window.onload = function () {
           allowgrouprun_calculations();
        };             
    </script>
    <script type="text/javascript" src="<%#strSitepath %>js/cart.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="<%#strSitepath %>js/min.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="<%#strSitepath %>js/popup.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="<%#strSitepath %>js/default.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            var keyCode = (window.event) ? e.which : e.keyCode;
            if (keyCode && keyCode == 13) {
                e.preventDefault();
                return false;
            }
        });
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

                oWnd.setUrl('<%#strSitepath %>' + "common/artwork_common.aspx?CartItemID=" + CartItemID + "&CartID=" + CartID + "&from=shoppingcart");
                oWnd.setSize(600, 300);
                oWnd.center();
                oWnd.show();
            }
            function SaveJobName() {
                var i = 0;
                var cartitems = hdnCartItems.value;
                var cartitemlist;
                var Jobname = "";
                var frm = document.forms[0];
                for (var i = 0; i < frm.length - 1; i++) 
                {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) 
                    {
                        if (!e.disabled) 
                        {
                            if (e.checked) 
                            {
                                cartitemlist= e.id.split("chkEachLine").pop();
                                if (CartJobNameIsMandatory=="True;") 
                                {
                                    txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + cartitemlist + "");
                                    Jobname = Jobname + cartitemlist + "±" + txt_jobName.value + "$";
                                   /*  if (txt_jobName.value != '')
                                    {
                                        Jobname = Jobname + cartitemlist + "±" + txt_jobName.value + "$";
                                    }
                                    else
                                    {
                                        alert(SpecialDecode(jobScreenName)+ ' are mandatory, Please enter '+ SpecialDecode(jobScreenName));
                                        txt_jobName.focus();
                                        return false;
                                    }   */                
                                      
                                }
                                else
                                {
                                    //for (var i = 0; i < cartitemlist.length - 1; i++) {
                                    txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + cartitemlist + "");
                                    Jobname = Jobname + cartitemlist + "±" + txt_jobName.value + "$";
                                }
                            }
                        }
                    }
                }

                AutoFill.Update_JobName(Jobname);
                if ('<%#AccountID %>' == 266) {
                    alert('Reference has been saved');
                }
                else if ('<%#AccountID %>' == 267) {
                    alert('Job/Business card name has been saved');
                }
                else if(CartJobScreenNameShow)
                {
                    alert(SpecialDecode(jobScreenName) +' have been saved ');
                    btn_SaveAndStay.style.display = "block";
                    loadingimg('div_btnsaveprocess3', 'div_SaveAndStay');
                    return false;
                }
                else {
                    btn_SaveAndStay.style.display = "none";
                    return true;
                }
               
            }
                                      
        </script>
    </telerik:RadScriptBlock>

     
      <script type="text/javascript" language="javascript">
          function GetRadWindow()
          {
              var oWindow = null;
              oWindow = $find('ctl00_ContentPlaceHolder1_ImagePopWindow');
            return oWindow;
        }
    </script>
   <telerik:RadWindow  ID="ImagePopWindow" Title="Image Preview" Height="420px" Width="835px" ResizeMode="NoResize" BackColor="Gray" runat="server" Modal="True" ReloadOnShow="true">
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
