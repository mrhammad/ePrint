<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="printcenter_leftpanel.ascx.cs" Inherits="ePrint.printcenter_leftpanel" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="../js/approvalsystem.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<%--do not comment this javascript or remove this javascript--%>
<script src="../js/item/item_summary.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<%--<div id="divSmall" style="display: none; position: absolute; vertical-align: middle;
    border: 0px solid; z-index: 100; width: 50%;" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowSmall" DestroyOnClose="true"
        Opacity="100" runat="server"  Style="z-index: 31000;" Width="360" Height="400" 
        OnClientClose="RadWinClose" Behaviors="Close,Move" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>--%>
<div id="divLoadingImageCus" runat="server" style="display: none;">
    <div id="DivLayer" class="loading_background">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
    </div>
</div>
<asp:Panel runat="server" ID="pnlItem" Visible="false">
    <asp:Panel runat="server" ID="pnlestimate" Visible="true">
        <tr valign="top" style="border: 1px solid red;">
            <td>
                <%--class="BgImage_New"--%>
                <div id="div1" style="display: block;">
                    <div id="divitemclose" runat="server" onclick="Items('none');" style="cursor: pointer;">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top" align="left" class="bgcustomize">
                                    <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                                </td>
                                <td nowrap="nowrap" width="149" class="bgcustomize" height="23">
                                    <strong class="navigatorpanel" style="padding-right: 92px">Items</strong>
                                    <img alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                                </td>
                                <td valign="top" align="right" class="bgcustomize">
                                    <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divitemshow" runat="server" onclick="Items('block');" style="cursor: pointer;
                        display: none">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top" align="left" class="bgcustomize">
                                    <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                                </td>
                                <td nowrap="nowrap" width="149" class="bgcustomize" height="23">
                                    <strong style="padding-right: 92px" class="navigatorpanel">Items</strong><img alt=""
                                        src="<%=strImagepath%>triangle.gif" align="absmiddle" />
                                </td>
                                <td valign="top" align="right" class="bgcustomize">
                                    <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr valign="top">
            <td class="borderWithoutTop">
                <asp:Label ID="lblItem" runat="server" Style="display: none"></asp:Label>
                <div id="divAddItem" runat="server" style="display: block; padding-top: 5px; padding-left: 5px;
                    padding-bottom: 5px">
                    <div id="divItem" runat="server" style="display: none; padding-bottom: 5px">
                        <a href="#" onclick="javascript:MakeMask();return false;">Add Item</a></div>
                    <div id="divItem_Store" runat="server" style="display: none; padding-bottom: 5px">
                        <a href="#" onclick="javascript:MakeMaskSupplyStore('store');return false;">Store Supply
                        </a>
                    </div>
                    <div id="divItem_Contract" runat="server" style="display: none; padding-bottom: 5px">
                        <a href="#" onclick="javascript:MakeMaskSupplyStore('contract');return false;">Customer
                            Item </a>
                    </div>
                    <div id="divItem_Library" runat="server" style="display: none; padding-bottom: 5px">
                        <a href="#" onclick="javascript:showItemlibrary();return false;">Item Library </a>
                    </div>
                    <div id="divItem_Jobs" runat="server" style="padding-bottom: 5px">
                        <a href="#" onclick="javascript:Show_LinkJobs();return false;">Link Jobs </a>
                    </div>
                    <div id="divItem_Attachments" runat="server" style="padding-bottom: 5px;">
                        <a href="#" onclick="javascript:MakeMaskShow();return false;">Attachments </a>
                    </div>
                    <div id="divItem_Notes" runat="server" style="padding-bottom: 5px;">
                        <a href="#" onclick="javascript:MakeMaskShow_Notes();return false;">Notes </a>
                    </div>
                    <%--  <div style="float: left; clear: both">
                </div>--%>
                </div>
            </td>
        </tr>
    </asp:Panel>
    <tr>
        <td>
            <div id="divestimate" style="display: block;">
                <div id="divestimateclosed" runat="server" onclick="estimate('none');" style="cursor: pointer;
                    display: block">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Optionssssss</strong><img
                                    alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divestimateopen" runat="server" onclick="estimate('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Optionssssss</strong><img
                                    alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <%-- <div id="divrecentitem1_1" style="display: none" runat="server">--%>
            <div id="divrecentitem_1" style="display: block; overflow: visible;">
                <ul id="Ul1" class="glossymenu">
                    <li id="add_estimate" runat="server" visible="true"><a href="<%=strSitepath%>Estimates/estimate_add.aspx">
                        &nbsp;&nbsp;Add a new Estimate</a> </li>
                    <li id="report_estimate" runat="server" visible="false"><a href="#">&nbsp;&nbsp;Reports</a>
                    </li>
                    <li id="view_estimate" runat="server" visible="true"><a href="<%=strSitepath%>Estimates/estimate_view.aspx">
                        &nbsp;&nbsp;View Estimates</a> </li>
                    <li id="att_estimate" runat="server" visible="false"><a href="#" onclick="javascript:MakeMaskShow();return false;">
                        &nbsp;&nbsp;Attachments</a> </li>
                    <li id="note_estimate" runat="server" visible="false"><a href="#" onclick="javascript:MakeMaskShow_Notes();return false;">
                        &nbsp;&nbsp;Notes</a> </li>
                </ul>
            </div>
            <%-- </div>--%>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<asp:Panel runat="server" ID="pnlPurchase" Visible="false">
    <tr valign="top">
        <td>
            <%--class="BgImage_New"--%>
            <div id="div2" style="display: block;">
                <div id="divstockclose" runat="server" onclick="Stock('none');" style="cursor: pointer;">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="160" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 70px">Add Stock</strong><img
                                    alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divstockshow" runat="server" onclick="Stock('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="160" class="bgcustomize" height="23">
                                <strong style="padding-right: 70px" class="navigatorpanel">Add Stock</strong><img
                                    alt="" src="<%=strImagepath%>triangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td class="borderWithoutTop">
            <div id="divAddStock" style="display: block; overflow: hidden; height: 76px; padding-top: 5px;
                padding-left: 5px; padding-bottom: 5px">
                <div style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMask_Show_StockOnly('paper');return false;">Paper</a></div>
                <div style="padding-bottom: 5px;">
                    <a href="#" onclick="javascript:MakeMask_Show_StockOnly('ink');return false;">Inks</a></div>
                <div style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMask_Show_StockOnly('film');return false;">Films
                    </a>
                </div>
                <div style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMask_Show_StockOnly('plate');return false;">Plates
                    </a>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<asp:Panel runat="server" ID="pnlWarehouse" Visible="false">
    <tr valign="top">
        <td>
            <%--class="BgImage_New"--%>
            <div id="divWarehouseHeader" style="display: block;">
                <div id="divinventoryclose" runat="server" onclick="Inventory('none');" style="cursor: pointer;">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 81px">
                                    <asp:Label ID="lblheader1" runat="server" Text="Options"></asp:Label></strong><img
                                        alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divinventoryshow" runat="server" onclick="Inventory('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149" class="bgcustomize" height="23">
                                <strong style="padding-right: 81px" class="navigatorpanel">
                                    <asp:Label ID="lblheader" runat="server" Text="Options"></asp:Label></strong><img
                                        alt="" src="<%=strImagepath%>triangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <div id="divAddInventory" style="display: block; overflow: visible; height: 135px;">
                <div style="padding-bottom: 5px; display: none">
                    <a href="<%=strSitepath%>warehouse/stock_adjustment.aspx">Stock Adjustment</a></div>
                <div id="divsetting" style="display: block; overflow: visible;" runat="server">
                    <div style="float: left;">
                        <ul id="verticalmenu" class="glossymenu" style="display: block">
                            <li runat="server" id="liInvAdd"><a href="<%=strSitepath%>warehouse/inventory_add.aspx"
                                title="Add New Inventory">&nbsp;&nbsp;Add New</a> </li>
                            <li runat="server" id="liInvView"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=inventory">
                                &nbsp;&nbsp;View Inventory</a> </li>
                            <li runat="server" id="listoresupply"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=store"
                                title="Add New Inventory">&nbsp;&nbsp;View Store Supply </a></li>
                            <li runat="server" id="licustomeritem"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=item"
                                title="Add New Inventory">&nbsp;&nbsp;View Customer Item </a></li>
                            <li runat="server" id="liInvAdj" style="display: none"><a href="<%=strSitepath%>warehouse/stock_adjustment.aspx?type=inventory"
                                title="Inventory Adjustment">&nbsp;&nbsp;Inv.. Adjustment</a>
                                <%--<ul style="border-top: solid 1px #ccc">
                                    <li><a href="<%=strSitepath%>warehouse/stock_adjustment.aspx?type=price">&nbsp;&nbsp;Price</a></li>
                                    <li><a href="<%=strSitepath%>warehouse/stock_adjustment.aspx?type=quantity">&nbsp;&nbsp;Quantity</a></li>
                                </ul>--%>
                            </li>
                            <li><a href="#" title="Inventory Issues">&nbsp;&nbsp;Inventory Issue</a> </li>
                            <li><a href="#" onclick="javascript:showmessage();" title="Raise Inventory Purchase Order">
                                &nbsp;&nbsp;Raise PO</a> </li>
                            <%--onclick="javascript:ShowRaisePO();return false;"--%>
                            <li><a href="#">&nbsp;&nbsp;Reports</a> </li>
                        </ul>
                        <ul id="ul_store" class="glossymenu" style="display: none">
                            <li runat="server" id="liAddStore"><a href="<%=strSitepath%>warehouse/item_finishedgoods_add.aspx?page=store"
                                title="Add New Store Supply">&nbsp;&nbsp;Add New</a> </li>
                            <li runat="server" id="li5"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=inventory">
                                &nbsp;&nbsp;View Inventory</a> </li>
                            <li runat="server" id="liViewStore" visible="false"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=store"
                                title="View Store Supply">&nbsp;&nbsp;View Store Supply</a></li>
                            <li runat="server" id="li9"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=item"
                                title="View Customer Item">&nbsp;&nbsp;View Customer Item </a></li>
                            <li runat="server" id="li6" style="display: none"><a href="<%=strSitepath%>warehouse/stock_adjustment.aspx?type=store"
                                title="Store Supply Adjustment">&nbsp;&nbsp;Sto.. Adjustment</a> </li>
                            <li><a href="#">&nbsp;&nbsp;Reports</a> </li>
                        </ul>
                        <ul id="ul_item" class="glossymenu" style="display: none">
                            <li runat="server" id="liAddItem"><a href="<%=strSitepath%>warehouse/item_finishedgoods_add.aspx?page=item"
                                title="Add New Customer Item">&nbsp;&nbsp;Add New</a> </li>
                            <li runat="server" id="li7"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=inventory">
                                &nbsp;&nbsp;View Inventory</a> </li>
                            <li runat="server" id="liViewItem" visible="false"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=item"
                                title="View Customer Item">&nbsp;&nbsp;View Customer Item</a> </li>
                            <li runat="server" id="li10"><a href="<%=strSitepath%>warehouse/warehouse.aspx?type=store"
                                title="View Inventory">&nbsp;&nbsp;View Store Supply</a> </li>
                            <li runat="server" id="li8" style="display: none"><a href="<%=strSitepath%>warehouse/stock_adjustment.aspx?type=item"
                                title="Customer Item Adjustment">&nbsp;&nbsp;Cust... Adjustment</a> </li>
                            <li><a href="#" title="Inventory Issues">&nbsp;&nbsp;Customer Item Issue</a> </li>
                            <li><a href="#">&nbsp;&nbsp;Reports</a> </li>
                        </ul>
                    </div>
                </div>
                <script>


                    CheckWarehouseLeftpanel();
                    function CheckWarehouseLeftpanel() {

                        var urlInv = "<%=urlInventory %>";
                        var urlStor = "<%=urlStoreSupply %>";
                        var urlCust = "<%=urlCustomerItem %>";

                        wareNone();
                        if (urlInv != '') {

                            document.getElementById("verticalmenu").style.display = "block";

                        }
                        else if (urlStor != '') {
                            document.getElementById("ul_store").style.display = "block";
                            document.getElementById("divAddInventory").style.height = "30px";
                        }
                        else if (urlCust != '') {
                            document.getElementById("ul_item").style.display = "block";
                            document.getElementById("divAddInventory").style.height = "30px";
                        }

                    }
                    function wareNone() {
                        document.getElementById("verticalmenu").style.display = "none";
                        document.getElementById("ul_store").style.display = "none";
                        document.getElementById("ul_item").style.display = "none";
                    }
                </script>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<asp:Panel runat="server" ID="pnlPrint" Visible="false">
    <tr valign="top">
        <td>
            <%--class="BgImage_New"--%>
            <div id="div3" style="display: block;">
                <div id="divprintclose" runat="server" onclick="Print('none');" style="cursor: pointer;">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Options</strong><img alt=""
                                    src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divprintshow" runat="server" onclick="Print('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Options</strong><img alt=""
                                    src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <div style="padding-left: 5px;">
                <asp:PlaceHolder ID="plhLeftSide" runat="server"></asp:PlaceHolder>
            </div>
            <%--<div id="div_estimate_edit" runat="server" style="display: block">--%>
            <div id="div_estimate_edit1" style="display: block; overflow: visible; height: <%=divheight %>>">
                <div style="float: left;">
                    <ul class="glossymenu" id="divitem_form1" runat="server">
                        <li><a href="#">&nbsp;&nbsp;Print/Email Estimate</a> </li>
                        <li><a href="#">&nbsp;&nbsp;Pro Forma Invoice </a></li>
                        <li><a href="#">&nbsp;&nbsp;Print MRN</a> </li>
                        <li><a href="#">&nbsp;&nbsp;Progress To Job</a> </li>
                    </ul>
                    <ul class="glossymenu" runat="server" id="divitem_form">
                        <li style="display: none"><a href="<%=strSitepath%>estimates/estimate_add.aspx?type=edit">
                            &nbsp;&nbsp;Re-run Item</a> </li>
                        <li><a href="#" title="Add To Price Catalogue">&nbsp;&nbsp;Add to Price...</a> </li>
                        <li><a href="#">&nbsp;&nbsp;Delete</a> </li>
                        <li id="add_moreitem" runat="server" visible="true"><a href="#" onclick="javascript:AddAnotherItems();">
                            &nbsp;&nbsp;Add An Item</a> </li>
                        <li id="Li1" runat="server" visible="true"><a href="#">&nbsp;&nbsp;Send Estimate</a>
                        </li>
                        <li id="Li2" runat="server" visible="true"><a href="#">&nbsp;&nbsp;Progress To Job</a>
                        </li>
                        <li id="Li3" runat="server" visible="true"><a href="#">&nbsp;&nbsp;Attachments</a>
                        </li>
                        <li id="Li4" runat="server" visible="true"><a href="#">&nbsp;&nbsp;Notes</a> </li>
                    </ul>
                </div>
            </div>
            <%--</div>--%>
            <div id="divPrint" runat="server" style="display: block; overflow: hidden; height: 145px;
                padding-top: 5px; padding-left: 5px; padding-bottom: 5px">
                <div id="prntEstimate" runat="server" style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMaskShow_OrderAck();return false;">Print/Email Estimate</a></div>
                <div id="prntProforma" runat="server" style="padding-bottom: 5px">
                    <a href="<%=strSitepath%>invoice/invoice_add.aspx?type=edit&eid=1" onclick="">Print
                        Pro Forma Invoice </a>
                </div>
                <div id="prntInvoice" runat="server" style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMaskSupplyStore('store');return false;">Print/Email
                        Invoices </a>
                </div>
                <div id="prntMrn" runat="server" style="padding-bottom: 5px">
                    <a href="#">Print MRN</a>
                </div>
                <div id="prntNote" runat="server" style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMaskShow_Delivery_Notes_View();return false;">Print/Email
                        Delivery Note</a>
                </div>
                <div id="prntPo" runat="server" style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMaskShow_PurchaseOrders();return false;">Print/Email
                        PO </a>
                </div>
                <div id="prntAckno" runat="server" style="padding-bottom: 5px">
                    <a href="#" onclick="javascript:MakeMaskShow_OrderAck();return false;">Print Order Acknowledgement
                    </a>
                </div>
                <div id="divbtnestimate" runat="server" style="padding-bottom: 5px">
                    <asp:LinkButton ID="lnkrevertto_estimate" runat="server" Text="Revert To Estimate"
                        Width="115px" OnClick="lnkrevertto_estimate_OnClick"></asp:LinkButton></div>
                <div id="divbtnjob" runat="server" style="padding-bottom: 5px">
                    <asp:LinkButton ID="lnkprogressto_job" runat="server" Text="Progress To Job" Width="115px"
                        OnClick="lnkprogressto_job_OnClick"></asp:LinkButton></div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<asp:Panel runat="server" ID="pnlButton" Visible="false">
    <tr valign="top">
        <td>
            <%-- <asp:Button ID="btnEstimate" runat="server" Text="Revert To Estimate" CssClass="button"
                                                                                                        Width="115px" />--%>
            <asp:LinkButton ID="btnEstimate" runat="server" Text="Revert To Estimate" Width="115px"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
    <tr valign="top">
        <td>
            <%--<asp:Button ID="btnJob" runat="server" Text="Progress To Job" CssClass="button" Width="115px" />--%>
            <asp:LinkButton ID="btnJob" runat="server" Text="Progress To Job" Width="115px"></asp:LinkButton>
        </td>
    </tr>
</asp:Panel>
<%--Left Panel--%>
<%--<div id="Div_EstSummary" runat="server" visible="false">
    <asp:ImageButton runat="server" ID="tbimage" ImageUrl="~/images/Attachment.png" Style="float: left;
        outline: 0; width: 21px" />
    <div class="leftPanelBarContainer">
        <div id="slidingDiv" style="visibility: hidden">--%>
<asp:Panel runat="server" ID="pnlCustomize" Visible="false">
    <tr valign="top">
        <td>
            <%--class="BgImage_New"--%>
            <div id="div4" style="display: block;">
                <div id="divcustclose" runat="server" onclick="CustLeftPanel('none');" style="cursor: pointer;">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">
                                    <%=objLangClass.GetLanguageConversion("Options")%></strong><img alt="" src="<%=strImagepath%>opentriangle.gif"
                                        align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divcustshow" runat="server" onclick="CustLeftPanel('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">
                                    <%=objLangClass.GetLanguageConversion("Options")%></strong><img alt="" src="<%=strImagepath%>opentriangle.gif"
                                        align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <style type="text/css">
                /* this inline css is added for bugid 2392 please do not remove this css */
                #ctl00_tint_RadPanelBar_LeftPanel_i0_RadMenu_LeftPanel1
                {
                    z-index: +10 !important;
                }
                #ctl00_tint_RadPanelBar_ordSummary_i0_RadMenu_ordSummary
                {
                    z-index: +10 !important;
                }
            </style>
            <%--By Natraj--%>
            <div id="Div_OrderSummary" runat="server" visible="false">
                <telerik:RadPanelBar ID="RadPanelBar_ordSummary" runat="server" Font-Bold="true"
                    ExpandAnimation-Type="none" CollapseAnimation-Type="none" Width="159px">
                    <Items>
                        <telerik:RadPanelItem>
                            <ItemTemplate>
                                <telerik:RadMenu ID="RadMenu_ordSummary" runat="server" Flow="Vertical" Width="100%">
                                    <Items>
                                        <telerik:RadMenuItem Text="Print/Email" Font-Bold="true" Width="100%" Style="cursor: pointer">
                                            <Items>
                                                <telerik:RadMenuItem Text="All Items" Style="cursor: pointer;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Selected Items" Style="cursor: pointer;">
                                                </telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenu>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Progress to Job" Style="cursor: pointer;" Font-Bold="true"
                            onclick="javascript:ShowProgressToJobFromOrders();return false;">
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Attachments" Style="cursor: pointer;" Font-Bold="true"
                            onclick="javascript:ShowAttachments();">
                        </telerik:RadPanelItem>
                        <%-- <telerik:RadPanelItem Text="Activity History" onclick="javascript:ShowNotes();return false;"
                            Style="cursor: pointer;" Font-Bold="true">
                        </telerik:RadPanelItem>--%>
                    </Items>
                </telerik:RadPanelBar>
            </div>
            <asp:PlaceHolder ID="plhLeftPanel" runat="server"></asp:PlaceHolder>
            <div id="Div_EstSummary" runat="server" visible="false">
                <%--<asp:ImageButton runat="server" ID="tbimage" ImageUrl="~/images/Attachment.png" Style="float: left;
                    outline: 0; width: 21px" />
                <div class="leftPanelBarContainer">
                    <div id="slidingDiv" style="visibility: hidden">--%>
                <telerik:RadPanelBar ID="RadPanelBar_LeftPanel" runat="server" Font-Bold="true" ExpandAnimation-Type="none"
                    CollapseAnimation-Type="none" Width="159px" Style="z-index: 0;">
                    <Items>
                        <%-- <telerik:RadPanelItem Text="Print/Email" Font-Bold="true" Style="cursor: pointer;">
                            <Items>--%>
                        <telerik:RadPanelItem Style="z-index: 0;">
                            <ItemTemplate>
                                <telerik:RadMenu ID="RadMenu_LeftPanel1" runat="server" Flow="Vertical" Width="100%"
                                    Style="z-index: 0;">
                                    <Items>
                                        <telerik:RadMenuItem Text="Print/Emailsssss" Font-Bold="true" Width="100%" Style="cursor: pointer;
                                            z-index: 0;">
                                            <Items>
                                                <telerik:RadMenuItem Text="Customer" Style="cursor: pointer;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Supplier" Style="cursor: pointer;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Outwork Supplier" Style="cursor: pointer;">
                                                </telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenu>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                        <%--</Items>
                        </telerik:RadPanelItem>--%>
                        <telerik:RadPanelItem Text="Add Item" runat="server" Font-Bold="true" Style="cursor: pointer;">
                            <Items>
                                <telerik:RadPanelItem Style="margin-top: 10px; margin-bottom: 10px">
                                    <ItemTemplate>
                                        <telerik:RadMenu ID="RadMenu_LeftPanel" runat="server" Flow="Vertical" Width="100%">
                                            <Items>
                                                <telerik:RadMenuItem Text="Sheet Fed Digital" Width="100%">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('S');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Booklet" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('B');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('P');return false;">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Sheet Fed Offset" Width="100%">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('F');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Booklet" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('K');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="NCR" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('N');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('D');return false;">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Outwork" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('O');return false;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Product Catalogue" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('C');return false;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Other Cost" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('U');return false;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Large Format" Style="cursor: pointer;">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Linear" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('L');return false;">
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Square Meter" Style="cursor: pointer;" onclick="javascript:AddAnItem_Call('Sq');return false;">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Warehouse" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('W');return false;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Quick Quote" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('Q');return false;">
                                                </telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Delivery Cost" Style="cursor: pointer;"
                                                    onclick="javascript:AddAnItem_Call('T');return false;">
                                                </telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadMenu>
                                    </ItemTemplate>
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Progress To Job" Style="cursor: pointer; display: none"
                            Font-Bold="true" onclick="javascript:ShowProgressToJob();return false;">
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Attachments" Style="cursor: pointer;" Font-Bold="true">
                        </telerik:RadPanelItem>
                        <%-- <telerik:RadPanelItem Text="Activity History" onclick="javascript:ShowNotes();return false;"
                            Style="cursor: pointer; display: block;" Font-Bold="true">
                        </telerik:RadPanelItem>--%>
                        <telerik:RadPanelItem Text="Copy Estimate" Font-Bold="true">
                            <Items>
                                <telerik:RadPanelItem Text="To Same Customer" onclick="javascript:EstimateCopyto_SameCust();return false;"
                                    Style="cursor: pointer;">
                                </telerik:RadPanelItem>
                                <telerik:RadPanelItem Text="To New Customer" onclick="javascript:EstimateCopyto_NewCust();return false;"
                                    Style="cursor: pointer;">
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Revert To Estimate" Font-Bold="true" Style="cursor: pointer;
                            display: none;">
                        </telerik:RadPanelItem>
                        <%--<telerik:RadPanelItem runat="server" Text="Delete" Expanded="true" Selected="true"
                            Style="display: none;" Font-Bold="true">
                            <Items>
                                <telerik:RadPanelItem runat="server" Value="DeleteItems">
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>--%>
                    </Items>
                </telerik:RadPanelBar>
                <%--</div>--%>
                <%-- </div>--%>
            </div>
            <asp:HiddenField ID="hdn_PrintEmail" runat="server" Value="" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr valign="top" style="margin-top">
        <td>
            <div id="divJobCust" runat="server" style="display: none;">
                <div id="activity">
                    <%--class="BgImage_New"--%>
                    <div id="activity-header">
                        <%=objLangClass.GetLanguageConversion("Quick_Links")%></div>
                    <asp:PlaceHolder ID="plhjobLeftPanel" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </td>
    </tr>
</asp:Panel>
<%--RE-ENG ; To view the PanelBar--%>
<style type="text/css">
    .RadPanelBar, .RadPanelBar .rpSlide, .RadPanelBar .rpGroup, .RadPanelBar .rpItem, .RadPanelBar .rpTemplate
    {
        overflow: visible !important;
    }
    div.RadPanelBar .rpLevel1 .rpItem
    {
        padding: 0;
    }
    * html .RadPanelBar .RadMenu ul.rmRootGroup
    {
        zoom: 1;
    }
    div.RadMenu .rmRootGroup
    {
        border: 0;
    }
    div.RadMenu .rmLink
    {
        float: none;
    }
    .leftPanelBarContainer
    {
        float: left;
        width: 250px;
        height: 250px;
        overflow: auto;
        position: relative; /* Required to workaround IE rendering bug*/
    }
</style>
<%--
<script>
    var panelDomElement = $get('<%=RadPanelBar_LeftPanel.ClientID %>');
    var timage = $get('<%= tbimage.ClientID %>');

    if (panelDomElement) {
        SetUpAnimation(timage.id, Telerik.Web.UI.jSlideDirection.Right, panelDomElement);
    }
    function SetUpAnimation(image, direction, element) {
        element.style.position = "relative";
        var slider = document.getElementById(image);

        var expanded = false;

        var expandAnimation = new Telerik.Web.UI.AnimationSettings({});
        var collapseAnimation = new Telerik.Web.UI.AnimationSettings({});

        var slide = new Telerik.Web.UI.jSlide(element, expandAnimation, collapseAnimation, false);

        slide.initialize();

        slide.set_direction(direction);

        slider.onclick = function() {
            element.parentNode.style.visibility = "visible";
            element.parentNode.style.display = "block";
            if (!expanded) {
                slide.expand();
            }
            else {
                slide.collapse();
            }
            expanded = !expanded;
            return false;
        }
    }
</script>--%>
<asp:Panel runat="server" ID="pnlCustomize2" Visible="false">
    <tr valign="top">
        <td>
            <%--class="BgImage_New"--%>
            <div id="div5" style="display: block;">
                <div id="divcustclose2" runat="server" onclick="CustLeftPanel2('none');" style="cursor: pointer;">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Options</strong><img alt=""
                                    src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divcustshow2" runat="server" onclick="CustLeftPanel2('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 83px">Options</strong><img alt=""
                                    src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <asp:PlaceHolder ID="plhLeftPanel2" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</asp:Panel>
<asp:HiddenField ID="hdnPCPath" runat="server" Value="" />
<asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
<asp:HiddenField ID="editViewID" runat="server" Value="0" />
<asp:HiddenField ID="CompanyID_change" runat="server" />
<asp:HiddenField ID="hidchkDeletepo" runat="server" Value="false" />
<asp:HiddenField ID="hidchkDeleteDel" runat="server" Value="false" />
<asp:HiddenField ID="hdnReduceStockTypeForCancelledNew" Value="false" runat="server" />
<asp:HiddenField ID="hdnStockCancelChk" runat="server" Value="false" />
<asp:LinkButton ID="lnk_RevertToJob" runat="server" OnClick="btnAddTraining_Click"
    Style="display: none" />
<asp:HiddenField ID="hdnOrderID" Value="0" runat="server" />
<asp:HiddenField ID="hdnEstimateID" Value="0" runat="server" />
<%--<div id="divBackGroundNew" style="display: none;">
</div>--%>
<script>
    var strSitepath = '<%=strSitepath  %>';
    var CompanyID_change = document.getElementById("<%=CompanyID_change.ClientID %>");
    var hdnReduceStockTypeForCancelledNew = document.getElementById("<%= hdnReduceStockTypeForCancelledNew.ClientID%>");
    var hidchkDeletepo = document.getElementById("<%= hidchkDeletepo.ClientID%>");
    var hidchkDeleteDel = document.getElementById("<%= hidchkDeleteDel.ClientID%>");
    var ManageStockPermission = '<%=ManageStockPermission  %>';
    var StockCancellationType = '<%=StockCancellationType  %>';
    var hdnEstimateID = document.getElementById("<%=hdnEstimateID.ClientID%>");

    function editview() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_job() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_invoice() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_order() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_purchase() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_delivery() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_inventory() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_store() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View1');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_item() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View2');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_campaign() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_sectionView_ddl_View');
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function Copy_campaign() {
        var editViewID = document.getElementById("<%=editViewID.ClientID %>");
        editViewID.value = campaignid;
    }



    function CheckchkOne(type) {
        var PageType = '<%=PageType %>';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        var Ides = "";

        hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                }
            }
        }
        hdnIDs.value = Ides;

        if (Number(Counter) == 0) {
            if (type == "delete") {
                alert("Please check at least one row to Delete");
            }
            else if (type == "archive") {
                alert("Please check at least one row to Archive");
            }
            else if (type == "unarchive") {
                alert("Please check at least one row to Un-Archive");
            }
            return false;
        }
        else {
            var check = "";
            if (type == "delete") {
                check = window.confirm('Are you sure you want to delete this record(s)?');
            }
            else if (type == "archive") {
                check = window.confirm('Are you sure you want to archive this record(s)?');
            }
            else if (type == "unarchive") {
                check = window.confirm('Are you sure you want to un-archive this record(s)?');
            }
            if (check) {
                if (type == "delete") {
                    if (PageType == "purchase") {
                        DeletePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        DeleteDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        DeleteOrder(Ides);
                    }
                    else {
                        DeleteInv();
                    }
                }
                else if (type == "archive") {
                    if (PageType == 'estimate') {
                        ArchiveEstimate();
                    }
                    else if (PageType == 'job') {
                        ArchiveJob();
                    }
                    else if (PageType == 'invoice') {
                        ArchiveInvoice();
                    }
                    else if (PageType == "purchase") {
                        ArchivePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        ArchiveDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        ArchiveOrder(Ides);
                    }
                    else {
                        ArchiveInv();
                    }
                }
                else if (type == "unarchive") {
                    UnArchiveInv();
                }
                return false;
            }
            else {
                return check;
            }
            //  return true;
        }
    }

    function DelArc_Estimate(type) {
        var PageType = '<%=PageType %>';
        var check = "";
        if (type == "delete") {
            check = window.confirm('Are you sure you want to delete this record?');
        }
        else {
            check = window.confirm('Are you sure you want to archive this record?');
        }
        if (check) {
            if (PageType == 'estimate' && type == "archive") {
                Archive_Estimate();
            }
            else if (PageType == 'estimate' && type == "delete") {
                Delete_Estimate();
            }
            //return false;
        }
        else {
            return check;
        }
    }
    function CheckchkOnlyOne() {
        var PageType = '<%=PageType %>';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
        var Ides = "";
        var EstIDs = "";
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                    if (PageType == 'job' || PageType == 'invoice') {
                        var EstimateID = document.getElementById("hid_EstimateID_" + e.value + "").value;
                        EstIDs = EstIDs + EstimateID + ",";
                    }
                }
            }
        }
        hdnIDs.value = Ides;
        if (Number(Counter) == 0) {
            if (PageType == 'estimate') {
                alert("Please select at least one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == 'job') {
                alert("Please select at least one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                // alert("Please select at least one Purchase to Copy To New Purchase");
                alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Purchase_To_Copy_To_New_Purchase")%>');
                return false;
            }
        }
        else if (Number(Counter) == 1) {
            if (PageType == 'estimate') {
                CopyEstimate();
                return false;
            }
            else if (PageType == 'job') {
                CopyJob(Ides, EstIDs);
                return false;
            }
            else if (PageType == 'invoice') {
                CopyInvoice(Ides, EstIDs);
                return false;
            }
            else if (PageType == "purchase") {
                CopyPurchase(Ides);
                return false;
            }
        }
        else if (Number(Counter) > 1) {
            if (PageType == 'estimate') {
                alert("Please select only one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == "job") {
                alert("Please select only one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                alert("Please select only one Purchase to Copy To New Purchase");
                return false;
            }
        }
    }
</script>
<script type="text/javascript">
    function hideDivNew1() {
        document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');

    }

    function Save1(val) {

        if (val == 'Y') {

            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');

        }
        else {

            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        }
    }

    function RevertJobNew() {
        var chkInvadjusted = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkInvadjusted");
        if (chkInvadjusted.checked) {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
        }
        else {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        }

        var chkDeletepo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeletepo");
        var chkDeleteDel = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeleteDel");
        if (chkDeletepo.checked) {
            hidchkDeletepo.value = "true";
        }
        if (chkDeleteDel.checked) {
            hidchkDeleteDel.value = "true";
        }
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        return false;
    }
</script>
<script>
    var menuids = new Array("verticalmenu", "jobverticalmenu") //Enter id(s) of UL menus, separated by commas                
    var submenuoffset = -2 //Offset of submenus from main menu. Default is -2 pixels.

    function createcssmenu() {
        //           for(var i=0;i<menuids.length;i++)
        //           {
        //              var ultags=document.getElementById(menuids[i].getElementsByTagName("ul"));
        //              alert(ultags.length);
        //           }
        for (var i = 0; i < menuids.length; i++) {
            var ultags = '';
            try {
                ultags = document.getElementById(menuids[i]).getElementsByTagName("ul")
            }
            catch (err) {
            }

            for (var t = 0; t < ultags.length; t++) {
                var spanref = document.createElement("span")

                spanref.className = "arrowdiv";
                spanref.innerHTML = "&nbsp;&nbsp;";

                //ultags[t].parentNode.getElementsByTagName("a")[0].appendChild(spanref)

                ultags[t].parentNode.onmouseover = function () {
                    this.getElementsByTagName("ul")[0].style.left = this.parentNode.offsetWidth + submenuoffset + "px";
                    this.getElementsByTagName("ul")[0].style.display = "block";
                }
                ultags[t].parentNode.onmouseout = function () {
                    this.getElementsByTagName("ul")[0].style.display = "none"
                }
            }


        }
    }


    if (window.addEventListener)
        window.addEventListener("load", createcssmenu, false)
    else if (window.attachEvent)
        window.attachEvent("onload", createcssmenu)
</script>
<script type="text/javascript" language="javascript">
    function set_height(divid, divheight) {

        document.getElementById("div6").style.height = "140px";
    }
    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }

    function estimate(val) {

        //ctl00_divrecentitem1.style.display=val;
        if (val == 'none') {
            //recentitems.slideup();divrecentitem
            //slideup('divrecentitem_1');
            //ctl00_tint_divestimateopen.style.display='block';
            //ctl00_tint_divestimateclosed.style.display='none';
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'none';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'block';
            document.getElementById("divrecentitem_1").style.display = 'none';
            //WriteCookie('NO3');
        }
        else {
            //ctl00_divrecentitem1_1.style.display=val;
            //recentitems.slidedown();
            // slidedown('divrecentitem_1');
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'block';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'none';
            document.getElementById("divrecentitem_1").style.display = 'block';
            //ctl00_recentitem.style.display='block';
            //WriteCookie('YES3');
        }
    }
</script>
<script>
    //====== Customized Left panel  ========//
    function CustLeftPanel(val) {
        if (val == 'none') {
            //            slideup('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='block';
            //            ctl00_tint_divcustclose.style.display='none';     
            document.getElementById("ctl00_tint_divcustclose").style.display = 'none';
            document.getElementById("ctl00_tint_divcustshow").style.display = 'block';
            document.getElementById("divCustContent").style.display = 'none';
        }
        else {
            //            slidedown('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='none';
            //            ctl00_tint_divcustclose.style.display='block';   
            document.getElementById("ctl00_tint_divcustclose").style.display = 'block';
            document.getElementById("ctl00_tint_divcustshow").style.display = 'none';
            document.getElementById("divCustContent").style.display = 'block';
        }
    }

    function CustLeftPaneljob(val) {
        if (val == 'none') {
            //document.getElementById("ctl00_tint_divjobcustclose").style.display = 'none';
            // document.getElementById("ctl00_tint_divjobcustshow").style.display = 'block';
            //document.getElementById("divjobCustContent").style.display = 'none';
        }
        else {
            //document.getElementById("ctl00_tint_divjobcustclose").style.display = 'block';
            //document.getElementById("ctl00_tint_divjobcustshow").style.display = 'none';
            //document.getElementById("divjobCustContent").style.display = 'block';
        }
    }

    function CustLeftPanel2(val) {
        if (val == 'none') {
            //            slideup('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='block';
            //            ctl00_tint_divcustclose.style.display='none';     
            document.getElementById("ctl00_tint_divcustclose2").style.display = 'none';
            document.getElementById("ctl00_tint_divcustshow2").style.display = 'block';
            document.getElementById("divCustContent2").style.display = 'none';
        }
        else {
            //            slidedown('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='none';
            //            ctl00_tint_divcustclose.style.display='block';   
            document.getElementById("ctl00_tint_divcustclose2").style.display = 'block';
            document.getElementById("ctl00_tint_divcustshow2").style.display = 'none';
            document.getElementById("divCustContent2").style.display = 'block';
        }
    }    
</script>
<script>
    function CallConfirm() {
        var ret = window.confirm("Are you sure you want to create delivery note against this job?");
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }
   
</script>
<%--Sachin --%>
<script>
    //    $(document).ready(function() {
    //        $("#imgleftpanelClick").click(function(event) {

    //            event.preventDefault();
    //            $("#divLeftpanel").fadeOut(0);

    //            document.getElementById("RightPanel").style.display = "none";
    //            $("#RightPanel").fadeOut(0);
    //            $("#tdLeftpanel").fadeIn(0);
    //            $("#RightPanel").fadeIn(0);
    //            setCookie('username', "open", 2);
    //            checkCookie();


    //        });
    //        $("#imgClosepanel").click(function(event) {

    //            setCookie('username', "close", 2);
    //            checkCookie();

    //            event.preventDefault();

    //            $("#tdLeftpanel").fadeOut(0);
    //            document.getElementById("tdLeftpanel").style.display = "none";
    //            document.getElementById("RightPanel").style.display = "none";

    //            $("#divLeftpanel").fadeIn(0);
    //            $("#RightPanel").fadeIn(0);
    //        });
    //    });

    // By Pradeep
    function Open_ProductCatalogue(EstItemID, EstId, i) {
        var hdnEstType = document.getElementById("hdnEstType_" + i).value;
        var strTypes = hdnEstType.split('~')
        var strPath = document.getElementById("ctl00_tint_hdnPCPath").value;
        window.location = strPath + "?EstID=" + EstId + "&EstItemID=" + EstItemID + "&ToConvert=Yes&EstType=" + strTypes[0] + "&pgFrom=" + strTypes[1] + "";
        //window.location = strPath;
    }

    //    function Edit_ProductCatalogue(id) {        
    //        var strPath = document.getElementById("ctl00_tint_hdnPCPath").value;
    //        window.open(strPath + "?action=edit&id=" + id + "", '_blank');
    //    }
    //End By Pradeep

    function OpenCreateInvoice(EstID) {
        var hdnOrderID = document.getElementById("<%=hdnOrderID.ClientID%>");
        var url = window.location.href;
        var module;
        //alert(url.indexOf("Jobs/job"));
        if (url.toLowerCase().indexOf("job_order_summary") != -1) {
            module = "ProgressToInvoiceFromOrder";
        }
        else if (url.toLowerCase().indexOf("job_summary_reeng") != -1) {
            module = "ProgressToInvoiceFromJob";
        }

        var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + EstID + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID.value);
        //        SetRadWindow('divrad', 'divBackGroundNew', '200');
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(510, 520);
        RadWindow_Paid.center();
        //        var a = ProgressJob_reeng();
        //                return a;
        return false;
    }

    function OpenCreateInvoiceForRecordView(EstID, IsJobFromWebstore) {      
        var RadWindow_Paid = window.radopen("<%=strSitepath %>common/Invoice_Paid.aspx?EstimateID=" + EstID + "&IsPaid=1&Module=JobRecordView&&IsJobFromWebstore=" + IsJobFromWebstore + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(680, 500);
        RadWindow_Paid.center();
        return false;
    }
</script>
