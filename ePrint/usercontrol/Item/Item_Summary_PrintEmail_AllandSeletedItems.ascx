<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_Summary_PrintEmail_AllandSeletedItems.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_Summary_PrintEmail_AllandSeletedItems" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div style="float: left; width: 100%; clear: both;">
    <table cellpadding="0" cellspacing="0" width="100%" height="82%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                    padding-left: 1px">
                    <b>
                        <%=objLanguage.GetLanguageConversion("Print_Email_To_Selected_Items")%></b>
                    <asp:Label ID="Label5" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton7" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv();return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
            
            
        </tr>

        <tr>
            <%--<td  colspan="5" class="popup-middlebg" align="center" style="border: 0px solid red;">
                <div style="align:left">
                <input type="radio" name="items" value="checkItems" onclick="javascript: checkItems();" checked> Select All
                <input type="radio" name="items" value="uncheckItems" onclick="javascript: uncheckItems();"> Deselect All
                    </div>
            </td>--%>

        </tr>

        <tr>
                                    
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>

            <td class="popup-middlebg" align="center" style="border: 0px solid red;">
                <table cellpadding="0" cellspacing="0" border="0" width="99%" height="100%" id="tbl_PrintandEmail">
                    <tr>
          <%-- <td class="popup-top-leftcorner">
                <input type="radio" name="items" value="checkItems" onclick="javascript: checkItems();" checked> Select All
            </td>
            <td class="popup-top-rightcorner">
                <input type="radio" name="items" value="uncheckItems" onclick="javascript: uncheckItems();"> Deselect All
            </td>--%>
                        <td>
                            <div>
                                
                <div style="align-content:center">
                <input type="radio" name="items" value="checkItems" onclick="javascript: checkItems();" checked> Select All
                <input type="radio" name="items" value="uncheckItems" onclick="javascript: uncheckItems();"> Deselect All
                    <br />
                    <br />
                    </div>
            
                            </div>
                            <div id="lstItems" style="border: 0px solid green; height: 300px; overflow-y: scroll; overflow-x: hidden;  word-break: break-word;">
                                <asp:PlaceHolder ID="Plh_PrintEmail" runat="server"></asp:PlaceHolder>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div align="center">
                                <div id="div_btnprintemail" style="display: block">
                                    <asp:Button ID="btnPrintEmail" CssClass="button" runat="server" Text="Print/Email"
                                        OnClientClick="javascript:var a=GetSelectedPrintItemIDs();if(a)loadingimg('div_btnprintemail','div_btnprintemailprocess');return a;"
                                        OnClick="btnPrintEmail_Click" />
                                </div>
                                <div id="div_btnprintemailprocess" class="button" align="center" style="width: 67px;
                                    display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress ID="upProgress" runat="server">
                                    <ProgressTemplate>
                                        <div id="div_Pro_Load" class="loading_new">
                                            <UC:Loading ID="ucLoading_Pro" runat="server" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField runat="server" ID="hdnPrintURL" />
    <asp:HiddenField runat="server" ID="hdnProofAppvedURL" />
    <asp:HiddenField runat="server" ID="hdnSelectedItemsID" />
</div>
<script language="javascript" type="text/javascript">
    function GetSelectedPrintItemIDs() {
        
        var hdnSelectedItemsID = document.getElementById("<%=hdnSelectedItemsID.ClientID%>");
        hdnSelectedItemsID.value = '';
        var mainTable = document.getElementById("tbl_PrintandEmail");

        var allCheckBoxes = mainTable.getElementsByTagName("input");
        var isanyCheckBoxChecked = false;

        for (var d = 0; d < allCheckBoxes.length; d++) {
            if (allCheckBoxes[d].type == 'checkbox')
                if (allCheckBoxes[d].checked) {
                    isanyCheckBoxChecked = true;
                    hdnSelectedItemsID.value += allCheckBoxes[d].id.replace('ctl00_ContentPlaceHolder1_UCItemSummaryMain_PrintandEmail_All_SeletedItems_ChkPrintEmail_', '') + ',';
                }
            //                else {
            //                    if ('<%=Module %>' == 'webstoreorder') {
            //                        hdnSelectedItemsID.value += allCheckBoxes[d].id.replace('ctl00_ContentPlaceHolder1_UCItemSummaryMain_PrintandEmail_All_SeletedItems_ChkPrintEmail_', '') + ',';
            //                    }
            //                    else {
            //                        hdnSelectedItemsID.value += allCheckBoxes[d].id.replace('ctl00_ContentPlaceHolder1_UCItemSummaryMain_PrintandEmail_All_SeletedItems_ChkPrintEmail_', '') + ',';
            //                    }
            //                }
        }

        if (isanyCheckBoxChecked == false) {
            alert('Please select at least one item to Print.')
            return false;
        }

        var hdnPrintURL = document.getElementById("<%=hdnPrintURL.ClientID%>");
        var hdn_PrintEmail = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_hdn_PrintEmail");
        hdnPrintURL.value = hdn_PrintEmail.value;
        debugger;
        var hdnProofAppvedURL = document.getElementById("<%=hdnProofAppvedURL.ClientID%>");
        var hdn_ProofApproved = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_hdn_ProofApprovedEmail");
        hdnProofAppvedURL.value = hdn_ProofApproved.value;

    }

    function checkItems() {
        //$('#' + 'lstItems' + ' :checkbox:not([disabled])').attr('checked', true);
        $('#' + 'lstItems' + ' :checkbox').attr('checked', true);
    }


    function uncheckItems() {
        //$('#' + 'lstItems' + ' :checkbox:not([disabled])').attr('checked', false);
        $('#' + 'lstItems' + ' :checkbox').attr('checked', false);
    }

</script>
