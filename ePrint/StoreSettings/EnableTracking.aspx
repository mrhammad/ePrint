<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="EnableTracking.aspx.cs" Inherits="ePrint.StoreSettings.EnableTracking" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%--<%@ Register Src="~/usercontrol/StoreSettings/Logout_Settings.ascx" TagName="RegistrationOption"
    TagPrefix="UC" %>--%>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath%>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath%>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript" language="javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath%>js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script>
        var AccountID = '<%=AccountID %>';
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
                                        <%=objLanguage.GetLanguageConversion("eStore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("TrackingSettings")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Change")%></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="padding: 20px 20px 20px 20px">
                <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="background-repeat: repeat-x; width: 70%; overflow: auto;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="width: 663px;">
                                    <table cellpadding="3" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-top: 1px;">
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="div1" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chksecurity" runat="server" onclick="EnableDisable()" />
                                </td>
                                <td>
                                    <asp:Label ID="lbllogoutoption" CssClass="OrderMngrHeader" runat="server" Text="Requires password to complete the order">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" style="padding-top: 5px;">
                            <tr>
                                <td style="padding-left: 22px;">
                                    <asp:Label ID="lblpwd" runat="server" Text="Password">
                                    </asp:Label><td style="padding-left: 5px;">
                                        <asp:TextBox ID="txtsecurity" TextMode="Password" runat="server" Width="180px" Style="font-family: Verdana,Arial,sans-serif;
                                            font-size: 11px;" CssClass="textboxnew"></asp:TextBox>
                                    </td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="clear: both; padding-top: 10px">
                </div>
                <div id="div_btnSaveSettings" style="padding-left: 24px">
                    <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
                        OnClientClick="javascript:var a=validate_Account(); if(a)loadingimg('div_btnSaveSettings','div_btnSaveSettingsProcess'); return a" Text="Save" />
                </div>
                <div id="div_btnSaveSettingsProcess" class="button" style="height: 14px; width: 29px;float:left; margin-left:23px; margin-bottom:15px; display: none">
                     <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                 </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function EnableDisable() {

            var chksecurity = document.getElementById("<%=chksecurity.ClientID %>");

            var txtsecurity = document.getElementById("<%=txtsecurity.ClientID %>");

            if (chksecurity.checked) {
                txtsecurity.disabled = false;
            }
            else {
                txtsecurity.disabled = true;
                txtsecurity.value = '';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
