<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobDate_Update.ascx.cs" Inherits="ePrint.usercontrol.Fields.JobDate_Update_ascx" %>
<script>
    $(document).ready(function () {
        $("[id$='txtJobDate']").attr("onclick", "javascript:event.cancelBubble=true;this.select();lcs(this,'"
            + $("[id$='hdnDateFormat']").val() + "');");
    });
   
    function closeDialog()
    {
        $("[id$=\"divLoadingImage\"]").show();
        Close_wind(); 
    }

</script>   


<div style="width: 100%; align-content: center;">
    <asp:HiddenField ID="hdnJobId" runat="server" />
        <asp:HiddenField ID="hdnEstimateItemID" runat="server" />
    <asp:HiddenField ID="hdnDateFormat" runat="server" />
    <asp:HiddenField ID="hdnReloadUrl" runat="server" />

    <div style="margin-bottom: 10px;">
        <div id="divLoadingImage" runat="server" style="display: none;">
            <div id="DivLayer" class="DialogueBackgroundSurveyView">
            </div>
            <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 35%;">
                <img src="/images/loading_new.gif" border="0" style="border-radius: 2px;" />
            </div>
        </div>
        <asp:Label Text="Job Date:" Style="width:auto" runat="server" class="bglabel" />
        <asp:TextBox ID="txtJobDate" runat="server" TextMode="DateTime"
            onblur="javascript:CopyDate(1,1,this.value);" Style="height: 23px"></asp:TextBox>
    </div>
    <div style="text-align: right; padding-right: 27%;">
        <asp:Button ID="btnSaveJobDate" runat="server" Text="Save" OnClick="btnSaveJobDate_Click" OnClientClick=""
            class="headerbutton white" />
        <input type="button" id="btnCancel" value="Cancel" class="headerbutton white" onclick='closeDialog();' />
    </div>

</div>