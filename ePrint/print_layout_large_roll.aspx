<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_layout_large_roll.aspx.cs" masterpagefile="~/Templates/popUpMasterPage.master" Inherits="ePrint.print_layout_large_roll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <%--<div style="width: 100%;" class="navigatorpanel">
                    <div class="t">
                        <div class="t">
                            <div class="t">
                                <div class="divpadding">
                                    <div align="left" style="float: left;" nowrap="nowrap">
                                        <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel">Print Layout</asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <%-- class="borderWithoutTop"--%>
                    <tr>
                        <td>
                            <img height="4" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" border="0" align="center">
                                <tr>
                                    <td align="center">
                                        <b><span class="normaltext">
                                            <asp:Label ID="lblImposition" Text="This Imposition is not to Scale" runat="server"></asp:Label>
                                        </span></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <b>
                                            <asp:Label ID="lblRowCol" runat="server" CssClass="normalTest"></asp:Label></b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: none">
                                <asp:PlaceHolder ID="phlayout" runat="server" Visible="false"></asp:PlaceHolder>
                            </div>
                            <div align="center" style="vertical-align: top;">
                                <asp:PlaceHolder ID="phtest" runat="server"></asp:PlaceHolder>
                            </div>
                            <div class="divEmptyOnly">
                                &nbsp;
                            </div>
                            <div align="center">
                                <input type="image" src="<%=strImagepath %>print.jpg" onclick="javascript:printView();" />
                            </div>
                            <div class="divEmptyOnly">
                                &nbsp;
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--<div align="left">
        <div align="center" style="width: 500px; height: 570px; border: solid 1px blue;">
            <table align='center' cellpadding='0px' cellspacing='0px' height='100%' width='100%'>
                <tr valign='middle'>
                    <td align='center'>
                        <div align="center" style="height: 550px;width: 450px;border: solid 1px red;">
                            &nbsp;
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>--%>
    <script>
        function printView() {
            window.print();
        }
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


