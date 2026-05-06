<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload_PreFlightProfile.aspx.cs" Inherits="ePrint.settings.Upload_PreFlightProfile"  masterpagefile="~/Templates/settingpage.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left">
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
        </div>
        </div>
        <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red; margin-top:40px">
            <div style="width: 60%; margin: 5px 0px 0px 5px">
                <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div style="width: 100%; margin-top: -3px;">
            <div>
                <div class="bgLabel" style="width: 12%; margin-top: 10px">
                    <asp:Label ID="lblUpload" runat="server"></asp:Label>
                    <span style="color: Red">*</span>
                    <img src="../images/Help-icon.png" alt="Help-icon.png" title="Only .ppp file allowed"
                        class="tooltip" style="float: right; cursor: pointer; width: 16px; height: 16px;
                        margin: 0px 0px 0px 0px; border: solid 0px green;" />
                </div>
                <div class="box" style="width: 12%; margin-top: 10px">
                    <asp:FileUpload ID="fuPreFlightProfile" runat="server" />
                    <span id="spnMandatory" class="spanerrorMsg" style="display: none; width: 247px;
                        padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Preflight_Profile_Select_Error")%></span>
                        <span id="spnExtension" class="spanerrorMsg" style="display: none;
                            width: 137px; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Preflight_Profile_Extension_Error")%></span>
                </div>
                <div class="bgLabel" style="width: 12%; margin-top: 10px; background-color: #fff">
                    &nbsp;
                </div>
                <div class="box" style="width: 12%; margin-top: 10px">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="NewButton" OnClick="btnUpload_Click" OnClientClick="javascript:var a=validateProfile();if(a) loadingimage(this.id,'div_btnUploadprocess');return a"/>
                    <div id="div_btnUploadprocess" class="button" align="center" style="width: 37px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                </div>
            </div>
        </div>
    <script type="text/javascript">
        var fuPreFlightProfile = document.getElementById("<%=fuPreFlightProfile.ClientID %>");
        function validateProfile() {
            if (fuPreFlightProfile.value != "") {
                document.getElementById("spnMandatory").style.display = "none";
                var checkExtension = fuPreFlightProfile.value.split('.');
                if (checkExtension[checkExtension.length - 1].toLowerCase() == "ppp") {
                    
                    return true;
                }
                else {
                    document.getElementById("spnExtension").style.display = "block";
                    return false;
                }
            }
            else {
                document.getElementById("spnMandatory").style.display = "block";
                document.getElementById("spnExtension").style.display = "none";
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
