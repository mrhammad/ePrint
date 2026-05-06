<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addressbook.aspx.cs" Inherits="ePrint.MyPublicStore.account.addressbook" masterpagefile="~/Templates/masterPageDefault.master" %>

<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="accountInfoMain_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitepath%>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="<%=strSitepath%>account/account<%=FileExtension %>">
                <%=objLanguage.GetLanguageConversion("My_Account") %></a> >
            <%=objLanguage.GetLanguageConversion("My_Address_Book") %>
        </div>
        <div id="accountInfo_background">
            <div id="accountInfoContent_div">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right">
                    <div id="addressbook_div">
                        <div id="addressbook_heading" class="Header_Background">
                            <div id="addressbookheading_left">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("My_Address_Book") %>
                                </strong>
                            </div>
                            <div id="addressbookheading_right">
                                <asp:Button ID="btn_new_address" runat="server" class="WS_Buttons_Style" Text="Add New Address"
                                    OnClick="btn_new_address_Click" />
                            </div>
                        </div>
                        <div id="addressbook_Content">
                            <div id="addressbook_Content_left">
                                <div id="div_InvoiceDetails" class="marginBottom10">
                                    <div id="addressbook_Content_left_header" runat="server" class="addressbook_Content_left_header">
                                        <strong>
                                            <%=objLanguage.GetLanguageConversion("Default_Invoice_Address") %>
                                        </strong>
                                    </div>
                                    <div id="addressbook_Content_left_contents">
                                        <div id="addressbook_Content_left_contents_details">
                                            <asp:Label ID="lbl_addressDetails" runat="server" Text=" "></asp:Label>
                                        </div>
                                        <div id="addressbook_Content_left_contents_link">
                                            <a href="#" onclick="onclick_address(0,'billing');" id="href_change_billing_address"
                                                runat="server" class="anchorColor">
                                                <%=objLanguage.GetLanguageConversion("Edit_Address") %></a>
                                        </div>
                                    </div>
                                </div>
                                    <div id="shipping_Content_left_header" runat="server" class="shipping_Content_left_header">
                                    <strong>
                                        <%=objLanguage.GetLanguageConversion("Default_Delivery_Address") %>
                                    </strong>
                                </div>
                                <div id="shipping_Content_left_contents">
                                    <div id="shipping_Content_left_contents_details">
                                        <asp:Label ID="lbl_ashippingDetails" runat="server" Text="Rajest1<br/>Rajest1<br/>Rajest1<br/>"></asp:Label>
                                    </div>
                                    <div id="shipping_Content_left_contents_link">
                                        <a href="#" onclick="onclick_address(0,'shipping');" id="href_change_shipping_address"
                                            runat="server" class="anchorColor">
                                            <%=objLanguage.GetLanguageConversion("Edit_Address") %></a>
                                    </div>
                                </div>
                            </div>
                            <div id="addressbook_Content_right">
                                <div id="addressbook_Content_right_header">
                                    <strong>
                                        <%=objLanguage.GetLanguageConversion("Additional_Address_Entries") %>
                                    </strong>
                                </div>
                                <div id="addressbook_Content_right_contents">
                                    <asp:PlaceHolder ID="plhAddition" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var DefaultBillingID = '<%=DefaultBillingID %>';
        var DefaultShippingID = '<%=DefaultShippingID %>';
        var IsPrivate_SystemName = '<%=IsPrivate_SystemName %>';

        var addressbook_Content_left_contents = document.getElementById("addressbook_Content_left_contents");
        var addressbook_Content_left_header = document.getElementById("ctl00_ContentPlaceHolder1_addressbook_Content_left_header");
        var div_InvoiceDetails = document.getElementById("div_InvoiceDetails");

        function IfB2B_System() {
            if (IsPrivate_SystemName == "True") {
                addressbook_Content_left_contents.style.display = "none";
                addressbook_Content_left_header.style.display = "none";
                div_InvoiceDetails.style.margin = "0px";
            }
        }
        //IfB2B_System();
    
    </script>
    <script type="text/javascript" src="<%=strSitepath%>js/addressbook.js?VN='<%=VersionNumber%>'"></script>
</asp:Content>


