<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="inventoryexport.aspx.cs" Inherits="ePrint.warehouse.inventoryexport" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>--%>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">
                                <%=objLangClass.GetLanguageConversion("Inventory_Inventory_View")%>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div id="content">
        <%-- <div class="borderWithoutTop">--%>
        <div id="padding" class="div_inv_margin">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <span class="bglabel" style="width: 20%; height: 35px">
                <%=objLangClass.GetLanguageConversion("Select_Columns")%></span>
            <div style="float: left">
                <asp:CheckBoxList ID="chkColumnName" runat="server" RepeatDirection="Horizontal"
                    RepeatColumns="4">
                    <asp:ListItem Text="Inventory Name" Value="InventoryName" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Friendly Name" Value="FriendlyName" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Description" Value="Description" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Inventory Code" Value="InventoryCode" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Location" Value="Location" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="In Stock" Value="InStock" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Re-Order Alert Level" Value="ReorderLevel" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Re-Order Quantity" Value="ReOrderQuantity" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Supplier" Value="Supplierid" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Cost" Value="Cost" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Per Quantity" Value="PerQuantity" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Packed In" Value="PackedIn" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Pack Price" Value="PackedPrice" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Weight" Value="basisweight" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Colour" Value="Colour" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Length" Value="Length" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Item Paper Size" Value="itempapersize" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Item Custom Size" Value="itemcustomsize" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Paper Type" Value="PaperType" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Large Format Material" Value="LargeFormatMaterial" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Coating Type" Value="Coated" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Created On" Value="createddate" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Markup %" Value="Markup" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Caliper" Value="Caliper" Selected="False"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div align="left" style="width: 100%; padding: 8px">
                <a href="javascript:\\" id="lnkSelectAll" onclick="javascript:SelectAll();" style="padding-left: 5px">
                    <%=objLangClass.GetLanguageConversion("Select_All")%></a>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left">
                <div class="bglabel" style="width: 20%; height: 35px">
                    <%=objLangClass.GetLanguageConversion("Select_Inventory_Category")%>
                </div>
                <div class="ddlsetting">
                    <div align="left">
                        <asp:DropDownList CausesValidation="false" ID="ddlInvCategory" runat="server" CssClass="normalText"
                            Width="183px">
                        </asp:DropDownList>
                    </div>
                    <%-- <div align="left">
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlInvCategory"
                                ValueToCompare="0" ErrorMessage="Please select Inv. Category" Operator="NotEqual"
                                Display="Dynamic" CssClass="RFV_Message"></asp:CompareValidator>
                        </div>--%>
                    <div id="rfv" class="RFV_Message" runat="server" style="width: 174px; float: left;
                        display: none">
                        <span style="float: left; padding-left: 4px">Please select Inv. Category</span>
                    </div>
                </div>
            </div>
            <br />
            <div align="left">
                <span class="bglabel" style="width: 20%; height: 12px">
                    <%=objLangClass.GetLanguageConversion("Select_File_Formate")%>
                </span>
                <div style="float: left">
                    <asp:RadioButton ID="rdoExcelFormat" runat="server" Text="Excel" Checked="true" onclick="javascript:rdoFormatChange('e');" />
                    <asp:RadioButton ID="rdoCsvFormat" runat="server" Text="CSV" onclick="javascript:rdoFormatChange('c');" />
                </div>
            </div>
            <div class="only10px">
            </div>
            <div style="float: left; width: 20%">
                &nbsp;
            </div>
            <div style="float:left">
                <div id="div_cancel">
                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_OnClick" OnClientClick="loadingimg('div_cancel','div_btnCancelProcess')"
                    Text="Cancel" CssClass="button" />
                </div>
                <div id="div_btnCancelProcess" class="button" align="center" style="width: 38px; display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                </div>
            </div>
            <div style="float: left; width: 10px">
                &nbsp;
            </div>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_OnClick" Text="Export"
                CausesValidation="true" CssClass="button" OnClientClick="javascript:return btnExport_OnClientClick();" />
            <div class="onlyEmpty">
            </div>
        </div>
        <%--  </div>--%>
    </div>
    <script type="text/javascript">
        function rdoFormatChange(val) {

            if (val == 'e') {

                document.getElementById("<%=rdoCsvFormat.ClientID %>").checked = false;
            }
            else if (val == 'c') {

                document.getElementById("<%=rdoExcelFormat.ClientID %>").checked = false;
            }

        }
        var CHK1 = document.getElementById("<%=chkColumnName.ClientID%>");
        var chk = CHK1.getElementsByTagName("input");
        function btnExport_OnClientClick() {
            var check;
            if (document.getElementById("<%=ddlInvCategory.ClientID %>").value != 5) {
                document.getElementById("<%=rfv.ClientID %>").style.display = "none";
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked == true) {
                        return true;
                    }
                    else {
                        check = false;
                    }
                }
                if (check == false) {
                    alert("Please select at least one column to export");
                    return false;
                }
            }
            else {
                document.getElementById("<%=rfv.ClientID %>").style.display = "block";
                return false;
            }

        }
        function SelectAll() {
            var Count = 0;
            if (trim12(lnkSelectAll.innerHTML) == trim12('<%=objLangClass.GetLanguageConversion("Select_All")%>')) {
                for (var i = 0; i < chk.length; i++) {
                    chk[i].checked = true;
                    lnkSelectAll.innerHTML = "Select None";
                }
            }
            else {
                for (var i = 0; i < chk.length; i++) {
                    chk[i].checked = false;
                    lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All")%>';
                }
            }
        }
    </script>
</asp:Content>
