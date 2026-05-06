<%@ Page Language="C#" MasterPageFile="~/Templates/settingpage.master" AutoEventWireup="true" CodeBehind="user_add.aspx.cs" Inherits="ePrint.settings.user_add" Title="Settings: User Add" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy3" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var pageMode = "<%= hdntype.Value%>";

        document.addEventListener('DOMContentLoaded', function() {
            
            if (pageMode == "add")
            {
                //Hide Change Password Link
                document.getElementById('divLnkChangePassword').style.display = 'none';
            }else
            {
                //Show Change Password Link
                document.getElementById('divLnkChangePassword').style.display = 'block';
            }
        }, false);

        function enablePasswordFields() {
            if (pageMode == "edit")
            {
                document.getElementById('divLnkChangePassword').style.display = 'block';
                //Disable password fields
                document.getElementById('ctl00_ContentPlaceHolder1_txtpassword').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_txtconfirmpassword').disabled = false;
                document.getElementById("spnPasswordAsterik").style.display = 'none';
                document.getElementById("spnConfirmPasswordAsterik").style.display = 'none';

            }else
            {
                //Hide Change Password Link
                document.getElementById('divLnkChangePassword').style.display = 'none';
                //Enable password fields
                document.getElementById('ctl00_ContentPlaceHolder1_txtpassword').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_txtconfirmpassword').disabled = true;     
                document.getElementById("spnPasswordAsterik").style.display = 'block';
                document.getElementById("spnConfirmPasswordAsterik").style.display = 'block';
            }
        }

    </script>
    <div style="display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Add_New_User")%></asp:Label>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="" OnClientClose="bindUploadimgname"
                KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true" Modal="true"
                ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div style="width: 100%; border: 0px solid red" class="mis_header_panel">
            <div id="">
                <div align="left" style="width: 100%;">
                    <div align="center">
                        <asp:Label ID="lblerror" CssClass="errorMsg" runat="server" Text="This Email address already exist,Please try again.!"
                            Visible="false">
                                <%=objLanguage.GetLanguageConversion("EmailAddress_Duplicate_Message") %></asp:Label>
                    </div>
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("User_Name")%>
                                <span style="color: red">*</span>
                            </div>
                            <div class="box" style="width: 65%;">
                                <asp:TextBox ID="txtname" MaxLength="100" runat="server" SkinID="textPad">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvname" runat="server" ErrorMessage="Please enter User Name"
                                    CssClass="errorMsg" ForeColor="" ControlToValidate="txtname" Display="Dynamic"
                                    Style="width: auto; padding-left: 4px; padding-right: 4px">
                                        <%=objLanguage.GetLanguageConversion("Please_Enter_User_Name")%></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("User_Email")%>
                                <span style="color: red">*</span>
                            </div>
                            <div class="box" style="width: 65%;">
                                <div style="float: left">
                                    <asp:TextBox ID="txtemail" runat="server" SkinID="textPad" MaxLength="250">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="Please enter Email"
                                        CssClass="errorMsg" ForeColor="" ControlToValidate="txtemail" Display="Dynamic"
                                        Style="width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Email")%></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor=""
                                        CssClass="errorMsg" Width="200px" Display="Dynamic" ErrorMessage="Email ID is Incorrect"
                                        Style="width: auto; padding-left: 4px; padding-right: 4px" ControlToValidate="txtemail"
                                        ValidationExpression="^((['\w])*[0-9a-zA-Z]([-.'\w]*[0-9a-zA-Z])*(['\w])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">
                                            <%=objLanguage.GetLanguageConversion("EmailID_Is_Incorrect")%></asp:RegularExpressionValidator>
                                </div>
                                <div id="spn_txtPlantPressCheck" style="display: none; width: auto; float: left; padding-left: 4px; padding-right: 4px">
                                    <div class="RFV_Message">
                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Email_Already_Exists")%></span>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                       
                        <div align="left">
                            <div id="divLnkChangePassword" class="box" style=" display:none;width: 75%; height: 25px;">
                                <a id="lnkChangePassword" href="#" onclick="return enablePasswordFields();"
                                    style="font-weight: bold; text-decoration: underline" >Change Password</a>
                            </div>

                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Password")%>
                                <span id="spnPasswordAsterik" style="color: red">*</span>
                            </div>
                            <div class="box" style="white-space: nowrap;">
                                <asp:TextBox ID="txtpassword" runat="server" SkinID="textPad" MaxLength="25" TextMode="Password">
                                </asp:TextBox>
                                <span id="span_txtpassword" class="errorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                    <%=objLanguage.GetLanguageConversion("Password_Cant_Accept_Single_Quote")%>
                                </span>
                                <asp:RequiredFieldValidator ID="rvfpassword" runat="server" ErrorMessage="Please enter Password"
                                    CssClass="errorMsg" ForeColor="" ControlToValidate="txtpassword" Display="Dynamic"
                                    Style="width: auto; padding-left: 4px; padding-right: 4px">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 24%">
                                    <%=objLanguage.GetLanguageConversion("Confirm_Password")%>
                                    <span id="spnConfirmPasswordAsterik" style="color: red">*</span>
                                </div>
                                <div class="box" style="white-space: nowrap;">
                                    <asp:TextBox ID="txtconfirmpassword" runat="server" SkinID="textPad" MaxLength="25"
                                        TextMode="Password">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Confirm Password"
                                        CssClass="errorMsg" ForeColor="" ControlToValidate="txtconfirmpassword" Display="Dynamic"
                                        Style="width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_ConfirmPassword") %></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvpassword" runat="server" ControlToCompare="txtpassword"
                                        CssClass="errorMsg" ForeColor="" ControlToValidate="txtconfirmpassword" Display="Dynamic"
                                        ErrorMessage="Password mismatch" Style="width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Password_Mismatch")%>
                                    </asp:CompareValidator>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 24%">
                                    <%=objLanguage.GetLanguageConversion("User_Image")%>
                                </div>
                                <div class="userimg_box">
                                    <a class="mainheader" runat="server" id="ancUploadimage" href="javascript:void(0);"
                                        onclick="javascript:openPopupCrop();">
                                        <%=objlang.GetLanguageConversion("Upload_Image") %></a>
                                    <div id="div_uploadedimagename" class="div_uploadimg">
                                        <a href="javascript:void(0);" id="lnkUpimagepath" runat="server"></a>
                                    </div>
                                    <div class="mainheader">
                                        <asp:Label ID="lblUserImage" runat="server" CssClass="Normaltext show_hide"></asp:Label>
                                    </div>
                                    <div class="mainheader">
                                        <span class="smallgraytext helptext_leftpadding">
                                            <%=objLanguage.GetLanguageConversion("User_Image_Size")%>
                                        </span>
                                    </div>
                                </div>
                                <div class="userimg_box">
                                    <asp:HiddenField ID="hid_UserImage" runat="server" Value="" />
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 24%">
                                    <%=objLanguage.GetLanguageConversion("Assign_Role")%>
                                </div>
                                <div class="ddlsetting" style="margin-left: -2px; margin-top: -3px;">
                                    <asp:DropDownList ID="ddlrole" runat="server" CssClass="normalText" Width="182px"
                                        onChange="javascript:changedata(this.value);">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="DivActiveUserForSalesTarget" style="display: block;" align="left">
                                <div class="bglabel" style="width: 24%">
                                    <%=objLanguage.GetLanguageConversion("Active_advanced_CRM_functions")%>
                                </div>
                                <div class="box" style="margin-left: -3px;">
                                    <asp:CheckBox ID="ChkActiveUserForSalesTarget" runat="server" />
                                </div>
                                <div class="box" style="margin-left: 0px; width: 400px;">
                                    <asp:Label ID="lblIsadvanceCrmMsg" runat="server" Visible="false" CssClass="smallgraytext"
                                        Text=""><%=objLanguage.GetLanguageConversion("Enabled_Advance_Crm")%></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both;">
                            &nbsp;
                        </div>
                    </div>
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Job_Title")%>
                                <span style="color: red"></span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtJobTitle" runat="server" MaxLength="20" SkinID="textPad">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Phone")%>
                                <span style="color: red"></span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" SkinID="textPad">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Mobile") %>
                                <span style="color: red"></span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="20" SkinID="textPad">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Fax") %>
                                <span style="color: red"></span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtFax" MaxLength="50" runat="server" SkinID="textPad">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Default_Landing")%>
                                <span style="color: red"></span>
                            </div>
                            <div class="ddlsetting" style="margin-left: -2px; margin-top: -3px;">
                                <asp:DropDownList ID="ddlDefaultLanding" runat="server" CssClass="normalText" Width="182px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="height: 50px; width: 24%">
                                <%=objLanguage.GetLanguageConversion("Description")%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtDescription" SkinID="textPad" TextMode="MultiLine" Height="50px"
                                    Columns="23" runat="server" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');">
                                </asp:TextBox>
                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                    <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%>
                                </span>
                            </div>
                        </div>
                        <div align="left" id="divLocation" runat="server">
                            <div class="bglabel" style="width: 24%">
                                Location
                                <span style="color: red"></span>
                                <div style="float: right;">
                                    <asp:ImageButton ID="imgShowMarkup" runat="server" ImageUrl="~/images/plus.gif" OnClientClick="javascript:ShowPopup(); return false;"
                                        CausesValidation="false" />
                                </div>
                            </div>
                            <div class="ddlsetting" style="margin-left: -2px; margin-top: -3px;">
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="normalText" Width="182px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div_dsbacct" style="display: none" align="left">
                            <div class="bglabel" style="width: 24%">
                                <%=objLanguage.GetLanguageConversion("Suspend_User")%>
                            </div>
                            <div class="box" style="margin-left: -3px;">
                                <asp:CheckBox ID="chkDisableAccount" runat="server" />
                            </div>
                        </div>
                        <div align="left" style="width: 70%;">
                            <div style="float: left; padding-top: 18px; margin-left: 5px;">
                                <div id="div_btnsave" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                        runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_cancelprocess" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 2px" class="loadingimg"
                                        alt="loading" border="0" />
                                </div>
                            </div>
                            <div id="div1" style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div style="float: left; padding-top: 18px;">
                                <div id="div_btndelete" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" runat="server" EnableEmbeddedSkins="false" ID="btndelete"
                                        runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" OnClick="btndelete_OnClick">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_deleteprocess" class="button" align="center" style="height: 14px; width: 38px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="float: left; width: 10px;" id="div_delete" runat="server">
                                &nbsp;
                            </div>
                            <div style="float: left; padding-top: 18px;">
                                <div id="btnsave" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                        runat="server" Text="Save" OnClick="btnSave_OnClick">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div align="right" style="width: 50%;">
                    </div>
                </div>
            </div>
            <div style="clear: both">
                &nbsp;
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdntype" runat="server" />
    <script type="text/javascript" language="javascript">

        var strSitePath = '<%=strSitePath %>';           
        var UserCount = <%=UserCount %>;
        var NoOfUser = <%=NoOfUser %>;
        var UserID = <%=userid%>
        var RestrictionMsg=  '<%=objLanguage.GetLanguageConversion("Sorry_maximum_user_creation_limit_is_over_please_contact_supporteprintsoftwarecom_to_create_more_user")%>';
        var lbluserimg =  document.getElementById("ctl00_ContentPlaceHolder1_lblUserImage");
        var hid_UserImage = document.getElementById("<%=hid_UserImage.ClientID%>");
        var ancUploadimage = document.getElementById('<%= ancUploadimage.ClientID %>')
        var lnkUpimagepath = document.getElementById('<%= lnkUpimagepath.ClientID %>')

        function openPopupCrop() {
            var mode = document.getElementById("<%=hdntype.ClientID %>").value;
            var oWnd = $find("<%=RadWindow1.ClientID %>");
            if (mode == "add") {
                oWnd.setUrl(strSitePath  + "UploadAndCrop.aspx?from=Settings/user_add&UserID=" + "add");
                oWnd.setSize(700, 490);
                oWnd.center();
                oWnd.show();
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else {
                oWnd.setUrl(strSitePath + "UploadAndCrop.aspx?from=Settings/user_add&UserID=" + UserID);
                oWnd.setSize(700, 490);
                oWnd.center();
                oWnd.show();
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }

        function RestrictedPopUp() {         
            if (NoOfUser > UserCount) {
                return true;
            }
            else {
                alert(RestrictionMsg);                   
                window.location=strSitePath + "Settings/user_manager.aspx";
                // return false;                  
            }
        }      
     

        function start() {
            var type = "<%=type %>";
            var div_dsbacct = document.getElementById("div_dsbacct");
            if (type == 'edit') {
                div_dsbacct.style.display = "block";
            }
            else {
                div_dsbacct.style.display = "none";
            }
        }
        window.onload = start
    </script>
    <script>
        var IsDuplicate = false;
        function CheckMailDuplicacy(val1) {
            if (val1 != '') {
                var compID = '<%=CompanyID %>';
                var id = '<%=userid %>';
                var val = compID + "±" + val1 + "±" + "user" + "±" + id;
                PageMethods.Getmailduplicacy(val, ShowMsgsuccess, ShowMsg_Failure);
            }
        }
        function ShowMsgsuccess(result) {
            $get('spn_txtPlantPressCheck').style.display = "none";
            if (result == -1) {
                $get('spn_txtPlantPressCheck').style.display = "block";
                IsDuplicate = true;
            }
            else {
                IsDuplicate = false;
            }

        }

        function ShowMsg_Failure(error) {
        }

      
    </script>
    <script type="text/javascript">
        function changedata(ddlvalue) {
            var companyid = '<%=CompanyID %>';
            // getdatafrmsp(companyid, ddlvalue);
            AutoFill.crm_common_select_accessrightOfUserType(companyid, ddlvalue, Onsuccuss);
        }

        function Onsuccuss(result) {

            if (result != '') {
                var opt = null;

                var StrName = '';
                var divCheck = document.getElementById("ctl00_ContentPlaceHolder1_ddlDefaultLanding");

                var len = divCheck.options.length;
                for (i = 0; i < len; i++) {
                    divCheck.remove(0);
                }


                var SpltName = result.split(',');

                for (var i = 0; i < SpltName.length - 1; i++) {
                    opt = new Option(SpltName[i], SpltName[i]);
                    divCheck.add(opt);
                }

            }
            else {

            }

        }
        
    
    </script>
    <asp:Panel ID="pnlCheck" runat="server" Visible="false">
        <script>
            function validate() {
                document.getElementById('spn_txtPlantPressCheck').style.display = "block";
            }
            validate();
        </script>
    </asp:Panel>

    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Location"
        Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="systemMarkup" runat="server" DestroyOnClose="true" Width="430"
                Height="200">
                <ContentTemplate>
                    <div id="divMarkup" class="SystemMarkup_Main" align="center">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <div style="padding: 10px 5px 10px 10px; width: 98%">
                                        <div class="" style="width: 100%">
                                            <div id="Div1">
                                                <div align="left" style="width: 100%;">
                                                    <div align="left">
                                                        <div>
                                                            <div class="UploadFont_bglabel">
                                                                <asp:Label ID="Label2" runat="server" CssClass="normalText"></asp:Label>
                                                                <span style="color: red">Location*</span>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtMarkupName" runat="server" SkinID="textPad"></asp:TextBox>
                                                            </div>
                                                            <div>
                                                                <asp:RequiredFieldValidator ID="RFVMarkupName" runat="server" ErrorMessage="Please enter Markup Name"
                                                                    ControlToValidate="txtMarkupName" CssClass="errorMsg box" ForeColor=" " Style="margin-top: 2px; margin-left: 4px; width: auto; padding-left: 4px; padding-right: 4px;"
                                                                    Display="dynamic"
                                                                    ValidationGroup="VGmarkupadd"> <%=objlang.GetLanguageConversion("Please_Enter_Paper_markup")%></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="only10px">
                                                </div>
                                                <div align="left" style="width: 500px">
                                                    <div class="SystemMarkup_bglabelEmpty" style="width: 100px">
                                                        &nbsp;
                                                    </div>
                                                    <%--<div style="float: left">
                                                        <telerik:RadButton EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                                                            CssClass="Button" ID="Button2" runat="server" Style="display: none" Text="Cancel"
                                                            CommandName="Cancel" CausesValidation="false">
                                                        </telerik:RadButton>
                                                    </div>--%>
                                                    <div style="float: left; width: 5px">
                                                        &nbsp;
                                                    </div>
                                                    <div id="div_btnDelete" style="float: left; display: block">
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                            runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" OnClick="btndelete_Click">
                                                        </telerik:RadButton>
                                                    </div>
                                                    <div style="float: left; width: 5px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:Button ID="btnSaveMarkup" runat="server" Text="Update" CssClass="button" OnClick="btnSaveMarkup_Click"
                                                            ValidationGroup="VGmarkupadd" OnClientClick="javascript:setHdn('edit');" />
                                                        <%-- <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSaveMarkup"
                                                            runat="server" Text="Update" OnClick="btnSaveMarkup_OnClick" ValidationGroup="VGmarkupadd">
                                                        </telerik:RadButton>--%>
                                                    </div>
                                                    <div style="float: left; width: 5px;">
                                                    </div>
                                                    <div style="float: left; padding-left: 5px">
                                                        <%-- <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnAdd" runat="server"
                                                            Text="Save as new" ValidationGroup="VGmarkupadd" OnClick="btnSaveMarkup_OnClick">
                                                        </telerik:RadButton>--%>
                                                        <asp:Button ID="btnAdd" runat="server" Text="Save as new" CssClass="button" OnClick="btnAdd_Click1"
                                                            ValidationGroup="VGmarkupadd" OnClientClick="javascript:setHdn('add');" />
                                                    </div>
                                                </div>
                                                <div class="only5px">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">
        function popup_markup(section) {
            var ddl_Markup = document.getElementById('<%=ddlLocation.ClientID %>');
            if (ddl_Markup.selectedIndex != 0) {
                window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=markup&pg=" + section + "&page=edit", '', 'width=550px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
            }
            else {
                window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=markup&pg=" + section + "&page=add", '', 'width=550px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
            }
        }
    </script>

    <script type="text/javascript">
     
        var ddl_Location = "<%=ddlLocation.ClientID %>";
       
        var txt_MarkupName = "<%=txtMarkupName.ClientID %>";

     

        function ShowPopup() {
            debugger;
            var oWnd = $find("<%=systemMarkup.ClientID%>");
            oWnd.show();

            if (document.getElementById(ddl_Location).selectedIndex != -1) {
                var ddl_Location_IndexValue = $get(ddl_Location).selectedIndex;
                var ddl_Location_Text = $get(ddl_Location).options[ddl_Location_IndexValue].text;
                var ddl_Location_Value = $get(ddl_Location).options[ddl_Location_IndexValue].value;
                document.getElementById(txt_MarkupName).value = ddl_Location_Text;
              
               
             

            }
            else {
                clearMarkup();
            }
        }

        function clearMarkup() {
            document.getElementById(txt_MarkupName).value = "";
        
        }

        function validatemarkup() {
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

