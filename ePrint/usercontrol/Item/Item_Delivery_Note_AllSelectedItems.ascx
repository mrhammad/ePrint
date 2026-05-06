<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_Delivery_Note_AllSelectedItems.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_Delivery_Note_AllSelectedItems" %>

<%@ Register src="~/usercontrol/settings/Loading.ascx" tagname="Loading" tagprefix="UC" %>

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
                        <%=objLanguage.GetLanguageConversion("Delivery_Note")%></b>
                    <asp:Label ID="Label5" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton7" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:CloseDiv();return false;" />
                    </div>
                </div>
                <%--<uc1:loading ID="Loading1" runat="server" />--%>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
            
            
        </tr>

        <tr>            

        </tr>

        <tr>
                                    
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>

            <td class="popup-middlebg" align="center" style="border: 0px solid red;">
                <table cellpadding="0" cellspacing="0" border="0" width="99%" height="100%" id="tbl_CreateDelivery">
                    <tr>
          
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
                                <div id="div_createDelNote" style="display: block">
                                    <asp:Button ID="btnCreateDeliveryNote" CssClass="button" runat="server" Text="Create Delivery Note" 
                                        OnClientClick="javascript:var a=GetSelectedPrintItemIDs123();if(a)loadingimg('div_createDelNote','div_btncreatedelprocess'); return false;"
                                         />
                                </div>
                                <div id="div_btncreatedelprocess" class="button" align="center" style="width: 67px;
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
    function GetSelectedPrintItemIDs123() {
        debugger;
        var hdnSelectedItemsID = document.getElementById("<%=hdnSelectedItemsID.ClientID%>");
        hdnSelectedItemsID.value = '';
        var mainTable = document.getElementById("tbl_CreateDelivery");

        var allCheckBoxes = mainTable.getElementsByTagName("input");
        var isanyCheckBoxChecked = false;

        for (var d = 0; d < allCheckBoxes.length; d++) {
            if (allCheckBoxes[d].type == 'checkbox')
                if (allCheckBoxes[d].checked) {
                    isanyCheckBoxChecked = true;
                    //hdnSelectedItemsID.value += allCheckBoxes[d].id.replace('ctl00_ContentPlaceHolder1_UCItemSummaryMain_DeliveryNote_All_SeletedItems_ChkPrintEmail', '') + 'µ';
                    hdnSelectedItemsID.value += allCheckBoxes[d].id.replace('ctl00_ContentPlaceHolder1_UCItemSummaryMain_DeliveryNote_All_SeletedItems_ChkCreateDelivery_', '') + 'µ';
                }
           
        }

        if (isanyCheckBoxChecked == false) {
            alert('Please select at least one item to create delivery note.')
            return false;
        }

        //var elem = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_DeliveryNote_All_SeletedItems_btnCreateDeliveryNote");
        //__doPostBack('btnCreateDeliveryNote', 'OnClick');

        OpenMultiDeliveryNoteByItemId(hdnSelectedItemsID.value);

        //var userName = "Shekhar Shete";
       // '<%Session["SelectedItemsCreateDeliveryNote"] = "' + hdnSelectedItemsID.value + '"; %>';
       // alert('<%=Session["SelectedItemsCreateDeliveryNote"] %>');

       // OpenMultiDeliveryNote();

       // var hdnPrintURL = document.getElementById("<%=hdnPrintURL.ClientID%>");
        //var hdn_PrintEmail = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_hdn_PrintEmail");
        //hdnPrintURL.value = hdn_PrintEmail.value;       
        //var hdnProofAppvedURL = document.getElementById("<%=hdnProofAppvedURL.ClientID%>");
        //var hdn_ProofApproved = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_hdn_ProofApprovedEmail");
        //hdnProofAppvedURL.value = hdn_ProofApproved.value;      

    }

    function checkItems() {
      
        $('#' + 'lstItems' + ' :checkbox').attr('checked', true);
    }


    function uncheckItems() {
      
        $('#' + 'lstItems' + ' :checkbox').attr('checked', false);
    }

</script>
