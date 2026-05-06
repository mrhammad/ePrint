<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="LogoutSettings.aspx.cs" Inherits="ePrint.StoreSettings.LogoutSettings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

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
                                        <%=objLanguage.GetLanguageConversion("eStore_Settings") %>:&nbsp;<%=objLanguage.GetLanguageConversion("LogoutSettings")%>&nbsp;
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
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="background-repeat: repeat-x; width: 58%; overflow: auto;">
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
                        <table width="100%" class="PrilivegeTab" style="padding-top: 1px;">
                            <tr>
                                <td style="font-weight: bold; padding-left: 5px;" class="style10">
                                    Login
                                </td>
                            </tr>
                        </table>
                        <table width="100%" class="PrilivegeTab" style="padding-top: 8px;">
                            <tr>
                                <td width="3%">
                                    <asp:CheckBox ID="chkloginoption" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lbllogoutoption" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblnote" CssClass="smallgraytext" Style="padding-left: 27px;" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" class="PrilivegeTab" style="padding-top: 15px;">
                            <tr>
                                <td style="font-weight: bold; padding-left: 5px;" class="style10">
                                    Logout
                                </td>
                            </tr>
                        </table>
                        <table width="100%" style="padding-bottom: 6px; margin-top: -5px;">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdologout" runat="server" GroupName="RegDept" onclick="EnableDisable()" />
                                    <asp:Label ID="lbllogin" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdocustomlogout" runat="server" GroupName="RegDept" onclick="EnableDisable()" />
                                    <asp:Label ID="lblCustomUrl" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 27px;">
                                    <asp:TextBox ID="txtCustomURL" runat="server" Width="230px" Style="font-family: Verdana,Arial,sans-serif;
                                        font-size: 11px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 27px;">
                                    <asp:Label ID="lbllogutmsg" CssClass="smallgraytext" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="clear: both; padding-top: 10px">
                </div>
                <div id="div_save" style="padding-left: 24px">
                    <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
                        OnClientClick="javascript:var a=validate_Account();if(a)loadingimg(this.id,'div_btnsaveProcess'); return a;" Text="Save" />
                </div>
                 <div id="div_btnsaveProcess" class="button" style="height: 14px; width: 28px;float:left; margin-left:24px; margin-bottom:10px; display: none">
                     <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                 </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function EnableDisable() {

            var rdocustomlogout = document.getElementById("<%=rdocustomlogout.ClientID %>");
            var rdologout = document.getElementById("<%=rdologout.ClientID %>");
            var txtCustomURL = document.getElementById("<%=txtCustomURL.ClientID %>");

            if (rdocustomlogout.checked) {
                txtCustomURL.disabled = false;
            }
            else {
                txtCustomURL.disabled = true;
                txtCustomURL.value = '';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

