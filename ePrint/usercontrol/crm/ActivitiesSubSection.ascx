<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivitiesSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.ActivitiesSubSection" %>

<div id="divLoadingImageRecords" style="display: none;">
    <div id="DivLayer" class="DialogueBackgroundSurveyView">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="<%=ImgPath %>loading_new.gif" border="0" />
    </div>
</div>
<div id="div_History" runat="server" style="display: block; padding: 10px 10px 10px 10px;
    border: solid 0px red;">
    <div id="ynnav" style="padding-left: 0px;">
        <ul style="display: none;">
            <asp:UpdatePanel ID="up_Estimates" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li id="li_EstimatesTab" style="cursor: pointer; float: left; clear: right;" onclick="javascript:gettabs('activities');">
                        <%-- --%>
                        <div id="div_EstimatesTab" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b>
                                <asp:Label ID="lbl_Estimates" runat="server" Text="" Style="color: Red;"><%=objLanguage.GetLanguageConversion("Estimate") %></asp:Label>
                                <asp:LinkButton ID="lnk_EstimatesTab" runat="server" OnClick="lnk_EstimatesTab_Click"></asp:LinkButton>
                            </b>
                        </div>
                    </li>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="up_eStore" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li id="li_eStoreTab" style="cursor: pointer; float: left; clear: right; display: block"
                        onclick="javascript:gettabs('estore');">
                        <div id="div_eStoreTab" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b>
                                <asp:Label ID="lbl_eStore" runat="server" Text=""><%=objLanguage.GetLanguageConversion("eStore_Order") %></asp:Label>
                                <asp:LinkButton ID="lnk_eStoreTab" runat="server" OnClick="lnk_eStoreTab_Click"></asp:LinkButton>
                            </b>
                        </div>
                    </li>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="up_Jobs" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li id="li_JobsTab" style="cursor: pointer; float: left; clear: right; display: block"
                        onclick="javascript:gettabs('jobs');">
                        <div id="div_JobsTab" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b>
                                <asp:Label ID="lbl_Jobs" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Job") %></asp:Label>
                                <asp:LinkButton ID="lnk_JobsTab" runat="server" OnClick="lnk_JobsTab_Click"></asp:LinkButton>
                            </b>
                        </div>
                    </li>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="up_Invoice" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li id="li_InvoiceTab" style="cursor: pointer; float: left; clear: right; display: block"
                        onclick="javascript:gettabs('invoices');">
                        <div id="div_InvoiceTab" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b>
                                <asp:Label ID="lbl_Invoices" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Invoices") %></asp:Label>
                                <asp:LinkButton ID="lnk_InvoicesTab" runat="server" OnClick="lnk_InvoicesTab_Click"></asp:LinkButton>
                            </b>
                        </div>
                    </li>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ul>
        <div style="float: left; padding-bottom:10px;">
            <asp:DropDownList ID="ddlRecordTab" runat="server" CssClass="simpledropdownPopup"
                Width="120px" onchange="javascript:GettabRecords();">
            </asp:DropDownList>
        </div>
    </div>
    <div id="div_EstimatesMain" runat="server" style="border-top: solid 0px silver; display: block;
        padding-top: 6px;">
        <div>
            <asp:UpdatePanel ID="up_EstimatesDetails" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plh_EstimatesDetails" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_eStoreMain" runat="server" style="border: solid 0px silver; width: 100%;
        display: none; padding-top: 6px;">
        <div>
            <asp:UpdatePanel ID="up_eStoreDetails" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plh_eStoreDetails" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_JobsMain" runat="server" style="border: solid 0px silver; width: 100%;
        display: none; padding-top: 6px;">
        <div>
            <asp:UpdatePanel ID="up_JobsDetails" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plh_JobsDetails" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_InvoicesMain" runat="server" style="border: solid 0px silver; width: 100%;
        display: none; padding-top: 6px;">
        <div>
            <asp:UpdatePanel ID="up_InvoiceDetails" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plh_InvoiceDetails" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">

    function GettabRecords() {
        var ddlRecordTab = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_ddlRecordTab");
        var ddlRecordTabNew = ddlRecordTab.options[ddlRecordTab.selectedIndex].value;

        var activities = "";
        if (ddlRecordTabNew == "Estimate") {
            document.getElementById("divLoadingImageRecords").style.display = "block";
            activities = "activities";
            gettabs(activities);
            var lnk_ClearFilter_Estimate = document.getElementById("ctl00_ContentPlaceHolder1_Client_div_EstimateControls");
            if (lnk_ClearFilter_Estimate != null && lnk_ClearFilter_Estimate != undefined) {
                lnk_ClearFilter_Estimate.style.display = "block";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_eStoreControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_JobControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_InvoiceControls").style.display = "none";
        }
        if (ddlRecordTabNew == "eStoreorder") {
            document.getElementById("divLoadingImageRecords").style.display = "block";
            activities = "estore";
            gettabs(activities);
            var lnk_ClearFilter_eStore = document.getElementById("ctl00_ContentPlaceHolder1_Client_div_eStoreControls");
            if (lnk_ClearFilter_eStore != null && lnk_ClearFilter_eStore != undefined) {
                lnk_ClearFilter_eStore.style.display = "block";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_EstimateControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_JobControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_InvoiceControls").style.display = "none";
        }
        if (ddlRecordTabNew == "Job") {
            document.getElementById("divLoadingImageRecords").style.display = "block";
            activities = "jobs";
            gettabs(activities);
            var lnk_ClearFilter_Job = document.getElementById("ctl00_ContentPlaceHolder1_Client_div_JobControls");
            if (lnk_ClearFilter_Job != null && lnk_ClearFilter_Job != undefined) {
                lnk_ClearFilter_Job.style.display = "block";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_EstimateControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_eStoreControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_InvoiceControls").style.display = "none";
        }
        if (ddlRecordTabNew == "Invoices") {
            document.getElementById("divLoadingImageRecords").style.display = "block";
            activities = "invoices";
            gettabs(activities);
            var lnk_ClearFilter_Invoice = document.getElementById("ctl00_ContentPlaceHolder1_Client_div_InvoiceControls");
            if (lnk_ClearFilter_Invoice != null && lnk_ClearFilter_Invoice != undefined) {
                lnk_ClearFilter_Invoice.style.display = "block";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_EstimateControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_eStoreControls").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_div_JobControls").style.display = "none";
        }
    }
    function LoadingImage() {
        parent.window.document.getElementById("DivBigLoadingImg").style.display = "block";
    }

</script>
<script type="text/javascript" language="javascript">

    var ClientID = '<%=ClientID%>';
    var lbl_Estimates = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Estimates");
    var div_EstimatesMain = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_EstimatesMain");

    var lbl_Jobs = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Jobs");
    var div_JobsMain = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_JobsMain");

    var lbl_Invoices = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Invoices");
    var div_InvoicesMain = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_InvoicesMain");
</script>

