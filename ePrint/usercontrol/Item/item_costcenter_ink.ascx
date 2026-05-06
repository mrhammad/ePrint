<%@ control language="C#" autoeventwireup="true" CodeBehind="item_costcenter_ink.ascx.cs" Inherits="ePrint.usercontrol.Item.item_costcenter_ink" %>
<div id="div_moreink" style="float: left; width: 100%">
    <div style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Cost Center Ink </span>
                        </div>
                        <%--  <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('div_employee_add');" style="color: White;">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="borderWithoutTop">
        <div id="padding">
            <div align="left" style="width: 100%">
                <fieldset style="padding: 8px">
                    <legend class="HeaderText">Side 1</legend>
                    <div style="float: left; width: 100%">
                        <div style="float: left; width: 20%">
                            &nbsp;</div>
                        <div style="float: left; width: 30%">
                            <span>Ink</span></div>
                        <div style="float: left; width: 20%">
                            <span>Coverage %</span></div>
                    </div>
                    <div style="float: left; width: 50%">
                        <asp:DropDownList ID="ddl1" runat="server" Width="250px" CssClass="normalText">
                            <asp:ListItem>Black C</asp:ListItem>
                            <asp:ListItem>BLACK C</asp:ListItem>
                            <asp:ListItem>BLACK C Hexachrome</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; width: 40%">
                        <asp:TextBox ID="txt1" runat="server" Width="50px" CssClass="txtbox">10</asp:TextBox>
                    </div>
                    <div style="float: left; width: 50%; clear: left">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="250px" CssClass="normalText">
                            <asp:ListItem>RED 032 C</asp:ListItem>
                            <asp:ListItem>REFLEX BLUE C</asp:ListItem>
                            <asp:ListItem>RHODAMINE RED C</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; width: 40%">
                        <asp:TextBox ID="TextBox1" runat="server" Width="50px" CssClass="txtbox">10</asp:TextBox>
                    </div>
                </fieldset>
            </div>
            <div style="clear: both">
                &nbsp;</div>
            <div align="left" style="width: 100%">
                <fieldset style="padding: 8px">
                    <legend class="HeaderText">Side 2</legend>
                    <div style="float: left; width: 100%">
                        <div style="float: left; width: 20%">
                            &nbsp;</div>
                        <div style="float: left; width: 30%">
                            <span>Ink</span></div>
                        <div style="float: left; width: 20%">
                            <span>Coverage %</span></div>
                    </div>
                    <div style="float: left; width: 50%">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="250px" CssClass="normalText">
                            <asp:ListItem>Black C</asp:ListItem>
                            <asp:ListItem>BLACK C</asp:ListItem>
                            <asp:ListItem>BLACK C Hexachrome</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; width: 40%">
                        <asp:TextBox ID="TextBox2" runat="server" Width="50px" CssClass="txtbox">10</asp:TextBox>
                    </div>
                    <div style="float: left; width: 50%; clear: left">
                        <asp:DropDownList ID="DropDownList3" runat="server" Width="250px" CssClass="normalText">
                            <asp:ListItem>RED 032 C</asp:ListItem>
                            <asp:ListItem>REFLEX BLUE C</asp:ListItem>
                            <asp:ListItem>RHODAMINE RED C</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; width: 40%">
                        <asp:TextBox ID="TextBox3" runat="server" Width="50px" CssClass="txtbox">10</asp:TextBox>
                    </div>
                </fieldset>
            </div>
            <div style="clear: both">
                &nbsp;</div>
            <div align="left" style="width: 100%">
                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" Width="65px" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="button" Width="65px" />
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>
</div>


