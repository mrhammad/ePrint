<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" inherits="warehouse_inventoryexport, App_Web_inventoryexport.aspx.15d5504d" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>--%>
    <div class="navigatorpanel">
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
    </div>
    <div id="content">
        <div class="borderWithoutTop">
            <div id="padding">
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
                        <asp:ListItem Text="Re-Order Alert Level" Value="ReorderLevel" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Re-Order Quantity" Value="ReOrderQuantity" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Supplier" Value="Supplierid" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Cost" Value="Cost" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Per Quantity" Value="PerQuantity" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Packed In" Value="PackedIn" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Pack Price" Value="PackedPrice" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Weight" Value="basisweight" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Colour" Value="Colour" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Created On" Value="createddate" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Coating Type" Value="Coated" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Item Paper Size" Value="itempapersize" Selected="False"></asp:ListItem>
                        <asp:ListItem Text="Item Custom Size" Value="itemcustomsize" Selected="False"></asp:ListItem>
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
                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_OnClick"
                    Text="Cancel" CssClass="button" />
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_OnClick" Text="Export"
                    CausesValidation="true" CssClass="button" OnClientClick="javascript:return btnExport_OnClientClick();" />
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
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
                    alert("Please select atleast one column to export");
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
            if (lnkSelectAll.innerHTML == "Select All") {
                for (var i = 0; i < chk.length; i++) {
                    chk[i].checked = true;
                    lnkSelectAll.innerHTML = "Select None";
                }
            }
            else {
                for (var i = 0; i < chk.length; i++) {
                    chk[i].checked = false;
                    lnkSelectAll.innerHTML = "Select All";
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
