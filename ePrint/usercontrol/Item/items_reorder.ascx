<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="items_reorder.ascx.cs" Inherits="ePrint.usercontrol.Item.items_reorder" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>

<asp:ScriptManagerProxy ID="SMproxy" runat="server">
    <services>
        <asp:ServiceReference Path="~/press_select.asmx" />

    </services>
</asp:ScriptManagerProxy>
<div id='accordion123'>


    <asp:PlaceHolder ID="plhItems" runat="server"></asp:PlaceHolder>


</div>

<div>
    <button id="btnSave" type="button" value="Save Order">Save Order</button>
</div>

<asp:HiddenField ID="page_type" runat="server" Value="" />

<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
<script type="text/javascript">


    $(document).ready(function () {
        $(function () {
            $('#accordion123').sortable({
                placeholder: "placeholder",
                axis: 'y',
                items: 'h3[data-value="sortable"]',

                stop: function (event, ui) {


                }
            });
        });

        ///*
        $("#btnSave").click(function () {
            //document.getElementById("div_Load").style.display = "block";
            var bar = new Promise((resolve, reject) => {

                $('h3[data-value]').each(function (i, item) {
                    
                    var estimateItemId = $(this).attr('id');
                    console.log("position:" + i + "  >>  " + estimateItemId);

                    var pageName = $("#ctl00_ContentPlaceHolder1_ctl00_page_type").val();
                    
                        ePrint.press_select.Update_EstimateItems_SortingOrder(estimateItemId, i + 1, pageName);
                    if (i === $('h3[data-value]').length - 1) {
                        resolve();
                        // window.onunload = window.location.reload(true);
                        //window.close();
                        setTimeout(function () {
                            parent.location.reload(true);
                        }, 1000);






                        }
                    
                });
            });

            bar.then(() => {
                console.log('All done!');
                //window.location.reload(true);
            });
        });
    });

</script>
