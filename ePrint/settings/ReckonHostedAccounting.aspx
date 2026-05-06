<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="ReckonHostedAccounting.aspx.cs" Inherits="ePrint.settings.ReckonHostedAccounting" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left" id="pnldetails">
        <div align="left">
            <%--<div style="width: 100%;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Settings_MYOB_Accounting")%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>--%>
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
                            <asp:Label ID="lblInvoice" runat="server" Text="Invoice" CssClass="normaltext">
<%=objLanguage.GetLanguageConversion("Invoice")%></asp:Label>
                        </div>
                        <div style="float: left; padding-left: 3px;">
                            <table>
                                <tr>
                                   
                                    <td style="vertical-align: top; margin-top: -1px;">
                                        <asp:RadioButton ID="rdoInvoiceFrom" runat="server" Onclick="ShowHideDiv(this.id,'divInvoice')"
                                            Text="All Changes since last export" GroupName="RdInvoice" Checked="true" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoInvoiceAll" runat="server" Text="All" Onclick="ShowHideDiv(this.id,'divInvoice')"
                                            GroupName="RdInvoice" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoInvoiceByDateRange" runat="server" Onclick="ShowHideDiv(this.id,'divInvoice')"
                                            Text="By Date Range" GroupName="RdInvoice" />
                                    </td>
                                    <td style="vertical-align: top;">
                                        <div style="float: left; vertical-align: middle; display: none; padding-top: 4px"
                                            id="divInvoice">
                                            &nbsp;&nbsp;
                                            <%=objLanguage.GetLanguageConversion("From_Date")%>
                                            <asp:TextBox ID="txInvoiceFromDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                            <%=objLanguage.GetLanguageConversion("To_Date")%>
                                            <asp:TextBox ID="txInvoiceToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="vertical-align: top">
                                        <div style="float: left; padding-left: 4px;">
                                            <asp:Button ID="btn_InvoiceExport" runat="server" CssClass="button" Text="Export"
                                                OnClick="btn_InvoiceExport_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="float: left; padding-left: 3px;">
                        <asp:Label ID="Lbl_Note" runat="server" CssClass="smallgraytext">
Note: Please always export customer and supplier data before exporting invoices.</asp:Label>
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--    <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Reset" OnClick="btnReset_Click" />--%>
    <script language="javascript" type="text/javascript">
        function ShowHideDiv(rdoID, divID) {
            var divControl = document.getElementById(divID);
            if (divID == 'divInvoice') {
                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';
                }
                else {
                    divControl.style.display = 'none';
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
