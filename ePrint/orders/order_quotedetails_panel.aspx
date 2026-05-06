<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_quotedetails_panel.aspx.cs" Inherits="ePrint.orders.order_quotedetails_panel" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagName="quote_details" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_supplierquotedetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
        rel="stylesheet" />
    <script>
        var divBackGroundNew = document.getElementById("divBackGroundNew");
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath %>js/wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#accordion2").accordion({
                    header: "h4", collapsible: true, autoHeight: false
                });
                $("#accordion2 span").click(function (event) {
                    event.stopImmediatePropagation();
                    event.preventDefault();
                });
                $("h4#" + accordion2)[0].click();
                var accordionindex = 1000;
                //var accordionindex = 0;
                $("#accordion2").accordion();
                if (accordionindex == 0) {
                    $("#accordion2").accordion();
                }
                else {
                    $("#accordion2").accordion();
                    $("#accordion2").accordion('activate', accordionindex);

                }
                document.getElementById("tabs").style.visibility = 'visible';
            });
        });
        //        $(document).ready(function () {
        //            
        //            // $("#accordion2").accordion('activate', 1);
        //            $("h4#" + accordion2)[0].click();
        //        });             
    </script>
    <div id="divrad" style="display: none; position: absolute; vertical-align: middle;
        border: 0px solid; z-index: 100; width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
            OnClientClose="RadWinClose" Behaviors="Close, Move,Reload,Resize" ReloadOnShow="true">
        </telerik:RadWindowManager>
    </div>
    <div id="tabs-3" class="ui-tabs-hide" style="width: 99%; padding: 8px 4px 20px 3px;
        margin: 0px">
         <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
        </div>
        <div id="accordion2" style="width: 100%; padding: 0px; margin: 0px">
            <UC:quote_details ID="ucQuotedetails" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
