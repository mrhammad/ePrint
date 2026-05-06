<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="order_summary_action.ascx.cs" Inherits="ePrint.usercontrol.orders.order_summary_action" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div id="div_ItemSumaryOrder" runat="server">
    <telerik:RadButton ID="rbtn_Action" runat="server" AutoPostBack="false" EnableSplitButton="true"
        Skin="Vista" OnClientClicked="OnClientClicked">
    </telerik:RadButton>
    <telerik:RadContextMenu ID="rcm_ItemOrder" runat="server" OnClientItemClicked="RedirectPage">
        <Items>
            <telerik:RadMenuItem Style="cursor: pointer;" />
            <telerik:RadMenuItem Visible="false" Style="cursor: pointer;" />
            <telerik:RadMenuItem Style="cursor: pointer;" />
        </Items>
    </telerik:RadContextMenu>
    <asp:HiddenField ID="HdnEstimateItemID" runat="server" Value="" />
    <script type="text/javascript">
        function OnClientClicked(sender, args) {
            var cntrlID = sender.get_id().replace('rbtn_Action', 'rcm_ItemOrder');
            if (args.IsSplitButtonClick() || !sender.get_commandName()) {
                var currentLocation = $telerik.getLocation(sender.get_element());
                var contextMenu = $find(cntrlID);
                contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
            }
        }

    </script>
    <script type="text/javascript">

        var OrderID;
        var EstimateID;
        var EstimateItemID;
        var Module = '<%=Module %>';
        var OrderItemID;
        var estType;
        function RedirectPage(sender, args) {
            var Edit_Job_Card = '<%=objLanguage.GetLanguageConversion("Edit_Job_Card") %>';
            var Delete_Item = '<%=objLanguage.GetLanguageConversion("Delete_Item") %>';
            var ReRun_Item = '<%=objLanguage.GetLanguageConversion("ReRun_Item") %>';

            var id = sender.get_id();
            var hdnConvertedID = id.replace("rcm_ItemOrder", "HdnEstimateItemID");
            var AllIds = document.getElementById(hdnConvertedID).value;
            var arrId = AllIds.split('μ');
            if (arrId.length > 0) {
                OrderID = arrId[0].trim();
                EstimateID = arrId[1].trim();
                EstimateItemID = arrId[2].trim();
                OrderItemID = arrId[3].trim();
                estType = arrId[4].trim();
            }
            var itemValue = args.get_item().get_text();

            if (itemValue == Edit_Job_Card) {
                ShowJobCard(EstimateID, EstimateItemID);
            }

            if (itemValue == Delete_Item) {
                DeleteOrderItem(EstimateItemID, OrderItemID);
            }



            if (itemValue == ReRun_Item) {
                var redirectPath
                if (Module == "webstoreorder") {
                    redirectPath = strSitepath + 'orders/order_productcatalogue.aspx?frm=sum&type=edit&ordid=' + OrderID + '&estid=' + EstimateID + '&estitemid=' + EstimateItemID;

                }
                if (Module == "job") {
                    if (estType == 'u') {
                        redirectPath = strSitepath + 'jobs/job_Othercost.aspx?type=edit&EstID=' + EstimateID + '&OrdID=' + OrderID + '&EstItemID=' + EstimateItemID + '&frm=sum&maintype=edit&esttype=U&eStore=yes';
                    }
                    else {
                        redirectPath = strSitepath + 'jobs/job_productcatalogue.aspx?frm=sum&type=edit&ordid=' + OrderID + '&estid=' + EstimateID + '&estitemid=' + EstimateItemID;
                    }
                }
                if (Module == "invoice") {
                    if (estType == 'u') {
                        redirectPath = strSitepath + 'invoice/invoice_Othercost.aspx?type=edit&EstID=' + EstimateID + '&OrdID=' + OrderID + '&EstItemID=' + EstimateItemID + '&frm=sum&maintype=edit&esttype=U&eStore=yes';
                    }
                    else {
                        redirectPath = strSitepath + 'invoice/invoice_productcatalogue.aspx?frm=sum&type=edit&ordid=' + OrderID + '&estid=' + EstimateID + '&estitemid=' + EstimateItemID;
                    }
                }
                window.location = redirectPath;

            }
        }
    </script>
</div>

