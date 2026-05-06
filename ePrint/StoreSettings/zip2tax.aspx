<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/SettingsEstore.master" CodeBehind="zip2tax.aspx.cs" Inherits="ePrint.StoreSettings.zip2tax" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath%>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath%>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript" language="javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath%>js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <script type="text/javascript">
        function enablePasswordFields() {
            debugger
            document.getElementById('<%=txtPassword.ClientID%>').disabled = false;
            document.getElementById('<%=hidTextBoxEnabled.ClientID%>').value = 'true';
        }
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
                                       Store Credit;
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
                <div style="background-repeat: repeat-x; width: 58%;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="width: 663px;">
                                    <table cellpadding="3" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-top: 1px;">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; text-align: left; padding-top: 10px;">Enter your Zip2Tax details below</td>

                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="bglabel">
                        <asp:Label ID="lblUserName" runat="server" Text="UserName" CssClass="normalText"></asp:Label><span style="color: Red"> *</span>

                    </div><div class="box">
                        <asp:TextBox runat="server" ID="txtUserName" SkinID="textPad" MaxLength="50" onBlur="Validatecmpnyname();"></asp:TextBox>
                        <span id="spn_UserName" class="spanerrorMsg" style="display: none; width: 178px;">
                            <asp:Label ID="lbl1" runat="server"></asp:Label></span></div>
                    <div class="bglabel">
                        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="normalText"></asp:Label><span style="color: Red"> *</span>

                    </div><div class="box">
                        <asp:TextBox runat="server" ID="txtPassword" SkinID="textPad" MaxLength="50" TextMode="Password" onBlur="Validatecmpnyname();" Enabled="false"></asp:TextBox>
                        <span id="spn_Password" class="spanerrorMsg" style="display: none; width: 178px;">
                            <asp:HiddenField runat="server" ID="hidTextBoxEnabled" />
                            <asp:Label ID="lbl2" runat="server"></asp:Label></span></div>
                    <div id="divLnkChangePassword" class="box" style=" display:block;width: 75%; height: 25px;">
                                <a id="lnkChangePassword" href="#" onclick="return enablePasswordFields();"
                                    style="font-weight: bold; text-decoration: underline" >Change Password</a>
                            </div>
                    <div id="div1" runat="server">
                        <table width="100%" class="PrilivegeTab" style="padding-top: 8px;">
                            <tr>
                                <td width="2%">
                                    <asp:CheckBox ID="chkzip2tax" runat="server" onclick="EnableDisable()" />
                                </td>
                                <td>
                                    <asp:Label ID="lblzip2taxcheck" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="clear: both; padding-top: 10px">
                </div>
                <div class="box" style="width: 450px">
                <div style="padding-left: 24px">
                    <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
                        OnClientClick="javascript:loadingimage(this.id,'div_btnsaveprocess');"  Text="Save" />
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                    <div style="float: left;">
                                    <div id="div_btnCancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                        </telerik:RadButton>
                                    </div>
                                    <div id="div_btncancelprocess" class="button" align="center" style="height: 14px; width: 43px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                    <div style="clear: both; padding-top: 10px">
                </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

