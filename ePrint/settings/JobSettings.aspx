<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="JobSettings.aspx.cs" Inherits="ePrint.settings.JobSettings" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px" class="mis_header_panel">
            <div id="">
                <div class="divpadding" style="width: 200px;">
                                <span class="normaltext"><b>Enable/Disable Job Date's</b></span>
                            </div>
                        <div id="divartwork" runat="server" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Estimated_ArtWork")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkJobArtwork" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');" runat="server" />
                            </div>
                         </div>

                         <div id="divproof" runat="server" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Estimated_Proof")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkJobProof" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');" runat="server" />
                            </div>
                         </div>

                         <div id="divapproval" runat="server" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Estimated_Approval")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkJobApproval" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');" runat="server" />
                            </div>
                         </div>

                         <div id="divproduction" runat="server" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Estimated_Production")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkJobProduction" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');" runat="server" />
                            </div>
                         </div>


                        <div id="divdisplayjobs" runat="server" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Display_100_Jobs_on_Job_Page")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkDisplayJobs" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');" runat="server" />
                            </div>
                         </div>
                         <div align="left">
                        <div class="bglabelEmpty">
                        </div>
                        <div class="DefaultSettingsbox">
                            <div style="float: left;">
                                <div id="div_btnsave" style="display: block; margin-top: -1px;">
                                    <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                                        OnClick="btnSave_OnClick" OnClientClick="if(Page_ClientValidate()){javascript:loadingimage(this.id,'div_btnsaveprocess');}else{return false;}" />
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                         
                        
            </div>

        </div>
         
        <div style="clear: both;">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
