<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task_add.aspx.cs" Inherits="ePrint.common.task_add" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <script type="text/javascript">

        function showhidemenu(xID) {
            var x = document.getElementById('ctl00_ContentPlaceHolder1_txttype');
            var y = document.getElementById('ctl00_ContentPlaceHolder1_ImageButton1');
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddlcontacttype');
            var txt = document.getElementById('ctl00_ContentPlaceHolder1_txtcontacttype');
            debugger;

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

        function openwin2() {
            var contacttype;
            var openwin;
            openwin = "common/selecttaskcontact.aspx?contacttype=Contact";
            window.radopen("<%=nmsCommon.global.sitePath()%>" + openwin, '900', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
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
            var txtSearch = document.getElementById("ctl00_ContentPlaceHolder1_txtduedate");
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
    <script type="text/javascript" src="calendar.js?VN='<%=VersionNumber%>'"></script>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr valign="top" style="display: none;">
            <td class="Border1px_New">
                <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0" height="23">
                    <tr>
                        <td width="1%" valign="top" align="left" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                        </td>
                        <%--r1.jpg--%>
                        <td nowrap="nowrap" class="bgcustomize" width="98%">
                            <asp:Label ID="lbltask" runat="server" Text='' CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Task")%>: </asp:Label><asp:Label
                                ID="lbltask_value" runat="server" Text='' CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("New_Task")%></asp:Label>
                        </td>
                        <td width="1%" valign="top" align="right" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                        </td>
                        <%--r3.jpg--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: -10px;">
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
                                                <td colspan="4" height="5px">
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" class="label" style="width: 20%" nowrap="nowrap">
                                                    <div style="float: left">
                                                        &nbsp;<asp:Label ID="Label6" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Assigned_To")%></asp:Label>
                                                    </div>
                                                    <div style="float: right">
                                                        <asp:ImageButton Style="vertical-align: middle" ID="ImageButton3" runat="server"
                                                            CausesValidation="False" Visible="false" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                                    </div>
                                                </td>
                                                <td style="width: 30%" nowrap="nowrap" align="left">
                                                    <%--<asp:TextBox ID="txtassignto" runat="server" CssClass="txtbox" Width="200" ReadOnly="true"></asp:TextBox>--%>
                                                    <asp:DropDownList runat="server" ID="ddlassigneto" CssClass="normaltext" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="label" style="width: 20%">
                                                    <%--class="NewBackgroung"--%>
                                                    &nbsp;<asp:Label ID="lblstatus" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Status")%></asp:Label>
                                                    <span style="color: red">*</span>
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="normaltext" Width="200px">
                                                    </asp:DropDownList>
                                                    <%--<div style="margin-top: 5px; width: 200px;">--%>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_ddlstatus" style="display: none; width: 200px; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Please_Select_Status")%></span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr valign="middle">
                                                <td class="label" valign="middle">
                                                    <%-- &nbsp;<asp:Label ID="lblsubject" runat="server" Width="65px" Text="Subject" CssClass="normaltext">Subject<span class="redver7">*</span></asp:Label>--%>
                                                    <div style="float: left">
                                                        &nbsp;<asp:Label ID="lblsubject" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Subject")%> 
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
                                                            <div style="float: left">
                                                                <asp:DropDownList runat="server" ID="ddlsubject" CssClass="normaltext" Width="200px"
                                                                    onchange="javascript:deletedisplay();CallonChange(this.value,'spn_ddlsubject');return false;">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div id="divdelete" style="float: left; display: none; padding-left: 5px">
                                                                <asp:ImageButton Style="" ID="ImageButton4" OnClick="btnDelete_OnClick" runat="server"
                                                                    CausesValidation="False" ImageUrl="~/images/deleteicon3.png"></asp:ImageButton></div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <%--  <asp:AsyncPostBackTrigger ControlID="btnOK" EventName="Click" />--%>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <%-- <div style="margin-top: 4px">--%>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_ddlsubject" style="display: none; width: 200px; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Please_Select_Subject")%></span>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="label" valign="top">
                                                    <%--class="NewBackgroung"--%>
                                                    &nbsp;<asp:Label ID="lblpriority" runat="server" Text='<%=objLanguage.GetLanguageConversion("Priority")%>'
                                                        CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Priority")%></asp:Label>
                                                    <span style="color: red">*</span>
                                                </td>
                                                <td valign="top">
                                                    <asp:DropDownList ID="ddlpriority" runat="server" CssClass="normaltext" Width="200px">
                                                    </asp:DropDownList>
                                                    <%--<div style="margin-top: 4px">--%>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_ddlpriority" style="display: none; width: 200px; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Please_Select_Priority")%></span>
                                                        </div>
                                                    </div>
                                                    <%--  </div>--%>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="label" valign="top">
                                                    <div style="float: left">
                                                        &nbsp;<asp:Label ID="lblcontacts" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Contacts")%></asp:Label>
                                                    </div>
                                                    <div style="float: right;">
                                                        <asp:ImageButton Style="vertical-align: middle" ID="ImageButton2" runat="server"
                                                            CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                                    </div>
                                                </td>
                                                <td valign="top" align="left" nowrap="nowrap">
                                                    <input type="text" name="txtcontacttype" maxlength="200" class="txtbox" style="width: 200px"
                                                        id="txtcontacttype" runat="server" readonly="readonly" />
                                                    <div style="margin-bottom: 2px; margin-top: 3px">
                                                        <asp:Label ID="lblcontacterror" CssClass="error" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td class="label" style="width: 20%" nowrap="nowrap">
                                                    <%--class="NewBackgroung"--%>
                                                    <asp:Label ID="lblduedate" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Due_Date_And_Time_hh_mm")%>
                                                    <span class="redver7">*</span></asp:Label>
                                                </td>
                                                <td valign="top" style="width: 38%;" class="normaltext">
                                                    <asp:TextBox ID="txtduedate" runat="server" SkinID="textPad" CssClass="txtbox" Width="82px"> </asp:TextBox>
                                                    &nbsp;&nbsp;<asp:DropDownList ID="ddlhour" runat="server" CssClass="normaltext" Width="50px"
                                                        ToolTip="Hour(s)">
                                                    </asp:DropDownList>
                                                    :
                                                    <asp:DropDownList ID="ddlminute" runat="server" CssClass="normaltext" Width="48px"
                                                        ToolTip="Minute(s)">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:Label ID="lblduedate_value" Visible="false" runat="server" CssClass="normaltext"></asp:Label>
                                                    <%--<div style="margin-top: 5px">--%>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtDueDate" style="display: none; width: 200px; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Date")%></span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <asp:PlaceHolder runat="server" ID="pnlLinkedTo" Visible="true">
                                                <tr>
                                                    <td class="label" valign="top">
                                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Linked To" CssClass="normaltext"></asp:Label>
                                                    </td>
                                                    <td nowrap="nowrap" align="left" colspan="3">
                                                        <asp:DropDownList runat="server" ID="ddllinkedto" CssClass="normaltext" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </asp:PlaceHolder>
                                            <tr valign="top" style="display: none">
                                                <td class="label" valign="top">
                                                    <%--class="NewBackgroung"--%>
                                                    &nbsp;<asp:DropDownList ID="ddltype" runat="server" CssClass="normaltext" Width="120px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td valign="top" align="left">
                                                    <asp:TextBox ID="txttype" runat="server" SkinID="textPad" MaxLength="200" CssClass="txtbox"
                                                        Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton Style="vertical-align: middle"
                                                            ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="../images/plus.gif">
                                                        </asp:ImageButton>
                                                    <div style="margin-top: 4px; margin-bottom: 2px">
                                                        <asp:Label ID="lbltxttypeerror" Text="" CssClass="error" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td width="5%">
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="label" valign="top">
                                                    &nbsp;<asp:Label ID="lblcomment" runat="server" Width="65px" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                </td>
                                                <td class="normaltext" colspan="3">
                                                    <asp:TextBox ID="txtcomment" Rows="8" Width="94%" runat="server" TextMode="MultiLine"
                                                        SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                                                    <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 175px;
                                                        white-space: nowrap">
                                                        <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                </td>
                                                <td class="normaltext" colspan="3" valign="top" visible="false">
                                                    <asp:CheckBox ID="Chkemail" runat="server" Text="Send Notification Email" Visible="false">
                                                    </asp:CheckBox>
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
                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="width: 90%; border: 0px solid">
                                <div style="float: left; width: 50%;">
                                    &nbsp;
                                </div>
                                <div style="float: right; width: 50%;">
                                    <div style="float: right;">
                                        <div align="left">
                                            <div style="float: left;">
                                                <div id="div_btncancel" style="display: block">
                                                    <asp:Button ID="btncancel" runat="server" CausesValidation="False" CssClass="button"
                                                        Text="Cancel" OnClientClick="javscript:loadingimage(this.id,'div_cancelprocess');" />
                                                </div>
                                                <div id="div_cancelprocess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; width: 10px;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left;">
                                                <div id="div_btnsave" style="display: block">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click1"
                                                        OnClientClick="javascript:var a= testdate();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
                                                </div>
                                                <div id="div_saveprocess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:Button ID="btnaddmore" runat="server" Width="120px" CssClass="button" Text="save + AddMore"
                                                    OnClick="btnaddmore_Click1" Visible="false" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
    <div id="div_SubjectTable" style="display: none; position: absolute; vertical-align: middle;
        z-index: 100; width: 35%;" align="center">
        <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Subject"
            Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
            <Windows>
                <telerik:RadWindow ID="cataloguewindow" DestroyOnClose="true" Width="430" Height="150"
                    runat="server">
                    <ContentTemplate>
                        <div class="AddTaskEvent">
                            <table align="center" cellpadding="2" cellspacing="2" border="0" class="TaskEventTable">
                                <tr>
                                    <td valign="top">
                                        <div style="float: left" class="bglabel">
                                            <asp:Label runat="server" ID="lblSubject_popup" CssClass="normaltext" Text=''><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label></div>
                                        <div style="float: left;" class="box">
                                            <asp:TextBox runat="server" ID="txtSubject" SkinID="textPad" Width="200px">
                                            </asp:TextBox>
                                            <span id="spn_txtSubject" class="spanerrorMsg" style="display: none; width: 150px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Subject")%></span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="float: left" class="bglabelEmpty">
                                        </div>
                                        <div style="float: left; display: none">
                                            <asp:Button runat="server" ID="btnCancel_Popup" Text="Cancel" Width="65px" CssClass="button"
                                                OnClientClick="javascript:show_hide_subject('hide');return false;" /></div>
                                        <div style="float: left; width: 5px;">
                                            &nbsp;</div>
                                        <div style="float: left;">
                                            <asp:Button runat="server" ID="btnOK" Text="Save" Width="65px" CssClass="button"
                                                OnClick="btnOK_OnClick" OnClientClick="javascript:return validate();" /></div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;</div>
                                        <div style="float: left">
                                            <asp:Button runat="server" ID="btnDelete" Text="Delete" Width="65px" CssClass="button"
                                                OnClick="btnDelete_OnClick" Visible="false" /></div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <div id="divrad" style="display: none;" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
            Top="30%" Left="150%" OnClientClose="RadWinClose" Behaviors="Close, Move,Reload,Resize"
            ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript">
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

            if (txtduedate.value == '') {
                document.getElementById("spn_txtDueDate").style.display = "block";
                CheckFinal = false;
            }
            else {
                if (ValidateForm(txtduedate, 'spn_txtDueDate', DateFormat) == false) {
                    CheckFinal = false;
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
    </script>
    <script type="text/javascript">
        function ShowPopUp() {
            var oWnd = $find("<%=cataloguewindow.ClientID%>");
            oWnd.show();
        }

        function show_hide_subject(distype) {
            var div_subject = document.getElementById("div_SubjectTable");
            var div_txtsubject = document.getElementById("<%=txtSubject.ClientID%>");
            var ddlsubject = document.getElementById("<%=ddlsubject.ClientID %>");

            div_subject.style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            if (distype == "show") {
                div_txtsubject.value = "";
                showDivPopupCenter('div_SubjectTable', '200');
                div_txtsubject.focus();
                ShowPopUp();
            }
            RadWinClose();
        }

        function deletedisplay() {
            var deleteimage = document.getElementById("<%=ImageButton4.ClientID%>");
            var divdelete = document.getElementById("divdelete");
            var ddlsubject = document.getElementById("<%=ddlsubject.ClientID%>");
            if (ddlsubject.selectedIndex != 0) {
                divdelete.style.display = "block";
            }
            else {
                divdelete.style.display = "none";
            }
        }
        function RadWinClose() {

            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }

        function validate() {
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
        var DateFormat = '<%=DateFormat %>';
    </script>
    <asp:Panel ID="pnlMoreThanOneRecord" Visible="false" runat="server">
        <script type="text/javascript">
            var type;
            type = window.document.forms[0]['ctl00_ContentPlaceHolder1_txtcontacttype'].value;

            var openwin;
            openwin = "morethanonecontact.aspx?nm=" + type;
            window.radopen(openwin, 'Lead', 'width=730,height=610,status=no,scrollbars=yes,resizable=yes,title=yes,location=no,titlebar=no');
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
    <script language="javascript" type="text/javascript">
        function SetFollowupContact(sub) {
            var txtcontacttype = document.getElementById("<%=txtcontacttype.ClientID%>");
            txtcontacttype.value = SpecialDecode(sub);
        }
    </script>
</asp:Content>

