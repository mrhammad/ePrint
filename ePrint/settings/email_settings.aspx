<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="email_settings.aspx.cs" Inherits="ePrint.settings.email_settings" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <div align="left">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel" runat="server" id="spnheader">
                                    <%=objlang.GetLanguageConversion("Settings")%>:&nbsp;<%=objlang.GetLanguageConversion("Email_Settings")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div align="left" style="width: 100%" class="mis_header_panel">
                    <table width="43%" border="0" cellpadding="1" cellspacing="1">
                        <tr>
                            <td style="width: 150px;">
                                <asp:Label ID="lbl_fromemail" CssClass="bglabel" Width="150px" Text="From Email Name"
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_fromemail" Width="238px" Style="margin-top: -1px;" runat="server"
                                    MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 30.5%;">
                                <asp:RequiredFieldValidator ID="rfv_fromemail" Visible="true" CssClass="errorMsg"
                                    ControlToValidate="txt_fromemail" runat="server" Display="Dynamic" ErrorMessage="Please enter from email"
                                    ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px;"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <div align="left">
                        <asp:RadioButton ID="rdbFromEprint" runat="server" Text="Send all emails from eprint"
                            Checked="false" GroupName="Email" onclick="checkonce();" /></div>
                    <div id="div_email" style="padding-left: 20px; display: none;">
                        <br />
                        <div>
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="Chk_cc" runat="server" Text="CC" Checked="false" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_cc" TextMode="MultiLine" CssClass="textpad" runat="server" Width="320px"
                                            onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgCC');"></asp:TextBox>
                                    </td>
                                    <td>
                                        <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                            <img alt="" id="img_help_productthumbnail" runat="server" src="../images/Help-icon.png"
                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <div>
                                            <span id="Spn_ErrMsgCC" class="RFV_Message autoccerrormsg" style="width: auto; padding-left: 4px;
                                                padding-right: 4px;"></span>
                                            <asp:HiddenField ID="hdn_cc" runat="server" Value="" />
                                            <span id="SpnChkErr" class="RFV_Message autoccerrormsg" style="width: auto; padding-left: 4px;
                                                padding-right: 4px;">Please enter email address</span>
                                        </div>
                                        <i class="graytext" style="font-weight: normal; display: none; padding-left: 5px">[Please
                                            separate multiple email addresses with a comma] </i>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="Chk_bcc" runat="server" Text="BCC" Checked="false" />&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_bcc" TextMode="MultiLine" CssClass="textpad" runat="server"
                                            Width="320px" onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgBCC');"></asp:TextBox>
                                    </td>
                                    <td>
                                        <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                            <img alt="" id="img1" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                                width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <div>
                                            <span id="Spn_ErrMsgBCC" class="RFV_Message autoccerrormsg" style="width: auto; padding-left: 4px;
                                                padding-right: 4px;"></span><span id="SpnChkErr1" class="RFV_Message autoccerrormsg"
                                                    style="width: auto; padding-left: 4px; padding-right: 4px;">Please enter email address</span>
                                        </div>
                                        <asp:HiddenField ID="hdn_bcc" runat="server" Value="" />
                                        <i class="graytext" style="font-weight: normal; display: none; padding-left: 5px">[Please
                                            separate multiple email addresses with a comma] </i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div align="left">
                            <fieldset style="width: 52%;">
                                <legend><b>
                                    <%=objlang.GetLanguageConversion("Other_Settings") %></b></legend>
                                <br />
                                &nbsp;&nbsp;<asp:Label ID="lbl_SupplierText" runat="server" Text="While sending Supplier RFQ attach all item specific files to the email"></asp:Label>
                                <asp:HiddenField ID="hdn_ChkSuplier" runat="server" Value="0" />
                                <div align="left" style="border: 0px solid red; margin-left: 3%; padding-top: 3px;">
                                    <asp:CheckBox ID="Chk_SupplierRFQ" runat="server" Text="Attach as Attachment" /><br />
                                    <asp:CheckBox ID="Chk_SuplrAttachLink" runat="server" Text="Attach as Link" /><br />
                                </div>
                                <br />
                                &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="While sending a Purchase Order to an Outwork Supplier attach all item specific files to the email"></asp:Label>
                                <asp:HiddenField ID="hdn_PUrchase" runat="server" Value="0" />
                                <div align="left" style="border: 0px solid red; margin-left: 3%; padding-top: 3px;">
                                    <asp:CheckBox ID="Chk_Purchase" runat="server" Text="Attach as Attachment" /><br />
                                    <asp:CheckBox ID="Chk_POAttachLink" runat="server" Text="Attach as Link" /><br />
                                    <asp:CheckBox ID="Chk_AttachDeliveryNote" runat="server" Text="Attach Delivery Note" /><br />
                                    <asp:CheckBox ID="Chk_estoreAttach" Checked="false" runat="server" Text="Attach eStore atrtwork file" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <br />
                    <div class="autotable">
                        <asp:RadioButton ID="rdbFromOthers" runat="server" Text="Send all emails via your preferred local email client [Outlook, Lotus...]"
                            Checked="false" GroupName="Email" onclick="checkonce();" />
                        <a href="#" class="tooltip" title="Templates attached to the emails will appear as a web link within the body of the email">
                            <img alt="" id="img4" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                class="tooltip" /></a>
                        <br />
                        <i class="graytext" style="font-weight: normal; padding-left: 18px; display: none;">
                            [<%=objlang.GetValueOnLang("Templates attached to the emails will appear as a web link within the body of the email")%>]</i>
                    </div>
                    <div id="Div_OtherEmail" style="padding-left: 20px; display: none;">
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="Chk_cc_Other" runat="server" Text="CC" />&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_cc_Other" TextMode="MultiLine" CssClass="textpad" runat="server"
                                        Width="320px" onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrOtherCC');"></asp:TextBox>
                                </td>
                                <td>
                                    <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                        <img alt="" id="img3" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                            width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                        <span id="Spn_ErrOtherCC" class="RFV_Message autoccerrormsg" style="width: auto;
                                            padding-left: 4px; padding-right: 4px;"></span><span id="SpnChkErr_CC" class="RFV_Message autoccerrormsg"
                                                style="width: auto; padding-left: 4px; padding-right: 4px;">Please enter email address</span>
                                    </div>
                                    <asp:HiddenField ID="hdn_cc_Other" runat="server" Value="" />
                                    <i class="graytext" style="font-weight: normal; padding-left: 5px; display: none;">[Please
                                        separate multiple email addresses with a comma] </i>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="Chk_bcc_Other" runat="server" Text="BCC" />&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_bcc_Other" TextMode="MultiLine" CssClass="textpad" runat="server"
                                        Width="320px" onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrOtherBCC');return false;"></asp:TextBox>
                                </td>
                                <td>
                                    <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                        <img alt="" id="img2" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                            width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                        <span id="Spn_ErrOtherBCC" class="RFV_Message autoccerrormsg" style="width: auto;
                                            padding-left: 4px; padding-right: 4px;"></span><span id="SpnChkErr_BCC" class="RFV_Message autoccerrormsg"
                                                style="width: auto; padding-left: 4px; padding-right: 4px;">Please enter email address</span>
                                        <asp:HiddenField ID="hdn_bcc_Other" runat="server" Value="" />
                                    </div>
                                    <i class="graytext" style="font-weight: normal; padding-left: 5px; display: none;">[Please
                                        separate multiple email addresses with a comma] </i>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <table width="30%" border="0" cellpadding="1" cellspacing="1" style="padding: 5px 0px 0px 165px;">
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <div id="div_btnCancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                        </telerik:RadButton>
                                    </div>
                                    <div id="div_btnCancelprocess" class="button" align="center" style="height: 14px; width: 43px; display: none">
                                         <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                     </div>
                                </div>
                                <div style="float: left; width: 10px;">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <div id="div_btnsave" runat="server" style="display: block; margin-top: -1px;">
                                        <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:return Validating();"
                                            Text="Save" OnClick="btnSave_OnClick" CausesValidation="false" CssClass="button">
                                        </asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess" runat="server" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none; float: left;">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hid_EmailSettingId" runat="server" Value="0" />
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
    <asp:LinkButton ID="lnk_Validate" runat="server" Text="" OnClick="btnSave_OnClick"></asp:LinkButton>
    <asp:LinkButton ID="lnk_OtherEmailSettings" runat="server" OnClick="btnSave_OnClick"></asp:LinkButton>
    <script type="text/javascript">
        var rdbFromEprint = document.getElementById("<%=rdbFromEprint.ClientID %>");
        var rdbFromOthers = document.getElementById("<%=rdbFromOthers.ClientID %>");
        var div_email = document.getElementById("div_email");
        var Div_OtherEmail = document.getElementById("Div_OtherEmail");

        if (rdbFromEprint.checked) {
            div_email.style.display = "block";
        }
        else if (rdbFromOthers.checked) {
            Div_OtherEmail.style.display = "block";
        }
        else {
            rdbFromEprint.checked = true;
            div_email.style.display = "block";
        }
        function checkonce() {
            if (rdbFromEprint.checked) {
                div_email.style.display = "block";
                Div_OtherEmail.style.display = "none";
            }
            else if (rdbFromOthers.checked) {
                Div_OtherEmail.style.display = "block";
                div_email.style.display = "none";
            }
        }       
    </script>
    <script>
        function validateEmail(field) {
            //var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return (regex.test(field)) ? true : false;
        }
        function ValidateMultiEmail(value, spnid) {
            document.getElementById(spnid).style.display = "none";

            if (value == '') {
                if (spnid == 'Spn_ErrMsgCC') {
                    if (Chk_cc.checked == true || Chk_bcc.checked == true) {
                        document.getElementById(spnid).innerHTML = "Please enter email address";
                        document.getElementById(spnid).style.display = "block";
                        return false;
                    }

                }
                else {
                    return true;
                }
            }
            //}
            else {
                var result = value.split(",");
                var chkvalidate = 'false';
                for (var i = 0; i < result.length; i++) {
                    var email = result[i].trim().replace(',', '');
                    if (!validateEmail(email)) {
                        document.getElementById(spnid).innerHTML = "Please enter valid email address";
                        document.getElementById(spnid).style.display = "block";
                        document.getElementById("SpnChkErr_CC").style.display = "none";
                        document.getElementById("SpnChkErr_BCC").style.display = "none";
                        document.getElementById("SpnChkErr").style.display = "none";
                        document.getElementById("SpnChkErr1").style.display = "none";
                        chkvalidate = 'false';
                    }
                    else {
                        chkvalidate = 'true';
                    }
                }
                if (chkvalidate == 'false') {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function Validating() {
            var rdbFromEprint = document.getElementById("<%=rdbFromEprint.ClientID %>");
            var rdbFromOthers = document.getElementById("<%=rdbFromOthers.ClientID %>");
            var txt_cc = document.getElementById("<%=txt_cc.ClientID %>");
            var txt_bcc = document.getElementById("<%=txt_bcc.ClientID %>");
            var Chk_bcc = document.getElementById("<%=Chk_bcc.ClientID %>");
            var Chk_cc = document.getElementById("<%=Chk_cc.ClientID %>");
            var Chk_cc_Other = document.getElementById("<%=Chk_cc_Other.ClientID %>");
            var txt_cc_Other = document.getElementById("<%=txt_cc_Other.ClientID %>");
            var Chk_bcc_Other = document.getElementById("<%=Chk_bcc_Other.ClientID %>");
            var txt_bcc_Other = document.getElementById("<%=txt_bcc_Other.ClientID %>");

            document.getElementById("<%=div_btnsaveprocess.ClientID %>").style.display = "block";
            document.getElementById("<%=div_btnsave.ClientID %>").style.display = "none";
            if (rdbFromEprint.checked) {
                if ((Chk_cc.checked == true) && (txt_cc.value == '')) {

                    document.getElementById("SpnChkErr").style.display = "block";
                    document.getElementById("SpnChkErr1").style.display = "none";
                    document.getElementById("<%=div_btnsaveprocess.ClientID %>").style.display = "none";
                    document.getElementById("<%=div_btnsave.ClientID %>").style.display = "block";
                    return false;
                }
                if ((Chk_bcc.checked == true) && (txt_bcc.value == '')) {
                    document.getElementById("SpnChkErr").style.display = "none";
                    document.getElementById("SpnChkErr1").style.display = "block";
                    document.getElementById("<%=div_btnsaveprocess.ClientID %>").style.display = "none";
                    document.getElementById("<%=div_btnsave.ClientID %>").style.display = "block";
                    return false;
                }

                var ret1, ret2;

                ret1 = ValidateMultiEmail(txt_cc.value, 'Spn_ErrMsgCC');
                ret2 = ValidateMultiEmail(txt_bcc.value, 'Spn_ErrMsgBCC');
                if ((ret1 == true) && (ret2 == true)) {
                    return true;
                }
                else {
                    return false;
                }
                //-------------------//
            }

            else if (rdbFromOthers.checked) {
                if ((Chk_cc_Other.checked == true) && (txt_cc_Other.value == '')) {

                    document.getElementById("SpnChkErr_CC").style.display = "block";
                    document.getElementById("SpnChkErr_BCC").style.display = "none";
                    document.getElementById("<%=div_btnsaveprocess.ClientID %>").style.display = "none";
                    document.getElementById("<%=div_btnsave.ClientID %>").style.display = "block";
                    return false;
                }
                if ((Chk_bcc_Other.checked == true) && (txt_bcc_Other.value == '')) {
                    document.getElementById("SpnChkErr_CC").style.display = "none";
                    document.getElementById("SpnChkErr_BCC").style.display = "block";
                    document.getElementById("<%=div_btnsaveprocess.ClientID %>").style.display = "none";
                    document.getElementById("<%=div_btnsave.ClientID %>").style.display = "block";
                    return false;
                }

                var ret1, ret2;

                ret1 = ValidateMultiEmail(txt_cc_Other.value, 'Spn_ErrOtherCC');
                ret2 = ValidateMultiEmail(txt_bcc_Other.value, 'Spn_ErrOtherBCC');
                if ((ret1 == true) && (ret2 == true)) {
                    return true;
                }
                else {
                    return false;
                }
                //-------------------//
            }
        }
         
           
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
