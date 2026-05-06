<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_proof_detail.ascx.cs" Inherits="ePrint.usercontrol.Item.item_proof_detail" %>
<style type="text/css">
    table.historyTable {
        border-width: 1px;
        border-spacing: 2px;
        /*border-style: outset;*/
        border-color: #bfbfbf;
        border-collapse: collapse;
        background-color: white;
    }

        table.historyTable td,th {
           /* border-width: 2px;
            padding: 1px;
            border-style: inset;*/
            border:1px solid #bfbfbf;
            background-color: white;
        }
      
   
</style>
<table id="tblItemTotal" style="min-height:460px;" width="97%" cellpadding="0" cellspacing="0" border="0">
    <tr id="tr1">
        <td valign="top" width="100%" style="padding-top: 2px">
            <asp:Image ID="ImageCanvas" runat="server" />
            <asp:PlaceHolder ID="plhItemTotal" runat="server"></asp:PlaceHolder>

        </td>
    </tr>
    <tr>
        <td valign="top" width="100%">
            <div style="float: right; border: 0px solid green; margin-top: 2px;">
                <%--<asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" OnClick="OnClick_btnCancel" />--%>
                <%--As per the instruction this Save & Save stay functionality included in Save&Stay and Save btn Click of Summary page so these two btns made display none--%>
                <div style="float: right">
                    <div id="div_btnsave" style="display: none">
                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnStay_Click" />
                    </div>
                    <div id="div_saveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: right; padding-right: 10px">
                    <div id="div_btnstay" style="display: none">
                        <asp:Button ID="btnStay" CssClass="button" runat="server" Text="Save & Stay" OnClick="btnStay_Click" />
                    </div>
                    <div id="div_stayprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <asp:HiddenField runat="server" Value="" ID="hdnSaveValues" />
                <%-- Items are by Using Web Service--%>
            </div>
            <%--<div align="left" id="summaryHRLine" style="width: 100%;">
</div>--%>
            <asp:HiddenField ID="hdnProfitmarginvalue" runat="server" Value="" />
            <asp:HiddenField ID="hdnProfitMarginInPrice" runat="server" Value="" />
            <asp:HiddenField ID="hdnSutotalold" runat="server" Value="" />
            <asp:HiddenField ID="hdnTaxPrice" runat="server" Value="" />
            <asp:HiddenField ID="hdn_Description" runat="server" Value="" />
        </td>
    </tr>
</table>
<script>

    var OldTable;

    function ShowProofHistory(EstimateItemId) {
        debugger;

        var ddlProofFiles = document.getElementById("ddlProofFiles_" + EstimateItemId);
        var attachmentId = '0';
        if (ddlProofFiles.options[ddlProofFiles.selectedIndex] != undefined && ddlProofFiles.options[ddlProofFiles.selectedIndex] != null) {
            attachmentId = ddlProofFiles.options[ddlProofFiles.options.selectedIndex].value;

            var ProofTab = document.getElementById("ProofTable_" + attachmentId);
            ProofTab.style.display = "block";
            if (OldTable) {
                OldTable.style.display = "none";
            }
            OldTable = ProofTab;
        }

    }
    function changeCurser(element) {
        element.style.cursor = "pointer";
    }
</script>
