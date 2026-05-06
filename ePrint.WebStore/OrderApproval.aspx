<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true"  CodeBehind="OrderApproval.aspx.cs" Inherits="ePrint.WebStore.OrderApproval" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var CompanyID = <%=CompanyID%>;
        var hid_MultiplePrice = document.getElementById("<%= hid_MultiplePrice.ClientID%>");
        function ShowDialog(value) {
            var hdnActionType = document.getElementById('ctl00_ContentPlaceHolder1_hdnActionType');
            hdnActionType.value = value;
            $("#overlay").show();
            $("#dialog").fadeIn(300);
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(300);
        }

        $(document).ready(function () {
            $("#btnClose_bill").click(function (e) {
                HideDialog();
                e.preventDefault();
            });
        });
    </script>
    <asp:HiddenField ID="hid_MultiplePrice" runat="server" Value="0" />
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script src="js/cart.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="OrderApproval">
        <div id="OrderMain_div">
            <div id="divMsg" class="productAdded" runat="server" style="padding-left: 40%; position: absolute;
                margin-top: -15px;">
                <div id="productAdded_image" class="floatLeft">
                    <img id="imgSucess" runat="server" alt="" src="~/images/StoreImages/Ok-icon.png" />
                </div>
                <div id="productAdded_sucessMsg">
                    <asp:Label ID="lblSucess" runat="server" Text="No items in cart"></asp:Label>
                </div>
            </div>
            <div id="Order_background_Outer">
                <div id="Order_background">
                    <div id="OrderContent_div">
                        <div id="Order_heading" class="Header_Background">
                            <strong>Orders Details </strong>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="Order_area" runat="server">
                            <div class="width100p">
                                <div class="orderDetails_div">
                                    <div class="orderDetails1">
                                        <div class="clearBoth">
                                        </div>
                                        <table class="width750px">
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="lblOrderNo" runat="server">Order Reference</asp:Label>
                                                    </div>
                                                </td>
                                                <td class="Order_areaDetailsTD1">
                                                    <div class="orderDetails_right5">
                                                        <asp:Label ID="lbl_OrderNo" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left">
                                                        <asp:Label ID="lblname" runat="server">Ordered For</asp:Label>
                                                    </div>
                                                </td>
                                                <td class="Order_areaDetailsTD2">
                                                    <div class="orderDetails_right" style="width: 295px">
                                                        <asp:Label ID="lbl_name" runat="server"></asp:Label><span id="spnattn" runat="server"
                                                            class="DisplayNone floatLeft smallfont">For the attention of<asp:Label ID="lblatnfor"
                                                                CssClass="smallfontgrey" runat="server"></asp:Label>
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblOrderDate" runat="server">Order Date</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lbl_OrderDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblemail" runat="server">Email</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321 --%>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblOrderTitle" runat="server">Order Title</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lbl_OrderTitle" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        Ordered By
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_Orderedby" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321--%>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblUserRefOrderNo" runat="server">Your Order Number</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lbl_UserRefOrderNo" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblordbyemail" runat="server">Email</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <div class="floatLeft">
                                                            <asp:Label ID="lbl_Orderedbyemail" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="EmptyCell">
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <%--please do not comment this empty row : bugid :2321 --%>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="orderDetails_left OrderDetailsClearTop2">
                                                        <asp:Label ID="lblDelivery" runat="server">Delivery Required By</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right4">
                                                        <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td id="tdlblStatus" runat="server">
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblStatus" runat="server">Status</asp:Label>
                                                    </div>
                                                </td>
                                                <td id="tdStatus" runat="server">
                                                    <div class="orderDetails_right3">
                                                        <div class="floatLeft">
                                                            <asp:Label ID="lbl_Status" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="floatLeft paddingLeft5">
                                                            <asp:Image ImageUrl="images/StoreImages/Reject.png" CssClass="CursorPointer" ID="RejectImage"
                                                                runat="server" Visible="false" />
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="TrCost" runat="server">
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="Label2" runat="server">Cost Centre</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right2" style="width: 205px">
                                                        <asp:Label ID="lblCostcenter" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_left2">
                                                        <asp:Label ID="lblConsignmentNoteNumber" runat="server">Consignment Note Number</asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_ConsignmentNoteNumber" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <div runat="server" id="div_paymentmode" class="DisplayBlock">
                                                        <div class="orderDetails_left2">
                                                            <asp:Label ID="lblPayment" runat="server">Payment Mode</asp:Label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="orderDetails_right3">
                                                        <asp:Label ID="lbl_Payment" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="clearBoth">
                                        </div>
                                        <div id="div_consigneeurl" class="DisplayNone">
                                            <div class="orderDetails_left paddingTop3">
                                                <asp:Label ID="lblConsigneeurl" runat="server">Consignee Url</asp:Label>
                                            </div>
                                            <div class="orderDetails_right" style="width: 295px">
                                                <a id="ancConsigneeurl" target="_blank" class="ColorBlue TextUnderline"></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                    <br />
                                    <div>
                                        <div id="order_billingAddress" class="order_billingAddress" style="word-break: break-all">
                                            <div class="order_Address_header paddingBottom5 paddingTop5">
                                                <strong>
                                                    <asp:Label ID="lbl_BliingAddressID" runat="server">Invoice Address</asp:Label></strong><br />
                                            </div>
                                            <div class="order_Address_content">
                                                <asp:Label ID="lbl_BliingAddress" runat="server" CssClass="line_height20px">Invoice Address</asp:Label><br />
                                            </div>
                                        </div>
                                        <div class="order_shippingAddress" style="word-break: break-all">
                                            <div class="order_Address_header paddingBottom5 paddingTop5">
                                                <strong>
                                                    <asp:Label ID="lbl_ShippingAddressID" runat="server">Delivery Address</asp:Label></strong><br />
                                            </div>
                                            <div class="order_Address_content">
                                                <asp:Label ID="lbl_ShippingAddress" CssClass="line_height20px" runat="server">Delivery Address</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="orderConfirm_header" class="clearBottom">
                                    <table border="0" id="CartItems_table" class="b_productName_table" style="width: 100%;margin-right:70px;">
                                        <tr>
                                            <td id="ActionTd" runat="server" class="ActionTD">
                                                <div id="HeaderCheckbox" runat="server" style="display: none;" class="CheckBoxAlign">
                                                    <div class="floatLeft">
                                                        <input id="checkAll" runat="server" checked="checked" name="checkAll" onclick="CheckAll(this);"
                                                            type="checkbox" />
                                                    </div>
                                                </div>
                                                <div class="PaddingTopWithColor">
                                                </div>
                                            </td>
                                            <td id="OrdRef" runat="server" style="width: auto;">
                                                <div class="clearTopBottom" style="width: 120px;">
                                                    <strong>&nbsp;<%=objLanguage.GetLanguageConversion("Order_Reference")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td style="width: auto;">
                                                <div class="clearTopBottom" style="width: 100px;">
                                                    <strong>&nbsp;<%=objLanguage.GetLanguageConversion("Product_Name")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="productdesc" runat="server" style="width: auto; padding-left: 0.5%;">
                                                <div class="clearTopBottom" style="width: 130px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Product_Description")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td style="width:auto; text-align: center;">
                                                <div class="clearTopBottom" style="width: 110px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Delivery_Date")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="qty" runat="server" style="width: auto; padding-left: 10px; text-align: right;word-break:normal">
                                                <div class="clearTopBottom">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Qty")%></strong>
                                                </div>
                                            </td>
                                            <td id="CampaignSignNumber" runat="server" visible="false" style="width: auto;" align="center">
                                                <div class="clearTopBottom" style="width: 90px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Sign_Number")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="Campaign_Td" runat="server" visible="false" style="width: auto;">
                                                <div class="clearTopBottom" style="width: 110px; margin-left: 10px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Campaign_Name")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="tdStaus" runat="server" style="width: auto; padding-left: 1%; text-align: left;">
                                                <div class="clearTopBottom" style="width:130px">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Status")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="tdApprovedStaus" runat="server" visible="false" style="width:auto; padding-left: 1%;">
                                                <div class="clearTopBottom" style="width: 120px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Approved")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="ItemMaterial" runat="server" style="width: auto; padding-left: 10px;">
                                                <div class="clearTopBottom" style="width: 90px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Item_Material")%>
                                                    </strong>
                                                </div>
                                            </td>
                                            <td id="JobName" runat="server" align="left" style="padding-top: 5px; width: auto;padding-left:10px">
                                                <div id="divJobName" class="Job_NameDiv" style="width: 145px;">
                                                    <%--<strong>&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Job_Name_Details")%>
                                                    </strong>--%>
                                                    <asp:Label runat="server" ID="lblJobName" Style="font-weight:bold;"></asp:Label>
                                                </div>
                                            </td>
                                            <td class="width4p">
                                            </td>
                                            <td align="left" class="width10p" runat="server" id="tdBeUser" visible="false">
                                                <div class="clearTopBottom">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Behalf_of_User")%></strong>
                                                </div>
                                            </td>
                                            <td align="left" class="Job_NameTD" runat="server" id="tdBeDept" visible="false">
                                                <div class="clearTopBottom">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Behalf_of_Department")%></strong>
                                                </div>
                                            </td>
                                            <td id="tdunitprice" runat="server" class="width12p" align="right">
                                                <div class="clearTopBottom" style="width: 85px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Unit_Price")%>
                                                        (<%=comm.GetCurrencyinRequiredFormate("",true)%>) </strong>
                                                </div>
                                            </td>
                                            <td id="td1" runat="server" class="width12p" align="left" style="padding-left:10px">
                                                <div class="clearTopBottom" style="width: 140px;">
                                                    <strong>
                                                        <%=objLanguage.GetLanguageConversion("Tax_Applicable")%></strong>
                                                </div>
                                            </td>
                                            <td id="tdtotalprice" runat="server" class="width12p" align="right">
                                                <div class="clearTopBottom" style="width: 120px;">
                                                    <asp:Label ID="lbltotalprice" runat="server" Style="font-weight:bolder">
                                                        <%=objLanguage.GetLanguageConversion("Total_ex_Tax")%>
                                                        (<%=comm.GetCurrencyinRequiredFormate("",true) %>) 
                                                    </asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <asp:PlaceHolder ID="plhorder" runat="server"></asp:PlaceHolder>
                                        <asp:HiddenField ID="hdnOrderItemID" runat="server" Value="" />
                                    </table>
                                </div>
                                <div class="clearBoth clearBottom">
                                    <table id="orderConfirm_footer_Main" style="width: 100%;" border="0">
                                        <tr>
                                            <td>
                                                <div id="orderConfirm_footer" class="width100p">
                                                    <table border="0" class="width100p">
                                                        <tr>
                                                            <td align="right">
                                                                <div id="orderConfirm_footer_right" style="width: 179px;">
                                                                    <asp:Label ID="lbl_subTotal_cost" runat="server" Text="0.00"></asp:Label><br />
                                                                    <div class="paddingTop5">
                                                                        <asp:PlaceHolder ID="plhOrdAddOptionsPrice" runat="server"></asp:PlaceHolder>
                                                                    </div>
                                                                    <div class="div_Tax paddingTop5">
                                                                        <asp:Label ID="lbl_TaxValue" runat="server" Text="0.00"></asp:Label>
                                                                    </div>
                                                                    <div id="div3" runat="server" class="horizontal_line_B2B2">
                                                                    </div>
                                                                    <div class="lbl_grandTotal_costDiv">
                                                                        <asp:Label ID="lbl_grandTotal_cost" CssClass="Grandtotal" runat="server" Text="0.00"
                                                                            Style="font-size: 15.4px;"></asp:Label>
                                                                    </div>
                                                                    <div id="div4" runat="server" class="horizontal_line_B2B2 floatRight">
                                                                    </div>
                                                                </div>
                                                                <div id="orderConfirm_footer_left">
                                                                    <asp:Label ID="lbl_subTotal" runat="server" CssClass="lbl_subTotal">
                                                                        <%=objLanguage.GetLanguageConversion("Price_ex_Tax_New")%>
                                                                    </asp:Label><br />
                                                                    <div class="paddingTop5">
                                                                        <asp:PlaceHolder ID="plhOrdAddOptions" runat="server"></asp:PlaceHolder>
                                                                    </div>
                                                                    <div class="div_Tax2">
                                                                        <asp:Label ID="lbl_tax" runat="server" CssClass="fontBold" Text="Total Tax"></asp:Label>
                                                                    </div>
                                                                    <div id="div5" runat="server" class="horizontal_line_B2B2">
                                                                    </div>
                                                                    <p>
                                                                        <div class="lbl_grandTotalDiv2" style="padding: 2px 0px 21px 0px;">
                                                                            <asp:Label ID="lbl_grandTotal" runat="server" CssClass="Grandtotal" Text="Grand Total"></asp:Label>
                                                                        </div>
                                                                    </p>
                                                                    <div id="div6" runat="server" class="horizontal_line_B2B2 floatRight">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <div runat="server" id="divButtons" class="DisplayBlock">
                                                                    <div id="DivReject" class="floatLeft clearLeft">
                                                                        <asp:Button ID="btn_Reject" runat="server" Text="Reject" CssClass="x-btnpro Grey main" />
                                                                    </div>
                                                                    <div id="DivRejectloa" style="width: 78px; height: 17px; display: none; display: none;
                                                                        float: left; margin-left: 0px;" class="x-btnpro Grey main" align="center">
                                                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                                    </div>
                                                                    <div id="div_btnApproved" class="floatLeft paddingLeft5">
                                                                        <asp:Button ID="btn_Approve" runat="server" Text="Approve" CssClass="x-btnpro Grey main"
                                                                            OnClick="btn_Approve_Click" />
                                                                    </div>
                                                                    <div id="div_btnApprovedloa" style="width: 78px; height: 17px; display: none; display: none;
                                                                        float: left; margin-left: 5px;" class="x-btnpro Grey main" align="center">
                                                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clearBoth">
                                    </div>
                                </div>
                                <div class="paddingTop5 clearLeft">
                                    <%--    <asp:TextBox ID="txtReason" runat="server" Text="" TextMode="MultiLine" /></div>
                                <div id="divReason" class="paddingTop5 clearLeft DisplayNone ColorRed">
                                    <span id="req_Reason">Please enter Reason for Rejecting the Order</span>
                                </div>--%>
                                    <telerik:RadWindow ID="RadWindow1" Skin="Default" runat="server" Height="210px" Width="450px"
                                        Opacity="100" EnableShadow="true" Top="250px" Left="510px" ShowContentDuringLoad="false"
                                        Behaviors="Close,Move,Reload">
                                        <ContentTemplate>
                                            <div class="disapprove_WindowDiv">
                                                <table border="0" cellpadding="0" cellspacing="0" class="width100p">
                                                    <tr>
                                                        <td class="disapprove_WindowTbl_TD1">
                                                            <asp:Label ID="lblDis" runat="server"></asp:Label>
                                                            <label id="Label4" class="mandatoryField">
                                                            </label>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <asp:TextBox ID="txtReason" runat="server" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                            <div class="Validationfont ColorRed">
                                                                <asp:RequiredFieldValidator ID="RequiredlstDepartment" runat="server" ValidationGroup="Reject"
                                                                    ControlToValidate="txtReason" Display="Dynamic" ErrorMessage="Please Enter Reject Reason">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td class="clearTop">
                                                            <div id="Div_Ok" class="floatLeft">
                                                                <asp:Button ID="btnOk" runat="server" Style="width: 75px; height: 27px;" class="x-btnpro Grey"
                                                                    OnClick="btnOk_Click" OnClientClick="javascript:ValidateReject();" />
                                                            </div>
                                                            <div id="divok_load" style="display: none; display: none; float: left; margin-left: 0px;"
                                                                class="x-btnpro Grey main" align="center">
                                                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                    <div>
                                        <div align="center">
                                            <div class="clearBoth">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnActionType" runat="server" Value="" />
                <script type="text/javascript" language="javascript">

                    var IsPPW_SystemName = '<%=IsPPW_SystemName %>';
                    var order_billingAddress = document.getElementById("order_billingAddress");

                    function IfB2B_System() {
                        if (IsPPW_SystemName == "True")
                            order_billingAddress.style.display = "none";
                    }
           
                </script>
            </div>
        </div>
        <script type="text/javascript">
            function hideHeader() {
                if (typeof header != 'undefined' && header != null) {
                    document.getElementById("header").style.display = "none";
                }
            }

            hideHeader();
        </script>
        <script type="text/javascript">
            function CheckAll(checkAllBox) {
                var frm = document.forms[0];
                var ChkState = checkAllBox.checked;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                    if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                }
            }
            function CheckChanged(id) {
                var frm = document.forms[0];
                var boolAllChecked;
                var Id;
                boolAllChecked = true;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('chkEachLine') != -1)
                        if (!e.disabled) {
                            if (e.checked == false) {
                                boolAllChecked = false;
                                break;
                            }
                        }
                }
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                        if (boolAllChecked == false) {
                            e.checked = false;
                        }
                        else {
                            e.checked = true;
                            break;
                        }
                    }
                }
            }
        </script>
        <script>
            
            function OpenRadwindow(val) {
                var RadPopupwin = $find("<%= RadWindow1.ClientID %>");
                var textval = '';
                textval = val;
                var valid = true;
                var Counter = 0
                
                var frm = document.getElementById("CartItems_table");
                var frmCheckBox = frm.getElementsByTagName('input');
                var Id;
                var CartId;
                var hdnOrderItemID = document.getElementById('<%=hdnOrderItemID.ClientID %>');
                    hdnOrderItemID.value = "";
                    for (i = 0; i < frmCheckBox.length; i++) {
                        e = frmCheckBox[i];
                        if (e.type == 'checkbox' && e.id.indexOf('chkEachLine') != -1) {
                            if (!e.disabled) {
                                if (e.checked) {
                                    Counter = Number(Counter) + 1;
                                    Id = e.id.split("chkEachLine");
                                    hdnOrderItemID.value += Id[1] + ',';
                                }
                            }
                        }
                    }
                

                    if (val == 'Approve') {
                        if (Number(Counter) == 0) {
                            alert("Please check at least one item to Approve");
                            valid = false;
                        }
                        else {
                            loadingimg('div_btnApproved', 'div_btnApprovedloa');
                        }
                    }
                    if (val == 'Reject') {
                        if (Number(Counter) == 0) {
                            alert("Please check at least one item to Reject");
                            valid = false;
                        }
                        else {
                            valid = false;
                            RadPopupwin.show();
                        }
                    }
                    if (valid) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                var textval = '';
                function Validate(val) {
                    textval = val;
                    var Counter = 0
                    var valid = true;
                
                    var frm = document.getElementById("CartItems_table");
                    var frmCheckBox = frm.getElementsByTagName('input');
                    var Id;
                    var CartId;
                    var hdnOrderItemID = document.getElementById('<%=hdnOrderItemID.ClientID %>');
                    hdnOrderItemID.value = "";
                    for (i = 0; i < frmCheckBox.length; i++) {
                        e = frmCheckBox[i];
                        if (e.type == 'checkbox' && e.id.indexOf('chkEachLine') != -1) {
                            if (!e.disabled) {
                                if (e.checked) {
                                    Counter = Number(Counter) + 1;
                                    Id = e.id.split("chkEachLine");
                                    hdnOrderItemID.value += Id[1] + ',';
                                }
                            }
                        }
                    }
                
                    if (val == 'Approve') {
                        if (Number(Counter) == 0) {
                            alert("Please check at least one item to Approve");
                            valid = false;
                        }
                        else {
                            loadingimg('div_btnApproved', 'div_btnApprovedloa');
                        }
                    }
                    if (val == 'Reject') {
                        if (Number(Counter) == 0) {
                            alert("Please check at least one item to Reject");
                            valid = false;
                        }
                    }

                    if (valid) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
        </script>
        <script>
            function ValidateReject() {
                var textBox = document.getElementById("<%=txtReason.ClientID %>");
                if (textBox.value != "") {
                    loadingimg('Div_Ok', 'divok_load')
                }
            }
        </script>
</asp:Content>
