<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_outwork_item.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_outwork_item" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script language="javascript" type="text/javascript">

    function Goto_3rdTab() {
        $(document).ready(function () {
            $(function () {
                $('#tabs').tabs();
                $('#tabs').tabs('select', '#tabs-3');
            });
        });
    }

    function QuoteDetailsOpen(tab) {
        $(document).ready(function () {
            $(function () {
                $('#tabs').tabs();
                $('#tabs').tabs('select', '#tabs-3');
            });
        });

        $(document).ready(function () {
            $(function () {
                $("#accordion2").accordion({
                    header: "h4", collapsible: true, autoHeight: false
                });
                var accordionindex = tab;
                $("#accordion2").accordion('activate', accordionindex);
                document.getElementById("tabs").style.visibility = 'visible';
            });
        });
    }

    function QuoteOrderTab(id) {
        var Name_ID = 'lblItemTitle_' + id;
        var Name = document.getElementById(Name_ID).innerText;
        var hdnid = 'ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcOutworkItem_' + id + '_hdnQuoteDetails_ID';
        var hdnName = 'ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcOutworkItem_' + id + '_hdnQuoteDetails_Name';
        var btnid = 'ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcOutworkItem_' + id + '_btn_QuoteDetails';

        document.getElementById(hdnid).value = id;
        document.getElementById(hdnName).value = Name;
        document.getElementById(btnid).click();
    }
</script>
<table id="tblOutworkItem" width="97%" cellpadding="0" cellspacing="0" border="0"
    style="float: left; margin-bottom: -2px;">

    <tr id="trQuantity">
        <td>
            <asp:PlaceHolder ID="plhOutworkItem" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>



