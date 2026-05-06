<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="email_template.ascx.cs" Inherits="ePrint.usercontrol.email_template" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<script type="text/javascript" src="<%=strSitePath %>js/commonloading.js?VN='<%=VersionNumber%>'"></script>
<div>
    <asp:Panel ID="pnlScriptEditor" Visible="true" runat="server">
    </asp:Panel>
    <script type="text/javascript">
        function showhidetemplatefield() {
            var x = document.getElementById('ctl00_ContentPlaceHolder1_txttemplatename');
            //alert(eval("x.style.display='none'"));
            var y = eval("x.style.display");
            //alert (y);    
            if (y == 'none') {
                eval("x.style.display='block'")
            }
            else {
                eval("x.style.display='none'")
            }
        }
        function RefreshMyData() {
            //alert('RefreshMyData');        
            var myHdnRefreshData = document.getElementById(<%= "'" + hdnRefreshData.ClientID + "'" %>);
            myHdnRefreshData.value = '1';
            window.document.forms[0].submit();
        }
    </script>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
        <tr>
            <td>
                <input id="hdnRefreshData" runat="server" type="hidden" value="" />
                <asp:PlaceHolder ID="plhHeader" runat="server" Visible="false"></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>
                <div align="left" id="div_EmailFromEprint" runat="server" style="width: 100%; display: none">
                    <table align="left" cellpadding="0" cellspacing="0" border="0" width="100%">
                        <%--class="borderWithoutTop"--%>
                        <tr>
                            <td>
                                <table cellspacing="2" cellpadding="5" width="100%" align="left" border="0">
                                    <tr>
                                        <td width="19%">
                                        </td>
                                        <td align="left">
                                            <div id="div_btncancel" style="display: block">
                                                <asp:Button ID="Button1" runat="server" CssClass="button" Width="65px" Text="Cancel"
                                                    OnClientClick="javascript:loadingimg('div_btncancel','div_cancelprocess');" OnClick="btncancel_Click"
                                                    CausesValidation="False"></asp:Button>
                                            </div>
                                            <div id="div_cancelprocess" class="button" align="center" style="width: 51px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="div_btnsend2" style="display: block">
                                                <asp:Button ID="Button2" runat="server" CssClass="button" OnClientClick="javascript:var a=checkvalidaetion();if(a)loadingimg('div_btnsend2','div_btnsend2process');return a;"
                                                    Width="65px" OnClick="btnsend_Click" Text="Send"></asp:Button><%--OnClick="btnsend_Click"--%>
                                            </div>
                                            <div id="div_btnsend2process" class="button" align="center" style="width: 51px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td width="100%">
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="2" cellpadding="2" width="100%" align="left" border="0">
                                    <%--<tr valign="top">
                                    <td colspan="2">
                                        <img height="2" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                    </td>
                                </tr>--%>
                                    <tr>
                                        <td valign="top" width="5%" class="label">
                                            <%--class="newLabelText"--%>
                                            &nbsp;<asp:Label ID="lblassigned" runat="server" CssClass="normaltext" Style="color: Black"><%=objLanguage.GetLanguageConversion("To")%></asp:Label>
                                            <div style="float: right" class="normalText">
                                                &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer; padding: 5 0 5 0px"
                                                    ID="imgselectleadmain" runat="server" Visible="true" onclick="javascript:CallTopopup(this);" />
                                            </div>
                                        </td>
                                        <td class="normaltext" align="left" width="95%">
                                            <div align="left" style="width: 100%">
                                                <div style="float: left" class="normalText">
                                                    <textarea class="txtbox" rows="2" cols="55" name="txtfirstname" id="txtfirstname"
                                                        runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_To')"></textarea>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                            </div>
                                            <div align="left" style="width: 100%">
                                                [<%=objLanguage.GetLanguageConversion("Comma_Separate_Email_Note")%>] &nbsp;<span
                                                    id="spn_To" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                    display: none">Please enter valid email</span>
                                            </div>
                                            <script>
                                                function validateEmail(field) {
                                                    // var regex = /\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b/i;                                                   
                                                    //var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                                                    //var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                                                    var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                                                    return (regex.test(field)) ? true : false;
                                                }


                                                function validateMultipleEmailsCommaSeparated(value, spnid) {
                                                    document.getElementById(spnid).style.display = "none";
                                                    if (value == '') {
                                                        if (spnid == 'spn_To') {
                                                            document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Email_Address") %>';
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
                                                            var email = result[i].trim().replace(',', '');
                                                            if (!validateEmail(email)) {
                                                                document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email_Address") %>';
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
                                            </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label" valign="top" align="left" width="5%">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("CC")%></span>
                                        </td>
                                        <td class="normaltext" align="left" width="95%">
                                            <%-- <textarea name="txtcc" rows="2" cols="55" id="txtcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_To')"></textarea>&nbsp;&nbsp;<asp:Image
                                            Style="vertical-align: middle; cursor: pointer" ID="imgselectleadcc" runat="server"
                                            Visible="false" />&nbsp;
                                       
                                        <br>
                                        [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                        (,)]--%>
                                            <div style="border: solid 0px red; width: 100%">
                                                <div align="left">
                                                    <textarea name="txtcc" rows="2" cols="55" id="txtcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_cc')"></textarea>
                                                    &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadcc"
                                                        runat="server" Visible="false" /><br />
                                                    [<%=objLanguage.GetLanguageConversion("Comma_Separate_Email_Note")%>]&nbsp;<span
                                                        id="spn_cc" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none"><%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email") %></span>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left" width="5%" class="label">
                                            <%--class="newLabelText"--%>
                                            &nbsp;<asp:Label ID="Label2" runat="server" Width="75px" CssClass="normaltext" Style="color: Black"><%=objLanguage.GetLanguageConversion("BCC")%></asp:Label>
                                        </td>
                                        <td class="normaltext" align="left" width="95%">
                                            <%--<textarea name="txtbcc" rows="2" cols="55" id="txtbcc" runat="server"></textarea>&nbsp;&nbsp;<asp:Image
                                            Style="vertical-align: middle; cursor: pointer" ID="imgselectleadbcc" runat="server"
                                            Visible="false" />&nbsp;
                                       
                                        <br>
                                        [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                        (,)]--%>
                                            <div style="border: solid 0px red; width: 100%">
                                                <div align="left">
                                                    <textarea name="txtbcc" rows="2" cols="55" id="txtbcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_bcc')"></textarea>
                                                    &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadbcc"
                                                        runat="server" Visible="false" /><br />
                                                    [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                                    (,)]&nbsp;<span id="spn_bcc" class="spanerrorMsg" style="width: auto; padding-left: 4px;
                                                        padding-right: 4px; display: none">Please enter valid email</span>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left" width="5%" class="label">
                                            <%--class="newLabelText"--%>
                                            &nbsp;<asp:Label ID="Label3" runat="server" Width="75px" CssClass="normaltext" Style="color: Black"><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label>
                                            <span class="normaltext" style="padding-top: 3px;"></span>
                                        </td>
                                        <td align="left" width="95%" class="normaltext">
                                            <input class="txtbox" style="height: 30px" type="text" maxlength="200" size="75"
                                                name="txtsubject" id="txtsubject" onkeydown="return handleEnterKeyPress(event);" onblur="javascript:validatesubject(this.value);"
                                                runat="server">
                                            <div class="error_top">
                                                <%--<asp:RequiredFieldValidator ID="reqtxtattachment" ForeColor="" runat="server" ControlToValidate="txtsubject"
                                                CssClass="error" Width="120px" Display="dynamic"></asp:RequiredFieldValidator>--%>
                                                <span id="spn_subject" class="spanerrorMsg" style="width: auto; padding-left: 4px;
                                                    padding-right: 4px; display: none">Please enter subject</span>
                                            </div>
                                            <script>
                                                function validatesubject(value) {
                                                    if (value == '') {
                                                        document.getElementById("spn_subject").style.display = "block";
                                                    }
                                                    else {
                                                        document.getElementById("spn_subject").style.display = "none";
                                                    }
                                                }

                                                function handleEnterKeyPress(event) {
                                                    debugger;
                                                    if (event.key === "Enter" || event.keyCode === 13) {
                                                        event.preventDefault(); // Prevent the default behavior (form submission)
                                                        return false; // Optionally, return false to ensure the event is fully canceled
                                                    }
                                                }

                                            </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left" width="5%" class="label" style="border: 0px solid red;">
                                            <%--class="newLabelText"--%>
                                            &nbsp;<asp:Label ID="Label4" runat="server" Width="75px" CssClass="normaltext" Style="color: Black"><%=objLanguage.GetLanguageConversion("Attachments")%></asp:Label>
                                            <div style="float: right; cursor: pointer;">
                                                <asp:Image ID="Image_Attachment" runat="server" ImageUrl="~/images/plus.gif" Visible="true"
                                                    ToolTip="Add new attachment(s)" onclick="Javascript:Call_Attachment();" />
                                            </div>
                                        </td>
                                        <td align="left" width="95%" class="normaltext" style="border: 0px solid red; padding-bottom: -10px;">
                                            <input class="txtbox" style="height: 18px; border: 1px solid white;" readonly="readonly"
                                                type="text" size="75" name="txtattachment"  onkeydown="return handleEnterKeyPress(event);" id="txtattachment" runat="server">
                                            <a id="LinkButton1" runat="server" style="cursor: pointer; display: none">Attach File</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="border: 0px solid green; padding-top: -10px;">
                                            <div id="Div_Attach" runat="server" style="border: 0px solid green; width: 500px;"
                                                enableviewstate="true">
                                            </div>
                                            <asp:HiddenField ID="hdn_GetAttached" runat="server" Value="" />
                                            <asp:HiddenField ID="hdn_Attach" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnEmailAttachment_ActualName" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnEmailAttachment_OriginalName" runat="server" Value="" />
                                            <asp:HiddenField ID="hdn_attachboth" runat="server" Value="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <div style="padding: -15px 0px 10px 0px; border: 0px solid green;">
                                                <asp:UpdatePanel ID="Uppnl_Attach" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div style="float: left;">
                                                            <asp:PlaceHolder ID="plh_Attach" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                        <asp:HiddenField ID="hdn_Attach_PO" runat="server" Value="" />
                                                        <asp:LinkButton ID="lnk_AttachUpdate" runat="server" Text=""></asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <%--OnClick="lnk_AttachUpdate_OnClick--%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display: none; padding-top: 10px;">
                                        <td class="label" style="width: 17%" nowrap="nowrap">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext" style="color: Black">&nbsp;<%=objLanguage.convert("Email type")%></span>
                                        </td>
                                        <td class="Normaltext" style="width: 83%">
                                            <asp:DropDownList AutoPostBack="true" ID="ddltemplateType" CssClass="normalText"
                                                Width="175px" runat="server" OnSelectedIndexChanged="ddltemplateType_SelectedIndexChanged">
                                                <%--<asp:ListItem Value="1" Text="Html"></asp:ListItem>--%>
                                                <asp:ListItem Value="2" Text="Text"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label" style="width: 17%" nowrap="nowrap">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext" style="color: Black">&nbsp;<%=objLanguage.GetLanguageConversion("Select_Template")%></span>
                                        </td>
                                        <td class="Normaltext" style="width: 83%">
                                            <asp:DropDownList ID="ddlEmailTemp" CssClass="normalText" CausesValidation="false"
                                                Width="175px" runat="server" OnSelectedIndexChanged="ddltemplate_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td validgn="top" align="left" class="label" width="5%">
                                            &nbsp;<asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Message")%>
                                            </asp:Label>
                                        </td>
                                        <td align="left" width="95%">
                                            <input type="hidden" id="hdnEditorValue" runat="server" value="may i know" />
                                            <input type="hidden" id="hdnselectTemplate" runat="server" />
                                            <noscript>
                                                <p>
                                                    <b>Javascript must be enabled to use this form.</b>
                                                </p>
                                            </noscript>
                                            <div class="box" style="width: 75%; border: 0px solid red">
                                                <div id="divFckEditor" style="float: left; border: 0px solid;">
                                                    <%-- <FCKeditorV2:FCKeditor ID="areaEditor" runat="server">
                                                    </FCKeditorV2:FCKeditor>--%>
                                                    <telerik:RadEditor ID="RadareaEditor" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                        ImageManager-ViewMode="Grid" OnClientLoad="OnClientLoad" ExternalDialogsPath="~/RadEditorDialogs"
                                                        ContentFilters="MakeUrlsAbsolute" ContentAreaMode="Iframe">
                                                        <Content>
                                                                          
                                                        </Content>
                                                        <CssFiles>
                                                            <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                        </CssFiles>
                                                    </telerik:RadEditor>
                                                    <div class="only5px">
                                                    </div>
                                                    <style type="text/css">
                                                        .Default.RadEditor .reContentCell
                                                        {
                                                            border: 1px solid #DADADA;
                                                        }
                                                    </style>
                                                    <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                                        Max. length of textbox is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg"
                                                            style="display: none; width: 185px;">Please enter E-mail body</span>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td valign="top" align="left" class="label" width="5%">
                                            <%--class="newLabelText"
                                            &nbsp;<asp:Label ID="lblEmailFooter" runat="server" CssClass="normaltext">Select Footer Signature </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEmailFooter" Width="200px" CssClass="Normaltext" runat="server"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlEmailFooter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                    <tr valign="top" style="display: none">
                                        <td>
                                        </td>
                                        <td>
                                            <span class="normaltext">You can use tags to customize of your newsletters.<asp:LinkButton
                                                ID="lnkkk" OnClientClick="javascript:TagHelper(); return false;" runat="server">View tags helper</asp:LinkButton></span>
                                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="left">
                                <table cellspacing="2" cellpadding="5" width="100%" align="left" border="0">
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td align="left">
                                            <div id="div_btn2cancel" style="display: block">
                                                <asp:Button ID="btncancel" runat="server" CssClass="button" Width="65px" Text="Cancel"
                                                    OnClick="btncancel_Click" OnClientClick="javascript:loadingimg('div_btn2cancel','div_btn2cnclprocess');"
                                                    CausesValidation="False" AutoPostBack="true"></asp:Button>
                                            </div>
                                            <div id="div_btn2cnclprocess" class="button" align="center" style="width: 51px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="div_btnsend" style="display: block">
                                                <asp:Button ID="btnsend" runat="server" CssClass="button" OnClientClick="javascript:var a=checkvalidaetion();if(a)loadingimg('div_btnsend','div_btnsendprocess');return a;"
                                                    Width="65px" OnClick="btnsend_Click" Text="Send"></asp:Button><%--OnClick="btnsend_Click"--%>
                                            </div>
                                            <div id="div_btnsendprocess" class="button" align="center" style="width: 51px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td>
                                            <asp:DropDownList Width="200px" ID="ddlLeadMoreAction" runat="server" Style="display: none">
                                                <asp:ListItem Text="---------More Action-------" style="color: #a1a1a1" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Select Template" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Attach File" Value="2"></asp:ListItem>
                                                <%--<asp:ListItem Text="Preview" Value="3"></asp:ListItem>--%>
                                                <asp:ListItem Text="-------------------------" style="color: #a1a1a1" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Create new Tepmlate" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Add to new Template" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Add to existing Template" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="100%">
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hid_EmailTemplateValue" runat="server" Value="" />
                                <script>
                                    var areaEditor = document.getElementById("<%=RadareaEditor.ClientID %>");
                                    var hid_EmailTemplateValue = document.getElementById("<%=hid_EmailTemplateValue.ClientID %>");
                                    var ddlEmailTemp = document.getElementById("<%=ddlEmailTemp.ClientID %>");
                                    var txtfirstname = document.getElementById("<%=txtfirstname.ClientID %>");
                                    var txtcc = document.getElementById("<%=txtcc.ClientID %>");
                                    var txtbcc = document.getElementById("<%=txtbcc.ClientID %>");
                                    var txtsubject = document.getElementById("<%=txtsubject.ClientID %>");
                                    var txtattachment = document.getElementById("<%=txtattachment.ClientID %>");
                                    var hdn_GetAttached = document.getElementById("<%=hdn_GetAttached.ClientID %>");
                                    var hdn_Attach = document.getElementById("<%=hdn_Attach.ClientID %>");
                                    var Div_POAttachLink = document.getElementById("<%=Div_POAttachLink.ClientID %>");


                                    function getEmailTemplate(ddlVal) {
                                        var str = hid_EmailTemplateValue.value.split('µ');
                                        if (ddlVal == "0") {
                                            areaEditor.value = "";
                                        }
                                        else {
                                            for (var i = 0; i < str.length; i++) {
                                                var str2 = str[i].split('±');
                                                var phraseid = str2[0];
                                                var phrasetext = str2[1];
                                                if (phraseid == ddlVal) {

                                                    areaEditor.value = phrasetext;

                                                    var PDFPath1 = '<%=strSitePath %>pdf.aspx?key=<%=TemplateKey %>';
                                                    var EmailFooter = '<%=Session["firstName"].ToString() %> <%=Session["lastName"].ToString() %>';
                                                    alert(EmailFooter);
                                                    //                                                    var AttachmentsLink = '<%=Div_POAttachLink %>';
                                                    //                                                    alert(AttachmentsLink);
                                                    areaEditor.value = areaEditor.value.replace("[$PDFPath$]", PDFPath1);
                                                    alert(areaEditor.value);
                                                    areaEditor.value = areaEditor.value.replace("[$EmailFooter$]", EmailFooter);
                                                    alert(areaEditor.value);
                                                }
                                            }
                                        }
                                    }
                                </script>
                                <script>
                                    //                                    function Check_Attachment() {
                                    //                                        var Count = '<%=count %>';
                                    //                                        var hdn_Attach = document.getElementById("<%=hdn_Attach.ClientID %>");
                                    //                                        var Str_AttachPath = '<%=Str_AttachPath %>';
                                    //                                        var ChckAttach = '';
                                    //                                        if (Count > 0) {
                                    //                                            for (var i = 0; i < Count; i++) {
                                    //                                                ChckAttach = document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_UCEmail_Chk_Attach_" + i + "");
                                    //                                                if (ChckAttach.checked) {

                                    //                                                    hdn_Attach.value += Str_AttachPath + ChckAttach.nextSibling.innerHTML + "µ";
                                    //                                                }
                                    //                                            }
                                    //                                        }
                                    //                                        else {
                                    //                                        }

                                    //                                    }


                                    //                                    function Checked_Attach() {
                                    //                                        var Str_AttachPath = '<%=Str_AttachPath %>';

                                    //                                        var hdn_GetAttached = document.getElementById("<%=hdn_GetAttached.ClientID %>");
                                    //                                        var hdn_Attach = document.getElementById("<%=hdn_Attach.ClientID %>");
                                    //                                        var SpltdAttach = hdn_GetAttached.value.split('‡');
                                    //                                        var ChekAttach = '';
                                    //                                        for (var i = 0; i < SpltdAttach.length - 1; i++) {
                                    //                                            ChekAttach = document.getElementById("Chk_Attach_" + i + "");
                                    //                                            if (ChekAttach.checked = true) {
                                    //                                                hdn_Attach.value += ChekAttach.value + "µ";
                                    //                                            }
                                    //                                        }
                                    //                                    }


                                    var Isvalided = true;
                                    function checkvalidaetion() {

                                        var Isvalided = true;
                                        if (!validateMultipleEmailsCommaSeparated(txtfirstname.value, 'spn_To')) {
                                            Isvalided = false;
                                        }

                                        if (!validateMultipleEmailsCommaSeparated(txtcc.value, 'spn_cc')) {
                                            Isvalided = false;
                                        }

                                        if (!validateMultipleEmailsCommaSeparated(txtbcc.value, 'spn_bcc')) {
                                            Isvalided = false;
                                        }

                                        if (txtsubject.value == '') {
                                            document.getElementById("spn_subject").style.display = "block";
                                            Isvalided = false;
                                        }

                                        if (Isvalided) {
                                            debugger;
                                            Checked_SuplierAttach();
                                            parent.document.getElementById("ds00").style.height = window.screen.availHeight + (window.screen.availHeight / 2) + "px";
                                            parent.document.getElementById("div_Load").style.display = "block";
                                            parent.document.getElementById("ds00").style.display = "block";
                                            return true;
                                        }
                                        else {
                                            return false;
                                        }
                                    }

                                </script>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="37%">
                                        </td>
                                        <td nowrap="nowrap">
                                            <div id="divAddNew" style="display: none">
                                                <asp:Label ID="lblAddNew" CssClass="Normaltext" runat="server" Text="Template Name"></asp:Label>
                                                <asp:TextBox ID="txtAddNew" CssClass="txtbox" Width="200px" runat="server"></asp:TextBox>&nbsp;
                                                <asp:Button ID="btnAddtext" CausesValidation="false" OnClick="btnAdd_Click" OnClientClick="javascript:return ValidateAddButton();"
                                                    CssClass="button" runat="server" Width="40px" Text="Add" /><%--onMouseOver="this.className='Button-Focus'" onMouseOut="this.className='Button'"--%>
                                            </div>
                                            <div id="divAddExisting" style="display: none">
                                                <asp:Label ID="Label5" CssClass="Normaltext" runat="server" Text="Template Name"></asp:Label>
                                                <asp:DropDownList ID="ddlAddExisting" Width="200px" CssClass="Normaltext" runat="server">
                                                </asp:DropDownList>
                                                &nbsp;
                                                <asp:Button ID="btnAddddl" CausesValidation="false" CssClass="button" OnClientClick="javascript:return ValidateAddButton();"
                                                    OnClick="btnAdd_Click" runat="server" Width="40px" Text="Add" /><%--onMouseOver="this.className='Button-Focus'" onMouseOut="this.className='Button'"--%>
                                            </div>
                                            <asp:Label ID="lblError" CssClass="error" runat="server" Visible="false"></asp:Label>
                                            <div id="divTemplateselect" style="display: none">
                                                <asp:Label ID="Label6" CssClass="Normaltext" runat="server" Text="Select Template"></asp:Label>
                                                <asp:DropDownList ID="ddlselecttemplate" OnSelectedIndexChanged="ddlselecttemplate_SelectedIndexChanged"
                                                    Width="200px" AutoPostBack="true" CssClass="Normaltext" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td width="20%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="30px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                <input type="hidden" id="hidleadid" runat="server" />
                                <input type="hidden" id="hidcontactid" runat="server" />
                                <input type="hidden" id="hidmixleadid" runat="server" />
                                <input type="hidden" id="hidmixcontactid" runat="server" />
                                <input type="hidden" id="hidleadidemail" runat="server" />
                                <input type="hidden" id="hidcontactidemail" runat="server" />
                                <input type="hidden" id="hidmixleadidemail" runat="server" />
                                <input type="hidden" id="hidmixcontactidemail" runat="server" />
                                <asp:HiddenField ID="hid_FileNames" runat="server" Value="" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_EmailFromOthers" runat="server" style="width: 100%; display: none">
                    <div align="left" class="normlaText" style="width: 100%; display: none">
                        <span>Your download will start automatically if it does not start,
                            <asp:LinkButton ID="lnkDownloadPDF" runat="server" OnClick="lnkDownloadPDF_OnClick"
                                Style="text-decoration: underline" OnClientClick="javascript:OpenEmailClient();">Click here to download</asp:LinkButton>
                            and to open local email client. </span>
                        <%--Click here
                            to download PDF, so that you can manually attach your local email client.--%>
                    </div>
                    <%--  <div class="only10px">
                    </div>--%>
                    <div align="left" class="normlaText" style="width: 100%; display: none">
                        <span><a id="lnkOpenClientEmail" onclick="javascript:OpenEmailClient();" style="text-decoration: underline"
                            href="#">
                            <%--href="mailto:<%=ContactEmail %>?cc=<%=Session["email"].ToString() %>&subject=<%=EstimateTitle %>&body=<%=DefaultEmailBody %>"--%>
                            Click here</a> to open local email client and email. </span>
                    </div>
                </div>
                <asp:HiddenField ID="hid_EmailSettingType" runat="server" Value="" />
            </td>
        </tr>
    </table>
    <style type="text/css">
        body
        {
            font-family: arial,sans-serif;
            font-size: 9pt;
        }
        
        .my_clip_button
        {
            width: 150px;
            text-align: center;
            border: 1px solid black;
            background-color: #ccc;
            margin: 10px;
            padding: 10px;
            cursor: default;
            font-size: 9pt;
        }
        
        .my_clip_button.hover
        {
            background-color: #eee;
        }
        
        .my_clip_button.active
        {
            background-color: #aaa;
        }
    </style>
    <script type="text/javascript" src="../usercontrol/ZeroClipboard.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <script language="JavaScript">
        var clip = null;

        //function $(id) { return document.getElementById(id); }

        function init() {
            clip = new ZeroClipboard.Client();
            clip.setHandCursor(true);

            clip.addEventListener('load', function (client) {
                debugstr("Flash movie loaded and ready.");
            });

            clip.addEventListener('complete', function (client, text) {
                debugstr("Copied text to clipboard: " + text);
            });

            clip.addEventListener('mouseOver', function (client) {
                clip.setText(document.getElementById('div_EmailBodyContent').innerHTML);
            });

            // glue specifying our button AND its container
            clip.glue('d_clip_button', 'd_clip_container');
        }

        function debugstr(msg) {
            var p = document.createElement('p');
            p.innerHTML = msg;
            document.getElementById('d_debug').appendChild(p);
        }

    </script>
    <div id="div_EmailBody" style="display: none">
        <span class="smallgrayText">(Note: Copy and paste the Email body displayed below to
            your local email client [Outlook, Lotus...] )</span><a href="#" onclick="fnSelect('div_EmailBodyContent');">
                Select All</a>
        <div id="div_EmailBodyContent" class="normalText">
        </div>
        <div id="Div_POAttachLink" runat="server" style="border: 1px solid green;">
        </div>
        <%--PLs donot delete the below commented code--%>
        <%--<div id="d_clip_container" style="position: relative">
            <div id="d_clip_button" class="my_clip_button">
                <b>Copy To Clipboard...</b></div>
        </div>
        <div id="d_debug" style="border: 1px solid #aaa; padding: 10px; font-size: 9pt;">
            <h3>
                Debug Console:</h3>
        </div>
        <br />
        <br />
        You can paste text here if you want, to make sure it worked:<br />
        <textarea id="testarea" cols="50" rows="10"></textarea><br />
        <input type="button" value="Clear Test Area" onclick="$('testarea').value = '';" />--%>
    </div>
    <div id="divrad" style="display: none; position: absolute; vertical-align: middle;
        border: 0px solid; z-index: 100; width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
            OnClientClose="RadWinClose" Behaviors="Close, Move, Reload, Resize" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
    <%--<div id="Div_Attachment" style="position: absolute; vertical-align: middle; z-index: 100;"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
            Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
            Behaviors="Close" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>--%>
    <asp:HiddenField ID="hdnEmailBody" runat="server" Value="" />
    <asp:HiddenField ID="hid_subject" runat="server" Value="" />
    <asp:HiddenField ID="hid_body" runat="server" Value="" />
    <asp:HiddenField ID="statusidonsend" runat="server" Value="" />
    <asp:HiddenField ID="statustitleonsend" runat="server" Value="" />
    <asp:HiddenField ID="hid_TemplateKey" runat="server" Value="" />
    <asp:HiddenField ID="hdn_EmailFooter" runat="server" Value="" />
    <asp:HiddenField ID="hdn_EmailbodyAttach" runat="server" Value="" />
    <asp:HiddenField ID="hdn_areaEditor" runat="server" Value="" />
    <script>
        var div_EmailBody = document.getElementById("div_EmailBody");
        var div_EmailBodyContent = document.getElementById("div_EmailBodyContent");
        div_EmailBody.style.display = "none";
        var SysName = '<%=SysName %>';

        function OpenEmailClient() {
            var to = document.getElementById("<%=txtfirstname.ClientID %>").value;
            var cc = ""; //'<%=Session["email"].ToString() %>';
            var bcc = document.getElementById("<%=txtbcc.ClientID %>").value;
            var subject = document.getElementById("<%=hid_subject.ClientID %>").value.replace("&", "and");
            var body = document.getElementById("<%=hid_body.ClientID %>").value;
            //body = body.replace("\r\n","<br>");
            //body = body.replace("<br>","%0A%0A");            

            var FinalOccyStr = '';
            FinalOccyStr = body;
            for (var k = 0; k < 10; k++) {
                FinalOccyStr = FinalOccyStr.replace("<br>", "%0A");
                FinalOccyStr = FinalOccyStr.replace("<br />", "%0A");
                FinalOccyStr = FinalOccyStr.replace("<p>", "");
                FinalOccyStr = FinalOccyStr.replace("</p>", "%0A%0A");
            }

            body = body;

            var lnkMail = '';
            if (cc != "" && bcc != "") {
                lnkMail = "mailto:" + to + "?cc=" + cc + "&bcc=" + bcc + "&subject=" + subject + "";
            }
            else if (cc = "" && bcc != "") {
                lnkMail = "mailto:" + to + "?bcc=" + bcc + "&subject=" + subject + "";
            }
            else if (bcc = "" && cc != "") {
                lnkMail = "mailto:" + to + "?cc=" + cc + "&subject=" + subject + "";
            }
            else {
                lnkMail = "mailto:" + to + "?subject=" + subject + "";
            }

            if (SysName == "occy") {
                location.href = lnkMail + "&body=" + strip(FinalOccyStr) + "";
                div_EmailBody.style.display = "none";
            }
            else {
                location.href = lnkMail; //&body=" + escape(body) + "
                //var mailto_link = 'mailto:' + to + '?cc=' + cc + '&subject=' + subject + '&body=' + escape(body) + '';
                //win = window.open(mailto_link, 'emailWindow');
                div_EmailBody.style.display = "block";
            }

            div_EmailBodyContent.innerHTML = document.getElementById("<%=RadareaEditor.ClientID %>").value;
        }

        //funcn to strip HTML tags
        function strip(html) {
            var tmp = document.createElement("DIV");
            tmp.innerHTML = html;
            return tmp.textContent || tmp.innerText;
        }

    </script>
    <script type="text/javascript">
        function fnSelect(objId) {
            fnDeSelect();
            if (document.selection) {
                var range = document.body.createTextRange();
                range.moveToElementText(document.getElementById(objId));
                range.select();
            }
            else if (window.getSelection) {
                var range = document.createRange();
                range.selectNode(document.getElementById(objId));
                window.getSelection().addRange(range);
            }
        }
        function fnDeSelect() {
            if (document.selection)
                document.selection.empty();
            else if (window.getSelection)
                window.getSelection().removeAllRanges();
        }
    </script>
    <asp:Panel ID="pnl_ShowEmailType" runat="server" Visible="false">
        <script>
            function ShowOnEmailType() {

                var EstimateNumber = '<%=EstimateNumber %>';
                var hid_EmailSettingType = document.getElementById("<%=hid_EmailSettingType.ClientID %>");
                var txtattachment = document.getElementById("<%=txtattachment.ClientID %>");
                var hid_TemplateKey = document.getElementById("<%=hid_TemplateKey.ClientID %>");

                document.getElementById("<%=div_EmailFromEprint.ClientID %>").style.display = "none";
                document.getElementById("<%=div_EmailFromOthers.ClientID %>").style.display = "none";
                if (hid_EmailSettingType.value == "o") {

                    document.getElementById("<%=div_EmailFromOthers.ClientID %>").style.display = "block";
                    window.parent.document.getElementById("ds00").style.display = "none";
                    window.parent.document.getElementById("div_Load").style.display = "none";
                    OpenEmailClient();
                    //init();  //****Pls donot delete ths needed for CopyToClipboard option
                    // __doPostBack('ctl00$ContentPlaceHolder1$UCtemplate1$UCEmail$lnkDownloadPDF', '');
                    PageMethods.SaveEmailedTemplate(txtattachment.value, hid_TemplateKey.value, GetKeyOnInsert);

                }
                else {
                    document.getElementById("<%=div_EmailFromEprint.ClientID %>").style.display = "block";
                    press_select.GetEditedTemplateName(hid_TemplateKey.value, BindTempName_OnEdit);
                }
            }
            ShowOnEmailType(); //==Called in usrcntl>templates_view page

            function GetKeyOnInsert(result) {
                //alert(result);
            }
            function BindTempName_OnEdit(result) {
                //alert(result);
                // txtattachment.value = result;
                txtattachment.value = EstimateNumber + result;
            }
        </script>
    </asp:Panel>
    <script language="JavaScript" type="text/javascript">
        //alert(document.getElementById("<%=hid_FileNames.ClientID %>").value);
        function TagHelper() {
            //window.open('../common/tag_helper.aspx?sectionname=<%=sectionname%>', 'Lead','width=615,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
            //PopupCenter("<%=nmsCommon.global.sitePath()%>common/tag_helper.aspx?sectionname=<%=sectionname%>", '615', '610');
            window.radopen("<%=nmsCommon.global.sitePath()%>common/tag_helper.aspx?sectionname=<%=sectionname%>", '', '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        function OpenPopUp() {
            var lblError = document.getElementById("ctl00_ContentPlaceHolder1_lblError");
            var divAddNew = document.getElementById("divAddNew");
            var divAddExisting = document.getElementById("divAddExisting");
            var ddlLeadMoreAction = document.getElementById("<%=ddlLeadMoreAction.ClientID %>");
            var divTemplateselect = document.getElementById("divTemplateselect");

            if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "1") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }
                divAddNew.style.display = "none";
                divAddExisting.style.display = "none";
                divTemplateselect.style.display = "block";
            }
            if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "2") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }

                divAddNew.style.display = "none";
                divAddExisting.style.display = "none";
                divTemplateselect.style.display = "none";
                //window.open('../common/attachfile.aspx?pg=<%=sectionname%>', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
                //PopupCenter("<%=nmsCommon.global.sitePath()%>common/attachfile.aspx?pg=<%=sectionname%>", '730', '400')
                window.radopen("<%=nmsCommon.global.sitePath()%>common/attachfile.aspx?pg=<%=sectionname%>", '730', '400');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                //displayCommon('divAttachMent');
            }
            else if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "3") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }

                divAddNew.style.display = "none";
                divAddExisting.style.display = "none";
                divTemplateselect.style.display = "none";
                var ddltemplateType = document.getElementById("ctl00_ContentPlaceHolder1_ddltemplateType");
                var hdnEditorValue = document.getElementById("ctl00_ContentPlaceHolder1_hdnEditorValue");
                var areaEditor = document.getElementById("ctl00_ContentPlaceHolder1_RadareaEditor").value;

                //hdnEditorValue.value=document.getElementById('areaEditor').value;
                var str = document.getElementById("ctl00_ContentPlaceHolder1_areaEditor").value;
                //alert(hdnEditorValue.value);
                //window.open('../common/email_preview.aspx', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');

            }
            else if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "5") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }

                divAddNew.style.display = "none";
                divAddExisting.style.display = "none";
                divTemplateselect.style.display = "none";
                //window.open('../common/Create_template.aspx?pg=<%=sectionname%>', 'Lead','width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
                // PopupCenter("<%=nmsCommon.global.sitePath()%>common/Create_template.aspx?pg=<%=sectionname%>", '730', '400')
                window.radopen("<%=nmsCommon.global.sitePath()%>common/Create_template.aspx?pg=<%=sectionname%>", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "6") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }

                divAddNew.style.display = "block";
                divAddExisting.style.display = "none";
                divTemplateselect.style.display = "none";
            }
            else if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "7") {
                try {
                    lblError.innerHTML = '';
                }
                catch (error) {
                }

                divAddNew.style.display = "none";
                divAddExisting.style.display = "block";
                divTemplateselect.style.display = "none";

            }
}
function ValidateAddButton() {
    var ddlLeadMoreAction = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
    var txtAddNew = document.getElementById("ctl00_ContentPlaceHolder1_txtAddNew");
    var ddlAddExisting = document.getElementById("ctl00_ContentPlaceHolder1_ddlAddExisting");
    var newReturnValue;
    if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "6") {
        if (txtAddNew.value != '') {
            newReturnValue = true;
        }
        else {
            alert("Please enter Template Name");
            newReturnValue = false;
        }
    }
    else if (ddlLeadMoreAction.options[ddlLeadMoreAction.selectedIndex].value == "7") {

        if (ddlAddExisting.options[ddlAddExisting.selectedIndex].value != "0") {
            newReturnValue = true;
        }
        else {
            alert("Please select Template Name");
            newReturnValue = false;
        }
    }
    if (newReturnValue) {
        return true;
    }
    else {
        return false;
    }

}
function RadWinClose() {
    document.getElementById("divrad").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
}
    </script>
    <script>
        function BindContact_EmailIDS(to, cc, bcc) {
            //alert(bcc);
            txtfirstname.value = to;
            txtcc.value = cc;
            txtbcc.value = bcc;
        }
    </script>
    <script>
        //by natraj, Attachments...
        function Call_Attachment() {
            //          
            //            var hdn_areaEditor = document.getElementById("<%=Div_POAttachLink.ClientID %>");
            //            hdn_areaEditor.value = areaEditor.value;
            //            alert(hdn_areaEditor.value);
            //            alert(areaEditor.value);            

            var PageType = '<%=sectionname %>';
            var EstimateID = "<%=EstimateID %>";
            var jobID = '<%=jobID %>';
            var InvoiceID = '<%=InvoiceID %>';
            var Section = 'CustmTemp';
            var pagetype = 'emailtemplate';
            if (PageType == "Purchase") {
                var RadPath_PO = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&purchaseID=" + EstimateID + "&estid=" + EstimateID + "&pg=" + PageType + "&Section=" + Section + "";
                window.parent.openAttpopup(RadPath_PO);
            }
            else if (PageType == "DeliveryNote") {
                var Radpath_Del = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&DeliveryID=" + EstimateID + "&estid=" + EstimateID + "&pg=" + PageType + "&Section=" + Section + "";
                window.parent.openAttpopup(Radpath_Del);
            }
            else if ((PageType != "Purchase") && (PageType != "DeliveryNote")) {
                var RadPath = '';
                if (PageType.toLowerCase() == "invoice") {
                    var RadPath = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&estid=" + InvoiceID + "&pg=" + PageType + "&Section=" + Section + "";
                }
                else if (PageType.toLowerCase() == "job") {
                    var RadPath = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&estid=" + jobID + "&pg=" + PageType + "&Section=" + Section + "";
                }
                else {
                    var RadPath = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&estid=" + EstimateID + "&pg=" + PageType + "&Section=" + Section + "";
                }
            window.parent.openAttpopup(RadPath);
        }
}

    </script>
    <script>
        function BindAttachments(AttachedAcutalFileName, AttchedOriginalFileName) {
            var hdn_GetAttached = document.getElementById("<%=hdn_GetAttached.ClientID %>");
            if (hdn_GetAttached.value != AttachedAcutalFileName) {
                hdn_GetAttached.value += AttachedAcutalFileName;
            }
            else {
                hdn_GetAttached.value = AttachedAcutalFileName;
            }
            var StrChckbox = '';
            var Div_Attach = document.getElementById("<%=Div_Attach.ClientID %>");
            var StrAttachAcutalFileName = AttachedAcutalFileName.split('‡');
            var StrAttachOriginalFileName = AttchedOriginalFileName.split('‡');
            for (var i = 0; i < StrAttachAcutalFileName.length - 1; i++) {
                var AttachAcutalFileName = StrAttachAcutalFileName[i];
                var AttachOriginalFileName = StrAttachOriginalFileName[i];
                StrChckbox += "<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>";
                StrChckbox += "<input type='checkbox'  id='Chk_Attach_" + i + "' value='" + AttachAcutalFileName + "' title='" + AttachOriginalFileName + "' checked='checked' style='float:left; display:block;'/>" + AttachOriginalFileName + "";
                StrChckbox += "</div>";
            }
            Div_Attach.innerHTML += StrChckbox;
        }

        function BindAttachmentsForActual(AttchedOriginalFileName, AttachedAcutalFileName) {
            var hdn_GetAttached = document.getElementById("<%=hdn_GetAttached.ClientID %>");
            if (hdn_GetAttached.value != AttachedAcutalFileName) {
                hdn_GetAttached.value += AttachedAcutalFileName;
                hdn_Attach.value += AttchedOriginalFileName;
            }
            else {
                hdn_GetAttached.value = AttachedAcutalFileName;
                hdn_Attach.value += AttchedOriginalFileName;
            }
            var StrChckbox = '';
            var Div_Attach = document.getElementById("<%=Div_Attach.ClientID %>");
            var StrAttach = AttchedOriginalFileName.split('‡');
            var StrActual = AttachedAcutalFileName.split('‡');
            for (var i = 0; i < StrAttach.length - 1; i++) {
                var AttachOriginalFileName = StrAttach[i];
                var AttachAcutalFileName = StrActual[i];
                StrChckbox += "<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>";
                StrChckbox += "<input type='checkbox'  id='Chk_Attach_" + i + "' value='" + AttachAcutalFileName + "' title='" + AttachOriginalFileName + "' checked='checked' style='float:left; display:block;'/>" + AttachOriginalFileName + "";
                StrChckbox += "</div>";
            }
            Div_Attach.innerHTML += StrChckbox;
        }
    </script>
    <script>

        function BindAttachment_Link(CheckedLink, ActualFiles) {
            var StrChckbox = '';
            var Div_POAttachLink = document.getElementById("<%=Div_POAttachLink.ClientID %>");
            var Str_AttachPath = '<%=Str_AttachPath %>';
            var strSitePath = '<%=StrDownload %>';
            var StrAttach = CheckedLink.split('‡');
            var StrActual = ActualFiles.split('‡');
            for (var i = 0; i < StrAttach.length - 1; i++) {
                var AttachFileName = StrAttach[i];
                var ActualFileName = StrActual[i];
                StrChckbox += "<div align='left' style='float:left; cursor:default; border:0px solid red; clear: both; width:500px;'>";
                StrChckbox += "<a href='" + '<%=StrDownload %>' + ActualFileName + "' target='_blank'>" + AttachFileName + "</a>";
                StrChckbox += "</div>";
            }

            var Editor = $find("<%= RadareaEditor.ClientID %>");
            Editor.set_html(Editor.get_html() + "<br />" + StrChckbox);

        }

    </script>
    <asp:Panel ID="pnl_attachment" runat="server" Visible="false">
        <script>
            BindAttachments(hdn_GetAttached.value, hdn_Attach.value);
        </script>
    </asp:Panel>
    <script>
        var imgID = '';
        function CallTopopup(obj) {
            imgID = obj.id;
            var PathTo = "../Common/email_Contact.aspx?sectionid=<%=sectionid %>&sectionname=<%=sectionname %>";
            window.parent.openAttpopup(PathTo);
        }

        function forRedirect(RedirectPath) {
            window.parent.location = RedirectPath;
        }

        function RedirectwithErrorMsg(RedirectPath) {
            alert('Attachment could not be created. Kindly go back and retry the process again..');
            window.parent.location = RedirectPath;
        }
    </script>
</div>

