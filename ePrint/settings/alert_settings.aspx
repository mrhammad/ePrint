<%@ page title="" language="C#" masterpagefile="~/Templates/UserEditProfile.master" autoeventwireup="true" CodeBehind="alert_settings.aspx.cs" Inherits="ePrint.settings.alert_settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_navigator" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblheader" runat="server"><%=objlang.GetLanguageConversion("Settings")%>: <%=objlang.GetLanguageConversion("Alert_Settings")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div>
            <div align="left" style="width: 100%;margin-top:8px" class="mis_header_panel">
                <div id="" style="height: 268px; margin-top: -5px;">
                    <div align="left" style="width: 100%; padding-bottom: 0px">
                        <div id="DivMessage" style="width: 60%">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -5px;">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkswitchonAlertsetting" runat="server" onclick="javascript:openalertsettings();" />
                            </td>
                            <td>
                                <div style="margin-top: -5px; margin-left: 4px;">
                                    <asp:Label ID="lblalert" runat="server" CssClass="cells1" Text="Switch on Tasks/Calls Alerts"
                                        Style="font-weight: bold;"><%=objlang.GetLanguageConversion("Switch_on_TasksCallsAlerts")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="display: none; margin-top: 16px; margin-left: 4px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="430px" style="vertical-align: top;">
                            <tr>
                                <td style="width: 150px; font-weight: bold;">
                                    <asp:Label ID="lblAlertType" runat="server" Text="Alert Type"> <%=objlang.GetLanguageConversion("Alert_Type")%></asp:Label>
                                </td>
                                <td style="width: 150px; font-weight: bold;">
                                    <div style="margin-left: 8px;">
                                        <asp:Label ID="lblMinuteBefore" runat="server" Text="Minutes Before"><%=objlang.GetLanguageConversion("Minutes_Before")%></asp:Label>
                                    </div>
                                </td>
                                <td style="width: 150px; font-weight: bold;">
                                    <asp:Label ID="lblAlertOn" runat="server" Text="Alert On"><%=objlang.GetLanguageConversion("Alert_On")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="lbltaskalert" runat="server" Text="Alert On"><%=objlang.GetLanguageConversion("Tasks_Alert")%></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 8px;">
                                        <asp:DropDownList ID="ddltaskminute" runat="server" CssClass="normalText" Width="120px">
                                            <%-- <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>--%>
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddltaskAlertOn" runat="server" CssClass="normalText" Width="120px">
                                        <asp:ListItem Text="Screen" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td style="width: 150px;">
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="lblEventAlert" runat="server" Text="Alert On"><%=objlang.GetLanguageConversion("Events_Alert")%></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 8px;">
                                        <asp:DropDownList ID="ddleventalert" runat="server" CssClass="normalText" Width="120px">
                                            <%--  <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>--%>
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEventAlerton" runat="server" CssClass="normalText" Width="120px">
                                        <asp:ListItem Text="Screen" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 160px;">
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="lblCallAlerts" runat="server" Text="Alert On"><%=objlang.GetLanguageConversion("Calls_Alert")%></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 8px;">
                                        <asp:DropDownList ID="ddlcallalert" runat="server" CssClass="normalText" Width="120px">
                                            <%-- <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>--%>
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCallalertOn" runat="server" CssClass="normalText" Width="120px">
                                        <asp:ListItem Text="Screen" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="416px" style="margin-top: 18px;
                            margin-bottom: 10px;">
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                    <div style="float: right;">
                                        <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                                            OnClick="btncancel_Click"></asp:Button>&nbsp;&nbsp;
                                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                            OnClick="btnSave_OnClick"></asp:Button>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="DivAlertSettings" runat="server" style="margin-top: 12px; margin-left: 16px;">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkTaskScreenMinute" runat="server" />
                                </td>
                                <td>
                                    <div style="margin-left: 1px; margin-top: 2px;">
                                       <%=objlang.GetLanguageConversion("Show_on_Screen_alert")%>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 4px; margin-top: -7px;">
                                        <asp:DropDownList ID="ddlTaskScreenMinute" runat="server" CssClass="normalText" Width="65px">
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 3px; margin-top: 3px;">
                                       <%=objlang.GetLanguageConversion("minute_before_the_Tasks_DueDateTime")%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 8px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkCallScreenMinute" runat="server" />
                                </td>
                                <td>
                                    <div style="margin-left: 1px; margin-top: 2px;">
                                        <%=objlang.GetLanguageConversion("Show_on_Screen_alert")%>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 4px; margin-top: -7px;">
                                        <asp:DropDownList ID="ddlCallScreenMinute" runat="server" CssClass="normalText" Width="65px">
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 3px; margin-top: 3px;">
                                        <%=objlang.GetLanguageConversion("minute_before_the_Call_DueDateTime")%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 8px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkTaskSendMinute" runat="server" />
                                </td>
                                <td>
                                    <div style="margin-left: 1px; margin-top: 2px;">
                                        <%=objlang.GetLanguageConversion("Send_Email_Notification")%>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 4px; margin-top: -7px;">
                                        <asp:DropDownList ID="ddlTaskSendMinute" runat="server" CssClass="normalText" Width="65px">
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 3px; margin-top: 3px;">
                                        <%=objlang.GetLanguageConversion("minute_before_the_Tasks_DueDateTime")%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 8px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkCallSendMinute" runat="server" />
                                </td>
                                <td>
                                    <div style="margin-left: 1px; margin-top: 2px;">
                                        <%=objlang.GetLanguageConversion("Send_Email_Notification")%>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 4px; margin-top: -7px;">
                                        <asp:DropDownList ID="ddlCallSendMinute" runat="server" CssClass="normalText" Width="65px">
                                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="60" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="90" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="120" Value="9"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 3px; margin-top: 3px;">
                                        <%=objlang.GetLanguageConversion("minute_before_the_Call_DueDateTime")%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 8px;">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table id="divbuttons" border="0" cellpadding="0" cellspacing="0" width="416px" style="margin-top: 18px;
                        margin-bottom: 10px; margin-left: 20px;">
                        <tr>
                            <td  >
                            </td>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" >
                                           <div id="div_btnCancelSetting">
                                                <asp:Button ID="btnCancelSetting" runat="server" CssClass="button" Text="Cancel"
                                                    CausesValidation="False" OnClick="btncancel_Click" OnClientClick="loadingimg('div_btnCancelSetting','div_btnCancelprocess');"></asp:Button>
                                            </div>
                                            <div id="div_btnCancelprocess" class="button" align="center" style="height: 14px; width: 37px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td>
                                            <div id="div_SaveSetting" style="margin-left: 7px;">
                                                <asp:Button ID="btnSaveSetting" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                                    OnClick="btnSave_OnClick" OnClientClick="javascript:chksavevalidations(); return false;">
                                                </asp:Button>
                                            </div>
                                            <div id="div_btnSaveSettingProcess" class="button" align="center" style="height: 14px; width: 28px; margin-left:8px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                        <td>
                                            <div id="div_updateSetting" style="margin-left: 5px;">
                                                <asp:Button ID="btnupdateSetting" runat="server" CssClass="button" Text="Update" OnClientClick="javascript:loadingimg(this.id,'div_btnUpdateSettingProcess')"
                                                    CausesValidation="False" OnClick="btnupdateSetting_OnClick" Style="display: none;"></asp:Button>
                                            </div>
                                             <div id="div_btnUpdateSettingProcess" class="button" align="center" style="height: 14px; width: 38px; margin-left:6px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        window.setTimeout(function () {
            var DivNotesMessage = document.getElementById('DivMessage');

            if (DivNotesMessage != null) {
                DivNotesMessage.style.display = 'none';
            }
        }, 9000);

        function openalertsettings() {
            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_chkTaskScreenMinute");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_chkCallScreenMinute");
            var chk3 = document.getElementById("ctl00_ContentPlaceHolder1_chkTaskSendMinute");
            var chk4 = document.getElementById("ctl00_ContentPlaceHolder1_chkCallSendMinute");

            var chkbox = document.getElementById("ctl00_ContentPlaceHolder1_chkswitchonAlertsetting");
            if (chkbox.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_DivAlertSettings").style.display = "block";
                document.getElementById("divbuttons").style.marginLeft = "172px";

                chk1.checked = false
                chk2.checked = false
                chk3.checked = false
                chk4.checked = false

            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_DivAlertSettings").style.display = "none";
                chk1.checked = false
                chk2.checked = false
                chk3.checked = false
                chk4.checked = false
                document.getElementById("divbuttons").style.marginLeft = "20px";
            }
        }

        function chksavevalidations() {
            var chkmain = document.getElementById("ctl00_ContentPlaceHolder1_chkswitchonAlertsetting");
            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_chkTaskScreenMinute");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_chkCallScreenMinute");
            var chk3 = document.getElementById("ctl00_ContentPlaceHolder1_chkTaskSendMinute");
            var chk4 = document.getElementById("ctl00_ContentPlaceHolder1_chkCallSendMinute");
            if (chkmain.checked == true) {

                if (chk1.checked == false && chk2.checked == false && chk3.checked == false && chk4.checked == false) {
                    alert("Please select at least one tickbox to process");
                    return true;
                }
                else {
                    __doPostBack('ctl00$ContentPlaceHolder1$btnSaveSetting', '');
                    document.getElementById('div_SaveSetting').style.display = "none";
                    document.getElementById('div_btnSaveSettingProcess').style.display = "block";
                }

            }
            else {
                alert("Please Switch on Tasks/Calls Alerts");
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
