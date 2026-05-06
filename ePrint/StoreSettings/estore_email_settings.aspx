<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="estore_email_settings.aspx.cs" Inherits="ePrint.StoreSettings.estore_email_settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var AccountID = '<%=AccountId %>';
    </script>
    <div style="float: left;" class="estore_settingBox" id="pnldetails">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Email_Settings")%>&nbsp;
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="content">
                <div class="manageedit">
                    <div style="float: left; width: 100%;">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="">
                        <div align="left" style="width: 100%">
                            <div id="div_email" style="width: 62%; float: left;">
                                <div class="onlyEmpty">
                                    <div class="bglabel" style="width: 20%; float: left;">
                                        <asp:Label ID="lblEventType" runat="server" Text="Event Type"><%=objLanguage.GetLanguageConversion("Event_Type")%></asp:Label>
                                    </div>
                                    <div class="box" style="width: 76%; float: right;">
                                        <asp:Label ID="Label1" Text="Email to Admin (New Order)" runat="server"><%=objLanguage.GetLanguageConversion("Email_To_Admin")%>(<%=objLanguage.GetLanguageConversion("New_Order") %>)</asp:Label>
                                    </div>
                                </div>
                                <div id="div_text" style="margin-left: -18px; margin-top: 30px;">
                                    <div class="onlyEmpty" style="border: 0px solid red; width: 74.5%; float: left; margin-top: 5px;">
                                        <div style="margin-bottom: -8px; margin-left: 200px; margin-top: 0;">
                                            <asp:Label ID="lblassigned" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("To")%></asp:Label>
                                        </div>
                                        <div class="box" style="border: 0 solid red; float: left; margin-left: 230px; margin-top: -10px;
                                            width: 74%;">
                                            <asp:TextBox ID="txt_Admin_To" CssClass="textpad" TextMode="MultiLine" runat="server"
                                                Width="280px" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'Error_msgAdmin_To')"></asp:TextBox>
                                            <a href="#" id="ref1" runat="server" class="tooltip" title=''>
                                                <img alt="" id="img4" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                                    width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                    class="tooltip" /></a> <span id="SpnChkErr_CC" class="RFV_Message" style="display: none;
                                                        float: right; width: auto; padding-left: 4px; padding-right: 4px">
                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Email_Address")%></span>
                                        </div>
                                        <div style="float: left; margin-left: 240px;">
                                            <span id="Error_msgAdmin_To" class="RFV_Message" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px; float: right;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email")%></span></div>
                                    </div>
                                    <div class="onlyEmpty" style="border: 0px solid red; width: 74.5%; float: left; margin-top: 5px;">
                                        <div style="margin-bottom: -8px; margin-left: 200px; margin-top: 0;">
                                            <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("CC")%></asp:Label>
                                        </div>
                                        <div class="box" style="border: 0 solid red; float: left; margin-left: 230px; margin-top: -10px;
                                            width: 74%;">
                                            <asp:TextBox ID="txt_Admin_CC" CssClass="textpad" TextMode="MultiLine" runat="server"
                                                Width="279px" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'Error_msgAdmin_CC')"></asp:TextBox>
                                            <a href="#" id="ref2" runat="server" class="tooltip" title=''>
                                                <img alt="" id="img1" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                                    width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                    class="tooltip" /></a>
                                        </div>
                                        <div style="float: left; margin-left: 240px;">
                                            <span id="Error_msgAdmin_CC" class="RFV_Message" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px; float: right;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email")%></span></div>
                                    </div>
                                    <div class="onlyEmpty" align="left" style="border: 0px solid red; width: 74.5%; float: left;
                                        margin-top: 5px;">
                                        <div style="margin-bottom: -8px; margin-left: 200px; margin-top: 0;">
                                            <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("BCC") %></asp:Label>
                                        </div>
                                        <div class="box" style="border: 0 solid red; float: left; margin-left: 230px; margin-top: -10px;
                                            width: 74%;">
                                            <asp:TextBox ID="txt_Admin_BCC" CssClass="textpad" TextMode="MultiLine" runat="server"
                                                Width="280px" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'Error_msgAdmin_BCC')"></asp:TextBox>
                                            <a href="#" id="ref3" runat="server" class="tooltip" title=''>
                                                <img alt="" id="img2" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                                    width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                    class="tooltip" /></a>
                                        </div>
                                        <div style="float: left; margin-left: 240px;">
                                            <span id="Error_msgAdmin_BCC" class="RFV_Message" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px; float: right;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email")%></span></div>
                                    </div>
                                    <div align="left" style="border: 0px solid red; width: 53.5%; float: left;">
                                        <br />
                                        <div style="float: left; padding-left: 232px">
                                            <div id="div_btnsave" style="display: block">
                                                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClientClick="javascript:var a=GetEmailValue();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                                    OnClick="btnSave_Click" />
                                            </div>
                                            <div id="div_btnsaveprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnAdminTo" runat="server" Value="" />
                <asp:HiddenField ID="hdnAdminCc" runat="server" Value="" />
                <asp:HiddenField ID="hdnAdminBcc" runat="server" Value="" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var div_mail = document.getElementById("div_mail");
        var hdnAdminTo = document.getElementById("ctl00_ContentPlaceHolder1_hdnAdminTo");
        var hdnAdminCc = document.getElementById("ctl00_ContentPlaceHolder1_hdnAdminCc");
        var hdnAdminBcc = document.getElementById("ctl00_ContentPlaceHolder1_hdnAdminBcc");
        var txtAdminTo = document.getElementById("ctl00_ContentPlaceHolder1_txt_Admin_To");
        var txtAdminCc = document.getElementById("ctl00_ContentPlaceHolder1_txt_Admin_CC");
        var txtAdminBcc = document.getElementById("ctl00_ContentPlaceHolder1_txt_Admin_BCC");


        function validateEmail(field) {
            //var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return (regex.test(field)) ? true : false;
        }

        function validateMultipleEmailsCommaSeparated(value, spnid) {
            document.getElementById(spnid).style.display = "none";
            debugger;
            if (value == '') {
                return true;
                <%--if (spnid == 'Error_msgAdmin_To') {
                    document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Email_Address")%>';
                    document.getElementById(spnid).style.display = "block";
                    return false;
                }
                else {
                    return true;
                }--%>
            }
            else {

                var result = value.split(",");
                var chkvalidate = 'false';
                for (var i = 0; i < result.length; i++) {
                    var email = result[i].trim().replace(',', '');
                    if (!validateEmail(email)) {
                        document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email_Address")%>';
                        document.getElementById(spnid).style.display = "block";
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

        function validateMultipleEmailsCommaSeparatedCustomer(value, spnid) {
            document.getElementById(spnid).style.display = "none";
            if (ChkEmailto_Customer.checked == true) {
                if (value == '') {
                    if (spnid == 'Error_msgCustomer_From') {
                        document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Email_Address")%>';
                        document.getElementById(spnid).style.display = "block";
                        return false;
                    }
                    else {
                        return true;
                    }
                }

                else {
                    var result = value.split(",");
                    var chkvalidate = 'false';
                    for (var i = 0; i < result.length; i++) {
                        if (!validateEmail(result[i])) {
                            document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email_Address")%>';
                            document.getElementById(spnid).style.display = "block";
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
        }


        //            function Show_accountListDiv() {
        //                showDivPopupCenter('div_accountsList', '200');
        //            }

        function GetEmailValue() {
            debugger;
            if (validate_Account()) {
                if (txtAdminTo.value == '') {
                    return true;
                    //document.getElementById("SpnChkErr_CC").style.display == "block";
                    //return false;
                }
                else {
                    var a = validateMultipleEmailsCommaSeparated(txtAdminTo.value, 'Error_msgAdmin_To');
                    if (a == true) {
                        var b = true;
                        hdnAdminTo.value = txtAdminTo.value;
                        hdnAdminCc.value = txtAdminCc.value;
                        hdnAdminBcc.value = txtAdminBcc.value;
                        if (txtAdminCc.value != '') {
                            b = validateMultipleEmailsCommaSeparated(txtAdminCc.value, 'Error_msgAdmin_CC');
                        }
                        if (txtAdminBcc.value != '') {
                            b = validateMultipleEmailsCommaSeparated(txtAdminBcc.value, 'Error_msgAdmin_BCC')
                        }
                        if (b) {
                            return true;
                        }
                        else {
                            return false;
                        }

                    }
                    else {
                        return false;
                    }

                }
            }
            else {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
