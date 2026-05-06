<%@ page title="" language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="Invoice_Paid_View.aspx.cs" Inherits="ePrint.common.Invoice_Paid_View" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
        rel="stylesheet" />
    <script src="<%=strSitePath%>js/commonloading.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/order_item_Summary.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../../common/swazz_calendar.js?VN='<%=VersionNumber%>'"
        language="javascript"></script>
    <script src="<%=strSitePath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript"></script>
    <link href="<%=strSitePath %>css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .rgExpandCol
        {
            display: none !important;
        }
        
        #test-1
        {
            background-image: none;
            font-weight: bolder;
        }
        
        .rpItem
        {
            border: 1px solid transparent !important;
        }
        .radpanelbar_default .rpout
        {
            border-bottom-width: 1px;
            border-bottom: 1px solid transparent;
        }
        .RadPanelBar_Default div.rpHeaderTemplate, .RadPanelBar_Default a.rpLink
        {
            background-image: none;
            border: 1px solid #6C6C6C;
            background-color: #F2F2F2;
        }
        .RadPanelBar .rpFocused .rpOut, .RadPanelBar a.rpLink:hover .rpOut, .RadPanelBar .rpSelected .rpOut, .RadPanelBar a.rpSelected:hover .rpOut
        {
            border-top-width: 0px;
            background-color: #C1C1C1;
            border-left-width: 0px;
            border-right-width: 0px;
            border-radius: 4px;
            -webkit-border-radius: 4px;
            -khtml-border-radius: 4px;
        }
        
        #ctl00_ContentPlaceHolder1_RadPanelBar1 li a
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="pnlgridAccountingCodes" ChildrenAsTriggers="false" UpdateMode="Conditional"
        RenderMode="Inline" runat="server">
        <ContentTemplate>
            <div id="div_ProgressToInvoice" align="left" style="display: block; border: 0px solid red;
                z-index: 100; width: 97%; height: 50%" align="center">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="center" valign="top">
                            <div id="div_JobStatus" runat="server" align="left" style="width: 100%; margin-top: -13px">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Height="100%" Skin="Default"
                                                ExpandMode="MultipleExpandedItems" CssClass="NewEditStyleForinvoice">
                                                <Items>
                                                    <telerik:RadPanelItem Text="Job Status" Font-Bold="true" Expanded="false" Width="455px"
                                                        CssClass="rounded-ReportTopcorners" Selected="true" Style="display: none;">
                                                        <ContentTemplate>
                                                            <div id="div_ProformaInvoice" runat="server" style="width: 98%">
                                                                <div style="clear: both">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                    <telerik:RadPanelItem Width="455px" Text="Invoice Payment" Expanded="true" Font-Bold="true"
                                                        Value="pnlInvoicePayment" CssClass="rounded-InvoicePaymentwithTopMargin">
                                                        <ContentTemplate>
                                                            <div id="div_invpayment" style="margin-top: 8px; margin-left: 12px">
                                                                <asp:PlaceHolder ID="plhamountpaidinvcreate" runat="server"></asp:PlaceHolder>
                                                                <table cellpadding="0" cellspacing="0" style="width: 100%; float: left">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bglabelforamountpaid" id="div_paymenttext" style="width: 150px;">
                                                                                <%=objLanguage.GetLanguageConversion("Payment")%>
                                                                            </div>
                                                                            <div id="divpaymenttype_module" class="box" style="width: 60%; margin-left: -8px;">
                                                                                <asp:RadioButtonList ID="rdopaymenttype_module" runat="server" onclick="javascript:amountpaidchanges_module();"
                                                                                    RepeatDirection="Horizontal" Style="list-style: center">
                                                                                    <asp:ListItem Text="Infull" Value="0"> </asp:ListItem>
                                                                                    <asp:ListItem Text="Inpart" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="none" Value="2"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div id="divamountpaidshowhide_module" runat="server" style="display: none;">
                                                                                <div class="bglabelforamountpaid" style="width: 150px">
                                                                                    <asp:Label ID="lblamountpaidtextdisp_module" runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="divamounttextbox_module" class="box">
                                                                                    <asp:TextBox ID="txtamtpaid_module" runat="server" Style="text-align: right" onblur="javascript:todecimal_function(this,this.value);"
                                                                                        CssClass="textboxnew" onkeypress="javascript:return onlyNumbers(event);" Width="80px"
                                                                                        autocomplete="off"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div id="PaidYesNo_module" runat="server" style="width: 100%; display: none">
                                                                                <div align="left" style="border: 0px solid black">
                                                                                    <div class="bglabelforamountpaid" style="border: 0px solid black; width: 150px">
                                                                                        <asp:Label ID="lblPaymentmode_module" runat="server" Width="100px"></asp:Label>
                                                                                    </div>
                                                                                    <div id="DivPayment_Dropdown_module" runat="server" class="box" style="margin-left: 1px">
                                                                                        <asp:DropDownList ID="ddl_Paymentmode_module" Width="110px" runat="server" SkinID="onlyDDL">
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                    <div class="box" style="margin-left: 1px">
                                                                                        <span id="spn_PaymentMode_Module" style="width: 105px; display: none;" class="spanerrorMsg">
                                                                                            <%=objLanguage.GetLanguageConversion("Please_select_Payment_Mode")%></span>
                                                                                    </div>
                                                                                    <div id="DivPayment_Value_module" runat="server" class="box">
                                                                                        <asp:Label ID="lblPaymentvalue_module" runat="server"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div align="left">
                                                                                    <div class="bglabelforamountpaid" style="width: 150px">
                                                                                        <asp:Label ID="lblDate_module" runat="server" SkinID="textPad"></asp:Label>
                                                                                    </div>
                                                                                    <div id="DivDate_Text_module" runat="server" class="box" style="margin-left: 1px">
                                                                                        <asp:TextBox ID="txtInvoicePaymentDate_module" Width="110px" runat="server" SkinID="textPad"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="box" style="margin-left: 1px">
                                                                                        <span id="spn_InvoicePaymentDaterfq_module" style="width: 105px; display: none" class="spanerrorMsg">
                                                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Date") %></span>
                                                                                    </div>
                                                                                    <div id="DivDate_Value_module" runat="server" class="box">
                                                                                        <asp:Label ID="lblDatevalue_module" runat="server"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div align="left">
                                                                                    <div class="bglabelforamountpaid" style="width: 150px">
                                                                                        <asp:Label ID="lblNotes_module" runat="server"></asp:Label>
                                                                                    </div>
                                                                                    <div id="DivNotes_Text_module" class="MultileText" style="float: left; margin-top: -3px;
                                                                                        margin-left: -1px">
                                                                                        <asp:TextBox ID="txt_PaymentDetailNotes_module" runat="server" TextMode="MultiLine"
                                                                                            SkinID="textPad_est"></asp:TextBox>
                                                                                    </div>
                                                                                    <div id="DivNotes_Value_module" runat="server" class="box" style="float: left; margin-top: -3px;
                                                                                        width: 100px; display: none">
                                                                                        <asp:Panel ID="pnlNotes_module" runat="server">
                                                                                            <div style="float: left; margin-top: 3px; width: 100px; overflow: auto">
                                                                                                <asp:Label ID="lblNotesValue_module" runat="server" Width="100px"></asp:Label>
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div id="div_CreditCardDetails_module" runat="server" style="display: none; width: 100%;
                                                                                border: 0px solid black">
                                                                                <div>
                                                                                    <div style="float: left; width: 100%;">
                                                                                        <asp:Label ID="lbl_HolderName_module" runat="server" CssClass="bglabelforamountpaid"
                                                                                            Style="width: 150px"></asp:Label>
                                                                                        <div style="float: left; width: 170px; padding-left: 3px" id="div_holderNameText_module">
                                                                                            <asp:TextBox ID="txt_HolderName_module" runat="server" Style="float: left" Width="185px"></asp:TextBox>
                                                                                            <span id="spn_HolderName_module" class="spanerrorMsg" style="display: none; float: left;">
                                                                                                &nbsp;&nbsp;&nbsp;This is a required field</span>
                                                                                        </div>
                                                                                        <div id="div_HolderName_module">
                                                                                            <asp:Label ID="lbl_CardHolderName_module" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div style="border: 0px solid black">
                                                                                    <div style="width: 100%;">
                                                                                        <asp:Label ID="lbl_cardType_module" class="bglabelforamountpaid" Style="width: 150px"
                                                                                            runat="server"></asp:Label>
                                                                                    </div>
                                                                                    <div style="padding-left: 70px; width: 350px; border: 0px solid black" id="div_CardTypeImg_module">
                                                                                        <table style="padding-top: -50px; border: 0px solid black">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rbnVisaID_module" runat="server" GroupName="credit" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <img id="img2" runat="server" alt="Visa" title="Visa" src="~/images/StoreImages/cc_visa_icon.jpg"
                                                                                                        height="20" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rbnMasterCardID_module" runat="server" GroupName="credit" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <img id="img3" runat="server" alt="Master Card" title="Master Card" src="~/images/StoreImages/cc_master_card_icon.jpg"
                                                                                                        height="20" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rbnAmericanID_module" runat="server" GroupName="credit" Style="padding-bottom: 50px" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <img id="img1" runat="server" alt="American Card" title="American Card" src="~/images/StoreImages/cc_amex_icon.jpg"
                                                                                                        height="20" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rbnDiscoverID_module" runat="server" GroupName="credit" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <img id="img4" runat="server" alt="Discover" title="Discover" src="~/images/StoreImages/cc_discover_icon.jpg"
                                                                                                        height="20" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                    <div id="div18">
                                                                                        <asp:Label ID="lbl_CardTypeValue_module" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div>
                                                                                    <div style="width: 100%;">
                                                                                        <asp:Label ID="lbl_cardNumber_module" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                                    </div>
                                                                                    <div style="margin-left: 114px; border: 0px solid black;" id="div_CardNumberText_module">
                                                                                        <div style="float: left; padding-left: 3px; width: 170px">
                                                                                            <asp:TextBox ID="txt_cardNumber_module" runat="server" Style="width: 185px; float: left"></asp:TextBox>
                                                                                            <span id="spn_cardNumber_module" class="spanerrorMsg" style="display: none; float: left;
                                                                                                padding-left: 8px;">Please enter valid card number</span>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="div_CardNumber_module">
                                                                                        <asp:Label ID="lbl_CardNumberValue_module" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div>
                                                                                    <div style="border: 0px solid black">
                                                                                        <div style="width: 100%; border: 0px solid red">
                                                                                            <asp:Label ID="lbl_expDate_module" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                                        </div>
                                                                                        <div style="margin-left: 112px; width: 200px; border: 0px solid green" id="div_MonthYearValue_module">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddl_month_module" runat="server" Style="">
                                                                                                            <asp:ListItem Text="Month" Value="0" Selected="True"></asp:ListItem>
                                                                                                            <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                                                                                            <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                                                                                            <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                                                                                            <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                                                                                            <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                                                                                            <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                                                                                            <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                                                                                            <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                                                                                            <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                                                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td style="padding-left: 15px">
                                                                                                        <asp:DropDownList ID="ddl_year_module" runat="server" Style="">
                                                                                                            <asp:ListItem Text="Year" Value="0" Selected="True"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                                                                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                        <div style="border: 0px solid black">
                                                                                            <div style="margin-left: 180px; border: 0px solid red">
                                                                                            </div>
                                                                                            <span id="spn_ddlmonth_module" class="spanerrorMsg" style="display: none">This is a
                                                                                                required field</span>
                                                                                            <div style="float: left;">
                                                                                                <span id="spn_ddlyear_module" class="spanerrorMsg" style="display: none; width: 185px;
                                                                                                    text-align: left;">This is a required field</span>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="div_MonthYear_module">
                                                                                            <asp:Label ID="lbl_ExpireDate_module" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div>
                                                                                    <div>
                                                                                        <asp:Label ID="lbl_verification_module" runat="server" Text="Verification Number"
                                                                                            Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                                    </div>
                                                                                    <div style="margin-left: 114px;" id="div_VarificationText_module">
                                                                                        <div style="float: left; padding-left: 3px; width: 170px">
                                                                                            <asp:TextBox ID="txt_verification_module" runat="server" MaxLength="4" Style="width: 60px;
                                                                                                float: left;" onkeypress="javascript:return onlyNumbersforVN(event);"></asp:TextBox>
                                                                                            <span id="spn_verification_module" class="spanerrorMsg" style="width: 185px; display: none;
                                                                                                float: left;">Please enter valid varification number</span>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="div_VarificationNumber_module">
                                                                                        <asp:Label ID="lbl_VarificationNumber_module" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                                <div>
                                                                                    <div class="creditCard_left">
                                                                                    </div>
                                                                                </div>
                                                                                <div class="clearBoth">
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                </Items>
                                            </telerik:RadPanelBar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div align="left">
                                                <table style="position: inherit; margin-left: 172px; width: 100%">
                                                    <tr>
                                                        <td style="position: inherit; margin-top: 15px">
                                                            <div id="DivPaddingTop" style="float: left; position: absolute" runat="server">
                                                                <asp:Button ID="BtnContinue" runat="server" OnClick="BtnContinue_onclick" Text="Continue"
                                                                    CssClass="button" OnClientClick="javascript:var b=validate_dateForModule();if(b)loadingimage(this.id,'divContinue');return b;" />
                                                            </div>
                                                            <div id="divContinue" style="display: none;">
                                                                <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--start module 2nd --%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div align="left" style="width: 98%; vertical-align: top; margin-top: -13px;">
                                        <asp:UpdatePanel ID="updEdit" runat="server">
                                            <ContentTemplate>
                                                <div align="left" id="divaddforother" runat="server" style="width: 98%; position: absolute;
                                                    left: 0px;">
                                                    <div align="left">
                                                        <table cellpadding="0" cellspacing="0" style="width: 98%; float: left">
                                                            <tr>
                                                                <td>
                                                                    <div id="divamountpaid" runat="server">
                                                                        <div id="div_invopmnt" runat="server" align="left" style="width: 100%">
                                                                            <asp:PlaceHolder ID="plhamountpaid" runat="server"></asp:PlaceHolder>
                                                                            <div id="divInvDetails" runat="server" align="center" style="padding-left: 12px;
                                                                                padding-right: 5px;">
                                                                                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblInvoiceNo" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                     <%=objLanguage.GetLanguageConversion("invoice_number")%>   
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblinvoicenovalue" Width="150px" runat="server" CssClass="box1" Style="margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblInvoiceDate" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                         <%=objLanguage.GetLanguageConversion("invoice_date")%>
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblInvoiceDatevalue" Width="100px" runat="server" CssClass="box1"
                                                                                                Style="margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblCustomer" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                         <%=objLanguage.GetLanguageConversion("Customer")%>
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblCustomervalue" Width="150px" runat="server" CssClass="box1" Style="margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPaymentTerms" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                         <%=objLanguage.GetLanguageConversion("Payment_Terms")%>
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblPaymentTermsvalue" Width="100px" runat="server" CssClass="box1"
                                                                                                Style="margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblInvAmount" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                         <%=objLanguage.GetLanguageConversion("Invoice_Amount")%>
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblInvAmountvalue" Width="150px" runat="server" CssClass="box1" Style="text-align: left;
                                                                                                margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblOutStanding" Width="150px" runat="server" Text='' CssClass="bglabelforamountpaid">
                                                                         <%=objLanguage.GetLanguageConversion("Outstanding")%>
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblOutStandingvalue" Width="100px" runat="server" CssClass="box1"
                                                                                                Style="text-align: left; margin-top: 4px;">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div style="padding-top: 5px">
                                                                                <div id="divMessage" runat="server" style="display: none; margin-top: 3px; margin-bottom: 3px;"
                                                                                    align="center">
                                                                                    <span style="color: Red">
                                                                                        <%=objLanguage.GetLanguageConversion("No_Payments_Made")%></span>
                                                                                </div>
                                                                                <div id="div_linkclick" runat="server" align="right" style="padding-left: 20px; padding-right: 0px;">
                                                                                    <%-- <asp:Label runat="server" ID="lblrcdpayment" onclick="hideshow(this);" Style="cursor: pointer;
                                                                                text-decoration: underline" Text="Click here to record a Payment">
                                                                            </asp:Label>--%>
                                                                                    <%--   <asp:Label runat="server" ID="lblnewpayment" onclick="hideshowfornewpayment(this);"
                                                                                Style="cursor: pointer; text-decoration: underline" Text="Click here to record a new Payment"
                                                                                Visible="false">
                                                                        
                                                                            </asp:Label>--%>
                                                                                    <asp:LinkButton ID="lblnewpayment" runat="server" Style="text-decoration: underline;
                                                                                        margin-right: 0px;" ForeColor="#10357F" OnClientClick="javascript:hideshowAddEdit();slideIt('divaddforother');return false;">
                                                                                        <span id="spnlnk" runat="server" class="normaltext" style="font-size: 11px; color: #10357F;">
                                                                                        </span>
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <asp:UpdatePanel ID="radgrid" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div id="divrecordpayment" align="center" runat="server" style="display: none; margin-top: 5px">
                                                                                        <div>
                                                                                            <div style="padding: 5px 5px 0px 10px; width: 100%;" align="left">
                                                                                                <div style="width: 100%;">
                                                                                                    <telerik:RadGrid ID="RadGrid2" runat="server" OnItemDataBound="OnItemDataBound_RadGrid2"
                                                                                                        PagerStyle-Visible="true" PagerStyle-AlwaysVisible="true" Height="196px" AllowSorting="false"
                                                                                                        HeaderStyle-Font-Bold="true" enablelinqexpressions="false" ShowFooter="True"
                                                                                                        Skin="RadGrid_Eprint_Skin" EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin"
                                                                                                        AutoGenerateColumns="False" HorizontalAlign="Center" Width="100%">
                                                                                                        <MasterTableView ShowFooter="true" CommandItemDisplay="None" Dir="LTR" Frame="Border"
                                                                                                            TableLayout="Auto" CurrentResetPageIndexAction="SetPageIndexToFirst" DataKeyNames="ID"
                                                                                                            AutoGenerateColumns="False" ExpandCollapseColumn-Display="false">
                                                                                                            <Columns>
                                                                                                                <telerik:GridTemplateColumn UniqueName="a" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="90px" Wrap="false" />
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                                                                                    <HeaderTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:Label ID="Label2" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Date")%></asp:Label>
                                                                                                                        </div>
                                                                                                                    </HeaderTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <div style="float: left; width: 90px; overflow: hidden" align="left">
                                                                                                                            <asp:LinkButton ID="lnkdate" Width="90px" runat="server" Style="text-decoration: none;
                                                                                                                                cursor: default" OnCommand="lnkbtnEdit_Click" ForeColor="Black" CommandArgument='<%#Eval("id")%>'>
                                                                                                                                <asp:Label runat="server" ID="lblGDate" CssClass="GV_Row"></asp:Label>
                                                                                                                            </asp:LinkButton>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                </telerik:GridTemplateColumn>
                                                                                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="mode" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="90px" Wrap="false" />
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                                                                                    <FooterStyle HorizontalAlign="Left" Width="90px" BackColor="Transparent" />
                                                                                                                    <HeaderTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:Label ID="Label1" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Mode")%></asp:Label>
                                                                                                                        </div>
                                                                                                                    </HeaderTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <div>
                                                                                                                            <div style="float: left; width: 90px; overflow: hidden">
                                                                                                                                <asp:LinkButton ID="lnkmode" Width="90px" runat="server" Style="text-decoration: none;
                                                                                                                                    cursor: default" ForeColor="Black" OnCommand="lnkbtnEdit_Click" CommandArgument='<%#Eval("id")%>'>
                                                                                                                                    <asp:Label runat="server" ID="lblMode" Text='<%#Eval("PaymentModeValue") %>' CssClass="GV_Row"></asp:Label>
                                                                                                                                </asp:LinkButton>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <div>
                                                                                                                            <span style="color: Black; font-weight: bold;">
                                                                                                                                <%=objLanguage.GetLanguageConversion("Total_paid")%>:</span>
                                                                                                                        </div>
                                                                                                                    </FooterTemplate>
                                                                                                                </telerik:GridTemplateColumn>
                                                                                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="amount" ItemStyle-HorizontalAlign="Right"
                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                    <HeaderStyle HorizontalAlign="Right" Width="90px" Wrap="false" />
                                                                                                                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                                                                                                                    <FooterStyle HorizontalAlign="Right" Width="90px" BackColor="Transparent" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:LinkButton ID="lnkamt" Width="90px" runat="server" Style="text-decoration: none;
                                                                                                                                cursor: default" ForeColor="Black" OnCommand="lnkbtnEdit_Click" CommandArgument='<%#Eval("id")%>'>
                                                                                                                                <asp:Label ID="lblAmount" CssClass="GV_Row" runat="server"></asp:Label>
                                                                                                                            </asp:LinkButton>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:Label ID="TextBox2" runat="server" CssClass="GV_Row"></asp:Label>
                                                                                                                        </div>
                                                                                                                    </FooterTemplate>
                                                                                                                </telerik:GridTemplateColumn>
                                                                                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="Left"
                                                                                                                    UniqueName="b">
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="180px" Wrap="false" />
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />
                                                                                                                    <HeaderTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:Label ID="Label4" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Notes")%></asp:Label>
                                                                                                                        </div>
                                                                                                                    </HeaderTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <div>
                                                                                                                            <asp:LinkButton ID="lnknote" Width="180px" runat="server" Style="text-decoration: none;
                                                                                                                                cursor: default" ForeColor="Black" OnCommand="lnkbtnEdit_Click" CommandArgument='<%#Eval("id")%>'>
                                                                                                                                <asp:Label ID="lblNotes" CssClass="GV_Row" ToolTip='<%#Eval("Notes")%>' runat="server"></asp:Label>
                                                                                                                            </asp:LinkButton>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                </telerik:GridTemplateColumn>
                                                                                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="45px" Wrap="false" />
                                                                                                                    <ItemStyle VerticalAlign="Middle" Width="40px" />
                                                                                                                    <HeaderTemplate>
                                                                                                                        <div style="float: left">
                                                                                                                            <asp:Label ID="lblAction" Text="Action" runat="server"><%=objLanguage.GetLanguageConversion("Action")%></asp:Label></div>
                                                                                                                    </HeaderTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <div style="float: left; width: 40px; overflow: hidden;">
                                                                                                                            <%-- <asp:ImageButton ID="imgbtnEdit" OnCommand="imgbtnEdit_Click" ImageUrl="../images/Edit.gif"
                                                                                                                                ToolTip="Edit" Width="13px" Height="13px" runat="server" CommandArgument='<%#Eval("id")%>' />--%>
                                                                                                                            <asp:ImageButton ID="imgbtnDelete" ImageUrl="../images/delete.gif" ToolTip="Delete"
                                                                                                                                Width="13px" Height="13px" runat="server" OnCommand="imgbtnDelete_Click" OnClientClick="Javascript:return DeletePaymentHistory()"
                                                                                                                                CommandArgument='<%#Eval("id")%>' />
                                                                                                                            <asp:ImageButton ID="imgView" ImageUrl="../images/viewall.gif" ToolTip="View Details"
                                                                                                                                Width="13px" Height="13px" runat="server" OnCommand="lnkbtnview_Click" CommandArgument='<%#Eval("id")%>' />
                                                                                                                            <asp:HiddenField ID="hdnEstID" runat="server" Value='<%#Eval("EstimateID")%>' />
                                                                                                                            <%-- OnClientClick="javascript:slideItForView('divaddforother');return false;"--%>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                </telerik:GridTemplateColumn>
                                                                                                            </Columns>
                                                                                                        </MasterTableView>
                                                                                                        <ClientSettings Scrolling-AllowScroll="true" Scrolling-ScrollHeight="145" AllowColumnsReorder="false"
                                                                                                            AllowRowsDragDrop="false">
                                                                                                            <ClientEvents />
                                                                                                            <Scrolling ScrollHeight="145" UseStaticHeaders="true" SaveScrollPosition="true" />
                                                                                                        </ClientSettings>
                                                                                                    </telerik:RadGrid>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <div id="divpaymentradio" runat="server" style="display: none; margin-top: 25px;
                                                                                margin-left: 5px;">
                                                                                <div id="div_NewPaymnethdng" runat="server" style="margin-top: 5px; margin-bottom: 10px;">
                                                                                    <asp:Label ID="lblheader" runat="server" CssClass="headerText"><%=objLanguage.GetLanguageConversion("New_Payment")%></asp:Label>
                                                                                </div>
                                                                                <div class="bglabelforamountpaid" style="width: 150px">
                                                                                    <%=objLanguage.GetLanguageConversion("Payment")%>
                                                                                </div>
                                                                                <div id="divpaymenttype" class="box" style="width: 50%; margin-left: -8px;">
                                                                                    <asp:RadioButtonList ID="rdopaymenttype" runat="server" onclick="javascript:amountpaidchanges();"
                                                                                        RepeatDirection="Horizontal" Style="list-style: center">
                                                                                        <asp:ListItem Text="Infull" Value="0"> </asp:ListItem>
                                                                                        <asp:ListItem Text="Inpart" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="none" Value="2"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                            </div>
                                                                            <div id="divamountpaidshowhide" runat="server" style="display: none;">
                                                                                <div class="bglabelforamountpaid" style="width: 150px">
                                                                                    <asp:Label ID="lblamountpaidtextdisp" runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="divamounttextbox" class="box">
                                                                                    <asp:TextBox ID="txtamtpaid" runat="server" Style="text-align: right" CssClass="textboxnew"
                                                                                        autocomplete="off" Width="80px" onblur="javascript:todecimal_function(this,this.value);"
                                                                                        onkeypress="javascript:return onlyNumbers(event);"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hdntxtamtpaid" runat="server" Value="" />
                                                                                    <asp:HiddenField ID="hdnAmtpaidforedit" runat="server" Value="" />
                                                                                    <%--onchange="Amountpaidvalidation(this.value);"--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="PaidYesNo" runat="server" style="width: 100%; display: none; margin-left: 5px;">
                                                                        <div align="left" style="border: 0px solid black">
                                                                            <div class="bglabelforamountpaid" style="border: 0px solid black; width: 150px">
                                                                                <asp:Label ID="lblPaymentmode" runat="server" Width="100px"></asp:Label>
                                                                            </div>
                                                                            <div id="DivPayment_Dropdown" runat="server" class="box" style="margin-left: 1px">
                                                                                <asp:DropDownList ID="ddl_Paymentmode" Style="width: 110px;" runat="server" SkinID="onlyDDL">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="box" style="margin-left: 1px">
                                                                                <span id="spn_PaymentMode" style="width: 105px; display: none;" class="spanerrorMsg">
                                                                                    <%=objLanguage.GetLanguageConversion("Please_select_Payment_Mode")%></span>
                                                                            </div>
                                                                            <div id="DivPayment_Value" runat="server" class="box">
                                                                                <asp:Label ID="lblPaymentvalue" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabelforamountpaid" style="width: 150px">
                                                                                <asp:Label ID="lblDate" runat="server" SkinID="textPad"></asp:Label>
                                                                            </div>
                                                                            <div id="DivDate_Text" runat="server" class="box" style="margin-left: 1px">
                                                                                <asp:TextBox ID="txtInvoicePaymentDate" Width="110px" runat="server" SkinID="textPad"></asp:TextBox>
                                                                            </div>
                                                                            <div class="box" style="margin-left: 1px">
                                                                                <span id="spn_InvoicePaymentDaterfq" style="width: 105px; display: none" class="spanerrorMsg">
                                                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Date") %></span>
                                                                            </div>
                                                                            <div id="DivDate_Value" runat="server" class="box">
                                                                                <asp:Label ID="lblDatevalue" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabelforamountpaid" style="width: 150px">
                                                                                <asp:Label ID="lblNotes" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div id="DivNotes_Text" runat="server" class="MultileText" style="float: left; margin-top: -3px;
                                                                                margin-left: -1px">
                                                                                <asp:TextBox ID="txt_PaymentDetailNotes" runat="server" TextMode="MultiLine" SkinID="textPad_est"></asp:TextBox>
                                                                            </div>
                                                                            <div id="DivNotes_Value" runat="server" class="box" style="float: left; margin-top: -3px;
                                                                                width: 100px; display: none">
                                                                                <asp:Panel ID="pnlNotes" runat="server">
                                                                                    <div style="float: left; margin-top: 3px; width: 100px; overflow: auto">
                                                                                        <asp:Label ID="lblNotesValue" runat="server" Width="100px"></asp:Label>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="div_OdrPaymentDetails" runat="server" style="width: 100%; display: none;
                                                                        margin-left: 5px;">
                                                                        <div align="left">
                                                                            <div class="bglabel" style="width: 150px">
                                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Label ID="lblCardHoldersName" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabel" style="width: 150px">
                                                                                <asp:Label ID="Label5" runat="server" SkinID="textPad"></asp:Label>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Label ID="lblCardType" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabel" style="float: left; width: 150px">
                                                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Label ID="lblCardNumber" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabel" style="float: left; width: 150px">
                                                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Label ID="lblExpDate" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabel" style="float: left; width: 150px">
                                                                                <asp:Label ID="lblverficationnotext" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Label ID="lblVerficationNo" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="div_CreditCardDetails" runat="server" style="display: none; width: 100%;
                                                                        margin-left: 5px; border: 0px solid black">
                                                                        <div>
                                                                            <div style="float: left; width: 100%;">
                                                                                <asp:Label ID="lbl_HolderName" runat="server" CssClass="bglabelforamountpaid" Style="width: 150px"></asp:Label>
                                                                                <div style="float: left; width: 170px; padding-left: 3px" id="div_holderNameText"
                                                                                    runat="server">
                                                                                    <asp:TextBox ID="txt_HolderName" runat="server" Style="float: left" Width="185px"></asp:TextBox>
                                                                                    <span id="spn_HolderName" class="spanerrorMsg" style="display: none; float: left;">&nbsp;&nbsp;&nbsp;This
                                                                                        is a required field</span>
                                                                                </div>
                                                                                <div id="div_HolderName" runat="server">
                                                                                    <asp:Label ID="lbl_CardHolderName" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                        <div style="border: 0px solid black">
                                                                            <div style="width: 100%;">
                                                                                <asp:Label ID="lbl_cardType" class="bglabelforamountpaid" Style="width: 150px" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div style="padding-left: 70px; width: 350px; border: 0px solid black" id="div_CardTypeImg"
                                                                                runat="server">
                                                                                <table style="padding-top: -50px; border: 0px solid black">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="rbnVisaID" runat="server" GroupName="credit" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <img id="imgVisaCard" runat="server" alt="Visa" title="Visa" src="~/images/StoreImages/cc_visa_icon.jpg"
                                                                                                height="20" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="rbnMasterCardID" runat="server" GroupName="credit" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <img id="imgMasterCard" runat="server" alt="Master Card" title="Master Card" src="~/images/StoreImages/cc_master_card_icon.jpg"
                                                                                                height="20" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="rbnAmericanID" runat="server" GroupName="credit" Style="padding-bottom: 50px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <img id="imgAmericanCard" runat="server" alt="American Card" title="American Card"
                                                                                                src="~/images/StoreImages/cc_amex_icon.jpg" height="20" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="rbnDiscoverID" runat="server" GroupName="credit" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <img id="imgDiscoverCard" runat="server" alt="Discover" title="Discover" src="~/images/StoreImages/cc_discover_icon.jpg"
                                                                                                height="20" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div id="div_CardType" runat="server">
                                                                                <asp:Label ID="lbl_CardTypeValue" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                        <div>
                                                                            <div style="width: 100%;">
                                                                                <asp:Label ID="lbl_cardNumber" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                            </div>
                                                                            <div style="margin-left: 114px; border: 0px solid black" id="div_CardNumberText"
                                                                                runat="server">
                                                                                <div style="float: left; padding-left: 3px; width: 170px">
                                                                                    <asp:TextBox ID="txt_cardNumber" runat="server" Style="width: 185px; float: left"></asp:TextBox>
                                                                                    <span id="spn_cardNumber" class="spanerrorMsg" style="display: none; float: left;">Please
                                                                                        enter valid card number</span>
                                                                                </div>
                                                                            </div>
                                                                            <div id="div_CardNumber" runat="server">
                                                                                <asp:Label ID="lbl_CardNumberValue" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                        <div>
                                                                            <div style="border: 0px solid black">
                                                                                <div style="width: 100%; border: 0px solid red">
                                                                                    <asp:Label ID="lbl_expDate" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                                </div>
                                                                                <div style="margin-left: 112px; width: 200px; border: 0px solid green" id="div_MonthYearValue"
                                                                                    runat="server">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddl_month" runat="server" Style="">
                                                                                                    <asp:ListItem Text="Month" Value="0" Selected="True"></asp:ListItem>
                                                                                                    <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                                                                                    <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                                                                                    <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                                                                                    <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                                                                                    <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                                                                                    <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                                                                                    <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                                                                                    <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                                                                                    <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                                                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td style="padding-left: 15px">
                                                                                                <asp:DropDownList ID="ddl_year" runat="server" Style="">
                                                                                                    <asp:ListItem Text="Year" Value="0" Selected="True"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                                <div style="border: 0px solid black">
                                                                                    <div style="margin-left: 180px; border: 0px solid red">
                                                                                    </div>
                                                                                    <span id="spn_ddlmonth" class="spanerrorMsg" style="display: none">This is a required
                                                                                        field</span>
                                                                                    <div style="float: left;">
                                                                                        <span id="spn_ddlyear" class="spanerrorMsg" style="display: none; width: 185px; text-align: left;">
                                                                                            This is a required field</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="div_MonthYear" runat="server">
                                                                                    <asp:Label ID="lbl_ExpireDate" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                        <div>
                                                                            <div>
                                                                                <asp:Label ID="lbl_verification" runat="server" Text="Verification Number" Style="width: 150px"
                                                                                    CssClass="bglabelforamountpaid"></asp:Label>
                                                                            </div>
                                                                            <div style="margin-left: 114px;" id="div_VarificationText">
                                                                                <div style="float: left; padding-left: 3px; width: 170px">
                                                                                    <asp:TextBox ID="txt_verification" runat="server" MaxLength="4" Style="width: 60px;
                                                                                        padding-left: 3px; float: left;" onkeypress="javascript:return onlyNumbersforVN(event);"></asp:TextBox>
                                                                                    <span id="spn_verification" class="spanerrorMsg" style="display: none; float: left;">
                                                                                        Please enter valid varification number</span>
                                                                                </div>
                                                                            </div>
                                                                            <div id="div_VarificationNumber" runat="server">
                                                                                <asp:Label ID="lbl_VarificationNumber" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                        <div>
                                                                            <div class="creditCard_left">
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearBoth">
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="upaddedit" runat="server">
                                            <ContentTemplate>
                                                <div id="divaddEdit" runat="server" style="width: 98%; display: none; right: 0px;
                                                    position: absolute;">
                                                    <asp:Button ID="imgback" runat="server" CssClass="button" Style="padding-left: -10px;
                                                        margin-bottom: -15px; margin-left: -1px;" Text="Back" ToolTip="Back to Payment Record History"
                                                        OnClientClick="javascript:slidehistory('divaddEdit');return false;" />
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%; float: left">
                                                        <tr>
                                                            <td>
                                                                <div id="divPaymentModeaddEdit" runat="server" style="margin-top: 25px">
                                                                    <div id="divPMTitle" runat="server" style="margin-top: 5px; margin-bottom: 10px;">
                                                                        <asp:Label ID="lbl_NewPaymentHeadre" runat="server" CssClass="headerText"><%=objLanguage.GetLanguageConversion("New_Payment")%></asp:Label>
                                                                    </div>
                                                                    <div id="divEditPayment" runat="server" style="margin-top: 5px; margin-bottom: 10px;">
                                                                        <asp:Label ID="lbl_Editpaymentgeader" runat="server" CssClass="headerText"><%=objLanguage.GetLanguageConversion("Edit_Payment")%></asp:Label>
                                                                    </div>
                                                                    <div class="bglabelforamountpaid" style="width: 150px">
                                                                        <%=objLanguage.GetLanguageConversion("Payment")%>
                                                                    </div>
                                                                    <div id="divPaymentforAddEdit" class="box" style="width: 50%; margin-left: -8px;">
                                                                        <asp:RadioButtonList ID="rdopaymenttypeforaddedit" runat="server" onclick="javascript:amountpaidchanges_AddEdit();"
                                                                            RepeatDirection="Horizontal" Style="list-style: center">
                                                                            <asp:ListItem Text="Infull" Value="0"> </asp:ListItem>
                                                                            <asp:ListItem Text="Inpart" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="none" Value="2"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                                <div id="divamtpaidAddEdit" runat="server">
                                                                    <div class="bglabelforamountpaid" style="width: 150px">
                                                                        <asp:Label ID="lblamountpaidtextaddEdit" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div id="divamttxtaddEdit" class="box">
                                                                        <asp:TextBox ID="txtAmtpaidAddedit" runat="server" Style="text-align: right" CssClass="textboxnew"
                                                                            autocomplete="off" Width="80px" onblur="javascript:todecimal_function(this,this.value);"
                                                                            onkeypress="javascript:return onlyNumbers(event);"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtamtpaidAddedit" runat="server" Value="" />
                                                                        <asp:HiddenField ID="hdnAmtpaidaddedit" runat="server" Value="" />
                                                                        <asp:HiddenField ID="hdntxtvalue" runat="server" Value="" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div id="PaidYesNo_Add" runat="server" style="width: 100%;">
                                                                    <div align="left" style="border: 0px solid black">
                                                                        <div class="bglabelforamountpaid" style="border: 0px solid black; width: 150px">
                                                                            <asp:Label ID="lblPaymentmode_Add" runat="server" Width="100px"></asp:Label>
                                                                        </div>
                                                                        <div id="DivPayment_Dropdown_Add" runat="server" class="box" style="margin-left: 1px">
                                                                            <asp:DropDownList ID="ddl_Paymentmode_Add" Style="width: 110px;" runat="server" SkinID="onlyDDL">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="box" style="margin-left: 1px">
                                                                            <span id="spn_PaymentMode_Add" style="width: 190px; display: none;" class="spanerrorMsg">
                                                                                <%=objLanguage.GetLanguageConversion("Please_select_Payment_Mode")%></span>
                                                                        </div>
                                                                        <div id="DivPayment_Value_Add" runat="server" class="box">
                                                                            <asp:Label ID="lblPaymentvalue_Add" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bglabelforamountpaid" style="width: 150px">
                                                                            <asp:Label ID="lblDate_Add" runat="server" SkinID="textPad"></asp:Label>
                                                                        </div>
                                                                        <div id="DivDate_Text_Add" runat="server" class="box" style="margin-left: 1px;">
                                                                            <asp:TextBox ID="txtInvoicePaymentDate_Add" Width="110px" runat="server" SkinID="textPad"></asp:TextBox>
                                                                            <%-- <span id="spn_InvoicePaymentDate_Add" style="width: 105px; display: none" class="spanerrorMsg">
                                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Date") %></span>--%>
                                                                        </div>
                                                                        <div class="box" style="margin-left: 1px">
                                                                            <span id="spn_InvoicePaymentDate_Add" style="width: 105px; display: none" class="spanerrorMsg">
                                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Date") %></span>
                                                                        </div>
                                                                        <div id="DivDate_Value_Add" runat="server" class="box">
                                                                            <asp:Label ID="lblDatevalue_Add" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bglabelforamountpaid" style="width: 150px">
                                                                            <asp:Label ID="lblNotes_Add" runat="server"></asp:Label>
                                                                        </div>
                                                                        <div id="DivNotes_Text_Add" runat="server" class="MultileText" style="float: left;
                                                                            margin-top: -3px; margin-left: 1px">
                                                                            <asp:TextBox ID="txt_PaymentDetailNotes_Add" runat="server" TextMode="MultiLine"
                                                                                SkinID="textPad_est" Width="200px" Height="60px"></asp:TextBox>
                                                                        </div>
                                                                        <div id="DivNotes_Value_Add" runat="server" class="box" style="float: left; margin-top: -3px;
                                                                            width: 10px; display: none">
                                                                            <asp:Panel ID="pnlNotes_Add" runat="server">
                                                                                <div style="float: left; margin-top: 3px; width: 100px; overflow: auto">
                                                                                    <asp:Label ID="lblNotesValue_Add" runat="server" Width="100px"></asp:Label>
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div id="div_CreditCardDetails_Add" runat="server" style="display: none; width: 100%;
                                                                    border: 0px solid black">
                                                                    <div>
                                                                        <div style="float: left; width: 100%;">
                                                                            <asp:Label ID="lbl_HolderName_Add" runat="server" CssClass="bglabelforamountpaid"
                                                                                Style="width: 150px"></asp:Label>
                                                                            <div style="float: left; width: 170px; padding-left: 4px" id="div_holderNameText_Add"
                                                                                runat="server">
                                                                                <asp:TextBox ID="txt_HolderName_Add" runat="server" Style="float: left" Width="185px"></asp:TextBox>
                                                                                <span id="spn_HolderName_Add" class="spanerrorMsg" style="display: none; float: left;">
                                                                                    &nbsp;&nbsp;&nbsp;This is a required field</span>
                                                                            </div>
                                                                            <div id="div_HolderName_Add" runat="server">
                                                                                <asp:Label ID="lbl_CardHolderName_Add" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                    <div style="border: 0px solid black">
                                                                        <div style="width: 100%;">
                                                                            <asp:Label ID="lbl_cardType_Add" class="bglabelforamountpaid" Style="width: 150px"
                                                                                runat="server"></asp:Label>
                                                                        </div>
                                                                        <div style="padding-left: 70px; width: 350px; border: 0px solid black" id="div_CardTypeImg_Add"
                                                                            runat="server">
                                                                            <table style="padding-top: -50px; border: 0px solid black">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbnVisaID_Add" runat="server" GroupName="credit" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <img id="imgVisaCard_Add" runat="server" alt="Visa" title="Visa" src="~/images/StoreImages/cc_visa_icon.jpg"
                                                                                            height="20" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbnMasterCardID_Add" runat="server" GroupName="credit" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <img id="imgMasterCard_Add" runat="server" alt="Master Card" title="Master Card"
                                                                                            src="~/images/StoreImages/cc_master_card_icon.jpg" height="20" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbnAmericanID_Add" runat="server" GroupName="credit" Style="padding-bottom: 50px" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <img id="imgAmericanCard_Add" runat="server" alt="American Card" title="American Card"
                                                                                            src="~/images/StoreImages/cc_amex_icon.jpg" height="20" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbnDiscoverID_Add" runat="server" GroupName="credit" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <img id="imgDiscoverCard_Add" runat="server" alt="Discover" title="Discover" src="~/images/StoreImages/cc_discover_icon.jpg"
                                                                                            height="20" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div id="div_CardType_Add" runat="server">
                                                                            <asp:Label ID="lbl_CardTypeValue_Add" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                    <div>
                                                                        <div style="width: 100%;">
                                                                            <asp:Label ID="lbl_cardNumber_Add" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                        </div>
                                                                        <div style="margin-left: 114px; border: 0px solid black" id="div_CardNumberText_Add"
                                                                            runat="server">
                                                                            <div style="float: left; padding-left: 4px; width: 170px">
                                                                                <asp:TextBox ID="txt_cardNumber_Add" runat="server" Style="width: 185px; float: left"></asp:TextBox>
                                                                                <span id="spn_cardNumber_Add" class="spanerrorMsg" style="display: none; float: left;">
                                                                                    Please enter valid card number</span>
                                                                            </div>
                                                                        </div>
                                                                        <div id="div_CardNumber_Add" runat="server">
                                                                            <asp:Label ID="lbl_CardNumberValue_Add" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                    <div>
                                                                        <div style="border: 0px solid black">
                                                                            <div style="width: 100%; border: 0px solid red">
                                                                                <asp:Label ID="lbl_expDate_Add" runat="server" Style="width: 150px" CssClass="bglabelforamountpaid"></asp:Label>
                                                                            </div>
                                                                            <div style="margin-left: 114px; width: 200px; border: 0px solid green" id="div_MonthYearValue_Add"
                                                                                runat="server">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddl_month_Add" runat="server" Style="">
                                                                                                <asp:ListItem Text="Month" Value="0" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                                                                                <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                                                                                <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                                                                                <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                                                                                <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                                                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="padding-left: 15px">
                                                                                            <asp:DropDownList ID="ddl_year_Add" runat="server" Style="">
                                                                                                <asp:ListItem Text="Year" Value="0" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                                                                                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                                                                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                                                                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                                                                <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                                                                                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div style="border: 0px solid black">
                                                                                <div style="margin-left: 180px; border: 0px solid red">
                                                                                </div>
                                                                                <span id="spn_ddlmonth_Add" class="spanerrorMsg" style="display: none">This is a required
                                                                                    field</span>
                                                                                <div style="float: left;">
                                                                                    <span id="spn_ddlyear_Add" class="spanerrorMsg" style="display: none; width: 185px;
                                                                                        text-align: left;">This is a required field</span>
                                                                                </div>
                                                                            </div>
                                                                            <div id="div_MonthYear_Add" runat="server">
                                                                                <asp:Label ID="lbl_ExpireDate_Add" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                    <div>
                                                                        <div>
                                                                            <asp:Label ID="lbl_verification_Add" runat="server" Text="Verification Number" Style="width: 150px"
                                                                                CssClass="bglabelforamountpaid"></asp:Label>
                                                                        </div>
                                                                        <div style="margin-left: 114px;" id="div_VarificationText_Add">
                                                                            <div style="float: left; padding-left: 4px; width: 170px">
                                                                                <asp:TextBox ID="txt_verification_Add" runat="server" MaxLength="4" Style="width: 60px;
                                                                                    padding-left: 3px; float: left;" onkeypress="javascript:return onlyNumbersforVN(event);"></asp:TextBox>
                                                                                <span id="spn_verification_Add" class="spanerrorMsg" style="display: none; float: left;">
                                                                                    Please enter valid varification number</span>
                                                                            </div>
                                                                        </div>
                                                                        <div id="div_VarificationNumber_Add" runat="server">
                                                                            <asp:Label ID="lbl_VarificationNumber_Add" runat="server" Style="margin-left: 5px;"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                    <div>
                                                                        <div class="creditCard_left">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearBoth">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div id="divbtnrecord" align="left" runat="server" style="display: none; width: 100%;
                                                                    border: 0px solid;">
                                                                    <table>
                                                                        <tr>
                                                                            <div id="Div1" style="margin-right: 25px;" runat="server">
                                                                                <td>
                                                                                    <div style="float: left;">
                                                                                        &nbsp;</div>
                                                                                    <div id="div_btnmain" style="float: left; margin-left: 160px; border: 0px solid black">
                                                                                        <div id="div_btnrecord" style="float: left; margin-left: -5px; vertical-align: bottom">
                                                                                            <asp:Button ID="btnRecord" runat="server" Text="Record" CssClass="button" OnClick="BtnRecord_onclick"
                                                                                                OnClientClick="javascript:var a=validate_date_Add();if(a) loadingimage(this.id,'div_btnrecordprocess'); return a;" />
                                                                                            <asp:HiddenField ID="hdnEstimateIDforUpdate" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdntotsellingpriceforUpdate" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdnoutstangimgforupdate" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdnpresentvalueforupdate" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdnbtnvalue" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdnpaymenttypeforupdate" runat="server" Value="" />
                                                                                            <asp:HiddenField ID="hdnPTfordelete" runat="server" Value="" />
                                                                                        </div>
                                                                                        <div id="div_btnrecordprocess" style="display: none">
                                                                                            <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div style="float: left; width: 5px">
                                                                                        &nbsp;
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <div id="div_recordclosemain" style="margin-right: 150px; margin-top: 0px; margin-left: -14px;">
                                                                                        <div id="div2" style="float: left; vertical-align: top">
                                                                                            <asp:Button ID="btnRecordNclose" runat="server" Text="Record & Continue" CssClass="button"
                                                                                                OnClick="BtnRecord_onclick" OnClientClick="javascript:var a=validate_date_Add();if(a) loadingimage(this.id,'div_recordcloseprocess'); return a;" />
                                                                                        </div>
                                                                                        <div id="div_recordcloseprocess" style="display: none;">
                                                                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div style="clear: both">
                                                                                    </div>
                                                                                </td>
                                                                            </div>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div id="divUpdateMain" align="left" runat="server" style="display: none; width: 100%;
                                                                    border: 0px solid; margin-top: 0px; margin-left: 150px">
                                                                    <table id="tblbtnupdate" runat="server" align="left" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="float: left;">
                                                                                    &nbsp;</div>
                                                                                <div id="div_btnupdate" style="margin-left: 16px; margin-top: 0px;">
                                                                                    <div id="div4" style="float: left; margin-left: -5px; vertical-align: top">
                                                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_onclick"
                                                                                            OnClientClick="javascript:var a=validate_date_Add();if(a) loadingimage(this.id,'divbtnupdateimg'); return a;" />
                                                                                    </div>
                                                                                    <div id="divbtnupdateimg" style="display: none">
                                                                                        <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                                    </div>
                                                                                </div>
                                                                                <div style="clear: both">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="divview" runat="server" style="width: 98%; display: none; right: 0px; position: absolute;">
                                                    <asp:Button ID="imgbackforview" runat="server" CssClass="button" Style="padding-left: -5px;
                                                        margin-left: 3px;" Text="Back" ToolTip="Back to Payment Record History" OnClientClick="javascript:slideView('divview');return false;" />
                                                    <div class="clearBoth" style="margin-top: 12px;">
                                                    </div>
                                                    <fieldset>
                                                        <legend id="lgheader" runat="server"></legend>
                                                        <table cellpadding="0" cellspacing="0" style="width: auto; float: left">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNVHoldername" Text='' runat="server" CssClass="bglabelforamountpaid"
                                                                        Style="width: 150px;"><%=objLanguage.GetLanguageConversion("Card_Holder_Name")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNVHoldervalue" runat="server" Style="margin: 0 0 2px; vertical-align: middle;
                                                                        float: left; font-size: 11px; padding: 5px;">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNVCardtype" Text='' runat="server" CssClass="bglabelforamountpaid"
                                                                        Style="width: 150px"><%=objLanguage.GetLanguageConversion("Card_Type")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNVCardtypeValue" Style="margin: 0 0 2px; vertical-align: middle;
                                                                        float: left; font-size: 11px; padding: 5px;" runat="server">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNVCardno" Text='' runat="server" CssClass="bglabelforamountpaid"
                                                                        Style="width: 150px"><%=objLanguage.GetLanguageConversion("Card_Number")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNVCardnoValue" Style="margin: 0 0 2px; vertical-align: middle;
                                                                        float: left; font-size: 11px; padding: 5px;" runat="server">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNVExpirationdate" Text='' runat="server" CssClass="bglabelforamountpaid"
                                                                        Style="width: 150px"><%=objLanguage.GetLanguageConversion("Expiration_Date")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <div style="margin: 0 0 2px; vertical-align: middle; float: left; font-size: 11px;
                                                                        padding: 5px;">
                                                                        <asp:Label ID="lblNVExpirationdatevalue" runat="server">
                                                                        </asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNVVerNo" Text='' runat="server" CssClass="bglabelforamountpaid"
                                                                        Style="width: 150px"><%=objLanguage.GetLanguageConversion("Verification_Number")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNVVerNoValue" Style="margin: 0 0 2px; vertical-align: middle; float: left;
                                                                        font-size: 11px; padding: 5px;" runat="server">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div align="left" style="width: 100%; border: 0px solid">
                                            <div style="float: left;">
                                                &nbsp;</div>
                                            <div id="div_main" style="float: left; margin-left: 37%; border: 0px solid black">
                                                <div id="DivBtnPay" runat="server" style="float: left; margin-left: -44px; margin-bottom: 5px;
                                                    display: none;">
                                                    <asp:Button ID="BtnPay" runat="server" Text="Record Payment" CssClass="button" OnClick="BtnPay_onclick"
                                                        OnClientClick="javascript:var a=validate_dateForMainView();if(a) loadingimage(this.id,'div_btnestimateprocess'); return a;" />
                                                </div>
                                                <div id="div_btnestimateprocess" style="display: none">
                                                    <img src="<%=strImagepath%>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; display: none">
                                                <input type="button" value="Cancel" class="button" style="width: 65px" onclick="javascript:hideDiv1('hide')return false;" />
                                            </div>
                                            <div style="float: left; width: 5px">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div id="div_lnkNotPaid" runat="server" style="display: none; float: left; border: 0px solid">
                                            <asp:LinkButton ID="lnkNotPaid" runat="server" OnClick="Onclick_lnkNotPaid" Style="text-decoration: underline;"></asp:LinkButton>
                                            <div class="only5px">
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
                <telerik:RadWindow ID="RadWindow1" runat="server" Skin="Forest" Behaviors="Close, Move"
                    Modal="true" Width="440" Height="385" EnableEmbeddedSkins="false">
                    <ContentTemplate>
                    </ContentTemplate>
                </telerik:RadWindow>
                <%-- <telerik:RadWindowManager EnableShadow="false" ID="RadWindow1" DestroyOnClose="true"
                    Opacity="100" runat="server" Width="440" Height="385" Modal="false" OnClientClose="OnClientClose"
                    Behaviors="Close,Move,Reload,Resize">
                </telerik:RadWindowManager>--%>
                <asp:Label ID="lblviewnote" runat="server" CssClass="smallgraytext"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnHeader" runat="server" Value="" />
    <asp:HiddenField ID="hdnEstimatIds" runat="server" Value="0" />
    <asp:HiddenField ID="hdnEstimateID" runat="server" Value="0" />
    <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">
        var Ispaidenable = '<%=Ispaidenable %>';
        var hdnHeader = document.getElementById("<%=hdnHeader.ClientID%>");
        var DivNotes_Value = document.getElementById("<%=DivNotes_Value.ClientID%>");
        var div_lnkNotPaid = document.getElementById("<%=div_lnkNotPaid.ClientID%>");
        var div_CreditCardDetails = document.getElementById("<%=div_CreditCardDetails.ClientID%>");
        var hdnEstimateID = document.getElementById("<%=hdnEstimateID.ClientID%>");
        var hdnPaymentMode = document.getElementById("<%=hdnPaymentMode.ClientID%>");
        var lblPaymentvalue = document.getElementById("<%=lblPaymentvalue.ClientID%>");
        var TotalInvoiceSellingPrice = '<%=TotalInvoiceSellingPrice %>';
        var OutStandingAmount = '<%=OutStandingAmount %>';
        var ModuleType = '<%=ModuleType %>';
        var AddorEdit = '<%=AddorEdit %>';
        var NewEdit = '<%=NewEdit %>';
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var EditPaymentMode = '<%=EditPaymentMode%>';
    </script>
    <script type="text/javascript">

        var panelBar;
        var panelBarProductsTab;
        var multiPage;

        function onLoad(sender) {

            panelBar = sender;
            panelBarProductsTab = panelBar.get_items().getItem(0);
            multiPage = panelBar.get_items().getItem(0).findControl("RadMultiPage1");
        }

        function onItemClicked(sender, eventArgs) {

            if (!panelBarProductsTab.get_selected()) {
                panelBarProductsTab.expand();
                panelBarProductsTab.select();
            }

            var pageView = multiPage.get_pageViews().getPageView(
                         eventArgs.get_item().get_index());

            pageView.set_selected(true);
        }

        function showSpecialOffers() {

            var oWnd = $find("<%= RadWindow1.ClientID %>");
            oWnd.set_visibleStatusbar(false);
            oWnd.show();
        }

        function stopPropagation(e) {

            e.cancelBubble = true;

            if (e.stopPropagation)
                e.stopPropagation();
        }
    </script>
    <script language="javascript" type="text/javascript">

        function validate_date() {

            CheckFinal = false;
            flag = false;
            var DateFormat = '<%=DateFormat%>';
            var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>")
            var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
            var txtamtvalue = document.getElementById("<%= txtamtpaid.ClientID %>").value;
            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");

            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {
                        document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtamtpaid.ClientID %>").value;
                        if (document.getElementById("<%= hdntxtamtpaid.ClientID %>").value == "0.00") {
                            alert('Please enter amount grater then 0');
                            document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0.00";
                            flag = false;
                            return false;
                        }
                        else {
                            flag = true;
                        }
                    }
                    else if (options[i].value == "1") {
                        if (txtamtvalue == '0.00') {
                            alert('Please enter amount grater then 0');
                            document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0.00";
                            flag = false;
                            return false;
                        }
                        else {
                            flag = true;
                        }
                    }
                }
            }

            if (flag == true) {
                if (txtInvoicePaymentDate == '') {
                    document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block";
                    CheckFinal = true;
                }
                else {
                    document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
                }

                if (ValidateForm(txtInvoicePaymentDate, 'spn_InvoicePaymentDaterfq', DateFormat) == false) {
                    CheckFinal = true;
                }

                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function validate_dateForMainView() {

            CheckFinal = false;
            flag = false;
            var DateFormat = '<%=DateFormat%>';
            var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>")
            var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
            var txtamtvalue = document.getElementById("<%= txtamtpaid.ClientID %>").value;
            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");

            //            for (var i = 0; i < options.length; i++) {
            //                if (options[i].type == "radio" && options[i].checked) {
            //                    if (options[i].value == "0") {
            //                        document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtamtpaid.ClientID %>").value;
            //                        if (document.getElementById("<%= hdntxtamtpaid.ClientID %>").value == "0.00") {
            //                            alert('Please enter amount grater then 0');
            //                            document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0.00";
            //                            flag = false;
            //                            return false;
            //                        }
            //                        else {
            //                            flag = true;
            //                        }
            //                    }
            //                    else if (options[i].value == "1") {
            //                        if (txtamtvalue == '0.00') {
            //                            alert('Please enter amount grater then 0');
            //                            document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0.00";
            //                            flag = false;
            //                            return false;
            //                        }
            //                        else {
            //                            flag = true;
            //                        }
            //                    }
            //                }
            //            }

            //            if (flag == true) {
            var ddlPayment = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "0") {
                document.getElementById("spn_PaymentMode").style.display = "block";
                flag = false;
                return false;
            }
            else {
                document.getElementById("spn_PaymentMode").style.display = "none";
                flag = true;
            }
            //            }


            if (flag == true) {
                if (txtInvoicePaymentDate == '') {
                    document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block";
                    CheckFinal = true;
                }
                else {
                    document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
                    if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDaterfq', DateFormat) == false) {
                        CheckFinal = true;
                    }
                }

                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function validate_dateForModule() {

            CheckFinal = false;
            flag = false;
            var Paymenttype = document.getElementById("<%=hdnPaymentMode.ClientID%>").value;
            if (Paymenttype == 'Credit Card' || Paymenttype == 'PayPal') {
                return true;
            }
            else {

                var DateFormat = '<%=DateFormat%>';
                var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_module.ClientID%>")
                var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
                var txtamtvalue = document.getElementById("<%= txtamtpaid_module.ClientID %>").value;
                var rdolist = document.getElementById("<%=rdopaymenttype_module.ClientID %>");
                var options = rdolist.getElementsByTagName("input");

                for (var i = 0; i < options.length; i++) {
                    if (options[i].type == "radio" && options[i].checked) {
                        if (options[i].value == "0") {
                            document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtamtpaid_module.ClientID %>").value;
                            if (document.getElementById("<%= hdntxtamtpaid.ClientID %>").value == "0.00") {
                                alert('Please enter amount grater then 0');
                                document.getElementById("<%= txtamtpaid_module.ClientID %>").value = "0.00";
                                flag = false;
                                return false;
                            }
                            else {
                                flag = true;
                            }
                        }
                        else if (options[i].value == "1") {
                            if (txtamtvalue == '0.00') {
                                alert('Please enter amount grater then 0');
                                document.getElementById("<%= txtamtpaid_module.ClientID %>").value = "0.00";
                                flag = false;
                                return false;
                            }
                            else if (txtamtvalue == '') {
                                alert('Please enter amount grater then 0');
                                document.getElementById("<%= txtamtpaid_module.ClientID %>").value = "";
                                flag = false;
                                return false;
                            }
                            else {
                                flag = true;
                            }
                        }
                    }
                }

                if (flag == true) {
                    var ddlPayment = document.getElementById("<%=ddl_Paymentmode_module.ClientID%>");
                    if (ddlPayment.options[ddlPayment.selectedIndex].value == "0") {
                        document.getElementById("spn_PaymentMode_Module").style.display = "block";
                        flag = false;
                        return false;
                    }
                    else {
                        document.getElementById("spn_PaymentMode_Module").style.display = "none";
                        flag = true;
                    }
                }

                if (flag == true) {
                    if (txtInvoicePaymentDate == '') {
                        document.getElementById("spn_InvoicePaymentDaterfq_module").style.display = "block";
                        CheckFinal = true;
                    }
                    else {
                        document.getElementById("spn_InvoicePaymentDaterfq_module").style.display = "none";
                        if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDaterfq_module', DateFormat) == false) {
                            CheckFinal = true;
                        }
                    }
                }

                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }
            // }
        }

    </script>
    <script language="javascript" type="text/javascript">
        function paidyes1() {

            var paid_reeng = document.getElementById("PaidYesNo_reeng");
            var ddl_Paymentmode = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            var txtInvoicePaymentDate = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>");
            var txt_PaymentDetailNotes = document.getElementById("<%=txt_PaymentDetailNotes.ClientID%>");
            ddl_Paymentmode.disabled = false;
            txt_PaymentDetailNotes.disabled = false;
            txtInvoicePaymentDate.disabled = false;
        }

        function paidNo1() {

            var paid_reeng = document.getElementById("PaidYesNo_reeng");
            var ddl_Paymentmode = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            var txtInvoicePaymentDate = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>");
            var txt_PaymentDetailNotes = document.getElementById("<%=txt_PaymentDetailNotes.ClientID%>");
            ddl_Paymentmode.disabled = true;
            txt_PaymentDetailNotes.disabled = true;
            txtInvoicePaymentDate.disabled = true;
            var ddlPayment = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            ddlPayment.options[0].selected = true;
            DisplayCreditCards();
            DisplayCreditCards_module();
        }

        function GetRadWindow() {

            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }



        function Close() {

            //alert("close");           
            var oWindow = GetRadWindow();
            var url;
            if (window.location.href.indexOf("ProgressToInvoiceFromJob") != -1) {
                url = "<%=strSitepath%>invoice/invoice_summary_reeng.aspx?estid=<%=EstimateID%>";
                oWindow.BrowserWindow.location.href = '<%=strSitepath%>invoice/invoice_summary_reeng.aspx?estid=<%=EstimateID%>';
            }
            else if (window.location.href.indexOf("ProgressToInvoiceFromOrder") != -1) {
                url = "<%=strSitepath%>invoice/invoice_order_summary.aspx?frm=view&estid=<%=EstimateID%>&ordid=<%=EstimateID%>";
                oWindow.BrowserWindow.location.href = '<%=strSitepath%>invoice/invoice_order_summary.aspx?frm=view&estid=<%=EstimateID%>&ordid=<%=EstimateID%>';
            }
            else if (window.location.href.indexOf("invoice_View") != -1) {
                url = "<%=strSitepath%>Invoice/invoice_view.aspx?su=Payment"
                oWindow.BrowserWindow.location.href = '<%=strSitepath%>Invoice/invoice_view.aspx?su=Payment';
            }
            else if (window.location.href.indexOf("job_View") != -1) {
                url = "<%=strSitepath%>Jobs/jobs_view.aspx?su=Payment"
                oWindow.BrowserWindow.location.href = '<%=strSitepath%>Jobs/jobs_view.aspx?su=Payment';
            }
            else if (ModuleType == "jobinvview") {
            }
            else {
                oWindow.BrowserWindow.location.reload();
            }
            oWindow.close();
            return false;
        }



        function FetchEstimateIDs() {

            var hdnEstimatIds = document.getElementById("<%=hdnEstimatIds.ClientID%>");
            var hdn = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_hdnInvoiceEstimateIds');
            hdnEstimatIds.value = hdn.value;
            return true;
        }

        function DisplayCreditCards_module() {
            var ddlPayment = document.getElementById("<%=ddl_Paymentmode_module.ClientID%>");
            var rbnVisaID = document.getElementById("<%=rbnVisaID_module.ClientID%>");
            var rbnMasterCardID = document.getElementById("<%=rbnMasterCardID_module.ClientID%>");
            var rbnDiscoverID = document.getElementById("<%=rbnDiscoverID_module.ClientID%>");
            var rbnAmericanID = document.getElementById("<%=rbnAmericanID_module.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {
                document.getElementById("<%=div_CreditCardDetails_module.ClientID%>").style.display = "block";
                document.getElementById("<%=txt_HolderName_module.ClientID%>").value = '';
                document.getElementById("<%=txt_cardNumber_module.ClientID%>").value = '';
                document.getElementById("<%=txt_verification_module.ClientID%>").value = '';
                document.getElementById("<%=ddl_month_module.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=ddl_year_module.ClientID%>").selectedIndex = 0;
                rbnVisaID.selected = false;
                rbnAmericanID.selected = false;
                rbnMasterCardID.selected = false;
                rbnDiscoverID.selected = false;
            }
            else {
                document.getElementById("<%=div_CreditCardDetails_module.ClientID%>").style.display = "none";
                rbnVisaID.checked = false;
            }
        }

        function PaymentTypeOnChangeNew() {
            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                document.getElementById("<%=div_JobStatus.ClientID%>").style.display = "none";
                document.getElementById("<%=div_linkclick.ClientID%>").style.display = "none";
                document.getElementById("<%=div_NewPaymnethdng.ClientID%>").style.display = "none";
                //                document.getElementById("<%=divbtnrecord.ClientID%>").style.display = "none";
                //                document.getElementById("<%=divUpdateMain.ClientID%>").style.display = "none";
                document.getElementById("<%=divamountpaidshowhide.ClientID%>").style.display = "none";
                document.getElementById("<%=divrecordpayment.ClientID%>").style.display = "none";
                document.getElementById("<%=DivNotes_Value.ClientID%>").style.display = "none";
                document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                document.getElementById("<%=divMessage.ClientID%>").style.display = "none";
                document.getElementById("<%=div_JobStatus.ClientID%>").style.display = "none";
                //                document.getElementById("<%=divview.ClientID%>").style.display = "none";
                //                document.getElementById("<%=divaddEdit.ClientID%>").style.display = "none";

                document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "none";
                document.getElementById("<%=PaidYesNo.ClientID%>").style.display = "block";
                document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "block";
                document.getElementById("<%=divpaymentradio.ClientID%>").style.display = "block";
                hdnHeader.value = "Invoice Payment";
                return false;
            }
            else {
                //document.getElementById("div_ProgressToInvoice").style.display = "none";
                //document.getElementById("divBackGroundNew").style.display = "none";
            }
        }

        function DisplayCreditCards() {

            var ddlPayment = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            var rbnVisaID = document.getElementById("<%=rbnVisaID.ClientID%>");
            var rbnAmericanID = document.getElementById("<%=rbnAmericanID.ClientID%>");
            var rbnMasterCardID = document.getElementById("<%=rbnMasterCardID.ClientID%>");
            var rbnDiscoverID = document.getElementById("<%=rbnDiscoverID.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {
                document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "block";
                if (AddorEdit != "edit") {
                    document.getElementById("<%=txt_HolderName.ClientID%>").value = '';
                    document.getElementById("<%=txt_cardNumber.ClientID%>").value = '';
                    document.getElementById("<%=txt_verification.ClientID%>").value = '';
                    document.getElementById("<%=ddl_month.ClientID%>").options[ddlPayment.selectedIndex].value = 0;
                    document.getElementById("<%=ddl_year.ClientID%>").options[ddlPayment.selectedIndex].value = 0;
                    rbnVisaID.selected = false;
                    rbnAmericanID.selected = false;
                    rbnMasterCardID.selected = false;
                    rbnDiscoverID.selected = false;
                }
                else {
                    if (EditPaymentMode != '4') {
                        document.getElementById("<%=txt_HolderName.ClientID%>").value = '';
                        document.getElementById("<%=txt_cardNumber.ClientID%>").value = '';
                        document.getElementById("<%=txt_verification.ClientID%>").value = '';
                        document.getElementById("<%=ddl_month.ClientID%>").options[ddlPayment.selectedIndex].value = 0;
                        document.getElementById("<%=ddl_year.ClientID%>").options[ddlPayment.selectedIndex].value = 0;
                        rbnVisaID.selected = false;
                        rbnAmericanID.selected = false;
                        rbnMasterCardID.selected = false;
                        rbnDiscoverID.selected = false;
                    }
                }

            }
            else {
                document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "none";
                rbnVisaID.selected = false;
                rbnAmericanID.selected = false;
                rbnMasterCardID.selected = false;
                rbnDiscoverID.selected = false;
            }
        }

        function CreditCardValidation() {

            var ddlPayment = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {
                var txt_cardNumber = document.getElementById("ctl00_ContentPlaceHolder1_txt_cardNumber");
                var rbnAmericanID = document.getElementById("ctl00_ContentPlaceHolder1_rbnAmericanID");
                var rbnVisaID = document.getElementById("ctl00_ContentPlaceHolder1_rbnVisaID");
                var rbnMasterCardID = document.getElementById("ctl00_ContentPlaceHolder1_rbnMasterCardID");
                var rbnDiscoverID = document.getElementById("ctl00_ContentPlaceHolder1_rbnDiscoverID");
                var txt_verification = document.getElementById("<%=txt_verification.ClientID %>");
                var txt_HolderName = document.getElementById("<%=txt_HolderName.ClientID %>");
                var ddl_month = document.getElementById("<%=ddl_month.ClientID %>");
                var ddl_year = document.getElementById("<%=ddl_year.ClientID %>");

                var CreditCheck = false;

                if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {

                    if (txt_cardNumber.value == "") {
                        document.getElementById("spn_cardNumber").style.display = "block";
                        CreditCheck = true;
                    }
                    else if (!Number(txt_cardNumber.value)) {
                        document.getElementById("spn_cardNumber").style.display = "block";
                        document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                        CreditCheck = true;
                    }

                    var re = '';

                    if (rbnVisaID.checked) {
                        // Visa: length 16, prefix 4, dashes optional.
                        re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
                        //                alert(re);
                    }
                    else if (rbnMasterCardID.checked) {
                        // Mastercard: length 16, prefix 51-55, dashes optional.
                        re = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
                    }
                    else if (rbnDiscoverID.checked) {
                        // Discover: length 16, prefix 6011, dashes optional.
                        re = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
                    }
                    else if (rbnAmericanID.checked) {
                        // American Express: length 15, prefix 34 or 37.
                        re = /^3[4,7]\d{13}$/;
                    }

                    if (re.length == 0) {
                        rbnVisaID.checked = true;
                        re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
                    }

                    if (!re.test(txt_cardNumber.value)) {
                        document.getElementById("spn_cardNumber").style.display = "block";
                        document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                        CreditCheck = true;
                    }
                    else {
                        document.getElementById("spn_cardNumber").style.display = "none";
                    }

                    // Remove all dashes for the checksum checks to eliminate negative numbers
                    var ccnum = txt_cardNumber.value.split("-").join("");
                    // Checksum ("Mod 10")
                    // Add even digits in even length strings or odd digits in odd length strings.
                    var checksum = 0;
                    for (var i = (2 - (ccnum.length % 2)); i <= ccnum.length; i += 2) {
                        checksum += parseInt(ccnum.charAt(i - 1));
                    }

                    // Analyze odd digits in even length strings or even digits in odd length strings.
                    for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {
                        var digit = parseInt(ccnum.charAt(i - 1)) * 2;
                        if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }
                    }
                    if ((checksum % 10) != 0) {
                        document.getElementById("spn_cardNumber").style.display = "block";
                        document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                        CreditCheck = true;
                    }
                    else if (!CreditCheck) {
                        document.getElementById("spn_cardNumber").style.display = "none";
                    }



                    if (txt_verification.value == "") {
                        document.getElementById("spn_verification").style.display = "block";
                        CreditCheck = true;
                    }
                    else if (!Number(txt_verification.value)) {
                        //                alert('CreditCheck1  _' + CreditCheck);
                        document.getElementById("spn_verification").style.display = "block";
                        document.getElementById("spn_verification").innerHTML = "Please Enter Valid Number";
                        CreditCheck = true;
                    }
                    else {
                        document.getElementById("spn_verification").style.display = "none";
                    }


                    if (txt_HolderName.value == "") {
                        document.getElementById("spn_HolderName").style.display = "block";
                        CreditCheck = true;
                    }
                    else {
                        document.getElementById("spn_HolderName").style.display = "none";
                    }

                    if (ddl_month.selectedIndex == 0 || ddl_year.selectedIndex == 0) {
                        document.getElementById("spn_ddlyear").style.display = "block";
                        document.getElementById("spn_ddlyear").innerHTML = "Please select valid month/year.";
                        CreditCheck = true;
                    }
                    else {
                        document.getElementById("spn_ddlyear").style.display = "none";
                    }
                }
                if (CreditCheck) {
                    return false;
                }
                return true;
            }
            else {
                return true;
            }
        }

        function Validations() {

            var ddlPayment = document.getElementById("<%=ddl_Paymentmode.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {
                validate_date();
                return CreditCardValidation();
            }
            else {
                return validate_date();
            }
        }

        function CardNumberValidation() {

            var txt_cardNumber = document.getElementById("<%=txt_cardNumber.ClientID%>");

            if (CheckReqCompare(txt_cardNumber.value, 'spn_cardNumber', 'spn_cardNumber')) {
                return false;
            }
        }

        function CardNumberValidationForModule() {

            var txt_cardNumber = document.getElementById("<%=txt_cardNumber_module.ClientID%>");

            if (CheckReqCompare(txt_cardNumber.value, 'spn_cardNumber_module', 'spn_cardNumber_module')) {
                return false;
            }
        }

        function VarificationCodeForModule() {

            var txt_verification = document.getElementById("<%=txt_verification_module.ClientID%>");

            if (CheckReqCompare(txt_verification.value, 'spn_verification_module', 'spn_verification_module')) {
                return false;
            }
        }

        function VarificationCode() {

            var txt_verification = document.getElementById("<%=txt_verification.ClientID%>");

            if (CheckReqCompare(txt_verification.value, 'spn_verification', 'spn_verification')) {
                return false;
            }
        }

        function amountpaidchanges() {

            var a = NewEdit;
            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var DefaultPaymentDate = '<%=txtInvoicePaymentDate.Text%>';
            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").disabled = true;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>")
                        if (AddorEdit != "add") {
                            document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtamtpaid.ClientID %>").value;
                            document.getElementById("<%= hdnAmtpaidforedit.ClientID %>").value = document.getElementById("<%= txtamtpaid.ClientID %>").value;
                        }
                        else {
                            if (OutStandingAmount > 0) {
                                document.getElementById("<%= txtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                                document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                                txtInvoicePaymentDateID.value = DefaultPaymentDate;
                            } else {
                                document.getElementById("<%= txtamtpaid.ClientID %>").value = "0.00";
                                document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = "0.00";
                            }
                        }
                    }
                    else if (options[i].value == "1") {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>")
                        if (AddorEdit != "add") {
                            document.getElementById("<%= hdnAmtpaidforedit.ClientID %>").value = document.getElementById("<%= txtamtpaid.ClientID %>").value;
                        }
                        else {
                            txtInvoicePaymentDateID.value = DefaultPaymentDate;
                            if (OutStandingAmount > 0) {
                                document.getElementById("<%= txtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                            } else {
                                document.getElementById("<%= txtamtpaid.ClientID %>").value = "0.00";
                            }
                        }
                    }
                    else if (options[i].value == "2") {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes").disabled = true;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = true;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = true;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate.ClientID%>")
                        txtInvoicePaymentDateID.value = DefaultPaymentDate;
                    }
                }
            }
        }

        function amountpaidchanges_module() {

            var DateFormat = '<%=DateFormat%>';
            var rdolist = document.getElementById("<%=rdopaymenttype_module.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var DefaultPaymentDate = '<%=txtInvoicePaymentDate_module.Text%>';
            for (var i = 0; i < options.length; i++) {

                if (options[i].type == "radio" && options[i].checked) {

                    if (options[i].value == "0") {
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_ddl_Paymentmode_module").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtInvoicePaymentDate_module").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txt_PaymentDetailNotes_module").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_module.ClientID%>")
                        if (OutStandingAmount > 0) {
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").focus();
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                            document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                        } else {
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "0.00";
                            document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = "0.00";
                        }
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").disabled = false;
                        // document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").disabled = true;
                    }
                    else if (options[i].value == "1") {
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_ddl_Paymentmode_module").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtInvoicePaymentDate_module").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txt_PaymentDetailNotes_module").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_module.ClientID%>")
                        txtInvoicePaymentDateID.value = trim12(DefaultPaymentDate);
                        if (OutStandingAmount > 0) {
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "";
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").focus();
                            // for  in part it shud be blank  document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                        } else {
                            document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "0.00";
                        }
                    }
                    else if (options[i].value == "2") {
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_ddl_Paymentmode_module").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtInvoicePaymentDate_module").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txt_PaymentDetailNotes_module").disabled = true;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_module.ClientID%>")
                        txtInvoicePaymentDateID.value = trim12(DefaultPaymentDate);
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = true;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = true;
                    }
                }
            }
        }

        function defaultloadonpage() {

            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {//for invoice
                        if (ModuleType == "jobinvview") {
                            document.getElementById("<%=DivPayment_Dropdown.ClientID%>").style.display = "block";
                            document.getElementById("<%=DivDate_Text.ClientID%>").style.display = "block";
                        }
                    }
                    else if (options[i].value == "1") {
                        document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                    }
                }
            }
        }

        function defaultloadonpage_module() {

            var rdolist = document.getElementById("<%=rdopaymenttype_module.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {
                        if (ModuleType == "jobinvview") {
                            document.getElementById("<%=DivPayment_Dropdown_module.ClientID%>").style.display = "block";
                            document.getElementById("<%=DivDate_Text_module.ClientID%>").style.display = "block";
                        }
                    }
                    else if (options[i].value == "1") {
                        document.getElementById("<%=DivPayment_Value_module.ClientID%>").style.display = "block";
                        document.getElementById("<%=DivDate_Value_module.ClientID%>").style.display = "block";
                    }
                }
            }
        }

        function Amountpaidvalidation(value) {

            var numbers = /^[0-9]+$/;
            if (parseFloat(value) < 0) {
                alert('Please enter amount grater then 0');
                document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0";
                return false;
            }
            else if (value != null) {
                if (value.match(numbers)) {
                    return true;
                } else {
                    alert('Please enter valid amount grater then 0');
                    document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0";
                    return false;
                }
            }
        }
        defaultloadonpage();

        function Amountpaidvalidation_Module(value) {

            var numbers = /^[0-9][\.][0-9]+$/;

            if (parseFloat(value) < 0) {
                alert('Please enter amount grater then 0');
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "0";
                return false;
            }
            else if (value != null) {
                if (value.match(numbers)) {
                    return true;
                } else {
                    alert('Please enter valid amount grater then 0');
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_txtamtpaid_module").value = "0";
                    return false;
                }
            }
        }

        function onlyNumbers(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function onlyNumbersforVN(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function todecimal_function(txtobj) {

            var value = txtobj.value;
            if (!isNaN(txtobj.value) && Number(txtobj.value)) {
                txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtobj.value, 0, '', false, false, false);
            }
            else {
                txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
            }
        }
        defaultloadonpage_module();
    </script>
    <script type="text/javascript">

        function hideshow(span) {

            var DefaultPaymentDate = '<%=txtInvoicePaymentDate.Text%>';
            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
            var div = document.getElementById("ctl00_ContentPlaceHolder1_divpaymentradio");
            var divamountpaidshowhide = document.getElementById("ctl00_ContentPlaceHolder1_divamountpaidshowhide");
            var div1 = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
            var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
            var txtamtpaid = document.getElementById("<%= txtamtpaid.ClientID %>");
            var ddl_pmntMode = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode");
            var txtpmntdate = document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate");
            var txtnotes = document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes");
            var btnRecord = document.getElementById('<%=btnRecord.ClientID %>');
            var btnRecordNclose = document.getElementById('<%=btnRecordNclose.ClientID %>');
            if (div.style.display == "none" || div1.style.display == "none" || divbtnrecord.style.display == "none" || divamountpaidshowhide.style.display == "none") {
                div.style.display = "block";
                div1.style.display = "block";
                if (ModuleType == "jobinvview") {
                    divamountpaidshowhide.style.display = "none";
                }
                else {
                    divamountpaidshowhide.style.display = "block";
                }
                divbtnrecord.style.display = "block";
                divUpdateMain.style.display = "none";
                if (ModuleType == "invoicesummary") {
                    if (OutStandingAmount > 0) {
                        txtamtpaid.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                    } else {
                        txtamtpaid.value = "0";
                    }
                    if (document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block") {
                        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
                    }
                    options[0].checked = true;
                    amountpaidchanges();
                }
                else if (ModuleType == "orderinvoicesummary") {
                    if (OutStandingAmount > 0) {
                        txtamtpaid.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                    } else {
                        txtamtpaid.value = "0.00";
                    }
                    if (document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block") {
                        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
                    }
                    options[0].checked = true;
                    amountpaidchanges();
                }
                else {
                    txtamtpaid.value = 0;
                }
                ddl_pmntMode.selectedIndex = 0;
                txtpmntdate.value = DefaultPaymentDate;
                txtnotes.value = "";
            }
            else {
                div.style.display = "none";
                divUpdateMain.style.display = "none";
                div1.style.display = "none";
                divbtnrecord.style.display = "none";
                divamountpaidshowhide.style.display = "none";
            }
        }


        function hideshowfornewpayment(span) {

            var DefaultPaymentDate = '<%=txtInvoicePaymentDate.Text%>';
            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
            var div = document.getElementById("ctl00_ContentPlaceHolder1_divpaymentradio");
            var divamountpaidshowhide = document.getElementById("ctl00_ContentPlaceHolder1_divamountpaidshowhide");
            var div1 = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
            var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
            var txtamtpaid = document.getElementById("<%= txtamtpaid.ClientID %>");
            var ddl_pmntMode = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode");
            var txtpmntdate = document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate");
            var txtnotes = document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes");
            var btnRecord = document.getElementById('<%=btnRecord.ClientID %>');
            var btnRecordNclose = document.getElementById('<%=btnRecordNclose.ClientID %>');
            if (div.style.display == "none" || div1.style.display == "none" || divbtnrecord.style.display == "none" || divamountpaidshowhide.style.display == "none") {
                AddorEdit = 'add';
                div.style.display = "block";
                div1.style.display = "block";
                divamountpaidshowhide.style.display = "block";
                divbtnrecord.style.display = "block";
                divUpdateMain.style.display = "none";

                if (OutStandingAmount > 0) {
                    txtamtpaid.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                } else {
                    txtamtpaid.value = "0.00";
                }
                if (document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block") {
                    document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";
                }
                options[0].checked = true;
                amountpaidchanges();
                ddl_pmntMode.selectedIndex = 0;
                txtpmntdate.value = DefaultPaymentDate;
                txtnotes.value = "";
                if (div_CreditCardDetails.style.display == "block") {
                    div_CreditCardDetails.style.display = "none";
                }
            }
            else {
                div.style.display = "none";
                divUpdateMain.style.display = "none";
                div1.style.display = "none";
                divbtnrecord.style.display = "none";
                divamountpaidshowhide.style.display = "none";
                div_CreditCardDetails.style.display = "none";
            }
        }

        function DeletePaymentHistory() {

            if (window.confirm("Are you sure you want to mark the invoice as not Paid?\nThis action cannot be undone. Click OK to Proceed or Cancel")) {
                return true;
            }
            else {
                return false;
            }
        }

        function EditPaymentHistory() {

            var rdolist = document.getElementById("<%=rdopaymenttype.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var div = document.getElementById("ctl00_ContentPlaceHolder1_divpaymentradio");
            var divamountpaidshowhide = document.getElementById("ctl00_ContentPlaceHolder1_divamountpaidshowhide");
            var div1 = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
            var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
            if (div.style.display == "none" || div1.style.display == "none" || divbtnrecord.style.display == "none" || divamountpaidshowhide.style.display == "none") {
                div.style.display = "block";
                div1.style.display = "block";
                divamountpaidshowhide.style.display = "block";
                divbtnrecord.style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = "0";
                document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes").disabled = false;
                document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;

                document.getElementById("ctl00_ContentPlaceHolder1_txtamtpaid").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").value = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate").value = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes").value = false;
                document.getElementById('<%=btnRecord.ClientID %>').value = false;
                document.getElementById('<%=btnRecordNclose.ClientID %>').value = false;
            }
        }

        function OnChangeForSummary() {

            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

                var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
                var div_ProformaInvoice = document.getElementById("<%=div_ProformaInvoice.ClientID%>");
                var PaidYesNo = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
                var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
                var DivBtnPay = document.getElementById("ctl00_ContentPlaceHolder1_DivBtnPay");
                var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
                var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
                var divrecordpayment = document.getElementById("ctl00_ContentPlaceHolder1_divrecordpayment");
                var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
                var DivPayment_Value = document.getElementById("ctl00_ContentPlaceHolder1_DivPayment_Value");
                var DivDate_Value = document.getElementById("ctl00_ContentPlaceHolder1_DivDate_Value");
                document.getElementById("<%=div_invopmnt.ClientID%>").style.display = "block";
                document.getElementById("<%=divMessage.ClientID%>").style.display = "block";
                PaidYesNo.style.display = "none";
                div_JobStatus.style.display = "none";
                divUpdateMain.style.display = "none";
                divrecordpayment.style.display = "none";
                divbtnrecord.style.display = "none";
                DivBtnPay.style.display = "none";
                hdnHeader.value = "Invoice Payment";
                div_ProformaInvoice.style.display = "none";
                DivPaddingTop.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                DivNotes_Value.style.display = "none";

                hideshowAddEdit();
                divdisp();
                var stockdiv = document.getElementById("<%=divaddEdit.ClientID%>");
                stockdiv.style.top = "-11px";
                document.getElementById("<%=divPMTitle.ClientID%>").style.display = "none";
                document.getElementById("<%=imgback.ClientID%>").style.display = "none";
                document.getElementById("<%=btnRecord.ClientID%>").style.display = "none";

                return false;
            }
            else {
                document.getElementById("div_ProgressToInvoice").style.display = "none";
                return false;
            }
        }


        function OnChangeForOJSummary() {

            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

                var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
                var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
                var PaidYesNo = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
                var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
                var DivBtnPay = document.getElementById("DivBtnPay");
                var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
                var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
                var divrecordpayment = document.getElementById("ctl00_ContentPlaceHolder1_divrecordpayment");
                var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
                var DivPayment_Value = document.getElementById("DivPayment_Value");
                var DivDate_Value = document.getElementById("DivDate_Value");
                document.getElementById("<%=div_invopmnt.ClientID%>").style.display = "block";
                document.getElementById("<%=divMessage.ClientID%>").style.display = "block";
                PaidYesNo.style.display = "none";
                div_JobStatus.style.display = "none";
                divUpdateMain.style.display = "none";
                divrecordpayment.style.display = "none";
                divbtnrecord.style.display = "none";
                DivBtnPay.style.display = "none";
                hdnHeader.value = "Invoice Payment";
                div_ProformaInvoice.style.display = "none";
                DivPaddingTop.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                DivNotes_Value.style.display = "none";
                return false;
            }
            else {
                document.getElementById("div_ProgressToInvoice").style.display = "none";
                return false;
            }
        }

        function OnChangeForWebStore() {

            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
                document.getElementById("<%=div_invopmnt.ClientID%>").style.display = "block";
                document.getElementById("<%=divMessage.ClientID%>").style.display = "none";
                document.getElementById("<%=div_linkclick.ClientID%>").style.display = "none";
                document.getElementById("<%=div_linkclick.ClientID%>").style.display = "none";
                document.getElementById("<%=divrecordpayment.ClientID%>").style.display = "block";
                document.getElementById("<%=divpaymentradio.ClientID%>").style.display = "none";
                document.getElementById("<%=divamountpaidshowhide.ClientID%>").style.display = "none";
                document.getElementById("<%=PaidYesNo.ClientID%>").style.display = "none";
                document.getElementById("<%=div_JobStatus.ClientID%>").style.display = "none";
                document.getElementById("<%=divUpdateMain.ClientID%>").style.display = "none";
                document.getElementById("<%=divbtnrecord.ClientID%>").style.display = "none";
                document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "none";
                document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "none";
                document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                document.getElementById("<%=DivNotes_Value.ClientID%>").style.display = "none";
                hdnHeader.value = "Invoice Payment";
                return false;
            }
            else {
                document.getElementById("div_ProgressToInvoice").style.display = "none";
                return false;
            }
        }

        function ProgressJob_reeng_module() {

            var ret = 0;
            if (document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_ddl_Paymentmode_module").selectedIndex != 0) {
                ret = 1;
            }
            else {
                // alert("Show Validation message");
                ret = 0;
            }
            if (Ispaidenable == '1') {
                if (ret == 1) {
                    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                        var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
                        hdnHeader.value = "Progress To Invoice";
                        document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivPayment_Value_module.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivDate_Value_module.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivNotes_Value_module.ClientID%>").style.display = "none";
                        return false;
                    }
                    else {
                        document.getElementById("div_ProgressToJob").style.display = "none";
                    }
                }
                else {
                    var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
                    var PaidYesNo = document.getElementById("PaidYesNo_module");
                    hdnHeader.value = "Progress To Invoice";
                    document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                    document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                    document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "block";
                    return false;
                }
            }
            else {
                if (ret == 1) {
                    return window.confirm("Are you sure you want to progress this Job to become an Invoice ?  Invoices can not be reverted back to become Jobs in the future.");
                }
                else {
                    return false;
                }
            }
        }

        function ProgressJob_reeng_OrderNew() {

            var ret = 0;
            //if IsPaymentEnable in web confg value is 1 then the Popup "Is This Invoice Paid?" opens on click Progress to invoice else the alert message box opens.
            if (Ispaidenable == '1') {
                if (ret == 1) {
                    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                        document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivNotes_Value.ClientID%>").style.display = "none";
                        hdnHeader.value = "Progress To Invoice";
                        return false;
                    }
                    else {
                        document.getElementById("div_ProgressToJob").style.display = "none";
                    }
                }
                else {

                    if (hdnPaymentMode.value == "Credit Card" || hdnPaymentMode.value == "PayPal") {
                        hdnHeader.value = "Progress To Invoice";
                        document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=div_OdrPaymentDetails.ClientID%>").style.display = "none";
                        document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "block";
                        document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "block";
                        document.getElementById("<%=PaidYesNo.ClientID%>").style.display = "none";
                        document.getElementById("<%=divamountpaid.ClientID%>").style.display = "none";
                        return false;
                    }
                    else {
                        hdnHeader.value = "Progress To Invoice";
                        document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivPayment_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=DivDate_Value.ClientID%>").style.display = "none";
                        document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "block";
                        document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "block";
                        document.getElementById("<%=PaidYesNo.ClientID%>").style.display = "none";
                        document.getElementById("<%=divamountpaid.ClientID%>").style.display = "none";
                        return false;
                    }
                }
            }
            else {
                if (ret == 1) {
                    return window.confirm("Are you sure you want to progress this Job to become an Invoice ?  Invoices can not be reverted back to become Jobs in the future.");
                }
                else {
                    return false;
                }
            }
        }

        function PaymentDetails_New() {

            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
                var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
                var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
                var DivBtnPay = document.getElementById("DivBtnPay");
                var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
                var DivNotes_Text = document.getElementById("DivNotes_Text");
                var txtAmountpaid = document.getElementById("DivNotes_Text");
                var div_HolderName = document.getElementById("div_HolderName");
                var div_CardType = document.getElementById("div_CardType");
                var div_CardNumber = document.getElementById("div_CardNumber");
                var div_MonthYear = document.getElementById("div_MonthYear");
                var div_VarificationNumber = document.getElementById("div_VarificationNumber");
                var div_VarificationText = document.getElementById("div_VarificationText");
                var div_MonthYearValue = document.getElementById("div_MonthYearValue");
                var div_CardNumberText = document.getElementById("div_CardNumberText");
                var div_CardTypeImg = document.getElementById("div_CardTypeImg");
                var div_holderNameText = document.getElementById("div_holderNameText");
                hdnHeader.value = "Payment Details";

                document.getElementById("<%=DivPayment_Dropdown.ClientID%>").style.display = "block";
                document.getElementById("<%=DivDate_Text.ClientID%>").style.display = "block";
                document.getElementById("<%=DivNotes_Text.ClientID%>").style.display = "block";

                document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "none";
                document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "none";

                document.getElementById("<%=DivNotes_Value.ClientID%>").style.display = "block";
                document.getElementById("<%=div_JobStatus.ClientID%>").style.display = "none";

                if (hdnPaymentMode.value == "Credit Card") {
                    document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "block";
                    document.getElementById("<%=div_HolderName.ClientID%>").style.display = "block";
                    document.getElementById("<%=div_CardType.ClientID%>").style.display = "block";
                    document.getElementById("<%=div_CardNumber.ClientID%>").style.display = "block";
                    document.getElementById("<%=div_MonthYear.ClientID%>").style.display = "block";
                    document.getElementById("<%=div_VarificationNumber.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_MonthYearValue.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_CardNumberText.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_CardTypeImg.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_holderNameText.ClientID%>").style.display = "none";
                }
                return false;
            }
            else {
                document.getElementById("div_ProgressToInvoice").style.display = "none";
                return false;
            }
        }


        function PaymentDetails_InvoiceSummaryNew(type) {

            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
                document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "none";
                document.getElementById("<%=PaidYesNo.ClientID%>").style.display = "none";
                document.getElementById("<%=div_ProformaInvoice.ClientID%>").style.display = "block";
                document.getElementById("<%=divamountpaid.ClientID%>").style.display = "none";
                document.getElementById("<%=DivBtnPay.ClientID%>").style.display = "none";
                document.getElementById("<%=DivPaddingTop.ClientID%>").style.display = "block";
                document.getElementById("<%=div_lnkNotPaid.ClientID%>").style.display = "none";
                document.getElementById("<%=DivNotes_Value.ClientID%>").style.display = "block";
                hdnHeader.value = "Payment Details";

                if (hdnPaymentMode.value == "Credit Card") {
                    document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "none";
                }
                if (type == "order") {
                    document.getElementById("<%=div_OdrPaymentDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_lnkNotPaid.ClientID%>").style.display = "none";
                    document.getElementById("<%=div_CreditCardDetails.ClientID%>").style.display = "none";
                }
                return false;
            }
            else {
                document.getElementById("div_ProgressToInvoice").style.display = "none";
                return false;
            }
        }

        function CardNumberValidation_Add() {

            var txt_cardNumber = document.getElementById("<%=txt_cardNumber_Add.ClientID%>");
            if (CheckReqCompare(txt_cardNumber.value, 'spn_cardNumber_Add', 'spn_cardNumber_Add')) {
                return false;
            }
        }

        function VarificationCode_Add() {

            var txt_verification = document.getElementById("<%=txt_verification_Add.ClientID%>");
            if (CheckReqCompare(txt_verification.value, 'spn_verification_Add', 'spn_verification_Add')) {
                return false;
            }
        }

        function hideshowAddEdit() {

            var DefaultPaymentDate = '<%=txtInvoicePaymentDate_Add.Text%>';
            var rdolist = document.getElementById("<%=rdopaymenttypeforaddedit.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
            var div = document.getElementById("ctl00_ContentPlaceHolder1_divPaymentModeaddEdit");
            var divamountpaidshowhide = document.getElementById("ctl00_ContentPlaceHolder1_divamtpaidAddEdit");
            var div1 = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo_Add");
            var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
            var txtamtpaid = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>");
            var ddl_pmntMode = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode_Add");
            var txtpmntdate = document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate_Add");
            var txtnotes = document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes_Add");
            var btnRecord = document.getElementById('<%=btnRecord.ClientID %>');
            var btnRecordNclose = document.getElementById('<%=btnRecordNclose.ClientID %>');
            var txt = document.getElementById('<%=hdntxtvalue.ClientID %>');
            var OutStandingAmount1 = txt.value;

            AddorEdit = 'add';
            div.style.display = "block";
            div1.style.display = "block";
            divamountpaidshowhide.style.display = "block";
            divbtnrecord.style.display = "block";
            divUpdateMain.style.display = "none";

            if (OutStandingAmount1 > 0) {
                txtamtpaid.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
            } else {
                txtamtpaid.value = "0.00";
            }

            if (document.getElementById("spn_InvoicePaymentDate_Add").style.display = "block") {
                document.getElementById("spn_InvoicePaymentDate_Add").style.display = "none";
            }

            if (document.getElementById("spn_PaymentMode_Add").style.display = "block") {
                document.getElementById("spn_PaymentMode_Add").style.display = "none";
            }


            if (document.getElementById('<%=div_CreditCardDetails_Add.ClientID %>').style.display = "block") {
                document.getElementById('<%=div_CreditCardDetails_Add.ClientID %>').style.display = "none";
            }

            document.getElementById('<%=divPMTitle.ClientID %>').style.display = "block";
            document.getElementById('<%=divEditPayment.ClientID %>').style.display = "none";

            options[0].checked = true;
            options[2].disabled = true;
            options[2].style.display = "none";
            amountpaidchanges_AddEdit();
            ddl_pmntMode.selectedIndex = 0;
            txtpmntdate.value = DefaultPaymentDate;
            txtnotes.value = "";
        }

        function validate_date_Add() {

            CheckFinal = false;
            flag = false;
            var DateFormat = '<%=DateFormat%>';
            var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_Add.ClientID%>")
            var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
            var txtamtvalue = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
            var rdolist = document.getElementById("<%=rdopaymenttypeforaddedit.ClientID %>");
            var options = rdolist.getElementsByTagName("input");

            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {
                        document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
                        if (document.getElementById("<%= hdntxtamtpaid.ClientID %>").value == "0.00") {
                            alert('Please enter amount grater then 0');
                            document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").value = "0.00";
                            flag = false;
                            return false;
                        }
                        else {
                            flag = true;
                        }
                    }
                    else if (options[i].value == "1") {
                        if (txtamtvalue == '0.00') {
                            alert('Please enter amount grater then 0');
                            document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").value = "0.00";
                            flag = false;
                            return false;
                        }
                        else if (txtamtvalue == '') {
                            alert('Please enter amount grater then 0');
                            document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").value = "";
                            flag = false;
                            return false;
                        }
                        else {
                            flag = true;
                        }
                    }
                }
            }

            if (flag == true) {
                var ddlPayment = document.getElementById("<%=ddl_Paymentmode_Add.ClientID%>");
                if (ddlPayment.options[ddlPayment.selectedIndex].value == "0") {
                    document.getElementById("spn_PaymentMode_Add").style.display = "block";
                    flag = false;
                    return false;
                }
                else {
                    document.getElementById("spn_PaymentMode_Add").style.display = "none";
                    flag = true;
                }
            }

            if (flag == true) {
                if (txtInvoicePaymentDate == '') {
                    document.getElementById("spn_InvoicePaymentDate_Add").style.display = "block";
                    CheckFinal = true;
                }
                else {
                    document.getElementById("spn_InvoicePaymentDate_Add").style.display = "none";
                    if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDate_Add', DateFormat) == false) {
                        CheckFinal = true;
                    }
                }

                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function amountpaidchanges_AddEdit() {

            var a = NewEdit;
            var rdolist = document.getElementById("<%=rdopaymenttypeforaddedit.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            var DefaultPaymentDate = '<%=txtInvoicePaymentDate_Add.Text%>';
            var txt = document.getElementById('<%=hdntxtvalue.ClientID %>');
            var OutStandingAmount1 = txt.value;
            //var AddorEdit = '<%=AddorEdit %>';

            options[2].style.display = "none";
            for (var i = 0; i < options.length; i++) {
                if (options[i].type == "radio" && options[i].checked) {
                    if (options[i].value == "0") {
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").disabled = false;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_Add.ClientID%>")
                        if (AddorEdit != "add") {
                            document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                            document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
                            document.getElementById("<%= hdnAmtpaidforedit.ClientID %>").value = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
                        }
                        else {
                            if (OutStandingAmount1 > 0) {
                                //                                document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                                //                                document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                                document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                                document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                                document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                                txtInvoicePaymentDateID.value = DefaultPaymentDate;
                            } else {
                                document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = "0.00";
                                document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                                document.getElementById("<%= hdntxtamtpaid.ClientID %>").value = "0.00";
                            }
                        }
                    }
                    else if (options[i].value == "1") {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes_Add").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord").disabled = false;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = false;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = false;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_Add.ClientID%>")

                        var txtforedit = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
                        var Eamt = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtforedit, 0, '', false, false, false);

                        if (AddorEdit != "add") {
                            document.getElementById("<%= hdnAmtpaidforedit.ClientID %>").value = document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value;
                            // document.getElementById("<%= hdnAmtpaidforedit.ClientID %>").value = Eamt;
                            document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                        }
                        else {
                            txtInvoicePaymentDateID.value = DefaultPaymentDate;
                            if (OutStandingAmount1 > 0) {
                                // document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount, 0, '', false, false, false);
                                // for new changes in add it shud be blank //document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                                document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = '';
                                document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                            } else {
                                //document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = "0.00";
                                document.getElementById("<%= txtAmtpaidAddedit.ClientID %>").value = '';
                                document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
                            }
                        }
                    }
                    else if (options[i].value == "2") {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").value = "0";
                        document.getElementById("ctl00_ContentPlaceHolder1_txtAmtpaidAddedit").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode_Add").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_txtInvoicePaymentDate_Add").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_txt_PaymentDetailNotes_Add").disabled = true;
                        document.getElementById('<%=btnRecord.ClientID %>').disabled = true;
                        document.getElementById('<%=btnRecordNclose.ClientID %>').disabled = true;
                        var txtInvoicePaymentDateID = document.getElementById("<%=txtInvoicePaymentDate_Add.ClientID%>")
                        txtInvoicePaymentDateID.value = DefaultPaymentDate;
                    }
                }
            }
        }

        function DisplayCreditCardsForAdd() {
            var ddlPayment = document.getElementById("<%=ddl_Paymentmode_Add.ClientID%>");
            var rbnVisaID = document.getElementById("<%=rbnVisaID_Add.ClientID%>");
            var rbnAmericanID = document.getElementById("<%=rbnAmericanID_Add.ClientID%>");
            var rbnMasterCardID = document.getElementById("<%=rbnMasterCardID_Add.ClientID%>");
            var rbnDiscoverID = document.getElementById("<%=rbnDiscoverID_Add.ClientID%>");
            if (ddlPayment.options[ddlPayment.selectedIndex].value == "4") {
                document.getElementById("<%=div_CreditCardDetails_Add.ClientID%>").style.display = "block";
                if (AddorEdit != "edit") {
                    document.getElementById("<%=txt_HolderName_Add.ClientID%>").value = '';
                    document.getElementById("<%=txt_cardNumber_Add.ClientID%>").value = '';
                    document.getElementById("<%=txt_verification_Add.ClientID%>").value = '';
                    document.getElementById("<%=ddl_month_Add.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=ddl_year_Add.ClientID%>").selectedIndex = 0;
                    rbnVisaID.selected = false;
                    rbnAmericanID.selected = false;
                    rbnMasterCardID.selected = false;
                    rbnDiscoverID.selected = false;
                }
                else {
                    if (EditPaymentMode != '4') {
                        document.getElementById("<%=txt_HolderName_Add.ClientID%>").value = '';
                        document.getElementById("<%=txt_cardNumber_Add.ClientID%>").value = '';
                        document.getElementById("<%=txt_verification_Add.ClientID%>").value = '';
                        document.getElementById("<%=ddl_month_Add.ClientID%>").selectedIndex = 0;
                        document.getElementById("<%=ddl_year_Add.ClientID%>").selectedIndex = 0;
                        rbnVisaID.selected = false;
                        rbnAmericanID.selected = false;
                        rbnMasterCardID.selected = false;
                        rbnDiscoverID.selected = false;
                    }
                }

            }
            else {
                document.getElementById("<%=div_CreditCardDetails_Add.ClientID%>").style.display = "none";
                rbnVisaID.selected = false;
                rbnAmericanID.selected = false;
                rbnMasterCardID.selected = false;
                rbnDiscoverID.selected = false;
            }
        }

        function slideIt(objdiv) {

            // var slidingDiv = document.getElementById(objdiv.id);
            document.getElementById("<%=divview.ClientID%>").style.display = 'none';
            var slidingDiv = document.getElementById("<%=divaddforother.ClientID%>");
            var stopPosition = 700;
            if (parseInt(slidingDiv.style.left) < stopPosition) {
                slidingDiv.style.left = parseInt(slidingDiv.style.left) + 70 + "px";
                setTimeout("slideIt('divaddforother')", 15);
            }
            setTimeout("divdisp()", 600);
        }

        function divdisp() {

            document.getElementById("<%=divaddforother.ClientID%>").style.display = 'none';
            document.getElementById("<%=divview.ClientID%>").style.display = 'none';
            var stockdiv = document.getElementById("<%=divaddEdit.ClientID%>");
            stockdiv.style.right = 0 + "px";
            document.getElementById("<%=divaddEdit.ClientID%>").style.display = 'block';
        }

        function slideItForEdit(objdiv) {
            if (document.getElementById("spn_InvoicePaymentDate_Add").style.display = "block") {
                document.getElementById("spn_InvoicePaymentDate_Add").style.display = "none";
            }
            if (document.getElementById("spn_PaymentMode_Add").style.display = "block") {
                document.getElementById("spn_PaymentMode_Add").style.display = "none";
            }

            //document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
            document.getElementById("<%=divview.ClientID%>").style.display = 'none';
            var slidingDiv = document.getElementById("<%=divaddforother.ClientID%>");
            var stopPosition = 700;
            if (parseInt(slidingDiv.style.left) < stopPosition) {
                slidingDiv.style.left = parseInt(slidingDiv.style.left) + 70 + "px";
                setTimeout("slideItForEdit('divaddforother')", 15);
            }
            setTimeout("divdispForEdit()", 600);
        }

        function divdispForEdit() {

            document.getElementById("<%=divaddforother.ClientID%>").style.display = 'none';
            document.getElementById("<%=divview.ClientID%>").style.display = 'none';
            var stockdiv = document.getElementById("<%=divaddEdit.ClientID%>");
            stockdiv.style.right = 0 + "px";
            document.getElementById("<%=divaddEdit.ClientID%>").style.display = 'block';
            AddorEdit = "edit";
            //            document.getElementById('<%= txtAmtpaidAddedit.ClientID %>').focus();
        }

        function slidehistory(id) {
            var slidingDiv = document.getElementById("<%=divaddEdit.ClientID%>");
            var stopPosition = 700;
            if (parseInt(slidingDiv.style.right) < stopPosition) {
                slidingDiv.style.right = parseInt(slidingDiv.style.right) + 70 + "px";
                setTimeout("slidehistory('divaddEdit')", 15);
            }
            setTimeout("divdispstock()", 400);
        }

        function divdispstock() {
            document.getElementById("<%=divaddEdit.ClientID%>").style.display = 'none';
            var stockdiv = document.getElementById("<%=divaddforother.ClientID%>");
            stockdiv.style.left = 0 + "px";
            document.getElementById("<%=divaddforother.ClientID%>").style.display = 'block';
        }

        function slideItForView(objdiv) {

            var slidingDiv = document.getElementById("<%=divaddforother.ClientID%>");
            var stopPosition = 700;
            if (parseInt(slidingDiv.style.left) < stopPosition) {
                slidingDiv.style.left = parseInt(slidingDiv.style.left) + 70 + "px";
                setTimeout("slideItForView('divaddforother')", 15);
            }
            setTimeout("divdispForView()", 600);
        }

        function divdispForView() {

            document.getElementById("<%=divaddforother.ClientID%>").style.display = 'none';
            document.getElementById("<%=divaddEdit.ClientID%>").style.display = 'none';
            var stockdiv = document.getElementById("<%=divview.ClientID%>");
            stockdiv.style.right = 0 + "px";
            document.getElementById("<%=divview.ClientID%>").style.display = 'block';
        }

        function slideView(id) {

            var slidingDiv = document.getElementById("<%=divview.ClientID%>");
            var stopPosition = 700;
            if (parseInt(slidingDiv.style.right) < stopPosition) {
                slidingDiv.style.right = parseInt(slidingDiv.style.right) + 70 + "px";
                setTimeout("slideView('divview')", 15);
            }
            setTimeout("divdispstockForView()", 600);
        }

        function divdispstockForView() {

            document.getElementById("<%=divview.ClientID%>").style.display = 'none';
            document.getElementById("<%=divaddEdit.ClientID%>").style.display = 'none';
            var stockdiv = document.getElementById("<%=divaddforother.ClientID%>");
            stockdiv.style.left = 0 + "px";
            document.getElementById("<%=divaddforother.ClientID%>").style.display = 'block';
        }

        function UpdateIspaid() {

            var Outstandingamt = document.getElementById('<%=hdnoutstangimgforupdate.ClientID %>');
            var paymenttype = document.getElementById('<%=hdnpaymenttypeforupdate.ClientID %>');
            var hdnPTfordelete = document.getElementById('<%=hdnPTfordelete.ClientID %>');

            var EstimateIDForUpdate = document.getElementById('<%=hdnEstimateIDforUpdate.ClientID %>');
            var TotPriceForUpdate = document.getElementById('<%=hdntotsellingpriceforUpdate.ClientID %>');
            var presentvalueforupdate = document.getElementById('<%=hdnpresentvalueforupdate.ClientID %>');
            var hdnbtnvalue = document.getElementById('<%=hdnbtnvalue.ClientID %>');

            var EstID = EstimateIDForUpdate.value;
            var hdnIsPaid = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_hdnIsPaid');
            var lblpaid = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_' + EstID + '_lblIspaid');
            var lblPaymentType = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_lblPaymentType');
            var hdnPaidValue = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_' + EstID + '_hdnPaidValue');
            var lblpaidForEstore = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_lblIspaid');

            //var OutStandingAmount1 = Outstandingamt.value;
            var OutStandingAmount1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Outstandingamt.value, 0, '', false, false, false);
            var totalsellingprice = TotPriceForUpdate.value;

            if (ModuleType == 'orderinvoicesummary') {
                if (OutStandingAmount1 > 0) {
                    var outamt = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                    var totprice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totalsellingprice, 0, '', false, false, false);
                    if (totprice == outamt) {
                        var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                        divpayment.style.display = 'none';
                        lblpaidForEstore.innerHTML = "No";
                        hdnIsPaid.value = "0";
                    }
                    else {
                        var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                        divpayment.style.display = 'block';
                        lblpaidForEstore.innerHTML = "Partially Paid";
                        hdnIsPaid.value = "1";
                        if (hdnbtnvalue.value == 'delete') {
                            lblPaymentType.innerHTML = hdnPTfordelete.value;
                        }
                        else {
                            lblPaymentType.innerHTML = paymenttype.value;
                        }
                    }
                }
                else {
                    var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                    divpayment.style.display = 'block';
                    lblpaidForEstore.innerHTML = "Paid in Full";
                    hdnIsPaid.value = "1";
                    if (hdnbtnvalue.value == 'delete') {
                        lblPaymentType.innerHTML = hdnPTfordelete.value;
                    }
                    else {
                        lblPaymentType.innerHTML = paymenttype.value;
                    }
                }
            }
            else if (ModuleType == 'ojsummary' || ModuleType == 'jobrecordview') {
                if (OutStandingAmount1 > 0) {
                    var outamt = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                    var totprice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totalsellingprice, 0, '', false, false, false);
                    if (totprice == outamt) {
                        var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                        divpayment.style.display = 'none';
                        lblpaidForEstore.innerHTML = "No";
                        hdnIsPaid.value = "0";
                    }
                    else {
                        var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                        divpayment.style.display = 'block';
                        lblpaidForEstore.innerHTML = "Partially Paid";
                        hdnIsPaid.value = "1";
                        if (hdnbtnvalue.value == 'delete') {
                            lblPaymentType.innerHTML = hdnPTfordelete.value;
                        }
                        else {
                            lblPaymentType.innerHTML = paymenttype.value;
                        }
                    }
                } else {
                    var divpayment = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_UCOrderSummary_divOrderIspaid');
                    divpayment.style.display = 'block';
                    lblpaidForEstore.innerHTML = "Paid in Full";
                    hdnIsPaid.value = "1";
                    if (hdnbtnvalue.value == 'delete') {
                        lblPaymentType.innerHTML = hdnPTfordelete.value;
                    }
                    else {
                        lblPaymentType.innerHTML = paymenttype.value;
                    }
                }
            }
            else {
                if (OutStandingAmount1 > 0) {
                    var outamt = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, OutStandingAmount1, 0, '', false, false, false);
                    var totprice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totalsellingprice, 0, '', false, false, false);
                    if (totprice == outamt) {
                        lblpaid.innerHTML = "No";
                        hdnPaidValue.value = "0";
                    }
                    else {
                        lblpaid.innerHTML = "Partially Paid";
                        hdnPaidValue.value = "1";
                    }
                } else {
                    lblpaid.innerHTML = "Paid in Full";
                    hdnPaidValue.value = "1";
                }
            }

            if (hdnbtnvalue.value == 'recordclose') {
                var oWindow = GetRadWindow();
                oWindow.close();
            }
        }

        function CloseWindow(id) {
            var oWindow = GetRadWindow();
            oWindow.close();


            var url = "<%=strSitepath%>invoice/invoices_add.aspx?type=edit&estid=0&ReRun=Y&InvID=" + id + "&estore=";
            oWindow.BrowserWindow.location.href = url;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
