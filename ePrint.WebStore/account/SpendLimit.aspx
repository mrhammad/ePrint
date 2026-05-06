<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpendLimit.aspx.cs" Inherits="ePrint.WebStore.account.SpendLimit" MasterPageFile="~/Templates/masterPageDefault.master" %>

<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="accountInfoMain_div">
        <div id="accountInfo_background">
            <div id="accountInfoContent_div_Accountpage">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right_withBrderLft">

                    <div id="createAccount_content_right">
                        <div id="heading" class="Header_Background Heading_AddressEditpage">
                            Spend Limit
                        </div>
                        <br />
                        <br />
                        <br />

                        <div style="margin-left: 5px;">
                            <asp:Label ID="lblSpenlimit" runat="server"> </asp:Label>


                        </div>

                        <div style="margin-left: 5px;">
                            <asp:Label ID="lblCurrentSpend" runat="server"> </asp:Label>


                        </div>

                        <div style="margin-left: 5px;">
                            <asp:Label ID="lblBalance" runat="server"> </asp:Label>


                        </div>

                         <div style="margin-left: 5px;">
                            <asp:Label ID="lblStoreCredit" runat="server"> </asp:Label>


                        </div>

                        <br />
                        <div class="clearBoth">
                        </div>
                        <div id="createAccount_content_bottom">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
