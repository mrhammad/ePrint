<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreFlight_Options.aspx.cs" Inherits="ePrint.settings.PreFlight_Options" masterpagefile="~/Templates/settingpage.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left">
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
            <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <contenttemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="width: 100%; margin-top: -3px;">
                    <div style="padding: 10px;">
                        <table style="vertical-align: middle">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkEnable" runat="server" />
                                </td>
                                <td>
                                    <span>Enable</span>
                                </td>
                            </tr>
                        </table>
                        <table style="vertical-align: middle; margin-left: 24px;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblDefaultProfile" runat="server" Text="Default Profile"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProfiles" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            </table>
                            <table>
                            <tr>
                                <td>
                                <div style="margin-top:14px;margin-left:4px;">
                                    <div id="div_btnSave" style="display: block">
                                       <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click" OnClientClick="var a=validateProfile();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;"/> 
                                    </div>
                                    <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        var chkEnable = document.getElementById("<%=chkEnable.ClientID %>");
        var ddlProfiles = document.getElementById("<%=ddlProfiles.ClientID %>");

        function EnableDisableDdl() {
            if (chkEnable.checked) {
                ddlProfiles.disabled = false;
            }
            else {
                ddlProfiles.disabled = true;
            }
            return false;
        }

        function validateProfile() {
            if (ddlProfiles.selectedIndex == 0 && chkEnable.checked) {
                alert("Please select profile");
                ddlProfiles.focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

