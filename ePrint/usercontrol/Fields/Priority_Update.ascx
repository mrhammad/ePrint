<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Priority_Update.ascx.cs" Inherits="ePrint.usercontrol.Fields.Priority_Update" %>



<script type="text/javascript">
    function closeDialog()
    {
        debugger;
        $("[id$=\"divLoadingImage\"]").show();
        if (window.parent && window.parent.location) {
            window.parent.location.reload();
        }
        Close_wind(); 
       
    }

  
        function saveCallback() {
            parent.location.href = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnReloadUrl").value;
        }

</script>
<asp:HiddenField ID="hdnId" runat="server" />
<asp:HiddenField ID="hdnpriority" runat="server" />
<asp:HiddenField ID="hdnpage" runat="server" />



<div style="width: 90%;">
    <div style="margin-bottom: 10px;">
        <div id="divLoadingImage" runat="server" style="display: none; margin-top:10px;">
            <div id="DivLayer" class="DialogueBackgroundSurveyView">
            </div>
            <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 35%;">
                <img src="/images/loading_new.gif" border="0" style="border-radius: 2px;" />
            </div>
        </div>
        <asp:Label Text="Priority:" ID="priorityLablel" runat="server" class="bglabel" />
        <asp:DropDownList ID="ddlPriority" runat="server" Style="width: 55%; height: 25px;">
        </asp:DropDownList>
    </div>
    <div style="text-align: right; padding-right: 13%;">
        <asp:Button ID="btnSavePriority" runat="server" Text="Save" OnClick="btnSavePriority_Click"
            class="headerbutton white" />
        <input type="button" id="btnCancel" value="Cancel" class="headerbutton white" onclick='closeDialog()' />
    </div>
</div>
