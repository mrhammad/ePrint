<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagingreport.ascx.cs" Inherits="ePrint.usercontrol.pagingreport" %>
<%--// CC Design //--%>
<div align="left" style="width: 100%;">
    <div style="padding: 4px">
        <div align="left" style="width: 100%; border: 0px solid silver">
            <%--   <div style="float: left; padding-left: 3px">
                <span class="normalText" style="padding-right: 10px">Pages:</span>
            </div>--%>
            <div style="float: left; padding-left: 3px;">
                <span class="HeaderText"><b>
                    <asp:LinkButton ID="lnkstart" OnClick="btn_Command" runat="server" Style="padding-right: 5px"
                        CausesValidation="false" Text="<<">                       
                    </asp:LinkButton></b> <b>
                        <asp:LinkButton ID="lnkPrev" CausesValidation="false" OnClick="btn_Command" Text="<"
                            runat="server">
                        </asp:LinkButton></b> <b>
                            <asp:LinkButton ID="lnkFirst" OnClick="btn_Command" Visible="false" runat="server"
                                Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkSecond" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkThird" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkFour" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkFive" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkSix" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkSeven" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkEight" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkNine" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkTen" OnClick="btn_Command" Visible="false" runat="server"
                            Style="padding-right: 5px" CausesValidation="false"></asp:LinkButton></b>
                    <b>
                        <asp:LinkButton ID="lnkNext" CausesValidation="false" Text=">" runat="server" OnClick="btn_Command">
                        </asp:LinkButton ></b> <b>
                            <asp:LinkButton ID="lnkEnd" OnClick="btn_Command" runat="server" Style="padding-right: 5px"
                                CausesValidation="false" Text=">>"></asp:LinkButton></b> </span>
                <asp:Label ID="lblPageNumber" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                <span class="normalText">/</span>
                <asp:Label ID="lblTotalPage" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
            </div>
            <%--    <div style="float: right; padding-left: 5px">
                <span class="normalText">Page</span>
                <asp:Label ID="lblPageNumber" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                <span class="normalText">/</span> <span class="normalText">of</span>
                <asp:Label ID="lblTotalPage" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label></div>--%>
            <input type="hidden" name="limitstart" value="0" />
            <asp:HiddenField runat="server" Value="5" ID="hdnPageCount" />
            <asp:HiddenField runat="server" Value="1" ID="hdnCurrentPage" />
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
<%--// CC Design //--%>