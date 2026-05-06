<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/SettingsEstore.master" CodeBehind="eStoreCredit.aspx.cs" Inherits="ePrint.StoreSettings.eStoreCredit" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

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
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="div1" runat="server">
                        <table width="100%" class="PrilivegeTab" style="padding-top: 8px;">
                            <tr>
                                <td width="2%">
                                    <asp:CheckBox ID="chkSpendLimit" runat="server" onclick="EnableDisable()" />
                                </td>
                                <td>
                                    <asp:Label ID="lblspendlimit" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                      <%--  <table width="100%" style="padding-bottom: 6px; margin-top: -5px; margin-left: 20px;">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoPerUser1" runat="server" GroupName="spendlimit" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoPerdept" runat="server" GroupName="spendlimit" />
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                </div>
                <div style="clear: both; padding-top: 10px">
                </div>
                <div style="padding-left: 24px">
                    <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
                        OnClientClick="javascript:loadingimage(this.id,'div_btnsaveprocess');"  Text="Save" />
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

