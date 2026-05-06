<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="inventorystockreduction.aspx.cs" Inherits="ePrint.settings.inventorystockreduction" title="Settings: Stock Reduction" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>: <%=objLanguage.GetLanguageConversion("Stock_Reduction")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div style="width: 100%;" class="mis_header_panel" >
                <div id="">
                    <div align="left" style="padding-bottom: 5px; width: 100%">
                        <div style="width: 65%">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div align="left" style="width: 100%; margin-top: -5px;">
                        <div class="bglabel" style="width: 20%; height: 150px">
                            <span>
                                <%=objLanguage.GetLanguageConversion("Reduce_The_Stock_When")%></span></div>
                        <div style="float: left; width: 75%; margin-left: 3px">
                            <asp:RadioButton ID="rdoEstimate" runat="server" Text="An Estimate is progressed to a Job"
                                onclick="javascript:rdoReduceStock_checked('e');" Checked="false" Style="display: none;" /><br />
                            <asp:RadioButton ID="rdoJob" runat="server" Text="When Job Status is changed to"
                                onclick="javascript:rdoReduceStock_checked('j');" Checked="true"/><br />
                            <div align="left" style="width: 100%; display: block; margin-left: 2%;" id="div_jobStatus"
                                runat="server">
                                <div class="ddlsetting" style="width: 60%">
                                    <asp:DropDownList ID="ddlJobStatus" runat="server" CausesValidation="false" CssClass="normalText"
                                        Width="183px" onblur="javascript:btnSave_OnClientClick();">
                                    </asp:DropDownList>
                                    <div style="clear: both">
                                    </div>
                                    <div id="spn_ddlJobStatus" style="display: none; float: left; vertical-align: top;
                                        padding-left: 183px; margin-top: -14px; margin-bottom: -2px">
                                        <div class="RFV_Message" style="vertical-align: top; position: absolute; margin-top: -5px;
                                            width: 183px;">
                                            <span style="float: left; padding-left: 4px">
                                                <%=objLanguage.GetLanguageConversion("Please_select_Job_Status")%></span>
                                        </div>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <span class="smallgraytext">Note1: Stock will be Reduced only first time when that Job
                                        status is matched with "Stock Reduction" status</span>
                                    <br />
                                    <span class="smallgraytext">Note2: Prompt will appear for Direct Invoice when below
                                        process starts to decide stock to be reduce or not</span>
                                    <br />
                                    <span class="smallgraytext" style="float: left; padding-left: 9%">1.When Direct Invoice
                                        is created </span>
                                    <br />
                                    <span class="smallgraytext" style="float: left; padding-left: 9%">2.When added a main/sub/copied
                                        item </span>
                                    <br />
                                    <span class="smallgraytext" style="float: left; padding-left: 9%">3.When copy the Invoice
                                        to same/new customer without creating the Job </span>
                                    <br />
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <asp:RadioButton ID="rdoInvoice" runat="server" Text="When Job is progressed to an Invoice"
                                onclick="javascript:rdoReduceStock_checked('i');" />
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" style="width: 100%;">
                        <div class="bglabel" style="width: 20%; height: 60px">
                            <span>
                                <%=objlang.GetLanguageConversion("If_a_Job_is_cancelled")%></span></div>
                        <div style="float: left;">
                            <asp:RadioButtonList ID="rdoCancellationAction" runat="server">
                                <asp:ListItem Text="Add stock back to the Inventory, if the stock has already been allocated/reduced"
                                    Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Do not add stock back to the Inventory" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Prompt user to decide if stock should be added back to the system"
                                    Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                    <div align="left" style="width: 100%;">
                        <div style="float: left; width: 23%">
                            &nbsp;
                        </div>
                        <div class="smallgraytext">
                            <%=objLanguage.GetLanguageConversion("Prompt_Will_Appears_When")%>
                            <br />
                            <span style="float: left; padding-left: 4%">
                                <%=objLanguage.GetLanguageConversion("Job_Invoice_Status_Is_Changed_To_Cancelled")%>
                                <%-- 1.&nbsp; Job/Invoice Status is changed to
                                    cancelled --%></span>
                            <br />
                            <span style="float: left; padding-left: 27%">
                                <%=objLanguage.GetLanguageConversion("An_Item_Is_Deleted_Through_ReRun_Whose_Quantity_Is_Allocated")%>
                                <%--2.&nbsp; An item is deleted through re-run
                                    whose quantity is allocated--%>
                            </span>
                            <br />
                            <span style="float: left; padding-left: 27%">
                                <%=objLanguage.GetLanguageConversion("Job_Is_Reverted_To_Estimate")%>
                                <%-- 3.&nbsp; Job is reverted to estimate--%>
                            </span>
                            <br />
                            <span style="float: left; padding-left: 27%">
                                <%=objLanguage.GetLanguageConversion("An_Item_Is_Deleted_Directly_From_Job_Invoice")%>
                                <%--4.&nbsp; An Item is deleted directly from
                                    Job/Invoice--%>
                            </span>
                            <br />
                            <span style="float: left; padding-left: 27%">
                                <%=objLanguage.GetLanguageConversion("When_Job_Progressed_To_Invoice_Without_Reducing_The_Stock_Which_Is_Allocated")%>
                                <%--5.&nbsp; When Job progressed to invoice
                                    without reducing the stock which is allocated--%>
                            </span>
                            <br />
                            <br />
                            <%--<asp:Label ID="lbl_StatusMsg" runat="server"  CssClass="smallgraytext" Text="Once your selection has been saved this option will be locked to prevent accidental changes.
                                                                                         To change in the future please contact support"></asp:Label>--%>
                            <span style="float: left; padding-left: 22%">
                                <%=objLanguage.GetLanguageConversion("Stock_Reduction_Email_Alert")%>
                                <%-- Once your selection has been saved this
                                    option will be locked. You will not be able to alter these Stock Reduction without
                                    contacting support@eprintsoftware.com as alterations to the Stock Reduction can
                                    cause accidental changes etc.--%></span>
                        </div>
                    </div>
                    <div class="only10px">
                    </div>
                    <div style="float: left; width: 21%">
                        &nbsp;
                    </div>
                    <div style="float: left;">
                        <div id="div_btnCancel" style="display: block">
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
                                CssClass="button" OnClick="btnCancel_OnClick" />
                        </div>
                        <div id="div_btnCancelprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" CssClass="button"
                            OnClientClick="javascript:return btnSave_OnClientClick();" OnClick="btnSave_OnClick" />
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var rdoEstimate = document.getElementById("<%=rdoEstimate.ClientID %>");
        var rdoJob = document.getElementById("<%=rdoJob.ClientID %>");
        var rdoInvoice = document.getElementById("<%=rdoInvoice.ClientID %>");
        var div_jobStatusnew = document.getElementById("<%=div_jobStatus.ClientID %>");
        var ddlJobStatus = document.getElementById("<%=ddlJobStatus.ClientID %>");
        var spn_ddlJobStatusnew = document.getElementById("spn_ddlJobStatus")
        function rdoReduceStock_checked(val) {
            if (val == 'e') {
                rdoEstimate.checked = true;
                rdoJob.checked = false;
                rdoInvoice.checked = false;

                spn_ddlJobStatusnew.style.display = "none";

            }
            if (val == 'i') {
                rdoEstimate.checked = false;
                rdoJob.checked = false;
                rdoInvoice.checked = true;

                spn_ddlJobStatusnew.style.display = "none";

            }
            if (val == 'j') {
                rdoEstimate.checked = false;
                rdoJob.checked = true;
                rdoInvoice.checked = false;
                div_jobStatusnew.style.display = "block";

            }

        }

        function btnSave_OnClientClick() {
            if (rdoJob.checked) {
                if (ddlJobStatus.value == 0) {
                    spn_ddlJobStatusnew.style.display = "block";
                    return false;
                }
                else {
                    spn_ddlJobStatusnew.style.display = "none";
                    return true;
                }

            }
            else {
                spn_ddlJobStatusnew.style.display = "none";
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
