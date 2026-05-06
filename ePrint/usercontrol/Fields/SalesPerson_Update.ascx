<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesPerson_Update.ascx.cs" Inherits="ePrint.usercontrol.Fields.SalesPerson_Update" %>

<script type="text/javascript">
    function closeDialog()
    {
        $("[id$=\"divLoadingImage\"]").show();
        Close_wind(); 
    }

</script>
<asp:HiddenField ID="hdnJobId" runat="server" />
<asp:HiddenField ID="hdnSalesPersonId" runat="server" />
<asp:HiddenField ID="hdnReloadUrl" runat="server" />
<asp:HiddenField ID="hdnType" runat="server" />


<div style="width: 90%;">
    <div style="margin-bottom: 10px;">
        <div id="divLoadingImage" runat="server" style="display: none; margin-top:10px;">
            <div id="DivLayer" class="DialogueBackgroundSurveyView">
            </div>
            <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 35%;">
                <img src="/images/loading_new.gif" border="0" style="border-radius: 2px;" />
            </div>
        </div>
        <asp:Label Text="Sales Person:" ID="salesPersonLablel" runat="server" class="bglabel" />
        <asp:DropDownList ID="ddlSalesPerson" runat="server" Style="width: 55%; height: 25px;">
        </asp:DropDownList>
    </div>
    <div style="text-align: right; padding-right: 13%;">
        <asp:Button ID="btnSaveSalesPerson" runat="server" Text="Save" OnClick="btnSaveSalesPerson_Click"
            class="headerbutton white" />
        <input type="button" id="btnCancel" value="Cancel" class="headerbutton white" onclick='closeDialog()' />
    </div>
</div>
