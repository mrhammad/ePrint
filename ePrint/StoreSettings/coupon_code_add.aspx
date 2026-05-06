<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="coupon_code_add.aspx.cs" Inherits="ePrint.StoreSettings.coupon_code_add" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .btnCreateCode {
            background-color: #505050;
            color: white;
            padding: 7px 10px 7px 10px;
            cursor: pointer;
        }

        .btnCreateCode {
            background-color: #505050;
            color: white;
            padding: 7px 10px 7px 10px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var Mode = '<%=action %>';
        var AccountID = '<%=AccountID %>';       
    </script>
    <!--POPUP START-->
    <div>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div style="float: left;" class="estore_settingBox">
        <UC:Header ID="header" runat="server" />
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Coupon_Code")%>
                                    <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                        href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                        <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                    </a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="div_Main" class="" style="width: 100%; padding-left: 5px; height: 100%">
            <div>
                <div align="left">
                    <div style="width: 65%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div align="left" style="width: 100%; padding-left: 6px;" class="mis_header_panel">
                    <div style="font-weight: bold; margin-bottom: 1%;">
                        <%=objLanguage.GetLanguageConversion("Add_Coupon_Code")%>
                    </div>
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel" style="width: 30%;">
                                <asp:Label ID="lblCouponCode" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Coupon_Code")%><span style="color:red;"> *</span></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtCouponCode" runat="server" Width="100%" CssClass="textboxnew" MaxLength="200"></asp:TextBox>
                                <span class="RFV_Message" id="spn_couponcodevalidation" style="display: none;width: auto;padding: 2px 3px 2px 3px;"></span>
                            </div>
                            <div id="div_CouponCode_CreateMultiple" runat="server">
                                <div class="bglabel" style="width: 30%;">
                                    <asp:Label ID="lbl_CreateMultipleCouponCode" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Create_Multiple_CouponCode")%></asp:Label>
                                </div>
                                <div class="checkboxstoresetting">
                                    <asp:CheckBox ID="chk_CreateMultipleCouponCode" runat="server" OnClick="EnableCouponCoderange();" />
                                </div>
                            </div>
                            <div id="div_CouponCodeRange" style="display: none;">
                                <div class="bglabel" style="width: 30%;">
                                    <asp:Label ID="lbl_CouponCodeRange" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Range_will_be_suffix_to_couponcode")%></asp:Label>
                                </div>
                                <div class="box">
                                    <span>From </span>
                                    <asp:TextBox ID="txt_CouponCodeFrom" runat="server" CssClass="textboxnew" Width="41px" Style="text-align: right; padding-right: 4px;" MaxLength="255" onkeydown="return isNumeric(event.keyCode);" onpaste="return false;"></asp:TextBox>
                                    <span>To </span>
                                    <asp:TextBox ID="txt_CouponCodeTo" runat="server" CssClass="textboxnew" Width="41px" Style="text-align: right; padding-right: 4px;" MaxLength="255" onkeydown="return isNumeric(event.keyCode);" onpaste="return false;"></asp:TextBox>
                                    <span class="RFV_Message" id="spn_FromToValidation" style="display: none;width: auto;padding: 2px 3px 2px 3px;"></span>
                                </div>
                            </div>
                            <div class="bglabel" style="width: 30%;">
                                <asp:Label ID="lblUserfriendly" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                <div style="margin-top: 2px;">
                                    <asp:Label ID="Label1" runat="server" CssClass="smallfontgrey">(<%=objLanguage.GetLanguageConversion("to_be_shared_and_used_by_customers")%>)</asp:Label>
                                </div>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtUserfriendly" runat="server" Width="100%" CssClass="textboxnew" MaxLength="200"></asp:TextBox>
                            </div>
                            <div class="bglabel" style="width: 30%;">
                                <asp:Label ID="lblDiscount" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Discount")%><span style="color:red;"> *</span></asp:Label>
                            </div>
                            <div class="box" style="width: 55.6%">
                                <asp:DropDownList ID="ddl_CouponCode_TypeSelect" runat="server" Style="width: 12%">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCouponCodeDiscount" runat="server" CssClass="textboxnew" Style="width: 84%" MaxLength="20" Onblur="javascript: validDiscount(this,this.value);"></asp:TextBox>
                                <span class="RFV_Message" id="spn_discountValidation" style="display: none;width: auto;padding: 2px 10px 2px 10px;"></span>
                            </div>
                            <div id="div_CouponCode_CanbeuseMultipletime" runat="server">
                                <div class="bglabel" style="width: 30%;">
                                    <asp:Label ID="lbl_CouponCode_CheckMultipleTime" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Can_it_be_used_multiple_time")%></asp:Label>
                                </div>
                                <div class="checkboxstoresetting">
                                    <asp:CheckBox ID="chk_CouponCode_CanbeusedMultipleTimes" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div style="margin-left: 16%; margin-top: 1%; float: left; margin-bottom: 1%;">
                        <asp:Button ID="btnCouponCode" runat="server" CssClass="button"
                            OnClick="btnCouponCode_Onclick" OnClientClick="javascript:var a=validateCouponCode();if(a)loadingimage(this.id,'div_btnsaveprocess_CouponCode');return a;" />
                        <div id="div_btnsaveprocess_CouponCode" class="button" align="center" style="width: 35px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" lang="javascript">
        var txtCouponCode = document.getElementById('<%=txtCouponCode.ClientID%>');
        var txtUserfriendly = document.getElementById('<%=txtUserfriendly.ClientID%>');
        var txtCouponCodeDiscount = document.getElementById('<%=txtCouponCodeDiscount.ClientID%>');
        var btnCouponCode = document.getElementById('<%=btnCouponCode.ClientID%>');
        var chk_CreateMultipleCouponCode = document.getElementById('<%=chk_CreateMultipleCouponCode.ClientID%>');
        var txt_CouponCodeFrom = document.getElementById('<%=txt_CouponCodeFrom.ClientID%>');
        var txt_CouponCodeTo = document.getElementById('<%=txt_CouponCodeTo.ClientID%>');
        var spn_FromToValidation = document.getElementById('spn_FromToValidation');
        var ddl = document.getElementById("<%=ddl_CouponCode_TypeSelect.ClientID%>");
        var spn_couponcodevalidation = document.getElementById('spn_couponcodevalidation');

        function validDiscount(txtobj) {
            var value = RemoveDollorAndComma(txtobj.value);
            if (!isNaN(value) && Number(value)) {
                if (Number(value) > 100 && ddl.selectedIndex == 0) {
                    txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
                }
                else {
                    txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, 0, '', false, false, false);
                    spn_discountValidation.style.display = 'none';
                }
            }
            else {
                txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
            }
        }

        function validateCouponCode() {
            var Valid = true;
            if (txtCouponCode.value == '') {
                spn_couponcodevalidation.style.display = 'block';
                spn_couponcodevalidation.innerHTML = 'Please enter coupon code';
                Valid = false;
                txtCouponCode.focus();
                return false;
            } else {
                spn_couponcodevalidation.style.display = 'none';
                Valid = true;
            }
            if (chk_CreateMultipleCouponCode.checked) {
                if (txt_CouponCodeFrom.value == '') {
                    Valid = false;
                    txt_CouponCodeFrom.focus();
                    return false;
                }
                else if (txt_CouponCodeTo.value == '') {
                    Valid = false;
                    txt_CouponCodeTo.focus();
                    return false;
                }
                else if (txt_CouponCodeFrom.value != '' && txt_CouponCodeTo.value != '') {
                    if ((Number(txt_CouponCodeFrom.value) < Number(txt_CouponCodeTo.value))) {
                        Valid = true;
                        spn_FromToValidation.style.display = 'none';
                    } else {
                        spn_FromToValidation.style.display = 'block';
                        spn_FromToValidation.innerHTML = 'Please enter To value greater than From value';
                        txt_CouponCodeTo.focus();
                        Valid = false;
                        return false;
                    }
                }
            } else {
                Valid = true;
            }
            if (Number(txtCouponCodeDiscount.value) == 0) {
                Valid = false;
                txtCouponCodeDiscount.focus();
                spn_discountValidation.style.display = 'block';
                spn_discountValidation.innerHTML = 'Please enter Discount value';
                return false;
            } else {
                Valid = true;
            }
            if (Valid) {
                return true;
            }
        }

        function CopyUserFriendlyname(ID, value) {
            if (ID != null && ID != undefined && txtUserfriendly.value == '') {
                txtUserfriendly.value = value;
            }
        }

        function isNumeric(keyCode) {
            return ((keyCode >= 48 && keyCode <= 57) || keyCode == 8 || keyCode == 46 || keyCode == 37 || keyCode == 39 || keyCode == 9 ||
                    (keyCode >= 96 && keyCode <= 105))
        }

        function EnableCouponCoderange() {
            if (chk_CreateMultipleCouponCode.checked) {
                document.getElementById("div_CouponCodeRange").style.display = "block";
            } else {
                document.getElementById("div_CouponCodeRange").style.display = "none";
            }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
