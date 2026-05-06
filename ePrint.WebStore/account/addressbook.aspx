<%@ page title="Address Book" language="C#" masterpagefile="~/Templates/masterPageDefault.master" autoeventwireup="true"  CodeBehind="addressbook.aspx.cs" Inherits="ePrint.WebStore.account.addressbook" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/Account.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="accountInfoMain_div">
        <div id="accountInfo_background">
            <div id="accountInfoContent_div_Accountpage">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right_withBrderLft">
                    <div id="addressbook_div">
                        <div id="addressbook_heading" class="Header_Background">
                            <table>
                                <tr>
                                    <td class="td495px">
                                        <div id="addressbookheading_left">
                                            <strong>
                                                <%=objLanguage.GetLanguageConversion("My_Address_book") %>
                                            </strong>
                                        </div>
                                    </td>
                                    <td>
                                        <div id="addressbookheading_right" style="float: right;">
                                            <div id="div_btnsave">
                                                <asp:Button ID="btn_new_address" runat="server" class="x-btnpro Grey main" Text="Add a New Address"
                                                    OnClick="btn_new_address_Click" OnClientClick="javascript:loadingimg('div_btnsave', 'div_btnsaveprocess');" />
                                            </div>
                                            <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                                <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="addressbook_Content">
                            <div id="addressbook_Content_left">
                                <%--  <table>
                                    <tr>
                                        <td class="td495px">--%>
                                <div id="div_InvoiceDetails" class="manageaddresswidth">
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
                                                <%=objLanguage.GetLanguageConversion("Edit") %></a>
                                        </div>
                                    </div>
                                </div>
                                <%-- </td>
                                        <td>--%>
                                <div id="addressBook_Info_right">
                                    <div id="shipping_Content_left_header" runat="server" class="shipping_Content_left_header">
                                        <strong>
                                            <%=objLanguage.GetLanguageConversion("Default_Delivery_Address") %>
                                        </strong>
                                    </div>
                                    <div class="clearBoth">
                                    </div>
                                    <div id="shipping_Content_left_contents">
                                        <div id="shipping_Content_left_contents_details">
                                            <asp:Label ID="lbl_ashippingDetails" runat="server" Text="Rajest1<br/>Rajest1<br/>Rajest1<br/>"></asp:Label>
                                        </div>
                                        <div id="shipping_Content_left_contents_link">
                                            <a href="#" onclick="onclick_address(0,'shipping');" id="href_change_shipping_address"
                                                runat="server" class="anchorColor">
                                                <%=objLanguage.GetLanguageConversion("Edit") %></a>
                                        </div>
                                    </div>
                                </div>
                                <%--</td>
                                    </tr>
                                </table>--%>
                            </div>
                            <div id="AdditionalAddress" runat="server" style="display: none">
                                <div id="addressbook_Content_right">
                                    <div id="addressbook_Content_right_header">
                                        <strong>
                                            <%=objLanguage.GetLanguageConversion("Additional_Address")%>
                                        </strong>
                                    </div>
                                    <div id="addressbook_Content_right_contents">
                                        <table>
                                            <asp:PlaceHolder ID="plhAddition" runat="server"></asp:PlaceHolder>
                                        </table>
                                    </div>
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
    </script>
    <script type="text/javascript" src="<%=strSitepath%>js/addressbook.js?VN='<%=VersionNumber%>'"></script>
</asp:Content>
