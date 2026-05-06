<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="account_leftpanel.ascx.cs" Inherits="ePrint.WebStore.usercontrol.account_leftpanel" %>


<asp:Panel runat="server" ID="pnlaccount" Visible="true">
    <script src="../js/default.js" type="text/javascript"></script>
    <div id="accountInfoContent_left">
        <div class="Hederfont paddingLeft5">
            <strong>
                <%=objLAnguage.GetLanguageConversion("My_Account") %>
            </strong>
        </div>
        <div id="accountInfoContent_left_content">
            <div class="marginTop5px marginBottom">
                <div id="href_account" runat="server">
                    <a href="<%=strSitepath %>account/account<%=FileExtension %>" title="Account Information">
                        <%=objLAnguage.GetLanguageConversion("Account_Information") %></a><br />
                </div>
                <div id="href_accountedit" runat="server" class="paddingTop5">
                    <a href="<%=strSitepath %>account/accountedit<%=FileExtension %>" title="My Account Information">
                        <%=objLAnguage.GetLanguageConversion("Edit_Account_Information") %></a><br />
                </div>
                <div id="href_addressbook" runat="server" class="paddingTop5">
                    <a href="<%=strSitepath %>account/addressbook<%=FileExtension %>" title="My Address Book">
                        <%=objLAnguage.GetLanguageConversion("My_Address_Book") %></a><br />
                </div>
                 <div id="Div1" runat="server" class="paddingTop5">
                    <a href="<%=strSitepath %>account/SpendLimit<%=FileExtension %>" title="Spend Limit">
                        Spend Limit</a><br />
                </div>
            </div>
        </div>
    </div>
    <div class="clearBoth">
    </div>
    <div class="account_leftBanner" id="account_leftBanner" runat="server">
        <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
    </div>
    <script type="text/javascript" language="javascript">
        var strSitepath = '<%=strSitepath %>';
    </script>
</asp:Panel>
