<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="email_printbroker.ascx.cs" Inherits="ePrint.usercontrol.email_printbroker" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="../js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<asp:Panel ID="pnlScriptEditor" Visible="true" runat="server">
    <div id="editor">
    </div>
</asp:Panel>
<style type="text/css">
    .Default.RadEditor .reContentCell
    {
        border: 1px solid #DADADA;
    }
</style>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadareaEditor" />
                <telerik:AjaxUpdatedControl ControlID="ddlEmailTemp" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<div align="left" id="div_EmailFromEprint" runat="server" style="width: 100%; display: none">
    <table align="left" cellpadding="0" cellspacing="0" border="0" width="100%">
        <%--class="borderWithoutTop"--%>
        <tr>
            <td>
                <table cellspacing="2" cellpadding="2" width="100%" align="left" border="0">
                    <tr>
                        <td valign="top" align="left" width="5%" class="label">
                            &nbsp;<asp:Label ID="Label8" runat="server" Height="3px" CssClass="normaltext">Send Email</asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkEmail" runat="server" Checked="true" />
                            <asp:Label ID="lblSupplierName" runat="server" CssClass="HeaderText" Style="padding-bottom: 8px"></asp:Label>
                            <asp:Label ID="lblSupplierID" runat="server" CssClass="HeaderText" Style="display: none"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="5%" class="label">
                            <div style="border: 0px solid red;">
                                <div style="float: left;" class="normalText">
                                    &nbsp;<asp:Label ID="lblassigned" runat="server" CssClass="normaltext">To</asp:Label>
                                </div>
                                <div style="float: right;" class="normalText">
                                    &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer; padding: 5 0 5 0px"
                                        ID="imgselectleadmain" runat="server" Visible="true" onclick="javascript:CallPopup(this);" />
                                    <script>
                                        var imgID = '';
                                        function CallPopup(obj) {
                                            imgID = obj.id;
                                            var supid = imgID.replace("imgselectleadmain", "lblSupplierID");
                                            supid = document.getElementById(supid);
                                            var suplrid = supid.innerHTML;
                                            //var path = '<%=openwindow %>';
                                            path = "../Common/email_Contact.aspx?sectionid=" + suplrid + "&sectionname=<%=sectionname %>";
                                            window.parent.openAttpopup(path);
                                            //PopupCenter(path, '800', '400');
                                            // window.radopen(path, '800', '400');
                                            //SetRadWindow('divrad', 'divBackGroundNew', '200');
                                            return false;
                                        }
                                    </script>
                                </div>
                            </div>
                        </td>
                        <td class="normaltext" align="left" width="95%">
                            <div align="left" style="width: 100%">
                                <div style="float: left" class="normalText">
                                    <textarea class="txtbox" rows="2" cols="55" name="txtfirstname" id="txtfirstname"
                                        runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this,this.value,'spn_To',true)"></textarea><br />
                                    [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                    (,)]&nbsp;
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                &nbsp;<span id="spn_To" runat="server" class="spanerrorMsg" style="width: 185px;
                                    display: none">Please enter valid email</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="label" valign="top" align="left" width="5%">
                            <span class="normaltext">&nbsp;<%=objLanguage.convert("CC")%></span>
                        </td>
                        <td class="normaltext" align="left" width="95%">
                            <div style="border: solid 0px red; width: 100%">
                                <div align="left">
                                    <textarea name="txtcc" rows="2" cols="55" id="txtcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this,this.value,'spn_cc',true)"></textarea>
                                    &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadcc"
                                        runat="server" Visible="false" /><br />
                                    [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                    (,)]&nbsp;<span id="spn_cc" runat="server" class="spanerrorMsg" style="width: 185px;
                                        display: none">Please enter valid email</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="5%" class="label">
                            &nbsp;<asp:Label ID="Label2" runat="server" Width="75px" CssClass="normaltext">BCC</asp:Label>
                        </td>
                        <td class="normaltext" align="left" width="95%">
                            <div style="border: solid 0px red; width: 100%">
                                <div align="left">
                                    <textarea name="txtbcc" rows="2" cols="55" id="txtbcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this,this.value,'spn_bcc',true)"></textarea>
                                    &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadbcc"
                                        runat="server" Visible="false" /><br />
                                    [<%=objLanguage.convert("To send more please separate the email addresses by comma")%>
                                    (,)]&nbsp;<span id="spn_bcc" runat="server" class="spanerrorMsg" style="width: 185px;
                                        display: none">Please enter valid email</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="5%" class="label">
                            &nbsp;<asp:Label ID="Label3" runat="server" Width="75px" CssClass="normaltext">Subject</asp:Label>
                        </td>
                        <td align="left" width="95%" class="normaltext">
                            <input class="txtbox" style="height: 30px" type="text" maxlength="200" size="75"
                                name="txtsubject" id="txtsubject" onblur="javascript:validatesubject(this);"
                                runat="server">
                            <div class="error_top">
                                <span id="spn_subject" runat="server" class="spanerrorMsg" style="width: 155px; display: none">
                                    Please enter subject</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="5%" class="label">
                            &nbsp;<asp:Label ID="Label4" runat="server" Width="75px" CssClass="normaltext">Attachment</asp:Label>
                            <div style="float: right; cursor: pointer;">
                                <asp:Image ID="Image_Attachment" runat="server" Visible="true" ImageUrl="~/images/plus.gif"
                                    onclick="Javascript:Call_Attachment(this);" ToolTip="Select attachment" />
                                <asp:Label ID="lbl_SupplierAttach" runat="server" Style="display: none;"></asp:Label>
                            </div>
                        </td>
                        <td align="left" width="95%" class="normaltext">
                            <input class="txtbox" style="height: 18px; border: 1px solid white; padding-bottom: -10px;"
                                readonly="readonly" type="text" size="75" name="txtattachment" id="txtattachment"
                                runat="server"><%--<asp:LinkButton ID="LinkButton1"
                                                runat="server" CausesValidation="false">Attach File</asp:LinkButton>--%>
                            <a id="LinkButton1" runat="server" style="cursor: pointer; display: none">Attach File</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="border: 0px solid green; padding-top: -10px;">
                            <div id="Div_Attach" runat="server" style="border: 0px solid green; width=500px;">
                            </div>
                            <asp:HiddenField ID="hdn_SuplrAttach" runat="server" Value="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <div style="padding: -10px 0px 5px 0px; border: 0px solid green;">
                                <asp:UpdatePanel ID="Uppnl_Attach" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div>
                                            <asp:PlaceHolder ID="plh_Attach" runat="server"></asp:PlaceHolder>
                                            <asp:HiddenField ID="hdn_Attach" runat="server" Value="" />
                                            <asp:HiddenField ID="hdn_TotalAttach" runat="server" Value="" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:LinkButton ID="lnk_AttachUpdate" runat="server" Style="display: none;" Text=""></asp:LinkButton>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="label" style="width: 17%" nowrap="nowrap">
                            <span class="normaltext">&nbsp;<%=objLanguage.convert("Email type")%></span>
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
                            <span class="normaltext">&nbsp;<%=objLanguage.convert("Select Template")%></span>
                        </td>
                        <td class="Normaltext" style="width: 83%">
                            <asp:DropDownList ID="ddlEmailTemp" CssClass="normalText" Width="175px" runat="server"
                                OnSelectedIndexChanged="ddltemplate_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <span id="spn_CurrentSupplierNo" runat="server" style="display: none"></span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" class="label" width="5%">
                            &nbsp;<asp:Label ID="Label1" runat="server" Height="3px" CssClass="normaltext">Message</asp:Label>
                        </td>
                        <td align="left" width="95%">
                            <input type="hidden" id="hdnEditorValue" runat="server" value="may i know" />
                            <input type="hidden" id="hdnselectTemplate" runat="server" />
                            <noscript>
                                <p>
                                    <b>Javascript must be enabled to use this form.</b></p>
                            </noscript>
                            <div class="box" style="width: 75%; border: 0px solid red">
                                <div id="divFckEditor" style="float: left; border: 0px solid;">
                                    <%--<FCKeditorV2:FCKeditor ID="areaEditor" runat="server">
                                    </FCKeditorV2:FCKeditor>--%>
                                    <telerik:RadEditor ID="RadareaEditor" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                        ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute" OnClientLoad="OnClientLoad"
                                        ContentAreaMode="Iframe">
                                        <Content>
                                                                          
                                        </Content>
                                        <CssFiles>
                                            <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                        </CssFiles>
                                    </telerik:RadEditor>
                                    <div class="only5px">
                                    </div>
                                    <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                        Max. length of textbox is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg"
                                            style="display: none; width: 185px;">Please enter E-mail body</span>
                                </div>
                            </div>
                            <div id="Div_SuplrAttachLink" runat="server" style="border: 0px solid green; display: none;">
                            </div>
                            <%--<asp:TextBox TextMode="MultiLine" ID="areaEditor" Columns="70" Height="230px" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td valign="top" align="left" class="label" width="5%">
                            <%--class="newLabelText"
                            &nbsp;<asp:Label ID="lblEmailFooter" runat="server" Width="175px" CssClass="normaltext">Select Footer Signature </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEmailFooter" Width="175px" AutoPostBack="true" CssClass="Normaltext"
                                OnSelectedIndexChanged="ddlEmailFooter_SelectedIndexChanged" runat="server">
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
                    <%-- <tr>
                        <td valign="top" align="left" class="label" width="5%">
                            &nbsp;<asp:Label ID="Label7" runat="server" Height="3px" CssClass="normaltext">Send Email</asp:Label></td>
                        <td>
                            <asp:CheckBox ID="chkEmail" runat="server" Checked="true" /></td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr valign="top">
            <td align="left">
                <table cellspacing="2" cellpadding="5" width="100%" align="left" border="0">
                    <tr>
                        <td width="20%">
                        </td>
                        <td align="left" style="display: none">
                            <asp:Button ID="btncancel" runat="server" CssClass="button" Width="65px" Text="Cancel"
                                OnClick="btncancel_Click" CausesValidation="False"></asp:Button>
                        </td>
                        <td align="left" style="display: none">
                            <asp:Button ID="btnsend" runat="server" CssClass="button" OnClientClick="javascript:return checkvalidaetion();"
                                OnClick="btnsend_Click" Width="65px" Text="Send"></asp:Button>
                        </td>
                        <td>
                            <asp:DropDownList Width="200px" ID="ddlLeadMoreAction" runat="server" Style="display: none">
                                <asp:ListItem Text="---------More Action-------" style="color: #a1a1a1;" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Select Template" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Attach File" Value="2"></asp:ListItem>
                                <%--<asp:ListItem Text="Preview" Value="3"></asp:ListItem>--%>
                                <asp:ListItem Text="-------------------------" style="color: #a1a1a1;" Value="4"></asp:ListItem>
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
                    var chkEmail = document.getElementById("<%=chkEmail.ClientID %>");
                    var spn_To = document.getElementById('<%=spn_To.ClientID %>');
                    var spn_CC = document.getElementById('<%=spn_cc.ClientID %>');
                    var spn_BCC = document.getElementById('<%=spn_bcc.ClientID %>');
                    var spn_subject = document.getElementById('<%=spn_subject.ClientID %>');
                    var SupplierCount = '<%=SupplierCount %>';
                    var hdn_SuplrAttach = document.getElementById('<%=hdn_SuplrAttach.ClientID %>');

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
            </td>
        </tr>
    </table>
    <div class="onlyEmpty">
    </div>
</div>
<div id="div_EmailFromOthers" runat="server" style="width: 100%; display: none">
    <div align="left" class="normlaText" style="width: 100%; display: none">
        <span>Your download will start automatically if it does not start,
            <asp:LinkButton ID="lnkDownloadPDF" runat="server" OnClick="lnkDownloadPDF_OnClick"
                Style="text-decoration: underline" OnClientClick="javascript:OpenEmailClient();">Click here to download</asp:LinkButton>
            and to open local email client. </span>
        <%--Click here to download PDF, so that you can manually attach your local email client.--%>
    </div>
    <%--  <div class="only10px">
            </div>--%>
    <div align="left" class="normlaText" style="width: 100%; display: none">
        <span><a id="lnkOpenClientEmail" name="lnkOpenClientEmail" onclick="javascript:OpenEmailClient();"
            style="text-decoration: underline" href="#">
            <%--href="mailto:<%=ContactEmail %>?cc=<%=Session["email"].ToString() %>&subject=<%=EstimateTitle %>&body=<%=DefaultEmailBody %>"--%>
            Click here</a> to open local email client and email. </span>
    </div>
</div>
<div class="onlyEmpty">
</div>
<div id="div_EmailBody_PrintBroker" style="display: none;">
    <span class="smallgrayText">(Note: Copy and paste the Email body displayed below to
        your local email client [Outlook, Lotus...] )</span><a href="#" onclick="fnSelect('div_EmailBodyContent');">
            Select All</a>
    <br />
    <div id="div_EmailBodyContent" class="normalText">
    </div>
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="divrad" style="display: none; position: absolute; vertical-align: middle;
    border: 0px solid; z-index: 100; width: 50%" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
        OnClientClose="RadWinClose" Behaviors="Close, Move, Reload, Resize">
    </telerik:RadWindowManager>
</div>
<%--<div id="Div_Attachment" style="position: absolute; vertical-align: middle; z-index: 100;"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
        Behaviors="Close" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>--%>
<asp:HiddenField ID="hid_EstimateNumber" runat="server" Value="" />
<asp:HiddenField ID="hid_FileNames" runat="server" Value="" />
<asp:HiddenField ID="hid_EmailSettingType" runat="server" Value="" />
<asp:HiddenField ID="hid_subject" runat="server" Value="" />
<asp:HiddenField ID="hid_body" runat="server" Value="" />
<asp:HiddenField ID="hid_TemplateKey" runat="server" Value="" />
<asp:HiddenField ID="hid_EmailSupCount" runat="server" Value="1" />
<asp:HiddenField ID="hdnEmailAttachment_ActualName" runat="server" Value="" />
<asp:HiddenField ID="hdnEmailAttachment_OriginalName" runat="server" Value="" />
<asp:HiddenField ID="hdnSupEmailBody" runat="server" Value="" />
<asp:HiddenField ID="hdn_SupEmailFooter" runat="server" Value="" />
<script src="../js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script>
    function getEmailTemplate(ddl) {
        var ddlVal = ddl.value;
        var areaEditor = ddl.id;
        var spn_CurrentSupplierNo = ddl.id;

        areaEditor = areaEditor.replace('ddlEmailTemp', 'RadareaEditor');
        areaEditor = document.getElementById(areaEditor);

        spn_CurrentSupplierNo = spn_CurrentSupplierNo.replace('ddlEmailTemp', 'spn_CurrentSupplierNo');
        spn_CurrentSupplierNo = document.getElementById(spn_CurrentSupplierNo);

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

                    var PdfPath1 = '';
                    var EmailFooter = '';
                    for (var j = 1; j <= SupplierCount; j++) {
                        PDFPath1 = '<%=strSitePath %>pdf.aspx?key=' + spn_CurrentSupplierNo.innerHTML + '_' + '<%=TemplateKey %>';
                        EmailFooter = '<%=Session["firstName"].ToString() %> <%=Session["lastName"].ToString() %>';
                    }
                    areaEditor.value = areaEditor.value.replace("[$PDFPath$]", PDFPath1);
                    areaEditor.value = areaEditor.value.replace("[$EmailFooter$]", EmailFooter);
                }
            }
        }
    }

</script>
<asp:Panel ID="pnl_ShowEmailType" runat="server" Visible="false">
    <script>
        var div_EmailBody_PrintBroker = document.getElementById("div_EmailBody_PrintBroker");
        var div_EmailBodyContent = document.getElementById("div_EmailBodyContent");
        div_EmailBody_PrintBroker.style.display = "none";
        var SysName = '<%=SysName %>';

        function OpenEmailClient(LoopCnt, TotSup) {
            var txtfirstname = document.getElementById("<%=txtfirstname.ClientID %>");
            var hid_subject = document.getElementById("<%=hid_subject.ClientID %>");
            var hid_body = document.getElementById("<%=hid_body.ClientID %>");
            var areaEditor = document.getElementById("<%=RadareaEditor.ClientID %>");
            var txtbcc = document.getElementById("<%=txtbcc.ClientID %>");

            var txtfirstnameNew = txtfirstname.id.replace('uc' + TotSup + '', 'uc' + LoopCnt + '');
            var hid_subjectNew = hid_subject.id.replace('uc' + TotSup + '', 'uc' + LoopCnt + '');
            var hid_bodyNew = hid_body.id.replace('uc' + TotSup + '', 'uc' + LoopCnt + '');
            var areaEditorNew = areaEditor.id.replace('uc' + TotSup + '', 'uc' + LoopCnt + '');
            var txtbccNew = txtbcc.id.replace('uc' + TotSup + '', 'uc' + LoopCnt + '');

            txtfirstnameNew = document.getElementById(txtfirstnameNew);
            hid_subjectNew = document.getElementById(hid_subjectNew);
            hid_bodyNew = document.getElementById(hid_bodyNew);
            areaEditorNew = document.getElementById(areaEditorNew);
            txtbccNew = document.getElementById(txtbccNew);

            var to = txtfirstnameNew.value;
            var cc = ""; //'<%=Session["email"].ToString() %>';
            var bcc = txtbccNew.value;
            var subject = hid_subjectNew.value;
            var body = '';
            var PdfPath = '<%=strSitePath %>' + "pdf.aspx?key=" + LoopCnt + "_" + '<%=TemplateKey %>';
            var EmailFooter = '<%=Session["firstName"].ToString()%>' + " " + '<%=Session["lastName"].ToString()%>';
            //body = body.replace("[$EmailFooter$]", EmailFooter);
            //body = body.replace("[$PDFPath$]", PdfPath);

            hid_bodyNew.value = hid_bodyNew.value.replace("[$PDFPath$]", '<a href=' + PdfPath + '>' + PdfPath + '</a>');
            body = '<a href=' + PdfPath + '>' + PdfPath + '</a>'; //hid_bodyNew.value;            
            if (LoopCnt == 1) {
                div_EmailBodyContent.innerHTML = hid_bodyNew.value;
            }

            body = strip(body);
            //alert(body;)
            //        body = body.replace("\r\n","<br>");
            //        body = body.replace("<br>","%0A%0A");

            //hid_bodyNew.value = hid_bodyNew.value.replace("\r\n","<br>");
            var FinalOccyStr = hid_bodyNew.value;
            for (var k = 0; k < 10; k++) {
                FinalOccyStr = FinalOccyStr.replace("<br>", "%0A");
                FinalOccyStr = FinalOccyStr.replace("<br />", "%0A");
                FinalOccyStr = FinalOccyStr.replace("<p>", "");
                FinalOccyStr = FinalOccyStr.replace("</p>", "%0A%0A");
            }

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
                div_EmailBody_PrintBroker.style.display = "none";
            }
            else {
                location.href = lnkMail + "&body=" + escape(body) + "";
                div_EmailBody_PrintBroker.style.display = "block";
            }
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
    <script>
        var hid_EstimateNumber = document.getElementById("<%=hid_EstimateNumber.ClientID %>");
        var hid_TemplateKey = document.getElementById("<%=hid_TemplateKey.ClientID %>");



        function ShowOnEmailType() {
            for (var j = 1; j <= SupplierCount; j++) {
                //alert(SupplierCount);

                var hid_EmailSettingType = document.getElementById("<%=hid_EmailSettingType.ClientID %>");
                var div_EmailFromEprint = document.getElementById("<%=div_EmailFromEprint.ClientID %>");
                var div_EmailFromOthers = document.getElementById("<%=div_EmailFromOthers.ClientID %>");
                var lnkDownloadPDF = document.getElementById("<%=lnkDownloadPDF.ClientID %>");
                var hid_EmailSupCount = document.getElementById("<%=hid_EmailSupCount.ClientID %>");
                var areaEditor = document.getElementById("<%=RadareaEditor.ClientID %>");
                var spn_CurrentSupplierNo = document.getElementById("<%=spn_CurrentSupplierNo.ClientID %>");

                var hid_EmailSettingTypeNew = hid_EmailSettingType.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var div_EmailFromEprintNew = div_EmailFromEprint.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var div_EmailFromOthersNew = div_EmailFromOthers.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var lnkDownloadPDFNew = lnkDownloadPDF.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var hid_EmailSupCountNew = hid_EmailSupCount.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var areaEditorNew = areaEditor.id.replace('uc' + SupplierCount + '', 'uc' + j + '');
                var spn_CurrentSupplierNoNew = spn_CurrentSupplierNo.id.replace('uc' + SupplierCount + '', 'uc' + j + '');

                hid_EmailSettingTypeNew = document.getElementById(hid_EmailSettingTypeNew);
                div_EmailFromEprintNew = document.getElementById(div_EmailFromEprintNew);
                div_EmailFromOthersNew = document.getElementById(div_EmailFromOthersNew);
                lnkDownloadPDFNew = document.getElementById(lnkDownloadPDFNew);
                hid_EmailSupCountNew = document.getElementById(hid_EmailSupCountNew);
                areaEditorNew = document.getElementById(areaEditorNew);
                spn_CurrentSupplierNoNew = document.getElementById(spn_CurrentSupplierNoNew);

                //div_EmailFromEprintNew.style.display = "none";
                //div_EmailFromOthersNew.style.display = "none";

                if (hid_EmailSettingTypeNew.value == "o") {
                    window.parent.document.getElementById("ds00").style.display = "none";
                    window.parent.document.getElementById("div_Load").style.display = "none";
                    document.getElementById("div_btnSendEmail").style.display = "none";
                    //                    document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_div_btnSendEmail").style.display = "none";
                    //                    document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_div_btnSendEmail1").style.display = "none";
                    div_EmailFromEprintNew.style.display = "none";
                    div_EmailFromOthersNew.style.display = "block";


                    OpenEmailClient(j, SupplierCount);
                    hid_EmailSupCountNew.value = j;
                    if (j == SupplierCount) {
                        //__doPostBack('ctl00$ContentPlaceHolder1$UCtemplate1$uc' + j + '$lnkDownloadPDF', '');
                        PageMethods.SaveEmailedTemplate_Printbroker(SupplierCount, hid_EstimateNumber.value, hid_TemplateKey.value, GetKeyOnInsert);
                    }
                }
                else {
                    //                    document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_div_btnSendEmail").style.display = "block";
                    //                    document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_div_btnSendEmail1").style.display = "block";
                    div_EmailFromOthersNew.style.display = "none";
                    div_EmailFromEprintNew.style.display = "block";

                    var PdfPath1 = '<%=strSitePath %>' + "pdf.aspx?key=" + j + "_" + '<%=TemplateKey %>';
                    var EmailFooter = '<%=Session["firstName"].ToString()%>' + " " + '<%=Session["lastName"].ToString()%>';

                    //                    areaEditorNew.value = areaEditorNew.value.replace("[$PDFPath$]", PdfPath1);


                    areaEditorNew.value = areaEditorNew.innerHTML.replace("[$EmailFooter$]", EmailFooter);
                    spn_CurrentSupplierNoNew.innerHTML = j;
                }
            }
        }

        ShowOnEmailType(); //==Called in usrcntl>templates_view page

        function GetKeyOnInsert(result) {
            //alert(result);
        }
        function RadWinClose() {

            // document.getElementById("ds00").style.display = "none";
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }
    </script>
    <script>

        var AttachImageID = '';
        var _dopostbackAttachImage = ''
        function Call_Attachment(ObjAttach) {
            var PageType = '<%=pg %>';
            var EstimateID = "<%=EstimateID %>";
            var sectionname = '<%=sectionname %>';
            var pagetype = 'emailtemplate';
            AttachImageID = ObjAttach.id;
            var AttachSupplierID = AttachImageID.replace("Image_Attachment", "lnk_AttachUpdate");
            _dopostbackAttachImage = document.getElementById(AttachSupplierID);
            var suplrID = _dopostbackAttachImage.innerHTML;
            var suplrid = '';
            var PathAttach = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&estid=" + EstimateID + " &pg=" + PageType + "&Section=" + sectionname + "&suplrid=" + suplrID + "&AttachImageID=" + AttachImageID + "";

            window.parent.openAttpopup(PathAttach);
        }

        //        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
        //            var div_Accountcode = document.getElementById(divMaskID);
        //            var divBackGroundNew = document.getElementById(divBackgroundID);
        //            if (document.getElementById(divMaskID).style.display == "none") {

        //                if (navigator.appName != "Microsoft Internet Explorer") {
        //                    setLoadingPositionOfDivCenter_Ver2(Div_Attachment);
        //                }
        //                showDivPopupCenter_Ver2(divMaskID);
        //            }
        //            else {
        //                showDivPopupCenter_Ver2(divMaskID);
        //            }
        //        }        


        //        function Check_Attachment() {
        //            var Count = '<%=AttachCount%>';
        //            var Str_AttachPath = '<%=Str_AttachPath %>';
        //            var hdn_Attach = document.getElementById("<%=hdn_Attach.ClientID %>");
        //            if (SupplierCount > 1) {
        //                for (var k = 1; k <= SupplierCount; k++) {
        //                    var hdn_TotalAttach = document.getElementById("<%=hdn_TotalAttach.ClientID %>");
        //                    var hdn_TotalAttachNew = hdn_TotalAttach.id.replace('uc' + SupplierCount + '', 'uc' + k + '');
        //                    hdn_TotalAttachNew = document.getElementById(hdn_TotalAttachNew);
        //                    alert(hdn_TotalAttachNew.value);
        //                    if (hdn_TotalAttachNew.value > 0) {
        //                        for (var i = 0; i < hdn_TotalAttachNew.value; i++) {
        //                            var ChckAttach = document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_uc" + k + "_Chk_Attach_" + i + "");
        //                            //alert(ChckAttach.id)
        //                            if (ChckAttach.checked) {
        //                                hdn_Attach.value += Str_AttachPath + ChckAttach.nextSibling.innerHTML + "µ";
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }


    </script>
    <script>
        function GetAttachLink_Supplier(Attached, ActualFiles, ContainerID, Path) {
            debugger
            var StrChckbox = '';
            var MainContainerID = ContainerID;
            var Str_AttachPath = Path;

            MainContainerID = MainContainerID.replace("Image_Attachment", "RadareaEditor");
            // var FCKeditor = window.parent.frames[0].document.getElementById(MainContainerID);
            var StrAttach = Attached.split('‡');
            var StrActual = ActualFiles.split('‡');
            for (var i = 0; i < StrAttach.length - 1; i++) {
                var AttachFileName = StrAttach[i];
                var ActualFileName = StrActual[i];
                StrChckbox += "<div align='left' style='float:left; cursor:default; border:0px solid red; clear: both; width:500px;'>";
                //StrChckbox += "<a href='" + Path + "ImageHandler_Print.ashx?FileName=" + ActualFileName + "&cid=" + '<%=CompanyID %>' + "'  target='_blank'>" + AttachFileName + "</a>";
                StrChckbox += "<a href='" + Path + ActualFileName + "'  target='_blank'>" + AttachFileName + "</a>";
                StrChckbox += "</div>";
            }
            var Editor = $find(MainContainerID);
            Editor.set_html(Editor.get_html() + "<br />" + StrChckbox);


        }
    </script>
</asp:Panel>

