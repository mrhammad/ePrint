<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalogueItem_Stock_Other.ascx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogueItem_Stock_Other" %>
<script type="text/javascript" src="../../js/item/pricecatalogfeatures.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/item/AutoFill.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script>
    var Pgtype = '<%=PageType %>';
</script>
<style>
.right-align {
        float: right;
        margin-top:10px;
    }
    
</style>



<asp:PlaceHolder ID="plhotherproducts" runat="server"></asp:PlaceHolder>
<asp:Button CssClass="button right-align" ID="btnStockOtherSave" OnClick="btnStockOtherSave_Click" OnClientClick="getOtherProductDetails();loadingimage(this.id,'div_save_other')" runat="server" Text="Update" />
 <div id="div_save_other" style="display: none; float: right">
    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
 </div>

<asp:HiddenField ID="hdnOtherProductDetails" runat="server" Value="0" />

<script>
    function ClearTextbox(txtcode, txttitle) {
        var txttitle = document.getElementById(txttitle);
        if (txtcode.value == '') {
            txttitle.value = '';
        }

    }

    function duplicatecodevalidate(textboxid, titletextboxid, otherkititemid, itemcode) {
        debugger;
            var rowid = document.getElementById('tblother').getElementsByTagName('tr');
            for (p = 1; p < (rowid.length); p++) {
                var inputs = rowid[p].getElementsByTagName('input');
                for (n = 0; n < inputs.length; n++) {
                    if (Number(inputs[0].value) != 0) {
                        if ((inputs[n].id).indexOf('txtitemcode') > -1) {
                            if (inputs[n].id != textboxid.id) {
                                if (inputs[n].value == itemcode) {
                                    textboxid.value = '';
                                    titletextboxid.value = '';
                                    otherkititemid = '';
                                    alert("Product already used!!");
                                    return false;
                                }
                            }
                        }

                    }


                }
            }
    }

    function getOtherProductDetails() {
        debugger;
        var hdnOtherProductDetails = document.getElementById("<%=hdnOtherProductDetails.ClientID %>");
         var otherproduct = '';
        var tblid = document.getElementById("tblother-edit");
        var rowid = document.getElementById('tblother-edit').getElementsByTagName('tr');
         for (p = 1; p < (rowid.length); p++) {

             var inputs = rowid[p].getElementsByTagName('input');
             for (n = 0; n < inputs.length; n++) {
                 if (Number(inputs[0].value) != 0) {
                     if ((inputs[n].id).indexOf('hdnOtherKitItemID-edit') > -1) {
                         otherproduct += 'kititemid»' + inputs[n].value + "±";
                     }
                     if ((inputs[n].id).indexOf('txtunit-edit') > -1) {
                         otherproduct += 'unit»' + inputs[n].value + "µ";
                     }
                 }
             }
         }
         hdnOtherProductDetails.value = otherproduct;
         return true;
    }
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function closeAndRedirect(id) {
        debugger;
        GetRadWindow().BrowserWindow.location.href = "<%=strSitePath %>" + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id + "";
        GetRadWindow().close();
    }
</script>

