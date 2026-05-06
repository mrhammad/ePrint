<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Navision_export.aspx.cs" Inherits="ePrint.settings.Navision_export" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left" id="pnldetails">
        <div align="left">
            <div class="estore_settingBox">
                <UC:Header_MIS ID="header_mis" runat="server" />
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="mis_header_panel" style="margin-top: 8px">
                    <div>
                        <div class="bglabel" style="width: 10%;">
                            <asp:Label ID="lblJob" runat="server" Text="Job" CssClass="normaltext">
                        <%=objLanguage.GetLanguageConversion("Job")%></asp:Label>
                        </div>
                        <div style="float: left; padding-left: 3px;">
                            <table>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <div style="margin-top: 3px; float: left; padding-left: 2px">
                                            <%=objLanguage.GetLanguageConversion("Status") %></div>
                                    </td>
                                    <td style="vertical-align: top; margin-top: 2px; padding-left: 2px">
                                        <asp:DropDownList ID="ddlJobStatus" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="vertical-align: top; margin-top: -1px;">
                                        <asp:RadioButton ID="rdoJobFrom" runat="server" Onclick="ShowHideDiv(this.id,'divJob')"
                                            Text="All Changes since last export" GroupName="RdJob" Checked="true" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoJobAll" runat="server" Text="All" Onclick="ShowHideDiv(this.id,'divJob')"
                                            GroupName="RdJob" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoJobByDateRange" runat="server" Onclick="ShowHideDiv(this.id,'divJob')"
                                            Text="By Date Range" GroupName="RdJob" />
                                    </td>
                                    <td style="vertical-align: top;">
                                        <div style="float: left; vertical-align: middle; display: none; padding-top: 4px"
                                            id="divJob">
                                            &nbsp;&nbsp;
                                            <%=objLanguage.GetLanguageConversion("From_Date")%>
                                            <asp:TextBox ID="txJobFromDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                            <%=objLanguage.GetLanguageConversion("To_Date")%>
                                            <asp:TextBox ID="txJobToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="vertical-align: top">
                                        <div style="float: left; padding-left: 4px;">
                                            <asp:Button ID="btn_JobExport" runat="server" CssClass="button" Text="Export" OnClick="btn_JobExport_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Reset" OnClick="btnReset_Click" />
    <script language="javascript" type="text/javascript">
        function ShowHideDiv(rdoID, divID) {
            var divControl = document.getElementById(divID);

            if (divID == 'divJob') {
                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';
                }
                else {
                    divControl.style.display = 'none';
                }
            }
        }           
    </script>
    <div class="only5px">
    </div>
</asp:Content>
