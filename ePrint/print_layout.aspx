<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_layout.aspx.cs" Inherits="ePrint.print_layout" MasterPageFile="~/Templates/popUpMasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<table cellspacing="0" cellpadding="0" width="100%" border="0" align="center" runat="server" id="tblNew">
        <tr>
            <td>--%>
    <div align="center" runat="server" id="tblNew">
        <b style="font-size: 12px">
            <i>
                <asp:Label ID="Label1" Text="Print layout imposition not available for manual entry" runat="server"></asp:Label>

            </i>

        </b>
    </div>

    <%-- </td>
        </tr>
    </table>--%>

    <div align="center">


        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" runat="server" id="tblMain">
            <tr>
                <td>
                    <%--<div style="width: 100%;" class="navigatorpanel">
                    <div class="t">
                        <div class="t">
                            <div class="t">
                                <div class="divpadding">
                                    <div align="left" style="float: left;" nowrap="nowrap">
                                        <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Print_LayOut") %></asp:Label>
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
                        <%--class="borderWithoutTop"--%>
                        <tr>
                            <td>
                                <img height="4" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="1" cellspacing="1" border="0" align="center">
                                    <tr>
                                        <td>
                                            <b style="font-size: 12px"><i>
                                                <asp:Label ID="lblImposition" Text="This imposition is not to scale" runat="server"></asp:Label></i></b>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<div style="display: none">
                                <asp:PlaceHolder ID="phlayout" runat="server" Visible="true"></asp:PlaceHolder>
                            </div>--%>
                                <div align="center" style="vertical-align: top;">
                                    <asp:PlaceHolder ID="phtest" runat="server"></asp:PlaceHolder>
                                </div>
                                <div class="divEmptyOnly">
                                    &nbsp;
                                </div>
                                <div align="center">
                                    <input type="image" src="<%=strImagepath %>print.jpg" onclick="javascript: printView();" />
                                </div>
                                <div class="divEmptyOnly">
                                    &nbsp;
                                </div>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

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


