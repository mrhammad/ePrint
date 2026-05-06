<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Client_add_new.ascx.cs" Inherits="ePrint.usercontrol.crm.Client_add_new" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>common/calendar.js?VN='<%=VersionNumber%>'"></script>
<%--<script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<script src="<%=strSitepath %>js/item/purchaseadd.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script type="text/javascript">
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var currentdate = '<%=DateFormat%>';
    var DateFormat = '<%=DateFormat%>';
   
</script>
<style type="text/css">
    .rcbItem {
        font-family: "Verdana", Verdana, Arial, Helvetica, sans-serif !important;
        color: #000000 !important;
        font-weight: normal !important;
        font-size: 11px !important;
    }

    .rcbInput {
        color: #000000 !important;
        font-family: "Verdana", Verdana, Arial, Helvetica, sans-serif !important;
        font-weight: normal !important;
        font-size: 11px !important;
        height: 15px;
    }

    .RadComboBox_Default .rcbInputCell .rcbEmptyMessage {
        font-style: normal !important;
        font-size: 11px !important;
    }
</style>
<%--<asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
    <Services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </Services>
</asp:ScriptManager>--%>
<asp:HiddenField ID="hdnsystemname" runat="server" Value="" />
<asp:HiddenField ID="hdncmpnyaddressid" runat="server" Value="" />
<div class="navigatorpanel show_hide" id="ColourPanel" runat="server">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" nowrap="nowrap">
                        <asp:Label ID="lblAddCompany" runat="server" CssClass="navigatorpanel"> <%=objLangClass.GetLanguageConversion("Add_New_Company")%> </asp:Label>
                        <%--<span class="navigatorpanel">Add New Company</span>--%>
                    </div>
                    <div align="left" nowrap="nowrap">
                        <%--<span class="navigatorpanel">Edit Company</span>--%>
                        <asp:Label ID="lblEditCompany" runat="server" CssClass="navigatorpanel" Text="Edit Company"
                            Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content" runat="server">
    <div id="padding" class="div_spacingcrm">
        <div align="left" style="width: 100%;">
            <span style="float: right; color: red">*
                <%=objLangClass.GetLanguageConversion("Fields_Are_Mandatory")%></span>
        </div>
        <div style="clear: both">
        </div>
        <div align="left" style="width: 100%;">
            <div id="leftcol" style="width: 49%;">
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lblcomptype" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Company_Type")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:Label ID="lblCompanyType" runat="server" CssClass="graytext"></asp:Label>
                        <asp:RadioButton ID="rdProspect" onchange="customerrdbclick()" GroupName="Customer" Text="Prospect"
                            runat="server" />&nbsp;&nbsp;
                        <asp:RadioButton ID="rdCustomer" GroupName="Customer" onchange="customerrdbclick()" Text="Customer" runat="server" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_companyname" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Company_Name")%> </asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_companyname" runat="server" MaxLength="250" SkinID="textPad"
                            onkeypress="javascript:return SaveFocValForMondatoryFld(event);" Width="75%"></asp:TextBox>
                        <span id="spn_companyname" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("Please_Enter_Company_Name")%></span>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass=""
                            Width="" runat="server" Visible="True" ErrorMessage=""
                            ControlToValidate="txt_companyname" ForeColor="Black" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                    </div>
                    <%-- onblur="CallonBlur(this.value,'spn_companyname');removespace();"--%>
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none">
                    <div class="bglabel">
                        <asp:Label ID="lbl_companyalias" runat="server" Text="Company Alias" CssClass="normaltext"></asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_companyalias" runat="server" MaxLength="250" SkinID="textPad"
                            Width="75%"></asp:TextBox>
                        <span id="spn_companyalias" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            <%=objlang.GetValueOnLang("Please enter Company Alias")%>
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_type" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Type")%> </asp:Label>
                    </div>
                    <div class="box">
                        <%-- <asp:DropDownList ID="ddl_type" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>--%>
                        <telerik:RadComboBox ID="ddl_type" TabIndex="2" Width="75%" runat="server" AllowCustomText="True"
                            ClientDropDownClosing="onDropDownClosing" OnClientBlur="onBlurA" EmptyMessage=" None"
                            DataValueField="id" DataTextField="companytype" NoWrap="true">
                            <ItemTemplate>
                                <div onclick="StopPropagation(event)">
                                    <asp:CheckBox runat="server" ID="chk1" onclick="onCheckBoxClick(this)" Text='<%# DataBinder.Eval(Container, "Text") %>' />
                                </div>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <%--<asp:TextBox ID="txt_type" Visible="false" runat="server" SkinID="textPad" Width="100%"></asp:TextBox>--%>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="div_Carrier" runat="server" align="left" style="display: none">
                    <div class="bglabel">
                        <asp:Label ID="lblcarrier" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Carrier") %></asp:Label>
                    </div>
                    <div class="box">
                        <asp:CheckBox ID="chkcarrier" runat="server" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_status" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Account_Status")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddl_status" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_account" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Account_Number")%> </asp:Label>
                        <%--<span style="color: red">*</span>--%>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_accountno" runat="server" SkinID="textPad" MaxLength="20" Width="75%"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                        <%--onblur="CallonBlur(this.value,'spn_account');"--%>
                        <span id="spn_account" style="display: none; width: 170px" class="spanerrorMsg">
                            <%=objlang.GetValueOnLang("Please enter Account No")%>
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_email" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Business_Email")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_email" runat="server" SkinID="textPad" MaxLength="150" Width="75%"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                        <asp:Label ID="lbl_emailValue" runat="server" Text="" Style="margin: 5px 0px 0px 2px; display: none;"></asp:Label>
                        <%--onblur="CallonBlur(this.value,'spn_Email');"--%>
                        <span id="spn_Email" style="display: none; width: 233px" class="spanerrorMsg">
                            <%=objlang.GetValueOnLang("Please enter valid email address")%>
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_url" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("URL")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_url" runat="server" SkinID="textPad" Width="75%" MaxLength="300"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                        <asp:Label ID="lbl_urlValue" runat="server" Text="" Style="margin: 5px 0px 0px 2px; display: none;"></asp:Label>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_defaultinv" runat="server" Text="Default Invoice Address" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <asp:CheckBox ID="chk_defaultinvoiceaddress" runat="server" />
                    </div>
                </div>
                <div align="left" id="div_DeliveryAddress1" runat="server" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_defaultdel" runat="server" Text="Default Delivery Address" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <asp:CheckBox ID="chk_defaultdeliveryaddress" runat="server" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_credit" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Credit_Limit")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_creditlimit" runat="server" Width="75%" MaxLength="20" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_creditref" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Credit_Reference")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_creditref" runat="server" Width="75%" MaxLength="20" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_tax1" runat="server" Text="Tax1" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddl_tax1" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="div_Tax2" runat="server" align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_tax2" runat="server" Text="Tax2" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddl_tax2" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                         <asp:Label ID="Label6" runat="server" Text="Company Tax Takes Precedence" CssClass="normaltext"></asp:Label>
                    </div> 
                     <div class="box">
                         <asp:CheckBox ID="chkTaxPrecedence" runat="server" Text="Tick to make company tax take precedence <br> over product and settings tax" /><br />
                        

                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="div_DeliveryAddressView" runat="server" style="display: none;">
                    <div id="div_DeliveryAddressHeader" style="display: block; float: left;" class="bglabel">
                        <asp:Label ID="lbl_DeliveryAddress" runat="server" Text="Delivery Address"></asp:Label>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Deliveryaddr1Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Deliveryaddr2Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Deliveryaddr3Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Deliveryaddr4Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Deliveryaddr5Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_DeliverycountryValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_DeliveryphoneValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_DeliveryfaxValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <asp:LinkButton ID="lnk_DeliveryEdit" runat="server" Text="Edit" OnClientClick="javascript:opencontacts('deliveryaddress','edit');return false;"></asp:LinkButton>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <asp:Label ID="lbl_DeliverySpliter" runat="server" Text="| "></asp:Label>
                            </div>
                            <div style="float: left;">
                                <asp:LinkButton ID="lnk_DeliveryChange" runat="server" Text="Change/New Address"
                                    OnClientClick="javascript:opencontacts('deliveryaddress','change');return false;"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_InvoiceAddressView" runat="server" style="display: none;">
                    <div id="div_InvoiceAddressHeader" style="display: block; float: left;" class="bglabel">
                        <asp:Label ID="lbl_InvoiceAddress" runat="server" Text="Invoice Address"></asp:Label>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Invoiceaddr1Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Invoiceaddr2Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Invoiceaddr3Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Invoiceaddr4Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_Invoiceaddr5Value" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_InvoicecountryValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_InvoicephoneValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_InvoicefaxValue" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <asp:LinkButton ID="lnk_InvoiceEdit" runat="server" Text="Edit" OnClientClick="javascript:opencontacts('invoiceaddress','edit');return false;"></asp:LinkButton>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <asp:Label ID="lbl_InvoiceSpliter" runat="server" Text="| "></asp:Label>
                            </div>
                            <div style="float: left;">
                                <asp:LinkButton ID="lnk_InvoiceChange" runat="server" Text="Change/New Address" OnClientClick="javascript:opencontacts('invoiceaddress','change');return false;"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="rightcol" style="width: 49%;">
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_terms" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Payment_Terms")%> </asp:Label>
                    </div>
                    <div class="box">
                        <%--  <asp:TextBox ID="txt_paymentterms" runat="server" SkinID="textPad" Width="20%"></asp:TextBox>
                        <span>day(s)</span>--%>
                        <%--<div id="Div_PaymentTerm" runat="server" style="float: left; border:1px solid red; "
                            width="100%" visible="true">--%>
                        <asp:DropDownList ID="ddl_PaymentTerms" runat="server" CssClass="normaltext" Width="75%"
                            onchange="Javascript:GetDays();return false;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdn_PaymentTerm" runat="server" Value="" />
                        <asp:HiddenField ID="hdn_PaymenttermID" runat="server" Value="0" />
                        <asp:Label ID="lbl_PaymentTerm" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_days" runat="server" Text="days" Visible="false"></asp:Label>
                        <%--</div>--%>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_profit" runat="server" CssClass="normaltext"> Markup </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_profitmargin" runat="server" MaxLength="8" Width="20%" SkinID="textPad"
                            onkeypress="javascript:return onlyNumbers(event);" onblur="javascript:todecimal_function(this,this.value);"
                            Style="text-align: right"></asp:TextBox>
                        <%--SavefocusWithValidation(event); onlyNumbers(event);--%>
                        <span>%</span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_taxno" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Tax_Reg_No")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_taxregno" runat="server" Width="75%" MaxLength="20" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_companyno" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Company_Number")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_companyno" runat="server" Width="75%" MaxLength="250" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_acopened" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("A_C_Opened")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_acopened" runat="server" Width="75%" SkinID="textPad" onkeypress="javascript:return SavefocusWithValidation(event);" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_code" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Bank_Code")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_bankcode" runat="server" Width="75%" MaxLength="20" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_bankacno" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Bank_Account_Number")%></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_bankacno" runat="server" Width="75%" MaxLength="200" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_acname" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Account_Name")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_accountname" runat="server" MaxLength="150" Width="75%" SkinID="textPad"
                            onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label15" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Sales_Person")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddl_salesperson" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div style="clear: both">
                </div>
                
                <div id="Div_Referencedby" align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="lbl_Referencedby" runat="server"> </asp:Label>
                        </div>
                        <div id="DivImgRefferedByAdd" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: middle" ID="ImgRefferedByAdd" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New" OnClientClick="javascript:OpenNewReffered();return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_Referencedby" runat="server" AutoCompleteType="disabled" CssClass="textboxnew_estNew"
                            SkinID="textPad" Width="75%" onblur="Javascript:CallNames(this.value);return false;"
                            onkeyup="Javascript:CallNames(this.value);return false;" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddl_Referencedby" runat="server" CssClass="normaltext" Width="75%">
                        </asp:DropDownList>
                        <span id="spn_Referencedby" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg"><%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%></span>
                        <asp:HiddenField ID="hdn_Referencedby" runat="server" Value="" />
                        <div id="divCheck" onmouseover="ShowName('divCheck');" onmouseout="NotShowName('divCheck');">
                        </div>
                    </div>
                </div>
                <div id="div_Supplier" align="left" runat="server" style="display: none">
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Tax_Number")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txt_taxnumber" runat="server" MaxLength="200" Width="75%" SkinID="textPad"
                                onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label3" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Balance")%> </asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txt_balance" runat="server" Width="75%" SkinID="textPad" MaxLength="200"
                                onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                        </div>
                    </div>
                    <%--added on 11-jan-2013  --%>
                </div>
                <div id="div_create_identical_contact" runat="server" align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label4" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Create_Identical_Contact")%> </asp:Label>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <asp:CheckBox ID="Chkcreate_identical_contact" runat="server" />
                    </div>
                </div>
                <div id="DivChkRoyalityFree" runat="server" align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label5" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Royality_Free")%> </asp:Label>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <asp:CheckBox ID="ChkRoyalityFree" runat="server" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; margin: 0px 0px 0px 0px;">
                <div style="width: 50%; margin: 15px 0px 5px 0px;">
                    <div style="padding-left: 5px;">
                        <asp:Label ID="AddressHeader" runat="server" CssClass="headerText"> <%=objLangClass.GetLanguageConversion("Address")%> </asp:Label>
                    </div>
                </div>
                <div id="div_CompanyAddressAdd" style="float: left; width: 100%;">
                    <div id="div_DeliveryAddress" runat="server" style="float: left; width: 49%; display: block;">
                        <div align="left">
                            <div class="bglabel">
                                <%-- <asp:Label ID="lbl_Deliveryaddr1" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Address1") %></asp:Label>--%>
                                <asp:Label ID="lbl_Deliveryaddr1" runat="server" Text="Address 1" CssClass="normaltext"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryaddr1" runat="server" SkinID="textPad" MaxLength="250"
                                    onkeypress="javascript:return SavefocusWithValidation(event);" Width="75%"></asp:TextBox>
                                <%--onblur="CallonBlur(this.value,'spn_addr1');"--%>
                                <span id="spn_addr1" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    <%=objlang.GetValueOnLang("Please enter Address Line 1")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <%-- <asp:Label ID="lbl_Deliveryaddr2" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Address2") %></asp:Label>--%>
                                <asp:Label ID="lbl_Deliveryaddr2" runat="server" Text="Address 2" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryaddr2" runat="server" SkinID="textPad" MaxLength="250"
                                    onkeypress="javascript:return SavefocusWithValidation(event);" Width="75%"></asp:TextBox>
                                <span id="spn_addr2" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    <%=objlang.GetValueOnLang("Please enter Address Line 2")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <%--<asp:Label ID="lbl_Deliveryaddr3" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("City") %></asp:Label>--%>
                                <asp:Label ID="lbl_Deliveryaddr3" runat="server" Text="City" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryaddr3" runat="server" SkinID="textPad" MaxLength="250"
                                    onkeypress="javascript:return SavefocusWithValidation(event);" Width="75%"></asp:TextBox>
                                <span id="spn_addr3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    <%=objlang.GetValueOnLang("Please enter Address Line 3")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Deliveryaddr4" runat="server" Text="Suburb" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryaddr4" runat="server" SkinID="textPad" MaxLength="250"
                                    onkeypress="javascript:return SavefocusWithValidation(event);" Width="75%"></asp:TextBox>
                                <span id="spn_addr4" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    <%=objlang.GetValueOnLang("Please enter Address Line 4")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <%-- <asp:Label ID="lbl_Deliveryaddr5" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Post_Code") %></asp:Label>--%>
                                <asp:Label ID="lbl_Deliveryaddr5" runat="server" Text="Post Code" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryaddr5" runat="server" SkinID="textPad" MaxLength="250"
                                    onkeypress="javascript:return SavefocusWithValidation(event);" Width="75%"></asp:TextBox>
                                <span id="spn_addr5" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    <%=objlang.GetValueOnLang("Please enter Address Line 5")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left" id="divDeliverycountry" runat="server">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Deliverycountry" runat="server" CssClass="normaltext">  <%=objLangClass.GetLanguageConversion("Country")%></asp:Label>
                            </div>
                            <div class="box">
                                <asp:DropDownList ID="ddl_Deliverycountry" runat="server" CssClass="normaltext" Width="75%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left" id="divDeliveryphone" runat="server">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Deliveryphone" runat="server" CssClass="normaltext"> </asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryphone" runat="server" MaxLength="100" Width="75%" SkinID="textPad"
                                    onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                                <span id="spn_Deliveryphone" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg"><%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left" id="divDeliveryfax" runat="server">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Deliveryfax" runat="server" MaxLength="100" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Fax")%></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_Deliveryfax" runat="server" Width="75%" SkinID="textPad" MaxLength="100"
                                    onkeypress="javascript:return SavefocusWithValidation(event);"></asp:TextBox>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="div_edit_changeDelivery" runat="server" align="left" style="display: none;">
                            <div class="bglabel" style="background-color: White;">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div id="div_Description" runat="server" style="float: right; width: 49%; padding: 0px 0px 0px 0px;">
                        <div class="bglabel">
                            <asp:Label ID="lbl_desc" runat="server" CssClass="normaltext">  </asp:Label>&nbsp;
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Height="155px"
                                Width="100%" SkinID="textPad"></asp:TextBox>
                            <span id="spn_description" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                class="spanerrorMsg"><%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%></span>
                            <%-- onkeypress="javascript:return SavefocusWithValidation(event); for bug ID 1891" --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="only5px">
        </div>
        <div align="left" style="width: 100%;">
            <div style="float: left; width: 66%">
                &nbsp;
            </div>
            <div style="float: left;">
                <div id="div_btnCancel" style="float: left">
                    <div id="div_btncnl" style="display: block">
                        <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                            TabIndex="1" OnClientClick="javascript:loadingimage(this.id,'div_btncancelprocess');"
                            OnClick="btncancel_onclick"></asp:Button>
                    </div>
                    <div id="div_btncancelprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>
                <div id="Divdiv_btnsave" runat="server" style="float: left">
                    <div id="div_btnsave" style="display: block">
                        <asp:Button ID="btnsave" runat="server" CssClass="button" Text="save"
                            TabIndex="0" OnClientClick="javascript: var b=Validate();if(b)loadingimage(this.id,'div_btnsaveprocess');return b;" OnClick="btnsave_onclick"></asp:Button>
                    </div>
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
<div style="float: left; width: 700px; margin-top: -8px;">
    &nbsp;
</div>
<div id="divrad" style="display: none; position: absolute; vertical-align: middle; border: 0px solid; z-index: 100; width: 50%"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="300" Style="z-index: 31000" Height="120"
        OnClientClose="RadWinClose" Behaviors="Close, Move,Reload, Resize" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_DeliveryaddressID" runat="server" />
<asp:HiddenField ID="hdn_InvoiceaddressID" runat="server" />
<asp:HiddenField ID="hdn_companytype" runat="server" />
<asp:HiddenField ID="hdn_selectedcounter" runat="server" Value="" />
<script type="text/javascript">
    var currentdate = '<%=newdate %>';
    var DeliveryAddressID = '<%=DeliveryAddressID %>';

    var txt_companyname = document.getElementById("<%=txt_companyname.ClientID %>");
    var txt_companyalias = document.getElementById("<%=txt_companyalias.ClientID %>");
    var txt_accountno = document.getElementById("<%=txt_accountno.ClientID %>");
    var txt_Deliveryaddr1 = document.getElementById("<%=txt_Deliveryaddr1.ClientID %>");
    var txt_Deliveryaddr2 = document.getElementById("<%=txt_Deliveryaddr2.ClientID %>");
    var txt_Deliveryaddr3 = document.getElementById("<%=txt_Deliveryaddr3.ClientID %>");
    var txt_Deliveryaddr4 = document.getElementById("<%=txt_Deliveryaddr4.ClientID %>");
    var txt_Deliveryaddr5 = document.getElementById("<%=txt_Deliveryaddr5.ClientID %>");
    var txt_description = document.getElementById("<%=txt_description.ClientID%>");
    var txt_Deliveryphone = document.getElementById("<%=txt_Deliveryphone.ClientID%>");
    var txt_email = document.getElementById("<%=txt_email.ClientID %>")
    var ddl_Referencedby = document.getElementById("<%=ddl_Referencedby.ClientID %>");
    var hdn_companytype = document.getElementById("<%=hdn_companytype.ClientID %>").value;
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
    var rdProspect = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_rdProspect");
    var rdCustomer = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_rdCustomer");
    var action = "<%=action%>";
    var lbl_Deliveryaddr1 = document.getElementById("<%=lbl_Deliveryaddr1.ClientID%>");
    var lbl_Deliveryaddr2 = document.getElementById("<%=lbl_Deliveryaddr2.ClientID%>");
    var lbl_Deliveryaddr3 = document.getElementById("<%=lbl_Deliveryaddr3.ClientID%>");
    var lbl_Deliveryaddr4 = document.getElementById("<%=lbl_Deliveryaddr4.ClientID%>");
    var lbl_Deliveryaddr5 = document.getElementById("<%=lbl_Deliveryaddr5.ClientID%>");


    var lbl_Deliveryaddr1Value = document.getElementById("<%=lbl_Deliveryaddr1Value.ClientID %>");
    var lbl_Deliveryaddr2Value = document.getElementById("<%=lbl_Deliveryaddr2Value.ClientID %>");
    var lbl_Deliveryaddr3Value = document.getElementById("<%=lbl_Deliveryaddr3Value.ClientID %>");
    var lbl_Deliveryaddr4Value = document.getElementById("<%=lbl_Deliveryaddr4Value.ClientID %>");
    var lbl_Deliveryaddr5Value = document.getElementById("<%=lbl_Deliveryaddr5Value.ClientID %>");
    var lbl_DeliverycountryValue = document.getElementById("<%=lbl_DeliverycountryValue.ClientID %>");
    var lbl_DeliveryphoneValue = document.getElementById("<%=lbl_DeliveryphoneValue.ClientID %>");
    var lbl_DeliveryfaxValue = document.getElementById("<%=lbl_DeliveryfaxValue.ClientID %>");
    var lbl_emailValue = document.getElementById("<%=lbl_emailValue.ClientID %>");
    var lbl_urlValue = document.getElementById("<%=lbl_urlValue.ClientID %>");
    var div_DeliveryAddress = document.getElementById("<%=div_DeliveryAddress.ClientID %>");
    var div_DeliveryAddressView = document.getElementById("<%=div_DeliveryAddressView.ClientID %>");
    var lnk_DeliveryEdit = document.getElementById("<%=lnk_DeliveryEdit.ClientID %>");
    var lbl_DeliverySpliter = document.getElementById("<%=lbl_DeliverySpliter.ClientID %>");
    var lnk_DeliveryChange = document.getElementById("<%=lnk_DeliveryChange.ClientID %>");
    var hdn_DeliveryaddressID = document.getElementById("<%=hdn_DeliveryaddressID.ClientID %>");
    var systemname = document.getElementById("<%=hdnsystemname.ClientID%>").value;

    var lbl_Invoiceaddr1Value = document.getElementById("<%=lbl_Invoiceaddr1Value.ClientID %>");
    var lbl_Invoiceaddr2Value = document.getElementById("<%=lbl_Invoiceaddr2Value.ClientID %>");
    var lbl_Invoiceaddr3Value = document.getElementById("<%=lbl_Invoiceaddr3Value.ClientID %>");
    var lbl_Invoiceaddr4Value = document.getElementById("<%=lbl_Invoiceaddr4Value.ClientID %>");
    var lbl_Invoiceaddr5Value = document.getElementById("<%=lbl_Invoiceaddr5Value.ClientID %>");
    var lbl_InvoicecountryValue = document.getElementById("<%=lbl_InvoicecountryValue.ClientID %>");
    var lbl_InvoicephoneValue = document.getElementById("<%=lbl_InvoicephoneValue.ClientID %>");
    var lbl_InvoicefaxValue = document.getElementById("<%=lbl_InvoicefaxValue.ClientID %>");
    var div_InvoiceAddressView = document.getElementById("<%=div_InvoiceAddressView.ClientID %>");
    var lnk_InvoiceEdit = document.getElementById("<%=lnk_InvoiceEdit.ClientID %>");
    var lbl_InvoiceSpliter = document.getElementById("<%=lbl_InvoiceSpliter.ClientID %>");
    var lnk_InvoiceChange = document.getElementById("<%=lnk_InvoiceChange.ClientID %>");
    var hdn_InvoiceaddressID = document.getElementById("<%=hdn_InvoiceaddressID.ClientID %>");
    var strisreqAdd = '<%=RequiredAddress %>';
    var RequiredAddressCustomer = '<%=RequiredAddress1 %>'

    function GetClientAlias() {
        txt_companyalias.value = txt_companyname.value.replace(' ', '');
    }
    function removespace() {
        //txt_companyname.value = txt_companyname.value.replace(/^\s+/, '');
    }

    if (rdProspect == null) {
        rdProspect = false;
    }
    var CheckFinal = 0;
    function Validate() {

        CheckFinal = 0;        
        
        var RequiredAddress = 0;
        var ClientID = '<%=ClientID %>';
        if (txt_companyname.value.trim() == "") {
            document.getElementById("spn_companyname").style.display = "block";
            txt_companyname.focus();
            CheckFinal = 1;
        }
        else {
            document.getElementById("spn_companyname").style.display = "none";
            CheckFinal = 0;
        }

        if (strisreqAdd != '') {
            var isreqAdd = strisreqAdd.split(',')
            for (var i = 0; i < isreqAdd.length; i++) {
                if (isreqAdd[i] == '1') {
                    if (txt_Deliveryaddr1.value.trim() == '') {
                        document.getElementById('spn_addr1').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr1').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '2') {
                    if (txt_Deliveryaddr2.value.trim() == '') {
                        document.getElementById('spn_addr2').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr2').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '3') {
                    if (txt_Deliveryaddr3.value.trim() == '') {
                        document.getElementById('spn_addr3').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr3').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '4') {
                    if (txt_Deliveryaddr4.value.trim() == '') {
                        document.getElementById('spn_addr4').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr4').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '5') {
                    if (txt_Deliveryaddr5.value.trim() == '') {
                        document.getElementById('spn_addr5').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr5').style.display = "none";
                    }
                }
            }
        }

        //For only fsg system. systemname == "fsg" &&   && systemname == "fsg" && action=="" && action==""
        if ((systemname == "fsg" && hdn_companytype == "prospect" && action == "") || (rdProspect.checked == true && systemname == "fsg" && action == "")) {
           

            if (txt_Deliveryaddr1.value.trim() == '') {
                document.getElementById('spn_addr1').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr1').style.display = "none";
            }

            //if (txt_Deliveryaddr2.value.trim() == '') {
            //    document.getElementById('spn_addr2').style.display = "block";
            //    CheckFinal = 1;
            //}
            //else {
            //    document.getElementById('spn_addr2').style.display = "none";
            //}

            if (txt_Deliveryaddr3.value.trim() == '') {
                document.getElementById('spn_addr3').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr3').style.display = "none";
            }

            if (txt_Deliveryaddr4.value.trim() == '') {
                document.getElementById('spn_addr4').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr4').style.display = "none";
            }

            if (txt_Deliveryaddr5.value.trim() == '') {
                document.getElementById('spn_addr5').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr5').style.display = "none";
            }

            if (txt_Deliveryphone.value.trim() == "") {
                document.getElementById("spn_Deliveryphone").style.display = "block";
                txt_Deliveryphone.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Deliveryphone").style.display = "none";
            }

            if (ddl_Referencedby.value == "0") {
                document.getElementById("spn_Referencedby").style.display = "block";
                ddl_Referencedby.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Referencedby").style.display = "none";
            }

            if (txt_description.value == "" || txt_description.value.trim() == "") {
                document.getElementById("spn_description").style.display = "block";
                txt_description.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_description").style.display = "none";
                txt_description.focus();
            }
        }//ends here

        if ((systemname == "fsg" && hdn_companytype == "prospect") && action == "edit") {
            
            if (txt_description.value == "" || txt_description.value.trim() == "") {
                document.getElementById("spn_description").style.display = "block";
                txt_description.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_description").style.display = "none";
                txt_description.focus();
            }

            if (ddl_Referencedby.value == "0") {
                document.getElementById("spn_Referencedby").style.display = "block";
                ddl_Referencedby.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Referencedby").style.display = "none";
            }
        }


    //    //if (ClientID != 0) {
    //    //    if (CheckFinal == 1) {
    //    //        return false;
    //    //    }
    //    //    else {
    //    //        return true;
    //    //    }
    //    //    }
    //    //else {
    //        if (RequiredAddress == 1 || CheckFinal == 1) {
    //            return false;
    //        }
    //    else {
    //            return true;
    //    }
        ////}

        //if (ClientID != 0) {
        //    if (CheckFinal == 1) {
        //        return false;
        //    }
        //    else {
        //        return true;
        //    }
        //}
        //else {
        if (hdn_companytype != "customer" && action == "edit" && RequiredAddress == 1)
        {
            if (txt_companyname.value.trim() == "") {
                document.getElementById("spn_companyname").style.display = "block";
                txt_companyname.focus();
                CheckFinal = 1;
                
            }
            else {
                document.getElementById("spn_companyname").style.display = "none";
                CheckFinal = 0;
                //return true;
            }
        }
        // ticket 96949
         //if (EmailValidate() == false) {
         //    CheckFinal = 1;
         //}
            if (RequiredAddress == 1 || CheckFinal == 1) {
                return false;
            }
            else {
                return true;
            }
        //}
    
    }

    function customerrdbclick() {
       
        //systemname == "fsg" &&
        if (systemname == "fsg" && rdCustomer.checked == true) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc').innerHTML = '<%=objLangClass.GetLanguageConversion("Description")%>';
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone').innerHTML = '<%=objLangClass.GetLanguageConversion("Telephone")%>';
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby').innerHTML = '<%=objLangClass.GetLanguageConversion("Referred_By")%>';

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.replace('*', '').trim();

            //var RequiredAddressCustomer = '<%=RequiredAddress %>';
            if (RequiredAddressCustomer != '') {
                var RequiredAddressCustomer1 = RequiredAddressCustomer.split(',')
                for (var i = 0; i < RequiredAddressCustomer1.length; i++) {
                    if (RequiredAddressCustomer1[i] == '1') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "1,";
                    }
                    if (RequiredAddressCustomer1[i] == '2') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "2,";
                    }
                    if (RequiredAddressCustomer1[i] == '3'){
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "3,";
                    }
                    if (RequiredAddressCustomer1[i] == '4') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "4,";
                    }
                    if (RequiredAddressCustomer1[i] == '5') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "1,";
                    }
                }
            }
            document.getElementById("spn_companyname").style.display = "none";
            document.getElementById("spn_description").style.display = "none";
            document.getElementById("spn_Deliveryphone").style.display = "none";
            document.getElementById("spn_Referencedby").style.display = "none";
            document.getElementById('spn_addr5').style.display = "none";
            document.getElementById('spn_addr4').style.display = "none";
            document.getElementById('spn_addr3').style.display = "none";
            document.getElementById('spn_addr2').style.display = "none";
            document.getElementById('spn_addr1').style.display = "none";
        }
        //systemname == "fsg" &&
        if (systemname == "fsg" && rdProspect.checked == true) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc').innerHTML = '<%=objLangClass.GetLanguageConversion("Description")%>' + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone').innerHTML = '<%=objLangClass.GetLanguageConversion("Telephone")%>' + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby').innerHTML = '<%=objLangClass.GetLanguageConversion("Referred_By")%>' + "<span style='color: red;'>&nbsp;*</span>";

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.replace('*', '').trim();

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            //document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";

            strisreqAdd = '';

            document.getElementById("spn_companyname").style.display = "none";
            document.getElementById("spn_description").style.display = "none";
            document.getElementById("spn_Deliveryphone").style.display = "none";
            document.getElementById("spn_Referencedby").style.display = "none";
            document.getElementById('spn_addr5').style.display = "none";
            document.getElementById('spn_addr4').style.display = "none";
            document.getElementById('spn_addr3').style.display = "none";
            document.getElementById('spn_addr2').style.display = "none";
            document.getElementById('spn_addr1').style.display = "none";
        }
    }

    // by natraj, calling Onblur.
    function EmailValidate() {

        debugger;
        var BusinessEmail = document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_txt_email').value;
        value = BusinessEmail
        //var strs;
        //if (value.indexOf(',') != -1) {
        //    strs = value.split(',');
        //}

        var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (value.trim() != "") {
            if (!EmailExn.test(value)) {
                document.getElementById("spn_Email").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_txt_email').focus();
                return false
            }
            else {
                document.getElementById("spn_Email").style.display = "none";
            }
        }
        else {
            document.getElementById("spn_Email").style.display = "none";
        }
    }

    function SendClientAddressIDandName(AddressID, AddLine1, City, State, ZipCode, Country, Phone, Fax, Email, AddressLine2, URL, AddressTo) {
        //alert(AddressID + ',' + AddLine1 + ',' + City + ',' + State + ',' + ZipCode + ',' + Country + ',' + Phone + ',' + Fax + ',' + Email);
        if (hdn_InvoiceaddressID.value == AddressID && hdn_InvoiceaddressID.value == AddressID) {
            AddressTo = 'both';
        }

        if (AddressTo == 'delivery') {
            hdn_DeliveryaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Deliveryaddr1Value.innerHTML = AddLine1;
            else
                lbl_Deliveryaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Deliveryaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Deliveryaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Deliveryaddr3Value.innerHTML = City;
            else
                lbl_Deliveryaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Deliveryaddr4Value.innerHTML = State;
            else
                lbl_Deliveryaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Deliveryaddr5Value.innerHTML = ZipCode;
            else
                lbl_Deliveryaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_DeliverycountryValue.innerHTML = Country;
            else
                lbl_DeliverycountryValue.innerHTML = '';

            if (Phone != '')
                lbl_DeliveryphoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_DeliveryphoneValue.innerHTML = '';

            if (Fax != '')
                lbl_DeliveryfaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_DeliveryfaxValue.innerHTML = '';

            lnk_DeliveryEdit.style.display = "block";
            lbl_DeliverySpliter.style.display = "block";
        }
        if (AddressTo == 'invoice') {
            hdn_InvoiceaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Invoiceaddr1Value.innerHTML = AddLine1;
            else
                lbl_Invoiceaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Invoiceaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Invoiceaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Invoiceaddr3Value.innerHTML = City;
            else
                lbl_Invoiceaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Invoiceaddr4Value.innerHTML = State;
            else
                lbl_Invoiceaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Invoiceaddr5Value.innerHTML = ZipCode;
            else
                lbl_Invoiceaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_InvoicecountryValue.innerHTML = Country;
            else
                lbl_InvoicecountryValue.innerHTML = '';

            if (Phone != '')
                lbl_InvoicephoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_InvoicephoneValue.innerHTML = '';

            if (Fax != '')
                lbl_InvoicefaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_InvoicefaxValue.innerHTML = '';

            lnk_InvoiceEdit.style.display = "block";
            lbl_InvoiceSpliter.style.display = "block";
        }
        if (AddressTo == 'both') {
            // DELIVERY
            hdn_DeliveryaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Deliveryaddr1Value.innerHTML = AddLine1;
            else
                lbl_Deliveryaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Deliveryaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Deliveryaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Deliveryaddr3Value.innerHTML = City;
            else
                lbl_Deliveryaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Deliveryaddr4Value.innerHTML = State;
            else
                lbl_Deliveryaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Deliveryaddr5Value.innerHTML = ZipCode;
            else
                lbl_Deliveryaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_DeliverycountryValue.innerHTML = Country;
            else
                lbl_DeliverycountryValue.innerHTML = '';

            if (Phone != '')
                lbl_DeliveryphoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_DeliveryphoneValue.innerHTML = '';

            if (Fax != '')
                lbl_DeliveryfaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_DeliveryfaxValue.innerHTML = '';

            lnk_DeliveryEdit.style.display = "block";
            lbl_DeliverySpliter.style.display = "block";

            // INVOICE
            hdn_InvoiceaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Invoiceaddr1Value.innerHTML = AddLine1;
            else
                lbl_Invoiceaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Invoiceaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Invoiceaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Invoiceaddr3Value.innerHTML = City;
            else
                lbl_Invoiceaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Invoiceaddr4Value.innerHTML = State;
            else
                lbl_Invoiceaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Invoiceaddr5Value.innerHTML = ZipCode;
            else
                lbl_Invoiceaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_InvoicecountryValue.innerHTML = Country;
            else
                lbl_InvoicecountryValue.innerHTML = '';

            if (Phone != '')
                lbl_InvoicephoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_InvoicephoneValue.innerHTML = '';

            if (Fax != '')
                lbl_InvoicefaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_InvoicefaxValue.innerHTML = '';

            lnk_InvoiceEdit.style.display = "block";
            lbl_InvoiceSpliter.style.display = "block";
        }

    }

    function opencontacts(val, type) {
        if (val == 'deliveryaddress') {
            if (type == 'change') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=client&pagename=clientchange&addressto=delivery", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'edit') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=edit&pg=client&addressid=" + hdn_DeliveryaddressID.value + "&pagename=clientedit&addressto=delivery", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        if (val == 'invoiceaddress') {
            if (type == 'change') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=client&pagename=clientchange&addressto=invoice", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'edit') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=edit&pg=client&addressid=" + hdn_InvoiceaddressID.value + "&pagename=clientedit&addressto=invoice", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
    }

    function onlyNumbers(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode != 43 && charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57)) {
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
        //alert(txtobj.value);
    }

    function RadWinClose() {
        //document.getElementById("ds00").style.display = "none";
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
</script>
<asp:HiddenField ID="hdn_ddlreferedbySel" runat="server" />
<asp:HiddenField ID="hdn_ddlRefSelIndexOnEditLoad" runat="server" Value="0" />
<script>
    var ddl_Referencedby = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby");
    var hdn_ddlreferedbySel = document.getElementById("<%=hdn_ddlreferedbySel.ClientID %>");
    var hdn_ddlRefSelIndexOnEditLoad = document.getElementById("<%=hdn_ddlRefSelIndexOnEditLoad.ClientID %>");
    //    function GetddlSelValue(SelIndex) {
    //        if (SelIndex == "" || SelIndex == 0) {
    //            SelIndex = 0;
    //            ddl_Referencedby.options[SelIndex].text = "None";
    //        }
    //        else
    //            hdn_ddlreferedbySel.value = ddl_Referencedby.options[SelIndex].text;
    //    }
    // GetddlSelValue(hdn_ddlRefSelIndexOnEditLoad.value);

    //    function CallNames(ReferenceName) {
    //        //        AutoFill.ClientReferencedByName_Select(ReferenceName, Onsuccuss);
    //        AutoFill.ClientReferencedByName_Select(ReferenceName, Onsuccuss);
    //    }
    //    function Onsuccuss(result) {
    //        if (result != '') {
    //            var StrName = '';
    //            ShowName('divCheck');
    //            var divCheck = document.getElementById("divCheck");
    //            var SpltName = result.split('¶');
    //            for (var i = 0; i < SpltName.length - 1; i++) {
    //                StrName += "<div class='divpad' style='height:16px;z-index:1000;'>";
    //                StrName += "&nbsp;&nbsp;<a href='#' style='color:black;' onclick=\"javascript:GetReferencedName('" + SpltName[i] + "')\">" + SpltName[i] + "</a>";
    //                StrName += "</div>";
    //            }
    //            divCheck.innerHTML = StrName;
    //        }
    //        else {
    //            NotShowName('divCheck');
    //        }
    //    }
    function ShowName(Div) {
        document.getElementById(Div).style.display = "block";

    }
    function NotShowName(Div) {
        document.getElementById(Div).style.display = "none";
    }
    //    function GetReferencedName(ReferencedName) {
    //        //        var txt_Referencedby = document.getElementById("<%=txt_Referencedby.ClientID%>");
    //        var ddl_Referencedby = document.getElementById("<%=ddl_Referencedby.ClientID%>");
    //        ddl_Referencedby.value = ReferencedName;
    //        NotShowName('divCheck');
    //    }

</script>
<style>
    #divCheck {
        float: left;
        position: absolute;
        display: none;
        border: solid 1px silver;
        overflow-x: hidden;
        overflow-y: scroll;
        width: 237px;
        height: 70px;
        background-color: white;
    }

    #div_list {
        float: left;
        position: absolute;
        display: none;
        border: solid 1px silver;
        overflow-x: hidden;
        overflow-y: scroll;
        width: 175px;
        height: 75px;
        background-color: white;
    }

    .divpad {
        padding: 2px;
    }
</style>
<script>
    function GetDays() {
        var ddl_PaymentTerm = document.getElementById("<%=ddl_PaymentTerms.ClientID%>");
        var hdn_PaymentTerm = document.getElementById("<%=hdn_PaymentTerm.ClientID%>");
        var lbl_PaymentTerm = document.getElementById("<%=lbl_PaymentTerm.ClientID%>");
        var hdn_PaymenttermID = document.getElementById("<%=hdn_PaymenttermID.ClientID%>");

        var splitPayment = hdn_PaymentTerm.value.split('»');
        for (var i = 0; i < splitPayment.length; i++) {
            var Payment = splitPayment[i].split('‡');
            if (Payment[1] == ddl_PaymentTerm.value) {
                lbl_PaymentTerm.innerHTML = Payment[0];
                hdn_PaymenttermID.value = Payment[1];

            }
        }
    }
    function SaveFocValForMondatoryFld() {

        if (typeof e == 'undefined' || window.event) { e = window.event; }
        if (e.keyCode == 13) {
            if (txt_companyname.value != "") {
                document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_btnsave').click();
            }
            else {
                Validate();
                return false;
            }
        }
    }
    function SavefocusWithValidation() {
        if (typeof e == 'undefined' || window.event) { e = window.event; }
        if (e.keyCode == 13) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_btnsave').click();
            return false;
        }
    }
</script>
<script type="text/javascript">
    function OpenNewReffered() {
        window.radopen("<%=nmsCommon.global.sitePath()%>common/add_new_referredby.aspx");
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
</script>
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script type="text/javascript">
        function CallNow() {           
            //document.getElementById("div_loading").style.display = "block";
            var SupplerIDnew = '<%=strFinalData %>';
            var SupplerID = SupplerIDnew.split('~')[0];
            var SupplerDDlSupID = SupplerIDnew.split('~')[1];
            var SupplerDDlSupName = SpecialDecode(SupplerIDnew.split('~')[2]);
            var SupplerContactID = SupplerIDnew.split('~')[3];
            window.parent.ReloadSupplier(SupplerID, SupplerDDlSupName, SupplerDDlSupID, SupplerContactID);
            setTimeout("TakeOut()", 500);
        }
        function TakeOut() {
            window.close();
        }
        CallNow();
    </script>
</asp:Panel>
 <%-- added for Optimization pnl_productsummary_supplieradd --%>
<asp:Panel ID="pnl_productsummary_supplieradd" runat="server" Visible="false">
    <script type="text/javascript">

        function Close() {
            
            var oWindow = GetRadWindow();           
            oWindow.close();
            return false;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
     

        function ddl_bind_supplier() {            
            
            var supplierid = document.getElementById("<%=hid_ClientID.ClientID %>").value;
            var txtsuppliername = document.getElementById("<%=txt_companyname.ClientID %>").value;
            window.parent.Bind_supplier(supplierid, txtsuppliername);
            Close();
        }
        ddl_bind_supplier();
    </script>
</asp:Panel>
<asp:Panel ID="pnl_supplier_add_frominventory" runat="server" Visible="false">
    <script type="text/javascript">
        function Close() {

            var oWindow = GetRadWindow();
            oWindow.close();
            return false;
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function ddl_bind_supplier() {

            var supplierid = document.getElementById("<%=hid_ClientID.ClientID %>").value;
            var txtsuppliername = document.getElementById("<%=txt_companyname.ClientID %>").value;
            window.parent.Bind_Supplier_inventory(supplierid, txtsuppliername);
            Close();
        }
        ddl_bind_supplier();
    </script>
</asp:Panel>
<%--<asp:Panel ID="pnlContactClose" runat="server" Visible="false">

    <script type="text/javascript">
        function CallNow_Contact() {
            var ContactIDnew = '<%=strFinalContactData %>';
            var ContactID = ContactIDnew.split('~')[0];
            var ContactDDlConID = ContactIDnew.split('~')[1];
            var ContactDDlConName = ContactIDnew.split('~')[2];

            window.parent.ReloadContact_new(ContactID, ContactDDlConName, ContactDDlConID);
            setTimeout("TakeOut()", 1000);
        }
        function TakeOut() {
            window.close();
        }
        CallNow_Contact();
    </script>

</asp:Panel>--%>
<asp:Panel ID="pnlWinClose1" runat="server" Visible="false">
    <script type="text/javascript">
        var ClientID = hid_ClientID.value;
        window.parent.Supplier_ReBind(ClientID, txt_companyname.value);
        setTimeout("TakeOut()", 700);
        function TakeOut() {
            window.close();
        }
    </script>
</asp:Panel>
<script language="javascript" type="text/javascript">
    function Close() {
        //alert("close");
        var oWindow = GetRadWindow();
        //alert(oWindow);
        //oWindow.argument = "hai";
        oWindow.close();
        return false;
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    //added for 13891
    function ddl_bind_supplier() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_UCInventory_Add_ddlSupplier');
        var supplierid = document.getElementById("<%=hid_ClientID.ClientID %>").value;
        var txtsuppliername = document.getElementById("<%=txt_companyname.ClientID %>").value;
        ddl.options.add(new Option(txtsuppliername, supplierid, ddl.options.length));
        ddl.selectedIndex = ddl.options.length - 1;
        close();
    }
</script>
<script language="javascript" type="text/javascript">

    function onDropDownClosing(sender, args) {
        cancelDropDownClosing = false;
    }

    function onBlurA(sender) {
        cancelFirstCombo = false;
    }

    function StopPropagation(e) {
        //cancel bubbling
        e.cancelBubble = true;
        if (e.stopPropagation) {
            e.stopPropagation();
        }
    }

    function onCheckBoxClick(chk) {

        var combo = $find("<%= ddl_type.ClientID %>");
        //Prevent second RadComboBox from closing.
        cancelDropDownClosing = true;
        var text = "";
        var values = "";
        var items = combo.get_items();
        for (var i = 0; i < items.get_count() ; i++) {
            var item = items.getItem(i);
            var chk1 = $get(combo.get_id() + "_i" + i + "_chk1");
            if (chk1.checked) {
                text += item.get_text() + ", ";
                values += item.get_value() + ",";
            }
        }
        text = removeLastComma(text);
        values = removeLastCommaNew(values);

        if (text.length > 0) {
            combo.set_text(text);
        }
        else {
            combo.set_text(" None");
        }
    }

    function removeLastComma(str) {

        return str.replace(/, $/, "");
    }

    function removeLastCommaNew(str) {

        return str.replace(/,$/, "");
    }

    function pageLoad() {
        
        var combo = $find("<%= ddl_type.ClientID %>");
        var input = combo.get_inputDomElement();
        input.onkeydown = onKeyDownHandler;
    }
    function onKeyDownHandler(e) {
        if (!e)
            e = window.event;
        e.returnValue = false;
        if (e.preventDefault) {
            e.preventDefault();
        }
    }

</script>
<asp:Panel ID="pnl_Supp_Purchase" runat="server" Visible="false">
    <script type="text/javascript">
        if (document.getElementById("<%=chkcarrier.ClientID %>").checked) {
            var ClientID = hid_ClientID.value;
            window.parent.ReBind_Supplier(ClientID, txt_companyname.value);
        }
        setTimeout("TakeOut()", 700);
        function TakeOut() {
            Close();
        }
    </script>
</asp:Panel>
<asp:Panel ID="pnlWinClose2" runat="server" Visible="false">
    <script type="text/javascript">
        setTimeout("TakeOut()", 500);
        function TakeOut() { window.close(); }
    </script>
</asp:Panel>
<asp:Panel ID="Panel_Inventoryadd" runat="server" Visible="false">
    <asp:PlaceHolder ID="plhDiv" runat="server"></asp:PlaceHolder>
</asp:Panel>
