<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="supplier_addmore.ascx.cs" Inherits="ePrint.usercontrol.Item.supplier_addmore" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/item_addmoreSupplier.js?VN='<%=VersionNumber%>'"></script>
<div id="div_SuplAdd" style="display: none; position: absolute; z-index: 10005; width: 60%;
    height: 350px; left: 285px; top: 150px;">
    <table cellpadding="0" cellspacing="0" width="100%;height:175px">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                    <b>Add More Supplier</b>
                    <asp:Label ID="Label1" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideDiv_Supp();return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="width: 100%;">
                    <fieldset>
                        <legend>
                            <%=objLanguage.GetLanguageConversion("Supplier_Selection")%></legend>
                        <%--Supplier Request for Quote Description--%>
                    </fieldset>
                </div>
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
</div>
<div align="left" id="div_Complete" runat="server">
    <div align="left" style="width: 100%;">
        <div align="center" id="diverrorMessage" style="width: auto; display: none; padding-left: 150px;">
            <span id="span_none" class="spanerrorMsg" style="width: auto; margin: 7px; padding-left: 4px;
                padding-right: 4px"></span>
        </div>
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t" style="width: 100%;">
                <div class="t" style="width: 100%;">
                    <div class="t" style="width: 100%;">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblCostViewTitle" runat="server"><%=objLanguage.GetLanguageConversion("Supplier_Selection")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div>
            <div align="left" style="width: 100%;">
                <div id="div_scroll" style="float: left; width: 100%; height: 265px;">
                    <%--overflow-y: scroll;--%>
                    <div id="div_addmorecontents">
                        <div id="div_supplier0">
                            <div align="left" style="display: none;">
                                <div style="width: 100%; float: left; padding: 3px 0px  6px 0px; border-bottom: 1px solid silver">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Supplier_1")%></span>
                                </div>
                                <asp:DropDownList ID="ddlSupplier1" Width="200px" runat="server" TabIndex="24" Style="padding: 0px"
                                    SkinID="onlyDDL">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlSupplierContact1" Width="200px" TabIndex="25" runat="server"
                                    SkinID="onlyDDL">
                                </asp:DropDownList>
                                <div style="width: 90%; float: left; padding: 2px;">
                                    <div class="onlyEmpty">
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 20%">
                                            <asp:Label ID="Label3" runat="server" Text="Name" CssClass="normalText"></asp:Label></div>
                                        <div class="box">
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 20%">
                                            <asp:Label ID="Label5" runat="server" Text="Contact" CssClass="normalText"></asp:Label></div>
                                        <div class="box">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divtest">
                            </div>
                        </div>
                    </div>
                    <div align="left">
                        <table align="left" cellspacing="2" width="100%" cellpadding="4" border="0">
                            <tbody id="tableSup">
                            </tbody>
                        </table>
                    </div>
                    <div id="div_added" align="left">
                    </div>
                    <div style="clear: both; height: 10px;">
                        &nbsp;
                    </div>
                    <div style="float: left; padding-bottom: 10px; border: solid 0px red; width: 100%">
                        <div style="width: 67%; float: left">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div style="float: left;">
                                <a id="link_more" name="link_more" href="#link_more" onclick="javascript:add_more();return false;">
                                    <%=objLanguage.GetLanguageConversion("Add_More")%></a></div>
                            <input type="hidden" value="1" id="hdn_count" /></div>
                        <div id="divS">
                        </div>
                    </div>
                </div>
                <div style="border: solid 0px red; width: 100%">
                    <div style="width: 50%; float: left">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div class='only10px'>
            </div>
        </div>
        <div style="float: left; padding: 5px 0px 0px 5px;">
            <div style="float: left;">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:return SupplierSelectionCheck();"
                    OnClick="btnSave_OnClick" />
                <asp:Button ID="btnSaveAndPrint" runat="server" Text="Save & Print" CssClass="button"
                    OnClientClick="javascript:return SupplierSelectionCheck();" OnClick="btnSaveAndPrint_OnClick" />
                <asp:Button ID="btnSaveAndEmail" runat="server" Text="Save & Email" CssClass="button"
                    OnClientClick="javascript:return SupplierSelectionCheck();" OnClick="btnSave_OnClick" />
            </div>
            <asp:HiddenField ID="hdnSupplierAddMore" runat="server" />
        </div>
    </div>
</div>
<script type="text/javascript">
    var OptionData = '';
    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var estimateType = "printbroker";
    var EstID = "<%=EstimateItemID %>";
    var IsEdit = false;
    var EditNo = '';
    //-----------
    var rowno = 1;
    var supCount = 1;
    var labelCount = 1;

    var tableSup = document.getElementById("tableSup");

    var ddl1 = document.getElementById("<%=ddlSupplier1.ClientID %>");
    var ddl2 = document.getElementById("<%=ddlSupplierContact1.ClientID %>");
    var SupplierContacts = document.getElementById("<%=ddlSupplierContact1.ClientID%>");

    var strSitepath = '<%=strSitepath %>';
    var strImagepath = '<%=strImagepath %>';
    var EstimateID = '<%=EstimateID %>';


    function GenrateSupplierQuoteList(EstID) {

        var supData = '';
        PageMethods.GetSuppliersQuote_List(CompanyID, EstID, function SList(retnValue) {
            OptionData = "<option selected='selected' value=0>--- Select ---</option>";
            if (retnValue != "") {
                var strSupArray = retnValue.split('±');
                for (var i = 0; i < strSupArray.length; i++) {
                    var arr1 = strSupArray[i].split('»');

                    if (arr1[1] != '' && arr1[1] != 'undefined') {
                        if (arr1[1] == "undefined") {
                        }
                        else {
                            OptionData += "<option value='" + arr1[0] + "'>" + arr1[1] + "</option>";
                        }
                    }
                    if (strSupArray.length - 1 == i) {
                        add_more();
                        add_more();
                        add_more();
                    }
                }
            }
        }, SList_error);
    }

    function hideDiv_Supp() {
        OptionData = '';
        for (var i = 1; i < labelCount; i++) {
            if (document.getElementById("ddlSupplier_" + i + "") != null) {
                RemoveThisSupplier(i);
                RemoveTableRow(i);
            }
        }
        document.getElementById("div_SuplAdd").style.display = "none";
        document.getElementById("overlay").style.display = "none";
        document.getElementById("diverrorMessage").style.display = "none";
        document.getElementById("span_none").innerHTML = "";
    }

    function ShowDiv_Supp(EstID) {
        document.getElementById("div_SuplAdd").style.display = "block";
        document.getElementById("overlay").style.display = "block";
        GenrateSupplierQuoteList(EstID);
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnSupplierAddMore_EstID").value = EstID;
    }

    GenrateSupplierQuoteList(EstID);

    function SupplierSelectionCheck() {

        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnSupplierAddMore").value = '';
        var IsValidToGo = false;
        var checkcnt = labelCount - 1;
        //duplicacy check
        var SupplierList = "@";
        for (var i = 1; i <= checkcnt; i++) {
            var supObj = document.getElementById("ddlSupplier_" + i);
            if (supObj != null) {
                var contObj = document.getElementById("ddlSupplierContact_" + i);
                var supValue = supObj.options[supObj.selectedIndex].value;
                var contValue = contObj.options[contObj.selectedIndex].value;
                if (supValue != "0") {
                    IsValidToGo = true;
                    SupplierList = SupplierList + supValue + ";" + contValue + "@";
                }
            }
        }
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnSupplierAddMore").value = SupplierList;
        if (IsValidToGo == false) {
            document.getElementById("diverrorMessage").style.display = "block";
            document.getElementById("span_none").innerHTML = "Please select at least one supplier";
        }
        else {
            document.getElementById("diverrorMessage").style.display = "none";
        }
        return IsValidToGo;
    }

</script>
