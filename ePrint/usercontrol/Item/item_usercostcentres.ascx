<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_usercostcentres.ascx.cs" Inherits="ePrint.usercontrol.Item.item_usercostcentres" %>

<%@ Register TagPrefix="UC" TagName="addnewcostcentre" Src="~/usercontrol/Item/item_addnew_costcentre.ascx" %>
<div id="costcentre" style="width: 100%; display: block;">
    <div id="div_costcenterheader" style="width: 100%; display: none" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Select Cost Centre</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('div_cost_centre');" style="color: White;">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="div_costcenterborder">
        <div align="left" style="width: 100%">
            <div style="clear: both; height: 10px;">
                &nbsp;</div>
            <div align="left" style="display: block; width: 100%; border: solid 0px blue;">
                <div id="ynnav" style="width: 90%; white-space: normal; float: left; border: solid 0px blue;
                    border-top: solid 0px gainsboro;">
                    <ul>
                        <asp:PlaceHolder ID="plhTab" runat="server"></asp:PlaceHolder>
                        <div id="div_other_tab"></div>
                        <asp:HiddenField ID="hid_OtherCostValues" runat="server" Value="" />
                    </ul>
                </div>
                <div class="onlyEmpty">
                </div>
                <div class="divBorderItem">
                    <div class="only5px">
                    </div>
                    <div align="left" style="width: 80%;">
                        <div id="divHeader" align="left" style="width: 100%; border: 1px solid silver;">
                            <div align="left" style="width: 100%; height: 23px; display: block;" class="bgCustomize"
                                id="divsubheader">
                                <div style="float: left; width: 48%; padding: 2px" class="navigatorpanel">
                                    <b>Name</b>
                                </div>
                                <div style="float: left; width: 49%; padding: 2 2 2 0px;" class="navigatorpanel">
                                    <b>Description</b>
                                </div>
                            </div>
                            <div id="divContent" align="left" style="width: 100%; height: 300px; overflow-y: scroll;
                                overflow-x: hidden">
                            </div>
                        </div>
                        <asp:HiddenField ID="hid_OtherCostValues_Load" runat="server" Value="" />
                    </div>
                    <div class="only10px">
                    </div>
                </div>
                <div style="float: left; width: 49%">
                    <div class="box">
                        <div id="div_OtherCostItems" style="position: absolute; display: none; z-index: 5000;
                            width: 300px; height: 75px;">
                            <div align="left" class="bgcustomize" style="padding: 2px; padding-right: 0px;">
                                <div style="float: left; width: 175px">
                                    <span class="navigatorpanel" style="vertical-align: middle; text-align: left;">Item
                                        Name</span>
                                </div>
                                <div style="float: left; width: 50px;">
                                    <span class="navigatorpanel" style="text-align: left;"></span>
                                </div>
                                <div align="right" style="float: right;">
                                    <a href="#" onclick="javascript:CloseOtherCostItems('m');return false;">
                                        <img src="<%=strImagepath%>close1.jpg" title="Close" border="0" width="10px" height="10px" /></a></div>
                                <div style="clear: both">
                                </div>
                                <div id="div_OtherCostItems_Add" align="left" class="divborderItem" style="overflow-y: scroll;
                                    clear: both; padding: 2px; height: 100px; background-color: white;">
                                </div>
                            </div>
                        </div>
                        <a id="href_ShowOtherCost" href="#" onclick="javascript:ShowOtherCostItems('m');return false;"
                            style="display: none"><b>Show Other Cost Items</b></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <div align="left" id="div_OtherCost_Qty" class="CenterDiv" style="float: left; position: absolute;
        display: none; height: 100px; width: 400px; padding: 0px; left: 30%; top: 50%;">
        <div class="onlyEmpty">
        </div>
        <div class="removeTrancy">
            <div align="center" class="bgcustomize" style="width: 100%; padding: 3px 0px 3px 0px;">
                <div style="float: left; width: 95%; border: 0px solid">
                    <span class="navigatorpanel" style="vertical-align: middle">Quantity</span></div>
                <div style="float: right; border: 0px solid">
                    <a href="#" onclick="javascript:ShowOtherCostQtyDiv('close');return false;">
                        <img src="<%=strImagepath%>close1.jpg" border="0" width="11px" height="11px" title="Close" /></a></div>
                <div style="clear: both">
                </div>
            </div>
            <div align="left" class="CenterDivTopBorder">
                <div class="onlyEmpty" style="height: 3px;">
                </div>
                <div align="left" style="width: 99%; padding-left: 3px">
                    <div class="bglabel">
                        <asp:Label ID="Label135" runat="server" Text="Required Stock Qty"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtOtherCostQty" SkinID="textPad" runat="server" MaxLength="8" onblur="CallonBlur(this.value,'spn_txtOtherCostQty');IsIntegerParameter(this.value,'spn_txtOtherCostQty_number');"></asp:TextBox>
                        <span id="spn_txtOtherCostQty" class="spanerrorMsg" style="display: none; width: 175px;">
                            Please enter Stock Qty </span><span id="spn_txtOtherCostQty_number" class="spanerrorMsg"
                                style="display: none; width: 175px;">Please enter numeric value </span>
                    </div>
                </div>
                <div class="onlyEmpty" style="height: 5px;">
                    <span></span>
                </div>
                <div align="left">
                    <div style="float: left; width: 40%;">
                        &nbsp;
                    </div>
                    <div style="float: left;">
                        <div style="float: left;">
                            <asp:Button ID="Button6" CssClass="button" Text="Add" Width="65px" runat="server"
                                OnClientClick="javascript:AddThisOtherCostItem(); return false;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    var hid_OtherCostValues_Load = document.getElementById("<%=hid_OtherCostValues_Load.ClientID %>");
    var rowcount = '<%=rowcount %>';
    var txtOtherCostQty = document.getElementById("<%=txtOtherCostQty.ClientID %>");
    
</script>

