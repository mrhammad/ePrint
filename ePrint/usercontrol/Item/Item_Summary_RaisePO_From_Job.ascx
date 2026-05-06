<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_Summary_RaisePO_From_Job.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_Summary_RaisePO_From_Job" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div id="Div_MainPORaise" style="width: 600px; word-break: break-word;">


    
        


    <table cellpadding="0" cellspacing="0" width="600px">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">&nbsp;
            </td>
            <td class="popup-top-middlebg" style="width: 600px;">
                <table width="100%">
                    <tr>
                        <td>
                            <div class="Label-PopupHeading" style="padding-top: 6px; padding-left: 1px; float: left;">
                                <div>
                                    <span><b>Create Purchase For Items </b></span>
                                </div>
                            </div>
                            <div style="float: right;">
                                <div class="CancelButtonDiv" style="position: relative; float: right; margin-top: -15px; right: -15;">
                                    <asp:ImageButton ID="ImageButton6" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                        runat="server" CausesValidation="false" OnClientClick="javascript:hideDiv1('close');return false;" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td colspan="2" class="popup-top-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">&nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">&nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <asp:Panel ID="pnlcreatePo" runat="server" Height="240">
                    <div align="left" style="width: 100%">
                        <div align="left">
                            <div align="left">
                                <div align="left" style="width: 100%">
                                    <div align="left" style="width: 100%">
                                        <div>
                                            <span id="spn_checkPO" style="display: none; color: Red">Please Select at least 1 Item
                                                to create Purchase Order</span>
                                        </div>
                                        <div style="clear: both">
                                            &nbsp;
                                        </div>
                                        <span id="spnPOCreate" style="display: inline;" runat="server">Select the item or items
                                            for the purchase order.</span><span runat="server" id="spnNoItemsTocreatePO" style="display: none;">
                                                There are no items remaining for which you haven't already created a Purchase Order.</span>
                                        <span id="spnReplenishment" style="display: none; float:right;  font-weight: bold; width: 125px;" runat="server">Replenishment</span>
                                        <div align="left" style="width: 100%; padding: 5px;">
                                            <a href="javascript:SelectAll1();" id="lnkSelectAll" style="font-size: 0.8em;">
                                                <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                        </div>
                                       <%-- <span id="spnReplenishment" style="display: none; text-align: right; width: 500px;" runat="server"><b>Replenishment</b></span>--%>
                                        <div style="float: left; width: 5px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 100%;">
                                            <asp:Panel ID="pnlpurchase" runat="server" Width="100%">
                                                <div style="float: left; margin-top: 3px; width: 100%; height: 150px; overflow: auto;">
                                                    <asp:PlaceHolder ID="plhpurchase" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </asp:Panel>

                                            <div id="divRadPO" style="display:none" runat="server">
                                                <asp:Panel ID="pnlradiopurchase" runat="server">
                                                    <span id="spnRadPO" runat="server">Please choose PO</span>
                                                    <asp:RadioButtonList runat="server" ID="radioButtonList" />
                                                </asp:Panel>

                                                <asp:HiddenField id="hdisCombinedPO" runat="server"/>
                                                <asp:HiddenField id="hdnCombinedValue" runat="server"/>
                                                <asp:HiddenField id="hdnIsPOPup" runat="server"/>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 100%; height: 30%">
                                <div style="clear: both">
                                    &nbsp;
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; width: 38%">
                                    &nbsp;
                                </div>
                                <div id="div17" style="float: left; margin-left: 4px;">
                                    <div id="div_btncreatepo" style="display: block">
                                        <asp:Button ID="btnCreatePo" runat="server" Text="Create PO" CssClass="button" OnClientClick="javascript:var a=ValidateCreateMultiplePo_reeng();if(a)loadingimg('div_btncreatepo','div_createpoprocess');return a;"
                                            OnClick="Onclick_btnCreatePo" />
                                        <asp:HiddenField ID="hidPoCount" runat="server" />
                                        <asp:HiddenField ID="hidPoEnable" runat="server" />
                                        <asp:HiddenField ID="hid_AdditionalItemIDs" runat="server" />
                                        <asp:LinkButton ID="lnkCreatePo" runat="server" OnClick="Onclick_btnCreatePo" Text=""></asp:LinkButton><%----%>
                                        <asp:HiddenField ID="hdnPOforPaperSupplied" runat="server" Value="" />
                                    </div>
                                    <div id="div_createpoprocess" class="button" align="center" style="width: 65px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </td>
            <td style="width: 10px; background-color: #ffffff">&nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
            </td>
            <td class="popup-bottom-middlebg">&nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_Po1Count" runat="server" Value="no" />
    <asp:HiddenField ID="hdnProductAddItemsIDs" runat="server" />
    <asp:HiddenField ID="hdnProductAddItemsIDs_PO" runat="server" />
    <script language="javascript" type="text/javascript">
        var hdnProductAddItemsIDs = document.getElementById("<%=hdnProductAddItemsIDs.ClientID %>");
        var hdnProductAddItemsIDs_PO = document.getElementById("<%=hdnProductAddItemsIDs_PO.ClientID %>");
        var lnkSelectAll = document.getElementById("lnkSelectAll");

        var hidPoEnable = document.getElementById("<%=hidPoEnable.ClientID %>");
        var hidPoCount = document.getElementById("<%=hidPoCount.ClientID %>");
        var btnCreatePo = document.getElementById("<%=btnCreatePo.ClientID %>");
        var hid_AdditionalItemIDs = document.getElementById("<%=hid_AdditionalItemIDs.ClientID %>");
        var hid_Po1Count = document.getElementById("<%=hid_Po1Count.ClientID %>");
        var ProductPOCount = '<%=ProductPOCount %>';
        var chk = hidPoCount.getElementsByTagName('input');


        function selectone(id) {

            if (id.indexOf("chkProductPO_0_") != -1) {

                var replacedid = id.replace("chkProductPO_0_", "chkPo_0_");
                var chkPo = document.getElementById(replacedid);
                chkPo.checked = false;
            }
            else if (id.indexOf("chkPo_0_") != -1) {
                var replacedid = id.replace("chkPo_0_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;
            }
        }
        function selectoneForLargeItem(id) {

            if (id.indexOf("chkProductPO_0_") != -1) {
                for (var i = 0; i < 5; i++) {
                    try {
                        var replacedid = id.replace("chkProductPO_0_", "chkPo_" + i + "_");
                        var chkPo = document.getElementById(replacedid);
                        chkPo.checked = false;
                    } catch (Error) { }
                }
            }
            else if (id.indexOf("chkPo_0_") != -1) {
                var replacedid = id.replace("chkPo_0_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;

            }
            else if (id.indexOf("chkPo_1_") != -1) {
                var replacedid = id.replace("chkPo_1_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;

            }
            else if (id.indexOf("chkPo_2_") != -1) {
                var replacedid = id.replace("chkPo_2_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;

            }
            else if (id.indexOf("chkPo_3_") != -1) {
                var replacedid = id.replace("chkPo_3_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;

            }
            else if (id.indexOf("chkPo_4_") != -1) {
                var replacedid = id.replace("chkPo_4_", "chkProductPO_0_");
                var chkProductPO_ = document.getElementById(replacedid);
                chkProductPO_.checked = false;
            }
        }
        function SelectAll1() {
            debugger
            var inputs = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_pnlpurchase").getElementsByTagName('input');
            //var MainPoCount = Number(hidPoCount.value)
            if (lnkSelectAll.innerHTML.trim() == '<%=objlang.GetLanguageConversion("Select_All_Columns") %>') {
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type.toLowerCase() == 'checkbox' && inputs[i].id.indexOf("chkPo") != -1) {
                        if (!inputs[i].disabled) {
                            inputs[i].checked = true;
                        }
                    }
                }
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
            }
            else {
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type.toLowerCase() == 'checkbox') {
                        inputs[i].checked = false;
                    }
                }
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_All_Columns") %>';
            }
        }

        //----------------------------------


    </script>
</div>
