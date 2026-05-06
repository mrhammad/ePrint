<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="B2BSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.B2BSubSection" %>

<div id="div_B2B" runat="server" style="width: 100%; display: block; height: 450px">
    <asp:UpdatePanel ID="up_b2bInfo" RenderMode="Inline" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="margin: 10px 0px 0px 10px; display: none;" id="div_B2B_Button" runat="server">
                <asp:Button ID="btn_b2bCreate" runat="server" CssClass="Button" OnClientClick="javascript:return showAccount();"
                    Text="" />
            </div>
            <div id="div_B2B_Link" runat="server" style="margin: 10px 0px 0px 10px; display: none;">
                <b>
                    <asp:Label ID="lbl_b2b_eStoreLink" runat="server" > <%=objLangClass.GetLanguageConversion("B2B_EStore_URL")%> </asp:Label></b>
                <div style="padding-top: 8px;">
                    <a id="lnk_b2beStoreLink" href='<%=WebStorePathB2B %>' target="_blank">
                        <asp:Label ID="lbl_b2beStoreLink" runat="server"></asp:Label></a></div>
            </div>
            <div id="div_B2C_Link" runat="server" style="margin: 10px 0px 0px 10px; display: none;">
                <b>
                    <asp:Label ID="lbl_b2c_eStoreLink" runat="server" Text="B2C eStore URL"></asp:Label></b>
                <div style="padding-top: 8px;">
                    <a id="lnk_b2ceStoreLink" href='<%=WebStorePathB2C %>' target="_blank">
                        <asp:Label ID="lbl_b2ceStoreLink" runat="server"></asp:Label></a></div>
            </div>
            <div id="div_account" runat="server" style="display: none; margin: 0px 10px 0px 0px;
                border: solid 0px green">
                <iframe id="ifrm_accounts" runat="server" scrolling="no" style="border: solid 0px green;
                    height: auto; width: 100%"></iframe>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div id="div_B2BMsg" runat="server" style="width: 100%; display: none; height: 500px">
    <div id="Div1" style="margin: 10px 0px 0px 10px; display: block;" runat="server">
<%--        <asp:Label ID="lvl_B2BMsg" runat="server" Text="Not applicable to your system. Contact support@eprintsoftware.com for more information"></asp:Label>--%>
                <asp:Label ID="lvl_B2BMsg" runat="server" Text="Not applicable to your system. Contact support@hexicomsoftware.com for more information"></asp:Label>
    </div>
</div>

<script type="text/javascript" language="javascript">

    var div_account = document.getElementById("<%=div_account.ClientID %>");
    var div_B2B_Link = document.getElementById("<%=div_B2B_Link.ClientID %>");
    var lbl_b2beStoreLink = document.getElementById("<%=lbl_b2beStoreLink.ClientID %>");

    var WebStorePathB2B = '<%=WebStorePathB2B %>';
    var WebStorePathB2C = '<%=WebStorePathB2C %>';

</script>

<%-- src="../Accounts/account_new_create_withoutTemplate.aspx?from=client&type=Customer&mode=add&clientID=<%=ClientID %>"--%>