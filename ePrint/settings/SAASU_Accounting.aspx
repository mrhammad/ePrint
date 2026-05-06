<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="SAASU_Accounting.aspx.cs" Inherits="ePrint.settings.SAASU_Accounting" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register src="../usercontrol/settings/settings_mis_headerpanel.ascx" tagname="Header_MIS" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left" id="pnldetails">
        <div align="left">            
            <div class="estore_settingBox">               
               <uc1:Header_MIS ID="header_mis" runat="server" />
<div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="mis_header_panel" style="margin-top:8px">
                    <%--<div>
                        <div class="bglabel" style="width: 10%;">
                            <asp:Label ID="Label1" runat="server" Text="Customer" CssClass="normaltext">
                    <%=objLanguage.GetLanguageConversion("Customer")%></asp:Label>
                        </div>
                        <div style="float: left; padding-left: 3px; width: 80%;">
                            <div style="float: left; padding-left: 3px;">
                                <asp:RadioButton ID="rdoCustomerFrom" runat="server" Onclick="ShowHideDiv(this.id,'divCustomer')"
                                    Text="All Changes since last export" GroupName="RdCustomer" Checked="true" />
                                <asp:RadioButton ID="rdoCustomerAll" runat="server" Onclick="ShowHideDiv(this.id,'divCustomer')"
                                    Text="All" GroupName="RdCustomer" />
                                <asp:RadioButton ID="rdoCustomerByDateRange" runat="server" Onclick="ShowHideDiv(this.id,'divCustomer')"
                                    Text="By Date Range" GroupName="RdCustomer" />
                            </div>
                            <div style="width: 500px; float: left; vertical-align: middle; display: none;" id="divCustomer">
                                &nbsp;&nbsp;&nbsp;
                                <%=objLanguage.GetLanguageConversion("From_Date")%>
                                <asp:TextBox ID="txtCustomerFromDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                <%=objLanguage.GetLanguageConversion("To_Date")%>
                                <asp:TextBox ID="txtCustomerToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_CustomerExport" runat="server" CssClass="button"
                                Text="Export" OnClick="Btn_CustomerExport_Click" OnClientClick="javascript:valideteDateFormat();" />
                        </div>
                    </div>--%>
                  <%--  <div class="only5px">
                    </div>--%>
                    <%--<div>
                        <div class="bglabel" style="width: 10%;">
                            <asp:Label ID="lblSupplier" runat="server" Text="Supplier" CssClass="normaltext">
            <%=objLanguage.GetLanguageConversion("Supplier")%></asp:Label>
                        </div>
                        <div style="float: left; padding-left: 3px; width: 80%;">
                            <div style="float: left; padding-left: 3px;">
                                <asp:RadioButton ID="rdoSupplierFrom" runat="server" Text="All Changes since last export"
                                    GroupName="RdSupplier" Onclick="ShowHideDiv(this.id,'divSupplier')" Checked="true" />
                                <asp:RadioButton ID="rdoSupplierAll" runat="server" Text="All" GroupName="RdSupplier"
                                    Onclick="ShowHideDiv(this.id,'divSupplier')" />
                                <asp:RadioButton ID="rdoSupplierByDateRange" runat="server" Onclick="ShowHideDiv(this.id,'divSupplier')"
                                    Text="By Date Range" GroupName="RdSupplier" />
                            </div>
                            <div style="width: 500px; float: left; vertical-align: middle; display: none;" id="divSupplier">
                                &nbsp;&nbsp;&nbsp;
                                <%=objLanguage.GetLanguageConversion("From_Date")%>
                                <asp:TextBox ID="txtSupplierFromDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                <%=objLanguage.GetLanguageConversion("To_Date")%>
                                <asp:TextBox ID="txtSupplierToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_SupplierExport" runat="server" CssClass="button"
                                Text="Export" OnClick="Btn_SupplierExport_Click" />
                        </div>
                    </div>--%>
                    <%--<div class="only5px">
                    </div>
                    <div class="only5px">
                    </div>--%>
                    <div style="width: 1240px; visibility:hidden;" >
                        <div class="bglabel" style="width: 10%;">
                            <asp:Label ID="lblPurchase" runat="server" Text="Purchase" CssClass="normaltext">
                            <%=objLanguage.GetLanguageConversion("Purchase")%></asp:Label>
                        </div>
                        <div style="float: left; padding-left: 3px;">
                            <table>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <div style="margin-top: 3px; float: left; padding-left: 2px">
                                            <%=objLanguage.GetLanguageConversion("Status") %></div>
                                    </td>
                                    <td style="vertical-align: top; margin-top: 2px; padding-left: 2px;">
                                        <asp:DropDownList ID="ddlPurchaseStatus" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="vertical-align: top; margin-top: -1px;">
                                        <asp:RadioButton ID="rdoPurchaseFrom" runat="server" Onclick="ShowHideDiv(this.id,'divPurchase')"
                                            Text="All Changes since last export" GroupName="RdPurchase" Checked="true" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoPurchaseAll" runat="server" Onclick="ShowHideDiv(this.id,'divPurchase')"
                                            Text="All" GroupName="RdPurchase" />
                                    </td>
                                    <td style="vertical-align: top; margin-top: 1px;">
                                        <asp:RadioButton ID="rdoPurchaseByDateRange" runat="server" Onclick="ShowHideDiv(this.id,'divPurchase')"
                                            Text="By Date Range" GroupName="RdPurchase" />
                                    </td>
                                    <td style="vertical-align: top;">
                                        <div style="float: left; vertical-align: middle; display: none; padding-top: 4px"
                                            id="divPurchase">
                                            &nbsp;&nbsp;
                                            <%=objLanguage.GetLanguageConversion("From_Date")%>
                                            <asp:TextBox ID="txtPurchaseFromDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                            <%=objLanguage.GetLanguageConversion("To_Date")%>
                                            <asp:TextBox ID="txtPurchaseToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="vertical-align: top;">
                                        <div style="float: left; padding-left: 4px;">
                                            <asp:Button ID="Btn_PurchaseExport" runat="server" CssClass="button" Text="Export"
                                                />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <%--SAASU Invoice--%>
                    <div>
                        <div class="bglabel" style="width: 10%;">
                            <asp:Label ID="lblInvoice" runat="server" Text="Invoice" CssClass="normaltext">
                <%=objLanguage.GetLanguageConversion("Invoice")%></asp:Label>
                        </div>

                        <div style="float: left; padding-left: 3px;">
                            <table>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <div style="margin-top: 3px; float: left; padding-left: 2px">
                                            <%=objLanguage.GetLanguageConversion("Status") %></div>
                                    </td>
                                    <td style="vertical-align: top; margin-top: 2px; padding-left: 2px">
                                        <asp:DropDownList ID="ddlInvStatus" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
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
                        <%=objLanguage.GetLanguageConversion("SAASU_Accounting_Note")%></asp:Label>
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
    <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Reset" OnClick="btnReset_Click" />
    <script language="javascript" type="text/javascript">
        function ShowHideDiv(rdoID, divID) {
            debugger
            var divControl = document.getElementById(divID);
            if (divID == 'divPurchase') {
                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';
                }
                else {
                    divControl.style.display = 'none';
                }
            }
            else if (divID == 'divInvoice') {
                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';
                }
                else {
                    divControl.style.display = 'none';
                }
            }
            else if (divID == 'divSupplier') {
                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';

                } else {
                    divControl.style.display = 'none';
                }
            }
            else if (divID == 'divCustomer') {

                if (rdoID.indexOf('Date') != -1) {
                    divControl.style.display = 'block';

                } else {
                    divControl.style.display = 'none';

                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
