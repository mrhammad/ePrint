<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="ePrint.StoreSettings.TermsAndConditions"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Terms_And_Conditions")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div>
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%; padding: 10px 0px 0px 10px;">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <table style="padding-left: 10px;">
                    <tr>
                        <td style="width: 235px; vertical-align: top">
                            <%--  <div style="padding-left: 5px; padding-top: 5px">
                                <div>--%>
                            <div class="bglabel" style="width: 80%;">
                                <asp:Label ID="lblterms" runat="server" Text="Enable Terms and Conditions" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Enable_Terms_And_Conditions")%></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div style="float: left; padding-left: 5px;">
                                <asp:CheckBox ID="chk_isterms" runat="server" Checked="false" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 235px; vertical-align: top">
                            <div class="bglabel" style="width: 80%;">
                                <asp:Label ID="lbltermscondition" runat="server" Text="Enable Terms and Conditions"
                                    CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Terms_And_Conditions")%></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div style="float: left; width: 60%; margin-left: 9px;">
                                <telerik:RadEditor ID="Radeditor" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                    ImageManager-ViewMode="Grid" ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute"
                                    ContentAreaMode="Iframe">
                                    <Content>
                                                                          
                                    </Content>
                                </telerik:RadEditor>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <div style="clear: both;">
                            </div>
                            <div style="margin-left: 8px;">
                                <div style="float: left; width: 450px; padding: 5px 0px 10px 0px;" class="box">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" OnClick="btn_Save_Onclick"
                                            OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_btnsaveprocess'); return a;" />
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>--%>

