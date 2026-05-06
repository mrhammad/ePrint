<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email_send_activityhistory.aspx.cs" Inherits="ePrint.common.email_send_activityhistory" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=sirSitePath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript">
        function RadWinClose() {
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="radscript" runat="server">
        </asp:ScriptManager>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr>
                <td>
                    <input id="hdnRefreshData" runat="server" type="hidden" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="padding">
                        <div class="only10px">
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <%--class="borderWithoutTop"--%>
                            <tr>
                                <td>
                                    <table cellspacing="2" cellpadding="2" width="98%" align="center" border="0">
                                        <tr valign="top">
                                            <td colspan="2">
                                                <img height="2" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="5px" class="label">
                                                &nbsp;<asp:Label ID="lblassigned" runat="server" Width="75px" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("To") %></asp:Label>
                                            </td>
                                            <td align="left" width="95%" class="normaltext">
                                                <div style="border: solid 0px red; width: 74.5%;">
                                                    <div align="left">
                                                        <textarea class="txtbox" rows="2" cols="55" name="txtfirstname" id="txtfirstname"
                                                            runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_To')"></textarea>
                                                        &nbsp;&nbsp;
                                                        <asp:Image Style="vertical-align: top; cursor: pointer; padding-top: 2px" ID="imgselectleadmain"
                                                            runat="server" Visible="true" />
                                                        <span id="spn_To" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; float: left;">
                                                            Please enter valid email</span>
                                                        <br />
                                                        [<%=objLanguage.GetLanguageConversion("Comma_Separate_Email_Note")%>]&nbsp;
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="label" valign="top" align="left" width="5%">
                                                <span class="normaltext">&nbsp;<%=objLanguage.GetLanguageConversion("CC")%></span>
                                            </td>
                                            <td class="normaltext" align="left" width="95%">
                                                <div style="border: solid 0px red; width: 74.5%;">
                                                    <div align="left">
                                                        <textarea name="txtcc" rows="2" cols="55" id="txtcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_cc')"></textarea>
                                                        &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadcc"
                                                            runat="server" Visible="false" />
                                                        <span id="spn_cc" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px; display: none; float: left;">
                                                            Please enter valid email</span>
                                                        <br />
                                                        [<%=objLanguage.GetLanguageConversion("Comma_Separate_Email_Note")%>]&nbsp;
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" width="5%" class="label">
                                                &nbsp;<asp:Label ID="Label2" runat="server" Width="75px" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("BCC") %></asp:Label>
                                            </td>
                                            <td class="normaltext" align="left" width="95%">
                                                <div style="border: solid 0px red; width: 74.5%">
                                                    <div align="left">
                                                        <div style="width: 20%; overflow: hidden;">
                                                        </div>
                                                        <textarea name="txtbcc" rows="2" cols="55" id="txtbcc" runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_bcc')"></textarea>
                                                        &nbsp;&nbsp;<asp:Image Style="vertical-align: middle; cursor: pointer" ID="imgselectleadbcc"
                                                            runat="server" Visible="false" />
                                                        <span id="spn_bcc" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px; display: none; float: left;">
                                                            Please enter valid email</span>
                                                        <br />
                                                        [<%=objLanguage.GetLanguageConversion("Comma_Separate_Email_Note")%>]&nbsp;
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" width="5%" class="label">
                                                &nbsp;<asp:Label ID="Label3" runat="server" Width="75px" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Subject") %><span style="color:red"> *</span></asp:Label>
                                                
                                            </td>
                                            <td align="left" width="95%" class="normaltext">
                                                <div style="border: solid 0px red; width: 74.5%">
                                                    <div align="left">
                                                        <div style="width: 20%; overflow: hidden;">
                                                        </div>
                                                        <input class="txtbox" style="height: 30px" type="text" maxlength="200" size="75"
                                                            name="txtsubject" id="txtsubject" onblur="javascript:validatesubject(this.value);"
                                                            runat="server">
                                                        <span id="spn_subject" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px; display: none; float: left">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Subject") %></span>
                                                        <div class="error_top">
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" width="5%" class="label">
                                                <%--class="newLabelText"--%>
                                                &nbsp;<asp:Label ID="Label4" runat="server" Width="75px" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Attachments") %></asp:Label>
                                            </td>
                                            <td align="left" width="95%" class="normaltext">
                                                <input class="txtbox" style="height: 30px" readonly="readonly" type="text" size="75"
                                                    name="txtattachment" id="txtattachment" runat="server">&nbsp;&nbsp; <a id="LinkButton1"
                                                        runat="server" style="cursor: pointer;">
                                                        <%=objLanguage.GetLanguageConversion("Attach_File") %></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="label" style="width: 17%" nowrap="nowrap" visible="false">
                                                <span class="normaltext">&nbsp;<%=objLanguage.GetLanguageConversion("Email_type")%></span>
                                            </td>
                                            <td class="Normaltext" style="width: 83%">
                                                <div style="width: 20%; overflow: hidden; vertical-align: super">
                                                </div>
                                                <asp:DropDownList AutoPostBack="true" ID="ddltemplateType" Width="100px" runat="server"
                                                    OnSelectedIndexChanged="ddltemplateType_SelectedIndexChanged">
                                                    <asp:ListItem Value="1" Text="HTML" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Text"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" class="label" width="5%">
                                                &nbsp;<asp:Label ID="Label1" runat="server" Height="3px" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Message") %></asp:Label>
                                            </td>
                                            <td align="left" width="95%">
                                                <input type="hidden" id="hdnEditorValue" runat="server" value="may i know" />
                                                <input type="hidden" id="hdnselectTemplate" runat="server" />
                                                <noscript>
                                                    <p>
                                                        <b>Javascript must be enabled to use this form.</b></p>
                                                </noscript>
                                                <div style="float: left; border: 0px solid; height: 300px;">
                                                    <telerik:RadEditor ID="RadEditor1" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                        ImageManager-ViewMode="Grid" ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute"
                                                        OnClientLoad="OnClientLoad" ContentAreaMode="Iframe">
                                                        <Content>
                                                                          
                                                        </Content>
                                                        <CssFiles>
                                                            <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                        </CssFiles>
                                                    </telerik:RadEditor>
                                                </div>
                                                <asp:TextBox TextMode="MultiLine" ID="areaEditor" Width="600px" Height="300px" runat="server"
                                                    Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
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
                                    <div style="float: left; width: 100%;">
                                        <div style="float: left;">
                                            <asp:DropDownList Width="200px" ID="ddlLeadMoreAction" runat="server" Visible="false">
                                                <asp:ListItem Text="---------More Action-------" style="color: #a1a1a1" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Select Template" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Attach File" Value="2"></asp:ListItem>
                                                <%--<asp:ListItem Text="Preview" Value="3"></asp:ListItem>--%>
                                                <asp:ListItem Text="-------------------------" style="color: #a1a1a1" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Create new Template" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Add to new Template" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Add to existing Template" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div style="float: right; width: 82%;">
                                            <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" OnClick="btncancel_Click"
                                                CausesValidation="False"></asp:Button>
                                            <asp:Button ID="btnsend" runat="server" CssClass="button" OnClientClick="javascript:var a=checkvalidaetion();if(a)loadingimage(this.id,'div_btnsaveprocess');return a; "
                                                OnClick="btnsend_Click" Text="Send"></asp:Button><%--OnClick="btnsend_Click"--%>
                                            <div id="div_btnsaveprocess" style="display: none">
                                             <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                              </div>
                                        </div>
                                    </div>
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
                                            <td colspan="3" height="10px">
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
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divrad" style="display: none; position: absolute; vertical-align: middle;
        border: 0px solid; z-index: 100; width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="900" Style="z-index: 31000" Height="500"
            OnClientClose="RadWinClose" Behaviors="Close, Move, Reload, Resize" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="../js/CommonOpenPopup.js?VN='<%=VersionNumber%>'"></script>

<script type="text/javascript" language="javascript">

    var sectionid = '<%=sectionid %>';
    var sectionname = '<%=sectionname %>';

    function validatesubject(value) {
        if (value == '') {
            document.getElementById("spn_subject").style.display = "block";
        }
        else {
            document.getElementById("spn_subject").style.display = "none";
        }
    }

    function validateEmail(field) {
        //var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return (regex.test(field)) ? true : false;
    }

    function validateMultipleEmailsCommaSeparated(value, spnid) {

        document.getElementById(spnid).style.display = "none";
        if (value == '') {
            if (spnid == 'spn_To') {
                document.getElementById(spnid).innerHTML = "Please enter email address";
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
    var Isvalided = true;
    function checkvalidaetion() {
        var Isvalided = true;
        var txtfirstname = document.getElementById("<%=txtfirstname.ClientID %>");
        var txtcc = document.getElementById("<%=txtcc.ClientID %>");
        var txtbcc = document.getElementById("<%=txtbcc.ClientID %>");
        var txtsubject = document.getElementById("txtsubject");
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
            return true;
        }
        else {
            return false;
        }

    }

    function TagHelper() {
        window.radopen("<%=nmsCommon.global.sitePath()%>common/tag_helper.aspx?sectionname=<%=sectionname%>", '615', '610');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

    function OpenPopUp() {

        var lblError = document.getElementById("ctl00_ContentPlaceHolder1_lblError");

        var divAddNew = document.getElementById("divAddNew");
        var divAddExisting = document.getElementById("divAddExisting");
        var ddlLeadMoreAction = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
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
            window.radopen("<%=nmsCommon.global.sitePath()%>common/attachfile.aspx?pg=<%=sectionname%>", '730', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
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
            var areaEditor = document.getElementById("ctl00_ContentPlaceHolder1_areaEditor").value;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_areaEditor").value;
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
            window.radopen("<%=nmsCommon.global.sitePath()%>common/Create_template.aspx?pg=<%=sectionname%>", '730', '400');
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

function BindContact_EmailIDS(to, cc, bcc) {
    var txtfirstname = document.getElementById("<%=txtfirstname.ClientID %>");
        var txtcc = document.getElementById("<%=txtcc.ClientID %>");
        var txtbcc = document.getElementById("<%=txtbcc.ClientID %>");
        txtfirstname.value = to;
        txtcc.value = cc;
        txtbcc.value = bcc;
    }


</script>
<asp:panel id="pnlLoadEmailPanel" runat="server" visible="false">

    <script type="text/javascript" language="javascript">

        function LoadEmailPanel() {
            var pw = window.parent;
            pw.SetTabs('emails');
            setTimeout("TakeOut()", 600);
        }
        function TakeOut() {
            window.close();
        }

        LoadEmailPanel();
    </script>

</asp:panel>
</html>


