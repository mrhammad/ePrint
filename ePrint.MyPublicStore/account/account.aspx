<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="ePrint.MyPublicStore.account.account" masterpagefile="~/Templates/masterPageDefault.master" %>


<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .common-sprite
        {
            background-image: url('../images/common_sprite_v1.png');
            background-repeat: no-repeat;
        }
    </style>
    <div id="accountInfoMain_div" class="contentArea_Background">
        <div id="div_NavigationID" runat="server" class="navigation_div">
            <a href="<%=strSitepath%>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label></a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label><%=objLanguage.GetLanguageConversion("My_DashBoard") %>
        </div>
        <div id="accountInfo_background">
            <div id="accountInfoContent_div">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right">
                    <div id="heading" class="Header_Background">
                        <strong>
                            <%=objLanguage.GetLanguageConversion("My_Dashboard") %>
                        </strong>
                    </div>
                    <div id="accountInfoContent_right_content">
                        <div id="accountInformation">
                            <img id="img_accountHolder" src="../ImageHandler.ashx?Imagename=i_ma-info.gif&amp;type=r"
                                alt=" " />
                            <asp:Label ID="lbl_accountInfo" runat="server" Text="ACCOUNT INFORMATION" class="lblStyle1"><%=objLanguage.GetLanguageConversion("Account_Information_Capital") %></asp:Label>
                        </div>
                        <div id="accountInformation_area">
                            <div id="contactInformation">
                                <div id="contactInformation_heading">
                                    <div id="contactInformation_heading_left">
                                        <asp:Label ID="lbl_contactInformation" runat="server" Text="Contact Information"
                                            class="lblStyle2"><%=objLanguage.GetLanguageConversion("Contact_Information") %></asp:Label></div>
                                    <div id="contactInformation_heading_right">
                                        <a href="<%=strSitepath%>account/accountedit<%=FileExtension %>" id="href_edit" class="anchorColor">
                                            <%=objLanguage.GetLanguageConversion("Edit") %></a></div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="contactInformation_contents">
                                    <div id="information">
                                        <asp:Label ID="lbl_information" runat="server" Text="Rajesh<br/>124, I stage<br/>Bangalore<br/>"></asp:Label>
                                    </div>
                                    <div id="changePwd">
                                        <a href="<%=strSitepath%>account/accountedit<%=FileExtension %>?type=p" id="A1" class="anchorColor">
                                            <%=objLanguage.GetLanguageConversion("Change_Password") %></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="clearBoth">
                        </div>
                        <div id="addressBook_area">
                            <div id="addressBook">
                                <div id="addressBook_heading">
                                    <div id="addressBook_heading_left">
                                        <asp:Label ID="lbl_addressBook" runat="server" Text="Address Book" class="lblStyle2"><%=objLanguage.GetLanguageConversion("Address_Book") %></asp:Label></div>
                                    <div id="addressBook_heading_right">
                                        <a href="addressbook.aspx" id="A2" class="anchorColor">
                                            <%=objLanguage.GetLanguageConversion("Manage_Addresses")%></a></div>
                                </div>
                                <div class="clearBoth">
                                </div>
                                <div id="addressBook_contents">
                                    <div id="addressBook_Info">
                                        <div id="addressBook_Info_left">
                                            <div id="addressBook_Info_left_heading" runat="server" class="addressBook_Info_left_heading">
                                                <asp:Label ID="Label2" runat="server" Text="Default Invoice Address"><%=objLanguage.GetLanguageConversion("Default_Invoice_Address")%></asp:Label>
                                            </div>
                                            <div id="addressBook_Info_left_content">
                                                <asp:Label ID="lblBillingAddress" runat="server" Text="asdfasfsd"></asp:Label>
                                            </div>
                                            <div id="billing_editAddress" runat="server">
                                                <a href="#" onclick="onclick_address('billing');" id="A3" class="anchorColor">
                                                    <%=objLanguage.GetLanguageConversion("Edit_Address")%></a>
                                            </div>
                                        </div>
                                        <div id="addressBook_Info_right">
                                            <div id="addressBook_Info_right_heading" runat="server" class="addressBook_Info_right_heading">
                                                <asp:Label ID="Label5" runat="server" Text="Default Delivery Address"><%=objLanguage.GetLanguageConversion("Default_Delivery_Address")%></asp:Label>
                                            </div>
                                            <div id="addressBook_Info_right_content">
                                                <asp:Label ID="lblShippingAddress" runat="server" Text="asdfasfsd"></asp:Label>
                                            </div>
                                            <div id="shipping_editAddress" runat="server">
                                                <a href="#" onclick="onclick_address('shipping');" id="A4" class="anchorColor">
                                                    <%=objLanguage.GetLanguageConversion("Edit_Address")%></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript">
        var DefaultBillingID = '<%=DefaultBillingID %>';
        var DefaultShippingID = '<%=DefaultShippingID %>';
        var IsPrivate_SystemName = '<%=IsPrivate_SystemName %>';

        var addressBook_Info_left = document.getElementById("addressBook_Info_left");

        function onclick_address(type) {
            if (Rewritemodule.toLowerCase() == "on") {
                if (type.toLowerCase() == "billing") {
                    window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultBillingID + KeySeparator + "acc" + FileExtension;
                }
                else if (type.toLowerCase() == "shipping") {
                    window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultShippingID + KeySeparator + "acc" + FileExtension;
                }
            }
            else {
                if (type.toLowerCase() == "billing") {
                    window.location = strSitepath + "account/addressbooknew.aspx?ID=" + DefaultBillingID + "&amp;type=acc";
                }
                else if (type.toLowerCase() == "shipping") {
                    window.location = strSitepath + "account/addressbooknew.aspx?ID=" + DefaultShippingID + "&amp;type=acc";
                }
            }
        }

        function IfB2B_System() {
            if (IsPrivate_SystemName == "True")
                addressBook_Info_left.style.display = "none";
        }
        //        IfB2B_System();

    </script>
</asp:Content>

