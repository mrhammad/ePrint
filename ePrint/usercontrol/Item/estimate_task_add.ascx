<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="estimate_task_add.ascx.cs" Inherits="ePrint.usercontrol.Item.estimate_task_add" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script type="text/javascript">
    var currentdate = '<%=newdate %>';
    function showhidemenu(xID) {
        var x = document.getElementById('ctl00_ContentPlaceHolder1_txttype');
        var y = document.getElementById('ctl00_ContentPlaceHolder1_ImageButton1');
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddlcontacttype');
        var txt = document.getElementById('ctl00_ContentPlaceHolder1_txtcontacttype');


        if (xID == 'Contact') {
            eval("window.document.forms[0]['ctl00_ContentPlaceHolder1_ddltype'].disabled=''");
            eval("x.disabled=''");
            eval("y.disabled=''");
            eval("y.style.width=25");
            txt.value = "<%=txttypevalue1%>"

        }
        else if (xID == 'Lead') {
            eval("window.document.forms[0]['ctl00_ContentPlaceHolder1_ddltype'].disabled='disabled'");
            eval("x.disabled='disabled'");
            eval("y.disabled='disabled'");
            eval("y.style.width=0");
            txt.value = "<%=temptxt%>";
        }
        else {
            eval("window.document.forms[0]['ctl00_ContentPlaceHolder1_ddltype'].disabled='disabled'");
            eval("x.disabled='disabled'");
            eval("y.disabled='disabled'");
            eval("y.style.width=0");
            window.document.forms[0]['ctl00_ContentPlaceHolder1_txtcontacttype'].value = "";
        }

}
function showddltype() {
    var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddltype');
    var txt = document.getElementById('ctl00_ContentPlaceHolder1_txttype');
    var txtvalue = txt.value;
    if (ddl.options[ddl.selectedIndex].text == "<%=ddltypevalue%>") {
        txt.value = "<%=txttypevalue%>";
    }
    else if (ddl.options[ddl.selectedIndex].text == "Select Type") {
        txt.value = ' ';
    }
    else {
        txt.value = ' ';
    }
}
function FromSelecttaskPage(ContactName, ContactID) {
    document.getElementById("<%=txtcontacttype.ClientID %>").value = ContactName;
    document.getElementById("<%=contactid_hidden.ClientID %>").value = ContactID;
    document.getElementById("<%=contacttxt_hidden.ClientID %>").value = ContactName;
}
function openwin2() {
    var contacttype;
    var openwin;
    openwin = "common/selecttaskcontact.aspx?contacttype=Contact";
    window.radopen("<%=nmsCommon.global.sitePath()%>" + openwin, '900', '400');
}
function openwin1() {
    var type;
    type = window.document.forms[0]['ctl00_ContentPlaceHolder1_ddltype'].value;
    var openwin;
    openwin = "common/selecttasktype.aspx?type=" + type;
    window.radopen("<%=nmsCommon.global.sitePath()%>" + openwin, '900', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function InsertSearchtext1(val) {
    var txtSearch = document.getElementById("<%=txtduedate.ClientID %>");
    if (val == 'f') {
        if (txtSearch.value == '')
            txtSearch.value = '';
        txtSearch.className = 'txtonblur1';
    }
    else {
        if (txtSearch.value == '') {
            txtSearch.value = '';
            txtSearch.className = 'txtonblur';
        }
    }
}

</script>


<div id="divBackGroundNew" style="display: none; z-index: 1000;">
</div>
<div id="div_task_add" style="position: absolute; z-index: 1200; width: 65%">
    <table cellpadding="0" cellspacing="0" width="100%" height="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b><%=objLangClass.GetLanguageConversion("Task_New_Task")%> </b>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton4" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideTaskDiv();return false;" />
                        <img id="img_button" title="Cancel" runat="server" src="~/images/closebtn.png" alt=" "
                            onclick="javascript:hideTaskDiv();return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">&nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">&nbsp;
            </td>
            <td class="popup-middlebg" align="left">
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="1">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr valign="top">
                                    <td>
                                        <input type="hidden" name="assigntoid_hidden" id="assigntoid_hidden" runat="server" />
                                        <input type="hidden" name="contactid_hidden" id="contactid_hidden" runat="server"
                                            value="0" />
                                        <input type="hidden" name="typeid_hidden" id="typeid_hidden" runat="server" />
                                        <input type="hidden" name="contacttxt_hidden" id="contacttxt_hidden" runat="server" />
                                        <input type="hidden" name="typetxt_hidden" id="typetxt_hidden" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img alt="" src="<%=strImagepath%>nil.gif" width="1" height="3" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div class="successfull_message2">
                                            <asp:Label ID="lblsuccessfull" runat="server" CssClass="successfull_message" Visible="false"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0">
                                            <tr valign="top">
                                                <td>
                                                    <table cellspacing="2" cellpadding="2" width="99%" align="center" border="0">
                                                        <tr valign="top">
                                                            <td colspan="5" height="5px">
                                                                <div style="float: left; width: 100%">
                                                                    <span style="float: right; color: red">*<%=objLangClass.GetLanguageConversion("Fields_Are_Mandatory")%> </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="left" class="label" style="width: 20%" nowrap="nowrap">
                                                                <div style="float: left">
                                                                    &nbsp;<asp:Label ID="Label6" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: middle" ID="ImageButton3" runat="server"
                                                                        CausesValidation="False" Visible="false" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30%" nowrap="nowrap" align="left">
                                                                <asp:DropDownList runat="server" ID="ddlassigneto" CssClass="normaltext" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="label" style="width: 20%">&nbsp;<asp:Label ID="lblstatus" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                                                <span style="color: red">*</span>
                                                            </td>
                                                            <td style="width: 30%" colspan="2">
                                                                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="normaltext" Width="200px">
                                                                </asp:DropDownList>
                                                                <div style="margin-top: 5px; width: 200px;">
                                                                    <span id="spn_ddlstatus" class="spanerrorMsg" style="display: none; width: 200px;"><%=objLangClass.GetLanguageConversion("Please_Select_Status")%> </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr valign="middle">
                                                            <td class="label" valign="middle">
                                                                <div style="float: left">
                                                                    &nbsp;<asp:Label ID="lblsubject" runat="server" Text="" CssClass="normaltext">
                                                        <span class="redver7">*</span></asp:Label>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="" ID="ImageButton9" OnClientClick="javascript:show_hide_subject('show');return false;"
                                                                        runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                                                </div>
                                                            </td>
                                                            <td valign="top" class="normaltext" nowrap="nowrap">
                                                                <asp:UpdatePanel RenderMode="Block" runat="server" ID="up12">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList runat="server" ID="ddlsubject" CssClass="normaltext" Width="200px"
                                                                            onchange="javascript:CallonChange(this.value,'spn_ddlsubject');SetVal(this);return false;">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnOK" EventName="Click" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                                <div style="margin-top: 4px">
                                                                    <span id="spn_ddlsubject" class="spanerrorMsg" style="display: none; width: 200px;">Please select Subject</span>
                                                                </div>
                                                            </td>
                                                            <td class="label" valign="top">&nbsp;<asp:Label ID="lblpriority" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                                                <span style="color: red">*</span>
                                                            </td>
                                                            <td valign="top" colspan="2">
                                                                <asp:DropDownList ID="ddlpriority" runat="server" CssClass="normaltext" Width="200px">
                                                                </asp:DropDownList>
                                                                <div style="margin-top: 4px">
                                                                    <span id="spn_ddlpriority" class="spanerrorMsg" style="display: none; width: 200px;">
                                                                        <%=objLangClass.GetLanguageConversion("Please_Select_Priority")%> </span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="label" valign="top">
                                                                <div style="float: left">
                                                                    &nbsp;<asp:Label ID="lblcontacts" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: middle" ID="ImageButton2" runat="server"
                                                                        CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                                                </div>
                                                            </td>
                                                            <td valign="top" align="left" nowrap="nowrap">
                                                                <input type="text" name="txtcontacttype" maxlength="200" class="textboxnew" style="width: 200px"
                                                                    id="txtcontacttype" runat="server" readonly="readonly" />
                                                                <div style="margin-bottom: 2px; margin-top: 3px">
                                                                    <asp:Label ID="lblcontacterror" CssClass="error" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td class="label" style="width: 20%;" nowrap="nowrap">
                                                                <asp:Label ID="lblduedate" runat="server" CssClass="normaltext">&nbsp;<%=objLangClass.GetLanguageConversion("Due_Date_And_Time_hh_mm")%> 
                                                    <span class="redver7">*</span></asp:Label>
                                                            </td>
                                                            <td valign="top" style="width: 38%;" class="normaltext">
                                                                <asp:TextBox ID="txtduedate" runat="server" SkinID="textboxnew" CssClass="textboxnew"
                                                                    Width="82px"> </asp:TextBox>
                                                                &nbsp;&nbsp;<asp:DropDownList ID="ddlhour" runat="server" CssClass="normaltext" Width="46px"
                                                                    ToolTip="Hour(s)">
                                                                </asp:DropDownList>
                                                                :
                                                                <asp:DropDownList ID="ddlminute" runat="server" CssClass="normaltext" Width="46px"
                                                                    ToolTip="Minute(s)">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <asp:Label ID="lblduedate_value" Visible="false" runat="server" CssClass="normaltext"></asp:Label>
                                                                <div style="margin-top: 5px">
                                                                    <span id="spn_txtDueDate" class="spanerrorMsg" style="display: none; width: 200px;"></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <asp:PlaceHolder runat="server" ID="pnlLinkedTo" Visible="true">
                                                            <tr>
                                                                <td class="label" valign="top">&nbsp;<asp:Label ID="Label1" runat="server" Text="Linked To" CssClass="normaltext"></asp:Label>
                                                                </td>
                                                                <td nowrap="nowrap" align="left" colspan="3">
                                                                    <asp:DropDownList runat="server" ID="ddllinkedto" CssClass="normaltext" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </asp:PlaceHolder>

                                                        <script language="javascript">
                                                            function txtduedate_onfocus() {
                                                                var reqID = document.getElementById('ctl00_ContentPlaceHolder1_UCItemDescription_UCTask_txtduedate');
                                                            }
                                                        </script>

                                                        <tr valign="top" style="display: none">
                                                            <td class="label" valign="top">&nbsp;<asp:DropDownList ID="ddltype" runat="server" CssClass="normaltext" Width="120px">
                                                            </asp:DropDownList>
                                                            </td>
                                                            <td valign="top" align="left">
                                                                <asp:TextBox ID="txttype" runat="server" SkinID="textPad" MaxLength="200" CssClass="txtbox"
                                                                    Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton Style="vertical-align: middle"
                                                                        ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="../../images/plus.gif"></asp:ImageButton>
                                                                <div style="margin-top: 4px; margin-bottom: 2px">
                                                                    <asp:Label ID="lbltxttypeerror" Text="" CssClass="error" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td width="5%"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="label" valign="top">&nbsp;<asp:Label ID="lblcomment" runat="server" Width="65px" Text="Description" CssClass="normaltext"></asp:Label>
                                                            </td>
                                                            <td class="normaltext" colspan="4">
                                                                <asp:TextBox ID="txtcomment" Rows="8" Width="94%" runat="server" TextMode="MultiLine"
                                                                    SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                                                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 175px; white-space: nowrap">Max. length of textbox is: 3000</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"></td>
                                                            <td class="normaltext" colspan="4" valign="top" visible="false">
                                                                <asp:CheckBox ID="Chkemail" runat="server" Text="Send Notification Email" Visible="false"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td>
                                        <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <div style="width: 90%;">
                                            <div style="float: left; width: 50%;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 48%;">
                                                <div align="left">
                                                    <div style="float: left; width: 60%">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <div style="float: left; display: none">
                                                            <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="button" Width="65px"
                                                                OnClientClick="javascript:CloseTaskPage();return false;" />
                                                        </div>
                                                        <div style="float: left; width: 10px;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:Button ID="Button2" runat="server" Text="" CssClass="button" Width="65px"
                                                                OnClientClick="javascript:return CallSave();" OnClick="btnSaveTask_OnClick" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- OLD BUTTON--%>
                                        <div style="width: 90%; display: none;">
                                            <div style="float: left; width: 50%;">
                                                &nbsp;
                                            </div>
                                            <div style="float: right; width: 50%;">
                                                <div style="float: right;">
                                                    <div align="left">
                                                        <div style="float: left;">
                                                            <asp:Button ID="btncancel" runat="server" Width="65px" CausesValidation="False" CssClass="button"
                                                                Text="Cancel" />
                                                        </div>
                                                        <div style="float: left; width: 10px;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:Button ID="btnsave" runat="server" Width="65px" CssClass="button" Text="Save"
                                                                OnClick="btnsave_Click1" OnClientClick="javascript:return testdate();" />
                                                        </div>
                                                        <div style="float: left; width: 10px">
                                                            &nbsp;
                                                        </div>
                                                        <div style="float: left">
                                                            <asp:Button ID="btnaddmore" runat="server" Width="120px" CssClass="button" Text="Save + Add More"
                                                                OnClick="btnaddmore_Click1" Visible="false" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- ABOVE BUTTONS ARE OLD BUTTON NOT IN USE--%>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td>
                                        <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px; background-color: #ffffff">&nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
            </td>
            <td class="popup-bottom-middlebg">&nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="div_SubjectTable" style="display: none; position: absolute; z-index: 1000000; width: 45%"
    align="center">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b>Subject</b>
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton5" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:show_hide_subject('hide');return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">&nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">&nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <div align="left" id="Div4" style="width: 100%; padding: 3px 3px 3px 3px">
                                        <div style="float: left" class="bglabel">
                                            <asp:Label runat="server" ID="lblSubject_popup" CssClass="normaltext" Text="Subject"></asp:Label>
                                        </div>
                                        <div style="float: left; white-space: nowrap;" class="box" nowrap="nowrap">
                                            <asp:TextBox runat="server" ID="txtSubject" SkinID="textPad" Width="200px">
                                            </asp:TextBox>
                                            <span id="spn_txtSubject" class="spanerrorMsg" style="display: none; width: 150px;">
                                                <%=objLangClass.GetLanguageConversion("Please_Enter_Subject")%></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left" class="bglabelEmpty">
                                    </div>
                                    <div style="float: left; display: none">
                                        <asp:Button runat="server" ID="btnCancel_Popup" Text="Cancel" Width="65px" CssClass="button"
                                            OnClientClick="javascript:show_hide_subject('hide');return false;" />
                                    </div>
                                    <div style="float: left; width: 5px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <asp:Button runat="server" ID="btnOK" Text="Save" Width="65px" CssClass="button"
                                            OnClick="btnOK_OnClick" OnClientClick="javascript:return validate1();" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">&nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
            </td>
            <td class="popup-bottom-middlebg">&nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Width="1000" Height="500" Opacity="100" runat="server" OnClientClose="RadWinClose"
        Behaviors="Close, Move, Resize,Reload">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdn_Subject" runat="server" Value="" />

<script>
    var hdn_Subject = document.getElementById("<%=hdn_Subject.ClientID %>");

    var CheckFinal = false;
    function testdate() {
        CheckFinal = true;
        var ddlsubject = document.getElementById("<%=ddlsubject.ClientID%>");
        document.getElementById("spn_txtDueDate").style.display = "none";

        if (ddlsubject.selectedIndex == 0) {
            document.getElementById("spn_ddlsubject").style.display = "block";
            CheckFinal = false;
        }
        var txtduedate = document.getElementById("<%=txtduedate.ClientID%>");
        if (txtduedate.value == "") {
            document.getElementById("spn_txtDueDate").innerHTML = ('<%=objLangClass.GetLanguageConversion("Please_Enter_A_Valid_Date")%>');
            document.getElementById("spn_txtDueDate").style.display = "block";
            CheckFinal = false;
        }
        else {

            if (ValidateForm(txtduedate, 'spn_txtDueDate', DateFormat) == true) {
                CheckFinal = true;
            }
        }
        var ddlstatus = document.getElementById("<%=ddlstatus.ClientID %>");
        if (ddlstatus.selectedIndex == 0) {
            document.getElementById("spn_ddlstatus").style.display = "block";
            CheckFinal = false;
        }
        var ddlpriority = document.getElementById("<%=ddlpriority.ClientID %>");
        if (ddlpriority.selectedIndex == 0) {
            document.getElementById("spn_ddlpriority").style.display = "block";
            CheckFinal = false;
        }
        if (CheckFinal) {
            return true;
        }
        else {
            return false;
        }
    }

    function SetVal(ddl) {
        hdn_Subject.value = ddl.options[ddl.selectedIndex].text;
    }

</script>

<script type="text/javascript">
    function validate1() {
        var isValid = true;
        var txtSubject = document.getElementById("<%=txtSubject.ClientID %>");
        var spn_txtSubject = document.getElementById("spn_txtSubject");
        spn_txtSubject.style.display = "none"
        if (trim12(txtSubject.value) == "") {
            spn_txtSubject.style.display = "block"
            isValid = false;
        }
        if (isValid) {
            show_hide_subject('hide')
            return true;
        }
        else {
            show_hide_subject('show')
            return false;
        }
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>

<script type="text/javascript">
    function setPopUpDivCenter(divisionloading) {

        var width = divisionloading.style.width;
        var height = divisionloading.style.height;

        var div_task_add = document.getElementById("div_task_add");
        var width1 = div_task_add.style.width;
        var height1 = div_task_add.style.minHeight;

        width1 = width1.replace('px', '');
        height1 = height1.replace('px', '');


        width = width.replace('px', '');
        height = height.replace('px', '');

        divisionloading.style.left = ((width1 - width) / 2.3) + "px";    //IE on 30.09.2011

        divisionloading.style.top = ((height1 - height) / 2.3) + "px";

        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
        var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
        var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth
    }
</script>

<script type="text/javascript">
    var txtSubject = document.getElementById("<%=txtSubject.ClientID%>");
    var DateFormat = '<%=DateFormat %>';
</script>

<asp:Panel ID="pnlMoreThanOneRecord" Visible="false" runat="server">

    <script type="text/javascript">
        var type;
        type = window.document.forms[0]['ctl00_ContentPlaceHolder1_txtcontacttype'].value;

        var openwin;
        openwin = "morethanonecontact.aspx?nm=" + type;
       
        window.radopen(openwin, 'Lead', 'width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    </script>

</asp:Panel>
<asp:Panel ID="pnlMoreThanOneRecord1" Visible="false" runat="server">

    <script type="text/javascript">
        var type;
        type = window.document.forms[0]['ctl00_ContentPlaceHolder1_txtcontacttype'].value;
        var openwin;
        openwin = "morethanonecontact1.aspx?nm=" + type;
        window.radopen(openwin, 'Lead', 'width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    </script>

</asp:Panel>

<script type="text/javascript" language="javascript">
    var ddlassigneto = document.getElementById("<%=ddlassigneto.ClientID %>");
    var ddlstatus = document.getElementById("<%=ddlstatus.ClientID %>");
    var ddlsubject = document.getElementById("<%=ddlsubject.ClientID %>");
    var ddlpriority = document.getElementById("<%=ddlpriority.ClientID %>");
    var txtcontacttype = document.getElementById("<%=txtcontacttype.ClientID %>");
    var txtduedate = document.getElementById("<%=txtduedate.ClientID %>");
    var ddlhour = document.getElementById("<%=ddlhour.ClientID %>");
    var ddlminute = document.getElementById("<%=ddlminute.ClientID %>");
    var contactid_hidden = document.getElementById("<%=contactid_hidden.ClientID %>");
    var txtcomment = document.getElementById("<%=txtcomment.ClientID %>");

    function CallSave() {
        var pg = '<%=pg %>';
        if (pg == "home" || pg == "client") {
            if (testdate() == false) {
                return false;
            }
        }
        else {
            Store_Task_Data();
            return false;
        }
    }

    function hideTaskDiv() {
        document.getElementById("div_Task").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>

