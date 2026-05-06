<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Mailchimp_Integration.aspx.cs" Inherits="ePrint.settings.Mailchimp_Integration" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left" style="width: 100%">
        <div class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div class="Mailchimpwidth">
                    <div id="padding">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table class="Mailchimptablewidth">
                            <tr>
                                <td class="Mailchimpbglabel">
                                    <div>
                                        <asp:Label ID="lblAPI" runat="server" Text="" CssClass="normaltext">
<%=objlang.GetLanguageConversion("API_Key")%></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div class="MailchimpAPIKey">
                                        <div>
                                            <asp:TextBox ID="txtAPIKey" runat="server" CssClass="Mailchimptxtbox"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblInRecord" runat="server" Visible="false">In Record</asp:Label>
                                            <asp:ImageButton ID="imgEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/Edit.gif"
                                                OnClick="imgEdit_OnClick" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div id="div_cancelprocess" class="autocancelProcess">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                    <asp:Button runat="server" ID="btnGetList" Text="" OnClick="btnGetList_OnClick" class="button"
                                        OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
                                </td>
                            </tr>
                            <tr id="listid" runat="server" visible="false">
                                <td class="Mailchimpbglabel">
                                    <div class="bglabelnew">
                                        <asp:Label ID="lblList" runat="server" Text="" CssClass="normaltext">
<%=objlang.GetLanguageConversion("Select_Default_List_ID")%></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlListID" runat="server" CssClass="MailchimpDefaultSettingsbox normaltext">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="box">
                                </td>
                            </tr>
                            <tr id="tdbtn" runat="server" visible="false">
                                <td>
                                </td>
                                <td>
                                    <div id="div_updateloading" class="autocancelProcess">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                    <asp:Button ID="btnSave" Text="" runat="server" class="button" OnClick="btnSave_OnClick"
                                        OnClientClick="javascript:loadingimage(this.id,'div_updateloading');" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="box">
                                    <span class="smallgraytext">
                                        <asp:Label ID="lblMailchimpmsg" runat="server" Style="white-space: nowrap;"> <%=objlang.GetLanguageConversion("To_send_contacts_from_your_CRM_module_to_Mail_Chimp_you_need_to_tick_the_box_for_Subscribed_user_in_each_conatct_record")%></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

