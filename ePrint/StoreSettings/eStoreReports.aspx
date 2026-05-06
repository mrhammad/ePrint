<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="eStoreReports.aspx.cs" Inherits="ePrint.StoreSettings.eStoreReports" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath%>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath%>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript" language="javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath%>js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
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
                                        <%=objLanguage.GetLanguageConversion("eStore_Settings") %>
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="padding: 0px 10px 10px 10px">
                <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="background-repeat: repeat-x; width: 58%;">
                    <div style="padding: 10px;">
                        <table>
                            <tr>
                                <td colspan="3">
                                    <asp:CheckBox ID="chkEnableReports" runat="server" onclick="javascript:EnableDisablerdo();" />
                                </td>
                            </tr>
                        </table>
                        <table style="margin-left: 20px;">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoMainApprover" runat="server" GroupName="rdoReports" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoMainDeptApprover" runat="server" GroupName="rdoReports" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoAllUsers" runat="server" GroupName="rdoReports" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <div id="div_btnsave" style="display: block; margin-left: 0px;">
                                        <asp:Button ID="btnSave" runat="server" CssClass="button" OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_btnsaveprocess'); return a;"
                                            OnClick="btnSave_Click" />
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none; margin-left: 0px;">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table style="margin-left: 3px">
                            <tr>
                                <td colspan="3">
                                    <span class="smallerfontgrey">
                                        <br />
                                        Note: Please note if you choose to enable reports for all users they will see all
                                        the data in the reports for all departments.<br />
                                        <span style="margin-left: 27px">The system will limit the data in the report to only
                                            be for the customer based on their login credentials.</span>
                                        <br />
                                        <span style="margin-left: 27px">When you view the reports from ePrint MIS you will see
                                            the data for all customers.</span> </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            var AccountID = '<%=AccountID %>';
            var chkEnableReports = document.getElementById("<%=chkEnableReports.ClientID%>");
            var rdoMainApprover = document.getElementById("<%=rdoMainApprover.ClientID%>");
            var rdoMainDeptApprover = document.getElementById("<%=rdoMainDeptApprover.ClientID%>");
            var rdoAllUsers = document.getElementById("<%=rdoAllUsers.ClientID%>");

            function EnableDisablerdo() {
                if (chkEnableReports.checked) {
                    rdoMainApprover.disabled = false;
                    rdoMainDeptApprover.disabled = false;
                    rdoAllUsers.disabled = false;
                    rdoMainApprover.checked = true;
                }
                else {
                    rdoMainApprover.disabled = true;
                    rdoMainDeptApprover.disabled = true;
                    rdoAllUsers.disabled = true;
                }
            }

            function EnableDisableOnLoad() {
                if (chkEnableReports.checked) {
                    rdoMainApprover.disabled = false;
                    rdoMainDeptApprover.disabled = false;
                    rdoAllUsers.disabled = false;
                }
                else {
                    rdoMainApprover.disabled = true;
                    rdoMainDeptApprover.disabled = true;
                    rdoAllUsers.disabled = true;
                }
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
