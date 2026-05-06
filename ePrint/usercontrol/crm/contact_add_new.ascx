<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact_add_new.ascx.cs" Inherits="ePrint.usercontrol.crm.contact_add_new" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.js?VN='<%=VersionNumber%>'"
    type="text/javascript"></script>
<script type="text/javascript" src="../common/calendar.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">
    var asyncState = true;
    XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
    XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
        async = asyncState;
        var eventArgs = Array.prototype.slice.call(arguments);
        return this.original_open.apply(this, eventArgs);
    }
    //checkEmilDuplicacynew2();
    var hdnsystemname = '<%=hdnsystemname %>';
    $(document).ready(function () {

        $(".hide_show").hide();
        $(".show_hide").show();

        $('.show_hide').click(function () {
            $(".hide_show").slideToggle();
            $(".show_hide").slideToggle();
        });

        $('.hide_show').click(function () {
            $(".show_hide").slideToggle();
            $(".hide_show").slideToggle();
        });
        var cnt = 0;
        $('.changepwd').click(function () {
            $(".changepwdpanel").slideToggle();
            if (cnt == 0) {
                chkB2bLoginChngPass.checked = true;
                onclick_chkB2bLogin('update');
                txtPassword.focus();
                cnt = 1;
            }
            else {
                chkB2bLoginChngPass.checked = false;
                onclick_chkB2bLogin('update');
                cnt = 0;
            }
        });

    });

</script>
<style type="text/css">
    .web_dialog_overlay_Address {
        position: fixed;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        height: 100%;
        width: 100%;
        margin: 0;
        padding: 0;
        background: Black;
        opacity: .25;
        filter: alpha(opacity=25);
        -moz-opacity: .25;
        z-index: 101;
        display: none;
    }
</style>
<div id="divOverLayer" class="web_dialog_overlay_Address">
</div>
<style type="text/css">
    .ui-accordion .ui-accordion-content {
        padding: 1em 0.3em !important;
        border-top: 1px solid #AAAAAA !important;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {

        $(function () {
            $("#accordion").accordion({
                header: "h4", collapsible: true, autoHeight: false
            });
            $("#accordion span").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
            var accordionindex = 1000;
            //var accordionindex = 0;
            $("#accordion").accordion();

            if (accordionindex == 0) {
                $("#accordion").accordion();
            }
            else {
                $("#accordion").accordion();
                $("#accordion").accordion('activate', accordionindex);

            }

        });
    });

</script>
<%--<style type="text/css">
    .active
    {
        background-color: #dadada;
    }
    .active1
    {
        background-color: white;
    }
   
</style>--%>
<%--<asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true">
    <Services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </Services>
</asp:ScriptManager>--%>
<asp:ScriptManagerProxy ID="SMP" runat="server">
    <services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </services>
</asp:ScriptManagerProxy>
<script type="text/javascript" language="javascript">
    var Pgtype = '<%=pg %>';
    var AccountID = '<%=AccountID %>';
    var StoreUserID = '<%=StoreUserID %>';
    var loginType = "insert";
    if (StoreUserID != 0) {
        loginType = "update";
    }
</script>
<div id="divBackGroundNew" style="display: none;">
</div>
<%--<div class="navigatorpanel">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" nowrap="nowrap">
                        <span runat="server" id="spn_Navigationpanel" class="navigatorpanel">
                            <asp:Label ID="lbl_header" runat="server" Text=""><%=objLangClass.GetLanguageConversion("Add_New_Contact")%> </asp:Label>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>--%>
<%--onmouseover="checkEmailForStoreUserNew();"--%>
<asp:HiddenField ID="hdnsystemname" runat="server" Value="" />
<div>
    <%--class="borderWithoutTop"--%>
    <div>
        <%--id="padding"--%>
        <%--  <div align="left" style="width: 92%;">
            <span style="float: right; color: red">*
                <%=objLangClass.GetLanguageConversion("Fields_Are_Mandatory")%></span>
        </div>--%>
        <%-- <div style="clear: both">
        </div--%>
        <div align="left" style="width: 100%;">
            <div id="leftcol" style="width: 49%; white-space: nowrap">
                <div align="left" style="padding: 0px 6px 5px 5px;">
                    <div>
                        <b>
                            <asp:Label ID="Label35" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Personal_Information")%> </asp:Label></b>
                    </div>
                </div>
                <div id="div_Autocomplete" runat="server" align="left" style="display: none">
                    <div class="bglabel">
                        <asp:Label ID="Label2" runat="server" Text="Company Name" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <div style="float: left; width: 100%">
                            <asp:TextBox ID="txtCompanyName" SkinID="textPad" runat="server" AutoCompleteType="disabled"
                                MaxLength="250" Width="100%" onblur="CallonBlur('none','spntxtName');"></asp:TextBox><%--onkeyup="BindCompanyName(this.value);"--%>
                            <span id="spntxtName" class="spanerrorMsg" style="display: none; width: auto"></span>
                        </div>
                        <asp:HiddenField ID="hdnAddress" runat="server" />
                        <asp:HiddenField ID="hdnClientID" runat="server" />
                    </div>
                </div>
                <div align="left">
                    <div id="div_CompanyType" runat="server" align="left" style="display: none">
                        <div class="bglabel">
                            <asp:Label ID="Label3" runat="server" Text="Company Type" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="ddlsetting">
                            <asp:Label ID="lbl_CompanyType" runat="server" CssClass="grayText" Width="200px"></asp:Label>
                            <asp:HiddenField ID="hid_CompanyType" runat="server" Value="" />
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label4" runat="server" CssClass="normaltext"> </asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtTitle" runat="server" SkinID="textPad" TabIndex="1" MaxLength="200"
                                Width="100%" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            <span id="spnTitle" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                class="spanerrorMsg">
                                <%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%>
                            </span>
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label5" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("First_Name")%> </asp:Label>
                            <span style="color: red">*</span>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtFirstName" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                                TabIndex="2" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="txtFirstName"
                                CssClass="spanerrorMsg" ForeColor="Black" Display="Dynamic" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>--%>
                            <span id="spnFirstName" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                class="spanerrorMsg">
                                <%=objLangClass.GetLanguageConversion("Please_Enter_First_Name")%>
                            </span>
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label6" runat="server" MaxLength="150" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Middle_Name")%> </asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtMiddleName" runat="server" SkinID="textPad" Width="100%" TabIndex="20"
                                MaxLength="200" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label7" runat="server" MaxLength="150" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtLastName" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                                TabIndex="3" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            <span id="spnLastName" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                class="spanerrorMsg">
                                <%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%>
                            </span>
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <div style="float: left; display: block;">
                                <asp:Label ID="lbl_Department" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Department")%> </asp:Label>
                            </div>
                            <div id="DivDepartment" runat="server" style="float: right; display: block;">
                                <asp:ImageButton Style="vertical-align: middle" ID="ImageButton1" runat="server"
                                    TabIndex="4" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Department"
                                    OnClientClick="javascript:addNewDepartment('contact','add','','0');return false;" />
                            </div>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtDepartment" runat="server" SkinID="textPad" Width="100%" MaxLength="300"
                                Visible="false"></asp:TextBox>
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="normaltext" Width="100%"
                                TabIndex="5" onchange="ddlDept_OnChange(this.value);">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnDeptID" runat="server" />
                        </div>
                    </div>
                    <div align="left" style="display: block">
                        <div class="bglabel">
                            <div style="float: left; display: block;">
                                <asp:Label ID="Label10" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Contact_Address")%> </asp:Label>
                            </div>
                            <div id="DivContactImage" runat="server" style="float: right; display: block;">
                                <asp:ImageButton Style="vertical-align: middle" ID="ImageButton2" runat="server"
                                    OnClick="lnk_ContactChange_Click" CausesValidation="False" ImageUrl="~/images/plus.gif"
                                    ToolTip="Change/New Address" OnClientClick="javascript:return GetContactAddress('change');" />
                            </div>
                        </div>
                        <div class="box">
                            <asp:Label ID="lbl_ContactAddressDetails" runat="server" SkinID="textPad" Width="100%"></asp:Label>
                        </div>
                    </div>
                    <div align="left" style="display: block">
                        <div class="bglabel">
                            <asp:Label ID="Label12" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Dept_Delivery_Address")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:Label ID="lbl_DeliveryAddressDetails" runat="server" SkinID="textPad" MaxLength="250"
                                Width="100%"></asp:Label>
                            <asp:HiddenField ID="hdn_ContactAddressDetails" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdn_DeliveryAddressDetails" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdn_InvoiceAddressDetails" runat="server"></asp:HiddenField>
                        </div>
                    </div>
                    <div align="left" style="display: block">
                        <div class="bglabel">
                            <asp:Label ID="Label14" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Dept_Invoice_Address")%> </asp:Label>
                        </div>
                        <div class="box">
                            <asp:Label ID="lbl_InvoiceAddressDetails" runat="server" SkinID="textPad" MaxLength="250"
                                Width="100%"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="clear: both">
                    </div>
                    <div id="div_B2bLogin" runat="server" align="left" style="display: none;">
                        <div style="padding: 3px 0px 0px 6px;">
                            <b>
                                <asp:Label ID="lbl_b2b" runat="server" CssClass="normaltext"></asp:Label></b>
                        </div>
                        <div class="box" align="left">
                            <asp:CheckBox ID="chkB2bLogin" runat="server" Text="allow this contact to login to b2b ordering portal"
                                onclick="javascript:onclick_chkB2bLogin('insert');" TabIndex="13" />
                            <asp:CheckBox ID="chkB2bLoginChngPass" runat="server" Text="Allow
                                this contact to change password for B2B ordering Portal"
                                Style="display: none;"
                                onclick="javascript:onclick_chkB2bLogin('update');" />
                        </div>
                        <div id="div_Password" runat="server" align="left" style="display: none;">
                            <div class="bglabel">
                                <asp:Label ID="Label8" runat="server" Text="Password" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box" style="width: auto">
                                <div style="float: left; border: solid 0px green;" class="changepwd">
                                    <a title="Click to Show/Hide" href="javascript:void(0);">
                                        <%=objLangClass.GetLanguageConversion("Change_Password")%></a>
                                </div>
                            </div>
                        </div>
                        <div id="div_PasswordArea" runat="server" style="display: block;" class="changepwdpanel">
                            <div align="left">
                                <div class="bglabel">
                                    <asp:Label ID="Label33" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("New_Password")%> </asp:Label>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtPassword" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                                        TabIndex="14" TextMode="Password" onkeyup="this.value=this.value.replace(/(^\s+)|\s+$/g,'')"></asp:TextBox>
                                    <span id="spnPassword" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                        class="spanerrorMsg">
                                        <%=objLangClass.GetLanguageConversion("Please_Enter_Password")%></span><span id="spnPassword_Space"
                                            style="display: none; width: auto" class="spanerrorMsg"><%=objLangClass.GetLanguageConversion("Please_Enter_Valid_Password")%></span>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel">
                                    <asp:Label ID="Label39" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Confirm_Password")%> </asp:Label>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" SkinID="textPad" Width="100%"
                                        TabIndex="15" MaxLength="200" TextMode="Password" onkeyup="this.value=this.value.replace(/(^\s+)|\s+$/g,'')"></asp:TextBox>
                                    <%--onkeyup="Javascript:NotSpaceAllowed(event);return false;"--%>
                                    <span id="spnConfirmPassword" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                        class="spanerrorMsg">
                                        <%=objLangClass.GetLanguageConversion("Please_Enter_ConfirmPassword")%></span><span
                                            id="spnValidPassword" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                                            class="spanerrorMsg"><%=objLangClass.GetLanguageConversion("Password_Mismatch")%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="div_LoginEmail" runat="server" style="display: none;">
                        <div class="ddlsetting" style="padding-left: 30%">
                            <asp:CheckBox ID="chkLoginEmail" runat="server" Text="Email Login Info to the User"
                                TabIndex="16" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="div1" runat="server" style="display: block;">
                        <div class="ddlsetting" style="padding-left: 30%">
                            <asp:CheckBox ID="ChkSubscribeduser" runat="server" Text="" TabIndex="17" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="divMailOut" runat="server">
                        <div class="ddlsetting contactadd">
                            <asp:CheckBox ID="chkReceiveMailOut" runat="server" Text="" TabIndex="18" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
            </div>
            <div id="rightcol" style="width: 49%; white-space: nowrap">
                <br />
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label11" runat="server" CssClass="normaltext"> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtJobTitle" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                            TabIndex="6" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                        <span id="spnJobTitle" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%>
                        </span>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lblJobTitle2" runat="server" CssClass="normaltext"> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtJobTitle2" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                            TabIndex="7" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                        <span id="spnJobTitle2" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%>
                        </span>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbl_ContactEmail" runat="server" CssClass="normaltext"> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:UpdatePanel runat="server" ID="up1">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_ContactEmail" runat="server" SkinID="textPad" Width="100%" MaxLength="200"
                                    onblur="checkEmailForStoreUser(this.value);checkEmilDuplicacynew(this.value);" TabIndex="8" OnLoad="txt_ContactEmail_TextChanged"
                                    OnTextChanged="txt_ContactEmail_TextChanged" AutoPostBack="true" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                <%--onblur="checkEmilDuplicacynew(this.value)" onKeyPress="checkEmilDuplicacynew(this.value)" onkeyup="checkEmilDuplicacynew(this.value)"--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <span id="spn_txtEmail" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("Please_Enter_Email_Address")%></span>
                        <span id="spn_txtEmailExp" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: pre-wrap;"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("Please_Enter_Valid_Email_Address")%></span>
                    </div>
                </div>
                <div align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="Label1" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Mobile")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtContactMobile" runat="server" SkinID="textPad" Width="100%" MaxLength="50"
                            TabIndex="9" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                    </div>
                </div>
                <div align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="Label28" runat="server" CssClass="normaltext"> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtHomePhone" runat="server" SkinID="textPad" Width="100%" MaxLength="30"
                            TabIndex="10" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                        <span id="spnHomePhone" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("This_Is_A_Required_Field")%>
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="Label9" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Personal_Fax")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtPersonalFax" runat="server" SkinID="textPad" Width="100%" MaxLength="30"
                            TabIndex="11" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                    </div>
                </div>
                <div align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="lblAlternate" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Alternate_numbers")%> </asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtAlternateNumber" runat="server" SkinID="textPad" Width="100%"
                            TabIndex="12" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                    </div>
                </div>
                <div align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="lblImageUpload" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Contact_Image")%> </asp:Label>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                            ControlToValidate="ImageUpload" ValidationGroup="Test"></asp:CustomValidator>

                    </div>
                    <%-- design changes added by thejesh -----%>
                    <div class="box">
                        <asp:FileUpload ID="ImageUpload" Width="100%" Style="height: 23px;" runat="server"
                            CssClass="textboxnew" BorderStyle="None" />
                        <div id="DivClear" runat="server" style="margin-top: -20px; margin-left: 260px;">
                            <a id="FileTextClear" runat="server" href="#" style="display: none; text-decoration: underline; cursor: pointer; padding-left: 5px;"
                                onclick="javascript:FileUploadClearText(); return false;">
                                <%=objLangClass.GetLanguageConversion("Clear") %></a>
                        </div>
                        <div id="ContactImage" runat="server" align="left" style="cursor: pointer; display: none;">
                            <div style="line-height: 150%;">
                                <asp:Label ID="lblContactImage" runat="server" CssClass="Normaltext"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <span id="Spn_ImageUploadFile" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 32%;"
                    class="spanerrorMsg">
                    <%=objLangClass.GetLanguageConversion("Please_upload_only_Jpeg_PDF")%>
                </span>
                <div style="clear: both">
                </div>
                <div style="float: left; padding-left: 6px; padding-top: 2px;">
                    <div>
                        <asp:Label runat="server" ID="lblImgguidance"><b><%=objLanguage.GetLanguageConversion("Image_guide_lines")%></b></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" class="smallgraytext" ID="Label16"><%=objLanguage.GetLanguageConversion("Please_upload_JPEG_or_PNG_file")%></asp:Label><br />
                        <asp:Label runat="server" class="smallgraytext" ID="Label17"><%=objLanguage.GetLanguageConversion("PDF_singlePage")%></asp:Label><br />
                        <asp:Label runat="server" class="smallgraytext" ID="Label18"><%=objLanguage.GetLanguageConversion("PDF_files_Background")%></asp:Label><br />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="DivMainApprover" runat="server" align="left" style="display: block;">
                    <div class="bglabel">
                        <asp:Label ID="Label13" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Main_Approver")%> </asp:Label>
                    </div>
                    <div class="box" style="margin-top: 2px;">
                        <asp:CheckBox ID="chkMainApprover" runat="server" TabIndex="13" OnClick="javascript:chkMainApproverchanged();" />
                    </div>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div id="accordion">
                <h4>
                    <a href='#'><b style="color: Black">
                        <%=objLangClass.GetLanguageConversion("Additional_Information")%></b></a>
                </h4>
                <div style="display: none;">
                    <table cellpadding="2" cellspacing="2">
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom1" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc1" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom9" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc9" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom2" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc2" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom10" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc10" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom3" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc3" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom11" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc11" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom4" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc4" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom12" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc12" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom5" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc5" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom13" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc13" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom6" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc6" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom14" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc14" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom7" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc7" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom15" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="dept_td_padding">
                                <asp:TextBox ID="txtc15" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="bglabel_dept" valign="top">
                                <div>
                                    <asp:Label ID="lblcustom8" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td valign="top" class="contact_customfield_td">
                                <asp:TextBox ID="txtc8" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="dept_div_margin">
                <span class="smallgraytext">
                    <%=objLangClass.GetLanguageConversion("These_custom_fields_can_appear_as_default_content")%>
                </span>
            </div>
            <div align="left" style="width: 100%;">
                <div style="float: left; width: 66%">
                    &nbsp;
                </div>
                <div align="right" style="float: left;">
                    <div id="div_cancel" runat="server" style="float: left; display: none;">
                        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                            OnClick="btnCancel_OnClick" OnClientClick="CallCan();"></asp:Button>
                    </div>
                    <div id="DivSAve" runat="server" style="float: left; margin: 0px 0px 0px 10px;" onmouseover="checkEmilDuplicacynew();">
                        <%--onmouseover="checkEmailForStoreUserNew();  "--%>
                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_OnClick"
                            TabIndex="19" OnClientClick="javascript:var a=Validate_CRM();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"></asp:Button>
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
</div>
<asp:LinkButton ID="lnk_redirect" runat="server" OnClick="lnk_redirect_Click"></asp:LinkButton>
<div align="left" style="width: 800px">
    &nbsp;
</div>
<input id="hid_ClientID" type="hidden" runat="server" value="0" />
<asp:HiddenField ID="hid_ContactID" runat="server" Value="0" />
<asp:HiddenField ID="hid_Mainapprovercount" runat="server" Value="0" />
<asp:HiddenField ID="hid_type" runat="server" Value="0" />
<asp:HiddenField ID="hid_ContactImage" runat="server" Value="" />
<asp:HiddenField ID="hid_Actualfilename" runat="server" Value="" />
<asp:HiddenField ID="hid_Originalfilename" runat="server" Value="" />
<asp:HiddenField ID="hid_IsProccessed" runat="server" Value="" />
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdnAddressID" runat="server" Value="0" />
<asp:HiddenField ID="hdnPassword" runat="server" />
<asp:HiddenField ID="hdnContactAddressID" runat="server" Value="0" />
<asp:HiddenField ID="hdnShippingAddressID" runat="server" Value="0" />
<%--please do not comment general.js . it using in Home > Customer View > Customer Details >> add contact popup.--%>
<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var txtFirstName = document.getElementById("<%=txtFirstName.ClientID%>");
    var txtLastName = document.getElementById("<%=txtLastName.ClientID %>");
    var txtHomePhone = document.getElementById("<%=txtHomePhone.ClientID%>");
    var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");
    var chkB2bLogin = document.getElementById("<%=chkB2bLogin.ClientID %>");
    var chkB2bLoginChngPass = document.getElementById("<%=chkB2bLoginChngPass.ClientID %>");
    var txtJobTitle = document.getElementById("<%=txtJobTitle.ClientID%>");
    var txtJobTitle2 = document.getElementById("<%=txtJobTitle2.ClientID%>");
    var txtTitle = document.getElementById("<%=txtTitle.ClientID%>");

    var txtPassword = document.getElementById("<%=txtPassword.ClientID %>");
    var txtConfirmPassword = document.getElementById("<%=txtConfirmPassword.ClientID %>");
    var chkLoginEmail = document.getElementById("<%=chkLoginEmail.ClientID %>");

    var hdnShippingAddressID = document.getElementById("<%=hdnShippingAddressID.ClientID %>");
    var hdnPassword = document.getElementById("<%=hdnPassword.ClientID %>");
    var hdnContactAddressID = document.getElementById("<%=hdnContactAddressID.ClientID %>");

    var lbl_ContactAddressDetails = document.getElementById("<%=lbl_ContactAddressDetails.ClientID %>");
    var lbl_DeliveryAddressDetails = document.getElementById("<%=lbl_DeliveryAddressDetails.ClientID %>");
    var lbl_InvoiceAddressDetails = document.getElementById("<%=lbl_InvoiceAddressDetails.ClientID %>");

    var EmailInvalidFormat = '<%=objLangClass.GetLanguageConversion("Please_Enter_Valid_Email_Address")%>';

    var hdn_ContactAddressDetails = document.getElementById("<%=hdn_ContactAddressDetails.ClientID %>");
    var hdn_DeliveryAddressDetails = document.getElementById("<%=hdn_DeliveryAddressDetails.ClientID %>");
    var hdn_InvoiceAddressDetails = document.getElementById("<%=hdn_InvoiceAddressDetails.ClientID %>");

    var div_Password = document.getElementById("<%=div_Password.ClientID %>");
    var div_PasswordArea = document.getElementById("<%=div_PasswordArea.ClientID %>");

    var cnt = 0;
    function CopyToShip() {
        hdnShippingAddressID.value = hdnAddressID.value;
        if (lblBusinessAddressLine1.innerHTML != "") {
            lblShippingAddressLine1.innerHTML = lblBusinessAddressLine1.innerHTML;
            div_ShippingAddressLine1.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingAddressLine1.innerHTML = "";
            div_ShippingAddressLine1.style.display = "none";
        }

        if (lblBusinessAddressLine2.innerHTML != "") {
            lblShippingAddressLine2.innerHTML = lblBusinessAddressLine2.innerHTML;
            div_ShippingAddressLine2.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingAddressLine2.innerHTML = "";
            div_ShippingAddressLine2.style.display = "none";
        }

        if (lblBusinessAddressLine3.innerHTML != "") {
            lblShippingAddressLine3.innerHTML = lblBusinessAddressLine3.innerHTML;
            div_ShippingAddressLine3.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingAddressLine3.innerHTML = "";
            div_ShippingAddressLine3.style.display = "none";
        }

        if (lblBusinessAddressLine4.innerHTML != "") {
            lblShippingAddressLine4.innerHTML = lblBusinessAddressLine4.innerHTML;
            div_ShippingAddressLine4.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingAddressLine4.innerHTML = "";
            div_ShippingAddressLine4.style.display = "none";
        }

        if (lblBusinessAddressLine5.innerHTML != "") {
            lblShippingAddressLine5.innerHTML = lblBusinessAddressLine5.innerHTML;
            div_ShippingAddressLine5.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingAddressLine5.innerHTML = "";
            div_ShippingAddressLine5.style.display = "none";
        }

        if (lblBusinessCountry.innerHTML != "") {
            lblShippingCountry.innerHTML = lblBusinessCountry.innerHTML;
            div_ShippingCountry.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingCountry.innerHTML = "";
            div_ShippingCountry.style.display = "none";
        }

        if (lblBusinessPhoneValue.innerHTML != "") {
            lblShippingPhoneValue.innerHTML = lblBusinessPhoneValue.innerHTML;
            div_ShippingPhone.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingPhoneValue.innerHTML = "";
            div_ShippingPhone.style.display = "none";
        }

        if (lblBusinessFaxValue.innerHTML != "") {
            lblShippingFaxValue.innerHTML = lblBusinessFaxValue.innerHTML;
            div_ShippingFax.style.display = "block";
            cnt = cnt + 1;
        }
        else {
            lblShippingFaxValue.innerHTML = "";
            div_ShippingFax.style.display = "none";
        }

        if (cnt != 0) {
            lnk_ShippingEdit.style.display = "block";
            lbl_ShippingSpliter.style.display = "block";
        }
    }


    function SendAddressIDandNameToContact(AddressID, Address, AddLine1, AddLine2, City, State, ZipCode, Country, Phone, Fax, AddressLabel, AddressTo) {

        // alert(AddressID + ', ' + Address + ', ' + AddLine1 + ', ' + AddLine2 + ', ' + City + ', ' + State + ', ' + ZipCode + ', ' + Country + ', ' + Phone + ', ' + Fax + ', ' + AddressTo);

        var CharLengthToDisplay = '<%=CharLengthToDisplay %>';
        if (AddressTo.toLowerCase() == "billing") {
            lbl_InvoiceAddressDetails.innerHTML = SpecialDecode(AddLine1) + ' ' + SpecialDecode(AddLine2) + ' ' + SpecialDecode(City) + ' ' + SpecialDecode(State) + ' ' + SpecialDecode(ZipCode) + ' ' + SpecialDecode(Country);
            if (trim12(lbl_InvoiceAddressDetails.innerHTML).length > CharLengthToDisplay) {
                lbl_InvoiceAddressDetails.innerHTML = trim12(lbl_InvoiceAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
                hdn_InvoiceAddressDetails.value = trim12(lbl_InvoiceAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
            }
            else {
                lbl_InvoiceAddressDetails.innerHTML = trim12(lbl_InvoiceAddressDetails.innerHTML);
                hdn_InvoiceAddressDetails.value = trim12(lbl_InvoiceAddressDetails.innerHTML);
            }
            hdnAddressID.value = AddressID;
        }

        if (AddressTo.toLowerCase() == "shipping") {
            lbl_DeliveryAddressDetails.innerHTML = SpecialDecode(AddLine1) + ' ' + SpecialDecode(AddLine2) + ' ' + SpecialDecode(City) + ' ' + SpecialDecode(State) + ' ' + SpecialDecode(ZipCode) + ' ' + SpecialDecode(Country);
            if (trim12(lbl_DeliveryAddressDetails.innerHTML).length > CharLengthToDisplay) {
                lbl_DeliveryAddressDetails.innerHTML = trim12(lbl_DeliveryAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
                hdn_DeliveryAddressDetails.value = trim12(lbl_DeliveryAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
            }
            else {
                lbl_DeliveryAddressDetails.innerHTML = trim12(lbl_DeliveryAddressDetails.innerHTML);
                hdn_DeliveryAddressDetails.value = trim12(lbl_DeliveryAddressDetails.innerHTML);
            }
            hdnShippingAddressID.value = AddressID;
        }

        if (AddressTo.toLowerCase() == "contactaddress") {
            //div_Edit_Change.style.display = "block";
            lbl_ContactAddressDetails.innerHTML = SpecialDecode(AddLine1) + ' ' + SpecialDecode(AddLine2) + ' ' + SpecialDecode(City) + ' ' + SpecialDecode(State) + ' ' + SpecialDecode(ZipCode) + ' ' + SpecialDecode(Country);
            if (trim12(lbl_ContactAddressDetails.innerHTML).length > CharLengthToDisplay) {
                lbl_ContactAddressDetails.innerHTML = trim12(lbl_ContactAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
                hdn_ContactAddressDetails.value = trim12(lbl_ContactAddressDetails.innerHTML).substring(0, CharLengthToDisplay);
            }
            else {
                lbl_ContactAddressDetails.innerHTML = trim12(lbl_ContactAddressDetails.innerHTML);
                hdn_ContactAddressDetails.value = trim12(lbl_ContactAddressDetails.innerHTML);
            }
            hdnContactAddressID.value = AddressID;
        }

    }

    var StoreUserID = '<%=StoreUserID %>';
    var AccountID = '<%=AccountID %>';
    var Client_ID = '<%=ClientID %>';
    var Contact_ID = '<%=ContactID %>';
    var ChkEmailDuplicacy = '<%=ChkEmailDuplicacy %>';
    var EmailID_already_exists = '<%=objLangClass.GetLanguageConversion("EmailID_already_exists")%>';
    var Waiting_For_Approval = '<%=objLangClass.GetLanguageConversion("Waiting_For_Approval")%>';
    var IsB2BEnabled = '<%=IsB2BEnabled %>';

    function checkEmilDuplicacynew(emailtext) {

        if (IsB2BEnabled.toLowerCase().trim() == 'true') {
            if (emailtext == "" || typeof emailtext == 'undefined' || emailtext == 'null') {
                emailtext = document.getElementById("<%=txt_ContactEmail.ClientID %>").value;
            }
            //  if (get_oldemail != emailtext) {
            if (emailtext != "") {
                asyncState = false;
                //AutoFill.Check_EmailID_Duplicacy(StoreUserID, emailtext, 0, GetResult, onTimeout, onError);
                AutoFill.Check_EmailID_Duplicacy_for_Account(SpecialEncode(emailtext), Client_ID, Contact_ID, GetResult, onTimeout, onError);
            }
                // }
            else {
                ChkEmailDuplicacy = false;
            }
        }
        else {
            ChkEmailDuplicacy = false;


        }
    }

    function checkEmailForStoreUser(emailtext) {

        if (IsB2BEnabled.toLowerCase().trim() == 'true') {
            var hid_Type_new = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_hid_type");
            getemail_ontextchnage = emailtext;
            if (emailtext != "") {
                //AutoFill.Check_EmailID_Duplicacy(StoreUserID, emailtext, 0, GetResult, onTimeout, onError);
                if ((get_oldemail != emailtext && hid_Type_new.value.indexOf('edit') > -1) || hid_Type_new.value.indexOf('edit') == -1)
                    AutoFill.Check_EmailID_Duplicate_for_Account(SpecialEncode(emailtext), Client_ID, GetResult, onTimeout, onError);
            }
        }
        else {
            ChkEmailDuplicacy = false;
        }
    }

    function checkEmailForStoreUserNew() {
        var hid_Type_new = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_hid_type");
        if (IsB2BEnabled.toLowerCase().trim() == 'true') {
            var emailtext = document.getElementById("<%=txt_ContactEmail.ClientID %>").value;
            if (hid_Type_new.value.toLowerCase() == "add" && emailtext != "") {
                AutoFill.Check_EmailID_Duplicate_for_Account(SpecialEncode(emailtext), Client_ID, GetResult, onTimeout, onError);
            }


        }
        else {
            ChkEmailDuplicacy = false;
        }
    }



    function checkEmilDuplicacynew2() {

        if (IsB2BEnabled.toLowerCase().trim() == 'true') {
            var emailtext = document.getElementById("<%=txt_ContactEmail.ClientID %>").value;
            if (get_oldemail != emailtext) {

                if (emailtext != "") {
                    AutoFill.Check_EmailID_Duplicacy_for_Account(SpecialEncode(emailtext), Client_ID, Contact_ID, GetResult, onTimeout, onError);
                }
            }
            else {
                ChkEmailDuplicacy = false;
            }
        }
        else {
            ChkEmailDuplicacy = false;
        }
    }
    //    checkEmilDuplicacynew2();
    //    checkEmailForStoreUserNew();


    function GetResult(result) {
        if (result == -1) {
            spn_txtEmailExp.innerHTML = EmailID_already_exists;
            spn_txtEmailExp.style.display = "block";
            ChkEmailDuplicacy = true;
            txt_ContactEmail.focus();
            //    if (chkB2bLogin.checked == false) {
            // spn_txtEmailExp.style.display = "none"; commented bcz email duplicacy checked only estoreuser checkbox checked
            //  ChkEmailDuplicacy = false;
            // return true;
            //    }
            //    else {
            //     spn_txtEmailExp.style.display = "block";
            // ChkEmailDuplicacy = true;
            //    return false;
            //}
            return false;
        }
        else if (result == -2) {
            spn_txtEmailExp.innerHTML = Waiting_For_Approval;
            txt_ContactEmail.focus();
            if (chkB2bLogin.checked == false) {
                spn_txtEmailExp.style.display = "none";
                ChkEmailDuplicacy = false;
                return true;
            }
            else {
                spn_txtEmailExp.style.display = "block";
                ChkEmailDuplicacy = true;
                return false;
            }
        }
        else {
            var NewCheck = true;
            if (spn_txtEmailExp.innerHTML == EmailID_already_exists) {
                NewCheck = false;
            }
            if (spn_txtEmailExp.innerHTML == Waiting_For_Approval) {
                NewCheck = false;
            }
            if (NewCheck && spn_txtEmailExp.style.display != "none") { }
            else { spn_txtEmailExp.style.display = "none"; }
            ChkEmailDuplicacy = false;
            return true;
        }
    }

    function onTimeout(request, context) { }

    function onError(objError) { }



    function CallCan() {
        window.close();
    }
    // not using.
    function NotSpaceAllowed(e) {
        var key = window.event ? e.keyCode : e.which;
        if (txtPassword.value != "") {
            if (key == 32) {
                //document.getElementById("spnPassword_Space").style.display = "block";
                txtPassword.value = "";
            }
        }
        if (txtConfirmPassword.value != "") {
            if (key == 32) {
                txtConfirmPassword.value = "";
            }
        }
    }

    function CopyAddress() {
        if ('<%=wintype %>' != "") {
            var hdnAddress = document.getElementById("<%=hdnAddress.ClientID %>");
            if (hdnAddress.value != '') {
                var strArr = hdnAddress.value.split('»');
                //alert(hdnAddress.value);
                //alert(strArr[0] + "==" + strArr[1] + "==" + strArr[2] + "==" + strArr[3] + "==" + strArr[4]);
                txtBusinessAddressLine1.value = strArr[0] == "" ? "" : strArr[0];
                txtBusinessAddressLine2.value = strArr[1] == "" ? "" : strArr[1];
                txtBusinessAddressLine3.value = strArr[2] == "" ? "" : strArr[2];
                txtBusinessAddressLine4.value = strArr[3] == "" ? "" : strArr[3];
                for (var i = 0; i < ddlBusinessCountry.length; i++) {
                    if (ddlBusinessCountry.options[i].text == strArr[4]) {
                        ddlBusinessCountry.selectedIndex = i;
                    }
                }
                txtBusinessPhone.value = strArr[5] == "" ? "" : strArr[5];
                txtEmail.value = strArr[6] == "" ? "" : strArr[6];
                txtBusinessFax.value = strArr[7] == "" ? "" : strArr[7];
            }
        }
        else {
            txtBusinessAddressLine1.value = '<%=BusinessAddressLine1 %>';
            txtBusinessAddressLine2.value = '<%=BusinessAddressLine2 %>';
            txtBusinessAddressLine3.value = '<%=BusinessAddressLine3 %>';
            txtBusinessAddressLine4.value = '<%=BusinessAddressLine4 %>';
            for (var i = 0; i < ddlBusinessCountry.length; i++) {
                if (ddlBusinessCountry.options[i].text == '<%=BusinessCountry %>') {
                    ddlBusinessCountry.selectedIndex = i;
                }
            }
            txtBusinessFax.value = '<%=FaxCopy %>';
            txtBusinessPhone.value = '<%=PhoneNumbercopy %>';
            txtEmail.value = '<%=EmailCopy %>';
        }
    }

    var txt_ContactEmail = document.getElementById("<%=txt_ContactEmail.ClientID %>");
    var getemail_ontextchnage = '';
    var get_oldemail = '';
    function onclick_chkB2bLogin(type) {
        if (getemail_ontextchnage == '' || getemail_ontextchnage == 'undefined' || getemail_ontextchnage == 'null') {
            getemail_ontextchnage = txt_ContactEmail.value;
        }
        var CheckLogin = false;
        var email = txt_ContactEmail.value;
        get_oldemail = txt_ContactEmail.value;
        if (type == "insert") {
            if (chkB2bLogin.checked == true) {
                if (getemail_ontextchnage == "") {
                    spn_txtEmailExp.style.display = "block";
                    txt_ContactEmail.focus();
                    spn_txtEmailExp.innerHTML = ('<%=objLangClass.GetLanguageConversion("Please_Enter_Email")%>');
                    CheckLogin = true;
                }
                else {
                    if (!ValidateEmail(getemail_ontextchnage, 'spn_txtEmailExp', 'no')) {
                        CheckLogin = true;
                    }
                    else {
                        CheckLogin = false;
                        //checkEmilDuplicacynew(email);
                        checkEmailForStoreUser(getemail_ontextchnage);
                    }
                }
            }
            else {
                CheckLogin = true;
                checkEmailForStoreUser(getemail_ontextchnage);
                chkB2bLogin.checked = false;
                spn_txtEmailExp.style.display = "none";
            }
        }
        else if (type == "update") {
            if (chkB2bLoginChngPass.checked == true) {
                if (getemail_ontextchnage == "") {
                    spn_txtEmailExp.style.display = "block";
                    txt_ContactEmail.focus();
                    spn_txtEmailExp.innerHTML = ('<%=objLangClass.GetLanguageConversion("Please_Enter_Email")%>');
                    CheckLogin = true;
                }
                else {
                    if (!ValidateEmail(getemail_ontextchnage, 'spn_txtEmailExp', 'no')) {
                        CheckLogin = true;
                    }
                    else {
                        //                        checkEmilDuplicacynew(txt_ContactEmail.value);
                        if (txt_ContactEmail.value != get_oldemail) {
                            checkEmailForStoreUser(txt_ContactEmail.value);
                        }
                        div_Password.style.display = "block";
                    }
                }
                //txtPassword.value = hdnPassword.value;
            }
            else {
                CheckLogin = true;
                chkB2bLoginChngPass.checked = false;
            }
        }

    if (!CheckLogin) {
        txtPassword.disabled = false;
        txtConfirmPassword.disabled = false;
        chkLoginEmail.disabled = false;
        //div_PasswordArea.style.display = "none";
    }
    else {
        txtPassword.disabled = true;
        txtConfirmPassword.disabled = true;
        //chkLoginEmail.disabled = true;
        chkB2bLogin.checked = false;
        chkB2bLoginChngPass.checked = false;
        txtPassword.value = "";
        txtConfirmPassword.value = "";
    }
}

onclick_chkB2bLogin(loginType);

function opencontacts(val, type) {
    if (val == 'address') {
        if (type == 'change') {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=Contact&pagename=Contact", '', '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        if (type == 'changeSh') {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=Contact&pagename=ContactSh", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'edit') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=edit&pg=Contact&pagename=Contactedit&addressid=" + hdnAddressID.value + "", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'editSh') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=edit&pg=Contact&pagename=ContacteditSh&addressid=" + hdnShippingAddressID.value + "", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
    }

    var hdnAddress = document.getElementById("<%=hdnAddress.ClientID %>");
    var hdnClientID = document.getElementById("<%=hdnClientID.ClientID %>");
    var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
    var lbl_CompanyType = document.getElementById("<%=lbl_CompanyType.ClientID %>");
    var hid_CompanyType = document.getElementById("<%=hid_CompanyType.ClientID %>");

    function GetValues(clientid, clientname, companytype, address) {
        //var ClientValues = document.getElementById("spn_" + clientid + "").innerHTML;
        //var Arr1 = ClientValues.split('±');

        document.getElementById("<%=hid_ClientID.ClientID %>").value = clientid; //Arr1[0];
        //document.getElementById("<%=txtCompanyName.ClientID %>").value = clientname; //Arr1[1];
        document.getElementById("<%=txtCompanyName.ClientID %>").value = clientname; //Arr1[1];
        lbl_CompanyType.innerHTML = companytype; //Arr1[2];
        hid_CompanyType.value = companytype;
        hdnAddress.value = address; //Arr1[3];
        hdnClientID.value = clientid;
        //ShowOff('divCheck');
        document.getElementById("<%=txtCompanyName.ClientID %>").focus();
    }

    var ddlDepartment = document.getElementById("<%=ddlDepartment.ClientID %>");
    var hdnDeptID = document.getElementById("<%=hdnDeptID.ClientID %>");
    function GetDepartmentDetails(Department) {
        // Clearing DDL Items
        ddlDepartment.options.length = 0;

        var deptDetails;
        var defDeptID = 0;
        var defDeptIDIndex = 0;
        var dept = Department.split('±');
        for (var i = 0; i < dept.length; i++) {

            deptDetails = dept[i].split('»');
            ddlDepartment.options.add(new Option(deptDetails[1], deptDetails[0], i));

            if (deptDetails[2] == 1) {
                defDeptID = deptDetails[0];
                defDeptIDIndex = i;
            }
        }
        ddlDepartment.selectedIndex = defDeptIDIndex;
        hdnDeptID.value = defDeptID;
        DeptAddress(defDeptID, 'companyselect');
    }

    var _type;
    function DeptAddress(val, type) {
        _type = type;
        AutoFill.GetDeptAddressDetails('<%=CompanyID %>', val, GetDeptAddress, onTimeout, onError);
    }

    function GetDeptAddress(result) {
        var Address;
        var InvoiceAddress;
        var DeliveryAddress;
        var InvoiceAddressCNT = 0;
        var DeliveryAddressCNT = 0;

        Address = result.split('±');
        if (Address[0] != "") {
            InvoiceAddress = Address[0].split('µ');
            SendAddressIDandNameToContact(InvoiceAddress[0], '', InvoiceAddress[1], InvoiceAddress[2], InvoiceAddress[3], InvoiceAddress[4], InvoiceAddress[5], InvoiceAddress[6], InvoiceAddress[7], InvoiceAddress[8], InvoiceAddress[9], 'billing');
            InvoiceAddressCNT++;
        }

        if (Address[1] != "") {
            DeliveryAddress = Address[1].split('µ');

            SendAddressIDandNameToContact(DeliveryAddress[0], '', DeliveryAddress[1], DeliveryAddress[2], DeliveryAddress[3], DeliveryAddress[4], DeliveryAddress[5], DeliveryAddress[6], DeliveryAddress[7], DeliveryAddress[8], DeliveryAddress[9], 'shipping');
            if ("<%=canChangetheContactAddress %>" != "no") {
                SendAddressIDandNameToContact(DeliveryAddress[0], '', DeliveryAddress[1], DeliveryAddress[2], DeliveryAddress[3], DeliveryAddress[4], DeliveryAddress[5], DeliveryAddress[6], DeliveryAddress[7], DeliveryAddress[8], DeliveryAddress[9], 'contactaddress');
            }
            DeliveryAddressCNT++;
        }

        if (InvoiceAddressCNT == 0) {
            SendAddressIDandNameToContact(0, '', '', '', '', '', '', '', '', '', '', 'billing');
            InvoiceAddressCNT = 0;
        }
        if (DeliveryAddressCNT == 0) {
            SendAddressIDandNameToContact(0, '', '', '', '', '', '', '', '', '', '', 'shipping');
            if ("<%=canChangetheContactAddress %>" != "no") {
                SendAddressIDandNameToContact(0, '', '', '', '', '', '', '', '', '', '', 'contactaddress');
            }
            DeliveryAddressCNT = 0;
            div_Edit_Change.style.display = "none";
        }
    }

    function ddlDept_OnChange(val) {
        hdnDeptID.value = val;
        DeptAddress(val, 'deptselect');
    }

    function RemoveHiddenField() {
        hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");

        if (document.getElementById("<%=txtCompanyName.ClientID %>").value != '') {
            if (hid_ClientID.value != '0') {
                var ClientValues = document.getElementById("spn_" + hid_ClientID.value + "").innerHTML;
                var Arr1 = ClientValues.split('±');
                if (Arr1[1] != document.getElementById("<%=txtCompanyName.ClientID %>").value) {
                    document.getElementById("<%=hid_ClientID.ClientID %>").value = '0';
                    document.getElementById("<%=txtCompanyName.ClientID %>").value = '';
                    document.getElementById("<%=txtCompanyName.ClientID %>").focus();
                }
            }
        }
    }

    var CompanyType = '<%=CompanyType %>';
    var pg = '<%=pg %>';
    var wintype = '<%=wintype %>';

    function addNewDepartment(val, type, clientid, contactid) {
        if (type == 'add') {
            if (val == 'contact') {
                if (wintype == 'main' && hdnClientID.value == 0) {
                    alert('Please select any compnay name.');
                    document.getElementById("<%=txtCompanyName.ClientID %>").focus();
                }
                else {
                    __doPostBack('ctl00$ContentPlaceHolder1$UCContact$lnk_redirect', '');
                }
            }
        }
    }

    function SendDeptIDandName(DeptID, DeptName) {
        ddlDepartment.options.add(new Option(DeptName, DeptID, ddlDepartment.options.length));
    }

    function GetContactAddress(val) {

        if (wintype == 'main') {
            if (val == 'edit') {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=" + hdnClientID.value + "&mode=add&pg=" + pg + "&companytype=" + CompanyType + "&pagename=Contact&from=contacteditmode_edit&wintype=main&addressid=" + hdnContactAddressID.value, '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=" + hdnClientID.value + "&mode=edit&pg=" + pg + "&companytype=" + CompanyType + "&pagename=ContactAddress&action=edit&from=contacteditmode_ch&wintype=" + wintype, '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            return false;
        }
        else

            return true;

        //        if (val == 'change') {
        //            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=" + hdnClientID.value + "&mode=edit&pg=" + pg + "&companytype=" + CompanyType + "&pagename=ContactAddress&action=edit&from=contacteditmode_ch&wintype=main", '800', '400');
        //            SetRadWindow('divrad', 'divBackGroundNew', '200');
        //            return false;
        //        }
    }

</script>
<asp:Panel ID="pnlcopyAddress" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        //CopyAddress();
    </script>
</asp:Panel>
<div id="div_loading" align="left" style="position: absolute; height: 50px; width: 200px; top: 45%; left: 45%; display: none;">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function CallNow() {
            document.getElementById("div_loading").style.display = "block";
            var contactValue = '<%=strFinalData %>';
            var ContactID = '<%=retContactID %>';
            var Pgtype = '<%=pg %>';
            if ((Pgtype == 'purchase') || (Pgtype == 'deliverynote')) {
                window.parent.ReloadContact(contactValue, ContactID);
            }
            else {
                window.parent.ReloadContact(contactValue, hdnDeptID.value, ddlDepartment.options[ddlDepartment.selectedIndex].text, hdnContactAddressID.value, hdn_ContactAddressDetails.value, hdnShippingAddressID.value, hdn_DeliveryAddressDetails.value, hdnAddressID.value, hdn_InvoiceAddressDetails.value, ContactID);
            }
            setTimeout("TakeOut()", 1000);
        }

        function TakeOut() {
            window.close();
        }
        CallNow();
    </script>
</asp:Panel>
<asp:Panel ID="pnlWinClose1" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function CallNow1() {
            document.getElementById("div_loading").style.display = "block";
            var contactValue = '<%=strFinalData %>';
            window.parent.ReloadContact1(contactValue); //Changed from opener to parent on 22.09.2011.
            setTimeout("TakeOut()", 2000);
        }
        function TakeOut() {
            window.close();
        }
        CallNow1();
    </script>
</asp:Panel>
<asp:Panel ID="pnlContactClose" runat="server" Visible="false">
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
</asp:Panel>
<asp:Panel ID="pnlContacts" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        var ContactID = '<%=retContactID %>';
        var txtLastName = document.getElementById("<%=txtLastName.ClientID %>");
        var txtFirstName = document.getElementById("<%=txtFirstName.ClientID %>");
        var ContactName = txtFirstName.value + ' ' + txtLastName.value;

        function sendContacts(contactid, contactname) {
            var pw = window.parent;
            window.parent.GetContactName(contactid, contactname);
            setTimeout("TakeOut()", 3000);
        }
        function TakeOut() {
            window.close();
        }

        sendContacts(ContactID, ContactName);

    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">

    function Close() {
        //        var oWindow = GetRadWindow();
        //        oWindow.argument = null;
        //        oWindow.close();

        GetRadWindow().close();

    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
        //oWindow.close();
    }

    function clientClose(arg) {
        GetRadWindow().close(arg);
    }



</script>
<script>
    function chkMainApproverchanged() {
        var hid_maiapprovercount = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_hid_Mainapprovercount").value;
        var hid_Type = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_hid_type").value;
        var chkapprover = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_chkMainApprover").checked;

        if (hid_maiapprovercount > 0 && chkapprover == true && hid_Type == "add") {
            alert("If you change the approver any orders which are currently awaiting approval will be lost.Please login to the approver's account and check if there are any orders awaiting approval before changing the approver.");
            return false;
        }

        if (hid_maiapprovercount > 0 && hid_Type == "editTrue" && chkapprover == false) {
            alert("If you change the approver any orders which are currently awaiting approval will be lost.Please login to the approver's account and check if there are any orders awaiting approval before changing the approver.");
            return false;

        }

        if (hid_maiapprovercount > 0 && hid_Type == "editFalse" && chkapprover == true) {
            alert("If you change the approver any orders which are currently awaiting approval will be lost.Please login to the approver's account and check if there are any orders awaiting approval before changing the approver.");
            return false;
        }
    }
    var lblContactImage = document.getElementById('<%=lblContactImage.ClientID %>');
    var hid_ContactImage = document.getElementById('<%=hid_ContactImage.ClientID %>');
    var ContactImage = document.getElementById('<%=ContactImage.ClientID %>');
    var hid_Actualfilename = document.getElementById('<%=hid_Actualfilename.ClientID %>');
    var hid_Originalfilename = document.getElementById('<%=hid_Originalfilename.ClientID %>');
    var ImageUpload = document.getElementById('<%=ImageUpload.ClientID %>');

    function FileUploadClearText() {
        ImageUpload.value = "";
        document.getElementById('<%=FileTextClear.ClientID%>').style.display = "none";
    }

    function RemoveImage() {
        hid_Actualfilename.value = "";
        hid_Originalfilename.value = "";
        lblContactImage.innerHTML = "";
        hid_ContactImage.value = "";
        ContactImage.style.display = "none";
        lblContactImage.style.display = "none";
        ImageUpload.style.display = "block";
        var img_delete = document.getElementById("img_delete");
        if (img_delete != null && img_delete != undefined) {
            img_delete.style.display = "none";
        }
    }

    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById("<%=ImageUpload.ClientID%>");
        var FileUploadPath = fuData.value;


        if (FileUploadPath == '') {
            // There is no file selected
            args.IsValid = false;
        }
        else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "jpg" || Extension == "png" || Extension == "gif" || Extension == "jpeg" || Extension == "pdf") {
                var divext = document.getElementById("Spn_ImageUploadFile");
                divext.style.display = 'none';
                document.getElementById('<%=FileTextClear.ClientID%>').style.display = "block";
                document.getElementById('<%=DivClear.ClientID%>').style.display = "block";
                ContactImage.style.display = "none"
                args.IsValid = true; // Valid file type
            }
            else {
                fuData.value = '';
                var divext = document.getElementById("Spn_ImageUploadFile");
                divext.style.display = 'block';
                document.getElementById('<%=FileTextClear.ClientID%>').style.display = "none";
                document.getElementById('<%=DivClear.ClientID%>').style.display = "none";
                args.IsValid = false; // Not valid file type                        
            }
        }
    }

</script>
<asp:Panel ID="pnlLoadContactPanel" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function LoadContactPanel() {
            var pw = window.parent;
            pw.SetTabs('contacts', 'yes');
            return false;
        }

        function TakeOut() {
            window.close();
        }


        LoadContactPanel();
    </script>
</asp:Panel>

