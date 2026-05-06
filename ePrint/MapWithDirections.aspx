<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapWithDirections.aspx.cs" Inherits="ePrint.MapWithDirections" %>


<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="margin-top: 15px; margin-left: 15px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 60%;">
                        <div class="bglabel" style="width: 140px; float: left;">
                            <asp:Label ID="lblcontact" runat="server" CssClass="normalText" Text="Company Name">
                            </asp:Label>
                        </div>
                        <div style="float: left; margin-left: 4px; margin-top: 4px;">
                            <asp:Label ID="lblClientName" runat="server" CssClass="normalText" Text="Vikash bardia"></asp:Label>
                        </div>
                    </td>
                    <td style="width: 40%;">
                        <div id="DivAddressdrop" style="float: right; margin-right: 3.5%;">
                            <div class="bglabel" style="width: 140px; float: left;">
                                <asp:Label ID="Label2" runat="server" CssClass="normalText" Text="Company addresses"></asp:Label>
                            </div>
                            <div style="float: left; margin-left: 4px; margin-top: 1px;">
                                <asp:DropDownList ID="ddlAddress" runat="server" CssClass="simpledropdownPopup" AutoPostBack="true"
                                    onchange="javascript:Changemapaddress(); return false;">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <div id="DivPrintButton" style="float: right; margin-right: 10px;">
                                <asp:LinkButton ID="lnkprintmap" runat="server" CssClass="printicon" OnClientClick="javascript:Printing();return false;"
                                    ToolTip="Print"></asp:LinkButton>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="margin-left: 15px; display: none;">
                            <table>
                                <tr>
                                    <td align="right">
                                        First Address :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstAddress" runat="server" Text="" Width="395px">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Second Address :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSecondAddress" runat="server" Text="" Width="395px">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Third Address :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtThirdAddress" runat="server" Text="10001" Width="395px">
                                        </asp:TextBox>(Postal Code can be used as well)
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Show direction instructions? :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkShowDirections" runat="server" Checked="true"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Hide Markers? :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHideMarkers" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Color of direction line :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDirColor" runat="server" Text="#FF2200" Width="120px">
                                        </asp:TextBox>(Hex value)
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Direction line width :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDirWidth" runat="server" Text="3" Width="120px">
                                        </asp:TextBox>(1 to 6)
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="right">
                                        Direction line opacity :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDirOpacity" runat="server" Text="0.6" Width="120px">
                                        </asp:TextBox>(0.1 to 1.0)
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDrawDirections" runat="server" Text="Draw Directions" OnClick="btnDrawDirections_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:HiddenField ID="hdnAddress" runat="server" />
        <asp:HiddenField ID="hdnAddressID" runat="server" />
    </div>
    <script type="text/javascript">

        function Changemapaddress() {
            var Address = document.getElementById("ddlAddress");
            Address.options[Address.selectedIndex].text;
            var hdnAddress = document.getElementById("hdnAddress");
            hdnAddress.value = Address.options[Address.selectedIndex].text;
            hdnAddressID.value = Address.options[Address.selectedIndex].value;

            __doPostBack('btnDrawDirections', '')
        }

        function Printing() {
            document.getElementById("DivPrintButton").style.display = "none";
            document.getElementById("DivAddressdrop").style.display = "none";
            window.print();

            document.getElementById("DivPrintButton").style.display = "block";
            document.getElementById("DivAddressdrop").style.display = "block";
        }
    </script>
    </form>
</body>
</html>

