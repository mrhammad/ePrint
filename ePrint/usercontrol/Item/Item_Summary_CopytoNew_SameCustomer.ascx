<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item_Summary_CopytoNew_SameCustomer.ascx.cs" Inherits="ePrint.usercontrol.Item.Item_Summary_CopytoNew_SameCustomer" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%--COPY TO NEW CUSTOMER WITH ALERT MESSAGES--%>
<script type="text/javascript" language="javascript">
    var CompanyID = '<%=CompanyID %>';
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<div id="divCopyto_new_customer" align="left" style="display: none; z-index: 100;
    position: absolute;">
    <table cellpadding="0" id="tbl_divCopyto_new_customer" cellspacing="0" height="175px">
        <tr>
            <td align="center">
                <div align="left" style="">
                    <div align="left">
                        <div style="float: left; padding-top: 6px; margin-left: 15px; margin-bottom: -6px"
                            visible="false">
                            <asp:Label ID="Label3" runat="server" Text="" Style="font-size: 11px"><b><%=objLanguage.GetLanguageConversion("Customer")%></b></asp:Label>
                            <span style="color: Red; padding-left: 4px">*</span>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="float: left; padding-top: 6px; margin-left: 15px;">
                            <asp:TextBox ID="txtName" SkinID="textPad" runat="server" AutoCompleteType="disabled"></asp:TextBox>
                            <div class="onlyEmpty">
                            </div>
                            <span id="spn_txtName" class="spanerrorMsg spanerrorMsg_border" style="display: none;
                                width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Customer_Name")%></span>
                        </div>
                        <asp:HiddenField ID="hid_CustName" runat="server" Value="" />
                        <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_EstimateID" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_Contact" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_AccountNo" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_Address" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_contactId" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_contactName" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_Greeting" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value="0" />
                        <asp:HiddenField ID="hdn_Attention" runat="server" Value="0" />
                        <asp:HiddenField ID="hdn_InvAddressID" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnStatusTitle" runat="server" Value="" />
                        <script type="text/javascript">
                            var txtName = document.getElementById("<%=txtName.ClientID %>");
                            var hid_CustName = document.getElementById("<%=hid_CustName.ClientID %>");
                            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
                            var hid_Contact = document.getElementById("<%=hid_Contact.ClientID %>");
                            var hid_AccountNo = document.getElementById("<%=hid_AccountNo.ClientID %>");
                            var hid_Address = document.getElementById("<%=hid_Address.ClientID %>");
                            var hid_Greeting = document.getElementById("<%=hid_Greeting.ClientID %>");
                            var hid_contactId = document.getElementById("<%=hid_contactId.ClientID %>");
                            var hid_contactName = document.getElementById("<%=hid_contactName.ClientID %>");
                            var hid_DeliveryAddressID = document.getElementById("<%=hid_DeliveryAddressID.ClientID %>");
                            var hdn_Attention = document.getElementById("<%=hdn_Attention.ClientID %>");
                            var hdn_InvAddressID = document.getElementById("<%=hdn_InvAddressID.ClientID %>");
                            var IsProformaInvoice = "<%=IsProformaInvoice%>";
                            var hdnStatusTitle = document.getElementById("<%=hdnStatusTitle.ClientID %>");
                           
                           
                        </script>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div style="float: left; padding-top: 6px; margin-left: 15px; margin-bottom: 6px"
                                visible="false">
                                <div id="divlblconfirmjob" style="display: none">
                                    <asp:Label ID="Label4" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create an estimate out of this Job and archive it?</b></asp:Label>
                                </div>
                                <div id="divlblconfirminvoice" style="display: none;">
                                    <asp:Label ID="Label12" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create an estimate and job out of this Invoice and archive it?</b></asp:Label>
                                </div>
                                <div id="div_lblinvoiceproforma" style="display: none">
                                    <asp:Label ID="Label17" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create a Proforma Invoice and keep job live?</b></asp:Label>
                                </div>
                            </div>
                            <div class="box" style="float: left; margin-left: 5px; margin-bottom: 6px" visible="false">
                                <div id="divRadioButton">
                                    <asp:RadioButton ID="rdnCopyNo" runat="server" Text="No" OnClick="javascript:return true;"
                                        GroupName="Copy" />
                                    <asp:RadioButton ID="rdnCopyYes" runat="server" Text="Yes" Checked="true" OnClick="javascript:return true;"
                                        GroupName="Copy" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" style="width: 100%;">
                        <div style="float: left; width: 10px">
                            &nbsp;</div>
                        <div id="div_btnEstimate" style="float: left; margin-left: 3px; display: none">
                            <div id="div_btncopyestimate" style="display: block">
                                <asp:Button ID="Button1" runat="server" Text="Copy Estimate" CssClass="button" OnClientClick="javascript: var a=validate_estCopy();if(a)loadingimg('div_btncopyestimate','div_copyestprocess');return a;"
                                    OnClick="lnkEstimateCopyToNewCustArchive_OnClick" />
                            </div>
                            <div id="div_copyestprocess" class="button" align="center" style="width: 90px; height: 15px;
                                display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="div_btnJob" style="float: left; margin-left: 3px; display: none">
                            <div id="div_btncopyjob" style="display: block">
                                <asp:Button ID="Button2" runat="server" Text="Copy Job" CssClass="button" OnClientClick="javascript:var a=validate_estCopy();if(a)loadingimg('div_btncopyjob','div_btncopyprocess');return a; "
                                    OnClick="lnkEstimateCopyToNewCustArchive_OnClick" />
                            </div>
                            <div id="div_btncopyprocess" class="button" align="center" style="width: 58px; height: 15px;
                                display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="div_btnInvoice" style="float: left; margin-left: 3px; display: none">
                            <div id="div_btncopyinvoice" style="display: block">
                                <asp:Button ID="Button3" runat="server" Text="Copy Invoice" CssClass="button" OnClientClick="javascript:var a=validate_estCopy();if(a) a = chkrdnNO_ForPrompt();if(a)loadingimg('div_btncopyinvoice','div_btninvprocess');return a;"
                                    OnClick="lnkEstimateCopyToNewCustArchive_OnClick" />
                            </div>
                            <div id="div_btninvprocess" class="button" align="center" style="width: 80px; height: 15px;
                                display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<div>
    <asp:LinkButton ID="lnkEstDelete" runat="server" Text=" " CausesValidation="false"
        Style="display: none;"></asp:LinkButton><%--  OnClick="lnkEstDelete_OnClick"--%>
    <asp:LinkButton ID="lnkEstArchive" runat="server" Text=" " CausesValidation="false"
        Style="display: none;"></asp:LinkButton>
    <asp:LinkButton ID="lnkEstimateCopytoSameCust" runat="server" Text="" CausesValidation="false"
        Style="display: block;" OnClick="lnkEstimateCopyToSameCustArchive_OnClick"></asp:LinkButton>
    <asp:LinkButton ID="lnkEstimateCopytoSameCustArchive" runat="server" CausesValidation="false"
        Style="display: none;" Text="" OnClick="lnkEstimateCopytoSameCustUnArchive_OnClick"></asp:LinkButton>
    <asp:LinkButton ID="lnkEstimateCopytoNewCust" runat="server" Text="" CausesValidation="false"
        Style="display: none;" OnClick="lnkEstimateCopyToNewCustArchive_OnClick"></asp:LinkButton>
    <asp:HiddenField ID="hdnEstimateId" runat="server" Value="0" />
</div>
<div id="divcopy_job_invoice_confirm" align="left" style="display: none; position: absolute;
    z-index: 100;">
    <table cellpadding="0" id="tbl_confirmationarchive" cellspacing="0" width="100%;">
        <tr>
            <td align="center">
                <div align="left" style="width: 100%">
                    <div style="float: left; padding-top: 6px; margin-left: 15px; margin-bottom: 6px"
                        visible="false">
                        <div id="jobconfirmcopy_alert" style="display: none">
                            <asp:Label ID="jobconfirmcopy_alertlbl" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create an estimate out of this Job and archive it?</b></asp:Label>
                        </div>
                        <div id="invoiceconfirmcopy_alert" style="display: none">
                            <asp:Label ID="invoiceconfirmcopy_alertlbl" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create an estimate and job out of this Invoice and archive it?</b></asp:Label>
                        </div>
                        <div id="div_CopyProformaInvoice" style="display: none">
                            <asp:Label ID="Label2" runat="server" Text="" Style="font-size: 11px"><b>Do you want to create a Proforma Invoice and keep job live?</b></asp:Label>
                        </div>
                    </div>
                    <div style="width: 100%; height: 20%">
                        <div style="clear: both">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" style="width: 100%;">
                        <div style="width: 100%; height: 10%">
                            <div style="clear: both">
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div style="float: left; width: 23%">
                            &nbsp;</div>
                        <div align="center" id="div_CopySameCustomar" style="float: left; margin-left: 10px;
                            display: none">
                            <div style="display: inline; float: right; padding-left: 20px;">
                                <div id="div_btnyes" style="display: block">
                                    <asp:Button ID="Button4" runat="server" Text="Yes" CssClass="button" OnClientClick="javascript:loadingimg('div_btnyes','div_btnyesprocess');"
                                        OnClick="lnkEstimateCopyToSameCustArchive_OnClick" />
                                </div>
                                <div id="div_btnyesprocess" class="button" align="center" style="width: 26px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="display: inline; float: left">
                                <div id="div_btnno" style="display: block">
                                    <asp:Button ID="Button5" runat="server" Text="No" CssClass="button" OnClientClick="javascript:var a= StockReduce_froDirectInvPrompt();if(a)loadingimg('div_btnno','div_btnnoprocess');return a;"
                                        OnClick="lnkEstimateCopytoSameCustUnArchive_OnClick" />
                                </div>
                                <div id="div_btnnoprocess" class="button" align="center" style="width: 21px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                        <div align="center" id="div_CopyNewCustomar" style="float: left; margin-left: 4px;
                            display: none">
                            <asp:Button ID="Button6" runat="server" Text="Yes" CssClass="button" OnClick="lnkEstimateCopyToNewCustArchive_OnClick" />
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnisStock_Reduce" runat="server" Value="" />
    <div id="div_yesnobtns" style="display: none; width:280px; padding-left: 0px; margin: 10px;">
        <table>
            <tr>
                <td colspan="2">
                    <label style="font-size: 11px; font-weight: bold;">
                        Do you want to reduce the inventory stock?</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="yes" style="width: 50px; margin-top: 10px; margin-left: 50px;"
                        class="button" value="Yes" onclick="javascript:called('yes');" />
                    &nbsp;&nbsp;
                    <input type="button" id="No" style="width: 50px;" class="button" value="No" onclick="javascript:called('No');" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</div>
<script type="text/javascript">
    var Pgtype = '<%=Pgtype %>';  
</script>
<asp:Panel ID="pnlcrmcopy" runat="server" Visible="false">
    <script type="text/javascript">
        var EstID = '<%=NewEstID %>';
        var Pgtype = '<%=Pgtype %>';
        var jID = '<%=jID %>';
        var InvID = '<%=InvID %>';

        if (Pgtype == 'estimate') {
            window.close();
            parent.location.href = "<%=strSitepath%>estimates/estimate_summary_reeng.aspx?frm=view&suc=cop&estid=" + EstID + "" + jID + InvID + "";

        }

        if (Pgtype == 'order') {
            window.close();
            parent.location.href = "<%=strSitepath%>orders/order_summary.aspx?frm=view&suc=cop&ordid=" + EstID + "&estid=" + EstID + "" + jID + InvID + "";

        }
        else if (Pgtype == 'job') {
            window.close();
            parent.location.href = "<%=strSitepath%>jobs/job_summary_reeng.aspx?frm=view&suc=copj&estid=" + EstID + "" + jID + "";
        }
        else if (Pgtype == 'invoice') {
            window.close();
            parent.location.href = "<%=strSitepath%>invoice/Invoice_Summary_reeng.aspx?frm=view&suc=copi&estid=" + EstID + "" + InvID + "";
        }

      
    
    </script>
</asp:Panel>
<script type="text/javascript">
    var Accountsonhold = <%=objLanguage.GetLanguageConversion("Accoutns_On_Hold") %>;
    var AccoutnsOnHoldCopyjobToSameNewCust = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Copyjob_To_Same_New_Cust") %>';
    var AccoutnsOnHoldCopyestimateToSameNewCust = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Copyestimate_To_Same_New_Cust") %>';
    function StockReduce_froDirectInvPrompt(){
        var Pgtype = '<%=Pgtype %>';
        var InventoryManagement = '<%=InventoryManagement %>'
        var ReduceStockType = '<%=ReduceStockType %>';
        var hdnisStock_Reduce = document.getElementById("<%=hdnisStock_Reduce.ClientID %>");
        var rdnCopyNo = document.getElementById("<%=rdnCopyNo.ClientID %>")
        if (InventoryManagement.toString().toLowerCase() == "im") {
            if (Pgtype.toLowerCase() == "invoice") {
                if (ReduceStockType.toLowerCase() != 'e' || ReduceStockType.toLowerCase() != 'i') {
                    //                    if (window.confirm('Do you want to reduce the inventory stock?')) {
                    //                        hdnisStock_Reduce.value = "yes";
                    //                    }
                    //                    else {
                    //                        hdnisStock_Reduce.value = "no";
                    //    }                
                    //SetRadWindow('divrad', 'divBackGroundNew', '200');
                    document.getElementById('tbl_divCopyto_new_customer').style.display = 'none';
                    document.getElementById('tbl_confirmationarchive').style.display = 'none';
                    document.getElementById('divcopy_job_invoice_confirm').style.display = 'block';
                    document.getElementById('div_yesnobtns').style.display = 'block';
                    if(check_copytonew == 'copytonew'){
                        document.getElementById('yes').style.marginLeft = '75px';
                    }
                    return false;
                }
            }
        }
        return true;
    }
    var check_copytonew = '';
    function called(val)
    {
        var hdnisStock_Reduce = document.getElementById("<%=hdnisStock_Reduce.ClientID %>");
        document.getElementById('div_yesnobtns').style.display = 'none';        
        hdnisStock_Reduce.value = val;         
        if(check_copytonew == '')
        {
            __doPostBack('ctl00$ContentPlaceHolder1$ctl00$Button5','');
        }
        else
        {
            __doPostBack('ctl00$ContentPlaceHolder1$ctl00$Button3','');
        }    
    }
    function chkrdnNO_ForPrompt() {
        check_copytonew = 'copytonew';
        var rdnCopyNo = document.getElementById("<%=rdnCopyNo.ClientID %>");
    if (rdnCopyNo.checked == true) {
        return StockReduce_froDirectInvPrompt();
    }
}    
</script>

